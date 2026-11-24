import type { LedgerLine } from '../posting/posting.js';
import { resolveBookSlotRowsTx } from '../shared/postingAccounts.js';
import { buildOrderRojmel } from '../shared/rojmel.js';
import type { VoucherScope } from '../vouchers/numbering.js';
import * as oldMetal from './salesOrderOldMetal.js';
import { orderHeaderRojmel, orderMoneyLedger } from './salesOrderMoneyPosting.js';
import * as rateCut from './salesOrderRateCutPosting.js';
import type { OrderTender } from './salesOrderTender.js';

/**
 * Every AC_DATA and ROJ_MEL_DATA row an order save writes: Ac_Ledr.Order_Ledr and Ac_Rojmel.Order_Rojmel, which both
 * forms call after every save (`TR_SALE_ORD.cs:9558-9563`, `TR_TOUR_ORD.cs:7609-7614`).
 */
export async function orderPostingRowsTx(
  tx: any,
  order: {
    scope: VoucherScope;
    book: {
      coBook: string;
      mainBook: string;
      vchType: string;
      inoutType: string;
      dataType: string;
    };
    key: { CO_BOOK: string; VCH_NO: string } & Record<string, unknown>;
    header: Record<string, unknown>;
    /** The resolved cash account; an explicit request account wins, as before. */
    cashAc: string;
    tender: OrderTender;
    party: { code: string; name: string };
    vchDate: Date;
  },
): Promise<{ ledger: LedgerLine[]; rojmelRows: Record<string, unknown>[] }> {
  const { book, key, header, tender, cashAc } = order;
  // BOOK_DETL slot 1 names the cash account and gives legs 01-06 and day-book 01-06 their VCH_TYPE, BOOK_NAME and
  // DATA_TYPE (Ac_Ledr.cs:30-40, Ac_Rojmel.cs:11-21). A book without slot 1 falls back to its BOOK_DATA columns.
  const slot1 = (
    await resolveBookSlotRowsTx(tx, { ...order.scope, coBook: book.coBook }, 'cash-settlement')
  ).get(1);
  const slot = {
    // Day-book type 01 names the slot's account even when there is no cash tender (Ac_Rojmel.cs:11).
    account: cashAc || slot1?.accountCode || '',
    vchType: slot1?.shortName || book.vchType,
    mainBook: slot1?.mainBook || book.mainBook,
    dataType: slot1?.dataType || book.dataType,
  };
  const ledger: LedgerLine[] = [
    // Order_Ledr 01-06 and 12/13 from the saved header, for both forms.
    ...orderMoneyLedger(key, header, slot, book, tender.upiRows),
    // Legs 07-10 (Ac_Ledr.cs:42-50) carry the line's VCH_TIME, HD_VCH_NO and MAIN_USER and BOOK_DATA's columns.
    ...oldMetal
      .orderOldMetalLedger(key, book.vchType, order.party.code, tender.oldMetal, book.inoutType)
      .map((leg) => ({
        ...leg,
        VCH_DATE: header.VCH_DATE,
        BOOK_NAME: book.mainBook,
        ENTRY_TIME: header.VCH_TIME,
        HD_VCH_NO: header.HD_VCH_NO,
        MAIN_USER: header.MAIN_USER,
        DATA_TYPE: book.dataType,
      })),
    // Ac_Ledr.cs:53: the rate-cut leg, one-sided as on the desktop (salesOrderRateCutPosting.ts).
    ...rateCut.orderRateCutLedger(key, header, book),
  ];
  const context = {
    scope: {
      coCode: order.scope.coCode,
      lcCode: order.scope.lcCode,
      coYear: order.scope.coYear!,
    },
    key,
    coBook: key.CO_BOOK,
    vchNo: key.VCH_NO,
  };
  // Ac_Rojmel.cs:11 and :23: type 01 only when ADV_AMT is not 0, type 07 when RCUT_FINE is not 0.
  const rojmelRows = rateCut.withOrderRateCutRojmel(
    [
      // Types 01, 02, 03, 05 and 08 from the saved header.
      ...orderHeaderRojmel(context, header, slot, book, tender.upiRows, tender.schemeAc),
      // Types 04 and 06, old metal, from the grid (Ac_Rojmel.cs:17-21; BOOK_DETL slot 1's columns).
      ...buildOrderRojmel(
        {
          ...context,
          vchDate: order.vchDate,
          vchType: slot.vchType,
          bookName: slot.mainBook,
          partyName: order.party.name,
          partyCode: order.party.code,
        },
        {
          advanceContraAc: cashAc,
          bankAc: '',
          advanceAmount: 0,
          chequeAmount: 0,
          oldMetal: oldMetal.orderOldMetalRojmel(tender.oldMetal),
        },
      ).map((row) => ({ ...row, DATA_TYPE: slot.dataType })),
    ],
    context,
    header,
    book,
  );
  return { ledger, rojmelRows };
}
