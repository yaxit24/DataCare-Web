import { describe, expect, it } from 'vitest';
import {
  mfgLotComponents,
  mfgLotDisplayName,
  mfgLotFields,
  mfgLotValue,
  type MfgLotDocument,
} from '../lib/mfgLotView';
describe('lossless saved lot presentation', () => {
  it('shows exact decimal text, null and blank distinctly without rounding or timezone conversion', () => {
    expect(mfgLotValue('9999999999999999.99')).toBe('9999999999999999.99');
    expect(mfgLotValue('0.000')).toBe('0.000');
    expect(mfgLotValue(null)).toBe('Not set');
    expect(mfgLotValue('')).toBe('Blank');
    expect(mfgLotValue('2024-01-01T23:59:59.123456')).toBe('2024-01-01T23:59:59.123456');
  });
  it('attaches components through persisted SR_NO and retains all noncontiguous child identities', () => {
    const document = {
      components: [
        { SR_NO: '17', ISR_NO: '3', ITM_LOT: 'A' },
        { SR_NO: '17', ISR_NO: '9', ITM_LOT: 'B' },
        { SR_NO: '42', ISR_NO: '3', ITM_LOT: 'C' },
      ],
    } as unknown as MfgLotDocument;
    expect(
      mfgLotComponents(document, { SR_NO: '17', OLD_SRNO: '42' }).map((c) => c.ITM_LOT),
    ).toEqual(['A', 'B']);
  });
  it('uses descriptor label order and retains unknown saved fields without inventing absent component lot', () => {
    const fields = mfgLotFields({
      CUSTOM_IMPORTED: 'value',
      ISR_NO: '9',
      SR_NO: '17',
      IT_GWT: '0.123',
    });
    expect(fields.map((f) => f.key)).toEqual(['SR_NO', 'ISR_NO', 'IT_GWT', 'CUSTOM_IMPORTED']);
    expect(fields.find((f) => f.key === 'ITM_LOT')).toBeUndefined();
    expect(fields.at(-1)).toEqual({
      key: 'CUSTOM_IMPORTED',
      label: 'CUSTOM_IMPORTED',
      value: 'value',
    });
  });
  it('resolves names only for actual account/item references and leaves saved codes untouched', () => {
    const labels = {
      accounts: { SAME: 'Scoped account', UNRESOLVED: null },
      items: { SAME: 'Scoped item' },
    };
    const row = { AC_CODE: 'SAME', IT_CODE: 'SAME', TAG_NO: 'SAME', ITM_LOT: 'SAME' };
    expect(mfgLotDisplayName('AC_CODE', row.AC_CODE, labels)).toBe('Scoped account');
    expect(mfgLotDisplayName('ITM_LOT_AC_CODE', 'SAME', labels)).toBe('Scoped account');
    expect(mfgLotDisplayName('receivedItemCode', 'SAME', labels)).toBe('Scoped item');
    expect(mfgLotDisplayName('IT_CODE', row.IT_CODE, labels)).toBe('Scoped item');
    expect(mfgLotDisplayName('TAG_NO', row.TAG_NO, labels)).toBeNull();
    expect(mfgLotDisplayName('ITM_LOT', row.ITM_LOT, labels)).toBeNull();
    expect(mfgLotDisplayName('AC_CODE', 'UNRESOLVED', labels)).toBeNull();
    expect(mfgLotDisplayName('AC_CODE', 'MISSING', labels)).toBeNull();
    expect(mfgLotFields(row).map((field) => field.value)).toEqual(['SAME', 'SAME', 'SAME', 'SAME']);
  });
});
