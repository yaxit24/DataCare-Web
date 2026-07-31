import { resolveOldGoldValuation } from './oldGoldValuation.js';
import {
  desktopLabourTypeFor,
  effectiveLabourRate,
  legacyLabourModeFor,
} from '../shared/labourDesktop.js';
import {
  averageTouchByItemTx,
  billProfit,
  billProfitEnabledTx,
  todaySaleRateTx,
} from './billProfit.js';
import { withTenant } from '@datacare/db';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { recordFieldChangesTx } from '../vouchers/fieldAudit.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { issueTagTx, restoreTagTx } from '../stock/stock.js';
import {
  assertBalanced,
  assertPeriodOpen,
  insertRowTx,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  metalAmount,
  labourCharge,
  lineNet as calcLineNet,
  billTotals,
  type LabourType,
  type BillTotals,
  lineTotalDesktop,
} from '@datacare/core';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { orderAdvanceAvailableTx, adjustOrderIntoSaleTx } from './salesOrder.js';
import { fineWt } from '../shared/fine.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../shared/bookPolicy.js';
import {
  assertCounterCodes,
  assertHallmarkWeights,
  resolveCounterStockPolicyTx,
} from '../shared/counterStockPolicy.js';
import { resolveRoundingPolicyTx } from '../shared/roundingPolicyLoader.js';
import type { RoundingPolicy } from '../shared/roundingPolicy.js';
import { buildSaleRojmel, rojmelMetalFor } from '../shared/rojmel.js';
import {
  generatedLabourRate,
  resolveSettingsBehaviorTx,
  saleAmountBase,
  stockMovementWeights,
  type LineAmountType,
} from '../shared/settingsBehavior.js';
import { partyCashReceivedTx } from '../finance/finance.js';
import { tenderThresholdDecision } from '../finance/tender.js';

export class SaleValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'SaleValidationError';
  }
}

export interface SaleLineInput {
  // ---- Return-line costing (SL_DETL_RTN) --------------------------------------------------------
  // TR_SALE_RTN.cs carries the item's full costing basis onto the return row so a re-issue of the same
  // tag can be priced from something. Declared on the shared line input because the return path reuses it.
  oldSrNo?: number; // OLD_SRNO — the sale line this return reverses
  otherWt?: number; // ITM_OTH_WT
  itType?: string; // IT_TYPE
  dataTransfer?: string; // DATA_TRFR
  margin?: number; // ITM_MARGIN
  tagSrNo?: number; // TAG_SRNO
  tagType?: string; // TAG_TYPE
  tagLabourPct?: number; // TAG_LBR_PRC
  tagLabourRate?: number; // TAG_LBR_RATE
  tagLabourAmount?: number; // TAG_LBR_AMT
  tagOtherAmount?: number; // TAG_OTH_AMT
  itCode: string;
  tagNo?: string; // tagged item -> issued from stock on save, restored on delete
  vchSrno?: number; // persisted BAR_DETL tag-instance identity
  ordNo?: string;
  ordYrcd?: string;
  ordDbcd?: string;
  ordSrno?: number;
  isuNo?: string;
  isuYrcd?: string;
  isuDbcd?: string;
  isuSrno?: number;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  fineWt?: number;
  metal?: 'G' | 'S'; // server validates against ITEM_MAST.IT_TYPE for unfixed metal posting
  rate?: number; // metal rate (per fine unit)
  metalAmount?: number; // precomputed metal amount (overrides fineWt*rate)
  labourType?: LabourType;
  labourRate?: number;
  labourPct?: number;
  labourFixed?: number;
  otherAmount?: number;
  huid?: string; // hallmark unique id (TR_SALE_HM) -> SL_DETL.HM_ID
  designNo?: string; // SL_DETL.DESIGN_NO
  itmSize?: string; // SL_DETL.ITM_SIZE
  lessWt?: number; // SL_DETL.ITM_OTH_WT (loss/other weight)
  tblCode?: string; // SL_DETL.TBL_CODE (counter)
  mrp?: number; // SL_DETL.ITM_MRP
  bagWt?: number;
  tagGrossWt?: number;
  tagNetWt?: number;
  ghtPct?: number;
  style?: string;
  itemLot?: string;
  remark?: string;
  discountPct?: number;
  discountAmount?: number;
  ghatAmount?: number;
  rateWith?: string;
  rateType?: string;
  tagCost?: number;
  karigarNetWt?: number;
  karigarTouch?: number;
  karigarWestPct?: number;
  karigarFine?: number;
  karigarName?: string;
  employeeCode?: string;
  prCode?: string;
  orderTagStockAdd?: string;
  designImageId?: string;
  hallmarkId2?: string;
  hallmarkId3?: string;
  hallmarkId4?: string;
  hallmarkIdWt?: number;
  hallmarkId2Wt?: number;
  hallmarkId3Wt?: number;
  hallmarkId4Wt?: number;
}

export interface SaleInput {
  scope: VoucherScope; // tenantId, coCode, lcCode, coYear, coBook
  mainUser?: string; // authenticated user; persisted and preserved by edit
  acCode: string; // customer account (required)
  acName?: string;
  billNo?: string;
  vchDate?: Date | string;
  discountAmount?: number;
  discountPct?: number;
  taxRatePct: number;
  taxCode?: string;
  interState: boolean; // checked against server-derived AC_MAST.AC_GST_TYPE; never authoritative
  rateUnfix?: boolean; // SL_DATA.RATE_UNFIX; suppresses normal money legs and posts desktop fine leg 38
  salesAc?: string; // sales income ledger (default 'SALES')
  taxAc?: string; // GST output ledger (default 'GST')
  roundAc?: string; // round-off ledger (default 'ROUNDOFF')
  // Sales-Order advance consumed into this bill (P0-3): applies (part of) an order's advance as settlement.
  orderRef?: { ordNo: string | number; adjustAmt?: number; ordBook?: string };
  crDays?: number; // credit days (SL_DATA.CR_DAYS)
  empCode?: string; // salesperson (SL_DATA.EMP_CODE)
  // Hallmark charge (TR_SALE_HM): a separate hallmarking fee billed on the invoice + its own GST.
  hallmarkAmount?: number; // HM_AMT — total hallmark charge (0/absent for a normal sale)
  hmChargeAc?: string; // hallmark-income ledger (default 'HMCHRG')
  hmTaxPct?: number; // GST% on the hallmark charge (defaults to the bill taxRatePct)
  // Settlement adjustments (desktop totals panel): TCS collected on the bill + Kasar round-off/write-off.
  tcsAmount?: number;
  tcsPct?: number;
  tcsAc?: string; // TCS collected (Cr TCS-payable, billed to customer); default ac 'TCS'
  tcsCode?: string;
  tdsCode?: string;
  tdsPct?: number;
  tdsAmount?: number;
  kasarAmount?: number;
  kasarAc?: string; // Kasar write-off (Dr KASAR), reduces the customer's outstanding; default 'KASAR'
  // Point-of-sale settlement (desktop SL_DATA: CASH_AMT/CARD_AMT/UPI_AMT/CHQ_AMT/OLD_GL_AMT/BILL_OS).
  cashAmt?: number;
  cardAmt?: number;
  upiAmt?: number;
  chequeAmt?: number;
  cashAc?: string; // default 'CASH'
  bankAc?: string; // cheque bank account; default 'BANK' for ledger routing
  cardAc?: string;
  chequeNo?: string;
  bankName?: string;
  cardCommissionAmount?: number;
  cashPaid?: number;
  currentAdjustmentAmount?: number;
  schemeAc?: string;
  schemeAmount?: number;
  pointValue?: number;
  address1?: string;
  address2?: string;
  address3?: string;
  city?: string;
  mobile?: string;
  issueNo?: string;
  issueYear?: string;
  issueBook?: string;
  description?: string;
  ornamentIssued?: boolean;
  oldGoldAc?: string; // default 'OLDGOLD'
  oldGold?: {
    metal?: 'G' | 'S';
    itCode?: string;
    description?: string;
    pcs?: number;
    grossWt?: number;
    otherWt?: number;
    netWt?: number;
    touch?: number;
    conversionPct?: number;
    conversionWt?: number;
    rate?: number;
    rateType?: string;
    amount: number;
  }[];
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

const num = (v: unknown): number => (v == null ? 0 : Number(v));
const round3s = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
const round2s = (n: number): number => Math.round((n + 1e-9) * 100) / 100;

/** Resolve a line's fine weight: explicit fineWt, else desktop (Net+Ght)×(Touch+West%)/100. */
export function lineFine(line: SaleLineInput): number {
  if (line.fineWt != null) return Number(line.fineWt);
  return fineWt(line.netWt, line.ghtWt, line.touch, line.westPct);
}

/** Compute a line's fine/metal/labour/net amounts (pure). */
export function computeLine(
  line: SaleLineInput,
  policy?: RoundingPolicy,
  amountType: LineAmountType = '',
): {
  fine: number;
  metal: number;
  labour: number;
  net: number;
} {
  const fine = lineFine(line);
  const rate =
    line.rate == null ? undefined : policy ? policy.roundItemRate(line.rate) : Number(line.rate);
  // TR_SALE.cs:18367-18417 selects the rate base from CO_SET.SL_AMT_TYPE; the request cannot
  // provide this mode. An explicit metalAmount remains the desktop-style authoritative line value.
  const amountBase = saleAmountBase({ ...line, fineWt: fine }, amountType);
  const metal =
    line.metalAmount != null
      ? Number(line.metalAmount)
      : amountBase > 0 && rate != null
        ? metalAmount(amountBase, rate)
        : 0;
  const labour = line.labourType
    ? labourCharge(
        line.labourType,
        {
          netWt: line.netWt,
          pcs: line.pcs,
          rate: line.labourRate,
          pct: line.labourPct,
          metalAmount: metal,
          fixed: line.labourFixed,
        },
        policy,
      )
    : 0;
  const net = calcLineNet({ metal, labour, other: line.otherAmount });
  return { fine, metal, labour, net };
}

/** Build the balanced double-entry AC_DATA lines for a sale (pure, Req 10.8/13.1).
 *  Settlement: Dr cash/bank/old-gold for amounts received now, Dr customer for the balance (BILL_OS);
 *  Cr sales (taxable) + GST (tax) + round-off. With no payments, the whole total is the customer balance
 *  (credit sale) — identical to the prior behaviour. */
export function buildSaleLedger(p: {
  key: VoucherKey;
  acCode: string;
  salesAc: string;
  taxAc: string;
  roundAc: string;
  controlAc?: string;
  rateUnfix?: boolean;
  vchType?: string;
  totals: Pick<BillTotals, 'total' | 'taxable' | 'tax' | 'roundOff'>;
  incomeLegs?: { ac: string; amount: number }[];
  payments?: {
    cashAc?: string;
    cashAmt?: number;
    bankAc?: string;
    bankAmt?: number;
    oldGoldAc?: string;
    oldGoldAmt?: number;
  };
}): LedgerLine[] {
  const base = { ...p.key, VCH_TYPE: p.vchType ?? 'SALE' };
  const R2 = (x: number): number => Math.round((x + 1e-9) * 100) / 100;
  const lines: LedgerLine[] = [];

  // Desktop Sales_Ledr suppresses the normal customer/income money footprint when RATE_UNFIX='Y'.
  if (!p.rateUnfix) {
    if (p.totals.total !== 0)
      lines.push({
        ...base,
        AC_CODE: p.acCode,
        LD_CODE: p.controlAc ?? p.salesAc,
        DR_AMT: p.totals.total,
        CR_AMT: 0,
        SIGN: 'D',
      });
    const income =
      p.incomeLegs && p.incomeLegs.length
        ? p.incomeLegs
        : [{ ac: p.salesAc, amount: p.totals.taxable }];
    for (const leg of income)
      if (leg.amount !== 0)
        lines.push({
          ...base,
          AC_CODE: leg.ac,
          LD_CODE: p.acCode,
          DR_AMT: 0,
          CR_AMT: leg.amount,
          SIGN: 'C',
        });
    if (p.totals.tax !== 0)
      lines.push({
        ...base,
        AC_CODE: p.taxAc,
        LD_CODE: p.acCode,
        DR_AMT: 0,
        CR_AMT: p.totals.tax,
        SIGN: 'C',
      });
    if (p.totals.roundOff > 0)
      lines.push({
        ...base,
        AC_CODE: p.roundAc,
        LD_CODE: p.acCode,
        DR_AMT: 0,
        CR_AMT: p.totals.roundOff,
        SIGN: 'C',
      });
    else if (p.totals.roundOff < 0)
      lines.push({
        ...base,
        AC_CODE: p.roundAc,
        LD_CODE: p.acCode,
        DR_AMT: Math.abs(p.totals.roundOff),
        CR_AMT: 0,
        SIGN: 'D',
      });
  }

  // Desktop emits a self-balanced party/tender pair, not a netted party balance.
  const addReceipt = (account: string, amount: number): void => {
    const value = R2(amount);
    if (value <= 0) return;
    lines.push({
      ...base,
      AC_CODE: p.acCode,
      LD_CODE: account,
      DR_AMT: 0,
      CR_AMT: value,
      SIGN: 'C',
    });
    lines.push({
      ...base,
      AC_CODE: account,
      LD_CODE: p.acCode,
      DR_AMT: value,
      CR_AMT: 0,
      SIGN: 'D',
    });
  };
  const pay = p.payments ?? {};
  addReceipt(pay.cashAc ?? 'CASH', Number(pay.cashAmt ?? 0));
  addReceipt(pay.bankAc ?? 'BANK', Number(pay.bankAmt ?? 0));
  addReceipt(pay.oldGoldAc ?? 'OLDGOLD', Number(pay.oldGoldAmt ?? 0));
  return lines;
}

/** Desktop Sales_Ledr leg 38: one customer fine-credit row per unfixed sale detail. */
export function buildSaleFineLedger(p: {
  key: VoucherKey;
  acCode: string;
  vchType?: string;
  rateUnfix?: boolean;
  lines: Array<{ metal: 'G' | 'S'; saleAc: string; fine: number }>;
}): LedgerLine[] {
  if (!p.rateUnfix) return [];
  return p.lines
    .filter((line) => round3s(line.fine) !== 0)
    .map((line) => ({
      ...p.key,
      VCH_TYPE: p.vchType ?? 'SALE',
      AC_CODE: p.acCode,
      LD_CODE: line.saleAc,
      IT_TYPE: line.metal,
      SIGN: '-',
      FINE_WT: round3s(line.fine),
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
    }));
}

/** Allocate the bill taxable across distinct per-group income accounts, proportional to each group's
 *  line-net share; the last account absorbs the rounding remainder so Σ legs == taxable exactly. */
export function buildIncomeLegs(
  items: { net: number; ac: string }[],
  taxable: number,
  lineNetTotal: number,
): { ac: string; amount: number }[] {
  const R2 = (x: number): number => Math.round((x + 1e-9) * 100) / 100;
  const byAc = new Map<string, number>();
  for (const it of items) byAc.set(it.ac, R2((byAc.get(it.ac) ?? 0) + it.net));
  const acs = [...byAc.keys()];
  if (acs.length <= 1) return [{ ac: acs[0] ?? 'SALES', amount: R2(taxable) }];
  const legs: { ac: string; amount: number }[] = [];
  let allocated = 0;
  for (let i = 0; i < acs.length; i++) {
    const ac = acs[i] as string;
    const amount =
      i === acs.length - 1
        ? R2(taxable - allocated)
        : lineNetTotal > 0
          ? R2((taxable * (byAc.get(ac) as number)) / lineNetTotal)
          : 0;
    if (i < acs.length - 1) allocated = R2(allocated + amount);
    legs.push({ ac, amount });
  }
  return legs;
}

function keyOf(s: VoucherScope, vchNo: number | string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'SAL',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export interface SaleResult {
  vchNo: number;
  totals: BillTotals;
  /**
   * Voucher margin, present only when `CO_SET_NEW.BILL_PROFIT` is on. Four desktop forms show this and the
   * web had none. Absent rather than zero when the setting is off, so a caller cannot mistake "hidden" for
   * "no margin".
   */
  billProfit?: { total: number; lines: { basis: string; cost: number; profit: number }[] };
}

/**
 * Create a sale end-to-end in ONE transaction (Req 10): allocate voucher no, issue each tag
 * (double-issue-guarded), compute GST split + bill totals, then post the balanced ledger plus
 * SL_DATA/SL_DETL/SL_IDTL. Any failure rolls the whole sale back.
 */
interface WriteSaleContext {
  vchNo: number;
  hdVchNo: string;
  mainUser: string;
  persistedClock?: unknown;
  isEdit: boolean;
  /** Persisted header read back before the rewrite, for the USER_DATA per-field edit audit. */
  persistedHeader?: Record<string, unknown>;
  /** User performing the edit (desktop NEW_USER); the original stays in MAIN_USER/USER_NAME. */
  editingUser?: string | null;
}

function completeSaleScope(
  scope: VoucherScope,
): asserts scope is VoucherScope & { coYear: string; coBook: string } {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new SaleValidationError(
      'sale requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

async function configuredSaleBookNameTx(
  tx: any,
  scope: VoucherScope & { coBook: string },
): Promise<string> {
  const rows: Array<{ BOOK_NAME: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (rows.length !== 1) {
    throw new SaleValidationError(`sale book configuration is ambiguous: ${scope.coBook}`);
  }
  return String(rows[0]?.BOOK_NAME ?? '').trim();
}

/**
 * Desktop TR_SALE write core. Main numbering is MAX(SL_DATA.VCH_NO)+1 by company/location/year/book
 * (TR_SALE.cs:15139); hidden numbering is allocated separately from TEMP_BOOK_DATA without year
 * (TR_SALE.cs:14209,15151). Edits call this after removing the prior write set in the same tx.
 */
async function writeSaleTx(
  tx: any,
  input: SaleInput,
  lines: SaleLineInput[],
  ctx: WriteSaleContext,
): Promise<SaleResult> {
  if (!input.acCode) throw new SaleValidationError('customer account (acCode) is required');
  if (!lines || lines.length === 0)
    throw new SaleValidationError('at least one line item is required');
  completeSaleScope(input.scope);

  const salesAc = input.salesAc ?? 'SALES';
  const fallbackTaxAc = input.taxAc ?? 'GST';
  const requestedRoundAc = input.roundAc;

  const tenantId = input.scope.tenantId;
  const vchNo = ctx.vchNo;
  const key = keyOf(input.scope, vchNo);
  const bookPolicy = await resolveBookPolicyTx(tx, input.scope, 'SALES');
  const roundingPolicy = await resolveRoundingPolicyTx(tx, input.scope);

  // TR_PURC.cs:12868 — counter code is mandatory only when CO_SET_NEW.COUNTER_STK='Y'; the flag is read
  // server-side per transaction, never from the request.
  const counterPolicy = await resolveCounterStockPolicyTx(tx, {
    tenantId: input.scope.tenantId,
    coCode: input.scope.coCode,
  });
  assertCounterCodes(
    counterPolicy,
    lines.map((l) => ({ itCode: l.itCode, tblCode: l.tblCode })),
  );
  // A filled hallmark ID must carry a weight.
  for (const l of lines) assertHallmarkWeights(l);
  const behavior = await resolveSettingsBehaviorTx(tx, input.scope);
  const saleFlagRows: Array<{ SL_TDS_TAX: unknown; OS_BILL_ORNA_ISU: unknown }> =
    await tx.$queryRawUnsafe(
      `SELECT "SL_TDS_TAX","OS_BILL_ORNA_ISU" FROM "CO_SET_NEW"
        WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
      tenantId,
      input.scope.coCode,
    );
  if (saleFlagRows.length > 1) {
    throw new SaleValidationError(`sale settings are ambiguous for company ${input.scope.coCode}`);
  }
  const tdsEnabled = text(saleFlagRows[0]?.SL_TDS_TAX).toUpperCase() === 'Y';
  // MS_OPNCOMP.cs:1144-1147 defaults blank OS_BILL_ORNA_ISU to Y.
  const osBillOrnamentIssue =
    (text(saleFlagRows[0]?.OS_BILL_ORNA_ISU).toUpperCase() || 'Y') === 'Y';
  const configuredBookName = await configuredSaleBookNameTx(tx, input.scope);
  const taxPolicy = await resolveTaxPolicyTx(tx, input.scope, {
    acCode: input.acCode,
    taxPct: input.taxRatePct,
    taxCode: input.taxCode,
  });
  if (input.interState !== taxPolicy.interState) {
    throw new SaleValidationError('interState does not match the persisted customer GST type');
  }
  if (input.hmTaxPct != null && Number(input.hmTaxPct) !== input.taxRatePct) {
    throw new SaleValidationError(
      'hallmark tax rate does not match the configured sale tax policy',
    );
  }
  const interState = taxPolicy.interState;
  const taxAc = taxPolicy.taxAc ?? fallbackTaxAc;

  // compute lines + totals
  const computed = lines.map((line) => {
    const rounded =
      line.rate == null ? line : { ...line, rate: roundingPolicy.roundItemRate(line.rate) };
    const effective = input.rateUnfix ? { ...rounded, metalAmount: 0, rate: undefined } : rounded;
    const calc = computeLine(effective, roundingPolicy, behavior.saleAmountType);
    const basis = rounded.labourType === 'per_piece' ? num(rounded.pcs) : num(rounded.netWt);
    const generated = generatedLabourRate(calc.labour, basis, behavior.labourRateGeneration);
    return {
      in: generated == null ? rounded : { ...rounded, labourRate: generated },
      calc,
    };
  });
  const lineNetTotal = computed.reduce((s, c) => s + c.calc.net, 0);
  const totals = billTotals(
    {
      lineNetTotal,
      discountAmount: input.discountAmount,
      taxRatePct: input.taxRatePct,
      interState: interState,
    },
    roundingPolicy,
  );

  // Per-group income accounts (desktop GROUP_MAST.SALE_AC): map each item → its group's sale account,
  // fall back to the single salesAc when unmapped. Income is split across distinct SALE_ACs (Σ == taxable).
  const itCodes = Array.from(
    new Set(lines.map((l) => String(l.itCode ?? '').trim()).filter(Boolean)),
  );
  const saleAcByItem: Record<string, string> = {};
  const metalByItem: Record<string, 'G' | 'S'> = {};
  // The Rojmel's IT_DESC carries the item NAME (Ac_Rojmel.Sales_Rojmel selects C.IT_NAME); all 245 real
  // sale metal rows have it populated.
  const nameByItem: Record<string, string> = {};
  if (itCodes.length) {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT i."IT_CODE" ic, i."IT_TYPE" metal, i."IT_NAME" iname, g."SALE_AC" sac FROM "ITEM_MAST" i
         LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id
          AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
         WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"::text = ANY($3::text[])`,
      input.scope.tenantId,
      input.scope.coCode,
      itCodes,
    );
    for (const r of rows) {
      const item = String(r.ic ?? '').trim();
      const account = String(r.sac ?? '').trim();
      const metal = String(r.metal ?? '')
        .trim()
        .toUpperCase();
      if (!item || !account)
        throw new SaleValidationError(`missing GROUP_MAST.SALE_AC for item ${item || '?'}`);
      saleAcByItem[item] = account;
      if (metal === 'G' || metal === 'S') metalByItem[item] = metal;
      nameByItem[item] = r.iname != null ? String(r.iname) : '';
    }
    const missing = itCodes.filter((item) => !saleAcByItem[item]);
    if (missing.length)
      throw new SaleValidationError(
        `item/group posting configuration missing: ${missing.join(', ')}`,
      );
    if (input.rateUnfix) {
      const missingMetal = itCodes.filter((item) => !metalByItem[item]);
      if (missingMetal.length)
        throw new SaleValidationError(
          `item metal type missing for unfixed sale: ${missingMetal.join(', ')}`,
        );
    }
  }
  const incomeLegs = buildIncomeLegs(
    computed.map((c) => ({
      net: c.calc.net,
      ac: saleAcByItem[String(c.in.itCode ?? '').trim()] ?? salesAc,
    })),
    totals.taxable,
    lineNetTotal,
  );

  // Hallmark charge (TR_SALE_HM): an extra hallmarking fee + its own GST, billed to the customer.
  // 0/absent ⇒ a normal sale, identical to before (no HM legs, TOT_AMT = item total).
  const hmAmt = round2s(num(input.hallmarkAmount));
  const hmTaxPct = input.hmTaxPct ?? input.taxRatePct;
  const hmTax = roundingPolicy.roundTaxAmount((hmAmt * hmTaxPct) / 100);
  const hmCgst = interState ? 0 : roundingPolicy.roundTaxAmount(hmTax / 2);
  const hmSgst = interState ? 0 : roundingPolicy.roundTaxAmount(hmTax - hmCgst);
  const hmIgst = interState ? hmTax : 0;
  const grandTotal = roundingPolicy.roundBillTotal(totals.total + hmAmt + hmTax);
  // TCS (collected on the bill, billed to the customer) + Kasar (round-off/write-off, reduces receivable).
  const tcsPct = num(input.tcsPct);
  const tcs =
    input.tcsAmount != null
      ? round2s(num(input.tcsAmount))
      : round2s((totals.total * tcsPct) / 100);
  const kasar = round2s(num(input.kasarAmount));
  const grandWithTcs = roundingPolicy.roundBillTotal(grandTotal + tcs);

  // TR_SALE.cs:15111-15128: taxable sale bill value >= PAN_CARD_VAL blocks save for the generic
  // cash party (00045), or when the selected party's persisted AC_MAST.AC_PANNO is blank.
  if (
    tenderThresholdDecision({
      cashAmount: num(input.cashAmt),
      priorCash: 0,
      billValue: grandWithTcs,
      cashLimit: behavior.cashLimit,
      panCardVal: behavior.panCardVal,
    }).panRequired
  ) {
    if (String(input.acCode) === '00045') {
      throw new SaleValidationError(
        `Please Select Party Account Because Bill Value > ${behavior.panCardVal}`,
      );
    }
    const parties: Array<{ pan: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "AC_PANNO" AS pan FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "AC_CODE"::text=$4::text
        ORDER BY row_id`,
      tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      String(input.acCode),
    );
    if (parties.length !== 1) {
      throw new SaleValidationError(`party PAN configuration is ambiguous: ${input.acCode}`);
    }
    if (!String(parties[0]?.pan ?? '').trim()) {
      throw new SaleValidationError(
        `Please Insert Party PanNo in Party mast...BIll Value > ${behavior.panCardVal}`,
      );
    }
  }

  const validateConfiguredAccount = (
    label: string,
    requested: string | undefined,
    configured: string,
  ): string => {
    if (requested && requested.trim() !== configured)
      throw new SaleValidationError(`${label} does not match BOOK_DETL configuration`);
    return configured;
  };
  const controlAc =
    input.rateUnfix || totals.total === 0
      ? salesAc
      : await resolveBookAccountTx(tx, input.scope, bookPolicy, 1);
  let cashAc = input.cashAc ?? 'CASH';
  if (round2s(num(input.cashAmt)) !== 0) {
    cashAc = validateConfiguredAccount(
      'cash account',
      input.cashAc,
      await resolveBookAccountTx(tx, input.scope, bookPolicy, 2),
    );
  }
  // DC_Main.cs:2149-2165 + TR_SALE.cs:14978-14988: cumulative party cash strictly above
  // CASH_LIMIT blocks save; the generic cash party 00045 is exempt and limit 0 disables the gate.
  if (round2s(num(input.cashAmt)) > 0 && input.acCode !== '00045') {
    const priorCash = await partyCashReceivedTx(tx, input.scope, input.acCode, cashAc);
    if (
      tenderThresholdDecision({
        cashAmount: num(input.cashAmt),
        priorCash,
        billValue: grandWithTcs,
        cashLimit: behavior.cashLimit,
        panCardVal: behavior.panCardVal,
      }).cashBlocked
    ) {
      throw new SaleValidationError(
        `Cash Recieved Limit Amount = ${behavior.cashLimit} \r\nOld Ledr Value Is ${priorCash} \r\nAnd Total Cash Amount Is ${round2s(num(input.cashAmt) + priorCash)} You Can Not Receive More Then Cash Limit ...`,
      );
    }
  }

  // TR_SALE.cs: the order-pick grid rejects the same order line twice
  // (`mSG_ORD[X,5] + mSG_ORD[X,1]` equal at a different row). Enforced here across the request's
  // lines so an order line cannot be consumed twice in one bill.
  const orderKeys = new Set<string>();
  for (const l of lines) {
    const ordNo = text(l.ordNo);
    if (!ordNo) continue;
    const key = `${text(l.ordDbcd)}|${text(l.ordYrcd)}|${ordNo}|${l.ordSrno ?? ''}`;
    if (orderKeys.has(key)) throw new SaleValidationError(DESKTOP_MESSAGES.DUPLICATE_ORDER);
    orderKeys.add(key);
  }

  // TR_SALE.cs settlement guards, desktop wording preserved verbatim:
  //   row 6: Val(MSG2_TOTAL[6,3]) != 0 AND MSG2_TOTAL[6,4] = ''  -> cheque amount without bank a/c
  //   row 7: Val(MSG2_TOTAL[7,3]) != 0 AND MSG2_TOTAL[7,4] = '' AND CardCommAdj = 'N'
  if (round2s(num(input.chequeAmt)) !== 0 && !text(input.bankAc)) {
    throw new SaleValidationError(DESKTOP_MESSAGES.CHEQUE_WITHOUT_BANK);
  }
  if (
    round2s(num(input.cardAmt)) !== 0 &&
    !text(input.cardAc) &&
    !behavior.cardCommissionAdjustment
  ) {
    throw new SaleValidationError(DESKTOP_MESSAGES.CARD_WITHOUT_BANK);
  }
  let roundAc = requestedRoundAc ?? 'ROUNDOFF';
  // BOOK_DETL is a per-book account SLOT table: SR_NO 1 sale, 2 cash, 3 kasar, 4 advance, 5 discount,
  // 6 labour income, 7 cash purchase, 8 scheme bonus. The Rojmel's advance row names slot 4.
  let advanceAc = '';
  let kasarAc = input.kasarAc ?? 'KASAR';
  if (totals.roundOff !== 0 || kasar !== 0) {
    const configured = await resolveBookAccountTx(tx, input.scope, bookPolicy, 3);
    roundAc = validateConfiguredAccount('round account', requestedRoundAc, configured);
    kasarAc = validateConfiguredAccount('kasar account', input.kasarAc, configured);
  }

  // Resolve and reserve each exact desktop tag instance inside this voucher transaction.
  const issuedTags = new Map<number, Awaited<ReturnType<typeof issueTagTx>>>();
  for (const [index, line] of lines.entries()) {
    if (!line.tagNo) continue;
    issuedTags.set(
      index,
      await issueTagTx(tx, {
        CO_CODE: key.CO_CODE,
        LC_CODE: key.LC_CODE,
        TAG_NO: line.tagNo,
        VCH_SRNO: line.vchSrno,
        IT_CODE: line.itCode,
      }),
    );
  }

  const voucherDate = input.vchDate ? new Date(input.vchDate) : new Date();
  // TR_SALE.cs:14242-14243,15331 preserves the opened voucher's time-of-day on edit.
  const sharedVoucherTime = voucherTimestamp(voucherDate, ctx.persistedClock);

  // Desktop SL_DETL assigns all production-schema columns below for every accepted item row.
  const buildSaleDetailRow = (c: (typeof computed)[number], idx: number) => {
    const lineTax = (c.calc.net * input.taxRatePct) / 100;
    const half = interState ? 0 : roundingPolicy.roundTaxAmount(lineTax / 2);
    const igst = interState ? roundingPolicy.roundTaxAmount(lineTax) : 0;
    const roundedLineTax = roundingPolicy.roundTaxAmount(half * 2 + igst);
    const tagStock = issuedTags.get(idx)?.stock;
    const tagGross =
      c.in.tagGrossWt != null
        ? num(c.in.tagGrossWt)
        : c.in.tagNo
          ? num(tagStock?.ITM_GWT ?? c.in.grossWt)
          : num(c.in.grossWt);
    const tagNet =
      c.in.tagNetWt != null
        ? num(c.in.tagNetWt)
        : c.in.tagNo
          ? num(tagStock?.ITM_NWT ?? c.in.netWt)
          : num(c.in.netWt);
    return {
      ...key,
      VCH_DATE: voucherDate,
      VCH_TIME: sharedVoucherTime,
      HD_VCH_NO: ctx.hdVchNo,
      VCH_TYPE: bookPolicy.vchType,
      INOUT_TYPE: bookPolicy.inout,
      ENTRY_TYPE: 'S',
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      SR_NO: idx + 1,
      OLD_SRNO: idx + 1,
      IT_CODE: c.in.itCode,
      IT_TYPE: metalByItem[String(c.in.itCode ?? '').trim()] ?? c.in.metal ?? '',
      TAG_NO: c.in.tagNo ?? 'N',
      VCH_SRNO: issuedTags.get(idx)?.VCH_SRNO ?? 0,
      ITM_LOT: c.in.itemLot ?? '',
      DESIGN_NO: c.in.designNo ?? '',
      ITM_STYLE: c.in.style ?? '',
      ITM_SIZE: c.in.itmSize ?? '',
      HM_ID: c.in.huid ?? '',
      BAG_WT: num(c.in.bagWt),
      ITM_PCS: num(c.in.pcs),
      ITM_GWT: num(c.in.grossWt),
      TAG_GWT: tagGross,
      ITM_OTH_WT: num(c.in.lessWt),
      ITM_NWT: num(c.in.netWt),
      TAG_NWT: tagNet,
      ITM_GHT_PRC: num(c.in.ghtPct),
      ITM_GHT_WT: num(c.in.ghtWt),
      ITM_TOUCH: num(c.in.touch),
      ITM_WEST_PRC: num(c.in.westPct),
      ITM_FINE: c.calc.fine,
      LBR_PRC: num(c.in.labourPct),
      // LBR_RATE is DERIVED when the operator gave a percentage instead of a rate.
      //
      // TR_SALE.cs:11021 computes `LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof)`, and every one
      // of the six labour-amount branches then multiplies by that column. Writing the request value verbatim
      // stored 0 on every percentage line — verified live: ITM_RATE 6200, LBR_PRC 12, LBR_RATE 0.00 where the
      // desktop writes 744. The column is read back when a voucher is reopened, so a zero there silently
      // changes the recomputed amount.
      LBR_RATE: effectiveLabourRate(
        num(c.in.labourRate),
        num(c.in.rate),
        num(c.in.labourPct),
        roundingPolicy.labourDecimals,
      ),
      // LBR_TYPE selects the weight BASIS, it is not a pricing mode. CO_SET.LBR_TYPE offers exactly
      // G "Gorss Wise", N "Net Wise", K "Kg Wise", P "Pcs Wise", and the column is varchar(1).
      //
      // The previous map sent `per_gram` to 'G', but G is GROSS weight — a per-gram charge on net weight is
      // 'N' (TR_SALE.cs:11119 vs :11104). It also emitted '%' for a percentage, which is not a value the
      // column ever holds, and sent `fixed` to 'N', which the desktop reads as net-weight-times-rate.
      //
      // A percentage is not a type: it derives the rate above and keeps whatever basis applies, which is why
      // it maps to the company default rather than to a code of its own.
      LBR_TYPE: desktopLabourTypeFor(c.in.labourType, behavior.labourType),
      LBR_AMT: c.calc.labour,
      DISC_PRC: num(c.in.discountPct),
      DISC_AMT: num(c.in.discountAmount),
      GHT_AMT: num(c.in.ghatAmount),
      OTH_AMT: num(c.in.otherAmount),
      RATE_WITH: c.in.rateWith ?? '',
      ITM_RATE: input.rateUnfix ? 0 : num(c.in.rate),
      ITM_AMT: c.calc.metal,
      ITM_MRP: num(c.in.mrp),
      // TR_SALE.cs: mSG[X,35] = Round(itemAmt + labourAmt + othAmt, 0) and mSG[X,37] = mSG[X,35], so
      // both persisted columns are the same tax-EXCLUSIVE whole-rupee figure. `Math.Round` in .NET is
      // half-to-even, which `lineTotalDesktop` reproduces.
      TOT_AMT: lineTotalDesktop({
        itemAmount: c.calc.metal,
        labourAmount: c.calc.labour,
        otherAmount: num(c.in.otherAmount),
      }),
      TAX_PRC: input.taxRatePct,
      NET_AMT: lineTotalDesktop({
        itemAmount: c.calc.metal,
        labourAmount: c.calc.labour,
        otherAmount: num(c.in.otherAmount),
      }),
      HM_AMT: 0,
      KR_NET_WT: num(c.in.karigarNetWt),
      KR_TOUCH: num(c.in.karigarTouch),
      KR_WEST_PRC: num(c.in.karigarWestPct),
      KR_FINE: num(c.in.karigarFine),
      TAG_COST: num(c.in.tagCost),
      KR_NAME: c.in.karigarName ?? '',
      RATE_TYPE: c.in.rateType ?? '',
      PR_CODE: c.in.prCode ?? '',
      ITM_REMARK: c.in.remark ?? '',
      ISU_NO: c.in.isuNo ?? '',
      ISU_LC_CODE: input.scope.lcCode,
      ISU_YRCD: c.in.isuYrcd ?? '',
      ISU_DBCD: c.in.isuDbcd ?? '',
      ISU_SRNO: c.in.isuSrno ?? 0,
      HM_ID2: c.in.hallmarkId2 ?? '',
      HM_ID3: c.in.hallmarkId3 ?? '',
      HM_ID4: c.in.hallmarkId4 ?? '',
      HM_ID_WT: num(c.in.hallmarkIdWt),
      HM_ID2_WT: num(c.in.hallmarkId2Wt),
      HM_ID3_WT: num(c.in.hallmarkId3Wt),
      HM_ID4_WT: num(c.in.hallmarkId4Wt),
      ORD_LC_CODE: input.scope.lcCode,
      ORD_NO: c.in.ordNo ?? '',
      ORD_YRCD: c.in.ordYrcd ?? '',
      ORD_DBCD: c.in.ordDbcd ?? '',
      ORD_SRNO: c.in.ordSrno ?? 0,
      ORD_TAG_STK_ADD: c.in.orderTagStockAdd ?? '',
      DESIGN_IMG_ID: c.in.designImageId ?? '',
      EMP_CODE: c.in.employeeCode ?? input.empCode ?? '',
      MAIN_USER: ctx.mainUser,
      ITM_CGST_AMT: half,
      ITM_SGST_AMT: half,
      ITM_IGST_AMT: igst,
      IT_TAX_AMT: roundedLineTax,
      TBL_CODE: c.in.tblCode ?? (c.in.tagNo ? '' : '001'),
      ADD_USER: null,
      DATA_TRFR: null,
      FINE_RATE: null,
      GRAND_TOTAL: null,
      ITM_COLOR: null,
      IT_DISC_AMT: null,
      LOT_NO: null,
      MCX_RATE: null,
      NEW_VCH_NO: null,
      OLD_VCH_NO: null,
      PRM_AMT: null,
      PRM_DISC: null,
      TAXABL_RATE: null,
      TAX_CODE: null,
      TAX_FREE_AMT: null,
      TAX_TYPE: null,
    };
  };
  const idtl = computed
    .filter((c) => c.in.tagNo)
    .map((c, idx) => ({
      ...key,
      VCH_TYPE: bookPolicy.vchType,
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'S',
      SR_NO: idx + 1,
      ISR_NO: 1,
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      TAG_NO: c.in.tagNo,
      VCH_SRNO: issuedTags.get(computed.indexOf(c))?.VCH_SRNO ?? 0,
      IT_CODE: c.in.itCode,
      IT_PCS: num(c.in.pcs),
      IT_GWT: num(c.in.grossWt),
      IT_RATE: num(c.in.rate),
      IT_AMT: c.calc.metal,
      IT_LBR_AMT: c.calc.labour,
      IT_NET_AMT: c.calc.net,
    }));

  // Every sale line moves stock: tagged rows carry their persisted identity; loose rows use N/0.
  const mainStock = computed.map((c, idx) => {
    const movementWeight = stockMovementWeights(
      c.in,
      issuedTags.get(idx)?.stock,
      behavior.stockWeightSource,
    );
    return {
      ...key,
      SR_NO: idx + 1,
      VCH_DATE: voucherDate,
      VCH_TYPE: bookPolicy.vchType,
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      IT_CODE: c.in.itCode,
      TAG_NO: c.in.tagNo ?? 'N',
      VCH_SRNO: issuedTags.get(idx)?.VCH_SRNO ?? 0,
      TR_TYPE: 'S',
      ITM_SIGN: '-',
      // ITM_QTY is a stock-MOVEMENT count, not a weight. Measured on the real customer database: every one
      // of the 267 MAIN_STOCK rows on the sale books (026/027/029/030/032) holds exactly 1, and across all
      // 1856 rows it is an integer without exception - 1792 are 1, the rest small signed counts on other
      // books. It coincides with ITM_PCS on 95% of rows only because most lines are a single piece; where
      // pieces is 2 the desktop still writes 1.
      //
      // This previously wrote netWt, so a 10.360 g line put 10.360 in a column whose real domain is a small
      // signed integer. Found by replaying a real voucher: desktop 1 against web 10.360.
      ITM_QTY: 1,
      ITM_PCS: num(c.in.pcs) || 1,
      ITM_GWT: movementWeight.grossWt,
      ITM_NWT: movementWeight.netWt,
      ITM_TOUCH: num(c.in.touch),
      ITM_FINE: c.calc.fine,
      ITM_RATE: num(c.in.rate),
      ITM_AMT: c.calc.metal,
      LBR_AMT: c.calc.labour,
      NET_AMT: c.calc.net,
    };
  });

  const oldMetalRows = input.oldGold ?? [];
  const oldGoldAmount = round2s(
    oldMetalRows.filter((g) => (g.metal ?? 'G') === 'G').reduce((sum, g) => sum + num(g.amount), 0),
  );
  const oldSilverAmount = round2s(
    oldMetalRows.filter((g) => g.metal === 'S').reduce((sum, g) => sum + num(g.amount), 0),
  );
  const oldGoldWeight = round3s(
    oldMetalRows.filter((g) => (g.metal ?? 'G') === 'G').reduce((sum, g) => sum + num(g.netWt), 0),
  );
  const oldSilverWeight = round3s(
    oldMetalRows.filter((g) => g.metal === 'S').reduce((sum, g) => sum + num(g.netWt), 0),
  );

  const header = {
    ...key,
    BILL_NO: input.billNo ?? formatVoucherNo(vchNo),
    AC_CODE: input.acCode,
    AC_NAME: input.acName ?? '',
    VCH_DATE: voucherDate,
    VCH_TIME: sharedVoucherTime,
    HD_VCH_NO: ctx.hdVchNo,
    MAIN_USER: ctx.mainUser,
    NET_AMT: totals.net,
    DISC_PRC: num(input.discountPct),
    DISC_AMT: totals.discount,
    TAX_PRC: input.taxRatePct,
    TAX_CODE: taxPolicy.taxCode ?? '',
    AC_GST_TYPE: taxPolicy.accountGstType ?? '',
    TAX_AMT: totals.tax,
    CGST_TAX: totals.cgst,
    SGST_TAX: totals.sgst,
    IGST_TAX: totals.igst,
    ROF_AMT: tdsEnabled ? 0 : totals.roundOff,
    TCS_CODE: input.tcsCode ?? '',
    TCS_PRC: tcsPct,
    TCS_AMT: tcs,
    TDS_CODE: tdsEnabled ? (input.tdsCode ?? '') : '',
    TDS_PRC: tdsEnabled ? num(input.tdsPct) : 0,
    TDS_AMT: tdsEnabled ? num(input.tdsAmount) : 0,
    LBR_AMT: round2s(computed.reduce((sum, c) => sum + c.calc.labour, 0)),
    OTH_AMT: round2s(computed.reduce((sum, c) => sum + num(c.in.otherAmount), 0)),
    TOT_AMT: totals.total,
    CARD_COM_AMT: round2s(num(input.cardCommissionAmount)),
    CASH_PAID: round2s(num(input.cashPaid)),
    CRNT_ADJ_AMT: round2s(num(input.currentAdjustmentAmount)),
    OLD_GL: oldGoldWeight,
    OLD_SL: oldSilverWeight,
    SCHM_AC: input.schemeAc ?? '',
    SCHM_AMT: round2s(num(input.schemeAmount)),
    POINT_VAL: num(input.pointValue),
    CARD_AC: input.cardAc ?? '',
    BANK_AC: input.bankAc ?? '',
    CHQ_NO: input.chequeNo ?? '',
    BANK_NAME: input.bankName ?? '',
    CARD_ADJ: behavior.cardCommissionAdjustment ? 'Y' : 'N',
    CR_DAYS: num(input.crDays),
    ADD1: input.address1 ?? '',
    ADD2: input.address2 ?? '',
    ADD3: input.address3 ?? '',
    CITY: input.city ?? '',
    MOBILE: input.mobile ?? '',
    HM_AMT: hmAmt,
    HM_TAX_CODE: '',
    HM_TAX_PRC: 0,
    HM_TAX_AMT: hmTax,
    RTN_TOT_AMT: 0,
    RTN_CHQ_AMT: 0,
    RTN_CARD_AMT: 0,
    RTN_CASH_AMT: 0,
    RTN_KASAR_AMT: 0,
    RTN_BILL_OS: 0,
    ISU_NO: input.issueNo ?? '',
    ISU_LC_CODE: input.scope.lcCode,
    ISU_YRCD: input.issueYear ?? '',
    ISU_DBCD: input.issueBook ?? '',
    EMP_CODE: input.empCode ?? '',
    VCH_DESC: input.description ?? '',
    ORNA_ISU: osBillOrnamentIssue ? 'W' : input.ornamentIssued === false ? 'N' : 'Y',
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    MOB_ENTRY_SAVE: 'Y',
    RATE_UNFIX: input.rateUnfix ? 'Y' : 'N',
    OZ_RATE: 0,
    OZ_CONV: 0,
    FX_RATE: 0,
    FX_CODE: '',
    MTL_RATE: 0,
    // Written by other desktop forms, not TR_SALE.
    ACK_DATE: null,
    ACK_NO: null,
    IRN_NO: null,
    IT_TYPE: null,
    NEW_VCH_NO: null,
    OLD_VCH_NO: null,
    OS_ADJ_AMT: null,
    PARTY_FINE: null,
    RTN_NET_AMT: null,
    TOT_TAX_FREE_AMT: null,
  };
  Object.assign(header, { ACK_DATE: null });

  const ledger = buildSaleLedger({
    key,
    acCode: input.acCode,
    salesAc,
    taxAc,
    roundAc,
    controlAc,
    rateUnfix: input.rateUnfix,
    vchType: bookPolicy.vchType,
    totals,
    incomeLegs,
    payments: {
      cashAc,
      cashAmt: input.cashAmt,
      bankAc: input.bankAc,
      bankAmt: round2s(num(input.cardAmt) + num(input.upiAmt) + num(input.chequeAmt)),
      oldGoldAc: input.oldGoldAc,
      oldGoldAmt: round2s(oldGoldAmount + oldSilverAmount),
    },
  });
  if (hmAmt > 0) {
    const hb = { ...key, VCH_TYPE: bookPolicy.vchType };
    ledger.push({
      ...hb,
      AC_CODE: input.hmChargeAc ?? 'HMCHRG',
      LD_CODE: input.acCode,
      DR_AMT: 0,
      CR_AMT: hmAmt,
      SIGN: 'C',
    }); // Cr hallmark income
    if (hmTax > 0)
      ledger.push({
        ...hb,
        AC_CODE: taxAc,
        LD_CODE: input.acCode,
        DR_AMT: 0,
        CR_AMT: hmTax,
        SIGN: 'C',
      }); // Cr GST on hallmark
    ledger.push({
      ...hb,
      AC_CODE: input.acCode,
      LD_CODE: input.hmChargeAc ?? 'HMCHRG',
      DR_AMT: round2s(hmAmt + hmTax),
      CR_AMT: 0,
      SIGN: 'D',
    }); // billed to customer
  }
  if (tcs > 0) {
    // TCS collected on the bill: Cr TCS-payable, billed to the customer
    const tb = { ...key, VCH_TYPE: bookPolicy.vchType };
    ledger.push({
      ...tb,
      AC_CODE: input.tcsAc ?? 'TCS',
      LD_CODE: input.acCode,
      DR_AMT: 0,
      CR_AMT: tcs,
      SIGN: 'C',
    });
    ledger.push({
      ...tb,
      AC_CODE: input.acCode,
      LD_CODE: input.tcsAc ?? 'TCS',
      DR_AMT: tcs,
      CR_AMT: 0,
      SIGN: 'D',
    });
  }
  if (kasar > 0) {
    // Kasar write-off: Dr KASAR, reduces what the customer owes
    const kb = { ...key, VCH_TYPE: bookPolicy.vchType };
    ledger.push({
      ...kb,
      AC_CODE: kasarAc,
      LD_CODE: input.acCode,
      DR_AMT: kasar,
      CR_AMT: 0,
      SIGN: 'D',
    });
    ledger.push({
      ...kb,
      AC_CODE: input.acCode,
      LD_CODE: kasarAc,
      DR_AMT: 0,
      CR_AMT: kasar,
      SIGN: 'C',
    });
  }
  ledger.push(
    ...buildSaleFineLedger({
      key,
      acCode: input.acCode,
      vchType: bookPolicy.vchType,
      rateUnfix: input.rateUnfix,
      lines: computed.map((c) => ({
        metal: metalByItem[String(c.in.itCode).trim()] ?? 'G',
        saleAc: saleAcByItem[String(c.in.itCode).trim()] ?? salesAc,
        fine: c.calc.fine,
      })),
    }),
  );
  assertBalanced(ledger);

  const cashAmt = round2s(num(input.cashAmt));
  const cardAmt = round2s(num(input.cardAmt));
  const upiAmt = round2s(num(input.upiAmt));
  const chequeAmt = round2s(num(input.chequeAmt));
  const oldGoldAmt = round2s(oldGoldAmount + oldSilverAmount);
  const paidNow = round2s(cashAmt + cardAmt + upiAmt + chequeAmt + oldGoldAmt);
  // Sales-Order advance consumed into this bill (P0-3): the order's advance (already Cr customer)
  // settles part of this receivable → reduces BILL_OS. Clamped to the available advance + bill balance.
  let orderAdjust = 0;
  if (input.orderRef?.ordNo != null) {
    const av = await orderAdvanceAvailableTx(
      tx,
      input.scope,
      input.orderRef.ordNo,
      input.orderRef.ordBook ?? 'SOR',
    );
    const want =
      input.orderRef.adjustAmt != null ? round2s(Number(input.orderRef.adjustAmt)) : av.available;
    orderAdjust = Math.max(
      0,
      Math.min(want, av.available, round2s(grandWithTcs - paidNow - kasar)),
    );
  }
  const billOS = round2s(grandWithTcs - paidNow - kasar - orderAdjust);
  // TR_SALE.cs: MsDefaulterAc = 'Y' AND outstanding > 0 -> credit to a flagged party is blocked.
  // The flag is read from the persisted account (AC_MAST.DEFAULTER_AC), never from the request.
  if (round2s(billOS) > 0) {
    const flagged: Array<{ d: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "DEFAULTER_AC" AS d FROM "AC_MAST"
        WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "AC_CODE"::text=$3::text LIMIT 1`,
      input.scope.coCode,
      input.scope.lcCode,
      input.acCode,
    );
    if (
      String(flagged[0]?.d ?? '')
        .trim()
        .toUpperCase() === 'Y'
    ) {
      throw new SaleValidationError(DESKTOP_MESSAGES.PARTY_IN_DEFAULTER_LIST);
    }
  }

  Object.assign(header, {
    CASH_AMT: cashAmt,
    CARD_AMT: cardAmt,
    UPI_AMT: upiAmt,
    CHQ_AMT: chequeAmt,
    ADV_AMT: orderAdjust,
    OLD_GL_AMT: oldGoldAmount,
    OLD_SL_AMT: oldSilverAmount,
    BILL_OS: billOS,
    HM_AMT: hmAmt,
    HM_TAX_AMT: hmTax,
    TCS_AMT: tcs,
    TCS_PRC: tcsPct,
    KASAR_AMT: kasar,
    TOT_AMT: grandWithTcs,
    CR_DAYS: input.crDays ?? null,
    EMP_CODE: input.empCode ?? null,
  });

  // Old-gold received from the customer: detail (SL_PR_DETL) + stock in-movement (MAIN_STOCK '+').
  const oldGoldDetl = oldMetalRows.map((g, i) => {
    const fine =
      g.netWt != null && g.touch != null ? round2s((num(g.netWt) * num(g.touch)) / 100) : 0;
    return {
      ...key,
      SR_NO: i + 1,
      VCH_DATE: header.VCH_DATE,
      VCH_TIME: sharedVoucherTime,
      HD_VCH_NO: ctx.hdVchNo,
      VCH_TYPE: bookPolicy.vchType,
      INOUT_TYPE: bookPolicy.inout,
      ENTRY_TYPE: 'A',
      BOOK_NAME: bookPolicy.bookName,
      AC_CODE: input.acCode,
      IT_CODE: g.itCode ?? ((g.metal ?? 'G') === 'S' ? 'OS' : 'OG'),
      IT_TYPE: g.metal ?? 'G',
      IT_DESC: g.description ?? 'OLD GOLD',
      ITM_PCS: num(g.pcs),
      ITM_GWT: num(g.grossWt),
      ITM_OTH_WT: num(g.otherWt),
      ITM_NWT: num(g.netWt),
      ITM_TOUCH: num(g.touch),
      ITM_FINE: fine,
      CON_PRC: num(g.conversionPct),
      CON_WT: num(g.conversionWt),
      // TR_SALE.cs values the exchange line server-side rather than trusting the posted amount:
      // rate type 'N' applies the rate to net weight, otherwise to fine (or to the conversion weight
      // when one is present), and `Math.Round(basis * rate, 0)` makes it whole rupees. When the
      // operator supplies an amount and no rate, the desktop back-calculates the rate instead.
      ...(() => {
        const valued = resolveOldGoldValuation({
          netWt: num(g.netWt),
          fineWt: fine,
          conversionWt: num(g.conversionWt),
          rate: num(g.rate),
          amount: num(g.amount),
          rateType: g.rateType,
        });
        return { ITM_RATE: valued.rate, NET_AMT: valued.amount };
      })(),
      ITM_RATE_TYPE: g.rateType ?? '',
      MAIN_USER: ctx.mainUser,
      HM_ID_WT: 0,
      HM_ID2_WT: 0,
      HM_ID3_WT: 0,
      HM_ID4_WT: 0,
      ITM_OTH: 0,
      HM_ID: null,
      HM_ID2: null,
      HM_ID3: null,
      HM_ID4: null,
      NEW_VCH_NO: null,
      OLD_VCH_NO: null,
    };
  });

  const oldGoldStock = oldMetalRows.map((g, i) => ({
    ...key,
    SR_NO: i + 1,
    VCH_DATE: header.VCH_DATE,
    VCH_TYPE: 'MIXSL',
    BOOK_NAME: 'OLD GOLD',
    AC_CODE: input.acCode,
    IT_CODE: g.itCode ?? 'OG',
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    // Same rule as the sale line above - a movement count, not a weight. Old-metal inward rows on the sale
    // books are inside the 267 measured and are also all 1.
    ITM_QTY: 1,
    ITM_PCS: num(g.pcs) || 1,
  }));

  // Satellite tables the desktop TR_SALE also writes: tax register + bill outstanding.
  const vchDate = header.VCH_DATE;
  // TAX_DATA: desktop writes SEPARATE CGST+SGST rows (intra) or one IGST row (inter) — Ac_Tax.Sales_GST.
  const taxBase = {
    ...key,
    TRAN_TYPE: 'S',
    BOOK_NAME: bookPolicy.bookName,
    VCH_DATE: vchDate,
    AC_CODE: input.acCode,
    PARTY_NAME: input.acName ?? null,
    NET_AMT: totals.taxable,
    DISC_AMT: totals.discount,
    TOT_AMT: totals.total,
    TAX_SIGN: '+',
    TAX_CODE: taxPolicy.taxCode,
  };
  const taxRows = interState
    ? [
        {
          ...taxBase,
          SR_NO: 1,
          TAX_TYPE: taxPolicy.taxGroup,
          TAX_PRC: input.taxRatePct,
          TAX_AMT: totals.igst,
        },
      ]
    : [
        {
          ...taxBase,
          SR_NO: 1,
          TAX_TYPE: taxPolicy.taxGroup,
          TAX_PRC: round2s(input.taxRatePct / 2),
          TAX_AMT: totals.cgst,
        },
        {
          ...taxBase,
          SR_NO: 2,
          TAX_TYPE: taxPolicy.taxGroup,
          TAX_PRC: round2s(input.taxRatePct / 2),
          TAX_AMT: totals.sgst,
        },
      ];
  if (hmAmt > 0 && hmTax > 0) {
    const hmBase = { ...taxBase, NET_AMT: hmAmt };
    if (interState)
      taxRows.push({
        ...hmBase,
        SR_NO: taxRows.length + 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: hmTaxPct,
        TAX_AMT: hmIgst,
      });
    else {
      taxRows.push({
        ...hmBase,
        SR_NO: taxRows.length + 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: round2s(hmTaxPct / 2),
        TAX_AMT: hmCgst,
      });
      taxRows.push({
        ...hmBase,
        SR_NO: taxRows.length + 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: round2s(hmTaxPct / 2),
        TAX_AMT: hmSgst,
      });
    }
  }
  const osRow = {
    ...key,
    VCH_TYPE: bookPolicy.vchType,
    INOUT_TYPE: bookPolicy.inout,
    ENTRY_TYPE: 'O',
    BOOK_NAME: bookPolicy.bookName,
    SR_NO: 1,
    VCH_DATE: vchDate,
    VCH_TIME: sharedVoucherTime,
    HD_VCH_NO: ctx.hdVchNo,
    AC_CODE: input.acCode,
    BILL_AMT: grandWithTcs,
    OLD_ADJ_AMT: 0,
    REC_AMT: round2s(grandWithTcs - (billOS + kasar)),
    KASAR_AMT: kasar,
    BILL_GOLD: 0,
    OLD_ADJ_GOLD: 0,
    REC_GOLD: 0,
    KASAR_GOLD: 0,
    BILL_SILVER: 0,
    OLD_ADJ_SILVER: 0,
    REC_SILVER: 0,
    KASAR_SILVER: 0,
    BILL_LC: input.scope.lcCode,
    BILL_YRCD: input.scope.coYear,
    BILL_DBCD: input.scope.coBook,
    BILL_NO: key.VCH_NO,
    BILL_HD_VCH_NO: ctx.hdVchNo,
    BILL_SRNO: 1,
    MAIN_USER: ctx.mainUser,
    DATA_TRFR: 'N',
    DATA_TYPE: 'A',
    // Written by other desktop forms, not TR_SALE.
    LD_CODE: null,
    NEW_VCH_NO: null,
    OLD_VCH_NO: null,
  };

  Object.assign(osRow, { LD_CODE: null });

  // TR_SALE.cs:14209,15151: hidden book numbering is a separate TEMP_BOOK_DATA sequence.
  await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_BOOK: input.scope.coBook,
    VCH_NO: ctx.hdVchNo,
    BOOK_NAME: configuredBookName,
  });

  // TR_SALE_RTN.cs:13497-13545 (same block in TR_SALE): an edit records one USER_DATA row per
  // changed header column. Written before the rewrite posts so the trail exists even if a later
  // statement in this transaction fails and rolls the voucher back to its prior state.
  if (ctx.isEdit && ctx.persistedHeader) {
    await recordFieldChangesTx(tx, tenantId, {
      key: {
        CO_CODE: key.CO_CODE,
        LC_CODE: key.LC_CODE,
        CO_YEAR: key.CO_YEAR,
        CO_BOOK: key.CO_BOOK,
        VCH_NO: key.VCH_NO,
      },
      acCode: input.acCode,
      vchDate: vchDate,
      bookName: bookPolicy.bookName,
      originalUser: ctx.mainUser,
      editingUser: ctx.editingUser ?? input.mainUser ?? null,
      before: ctx.persistedHeader,
      after: header,
    });
  }

  // The Rojmel — the day book the desktop binds to F11. A second projection of this sale showing metal
  // movement beside money, which AC_DATA cannot carry. Verified against the real desktop database:
  // 3179 rows, and a sale's three ledger legs become one metal row per detail line (the revenue leg
  // split, each carrying that line's pieces and weight) plus a party row and a tax row.
  // See project-memory/parity/ROJMEL-MODEL-VERIFIED.md and modules/shared/rojmel.ts.
  // Slot 4 is the book's advance account; resolved only when an advance actually applies, so a plain
  // sale does not pay for a lookup it will not use.
  if (orderAdjust !== 0) {
    advanceAc = await resolveBookAccountTx(tx, input.scope, bookPolicy, 4);
  }
  // Built once and shared: the SL_DETL write set and the Rojmel projection must agree, and computing
  // them twice is how they drift.
  const detailRows = computed.map((c, idx) => buildSaleDetailRow(c, idx));
  const rojmelRows = buildSaleRojmel(
    {
      scope: { coCode: input.scope.coCode, lcCode: input.scope.lcCode, coYear: key.CO_YEAR },
      key,
      coBook: key.CO_BOOK,
      vchNo: key.VCH_NO,
      vchDate: voucherDate,
      vchType: bookPolicy.vchType,
      bookName: bookPolicy.bookName,
      partyName: input.acName ?? '',
      partyCode: input.acCode,
    },
    computed.map((c, idx) => {
      const item = String(c.in.itCode ?? '').trim();
      return {
        lineNo: idx + 1,
        revenueAc: saleAcByItem[item] ?? salesAc,
        amount: c.calc.net,
        metal: rojmelMetalFor(metalByItem[item] ?? c.in.metal),
        pcs: num(c.in.pcs),
        grossWt: num(c.in.grossWt),
        netWt: num(c.in.netWt),
        rate: num(c.in.rate),
        // Ac_Rojmel.Sales_Rojmel copies these from SL_DETL onto the day-book row. All 245 real sale
        // metal rows carry IT_DESC / IT_CODE / NET_AMT and 237 of 245 carry LBR_AMT, so leaving them
        // blank was a measurable gap. Reading them off the persisted detail row keeps the two
        // projections from drifting apart.
        itemCode: item,
        itemName: nameByItem[item] ?? '',
        labourRate: num((detailRows[idx] as any)?.LBR_RATE),
        labourAmount: num((detailRows[idx] as any)?.LBR_AMT),
        otherAmount: num((detailRows[idx] as any)?.OTH_AMT),
        netAmount: num((detailRows[idx] as any)?.NET_AMT) || c.calc.net,
      };
    }),
    // The party row exists ONLY when the bill is outstanding, and its side follows the sign. Measured
    // on the real database: of 47 sales with BILL_OS = 0, ZERO carry a party row; of 42 with
    // BILL_OS <> 0, all 42 do. A fully settled bill leaves no receivable for a day book to show.
    {
      taxAc,
      taxAmount: totals.tax,
      partyAmount: billOS,
      // Ac_Rojmel.Sales_Rojmel guards each of these with `AND <column> <> 0`, so a sale settled wholly in
      // cash emits none of them. Identified by matching real amounts against SL_DATA across the sale
      // books: cheque 17/17 = CHQ_AMT, kasar 100/100 = KASAR_AMT, advance 23/23 = ADV_AMT on the book's
      // advance slot. Old metal comes from SL_PR_DETL and keeps its weight even though IT_TYPE is 'A',
      // so the day book shows metal taken in exchange without counting it as a metal sale.
      settlements: [
        { kind: 'cheque' as const, account: text(input.bankAc) || 'BANK', amount: chequeAmt },
        { kind: 'kasar' as const, account: kasarAc, amount: kasar },
        { kind: 'advance' as const, account: advanceAc, amount: orderAdjust },
        // Slot 5 is the book's round-off/discount account. SOURCE-ONLY: this company's data has ROF_AMT
        // non-zero on zero of 190 sales, so there is no real row to check the shape against.
        { kind: 'roundOff' as const, account: roundAc, amount: totals.roundOff },
        ...oldGoldDetl.map((g, i) => ({
          kind: 'oldMetal' as const,
          account: String((g as any).AC_CODE ?? input.acCode),
          amount: num((g as any).NET_AMT),
          lineNo: i + 1,
          pcs: num((g as any).ITM_PCS),
          grossWt: num((g as any).ITM_GWT),
          netWt: num((g as any).ITM_NWT),
          touch: num((g as any).ITM_TOUCH),
          fine: num((g as any).ITM_FINE),
          description: 'OLD GOLD',
          itemCode: String((g as any).IT_CODE ?? ''),
        })),
      ],
    },
    bookPolicy.inout !== 'I', // outward for a sale; an inward book mirrors the direction
  );

  await postVoucherTx(tx, tenantId, {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: bookPolicy.bookName,
    writes: [
      { table: 'SL_DATA', rows: [header] },
      { table: 'SL_DETL', rows: detailRows },
      ...(idtl.length ? [{ table: 'SL_IDTL', rows: idtl }] : []),
      ...(mainStock.length ? [{ table: 'MAIN_STOCK', rows: mainStock }] : []),
      ...(oldGoldDetl.length ? [{ table: 'SL_PR_DETL', rows: oldGoldDetl }] : []),
      ...(oldGoldStock.length ? [{ table: 'MAIN_STOCK', rows: oldGoldStock }] : []),
      { table: 'TAX_DATA', rows: taxRows },
      { table: 'BILL_OS_DATA', rows: [osRow] },
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
    ],
  });

  await consumeSaleReferencesTx(tx, input.scope, key.VCH_NO);

  // Consume the order advance into this sale (P0-3): record SL_ORD_ADJ linking order → this bill.
  if (orderAdjust > 0 && input.orderRef?.ordNo != null) {
    await adjustOrderIntoSaleTx(tx, tenantId, input.scope, {
      saleVchNo: formatVoucherNo(vchNo),
      ordNo: input.orderRef.ordNo,
      custAc: input.acCode,
      custName: input.acName,
      adjustAmt: orderAdjust,
      vchDate,
    });
  }

  if (behavior.touchAutoSave) {
    // TR_BUL_SALE.cs:7684-7735: save party/item touch and labour defaults atomically.
    for (const c of computed) {
      await tx.$executeRawUnsafe(
        `INSERT INTO "TOUCH_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_IT_CODE","AC_TOUCH","AC_WEST","AC_LBR_RATE","AC_LBR_TYPE","MAIN_USER")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10)
         ON CONFLICT (tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_IT_CODE") DO UPDATE SET
          "AC_TOUCH"=excluded."AC_TOUCH","AC_WEST"=excluded."AC_WEST",
          "AC_LBR_RATE"=excluded."AC_LBR_RATE","AC_LBR_TYPE"=excluded."AC_LBR_TYPE","MAIN_USER"=excluded."MAIN_USER"`,
        tenantId,
        key.CO_CODE,
        key.LC_CODE,
        input.acCode,
        String(c.in.itCode).slice(0, 5),
        num(c.in.touch),
        num(c.in.westPct),
        num(c.in.labourRate),
        desktopLabourTypeFor(c.in.labourType, behavior.labourType) || null,
        ctx.mainUser || null,
      );
    }
  }

  // Bill profit (TR_SALE.cs:17009-17045 per line, :19396-19399 total). Costing needs today's ex-tax fine
  // rate and each item's average touch, both read server-side — a client-supplied cost would let the margin
  // be dictated by the request.
  let profit: SaleResult['billProfit'];
  if (await billProfitEnabledTx(tx, input.scope)) {
    const saleRate = await todaySaleRateTx(tx, input.scope, vchDate);
    const touches = await averageTouchByItemTx(
      tx,
      input.scope,
      computed.map((c) => String(c.in.itCode ?? '')),
    );
    // TOT_AMT / NET_AMT must be the COMPUTED line totals, not fields on the request: the input carries
    // weights and rates, and the persisted total is derived by `lineTotalDesktop`. Reading them off the
    // input yielded 0 and made every profit equal to minus the cost.
    const profitLines = computed.map((c) => {
      const lineTotal = lineTotalDesktop({
        itemAmount: c.calc.metal,
        labourAmount: c.calc.labour,
        otherAmount: num(c.in.otherAmount),
      });
      return {
        tagNo: c.in.tagNo,
        itmMrp: num(c.in.mrp),
        tagCost: num(c.in.tagCost),
        krFine: num(c.in.karigarFine),
        netWt: num(c.in.netWt),
        // Both persisted columns hold the same tax-exclusive whole-rupee figure.
        totAmt: lineTotal,
        netAmt: lineTotal,
        avgTouch: touches[String(c.in.itCode ?? '')] ?? 0,
      };
    });
    const computedProfit = billProfit(profitLines, saleRate, { billProfitEnabled: true });
    profit = {
      total: computedProfit.total,
      lines: computedProfit.lines.map((x: { basis: string; cost: number; profit: number }) => ({
        basis: x.basis,
        cost: x.cost,
        profit: x.profit,
      })),
    };
  }

  return { vchNo, totals, ...(profit ? { billProfit: profit } : {}) };
}

/** Create a sale with independent main and hidden desktop voucher numbering. */
export async function createSale(
  prisma: any,
  input: SaleInput,
  lines: SaleLineInput[],
): Promise<SaleResult> {
  completeSaleScope(input.scope);
  const scope = input.scope;
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    // TR_SALE.cs:15139 allocates the main number from SL_DATA with year in scope.
    const vchNo = await nextVoucherNoTx(tx, scope);
    // TR_SALE.cs:14209,15151 allocates a five-digit hidden number from TEMP_BOOK_DATA without year.
    const hdVchNo = await nextHiddenVoucherNoTx(tx, scope);
    return writeSaleTx(tx, input, lines, {
      vchNo,
      hdVchNo,
      mainUser: String(input.mainUser ?? '').trim(),
      persistedClock: undefined,
      isEdit: false,
    });
  });
}

export interface DeleteSaleInput {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
}

const SALE_WRITE_TABLES = [
  'SL_DATA',
  'SL_DETL',
  'SL_IDTL',
  'SL_PR_DETL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'POINT_DATA',
  'UPI_DATA',
  'CARD_DATA',
  'DM_DATA',
  'CRNT_DATA',
  'ROJ_MEL_DATA',
  'LOT_DETL',
  'REMARK_DATA',
  'AD_ADJ',
] as const;

type CompleteSaleScope = VoucherScope & { coYear: string; coBook: string };
type LegacyRestore = Record<string, unknown> & {
  CO_CODE: string;
  LC_CODE: string;
  TAG_NO: string;
};

const text = (value: unknown): string => String(value ?? '').trim();
const saleParams = (scope: CompleteSaleScope, voucherNo: string): unknown[] => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];

async function persistedSaleHeaderTx(
  tx: any,
  scope: CompleteSaleScope,
  voucherNo: string,
  extraColumns: readonly string[] = [],
): Promise<Record<string, unknown>> {
  try {
    return await persistedVoucherHeaderTx(tx, {
      table: 'SL_DATA',
      scope,
      voucherNo,
      extraColumns,
    });
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new SaleValidationError(`sale voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new SaleValidationError(`sale voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
}

/** Restore every desktop source flag before deleting a sale so an edit can consume it again. */
async function releaseSaleReferencesTx(
  tx: any,
  scope: CompleteSaleScope,
  voucherNo: string,
): Promise<LegacyRestore[]> {
  const params = saleParams(scope, voucherNo);
  const tags: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT"
       FROM "SL_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND NULLIF(btrim(coalesce("TAG_NO"::text,'')),'') IS NOT NULL
        AND "TAG_NO"::text <> 'N' FOR UPDATE`,
    ...params,
  );
  const legacyRestores: LegacyRestore[] = [];
  for (const tag of tags) {
    const inBar: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"::text=$4
          AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
          AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'')`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      text(tag.TAG_NO),
      tag.VCH_SRNO ?? 0,
      tag.IT_CODE ?? '',
    );
    if (Number(inBar[0]?.n ?? 0) === 0) {
      legacyRestores.push({
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
        TAG_NO: text(tag.TAG_NO),
        VCH_SRNO: Number(tag.VCH_SRNO ?? 0),
        IT_CODE: text(tag.IT_CODE),
        ITM_PCS: tag.ITM_PCS,
        ITM_GWT: tag.ITM_GWT,
        ITM_NWT: tag.ITM_NWT,
        STK_TYPE: 'R',
      });
    }
  }

  await tx.$executeRawUnsafe(
    `DELETE FROM "SL_ORD_ADJ" a WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
      AND a."CO_YEAR"=$4 AND a."NEW_VCH_NO"::text=$5
      AND (a."OLD_VCH_NO"::text=$6 OR (
        nullif(btrim(coalesce(a."OLD_VCH_NO"::text,'')),'') IS NULL
        AND (SELECT count(*) FROM "SL_DATA" s
              WHERE s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
                AND s."CO_YEAR"=$4 AND s."VCH_NO"::text=$5)=1
      ))`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    voucherNo,
    scope.coBook,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "SL_ORD_DETL" o SET "TAG_SALE"='N' FROM "SL_DETL" s
      WHERE o.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND o."CO_CODE"=s."CO_CODE" AND o."VCH_NO"=s."ORD_NO"
        AND o."CO_YEAR"=s."ORD_YRCD" AND o."CO_BOOK"=s."ORD_DBCD"
        AND coalesce(o."OLD_SRNO",0)=coalesce(s."ORD_SRNO",0)`,
    ...params,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "APR_DETL" a SET "ISU_REC"='N' FROM "SL_DETL" s
      WHERE a.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND a."CO_CODE"=s."CO_CODE" AND a."LC_CODE"=s."LC_CODE"
        AND a."CO_YEAR"=s."ISU_YRCD" AND a."CO_BOOK"=s."ISU_DBCD"
        AND a."VCH_NO"=s."ISU_NO" AND coalesce(a."SR_NO",0)=coalesce(s."ISU_SRNO",0)`,
    ...params,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "APR_ISU"='Y',"APP_TRFR"='N' FROM "SL_DETL" s
      WHERE b.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND b."CO_CODE"=s."CO_CODE" AND b."LC_CODE"=s."LC_CODE"
        AND b."TAG_NO"=s."TAG_NO" AND coalesce(b."VCH_SRNO",0)=coalesce(s."VCH_SRNO",0)`,
    ...params,
  );
  return legacyRestores;
}

async function consumeSaleReferencesTx(
  tx: any,
  scope: CompleteSaleScope,
  voucherNo: string,
): Promise<void> {
  const params = saleParams(scope, voucherNo);
  await tx.$executeRawUnsafe(
    `UPDATE "SL_ORD_DETL" o SET "TAG_SALE"='Y' FROM "SL_DETL" s
      WHERE o.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND o."CO_CODE"=s."CO_CODE" AND o."VCH_NO"=s."ORD_NO"
        AND o."CO_YEAR"=s."ORD_YRCD" AND o."CO_BOOK"=s."ORD_DBCD"
        AND coalesce(o."OLD_SRNO",0)=coalesce(s."ORD_SRNO",0)`,
    ...params,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "APR_DETL" a SET "ISU_REC"='Y' FROM "SL_DETL" s
      WHERE a.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND a."CO_CODE"=s."CO_CODE" AND a."LC_CODE"=s."LC_CODE"
        AND a."CO_YEAR"=s."ISU_YRCD" AND a."CO_BOOK"=s."ISU_DBCD"
        AND a."VCH_NO"=s."ISU_NO" AND coalesce(a."SR_NO",0)=coalesce(s."ISU_SRNO",0)`,
    ...params,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "BAR_DETL" b SET "APR_ISU"='N',"APP_TRFR"='Y' FROM "SL_DETL" s
      WHERE b.tenant_id=$1 AND s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
        AND b."CO_CODE"=s."CO_CODE" AND b."LC_CODE"=s."LC_CODE"
        AND b."TAG_NO"=s."TAG_NO" AND coalesce(b."VCH_SRNO",0)=coalesce(s."VCH_SRNO",0)`,
    ...params,
  );
}

/** Open a persisted sale by voucher number using server-derived tenant scope only. */
export async function getSale(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeSaleScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const params = saleParams(scope, voucherNo);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","BILL_NO","HD_VCH_NO","MAIN_USER",
              "AC_CODE","AC_NAME","NET_AMT","DISC_AMT","TAX_CODE","TAX_PRC","TAX_AMT",
              "AC_GST_TYPE","CGST_TAX","SGST_TAX","IGST_TAX","ROF_AMT","TOT_AMT",
              "RATE_UNFIX","CASH_AMT","CARD_AMT","UPI_AMT","CHQ_AMT","OLD_GL_AMT",
              "BILL_OS","HM_AMT","HM_TAX_AMT","TCS_PRC","TCS_AMT","KASAR_AMT",
              "CR_DAYS","EMP_CODE","VCH_DESC","DISC_PRC","TCS_CODE","TDS_CODE","TDS_PRC","TDS_AMT",
              "ADD1","ADD2","ADD3","CITY","MOBILE","BANK_AC","CARD_AC","CHQ_NO","BANK_NAME",
              "CARD_COM_AMT","CASH_PAID","CRNT_ADJ_AMT","SCHM_AC","SCHM_AMT","POINT_VAL",
              "ISU_NO","ISU_YRCD","ISU_DBCD","ORNA_ISU"
         FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...params,
    );
    if (headers.length !== 1) {
      throw new SaleValidationError(
        headers.length
          ? `sale voucher is ambiguous: ${voucherNo}`
          : `sale voucher not found: ${voucherNo}`,
      );
    }
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","IT_TYPE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT",
              "ITM_NWT","ITM_TOUCH","ITM_GHT_WT","ITM_WEST_PRC","ITM_FINE","ITM_RATE",
              "ITM_AMT","LBR_TYPE","LBR_PRC","LBR_RATE","LBR_AMT","OTH_AMT","NET_AMT",
              "DESIGN_NO","ITM_SIZE","ITM_OTH_WT","TBL_CODE","ITM_MRP","HM_ID",
              "ORD_NO","ORD_YRCD","ORD_DBCD","ORD_SRNO","ISU_NO","ISU_YRCD","ISU_DBCD","ISU_SRNO",
              "BAG_WT","TAG_GWT","TAG_NWT","ITM_GHT_PRC","ITM_STYLE","ITM_LOT","ITM_REMARK",
              "DISC_PRC","DISC_AMT","GHT_AMT","RATE_WITH","RATE_TYPE","TAG_COST","KR_NET_WT",
              "KR_TOUCH","KR_WEST_PRC","KR_FINE","KR_NAME","EMP_CODE","PR_CODE","ORD_TAG_STK_ADD",
              "DESIGN_IMG_ID","HM_ID2","HM_ID3","HM_ID4","HM_ID_WT","HM_ID2_WT","HM_ID3_WT","HM_ID4_WT"
         FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params,
    );
    const oldGold: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","IT_TYPE","IT_DESC","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH",
              "ITM_FINE","CON_PRC","CON_WT","ITM_RATE","ITM_RATE_TYPE","NET_AMT"
         FROM "SL_PR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params,
    );
    const adjustments: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "ORD_NO","PAID_AMT" FROM "SL_ORD_ADJ"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "NEW_VCH_NO"::text=$6 AND "OLD_VCH_NO"::text=$5 ORDER BY "SR_NO" LIMIT 1`,
      ...params,
    );
    const h = headers[0]!;
    // Must agree with `desktopLabourTypeFor`. Reading 'N' as 'fixed' would corrupt the round trip now that
    // per-gram is correctly written as 'N'; 'G' and 'K' have no legacy mode and yield undefined rather than a
    // wrong one. `labourBasis` below carries the raw code so nothing is lost.
    const labourType = (value: unknown): LabourType | undefined =>
      legacyLabourModeFor(value) as LabourType | undefined;
    return {
      voucherNo: text(h.VCH_NO),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      billNo: text(h.BILL_NO),
      acCode: text(h.AC_CODE),
      acName: text(h.AC_NAME),
      taxCode: text(h.TAX_CODE),
      taxRatePct: num(h.TAX_PRC),
      interState: num(h.IGST_TAX) !== 0 || text(h.AC_GST_TYPE).toUpperCase() !== 'L',
      discountAmount: num(h.DISC_AMT),
      discountPct: num(h.DISC_PRC),
      rateUnfix: text(h.RATE_UNFIX).toUpperCase() === 'Y',
      cashAmt: num(h.CASH_AMT),
      cardAmt: num(h.CARD_AMT),
      upiAmt: num(h.UPI_AMT),
      chequeAmt: num(h.CHQ_AMT),
      hallmarkAmount: num(h.HM_AMT),
      hallmarkTaxAmount: num(h.HM_TAX_AMT),
      tcsPct: num(h.TCS_PRC),
      tcsAmount: num(h.TCS_AMT),
      tcsCode: text(h.TCS_CODE),
      tdsCode: text(h.TDS_CODE),
      tdsPct: num(h.TDS_PRC),
      tdsAmount: num(h.TDS_AMT),
      kasarAmount: num(h.KASAR_AMT),
      oldGoldAmount: num(h.OLD_GL_AMT),
      billOutstanding: num(h.BILL_OS),
      crDays: num(h.CR_DAYS),
      empCode: text(h.EMP_CODE),
      description: text(h.VCH_DESC),
      address1: text(h.ADD1),
      address2: text(h.ADD2),
      address3: text(h.ADD3),
      city: text(h.CITY),
      mobile: text(h.MOBILE),
      bankAc: text(h.BANK_AC),
      cardAc: text(h.CARD_AC),
      chequeNo: text(h.CHQ_NO),
      bankName: text(h.BANK_NAME),
      cardCommissionAmount: num(h.CARD_COM_AMT),
      cashPaid: num(h.CASH_PAID),
      currentAdjustmentAmount: num(h.CRNT_ADJ_AMT),
      schemeAc: text(h.SCHM_AC),
      schemeAmount: num(h.SCHM_AMT),
      pointValue: num(h.POINT_VAL),
      issueNo: text(h.ISU_NO),
      issueYear: text(h.ISU_YRCD),
      issueBook: text(h.ISU_DBCD),
      ornamentIssued: text(h.ORNA_ISU) !== 'N',
      orderRef: adjustments[0]
        ? { ordNo: text(adjustments[0].ORD_NO), adjustAmt: num(adjustments[0].PAID_AMT) }
        : null,
      totals: {
        net: num(h.NET_AMT),
        discount: num(h.DISC_AMT),
        taxable: round2s(num(h.NET_AMT) - num(h.DISC_AMT)),
        tax: num(h.TAX_AMT),
        cgst: num(h.CGST_TAX),
        sgst: num(h.SGST_TAX),
        igst: num(h.IGST_TAX),
        roundOff: num(h.ROF_AMT),
        total: num(h.TOT_AMT),
      },
      lines: details.map((row) => ({
        srNo: num(row.SR_NO),
        itCode: text(row.IT_CODE),
        metal: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
        tagNo: text(row.TAG_NO) === 'N' ? '' : text(row.TAG_NO),
        vchSrno: num(row.VCH_SRNO),
        pcs: num(row.ITM_PCS),
        grossWt: num(row.ITM_GWT),
        netWt: num(row.ITM_NWT),
        touch: num(row.ITM_TOUCH),
        ghtWt: num(row.ITM_GHT_WT),
        westPct: num(row.ITM_WEST_PRC),
        fineWt: num(row.ITM_FINE),
        rate: num(row.ITM_RATE),
        metalAmount: num(row.ITM_AMT),
        labourType: labourType(row.LBR_TYPE),
        labourPct: num(row.LBR_PRC),
        labourRate: num(row.LBR_RATE),
        labourFixed: text(row.LBR_TYPE) === 'N' ? num(row.LBR_AMT) : undefined,
        otherAmount: num(row.OTH_AMT),
        netAmount: num(row.NET_AMT),
        designNo: text(row.DESIGN_NO),
        itmSize: text(row.ITM_SIZE),
        lessWt: num(row.ITM_OTH_WT),
        tblCode: text(row.TBL_CODE),
        mrp: num(row.ITM_MRP),
        huid: text(row.HM_ID),
        ordNo: text(row.ORD_NO),
        ordYrcd: text(row.ORD_YRCD),
        ordDbcd: text(row.ORD_DBCD),
        ordSrno: num(row.ORD_SRNO),
        isuNo: text(row.ISU_NO),
        isuYrcd: text(row.ISU_YRCD),
        isuDbcd: text(row.ISU_DBCD),
        isuSrno: num(row.ISU_SRNO),
        bagWt: num(row.BAG_WT),
        tagGrossWt: num(row.TAG_GWT),
        tagNetWt: num(row.TAG_NWT),
        ghtPct: num(row.ITM_GHT_PRC),
        style: text(row.ITM_STYLE),
        itemLot: text(row.ITM_LOT),
        remark: text(row.ITM_REMARK),
        discountPct: num(row.DISC_PRC),
        discountAmount: num(row.DISC_AMT),
        ghatAmount: num(row.GHT_AMT),
        rateWith: text(row.RATE_WITH),
        rateType: text(row.RATE_TYPE),
        tagCost: num(row.TAG_COST),
        karigarNetWt: num(row.KR_NET_WT),
        karigarTouch: num(row.KR_TOUCH),
        karigarWestPct: num(row.KR_WEST_PRC),
        karigarFine: num(row.KR_FINE),
        karigarName: text(row.KR_NAME),
        employeeCode: text(row.EMP_CODE),
        prCode: text(row.PR_CODE),
        orderTagStockAdd: text(row.ORD_TAG_STK_ADD),
        designImageId: text(row.DESIGN_IMG_ID),
        hallmarkId2: text(row.HM_ID2),
        hallmarkId3: text(row.HM_ID3),
        hallmarkId4: text(row.HM_ID4),
        hallmarkIdWt: num(row.HM_ID_WT),
        hallmarkId2Wt: num(row.HM_ID2_WT),
        hallmarkId3Wt: num(row.HM_ID3_WT),
        hallmarkId4Wt: num(row.HM_ID4_WT),
      })),
      oldGold: oldGold.map((row) => ({
        metal: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
        itCode: text(row.IT_CODE),
        description: text(row.IT_DESC),
        pcs: num(row.ITM_PCS),
        grossWt: num(row.ITM_GWT),
        otherWt: num(row.ITM_OTH_WT),
        netWt: num(row.ITM_NWT),
        touch: num(row.ITM_TOUCH),
        fineWt: num(row.ITM_FINE),
        conversionPct: num(row.CON_PRC),
        conversionWt: num(row.CON_WT),
        rate: num(row.ITM_RATE),
        rateType: text(row.ITM_RATE_TYPE),
        amount: num(row.NET_AMT),
      })),
    };
  });
}

/** Replace a sale in-place, preserving the desktop header identity and audit-free edit semantics. */
export async function editSale(
  prisma: any,
  input: SaleInput,
  lines: SaleLineInput[],
  requestedVoucherNo: number | string,
): Promise<SaleResult> {
  completeSaleScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const persisted = await persistedSaleHeaderTx(tx, scope, voucherNo);
    // Full prior header for the USER_DATA edit audit, read BEFORE the write set is replaced.
    const priorHeaderRow: Record<string, unknown> | undefined = (
      await tx.$queryRawUnsafe(
        `SELECT * FROM "SL_DATA" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3
           AND "CO_BOOK"=$4 AND "VCH_NO"=$5 LIMIT 1`,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      )
    )[0];
    // Fail closed before any source flags or voucher rows move: both old and requested dates matter.
    await assertPeriodOpen(tx, input.scope.tenantId, {
      ledger: {
        table: 'AC_DATA',
        lines: [{ CO_CODE: input.scope.coCode, VCH_DATE: persisted.VCH_DATE }],
      },
    });
    await assertPeriodOpen(tx, input.scope.tenantId, {
      ledger: {
        table: 'AC_DATA',
        lines: [{ CO_CODE: input.scope.coCode, VCH_DATE: requestedDate }],
      },
    });

    const hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    const legacyRestores = await releaseSaleReferencesTx(tx, scope, voucherNo);
    // TR_SALE.cs:15167-15172 replaces the write set and TEMP_BOOK_DATA without DELETE_DATA.
    await deleteVoucherWriteSetTx(tx, {
      tables: SALE_WRITE_TABLES,
      key: { scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
    for (const tag of legacyRestores) {
      await restoreTagTx(tx, scope.tenantId, tag);
    }
    // TR_SALE.cs:14242-14243,14386,21243,15331,15341 preserve hidden no/user/clock.
    return writeSaleTx(tx, input, lines, {
      vchNo: Number(voucherNo),
      hdVchNo: hiddenVoucherNo,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
      isEdit: true,
      // Desktop compares the FULL reloaded header (SELECT * FROM SL_DATA).
      persistedHeader: priorHeaderRow,
      editingUser: input.mainUser ?? null,
    });
  });
}

/** Reverse a sale and write the desktop TR_SALE 1-header + N-detail DELETE_DATA audit. */
export async function deleteSale(prisma: any, input: DeleteSaleInput): Promise<{ reversed: true }> {
  completeSaleScope(input.scope);
  const scope = input.scope;
  const tenantId = scope.tenantId;
  const voucherNo = formatVoucherNo(input.vchNo);
  const key = keyOf(scope, voucherNo);
  return withTenant(prisma, tenantId, async (tx: any) => {
    const bookPolicy = await resolveBookPolicyTx(tx, scope, 'SALES');
    const configuredBookName = await configuredSaleBookNameTx(tx, scope);
    const header = await persistedSaleHeaderTx(tx, scope, voucherNo, [
      'AC_CODE',
      'AC_NAME',
      'TOT_AMT',
      'OLD_GL_AMT',
      'OLD_SL_AMT',
      'CASH_AMT',
      'CARD_AMT',
      'CHQ_AMT',
      'CASH_PAID',
      'KASAR_AMT',
      'VCH_DESC',
    ]);
    await assertPeriodOpen(tx, tenantId, {
      ledger: {
        table: 'AC_DATA',
        lines: [{ CO_CODE: input.scope.coCode, VCH_DATE: header.VCH_DATE }],
      },
    });
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","TAG_NO","NET_AMT","IT_TYPE","ITM_NWT"
         FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      ...saleParams(scope, voucherNo),
    );
    const legacyRestores = await releaseSaleReferencesTx(tx, scope, voucherNo);
    await reverseVoucherTx(tx, tenantId, { tables: [...SALE_WRITE_TABLES], key });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      text(header.HD_VCH_NO),
    );
    const deletedAt = new Date();
    const common = {
      ...key,
      VCH_DATE: header.VCH_DATE,
      VCH_TIME: header.VCH_TIME,
      DELETE_DATE: deletedAt,
      DELETE_TIME: deletedAt,
      VCH_TYPE: bookPolicy.vchType,
      BOOK_NAME: configuredBookName,
      AC_CODE: header.AC_CODE,
      AC_NAME: header.AC_NAME,
      HD_VCH_NO: header.HD_VCH_NO,
      MAIN_USER: header.MAIN_USER,
      DELETE_USER: input.deleteUser ?? 'system',
    };
    // TR_SALE.cs:16320: exactly one header audit row, SR_NO=0 and configured book identity.
    await insertRowTx(tx, 'DELETE_DATA', tenantId, {
      ...common,
      SR_NO: 0,
      VCH_VAL_DR: num(header.TOT_AMT),
      VCH_VAL_CR: round2s(
        num(header.OLD_GL_AMT) +
          num(header.OLD_SL_AMT) +
          num(header.CASH_AMT) +
          num(header.CARD_AMT) +
          num(header.CHQ_AMT) -
          num(header.CASH_PAID) +
          num(header.KASAR_AMT),
      ),
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      VCH_DESC: text(header.VCH_DESC).slice(0, 150),
    });
    // TR_SALE.cs:16322: one audit row per SL_DETL line with fine weight in VCH_FINE_CR.
    for (const detail of details) {
      await insertRowTx(tx, 'DELETE_DATA', tenantId, {
        ...common,
        SR_NO: num(detail.SR_NO),
        VCH_VAL_DR: num(detail.NET_AMT),
        VCH_VAL_CR: 0,
        FINE_TYPE: text(detail.IT_TYPE),
        VCH_FINE_DR: 0,
        VCH_FINE_CR: num(detail.ITM_NWT),
        VCH_DESC: `ItCode / ${text(detail.IT_CODE)}   TagNo / ${text(detail.TAG_NO)}`.slice(0, 150),
      });
    }
    for (const tag of legacyRestores) await restoreTagTx(tx, tenantId, tag);
    return { reversed: true };
  });
}
