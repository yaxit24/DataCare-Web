/** Company-open bill tax precision, MS_OPNCOMP.cs:657–671, 741–743,
 * 929–931 and 1297–1303. This is the current SQL Int32-text observation
 * profile, not a general implementation of VB Val or live setting changes.
 * No calculation input, raw setting or policy from this function grants writes.
 */
export const SALE_RETURN_BILL_TAX_POLICY_VERSION = 'sale-return-company-open-tax-policy-v1';
export const SALE_RETURN_BILL_TAX_POLICY_PROFILE = 'sql-int32-text-and-null-v1';

export type SaleReturnBillTaxPolicyRaw = Readonly<{
  'CO_SET.TAX_ROF': string | null;
  'CO_SET.ALL_ROF_REMOVE': string | null;
}>;
export type SaleReturnBillTaxPolicyCode =
  | 'invalid-tax-policy-input'
  | 'unsupported-tax-precision-text'
  | 'tax-precision-int32-overflow'
  | 'unsupported-all-rounding-flag'
  | 'negative-tax-precision';
export interface SaleReturnBillTaxPolicyDiagnostic {
  readonly code: SaleReturnBillTaxPolicyCode;
  readonly key?: keyof SaleReturnBillTaxPolicyRaw;
  readonly message: string;
}
export type SaleReturnBillTaxPolicyProvenance =
  | Readonly<{
      stage: 'int32-conversion';
      inputKind: 'sql-null-via-fnv' | 'canonical-sql-int32-text';
      value: string;
    }>
  | Readonly<{
      stage: 'greater-than-five-fallback';
      applied: boolean;
      before: string;
      after: string;
    }>
  | Readonly<{
      stage: 'all-rounding-flag';
      inputKind: 'blank-default' | 'canonical-flag';
      value: 'N' | 'Y';
    }>
  | Readonly<{
      stage: 'all-rounding-override';
      applied: boolean;
      before: string;
      after: string;
    }>;
export interface SaleReturnBillTaxPolicy {
  readonly version: typeof SALE_RETURN_BILL_TAX_POLICY_VERSION;
  readonly taxRoundingDecimals: 0 | 1 | 2 | 3 | 4 | 5;
}
interface ResolutionBase {
  readonly version: typeof SALE_RETURN_BILL_TAX_POLICY_VERSION;
  readonly profile: typeof SALE_RETURN_BILL_TAX_POLICY_PROFILE;
  /** Null means the input shape was not a complete, exact raw observation. */
  readonly raw: SaleReturnBillTaxPolicyRaw | null;
  readonly provenance: readonly SaleReturnBillTaxPolicyProvenance[];
}
export type SaleReturnBillTaxPolicyResult =
  | (ResolutionBase & {
      readonly status: 'ready';
      readonly raw: SaleReturnBillTaxPolicyRaw;
      readonly policy: SaleReturnBillTaxPolicy;
      readonly diagnostics: readonly [];
    })
  | (ResolutionBase & {
      readonly status: 'unsupported';
      readonly policy: null;
      readonly diagnostics: readonly SaleReturnBillTaxPolicyDiagnostic[];
    });

const keys = ['CO_SET.TAX_ROF', 'CO_SET.ALL_ROF_REMOVE'] as const;
const taxKey = keys[0];
const flagKey = keys[1];
const precision = Object.freeze({ '0': 0, '1': 1, '2': 2, '3': 3, '4': 4, '5': 5 } as const);

/** Accept only two own data properties. Getters and inherited settings are not
 * raw SQL observations. Shape errors must not invent missing fields as NULL.
 */
function readRaw(value: unknown): SaleReturnBillTaxPolicyRaw | null {
  if (value === null || typeof value !== 'object' || Array.isArray(value)) return null;
  try {
    const prototype = Object.getPrototypeOf(value);
    if (prototype !== Object.prototype && prototype !== null) return null;
    const ownKeys = Reflect.ownKeys(value);
    if (ownKeys.length !== keys.length || keys.some((key) => !ownKeys.includes(key))) return null;
    const descriptors = Object.getOwnPropertyDescriptors(value);
    for (const key of keys) {
      const property = descriptors[key];
      if (
        !property ||
        !property.enumerable ||
        !Object.hasOwn(property, 'value') ||
        (property.value !== null && typeof property.value !== 'string')
      )
        return null;
    }
    return Object.freeze({
      [taxKey]: descriptors[taxKey]!.value as string | null,
      [flagKey]: descriptors[flagKey]!.value as string | null,
    });
  } catch {
    return null;
  }
}

/** Compare bounded SQL integer text before any numeric coercion. Math.Round
 * leaves an integral Int32 unchanged; preserving text also avoids Double loss.
 */
function inInt32(value: string): boolean {
  const negative = value.startsWith('-');
  const magnitude = negative ? value.slice(1) : value;
  const maximum = negative ? '2147483648' : '2147483647';
  return (
    magnitude.length < maximum.length ||
    (magnitude.length === maximum.length && magnitude <= maximum)
  );
}

/** Resolve detached, immutable source policy from server-observed SQL text.
 * SQL NULL follows the explicit Fnv path. Blank TAX_ROF, unlike a blank flag,
 * is outside current Int? storage and is not admitted by this named profile.
 * Failed Int32 conversion is contained before either source fallback/override.
 */
export function resolveSaleReturnBillTaxPolicy(input: unknown): SaleReturnBillTaxPolicyResult {
  const raw = readRaw(input);
  const provenance: SaleReturnBillTaxPolicyProvenance[] = [];
  const base = (): ResolutionBase => ({
    version: SALE_RETURN_BILL_TAX_POLICY_VERSION,
    profile: SALE_RETURN_BILL_TAX_POLICY_PROFILE,
    raw,
    provenance: Object.freeze([...provenance]),
  });
  const unsupported = (
    code: SaleReturnBillTaxPolicyCode,
    message: string,
    key?: keyof SaleReturnBillTaxPolicyRaw,
  ): SaleReturnBillTaxPolicyResult =>
    Object.freeze({
      ...base(),
      status: 'unsupported',
      policy: null,
      diagnostics: Object.freeze([
        Object.freeze({ code, message, ...(key === undefined ? {} : { key }) }),
      ]),
    });
  if (!raw)
    return unsupported(
      'invalid-tax-policy-input',
      'Tax policy requires exactly CO_SET.TAX_ROF and CO_SET.ALL_ROF_REMOVE as SQL text or NULL.',
    );
  const inputPrecision = raw[taxKey];
  if (
    inputPrecision !== null &&
    (inputPrecision.trim() !== inputPrecision || !/^(?:0|-?[1-9]\d*)$/.test(inputPrecision))
  )
    return unsupported(
      'unsupported-tax-precision-text',
      'Tax precision is outside the supported canonical SQL Int32-text profile.',
      taxKey,
    );
  const converted = inputPrecision ?? '0';
  if (!inInt32(converted))
    return unsupported(
      'tax-precision-int32-overflow',
      'Tax precision cannot pass the source Int32 conversion before rounding overrides.',
      taxKey,
    );
  provenance.push(
    Object.freeze({
      stage: 'int32-conversion',
      inputKind: inputPrecision === null ? 'sql-null-via-fnv' : 'canonical-sql-int32-text',
      value: converted,
    }),
  );
  const greaterThanFive = !converted.startsWith('-') && (converted.length > 1 || converted > '5');
  const afterFallback = greaterThanFive ? '2' : converted;
  provenance.push(
    Object.freeze({
      stage: 'greater-than-five-fallback',
      applied: greaterThanFive,
      before: converted,
      after: afterFallback,
    }),
  );
  const inputFlag = raw[flagKey];
  if (inputFlag !== '' && inputFlag !== 'N' && inputFlag !== 'Y')
    return unsupported(
      'unsupported-all-rounding-flag',
      'The all-rounding flag requires exact N, Y or the source blank default.',
      flagKey,
    );
  const flag = inputFlag === '' ? 'N' : inputFlag;
  provenance.push(
    Object.freeze({
      stage: 'all-rounding-flag',
      inputKind: inputFlag === '' ? 'blank-default' : 'canonical-flag',
      value: flag,
    }),
  );
  const effective = flag === 'Y' ? '2' : afterFallback;
  provenance.push(
    Object.freeze({
      stage: 'all-rounding-override',
      applied: flag === 'Y',
      before: afterFallback,
      after: effective,
    }),
  );
  if (effective.startsWith('-'))
    return unsupported(
      'negative-tax-precision',
      'Negative tax precision requires the configured all-rounding override.',
      taxKey,
    );
  return Object.freeze({
    ...base(),
    status: 'ready',
    raw,
    policy: Object.freeze({
      version: SALE_RETURN_BILL_TAX_POLICY_VERSION,
      taxRoundingDecimals: precision[effective as keyof typeof precision],
    }),
    diagnostics: Object.freeze([] as const),
  });
}
