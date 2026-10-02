import assert from 'node:assert/strict';
import { test } from 'node:test';
import { inspectSupportedRuntime, REQUIRED_REHEARSAL_CHECKS } from './lib/supported-runtime.mjs';

function fixture() {
  const rootPackage = {
    engines: { node: '>=24' },
    devDependencies: { vitest: '4.1.11' },
  };
  const dbPackage = {
    dependencies: {
      '@prisma/adapter-pg': '7.10.0',
      '@prisma/client': '7.10.0',
    },
    devDependencies: { prisma: '7.10.0', vitest: '4.1.11' },
  };
  const apiPackage = { dependencies: {}, devDependencies: { vitest: '4.1.11' } };
  const webPackage = {
    dependencies: { next: '15.5.27', react: '19.0.8', 'react-dom': '19.0.8' },
    devDependencies: { vitest: '4.1.11' },
  };
  return {
    rootPackage,
    dbPackage,
    apiPackage,
    webPackage,
    workspacePackages: [
      { name: 'workspace-root', manifest: rootPackage },
      { name: 'packages/db', manifest: dbPackage },
      { name: 'apps/api', manifest: apiPackage },
      { name: 'apps/web', manifest: webPackage },
    ],
    schema: `generator client {
  provider = "prisma-client"
  output = "../src/generated/prisma"
}
datasource db {
  provider = "postgresql"
}`,
    prismaConfig: `import { defineConfig } from 'prisma/config';
export default defineConfig({ datasource: { url: process.env.DATABASE_URL } });`,
    prismaImports: [],
    rehearsal: {
      schemaVersion: 1,
      date: '2026-10-02',
      basedOn: '16b574e',
      productionBaseline: {
        next: '15.5.27',
        react: '19.0.8',
        'react-dom': '19.0.8',
      },
      candidate: { next: '16.3.8', react: '19.0.8', 'react-dom': '19.0.8' },
      checks: REQUIRED_REHEARSAL_CHECKS.map((id) => ({ id, status: 'passed' })),
      status: 'passed',
    },
  };
}

test('accepts the supported Node, Prisma, Vitest, and rehearsed Next baseline', () => {
  assert.deepEqual(inspectSupportedRuntime(fixture()), []);
});

test('rejects the legacy Prisma/Vitest shape and direct client imports', () => {
  const value = fixture();
  value.rootPackage.engines.node = '>=20';
  value.dbPackage.dependencies['@prisma/client'] = '6.19.3';
  value.dbPackage.dependencies['@prisma/adapter-pg'] = '^7.10.0';
  value.dbPackage.devDependencies.prisma = '7.9.1';
  value.apiPackage.dependencies['@prisma/client'] = '7.10.0';
  value.workspacePackages[0].manifest.devDependencies.vitest = '3.2.7';
  value.schema = `generator client { provider = "prisma-client-js" }
datasource db { provider = "postgresql"\n url = env("DATABASE_URL") }`;
  value.prismaConfig = '';
  value.prismaImports = ['apps/api/src/server.ts'];

  const problems = inspectSupportedRuntime(value);
  for (const expected of [
    'root engines.node must be exactly >=24',
    '@prisma/client must use Prisma major 7',
    '@prisma/adapter-pg must use an exact version',
    'prisma and @prisma/client versions must match',
    '@prisma/adapter-pg and @prisma/client versions must match',
    '@datacare/api must consume the adapter-backed client from @datacare/db',
    'workspace-root vitest must be at least 4.1.11',
    'Prisma generator must use prisma-client',
    'Prisma generator must declare a custom output',
    'Prisma datasource URLs must live in prisma.config.ts',
    'packages/db/prisma.config.ts must configure the CLI datasource',
    'apps/api/src/server.ts must import Prisma through @datacare/db',
  ]) {
    assert.ok(problems.includes(expected), `missing problem: ${expected}`);
  }
});

test('rejects stale, incomplete, or non-isolated Next.js rehearsal evidence', () => {
  const value = fixture();
  value.rehearsal.productionBaseline.next = '15.5.26';
  value.rehearsal.candidate.next = '15.5.27';
  value.rehearsal.candidate.react = '19.3.0';
  // One required check has no recorded result, and the status is not a known value.
  value.rehearsal.checks = value.rehearsal.checks.filter(({ id }) => id !== 'mocked-browser');
  value.rehearsal.status = 'in-progress';

  const problems = inspectSupportedRuntime(value);
  assert.ok(problems.includes('Next.js 16 rehearsal baseline next must match production'));
  assert.ok(problems.includes('Next.js rehearsal candidate must use Next.js 16'));
  assert.ok(
    problems.includes('Next.js rehearsal must keep React fixed to isolate the framework change'),
  );
  assert.ok(
    problems.includes(
      'Next.js 16 rehearsal check mocked-browser must record a passed/failed result',
    ),
  );
  assert.ok(problems.includes('Next.js 16 rehearsal status must be passed or regressions-found'));
});

test('accepts a recorded rehearsal with a failed check when a disposition is given', () => {
  const value = fixture();
  value.rehearsal.checks = value.rehearsal.checks.map((check) =>
    check.id === 'mocked-browser' ? { ...check, status: 'failed' } : check,
  );
  value.rehearsal.status = 'regressions-found';
  value.rehearsal.disposition =
    'Mocked browser smoke times out on /txn/tag-opening under Next 16; production stays on patched 15.5.';
  assert.deepEqual(inspectSupportedRuntime(value), []);
});

test('rejects a failed rehearsal check without status or disposition', () => {
  const value = fixture();
  value.rehearsal.checks = value.rehearsal.checks.map((check) =>
    check.id === 'mocked-browser' ? { ...check, status: 'failed' } : check,
  );
  // status left as 'passed', no disposition
  const problems = inspectSupportedRuntime(value);
  assert.ok(
    problems.includes(
      'Next.js 16 rehearsal with a failed check must record status regressions-found',
    ),
  );
});
