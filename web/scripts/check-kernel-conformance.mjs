#!/usr/bin/env node
/**
 * Compatibility kernel conformance gate (WP-06).
 *
 * WP-06 asks that every posting family use the shared kernel and that no module keep a local fallback. The
 * kernel largely exists — exact-decimal rounding in `@datacare/core`, the flag-driven `roundingPolicy`, and
 * two fail-closed `BOOK_DETL` resolvers — so this measures ADOPTION and refuses to let it slip.
 *
 * Decisions live in `apps/api/src/modules/ops/kernelConformance.ts` and are unit tested there, including a
 * characterisation of why the local rounding helpers are NOT interchangeable with the kernel.
 *
 *   node scripts/check-kernel-conformance.mjs           # audit; exit 1 if adoption regressed
 *   node scripts/check-kernel-conformance.mjs --list    # list every bypass with file:line
 */
import { readFileSync, readdirSync, statSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join, relative, resolve } from 'node:path';

const here = dirname(fileURLToPath(import.meta.url));
const webRoot = resolve(here, '..');
const srcRoot = resolve(webRoot, 'apps/api/src');

const { auditKernelConformance, KERNEL_CONCERNS } = await import(
  resolve(webRoot, 'apps/api/dist/modules/ops/kernelConformance.js')
).catch((error) => {
  console.error(
    'KERNEL_CONFORMANCE_UNAVAILABLE: build the API package first (pnpm --filter @datacare/api build).\n' +
      String(error?.message ?? error),
  );
  process.exit(1);
});

/**
 * Adoption ceilings measured on 2026-08-30. Mirrored in apps/api/test/kernelConformance.test.ts so a drift
 * breaks a test as well as this script. They may fall; they may never rise.
 */
const CEILINGS = { rounding: 108, 'book-account': 5 };

function sourceFiles(dir) {
  const out = [];
  for (const entry of readdirSync(dir)) {
    const full = join(dir, entry);
    if (statSync(full).isDirectory()) out.push(...sourceFiles(full));
    else if (entry.endsWith('.ts')) {
      out.push({ path: relative(srcRoot, full), text: readFileSync(full, 'utf8') });
    }
  }
  return out;
}

const files = sourceFiles(srcRoot);
const report = auditKernelConformance(files, CEILINGS);

console.log(`kernel conformance across ${files.length} source files\n`);
for (const { concern, bypasses, files: fileCount } of report.concerns) {
  const ceiling = CEILINGS[concern.id];
  console.log(`  ${concern.id}`);
  console.log(
    `      ${concern.title}: ${bypasses} bypass(es) in ${fileCount} file(s), ceiling ${ceiling}`,
  );
  console.log(`      use instead: ${concern.kernel}`);
  console.log(`      why it matters: ${concern.why}`);
}

if (process.argv.includes('--list')) {
  for (const { concern } of report.concerns) {
    const mine = report.bypasses.filter((b) => b.concern === concern.id);
    if (!mine.length) continue;
    console.log(`\n  ${concern.id} bypasses:`);
    for (const b of mine) console.log(`    ${b.path}:${b.line}  ${b.snippet}`);
  }
}

if (report.verdict !== 'ok') {
  console.log('\nKERNEL_CONFORMANCE_RED adoption regressed');
  for (const r of report.regressions) console.log(`    ${r}`);
  process.exit(1);
}
console.log(
  `\nKERNEL_CONFORMANCE_OK adoption has not regressed.` +
    ` ${report.totals.rounding} local rounding helpers and ${report.totals['book-account']} inline BOOK_DETL` +
    ` reads remain — each needs its desktop mechanism identified in a contract before it can be migrated,` +
    ` because swapping them changes posted values at midpoints.`,
);
