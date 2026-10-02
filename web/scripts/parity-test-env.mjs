#!/usr/bin/env node
/**
 * X03, N49: a disposable, localhost-only PostgreSQL with the migrations, forced RLS and the non-owner
 * runtime role, for database tests and the zero-mock browser suites.
 *
 * Usage (from web/):
 *   node scripts/parity-test-env.mjs -- <command...>   fresh database, run the command, tear down
 *   node scripts/parity-test-env.mjs                   fresh database, verify it, leave it running
 *   node scripts/parity-test-env.mjs --down            tear down a database left running
 *
 * Isolation (N49 step 3, gap G24):
 *   - Each checkout gets its own Compose project, a hash of its real path (override: PARITY_TEST_PROJECT),
 *     and listens on PARITY_TEST_PORT (default 55433), so two worktrees can run at once on different ports.
 *   - Every run starts from an empty volume and, after a command, ends with `down --volumes` (also on
 *     failure or Ctrl-C). Set PARITY_TEST_KEEP=1 to keep the database for inspection.
 *   - Credentials are random per run and live outside the repository, in
 *     PARITY_TEST_STATE_DIR (default ~/.cache/datacare-parity-test)/<project>.env, mode 0600.
 *   - The command receives PARITY_TEST_PROJECT, PARITY_TEST_PORT, PARITY_TEST_DATABASE,
 *     PARITY_TEST_CONTAINER_ID and PARITY_TEST_SYSTEM_IDENTIFIER (pg_control_system()). After it exits the
 *     container ID and system identifier are read again; if either changed the run fails even when the
 *     command passed. apps/api/test/globalSetup.ts checks the identifier before enabling database tests.
 *
 * Never touches the application's port 5433.
 */
import { randomBytes } from 'node:crypto';
import { spawn, spawnSync } from 'node:child_process';
import { existsSync, mkdirSync, readFileSync, realpathSync, rmSync, writeFileSync } from 'node:fs';
import { homedir } from 'node:os';
import { dirname, join, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import {
  parityTestIdentityChanges,
  parityTestPort,
  parityTestProject,
} from './lib/parity-test-env-lib.mjs';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const project = parityTestProject(realpathSync(root), process.env.PARITY_TEST_PROJECT);
const port = parityTestPort(process.env.PARITY_TEST_PORT);
const database = 'datacare';
const stateDir = resolve(
  process.env.PARITY_TEST_STATE_DIR?.trim() || join(homedir(), '.cache', 'datacare-parity-test'),
);
const secretsFile = join(stateDir, `${project}.env`);
const argv = process.argv.slice(2);
const separator = argv.indexOf('--');
const command = separator >= 0 ? argv.slice(separator + 1) : [];
const options = separator >= 0 ? argv.slice(0, separator) : argv;
if (separator >= 0 && command.length === 0) throw new Error('Expected a command after --');

class StepFailed extends Error {
  constructor(message, code = 1) {
    super(message);
    this.code = code;
  }
}

const compose = [
  'compose',
  '--project-name',
  project,
  '-f',
  resolve(root, 'docker-compose.parity-test.yml'),
];
const withSecrets = () => [...compose, '--env-file', secretsFile];
/** Compose interpolates the password even to tear down, so teardown passes a throwaway random value. */
const teardownEnv = {
  ...process.env,
  PARITY_TEST_PORT: port,
  PARITY_OWNER_PASSWORD: randomBytes(24).toString('hex'),
};

function run(cmd, args, opts = {}) {
  const result = spawnSync(cmd, args, {
    cwd: root,
    encoding: 'utf8',
    stdio: opts.input === undefined ? 'inherit' : ['pipe', 'inherit', 'inherit'],
    ...opts,
  });
  if (result.error || result.status !== 0) {
    if (opts.allowFailure) return '';
    // Never print the argument/environment objects: they may contain setup credentials.
    throw new StepFailed(`PARITY_TEST_FAILED ${cmd} exited ${result.status ?? 'before startup'}`);
  }
  return result.stdout ?? '';
}

function teardown() {
  run('docker', [...compose, 'down', '--volumes', '--remove-orphans'], {
    env: teardownEnv,
    stdio: ['ignore', 'ignore', 'inherit'],
    allowFailure: true,
  });
  rmSync(secretsFile, { force: true });
}

const psql = [
  'exec',
  '-T',
  'postgres',
  'psql',
  '-X',
  '-U',
  'datacare',
  '-d',
  database,
  '-v',
  'ON_ERROR_STOP=1',
];
function identity(env, allowFailure = false) {
  const quiet = { env, stdio: ['ignore', 'pipe', 'ignore'], allowFailure };
  return {
    containerId: run('docker', [...withSecrets(), 'ps', '-q', 'postgres'], quiet).trim(),
    systemIdentifier: run(
      'docker',
      [...withSecrets(), ...psql, '-At', '-c', 'SELECT system_identifier FROM pg_control_system()'],
      quiet,
    ).trim(),
  };
}

/** Runs the command, forwarding Ctrl-C and termination so teardown still happens afterwards. */
function runChild(cmd, args, env) {
  return new Promise((done) => {
    const child = spawn(cmd, args, { cwd: root, env, stdio: 'inherit' });
    const forward = (signal) => child.kill(signal);
    process.on('SIGINT', forward);
    process.on('SIGTERM', forward);
    child.on('error', () => done(127));
    child.on('exit', (code, signal) => {
      process.off('SIGINT', forward);
      process.off('SIGTERM', forward);
      done(code ?? (signal ? 1 : 0));
    });
  });
}

if (options.includes('--down')) {
  teardown();
  console.log(`PARITY_TEST_DOWN ${project}`);
  process.exit(0);
}
if (existsSync(resolve(root, '.env.parity-test')))
  console.warn(
    'PARITY_TEST_NOTE web/.env.parity-test is no longer used (credentials now live in ' +
      `${stateDir}); delete it so it cannot be committed.`,
  );

let exitCode = 0;
let keep = command.length === 0 || process.env.PARITY_TEST_KEEP === '1';
try {
  // A fresh volume every run: no schema, rows or roles from an earlier run can leak into this one.
  teardown();
  mkdirSync(stateDir, { recursive: true, mode: 0o700 });
  const secrets = {
    PARITY_OWNER_PASSWORD: randomBytes(24).toString('hex'),
    PARITY_APP_PASSWORD: randomBytes(24).toString('hex'),
  };
  const urls = {
    DATABASE_URL: `postgresql://app_user:${secrets.PARITY_APP_PASSWORD}@127.0.0.1:${port}/${database}?schema=public`,
    MIGRATE_DATABASE_URL: `postgresql://datacare:${secrets.PARITY_OWNER_PASSWORD}@127.0.0.1:${port}/${database}?schema=public`,
  };
  writeFileSync(
    secretsFile,
    Object.entries({ ...secrets, PARITY_TEST_PORT: port, ...urls })
      .map(([key, value]) => `${key}=${value}\n`)
      .join(''),
    { mode: 0o600 },
  );
  const env = {
    ...process.env,
    ...secrets,
    ...urls,
    PARITY_TEST_PROJECT: project,
    PARITY_TEST_PORT: port,
    PARITY_TEST_DATABASE: database,
    PARITY_TEST_ENV_FILE: secretsFile,
    RUN_DB_INTEGRITY_TESTS: '1',
    RUN_DB_SECURITY_TESTS: '1',
    TZ: 'UTC',
  };
  delete env.ALLOW_SKIP_DB_TESTS;

  run('docker', [...withSecrets(), 'up', '-d', '--wait', '--wait-timeout', '60'], { env });
  // Prisma must use the migration owner, not the app role, for schema deployment.
  run(
    'pnpm',
    [
      '--filter',
      '@datacare/db',
      'exec',
      'prisma',
      'migrate',
      'deploy',
      '--schema',
      'prisma/schema.prisma',
    ],
    { env: { ...env, DATABASE_URL: env.MIGRATE_DATABASE_URL } },
  );
  run('docker', [...withSecrets(), ...psql], {
    env,
    input: readFileSync(resolve(root, 'packages/db/prisma/rls.sql'), 'utf8'),
  });
  run('docker', [...withSecrets(), ...psql, '-v', `app_password=${secrets.PARITY_APP_PASSWORD}`], {
    env,
    input: readFileSync(resolve(root, 'packages/db/setup_roles.sql'), 'utf8'),
  });
  const verified = run(
    'docker',
    [
      ...withSecrets(),
      ...psql,
      '-At',
      '-c',
      `SELECT current_database()='${database}' AND EXISTS (SELECT 1 FROM pg_roles WHERE rolname='app_user'
     AND NOT rolsuper AND NOT rolbypassrls AND NOT rolcreatedb AND NOT rolcreaterole)
     AND NOT EXISTS (SELECT 1 FROM pg_class c JOIN pg_namespace n ON n.oid=c.relnamespace
     WHERE n.nspname='public' AND c.relkind='r' AND EXISTS
     (SELECT 1 FROM pg_attribute a WHERE a.attrelid=c.oid AND a.attname='tenant_id')
     AND (NOT c.relrowsecurity OR NOT c.relforcerowsecurity));`,
    ],
    { env, stdio: ['ignore', 'pipe', 'inherit'] },
  );
  if (verified.trim() !== 't')
    throw new StepFailed('PARITY_TEST_TARGET_INVALID: runtime role or forced RLS missing');
  const before = identity(env);
  if (!before.containerId || !/^\d+$/.test(before.systemIdentifier))
    throw new StepFailed(
      'PARITY_TEST_TARGET_INVALID: could not read the container and system identifier',
    );
  console.log(
    `PARITY_TEST_READY 127.0.0.1:${port}/${database} / project ${project} / container ` +
      `${before.containerId.slice(0, 12)} / system ${before.systemIdentifier} / migrations / ` +
      'non-owner role / forced RLS',
  );

  if (command.length === 0) {
    console.log(
      `PARITY_TEST_LEFT_RUNNING credentials and URLs in ${secretsFile}; ` +
        'tear down with: node scripts/parity-test-env.mjs --down',
    );
  } else {
    const [cmd, ...args] = command;
    exitCode = await runChild(cmd, args, {
      ...env,
      PARITY_TEST_CONTAINER_ID: before.containerId,
      PARITY_TEST_SYSTEM_IDENTIFIER: before.systemIdentifier,
    });
    const changes = parityTestIdentityChanges(before, identity(env, true));
    if (changes.length) {
      console.error(`PARITY_TEST_IDENTITY_CHANGED ${changes.join('; ')}`);
      exitCode = exitCode || 1;
    }
  }
} catch (error) {
  console.error(error instanceof StepFailed ? error.message : error);
  exitCode = error instanceof StepFailed ? error.code : 1;
  keep = process.env.PARITY_TEST_KEEP === '1';
} finally {
  if (keep && command.length > 0) console.log(`PARITY_TEST_KEPT ${project} (PARITY_TEST_KEEP=1)`);
  if (!keep) teardown();
}
process.exit(exitCode);
