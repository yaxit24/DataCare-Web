#!/usr/bin/env node
import { existsSync, readFileSync, readdirSync, statSync } from 'node:fs';
import { dirname, relative, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { inspectSupportedRuntime } from './lib/supported-runtime.mjs';

const web = resolve(dirname(fileURLToPath(import.meta.url)), '..');
const readJson = (path) => JSON.parse(readFileSync(path, 'utf8'));
const readText = (path) => (existsSync(path) ? readFileSync(path, 'utf8') : '');

function workspacePackages() {
  const packages = [{ name: 'workspace-root', manifest: readJson(resolve(web, 'package.json')) }];
  for (const group of ['apps', 'packages']) {
    const root = resolve(web, group);
    for (const entry of readdirSync(root)) {
      const path = resolve(root, entry, 'package.json');
      if (existsSync(path)) packages.push({ name: `${group}/${entry}`, manifest: readJson(path) });
    }
  }
  return packages;
}

function directPrismaImports() {
  const paths = [];
  for (const subtree of ['apps/api/src', 'apps/api/test', 'apps/api/integration']) {
    const root = resolve(web, subtree);
    const pending = [root];
    while (pending.length) {
      const current = pending.pop();
      for (const entry of readdirSync(current)) {
        const path = resolve(current, entry);
        if (statSync(path).isDirectory()) pending.push(path);
        else if (
          /\.(?:ts|mjs)$/.test(entry) &&
          readFileSync(path, 'utf8').includes('@prisma/client')
        )
          paths.push(relative(web, path));
      }
    }
  }
  return paths.sort();
}

const evidencePath = resolve(web, 'security/next16-rehearsal.json');
const problems = inspectSupportedRuntime({
  rootPackage: readJson(resolve(web, 'package.json')),
  dbPackage: readJson(resolve(web, 'packages/db/package.json')),
  apiPackage: readJson(resolve(web, 'apps/api/package.json')),
  webPackage: readJson(resolve(web, 'apps/web/package.json')),
  workspacePackages: workspacePackages(),
  schema: readText(resolve(web, 'packages/db/prisma/schema.prisma')),
  prismaConfig: readText(resolve(web, 'packages/db/prisma.config.ts')),
  prismaImports: directPrismaImports(),
  rehearsal: existsSync(evidencePath) ? readJson(evidencePath) : null,
});

if (problems.length) {
  console.error(`SUPPORTED_RUNTIME_RED ${problems.length} problem(s)`);
  for (const problem of problems) console.error(`  - ${problem}`);
  process.exit(1);
}

console.log(
  'SUPPORTED_RUNTIME_OK Node 24 baseline, Prisma 7 adapter, patched Vitest, and Next.js 16 rehearsal',
);
