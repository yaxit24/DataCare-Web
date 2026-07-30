export type ScaleUnit = 'g' | 'kg';

export interface ScaleReadingInput {
  value: unknown;
  unit: unknown;
  stable: unknown;
  timestamp: unknown;
}

export interface ScaleReadingPolicy {
  allowedUnits: readonly ScaleUnit[];
  decimalPlaces: number;
  minGrams: number;
  maxGrams: number;
  maxAgeMs: number;
  futureToleranceMs?: number;
  now?: Date;
}

export interface NormalizedScaleReading {
  value: number;
  unit: ScaleUnit;
  grams: number;
  stable: boolean;
  timestamp: string;
}

export class ScaleReadingValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'ScaleReadingValidationError';
  }
}

function fail(message: string): never {
  throw new ScaleReadingValidationError(message);
}

/**
 * Validate an untrusted local-agent/WebSerial reading without assuming shop-specific limits.
 * TR_TAG_OPBL.cs:7557-7590 extracts numeric scale text and formats it to exactly three decimals;
 * callers therefore supply the allowed unit/range/freshness policy explicitly.
 */
export function normalizeScaleReading(
  input: ScaleReadingInput,
  policy: ScaleReadingPolicy,
): NormalizedScaleReading {
  if (
    !Number.isInteger(policy.decimalPlaces) ||
    policy.decimalPlaces < 0 ||
    policy.decimalPlaces > 6
  )
    fail('scale decimal policy is invalid');
  if (
    !Number.isFinite(policy.minGrams) ||
    !Number.isFinite(policy.maxGrams) ||
    policy.minGrams < 0 ||
    policy.maxGrams <= policy.minGrams
  )
    fail('scale range policy is invalid');
  if (!Number.isFinite(policy.maxAgeMs) || policy.maxAgeMs < 0)
    fail('scale freshness policy is invalid');

  if (typeof input.value !== 'string') fail('scale value must be a decimal string');
  const valueText = input.value.trim();
  const decimalPattern = new RegExp(`^\\d+(?:\\.\\d{1,${policy.decimalPlaces}})?$`);
  if (!decimalPattern.test(valueText)) fail('scale value is malformed or too precise');
  const value = Number(valueText);
  if (!Number.isFinite(value)) fail('scale value is malformed');

  if (input.unit !== 'g' && input.unit !== 'kg') fail('scale unit is unsupported');
  const unit = input.unit;
  if (!policy.allowedUnits.includes(unit)) fail('scale unit is not allowed');
  if (typeof input.stable !== 'boolean') fail('scale stability flag must be boolean');
  if (typeof input.timestamp !== 'string') fail('scale timestamp must be an ISO string');

  const timestamp = new Date(input.timestamp);
  if (Number.isNaN(timestamp.getTime()) || timestamp.toISOString() !== input.timestamp)
    fail('scale timestamp is malformed');
  const nowMs = (policy.now ?? new Date()).getTime();
  const futureToleranceMs = policy.futureToleranceMs ?? 0;
  if (timestamp.getTime() > nowMs + futureToleranceMs) fail('scale timestamp is in the future');
  if (nowMs - timestamp.getTime() > policy.maxAgeMs) fail('scale reading is stale');

  const grams = unit === 'kg' ? value * 1000 : value;
  if (grams < policy.minGrams || grams > policy.maxGrams)
    fail('scale value is outside the configured range');

  return {
    value,
    unit,
    grams: Number(grams.toFixed(policy.decimalPlaces)),
    stable: input.stable,
    timestamp: timestamp.toISOString(),
  };
}
