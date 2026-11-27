import { round } from '@datacare/core';
import { assertBalanced, type LedgerLine, type PostInput } from '../posting/posting.js';
import { blank, rojmelLedrKey, type RojmelRow } from '../shared/rojmel.js';

/**
 * The AC_DATA legs and the ROJ_MEL_DATA rows of a TR_CASH voucher, transcribed from the desktop SQL.
 *
 * TR_CASH (cash and bank receipts and payments, all four menus) saves ONE CASH_DATA row per grid line
 * (TR_CASH.cs:3011-3069) and then rebuilds the ledger and the day book from those rows: `Ac_Ledr.Bank_Ledr` and
 * `Ac_Rojmel.Bank_Rojmel` for BANK REC / BANK PAY books, `Cash_Ledr` and `Cash_Rojmel` for every other book
 * (TR_CASH.cs:3073-3090). The functions here are pure so the shapes can be checked against the SQL without a
 * database (test/cashBankLegs.test.ts).
 *
 * Every leg joins `BOOK_DETL`: slot 1 is the cash or bank account (`B1`), slot 2 the kasar account (`B2`) and,
 * on the bank layout, slot 3 the bank-charges account (`B3`).
 */
export type CashLayout = 'cash' | 'bank';
export type CashDirection = 'receipt' | 'payment';

/** One TR_CASH grid row, already normalised (`SR_NO` is the grid's Sr column, TR_CASH.cs:3034). */
export interface CashGridRow {
  srNo: number;
  partyAc: string;
  /** CASH_DATA.AC_NAME, the grid's Ac Name cell (TR_CASH.cs:3040). */
  partyName: string;
  recAmt: number;
  kasar: number;
  /** BANK_CHARGES, the bank layout's Charges cell (TR_CASH.cs:3042). */
  charges: number;
  itDesc: string;
  chqNo: string;
  vchDate: Date;
  /** CLR_DATE: the grid's Clearing Dt cell, the voucher date when it is empty (TR_CASH.cs:3022-3029). */
  clrDate: Date;
}

export interface CashAccounts {
  /** BOOK_DETL slot 1 (or the settlement account the caller named). */
  settle: string;
  /** BOOK_DETL slot 2. Needed only when a row carries kasar. */
  kasar: string;
  /** BOOK_DETL slot 3. Needed only on the bank layout when a row carries charges. */
  charges: string;
}

export interface CashVoucherFacts {
  /** CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO of the voucher. */
  key: Record<string, unknown>;
  coBook: string;
  vchNo: string;
  layout: CashLayout;
  direction: CashDirection;
  /** BOOK_DATA.BOOK_SNAME and MAIN_BOOK (B.BOOK_SNAME, B.MAIN_BOOK) and DATA_TYPE. */
  shortName: string;
  mainBook: string;
  dataType: string;
  hiddenVoucherNo: string;
  mainUser: string;
  /** VCH_TIME. Data Refresh passes the stored text so the database casts the wall clock back unchanged. */
  voucherTime: Date | string;
  scope: { coCode: string; lcCode: string; coYear: string };
  accounts: CashAccounts;
}

type Who = 'party' | 'settle' | 'kasar' | 'charges';
interface LegSpec {
  code: string;
  /** Which column of the row must be non-zero for the leg to be written (`A.REC_AMT <> 0` ...). */
  when: 'rec' | 'kasar' | 'charges';
  ac: Who;
  ld: Who;
  side: 'CR' | 'DR';
  /** Narration: the row's own, or blank (kasar legs write ''). */
  desc: 'line' | 'none';
  /** TR_CASH.cs / Ac_Ledr.cs:567-583: only the party's own legs carry PARTY_AC_CODE. */
  partyLeg: boolean;
  /** Cash payment legs 05/06 copy SUBSTRING(A.IT_DESC,1,150) (Ac_Ledr.cs:575, :577). */
  desc150?: boolean;
}

/** Cash_Ledr, Ac_Ledr.cs:565-583. */
const CASH_LEGS: Record<CashDirection, LegSpec[]> = {
  receipt: [
    {
      code: '01',
      when: 'rec',
      ac: 'party',
      ld: 'settle',
      side: 'CR',
      desc: 'line',
      partyLeg: true,
    },
    {
      code: '02',
      when: 'rec',
      ac: 'settle',
      ld: 'party',
      side: 'DR',
      desc: 'line',
      partyLeg: false,
    },
    {
      code: '03',
      when: 'kasar',
      ac: 'party',
      ld: 'kasar',
      side: 'CR',
      desc: 'none',
      partyLeg: true,
    },
    {
      code: '04',
      when: 'kasar',
      ac: 'kasar',
      ld: 'party',
      side: 'DR',
      desc: 'none',
      partyLeg: false,
    },
  ],
  payment: [
    {
      code: '05',
      when: 'rec',
      ac: 'party',
      ld: 'settle',
      side: 'DR',
      desc: 'line',
      desc150: true,
      partyLeg: true,
    },
    {
      code: '06',
      when: 'rec',
      ac: 'settle',
      ld: 'party',
      side: 'CR',
      desc: 'line',
      desc150: true,
      partyLeg: false,
    },
    {
      code: '07',
      when: 'kasar',
      ac: 'party',
      ld: 'kasar',
      side: 'DR',
      desc: 'none',
      partyLeg: true,
    },
    {
      code: '08',
      when: 'kasar',
      ac: 'kasar',
      ld: 'party',
      side: 'CR',
      desc: 'none',
      partyLeg: false,
    },
  ],
};

/** Bank_Ledr, Ac_Ledr.cs:585-610. Legs 05/06 and 11/12 are the bank charges (`A.BANK_CHARGES <> 0`). */
const BANK_LEGS: Record<CashDirection, LegSpec[]> = {
  receipt: [
    {
      code: '01',
      when: 'rec',
      ac: 'party',
      ld: 'settle',
      side: 'CR',
      desc: 'line',
      partyLeg: true,
    },
    {
      code: '02',
      when: 'rec',
      ac: 'settle',
      ld: 'party',
      side: 'DR',
      desc: 'line',
      partyLeg: false,
    },
    {
      code: '03',
      when: 'kasar',
      ac: 'party',
      ld: 'kasar',
      side: 'CR',
      desc: 'none',
      partyLeg: true,
    },
    {
      code: '04',
      when: 'kasar',
      ac: 'kasar',
      ld: 'party',
      side: 'DR',
      desc: 'none',
      partyLeg: false,
    },
    {
      code: '05',
      when: 'charges',
      ac: 'settle',
      ld: 'party',
      side: 'CR',
      desc: 'line',
      partyLeg: false,
    },
    {
      code: '06',
      when: 'charges',
      ac: 'charges',
      ld: 'settle',
      side: 'DR',
      desc: 'line',
      partyLeg: false,
    },
  ],
  payment: [
    {
      code: '07',
      when: 'rec',
      ac: 'party',
      ld: 'settle',
      side: 'DR',
      desc: 'line',
      partyLeg: true,
    },
    {
      code: '08',
      when: 'rec',
      ac: 'settle',
      ld: 'party',
      side: 'CR',
      desc: 'line',
      partyLeg: false,
    },
    {
      code: '09',
      when: 'kasar',
      ac: 'party',
      ld: 'kasar',
      side: 'DR',
      desc: 'none',
      partyLeg: true,
    },
    {
      code: '10',
      when: 'kasar',
      ac: 'kasar',
      ld: 'party',
      side: 'CR',
      desc: 'none',
      partyLeg: false,
    },
    {
      code: '11',
      when: 'charges',
      ac: 'settle',
      ld: 'party',
      side: 'CR',
      desc: 'line',
      partyLeg: false,
    },
    {
      code: '12',
      when: 'charges',
      ac: 'charges',
      ld: 'settle',
      side: 'DR',
      desc: 'line',
      partyLeg: false,
    },
  ],
};

const amountOf = (row: CashGridRow, when: LegSpec['when']): number =>
  when === 'rec' ? row.recAmt : when === 'kasar' ? row.kasar : row.charges;

const sameDay = (a: Date, b: Date): boolean =>
  a.toISOString().slice(0, 10) === b.toISOString().slice(0, 10);

/**
 * Cash_Ledr / Bank_Ledr: the AC_DATA legs of every grid row, in row order and leg order.
 *
 * Cash layout: `VCH_DATE = A.VCH_DATE`, `CLR_DATE` null, `CHQ_NO` ''. Bank layout (Ac_Ledr.cs:587): the ledger is
 * dated on the CLEARING date and CLR_DATE carries the voucher date, `CHQ_NO = A.CHQ_NO`, and ENTRY_TIME is the
 * voucher time when both dates agree, the clearing date otherwise.
 */
export function cashLedgerLegs(facts: CashVoucherFacts, rows: CashGridRow[]): LedgerLine[] {
  const specs = (facts.layout === 'bank' ? BANK_LEGS : CASH_LEGS)[facts.direction];
  const who = (row: CashGridRow, w: Who): string =>
    w === 'party' ? row.partyAc : facts.accounts[w];
  const legs: LedgerLine[] = [];
  for (const row of rows) {
    for (const spec of specs) {
      const amount = amountOf(row, spec.when);
      if (amount === 0) continue;
      const bank = facts.layout === 'bank';
      const desc = spec.desc === 'none' ? '' : spec.desc150 ? row.itDesc.slice(0, 150) : row.itDesc;
      legs.push({
        ...facts.key,
        VCH_TYPE: facts.shortName,
        VCH_DATE: bank ? row.clrDate : row.vchDate,
        legKeySuffix: `${row.srNo}${spec.code}`.padStart(12, ' '),
        BOOK_NAME: facts.mainBook,
        CHQ_NO: bank ? row.chqNo : '',
        AC_CODE: who(row, spec.ac),
        LD_CODE: who(row, spec.ld),
        CR_AMT: spec.side === 'CR' ? amount : 0,
        DR_AMT: spec.side === 'DR' ? amount : 0,
        IT_TYPE: 'A',
        SIGN: '',
        FINE_WT: 0,
        IT_DESC: desc,
        ENTRY_TIME: bank && !sameDay(row.vchDate, row.clrDate) ? row.clrDate : facts.voucherTime,
        HD_VCH_NO: facts.hiddenVoucherNo,
        CLR_DATE: bank ? row.vchDate : null,
        DATA_TYPE: facts.dataType,
        DATA_TRFR: 'N',
        MAIN_USER: facts.mainUser || null,
        FINE_RATE: 0,
        PARTY_AC_CODE: spec.partyLeg ? row.partyAc : '',
        LDR_NAME: '',
      });
    }
  }
  return legs;
}

interface RowSpec {
  type: string;
  when: 'rec' | 'kasar' | 'charges';
  ac: Who;
  ld: Who;
  side: 'CR' | 'DR';
  /** The party's name, or 'KSR - ' + the name on a kasar row (Ac_Rojmel.cs:183, :201). */
  name: 'party' | 'kasar' | 'blank';
  /** Bank receipts credit the bank with `REC_AMT - BANK_CHARGES` (Ac_Rojmel.cs:199). */
  net?: boolean;
}

/**
 * Cash_Rojmel (Ac_Rojmel.cs:179-193): the cash book has one row for the cash movement and a pair for the kasar.
 * The cash row names the cash account in AC_CODE and the party in LD_CODE: that is how every row of books 001 and
 * 002 is stored (measured: 56/56 and 175/175 in Next24M), where the SQL text lists them the other way round.
 */
const CASH_ROWS: Record<CashDirection, RowSpec[]> = {
  receipt: [
    { type: '01', when: 'rec', ac: 'settle', ld: 'party', side: 'CR', name: 'party' },
    { type: '02', when: 'kasar', ac: 'party', ld: 'kasar', side: 'CR', name: 'kasar' },
    { type: '03', when: 'kasar', ac: 'kasar', ld: 'party', side: 'DR', name: 'kasar' },
  ],
  payment: [
    { type: '04', when: 'rec', ac: 'settle', ld: 'party', side: 'DR', name: 'party' },
    { type: '05', when: 'kasar', ac: 'party', ld: 'kasar', side: 'DR', name: 'kasar' },
    { type: '06', when: 'kasar', ac: 'kasar', ld: 'party', side: 'CR', name: 'kasar' },
  ],
};

/**
 * Bank_Rojmel (Ac_Rojmel.cs:195-219): the bank day book is a PAIR per movement (the party row and the bank row,
 * dated on the clearing date), a pair for the kasar and the bank-charges rows.
 */
const BANK_ROWS: Record<CashDirection, RowSpec[]> = {
  receipt: [
    { type: '01', when: 'rec', ac: 'party', ld: 'settle', side: 'CR', name: 'blank' },
    { type: '02', when: 'rec', ac: 'settle', ld: 'party', side: 'DR', name: 'blank', net: true },
    { type: '03', when: 'kasar', ac: 'party', ld: 'kasar', side: 'CR', name: 'kasar' },
    { type: '04', when: 'kasar', ac: 'kasar', ld: 'party', side: 'DR', name: 'kasar' },
    { type: '05', when: 'charges', ac: 'charges', ld: 'party', side: 'DR', name: 'blank' },
  ],
  payment: [
    { type: '07', when: 'rec', ac: 'party', ld: 'settle', side: 'DR', name: 'blank' },
    { type: '08', when: 'rec', ac: 'settle', ld: 'party', side: 'CR', name: 'blank' },
    { type: '09', when: 'kasar', ac: 'party', ld: 'kasar', side: 'DR', name: 'kasar' },
    { type: '10', when: 'kasar', ac: 'kasar', ld: 'party', side: 'CR', name: 'kasar' },
    { type: '11', when: 'charges', ac: 'settle', ld: 'party', side: 'CR', name: 'blank' },
    { type: '12', when: 'charges', ac: 'charges', ld: 'party', side: 'DR', name: 'blank' },
  ],
};

export function cashRojmelRows(facts: CashVoucherFacts, rows: CashGridRow[]): RojmelRow[] {
  const specs = (facts.layout === 'bank' ? BANK_ROWS : CASH_ROWS)[facts.direction];
  const who = (row: CashGridRow, w: Who): string =>
    w === 'party' ? row.partyAc : facts.accounts[w];
  const out: RojmelRow[] = [];
  for (const row of rows) {
    for (const spec of specs) {
      const amount = amountOf(row, spec.when);
      if (amount === 0) continue;
      // Ac_Rojmel.cs:199: the bank row of a receipt is `REC_AMT - A.BANK_CHARGES`.
      const value = spec.net ? round(amount - row.charges, 2) : amount;
      // LEDR_KEY = voucher + row type + STR(SR_NO) (Ac_Rojmel.cs:181 `VCH_NO+'01'+Str(A.SR_NO)`).
      const ledrKey = rojmelLedrKey(
        facts.scope,
        facts.coBook,
        facts.vchNo,
        spec.type as Parameters<typeof rojmelLedrKey>[3],
        row.srNo,
      );
      out.push({
        ...blank(
          {
            scope: facts.scope,
            key: facts.key,
            coBook: facts.coBook,
            vchNo: facts.vchNo,
            vchDate: facts.layout === 'bank' ? row.clrDate : row.vchDate,
            vchType: facts.shortName,
            bookName: facts.mainBook,
            partyName: '',
            partyCode: '',
          },
          ledrKey,
        ),
        AC_CODE: who(row, spec.ac),
        LD_CODE: who(row, spec.ld),
        CR_AMT: spec.side === 'CR' ? value : 0,
        DR_AMT: spec.side === 'DR' ? value : 0,
        AC_NAME:
          spec.name === 'party'
            ? row.partyName
            : spec.name === 'kasar'
              ? `KSR - ${row.partyName}`
              : '',
        IT_DESC: row.itDesc,
        DATA_TYPE: facts.dataType,
      });
    }
  }
  return out;
}

/**
 * The posting of one TR_CASH voucher: Cash_Ledr / Bank_Ledr legs into AC_DATA and Cash_Rojmel / Bank_Rojmel rows into
 * ROJ_MEL_DATA (Ac_Ledr.cs:565-610, Ac_Rojmel.cs:179-219), balance-checked. The writer adds its own CASH_DATA and
 * card / UPI rows in front of `writes`; Data Refresh > Account re-derives a saved voucher's postings with the same
 * call (cashBankRefresh.ts), so the two cannot drift.
 */
export function cashBankPostInput(facts: CashVoucherFacts, rows: CashGridRow[]): PostInput {
  const ledger = cashLedgerLegs(facts, rows);
  assertBalanced(ledger);
  const rojmelRows = cashRojmelRows(facts, rows);
  return {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: facts.mainBook,
    writes: rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : [],
  };
}
