#!/usr/bin/env node
/**
 * Kernel conformance by site identity (N48, gap G22).
 *
 * The kernel exists — exact-decimal `round`/`roundHalfEven` in `@datacare/core`, the flag-driven
 * `roundingPolicy`, and two fail-closed `BOOK_DETL` resolvers. This gate measures ADOPTION and refuses to let
 * it slip. It no longer counts bypasses: it compares the live set of bypass SITES, by identity, against a
 * checked-in baseline (`parity/kernel-conformance-baseline.json`). A site not in the baseline fails — an
 * addition can no longer hide behind an unrelated removal, which a total-count ratchet allowed. A baseline
 * site that no longer exists also fails, so a burn-down deletes its ID in the same change.
 *
 * The detector lives in `apps/api/src/modules/ops/kernelConformance.ts` and is unit tested there and in
 * `apps/api/test/kernelConformance.test.ts`, which loads the SAME baseline, so the script and the test can
 * never disagree about scope, rules or the grandfathered set.
 *
 *   node scripts/check-kernel-conformance.mjs           # audit; exit 1 if a site was added or removed
 *   node scripts/check-kernel-conformance.mjs --list    # list every live site ID
 */
import { readFileSync, readdirSync, statSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join, relative, resolve } from 'node:path';

const here = dirname(fileURLToPath(import.meta.url));
const webRoot = resolve(here, '..');
const apiSrc = resolve(webRoot, 'apps/api/src');
const coreSrc = resolve(webRoot, 'packages/core/src');
const baselinePath = resolve(webRoot, 'parity/kernel-conformance-baseline.json');

const { compareToBaseline } = await import(
  resolve(webRoot, 'apps/api/dist/modules/ops/kernelConformance.js')
).catch((error) => {
  console.error(
    'KERNEL_CONFORMANCE_UNAVAILABLE: build the API package first (pnpm --filter @datacare/api build).\n' +
      String(error?.message ?? error),
  );
  process.exit(1);
});

/**
 * Collect `.ts` sources under a root. `apps/api/src` keeps its paths relative to itself; `packages/core/src`
 * is prefixed with `packages/core/` so a file moving between the two roots keeps the same identity (the
 * reason the mirror test widened scope to core, and the reason both scan the same two roots here).
 */
function sourceFiles(dir, base, prefix = '') {
  const out = [];
  for (const entry of readdirSync(dir)) {
    const full = join(dir, entry);
    if (statSync(full).isDirectory()) out.push(...sourceFiles(full, base, prefix));
    else if (entry.endsWith('.ts')) {
      out.push({ path: prefix + relative(base, full), text: readFileSync(full, 'utf8') });
    }
  }
  return out;
}

const files = [...sourceFiles(apiSrc, apiSrc), ...sourceFiles(coreSrc, coreSrc, 'packages/core/')];

const baseline = JSON.parse(readFileSync(baselinePath, 'utf8'));
const result = compareToBaseline(files, baseline);

const rounding = result.liveSites.filter((s) => s.startsWith('rounding:')).length;
const bookAccount = result.liveSites.filter((s) => s.startsWith('book-account:')).length;

console.log(
  `kernel conformance across ${files.length} source files (apps/api/src + packages/core/src)\n` +
    `  ${result.liveSites.length} live bypass site(s): ${rounding} rounding, ${bookAccount} book-account\n` +
    `  ${baseline.sites.length} site(s) in the baseline`,
);

if (process.argv.includes('--list')) {
  console.log('\n  live site IDs:');
  for (const id of result.liveSites) console.log(`    ${id}`);
}

if (result.verdict !== 'ok') {
  console.log('\nKERNEL_CONFORMANCE_RED the live site set does not match the baseline:');
  for (const problem of result.problems) console.log(`    ${problem}`);
  process.exit(1);
}

console.log(
  '\nKERNEL_CONFORMANCE_OK every live bypass is a grandfathered site in the baseline; no site was added or removed.',
);
