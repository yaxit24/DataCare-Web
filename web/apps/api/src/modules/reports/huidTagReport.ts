import { toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';

/**
 * WP-18 HuId Report dataset — desktop `RP_HUID` (`Tag Stock With Huid`, MDI_FORM.cs:9032 dispatch).
 *
 * WHY THIS EXISTS
 * The web had only a two-tab approximation (`huid.ts`: "all history" / net-count stock, no dates, no year,
 * no Out view). The desktop form has three views — In, Out and Stock — each with its own driving table and
 * date rule, and this resolver reproduces those three queries exactly. `huid.ts` stays untouched for its
 * module-level tests (`p9Reports.db.test.ts`); the screen and every export reach THIS file, so they can
 * never disagree (the account-ledger lesson).
 *
 * DESKTOP RULES, cited per view (`RP_HUID.cs` Tag_Summ, lines 1752-1875):
 *   In    — `from BAR_DETL AS C LEFT JOIN ITEM_MAST AS B` (RP_HUID.cs:1761), voucher date bounded by
 *           From and To inclusive, no movement condition, `ORDER BY C.TAG_NO` (:1790).
 *   Out   — `MAIN_STOCK AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE
 *           AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO` (:1799), `AND A.ITM_SIGN = '-'` (:1795),
 *           the movement's own voucher date bounded by From and To, `'' As KrName` (:1795), the account
 *           filter on A (`AND A.AC_CODE`), order `ORDER BY C.TAG_NO` (:1829).
 *   Stock — the availability rule is the desktop's serial sum, not a count:
 *           `HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0`
 *           (RP_HUID.cs:1873), over `MAIN_STOCK` movements joined on company, location, tag, serial AND
 *           item (`And A.IT_CODE = C.IT_CODE`, :1838). The date rule bounds only the To side of the
 *           tag's stock date: `AND C.STK_DATE <= '` (:1838). In PostgreSQL the HAVING becomes a grouped
 *           subquery joined back to `BAR_DETL`, so the desktop's 23-column GROUP BY is not needed.
 *   Every view excludes tag 'N' (`AND C.TAG_NO <> 'N'`, :1761/:1795/:1838) and With/Without HuId test the
 *   FIRST slot only (`AND C.HM_ID <> ''` / `AND C.HM_ID = ''`, :1764/:1768). A whitespace-only first slot is
 *   in neither mode (see `commonConditions`); the desktop's SQL Server trailing-space rule is why.
 *
 * NOT PORTED (desktop weaknesses, study "Desktop weaknesses" 1-4, 10): the four company-wide `BAR_DETL`
 * `UPDATE`s before every view (:1754-1757), the shared `TAG_STOCK_PRINT` staging table (:2140, :2168-2184)
 * and the global drill-down state. This report is read-only: `write.view-leaves-bar-detl-unchanged` and
 * `write.print-leaves-no-staging-rows` pin that. The merge flag's company-filter drop (:1795/:1838 with
 * `CO_STK_MERGE='Y'`) is not ported either — the company filter always applies (T11).
 *
 * Read-only and RLS-scoped: every table carries both the tenant row-level security (withTxBudget binds
 * the tenant) and an explicit `tenant_id` filter.
 */
export type HuidView = 'in' | 'out' | 'stock';

export class HuidTagReportValidationError extends Error {
  readonly statusCode = 400;
  constructor(message: string) {
    super(message);
    this.name = 'HuidTagReportValidationError';
  }
}

export interface HuidTagQuery {
  view: HuidView;
  /** ISO `YYYY-MM-DD`; required for in and out, ignored by stock (RP_HUID.cs:1838 bounds only To). */
  from?: string;
  /** ISO `YYYY-MM-DD`; required by every view (the desktop formats `mToDt.Text` into each query). */
  to: string;
  /** First letter of the desktop Item Type box (`B.IT_TYPE`, RP_HUID.cs:1778). */
  itemType?: 'G' | 'S';
  /** `B.PR_CODE` (RP_HUID.cs:1772). */
  product?: string;
  /** `B.GR_CODE` (RP_HUID.cs:1815). */
  group?: string;
  /** Exact `C.TAG_NO` (RP_HUID.cs:1784). */
  tagNo?: string;
  /** `C.AC_CODE` on In/Stock, `A.AC_CODE` on Out (RP_HUID.cs:1788, :1826). */
  acCode?: string;
  hallmark?: 'all' | 'with' | 'without';
  /** First HuId column that has a match wins (RP_HUID.cs:1669-1689). */
  search?: string;
}

export interface HuidTagColumn {
  key: string;
  /** The desktop grid shows the SELECT alias as its header (no designer caption exists; study Gap 18). */
  header: string;
  hidden: boolean;
  total: boolean;
}

export interface HuidTagRow {
  coCode: string | null;
  vchTyp: string | null;
  vchNo: string | null;
  vchDate: string | null;
  /** The Stock view's visible date: `C.STK_DATE As StkDate` (RP_HUID.cs:1838). */
  stkDate: string | null;
  tagNo: string;
  itCode: string | null;
  counter: string | null;
  /** The desktop selects the literal 1 (RP_HUID.cs:1761 `1 AS Qty`): one row is one tag. */
  qty: number;
  pcs: string;
  grwt: string;
  netWt: string;
  huId: string | null;
  huWt: string;
  huId2: string | null;
  huWt2: string;
  huId3: string | null;
  huWt3: string;
  huId4: string | null;
  huWt4: string;
  krName: string;
  book: string | null;
  bookName: string | null;
  itRemark: string | null;
  tagId: string | null;
  /** Hidden print-grouping columns (TagHuIdRpt.xml groups on ITEM_MAST.PR_CODE / GR_CODE). */
  prCode: string | null;
  grCode: string | null;
}

export interface HuidTagTotals {
  /** One per row (`1 AS Qty`), so the Qty total is the row count (RP_HUID.cs:2068). */
  qty: number;
  pcs: string;
  grwt: string;
  netWt: string;
  huWt: string;
  huWt2: string;
  huWt3: string;
  huWt4: string;
}

export interface HuidTagReport {
  view: HuidView;
  from: string;
  to: string;
  columns: HuidTagColumn[];
  rows: HuidTagRow[];
  totals: HuidTagTotals;
}

export interface HuidTagScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

const DATE_KEYS: ReadonlyArray<keyof HuidTagQuery> = ['from', 'to'];

/**
 * Integer thousandths, never floating point. The weight columns are `Decimal(14,3)` / `Decimal(12,3)`
 * (migration 20260627200423_init), so the database's own scale never exceeds three decimals and the rows
 * carry it as text; summing scaled integers cannot drift the way doubles do.
 */
const THOUSANDTHS = /^(-?)(\d+)(?:\.(\d+))?$/;

export function weightThousandths(value: unknown): number {
  const match = THOUSANDTHS.exec(String(value ?? '').trim());
  if (!match) return 0;
  const fraction = match[3] ? Number(match[3].slice(0, 3).padEnd(3, '0')) : 0;
  return (match[1] ? -1 : 1) * (Number(match[2]) * 1000 + fraction);
}

/** Render thousandths back with the database scale, e.g. 71000 -> '71.000'. */
export function thousandthsText(value: number): string {
  const sign = value < 0 ? '-' : '';
  const abs = Math.abs(value);
  return `${sign}${Math.floor(abs / 1000)}.${String(abs % 1000).padStart(3, '0')}`;
}

const text = (value: unknown): string | null => (value == null ? null : String(value));
const weight = (value: unknown): string => (value == null ? '' : String(value));

/** The desktop search (RP_HUID.cs:1669-1689): HuId, then HuId2, HuId3, HuId4 — the FIRST column with any
 *  match is the result; a column with no match is skipped, and no match anywhere clears the grid. The text
 *  is literal, so an apostrophe is just a character. */
export function applyHuidSearch(rows: HuidTagRow[], search: string | undefined): HuidTagRow[] {
  const needle = String(search ?? '')
    .trim()
    .toUpperCase();
  if (!needle) return rows;
  for (const key of ['huId', 'huId2', 'huId3', 'huId4'] as const) {
    const hits = rows.filter((row) =>
      String(row[key] ?? '')
        .toUpperCase()
        .includes(needle),
    );
    if (hits.length > 0) return hits;
  }
  return [];
}

const shortText = (query: Record<string, unknown>, key: string, max: number): string => {
  const value = String(query[key] ?? '').trim();
  if (value.length > max)
    throw new HuidTagReportValidationError(`${key} must be at most ${max} characters`);
  return value;
};

const isoDate = (query: Record<string, unknown>, key: string): string => {
  const raw = String(query[key] ?? '').trim();
  if (!raw) throw new HuidTagReportValidationError(`${key} is required as YYYY-MM-DD`);
  try {
    return toIsoDate(raw);
  } catch {
    throw new HuidTagReportValidationError(`${key} must be a real date as YYYY-MM-DD`);
  }
};

/**
 * Parse and validate the route query. Unknown parameters (`counter`, `itCode`, `tab`, …) are ignored, so
 * they cannot filter: the desktop has no counter or item-code condition (study Gaps 8 and 9, pinned by
 * `filter.counter-absent` and `filter.item-code-absent`). From after To is NOT an error — the desktop
 * compares no date order (study Rules), the window just matches nothing.
 */
export function parseHuidTagQuery(query: Record<string, unknown>): HuidTagQuery {
  const view = String(query.view ?? '')
    .trim()
    .toLowerCase();
  if (view !== 'in' && view !== 'out' && view !== 'stock')
    throw new HuidTagReportValidationError('view must be one of stock, in, or out');
  const q: HuidTagQuery = { view, from: undefined, to: '' };
  for (const key of DATE_KEYS) {
    if (String(query[key] ?? '').trim() === '') continue;
    if (key === 'to') q.to = isoDate(query, 'to');
    else q.from = isoDate(query, 'from');
  }
  if (!q.to) throw new HuidTagReportValidationError('to is required as YYYY-MM-DD');
  if (view !== 'stock' && !q.from)
    throw new HuidTagReportValidationError('from is required for the in and out views');
  const itemType = String(query.itemType ?? '')
    .trim()
    .toUpperCase();
  if (itemType && itemType !== 'G' && itemType !== 'S')
    throw new HuidTagReportValidationError('itemType must be G or S');
  if (itemType) q.itemType = itemType as 'G' | 'S';
  const hallmark = String(query.hallmark ?? '')
    .trim()
    .toLowerCase();
  if (hallmark && !['all', 'with', 'without'].includes(hallmark))
    throw new HuidTagReportValidationError('hallmark must be all, with, or without');
  if (hallmark && hallmark !== 'all') q.hallmark = hallmark as 'with' | 'without';
  // The desktop upper-cases every key (RP_HUID.cs:1715) and looks the tag and the account up by code.
  q.tagNo = shortText(query, 'tagNo', 40).toUpperCase();
  q.acCode = shortText(query, 'acCode', 40).toUpperCase();
  q.product = shortText(query, 'product', 40);
  q.group = shortText(query, 'group', 40);
  q.search = shortText(query, 'search', 60);
  if (!q.tagNo) delete q.tagNo;
  if (!q.acCode) delete q.acCode;
  if (!q.product) delete q.product;
  if (!q.group) delete q.group;
  if (!q.search) delete q.search;
  return q;
}

/** Bound parameter builder: every value is `$n`, never concatenated (study weakness 5). */
class Params {
  private values: unknown[] = [];
  push(value: unknown): string {
    this.values.push(value);
    return `$${this.values.length}`;
  }
  get list(): unknown[] {
    return this.values;
  }
}

interface BuildInput {
  scope: HuidTagScope;
  q: HuidTagQuery;
}

/** Company, location, year, the tag-'N' exclusion and the optional selectors shared by all three views. */
function commonConditions({ scope, q }: BuildInput, p: Params, alias: 'c' | 'a'): string[] {
  const filters = [
    `${alias}."tenant_id"::text=${p.push(scope.tenantId)}`,
    `${alias}."CO_CODE"::text=${p.push(scope.coCode)}`,
    `${alias}."LC_CODE"::text=${p.push(scope.lcCode)}`,
    `${alias}."CO_YEAR"::text=${p.push(scope.coYear)}`,
    `${alias}."TAG_NO"::text <> 'N'`,
  ];
  // With/Without test the FIRST slot only (RP_HUID.cs:1764 `AND C.HM_ID <> ''`, :1768 `AND C.HM_ID = ''`).
  // A whitespace-only slot is in NEITHER mode on the web (pinned by the two hallmark cases: the desktop's
  // `<> ''`/`= ''` pair is a SQL Server trailing-space comparison, which PostgreSQL does not reproduce with
  // one rule — `btrim` makes 'with' exclude it, a plain `= ''` makes 'without' exclude it). The disputed
  // classification is the blocked case `huid-report.hallmark.whitespace-only-first-slot`.
  const firstSlot = `${alias === 'a' ? 'c' : alias}."HM_ID"`;
  if (q.hallmark === 'with') filters.push(`btrim(coalesce(${firstSlot},'')) <> ''`);
  if (q.hallmark === 'without') filters.push(`coalesce(${firstSlot},'') = ''`);
  if (q.tagNo) filters.push(`${alias}."TAG_NO"::text=${p.push(q.tagNo)}`);
  return filters;
}

/**
 * Item-master selectors: product, group, item type (RP_HUID.cs:1772 `AND B.PR_CODE`, :1815 `AND B.GR_CODE`,
 * :1778 `AND B.IT_TYPE`). The Out view applies them on the movement's own item join
 * (`LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE`, :1799).
 */
function itemConditions({ q }: BuildInput, p: Params): string[] {
  const filters: string[] = [];
  if (q.product) filters.push(`b."PR_CODE"::text=${p.push(q.product)}`);
  if (q.group) filters.push(`b."GR_CODE"::text=${p.push(q.group)}`);
  if (q.itemType) filters.push(`b."IT_TYPE"::text=${p.push(q.itemType)}`);
  return filters;
}

/** The four HuId slot pairs, from the tag row (RP_HUID.cs:1761 `C.HM_ID As HuId,C.HM_ID_WT As HuWt,`). */
function slotColumns(alias: 'c' | 'a'): string {
  return [0, 1, 2, 3]
    .map((i) => {
      const n = i === 0 ? '' : String(i + 1);
      return `${alias}."HM_ID${n}" AS "huId${n}", ${alias}."HM_ID${n}_WT"::text AS "huWt${n}"`;
    })
    .join(', ');
}

function mapRow(raw: Record<string, unknown>): HuidTagRow {
  return {
    coCode: text(raw.coCode),
    vchTyp: text(raw.vchTyp),
    vchNo: text(raw.vchNo),
    vchDate: text(raw.vchDate),
    stkDate: text(raw.stkDate),
    tagNo: String(raw.tagNo ?? ''),
    itCode: text(raw.itCode),
    counter: text(raw.counter),
    qty: 1,
    pcs: weight(raw.pcs),
    grwt: weight(raw.grwt),
    netWt: weight(raw.netWt),
    huId: text(raw.huId),
    huWt: weight(raw.huWt),
    huId2: text(raw.huId2),
    huWt2: weight(raw.huWt2),
    huId3: text(raw.huId3),
    huWt3: weight(raw.huWt3),
    huId4: text(raw.huId4),
    huWt4: weight(raw.huWt4),
    krName: weight(raw.krName),
    book: text(raw.book),
    bookName: text(raw.bookName),
    itRemark: text(raw.itRemark),
    tagId: text(raw.tagId),
    prCode: text(raw.prCode),
    grCode: text(raw.grCode),
  };
}

/**
 * The In view (RP_HUID.cs:1761): every tag row of the window, joined to the live `ITEM_MAST` for the
 * product / group / item-type selectors (so a renamed master keeps its history, `history.group-renamed`).
 */
function inSql(input: BuildInput, p: Params): string {
  const { scope, q } = input;
  const filters = [
    ...commonConditions(input, p, 'c'),
    `c."VCH_DATE" >= ${p.push(q.from)}::date`,
    `c."VCH_DATE" <= ${p.push(q.to)}::date`,
    ...itemConditions(input, p),
  ];
  if (q.acCode) filters.push(`c."AC_CODE"::text=${p.push(q.acCode)}`);
  return `SELECT c."CO_CODE"::text AS "coCode", c."VCH_TYPE" AS "vchTyp", c."VCH_NO" AS "vchNo",
                 c."VCH_DATE"::text AS "vchDate", NULL AS "stkDate", c."TAG_NO" AS "tagNo",
                 c."IT_CODE" AS "itCode", c."TBL_CODE" AS "counter",
                 c."ITM_PCS"::text AS "pcs", c."ITM_GWT"::text AS "grwt", c."ITM_NWT"::text AS "netWt",
                 ${slotColumns('c')},
                 c."KR_NAME" AS "krName", c."CO_BOOK" AS "book", c."BOOK_NAME" AS "bookName",
                 c."ITM_REMARK" AS "itRemark", c."VCH_SRNO"::text AS "tagId",
                 b."PR_CODE" AS "prCode", b."GR_CODE" AS "grCode"
            FROM "BAR_DETL" c
            LEFT JOIN "ITEM_MAST" b
              ON b."tenant_id"::text=${p.push(scope.tenantId)}
             AND b."CO_CODE"::text=c."CO_CODE"::text AND b."IT_CODE"::text=c."IT_CODE"::text
           WHERE ${filters.join(' AND ')}
           ORDER BY c."TAG_NO", coalesce(c."VCH_SRNO",0)`;
}

/**
 * The Out view (RP_HUID.cs:1795/:1799, the non-merge branch): one row per sale movement (`ITM_SIGN='-'`),
 * dated by the movement's own voucher date, the tag's HuId slots, `'' As KrName`, the account on the
 * movement (`A.AC_CODE`), order by tag. The tag filter lands on the movement's `TAG_NO`, which the join
 * equates with the tag row's (`AND A.TAG_NO = C.TAG_NO`, :1799; the desktop writes `AND C.TAG_NO`).
 */
function outSql(input: BuildInput, p: Params): string {
  const { scope, q } = input;
  const filters = [
    ...commonConditions(input, p, 'a'),
    `a."VCH_DATE" >= ${p.push(q.from)}::date`,
    `a."VCH_DATE" <= ${p.push(q.to)}::date`,
    `a."ITM_SIGN"::text='-'`,
    ...itemConditions(input, p),
  ];
  if (q.acCode) filters.push(`a."AC_CODE"::text=${p.push(q.acCode)}`);
  return `SELECT a."CO_CODE"::text AS "coCode", a."VCH_TYPE" AS "vchTyp", a."VCH_NO" AS "vchNo",
                 a."VCH_DATE"::text AS "vchDate", NULL AS "stkDate", c."TAG_NO" AS "tagNo",
                 a."IT_CODE" AS "itCode", a."TBL_CODE" AS "counter",
                 a."ITM_PCS"::text AS "pcs", a."ITM_GWT"::text AS "grwt", a."ITM_NWT"::text AS "netWt",
                 ${slotColumns('c')},
                 '' AS "krName", a."CO_BOOK" AS "book", a."BOOK_NAME" AS "bookName",
                 c."ITM_REMARK" AS "itRemark", a."VCH_SRNO"::text AS "tagId",
                 b."PR_CODE" AS "prCode", b."GR_CODE" AS "grCode"
            FROM "MAIN_STOCK" a
           INNER JOIN "BAR_DETL" c
              ON c."tenant_id"::text=${p.push(scope.tenantId)}
             AND a."CO_CODE"::text=c."CO_CODE"::text AND a."LC_CODE"::text=c."LC_CODE"::text
             AND a."TAG_NO"::text=c."TAG_NO"::text AND a."VCH_SRNO"=c."VCH_SRNO"
            LEFT JOIN "ITEM_MAST" b
              ON b."tenant_id"::text=${p.push(scope.tenantId)}
             AND b."CO_CODE"::text=a."CO_CODE"::text AND b."IT_CODE"::text=a."IT_CODE"::text
           WHERE ${filters.join(' AND ')}
           ORDER BY c."TAG_NO", coalesce(a."VCH_SRNO",0)`;
}

/**
 * The Stock view (RP_HUID.cs:1838 non-merge, :1873 HAVING): tag rows whose movement serials still sum
 * above zero, bounded by the tag's stock date on the To side only. The desktop's `HAVING` over the joined
 * rows becomes a grouped `MAIN_STOCK` subquery joined back on the same key (company, location, tag,
 * serial, item — `And A.IT_CODE = C.IT_CODE`, :1838), which is the same arithmetic per tag instance.
 */
function stockSql(input: BuildInput, p: Params): string {
  const { scope, q } = input;
  const filters = [
    ...commonConditions(input, p, 'c'),
    `c."STK_DATE"::text <= ${p.push(q.to)}`,
    ...itemConditions(input, p),
  ];
  if (q.acCode) filters.push(`c."AC_CODE"::text=${p.push(q.acCode)}`);
  return `SELECT c."CO_CODE"::text AS "coCode", c."VCH_TYPE" AS "vchTyp", c."VCH_NO" AS "vchNo",
                 c."STK_DATE"::text AS "stkDate", c."VCH_DATE"::text AS "vchDate", c."TAG_NO" AS "tagNo",
                 s."IT_CODE" AS "itCode", c."TBL_CODE" AS "counter",
                 c."ITM_PCS"::text AS "pcs", c."ITM_GWT"::text AS "grwt", c."ITM_NWT"::text AS "netWt",
                 ${slotColumns('c')},
                 c."KR_NAME" AS "krName", c."CO_BOOK" AS "book", c."BOOK_NAME" AS "bookName",
                 c."ITM_REMARK" AS "itRemark", c."VCH_SRNO"::text AS "tagId",
                 b."PR_CODE" AS "prCode", b."GR_CODE" AS "grCode"
            FROM "BAR_DETL" c
           INNER JOIN (
                  SELECT m."CO_CODE", m."LC_CODE", m."TAG_NO", m."VCH_SRNO", m."IT_CODE"
                    FROM "MAIN_STOCK" m
                   WHERE m."tenant_id"::text=${p.push(scope.tenantId)}
                     AND m."CO_CODE"::text=${p.push(scope.coCode)}
                     AND m."LC_CODE"::text=${p.push(scope.lcCode)}
                     AND m."CO_YEAR"::text=${p.push(scope.coYear)}
                     AND m."TAG_NO"::text <> 'N'
                   GROUP BY m."CO_CODE", m."LC_CODE", m."TAG_NO", m."VCH_SRNO", m."IT_CODE"
                  HAVING SUM(CASE WHEN m."ITM_SIGN"::text='+'
                                  THEN coalesce(m."VCH_SRNO",0) ELSE -coalesce(m."VCH_SRNO",0) END) > 0
                ) s
              ON s."CO_CODE"::text=c."CO_CODE"::text AND s."LC_CODE"::text=c."LC_CODE"::text
             AND s."TAG_NO"::text=c."TAG_NO"::text AND s."VCH_SRNO"=c."VCH_SRNO"
             AND s."IT_CODE"::text=c."IT_CODE"::text
            LEFT JOIN "ITEM_MAST" b
              ON b."tenant_id"::text=${p.push(scope.tenantId)}
             AND b."CO_CODE"::text=c."CO_CODE"::text AND b."IT_CODE"::text=s."IT_CODE"::text
           WHERE ${filters.join(' AND ')}
           ORDER BY c."TAG_NO", coalesce(c."VCH_SRNO",0)`;
}

/** The 24 desktop columns in SELECT order (RP_HUID.cs:1761), plus the hidden print grouping columns.
 *  Stock shows `StkDate` where In and Out show `VchDate` (RP_HUID.cs:1838); the hidden vchDate stays on
 *  every stock row because the print selection filters the voucher date (RP_HUID.cs:2219). */
export function huidTagColumns(view: HuidView): HuidTagColumn[] {
  const col = (
    key: string,
    header: string,
    extra: { hidden?: boolean; total?: boolean } = {},
  ): HuidTagColumn => ({
    key,
    header,
    hidden: extra.hidden === true,
    total: extra.total === true,
  });
  const columns: HuidTagColumn[] = [
    col('coCode', 'CoCode', { hidden: true }),
    col('vchTyp', 'VchTyp'),
    col('vchNo', 'VchNo'),
  ];
  if (view === 'stock') {
    columns.push(col('stkDate', 'StkDate'));
    columns.push(col('vchDate', 'VchDate', { hidden: true }));
  } else {
    columns.push(col('vchDate', 'VchDate'));
    columns.push(col('stkDate', 'StkDate', { hidden: true }));
  }
  columns.push(
    col('tagNo', 'TagNo'),
    col('itCode', 'ItCode'),
    col('counter', 'Counter'),
    col('qty', 'Qty', { total: true }),
    col('pcs', 'Pcs', { total: true }),
    col('grwt', 'Grwt', { total: true }),
    col('netWt', 'NetWt', { total: true }),
    col('huId', 'HuId'),
    col('huWt', 'HuWt', { total: true }),
    col('huId2', 'HuId2'),
    col('huWt2', 'HuWt2', { total: true }),
    col('huId3', 'HuId3'),
    col('huWt3', 'HuWt3', { total: true }),
    col('huId4', 'HuId4'),
    col('huWt4', 'HuWt4', { total: true }),
    col('krName', 'KrName'),
    col('book', 'Book', { hidden: true }),
    col('bookName', 'BookName', { hidden: true }),
    col('itRemark', 'ItRemark'),
    col('tagId', 'TagId'),
    col('prCode', 'PrCode', { hidden: true }),
    col('grCode', 'GrCode', { hidden: true }),
  );
  return columns;
}

/**
 * The grid footer sums (RP_HUID.cs:2068-2096, one sum per column): Qty, Pcs, Grwt, NetWt and the four
 * HuId slot weights, over the rows the search kept — the desktop's search shrinks the grid before Excel
 * prints it (RP_HUID.cs:1365), so the totals must follow the rows as shown.
 */
export function huidTagTotals(rows: HuidTagRow[]): HuidTagTotals {
  const sum = (key: 'pcs' | 'grwt' | 'netWt' | 'huWt' | 'huWt2' | 'huWt3' | 'huWt4'): string =>
    thousandthsText(rows.reduce((acc, row) => acc + weightThousandths(row[key]), 0));
  return {
    qty: rows.length,
    pcs: sum('pcs'),
    grwt: sum('grwt'),
    netWt: sum('netWt'),
    huWt: sum('huWt'),
    huWt2: sum('huWt2'),
    huWt3: sum('huWt3'),
    huWt4: sum('huWt4'),
  };
}

/** Resolve one view. Read-only: no `BAR_DETL` write, no staging table (study weaknesses 1-4). */
export async function huidTagReport(
  prisma: any,
  scope: HuidTagScope,
  q: HuidTagQuery,
): Promise<HuidTagReport> {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear)
    throw new HuidTagReportValidationError('session scope is incomplete');
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const p = new Params();
    const input: BuildInput = { scope, q };
    const sql =
      q.view === 'in' ? inSql(input, p) : q.view === 'out' ? outSql(input, p) : stockSql(input, p);
    const raw: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(sql, ...p.list);
    const mapped = raw.map(mapRow);
    const rows = applyHuidSearch(mapped, q.search);
    return {
      view: q.view,
      from: q.from ?? '',
      to: q.to,
      columns: huidTagColumns(q.view),
      rows,
      totals: huidTagTotals(rows),
    };
  });
}
