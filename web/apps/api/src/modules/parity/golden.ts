import { gstSplit, billTotals, labourCharge } from '@datacare/core';
import { accruedInterest, monthlyTermInterest } from '../dhrn/dhrn.js';
import { fineWeight, fineWithWastage } from '../manufacturing/karigar.js';
import { ledgerBalance } from '../posting/posting.js';

/**
 * Parity golden vectors: fixed input → expected output pairs derived from the desktop's own formulas
 * (Ac_Ledr / TR_SALE GST split, RP_DHRN_OS interest, MS_UPDATE wastage, double-entry balance). This is
 * the deterministic parity gate that runs with no external dependency. Cross-DB row parity (vs a
 * restored SQL Server golden-master) is the separate heavy/external layer documented in the report.
 */

export interface Vector {
  name: string;
  ok: boolean;
  actual: unknown;
  expected: unknown;
}

const eq = (a: unknown, b: unknown): boolean => JSON.stringify(a) === JSON.stringify(b);

export function goldenVectors(): Vector[] {
  const v: Vector[] = [];
  const add = (name: string, actual: unknown, expected: unknown) =>
    v.push({ name, actual, expected, ok: eq(actual, expected) });

  // GST split (TR_SALE: intra CGST=SGST=tax/2; inter IGST=tax)
  add('gstSplit intra 30', gstSplit(30, false), { cgst: 15, sgst: 15, igst: 0 });
  add('gstSplit inter 30', gstSplit(30, true), { cgst: 0, sgst: 0, igst: 30 });

  // Bill totals (1000 @ 3%, no discount) intra + inter
  const bt = billTotals({
    lineNetTotal: 1000,
    discountAmount: 0,
    taxRatePct: 3,
    interState: false,
  });
  add('billTotals intra taxable', bt.taxable, 1000);
  add('billTotals intra tax', bt.tax, 30);
  add('billTotals intra total', bt.total, 1030);
  add('billTotals intra cgst+sgst', [bt.cgst, bt.sgst, bt.igst], [15, 15, 0]);
  const bti = billTotals({
    lineNetTotal: 2000,
    discountAmount: 0,
    taxRatePct: 3,
    interState: true,
  });
  add('billTotals inter igst', [bti.igst, bti.cgst, bti.sgst, bti.total], [60, 0, 0, 2060]);

  // Labour (per-gram)
  add('labour per_gram 10g@50', labourCharge('per_gram', { netWt: 10, rate: 50 }), 500);

  // Dhrn interest (RP_DHRN_OS: principal × rate% × days/yearDays)
  add('dhrn interest 10000@12% 90d/360', accruedInterest(10000, 12, 90, 360), 300);
  add('dhrn interest 10000@12% 360d/360', accruedInterest(10000, 12, 360, 360), 1200);
  // Dhrn MONTHLY interest (desktop CO_SET DHRN_INT_TYPE='M', confirmed vs Next24): principal × monthlyRate% × months
  add('dhrn monthly 10000@2%/mo × 3mo', monthlyTermInterest(10000, 2, 3), 600);
  add('dhrn monthly 50000@1.5%/mo × 6mo', monthlyTermInterest(50000, 1.5, 6), 4500);

  // Karigar fine (MS_UPDATE: NWT × (TOUCH+WEST)/100)
  add('karigar fine 100g@92%', fineWeight(100, 92), 92);
  add('karigar fine+wastage 100g@90%+2%', fineWithWastage(100, 90, 2), 92);

  // Double-entry balance (Ac_Ledr: ΣDR = ΣCR)
  const bal = ledgerBalance([{ DR_AMT: 1030 }, { CR_AMT: 1000 }, { CR_AMT: 30 }]);
  add('ledger balanced 1030', [bal.balanced, bal.dr, bal.cr], [true, 1030, 1030]);

  return v;
}

export interface ParityResult {
  passed: number;
  failed: number;
  total: number;
  results: Vector[];
}

/** Run all golden vectors; failed=0 ⇒ calc/ledger parity holds. */
export function runParity(): ParityResult {
  const results = goldenVectors();
  const passed = results.filter((r) => r.ok).length;
  return { passed, failed: results.length - passed, total: results.length, results };
}
