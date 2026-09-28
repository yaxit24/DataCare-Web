/**
 * Family 4 (purchase) — the Rojmel's party row and item columns.
 *
 * Both rules were already measured; the purchase module simply did not honour them.
 *
 * ## The party row is conditional on the bill being OUTSTANDING
 * Measured in family 1 on the sale books: of 47 sales with BILL_OS = 0, ZERO carry a party Rojmel row; of 42
 * with BILL_OS <> 0, all 42 do. A settled bill leaves no receivable for a day book to show. `buildSaleRojmel`
 * gates on its `partyAmount` argument and names the local `outstanding`, but the purchase passed
 * `totals.total`, so the condition was always true.
 *
 * It reproduces on the real purchase books:
 *   035/00001  pays 6780.00 cash against a 6780.00 bill (BILL_OS 0)  -> ONE Rojmel row, the line row
 *   035/00003  leaves a balance                                      -> THREE rows (line, party, cash)
 *
 * ## A metal row carries its item; a money row never does
 * Measured across the sale and purchase books: every IT_TYPE 'G'/'S' row has IT_CODE set (240 rows, 0 blank)
 * and every IT_TYPE 'A' money row has it blank (466 rows, 0 set). The real purchase line rows carry '999'
 * with IT_DESC 'FINE GOLD', and 'ORG' with 'GOLD ORNAMENTS'.
 */
import { describe, expect, it } from 'vitest';
import { buildSaleRojmel } from '../src/modules/shared/rojmel.js';

const ctx = {
  scope: { coCode: '01', lcCode: '00', coYear: '2024-2025' },
  key: {
    CO_CODE: '01',
    LC_CODE: '00',
    CO_YEAR: '2024-2025',
    CO_BOOK: '035',
    VCH_NO: '00001',
  },
  coBook: '035',
  vchNo: '00001',
  vchDate: new Date('2024-04-01T00:00:00Z'),
  vchType: 'FGPR',
  bookName: 'Gold Purchase',
  partyName: 'GOLD SUPPLIER',
  partyCode: '000903',
};

const line = {
  lineNo: 1,
  revenueAc: '00008',
  amount: 6780,
  itemCode: '999',
  itemName: 'FINE GOLD',
  metal: 'G' as const,
  pcs: 1,
  grossWt: 1,
  netWt: 1,
  rate: 6780,
};

describe('purchase Rojmel: the party row follows BILL_OS', () => {
  it('writes NO party row when the bill is settled — real voucher 035/00001 has one row', () => {
    const rows = buildSaleRojmel(
      ctx as never,
      [line] as never,
      { taxAc: '00014', taxAmount: 0, partyAmount: 0 },
      false,
    );
    expect(rows).toHaveLength(1);
    // The single row is the LINE row: purchase account, party as contra, the line's money.
    const r = rows[0] as never as Record<string, unknown>;
    expect(r.AC_CODE).toBe('00008');
    expect(r.LD_CODE).toBe('000903');
    expect(Number(r.DR_AMT)).toBe(6780);
  });

  it('writes a party row when a balance remains — real voucher 035/00003 has three', () => {
    const rows = buildSaleRojmel(
      ctx as never,
      [line] as never,
      { taxAc: '00014', taxAmount: 0, partyAmount: 850 },
      false,
    );
    expect(rows).toHaveLength(2);
    const party = rows.find(
      (x) => (x as never as { AC_CODE: string }).AC_CODE === '000903',
    ) as never as Record<string, unknown>;
    expect(party).toBeDefined();
    // Inward voucher, money owed to the supplier: the party is CREDITED.
    expect(Number(party.CR_AMT)).toBe(850);
    expect(Number(party.DR_AMT)).toBe(0);
  });
});

describe('purchase Rojmel: item columns on metal rows only', () => {
  it('carries IT_CODE and IT_DESC on the metal line row', () => {
    const rows = buildSaleRojmel(
      ctx as never,
      [line] as never,
      { taxAc: '00014', taxAmount: 0, partyAmount: 0 },
      false,
    );
    const r = rows[0] as never as Record<string, unknown>;
    expect(r.IT_CODE).toBe('999');
    expect(r.IT_DESC).toBe('FINE GOLD');
  });

  it('leaves them blank on the money party row — 466 real money rows, 0 with an item', () => {
    const rows = buildSaleRojmel(
      ctx as never,
      [line] as never,
      { taxAc: '00014', taxAmount: 0, partyAmount: 850 },
      false,
    );
    const party = rows.find(
      (x) => (x as never as { AC_CODE: string }).AC_CODE === '000903',
    ) as never as Record<string, unknown>;
    expect(party.IT_CODE).toBe('');
    expect(party.IT_DESC).toBe('');
    // And a money row is IT_TYPE 'A', not a metal code.
    expect(party.IT_TYPE).toBe('A');
  });
});
