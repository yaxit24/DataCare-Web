import { computeSaleLine, saleGhatWeight, type RoundingPolicy } from '@datacare/core';
import type { SaleLineInput } from './sales.js';

/**
 * A Sale line as it posts: the ONE shared Sale line (core `computeSaleLine`, TR_SALE.cs CommPassTotal in IEEE double
 * with .NET Math.Round), the same function the Sale and Sales Quotation previews run, so a preview and a posting
 * cannot differ.
 *
 * The request carries the grid's cells. A supplied `labourRate` is LBR_RATE as the grid holds it and stands; a
 * percentage line without one derives it from LBR_PRC (TR_SALE.cs:10999-11021). A supplied `metalAmount` is a typed
 * ITM_AMT, kept as its "0.00" cell (:9478, :9495). `per_gram` and `per_piece` are the N and P bases with a typed rate;
 * a percentage multiplies the LBR_TYPE the writer persists (`basis`).
 */
export function postedSaleLine(
  line: SaleLineInput,
  fine: number,
  itemRate: number,
  rateWith: string,
  basis: string | undefined,
  policy: RoundingPolicy,
  labourWithGhat: boolean,
): { fine: number; metal: number; labour: number; net: number; labourRate?: number } {
  const num = (v: number | null | undefined): number => Number(v ?? 0);
  const type = line.labourType;
  const r = computeSaleLine(
    {
      pcs: num(line.pcs),
      grossWt: num(line.grossWt),
      netWt: num(line.netWt),
      ghtWt: num(line.ghtWt),
      fineWt: fine,
      rateWith,
      rateType: line.rateType,
      itemRate,
      itemAmount: line.metalAmount == null ? null : num(line.metalAmount),
      labourMode: !type
        ? 'none'
        : type === 'fixed'
          ? 'fixed'
          : type === 'percentage'
            ? type
            : 'rate',
      labourBasis: type === 'per_gram' ? 'N' : type === 'per_piece' ? 'P' : (basis ?? ''),
      labourPct: num(line.labourPct),
      labourRate:
        line.labourRate == null ? (type === 'percentage' ? null : 0) : num(line.labourRate),
      labourFixed: num(line.labourFixed),
      otherAmount: num(line.otherAmount),
    },
    {
      labourRateDecimals: policy.labourDecimals,
      allRoundingRemoved: !!policy.allRoundingRemoved,
      labourWithGhat,
    },
  );
  return {
    fine,
    metal: r.itemAmount,
    labour: r.labourAmount,
    net: r.netAmount,
    labourRate: r.labourRate,
  };
}

/**
 * A Sale line that sends Ghat % without a ghat weight takes the grid's own derivation, ITM_GHT_WT =
 * Format(ITM_NWT x ITM_GHT_PRC / 100, "0.000") (TR_SALE.cs:10581), as the page preview does; a sent weight wins.
 */
export function withSaleGhat<T extends Pick<SaleLineInput, 'ghtWt' | 'ghtPct' | 'netWt'>>(
  line: T,
): T {
  if (line.ghtWt != null || !line.ghtPct) return line;
  return { ...line, ghtWt: saleGhatWeight(Number(line.netWt ?? 0), Number(line.ghtPct)) };
}
