import { oldMetalRateTypeError, round } from '@datacare/core';
import { SessionCommandError } from '../auth/sessionContextCommand.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import { openAdvanceOfOrderTx } from './orderCancel.js';

/**
 * WP-26 (N243, G255): the Sales Invoice (TR_SALE) parts the web writer did not carry: the UPI grid (`UPI_DATA`),
 * the credit-note grid (`CRNT_DATA`), the order-advance grid in the desktop shape (`SL_ORD_ADJ`), the stone rows
 * (`SL_IDTL`), the member-commission header columns, and the lossless rule for an unchanged save.
 * Kept out of `sales.ts` (size budget); `writeSaleTx` and `getSale` call in here.
 */

/** One `MSG_UPI` row: col 1 account, 2 name, 3 type, 4 UPI id, 5 amount (TR_SALE.cs:15865-15869). */
export interface SaleUpiRow {
  acCode: string;
  acName?: string;
  type?: string;
  upiId?: string;
  amount: number;
}
/** One `MSG_CRNT` row: col 1 note no, 2 amount, 3 LC, 4 year, 5 book, 6 account, 7 hidden no (:15906-15911). */
export interface SaleCreditNoteRow {
  crntNo: string;
  amount: number;
  crntLc?: string;
  crntYear?: string;
  crntBook?: string;
  crntAcCode?: string;
  crntHdVchNo?: string;
}
/** One `MSG_ORD` row (:15709-15716). `amount` absent only on the legacy `orderRef` (whole open advance). */
export interface SaleOrderRow {
  ordNo: string | number;
  amount?: number;
  ordBook?: string;
  ordYear?: string;
  ordLc?: string;
  ordAcCode?: string;
  ordHdVchNo?: string;
}

export interface SaleResidualInput {
  memberCommissionAc?: string;
  withoutCommissionBill?: boolean;
  upiRows?: SaleUpiRow[];
  creditNotes?: SaleCreditNoteRow[];
  orders?: SaleOrderRow[];
}

const num = (v: unknown): number => {
  const x = Number(v ?? 0);
  return Number.isFinite(x) ? x : 0;
};
const text = (v: unknown): string => String(v ?? '').trim();
const r2 = (v: number): number => round(v, 2);
const TOLERANCE = 0.005;

/** The request body fields of this module, for the sale routes. */
export function saleResidualInput(b: Record<string, any>): SaleResidualInput {
  const list = <T>(v: unknown): T[] | undefined => (Array.isArray(v) ? (v as T[]) : undefined);
  return {
    memberCommissionAc: b.memberCommissionAc == null ? undefined : String(b.memberCommissionAc),
    withoutCommissionBill: b.withoutCommissionBill == null ? undefined : !!b.withoutCommissionBill,
    upiRows: list<SaleUpiRow>(b.upiRows),
    creditNotes: list<SaleCreditNoteRow>(b.creditNotes),
    orders: list<SaleOrderRow>(b.orders),
  };
}

type TenderInput = SaleResidualInput & {
  upiAmt?: number;
  currentAdjustmentAmount?: number;
  orderRef?: { ordNo: string | number; adjustAmt?: number; ordBook?: string } | null;
  oldGold?: Array<{ rateType?: string }>;
};

/**
 * Shape rules that need no database. UPI rows count when the account is set and the amount is non-zero
 * (TR_SALE.cs:6862), credit-note rows when the amount is non-zero (:15909 guard). Decision D1: the header
 * `UPI_AMT` (`CRNT_ADJ_AMT`) is the row sum; a request that also sends a different figure is refused.
 * Duplicate order (book + number) is refused with the desktop text (:7324-7326). An old-metal rate type other
 * than N/F is refused with the desktop text (:7667-7669).
 */
export function resolveSaleTenders<T extends TenderInput>(input: T, fail: (msg: string) => Error): T {
  for (const row of input.oldGold ?? []) {
    const error = oldMetalRateTypeError(row?.rateType);
    if (error) throw fail(error);
  }
  const out: T = { ...input };
  if (input.upiRows) {
    const rows = input.upiRows.filter((r) => text(r?.acCode) !== '' && num(r?.amount) !== 0);
    const sum = r2(rows.reduce((s, r) => s + num(r.amount), 0));
    if (input.upiAmt != null && Math.abs(num(input.upiAmt) - sum) > TOLERANCE)
      throw fail(`upiAmount ${r2(num(input.upiAmt)).toFixed(2)} differs from the UPI rows total ${sum.toFixed(2)}`);
    out.upiRows = rows;
    out.upiAmt = sum;
  }
  if (input.creditNotes) {
    const rows = input.creditNotes.filter((r) => num(r?.amount) !== 0);
    const sum = r2(rows.reduce((s, r) => s + num(r.amount), 0));
    if (
      input.currentAdjustmentAmount != null &&
      Math.abs(num(input.currentAdjustmentAmount) - sum) > TOLERANCE
    )
      throw fail(
        `currentAdjustmentAmount ${r2(num(input.currentAdjustmentAmount)).toFixed(2)} differs from the credit-note rows total ${sum.toFixed(2)}`,
      );
    out.creditNotes = rows;
    out.currentAdjustmentAmount = sum;
  }
  const orders: SaleOrderRow[] = input.orders
    ? input.orders.filter((r) => text(r?.ordNo) !== '' && (r.amount == null || num(r.amount) !== 0))
    : input.orderRef?.ordNo != null && text(input.orderRef.ordNo) !== ''
      ? [{ ordNo: input.orderRef.ordNo, amount: input.orderRef.adjustAmt, ordBook: input.orderRef.ordBook }]
      : [];
  const seen = new Set<string>();
  for (const row of orders) {
    const id = `${text(row.ordBook) || 'SOR'}|${formatVoucherNo(text(row.ordNo))}`;
    if (seen.has(id)) throw fail('Duplicate Order No');
    seen.add(id);
  }
  out.orders = orders;
  return out;
}

export interface CheckedOrderRow {
  ordNo: string;
  amount: number;
  ordBook: string;
  ordYear: string;
  ordLc: string;
  ordAcCode: string;
  ordHdVchNo: string;
}

/**
 * Check each order row against the order's open advance, locking the order (same lock as the order cancel, so a
 * sale and a cancel never use one advance twice). The desktop has no lock (single user); a row asking more than
 * is open is a 409 conflict (hosted-service safety add, cases.md `concurrency.order-advance-double-use`).
 * A legacy `orderRef` without an amount takes the open advance up to `remaining` (the old web behaviour).
 */
export async function checkSaleOrdersTx(
  tx: any,
  scope: VoucherScope,
  rows: readonly SaleOrderRow[],
  remaining: number,
  fail: (msg: string) => Error,
): Promise<CheckedOrderRow[]> {
  const out: CheckedOrderRow[] = [];
  let left = remaining;
  for (const row of rows) {
    const ordNo = formatVoucherNo(text(row.ordNo));
    const order = await openAdvanceOfOrderTx(tx, scope, ordNo, text(row.ordBook) || 'SOR');
    if (!order) throw fail(`sales order #${ordNo} not found`);
    const amount = r2(row.amount == null ? Math.max(0, Math.min(order.openAmt, left)) : num(row.amount));
    if (amount > order.openAmt + TOLERANCE)
      throw new SessionCommandError(
        'order-advance-conflict',
        409,
        `order ${ordNo} has ${order.openAmt.toFixed(2)} advance open; ${amount.toFixed(2)} cannot be adjusted`,
      );
    left = r2(left - amount);
    if (amount === 0) continue;
    out.push({
      ordNo,
      amount,
      ordBook: text(row.ordBook) || order.ordBook,
      ordYear: text(row.ordYear) || order.ordYear,
      ordLc: text(row.ordLc) || scope.lcCode,
      ordAcCode: text(row.ordAcCode) || order.acCode,
      ordHdVchNo: text(row.ordHdVchNo) || order.hdVchNo,
    });
  }
  return out;
}

export interface TenderBase {
  key: Record<string, unknown>;
  vchDate: Date;
  vchTime: unknown;
  hdVchNo: string;
  acCode: string;
  acName: string;
  vchType: string;
  inout: string;
  bookName: string;
  empCode: string;
  mainUser: string;
}

/** The `UPI_DATA`, `CRNT_DATA` and `SL_ORD_ADJ` rows of the voucher, column for column as TR_SALE writes them. */
export function saleTenderWrites(
  base: TenderBase,
  upiRows: readonly SaleUpiRow[],
  creditNotes: readonly SaleCreditNoteRow[],
  orders: readonly CheckedOrderRow[],
): Array<{ table: string; rows: Record<string, unknown>[] }> {
  const voucher = {
    ...base.key,
    VCH_DATE: base.vchDate,
    HD_VCH_NO: base.hdVchNo,
    AC_CODE: base.acCode,
    AC_NAME: base.acName,
    VCH_TYPE: base.vchType,
    INOUT_TYPE: base.inout,
    ENTRY_TYPE: 'S',
    BOOK_NAME: base.bookName,
  };
  // TR_SALE.cs:15861-15869 (UPI_DATA carries no name/type/book columns of the voucher).
  const upi = upiRows.map((r, i) => ({
    ...base.key,
    SR_NO: i + 1,
    ISR_NO: 0,
    AC_CODE: base.acCode,
    VCH_DATE: base.vchDate,
    VCH_TIME: base.vchTime,
    UPI_AC_CODE: text(r.acCode),
    UPI_AC_NAME: text(r.acName),
    UPI_TYPE: text(r.type),
    UPI_ID: text(r.upiId),
    UPI_AMT: r2(num(r.amount)),
  }));
  // TR_SALE.cs:15893-15918.
  const crnt = creditNotes.map((r, i) => ({
    ...voucher,
    SR_NO: i + 1,
    CRNT_HD_VCH_NO: text(r.crntHdVchNo),
    CRNT_NO: text(r.crntNo),
    CRNT_LC: text(r.crntLc),
    CRNT_YRCD: text(r.crntYear),
    CRNT_DBCD: text(r.crntBook),
    CRNT_AC_CODE: text(r.crntAcCode),
    CRNT_AMT: r2(num(r.amount)),
    VCH_TIME: base.vchTime,
    DATA_TRFR: 'N',
    EMP_CODE: base.empCode,
    MAIN_USER: base.mainUser,
  }));
  // TR_SALE.cs:15695-15727, decision D2: ORD_SIGN '-', ORD_AMT, PAID_AMT 0, ENTRY_TYPE 'S', one row per order.
  const ord = orders.map((r, i) => ({
    ...voucher,
    SR_NO: i + 1,
    ORD_HD_VCH_NO: r.ordHdVchNo,
    ORD_NO: r.ordNo,
    ORD_LC: r.ordLc,
    ORD_YRCD: r.ordYear,
    ORD_DBCD: r.ordBook,
    ORD_AC_CODE: r.ordAcCode,
    ORD_SIGN: '-',
    ORD_AMT: r.amount,
    PAID_AC: '',
    PAID_AMT: 0,
    ORD_BAL_AMT: 0,
    ORD_GOLD: 0,
    ORD_SILVER: 0,
    KASAR_AMT: 0,
    VCH_TIME: base.vchTime,
    DATA_TRFR: 'N',
    EMP_CODE: base.empCode,
    IT_DESC: '',
    MAIN_USER: base.mainUser,
  }));
  return [
    ...(upi.length ? [{ table: 'UPI_DATA', rows: upi }] : []),
    ...(crnt.length ? [{ table: 'CRNT_DATA', rows: crnt }] : []),
    ...(ord.length ? [{ table: 'SL_ORD_ADJ', rows: ord }] : []),
  ];
}

/** `SL_IDTL` columns a stone row carries beyond the voucher key (TR_SALE.cs:15583-15620). */
const STONE_COLUMNS = [
  'TAG_NO', 'VCH_SRNO', 'ISR_NO', 'IT_CODE', 'IT_TYPE', 'DM_CODE', 'DM_SIZE', 'DM_SFNO', 'DM_LEB', 'IT_PCS', 'IT_PCS_WT', 'KR_WT',
  'KR_LESS_PRC', 'IT_GWT', 'IT_CON_PRC', 'IT_CON_WT', 'IT_RATE_TYPE', 'IT_RATE', 'IT_AMT', 'IT_LBR_RATE',
  'IT_LBR_AMT', 'IT_NET_AMT', 'KR_CON_PRC', 'KR_CON_WT', 'KR_RATE', 'KR_AMT', 'KR_LBR_RATE', 'KR_LBR_AMT',
  'KR_NET_AMT', 'DM_ORIGIN', 'DM_REMARK', 'DM_COLOR', 'DM_NAME', 'KR_RATE_TYPE', 'IT_DISC_PRC', 'IT_DISC_AMT',
  'OLD_VCH_NO', 'NEW_VCH_NO', 'MAIN_USER',
] as const;

/** A line's stone rows as the request carries them back (from `getSale`), rebuilt on the voucher key. */
export function stoneRowsFor(
  stones: readonly Record<string, unknown>[],
  line: Record<string, unknown>,
): Record<string, unknown>[] {
  return stones.map((stone) => {
    const row: Record<string, unknown> = { ...line };
    for (const column of STONE_COLUMNS) if (column in stone) row[column] = stone[column] ?? null;
    return row;
  });
}

/**
 * The web's own `SL_IDTL` row for a tagged line (one per tag, ISR_NO 1, the line's item, no stone code) is
 * rebuilt by the writer; every other `SL_IDTL` row is a stone row the line carries back unchanged (TR_SALE.cs:14670).
 */
export function stonesByLine(
  idtl: readonly Record<string, unknown>[],
  lines: ReadonlyArray<{ srNo: number; tagNo: string; itCode: string }>,
): Map<number, Record<string, unknown>[]> {
  const out = new Map<number, Record<string, unknown>[]>();
  for (const row of idtl) {
    const tag = text(row.TAG_NO);
    const own = lines.some((l) => l.tagNo !== '' && l.tagNo === tag && l.itCode === text(row.IT_CODE));
    if (own && num(row.ISR_NO) === 1 && text(row.DM_CODE) === '') continue;
    const srNo = num(row.SR_NO);
    const stone: Record<string, unknown> = {};
    for (const column of STONE_COLUMNS) stone[column] = row[column] ?? null;
    out.set(srNo, [...(out.get(srNo) ?? []), stone]);
  }
  return out;
}

/** Header columns an unchanged save must not touch even though the writer computes them (decision D8). */
const CARRIED = new Set(['VCH_TIME', 'DATA_TRFR', 'USER_UPDATE', 'USER_DELETE', 'RE_TRFR', 'MOB_ENTRY_SAVE', 'CARD_ADJ']);
/** Desktop-computed columns the web has no calculation for (member commission, TR_SALE.cs:15265-15266): an edit
 * keeps the stored value rather than writing 0. */
const KEPT = ['AC_MEMB_COM_PRC', 'AC_MEMB_COM_VAL'];

const same = (a: unknown, b: unknown): boolean => {
  const norm = (v: unknown): string => {
    if (v == null) return '';
    if (v instanceof Date) return v.toISOString();
    if (typeof v === 'number') return v === 0 ? '' : String(round(v, 6));
    if (typeof v === 'object') return norm(Number(String(v)));
    const s = String(v).trim();
    return s;
  };
  const x = norm(a);
  const y = norm(b);
  if (x === y) return true;
  const nx = Number(x || 0);
  const ny = Number(y || 0);
  return x !== '' && y !== '' && Number.isFinite(nx) && Number.isFinite(ny) && Math.abs(nx - ny) < 1e-6;
};

/**
 * Lossless reopen (study gap 1, decision D8): when every column the writer computes equals the stored row, the
 * save is unchanged and the stored row is written back as it was (every column, except the voucher clock the
 * writer already preserves). A changed save keeps the desktop rule: `DATA_TRFR`/`USER_UPDATE`/`USER_DELETE` = N
 * (TR_SALE.cs:15332, :15342) and `RE_TRFR` = Y when the stored voucher was transferred (:15333-15340, :14412-14416).
 */
export function settleEditedHeader(
  header: Record<string, unknown>,
  persisted: Record<string, unknown>,
): 'unchanged' | 'changed' {
  for (const column of KEPT) if (persisted[column] != null) header[column] = persisted[column];
  const changed = Object.keys(header).some(
    (column) => !CARRIED.has(column) && header[column] != null && !same(header[column], persisted[column]),
  );
  if (!changed) {
    for (const [column, value] of Object.entries(persisted)) {
      if (column === 'tenant_id' || column === 'row_id' || column === 'VCH_TIME') continue;
      header[column] = value;
    }
    return 'unchanged';
  }
  const transferred = text(persisted.DATA_TRFR) === 'Y' || text(persisted.RE_TRFR) === 'Y';
  header.RE_TRFR = transferred ? 'Y' : 'N';
  return 'changed';
}

/** Read the residual children of a saved sale (TR_SALE.cs:14670, :14735, :14757, :14812). */
export async function readSaleResidualsTx(tx: any, params: readonly unknown[]) {
  const where = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;
  const upi: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "UPI_DATA" WHERE ${where} ORDER BY "SR_NO","ISR_NO"`,
    ...params,
  );
  const crnt: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "CRNT_DATA" WHERE ${where} ORDER BY "SR_NO"`,
    ...params,
  );
  const ord: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "SL_ORD_ADJ" WHERE ${where} AND "ORD_SIGN"='-' ORDER BY "SR_NO"`,
    ...params,
  );
  // Rows the earlier web writer kept under book ORA (ORD_SIGN 'C', PAID_AMT, NEW_VCH_NO = this sale).
  const legacy: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "ORD_NO","PAID_AMT" FROM "SL_ORD_ADJ"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "NEW_VCH_NO"::text=$6 AND "OLD_VCH_NO"::text=$5 AND "ORD_SIGN"='C' ORDER BY "SR_NO"`,
    ...params,
  );
  const idtl: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "SL_IDTL" WHERE ${where} ORDER BY "SR_NO","ISR_NO"`,
    ...params,
  );
  return {
    upiRows: upi.map((r) => ({
      acCode: text(r.UPI_AC_CODE),
      acName: text(r.UPI_AC_NAME),
      type: text(r.UPI_TYPE),
      upiId: text(r.UPI_ID),
      amount: num(r.UPI_AMT),
    })),
    creditNotes: crnt.map((r) => ({
      crntNo: text(r.CRNT_NO),
      amount: num(r.CRNT_AMT),
      crntLc: text(r.CRNT_LC),
      crntYear: text(r.CRNT_YRCD),
      crntBook: text(r.CRNT_DBCD),
      crntAcCode: text(r.CRNT_AC_CODE),
      crntHdVchNo: text(r.CRNT_HD_VCH_NO),
    })),
    orders: [
      ...ord.map((r) => ({
        ordNo: text(r.ORD_NO),
        amount: num(r.ORD_AMT),
        ordBook: text(r.ORD_DBCD),
        ordYear: text(r.ORD_YRCD),
        ordLc: text(r.ORD_LC),
        ordAcCode: text(r.ORD_AC_CODE),
        ordHdVchNo: text(r.ORD_HD_VCH_NO),
      })),
      ...legacy.map((r) => ({ ordNo: text(r.ORD_NO), amount: num(r.PAID_AMT) })),
    ] as SaleOrderRow[],
    idtl,
  };
}
