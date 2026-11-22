import { Decimal as DecimalJs } from 'decimal.js';
import { round, PRECISION } from './money.js';
import { roundSaleLineAmount } from './roundingPolicy.js';

/** Structurally implemented by the API's company rounding policy. */
export interface MoneyRoundingPolicy {
  taxDecimals?: number;
  billTotalDecimals?: number;
  /** `CO_SET.ALL_ROF_REMOVE = 'Y'`: the Sale line's own precision switch (`saleLineDecimals`). */
  allRoundingRemoved?: boolean;
  roundTaxAmount(value: number): number;
  roundLabourAmount(value: number): number;
  /**
   * `Math.Round(x, MsLbrRof)` for a DERIVED labour rate (TR_SALE.cs:11021, TR_SALE_RTN.cs:4963). Falls back to
   * `roundLabourAmount`, which is the same LBR_ROF stage unless a form hardcodes its labour amount precision
   * (`salesReturnRoundingPolicy`) and keeps this one.
   */
  roundLabourRate?(value: number): number;
  roundItemRate(value: number): number;
  roundBillTotal(value: number): number;
  roundPurchaseRate(value: number): number;
}

/** Labour/making-charge types (Req 12.2–12.5). */
export type LabourType = 'per_gram' | 'per_piece' | 'percentage' | 'fixed';

/**
 * Which desktop form's `LBR_TYPE` switch turns a basis code into a quantity. They differ only in the fallback:
 *
 * | LBR_TYPE | 'sale' (TR_SALE.cs:11084-11127)      | 'saleReturn' (TR_SALE_RTN.cs:4975-4993) |
 * |----------|-------------------------------------|-----------------------------------------|
 * | P        | ITM_PCS                             | ITM_PCS                                 |
 * | N        | ITM_NWT (+ ITM_GHT_WT unless LBR_WITH_GHT = N) | same                         |
 * | K        | (ITM_NWT + ITM_GHT_WT) / 1000       | same                                    |
 * | G        | ITM_GWT                             | ITM_GWT (the default branch)            |
 * | other    | ITM_NWT + ITM_GHT_WT                | ITM_GWT                                 |
 */
export type LabourBasisRule = 'sale' | 'saleReturn';

export interface LabourInput {
  netWt?: DecimalJs.Value;
  pcs?: DecimalJs.Value;
  rate?: DecimalJs.Value;
  pct?: DecimalJs.Value;
  fixed?: DecimalJs.Value;
  /** `ITM_GWT`: the G basis of a percentage line. */
  grossWt?: DecimalJs.Value;
  /** `ITM_RATE`: a percentage line's labour rate is LBR_PRC of it (TR_SALE.cs:11021). */
  itemRate?: DecimalJs.Value;
  /**
   * `LBR_TYPE` (G/N/K/P, else blank): the basis a percentage line's derived rate multiplies. The web's
   * `per_gram` and `per_piece` modes are the N and P bases with a typed rate.
   */
  basis?: string;
  /** Whose basis switch applies; the Sale's by default. */
  basisRule?: LabourBasisRule;
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
  const v = labourChargeExact(type, i, policy);
  return policy ? policy.roundLabourAmount(v.toNumber()) : round(v, PRECISION.amount);
}

/**
 * `LBR_RATE` of a percentage line: `Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof)` (TR_SALE.cs:11021; the Sales
 * Return grid has the same statement at TR_SALE_RTN.cs:4963), stored in the grid cell as `Format(.., "0.00")`, which
 * is the value every amount branch then reads back with `Conversion.Val`. A zero percentage gives 0.
 *
 * Without a policy the rate keeps the web's 2 dp default.
 */
export function percentageLabourRate(
  itemRate: DecimalJs.Value | null | undefined,
  pct: DecimalJs.Value | null | undefined,
  policy?: Pick<MoneyRoundingPolicy, 'roundLabourAmount' | 'roundLabourRate'>,
): number {
  const raw = D(itemRate ?? 0)
    .times(D(pct ?? 0))
    .div(100)
    .toNumber();
  if (raw === 0) return 0;
  const rounded = policy
    ? (policy.roundLabourRate ?? policy.roundLabourAmount)(raw)
    : round(raw, PRECISION.amount);
  // The cell holds "0.00" text: a 3-decimal LBR_ROF is cut back to 2 when the rate is read again.
  return round(rounded, PRECISION.amount);
}

/** The quantity `LBR_RATE` multiplies for a desktop `LBR_TYPE`, and the per-kg divisor (see LabourBasisRule). */
export function desktopLabourBasisQuantity(
  basis: string | undefined,
  i: Pick<LabourInput, 'netWt' | 'pcs' | 'grossWt' | 'ghatWt' | 'withGhat' | 'basisRule'>,
): DecimalJs {
  const code = String(basis ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  const net = D(i.netWt);
  const ghat = D(i.ghatWt ?? 0);
  switch (code) {
    case 'P':
      return D(i.pcs);
    case 'N':
      return net.plus(i.withGhat === false ? 0 : ghat);
    case 'K':
      return net.plus(ghat).div(1000);
    case 'G':
      return D(i.grossWt);
    default:
      return i.basisRule === 'saleReturn' ? D(i.grossWt) : net.plus(ghat);
  }
}

/**
 * Sale LBR_AMT: ONE `Math.Round(basis x LBR_RATE, digits2)` (TR_SALE.cs:11100-11127), where `digits2` is the Sale
 * line precision: 0, or 2 under ALL_ROF_REMOVE (TR_SALE.cs:10343-10362, `saleLineDecimals`). Neither LBR_ROF nor
 * TOT_AMT_ROF rounds the amount: LBR_ROF only rounds a derived RATE (:11021, :11160-11183), and TOT_AMT_ROF only the
 * bill totals (:19192, :19274). Desktop oracle vectors `labour.mid.*` (run 42580947381) pin the single rounding.
 */
export function saleLineLabourAmount(
  type: LabourType,
  i: LabourInput,
  policy: MoneyRoundingPolicy,
): number {
  return roundSaleLineAmount(labourChargeExact(type, i, policy).toNumber(), policy);
}

function labourChargeExact(
  type: LabourType,
  i: LabourInput,
  policy?: MoneyRoundingPolicy,
): DecimalJs {
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
      // The desktop never takes a percentage of an amount. LBR_PRC derives LBR_RATE from the ITEM RATE
      // (TR_SALE.cs:11021), and the LBR_TYPE basis multiplies that rate like any typed rate (:11084-11127).
      // Desktop oracle vectors labour.pct.* (run 42580947381): G, rtN gives 7853 where LBR_PRC of the item
      // amount gave 7570.
      v = desktopLabourBasisQuantity(i.basis, i).times(
        percentageLabourRate(i.itemRate, i.pct, policy),
      );
      break;
    case 'fixed':
      v = D(i.fixed);
      break;
  }
  return v;
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
 * Desktop sale LINE total, persisted to `SL_DETL.TOT_AMT` and `SL_DETL.NET_AMT`.
 *
 * `TR_SALE.cs` `CommPassTotal`, the per-row calculation every cell exit runs (:11548 and :11559, then :11570):
 *   `mSG[Row,35] = Format(Val(mSG[Row,27]) + Val(mSG[Row,29]) + Val(mSG[Row,23]) - Val(mSG[Row,32]), "0.00")`
 *   `mSG[Row,37] = Format(Val(mSG[Row,35]), "0.00")`          (when the line has no TAX_PRC)
 * where 23 = item amount, 27 = labour amount, 29 = other amount, 32 = labour discount.
 *
 * - The sum is NOT rounded to whole rupees: it keeps paise at 2 dp. Item and labour amounts are already whole rupees
 *   (one `Math.Round(..., 0)` each), so only a paise OTHER amount reaches the total: 63085 + 2544 + 1234.50 =
 *   66863.50 on the desktop (desktop oracle vector `total.stone`, run 42580947381).
 * - The whole-rupee `Math.Round(23 + 27 + 29, 0)` this function used to apply is `NetAmtChange` (TR_SALE.cs:18416),
 *   which runs only when the operator presses F1 on the bill-net cell to spread a new net amount over the lines.
 * - Tax-exclusive; `NET_AMT` equals `TOT_AMT` on a line without TAX_PRC.
 * - The labour discount (column 32) is not modelled by the web line yet; callers pass none.
 *
 * Write set: `SL_DETL.TOT_AMT` <- `Val(mSG[i,35])` (line 15436) and `SL_DETL.NET_AMT` <- `Val(mSG[i,37])` (line 15438).
 */
export function lineTotalDesktop(parts: {
  itemAmount: DecimalJs.Value;
  labourAmount: DecimalJs.Value;
  otherAmount?: DecimalJs.Value;
}): number {
  return round(
    D(parts.itemAmount)
      .plus(parts.labourAmount)
      .plus(parts.otherAmount ?? 0),
    PRECISION.amount,
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
