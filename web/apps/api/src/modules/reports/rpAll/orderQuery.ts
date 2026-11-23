import type { RpAllFilters, RpAllSessionScope } from './filters.js';
import type { OrderFilterKey, OrderQueryShape } from './orderLayouts.js';

/**
 * Read-only SQL for the Order branch of RP_ALL.
 *
 * Every fragment is a constant chosen by the query SHAPE; request values are bound.
 * The desktop builds Crystal formulas by concatenating control text (RP_ALL.cs:8380-8403,
 * :12608-12631) — that weakness is not ported.
 */

export interface SqlQuery {
  text: string;
  values: unknown[];
}

export interface OrderQueryArgs {
  shape: OrderQueryShape;
  scope: RpAllSessionScope;
  filters: RpAllFilters;
  /** Only the filters the mode's click handler applies. */
  applied: ReadonlySet<OrderFilterKey>;
}

const NUM = (expr: string) => `COALESCE(${expr}, 0)::float8`;

const HEADER_COLUMNS: readonly [string, string][] = [
  ['lcCode', 'd."LC_CODE"'],
  ['coBook', 'd."CO_BOOK"'],
  ['coYear', 'd."CO_YEAR"'],
  ['vchNo', 'd."VCH_NO"'],
  ['vchDate', `to_char(d."VCH_DATE", 'YYYY-MM-DD')`],
  ['acCode', 'd."AC_CODE"'],
  ['acName', 'd."AC_NAME"'],
  ['totAmt', NUM('d."TOT_AMT"')],
  ['advAmt', NUM('d."ADV_AMT"')],
  ['cashAmt', NUM('d."CASH_AMT"')],
  ['cardAmt', NUM('d."CARD_AMT"')],
  ['chqAmt', NUM('d."CHQ_AMT"')],
  ['oldGlAmt', NUM('d."OLD_GL_AMT"')],
  ['oldSlAmt', NUM('d."OLD_SL_AMT"')],
  // DEL_DATE is a varchar on SL_ORD_DATA (schema.prisma:6102), not a date: select it as stored text.
  ['delDate', 'd."DEL_DATE"'],
];

const LINE_COLUMNS: readonly [string, string][] = [
  ['srNo', 'l."SR_NO"::float8'],
  ['itCode', 'l."IT_CODE"'],
  ['itName', 'im."IT_NAME"'],
  ['designNo', 'l."DESIGN_NO"'],
  ['tagNo', 'l."TAG_NO"'],
  ['itmSize', 'l."ITM_SIZE"'],
  ['pcs', NUM('l."ITM_PCS"')],
  ['nwt', NUM('l."ITM_NWT"')],
  ['itmRate', NUM('l."ITM_RATE"')],
  ['itmAmt', NUM('l."ITM_AMT"')],
  ['lbrRate', NUM('l."LBR_RATE"')],
  ['lbrAmt', NUM('l."LBR_AMT"')],
  ['othAmt', NUM('l."OTH_AMT"')],
  ['netAmt', NUM('l."NET_AMT"')],
  ['designIsu', 'l."DESIGN_ISU"'],
];

const ADJUSTMENT_COLUMNS: readonly [string, string][] = [
  ['adjSr', 'a."SR_NO"::float8'],
  ['ordSign', 'a."ORD_SIGN"'],
  ['ordAmt', NUM('a."ORD_AMT"')],
  ['ordLc', 'a."ORD_LC"'],
  ['ordYrcd', 'a."ORD_YRCD"'],
  ['ordDbcd', 'a."ORD_DBCD"'],
  ['ordNo', 'a."ORD_NO"'],
];

const BILL_COLUMNS: readonly [string, string][] = [
  ['billNo', 'b."VCH_NO"'],
  ['billDate', `to_char(b."VCH_DATE", 'YYYY-MM-DD')`],
  ['billTotAmt', NUM('b."TOT_AMT"')],
  ['billAdvAmt', NUM('b."ADV_AMT"')],
  ['billAcCode', 'b."AC_CODE"'],
  ['billAcName', 'b."AC_NAME"'],
];

const PARTY_COLUMNS: readonly [string, string][] = [
  ['partyName', 'ac."AC_NAME"'],
  ['city', 'ac."AC_CITY"'],
  ['area', 'ac."AC_AREA"'],
];

const BOOK_COLUMNS: readonly [string, string][] = [
  ['bookName', 'bk."BOOK_NAME"'],
  ['bookSName', 'bk."BOOK_SNAME"'],
];

const itemJoins = `LEFT JOIN "ITEM_MAST" im ON im."CO_CODE" = l."CO_CODE" AND im."IT_CODE" = l."IT_CODE"`;
const partyJoin = (h: string) =>
  `LEFT JOIN LATERAL (SELECT a."AC_NAME", a."AC_CITY", a."AC_AREA"
       FROM "AC_MAST" a WHERE a."CO_CODE" = ${h}."CO_CODE" AND a."AC_CODE" = ${h}."AC_CODE"
       ORDER BY (a."LC_CODE" = ${h}."LC_CODE") DESC NULLS LAST, a."row_id" LIMIT 1) ac ON true`;
const bookJoin = (h: string) =>
  `LEFT JOIN LATERAL (SELECT b."BOOK_NAME", b."BOOK_SNAME"
       FROM "BOOK_DATA" b WHERE b."CO_CODE" = ${h}."CO_CODE" AND b."CO_BOOK" = ${h}."CO_BOOK"
       ORDER BY (b."LC_CODE" = ${h}."LC_CODE") DESC NULLS LAST, b."row_id" LIMIT 1) bk ON true`;
const lineJoin =
  `LEFT JOIN "SL_ORD_DETL" l ON l."CO_CODE" = d."CO_CODE" AND l."LC_CODE" = d."LC_CODE" AND l."CO_YEAR" = d."CO_YEAR"
       AND l."CO_BOOK" = d."CO_BOOK" AND l."VCH_NO" = d."VCH_NO"`;
const adjustmentJoin =
  `LEFT JOIN "SL_ORD_ADJ" a ON a."CO_CODE" = d."CO_CODE" AND a."LC_CODE" = d."LC_CODE" AND a."CO_YEAR" = d."CO_YEAR"
       AND a."CO_BOOK" = d."CO_BOOK" AND a."VCH_NO" = d."VCH_NO"`;
const billFromAdjustmentJoin =
  `LEFT JOIN "SL_DATA" b ON b."CO_CODE" = a."ORD_LC"::text AND b."LC_CODE" = a."ORD_LC"
       AND b."CO_YEAR" = a."ORD_YRCD" AND b."CO_BOOK" = a."ORD_DBCD" AND b."VCH_NO" = a."ORD_NO"`;
const orderFromAdjustmentJoin =
  `LEFT JOIN "SL_ORD_DATA" o ON o."CO_CODE" = a."CO_CODE" AND o."LC_CODE" = a."LC_CODE" AND o."CO_YEAR" = a."CO_YEAR"
       AND o."CO_BOOK" = a."CO_BOOK" AND o."VCH_NO" = a."VCH_NO"`;

const select = (columns: readonly [string, string][]) =>
  columns.map(([alias, expr]) => `${expr} AS "${alias}"`).join(',\n       ');

const fullyAdjustedExclusion = (h: string) =>
  `NOT EXISTS (
       SELECT 1 FROM "SL_ORD_DATA" a2
       LEFT JOIN "SL_ORD_ADJ" b2
         ON a2."CO_CODE" = b2."CO_CODE" AND a2."LC_CODE" = b2."LC_CODE" AND a2."CO_YEAR" = b2."CO_YEAR"
         AND a2."CO_BOOK" = b2."CO_BOOK" AND a2."VCH_NO" = b2."VCH_NO"
       WHERE a2."CO_CODE" = ${h}."CO_CODE" AND a2."LC_CODE" = ${h}."LC_CODE"
         AND a2."CO_YEAR" = ${h}."CO_YEAR" AND a2."CO_BOOK" = ${h}."CO_BOOK" AND a2."VCH_NO" = ${h}."VCH_NO"
       GROUP BY a2."CO_YEAR", a2."CO_BOOK", a2."VCH_NO"
       HAVING SUM(CASE WHEN b2."ORD_SIGN" = '+' THEN b2."ORD_AMT" ELSE -b2."ORD_AMT" END) = 0
     )`;

export function buildOrderQuery(input: OrderQueryArgs): SqlQuery {
  const { shape, scope, filters, applied } = input;
  const values: unknown[] = [];
  const p = (value: unknown, cast = '') => {
    values.push(value);
    return `$${values.length}${cast}`;
  };

  const has = (key: OrderFilterKey) => applied.has(key) && filters[key] !== undefined;

  const columns: [string, string][] = [];
  const joins: string[] = [];
  let from: string;
  let dateAlias: string;

  if (shape.base === 'SL_ORD_DATA') {
    from = '"SL_ORD_DATA" d';
    dateAlias = 'd';
    columns.push(...HEADER_COLUMNS);
    joins.push(partyJoin('d'), bookJoin('d'));
    if (shape.lines) {
      columns.push(...LINE_COLUMNS);
      joins.push(lineJoin, itemJoins);
    }
    if (shape.adjustments) {
      columns.push(...ADJUSTMENT_COLUMNS);
      joins.push(adjustmentJoin);
      if (shape.base === 'SL_ORD_DATA') {
        // Order Wise Bill left-joins the bill referenced by the adjustment.
        columns.push(...BILL_COLUMNS);
        joins.push(billFromAdjustmentJoin);
      }
    }
  } else {
    // Bill Wise Adjust: base is the sale bill table SL_DATA (RP_ALL.cs:12608).
    from = '"SL_DATA" d';
    dateAlias = 'd';
    columns.push(
      ['lcCode', 'd."LC_CODE"'],
      ['coBook', 'd."CO_BOOK"'],
      ['coYear', 'd."CO_YEAR"'],
      ['vchNo', 'd."VCH_NO"'],
      ['vchDate', `to_char(d."VCH_DATE", 'YYYY-MM-DD')`],
      ['coCode', 'd."CO_CODE"'],
      ['billAcCode', 'd."AC_CODE"'],
      ['billAcName', 'd."AC_NAME"'],
      ['billTotAmt', NUM('d."TOT_AMT"')],
      ['billAdvAmt', NUM('d."ADV_AMT"')],
    );
    joins.push(adjustmentJoin, orderFromAdjustmentJoin, bookJoin('d'));
    columns.push(
      ...ADJUSTMENT_COLUMNS,
      ['orderAcName', 'o."AC_NAME"'],
      ['orderAcCode', 'o."AC_CODE"'],
    );
  }

  const where: string[] = [
    `${dateAlias}."CO_CODE" = ${p(scope.coCode)}`,
    `${dateAlias}."VCH_DATE"::date >= ${p(filters.fromDate, '::date')}`,
    `${dateAlias}."VCH_DATE"::date <= ${p(filters.toDate, '::date')}`,
  ];

  // Location filter is applied whenever a location is set (RP_ALL.cs:8383).
  if (applied.has('lcCode') && filters.lcCode !== null)
    where.push(`${dateAlias}."LC_CODE" = ${p(filters.lcCode)}`);
  if (has('coBook')) where.push(`${dateAlias}."CO_BOOK" = ${p(filters.coBook)}`);
  if (has('acCode')) where.push(`${dateAlias}."AC_CODE" = ${p(filters.acCode)}`);
  if (has('custName')) where.push(`${dateAlias}."AC_NAME" = ${p(filters.custName)}`);

  // City/Area filter on AC_MAST joined to the order header (RP_ALL.cs:8395-8399).
  if (has('city')) where.push(`ac."AC_CITY" = ${p(filters.city)}`);
  if (has('area')) where.push(`ac."AC_AREA" = ${p(filters.area)}`);

  if (shape.lines && shape.fullyAdjustedExclusion) {
    where.push(`l."DESIGN_ISU" = 'N'`);
    where.push(fullyAdjustedExclusion('d'));
  }

  const text = `SELECT ${select(columns)}
  FROM ${from}
     ${joins.join('\n     ')}
 WHERE ${where.join('\n   AND ')}`;
  return { text, values };
}
