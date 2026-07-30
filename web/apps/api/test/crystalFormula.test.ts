import { describe, it, expect } from 'vitest';
import { evalCrystal } from '../src/modules/reports/crystalFormula.js';

const get = (r: string): string =>
  ({
    '{SL_DATA.ADD1}': 'Main St',
    '{SL_DATA.ADD2}': 'Rajkot',
    '{AC_MAST.AC_ADD1}': 'Fallback',
    '{AC_MAST.AC_ADD2}': 'City',
    '{SL_DATA.NET}': '100',
    '{SL_DATA.TAX}': '18',
    '{@Sub}': 'X',
  })[r] ?? '';

describe('crystal formula evaluator', () => {
  it('if/then/else with non-empty condition + string concat', () => {
    expect(
      evalCrystal(
        "if {SL_DATA.ADD1} <> '' then {SL_DATA.ADD1} + ' , ' + {SL_DATA.ADD2} else {AC_MAST.AC_ADD1}",
        get,
      ),
    ).toBe('Main St , Rajkot');
  });
  it('if/then/else takes else branch when condition empty', () => {
    expect(
      evalCrystal(
        "if {MISSING.X} <> '' then {SL_DATA.ADD1} else {AC_MAST.AC_ADD1} + ' , ' + {AC_MAST.AC_ADD2}",
        get,
      ),
    ).toBe('Fallback , City');
  });
  it('numeric addition', () => {
    expect(evalCrystal('{SL_DATA.NET} + {SL_DATA.TAX}', get)).toBe('118');
  });
  it('ToText/Trim passthrough of a field', () => {
    expect(evalCrystal('Trim({SL_DATA.ADD2})', get)).toBe('Rajkot');
  });
  it('nested formula ref', () => {
    expect(evalCrystal("{@Sub} + '!'", get)).toBe('X!');
  });
  it('empty/garbage never throws → returns a string', () => {
    expect(typeof evalCrystal('', get)).toBe('string');
  });
});
