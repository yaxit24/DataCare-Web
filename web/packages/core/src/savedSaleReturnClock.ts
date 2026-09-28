/** TR_SALE_RTN:10104–10106/10197 supplies VCH_DATE's day and VCH_TIME's
 * HH:mm:ss to DC_Main.MsAcBal:1463–1487. This pure adapter qualifies only
 * current PostgreSQL JSONB text. It does not authenticate provenance, repair
 * imported clocks, emulate Windows locale parsing or make closing available.
 */
export const SAVED_SALE_RETURN_CLOCK_VERSION = 'saved-sale-return-clock-v1';
export const SAVED_SALE_RETURN_CLOCK_PROFILE = 'canonical-postgresql-jsonb-local-clock-v1';

export interface SavedSaleReturnClockRaw {
  readonly VCH_DATE?: string | null;
  readonly VCH_TIME?: string | null;
}
export interface SavedSaleReturnClockProvenance {
  readonly documentIdentity: string;
  readonly documentVersion: string;
}
export interface SavedSaleReturnClockInput {
  readonly raw: SavedSaleReturnClockRaw;
  readonly provenance: SavedSaleReturnClockProvenance;
}
export interface SavedSaleReturnClockObservation extends SavedSaleReturnClockInput {
  readonly cutoffLocalSecond: string | null;
}
export interface SavedSaleReturnClockDiagnostic {
  readonly code:
    | 'invalid-input'
    | 'missing-saved-column'
    | 'null-saved-column'
    | 'unsupported-saved-date'
    | 'unsupported-saved-time';
  readonly sourceField?: 'VCH_DATE' | 'VCH_TIME';
  readonly message: string;
}
interface ClockResultIdentity {
  readonly version: typeof SAVED_SALE_RETURN_CLOCK_VERSION;
  readonly profile: typeof SAVED_SALE_RETURN_CLOCK_PROFILE;
}
export type SavedSaleReturnClockResult = ClockResultIdentity &
  (
    | Readonly<{
        status: 'ready';
        observation: SavedSaleReturnClockObservation & { readonly cutoffLocalSecond: string };
        diagnostics: readonly [];
      }>
    | Readonly<{
        status: 'unsupported';
        observation: SavedSaleReturnClockObservation & { readonly cutoffLocalSecond: null };
        diagnostics: readonly SavedSaleReturnClockDiagnostic[];
      }>
    | Readonly<{
        status: 'invalid-input';
        observation: null;
        diagnostics: readonly SavedSaleReturnClockDiagnostic[];
      }>
  );

/** Read own enumerable data descriptors only. Nesting is a fixed envelope;
 * values become trusted scalars only after separate validation below.
 */
function fields(
  value: unknown,
  allowed: readonly string[],
  requireAll: boolean,
): Record<string, unknown> | null {
  if (value === null || typeof value !== 'object' || Array.isArray(value)) return null;
  const prototype = Object.getPrototypeOf(value);
  if (prototype !== Object.prototype && prototype !== null) return null;
  const own = Reflect.ownKeys(value);
  if (requireAll && own.length !== allowed.length) return null;
  const result: Record<string, unknown> = {};
  for (const key of own) {
    if (typeof key !== 'string' || !allowed.includes(key)) return null;
    const descriptor = Object.getOwnPropertyDescriptor(value, key);
    if (!descriptor || !descriptor.enumerable || !Object.hasOwn(descriptor, 'value')) return null;
    result[key] = descriptor.value;
  }
  return result;
}
function identifier(value: unknown): value is string {
  return (
    typeof value === 'string' &&
    value.length > 0 &&
    value.length <= 256 &&
    !/[^\x20-\x7e]/.test(value) &&
    value.trim() === value
  );
}
function freeze<T>(value: T): T {
  if (value !== null && typeof value === 'object') {
    for (const child of Object.values(value)) freeze(child);
    Object.freeze(value);
  }
  return value;
}
const identity: ClockResultIdentity = {
  version: SAVED_SALE_RETURN_CLOCK_VERSION,
  profile: SAVED_SALE_RETURN_CLOCK_PROFILE,
};
function invalidInput(): SavedSaleReturnClockResult {
  return freeze({
    ...identity,
    status: 'invalid-input',
    observation: null,
    diagnostics: [
      {
        code: 'invalid-input',
        message:
          'Two owned raw date/clock fields and complete plain-data document provenance are required.',
      },
    ],
  });
}

/** Only bounded integer calendar components use Number. No Date, locale,
 * timezone conversion, rollover or fractional arithmetic occurs here.
 */
function calendarDay(value: string): boolean {
  if (value.length !== 10 || !/^\d{4}-\d{2}-\d{2}$/.test(value)) return false;
  const year = Number(value.slice(0, 4));
  const month = Number(value.slice(5, 7));
  const day = Number(value.slice(8, 10));
  if (year < 1 || year > 9999 || month < 1 || month > 12 || day < 1) return false;
  const leap = year % 4 === 0 && (year % 100 !== 0 || year % 400 === 0);
  const days = [31, leap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
  return day <= days[month - 1]!;
}
function timestampClock(value: string): string | null {
  if (
    value.length < 19 ||
    value.length > 26 ||
    /[^\x20-\x7e]/.test(value) ||
    !/^\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}(?:\.\d{1,6})?$/.test(value) ||
    !calendarDay(value.slice(0, 10)) ||
    Number(value.slice(11, 13)) > 23 ||
    Number(value.slice(14, 16)) > 59 ||
    Number(value.slice(17, 19)) > 59
  )
    return null;
  // Validate the whole stored timestamp first, then deliberately ignore its
  // calendar day and fractional suffix. 23:59:59.999999 remains 23:59:59.
  return value.slice(11, 19);
}

export function projectSavedSaleReturnClock(input: unknown): SavedSaleReturnClockResult {
  try {
    const envelope = fields(input, ['raw', 'provenance'], true);
    if (!envelope) return invalidInput();
    const observed = fields(envelope.raw, ['VCH_DATE', 'VCH_TIME'], false);
    const reference = fields(envelope.provenance, ['documentIdentity', 'documentVersion'], true);
    if (
      !observed ||
      !reference ||
      !Object.values(observed).every((value) => value === null || typeof value === 'string') ||
      !identifier(reference.documentIdentity) ||
      !identifier(reference.documentVersion)
    )
      return invalidInput();
    // The newly allocated raw map preserves absence separately from owned NULL.
    const raw: SavedSaleReturnClockRaw = observed as SavedSaleReturnClockRaw;
    const provenance: SavedSaleReturnClockProvenance = {
      documentIdentity: reference.documentIdentity,
      documentVersion: reference.documentVersion,
    };
    const diagnostics: SavedSaleReturnClockDiagnostic[] = [];
    let date: string | null = null;
    let clock: string | null = null;
    for (const sourceField of ['VCH_DATE', 'VCH_TIME'] as const) {
      if (!Object.hasOwn(raw, sourceField)) {
        diagnostics.push({
          code: 'missing-saved-column',
          sourceField,
          message: `The saved ${sourceField} observation is missing.`,
        });
        continue;
      }
      const value = raw[sourceField]!;
      if (value === null) {
        diagnostics.push({
          code: 'null-saved-column',
          sourceField,
          message: `The saved ${sourceField} is SQL NULL; this profile has no fallback.`,
        });
        continue;
      }
      if (sourceField === 'VCH_DATE') {
        if (calendarDay(value)) date = value;
        else
          diagnostics.push({
            code: 'unsupported-saved-date',
            sourceField,
            message: 'Use the exact saved PostgreSQL JSONB calendar day YYYY-MM-DD.',
          });
      } else {
        clock = timestampClock(value);
        if (clock === null)
          diagnostics.push({
            code: 'unsupported-saved-time',
            sourceField,
            message:
              'The saved clock must be a valid local JSONB timestamp with at most six fractional digits.',
          });
      }
    }
    if (date === null || clock === null)
      return freeze({
        ...identity,
        status: 'unsupported',
        observation: { raw, provenance, cutoffLocalSecond: null },
        diagnostics,
      });
    return freeze({
      ...identity,
      status: 'ready',
      observation: { raw, provenance, cutoffLocalSecond: `${date} ${clock}` },
      diagnostics: [] as const,
    });
  } catch {
    // Unreadable object descriptors are malformed observations, not clock zero.
    return invalidInput();
  }
}
