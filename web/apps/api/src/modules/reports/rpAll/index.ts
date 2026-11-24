import { round } from '@datacare/core';
import { withTxBudget } from '../../shared/txBudget.js';
import {
  APPROVAL_SPECS,
  approvalMode,
  type ApprovalMode,
  type ApprovalModeSpec,
} from './approvalLayouts.js';
import { buildApprovalQuery, type NormalizedApprovalFilters } from './approvalQuery.js';
import { reportTitle, runLayout } from './engine.js';
import {
  parseFlag,
  parseOnlySummary,
  parseRpAllFilters,
  RpAllRequestError,
  type RpAllFilters,
  type RpAllSessionScope,
} from './filters.js';
import {
  ORDER_MODES,
  ORDER_SPECS,
  orderSummaryVariant,
  type OrderFilterKey,
  type OrderMode,
  type OrderModeSpec,
  type OrderVariant,
} from './orderLayouts.js';
import {
  SALES_MODES,
  SALES_SPECS,
  type SalesFilterKey,
  type SalesMode,
  type SalesModeSpec,
  type SalesVariant,
} from './salesLayouts.js';
import { buildOrderQuery } from './orderQuery.js';
import { buildSalesQuery } from './salesQuery.js';
import type {
  RpAllBranch,
  RpAllColumn,
  RpAllGroup,
  RpAllRecord,
  RpAllRow,
  RpAllValue,
} from './types.js';

/**
 * Public surface of the shared RP_ALL engine (WP-11). A branch adapter supplies its mode table and its
 * read; everything else — selector parsing, grouping, count-once totals, titles — is shared. Purchase Rpt,
 * Approval Rpt and Order Report add an adapter beside `sales` and reuse the rest unchanged.
 */

export { RpAllRequestError } from './filters.js';
export type { RpAllFilters, RpAllSessionScope } from './filters.js';

export interface RpAllRequest {
  branch: RpAllBranch;
  mode: SalesMode | OrderMode;
  /** The desktop's Yes/No prompt "Sales Return (Creditnote) Report" answered Yes. */
  returns: boolean;
  /** The desktop's Yes/No prompt "Only Item Sales With Order" answered Yes. */
  orderOnly: boolean;
  /** The desktop's Yes/No prompt "Only Design Summery Report.." answered Yes (Order branch). */
  onlySummary: boolean;
  filters: RpAllFilters;
}

export interface RpAllResult {
  branch: RpAllBranch;
  mode: string;
  caption: string;
  variant: 'sale' | 'return';
  template: string;
  title: string;
  columns: RpAllColumn[];
  groups: RpAllGroup[];
  groupLevels: { key: string; subtotal: 'header' | 'footer' | 'none'; subtotalCaption?: string }[];
  rows: RpAllRow[];
  totals: Record<string, number>;
  grandTotal: boolean;
  grandTotalCaption?: string;
  voucherCount: number;
  filters: RpAllFilters;
  /** Filters the request carried that this button's formula does not use (the desktop ignores them too). */
  ignoredFilters: (SalesFilterKey | OrderFilterKey)[];
  cite: string;
}

const FILTER_KEYS: readonly (SalesFilterKey | OrderFilterKey)[] = [
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
  'custName',
];

function parseSalesRequest(
  query: Record<string, unknown>,
  session: RpAllSessionScope,
): Omit<RpAllRequest, 'branch'> {
  const rawMode = query.mode;
  const mode = (typeof rawMode === 'string' && rawMode !== '' ? rawMode : 'report') as SalesMode;
  if (!SALES_MODES.includes(mode))
    throw new RpAllRequestError('invalid-mode', `mode must be one of ${SALES_MODES.join(', ')}`, {
      field: 'mode',
    });
  const spec = SALES_SPECS[mode];
  const returns = parseFlag(query, 'returns');
  const orderOnly = parseFlag(query, 'orderOnly');
  if (returns && !spec.returnPrompt)
    throw new RpAllRequestError('invalid-mode', `${spec.caption} has no sales-return variant`, {
      field: 'returns',
    });
  if (orderOnly && !spec.orderPrompt)
    throw new RpAllRequestError('invalid-mode', `${spec.caption} has no order-only prompt`, {
      field: 'orderOnly',
    });
  const filters = parseRpAllFilters(query, session);
  const lacking = spec.templateLacks.filter((key) => filters[key] !== undefined);
  if (lacking.length)
    throw new RpAllRequestError(
      'filter-not-in-template',
      `${spec.caption}: the desktop template has no party master, so ${lacking.join(', ')} cannot be applied`,
      { fields: lacking },
    );
  return { mode, returns, orderOnly, onlySummary: false, filters };
}

function parseOrderRequest(
  query: Record<string, unknown>,
  session: RpAllSessionScope,
): Omit<RpAllRequest, 'branch'> {
  const rawMode = query.mode;
  const mode = (typeof rawMode === 'string' && rawMode !== '' ? rawMode : 'report') as OrderMode;
  if (!ORDER_MODES.includes(mode))
    throw new RpAllRequestError('invalid-mode', `mode must be one of ${ORDER_MODES.join(', ')}`, {
      field: 'mode',
    });
  const spec = ORDER_SPECS[mode];
  const filters = parseRpAllFilters(query, session);
  const lacking = Object.keys(filters).filter(
    (key) =>
      !spec.filters.includes(key as OrderFilterKey) &&
      key !== 'fromDate' &&
      key !== 'toDate' &&
      key !== 'lcCode',
  ) as OrderFilterKey[];
  if (lacking.length)
    throw new RpAllRequestError(
      'filter-not-in-template',
      `${spec.caption}: the desktop handler does not apply ${lacking.join(', ')}`,
      { fields: lacking },
    );
  return {
    mode,
    returns: false,
    orderOnly: false,
    onlySummary: mode === 'summary' ? parseOnlySummary(query) : false,
    filters,
  };
}

/** Parse the whole request: branch, mode, branch prompts and the shared selectors. */
export function parseRpAllRequest(
  branch: RpAllBranch,
  query: Record<string, unknown>,
  session: RpAllSessionScope,
): RpAllRequest {
  const base =
    branch === 'order' ? parseOrderRequest(query, session) : parseSalesRequest(query, session);
  return { branch, ...base };
}

function variantOf(spec: SalesModeSpec, returns: boolean): SalesVariant {
  return returns && spec.ret ? spec.ret : spec.sale;
}

function presentFilters(filters: RpAllFilters): (SalesFilterKey | OrderFilterKey)[] {
  return FILTER_KEYS.filter((key) => key !== 'lcCode' && filters[key] !== undefined);
}

/**
 * The pure half of a Sales run: adapter records → derived formula fields → engine → result. Exported so the
 * unit tests drive the whole report from fixture records without a database.
 */
export function shapeSalesResult(
  request: RpAllRequest,
  records: readonly RpAllRecord[],
): RpAllResult {
  const spec = SALES_SPECS[request.mode as SalesMode];
  const variant = variantOf(spec, request.returns);
  const layout = variant.layout;
  const derived: RpAllRecord[] = records.map((record) =>
    variant.derive
      ? { ...record, ...(variant.derive(record) as Record<string, RpAllValue>) }
      : record,
  );
  const result = runLayout(layout, derived);
  return {
    branch: request.branch,
    mode: request.mode,
    caption: spec.caption,
    variant: request.returns && spec.ret ? 'return' : 'sale',
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
    ignoredFilters: presentFilters(request.filters).filter((key) => !spec.filters.includes(key)),
    cite: variant.cite,
  };
}

/** Normalise a database row: bigint/Decimal-like values to numbers, everything else as text or null. */
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

/** Read-only adapter for the Sales branch: one parameterised SELECT inside a read budget. */
export async function fetchSalesRecords(
  prisma: any,
  session: RpAllSessionScope,
  request: RpAllRequest,
): Promise<RpAllRecord[]> {
  const spec = SALES_SPECS[request.mode as SalesMode];
  const variant = variantOf(spec, request.returns);
  const query = buildSalesQuery({
    shape: variant.query,
    scope: session,
    filters: request.filters,
    applied: new Set(spec.filters),
    orderOnly: request.orderOnly,
  });
  const rows: Record<string, unknown>[] = await withTxBudget(
    prisma,
    session.tenantId,
    'read',
    (tx: any) => tx.$queryRawUnsafe(query.text, ...query.values),
  );
  return rows.map(toRecord);
}

/** The Sales Report dataset: parse → read → shape. Business scope always comes from the session. */
export async function salesReport(
  prisma: any,
  session: RpAllSessionScope,
  query: Record<string, unknown>,
): Promise<RpAllResult> {
  const request = parseRpAllRequest('sales', query, session);
  const records = await fetchSalesRecords(prisma, session, request);
  return shapeSalesResult(request, records);
}

function orderVariantOf(spec: OrderModeSpec, onlySummary: boolean): OrderVariant {
  return spec.mode === 'summary' ? orderSummaryVariant(onlySummary) : spec.variant;
}

/**
 * The pure half of an Order run: adapter records → derived formula fields → engine → result.
 */
export function shapeOrderResult(
  request: RpAllRequest,
  records: readonly RpAllRecord[],
): RpAllResult {
  const spec = ORDER_SPECS[request.mode as OrderMode];
  const variant = orderVariantOf(spec, request.onlySummary);
  const layout = variant.layout;
  const derived: RpAllRecord[] = records.map((record) =>
    variant.derive
      ? { ...record, ...(variant.derive(record) as Record<string, RpAllValue>) }
      : record,
  );
  const result = runLayout(layout, derived);
  if (variant.bandFormulas) {
    // Non-sum header formulas (OrdAdjBillWise @PandingTot) from the band's own sums, money precision.
    const apply = (totals: Record<string, number>) => {
      for (const [key, value] of Object.entries(variant.bandFormulas!(totals)))
        totals[key] = round(value, 2);
    };
    result.groups.forEach((group) => {
      if (layout.groups[group.depth]?.subtotal !== 'none') apply(group.totals);
    });
    apply(result.totals);
  }
  if (variant.bandFormulas) {
    // Non-sum header formulas (OrdAdjBillWise @PandingTot) from the band's own sums, money precision.
    const apply = (totals: Record<string, number>) => {
      for (const [key, value] of Object.entries(variant.bandFormulas!(totals)))
        totals[key] = round(value, 2);
    };
    result.groups.forEach((group) => {
      if (layout.groups[group.depth]?.subtotal !== 'none') apply(group.totals);
    });
    apply(result.totals);
  }
  return {
    branch: request.branch,
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
    ignoredFilters: presentFilters(request.filters).filter(
      (key) => !spec.filters.includes(key as OrderFilterKey),
    ),
    cite: variant.cite,
  };
}

/** Read-only adapter for the Order branch: one parameterised SELECT inside a read budget. */
export async function fetchOrderRecords(
  prisma: any,
  session: RpAllSessionScope,
  request: RpAllRequest,
): Promise<RpAllRecord[]> {
  const spec = ORDER_SPECS[request.mode as OrderMode];
  const variant = orderVariantOf(spec, request.onlySummary);
  const query = buildOrderQuery({
    shape: variant.query,
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

/** The Order Report dataset: parse → read → shape. */
export async function orderReport(
  prisma: any,
  session: RpAllSessionScope,
  query: Record<string, unknown>,
): Promise<RpAllResult> {
  const request = parseRpAllRequest('order', query, session);
  const records = await fetchOrderRecords(prisma, session, request);
  return shapeOrderResult(request, records);
}

// -----------------------------------------------------------------------------------------------------------
// Approval Rpt — the three PanelApr buttons (RP_ALL.cs:5132-5134, 6707-6711).
// -----------------------------------------------------------------------------------------------------------

export interface ApprovalRequest {
  branch: 'approval';
  mode: ApprovalMode;
  fromDate: string;
  toDate: string;
  filters: NormalizedApprovalFilters;
  /** A/B only; the setting is supplied by the server, never by a client SQL fragment (D3). */
  dataType?: string;
}

export interface ApprovalResult {
  branch: 'approval';
  mode: ApprovalMode;
  caption: string;
  template: string;
  title: string;
  columns: RpAllColumn[];
  groups: RpAllGroup[];
  groupLevels: { key: string; subtotal: 'header' | 'footer' | 'none'; subtotalCaption?: string }[];
  rows: RpAllRow[];
  totals: Record<string, number>;
  grandTotal: boolean;
  grandTotalCaption?: string;
  voucherCount: number;
  filters: NormalizedApprovalFilters;
  ignoredFilters: string[];
  cite: string;
}

/** Reject impossible dates safely; the desktop's click handler converts without a guard (RP_ALL.cs:8152). */
function realIsoDate(value: unknown): string | undefined {
  if (typeof value !== 'string' || !/^\d{4}-\d{2}-\d{2}$/.test(value)) return undefined;
  const d = new Date(`${value}T00:00:00Z`);
  if (
    Number.isNaN(d.getTime()) ||
    d.getUTCFullYear() !== Number(value.slice(0, 4)) ||
    d.getUTCMonth() + 1 !== Number(value.slice(5, 7)) ||
    d.getUTCDate() !== Number(value.slice(8, 10))
  )
    return undefined;
  return value;
}

/**
 * Normalise the two callers of the approval builder:
 *  - the HTTP screen passes a session scope whose `filters` came from the shared report filter parser;
 *  - a unit caller passes the raw scope/options directly.
 * The desktop's lc box is session-locked (RP_ALL.cs:6664), so a client-supplied location never widens scope.
 */
function approvalInput(s: any, options: Record<string, unknown>): ApprovalRequest {
  const fromDate = realIsoDate(s?.fromDate) ?? realIsoDate(options.fromDate) ?? '2010-01-01';
  const toDate =
    realIsoDate(s?.toDate) ?? realIsoDate(options.toDate) ?? new Date().toISOString().slice(0, 10);
  if (!realIsoDate(s?.fromDate ?? options.fromDate) && s?.fromDate !== undefined)
    throw new RpAllRequestError('invalid-date', 'fromDate must be a date (yyyy-mm-dd)', {
      field: 'fromDate',
    });
  if (!realIsoDate(s?.toDate ?? options.toDate) && s?.toDate !== undefined)
    throw new RpAllRequestError('invalid-date', 'toDate must be a date (yyyy-mm-dd)', {
      field: 'toDate',
    });

  const supplied =
    s?.filters && typeof s.filters === 'object' ? (s.filters as Record<string, unknown>) : {};
  const pick = (...keys: string[]): string | undefined => {
    for (const key of keys) {
      for (const source of [supplied, options]) {
        const value = source[key];
        if (typeof value === 'string' && value.trim() !== '') return value.trim();
      }
    }
    return undefined;
  };
  // D3: the A/B setting is the desktop session's MsDataType (RP_ALL.cs:8186), never a request value. Only a
  // server-built scope may carry it; the query string and the shared filter parse are ignored.
  const dataType = s?.dataType === 'A' || s?.dataType === 'B' ? (s.dataType as string) : undefined;

  const filters: NormalizedApprovalFilters = {};
  const coBook = pick('coBook', 'bookCode');
  const acCode = pick('acCode');
  const prCode = pick('prCode');
  const grCode = pick('grCode');
  const city = pick('city');
  const area = pick('area');
  const itemType = pick('itemType', 'itType');
  if (coBook) filters.coBook = coBook;
  if (acCode) filters.acCode = acCode;
  if (prCode) filters.prCode = prCode;
  if (grCode) filters.grCode = grCode;
  if (city) filters.city = city;
  if (area) filters.area = area;
  if (itemType) filters.itemType = itemType.slice(0, 1).toUpperCase();
  return {
    branch: 'approval',
    mode: approvalMode(options.mode),
    fromDate,
    toDate,
    filters,
    dataType,
  };
}

/** Pure half of an Approval run: adapter records → engine rows, bands and totals; no I/O. */
export function shapeApprovalResult(
  request: ApprovalRequest,
  records: readonly RpAllRecord[],
): ApprovalResult {
  const spec: ApprovalModeSpec = APPROVAL_SPECS[request.mode];
  const layout = spec.layout;
  const result = runLayout(layout, records);
  return {
    branch: 'approval',
    mode: request.mode,
    caption: spec.caption,
    template: layout.template,
    title: reportTitle(layout.titlePrefix, request.fromDate, request.toDate),
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
    // Cust Name, employee, state and multi-book are hidden on this panel (RP_ALL.cs:6400-6549).
    ignoredFilters: [],
    cite: spec.cite,
  };
}

/** Read-only adapter for the Approval branch: one parameterised SELECT inside a read budget. */
export async function fetchApprovalRecords(
  prisma: any,
  session: RpAllSessionScope,
  request: ApprovalRequest,
): Promise<RpAllRecord[]> {
  const query = buildApprovalQuery({
    mode: request.mode,
    scope: session,
    fromDate: request.fromDate,
    toDate: request.toDate,
    filters: request.filters,
    dataType: request.dataType,
  });
  const rows: Record<string, unknown>[] = await withTxBudget(
    prisma,
    session.tenantId,
    'read',
    (tx: any) => tx.$queryRawUnsafe(query.text, ...query.values),
  );
  return rows.map(toRecord);
}

/**
 * Report → Approval Rpt (RP_ALL caption "Approval Rpt"): the three buttons of PanelApr
 * (RP_ALL.cs:5132-5134), selected by the session menu caption (RP_ALL.cs:6658-6711). Business scope —
 * tenant, company, location and year — always comes from the session; the query may only narrow it.
 */
export async function approvalReport(
  prisma: any,
  s: any,
  options: Record<string, unknown> = {},
): Promise<ApprovalResult> {
  const request = approvalInput(s, options);
  const sessionLc = String(s?.lcCode ?? '');
  // Only a head-office (00) session may edit the lc box (RP_ALL.cs:6660
  // {{if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)}}); a cleared box appends no location
  // clause (RP_ALL.cs:8154 {{if (Operators.CompareString(tLcCode.Text, "", false) != 0)}}), so a 00 user who
  // clears it lists every location, as on the Sales branch (filters.ts). Any other session stays locked (D9).
  const lcCode = sessionLc === '00' && options.lcCode === '' ? '' : sessionLc;
  const session: RpAllSessionScope = {
    tenantId: String(s?.tenantId ?? ''),
    coCode: String(s?.coCode ?? ''),
    lcCode,
    coYear: String(s?.coYear ?? ''),
  };
  const records = await fetchApprovalRecords(prisma, session, request);
  return shapeApprovalResult(request, records);
}
