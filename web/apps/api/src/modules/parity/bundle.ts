/**
 * Portable parity bundle — the artifact that makes a desktop-vs-web comparison possible and auditable.
 *
 * WHY A BUNDLE RATHER THAN A LIVE TWO-SIDED COMPARISON
 * ----------------------------------------------------
 * The previous harness connected to SQL Server and PostgreSQL simultaneously and compared in flight. That
 * design has three problems:
 *
 *  1. It can only ever run on a machine with reach to both, which in practice means the Windows box with the
 *     desktop install. Every defect in the comparison logic is therefore discovered THERE, during a session
 *     that is expensive to arrange.
 *  2. Nothing is retained. A run prints a verdict; the underlying values are gone, so a disputed result
 *     cannot be re-examined and a fix cannot be shown to change the outcome on the same data.
 *  3. The comparison logic cannot be tested, because testing it needs a SQL Server.
 *
 * Splitting extraction from comparison fixes all three. Each side writes a bundle — a self-describing snapshot
 * of the rows a named business case produced, WITH the column types and scales. Comparison then runs anywhere,
 * on two files, and can be exercised exhaustively against synthetic bundles.
 *
 * The bundle is the evidence. It is what a reviewer inspects, and what a later re-run is compared against.
 */

/** A column as the source database declares it. Type and scale drive canonicalisation. */
export interface BundleColumn {
  name: string;
  /** Engine-native type name, lowercased (`varchar`, `numeric`, `float`, `date`, `datetime`, `bit`, …). */
  type: string;
  /** Declared numeric scale, when the engine reports one. `null` for float/real, which have none. */
  scale: number | null;
}

export interface BundleTable {
  columns: BundleColumn[];
  /** Row values, ordered to match `columns`. */
  rows: unknown[][];
}

/** One business scenario: a voucher entered on both sides, and everything it wrote. */
export interface BundleCase {
  /** Stable identifier shared by both sides, e.g. `sale-cash-single-line`. */
  caseId: string;
  /** What the operator did, in words, so a reviewer can repeat it. */
  description: string;
  /** The voucher this case produced on THIS side. Identity differs between sides by construction. */
  voucher: { book: string; vchNo: string; coYear?: string };
  /** Table name -> rows. Keys are upper-case table names. */
  tables: Record<string, BundleTable>;
}

export interface ParityBundle {
  kind: 'datacare.parity-bundle/1.0';
  side: 'desktop' | 'web';
  capturedAt: string;
  source: {
    engine: 'sqlserver' | 'postgres';
    database: string;
    /** Host is recorded for provenance. Never a credential. */
    host?: string;
    appVersion?: string;
  };
  scope: { coCode: string; lcCode?: string; coYear?: string };
  cases: BundleCase[];
}

export const BUNDLE_KIND = 'datacare.parity-bundle/1.0' as const;

/** Distinct from the empty string on purpose: NULL and '' are different values and must not silently merge. */
export const NULL_SENTINEL = '\u2300';

/**
 * Fields excluded from comparison, each with a REASON.
 *
 * The previous harness used a bare `SKIP_COLUMNS` set that quietly removed 13-17 columns from every core
 * table — including `VCH_DATE` and `BILL_NO`, which are business data, not identity. A comparison that hides
 * business fields without saying so overstates agreement.
 *
 * Two rules make this honest:
 *  * every exclusion carries a reason, so a reviewer can judge it;
 *  * the diff report publishes its own denominator (compared vs excluded), so the number cannot be read as
 *    "everything matched" when a third of the columns were never looked at.
 *
 * Only fields that CANNOT agree by construction belong here. A field that merely happens to disagree is a
 * finding, not an exclusion.
 */
export const EXCLUDED_FIELDS: Record<string, string> = {
  // Storage identity, not business data.
  TENANT_ID: 'web-only multi-tenancy discriminator; the desktop is single-tenant per database',
  ROW_ID: 'web surrogate key; the desktop has no equivalent',
  // Voucher identity is allocated independently on each side, so it cannot match. The two sides are linked by
  // the case, not by the number.
  VCH_NO: 'voucher number allocated independently on each side; cases are matched by caseId',
  HD_VCH_NO: 'hidden voucher number, allocated independently',
  OLD_VCH_NO: 'renumbering trail; depends on the independent voucher sequence',
  NEW_VCH_NO: 'renumbering trail; depends on the independent voucher sequence',
  // Wall-clock capture, necessarily different because the two entries happen at different moments.
  VCH_TIME: 'time of day when the row was captured; the two entries occur at different moments',
  ENTRY_TIME: 'row insertion timestamp',
  // Operator identity differs between the desktop session and the API session.
  MAIN_USER: 'operating user differs between the desktop session and the web session',
  USER_UPDATE: 'operating user differs between sessions',
};

/**
 * Fields that ARE compared even though the old harness skipped them, recorded here so the change is explicit.
 *
 * `VCH_DATE` is the single most important one: it is the accounting date of the voucher, chosen by the
 * operator, and it must be identical on both sides. Skipping it meant the harness could not detect a voucher
 * posted to the wrong day.
 */
export const RECLAIMED_FIELDS = [
  'VCH_DATE',
  'BILL_NO',
  'STK_DATE',
  'FUN_DATE',
  'DATA_TRFR',
  'CO_BOOK',
  'CO_CODE',
  'LC_CODE',
  'CO_YEAR',
] as const;

const NUMERIC_TYPES = new Set([
  'bigint',
  'decimal',
  'double precision',
  'float',
  'int',
  'integer',
  'money',
  'numeric',
  'real',
  'smallint',
  'smallmoney',
  'tinyint',
]);
const DATE_ONLY_TYPES = new Set(['date']);
const DATETIME_TYPES = new Set([
  'datetime',
  'datetime2',
  'smalldatetime',
  'timestamp',
  'timestamp without time zone',
  'timestamp with time zone',
]);
const BOOL_TYPES = new Set(['bit', 'boolean']);

/**
 * Scale used when neither side declares one.
 *
 * The desktop declares most numerics as `FLOAT`, which has no scale, while the web often uses
 * `numeric(18,3)`. Comparing at the TARGET's declared scale is the principled choice: a difference finer than
 * the web can persist is not representable, so asserting on it would be noise. When neither side declares a
 * scale, 6 is used — tight enough that a real divergence surfaces, and recorded in the report so the
 * comparison describes its own precision.
 */
export const DEFAULT_COMPARISON_SCALE = 6;

export function comparisonScale(a: BundleColumn | undefined, b: BundleColumn | undefined): number {
  const scales = [a?.scale, b?.scale].filter((s): s is number => typeof s === 'number' && s >= 0);
  // The COARSER of the two declared scales: neither side can be held to precision it does not store.
  if (scales.length) return Math.min(...scales);
  return DEFAULT_COMPARISON_SCALE;
}

/** Fixed-point text, so 1.5000 and 1.5004 differ at scale 4 and agree at scale 3. */
function fixed(value: number, scale: number): string {
  if (!Number.isFinite(value)) return String(value);
  // toFixed rounds half-away-from-zero on the string level, which is what a scale-limited store would do.
  const text = value.toFixed(scale);
  // Normalise -0 so it never reads as different from 0.
  return text === `-${(0).toFixed(scale)}` ? (0).toFixed(scale) : text;
}

function isoDate(value: Date): string {
  return value.toISOString().slice(0, 10);
}
function isoDateTime(value: Date): string {
  return value.toISOString().slice(0, 19);
}

/**
 * Canonicalise one value for comparison.
 *
 * The predecessor returned `''` for EVERY `Date`, which made 64 date and datetime columns across 42 tables
 * compare as equal no matter what they contained — a voucher dated 2099 matched one dated 2024. Dates are
 * first-class here.
 */
export function canonicalise(value: unknown, type: string, scale: number): string {
  if (value === null || value === undefined) return NULL_SENTINEL;

  const t = String(type ?? '').toLowerCase();

  if (value instanceof Date) {
    return DATE_ONLY_TYPES.has(t) ? isoDate(value) : isoDateTime(value);
  }
  if (typeof value === 'boolean') return value ? '1' : '0';
  if (typeof value === 'bigint') return value.toString();

  if (BOOL_TYPES.has(t)) {
    const s = String(value).trim().toUpperCase();
    if (['1', 'TRUE', 'Y', 'YES', 'T'].includes(s)) return '1';
    if (['0', 'FALSE', 'N', 'NO', 'F'].includes(s)) return '0';
    return s;
  }

  if (NUMERIC_TYPES.has(t)) {
    const n = typeof value === 'number' ? value : Number(String(value).trim());
    // A non-numeric value in a numeric column is a finding, not something to coerce to zero.
    if (!Number.isFinite(n)) return `NaN(${String(value).trim()})`;
    return fixed(n, scale);
  }

  // Text. Dates and numbers stored in varchar columns are common in this schema, so a date-typed column
  // holding text is canonicalised by SHAPE: '2024-06-10 00:00:00' and '2024-06-10' are the same date.
  const text = String(value).trim();
  if (text === '') return '';
  if (DATE_ONLY_TYPES.has(t) || DATETIME_TYPES.has(t)) {
    // The components are read LITERALLY rather than through `new Date(text)`.
    //
    // `new Date('2024-06-10 00:00:00')` has no timezone marker, so it is interpreted as LOCAL time; calling
    // `toISOString()` then converts to UTC and, in a +05:30 zone, yields 2024-06-09. That off-by-one would
    // have shown up as a genuine-looking parity failure on every text date field and sent someone hunting a
    // defect that does not exist. Both engines emit ISO-shaped text, so taking the digits verbatim is both
    // correct and timezone-proof.
    const m = /^(\d{4})-(\d{2})-(\d{2})(?:[T ](\d{2}):(\d{2})(?::(\d{2}))?)?/.exec(text);
    if (m) {
      const [, y, mo, d, hh, mm, ss] = m;
      if (DATE_ONLY_TYPES.has(t)) return `${y}-${mo}-${d}`;
      return `${y}-${mo}-${d}T${hh ?? '00'}:${mm ?? '00'}:${ss ?? '00'}`;
    }
  }
  return text;
}

/** Is this field excluded from comparison, and why? */
export function exclusionReason(column: string): string | null {
  return EXCLUDED_FIELDS[column.toUpperCase()] ?? null;
}

export function isBundle(value: unknown): value is ParityBundle {
  const b = value as ParityBundle;
  return Boolean(
    b &&
    typeof b === 'object' &&
    b.kind === BUNDLE_KIND &&
    (b.side === 'desktop' || b.side === 'web') &&
    Array.isArray(b.cases),
  );
}
