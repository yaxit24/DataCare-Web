#!/usr/bin/env node
/** X03: migrations and non-owner runtime role in an isolated, localhost-only test DB.
 * Usage: node scripts/parity-test-env.mjs -- pnpm --filter @datacare/api test
 * With no command, provisions and verifies the environment only. Never touches app port 5433.
 */
import { randomBytes } from 'node:crypto';
import { spawnSync } from 'node:child_process';
import { existsSync, readFileSync, writeFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';

const root = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const secretsFile = resolve(root, '.env.parity-test');
if (!existsSync(secretsFile)) {
  writeFileSync(
    secretsFile,
    `PARITY_OWNER_PASSWORD=${randomBytes(24).toString('hex')}\nPARITY_APP_PASSWORD=${randomBytes(24).toString('hex')}\n`,
    { mode: 0o600, flag: 'wx' },
  );
}
const secrets = Object.fromEntries(
  readFileSync(secretsFile, 'utf8')
    .trim()
    .split(/\r?\n/)
    .map((line) => line.split('=')),
);
for (const key of ['PARITY_OWNER_PASSWORD', 'PARITY_APP_PASSWORD']) {
  if (!/^[a-f0-9]{48}$/.test(secrets[key] ?? ''))
    throw new Error(`Invalid test credential: ${key}`);
}
const env = {
  ...process.env,
  ...secrets,
  DATABASE_URL: `postgresql://app_user:${secrets.PARITY_APP_PASSWORD}@127.0.0.1:55433/datacare?schema=public`,
  MIGRATE_DATABASE_URL: `postgresql://datacare:${secrets.PARITY_OWNER_PASSWORD}@127.0.0.1:55433/datacare?schema=public`,
  RUN_DB_INTEGRITY_TESTS: '1',
  RUN_DB_SECURITY_TESTS: '1',
  TZ: 'UTC',
};
delete env.ALLOW_SKIP_DB_TESTS;
const compose = [
  'compose',
  '--project-name',
  'datacare-parity-test',
  '--env-file',
  secretsFile,
  '-f',
  resolve(root, 'docker-compose.parity-test.yml'),
];
function run(command, args, options = {}) {
  const result = spawnSync(command, args, {
    cwd: root,
    env,
    encoding: 'utf8',
    stdio: options.input === undefined ? 'inherit' : ['pipe', 'inherit', 'inherit'],
    ...options,
  });
  if (result.error || result.status !== 0) {
    // Never print the argument/environment objects: they may contain setup credentials.
    console.error(`PARITY_TEST_FAILED ${command} exited ${result.status ?? 'before startup'}`);
    process.exit(result.status || 1);
  }
  return result.stdout;
}
run('docker', [...compose, 'up', '-d', '--wait', '--wait-timeout', '60']);
const owner = [
  'exec',
  '-T',
  'postgres',
  'psql',
  '-X',
  '-U',
  'datacare',
  '-d',
  'datacare',
  '-v',
  'ON_ERROR_STOP=1',
];
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
run('docker', [...compose, ...owner], {
  input: readFileSync(resolve(root, 'packages/db/prisma/rls.sql'), 'utf8'),
});
run('docker', [...compose, ...owner, '-v', `app_password=${secrets.PARITY_APP_PASSWORD}`], {
  input: readFileSync(resolve(root, 'packages/db/setup_roles.sql'), 'utf8'),
});
const verified = run(
  'docker',
  [
    ...compose,
    ...owner,
    '-At',
    '-c',
    `SELECT current_database()='datacare' AND EXISTS (SELECT 1 FROM pg_roles WHERE rolname='app_user'
   AND NOT rolsuper AND NOT rolbypassrls AND NOT rolcreatedb AND NOT rolcreaterole)
   AND NOT EXISTS (SELECT 1 FROM pg_class c JOIN pg_namespace n ON n.oid=c.relnamespace
   WHERE n.nspname='public' AND c.relkind='r' AND EXISTS
   (SELECT 1 FROM pg_attribute a WHERE a.attrelid=c.oid AND a.attname='tenant_id')
   AND (NOT c.relrowsecurity OR NOT c.relforcerowsecurity));`,
  ],
  { stdio: ['ignore', 'pipe', 'inherit'] },
);
if (verified.trim() !== 't')
  throw new Error('PARITY_TEST_TARGET_INVALID: runtime role or forced RLS missing');
console.log(
  'PARITY_TEST_READY localhost:55433 / isolated compose project / migrations / non-owner role / forced RLS',
);
const separator = process.argv.indexOf('--');
if (separator >= 0) {
  const [command, ...args] = process.argv.slice(separator + 1);
  if (!command) throw new Error('Expected a command after --');
  run(command, args);
}
