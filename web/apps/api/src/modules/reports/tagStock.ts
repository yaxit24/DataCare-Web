import { withTxBudget } from '../shared/txBudget.js';
import {
  r2,
  r3,
  tagStockColumns,
  tagStockCsv,
  type TagStockColumn,
  type TagStockTab,
  type TagStockView,
} from './tagStockColumns.js';

export { tagStockCsv, tagStockColumns };
export type { TagStockColumn, TagStockTab, TagStockView };

/**
 * Tag Stock report: the desktop RP_TAG "Tag Wise" selections (RP_TAG.cs:3977-4325), read-only.
 *
 *   in    BAR_DETL creation rows dated From..To (not every positive movement)               :4009
 *   out   MAIN_STOCK minus movements dated From..To joined to their tag, by voucher        :4070
 *   stock tags whose signed movement sum is > 0 up to To (the stock rule)                   :4124, :4187
 *   mrp   stock with ITM_MRP <> 0 (negative MRP counts)                                      :4152
 *   apr   APR_DETL 'APR ISU' (or 'EMP ISU') rows with ISU_REC = 'N', joined to BAR_DETL      :4216, :4227
 *   all   the signed movement history of the year, dates ignored when a tag no is given      :4278, :4286
 *
 * Every mode excludes the item-level sentinel tag 'N', is scoped to the session company and (unless the location
 * selector is blank) the location, and covers EVERY selected row: no row cap, totals summed over all rows.
 * The stock rule sums VCH_SRNO (the tag instance id) with the movement sign, per (company, location, tag, id,
 * item), over the movements of the session year dated up to To. The `view` option is the desktop Tag Summ /
 * Product Stk grouping computed on the same selection (no shared staging table, unlike TAG_SUM_DATA).
 * Text filters are bound parameters, never concatenated (RP_TAG.cs:4136 concatenates them).
 */
export class TagStockValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'TagStockValidationError';
  }
}

export interface TagStockScope {
  CO_CODE: string;
  LC_CODE: string;
  /** The session financial year; movements of another year never balance a tag (RP_TAG.cs:4124 A.CO_YEAR). */
  CO_YEAR?: string;
}
export interface TagStockFilters {
  /** Location selector: undefined = the session location, '' = every location of the company. */
  lcCode?: string;
  fromDate?: string;
  toDate?: string;
  /** The system date the Day column counts from; defaults to the database current date. */
  sysDate?: string;
  /** A, B or C. 'C' (and undefined) = no data-type filter (RP_TAG.cs:4009). */
  dataType?: string;
  tblCode?: string;
  itCode?: string;
  prCode?: string;
  grCode?: string;
  itType?: string;
  tagNo?: string;
  size?: string;
  /** Book code of the voucher book (CO_BOOK). */
  bookCode?: string;
  /** Tag no contains (the desktop search box over the bound grid); totals follow it. */
  search?: string;
  empIsuLess?: boolean;
  /** Apr: 'employee' is the desktop "Tour Outword Stock Show....?" = Yes (EMP ISU issues). */
  aprKind?: 'party' | 'employee';
  /** MsDesignHelp = Y: design order instead of tag order. */
  designHelp?: boolean;
  view?: TagStockView;
}
export interface TagStockRow {
  lcCode: string | null;
  vchType: string | null;
  vchNo: string | null;
  vchDate: string | null;
  day: number | null;
  tagNo: string;
  tagId: number | null;
  itCode: string;
  itName: string | null;
  counter: string | null;
  design: string | null;
  style: string | null;
  size: string | null;
  qty: number;
  pcs: number;
  grossWt: number;
  netWt: number;
  fine: number;
  lbrRate: number;
  lbrPrc: number;
  lbrAmt: number;
  othAmt: number;
  prCost: number;
  mrp: number;
  krName: string | null;
  remark: string | null;
  book: string | null;
  bookName: string | null;
  acCode: string | null;
  sign: string | null;
  empIsu: string | null;
  safeName: string | null;
  partyName: string | null;
  empName: string | null;
  itType: string | null;
  prCode: string | null;
  prName: string | null;
  /** Compatibility names kept for earlier callers. */
  designNo: string | null;
  tblCode: string | null;
}
export interface TagStockSummaryRow {
  key: string;
  name: string;
  itType: string | null;
  qty: number;
  pcs: number;
  grossWt: number;
  netWt: number;
}
export interface TagStockTotals {
  count: number;
  qty: number;
  pcs: number;
  grossWt: number;
  netWt: number;
  fine: number;
  lbrAmt: number;
  othAmt: number;
  prCost: number;
  mrp: number;
}
export interface TagStockReport {
  tab: TagStockTab;
  view: TagStockView;
  columns: TagStockColumn[];
  rows: Array<TagStockRow | TagStockSummaryRow>;
  totals: TagStockTotals;
  /** Apr only: employee ("tour") issues exist, so the screen asks the desktop prompt. */
  hasEmpIssue?: boolean;
}

export const TAG_STOCK_TABS: readonly TagStockTab[] = ['in', 'out', 'stock', 'mrp', 'apr', 'all'];
const VIEWS: readonly TagStockView[] = ['tag', 'item', 'product'];
const ISO = /^\d{4}-\d{2}-\d{2}$/;

const text = (v: unknown, name: string, max = 50): string | undefined => {
  if (v === undefined || v === null) return undefined;
  const s = String(v).trim();
  if (s.length > max) throw new TagStockValidationError(`${name} is too long`);
  return s === '' ? undefined : s;
};
const isoDate = (v: unknown, name: string): string | undefined => {
  const s = text(v, name, 10);
  if (s === undefined) return undefined;
  const ok =
    ISO.test(s) &&
    !Number.isNaN(Date.parse(s + 'T00:00:00Z')) &&
    new Date(s + 'T00:00:00Z').toISOString().slice(0, 10) === s;
  if (!ok) throw new TagStockValidationError(`${name} must be a valid date (YYYY-MM-DD)`);
  return s;
};

/** Validates the raw query of the HTTP routes (fail closed: an unknown mode or grouping is a 400, not stock). */
export function parseTagStockQuery(q: Record<string, unknown>): {
  tab: TagStockTab;
  filters: TagStockFilters;
} {
  const tabRaw = String(q.tab ?? 'stock');
  if (!(TAG_STOCK_TABS as readonly string[]).includes(tabRaw))
    throw new TagStockValidationError(`tab must be one of ${TAG_STOCK_TABS.join(', ')}`);
  const viewRaw = String(q.view ?? 'tag');
  if (!(VIEWS as readonly string[]).includes(viewRaw))
    throw new TagStockValidationError(`view must be one of ${VIEWS.join(', ')}`);
  const aprRaw = String(q.aprKind ?? 'party');
  if (aprRaw !== 'party' && aprRaw !== 'employee')
    throw new TagStockValidationError('aprKind must be party or employee');
  const dt = text(q.dataType, 'dataType', 1)?.toUpperCase();
  if (dt && !['A', 'B', 'C'].includes(dt))
    throw new TagStockValidationError('dataType must be A, B or C');
  const flag = (v: unknown) => v === true || v === '1' || v === 'true' || v === 'Y';
  const filters: TagStockFilters = {
    fromDate: isoDate(q.fromDate, 'fromDate'),
    toDate: isoDate(q.toDate, 'toDate'),
    sysDate: isoDate(q.sysDate, 'sysDate'),
    dataType: dt,
    tblCode: text(q.tblCode, 'tblCode'),
    itCode: text(q.itCode, 'itCode'),
    prCode: text(q.prCode, 'prCode'),
    grCode: text(q.grCode, 'grCode'),
    itType: text(q.itType, 'itType')?.toUpperCase(),
    tagNo: text(q.tagNo, 'tagNo'),
    size: text(q.size, 'size'),
    bookCode: text(q.bookCode, 'bookCode'),
    search: text(q.search, 'search'),
    empIsuLess: flag(q.empIsuLess),
    aprKind: aprRaw,
    designHelp: flag(q.designHelp),
    view: viewRaw as TagStockView,
  };
  // The location selector is present-but-blank for "every location".
  if (Object.prototype.hasOwnProperty.call(q, 'lcCode'))
    filters.lcCode = text(q.lcCode, 'lcCode') ?? '';
  return { tab: tabRaw as TagStockTab, filters };
}

const N = (v: unknown): number => (v === null || v === undefined ? 0 : Number(v));
const S = (v: unknown): string | null => (v === null || v === undefined ? null : String(v));

/** STK_DATE is stored as 'YYYY-MM-DD' text; anything else counts as unknown instead of failing the report. */
const stkDate = (alias: string): string =>
  `(CASE WHEN ${alias}."STK_DATE" ~ '^\\d{4}-\\d{2}-\\d{2}' THEN substr(${alias}."STK_DATE",1,10)::date END)`;

class Params {
  readonly values: unknown[] = [];
  add(v: unknown): string {
    this.values.push(v);
    return `$${this.values.length}`;
  }
}

/** The select list shared by every mode: the same aliases, with per-mode expressions. */
interface Cols {
  lcCode: string;
  vchType: string;
  vchNo: string;
  vchDate: string;
  day: string;
  tagNo: string;
  itCode: string;
  counter: string;
  design: string;
  style: string;
  size: string;
  pcs: string;
  gwt: string;
  nwt: string;
  fine: string;
  lbrRate: string;
  lbrPrc: string;
  lbrAmt: string;
  othAmt: string;
  prCost: string;
  mrp: string;
  krName: string;
  remark: string;
  book: string;
  bookName: string;
  acCode: string;
  tagId: string;
  sign: string;
  empIsu: string;
  party: string;
  emp: string;
}
const num = (e: string): string => `coalesce(${e},0)::float8`;
function selectList(k: Cols): string {
  return `${k.lcCode} AS "lcCode", ${k.vchType} AS "vchType", ${k.vchNo} AS "vchNo",
    to_char(${k.vchDate},'YYYY-MM-DD') AS "vchDate", ${k.day} AS "day", ${k.tagNo} AS "tagNo",
    ${k.itCode} AS "itCode", ${k.counter} AS "counter", ${k.design} AS "design", ${k.style} AS "style",
    ${k.size} AS "size", ${num(k.pcs)} AS "pcs", ${num(k.gwt)} AS "grossWt", ${num(k.nwt)} AS "netWt",
    ${num(k.fine)} AS "fine", ${num(k.lbrRate)} AS "lbrRate", ${num(k.lbrPrc)} AS "lbrPrc",
    ${num(k.lbrAmt)} AS "lbrAmt", ${num(k.othAmt)} AS "othAmt", ${num(k.prCost)} AS "prCost",
    ${num(k.mrp)} AS "mrp", ${k.krName} AS "krName", ${k.remark} AS "remark", ${k.book} AS "book",
    ${k.bookName} AS "bookName", ${k.acCode} AS "acCode", ${k.tagId} AS "tagId", ${k.sign} AS "sign",
    ${k.empIsu} AS "empIsu", ${k.party} AS "partyName", ${k.emp} AS "empName",
    b."IT_NAME" AS "itName", b."IT_TYPE" AS "itType", b."PR_CODE" AS "prCode", b."SAFE_NAME" AS "safeName",
    (SELECT p."PR_NAME" FROM "PRODUCT_MAST" p WHERE p."CO_CODE"=b."CO_CODE" AND p."PR_CODE"=b."PR_CODE" LIMIT 1) AS "prName"`;
}
const fromC = (c: string): Cols => ({
  lcCode: `${c}."LC_CODE"`,
  vchType: `${c}."VCH_TYPE"`,
  vchNo: `${c}."VCH_NO"`,
  vchDate: `${c}."VCH_DATE"`,
  day: 'NULL::int',
  tagNo: `${c}."TAG_NO"`,
  itCode: `${c}."IT_CODE"`,
  counter: `${c}."TBL_CODE"`,
  design: `${c}."DESIGN_NO"`,
  style: `${c}."ITM_STYLE"`,
  size: `${c}."ITM_SIZE"`,
  pcs: `${c}."ITM_PCS"`,
  gwt: `${c}."ITM_GWT"`,
  nwt: `${c}."ITM_NWT"`,
  fine: `${c}."ITM_FINE"`,
  lbrRate: `${c}."LBR_RATE"`,
  lbrPrc: `${c}."LBR_PRC"`,
  lbrAmt: `${c}."LBR_AMT"`,
  othAmt: `${c}."OTH_AMT"`,
  prCost: `${c}."KR_COST"`,
  mrp: `${c}."ITM_MRP"`,
  krName: `${c}."KR_NAME"`,
  remark: `${c}."ITM_REMARK"`,
  book: `${c}."CO_BOOK"`,
  bookName: `${c}."BOOK_NAME"`,
  acCode: `${c}."AC_CODE"`,
  tagId: `${c}."VCH_SRNO"::float8`,
  sign: 'NULL::text',
  empIsu: 'NULL::text',
  party: 'NULL::text',
  emp: 'NULL::text',
});

const SIGNED_SUM = `CASE WHEN m."ITM_SIGN"='+' THEN m."VCH_SRNO" ELSE -m."VCH_SRNO" END`;

export async function tagStockReport(
  prisma: any,
  tenantId: string,
  scope: TagStockScope,
  tabIn: TagStockTab,
  filtersIn: TagStockFilters = {},
): Promise<TagStockReport> {
  const tab = tabIn;
  if (!(TAG_STOCK_TABS as readonly string[]).includes(tab))
    throw new TagStockValidationError(`tab must be one of ${TAG_STOCK_TABS.join(', ')}`);
  const view = filtersIn.view ?? 'tag';
  if (!(VIEWS as readonly string[]).includes(view))
    throw new TagStockValidationError(`view must be one of ${VIEWS.join(', ')}`);
  const f = filtersIn;
  const aprKind = f.aprKind === 'employee' ? 'employee' : 'party';
  const lc = f.lcCode === undefined ? scope.LC_CODE : f.lcCode;

  return withTxBudget(prisma, tenantId, 'heavy', async (tx: any) => {
    const p = new Params();
    const co = p.add(scope.CO_CODE);
    // Bound only where the Day column uses it: an unused parameter has no type and PostgreSQL refuses it.
    let sysExpr: string | undefined;
    const sys = (): string =>
      (sysExpr ??= f.sysDate ? `${p.add(f.sysDate)}::date` : 'CURRENT_DATE');
    const where: string[] = [];
    const dataType = f.dataType && f.dataType !== 'C' ? f.dataType : undefined;
    const year = scope.CO_YEAR ? scope.CO_YEAR : undefined;

    /** Filters common to the BAR_DETL-side selectors; `m` names the movement/approval alias if any. */
    const itemFilters = (c: string, tagCol: string, sizeCol: string, bookCol?: string) => {
      if (f.size) where.push(`${sizeCol}=${p.add(f.size)}`);
      if (f.itCode) where.push(`b."IT_CODE"=${p.add(f.itCode)}`);
      if (f.prCode) where.push(`b."PR_CODE"=${p.add(f.prCode)}`);
      if (f.grCode) where.push(`b."GR_CODE"=${p.add(f.grCode)}`);
      if (f.itType) where.push(`b."IT_TYPE"=${p.add(f.itType)}`);
      if (f.tagNo) where.push(`${tagCol}=${p.add(f.tagNo)}`);
      if (f.tblCode) where.push(`${c}."TBL_CODE"=${p.add(f.tblCode)}`);
      if (f.search) where.push(`strpos(upper(${tagCol}),upper(${p.add(f.search)}))>0`);
      if (bookCol && f.bookCode) where.push(`${bookCol}=${p.add(f.bookCode)}`);
    };
    const itemJoin = (c: string) =>
      `LEFT JOIN "ITEM_MAST" b ON b."CO_CODE"=${c}."CO_CODE" AND b."IT_CODE"=${c}."IT_CODE"`;
    const order = (a: string, byDesign: string, byTag: string) => (f.designHelp ? byDesign : byTag);
    const lcWhere = (c: string) => {
      if (lc) where.push(`${c}."LC_CODE"=${p.add(lc)}`);
    };
    const dateRange = (col: string, withFrom: boolean) => {
      if (withFrom && f.fromDate) where.push(`${col}>=${p.add(f.fromDate)}::date`);
      if (f.toDate) where.push(`${col}<=${p.add(f.toDate)}::date`);
    };
    const designOrder = (col: string) => `substr(${col},1,2), length(${col}), ${col}`;

    let sql: string;
    where.push(`TRUE`);
    if (tab === 'in') {
      const k = fromC('c');
      k.day = `(${sys()} - ${stkDate('c')})`;
      sql = `SELECT ${selectList(k)}
        FROM "BAR_DETL" c ${itemJoin('c')}`;
      where.push(`c."CO_CODE"=${co}`);
      lcWhere('c');
      if (year) where.push(`c."CO_YEAR"=${p.add(year)}`);
      where.push(`c."TAG_NO"<>'N'`);
      dateRange('c."VCH_DATE"', true);
      if (dataType) where.push(`c."DATA_TYPE"=${p.add(dataType)}`);
      itemFilters('c', 'c."TAG_NO"', 'c."ITM_SIZE"', 'c."CO_BOOK"');
      sql += ` WHERE ${where.join(' AND ')} ORDER BY ${order('c', designOrder('c."DESIGN_NO"'), 'c."TAG_NO"')}, c."VCH_SRNO", c.row_id`;
    } else if (tab === 'out' || tab === 'all') {
      const k = fromC('c');
      Object.assign(k, {
        lcCode: 'a."LC_CODE"',
        vchType: 'a."VCH_TYPE"',
        vchNo: 'a."VCH_NO"',
        vchDate: 'a."VCH_DATE"',
        itCode: 'a."IT_CODE"',
        counter: 'a."TBL_CODE"',
        pcs: 'a."ITM_PCS"',
        gwt: 'a."ITM_GWT"',
        nwt: 'a."ITM_NWT"',
        fine: 'a."ITM_FINE"',
        lbrRate: 'a."LBR_RATE"',
        lbrAmt: 'a."LBR_AMT"',
        othAmt: 'a."OTH_AMT"',
        mrp: 'a."ITM_MRP"',
        book: 'a."CO_BOOK"',
        bookName: 'a."BOOK_NAME"',
        acCode: 'a."AC_CODE"',
        tagId: 'a."VCH_SRNO"::float8',
      });
      if (tab === 'out') {
        k.day = `(a."VCH_DATE" - ${stkDate('c')})`;
        k.tagNo = 'c."TAG_NO"';
      } else {
        // All: the movement's own design and size; no style, labour percent or tag cost (RP_TAG.cs:4278).
        Object.assign(k, {
          tagNo: 'a."TAG_NO"',
          design: 'a."DESIGN_NO"',
          size: 'a."ITM_SIZE"',
          style: 'NULL::text',
          lbrPrc: '0',
          prCost: '0',
          sign: 'a."ITM_SIGN"',
          empIsu: 'c."EMP_ISU"',
        });
      }
      sql = `SELECT ${selectList(k)}
        FROM "MAIN_STOCK" a
        JOIN "BAR_DETL" c ON a."CO_CODE"=c."CO_CODE" AND a."LC_CODE"=c."LC_CODE" AND a."TAG_NO"=c."TAG_NO"
          AND a."VCH_SRNO"=c."VCH_SRNO" AND a."IT_CODE"=c."IT_CODE"
        ${itemJoin('a')}`;
      where.push(`a."CO_CODE"=${co}`);
      lcWhere('a');
      if (year) where.push(`a."CO_YEAR"=${p.add(year)}`);
      where.push(`a."TAG_NO"<>'N'`);
      if (tab === 'out') {
        dateRange('a."VCH_DATE"', true);
        where.push(`a."ITM_SIGN"='-'`);
      } else if (!f.tagNo) {
        dateRange('a."VCH_DATE"', true);
      }
      if (dataType) where.push(`a."DATA_TYPE"=${p.add(dataType)}`);
      // Out filters the tag's size (C.ITM_SIZE); All filters the movement's (A.ITM_SIZE).
      itemFilters(
        'a',
        tab === 'out' ? 'c."TAG_NO"' : 'a."TAG_NO"',
        tab === 'out' ? 'c."ITM_SIZE"' : 'a."ITM_SIZE"',
        'a."CO_BOOK"',
      );
      const ord =
        tab === 'out'
          ? `a."VCH_TYPE", a."VCH_NO", a."TAG_NO"`
          : order('a', `a."VCH_DATE", ${designOrder('c."DESIGN_NO"')}`, `a."VCH_DATE", a."TAG_NO"`);
      sql += ` WHERE ${where.join(' AND ')} ORDER BY ${ord}, a.row_id`;
    } else if (tab === 'apr') {
      const k = fromC('c');
      Object.assign(k, {
        lcCode: 'a."LC_CODE"',
        vchType: 'a."VCH_TYPE"',
        vchNo: 'a."VCH_NO"',
        vchDate: 'a."VCH_DATE"',
        tagNo: 'a."TAG_NO"',
        itCode: 'a."IT_CODE"',
        book: 'a."CO_BOOK"',
        bookName: 'a."BOOK_NAME"',
        acCode: 'a."AC_CODE"',
        remark: 'NULL::text',
        party:
          aprKind === 'party'
            ? `(SELECT d."AC_NAME" FROM "AC_MAST" d WHERE d."CO_CODE"=a."CO_CODE" AND d."AC_CODE"=a."AC_CODE" LIMIT 1)`
            : 'NULL::text',
        emp:
          aprKind === 'employee'
            ? `(SELECT d."EMP_NAME" FROM "EMP_MAST" d WHERE d."CO_CODE"=a."CO_CODE" AND d."EMP_CODE"=a."AC_CODE" LIMIT 1)`
            : 'NULL::text',
      });
      sql = `SELECT ${selectList(k)}
        FROM "APR_DETL" a
        JOIN "BAR_DETL" c ON a."CO_CODE"=c."CO_CODE" AND a."LC_CODE"=c."LC_CODE" AND a."TAG_NO"=c."TAG_NO"
          AND a."VCH_SRNO"=c."VCH_SRNO" AND a."IT_CODE"=c."IT_CODE"
        ${itemJoin('a')}`;
      where.push(`a."CO_CODE"=${co}`);
      lcWhere('a');
      where.push(`a."TAG_NO"<>'N'`);
      dateRange('a."VCH_DATE"', false);
      where.push(
        `a."BOOK_NAME"='${aprKind === 'employee' ? 'EMP ISU' : 'APR ISU'}'`,
        `a."ISU_REC"='N'`,
      );
      itemFilters('c', 'a."TAG_NO"', 'c."ITM_SIZE"', 'a."CO_BOOK"');
      sql += ` WHERE ${where.join(' AND ')} ORDER BY a."CO_YEAR", a."VCH_NO", ${
        f.designHelp ? 'c."DESIGN_NO"' : 'a."TAG_NO"'
      }, a.row_id`;
    } else {
      // stock / mrp: BAR_DETL instances whose signed movement sum (year, up to To) is positive.
      const k = fromC('c');
      k.vchDate = stkDate('c');
      k.day = `(${sys()} - ${stkDate('c')})`;
      sql = `SELECT ${selectList(k)}
        FROM "BAR_DETL" c ${itemJoin('c')}`;
      where.push(`c."CO_CODE"=${co}`);
      lcWhere('c');
      where.push(`c."TAG_NO"<>'N'`);
      itemFilters('c', 'c."TAG_NO"', 'c."ITM_SIZE"');
      if (tab === 'mrp') where.push(`c."ITM_MRP"<>0`);
      if (f.empIsuLess) where.push(`c."EMP_ISU"<>'Y'`);
      const mv: string[] = [
        `m."CO_CODE"=c."CO_CODE"`,
        `m."LC_CODE"=c."LC_CODE"`,
        `m."TAG_NO"=c."TAG_NO"`,
        `m."VCH_SRNO"=c."VCH_SRNO"`,
        `m."IT_CODE"=c."IT_CODE"`,
        `m."TAG_NO"<>'N'`,
      ];
      if (year) mv.push(`m."CO_YEAR"=${p.add(year)}`);
      if (f.toDate) mv.push(`m."VCH_DATE"<=${p.add(f.toDate)}::date`);
      if (dataType) mv.push(`m."DATA_TYPE"=${p.add(dataType)}`);
      if (f.bookCode) mv.push(`m."CO_BOOK"=${p.add(f.bookCode)}`);
      where.push(`(SELECT sum(${SIGNED_SUM}) FROM "MAIN_STOCK" m WHERE ${mv.join(' AND ')}) > 0`);
      sql += ` WHERE ${where.join(' AND ')} ORDER BY ${order('c', designOrder('c."DESIGN_NO"'), 'c."TAG_NO"')}, c."VCH_SRNO", c.row_id`;
    }

    const raw: any[] = await tx.$queryRawUnsafe(sql, ...p.values);
    const rows: TagStockRow[] = raw.map((r) => ({
      lcCode: S(r.lcCode),
      vchType: S(r.vchType),
      vchNo: S(r.vchNo),
      vchDate: S(r.vchDate),
      day: r.day === null || r.day === undefined ? null : Number(r.day),
      tagNo: String(r.tagNo ?? ''),
      tagId: r.tagId === null || r.tagId === undefined ? null : Number(r.tagId),
      itCode: String(r.itCode ?? ''),
      itName: S(r.itName),
      counter: S(r.counter),
      design: S(r.design),
      style: S(r.style),
      size: S(r.size),
      qty: 1,
      pcs: N(r.pcs),
      grossWt: N(r.grossWt),
      netWt: N(r.netWt),
      fine: N(r.fine),
      lbrRate: N(r.lbrRate),
      lbrPrc: N(r.lbrPrc),
      lbrAmt: N(r.lbrAmt),
      othAmt: N(r.othAmt),
      prCost: N(r.prCost),
      mrp: N(r.mrp),
      krName: S(r.krName),
      remark: S(r.remark),
      book: S(r.book),
      bookName: S(r.bookName),
      acCode: S(r.acCode),
      sign: S(r.sign),
      empIsu: S(r.empIsu),
      safeName: S(r.safeName),
      partyName: S(r.partyName),
      empName: S(r.empName),
      itType: S(r.itType),
      prCode: S(r.prCode),
      prName: S(r.prName),
      designNo: S(r.design),
      tblCode: S(r.counter),
    }));

    const totals = totalsOf(rows);
    let hasEmpIssue: boolean | undefined;
    if (tab === 'apr') {
      const q: any[] = await tx.$queryRawUnsafe(
        `SELECT 1 AS x FROM "BAR_DETL" WHERE "CO_CODE"=$1 ${lc ? `AND "LC_CODE"=$2` : ''} AND "EMP_ISU"='Y' LIMIT 1`,
        ...(lc ? [scope.CO_CODE, lc] : [scope.CO_CODE]),
      );
      hasEmpIssue = q.length > 0;
    }
    const base = { tab, view, totals, ...(hasEmpIssue === undefined ? {} : { hasEmpIssue }) };
    if (view === 'tag') return { ...base, columns: tagStockColumns(tab, view, aprKind), rows };
    return { ...base, columns: tagStockColumns(tab, view, aprKind), rows: summarise(rows, view) };
  });
}

function totalsOf(rows: TagStockRow[]): TagStockTotals {
  const t = rows.reduce(
    (a, r) => ({
      qty: a.qty + r.qty,
      pcs: a.pcs + r.pcs,
      grossWt: a.grossWt + r.grossWt,
      netWt: a.netWt + r.netWt,
      fine: a.fine + r.fine,
      lbrAmt: a.lbrAmt + r.lbrAmt,
      othAmt: a.othAmt + r.othAmt,
      prCost: a.prCost + r.prCost,
      mrp: a.mrp + r.mrp,
    }),
    { qty: 0, pcs: 0, grossWt: 0, netWt: 0, fine: 0, lbrAmt: 0, othAmt: 0, prCost: 0, mrp: 0 },
  );
  return {
    count: t.qty,
    qty: t.qty,
    pcs: r3(t.pcs),
    grossWt: r3(t.grossWt),
    netWt: r3(t.netWt),
    fine: r3(t.fine),
    lbrAmt: r2(t.lbrAmt),
    othAmt: r2(t.othAmt),
    prCost: r2(t.prCost),
    mrp: r2(t.mrp),
  };
}

/** Tag Summ (by item name) and Product Stk (by product name), RP_TAG.cs:7866, :8322-8326. */
function summarise(rows: TagStockRow[], view: TagStockView): TagStockSummaryRow[] {
  const groups = new Map<string, TagStockSummaryRow>();
  for (const r of rows) {
    const key = view === 'item' ? r.itCode : (r.prCode ?? '');
    const name = (view === 'item' ? r.itName : r.prName) ?? key;
    const g = groups.get(key) ?? {
      key,
      name,
      itType: r.itType,
      qty: 0,
      pcs: 0,
      grossWt: 0,
      netWt: 0,
    };
    g.qty += r.qty;
    g.pcs += r.pcs;
    g.grossWt += r.grossWt;
    g.netWt += r.netWt;
    groups.set(key, g);
  }
  return [...groups.values()]
    .map((g) => ({ ...g, pcs: r3(g.pcs), grossWt: r3(g.grossWt), netWt: r3(g.netWt) }))
    .sort((a, b) => (a.name < b.name ? -1 : a.name > b.name ? 1 : a.key < b.key ? -1 : 1));
}
