import { readFileSync, readdirSync, statSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join, relative, resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import { round, roundHalfEven } from '@datacare/core';
import {
  auditKernelConformance,
  findBypasses,
  KERNEL_CONCERNS,
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
 * Adoption ceilings re-baselined on 2026-09-11 after the expanded parity implementation pass. These may fall and may never rise.
 * 2026-09-29 (N18): rounding 128 -> 126 — the legacy Tag Transfer writer in stock/stock.ts took two module-local rounding
 * helpers with it; its replacement (stock/tagCancel*.ts) rounds only through @datacare/core.
 * 2026-10-01 (N33): rounding 126 -> 125 — the legacy createOtherPurchase/deleteOtherPurchase writer in purchase/purchase.ts
 * was removed; Other Expenses now posts through the shared TR_OTH_PURC writer in purchase/otherIncome.ts.
 *
 * `rounding` counts function-valued bindings (arrow or block-bodied) that round; `book-account` counts inline `BOOK_DETL` reads
 * outside the two shared resolvers.
 */
const CEILINGS = { rounding: 125, 'book-account': 5 } as const;

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
});

describe('kernel adoption in this repository', () => {
  const report = auditKernelConformance(files, CEILINGS);

  it('holds the measured bypass counts so adoption cannot regress', () => {
    expect(report.totals).toEqual({ rounding: 125, 'book-account': 5 });
    expect(report.regressions).toEqual([]);
    expect(report.verdict).toBe('ok');
  });

  it('locates the book-account bypasses precisely, since there are few enough to fix', () => {
    const paths = [
      ...new Set(report.bypasses.filter((b) => b.concern === 'book-account').map((b) => b.path)),
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

  it('shows the rounding bypasses are spread wide, which is why bulk migration is the wrong move', () => {
    const rounding = report.bypasses.filter((b) => b.concern === 'rounding');
    const files = new Set(rounding.map((b) => b.path));
    expect(files.size).toBe(81);
    // Every one needs its desktop mechanism identified before it can be migrated, and that lives in a
    // contract, not in this test.
    expect(rounding.length).toBeGreaterThan(files.size);
  });

  it('fails when adoption goes backwards', () => {
    const tighter = auditKernelConformance(files, { rounding: 10, 'book-account': 0 });
    expect(tighter.verdict).toBe('red');
    expect(tighter.regressions).toHaveLength(2);
    expect(tighter.regressions[0]).toContain('use the kernel primitive instead');
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
