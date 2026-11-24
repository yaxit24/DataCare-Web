import { round } from '@datacare/core';
import { postVoucherTx } from '../posting/posting.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { openAdvanceOfOrderTx } from './orderCancel.js';
import { SaleValidationError } from './sales.js';

/** The order key of the sale's SL_ORD_ADJ adjustment row. */
type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

/**
 * Advance still available on an order to consume into a sale. The rule is shared with Order Cancel
 * (`openAdvanceOfOrderTx`), so a sale and a cancellation can never use the same advance twice: it counts what earlier
 * sales and cancellations used, including a cancellation's kasar.
 */
export async function orderAdvanceAvailableTx(
  tx: any,
  scope: VoucherScope,
  ordNo: number | string,
  ordBook = 'SOR',
): Promise<{
  custAc: string;
  custName: string | null;
  advance: number;
  available: number;
  ordYear: string;
  ordBook: string;
  hdVchNo: string;
}> {
  const ord = await openAdvanceOfOrderTx(tx, scope, ordNo, ordBook);
  if (!ord) throw new SaleValidationError(`sales order #${ordNo} not found`);
  return {
    custAc: ord.acCode,
    custName: ord.acName || null,
    advance: ord.advAmt,
    available: ord.openAmt,
    ordYear: ord.ordYear,
    ordBook: ord.ordBook,
    hdVchNo: ord.hdVchNo,
  };
}

/** Write an SL_ORD_ADJ row consuming `adjustAmt` of an order's advance into a sale (within the sale's tx).
 *  No ledger here — the sale (createSale) reduces the customer Dr by adjustAmt (the advance is applied).
 *  The money is stored as the desktop sale stores it (TR_SALE.cs:15712-15725): ORD_SIGN '-', the amount in ORD_AMT,
 *  PAID_AMT 0, and the order's own key in ORD_NO / ORD_LC / ORD_YRCD / ORD_DBCD / ORD_HD_VCH_NO, so it nets against the
 *  order's '+' row (TR_SALE_ORD.cs:9503). The row keeps its web ORA key and NEW_VCH_NO / OLD_VCH_NO link to the sale. */
export async function adjustOrderIntoSaleTx(
  tx: any,
  tenantId: string,
  scope: VoucherScope,
  args: {
    saleVchNo: string;
    ordNo: number | string;
    /** The order's own CO_YEAR and CO_BOOK (ORD_YRCD / ORD_DBCD), from `orderAdvanceAvailableTx`. */
    ordYear: string;
    ordBook: string;
    custAc: string;
    custName?: string | null;
    adjustAmt: number;
    vchDate: Date;
    /** ORD_HD_VCH_NO — the order's hidden book number, so the adjustment ties to the exact order row. */
    ordHiddenVchNo?: string | null;
    /** EMP_CODE — varchar(3); the salesperson credited with the order. */
    empCode?: string | null;
  },
): Promise<{ vchNo: number }> {
  const no = await nextVoucherNoTx(tx, { ...scope, coBook: 'ORA' });
  const key: VoucherKey = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear ?? '',
    CO_BOOK: 'ORA',
    VCH_NO: formatVoucherNo(no),
  };
  const row = {
    ...key,
    SR_NO: 1,
    VCH_DATE: args.vchDate,
    VCH_TYPE: 'SADJ',
    INOUT_TYPE: 'O',
    ENTRY_TYPE: 'A',
    BOOK_NAME: 'ORDER ADJUST',
    AC_CODE: args.custAc,
    AC_NAME: args.custName ?? null,
    ORD_NO: formatVoucherNo(args.ordNo),
    ORD_AC_CODE: args.custAc,
    ORD_SIGN: '-',
    ORD_AMT: round(args.adjustAmt, 2),
    PAID_AMT: 0,
    KASAR_AMT: 0,
    ORD_BAL_AMT: 0,
    OLD_VCH_NO: scope.coBook,
    NEW_VCH_NO: args.saleVchNo,
    IT_DESC: `Advance adjusted into sale ${args.saleVchNo}`,
    // TR_SALE_HM.cs carries the full ORDER key on the adjustment so the advance can be traced back to the
    // exact order line: location, year and book alongside the order number, plus its hidden book number.
    ORD_LC: scope.lcCode,
    ORD_YRCD: args.ordYear,
    ORD_DBCD: args.ordBook,
    ORD_HD_VCH_NO: args.ordHiddenVchNo ?? null,
    // Metal advances are tracked separately from the money advance; a pure cash advance leaves both 0,
    // which is what the desktop writes.
    ORD_GOLD: 0,
    ORD_SILVER: 0,
    EMP_CODE: args.empCode ?? null,
  };
  await postVoucherTx(tx, tenantId, {
    ledger: { table: 'AC_DATA', lines: [] },
    writes: [{ table: 'SL_ORD_ADJ', rows: [row] }],
  });
  return { vchNo: no };
}
