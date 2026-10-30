import { describe, expect, it } from 'vitest';
import { neighbourPath, voucherNumberKey } from '../lib/voucherNumberKeys';

describe('voucherNumberKey (tVchNo_KeyDown, TR_SALE.cs:17068-17096)', () => {
  it('maps F1, Up, Down and Enter like the desktop', () => {
    expect(voucherNumberKey({ key: 'F1' })).toBe('list');
    expect(voucherNumberKey({ key: 'ArrowUp' })).toBe('next');
    expect(voucherNumberKey({ key: 'ArrowDown' })).toBe('previous');
    expect(voucherNumberKey({ key: 'Enter' })).toBe('open');
  });

  it('leaves typing and other keys alone', () => {
    for (const key of [
      '0',
      '5',
      'a',
      'Backspace',
      'Tab',
      'ArrowLeft',
      'ArrowRight',
      'F2',
      'Escape',
    ])
      expect(voucherNumberKey({ key })).toBeNull();
  });

  it('leaves the shell chords alone (Alt+S save, Ctrl+F1, Meta combinations)', () => {
    expect(voucherNumberKey({ key: 'F1', ctrlKey: true })).toBeNull();
    expect(voucherNumberKey({ key: 'Enter', altKey: true })).toBeNull();
    expect(voucherNumberKey({ key: 'ArrowUp', metaKey: true })).toBeNull();
  });
});

describe('neighbourPath', () => {
  it('asks for one step from the trimmed number, empty in the new-entry state', () => {
    expect(neighbourPath('SL_DATA', 'SL', ' 00005 ', 'next')).toBe(
      '/vouchers/neighbour?table=SL_DATA&book=SL&from=00005&direction=next',
    );
    expect(neighbourPath('PR_DATA', 'P 1', '', 'previous')).toBe(
      '/vouchers/neighbour?table=PR_DATA&book=P+1&from=&direction=previous',
    );
  });
});
