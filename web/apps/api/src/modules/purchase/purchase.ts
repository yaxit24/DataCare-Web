import { type StoneSubDetailInput } from '../shared/stoneSubDetail.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { withTenant } from '@datacare/db';
import { recordFieldChangesTx } from '../vouchers/fieldAudit.js';
import { stagePurchaseLotDetailTx } from '../stock/lotRegister.js';
import {
  formatVoucherNo,
  nextVoucherNoTx,
  nextTagNoTx,
  type VoucherScope,
} from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  assertPeriodOpen,
  insertRowTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { payoutLegs, receiptLegs } from '../finance/tender.js';
import { fineFor } from '../shared/finePolicy.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../shared/bookPolicy.js';
import { assertCounterCodes, resolveCounterStockPolicyTx } from '../shared/counterStockPolicy.js';
import { resolveRoundingPolicyTx } from '../shared/roundingPolicyLoader.js';
import type { RoundingPolicy } from '../shared/roundingPolicy.js';
import { buildSaleRojmel, rojmelMetalFor } from '../shared/rojmel.js';
import {
  desktopLabourTypeFor,
  effectiveLabourRate,
  legacyLabourModeFor,
} from '../shared/labourDesktop.js';
import {
  cashPurchaseParty,
  generatedLabourRate,
  purchaseAmountBase,
  purchaseExpenseSplit,
  resolveSettingsBehaviorTx,
  tagSerialWidth,
  type LineAmountType,
} from '../shared/settingsBehavior.js';
import {
  metalAmount,
  labourCharge,
  lineNet as calcLineNet,
  billTotals,
  type LabourType,
  type BillTotals,
} from '@datacare/core';

export class PurchaseValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'PurchaseValidationError';
  }
}

export interface PurchaseLineInput {
  itCode: string;
  tagNo?: string; // tagged item -> created in stock on save (stock-IN), removed on delete
  vchSrno?: number; // persisted BAR_DETL identity; server verifies it for returns/issues
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number; // % purity; if fineWt absent, fine = (net+ght) * (touch+west) / 100
  ghtWt?: number;
  westPct?: number;
  lesTouch?: number; // old-gold/Kun less-touch adjustment; presence selects that desktop policy
  kunFine?: number; // old-gold/Kun fine addition; presence selects that desktop policy
  fineWt?: number;
  rate?: number; // metal rate (per fine unit)
  metalAmount?: number;
  labourType?: LabourType;
  labourRate?: number;
  labourPct?: number;
  labourFixed?: number;
  /**
   * Labour charge stated outright, which wins over any computed one — the mirror of `metalAmount`.
   *
   * Required for a lossless reopen: `LBR_TYPE` cannot hold the web's `percentage` or `fixed` modes, so a
   * reopened line has no recoverable labour type and would otherwise recompute its labour as zero.
   */
  labourAmount?: number;
  otherAmount?: number;
  /** Metal type for the AC_DATA fine-weight sub-ledger leg (desktop parity); default 'G' (gold). */
  metal?: 'G' | 'S';
  otherFineWt?: number; // PR_DETL.ITM_OTH_FINE, added to gold fine leg 29
  silverFineWt?: number; // PR_DETL.SILVER_FINE, posted to desktop silver account 00009
  /** Hallmark HUID / hallmark id stamped on this line (TR_PURC_HM → PR_DETL.HM_ID). */
  huid?: string;
  // Desktop purchase-grid columns (TR_PURC.cs `mSG_PR[i, c]`), one per PR_DETL column.
  itDesc?: string; // mSG_PR[i,2]  :13100
  tblCode?: string; // mSG_PR[i,3]  :13102
  designNo?: string; // mSG_PR[i,4]  :13103
  lotNo?: string; // mSG_PR[i,5]  :13104
  itmLot?: string; // mSG_PR[i,6]  :13105
  withStock?: string; // mSG_PR[i,7]  :13151
  bagWt?: number; // mSG_PR[i,8]  :13107
  lossWt?: number; // mSG_PR[i,14] :13112
  lessWt?: number; // mSG_PR[i,13] :13111 (ITM_OTH_WT)
  ghtPct?: number; // mSG_PR[i,19] :13117
  lessTouch?: number; // mSG_PR[i,23] :13121
  convRate?: number; // mSG_PR[i,27] :13131
  convPct?: number; // mSG_PR[i,28] :13132
  /**
   * The line's rate basis, persisted to `PR_DETL.RATE_TYPE`.
   *
   * `'G'` on all 78 captured purchase lines, including silver ones, so it is not the metal — `IT_TYPE` carries
   * that. The same union is already modelled on `RateCutLine.rateType`. Defaults to `'G'` because that is what
   * every captured line holds; an explicit value wins.
   */
  rateType?: 'P' | '1' | 'K' | 'G';
  urdRateType?: string; // mSG_PR[i,30] :13137
  otherRate?: number; // mSG_PR[i,37] :13129
  mrp?: number; // mSG_PR[i,39] :13139
  commissionPct?: number; // mSG_PR[i,41] :13140
  commissionAmount?: number; // mSG_PR[i,42] :13141
  fineCutPcs?: number; // mSG_PR[i,60] :13189
  fineCutGrossWt?: number; // mSG_PR[i,61] :13190
  fineCutNetWt?: number; // mSG_PR[i,62] :13191
  fineCutFine?: number; // mSG_PR[i,63] :13192
  prCode?: string; // mSG_PR[i,64] :13147
  /** Consignment receipt source columns for TR_PR_SL_UAE `CON PUR` mode. */
  consiNo?: string; // mSG_PR[i,36] → PR_DETL.CONSI_NO
  consiYrcd?: string; // mSG_PR[i,37] → PR_DETL.CONSI_YRCD
  consiDbcd?: string; // mSG_PR[i,38] → PR_DETL.CONSI_DBCD
  consiSrno?: number; // mSG_PR[i,39] → PR_DETL.CONSI_SRNO
  /**
   * Stone/diamond sub-detail rows for this line (desktop `DtIdtlPr` grid → PR_IDTL,
   * TR_PURC.cs:13211-13243). An empty grid writes no PR_IDTL rows, so omitting this writes none.
   */
  stones?: PurchaseStoneInput[];
}

/** One PR_IDTL sub-detail row (TR_PURC.cs:13223-13242, `DtIdtlPr.Rows[i][n]` column ordinals). */
export interface PurchaseStoneInput extends StoneSubDetailInput {
  /** Extends the shared TblIdtl shape: stone identity plus the karigar side of its valuation. */
  isrNo?: number; // [0]  ISR_NO
  itCode?: string; // [1]  IT_CODE
  dmCode?: string; // [3]  DM_CODE
  dmName?: string; // [4]  DM_NAME
  dmColor?: string; // [5]  DM_COLOR
  dmSize?: string; // [6]  DM_SIZE
  dmOrigin?: string; // [7]  DM_ORIGIN
  dmRemark?: string; // [8]  DM_REMARK
  dmSfNo?: string; // [9]  DM_SFNO
  pcs?: number; // [12] IT_PCS
  grossWt?: number; // [14] IT_GWT
  conPct?: number; // [15] IT_CON_PRC
  rateType?: string; // [16] IT_RATE_TYPE
  rate?: number; // [17] IT_RATE
  amount?: number; // [18] IT_AMT
  lbrRate?: number; // [19] IT_LBR_RATE
  lbrAmount?: number; // [20] IT_LBR_AMT
  netAmount?: number; // [21] IT_NET_AMT
  conWt?: number; // [22] IT_CON_WT
  itType?: string; // [23] IT_TYPE
}

export interface PurchaseInput {
  scope: VoucherScope;
  mainUser?: string; // authenticated user; persisted and preserved by edit
  acCode: string; // supplier account (required)
  acName?: string;
  billNo?: string;
  vchDate?: Date | string;
  // Desktop PR_DATA header fields (TR_PURC.cs:12982-13046): party address/contact, bank and
  // cheque reference, credit terms, bill discount %, and the TDS/TCS settlement rows.
  address1?: string;
  address2?: string;
  address3?: string;
  city?: string;
  mobile?: string;
  bankName?: string;
  chequeNo?: string;
  cardAc?: string;
  creditDays?: number;
  discountPct?: number;
  tcsCode?: string;
  tcsPct?: number;
  tcsAmount?: number;
  tdsCode?: string;
  tdsPct?: number;
  tdsAmount?: number;
  /** Purchase booked against a sale bill (TR_PURC.cs:13169-13172 tSlBill / tSlBill_DbCd). */
  saleBillNo?: string;
  saleBillLc?: string;
  saleBillYear?: string;
  saleBillBook?: string;
  /** TR_PR_SL_UAE `CON PUR` header source receipt, persisted in PR_DATA/PR_DETL SL_BILL_* columns. */
  consiNo?: string;
  consiLcCode?: string;
  consiYrcd?: string;
  consiDbcd?: string;
  discountAmount?: number;
  taxRatePct: number;
  taxCode?: string;
  interState: boolean; // checked against persisted AC_MAST.AC_GST_TYPE; never authoritative
  urd?: boolean; // unregistered-dealer purchase — no input GST (tax forced to 0)
  rateUnfix?: boolean; // PR_DATA.RATE_UNFIX; gates the workflow-specific fine ledger policy
  purchaseAc?: string; // purchase expense ledger (default 'PURCHASE')
  taxAc?: string; // GST input ledger (default 'GST-INPUT')
  roundAc?: string;
  // Hallmark purchase (TR_PURC_HM): a hallmarking charge on the bought items + its own input GST.
  hmAmount?: number; // HM_AMT — hallmark charge (0/absent ⇒ a normal purchase)
  hmChargeAc?: string; // hallmark-expense ledger (default 'HMCHRG')
  hmTaxPct?: number; // GST% on the hallmark charge (defaults to the bill taxRatePct)
  // Settlement/tender (desktop PR_DATA CASH_AMT/CHQ_AMT/CARD_AMT/KASAR_AMT/BILL_OS) — pay the supplier now.
  cashAmt?: number;
  chequeAmt?: number;
  cardAmt?: number;
  upiAmt?: number;
  kasar?: number;
  cashAc?: string; // default 'CASH'
  bankAc?: string; // default 'BANK' (cheque/card/upi)
  kasarAc?: string; // default 'KASAR'
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

const num = (v: unknown): number => (v == null ? 0 : Number(v));
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;

/** Resolve a purchase line's 3dp fine: standard items use (net+ght)×(touch+west)/100;
 * old-gold/Kun inputs use the TR_PURC.cs:7310-7317 less-touch + Kun-fine policy. */
export function lineFine(line: PurchaseLineInput): number {
  if (line.fineWt != null) return round3(Number(line.fineWt));
  const workflow =
    line.lesTouch != null || line.kunFine != null ? 'purchaseOldGold' : 'purchaseItem';
  return fineFor(workflow, line);
}

/** Compute a purchase line's metal/labour/net (pure). */
export function computeLine(
  line: PurchaseLineInput,
  policy?: RoundingPolicy,
  amountType: LineAmountType = '',
  /** CO_SET_NEW.LBR_WITH_GHT; defaults to the desktop's blank default of true. */
  labourWithGhat: boolean = true,
): {
  fine: number;
  metal: number;
  labour: number;
  net: number;
} {
  const fine = lineFine(line);
  const rate =
    line.rate == null
      ? undefined
      : policy
        ? policy.roundPurchaseRate(line.rate)
        : Number(line.rate);
  // TR_PURC.cs:7396 selects the rate base from CO_SET.PR_AMT_TYPE; this mode is never accepted
  // from the request. An explicit metalAmount remains the authoritative desktop-style line value.
  const amountBase = purchaseAmountBase({ ...line, fineWt: fine }, amountType);
  const metal =
    line.metalAmount != null
      ? Number(line.metalAmount)
      : rate != null
        ? metalAmount(amountBase, rate)
        : 0;
  const labour =
    // An explicitly stated labour amount wins, exactly as `metalAmount` does for metal above.
    //
    // WP-08: without this, reopening a purchase and saving it unchanged SILENTLY ZEROED the labour charge and
    // reduced the voucher total by that amount. `LBR_TYPE` cannot represent the web's `percentage` and `fixed`
    // modes — `desktopLabourTypeFor` collapses both to the company default code — so the reader cannot recover
    // the mode, `line.labourType` comes back undefined, and this expression used to fall through to 0. The
    // amount, however, IS persisted in `LBR_AMT`, and the reader returns it; honouring it keeps the money
    // while inventing no labour mode that the desktop column cannot hold.
    line.labourAmount != null
      ? Number(line.labourAmount)
      : line.labourType
        ? labourCharge(
            line.labourType,
            {
              netWt: line.netWt,
              pcs: line.pcs,
              rate: line.labourRate,
              pct: line.labourPct,
              metalAmount: metal,
              fixed: line.labourFixed,
              // P4: (net + ghat) x rate is the desktop's per-gram labour base; the ghat term is
              // dropped only when CO_SET_NEW.LBR_WITH_GHT = 'N' (TR_SALE.cs:11112-11123, blank
              // default 'Y' at MS_OPNCOMP.cs:1224-1226). This was omitted entirely, so labour was
              // understated by ghat x rate on every line carrying ghat weight.
              ghatWt: line.ghtWt,
              withGhat: labourWithGhat,
            },
            policy,
          )
        : 0;
  const net = calcLineNet({ metal, labour, other: line.otherAmount });
  return { fine, metal, labour, net };
}

/**
 * Build the balanced double-entry AC_DATA lines for a purchase (pure). Ledger sense is the MIRROR of
 * sales: credit supplier (total), debit purchase (taxable) + input GST (tax) + round-off (Req 11.2/13.1).
 */
export function buildPurchaseLedger(p: {
  key: VoucherKey;
  acCode: string;
  purchaseAc: string;
  taxAc: string;
  roundAc: string;
  controlAc?: string;
  vchType?: string;
  totals: Pick<BillTotals, 'total' | 'taxable' | 'tax' | 'roundOff'>;
  expenseLegs?: { ac: string; amount: number }[];
}): LedgerLine[] {
  const base = { ...p.key, VCH_TYPE: p.vchType ?? 'PURC' };
  const lines: LedgerLine[] = [];
  if (p.totals.total !== 0)
    lines.push({
      ...base,
      AC_CODE: p.acCode,
      legType: PURC_LEG.party,
      LD_CODE: p.controlAc ?? p.purchaseAc,
      DR_AMT: 0,
      CR_AMT: p.totals.total,
      SIGN: 'C',
    });
  const expense =
    p.expenseLegs && p.expenseLegs.length
      ? p.expenseLegs
      : [{ ac: p.purchaseAc, amount: p.totals.taxable }];
  for (const leg of expense)
    if (leg.amount !== 0)
      lines.push({
        ...base,
        legType: PURC_LEG.purchase,
        AC_CODE: leg.ac,
        LD_CODE: p.acCode,
        DR_AMT: leg.amount,
        CR_AMT: 0,
        SIGN: 'D',
      });
  if (p.totals.tax !== 0)
    lines.push({
      ...base,
      legType: PURC_LEG.tax,
      AC_CODE: p.taxAc,
      LD_CODE: p.acCode,
      DR_AMT: p.totals.tax,
      CR_AMT: 0,
      SIGN: 'D',
    });
  if (p.totals.roundOff > 0)
    lines.push({
      ...base,
      legType: PURC_LEG.webRoundOff,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: p.totals.roundOff,
      CR_AMT: 0,
      SIGN: 'D',
    });
  else if (p.totals.roundOff < 0)
    lines.push({
      ...base,
      legType: PURC_LEG.webRoundOff,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: 0,
      CR_AMT: Math.abs(p.totals.roundOff),
      SIGN: 'C',
    });
  return lines;
}

/** Allocate the bill taxable across distinct per-group expense accounts, proportional to each group's
 *  line-net share; the last account absorbs the rounding remainder so Σ legs == taxable exactly. */
export function buildExpenseLegs(
  items: { net: number; ac: string }[],
  taxable: number,
  lineNetTotal: number,
): { ac: string; amount: number }[] {
  const R2 = (x: number): number => Math.round((x + 1e-9) * 100) / 100;
  const byAc = new Map<string, number>();
  for (const it of items) byAc.set(it.ac, R2((byAc.get(it.ac) ?? 0) + it.net));
  const acs = [...byAc.keys()];
  if (acs.length <= 1) return [{ ac: acs[0] ?? 'PURCHASE', amount: R2(taxable) }];
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

export function buildPurchaseFineLedger(p: {
  key: VoucherKey;
  acCode: string;
  purchaseAc: string;
  vchType?: string;
  rateUnfix?: boolean;
  purcAcByItem?: Record<string, string>;
  lines: Array<{
    itCode: string;
    metal?: 'G' | 'S';
    fine: number;
    metalAmount: number;
    otherFineWt?: number;
    silverFineWt?: number;
  }>;
}): LedgerLine[] {
  if (p.rateUnfix) return [];
  // ONE FINE LEG PER LINE, not one per metal/account combination.
  //
  // Measured on book 035: 42 real type-21 legs across 11 accounts, and voucher 00004 alone has THREE - lines 1,
  // 2 and 3 carrying 12.712, 11.950 and 3.950, all gold and all against purchase account 00008. Aggregating by
  // `${metal}|${ldCode}` collapsed those into a single leg of 28.612.
  //
  // THE KEY IS A DIFFERENT LAYOUT FROM THE SAME BOOK'S MONEY LEGS. Money legs 01/03/06/16/17 are 23 characters
  // with the leg type at 22-23; these fine legs are 33 with `<line><leg>` right-aligned in 12 - the cash books'
  // shape. So one table of one book uses two layouts, chosen by leg type. Real keys:
  //
  //     [01002024-202503500004         121]  fine 12.712
  //     [01002024-202503500004         221]  fine 11.950
  //     [01002024-202503500004         321]  fine  3.950
  //
  // `legKeySuffix` carries it per row, which is why that mechanism is per-LINE rather than per-family.
  const suffix = (line: number): string =>
    `${line}${String(FINE_LEG).padStart(2, '0')}`.padStart(12, ' ');
  const out: LedgerLine[] = [];
  p.lines.forEach((line, idx) => {
    if (round2(line.metalAmount) !== 0) return;
    const metal = line.metal ?? 'G';
    const ldCode = metal === 'S' ? '00009' : (p.purcAcByItem?.[line.itCode.trim()] ?? p.purchaseAc);
    const fine =
      metal === 'S' ? round3(num(line.silverFineWt)) : round3(line.fine + num(line.otherFineWt));
    if (fine === 0) return;
    out.push({
      ...p.key,
      legKeySuffix: suffix(idx + 1),
      VCH_TYPE: p.vchType ?? 'PURC',
      AC_CODE: p.acCode,
      LD_CODE: ldCode,
      IT_TYPE: metal,
      SIGN: '+',
      FINE_WT: fine,
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
    });
  });
  return out;
}

/**
 * The purchase FINE leg's type code, measured on books 035 and 036: type 21, on all 42 real legs.
 *
 * The money legs use different codes entirely - 01 party Cr, 03 purchase Dr, 06 tax Dr, 16/17 the settlement
 * pair, 18/19 the kasar pair - and they are 23-character keys while these are 33.
 */
const FINE_LEG = 21;

/**
 * Purchase leg type codes, measured across books 035 and 036.
 *
 *   01 party      Cr   (17)   the bill - the sale's shape with the directions inverted
 *   03 purchase   Dr   (17)   00008 gold / 00009 silver
 *   06 tax 00085  Dr    (2)
 *   16 party Dr / 17 cash Cr   (5)   paying the supplier
 *   18 party Dr / 19 kasar 00042 Cr  (2)   book 036 only
 *   21 fine legs       (42)   weight only, 33-character keys - see buildPurchaseFineLedger
 *
 * NOTE THE TAX CODE. Purchase uses 06 where the SALE family uses 04 for the same role. So the codes are not a
 * universal role map even for identical roles - they are per book, which is the third independent confirmation
 * of that after the cash/bank split and the receipt/payment split.
 */
const PURC_LEG = {
  party: 1,
  purchase: 3,
  tax: 6,
  settleParty: 16,
  settleCash: 17,
  kasarParty: 18,
  kasar: 19,
  /** The web's round-off leg, which the desktop does not write. Same reasoning as the sale family's 99. */
  webRoundOff: 99,
} as const;

function keyOf(s: VoucherScope, vchNo: number | string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'PUR',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export interface PurchaseResult {
  vchNo: number;
  totals: BillTotals;
}

interface WritePurchaseContext {
  vchNo: number;
  hdVchNo: string;
  mainUser: string;
  persistedClock?: unknown;
  isEdit: boolean;
  /** Persisted header read back before the rewrite, for the USER_DATA per-field edit audit. */
  persistedHeader?: Record<string, unknown>;
  /** User performing the edit (desktop NEW_USER). */
  editingUser?: string | null;
  /** TR_PURC `PR QUOT` mode: persist PR_DATA/PR_DETL/PR_IDTL only; posting routines intentionally match no rows. */
  quoteMode?: boolean;
  /**
   * Tag serials already persisted by THIS voucher, keyed by tag number, read before the rewrite.
   *
   * WP-08: an edit deletes and rebuilds the write set, and without this the writer allocated a fresh
   * `VCH_SRNO` for every tagged line — so reopening a purchase and saving it unchanged changed the tag
   * IDENTITY (measured 1 → 2), violating plan §7.1 invariants 1 and 2. Tag opening solves the same problem
   * with the same field name, and this mirrors it.
   */
  persistedTagSrnos?: Map<string, number>;
}

function completePurchaseScope(
  scope: VoucherScope,
): asserts scope is VoucherScope & { coYear: string; coBook: string } {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new PurchaseValidationError(
      'purchase requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

/**
 * Reject a non-numeric header value with a message that names the field.
 *
 * WHY THIS EXISTS: `PurchaseInput.taxRatePct` is declared as a required `number`, but the HTTP route
 * copies `body.taxRatePct` through untouched, so a request that simply omits it passed `undefined`
 * into the money pipeline and surfaced as an unhandled `[DecimalError] Invalid argument: undefined`
 * — HTTP 500, no field named. Found by posting a real voucher against the running stack; every test
 * supplies a complete fixture, so the suite could not see it.
 *
 * It deliberately does NOT default the value to 0. A silent 0 would post a tax-free bill for a
 * company that charges tax, which is worse than a refusal: the voucher would look successful and the
 * GST return would be wrong. A missing required field is the caller's error and is reported as one.
 */
function requirePurchaseNumber(value: unknown, field: string): number {
  if (typeof value === 'number' && Number.isFinite(value)) return value;
  // Accept a numeric string, since HTML form fields arrive as strings.
  if (typeof value === 'string' && value.trim() !== '' && Number.isFinite(Number(value))) {
    return Number(value);
  }
  throw new PurchaseValidationError(
    `purchase requires a numeric ${field}; received ${value === undefined ? 'nothing' : JSON.stringify(value)}`,
  );
}

async function configuredPurchaseBookNameTx(
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
    throw new PurchaseValidationError(`purchase book configuration is ambiguous: ${scope.coBook}`);
  }
  return String(rows[0]?.BOOK_NAME ?? '').trim();
}

async function authoritativePurchaseAccountNameTx(
  tx: any,
  scope: VoucherScope,
  acCode: string,
): Promise<string> {
  const rows: Array<{ AC_NAME: unknown }> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "AC_NAME",row_id,CASE WHEN "LC_CODE"::text=$4 THEN 0 ELSE 1 END priority
         FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
          AND ("LC_CODE" IS NULL OR btrim("LC_CODE"::text)='' OR "LC_CODE"::text=$4)
     )
     SELECT "AC_NAME" FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates) ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    acCode,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new PurchaseValidationError(
      rows.length
        ? `supplier account is ambiguous: ${acCode}`
        : `supplier account not found: ${acCode}`,
    );
  }
  return text(rows[0]?.AC_NAME);
}

/**
 * Desktop TR_PURC write core. Main numbering is MAX(PR_DATA.VCH_NO)+1 by company/location/year/book
 * (TR_PURC.cs:12911); hidden numbering is MAX(TEMP_BOOK_DATA.VCH_NO)+1 without year, five digits
 * (TR_PURC.cs:12100,12108,12923,12927). Edits call this after removing the prior write set.
 */
async function writePurchaseTx(
  tx: any,
  input: PurchaseInput,
  lines: PurchaseLineInput[],
  ctx: WritePurchaseContext,
): Promise<PurchaseResult> {
  completePurchaseScope(input.scope);
  const behavior = await resolveSettingsBehaviorTx(tx, input.scope);
  // TR_PURC.cs:11977: enabled cash purchase defaults the persisted party to desktop account 00050.
  input = { ...input, acCode: cashPurchaseParty(input.acCode, behavior.cashPurchaseAccount) };
  if (!input.acCode) throw new PurchaseValidationError('supplier account (acCode) is required');
  if (!lines || lines.length === 0)
    throw new PurchaseValidationError('at least one line item is required');

  const purchaseAc = input.purchaseAc ?? 'PURCHASE';
  const fallbackTaxAc = input.taxAc ?? 'GSTINPUT';
  const requestedRoundAc = input.roundAc;
  const taxPct = input.urd ? 0 : input.taxRatePct;
  const tenantId = input.scope.tenantId;
  const vchNo = ctx.vchNo;
  const key = keyOf(input.scope, vchNo);
  const linkedSource = purchaseLinkFromInput(input);
  const actualMainBook = await purchaseMainBookTx(
    tx,
    input.scope as VoucherScope & { coYear: string; coBook: string },
  );
  const isPurchaseQuotation = actualMainBook === 'PR QUOT';
  if (ctx.quoteMode && !isPurchaseQuotation) {
    throw new PurchaseValidationError(
      `purchase quotation requires BOOK_DATA.MAIN_BOOK='PR QUOT' for book ${input.scope.coBook}`,
    );
  }
  if (isPurchaseQuotation && !ctx.quoteMode) {
    throw new PurchaseValidationError(
      `book ${input.scope.coBook} is PR QUOT; use the purchase quotation workflow`,
    );
  }
  const bookPolicy = await resolveBookPolicyTx(
    tx,
    input.scope,
    isPurchaseQuotation
      ? 'PURCHASE QUOTATION'
      : actualMainBook === 'CON PUR'
        ? 'CONSIGNMENT PURCHASE'
        : 'PURCHASE',
  );
  const roundingPolicy = await resolveRoundingPolicyTx(tx, input.scope);

  // TR_PURC.cs refuses a voucher whose footer totals are ALL zero — labour amount, pieces, gross weight
  // and net amount together. Summing the same four quantities across the request's lines reproduces the
  // footer test without needing the grid.
  const contentTotal = lines.reduce(
    (sum, l) =>
      sum +
      Math.abs(Number(l.labourFixed ?? 0)) +
      Math.abs(Number(l.labourRate ?? 0)) +
      Math.abs(Number(l.pcs ?? 0)) +
      Math.abs(Number(l.grossWt ?? 0)) +
      Math.abs(Number(l.metalAmount ?? 0)),
    0,
  );
  if (contentTotal === 0) throw new PurchaseValidationError(DESKTOP_MESSAGES.PARTY_ENTRY_REQUIRED);

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
  // TR_PURC's HmId2..4 weight rule lives on header controls (tHmId2/nHmWt2), which the purchase input
  // does not carry: PR_DETL keeps a single HM_ID per line. Enforced on sales, where the four ID slots
  // and their weights both exist.
  const configuredBookName = await configuredPurchaseBookNameTx(
    tx,
    input.scope as VoucherScope & { coBook: string },
  );
  const taxPolicy = await resolveTaxPolicyTx(tx, input.scope, {
    acCode: input.acCode,
    taxPct,
    taxCode: input.taxCode,
  });
  const supplierName = await authoritativePurchaseAccountNameTx(tx, input.scope, input.acCode);
  if (input.interState !== taxPolicy.interState) {
    throw new PurchaseValidationError('interState does not match the persisted supplier GST type');
  }
  const interState = taxPolicy.interState;
  const taxAc = taxPolicy.taxAc ?? fallbackTaxAc;

  const computed = lines.map((line) => {
    const rounded =
      line.rate == null ? line : { ...line, rate: roundingPolicy.roundPurchaseRate(line.rate) };
    const calc = computeLine(
      rounded,
      roundingPolicy,
      behavior.purchaseAmountType,
      behavior.labourIncludesGhat,
    );
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
      taxRatePct: taxPct,
      interState: interState,
    },
    roundingPolicy,
  );

  // Hallmark purchase (TR_PURC_HM): a hallmarking charge + its own input GST. 0 ⇒ a normal purchase
  // (identical output). Mirror of the sale-HM: here Dr hallmark-expense + Dr input-GST / Cr supplier.
  const hmAmt = round2(num(input.hmAmount));
  /**
   * `PURC_WITH_HMTAX` — whether GST applies to the hallmark charge (P4).
   *
   * The desktop makes this a company switch and gives HM tax its own total row
   * (TR_PURC_HM.cs:7262-7264, :9394). The web computed it whenever an `hmAmount` was supplied, so a shop
   * configured not to charge GST on hallmarking was charging it anyway — a wrong tax figure on every
   * hallmark bill, invisible because the setting appeared to exist.
   *
   * The CHARGE itself still posts; only its tax is gated, which is what the desktop does.
   */
  const hmTaxApplies = behavior.purchaseWithHallmarkTax;
  const hmTaxPct = hmTaxApplies ? (input.hmTaxPct ?? taxPct) : 0;
  const hmTax = roundingPolicy.roundTaxAmount((hmAmt * hmTaxPct) / 100);
  const hmCgst = interState ? 0 : roundingPolicy.roundTaxAmount(hmTax / 2);
  const hmSgst = interState ? 0 : roundingPolicy.roundTaxAmount(hmTax - hmCgst);
  const hmIgst = interState ? hmTax : 0;
  const grandTotal = roundingPolicy.roundBillTotal(totals.total + hmAmt + hmTax);

  const validateConfiguredAccount = (
    label: string,
    requested: string | undefined,
    configured: string,
  ): string => {
    if (requested && requested.trim() !== configured)
      throw new PurchaseValidationError(`${label} does not match BOOK_DETL configuration`);
    return configured;
  };
  const controlAc =
    isPurchaseQuotation || totals.total === 0
      ? purchaseAc
      : await resolveBookAccountTx(tx, input.scope, bookPolicy, 1);
  let cashAc = input.cashAc ?? 'CASH';
  if (!isPurchaseQuotation && round2(num(input.cashAmt)) !== 0) {
    cashAc = validateConfiguredAccount(
      'cash account',
      input.cashAc,
      await resolveBookAccountTx(tx, input.scope, bookPolicy, 2),
    );
  }
  let roundAc = requestedRoundAc ?? 'ROUNDOFF';
  let kasarAc = input.kasarAc ?? 'KASAR';
  if (!isPurchaseQuotation && (totals.roundOff !== 0 || round2(num(input.kasar)) !== 0)) {
    const configured = await resolveBookAccountTx(tx, input.scope, bookPolicy, 3);
    roundAc = validateConfiguredAccount('round account', requestedRoundAc, configured);
    kasarAc = validateConfiguredAccount('kasar account', input.kasarAc, configured);
  }

  // Per-group expense accounts (desktop GROUP_MAST.PURC_AC): map each item → its group's purchase
  // account, fall back to the single purchaseAc when unmapped. Σ legs == taxable.
  const itCodes = Array.from(
    new Set(lines.map((l) => String(l.itCode ?? '').trim()).filter(Boolean)),
  );
  const purcAcByItem: Record<string, string> = {};
  const itemTypeByItem: Record<string, 'G' | 'S'> = {};
  const itemNameByItem: Record<string, string> = {};
  if (itCodes.length) {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT i."IT_CODE" ic,i."IT_TYPE" typ,i."IT_NAME" nm,g."PURC_AC" pac FROM "ITEM_MAST" i
         LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id
          AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
         WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"::text = ANY($3::text[])`,
      input.scope.tenantId,
      input.scope.coCode,
      itCodes,
    );
    for (const r of rows) {
      const item = String(r.ic ?? '').trim();
      const account = String(r.pac ?? '').trim();
      const itemType = String(r.typ ?? '')
        .trim()
        .toUpperCase();
      if (!item) throw new PurchaseValidationError(`item not found or invalid: ${item || '?'}`);
      if (!isPurchaseQuotation && !account)
        throw new PurchaseValidationError(`missing GROUP_MAST.PURC_AC for item ${item || '?'}`);
      if (itemType !== 'G' && itemType !== 'S') {
        throw new PurchaseValidationError(`invalid ITEM_MAST.IT_TYPE for item ${item || '?'}`);
      }
      if (account) purcAcByItem[item] = account;
      itemTypeByItem[item] = itemType;
      // IT_DESC on a metal Rojmel row: the real rows carry the item's name ('FINE GOLD' for 999).
      itemNameByItem[item] = String(r.nm ?? '').trim();
    }
    const missingItems = itCodes.filter((item) => !itemTypeByItem[item]);
    if (missingItems.length) {
      throw new PurchaseValidationError(`item configuration missing: ${missingItems.join(', ')}`);
    }
    const missing = itCodes.filter((item) => !purcAcByItem[item]);
    if (!isPurchaseQuotation && missing.length)
      throw new PurchaseValidationError(
        `item/group posting configuration missing: ${missing.join(', ')}`,
      );
  }
  // Ac_Ledr.cs:520-532: PURC_WITH_LBR='Y' keeps labour/other in the primary purchase leg; 'N'
  // separates those charges to BOOK_DETL row 4. Discount remains in the primary allocation so the
  // web ledger remains exactly balanced without inventing an additional desktop discount account.
  const splits = computed.map((c) =>
    purchaseExpenseSplit(
      c.calc.net,
      c.calc.labour,
      num(c.in.otherAmount),
      behavior.purchaseWithLabour,
    ),
  );
  const labourOtherTotal = round2(splits.reduce((sum, split) => sum + split.labourOther, 0));
  const primaryTotal = splits.reduce((sum, split) => sum + split.primary, 0);
  const expenseLegs = buildExpenseLegs(
    computed.map((c, index) => ({
      net: splits[index]?.primary ?? 0,
      ac: purcAcByItem[String(c.in.itCode ?? '').trim()] ?? purchaseAc,
    })),
    round2(totals.taxable - labourOtherTotal),
    primaryTotal,
  );
  if (!isPurchaseQuotation && labourOtherTotal !== 0) {
    expenseLegs.push({
      ac: await resolveBookAccountTx(tx, input.scope, bookPolicy, 4),
      amount: labourOtherTotal,
    });
  }

  // Each purchased tag receives the desktop VCH_SRNO identity even when TAG_NO is manual.
  //
  // On an EDIT the identity must not move: a tag already carrying a serial from this voucher keeps it, so
  // reopening and saving leaves the ornament identifiable. Only a tag this voucher has not seen takes a new
  // serial, which is what happens on create and when the operator types a different tag number.
  //
  // The map is CONSUMED as it is read. Two input lines naming the same tag number must not both claim the
  // persisted serial — that would mint a duplicate identity, a strictly worse failure than the field loss this
  // fixes — so the second such line falls through to a fresh allocation exactly as it does today.
  const persistedTagSrnos = new Map(ctx.persistedTagSrnos ?? []);
  const tagSrnos = new Map<number, number>();
  for (const [index, c] of computed.entries()) {
    if (isPurchaseQuotation) continue;
    if (!c.in.tagNo) continue;
    const reused = persistedTagSrnos.get(String(c.in.tagNo).trim());
    if (reused != null && reused > 0) {
      persistedTagSrnos.delete(String(c.in.tagNo).trim());
      tagSrnos.set(index, reused);
      continue;
    }
    const allocated = await nextTagNoTx(tx, input.scope, {
      prefix: String(c.in.itCode ?? '').slice(0, 3),
      pad: tagSerialWidth(behavior),
    });
    tagSrnos.set(index, allocated.srno);
  }

  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  // TR_PURC.cs:12134-12135,13051,13066,13148,13173 preserve the opened wall clock on edit.
  const sharedVoucherTime = voucherTimestamp(vchDate, ctx.persistedClock);
  const detl = computed.map((c, idx) => ({
    ...key,
    VCH_DATE: vchDate,
    VCH_TIME: sharedVoucherTime,
    VCH_TYPE: bookPolicy.vchType,
    INOUT_TYPE: bookPolicy.inout,
    ENTRY_TYPE: 'P',
    BOOK_NAME: bookPolicy.bookName,
    AC_CODE: input.acCode,
    MAIN_USER: ctx.mainUser || null,
    HD_VCH_NO: ctx.hdVchNo,
    SR_NO: idx + 1,
    // OLD_SRNO carries the line's own serial on original entry — measured equal to SR_NO on all 103 real
    // PR_DETL rows (0 zero, 0 null). The web wrote 0, breaking any back-reference that joins on it.
    OLD_SRNO: idx + 1,
    IT_CODE: c.in.itCode,
    IT_TYPE: itemTypeByItem[String(c.in.itCode ?? '').trim()],
    /**
     * `''` on an untagged purchase LINE, not `'N'`.
     *
     * The `'N'` sentinel is a `MAIN_STOCK` convention, verified from `Ac_Stock.cs:54` where the desktop writes
     * `CASE WHEN A.TAG_NO = '' THEN 'N' ELSE A.TAG_NO END` — the SOURCE rows hold `''` and only the stock row is
     * converted. `PR_DETL` holds `''` on 78/78 captured rows, and the derived column-default spec agrees.
     *
     * So the sentinel is per TABLE, not global. That also puts the WP-08e change to `KR_DETL` in doubt: it was
     * justified from `TR_KR_ISU.cs:5109`, the karigar form's own save routine, so it is probably right — but it
     * should be confirmed against captured `KR_DETL` rows rather than assumed from this table.
     */
    TAG_NO: c.in.tagNo ?? '',
    VCH_SRNO: tagSrnos.get(idx) ?? 0,
    ITM_PCS: num(c.in.pcs),
    ITM_GWT: num(c.in.grossWt),
    ITM_NWT: num(c.in.netWt),
    ITM_TOUCH: num(c.in.touch),
    ITM_GHT_WT: num(c.in.ghtWt),
    ITM_WEST_PRC: num(c.in.westPct),
    ITM_FINE: c.calc.fine,
    ITM_OTH_FINE: num(c.in.otherFineWt),
    SILVER_FINE: num(c.in.silverFineWt),
    ITM_RATE: num(c.in.rate),
    ITM_AMT: c.calc.metal,
    // LBR_TYPE selects the weight BASIS: G gross wise, N net wise, K kg wise, P pcs wise
    // (CO_SET.LBR_TYPE options; TR_SALE.cs:11104/11119/11108/11127). The previous map sent per_gram to 'G',
    // which is GROSS weight, and emitted '%', which the varchar(1) column never holds.
    LBR_TYPE: desktopLabourTypeFor(c.in.labourType, behavior.labourType) || null,
    LBR_PRC: num(c.in.labourPct),
    // Derived when the operator supplied a percentage rather than a rate (TR_SALE.cs:11021):
    // LBR_RATE = Math.Round(ITM_RATE x LBR_PRC / 100, MsLbrRof).
    LBR_RATE: effectiveLabourRate(
      num(c.in.labourRate),
      num(c.in.rate),
      num(c.in.labourPct),
      roundingPolicy.labourDecimals,
    ),
    LBR_AMT: c.calc.labour,
    OTH_AMT: num(c.in.otherAmount),
    // TR_PURC.cs:13142 — TOT_AMT <- mSG_PR[i,40], computed as
    //   mSG_PR[Row,40] = Format(Val([Row,35]) + Val([Row,36]) + Val([Row,31]), "0.00")
    // where 35 = cPrLbrAmt, 36 = cPrOthAmt, 31 = cPrItAmt. Unlike the SALE line total this uses NO
    // Math.Round, so paise are preserved at two decimals — do not copy the sale's whole-rupee rule here.
    TOT_AMT: round2(c.calc.metal + c.calc.labour + num(c.in.otherAmount)),
    // TR_PURC.cs:13144 — NET_AMT <- mSG_PR[i,44]. With tax% = 0 the desktop sets
    //   mSG_PR[Row,44] = Format(Val([Row,40]) + Val([Row,42]), "0.00")   // total + commission
    // A second branch back-calculates a tax-exclusive net from a tax-INCLUSIVE total, but it is gated on
    // `Val([Row,43]) <> Val([Row,58])` — column 58 is a shadow copy of the previous tax %, i.e. a UI
    // change-detection flag. Its outcome therefore depends on the operator's edit sequence and is not
    // reproducible from a request payload, so it is recorded as an ambiguity rather than guessed at.
    NET_AMT: round2(
      round2(c.calc.metal + c.calc.labour + num(c.in.otherAmount)) + num(c.in.commissionAmount),
    ),
    TAX_PRC: taxPct,
    HM_ID: c.in.huid ?? null,
    // Desktop PR_DETL columns (TR_PURC.cs:13100-13192). Grid cells left blank persist as ''/0,
    // which is what an absent input reproduces here.
    IT_DESC: text(c.in.itDesc).slice(0, 100) || null, // mSG_PR[i,2]  :13100
    TBL_CODE: text(c.in.tblCode).slice(0, 3) || null, // mSG_PR[i,3]  :13102
    DESIGN_NO: text(c.in.designNo).slice(0, 20) || null, // mSG_PR[i,4]  :13103
    LOT_NO: text(c.in.lotNo).slice(0, 10) || null, // mSG_PR[i,5]  :13104
    ITM_LOT: text(c.in.itmLot).slice(0, 10) || null, // mSG_PR[i,6]  :13105
    WITH_STOCK: text(c.in.withStock).slice(0, 1) || null, // mSG_PR[i,7]  :13151
    BAG_WT: num(c.in.bagWt), // mSG_PR[i,8]  :13107
    ITM_OTH_WT: num(c.in.lessWt), // mSG_PR[i,13] :13111
    ITM_LOSS_WT: num(c.in.lossWt), // mSG_PR[i,14] :13112
    ITM_GHT_PRC: num(c.in.ghtPct), // mSG_PR[i,19] :13117
    ITM_LESS_TCH: num(c.in.lessTouch ?? c.in.lesTouch), // mSG_PR[i,23] :13121
    CONV_RATE: num(c.in.convRate), // mSG_PR[i,27] :13131
    CONV_PRC: num(c.in.convPct), // mSG_PR[i,28] :13132
    /**
     * The line's rate basis, `'G'` on 78/78 captured rows.
     *
     * `PurchaseLineInput.rateType` existed and was accepted, but no `PR_DETL.RATE_TYPE` was ever written — so a
     * value the caller supplied was silently dropped. Distinct from `URD_RATE_TYPE` below (the unregistered-dealer
     * basis) and from `IT_RATE_TYPE` on the stone sub-detail.
     */
    RATE_TYPE: c.in.rateType ?? 'G',
    URD_RATE_TYPE: text(c.in.urdRateType).slice(0, 1) || null, // mSG_PR[i,30] :13137
    /**
     * Three flags the desktop writes as 'N' on every purchase line, and the builder wrote not at all.
     *
     * 78/78 in the retained capture. They are not inputs — no `designImgId` / `aprIsu` / `empIsu` exists on
     * `PurchaseLineInput` — so the form sets them, which means the builder must. The derived column-default spec
     * carries `''` for all three, which is its GLOBAL default across every PR_DETL row in the database; it cannot
     * express "a purchase line writes 'N'", so the value belongs here rather than in the spec.
     */
    DESIGN_IMG_ID: 'N',
    APR_ISU: 'N',
    EMP_ISU: 'N',
    ITM_OTH_RATE: num(c.in.otherRate), // mSG_PR[i,37] :13129
    ITM_MRP: num(c.in.mrp), // mSG_PR[i,39] :13139
    COMM_PRC: num(c.in.commissionPct), // mSG_PR[i,41] :13140
    COMM_AMT: round2(num(c.in.commissionAmount)), // mSG_PR[i,42] :13141
    FINE_CUT_PCS: num(c.in.fineCutPcs), // mSG_PR[i,60] :13189
    FINE_CUT_GWT: num(c.in.fineCutGrossWt), // mSG_PR[i,61] :13190
    FINE_CUT_NWT: num(c.in.fineCutNetWt), // mSG_PR[i,62] :13191
    FINE_CUT_FINE: num(c.in.fineCutFine), // mSG_PR[i,63] :13192
    PR_CODE: text(c.in.prCode).slice(0, 2) || null, // mSG_PR[i,64] :13147
    // Sale/consignment source linkage for TR_PURC and TR_PR_SL_UAE.
    SL_BILL_NO: linkedSource.vchNo || null, // tSlBill/tConsiNo.Text
    SL_BILL_LC: linkedSource.lcCode, // MLc_code
    SL_BILL_YRCD: linkedSource.coYear, // source fiscal year
    SL_BILL_DBCD: linkedSource.coBook || null, // tSlBill_DbCd/tConsiDbCd.Text
    CONSI_NO: text(c.in.consiNo ?? input.consiNo).slice(0, 10) || null, // mSG_PR[i,36] :8278
    CONSI_YRCD: text(c.in.consiYrcd ?? input.consiYrcd).slice(0, 9) || null, // mSG_PR[i,37]
    CONSI_DBCD: text(c.in.consiDbcd ?? input.consiDbcd).slice(0, 3) || null, // mSG_PR[i,38]
    CONSI_SRNO: num(c.in.consiSrno), // mSG_PR[i,39]
    // Desktop writes these as literal blanks/zeros on the purchase book.
    ITM_SIZE: '', // literal :13106
    KR_NAME: '', // literal :13186
    MCX_RATE: 0, // literal :13133
    PRM_AMT: 0, // literal :13134
    PRM_DISC: 0, // literal :13135
    TAG_TOUCH: 0, // literal :13177
    TAG_WEST_PRC: 0, // literal :13178
    TAG_FINE: 0, // literal :13179
    TAG_LBR_PRC: 0, // literal :13180
    TAG_LBR_RATE: 0, // literal :13181
    TAG_LBR_AMT: 0, // literal :13182
    TAG_OTH_AMT: 0, // literal :13183
    TAG_COST: 0, // literal :13184
    TAG_MRP: 0, // literal :13185
  }));

  /**
   * Stone/diamond sub-detail (TR_PURC.cs:13211-13243). One row per sub-grid row, keyed by the
   * parent line's SR_NO plus ISR_NO. The desktop writes nothing when the sub-grid is empty.
   * PR_IDTL is already part of PURCHASE_WRITE_TABLES, so edit and delete reverse these rows.
   */
  const prIdtl = computed.flatMap((c, idx) =>
    (c.in.stones ?? []).map((stone, sIdx) => ({
      ...key,
      VCH_DATE: vchDate,
      VCH_TYPE: bookPolicy.vchType, // FormBookSname :13217
      INOUT_TYPE: bookPolicy.inout, // FormBookInOut :13218
      ENTRY_TYPE: 'P', // literal       :13219
      BOOK_NAME: bookPolicy.bookName, // FormMainBook  :13220
      AC_CODE: input.acCode, // tAcCode.Text  :13221
      SR_NO: idx + 1, // parent line   :13222
      ISR_NO: stone.isrNo ?? sIdx + 1, // [0]           :13223
      IT_CODE: text(stone.itCode).slice(0, 10) || null, // [1]  :13224
      DM_CODE: text(stone.dmCode).slice(0, 10) || null, // [3]  :13225
      DM_NAME: text(stone.dmName).slice(0, 50) || null, // [4]  :13226
      DM_COLOR: text(stone.dmColor).slice(0, 15) || null, // [5]  :13227
      DM_SIZE: text(stone.dmSize).slice(0, 15) || null, // [6]  :13228
      DM_ORIGIN: text(stone.dmOrigin).slice(0, 15) || null, // [7]  :13229
      DM_REMARK: text(stone.dmRemark).slice(0, 50) || null, // [8]  :13230
      DM_SFNO: text(stone.dmSfNo).slice(0, 15) || null, // [9]  :13231
      IT_PCS: num(stone.pcs), // [12] :13232
      IT_GWT: num(stone.grossWt), // [14] :13233
      IT_CON_PRC: num(stone.conPct), // [15] :13234
      IT_RATE_TYPE: text(stone.rateType).slice(0, 1) || null, // [16] :13235
      IT_RATE: num(stone.rate), // [17] :13236
      IT_AMT: round2(num(stone.amount)), // [18] :13237
      IT_LBR_RATE: num(stone.lbrRate), // [19] :13238
      IT_LBR_AMT: round2(num(stone.lbrAmount)), // [20] :13239
      IT_NET_AMT: round2(num(stone.netAmount)), // [21] :13240
      IT_CON_WT: num(stone.conWt), // [22] :13241
      IT_TYPE: text(stone.itType).slice(0, 1) || null, // [23] :13242
      // Karigar side of the same stone (the desktop's shared TblIdtl block). A job-work settlement
      // prices the stone portion from these columns.
      DM_LEB: text(stone.dmLeb).slice(0, 15) || null,
      IT_PCS_WT: num(stone.pcsWt),
      KR_WT: num(stone.karigarWt),
      KR_LESS_PRC: num(stone.karigarLessPct),
      KR_CON_PRC: num(stone.karigarConPct),
      KR_CON_WT: num(stone.karigarConWt),
      KR_RATE: num(stone.karigarRate),
      KR_AMT: num(stone.karigarAmount),
      KR_LBR_RATE: num(stone.karigarLabourRate),
      KR_LBR_AMT: num(stone.karigarLabourAmount),
      KR_NET_AMT: num(stone.karigarNetAmount),
      MAIN_USER: ctx.mainUser || null, // MainUser :13243
    })),
  );

  const barDetl = isPurchaseQuotation
    ? []
    : computed.flatMap((c, idx) => {
        if (!c.in.tagNo) return [];
        return [
          {
            ...key,
            SR_NO: idx + 1,
            OLD_SRNO: idx + 1,
            VCH_DATE: vchDate,
            VCH_TIME: sharedVoucherTime,
            VCH_TYPE: bookPolicy.vchType,
            INOUT_TYPE: 'I',
            ENTRY_TYPE: 'P',
            BOOK_NAME: bookPolicy.bookName,
            AC_CODE: input.acCode,
            MAIN_USER: ctx.mainUser || null,
            HD_VCH_NO: ctx.hdVchNo,
            TAG_NO: c.in.tagNo,
            VCH_SRNO: tagSrnos.get(idx) ?? 0,
            IT_CODE: c.in.itCode,
            ITM_PCS: num(c.in.pcs),
            ITM_GWT: num(c.in.grossWt),
            ITM_NWT: num(c.in.netWt),
            ITM_TOUCH: num(c.in.touch),
            ITM_WEST_PRC: num(c.in.westPct),
            ITM_FINE: c.calc.fine,
            ITM_RATE: num(c.in.rate),
            ITM_AMT: c.calc.metal,
            LBR_AMT: c.calc.labour,
            OTH_AMT: num(c.in.otherAmount),
            RATE_TYPE: c.in.metalAmount != null ? 'A' : 'P',
            IT_TYPE: itemTypeByItem[String(c.in.itCode ?? '').trim()],
            HM_ID: c.in.huid ?? null,
          },
        ];
      });
  const barIdtl = isPurchaseQuotation
    ? []
    : computed.flatMap((c, idx) => {
        if (!c.in.tagNo) return [];
        return [
          {
            ...key,
            SR_NO: idx + 1,
            ISR_NO: 1,
            VCH_DATE: vchDate,
            VCH_TYPE: bookPolicy.vchType,
            INOUT_TYPE: 'I',
            ENTRY_TYPE: 'P',
            BOOK_NAME: bookPolicy.bookName,
            AC_CODE: input.acCode,
            TAG_NO: c.in.tagNo,
            VCH_SRNO: tagSrnos.get(idx) ?? 0,
            IT_CODE: c.in.itCode,
            IT_TYPE: itemTypeByItem[String(c.in.itCode ?? '').trim()],
            IT_PCS: num(c.in.pcs),
            IT_GWT: num(c.in.grossWt),
            IT_RATE: num(c.in.rate),
            IT_AMT: c.calc.metal,
            IT_LBR_AMT: c.calc.labour,
            IT_NET_AMT: c.calc.net,
          },
        ];
      });

  const header = {
    ...key,
    /**
     * `''` when the operator supplied no bill number — NOT the voucher number.
     *
     * `BILL_NO` is `''` on all 51 captured purchase headers. Defaulting it to the voucher number invented a
     * supplier's bill reference that the supplier never issued, which is worse than a blank: a blank is honestly
     * unknown, whereas `00001` looks like a real document number in any report or reconciliation that reads it.
     */
    BILL_NO: input.billNo ?? '',
    /**
     * The sale-bill back-reference scope and the audit flags, all constant across the captured headers:
     * `SL_BILL_LC` = the company's location (`'00'`, 51/51), `SL_BILL_YRCD` = its year (`'2024-2025'`, 51/51),
     * and `USER_UPDATE` / `USER_DELETE` = `'N'` (51/51 each). The detail builder already writes the first two
     * (`:13170`, `:13171`); the header was omitting them.
     */
    SL_BILL_NO: linkedSource.vchNo || null,
    SL_BILL_LC: linkedSource.lcCode,
    SL_BILL_YRCD: linkedSource.coYear,
    SL_BILL_DBCD: linkedSource.coBook || null,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    AC_CODE: input.acCode,
    AC_NAME: supplierName || null,
    VCH_DATE: vchDate,
    // TR_PURC.cs:12134-12135,12234,13051,13066,13148,13173 preserve identity on rewrite.
    VCH_TIME: sharedVoucherTime,
    HD_VCH_NO: ctx.hdVchNo,
    MAIN_USER: ctx.mainUser || null,
    IT_TYPE: itemTypeByItem[String(computed[0]?.in.itCode ?? '').trim()] ?? 'G',
    /**
     * The party's metal position moves only when the metal came in UNPRICED.
     *
     * Measured 51/51 on the captured headers: `PARTY_FINE` is non-zero exactly when every line carries
     * `ITM_RATE = 0`, and zero whenever a rate was fixed. The same selector produces the metal day-book row, and
     * for the same reason — metal bought at an agreed price is settled in money, so nothing is owed in metal.
     *
     * The web summed the fine unconditionally, so every priced purchase also credited the supplier a metal
     * balance. That is not a display difference: it is a metal liability the shop does not owe, and it would show
     * in the party's gold position.
     */
    PARTY_FINE: computed.every((row) => !num(row.in.rate))
      ? round3(computed.reduce((sum, row) => sum + row.calc.fine, 0))
      : 0,
    LBR_AMT: round2(computed.reduce((sum, row) => sum + row.calc.labour, 0)),
    OTH_AMT: round2(computed.reduce((sum, row) => sum + num(row.in.otherAmount), 0)),
    NET_AMT: totals.net,
    DISC_AMT: totals.discount,
    TAX_PRC: taxPct,
    TAX_CODE: taxPolicy.taxCode,
    AC_GST_TYPE: taxPolicy.accountGstType,
    TAX_AMT: totals.tax,
    CGST_TAX: totals.cgst,
    SGST_TAX: totals.sgst,
    IGST_TAX: totals.igst,
    ROF_AMT: totals.roundOff,
    TOT_AMT: grandTotal,
    RATE_UNFIX: input.rateUnfix ? 'Y' : 'N',
    // Desktop PR_DATA header columns (TR_PURC.cs:12982-13056). Party address/bank/cheque come from
    // the header fields, TDS/TCS from the settlement grid MSG2_TOTAL rows 3-4, and FX/OZ/metal-rate
    // are persisted as the desktop's literal zeros/blanks on this book.
    ADD1: text(input.address1).slice(0, 50) || null, // tAdd1.Text     :13017
    ADD2: text(input.address2).slice(0, 50) || null, // tAdd2.Text     :13018
    ADD3: text(input.address3).slice(0, 50) || null, // tAdd3.Text     :13019
    CITY: text(input.city).slice(0, 25) || null, // tCity.Text     :13020
    MOBILE: text(input.mobile).slice(0, 15) || null, // tMobile.Text   :13021
    BANK_NAME: text(input.bankName).slice(0, 50) || null, // tBankName.Text :13016
    CHQ_NO: text(input.chequeNo).slice(0, 20) || null, // MSG2_TOTAL[6,2]:13015
    CARD_AC: text(input.cardAc).slice(0, 10) || null, // MSG2_TOTAL[7,4]:13013
    CR_DAYS: num(input.creditDays), // nCrDays.Text   :13046
    DISC_PRC: num(input.discountPct), // MSG2_TOTAL[1,2]:12982
    TCS_CODE: text(input.tcsCode).slice(0, 10) || null, // MSG2_TOTAL[3,4]:12987
    TCS_PRC: num(input.tcsPct), // MSG2_TOTAL[3,2]:12988
    TCS_AMT: round2(num(input.tcsAmount)), // MSG2_TOTAL[3,3]:12989
    /**
     * `PR_TDS_TAX` — purchase TDS is persisted only when the company charges it (P4).
     *
     * The desktop exposes and writes these three columns only when `MsPrTdsTax = 'Y'` and otherwise
     * writes blank/zero explicitly (TR_PURC.cs:12160-12172, :12990-13003). The web wrote whatever the
     * request carried, and the screen always sent the fields, so a company with TDS switched off
     * still had TDS on its purchase vouchers.
     */
    TDS_CODE: behavior.purchaseTdsEnabled ? text(input.tdsCode).slice(0, 10) || null : null,
    TDS_PRC: behavior.purchaseTdsEnabled ? num(input.tdsPct) : 0,
    TDS_AMT: behavior.purchaseTdsEnabled ? round2(num(input.tdsAmount)) : 0,
    OZ_RATE: 0, // literal            :13052
    OZ_CONV: 0, // literal            :13053
    FX_RATE: 0, // literal            :13054
    FX_CODE: '', // literal            :13055
    MTL_RATE: 0, // literal            :13056
    ...(hmAmt > 0 ? { HM_AMT: hmAmt, HM_TAX_PRC: hmTaxPct, HM_TAX_AMT: hmTax } : {}),
  };

  const ledger = buildPurchaseLedger({
    key,
    acCode: input.acCode,
    purchaseAc,
    taxAc,
    roundAc,
    controlAc,
    vchType: bookPolicy.vchType,
    totals,
    expenseLegs,
  });
  if (hmAmt > 0) {
    const hb = { ...key, VCH_TYPE: bookPolicy.vchType };
    ledger.push({
      ...hb,
      AC_CODE: input.hmChargeAc ?? 'HMCHRG',
      LD_CODE: input.acCode,
      DR_AMT: hmAmt,
      CR_AMT: 0,
      SIGN: 'D',
    }); // Dr hallmark expense
    if (hmTax > 0)
      ledger.push({
        ...hb,
        AC_CODE: taxAc,
        LD_CODE: input.acCode,
        DR_AMT: hmTax,
        CR_AMT: 0,
        SIGN: 'D',
      }); // Dr input GST on HM
    ledger.push({
      ...hb,
      AC_CODE: input.acCode,
      LD_CODE: input.hmChargeAc ?? 'HMCHRG',
      DR_AMT: 0,
      CR_AMT: round2(hmAmt + hmTax),
      SIGN: 'C',
    }); // Cr supplier (HM owed)
  }
  assertBalanced(ledger); // money legs only — metal legs (DR=CR=0) are appended below and never unbalance it

  // Settlement/tender (F2 payoutLegs): pay the supplier now → Dr supplier / Cr cash|bank + kasar (discount received).
  // No tender ⇒ no legs ⇒ full payable (unchanged). Self-balanced pairs keep the ledger balanced.
  const tender = isPurchaseQuotation
    ? {
        cashAmt: round2(num(input.cashAmt)),
        paidNow: round2(
          num(input.cashAmt) + num(input.chequeAmt) + num(input.cardAmt) + num(input.upiAmt),
        ),
        kasar: round2(num(input.kasar)),
        legs: [] as LedgerLine[],
      }
    : payoutLegs(
        { ...key, VCH_TYPE: bookPolicy.vchType },
        {
          partyAc: input.acCode,
          cashAmt: input.cashAmt,
          chequeAmt: input.chequeAmt,
          cardAmt: input.cardAmt,
          upiAmt: input.upiAmt,
          kasar: input.kasar,
          cashAc,
          bankAc: input.bankAc,
          kasarAc,
          // Measured on books 035/036: the settlement pair is 16 party Dr / 17 cash Cr on 5 real vouchers. The
          // bank and kasar pairs are NOT passed - book 036's kasar pair is 18/19, but no bank settlement appears
          // in this dataset, so those stay on the reserved-band fallback until measured.
          legs: { cashParty: PURC_LEG.settleParty, cash: PURC_LEG.settleCash },
        },
      );
  if (!isPurchaseQuotation) ledger.push(...tender.legs);

  if (!isPurchaseQuotation) {
    ledger.push(
      ...buildPurchaseFineLedger({
        key,
        acCode: input.acCode,
        purchaseAc,
        vchType: bookPolicy.vchType,
        rateUnfix: input.rateUnfix,
        purcAcByItem,
        lines: computed.map((c) => ({
          itCode: c.in.itCode,
          metal: itemTypeByItem[String(c.in.itCode ?? '').trim()],
          fine: c.calc.fine,
          metalAmount: c.calc.metal,
          otherFineWt: c.in.otherFineWt,
          silverFineWt: c.in.silverFineWt,
        })),
      }),
    );
  }

  // Satellite tables the desktop TR_PURC also writes: tax register (input) + bill outstanding (payable).
  const r2 = (x: number): number => Math.round((x + 1e-9) * 100) / 100;
  const taxBase = {
    ...key,
    TRAN_TYPE: 'P',
    BOOK_NAME: bookPolicy.bookName,
    VCH_DATE: header.VCH_DATE,
    AC_CODE: input.acCode,
    PARTY_NAME: supplierName || null,
    NET_AMT: totals.taxable,
    DISC_AMT: totals.discount,
    TOT_AMT: totals.total,
    TAX_SIGN: '-',
    TAX_CODE: taxPolicy.taxCode,
  };
  const taxRows: Record<string, unknown>[] = [];
  if (totals.tax !== 0) {
    if (interState)
      taxRows.push({
        ...taxBase,
        SR_NO: 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: taxPct,
        TAX_AMT: totals.igst,
      });
    else {
      taxRows.push({
        ...taxBase,
        SR_NO: 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: r2(taxPct / 2),
        TAX_AMT: totals.cgst,
      });
      taxRows.push({
        ...taxBase,
        SR_NO: 2,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: r2(taxPct / 2),
        TAX_AMT: totals.sgst,
      });
    }
  }
  if (hmAmt > 0 && hmTax > 0) {
    const hmB = { ...taxBase, NET_AMT: hmAmt };
    if (interState)
      taxRows.push({
        ...hmB,
        SR_NO: taxRows.length + 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: hmTaxPct,
        TAX_AMT: hmIgst,
      });
    else {
      taxRows.push({
        ...hmB,
        SR_NO: taxRows.length + 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: r2(hmTaxPct / 2),
        TAX_AMT: hmCgst,
      });
      taxRows.push({
        ...hmB,
        SR_NO: taxRows.length + 1,
        TAX_TYPE: taxPolicy.taxGroup,
        TAX_PRC: r2(hmTaxPct / 2),
        TAX_AMT: hmSgst,
      });
    }
  }
  Object.assign(header, {
    CASH_AMT: tender.cashAmt,
    CHQ_AMT: round2(num(input.chequeAmt)),
    CARD_AMT: round2(num(input.cardAmt)),
    KASAR_AMT: tender.kasar,
    BILL_OS: round2(grandTotal - tender.paidNow - tender.kasar),
    BANK_AC: input.bankAc ?? null,
  });
  const osRow = {
    ...key,
    VCH_TYPE: bookPolicy.vchType,
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'N',
    BOOK_NAME: bookPolicy.bookName,
    SR_NO: 1,
    VCH_DATE: header.VCH_DATE,
    AC_CODE: input.acCode,
    BILL_AMT: grandTotal,
    REC_AMT: tender.paidNow,
    KASAR_AMT: tender.kasar,
  };
  // What the supplier is still owed after this voucher's own tender and write-off.
  const outstanding = round2(grandTotal - tender.paidNow - tender.kasar);

  // Every purchase detail moves stock; loose inventory uses TAG_NO=N/VCH_SRNO=0.
  const mainStock = computed.map((c, idx) => ({
    ...key,
    /**
     * MAIN_STOCK.SR_NO is 1 on a goods-received voucher, NOT a running line number. Measured over every
     * purchase-book row in the real database: 77 rows, all SR_NO=1, exactly one distinct value — including
     * multi-line vouchers, where a 3-line purchase writes 1,1,1 and a 4-line writes 1,1,1,1.
     *
     * The web wrote `idx + 1`, so every line after the first carried a serial the desktop never uses (27
     * field differences). This is the same shape as the ITM_QTY defect fixed in F4.1: a column the web
     * treats as a line ordinal that the desktop uses as a constant on transaction vouchers.
     *
     * Deliberately NOT generalised. The bulk stock books DO use SR_NO as a sequence — OPSTK reaches 108 and
     * TAG GEN 35 — and no single rule fits them: TAG GEN matches rank-within-voucher on 0 of 190 rows while
     * OPSTK matches on 1189 of 1241. Those paths are left alone because this dataset cannot settle them.
     */
    SR_NO: 1,
    VCH_DATE: header.VCH_DATE,
    /**
     * The desktop's own purchase stock rows, measured across all 77 in the retained capture, fix these eight
     * columns exactly. The web wrote none of them, which the 70-case comparison counted as 635 of its 3,813
     * field differences — the single largest block, and all of it one omission repeated per row.
     *
     *   ISR_NO      the LINE ORDINAL within the voucher: 1 row -> 1; 2 rows -> 1,2; 3 -> 1,2,3; 4 -> 1,2,3,4.
     *               77/77. This is the counterpart to the SR_NO finding recorded below: the desktop holds SR_NO
     *               constant at 1 on a goods-received voucher and uses ISR_NO for the ordinal, so the web had
     *               the two exactly the wrong way round.
     *   STK_DATE    equals VCH_DATE, 77/77.
     *   KR_NWT      equals ITM_NWT, 77/77.   KR_FINE equals ITM_FINE, 77/77.
     *   KR_TOUCH    equals ITM_TOUCH, 77/77. KR_WEST equals ITM_WEST, 77/77.
     *   EMP_CODE    '' on 77/77.             ITM_SIZE '' on 77/77.
     *
     * The KR_* group is not a coincidence: on a purchase the karigar-valuation columns carry the same weights as
     * the item itself, because the metal came in at that purity. Derived from the data rather than reasoned from
     * the C#, because the data is what the comparison is against.
     */
    ISR_NO: idx + 1,
    /**
     * A 10-character date STRING, not a Date.
     *
     * `MAIN_STOCK.STK_DATE` is `character varying` in this schema while the desktop's is `date` — the only such
     * divergence in 1,127 compared columns, so it is an isolated schema quirk rather than a systematic one. Every
     * other writer already accommodates it the same way (`vpParcel.ts:989`, `wholesaleSaleReturn.ts:979` and
     * `:1036`, `meltingPro.ts:347`, `stockVoucherLifecycle.ts:603`), and passing a Date instead stored a full
     * timestamp that differed from the desktop on all 79 rows.
     */
    STK_DATE: new Date(header.VCH_DATE as Date).toISOString().slice(0, 10),
    VCH_TYPE: bookPolicy.vchType,
    BOOK_NAME: bookPolicy.bookName,
    AC_CODE: input.acCode,
    IT_CODE: c.in.itCode,
    TAG_NO: c.in.tagNo ?? 'N',
    VCH_SRNO: tagSrnos.get(idx) ?? 0,
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: 1,
    ITM_PCS: num(c.in.pcs) || 1,
    ITM_GWT: num(c.in.grossWt),
    ITM_NWT: num(c.in.netWt),
    ITM_TOUCH: num(c.in.touch),
    ITM_WEST: num(c.in.westPct),
    ITM_FINE: c.calc.fine,
    ITM_RATE: num(c.in.rate),
    ITM_AMT: c.calc.metal,
    LBR_AMT: c.calc.labour,
    // Also carried on the desktop's stock row: 13 of 77 rows have a non-zero OTH_AMT and 5 a non-zero LBR_RATE,
    // so both are line values the builder simply was not passing on.
    LBR_RATE: num(c.in.labourRate),
    OTH_AMT: num(c.in.otherAmount),
    NET_AMT: c.calc.net,
    KR_NWT: num(c.in.netWt),
    KR_TOUCH: num(c.in.touch),
    KR_WEST: num(c.in.westPct),
    KR_FINE: c.calc.fine,
    EMP_CODE: '',
    ITM_SIZE: '',
  }));

  // TR_PURC.cs:12100,12108,12923,12927: hidden voucher evidence uses configured BOOK_DATA name.
  await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_BOOK: input.scope.coBook,
    VCH_NO: ctx.hdVchNo,
    BOOK_NAME: configuredBookName,
  });

  // TR_PURC shares TR_SALE_RTN's edit-audit block: one USER_DATA row per changed header column.
  if (ctx.isEdit && ctx.persistedHeader) {
    await recordFieldChangesTx(tx, tenantId, {
      key: {
        CO_CODE: String(key.CO_CODE),
        LC_CODE: String(key.LC_CODE),
        CO_YEAR: String(key.CO_YEAR),
        CO_BOOK: String(key.CO_BOOK),
        VCH_NO: String(key.VCH_NO),
      },
      acCode: input.acCode,
      vchDate,
      bookName: bookPolicy.bookName,
      originalUser: ctx.mainUser,
      editingUser: ctx.editingUser ?? input.mainUser ?? null,
      before: ctx.persistedHeader,
      after: header,
    });
  }

  if (isPurchaseQuotation) {
    await assertPeriodOpen(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      writes: [{ table: 'PR_DATA', rows: [header] }],
    });
    await insertRowTx(tx, 'PR_DATA', tenantId, header);
    for (const row of detl) await insertRowTx(tx, 'PR_DETL', tenantId, row);
    for (const row of prIdtl) await insertRowTx(tx, 'PR_IDTL', tenantId, row);
    return { vchNo, totals };
  }

  // The Rojmel, inward. A purchase is the mirror of a sale: metal comes IN (SIGN '+'), the expense
  // account is debited and the party credited. Confirmed against the real desktop database — books 035
  // and 037 (gold purchase) write IT_TYPE 'G' with SIGN '+', 036 and 038 (silver) write 'S' with '+',
  // against 'G'/'S' with '-' on the tax-invoice books.
  const rojmelRows = buildSaleRojmel(
    {
      scope: { coCode: input.scope.coCode, lcCode: input.scope.lcCode, coYear: key.CO_YEAR },
      key,
      coBook: key.CO_BOOK,
      vchNo: key.VCH_NO,
      vchDate,
      vchType: bookPolicy.vchType,
      bookName: bookPolicy.bookName,
      partyName: input.acName ?? '',
      partyCode: input.acCode,
    },
    computed.map((c, idx) => {
      const item = String(c.in.itCode ?? '').trim();
      return {
        lineNo: idx + 1,
        revenueAc: purcAcByItem[item] ?? purchaseAc,
        amount: c.calc.net,
        // A METAL ROJMEL ROW CARRIES ITS ITEM; A MONEY ROW NEVER DOES.
        //
        // Measured on the real Rojmel across the sale and purchase books: every IT_TYPE 'G'/'S' row has
        // IT_CODE set (240 rows, 0 blank) and every IT_TYPE 'A' money row has it blank (466 rows, 0 set). The
        // real purchase line rows carry '999' and 'ORG'; the web was writing them blank because this mapping
        // never passed the field - the sale caller does, so the builder itself was correct.
        itemCode: item,
        // The builder's field is `itemName` (it writes IT_DESC from it); `itemDesc` silently did nothing,
        // since the line type's optional fields make a typo a no-op rather than an error.
        itemName: itemNameByItem[item] ?? '',
        metal: rojmelMetalFor(itemTypeByItem[item]),
        pcs: num(c.in.pcs),
        grossWt: num(c.in.grossWt),
        netWt: num(c.in.netWt),
        /**
         * Touch, wastage and fine, which the metal day-book row exists to carry.
         *
         * The mapping stopped at gross and net, so the unpriced-metal row was written with `ITM_TOUCH`,
         * `ITM_WEST` and `ITM_FINE` all zero — the row's whole purpose is the fine weight it books against the
         * party, and it was booking nothing. Measured on the captured rows: `ITM_FINE` 7.917, `ITM_TOUCH` 92.000,
         * `ITM_WEST` 3.500 where the web wrote 0.
         */
        touch: num(c.in.touch),
        wastage: num(c.in.westPct),
        fine: c.calc.fine,
        rate: num(c.in.rate),
      };
    }),
    {
      taxAc,
      taxAmount: totals.tax,
      // THE PARTY ROJMEL ROW IS CONDITIONAL ON THE BILL BEING OUTSTANDING, and this argument is that
      // OUTSTANDING amount - buildSaleRojmel names its local `outstanding` - not the bill total.
      //
      // Family 1 measured the rule on the sale books: of 47 sales with BILL_OS = 0, ZERO carry a party row;
      // of 42 with BILL_OS <> 0, all 42 do. A settled bill leaves no receivable for a day book to show.
      // Passing `totals.total` made the condition always true, so every purchase got a party row.
      //
      // It reproduces on the real purchase books. Voucher 035/00001 pays 6780.00 cash against a 6780.00 bill
      // - BILL_OS 0 - and has ONE Rojmel row, the line row. Voucher 035/00003 leaves a balance and has three.
      // I first recorded that pair as a DESKTOP INCONSISTENCY, having compared them on line count and tender
      // without checking BILL_OS - the discriminator already measured and written into rojmel.ts in family 1.
      // Retracted here because "the desktop is inconsistent" ends investigation and invites an invented rule.
      partyAmount: round2(grandTotal - tender.paidNow - tender.kasar),
    },
    false, // inward: metal in, party credited
  );

  await postVoucherTx(tx, tenantId, {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: bookPolicy.bookName,
    // Lets the poster stamp PARTY_AC_CODE on the supplier's own leg only, which is the desktop's rule.
    partyAc: input.acCode,
    writes: [
      { table: 'PR_DATA', rows: [header] },
      { table: 'PR_DETL', rows: detl },
      ...(prIdtl.length ? [{ table: 'PR_IDTL', rows: prIdtl }] : []),
      ...(barDetl.length ? [{ table: 'BAR_DETL', rows: barDetl }] : []),
      ...(barIdtl.length ? [{ table: 'BAR_IDTL', rows: barIdtl }] : []),
      ...(mainStock.length ? [{ table: 'MAIN_STOCK', rows: mainStock }] : []),
      ...(taxRows.length ? [{ table: 'TAX_DATA', rows: taxRows }] : []),
      /**
       * The payable register row is written only when something is actually OUTSTANDING.
       *
       * The desktop writes no `BILL_OS_DATA` at all for any of the 51 captured purchases — every one is settled
       * in full at entry — yet the web wrote one unconditionally. A payable row for a bill that was paid on the
       * spot is not a cosmetic difference: it is a liability the business does not owe, and it appears in
       * outstanding and ageing reports as though it were real.
       */
      ...(outstanding > 0.005 ? [{ table: 'BILL_OS_DATA', rows: [osRow] }] : []),
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
    ],
  });

  // Lot register (LOT_DETL): desktop Ac_Stock.PrKr_Lot runs after the voucher rows exist and copies
  // them through the same joins (Ac_Stock.cs:624). Narrowed to this voucher so a save never rebuilds
  // the whole company register. LOT_DETL is in PURCHASE_WRITE_TABLES, so edit/delete reverse it.
  /**
   * Staged unconditionally, DELIBERATELY, despite the comparison reporting 78 lot rows the desktop did not have.
   *
   * A guard on "does any line name a lot" was written and then reverted, because it contradicts the desktop's own
   * source: `Ac_Stock.cs`'s `LOT_DETL` insert filters only on `MAIN_BOOK IN ('PURCHASE','B2B PURC')` and
   * `BOOK_INOUT = 'I'` — there is NO lot-number condition, so the desktop stages every purchase line.
   *
   * The captured data disagrees: none of the 51 purchase vouchers has a `LOT_DETL` row. The likely reconciliation
   * is that `PrKr_Lot` is a separate stock-posting pass rather than part of the voucher save — this module's own
   * comment says it "runs after the voucher rows exist" — so the capture may simply predate the pass for these
   * vouchers.
   *
   * Two readings, opposite conclusions, and no evidence here to settle which. Guessing would either invent lot
   * rows or suppress real ones, so the source is followed and the discrepancy is recorded instead.
   */
  await stagePurchaseLotDetailTx(
    tx,
    tenantId,
    {
      coCode: String(key.CO_CODE),
      lcCode: String(key.LC_CODE),
      coYear: String(key.CO_YEAR),
    },
    String(key.CO_BOOK),
    String(key.VCH_NO),
  );

  if (behavior.touchAutoSave) {
    // TR_BUL_SALE.cs:7684 and purchase equivalents persist party/item defaults in the voucher tx.
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

  return { vchNo, totals };
}

/** Create a purchase with independent main and hidden desktop voucher numbering. */
export async function createPurchase(
  prisma: any,
  input: PurchaseInput,
  lines: PurchaseLineInput[],
): Promise<PurchaseResult> {
  completePurchaseScope(input.scope);
  // Fail with the field name rather than a DecimalError 500 (see requirePurchaseNumber).
  input.taxRatePct = requirePurchaseNumber(input.taxRatePct, 'taxRatePct');
  const scope = input.scope;
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const isConsignmentPurchase = (await purchaseMainBookTx(tx, scope)) === 'CON PUR';
    let writeInput = input;
    let writeLines = lines;
    if (isConsignmentPurchase) {
      const normalized = normalizeConsignmentPurchaseInput(input, lines);
      await assertConsignmentPurchaseSourceOpenTx(tx, normalized.input, normalized.lines);
      writeInput = normalized.input;
      writeLines = normalized.lines;
    }
    // TR_PURC.cs:12911 allocates the main number from PR_DATA with year in scope.
    const vchNo = await nextVoucherNoTx(tx, scope);
    // TR_PURC.cs:12100,12108,12923,12927 allocate hidden numbering without fiscal year.
    const hdVchNo = await nextHiddenVoucherNoTx(tx, scope);
    const result = await writePurchaseTx(tx, writeInput, writeLines, {
      vchNo,
      hdVchNo,
      mainUser: String(writeInput.mainUser ?? '').trim(),
      persistedClock: undefined,
      isEdit: false,
    });
    if (isConsignmentPurchase) {
      await applyConsignmentPurchaseAdjustmentsTx(tx, scope, formatVoucherNo(result.vchNo), 1);
    }
    return result;
  });
}

/** Create a persisted TR_PURC `PR QUOT` voucher without ledger, tax, stock, rojmel, bill-OS or lot postings. */
export async function createPurchaseQuotation(
  prisma: any,
  input: PurchaseInput,
  lines: PurchaseLineInput[],
): Promise<PurchaseResult> {
  completePurchaseScope(input.scope);
  input.taxRatePct = requirePurchaseNumber(input.taxRatePct, 'taxRatePct');
  const scope = input.scope;
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertPurchaseMainBookTx(tx, scope, 'PR QUOT', 'purchase quotation');
    const vchNo = await nextVoucherNoTx(tx, scope);
    const hdVchNo = await nextHiddenVoucherNoTx(tx, scope);
    return writePurchaseTx(tx, input, lines, {
      vchNo,
      hdVchNo,
      mainUser: String(input.mainUser ?? '').trim(),
      persistedClock: undefined,
      isEdit: false,
      quoteMode: true,
    });
  });
}

export async function getPurchaseQuotation(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completePurchaseScope(scope);
  await withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertPurchaseMainBookTx(tx, scope, 'PR QUOT', 'purchase quotation');
  });
  return getPurchase(prisma, scope, requestedVoucherNo);
}

/** Replace a purchase quotation in-place, preserving the desktop hidden voucher identity. */
export async function editPurchaseQuotation(
  prisma: any,
  input: PurchaseInput,
  lines: PurchaseLineInput[],
  requestedVoucherNo: number | string,
): Promise<PurchaseResult> {
  completePurchaseScope(input.scope);
  input.taxRatePct = requirePurchaseNumber(input.taxRatePct, 'taxRatePct');
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertPurchaseMainBookTx(tx, scope, 'PR QUOT', 'purchase quotation');
    const persisted = await persistedPurchaseHeaderTx(tx, scope, voucherNo);
    const priorHeaderRow: Record<string, unknown> | undefined = (
      await tx.$queryRawUnsafe(
        `SELECT * FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
           AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
        ...purchaseParams(scope, voucherNo),
      )
    )[0];
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: {
        table: 'AC_DATA',
        lines: [{ CO_CODE: scope.coCode, VCH_DATE: persisted.VCH_DATE }],
      },
    });
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: requestedDate }] },
    });
    await deleteVoucherWriteSetTx(tx, {
      tables: PURCHASE_QUOTATION_WRITE_TABLES,
      key: { scope, voucherNo },
      tempBook: { voucherNo: formatVoucherNo(text(persisted.HD_VCH_NO)) },
    });
    return writePurchaseTx(tx, input, lines, {
      vchNo: Number(voucherNo),
      hdVchNo: formatVoucherNo(text(persisted.HD_VCH_NO)),
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
      isEdit: true,
      persistedHeader: priorHeaderRow,
      editingUser: input.mainUser ?? null,
      quoteMode: true,
    });
  });
}

export interface DeletePurchaseInput {
  scope: VoucherScope;
  vchNo: number | string;
  deleteUser?: string;
}

const PURCHASE_QUOTATION_WRITE_TABLES = ['PR_DATA', 'PR_DETL', 'PR_IDTL'] as const;

const PURCHASE_WRITE_TABLES = [
  'PR_DATA',
  'PR_DETL',
  'PR_IDTL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'SL_PR_DETL',
  'ITM_LOT_DETL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'LOT_DETL',
  'REMARK_DATA',
] as const;

type CompletePurchaseScope = VoucherScope & { coYear: string; coBook: string };
const text = (value: unknown): string => String(value ?? '').trim();
const purchaseParams = (scope: CompletePurchaseScope, voucherNo: string): unknown[] => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];

type PurchaseSourceLink = {
  vchNo: string;
  lcCode: string;
  coYear: string;
  coBook: string;
};

function purchaseLinkFromInput(input: PurchaseInput): PurchaseSourceLink {
  return {
    vchNo: text(input.consiNo || input.saleBillNo).slice(0, 10),
    lcCode: text(input.consiLcCode || input.saleBillLc || input.scope.lcCode).slice(0, 2),
    coYear: text(input.consiYrcd || input.saleBillYear || input.scope.coYear).slice(0, 10),
    coBook: text(input.consiDbcd || input.saleBillBook).slice(0, 3),
  };
}

async function purchaseMainBookTx(tx: any, scope: CompletePurchaseScope): Promise<string> {
  const rows: Array<{ MAIN_BOOK: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "MAIN_BOOK" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (rows.length !== 1) {
    throw new PurchaseValidationError(`purchase book configuration is ambiguous: ${scope.coBook}`);
  }
  return text(rows[0]?.MAIN_BOOK).toUpperCase();
}

async function assertPurchaseMainBookTx(
  tx: any,
  scope: CompletePurchaseScope,
  expectedMainBook: string,
  label: string,
): Promise<void> {
  const mainBook = await purchaseMainBookTx(tx, scope);
  if (mainBook !== expectedMainBook.toUpperCase()) {
    throw new PurchaseValidationError(
      `${label} requires BOOK_DATA.MAIN_BOOK='${expectedMainBook}' for book ${scope.coBook}`,
    );
  }
}

function normalizeConsignmentPurchaseInput(
  input: PurchaseInput,
  lines: PurchaseLineInput[],
): { input: PurchaseInput; lines: PurchaseLineInput[]; source: PurchaseSourceLink } {
  const source = purchaseLinkFromInput(input);
  if (!source.vchNo || !source.coYear || !source.coBook) {
    throw new PurchaseValidationError(
      'consignment purchase requires source consignment receipt no, year, and book',
    );
  }
  const normalizedLines = lines.map((line) => ({
    ...line,
    consiNo: text(line.consiNo || source.vchNo).slice(0, 10),
    consiYrcd: text(line.consiYrcd || source.coYear).slice(0, 9),
    consiDbcd: text(line.consiDbcd || source.coBook).slice(0, 3),
    consiSrno: num(line.consiSrno),
  }));
  const missingLine = normalizedLines.find(
    (line) => !line.consiNo || !line.consiYrcd || !line.consiDbcd || !line.consiSrno,
  );
  if (missingLine) {
    throw new PurchaseValidationError(
      'each consignment purchase line requires a source line serial',
    );
  }
  return {
    input: {
      ...input,
      consiNo: source.vchNo,
      consiLcCode: source.lcCode,
      consiYrcd: source.coYear,
      consiDbcd: source.coBook,
    },
    lines: normalizedLines,
    source,
  };
}

async function assertConsignmentPurchaseSourceOpenTx(
  tx: any,
  input: PurchaseInput,
  lines: PurchaseLineInput[],
): Promise<void> {
  const normalized = normalizeConsignmentPurchaseInput(input, lines);
  const source = normalized.source;
  const srnos = [
    ...new Set(normalized.lines.map((line) => num(line.consiSrno)).filter((n) => n > 0)),
  ];
  const rows: Array<{ OLD_SRNO: unknown; CON_ISU_REC: unknown; MAIN_BOOK: unknown }> =
    await tx.$queryRawUnsafe(
      `SELECT a."OLD_SRNO",a."CON_ISU_REC",d."MAIN_BOOK"
         FROM "APR_DETL" a
         JOIN "BOOK_DATA" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE"
          AND d."LC_CODE"=a."LC_CODE" AND d."CO_BOOK"=a."CO_BOOK"
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
          AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5 AND a."VCH_NO"=$6
          AND coalesce(a."OLD_SRNO",0)::numeric = ANY($7::numeric[])
          AND d."MAIN_BOOK"='CON REC'
        ORDER BY a."OLD_SRNO" FOR UPDATE OF a`,
      input.scope.tenantId,
      input.scope.coCode,
      source.lcCode,
      source.coYear,
      source.coBook,
      source.vchNo,
      srnos,
    );
  const found = new Set(rows.map((row) => num(row.OLD_SRNO)));
  const missing = srnos.filter((srno) => !found.has(srno));
  if (missing.length) {
    throw new PurchaseValidationError(
      `consignment receipt line not found or not a CON REC source: ${missing.join(', ')}`,
    );
  }
  const closed = rows.filter((row) => text(row.CON_ISU_REC).toUpperCase() === 'Y');
  if (closed.length) {
    throw new PurchaseValidationError(
      `consignment receipt line already purchased: ${closed.map((row) => num(row.OLD_SRNO)).join(', ')}`,
    );
  }
}

async function applyConsignmentPurchaseAdjustmentsTx(
  tx: any,
  scope: CompletePurchaseScope,
  voucherNo: string,
  direction: 1 | -1,
): Promise<void> {
  const flag = direction > 0 ? 'Y' : 'N';
  await tx.$executeRawUnsafe(
    `WITH refs AS (
       SELECT "CONSI_YRCD","CONSI_DBCD","CONSI_NO","CONSI_SRNO",
              sum(coalesce("ITM_GWT",0))::double precision AS gwt,
              sum(coalesce("ITM_NWT",0))::double precision AS nwt
         FROM "PR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6
          AND nullif(btrim(coalesce("CONSI_NO"::text,'')),'') IS NOT NULL
        GROUP BY "CONSI_YRCD","CONSI_DBCD","CONSI_NO","CONSI_SRNO"
     )
     UPDATE "APR_DETL" a
        SET "ADJ_GWT"=coalesce(a."ADJ_GWT",0)::double precision + ($7::double precision * refs.gwt),
            "ADJ_NWT"=coalesce(a."ADJ_NWT",0)::double precision + ($7::double precision * refs.nwt),
            "CON_ISU_REC"=$8
       FROM refs
      WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
        AND a."CO_YEAR"=refs."CONSI_YRCD" AND a."CO_BOOK"=refs."CONSI_DBCD"
        AND a."VCH_NO"=refs."CONSI_NO" AND coalesce(a."OLD_SRNO",0)=coalesce(refs."CONSI_SRNO",0)`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
    direction,
    flag,
  );
}

async function persistedPurchaseHeaderTx(
  tx: any,
  scope: CompletePurchaseScope,
  voucherNo: string,
  extraColumns: readonly string[] = [],
): Promise<Record<string, unknown>> {
  try {
    return await persistedVoucherHeaderTx(tx, {
      table: 'PR_DATA',
      scope,
      voucherNo,
      extraColumns,
    });
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new PurchaseValidationError(`purchase voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new PurchaseValidationError(`purchase voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
}

/**
 * Reject removal/rewrite when a tag created by this purchase was consumed by another voucher.
 *
 * Also RETURNS the persisted tag serials it read, keyed by tag number. It already reads and locks exactly the
 * rows the writer needs in order to keep each tag's identity across an edit; returning them costs nothing and
 * discarding them was the cause of the identity moving on an unchanged save (WP-08).
 */
async function assertPurchaseTagsUnconsumedTx(
  tx: any,
  scope: CompletePurchaseScope,
  voucherNo: string,
  action: 'edited' | 'deleted',
): Promise<Map<string, number>> {
  const tags: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAG_NO","VCH_SRNO","IT_CODE" FROM "BAR_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND NULLIF(btrim(coalesce("TAG_NO"::text,'')),'') IS NOT NULL
        AND "TAG_NO"::text <> 'N' ORDER BY "TAG_NO","VCH_SRNO","IT_CODE" FOR UPDATE`,
    ...purchaseParams(scope, voucherNo),
  );
  for (const tag of tags) {
    // Serialize with issueTagTx so a concurrent sale cannot pass this check and commit after the
    // purchase source rows have been replaced or deleted.
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `tag-issue|${scope.coCode}|${scope.lcCode}|${text(tag.TAG_NO)}`,
    );
    const issued: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"::text=$4
          AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
          AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'')
          AND "ITM_SIGN"::text='-'
          AND NOT (coalesce("CO_YEAR"::text,'')=$7 AND coalesce("CO_BOOK"::text,'')=$8
                   AND coalesce("VCH_NO"::text,'')=$9)`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      text(tag.TAG_NO),
      tag.VCH_SRNO ?? 0,
      tag.IT_CODE ?? '',
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (Number(issued[0]?.n ?? 0) > 0) {
      throw new PurchaseValidationError(
        `tag already issued and purchase cannot be ${action}: ${text(tag.TAG_NO)}`,
      );
    }
  }
  // Keyed by tag number for the writer. A tag number appearing twice in the persisted set would make the
  // identity ambiguous, so the FIRST is kept and the caller allocates a fresh serial for any further line —
  // never two lines sharing one serial.
  const persistedTagSrnos = new Map<string, number>();
  for (const tag of tags) {
    const tagNo = text(tag.TAG_NO);
    if (!tagNo || persistedTagSrnos.has(tagNo)) continue;
    persistedTagSrnos.set(tagNo, Number(tag.VCH_SRNO ?? 0));
  }
  return persistedTagSrnos;
}

/** Restore desktop approval/order source flags before BAR_DETL is removed. */
async function releasePurchaseReferencesTx(
  tx: any,
  scope: CompletePurchaseScope,
  voucherNo: string,
): Promise<void> {
  const params = purchaseParams(scope, voucherNo);
  await tx.$executeRawUnsafe(
    `UPDATE "APR_DETL" a SET "ISU_REC"='N' FROM "BAR_DETL" b
      WHERE a.tenant_id=$1 AND b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3
        AND b."CO_YEAR"=$4 AND b."CO_BOOK"=$5 AND b."VCH_NO"=$6
        AND a."CO_CODE"=b."CO_CODE" AND a."LC_CODE"=b."ORD_LC_CODE"
        AND a."ISU_YRCD"=b."ORD_YRCD" AND a."ISU_DBCD"=b."ORD_DBCD"
        AND a."ISU_NO"=b."ORD_NO" AND coalesce(a."ISU_SRNO",0)=coalesce(b."ORD_SRNO",0)`,
    ...params,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "SL_ORD_DETL" o SET "TAG_GEN"='N' FROM "BAR_DETL" b
      WHERE o.tenant_id=$1 AND b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3
        AND b."CO_YEAR"=$4 AND b."CO_BOOK"=$5 AND b."VCH_NO"=$6
        AND o."CO_CODE"=b."CO_CODE" AND o."LC_CODE"=b."ORD_LC_CODE"
        AND o."CO_YEAR"=b."ORD_YRCD" AND o."CO_BOOK"=b."ORD_DBCD"
        AND o."VCH_NO"=b."ORD_NO" AND coalesce(o."OLD_SRNO",0)=coalesce(b."ORD_SRNO",0)`,
    ...params,
  );
}

/** Open a persisted purchase by voucher number using server-derived tenant scope only. */
export async function getPurchase(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completePurchaseScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const params = purchaseParams(scope, voucherNo);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","BILL_NO","HD_VCH_NO","MAIN_USER",
               "AC_CODE","AC_NAME","NET_AMT","DISC_AMT","TAX_CODE","TAX_PRC","TAX_AMT",
               "AC_GST_TYPE","CGST_TAX","SGST_TAX","IGST_TAX","ROF_AMT","TOT_AMT",
               "RATE_UNFIX","CASH_AMT","CARD_AMT","CHQ_AMT","KASAR_AMT","BILL_OS",
               "BANK_AC","HM_AMT","HM_TAX_PRC","HM_TAX_AMT","IT_TYPE","PARTY_FINE","VCH_DESC",
               "SL_BILL_NO","SL_BILL_LC","SL_BILL_YRCD","SL_BILL_DBCD"
          FROM "PR_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...params,
    );
    if (headers.length !== 1) {
      throw new PurchaseValidationError(
        headers.length
          ? `purchase voucher is ambiguous: ${voucherNo}`
          : `purchase voucher not found: ${voucherNo}`,
      );
    }
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","IT_TYPE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT",
              "ITM_NWT","ITM_TOUCH","ITM_GHT_WT","ITM_WEST_PRC","ITM_FINE",
              "ITM_OTH_FINE","SILVER_FINE","ITM_RATE","ITM_AMT","LBR_TYPE","LBR_PRC",
               "LBR_RATE","LBR_AMT","OTH_AMT","NET_AMT","HM_ID",
               -- WP-08: selecting a column is half the job; the mapping below must read it. Both halves
               -- were missing for these, so an unchanged save wiped them.
               "DESIGN_NO","TBL_CODE","IT_DESC","BAG_WT","ITM_MRP","ITM_OTH_RATE","COMM_PRC","ITM_OTH_WT",
               "SL_BILL_NO","SL_BILL_LC","SL_BILL_YRCD","SL_BILL_DBCD",
               "CONSI_NO","CONSI_YRCD","CONSI_DBCD","CONSI_SRNO"
          FROM "PR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params,
    );
    const tags: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","IT_TYPE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT",
              "ITM_NWT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","ITM_AMT",
              "LBR_AMT","OTH_AMT","HM_ID"
         FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params,
    );
    /**
     * Stone sub-detail (`PR_IDTL`). Selected AND mapped, because the writer persists these rows
     * (`:953`) and `PR_IDTL` is in `PURCHASE_WRITE_TABLES`, so an edit deletes and rebuilds them
     * from its input. A reader that omitted them meant a reopen-and-save silently destroyed every
     * stone on the voucher — the same defect class WP-08 found on `BAR_DETL`, where an unchanged
     * save wiped 43 of 109 columns. Asserted by the sub-detail case in
     * `test/operatorDepth.roundtrip.db.test.ts`.
     */
    const stoneRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","ISR_NO","IT_CODE","DM_CODE","DM_NAME","DM_COLOR","DM_SIZE","DM_ORIGIN",
              "DM_REMARK","DM_SFNO","IT_PCS","IT_GWT","IT_PCS_WT","IT_CON_PRC","IT_CON_WT",
              "IT_RATE_TYPE","IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT","IT_TYPE",
              "KR_WT","KR_LESS_PRC","KR_CON_PRC","KR_CON_WT","KR_RATE","KR_AMT","KR_LBR_RATE",
              "KR_LBR_AMT","KR_NET_AMT"
         FROM "PR_IDTL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO","ISR_NO"`,
      ...params,
    );
    const stonesBySrNo = new Map<number, Array<Record<string, unknown>>>();
    for (const row of stoneRows) {
      const srNo = num(row.SR_NO);
      const list = stonesBySrNo.get(srNo) ?? [];
      list.push({
        isrNo: num(row.ISR_NO),
        itCode: text(row.IT_CODE),
        dmCode: text(row.DM_CODE),
        dmName: text(row.DM_NAME),
        dmColor: text(row.DM_COLOR),
        dmSize: text(row.DM_SIZE),
        dmOrigin: text(row.DM_ORIGIN),
        dmRemark: text(row.DM_REMARK),
        dmSfNo: text(row.DM_SFNO),
        pcs: num(row.IT_PCS),
        grossWt: num(row.IT_GWT),
        pcsWt: num(row.IT_PCS_WT),
        conPct: num(row.IT_CON_PRC),
        conWt: num(row.IT_CON_WT),
        rateType: text(row.IT_RATE_TYPE),
        rate: num(row.IT_RATE),
        amount: num(row.IT_AMT),
        lbrRate: num(row.IT_LBR_RATE),
        lbrAmount: num(row.IT_LBR_AMT),
        netAmount: num(row.IT_NET_AMT),
        itType: text(row.IT_TYPE),
        karigarWt: num(row.KR_WT),
        karigarLessPct: num(row.KR_LESS_PRC),
        karigarConPct: num(row.KR_CON_PRC),
        karigarConWt: num(row.KR_CON_WT),
        karigarRate: num(row.KR_RATE),
        karigarAmount: num(row.KR_AMT),
        karigarLabourRate: num(row.KR_LBR_RATE),
        karigarLabourAmount: num(row.KR_LBR_AMT),
        karigarNetAmount: num(row.KR_NET_AMT),
      });
      stonesBySrNo.set(srNo, list);
    }
    const h = headers[0]!;
    const labourType = (value: unknown): LabourType | undefined =>
      legacyLabourModeFor(value) as LabourType | undefined;
    return {
      voucherNo: text(h.VCH_NO),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: text(h.VCH_DATE).slice(0, 10),
      billNo: text(h.BILL_NO),
      saleBillNo: text(h.SL_BILL_NO),
      saleBillLc: text(h.SL_BILL_LC),
      saleBillYear: text(h.SL_BILL_YRCD),
      saleBillBook: text(h.SL_BILL_DBCD),
      consiNo: text(h.SL_BILL_NO),
      consiLcCode: text(h.SL_BILL_LC),
      consiYrcd: text(h.SL_BILL_YRCD),
      consiDbcd: text(h.SL_BILL_DBCD),
      acCode: text(h.AC_CODE),
      acName: text(h.AC_NAME),
      taxCode: text(h.TAX_CODE),
      taxRatePct: num(h.TAX_PRC),
      interState: num(h.IGST_TAX) !== 0 || text(h.AC_GST_TYPE).toUpperCase() !== 'L',
      urd: num(h.TAX_PRC) === 0 && num(h.TAX_AMT) === 0,
      discountAmount: num(h.DISC_AMT),
      rateUnfix: text(h.RATE_UNFIX).toUpperCase() === 'Y',
      cashAmt: num(h.CASH_AMT),
      cardAmt: num(h.CARD_AMT),
      upiAmt: 0,
      chequeAmt: num(h.CHQ_AMT),
      kasar: num(h.KASAR_AMT),
      billOutstanding: num(h.BILL_OS),
      bankAc: text(h.BANK_AC),
      hmAmount: num(h.HM_AMT),
      hmTaxPct: num(h.HM_TAX_PRC),
      hmTaxAmount: num(h.HM_TAX_AMT),
      metal: text(h.IT_TYPE) === 'S' ? 'S' : 'G',
      partyFine: num(h.PARTY_FINE),
      description: text(h.VCH_DESC),
      totals: {
        net: num(h.NET_AMT),
        discount: num(h.DISC_AMT),
        taxable: round2(num(h.NET_AMT) - num(h.DISC_AMT)),
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
        otherFineWt: num(row.ITM_OTH_FINE),
        silverFineWt: num(row.SILVER_FINE),
        rate: num(row.ITM_RATE),
        metalAmount: num(row.ITM_AMT),
        labourType: labourType(row.LBR_TYPE),
        labourPct: num(row.LBR_PRC),
        labourRate: num(row.LBR_RATE),
        labourFixed: text(row.LBR_TYPE) === 'N' ? num(row.LBR_AMT) : undefined,
        labourAmount: num(row.LBR_AMT),
        otherAmount: num(row.OTH_AMT),
        netAmount: num(row.NET_AMT),
        huid: text(row.HM_ID),
        // WP-08: descriptive and rate fields the writer persists and the reader used to drop. Because
        // `editPurchase` rebuilds PR_DETL from its input, an unchanged save wiped each of these — measured as
        // DESIGN_NO, TBL_CODE, IT_DESC and COMM_PRC to null/0, and BAG_WT, ITM_OTH_WT, ITM_MRP, ITM_OTH_RATE
        // to 0. Asserted by the round-trip test in purchase.lifecycle.db.test.ts.
        designNo: text(row.DESIGN_NO),
        tblCode: text(row.TBL_CODE),
        itDesc: text(row.IT_DESC),
        bagWt: num(row.BAG_WT),
        lessWt: num(row.ITM_OTH_WT),
        mrp: num(row.ITM_MRP),
        otherRate: num(row.ITM_OTH_RATE),
        commissionPct: num(row.COMM_PRC),
        saleBillNo: text(row.SL_BILL_NO),
        saleBillLc: text(row.SL_BILL_LC),
        saleBillYear: text(row.SL_BILL_YRCD),
        saleBillBook: text(row.SL_BILL_DBCD),
        consiNo: text(row.CONSI_NO),
        consiYrcd: text(row.CONSI_YRCD),
        consiDbcd: text(row.CONSI_DBCD),
        consiSrno: num(row.CONSI_SRNO),
        // Stone rows for this line, keyed by the parent SR_NO the writer used.
        stones: stonesBySrNo.get(num(row.SR_NO)) ?? [],
      })),
      tags: tags.map((row) => ({
        srNo: num(row.SR_NO),
        itCode: text(row.IT_CODE),
        metal: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
        tagNo: text(row.TAG_NO),
        vchSrno: num(row.VCH_SRNO),
        pcs: num(row.ITM_PCS),
        grossWt: num(row.ITM_GWT),
        netWt: num(row.ITM_NWT),
        touch: num(row.ITM_TOUCH),
        fineWt: num(row.ITM_FINE),
        rate: num(row.ITM_RATE),
        metalAmount: num(row.ITM_AMT),
        labourAmount: num(row.LBR_AMT),
        otherAmount: num(row.OTH_AMT),
        huid: text(row.HM_ID),
      })),
    };
  });
}

export interface ConsignmentReceiptFilter {
  sourceVchNo?: number | string;
  sourceCoYear?: string;
  sourceCoBook?: string;
}

export async function listOpenConsignmentPurchaseReceipts(
  prisma: any,
  scope: VoucherScope,
  filter: ConsignmentReceiptFilter = {},
): Promise<Record<string, unknown>> {
  completePurchaseScope(scope);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await assertPurchaseMainBookTx(tx, scope, 'CON PUR', 'consignment purchase');
    const sourceYear = text(filter.sourceCoYear || scope.coYear);
    const sourceBook = text(filter.sourceCoBook);
    const sourceVchNo = filter.sourceVchNo == null ? '' : formatVoucherNo(filter.sourceVchNo);

    const summaryParams: unknown[] = [scope.tenantId, scope.coCode, scope.lcCode, sourceYear];
    const summaryBookSql = sourceBook ? 'AND a."CO_BOOK"=$5' : '';
    if (sourceBook) summaryParams.push(sourceBook);
    const summaryRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."VCH_NO" AS "voucherNo",
              min(a."VCH_DATE"::text) AS "vchDate",
              min(a."AC_CODE"::text) AS "acCode",
              min(c."AC_NAME"::text) AS "acName",
              a."CO_YEAR" AS "coYear",
              a."CO_BOOK" AS "coBook",
              sum(coalesce(a."ITM_GWT",0))::float AS "grossWt",
              sum(coalesce(a."ADJ_GWT",0))::float AS "adjustGrossWt",
              sum(coalesce(a."ITM_GWT",0)-coalesce(a."ADJ_GWT",0))::float AS "balanceGrossWt",
              sum(coalesce(a."ITM_NWT",0))::float AS "netWt",
              sum(coalesce(a."ADJ_NWT",0))::float AS "adjustNetWt",
              sum(coalesce(a."ITM_NWT",0)-coalesce(a."ADJ_NWT",0))::float AS "balanceNetWt"
         FROM "APR_DETL" a
         JOIN "BOOK_DATA" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE"
          AND d."LC_CODE"=a."LC_CODE" AND d."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN "AC_MAST" c ON c.tenant_id=a.tenant_id AND c."CO_CODE"=a."CO_CODE"
          AND c."LC_CODE"=a."LC_CODE" AND c."AC_CODE"=a."AC_CODE"
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
          AND a."CO_YEAR"=$4 ${summaryBookSql} AND d."MAIN_BOOK"='CON REC'
        GROUP BY a."VCH_NO",a."CO_YEAR",a."CO_BOOK"
       HAVING sum(coalesce(a."ITM_NWT",0)-coalesce(a."ADJ_NWT",0)) > 0
        ORDER BY a."VCH_NO"`,
      ...summaryParams,
    );
    const receipts = summaryRows.map((row) => ({
      voucherNo: text(row.voucherNo),
      vchDate: text(row.vchDate).slice(0, 10),
      acCode: text(row.acCode),
      acName: text(row.acName),
      coYear: text(row.coYear),
      coBook: text(row.coBook),
      grossWt: num(row.grossWt),
      adjustGrossWt: num(row.adjustGrossWt),
      balanceGrossWt: num(row.balanceGrossWt),
      netWt: num(row.netWt),
      adjustNetWt: num(row.adjustNetWt),
      balanceNetWt: num(row.balanceNetWt),
    }));
    if (!sourceVchNo) return { receipts };

    const detailParams: unknown[] = [
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      sourceYear,
      sourceVchNo,
    ];
    const detailBookSql = sourceBook ? 'AND a."CO_BOOK"=$6' : '';
    if (sourceBook) detailParams.push(sourceBook);
    const sourceLines: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a.*,i."IT_NAME"
         FROM "APR_DETL" a
         JOIN "BOOK_DATA" d ON d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE"
          AND d."LC_CODE"=a."LC_CODE" AND d."CO_BOOK"=a."CO_BOOK"
         LEFT JOIN "ITEM_MAST" i ON i.tenant_id=a.tenant_id AND i."CO_CODE"=a."CO_CODE"
          AND i."IT_CODE"=a."IT_CODE"
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4
          AND a."VCH_NO"=$5 ${detailBookSql} AND d."MAIN_BOOK"='CON REC'
          AND coalesce(a."CON_ISU_REC",'N')='N'
        ORDER BY a."OLD_SRNO",a."SR_NO"`,
      ...detailParams,
    );
    if (!sourceLines.length) {
      throw new PurchaseValidationError(`no open consignment receipt lines found: ${sourceVchNo}`);
    }
    const actualSourceBook = text(sourceLines[0]?.CO_BOOK);
    const stoneRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","ISR_NO","IT_CODE","DM_CODE","DM_NAME","DM_COLOR","DM_SIZE","DM_ORIGIN",
              "DM_REMARK","DM_SFNO","IT_PCS","IT_GWT","IT_PCS_WT","IT_CON_PRC","IT_CON_WT",
              "IT_RATE_TYPE","IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT","IT_TYPE",
              "KR_WT","KR_LESS_PRC","KR_CON_PRC","KR_CON_WT","KR_RATE","KR_AMT","KR_LBR_RATE",
              "KR_LBR_AMT","KR_NET_AMT"
         FROM "APR_IDTL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO","ISR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      sourceYear,
      actualSourceBook,
      sourceVchNo,
    );
    const stonesBySrNo = new Map<number, Array<Record<string, unknown>>>();
    for (const row of stoneRows) {
      const srNo = num(row.SR_NO);
      const list = stonesBySrNo.get(srNo) ?? [];
      list.push({
        isrNo: num(row.ISR_NO),
        itCode: text(row.IT_CODE),
        dmCode: text(row.DM_CODE),
        dmName: text(row.DM_NAME),
        dmColor: text(row.DM_COLOR),
        dmSize: text(row.DM_SIZE),
        dmOrigin: text(row.DM_ORIGIN),
        dmRemark: text(row.DM_REMARK),
        dmSfNo: text(row.DM_SFNO),
        pcs: num(row.IT_PCS),
        grossWt: num(row.IT_GWT),
        pcsWt: num(row.IT_PCS_WT),
        conPct: num(row.IT_CON_PRC),
        conWt: num(row.IT_CON_WT),
        rateType: text(row.IT_RATE_TYPE),
        rate: num(row.IT_RATE),
        amount: num(row.IT_AMT),
        lbrRate: num(row.IT_LBR_RATE),
        lbrAmount: num(row.IT_LBR_AMT),
        netAmount: num(row.IT_NET_AMT),
        itType: text(row.IT_TYPE),
        karigarWt: num(row.KR_WT),
        karigarLessPct: num(row.KR_LESS_PRC),
        karigarConPct: num(row.KR_CON_PRC),
        karigarConWt: num(row.KR_CON_WT),
        karigarRate: num(row.KR_RATE),
        karigarAmount: num(row.KR_AMT),
        karigarLabourRate: num(row.KR_LBR_RATE),
        karigarLabourAmount: num(row.KR_LBR_AMT),
        karigarNetAmount: num(row.KR_NET_AMT),
      });
      stonesBySrNo.set(srNo, list);
    }
    const first = sourceLines[0]!;
    const source = {
      voucherNo: sourceVchNo,
      coYear: sourceYear,
      coBook: actualSourceBook,
      acCode: text(first.AC_CODE),
      acName:
        receipts.find((r) => r.voucherNo === sourceVchNo && r.coBook === actualSourceBook)
          ?.acName ?? '',
    };
    return {
      source,
      lines: sourceLines.map((row) => {
        const sourceSrNo = num(row.OLD_SRNO) || num(row.SR_NO);
        return {
          itCode: text(row.IT_CODE),
          itDesc: text(row.IT_NAME),
          tagNo: text(row.TAG_NO) === 'N' ? '' : text(row.TAG_NO),
          pcs: num(row.ITM_PCS),
          grossWt: num(row.ITM_GWT),
          netWt: num(row.ITM_NWT),
          touch: num(row.ITM_TOUCH),
          ghtWt: num(row.ITM_GHT_WT),
          westPct: num(row.ITM_WEST_PRC),
          fineWt: num(row.ITM_FINE),
          rate: num(row.ITM_RATE),
          metalAmount: num(row.ITM_AMT),
          labourPct: num(row.LBR_PRC),
          labourRate: num(row.LBR_RATE),
          labourAmount: num(row.LBR_AMT),
          otherAmount: num(row.OTH_AMT),
          tblCode: text(row.TBL_CODE),
          designNo: text(row.DESIGN_NO),
          lotNo: text(row.LOT_NO),
          bagWt: num(row.BAG_WT),
          lessWt: num(row.ITM_OTH_WT),
          lossWt: num(row.ITM_LOSS_WT),
          mrp: num(row.ITM_MRP),
          rateType: text(row.RATE_TYPE) || 'G',
          metal: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
          prCode: text(row.PR_CODE),
          consiNo: sourceVchNo,
          consiYrcd: sourceYear,
          consiDbcd: actualSourceBook,
          consiSrno: sourceSrNo,
          stones: stonesBySrNo.get(num(row.SR_NO)) ?? [],
        };
      }),
    };
  });
}

/** Replace a purchase in-place, preserving desktop header identity and audit-free edit semantics. */
export async function editPurchase(
  prisma: any,
  input: PurchaseInput,
  lines: PurchaseLineInput[],
  requestedVoucherNo: number | string,
): Promise<PurchaseResult> {
  completePurchaseScope(input.scope);
  // Fail with the field name rather than a DecimalError 500 (see requirePurchaseNumber).
  input.taxRatePct = requirePurchaseNumber(input.taxRatePct, 'taxRatePct');
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const isConsignmentPurchase = (await purchaseMainBookTx(tx, scope)) === 'CON PUR';
    const persisted = await persistedPurchaseHeaderTx(tx, scope, voucherNo, ['SL_BILL_NO']);
    // Full prior header for the USER_DATA edit audit, read BEFORE the write set is replaced.
    const priorHeaderRow: Record<string, unknown> | undefined = (
      await tx.$queryRawUnsafe(
        `SELECT * FROM "PR_DATA" WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3
           AND "CO_BOOK"=$4 AND "VCH_NO"=$5 LIMIT 1`,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      )
    )[0];
    // TR_PURC.cs `ItCodeLock`: a line that already produced a tag has its item code frozen, because the
    // tag is in stock under that item. Compared against the PERSISTED detail rows, never the request.
    const priorLines: Array<{ SR_NO: unknown; IT_CODE: unknown; TAG_NO: unknown }> =
      await tx.$queryRawUnsafe(
        `SELECT "SR_NO","IT_CODE","TAG_NO" FROM "PR_DETL"
           WHERE "CO_CODE"=$1 AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5
           ORDER BY "SR_NO"`,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
    for (const prior of priorLines) {
      const tagNo = String(prior.TAG_NO ?? '').trim();
      if (!tagNo || tagNo === 'N') continue; // untagged lines may still change item
      const srNo = Number(prior.SR_NO);
      const incoming = lines[srNo - 1];
      if (!incoming) continue;
      const before = String(prior.IT_CODE ?? '').trim();
      const after = String(incoming.itCode ?? '').trim();
      if (after && before && after !== before) {
        throw new PurchaseValidationError(DESKTOP_MESSAGES.ITEM_CODE_LOCKED_IN_EDIT);
      }
    }

    // Fail closed before any source flags or voucher rows move: both old and requested dates matter.
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: {
        table: 'AC_DATA',
        lines: [{ CO_CODE: scope.coCode, VCH_DATE: persisted.VCH_DATE }],
      },
    });
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: requestedDate }] },
    });
    if (text(persisted.SL_BILL_NO) && !isConsignmentPurchase) {
      throw new PurchaseValidationError('purchase is linked to a sale bill and cannot be edited');
    }

    const persistedTagSrnos = await assertPurchaseTagsUnconsumedTx(tx, scope, voucherNo, 'edited');
    const hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    await releasePurchaseReferencesTx(tx, scope, voucherNo);
    let writeInput = input;
    let writeLines = lines;
    if (isConsignmentPurchase) {
      await applyConsignmentPurchaseAdjustmentsTx(tx, scope, voucherNo, -1);
      const normalized = normalizeConsignmentPurchaseInput(input, lines);
      await assertConsignmentPurchaseSourceOpenTx(tx, normalized.input, normalized.lines);
      writeInput = normalized.input;
      writeLines = normalized.lines;
    }
    // TR_PURC.cs:12939-12944,13252,13297-13299,13548 replaces the full write set and temp row.
    // Desktop edit never writes DELETE_DATA.
    await deleteVoucherWriteSetTx(tx, {
      tables: PURCHASE_WRITE_TABLES,
      key: { scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
    // TR_PURC.cs:12134-12135,12234,13051,13066,13148,13173 preserve no/user/clock.
    const result = await writePurchaseTx(tx, writeInput, writeLines, {
      vchNo: Number(voucherNo),
      hdVchNo: hiddenVoucherNo,
      mainUser: text(persisted.MAIN_USER),
      persistedClock: persisted.VCH_CLOCK,
      isEdit: true,
      // Desktop compares the FULL reloaded header (SELECT * FROM PR_DATA); the projection used for
      // identity is too narrow to diff against.
      persistedHeader: priorHeaderRow,
      editingUser: input.mainUser ?? null,
      // Keeps each tag's identity across the rewrite; see WritePurchaseContext.persistedTagSrnos.
      persistedTagSrnos,
    });
    if (isConsignmentPurchase) {
      await applyConsignmentPurchaseAdjustmentsTx(tx, scope, voucherNo, 1);
    }
    return result;
  });
}

/** Reverse a purchase and write the desktop TR_PURC 1-header + N-detail DELETE_DATA audit. */
export async function deletePurchase(
  prisma: any,
  input: DeletePurchaseInput,
): Promise<{ reversed: true }> {
  completePurchaseScope(input.scope);
  const scope = input.scope;
  const tenantId = scope.tenantId;
  const voucherNo = formatVoucherNo(input.vchNo);
  const key = keyOf(scope, voucherNo);
  return withTenant(prisma, tenantId, async (tx: any) => {
    const isConsignmentPurchase = (await purchaseMainBookTx(tx, scope)) === 'CON PUR';
    const bookPolicy = await resolveBookPolicyTx(
      tx,
      scope,
      isConsignmentPurchase ? 'CONSIGNMENT PURCHASE' : 'PURCHASE',
    );
    const configuredBookName = await configuredPurchaseBookNameTx(tx, scope);
    const header = await persistedPurchaseHeaderTx(tx, scope, voucherNo, [
      'AC_CODE',
      'AC_NAME',
      'TOT_AMT',
      'CASH_AMT',
      'CARD_AMT',
      'CHQ_AMT',
      'IT_TYPE',
      'PARTY_FINE',
      'VCH_DESC',
      'SL_BILL_NO',
    ]);
    await assertPeriodOpen(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: header.VCH_DATE }] },
    });
    if (text(header.SL_BILL_NO) && !isConsignmentPurchase) {
      throw new PurchaseValidationError('purchase is linked to a sale bill and cannot be deleted');
    }
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","NET_AMT","IT_TYPE","ITM_FINE"
         FROM "PR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      ...purchaseParams(scope, voucherNo),
    );
    await assertPurchaseTagsUnconsumedTx(tx, scope, voucherNo, 'deleted');
    await releasePurchaseReferencesTx(tx, scope, voucherNo);
    if (isConsignmentPurchase) {
      await applyConsignmentPurchaseAdjustmentsTx(tx, scope, voucherNo, -1);
    }
    await reverseVoucherTx(tx, tenantId, { tables: [...PURCHASE_WRITE_TABLES], key });
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
    // TR_PURC.cs:13861: one header row; tender debit excludes UPI and description is 149 chars.
    await insertRowTx(tx, 'DELETE_DATA', tenantId, {
      ...common,
      SR_NO: 0,
      VCH_VAL_DR: round2(num(header.CASH_AMT) + num(header.CARD_AMT) + num(header.CHQ_AMT)),
      VCH_VAL_CR: num(header.TOT_AMT),
      FINE_TYPE: text(header.IT_TYPE),
      VCH_FINE_DR: 0,
      VCH_FINE_CR: num(header.PARTY_FINE),
      VCH_DESC: text(header.VCH_DESC).slice(0, 149),
    });
    // TR_PURC.cs:13863: one credit/fine audit row per PR_DETL line.
    for (const detail of details) {
      await insertRowTx(tx, 'DELETE_DATA', tenantId, {
        ...common,
        SR_NO: num(detail.SR_NO),
        VCH_VAL_DR: 0,
        VCH_VAL_CR: num(detail.NET_AMT),
        FINE_TYPE: text(detail.IT_TYPE),
        VCH_FINE_DR: 0,
        VCH_FINE_CR: num(detail.ITM_FINE),
        VCH_DESC: `ItCode/${text(detail.IT_CODE)}`.slice(0, 150),
      });
    }
    return { reversed: true };
  });
}

/** Delete a TR_PURC `PR QUOT` voucher and preserve the desktop delete audit trail. */
export async function deletePurchaseQuotation(
  prisma: any,
  input: DeletePurchaseInput,
): Promise<{ reversed: true }> {
  completePurchaseScope(input.scope);
  const scope = input.scope;
  const tenantId = scope.tenantId;
  const voucherNo = formatVoucherNo(input.vchNo);
  const key = keyOf(scope, voucherNo);
  return withTenant(prisma, tenantId, async (tx: any) => {
    await assertPurchaseMainBookTx(tx, scope, 'PR QUOT', 'purchase quotation');
    const bookPolicy = await resolveBookPolicyTx(tx, scope, 'PURCHASE QUOTATION');
    const configuredBookName = await configuredPurchaseBookNameTx(tx, scope);
    const header = await persistedPurchaseHeaderTx(tx, scope, voucherNo, [
      'AC_CODE',
      'AC_NAME',
      'TOT_AMT',
      'CASH_AMT',
      'CARD_AMT',
      'CHQ_AMT',
      'IT_TYPE',
      'PARTY_FINE',
      'VCH_DESC',
    ]);
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","NET_AMT","IT_TYPE","ITM_FINE"
         FROM "PR_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      ...purchaseParams(scope, voucherNo),
    );
    await reverseVoucherTx(tx, tenantId, {
      tables: [...PURCHASE_QUOTATION_WRITE_TABLES],
      key,
    });
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
    await insertRowTx(tx, 'DELETE_DATA', tenantId, {
      ...common,
      SR_NO: 0,
      VCH_VAL_DR: round2(num(header.CASH_AMT) + num(header.CARD_AMT) + num(header.CHQ_AMT)),
      VCH_VAL_CR: num(header.TOT_AMT),
      FINE_TYPE: text(header.IT_TYPE),
      VCH_FINE_DR: 0,
      VCH_FINE_CR: num(header.PARTY_FINE),
      VCH_DESC: text(header.VCH_DESC).slice(0, 149),
    });
    for (const detail of details) {
      await insertRowTx(tx, 'DELETE_DATA', tenantId, {
        ...common,
        SR_NO: num(detail.SR_NO),
        VCH_VAL_DR: 0,
        VCH_VAL_CR: num(detail.NET_AMT),
        FINE_TYPE: text(detail.IT_TYPE),
        VCH_FINE_DR: 0,
        VCH_FINE_CR: num(detail.ITM_FINE),
        VCH_DESC: `ItCode/${text(detail.IT_CODE)}`.slice(0, 150),
      });
    }
    return { reversed: true };
  });
}

// ───────────────────────── Other / expense purchase (TR_OTH_PURC) ─────────────────────────
// A NON-STOCK purchase: buying expenses/services (packing, freight, repairs…) from a supplier,
// with GST input credit. Ledger is purchase-sense (Dr expense + Dr input-GST + Dr round-off / Cr
// supplier) but NO inventory is touched. Header → PAY_DATA (desktop TR_OTH_PURC), + TAX_DATA
// (input register) + BILL_OS_DATA (payable). Book 'OPR', VCH_TYPE 'OPUR'.

export interface OtherPurchaseLine {
  expenseAc: string; // expense ledger to debit (required)
  amount: number; // F: taxable base for this line; R: tax-inclusive gross
  description?: string;
  hsnCode?: string;
  taxPct?: number; // per-line GST% (defaults to the bill taxRatePct)
  taxType?: 'F' | 'R'; // F=forward (amount is taxable, tax added on top); R=reverse/inclusive (amount includes tax)
}

export interface OtherPurchaseInput {
  scope: VoucherScope;
  acCode: string; // supplier account (required)
  acName?: string;
  billNo?: string;
  vchDate?: Date | string;
  taxRatePct: number;
  interState: boolean;
  taxAc?: string; // GST input ledger (default 'GSTINPUT')
  roundAc?: string;
  lines: OtherPurchaseLine[];
  cashAmt?: number;
  chequeAmt?: number;
  cardAmt?: number;
  upiAmt?: number;
  kasar?: number;
  cashAc?: string;
  bankAc?: string;
  kasarAc?: string;
}

function otherKeyOf(s: VoucherScope, vchNo: number): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? 'OPR',
    VCH_NO: formatVoucherNo(vchNo),
  };
}

export async function createOtherPurchase(
  prisma: any,
  input: OtherPurchaseInput,
): Promise<PurchaseResult> {
  if (!input.acCode) throw new PurchaseValidationError('supplier account (acCode) is required');
  const lines = (input.lines ?? []).filter((l) => l && l.expenseAc && Number(l.amount) > 0);
  if (!lines.length)
    throw new PurchaseValidationError('at least one expense line (account + amount) is required');

  const taxAc = input.taxAc ?? 'GSTINPUT';
  const roundAc = input.roundAc ?? 'ROUNDOFF';
  const tenantId = input.scope.tenantId;

  return withTenant(prisma, tenantId, async (tx: any) => {
    const vchNo = await nextVoucherNoTx(tx, input.scope);
    const key = otherKeyOf(input.scope, vchNo);
    const r2 = (x: number): number => Math.round((x + 1e-9) * 100) / 100;
    const inter = !!input.interState;

    // Per-line tax: F = forward (amount is the taxable base, tax added on top); R = reverse/inclusive
    // (amount includes tax → taxable = amount×100/(100+rate)). Rate defaults to the bill taxRatePct.
    const calc = lines.map((l) => {
      const pct = l.taxPct != null ? Number(l.taxPct) : input.taxRatePct;
      const amount = round2(Number(l.amount));
      const isR = String(l.taxType ?? 'F').toUpperCase() === 'R';
      const base = isR ? r2((amount * 100) / (100 + pct)) : amount;
      const gross = isR ? amount : r2(amount * (1 + pct / 100));
      const tax = r2(gross - base);
      return {
        ac: l.expenseAc,
        pct,
        base,
        gross,
        tax,
        hsn: l.hsnCode ?? null,
        itName: l.description ?? null,
        type: isR ? 'R' : 'F',
      };
    });
    const sumBase = r2(calc.reduce((s, c) => s + c.base, 0));
    const sumTax = r2(calc.reduce((s, c) => s + c.tax, 0));
    const total = Math.round(sumBase + sumTax);
    const roundOff = r2(total - (sumBase + sumTax));
    const cgst = inter ? 0 : r2(sumTax / 2);
    const sgst = inter ? 0 : r2(sumTax - cgst);
    const igst = inter ? sumTax : 0;
    const totals = {
      net: sumBase,
      taxable: sumBase,
      discount: 0,
      tax: sumTax,
      cgst,
      sgst,
      igst,
      roundOff,
      total,
    } as unknown as BillTotals;

    const byAc = new Map<string, number>();
    for (const c of calc) byAc.set(c.ac, r2((byAc.get(c.ac) ?? 0) + c.base));

    const base = { ...key, VCH_TYPE: 'OPUR' };
    const ledger: LedgerLine[] = [
      { ...base, AC_CODE: input.acCode, DR_AMT: 0, CR_AMT: total, SIGN: 'C' },
    ]; // Cr supplier
    for (const [ac, amount] of byAc)
      if (amount !== 0) ledger.push({ ...base, AC_CODE: ac, DR_AMT: amount, CR_AMT: 0, SIGN: 'D' }); // Dr expense (taxable base)
    if (sumTax !== 0)
      ledger.push({ ...base, AC_CODE: taxAc, DR_AMT: sumTax, CR_AMT: 0, SIGN: 'D' }); // Dr input GST
    if (roundOff !== 0)
      ledger.push({ ...base, AC_CODE: roundAc, DR_AMT: roundOff, CR_AMT: 0, SIGN: 'D' });
    assertBalanced(ledger);

    const tender = payoutLegs(base, {
      partyAc: input.acCode,
      cashAmt: input.cashAmt,
      chequeAmt: input.chequeAmt,
      cardAmt: input.cardAmt,
      upiAmt: input.upiAmt,
      kasar: input.kasar,
      cashAc: input.cashAc,
      bankAc: input.bankAc,
      kasarAc: input.kasarAc,
    });
    ledger.push(...tender.legs);

    const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
    const header = {
      ...key,
      VCH_TYPE: 'OPUR',
      BILL_NO: input.billNo ?? formatVoucherNo(vchNo),
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      AC_NAME: input.acName ?? null,
      NET_AMT: sumBase,
      CGST_TAX: cgst,
      SGST_TAX: sgst,
      IGST_TAX: igst,
      TOT_AMT: total,
      CASH_AMT: tender.cashAmt,
      CHQ_AMT: round2(num(input.chequeAmt)),
      CARD_AMT: round2(num(input.cardAmt)),
      KASAR_AMT: tender.kasar,
      BANK_AC: input.bankAc ?? null,
      BILL_OS: round2(total - tender.paidNow - tender.kasar),
    };
    // Per-line detail with HSN + F/R + CGST/SGST/IGST split (PAY_DETL).
    const detl = calc.map((c, i) => {
      const cg = inter ? 0 : r2(c.tax / 2);
      const sg = inter ? 0 : r2(c.tax - cg);
      const ig = inter ? c.tax : 0;
      return {
        ...key,
        SR_NO: i + 1,
        VCH_DATE: vchDate,
        VCH_TYPE: 'OPUR',
        BOOK_NAME: 'OTH PURC',
        AC_CODE: c.ac,
        HSN_CODE: c.hsn,
        IT_NAME: c.itName,
        TAX_TYPE: c.type,
        TAX_PRC: c.pct,
        TAXABLE_AMT: c.base,
        NET_AMT: c.base,
        CGST_PRC: inter ? 0 : r2(c.pct / 2),
        CGST_TAX: cg,
        SGST_PRC: inter ? 0 : r2(c.pct / 2),
        SGST_TAX: sg,
        IGST_PRC: inter ? c.pct : 0,
        IGST_TAX: ig,
        TOT_AMT: c.gross,
      };
    });
    // TAX_DATA grouped per distinct rate (a bill may mix HSN rates).
    const taxBase = {
      ...key,
      TRAN_TYPE: 'P',
      BOOK_NAME: 'OTH PURC',
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      PARTY_NAME: input.acName ?? null,
      TAX_SIGN: '-',
    };
    const byRate = new Map<number, { base: number; tax: number }>();
    for (const c of calc) {
      const e = byRate.get(c.pct) ?? { base: 0, tax: 0 };
      e.base = r2(e.base + c.base);
      e.tax = r2(e.tax + c.tax);
      byRate.set(c.pct, e);
    }
    const taxRows: any[] = [];
    let sr = 1;
    for (const [pct, e] of byRate) {
      if (e.tax === 0) continue;
      if (inter)
        taxRows.push({
          ...taxBase,
          SR_NO: sr++,
          TAX_TYPE: 'IGST',
          TAX_PRC: pct,
          NET_AMT: e.base,
          TAX_AMT: e.tax,
          TOT_AMT: r2(e.base + e.tax),
        });
      else {
        const cg = r2(e.tax / 2);
        taxRows.push({
          ...taxBase,
          SR_NO: sr++,
          TAX_TYPE: 'CGST',
          TAX_PRC: r2(pct / 2),
          NET_AMT: e.base,
          TAX_AMT: cg,
          TOT_AMT: r2(e.base + e.tax),
        });
        taxRows.push({
          ...taxBase,
          SR_NO: sr++,
          TAX_TYPE: 'SGST',
          TAX_PRC: r2(pct / 2),
          NET_AMT: e.base,
          TAX_AMT: r2(e.tax - cg),
          TOT_AMT: r2(e.base + e.tax),
        });
      }
    }
    const osRow = {
      ...key,
      VCH_TYPE: 'OPUR',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'N',
      BOOK_NAME: 'OTH PURC',
      SR_NO: 1,
      VCH_DATE: vchDate,
      AC_CODE: input.acCode,
      BILL_AMT: total,
      REC_AMT: tender.paidNow,
      KASAR_AMT: tender.kasar,
    };

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: 'OTH PURC',
      writes: [
        { table: 'PAY_DATA', rows: [header] },
        { table: 'PAY_DETL', rows: detl },
        ...(taxRows.length ? [{ table: 'TAX_DATA', rows: taxRows }] : []),
        { table: 'BILL_OS_DATA', rows: [osRow] },
      ],
    });
    return { vchNo, totals };
  });
}

export async function deleteOtherPurchase(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = otherKeyOf(input.scope, Number(input.vchNo));
  return withTenant(prisma, tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: ['PAY_DATA', 'PAY_DETL', 'AC_DATA', 'TAX_DATA', 'BILL_OS_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: 'OPUR', DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}
