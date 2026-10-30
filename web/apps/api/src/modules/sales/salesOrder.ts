import { withTxBudget, SNAPSHOT_READ, type TxBudgetPrisma, type Tx } from '../shared/txBudget.js';
import { withSessionContextCommand } from '../auth/sessionContextCommand.js';
import { createHash } from 'node:crypto';
import {
  readStoneSubDetail,
  stoneSubDetailColumns,
  type StoneSubDetailInput,
} from '../shared/stoneSubDetail.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  assertBalanced,
  reverseVoucherTx,
  assertPeriodOpen,
  insertRowTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  billTotals,
  orderLabourAmount,
  orderLabourTransition,
  orderLabourReplay,
  orderLabourWithCache,
  round,
  type OrderLabourEdit,
  type OrderLabourAction,
  type OrderLabourPolicy,
  type OrderLabourState,
  applySalesOrderDesignSelection,
  clearSalesOrderDesignSelection,
  type SalesOrderDesignEvent,
} from '@datacare/core';
import { SaleValidationError } from './sales.js';
import { fineWt } from '../shared/fine.js';
import { resolveSalesOrderDesignTx } from './orderDesignSelection.js';
import { resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import { kasarAccountTx } from '../finance/finance.js';
import {
  orderDate,
  orderClock,
  salesOrderFiscalConfigurationTx,
  assertSalesOrderDateTx,
  preserveOrderRow,
  preserveOrderInputRow,
  orderDirtyColumns,
  exactOrderValues,
  ORDER_HEADER_FIELDS,
  ORDER_PARENT_FIELDS,
  ORDER_COMPONENT_FIELDS,
} from './orderLifecyclePolicy.js';
import { buildOrderRojmel } from '../shared/rojmel.js';
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';

/**
 * Sales order (TR_SALE_ORD.cs): a customer order placed for later fulfilment. It is NOT a sale —
 * no income is recognised. We record the order header in SL_ORD_DATA. If an advance is taken, that
 * IS a money movement, posted balanced: Dr CASH / Cr customer (advance liability). Order book 'SOR'.
 */

export interface SalesOrderInput {
  dirtyFields?: string[];
  /** Trusted HTTP adapter policy; never copy this flag from caller JSON. */
  requireDesignSelection?: boolean;
  scope: VoucherScope;
  /** Snapshot returned by GET; checked under the persisted-header lock before mutation. */
  expectedVersion?: string;
  vchDesc?: string;
  /** Voucher wall-clock time, independent of the API process timezone. */
  vchTime?: string;
  acCode: string;
  acName?: string;
  billNo?: string;
  netAmount?: number;
  lines?: SalesOrderLine[];
  taxRatePct: number;
  interState?: boolean;
  advanceAmount?: number;
  vchDate?: Date | string;
  cashAc?: string;
  mainUser?: string;
  /** Desktop FormMainBook mode: Sales Order uses SALES ORDER; Tour Order uses TOUR ORDER. */
  orderMainBook?: OrderMainBook;
  // Desktop SL_ORD_DATA header fields (TR_SALE_ORD.cs:9120-9161).
  taxCode?: string; // MSG2_TOTAL[1,4] :9120
  upiAmount?: number; // MSG2_TOTAL[3,1] :9141
  bankAc?: string; // MSG2_TOTAL[4,4] :9149
  chequeNo?: string; // MSG2_TOTAL[4,2] :9150
  bankName?: string; // tBankName.Text  :9151
  cardAc?: string; // MSG2_TOTAL[5,4] :9148
  cardAdj?: string; // CardCommAdj     :9154
  oldGoldFine?: number; // MSG2_TOTAL[6,2]+[9,2] :9143
  oldGoldAmount?: number; // MSG2_TOTAL[6,3] :9136
  oldSilverFine?: number; // MSG2_TOTAL[7,2] :9144
  oldSilverAmount?: number; // MSG2_TOTAL[7,3] :9137
  schemeAmount?: number; // MSG2_TOTAL[8,3] :9142
  rateCutRate?: number; // MSG2_TOTAL[9,1] :9134
  rateCutFine?: number; // MSG2_TOTAL[9,2] :9135
  rateCutAmount?: number; // MSG2_TOTAL[9,3] :9126
  adjustGold?: number; // AdjGold      :9146
  adjustSilver?: number; // AdjSilver    :9147
  orderAdjustAmount?: number; // RecAdjAmt    :9145
  deliveryDate?: Date | string; // DEL_DATE     :9152
  functionDate?: Date | string; // FUN_DATE     :9153
  address1?: string; // tAdd1.Text   :9157
  address2?: string; // tAdd2.Text   :9158
  address3?: string; // tAdd3.Text   :9159
  city?: string; // tCity.Text   :9160
  mobile?: string; // tMobile.Text :9161
  empCode?: string; // tEmpCode.Text (detail) :9296
}

export type SalesOrderEdit =
  | SalesOrderDesignEvent
  | { kind: 'field'; field: string; value: string | number }
  | { kind: 'labour'; edit: OrderLabourEdit };

/** A sales-order line (weight-based, like a sale line). */
export interface SalesOrderLine {
  dirtyFields?: string[];
  /** Persisted parent identity; reopening a voucher must not renumber its child references. */
  srNo?: number;
  /** Independent SL_ORD_IDTL rows. Omitted preserves compatibility with flattened clients. */
  components?: OrderComponent[];
  itCode: string;
  designNo?: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  rate?: number;
  making?: number; // legacy per-gram making alias
  labourAmount?: number; // persisted LBR_AMT, including manual paise
  labourEdits?: OrderLabourEdit[];
  /** Ordered F1/field/labour commits, replayed from a locked saved parent or new-row defaults. */
  orderEdits?: SalesOrderEdit[];
  labourAction?: OrderLabourAction; // latest operator-committed labour cell
  remark?: string;
  /** Read-only imported tag identity; assigning stock to an order uses a separate workflow. */
  tagNo?: string;
  // Desktop SL_ORD_DETL grid columns (TR_SALE_ORD.cs `mSG[i, c]`).
  tblCode?: string; // mSG[i,3]  :9216
  itmColor?: string; // mSG[i,5]  :9218
  itmSize?: string; // mSG[i,6]  :9219
  bagWt?: number; // mSG[i,7]  :9220
  lessWt?: number; // mSG[i,10] :9223 (ITM_OTH_WT)
  ghtPct?: number; // mSG[i,12] :9225
  rateFix?: string; // mSG[i,17] :9237
  labourPct?: number; // mSG[i,20] :9230
  labourType?: string; // mSG[i,21] :9231
  labourRate?: number; // mSG[i,22] :9232
  otherAmount?: number; // mSG[i,24] :9234
  mrp?: number; // mSG[i,25] :9249
  orderDeliveryDate?: Date | string; // mSG[i,26] :9290
  karigarNetWt?: number; // mSG[i,32] :9254
  karigarTouch?: number; // mSG[i,35] :9255
  karigarWestPct?: number; // mSG[i,36] :9256
  karigarFine?: number; // mSG[i,37] :9257
  karigarName?: string; // mSG[i,30] :9258

  // ---- Stone / diamond sub-detail (SL_ORD_IDTL) -------------------------------------------------
  // TR_SALE_ORD.cs fills SL_ORD_IDTL from its `DtIdtl` grid, one row per stone under the item line.
  // Column indices are the DtIdtl ordinals the desktop reads (`DtIdtl.Rows[i][n]`).
  dmCode?: string; // DtIdtl[3]  -> DM_CODE
  dmName?: string; // DtIdtl[4]  -> DM_NAME
  dmSize?: string; // DtIdtl[5]  -> DM_SIZE
  dmSfNo?: string; // DtIdtl[6]  -> DM_SFNO
  dmColor?: string; // DM_COLOR
  dmOrigin?: string; // DM_ORIGIN
  dmRemark?: string; // DM_REMARK
  dmLeb?: string; // DM_LEB (certificate/lab)
  stonePcsWt?: number; // IT_PCS_WT
  stoneConPct?: number; // DtIdtl[9]  -> IT_CON_PRC
  stoneConWt?: number; // DtIdtl[16] -> IT_CON_WT
  stoneRateType?: string; // DtIdtl[10] -> IT_RATE_TYPE
  stoneRate?: number; // DtIdtl[11] -> IT_RATE
  stoneLabourRate?: number; // DtIdtl[13] -> IT_LBR_RATE
  stoneLabourAmount?: number; // DtIdtl[14] -> IT_LBR_AMT
  stoneKarigarWt?: number; // DtIdtl[17] -> KR_WT
  stoneKarigarLessPct?: number; // KR_LESS_PRC
  stoneKarigarConPct?: number; // KR_CON_PRC
  stoneKarigarConWt?: number; // KR_CON_WT
  stoneKarigarRate?: number; // KR_RATE
  stoneKarigarAmount?: number; // KR_AMT
  stoneKarigarLabourRate?: number; // KR_LBR_RATE
  stoneKarigarLabourAmount?: number; // KR_LBR_AMT
  stoneKarigarNetAmount?: number; // KR_NET_AMT
  tagCost?: number; // mSG[i,43] :9250
  vchSrno?: number; // mSG[i,42] :9262
  oldSrNo?: number; // mSG[i,47] :9205
  rateType?: string; // mSG[i,48] :9259
  itType?: string; // mSG[i,49] :9260
  prCode?: string; // mSG[i,51] :9261
  oldTblCode?: string; // mSG[i,69] :9266
  tagStockLess?: string; // mSG[i,70] :9267
  designImageId?: string; // mSG[i,71] :9297
  huid?: string; // mSG[i,72] :9298
  hallmarkId2?: string; // mSG[i,73] :9299
  hallmarkId3?: string; // mSG[i,74] :9300
  hallmarkId4?: string; // mSG[i,75] :9301
  hallmarkIdWt?: number; // mSG[i,76] :9302
  hallmarkId2Wt?: number; // mSG[i,77] :9303
  hallmarkId3Wt?: number; // mSG[i,78] :9304
  hallmarkId4Wt?: number; // mSG[i,79] :9305
}

export interface OrderComponent extends StoneSubDetailInput {
  dirtyFields?: string[];
  isrNo?: number;
  itCode: string;
  itType?: string;
  pcs?: number;
  grossWt?: number;
  amount?: number;
  lbrRate?: number;
  lbrAmount?: number;
  netAmount?: number;
}

export class SalesOrderConflictError extends Error {
  constructor() {
    super('Order changed since it was loaded; reload before saving or deleting.');
    this.name = 'SalesOrderConflictError';
  }
}

function orderRowNumbers(rows: readonly Record<string, any>[], key: 'srNo' | 'isrNo'): number[] {
  const specified = rows.filter((row) => row[key] != null).map((row) => Number(row[key]));
  if (
    specified.some((value) => !Number.isSafeInteger(value) || value <= 0) ||
    new Set(specified).size !== specified.length
  )
    throw new SaleValidationError(`${key} must contain unique positive row numbers`);
  let next = Math.max(0, ...specified);
  return rows.map((row) => (row[key] == null ? ++next : Number(row[key])));
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
export type OrderMainBook = 'SALES ORDER' | 'TOUR ORDER';

type OrderBookMode = {
  mainBook: OrderMainBook;
  defaultCoBook: string;
  defaultVchType: string;
  defaultInoutType: string;
};

type ResolvedOrderBook = {
  mainBook: OrderMainBook;
  coBook: string;
  bookName: string;
  vchType: string;
  inoutType: string;
};

const ORDER_BOOK_MODES: Record<OrderMainBook, OrderBookMode> = {
  'SALES ORDER': {
    mainBook: 'SALES ORDER',
    defaultCoBook: 'SOR',
    defaultVchType: 'SORD',
    defaultInoutType: 'O',
  },
  'TOUR ORDER': {
    mainBook: 'TOUR ORDER',
    defaultCoBook: '510',
    defaultVchType: 'TUROD',
    defaultInoutType: 'I',
  },
};

const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

function requestedMode(input?: OrderMainBook): OrderBookMode {
  return ORDER_BOOK_MODES[input ?? 'SALES ORDER'];
}

function keyOf(s: VoucherScope, vchNo: number, defaultCoBook = 'SOR'): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? defaultCoBook,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

async function resolveOrderBookTx(
  tx: any,
  scope: VoucherScope,
  mode: OrderBookMode,
): Promise<ResolvedOrderBook> {
  completeOrderScope(scope);
  const coBook = scope.coBook;
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","BOOK_INOUT","MAIN_BOOK","BOOK_TBL_NAME"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    coBook,
  );
  if (rows.length > 1)
    throw new SaleValidationError(`${mode.mainBook} book configuration is ambiguous: ${coBook}`);
  const row = rows[0];
  if (!row)
    throw new SaleValidationError(`${mode.mainBook} book configuration not found for ${coBook}`);
  const actualMainBook = text(row.MAIN_BOOK).toUpperCase();
  if (actualMainBook !== mode.mainBook)
    throw new SaleValidationError(
      `expected ${mode.mainBook} book, got ${actualMainBook || 'blank'}`,
    );
  const table = text(row.BOOK_TBL_NAME).toUpperCase();
  if (table && table !== 'SL_ORD_DATA')
    throw new SaleValidationError(`${mode.mainBook} book must write SL_ORD_DATA, got ${table}`);
  const inout = text(row.BOOK_INOUT).toUpperCase();
  if (inout && inout !== mode.defaultInoutType)
    throw new SaleValidationError(
      `${mode.mainBook} book direction must be ${mode.defaultInoutType}`,
    );
  return {
    mainBook: mode.mainBook,
    coBook,
    bookName: text(row.BOOK_NAME) || mode.mainBook,
    vchType: text(row.BOOK_SNAME) || mode.defaultVchType,
    inoutType: text(row.BOOK_INOUT) || mode.defaultInoutType,
  };
}

/** Scoped order settings: amount precision is always0; LBR_ROF affects derived rates only. */
async function orderLabourConfigurationTx(tx: any, scope: VoucherScope) {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "LBR_WITH_GHT" FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
  const settings: any[] = await tx.$queryRawUnsafe(
    `SELECT "LBR_ROF","ALL_ROF_REMOVE" FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    scope.tenantId,
    scope.coCode,
  );
  if (rows.length > 1 || settings.length > 1)
    throw new SaleValidationError('order labour settings are ambiguous');
  const flag = text(rows[0]?.LBR_WITH_GHT).toUpperCase();
  const remove = text(settings[0]?.ALL_ROF_REMOVE).toUpperCase();
  if (flag && !['Y', 'N'].includes(flag))
    throw new SaleValidationError('invalid order labour ghat setting');
  if (remove && !['Y', 'N'].includes(remove))
    throw new SaleValidationError('invalid order rounding setting');
  // Missing legacy setting retains the documented web2dp default; it is not desktop evidence.
  const raw = settings[0]?.LBR_ROF;
  let decimals = raw == null ? 2 : Number(raw);
  if (!Number.isInteger(decimals) || decimals < 0)
    throw new SaleValidationError('order labour rate precision must be a nonnegative integer');
  if (decimals > 3) decimals = 0; // MS_OPNCOMP:817–819
  if (remove === 'Y') decimals = 2; // MS_OPNCOMP:1297–1303
  return { labourIncludesGhat: flag !== 'N', labourRateDecimals: decimals };
}

export async function getSalesOrderConfiguration(prisma: any, scope: VoucherScope) {
  completeOrderScope(scope);
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx: any) => {
    await resolveOrderBookTx(tx, scope, requestedMode('SALES ORDER'));
    return {
      ...(await orderLabourConfigurationTx(tx, scope)),
      ...(await salesOrderFiscalConfigurationTx(tx, scope)),
    };
  });
}

export async function getTourOrderConfiguration(prisma: any, scope: VoucherScope) {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveOrderBookTx(tx, scope, requestedMode('TOUR ORDER'));
    return orderLabourConfigurationTx(tx, scope);
  });
}

function persistedLabour(row?: Record<string, any>): OrderLabourState {
  return {
    labourType: text(row?.LBR_TYPE),
    pcs: n(row?.ITM_PCS),
    grossWt: n(row?.ITM_GWT),
    netWt: n(row?.ITM_NWT),
    ghatWt: n(row?.ITM_GHT_WT),
    itemRate: n(row?.ITM_RATE),
    labourPct: n(row?.LBR_PRC),
    labourRate: n(row?.LBR_RATE),
    labourAmount: n(row?.LBR_AMT),
  };
}

function calculateOrderLine(
  line: SalesOrderLine,
  prior: Record<string, any> | undefined,
  policy: OrderLabourPolicy,
  exactLabour?: OrderLabourState,
) {
  const previous = persistedLabour(prior);
  const oldMakingBase = previous.netWt + (policy.includesGhat ? previous.ghatWt : 0);
  const oldMaking = oldMakingBase ? previous.labourAmount / oldMakingBase : 0;
  const legacyMakingChanged =
    line.labourAction == null &&
    line.labourAmount == null &&
    (line.labourRate == null || (prior && n(line.labourRate) === previous.labourRate)) &&
    line.making != null &&
    (!prior || n(line.making) !== oldMaking);
  const next: OrderLabourState = {
    labourType: text(line.labourType),
    pcs: n(line.pcs),
    grossWt: n(line.grossWt),
    netWt: n(line.netWt),
    ghatWt: n(line.ghtWt),
    itemRate: n(line.rate),
    labourPct: n(line.labourPct),
    labourRate: legacyMakingChanged
      ? n(line.making)
      : n(line.labourRate ?? line.making ?? prior?.LBR_RATE),
    labourAmount: line.labourAmount == null ? previous.labourAmount : n(line.labourAmount),
  };
  let action = line.labourAction;
  if (action != null && !['rate', 'percentage', 'amount'].includes(action))
    throw new SaleValidationError('invalid order labour action');
  if (!action) {
    if (line.labourAmount != null && next.labourAmount !== previous.labourAmount) action = 'amount';
    else if (next.labourRate !== previous.labourRate) action = 'rate';
    else if (next.labourPct !== previous.labourPct) action = 'percentage';
  }
  // Rate/percentage previews are not manual amount edits. Re-run the actual source trigger against
  // the locked persisted values; changing only a remark, component or basis retains manual labour.
  let labour = { ...next, labourAmount: previous.labourAmount };
  try {
    if (exactLabour) {
      labour = { ...exactLabour };
    } else if (line.labourEdits?.length) {
      const replayed = orderLabourReplay(previous, line.labourEdits, policy);
      for (const key of ['labourRate', 'labourPct', 'labourAmount'] as const)
        if (n(line[key]) !== replayed[key])
          throw new SaleValidationError(
            'Order labour values do not match the committed edits; reload and retry',
          );
      labour = {
        ...next,
        labourRate: replayed.labourRate,
        labourPct: replayed.labourPct,
        labourAmount: replayed.labourAmount,
      };
    } else {
      if (action)
        labour = orderLabourTransition(
          previous,
          {
            ...next,
            labourAmount: action === 'amount' ? next.labourAmount : previous.labourAmount,
          },
          policy,
          action,
        );
      if (
        line.labourAction &&
        action !== 'amount' &&
        line.labourAmount != null &&
        next.labourAmount !== previous.labourAmount &&
        next.labourAmount === orderLabourAmount(labour, policy)
      )
        // An operator can change a rate away and back within one editing session. The final rate then
        // equals the persisted rate but the explicit committed calculation still has its exact result.
        labour.labourAmount = next.labourAmount;
    }
  } catch (error) {
    throw new SaleValidationError(
      error instanceof Error ? error.message : 'invalid order labour calculation',
    );
  }
  const sameMetal =
    prior &&
    [
      ['netWt', 'ITM_NWT'],
      ['ghtWt', 'ITM_GHT_WT'],
      ['touch', 'ITM_TOUCH'],
      ['westPct', 'ITM_WEST_PRC'],
      ['rate', 'ITM_RATE'],
    ].every(([field, column]) => n((line as any)[field!]) === n(prior[column!]));
  const fine = sameMetal
    ? n(prior.ITM_FINE)
    : fineWt(line.netWt, line.ghtWt, line.touch, line.westPct);
  const metal = sameMetal ? n(prior.ITM_AMT) : round2(fine * n(line.rate));
  const sameTotal =
    prior &&
    sameMetal &&
    labour.labourAmount === n(prior.LBR_AMT) &&
    n(line.otherAmount) === n(prior.OTH_AMT);
  const net = sameTotal
    ? n(prior.NET_AMT)
    : round2(metal + labour.labourAmount + n(line.otherAmount));
  return {
    in: line,
    fine,
    metal,
    making: labour.labourAmount,
    labourRate: labour.labourRate,
    labourPct: labour.labourPct,
    net,
    total: sameTotal ? n(prior.TOT_AMT) : net,
    preservedAmounts: prior
      ? {
          ...(sameMetal ? { ITM_FINE: prior.ITM_FINE, ITM_AMT: prior.ITM_AMT } : {}),
          ...(sameTotal ? { NET_AMT: prior.NET_AMT, TOT_AMT: prior.TOT_AMT } : {}),
        }
      : {},
  };
}

const REPLAY_NUMBERS = [
  'pcs',
  'grossWt',
  'netWt',
  'ghtWt',
  'rate',
  'touch',
  'westPct',
  'labourPct',
  'labourRate',
  'labourAmount',
  'otherAmount',
] as const;
const REPLAY_TEXT = [
  'itCode',
  'designNo',
  'itmSize',
  'karigarName',
  'designImageId',
  'labourType',
] as const;
const REPLAY_COLUMNS = {
  pcs: 'ITM_PCS',
  grossWt: 'ITM_GWT',
  netWt: 'ITM_NWT',
  ghtWt: 'ITM_GHT_WT',
  rate: 'ITM_RATE',
  touch: 'ITM_TOUCH',
  westPct: 'ITM_WEST_PRC',
  labourPct: 'LBR_PRC',
  labourRate: 'LBR_RATE',
  labourAmount: 'LBR_AMT',
  otherAmount: 'OTH_AMT',
  itCode: 'IT_CODE',
  designNo: 'DESIGN_NO',
  itmSize: 'ITM_SIZE',
  karigarName: 'KR_NAME',
  designImageId: 'DESIGN_IMG_ID',
  labourType: 'LBR_TYPE',
} as const;

async function replaySalesOrderLineTx(
  tx: any,
  scope: VoucherScope,
  line: SalesOrderLine,
  prior: Record<string, any> | undefined,
  policy: OrderLabourPolicy,
) {
  const edits = line.orderEdits;
  if (!edits) return calculateOrderLine(line, prior, policy);
  if (!Array.isArray(edits) || edits.length > 512 || line.labourEdits?.length || line.labourAction)
    throw new SaleValidationError(
      'Submit one ordered Sales Order journal with at most 512 committed events.',
    );
  let current: SalesOrderLine = {
    itCode: '',
    designImageId: prior ? text(prior.DESIGN_IMG_ID) : 'N',
  };
  for (const field of REPLAY_NUMBERS) current[field] = n(prior?.[REPLAY_COLUMNS[field]]);
  for (const field of REPLAY_TEXT)
    if (field !== 'designImageId') current[field] = text(prior?.[REPLAY_COLUMNS[field]]);
  let cached = {
    fine: n(prior?.ITM_FINE),
    metal: n(prior?.ITM_AMT),
    making: n(prior?.LBR_AMT),
    labourRate: n(prior?.LBR_RATE),
    labourPct: n(prior?.LBR_PRC),
    net: n(prior?.NET_AMT),
    total: n(prior?.TOT_AMT),
    preservedAmounts: prior
      ? {
          ITM_FINE: prior.ITM_FINE,
          ITM_AMT: prior.ITM_AMT,
          NET_AMT: prior.NET_AMT,
          TOT_AMT: prior.TOT_AMT,
        }
      : ({} as Record<string, any>),
  };
  let triggerCache = {
    labourRate: n(prior?.LBR_RATE),
    labourPct: n(prior?.LBR_PRC),
    labourAmount: n(prior?.LBR_AMT),
  };
  const rowOf = (state: SalesOrderLine) => ({
    ...Object.fromEntries(
      Object.entries(REPLAY_COLUMNS).map(([field, column]) => [column, (state as any)[field]]),
    ),
    ITM_FINE: cached.fine,
    ITM_AMT: cached.metal,
    NET_AMT: cached.net,
    TOT_AMT: cached.total,
  });
  let calculationBaseline = rowOf(current);
  const selectedTextFields = new Set<'designNo' | 'itmSize' | 'karigarName' | 'designImageId'>();
  const trigger = (_previous: Record<string, any>) => {
    try {
      const result = orderLabourWithCache(persistedLabour(rowOf(current)), triggerCache, policy);
      triggerCache = result.cache;
      current = {
        ...current,
        labourRate: result.state.labourRate,
        labourPct: result.state.labourPct,
        labourAmount: result.state.labourAmount,
      };
      cached = calculateOrderLine(current, calculationBaseline, policy, result.state);
      calculationBaseline = rowOf(current);
    } catch (error) {
      throw new SaleValidationError(
        error instanceof Error ? error.message : 'Invalid order calculation trigger.',
      );
    }
  };
  for (const event of edits) {
    if (!event || typeof event !== 'object')
      throw new SaleValidationError('Invalid Sales Order edit event.');
    if (event.kind === 'design') {
      const selected = await resolveSalesOrderDesignTx(tx, scope, {
        itCode: current.itCode,
        source: event.source,
      });
      try {
        current = applySalesOrderDesignSelection(current, selected, { existing: !!prior });
      } catch (error) {
        throw new SaleValidationError(
          error instanceof Error ? error.message : 'Invalid selected design values.',
        );
      }
      // TR_SALE_ORD:7341–7364 copies cells only. Save9244–9250 copies the cached totals.
      for (const field of ['designNo', 'itmSize', 'karigarName', 'designImageId'] as const)
        selectedTextFields.add(field);
      cached = {
        ...cached,
        labourRate: n(current.labourRate),
        labourPct: n(current.labourPct),
      };
    } else if (event.kind === 'clearDesign') {
      current = clearSalesOrderDesignSelection(current);
      selectedTextFields.add('designNo');
      selectedTextFields.add('designImageId');
    } else if (event.kind === 'field') {
      const numeric = (REPLAY_NUMBERS as readonly string[]).includes(event.field);
      if (!numeric && !(REPLAY_TEXT as readonly string[]).includes(event.field))
        throw new SaleValidationError(`Unsupported Sales Order committed field: ${event.field}`);
      if (
        (numeric && (typeof event.value !== 'number' || !Number.isFinite(event.value))) ||
        (!numeric && typeof event.value !== 'string')
      )
        throw new SaleValidationError('Invalid Sales Order committed field value.');
      if (
        event.field === 'designImageId' &&
        event.value !== 'N' &&
        event.value !== current.designImageId
      )
        throw new SaleValidationError('Choose a saved design to change its linked image identity.');
      const previous = rowOf(current);
      current = { ...current, [event.field]: event.value };
      if (
        ['pcs', 'grossWt', 'netWt', 'ghtWt', 'rate', 'touch', 'westPct', 'otherAmount'].includes(
          event.field,
        )
      ) {
        trigger(previous);
      } else
        cached = {
          ...cached,
          making: n(current.labourAmount),
          labourRate: n(current.labourRate),
          labourPct: n(current.labourPct),
        };
    } else if (event.kind === 'labour') {
      const previous = rowOf(current);
      try {
        orderLabourReplay(persistedLabour(previous), [event.edit], policy);
      } catch (error) {
        throw new SaleValidationError(
          error instanceof Error ? error.message : 'Invalid order labour event.',
        );
      }
      const basis = event.edit.basis;
      const field = { rate: 'labourRate', percentage: 'labourPct', amount: 'labourAmount' }[
        event.edit.action
      ];
      current = {
        ...current,
        pcs: basis.pcs,
        grossWt: basis.grossWt,
        netWt: basis.netWt,
        ghtWt: basis.ghatWt,
        rate: basis.itemRate,
        labourType: basis.labourType,
        [field]: round(event.edit.value, 2),
      };
      trigger(previous);
    } else throw new SaleValidationError('Invalid Sales Order edit event kind.');
  }
  for (const field of REPLAY_NUMBERS)
    if (n(line[field]) !== n(current[field]))
      throw new SaleValidationError(
        `Sales Order ${field} does not match its committed edits; reload and retry.`,
      );
  for (const field of REPLAY_TEXT)
    if (text(line[field]) !== text(current[field]))
      throw new SaleValidationError(
        `Sales Order ${field} does not match its committed edits; reload and retry.`,
      );
  // Blank source cells are actual copied values, not omitted input. Final server replay is
  // authoritative even when an older serializer omitted an empty text cell. Later text commits
  // already changed current, so this does not reapply Design defaults after a manual edit.
  const selectedText = Object.fromEntries(
    [...selectedTextFields].map((field) => [field, current[field]]),
  );
  return { ...cached, in: { ...line, ...selectedText } };
}

type OrderWriteContext = {
  tx: any;
  vchNo: number;
  hdVchNo: string;
  mainUser: string;
  persistedClock?: unknown;
  previousLines?: Record<string, any>[];
  previousHeader?: Record<string, any>;
  previousComponents?: Record<string, any>[];
};

/** Existing internal compatibility entry; optional lifecycle remains replacement-only. */
export async function createSalesOrder(
  prisma: any,
  input: SalesOrderInput,
  lifecycle?: OrderWriteContext,
): Promise<{ vchNo: number; total: number; advance: number }> {
  const prepared = prepareSalesOrderCreate(input, lifecycle);
  return lifecycle
    ? prepared.run(lifecycle.tx)
    : withTxBudget(prisma, prepared.tenantId, 'voucher', prepared.run);
}

/** New allocation and complete order write set in the caller's existing transaction. */
export async function createSalesOrderTx(
  tx: Tx,
  input: SalesOrderInput,
): Promise<{ vchNo: number; total: number; advance: number }> {
  return prepareSalesOrderCreate(input).run(tx);
}

function prepareSalesOrderCreate(input: SalesOrderInput, lifecycle?: OrderWriteContext) {
  completeOrderScope(input.scope);
  const requestedDate =
    orderDate(input.vchDate, 'vchDate', input.orderMainBook !== 'TOUR ORDER' && !lifecycle) ??
    orderDate(lifecycle?.previousHeader?.VCH_DATE, 'saved vchDate') ??
    new Date();
  orderDate(input.deliveryDate, 'deliveryDate');
  orderDate(input.functionDate, 'functionDate');
  if (input.vchTime != null) orderClock(input.vchTime);
  if (!input.acCode) throw new SaleValidationError('customer account (acCode) is required');
  if (input.lines !== undefined && !Array.isArray(input.lines))
    throw new SaleValidationError('order lines must be an array');
  for (const line of input.lines ?? []) {
    orderDate(line.orderDeliveryDate, 'orderDeliveryDate');
    if (line.labourEdits != null && !Array.isArray(line.labourEdits))
      throw new SaleValidationError('Order labour edits must be an array');
    for (const field of ['labourAmount', 'labourRate', 'labourPct', 'making'] as const)
      if (line[field] != null && !Number.isFinite(Number(line[field])))
        throw new SaleValidationError(`${field} must be a finite number`);
    if (line.components !== undefined && !Array.isArray(line.components))
      throw new SaleValidationError('order components must be an array');
    for (const row of [line, ...(line.components ?? [])])
      for (const [field, value] of Object.entries(row))
        if (typeof value === 'number' && !Number.isFinite(value))
          throw new SaleValidationError(`${field} must be a finite number`);
  }
  const N = (v: unknown): number => (v == null ? 0 : Number(v));
  /** Desktop grid cells persist as trimmed text bounded by the column width; blank ⇒ null. */
  const txt = (v: unknown, len: number): string | null =>
    String(v ?? '')
      .trim()
      .slice(0, len) || null;
  const designText = (line: SalesOrderLine, value: unknown, len: number) =>
    line.orderEdits?.some((event) => event.kind === 'design')
      ? String(value ?? '')
          .trim()
          .slice(0, len)
      : txt(value, len);
  // Compute new or explicitly edited values; imported manual values survive unchanged replacement.
  const orderLines = input.lines ?? [];
  const parentNumbers = orderRowNumbers(orderLines, 'srNo');
  const tenantId = input.scope.tenantId;
  const adv = round2(Number(input.advanceAmount || 0));
  const cashAc = input.cashAc ?? 'CASH';

  const run = async (tx: any) => {
    const mode = requestedMode(input.orderMainBook);
    const book = await resolveOrderBookTx(tx, input.scope, mode);
    if (mode.mainBook === 'SALES ORDER')
      await assertSalesOrderDateTx(tx, input.scope, requestedDate);
    const configuration = await orderLabourConfigurationTx(tx, input.scope);
    const policy = {
      includesGhat: configuration.labourIncludesGhat,
      rateDecimals: configuration.labourRateDecimals,
    };
    const previousLines = new Map(
      (lifecycle?.previousLines ?? []).map((row) => [n(row.SR_NO), row]),
    );
    // TR_SALE_ORD:9208–9215 and TR_TOUR_ORD:7378 persist a saved tag, not an unconditional N.
    // This editor has no tag-stock reservation transition. Preserve imported ownership and refuse
    // changing either component of the tag image identity, including deleting/remapping its row.
    const tagIdentity = (value: unknown) => {
      const tag = String(value ?? '').trim();
      return tag === 'N' ? '' : tag;
    };
    for (const [srNo, previous] of previousLines) {
      if (tagIdentity(previous.TAG_NO) && !parentNumbers.includes(srNo))
        throw new SaleValidationError(
          'A tagged order item cannot be removed in this editor; its stock allocation must be resolved first.',
        );
    }
    for (const [index, line] of orderLines.entries()) {
      const previous = previousLines.get(parentNumbers[index]!);
      const savedTag = tagIdentity(previous?.TAG_NO);
      if (line.tagNo != null && tagIdentity(line.tagNo) !== savedTag)
        throw new SaleValidationError(
          'Changing an order tag identity is not supported in this editor.',
        );
      if (savedTag && line.vchSrno != null && Number(line.vchSrno) !== Number(previous!.VCH_SRNO))
        throw new SaleValidationError(
          'Changing the saved tag instance is not supported in this editor.',
        );
      if (input.requireDesignSelection && mode.mainBook === 'SALES ORDER') {
        const oldImage = previous ? text(previous.DESIGN_IMG_ID) : 'N';
        const requestedImage =
          line.designImageId === undefined ? oldImage : text(line.designImageId);
        if (requestedImage !== oldImage) {
          const events = Array.isArray(line.orderEdits) ? line.orderEdits : [];
          if (!events.some((event) => event.kind === 'design' || event.kind === 'clearDesign'))
            throw new SaleValidationError(
              'Choose or clear the saved design through its source selection before changing the linked image identity.',
            );
        }
      }
    }
    const computed = [];
    for (const [index, line] of orderLines.entries()) {
      if (line.orderEdits && mode.mainBook !== 'SALES ORDER')
        throw new SaleValidationError('Design selection replay belongs to the Sales Order form.');
      computed.push(
        await replaySalesOrderLineTx(
          tx,
          input.scope,
          line,
          previousLines.get(parentNumbers[index]!),
          policy,
        ),
      );
    }
    const linesNet = round2(computed.reduce((s, c) => s + c.net, 0));
    const baseNet = linesNet > 0 ? linesNet : Number(input.netAmount || 0);
    if (!(baseNet > 0))
      throw new SaleValidationError('order amount (or line weights/rate) is required');
    let totals = billTotals({
      lineNetTotal: baseNet,
      taxRatePct: input.taxRatePct,
      interState: !!input.interState,
    });

    const previousHeader = lifecycle?.previousHeader;
    if (
      previousHeader &&
      previousLines.size === computed.length &&
      input.taxRatePct === n(previousHeader.TAX_PRC) &&
      (input.netAmount == null || n(input.netAmount) === n(previousHeader.NET_AMT)) &&
      computed.every((line, index) => {
        const old = previousLines.get(parentNumbers[index]!);
        return old && line.net === n(old.NET_AMT) && line.total === n(old.TOT_AMT);
      })
    )
      // Saved header totals may contain a desktop manual override or rounding branch. If this
      // request did not edit its financial values, an unchanged/child-only save must retain them.
      totals = {
        ...totals,
        taxable: previousHeader.NET_AMT,
        tax: previousHeader.TAX_AMT,
        total: previousHeader.TOT_AMT,
      };

    const scoped = { ...input.scope, coBook: book.coBook };
    const no = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, scoped));
    const hdVchNo = lifecycle?.hdVchNo ?? (await nextHiddenVoucherNoTx(tx, scoped));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key = keyOf(scoped, no, mode.defaultCoBook);
    const vchDate = voucherTimestamp(
      requestedDate,
      input.vchTime == null ? lifecycle?.persistedClock : orderClock(input.vchTime),
    );
    const exactClock =
      input.vchTime == null
        ? lifecycle?.persistedClock == null
          ? undefined
          : orderClock(lifecycle.persistedClock)
        : orderClock(input.vchTime);
    const headerDirty = orderDirtyColumns(input, ORDER_HEADER_FIELDS);
    const parentDirty = orderLines.map((line, index) =>
      orderDirtyColumns(
        line,
        ORDER_PARENT_FIELDS,
        (line.orderEdits ?? []).flatMap((event) =>
          event.kind === 'field'
            ? [ORDER_PARENT_FIELDS[event.field]!]
            : event.kind === 'labour'
              ? ['LBR_RATE', 'LBR_PRC', 'LBR_AMT', 'ITM_FINE', 'ITM_AMT', 'NET_AMT', 'TOT_AMT']
              : event.kind === 'design'
                ? previousLines.has(parentNumbers[index]!)
                  ? ['DESIGN_NO', 'ITM_SIZE', 'KR_NAME', 'DESIGN_IMG_ID']
                  : [
                      'DESIGN_NO',
                      'ITM_SIZE',
                      'KR_NAME',
                      'DESIGN_IMG_ID',
                      'ITM_TOUCH',
                      'ITM_WEST_PRC',
                      'LBR_PRC',
                      'LBR_RATE',
                    ]
                : ['DESIGN_NO', 'DESIGN_IMG_ID'],
        ),
      ),
    );
    const header = preserveOrderInputRow(
      lifecycle?.previousHeader,
      {
        ...key,
        VCH_DATE: vchDate,
        BILL_NO: input.billNo ?? formatVoucherNo(no),
        AC_CODE: input.acCode,
        AC_NAME: input.acName ?? null,
        NET_AMT: totals.taxable,
        TAX_PRC: input.taxRatePct,
        TAX_AMT: totals.tax,
        TOT_AMT: totals.total,
        ADV_AMT: adv,
        VCH_TIME: vchDate,
        ENTRY_TIME:
          lifecycle?.previousHeader && !headerDirty.has('VCH_TIME') && !headerDirty.has('VCH_DATE')
            ? lifecycle.previousHeader.ENTRY_TIME
            : vchDate,
        HD_VCH_NO: hdVchNo,
        MAIN_USER: mainUser,
        EMP_CODE: txt(input.empCode, 5),
        VCH_DESC: input.vchDesc ?? null,
        // Desktop SL_ORD_DATA columns (TR_SALE_ORD.cs:9120-9161): tax code, tender rows from the
        // settlement grid, old-metal and rate-cut adjustment, delivery/function dates and the party
        // address block. A blank desktop grid cell persists as ''/0.
        TAX_CODE: txt(input.taxCode, 2), // MSG2_TOTAL[1,4] :9120
        UPI_AMT: round2(N(input.upiAmount)), // MSG2_TOTAL[3,1] :9141
        BANK_AC: txt(input.bankAc, 9), // MSG2_TOTAL[4,4] :9149
        CHQ_NO: txt(input.chequeNo, 10), // MSG2_TOTAL[4,2] :9150
        BANK_NAME: txt(input.bankName, 50), // tBankName.Text  :9151
        CARD_AC: txt(input.cardAc, 9), // MSG2_TOTAL[5,4] :9148
        CARD_ADJ: txt(input.cardAdj, 1), // CardCommAdj     :9154
        OLD_GL: N(input.oldGoldFine), // [6,2]+[9,2]    :9143
        OLD_GL_AMT: round2(N(input.oldGoldAmount)), // MSG2_TOTAL[6,3] :9136
        OLD_SL: N(input.oldSilverFine), // MSG2_TOTAL[7,2] :9144
        OLD_SL_AMT: round2(N(input.oldSilverAmount)), // MSG2_TOTAL[7,3] :9137
        SCHM_AMT: round2(N(input.schemeAmount)), // MSG2_TOTAL[8,3] :9142
        RCUT_RATE: N(input.rateCutRate), // MSG2_TOTAL[9,1] :9134
        RCUT_FINE: N(input.rateCutFine), // MSG2_TOTAL[9,2] :9135
        RCUT_AMT: round2(N(input.rateCutAmount)), // MSG2_TOTAL[9,3] :9126
        ADJ_GOLD: N(input.adjustGold), // AdjGold  :9146
        ADJ_SILVER: N(input.adjustSilver), // AdjSilver:9147
        ORD_ADJ_AMT: round2(N(input.orderAdjustAmount)), // RecAdjAmt:9145
        DEL_DATE: orderDate(input.deliveryDate, 'deliveryDate') ?? null, // :9152
        FUN_DATE: orderDate(input.functionDate, 'functionDate') ?? null, // :9153
        ADD1: txt(input.address1, 50), // tAdd1.Text  :9157
        ADD2: txt(input.address2, 50), // tAdd2.Text  :9158
        ADD3: txt(input.address3, 50), // tAdd3.Text  :9159
        CITY: txt(input.city, 20), // tCity.Text  :9160
        MOBILE: txt(input.mobile, 21), // tMobile.Text:9161
      },
      input,
      ORDER_HEADER_FIELDS,
      headerDirty,
    );
    const detl = computed.map((c, i) =>
      preserveOrderInputRow(
        previousLines.get(parentNumbers[i]!),
        {
          ...key,
          SR_NO: parentNumbers[i]!,
          VCH_DATE: vchDate,
          IT_CODE: c.in.itCode,
          DESIGN_NO: c.in.designNo ?? null,
          ITM_PCS: N(c.in.pcs),
          ITM_GWT: N(c.in.grossWt),
          ITM_NWT: N(c.in.netWt),
          ITM_TOUCH: N(c.in.touch),
          ITM_FINE: c.preservedAmounts.ITM_FINE ?? c.fine,
          ITM_RATE: N(c.in.rate),
          ITM_AMT: c.preservedAmounts.ITM_AMT ?? c.metal,
          LBR_AMT: c.making,
          NET_AMT: c.preservedAmounts.NET_AMT ?? c.net,
          TOT_AMT: c.preservedAmounts.TOT_AMT ?? c.total,
          ITM_REMARK: c.in.remark ?? null,
          AC_CODE: input.acCode,
          VCH_TYPE: book.vchType,
          INOUT_TYPE: book.inoutType,
          ENTRY_TYPE: 'O',
          BOOK_NAME: book.mainBook,
          VCH_TIME: vchDate,
          HD_VCH_NO: hdVchNo,
          MAIN_USER: mainUser,
          TAG_SALE: 'N',
          TAG_GEN: 'N',
          DESIGN_ISU: 'N',
          // Desktop SL_ORD_DETL grid columns (TR_SALE_ORD.cs:9205-9306).
          TBL_CODE: txt(c.in.tblCode, 3), // mSG[i,3]  :9216
          ITM_COLOR: txt(c.in.itmColor, 15), // mSG[i,5]  :9218
          ITM_SIZE: designText(c.in, c.in.itmSize, 20), // selected blank is a copied cell :7342
          BAG_WT: N(c.in.bagWt), // mSG[i,7]  :9220
          ITM_OTH_WT: N(c.in.lessWt), // mSG[i,10] :9223
          ITM_GHT_PRC: N(c.in.ghtPct), // mSG[i,12] :9225
          ITM_GHT_WT: N(c.in.ghtWt), // mSG[i,13] :9226
          ITM_WEST_PRC: N(c.in.westPct), // mSG[i,15] :9228
          RATE_FIX: txt(c.in.rateFix, 1), // mSG[i,17] :9237
          LBR_PRC: c.labourPct, // mSG[i,20] :9230
          LBR_TYPE: txt(c.in.labourType, 1), // mSG[i,21] :9231
          LBR_RATE: c.labourRate, // mSG[i,22] :9232
          OTH_AMT: round2(N(c.in.otherAmount)), // mSG[i,24] :9234
          ITM_MRP: N(c.in.mrp), // mSG[i,25] :9249
          ORD_DEL_DATE: orderDate(c.in.orderDeliveryDate, 'orderDeliveryDate') ?? null, // :9290
          KR_NET_WT: N(c.in.karigarNetWt), // mSG[i,32] :9254
          KR_TOUCH: N(c.in.karigarTouch), // mSG[i,35] :9255
          KR_WEST_PRC: N(c.in.karigarWestPct), // mSG[i,36] :9256
          KR_FINE: N(c.in.karigarFine), // mSG[i,37] :9257
          KR_NAME: designText(c.in, c.in.karigarName, 5), // selected blank is a copied cell :7343
          TAG_COST: N(c.in.tagCost), // mSG[i,43] :9250
          VCH_SRNO: tagIdentity(previousLines.get(parentNumbers[i]!)?.TAG_NO)
            ? previousLines.get(parentNumbers[i]!)!.VCH_SRNO
            : N(c.in.vchSrno), // saved tag instance / mSG[i,42] :9262
          OLD_SRNO: c.in.oldSrNo ?? i + 1, // mSG[i,47] :9205
          RATE_TYPE: txt(c.in.rateType, 1), // mSG[i,48] :9259
          IT_TYPE: txt(c.in.itType, 1), // mSG[i,49] :9260
          PR_CODE: txt(c.in.prCode, 2), // mSG[i,51] :9261
          OLD_TBL_CODE: txt(c.in.oldTblCode, 3), // mSG[i,69] :9266
          TAG_STK_LESS: txt(c.in.tagStockLess, 1), // mSG[i,70] :9267
          DESIGN_IMG_ID:
            c.in.designImageId === undefined
              ? previousLines.has(parentNumbers[i]!)
                ? previousLines.get(parentNumbers[i]!)!.DESIGN_IMG_ID
                : 'N'
              : c.in.designImageId === null
                ? null
                : String(c.in.designImageId).trim().slice(0, 50), // copied blank :7362 differs from new-row N :5558.
          HM_ID: txt(c.in.huid, 10), // mSG[i,72] :9298
          HM_ID2: txt(c.in.hallmarkId2, 10), // mSG[i,73] :9299
          HM_ID3: txt(c.in.hallmarkId3, 10), // mSG[i,74] :9300
          HM_ID4: txt(c.in.hallmarkId4, 10), // mSG[i,75] :9301
          HM_ID_WT: N(c.in.hallmarkIdWt), // mSG[i,76] :9302
          HM_ID2_WT: N(c.in.hallmarkId2Wt), // mSG[i,77] :9303
          HM_ID3_WT: N(c.in.hallmarkId3Wt), // mSG[i,78] :9304
          HM_ID4_WT: N(c.in.hallmarkId4Wt), // mSG[i,79] :9305
          EMP_CODE: txt(input.empCode, 5), // tEmpCode.Text :9296
          TAG_NO: previousLines.has(parentNumbers[i]!)
            ? previousLines.get(parentNumbers[i]!)!.TAG_NO
            : 'N', // saved parent identity; new untagged row sentinel
          ORD_REC_AMT: 0, // literal       :9306
        },
        c.in,
        ORDER_PARENT_FIELDS,
        parentDirty[i]!,
      ),
    );
    const previousComponents = new Map(
      (lifecycle?.previousComponents ?? []).map((row) => [`${row.SR_NO}:${row.ISR_NO}`, row]),
    );
    const componentDirty = new Map<string, Set<string>>();
    const idtl = computed.flatMap((c, i) => {
      const legacy = {
        ...key,
        SR_NO: parentNumbers[i]!,
        ISR_NO: 1,
        VCH_DATE: vchDate,
        AC_CODE: input.acCode,
        VCH_TYPE: book.vchType,
        INOUT_TYPE: book.inoutType,
        ENTRY_TYPE: 'O',
        BOOK_NAME: book.mainBook,
        TAG_NO: 'N',
        VCH_SRNO: detl[i]!.VCH_SRNO,
        IT_CODE: c.in.itCode,
        IT_PCS: N(c.in.pcs),
        IT_GWT: N(c.in.grossWt),
        IT_AMT: c.metal,
        IT_NET_AMT: c.net,
        // Stone / diamond identity — widths taken from the live schema (DM_NAME 50, DM_SIZE 20, DM_LEB 15).
        DM_CODE: text(c.in.dmCode).slice(0, 8) || null,
        DM_NAME: text(c.in.dmName).slice(0, 50) || null,
        DM_SIZE: text(c.in.dmSize).slice(0, 20) || null,
        DM_SFNO: text(c.in.dmSfNo).slice(0, 20) || null,
        DM_COLOR: text(c.in.dmColor).slice(0, 15) || null,
        DM_ORIGIN: text(c.in.dmOrigin).slice(0, 20) || null,
        DM_REMARK: text(c.in.dmRemark).slice(0, 20) || null,
        DM_LEB: text(c.in.dmLeb).slice(0, 15) || null,
        // Stone valuation
        IT_PCS_WT: N(c.in.stonePcsWt),
        IT_CON_PRC: N(c.in.stoneConPct),
        IT_CON_WT: N(c.in.stoneConWt),
        IT_RATE_TYPE: text(c.in.stoneRateType).slice(0, 1) || null,
        IT_RATE: N(c.in.stoneRate),
        IT_LBR_RATE: N(c.in.stoneLabourRate),
        IT_LBR_AMT: N(c.in.stoneLabourAmount),
        // Karigar side of the stone line
        KR_WT: N(c.in.stoneKarigarWt),
        KR_LESS_PRC: N(c.in.stoneKarigarLessPct),
        KR_CON_PRC: N(c.in.stoneKarigarConPct),
        KR_CON_WT: N(c.in.stoneKarigarConWt),
        KR_RATE: N(c.in.stoneKarigarRate),
        KR_AMT: N(c.in.stoneKarigarAmount),
        KR_LBR_RATE: N(c.in.stoneKarigarLabourRate),
        KR_LBR_AMT: N(c.in.stoneKarigarLabourAmount),
        KR_NET_AMT: N(c.in.stoneKarigarNetAmount),
        NEW_VCH_NO: null,
        HD_VCH_NO: hdVchNo,
        MAIN_USER: mainUser,
      };
      if (c.in.components === undefined)
        return [preserveOrderRow(previousComponents.get(`${parentNumbers[i]}:1`), legacy)];
      const componentNumbers = orderRowNumbers(c.in.components, 'isrNo');
      return c.in.components.map((component, childIndex) => {
        if (!text(component.itCode))
          throw new SaleValidationError(
            `item line ${i + 1}, component ${childIndex + 1}: item is required`,
          );
        const dirty = orderDirtyColumns(component, ORDER_COMPONENT_FIELDS);
        componentDirty.set(`${parentNumbers[i]}:${componentNumbers[childIndex]}`, dirty);
        return preserveOrderInputRow(
          previousComponents.get(`${parentNumbers[i]}:${componentNumbers[childIndex]}`),
          {
            ...legacy,
            ...stoneSubDetailColumns(component),
            ISR_NO: componentNumbers[childIndex]!,
            IT_CODE: text(component.itCode),
            IT_TYPE: txt(component.itType, 1),
            IT_PCS: N(component.pcs),
            IT_GWT: N(component.grossWt),
            IT_AMT: N(component.amount),
            IT_NET_AMT: N(component.netAmount),
          },
          component,
          ORDER_COMPONENT_FIELDS,
          dirty,
        );
      });
    });
    const ledger: LedgerLine[] =
      adv > 0
        ? [
            { ...key, VCH_TYPE: book.vchType, AC_CODE: cashAc, DR_AMT: adv, CR_AMT: 0, SIGN: 'D' },
            {
              ...key,
              VCH_TYPE: book.vchType,
              AC_CODE: input.acCode,
              DR_AMT: 0,
              CR_AMT: adv,
              SIGN: 'C',
            },
          ]
        : [];
    if (ledger.length) assertBalanced(ledger);

    // The Rojmel (day book). Book 020 carries 55 real rows across four types; the other four in
    // Ac_Rojmel.Order_Rojmel never fired here. Type 01 is the advance as a CREDIT with the book's slot-1
    // account as contra - verified: slot 1 on book 020 is 00001 and every real type-01 row has LD_CODE
    // 00001. Type 02 is a cheque, and note it names the BANK in AC_CODE with the party in LD_CODE, the
    // reverse of the advance row.
    //
    // NOT written, on evidence: type 03 card (CARD_AMT is 0 of 76 orders), type 07 rate-cut fine
    // (RCUT_FINE 0 of 76), type 08 UPI (UPI_DATA has 1 row company-wide), and type 05 scheme adjustment -
    // which is an unresolved ANOMALY: SCHM_AMT is non-zero on 7 of 76 orders yet there are ZERO type-05
    // rows. Emitting it would add rows the desktop does not have, which is harder to notice than a
    // missing row and equally a parity failure. See docs/PLAN-SALESORDER-ROJMEL.md section 2.4.
    //
    // The old-metal detail rows (types 04 and 06) come from SL_PR_DETL, which this function does not
    // currently write on an order - so they cannot fire yet. They are implemented in the shared builder
    // and will be exercised when an order accepts metal in part-exchange.
    const rojmelRows = buildOrderRojmel(
      {
        scope: {
          coCode: input.scope.coCode,
          lcCode: input.scope.lcCode,
          coYear: input.scope.coYear!,
        },
        key,
        coBook: key.CO_BOOK,
        vchNo: key.VCH_NO,
        vchDate,
        vchType: book.vchType,
        bookName: book.mainBook,
        partyName: input.acName ?? '',
        partyCode: input.acCode,
      },
      {
        // Slot 1 is the book's advance contra. `cashAc` is what the ledger already debits for the
        // advance, which is the same account the desktop names in LD_CODE.
        advanceContraAc: cashAc,
        bankAc: cashAc,
        advanceAmount: adv,
        // An order's cheque tender is not modelled separately from the advance here, so type 02 stays
        // dormant rather than being fed a value it does not have.
        chequeAmount: 0,
      },
    );
    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: scoped.coCode,
      LC_CODE: scoped.lcCode,
      CO_BOOK: scoped.coBook,
      VCH_NO: hdVchNo,
      BOOK_NAME: book.bookName,
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      writes: [
        { table: 'SL_ORD_DATA', rows: [header] },
        ...(detl.length ? [{ table: 'SL_ORD_DETL', rows: detl }] : []),
        ...(idtl.length ? [{ table: 'SL_ORD_IDTL', rows: idtl }] : []),
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    // Shared insertion defaults apply to new rows. An unchanged imported NULL belongs to the
    // saved snapshot and must not become zero/blank merely because an order was reopened.
    for (const [table, rows, priorRows] of [
      ['SL_ORD_DATA', [header], lifecycle?.previousHeader ? [lifecycle.previousHeader] : []],
      ['SL_ORD_DETL', detl, lifecycle?.previousLines ?? []],
      ['SL_ORD_IDTL', idtl, lifecycle?.previousComponents ?? []],
    ] as const) {
      for (const row of rows) {
        const prior = priorRows.find(
          (candidate) =>
            (table === 'SL_ORD_DATA' || n(candidate.SR_NO) === n(row.SR_NO)) &&
            (table !== 'SL_ORD_IDTL' || n(candidate.ISR_NO) === n(row.ISR_NO)),
        );
        if (!prior) continue;
        const dirty =
          table === 'SL_ORD_DATA'
            ? headerDirty
            : table === 'SL_ORD_DETL'
              ? parentDirty[parentNumbers.indexOf(n(row.SR_NO))]
              : componentDirty.get(`${row.SR_NO}:${row.ISR_NO}`);
        const columns = Object.keys(row).filter(
          (column) => row[column] === null && prior[column] === null && !dirty?.has(column),
        );
        if (!columns.length) continue;
        const serials =
          table === 'SL_ORD_DATA' ? [] : table === 'SL_ORD_DETL' ? ['SR_NO'] : ['SR_NO', 'ISR_NO'];
        await tx.$executeRawUnsafe(
          `UPDATE "${table}" SET ${columns.map((column) => `"${column}"=NULL`).join(',')} WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6${serials.map((column, index) => ` AND "${column}"=$${index + 7}`).join('')}`,
          ...orderParams(scoped as CompleteOrderScope, key.VCH_NO),
          ...serials.map((column) => row[column]),
        );
      }
    }
    if (exactClock) {
      // Keep the six-digit PostgreSQL clock; JavaScript Date only represents milliseconds.
      const timestamp = `${requestedDate.toISOString().slice(0, 10)} ${exactClock}`;
      for (const [table, columns] of [
        [
          'SL_ORD_DATA',
          lifecycle?.previousHeader && !headerDirty.has('VCH_TIME') && !headerDirty.has('VCH_DATE')
            ? ['VCH_TIME']
            : ['VCH_TIME', 'ENTRY_TIME'],
        ],
        ['SL_ORD_DETL', ['VCH_TIME']],
        ['AC_DATA', ['ENTRY_TIME']],
      ] as const)
        await tx.$executeRawUnsafe(
          `UPDATE "${table}" SET ${columns.map((column) => `"${column}"=$7::timestamp`).join(',')} WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
          ...orderParams(scoped as CompleteOrderScope, key.VCH_NO),
          timestamp,
        );
    }
    return { vchNo: no, total: totals.total, advance: adv };
  };
  return { tenantId, run };
}

type CompleteOrderScope = VoucherScope & { coYear: string; coBook: string };
const ORDER_WRITE_TABLES = [
  'SL_ORD_DATA',
  'SL_ORD_DETL',
  'SL_ORD_IDTL',
  'SL_PR_DETL',
  'SL_ORD_ADJ',
  'UPI_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
] as const;
const text = (v: unknown): string => String(v ?? '').trim();
const n = (v: unknown): number => Number(v ?? 0);
function completeOrderScope(scope: VoucherScope): asserts scope is CompleteOrderScope {
  if (
    ['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'].some(
      (field) => !String((scope as any)[field] ?? '').trim(),
    )
  )
    throw new SaleValidationError(
      'complete voucher scope (tenant, company, location, coYear and coBook) is required',
    );
}
const orderParams = (scope: CompleteOrderScope, voucherNo: string): unknown[] => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];

async function lockOrderMutationTx(tx: any, scope: CompleteOrderScope, voucherNo: string) {
  // The writer replaces rows. An advisory lock starts the second writer's SELECT after replacement,
  // so it reads the new snapshot instead of waiting on a deleted tuple and reporting "not found".
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    JSON.stringify(['order-mutation', ...orderParams(scope, voucherNo)]),
  );
}

/** All rows that an edit/delete replaces, including evidence needed for stale-write detection. */
async function orderStateTx(tx: any, scope: CompleteOrderScope, voucherNo: string) {
  const state = {} as Record<(typeof ORDER_WRITE_TABLES)[number] | 'COMPANY_POLICY', any[]>;
  for (const table of ORDER_WRITE_TABLES) {
    state[table] = await tx.$queryRawUnsafe(
      `SELECT r.*${table === 'SL_ORD_DATA' ? ',to_char("VCH_TIME",\'HH24:MI:SS.US\') AS "VCH_CLOCK"' : ''} FROM "${table}" r WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY to_jsonb(r)::text${table === 'SL_ORD_DATA' ? ' FOR SHARE' : ''}`,
      ...orderParams(scope, voucherNo),
    );
  }
  state.COMPANY_POLICY = [await orderLabourConfigurationTx(tx, scope)];
  return state;
}

function orderVersion(state: Record<(typeof ORDER_WRITE_TABLES)[number], any[]>): string {
  // Database row ids change on replacement, so even an unchanged edit invalidates its old snapshot.
  const canonical = (value: any): any => {
    if (value == null || typeof value !== 'object')
      return typeof value === 'bigint' ? String(value) : value;
    if (value instanceof Date) return value.toISOString();
    if (typeof value.toJSON === 'function') return canonical(value.toJSON());
    if (Array.isArray(value)) return value.map(canonical);
    return Object.fromEntries(
      Object.keys(value)
        .sort()
        .map((key) => [key, canonical(value[key])]),
    );
  };
  return createHash('sha256')
    .update(JSON.stringify(canonical(state)))
    .digest('hex');
}

const dateText = (value: unknown): string =>
  value instanceof Date ? value.toISOString().slice(0, 10) : text(value).slice(0, 10);

function unsupportedOrderEdit(
  state: Record<(typeof ORDER_WRITE_TABLES)[number], any[]>,
): string | undefined {
  if (
    (['SL_PR_DETL', 'SL_ORD_ADJ', 'UPI_DATA', 'MAIN_STOCK'] as const).some(
      (table) => state[table]?.length,
    )
  )
    return 'This order has metal, settlement or stock allocations that must be resolved before editing.';
  const header = state.SL_ORD_DATA[0];
  if (header && ['CASH_AMT', 'CHQ_AMT', 'CARD_AMT'].some((column) => n(header[column]) !== 0))
    return 'This order uses separate cash, cheque or card settlement. Its settlement workflow must be completed before editing.';
  return undefined;
}

async function assertOrderVersionTx(
  tx: any,
  scope: CompleteOrderScope,
  voucherNo: string,
  expectedVersion?: string,
) {
  const state = await orderStateTx(tx, scope, voucherNo);
  if (expectedVersion !== undefined && expectedVersion !== orderVersion(state))
    throw new SalesOrderConflictError();
  return state;
}

export async function getSalesOrder(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
  options: { orderMainBook?: OrderMainBook } = {},
): Promise<Record<string, unknown>> {
  completeOrderScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, SNAPSHOT_READ, async (tx: any) => {
    await resolveOrderBookTx(tx, scope, requestedMode(options.orderMainBook));
    const state = await orderStateTx(tx, scope, voucherNo);
    const h = state.SL_ORD_DATA;
    if (h.length !== 1)
      throw new SaleValidationError(
        h.length
          ? `sales order voucher is ambiguous: ${voucherNo}`
          : `sales order voucher not found: ${voucherNo}`,
      );
    const d = [...state.SL_ORD_DETL].sort((a, b) => n(a.SR_NO) - n(b.SR_NO));
    const x = h[0];
    const advanceDebit = state.AC_DATA.find((row) => n(row.DR_AMT) > 0);
    const dto = {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchTime: text(x.VCH_CLOCK).replace(/(\.\d{3})000$/, '$1'),
      version: orderVersion(state),
      labourIncludesGhat: state.COMPANY_POLICY[0].labourIncludesGhat,
      labourRateDecimals: state.COMPANY_POLICY[0].labourRateDecimals,
      editBlockedReason: unsupportedOrderEdit(state),
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear: scope.coYear,
      coBook: scope.coBook,
      vchDate: dateText(x.VCH_DATE),
      billNo: text(x.BILL_NO),
      vchDesc: text(x.VCH_DESC),
      acCode: text(x.AC_CODE),
      acName: text(x.AC_NAME),
      netAmount: n(x.NET_AMT),
      taxRatePct: n(x.TAX_PRC),
      total: n(x.TOT_AMT),
      advanceAmount: n(x.ADV_AMT),
      cashAc: text(advanceDebit?.AC_CODE) || undefined,
      empCode: text(x.EMP_CODE) || text(d[0]?.EMP_CODE),
      taxCode: text(x.TAX_CODE),
      upiAmount: n(x.UPI_AMT),
      bankAc: text(x.BANK_AC),
      chequeNo: text(x.CHQ_NO),
      bankName: text(x.BANK_NAME),
      cardAc: text(x.CARD_AC),
      cardAdj: text(x.CARD_ADJ),
      oldGoldFine: n(x.OLD_GL),
      oldGoldAmount: n(x.OLD_GL_AMT),
      oldSilverFine: n(x.OLD_SL),
      oldSilverAmount: n(x.OLD_SL_AMT),
      schemeAmount: n(x.SCHM_AMT),
      rateCutRate: n(x.RCUT_RATE),
      rateCutFine: n(x.RCUT_FINE),
      rateCutAmount: n(x.RCUT_AMT),
      adjustGold: n(x.ADJ_GOLD),
      adjustSilver: n(x.ADJ_SILVER),
      orderAdjustAmount: n(x.ORD_ADJ_AMT),
      deliveryDate: dateText(x.DEL_DATE),
      functionDate: dateText(x.FUN_DATE),
      address1: text(x.ADD1),
      address2: text(x.ADD2),
      address3: text(x.ADD3),
      city: text(x.CITY),
      mobile: text(x.MOBILE),
      lines: d.map((r) => ({
        srNo: n(r.SR_NO),
        tagNo: text(r.TAG_NO) === 'N' ? '' : text(r.TAG_NO),
        itCode: text(r.IT_CODE),
        designNo: text(r.DESIGN_NO),
        pcs: n(r.ITM_PCS),
        grossWt: n(r.ITM_GWT),
        netWt: n(r.ITM_NWT),
        touch: n(r.ITM_TOUCH),
        rate: n(r.ITM_RATE),
        // Inverse of the shared per-gram labour base. Keep the inferred rate unrounded so an
        // unchanged edit retains the persisted amount even for fractional net/ghat weights.
        making:
          n(r.ITM_NWT) + (state.COMPANY_POLICY[0].labourIncludesGhat ? n(r.ITM_GHT_WT) : 0)
            ? n(r.LBR_AMT) /
              (n(r.ITM_NWT) + (state.COMPANY_POLICY[0].labourIncludesGhat ? n(r.ITM_GHT_WT) : 0))
            : 0,
        remark: text(r.ITM_REMARK),
        tblCode: text(r.TBL_CODE),
        itmColor: text(r.ITM_COLOR),
        itmSize: text(r.ITM_SIZE),
        bagWt: n(r.BAG_WT),
        lessWt: n(r.ITM_OTH_WT),
        ghtPct: n(r.ITM_GHT_PRC),
        ghtWt: n(r.ITM_GHT_WT),
        westPct: n(r.ITM_WEST_PRC),
        rateFix: text(r.RATE_FIX),
        labourPct: n(r.LBR_PRC),
        labourType: text(r.LBR_TYPE),
        labourRate: n(r.LBR_RATE),
        labourAmount: n(r.LBR_AMT),
        fineWeight: n(r.ITM_FINE),
        itemAmount: n(r.ITM_AMT),
        lineNetAmount: n(r.NET_AMT),
        lineTotalAmount: n(r.TOT_AMT),
        otherAmount: n(r.OTH_AMT),
        mrp: n(r.ITM_MRP),
        orderDeliveryDate: dateText(r.ORD_DEL_DATE),
        karigarNetWt: n(r.KR_NET_WT),
        karigarTouch: n(r.KR_TOUCH),
        karigarWestPct: n(r.KR_WEST_PRC),
        karigarFine: n(r.KR_FINE),
        karigarName: text(r.KR_NAME),
        tagCost: n(r.TAG_COST),
        vchSrno: n(r.VCH_SRNO),
        oldSrNo: n(r.OLD_SRNO),
        rateType: text(r.RATE_TYPE),
        itType: text(r.IT_TYPE),
        prCode: text(r.PR_CODE),
        oldTblCode: text(r.OLD_TBL_CODE),
        tagStockLess: text(r.TAG_STK_LESS),
        designImageId: text(r.DESIGN_IMG_ID),
        huid: text(r.HM_ID),
        hallmarkId2: text(r.HM_ID2),
        hallmarkId3: text(r.HM_ID3),
        hallmarkId4: text(r.HM_ID4),
        hallmarkIdWt: n(r.HM_ID_WT),
        hallmarkId2Wt: n(r.HM_ID2_WT),
        hallmarkId3Wt: n(r.HM_ID3_WT),
        hallmarkId4Wt: n(r.HM_ID4_WT),
        consumed: [r.TAG_SALE, r.TAG_GEN, r.DESIGN_ISU].some((v) => text(v) === 'Y'),
        components: state.SL_ORD_IDTL.filter((child) => n(child.SR_NO) === n(r.SR_NO))
          .sort((a, b) => n(a.ISR_NO) - n(b.ISR_NO))
          .map(readStoneSubDetail),
      })),
    };
    // Both saved order forms retain exact mapped scalar values; calculations remain server-owned.
    exactOrderValues(dto, x, ORDER_HEADER_FIELDS);
    dto.lines.forEach((line, index) => {
      const parent = d[index];
      exactOrderValues(
        line,
        parent,
        Object.fromEntries(
          Object.entries(ORDER_PARENT_FIELDS).filter(([field]) => field !== 'making'),
        ),
      );
      exactOrderValues(line, parent, {
        fineWeight: 'ITM_FINE',
        itemAmount: 'ITM_AMT',
        lineNetAmount: 'NET_AMT',
        lineTotalAmount: 'TOT_AMT',
      });
      for (const child of line.components) {
        const saved = state.SL_ORD_IDTL.find(
          (row) => n(row.SR_NO) === n(parent.SR_NO) && n(row.ISR_NO) === n(child.isrNo),
        );
        if (saved) exactOrderValues(child, saved, ORDER_COMPONENT_FIELDS);
      }
    });
    return dto;
  });
}

async function assertOrderUnconsumedTx(
  tx: any,
  scope: CompleteOrderScope,
  voucherNo: string,
): Promise<void> {
  // ORD_* identify the source order; the allocation row's own book/year/location identify
  // the later settlement voucher. A missing legacy dimension is unknown, so it can still
  // block a possible match. An explicitly different dimension must not block another order
  // merely because voucher numbers are reused across books, financial years or branches.
  const blocked: any[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "SL_ORD_DETL" d
      WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3
        AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6
        AND (coalesce(d."TAG_SALE",'N')='Y' OR coalesce(d."TAG_GEN",'N')='Y'
          OR coalesce(d."DESIGN_ISU",'N')='Y'
          OR EXISTS (SELECT 1 FROM "SL_ORD_ADJ" a
            WHERE a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE"
              AND a."ORD_NO"=d."VCH_NO"
              AND (nullif(trim(a."ORD_LC"),'') IS NULL OR trim(a."ORD_LC")=d."LC_CODE")
              AND (nullif(trim(a."ORD_YRCD"),'') IS NULL OR trim(a."ORD_YRCD")=d."CO_YEAR")
              AND (nullif(trim(a."ORD_DBCD"),'') IS NULL OR trim(a."ORD_DBCD")=d."CO_BOOK")))
      LIMIT 1 FOR UPDATE OF d`,
    ...orderParams(scope, voucherNo),
  );
  if (blocked.length)
    throw new SaleValidationError(
      'sales order cannot be edited — it has already been issued, tagged, delivered, or adjusted',
    );
}

function prepareSalesOrderEdit(input: SalesOrderInput, requestedVoucherNo: number | string) {
  completeOrderScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requestedDate = orderDate(input.vchDate, 'vchDate');
  orderDate(input.deliveryDate, 'deliveryDate');
  orderDate(input.functionDate, 'functionDate');
  if (input.vchTime != null) orderClock(input.vchTime);
  for (const line of input.lines ?? []) orderDate(line.orderDeliveryDate, 'orderDeliveryDate');
  return { scope, voucherNo, requestedDate };
}

/** Existing internal compatibility entry; it does not establish HTTP session-context admission. */
export async function editSalesOrder(
  prisma: any,
  input: SalesOrderInput,
  requestedVoucherNo: number | string,
): Promise<{ vchNo: number; total: number; advance: number }> {
  const prepared = prepareSalesOrderEdit(input, requestedVoucherNo);
  return withTxBudget(prisma, prepared.scope.tenantId, 'voucher', (tx) =>
    runSalesOrderEditTx(tx, input, prepared),
  );
}

/** Existing edit/replacement write set, entirely within the caller's transaction. */
export async function editSalesOrderTx(
  tx: Tx,
  input: SalesOrderInput,
  requestedVoucherNo: number | string,
): Promise<{ vchNo: number; total: number; advance: number }> {
  return runSalesOrderEditTx(tx, input, prepareSalesOrderEdit(input, requestedVoucherNo));
}

async function runSalesOrderEditTx(
  tx: Tx,
  input: SalesOrderInput,
  prepared: ReturnType<typeof prepareSalesOrderEdit>,
): Promise<{ vchNo: number; total: number; advance: number }> {
  const { scope, voucherNo, requestedDate } = prepared;
  await resolveOrderBookTx(tx, scope, requestedMode(input.orderMainBook));
  await lockOrderMutationTx(tx, scope, voucherNo);
  const persisted = await persistedVoucherHeaderTx(tx, {
    table: 'SL_ORD_DATA',
    scope,
    voucherNo,
    extraColumns: [],
  });
  const state = await assertOrderVersionTx(tx, scope, voucherNo, input.expectedVersion);
  const editBlockedReason = unsupportedOrderEdit(state);
  if (editBlockedReason) throw new SaleValidationError(editBlockedReason);
  const childCounts = new Map<number, number>();
  for (const child of state.SL_ORD_IDTL)
    childCounts.set(n(child.SR_NO), (childCounts.get(n(child.SR_NO)) ?? 0) + 1);
  // Older clients flatten one component into each parent line. Such a request cannot represent
  // an existing multi-component order, including imported noncontiguous parent serials. Require
  // explicit component collections before replacing any rows; never infer deletion from omission.
  if (
    [...childCounts.values()].some((count) => count > 1) &&
    (!input.lines || input.lines.some((line) => line.components === undefined))
  )
    throw new SaleValidationError(
      'This order has multiple components. Reload it and submit complete component lists before editing.',
    );
  const writeDate = requestedDate ?? orderDate(persisted.VCH_DATE, 'saved vchDate', true)!;
  if (input.orderMainBook !== 'TOUR ORDER') await assertSalesOrderDateTx(tx, scope, writeDate);
  for (const date of [persisted.VCH_DATE, writeDate])
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
    });
  await assertOrderUnconsumedTx(tx, scope, voucherNo);
  const hd = formatVoucherNo(text(persisted.HD_VCH_NO));
  await deleteVoucherWriteSetTx(tx, {
    tables: ORDER_WRITE_TABLES,
    key: { scope, voucherNo },
    tempBook: { voucherNo: hd },
  });
  return createSalesOrder(
    undefined,
    { ...input, vchDate: writeDate },
    {
      tx,
      vchNo: Number(voucherNo),
      hdVchNo: hd,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: state.SL_ORD_DATA[0].VCH_CLOCK,
      previousLines: state.SL_ORD_DETL,
      previousComponents: state.SL_ORD_IDTL,
      previousHeader: state.SL_ORD_DATA[0],
    },
  );
}

/** Required-authority entry for the single participating Sales Order HTTP edit route. */
export async function editSalesOrderInSession(
  prisma: TxBudgetPrisma,
  request: { identity: unknown; input: SalesOrderInput; voucherNo: number | string },
): Promise<{ vchNo: number; total: number; advance: number }> {
  // This HTTP entry requires a saved version even though internal/Tour compatibility allows omission.
  if (
    typeof request.input.expectedVersion !== 'string' ||
    request.input.expectedVersion.length !== 64 ||
    /[^0-9a-f]/.test(request.input.expectedVersion)
  ) {
    throw new SaleValidationError('A valid saved Sales Order expectedVersion is required.');
  }
  if (request.input.orderMainBook !== undefined && request.input.orderMainBook !== 'SALES ORDER') {
    throw new SaleValidationError('This session command edits Sales Orders only.');
  }
  // Detach the complete request (including Date objects) before any wait. Admission and work share this scope.
  const input = structuredClone(request.input);
  input.scope = Object.freeze({ ...input.scope });
  const prepared = prepareSalesOrderEdit(input, request.voucherNo);
  return withSessionContextCommand(
    prisma,
    request.identity,
    {
      form: 'Sales/Sales Order',
      action: 'update',
      scope: prepared.scope,
    },
    (tx) => runSalesOrderEditTx(tx, input, prepared),
  );
}

export async function listSalesOrders(
  prisma: any,
  scope: VoucherScope,
  options: { orderMainBook?: OrderMainBook } = {},
): Promise<Record<string, any>[]> {
  completeOrderScope(scope);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const mode = requestedMode(options.orderMainBook);
    const book = await resolveOrderBookTx(tx, scope, mode);
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT h."VCH_NO" AS "vchNo", h."CO_BOOK" AS "book", h."VCH_DATE" AS "vchDate", h."AC_CODE" AS "acCode", h."AC_NAME" AS "acName", coalesce(NULLIF(h."TOT_AMT"::text,'')::numeric,0) AS "total", coalesce(NULLIF(h."ADV_AMT"::text,'')::numeric,0) AS "advance", h."DEL_DATE" AS "delDate"
         FROM "SL_ORD_DATA" h
        WHERE h.tenant_id=$1 AND h."CO_CODE"=$2 AND h."LC_CODE"=$3 AND h."CO_YEAR"::text=$4 AND h."CO_BOOK"=$5
        ORDER BY h."VCH_DATE" DESC,h."VCH_NO" DESC LIMIT 300`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear ?? '',
      book.coBook,
    );
    return rows.map((r) => ({
      ...r,
      vchNo: String(r.vchNo),
      total: Number(r.total),
      advance: Number(r.advance),
    }));
  });
}

export const createTourOrder = (prisma: any, input: SalesOrderInput) =>
  createSalesOrder(prisma, { ...input, orderMainBook: 'TOUR ORDER' });

export const getTourOrder = (
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
) => getSalesOrder(prisma, scope, requestedVoucherNo, { orderMainBook: 'TOUR ORDER' });

export const editTourOrder = (
  prisma: any,
  input: SalesOrderInput,
  requestedVoucherNo: number | string,
) => editSalesOrder(prisma, { ...input, orderMainBook: 'TOUR ORDER' }, requestedVoucherNo);

export const listTourOrders = (prisma: any, scope: VoucherScope) =>
  listSalesOrders(prisma, scope, { orderMainBook: 'TOUR ORDER' });

export const cancelTourOrder = (
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    deleteUser?: string;
    expectedVersion?: string;
  },
) => cancelSalesOrder(prisma, { ...input, orderMainBook: 'TOUR ORDER' });

export type SalesOrderCancelInput = {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
  expectedVersion?: string;
  orderMainBook?: OrderMainBook;
};

function prepareSalesOrderCancel(input: SalesOrderCancelInput) {
  completeOrderScope(input.scope);
  const scope = input.scope;
  const tenantId = scope.tenantId;
  const voucherNo = formatVoucherNo(input.vchNo);
  const key = keyOf(scope, Number(voucherNo));
  return { scope, tenantId, voucherNo, key };
}

/** Existing internal compatibility entry; it does not establish session-context admission. */
export async function cancelSalesOrder(
  prisma: any,
  input: SalesOrderCancelInput,
): Promise<{ cancelled: true }> {
  const prepared = prepareSalesOrderCancel(input);
  return withTxBudget(prisma, prepared.tenantId, 'voucher', (tx) =>
    runSalesOrderCancelTx(tx, input, prepared),
  );
}

/** Existing reversal, temporary row deletion and cancellation evidence in the caller's transaction. */
export async function cancelSalesOrderTx(
  tx: Tx,
  input: SalesOrderCancelInput,
): Promise<{ cancelled: true }> {
  return runSalesOrderCancelTx(tx, input, prepareSalesOrderCancel(input));
}

async function runSalesOrderCancelTx(
  tx: Tx,
  input: SalesOrderCancelInput,
  prepared: ReturnType<typeof prepareSalesOrderCancel>,
): Promise<{ cancelled: true }> {
  const { scope, tenantId, voucherNo, key } = prepared;
  await resolveOrderBookTx(tx, scope, requestedMode(input.orderMainBook));
  await lockOrderMutationTx(tx, scope, voucherNo);
  const header = await persistedVoucherHeaderTx(tx, {
    table: 'SL_ORD_DATA',
    scope,
    voucherNo,
    extraColumns: [
      'AC_CODE',
      'AC_NAME',
      'ADV_AMT',
      'CASH_AMT',
      'CHQ_AMT',
      'CARD_AMT',
      'OLD_GL_AMT',
      'OLD_SL_AMT',
      'OLD_GL',
      'OLD_SL',
    ],
  });
  const state = await assertOrderVersionTx(tx, scope, voucherNo, input.expectedVersion);
  const blocked = unsupportedOrderEdit(state);
  if (blocked) throw new SaleValidationError(blocked);
  if (state.SL_ORD_DETL.some((row) => text(row.TAG_NO) && text(row.TAG_NO) !== 'N'))
    throw new SaleValidationError(
      'A tagged order cannot be deleted in this editor; its stock allocation must be resolved first.',
    );
  await assertPeriodOpen(tx, tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: header.VCH_DATE }] },
  });
  await assertOrderUnconsumedTx(tx, scope, voucherNo);
  const books: any[] = await tx.$queryRawUnsafe(
    `SELECT "BOOK_SNAME","BOOK_NAME" FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 LIMIT 1`,
    tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (books.length !== 1) throw new SaleValidationError('sales order book configuration not found');
  await reverseVoucherTx(tx, tenantId, { tables: [...ORDER_WRITE_TABLES], key });
  await tx.$executeRawUnsafe(
    `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
    tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
    text(header.HD_VCH_NO),
  );
  const now = new Date();
  const desc =
    `Cash/Bank/Card/Ogl/Osl-${n(header.CASH_AMT)}/${n(header.CHQ_AMT)}/${n(header.CARD_AMT)}/${n(header.OLD_GL_AMT)}/${n(header.OLD_SL_AMT)} OG :${n(header.OLD_GL)} OS :${n(header.OLD_SL)}`.slice(
      0,
      150,
    );
  await insertRowTx(tx, 'DELETE_DATA', tenantId, {
    ...key,
    SR_NO: 0,
    VCH_DATE: header.VCH_DATE,
    DELETE_DATE: now,
    VCH_TYPE: books[0].BOOK_SNAME,
    VCH_TIME: header.VCH_TIME,
    DELETE_TIME: now,
    BOOK_NAME: books[0].BOOK_NAME,
    AC_CODE: header.AC_CODE,
    AC_NAME: header.AC_NAME,
    VCH_VAL_DR: 0,
    VCH_VAL_CR: n(header.ADV_AMT),
    FINE_TYPE: 'A',
    VCH_FINE_DR: 0,
    VCH_FINE_CR: 0,
    HD_VCH_NO: header.HD_VCH_NO,
    MAIN_USER: header.MAIN_USER,
    DELETE_USER: input.deleteUser ?? 'system',
    VCH_DESC: desc,
  });
  return { cancelled: true };
}

/** Detach all business values before admission can wait on the retained session row. */
function detachedOrderCommandInput<
  T extends { scope: VoucherScope; orderMainBook?: OrderMainBook },
>(supplied: T, family: OrderMainBook) {
  if (supplied.orderMainBook !== undefined && supplied.orderMainBook !== family)
    throw new SaleValidationError('This session command belongs to the ' + family + ' form.');
  const input = structuredClone(supplied);
  const scope = Object.freeze({ ...input.scope });
  completeOrderScope(scope);
  input.scope = scope;
  input.orderMainBook = family;
  return { input, scope };
}

function requireSessionOrderVersion(value: unknown) {
  if (typeof value !== 'string' || value.length !== 64 || /[^0-9a-f]/.test(value))
    throw new SaleValidationError('A valid saved order expectedVersion is required.');
}

type SessionOrderCreateRequest = { identity: unknown; input: SalesOrderInput };
type SessionOrderCancelRequest = { identity: unknown; input: SalesOrderCancelInput };
type SessionOrderEditRequest = SessionOrderCreateRequest & { voucherNo: number | string };
type OrderCommandPrisma = TxBudgetPrisma;

function createOrderInSession(
  prisma: OrderCommandPrisma,
  request: SessionOrderCreateRequest,
  family: OrderMainBook,
) {
  const { input, scope } = detachedOrderCommandInput(request.input, family);
  const prepared = prepareSalesOrderCreate(input);
  return withSessionContextCommand(
    prisma,
    request.identity,
    {
      form: family === 'SALES ORDER' ? 'Sales/Sales Order' : 'Karigar/Tour Order',
      action: 'create',
      scope,
    },
    prepared.run,
  );
}

function cancelOrderInSession(
  prisma: OrderCommandPrisma,
  request: SessionOrderCancelRequest,
  family: OrderMainBook,
) {
  // Modern HTTP commands require a version; the internal compatibility wrappers remain optional.
  requireSessionOrderVersion(request.input.expectedVersion);
  const { input, scope } = detachedOrderCommandInput(request.input, family);
  const prepared = prepareSalesOrderCancel(input);
  return withSessionContextCommand(
    prisma,
    request.identity,
    {
      form: family === 'SALES ORDER' ? 'Sales/Sales Order' : 'Karigar/Tour Order',
      action: 'delete',
      scope,
    },
    (tx) => runSalesOrderCancelTx(tx, input, prepared),
  );
}

export async function createSalesOrderInSession(
  prisma: OrderCommandPrisma,
  request: SessionOrderCreateRequest,
) {
  return createOrderInSession(prisma, request, 'SALES ORDER');
}
export async function createTourOrderInSession(
  prisma: OrderCommandPrisma,
  request: SessionOrderCreateRequest,
) {
  return createOrderInSession(prisma, request, 'TOUR ORDER');
}
export async function cancelSalesOrderInSession(
  prisma: OrderCommandPrisma,
  request: SessionOrderCancelRequest,
) {
  return cancelOrderInSession(prisma, request, 'SALES ORDER');
}
export async function cancelTourOrderInSession(
  prisma: OrderCommandPrisma,
  request: SessionOrderCancelRequest,
) {
  return cancelOrderInSession(prisma, request, 'TOUR ORDER');
}
export async function editTourOrderInSession(
  prisma: OrderCommandPrisma,
  request: SessionOrderEditRequest,
) {
  requireSessionOrderVersion(request.input.expectedVersion);
  const { input, scope } = detachedOrderCommandInput(request.input, 'TOUR ORDER');
  const prepared = prepareSalesOrderEdit(input, request.voucherNo);
  return withSessionContextCommand(
    prisma,
    request.identity,
    { form: 'Karigar/Tour Order', action: 'update', scope },
    (tx) => runSalesOrderEditTx(tx, input, prepared),
  );
}

// ───────────────────────── F4 · SL_ORD_ADJ order-adjust helpers ─────────────────────────

/** Advance still available on an order to consume into a sale = ADV_AMT − Σ already-adjusted PAID_AMT. */
export async function orderAdvanceAvailableTx(
  tx: any,
  scope: VoucherScope,
  ordNo: number | string,
  ordBook = 'SOR',
): Promise<{ custAc: string; custName: string | null; advance: number; available: number }> {
  const ord: any = (
    await tx.$queryRawUnsafe(
      `SELECT "AC_CODE" ac, "AC_NAME" nm, coalesce(NULLIF("ADV_AMT"::text,'')::numeric,0)::float adv FROM "SL_ORD_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1`,
      scope.coCode,
      ordBook,
      formatVoucherNo(ordNo),
    )
  )[0];
  if (!ord) throw new SaleValidationError(`sales order #${ordNo} not found`);
  const used: any = (
    await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(coalesce(NULLIF("PAID_AMT"::text,'')::numeric,0)),0)::float u FROM "SL_ORD_ADJ" WHERE "CO_CODE"=$1 AND "ORD_NO"=$2`,
      scope.coCode,
      formatVoucherNo(ordNo),
    )
  )[0];
  return {
    custAc: String(ord.ac),
    custName: ord.nm ?? null,
    advance: round2(Number(ord.adv)),
    available: round2(Number(ord.adv) - Number(used.u)),
  };
}

/** Write an SL_ORD_ADJ row consuming `adjustAmt` of an order's advance into a sale (within the sale's tx).
 *  No ledger here — the sale (createSale) reduces the customer Dr by adjustAmt (the advance is applied). */
export async function adjustOrderIntoSaleTx(
  tx: any,
  tenantId: string,
  scope: VoucherScope,
  args: {
    saleVchNo: string;
    ordNo: number | string;
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
    ORD_SIGN: 'C',
    PAID_AMT: round2(args.adjustAmt),
    OLD_VCH_NO: scope.coBook,
    NEW_VCH_NO: args.saleVchNo,
    IT_DESC: `Advance adjusted into sale ${args.saleVchNo}`,
    // TR_SALE_HM.cs carries the full ORDER key on the adjustment so the advance can be traced back to the
    // exact order line: location, year and book alongside the order number, plus its hidden book number.
    ORD_LC: scope.lcCode,
    ORD_YRCD: scope.coYear ?? null,
    ORD_DBCD: scope.coBook ?? null,
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

/**
 * Order Cancel with refund (desktop TR_SL_ORD_ADJ): refund the advance through an operator-chosen
 * account (PaiidAc, default CASH), writing SL_ORD_ADJ + a balanced refund — Dr customer (clear the
 * advance liability) / Cr PaiidAc (paidAmt) + Cr KASAR (kasarAmt kept as a cancellation write-off).
 * The order stays (audit); use cancelSalesOrder for the plain void. Book 'ORC'.
 */
export async function cancelSalesOrderAdjust(
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    paidAc?: string;
    paidAmt?: number;
    kasarAmt?: number;
    itDesc?: string;
    kasarAc?: string;
    vchDate?: Date | string;
    mainUser?: string;
  },
  lifecycle?: OrderWriteContext,
): Promise<{ vchNo: number; refunded: number; kasar: number }> {
  const tenantId = input.scope.tenantId;
  const ordBook = input.scope.coBook ?? 'SOR';
  const run = async (tx: any) => {
    const ord: any = (
      await tx.$queryRawUnsafe(
        `SELECT "AC_CODE" ac, "AC_NAME" nm, coalesce(NULLIF("ADV_AMT"::text,'')::numeric,0)::float adv, coalesce(NULLIF("TOT_AMT"::text,'')::numeric,0)::float tot FROM "SL_ORD_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 LIMIT 1`,
        input.scope.coCode,
        ordBook,
        formatVoucherNo(input.vchNo),
      )
    )[0];
    if (!ord) throw new SaleValidationError(`sales order #${input.vchNo} not found`);
    const custAc = String(ord.ac);
    const paidAmt = round2(input.paidAmt != null ? Number(input.paidAmt) : Number(ord.adv)); // default: refund full advance
    const kasar = round2(Number(input.kasarAmt || 0));
    // N59/G163: the refund/write-off ledgers are NOT literals. The desktop posts the order-cancel
    // adjustment through Ac_Ledr.Order_Adj_Ledr (TR_SL_ORD_ADJ.cs:3665), which answers both accounts
    // from the cancel book's BOOK_DETL slots (1=settlement, 2=kasar) — never 'CASH'/'KASAR', which do
    // not exist in a real AC_MAST. Explicit wins; else resolve on this tx and FAIL-CLOSED if unconfigured.
    const cancelScope: VoucherScope = { ...input.scope, coBook: 'ORC' };
    const paidAc =
      paidAmt > 0
        ? await resolveBookSlotAccountTx(tx, cancelScope, 'cash-settlement', 1, input.paidAc)
        : (input.paidAc ?? '');
    const kasarAc =
      kasar > 0 ? await kasarAccountTx(tx, cancelScope, input.kasarAc, paidAc, kasar) : '';
    const no = lifecycle?.vchNo ?? (await nextVoucherNoTx(tx, { ...input.scope, coBook: 'ORC' }));
    const hdVchNo =
      lifecycle?.hdVchNo ?? (await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: 'ORC' }));
    const mainUser = lifecycle?.mainUser ?? String(input.mainUser ?? '').trim();
    const key: VoucherKey = {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_YEAR: input.scope.coYear ?? '',
      CO_BOOK: 'ORC',
      VCH_NO: formatVoucherNo(no),
    };
    const vchDate = voucherTimestamp(
      input.vchDate ? new Date(input.vchDate) : new Date(),
      lifecycle?.persistedClock,
    );
    const adjRow = {
      ...key,
      SR_NO: 1,
      VCH_DATE: vchDate,
      VCH_TYPE: 'SADJ',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'A',
      BOOK_NAME: 'ORDER CANCEL',
      AC_CODE: custAc,
      AC_NAME: ord.nm ?? null,
      ORD_NO: formatVoucherNo(input.vchNo),
      ORD_AC_CODE: custAc,
      ORD_SIGN: 'D',
      ORD_AMT: round2(Number(ord.tot)),
      PAID_AMT: paidAmt,
      PAID_AC: paidAc,
      KASAR_AMT: kasar,
      ORD_BAL_AMT: round2(Number(ord.tot) - paidAmt - kasar),
      IT_DESC: input.itDesc ?? 'Order Cancel',
      OLD_VCH_NO: formatVoucherNo(input.vchNo),
      VCH_TIME: vchDate,
      HD_VCH_NO: hdVchNo,
      MAIN_USER: mainUser,
    };
    const ledger: LedgerLine[] = [];
    const drCust = round2(paidAmt + kasar);
    if (drCust > 0)
      ledger.push({
        ...key,
        VCH_TYPE: 'SADJ',
        AC_CODE: custAc,
        DR_AMT: drCust,
        CR_AMT: 0,
        SIGN: 'D',
      }); // clear advance liability
    if (paidAmt > 0)
      ledger.push({
        ...key,
        VCH_TYPE: 'SADJ',
        AC_CODE: paidAc,
        DR_AMT: 0,
        CR_AMT: paidAmt,
        SIGN: 'C',
      }); // refund out via chosen account
    if (kasar > 0)
      ledger.push({
        ...key,
        VCH_TYPE: 'SADJ',
        AC_CODE: kasarAc,
        DR_AMT: 0,
        CR_AMT: kasar,
        SIGN: 'C',
      }); // write-off kept
    if (ledger.length) assertBalanced(ledger);
    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: input.scope.coCode,
      LC_CODE: input.scope.lcCode,
      CO_BOOK: 'ORC',
      VCH_NO: hdVchNo,
      BOOK_NAME: 'ORDER CANCEL',
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: 'ORDER CANCEL',
      writes: [{ table: 'SL_ORD_ADJ', rows: [adjRow] }],
    });
    return { vchNo: no, refunded: paidAmt, kasar };
  };
  return lifecycle ? run(lifecycle.tx) : withTxBudget(prisma, tenantId, 'voucher', run);
}

const ADJUST_WRITE_TABLES = [
  'SL_ORD_ADJ',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'APR_DETL',
  'BAR_DETL',
  'BAR_IDTL',
] as const;
function adjustScope(scope: VoucherScope): CompleteOrderScope {
  if (!scope.coYear) throw new SaleValidationError('complete voucher scope (coYear) is required');
  return { ...scope, coYear: scope.coYear, coBook: 'ORC' };
}
export async function getSalesOrderAdjustment(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  const sc = adjustScope(scope),
    voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, sc.tenantId, 'read', async (tx: any) => {
    const p = orderParams(sc, voucherNo);
    const r: any[] = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME","ORD_NO","PAID_AMT","PAID_AC","KASAR_AMT","IT_DESC" FROM "SL_ORD_ADJ" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...p,
    );
    if (!r.length)
      throw new SaleValidationError(`order adjustment voucher not found: ${voucherNo}`);
    const x = r[0];
    return {
      voucherNo: text(x.VCH_NO),
      hiddenVoucherNo: text(x.HD_VCH_NO),
      mainUser: text(x.MAIN_USER),
      vchTime: text(x.VCH_CLOCK),
      vchDate: text(x.VCH_DATE).slice(0, 10),
      orderVchNo: text(x.ORD_NO),
      paidAmt: n(x.PAID_AMT),
      paidAc: text(x.PAID_AC),
      kasarAmt: n(x.KASAR_AMT),
      itDesc: text(x.IT_DESC),
      acCode: text(x.AC_CODE),
      acName: text(x.AC_NAME),
    };
  });
}
export async function editSalesOrderAdjustment(
  prisma: any,
  input: {
    scope: VoucherScope;
    vchNo: number | string;
    paidAc?: string;
    paidAmt?: number;
    kasarAmt?: number;
    itDesc?: string;
    kasarAc?: string;
    vchDate?: Date | string;
    mainUser?: string;
  },
  requestedVoucherNo: number | string,
): Promise<{ vchNo: number; refunded: number; kasar: number }> {
  const sc = adjustScope(input.scope),
    voucherNo = formatVoucherNo(requestedVoucherNo),
    requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, sc.tenantId, 'voucher', async (tx: any) => {
    const persisted = await persistedVoucherHeaderTx(tx, {
      table: 'SL_ORD_ADJ',
      scope: sc,
      voucherNo,
      extraColumns: [],
    });
    for (const date of [persisted.VCH_DATE, requestedDate])
      await assertPeriodOpen(tx, sc.tenantId, {
        ledger: { table: 'AC_DATA', lines: [{ CO_CODE: sc.coCode, VCH_DATE: date }] },
      });
    const hd = formatVoucherNo(text(persisted.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: ADJUST_WRITE_TABLES,
      key: { scope: sc, voucherNo },
      tempBook: { voucherNo: hd },
    });
    return cancelSalesOrderAdjust(prisma, input, {
      tx,
      vchNo: Number(voucherNo),
      hdVchNo: hd,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
    });
  });
}
export async function deleteSalesOrderAdjustment(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string },
): Promise<{ reversed: true }> {
  const sc = adjustScope(input.scope),
    voucherNo = formatVoucherNo(input.vchNo),
    key = keyOf(sc, Number(voucherNo));
  return withTxBudget(prisma, sc.tenantId, 'voucher', async (tx: any) => {
    const persisted = await persistedVoucherHeaderTx(tx, {
      table: 'SL_ORD_ADJ',
      scope: sc,
      voucherNo,
      extraColumns: [],
    });
    await assertPeriodOpen(tx, sc.tenantId, {
      ledger: {
        table: 'AC_DATA',
        lines: [{ CO_CODE: sc.coCode, VCH_DATE: persisted.VCH_DATE }],
      },
    });
    await reverseVoucherTx(tx, sc.tenantId, { tables: [...ADJUST_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      sc.tenantId,
      sc.coCode,
      sc.lcCode,
      sc.coBook,
      text(persisted.HD_VCH_NO),
    );
    return { reversed: true };
  });
}
