import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertPeriodOpen,
  insertRowTx,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  assertFiscalDateTx,
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';

/**
 * Manufacturing (MFG) metal-flow pipeline. UNLIKE karigar (one issue, one receive, one party), a
 * single physical lot of metal flows through N sequential shop processes (melting → ghat/cast →
 * filing → pre-polish → mino → setting → assemble → nakshi → polish). At each process the metal is
 * ISSUED to the process (ITM_SIGN '-') and later RECEIVED back (ITM_SIGN '+'); the received weight
 * differs from issued by recoverable scrap (chol, ghis), casting-gate waste (ghat) and unrecoverable
 * loss. The same MFG_* tables are reused for every stage; the stage is identified by the book
 * (CO_BOOK / MAIN_BOOK) and by the 1-char process code ENTRY_TYPE (= IR_TYPE).
 *
 * Every stage writes the voucher trio MFG_DATA (header) + MFG_DETL (item lines) + MFG_IDTL
 * (sub-components / stones), then projects signed rows into the central MFG_ISU_REC metal-flow
 * ledger and — only for stock-bearing stages — a MAIN_STOCK movement. The manufacturing voucher is a
 * pure metal/weight movement: it posts NO amount to AC_DATA unless labour/cash is settled (then a
 * Dr LABOUR / Cr party pair, same shape as karigar receive).
 *
 * Metal accountability per lot/process is reconciled by the desktop formula (TR_MFG_ISU_REC.cs):
 *   RecWt = IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS
 * and the open balance for a lot = Σ issued IR_WT − Σ received RecWt (zero ⇒ fully accounted).
 *
 * NOTE: INOUT_TYPE is the book direction (= BOOK_INOUT): issue = metal OUT = 'O', receive = metal
 * IN = 'I' (opposite of intuition). This matches the desktop MFG_MAST.IN_OUT convention.
 */

export class MfgValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'MfgValidationError';
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const num = (v: unknown): number => (v == null ? 0 : Number(v));
const text = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;

/** Process-stage codes (ENTRY_TYPE / IR_TYPE), single char (decompiled Mfg_With_Order@25 / MFG_MAST). */
export const IR_TYPE = {
  MELT: 'L',
  GHAT: 'G',
  DESIGN: 'D',
  WAX: 'W',
  CAST: 'C',
  FILE: 'F',
  PREPOLISH: 'R',
  MINO: 'M',
  SETTING: 'S',
  ASSEMBLE: 'A',
  NAKSHI: 'N',
  POLISH: 'P',
  FILE2: 'I',
  NONE: 'X',
} as const;
export type IrType = (typeof IR_TYPE)[keyof typeof IR_TYPE];

/** MFG_DATA / MFG_DETL.INOUT_TYPE (= book direction): issue = metal OUT = 'O', receive = metal IN = 'I'. */
export const INOUT_ISSUE = 'O';
export const INOUT_RECEIPT = 'I';

/** MFG_ISU_REC.ITM_SIGN: issue subtracts metal from the lot, receive adds it back. */
export const SIGN_ISSUE = '-';
export const SIGN_RECEIPT = '+';

/** MAIN_STOCK.TR_TYPE: issue ⇒ metal out 'O', receive ⇒ metal in 'I'. */
const TR_ISSUE = 'O';
const TR_RECEIPT = 'I';

const DEFAULT_BOOK_NAME = 'MANUFACTURING';
const ISSUE_BOOK = 'MIS';
const RECEIPT_BOOK = 'MRC';
const VCH_TYPE_ISSUE = 'MFGI';
const VCH_TYPE_RECEIPT = 'MFGR';

// ---------------------------------------------------------------------------------------------------
// Pure computations (§2 of spec-mfg.md) — unit-testable, no DB.
// ---------------------------------------------------------------------------------------------------

/** Pure fine weight = net × touch / 100 (issue side, no ghat/wastage). */
export function fineWeight(nwt: number, touch: number): number {
  return round3((nwt * touch) / 100);
}

/** Accountable fine with casting-gate weight + wastage = (net + ghtWt) × (touch + west)/100. */
export function fineWithGhat(nwt: number, ghtWt: number, touch: number, westPct: number): number {
  return round3(((nwt + ghtWt) * (touch + westPct)) / 100);
}

/**
 * Labour amount by labour type (CommPassTotal): 'P' per-pc, 'N' per (net+ghat) gram, 'K' per
 * (net+ghat) fine /1000, default per gross gram.
 */
export function labourAmount(
  type: string | undefined | null,
  args: { pcs?: number; net?: number; ghtWt?: number; gross?: number; lbrRate?: number },
): number {
  const rate = num(args.lbrRate);
  switch (type) {
    case 'P':
      return round2(num(args.pcs) * rate);
    case 'N':
      return round2((num(args.net) + num(args.ghtWt)) * rate);
    case 'K':
      return round2(((num(args.net) + num(args.ghtWt)) * rate) / 1000);
    default:
      return round2(num(args.gross) * rate);
  }
}

/** Accountable received weight per line/lot = IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS (§2.3). */
export function recWt(args: {
  irWt: number;
  rtnChol?: number;
  rtnGhis?: number;
  itmGhat?: number;
  itmLoss?: number;
}): number {
  return round3(
    num(args.irWt) + num(args.rtnChol) + num(args.rtnGhis) + num(args.itmGhat) + num(args.itmLoss),
  );
}

/** Open lot balance at a process = Σ issued IR_WT − Σ received RecWt (> 0 ⇒ still outstanding). */
export function lotBalance(issuedWt: number, recWtTotal: number): number {
  return round3(issuedWt - recWtTotal);
}

type CompleteMfgScope = VoucherScope & { coYear: string; coBook: string };
type MfgAuditShape = 'header' | 'order-detail' | 'ghat-detail';

type MfgBookPolicy = { bookName: string; vchType: string; auditShape: MfgAuditShape };

function completeScope(scope: VoucherScope): CompleteMfgScope {
  if (!scope.coYear || !scope.coBook)
    throw new MfgValidationError('company year and book are required');
  return scope as CompleteMfgScope;
}

async function mfgBookPolicyTx(tx: any, scope: CompleteMfgScope): Promise<MfgBookPolicy> {
  const rows: Array<{ BOOK_NAME: unknown; BOOK_SNAME: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME","BOOK_SNAME" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (rows.length !== 1)
    throw new MfgValidationError(`book ${scope.coBook} is not configured unambiguously`);
  const bookName = String(rows[0]?.BOOK_NAME ?? '').trim();
  const vchType = String(rows[0]?.BOOK_SNAME ?? '').trim();
  if (!bookName || !vchType)
    throw new MfgValidationError(`book ${scope.coBook} has incomplete desktop identity`);
  const upper = `${scope.coBook} ${bookName} ${vchType}`.toUpperCase();
  // TR_MFG_ORD_ISU.cs:6301 uses detail audit with ITM_NWT on VCH_FINE_CR.
  const auditShape: MfgAuditShape = /DESIGN|ORD.*IS[SU]UE|DISU/.test(upper)
    ? 'order-detail'
    : // TR_MFG_GHAT_REC.cs:4888 uses detail audit with ITM_FINE on VCH_FINE_DR.
      /GHAT/.test(upper)
      ? 'ghat-detail'
      : 'header';
  return { bookName, vchType, auditShape };
}

/**
 * Route-level configured-book authority for a concrete MFG workflow. Generic MFG writers serve many
 * desktop forms, so they cannot infer whether a caller meant JDTR ISU, JDTR REC, GHAT, DESIGN, etc.
 * Adapters call this before any mutation/read, preventing a valid but wrong MFG book from crossing families.
 */
export async function requireMfgMainBook(
  prisma: any,
  scopeInput: VoucherScope,
  expectedMainBook: string,
): Promise<void> {
  const scope = completeScope(scopeInput);
  await withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<{ MAIN_BOOK: unknown; BOOK_TBL_NAME: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "MAIN_BOOK","BOOK_TBL_NAME" FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        ORDER BY row_id LIMIT 2`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
    );
    const mainBook = String(rows[0]?.MAIN_BOOK ?? '')
      .trim()
      .toUpperCase();
    const table = String(rows[0]?.BOOK_TBL_NAME ?? '')
      .trim()
      .toUpperCase();
    if (rows.length !== 1 || mainBook !== expectedMainBook.toUpperCase() || table !== 'MFG_DATA') {
      throw new MfgValidationError(
        `book ${scope.coBook} is ${mainBook || 'unclassified'}, expected ${expectedMainBook}`,
      );
    }
  });
}

async function tempBookRowTx(
  tx: any,
  scope: CompleteMfgScope,
  hiddenVoucherNo: string,
  bookName: string,
): Promise<void> {
  // Independent hidden numbering: TR_MFG_ISU_REC.cs:5242; TR_MFG_ITEM.cs:6724;
  // TR_MFG_ORD_ISU.cs:5511; TR_MFG_ORD_REC.cs:6180; TR_MFG_WITH_LOT.cs:5602;
  // TR_MFG_GHAT_REC.cs:4175; TR_JDT_REC.cs:5634; TR_MFG_KR_ISU_REC.cs:8983.
  await insertRowTx(tx, 'TEMP_BOOK_DATA', scope.tenantId, {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_BOOK: scope.coBook,
    VCH_NO: hiddenVoucherNo,
    BOOK_NAME: bookName,
  });
}

// ---------------------------------------------------------------------------------------------------
// Input shapes
// ---------------------------------------------------------------------------------------------------

/** One manufacturing detail line (→ MFG_DETL) optionally carrying sub-components (→ MFG_IDTL). */
export interface MfgLine {
  // ---- Process totals and OLD (pre-process) weights (MFG_DETL) ----------------------------------
  totalGrossWt?: number; // TOT_GWT
  totalLessWt?: number; // TOT_LWT
  totalNetWt?: number; // TOT_NWT
  karigarJobworkWt?: number; // KR_JDT_WT
  karigarMinorityWt?: number; // KR_MINO_WT
  karigarMinorityAmount?: number; // KR_MINO_AMT
  oldGrossWt?: number; // OLD_GWT
  oldNetWt?: number; // OLD_NWT
  oldFine?: number; // OLD_FINE
  oldLabourAmount?: number; // OLD_LBR_AMT
  oldOther?: number; // OLD_OTH
  addOtherWt?: number; // ADD_OTH_WT
  lessOtherWt?: number; // LESS_OTH_WT
  rateType?: string; // RATE_TYPE
  prCode?: string; // PR_CODE
  fittingItCode?: string; // FTNG_IT_CODE
  adjustDate?: Date | string; // ADJ_DATE
  vchSrno?: number; // VCH_SRNO
  // identity / pipeline
  itCode?: string;
  isuItCode?: string;
  itemRemark?: string;
  lotNo?: string;
  tagNo?: string;
  designNo?: string;
  designSrNo?: number;
  size?: string;
  // weights
  pcs?: number;
  grossWt?: number;
  othWt?: number; // ITM_OTH_WT (stone / other weight)
  netWt: number; // ITM_NWT
  ghtPct?: number; // ITM_GHT_PRC
  ghtWt?: number; // ITM_GHT_WT (ghat / casting-gate weight)
  touch: number; // ITM_TOUCH (purity %)
  westPct?: number; // ITM_WEST_PRC (wastage %)
  fineWt?: number; // override ITM_FINE; else computed
  // receive-side scrap / reconciliation
  rtnChol?: number; // RTN_CHOL (filings/clippings returned)
  rtnGhis?: number; // RTN_GHIS (polishing dust returned)
  itmGhat?: number; // ITM_GHAT (defaults to ghtWt on receive)
  itmLoss?: number; // ITM_LOSS (unrecoverable loss)
  mtrlWt?: number; // MTRL_WT (auxiliary material)
  mtrlItCode?: string; // MTRL_IT_CODE
  // diamonds / stones carried alongside
  dmPcs?: number;
  dmWt?: number;
  // labour / amounts
  lbrType?: string; // P / N / K / '' (default %)
  lbrRate?: number;
  lbrAmt?: number; // override; else computed
  othAmt?: number;
  itRate?: number;
  itAmt?: number;
  netAmt?: number; // override; else lbrAmt + othAmt
  krName?: string;
  // pipeline back-pointer (receive → prior-process MFG_DETL line)
  repYrcd?: string;
  repDbcd?: string;
  repNo?: string;
  repSrno?: number;
  repAcCode?: string;
  // sales-order link (TR_MFG_ORD_ISU): the open SL_ORD_DETL line this design issue consumes
  ordNo?: string; // ORD_NO (order VCH_NO)
  ordYrcd?: string; // ORD_YRCD (order CO_YEAR)
  ordDbcd?: string; // ORD_DBCD (order CO_BOOK)
  ordAcCode?: string; // ORD_AC_CODE (order customer)
  ordDesign?: string; // ORD_DESIGN
  ordSrno?: number; // ORD_SRNO (order line SR_NO)
  // sub-components / stones under this line
  components?: MfgComponent[];
}

/** One sub-component / stone under a detail line (→ MFG_IDTL). */
export interface MfgComponent {
  /** VCH_SRNO — the tag instance this component came from (TR_MFG_WITH_LOT.cs). */
  vchSrno?: number;
  itCode?: string;
  itType?: string;
  tagNo?: string;
  pcs?: number;
  pcsWt?: number; // IT_PCS_WT
  grossWt?: number; // IT_GWT
  conPct?: number; // IT_CON_PRC (consumption %)
  conWt?: number; // IT_CON_WT (override; else gwt × con%/100)
  rateType?: string; // IT_RATE_TYPE ('P' per-pc / 'W' per-wt)
  rate?: number; // IT_RATE
  amount?: number; // IT_AMT (override)
  lbrRate?: number; // IT_LBR_RATE
  lbrAmt?: number; // IT_LBR_AMT (override)
  netAmt?: number; // IT_NET_AMT (override)
  oldItmIsu?: string; // OLD_ITM_ISU (Y/N)
  rtnPcs?: number;
  rtnWt?: number; // RTN_GWT
  brokPcs?: number;
  brokWt?: number;
}

export interface MfgIssueInput {
  scope: VoucherScope;
  partyAc?: string; // AC_CODE (party)
  karigarAc?: string; // KR_CODE (worker / process party)
  vchDate?: Date | string;
  irType?: string; // ENTRY_TYPE / process char; resolved from MFG_MAST or defaulted
  bookName?: string; // BOOK_NAME = MAIN_BOOK
  vchType?: string; // VCH_TYPE = BOOK_SNAME
  empCode?: string;
  billNo?: string;
  billDate?: Date | string;
  vchDesc?: string;
  mainUser?: string;
  postStock?: boolean; // force a MAIN_STOCK movement (STK_ISU). Default: stage flag, else true.
  lines: MfgLine[];
}

export interface MfgReceiveInput extends MfgIssueInput {
  labourAmt?: number; // settled labour (Dr LABOUR / Cr party)
  labourAc?: string; // default 'LABOUR'
  cashAmt?: number;
  kasarAmt?: number;
  billOs?: number;
}

// ---------------------------------------------------------------------------------------------------
// Stage registry (MFG_MAST) + key helpers
// ---------------------------------------------------------------------------------------------------

interface MfgStage {
  irType: string; // ENTRY_TYPE
  bookName: string; // MAIN_BOOK
  vchType: string; // BOOK_SNAME
  stkIsu: string; // STK_ISU (Y/N)
  stkRec: string; // STK_REC (Y/N)
  lastTran: string; // LAST_TRAN (previous stage IR_TYPE)
  nextTran: string; // NEXT_TRAN (next stage IR_TYPE)
}

/** Resolve the stage/book config for a CO_BOOK from MFG_MAST (greenfield ⇒ null, caller defaults). */
async function getStageTx(tx: any, s: VoucherScope): Promise<MfgStage | null> {
  if (!s.coBook) return null;
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "ENTRY_TYPE","MAIN_BOOK","BOOK_SNAME","STK_ISU","STK_REC","LAST_TRAN","NEXT_TRAN"
     FROM "MFG_MAST" WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 LIMIT 1`,
    s.coCode,
    s.coBook,
  );
  if (!rows.length) return null;
  const r = rows[0]!;
  return {
    irType: String(r.ENTRY_TYPE ?? ''),
    bookName: String(r.MAIN_BOOK ?? ''),
    vchType: String(r.BOOK_SNAME ?? ''),
    stkIsu: String(r.STK_ISU ?? 'N'),
    stkRec: String(r.STK_REC ?? 'N'),
    lastTran: String(r.LAST_TRAN ?? ''),
    nextTran: String(r.NEXT_TRAN ?? ''),
  };
}

function keyOf(s: VoucherScope, vchNo: number, book: string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? book,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

interface RowCtx {
  /** Settlement block carried on the MFG_DATA header (MSG2_TOTAL grid in the desktop). */
  bankAc?: string;
  cardAc?: string;
  chqNo?: string;
  vchDate: Date;
  vchType: string;
  bookName: string;
  inout: string;
  irType: string;
  isReceipt: boolean;
  partyAc?: string;
  karigarAc?: string;
  empCode?: string;
  mainUser?: string;
  hiddenVoucherNo: string;
  persistedClock?: unknown;
  billNo?: string;
  billDate?: Date | null;
  vchDesc?: string;
}

function ctxOf(
  input: MfgIssueInput,
  stage: MfgStage | null,
  vchDate: Date,
  isReceipt: boolean,
  hiddenVoucherNo: string,
  persistedClock?: unknown,
): RowCtx {
  return {
    vchDate,
    hiddenVoucherNo,
    persistedClock,
    vchType: input.vchType ?? stage?.vchType ?? (isReceipt ? VCH_TYPE_RECEIPT : VCH_TYPE_ISSUE),
    bookName: input.bookName ?? stage?.bookName ?? DEFAULT_BOOK_NAME,
    inout: isReceipt ? INOUT_RECEIPT : INOUT_ISSUE,
    irType: input.irType ?? stage?.irType ?? IR_TYPE.GHAT,
    isReceipt,
    partyAc: input.partyAc,
    karigarAc: input.karigarAc,
    empCode: input.empCode,
    mainUser: input.mainUser,
    billNo: input.billNo,
    billDate: input.billDate ? new Date(input.billDate) : null,
    vchDesc: input.vchDesc,
  };
}

// ---------------------------------------------------------------------------------------------------
// Per-line derived values
// ---------------------------------------------------------------------------------------------------

/** ITM_FINE per line: explicit override → (net+ghat)×(touch+west)/100 when touch/west present → net. */
function lineFine(l: MfgLine): number {
  if (l.fineWt != null) return round3(num(l.fineWt));
  const touch = num(l.touch);
  const west = num(l.westPct);
  if (touch === 0 && west === 0) return round3(num(l.netWt));
  return fineWithGhat(num(l.netWt), num(l.ghtWt), touch, west);
}

function lineLbrAmt(l: MfgLine): number {
  if (l.lbrAmt != null) return round2(num(l.lbrAmt));
  return labourAmount(l.lbrType, {
    pcs: l.pcs,
    net: l.netWt,
    ghtWt: l.ghtWt,
    gross: l.grossWt,
    lbrRate: l.lbrRate,
  });
}

function lineNetAmt(l: MfgLine): number {
  if (l.netAmt != null) return round2(num(l.netAmt));
  return round2(lineLbrAmt(l) + num(l.othAmt));
}

/** Accountable received weight for a receive line (ITM_GHAT defaults to the line's ghat weight). */
function lineRecWt(l: MfgLine): number {
  return recWt({
    irWt: num(l.netWt),
    rtnChol: num(l.rtnChol),
    rtnGhis: num(l.rtnGhis),
    itmGhat: l.itmGhat != null ? num(l.itmGhat) : num(l.ghtWt),
    itmLoss: num(l.itmLoss),
  });
}

interface Totals {
  grWt: number;
  netWt: number;
  fineWt: number;
  lbrAmt: number;
  othAmt: number;
  netAmt: number;
  totAmt: number;
  cashAmt: number;
  kasarAmt: number;
  billOs: number;
}

function totalsOf(
  lines: MfgLine[],
  extra: { cashAmt?: number; kasarAmt?: number; billOs?: number },
): Totals {
  const grWt = round3(lines.reduce((s, l) => s + num(l.grossWt), 0));
  const netWt = round3(lines.reduce((s, l) => s + num(l.netWt), 0));
  const fineWt = round3(lines.reduce((s, l) => s + lineFine(l), 0));
  const lbrAmt = round2(lines.reduce((s, l) => s + lineLbrAmt(l), 0));
  const othAmt = round2(lines.reduce((s, l) => s + num(l.othAmt), 0));
  const netAmt = round2(lines.reduce((s, l) => s + lineNetAmt(l), 0));
  const cashAmt = round2(num(extra.cashAmt));
  const kasarAmt = round2(num(extra.kasarAmt));
  const billOs =
    extra.billOs != null ? round2(num(extra.billOs)) : round2(netAmt - cashAmt - kasarAmt);
  return { grWt, netWt, fineWt, lbrAmt, othAmt, netAmt, totAmt: netAmt, cashAmt, kasarAmt, billOs };
}

// ---------------------------------------------------------------------------------------------------
// Row builders (only columns that exist in the live schema are written)
// ---------------------------------------------------------------------------------------------------

function header(key: VoucherKey, ctx: RowCtx, t: Totals): Record<string, unknown> {
  return {
    ...key,
    VCH_DATE: ctx.vchDate,
    VCH_TIME: voucherTimestamp(ctx.vchDate, ctx.persistedClock as string | undefined),
    BILL_NO: ctx.billNo ?? null,
    BILL_DATE: ctx.billDate ?? null,
    VCH_TYPE: ctx.vchType,
    INOUT_TYPE: ctx.inout,
    ENTRY_TYPE: ctx.irType,
    BOOK_NAME: ctx.bookName,
    AC_CODE: ctx.partyAc ?? null,
    KR_CODE: ctx.karigarAc ?? null,
    EMP_CODE: ctx.empCode ?? null,
    VCH_DESC: ctx.vchDesc ?? null,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    AC_GST_TYPE: 'L',
    TAX_PRC: 0,
    TAX_AMT: 0,
    IGST_TAX: 0,
    CGST_TAX: 0,
    SGST_TAX: 0,
    GR_WT: t.grWt,
    NET_WT: t.netWt,
    FINE_WT: t.fineWt,
    LBR_AMT: t.lbrAmt,
    OTH_AMT: t.othAmt,
    ROF_AMT: 0,
    NET_AMT: t.netAmt,
    TOT_AMT: t.totAmt,
    CASH_AMT: t.cashAmt,
    CHQ_AMT: 0,
    CARD_AMT: 0,
    KASAR_AMT: t.kasarAmt,
    BILL_OS: t.billOs,
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    // TR_MFG_*.cs carries the settlement block on the manufacturing header, sourced from its settlement
    // grid: MSG2_TOTAL[2,5] bank account, [3,5] card account, [2,2] cheque number. TAX_CODE is a literal
    // empty string in the desktop — manufacturing carries no tax code of its own.
    BANK_AC: text(ctx.bankAc, 8),
    CARD_AC: text(ctx.cardAc, 8),
    CHQ_NO: text(ctx.chqNo, 20),
    TAX_CODE: null,
    MAIN_USER: ctx.mainUser ?? null,
  };
}

function detlRows(key: VoucherKey, ctx: RowCtx, lines: MfgLine[]): Record<string, unknown>[] {
  return lines.map((l, idx) => ({
    ...key,
    SR_NO: idx + 1,
    OLD_SRNO: idx + 1,
    VCH_DATE: ctx.vchDate,
    VCH_TIME: voucherTimestamp(ctx.vchDate, ctx.persistedClock as string | undefined),
    VCH_TYPE: ctx.vchType,
    INOUT_TYPE: ctx.inout,
    ENTRY_TYPE: ctx.irType,
    BOOK_NAME: ctx.bookName,
    AC_CODE: ctx.partyAc ?? null,
    KR_CODE: ctx.karigarAc ?? null,
    KR_NAME: l.krName ?? null,
    IT_CODE: l.itCode ?? null,
    ISU_IT_CODE: l.isuItCode ?? null,
    ITM_REMARK: l.itemRemark ?? null,
    TAG_NO: l.tagNo ?? null,
    LOT_NO: l.lotNo ?? null,
    DESIGN_NO: l.designNo ?? null,
    DESIGN_SRNO: l.designSrNo == null ? null : num(l.designSrNo),
    ITM_SIZE: l.size ?? null,
    ITM_PCS: num(l.pcs),
    ITM_GWT: num(l.grossWt),
    ITM_OTH_WT: num(l.othWt),
    ITM_NWT: num(l.netWt),
    ITM_TOUCH: num(l.touch),
    ITM_WEST_PRC: num(l.westPct),
    ITM_FINE: lineFine(l),
    ITM_GHT_PRC: num(l.ghtPct),
    ITM_GHT_WT: num(l.ghtWt),
    RTN_CHOL: ctx.isReceipt ? num(l.rtnChol) : 0,
    RTN_GHIS: ctx.isReceipt ? num(l.rtnGhis) : 0,
    MTRL_IT_CODE: l.mtrlItCode ?? null,
    MTRL_WT: ctx.isReceipt ? num(l.mtrlWt) : 0,
    KR_GHAT_WT: 0,
    KR_KUNDAN_WT: 0,
    KR_WAX_WT: 0,
    FTNG_GWT: 0,
    FTNG_NWT: 0,
    FTNG_TOUCH: 0,
    FTNG_FINE: 0,
    LBR_TYPE: l.lbrType ?? null,
    LBR_RATE: num(l.lbrRate),
    LBR_AMT: lineLbrAmt(l),
    OTH_AMT: num(l.othAmt),
    ITM_RATE: num(l.itRate),
    ITM_AMT: num(l.itAmt),
    NET_AMT: lineNetAmt(l),
    DM_PCS: num(l.dmPcs),
    DM_WT: num(l.dmWt),
    IT_TYPE: 'G',
    REP_YRCD: l.repYrcd ?? null,
    REP_DBCD: l.repDbcd ?? null,
    REP_NO: l.repNo ?? null,
    REP_SRNO: l.repSrno == null ? null : num(l.repSrno),
    REP_AC_CODE: l.repAcCode ?? null,
    REP_ADJ: 'N',
    ORD_NO: l.ordNo ?? null,
    ORD_YRCD: l.ordYrcd ?? null,
    ORD_DBCD: l.ordDbcd ?? null,
    ORD_AC_CODE: l.ordAcCode ?? null,
    ORD_DESIGN: l.ordDesign ?? null,
    ORD_SRNO: l.ordSrno == null ? null : num(l.ordSrno),
    HD_VCH_NO: ctx.hiddenVoucherNo,
    DATA_TRFR: 'N',
    // TR_MFG_*.cs carries the process totals, the OLD (pre-process) weights and the karigar jobwork /
    // minority split on every MFG_DETL row. Without them a manufacturing stage cannot be reconciled back
    // to what went in, which is the whole purpose of the detail row.
    TOT_GWT: num(l.totalGrossWt),
    TOT_LWT: num(l.totalLessWt),
    TOT_NWT: num(l.totalNetWt),
    KR_JDT_WT: num(l.karigarJobworkWt),
    KR_MINO_WT: num(l.karigarMinorityWt),
    KR_MINO_AMT: num(l.karigarMinorityAmount),
    OLD_GWT: num(l.oldGrossWt),
    OLD_NWT: num(l.oldNetWt),
    OLD_FINE: num(l.oldFine),
    OLD_LBR_AMT: num(l.oldLabourAmount),
    OLD_OTH: num(l.oldOther),
    ADD_OTH_WT: num(l.addOtherWt),
    LESS_OTH_WT: num(l.lessOtherWt),
    RATE_TYPE: text(l.rateType, 1),
    PR_CODE: text(l.prCode, 2),
    FTNG_IT_CODE: text(l.fittingItCode, 5),
    ADJ_DATE: l.adjustDate ? new Date(l.adjustDate) : null,
    VCH_SRNO: l.vchSrno ?? idx + 1,
    MAIN_USER: ctx.mainUser ?? null,
  }));
}

function idtlRows(key: VoucherKey, ctx: RowCtx, lines: MfgLine[]): Record<string, unknown>[] {
  const rows: Record<string, unknown>[] = [];
  lines.forEach((l, idx) => {
    const parentSr = idx + 1;
    (l.components ?? []).forEach((c, j) => {
      const conWt =
        c.conWt != null ? round3(num(c.conWt)) : round3((num(c.grossWt) * num(c.conPct)) / 100);
      const itAmt =
        c.amount != null
          ? round2(num(c.amount))
          : round2(num(c.rate) * (c.rateType === 'P' ? num(c.pcs) : num(c.grossWt)));
      const lbrAmt = c.lbrAmt != null ? round2(num(c.lbrAmt)) : round2(num(c.lbrRate) * num(c.pcs));
      const netAmt = c.netAmt != null ? round2(num(c.netAmt)) : round2(itAmt + lbrAmt);
      rows.push({
        // TR_MFG_WITH_LOT.cs stamps the tag instance the component came from, so a lot-tracked
        // component can be traced to its physical tag row.
        VCH_SRNO: c.vchSrno ?? parentSr,
        ...key,
        SR_NO: parentSr,
        ISR_NO: j + 1,
        VCH_DATE: ctx.vchDate,
        VCH_TYPE: ctx.vchType,
        INOUT_TYPE: ctx.inout,
        ENTRY_TYPE: ctx.irType,
        BOOK_NAME: ctx.bookName,
        AC_CODE: ctx.partyAc ?? null,
        TAG_NO: c.tagNo ?? null,
        IT_CODE: c.itCode ?? null,
        IT_TYPE: c.itType ?? null,
        IT_PCS: num(c.pcs),
        IT_PCS_WT: num(c.pcsWt),
        IT_GWT: num(c.grossWt),
        IT_CON_PRC: num(c.conPct),
        IT_CON_WT: conWt,
        IT_RATE_TYPE: c.rateType ?? null,
        IT_RATE: num(c.rate),
        IT_AMT: itAmt,
        IT_LBR_RATE: num(c.lbrRate),
        IT_LBR_AMT: lbrAmt,
        IT_NET_AMT: netAmt,
        RTN_PCS: num(c.rtnPcs),
        RTN_GWT: num(c.rtnWt),
        BROK_PCS: num(c.brokPcs),
        BROK_WT: num(c.brokWt),
        OLD_ITM_ISU: c.oldItmIsu ?? 'N',
        KR_CODE: ctx.karigarAc ?? null,
        HD_VCH_NO: ctx.hiddenVoucherNo,
        MAIN_USER: ctx.mainUser ?? null,
      });
    });
  });
  return rows;
}

/** Project signed metal-flow rows into MFG_ISU_REC: issue ⇒ '-' (scrap 0), receive ⇒ '+' (scrap filled). */
function isuRecRows(key: VoucherKey, ctx: RowCtx, lines: MfgLine[]): Record<string, unknown>[] {
  return lines.map((l, idx) => ({
    ...key,
    SR_NO: idx + 1,
    ISR_NO: 1,
    IR_SRNO: idx + 1,
    VCH_DATE: ctx.vchDate,
    VCH_TIME: voucherTimestamp(ctx.vchDate, ctx.persistedClock as string | undefined),
    VCH_TYPE: ctx.vchType,
    INOUT_TYPE: ctx.inout,
    BOOK_NAME: ctx.bookName,
    AC_CODE: ctx.partyAc ?? null,
    KR_AC_CODE: ctx.karigarAc ?? null,
    IT_CODE: l.itCode ?? null,
    LOT_NO: l.lotNo ?? null,
    DESIGN_NO: l.designNo ?? null,
    ITM_SIZE: l.size ?? null,
    IT_TYPE: 'G',
    ITM_SIGN: ctx.isReceipt ? SIGN_RECEIPT : SIGN_ISSUE,
    IR_TYPE: ctx.irType,
    IR_PCS: num(l.pcs),
    IR_WT: num(l.netWt), // IR_WT = ITM_NWT
    DM_PCS: num(l.dmPcs),
    DM_WT: num(l.dmWt),
    ITM_GWT: num(l.grossWt),
    ITM_NWT: num(l.netWt),
    ITM_TOUCH: num(l.touch),
    ITM_WEST: num(l.westPct),
    ITM_FINE: lineFine(l),
    RTN_CHOL: ctx.isReceipt ? num(l.rtnChol) : 0,
    RTN_GHIS: ctx.isReceipt ? num(l.rtnGhis) : 0,
    ITM_GHAT: ctx.isReceipt ? (l.itmGhat != null ? num(l.itmGhat) : num(l.ghtWt)) : 0,
    ITM_LOSS: ctx.isReceipt ? num(l.itmLoss) : 0,
    RTN_MTRL: ctx.isReceipt ? num(l.mtrlWt) : 0,
    LBR_RATE: num(l.lbrRate),
    LBR_AMT: lineLbrAmt(l),
    OTH_AMT: num(l.othAmt),
    ITM_RATE: num(l.itRate),
    ITM_AMT: num(l.itAmt),
    CR_AMT: 0,
    DR_AMT: 0,
    EMP_CODE: ctx.empCode ?? null,
    MAIN_USER: ctx.mainUser ?? null,
    DATA_TYPE: 'M',
  }));
}

/** MAIN_STOCK metal movement (issue ⇒ TR_TYPE 'O'/sign '-', receive ⇒ 'I'/'+'); mirrors karigar.stockRows. */
function stockRows(
  key: VoucherKey,
  ctx: RowCtx,
  trType: 'I' | 'O',
  sign: '+' | '-',
  lines: MfgLine[],
): Record<string, unknown>[] {
  return lines.map((l, idx) => ({
    ...key,
    SR_NO: idx + 1,
    ISR_NO: 1,
    VCH_DATE: ctx.vchDate,
    VCH_TYPE: ctx.vchType,
    BOOK_NAME: ctx.bookName,
    AC_CODE: ctx.partyAc ?? null,
    IT_CODE: l.itCode ?? null,
    TAG_NO: l.tagNo ?? null,
    TR_TYPE: trType,
    ITM_SIGN: sign,
    ITM_QTY: 1,
    ITM_PCS: num(l.pcs),
    ITM_GWT: num(l.grossWt),
    ITM_NWT: num(l.netWt),
    ITM_TOUCH: num(l.touch),
    ITM_WEST: num(l.westPct),
    ITM_FINE: lineFine(l),
    ITM_RATE: num(l.itRate),
    ITM_AMT: num(l.itAmt),
    LBR_RATE: num(l.lbrRate),
    LBR_AMT: lineLbrAmt(l),
    OTH_AMT: num(l.othAmt),
    NET_AMT: lineNetAmt(l),
    DESIGN_NO: l.designNo ?? null,
    ITM_SIZE: l.size ?? null,
    GHT_PRC: num(l.ghtPct),
    ITM_LOT: l.lotNo ?? null,
    EMP_CODE: ctx.empCode ?? null,
    MAIN_USER: ctx.mainUser ?? null,
    DATA_TYPE: 'M',
  }));
}

type Write = { table: string; rows: Record<string, unknown>[] };

// ---------------------------------------------------------------------------------------------------
// Public engine
// ---------------------------------------------------------------------------------------------------

/**
 * MFG ISSUE — metal OUT to a process stage. Writes MFG_DATA + MFG_DETL (+ MFG_IDTL for components),
 * projects MFG_ISU_REC rows with ITM_SIGN '-' (scrap cols 0), and posts a MAIN_STOCK movement
 * (TR_TYPE 'O' / sign '-') when the stage bears stock (STK_ISU='Y' or postStock). Pure metal flow ⇒
 * empty AC_DATA ledger (mirrors karigar). All writes in ONE tenant transaction.
 */
export async function issueMfg(
  prisma: any,
  input: MfgIssueInput,
): Promise<{ vchNo: number; fineIssued: number; netWt: number }> {
  if (!input.lines?.length) throw new MfgValidationError('at least one line is required');
  if (!input.partyAc && !input.karigarAc)
    throw new MfgValidationError('partyAc or karigarAc is required');

  const scope = completeScope(input.scope);
  const tenantId = scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const t = totalsOf(input.lines, {});

  const vchNo = await withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const stage = await getStageTx(tx, scope);
    const policy = await mfgBookPolicyTx(tx, scope);
    const hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
    const ctx = ctxOf(
      { ...input, scope, bookName: policy.bookName, vchType: policy.vchType },
      stage,
      vchDate,
      false,
      hiddenVoucherNo,
    );
    const no = await nextVoucherNoTx(tx, scope);
    const key = keyOf(scope, no, ISSUE_BOOK);
    await tempBookRowTx(tx, scope, hiddenVoucherNo, policy.bookName);

    const writes: Write[] = [
      { table: 'MFG_DATA', rows: [header(key, ctx, t)] },
      { table: 'MFG_DETL', rows: detlRows(key, ctx, input.lines) },
      { table: 'MFG_ISU_REC', rows: isuRecRows(key, ctx, input.lines) },
    ];
    const idtl = idtlRows(key, ctx, input.lines);
    if (idtl.length) writes.push({ table: 'MFG_IDTL', rows: idtl });

    const doStock = stage ? stage.stkIsu === 'Y' : input.postStock !== false;
    if (doStock)
      writes.push({
        table: 'MAIN_STOCK',
        rows: stockRows(key, ctx, TR_ISSUE, SIGN_ISSUE, input.lines),
      });

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      writes,
      bookName: ctx.bookName,
    });
    // TR_MFG_ORD_ISU: mark each consumed open sales-order line as design-issued.
    for (const l of input.lines) {
      const rawOrdNo = String(l.ordNo ?? '').trim();
      if (!rawOrdNo) continue;
      const ordNo = formatVoucherNo(rawOrdNo);
      await tx.$executeRawUnsafe(
        `UPDATE "SL_ORD_DETL" SET "DESIGN_ISU"='Y' WHERE "CO_CODE"=$1 AND "VCH_NO"=$2 AND "SR_NO"=$3`,
        input.scope.coCode,
        ordNo,
        num(l.ordSrno),
      );
    }
    return no;
  });

  return { vchNo, fineIssued: t.fineWt, netWt: t.netWt };
}

/**
 * MFG RECEIVE — metal IN from a process stage with ghat/loss/chol/ghis reconciliation. Writes the
 * MFG_DATA/MFG_DETL/(MFG_IDTL) trio, projects MFG_ISU_REC rows with ITM_SIGN '+' filling
 * RTN_CHOL/RTN_GHIS/ITM_GHAT(=ghtWt)/RTN_MTRL/ITM_LOSS, and posts finished goods to MAIN_STOCK
 * (TR_TYPE 'I' / sign '+') when the stage bears stock (STK_REC='Y' or postStock). Per line the
 * accountable received weight is RecWt = IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS. Labour
 * settlement (labourAmt > 0) posts a balanced Dr LABOUR / Cr party pair to AC_DATA; otherwise the
 * ledger is empty (pure metal flow). All writes in ONE tenant transaction.
 */
export async function receiveMfg(
  prisma: any,
  input: MfgReceiveInput,
): Promise<{ vchNo: number; fineReceived: number; recWt: number; netWt: number }> {
  if (!input.lines?.length) throw new MfgValidationError('at least one line is required');
  if (!input.partyAc && !input.karigarAc)
    throw new MfgValidationError('partyAc or karigarAc is required');

  const scope = completeScope(input.scope);
  const tenantId = scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const labourAmt = round2(num(input.labourAmt));
  const labourAc = input.labourAc ?? 'LABOUR';
  const creditAc = input.karigarAc ?? input.partyAc;
  if (labourAmt > 0 && !creditAc)
    throw new MfgValidationError('a party/karigar account is required to settle labour');

  const t = totalsOf(input.lines, {
    cashAmt: input.cashAmt,
    kasarAmt: input.kasarAmt,
    billOs: input.billOs,
  });
  const recWtTotal = round3(input.lines.reduce((s, l) => s + lineRecWt(l), 0));

  const vchNo = await withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const stage = await getStageTx(tx, scope);
    const policy = await mfgBookPolicyTx(tx, scope);
    const hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
    const ctx = ctxOf(
      { ...input, scope, bookName: policy.bookName, vchType: policy.vchType },
      stage,
      vchDate,
      true,
      hiddenVoucherNo,
    );
    const no = await nextVoucherNoTx(tx, scope);
    const key = keyOf(scope, no, RECEIPT_BOOK);
    await tempBookRowTx(tx, scope, hiddenVoucherNo, policy.bookName);

    const ledger: LedgerLine[] =
      labourAmt > 0
        ? [
            {
              ...key,
              VCH_TYPE: ctx.vchType,
              BOOK_NAME: ctx.bookName,
              AC_CODE: labourAc,
              DR_AMT: labourAmt,
              CR_AMT: 0,
              SIGN: 'D',
            },
            {
              ...key,
              VCH_TYPE: ctx.vchType,
              BOOK_NAME: ctx.bookName,
              AC_CODE: creditAc,
              DR_AMT: 0,
              CR_AMT: labourAmt,
              SIGN: 'C',
            },
          ]
        : [];

    const writes: Write[] = [
      {
        table: 'MFG_DATA',
        rows: [header(key, ctx, { ...t, lbrAmt: labourAmt > 0 ? labourAmt : t.lbrAmt })],
      },
      { table: 'MFG_DETL', rows: detlRows(key, ctx, input.lines) },
      { table: 'MFG_ISU_REC', rows: isuRecRows(key, ctx, input.lines) },
    ];
    const idtl = idtlRows(key, ctx, input.lines);
    if (idtl.length) writes.push({ table: 'MFG_IDTL', rows: idtl });

    const doStock = stage ? stage.stkRec === 'Y' : input.postStock !== false;
    if (doStock)
      writes.push({
        table: 'MAIN_STOCK',
        rows: stockRows(key, ctx, TR_RECEIPT, SIGN_RECEIPT, input.lines),
      });

    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      writes,
      bookName: ctx.bookName,
    });
    return no;
  });

  return { vchNo, fineReceived: t.fineWt, recWt: recWtTotal, netWt: t.netWt };
}

/**
 * Live lot balance at a process from MFG_ISU_REC (§2.3):
 *   Σ issued IR_WT − Σ received (IR_WT + RTN_CHOL + RTN_GHIS + ITM_GHAT + ITM_LOSS).
 * Positive ⇒ metal still outstanding at the stage/lot.
 */
export async function mfgLotBalance(
  prisma: any,
  scope: VoucherScope,
  lotNo: string,
  itCode?: string,
): Promise<number> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const params: unknown[] = [scope.coCode, lotNo];
    let sql = `SELECT
        coalesce(SUM(CASE WHEN "ITM_SIGN"=$3 THEN "IR_WT" ELSE 0 END),0) AS issued,
        coalesce(SUM(CASE WHEN "ITM_SIGN"=$4 THEN ("IR_WT"+"RTN_CHOL"+"RTN_GHIS"+"ITM_GHAT"+"ITM_LOSS") ELSE 0 END),0) AS received
      FROM "MFG_ISU_REC" WHERE "CO_CODE"=$1 AND "LOT_NO"=$2`;
    params.push(SIGN_ISSUE, SIGN_RECEIPT);
    if (itCode) {
      sql += ` AND "IT_CODE"=$5`;
      params.push(itCode);
    }
    const rows: Array<{ issued: unknown; received: unknown }> = await tx.$queryRawUnsafe(
      sql,
      ...params,
    );
    const issued = Number(rows[0]?.issued ?? 0);
    const received = Number(rows[0]?.received ?? 0);
    return lotBalance(issued, received);
  });
}

export interface MfgLifecycleInput extends MfgIssueInput {
  vchNo: number | string;
  mode: 'issue' | 'receive';
  labourAmt?: number;
  labourAc?: string;
  cashAmt?: number;
  kasarAmt?: number;
  billOs?: number;
}

export interface DeleteMfgInput {
  scope: VoucherScope;
  vchNo: number | string;
  book?: string;
  vchType?: string;
  deleteUser?: string;
}

const mfgWriteSet = [
  'AC_DATA',
  'MAIN_STOCK',
  'MFG_ISU_REC',
  'MFG_IDTL',
  'MFG_DETL',
  'MFG_DATA',
] as const;

function isoDate(value: unknown): string {
  return new Date(value as any).toISOString().slice(0, 10);
}

async function assertMfgReplacementSafeTx(
  tx: any,
  scope: CompleteMfgScope,
  voucherNo: string,
  mode: 'issue' | 'receive',
  lines: MfgLine[],
): Promise<void> {
  const refs: Array<{ one: unknown }> = await tx.$queryRawUnsafe(
    `SELECT 1 AS one FROM "MFG_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      AND coalesce("REP_YRCD",'')=$4 AND coalesce("REP_DBCD",'')=$5 AND coalesce("REP_NO",'')=$6
      AND NOT ("CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6) LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  // Desktop delete guards follow REP_YRCD/REP_DBCD/REP_NO before reversal (TR_MFG_ISU_REC.cs:6040-6088;
  // TR_MFG_ORD_ISU.cs:6242-6300). Editing is the same destructive replacement and must fail first.
  if (refs.length)
    throw new MfgValidationError('voucher metal/stock was consumed by a later voucher');
  if (mode !== 'issue') return;

  for (const line of lines) {
    const lot = String(line.lotNo ?? '').trim();
    const item = String(line.itCode ?? '').trim();
    if (!lot && !item) continue;
    const rows: Array<{ balance: unknown }> = await tx.$queryRawUnsafe(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='-' THEN "IR_WT"
                                ELSE -("IR_WT"+"RTN_CHOL"+"RTN_GHIS"+"ITM_GHAT"+"ITM_LOSS") END),0) AS balance
         FROM "MFG_ISU_REC" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND coalesce("LOT_NO",'')=$4 AND coalesce("IT_CODE",'')=$5
          AND NOT ("CO_YEAR"=$6 AND "CO_BOOK"=$7 AND "VCH_NO"=$8)`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      lot,
      item,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (Number(rows[0]?.balance ?? 0) + num(line.netWt) < -0.0005)
      throw new MfgValidationError('voucher metal/stock was consumed by a later voucher');
  }
}

export async function getMfg(prisma: any, scopeInput: VoucherScope, vchNoInput: number | string) {
  const scope = completeScope(scopeInput);
  const vchNo = formatVoucherNo(vchNoInput);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const headerRows: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT *,to_char("VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK" FROM "MFG_DATA"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    if (headerRows.length !== 1) throw new MfgValidationError(`voucher not found: ${vchNo}`);
    const details: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "MFG_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
       AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    const components: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "MFG_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
       AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO","ISR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    const h = headerRows[0]!;
    const lines = details.map((d) => ({
      itCode: d.IT_CODE,
      isuItCode: d.ISU_IT_CODE,
      itemRemark: d.ITM_REMARK,
      lotNo: d.LOT_NO,
      tagNo: d.TAG_NO,
      designNo: d.DESIGN_NO,
      designSrNo: Number(d.DESIGN_SRNO ?? 0),
      size: d.ITM_SIZE,
      pcs: Number(d.ITM_PCS ?? 0),
      grossWt: Number(d.ITM_GWT ?? 0),
      othWt: Number(d.ITM_OTH_WT ?? 0),
      netWt: Number(d.ITM_NWT ?? 0),
      touch: Number(d.ITM_TOUCH ?? 0),
      westPct: Number(d.ITM_WEST_PRC ?? 0),
      fineWt: Number(d.ITM_FINE ?? 0),
      ghtPct: Number(d.ITM_GHT_PRC ?? 0),
      ghtWt: Number(d.ITM_GHT_WT ?? 0),
      rtnChol: Number(d.RTN_CHOL ?? 0),
      rtnGhis: Number(d.RTN_GHIS ?? 0),
      mtrlItCode: d.MTRL_IT_CODE,
      mtrlWt: Number(d.MTRL_WT ?? 0),
      lbrType: d.LBR_TYPE,
      lbrRate: Number(d.LBR_RATE ?? 0),
      lbrAmt: Number(d.LBR_AMT ?? 0),
      othAmt: Number(d.OTH_AMT ?? 0),
      itRate: Number(d.ITM_RATE ?? 0),
      itAmt: Number(d.ITM_AMT ?? 0),
      ordNo: d.ORD_NO,
      ordYrcd: d.ORD_YRCD,
      ordDbcd: d.ORD_DBCD,
      ordSrno: Number(d.ORD_SRNO ?? 0),
      /**
       * P3-1: the reconciliation, karigar-side, old-metal, material and provenance fields.
       *
       * The writer persists every one of these (`:607-643`, `:726-735`) and `MFG_DETL` carries the
       * columns, but the reader omitted them — so they were accepted, stored, and lost on the next
       * save, and no screen could sensibly offer them because a reopen showed nothing. This is the
       * third time in this module family that the WRITE side was complete and the READ side was not.
       *
       * `itmGhat` is receive-only at the writer (`:735` gates it on `ctx.isReceipt`), matching the
       * desktop: filings and polishing dust come back when the ornament is received, not when metal
       * is issued. Reading it unconditionally is still correct — an issue voucher simply returns 0.
       */
      totalGrossWt: Number(d.TOT_GWT ?? 0),
      totalLessWt: Number(d.TOT_LWT ?? 0),
      karigarJobworkWt: Number(d.KR_JDT_WT ?? 0),
      karigarMinorityWt: Number(d.KR_MINO_WT ?? 0),
      karigarMinorityAmount: Number(d.KR_MINO_AMT ?? 0),
      oldGrossWt: Number(d.OLD_GWT ?? 0),
      oldFine: Number(d.OLD_FINE ?? 0),
      oldLabourAmount: Number(d.OLD_LBR_AMT ?? 0),
      oldOther: Number(d.OLD_OTH ?? 0),
      addOtherWt: Number(d.ADD_OTH_WT ?? 0),
      lessOtherWt: Number(d.LESS_OTH_WT ?? 0),
      itmGhat: Number(d.ITM_GHAT ?? 0),
      dmPcs: Number(d.DM_PCS ?? 0),
      dmWt: Number(d.DM_WT ?? 0),
      fittingItCode: d.FTNG_IT_CODE,
      adjustDate: d.ADJ_DATE,
      repYrcd: d.REP_YRCD,
      repDbcd: d.REP_DBCD,
      repNo: d.REP_NO,
      repSrno: Number(d.REP_SRNO ?? 0),
      repAcCode: d.REP_AC_CODE,
      /**
       * Every field `MfgComponent` accepts, not a subset.
       *
       * This mapping used to return 7 of 22, which made the module LOOK safe in a reader audit — it
       * does select MFG_IDTL — while an unchanged save still dropped the labour columns and the whole
       * return/breakage block. `MFG_IDTL` is in the write set, so edit deletes and rebuilds it from
       * the request, and a request built from a 7-field read carries only 7 fields. Selecting a table
       * is half the job; the mapping is the other half. Pinned by the manufacturing case in
       * `test/operatorDepth.roundtrip.db.test.ts`.
       */
      components: components
        .filter((c) => Number(c.SR_NO) === Number(d.SR_NO))
        .map((c) => ({
          vchSrno: Number(c.VCH_SRNO ?? 0) || undefined,
          itCode: c.IT_CODE,
          itType: c.IT_TYPE,
          tagNo: c.TAG_NO,
          pcs: Number(c.IT_PCS ?? 0),
          pcsWt: Number(c.IT_PCS_WT ?? 0),
          grossWt: Number(c.IT_GWT ?? 0),
          conPct: Number(c.IT_CON_PRC ?? 0),
          conWt: Number(c.IT_CON_WT ?? 0),
          rateType: c.IT_RATE_TYPE,
          rate: Number(c.IT_RATE ?? 0),
          amount: Number(c.IT_AMT ?? 0),
          lbrRate: Number(c.IT_LBR_RATE ?? 0),
          lbrAmt: Number(c.IT_LBR_AMT ?? 0),
          netAmt: Number(c.IT_NET_AMT ?? 0),
          oldItmIsu: c.OLD_ITM_ISU,
          rtnPcs: Number(c.RTN_PCS ?? 0),
          rtnWt: Number(c.RTN_GWT ?? 0),
          brokPcs: Number(c.BROK_PCS ?? 0),
          brokWt: Number(c.BROK_WT ?? 0),
        })),
    }));
    // DISPLAY_DATA preserves VCH_TIME/HD_VCH_NO/MAIN_USER in every scoped desktop form; examples:
    // TR_MFG_ISU_REC.cs:5452-5453,5495; TR_MFG_ITEM.cs:6765-6766,6801;
    // TR_MFG_ORD_ISU.cs:5536,5553,5567; TR_MFG_KR_ISU_REC.cs:9024-9025,9060.
    return {
      voucherNo: vchNo,
      hiddenVoucherNo: String(h.HD_VCH_NO ?? ''),
      mainUser: h.MAIN_USER,
      vchClock: h.VCH_CLOCK,
      vchDate: isoDate(h.VCH_DATE),
      partyAc: h.AC_CODE,
      karigarAc: h.KR_CODE,
      empCode: h.EMP_CODE,
      billNo: h.BILL_NO,
      vchDesc: h.VCH_DESC,
      mode: ['I', 'R'].includes(String(h.INOUT_TYPE ?? '').toUpperCase()) ? 'receive' : 'issue',
      labourAmt: Number(h.LBR_AMT ?? 0),
      lines,
    };
  });
}

export async function editMfg(prisma: any, input: MfgLifecycleInput) {
  if (!input.lines?.length) throw new MfgValidationError('at least one line is required');
  const scope = completeScope(input.scope);
  const vchNo = formatVoucherNo(input.vchNo);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const prior = await persistedVoucherHeaderTx(tx, {
      table: 'MFG_DATA',
      scope,
      voucherNo: vchNo,
      extraColumns: ['INOUT_TYPE'],
    });
    const check = async (date: unknown) =>
      assertPeriodOpen(tx, scope.tenantId, {
        ledger: { table: 'AC_DATA', lines: [] },
        writes: [{ table: 'MFG_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: date }] }],
      });
    await check(prior.VCH_DATE);
    await check(requestedDate);
    await assertFiscalDateTx(tx, scope, isoDate(requestedDate));
    await assertMfgReplacementSafeTx(tx, scope, vchNo, input.mode, input.lines);

    const policy = await mfgBookPolicyTx(tx, scope);
    const stage = await getStageTx(tx, scope);
    const hiddenVoucherNo = String(prior.HD_VCH_NO ?? '').trim();
    if (!hiddenVoucherNo) throw new MfgValidationError('persisted voucher has no hidden identity');
    const normalized = {
      ...input,
      scope,
      mainUser: String(prior.MAIN_USER ?? '').trim() || input.mainUser,
      bookName: policy.bookName,
      vchType: policy.vchType,
    };
    const receipt = input.mode === 'receive';
    const ctx = ctxOf(normalized, stage, requestedDate, receipt, hiddenVoucherNo, prior.VCH_CLOCK);
    const key = keyOf(scope, Number(vchNo), receipt ? RECEIPT_BOOK : ISSUE_BOOK);
    const totals = totalsOf(input.lines, {
      cashAmt: input.cashAmt,
      kasarAmt: input.kasarAmt,
      billOs: input.billOs,
    });
    const labourAmt = receipt ? round2(num(input.labourAmt)) : 0;
    const ledger: LedgerLine[] =
      labourAmt > 0
        ? [
            {
              ...key,
              VCH_TYPE: ctx.vchType,
              BOOK_NAME: ctx.bookName,
              AC_CODE: input.labourAc ?? 'LABOUR',
              DR_AMT: labourAmt,
              CR_AMT: 0,
              SIGN: 'D',
            },
            {
              ...key,
              VCH_TYPE: ctx.vchType,
              BOOK_NAME: ctx.bookName,
              AC_CODE: input.karigarAc ?? input.partyAc,
              DR_AMT: 0,
              CR_AMT: labourAmt,
              SIGN: 'C',
            },
          ]
        : [];
    const writes: Write[] = [
      {
        table: 'MFG_DATA',
        rows: [header(key, ctx, { ...totals, lbrAmt: labourAmt || totals.lbrAmt })],
      },
      { table: 'MFG_DETL', rows: detlRows(key, ctx, input.lines) },
      { table: 'MFG_ISU_REC', rows: isuRecRows(key, ctx, input.lines) },
    ];
    const idtl = idtlRows(key, ctx, input.lines);
    if (idtl.length) writes.push({ table: 'MFG_IDTL', rows: idtl });
    const doStock = stage
      ? receipt
        ? stage.stkRec === 'Y'
        : stage.stkIsu === 'Y'
      : input.postStock !== false;
    if (doStock)
      writes.push({
        table: 'MAIN_STOCK',
        rows: stockRows(
          key,
          ctx,
          receipt ? TR_RECEIPT : TR_ISSUE,
          receipt ? SIGN_RECEIPT : SIGN_ISSUE,
          input.lines,
        ),
      });

    // Desktop save first deletes the complete derived write set then rewrites it, without audit:
    // TR_MFG_ISU_REC.cs:5753-5759; TR_MFG_ITEM.cs:7255-7261; TR_MFG_ORD_ISU.cs:5859-5865;
    // TR_MFG_ORD_REC.cs:6668-6674; TR_MFG_WITH_LOT.cs:5946-5952; TR_MFG_GHAT_REC.cs:4575-4580;
    // TR_JDT_REC.cs:6134-6140; TR_MFG_KR_ISU_REC.cs:9460-9466. In all files INSERT INTO
    // DELETE_DATA occurs only in the delete handler, so replacement intentionally inserts zero audits.
    await deleteVoucherWriteSetTx(tx, {
      tables: mfgWriteSet,
      key: { scope, voucherNo: vchNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
    await tempBookRowTx(tx, scope, hiddenVoucherNo, policy.bookName);
    await postVoucherTx(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      writes,
      bookName: policy.bookName,
    });
    return { vchNo: Number(vchNo), updated: true as const };
  });
}

export async function deleteMfg(prisma: any, input: DeleteMfgInput): Promise<{ reversed: true }> {
  const scope = completeScope({ ...input.scope, coBook: input.scope.coBook ?? input.book });
  const vchNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const h = await persistedVoucherHeaderTx(tx, {
      table: 'MFG_DATA',
      scope,
      voucherNo: vchNo,
      extraColumns: ['AC_CODE'],
    });
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [] },
      writes: [{ table: 'MFG_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: h.VCH_DATE }] }],
    });
    await assertMfgReplacementSafeTx(tx, scope, vchNo, 'issue', []);
    const policy = await mfgBookPolicyTx(tx, scope);
    const details: Record<string, unknown>[] = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","IT_CODE","IT_TYPE","ITM_NWT","ITM_FINE" FROM "MFG_DETL"
       WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    const acRows: Array<{ AC_NAME: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE"=$2 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      h.AC_CODE,
    );
    const now = new Date();
    const base = {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: scope.coYear,
      CO_BOOK: scope.coBook,
      VCH_NO: vchNo,
      VCH_DATE: h.VCH_DATE,
      DELETE_DATE: now,
      VCH_TIME: voucherTimestamp(new Date(h.VCH_DATE as any), h.VCH_CLOCK),
      DELETE_TIME: now,
      VCH_TYPE: policy.vchType,
      BOOK_NAME: policy.bookName,
      AC_CODE: h.AC_CODE,
      AC_NAME: acRows[0]?.AC_NAME ?? null,
      HD_VCH_NO: h.HD_VCH_NO,
      MAIN_USER: h.MAIN_USER,
      DELETE_USER: input.deleteUser ?? 'system',
    };
    if (policy.auditShape === 'order-detail') {
      // Exact TR_MFG_ORD_ISU.cs:6301 mapping.
      for (const d of details)
        await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
          ...base,
          SR_NO: d.SR_NO,
          VCH_VAL_DR: 0,
          VCH_VAL_CR: 0,
          FINE_TYPE: d.IT_TYPE,
          VCH_FINE_DR: 0,
          VCH_FINE_CR: d.ITM_NWT,
          VCH_DESC: `ItCode / ${String(d.IT_CODE ?? '')}   TagNo / `,
        });
    } else if (policy.auditShape === 'ghat-detail') {
      // Exact TR_MFG_GHAT_REC.cs:4888 mapping.
      for (const d of details)
        await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
          ...base,
          SR_NO: d.SR_NO,
          VCH_VAL_DR: 0,
          VCH_VAL_CR: 0,
          FINE_TYPE: d.IT_TYPE,
          VCH_FINE_DR: d.ITM_FINE,
          VCH_FINE_CR: 0,
          VCH_DESC: `ItCode/${String(d.IT_CODE ?? '')}`,
        });
    } else {
      // Header audit mapping is identical at TR_MFG_ISU_REC.cs:6089, TR_MFG_ITEM.cs:7573,
      // TR_MFG_ORD_REC.cs:7171, TR_MFG_WITH_LOT.cs:6321, TR_JDT_REC.cs:6432 and
      // TR_MFG_KR_ISU_REC.cs:9935.
      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
        ...base,
        SR_NO: 0,
        VCH_VAL_DR: 0,
        VCH_VAL_CR: 0,
        FINE_TYPE: 'A',
        VCH_FINE_DR: 0,
        VCH_FINE_CR: 0,
        VCH_DESC: '0',
      });
    }
    const ords: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT DISTINCT "ORD_NO" ono,"ORD_SRNO" osr FROM "MFG_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND coalesce("ORD_NO",'')<>''`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      vchNo,
    );
    await deleteVoucherWriteSetTx(tx, {
      tables: mfgWriteSet,
      key: { scope, voucherNo: vchNo },
      tempBook: { voucherNo: String(h.HD_VCH_NO ?? '') },
    });
    for (const o of ords)
      await tx.$executeRawUnsafe(
        `UPDATE "SL_ORD_DETL" SET "DESIGN_ISU"='N' WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "VCH_NO"=$3 AND "SR_NO"=$4`,
        scope.tenantId,
        scope.coCode,
        String(o.ono ?? ''),
        Number(o.osr ?? 0),
      );
    return { reversed: true };
  });
}
