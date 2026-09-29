import { withTenant } from '@datacare/db';

/** Lookup sources: master table + code/name columns for type-ahead pickers (LookupPicker UI). */
const SOURCES: Record<string, { table: string; code: string; name: string; extra?: string[] }> = {
  accounts: {
    table: 'AC_MAST',
    code: 'AC_CODE',
    name: 'AC_NAME',
    extra: ['AC_GST_TYPE', 'AC_CITY', 'AC_MOBILE', 'AC_STATE'],
  },
  customers: {
    table: 'AC_MAST',
    code: 'AC_CODE',
    name: 'AC_NAME',
    extra: ['AC_GST_TYPE', 'AC_CITY', 'AC_MOBILE', 'AC_STATE'],
  },
  items: { table: 'ITEM_MAST', code: 'IT_CODE', name: 'IT_NAME', extra: ['IT_TYPE', 'RATE_TYPE'] },
  groups: { table: 'GROUP_MAST', code: 'GR_CODE', name: 'GR_NAME' },
  'ac-groups': { table: 'AC_GROUP', code: 'AC_GR', name: 'AC_GR_NAME', extra: ['AC_MAIN_GR'] },
  products: { table: 'PRODUCT_MAST', code: 'PR_CODE', name: 'PR_NAME' },
  employees: { table: 'EMP_MAST', code: 'EMP_CODE', name: 'EMP_NAME' },
  designs: { table: 'DESIGN_MAST', code: 'DESIGN_NO', name: 'DESIGN_NO' },
  /**
   * Diamond / stone master, for the `*_IDTL` sub-detail grids' `DM_CODE` column.
   *
   * The desktop reads `DM_MAST` at 60 call sites and its sub-detail grids offer a picker on that
   * column, but the web had no lookup source for it — so even once the sub-detail grid existed,
   * `DmCode` would have been free text and `DmName`/`DmColor` would never autofill. The extras are
   * the columns the desktop fills alongside the code.
   */
  diamonds: {
    table: 'DM_MAST',
    code: 'DM_CODE',
    name: 'DM_NAME',
    extra: ['DM_COLOR', 'DM_SHAPE', 'DM_CLARITY', 'SL_RATE', 'PR_RATE'],
  },
  tags: {
    table: 'BAR_DETL',
    code: 'TAG_NO',
    name: 'IT_CODE',
    extra: ['ITM_NWT', 'ITM_GWT', 'ITM_TOUCH', 'ITM_FINE', 'ITM_RATE', 'ITM_MRP'],
  },
  states: { table: 'STATE_MAST', code: 'STATE_CODE', name: 'STATE_NAME', extra: ['STATE_SHORT'] },
  books: {
    table: 'BOOK_DATA',
    code: 'CO_BOOK',
    name: 'BOOK_NAME',
    extra: ['BOOK_TYPE', 'BOOK_INOUT', 'BOOK_VCH_TYPE'],
  },
};

const q = (id: string): string => '"' + id.replace(/[^A-Za-z0-9_]/g, '') + '"';
const text = (v: unknown): string => String(v ?? '').trim();
const num = (v: unknown): number => Number(v ?? 0);

export interface LookupOptions {
  lcCode?: string;
  coYear?: string;
  acCode?: string;
  itType?: string;
}

function serialText(v: unknown): string {
  const n = Number(v);
  if (Number.isFinite(n)) return Number.isInteger(n) ? String(n) : String(n);
  return text(v);
}

/**
 * Workflow lookup for TR_BUL_BOOKING sources used by rate-cut / wholesale sale.
 *
 * A booking source is not a master row. It is a scoped voucher line whose remaining quantity is
 * `BUL_DATA.ITM_GWT - BUL_DATA.ADJ_WT`, and the rate-cut writer consumes it by joining
 * `RATE_CUT_* .ISU_YRCD/ISU_DBCD/ISU_NO/ISU_SRNO` to
 * `BUL_DATA.CO_YEAR/CO_BOOK/VCH_NO/OLD_SRNO`. Returning only rows with a positive remainder gives the
 * operator the same class of selectable sources the desktop offers and prevents free-text source keys
 * from being the normal path.
 */
export async function lookupBullionBookings(
  prisma: any,
  tenantId: string,
  term: string,
  coCode: string,
  limit = 20,
  options: LookupOptions = {},
): Promise<Record<string, unknown>[]> {
  const n = Math.min(Number(limit) || 20, 50);
  const find = `%${text(term)}%`;
  const lcCode = text(options.lcCode);
  const coYear = text(options.coYear);
  const acCode = text(options.acCode);
  const itType = text(options.itType);
  return withTenant(prisma, tenantId, async (tx: any) => {
    const rows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT "CO_YEAR","CO_BOOK","VCH_NO",coalesce("OLD_SRNO","SR_NO")::float8 AS "SOURCE_SRNO",
              "LC_CODE","AC_CODE","IT_CODE","IT_TYPE","IT_DESC","VCH_DATE"::text AS "VCH_DATE",
              coalesce("ITM_GWT",0)::float8 AS "ITM_GWT",
              coalesce("ADJ_WT",0)::float8 AS "ADJ_WT",
              (coalesce("ITM_GWT",0) - coalesce("ADJ_WT",0))::float8 AS "AVAILABLE_WT",
              coalesce("ITM_RATE",0)::float8 AS "ITM_RATE",
              coalesce("MCX_RATE",0)::float8 AS "MCX_RATE",
              coalesce("ITM_AMT",0)::float8 AS "ITM_AMT"
         FROM "BUL_DATA"
        WHERE tenant_id=$1
          AND "CO_CODE"=$2
          AND ($3::text='' OR "LC_CODE"=$3)
          AND ($4::text='' OR "CO_YEAR"=$4)
          AND ($5::text='' OR "AC_CODE"=$5)
          AND ($6::text='' OR "IT_TYPE"=$6)
          AND (coalesce("ITM_GWT",0) - coalesce("ADJ_WT",0)) > 0
          AND (
            $7::text='%%'
            OR "CO_BOOK"::text ILIKE $7
            OR "VCH_NO"::text ILIKE $7
            OR "AC_CODE"::text ILIKE $7
            OR coalesce("IT_CODE",'')::text ILIKE $7
            OR coalesce("IT_DESC",'')::text ILIKE $7
          )
        ORDER BY "VCH_DATE" NULLS LAST,"CO_YEAR","CO_BOOK","VCH_NO","SOURCE_SRNO"
        LIMIT ${n}`,
      tenantId,
      coCode,
      lcCode,
      coYear,
      acCode,
      itType,
      find,
    );
    return rows.map((r) => {
      const srno = serialText(r.SOURCE_SRNO);
      const year = text(r.CO_YEAR);
      const book = text(r.CO_BOOK);
      const voucher = text(r.VCH_NO);
      const availableWt = num(r.AVAILABLE_WT);
      const item = text(r.IT_CODE) || text(r.IT_TYPE);
      return {
        code: `${year}/${book}/${voucher}/${srno}`,
        name: `${text(r.AC_CODE)} · ${item} · ${availableWt.toFixed(3)}g available`,
        CO_YEAR: year,
        CO_BOOK: book,
        VCH_NO: voucher,
        SR_NO: num(r.SOURCE_SRNO),
        OLD_SRNO: num(r.SOURCE_SRNO),
        LC_CODE: text(r.LC_CODE),
        AC_CODE: text(r.AC_CODE),
        IT_CODE: text(r.IT_CODE),
        IT_TYPE: text(r.IT_TYPE),
        IT_DESC: text(r.IT_DESC),
        VCH_DATE: text(r.VCH_DATE).slice(0, 10),
        ITM_GWT: num(r.ITM_GWT),
        ADJ_WT: num(r.ADJ_WT),
        AVAILABLE_WT: availableWt,
        ITM_RATE: num(r.ITM_RATE),
        MCX_RATE: num(r.MCX_RATE),
        ITM_AMT: num(r.ITM_AMT),
        issueYear: year,
        issueBook: book,
        issueNo: voucher,
        issueSrno: num(r.SOURCE_SRNO),
        issueLcCode: text(r.LC_CODE),
        availableWt,
      };
    });
  });
}

/** Search a master by code or name (case-insensitive, prefix-weighted), scoped to the company. */
export async function lookup(
  prisma: any,
  tenantId: string,
  entity: string,
  term: string,
  coCode: string,
  limit = 20,
  options: LookupOptions = {},
): Promise<Record<string, unknown>[]> {
  if (entity === 'bullion-bookings') {
    return lookupBullionBookings(prisma, tenantId, term, coCode, limit, options);
  }
  const s = SOURCES[entity];
  if (!s) return [];
  const n = Math.min(Number(limit) || 20, 50);
  const t = `%${(term || '').trim()}%`;
  const cols = [s.code, s.name, ...(s.extra ?? [])].filter((c, i, a) => a.indexOf(c) === i);
  const sel = cols.map((c) => `${q(c)}`).join(',');
  // company filter only if the table has CO_CODE
  return withTenant(prisma, tenantId, async (tx: any) => {
    const hasCo =
      (
        await tx.$queryRawUnsafe(
          `SELECT count(*)::int n FROM information_schema.columns WHERE table_name=$1 AND column_name='CO_CODE'`,
          s.table,
        )
      )[0].n > 0;
    const coClause = hasCo ? `${q('CO_CODE')}=$3 AND ` : '';
    const params: unknown[] = hasCo ? [t, t, coCode] : [t, t];
    const rows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT DISTINCT ${sel} FROM ${q(s.table)} WHERE ${coClause}(${q(s.code)}::text ILIKE $1 OR ${q(s.name)}::text ILIKE $2)
       ORDER BY ${q(s.code)} LIMIT ${n}`,
      ...params,
    );
    return rows.map((r) => ({
      code: r[s.code],
      name: r[s.name],
      ...Object.fromEntries((s.extra ?? []).map((e) => [e, r[e]])),
    }));
  });
}

export const LOOKUP_ENTITIES = Object.keys(SOURCES);
