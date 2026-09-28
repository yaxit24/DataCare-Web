#!/usr/bin/env node
/**
 * Contract integrity gate (P1-07 / WP-05).
 *
 * Audits every `project-memory/contracts/<FORM>.contract.md` against three sets of facts it cannot fake:
 * the desktop sources in `unified/src/csharp/DataCareNext` (does the cited line exist?), the golden vectors in
 * `apps/api/test/goldenVectors.test.ts` (does the cited vector exist?), and the contract's own declared
 * status (is it claiming approval while carrying open cells?).
 *
 * Decisions live in `apps/api/src/modules/ops/contractIntegrity.ts` and are unit tested there. This runner
 * only gathers the facts, exactly as the release certifier does, so the rules can be tested without the
 * workspace.
 *
 *   node scripts/check-contracts.mjs            # audit; exit 1 on a blocking finding
 *   node scripts/check-contracts.mjs --debt     # additionally list every draft debt line
 */
import { readFileSync, readdirSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, resolve } from 'node:path';

const here = dirname(fileURLToPath(import.meta.url));
const webRoot = resolve(here, '..');
const repoRoot = resolve(webRoot, '..');
const contractsDir = resolve(repoRoot, 'project-memory/contracts');
const desktopDir = resolve(repoRoot, 'unified/src/csharp/DataCareNext');
const vectorsFile = resolve(webRoot, 'apps/api/test/goldenVectors.test.ts');

const { auditContracts, vectorCandidates } = await import(
  resolve(webRoot, 'apps/api/dist/modules/ops/contractIntegrity.js')
).catch((error) => {
  console.error(
    'CONTRACTS_UNAVAILABLE: build the API package first (pnpm --filter @datacare/api build).\n' +
      String(error?.message ?? error),
  );
  process.exit(1);
});

/**
 * Debt ceilings, measured on 2026-08-30.
 *
 * `notEnforced` fell from 30 to 28 when two stale rows were corrected: the message they called NOT ENFORCED is
 * thrown by current code. `blankTest` is 0, not the 37 previously reported — every one of those rows is WAIVED
 * or UI-LEVEL and carries a reason, which is the contracts' own accepted discipline; the old figure came from a
 * parser that could not tell the two table shapes apart.
 *
 * These are not targets. They are the high-water mark that may never rise.
 */
const DEBT_CEILING = { notEnforced: 28, blankVector: 184, blankTest: 0 };

const files = readdirSync(contractsDir)
  .filter((name) => name.endsWith('.contract.md'))
  .sort()
  .map((name) => ({ name, text: readFileSync(resolve(contractsDir, name), 'utf8') }));

const desktopLineCounts = {};
for (const name of readdirSync(desktopDir).filter((n) => n.endsWith('.cs'))) {
  const text = readFileSync(resolve(desktopDir, name), 'utf8');
  desktopLineCounts[name.replace(/\.cs$/, '')] = text.split('\n').length;
}

const definedVectorIds = new Set(
  [...readFileSync(vectorsFile, 'utf8').matchAll(/GV-[A-Z0-9]+-\d+/g)].map((m) => m[0]),
);

const report = auditContracts(files, {
  desktopLineCounts,
  definedVectorIds,
  debtCeiling: DEBT_CEILING,
});

const width = Math.max(...report.contracts.map((c) => c.name.length));
console.log(
  `contracts: ${report.totals.contracts} (${report.totals.approved} approved, ${report.totals.draft} draft)` +
    ` | desktop sources: ${Object.keys(desktopLineCounts).length} | golden vectors: ${definedVectorIds.size}\n`,
);
for (const c of report.contracts) {
  console.log(
    `  ${c.name.padEnd(width)}  ${c.status.padEnd(8)}` +
      ` rules=${String(c.validations + c.authoredRules).padStart(3)}` +
      ` notEnforced=${String(c.notEnforced).padStart(2)}` +
      ` computed=${String(c.computed).padStart(3)}` +
      ` blankVector=${String(c.blankVector).padStart(3)}` +
      ` citations=${String(c.citations).padStart(3)}`,
  );
}
console.log(
  `\n  totals: rules=${report.totals.validations} authored+generated, notEnforced=${report.totals.notEnforced},` +
    ` computed=${report.totals.computed}, blankVector=${report.totals.blankVector},` +
    ` blankTest=${report.totals.blankTest}, citations=${report.totals.citations}`,
);

const blocking = report.findings.filter((f) => f.severity === 'blocking');
const debt = report.findings.filter((f) => f.severity === 'debt');

if (process.argv.includes('--debt') && debt.length) {
  console.log('\n  open contract debt (WP-05 authoring work, not a gate failure):');
  for (const f of debt) console.log(`    ${f.contract}: ${f.detail}`);
}

if (process.argv.includes('--candidates')) {
  const candidates = vectorCandidates(files);
  const byContract = new Map();
  for (const c of candidates) {
    byContract.set(c.contract, [...(byContract.get(c.contract) ?? []), c]);
  }
  console.log(
    `\n  vector-link candidates: ${candidates.length} of ${report.totals.blankVector} blank cells have a` +
      ` cell in an APPROVED contract with the same control AND persisted column.\n` +
      `  These are NOT applied. A filled Vector cell asserts a golden vector pins that formula, and the\n` +
      `  retained audits record cell identity but not the desktop expression — so each must be confirmed\n` +
      `  against unified/src/csharp/DataCareNext/<FORM>.cs before it is written down.`,
  );
  for (const [contract, list] of [...byContract].sort()) {
    console.log(`\n    ${contract}  (${list.length})`);
    for (const c of list) {
      console.log(
        `      ${c.control.padEnd(14)} ${c.column.padEnd(16)} -> ${c.vector.padEnd(16)} (per ${c.precedent})`,
      );
    }
  }
}

if (blocking.length) {
  console.log(`\nCONTRACTS_RED ${blocking.length} blocking finding(s)`);
  for (const f of blocking) console.log(`    [${f.rule}] ${f.contract}: ${f.detail}`);
  process.exit(1);
}
console.log(
  `\nCONTRACTS_OK every citation resolves, every cited vector exists, and no contract claims approval` +
    ` while carrying open cells (${debt.length} draft debt line(s) recorded${
      process.argv.includes('--debt') ? '' : '; pass --debt to list them'
    })`,
);
