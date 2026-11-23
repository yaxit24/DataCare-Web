import type { RpAllFilters, RpAllSessionScope } from './filters.js';
import type { OrderFilterKey, OrderQueryShape } from './orderLayouts.js';

/**
 * Read-only SQL for the Order branch of RP_ALL.
 *
 * Every fragment is a constant chosen by the query SHAPE (from the mode table, never from the request);
 * request values are bound as `$n`. The desktop builds Crystal formulas by concatenating control text
 * (RP_ALL.cs:8380-8403, :12608-12631) — that weakness is not ported.
 *
 * Each shape reproduces the record set of its template's TableLinks (extraction_output/rpt_xml/*.xml):
 *   header   OrdAdvRpt       SL_ORD_DATA → AC_MAST, BOOK_DATA
 *   lines    OrdDetlRpt, OrdDetlPanding, OrdDesignSumm
 *                            SL_ORD_DATA ⟕ SL_ORD_DETL (5 keys) ⟕ ITEM_MAST, → AC_MAST, BOOK_DATA
 *   adjust   OrdAdvAdj       SL_ORD_DATA ⟕ SL_ORD_ADJ ON CO_CODE, ORD_NO, ORD_LC, ORD_YRCD, ORD_DBCD
 *   withBill OrdAdjBillWise  SL_ORD_DATA ⟕ SL_ORD_ADJ ON CO_CODE, ORD_NO, ORD_YRCD, ORD_DBCD (no ORD_LC)
 *                            ⟕ SL_DATA ON the adjustment's own 5 keys ⟕ AC_MAST ON SL_DATA.AC_CODE
 *   billWise BillWiseOrderAdjust
 *                            SL_DATA ⋈ SL_ORD_ADJ (Equal join) ON the 5 voucher keys,
 *                            ⟕ AC_MAST ON SL_ORD_ADJ.ORD_AC_CODE, ⟕ BOOK_DATA ON SL_DATA
 * An SL_ORD_ADJ row's own keys are the voucher that wrote it (the order for its `+` advance row, the sale
 * bill for a `-` adjustment, Ac_Tax.cs:71-73) and ORD_* point at the order — so an order reaches its
 * adjustments through ORD_*, never through the adjustment's own keys.
 *
 * Masters are looked up once per row (LATERAL ... LIMIT 1, as the Sales adapter does: AC_MAST and BOOK_DATA
 * have no unique key in the schema). Tenant isolation comes from forced RLS on every table read inside
 * withTxBudget; company and location are explicit predicates as well.
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
const DATE = (expr: string) => `to_char(${expr}, 'YYYY-MM-DD')`;

const ORDER_HEADER: readonly [string, string][] = [
  ['coCode', 'd."CO_CODE"'],
  ['lcCode', 'd."LC_CODE"'],
  ['coYear', 'd."CO_YEAR"'],
  ['coBook', 'd."CO_BOOK"'],
  ['vchNo', 'd."VCH_NO"'],
  ['vchDate', DATE('d."VCH_DATE"')],
  ['acCode', 'd."AC_CODE"'],
  ['acName', 'd."AC_NAME"'],
  ['totAmt', NUM('d."TOT_AMT"')],
  ['advAmt', NUM('d."ADV_AMT"')],
  ['cashAmt', NUM('d."CASH_AMT"')],
  ['cardAmt', NUM('d."CARD_AMT"')],
  ['chqAmt', NUM('d."CHQ_AMT"')],
  ['oldGlAmt', NUM('d."OLD_GL_AMT"')],
  ['oldSlAmt', NUM('d."OLD_SL_AMT"')],
  // OrdDetlPanding prints {SL_ORD_DATA.OLD_GL} (the old-gold weight column), not OLD_GL_AMT.
  ['oldGl', NUM('d."OLD_GL"')],
  // DEL_DATE is a varchar on SL_ORD_DATA (schema.prisma), not a date: select it as stored text.
  ['delDate', 'd."DEL_DATE"'],
  ['bookName', 'bk."BOOK_NAME"'],
  ['bookSName', 'bk."BOOK_SNAME"'],
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

/** The adjustment row: its own keys (the writing voucher) and its ORD_* reference to the order. */
const ADJUSTMENT_COLUMNS: readonly [string, string][] = [
  ['adjLc', 'a."LC_CODE"'],
  ['adjYear', 'a."CO_YEAR"'],
  ['adjBook', 'a."CO_BOOK"'],
  ['adjVchNo', 'a."VCH_NO"'],
  ['adjSr', 'a."SR_NO"::float8'],
  ['adjVchDate', DATE('a."VCH_DATE"')],
  ['adjAcName', 'a."AC_NAME"'],
  ['ordSign', 'a."ORD_SIGN"'],
  // NULL stays NULL: an order without adjustment rows has no amount (Crystal prints a blank, sums skip it).
  ['ordAmt', 'a."ORD_AMT"::float8'],
  ['ordLc', 'a."ORD_LC"'],
  ['ordYrcd', 'a."ORD_YRCD"'],
  ['ordDbcd', 'a."ORD_DBCD"'],
  ['ordNo', 'a."ORD_NO"'],
  ['ordAcCode', 'a."ORD_AC_CODE"'],
];

const masterJoin = (alias: string, co: string, code: string, lc: string) =>
  `LEFT JOIN LATERAL (SELECT m."AC_NAME", m."AC_CITY", m."AC_AREA"
       FROM "AC_MAST" m WHERE m."CO_CODE" = ${co} AND m."AC_CODE" = ${code}
       ORDER BY (m."LC_CODE" = ${lc}) DESC NULLS LAST, m."row_id" LIMIT 1) ${alias} ON true`;
const bookJoin = `LEFT JOIN LATERAL (SELECT b."BOOK_NAME", b."BOOK_SNAME"
       FROM "BOOK_DATA" b WHERE b."CO_CODE" = d."CO_CODE" AND b."LC_CODE" = d."LC_CODE" AND b."CO_BOOK" = d."CO_BOOK"
       ORDER BY b."row_id" LIMIT 1) bk ON true`;
const lineJoin = `LEFT JOIN "SL_ORD_DETL" l ON l."CO_CODE" = d."CO_CODE" AND l."LC_CODE" = d."LC_CODE"
       AND l."CO_YEAR" = d."CO_YEAR" AND l."CO_BOOK" = d."CO_BOOK" AND l."VCH_NO" = d."VCH_NO"
     LEFT JOIN "ITEM_MAST" im ON im."CO_CODE" = l."CO_CODE" AND im."IT_CODE" = l."IT_CODE"`;
// OrdAdvAdj.xml TableLink: SL_ORD_DATA (CO_CODE, VCH_NO, LC_CODE, CO_YEAR, CO_BOOK)
//   → SL_ORD_ADJ (CO_CODE, ORD_NO, ORD_LC, ORD_YRCD, ORD_DBCD).
const adjustByOrderJoin = `LEFT JOIN "SL_ORD_ADJ" a ON a."CO_CODE" = d."CO_CODE" AND a."ORD_NO" = d."VCH_NO"
       AND a."ORD_LC" = d."LC_CODE" AND a."ORD_YRCD" = d."CO_YEAR" AND a."ORD_DBCD" = d."CO_BOOK"`;
// OrdAdjBillWise.xml TableLink: the same without the location (SL_ORD_DATA.LC_CODE is not linked).
const adjustByOrderNoLcJoin = `LEFT JOIN "SL_ORD_ADJ" a ON a."CO_CODE" = d."CO_CODE" AND a."ORD_NO" = d."VCH_NO"
       AND a."ORD_YRCD" = d."CO_YEAR" AND a."ORD_DBCD" = d."CO_BOOK"`;
// OrdAdjBillWise.xml TableLink: SL_ORD_ADJ (5 own keys) → SL_DATA (5 keys).
const billOfAdjustmentJoin = `LEFT JOIN "SL_DATA" s ON s."CO_CODE" = a."CO_CODE" AND s."LC_CODE" = a."LC_CODE"
       AND s."CO_YEAR" = a."CO_YEAR" AND s."CO_BOOK" = a."CO_BOOK" AND s."VCH_NO" = a."VCH_NO"`;
// BillWiseOrderAdjust.xml TableLink JoinType="Equal": SL_DATA (5 keys) → SL_ORD_ADJ (5 own keys).
const adjustOfBillJoin = `JOIN "SL_ORD_ADJ" a ON a."CO_CODE" = d."CO_CODE" AND a."LC_CODE" = d."LC_CODE"
       AND a."CO_YEAR" = d."CO_YEAR" AND a."CO_BOOK" = d."CO_BOOK" AND a."VCH_NO" = d."VCH_NO"`;

const select = (columns: readonly [string, string][]) =>
  columns.map(([alias, expr]) => `${expr} AS "${alias}"`).join(',\n       ');

const ORDER_KEY_SORT = 'd."CO_CODE", d."LC_CODE", d."CO_YEAR", d."CO_BOOK", d."VCH_NO"';

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
  let orderBy: string;
  /** Alias of the AC_MAST row the template's {AC_MAST.AC_CITY}/{AC_MAST.AC_AREA} filters read. */
  let party: string;

  if (shape.kind === 'billWise') {
    // Bill Wise Adjust: SL_DATA is the base table (RP_ALL.cs:12608 {{CurFormula = "{SL_DATA.CO_CODE} = '"}}).
    from = '"SL_DATA" d';
    columns.push(
      ['coCode', 'd."CO_CODE"'],
      ['lcCode', 'd."LC_CODE"'],
      ['coYear', 'd."CO_YEAR"'],
      ['coBook', 'd."CO_BOOK"'],
      ['vchNo', 'd."VCH_NO"'],
      ['vchDate', DATE('d."VCH_DATE"')],
      ['billAcCode', 'd."AC_CODE"'],
      ['billAcName', 'd."AC_NAME"'],
      ['billTotAmt', NUM('d."TOT_AMT"')],
      ['billAdvAmt', NUM('d."ADV_AMT"')],
      ['bookName', 'bk."BOOK_NAME"'],
      ...ADJUSTMENT_COLUMNS,
      ['orderPartyName', 'ac."AC_NAME"'],
    );
    joins.push(adjustOfBillJoin, bookJoin, masterJoin('ac', 'a."CO_CODE"', 'a."ORD_AC_CODE"', 'a."LC_CODE"'));
    party = 'ac';
    orderBy = `${ORDER_KEY_SORT}, a."SR_NO"`;
  } else {
    from = '"SL_ORD_DATA" d';
    columns.push(...ORDER_HEADER);
    joins.push(bookJoin);
    orderBy = ORDER_KEY_SORT;
    if (shape.kind === 'withBill') {
      // OrdAdjBillWise links AC_MAST to the BILL's party, not the order's.
      columns.push(
        ...ADJUSTMENT_COLUMNS,
        ['billTotAmt', NUM('s."TOT_AMT"')],
        ['billAcCode', 's."AC_CODE"'],
        ['billPartyName', 'ac."AC_NAME"'],
      );
      joins.push(
        adjustByOrderNoLcJoin,
        billOfAdjustmentJoin,
        masterJoin('ac', 's."CO_CODE"', 's."AC_CODE"', 's."LC_CODE"'),
      );
      orderBy += ', a."CO_YEAR", a."VCH_DATE", a."CO_BOOK", a."VCH_NO", a."SR_NO"';
    } else {
      joins.push(masterJoin('ac', 'd."CO_CODE"', 'd."AC_CODE"', 'd."LC_CODE"'));
      if (shape.kind === 'lines') {
        columns.push(...LINE_COLUMNS);
        joins.push(lineJoin);
        orderBy += ', l."SR_NO"';
      } else if (shape.kind === 'adjust') {
        columns.push(...ADJUSTMENT_COLUMNS);
        joins.push(adjustByOrderJoin);
        orderBy += ', a."CO_YEAR", a."VCH_DATE", a."CO_BOOK", a."VCH_NO", a."SR_NO"';
      }
    }
    party = 'ac';
  }

  const where: string[] = [
    `d."CO_CODE" = ${p(scope.coCode)}`,
    `d."VCH_DATE"::date >= ${p(filters.fromDate, '::date')}`,
    `d."VCH_DATE"::date <= ${p(filters.toDate, '::date')}`,
  ];
  // Every handler appends its location/book/party/name clause on its base table when the box is not empty
  // (RP_ALL.cs:8383 {{CurFormula = CurFormula + " And {SL_ORD_DATA.LC_CODE} = '" + tLcCode.Text + "'";}},
  //  RP_ALL.cs:12611 {{CurFormula = CurFormula + " And {SL_DATA.LC_CODE} = '" + tLcCode.Text + "'";}}).
  if (applied.has('lcCode') && filters.lcCode !== null && filters.lcCode !== undefined)
    where.push(`d."LC_CODE" = ${p(filters.lcCode)}`);
  if (has('coBook')) where.push(`d."CO_BOOK" = ${p(filters.coBook)}`);
  if (has('acCode')) where.push(`d."AC_CODE" = ${p(filters.acCode)}`);
  if (has('city')) where.push(`${party}."AC_CITY" = ${p(filters.city)}`);
  if (has('area')) where.push(`${party}."AC_AREA" = ${p(filters.area)}`);
  if (has('custName')) where.push(`d."AC_NAME" = ${p(filters.custName)}`);
  // Making Panding / Making Summ print only lines not yet issued for making
  // (RP_ALL.cs:10940 {{AND {SL_ORD_DETL.DESIGN_ISU} = 'N' }}).
  if (shape.kind === 'lines' && shape.designPending) where.push(`l."DESIGN_ISU" = 'N'`);

  const text = `SELECT ${select(columns)}
  FROM ${from}
     ${joins.join('\n     ')}
 WHERE ${where.join('\n   AND ')}
 ORDER BY ${orderBy}`;
  return { text, values };
}
