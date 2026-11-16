import { round, toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import {
  resolveBookSlotAccountTx,
  PostingAccountValidationError,
} from '../shared/postingAccounts.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { assertBalanced, postVoucherTx, type LedgerLine } from '../posting/posting.js';
import { rojmelLedrKey, type RojmelRow } from '../shared/rojmel.js';
import { kasarAccountTx } from '../finance/finance.js';
import { deleteVoucherWriteSetTx } from '../vouchers/lifecycle.js';
import {
  assertVoucherVersionTx,
  requiredVersion,
  versionKeyOf,
  voucherVersionTx,
} from '../vouchers/version.js';
import {
  completeFinanceScope,
  configuredBookTx,
  createFinanceIdentityTx,
  editIdentityTx,
  financeEmployeeTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  requireBookFamily,
  assertFinanceVoucherDateTx,
  text,
  voucherKey,
  type CompleteFinanceScope,
  type VoucherIdentity,
} from '../finance/lifecycle.js';
import {
  markOrderTagsTx,
  reservedOrderTagsTx,
  savedOrderCancelTagsTx,
  writeOrderCancelTagsTx,
  type OrderTagRow,
} from './orderCancelTags.js';

/**
 * Order Cancel (desktop TR_SL_ORD_ADJ, book family `ORDER CANCEL`, MDI_FORM.cs:8628-8639): one voucher cancels the
 * advance of any number of pending sales orders. A grid row names an order, the amount of its advance that is adjusted
 * (AdjAmt), the part kept as kasar (KsarAmt) and the part refunded (PaidAmt = AdjAmt - KsarAmt, CommPassTotal
 * TR_SL_ORD_ADJ.cs:2447) through an account (PaiidAc, default 00001 CASH ON HAND, CommPassAdd :2255-2263).
 *
 * Write set (BtnSave_Click, TR_SL_ORD_ADJ.cs:3410-3680), all in one transaction:
 *  - SL_ORD_ADJ  one row per grid row (:3527-3585): ENTRY_TYPE 'C', ORD_SIGN '-', ORD_AMT = AdjAmt, ORD_BAL_AMT =
 *    OrdAmt, the order's own key in ORD_NO / ORD_LC / ORD_YRCD / ORD_DBCD / ORD_HD_VCH_NO;
 *  - TEMP_BOOK_DATA the hidden voucher number (:3511-3522);
 *  - APR_DETL, BAR_DETL, BAR_IDTL, SL_ORD_DETL.TAG_SALE and MAIN_STOCK for the tags the orders held (orderCancelTags.ts);
 *  - AC_DATA     Order_Adj_Ledr (Ac_Ledr.cs:928-937): Dr customer / Cr refund account for PaidAmt (keys STR(SR_NO)+'01',
 *    +'02') and, when there is a kasar, Dr customer / Cr kasar account (+'03', +'04');
 *  - ROJ_MEL_DATA Order_Adj_Rojmel (Ac_Rojmel.cs:392-400): the same legs, without the cash account's own row.
 *
 * Accounts are never literals: the refund account is the operator's choice (default: slot 1 of the cancel book, the
 * desktop's 00001), the kasar account is slot 2 of the cancel book (the desktop's fixed 00042), as in G163.
 *
 * Deliberate web hardening (the desktop checks none of these; each would let an advance be refunded twice or post a
 * negative leg): AdjAmt must be above zero and at most the advance still open on the order, also across rows of the
 * same voucher and against sales and other cancels made meanwhile (the order row is locked); KsarAmt is between 0
 * and AdjAmt.
 */
export class OrderCancelValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'OrderCancelValidationError';
  }
}

export interface OrderCancelRow {
  /** Order voucher number (grid column OrdNo). */
  ordNo: string;
  /** The order's year and book (hidden grid columns 11 and 12): an order number repeats across years and books. */
  ordYear?: string;
  ordBook?: string;
  /** AdjAmt: the advance used up by this cancellation. */
  adjAmt: number;
  kasarAmt: number;
  /** PaidAmt: AdjAmt - KsarAmt. Optional; when sent it must agree. */
  paidAmt?: number;
  /** PaiidAc: the account the refund leaves from. Blank = slot 1 of the cancel book. */
  paidAc?: string;
  itDesc?: string;
}

export interface OrderCancelInput {
  scope: VoucherScope;
  rows: OrderCancelRow[];
  vchDate?: Date | string;
  empCode?: string;
  mainUser?: string;
}

export interface PendingOrder {
  ordNo: string;
  acCode: string;
  acName: string;
  ordDate: string;
  ordYear: string;
  ordBook: string;
  hdVchNo: string;
  advAmt: number;
  /** Advance already used by sales and earlier cancellations. */
  adjAmt: number;
  /** What is left to cancel. */
  openAmt: number;
}

/** The tables a cancel voucher owns, keyed by its own company, location, year, book and number. */
export const ORDER_CANCEL_WRITE_TABLES = [
  'SL_ORD_ADJ',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'APR_DETL',
  'BAR_DETL',
  'BAR_IDTL',
] as const;

const round2 = (value: number): number => round(value, 2);
const num = (value: unknown): number => Number(value ?? 0);
const TOLERANCE = 0.004;

/**
 * How much of an order's advance is already used. The desktop stores a use as an SL_ORD_ADJ row with ORD_SIGN '-' and
 * the amount in ORD_AMT (TR_SALE.cs:15715, TR_SL_ORD_ADJ.cs:3552). The web's earlier writers stored it with ORD_SIGN
 * 'C' (sale) or 'D' (cancel) and the amount in PAID_AMT (+ KASAR_AMT for a cancel); those rows are read the same way.
 * ORD_SIGN '+' is the advance itself (TR_SALE_ORD.cs:9503); the web reads the advance from SL_ORD_DATA.ADV_AMT
 * because the web Sales Order writes no '+' row, so a '+' row is not counted twice.
 */
const CONSUMED_SQL = `
  CASE
    WHEN a."ORD_SIGN" = '-'
     AND coalesce(nullif(btrim(a."ORD_YRCD"::text),''), o."CO_YEAR") = o."CO_YEAR"
     AND coalesce(nullif(btrim(a."ORD_DBCD"::text),''), o."CO_BOOK") = o."CO_BOOK"
      THEN coalesce(NULLIF(a."ORD_AMT"::text,'')::numeric,0)
    WHEN a."ORD_SIGN" IN ('C','D')
      THEN coalesce(NULLIF(a."PAID_AMT"::text,'')::numeric,0) + coalesce(NULLIF(a."KASAR_AMT"::text,'')::numeric,0)
    ELSE 0
  END`;

/**
 * Orders of the location with their advance and what is used; callers decide which are still open. With `lock`,
 * the named orders' rows are locked first (FOR UPDATE, in key order) so a concurrent sale or cancel of the same order
 * waits and then sees this transaction's use.
 */
async function ordersWithAdvanceTx(
  tx: any,
  scope: VoucherScope,
  lock?: string[],
): Promise<PendingOrder[]> {
  if (lock?.length)
    await tx.$queryRawUnsafe(
      `SELECT 1 FROM "SL_ORD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "VCH_NO" = ANY($4::text[])
        ORDER BY "CO_YEAR","CO_BOOK","VCH_NO" FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      [...new Set(lock)],
    );
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT o."VCH_NO" AS ord_no, o."AC_CODE" AS ac_code, o."AC_NAME" AS ac_name, o."VCH_DATE"::text AS ord_date,
            o."CO_YEAR" AS ord_year, o."CO_BOOK" AS ord_book, o."HD_VCH_NO" AS hd_vch_no,
            coalesce(NULLIF(o."ADV_AMT"::text,'')::numeric,0)::float AS adv,
            coalesce((
              SELECT sum(${CONSUMED_SQL}) FROM "SL_ORD_ADJ" a
               WHERE a.tenant_id = o.tenant_id AND a."CO_CODE" = o."CO_CODE"
                 AND a."ORD_NO" = o."VCH_NO"
                 AND coalesce(nullif(btrim(a."ORD_LC"::text),''), a."LC_CODE") = o."LC_CODE"
            ), 0)::float AS used
       FROM "SL_ORD_DATA" o
      WHERE o.tenant_id = $1 AND o."CO_CODE" = $2 AND o."LC_CODE" = $3
        ${lock?.length ? `AND o."VCH_NO" = ANY($4::text[])` : ''}
      ORDER BY o."VCH_DATE", o."VCH_NO", o."CO_YEAR", o."CO_BOOK"`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    ...(lock?.length ? [[...new Set(lock)]] : []),
  );
  return rows.map((r) => {
    const advAmt = round2(num(r.adv));
    const adjAmt = round2(num(r.used));
    return {
      ordNo: text(r.ord_no),
      acCode: text(r.ac_code),
      acName: text(r.ac_name),
      ordDate: toIsoDate(r.ord_date),
      ordYear: text(r.ord_year),
      ordBook: text(r.ord_book),
      hdVchNo: text(r.hd_vch_no),
      advAmt,
      adjAmt,
      openAmt: round2(advAmt - adjAmt),
    };
  });
}

/** The help list of the OrdNo cell: orders whose advance is not used up (TR_SL_ORD_ADJ.cs:2499-2526). */
export async function listPendingOrders(prisma: any, scope: VoucherScope): Promise<PendingOrder[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) =>
    (await ordersWithAdvanceTx(tx, scope)).filter((order) => order.openAmt > TOLERANCE),
  );
}

/** The help list with each order's held tags, which picking it puts in the tag grid (TR_SL_ORD_ADJ.cs:2598-2631). */
export async function listPendingOrdersWithTags(
  prisma: any,
  scope: VoucherScope,
): Promise<Array<PendingOrder & { tags: OrderTagRow[] }>> {
  const complete = completeFinanceScope(scope);
  return withTxBudget(prisma, complete.tenantId, 'read', async (tx: any) => {
    const open = (await ordersWithAdvanceTx(tx, complete)).filter((o) => o.openAmt > TOLERANCE);
    const out: Array<PendingOrder & { tags: OrderTagRow[] }> = [];
    for (const order of open)
      out.push({ ...order, tags: await reservedOrderTagsTx(tx, complete, [order]) });
    return out;
  });
}

/**
 * A new grid row's refund account: the desktop puts 00001 CASH ON HAND in PaiidAc (CommPassAdd, TR_SL_ORD_ADJ.cs:2255-
 * 2263); the web reads it from slot 1 of the cancel book. Blank when the book has no slot 1 (Save then asks for one).
 */
export async function orderCancelDefaults(
  prisma: any,
  scope: VoucherScope,
): Promise<{ paidAc: string; paidAcName: string }> {
  const complete = completeFinanceScope(scope);
  return withTxBudget(prisma, complete.tenantId, 'read', async (tx: any) => {
    requireBookFamily(await configuredBookTx(tx, complete), 'ORDER CANCEL', 'order cancel');
    const paidAc = await cashAccountTx(tx, complete);
    if (!paidAc) return { paidAc: '', paidAcName: '' };
    const rows: Array<{ name: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "AC_NAME" AS name FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"::text=$3::text
        ORDER BY CASE WHEN "LC_CODE"::text=$4 THEN 0 ELSE 1 END, row_id LIMIT 1`,
      complete.tenantId,
      complete.coCode,
      paidAc,
      complete.lcCode,
    );
    return { paidAc, paidAcName: text(rows[0]?.name) };
  });
}

/**
 * Open advance of one order, for the sale that wants to use it. Same rule and the same lock as the cancel, so a sale
 * and a cancel never use the same money twice. Call it inside the writer's transaction.
 */
export async function openAdvanceOfOrderTx(
  tx: any,
  scope: VoucherScope,
  ordNo: number | string,
  ordBook = 'SOR',
): Promise<PendingOrder | null> {
  const no = formatVoucherNo(ordNo);
  const orders = await ordersWithAdvanceTx(tx, scope, [no]);
  return orders.find((o) => o.ordBook === ordBook) ?? orders[0] ?? null;
}

interface CheckedRow {
  order: PendingOrder;
  adjAmt: number;
  kasarAmt: number;
  paidAmt: number;
  paidAc: string;
  itDesc: string;
  /** OrdAmt: what was still open on the order when this row was reached (earlier rows already taken off). */
  balAmt: number;
}

/** Shape rules that need no database (TR_SL_ORD_ADJ.cs:2447 PaidAmt = AdjAmt - KsarAmt, :2733 AdjAmt required). */
function checkShape(rows: OrderCancelRow[]): Array<OrderCancelRow & { paidAmt: number }> {
  const given = Array.isArray(rows) ? rows : [];
  const used = given.filter((r) => text(r?.ordNo) !== '');
  if (!used.length) throw new OrderCancelValidationError('Select at least one order to cancel.');
  return used.map((r, i) => {
    const label = `Row ${i + 1} (order ${text(r.ordNo)})`;
    const adj = round2(num(r.adjAmt));
    const kasar = round2(num(r.kasarAmt));
    const paid = round2(adj - kasar);
    if (![adj, kasar].every(Number.isFinite))
      throw new OrderCancelValidationError(`${label}: the amounts must be numbers.`);
    if (adj <= 0)
      throw new OrderCancelValidationError(`${label}: Enter the adjusted amount (AdjAmt).`);
    if (kasar < 0 || paid < 0)
      throw new OrderCancelValidationError(`${label}: Kasar and Paid amounts cannot be negative.`);
    if (r.paidAmt != null && Math.abs(round2(num(r.paidAmt)) - paid) > TOLERANCE)
      throw new OrderCancelValidationError(
        `${label}: Paid amount plus Kasar must equal the adjusted amount (${adj.toFixed(2)}).`,
      );
    return {
      ...r,
      ordNo: formatVoucherNo(text(r.ordNo)),
      adjAmt: adj,
      kasarAmt: kasar,
      paidAmt: paid,
    };
  });
}

async function accountExistsTx(tx: any, scope: VoucherScope, acCode: string): Promise<boolean> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"::text=$3::text LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    acCode,
  );
  return rows.length > 0;
}

/** Match the rows to orders, and refuse what the order cannot give. Locks the orders it reads. */
async function checkRowsTx(
  tx: any,
  scope: VoucherScope,
  shaped: Array<OrderCancelRow & { paidAmt: number }>,
): Promise<CheckedRow[]> {
  const orders = await ordersWithAdvanceTx(
    tx,
    scope,
    shaped.map((r) => r.ordNo),
  );
  const taken = new Map<PendingOrder, number>();
  const checked: CheckedRow[] = [];
  for (const [i, row] of shaped.entries()) {
    const label = `Row ${i + 1} (order ${row.ordNo})`;
    const named = orders.filter(
      (o) =>
        o.ordNo === row.ordNo &&
        (!row.ordYear || o.ordYear === row.ordYear) &&
        (!row.ordBook || o.ordBook === row.ordBook),
    );
    if (!named.length) throw new OrderCancelValidationError(`${label}: sales order not found.`);
    const open = named.filter((o) => o.openAmt > TOLERANCE);
    if (named.length > 1 && open.length !== 1)
      throw new OrderCancelValidationError(
        `${label}: more than one order has this number; choose it from the list.`,
      );
    const order = (open.length === 1 ? open[0] : named[0])!;
    const already = taken.get(order) ?? 0;
    const balAmt = round2(order.openAmt - already);
    const total = round2(already + row.adjAmt);
    if (total - order.openAmt > TOLERANCE)
      throw new OrderCancelValidationError(
        `${label}: ${total.toFixed(2)} was asked for but only ${order.openAmt.toFixed(2)} open advance is left on this order.`,
      );
    taken.set(order, total);
    let paidAc = text(row.paidAc);
    if (row.paidAmt > 0) {
      // The refund account: the operator's choice or slot 1 of the cancel book. Never a literal.
      paidAc = await resolveBookSlotAccountTx(tx, scope, 'refund-settlement', 1, row.paidAc);
      if (!(await accountExistsTx(tx, scope, paidAc)))
        throw new OrderCancelValidationError(`${label}: refund account ${paidAc} does not exist.`);
    }
    checked.push({
      order,
      adjAmt: row.adjAmt,
      kasarAmt: row.kasarAmt,
      paidAmt: row.paidAmt,
      paidAc,
      itDesc: text(row.itDesc).slice(0, 150),
      balAmt,
    });
  }
  return checked;
}

/** Slot 1 of the cancel book is the cash account; its own Rojmel row is left out (Ac_Rojmel.cs, PAID_AC <> '00001'). */
async function cashAccountTx(tx: any, scope: VoucherScope): Promise<string> {
  try {
    return await resolveBookSlotAccountTx(tx, scope, 'cash-settlement', 1);
  } catch (error) {
    if (error instanceof PostingAccountValidationError) return '';
    throw error;
  }
}

/** Order_Adj_Ledr (Ac_Ledr.cs:928-937): IT_DESC '', PARTY_AC_CODE the customer on all four legs. */
function legs(
  key: Record<string, unknown>,
  srNo: number,
  row: CheckedRow,
  kasarAc: string,
  identity: VoucherIdentity,
  vchType: string,
): LedgerLine[] {
  const customer = row.order.acCode;
  const base = (suffix: string, ac: string, ld: string, dr: number, cr: number): LedgerLine => ({
    ...key,
    VCH_TYPE: vchType,
    VCH_DATE: identity.voucherDate,
    legKeySuffix: `${srNo}${suffix}`.padStart(12, ' '),
    AC_CODE: ac,
    LD_CODE: ld,
    DR_AMT: dr,
    CR_AMT: cr,
    IT_TYPE: 'A',
    SIGN: '',
    IT_DESC: '',
    ENTRY_TIME: identity.voucherTime,
    HD_VCH_NO: identity.hiddenVoucherNo,
    MAIN_USER: identity.mainUser,
    PARTY_AC_CODE: customer,
    LDR_NAME: '',
  });
  const out: LedgerLine[] = [];
  if (row.paidAmt !== 0)
    out.push(
      base('01', customer, row.paidAc, row.paidAmt, 0),
      base('02', row.paidAc, customer, 0, row.paidAmt),
    );
  if (row.kasarAmt !== 0)
    out.push(
      base('03', customer, kasarAc, row.kasarAmt, 0),
      base('04', kasarAc, customer, 0, row.kasarAmt),
    );
  return out;
}

function rojmel(
  scope: CompleteFinanceScope,
  key: Record<string, unknown>,
  book: { shortName: string; mainBook: string },
  identity: VoucherIdentity,
  srNo: number,
  row: CheckedRow,
  cashAc: string,
  kasarAc: string,
): RojmelRow[] {
  const make = (
    type: string,
    ac: string,
    ld: string,
    dr: number,
    cr: number,
    name: string,
  ): RojmelRow => ({
    ...key,
    LEDR_KEY: rojmelLedrKey(
      { coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear },
      scope.coBook,
      identity.voucherNo,
      type as never,
      srNo,
    ),
    VCH_DATE: identity.voucherDate,
    VCH_TYPE: book.shortName,
    BOOK_NAME: book.mainBook,
    AC_CODE: ac,
    AC_NAME: name,
    LD_CODE: ld,
    DR_AMT: dr,
    CR_AMT: cr,
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
    IT_DESC: row.itDesc,
    IT_CODE: '',
  });
  const customer = row.order.acCode;
  const name = row.order.acName;
  const out: RojmelRow[] = [];
  if (row.paidAmt !== 0) {
    out.push(make('01', customer, row.paidAc, row.paidAmt, 0, name));
    if (row.paidAc !== cashAc) out.push(make('02', row.paidAc, customer, 0, row.paidAmt, name));
  }
  if (row.kasarAmt !== 0) {
    out.push(make('03', customer, kasarAc, row.kasarAmt, 0, `KSR - ${name}`));
    out.push(make('04', kasarAc, customer, 0, row.kasarAmt, `KSR - ${name}`));
  }
  return out;
}

/** Writes the whole voucher for an identity; the caller owns the transaction (create, or edit after the delete). */
async function writeOrderCancelTx(
  tx: any,
  scope: CompleteFinanceScope,
  input: OrderCancelInput,
  shaped: Array<OrderCancelRow & { paidAmt: number }>,
  identity: VoucherIdentity,
): Promise<{ vchNo: number }> {
  const book = await configuredBookTx(tx, scope);
  requireBookFamily(book, 'ORDER CANCEL', 'order cancel');
  // TR_SL_ORD_ADJ.cs:3440-3445: a blank employee is refused when the company makes it mandatory.
  const empCode = await financeEmployeeTx(tx, scope, input.empCode);
  const rows = await checkRowsTx(tx, scope, shaped);
  const kasarTotal = rows.reduce((sum, r) => sum + r.kasarAmt, 0);
  // The kasar account is slot 2 of the cancel book; unconfigured is refused, never replaced by a literal.
  const kasarAc = kasarTotal ? await kasarAccountTx(tx, scope, undefined, '', kasarTotal) : '';
  const cashAc = await cashAccountTx(tx, scope);
  const key = voucherKey(scope, identity.voucherNo);
  const ledger = rows.flatMap((row, i) => legs(key, i + 1, row, kasarAc, identity, book.shortName));
  if (ledger.length) assertBalanced(ledger);
  const rojmelRows = rows.flatMap((row, i) =>
    rojmel(scope, key, book, identity, i + 1, row, cashAc, kasarAc),
  );
  await insertHiddenIdentityTx(tx, scope, identity, book.name);
  await postVoucherTx(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: book.mainBook, // Ac_Ledr.cs:928 stamps B.MAIN_BOOK
    writes: [
      {
        table: 'SL_ORD_ADJ',
        rows: rows.map((row, i) => ({
          ...key,
          SR_NO: i + 1,
          VCH_DATE: identity.voucherDate,
          VCH_TIME: identity.voucherTime,
          VCH_TYPE: book.shortName,
          INOUT_TYPE: book.inout,
          ENTRY_TYPE: 'C',
          BOOK_NAME: book.mainBook,
          AC_CODE: row.order.acCode,
          AC_NAME: row.order.acName,
          ORD_HD_VCH_NO: row.order.hdVchNo,
          ORD_NO: row.order.ordNo,
          ORD_LC: scope.lcCode,
          ORD_YRCD: row.order.ordYear,
          ORD_DBCD: row.order.ordBook,
          ORD_AC_CODE: row.order.acCode,
          ORD_SIGN: '-',
          ORD_BAL_AMT: row.balAmt,
          ORD_AMT: row.adjAmt,
          PAID_AC: row.paidAc,
          PAID_AMT: row.paidAmt,
          KASAR_AMT: row.kasarAmt,
          ORD_GOLD: 0,
          ORD_SILVER: 0,
          IT_DESC: row.itDesc,
          HD_VCH_NO: identity.hiddenVoucherNo,
          EMP_CODE: empCode,
          DATA_TRFR: 'N',
          MAIN_USER: identity.mainUser,
          USER_UPDATE: 'N',
          USER_DELETE: 'N',
        })),
      },
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
    ],
  });
  // The tags the orders held come back to stock (TR_SL_ORD_ADJ.cs:3593-3660, Ac_Stock.cs:610).
  const seen = new Set<string>();
  const orders = rows
    .map((r) => r.order)
    .filter((o) => {
      const id = `${o.ordYear}|${o.ordBook}|${o.ordNo}`;
      return seen.has(id) ? false : (seen.add(id), true);
    });
  await writeOrderCancelTagsTx(
    tx,
    {
      scope,
      voucherNo: identity.voucherNo,
      hiddenVoucherNo: identity.hiddenVoucherNo,
      vchDate: identity.voucherDate,
      voucherTime: identity.voucherTime,
      book,
      mainUser: identity.mainUser,
      empCode,
    },
    await reservedOrderTagsTx(tx, scope, orders),
  );
  return { vchNo: identity.vchNo };
}

const requestedDate = (value: Date | string | undefined): Date => {
  const date = value ? new Date(value) : new Date();
  if (Number.isNaN(date.getTime()))
    throw new OrderCancelValidationError('the voucher date is not a date');
  return date;
};

export async function postOrderCancel(
  prisma: any,
  input: OrderCancelInput,
): Promise<{ vchNo: number }> {
  const shaped = checkShape(input.rows);
  const scope = completeFinanceScope(input.scope);
  const vchDate = requestedDate(input.vchDate);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) =>
    writeOrderCancelTx(
      tx,
      scope,
      input,
      shaped,
      await createFinanceIdentityTx(tx, scope, vchDate, input.mainUser),
    ),
  );
}

export interface OrderCancelVoucherRow {
  srNo: number;
  ordNo: string;
  acCode: string;
  acName: string;
  ordYear: string;
  ordBook: string;
  ordHdVchNo: string;
  /** OrdAmt: the open advance when the row was saved. */
  ordAmt: number;
  adjAmt: number;
  kasarAmt: number;
  paidAmt: number;
  paidAc: string;
  paidAcName: string;
  itDesc: string;
}

/**
 * The saved voucher as DISPLAY_DATA shows it (TR_SL_ORD_ADJ.cs:3184-3326), with the version an edit or a delete must
 * send back. A row saved by the earlier single-order writer keeps its amounts in PAID_AMT and KASAR_AMT only.
 */
export async function getOrderCancel(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
) {
  const complete = completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, complete.tenantId, 'read', async (tx: any) => {
    requireBookFamily(await configuredBookTx(tx, complete), 'ORDER CANCEL', 'order cancel');
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."VCH_NO", a."VCH_DATE"::text AS vch_date, a."HD_VCH_NO", a."MAIN_USER", a."EMP_CODE", a."SR_NO",
              a."AC_CODE", a."AC_NAME", a."ORD_NO", a."ORD_YRCD", a."ORD_DBCD", a."ORD_HD_VCH_NO", a."IT_DESC", a."PAID_AC",
              coalesce(NULLIF(a."ORD_AMT"::text,'')::numeric,0)::float AS ord_amt,
              coalesce(NULLIF(a."ORD_BAL_AMT"::text,'')::numeric,0)::float AS ord_bal,
              coalesce(NULLIF(a."PAID_AMT"::text,'')::numeric,0)::float AS paid,
              coalesce(NULLIF(a."KASAR_AMT"::text,'')::numeric,0)::float AS kasar,
              (SELECT m."AC_NAME" FROM "AC_MAST" m WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE"
                  AND m."AC_CODE"::text=a."PAID_AC"::text LIMIT 1) AS paid_name,
              (SELECT e."EMP_NAME" FROM "EMP_MAST" e WHERE e.tenant_id=a.tenant_id AND e."CO_CODE"=a."CO_CODE"
                  AND e."EMP_CODE"=a."EMP_CODE" LIMIT 1) AS emp_name
         FROM "SL_ORD_ADJ" a
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
        ORDER BY a."SR_NO"`,
      complete.tenantId,
      complete.coCode,
      complete.lcCode,
      complete.coYear,
      complete.coBook,
      voucherNo,
    );
    if (!rows.length)
      throw new OrderCancelValidationError(`order cancel voucher not found: ${voucherNo}`);
    const head = rows[0]!;
    const tags: OrderTagRow[] = await savedOrderCancelTagsTx(tx, complete, voucherNo);
    return {
      voucherNo,
      hiddenVoucherNo: text(head.HD_VCH_NO),
      mainUser: text(head.MAIN_USER),
      empCode: text(head.EMP_CODE),
      empName: text(head.emp_name),
      vchDate: toIsoDate(head.vch_date),
      version: await voucherVersionTx(
        tx,
        ORDER_CANCEL_WRITE_TABLES,
        versionKeyOf(complete, voucherNo),
      ),
      tags,
      rows: rows.map((r): OrderCancelVoucherRow => {
        const paidAmt = round2(num(r.paid));
        const kasarAmt = round2(num(r.kasar));
        const adjAmt = num(r.ord_amt) > 0 ? round2(num(r.ord_amt)) : round2(paidAmt + kasarAmt);
        return {
          srNo: num(r.SR_NO),
          ordNo: text(r.ORD_NO),
          acCode: text(r.AC_CODE),
          acName: text(r.AC_NAME),
          ordYear: text(r.ORD_YRCD),
          ordBook: text(r.ORD_DBCD),
          ordHdVchNo: text(r.ORD_HD_VCH_NO),
          ordAmt: num(r.ord_bal) > 0 ? round2(num(r.ord_bal)) : adjAmt,
          adjAmt,
          kasarAmt,
          paidAmt,
          paidAc: text(r.PAID_AC),
          paidAcName: text(r.paid_name),
          itDesc: text(r.IT_DESC),
        };
      }),
    };
  });
}

/** Lock the saved voucher, check the lock date and the version; nothing is changed before this passes. */
async function lockedVoucherTx(
  tx: any,
  scope: CompleteFinanceScope,
  requestedVoucherNo: number | string,
  expectedVersion: string,
  date: { requested: Date; check: boolean },
) {
  requireBookFamily(await configuredBookTx(tx, scope), 'ORDER CANCEL', 'order cancel');
  const { identity } = await editIdentityTx(tx, {
    table: 'SL_ORD_ADJ',
    scope,
    requestedVoucherNo,
    requestedDate: date.requested,
    checkRequestedDate: date.check,
  });
  await assertVoucherVersionTx(
    tx,
    ORDER_CANCEL_WRITE_TABLES,
    versionKeyOf(scope, identity.voucherNo),
    expectedVersion,
  );
  return identity;
}

export async function editOrderCancel(
  prisma: any,
  input: OrderCancelInput & { expectedVersion: unknown },
  requestedVoucherNo: number | string,
) {
  const expectedVersion = requiredVersion(input.expectedVersion);
  const shaped = checkShape(input.rows); // refuse before touching the saved voucher
  const scope = completeFinanceScope(input.scope);
  const date = requestedDate(input.vchDate);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    // TR_SL_ORD_ADJ.cs:3455 checks the year; editIdentityTx then checks the lock date of the saved and the new date.
    await assertFinanceVoucherDateTx(tx, scope, date);
    const identity = await lockedVoucherTx(tx, scope, requestedVoucherNo, expectedVersion, {
      requested: date,
      check: true,
    });
    // The orders' tags go back to "held by the order" before the rebuild picks them up again.
    await markOrderTagsTx(tx, scope, identity.voucherNo, 'N');
    await replaceWriteSetTx(
      tx,
      scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      ORDER_CANCEL_WRITE_TABLES,
    );
    return writeOrderCancelTx(tx, scope, input, shaped, identity);
  });
}

/**
 * BtnDelete_Click (TR_SL_ORD_ADJ.cs:3726-3756): lock date, then TAG_SALE back to 'N', then the hidden number, ledger,
 * day book, stock, SL_ORD_ADJ, APR_DETL, BAR_DETL and BAR_IDTL rows of the voucher. It writes no DELETE_DATA row.
 */
export async function deleteOrderCancel(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; expectedVersion: unknown },
): Promise<{ reversed: true }> {
  const expectedVersion = requiredVersion(input.expectedVersion);
  const scope = completeFinanceScope(input.scope);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const identity = await lockedVoucherTx(tx, scope, input.vchNo, expectedVersion, {
      requested: new Date(),
      check: false,
    });
    await markOrderTagsTx(tx, scope, identity.voucherNo, 'N');
    await deleteVoucherWriteSetTx(tx, {
      tables: ORDER_CANCEL_WRITE_TABLES,
      key: { scope, voucherNo: identity.voucherNo },
      tempBook: { voucherNo: identity.hiddenVoucherNo },
    });
    return { reversed: true as const };
  });
}
