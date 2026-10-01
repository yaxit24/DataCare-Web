import { readFileSync, readdirSync, statSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join, relative, resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import { round, roundHalfEven } from '@datacare/core';
import {
  auditKernelConformance,
  compareToBaseline,
  findBypasses,
  KERNEL_CONCERNS,
  type KernelBaseline,
  type KernelSourceFile,
} from '../src/modules/ops/kernelConformance.js';
import { resolveRoundingPolicy } from '../src/modules/shared/roundingPolicy.js';
import { TAG_STOCK_COLUMNS } from '../src/modules/stock/stock.js';

/**
 * WP-06 — the compatibility kernel exists; this measures whether it is used, and pins why the local copies
 * are not interchangeable with it.
 *
 * The second half is the important half. A reader who finds 105 near-identical `round2` helpers will be
 * tempted to replace them all with one import, and that would silently change posted money: the local helpers,
 * the kernel's half-up and the kernel's half-to-even disagree, and which one is right depends on whether the
 * desktop produced that figure with `Strings.Format` or `Math.Round`. These characterisation tests record the
 * disagreement so the cleanup cannot be done by eye.
 */

const here = dirname(fileURLToPath(import.meta.url));
const srcRoot = resolve(here, '../src');
/**
 * `packages/core/src` is scanned TOO, and that is deliberate.
 *
 * This measure answers "how many places reimplement a kernel primitive". That question does not care
 * which package a file happens to sit in, so MOVING code must not change the answer. It nearly did:
 * relocating `finePolicy.ts` (which carries its own `round3 = Math.round((v + EPSILON) * 1000) / 1000`)
 * from apps/api into core dropped the count 108 -> 107 while eliminating nothing. Lowering the ceiling
 * on that basis would have been gaming the ratchet, so the scope was widened to keep the number honest.
 */
const coreRoot = resolve(here, '../../../packages/core/src');

function sourceFiles(dir: string, base: string = dir): KernelSourceFile[] {
  const out: KernelSourceFile[] = [];
  for (const entry of readdirSync(dir)) {
    const full = join(dir, entry);
    if (statSync(full).isDirectory()) out.push(...sourceFiles(full, base));
    else if (entry.endsWith('.ts')) {
      out.push({ path: relative(base, full), text: readFileSync(full, 'utf8') });
    }
  }
  return out;
}

const files = [
  ...sourceFiles(srcRoot),
  ...sourceFiles(coreRoot).map((f) => ({ ...f, path: `packages/core/${f.path}` })),
];

/**
 * N48 replaced the total-count ratchet with a checked-in baseline of site IDENTITIES
 * (`parity/kernel-conformance-baseline.json`). The script and this test load the SAME file and run the SAME
 * `compareToBaseline`, so they can never disagree about scope, rules or the grandfathered set — the exact
 * drift (script ceiling 108 over `apps/api/src` only, test ceiling 125 over api+core) that G22 flagged.
 */
const baseline = JSON.parse(
  readFileSync(resolve(here, '../../..', 'parity/kernel-conformance-baseline.json'), 'utf8'),
) as KernelBaseline;

/** The shape every module-local helper takes, reproduced here so the comparison is against the real thing. */
const localEpsilon = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const localNano = (n: number): number => Math.round((n + 1e-9) * 100) / 100;

describe('the three rounding implementations are not interchangeable', () => {
  it('breaks negative midpoints the wrong way in every module-local helper', () => {
    // JavaScript rounds a negative tie toward +Infinity; .NET half-up rounds away from zero. The desktop's
    // 20,575 `Strings.Format` sites are half-up, so this is a real divergence on any negative amount —
    // kasar, round-off, credit notes, signed metal legs, or a CR − DR difference.
    expect(localEpsilon(-1.005)).toBe(-1);
    expect(localNano(-1.005)).toBe(-1);
    expect(round(-1.005, 2)).toBe(-1.01);

    expect(localEpsilon(-0.125)).toBe(-0.12);
    expect(round(-0.125, 2)).toBe(-0.13);

    // At zero decimal places the same defect is a whole rupee.
    expect(Math.round(-0.5)).toBe(-0);
    expect(round(-0.5, 0)).toBe(-1);
  });

  it('differs from half-to-even on positive midpoints, which is the other half of the risk', () => {
    // Whichever epsilon a module happened to use, it implements HALF-UP. The desktop's 10,306 `Math.Round`
    // sites are half-to-even, so a formula from one of those sites is wrong here at every midpoint.
    for (const value of [1.005, 2.005, 0.125]) {
      expect(localEpsilon(value)).toBe(round(value, 2));
    }
    expect(round(1.005, 2)).toBe(1.01);
    expect(roundHalfEven(1.005, 2)).toBe(1);
    expect(round(0.125, 2)).toBe(0.13);
    expect(roundHalfEven(0.125, 2)).toBe(0.12);
  });

  it('is not fixed by the flag-driven policy, which implements BOTH desktop mechanisms correctly', () => {
    // `roundingPolicy.roundNearest` multiplies by `Math.sign`, so it rounds away from zero on both branches —
    // and it selects the branch by whether the company CONFIGURED the flag: a configured decimal count rounds
    // ties to even (the `Math.Round` default), an absent one rounds half-up (the format-string behaviour).
    // Measured, not assumed:
    const configured = resolveRoundingPolicy({ TOT_AMT_ROF: '2' });
    const defaulted = resolveRoundingPolicy({});

    expect(configured.roundBillTotal(-1.005)).toBe(-1); // ties to even
    expect(defaulted.roundBillTotal(-1.005)).toBe(-1.01); // half-up, away from zero
    expect(configured.roundBillTotal(0.125)).toBe(0.12);
    expect(defaulted.roundBillTotal(0.125)).toBe(0.13);

    // The module-local helper agrees with NEITHER branch on this value, which is the whole point: it is a
    // third behaviour, and the only one that is wrong about the sign.
    expect(localEpsilon(-1.005)).toBe(-1);
    expect(round(-1.005, 2)).toBe(-1.01);
  });

  it('agrees everywhere away from a midpoint, which is why the divergence stayed invisible', () => {
    for (const value of [1.004, 1.006, 12.341, 99.999, -3.217, 0.001]) {
      expect(localEpsilon(value), `${value}`).toBe(round(value, 2));
      expect(localNano(value), `${value}`).toBe(round(value, 2));
    }
  });
});

/**
 * Signed-midpoint vectors for the N48 migration (G22). Each migrated helper now calls a kernel primitive;
 * these pin the midpoint behaviour at both signs so the migration can never silently drift back to the float
 * helper, which rounds negative midpoints toward +Infinity. Expected values are derived from the desktop
 * mechanism cited for each site, not from the web output.
 *
 *   round(x, dp)        — desktop Strings.Format("0.00"/"0.000"): half-up, away from zero.
 *   roundHalfEven(x, dp) — desktop Math.Round(x, dp): half to even.
 */
describe('N48 migrated helpers: signed midpoint vectors', () => {
  it('reports, einvoiceExport, scheme, stockInout, tagSplit use half-up round at ±x.5 and ±x.005', () => {
    // 2dp amounts (report round2, einvoiceExport round2, stockInout r2, tagSplit f2, otherIncome money).
    expect(round(1.005, 2)).toBe(1.01);
    expect(round(-1.005, 2)).toBe(-1.01); // float helper would give -1.00 (wrong sign of the tie)
    expect(round(2.675, 2)).toBe(2.68);
    expect(round(-2.675, 2)).toBe(-2.68);
    // 3dp weights (report round3, einvoiceExport round3, scheme round3, tagSplit f3).
    expect(round(1.0005, 3)).toBe(1.001);
    expect(round(-1.0005, 3)).toBe(-1.001);
    // 0dp counts (tagSplit f0).
    expect(round(0.5, 0)).toBe(1);
    expect(round(-0.5, 0)).toBe(-1);
    expect(round(2.5, 0)).toBe(3);
    expect(round(-2.5, 0)).toBe(-3);
  });

  it('otherIncome integerMoney and the reverse-charge back-calc use half-to-even (desktop Math.Round)', () => {
    // integerMoney = roundHalfEven(x, 0): desktop Math.Round(x, 0) for discount (:2872) and TDS (:5001).
    expect(roundHalfEven(0.5, 0)).toBe(0); // ties to the even neighbour, 0
    expect(roundHalfEven(1.5, 0)).toBe(2);
    expect(roundHalfEven(2.5, 0)).toBe(2);
    expect(roundHalfEven(-0.5, 0)).toBe(-0);
    expect(roundHalfEven(-1.5, 0)).toBe(-2);
    expect(roundHalfEven(-2.5, 0)).toBe(-2);
    // reverse-charge taxable back-calc = roundHalfEven(x, 2): desktop Math.Round(x, 2) (:2876).
    expect(roundHalfEven(1.005, 2)).toBe(1); // not 1.01 — the whole point of the distinction
    expect(roundHalfEven(1.015, 2)).toBe(1.02);
    expect(roundHalfEven(-1.005, 2)).toBe(-1);
  });

  it('the old float helper disagreed on both signs, which is why the migration matters', () => {
    // Negative 2dp midpoint: float helper rounds toward +Infinity (wrong); kernel rounds away from zero.
    expect(localEpsilon(-1.005)).toBe(-1); // old otherIncome/report behaviour
    expect(round(-1.005, 2)).toBe(-1.01); // new behaviour
    // 0dp: old integerMoney (Math.round) broke the negative tie toward +Infinity; half-to-even does not.
    expect(Math.round(-2.5)).toBe(-2); // happens to agree here
    expect(Math.round(-0.5)).toBe(-0);
    expect(roundHalfEven(-0.5, 0)).toBe(-0);
    expect(roundHalfEven(-1.5, 0)).toBe(-2); // old Math.round(-1.5) = -1 (wrong)
    expect(Math.round(-1.5)).toBe(-1);
  });
});

describe('kernel bypass detection', () => {
  it('counts a private helper and ignores an incidental use', () => {
    const detected = findBypasses([
      {
        path: 'modules/x/a.ts',
        text: 'const round2 = (n: number): number => Math.round(n * 100) / 100;',
      },
      { path: 'modules/x/b.ts', text: 'const total = Math.round(subtotal * 100) / 100;' },
      {
        path: 'modules/x/c.ts',
        text: 'const money = (value: unknown): number =>\n  Math.round((n(value) + 1e-9) * 100) / 100;',
      },
      { path: 'modules/x/d.ts', text: 'function fine(n: number) {\n  return Math.round(n);\n}' },
    ]);
    const rounding = detected.filter((b) => b.concern === 'rounding').map((b) => b.path);
    expect(rounding).toContain('modules/x/a.ts');
    expect(rounding).toContain('modules/x/c.ts');
    expect(rounding).toContain('modules/x/d.ts');
    expect(rounding, 'an incidental Math.round is a use, not a reimplementation').not.toContain(
      'modules/x/b.ts',
    );
  });

  it('exempts the files that ARE the kernel', () => {
    const text = 'const q = `SELECT "AC_CODE" FROM "BOOK_DETL" WHERE 1=1`;';
    expect(findBypasses([{ path: 'modules/shared/bookPolicy.ts', text }])).toEqual([]);
    expect(findBypasses([{ path: 'modules/shared/postingAccounts.ts', text }])).toEqual([]);
    expect(findBypasses([{ path: 'modules/repair/x.ts', text }])).toHaveLength(1);
  });

  it('names the kernel primitive and the correctness reason for every concern', () => {
    for (const concern of KERNEL_CONCERNS) {
      expect(concern.kernel.length).toBeGreaterThan(20);
      expect(concern.why.length).toBeGreaterThan(40);
    }
  });

  it('gives each site a line-independent identity, with an ordinal for repeats in one file', () => {
    // Two `r2` helpers in one file get stable, distinct IDs in declaration order; moving them (changing the
    // line) must not change the identity. The book-account read has no name, so it is fingerprinted by line.
    const detected = findBypasses([
      {
        path: 'modules/x/twins.ts',
        text:
          'const r2 = (n: number): number => Math.round(n * 100) / 100;\n' +
          'const other = 1;\n' +
          'const r2b = (n: number): number => Math.round(n * 100) / 100;\n' +
          'const r2 = (n: number): number => Math.round(n * 1000) / 1000;',
      },
      { path: 'modules/x/book.ts', text: 'const q = `... FROM "BOOK_DETL" WHERE 1=1`;' },
    ]);
    const ids = detected.map((b) => b.siteId);
    expect(ids).toContain('rounding:modules/x/twins.ts#r2');
    expect(ids).toContain('rounding:modules/x/twins.ts#r2~2'); // second `r2`, ordinal 2
    expect(ids).toContain('rounding:modules/x/twins.ts#r2b');
    expect(ids.some((id) => id.startsWith('book-account:modules/x/book.ts#'))).toBe(true);
    // Every site carries a non-empty identity.
    expect(detected.every((b) => b.siteId.length > 0)).toBe(true);
  });

  it('still exposes the legacy count audit for the characterisation tests', () => {
    const report = auditKernelConformance(
      [{ path: 'modules/x/a.ts', text: 'const r2 = (n: number) => Math.round(n * 100) / 100;' }],
      { rounding: 0, 'book-account': 0 },
    );
    expect(report.totals.rounding).toBe(1);
    expect(report.verdict).toBe('red');
  });
});

describe('kernel adoption in this repository', () => {
  const comparison = compareToBaseline(files, baseline);

  it('matches the checked-in baseline exactly — the same file and function the script runs', () => {
    // The gate's whole point after N48: the live set of bypass SITES equals the baseline set. No site was
    // added (an addition can no longer hide behind an unrelated removal) and none was removed without its ID
    // being deleted here.
    expect(
      comparison.added,
      'a new bypass must use the kernel or be reviewed into the baseline',
    ).toEqual([]);
    expect(comparison.removed, 'a burned-down site must be deleted from the baseline').toEqual([]);
    expect(comparison.verdict).toBe('ok');
  });

  it('is burned down to at most 108 rounding sites (the 21 additions removed)', () => {
    const rounding = comparison.liveSites.filter((s) => s.startsWith('rounding:'));
    const bookAccount = comparison.liveSites.filter((s) => s.startsWith('book-account:'));
    expect(rounding.length).toBeLessThanOrEqual(108);
    expect(comparison.liveSites.length).toBe(baseline.sites.length);
    // The five inline BOOK_DETL reads remain until N59 settles the location-fallback decision.
    expect(bookAccount.length).toBe(5);
  });

  it('confirms the 21 migrated additions are gone from the live set', () => {
    const migrated = [
      'rounding:modules/einvoice/einvoiceExport.ts#round2',
      'rounding:modules/einvoice/einvoiceExport.ts#round3',
      'rounding:modules/membership/scheme.ts#round3',
      'rounding:modules/purchase/otherIncome.ts#money',
      'rounding:modules/purchase/otherIncome.ts#integerMoney',
      'rounding:modules/reports/branchInoutReport.ts#round3',
      'rounding:modules/reports/consiReport.ts#round2',
      'rounding:modules/reports/consiReport.ts#round3',
      'rounding:modules/reports/designMoveReport.ts#round3',
      'rounding:modules/reports/graphReport.ts#round2',
      'rounding:modules/reports/graphReport.ts#round3',
      'rounding:modules/reports/manufacturingReports.ts#round2',
      'rounding:modules/reports/manufacturingReports.ts#round3',
      'rounding:modules/reports/oldStockReport.ts#round3',
      'rounding:modules/reports/otherItemReport.ts#round2',
      'rounding:modules/reports/otherItemReport.ts#round3',
      'rounding:modules/reports/tourReports.ts#round3',
      'rounding:modules/reports/tradingReport.ts#round2',
      'rounding:modules/reports/tradingReport.ts#round3',
      'rounding:modules/stock/stockInout.ts#r2',
      'rounding:modules/stock/tagSplitRows.ts#f0',
    ];
    const live = new Set(comparison.liveSites);
    for (const id of migrated) expect(live.has(id), `${id} should be migrated away`).toBe(false);
    // None of them is still grandfathered in the baseline either.
    for (const id of migrated) expect(baseline.sites).not.toContain(id);
  });

  it('locates the book-account bypasses precisely, since there are few enough to fix', () => {
    const paths = [
      ...new Set(
        findBypasses(files)
          .filter((b) => b.concern === 'book-account')
          .map((b) => b.path),
      ),
    ].sort();
    expect(paths).toEqual([
      'modules/repair/repairCustomerIssue.ts',
      'modules/repair/repairKarigarReceipt.ts',
      'modules/repair/repairReceipt.ts',
      'modules/repair/repairWorkflowCommon.ts',
      'modules/sales/rateCut.ts',
    ]);
  });

  it('records that the repair resolver is RICHER than the kernel, so consolidation is not a refactor', () => {
    /**
     * The obvious WP-06 move — delete the two byte-identical private `resolveBookDetlAccountTx` copies and
     * call the shared resolver — would be a regression, and this test exists to stop it.
     *
     * The private copy accepts a `BOOK_DETL` row whose `LC_CODE` is the current location OR `'00'` OR NULL,
     * preferring the current location; the shared `resolveBookSlotAccountTx` requires an exact `LC_CODE`
     * match. Consolidating would make every book configured with a `'00'` row start failing closed.
     *
     * The fix therefore runs the other way: the kernel must absorb the location fallback, which first needs a
     * desktop-evidenced decision that `'00'` rows are valid — contract work, not refactoring. Changing a
     * fail-closed resolver into a more permissive one on the strength of one module's comment is exactly the
     * kind of guess P0-04 removed from the posting paths.
     */
    const repair = readFileSync(resolve(srcRoot, 'modules/repair/repairKarigarReceipt.ts'), 'utf8');
    const kernel = readFileSync(resolve(srcRoot, 'modules/shared/postingAccounts.ts'), 'utf8');
    expect(repair, 'the private resolver falls back across locations').toMatch(
      /"LC_CODE"=\$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL/,
    );
    expect(kernel, 'the kernel requires an exact location match').toMatch(/"LC_CODE"=\$3/);
    expect(kernel).not.toMatch(/LC_CODE" IS NULL/);
  });

  it('fails when a bypass is added or a baseline site is removed', () => {
    // Add one synthetic file with a new helper (an addition), and add one synthetic baseline-only site that
    // does not exist in the tree (a burned-down site whose ID was not deleted): both must be reported.
    const withExtra = [
      ...files,
      {
        path: 'modules/x/synthetic.ts',
        text: 'const round2 = (n: number): number => Math.round(n * 100) / 100;',
      },
    ];
    const ghostId = 'rounding:modules/x/alreadyGone.ts#ghost';
    const staleBaseline: KernelBaseline = {
      ...baseline,
      sites: [...baseline.sites, ghostId],
    };
    const broken = compareToBaseline(withExtra, staleBaseline);
    expect(broken.verdict).toBe('red');
    expect(broken.added).toContain('rounding:modules/x/synthetic.ts#round2');
    expect(broken.removed).toContain(ghostId);
    expect(broken.problems.some((p) => p.includes('NEW bypass not in the baseline'))).toBe(true);
    expect(broken.problems.some((p) => p.includes('delete this ID'))).toBe(true);
  });

  it('never builds a TAG_STOCK restore payload with an undeclared column', () => {
    // A SOURCE-SCANNING version of this check was tried and discarded: restore payloads are not
    // syntactically distinctive, so splitting on object literals produced 57 offenders of which nearly
    // all were unrelated rows (DELETE_DATA audit rows, MAIN_STOCK movements). A guard that cries wolf
    // gets ignored, so this looks only at the two known restore sites and asserts the precise property
    // that broke: insertTagTx THROWS on an undeclared column, so IT_CODE aborted the whole reversal for
    // a tag that lived only in TAG_STOCK — the imported/legacy stock the path exists to restore.
    const declared = new Set<string>(TAG_STOCK_COLUMNS as readonly string[]);
    // Comments must be stripped first. The first version of this guard flagged the very comment that
    // documents the fix, because `// NO IT_CODE: TAG_STOCK has IT_TYPE` matches `NAME:` too — a scanner
    // that reads prose as code reports the explanation as the defect.
    const stripComments = (text: string): string =>
      text.replace(/\/\*[\s\S]*?\*\//g, '').replace(/^\s*\/\/.*$/gm, '');
    const sites = files
      .filter((f) => /restoreTagTx\(/.test(f.text))
      .map((f) => ({ path: f.path, text: stripComments(f.text) }));
    expect(sites.length).toBeGreaterThan(0);
    const offenders: string[] = [];
    for (const file of sites) {
      // The restore object is the one that sets STK_TYPE: 'R'.
      for (const m of file.text.matchAll(/\{[^{}]*STK_TYPE:\s*'R'[^{}]*\}/g)) {
        for (const k of m[0].matchAll(/([A-Z][A-Z0-9_]{2,}):/g)) {
          if (!declared.has(k[1]!)) offenders.push(`${file.path}: ${k[1]}`);
        }
      }
    }
    expect(offenders).toEqual([]);
  });
});
