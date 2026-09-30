import { formatVoucherNo } from '../vouchers/numbering.js';

/**
 * The complete voucher key every printable document reads by.
 *
 * Each desktop print filters its Crystal report on the full identity, for example
 * `{SL_DATA.CO_CODE}`, `{SL_DATA.LC_CODE}`, `{SL_DATA.CO_YEAR}`, `{SL_DATA.CO_BOOK}` and `{SL_DATA.VCH_NO}`
 * (TR_SALE.cs:16475, 16532; TR_PURC.cs:14007). Voucher numbers restart per location, year and book, so a
 * reader that omits any of them can print another branch's or another year's voucher with the same number,
 * and a detail query that omits them mixes the lines of several vouchers into one document.
 *
 * `tenant_id` is also named explicitly. Row-level security already isolates tenants; naming the column keeps
 * the predicate complete even for a caller that runs with a broader role.
 */
export interface VoucherDocumentScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  vchNo: string | number;
}

/** A document request that does not name its complete voucher identity. Mapped to HTTP 400. */
export class DocumentScopeError extends Error {
  readonly statusCode = 400;
  constructor(readonly field: keyof VoucherDocumentScope) {
    super(`Printing a voucher requires ${field}`);
    this.name = 'DocumentScopeError';
  }
}

const FIELDS: Array<keyof VoucherDocumentScope> = [
  'tenantId',
  'coCode',
  'lcCode',
  'coYear',
  'coBook',
  'vchNo',
];

/** Refuse an incomplete key instead of widening the query. There is deliberately no default book. */
export function requireVoucherDocumentScope(
  s: Partial<Record<keyof VoucherDocumentScope, unknown>>,
): VoucherDocumentScope {
  for (const field of FIELDS) {
    if (!String(s[field] ?? '').trim()) throw new DocumentScopeError(field);
  }
  return {
    tenantId: String(s.tenantId).trim(),
    coCode: String(s.coCode).trim(),
    lcCode: String(s.lcCode).trim(),
    coYear: String(s.coYear).trim(),
    coBook: String(s.coBook).trim(),
    vchNo: String(s.vchNo).trim(),
  };
}

/** `WHERE` predicate over the complete key; parameters are `voucherKeyParams` in order ($1..$6). */
export function voucherKeyWhere(alias = ''): string {
  const a = alias ? `${alias}.` : '';
  return (
    `${a}tenant_id=$1 AND ${a}"CO_CODE"=$2 AND ${a}"LC_CODE"=$3 AND ${a}"CO_YEAR"=$4 ` +
    `AND ${a}"CO_BOOK"=$5 AND ${a}"VCH_NO"=$6`
  );
}

export function voucherKeyParams(s: VoucherDocumentScope): unknown[] {
  return [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook, formatVoucherNo(s.vchNo)];
}

/** The company header row (CO_MAST is company-owned). */
export async function documentCompanyTx(tx: any, s: VoucherDocumentScope): Promise<any> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
    s.tenantId,
    s.coCode,
  );
  return rows[0] ?? null;
}

/**
 * The party on the voucher. The desktop joins AC_MAST on company and account only (for example
 * TR_KR_ISU.cs:6850 `A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE`), so an account is company-wide.
 * Where a company carries the same code on several locations, the voucher's own location wins, and the
 * choice is deterministic rather than whichever row the database returns first.
 */
export async function documentPartyTx(
  tx: any,
  s: VoucherDocumentScope,
  acCode: unknown,
): Promise<any> {
  const code = String(acCode ?? '').trim();
  if (!code) return null;
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
      ORDER BY CASE WHEN "LC_CODE"=$4 THEN 0 WHEN "LC_CODE" IS NULL OR btrim("LC_CODE")='' THEN 1 ELSE 2 END,
               row_id
      LIMIT 1`,
    s.tenantId,
    s.coCode,
    code,
    s.lcCode,
  );
  return rows[0] ?? null;
}
