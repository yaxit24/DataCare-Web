#!/usr/bin/env node
/**
 * Fresh-provision gate.
 *
 * WHY THIS EXISTS
 * ---------------
 * `message_attempt_log` shipped with a `tenant_id` column, no row level security and no policy. It was
 * created by a migration that ran AFTER the blanket security migration, so the blanket pass never covered it.
 * Two queries in `messaging.ts` filtered on `idempotency_key` alone and relied on RLS, so on a fresh
 * deployment a colliding key gave a cross-tenant READ of another tenant's delivery status and a cross-tenant
 * WRITE that overwrote their row.
 *
 * Every test passed throughout. The long-lived development database had acquired RLS on that table through
 * unrelated history, so nothing that looked at the running database could see the hole. It was found only by
 * provisioning a database from the migration chain and diffing it against the working one.
 *
 * That is a repeatable act, so it is a gate rather than an anecdote. Any future table added after the blanket
 * migration escapes it the same way, and this catches it on the commit that introduces it.
 *
 * WHAT IT CHECKS
 * --------------
 *  1. The migration chain applies to an empty database with no errors.
 *  2. Every table carrying `tenant_id` has RLS ENABLED and FORCED and at least one policy. Forced matters
 *     independently: without it the table owner bypasses the policy, and the API's role may own the table.
 *  3. The fresh schema matches the working database, table for table and column for column. A difference in
 *     either direction is a finding: a table only in the working database means a migration is missing, and a
 *     table only in the fresh one means the working database is behind.
 *
 * SAFETY
 * ------
 * Operates on a scratch database whose name it chooses and drops. It never connects to the working database
 * except to read `information_schema`, and it refuses to run if the scratch name collides with the target.
 */

import { execFile } from 'node:child_process';
import { promisify } from 'node:util';

const exec = promisify(execFile);

const SCRATCH = process.env.FRESH_PROVISION_DB || 'datacare_fresh_provision_gate';

const adminUrl = process.env.MIGRATE_DATABASE_URL || process.env.DATABASE_URL;
if (!adminUrl) {
  console.error('FRESH_PROVISION_SKIP no MIGRATE_DATABASE_URL/DATABASE_URL');
  process.exit(0);
}

/** Swap the database name in a connection string, keeping credentials and parameters. */
function withDatabase(url, name) {
  const u = new URL(url);
  u.pathname = `/${name}`;
  return u.toString();
}

const targetName = new URL(adminUrl).pathname.replace(/^\//, '').split('?')[0];
if (targetName === SCRATCH) {
  // Refusing rather than proceeding: this script drops the scratch database.
  console.error(
    `FRESH_PROVISION_FAIL scratch name "${SCRATCH}" is the working database; refusing to continue`,
  );
  process.exit(1);
}

const maintenanceUrl = withDatabase(adminUrl, 'postgres');
const scratchUrl = withDatabase(adminUrl, SCRATCH);

/** `psql` rejects the ?schema= parameter Prisma appends. */
const dsn = (url) => url.replace(/\?.*$/, '');

async function psql(url, sql) {
  const { stdout } = await exec('psql', [dsn(url), '-tA', '-v', 'ON_ERROR_STOP=1', '-c', sql]);
  return stdout.trim();
}

/**
 * Parse a boolean out of psql output.
 *
 * A bare boolean column prints `t`/`f`, but the moment it is CONCATENATED into text it renders as
 * `true`/`false`. The first version of this function compared against `'t'` only, so every table read as
 * unprotected and the gate reported a catastrophic isolation failure that did not exist — a false positive is
 * as damaging as a false negative, because a gate nobody believes is a gate nobody acts on.
 *
 * An unrecognised value now throws rather than defaulting to either answer.
 */
function bool(value, context) {
  const v = String(value).trim().toLowerCase();
  if (v === 't' || v === 'true') return true;
  if (v === 'f' || v === 'false') return false;
  throw new Error(`unparseable boolean "${value}" for ${context}`);
}

async function tenantTableAudit(url) {
  const out = await psql(
    url,
    `SELECT c.relname || '|' || c.relrowsecurity::text || '|' || c.relforcerowsecurity::text || '|' ||
            (SELECT count(*) FROM pg_policies p WHERE p.tablename = c.relname)::text
       FROM pg_class c
       JOIN information_schema.columns ic
         ON ic.table_schema='public' AND ic.table_name=c.relname AND ic.column_name='tenant_id'
      WHERE c.relnamespace='public'::regnamespace AND c.relkind='r'
      ORDER BY c.relname`,
  );
  return out
    .split('\n')
    .filter(Boolean)
    .map((line) => {
      const [table, rls, forced, policies] = line.split('|');
      return {
        table,
        rls: bool(rls, `${table}.relrowsecurity`),
        forced: bool(forced, `${table}.relforcerowsecurity`),
        policies: Number(policies),
      };
    });
}

async function columnSet(url) {
  const out = await psql(
    url,
    `SELECT table_name || '.' || column_name FROM information_schema.columns
      WHERE table_schema='public' AND table_name <> '_prisma_migrations' ORDER BY 1`,
  );
  return new Set(out.split('\n').filter(Boolean));
}

let created = false;
try {
  await psql(maintenanceUrl, `DROP DATABASE IF EXISTS "${SCRATCH}"`);
  await psql(maintenanceUrl, `CREATE DATABASE "${SCRATCH}"`);
  created = true;

  // Apply the chain exactly as a deployment would.
  await exec('pnpm', ['exec', 'prisma', 'migrate', 'deploy'], {
    cwd: 'packages/db',
    env: { ...process.env, DATABASE_URL: scratchUrl, MIGRATE_DATABASE_URL: scratchUrl },
  });

  const problems = [];

  // ---- 1. Tenant isolation on a clean deployment -----------------------------------------------------
  const audit = await tenantTableAudit(scratchUrl);
  if (audit.length < 100) {
    problems.push(`only ${audit.length} tenant-scoped tables found; the chain did not apply fully`);
  }
  for (const t of audit) {
    if (!t.rls || !t.forced || t.policies < 1) {
      problems.push(
        `${t.table}: has tenant_id but rls=${t.rls} forced=${t.forced} policies=${t.policies}`,
      );
    }
  }

  // ---- 2. Fresh vs working schema --------------------------------------------------------------------
  const [fresh, working] = await Promise.all([columnSet(scratchUrl), columnSet(adminUrl)]);
  // Known local drift, each with a reason. In CI the working database is itself freshly provisioned, so this
  // is normally empty; it exists so a developer machine that has accumulated an artifact stays honest about it
  // instead of the gate being switched off. An entry here is a visible open item, not an exemption from
  // thinking about it.
  const allowedExtraTables = {
    TAG_IMAGE_BLOB:
      'empty orphan left by a partially applied entity-image rename on a developer machine. A fresh ' +
      'deployment never creates it (the chain renames it to ENTITY_IMAGE), so no migration is missing. ' +
      'Pending an explicit decision to drop it, since dropping a table is irreversible.',
  };
  const allowed = (key) => Boolean(allowedExtraTables[key.split('.')[0]]);
  const onlyWorking = [...working].filter((k) => !fresh.has(k) && !allowed(k));
  const allowedSeen = [
    ...new Set([...working].filter((k) => !fresh.has(k) && allowed(k)).map((k) => k.split('.')[0])),
  ];
  const onlyFresh = [...fresh].filter((k) => !working.has(k));
  if (onlyWorking.length) {
    problems.push(
      `present in the working database but NOT produced by the migration chain (a migration is missing): ` +
        onlyWorking.slice(0, 8).join(', ') +
        (onlyWorking.length > 8 ? ` (+${onlyWorking.length - 8} more)` : ''),
    );
  }
  if (onlyFresh.length) {
    problems.push(
      `produced by the chain but absent from the working database (it is behind; run migrate deploy): ` +
        onlyFresh.slice(0, 8).join(', ') +
        (onlyFresh.length > 8 ? ` (+${onlyFresh.length - 8} more)` : ''),
    );
  }

  if (problems.length) {
    console.error('FRESH_PROVISION_FAIL');
    for (const p of problems) console.error(`  ${p}`);
    process.exit(1);
  }

  for (const t of allowedSeen) {
    console.log(`  note: allowed local drift "${t}" - ${allowedExtraTables[t].split('.')[0]}.`);
  }
  console.log(
    `FRESH_PROVISION_OK chain applies clean; ${audit.length} tenant-scoped tables all have forced RLS ` +
      `and a policy; schema matches the working database` +
      (allowedSeen.length ? ` (${allowedSeen.length} allowed drift)` : ''),
  );
} catch (e) {
  const message = e instanceof Error ? e.stderr || e.message : String(e);
  console.error(`FRESH_PROVISION_FAIL ${String(message).split('\n').slice(0, 6).join('\n  ')}`);
  process.exit(1);
} finally {
  if (created) {
    try {
      await psql(maintenanceUrl, `DROP DATABASE IF EXISTS "${SCRATCH}"`);
    } catch {
      console.error(
        `  note: scratch database "${SCRATCH}" could not be dropped; remove it manually`,
      );
    }
  }
}
