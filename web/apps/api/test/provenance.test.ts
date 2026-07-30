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

  it('defaults DATA_TRFR to N, meaning not yet transferred', () => {
    expect(applyProvenance({}, columns('DATA_TRFR')).DATA_TRFR).toBe('N');
  });

  it('never overwrites a value the module supplied', () => {
    // A transfer utility legitimately sets 'Y'; the stamp must not undo it.
    expect(applyProvenance({ DATA_TRFR: 'Y' }, columns('DATA_TRFR')).DATA_TRFR).toBe('Y');
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

  it('mirrors ADD_USER from MAIN_USER, and never invents one', () => {
    expect(applyProvenance({ MAIN_USER: 'admin' }, columns('MAIN_USER', 'ADD_USER')).ADD_USER).toBe(
      'admin',
    );
    // With no acting user there is nothing truthful to write, so ADD_USER stays unset rather than
    // receiving a placeholder that would look like a real audit trail.
    expect('ADD_USER' in applyProvenance({}, columns('ADD_USER'))).toBe(false);
  });

  it('preserves an explicit ADD_USER that differs from MAIN_USER, as an edit does', () => {
    // An edited voucher keeps its ORIGINAL creator while MAIN_USER becomes the editor.
    const row = applyProvenance(
      { MAIN_USER: 'editor', ADD_USER: 'original-creator' },
      columns('MAIN_USER', 'ADD_USER'),
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
