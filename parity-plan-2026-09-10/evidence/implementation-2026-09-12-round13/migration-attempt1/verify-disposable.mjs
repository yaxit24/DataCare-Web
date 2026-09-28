#!/usr/bin/env node
/** Staged, unexecuted migration harness. Run only through the isolated parity wrapper. */
import assert from 'node:assert/strict';
import { createHash, randomBytes } from 'node:crypto';
import { spawnSync } from 'node:child_process';
import { readFileSync, writeFileSync } from 'node:fs';
import { dirname, join } from 'node:path';
import { fileURLToPath } from 'node:url';

const folder = dirname(fileURLToPath(import.meta.url));
const digest = (bytes) => createHash('sha256').update(bytes).digest('hex');
const pinned = JSON.parse(readFileSync(join(folder, 'inputs.json'), 'utf8'));
const files = {
  migration: join(folder, 'migration.sql'),
  baseline: join(folder, 'independent/baseline.sql'),
  cases: join(folder, 'independent/migration-independent-cases.json'),
};
const bytes = Object.fromEntries(
  Object.entries(files).map(([key, path]) => [key, readFileSync(path)]),
);
for (const [key, value] of Object.entries(bytes)) {
  assert.equal(digest(value), pinned[key], `${key} input changed before execution`);
}
const cases = JSON.parse(bytes.cases.toString('utf8')).cases;
assert.ok(Array.isArray(cases) && cases.length > 0, 'Independent cases are required');
assert.equal(cases.length, pinned.caseCount);
assert.equal(new Set(cases.map((item) => item.id)).size, cases.length, 'Duplicate case IDs');

function isolatedUrl(name, user) {
  assert.ok(process.env[name], `${name} must come from the isolated wrapper`);
  let url;
  try {
    url = new URL(process.env[name]);
  } catch {
    throw new Error(`${name} must be a valid isolated database URL`);
  }
  assert.ok(['postgres:', 'postgresql:'].includes(url.protocol));
  assert.ok(['127.0.0.1', 'localhost', '[::1]'].includes(url.hostname));
  assert.equal(url.port, '55433', 'Only disposable port 55433 is admitted');
  assert.equal(decodeURIComponent(url.username), user);
  assert.equal(url.pathname, '/datacare');
  assert.ok(url.password);
  for (const [key, value] of url.searchParams) {
    assert.ok(key === 'schema' && value === 'public', 'Unexpected database URL option');
  }
  return url;
}
const ownerUrl = isolatedUrl('MIGRATE_DATABASE_URL', 'datacare');
const appUrl = isolatedUrl('DATABASE_URL', 'app_user');
assert.equal(appUrl.hostname, ownerUrl.hostname);
assert.equal(appUrl.port, ownerUrl.port);

const owned = new Map();
const newColumns = new Set([
  'context_epoch',
  'ledger_context',
  'last_context_selection_id',
  'last_context_request_sha256',
  'last_context_from_epoch',
]);
const newConstraints = new Set([
  'auth_session_context_epoch_v1_check',
  'auth_session_ledger_context_v1_check',
  'auth_session_context_receipt_v1_check',
]);
const safeMessage = (message) => {
  let out = String(message);
  for (const url of [ownerUrl, appUrl]) {
    out = out.replaceAll(decodeURIComponent(url.password), '[redacted]');
    out = out.replaceAll(url.password, '[redacted]');
  }
  return out;
};
function psql(database, input, { app = false, allowFailure = false } = {}) {
  assert.ok(database === 'datacare' || owned.has(database), 'Database is not owned by this run');
  const url = app ? appUrl : ownerUrl;
  // Do not pass credentials in argv, print connection URLs, or inherit PGHOSTADDR/PGSERVICE.
  const env = Object.fromEntries(
    Object.entries(process.env).filter(([key]) => !key.startsWith('PG')),
  );
  Object.assign(env, {
    PGHOST: url.hostname === '[::1]' ? '::1' : url.hostname,
    PGPORT: url.port,
    PGUSER: decodeURIComponent(url.username),
    PGPASSWORD: decodeURIComponent(url.password),
    PGSSLMODE: 'disable',
    PGCONNECT_TIMEOUT: '5',
  });
  const result = spawnSync(
    'psql',
    [
      '-X',
      '--no-password',
      '--quiet',
      '--tuples-only',
      '--no-align',
      '--set',
      'ON_ERROR_STOP=1',
      '--dbname',
      database,
    ],
    { input, env, encoding: 'utf8', timeout: 30_000, maxBuffer: 8 * 1024 * 1024 },
  );
  if (result.error) throw new Error(`psql process failed: ${safeMessage(result.error.message)}`);
  const output = {
    status: result.status,
    stdout: result.stdout.trim(),
    stderr: safeMessage(result.stderr),
  };
  if (!allowFailure && output.status !== 0) {
    throw new Error(`psql failed (${output.status}): ${output.stderr}`);
  }
  return output;
}
function query(database, sql, options) {
  const result = psql(database, sql, options);
  return JSON.parse(result.stdout);
}
function quoteOwned(database) {
  assert.match(database, /^datacare_context_migration_[0-9a-f]{24}$/);
  return `"${database}"`;
}
function createDatabase() {
  const suffix = randomBytes(12).toString('hex');
  const database = `datacare_context_migration_${suffix}`;
  const marker = `datacare-session-context-migration:${suffix}`;
  // Register only after successful CREATE; pre-existing databases are never adopted.
  psql('datacare', `CREATE DATABASE ${quoteOwned(database)} OWNER datacare TEMPLATE template0;`);
  owned.set(database, { marker, marked: false });
  psql('datacare', `COMMENT ON DATABASE ${quoteOwned(database)} IS '${marker}';`);
  owned.set(database, { marker, marked: true });
  return database;
}
function dropDatabase(database) {
  const receipt = owned.get(database);
  assert.ok(receipt, 'Cannot drop an unowned database');
  const observed = query(
    'datacare',
    `SELECT COALESCE((SELECT json_build_object(
    'owner',pg_get_userbyid(datdba),'marker',shobj_description(oid,'pg_database'))
    FROM pg_database WHERE datname='${database}'),'null'::json);`,
  );
  if (observed === null) {
    owned.delete(database);
    return;
  }
  assert.equal(observed.owner, 'datacare');
  assert.equal(observed.marker, receipt.marked ? receipt.marker : null);
  psql('datacare', `DROP DATABASE ${quoteOwned(database)};`);
  owned.delete(database);
}

function snapshot(database) {
  const metadata = query(
    database,
    `SELECT jsonb_build_object('kind',(SELECT relkind::text FROM pg_class
      WHERE oid=to_regclass('public.auth_session')),
      'hasLedgerColumn',EXISTS (SELECT 1 FROM pg_attribute
        WHERE attrelid=to_regclass('public.auth_session')
          AND attname='ledger_context' AND NOT attisdropped));`,
  );
  const rows =
    metadata.kind === 'r'
      ? `(SELECT COALESCE(jsonb_agg(jsonb_build_object('raw',
        (SELECT jsonb_object_agg(j.key,j.value) FROM jsonb_each_text(to_jsonb(t)) j),
        'ledgerContextSqlNull',${metadata.hasLedgerColumn ? 't.ledger_context IS NULL' : 'NULL'},
        'xmin',t.xmin::text,'ctid',t.ctid::text)
        ORDER BY to_jsonb(t)->>'tenant_id',to_jsonb(t)->>'session_id',t.ctid),'[]'::jsonb)
        FROM public.auth_session t)`
      : `'[]'::jsonb`;
  return query(
    database,
    `SELECT jsonb_build_object(
    'rows',${rows},
    'relation',(SELECT jsonb_build_object('oid',c.oid::text,'owner',c.relowner::text,
      'kind',c.relkind,'rls',c.relrowsecurity,'forceRls',c.relforcerowsecurity,'acl',c.relacl)
      FROM pg_class c WHERE c.oid=to_regclass('public.auth_session')),
    'columns',COALESCE((SELECT jsonb_agg(jsonb_build_object('name',a.attname,'position',a.attnum,
      'type',a.atttypid::text,'modifier',a.atttypmod,'collation',a.attcollation::text,
      'notNull',a.attnotnull,'identity',a.attidentity,'generated',a.attgenerated,
      'default',pg_get_expr(d.adbin,d.adrelid),'acl',a.attacl) ORDER BY a.attnum)
      FROM pg_attribute a LEFT JOIN pg_attrdef d ON d.adrelid=a.attrelid AND d.adnum=a.attnum
      WHERE a.attrelid=to_regclass('public.auth_session') AND a.attnum>0 AND NOT a.attisdropped),'[]'::jsonb),
    'constraints',COALESCE((SELECT jsonb_agg(jsonb_build_object('name',c.conname,
      'type',c.contype,'definition',pg_get_constraintdef(c.oid),'validated',c.convalidated,
      'noInherit',c.connoinherit) ORDER BY c.conname)
      FROM pg_constraint c WHERE c.conrelid=to_regclass('public.auth_session')),'[]'::jsonb),
    'indexes',COALESCE((SELECT jsonb_agg(jsonb_build_object('name',indexname,'definition',indexdef)
      ORDER BY indexname) FROM pg_indexes WHERE schemaname='public' AND tablename='auth_session'),'[]'::jsonb),
    'policies',COALESCE((SELECT jsonb_agg(jsonb_build_object('name',p.polname,'command',p.polcmd,
      'permissive',p.polpermissive,'roles',p.polroles,'using',pg_get_expr(p.polqual,p.polrelid),
      'check',pg_get_expr(p.polwithcheck,p.polrelid)) ORDER BY p.polname)
      FROM pg_policy p WHERE p.polrelid=to_regclass('public.auth_session')),'[]'::jsonb),
    'triggers',COALESCE((SELECT jsonb_agg(jsonb_build_object('name',t.tgname,'enabled',t.tgenabled,
      'internal',t.tgisinternal,'definition',pg_get_triggerdef(t.oid)) ORDER BY t.tgname)
      FROM pg_trigger t WHERE t.tgrelid=to_regclass('public.auth_session')),'[]'::jsonb),
    'rules',COALESCE((SELECT jsonb_agg(jsonb_build_object('name',r.rulename,
      'enabled',r.ev_enabled,'definition',pg_get_ruledef(r.oid)) ORDER BY r.rulename)
      FROM pg_rewrite r WHERE r.ev_class=to_regclass('public.auth_session')),'[]'::jsonb),
    'inheritance',COALESCE((SELECT jsonb_agg(to_jsonb(i) ORDER BY i.inhrelid,i.inhseqno)
      FROM pg_inherits i WHERE i.inhrelid=to_regclass('public.auth_session')
      OR i.inhparent=to_regclass('public.auth_session')),'[]'::jsonb));`,
  );
}
function legacyProjection(state) {
  return {
    ...state,
    rows: state.rows.map(({ raw }) =>
      Object.fromEntries(Object.entries(raw).filter(([key]) => !newColumns.has(key))),
    ),
    columns: state.columns.filter((column) => !newColumns.has(column.name)),
    constraints: state.constraints.filter((constraint) => !newConstraints.has(constraint.name)),
  };
}
function assertExistingNewValuesPreserved(before, after) {
  const identity = (row) => JSON.stringify([row.raw.tenant_id, row.raw.session_id]);
  const saved = new Map(after.rows.map((row) => [identity(row), row]));
  for (const original of before.rows) {
    const current = saved.get(identity(original));
    assert.ok(current, 'A pre-existing tenant/session row disappeared');
    for (const column of newColumns) {
      if (Object.hasOwn(original.raw, column) && original.raw[column] !== null) {
        assert.equal(current.raw[column], original.raw[column], `Existing ${column} changed`);
      }
    }
  }
}
function assertRls(database, state) {
  const tenants = [...new Set(state.rows.map((row) => row.raw.tenant_id))];
  for (const tenant of tenants) {
    assert.match(tenant, /^[a-z0-9-]+$/);
    const visible = query(
      database,
      `BEGIN;
      DO $scope$ BEGIN PERFORM set_config('app.tenant_id','${tenant}',true); END $scope$;
      SELECT COALESCE(jsonb_agg(jsonb_build_object('tenant',tenant_id,'session',session_id)
        ORDER BY session_id),'[]'::jsonb) FROM public.auth_session;
      ROLLBACK;`,
      { app: true },
    );
    const expected = state.rows
      .filter((row) => row.raw.tenant_id === tenant)
      .map((row) => ({ tenant, session: row.raw.session_id }))
      .sort((a, b) => a.session.localeCompare(b.session));
    assert.deepEqual(visible, expected);
  }
  const unset = query(database, `SELECT to_jsonb(count(*)::text) FROM public.auth_session;`, {
    app: true,
  });
  assert.equal(unset, '0');
}

const report = {
  kind: 'staged-session-context-migration-disposable-verification-v1',
  startedAt: new Date().toISOString(),
  migrationSha256: pinned.migration,
  baselineSha256: pinned.baseline,
  casesSha256: pinned.cases,
  exactMigrationBytesPreserved: true,
  target: 'localhost:55433; only generated datacare_context_migration_ databases',
  results: [],
};
let failed;
try {
  const target = query(
    'datacare',
    `SELECT json_build_object('database',current_database(),
    'user',current_user,'canBypassRls',rolsuper OR rolbypassrls,'canCreate',rolsuper OR rolcreatedb)
    FROM pg_roles WHERE rolname=current_user;`,
  );
  assert.deepEqual(target, {
    database: 'datacare',
    user: 'datacare',
    canBypassRls: true,
    canCreate: true,
  });
  for (const item of cases) {
    assert.match(item.id, /^[A-Z][0-9]{2}$/);
    assert.ok(['success', 'failure'].includes(item.expected));
    const database = createDatabase();
    try {
      psql(database, bytes.baseline);
      if (item.setupSql) psql(database, item.setupSql);
      const before = snapshot(database);
      // The exact frozen Buffer, including its own BEGIN and COMMIT, is sent unchanged to psql.
      const result = psql(database, bytes.migration, { allowFailure: true });
      const after = snapshot(database);
      if (item.expected === 'failure') {
        assert.notEqual(result.status, 0, `${item.id} unexpectedly accepted an incompatible state`);
        if (item.messageIncludes)
          assert.ok(result.stderr.includes(item.messageIncludes), result.stderr);
        assert.deepEqual(after, before, `${item.id} failed migration left schema/data changes`);
      } else {
        assert.equal(result.status, 0, result.stderr);
        assert.deepEqual(
          legacyProjection(after),
          legacyProjection(before),
          `${item.id} changed legacy state`,
        );
        assertExistingNewValuesPreserved(before, after);
        const expectedNames = [...newColumns].sort();
        assert.deepEqual(
          after.columns
            .filter((c) => newColumns.has(c.name))
            .map((c) => c.name)
            .sort(),
          expectedNames,
        );
        assert.equal(
          after.constraints.filter((c) => newConstraints.has(c.name) && c.validated).length,
          3,
        );
        if (item.checksSql)
          assert.equal(
            psql(database, item.checksSql).stdout,
            't',
            `${item.id} expected state differs`,
          );
        assertRls(database, after);
        psql(database, bytes.migration);
        assert.deepEqual(snapshot(database), after, `${item.id} second application changed state`);
      }
      for (const [key, path] of Object.entries(files)) {
        assert.equal(digest(readFileSync(path)), pinned[key], `${key} changed during execution`);
      }
      report.results.push({ id: item.id, expected: item.expected, passed: true });
      console.log(`PASS ${item.id} ${item.expected}`);
    } finally {
      dropDatabase(database);
    }
  }
} catch (error) {
  failed = error;
  report.error = safeMessage(error instanceof Error ? error.message : error);
} finally {
  for (const database of [...owned.keys()]) {
    try {
      dropDatabase(database);
    } catch (error) {
      report.cleanupErrors ??= [];
      report.cleanupErrors.push({ database, message: safeMessage(error.message) });
      failed ??= error;
    }
  }
  report.completedAt = new Date().toISOString();
  report.passed = !failed && report.results.length === cases.length;
  report.remainingOwnedDatabases = [...owned.keys()];
  writeFileSync(join(folder, 'verification-result.json'), `${JSON.stringify(report, null, 2)}\n`);
}
if (failed) {
  console.error(report.error ?? 'Disposable migration cleanup failed');
  process.exitCode = 1;
} else {
  console.log(
    `PASS ${report.results.length} disposable migration cases; all owned databases removed`,
  );
}
