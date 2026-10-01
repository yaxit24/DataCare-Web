import { round } from '@datacare/core';
import { withTenant } from '@datacare/db';
import type { ListReport, ReportScope } from './reports.js';

export type TradingMode = 'all' | 'only-ratecut' | 'without-ratecut';

const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
// Report display rounding (N57 keeps numerics exact until output); desktop presents half-up, so kernel
// `round` is correct here, not a float helper (N48, G22).
const round2 = (n: number): number => round(n, 2);
const round3 = (n: number): number => round(n, 3);
const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const isoDate = (v: unknown): string | null => {
  if (!v) return null;
  const d = v instanceof Date ? v : new Date(String(v));
  return Number.isFinite(d.getTime()) ? d.toISOString().slice(0, 10) : null;
};
const today = (): string => new Date().toISOString().slice(0, 10);
const modeFrom = (v: unknown): TradingMode => {
  const s = String(v ?? '').trim();
  if (s === 'only-ratecut') return 'only-ratecut';
  if (s === 'without-ratecut') return 'without-ratecut';
  return 'all';
};
const cleanCodes = (value: unknown): string[] =>
  String(value ?? '')
    .split(',')
    .map((v) => v.trim())
    .filter(Boolean)
    .map((v) => v.slice(0, 8));
const rate = (amount: number, fine: number): number => (amount && fine ? round2(amount / fine) : 0);
const keyOf = (row: Record<string, unknown>): string =>
  `${txt(row.coBook) ?? ''}|${txt(row.vchNo) ?? ''}`;
const fineKey = (row: Record<string, unknown>, sign: string): string => `${keyOf(row)}|${sign}`;

function dateBounds(s: ReportScope): { fromDate: string; toDate: string } {
  const fallback = s.toDate ?? s.fromDate ?? today();
  return { fromDate: s.fromDate ?? fallback, toDate: s.toDate ?? fallback };
}

function pushBookFilter(bookCodes: string[], params: unknown[], alias = 'a'): string {
  if (!bookCodes.length) return '';
  const refs = bookCodes.map((book) => {
    params.push(book);
    return `$${params.length}`;
  });
  return ` AND ${alias}."CO_BOOK" IN (${refs.join(',')})`;
}

/**
 * Trading Report — desktop `RP_TRADING`.
 *
 * Desktop modes:
 *   All            -> AC_DATA rows for sales/purchase accounts with nonzero amount.
 *   Only RateCut   -> fine-rate rows on WH SALES/RATE CUT, using LD_CODE and swapped Dr/Cr columns.
 *   Whout RateCut  -> AC_DATA rows for sales/purchase accounts where FINE_RATE = 0.
 *
 * The grid shows sale-side and purchase-side columns in one row. Fine weight comes first from the rate-cut
 * voucher (`AC_DATA.SIGN` +/-) and falls back to stock fine (`MAIN_STOCK.ITM_SIGN` - for sales, + for purchase).
 */
export async function tradingReport(
  prisma: any,
  s: ReportScope,
  options: { mode?: unknown; salesAc?: unknown; purchaseAc?: unknown; bookCodes?: unknown } = {},
): Promise<ListReport> {
  const mode = modeFrom(options.mode);
  const salesAc = String(options.salesAc ?? '00003').trim();
  const purchaseAc = String(options.purchaseAc ?? '00008').trim();
  const bookCodes = cleanCodes(options.bookCodes ?? s.filters?.bookCode);
  const { fromDate, toDate } = dateBounds(s);

  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const stockParams: unknown[] = [
      s.coCode,
      s.lcCode ?? '',
      fromDate,
      toDate,
      salesAc,
      purchaseAc,
    ];
    const stockBookFilter = pushBookFilter(bookCodes, stockParams, 'a');
    const stockFineRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."CO_BOOK" AS "coBook", a."VCH_NO" AS "vchNo", a."ITM_SIGN" AS "sign",
              SUM(coalesce(a."ITM_FINE",0)) AS "fine"
         FROM "MAIN_STOCK" a
         LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=a.tenant_id
          AND i."CO_CODE"=a."CO_CODE"
          AND i."IT_CODE"::text=a."IT_CODE"::text
         LEFT JOIN "GROUP_MAST" g
           ON g.tenant_id=i.tenant_id
          AND g."CO_CODE"=i."CO_CODE"
          AND g."GR_CODE"=i."GR_CODE"
        WHERE a."CO_CODE"=$1
          AND a."LC_CODE"=$2
          AND a."VCH_DATE" >= $3::date
          AND a."VCH_DATE" <= $4::date
          AND (g."SALE_AC"=$5 OR g."PURC_AC"=$6)${stockBookFilter}
        GROUP BY a."CO_BOOK", a."VCH_NO", a."ITM_SIGN"`,
      ...stockParams,
    );
    const stockFine = new Map(
      stockFineRows.map((row) => [
        fineKey(row, String(row.sign ?? '').trim()),
        round3(num(row.fine)),
      ]),
    );

    const rateParams: unknown[] = [s.coCode, s.lcCode ?? '', fromDate, toDate];
    const rateBookFilter = pushBookFilter(bookCodes, rateParams, 'a');
    const rateCutRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."CO_BOOK" AS "coBook", a."VCH_NO" AS "vchNo", a."SIGN" AS "sign",
              SUM(coalesce(a."FINE_WT",0)) AS "fine"
         FROM "AC_DATA" a
        WHERE a."CO_CODE"=$1
          AND a."LC_CODE"=$2
          AND coalesce(a."CR_AMT",0) + coalesce(a."DR_AMT",0) <> 0
          AND coalesce(a."FINE_WT",0) <> 0
          AND a."VCH_DATE" >= $3::date
          AND a."VCH_DATE" <= $4::date${rateBookFilter}
        GROUP BY a."CO_BOOK", a."VCH_NO", a."SIGN"
       HAVING SUM(coalesce(a."FINE_WT",0)) <> 0`,
      ...rateParams,
    );
    const rateCutFine = new Map(
      rateCutRows.map((row) => [
        fineKey(row, String(row.sign ?? '').trim()),
        round3(num(row.fine)),
      ]),
    );

    const partyParams: unknown[] = [s.coCode, s.lcCode ?? '', fromDate, toDate];
    const partyBookFilter1 = pushBookFilter(bookCodes, partyParams, 'a');
    const partyOffset = partyParams.length;
    partyParams.push(s.coCode, s.lcCode ?? '', fromDate, toDate);
    const partyBookFilter2 = bookCodes.length
      ? ` AND c."CO_BOOK" IN (${bookCodes
          .map((book) => {
            partyParams.push(book);
            return `$${partyParams.length}`;
          })
          .join(',')})`
      : '';
    const partyRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT x."coBook", x."vchNo", MIN(x."party") AS "party"
         FROM (
               SELECT a."CO_BOOK" AS "coBook", a."VCH_NO" AS "vchNo", m."AC_NAME" AS "party"
                 FROM "MAIN_STOCK" a
                 LEFT JOIN "AC_MAST" m
                   ON m.tenant_id=a.tenant_id
                  AND m."CO_CODE"=a."CO_CODE"
                  AND m."AC_CODE"::text=a."AC_CODE"::text
                WHERE a."CO_CODE"=$1
                  AND a."LC_CODE"=$2
                  AND a."VCH_DATE" >= $3::date
                  AND a."VCH_DATE" <= $4::date${partyBookFilter1}
               UNION ALL
               SELECT c."CO_BOOK" AS "coBook", c."VCH_NO" AS "vchNo", m."AC_NAME" AS "party"
                 FROM "AC_DATA" c
                 LEFT JOIN "AC_MAST" m
                   ON m.tenant_id=c.tenant_id
                  AND m."CO_CODE"=c."CO_CODE"
                  AND m."AC_CODE"::text=c."PARTY_AC_CODE"::text
                WHERE c."CO_CODE"=$${partyOffset + 1}
                  AND c."LC_CODE"=$${partyOffset + 2}
                  AND c."VCH_DATE" >= $${partyOffset + 3}::date
                  AND c."VCH_DATE" <= $${partyOffset + 4}::date
                  AND coalesce(c."PARTY_AC_CODE",'') <> ''${partyBookFilter2}
              ) x
        WHERE coalesce(x."party",'') <> ''
        GROUP BY x."coBook", x."vchNo"`,
      ...partyParams,
    );
    const partyName = new Map(partyRows.map((row) => [keyOf(row), txt(row.party)]));

    const mainParams: unknown[] = [
      s.coCode,
      s.lcCode ?? '',
      s.coYear ?? '',
      salesAc,
      purchaseAc,
      fromDate,
      toDate,
    ];
    const mainBookFilter = pushBookFilter(bookCodes, mainParams, 'a');
    const modeSql =
      mode === 'only-ratecut'
        ? {
            amountSelect:
              'SUM(coalesce(a."DR_AMT",0)) AS "crAmt", SUM(coalesce(a."CR_AMT",0)) AS "drAmt"',
            filter: `AND coalesce(a."FINE_RATE",0) <> 0 AND a."LD_CODE" IN ($4,$5) AND b."MAIN_BOOK" IN ('WH SALES','RATE CUT')`,
            order: 'a."VCH_DATE", a."VCH_TYPE", a."CO_BOOK", a."VCH_NO"',
          }
        : mode === 'without-ratecut'
          ? {
              amountSelect:
                'SUM(coalesce(a."CR_AMT",0)) AS "crAmt", SUM(coalesce(a."DR_AMT",0)) AS "drAmt"',
              filter: `AND coalesce(a."FINE_RATE",0) = 0 AND a."AC_CODE" IN ($4,$5)`,
              order:
                'a."VCH_DATE", SUM(coalesce(a."CR_AMT",0)), a."VCH_TYPE", a."CO_BOOK", a."VCH_NO"',
            }
          : {
              amountSelect:
                'SUM(coalesce(a."CR_AMT",0)) AS "crAmt", SUM(coalesce(a."DR_AMT",0)) AS "drAmt"',
              filter: `AND coalesce(a."CR_AMT",0) + coalesce(a."DR_AMT",0) <> 0 AND a."AC_CODE" IN ($4,$5)`,
              order:
                'a."VCH_DATE", SUM(coalesce(a."DR_AMT",0)), a."VCH_TYPE", a."CO_BOOK", a."VCH_NO"',
            };
    const mainRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."VCH_TYPE" AS "vchType", a."CO_BOOK" AS "coBook", b."MAIN_BOOK" AS "bookName",
              a."VCH_NO" AS "vchNo", a."VCH_DATE" AS "vchDate", ${modeSql.amountSelect}
         FROM "AC_DATA" a
         LEFT JOIN "BOOK_DATA" b
           ON b.tenant_id=a.tenant_id
          AND b."CO_CODE"=a."CO_CODE"
          AND b."LC_CODE"=a."LC_CODE"
          AND b."CO_BOOK"=a."CO_BOOK"
        WHERE a."CO_CODE"=$1
          AND a."LC_CODE"=$2
          AND a."CO_YEAR"=$3
          ${modeSql.filter}
          AND a."VCH_DATE" >= $6::date
          AND a."VCH_DATE" <= $7::date${mainBookFilter}
        GROUP BY a."VCH_TYPE", a."CO_BOOK", b."MAIN_BOOK", a."VCH_NO", a."VCH_DATE"
        ORDER BY ${modeSql.order}`,
      ...mainParams,
    );

    const mapped = mainRows.map((row, index) => {
      const baseKey = keyOf(row);
      const saleAmt = round2(num(row.crAmt));
      const purchaseAmt = round2(num(row.drAmt));
      const saleFine = saleAmt
        ? round3(rateCutFine.get(`${baseKey}|+`) ?? stockFine.get(`${baseKey}|-`) ?? 0)
        : 0;
      const purchaseFine = purchaseAmt
        ? round3(rateCutFine.get(`${baseKey}|-`) ?? stockFine.get(`${baseKey}|+`) ?? 0)
        : 0;
      const party = partyName.get(baseKey) ?? null;
      return {
        srNo: index + 1,
        vchDate: isoDate(row.vchDate),
        slBook: saleAmt ? txt(row.vchType) : null,
        slBookCode: saleAmt ? txt(row.coBook) : null,
        slBookName: saleAmt ? txt(row.bookName) : null,
        slVchNo: saleAmt ? txt(row.vchNo) : null,
        slPartyName: saleAmt ? party : null,
        slWt: saleFine,
        slRate: rate(saleAmt, saleFine),
        slAmt: saleAmt,
        prBook: purchaseAmt ? txt(row.vchType) : null,
        prBookCode: purchaseAmt ? txt(row.coBook) : null,
        prBookName: purchaseAmt ? txt(row.bookName) : null,
        prVchNo: purchaseAmt ? txt(row.vchNo) : null,
        prPartyName: purchaseAmt ? party : null,
        prWt: purchaseFine,
        prRate: rate(purchaseAmt, purchaseFine),
        prAmt: purchaseAmt,
      };
    });
    const slWt = round3(mapped.reduce((sum, row) => sum + row.slWt, 0));
    const prWt = round3(mapped.reduce((sum, row) => sum + row.prWt, 0));
    const slAmt = round2(mapped.reduce((sum, row) => sum + row.slAmt, 0));
    const prAmt = round2(mapped.reduce((sum, row) => sum + row.prAmt, 0));
    const diffFine = round3(prWt - slWt);
    const diffAmount = round2(prAmt - slAmt);
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        slWt,
        slAmt,
        prWt,
        prAmt,
        slRate: rate(slAmt, slWt),
        prRate: rate(prAmt, prWt),
        diffFine,
        diffAmount,
      },
    };
  });
}
