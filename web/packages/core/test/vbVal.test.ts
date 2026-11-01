import { describe, expect, it } from 'vitest';
import { vbVal } from '../src/vbVal.js';

/**
 * Expected values follow the VB `Conversion.Val` rules the desktop relies on for its numeric boxes (for example
 * MS_EMP.cs:1503-1504): blanks are skipped anywhere, the longest leading number is read, anything else ends it.
 */
describe('vbVal is VB Conversion.Val of a text box', () => {
  it('reads a plain number, a sign and a bare decimal point', () => {
    expect(vbVal('1250.75')).toBe(1250.75);
    expect(vbVal('-12.5')).toBe(-12.5);
    expect(vbVal('+8')).toBe(8);
    expect(vbVal('.5')).toBe(0.5);
    expect(vbVal('7.')).toBe(7);
  });

  it('skips blanks, tabs and line feeds anywhere in the text', () => {
    expect(vbVal('  1 000 ')).toBe(1000);
    expect(vbVal('\t2 4\n5')).toBe(245);
  });

  it('stops at the first character that is not part of a number', () => {
    expect(vbVal('12.5 KG')).toBe(12.5);
    expect(vbVal('1,000')).toBe(1);
    expect(vbVal('3.2.1')).toBe(3.2);
    expect(vbVal('1-2')).toBe(1);
  });

  it('reads an E or D exponent', () => {
    expect(vbVal('1.5E3')).toBe(1500);
    expect(vbVal('2d2')).toBe(200);
    expect(vbVal('4e')).toBe(4);
  });

  it('gives 0 for blank, text, a lone sign and anything that is not a number', () => {
    expect(vbVal('')).toBe(0);
    expect(vbVal('   ')).toBe(0);
    expect(vbVal('ABC')).toBe(0);
    expect(vbVal('-')).toBe(0);
    expect(vbVal(null)).toBe(0);
    expect(vbVal(undefined)).toBe(0);
    expect(vbVal('&H10')).toBe(0);
  });

  it('passes a finite number through and turns NaN or Infinity into 0', () => {
    expect(vbVal(42.125)).toBe(42.125);
    expect(vbVal(Number.NaN)).toBe(0);
    expect(vbVal(Number.POSITIVE_INFINITY)).toBe(0);
  });
});
