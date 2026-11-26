import { describe, expect, it } from 'vitest';
import {
  cashLedgerLegs,
  cashRojmelRows,
  type CashGridRow,
  type CashVoucherFacts,
} from '../src/modules/finance/cashBankLegs.js';

/**
 * Kernel vectors for the TR_CASH ledger and day book. Every expected value is read off the desktop SQL, not off
 * the web's own output:
 *
 *   Cash_Ledr   Ac_Ledr.cs:567-581   Bank_Ledr   Ac_Ledr.cs:587-609
 *   Cash_Rojmel Ac_Rojmel.cs:181-191 Bank_Rojmel Ac_Rojmel.cs:197-217
 *
 * Synthetic accounts and amounts only.
 */
const PARTY = 'P0001';
const SETTLE = 'S0001'; // BOOK_DETL slot 1
const KASAR = 'K0002'; // slot 2
const CHARGES = 'C0003'; // slot 3
const d = (iso: string) => new Date(`${iso}T00:00:00.000Z`);
const TIME = new Date('2024-05-01T10:30:00.000Z');

const facts = (
  layout: 'cash' | 'bank',
  direction: 'receipt' | 'payment',
  mainBook: string,
  shortName: string,
): CashVoucherFacts => ({
  key: { CO_CODE: '01', LC_CODE: '00', CO_YEAR: '2024-2025', CO_BOOK: '009', VCH_NO: '00007' },
  coBook: '009',
  vchNo: '00007',
  layout,
  direction,
  shortName,
  mainBook,
  dataType: 'A',
  hiddenVoucherNo: '00004',
  mainUser: 'ADMIN',
  voucherTime: TIME,
  scope: { coCode: '01', lcCode: '00', coYear: '2024-2025' },
  accounts: { settle: SETTLE, kasar: KASAR, charges: CHARGES },
});

const row = (over: Partial<CashGridRow> = {}): CashGridRow => ({
  srNo: 1,
  partyAc: PARTY,
  partyName: 'SAMPLE PARTY',
  recAmt: 1000,
  kasar: 0,
  charges: 0,
  itDesc: '',
  chqNo: '',
  vchDate: d('2024-05-01'),
  clrDate: d('2024-05-01'),
  ...over,
});

const shape = (legs: ReturnType<typeof cashLedgerLegs>) =>
  legs.map((l) => [
    String(l.legKeySuffix).trim(),
    l.AC_CODE,
    l.LD_CODE,
    l.DR_AMT,
    l.CR_AMT,
    l.PARTY_AC_CODE,
    l.IT_DESC,
  ]);

describe('Cash_Ledr (Ac_Ledr.cs:567-581)', () => {
  it('CASH REC: 01 party Cr / 02 cash Dr, then 03 party Cr / 04 kasar Dr; only the party legs carry PARTY_AC_CODE', () => {
    const legs = cashLedgerLegs(facts('cash', 'receipt', 'CASH REC', 'CREC'), [
      row({ recAmt: 60000, kasar: 771, itDesc: 'march dues' }),
    ]);
    expect(shape(legs)).toEqual([
      // :567 A.AC_CODE,B.AC_CODE,REC_AMT,0 ... A.IT_DESC ... A.AC_CODE
      ['101', PARTY, SETTLE, 0, 60000, PARTY, 'march dues'],
      // :569 B.AC_CODE,A.AC_CODE,0,REC_AMT ... A.IT_DESC ... ''
      ['102', SETTLE, PARTY, 60000, 0, '', 'march dues'],
      // :571 kasar legs write the blank narration
      ['103', PARTY, KASAR, 0, 771, PARTY, ''],
      ['104', KASAR, PARTY, 771, 0, '', ''],
    ]);
    for (const l of legs) {
      expect(l.BOOK_NAME).toBe('CASH REC'); // B.MAIN_BOOK
      expect(l.VCH_TYPE).toBe('CREC'); // B.BOOK_SNAME
      expect(l.CLR_DATE).toBeNull(); // Null
      expect(l.CHQ_NO).toBe(''); // ''
      expect(l.VCH_DATE).toEqual(d('2024-05-01')); // A.VCH_DATE
      expect(l.LDR_NAME).toBe('');
    }
  });

  it('CASH PAY: 05 party Dr / 06 cash Cr, then 07 party Dr / 08 kasar Cr; the narration is cut at 150 characters', () => {
    const long = 'n'.repeat(200);
    const legs = cashLedgerLegs(facts('cash', 'payment', 'CASH PAY', 'CPAY'), [
      row({ recAmt: 250, kasar: 5, itDesc: long }),
    ]);
    expect(shape(legs).map((l) => l.slice(0, 6))).toEqual([
      ['105', PARTY, SETTLE, 250, 0, PARTY],
      ['106', SETTLE, PARTY, 0, 250, ''],
      ['107', PARTY, KASAR, 5, 0, PARTY],
      ['108', KASAR, PARTY, 0, 5, ''],
    ]);
    // Ac_Ledr.cs:575, :577 SUBSTRING(A.IT_DESC,1,150) on the cash payment's amount legs.
    expect(legs[0]!.IT_DESC).toBe('n'.repeat(150));
    expect(legs[1]!.IT_DESC).toBe('n'.repeat(150));
    expect(legs[2]!.IT_DESC).toBe('');
  });

  it('a CASH REC narration is not cut (Ac_Ledr.cs:567 copies A.IT_DESC whole)', () => {
    const legs = cashLedgerLegs(facts('cash', 'receipt', 'CASH REC', 'CREC'), [
      row({ itDesc: 'n'.repeat(200) }),
    ]);
    expect(String(legs[0]!.IT_DESC)).toHaveLength(200);
  });

  it('a kasar-only line writes no amount pair, and the line number leads the key (STR(SR_NO)+code)', () => {
    const legs = cashLedgerLegs(facts('cash', 'receipt', 'CASH REC', 'CREC'), [
      row({ recAmt: 1000 }),
      row({ srNo: 2, recAmt: 0, kasar: 5 }),
    ]);
    expect(legs.map((l) => String(l.legKeySuffix))).toEqual([
      '         101',
      '         102',
      '         203',
      '         204',
    ]);
  });
});

describe('Bank_Ledr (Ac_Ledr.cs:587-609)', () => {
  const bankRow = row({
    recAmt: 5000,
    kasar: 10,
    charges: 18,
    itDesc: 'neft',
    chqNo: '123456',
    vchDate: d('2024-05-01'),
    clrDate: d('2024-05-03'),
  });

  it('BANK REC: 01-06 with charges, dated on the CLEARING date; CLR_DATE carries the voucher date', () => {
    const legs = cashLedgerLegs(facts('bank', 'receipt', 'BANK REC', 'BREC'), [bankRow]);
    expect(shape(legs)).toEqual([
      ['101', PARTY, SETTLE, 0, 5000, PARTY, 'neft'],
      ['102', SETTLE, PARTY, 5000, 0, '', 'neft'],
      ['103', PARTY, KASAR, 0, 10, PARTY, ''],
      ['104', KASAR, PARTY, 10, 0, '', ''],
      // :595 B.AC_CODE,A.AC_CODE,BANK_CHARGES,0 -> the bank is credited the charges
      ['105', SETTLE, PARTY, 0, 18, '', 'neft'],
      // :597 C.AC_CODE (slot 3),B.AC_CODE,0,BANK_CHARGES
      ['106', CHARGES, SETTLE, 18, 0, '', 'neft'],
    ]);
    for (const l of legs) {
      expect(l.VCH_DATE).toEqual(d('2024-05-03')); // A.CLR_DATE
      expect(l.CLR_DATE).toEqual(d('2024-05-01')); // A.VCH_DATE
      expect(l.CHQ_NO).toBe('123456'); // A.CHQ_NO
      expect(l.ENTRY_TIME).toEqual(d('2024-05-03')); // dates differ: the clearing date
    }
  });

  it('BANK PAY: 07 party Dr / 08 bank Cr, 09/10 kasar, 11 bank Cr / 12 charges Dr', () => {
    const legs = cashLedgerLegs(facts('bank', 'payment', 'BANK PAY', 'BBPAY'), [bankRow]);
    expect(shape(legs)).toEqual([
      ['107', PARTY, SETTLE, 5000, 0, PARTY, 'neft'],
      ['108', SETTLE, PARTY, 0, 5000, '', 'neft'],
      ['109', PARTY, KASAR, 10, 0, PARTY, ''],
      ['110', KASAR, PARTY, 0, 10, '', ''],
      ['111', SETTLE, PARTY, 0, 18, '', 'neft'],
      ['112', CHARGES, SETTLE, 18, 0, '', 'neft'],
    ]);
    expect(legs[0]!.VCH_TYPE).toBe('BBPAY');
  });

  it('with the clearing date equal to the voucher date, ENTRY_TIME is the voucher time', () => {
    const legs = cashLedgerLegs(facts('bank', 'receipt', 'BANK REC', 'BREC'), [
      row({ recAmt: 100 }),
    ]);
    expect(legs[0]!.ENTRY_TIME).toEqual(TIME);
    expect(legs[0]!.VCH_DATE).toEqual(d('2024-05-01'));
    expect(legs[0]!.CLR_DATE).toEqual(d('2024-05-01'));
  });
});

const rojmel = (rows: ReturnType<typeof cashRojmelRows>) =>
  rows.map((r) => [
    String(r.LEDR_KEY).slice(21).replace(/\s+/g, ''),
    r.AC_CODE,
    r.LD_CODE,
    r.DR_AMT,
    r.CR_AMT,
    r.AC_NAME,
    r.IT_DESC,
  ]);

describe('Cash_Rojmel / Bank_Rojmel (Ac_Rojmel.cs:181-217)', () => {
  it('CASH REC day book: the cash row names the party, the kasar pair names "KSR - " + the party', () => {
    const rows = cashRojmelRows(facts('cash', 'receipt', 'CASH REC', 'CREC'), [
      row({ recAmt: 60000, kasar: 771, itDesc: 'march dues' }),
    ]);
    expect(rojmel(rows)).toEqual([
      ['011', SETTLE, PARTY, 0, 60000, 'SAMPLE PARTY', 'march dues'],
      ['021', PARTY, KASAR, 0, 771, 'KSR - SAMPLE PARTY', 'march dues'],
      ['031', KASAR, PARTY, 771, 0, 'KSR - SAMPLE PARTY', 'march dues'],
    ]);
    expect(rows[0]!.LEDR_KEY).toBe('01002024-20250090000701         1');
    expect(rows[0]!.BOOK_NAME).toBe('CASH REC');
    expect(rows[0]!.VCH_TYPE).toBe('CREC');
  });

  it('CASH PAY day book: 04 cash row Dr, 05 party Dr kasar, 06 kasar Cr', () => {
    const rows = cashRojmelRows(facts('cash', 'payment', 'CASH PAY', 'CPAY'), [
      row({ recAmt: 730, kasar: 3 }),
    ]);
    expect(rojmel(rows).map((r) => r.slice(0, 5))).toEqual([
      ['041', SETTLE, PARTY, 730, 0],
      ['051', PARTY, KASAR, 3, 0],
      ['061', KASAR, PARTY, 0, 3],
    ]);
  });

  it('BANK REC day book is a PAIR dated on the clearing date: party Cr, bank Dr net of the charges, charges Dr', () => {
    const rows = cashRojmelRows(facts('bank', 'receipt', 'BANK REC', 'BREC'), [
      row({ recAmt: 5000, kasar: 10, charges: 18, clrDate: d('2024-05-03'), itDesc: 'neft' }),
    ]);
    expect(rojmel(rows)).toEqual([
      // Ac_Rojmel.cs:197 A.AC_CODE,B.AC_CODE,REC_AMT,0,''
      ['011', PARTY, SETTLE, 0, 5000, '', 'neft'],
      // :199 B.AC_CODE,A.AC_CODE,0,REC_AMT-A.BANK_CHARGES,''
      ['021', SETTLE, PARTY, 4982, 0, '', 'neft'],
      ['031', PARTY, KASAR, 0, 10, 'KSR - SAMPLE PARTY', 'neft'],
      ['041', KASAR, PARTY, 10, 0, 'KSR - SAMPLE PARTY', 'neft'],
      // :205 B.AC_CODE (slot 3),A.AC_CODE,0,A.BANK_CHARGES,''
      ['051', CHARGES, PARTY, 18, 0, '', 'neft'],
    ]);
    for (const r of rows) expect(r.VCH_DATE).toEqual(d('2024-05-03')); // A.CLR_DATE
  });

  it('BANK PAY day book: 07 party Dr, 08 bank Cr, 09/10 kasar, 11 bank Cr charges, 12 charges Dr', () => {
    const rows = cashRojmelRows(facts('bank', 'payment', 'BANK PAY', 'BPAY'), [
      row({ recAmt: 100, charges: 18 }),
    ]);
    expect(rojmel(rows).map((r) => r.slice(0, 5))).toEqual([
      ['071', PARTY, SETTLE, 100, 0],
      ['081', SETTLE, PARTY, 0, 100],
      ['111', SETTLE, PARTY, 0, 18],
      ['121', CHARGES, PARTY, 18, 0],
    ]);
  });
});
