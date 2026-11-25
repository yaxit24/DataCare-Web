import type { Column, Dimension, StockFilters } from './parse.js';

/**
 * Read-only SQL for the Stock Report (RP_STOCK.cs:4277-4695 Stock_Summ, 2816-3227 DGV_DoubleClick).
 *
 * Every fragment is a constant chosen by the dimension or column; every request value is pushed to `values`
 * and referenced as `$n`. Stock truth is the signed MAIN_STOCK movement (`ITM_SIGN`), never a BAR_DETL
 * snapshot. Nothing is written: the desktop's load-time UPDATEs (RP_STOCK.cs:3651-3653) and Trading UPDATE
 * (RP_STOCK.cs:4641) are replaced by COALESCE rules (NULL STK_DISPLAY = shown, NULL SAFE_NAME = MAIN, blank
 * counter = 001, blank item trading type = its group's).
 */
export interface SqlQuery {
  text: string;
  values: unknown[];
}
export interface StockScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  /** CO_STK_MERGE = Y: the company condition is dropped inside the tenant (RP_STOCK.cs:4284). */
  merge: boolean;
}

const ITEM_JOIN = `LEFT JOIN "ITEM_MAST" b ON b.tenant_id = a.tenant_id AND b."CO_CODE" = a."CO_CODE" AND b."IT_CODE" = a."IT_CODE"`;
const GROUP_JOIN = `LEFT JOIN LATERAL (SELECT "GR_NAME","TRAD_TYPE" FROM "GROUP_MAST" x WHERE x."CO_CODE" = b."CO_CODE" AND x."GR_CODE" = b."GR_CODE" LIMIT 1) g ON true`;

const IT_TYPE = `COALESCE(b."IT_TYPE", '')`;
const SAFE = `COALESCE(NULLIF(b."SAFE_NAME", ''), 'MAIN')`;
const COUNTER = `COALESCE(NULLIF(a."TBL_CODE", ''), '001')`;
const TRADING = `COALESCE(NULLIF(b."TRAD_TYPE", ''), NULLIF(g."TRAD_TYPE", ''), '')`;

interface DimSpec {
  key: string;
  name: string;
  /** joins the key itself needs (drill-down uses only these). */
  keyJoins: string;
  /** joins the display name needs, in addition. */
  nameJoins: string;
}
const DIM: Record<Dimension, DimSpec> = {
  item: {
    key: `COALESCE(a."IT_CODE", '')`,
    name: `COALESCE(NULLIF(b."IT_NAME", ''), a."IT_CODE", '')`,
    keyJoins: '',
    nameJoins: '',
  },
  product: {
    key: `COALESCE(b."PR_CODE", '')`,
    name: `COALESCE(p."PR_NAME", '')`,
    keyJoins: '',
    nameJoins: `LEFT JOIN LATERAL (SELECT "PR_NAME" FROM "PRODUCT_MAST" x WHERE x."CO_CODE" = b."CO_CODE" AND x."PR_CODE" = b."PR_CODE" LIMIT 1) p ON true`,
  },
  group: {
    key: `COALESCE(b."GR_CODE", '')`,
    name: `COALESCE(g."GR_NAME", '')`,
    keyJoins: '',
    nameJoins: GROUP_JOIN,
  },
  safe: { key: SAFE, name: SAFE, keyJoins: '', nameJoins: '' },
  design: {
    key: `COALESCE(a."DESIGN_NO", '')`,
    name: `COALESCE(a."DESIGN_NO", '')`,
    keyJoins: '',
    nameJoins: '',
  },
  size: {
    key: `COALESCE(a."ITM_SIZE", '')`,
    name: `COALESCE(a."ITM_SIZE", '')`,
    keyJoins: '',
    nameJoins: '',
  },
  counter: {
    key: COUNTER,
    name: `COALESCE(t."TABLE_NAME", '')`,
    keyJoins: '',
    nameJoins: `LEFT JOIN LATERAL (SELECT "TABLE_NAME" FROM "TABLE_MAST" x WHERE x."CO_CODE" = a."CO_CODE" AND x."LC_CODE" = a."LC_CODE" AND x."TABLE_CODE" = ${COUNTER} LIMIT 1) t ON true`,
  },
  trading: {
    key: TRADING,
    name: `COALESCE(r."TRAD_NAME", '')`,
    keyJoins: GROUP_JOIN,
    nameJoins: `LEFT JOIN LATERAL (SELECT "TRAD_NAME" FROM "BAL_GR" x WHERE x."CO_CODE" = b."CO_CODE" AND x."TRAD_TYPE" = ${TRADING} LIMIT 1) r ON true`,
  },
};

/** The WHERE clause shared by the summary and the drill-down, so a cell and its detail total agree. */
function where(scope: StockScope, f: StockFilters, values: unknown[]): string {
  const bind = (v: unknown) => {
    values.push(v);
    return `$${values.length}`;
  };
  const c: string[] = [`a.tenant_id = ${bind(scope.tenantId)}`];
  if (!scope.merge) c.push(`a."CO_CODE" = ${bind(scope.coCode)}`);
  c.push(`a."LC_CODE" = ${bind(scope.lcCode)}`);
  c.push(`a."CO_YEAR" = ${bind(scope.coYear)}`);
  // Items marked "not displayed in stock" are left out (RP_STOCK.cs:4284 `B.STK_DISPLAY <> 'N'`); NULL is shown.
  c.push(`COALESCE(b."STK_DISPLAY", 'Y') <> 'N'`);
  if (f.dataType && f.dataType !== 'C') c.push(`a."DATA_TYPE" = ${bind(f.dataType)}`);
  if (f.stockType === 'tag') c.push(`COALESCE(a."TAG_NO", 'N') <> 'N'`);
  if (f.stockType === 'item') c.push(`COALESCE(a."TAG_NO", 'N') = 'N'`);
  if (f.acCode !== undefined) c.push(`a."AC_CODE" = ${bind(f.acCode)}`);
  if (f.tagNo !== undefined) c.push(`a."TAG_NO" = ${bind(f.tagNo)}`);
  if (f.itemType !== undefined) c.push(`${IT_TYPE} = ${bind(f.itemType)}`);
  if (f.prCode !== undefined) c.push(`b."PR_CODE" = ${bind(f.prCode)}`);
  if (f.grCode !== undefined) c.push(`b."GR_CODE" = ${bind(f.grCode)}`);
  if (f.itCode !== undefined) c.push(`a."IT_CODE" = ${bind(f.itCode)}`);
  if (f.designNo !== undefined) c.push(`COALESCE(a."DESIGN_NO", '') = ${bind(f.designNo)}`);
  if (f.safe !== undefined) c.push(`${SAFE} = ${bind(f.safe)}`);
  if (f.tblCode !== undefined) c.push(`${COUNTER} = ${bind(f.tblCode)}`);
  return c.join(' AND ');
}

const sign = (col: string) =>
  `CASE WHEN a."ITM_SIGN" = '+' THEN COALESCE(${col}, 0) ELSE -COALESCE(${col}, 0) END`;

/** Summary: one row per dimension value and item type, with the desktop's nine conditional sums. */
export function summaryQuery(
  dimension: Dimension,
  scope: StockScope,
  f: StockFilters,
  gross: boolean,
): SqlQuery {
  const values: unknown[] = [];
  const spec = DIM[dimension];
  const w = gross ? 'a."ITM_GWT"' : 'a."ITM_NWT"';
  const where_ = where(scope, f, values);
  values.push(f.fromDate, f.toDate);
  const from = `$${values.length - 1}::date`;
  const to = `$${values.length}::date`;
  const inWin = `a."VCH_DATE" >= ${from} AND a."VCH_DATE" <= ${to}`;
  const flow = (signChar: '+' | '-', tr: string, col: string) =>
    `SUM(CASE WHEN ${inWin} AND a."ITM_SIGN" = '${signChar}' AND a."TR_TYPE" = '${tr}' THEN COALESCE(${col}, 0) ELSE 0 END)::float8`;
  const pair = (prefix: string, signChar: '+' | '-', tr: string) =>
    `${flow(signChar, tr, 'a."ITM_PCS"')} AS "${prefix}Pcs", ${flow(signChar, tr, w)} AS "${prefix}Wt"`;
  const text = `SELECT ${spec.key} AS code, ${spec.name} AS name, ${IT_TYPE} AS "itType",
  SUM(CASE WHEN a."VCH_DATE" < ${from} THEN ${sign('a."ITM_PCS"')} ELSE 0 END)::float8 AS "opPcs",
  SUM(CASE WHEN a."VCH_DATE" < ${from} THEN ${sign(w)} ELSE 0 END)::float8 AS "opWt",
  ${pair('pr', '+', 'P')}, ${pair('in', '+', 'I')}, ${pair('out', '-', 'O')}, ${pair('sl', '-', 'S')},
  SUM(CASE WHEN a."VCH_DATE" <= ${to} THEN ${sign('a."ITM_PCS"')} ELSE 0 END)::float8 AS "clPcs",
  SUM(CASE WHEN a."VCH_DATE" <= ${to} THEN ${sign(w)} ELSE 0 END)::float8 AS "clWt",
  ${pair('tIn', '+', 'T')}, ${pair('tOut', '-', 'T')}
FROM "MAIN_STOCK" a ${ITEM_JOIN} ${spec.keyJoins} ${spec.nameJoins}
WHERE ${where_}
GROUP BY ${spec.key}, ${spec.name}, ${IT_TYPE}
ORDER BY ${spec.name}, ${IT_TYPE}, ${spec.key}`;
  return { text, values };
}

/** The date condition of a clicked column (RP_STOCK.cs:2896-2916). */
function columnPredicate(column: Column, from: string, to: string): string {
  const win = `a."VCH_DATE" >= ${from} AND a."VCH_DATE" <= ${to}`;
  switch (column) {
    case 'opening':
      return `a."VCH_DATE" < ${from}`;
    case 'purchase':
      return `a."ITM_SIGN" = '+' AND a."TR_TYPE" = 'P' AND ${win}`;
    case 'inward':
      return `a."ITM_SIGN" = '+' AND a."TR_TYPE" = 'I' AND ${win}`;
    case 'outward':
      return `a."ITM_SIGN" = '-' AND a."TR_TYPE" = 'O' AND ${win}`;
    case 'sale':
      return `a."ITM_SIGN" = '-' AND a."TR_TYPE" = 'S' AND ${win}`;
    case 'closing':
      return `a."VCH_DATE" <= ${to}`;
  }
}

/**
 * Movements behind one summary cell. Fine is KR_FINE for '+' rows and ITM_FINE for '-' rows (RP_STOCK.cs:2896
 * `CASE WHEN A.ITM_SIGN = '+' THEN KR_FINE ELSE ITM_FINE END`). The summary's own filters (item type and the
 * hidden-item rule included) are repeated so the detail total equals the cell: the desktop omits them
 * (desktop weakness 5), which is not ported.
 */
export function movementsQuery(
  dimension: Dimension,
  scope: StockScope,
  f: StockFilters,
  key: string,
  rowType: string,
  column: Column,
): SqlQuery {
  const values: unknown[] = [];
  const spec = DIM[dimension];
  const where_ = where(scope, f, values);
  values.push(key, rowType, f.fromDate, f.toDate);
  const n = values.length;
  const text = `SELECT bd."BOOK_SNAME" AS "vchType", bd."MAIN_BOOK" AS "mainBook", a."CO_BOOK" AS "coBook",
  COALESCE(ac."AC_NAME", '') AS "partyName", a."VCH_NO" AS "vchNo", to_char(a."VCH_DATE", 'YYYY-MM-DD') AS "vchDate",
  a."TAG_NO" AS "tagNo", a."ITM_LOT" AS "itLot", COALESCE(b."IT_NAME", '') AS "itName",
  COALESCE(a."ITM_PCS", 0)::float8 AS pcs, COALESCE(a."ITM_GWT", 0)::float8 AS gwt, COALESCE(a."ITM_NWT", 0)::float8 AS nwt,
  (CASE WHEN a."ITM_SIGN" = '+' THEN COALESCE(a."KR_FINE", 0) ELSE COALESCE(a."ITM_FINE", 0) END)::float8 AS fine,
  CASE WHEN a."ITM_SIGN" = '+' THEN '+' ELSE '-' END AS sign
FROM "MAIN_STOCK" a ${ITEM_JOIN} ${spec.keyJoins}
LEFT JOIN LATERAL (SELECT "BOOK_SNAME","MAIN_BOOK" FROM "BOOK_DATA" x WHERE x."CO_CODE" = a."CO_CODE" AND x."CO_BOOK" = a."CO_BOOK"
   ORDER BY (x."LC_CODE" = a."LC_CODE") DESC NULLS LAST LIMIT 1) bd ON true
LEFT JOIN LATERAL (SELECT "AC_NAME" FROM "AC_MAST" x WHERE x."CO_CODE" = a."CO_CODE" AND x."AC_CODE" = a."AC_CODE" LIMIT 1) ac ON true
WHERE ${where_} AND ${spec.key} = $${n - 3} AND ${IT_TYPE} = $${n - 2}
  AND ${columnPredicate(column, `$${n - 1}::date`, `$${n}::date`)}
  AND $${n - 1}::date IS NOT NULL AND $${n}::date IS NOT NULL
ORDER BY a."VCH_DATE", a."VCH_NO", a."SR_NO", a.row_id`;
  return { text, values };
}
