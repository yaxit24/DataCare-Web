import { Decimal as DecimalJs } from 'decimal.js';
import { round, roundHalfEven, PRECISION } from './money.js';

/** Structurally implemented by the API's company rounding policy. */
export interface MoneyRoundingPolicy {
  taxDecimals?: number;
  billTotalDecimals?: number;
  roundTaxAmount(value: number): number;
  roundLabourAmount(value: number): number;
  roundItemRate(value: number): number;
  roundBillTotal(value: number): number;
  roundPurchaseRate(value: number): number;
}

/** Labour/making-charge types (Req 12.2–12.5). */
export type LabourType = 'per_gram' | 'per_piece' | 'percentage' | 'fixed';

export interface LabourInput {
  netWt?: DecimalJs.Value;
  pcs?: DecimalJs.Value;
  rate?: DecimalJs.Value;
  pct?: DecimalJs.Value;
  metalAmount?: DecimalJs.Value;
  fixed?: DecimalJs.Value;
  /**
   * `ITM_GHT_WT` — ghat (wastage-carrier) weight, part of the per-gram labour base.
   *
   * The desktop computes per-gram labour as `(NetWt + GhtWt) x rate` and drops the ghat term only
   * when `CO_SET_NEW.LBR_WITH_GHT = 'N'` (TR_SALE.cs:11112-11123; the same branch appears in
   * TR_APR_ISU.cs:4255 and TR_BUL_SALE.cs:5513, :5594, :7121). Its blank DEFAULT is 'Y'
   * (MS_OPNCOMP.cs:1224-1226), so including ghat is the normal case.
   *
   * This was absent, so every per-gram labour charge on a line carrying ghat weight was UNDERSTATED
   * by `ghat x rate` — a money defect, not a rounding difference.
   */
  ghatWt?: DecimalJs.Value;
  /**
   * Whether the ghat term applies. Defaults to TRUE to match the desktop's blank default; a company
   * with `LBR_WITH_GHT = 'N'` passes false.
   */
  withGhat?: boolean;
}

const D = (v?: DecimalJs.Value): DecimalJs => new DecimalJs(v ?? 0);

/** Labour charge by type (Req 12.2–12.5). */
export function labourCharge(
  type: LabourType,
  i: LabourInput,
  policy?: MoneyRoundingPolicy,
): number {
  let v: DecimalJs;
  switch (type) {
    case 'per_gram':
      // (net + ghat) x rate, with the ghat term dropped only when the company switches it off.
      v = D(i.netWt)
        .plus(i.withGhat === false ? D(0) : D(i.ghatWt ?? 0))
        .times(D(i.rate));
      break;
    case 'per_piece':
      v = D(i.pcs).times(D(i.rate));
      break;
    case 'percentage':
      v = D(i.metalAmount).times(D(i.pct)).div(100);
      break;
    case 'fixed':
      v = D(i.fixed);
      break;
  }
  return policy ? policy.roundLabourAmount(v.toNumber()) : round(v, PRECISION.amount);
}

/** Metal amount = fine weight × rate. */
export function metalAmount(fineWt: DecimalJs.Value, rate: DecimalJs.Value): number {
  return round(D(fineWt).times(rate), PRECISION.amount);
}

/** Line net = metal + labour + other (Req 12.6). */
export function lineNet(parts: {
  metal: DecimalJs.Value;
  labour: DecimalJs.Value;
  other?: DecimalJs.Value;
}): number {
  return round(
    D(parts.metal)
      .plus(parts.labour)
      .plus(parts.other ?? 0),
    PRECISION.amount,
  );
}

/**
 * Desktop sale/purchase LINE total, persisted to `SL_DETL.TOT_AMT` and `SL_DETL.NET_AMT`.
 *
 * `TR_SALE.cs`, end of the per-row calculation loop:
 *   `mSG[X,35] = Format(Math.Round(Val(mSG[X,23]) + Val(mSG[X,27]) + Val(mSG[X,29]), 0), "0.00")`
 *   `mSG[X,37] = mSG[X,35]`
 * where 23 = item amount, 27 = labour amount, 29 = other amount.
 *
 * Three details matter and are easy to get wrong:
 *  1. the sum is rounded to **0 decimal places** — whole rupees — with a hardcoded 0, NOT `MsItmRateRof`;
 *  2. it is **tax-exclusive** (tax lives in its own column, 36, as a percentage);
 *  3. `NET_AMT` is a copy of `TOT_AMT`, so the two persisted columns are always equal.
 *
 * The write-set extraction confirms the binding: `SL_DETL.TOT_AMT` ← `Val(mSG[i,35])` (line 15436) and
 * `SL_DETL.NET_AMT` ← `Val(mSG[i,37])` (line 15438).
 */
export function lineTotalDesktop(parts: {
  itemAmount: DecimalJs.Value;
  labourAmount: DecimalJs.Value;
  otherAmount?: DecimalJs.Value;
}): number {
  return roundHalfEven(
    D(parts.itemAmount)
      .plus(parts.labourAmount)
      .plus(parts.otherAmount ?? 0),
    0,
  );
}

export interface GstSplit {
  cgst: number;
  sgst: number;
  igst: number;
}

/** CGST/SGST (intra) vs IGST (inter) split (Req 10.4/10.5, 18.2/18.3).
 *  Intra-state halves are EQUAL and unrounded, matching the desktop's direct `tax / 2.0` assignment. */
export function gstSplit(
  taxAmount: DecimalJs.Value,
  interState: boolean,
  policy?: MoneyRoundingPolicy,
): GstSplit {
  const roundTax = (value: DecimalJs): number =>
    policy ? policy.roundTaxAmount(value.toNumber()) : round(value, PRECISION.amount);
  const t = D(taxAmount);
  if (interState) return { cgst: 0, sgst: 0, igst: roundTax(t) };
  // TR_SALE.cs assigns the intra-state halves directly and WITHOUT rounding:
  //   ["SGST_TAX"] = Val(MSG2_TOTAL[2,3]) / 2.0;  ["CGST_TAX"] = Val(MSG2_TOTAL[2,3]) / 2.0;
  // Both columns are `double precision` with no scale, so an odd-paise tax is stored as two EQUAL
  // halves (₹1.01 → 0.505 and 0.505), not as 0.51 + 0.50. GST returns report the two heads separately,
  // so splitting them unequally would be visible on a filed return.
  const half = t.div(2).toNumber();
  return { cgst: half, sgst: half, igst: 0 };
}

export interface BillInput {
  lineNetTotal: DecimalJs.Value;
  discountAmount?: DecimalJs.Value;
  taxRatePct: DecimalJs.Value;
  interState: boolean;
}

export interface BillTotals {
  net: number;
  discount: number;
  taxable: number;
  tax: number;
  cgst: number;
  sgst: number;
  igst: number;
  roundOff: number;
  total: number;
}

/** Bill totals: net → discount → taxable → tax (split) → round-off → total (Req 10.3, 12). */
export function billTotals(i: BillInput, policy?: MoneyRoundingPolicy): BillTotals {
  const rawNet = D(i.lineNetTotal);
  const discount = D(i.discountAmount);

  // A supplied company policy follows the desktop totals grid: TOT_AMT_ROF rounds the monetary
  // base and final bill, while TAX_ROF independently rounds tax. No policy preserves legacy core
  // behavior, including its nearest-whole final total.
  const net = policy ? D(policy.roundBillTotal(rawNet.toNumber())) : rawNet;
  const taxableRaw = net.minus(discount);
  const taxable = policy ? D(policy.roundBillTotal(taxableRaw.toNumber())) : taxableRaw;
  const taxRaw = taxable.times(i.taxRatePct).div(100);
  const tax = policy ? D(policy.roundTaxAmount(taxRaw.toNumber())) : taxRaw;
  const split = gstSplit(tax, i.interState, policy);
  const preRound = taxable.plus(tax);
  const total = policy
    ? D(policy.roundBillTotal(preRound.toNumber()))
    : preRound.toDecimalPlaces(0, DecimalJs.ROUND_HALF_UP);
  const roundOff = total.minus(preRound);
  const roundOffDp = Math.max(
    PRECISION.amount,
    policy?.taxDecimals ?? 0,
    policy?.billTotalDecimals ?? 0,
  );
  return {
    net: policy ? net.toNumber() : round(net, PRECISION.amount),
    discount: round(discount, PRECISION.amount),
    taxable: policy ? taxable.toNumber() : round(taxable, PRECISION.amount),
    tax: policy ? tax.toNumber() : round(tax, PRECISION.amount),
    cgst: split.cgst,
    sgst: split.sgst,
    igst: split.igst,
    roundOff: round(roundOff, roundOffDp),
    total: policy ? total.toNumber() : round(total, PRECISION.amount),
  };
}
