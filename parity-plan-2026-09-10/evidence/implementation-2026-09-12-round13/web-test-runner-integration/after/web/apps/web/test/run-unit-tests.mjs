import { readdirSync } from 'node:fs';
import { createRequire } from 'node:module';
import { dirname, join } from 'node:path';
import { spawnSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';

const testDirectory = dirname(fileURLToPath(import.meta.url));
const packageDirectory = dirname(testDirectory);
const require = createRequire(import.meta.url);
const vitest = join(dirname(require.resolve('vitest/package.json')), 'vitest.mjs');

function run(args) {
  const result = spawnSync(process.execPath, args, {
    cwd: packageDirectory,
    env: process.env,
    stdio: 'inherit',
  });
  if (result.error) throw result.error;
  if (result.signal || result.status !== 0) process.exit(result.status || 1);
}

function nodeTests(directory) {
  return readdirSync(directory, { withFileTypes: true }).flatMap((entry) => {
    const path = join(directory, entry.name);
    if (entry.isDirectory()) return nodeTests(path);
    return entry.isFile() && entry.name.endsWith('.test.mjs') ? [path] : [];
  });
}

// Node's test runner must own its tests: importing node:test into a Vitest worker
// neither registers a Vitest suite nor makes Vitest await Node's test lifecycle.
// Keep both runners mandatory and propagate either runner's failure.
const nativeTests = nodeTests(testDirectory).sort();
if (nativeTests.length === 0) throw new Error('Expected the web Node test suite.');
run([vitest, 'run', '--exclude', '**/*.test.mjs']);
run(['--test', ...nativeTests]);
