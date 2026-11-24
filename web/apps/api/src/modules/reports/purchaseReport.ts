import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { reportTitle, runLayout, formatCell } from './rpAll/engine.js';
import { exportTable, type ExportTable } from './rpAll/exportRows.js';
import {
  parseRpAllFilters,
  RpAllRequestError,
  type RpAllFilters,
  type RpAllSessionScope,
} from './rpAll/filters.js';
import type { RpAllResult } from './rpAll/index.js';
import {
  PURCHASE_MODES,
  PURCHASE_SPECS,
  type PurchaseFilterKey,
  type PurchaseMode,
} from './rpAll/purchaseLayouts.js';
import { buildPurchaseQuery } from './rpAll/purchaseQuery.js';
import type { RpAllRecord, RpAllValue } from './rpAll/types.js';
import { escapeHtml } from './render.js';

/**
 * Report → Purchase Rpt: the desktop RP_ALL form in its "Purchase Rpt" caption (MDI_FORM.cs:8911-8920,
 * RP_ALL.cs:6704-6707 shows PanelPurc). The selector parsing, grouping, count-once totals and export flattening
 * are the shared RP_ALL engine of the Sales Report (modules/reports/rpAll); this module adds the purchase mode
 * table and read, and the voucher totals line the web prints under every mode.
 */

export { RpAllRequestError } from './rpAll/filters.js';

const FILTER_KEYS: readonly PurchaseFilterKey[] = [
  'lcCode',
  'coBook',
  'books',
  'acCode',
  'prCode',
  'grCode',
  'city',
  'area',
  'state',
  'empCode',
  'itemType',
];

/** The totals of the vouchers behind the selection, each voucher counted once whatever the mode prints. */
export interface PurchaseSelection {
  voucherCount: number;
  netAmt: number;
  taxAmt: number;
  totAmt: number;
  /** Line sums; null for Purc Reg, which reads no lines. */
  fine: number | null;
  nwt: number | null;
}

export interface PurchaseReportResponse extends Omit<RpAllResult, 'rows' | 'groups'> {
  table: ExportTable;
  selection: PurchaseSelection;
}

export interface PurchaseRequest {
  mode: PurchaseMode;
  filters: RpAllFilters;
}

const todayServer = (now = new Date()): string => {
  const pad = (v: number) => String(v).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
};

/**
 * Parse the whole request. Both dates default to today, as the desktop form opens with the system date in both
 * boxes (RP_ALL.cs:7195-7202). From after To is not an error here: the desktop prints an empty report; the screen
 * refuses the reversed range before it asks.
 */
export function parsePurchaseRequest(
  query: Record<string, unknown>,
  session: RpAllSessionScope,
  today: string = todayServer(),
): PurchaseRequest {
  const rawMode = query.mode;
  const mode = (typeof rawMode === 'string' && rawMode !== '' ? rawMode : 'report') as PurchaseMode;
  if (!PURCHASE_MODES.includes(mode))
    throw new RpAllRequestError(
      'invalid-mode',
      `mode must be one of ${PURCHASE_MODES.join(', ')}`,
      {
        field: 'mode',
      },
    );
  const dated = { ...query };
  for (const key of ['fromDate', 'toDate'] as const) {
    const raw = dated[key];
    if (raw === undefined || raw === null || (typeof raw === 'string' && raw.trim() === ''))
      dated[key] = today;
  }
  const filters = parseRpAllFilters(dated, session);
  const spec = PURCHASE_SPECS[mode];
  const lacking = spec.templateLacks.filter((key) => filters[key] !== undefined);
  if (lacking.length)
    throw new RpAllRequestError(
      'filter-not-in-template',
      `${spec.caption}: the desktop template has no party master, so ${lacking.join(', ')} cannot be applied`,
      { fields: lacking },
    );
  return { mode, filters };
}

function toRecord(row: Record<string, unknown>): RpAllRecord {
  const out: Record<string, RpAllValue> = {};
  for (const [key, value] of Object.entries(row)) {
    if (value === null || value === undefined) out[key] = null;
    else if (typeof value === 'number' || typeof value === 'string') out[key] = value;
    else if (typeof value === 'bigint') out[key] = Number(value);
    else out[key] = String(value);
  }
  return out;
}

const num = (r: RpAllRecord, key: string): number => {
  const v = r[key];
  return typeof v === 'number' ? v : v === null || v === undefined || v === '' ? 0 : Number(v);
};

/** Voucher totals counted once per voucher, line sums once per line (the same count-once rule as the engine). */
export function selectionTotals(
  records: readonly RpAllRecord[],
  withLines: boolean,
): PurchaseSelection {
  const vouchers = new Set<string>();
  const lines = new Set<string>();
  let netAmt = 0;
  let taxAmt = 0;
  let totAmt = 0;
  let fine = 0;
  let nwt = 0;
  for (const r of records) {
    const v = `${r.lcCode}|${r.coBook}|${r.vchNo}`;
    if (!vouchers.has(v)) {
      vouchers.add(v);
      netAmt = round(netAmt + num(r, 'netAmt'), 6);
      taxAmt = round(taxAmt + num(r, 'taxAmt'), 6);
      totAmt = round(totAmt + num(r, 'totAmt'), 6);
    }
    if (withLines && r.srNo !== null && r.srNo !== undefined) {
      const l = `${v}|${r.srNo}`;
      if (!lines.has(l)) {
        lines.add(l);
        fine = round(fine + num(r, 'fine'), 6);
        nwt = round(nwt + num(r, 'nwt'), 6);
      }
    }
  }
  return {
    voucherCount: vouchers.size,
    netAmt: round(netAmt, 2),
    taxAmt: round(taxAmt, 2),
    totAmt: round(totAmt, 2),
    fine: withLines ? round(fine, 3) : null,
    nwt: withLines ? round(nwt, 3) : null,
  };
}

/** The pure half of a run: adapter records → derived formula fields → engine → response. */
export function shapePurchaseResult(
  request: PurchaseRequest,
  records: readonly RpAllRecord[],
): PurchaseReportResponse {
  const spec = PURCHASE_SPECS[request.mode];
  const prepared = spec.prepare ? spec.prepare(records) : [...records];
  const derived: RpAllRecord[] = prepared.map((record) =>
    spec.derive ? { ...record, ...(spec.derive(record) as Record<string, RpAllValue>) } : record,
  );
  const layout = spec.layout;
  const result = runLayout(layout, derived);
  const full: RpAllResult = {
    branch: 'purchase',
    mode: request.mode,
    caption: spec.caption,
    variant: 'sale',
    template: layout.template,
    title: reportTitle(layout.titlePrefix, request.filters.fromDate, request.filters.toDate),
    columns: [...layout.columns],
    groups: result.groups,
    groupLevels: layout.groups.map((g) => ({
      key: g.key,
      subtotal: g.subtotal,
      ...(g.subtotalCaption ? { subtotalCaption: g.subtotalCaption } : {}),
    })),
    rows: result.rows,
    totals: result.totals,
    grandTotal: layout.grandTotal,
    ...(layout.grandTotalCaption ? { grandTotalCaption: layout.grandTotalCaption } : {}),
    voucherCount: result.voucherCount,
    filters: request.filters,
    ignoredFilters: FILTER_KEYS.filter(
      (key) =>
        key !== 'lcCode' &&
        request.filters[key] !== undefined &&
        !(spec.filters as readonly string[]).includes(key),
    ),
    cite: spec.cite,
  };
  const { rows: _rows, groups: _groups, ...rest } = full;
  return {
    ...rest,
    table: exportTable(full),
    selection: selectionTotals(derived, spec.query.lines),
  };
}

/** Read the mode's record set: one parameterised SELECT inside a read budget. */
export async function fetchPurchaseRecords(
  prisma: any,
  session: RpAllSessionScope,
  request: PurchaseRequest,
): Promise<RpAllRecord[]> {
  const spec = PURCHASE_SPECS[request.mode];
  const query = buildPurchaseQuery({
    shape: spec.query,
    scope: session,
    filters: request.filters,
    applied: new Set(spec.filters),
  });
  const rows: Record<string, unknown>[] = await withTxBudget(
    prisma,
    session.tenantId,
    'read',
    (tx: any) => tx.$queryRawUnsafe(query.text, ...query.values),
  );
  return rows.map(toRecord);
}

/** The Purchase Rpt dataset: parse → read → shape. Business scope always comes from the session. */
export async function purchaseReport(
  prisma: any,
  session: RpAllSessionScope,
  query: Record<string, unknown>,
): Promise<PurchaseReportResponse> {
  const request = parsePurchaseRequest(query, session);
  const records = await fetchPurchaseRecords(prisma, session, request);
  return shapePurchaseResult(request, records);
}

/** City and Area drop-downs: the distinct AC_MAST values of the company (RP_ALL.cs:7087-7102, 7121-7136). */
export async function purchaseReportOptions(
  prisma: any,
  tenantId: string,
  coCode: string,
): Promise<{ cities: string[]; areas: string[] }> {
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const distinct = async (column: 'AC_CITY' | 'AC_AREA'): Promise<string[]> => {
      const rows: { v: string }[] = await tx.$queryRawUnsafe(
        `SELECT DISTINCT btrim("${column}") AS v FROM "AC_MAST"
          WHERE "CO_CODE" = $1 AND btrim(COALESCE("${column}", '')) <> '' ORDER BY 1`,
        coCode,
      );
      return rows.map((r) => String(r.v));
    };
    return { cities: await distinct('AC_CITY'), areas: await distinct('AC_AREA') };
  });
}

/**
 * The table the screen, PDF, CSV and Excel all print: the engine's flattened lines, then the web's voucher totals
 * line (Net Amt, Tax, Bill Total of the vouchers behind the selection; Fine and Net Wt where lines are read).
 */
export function purchaseOutputTable(response: PurchaseReportResponse): ExportTable {
  const s = response.selection;
  const money = (v: number) => formatCell('money', v);
  const weight = (v: number) => formatCell('weight', v);
  const parts = [
    `Vouchers ${s.voucherCount}`,
    `Net Amt ${money(s.netAmt)}`,
    `Tax ${money(s.taxAmt)}`,
    `Bill Total ${money(s.totAmt)}`,
  ];
  if (s.fine !== null) parts.push(`Fine ${weight(s.fine)}`);
  if (s.nwt !== null) parts.push(`Net Wt ${weight(s.nwt)}`);
  return {
    columns: response.table.columns,
    lines: [
      ...response.table.lines,
      { _band: `Voucher totals: ${parts.join('  ')}`, _kind: 'selection' },
    ],
  };
}

/** Column slots of a result: columns of different levels with one slot header print in one table column. */
export function slotsOf(
  response: Pick<PurchaseReportResponse, 'columns'>,
): { header: string; keys: string[] }[] {
  const slots: { header: string; keys: string[] }[] = [];
  const bySlot = new Map<string, number>();
  for (const c of response.columns) {
    const name = c.slot ?? c.caption;
    let i = bySlot.get(name);
    if (i === undefined) {
      i = slots.length;
      bySlot.set(name, i);
      slots.push({ header: name, keys: [] });
    }
    slots[i]!.keys.push(c.key);
  }
  return slots;
}

/** Print HTML for the PDF export (server-built: no client HTML reaches Chromium). */
export function purchaseReportHtml(response: PurchaseReportResponse): string {
  const e = (v: unknown) => escapeHtml(v);
  const table = purchaseOutputTable(response);
  const slots = slotsOf(response);
  const head = `<th></th>${slots.map((slot) => `<th>${e(slot.header)}</th>`).join('')}`;
  const body = table.lines
    .map((line) => {
      const kind = line._kind ?? '';
      const isRow = kind === 'voucher' || kind === 'line' || kind === 'sub';
      const label = isRow ? '' : (line._band ?? '');
      if (kind === 'selection')
        return `<tr class="selection"><td colspan="${slots.length + 1}">${e(label)}</td></tr>`;
      const cells = slots
        .map((slot) => {
          const key = slot.keys.find((k) => line[k] !== undefined);
          return `<td>${e(key ? line[key] : '')}</td>`;
        })
        .join('');
      return `<tr class="${e(kind)}"><td>${e(label)}</td>${cells}</tr>`;
    })
    .join('');
  return `<!doctype html><html><head><meta charset="utf-8"><title>${e(response.title)}</title><style>
body{font:9px Arial,sans-serif;color:#111}h1{font-size:15px;margin:0 0 4px}table{border-collapse:collapse;width:100%}th,td{border:1px solid #888;padding:2px 3px;vertical-align:top}th{background:#eee;text-align:left}tr.total,tr.group,tr.selection,tr.voucher{font-weight:bold}</style></head><body>
<h1>${e(response.title)}</h1><div>${e(response.caption)} · ${e(response.template)}</div>
<table><thead><tr>${head}</tr></thead><tbody>${body}</tbody></table></body></html>`;
}
