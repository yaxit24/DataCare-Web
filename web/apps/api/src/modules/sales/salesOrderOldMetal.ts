import { round, roundHalfEven } from '@datacare/core';
import { assertBalanced, type LedgerLine } from '../posting/posting.js';
import type { OrderOldMetalLine } from '../shared/rojmel.js';
import { SaleValidationError } from './sales.js';

/**
 * N225 (G206): the Sales Order's old gold and old silver, as TR_SALE_ORD stores and posts them.
 *
 * - The grid is MSG_OLD (`:3957-4020`): Sr, ItCode, ItName, Pcs, GrWt, OthWt, NetWt, Touch, Fine, RTyp, Rate, NetAmt.
 *   The operator types the item, pieces, gross and other weight, touch, the rate type (N net wise, F fine wise) and
 *   the amount; CommPassTotal_Old (`:4427-4500`) derives the rest.
 * - Save writes a SL_PR_DETL row for each grid row with an item code and a net weight or amount (`:9421-9475`).
 *   SR_NO is the grid row. IT_TYPE and IT_DESC come from the item master (`:4207-4210`).
 * - BILL_TOTAL (`:11345-11365`) sums the rows by item type into OLD_GL_AMT / OLD_GL (type G) and OLD_SL_AMT / OLD_SL
 *   (any other type), and the advance, `MSG2_TOTAL[9,3]`, includes both amounts (`:11368`).
 * - Order_Rojmel keys a valued row `04 + STR(SR_NO)` and an unvalued row with fine `06 + STR(SR_NO)`
 *   (`Ac_Rojmel.cs:17-21`); the shared builder (`buildOrderRojmel`) writes them.
 * - Order_Ledr legs 07-10 (`Ac_Ledr.cs:42-50`) join BOOK_DATA with `BOOK_INOUT = 'I'`. A Sales Order book here is
 *   always 'O' (`resolveOrderBookTx`), so those legs are built only when the book is 'I' and the screen's book never
 *   posts them. They are kept separate and tested so a book that is 'I' posts exactly what the desktop posts.
 *
 * Not built: the 'T' book variant, where the old metal amount is typed in the Old Gold Amt cell and an URD Purchase
 * voucher is opened (`:11080-11195`); and the SL_ORD_ADJ 'O' row with ORD_GOLD / ORD_SILVER (`:9481-9516`).
 */
export const OLD_METAL_RATE_TYPE = 'Please Slelect Rate type = N - Net Wise Or F - Fine Wise';

export interface OrderOldMetalRow {
  /** The grid row (Sr), the line number in SL_PR_DETL.SR_NO and in the ledger and day-book keys. */
  srNo: number;
  itCode: string;
  /** ItName: the item master's name, filled in the writer's transaction. */
  itName: string;
  /** The item master's IT_TYPE ('G' is old gold, any other type counts as old silver). */
  itType: string;
  /** The item group's purchase account, which the ledger legs and the day book name. */
  purchaseAc: string;
  pcs: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  touch: number;
  fine: number;
  rateType: 'N' | 'F';
  rate: number;
  netAmt: number;
}

export interface OldMetalTotals {
  goldAmount: number;
  silverAmount: number;
  goldFine: number;
  silverFine: number;
}

const MAX_ROWS = 50;

const num = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));
const nonNegative = (value: unknown, field: string, line: number): number => {
  const n = num(value);
  if (!Number.isFinite(n) || n < 0)
    throw new SaleValidationError(
      `${field} on old metal line ${line} must be a non-negative number`,
    );
  return n;
};

/**
 * One grid row as CommPassTotal_Old leaves it.
 * - Net weight is gross minus other weight (`:4427-4440`).
 * - Fine is net x touch / 100, three decimals half up, when touch and net weight are set; otherwise the typed fine,
 *   or the net weight when none was typed (`:4455-4472`).
 * - The rate type's basis is the net weight for N and the fine for F. A typed amount gives the rate, rounded to whole
 *   rupees half to even (`Math.Round`); with no amount, a typed rate gives the amount the same way (`:4474-4503`).
 *   A rate that already produces the typed amount is kept as typed.
 */
export function deriveOldMetalRow(input: {
  grossWt: number;
  otherWt: number;
  touch: number;
  fine: number;
  rateType: string;
  rate: number;
  netAmt: number;
}): Pick<OrderOldMetalRow, 'netWt' | 'fine' | 'rateType' | 'rate' | 'netAmt'> {
  if (input.rateType !== 'N' && input.rateType !== 'F')
    throw new SaleValidationError(OLD_METAL_RATE_TYPE);
  const netWt = round(input.grossWt - input.otherWt, 3);
  const fine =
    input.touch !== 0 && netWt !== 0
      ? round((netWt * input.touch) / 100, 3)
      : input.fine !== 0
        ? round(input.fine, 3)
        : netWt;
  const basis = input.rateType === 'N' ? netWt : fine;
  let rate = round(input.rate, 2);
  let netAmt = round(input.netAmt, 2);
  if (basis !== 0) {
    if (netAmt !== 0 && !(rate !== 0 && netAmt === roundHalfEven(basis * rate, 0)))
      rate = roundHalfEven(netAmt / basis, 0);
    else if (netAmt === 0 && rate !== 0) netAmt = roundHalfEven(basis * rate, 0);
  }
  return { netWt, fine, rateType: input.rateType, rate, netAmt };
}

/**
 * The request's old-metal grid. Rows without an item code, or with neither a net weight nor an amount, are not saved
 * (`:9429-9431`). `srNo` is the row's place in the request, as the grid's Sr column.
 */
export function orderOldMetalOf(value: unknown): OrderOldMetalRow[] {
  if (value == null) return [];
  if (!Array.isArray(value) || value.length > MAX_ROWS)
    throw new SaleValidationError(`oldMetalRows must be a list of at most ${MAX_ROWS} rows`);
  return value.flatMap((raw, index): OrderOldMetalRow[] => {
    const row = (raw ?? {}) as Record<string, unknown>;
    const srNo = index + 1;
    const itCode = String(row.itCode ?? '').trim();
    if (itCode.length > 5)
      throw new SaleValidationError(`ItCode on old metal line ${srNo} is longer than 5 characters`);
    const derived = deriveOldMetalRow({
      grossWt: nonNegative(row.grossWt, 'GrWt', srNo),
      otherWt: nonNegative(row.otherWt, 'OthWt', srNo),
      touch: nonNegative(row.touch, 'Touch', srNo),
      fine: nonNegative(row.fine, 'Fine', srNo),
      rateType: String(row.rateType ?? 'F').trim() || 'F',
      rate: nonNegative(row.rate, 'Rate', srNo),
      netAmt: nonNegative(row.netAmt, 'NetAmt', srNo),
    });
    if (!itCode || derived.netWt + derived.netAmt === 0) return [];
    return [
      {
        srNo,
        itCode,
        itName: '',
        itType: '',
        purchaseAc: '',
        pcs: round(nonNegative(row.pcs, 'Pcs', srNo), 0),
        grossWt: round(num(row.grossWt), 3),
        otherWt: round(num(row.otherWt), 3),
        touch: round(num(row.touch), 2),
        ...derived,
      },
    ];
  });
}

/** BILL_TOTAL's old gold and old silver totals (`TR_SALE_ORD.cs:11345-11365`). */
export function oldMetalTotals(rows: readonly OrderOldMetalRow[]): OldMetalTotals {
  const sum = (pick: (row: OrderOldMetalRow) => number, gold: boolean, dp: number) =>
    round(
      rows.filter((row) => (row.itType === 'G') === gold).reduce((all, row) => all + pick(row), 0),
      dp,
    );
  return {
    goldAmount: sum((row) => row.netAmt, true, 2),
    silverAmount: sum((row) => row.netAmt, false, 2),
    goldFine: sum((row) => row.fine, true, 3),
    silverFine: sum((row) => row.fine, false, 3),
  };
}

/** The header columns the totals fill (`:9136-9144`). */
export function oldMetalHeader(rows: readonly OrderOldMetalRow[]) {
  const totals = oldMetalTotals(rows);
  return {
    OLD_GL_AMT: totals.goldAmount,
    OLD_SL_AMT: totals.silverAmount,
    OLD_GL: totals.goldFine,
    OLD_SL: totals.silverFine,
  };
}

/** The old metal's share of ADV_AMT. */
export function oldMetalAdvance(rows: readonly OrderOldMetalRow[]): number {
  const totals = oldMetalTotals(rows);
  return round(totals.goldAmount + totals.silverAmount, 2);
}

/**
 * Each row's item name, type and group purchase account, in the writer's transaction. The desktop picks the item from
 * the item master and joins its group for the purchase account (`:4207-4210`, `Ac_Rojmel.cs:17`). An item that is not
 * in the master, or whose group has no purchase account, would write a day-book row with no account, so the web
 * refuses it where the desktop would insert a blank.
 */
export async function resolveOrderOldMetalTx(
  tx: any,
  scope: { tenantId: string; coCode: string },
  rows: OrderOldMetalRow[],
): Promise<void> {
  for (const row of rows) {
    const [item] = await tx.$queryRawUnsafe(
      `SELECT btrim(i."IT_NAME"::text) AS name, btrim(coalesce(i."IT_TYPE"::text,'')) AS type,
              btrim(coalesce(g."PURC_AC"::text,'')) AS purc
         FROM "ITEM_MAST" i
         LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
        WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND upper(btrim(i."IT_CODE"::text))=upper($3) LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      row.itCode,
    );
    if (!item)
      throw new SaleValidationError(
        `Item ${row.itCode} on old metal line ${row.srNo} is not in the item master`,
      );
    if (!item.purc)
      throw new SaleValidationError(
        `The item group of ${row.itCode} on old metal line ${row.srNo} has no purchase account`,
      );
    row.itName = String(item.name ?? '').slice(0, 50);
    row.itType = String(item.type ?? '').slice(0, 1);
    row.purchaseAc = String(item.purc);
  }
}

/** SL_PR_DETL (`TR_SALE_ORD.cs:9421-9475`): one row per saved grid row. */
export function orderOldMetalWrites(
  key: Record<string, unknown>,
  rows: readonly OrderOldMetalRow[],
  book: { vchType: string; inoutType: string; mainBook: string },
  order: { partyAc: string; vchDate: Date; hdVchNo: string; mainUser: string },
) {
  if (!rows.length) return [];
  return [
    {
      table: 'SL_PR_DETL',
      rows: rows.map((row) => ({
        ...key,
        VCH_DATE: order.vchDate,
        VCH_TIME: order.vchDate,
        HD_VCH_NO: order.hdVchNo,
        AC_CODE: order.partyAc,
        VCH_TYPE: book.vchType,
        INOUT_TYPE: book.inoutType,
        ENTRY_TYPE: 'A',
        BOOK_NAME: book.mainBook,
        SR_NO: row.srNo,
        IT_CODE: row.itCode,
        IT_TYPE: row.itType,
        IT_DESC: row.itName,
        ITM_PCS: row.pcs,
        ITM_GWT: row.grossWt,
        ITM_OTH: row.otherWt,
        ITM_NWT: row.netWt,
        ITM_TOUCH: row.touch,
        ITM_FINE: row.fine,
        ITM_RATE_TYPE: row.rateType,
        ITM_RATE: row.rate,
        NET_AMT: row.netAmt,
        MAIN_USER: order.mainUser,
      })),
    },
  ];
}

/**
 * Order_Ledr legs 07-10 (`Ac_Ledr.cs:42-50`), only for a book whose BOOK_INOUT is 'I'. Keys are
 * `...VCH_NO + STR(SR_NO) + leg`: the line comes before the leg type, the reverse of the UPI legs. A valued row posts
 * 07 (party Cr, purchase account as contra) and 08 (purchase account Dr). A row with fine and no amount posts the
 * money-free fine pair 09 (SIGN +) and 10 (SIGN -), carrying ITM_FINE as FINE_WT. BILL_NO is blank on these legs.
 */
export function orderOldMetalLedger(
  key: Record<string, unknown>,
  vchType: string,
  partyAc: string,
  rows: readonly OrderOldMetalRow[],
  bookInout: string,
): LedgerLine[] {
  if (bookInout !== 'I') return [];
  const legs: LedgerLine[] = [];
  const suffix = (row: OrderOldMetalRow, leg: string) => `${String(row.srNo).padStart(10)}${leg}`;
  for (const row of rows) {
    const base = { ...key, VCH_TYPE: vchType, BILL_NO: '', CHQ_NO: '', LDR_NAME: '', FINE_RATE: 0 };
    if (row.netAmt) {
      legs.push(
        {
          ...base,
          legKeySuffix: suffix(row, '07'),
          AC_CODE: partyAc,
          LD_CODE: row.purchaseAc,
          CR_AMT: row.netAmt,
          DR_AMT: 0,
          IT_TYPE: 'A',
          SIGN: '',
          FINE_WT: 0,
          PARTY_AC_CODE: partyAc,
        },
        {
          ...base,
          legKeySuffix: suffix(row, '08'),
          AC_CODE: row.purchaseAc,
          LD_CODE: partyAc,
          CR_AMT: 0,
          DR_AMT: row.netAmt,
          IT_TYPE: 'A',
          SIGN: '',
          FINE_WT: 0,
          PARTY_AC_CODE: '',
        },
      );
    } else if (row.fine) {
      legs.push(
        {
          ...base,
          legKeySuffix: suffix(row, '09'),
          AC_CODE: partyAc,
          LD_CODE: row.purchaseAc,
          CR_AMT: 0,
          DR_AMT: 0,
          IT_TYPE: row.itType,
          SIGN: '+',
          FINE_WT: row.fine,
          PARTY_AC_CODE: partyAc,
        },
        {
          ...base,
          legKeySuffix: suffix(row, '10'),
          AC_CODE: row.purchaseAc,
          LD_CODE: partyAc,
          CR_AMT: 0,
          DR_AMT: 0,
          IT_TYPE: row.itType,
          SIGN: '-',
          FINE_WT: row.fine,
          PARTY_AC_CODE: '',
        },
      );
    }
  }
  if (legs.length) assertBalanced(legs);
  return legs;
}

/** The rows as `buildOrderRojmel` takes them: type 04 for a valued row, type 06 for fine with no amount. */
export function orderOldMetalRojmel(rows: readonly OrderOldMetalRow[]): OrderOldMetalLine[] {
  return rows.map((row) => ({
    lineNo: row.srNo,
    purchaseAc: row.purchaseAc,
    netAmount: row.netAmt,
    metal: row.itType as OrderOldMetalLine['metal'],
    pcs: row.pcs,
    grossWt: row.grossWt,
    netWt: row.netWt,
    touch: row.touch,
    fine: row.fine,
    itemCode: row.itCode,
    itemName: row.itName,
  }));
}

/** An edit rewrites SL_PR_DETL, so an order with old metal must send its rows; omission never deletes them. */
export function assertOldMetalRowsSent(
  saved: readonly unknown[],
  input: { oldMetalRows?: unknown },
): void {
  if (saved.length && input.oldMetalRows === undefined)
    throw new SaleValidationError(
      'This order has old metal rows. Reload it and submit its old metal rows before editing.',
    );
}

/** The reopened order's grid rows. */
export function orderOldMetalView(saved: ReadonlyArray<Record<string, any>>) {
  return [...saved]
    .sort((a, b) => num(a.SR_NO) - num(b.SR_NO))
    .map((row) => ({
      srNo: num(row.SR_NO),
      itCode: String(row.IT_CODE ?? '').trim(),
      itName: String(row.IT_DESC ?? '').trim(),
      itType: String(row.IT_TYPE ?? '').trim(),
      pcs: num(row.ITM_PCS),
      grossWt: num(row.ITM_GWT),
      otherWt: num(row.ITM_OTH),
      netWt: num(row.ITM_NWT),
      touch: num(row.ITM_TOUCH),
      fine: num(row.ITM_FINE),
      rateType: String(row.ITM_RATE_TYPE ?? '').trim() || 'F',
      rate: num(row.ITM_RATE),
      netAmt: num(row.NET_AMT),
    }));
}
