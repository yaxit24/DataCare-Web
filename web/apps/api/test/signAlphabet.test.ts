/**
 * `SIGN` is a MOVEMENT DIRECTION, not a debit/credit marker.
 *
 * Measured across every table in the real customer database that has a `SIGN` column - 11,548 rows:
 *
 *     AC_DATA        blank 4975   + 105    - 70
 *     ROJ_MEL_DATA   blank 2711   + 160    - 308
 *     AD_OS                       + 8160   - 34
 *     AD_ADJ                               - 26
 *
 * 'C' and 'D' appear NOWHERE, yet 122 web write sites across 14 modules used them. The desktop leaves SIGN
 * blank on a money leg and sets +/- only where metal moves: 174 of the 175 signed AC_DATA rows carry a non-zero
 * FINE_WT, the single exception being in book 034 (wholesale sale, which is not built).
 *
 * THE C/D ALPHABET IS CORRECT FOR OTHER COLUMNS, which is why this is normalised on `SIGN` alone:
 * OP_DATA.OP_SIGN is D 73 / C 35 and OP_DATA.FINE_SIGN is D 97 / C 11 - genuine opening-balance debit/credit
 * markers. A blanket rename across every *SIGN* column would have broken those.
 */
import { describe, expect, it } from 'vitest';
import { enrichLedgerLine } from '../src/modules/posting/posting.js';

const base = {
  CO_CODE: '01',
  LC_CODE: '00',
  CO_YEAR: '2024-2025',
  CO_BOOK: '035',
  VCH_NO: '00001',
  AC_CODE: '000903',
};

describe('SIGN carries the desktop alphabet', () => {
  it("maps 'C' and 'D' to blank — neither appears in 11,548 real rows", () => {
    for (const wrong of ['C', 'D'] as const) {
      const row = enrichLedgerLine({ ...base, SIGN: wrong } as never, 1, '', false);
      expect(row.SIGN).toBe('');
    }
  });

  it("preserves '+' and '-' — the real metal-movement values", () => {
    for (const right of ['+', '-'] as const) {
      const row = enrichLedgerLine({ ...base, SIGN: right, FINE_WT: 7.917 } as never, 1, '', false);
      expect(row.SIGN).toBe(right);
    }
  });

  it('defaults to blank, which is what 4975 of 5150 real ledger rows hold', () => {
    const row = enrichLedgerLine({ ...base } as never, 1, '', false);
    expect(row.SIGN).toBe('');
  });
});
