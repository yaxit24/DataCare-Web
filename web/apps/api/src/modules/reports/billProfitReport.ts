import { withTenant } from '@datacare/db';
import { PRECISION, round } from '@datacare/core';
import { lineProfit, todaySaleRateTx, type ProfitBasis } from '../sales/billProfit.js';

/**
 * Bill profit report (desktop `RP_BILL_PROFIT`).
 *
 * WHY IT MATTERS THAT THIS READS THE TAG
 * The desktop's query joins `MAIN_STOCK` to `BAR_DETL` and takes `KR_NET_WT`, `KR_FINE`, `KR_LBR_AMT`,
 * `KR_OTH_AMT` and `KR_COST` from the TAG, not from the sale line — the tag carries the karigar cost
 * basis, and profit is realisation minus that basis. This report is therefore the consumer that makes
 * the karigar cost columns matter: while `karigar.ts` wrote none of them, every karigar-made tag
 * reported its cost as ZERO here, which reads as pure profit.
 *
 * THE PROFIT FORMULA IS NOT REIMPLEMENTED. `sales/billProfit.ts` already carries the desktop's
 * four-branch rule, derived and tested previously, and this report calls `lineProfit` directly:
 *   1. MRP-priced   — the tag's own TAG_COST is authoritative
 *   2. karigar-fine — cost = KR_FINE x today's sale rate + TAG_COST (needs BOTH a fine and a tag no)
 *   3. average-touch— fine derived from ITEM_MAST.AVG_TOUCH when there is no karigar fine
 *   4. none         — shown as nothing rather than as zero cost, so an unknown cost is never read as
 *                     pure profit
 * A second copy of that logic here would eventually disagree with what the sale screen shows.
 *
 * SCOPE: sale transactions on TAGGED pieces only, matching the desktop's own WHERE clause. Untagged
 * lines and non-sale OUT movements are excluded deliberately — including them made tag generation look
 * like a loss.
 *
 * Read-only and RLS-scoped.
 */
export interface BillProfitRow {
  vchType: string | null;
  vchNo: string | null;
  vchDate: string | null;
  acName: string | null;
  tagNo: string | null;
  itCode: string | null;
  itName: string | null;
  itType: string | null;
  book: string | null;
  bookName: string | null;
  tagId: number;
  pcs: number;
  grossWt: number;
  netWt: number;
  fine: number;
  /** The tag's karigar basis, straight from BAR_DETL. */
  karigarNetWt: number;
  karigarFine: number;
  karigarLabourAmount: number;
  karigarOtherAmount: number;
  karigarCost: number;
  /** Realisation on the line. */
  itemAmount: number;
  labourAmount: number;
  otherAmount: number;
  mrp: number;
  /** From `lineProfit` — which branch decided the cost, and the result. */
  basis: ProfitBasis;
  cost: number;
  profit: number;
}

export interface BillProfitReport {
  rows: BillProfitRow[];
  totals: {
    count: number;
    realisation: number;
    cost: number;
    profit: number;
    /** How many rows fell to the 'none' branch — an unknown cost, NOT a zero cost. */
    unknownCost: number;
  };
  byBasis: Record<ProfitBasis, { count: number; profit: number }>;
}

const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s === '' ? null : s;
};
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
const w3 = (n: number): number => round(n, PRECISION.weight);
const a2 = (n: number): number => round(n, PRECISION.amount);

export async function billProfitReport(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  options: { from?: string; to?: string; book?: string } = {},
): Promise<BillProfitReport> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    /**
     * The desktop's filter is THREE conditions, not one:
     *   `A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.TAG_NO <> 'N'`   (RP_BILL_PROFIT.cs)
     *
     * My first version used only the sign, and the live output showed why that is wrong: TAG-GENERATION
     * movements (VCH_TYPE 'TGEN') are OUT movements with no realisation, so they appeared with a large
     * NEGATIVE profit and dragged the total down, and untagged lines (TAG_NO 'N') appeared with a cost
     * derived from average touch alone. `TR_TYPE = 'S'` restricts this to sale transactions and
     * `TAG_NO <> 'N'` to tagged pieces, which is what a bill-wise profit report is about.
     */
    const filters = [
      'a."CO_CODE"::text=$1',
      'a."LC_CODE"::text=$2',
      `a."ITM_SIGN"::text='-'`,
      `a."TR_TYPE"::text='S'`,
      `coalesce(a."TAG_NO"::text,'N') <> 'N'`,
    ];
    if (options.book) {
      params.push(options.book);
      filters.push(`a."CO_BOOK"::text=$${params.length}`);
    }
    if (options.from) {
      params.push(options.from);
      filters.push(`a."VCH_DATE" >= $${params.length}::date`);
    }
    if (options.to) {
      params.push(options.to);
      filters.push(`a."VCH_DATE" <= $${params.length}::date`);
    }

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."VCH_TYPE",a."VCH_NO",a."VCH_DATE"::text AS "VCH_DATE",a."TAG_NO",a."IT_CODE",
              a."ITM_PCS",a."ITM_GWT",a."ITM_NWT",a."ITM_FINE",a."ITM_AMT",a."LBR_AMT",a."OTH_AMT",
              a."ITM_MRP",a."NET_AMT",a."CO_BOOK",a."BOOK_NAME",a."VCH_SRNO",a."AC_CODE",
              b."KR_NET_WT",b."KR_FINE",b."KR_LBR_AMT",b."KR_OTH_AMT",b."KR_COST",b."TAG_COST",
              c."IT_NAME",c."IT_TYPE",c."AVG_TOUCH",d."AC_NAME"
         FROM "MAIN_STOCK" a
         LEFT JOIN "BAR_DETL" b
           ON b."CO_CODE"::text=a."CO_CODE"::text AND b."LC_CODE"::text=a."LC_CODE"::text
          AND b."TAG_NO"::text=a."TAG_NO"::text
          AND coalesce(b."VCH_SRNO",0)=coalesce(a."VCH_SRNO",0)
         LEFT JOIN "ITEM_MAST" c
           ON c."CO_CODE"::text=a."CO_CODE"::text AND c."IT_CODE"::text=a."IT_CODE"::text
         LEFT JOIN "AC_MAST" d
           ON d."CO_CODE"::text=a."CO_CODE"::text AND d."AC_CODE"::text=a."AC_CODE"::text
        WHERE ${filters.join(' AND ')}
        ORDER BY a."VCH_DATE", a."VCH_NO", a."TAG_NO"`,
      ...params,
    );

    // One rate for the report window. The desktop's ToDaySlRate is a single day's rate, so the window's
    // end (or today) is used rather than re-reading a rate per row, which would be a different measure.
    const saleRate = await todaySaleRateTx(
      tx,
      { coCode: scope.CO_CODE, lcCode: scope.LC_CODE },
      options.to ?? new Date(),
    );

    const mapped: BillProfitRow[] = rows.map((r) => {
      const profit = lineProfit(
        {
          tagNo: txt(r.TAG_NO) ?? undefined,
          itmMrp: num(r.ITM_MRP),
          tagCost: num(r.TAG_COST),
          krFine: num(r.KR_FINE),
          netWt: num(r.ITM_NWT),
          totAmt: num(r.ITM_AMT) + num(r.LBR_AMT) + num(r.OTH_AMT),
          netAmt: num(r.NET_AMT),
          avgTouch: num(r.AVG_TOUCH),
        },
        saleRate,
      );
      return {
        vchType: txt(r.VCH_TYPE),
        vchNo: txt(r.VCH_NO),
        vchDate: txt(r.VCH_DATE)?.slice(0, 10) ?? null,
        acName: txt(r.AC_NAME),
        tagNo: txt(r.TAG_NO),
        itCode: txt(r.IT_CODE),
        itName: txt(r.IT_NAME),
        itType: txt(r.IT_TYPE),
        book: txt(r.CO_BOOK),
        bookName: txt(r.BOOK_NAME),
        tagId: num(r.VCH_SRNO),
        pcs: num(r.ITM_PCS),
        grossWt: w3(num(r.ITM_GWT)),
        netWt: w3(num(r.ITM_NWT)),
        fine: w3(num(r.ITM_FINE)),
        karigarNetWt: w3(num(r.KR_NET_WT)),
        karigarFine: w3(num(r.KR_FINE)),
        karigarLabourAmount: a2(num(r.KR_LBR_AMT)),
        karigarOtherAmount: a2(num(r.KR_OTH_AMT)),
        karigarCost: a2(num(r.KR_COST)),
        itemAmount: a2(num(r.ITM_AMT)),
        labourAmount: a2(num(r.LBR_AMT)),
        otherAmount: a2(num(r.OTH_AMT)),
        mrp: a2(num(r.ITM_MRP)),
        basis: profit.basis,
        cost: profit.cost,
        profit: profit.profit,
      };
    });

    const byBasis = { mrp: 0, 'karigar-fine': 0, 'average-touch': 0, none: 0 } as Record<
      ProfitBasis,
      number
    >;
    const profitByBasis = { ...byBasis };
    for (const r of mapped) {
      byBasis[r.basis] += 1;
      profitByBasis[r.basis] = a2(profitByBasis[r.basis] + r.profit);
    }

    return {
      rows: mapped,
      totals: {
        count: mapped.length,
        realisation: a2(
          mapped.reduce((s, r) => s + r.itemAmount + r.labourAmount + r.otherAmount, 0),
        ),
        cost: a2(mapped.reduce((s, r) => s + r.cost, 0)),
        profit: a2(mapped.reduce((s, r) => s + r.profit, 0)),
        // Surfaced deliberately: a row whose cost could not be established is NOT a zero-cost row, and
        // reporting it silently as full profit is how a bad margin looks like a good one.
        unknownCost: byBasis.none,
      },
      byBasis: Object.fromEntries(
        (Object.keys(byBasis) as ProfitBasis[]).map((k) => [
          k,
          { count: byBasis[k], profit: profitByBasis[k] },
        ]),
      ) as Record<ProfitBasis, { count: number; profit: number }>,
    };
  });
}
