import { describe, expect, it } from 'vitest';
import { applyProvenance } from '../src/modules/posting/posting.js';

/**
 * Provenance stamping in `postVoucherTx`.
 *
 * Five columns — `MAIN_USER`, `ADD_USER`, `DATA_TRFR`, `OLD_VCH_NO`, `NEW_VCH_NO` — were missing across
 * dozens of tables, thinly spread. That distribution is the signature of a cross-cutting concern, so they
 * are stamped centrally rather than added to every module, which is also what stops the next write set
 * from forgetting them.
 *
 * These tests pin the rules that keep the stamping safe: it never overwrites a caller's value, never adds
 * a column the table does not have, and never invents an audit identity.
 */
describe('voucher provenance stamping', () => {
  const columns = (...names: string[]): Set<string> => new Set(names);

  it('defaults DATA_TRFR to N on the tables that populate it', () => {
    expect(applyProvenance({}, columns('DATA_TRFR'), 'AC_DATA').DATA_TRFR).toBe('N');
  });

  it('leaves DATA_TRFR unset on the tables the desktop leaves blank', () => {
    /**
     * Measured over all 37 tables carrying the column: `RATE_CUT_ISU` 0/20, `SL_DETL` 0/245,
     * `SL_PR_DETL` 0/25, `AD_OS` 0/8194 and `SL_DETL_RTN` 0/1 never populate it. The previous blanket
     * default stamped 'N' onto every one of them.
     */
    for (const t of ['RATE_CUT_ISU', 'SL_DETL', 'SL_PR_DETL', 'AD_OS', 'SL_DETL_RTN']) {
      expect(applyProvenance({}, columns('DATA_TRFR'), t).DATA_TRFR, t).toBeUndefined();
    }
  });

  it("writes DATA_TRFR 'Y' on the opening-balance tables", () => {
    // OP_DATA 108/108 and ITM_OPBL 72/72 store 'Y', not 'N'.
    for (const t of ['OP_DATA', 'ITM_OPBL']) {
      expect(applyProvenance({}, columns('DATA_TRFR'), t).DATA_TRFR, t).toBe('Y');
    }
  });

  it('never overwrites a value the module supplied', () => {
    // A transfer utility legitimately sets 'Y'; the stamp must not undo it.
    expect(applyProvenance({ DATA_TRFR: 'Y' }, columns('DATA_TRFR'), 'AC_DATA').DATA_TRFR).toBe(
      'Y',
    );
    const renumbered = applyProvenance(
      { OLD_VCH_NO: '00007', NEW_VCH_NO: '00008' },
      columns('OLD_VCH_NO', 'NEW_VCH_NO'),
    );
    expect(renumbered.OLD_VCH_NO).toBe('00007');
    expect(renumbered.NEW_VCH_NO).toBe('00008');
  });

  it('initialises the renumbering trail to null on a fresh voucher', () => {
    const row = applyProvenance({}, columns('OLD_VCH_NO', 'NEW_VCH_NO'));
    // Present-and-null, not absent: the column is written so a later renumber updates rather than inserts.
    expect('OLD_VCH_NO' in row).toBe(true);
    expect('NEW_VCH_NO' in row).toBe(true);
    expect(row.OLD_VCH_NO).toBeNull();
    expect(row.NEW_VCH_NO).toBeNull();
  });

  it('mirrors ADD_USER only on the two tables that populate it', () => {
    /**
     * This assertion previously required the mirror on EVERY table, which was wrong. Measured over all 19
     * tables carrying both columns, `ADD_USER` is populated on only `BAR_DETL` (1169/1329) and
     * `SL_ORD_DETL` (25/63) and is EMPTY on the other seventeen while `MAIN_USER` is filled — including
     * `PR_DETL` 0/103, `CASH_DATA` 0/335, `SL_DETL` 0/245 and `CONTRA_DATA` 0/102. Where it IS written it
     * always equals `MAIN_USER`, so the form was right and only the scope was wrong.
     */
    for (const t of ['BAR_DETL', 'SL_ORD_DETL']) {
      expect(
        applyProvenance({ MAIN_USER: 'admin' }, columns('MAIN_USER', 'ADD_USER'), t).ADD_USER,
        t,
      ).toBe('admin');
    }
    for (const t of ['PR_DETL', 'CASH_DATA', 'SL_DETL', 'CONTRA_DATA', 'RATE_CUT_ISU']) {
      expect(
        'ADD_USER' in applyProvenance({ MAIN_USER: 'admin' }, columns('MAIN_USER', 'ADD_USER'), t),
        t,
      ).toBe(false);
    }
    // With no acting user there is nothing truthful to write even on a mirroring table.
    expect('ADD_USER' in applyProvenance({}, columns('ADD_USER'), 'BAR_DETL')).toBe(false);
  });

  it('preserves an explicit ADD_USER that differs from MAIN_USER, as an edit does', () => {
    // An edited voucher keeps its ORIGINAL creator while MAIN_USER becomes the editor.
    const row = applyProvenance(
      { MAIN_USER: 'editor', ADD_USER: 'original-creator' },
      columns('MAIN_USER', 'ADD_USER'),
      'BAR_DETL',
    );
    expect(row.ADD_USER).toBe('original-creator');
    expect(row.MAIN_USER).toBe('editor');
  });

  it('adds nothing to a table that lacks the columns', () => {
    const row = applyProvenance({ IT_CODE: 'GOLD' }, columns('IT_CODE'));
    expect(row).toEqual({ IT_CODE: 'GOLD' });
  });

  it('leaves the caller object untouched', () => {
    const original = { MAIN_USER: 'admin' };
    applyProvenance(original, columns('MAIN_USER', 'ADD_USER', 'DATA_TRFR'));
    expect(original).toEqual({ MAIN_USER: 'admin' });
  });
});
