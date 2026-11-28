import { round } from '@datacare/core';
import { SessionCommandError } from '../auth/sessionContextCommand.js';
import { insertRowTx } from '../posting/posting.js';

/**
 * Owner decision 3B (2026-11-27): a sale may adjust an order advance when the order belongs to another customer, or
 * when it adjusts more than the order's open advance, as the desktop allows, but only after the operator confirms
 * exactly that situation.
 *
 * The desktop (TR_SALE.cs:7206-7311, help query :7229) lists every open order of the location in the Order No help, of any party (a
 * party filter exists for one licence only, :7229), copies the order's AC_CODE into the row (col 6 -> ORD_AC_CODE) and
 * refuses a larger amount only on the last grid row and only when the help filled the open figure (col 8, :7296-7304);
 * an order number typed directly takes the whole ADV_AMT (:7272-7290), and a reopened bill never loads col 8 (:14572-
 * 14590), so both situations reach the save unchecked. The save writes the rows as for any order (:15505-15530):
 * SL_DATA.ADV_AMT is the grid total (:15062, :19082-19086), and Ac_Ledr.cs:131-133 posts legs 21/22 only when
 * ORD_AC_CODE is 00020 (the ORDER ADVANCE account). An over-adjusted order's open advance simply goes negative.
 *
 * The web keeps refusing by default (409 `order-advance-confirm`, the facts in `details`) and accepts the save when
 * the request's `orderAdvanceAck` names exactly what the server computes at save time. The confirmation is recorded in
 * USER_DATA (the voucher's audit table, never part of the voucher's write set, so it survives an edit or delete).
 */

/** The ORDER ADVANCE account (bookTemplates slot 4/6): an order booked to it is not another customer's. */
export const ORDER_ADVANCE_ACCOUNT = '00020';
export const ORDER_ADVANCE_CONFIRM = 'order-advance-confirm';
/** USER_DATA.COL_TYPE (varchar 20) of a confirmation row. */
export const ORDER_ADVANCE_AUDIT_COL = 'ORD_ADV_CONFIRM';
const TOLERANCE = 0.005;

const text = (v: unknown): string => String(v ?? '').trim();
const num = (v: unknown): number => {
  const x = Number(v ?? 0);
  return Number.isFinite(x) ? x : 0;
};
const money = (v: number): string => round(v, 2).toFixed(2);

/** What the client sends back after the operator answered Yes, one per confirmed order row. */
export interface OrderAdvanceAck {
  orderKey: string;
  orderParty: string;
  openAmount: number;
  adjustAmount: number;
}

/** The facts of one order row that needs the operator's confirmation. */
export interface OrderAdvanceFacts {
  /** `<book>/<year>/<no>` of the order. */
  orderKey: string;
  ordNo: string;
  ordBook: string;
  ordYear: string;
  orderParty: string;
  orderPartyName: string;
  saleParty: string;
  salePartyName: string;
  openAmount: number;
  adjustAmount: number;
  /** adjustAmount - openAmount when positive, else 0. */
  overBy: number;
  otherCustomer: boolean;
}

export const orderKeyOf = (book: string, year: string, no: string): string =>
  `${text(book)}/${text(year)}/${text(no)}`;

/** The request's `orderAdvanceAck`: one object or a list; anything else is ignored. */
export function parseOrderAdvanceAck(v: unknown): OrderAdvanceAck[] | undefined {
  const list = Array.isArray(v) ? v : v && typeof v === 'object' ? [v] : [];
  const out = list
    .filter((a): a is Record<string, unknown> => !!a && typeof a === 'object')
    .map((a) => ({
      orderKey: text(a.orderKey),
      orderParty: text(a.orderParty),
      openAmount: num(a.openAmount),
      adjustAmount: num(a.adjustAmount),
    }))
    .filter((a) => a.orderKey !== '');
  return out.length ? out : undefined;
}

/** The row's facts when it needs a confirmation (another customer's order, or more than is open); else null. */
export function orderAdvanceFacts(
  order: { ordNo: string; ordBook: string; ordYear: string; acCode: string; acName: string },
  openAmount: number,
  adjustAmount: number,
  sale: { acCode: string; acName: string },
): OrderAdvanceFacts | null {
  const orderParty = text(order.acCode);
  const otherCustomer =
    orderParty !== '' && orderParty !== ORDER_ADVANCE_ACCOUNT && orderParty !== text(sale.acCode);
  const overBy = round(Math.max(0, adjustAmount - openAmount), 2);
  if (!otherCustomer && overBy <= TOLERANCE) return null;
  return {
    orderKey: orderKeyOf(order.ordBook, order.ordYear, order.ordNo),
    ordNo: text(order.ordNo),
    ordBook: text(order.ordBook),
    ordYear: text(order.ordYear),
    orderParty,
    orderPartyName: text(order.acName),
    saleParty: text(sale.acCode),
    salePartyName: text(sale.acName),
    openAmount: round(openAmount, 2),
    adjustAmount: round(adjustAmount, 2),
    overBy,
    otherCustomer,
  };
}

const party = (name: string, code: string): string => (name ? `${name} (${code})` : code);

/** The facts in plain words, as the confirmation and the refusal message state them. */
export function orderAdvanceQuestion(f: OrderAdvanceFacts): string {
  const owner = f.otherCustomer
    ? `Order ${f.ordNo} (${f.ordBook}) belongs to ${party(f.orderPartyName, f.orderParty)}, not to this bill's customer.`
    : `Order ${f.ordNo} (${f.ordBook}) belongs to ${party(f.orderPartyName, f.orderParty)}.`;
  const over = f.overBy > 0 ? `, ${money(f.overBy)} more than is open` : '';
  return (
    `${owner} It has ${money(f.openAmount)} advance open. You are adjusting ${money(f.adjustAmount)} on ` +
    `${party(f.salePartyName, f.saleParty)}'s bill${over}.`
  );
}

export interface OrderAdvanceRefusal {
  reason: 'confirm' | 'stale';
  rows: OrderAdvanceFacts[];
}

/** 409 `order-advance-confirm` (a SessionCommandError, which the routes answer with its `details`). Built at throw
 * time, not as a subclass, so a module that mocks sessionContextCommand can still load this one. */
export function orderAdvanceConfirmError(
  details: OrderAdvanceRefusal,
): SessionCommandError & { details: OrderAdvanceRefusal } {
  const message = [
    details.reason === 'stale'
      ? 'The order advance changed since it was confirmed.'
      : 'This order advance needs confirmation.',
    ...details.rows.map(orderAdvanceQuestion),
  ].join(' ');
  return Object.assign(new SessionCommandError(ORDER_ADVANCE_CONFIRM, 409, message), { details });
}

const same = (a: number, b: number) => Math.abs(round(a, 2) - round(b, 2)) <= TOLERANCE;

/**
 * Refuse unless every flagged row has an acknowledgement equal to the facts computed now. An ack for an order that
 * needs none is ignored; an ack whose figures differ (the open advance moved, another amount, another party) is stale.
 */
export function assertOrderAdvanceAcks(
  flagged: readonly OrderAdvanceFacts[],
  acks: readonly OrderAdvanceAck[] | undefined,
): void {
  if (!flagged.length) return;
  let stale = false;
  let missing = false;
  for (const f of flagged) {
    const ack = (acks ?? []).find((a) => a.orderKey === f.orderKey);
    if (!ack) missing = true;
    else if (
      ack.orderParty !== f.orderParty ||
      !same(ack.openAmount, f.openAmount) ||
      !same(ack.adjustAmount, f.adjustAmount)
    )
      stale = true;
  }
  if (stale || missing)
    throw orderAdvanceConfirmError({ reason: stale ? 'stale' : 'confirm', rows: [...flagged] });
}

export interface OrderAdvanceAuditContext {
  tenantId: string;
  key: { CO_CODE: string; LC_CODE: string; CO_YEAR: string; CO_BOOK: string; VCH_NO: string };
  acCode: string;
  vchDate: Date;
  bookName?: string | null;
  /** The voucher's own user (USER_NAME); the confirming user goes to NEW_USER. */
  originalUser?: string | null;
  user?: string | null;
}

/**
 * One USER_DATA row per confirmed order: COL_TYPE `ORD_ADV_CONFIRM`, OLD_VAL `<book>/<year>/<no>|<party>|<open>`,
 * NEW_VAL `<adjusted>|<P party, O over>|Y`, NEW_USER the operator who answered Yes, ENTRY_TIME the moment.
 */
export async function recordOrderAdvanceConfirmTx(
  tx: any,
  audit: OrderAdvanceAuditContext,
  confirmed: readonly OrderAdvanceFacts[],
): Promise<void> {
  const now = new Date();
  for (const f of confirmed) {
    const flags = `${f.otherCustomer ? 'P' : ''}${f.overBy > 0 ? 'O' : ''}`;
    await insertRowTx(tx, 'USER_DATA', audit.tenantId, {
      CO_CODE: audit.key.CO_CODE,
      LC_CODE: audit.key.LC_CODE,
      CO_YEAR: audit.key.CO_YEAR,
      CO_BOOK: audit.key.CO_BOOK,
      VCH_NO: audit.key.VCH_NO,
      AC_CODE: audit.acCode,
      VCH_DATE: audit.vchDate,
      EDIT_DATE: now,
      ENTRY_TIME: now,
      USER_NAME: text(audit.originalUser).slice(0, 15) || null,
      NEW_USER: text(audit.user).slice(0, 15) || null,
      BOOK_NAME: audit.bookName ? text(audit.bookName).slice(0, 50) : null,
      COL_TYPE: ORDER_ADVANCE_AUDIT_COL,
      OLD_VAL: `${f.orderKey}|${f.orderParty}|${money(f.openAmount)}`.slice(0, 50),
      NEW_VAL: `${money(f.adjustAmount)}|${flags}|Y`.slice(0, 50),
      ENTRY_CHECK: 'N',
    });
  }
}

const ddmmyyyy = (d: Date): string =>
  `${String(d.getDate()).padStart(2, '0')}/${String(d.getMonth() + 1).padStart(2, '0')}/${d.getFullYear()}`;

/**
 * The reopen notes: for each order row the sale still carries, the latest confirmation of that order with the same
 * amount ("Order advance from another customer's order — confirmed by <user> on <date>").
 */
export async function readOrderAdvanceNotesTx(
  tx: any,
  params: readonly unknown[],
  orders: ReadonlyArray<{
    ordNo?: unknown;
    ordBook?: unknown;
    ordYear?: unknown;
    amount?: unknown;
  }>,
): Promise<string[]> {
  if (!orders.length) return [];
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "OLD_VAL","NEW_VAL","NEW_USER","ENTRY_TIME" FROM "USER_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND "COL_TYPE"='${ORDER_ADVANCE_AUDIT_COL}' ORDER BY "ENTRY_TIME" DESC, row_id DESC`,
    ...params,
  );
  const notes: string[] = [];
  for (const order of orders) {
    const orderKey = orderKeyOf(text(order.ordBook), text(order.ordYear), text(order.ordNo));
    const row = rows.find((r) => text(r.OLD_VAL).split('|')[0] === orderKey);
    if (!row) continue;
    const [, orderParty = '', open = '0'] = text(row.OLD_VAL).split('|');
    const [adjusted = '0', flags = ''] = text(row.NEW_VAL).split('|');
    if (!same(num(adjusted), num(order.amount))) continue;
    const what = [
      flags.includes('P') ? `from another customer's order (${orderParty})` : '',
      flags.includes('O')
        ? `${money(num(adjusted) - num(open))} more than the ${money(num(open))} open`
        : '',
    ]
      .filter(Boolean)
      .join(', ');
    const when = row.ENTRY_TIME instanceof Date ? ddmmyyyy(row.ENTRY_TIME) : text(row.ENTRY_TIME);
    notes.push(
      `Order advance ${what}: order ${text(order.ordNo)}, ${money(num(adjusted))} adjusted — confirmed by ${text(row.NEW_USER) || 'unknown user'} on ${when}`,
    );
  }
  return notes;
}
