import { readdir, readFile } from 'node:fs/promises';
import { extname, join, relative } from 'node:path';
import process from 'node:process';
import ts from 'typescript';
import { findPlausibleSecretLiterals } from './secret-scanner.mjs';

const root = process.cwd();
const sourceRoots = ['apps', 'packages', 'scripts'];
const ignoredDirectories = new Set(['.git', '.next', '.turbo', 'coverage', 'dist', 'node_modules']);
// Reproducible, git-ignored generator output (Prisma 7 `prisma-client`): not authored source, so it is not
// linted. Its model field names (e.g. LOGIN_PWD) are desktop column identifiers, not secret literals.
const ignoredRelativeDirectories = new Set(['packages/db/src/generated']);
const sourceExtensions = new Set(['.ts', '.tsx', '.js', '.mjs']);
const errors = [];
let sourceCount = 0;
let manifestCount = 0;

async function walk(directory, visit) {
  for (const entry of await readdir(directory, { withFileTypes: true })) {
    if (ignoredDirectories.has(entry.name)) continue;
    const path = join(directory, entry.name);
    if (entry.isDirectory()) {
      if (ignoredRelativeDirectories.has(relative(root, path))) continue;
      await walk(path, visit);
    } else await visit(path);
  }
}

function report(path, message) {
  errors.push(`${relative(root, path)}: ${message}`);
}

async function lintSource(path) {
  const extension = extname(path);
  if (!sourceExtensions.has(extension)) return;
  sourceCount += 1;
  const text = await readFile(path, 'utf8');
  const kind =
    extension === '.tsx'
      ? ts.ScriptKind.TSX
      : extension === '.ts'
        ? ts.ScriptKind.TS
        : ts.ScriptKind.JS;
  const source = ts.createSourceFile(path, text, ts.ScriptTarget.Latest, true, kind);

  for (const diagnostic of source.parseDiagnostics) {
    const position =
      diagnostic.start === undefined
        ? ''
        : `:${source.getLineAndCharacterOfPosition(diagnostic.start).line + 1}`;
    report(
      path,
      `syntax${position}: ${ts.flattenDiagnosticMessageText(diagnostic.messageText, '\n')}`,
    );
  }
  if (text.split('\n').some((line) => /^\s*(?:\/\/|\/\*)\s*@ts-ignore\b/.test(line))) {
    report(path, '@ts-ignore is prohibited; use a typed boundary with an explanation');
  }

  const projectPath = relative(root, path);
  const testFixture =
    projectPath.includes('/test/') ||
    projectPath.includes('/integration/') ||
    /(?:^|\/)test[^/]*\.[cm]?[jt]sx?$/.test(projectPath) ||
    /\.test\.[cm]?[jt]sx?$/.test(projectPath);
  if (!testFixture) {
    for (const finding of findPlausibleSecretLiterals(text, projectPath)) {
      report(path, `${finding.message} at line ${finding.line}`);
    }
  }
  if (
    projectPath.startsWith('apps/web/app/(app)/') &&
    projectPath.endsWith('.tsx') &&
    projectPath !== 'apps/web/app/(app)/layout.tsx'
  ) {
    if (/['"]\/me['"]/.test(text)) {
      report(path, 'protected pages must consume useBusinessScope() instead of fetching /me');
    }
    const intentionalTargetState = new Set([
      'apps/web/app/(app)/admin/provision/page.tsx',
      'apps/web/app/(app)/masters/year-create/page.tsx',
    ]);
    if (
      !intentionalTargetState.has(projectPath) &&
      /const\s+\[(?:coCode|lcCode|coYear),\s*set(?:CoCode|LcCode|CoYear)\]\s*=\s*useState/.test(
        text,
      )
    ) {
      report(path, 'current company/location/year state must come from useBusinessScope()');
    }
    if (
      /const\s+\[coBook(?:,\s*setCoBook)?\]\s*=\s*useState\(\s*['"][^'"]+['"]\s*\)/.test(text) ||
      /coBook\s*:\s*['"][A-Za-z0-9]+['"]/.test(text)
    ) {
      report(path, 'book codes must come from active BOOK_DATA via BookSelect');
    }
  }

  if (
    projectPath.startsWith('apps/api/src/') &&
    !path.endsWith(join('modules', 'reports', 'render.ts')) &&
    text.includes('FakePdfRenderer')
  ) {
    report(path, 'FakePdfRenderer is test-only and cannot be used by production routes');
  }

  function inspect(node) {
    if (
      ts.isCallExpression(node) &&
      ts.isIdentifier(node.expression) &&
      node.expression.text === 'eval'
    )
      report(
        path,
        `dynamic eval() is prohibited at line ${source.getLineAndCharacterOfPosition(node.pos).line + 1}`,
      );
    if (
      ts.isNewExpression(node) &&
      ts.isIdentifier(node.expression) &&
      node.expression.text === 'Function'
    )
      report(
        path,
        `new Function() is prohibited at line ${source.getLineAndCharacterOfPosition(node.pos).line + 1}`,
      );
    ts.forEachChild(node, inspect);
  }
  inspect(source);
}

function dependencyBlocks(manifest) {
  return ['dependencies', 'devDependencies', 'optionalDependencies', 'peerDependencies'].flatMap(
    (name) =>
      Object.entries(manifest[name] ?? {}).map(([dependency, specifier]) => ({
        name,
        dependency,
        specifier,
      })),
  );
}

async function lintManifest(path) {
  manifestCount += 1;
  const manifest = JSON.parse(await readFile(path, 'utf8'));
  for (const { name, dependency, specifier } of dependencyBlocks(manifest)) {
    if (typeof specifier !== 'string' || specifier.startsWith('workspace:')) continue;
    if (/^(\^|~|>|<|\*|latest$)/.test(specifier)) {
      report(path, `${name}.${dependency} must use an exact version (found ${specifier})`);
    }
  }
  if (path !== join(root, 'package.json') && manifest.scripts?.typecheck === undefined) {
    report(path, 'workspace package must expose a typecheck script');
  }
}

for (const sourceRoot of sourceRoots) {
  const path = join(root, sourceRoot);
  await walk(path, async (file) => {
    if (file.endsWith('package.json')) await lintManifest(file);
    await lintSource(file);
  });
}
await lintManifest(join(root, 'package.json'));

if (errors.length) {
  console.error(`Workspace lint failed with ${errors.length} error(s):`);
  for (const error of errors) console.error(`- ${error}`);
  process.exitCode = 1;
} else {
  console.log(
    `Workspace lint passed: ${sourceCount} source files parsed, ${manifestCount} manifests checked, 0 policy violations.`,
  );
}
