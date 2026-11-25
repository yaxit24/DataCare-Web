import type { RpAllFilters, RpAllSessionScope } from './filters.js';
import type { SqlQuery } from './salesQuery.js';
import type { PurchaseFilterKey, PurchaseQueryShape } from './purchaseLayouts.js';

/**
 * Read-only SQL for the Purchase branch of RP_ALL: PR_DATA LEFT JOIN PR_DETL LEFT JOIN PR_IDTL, the shape the
 * Crystal templates read (PurcReport.xml TableLinks). Same rules as salesQuery.ts: every fragment is a constant
 * chosen by the mode's shape, every request value is a bound parameter, masters are looked up once per row with
 * LATERAL ... LIMIT 1 (AC_MAST, BOOK_DATA, PRODUCT_MAST and GROUP_MAST have no unique key in the schema), and
 * company, year and location are explicit predicates besides forced row-level security.
 *
 * The desktop appends `{BOOK_DATA.DATA_TYPE} = 'A'|'B'` when the session data type is A or B
 * (RP_ALL.cs:7653-7660). The web has no session data type (Ctrl+A/B/C of MDI_FORM.cs:12720-12760 is not ported),
 * so that predicate is never added; see docs/parity/rpall-purchase-inventory.md.
 */

export interface PurchaseQueryArgs {
  shape: PurchaseQueryShape;
  scope: RpAllSessionScope;
  filters: RpAllFilters;
  /** Only the filters the mode's click handler applies. */
  applied: ReadonlySet<PurchaseFilterKey>;
}

const NUM = (expr: string) => `COALESCE(${expr}, 0)::float8`;

const HEADER_COLUMNS: readonly [string, string][] = [
  ['lcCode', 'd."LC_CODE"'],
  ['coYear', 'd."CO_YEAR"'],
  ['coBook', 'd."CO_BOOK"'],
  ['vchNo', 'd."VCH_NO"'],
  ['vchDate', `to_char(d."VCH_DATE", 'YYYY-MM-DD')`],
  ['billNo', 'd."BILL_NO"'],
  ['acCode', 'd."AC_CODE"'],
  ['acName', 'd."AC_NAME"'],
  ['netAmt', NUM('d."NET_AMT"')],
  ['discAmt', NUM('d."DISC_AMT"')],
  ['taxAmt', NUM('d."TAX_AMT"')],
  ['rofAmt', NUM('d."ROF_AMT"')],
  ['totAmt', NUM('d."TOT_AMT"')],
  ['cgstTax', NUM('d."CGST_TAX"')],
  ['sgstTax', NUM('d."SGST_TAX"')],
  ['igstTax', NUM('d."IGST_TAX"')],
  ['cashAmt', NUM('d."CASH_AMT"')],
  ['cardAmt', NUM('d."CARD_AMT"')],
  ['chqAmt', NUM('d."CHQ_AMT"')],
  ['kasarAmt', NUM('d."KASAR_AMT"')],
  ['billOs', NUM('d."BILL_OS"')],
  ['partyName', 'ac."AC_NAME"'],
  ['city', 'ac."AC_CITY"'],
  ['bookName', 'bk."BOOK_NAME"'],
  ['bookSName', 'bk."BOOK_SNAME"'],
  ['bookSrName', 'bk."BOOK_SR_NAME"'],
  ['bookInout', 'bk."BOOK_INOUT"'],
];

const LINE_COLUMNS: readonly [string, string][] = [
  ['srNo', 'l."SR_NO"::float8'],
  ['tagNo', 'l."TAG_NO"'],
  ['itCode', 'l."IT_CODE"'],
  ['itName', 'im."IT_NAME"'],
  ['itType', 'im."IT_TYPE"'],
  ['prCode', 'im."PR_CODE"'],
  ['grCode', 'im."GR_CODE"'],
  ['grName', 'gm."GR_NAME"'],
  ['hsn', 'im."HSN_CODE"'],
  ['pcs', NUM('l."ITM_PCS"')],
  ['gwt', NUM('l."ITM_GWT"')],
  ['nwt', NUM('l."ITM_NWT"')],
  ['touch', NUM('l."ITM_TOUCH"')],
  ['westPrc', NUM('l."ITM_WEST_PRC"')],
  ['fine', NUM('l."ITM_FINE"')],
  ['rate', NUM('l."ITM_RATE"')],
  ['lbrRate', NUM('l."LBR_RATE"')],
  ['lbrAmt', NUM('l."LBR_AMT"')],
  ['othAmt', NUM('l."OTH_AMT"')],
  ['itmAmtLine', NUM('l."ITM_AMT"')],
  ['mrp', NUM('l."ITM_MRP"')],
  ['lineTotAmt', NUM('l."TOT_AMT"')],
  ['lineNetAmt', NUM('l."NET_AMT"')],
];

const SUB_COLUMNS: readonly [string, string][] = [
  ['subSrNo', 's."ISR_NO"::float8'],
  ['subItName', 'sim."IT_NAME"'],
  ['subPcs', NUM('s."IT_PCS"')],
  ['subGwt', NUM('s."IT_GWT"')],
  ['subRate', NUM('s."IT_RATE"')],
  ['subNetAmt', NUM('s."IT_NET_AMT"')],
];

const PARTY_JOIN = `LEFT JOIN LATERAL (SELECT a."AC_NAME", a."AC_CITY", a."AC_AREA"
       FROM "AC_MAST" a WHERE a."CO_CODE" = d."CO_CODE" AND a."AC_CODE" = d."AC_CODE"
       ORDER BY (a."LC_CODE" = d."LC_CODE") DESC NULLS LAST, a."row_id" LIMIT 1) ac ON true`;
const BOOK_JOIN = `LEFT JOIN LATERAL (SELECT b."BOOK_NAME", b."BOOK_SNAME", b."BOOK_SR_NAME", b."BOOK_INOUT"
       FROM "BOOK_DATA" b WHERE b."CO_CODE" = d."CO_CODE" AND b."CO_BOOK" = d."CO_BOOK"
       ORDER BY (b."LC_CODE" = d."LC_CODE") DESC NULLS LAST, b."row_id" LIMIT 1) bk ON true`;
const LINE_JOIN = `LEFT JOIN "PR_DETL" l ON l."CO_CODE" = d."CO_CODE" AND l."LC_CODE" = d."LC_CODE" AND l."CO_YEAR" = d."CO_YEAR"
       AND l."CO_BOOK" = d."CO_BOOK" AND l."VCH_NO" = d."VCH_NO"
     LEFT JOIN "ITEM_MAST" im ON im."CO_CODE" = l."CO_CODE" AND im."IT_CODE" = l."IT_CODE"
     LEFT JOIN LATERAL (SELECT g."GR_NAME" FROM "GROUP_MAST" g
       WHERE g."CO_CODE" = im."CO_CODE" AND g."GR_CODE" = im."GR_CODE" ORDER BY g."row_id" LIMIT 1) gm ON true`;
const SUB_JOIN = `LEFT JOIN "PR_IDTL" s ON s."CO_CODE" = l."CO_CODE" AND s."LC_CODE" = l."LC_CODE" AND s."CO_YEAR" = l."CO_YEAR"
       AND s."CO_BOOK" = l."CO_BOOK" AND s."VCH_NO" = l."VCH_NO" AND s."SR_NO" = l."SR_NO"
     LEFT JOIN "ITEM_MAST" sim ON sim."CO_CODE" = s."CO_CODE" AND sim."IT_CODE" = s."IT_CODE"`;

const select = (columns: readonly [string, string][]) =>
  columns.map(([alias, expr]) => `${expr} AS "${alias}"`).join(',\n       ');

/** Build the parameterised query for one mode. */
export function buildPurchaseQuery(input: PurchaseQueryArgs): SqlQuery {
  const { shape, scope, filters, applied } = input;
  const values: unknown[] = [];
  const p = (value: unknown, cast = '') => {
    values.push(value);
    return `$${values.length}${cast}`;
  };
  // {PR_DATA.CO_CODE} = company AND {PR_DATA.CO_YEAR} = year AND {PR_DATA.VCH_DATE} >= From AND <= To
  // (RP_ALL.cs:7957-7958; the formula tests the header's date, not the line's).
  const where: string[] = [
    `d."CO_CODE" = ${p(scope.coCode)}`,
    `d."CO_YEAR" = ${p(scope.coYear)}`,
    `d."VCH_DATE"::date >= ${p(filters.fromDate, '::date')}`,
    `d."VCH_DATE"::date <= ${p(filters.toDate, '::date')}`,
  ];
  if (shape.guardNetAmt) where.push(`d."NET_AMT" <> 0`);
  const has = (key: PurchaseFilterKey) => applied.has(key) && filters[key] !== undefined;
  if (applied.has('lcCode') && filters.lcCode !== null)
    where.push(`d."LC_CODE" = ${p(filters.lcCode)}`);
  if (has('coBook')) where.push(`d."CO_BOOK" = ${p(filters.coBook)}`);
  if (has('acCode')) where.push(`d."AC_CODE" = ${p(filters.acCode)}`);
  if (has('city')) where.push(`ac."AC_CITY" = ${p(filters.city)}`);
  if (has('area')) where.push(`ac."AC_AREA" = ${p(filters.area)}`);
  if (has('prCode')) where.push(`im."PR_CODE" = ${p(filters.prCode)}`);
  if (has('grCode')) where.push(`im."GR_CODE" = ${p(filters.grCode)}`);
  if (has('itemType')) where.push(`im."IT_TYPE" = ${p(filters.itemType)}`);

  const columns: [string, string][] = [...HEADER_COLUMNS];
  const joins: string[] = [PARTY_JOIN, BOOK_JOIN];
  if (shape.lines) {
    columns.push(...LINE_COLUMNS);
    joins.push(LINE_JOIN);
    if (shape.subs) {
      columns.push(...SUB_COLUMNS);
      joins.push(SUB_JOIN);
    }
  }
  const text = `SELECT ${select(columns)}
  FROM "PR_DATA" d
     ${joins.join('\n     ')}
 WHERE ${where.join('\n   AND ')}`;
  return { text, values };
}
