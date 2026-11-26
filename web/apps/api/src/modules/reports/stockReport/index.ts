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
    itemLot: behavior.itemWithLotStock,
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
  /** The system date: what Cancel resets To to (CLEAR_DATA, RP_STOCK.cs:3733), whatever a future voucher did to To on open. */
  systemDate: string;
  itemType: string;
  stockType: 'all';
  grossWeight: boolean;
  /** CO_STK_MERGE: the voucher zoom and any LC-specific behaviour are off while merged (RP_STOCK.cs:5225). */
  companyMerge: boolean;
  /** ITM_WITH_LOT_STK = Y: the Safe button reads Item Lot and groups by lot (RP_STOCK.cs:3701, :4485). */
  itemLot: boolean;
  /**
   * The latest movement dated after today (RP_STOCK.cs:3713-3718): the desktop warns on open and sets To to its date.
   * `message` is the desktop's text, ready to show.
   */
  futureVoucher: { bookName: string; vchNo: string; vchDate: string; message: string } | null;
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
    // MsMetalType (MS_OPNCOMP.cs:481-485, a blank one is G): Gold when G, otherwise Silver (RP_STOCK.cs:3628-3635).
    const metal: Array<{ metal: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "METAL_TYPE" AS metal FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"::text=$2 LIMIT 1`,
      session.tenantId,
      session.coCode,
    );
    const metalType = String(metal[0]?.metal ?? '').trim() || 'G';
    const today = todayIso();
    // RP_STOCK.cs:3713: any later-dated movement of this location (every year), the latest first.
    const future: Array<{ bookName: string | null; vchNo: string | null; vchDate: string }> =
      await tx.$queryRawUnsafe(
        `SELECT b."BOOK_NAME" AS "bookName", a."VCH_NO" AS "vchNo", a."VCH_DATE"::date::text AS "vchDate"
           FROM "MAIN_STOCK" a
           LEFT JOIN "BOOK_DATA" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."LC_CODE"=a."LC_CODE" AND b."CO_BOOK"=a."CO_BOOK"
          WHERE a.tenant_id=$1 AND a."CO_CODE"::text=$2 AND a."LC_CODE"=$3 AND a."VCH_DATE"::date > $4::date
          ORDER BY a."VCH_DATE" DESC LIMIT 1`,
        session.tenantId,
        session.coCode,
        session.lcCode,
        today,
      );
    const f = future[0];
    const futureVoucher = f
      ? {
          bookName: String(f.bookName ?? ''),
          vchNo: String(f.vchNo ?? ''),
          vchDate: f.vchDate,
          message: `Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = ${f.bookName ?? ''} And VchNo = ${f.vchNo ?? ''}....`,
        }
      : null;
    return {
      fromDate: rows[0]?.opening ?? `${start}-04-01`,
      toDate: futureVoucher?.vchDate ?? today,
      systemDate: today,
      itemType: metalType === 'G' ? 'G' : 'S',
      stockType: 'all',
      grossWeight: scope.grossDefault,
      companyMerge: scope.merge,
      itemLot: Boolean(scope.itemLot),
      futureVoucher,
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

// ---------------------------------------------------------------------------------------------------------------
// Voucher zoom (RP_STOCK.cs:5218-5600 DGV_VCH_DoubleClick)
// ---------------------------------------------------------------------------------------------------------------

/** The entry screen of each stock-moving book of the Lite edition; the other books' menus are not in Lite. */
const OPENING = { path: '/txn/tag-opening', form: 'Inventory/Tag Opening' };
const ZOOM_TARGETS: Record<string, { path: string; form: string }> = {
  OPSTK: OPENING, // RP_STOCK.cs:5265
  'TAG OPENING': OPENING, // the web's Tag Opening book (seedCompany.ts, book TOP)
  'TAG GEN': OPENING, // RP_STOCK.cs:5272
  'JDTR TAG': OPENING,
  'MFG TAG': OPENING,
  'TAG CANCEL': { path: '/txn/tag-cancel', form: 'Inventory/Tag Cancel' }, // RP_STOCK.cs:5281
  'STOCK ADJUST': { path: '/txn/stock-adjust', form: 'Inventory/Stock Adjust' }, // RP_STOCK.cs:5288
  'APR ISU': { path: '/txn/tour', form: 'Sales/Tour / Approval Sale' }, // RP_STOCK.cs:5295
  'APR RTN': { path: '/txn/tour-return', form: 'Sales/Approval Return' }, // RP_STOCK.cs:5302
  SALES: { path: '/txn/sales', form: 'Sales/Sales Invoice' }, // RP_STOCK.cs:5316
  PURCHASE: { path: '/txn/purchase', form: 'Purchase/Purchase Invoice' }, // RP_STOCK.cs:5333
  'PURC RETURN': { path: '/txn/purchase-return', form: 'Purchase/Purchase Return' }, // RP_STOCK.cs:5350
  'SALES RETURNE': { path: '/txn/sale-return', form: 'Sales/Sales Return' }, // RP_STOCK.cs:5423
};
export const ZOOM_NO_RIGHTS = 'You Have No Rights...'; // RP_STOCK.cs:5248 (three dots)
export const ZOOM_ITEM_OPENING = 'This Is a Item Wise Opening Stock Voucher You Cant Zoom ....'; // RP_STOCK.cs:5263

export type ZoomAnswer =
  | { action: 'none' }
  | { action: 'refuse'; message: string }
  | { action: 'open'; path: string; vchNo: string; coBook: string; coYear: string; lcCode: string };

/**
 * What a double click on a movement row does. Nothing opens while the companies' stock is merged. The target menu's
 * View right is needed (the desktop refuses only an explicit N; the hosted service refuses a missing row as well,
 * decision 5, so `canView` answers for the form). A voucher number shorter than three characters is an Item Opening
 * row and is refused with the desktop text.
 */
export async function stockZoom(
  prisma: any,
  session: StockSession,
  coBook: string,
  vchNo: string,
  canView: (form: string) => Promise<boolean>,
): Promise<ZoomAnswer> {
  const book = await withTxBudget(prisma, session.tenantId, 'read', async (tx: any) => {
    const scope = await scopeOf(tx, session);
    if (scope.merge) return { merged: true, main: null as string | null };
    const rows: Array<{ main: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "MAIN_BOOK" AS main FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 LIMIT 1`,
      session.tenantId,
      session.coCode,
      session.lcCode,
      coBook,
    );
    return { merged: false, main: rows[0] ? String(rows[0].main ?? '') : null };
  });
  if (book.merged) return { action: 'none' };
  const wanted = vchNo.trim();
  // A book the location does not define opens nothing, except the Item Opening rows (a short voucher number), whose
  // refusal does not depend on the book's entry screen.
  if (book.main === null)
    return wanted.length < 3
      ? { action: 'refuse', message: ZOOM_ITEM_OPENING }
      : { action: 'none' };
  const target = ZOOM_TARGETS[book.main];
  if (target && !(await canView(target.form))) return { action: 'refuse', message: ZOOM_NO_RIGHTS };
  if (wanted.length < 3) return { action: 'refuse', message: ZOOM_ITEM_OPENING };
  if (!target) return { action: 'none' };
  return {
    action: 'open',
    path: target.path,
    vchNo: wanted,
    coBook,
    coYear: session.coYear,
    lcCode: session.lcCode,
  };
}

// ---------------------------------------------------------------------------------------------------------------
// InOut: the item ledger of the ticked items (RP_STOCK.cs:5857-5976 BtnDelete_Click, ItmList, btnOk_Click)
// ---------------------------------------------------------------------------------------------------------------

export const ITEM_SELECTION_NOT_DONE = 'Item Selection Not Done...'; // RP_STOCK.cs:5942

/** The items the picker lists for an Item Type (RP_STOCK.cs:5879): code and name, ordered by name. */
export async function itemLedgerItems(
  prisma: any,
  session: StockSession,
  itemType: string,
): Promise<Array<{ code: string; name: string }>> {
  const type = String(itemType ?? '').slice(0, 1);
  return withTxBudget(prisma, session.tenantId, 'read', async (tx: any) => {
    const rows: Array<{ code: string; name: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE" AS code, "IT_NAME" AS name FROM "ITEM_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2 AND "IT_TYPE"=$3 ORDER BY "IT_NAME"`,
      session.tenantId,
      session.coCode,
      type,
    );
    return rows.map((r) => ({ code: String(r.code), name: String(r.name ?? '') }));
  });
}

export interface LedgerRow {
  date: string;
  vchType: string;
  vchNo: string;
  party: string;
  tagNo: string;
  pcs: number;
  grossWt: number;
  netWt: number;
  sign: '+' | '-';
}
export interface ItemLedger {
  title: string;
  fromDate: string;
  toDate: string;
  items: Array<{
    code: string;
    name: string;
    openingPcs: number;
    openingNetWt: number;
    rows: LedgerRow[];
    closingPcs: number;
    closingNetWt: number;
  }>;
}

const ISO = /^\d{4}-\d{2}-\d{2}$/;
const dmy = (iso: string) => `${iso.slice(8, 10)}/${iso.slice(5, 7)}/${iso.slice(0, 4)}`;

/**
 * The movements of the ticked items up to the To date (RP_STOCK.cs:5958 `IT_CODE in [..]`, VCH_DATE <= To), grouped by
 * item with the opening before From and the closing at To. The desktop prints them through ItemLedger.rpt.
 */
export async function itemLedger(
  prisma: any,
  session: StockSession,
  raw: { items?: unknown; fromDate?: unknown; toDate?: unknown },
): Promise<ItemLedger> {
  const codes = String(raw.items ?? '')
    .split(',')
    .map((c) => c.trim())
    .filter(Boolean);
  if (codes.length === 0)
    throw new StockReportError('item-selection-not-done', ITEM_SELECTION_NOT_DONE);
  if (codes.length > 500 || codes.some((c) => c.length > 20 || /[\u0000-\u001f]/.test(c)))
    throw new StockReportError('bad-items', 'The item list is too long or has an invalid code');
  const fromDate = String(raw.fromDate ?? '');
  const toDate = String(raw.toDate ?? '');
  if (!ISO.test(fromDate) || !ISO.test(toDate))
    throw new StockReportError('bad-date', 'From and To must be dates');
  return withTxBudget(prisma, session.tenantId, 'read', async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."IT_CODE" AS code, COALESCE(b."IT_NAME", '') AS name, to_char(a."VCH_DATE", 'YYYY-MM-DD') AS date,
              COALESCE(bd."BOOK_SNAME", '') AS "vchType", COALESCE(a."VCH_NO", '') AS "vchNo", COALESCE(ac."AC_NAME", '') AS party,
              COALESCE(a."TAG_NO", '') AS "tagNo", COALESCE(a."ITM_PCS", 0)::float8 AS pcs, COALESCE(a."ITM_GWT", 0)::float8 AS gwt,
              COALESCE(a."ITM_NWT", 0)::float8 AS nwt, CASE WHEN a."ITM_SIGN" = '+' THEN '+' ELSE '-' END AS sign
         FROM "MAIN_STOCK" a
         LEFT JOIN "ITEM_MAST" b ON b.tenant_id=a.tenant_id AND b."CO_CODE"=a."CO_CODE" AND b."IT_CODE"=a."IT_CODE"
         LEFT JOIN LATERAL (SELECT "BOOK_SNAME" FROM "BOOK_DATA" x WHERE x."CO_CODE" = a."CO_CODE" AND x."CO_BOOK" = a."CO_BOOK"
              ORDER BY (x."LC_CODE" = a."LC_CODE") DESC NULLS LAST LIMIT 1) bd ON true
         LEFT JOIN LATERAL (SELECT "AC_NAME" FROM "AC_MAST" x WHERE x."CO_CODE" = a."CO_CODE" AND x."AC_CODE" = a."AC_CODE" LIMIT 1) ac ON true
        WHERE a.tenant_id=$1 AND a."CO_CODE"::text=$2 AND a."CO_YEAR"=$3 AND a."LC_CODE"=$4
          AND a."VCH_DATE"::date <= $5::date AND a."IT_CODE" = ANY($6::text[])
        ORDER BY a."IT_CODE", a."VCH_DATE", a."VCH_NO", a."SR_NO", a.row_id`,
      session.tenantId,
      session.coCode,
      session.coYear,
      session.lcCode,
      toDate,
      codes,
    );
    const byItem = new Map<string, ItemLedger['items'][number]>();
    for (const r of rows) {
      const code = String(r.code);
      let item = byItem.get(code);
      if (!item) {
        item = {
          code,
          name: String(r.name),
          openingPcs: 0,
          openingNetWt: 0,
          rows: [],
          closingPcs: 0,
          closingNetWt: 0,
        };
        byItem.set(code, item);
      }
      const sign = r.sign === '+' ? 1 : -1;
      const pcs = Number(r.pcs);
      const nwt = Number(r.nwt);
      if (String(r.date) < fromDate) {
        item.openingPcs = round(item.openingPcs + sign * pcs, 3);
        item.openingNetWt = round(item.openingNetWt + sign * nwt, 3);
      } else {
        item.rows.push({
          date: String(r.date),
          vchType: String(r.vchType),
          vchNo: String(r.vchNo),
          party: String(r.party),
          tagNo: String(r.tagNo),
          pcs,
          grossWt: Number(r.gwt),
          netWt: nwt,
          sign: r.sign === '+' ? '+' : '-',
        });
      }
      item.closingPcs = round(item.closingPcs + sign * pcs, 3);
      item.closingNetWt = round(item.closingNetWt + sign * nwt, 3);
    }
    return {
      // RP_STOCK.cs:5970: "Stock Ledger Report From dd/MM/yyyy To dd/MM/yyyy".
      title: `Stock Ledger Report From ${dmy(fromDate)} To ${dmy(toDate)}`,
      fromDate,
      toDate,
      items: codes.filter((c) => byItem.has(c)).map((c) => byItem.get(c)!),
    };
  });
}

/** The ledger as the flat table the shared PDF writer prints: one block per item, its opening and closing lines. */
export function itemLedgerTable(ledger: ItemLedger): {
  title: string;
  rows: Array<Record<string, string>>;
} {
  const rows: Array<Record<string, string>> = [];
  const fmt = (n: number) => n.toFixed(3);
  for (const item of ledger.items) {
    rows.push({
      Item: item.name,
      Date: '',
      Book: 'Opening',
      VchNo: '',
      Party: '',
      TagNo: '',
      Pcs: String(item.openingPcs),
      NetWt: fmt(item.openingNetWt),
      Sign: '',
    });
    for (const r of item.rows)
      rows.push({
        Item: item.name,
        Date: dmy(r.date),
        Book: r.vchType,
        VchNo: r.vchNo,
        Party: r.party,
        TagNo: r.tagNo,
        Pcs: String(r.pcs),
        NetWt: fmt(r.netWt),
        Sign: r.sign,
      });
    rows.push({
      Item: item.name,
      Date: dmy(ledger.toDate),
      Book: 'Closing',
      VchNo: '',
      Party: '',
      TagNo: '',
      Pcs: String(item.closingPcs),
      NetWt: fmt(item.closingNetWt),
      Sign: '',
    });
  }
  return { title: ledger.title, rows };
}
