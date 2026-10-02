import { withTxBudget } from '../shared/txBudget.js';
import { dateWhere, type ReportScope } from './reports.js';

/** `Conversion.Val`-equivalent numeric read; the desktop tolerates junk in these columns. */
const num = (v: unknown): number => {
  if (typeof v === 'number') return Number.isFinite(v) ? v : 0;
  const m = /^\s*-?\d*\.?\d*/.exec(String(v ?? ''));
  const n = Number(m?.[0]);
  return Number.isFinite(n) ? n : 0;
};
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;

/**
 * The Rojmel — the jeweller's day book, bound to F11 in the desktop.
 *
 * The existing `dayBook` report reads `AC_DATA` and shows money only. That is not what the desktop's
 * `RP_ROJMEL` shows, and the difference is the point of this report: a jeweller reconciles **metal and
 * money together**, and `AC_DATA` cannot carry weight.
 *
 * ## What the desktop's report actually does
 * `RP_ROJMEL.cs` (5856 lines) has two halves, and it is worth being precise because I first read it too
 * quickly and concluded it never touched `ROJ_MEL_DATA`:
 *
 * 1. A **voucher listing** built from the source tables — `AC_DATA` joined to `BOOK_DATA` filtered to
 *    `MAIN_BOOK IN ('MEMB ENTRY','SALES','SALES ORDER','CASH REC','BANK REC','KARIGAR ISSUE','VP PARCEL',
 *    'BILL REC','CUSTREP RECEIPT','CUSTREP ISSUE','CARD ADJUST')`, unioned with `RATE_CUT_DATA` for
 *    `('WH SALES','RATE CUT','BUL WH SALE','TOUR SALES')` and `SL_DATA` for `'SALES RETURNE'`.
 * 2. **Summary sections** read from `ROJ_MEL_DATA`, six queries, all for a single `VCH_DATE`:
 *      `ITM_FINE <> 0 AND SIGN = '+' AND IT_TYPE = 'G'`   gold fine in
 *      `ITM_FINE <> 0 AND SIGN = '-' AND IT_TYPE = 'G'`   gold fine out
 *      `ITM_FINE <> 0 AND SIGN = '+' AND IT_TYPE = 'S'`   silver fine in
 *      `ITM_FINE <> 0 AND SIGN = '-' AND IT_TYPE = 'S'`   silver fine out
 *      `CR_AMT + DR_AMT <> 0`                             all money movement
 *      `DR_AMT <> 0`                                      debits
 *
 * Note the metal summaries key on **`ITM_FINE`**, not `ITM_GWT`. Measured on the real database, sale and
 * estimate books populate no fine at all (0 of 115 estimate rows, 0 of 79 gold-invoice rows), while the
 * fine-settlement families do: gold purchase 42/55, rate cut 32/32, fine JV 28/28, wholesale sales 24/26,
 * karigar receipt 21/24. So the fine summaries are about unfixed-metal settlement, and a plain tax
 * invoice contributes weight but no fine — which is why this report reports gross and net weight
 * separately from fine rather than folding them together.
 *
 * ## What this implementation covers
 * The `ROJ_MEL_DATA` half, which is the half the web could not produce at all until the day-book
 * projection was written. Every row the web now writes appears here with its metal beside its money.
 *
 * The desktop's per-voucher narration lines — which reach into `CASH_DATA`, `CARD_DATA`, `AD_DATA` +
 * `AD_MEMB` and `KR_DATA` to describe each voucher — are **not** reproduced. They are presentation drawn
 * from tables this report does not read, and inventing them would be inventing content.
 */

export interface RojmelRowOut {
  vchNo: string;
  coBook: string;
  vchType: string | null;
  bookName: string | null;
  acCode: string | null;
  acName: string | null;
  ldCode: string | null;
  /** 'G' gold, 'S' silver, 'O' other metal, 'A' a money row. */
  itType: string | null;
  /** '-' metal out, '+' metal in, blank on money rows. */
  sign: string | null;
  dr: number;
  cr: number;
  pcs: number;
  grossWt: number;
  netWt: number;
  fine: number;
}

export interface RojmelMetalTotals {
  inFine: number;
  outFine: number;
  inGrossWt: number;
  outGrossWt: number;
  netFine: number;
}

export interface Rojmel {
  rows: RojmelRowOut[];
  totals: {
    dr: number;
    cr: number;
    balanced: boolean;
    /** Keyed by metal letter, mirroring the desktop's separate gold and silver summary sections. */
    gold: RojmelMetalTotals;
    silver: RojmelMetalTotals;
    other: RojmelMetalTotals;
  };
}

const EMPTY = (): RojmelMetalTotals => ({
  inFine: 0,
  outFine: 0,
  inGrossWt: 0,
  outGrossWt: 0,
  netFine: 0,
});

/**
 * Build the day book from `ROJ_MEL_DATA`.
 *
 * Metal and money rows come back together and in `LEDR_KEY` order, which is the desktop's own ordering:
 * the key encodes company, location, year, book, voucher, row type and line, so sorting by it groups a
 * voucher's rows and orders them the way the desktop wrote them.
 */
export async function rojmel(prisma: any, s: ReportScope): Promise<Rojmel> {
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.tenantId, s.coCode, s.lcCode, s.coYear];
    const where =
      `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4` +
      dateWhere(s, '"VCH_DATE"', params);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO" AS "vchNo", "CO_BOOK" AS "coBook", "VCH_TYPE" AS "vchType",
              "BOOK_NAME" AS "bookName", "AC_CODE" AS "acCode", "AC_NAME" AS "acName",
              "LD_CODE" AS "ldCode", "IT_TYPE" AS "itType", "SIGN" AS "sign",
              "DR_AMT" AS dr, "CR_AMT" AS cr,
              "ITM_PCS" AS pcs, "ITM_GWT" AS "grossWt",
              "ITM_NWT" AS "netWt", "ITM_FINE" AS fine
         FROM "ROJ_MEL_DATA" WHERE ${where} ORDER BY "LEDR_KEY"`,
      ...params,
    );

    const out: RojmelRowOut[] = rows.map((x) => ({
      vchNo: String(x.vchNo ?? ''),
      coBook: String(x.coBook ?? ''),
      vchType: x.vchType ?? null,
      bookName: x.bookName ?? null,
      acCode: x.acCode ?? null,
      acName: x.acName ?? null,
      ldCode: x.ldCode ?? null,
      itType: x.itType ?? null,
      sign: x.sign ?? null,
      dr: round2(num(x.dr)),
      cr: round2(num(x.cr)),
      pcs: round3(num(x.pcs)),
      grossWt: round3(num(x.grossWt)),
      netWt: round3(num(x.netWt)),
      fine: round3(num(x.fine)),
    }));

    const metal = { G: EMPTY(), S: EMPTY(), O: EMPTY() };
    for (const row of out) {
      const bucket = metal[row.itType as 'G' | 'S' | 'O'];
      if (!bucket) continue; // money rows ('A') and anything unrecognised carry no metal
      // The desktop's summaries key on ITM_FINE and split by SIGN, so this mirrors both.
      if (row.sign === '+') {
        bucket.inFine = round3(bucket.inFine + row.fine);
        bucket.inGrossWt = round3(bucket.inGrossWt + row.grossWt);
      } else if (row.sign === '-') {
        bucket.outFine = round3(bucket.outFine + row.fine);
        bucket.outGrossWt = round3(bucket.outGrossWt + row.grossWt);
      }
    }
    for (const b of Object.values(metal)) b.netFine = round3(b.inFine - b.outFine);

    const dr = round2(out.reduce((t, x) => t + x.dr, 0));
    const cr = round2(out.reduce((t, x) => t + x.cr, 0));
    return {
      rows: out,
      totals: { dr, cr, balanced: dr === cr, gold: metal.G, silver: metal.S, other: metal.O },
    };
  });
}
