import { toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { SIGNED_MONEY, num, txt } from './accountLedgerShared.js';
import {
  buildCashBank,
  type CashBankLine,
  type CashBankRow,
  type CashBankTotals,
} from './cashBankKernel.js';

export type { CashBankRow, CashBankTotals } from './cashBankKernel.js';

/**
 * Cash Bank report (desktop RP_CASH_BANK, one account's cash-and-bank book). Read-only, tenant/RLS scoped.
 * Scope (tenant, company, location, year) always comes from the session, never from the query.
 * Every value is a bound parameter; the desktop's string-built SQL is not ported.
 */
export class CashBankValidationError extends Error {
  constructor(
    message: string,
    readonly code: 'invalid-request' | 'location-required' = 'invalid-request',
  ) {
    super(message);
    this.name = 'CashBankValidationError';
  }
}

export interface CashBankQuery {
  fromDate: string;
  toDate: string;
  acCode: string;
  bookCode: string | undefined;
}

export interface CashBankScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

export interface CashBankResult {
  rows: CashBankRow[];
  totals: CashBankTotals | null;
  account: { acCode: string; acName: string } | null;
  book: { code: string; name: string } | null;
  from: string;
  to: string;
}

export interface CashBankAccountHelp {
  acCode: string;
  acName: string;
  group: string;
  area: string;
  address: string;
  city: string;
}

const ISO = /^\d{4}-\d{2}-\d{2}$/;
const CODE = /^[A-Za-z0-9]{1,8}$/;

function isoDate(label: string, v: unknown): string {
  const s = v == null ? '' : String(v).trim();
  if (!ISO.test(s)) throw new CashBankValidationError(`${label} must be YYYY-MM-DD`);
  try {
    return toIsoDate(s);
  } catch {
    throw new CashBankValidationError(`${label} is not a calendar date`);
  }
}

/** Parse a request, failing closed. From after To is not an error: the desktop has no such check. */
export function parseCashBankQuery(q: Record<string, unknown>): CashBankQuery {
  const acCode = String(q.acCode ?? '').trim();
  if (!CODE.test(acCode))
    throw new CashBankValidationError('acCode is required (1 to 8 letters or digits)');
  const book = String(q.bookCode ?? '').trim();
  if (book !== '' && !CODE.test(book))
    throw new CashBankValidationError('bookCode must be 1 to 8 letters or digits');
  return {
    fromDate: isoDate('fromDate', q.fromDate),
    toDate: isoDate('toDate', q.toDate),
    acCode,
    bookCode: book === '' ? undefined : book,
  };
}

function requireLocation(s: CashBankScope): string {
  if (!s.lcCode) throw new CashBankValidationError('location is required', 'location-required');
  return s.lcCode;
}

/** The company-year predicate is added only when the session has a year (the supervisor decision). */
function yearPredicate(s: CashBankScope, params: unknown[]): string {
  if (!s.coYear) return '';
  params.push(s.coYear);
  return ` AND d."CO_YEAR"=$${params.length}`;
}

export async function cashBankReport(
  prisma: any,
  s: CashBankScope,
  q: CashBankQuery,
): Promise<CashBankResult> {
  const lc = requireLocation(s);
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const acc: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" AS ac_code, "AC_NAME" AS ac_name FROM "AC_MAST" WHERE "CO_CODE"=$1 AND "AC_CODE"=$2 LIMIT 1`,
      s.coCode,
      q.acCode,
    );
    let book: CashBankResult['book'] = null;
    if (q.bookCode) {
      const b: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT "BOOK_NAME" AS name FROM "BOOK_DATA" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_BOOK"=$3 LIMIT 1`,
        s.coCode,
        lc,
        q.bookCode,
      );
      if (b[0]) book = { code: q.bookCode, name: txt(b[0].name) ?? '' };
    }

    // RP_CASH_BANK.cs:3160 {{and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")}}
    // Opening: signed net before From, same account, location, optional book; the company year bounds it.
    const op: unknown[] = [s.coCode, lc, q.acCode, q.fromDate];
    let opSql = `d."CO_CODE"=$1 AND d."LC_CODE"=$2 AND d."AC_CODE"=$3 AND d."VCH_DATE" < $4::date`;
    if (q.bookCode) {
      op.push(q.bookCode);
      opSql += ` AND d."CO_BOOK"=$${op.length}`;
    }
    opSql += yearPredicate(s, op);
    const opening: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${SIGNED_MONEY} AS net FROM "AC_DATA" d WHERE ${opSql}`,
      ...op,
    );

    // RP_CASH_BANK.cs:3162 {{GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.LEDR_KEY,A.LD_CODE}}
    // Detail: From inclusive, To inclusive. Party name sources are joined, never looked up row by row.
    const dp: unknown[] = [s.coCode, lc, q.acCode, q.fromDate, q.toDate];
    let dSql = `d."CO_CODE"=$1 AND d."LC_CODE"=$2 AND d."AC_CODE"=$3 AND d."VCH_DATE" >= $4::date AND d."VCH_DATE" <= $5::date`;
    if (q.bookCode) {
      dp.push(q.bookCode);
      dSql += ` AND d."CO_BOOK"=$${dp.length}`;
    }
    dSql += yearPredicate(s, dp);
    const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT b."BOOK_NAME" AS book_name, d."CO_BOOK" AS co_book, d."VCH_NO" AS vch_no,
              d."VCH_DATE"::text AS vch_date, d."LEDR_KEY" AS ledr_key, d."LD_CODE" AS ld_code,
              ${SIGNED_MONEY} AS net,
              max(b."MAIN_BOOK") AS main_book, max(c."AC_NAME") AS cp_name, max(c."AC_AREA") AS cp_area,
              max(sl.name) AS sl_name, max(pr.name) AS pr_name
         FROM "AC_DATA" d
         JOIN "BOOK_DATA" b ON b."CO_CODE"=d."CO_CODE" AND b."LC_CODE"=d."LC_CODE" AND b."CO_BOOK"=d."CO_BOOK"
         LEFT JOIN "AC_MAST" c ON c."CO_CODE"=d."CO_CODE" AND c."AC_CODE"=d."LD_CODE"
         LEFT JOIN LATERAL (SELECT s2."AC_NAME" AS name FROM "SL_DATA" s2
                             WHERE s2."CO_CODE"=d."CO_CODE" AND s2."LC_CODE"=d."LC_CODE"
                               AND s2."CO_BOOK"=d."CO_BOOK" AND s2."VCH_NO"=d."VCH_NO" LIMIT 1) sl ON true
         LEFT JOIN LATERAL (SELECT p2."AC_NAME" AS name FROM "PR_DATA" p2
                             WHERE p2."CO_CODE"=d."CO_CODE" AND p2."LC_CODE"=d."LC_CODE"
                               AND p2."CO_BOOK"=d."CO_BOOK" AND p2."VCH_NO"=d."VCH_NO" LIMIT 1) pr ON true
        WHERE ${dSql}
        GROUP BY b."BOOK_NAME", d."CO_BOOK", d."VCH_NO", d."VCH_DATE", d."LEDR_KEY", d."LD_CODE"
        ORDER BY d."VCH_DATE", b."BOOK_NAME", d."VCH_NO", d."LEDR_KEY"`,
      ...dp,
    );

    const lines: CashBankLine[] = raw.map((r) => {
      const mainBook = txt(r.main_book) ?? '';
      // RP_CASH_BANK.cs:3261 {{(object)"SALES", false))}}: SALES takes SL_DATA, PURCHASE takes PR_DATA,
      // every other book the counter-party. MEMB ENTRY: desktop reads AD_DATA/AD_MEMB, RP_CASH_BANK.cs:3280, not ported.
      const party =
        mainBook === 'SALES'
          ? txt(r.sl_name)
          : mainBook === 'PURCHASE'
            ? txt(r.pr_name)
            : txt(r.cp_name);
      return {
        vchNo: txt(r.vch_no) ?? '',
        vchDate: toIsoDate(r.vch_date),
        book: txt(r.book_name) ?? '',
        coBook: txt(r.co_book) ?? '',
        mainBook,
        party: party ?? '',
        area: txt(r.cp_area) ?? '',
        net: num(r.net),
      };
    });

    const { rows, totals } = buildCashBank(opening[0]?.net, lines);
    const out: CashBankRow[] = rows;
    return {
      rows: out,
      totals,
      account: acc[0]
        ? { acCode: txt(acc[0].ac_code) ?? q.acCode, acName: txt(acc[0].ac_name) ?? '' }
        : null,
      book,
      from: q.fromDate,
      to: q.toDate,
    };
  });
}

/**
 * Account help list. RP_CASH_BANK.cs:3661 {{AND CAST(C.AC_CODE AS INT) < 100}}: code below 100 in any group, or code 200
 * or more with a cash/bank-like group. Location 00: the desktop's group-only query was not read (MISSING), empty list.
 */
export async function cashBankAccountHelp(
  prisma: any,
  s: CashBankScope,
  q: string,
): Promise<CashBankAccountHelp[]> {
  const lc = requireLocation(s);
  if (lc === '00') return [];
  return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [s.coCode, lc];
    let narrow = '';
    const needle = q.trim();
    if (needle !== '') {
      params.push(`${needle.replace(/[\\%_]/g, (m) => `\\${m}`)}%`);
      narrow = ` AND (a."AC_CODE" ILIKE $3 OR a."AC_NAME" ILIKE $3)`;
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."AC_CODE" AS ac_code, a."AC_NAME" AS ac_name, g."AC_GR_NAME" AS grp,
              a."AC_AREA" AS area, a."AC_ADD1" AS address, a."AC_CITY" AS city
         FROM "AC_MAST" a
         LEFT JOIN "AC_GROUP" g ON g."CO_CODE"=a."CO_CODE" AND g."AC_GR"=a."AC_GR"
        WHERE a."CO_CODE"=$1
          AND ((a."AC_CODE" ~ '^[0-9]+$' AND a."AC_CODE"::numeric < 100)
            OR (a."LC_CODE"=$2 AND a."AC_GR" IN ('02','03','19','21','22','23')
                AND a."AC_CODE" ~ '^[0-9]+$' AND a."AC_CODE"::numeric >= 200))${narrow}
        ORDER BY a."AC_NAME", a."AC_CODE"
        LIMIT 50`,
      ...params,
    );
    return rows.map((r) => ({
      acCode: txt(r.ac_code) ?? '',
      acName: txt(r.ac_name) ?? '',
      group: txt(r.grp) ?? '',
      area: txt(r.area) ?? '',
      address: txt(r.address) ?? '',
      city: txt(r.city) ?? '',
    }));
  });
}
