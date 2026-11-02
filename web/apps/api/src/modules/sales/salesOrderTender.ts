import { round } from '@datacare/core';
import { assertBalanced, type LedgerLine } from '../posting/posting.js';
import { buildOrderRojmel, type RojmelContext } from '../shared/rojmel.js';
import {
  oldMetalAdvance,
  oldMetalHeader,
  orderOldMetalLedger,
  orderOldMetalOf,
  orderOldMetalRojmel,
  orderOldMetalView,
  type OrderOldMetalRow,
} from './salesOrderOldMetal.js';
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
 * G206 (UPI): the UPI grid MSG_UPI (AcCode, Upi Bank Name, UpiType, Upi Id, UpiAmt). Its total is UPI_AMT
 * (TotAmt, `:3698-3711`: rows with an account and a non-zero amount), each such row is a UPI_DATA row with SR_NO its
 * grid line (`:9520-9556`), Order_Ledr posts legs 12/13 + STR(SR_NO) per row (`Ac_Ledr.cs:55-57`) and Order_Rojmel
 * type 08 + STR(SR_NO) (`Ac_Rojmel.cs:25`).
 *
 * N226 (G206): old gold and old silver are the grid MSG_OLD (`salesOrderOldMetal.ts`). Their amounts join ADV_AMT
 * (`:11368`) and the header's OLD_GL* columns come from the grid, so the request cannot set them. The scheme tender is
 * not taken by this screen yet.
 */
export interface OrderUpiRow {
  srNo: number;
  upiAc: string;
  /** Upi Bank Name: the account's AC_MAST name, filled in the writer's transaction. */
  upiName: string;
  upiType: string;
  upiId: string;
  amount: number;
}

export interface OrderTender {
  cash: number;
  cheque: number;
  card: number;
  bankAc: string;
  chequeNo: string;
  cardAc: string;
  /** The UPI tender (the sum of `upiRows`), part of ADV_AMT and posted. */
  upi: number;
  upiRows: OrderUpiRow[];
  /** UPI_AMT as stored: the UPI tender on a Sales Order; the request's value on a Tour Order, as before. */
  upiColumn: number;
  /** The saved old gold and old silver grid rows (a Sales Order only), part of ADV_AMT. */
  oldMetal: OrderOldMetalRow[];
  /** The request carried the grid (the screen always does). Without it the header totals pass through as before. */
  oldMetalSent: boolean;
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
const cell = (value: unknown, field: string, line: number, max: number): string => {
  const out = text(value);
  if (out.length > max)
    throw new SaleValidationError(`${field} on UPI line ${line} is longer than ${max} characters`);
  return out;
};

export const UPI_NEEDS_ROWS =
  'Enter the UPI amount in the UPI rows (account, type, id and amount).';

/** The request's UPI grid; only rows with an account and a non-zero amount count (TotAmt, `:3698-3711`). */
function orderUpiRowsOf(value: unknown): OrderUpiRow[] {
  if (value == null) return [];
  if (!Array.isArray(value) || value.length > 50)
    throw new SaleValidationError('upiRows must be a list of at most 50 rows');
  return value.flatMap((raw, index): OrderUpiRow[] => {
    const row = (raw ?? {}) as Record<string, unknown>;
    const srNo = index + 1;
    const upiAc = cell(row.upiAc, 'AcCode', srNo, 8);
    const upiType = cell(row.upiType, 'UpiType', srNo, 25);
    const upiId = cell(row.upiId, 'Upi Id', srNo, 25);
    const value = amount(row.amount, `UPI amount on line ${srNo}`);
    return upiAc && value ? [{ srNo, upiAc, upiName: '', upiType, upiId, amount: value }] : [];
  });
}

/** N197: on a Sales Order the screen's advance is the cash tender, so it maps to CASH_AMT, not ADV_AMT. */
export function orderHeaderFields(
  fields: Record<string, string>,
  salesOrder: boolean,
  oldMetalSent = false,
): Record<string, string> {
  if (!salesOrder) return fields;
  const withCash = { ...fields, advanceAmount: 'CASH_AMT' };
  if (!oldMetalSent) return withCash;
  // The old gold and old silver totals are the grid's (BILL_TOTAL), so a request that carries it cannot set them.
  const { oldGoldFine, oldGoldAmount, oldSilverFine, oldSilverAmount, ...rest } = fields;
  void [oldGoldFine, oldGoldAmount, oldSilverFine, oldSilverAmount];
  return { ...rest, advanceAmount: 'CASH_AMT' };
}

const num = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));

/**
 * The reopened order's tenders. The cash leg is leg type 02; an order saved before N197 (and every Tour Order) has
 * one debit leg, and its ADV_AMT holds the cash advance.
 */
export function orderTenderView(
  header: Record<string, any>,
  saved: {
    AC_DATA: Array<Record<string, any>>;
    UPI_DATA: Array<Record<string, any>>;
    SL_PR_DETL?: Array<Record<string, any>>;
  },
  salesOrder: boolean,
) {
  const ledger = saved.AC_DATA;
  const tendered =
    salesOrder &&
    !!(
      num(header.CASH_AMT) ||
      num(header.CHQ_AMT) ||
      num(header.CARD_AMT) ||
      num(header.UPI_AMT) ||
      // An order whose only tender is old metal keeps its cash at CASH_AMT = 0; ADV_AMT is the metal's value.
      saved.SL_PR_DETL?.length
    );
  // A tendered order names its cash account on leg 02 only; a cheque or card leg is never the cash account.
  const cashLeg = tendered
    ? ledger.find((row) => /^.{21}02$/.test(String(row.LEDR_KEY ?? '')) && num(row.DR_AMT) > 0)
    : ledger.find((row) => num(row.DR_AMT) > 0);
  return {
    tendered,
    cashAc: String(cashLeg?.AC_CODE ?? '').trim() || undefined,
    fields: {
      advanceAmount: tendered ? num(header.CASH_AMT) : num(header.ADV_AMT),
      ...(salesOrder
        ? {
            chequeAmount: num(header.CHQ_AMT),
            cardAmount: num(header.CARD_AMT),
            oldMetalRows: orderOldMetalView(saved.SL_PR_DETL ?? []),
            upiRows: [...saved.UPI_DATA]
              .sort((a, b) => num(a.SR_NO) - num(b.SR_NO))
              .map((row) => ({
                srNo: num(row.SR_NO),
                upiAc: text(row.UPI_AC_CODE),
                upiName: text(row.UPI_AC_NAME),
                upiType: text(row.UPI_TYPE),
                upiId: text(row.UPI_ID),
                amount: num(row.UPI_AMT),
              })),
          }
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
  const { upiAmount, upiRows, oldMetalRows, bankAc, chequeNo, bankName, cardAc, cardAdj } = body;
  const { chequeAmount, cardAmount } = body;
  return {
    upiAmount,
    upiRows,
    oldMetalRows,
    bankAc,
    chequeNo,
    bankName,
    cardAc,
    cardAdj,
    chequeAmount,
    cardAmount,
  };
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
    upiAmount?: unknown;
    upiRows?: unknown;
    oldMetalRows?: unknown;
  },
  salesOrder = true,
): OrderTender {
  // A Sales Order's UPI_AMT is the total of its UPI rows; a bare amount has no account to post to.
  if (salesOrder && input.upiRows === undefined && num(input.upiAmount))
    throw new SaleValidationError(UPI_NEEDS_ROWS);
  const upiRows = salesOrder ? orderUpiRowsOf(input.upiRows) : [];
  const upi = round(
    upiRows.reduce((sum, row) => sum + row.amount, 0),
    2,
  );
  const tender = {
    cash: amount(input.advanceAmount, 'advanceAmount'),
    cheque: salesOrder ? amount(input.chequeAmount, 'chequeAmount') : 0,
    card: salesOrder ? amount(input.cardAmount, 'cardAmount') : 0,
    bankAc: text(input.bankAc),
    chequeNo: text(input.chequeNo),
    cardAc: text(input.cardAc),
    upi,
    upiRows,
    upiColumn: salesOrder ? upi : round(num(input.upiAmount), 2),
    oldMetal: salesOrder ? orderOldMetalOf(input.oldMetalRows) : [],
    oldMetalSent: salesOrder && input.oldMetalRows !== undefined,
  };
  if (tender.cheque && !tender.bankAc) throw new SaleValidationError(CHEQUE_NEEDS_BANK);
  if (tender.card && !tender.cardAc) throw new SaleValidationError(CARD_NEEDS_ACCOUNT);
  return tender;
}

/** ADV_AMT: the sum of the tenders taken here (`TR_SALE_ORD.cs:11368`), old gold and old silver included. */
export function orderAdvanceTotal(tender: OrderTender): number {
  return round(
    tender.cash + tender.cheque + tender.card + tender.upi + oldMetalAdvance(tender.oldMetal),
    2,
  );
}

/** OLD_GL, OLD_GL_AMT, OLD_SL and OLD_SL_AMT from the grid (`:9136-9144`); a Tour Order writes the request's. */
export function orderOldMetalColumns(tender: OrderTender, salesOrder = true) {
  return salesOrder && tender.oldMetalSent ? oldMetalHeader(tender.oldMetal) : {};
}

/** The header's tender columns (`TR_SALE_ORD.cs:9131-9150`); the Tour Order writes ADV_AMT alone, as before. */
export function orderTenderColumns(tender: OrderTender, salesOrder = true) {
  if (!salesOrder) return { ADV_AMT: orderAdvanceTotal(tender), UPI_AMT: tender.upiColumn };
  return {
    CASH_AMT: tender.cash,
    CHQ_AMT: tender.cheque,
    CARD_AMT: tender.card,
    UPI_AMT: tender.upiColumn,
    ADV_AMT: orderAdvanceTotal(tender),
  };
}

/** Order_Ledr's tender legs (`Ac_Ledr.cs:28-47`, `:55-57`), balanced, with the desktop leg types. */
export function orderTenderLedger(
  key: Record<string, unknown>,
  vchType: string,
  party: { code: string; name?: string; billNo?: string },
  cashAc: string,
  tender: OrderTender,
  salesOrder = true,
  bookInout = '',
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
  const pair = (
    value: number,
    account: string,
    label: string,
    debitLeg: number,
    chqNo = '',
    line?: number,
  ) => {
    if (!value) return;
    const base = {
      ...key,
      VCH_TYPE: vchType,
      BILL_NO: party.billNo ?? '',
      PARTY_AC_CODE: party.code,
      ...(chqNo ? { CHQ_NO: chqNo } : {}),
      // The UPI legs carry their grid line after the leg type: '12' / '13' + STR(SR_NO).
      ...(line ? { legLine: line } : {}),
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
  for (const row of tender.upiRows) pair(row.amount, row.upiAc, 'UPI', 13, '', row.srNo);
  if (legs.length) assertBalanced(legs);
  // Old metal legs 07-10 post only for a book whose BOOK_INOUT is 'I' (Ac_Ledr.cs:42-50); see salesOrderOldMetal.ts.
  return [...legs, ...orderOldMetalLedger(key, vchType, party.code, tender.oldMetal, bookInout)];
}

/**
 * Order_Rojmel types 03 and 08 (Ac_Rojmel.cs:16, :25). The shared builder writes types 01 and 02. Type 03 DEBITS the
 * card account against the party; type 08 DEBITS each UPI row's account, keyed 08 + STR(SR_NO). Both are the advance
 * row's columns with the tender's account, the party as LD_CODE and no AC_NAME.
 */
export function withTenderRojmel<T extends Record<string, unknown>>(
  rows: T[],
  partyAc: string,
  tender: OrderTender,
): T[] {
  const advance = rows.find((row) => /^.{21}01$/.test(String(row.LEDR_KEY ?? '')));
  if (!advance) return rows;
  const head = String(advance.LEDR_KEY).slice(0, -2);
  const debit = (key: string, account: string, value: number): T => ({
    ...advance,
    LEDR_KEY: key,
    AC_CODE: account,
    LD_CODE: partyAc,
    CR_AMT: 0,
    DR_AMT: value,
    AC_NAME: '',
  });
  return [
    ...rows,
    ...(tender.card ? [debit(`${head}03`, tender.cardAc, tender.card)] : []),
    ...tender.upiRows.map((row) =>
      debit(`${head}08${String(row.srNo).padStart(10)}`, row.upiAc, row.amount),
    ),
  ];
}

/**
 * The UPI rows' accounts and ids, in the writer's transaction (TEXT_UPI_KeyDown, `TR_SALE_ORD.cs:3814-3925`). The
 * account must be in AC_MAST, whose name is the row's Upi Bank Name. On a new order an Upi Id already in UPI_DATA for
 * the company and location is refused with the desktop text. The desktop checks the id as it is typed; the web checks
 * the rows it saves.
 */
export async function resolveOrderUpiTx(
  tx: any,
  scope: { tenantId: string; coCode: string; lcCode: string },
  tender: OrderTender,
  isNew: boolean,
): Promise<void> {
  for (const row of tender.upiRows) {
    const [account] = await tx.$queryRawUnsafe(
      `SELECT btrim("AC_NAME"::text) AS name FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND btrim("AC_CODE"::text)=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      row.upiAc,
    );
    if (!account)
      throw new SaleValidationError(
        `UPI account ${row.upiAc} on line ${row.srNo} is not in the account master`,
      );
    row.upiName = String(account.name ?? '').slice(0, 50);
    if (!isNew || !row.upiId) continue;
    const [used] = await tx.$queryRawUnsafe(
      `SELECT btrim("CO_BOOK"::text) AS book, btrim("VCH_NO"::text) AS vch FROM "UPI_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND btrim("UPI_ID"::text)=$4
        ORDER BY "CO_YEAR","CO_BOOK","VCH_NO" LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      row.upiId,
    );
    if (used)
      throw new SaleValidationError(
        `This UpiId already Exist In Book No =  ${used.book} AND VchNo = ${used.vch} Please Change Upi Id ...`,
      );
  }
}

/** UPI_DATA (`TR_SALE_ORD.cs:9520-9556`): one row per UPI row; ISR_NO is the web's split key, 1 here. */
export function orderUpiWrites(
  key: Record<string, unknown>,
  partyAc: string,
  vchDate: Date,
  tender: OrderTender,
) {
  if (!tender.upiRows.length) return [];
  const rows = tender.upiRows.map((row) => ({
    ...key,
    SR_NO: row.srNo,
    ISR_NO: 1,
    AC_CODE: partyAc,
    VCH_DATE: vchDate,
    VCH_TIME: vchDate,
    UPI_AC_CODE: row.upiAc,
    UPI_AC_NAME: row.upiName,
    UPI_TYPE: row.upiType,
    UPI_ID: row.upiId,
    UPI_AMT: row.amount,
  }));
  return [{ table: 'UPI_DATA', rows }];
}

/** An edit rewrites UPI_DATA, so an order with UPI rows must send them; omission never deletes them. */
export function assertUpiRowsSent(saved: readonly unknown[], input: { upiRows?: unknown }): void {
  if (saved.length && input.upiRows === undefined)
    throw new SaleValidationError(
      'This order has UPI rows. Reload it and submit its UPI rows before editing.',
    );
}

/**
 * The order's whole day book. Slot 1 is the book's advance contra: `cashAc` is what the ledger already debits for the
 * advance, which is the same account the desktop names in LD_CODE. Type 01 credits ADV_AMT, 02 debits the cheque's
 * bank, 03 the card (Ac_Rojmel.cs:11-16), 04/06 each old metal row (:17-21) and 08 each UPI row (:25). Not written:
 * type 07 rate-cut fine (RCUT_FINE 0 of 76 orders) and type 05 scheme (an unresolved ANOMALY: SCHM_AMT is non-zero on
 * 7 of 76 orders yet there are ZERO type-05 rows; docs/PLAN-SALESORDER-ROJMEL.md section 2.4).
 */
export function orderRojmelRows(
  context: RojmelContext,
  cashAc: string,
  advance: number,
  tender: OrderTender,
) {
  return withTenderRojmel(
    buildOrderRojmel(context, {
      advanceContraAc: cashAc,
      bankAc: tender.bankAc,
      advanceAmount: advance,
      chequeAmount: tender.cheque,
      oldMetal: orderOldMetalRojmel(tender.oldMetal),
    }),
    context.partyCode,
    tender,
  );
}
