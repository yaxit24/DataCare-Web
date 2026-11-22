import { Prisma } from '@datacare/db';
import { decimalCellText } from '@datacare/core';

const Decimal = Prisma.Decimal;
type Decimal = Prisma.Decimal;

/**
 * Balance TrFr (desktop BtmSchm, menu Company → Balance TrFr): the pure rules, so each is unit-tested on its own.
 *
 * Every figure is computed in exact decimals from the database's NUMERIC text and rounded half away from zero, which
 * is what the desktop's `format(..., '0.00' / '0.000')` and `Strings.Format` do (`@datacare/core` `decimalCellText`,
 * ROUND_HALF_UP in decimal.js rounds a tie away from zero). Never through binary floats: 10.005 is 1000.4999… × 0.01
 * as a double and would round down.
 */

export type CrDr = 'C' | 'D';

/** Exact decimal of a NUMERIC text (or a number) from the database; NULL and blank are 0 (DC_Main.Fnv). */
export function dec(value: unknown): Decimal {
  if (value === null || value === undefined) return new Decimal(0);
  if (typeof value === 'number') return new Decimal(Number.isFinite(value) ? value : 0);
  const text = String(value).trim();
  if (text === '') return new Decimal(0);
  try {
    const d = new Decimal(text);
    return d.isFinite() ? d : new Decimal(0);
  } catch {
    return new Decimal(0);
  }
}

/** `format(x, '0.00')` / `'0.000'` read back with `Conversion.Val`: the rounded value as a number. */
export function vbFormat(value: unknown, places: number): number {
  return Number(decimalCellText(dec(value), places));
}

/** The six heads of one carried opening, as OP_DATA stores them (BtmSchm.cs:2801). */
export interface AcOpeningHeads {
  amount: number;
  sign: CrDr;
  gold: number;
  goldSign: CrDr;
  silver: number;
  silverSign: CrDr;
}

/** One (account, DATA_TYPE) group of Rtl_AcOpbl's query: the raw grouped sums, Cr-positive. */
export interface AcClosingSums {
  /** Σ(CR_AMT − DR_AMT). */
  money: unknown;
  /** Σ FINE_WT of IT_TYPE 'G' legs, '+' adds and any other sign subtracts. */
  gold: unknown;
  /** The same for IT_TYPE 'S'. */
  silver: unknown;
}

/**
 * Rtl_AcOpbl's row rule (BtmSchm.cs:2786-2801): each grouped sum is formatted to 0.00 / 0.000 (rounded after grouping,
 * never per voucher); the row is skipped when |amount| + |gold| + |silver| is 0; the written value is the magnitude, and
 * its sign is 'C' only when the formatted value is above 0, so a zero head is 'D'.
 *
 * The desktop's HAVING also drops a group whose money, gold, silver and diamond fine add up to exactly 0 although each
 * is not (50.00 Cr and 50.000 gold Dr). That loses two real balances and breaks closing = opening, so the web carries
 * such a party (Q2, decided 2026-11-22 by the architect, owner may override: a deliberate difference).
 */
export function acOpeningHeads(sums: AcClosingSums): AcOpeningHeads | null {
  const amount = new Decimal(decimalCellText(dec(sums.money), 2));
  const gold = new Decimal(decimalCellText(dec(sums.gold), 3));
  const silver = new Decimal(decimalCellText(dec(sums.silver), 3));
  if (amount.abs().plus(gold.abs()).plus(silver.abs()).isZero()) return null;
  const side = (d: Decimal): CrDr => (d.greaterThan(0) ? 'C' : 'D');
  return {
    amount: amount.abs().toNumber(),
    sign: side(amount),
    gold: gold.abs().toNumber(),
    goldSign: side(gold),
    silver: silver.abs().toNumber(),
    silverSign: side(silver),
  };
}

/** One item group of BtnItmStk's query (BtmSchm.cs:2933): signed sums of untagged MAIN_STOCK to the closing date. */
export interface ItemClosingSums {
  itCode: string;
  itType: string | null;
  /** Σ ±ITM_PCS. */
  pcs: unknown;
  /** Σ ±ITM_GWT. */
  gross: unknown;
  /** Σ ±ITM_NWT. */
  net: unknown;
  /** Σ ±(ITM_PCS × ITEM_MAST.ITEM_RATE). */
  amount: unknown;
  /** ITEM_MAST.AVG_TOUCH. */
  touch: unknown;
}

/** The figures BtnItmStk writes into one ITM_OPBL row (BtmSchm.cs:2966-2994). */
export interface ItemOpeningFigures {
  pcs: number;
  gross: number;
  net: number;
  touch: number;
  fine: number;
  amount: number;
}

/**
 * BtnItmStk's row rule (BtmSchm.cs:2945-2994): fine = Format(net × touch / 100, "0.000") only when the net weight and
 * the touch are both non-zero (:2950-2961); pieces Format "0", gross and net Format "0.000"; the amount goes in as the
 * signed sum (ITM_AMT and NET_AMT, :2985-2994) at the column's two places.
 *
 * Skip: the desktop skips when gross + net + pcs adds to 0 (:2964). That sum is signed, so 5 pcs with −2.500 gross and
 * −2.500 net is skipped and a stock position is lost (weakness 5). The web skips only an item whose pieces, gross and
 * net are each 0 (Q3, decided 2026-11-22 by the architect, owner may override: a deliberate difference).
 */
export function itemOpeningFigures(sums: ItemClosingSums): ItemOpeningFigures | null {
  const pcs = dec(sums.pcs);
  const gross = dec(sums.gross);
  const net = dec(sums.net);
  if (pcs.isZero() && gross.isZero() && net.isZero()) return null;
  const touch = dec(sums.touch);
  const fine = !net.isZero() && !touch.isZero() ? vbFormat(net.times(touch).dividedBy(100), 3) : 0;
  return {
    pcs: vbFormat(pcs, 0),
    gross: vbFormat(gross, 3),
    net: vbFormat(net, 3),
    touch: touch.toNumber(),
    fine,
    amount: vbFormat(sums.amount, 2),
  };
}

/** One YEAR_MAST row as the form reads it. */
export interface YearRow {
  coYear: string;
  opDate: string | null;
  clDate: string | null;
}

/**
 * The Transfer Year (BtmSchm.cs:2085-2105): the first YEAR_MAST year after the current one, ordered by CO_YEAR
 * (`AND CO_YEAR > MCo_year ORDER BY CO_YEAR`), with its opening date. Null when there is none, which is when the form
 * says "There Are Not Found New Year Please Creat New Year And Try....".
 */
export function nextYearOf(years: YearRow[], fromYear: string): YearRow | null {
  const later = years
    .filter((y) => y.coYear > fromYear)
    .sort((a, b) => (a.coYear < b.coYear ? -1 : a.coYear > b.coYear ? 1 : 0));
  return later[0] ?? null;
}

/** The day before a year opens (`mTrfr_dt.AddDays(-1.0)`, BtmSchm.cs:2378), as an ISO date. */
export function dayBefore(isoDate: string): string {
  const d = new Date(`${isoDate.slice(0, 10)}T00:00:00.000Z`);
  d.setUTCDate(d.getUTCDate() - 1);
  return d.toISOString().slice(0, 10);
}
