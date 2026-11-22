import { round } from '@datacare/core';
import { resolveSettingsBehaviorTx } from '../../shared/settingsBehavior.js';
import { withTxBudget } from '../../shared/txBudget.js';
import {
  parseMovementRequest,
  parseStockRequest,
  StockReportError,
  type Dimension,
  type StockFilters,
} from './parse.js';
import { movementsQuery, summaryQuery, type SqlQuery, type StockScope } from './sql.js';

export { StockReportError } from './parse.js';
export type { Dimension, StockFilters } from './parse.js';

/**
 * Report -> Stock Report, the desktop RP_STOCK form (MDI_FORM.cs:8881-8890).
 *
 * Every figure is the sum of signed MAIN_STOCK movements for the session's company, location and year
 * (RP_STOCK.cs:4284); none comes from a BAR_DETL snapshot and none from the shared `onHandNet()` helper, which
 * takes fine from ITM_FINE for both signs and has no date range (listed as a separate defect in the PR). The
 * report writes nothing.
 */

export interface StockSession {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

export const FIGURES = [
  'opPcs',
  'opWt',
  'prPcs',
  'prWt',
  'inPcs',
  'inWt',
  'outPcs',
  'outWt',
  'slPcs',
  'slWt',
  'clPcs',
  'clWt',
  'tInPcs',
  'tInWt',
  'tOutPcs',
  'tOutWt',
] as const;
export type FigureKey = (typeof FIGURES)[number];
export type Figures = Record<FigureKey, number>;

export interface StockRow extends Figures {
  code: string;
  name: string;
  itType: string;
}

export interface StockResult {
  dimension: Dimension;
  title: string;
  weight: 'net' | 'gross';
  fromDate: string;
  toDate: string;
  filters: StockFilters;
  rows: StockRow[];
  /** The "Total :" row (RP_STOCK.cs:5052): the arithmetic sum of every column, hidden transfer columns included. */
  totals: Figures;
}

export interface MovementRow {
  vchType: string | null;
  mainBook: string | null;
  coBook: string | null;
  partyName: string;
  vchNo: string | null;
  vchDate: string | null;
  tagNo: string | null;
  itLot: string | null;
  itName: string;
  pcs: number;
  gwt: number;
  nwt: number;
  fine: number;
  sign: '+' | '-';
}
export interface MovementResult {
  dimension: Dimension;
  column: string;
  key: string;
  rowType: string;
  rows: MovementRow[];
  totals: { pcs: number; gwt: number; nwt: number; fine: number };
}

/** Print titles by dimension (RP_STOCK.cs:4029-4051): Item, Size, Design, Trading and the rest use "Item Wise". */
const TITLE_PREFIX: Record<Dimension, string> = {
  group: 'Group Wise Stock From Date  ',
  product: 'Product Wise Stock From Date  ',
  counter: 'Counter Wise Stock From Date  ',
  safe: 'Safe Wise Stock From Date  ',
  item: 'Item Wise Stock From Date  ',
  size: 'Item Wise Stock From Date  ',
  design: 'Item Wise Stock From Date  ',
  trading: 'Item Wise Stock From Date  ',
};
const ddmmyyyy = (iso: string) => `${iso.slice(8, 10)}/${iso.slice(5, 7)}/${iso.slice(0, 4)}`;

const num = (v: unknown): number => (v === null || v === undefined ? 0 : Number(v) || 0);
const r3 = (v: unknown): number => round(num(v), 3);

async function scopeOf(
  tx: any,
  session: StockSession,
): Promise<StockScope & { grossDefault: boolean }> {
  const behavior = await resolveSettingsBehaviorTx(tx, {
    tenantId: session.tenantId,
    coCode: session.coCode,
  });
  return {
    tenantId: session.tenantId,
    coCode: session.coCode,
    lcCode: session.lcCode,
    coYear: session.coYear,
    merge: behavior.companyStockMerge,
    grossDefault: behavior.stockReportGrossWeight,
  };
}

export async function stockSummary(
  prisma: any,
  session: StockSession,
  rawQuery: Record<string, unknown>,
): Promise<StockResult> {
  const request = parseStockRequest(rawQuery);
  return withTxBudget(prisma, session.tenantId, 'read', async (tx: any) => {
    const scope = await scopeOf(tx, session);
    const gross = request.filters.gross ?? scope.grossDefault;
    const q: SqlQuery = summaryQuery(request.dimension, scope, request.filters, gross);
    const raw: Record<string, unknown>[] = await tx.$queryRawUnsafe(q.text, ...q.values);
    const totals = Object.fromEntries(FIGURES.map((k) => [k, 0])) as Figures;
    const rows = raw.map((r): StockRow => {
      const row = {
        code: String(r.code ?? ''),
        name: String(r.name ?? ''),
        itType: String(r.itType ?? ''),
      } as StockRow;
      for (const k of FIGURES) {
        row[k] = r3(r[k]);
        totals[k] = round(totals[k] + row[k], 3);
      }
      return row;
    });
    return {
      dimension: request.dimension,
      // RptTitel = text + From + " To " + To (RP_STOCK.cs:4224).
      title: `${TITLE_PREFIX[request.dimension]}${ddmmyyyy(request.filters.fromDate)} To ${ddmmyyyy(request.filters.toDate)}`,
      weight: gross ? 'gross' : 'net',
      fromDate: request.filters.fromDate,
      toDate: request.filters.toDate,
      filters: request.filters,
      rows,
      totals,
    };
  });
}

export async function stockMovements(
  prisma: any,
  session: StockSession,
  rawQuery: Record<string, unknown>,
): Promise<MovementResult> {
  const request = parseMovementRequest(rawQuery);
  return withTxBudget(prisma, session.tenantId, 'read', async (tx: any) => {
    const scope = await scopeOf(tx, session);
    const q = movementsQuery(
      request.dimension,
      scope,
      request.filters,
      request.key,
      request.rowType,
      request.column,
    );
    const raw: Record<string, unknown>[] = await tx.$queryRawUnsafe(q.text, ...q.values);
    const rows = raw.map((r): MovementRow => ({
      vchType: (r.vchType as string | null) ?? null,
      mainBook: (r.mainBook as string | null) ?? null,
      coBook: (r.coBook as string | null) ?? null,
      partyName: String(r.partyName ?? ''),
      vchNo: (r.vchNo as string | null) ?? null,
      vchDate: (r.vchDate as string | null) ?? null,
      tagNo: (r.tagNo as string | null) ?? null,
      itLot: (r.itLot as string | null) ?? null,
      itName: String(r.itName ?? ''),
      pcs: r3(r.pcs),
      gwt: r3(r.gwt),
      nwt: r3(r.nwt),
      fine: r3(r.fine),
      sign: r.sign === '+' ? '+' : '-',
    }));
    // Opening and Closing add a '+' row and subtract a '-' row (RP_STOCK.cs:3175); the in-period columns add all.
    const signed = request.column === 'opening' || request.column === 'closing';
    const totals = { pcs: 0, gwt: 0, nwt: 0, fine: 0 };
    for (const r of rows) {
      const s = signed && r.sign === '-' ? -1 : 1;
      for (const k of ['pcs', 'gwt', 'nwt', 'fine'] as const)
        totals[k] = round(totals[k] + s * r[k], 3);
    }
    return {
      dimension: request.dimension,
      column: request.column,
      key: request.key,
      rowType: request.rowType,
      rows,
      totals,
    };
  });
}

export interface StockDefaults {
  fromDate: string;
  toDate: string;
  itemType: string;
  stockType: 'all';
  grossWeight: boolean;
  /** CO_STK_MERGE: the voucher zoom and any LC-specific behaviour are off while merged (RP_STOCK.cs:5225). */
  companyMerge: boolean;
}

function todayIso(): string {
  const zone = process.env.PRINT_TIME_ZONE?.trim() || 'Asia/Kolkata';
  try {
    return new Intl.DateTimeFormat('en-CA', { timeZone: zone }).format(new Date());
  } catch {
    return new Date().toISOString().slice(0, 10);
  }
}

/** Form defaults: From = the year's opening date, To = the system date, Gold, All, STK_RPT_TYPE (RP_STOCK.cs:3705-3647). */
export async function stockDefaults(prisma: any, session: StockSession): Promise<StockDefaults> {
  return withTxBudget(prisma, session.tenantId, 'read', async (tx: any) => {
    const scope = await scopeOf(tx, session);
    const rows: Array<{ opening: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "OP_DATE"::date::text AS opening FROM "YEAR_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2 AND "CO_YEAR"=$3 LIMIT 1`,
      session.tenantId,
      session.coCode,
      session.coYear,
    );
    const start = /^(\d{4})/.exec(session.coYear)?.[1] ?? String(new Date().getUTCFullYear());
    return {
      fromDate: rows[0]?.opening ?? `${start}-04-01`,
      toDate: todayIso(),
      itemType: 'G',
      stockType: 'all',
      grossWeight: scope.grossDefault,
      companyMerge: scope.merge,
    };
  });
}

/** Visible grid columns of the export (the Excel button writes the visible grid, RP_STOCK.cs:3232-3340). */
const EXPORT_COLUMNS: Array<[string, FigureKey | null]> = [
  ['OpPcs', 'opPcs'],
  ['OpWt', 'opWt'],
  ['PrPcs', 'prPcs'],
  ['PrWt', 'prWt'],
  ['InPcs', 'inPcs'],
  ['InWt', 'inWt'],
  ['OuPcs', 'outPcs'],
  ['OuWt', 'outWt'],
  ['SlPcs', 'slPcs'],
  ['SlWt', 'slWt'],
  ['ClPcs', 'clPcs'],
  ['ClWt', 'clWt'],
];
export interface ExportTable {
  title: string;
  header: string[];
  lines: string[][];
}
const cell = (key: FigureKey, v: number) => (key.endsWith('Wt') ? v.toFixed(3) : String(v));
export function exportTable(result: StockResult): ExportTable {
  const header = ['SrNo', 'Item Name', 'ItType', ...EXPORT_COLUMNS.map(([c]) => c)];
  const lines = result.rows.map((r, i) => [
    String(i + 1),
    r.name,
    r.itType,
    ...EXPORT_COLUMNS.map(([, k]) => cell(k!, r[k!])),
  ]);
  lines.push(['', 'Total :', '', ...EXPORT_COLUMNS.map(([, k]) => cell(k!, result.totals[k!]))]);
  return { title: result.title, header, lines };
}

const risky = (s: string) => /^[=+@\t]/.test(s) || (s.startsWith('-') && !/^-\d+(\.\d+)?$/.test(s));
const csvCell = (s: string) => {
  const guarded = risky(s) ? `'${s}` : s;
  return /[",\n\r]/.test(guarded) || guarded !== s ? `"${guarded.replace(/"/g, '""')}"` : s;
};
export function exportCsv(result: StockResult): string {
  const t = exportTable(result);
  return `${[t.header, ...t.lines].map((l) => l.map(csvCell).join(',')).join('\r\n')}\r\n`;
}
