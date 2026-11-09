import { withTxBudget } from '../../shared/txBudget.js';
import { reportTitle, runLayout } from './engine.js';
import {
  parseFlag,
  parseRpAllFilters,
  RpAllRequestError,
  type RpAllFilters,
  type RpAllSessionScope,
} from './filters.js';
import {
  SALES_MODES,
  SALES_SPECS,
  type SalesFilterKey,
  type SalesMode,
  type SalesModeSpec,
  type SalesVariant,
} from './salesLayouts.js';
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
  mode: SalesMode;
  /** The desktop's Yes/No prompt "Sales Return (Creditnote) Report" answered Yes. */
  returns: boolean;
  /** The desktop's Yes/No prompt "Only Item Sales With Order" answered Yes. */
  orderOnly: boolean;
  filters: RpAllFilters;
}

export interface RpAllResult {
  branch: RpAllBranch;
  mode: SalesMode;
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
  ignoredFilters: SalesFilterKey[];
  cite: string;
}

const FILTER_KEYS: readonly SalesFilterKey[] = [
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

/** Parse the whole request: branch, mode, the two prompts and the shared selectors. */
export function parseRpAllRequest(
  branch: RpAllBranch,
  query: Record<string, unknown>,
  session: RpAllSessionScope,
): RpAllRequest {
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
  return { branch, mode, returns, orderOnly, filters };
}

function variantOf(spec: SalesModeSpec, returns: boolean): SalesVariant {
  return returns && spec.ret ? spec.ret : spec.sale;
}

function presentFilters(filters: RpAllFilters): SalesFilterKey[] {
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
  const spec = SALES_SPECS[request.mode];
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
  const spec = SALES_SPECS[request.mode];
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
