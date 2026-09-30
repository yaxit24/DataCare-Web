import { Decimal } from 'decimal.js';
import { round, PRECISION } from './money.js';

/**
 * Retail sale (TR_SALE) item amount: which quantity the item rate multiplies.
 *
 * Desktop: `TR_SALE.cs` `CommPassTotal`, lines 10716-10936.
 *
 * - Grid column 21 `RtWith` belongs to each line. `CommPassAdd` seeds it from the company
 *   `SL_AMT_TYPE` (TR_SALE.cs:9161), and `BtnSave_Click` saves it to `SL_DETL.RATE_WITH` (:15432).
 * - Column 58 is the item's `RATE_TYPE`, copied from `ITEM_MAST.RATE_TYPE` (:12833). Its values are
 *   G, 1, K and P: gram, 10 g, kg and pieces (MS_ITEM.cs:2731-2734, :3243).
 * - A blank `SL_AMT_TYPE` is 'N' everywhere the desktop reads it:
 *   - MS_OPNCOMP.cs:881-884 sets it when the company is opened;
 *   - Ac_Image.cs:6221 backfills NULL to 'N' in the database;
 *   - UT_SETTING_MAIN.cs:8526-8545 shows blank as "Net Wise".
 *
 * The item amount, before the caller's rounding pipeline:
 *
 * | RATE_TYPE | RtWith          | amount                                   | source        |
 * |-----------|-----------------|------------------------------------------|---------------|
 * | P         | any             | pcs x rate                               | 10884, 10932  |
 * | 1         | F / G / other   | (fine / gross / net + ghat) x rate / 10  | 10928         |
 * | K         | F / G / other   | (fine / gross / net + ghat) x rate / 1000| 10924         |
 * | G/blank   | F               | fine x rate (no ghat)                    | 10898-10905   |
 * | G/blank   | P               | pcs x rate                               | 10909-10916   |
 * | G/blank   | G               | (gross + ghat) x rate                    | 10843-10850, 10920 |
 * | G/blank   | N/blank/other   | (net + ghat) x rate                      | 10854, 10920  |
 *
 * Details that follow from the table:
 * - "fine" is grid column 20. When touch + wastage is 0, column 20 is net + ghat (10753-10760), so
 *   a zero fine falls back to net + ghat.
 * - Rate types 1 and K add ghat even to the fine quantity. This is a desktop quirk and is kept.
 *
 * Not reproduced: the desktop's path-dependent recalculation. When the RtWith column is visible and
 * a pass finds the cell unchanged, `text` reverts to "N" (10772-10798), so a G line can be repriced
 * on net after a later rate edit. The web prices from the final line using the line's own value.
 */

const D = (value: Decimal.Value | null | undefined): Decimal => new Decimal(value ?? 0);

/** The desktop cell is one character wide (`MaxLength = 1`, TR_SALE.cs:9306-9311). */
export function saleRateWithCode(value: unknown): string {
  return String(value ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);
}

/** `CO_SET.SL_AMT_TYPE` as the desktop uses it: blank means 'N' (MS_OPNCOMP.cs:881-884). */
export function companySaleAmountType(value: unknown): string {
  return saleRateWithCode(value) || 'N';
}

/** A line's RtWith: its own column-21 value, else the company value (`CommPassAdd`, TR_SALE.cs:9161). */
export function effectiveSaleRateWith(lineValue: unknown, companyType: unknown): string {
  return saleRateWithCode(lineValue) || companySaleAmountType(companyType);
}

export interface SaleAmountLine {
  pcs?: Decimal.Value | null;
  grossWt?: Decimal.Value | null;
  netWt?: Decimal.Value | null;
  ghtWt?: Decimal.Value | null;
  /** The line's fine weight (grid column 20), as resolved by the caller's fine policy. */
  fineWt?: Decimal.Value | null;
}

export interface SaleAmountBasis {
  /** The quantity the item rate multiplies: a weight, or a piece count. */
  quantity: number;
  /** 1, or 10 for RATE_TYPE '1' (rate per 10 g), or 1000 for RATE_TYPE 'K' (rate per kg). */
  rateDivisor: 1 | 10 | 1000;
}

/**
 * The quantity and rate divisor for one line.
 *
 * `rateWith` is the EFFECTIVE value: the caller resolves it with `effectiveSaleRateWith`.
 */
export function saleAmountBasis(
  line: SaleAmountLine,
  rateWith: unknown,
  rateType?: unknown,
): SaleAmountBasis {
  const code = saleRateWithCode(rateWith);
  const itemRateType = String(rateType ?? '')
    .trim()
    .toUpperCase();
  const pcs = D(line.pcs);
  const net = D(line.netWt);
  const ghat = D(line.ghtWt);
  const fine = D(line.fineWt);
  if (itemRateType === 'P') return { quantity: pcs.toNumber(), rateDivisor: 1 };
  // 10802-10865: the weight column the rate applies to.
  const weight =
    code === 'F' ? (fine.isZero() ? net.plus(ghat) : fine) : code === 'G' ? D(line.grossWt) : net;
  if (itemRateType === '1' || itemRateType === 'K') {
    return {
      quantity: weight.plus(ghat).toNumber(),
      rateDivisor: itemRateType === '1' ? 10 : 1000,
    };
  }
  if (code === 'F') return { quantity: weight.toNumber(), rateDivisor: 1 };
  if (code === 'P') return { quantity: pcs.toNumber(), rateDivisor: 1 };
  return { quantity: weight.plus(ghat).toNumber(), rateDivisor: 1 };
}

/** Item amount = quantity x (rate / divisor), at the web's metal-amount precision. */
export function saleItemAmount(
  basis: SaleAmountBasis,
  rate: Decimal.Value | null | undefined,
): number {
  return round(D(basis.quantity).times(D(rate).div(basis.rateDivisor)), PRECISION.amount);
}
