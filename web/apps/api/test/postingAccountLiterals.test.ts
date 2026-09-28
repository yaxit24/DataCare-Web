import { readFileSync, readdirSync, statSync } from 'node:fs';
import { fileURLToPath } from 'node:url';
import { dirname, join, relative, resolve } from 'node:path';
import { describe, expect, it } from 'vitest';

/**
 * P0-04 static rule: a posting account may not come from a string literal.
 *
 * WHY A TEXT RULE RATHER THAN A TYPE
 * ==================================
 * The defect is not a type error. `input.kasarAc ?? 'KASAR'` is perfectly typed; it is simply wrong, because
 * `KASAR` is not an account in any real dataset — it exists only in the provisioning seed, so the mistake is
 * invisible on a demo company and silent on a migrated one. Nothing in the type system can tell a configured
 * account code from a plausible-looking string, so the guard has to be a rule about the SOURCE TEXT.
 *
 * HOW IT IS SCOPED
 * ================
 * Only literals that real code uses as ACCOUNT CODES count. Book codes (`'SAL'`, `'RCT'`), voucher types,
 * currency (`'INR'`) and display labels are also uppercase fallbacks and are none of this rule's business; a
 * scan that banned every uppercase literal produced 139 hits, of which 71 were irrelevant, and a rule that
 * cries wolf gets deleted. The account set below is the six named in the P0-04 gap plus the ones a
 * site-by-site read of the posting paths showed are used the same way.
 *
 * HOW THE REGISTER WORKS
 * ======================
 * P0-04 is not finished. `REMAINING` records, per file, how many account literals are still reachable there,
 * so this rule can be a RATCHET rather than a wish:
 *
 *   * a file absent from the register must contain ZERO — this is what stops the defect coming back into
 *     finance, tender, batch receipt and scheme, which are now clean;
 *   * a registered file may contain AT MOST its recorded count, so the debt can only shrink;
 *   * the total may only decrease.
 *
 * Lowering a number is the visible act of closing part of P0-04. Raising one requires editing this file,
 * which is the point: it cannot happen by accident in a voucher module.
 */

const here = dirname(fileURLToPath(import.meta.url));
const srcRoot = resolve(here, '../src');

/**
 * Literals that reach a ledger account column somewhere in this codebase.
 *
 * `CASH`, `KASAR`, `ROUNDOFF`, `LABOUR`, `STKADJ` and `WTDIFF` are the six the P0-04 gap names. The rest were
 * found by reading the same posting paths: they are account-code fallbacks of exactly the same shape, and
 * leaving them out would have let the defect survive under a different name.
 */
const ACCOUNT_LITERALS = [
  'CASH',
  'KASAR',
  'ROUNDOFF',
  'LABOUR',
  'STKADJ',
  'WTDIFF',
  'BANK',
  'BULLION',
  'INTINC',
  'TDS',
  'PF',
  'GST',
  'GSTINPUT',
  'SALES',
  'PURCHASE',
  'HMCHRG',
  'TCS',
  'OLDGOLD',
  'FINEPURC',
  'FINESALE',
] as const;

/**
 * Account literals still reachable, by file. Measured, not estimated.
 *
 * Sales/purchase/return entries are mostly INERT initialisers that a non-zero amount immediately replaces
 * with a `BOOK_DETL` slot, so they are lower risk than the finance ones that were removed first — but they
 * are still literals in a posting path and still have to go.
 *
 * `stock/tagOps.ts` is additionally unreachable through the API today: WP-01 contains Tag Weight Difference,
 * so those two cannot post at all until that containment is lifted.
 */
const REMAINING: Readonly<Record<string, number>> = {
  'modules/sales/sales.ts': 14,
  'modules/purchase/purchase.ts': 10,
  'modules/dhrn/dhrn.ts': 5,
  'modules/finance/billToBill.ts': 5,
  'modules/purchase/purchaseReturn.ts': 5,
  'modules/sales/salesReturn.ts': 5,
  'modules/manufacturing/karigar.ts': 4,
  'modules/sales/labourInvoice.ts': 4,
  'modules/finance/employeeJv.ts': 3,
  'modules/sales/salesOrder.ts': 3,
  'modules/bullion/bullion.ts': 2,
  'modules/bullion/fineSalePurchase.ts': 2,
  'modules/finance/ledgerAdjust.ts': 2,
  'modules/manufacturing/mfg.ts': 2,
  'modules/stock/tagOps.ts': 2,
};

/** The total at the time P0-04's first slice landed. It may fall; it may not rise. */
const REMAINING_TOTAL = 68;

/**
 * Files this slice cleaned. Listing them explicitly means a regression names itself instead of hiding inside
 * a total that happens to balance because something else improved.
 */
const MUST_STAY_CLEAN = [
  'modules/finance/finance.ts',
  'modules/finance/tender.ts',
  'modules/finance/batchReceipt.ts',
  'modules/membership/scheme.ts',
  'modules/shared/postingAccounts.ts',
];

const FALLBACK = new RegExp(String.raw`(?:\?\?|\|\|)\s*'(${ACCOUNT_LITERALS.join('|')})'`, 'g');

function sourceFiles(dir: string): string[] {
  const out: string[] = [];
  for (const entry of readdirSync(dir)) {
    const full = join(dir, entry);
    if (statSync(full).isDirectory()) out.push(...sourceFiles(full));
    else if (entry.endsWith('.ts')) out.push(full);
  }
  return out;
}

/** Count fallback account literals in a file, ignoring comment lines. */
function countLiterals(file: string): { count: number; lines: string[] } {
  const lines: string[] = [];
  let count = 0;
  const text = readFileSync(file, 'utf8').split('\n');
  text.forEach((line, index) => {
    const trimmed = line.trim();
    if (trimmed.startsWith('//') || trimmed.startsWith('*')) return;
    for (const match of line.matchAll(FALLBACK)) {
      count += 1;
      lines.push(`${index + 1}:${match[1]}`);
    }
  });
  return { count, lines };
}

function scan(): Map<string, { count: number; lines: string[] }> {
  const found = new Map<string, { count: number; lines: string[] }>();
  for (const file of sourceFiles(srcRoot)) {
    const result = countLiterals(file);
    if (result.count > 0) found.set(relative(srcRoot, file), result);
  }
  return found;
}

describe('P0-04 posting account literals', () => {
  it('introduces no account literal in a file that does not already carry recorded debt', () => {
    const found = scan();
    const unexpected = [...found.entries()]
      .filter(([file]) => REMAINING[file] === undefined)
      .map(([file, r]) => `${file} (${r.lines.join(', ')})`);
    expect(
      unexpected,
      'a posting account must come from BOOK_DETL, company/item configuration or the caller — never a literal',
    ).toEqual([]);
  });

  it('never lets a registered file grow, so the debt can only shrink', () => {
    const found = scan();
    const grown: string[] = [];
    for (const [file, allowed] of Object.entries(REMAINING)) {
      const actual = found.get(file)?.count ?? 0;
      if (actual > allowed) grown.push(`${file}: ${actual} > ${allowed} allowed`);
    }
    expect(grown).toEqual([]);
  });

  it('keeps the files this slice cleaned at zero', () => {
    const found = scan();
    const regressed = MUST_STAY_CLEAN.filter((file) => (found.get(file)?.count ?? 0) > 0).map(
      (file) => `${file} (${found.get(file)!.lines.join(', ')})`,
    );
    expect(
      regressed,
      'these paths resolve every posting account from configuration; a literal here is a regression',
    ).toEqual([]);
    // And none of them may quietly leave the register either.
    for (const file of MUST_STAY_CLEAN) expect(REMAINING[file]).toBeUndefined();
  });

  it('holds the overall total at or below the recorded figure', () => {
    const total = [...scan().values()].reduce((sum, r) => sum + r.count, 0);
    expect(total).toBeLessThanOrEqual(REMAINING_TOTAL);
  });

  it('keeps the register honest: every entry must still exist', () => {
    // A register entry for a file that no longer has literals is stale bookkeeping and hides progress, so it
    // has to be removed when the last literal in that file goes.
    const found = scan();
    const stale = Object.keys(REMAINING).filter((file) => (found.get(file)?.count ?? 0) === 0);
    expect(stale, 'remove these from REMAINING — they are already clean').toEqual([]);
  });
});
