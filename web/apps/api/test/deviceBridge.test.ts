import { describe, expect, it } from 'vitest';
import {
  normalizeScaleReading,
  ScaleReadingValidationError,
  type ScaleReadingPolicy,
} from '../src/modules/integrations/deviceBridge.js';

const policy: ScaleReadingPolicy = {
  allowedUnits: ['g', 'kg'],
  decimalPlaces: 3,
  minGrams: 0,
  maxGrams: 100_000,
  maxAgeMs: 5_000,
  now: new Date('2026-07-28T00:00:05.000Z'),
};

const reading = {
  value: '12.345',
  unit: 'g',
  stable: true,
  timestamp: '2026-07-28T00:00:03.000Z',
};

describe('scale reading validator', () => {
  it('normalizes a valid reading', () => {
    expect(normalizeScaleReading(reading, policy)).toEqual({
      value: 12.345,
      unit: 'g',
      grams: 12.345,
      stable: true,
      timestamp: '2026-07-28T00:00:03.000Z',
    });
  });

  it('preserves an unstable reading without pretending it is stable', () => {
    expect(normalizeScaleReading({ ...reading, stable: false }, policy).stable).toBe(false);
  });

  it('rejects an out-of-range reading', () => {
    expect(() =>
      normalizeScaleReading({ ...reading, value: '100.001', unit: 'kg' }, policy),
    ).toThrow('outside the configured range');
  });

  it('rejects a wrong unit', () => {
    expect(() => normalizeScaleReading({ ...reading, unit: 'lb' }, policy)).toThrow(
      ScaleReadingValidationError,
    );
  });

  it('rejects malformed and over-precise readings', () => {
    for (const value of [12.345, '12g', '-1.000', '1.2345']) {
      expect(() => normalizeScaleReading({ ...reading, value }, policy)).toThrow(
        ScaleReadingValidationError,
      );
    }
  });
});
