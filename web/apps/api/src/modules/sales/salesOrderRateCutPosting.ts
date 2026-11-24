import { round } from '@datacare/core';
import {
  ORDER_RATE_CUT_LD_CODE,
  ORDER_RATE_CUT_LEG_TYPE,
  ORDER_RATE_CUT_ONE_SIDED,
  type LedgerLine,
} from '../posting/posting.js';
import { ROJMEL_ORDER_ROW_TYPE, rojmelLedrKey, type RojmelKeyScope } from '../shared/rojmel.js';

/**
 * The rate-cut rows of a Sales Order or Tour Order, copied from the desktop. This is a ONE-SIDED entry on purpose.
 *
 * Both forms save the header and then delete and rebuild the voucher's AC_DATA and ROJ_MEL_DATA on every save
 * (`TR_SALE_ORD.cs:9558-9563`, `TR_TOUR_ORD.cs:7609-7614`); the Account Refresh rebuild runs the same routines for
 * every order (`MS_UPDATE.cs:2454-2456`). Delete removes every AC_DATA and ROJ_MEL_DATA row of the voucher
 * (`TR_SALE_ORD.cs:9729-9730`, `TR_TOUR_ORD.cs:7753-7754`).
 *
 * Ledger, `Ac_Ledr.Order_Ledr` (`Ac_Ledr.cs:53`), from SL_ORD_DATA joined to BOOK_DATA, for
 * `MAIN_BOOK IN ('SALES ORDER','TOUR ORDER') AND BOOK_INOUT = 'I' AND RCUT_FINE <> 0`:
 *
 *   VCH_TYPE BOOK_SNAME | LEDR_KEY head + '11' | BOOK_NAME MAIN_BOOK | BILL_NO '' | BILL_DATE Null | CHQ_NO ''
 *   AC_CODE the party | LD_CODE '00008' | CR_AMT 0
 *   DR_AMT CASH_AMT + CARD_AMT + CHQ_AMT + OLD_GL_AMT + OLD_SL_AMT + SCHM_AMT (UPI_AMT is not in it)
 *   IT_TYPE 'G' | SIGN '+' | FINE_WT RCUT_FINE | IT_DESC '' | ENTRY_TIME VCH_TIME | HD_VCH_NO | CLR_DATE Null
 *   DATA_TYPE BOOK_DATA.DATA_TYPE | DATA_TRFR 'N' | MAIN_USER | FINE_RATE 0 | PARTY_AC_CODE the party | LDR_NAME ''
 *
 * There is no counter-leg: Order_Ledr writes no second row for key 11, so the voucher's AC_DATA does not balance.
 * The owner's rule is that the web copies the desktop exactly, one-sided postings included, so ledgers reconcile with
 * desktop data. `postVoucherTx` leaves this one leg out of its balance check, and only this one (posting.ts).
 *
 * Day book, `Ac_Rojmel.Order_Rojmel` type 07 (`Ac_Rojmel.cs:23`), from SL_ORD_DATA joined to BOOK_DATA, for
 * `MAIN_BOOK IN ('SALES ORDER','TOUR ORDER') AND RCUT_FINE <> 0` (no BOOK_INOUT filter):
 *
 *   LEDR_KEY head + '07' | VCH_TYPE BOOK_SNAME | BOOK_NAME MAIN_BOOK | AC_CODE the party | LD_CODE '00008'
 *   CR_AMT 0 | DR_AMT the same sum | AC_NAME | IT_TYPE 'G' | SIGN '+' | ITM_PCS 0 | ITM_GWT, ITM_NWT, ITM_FINE RCUT_FINE
 *   ITM_TOUCH 0 | ITM_WEST 0 | ITM_RATE RCUT_RATE | ITM_AMT, LBR_RATE, LBR_AMT, OTH_AMT, NET_AMT 0
 *   IT_DESC VCH_DESC | IT_CODE, MEMB_CODE, SCHM_CODE, REF_NO '' | DATA_TYPE BOOK_DATA.DATA_TYPE
 *
 * Type 01 reads ADV_AMT (`Ac_Rojmel.cs:11`, `ADV_AMT <> 0`), which a rate-cut order saves as 0
 * (`TR_SALE_ORD.cs:9124-9128`, `TR_TOUR_ORD.cs:7295-7298`), so a rate-cut order has no type 01 row.
 *
 * Every value is read from the saved header row, as the desktop's INSERT ... SELECT reads SL_ORD_DATA.
 */

export interface OrderRateCutBook {
  mainBook: string;
  vchType: string;
  inoutType: string;
  /** BOOK_DATA.DATA_TYPE. */
  dataType: string;
}

const num = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));
const str = (value: unknown): string => (value == null ? '' : String(value));

/** CASH_AMT + CARD_AMT + CHQ_AMT + OLD_GL_AMT + OLD_SL_AMT + SCHM_AMT (`Ac_Ledr.cs:53`, `Ac_Rojmel.cs:23`). */
export function orderRateCutAmount(header: Record<string, unknown>): number {
  return round(
    num(header.CASH_AMT) +
      num(header.CARD_AMT) +
      num(header.CHQ_AMT) +
      num(header.OLD_GL_AMT) +
      num(header.OLD_SL_AMT) +
      num(header.SCHM_AMT),
    2,
  );
}

/** Ledger key 11 (`Ac_Ledr.cs:53`): only for a book whose BOOK_INOUT is 'I' and a non-zero RCUT_FINE. */
export function orderRateCutLedger(
  key: Record<string, unknown>,
  header: Record<string, unknown>,
  book: OrderRateCutBook,
): LedgerLine[] {
  if (book.inoutType !== 'I' || !num(header.RCUT_FINE)) return [];
  const party = str(header.AC_CODE);
  return [
    {
      ...key,
      [ORDER_RATE_CUT_ONE_SIDED]: true,
      legType: ORDER_RATE_CUT_LEG_TYPE,
      VCH_TYPE: book.vchType,
      VCH_DATE: header.VCH_DATE,
      BOOK_NAME: book.mainBook,
      BILL_NO: '',
      BILL_DATE: null,
      CHQ_NO: '',
      AC_CODE: party,
      LD_CODE: ORDER_RATE_CUT_LD_CODE,
      CR_AMT: 0,
      DR_AMT: orderRateCutAmount(header),
      IT_TYPE: 'G',
      SIGN: '+',
      FINE_WT: round(num(header.RCUT_FINE), 3),
      IT_DESC: '',
      ENTRY_TIME: header.VCH_TIME,
      HD_VCH_NO: header.HD_VCH_NO,
      CLR_DATE: null,
      DATA_TYPE: book.dataType,
      DATA_TRFR: 'N',
      MAIN_USER: header.MAIN_USER,
      FINE_RATE: 0,
      PARTY_AC_CODE: party,
      LDR_NAME: '',
    },
  ];
}

/** True for the order's rate-cut ledger leg (key 11 against '00008'), which is not a money tender leg. */
export function isOrderRateCutLedgerRow(row: Record<string, unknown>): boolean {
  return /^.{21}11$/.test(str(row.LEDR_KEY)) && str(row.LD_CODE).trim() === ORDER_RATE_CUT_LD_CODE;
}

/**
 * The order's day book as the desktop leaves it: type 01 only when ADV_AMT is not 0, and type 07 when RCUT_FINE is
 * not 0. `rows` are the other Order_Rojmel types, built beside a type 01 row whose columns they share.
 */
export function withOrderRateCutRojmel<T extends Record<string, unknown>>(
  rows: T[],
  context: {
    scope: RojmelKeyScope;
    key: Record<string, unknown>;
    coBook: string;
    vchNo: string;
  },
  header: Record<string, unknown>,
  book: OrderRateCutBook,
): Array<T | Record<string, unknown>> {
  const advanceKey = rojmelLedrKey(
    context.scope,
    context.coBook,
    context.vchNo,
    ROJMEL_ORDER_ROW_TYPE.ADVANCE,
  );
  const kept = num(header.ADV_AMT) ? rows : rows.filter((row) => row.LEDR_KEY !== advanceKey);
  const fine = num(header.RCUT_FINE);
  if (!fine) return kept;
  return [
    ...kept,
    {
      ...context.key,
      LEDR_KEY: rojmelLedrKey(
        context.scope,
        context.coBook,
        context.vchNo,
        ROJMEL_ORDER_ROW_TYPE.RATE_CUT,
      ),
      VCH_DATE: header.VCH_DATE,
      VCH_TYPE: book.vchType,
      BOOK_NAME: book.mainBook,
      AC_CODE: str(header.AC_CODE),
      LD_CODE: ORDER_RATE_CUT_LD_CODE,
      CR_AMT: 0,
      DR_AMT: orderRateCutAmount(header),
      AC_NAME: str(header.AC_NAME),
      IT_TYPE: 'G',
      SIGN: '+',
      ITM_PCS: 0,
      ITM_GWT: round(fine, 3),
      ITM_NWT: round(fine, 3),
      ITM_TOUCH: 0,
      ITM_WEST: 0,
      ITM_FINE: round(fine, 3),
      ITM_RATE: round(num(header.RCUT_RATE), 2),
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
      DATA_TYPE: book.dataType,
    },
  ];
}
