import { describe, expect, it } from 'vitest';
import {
  SUB_DETAIL_COLUMNS,
  SUB_DETAIL_CORE,
  SUB_DETAIL_KARIGAR,
  blankSubDetailRow,
  isSubDetailRowFilled,
  subDetailInputs,
  toSubDetailInput,
  type SubDetailField,
} from '../components/SubDetailGrid';

/**
 * The shared sub-detail grid backs the desktop's 38 `*_IDTL` grids across 35 forms. The DOM is
 * covered by route-coverage.mjs and browser.smoke.mjs; this file pins the conversion rules, which
 * are where a silent data defect would live.
 */
describe('sub-detail grid contract', () => {
  it('gives every field a desktop-transcribed label and a sane width', () => {
    const fields = Object.keys(SUB_DETAIL_COLUMNS) as SubDetailField[];
    expect(fields.length).toBeGreaterThanOrEqual(30);
    for (const field of fields) {
      const spec = SUB_DETAIL_COLUMNS[field];
      expect(spec.label, field).toMatch(/^[A-Za-z%/]+$/);
      expect(spec.width ?? 0, field).toBeGreaterThan(0);
    }
  });

  it('keeps the core and karigar sets inside the declared field registry', () => {
    for (const field of [...SUB_DETAIL_CORE, ...SUB_DETAIL_KARIGAR]) {
      expect(SUB_DETAIL_COLUMNS[field], field).toBeDefined();
    }
    // The core is the majority-of-desktop-forms set; it must stay a strict subset so a form can
    // still declare fewer columns than the core when its own grid is narrower.
    expect(SUB_DETAIL_CORE.length).toBeLessThan(Object.keys(SUB_DETAIL_COLUMNS).length);
  });

  it('offers a master picker exactly where the column is a coded reference', () => {
    expect(SUB_DETAIL_COLUMNS.itCode.lookup).toBe('items');
    // DM_CODE is backed by DM_MAST, which the desktop reads at 60 call sites. Without this the
    // column would be free text and DmName/DmColor would never autofill.
    expect(SUB_DETAIL_COLUMNS.dmCode.lookup).toBe('diamonds');
    expect(SUB_DETAIL_COLUMNS.dmName.lookup).toBeUndefined();
  });

  /**
   * The defect this prevents: `Number(value || 0)` turns an untouched field into an explicit zero,
   * which the server then treats as an operator assertion rather than an absence. That is precisely
   * how the dhiran interest and karigar labour engines were silently disabled (P1-1, P1-2).
   */
  it('omits blank cells rather than sending zero or empty string', () => {
    const row = blankSubDetailRow();
    expect(toSubDetailInput(row)).toEqual({});

    const partial = { dmCode: 'DM1', pcs: '', rate: '   ', grossWt: '0' };
    const converted = toSubDetailInput(partial);
    expect(converted).toEqual({ dmCode: 'DM1', grossWt: 0 });
    expect('pcs' in converted).toBe(false);
    expect('rate' in converted).toBe(false);
    // An explicit zero the operator typed IS meaningful and must survive.
    expect(converted.grossWt).toBe(0);
  });

  it('coerces numerics and trims text, dropping unparseable numbers', () => {
    expect(toSubDetailInput({ pcs: '3', grossWt: '1.234', dmName: '  Round  ' })).toEqual({
      pcs: 3,
      grossWt: 1.234,
      dmName: 'Round',
    });
    // A non-numeric keystroke in a numeric cell must not become NaN in the payload.
    expect(toSubDetailInput({ pcs: 'abc' })).toEqual({});
  });

  it('treats a row as filled only when something was entered', () => {
    expect(isSubDetailRowFilled(blankSubDetailRow())).toBe(false);
    expect(isSubDetailRowFilled({ dmCode: '   ' })).toBe(false);
    expect(isSubDetailRowFilled({ dmCode: 'DM1' })).toBe(true);
  });

  it('submits only filled rows, so a trailing blank entry row is never persisted', () => {
    const rows = [{ dmCode: 'DM1', pcs: '2' }, blankSubDetailRow(), { dmCode: 'DM2' }];
    expect(subDetailInputs(rows)).toEqual([{ dmCode: 'DM1', pcs: 2 }, { dmCode: 'DM2' }]);
  });
});
