import { describe, expect, it } from 'vitest';
import { creditNoteValue } from '../lib/creditNoteView';

describe('credit-note saved field display', () => {
  it('formats only calendar date fields in desktop dd/MM/yyyy form', () => {
    expect(creditNoteValue('2026-10-01', 'VCH_DATE')).toBe('01/10/2026');
    expect(creditNoteValue('2026-10-01T23:30:00+05:30', 'ACK_DATE')).toBe('01/10/2026');
    expect(creditNoteValue('2026-10-01', 'BILL_NO')).toBe('2026-10-01');
  });

  it('preserves explicit null and blank labels for date fields', () => {
    expect(creditNoteValue(null, 'VCH_DATE')).toBe('Not set');
    expect(creditNoteValue('', 'ACK_DATE')).toBe('Blank');
  });
});
