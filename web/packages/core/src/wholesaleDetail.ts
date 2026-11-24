import { dotNetRoundDouble, round } from './money.js';

/**
 * TR_WH_SALE item-detail grid (`MSG_IDTL`): the hand-typed stone / loose-item rows under an issue line, shared by the
 * writer (apps/api `wholesaleDetailRows.ts`) and the Wh Sales screen, so what the operator sees is what posts.
 *
 * Source: `CommPassTotal_Idtl`, TR_WH_SALE.cs:7750-7971 (column numbers below are `MSG_IDTL`'s), and the Enter handler
 * of the edit box, :7389-7530. The desktop keeps every cell as TEXT and re-reads it with `Conversion.Val`, so a cell
 * formatted "0.000" or "0.00" is what the next step sees: each step below rounds exactly where the desktop formats
 * (`Strings.Format` is half away from zero = `round`) and `Math.Round(x, 0)` is `dotNetRoundDouble` (banker's, on the
 * double). Amounts are never negative on the web (the hosted service refuses a negative figure before it gets here).
 *
 * Desktop ambiguities, resolved as the study decided (orchestration/work/WP-30/study.md): the two guards the source
 * writes as `Val(mSG_IDTL[24]) > 0` and `Val(mSG_IDTL[19]) > 0` are read as "the row's KrCon% is above zero" and "the
 * row's Disc% is above zero", and Con% (col 15) multiplies the weight as a factor, with no division by 100: ConWt =
 * Weight x Con%, which is how a carat-to-gram factor such as 0.2 is entered.
 */

/** One grid row as typed or reloaded (numbers, `Val` of the cell). */
export interface WholesaleDetailInput {
  /** col 10 */
  pcs?: number;
  /** col 11 */
  pcsWt?: number;
  /** col 14 "Weight" (IT_GWT) */
  weight?: number;
  /** col 26 tag weight (KR_WT); defaults to the weight when it is still zero */
  tagWt?: number;
  /** col 15 Con% */
  conPct?: number;
  /** col 24 KrCon% */
  krConPct?: number;
  /** col 16 rate type: '' (by weight), 'P' (by piece) or anything else (by weight) */
  rateType?: string;
  /** col 17 */
  rate?: number;
  /** col 18 (kept as typed when no rate gives it) */
  itAmt?: number;
  /** col 19 */
  discPct?: number;
  /** col 20 (kept as typed when no Disc% gives it) */
  discAmt?: number;
  /** col 21 */
  lbrRate?: number;
  /** col 22 (kept as typed when no labour rate gives it) */
  lbrAmt?: number;
  /** col 23 (kept as typed when the item and labour amounts are both zero) */
  netAmt?: number;
  /** col 28 */
  itType?: string;
}

export interface WholesaleDetailResult {
  pcs: number;
  pcsWt: number;
  weight: number;
  tagWt: number;
  conPct: number;
  conWt: number;
  krConPct: number;
  krConWt: number;
  rateType: string;
  rate: number;
  itAmt: number;
  discPct: number;
  discAmt: number;
  lbrRate: number;
  lbrAmt: number;
  netAmt: number;
  itType: string;
}

const n = (value: unknown): number => {
  const x = Number(value ?? 0);
  return Number.isFinite(x) ? x : 0;
};
const f3 = (x: number): number => round(x, 3);
const f2 = (x: number): number => round(x, 2);

/** `CommPassTotal_Idtl(CRow)` for one row: steps 1 to 8 of the study's Calculations, in the desktop's order. */
export function commPassTotalIdtl(input: WholesaleDetailInput): WholesaleDetailResult {
  const pcs = n(input.pcs);
  const pcsWt = n(input.pcsWt);
  const conPct = n(input.conPct);
  const krConPct = n(input.krConPct);
  const rate = n(input.rate);
  const discPct = n(input.discPct);
  const lbrRate = n(input.lbrRate);
  const rateType = String(input.rateType ?? '');

  // 1. Weight from pieces (:7753-7756): only when both are non-zero, written "0.000".
  let weight = n(input.weight);
  if (pcs !== 0 && pcsWt !== 0) weight = f3(pcs * pcsWt);
  weight = f3(weight);
  // 2. Tag weight defaults to the weight while it is still zero (:7758-7761).
  let tagWt = f3(n(input.tagWt));
  if (weight !== 0 && tagWt === 0) tagWt = weight;
  // 3. ConWt = Weight x Con% (:7762-7766), else 0.
  const conWt = weight !== 0 && conPct !== 0 ? f3(weight * conPct) : 0;
  // 4. KrConWt: tag weight x KrCon% when KrCon% is above zero, otherwise tag weight x Con% (:7767-7779).
  let krConWt = 0;
  if (krConPct > 0) {
    if (tagWt !== 0 && krConPct !== 0) krConWt = f3(tagWt * krConPct);
  } else if (tagWt !== 0 && conPct !== 0) krConWt = f3(tagWt * conPct);

  // 5. ItAmt by the rate type (:7780-7805). `Math.Round(x, 0)` is on the double, then "0.00".
  let itAmt = f2(n(input.itAmt));
  if (rateType === '') {
    if (weight === 0 && pcs !== 0 && rate !== 0) itAmt = f2(dotNetRoundDouble(rate * pcs, 0));
    else if (weight !== 0 && rate !== 0) itAmt = f2(dotNetRoundDouble(rate * weight, 0));
  } else if (rateType === 'P' && dotNetRoundDouble(rate, 0) !== 0) {
    // `(0 - (type == "P")) & (long)Math.Round(rate)` is non-zero only for type P with a rate that rounds to non-zero.
    itAmt = f2(dotNetRoundDouble(rate * pcs, 0));
  } else if (rate !== 0) {
    itAmt = f2(dotNetRoundDouble(rate * weight, 0));
  }
  // 6. LbrAmt = LbrRate x Pcs when the rate is non-zero (:7811).
  let lbrAmt = f2(n(input.lbrAmt));
  if (lbrRate !== 0) lbrAmt = f2(lbrRate * pcs);
  // 7. DiscAmt = Math.Round(ItAmt x Disc% / 100, 0) (:7815).
  let discAmt = f2(n(input.discAmt));
  if (discPct > 0 && itAmt !== 0) discAmt = f2(dotNetRoundDouble((itAmt * discPct) / 100, 0));
  // 8. NetAmt = ItAmt - DiscAmt + LbrAmt when ItAmt + LbrAmt is non-zero (:7819); otherwise the typed cell stays.
  let netAmt = f2(n(input.netAmt));
  if (itAmt + lbrAmt !== 0) netAmt = f2(itAmt - discAmt + lbrAmt);

  return {
    pcs,
    pcsWt,
    weight,
    tagWt,
    conPct,
    conWt,
    krConPct,
    krConWt,
    rateType,
    rate,
    itAmt,
    discPct,
    discAmt,
    lbrRate,
    lbrAmt,
    netAmt,
    itType: String(input.itType ?? ''),
  };
}

/** The Enter handler of column 11 (:7503-7510): Weight = Pcs x PcsWt when both are non-zero. */
export function detailWeightFromPieces(pcs: number, pcsWt: number): number | null {
  return n(pcs) !== 0 && n(pcsWt) !== 0 ? f3(n(pcs) * n(pcsWt)) : null;
}

/** The Enter handler of column 13 (:7511-7517): Weight = KrWt x KrLs% / 100 when both are non-zero. */
export function detailWeightFromKr(krWt: number, krLessPct: number): number | null {
  return n(krWt) !== 0 && n(krLessPct) !== 0 ? f3((n(krWt) * n(krLessPct)) / 100) : null;
}

/** What the roll-up writes into the issue line (`MSG` columns 16, 17, 28, 37, 46 and 47; :7821-7880). */
export interface WholesaleDetailRollup {
  /** col 16 OthWt: sum of ConWt, set only when it is non-zero */
  othWt: number | null;
  /** col 17 NetWt: gross - OthWt, set only when OthWt is */
  netWt: number | null;
  /** col 46 KrOthWt: sum of KrConWt, set only when it is non-zero */
  krOthWt: number | null;
  /** col 47 KrNwt: gross - KrOthWt, set only when KrOthWt is */
  krNwt: number | null;
  /** col 37 OthAmt: sum of NetAmt, set only when it is non-zero */
  othAmt: number | null;
  /** col 28 SlvrFine: weight of the silver rows with no ItAmt; null when none (the cell is cleared otherwise) */
  silverFine: number | null;
}

type RollupRow = Pick<
  WholesaleDetailResult,
  'conWt' | 'krConWt' | 'netAmt' | 'itAmt' | 'weight' | 'itType'
>;

/** The roll-up of the line's rows (already through `commPassTotalIdtl`) into the issue line, given its gross weight. */
export function rollupWholesaleDetails(
  rows: ReadonlyArray<RollupRow>,
  grossWt: number,
): WholesaleDetailRollup {
  let conWt = 0;
  let krConWt = 0;
  let netAmt = 0;
  let silver = 0;
  for (const row of rows) {
    conWt += row.conWt;
    krConWt += row.krConWt;
    netAmt += row.netAmt;
    if (row.itType === 'S' && row.itAmt === 0) silver += f2(row.weight);
  }
  const gross = n(grossWt);
  return {
    othWt: conWt !== 0 ? f3(conWt) : null,
    netWt: conWt !== 0 ? f3(gross - f3(conWt)) : null,
    krOthWt: krConWt !== 0 ? f3(krConWt) : null,
    krNwt: krConWt !== 0 ? f3(gross - f3(krConWt)) : null,
    othAmt: netAmt !== 0 ? f2(netAmt) : null,
    silverFine: silver !== 0 ? f2(silver) : null,
  };
}

/** The save loop keeps a row only when pieces, weight, tag weight or net amount is non-zero (:13175-13190). */
export function detailRowIsWritten(
  row: Pick<WholesaleDetailResult, 'pcs' | 'weight' | 'tagWt' | 'netAmt'>,
): boolean {
  return row.pcs + row.weight + row.tagWt + row.netAmt !== 0;
}
