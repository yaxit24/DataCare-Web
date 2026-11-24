import { round } from '@datacare/core';
import type { LedgerLine } from '../posting/posting.js';
import { rojmelLedrKey, type RojmelKeyScope } from '../shared/rojmel.js';

/**
 * The money rows of a Sales Order or Tour Order, built from the saved header row as the desktop's
 * `INSERT ... SELECT` statements read SL_ORD_DATA. Both forms call the same routines after every save
 * (`TR_SALE_ORD.cs:9558-9563`, `TR_TOUR_ORD.cs:7609-7614`).
 *
 * Ledger, `Ac_Ledr.Order_Ledr` (`Ac_Ledr.cs:30-40`, `:55-57`). Legs 01-06 join BOOK_DETL slot 1 (`B.SR_NO = 1`), which
 * gives VCH_TYPE (BOOK_SNAME), BOOK_NAME (MAIN_BOOK), DATA_TYPE and the cash account; every leg carries BILL_NO,
 * BILL_DATE Null, IT_TYPE 'A', SIGN '', FINE_WT 0, IT_DESC '', ENTRY_TIME VCH_TIME, HD_VCH_NO, CLR_DATE Null,
 * DATA_TRFR 'N', MAIN_USER, FINE_RATE 0 and PARTY_AC_CODE the party:
 *
 *   01 party Cr CASH_AMT, LD slot-1 account, LDR_NAME 'CASH - ' + AC_NAME   02 slot-1 account Dr, LD party
 *   03 party Cr CHQ_AMT, LD BANK_AC, CHQ_NO, 'BANK - ' + AC_NAME            04 BANK_AC Dr, LD party, CHQ_NO
 *   05 party Cr CARD_AMT, LD CARD_AC, CHQ_NO, 'CARD - ' + AC_NAME           06 CARD_AC Dr, LD party, CHQ_NO
 *      (05/06 only when CARD_ADJ <> 'Y': a card adjusted against commission posts elsewhere)
 *   12 + STR(SR_NO) party Cr UPI_AMT, LD the UPI account, 'UPI - ' + AC_NAME 13 + STR(SR_NO) UPI account Dr, LD party
 *      (SALES ORDER only; BOOK_DATA, not the slot, gives VCH_TYPE, BOOK_NAME and DATA_TYPE; CHQ_NO '')
 *
 * Day book, `Ac_Rojmel.Order_Rojmel` (`Ac_Rojmel.cs:11-25`), the header rows. 01-05 join BOOK_DETL slot 1; IT_DESC is
 * the order's VCH_DESC on every one of them:
 *
 *   01 ADV_AMT <> 0: party, LD slot-1 account, CR ADV_AMT, AC_NAME
 *   02 CHQ_AMT <> 0: BANK_AC, LD party, DR CHQ_AMT, AC_NAME ''
 *   03 CARD_AMT <> 0 AND CARD_ADJ <> 'Y': CARD_AC, LD party, DR CARD_AMT, AC_NAME ''
 *   05 SCHM_AMT <> 0: the scheme account, LD party, DR SCHM_AMT, AC_NAME 'MADJ - ' + AC_NAME
 *   08 + STR(SR_NO) per UPI row: the UPI account, LD party, DR UPI_AMT, AC_NAME '' (BOOK_DATA)
 *
 * Types 04/06 (old metal) and 07 (rate cut) are built beside these (`buildOrderRojmel`, salesOrderRateCutPosting.ts).
 */

/** BOOK_DETL slot 1 of the order book, with its account (the cash account) and its own book columns. */
export interface OrderSlot {
  account: string;
  vchType: string;
  mainBook: string;
  dataType: string;
}

/** BOOK_DATA of the order book. */
export interface OrderBookColumns {
  mainBook: string;
  vchType: string;
  dataType: string;
}

export interface OrderUpiPosting {
  srNo: number;
  upiAc: string;
  amount: number;
}

type Row = Record<string, unknown>;
const num = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));
const str = (value: unknown): string => (value == null ? '' : String(value));
/** `A.CARD_ADJ <> 'Y'`: the card tender posts here unless it is adjusted against commission. */
const cardPosts = (header: Row): boolean => str(header.CARD_ADJ).trim() !== 'Y';

export function orderMoneyLedger(
  key: Row,
  header: Row,
  slot: OrderSlot,
  book: OrderBookColumns,
  upiRows: readonly OrderUpiPosting[],
): LedgerLine[] {
  const party = str(header.AC_CODE);
  const name = str(header.AC_NAME);
  const common = {
    ...key,
    VCH_DATE: header.VCH_DATE,
    BILL_NO: header.BILL_NO,
    BILL_DATE: null,
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: 0,
    IT_DESC: '',
    ENTRY_TIME: header.VCH_TIME,
    HD_VCH_NO: header.HD_VCH_NO,
    CLR_DATE: null,
    DATA_TRFR: 'N',
    MAIN_USER: header.MAIN_USER,
    FINE_RATE: 0,
    PARTY_AC_CODE: party,
  };
  const fromSlot = { VCH_TYPE: slot.vchType, BOOK_NAME: slot.mainBook, DATA_TYPE: slot.dataType };
  const legs: LedgerLine[] = [];
  const pair = (
    amount: number,
    account: string,
    label: string,
    creditLeg: number,
    chqNo: unknown,
    columns: Row,
    line?: number,
  ) => {
    if (!amount) return;
    const shared = { ...common, ...columns, CHQ_NO: chqNo, ...(line ? { legLine: line } : {}) };
    legs.push(
      {
        ...shared,
        legType: creditLeg,
        AC_CODE: party,
        LD_CODE: account,
        CR_AMT: amount,
        DR_AMT: 0,
        LDR_NAME: `${label} - ${name}`,
      },
      {
        ...shared,
        legType: creditLeg + 1,
        AC_CODE: account,
        LD_CODE: party,
        CR_AMT: 0,
        DR_AMT: amount,
        LDR_NAME: '',
      },
    );
  };
  pair(num(header.CASH_AMT), slot.account, 'CASH', 1, '', fromSlot);
  pair(num(header.CHQ_AMT), str(header.BANK_AC), 'BANK', 3, header.CHQ_NO, fromSlot);
  if (cardPosts(header))
    pair(num(header.CARD_AMT), str(header.CARD_AC), 'CARD', 5, header.CHQ_NO, fromSlot);
  if (book.mainBook === 'SALES ORDER')
    for (const row of upiRows)
      pair(
        row.amount,
        row.upiAc,
        'UPI',
        12,
        '',
        {
          VCH_TYPE: book.vchType,
          BOOK_NAME: book.mainBook,
          DATA_TYPE: book.dataType,
        },
        row.srNo,
      );
  return legs;
}

/** Ac_Rojmel.cs:11-25 types 01, 02, 03, 05 and 08 from the saved header (see the module comment). */
export function orderHeaderRojmel(
  context: { scope: RojmelKeyScope; key: Row; coBook: string; vchNo: string },
  header: Row,
  slot: OrderSlot,
  book: OrderBookColumns,
  upiRows: readonly OrderUpiPosting[],
  schemeAc: string,
): Row[] {
  const party = str(header.AC_CODE);
  const keyOf = (type: string, line?: number) =>
    rojmelLedrKey(context.scope, context.coBook, context.vchNo, type as '01', line);
  const row = (
    ledrKey: string,
    columns: Row,
    from: { vchType: string; mainBook: string; dataType: string },
  ) => ({
    ...context.key,
    LEDR_KEY: ledrKey,
    VCH_DATE: header.VCH_DATE,
    VCH_TYPE: from.vchType,
    BOOK_NAME: from.mainBook,
    AC_CODE: '',
    LD_CODE: party,
    CR_AMT: 0,
    DR_AMT: 0,
    AC_NAME: '',
    IT_TYPE: 'A',
    SIGN: '',
    ITM_PCS: 0,
    ITM_GWT: 0,
    ITM_NWT: 0,
    ITM_TOUCH: 0,
    ITM_WEST: 0,
    ITM_FINE: 0,
    ITM_RATE: 0,
    ITM_AMT: 0,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    NET_AMT: 0,
    IT_DESC: str(header.VCH_DESC),
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: from.dataType,
    ...columns,
  });
  const rows: Row[] = [];
  const advance = num(header.ADV_AMT);
  if (advance)
    rows.push(
      row(
        keyOf('01'),
        {
          AC_CODE: party,
          LD_CODE: slot.account,
          CR_AMT: advance,
          AC_NAME: str(header.AC_NAME),
        },
        slot,
      ),
    );
  const cheque = num(header.CHQ_AMT);
  if (cheque) rows.push(row(keyOf('02'), { AC_CODE: str(header.BANK_AC), DR_AMT: cheque }, slot));
  const card = num(header.CARD_AMT);
  if (card && cardPosts(header))
    rows.push(row(keyOf('03'), { AC_CODE: str(header.CARD_AC), DR_AMT: card }, slot));
  const scheme = num(header.SCHM_AMT);
  if (scheme && schemeAc)
    rows.push(
      row(
        keyOf('05'),
        {
          AC_CODE: schemeAc,
          DR_AMT: scheme,
          AC_NAME: `MADJ - ${str(header.AC_NAME)}`,
        },
        slot,
      ),
    );
  for (const upi of upiRows)
    rows.push(
      row(keyOf('08', upi.srNo), { AC_CODE: upi.upiAc, DR_AMT: round(upi.amount, 2) }, book),
    );
  return rows;
}
