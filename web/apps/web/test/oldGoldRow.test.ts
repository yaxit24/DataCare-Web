import { describe, expect, it } from 'vitest';
import { oldGoldRowAmount } from '../lib/lineRecalc';

const row = (
  cells: Partial<Record<'netWt' | 'touch' | 'rate' | 'conversionWt' | 'rateType', string>>,
) => ({
  netWt: '',
  touch: '',
  rate: '',
  conversionWt: '',
  rateType: '',
  ...cells,
});

/**
 * G83: the sale and sales-quotation screens preview an exchange row with the same kernel valuation the writer
 * stores (`valueOldGoldLine`, `TR_SALE.cs` `CommPassTotal_Old`). Expected values are worked from the desktop:
 * fine = Strings.Format(net x touch / 100, "0.000"), amount = Math.Round(basis x rate, 0).
 */
describe('old-gold row preview on the sale screens', () => {
  it('shows the stored whole-rupee figure, not net x touch x rate to the paisa', () => {
    // fine 4.452, Math.Round(25821.6, 0) = 25822; the old screen showed 25821.60.
    expect(oldGoldRowAmount(row({ netWt: '5.3', touch: '84', rate: '5800' }))).toBe(25822);
  });

  it('values a net-wise row on the net weight and a conversion row on the conversion weight', () => {
    expect(oldGoldRowAmount(row({ netWt: '4.3', touch: '90', rate: '100', rateType: 'N' }))).toBe(
      430,
    );
    expect(
      oldGoldRowAmount(row({ netWt: '4.3', touch: '90', rate: '100', conversionWt: '0.1' })),
    ).toBe(10);
  });

  it('uses the net weight as the fine when no touch is entered, and is 0 without a rate', () => {
    expect(oldGoldRowAmount(row({ netWt: '2', rate: '6000' }))).toBe(12000);
    expect(oldGoldRowAmount(row({ netWt: '5.3', touch: '84' }))).toBe(0);
    expect(oldGoldRowAmount(row({}))).toBe(0);
  });
});
