import { oldMetalRateTypeError, oldMetalTouchFromAmount, valueOldGoldLine } from '@datacare/core';

/**
 * WP-26 (N243, G255): what the Sales Invoice screen carries beyond its own fields so a reopened voucher saves back
 * unchanged (TR_SALE `DISPLAY_DATA`): the UPI, credit-note and order grids, the member-commission header and the
 * header overrides the reopen used to drop. Kept out of `txn/sales/page.tsx` (size budget).
 */
export interface UpiRow {
  acCode: string;
  acName: string;
  type: string;
  upiId: string;
  amount: string;
}
export interface CreditNoteRow {
  crntNo: string;
  amount: string;
  rest: Record<string, string>;
}
export interface OrderRow {
  ordNo: string;
  ordBook: string;
  amount: string;
  rest: Record<string, string>;
}
export interface SaleResidual {
  memberCommissionAc: string;
  withoutCommissionBill: boolean;
  upiRows: UpiRow[];
  creditNotes: CreditNoteRow[];
  orders: OrderRow[];
}

export const emptySaleResidual = (): SaleResidual => ({
  memberCommissionAc: '',
  withoutCommissionBill: false,
  upiRows: [],
  creditNotes: [],
  orders: [],
});

const s = (v: unknown) => (v == null ? '' : String(v));
const amt = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const n = (v: string) => Number(v || 0);
export const sumRows = (rows: Array<{ amount: string }>) =>
  Math.round(rows.reduce((t, r) => t + n(r.amount), 0) * 100) / 100;

export function saleResidualFromView(view: any): SaleResidual {
  const rest = (row: Record<string, unknown>, skip: string[]) =>
    Object.fromEntries(
      Object.entries(row)
        .filter(([k]) => !skip.includes(k))
        .map(([k, v]) => [k, s(v)]),
    );
  return {
    memberCommissionAc: s(view.memberCommissionAc),
    withoutCommissionBill: !!view.withoutCommissionBill,
    upiRows: (view.upiRows ?? []).map((r: any) => ({
      acCode: s(r.acCode),
      acName: s(r.acName),
      type: s(r.type),
      upiId: s(r.upiId),
      amount: amt(r.amount),
    })),
    creditNotes: (view.creditNotes ?? []).map((r: any) => ({
      crntNo: s(r.crntNo),
      amount: amt(r.amount),
      rest: rest(r, ['crntNo', 'amount']),
    })),
    orders: (view.orders ?? []).map((r: any) => ({
      ordNo: s(r.ordNo),
      ordBook: s(r.ordBook),
      amount: amt(r.amount),
      rest: rest(r, ['ordNo', 'ordBook', 'amount']),
    })),
  };
}

/** The reopened header overrides (rate unfix, tax code) the save sends back (study gap 1, G82 gap 9b). */
export const headerExtraFromView = (view: any): Record<string, string> => ({
  ...(view.rateUnfix ? { rateUnfix: 'Y' } : {}),
  ...(view.taxCode ? { taxCode: String(view.taxCode) } : {}),
});

/** Request fields; grids with rows only, so a voucher without them keeps the legacy single figures. */
export function saleResidualBody(r: SaleResidual) {
  return Object.fromEntries(Object.entries(residualFields(r)).filter(([, v]) => v !== undefined));
}
function residualFields(r: SaleResidual) {
  const upi = r.upiRows.filter((u) => u.acCode.trim() !== '' && n(u.amount) !== 0);
  return {
    memberCommissionAc: r.memberCommissionAc || undefined,
    withoutCommissionBill: r.withoutCommissionBill || undefined,
    upiRows: r.upiRows.length ? upi.map((u) => ({ ...u, amount: n(u.amount) })) : undefined,
    upiAmt: r.upiRows.length ? sumRows(upi) : undefined,
    creditNotes: r.creditNotes.length
      ? r.creditNotes.map((c) => ({ ...c.rest, crntNo: c.crntNo, amount: n(c.amount) }))
      : undefined,
    currentAdjustmentAmount: r.creditNotes.length ? sumRows(r.creditNotes) : undefined,
    orders: r.orders.length
      ? r.orders.map((o) => ({
          ...o.rest,
          ordNo: o.ordNo,
          ordBook: o.ordBook || undefined,
          amount: n(o.amount),
        }))
      : undefined,
  };
}

/** TR_SALE.cs:7324-7326: the same book and order number on another row. */
export const duplicateOrderMessage = (rows: OrderRow[], index: number): string | null =>
  rows.some(
    (r, i) =>
      i !== index &&
      r.ordNo.trim() !== '' &&
      r.ordNo.trim() === rows[index]?.ordNo.trim() &&
      r.ordBook === rows[index]?.ordBook,
  )
    ? 'Duplicate Order No'
    : null;

/** TR_SALE.cs:7667-7669 on the old-metal rate type cell. */
export const oldMetalRateTypeMessage = (value: string) => oldMetalRateTypeError(value);

/**
 * TR_SALE.cs:7965-7993 after an old-metal amount or rate cell: a typed amount with no rate gives the rate, and on a
 * net-wise `OG`/`OS` row the touch is back-calculated from today's rate (two decimals).
 */
export function applyOldMetalAmount<
  T extends {
    itCode: string;
    rateType: string;
    netWt: string;
    touch: string;
    rate: string;
    amount?: string;
  },
>(row: T, today: { gold: number; silver: number }): T {
  const v = valueOldGoldLine({
    netWt: n(row.netWt),
    touch: n(row.touch),
    rate: n(row.rate),
    amount: n(row.amount ?? ''),
    rateType: row.rateType || undefined,
  });
  const touch = oldMetalTouchFromAmount({
    itCode: row.itCode,
    rateType: row.rateType,
    netWt: n(row.netWt),
    amount: v.amount,
    todayGoldRate: today.gold,
    todaySilverRate: today.silver,
  });
  return {
    ...row,
    rate: v.rate ? String(v.rate) : row.rate,
    ...(touch ? { touch: String(touch.touch) } : {}),
  };
}

/** One reopened sale line as the screen's grid row (moved from txn/sales/page.tsx, size budget). */
export function saleLineFromView(line: any): Record<string, unknown> {
  const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
  return {
    stones: line.stones,
    itCode: String(line.itCode ?? ''),
    tagNo: String(line.tagNo ?? ''),
    vchSrno: Number(line.vchSrno ?? 0) || undefined,
    pcs: str(line.pcs),
    grossWt: str(line.grossWt),
    netWt: str(line.netWt),
    touch: str(line.touch),
    rate: str(line.rate),
    making: line.labourType === 'per_gram' ? str(line.labourRate) : '',
    designNo: String(line.designNo ?? ''),
    itmSize: String(line.itmSize ?? ''),
    lessWt: str(line.lessWt),
    lbrPct: str(line.labourPct),
    othAmt: str(line.otherAmount),
    bagWt: str(line.bagWt),
    tagGrossWt: str(line.tagGrossWt),
    tagNetWt: str(line.tagNetWt),
    ghtPct: str(line.ghtPct),
    style: String(line.style ?? ''),
    itemLot: String(line.itemLot ?? ''),
    remark: String(line.remark ?? ''),
    discountPct: str(line.discountPct),
    lineDiscountAmount: str(line.discountAmount),
    ghatAmount: str(line.ghatAmount),
    rateWith: String(line.rateWith ?? ''),
    rateType: String(line.rateType ?? ''),
    tagCost: str(line.tagCost),
    karigarNetWt: str(line.karigarNetWt),
    karigarTouch: str(line.karigarTouch),
    karigarWestPct: str(line.karigarWestPct),
    karigarFine: str(line.karigarFine),
    karigarName: String(line.karigarName ?? ''),
    employeeCode: String(line.employeeCode ?? ''),
    prCode: String(line.prCode ?? ''),
    orderTagStockAdd: String(line.orderTagStockAdd ?? ''),
    designImageId: String(line.designImageId ?? ''),
    hallmarkId2: String(line.hallmarkId2 ?? ''),
    hallmarkId3: String(line.hallmarkId3 ?? ''),
    hallmarkId4: String(line.hallmarkId4 ?? ''),
    hallmarkIdWt: str(line.hallmarkIdWt),
    hallmarkId2Wt: str(line.hallmarkId2Wt),
    hallmarkId3Wt: str(line.hallmarkId3Wt),
    hallmarkId4Wt: str(line.hallmarkId4Wt),
    labourType: line.labourType,
    labourRate: Number(line.labourRate ?? 0) || undefined,
    labourFixed: Number(line.labourFixed ?? 0) || undefined,
    ordNo: String(line.ordNo ?? '') || undefined,
    ordYrcd: String(line.ordYrcd ?? '') || undefined,
    ordDbcd: String(line.ordDbcd ?? '') || undefined,
    ordSrno: Number(line.ordSrno ?? 0) || undefined,
    isuNo: String(line.isuNo ?? '') || undefined,
    isuYrcd: String(line.isuYrcd ?? '') || undefined,
    isuDbcd: String(line.isuDbcd ?? '') || undefined,
    isuSrno: Number(line.isuSrno ?? 0) || undefined,
  };
}
