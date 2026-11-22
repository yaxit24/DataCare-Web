import { Decimal } from 'decimal.js';
import { dotNetRoundDouble } from './money.js';

/**
 * One Sale grid row, computed the way `TR_SALE.cs` CommPassTotal computes it. This is the ONE implementation the Sale
 * and Sales Quotation previews and the API's `computeLine` share, so a preview can never differ from a posting.
 *
 * Arithmetic is IEEE double in the desktop's statement order (`Conversion.Val` returns a double), rounded with .NET
 * `Math.Round(double, digits)` (half to even on the scaled double, `dotNetRoundDouble`) at exactly the points the
 * desktop rounds, and a cell the desktop writes with `Strings.Format(.., "0.00")` goes through `formatCell2`.
 */

/**
 * VB `Strings.Format(Val(x), "0.00")` read back with `Val`: .NET Framework formats a double from its 15 significant
 * digits and rounds the last place half away from zero. So a typed 0.315 becomes "0.32" (TR_SALE.cs:9479-9496 for
 * the labour rate cell, :9478/:9495 for the amount cell).
 */
export function formatCell2(value: number): number {
  return formatCell(value, 2);
}

/** `Strings.Format(x, "0.000")` (or any fixed places) read back with `Val`, as `formatCell2`. */
export function formatCell(value: number, places: number): number {
  if (!Number.isFinite(value)) return 0;
  return new Decimal(value.toPrecision(15))
    .toDecimalPlaces(places, Decimal.ROUND_HALF_UP)
    .toNumber();
}

/**
 * The Sale grid's ghat weight from Ghat %: `ITM_GHT_WT = Format(ITM_NWT * ITM_GHT_PRC / 100, "0.000")`
 * (TR_SALE.cs:10581). Used by the preview and by the API for a line that sends Ghat % without a ghat weight.
 */
export function saleGhatWeight(netWt: number, ghtPct: number): number {
  return formatCell((netWt * ghtPct) / 100, 3);
}

/** How the row's labour is priced. `rate` and `percentage` multiply an LBR_TYPE basis; `fixed` is a web amount. */
export type SaleLineLabourMode = 'none' | 'rate' | 'percentage' | 'fixed';

export interface SaleLineCells {
  /** ITM_PCS, ITM_GWT, ITM_NWT, ITM_GHT_WT, ITM_FINE: grid columns 11, 12, 14, 17, 20. */
  pcs: number;
  grossWt: number;
  netWt: number;
  ghtWt: number;
  fineWt: number;
  /** The line's effective RtWith (column 21: N, G, F or P) and the item RATE_TYPE (column 58). */
  rateWith: string;
  rateType?: string;
  /** ITM_RATE, column 22, as the grid holds it (already rounded by ITM_RATE_ROF). */
  itemRate: number;
  /** A TYPED ITM_AMT (column 23). Absent: the amount is computed from the rate. */
  itemAmount?: number | null;
  labourMode: SaleLineLabourMode;
  /** LBR_TYPE, column 25: the basis LBR_RATE multiplies (G, N, K, P, else blank). */
  labourBasis: string;
  /** LBR_PRC, column 24. */
  labourPct: number;
  /** LBR_RATE, column 26. Absent on a percentage row: it is derived from LBR_PRC (TR_SALE.cs:11021). */
  labourRate?: number | null;
  labourFixed?: number;
  otherAmount: number;
}

export interface SaleLineSettings {
  /** CO_SET.LBR_ROF: the decimals of a derived labour rate (MsLbrRof). */
  labourRateDecimals: number;
  /** CO_SET.ALL_ROF_REMOVE = 'Y': line amounts keep 2 decimals instead of 0 (TR_SALE.cs:10343-10362). */
  allRoundingRemoved: boolean;
  /** CO_SET_NEW.LBR_WITH_GHT <> 'N' (blank default Y). */
  labourWithGhat: boolean;
  /** The Sales Return's basis switch falls back to gross weight (TR_SALE_RTN.cs:4975-4993). */
  basisRule?: 'sale' | 'saleReturn';
}

export interface SaleLineResult {
  itemAmount: number;
  /** LBR_RATE as stored (column 26), or undefined on a row with no rate-priced labour. */
  labourRate?: number;
  labourAmount: number;
  /** NET_AMT = ITM_AMT + LBR_AMT + OTH_AMT, the 2 dp sum (TR_SALE.cs:11548). */
  netAmount: number;
}

/** `Math.Round(ITM_RATE * LBR_PRC / 100.0, MsLbrRof)`, then the "0.00" cell (TR_SALE.cs:11021). */
export function derivedLabourRate(itemRate: number, pct: number, decimals: number): number {
  const raw = (itemRate * pct) / 100;
  return raw === 0 ? 0 : formatCell2(dotNetRoundDouble(raw, decimals));
}

/** The ITM_AMT expression of TR_SALE.cs:10802-10932, in double, before rounding. */
function itemAmountRaw(c: SaleLineCells): number {
  const rateType = String(c.rateType ?? '')
    .trim()
    .toUpperCase();
  const code = String(c.rateWith ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  if (rateType === 'P') return c.pcs * c.itemRate;
  // num5: the weight column the rate applies to (gross for G, fine for F, else net).
  const num5 =
    code === 'F'
      ? c.fineWt === 0
        ? c.netWt + c.ghtWt
        : c.fineWt
      : code === 'G'
        ? c.grossWt
        : c.netWt;
  if (rateType === '1') return (num5 + c.ghtWt) * (c.itemRate / 10);
  if (rateType === 'K') return (num5 + c.ghtWt) * (c.itemRate / 1000);
  if (code === 'F') return num5 * c.itemRate;
  if (code === 'P') return c.pcs * c.itemRate;
  return (num5 + c.ghtWt) * c.itemRate;
}

/** The LBR_AMT expression of TR_SALE.cs:11084-11127 (Sales Return :4975-4993), in double, before rounding. */
function labourAmountRaw(c: SaleLineCells, rate: number, s: SaleLineSettings): number {
  const code = String(c.labourBasis ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  switch (code) {
    case 'P':
      return c.pcs * rate;
    case 'N':
      return s.labourWithGhat ? (c.netWt + c.ghtWt) * rate : c.netWt * rate;
    case 'K':
      return (c.netWt + c.ghtWt) * (rate / 1000);
    case 'G':
      return c.grossWt * rate;
    default:
      return s.basisRule === 'saleReturn' ? c.grossWt * rate : (c.netWt + c.ghtWt) * rate;
  }
}

export function computeSaleLine(c: SaleLineCells, s: SaleLineSettings): SaleLineResult {
  // `digits` / `digits2`: 0, or 2 under ALL_ROF_REMOVE (TR_SALE.cs:10343-10362).
  const digits = s.allRoundingRemoved ? 2 : 0;
  const itemAmount =
    c.itemAmount != null
      ? formatCell2(c.itemAmount)
      : c.itemRate === 0
        ? 0
        : formatCell2(dotNetRoundDouble(itemAmountRaw(c), digits));
  let labourRate: number | undefined;
  let labourAmount = 0;
  if (c.labourMode === 'rate' || c.labourMode === 'percentage') {
    labourRate =
      c.labourRate != null
        ? formatCell2(c.labourRate)
        : c.labourMode === 'percentage'
          ? derivedLabourRate(c.itemRate, c.labourPct, s.labourRateDecimals)
          : 0;
    labourAmount = formatCell2(dotNetRoundDouble(labourAmountRaw(c, labourRate, s), digits));
  } else if (c.labourMode === 'fixed') {
    labourAmount = formatCell2(dotNetRoundDouble(c.labourFixed ?? 0, digits));
  }
  const netAmount = new Decimal(itemAmount)
    .plus(labourAmount)
    .plus(c.otherAmount || 0)
    .toDecimalPlaces(2, Decimal.ROUND_HALF_UP)
    .toNumber();
  return { itemAmount, labourRate, labourAmount, netAmount };
}

/** The grid cells one edit touches, with the column-83 tracker (the LBR_PRC the stored LBR_RATE came from). */
export interface SaleGridLabourCells {
  rate?: string;
  making?: string;
  lbrPct?: string;
  /** Column 83: the LBR_PRC last applied to LBR_RATE ('' = none). Restored from LBR_PRC on reopen (:21091-21096). */
  lbrPctApplied?: string;
  metalAmount?: string;
  pcs?: string;
  grossWt?: string;
}

const val = (v: string | number | undefined | null): number => {
  const x = Number(String(v ?? '').trim() || 0);
  return Number.isFinite(x) ? x : 0;
};

/**
 * One cell edit followed by CommPassTotal's own bookkeeping, in the desktop's order:
 *
 * - a changed item rate, weight, pieces, touch or RtWith on a row with weight or pieces re-prices ITM_AMT, so a typed
 *   amount is dropped, and resets column 83 (TR_SALE.cs:10413-10790, :10822-10880);
 * - Lbr% set to 0 clears LBR_RATE (:11033-11048);
 * - whenever LBR_PRC differs from column 83 and the item rate is not 0, LBR_RATE is re-derived and column 83 takes
 *   LBR_PRC (:10999-11021). A percentage entered before the item rate therefore waits for it, and a Making/g typed
 *   after the percentage stands.
 */
/**
 * Cells whose edit makes CommPassTotal price the row again: the rate (column 22 against its tracker 82) and the
 * weights, pieces, touch and RtWith, whose edits reset column 82 (TR_SALE.cs:10413-10790). Re-pricing also resets
 * column 83, so a percentage row re-derives its labour rate (:10876-10880).
 */
const AMOUNT_INPUTS = new Set([
  'rate',
  'pcs',
  'grossWt',
  'lessWt',
  'netWt',
  'ghtWt',
  'ghtPct',
  'touch',
  'westPct',
  'rateWith',
]);

export function applySaleGridEdit<T extends SaleGridLabourCells>(
  row: T,
  key: keyof T,
  value: string,
  labourRateDecimals: number,
  roundItemRate: (v: number) => number = (v) => v,
): T {
  const next: T = { ...row, [key]: value };
  const cur = row[key] as unknown as string | undefined;
  const repriced = AMOUNT_INPUTS.has(String(key)) && String(value ?? '') !== String(cur ?? '');
  if (repriced && val(next.grossWt) + val(next.pcs) !== 0) {
    next.lbrPctApplied = '';
    next.metalAmount = '';
  }
  if (key === 'lbrPct' && val(value) === 0) {
    next.making = '';
    next.lbrPctApplied = '';
    return next;
  }
  const itemRate = roundItemRate(val(next.rate));
  if (val(next.lbrPct) !== 0 && val(next.lbrPct) !== val(next.lbrPctApplied) && itemRate !== 0) {
    next.making = derivedLabourRate(itemRate, val(next.lbrPct), labourRateDecimals).toFixed(2);
    next.lbrPctApplied = String(next.lbrPct);
  }
  return next;
}
