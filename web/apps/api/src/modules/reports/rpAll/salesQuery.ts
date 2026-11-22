import type { RpAllFilters, RpAllSessionScope } from './filters.js';
import type { SalesFilterKey, SalesQueryShape } from './salesLayouts.js';

/**
 * Read-only SQL for the Sales branch of RP_ALL.
 *
 * Every fragment below is a constant chosen by the query SHAPE (which comes from the mode table, never from
 * the request); every request value is pushed to `values` and referenced as `$n`. The desktop builds the
 * same predicates by concatenating control text into a Crystal formula (RP_ALL.cs:7618-7665) — that
 * weakness is not ported.
 *
 * The query reproduces the template's record set: SL_DATA LEFT JOIN lines LEFT JOIN sub-lines, with the
 * masters looked up once per row (LATERAL ... LIMIT 1, because AC_MAST, BOOK_DATA, EMP_MAST, PRODUCT_MAST
 * and GROUP_MAST have no unique key in the schema and a duplicate master row must not duplicate a sale).
 * Tenant isolation comes from forced RLS on every table read inside withTxBudget; company, year and
 * location are explicit predicates as well.
 */

export interface SqlQuery {
  text: string;
  values: unknown[];
}

export interface SalesQueryArgs {
  shape: SalesQueryShape;
  scope: RpAllSessionScope;
  filters: RpAllFilters;
  /** Only the filters the mode's click handler applies. */
  applied: ReadonlySet<SalesFilterKey>;
  orderOnly: boolean;
}

const NUM = (expr: string) => `COALESCE(${expr}, 0)::float8`;

const HEADER_COLUMNS: readonly [string, string][] = [
  ['lcCode', 'd."LC_CODE"'],
  ['coBook', 'd."CO_BOOK"'],
  ['vchNo', 'd."VCH_NO"'],
  ['vchDate', `to_char(d."VCH_DATE", 'YYYY-MM-DD')`],
  ['billNo', 'd."BILL_NO"'],
  ['acCode', 'd."AC_CODE"'],
  ['acName', 'd."AC_NAME"'],
  ['empCode', 'd."EMP_CODE"'],
  ['netAmt', NUM('d."NET_AMT"')],
  ['discAmt', NUM('d."DISC_AMT"')],
  ['taxAmt', NUM('d."TAX_AMT"')],
  ['rofAmt', NUM('d."ROF_AMT"')],
  ['totAmt', NUM('d."TOT_AMT"')],
  ['cgstTax', NUM('d."CGST_TAX"')],
  ['sgstTax', NUM('d."SGST_TAX"')],
  ['cashAmt', NUM('d."CASH_AMT"')],
  ['chqAmt', NUM('d."CHQ_AMT"')],
  ['cardAmt', NUM('d."CARD_AMT"')],
  ['advAmt', NUM('d."ADV_AMT"')],
  ['oldGlAmt', NUM('d."OLD_GL_AMT"')],
  ['oldSlAmt', NUM('d."OLD_SL_AMT"')],
  ['kasarAmt', NUM('d."KASAR_AMT"')],
  ['billOs', NUM('d."BILL_OS"')],
  ['rtnNetAmt', NUM('d."RTN_NET_AMT"')],
  ['rtnTotAmt', NUM('d."RTN_TOT_AMT"')],
  ['rtnCashAmt', NUM('d."RTN_CASH_AMT"')],
  ['rtnCardAmt', NUM('d."RTN_CARD_AMT"')],
  ['rtnChqAmt', NUM('d."RTN_CHQ_AMT"')],
  ['rtnKasarAmt', NUM('d."RTN_KASAR_AMT"')],
  ['rtnBillOs', NUM('d."RTN_BILL_OS"')],
  ['empName', 'em."EMP_NAME"'],
];

const PARTY_COLUMNS: readonly [string, string][] = [
  ['partyName', 'ac."AC_NAME"'],
  ['city', 'ac."AC_CITY"'],
  ['mobile', 'ac."AC_MOBILE"'],
  ['panNo', 'ac."AC_PANNO"'],
  ['gstNo', 'ac."AC_GSTNO"'],
];

const BOOK_COLUMNS: readonly [string, string][] = [
  ['bookName', 'bk."BOOK_NAME"'],
  ['bookSName', 'bk."BOOK_SNAME"'],
];

const LINE_COLUMNS: readonly [string, string][] = [
  ['srNo', 'l."SR_NO"::float8'],
  ['tagNo', 'l."TAG_NO"'],
  ['itCode', 'l."IT_CODE"'],
  ['itName', 'im."IT_NAME"'],
  ['itType', 'im."IT_TYPE"'],
  ['prCode', 'im."PR_CODE"'],
  ['prName', 'pm."PR_NAME"'],
  ['grCode', 'im."GR_CODE"'],
  ['grName', 'gm."GR_NAME"'],
  ['pcs', NUM('l."ITM_PCS"')],
  ['gwt', NUM('l."ITM_GWT"')],
  ['nwt', NUM('l."ITM_NWT"')],
  ['rate', NUM('l."ITM_RATE"')],
  ['lbrRate', NUM('l."LBR_RATE"')],
  ['lbrAmt', NUM('l."LBR_AMT"')],
  ['othAmt', NUM('l."OTH_AMT"')],
  ['itmAmtLine', NUM('l."ITM_AMT"')],
  ['mrp', NUM('l."ITM_MRP"')],
  ['lineTotAmt', NUM('l."TOT_AMT"')],
  ['lineNetAmt', NUM('l."NET_AMT"')],
];

/** SL_DETL-only columns (SL_DETL_RTN has no tax/discount split or order reference). */
const SALE_LINE_COLUMNS: readonly [string, string][] = [
  ['itTaxAmt', NUM('l."IT_TAX_AMT"')],
  ['itDiscAmt', NUM('l."IT_DISC_AMT"')],
  ['vchType', 'l."VCH_TYPE"'],
  ['ordNo', 'l."ORD_NO"'],
  ['ordYrcd', 'l."ORD_YRCD"'],
  ['ordDbcd', 'l."ORD_DBCD"'],
];

const SUB_COLUMNS: readonly [string, string][] = [
  ['subSrNo', 's."ISR_NO"::float8'],
  ['subItName', 'sim."IT_NAME"'],
  ['subPcs', NUM('s."IT_PCS"')],
  ['subGwt', NUM('s."IT_GWT"')],
  ['subRate', NUM('s."IT_RATE"')],
  ['subNetAmt', NUM('s."IT_NET_AMT"')],
];

/** Master lookups shared by both FROM shapes; `h` is the alias carrying CO_CODE/LC_CODE/AC_CODE/CO_BOOK. */
const partyJoin = (h: string) =>
  `LEFT JOIN LATERAL (SELECT a."AC_NAME", a."AC_CITY", a."AC_AREA", a."AC_STATE", a."AC_MOBILE", a."AC_PANNO", a."AC_GSTNO"
       FROM "AC_MAST" a WHERE a."CO_CODE" = ${h}."CO_CODE" AND a."AC_CODE" = ${h}."AC_CODE"
       ORDER BY (a."LC_CODE" = ${h}."LC_CODE") DESC NULLS LAST, a."row_id" LIMIT 1) ac ON true`;
const bookJoin = (h: string) =>
  `LEFT JOIN LATERAL (SELECT b."BOOK_NAME", b."BOOK_SNAME", b."DATA_TYPE"
       FROM "BOOK_DATA" b WHERE b."CO_CODE" = ${h}."CO_CODE" AND b."CO_BOOK" = ${h}."CO_BOOK"
       ORDER BY (b."LC_CODE" = ${h}."LC_CODE") DESC NULLS LAST, b."row_id" LIMIT 1) bk ON true`;
const itemJoins = `LEFT JOIN "ITEM_MAST" im ON im."CO_CODE" = l."CO_CODE" AND im."IT_CODE" = l."IT_CODE"
     LEFT JOIN LATERAL (SELECT p."PR_NAME" FROM "PRODUCT_MAST" p
       WHERE p."CO_CODE" = im."CO_CODE" AND p."PR_CODE" = im."PR_CODE" ORDER BY p."row_id" LIMIT 1) pm ON true
     LEFT JOIN LATERAL (SELECT g."GR_NAME" FROM "GROUP_MAST" g
       WHERE g."CO_CODE" = im."CO_CODE" AND g."GR_CODE" = im."GR_CODE" ORDER BY g."row_id" LIMIT 1) gm ON true`;
const empJoin = `LEFT JOIN LATERAL (SELECT e."EMP_NAME" FROM "EMP_MAST" e
       WHERE e."CO_CODE" = d."CO_CODE" AND e."EMP_CODE" = d."EMP_CODE" ORDER BY e."row_id" LIMIT 1) em ON true`;
const lineJoin = (table: 'SL_DETL' | 'SL_DETL_RTN') =>
  `LEFT JOIN "${table}" l ON l."CO_CODE" = d."CO_CODE" AND l."LC_CODE" = d."LC_CODE" AND l."CO_YEAR" = d."CO_YEAR"
       AND l."CO_BOOK" = d."CO_BOOK" AND l."VCH_NO" = d."VCH_NO"`;
const subJoin = (table: 'SL_IDTL' | 'BAR_IDTL') =>
  `LEFT JOIN "${table}" s ON s."CO_CODE" = l."CO_CODE" AND s."LC_CODE" = l."LC_CODE" AND s."CO_YEAR" = l."CO_YEAR"
       AND s."CO_BOOK" = l."CO_BOOK" AND s."VCH_NO" = l."VCH_NO" AND s."SR_NO" = l."SR_NO"
     LEFT JOIN "ITEM_MAST" sim ON sim."CO_CODE" = s."CO_CODE" AND sim."IT_CODE" = s."IT_CODE"`;

const select = (columns: readonly [string, string][]) =>
  columns.map(([alias, expr]) => `${expr} AS "${alias}"`).join(',\n       ');

/**
 * Build the parameterised query. `applied` decides which of the request's filters become predicates; a
 * filter the mode's handler does not append is left out exactly as the desktop leaves it out.
 */
export function buildSalesQuery(input: SalesQueryArgs): SqlQuery {
  const { shape, scope, filters, applied } = input;
  const values: unknown[] = [];
  const p = (value: unknown, cast = '') => {
    values.push(value);
    return `$${values.length}${cast}`;
  };
  // h = the alias whose columns the formula tests ({SL_DATA.*}, or {SL_DETL.*} for Sale With Order).
  const h = shape.from === 'detail' ? 'l' : 'd';
  const where: string[] = [
    `${h}."CO_CODE" = ${p(scope.coCode)}`,
    `${h}."CO_YEAR" = ${p(scope.coYear)}`,
    `${h}."VCH_DATE"::date >= ${p(filters.fromDate, '::date')}`,
    `${h}."VCH_DATE"::date <= ${p(filters.toDate, '::date')}`,
  ];
  if (shape.guard === 'NET_AMT') where.push(`d."NET_AMT" <> 0`);
  if (shape.guard === 'RTN_NET_AMT') where.push(`d."RTN_NET_AMT" <> 0`);
  if (input.orderOnly) where.push(`l."ORD_NO" <> ''`);

  const has = (key: SalesFilterKey) => applied.has(key) && filters[key] !== undefined;
  // The location filter is applied whenever a location is set: tLcCode always holds the session location
  // unless a head-office user cleared it (RP_ALL.cs:6660-6671, filters.ts).
  if (applied.has('lcCode') && filters.lcCode !== null)
    where.push(`${h}."LC_CODE" = ${p(filters.lcCode)}`);
  if (has('coBook')) where.push(`${h}."CO_BOOK" = ${p(filters.coBook)}`);
  if (has('books')) where.push(`${h}."CO_BOOK" = ANY(${p(filters.books, '::text[]')})`);
  if (has('acCode')) where.push(`${h}."AC_CODE" = ${p(filters.acCode)}`);
  if (has('city')) where.push(`ac."AC_CITY" = ${p(filters.city)}`);
  if (has('area')) where.push(`ac."AC_AREA" = ${p(filters.area)}`);
  if (has('state')) where.push(`ac."AC_STATE" = ${p(filters.state)}`);
  if (has('empCode')) where.push(`d."EMP_CODE" = ${p(filters.empCode)}`);
  if (has('prCode')) where.push(`im."PR_CODE" = ${p(filters.prCode)}`);
  if (has('grCode')) where.push(`im."GR_CODE" = ${p(filters.grCode)}`);
  if (has('itemType')) where.push(`im."IT_TYPE" = ${p(filters.itemType)}`);

  const columns: [string, string][] = [];
  const joins: string[] = [];
  let from: string;
  if (shape.from === 'detail') {
    from = `"SL_DETL" l`;
    columns.push(
      ['lcCode', 'l."LC_CODE"'],
      ['coBook', 'l."CO_BOOK"'],
      ['vchNo', 'l."VCH_NO"'],
      ['vchDate', `to_char(l."VCH_DATE", 'YYYY-MM-DD')`],
      ['acCode', 'l."AC_CODE"'],
      ...LINE_COLUMNS,
      ...SALE_LINE_COLUMNS,
      ['partyName', 'ac."AC_NAME"'],
      ...BOOK_COLUMNS,
    );
    joins.push(itemJoins, partyJoin('l'), bookJoin('l'));
  } else {
    from = `"SL_DATA" d`;
    columns.push(...HEADER_COLUMNS, ...PARTY_COLUMNS, ...BOOK_COLUMNS);
    joins.push(partyJoin('d'), bookJoin('d'), empJoin);
    if (shape.lines) {
      columns.push(...LINE_COLUMNS);
      if (shape.lines === 'SL_DETL') columns.push(...SALE_LINE_COLUMNS);
      joins.push(lineJoin(shape.lines), itemJoins);
      if (shape.subs) {
        columns.push(...SUB_COLUMNS);
        joins.push(subJoin(shape.subs));
      }
    }
  }
  const text = `SELECT ${select(columns)}
  FROM ${from}
     ${joins.join('\n     ')}
 WHERE ${where.join('\n   AND ')}`;
  return { text, values };
}
