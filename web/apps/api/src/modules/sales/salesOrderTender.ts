import { round } from '@datacare/core';
import { assertBalanced, type LedgerLine } from '../posting/posting.js';
import { SaleValidationError } from './sales.js';

/**
 * N197 (G206): the Sales Order's money tenders, as TR_SALE_ORD stores them and Order_Ledr posts them.
 *
 * - Header (`TR_SALE_ORD.cs:9131-9150`): CASH_AMT, CHQ_AMT with BANK_AC and CHQ_NO, CARD_AMT with CARD_AC. ADV_AMT is
 *   the sum of the tenders (`:11368`).
 * - A cheque amount needs its bank account and a card amount its card account (`:8988-8996`).
 * - Order_Ledr (`Ac_Ledr.cs:28-47`) posts each tender as a pair keyed by its leg type: 01 party CR / 02 slot-1 account
 *   DR for the cash, 03 party CR / 04 bank DR for the cheque, 05 party CR / 06 card account DR for the card. The
 *   party legs name the tender ('CASH - ', 'BANK - ', 'CARD - ' + party name); cheque and card legs carry CHQ_NO;
 *   every leg carries the order's BILL_NO and the party as PARTY_AC_CODE.
 *
 * UPI, old metal and scheme tenders are not taken by this screen yet.
 */
export interface OrderTender {
  cash: number;
  cheque: number;
  card: number;
  bankAc: string;
  chequeNo: string;
  cardAc: string;
}

export const CHEQUE_NEEDS_BANK =
  'Please Select Bank Account And Try Because Chq Rec Amt <> 0......';
export const CARD_NEEDS_ACCOUNT =
  'Please Select Card Bank Account And Try Because Card Amt <> 0......';

const amount = (value: unknown, field: string): number => {
  const n = value == null || value === '' ? 0 : Number(value);
  if (!Number.isFinite(n) || n < 0)
    throw new SaleValidationError(`${field} must be a non-negative number`);
  return round(n, 2);
};
const text = (value: unknown): string => String(value ?? '').trim();

/** N197: on a Sales Order the screen's advance is the cash tender, so it maps to CASH_AMT, not ADV_AMT. */
export function orderHeaderFields(
  fields: Record<string, string>,
  salesOrder: boolean,
): Record<string, string> {
  return salesOrder ? { ...fields, advanceAmount: 'CASH_AMT' } : fields;
}

const num = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));

/**
 * The reopened order's tenders. The cash leg is leg type 02; an order saved before N197 (and every Tour Order) has
 * one debit leg, and its ADV_AMT holds the cash advance.
 */
export function orderTenderView(
  header: Record<string, any>,
  ledger: Array<Record<string, any>>,
  salesOrder: boolean,
) {
  const tendered =
    salesOrder && !!(num(header.CASH_AMT) || num(header.CHQ_AMT) || num(header.CARD_AMT));
  // A tendered order names its cash account on leg 02 only; a cheque or card leg is never the cash account.
  const cashLeg = tendered
    ? ledger.find((row) => String(row.LEDR_KEY ?? '').endsWith('02') && num(row.DR_AMT) > 0)
    : ledger.find((row) => num(row.DR_AMT) > 0);
  return {
    tendered,
    cashAc: String(cashLeg?.AC_CODE ?? '').trim() || undefined,
    fields: {
      advanceAmount: tendered ? num(header.CASH_AMT) : num(header.ADV_AMT),
      ...(salesOrder
        ? { chequeAmount: num(header.CHQ_AMT), cardAmount: num(header.CARD_AMT) }
        : {}),
    },
    /** The column each reopened tender field keeps its exact saved decimal from. */
    exactFields: (tendered || !salesOrder ? {} : { advanceAmount: 'ADV_AMT' }) as Record<
      string,
      string
    >,
  };
}

/** The request's tender fields as the HTTP route hands them to the writer. */
export function orderTenderRequest(body: Record<string, any>) {
  const { upiAmount, bankAc, chequeNo, bankName, cardAc, cardAdj, chequeAmount, cardAmount } = body;
  return { upiAmount, bankAc, chequeNo, bankName, cardAc, cardAdj, chequeAmount, cardAmount };
}

/**
 * The order's tenders from the request; `advanceAmount` is the cash tender. The Tour Order (TR_TOUR_ORD) is its own
 * desktop form and keeps the previous single cash advance, so `salesOrder` false ignores cheque and card.
 */
export function orderTenderOf(
  input: {
    advanceAmount?: unknown;
    chequeAmount?: unknown;
    cardAmount?: unknown;
    bankAc?: unknown;
    chequeNo?: unknown;
    cardAc?: unknown;
  },
  salesOrder = true,
): OrderTender {
  const tender = {
    cash: amount(input.advanceAmount, 'advanceAmount'),
    cheque: salesOrder ? amount(input.chequeAmount, 'chequeAmount') : 0,
    card: salesOrder ? amount(input.cardAmount, 'cardAmount') : 0,
    bankAc: text(input.bankAc),
    chequeNo: text(input.chequeNo),
    cardAc: text(input.cardAc),
  };
  if (tender.cheque && !tender.bankAc) throw new SaleValidationError(CHEQUE_NEEDS_BANK);
  if (tender.card && !tender.cardAc) throw new SaleValidationError(CARD_NEEDS_ACCOUNT);
  return tender;
}

/** ADV_AMT: the sum of the tenders (`TR_SALE_ORD.cs:11368`). */
export function orderAdvanceTotal(tender: OrderTender): number {
  return round(tender.cash + tender.cheque + tender.card, 2);
}

/** The header's tender columns (`TR_SALE_ORD.cs:9131-9150`); the Tour Order writes ADV_AMT alone, as before. */
export function orderTenderColumns(tender: OrderTender, salesOrder = true) {
  if (!salesOrder) return { ADV_AMT: orderAdvanceTotal(tender) };
  return {
    CASH_AMT: tender.cash,
    CHQ_AMT: tender.cheque,
    CARD_AMT: tender.card,
    ADV_AMT: orderAdvanceTotal(tender),
  };
}

/** Order_Ledr's tender legs (`Ac_Ledr.cs:28-47`), balanced, with the desktop leg types. */
export function orderTenderLedger(
  key: Record<string, unknown>,
  vchType: string,
  party: { code: string; name?: string; billNo?: string },
  cashAc: string,
  tender: OrderTender,
  salesOrder = true,
): LedgerLine[] {
  if (!salesOrder) {
    // The Tour Order keeps its previous two legs: Dr the cash account, Cr the customer.
    const cash = tender.cash;
    if (!cash) return [];
    const legacy: LedgerLine[] = [
      { ...key, VCH_TYPE: vchType, AC_CODE: cashAc, DR_AMT: cash, CR_AMT: 0, SIGN: 'D' },
      { ...key, VCH_TYPE: vchType, AC_CODE: party.code, DR_AMT: 0, CR_AMT: cash, SIGN: 'C' },
    ];
    assertBalanced(legacy);
    return legacy;
  }
  const legs: LedgerLine[] = [];
  const pair = (value: number, account: string, label: string, debitLeg: number, chqNo = '') => {
    if (!value) return;
    const base = {
      ...key,
      VCH_TYPE: vchType,
      BILL_NO: party.billNo ?? '',
      PARTY_AC_CODE: party.code,
      ...(chqNo ? { CHQ_NO: chqNo } : {}),
    };
    legs.push({
      ...base,
      AC_CODE: party.code,
      LD_CODE: account,
      DR_AMT: 0,
      CR_AMT: value,
      SIGN: 'C',
      LDR_NAME: `${label} - ${party.name ?? ''}`.trim(),
      legType: debitLeg - 1,
    });
    legs.push({
      ...base,
      AC_CODE: account,
      LD_CODE: party.code,
      DR_AMT: value,
      CR_AMT: 0,
      SIGN: 'D',
      legType: debitLeg,
    });
  };
  pair(tender.cash, cashAc, 'CASH', 2);
  pair(tender.cheque, tender.bankAc, 'BANK', 4, tender.chequeNo);
  pair(tender.card, tender.cardAc, 'CARD', 6, tender.chequeNo);
  if (legs.length) assertBalanced(legs);
  return legs;
}

/**
 * Order_Rojmel type 03 (Ac_Rojmel.cs:16): the card tender DEBITS the card account against the party. The shared
 * builder writes types 01 and 02; type 03 is the same 23-character header-row key with the leg type 03 and the same
 * columns as the advance row, with the card account, the party as LD_CODE and no AC_NAME.
 */
export function withCardRojmel<T extends Record<string, unknown>>(
  rows: T[],
  partyAc: string,
  tender: OrderTender,
): T[] {
  const advance = tender.card
    ? rows.find((row) => String(row.LEDR_KEY ?? '').endsWith('01'))
    : null;
  if (!advance) return rows;
  const key = String(advance.LEDR_KEY);
  return [
    ...rows,
    {
      ...advance,
      LEDR_KEY: `${key.slice(0, -2)}03`,
      AC_CODE: tender.cardAc,
      LD_CODE: partyAc,
      CR_AMT: 0,
      DR_AMT: tender.card,
      AC_NAME: '',
    },
  ];
}
