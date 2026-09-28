/** Exact mathematical storage qualification for the three SL_DATA Float targets.
 * This is narrower than decimal-to-nearest-Double conversion; it is not Windows
 * runtime parity. It performs no calculation replay, mutation or authorization.
 */
export const SALE_RETURN_HEADER_FLOAT_VERSION = 'sale-return-header-exact-binary64-v1' as const;
export const SALE_RETURN_HEADER_FLOAT_PROFILE = 'plain-decimal-36sd-18dp-exact-binary64' as const;
const fields = ['RTN_NET_AMT', 'RTN_TOT_AMT', 'RTN_BILL_OS'] as const;
type Field = (typeof fields)[number];
type Values = Readonly<Record<Field, string>>;
type Code = 'invalid-envelope' | 'invalid-decimal' | 'unsupported-precision' | 'inexact-binary64';
export type SaleReturnHeaderFloatResult =
  | {
      readonly status: 'ready';
      readonly version: typeof SALE_RETURN_HEADER_FLOAT_VERSION;
      readonly profile: typeof SALE_RETURN_HEADER_FLOAT_PROFILE;
      readonly raw: Values;
      readonly values: Values;
      readonly canCommit: false;
    }
  | {
      readonly status: 'unsupported';
      readonly version: typeof SALE_RETURN_HEADER_FLOAT_VERSION;
      readonly profile: typeof SALE_RETURN_HEADER_FLOAT_PROFILE;
      readonly raw: Values | null;
      readonly values: null;
      readonly canCommit: false;
      readonly diagnostic: Readonly<{ code: Code; field: Field | null; recoverable: true }>;
    };

function parseExact(text: string): { value: string } | { code: Exclude<Code, 'invalid-envelope'> } {
  if (text.length > 128 || /[^\x20-\x7e]/.test(text)) return { code: 'invalid-decimal' };
  const match = /^ *([+-]?)(?:(\d+)(?:\.(\d*))?|\.(\d+)) *$/.exec(text);
  if (!match) return { code: 'invalid-decimal' };
  const integer = (match[2] ?? '0').replace(/^0+/, '') || '0';
  const fraction = (match[3] ?? match[4] ?? '').replace(/0+$/, '');
  const digits = (integer + fraction).replace(/^0+/, '') || '0';
  if (digits.length > 36 || fraction.length > 18 || integer.length > 36)
    return { code: 'unsupported-precision' };
  let numerator = BigInt(digits);
  if (numerator === 0n) return { value: '0' };
  // decimal n/10^scale has a finite binary expansion only if every factor5
  // cancels. Keep all arithmetic integral; no lossy Number roundtrip.
  const fives = 5n ** BigInt(fraction.length);
  if (numerator % fives !== 0n) return { code: 'inexact-binary64' };
  numerator /= fives;
  let exponent = -fraction.length;
  while (numerator % 2n === 0n) {
    numerator /= 2n;
    exponent += 1;
  }
  const bits = numerator.toString(2).length;
  if (bits > 53 || exponent < -1074 || exponent + bits - 1 > 1023)
    return { code: 'inexact-binary64' };
  return { value: `${match[1] === '-' ? '-' : ''}${integer}${fraction ? `.${fraction}` : ''}` };
}

/** Caller must separately replay and validate the complete saved write profile.
 * Qualifying these values does not prove they belong to any actual document.
 */
export function qualifySaleReturnHeaderFloat(input: unknown): SaleReturnHeaderFloatResult {
  let raw: Values | null = null;
  const unsupported = (code: Code, field: Field | null): SaleReturnHeaderFloatResult =>
    Object.freeze({
      status: 'unsupported',
      version: SALE_RETURN_HEADER_FLOAT_VERSION,
      profile: SALE_RETURN_HEADER_FLOAT_PROFILE,
      raw,
      values: null,
      canCommit: false,
      diagnostic: Object.freeze({ code, field, recoverable: true }),
    });
  if (!input || typeof input !== 'object' || Array.isArray(input))
    return unsupported('invalid-envelope', null);
  const proto = Object.getPrototypeOf(input);
  if (proto !== Object.prototype && proto !== null) return unsupported('invalid-envelope', null);
  const keys = Reflect.ownKeys(input);
  if (
    keys.length !== fields.length ||
    keys.some((key) => typeof key !== 'string' || !fields.includes(key as Field))
  )
    return unsupported('invalid-envelope', null);
  const detached = {} as Record<Field, string>;
  for (const field of fields) {
    const descriptor = Object.getOwnPropertyDescriptor(input, field);
    if (!descriptor?.enumerable || !('value' in descriptor) || typeof descriptor.value !== 'string')
      return unsupported('invalid-envelope', field);
    detached[field] = descriptor.value;
  }
  raw = Object.freeze(detached);
  const values = {} as Record<Field, string>;
  for (const field of fields) {
    const parsed = parseExact(raw[field]);
    if ('code' in parsed) return unsupported(parsed.code, field);
    values[field] = parsed.value;
  }
  return Object.freeze({
    status: 'ready',
    version: SALE_RETURN_HEADER_FLOAT_VERSION,
    profile: SALE_RETURN_HEADER_FLOAT_PROFILE,
    raw,
    values: Object.freeze(values),
    canCommit: false,
  });
}
