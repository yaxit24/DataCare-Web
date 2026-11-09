/**
 * RP_ALL shared selectors: parse and validate the query into a typed filter set (pure, fail-closed).
 *
 * Desktop selectors (InitializeComponent tab order, RP_ALL.cs:4778-6549):
 *   From / To date  mFromDt :5618 (tab 0), mToDt :5610 (tab 1)
 *   lc Code         tLcCode :4914 (tab 2) — fixed to the session location unless it is "00" (:6660-6671)
 *   Book            tBookCode :4778 (tab 3), plus the "Select Book" multi-pick chkBookSelect :6532-6539
 *   Pr Code         tItCode :4874 (tab 4) — a PRODUCT_MAST code (help :7477-7503), filters ITEM_MAST.PR_CODE
 *   Gr Code         tGrCode :5626 (tab 5) — filters ITEM_MAST.GR_CODE
 *   Party Code      tAcCode :4812 (tab 6)
 *   City / Area     cboCity :4839 (tab 8), cboArea :4858 (tab 9) — AC_MAST.AC_CITY / AC_AREA
 *   Item Type       cboItemTyp :4899 (tab 10) — "", Gold, Silver, Diamond, Real Stone, Emitation, Other,
 *                   Platinum (:7165-7172); the formula takes the first letter (:7663)
 *   Employ          cboEmploy :6396, shown for Sales Report (:6679-6680)
 *   State           cboState :6545, shown only for registration DM019NEDM (:6694-6697), so never in Lite
 *
 * Each value reaches SQL only as a bound parameter; nothing here is ever concatenated into SQL text.
 */

export class RpAllRequestError extends Error {
  readonly statusCode = 400;
  constructor(
    readonly code: string,
    message: string,
    readonly details: Record<string, unknown> = {},
  ) {
    super(message);
    this.name = 'RpAllRequestError';
  }
}

/** cboItemTyp items (RP_ALL.cs:7165-7172) → the first letter the formula compares to ITEM_MAST.IT_TYPE. */
export const ITEM_TYPES: Readonly<Record<string, string>> = {
  Gold: 'G',
  Silver: 'S',
  Diamond: 'D',
  'Real Stone': 'R',
  Emitation: 'E',
  Other: 'O',
  Platinum: 'P',
};

export interface RpAllFilters {
  /** ISO yyyy-mm-dd, inclusive (the formula uses >= and <=, RP_ALL.cs:7618). */
  fromDate: string;
  toDate: string;
  /** null = every location (only when the session location is "00"). */
  lcCode: string | null;
  coBook?: string;
  /** "Select Book" multi-pick (RP_ALL.cs:11367-11403): CO_BOOK IN (...). */
  books?: string[];
  acCode?: string;
  prCode?: string;
  grCode?: string;
  city?: string;
  area?: string;
  state?: string;
  empCode?: string;
  /** One of the ITEM_TYPES letters. */
  itemType?: string;
}

export interface RpAllSessionScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

const ISO = /^(\d{4})-(\d{2})-(\d{2})$/;
/** Codes are short desktop keys (CO_BOOK 8, AC_CODE 18, PR/GR/EMP codes); bounded so a query cannot carry a payload. */
const CODE = /^[A-Za-z0-9 ._/&-]{1,20}$/;
const TEXT = /^[^\u0000-\u001f]{1,60}$/;

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
    throw new RpAllRequestError('invalid-filter', `${name} must be text`);
  const trimmed = value.trim();
  return trimmed === '' ? undefined : trimmed;
}

function code(query: Record<string, unknown>, name: string): string | undefined {
  const value = one(query, name);
  if (value !== undefined && !CODE.test(value))
    throw new RpAllRequestError('invalid-filter', `${name} is not a valid code`, { field: name });
  return value;
}

function text(query: Record<string, unknown>, name: string): string | undefined {
  const value = one(query, name);
  if (value !== undefined && !TEXT.test(value))
    throw new RpAllRequestError('invalid-filter', `${name} is not valid text`, { field: name });
  return value;
}

/**
 * Parse the shared selectors. Dates are required and must be real calendar dates; From after To is NOT an
 * error, because the desktop has no such check and simply prints an empty report (RP_ALL.cs:7618 builds the
 * range predicate without comparing the two).
 */
export function parseRpAllFilters(
  query: Record<string, unknown>,
  session: RpAllSessionScope,
): RpAllFilters {
  const fromDate = one(query, 'fromDate');
  const toDate = one(query, 'toDate');
  if (!fromDate || !isRealDate(fromDate))
    throw new RpAllRequestError('invalid-date', 'fromDate must be a date (yyyy-mm-dd)', {
      field: 'fromDate',
    });
  if (!toDate || !isRealDate(toDate))
    throw new RpAllRequestError('invalid-date', 'toDate must be a date (yyyy-mm-dd)', {
      field: 'toDate',
    });

  // tLcCode starts as the session location and is locked unless the session is the head office "00"
  // (RP_ALL.cs:6660-6671). Only then may the operator clear it (every location) or pick another one.
  const rawLc = query.lcCode;
  let lcCode: string | null = session.lcCode;
  if (session.lcCode === '00') {
    if (rawLc === '') lcCode = null;
    else {
      const asked = code(query, 'lcCode');
      if (asked !== undefined) lcCode = asked;
    }
  } else {
    const asked = code(query, 'lcCode');
    if (asked !== undefined && asked !== session.lcCode)
      throw new RpAllRequestError('location-locked', 'lcCode is fixed to the session location', {
        field: 'lcCode',
      });
  }

  const booksRaw = one(query, 'books');
  let books: string[] | undefined;
  if (booksRaw !== undefined) {
    books = booksRaw
      .split(',')
      .map((b) => b.trim())
      .filter(Boolean);
    if (books.length > 50 || books.some((b) => !CODE.test(b)))
      throw new RpAllRequestError('invalid-filter', 'books must be a comma list of book codes', {
        field: 'books',
      });
    // "Book Selection Not Done..." (RP_ALL.cs:11392): an empty pick is not a filter.
    if (books.length === 0) books = undefined;
  }

  const itemTypeRaw = one(query, 'itemType');
  let itemType: string | undefined;
  if (itemTypeRaw !== undefined) {
    itemType = ITEM_TYPES[itemTypeRaw] ?? itemTypeRaw.toUpperCase();
    if (!Object.values(ITEM_TYPES).includes(itemType))
      throw new RpAllRequestError(
        'invalid-filter',
        'itemType is not one of the desktop item types',
        {
          field: 'itemType',
        },
      );
  }

  const filters: RpAllFilters = { fromDate, toDate, lcCode };
  const set = <K extends keyof RpAllFilters>(key: K, value: RpAllFilters[K] | undefined) => {
    if (value !== undefined) filters[key] = value;
  };
  set('coBook', code(query, 'coBook'));
  set('books', books);
  set('acCode', code(query, 'acCode'));
  set('prCode', code(query, 'prCode'));
  set('grCode', code(query, 'grCode'));
  set('city', text(query, 'city'));
  set('area', text(query, 'area'));
  set('state', text(query, 'state'));
  set('empCode', code(query, 'empCode'));
  set('itemType', itemType);
  return filters;
}

/** Truthy flag from the query ("1", "true", "yes", "Y"), used for the desktop's Yes/No prompts. */
export function parseFlag(query: Record<string, unknown>, name: string): boolean {
  const value = one(query, name);
  if (value === undefined) return false;
  if (/^(1|true|yes|y)$/i.test(value)) return true;
  if (/^(0|false|no|n)$/i.test(value)) return false;
  throw new RpAllRequestError('invalid-filter', `${name} must be yes or no`, { field: name });
}
