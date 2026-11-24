import { describe, expect, it } from 'vitest';
import { renumberNotice } from '../lib/voucherRenumber';

// WP-10 F4: the saved number differs from the one the screen showed (another operator took it, or the operator typed
// a different one). The desktop says so on save; the text is verbatim, typo and double space included.
describe('renumberNotice', () => {
  it('uses the TR_TAG_CAN text for the Tag Cancel family (TR_TAG_CAN.cs:5046)', () => {
    expect(renumberNotice('00014', '00015', 'tag-cancel')).toBe('New Voucher No: 00015');
  });

  it("uses the 'changd' text for the other forms (TR_TAG_SPLIT.cs:10060)", () => {
    expect(renumberNotice('00020', '15', 'changed')).toBe(
      "Current Voucher No has been changd New Voucher No is  '00015'",
    );
  });

  it('is silent when the saved number is the one shown, or nothing was shown', () => {
    expect(renumberNotice('00015', '15', 'tag-cancel')).toBeNull();
    expect(renumberNotice('', '00015', 'changed')).toBeNull();
  });
});
