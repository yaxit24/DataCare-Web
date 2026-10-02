import { withTxBudget } from '../shared/txBudget.js';
import {
  DEFAULT_INT_YEAR_DAYS,
  desktopDhrnInterest,
  interestTypeForBook,
  resolveSettingsBehaviorTx,
  type SettingsBehavior,
} from '../shared/settingsBehavior.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  postVoucherTx,
  reverseVoucherTx,
  assertBalanced,
  type LedgerLine,
} from '../posting/posting.js';

import {
  completeFinanceScope,
  configuredBookTx,
  createIdentityTx,
  editIdentityTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  num as lifecycleNum,
  voucherKey,
  type VoucherIdentity,
} from '../finance/lifecycle.js';
/**
 * Dhrn (pledge loan / "Dharna"): money lent against pledged gold/silver ornaments. Issue pays cash
 * out and books a receivable; receipts repay principal + interest and release ornaments.
 * Interest formula is the desktop's (RP_DHRN_OS.cs): outstandingPrincipal × INT_PRC/100 × days/yearDays
 * (annual rate, day-count basis). Outstanding = issue principal − Σ receipts (per ISU_NO).
 */

export class DhrnValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'DhrnValidationError';
  }
}

/** Day-count basis (desktop global MsIntYearDays). Conventionally 360; confirm at parity Task 30. */
export const DEFAULT_YEAR_DAYS = DEFAULT_INT_YEAR_DAYS;

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;

/** Accrued simple interest on outstanding principal (RP_DHRN_OS.cs parity). */
export function accruedInterest(
  outstandingPrincipal: number,
  annualRatePct: number,
  days: number,
  yearDays = DEFAULT_YEAR_DAYS,
): number {
  if (yearDays <= 0) throw new DhrnValidationError('yearDays must be positive');
  return round2(outstandingPrincipal * (annualRatePct / 100) * (days / yearDays));
}

/** Indicative monthly interest (issue-time MONTH_INT_AMT) on the same day-count basis (30-day month). */
export function monthlyInterest(
  principal: number,
  annualRatePct: number,
  yearDays = DEFAULT_YEAR_DAYS,
): number {
  return accruedInterest(principal, annualRatePct, 30, yearDays);
}

/**
 * Monthly-term interest = principal × monthlyRate% × months. This is the desktop's primary mode:
 * CO_SET.DHRN_INT_TYPE / LOAN_INT_TYPE = 'M' (confirmed vs Next24 golden-master, INT_YEAR_DAYS=0),
 * where INT_PRC is a per-month rate.
 */
export function monthlyTermInterest(
  principal: number,
  monthlyRatePct: number,
  months: number,
): number {
  return round2(principal * (monthlyRatePct / 100) * months);
}

export type InterestType = 'M' | 'D'; // CO_SET.DHRN_INT_TYPE: 'M' monthly (default), 'D' day-count
export type DhrnEntryType = 'D' | 'L';
type DhrnIssueLedgerMode = 'pledge-issue' | 'loan-received';
type DhrnReceiptLedgerMode = 'pledge-receipt' | 'loan-issue';
type DhrnBook = Awaited<ReturnType<typeof configuredBookTx>>;

function normalized(value: unknown): string {
  return String(value ?? '')
    .trim()
    .toUpperCase();
}

function assertDhrnBook(
  book: DhrnBook,
  expectedMainBook?: string,
  expectedInout?: 'I' | 'O',
): void {
  if (expectedMainBook && normalized(book.mainBook) !== normalized(expectedMainBook)) {
    throw new DhrnValidationError(
      `book is ${book.mainBook || book.name || 'blank'}, expected ${expectedMainBook}`,
    );
  }
  if (expectedInout && normalized(book.inout) !== expectedInout) {
    throw new DhrnValidationError(
      `book direction is ${book.inout || 'blank'}, expected ${expectedInout}`,
    );
  }
}

function desktopDhrnBookName(book: DhrnBook, entryType: DhrnEntryType): string {
  return entryType === 'L' ? book.mainBook || book.name : book.name;
}

/** Interest dispatcher honouring the desktop CO_SET interest type. */
export function dhrnInterest(args: {
  type: InterestType;
  principal: number;
  ratePct: number;
  months?: number;
  days?: number;
  yearDays?: number;
}): number {
  if (args.type === 'M') return monthlyTermInterest(args.principal, args.ratePct, args.months ?? 0);
  return accruedInterest(
    args.principal,
    args.ratePct,
    args.days ?? 0,
    args.yearDays ?? DEFAULT_YEAR_DAYS,
  );
}

/**
 * Whole-month bucketing for pledge interest (desktop convention): months between two dates, rounding
 * ANY partial month UP to a full month, 1-month minimum. e.g. 15-Jan→14-Feb = 1; 15-Jan→16-Feb = 2.
 * Converts an issue→collection date span into the INT_MONTH count for monthly-term ('M') interest.
 */
export function monthsBetween(from: Date | string, to: Date | string): number {
  const a = new Date(from);
  const b = new Date(to);
  let months = (b.getFullYear() - a.getFullYear()) * 12 + (b.getMonth() - a.getMonth());
  if (b.getDate() > a.getDate()) months += 1; // any part of a further month counts as a full month
  return Math.max(1, months);
}

/** Monthly-term interest over a date span using whole-month bucketing (monthsBetween). */
export function termInterestBetween(
  principal: number,
  monthlyRatePct: number,
  from: Date | string,
  to: Date | string,
): number {
  return monthlyTermInterest(principal, monthlyRatePct, monthsBetween(from, to));
}

/** Whole days between two dates (>=0), used for day-count ('D') interest. */
export function daysBetween(from: Date | string, to: Date | string): number {
  const ms = new Date(to).getTime() - new Date(from).getTime();
  return Math.max(0, Math.round(ms / 86400000));
}

/** Round dhrn interest by loan type (desktop rule): cash 'A' → whole rupees (0 dp); metal 'G'/'S' → 3 dp fine. */
export function roundInterestByLoanType(amount: number, loanType: string | undefined): number {
  const lt = String(loanType ?? 'A')
    .trim()
    .toUpperCase();
  if (lt === 'G' || lt === 'S') return Math.round((amount + Number.EPSILON) * 1000) / 1000;
  return Math.round(amount + Number.EPSILON); // cash: whole rupees
}

/** Strict transaction-scoped loader for INT_YEAR_DAYS, INT_DAY, LOAN_INT_TYPE and
 * DHIRN_COMPOUND. Desktop sources: MS_OPNCOMP.cs:680-697 and defaults :777-843. */
async function dhrnConfigTx(tx: any, tenantId: string, coCode: unknown): Promise<SettingsBehavior> {
  return resolveSettingsBehaviorTx(tx, { tenantId, coCode: String(coCode ?? '') });
}

/**
 * Accrued interest on a Dhrn issue's OUTSTANDING principal as of `asOf`, honouring the company's
 * CO_SET interest type + year-days and the per-loan-type rounding — desktop TR_DHRN_REC/INTREC
 * BILL_TOTAL parity. Used by the endpoints when the operator does not override the interest amount.
 */
async function computeDhrnInterestTx(
  tx: any,
  scope: VoucherScope,
  isuNo: number | string,
  asOf?: Date | string,
): Promise<number> {
  const rows: any[] = await tx.$queryRawUnsafe(
    `SELECT "VCH_DATE"::text d, coalesce("INT_PRC",0)::float rate, coalesce("LOAN_TYPE",'A') lt FROM "DHRN_ISU_DATA" WHERE "VCH_NO"=$1 AND "CO_CODE"=$2 LIMIT 1`,
    formatVoucherNo(isuNo),
    scope.coCode,
  );
  const issue = rows[0];
  if (!issue) return 0;
  const outstandingPrincipal = await outstandingTx(tx, scope, isuNo);
  if (!(outstandingPrincipal > 0)) return 0;
  const cfg = await dhrnConfigTx(tx, scope.tenantId, scope.coCode);
  // Book-driven interest type (TR_DHRN_REC.cs:5626-5643 / TR_DHRN_INTREC.cs:4265-4280).
  const bookForInterest = await configuredBookTx(tx, scope);
  const interestSettings = {
    ...cfg,
    loanIntType: interestTypeForBook(cfg, bookForInterest.mainBook),
  };
  const issueDate = issue.d ? new Date(issue.d) : new Date();
  const asOfDate = asOf ? new Date(asOf) : new Date();
  return desktopDhrnInterest({
    principal: outstandingPrincipal,
    annualRatePct: Number(issue.rate),
    from: issueDate,
    to: asOfDate,
    settings: interestSettings,
    loanType: String(issue.lt ?? 'A'),
  });
}

/** Issue ledger: Dr loan-receivable / Cr cash (principal). */
export function buildDhrnIssueLedger(
  key: VoucherKey,
  loanAc: string,
  cashAc: string,
  principal: number,
): LedgerLine[] {
  const base = { ...key, VCH_TYPE: 'DISU' };
  return [
    { ...base, AC_CODE: loanAc, LD_CODE: cashAc, DR_AMT: principal, CR_AMT: 0, SIGN: 'D' },
    { ...base, AC_CODE: cashAc, LD_CODE: loanAc, DR_AMT: 0, CR_AMT: principal, SIGN: 'C' },
  ];
}

/** Loan Received (TR_DHRN_ISU + MAIN_BOOK LOAN REC): Dr settlement / Cr lender. */
function buildLoanReceivedLedger(
  key: VoucherKey,
  lenderAc: string,
  cashAc: string,
  principal: number,
): LedgerLine[] {
  const base = { ...key, VCH_TYPE: 'LONRC' };
  return [
    { ...base, AC_CODE: lenderAc, LD_CODE: cashAc, DR_AMT: 0, CR_AMT: principal, SIGN: 'C' },
    { ...base, AC_CODE: cashAc, LD_CODE: lenderAc, DR_AMT: principal, CR_AMT: 0, SIGN: 'D' },
  ];
}

/** Receipt ledger: Dr cash (principal+interest) / Cr loan-receivable (principal) / Cr interest-income. */
export function buildDhrnReceiptLedger(
  key: VoucherKey,
  loanAc: string,
  cashAc: string,
  intIncAc: string,
  principalRepaid: number,
  interest: number,
): LedgerLine[] {
  const base = { ...key, VCH_TYPE: 'DREC' };
  const lines: LedgerLine[] = [
    {
      ...base,
      AC_CODE: cashAc,
      LD_CODE: loanAc,
      DR_AMT: round2(principalRepaid + interest),
      CR_AMT: 0,
      SIGN: 'D',
    },
    { ...base, AC_CODE: loanAc, LD_CODE: cashAc, DR_AMT: 0, CR_AMT: principalRepaid, SIGN: 'C' },
  ];
  if (interest > 0)
    lines.push({
      ...base,
      AC_CODE: intIncAc,
      LD_CODE: cashAc,
      DR_AMT: 0,
      CR_AMT: interest,
      SIGN: 'C',
    });
  return lines;
}

/** Loan Issue (TR_DHRN_REC + MAIN_BOOK LOAN ISSUE): Dr lender/principal and interest, Cr settlement. */
function buildLoanIssueLedger(
  key: VoucherKey,
  lenderAc: string,
  cashAc: string,
  intExpenseAc: string,
  principalIssued: number,
  interest: number,
): LedgerLine[] {
  const base = { ...key, VCH_TYPE: 'LONIS' };
  const lines: LedgerLine[] = [
    { ...base, AC_CODE: lenderAc, LD_CODE: cashAc, DR_AMT: principalIssued, CR_AMT: 0, SIGN: 'D' },
  ];
  if (interest > 0) {
    lines.push({
      ...base,
      AC_CODE: intExpenseAc,
      LD_CODE: cashAc,
      DR_AMT: interest,
      CR_AMT: 0,
      SIGN: 'D',
    });
  }
  lines.push({
    ...base,
    AC_CODE: cashAc,
    LD_CODE: lenderAc,
    DR_AMT: 0,
    CR_AMT: round2(principalIssued + interest),
    SIGN: 'C',
  });
  return lines;
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

export interface DhrnCollateral {
  // ---- Pledge linkage and item identity (DHRN_ISU_DETL) -----------------------------------------
  custName?: string; // CUST_NAME — TR_DHRN_ISU grid col 2
  dhrnDbcd?: string; // DHRN_DBCD — grid col 25
  dhrnNo?: string; // DHRN_NO   — grid col 23
  dhrnYrcd?: string; // DHRN_YRCD — grid col 24
  huid?: string; // HM_ID
  itType?: string; // IT_TYPE
  rateType?: string; // RATE_TYPE
  oldSrNo?: number; // OLD_SRNO
  receivedNetWt?: number; // REC_NWT
  itCode?: string;
  itName?: string;
  itDesc?: string;
  pcs?: number;
  grossWt?: number;
  otherWt?: number;
  netWt?: number;
  touch?: number;
  westPct?: number;
  fineWt?: number;
  rate?: number;
  amount?: number;
  packet?: string;
}

export interface DhrnIssueInput {
  // ---- Pledge metadata (DHRN_DATA) ---------------------------------------------------------------
  licenceNo?: string; // DHRN_LIC_NO — the pawnbroking licence the pledge was booked under
  remarks?: string; // REMARKS
  adjustedDhrn?: number; // ADJ_DHRN
  uncheckedReceipts?: number; // UNCHAK_DHRN_REC
  scope: VoucherScope;
  entryType?: DhrnEntryType;
  expectedMainBook?: string;
  expectedBookInout?: 'I' | 'O';
  ledgerMode?: DhrnIssueLedgerMode;
  borrowerAc: string;
  borrowerName?: string;
  principal: number; // DHRN_AMT
  intPrc?: number; // absent uses configured CO_SET.DHRN_PRC; blank setting preserves required behavior
  intMonths?: number; // INT_MONTH (interest period in months)
  loanType?: 'A' | 'G' | 'S'; // amount / gold / silver
  packetNo?: string;
  otherCharges?: number;
  goldWt?: number;
  goldAmt?: number;
  vchDate?: Date | string;
  fromDate?: Date | string;
  toDate?: Date | string;
  loanAc?: string; // receivable ledger (default 'DHRN')
  cashAc?: string; // funding ledger (default 'CASH')
  mainUser?: string;
  collateral?: DhrnCollateral[]; // pledged ornaments grid → DHRN_ISU_DETL
}

export async function issueDhrn(
  prisma: any,
  input: DhrnIssueInput,
  context?: { tx: any; identity: VoucherIdentity },
): Promise<{ vchNo: number; monthInt: number; intAmt: number }> {
  completeFinanceScope(input.scope);
  if (!input.borrowerAc) throw new DhrnValidationError('borrower account is required');
  if (!(input.principal > 0)) throw new DhrnValidationError('principal must be positive');
  const date = input.vchDate
    ? new Date(input.vchDate)
    : input.fromDate
      ? new Date(input.fromDate)
      : new Date();
  const run = async (tx: any, identity: VoucherIdentity) => {
    const loanAc = (input.loanAc ?? '').trim() || input.borrowerAc;
    const cashAc = input.cashAc ?? 'CASH';
    const book = await configuredBookTx(tx, input.scope);
    assertDhrnBook(book, input.expectedMainBook, input.expectedBookInout);
    const entryType = input.entryType ?? 'D';
    const inoutType = input.expectedBookInout ?? ((book.inout as 'I' | 'O' | '') || 'O');
    const bookName = desktopDhrnBookName(book, entryType);
    const N = (v: unknown): number => (v == null ? 0 : Number(v));
    const text = (v: unknown, len: number): string | null =>
      String(v ?? '')
        .trim()
        .slice(0, len) || null;
    const months = N(input.intMonths);
    const cfg = await dhrnConfigTx(tx, input.scope.tenantId, input.scope.coCode);
    // TR_DHRN_ISU.cs:4787: company DHRN_PRC supplies the issue rate when the operator omits it.
    const issueRate = input.intPrc ?? cfg.dhrnDefaultRate;
    if (issueRate == null)
      throw new DhrnValidationError('intPrc is required when CO_SET.DHRN_PRC is blank');
    const interestBase = {
      principal: input.principal,
      annualRatePct: issueRate,
      from: date,
      to: input.toDate ? new Date(input.toDate) : date,
      settings: {
        ...cfg,
        // Book-driven interest type (TR_DHRN_REC.cs:5626-5643, TR_DHRN_INTREC.cs:4265-4280).
        loanIntType: interestTypeForBook(cfg, book.mainBook),
      },
      loanType: input.loanType ?? 'A',
    } as const;
    const monthInt = desktopDhrnInterest({ ...interestBase, months: 1 });
    const intAmt = months > 0 ? desktopDhrnInterest({ ...interestBase, months }) : 0;
    const coll = input.collateral ?? [];
    const goldAmt = input.goldAmt ?? round2(coll.reduce((s, c) => s + N(c.amount), 0));
    const goldWt = input.goldWt ?? round2(coll.reduce((s, c) => s + N(c.grossWt), 0));
    const goldNwt = round2(coll.reduce((s, c) => s + N(c.netWt), 0));
    const goldDesc = coll
      .map(
        (c) =>
          `${c.itDesc ?? c.itName ?? c.itCode ?? ''}, N ${N(c.netWt)} / T ${N(c.touch)} / F ${N(c.fineWt)}`,
      )
      .join(', ')
      .slice(0, 255);
    const key = voucherKey(input.scope, identity.voucherNo);
    const ledgerBuilder =
      input.ledgerMode === 'loan-received'
        ? buildLoanReceivedLedger(key, input.borrowerAc, cashAc, input.principal)
        : buildDhrnIssueLedger(key, loanAc, cashAc, input.principal);
    const ledger = ledgerBuilder.map((l) => ({
      ...l,
      VCH_TYPE: book.shortName,
      VCH_DATE: identity.voucherDate,
    }));
    assertBalanced(ledger);
    const common = {
      ...key,
      VCH_TYPE: book.shortName,
      INOUT_TYPE: inoutType,
      ENTRY_TYPE: entryType,
      BOOK_NAME: bookName,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      HD_VCH_NO: identity.hiddenVoucherNo,
      MAIN_USER: identity.mainUser || null,
      DATA_TRFR: 'N',
    };
    const header = {
      ...common,
      AC_CODE: input.borrowerAc,
      AC_NAME: input.borrowerName ?? null,
      LEDR_ACCD: loanAc,
      LOAN_TYPE: input.loanType ?? 'A',
      DHRN_AMT: input.principal,
      DHRN_REC_AMT: 0,
      INT_PRC: issueRate,
      INT_MONTH: months,
      MONTH_INT_AMT: monthInt,
      INT_AMT: intAmt,
      INT_REC_AMT: round2(intAmt + N(input.otherCharges)),
      OTH_AMT: N(input.otherCharges),
      PACKET_NO: input.packetNo ?? null,
      ISU_REC: 'N',
      GOLD_AMT: goldAmt,
      GOLD_WT: goldWt,
      GOLD_NWT: goldNwt,
      GOLD_DESC: goldDesc,
      TO_DATE: input.toDate ? new Date(input.toDate) : null,
    };
    const detl = coll.map((c, i) => ({
      ...common,
      SR_NO: i + 1,
      AC_CODE: input.borrowerAc,
      IT_CODE: c.itCode ?? null,
      IT_NAME: c.itName ?? c.itDesc ?? null,
      IT_DESC: c.itDesc ?? null,
      ITM_PCS: N(c.pcs),
      ITM_GWT: N(c.grossWt),
      ITM_OTH_WT: N(c.otherWt),
      ITM_NWT: N(c.netWt),
      ITM_TOUCH: N(c.touch),
      ITM_WEST_PRC: N(c.westPct),
      ITM_FINE: N(c.fineWt),
      ITM_RATE: N(c.rate),
      ITM_AMT: N(c.amount),
      NET_AMT: N(c.amount),
      PACKET_NO: c.packet ?? input.packetNo ?? null,
      PACKET_REC: 'N',
      // TR_DHRN_ISU.cs also carries the pledge LINKAGE and the item's identity on each collateral row:
      // the customer's own name (grid col 2) and the dhiran key (cols 23/24/25) that ties this ornament
      // back to its pledge, plus the hallmark id, metal type, rate basis and source line.
      CUST_NAME: text(c.custName ?? input.borrowerName, 50),
      DHRN_DBCD: text(c.dhrnDbcd ?? input.scope.coBook, 3),
      DHRN_NO: text(c.dhrnNo, 10),
      DHRN_YRCD: text(c.dhrnYrcd ?? input.scope.coYear, 10),
      HM_ID: text(c.huid, 10),
      IT_TYPE: text(c.itType, 1),
      RATE_TYPE: text(c.rateType, 1),
      OLD_SRNO: N(c.oldSrNo),
      REC_NWT: N(c.receivedNetWt),
    }));
    const movement = {
      ...common,
      SR_NO: 1,
      FROM_DATE: identity.voucherDate,
      TO_DATE: input.toDate ? new Date(input.toDate) : null,
      AC_CODE: input.borrowerAc,
      DHRN_AMT: input.principal,
      DHRN_REC_AMT: 0,
      INT_PRC: issueRate,
      INT_AMT: intAmt,
      INT_REC_AMT: 0,
      ISU_NO: identity.voucherNo,
      ISU_LC: input.scope.lcCode,
      ISU_YRCD: input.scope.coYear ?? null,
      ISU_DBCD: input.scope.coBook,
      GOLD_AMT: goldAmt,
      INT_DAYS: months * 30,
      LOAN_TYPE: input.loanType ?? 'A',
      // TR_DHRN_ISU/REC carry the pledge licence number, free-text remarks, the adjusted-dhiran amount and
      // the unchecked-receipt counter. REC_DATE stays null on issue: it is set when the pledge is received
      // back, so filling it here would claim a redemption that has not happened.
      DHRN_LIC_NO: text(input.licenceNo, 15),
      REMARKS: text(input.remarks, 255),
      ADJ_DHRN: N(input.adjustedDhrn),
      UNCHAK_DHRN_REC: N(input.uncheckedReceipts),
      REC_DATE: null,
    };
    await insertHiddenIdentityTx(tx, input.scope, identity, book.name);
    await postVoucherTx(tx, input.scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName,
      writes: [
        { table: 'DHRN_ISU_DATA', rows: [header] },
        ...(detl.length ? [{ table: 'DHRN_ISU_DETL', rows: detl }] : []),
        { table: 'DHRN_DATA', rows: [movement] },
      ],
    });
    return { vchNo: identity.vchNo, monthInt, intAmt };
  };
  if (context) return run(context.tx, context.identity);
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx) =>
    run(tx, await createIdentityTx(tx, input.scope, date, input.mainUser)),
  );
}

export interface DhrnReceiptInput {
  scope: VoucherScope;
  entryType?: DhrnEntryType;
  expectedMainBook?: string;
  expectedBookInout?: 'I' | 'O';
  ledgerMode?: DhrnReceiptLedgerMode;
  isuNo: number | string; // the issue VCH_NO this repayment is against
  borrowerAc: string;
  borrowerName?: string;
  principalRepaid: number;
  interest?: number; // collected interest; omit to auto-compute from issue rate × elapsed period × CO_SET
  intPrc?: number;
  loanAc?: string;
  cashAc?: string;
  intIncAc?: string; // interest-income ledger (default 'INTINC')
  mainUser?: string;
  vchDate?: Date | string;
  /**
   * Desktop DHRN_REC_DATA header fields (TR_DHRN_REC.cs:6142-6205). Blank desktop fields persist as
   * ''/0, which an absent input reproduces.
   */
  billNo?: string; // tBillNo.Text        :6149
  fromDate?: Date | string; // mFromDate.Text      :6153
  toDate?: Date | string; // mToDate.Text        :6154
  packetNo?: string; // tPacketNo.Text      :6167
  dhrnDate?: Date | string; // mIsuDate.Text       :6168
  loanType?: string; // cboLoanType first   :6169
  dhrnAdjustAmount?: number; // nDhrnAdjAmt.Text    :6171
  advanceDhiranReceipt?: number; // nAdvanceDhiran.Text :6172
  dhrnMonths?: number; // nDhrnMonth.Text     :6175
  interestKasar?: number; // nIntKasr.Text       :6176
  interestDays?: number; // nIntDays.Text       :6177
  interestMonths?: number; // nIntMonth.Text      :6181
  empCode?: string; // tEmpCode.Text       :6183
  goldAmount?: number; // MSG_TOT[0,14]       :6184
  goldWeight?: number; // MSG_TOT[0,6]        :6185
  vchDesc?: string; // tVchDesc            :6190
  panAdjustAmount?: number; // nPanIntAmt.Text     :6191
  adjustInterest?: number; // nAdjInt.Text        :6192
  adjustDhiran?: number; // nAdjDhiran.Text     :6193
  rateCutRate?: number; // nFineRate.Text      :6197
  rateCutAmount?: number; // nRcutAmt.Text       :6198
  rateCutPayAmount?: number; // nPayAmt.Text        :6199
  rateCutOsAmount?: number; // nOsAmt.Text         :6200
  /**
   * Pledged items released by this receipt → DHRN_REC_DETL (TR_DHRN_REC.cs:6212-6272, `mSG` grid).
   * The desktop writes no detail rows when the grid is empty.
   */
  items?: DhrnReceiptItem[];
  /**
   * Book/year of the issue voucher being repaid. Defaults to the receipt scope, preserving the
   * previous behaviour for single-book setups; supply them when the pledge issue lives in its own
   * book, which is what the desktop join relies on (DHRN_ISU_DATA.CO_BOOK = receipt.ISU_DBCD).
   */
  isuBook?: string;
  isuYear?: string;
}

/** One DHRN_REC_DETL row (TR_DHRN_REC.cs:6241-6266, `mSG[i, c]` grid ordinals). */
export interface DhrnReceiptItem {
  srNo?: number; // mSG[i,0]  SR_NO / OLD_SRNO
  packetNo?: string; // mSG[i,1]  PACKET_NO
  custName?: string; // mSG[i,2]  CUST_NAME
  itCode?: string; // mSG[i,3]  IT_CODE
  itName?: string; // mSG[i,4]  IT_NAME
  pcs?: number; // mSG[i,5]  ITM_PCS
  grossWt?: number; // mSG[i,6]  ITM_GWT
  otherWt?: number; // mSG[i,7]  ITM_OTH_WT
  netWt?: number; // mSG[i,8]  ITM_NWT
  touch?: number; // mSG[i,9]  ITM_TOUCH
  westPct?: number; // mSG[i,10] ITM_WEST_PRC
  fineWt?: number; // mSG[i,11] ITM_FINE
  rate?: number; // mSG[i,12] ITM_RATE
  amount?: number; // mSG[i,13] ITM_AMT
  netAmount?: number; // mSG[i,14] NET_AMT
  itType?: string; // mSG[i,16] IT_TYPE
  rateType?: string; // mSG[i,17] RATE_TYPE
  itDesc?: string; // mSG[i,18] IT_DESC (desktop truncates at 249)
  isuNo?: string; // mSG[i,24] ISU_NO
  isuYrcd?: string; // mSG[i,25] ISU_YRCD
  isuDbcd?: string; // mSG[i,26] ISU_DBCD
  isuSrno?: number; // mSG[i,27] ISU_SRNO
  /** REC_NWT / REC_QTY — what was actually received back, which can be less than pledged. */
  receivedNetWt?: number;
  receivedQty?: number;
}

/** Desktop text fields persist trimmed and bounded by the column width; blank ⇒ null. */
const txtR = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;
/** Desktop numeric fields persist 0 when blank. */
const n2 = (v: unknown): number => (v == null ? 0 : Number(v));
const dateOrNull = (v: unknown): Date | null => (v ? new Date(v as string) : null);

export async function receiveDhrn(
  prisma: any,
  input: DhrnReceiptInput,
  context?: { tx: any; identity: VoucherIdentity },
): Promise<{ vchNo: number; outstanding: number }> {
  completeFinanceScope(input.scope);
  if (!(input.principalRepaid >= 0))
    throw new DhrnValidationError('principal repaid must be non-negative');
  const date = input.vchDate ? new Date(input.vchDate) : new Date();
  const run = async (tx: any, identity: VoucherIdentity) => {
    const loanAc = (input.loanAc ?? '').trim() || input.borrowerAc;
    const cashAc = input.cashAc ?? 'CASH';
    const intIncAc = input.intIncAc ?? 'INTINC';
    const entryType = input.entryType ?? 'D';
    const before = await outstandingTx(tx, input.scope, input.isuNo, {
      isuBook: input.isuBook,
      isuYear: input.isuYear,
      entryType,
    });
    if (input.principalRepaid > before + 1e-6)
      throw new DhrnValidationError(
        `principal repaid (${input.principalRepaid}) exceeds outstanding (${before})`,
      );
    const interest =
      input.interest != null && Number.isFinite(input.interest)
        ? round2(input.interest)
        : await computeDhrnInterestTx(tx, input.scope, input.isuNo, date);
    if (!(interest >= 0) || input.principalRepaid + interest <= 0)
      throw new DhrnValidationError('repayment must be positive and interest non-negative');
    const newOs = round2(before - input.principalRepaid);
    const book = await configuredBookTx(tx, input.scope);
    assertDhrnBook(book, input.expectedMainBook, input.expectedBookInout);
    const inoutType = input.expectedBookInout ?? ((book.inout as 'I' | 'O' | '') || 'I');
    const bookName = desktopDhrnBookName(book, entryType);
    const key = voucherKey(input.scope, identity.voucherNo);
    const ledgerBuilder =
      input.ledgerMode === 'loan-issue'
        ? buildLoanIssueLedger(
            key,
            input.borrowerAc,
            cashAc,
            intIncAc,
            input.principalRepaid,
            interest,
          )
        : buildDhrnReceiptLedger(key, loanAc, cashAc, intIncAc, input.principalRepaid, interest);
    const ledger = ledgerBuilder.map((l) => ({
      ...l,
      VCH_TYPE: book.shortName,
      VCH_DATE: identity.voucherDate,
    }));
    assertBalanced(ledger);
    const common = {
      ...key,
      VCH_TYPE: book.shortName,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      INOUT_TYPE: inoutType,
      ENTRY_TYPE: entryType,
      BOOK_NAME: bookName,
      HD_VCH_NO: identity.hiddenVoucherNo,
      MAIN_USER: identity.mainUser || null,
      DATA_TRFR: 'N',
    };
    // The issue voucher's book/year: desktop stores them on the receipt and joins the issue row by
    // them (TR_DHRN_REC.cs:6300). Defaults keep single-book behaviour unchanged.
    const isuBook = input.isuBook ?? input.scope.coBook;
    const isuYear = input.isuYear ?? input.scope.coYear;
    const row = {
      ...common,
      AC_CODE: input.borrowerAc,
      AC_NAME: input.borrowerName ?? null,
      LEDR_ACCD: loanAc,
      ISU_NO: formatVoucherNo(input.isuNo),
      ISU_LC: input.scope.lcCode,
      ISU_YRCD: isuYear ?? null,
      ISU_DBCD: isuBook,
      DHRN_AMT: input.principalRepaid,
      DHRN_REC_AMT: input.principalRepaid,
      INT_AMT: interest,
      INT_REC_AMT: interest,
      INT_PRC: input.intPrc ?? 0,
      DHRN_OS_AMT: newOs,
      // Desktop DHRN_REC_DATA columns (TR_DHRN_REC.cs:6149-6204).
      DHRN_BILL: txtR(input.billNo, 10), // tBillNo.Text        :6149
      FROM_DATE: dateOrNull(input.fromDate), // mFromDate.Text      :6153
      TO_DATE: dateOrNull(input.toDate), // mToDate.Text        :6154
      DHRN_LIC_NO: '', // literal            :6166
      PACKET_NO: txtR(input.packetNo, 10), // tPacketNo.Text      :6167
      DHRN_DATE: dateOrNull(input.dhrnDate), // mIsuDate.Text       :6168
      LOAN_TYPE: txtR(input.loanType, 1), // cboLoanType         :6169
      DHRN_ADJ_AMT: n2(input.dhrnAdjustAmount), // nDhrnAdjAmt.Text    :6171
      UNCHAK_DHRN_REC: n2(input.advanceDhiranReceipt), // nAdvanceDhiran.Text :6172
      DHRN_MONTH: n2(input.dhrnMonths), // nDhrnMonth.Text     :6175
      KASAR_AMT: n2(input.interestKasar), // nIntKasr.Text       :6176
      INT_DAY: n2(input.interestDays), // nIntDays.Text       :6177
      INT_MONTH: n2(input.interestMonths), // nIntMonth.Text      :6181
      EMP_CODE: txtR(input.empCode, 3), // tEmpCode.Text       :6183
      GOLD_AMT: n2(input.goldAmount), // MSG_TOT[0,14]       :6184
      GOLD_WT: n2(input.goldWeight), // MSG_TOT[0,6]        :6185
      VCH_DESC: txtR(input.vchDesc, 150), // tVchDesc            :6190
      PAN_ADJ_AMT: n2(input.panAdjustAmount), // nPanIntAmt.Text     :6191
      ADJ_INT: n2(input.adjustInterest), // nAdjInt.Text        :6192
      ADJ_DHRN: n2(input.adjustDhiran), // nAdjDhiran.Text     :6193
      RCUT_RATE: n2(input.rateCutRate), // nFineRate.Text      :6197
      RCUT_AMT: n2(input.rateCutAmount), // nRcutAmt.Text       :6198
      RCUT_PAY_AMT: n2(input.rateCutPayAmount), // nPayAmt.Text        :6199
      RCUT_OS_AMT: n2(input.rateCutOsAmount), // nOsAmt.Text         :6200
      USER_UPDATE: 'N', // literal            :6203
      USER_DELETE: 'N', // literal            :6204
    };
    const movement = {
      ...common,
      SR_NO: 1,
      INOUT_TYPE: inoutType,
      ENTRY_TYPE: entryType,
      AC_CODE: input.borrowerAc,
      DHRN_AMT: 0,
      DHRN_REC_AMT: input.principalRepaid,
      INT_PRC: input.intPrc ?? 0,
      INT_AMT: interest,
      INT_REC_AMT: interest,
      ISU_NO: formatVoucherNo(input.isuNo),
      ISU_LC: input.scope.lcCode,
      ISU_YRCD: isuYear ?? null,
      ISU_DBCD: isuBook,
      LOAN_TYPE: txtR(input.loanType, 1) ?? 'A',
    };
    // DHRN_REC_DETL: the pledged items released by this receipt (TR_DHRN_REC.cs:6212-6272).
    // Header-derived columns come from the book and scope; an empty grid writes no rows.
    const recDetl = (input.items ?? []).map((item, idx) => ({
      ...common,
      SR_NO: item.srNo ?? idx + 1, // mSG[i,0]  :6241
      OLD_SRNO: item.srNo ?? idx + 1, // mSG[i,0]  :6242
      INOUT_TYPE: inoutType, // FormBookInOut :6231
      ENTRY_TYPE: entryType, // desktop: D for Dhiran receipt, L for Loan Issue
      AC_CODE: input.borrowerAc, // tAcCode.Text  :6229
      PACKET_NO: txtR(item.packetNo, 10), // mSG[i,1]  :6243
      CUST_NAME: txtR(item.custName, 50), // mSG[i,2]  :6244
      IT_CODE: txtR(item.itCode, 10), // mSG[i,3]  :6245
      IT_NAME: txtR(item.itName, 50), // mSG[i,4]  :6246
      ITM_PCS: n2(item.pcs), // mSG[i,5]  :6247
      ITM_GWT: n2(item.grossWt), // mSG[i,6]  :6248
      ITM_OTH_WT: n2(item.otherWt), // mSG[i,7]  :6249
      ITM_NWT: n2(item.netWt), // mSG[i,8]  :6250
      ITM_TOUCH: n2(item.touch), // mSG[i,9]  :6251
      ITM_WEST_PRC: n2(item.westPct), // mSG[i,10] :6252
      ITM_FINE: n2(item.fineWt), // mSG[i,11] :6253
      ITM_RATE: n2(item.rate), // mSG[i,12] :6254
      ITM_AMT: n2(item.amount), // mSG[i,13] :6255
      NET_AMT: n2(item.netAmount), // mSG[i,14] :6256
      IT_DESC: txtR(item.itDesc, 249), // mSG[i,18] :6257 (desktop truncates at 249)
      RATE_TYPE: txtR(item.rateType, 1), // mSG[i,17] :6258
      IT_TYPE: txtR(item.itType, 1), // mSG[i,16] :6259
      ISU_LC: input.scope.lcCode, // MLc_code  :6262
      ISU_NO: txtR(item.isuNo, 10) ?? formatVoucherNo(input.isuNo), // mSG[i,24] :6263
      ISU_YRCD: txtR(item.isuYrcd, 9) ?? input.scope.coYear ?? null, // mSG[i,25] :6264
      ISU_DBCD: txtR(item.isuDbcd, 3) ?? input.scope.coBook, // mSG[i,26] :6265
      ISU_SRNO: n2(item.isuSrno), // mSG[i,27] :6266
      // The weight and piece count actually RECEIVED back, which can differ from what was pledged when
      // a customer redeems part of a lot — that difference is the whole reason these columns exist.
      REC_NWT: n2(item.receivedNetWt ?? item.netWt),
      REC_QTY: n2(item.receivedQty ?? item.pcs),
    }));
    await insertHiddenIdentityTx(tx, input.scope, identity, book.name);
    await postVoucherTx(tx, input.scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName,
      writes: [
        { table: 'DHRN_REC_DATA', rows: [row] },
        ...(recDetl.length ? [{ table: 'DHRN_REC_DETL', rows: recDetl }] : []),
        { table: 'DHRN_DATA', rows: [movement] },
      ],
    });
    await tx.$executeRawUnsafe(
      // DEFECT FIX: every placeholder was missing from this statement, so a dhiran receipt failed
      // with a SQL syntax error on every call. No test exercised receiveDhrn, so it went unnoticed.
      // The issue row is matched the way the desktop matches it (TR_DHRN_REC.cs:6300): by the
      // receipt's own ISU_YRCD/ISU_DBCD/ISU_NO, not by the receipt's book, which never matches.
      `UPDATE "DHRN_ISU_DATA" SET "ISU_REC"=$7
         WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
           AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      input.scope.tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      isuYear,
      isuBook,
      formatVoucherNo(input.isuNo),
      newOs <= 0 ? 'Y' : 'N',
    );
    return { vchNo: identity.vchNo, outstanding: newOs };
  };
  if (context) return run(context.tx, context.identity);
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx) =>
    run(tx, await createIdentityTx(tx, input.scope, date, input.mainUser)),
  );
}

export function receiveLoan(
  prisma: any,
  input: Omit<
    DhrnIssueInput,
    'entryType' | 'expectedMainBook' | 'expectedBookInout' | 'ledgerMode'
  >,
  context?: { tx: any; identity: VoucherIdentity },
): Promise<{ vchNo: number; monthInt: number; intAmt: number }> {
  return issueDhrn(
    prisma,
    {
      ...input,
      entryType: 'L',
      expectedMainBook: 'LOAN REC',
      expectedBookInout: 'I',
      ledgerMode: 'loan-received',
    },
    context,
  );
}

export function issueLoan(
  prisma: any,
  input: Omit<
    DhrnReceiptInput,
    'entryType' | 'expectedMainBook' | 'expectedBookInout' | 'ledgerMode'
  >,
  context?: { tx: any; identity: VoucherIdentity },
): Promise<{ vchNo: number; outstanding: number }> {
  return receiveDhrn(
    prisma,
    {
      ...input,
      entryType: 'L',
      expectedMainBook: 'LOAN ISSUE',
      expectedBookInout: 'O',
      ledgerMode: 'loan-issue',
    },
    context,
  );
}

export interface DhrnInterestInput {
  scope: VoucherScope;
  isuNo: number | string; // the issue VCH_NO this interest collection is booked against
  borrowerAc: string;
  borrowerName?: string;
  interest?: number; // interest collected; omit to auto-compute (principal is left untouched)
  intPrc?: number;
  cashAc?: string; // funding ledger (default 'CASH')
  intIncAc?: string; // interest-income ledger (default 'INTINC')
  mainUser?: string;
  vchDate?: Date | string;
}

/**
 * Interest-only collection (TR_DHRN_INTREC): collect accrued interest on a Dhrn issue WITHOUT
 * repaying principal — the outstanding is unchanged. Ledger is Dr cash (interest) /
 * Cr interest-income (interest); no loan-receivable leg, no DHRN_REC_AMT.
 */
export async function receiveDhrnInterest(
  prisma: any,
  input: DhrnInterestInput,
): Promise<{ vchNo: number }> {
  if (!input.borrowerAc) throw new DhrnValidationError('borrower account is required');

  const cashAc = input.cashAc ?? 'CASH';
  const intIncAc = input.intIncAc ?? 'INTINC';
  const tenantId = input.scope.tenantId;
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();

  const vchNo = await withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    // Interest: operator override if supplied, else computed from issue rate × elapsed × CO_SET (R3).
    const interest =
      input.interest != null && Number.isFinite(input.interest)
        ? round2(input.interest)
        : await computeDhrnInterestTx(tx, input.scope, input.isuNo, vchDate);
    if (!(interest > 0))
      throw new DhrnValidationError('interest must be positive (none accrued or supplied)');
    const no = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, no, 'DIN');
    // Interest-only ledger: Dr cash (interest) / Cr interest-income (interest).
    const base = { ...key, VCH_TYPE: 'DINT' };
    const ledger: LedgerLine[] = [
      { ...base, AC_CODE: cashAc, DR_AMT: interest, CR_AMT: 0, SIGN: 'D' },
      { ...base, AC_CODE: intIncAc, DR_AMT: 0, CR_AMT: interest, SIGN: 'C' },
    ];
    assertBalanced(ledger);
    // DHRN_DATA movement row: interest in (INOUT 'I'), principal untouched (DHRN_AMT/DHRN_REC_AMT 0).
    const movement = {
      ...key,
      SR_NO: 1,
      VCH_TYPE: 'DINT',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'D',
      BOOK_NAME: 'DHIRAN',
      VCH_DATE: vchDate,
      AC_CODE: input.borrowerAc,
      DHRN_AMT: 0,
      DHRN_REC_AMT: 0,
      INT_PRC: input.intPrc ?? 0,
      INT_AMT: interest,
      INT_REC_AMT: interest,
      ISU_NO: formatVoucherNo(input.isuNo),
      ISU_LC: input.scope.lcCode,
      ISU_YRCD: input.scope.coYear ?? null,
      LOAN_TYPE: 'A',
    };
    // DHRN_REC_DATA header: interest receipt with no principal repayment (DHRN_REC_AMT 0).
    const recHeader = {
      ...key,
      VCH_TYPE: 'DINT',
      VCH_DATE: vchDate,
      AC_CODE: input.borrowerAc,
      AC_NAME: input.borrowerName ?? null,
      ISU_NO: formatVoucherNo(input.isuNo),
      ISU_LC: input.scope.lcCode,
      ISU_YRCD: input.scope.coYear ?? null,
      DHRN_REC_AMT: 0,
      INT_AMT: interest,
      INT_REC_AMT: interest,
      INT_PRC: input.intPrc ?? 0,
    };
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: 'DHIRAN',
      writes: [
        { table: 'DHRN_REC_DATA', rows: [recHeader] },
        { table: 'DHRN_DATA', rows: [movement] },
      ],
    });
    return no;
  });
  return { vchNo };
}

async function outstandingTx(
  tx: any,
  s: VoucherScope,
  isuNo: number | string,
  options: { isuBook?: string; isuYear?: string; entryType?: DhrnEntryType } = {},
): Promise<number> {
  const issueWhere = [`tenant_id=$1`, `"CO_CODE"=$2`, `"LC_CODE"=$3`, `"VCH_NO"=$4`];
  const issueParams: unknown[] = [s.tenantId, s.coCode, s.lcCode, formatVoucherNo(isuNo)];
  if (options.isuBook) {
    issueParams.push(options.isuBook);
    issueWhere.push(`"CO_BOOK"=$${issueParams.length}`);
  }
  if (options.isuYear) {
    issueParams.push(options.isuYear);
    issueWhere.push(`"CO_YEAR"=$${issueParams.length}`);
  }
  if (options.entryType) {
    issueParams.push(options.entryType);
    issueWhere.push(`coalesce("ENTRY_TYPE",'D')=$${issueParams.length}`);
  }
  const issue: { p: unknown }[] = await tx.$queryRawUnsafe(
    `SELECT coalesce("DHRN_AMT",0) AS p FROM "DHRN_ISU_DATA" WHERE ${issueWhere.join(' AND ')} LIMIT 1`,
    ...issueParams,
  );
  const principal = Number(issue[0]?.p ?? 0);

  const recWhere = [`tenant_id=$1`, `"CO_CODE"=$2`, `"LC_CODE"=$3`, `"ISU_NO"=$4`];
  const recParams: unknown[] = [s.tenantId, s.coCode, s.lcCode, formatVoucherNo(isuNo)];
  if (options.isuBook) {
    recParams.push(options.isuBook);
    recWhere.push(`"ISU_DBCD"=$${recParams.length}`);
  }
  if (options.isuYear) {
    recParams.push(options.isuYear);
    recWhere.push(`"ISU_YRCD"=$${recParams.length}`);
  }
  if (options.entryType) {
    recParams.push(options.entryType);
    recWhere.push(`coalesce("ENTRY_TYPE",'D')=$${recParams.length}`);
  }
  const rec: { r: unknown }[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum("DHRN_REC_AMT"),0) AS r FROM "DHRN_REC_DATA" WHERE ${recWhere.join(' AND ')}`,
    ...recParams,
  );
  return round2(principal - Number(rec[0]?.r ?? 0));
}

/** Outstanding principal for a Dhrn issue = principal − Σ receipts (desktop OS-report parity). */
export async function outstanding(
  prisma: any,
  scope: VoucherScope,
  isuNo: number | string,
): Promise<number> {
  return withTxBudget(prisma, scope.tenantId, 'read', (tx: any) => outstandingTx(tx, scope, isuNo));
}

export interface DeleteDhrnInput {
  scope: VoucherScope;
  vchNo: number | string;
  headerTable: 'DHRN_ISU_DATA' | 'DHRN_REC_DATA';
  book: string;
  vchType: string;
  deleteUser?: string;
}

export async function deleteDhrn(prisma: any, input: DeleteDhrnInput): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), input.book);
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    // A receipt owns its released-item detail as well as the DHRN_DATA movement.
    const extra =
      input.headerTable === 'DHRN_ISU_DATA'
        ? ['DHRN_ISU_DETL', 'DHRN_DATA']
        : ['DHRN_REC_DETL', 'DHRN_DATA'];
    await reverseVoucherTx(tx, tenantId, {
      tables: [input.headerTable, ...extra, 'AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: input.vchType, DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}
