import { round } from '@datacare/core';
import { withTenant } from '@datacare/db';
import type { ListReport, ReportScope } from './reports.js';

export type GraphMode =
  | 'last-30-day-sales'
  | 'month-sales'
  | 'product-sales'
  | 'employee-sales'
  | 'expense-by-day'
  | 'expense-by-type'
  | 'karigar-sales';

type Metric = 'amount' | 'weight';
type TransactionType = 'all' | 'sales' | 'return';
type BookType = 'retail' | 'whsale' | 'all';

export interface GraphReportOptions {
  mode?: unknown;
  metric?: unknown;
  transactionType?: unknown;
  bookType?: unknown;
  itemType?: unknown;
  grCode?: unknown;
  lcCode?: unknown;
  dataType?: unknown;
}

const txt = (v: unknown): string | null => {
  const s = String(v ?? '').trim();
  return s ? s : null;
};
const num = (v: unknown): number => {
  const n = Number(v ?? 0);
  return Number.isFinite(n) ? n : 0;
};
// Report display rounding (N57 exact until output); desktop presents half-up, kernel `round` (N48, G22).
const round3 = (n: number): number => round(n, 3);
const round2 = (n: number): number => round(n, 2);
const todayIso = (): string => new Date().toISOString().slice(0, 10);
const isoDate = (v: unknown): string | null => {
  if (!v) return null;
  const d = v instanceof Date ? v : new Date(String(v));
  return Number.isFinite(d.getTime()) ? d.toISOString().slice(0, 10) : null;
};
const addDays = (iso: string, days: number): string => {
  const [y, m, d] = iso.split('-').map((part) => Number(part));
  const date = new Date(Date.UTC(y || 1970, (m || 1) - 1, d || 1));
  date.setUTCDate(date.getUTCDate() + days);
  return date.toISOString().slice(0, 10);
};
const fiscalStart = (coYear?: string): string => {
  const match = String(coYear ?? '').match(/\d{4}/);
  return match ? `${match[0]}-04-01` : '2010-04-01';
};

function normalizeMode(v: unknown): GraphMode {
  const s = String(v ?? '')
    .trim()
    .toLowerCase()
    .replace(/[\s_]+/g, '-');
  const aliases: Record<string, GraphMode> = {
    '': 'last-30-day-sales',
    day: 'last-30-day-sales',
    days: 'last-30-day-sales',
    'day-sales': 'last-30-day-sales',
    'last-30': 'last-30-day-sales',
    'last-30-day-sl': 'last-30-day-sales',
    'last-30-day-sales': 'last-30-day-sales',
    month: 'month-sales',
    'month-sl': 'month-sales',
    'monthly-sales': 'month-sales',
    'month-sales': 'month-sales',
    item: 'product-sales',
    product: 'product-sales',
    'product-sl': 'product-sales',
    'product-sales': 'product-sales',
    emp: 'employee-sales',
    employee: 'employee-sales',
    'employee-sl': 'employee-sales',
    'employee-sales': 'employee-sales',
    expense: 'expense-by-day',
    'expense-by-day': 'expense-by-day',
    'expense-day': 'expense-by-day',
    'expense-type': 'expense-by-type',
    'expense-by-type': 'expense-by-type',
    'karigar-sales': 'karigar-sales',
    'karigar-sl': 'karigar-sales',
    'kr-sales': 'karigar-sales',
    krsl: 'karigar-sales',
  };
  return aliases[s] ?? 'last-30-day-sales';
}

function normalizeMetric(v: unknown, workType: string | null): Metric {
  const s = String(v ?? '')
    .trim()
    .toLowerCase();
  if (['amount', 'amt', 'a'].includes(s)) return 'amount';
  if (['weight', 'wt', 'nwt', 'w'].includes(s)) return 'weight';
  return (workType ?? '').toUpperCase() === 'W' ? 'weight' : 'amount';
}

function normalizeTransaction(v: unknown): TransactionType {
  const s = String(v ?? '')
    .trim()
    .toLowerCase();
  if (['sales', 'sale', 'out', '-'].includes(s)) return 'sales';
  if (['return', 'returns', 'ret', 'in', '+'].includes(s)) return 'return';
  return 'all';
}

function normalizeBookType(v: unknown, workType: string | null): BookType {
  const s = String(v ?? '')
    .trim()
    .toLowerCase();
  if (['all', 'both', '*'].includes(s)) return 'all';
  if (['retail', 'ret', 'r'].includes(s)) return 'retail';
  if (['whsale', 'wh-sale', 'wholesale', 'wh', 'w'].includes(s)) return 'whsale';
  return (workType ?? '').toUpperCase() === 'W' ? 'whsale' : 'retail';
}

function normalizeItemType(v: unknown, metalType: string | null): string | null {
  const raw = String(v ?? '').trim();
  if (!raw) return (metalType ?? '').toUpperCase() === 'G' ? 'G' : 'S';
  const s = raw.toLowerCase();
  if (['all', 'any', '*'].includes(s)) return null;
  if (s.startsWith('gold')) return 'G';
  if (s.startsWith('silver')) return 'S';
  if (s.startsWith('diamond')) return 'D';
  if (s.startsWith('real')) return 'R';
  if (s.startsWith('emitation') || s.startsWith('imitation')) return 'E';
  if (s.startsWith('other')) return 'O';
  if (s.startsWith('platinum')) return 'P';
  return raw[0]?.toUpperCase() ?? null;
}

function mainBooks(bookType: BookType): string[] {
  if (bookType === 'retail') return ['SALES', 'E INVOICE', 'SALES RETURNE'];
  if (bookType === 'whsale') return ['WH SALES'];
  return ['SALES', 'E INVOICE', 'SALES RETURNE', 'WH SALES'];
}

function pushParam(params: unknown[], value: unknown): string {
  params.push(value);
  return `$${params.length}`;
}

function addMainBookFilter(params: unknown[], where: string[], bookType: BookType): void {
  const placeholders = mainBooks(bookType).map((book) => pushParam(params, book));
  where.push(`upper(coalesce(b."MAIN_BOOK",'')) IN (${placeholders.join(',')})`);
}

function addDataTypeFilter(
  params: unknown[],
  where: string[],
  alias: string,
  dataType: string | null,
): void {
  if (!dataType || dataType.toUpperCase() === 'C') return;
  where.push(`${alias}."DATA_TYPE"=${pushParam(params, dataType.toUpperCase())}`);
}

function addGroupAndItemFilters(
  params: unknown[],
  where: string[],
  grCode: string | null,
  itemType: string | null,
): void {
  if (grCode) where.push(`d."GR_CODE"=${pushParam(params, grCode)}`);
  if (itemType) where.push(`d."IT_TYPE"=${pushParam(params, itemType)}`);
}

function addDateWindow(params: unknown[], where: string[], fromDate: string, toDate: string): void {
  where.push(`a."VCH_DATE">=${pushParam(params, fromDate)}::date`);
  where.push(`a."VCH_DATE"<=${pushParam(params, toDate)}::date`);
}

function stockAggregates(
  metric: Metric,
  transactionType: TransactionType,
): { value: string; series: string; sign: string } {
  const metricExpr = metric === 'weight' ? 'coalesce(a."ITM_NWT",0)' : 'coalesce(a."NET_AMT",0)';
  const amountExpr = 'coalesce(a."NET_AMT",0)';
  if (transactionType === 'sales') {
    return {
      value: `SUM(${metricExpr})`,
      series: `SUM(${metricExpr})`,
      sign: ` AND a."ITM_SIGN"='-'`,
    };
  }
  if (transactionType === 'return') {
    return {
      value: `SUM(${metricExpr})`,
      series: `SUM(${metricExpr})`,
      sign: ` AND a."ITM_SIGN"='+'`,
    };
  }
  const signedMetric = `SUM(CASE WHEN a."ITM_SIGN"='-' THEN ${metricExpr} ELSE -${metricExpr} END)`;
  const signedAmount = `SUM(CASE WHEN a."ITM_SIGN"='-' THEN ${amountExpr} ELSE -${amountExpr} END)`;
  return {
    value: signedMetric,
    series: metric === 'weight' ? signedAmount : signedMetric,
    sign: '',
  };
}

function mappedRows(rows: Array<Record<string, unknown>>, mode: GraphMode): Record<string, any>[] {
  return rows.map((row) => {
    const rawTot = row.totAmt;
    const numericTot =
      rawTot != null && rawTot !== '' && Number.isFinite(Number(rawTot))
        ? round3(num(rawTot))
        : null;
    return {
      mode,
      code: row.code == null ? null : num(row.code),
      name: row.name instanceof Date ? isoDate(row.name) : (txt(row.name) ?? ''),
      value: round3(num(row.value)),
      totAmt: numericTot ?? txt(rawTot) ?? '',
    };
  });
}

async function companyDefaults(
  tx: any,
  s: ReportScope,
): Promise<{ workType: string | null; metalType: string | null }> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "WORK_TYPE" AS "workType", "METAL_TYPE" AS "metalType"
       FROM "CO_MAST"
      WHERE tenant_id=current_setting('app.tenant_id', true)
        AND "CO_CODE"=$1
      LIMIT 1`,
    s.coCode,
  );
  return { workType: txt(rows[0]?.workType), metalType: txt(rows[0]?.metalType) };
}

/**
 * Graph Report — desktop `RP_GRAPH`.
 *
 * The desktop is a dashboard form with seven buttons, each building a different query and then binding the
 * same chart fields: `Name`, `Value`, `TotAmt`. This builder keeps those branches as one endpoint selected
 * by `mode`, while preserving the desktop combo semantics for book type, sales/return, amount/weight,
 * item type, group, location, company year and data type.
 */
export async function graphReport(
  prisma: any,
  s: ReportScope,
  options: GraphReportOptions = {},
): Promise<ListReport> {
  return withTenant(prisma, s.tenantId, async (tx: any) => {
    const defaults = await companyDefaults(tx, s);
    const mode = normalizeMode(options.mode);
    const metric = normalizeMetric(options.metric, defaults.workType);
    const transactionType = normalizeTransaction(options.transactionType);
    const bookType = normalizeBookType(options.bookType, defaults.workType);
    const itemType = normalizeItemType(options.itemType, defaults.metalType);
    const grCode = txt(options.grCode);
    const lcCode = txt(options.lcCode) ?? s.lcCode ?? '';
    const dataType = txt(options.dataType);
    const toDate = s.toDate ?? todayIso();
    const fromDate =
      mode === 'last-30-day-sales' ? addDays(toDate, -30) : (s.fromDate ?? fiscalStart(s.coYear));

    const params: unknown[] = [s.coCode];
    const where = [`a.tenant_id=current_setting('app.tenant_id', true)`, `a."CO_CODE"=$1`];

    if (mode === 'expense-by-day' || mode === 'expense-by-type') {
      where.push(`a."LC_CODE"=${pushParam(params, lcCode)}`);
      if (s.coYear) where.push(`a."CO_YEAR"=${pushParam(params, s.coYear)}`);
      addDataTypeFilter(params, where, 'a', dataType);
      addDateWindow(params, where, fromDate, toDate);
      where.push(`b."AC_GR" IN ('45','46','47')`);
      const group =
        mode === 'expense-by-day'
          ? `EXTRACT(MONTH FROM a."VCH_DATE")::int, EXTRACT(DAY FROM a."VCH_DATE")::int`
          : `EXTRACT(MONTH FROM a."VCH_DATE")::int, b."AC_NAME"`;
      const select =
        mode === 'expense-by-day'
          ? `EXTRACT(MONTH FROM a."VCH_DATE")::int AS "name", SUM(coalesce(a."DR_AMT",0)) AS "value", EXTRACT(DAY FROM a."VCH_DATE")::int AS "totAmt"`
          : `EXTRACT(MONTH FROM a."VCH_DATE")::int AS "name", SUM(coalesce(a."DR_AMT",0)) AS "value", b."AC_NAME" AS "totAmt"`;
      const order =
        mode === 'expense-by-day'
          ? `EXTRACT(DAY FROM a."VCH_DATE")::int`
          : `EXTRACT(MONTH FROM a."VCH_DATE")::int, b."AC_NAME"`;
      const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT ${select}
           FROM "AC_DATA" a
           LEFT JOIN "AC_MAST" b
             ON b.tenant_id=a.tenant_id
            AND b."CO_CODE"=a."CO_CODE"
            AND b."AC_CODE"=a."AC_CODE"
          WHERE ${where.join(' AND ')}
          GROUP BY ${group}
         HAVING SUM(coalesce(a."DR_AMT",0)) > 0
          ORDER BY ${order}`,
        ...params,
      );
      const mapped = mappedRows(rows, mode);
      return {
        rows: mapped,
        totals: {
          rows: mapped.length,
          value: round2(mapped.reduce((t, r) => t + num(r.value), 0)),
        },
      };
    }

    if (mode === 'karigar-sales') {
      where.push(`a."LC_CODE"=${pushParam(params, lcCode)}`);
      if (s.coYear) where.push(`a."CO_YEAR"=${pushParam(params, s.coYear)}`);
      addDataTypeFilter(params, where, 'bar', dataType);
      addGroupAndItemFilters(params, where, grCode, itemType);
      where.push(`a."ITM_SIGN"='-'`);
      where.push(`a."TR_TYPE"='S'`);
      addDateWindow(params, where, fromDate, toDate);
      const valueExpr = metric === 'weight' ? 'coalesce(a."ITM_NWT",0)' : 'coalesce(a."NET_AMT",0)';
      const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT bar."KR_NAME" AS "name", SUM(${valueExpr}) AS "value", d."IT_NAME" AS "totAmt"
           FROM "MAIN_STOCK" a
           INNER JOIN "BAR_DETL" bar
             ON bar.tenant_id=a.tenant_id
            AND bar."CO_CODE"=a."CO_CODE"
            AND bar."LC_CODE"=a."LC_CODE"
            AND bar."TAG_NO"=a."TAG_NO"
            AND bar."VCH_SRNO"=a."VCH_SRNO"
           LEFT JOIN "ITEM_MAST" d
             ON d.tenant_id=a.tenant_id
            AND d."CO_CODE"=a."CO_CODE"
            AND d."IT_CODE"=a."IT_CODE"
          WHERE ${where.join(' AND ')}
          GROUP BY bar."KR_NAME", d."IT_NAME"
          ORDER BY bar."KR_NAME", d."IT_NAME"`,
        ...params,
      );
      const mapped = mappedRows(rows, mode);
      return {
        rows: mapped,
        totals: {
          rows: mapped.length,
          value: round3(mapped.reduce((t, r) => t + num(r.value), 0)),
        },
      };
    }

    where.push(`a."LC_CODE"=${pushParam(params, lcCode)}`);
    if (mode === 'product-sales' || mode === 'employee-sales') {
      if (s.coYear) where.push(`a."CO_YEAR"=${pushParam(params, s.coYear)}`);
    }
    addMainBookFilter(params, where, bookType);
    addDataTypeFilter(params, where, 'b', dataType);
    addGroupAndItemFilters(params, where, grCode, itemType);
    const aggs = stockAggregates(metric, transactionType);
    if (aggs.sign) where.push(aggs.sign.replace(/^ AND /, ''));
    addDateWindow(params, where, fromDate, toDate);

    const sql =
      mode === 'last-30-day-sales'
        ? `SELECT a."VCH_DATE" AS "name", ${aggs.value} AS "value", ${aggs.value} AS "totAmt"
             FROM "MAIN_STOCK" a
             LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
             LEFT JOIN "ITEM_MAST" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."IT_CODE"=a."IT_CODE"
            WHERE ${where.join(' AND ')}
            GROUP BY a."VCH_DATE"
            ORDER BY a."VCH_DATE"`
        : mode === 'month-sales'
          ? `SELECT EXTRACT(MONTH FROM a."VCH_DATE")::int AS "code", trim(to_char(a."VCH_DATE", 'Mon')) AS "name", ${aggs.value} AS "value", ${aggs.value} AS "totAmt"
               FROM "MAIN_STOCK" a
               LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
               LEFT JOIN "ITEM_MAST" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."IT_CODE"=a."IT_CODE"
              WHERE ${where.join(' AND ')}
              GROUP BY EXTRACT(MONTH FROM a."VCH_DATE")::int, trim(to_char(a."VCH_DATE", 'Mon'))
              ORDER BY EXTRACT(MONTH FROM a."VCH_DATE")::int, trim(to_char(a."VCH_DATE", 'Mon'))`
          : mode === 'product-sales'
            ? `SELECT d."PR_CODE" AS "name", ${aggs.value} AS "value", ${aggs.series} AS "totAmt"
                 FROM "MAIN_STOCK" a
                 LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
                 LEFT JOIN "ITEM_MAST" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."IT_CODE"=a."IT_CODE"
                WHERE ${where.join(' AND ')}
                GROUP BY d."PR_CODE"
                ORDER BY d."PR_CODE"`
            : `SELECT a."EMP_CODE" AS "name", ${aggs.value} AS "value", ${aggs.series} AS "totAmt"
                 FROM "MAIN_STOCK" a
                 LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
                 LEFT JOIN "ITEM_MAST" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."IT_CODE"=a."IT_CODE"
                WHERE ${where.join(' AND ')}
                GROUP BY a."EMP_CODE"
                ORDER BY a."EMP_CODE"`;

    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(sql, ...params);
    const mapped = mappedRows(rows, mode);
    const numericTot = mapped.every((row) => row.totAmt === '' || typeof row.totAmt === 'number');
    return {
      rows: mapped,
      totals: {
        rows: mapped.length,
        value: round3(mapped.reduce((t, r) => t + num(r.value), 0)),
        ...(numericTot ? { totAmt: round3(mapped.reduce((t, r) => t + num(r.totAmt), 0)) } : {}),
      },
    };
  });
}
