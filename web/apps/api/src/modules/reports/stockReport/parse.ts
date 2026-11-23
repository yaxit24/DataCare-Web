/**
 * Report -> Stock Report (desktop RP_STOCK): the typed query, parsed fail-closed.
 *
 * Desktop selectors (RP_STOCK.cs InitializeComponent, 1535-2811): From / To date (mFromDt, mToDt), Item Type
 * (cboItemTyp, first letter is the filter, RP_STOCK.cs:4303), Stock Type (All / Tag / Item, RP_STOCK.cs:4287-4291),
 * Gross Wise Weight (chkWtType, RP_STOCK.cs:4280), Gr Code, Pr Code, It Code, Design, Safe, Counter, TagNo, AcCode.
 * The desktop concatenates their text into SQL (RP_STOCK.cs:4295 `"AND A.AC_CODE =  '" + tAcCode.Text + "'"`); the
 * web only ever binds them, so this parser limits shape and length and nothing here reaches SQL as text.
 * Company, location and year are the session's and cannot be replaced by the query (enforceRequestScope).
 */

export class StockReportError extends Error {
  readonly statusCode = 400;
  constructor(
    readonly code: string,
    message: string,
    readonly details: Record<string, unknown> = {},
  ) {
    super(message);
    this.name = 'StockReportError';
  }
}

export const DIMENSIONS = [
  'item',
  'product',
  'group',
  'design',
  'safe',
  'counter',
  'trading',
  'size',
] as const;
export type Dimension = (typeof DIMENSIONS)[number];

export const COLUMNS = ['opening', 'purchase', 'inward', 'outward', 'sale', 'closing'] as const;
export type Column = (typeof COLUMNS)[number];

/** cboItemTyp items (RP_STOCK.cs:3620-3627) -> the first letter compared with ITEM_MAST.IT_TYPE. */
export const ITEM_TYPES: Readonly<Record<string, string>> = {
  Gold: 'G',
  Silver: 'S',
  Diamond: 'D',
  'Real Stone': 'R',
  Emitation: 'E',
  Other: 'O',
  Platinum: 'P',
};

export interface StockFilters {
  fromDate: string;
  toDate: string;
  /** undefined = the company setting STK_RPT_TYPE decides (RP_STOCK.cs:3647). */
  gross?: boolean;
  itemType?: string;
  stockType?: 'tag' | 'item';
  acCode?: string;
  tagNo?: string;
  prCode?: string;
  grCode?: string;
  itCode?: string;
  designNo?: string;
  safe?: string;
  tblCode?: string;
  /** MsDataType: A or B restricts, C (or absent) adds no condition (RP_STOCK.cs:4284). */
  dataType?: string;
}

export interface StockRequest {
  dimension: Dimension;
  filters: StockFilters;
}

export interface MovementRequest extends StockRequest {
  key: string;
  rowType: string;
  column: Column;
}

const TEXT = /^[^\u0000-\u001f]{1,60}$/;
const ISO = /^(\d{4})-(\d{2})-(\d{2})$/;
/** Keys the scope guard has already proven equal to the session; they carry no selector. */
const SCOPE_KEYS = ['lcCode', 'coCode', 'coYear', 'LC_CODE', 'CO_CODE', 'CO_YEAR'];
const BASE_KEYS = [
  'dimension',
  'fromDate',
  'toDate',
  'weight',
  'itemType',
  'stockType',
  'acCode',
  'tagNo',
  'prCode',
  'grCode',
  'itCode',
  'designNo',
  'safe',
  'tblCode',
  'dataType',
];
const MOVEMENT_KEYS = ['key', 'rowType', 'column'];

function isRealDate(value: string): boolean {
  const m = ISO.exec(value);
  if (!m) return false;
  const d = new Date(`${value}T00:00:00Z`);
  return (
    !Number.isNaN(d.getTime()) &&
    d.getUTCFullYear() === Number(m[1]) &&
    d.getUTCMonth() + 1 === Number(m[2]) &&
    d.getUTCDate() === Number(m[3])
  );
}

function one(query: Record<string, unknown>, name: string): string | undefined {
  const raw = query[name];
  const value = Array.isArray(raw) ? raw[0] : raw;
  if (value === undefined || value === null) return undefined;
  if (typeof value !== 'string')
    throw new StockReportError('invalid-filter', `${name} must be text`, { field: name });
  // Not trimmed for the key: a design or safe name may legitimately carry inner spaces; only the ends go.
  const trimmed = value.trim();
  return trimmed === '' ? undefined : trimmed;
}

function text(query: Record<string, unknown>, name: string): string | undefined {
  const value = one(query, name);
  if (value !== undefined && !TEXT.test(value))
    throw new StockReportError('invalid-filter', `${name} is not valid text`, { field: name });
  return value;
}

function refuseUnknown(query: Record<string, unknown>, allowed: readonly string[]): void {
  const unknown = Object.keys(query).filter(
    (k) => !allowed.includes(k) && !SCOPE_KEYS.includes(k) && query[k] !== undefined,
  );
  if (unknown.length)
    throw new StockReportError(
      'unknown-filter',
      `Stock Report cannot filter by ${unknown.join(', ')}`,
      { fields: unknown },
    );
}

/** The letter for an Item Type typed as a letter or as the combo's caption. */
function itemTypeLetter(value: string): string {
  if (ITEM_TYPES[value]) return ITEM_TYPES[value]!;
  if (Object.values(ITEM_TYPES).includes(value)) return value;
  throw new StockReportError(
    'invalid-filter',
    `itemType must be one of ${Object.keys(ITEM_TYPES).join(', ')}`,
    {
      field: 'itemType',
    },
  );
}

function parseFilters(query: Record<string, unknown>): StockFilters {
  const fromDate = one(query, 'fromDate');
  const toDate = one(query, 'toDate');
  for (const [name, value] of [
    ['fromDate', fromDate],
    ['toDate', toDate],
  ] as const) {
    if (value === undefined)
      throw new StockReportError('invalid-date', `${name} is required (yyyy-mm-dd)`, {
        field: name,
      });
    if (!isRealDate(value))
      throw new StockReportError('invalid-date', `${name} is not a real calendar date`, {
        field: name,
      });
  }
  // From after To is NOT an error: the desktop never compares the two (RP_STOCK.cs has no such check).
  const weight = one(query, 'weight');
  if (weight !== undefined && weight !== 'net' && weight !== 'gross')
    throw new StockReportError('invalid-filter', 'weight must be net or gross', {
      field: 'weight',
    });
  const itemType = one(query, 'itemType');
  const stockType = one(query, 'stockType');
  if (stockType !== undefined && !['all', 'tag', 'item'].includes(stockType))
    throw new StockReportError('invalid-filter', 'stockType must be all, tag or item', {
      field: 'stockType',
    });
  const dataType = one(query, 'dataType');
  if (dataType !== undefined && !['A', 'B', 'C'].includes(dataType))
    throw new StockReportError('invalid-filter', 'dataType must be A, B or C', {
      field: 'dataType',
    });
  const out: StockFilters = { fromDate: fromDate!, toDate: toDate! };
  if (weight !== undefined) out.gross = weight === 'gross';
  if (itemType !== undefined) out.itemType = itemTypeLetter(itemType);
  if (stockType === 'tag' || stockType === 'item') out.stockType = stockType;
  if (dataType !== undefined && dataType !== 'C') out.dataType = dataType;
  for (const name of [
    'acCode',
    'tagNo',
    'prCode',
    'grCode',
    'itCode',
    'designNo',
    'safe',
    'tblCode',
  ] as const) {
    const value = text(query, name);
    if (value !== undefined) out[name] = value;
  }
  return out;
}

function dimension(query: Record<string, unknown>): Dimension {
  const value = one(query, 'dimension') ?? 'item';
  if (!(DIMENSIONS as readonly string[]).includes(value))
    throw new StockReportError(
      'invalid-dimension',
      `dimension must be one of ${DIMENSIONS.join(', ')}`,
      {
        field: 'dimension',
      },
    );
  return value as Dimension;
}

export function parseStockRequest(query: Record<string, unknown>): StockRequest {
  refuseUnknown(query, BASE_KEYS);
  return { dimension: dimension(query), filters: parseFilters(query) };
}

export function parseMovementRequest(query: Record<string, unknown>): MovementRequest {
  refuseUnknown(query, [...BASE_KEYS, ...MOVEMENT_KEYS]);
  const column = one(query, 'column');
  if (!column || !(COLUMNS as readonly string[]).includes(column))
    throw new StockReportError('invalid-column', `column must be one of ${COLUMNS.join(', ')}`, {
      field: 'column',
    });
  // The key may legitimately be blank (a blank design or size is a real group); the row type is one letter or blank.
  const rawKey = query.key;
  if (typeof rawKey !== 'string' || /[\u0000-\u001f]/.test(rawKey) || rawKey.length > 60)
    throw new StockReportError('invalid-key', 'key is required (the code of the summary row)', {
      field: 'key',
    });
  const rowType = typeof query.rowType === 'string' ? query.rowType : undefined;
  if (rowType === undefined || !/^[A-Za-z]?$/.test(rowType))
    throw new StockReportError(
      'invalid-key',
      'rowType is required (the item type of the summary row)',
      {
        field: 'rowType',
      },
    );
  return {
    dimension: dimension(query),
    filters: parseFilters(query),
    key: rawKey,
    rowType,
    column: column as Column,
  };
}
