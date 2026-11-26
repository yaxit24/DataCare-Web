import type { LedgerLine } from '../posting/posting.js';
import { resolveBookSlotRowsTx } from '../shared/postingAccounts.js';
import { buildOrderRojmel } from '../shared/rojmel.js';
import type { VoucherScope } from '../vouchers/numbering.js';
import * as oldMetal from './salesOrderOldMetal.js';
import { orderHeaderRojmel, orderMoneyLedger } from './salesOrderMoneyPosting.js';
import * as rateCut from './salesOrderRateCutPosting.js';
import type { OrderTender } from './salesOrderTender.js';

const num = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));

/**
 * Every AC_DATA and ROJ_MEL_DATA row an order save writes: Ac_Ledr.Order_Ledr and Ac_Rojmel.Order_Rojmel, which both
 * forms call after every save (`TR_SALE_ORD.cs:9558-9563`, `TR_TOUR_ORD.cs:7609-7614`).
 */
/** Ac_Rojmel.cs:19 {{'00079'}}: the day-book scheme account the desktop writes literally. */
const DESKTOP_SCHEME_AC = '00079';

/**
 * Ledger legs 01-06 and day-book types 01-06 are INSERT ... SELECT statements that join BOOK_DETL with SR_NO = 1
 * (Ac_Ledr.cs:30-40, Ac_Rojmel.cs:11-21), so a book without slot 1 writes none of them. The other legs (ledger 12/13 UPI,
 * day-book 08) do not use that join and still post.
 */
const SLOT_JOINED_LEG_LAST = 6;
const legOfKey = (ledrKey: unknown) => Number(String(ledrKey ?? '').slice(21, 23));
const isSlotJoinedLedgerLeg = (row: object) =>
  Number((row as { legType?: unknown }).legType) <= SLOT_JOINED_LEG_LAST;
const isSlotJoinedRojmelRow = (row: Record<string, unknown>) =>
  legOfKey(row.LEDR_KEY) <= SLOT_JOINED_LEG_LAST;

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
    tender: OrderTender;
    party: { code: string; name: string };
    vchDate: Date;
  },
): Promise<{ ledger: LedgerLine[]; rojmelRows: Record<string, unknown>[] }> {
  const { book, key, header, tender } = order;
  // BOOK_DETL slot 1 names the cash account and gives legs 01-06 and day-book 01-06 their columns. Because the
  // desktop uses a joined SELECT with B.SR_NO=1, a missing slot writes none of those rows (Ac_Ledr.cs:30-40;
  // Ac_Rojmel.cs:11-21). The request's Cash A/c field is not referenced by either routine.
  const slot1 = (
    await resolveBookSlotRowsTx(tx, { ...order.scope, coBook: book.coBook }, 'cash-settlement')
  ).get(1);
  const slot = slot1 && {
    // Day-book type 01 names the slot's account even when there is no cash tender (Ac_Rojmel.cs:11).
    account: slot1.accountCode,
    // Blank slot columns keep the book's own values, as before.
    vchType: slot1.shortName || book.vchType,
    mainBook: slot1.mainBook || book.mainBook,
    dataType: slot1.dataType || book.dataType,
  };
  const postingSlot = slot ?? {
    account: '',
    vchType: book.vchType,
    mainBook: book.mainBook,
    dataType: book.dataType,
  };
  // Ac_Ledr.cs:48-50 gates the old-metal fine mirror leg 10 on the company's trading-fine setting
  // (CO_SET.TRAD_FINE, blank 'N', MS_OPNCOMP.cs:690, :813-816); read it only when those legs can post.
  const tradeFine =
    book.inoutType === 'I' && tender.oldMetal.length
      ? String(
          (
            (await tx.$queryRawUnsafe(
              `SELECT upper(btrim(coalesce("TRAD_FINE"::text,''))) AS trad_fine FROM "CO_SET"
                WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text ORDER BY row_id LIMIT 1`,
              order.scope.tenantId,
              String(order.scope.coCode),
            )) as Array<{ trad_fine: string | null }>
          )[0]?.trad_fine ?? '',
        ) === 'Y'
      : false;
  const ledger: LedgerLine[] = [
    // Order_Ledr 01-06 and 12/13 from the saved header, for both forms.
    ...orderMoneyLedger(key, header, postingSlot, book, tender.upiRows).filter(
      (row) => slot || !isSlotJoinedLedgerLeg(row),
    ),
    // Legs 07-10 (Ac_Ledr.cs:42-50) carry the line's VCH_TIME, HD_VCH_NO and MAIN_USER and BOOK_DATA's columns.
    ...oldMetal
      .orderOldMetalLedger(
        key,
        book.vchType,
        order.party.code,
        tender.oldMetal,
        book.inoutType,
        tradeFine,
      )
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
  // Type 05 (Ac_Rojmel.cs:19) is written for EITHER form whenever the saved SCHM_AMT is not 0, with the
  // desktop's literal scheme account '00079' (no book lookup). A Tour Order's request never carries the
  // scheme (orderTenderOf ignores it), so fall back to that literal rather than dropping the row.
  const schemeAc = tender.schemeAc || (num(header.SCHM_AMT) !== 0 ? DESKTOP_SCHEME_AC : '');
  const rojmelRows = rateCut.withOrderRateCutRojmel(
    [
      // Types 01, 02, 03, 05 and 08 from the saved header.
      ...orderHeaderRojmel(context, header, postingSlot, book, tender.upiRows, schemeAc).filter(
        (row) => slot || !isSlotJoinedRojmelRow(row),
      ),
      // Types 04 and 06, old metal, from the grid (Ac_Rojmel.cs:17-21; BOOK_DETL slot 1's columns).
      ...(slot
        ? buildOrderRojmel(
            {
              ...context,
              vchDate: order.vchDate,
              vchType: slot.vchType,
              bookName: slot.mainBook,
              partyName: order.party.name,
              partyCode: order.party.code,
            },
            {
              advanceContraAc: slot.account,
              bankAc: '',
              advanceAmount: 0,
              chequeAmount: 0,
              oldMetal: oldMetal.orderOldMetalRojmel(tender.oldMetal),
            },
          ).map((row) => ({ ...row, DATA_TYPE: slot.dataType }))
        : []),
    ],
    context,
    header,
    book,
  );
  return { ledger, rojmelRows };
}
