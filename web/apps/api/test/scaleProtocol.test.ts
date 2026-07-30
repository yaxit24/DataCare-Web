import { describe, expect, it } from 'vitest';
import {
  parseScaleFrame,
  SCALE_PORT_PROFILES,
  SCALE_TARGET_GRID_COLUMN,
  scaleCaptureEnabled,
} from '../src/modules/integrations/scaleProtocol.js';

/**
 * Scale protocol parity with `TR_TAG_OPBL.cs`. These are the frames a real CH340 scale emits, so this
 * suite is what makes "the hardware will work when it arrives" a checkable claim rather than a hope.
 */
describe('weighing scale frame parsing', () => {
  it('extracts a plain reading and formats it to three decimals', () => {
    expect(parseScaleFrame('12.345\r\n').text).toBe('12.345');
    expect(parseScaleFrame('12.345\r\n').value).toBeCloseTo(12.345, 3);
  });

  it('drops the + sign and CR the desktop excludes explicitly', () => {
    // Many scales prefix a stable positive reading with '+'.
    expect(parseScaleFrame('+  12.345\r').text).toBe('12.345');
    expect(parseScaleFrame('+000.500\r').value).toBeCloseTo(0.5, 3);
  });

  it('strips unit letters and whitespace, keeping only digits and the point', () => {
    expect(parseScaleFrame('ST,GS,+  1.234 g\r\n').extracted).toBe('1.234');
  });

  it('loses the sign on a negative reading, exactly as the desktop does', () => {
    // The keep-set is numeric-or-dot; '-' is not in it, so a tare-negative weight arrives positive.
    const result = parseScaleFrame('-1.234\r\n');
    expect(result.text).toBe('1.234');
    expect(result.signDropped).toBe(true);
  });

  it('scans at most the first twenty characters', () => {
    // The 9 lands at index 20 (0-based), one past the desktop's window, so it must not be picked up.
    const frame = `${' '.repeat(20)}9`;
    expect(parseScaleFrame(frame).extracted).toBe('');
    expect(parseScaleFrame(`${' '.repeat(19)}9`).extracted).toBe('9');
  });

  it('reports an empty frame distinguishably from a zero weight', () => {
    const empty = parseScaleFrame('');
    expect(empty.extracted).toBe('');
    expect(empty.value).toBe(0);
    // A real zero reading carries digits, so callers can tell them apart.
    expect(parseScaleFrame('0.000\r').extracted).toBe('0.000');
  });

  it('stops at a second decimal point, as VB Val does', () => {
    expect(parseScaleFrame('1.2.3\r').extracted).toBe('1.2.3');
    expect(parseScaleFrame('1.2.3\r').value).toBeCloseTo(1.2, 3);
  });

  it('is disabled by WEIGHT_PORT = 0 and by a blank setting', () => {
    expect(scaleCaptureEnabled('0')).toBe(false);
    expect(scaleCaptureEnabled('')).toBe(false);
    expect(scaleCaptureEnabled(null)).toBe(false);
    expect(scaleCaptureEnabled('COM3')).toBe(true);
  });

  it('publishes both desktop port profiles, including the 7-data-bit fallback', () => {
    expect(SCALE_PORT_PROFILES.primary).toEqual({
      baudRate: 9600,
      dataBits: 8,
      parity: 'none',
      stopBits: 1,
    });
    // The fallback changes BOTH baud rate and data bits; reading 7-bit data as 8-bit corrupts digits.
    expect(SCALE_PORT_PROFILES.fallback).toEqual({
      baudRate: 2400,
      dataBits: 7,
      parity: 'none',
      stopBits: 1,
    });
  });

  it('targets the desktop net-weight grid column', () => {
    expect(SCALE_TARGET_GRID_COLUMN).toBe(14);
  });
});
