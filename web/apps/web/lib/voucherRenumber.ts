/**
 * The desktop's save-time renumber notice. A screen shows the book's next number on New; at save the desktop checks
 * whether that number is now taken and, if so, re-reads MAX+1 and tells the operator before saving under the new
 * number. The web takes the number at save from the allocator (`nextVoucherNoTx`, under the book's lock), so when the
 * saved number is not the one the screen showed, the page shows the same notice, word for word.
 *
 * - TR_TAG_CAN (Tag Cancel, Tag Transfer and Stock Adjust: one form, MDI_FORM.cs:8586, :8617, :8664):
 *   TR_TAG_CAN.cs:5046 {{New Voucher No: }}
 * - Every other form (TR_SALE, TR_TAG_SPLIT, ...), spelling and the two spaces as in the source:
 *   TR_TAG_SPLIT.cs:10060 {{Current Voucher No has been changd New Voucher No is  '}}
 */
export type RenumberText = 'tag-cancel' | 'changed';

const asNumber = (value: string): number | null => {
  const trimmed = value.trim();
  if (!/^\d+$/.test(trimmed)) return null;
  return Number(trimmed);
};

/** The notice, or `null` when the screen showed no number or the saved number is the one it showed. */
export function renumberNotice(shown: string, saved: string, text: RenumberText): string | null {
  const before = asNumber(shown);
  const after = asNumber(saved);
  if (before == null || after == null || before === after) return null;
  const formatted = String(after).padStart(5, '0');
  return text === 'tag-cancel'
    ? `New Voucher No: ${formatted}`
    : `Current Voucher No has been changd New Voucher No is  '${formatted}'`;
}
