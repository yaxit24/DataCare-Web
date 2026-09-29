import { round, roundHalfEven } from './money.js';

/**
 * Money/metal settlement — the desktop's `BILL_TOTAL` conversion block.
 *
 * A jewellery voucher settles in TWO currencies at once: rupees and fine metal. The operator fills in
 * whichever side they know and the form derives the rest. That fill-in-the-blank behaviour is missing from
 * the web's tour sale, wholesale sale, bullion sale and labour sale, so a party balance cannot be closed in
 * rupees and gold together.
 *
 * Source: `TR_TOUR_SALE.cs:12999-13130`. The same block appears in `TR_WH_SALE.cs:15372-15419` and
 * `TR_BUL_SALE.cs:10518-10565`, which is why this is one engine rather than four copies.
 *
 * THE RULES, IN THE DESKTOP'S OWN ORDER
 * -------------------------------------
 *  1. explicit rate:   convRate and convPct both set -> `Math.Round(convRate / convPct * 100, 2)`
 *                      convRate alone                -> convRate
 *  2. rate from money+metal, ONLY when the rate is still zero:
 *                      drAmt & crFine -> `drAmt * F / crFine`   (3 dp)
 *                      crAmt & drFine -> `crAmt * F / drFine`   (3 dp)
 *  3. money from metal, ONLY when that money field is still zero:
 *                      drAmt = `Math.Round(crFine * (rate / F), 0)`
 *                      crAmt = `Math.Round(drFine * (rate / F), 0)`
 *  4. metal from money, ONLY when that metal field is still zero:
 *                      crFine = `drAmt * F / rate`   (3 dp)
 *                      drFine = `crAmt * F / rate`   (3 dp)
 *
 * `F` is the rate basis from `MsRatePar` (`CO_SET.RATE_PAR`, `MS_OPNCOMP.cs:672`, default `G`):
 * `T` = per 10 g -> 10, `K` = per kg -> 1000, anything else -> 1. Note the direction: deriving money
 * DIVIDES the rate by F, deriving metal MULTIPLIES the amount by F.
 *
 * ROUNDING IS NOT UNIFORM, and the difference is load-bearing:
 *  * the explicit rate uses `Math.Round(x, 2)` — .NET default, so BANKER'S rounding;
 *  * money uses `Math.Round(x, 0)` — banker's, to whole rupees;
 *  * every rate back-calculation and every fine figure uses `Strings.Format(x, "0.000")`, which is
 *    half-away-from-zero at three decimals and applies NO `Math.Round`.
 * Using one rounding mode throughout would disagree with the desktop on exact midpoints.
 *
 * "Only when still zero" is the crux: an operator-entered figure is never overwritten. Every derivation is
 * guarded, exactly as the desktop guards it.
 */

export type RateBasis = 'G' | 'T' | 'K';

export interface SettlementInput {
  /** `nConvRate` — conversion rate, e.g. a per-10-gram metal rate. */
  convRate?: number;
  /** `nConvPrc` — conversion percentage (purity), e.g. 91.6. */
  convPct?: number;
  /** `nFineRate` — supplied directly; when non-zero it wins over every derivation. */
  fineRate?: number;
  /** `nAcDrAmt` / `nAcCrAmt` — money legs. */
  drAmt?: number;
  crAmt?: number;
  /** `nAcDrFine` / `nAcCrFine` — metal legs, in fine grams. */
  drFine?: number;
  crFine?: number;
  /** `MsRatePar` from `CO_SET.RATE_PAR`. Loaded server-side; never accepted from a request body. */
  ratePar?: RateBasis | string;
}

export interface SettlementResult {
  fineRate: number;
  drAmt: number;
  crAmt: number;
  drFine: number;
  crFine: number;
  /** Which fields the engine derived, so a UI can show them as computed rather than typed. */
  derived: string[];
}

/** `T` = rate per 10 g, `K` = rate per kg, anything else = per gram. */
export function rateFactor(ratePar?: RateBasis | string): number {
  const p = String(ratePar ?? 'G')
    .trim()
    .toUpperCase()
    .slice(0, 1);
  if (p === 'T') return 10;
  if (p === 'K') return 1000;
  return 1;
}

const n = (v: unknown): number => {
  const x = Number(v ?? 0);
  return Number.isFinite(x) ? x : 0;
};

export function settleMoneyMetal(input: SettlementInput): SettlementResult {
  const F = rateFactor(input.ratePar);
  let fineRate = n(input.fineRate);
  let drAmt = n(input.drAmt);
  let crAmt = n(input.crAmt);
  let drFine = n(input.drFine);
  let crFine = n(input.crFine);
  const derived: string[] = [];

  const convRate = n(input.convRate);
  const convPct = n(input.convPct);

  // 1. Explicit conversion (TR_TOUR_SALE.cs:12999-13006). Math.Round -> banker's rounding at 2 dp.
  if (fineRate === 0) {
    if (convRate !== 0 && convPct !== 0) {
      fineRate = roundHalfEven((convRate / convPct) * 100, 2);
      derived.push('fineRate');
    } else if (convRate !== 0) {
      fineRate = roundHalfEven(convRate, 2);
      derived.push('fineRate');
    }
  }

  // 2. Rate back-calculated from a money/metal pair (:13007-13047). Format "0.000" -> half-up at 3 dp.
  if (fineRate === 0 && drAmt !== 0 && crFine !== 0) {
    fineRate = round((drAmt * F) / crFine, 3);
    derived.push('fineRate');
  }
  if (fineRate === 0 && crAmt !== 0 && drFine !== 0) {
    fineRate = round((crAmt * F) / drFine, 3);
    derived.push('fineRate');
  }

  // 3. Money from metal (:13049-13089). Math.Round(x, 0) -> banker's, whole rupees. The rate is DIVIDED
  //    by the basis: a per-10-gram rate applied to grams must be scaled down.
  if (fineRate !== 0 && crFine !== 0 && drAmt === 0) {
    drAmt = roundHalfEven(crFine * (fineRate / F), 0);
    derived.push('drAmt');
  }
  if (fineRate !== 0 && drFine !== 0 && crAmt === 0) {
    crAmt = roundHalfEven(drFine * (fineRate / F), 0);
    derived.push('crAmt');
  }

  // 4. Metal from money (:13091-13131). The amount is MULTIPLIED by the basis — the inverse of step 3.
  if (fineRate !== 0 && drAmt !== 0 && crFine === 0) {
    crFine = round((drAmt * F) / fineRate, 3);
    derived.push('crFine');
  }
  if (fineRate !== 0 && crAmt !== 0 && drFine === 0) {
    drFine = round((crAmt * F) / fineRate, 3);
    derived.push('drFine');
  }

  return { fineRate, drAmt, crAmt, drFine, crFine, derived };
}

/**
 * Net settlement position after conversion: what the party still owes, in money and in metal.
 *
 * Reported separately rather than netted into one figure, because a jeweller settles the two sides
 * independently — a customer can owe rupees while the shop owes them gold.
 */
export function settlementBalance(r: SettlementResult): {
  amountDue: number;
  fineDue: number;
} {
  return {
    amountDue: roundHalfEven(r.drAmt - r.crAmt, 2),
    fineDue: round(r.drFine - r.crFine, 3),
  };
}
