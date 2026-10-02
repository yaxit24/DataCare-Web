const EXACT_VERSION = /^\d+\.\d+\.\d+(?:-[0-9A-Za-z.-]+)?$/;
const ISO_DATE = /^\d{4}-\d{2}-\d{2}$/;

// The Next.js 16 rehearsal swaps only the framework (React fixed), so it exercises the web build and
// web-facing suites. The Prisma/database tiers are unchanged by a Next version and are proven separately on
// the supported baseline, so they are not part of this rehearsal's required checks.
export const REQUIRED_REHEARSAL_CHECKS = [
  'typecheck',
  'build',
  'web-tests',
  'mocked-browser',
  'route-reachability',
];

function dependency(manifest, name) {
  return manifest.dependencies?.[name] ?? manifest.devDependencies?.[name];
}

function numericVersion(version) {
  if (!EXACT_VERSION.test(version ?? '')) return null;
  return version
    .split('-', 1)[0]
    .split('.')
    .map((part) => Number(part));
}

function atLeast(version, floor) {
  const actual = numericVersion(version);
  const minimum = numericVersion(floor);
  if (!actual || !minimum) return false;
  for (let index = 0; index < 3; index += 1) {
    if (actual[index] !== minimum[index]) return actual[index] > minimum[index];
  }
  return true;
}

function major(version) {
  return numericVersion(version)?.[0];
}

export function inspectSupportedRuntime({
  rootPackage,
  dbPackage,
  apiPackage,
  webPackage,
  workspacePackages,
  schema,
  prismaConfig,
  prismaImports,
  rehearsal,
}) {
  const problems = [];

  if (rootPackage.engines?.node !== '>=24') problems.push('root engines.node must be exactly >=24');

  const prisma = dependency(dbPackage, 'prisma');
  const client = dependency(dbPackage, '@prisma/client');
  const adapter = dependency(dbPackage, '@prisma/adapter-pg');
  for (const [name, version] of [
    ['prisma', prisma],
    ['@prisma/client', client],
    ['@prisma/adapter-pg', adapter],
  ]) {
    if (!EXACT_VERSION.test(version ?? '')) problems.push(`${name} must use an exact version`);
    else if (major(version) !== 7) problems.push(`${name} must use Prisma major 7`);
  }
  if (prisma && client && prisma !== client)
    problems.push('prisma and @prisma/client versions must match');
  if (adapter && client && adapter !== client)
    problems.push('@prisma/adapter-pg and @prisma/client versions must match');
  if (dependency(apiPackage, '@prisma/client'))
    problems.push('@datacare/api must consume the adapter-backed client from @datacare/db');

  for (const { name, manifest } of workspacePackages) {
    const vitest = dependency(manifest, 'vitest');
    if (!vitest) continue;
    if (!EXACT_VERSION.test(vitest)) problems.push(`${name} vitest must use an exact version`);
    else if (!atLeast(vitest, '4.1.11')) problems.push(`${name} vitest must be at least 4.1.11`);
  }

  const generator = schema.match(/generator\s+client\s*\{([\s\S]*?)\}/)?.[1] ?? '';
  if (!/provider\s*=\s*"prisma-client"/.test(generator))
    problems.push('Prisma generator must use prisma-client');
  if (!/output\s*=\s*"[^"]+"/.test(generator))
    problems.push('Prisma generator must declare a custom output');
  const datasource = schema.match(/datasource\s+db\s*\{([\s\S]*?)\}/)?.[1] ?? '';
  if (/^\s*(?:url|directUrl|shadowDatabaseUrl)\s*=/m.test(datasource))
    problems.push('Prisma datasource URLs must live in prisma.config.ts');
  if (!/defineConfig/.test(prismaConfig ?? '') || !/datasource\s*:/.test(prismaConfig ?? ''))
    problems.push('packages/db/prisma.config.ts must configure the CLI datasource');

  for (const path of prismaImports)
    problems.push(`${path} must import Prisma through @datacare/db`);

  if (!rehearsal || typeof rehearsal !== 'object') {
    problems.push('Next.js 16 rehearsal evidence is missing');
  } else {
    if (rehearsal.schemaVersion !== 1)
      problems.push('Next.js 16 rehearsal schemaVersion must be 1');
    if (!ISO_DATE.test(rehearsal.date ?? ''))
      problems.push('Next.js 16 rehearsal date must be YYYY-MM-DD');
    if (!/^[0-9a-f]{7,40}$/.test(rehearsal.basedOn ?? ''))
      problems.push('Next.js 16 rehearsal must identify its base commit');
    const baseline = rehearsal.productionBaseline ?? {};
    for (const name of ['next', 'react', 'react-dom']) {
      if (baseline[name] !== webPackage.dependencies?.[name])
        problems.push(`Next.js 16 rehearsal baseline ${name} must match production`);
    }
    if (major(rehearsal.candidate?.next) !== 16)
      problems.push('Next.js rehearsal candidate must use Next.js 16');
    if (rehearsal.candidate?.react !== baseline.react)
      problems.push('Next.js rehearsal must keep React fixed to isolate the framework change');
    if (rehearsal.candidate?.['react-dom'] !== baseline['react-dom'])
      problems.push('Next.js rehearsal must keep react-dom fixed to isolate the framework change');
    const checks = new Map(
      Array.isArray(rehearsal.checks)
        ? rehearsal.checks.map((check) => [check?.id, check?.status])
        : [],
    );
    // D26 requires the rehearsal to be RUN and RECORDED, not necessarily to pass: production stays on the
    // patched 15.5 line while 15.5 still receives security fixes. Each required check must carry a recorded
    // passed/failed result, the status must be a known value, and any failure must have a disposition.
    const RESULTS = new Set(['passed', 'failed']);
    for (const id of REQUIRED_REHEARSAL_CHECKS) {
      if (!RESULTS.has(checks.get(id)))
        problems.push(`Next.js 16 rehearsal check ${id} must record a passed/failed result`);
    }
    if (!['passed', 'regressions-found'].includes(rehearsal.status))
      problems.push('Next.js 16 rehearsal status must be passed or regressions-found');
    const anyFailed = [...checks.values()].includes('failed');
    if (anyFailed && rehearsal.status !== 'regressions-found')
      problems.push(
        'Next.js 16 rehearsal with a failed check must record status regressions-found',
      );
    if (anyFailed && !(typeof rehearsal.disposition === 'string' && rehearsal.disposition.trim()))
      problems.push('Next.js 16 rehearsal with a failed check must record a disposition');
  }

  return problems;
}
