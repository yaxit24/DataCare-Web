import { withTxBudget } from '../shared/txBudget.js';
import type { BalanceTransferScope } from './balanceTransfer.js';

/**
 * Balance TrFr: which tags, orders and approval lines the desktop carries (read-only). In the one-database web these
 * stay open in the next year without a copy (Q1/Q8, decided 2026-11-22 by the architect, owner may override), so the
 * Tag Stock, Sales Order and Approval buttons run these selections and report the counts (confirmImplicitCarry). Each
 * reads the closed year only and writes nothing (the desktop's approval selection first rewrites APR_DETL.ISU_REC and
 * BAR_DETL.APR_ISU in the closed year, BtmSchm.cs:4123-4128; here that is computed).
 */

export interface SelectionScope extends BalanceTransferScope {
  /** Closing date of the year being closed, ISO. */
  clDate: string;
}

const lcOf = (s: BalanceTransferScope) => s.lcCode ?? '01';

export interface TagInStock {
  itCode: string;
  tagNo: string;
  vchSrNo: number;
}

/**
 * Tags in stock at the closing date (BtmSchm.cs:2362): MAIN_STOCK joined to its BAR_DETL instance (company, location,
 * tag, VCH_SRNO, item), year being closed, TAG_NO not 'N', VCH_DATE up to the closing date, kept when
 * Σ(+VCH_SRNO for '+', −VCH_SRNO otherwise) > 0, ordered by item type, item and tag.
 */
export function tagsInStock(prisma: any, scope: SelectionScope): Promise<TagInStock[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a."IT_CODE" it, a."TAG_NO" tag, c."VCH_SRNO"::float srno
         FROM "MAIN_STOCK" a
         JOIN LATERAL (SELECT x."VCH_SRNO" FROM "BAR_DETL" x
                        WHERE x."CO_CODE"=a."CO_CODE" AND x."LC_CODE"=a."LC_CODE" AND x."TAG_NO"=a."TAG_NO"
                          AND x."VCH_SRNO"=a."VCH_SRNO" AND x."IT_CODE"=a."IT_CODE" LIMIT 1) c ON true
         LEFT JOIN "ITEM_MAST" b ON b."CO_CODE"=a."CO_CODE" AND b."IT_CODE"=a."IT_CODE"
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."CO_YEAR"=$3 AND a."TAG_NO" <> 'N'
          AND a."VCH_DATE" <= $4::date
        GROUP BY b."IT_TYPE", a."IT_CODE", a."TAG_NO", c."VCH_SRNO"
       HAVING sum(CASE WHEN a."ITM_SIGN"='+' THEN a."VCH_SRNO" ELSE -a."VCH_SRNO" END) > 0
        ORDER BY b."IT_TYPE", a."IT_CODE", a."TAG_NO"`,
      scope.coCode,
      lcOf(scope),
      scope.coYear,
      scope.clDate,
    );
    return rows.map((r) => ({
      itCode: String(r.it),
      tagNo: String(r.tag),
      vchSrNo: Number(r.srno),
    }));
  });
}

export interface OpenOrder {
  coYear: string;
  coBook: string;
  vchNo: string;
  acCode: string;
  advAmt: number;
  adjAmount: number;
  adjGold: number;
  adjSilver: number;
}

/**
 * Open sales orders at the closing date (BtmSchm.cs:3024): SL_ORD_DATA left-joined to its SL_ORD_ADJ rows (ORD_LC,
 * ORD_YRCD, ORD_DBCD, ORD_NO), order date up to the closing date, kept when the '+' rows less the others, money + gold
 * + silver, is above 0 (an order with no adjustment row sums to NULL and is not kept); ordered by date and number.
 */
export function openOrders(prisma: any, scope: SelectionScope): Promise<OpenOrder[]> {
  const signed = (c: string) => `sum(CASE WHEN b."ORD_SIGN"='+' THEN b."${c}" ELSE -b."${c}" END)`;
  const adj = (c: string) =>
    `coalesce(sum(CASE WHEN b."ORD_SIGN"='-' THEN b."${c}" ELSE 0 END),0)::float`;
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a."CO_YEAR" yr, a."CO_BOOK" book, a."VCH_NO" no, a."AC_CODE" ac, coalesce(a."ADV_AMT",0)::float adv,
              ${adj('ORD_AMT')} amt, ${adj('ORD_GOLD')} gold, ${adj('ORD_SILVER')} silver
         FROM "SL_ORD_DATA" a
         LEFT JOIN "SL_ORD_ADJ" b ON b."CO_CODE"=a."CO_CODE" AND b."ORD_LC"=a."LC_CODE" AND b."ORD_YRCD"=a."CO_YEAR"
                                 AND b."ORD_DBCD"=a."CO_BOOK" AND b."ORD_NO"=a."VCH_NO"
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND a."VCH_DATE" <= $3::date
        GROUP BY a."AC_CODE", a."VCH_DATE", a."VCH_NO", a."ADV_AMT", a."CO_YEAR", a."CO_BOOK", a."HD_VCH_NO"
       HAVING ${signed('ORD_AMT')} + ${signed('ORD_GOLD')} + ${signed('ORD_SILVER')} > 0
        ORDER BY a."VCH_DATE", a."VCH_NO"`,
      scope.coCode,
      lcOf(scope),
      scope.clDate,
    );
    return rows.map((r) => ({
      coYear: String(r.yr),
      coBook: String(r.book),
      vchNo: String(r.no),
      acCode: String(r.ac ?? ''),
      advAmt: Number(r.adv),
      adjAmount: Number(r.amt),
      adjGold: Number(r.gold),
      adjSilver: Number(r.silver),
    }));
  });
}

export interface OpenApprovalLine {
  coYear: string;
  coBook: string;
  vchNo: string;
  srNo: number;
  tagNo: string;
}

/**
 * Approval issue lines still out at the closing date (BtmSchm.cs:4123-4125 and :4142; the desktop's database holds only
 * the closed year, so the web bounds issues and their closing lines by the closing date and the year): lines of a book whose MAIN_BOOK is 'APR ISU' that no
 * APR RTN line (APR_DETL), SALES line (SL_DETL) or WH SALES / RATE CUT issue (RATE_CUT_ISU) names through
 * ISU_YRCD / ISU_DBCD / ISU_NO / ISU_SRNO = the line's CO_YEAR / CO_BOOK / VCH_NO / OLD_SRNO. ISU_REC is computed, not
 * written to the closed year.
 */
export function openApprovalLines(prisma: any, scope: SelectionScope): Promise<OpenApprovalLine[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const closer = (table: string, alias: string, books: string) =>
      `SELECT 1 FROM "${table}" ${alias} WHERE ${alias}."CO_CODE"=a."CO_CODE" AND ${alias}."LC_CODE"=a."LC_CODE"
          AND ${alias}."BOOK_NAME" IN (${books}) AND coalesce(${alias}."ISU_NO",'') <> ''
          AND ${alias}."ISU_YRCD"=a."CO_YEAR" AND ${alias}."ISU_DBCD"=a."CO_BOOK" AND ${alias}."ISU_NO"=a."VCH_NO"
          AND ${alias}."ISU_SRNO"::numeric = NULLIF(a."OLD_SRNO"::text,'')::numeric
          AND ${alias}."VCH_DATE" <= $3::date`;
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT a."CO_YEAR" yr, a."CO_BOOK" book, a."VCH_NO" no, a."SR_NO"::float sr, coalesce(a."TAG_NO",'') tag
         FROM "APR_DETL" a
         JOIN "BOOK_DATA" k ON k."CO_CODE"=a."CO_CODE" AND k."LC_CODE"=a."LC_CODE" AND k."CO_BOOK"=a."CO_BOOK"
        WHERE a."CO_CODE"=$1 AND a."LC_CODE"=$2 AND k."MAIN_BOOK"='APR ISU'
          AND a."CO_YEAR" <= $4 AND a."VCH_DATE" <= $3::date
          AND NOT EXISTS (${closer('APR_DETL', 'r', `'APR RTN'`)})
          AND NOT EXISTS (${closer('SL_DETL', 's', `'SALES'`)})
          AND NOT EXISTS (${closer('RATE_CUT_ISU', 'w', `'WH SALES','RATE CUT'`)})
        ORDER BY a."CO_YEAR", a."CO_BOOK", a."VCH_NO", a."SR_NO"`,
      scope.coCode,
      lcOf(scope),
      scope.clDate,
      scope.coYear,
    );
    return rows.map((r) => ({
      coYear: String(r.yr),
      coBook: String(r.book),
      vchNo: String(r.no),
      srNo: Number(r.sr),
      tagNo: String(r.tag),
    }));
  });
}
