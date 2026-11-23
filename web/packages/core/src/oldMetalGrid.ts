import { round } from './money.js';

/**
 * Old-metal (exchange) grid rules of `TR_SALE.cs` that sit around the valuation in `oldGold.ts` (WP-26, G83):
 * the rate-type check, the touch back-calculation for the codes `OG`/`OS`, today's per-gram rates and the header
 * gold/silver split. Kept in the kernel so the sale screen and the writer apply the same rule.
 */

/** TR_SALE.cs:7669, spelling kept. */
export const OLD_METAL_RATE_TYPE_MESSAGE =
  'Please Slelect Rate type = N - Net Wise Or F - Fine Wise';

/**
 * TR_SALE.cs:7667: a typed rate type other than `N` or `F` is refused. `CompareString(.., false)` is a binary
 * compare, so a lower-case `n` is refused too. A blank cell is not typed and is not checked here (the valuation
 * then uses the fine weight, as `oldGoldBasisWeight` does for any non-`N` type).
 */
export function oldMetalRateTypeError(rateType: unknown): string | null {
  const value = String(rateType ?? '');
  if (value === '' || value === 'N' || value === 'F') return null;
  return OLD_METAL_RATE_TYPE_MESSAGE;
}

/**
 * Today's per-gram rates from the newest `RATE_MAST` row on or before the voucher date
 * (TR_SALE.cs:20833 `FINE_GL_RATE / 10`, :20854 `FINE_SL_RATE / 1000`, two decimals). A missing row gives 0.
 */
export function oldMetalTodayRates(
  row: { fineGoldRate?: unknown; fineSilverRate?: unknown } | null,
): {
  gold: number;
  silver: number;
} {
  const v = (x: unknown) => (Number.isFinite(Number(x)) ? Number(x ?? 0) : 0);
  return {
    gold: round(v(row?.fineGoldRate) / 10, 2),
    silver: round(v(row?.fineSilverRate) / 1000, 2),
  };
}

/**
 * TR_SALE.cs:7979-7993: on a net-wise row whose code is `OG` (or `OS`), the touch is back-calculated from the
 * amount and today's gold (silver) rate, two decimals, and the fine follows from it. Returns null when the rule
 * does not apply (other code, rate type not `N`, no today's rate, no net or no amount), leaving the typed touch.
 */
export function oldMetalTouchFromAmount(input: {
  itCode?: string;
  rateType?: string;
  netWt?: number;
  amount?: number;
  todayGoldRate?: number;
  todaySilverRate?: number;
}): { touch: number; fine: number } | null {
  if (String(input.rateType ?? '') !== 'N') return null;
  const code = String(input.itCode ?? '');
  const today =
    code === 'OG'
      ? Number(input.todayGoldRate ?? 0)
      : code === 'OS'
        ? Number(input.todaySilverRate ?? 0)
        : 0;
  const net = Number(input.netWt ?? 0);
  const amount = Number(input.amount ?? 0);
  if (today === 0 || net === 0 || amount === 0) return null;
  const touch = round((amount / today / net) * 100, 2);
  return { touch, fine: round((net * touch) / 100, 3) };
}

/**
 * Header totals of the old-metal grid (TR_SALE.cs:19343-19351): rows whose type is exactly `G` are gold, EVERY
 * other row (`S`, `P`, blank, ...) is silver. Weight is the NET weight (column 6, three decimals), amount is
 * column 13 (two decimals).
 */
export function oldMetalHeaderTotals(
  rows: ReadonlyArray<{ itType?: string; netWt?: number; amount?: number }>,
): { goldWt: number; goldAmt: number; silverWt: number; silverAmt: number } {
  let goldWt = 0;
  let goldAmt = 0;
  let silverWt = 0;
  let silverAmt = 0;
  for (const row of rows) {
    if (String(row.itType ?? '') === 'G') {
      goldWt = round(goldWt + Number(row.netWt ?? 0), 3);
      goldAmt = round(goldAmt + Number(row.amount ?? 0), 2);
    } else {
      silverWt = round(silverWt + Number(row.netWt ?? 0), 3);
      silverAmt = round(silverAmt + Number(row.amount ?? 0), 2);
    }
  }
  return { goldWt, goldAmt, silverWt, silverAmt };
}
