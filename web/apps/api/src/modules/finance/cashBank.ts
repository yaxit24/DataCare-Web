import { round, toIsoDate } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { DEFAULT_CASH_LIMIT, resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { requirePostingAccount, resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertBalanced,
  assertPeriodOpen,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
  type VoucherWrite,
} from '../posting/posting.js';
import {
  completeFinanceScope,
  configuredBookTx,
  createFinanceIdentityTx,
  editIdentityTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  voucherKey,
  type VoucherIdentity,
  assertFinanceVoucherDateTx,
  financeEmployeeTx,
} from './lifecycle.js';
import { tenderThresholdDecision } from './tender.js';
import { FinanceValidationError, gridLinesToSave } from './gridLines.js';
import {
  cashLedgerLegs,
  cashRojmelRows,
  type CashGridRow,
  type CashLayout,
} from './cashBankLegs.js';

export { FinanceValidationError };

export { DEFAULT_CASH_LIMIT } from '../shared/settingsBehavior.js';

export type PayMode = 'cash' | 'cheque' | 'card' | 'upi' | 'bank';
export type CashDirection = 'receipt' | 'payment';

/**
 * Cash and bank receipts and payments are ONE desktop form, TR_CASH, and one table: every CASH REC, CASH PAY,
 * BANK REC and BANK PAY voucher is saved into CASH_DATA, one row per grid line (TR_CASH.cs:3005-3069), and
 * numbered from `MAX(VCH_NO)` of CASH_DATA (TR_CASH.cs:2674, :2968). The desktop points every such book at it
 * (`UPDATE BOOK_DATA SET BOOK_TBL_NAME = 'CASH_DATA' WHERE MAIN_BOOK IN ('CASH REC','CASH PAY','BANK REC',
 * 'BANK PAY')`, MS_UPDATE.cs:7821 and :16374), and it prints every one of them from CASH_DATA through
 * CashBankBill(.Ac).RPT (TR_CASH.cs:3327, :3331). PAY_DATA/PAY_DETL belong to Other Expenses, Other Income and
 * Other Commission (MS_UPDATE.cs:7933).
 *
 * Until the replay oracle found it, the web wrote payments to PAY_DATA/PAY_DETL. No owner decision chose that
 * (it came with the first web build, project-memory/parity/audit-D-finance-bullion.md recorded it as a
 * divergence to reconcile and G244 kept it open). Payments saved that way before this change stay readable,
 * editable and deletable: `LEGACY_PAYMENT_TABLES` below.
 */
export const LEGACY_PAYMENT_TABLES = ['PAY_DATA', 'PAY_DETL'] as const;

/**
 * The `BOOK_DATA.MAIN_BOOK` values a receipt or payment may be written to, and which mode each allows.
 *
 * Desktop: each menu fixes the book family before the form opens (MDI_FORM.cs:8052-8099) and the book decides the
 * cash or bank layout (TR_CASH.cs:2629-2650). The web chooses the mode on the form, so the pairing is enforced
 * here. `RECEIPT` and `PAYMENT` are the generic books web provisioning creates (seedCompany): not desktop
 * MAIN_BOOK values, they allow every mode.
 */
const FINANCE_BOOK_FAMILIES = {
  receipt: { 'CASH REC': 'cash', 'BANK REC': 'bank', RECEIPT: 'any' },
  payment: { 'CASH PAY': 'cash', 'BANK PAY': 'bank', PAYMENT: 'any' },
} as const satisfies Record<CashDirection, Record<string, 'cash' | 'bank' | 'any'>>;

type FinanceDirection = CashDirection;
type FinanceBook = Awaited<ReturnType<typeof configuredBookTx>> & {
  layout: 'cash' | 'bank' | 'any';
};

/** Resolve the configured book and refuse one outside the receipt/payment family or the mode's layout. */
async function financeBookTx(
  tx: any,
  scope: VoucherScope,
  direction: FinanceDirection,
  mode: PayMode,
): Promise<FinanceBook> {
  const book = await configuredBookTx(tx, scope);
  const mainBook = book.mainBook.toUpperCase();
  const family = FINANCE_BOOK_FAMILIES[direction] as Record<string, 'cash' | 'bank' | 'any'>;
  const allowed = family[mainBook];
  if (!allowed) {
    throw new FinanceValidationError(
      `book ${scope.coBook} is a ${mainBook || 'unclassified'} book; a ${direction} needs a ${Object.keys(family).join(', ')} book`,
    );
  }
  const wanted = mode === 'cash' ? 'cash' : 'bank';
  if (allowed !== 'any' && allowed !== wanted) {
    throw new FinanceValidationError(
      `book ${scope.coBook} is a ${mainBook} book and cannot take a ${mode} ${direction}`,
    );
  }
  return { ...book, layout: allowed };
}

/** The ledger/day-book layout a voucher is written with: the book's own, or the mode's in a generic book. */
const layoutOf = (book: { layout: 'cash' | 'bank' | 'any' }, mode: PayMode): CashLayout =>
  book.layout === 'any' ? (mode === 'cash' ? 'cash' : 'bank') : book.layout;

/**
 * The cash or bank account a receipt/payment settles to: the caller's account, else the book's BOOK_DETL slot 1
 * (TR_CASH.cs:2629-2650 lays the form out from the book). The generic web RECEIPT/PAYMENT books take every mode
 * with CASH in slot 1, so a bank, card, UPI or cheque movement in them must name an account, and not the cash one.
 */
async function financeSettlementAccountTx(
  tx: any,
  scope: VoucherScope,
  book: { layout: 'cash' | 'bank' | 'any' },
  direction: FinanceDirection,
  mode: PayMode,
  explicit: unknown,
): Promise<string> {
  const role = mode === 'cash' ? 'cash-settlement' : 'bank-settlement';
  if (mode === 'cash' || book.layout !== 'any')
    return resolveBookSlotAccountTx(tx, scope, role, 1, explicit);
  const chosen = String(explicit ?? '').trim();
  if (!chosen)
    throw new FinanceValidationError(
      `a ${mode} ${direction} in book ${scope.coBook} needs the bank account it ${direction === 'receipt' ? 'is paid into' : 'is paid from'}`,
    );
  const cashAc = await resolveBookSlotAccountTx(tx, scope, 'cash-settlement', 1).catch(() => '');
  if (cashAc && chosen === cashAc)
    throw new FinanceValidationError(
      `a ${mode} ${direction} cannot settle to the cash account ${cashAc}; choose the bank account`,
    );
  return chosen;
}

/**
 * The kasar (write-off) account: an explicit account, else BOOK_DETL slot 2 of the book (Ac_Ledr.cs:571-581
 * joins `B.SR_NO = 2 AND A.KASAR_AMT <> 0`). Web adaptation: slot 2 is refused when it names the settlement
 * account, because a write-off posted to the cash account would overstate cash on hand.
 */
export async function kasarAccountTx(
  tx: any,
  scope: VoucherScope,
  explicit: unknown,
  settlementAc: string,
  kasar: number,
): Promise<string> {
  if (String(explicit ?? '').trim()) {
    return requirePostingAccount('kasar', explicit, `book ${scope.coBook} writes off ${kasar}`);
  }
  const account = await resolveBookSlotAccountTx(tx, scope, 'kasar', 2);
  if (account === settlementAc) {
    throw new FinanceValidationError(
      `book ${scope.coBook} slot 2 (kasar) names the settlement account ${account}; configure a kasar account in slot 2 before writing off ${kasar}`,
    );
  }
  return account;
}

/**
 * Compatibility helper retained for callers/tests. Desktop PAN enforcement is a taxable-sale rule,
 * not a cash-payment override (TR_SALE.cs:15111-15128), so payment/receipt writers do not call it.
 */
export function assertCashLimit(
  mode: PayMode,
  amount: number,
  pan: string | undefined,
  limit = DEFAULT_CASH_LIMIT,
): void {
  if (mode === 'cash' && amount > limit && !(pan && pan.trim())) {
    throw new FinanceValidationError(`PAN required for cash transaction over ${limit}`);
  }
}

/** Strict active-company read; query errors/duplicates/invalid values fail the voucher closed. */
export async function cashLimitTx(tx: any, tenantId: string, coCode: unknown): Promise<number> {
  return (await resolveSettingsBehaviorTx(tx, { tenantId, coCode: String(coCode ?? '') }))
    .cashLimit;
}

/** A party's cumulative cash already received (Σ AC_DATA CR against the cash account) — for the ceiling. */
export async function partyCashReceivedTx(
  tx: any,
  scope: VoucherScope,
  partyAc: string,
  cashAc = 'CASH',
): Promise<number> {
  // DC_Main.cs:2149-2165 LedrCash: cumulative AC_DATA CR for party whose contra is cash.
  const r: any[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(coalesce("CR_AMT",0)),0)::float s
       FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "AC_CODE"::text=$4::text AND "LD_CODE"::text=$5::text`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    String(partyAc),
    cashAc,
  );
  const value = Number(r?.[0]?.s);
  if (!Number.isFinite(value)) throw new FinanceValidationError('party cash total is unreadable');
  return value;
}

/**
 * Desktop cash-RECEIPT ceiling (TR_CASH.cs:2913-2922 "You Can Not Receive More Then Cash Limit"). A cash receipt
 * is BLOCKED, with no PAN escape, when this amount plus the party's existing cash received exceeds the limit.
 */
export function assertCashReceiptCeiling(
  amount: number,
  priorCash: number,
  limit = DEFAULT_CASH_LIMIT,
  partyName = '',
): void {
  const total = round2(amount + priorCash);
  if (
    tenderThresholdDecision({
      cashAmount: amount,
      priorCash,
      billValue: 0,
      cashLimit: limit,
      panCardVal: Number.POSITIVE_INFINITY,
    }).cashBlocked
  ) {
    throw new FinanceValidationError(
      `Cash Recieved Limit Amount = ${limit} \r\nOld Ledr Value Is ${priorCash} \r\nAnd Total Cash Amount Is ${total} \r\nYou Can Not Receive More Then Cash Limit...\r\nParty Name Is ${partyName} `,
    );
  }
}

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

/** A balanced two-line transfer ledger: Dr `drAc` / Cr `crAc` for `amount` (Req 13.1). */
export function buildTransferLedger(
  key: VoucherKey,
  vchType: string,
  drAc: string,
  crAc: string,
  amount: number,
): LedgerLine[] {
  const base = { ...key, VCH_TYPE: vchType };
  return [
    { ...base, AC_CODE: drAc, DR_AMT: amount, CR_AMT: 0, SIGN: 'D' },
    { ...base, AC_CODE: crAc, DR_AMT: 0, CR_AMT: amount, SIGN: 'C' },
  ];
}

/**
 * The cash/bank ledger code for a payment mode: the account the caller resolved (explicit bank, or the book's
 * configured slot), refusing when the needed one is absent (P0-04: the old literals 'CASH'/'BANK' are not accounts).
 */
export function settlementAc(
  mode: PayMode,
  bankAc?: string,
  cashAc?: string,
  context = 'settlement',
): string {
  return mode === 'cash'
    ? requirePostingAccount('cash-settlement', cashAc, `${context} settles in cash`)
    : requirePostingAccount('bank-settlement', bankAc, `${context} settles by ${mode}`);
}

const numv = (v: unknown): number => Number(v ?? 0);
const round2 = (n: number): number => round(n, 2);

/**
 * One TR_CASH grid row as the API takes it. `amount`, `kasar` and `itDesc` are the Amount, Kasar and Remark cells;
 * `bankCharges`, `chqNo`, `clrDate` are the bank layout's Charges, Chq No and Clearing Dt cells and `chqPrintName`
 * and `bankName` the Chq Ac Name and Bank Name boxes (TR_CASH.cs:1730-1830, :3699-3736). An omitted cell is what
 * the desktop writes for an empty one: '' for text, 0 for amounts, the voucher date for the clearing date.
 */
export interface ReceiptPaymentLine {
  partyAc: string;
  partyName?: string;
  amount: number;
  kasar?: number;
  itDesc?: string;
  empCode?: string;
  bankCharges?: number;
  chqNo?: string;
  clrDate?: Date | string;
  chqPrintName?: string;
  bankName?: string;
}
export interface ReceiptPaymentLinesInput {
  scope: VoucherScope;
  mode?: PayMode; // cash|cheque|card|upi|bank
  bankAc?: string; // cash/bank ledger (defaults to the book's slot 1)
  chqNo?: string;
  vchDate?: Date | string;
  kasarAc?: string;
  empCode?: string; // header-level employee
  mainUser?: string;
  /** Chq Ac Name and Bank Name boxes applied to every line that does not carry its own. */
  chqPrintName?: string;
  bankName?: string;
  lines: ReceiptPaymentLine[];
}

interface CashVoucherFields {
  scope: VoucherScope;
  partyAc: string; // who paid us / who we pay
  partyName?: string;
  amount: number;
  mode: PayMode;
  bankAc?: string; // cash/bank ledger (defaults by mode)
  chqNo?: string;
  vchDate?: Date | string;
  /** The employee box (TR_CASH tEmpCode), stored in CASH_DATA.EMP_CODE. */
  empCode?: string;
  kasar?: number; // write-off applied against the party
  kasarAc?: string;
  mainUser?: string;
  itDesc?: string;
  bankCharges?: number;
  clrDate?: Date | string;
  chqPrintName?: string;
  bankName?: string;
}

export interface ReceiptInput extends CashVoucherFields {
  // Payment-mode detail (desktop TR_CARD_REC / TR_UPI_REC):
  cardCommissionPct?: number; // card mode: bank/card commission % (default 0) → CARD_COM_AMT, net to bank
  upiId?: string; // upi mode: UPI transaction id / VPA ref
}
export type PaymentInput = CashVoucherFields;

export interface FinanceResult {
  vchNo: number;
}

type FinanceWriteContext = { tx: any; identity: VoucherIdentity };

interface CashWrite {
  tx: any;
  scope: VoucherScope & { coYear: string; coBook: string };
  direction: CashDirection;
  mode: PayMode;
  identity: VoucherIdentity;
  lines: ReceiptPaymentLine[];
  bankAc?: string;
  kasarAc?: string;
  empCode?: string;
  headerChqNo?: string;
  headerChqPrintName?: string;
  headerBankName?: string;
  /** The receipt-only card / UPI detail tables (single receipt, desktop TR_CARD_REC / TR_UPI_REC). */
  detail?: (ctx: { key: VoucherKey; settleAc: string }) => Promise<VoucherWrite[]>;
}

const clip = (value: unknown, width: number): string => text(value).slice(0, width);

/**
 * Write ONE TR_CASH voucher: CASH_DATA (one row per grid line, TR_CASH.cs:3011-3069), the ledger legs
 * (Cash_Ledr/Bank_Ledr, Ac_Ledr.cs:565-610), the day book (Cash_Rojmel/Bank_Rojmel, Ac_Rojmel.cs:179-219) and the
 * hidden voucher identity in TEMP_BOOK_DATA (:2995-3004). Receipts, payments, one party or a grid, create or edit
 * all come through here, so the four menus cannot drift apart again.
 */
async function writeCashVoucherTx(w: CashWrite): Promise<FinanceResult & { total: number }> {
  const { tx, scope, direction, mode, identity } = w;
  const tenantId = scope.tenantId;
  const empCode = await financeEmployeeTx(tx, scope, w.empCode);
  await assertFinanceVoucherDateTx(tx, scope, identity.voucherDate);
  // The book first: a receipt must land in a receipt book, a payment in a payment book, matching the mode.
  const book = await financeBookTx(tx, scope, direction, mode);
  const layout = layoutOf(book, mode);
  const settleAc = await financeSettlementAccountTx(tx, scope, book, direction, mode, w.bankAc);
  // Cash-receipt ceiling (TR_CASH.cs:2913-2922, CASH REC only): this + the party's prior cash may not exceed
  // CO_SET.CASH_LIMIT, with no PAN escape. Resolved before the writes: the ceiling counts prior cash against
  // THIS account.
  if (direction === 'receipt' && mode === 'cash') {
    const limit = await cashLimitTx(tx, tenantId, scope.coCode);
    for (const line of w.lines) {
      // A kasar-only line moves no cash, so the ceiling has nothing to measure.
      if (round2(Number(line.amount) || 0) === 0) continue;
      const prior = await partyCashReceivedTx(tx, scope, line.partyAc, settleAc);
      assertCashReceiptCeiling(Number(line.amount), prior, limit, line.partyName);
    }
  }
  const vchDate = identity.voucherDate;
  const rows: CashGridRow[] = w.lines.map((line, index) => ({
    srNo: index + 1,
    partyAc: text(line.partyAc),
    partyName: clip(line.partyName, 50),
    recAmt: round2(numv(line.amount)),
    kasar: round2(numv(line.kasar)),
    charges: round2(numv(line.bankCharges)),
    itDesc: text(line.itDesc),
    chqNo: clip(line.chqNo ?? w.headerChqNo, 10),
    vchDate,
    clrDate: line.clrDate ? new Date(line.clrDate) : vchDate,
  }));
  const totalAmt = round2(rows.reduce((s, r) => s + r.recAmt, 0));
  const totalKasar = round2(rows.reduce((s, r) => s + r.kasar, 0));
  const totalCharges = round2(rows.reduce((s, r) => s + r.charges, 0));
  if (rows.some((r) => r.charges < 0))
    throw new FinanceValidationError('bank charges cannot be negative');
  if (totalCharges !== 0 && layout !== 'bank')
    throw new FinanceValidationError(
      `bank charges belong to a bank ${direction}; book ${scope.coBook} is a cash book`,
    );
  const kasarAc =
    totalKasar > 0 ? await kasarAccountTx(tx, scope, w.kasarAc, settleAc, totalKasar) : '';
  // The bank layout's Charges column posts against BOOK_DETL slot 3 (Ac_Ledr.cs:597, :609; Ac_Rojmel.cs:205, :217).
  const chargesAc =
    totalCharges !== 0 ? await resolveBookSlotAccountTx(tx, scope, 'bank-charges', 3) : '';
  const key: VoucherKey = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: identity.voucherNo,
  };
  const facts = {
    key,
    coBook: key.CO_BOOK,
    vchNo: key.VCH_NO,
    layout,
    direction,
    shortName: book.shortName,
    mainBook: book.mainBook,
    dataType: book.dataType,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    mainUser: identity.mainUser,
    voucherTime: identity.voucherTime,
    scope: { coCode: scope.coCode, lcCode: scope.lcCode, coYear: scope.coYear },
    accounts: { settle: settleAc, kasar: kasarAc, charges: chargesAc },
  };
  const ledger = cashLedgerLegs(facts, rows);
  assertBalanced(ledger);
  const rojmelRows = cashRojmelRows(facts, rows);
  // REC_AC_CODE is not a TR_CASH column (TR_CASH.cs:3016-3062 never sets it; only Bill To Bill does,
  // TR_BILL_TO.cs:4789). The web keeps it ONLY when the settlement account is not the one the book names in slot 1,
  // which is the one thing a reopened voucher could not otherwise recover (a generic book's bank account, or an
  // account the operator chose over the book's).
  const slotOne = await resolveBookSlotAccountTx(tx, scope, 'cash-settlement', 1).catch(() => '');
  const recAcCode = settleAc !== slotOne ? settleAc : null;
  const cashRows = rows.map((r, index) => {
    const line = w.lines[index]!;
    return {
      ...key,
      SR_NO: r.srNo,
      VCH_DATE: vchDate,
      // TR_CASH.cs:3022-3029: the grid's Clearing Dt cell, the voucher date when it is empty.
      CLR_DATE: r.clrDate,
      VCH_TYPE: book.shortName,
      INOUT_TYPE: book.inout || (direction === 'receipt' ? 'I' : 'O'),
      // TR_CASH.cs:3032 writes 'C' for every cash and bank book; BOOK_NAME is the book's MAIN_BOOK (:3033).
      ENTRY_TYPE: 'C',
      BOOK_NAME: book.mainBook,
      AC_CODE: r.partyAc,
      AC_NAME: r.partyName,
      REC_AMT: r.recAmt,
      BANK_CHARGES: r.charges,
      KASAR_AMT: r.kasar,
      IT_DESC: r.itDesc,
      CHQ_NO: r.chqNo,
      CHQ_PRINT_NAME: clip(line.chqPrintName ?? w.headerChqPrintName, 255),
      BANK_NAME: w.detail ? '' : clip(line.bankName ?? w.headerBankName, 50),
      REC_AC_CODE: recAcCode,
      VCH_TIME: identity.voucherTime,
      HD_VCH_NO: identity.hiddenVoucherNo,
      EMP_CODE: empCode || null,
      DATA_TRFR: 'N',
      MAIN_USER: identity.mainUser || null,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    };
  });
  const writes: VoucherWrite[] = [{ table: 'CASH_DATA', rows: cashRows }];
  if (w.detail) writes.push(...(await w.detail({ key, settleAc })));
  if (rojmelRows.length) writes.push({ table: 'ROJ_MEL_DATA', rows: rojmelRows });
  await insertHiddenIdentityTx(tx, scope, identity, book.name);
  // The lock date is the VOUCHER's, not the clearing date the bank legs may be dated on (TR_CASH.cs:2943).
  await assertPeriodOpen(tx, tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: vchDate }] },
  });
  await postVoucherTx(tx, tenantId, {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: book.mainBook,
    writes,
  });
  return { vchNo: identity.vchNo, total: totalAmt };
}

/** One party, one grid row: the page's single-party mode. */
async function postCash(
  prisma: any,
  direction: CashDirection,
  input: ReceiptInput | PaymentInput,
  lifecycle?: FinanceWriteContext,
): Promise<FinanceResult> {
  if (!input.partyAc) throw new FinanceValidationError('party account is required');
  if (!(input.amount > 0)) throw new FinanceValidationError('amount must be positive');
  const mode = String(input.mode || 'cash').toLowerCase() as PayMode;
  const scope = completeFinanceScope(input.scope);
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const receipt = direction === 'receipt' ? (input as ReceiptInput) : undefined;
  const cardOrUpi = receipt && (mode === 'card' || mode === 'upi');
  const write = async (tx: any, identity: VoucherIdentity): Promise<FinanceResult> => {
    const { vchNo } = await writeCashVoucherTx({
      tx,
      scope,
      direction,
      mode,
      identity,
      lines: [
        {
          partyAc: input.partyAc,
          partyName: input.partyName,
          amount: input.amount,
          kasar: input.kasar,
          itDesc: input.itDesc,
          bankCharges: input.bankCharges,
          chqNo: input.chqNo,
          clrDate: input.clrDate,
          chqPrintName: input.chqPrintName,
          bankName: input.bankName,
        },
      ],
      bankAc: input.bankAc,
      kasarAc: input.kasarAc,
      empCode: input.empCode,
      detail: cardOrUpi
        ? ({ key, settleAc }) => cardOrUpiWrites(tx, scope, receipt!, mode, identity, key, settleAc)
        : undefined,
    });
    return { vchNo };
  };
  if (lifecycle) return write(lifecycle.tx, lifecycle.identity);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) =>
    write(tx, await createFinanceIdentityTx(tx, scope, vchDate, input.mainUser)),
  );
}

/** Payment-mode detail tables (desktop TR_CARD_REC / TR_UPI_REC): additive to the CASH_DATA row. */
async function cardOrUpiWrites(
  tx: any,
  scope: VoucherScope,
  input: ReceiptInput,
  mode: PayMode,
  identity: VoucherIdentity,
  key: VoucherKey,
  settleAc: string,
): Promise<VoucherWrite[]> {
  const vchType = (await configuredBookTx(tx, scope)).shortName;
  const vchDate = identity.voucherDate;
  if (mode === 'card') {
    const behavior = await resolveSettingsBehaviorTx(tx, scope);
    const comPct = round2(numv(input.cardCommissionPct));
    const comAmt = round2((input.amount * comPct) / 100);
    const net = round2(input.amount - comAmt);
    return [
      {
        table: 'CARD_DATA',
        rows: [
          {
            ...key,
            VCH_TYPE: vchType,
            INOUT_TYPE: 'I',
            ENTRY_TYPE: 'C',
            BOOK_NAME: 'BANK REC',
            VCH_TIME: vchDate,
            VCH_DATE: vchDate,
            AC_CODE: input.partyAc,
            AC_NAME: input.partyName ?? null,
            CARD_AMT: input.amount,
            CARD_COM_PRC: comPct,
            CARD_COM_AMT: comAmt,
            CARD_REC_AMT: net,
            BANK_ACCD: settleAc,
            BANK_NAME: input.bankName ?? null,
            BANK_NET_AMT: net,
            // TR_SALE.cs:18936 opens CARD ADJUST when CARD_COM_ADJ=Y; persist the workflow marker.
            IT_DESC: behavior.cardCommissionAdjustment
              ? 'Card receipt — adjustment required'
              : 'Card receipt',
            HD_VCH_NO: identity.hiddenVoucherNo,
            MAIN_USER: identity.mainUser || null,
            DATA_TRFR: 'N',
          },
        ],
      },
    ];
  }
  return [
    {
      table: 'UPI_DATA',
      rows: [
        {
          ...key,
          SR_NO: 1,
          VCH_DATE: vchDate,
          VCH_TIME: vchDate,
          AC_CODE: input.partyAc,
          UPI_AC_CODE: settleAc,
          UPI_AC_NAME: input.bankName ?? null,
          UPI_AMT: input.amount,
          UPI_ID: input.upiId ?? input.chqNo ?? null,
          HD_VCH_NO: identity.hiddenVoucherNo,
          MAIN_USER: identity.mainUser || null,
          UPI_TYPE: 'R',
        },
      ],
    },
  ];
}

/** Receipt (money IN): Dr cash/bank, Cr party. Header → CASH_DATA. */
export async function postReceipt(
  prisma: any,
  input: ReceiptInput,
  lifecycle?: FinanceWriteContext,
): Promise<FinanceResult> {
  return postCash(prisma, 'receipt', input, lifecycle);
}

/** Payment (money OUT): Dr party, Cr cash/bank. Header → CASH_DATA, as TR_CASH (TR_CASH.cs:3005). */
export async function postPayment(
  prisma: any,
  input: PaymentInput,
  lifecycle?: FinanceWriteContext,
): Promise<FinanceResult> {
  return postCash(prisma, 'payment', input, lifecycle);
}

/** The TR_CASH grid: one CASH_DATA row, one ledger pair and one day-book row set per line. */
async function postCashLines(
  prisma: any,
  direction: CashDirection,
  input: ReceiptPaymentLinesInput,
): Promise<FinanceResult & { total: number }> {
  const lines = gridLinesToSave(
    input.lines,
    `at least one ${direction} line (party + amount) is required`,
  );
  const mode = String(input.mode || 'cash').toLowerCase() as PayMode;
  const scope = completeFinanceScope(input.scope);
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) =>
    writeCashVoucherTx({
      tx,
      scope,
      direction,
      mode,
      identity: await createFinanceIdentityTx(tx, scope, vchDate, input.mainUser),
      lines,
      bankAc: input.bankAc,
      kasarAc: input.kasarAc,
      empCode: input.empCode,
      headerChqNo: input.chqNo,
      headerChqPrintName: input.chqPrintName,
      headerBankName: input.bankName,
    }),
  );
}

export async function postReceiptLines(
  prisma: any,
  input: ReceiptPaymentLinesInput,
): Promise<FinanceResult & { total: number }> {
  return postCashLines(prisma, 'receipt', input);
}

export async function postPaymentLines(
  prisma: any,
  input: ReceiptPaymentLinesInput,
): Promise<FinanceResult & { total: number }> {
  return postCashLines(prisma, 'payment', input);
}

/** Every table a TR_CASH voucher writes: rebuilt on an edit, removed on a delete (TR_CASH.cs:3217-3223). */
const CASH_WRITE_TABLES = [
  'CASH_DATA',
  'CARD_DATA',
  'UPI_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
] as const;
/** A payment saved before payments moved to CASH_DATA: PAY_DATA (+ PAY_DETL for a grid), AC_DATA, ROJ_MEL_DATA. */
const LEGACY_WRITE_TABLES = [...LEGACY_PAYMENT_TABLES, 'AC_DATA', 'ROJ_MEL_DATA'] as const;

/** Which header table holds a voucher: CASH_DATA, or (a payment only) the legacy PAY_DATA. */
async function headerTableTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
  direction: CashDirection,
): Promise<'CASH_DATA' | 'PAY_DATA'> {
  const has = async (table: string): Promise<boolean> =>
    (
      (await tx.$queryRawUnsafe(
        `SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      )) as unknown[]
    ).length > 0;
  if (await has('CASH_DATA')) return 'CASH_DATA';
  if (direction === 'payment' && (await has('PAY_DATA'))) return 'PAY_DATA';
  return 'CASH_DATA';
}

/**
 * Edit a single-party voucher: replace the write set and repost in one transaction. A cell the page does not carry
 * (narration, charges, clearing date, cheque print name, bank name) keeps its saved value when the request omits
 * it, so an unchanged save is a no-op (a clearing date is kept only when it was not simply the voucher date).
 */
async function editCash(
  prisma: any,
  direction: CashDirection,
  input: ReceiptInput | PaymentInput,
  requestedVoucherNo: number | string,
): Promise<FinanceResult> {
  const scope = completeFinanceScope(input.scope);
  const requestedDate = input.vchDate ? new Date(input.vchDate) : new Date();
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    // TR_CASH.cs:2937-2947 checks the year before the lock date that editIdentityTx enforces.
    await assertFinanceVoucherDateTx(tx, scope, requestedDate);
    const voucherNo = formatVoucherNo(requestedVoucherNo);
    const table = await headerTableTx(tx, scope, voucherNo, direction);
    const { identity } = await editIdentityTx(tx, {
      table,
      scope,
      requestedVoucherNo,
      requestedDate,
      // A grid voucher's rows differ in SR_NO, so this refuses ("voucher is ambiguous") rather than collapse a
      // multi-line voucher into one line; the screen offers no single-line edit for it.
      extraColumns: table === 'CASH_DATA' ? ['SR_NO'] : [],
      // TR_CASH.cs:2976-3004 gives a NEW cash voucher its hidden number. A payment saved in PAY_DATA before payments
      // moved to CASH_DATA has none, and this single-party edit cannot rebuild its PAY_DETL lines.
      blankHiddenRefusal:
        table === 'PAY_DATA'
          ? 'Cannot edit this legacy payment: it has no hidden voucher number. Its saved payment lines must be migrated before editing.'
          : undefined,
    });
    let merged = input;
    if (table === 'CASH_DATA') {
      const saved: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT "IT_DESC","BANK_CHARGES","BANK_NAME","CHQ_PRINT_NAME","VCH_DATE"::text vd,"CLR_DATE"::text cd
           FROM "CASH_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
            AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      const s = saved[0];
      if (s) {
        const keptClr = s.cd && s.cd !== s.vd ? toIsoDate(s.cd) : undefined;
        merged = {
          ...input,
          itDesc: input.itDesc ?? text(s.IT_DESC),
          bankCharges: input.bankCharges ?? numv(s.BANK_CHARGES),
          bankName: input.bankName ?? text(s.BANK_NAME),
          chqPrintName: input.chqPrintName ?? text(s.CHQ_PRINT_NAME),
          clrDate: input.clrDate ?? keptClr,
        };
      }
    }
    await replaceWriteSetTx(
      tx,
      scope,
      identity.voucherNo,
      identity.hiddenVoucherNo,
      table === 'CASH_DATA' ? CASH_WRITE_TABLES : LEGACY_WRITE_TABLES,
    );
    return postCash(prisma, direction, merged, { tx, identity });
  });
}

export async function editReceipt(
  prisma: any,
  input: ReceiptInput,
  requestedVoucherNo: number | string,
): Promise<FinanceResult> {
  return editCash(prisma, 'receipt', input, requestedVoucherNo);
}

/** Edit a single-party payment (mirror editReceipt). A payment saved in PAY_DATA is rewritten into CASH_DATA. */
export async function editPayment(
  prisma: any,
  input: PaymentInput,
  requestedVoucherNo: number | string,
): Promise<FinanceResult> {
  return editCash(prisma, 'payment', input, requestedVoucherNo);
}

/** Delete a whole TR_CASH voucher (every grid row), audited per row (TR_CASH.cs:3200-3227). */
async function deleteCash(
  prisma: any,
  direction: CashDirection,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
): Promise<{ reversed: true }> {
  const scope = completeFinanceScope(input.scope);
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const table = await headerTableTx(tx, scope, voucherNo, direction);
    const book = await configuredBookTx(tx, scope);
    let header: Record<string, unknown>;
    let hiddenVoucherNo: string;
    let rows: Array<{
      srNo: number;
      acCode: unknown;
      acName: unknown;
      valueDr: number;
      valueCr: number;
      description: string;
    }>;
    let tables: readonly string[];
    if (table === 'CASH_DATA') {
      const edit = await editIdentityTx(tx, {
        table,
        scope,
        requestedVoucherNo: voucherNo,
        requestedDate: new Date(),
        extraColumns: ['INOUT_TYPE'],
      });
      header = edit.persisted;
      hiddenVoucherNo = edit.identity.hiddenVoucherNo;
      const lineRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT "SR_NO","AC_CODE","AC_NAME","REC_AMT","IT_DESC" FROM "CASH_DATA" WHERE tenant_id=$1
          AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
          ORDER BY "SR_NO" NULLS FIRST, row_id`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      const card: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT "CARD_AMT","IT_DESC" FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
         AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      const source = card[0];
      const inout = text(header.INOUT_TYPE);
      rows = lineRows.map((r, i) => ({
        srNo: Number(r.SR_NO ?? 0) || i + 1,
        acCode: r.AC_CODE,
        acName: r.AC_NAME,
        valueDr: source ? 0 : inout === 'O' ? numv(r.REC_AMT) : 0,
        valueCr: source ? numv(source.CARD_AMT) : inout === 'I' ? numv(r.REC_AMT) : 0,
        description: text(source?.IT_DESC ?? r.IT_DESC),
      }));
      tables = CASH_WRITE_TABLES;
    } else {
      // A payment saved in PAY_DATA before payments moved to CASH_DATA: one audit row per allocation line.
      const detail: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT "SR_NO","AC_CODE","IT_NAME","NET_AMT","IT_REMARK" FROM "PAY_DETL" WHERE tenant_id=$1
          AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      const head: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
        `SELECT "VCH_DATE","VCH_TIME","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME","NET_AMT","VCH_DESC"
           FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 LIMIT 1 FOR UPDATE`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coYear,
        scope.coBook,
        voucherNo,
      );
      // Older payments have no hidden number (it is what an edit needs), but they can still be deleted.
      header = { VCH_NO: voucherNo, ...head[0] };
      hiddenVoucherNo = text(head[0]?.HD_VCH_NO);
      rows = detail.length
        ? detail.map((r, i) => ({
            srNo: Number(r.SR_NO ?? 0) || i + 1,
            acCode: r.AC_CODE,
            acName: r.IT_NAME,
            valueDr: numv(r.NET_AMT),
            valueCr: 0,
            description: text(r.IT_REMARK),
          }))
        : [
            {
              srNo: 1,
              acCode: head[0]?.AC_CODE,
              acName: head[0]?.AC_NAME,
              valueDr: numv(head[0]?.NET_AMT),
              valueCr: 0,
              description: text(head[0]?.VCH_DESC),
            },
          ];
      tables = LEGACY_WRITE_TABLES;
    }
    await reverseVoucherTx(tx, scope.tenantId, {
      tables: [...tables],
      key: voucherKey(scope, voucherNo),
    });
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      hiddenVoucherNo,
    );
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: book,
      header,
      rows: rows.map((r) => ({ ...r, fineType: 'A' })),
      deleteUser: input.deleteUser,
    });
    return { reversed: true as const };
  });
}

export async function deleteReceipt(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
): Promise<{ reversed: true }> {
  return deleteCash(prisma, 'receipt', input);
}

/** Delete a payment voucher, whichever table holds it (CASH_DATA, or the legacy PAY_DATA). */
export async function deletePayment(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string; book?: unknown },
): Promise<{ reversed: true }> {
  return deleteCash(prisma, 'payment', input);
}

// A grid voucher is the same voucher as a single one (one CASH_DATA row per line): one delete path.
export const deleteReceiptLines = deleteReceipt;
export const deletePaymentLines = deletePayment;

export interface DeleteFinanceInput {
  scope: VoucherScope;
  vchNo: number | string;
  headerTable: 'CASH_DATA' | 'PAY_DATA' | 'CONTRA_DATA';
  book: string; // CO_BOOK used at creation (RCT/PAY/CON)
  vchType: string;
  deleteUser?: string;
}

/** Delete/reverse a finance voucher: remove header + AC_DATA, write DELETE_DATA (Req 13.4). */
export async function deleteFinance(
  prisma: any,
  input: DeleteFinanceInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key: VoucherKey = {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_YEAR: input.scope.coYear ?? '',
    CO_BOOK: input.scope.coBook ?? input.book,
    VCH_NO: formatVoucherNo(Number(input.vchNo)),
  };
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: [input.headerTable, 'AC_DATA'],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: { ...key, VCH_TYPE: input.vchType, DELETE_USER: input.deleteUser ?? 'system' },
      },
    });
    return { reversed: true };
  });
}

/** The BOOK_DATA row of a book, retired or not: reading a saved voucher must not depend on CUR_USE. */
async function bookFamilyTx(
  tx: any,
  scope: VoucherScope,
): Promise<{ mainBook: string; slotOne: string }> {
  const rows: Array<{ m: unknown }> = await tx.$queryRawUnsafe(
    `SELECT upper(btrim(coalesce("MAIN_BOOK"::text,''))) m FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  const slotOne = await resolveBookSlotAccountTx(tx, scope, 'cash-settlement', 1).catch(() => '');
  return { mainBook: text(rows[0]?.m), slotOne };
}

/**
 * Read a saved receipt or payment (TR_CASH DISPLAY_DATA refills the grid from every CASH_DATA row in SR_NO order,
 * TR_CASH.cs:2742-2834). A payment saved in PAY_DATA before this change is read from there.
 */
async function readCash(
  prisma: any,
  direction: CashDirection,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeFinanceScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME",
              "REC_AMT","KASAR_AMT","BANK_CHARGES","REC_AC_CODE","CHQ_NO","IT_DESC","BOOK_NAME","EMP_CODE",
              "CLR_DATE"::text clr,"CHQ_PRINT_NAME","BANK_NAME"
         FROM "CASH_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" NULLS FIRST, row_id`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length) {
      if (direction === 'payment') {
        const legacy = await readLegacyPaymentTx(tx, scope, voucherNo);
        if (legacy) return legacy;
      }
      throw new FinanceValidationError(`${direction} voucher not found: ${voucherNo}`);
    }
    const identityOf = (r: Record<string, unknown>) =>
      ['VCH_DATE', 'VCH_TIME', 'HD_VCH_NO', 'MAIN_USER', 'REC_AC_CODE']
        .map((c) => text(r[c]))
        .join('|');
    if (rows.some((r) => identityOf(r) !== identityOf(rows[0]!)))
      throw new FinanceValidationError(`${direction} voucher is ambiguous: ${voucherNo}`);
    // The wire shape of an ordinary line stays what it was; the bank layout's Charges and a clearing date other than
    // the voucher date appear only when the voucher has them.
    const lines = rows.map((r) => ({
      partyAc: text(r.AC_CODE),
      partyName: text(r.AC_NAME),
      amount: numv(r.REC_AMT),
      kasar: numv(r.KASAR_AMT),
      itDesc: text(r.IT_DESC),
      ...(numv(r.BANK_CHARGES) !== 0 ? { bankCharges: numv(r.BANK_CHARGES) } : {}),
      ...(r.clr && toIsoDate(r.clr) !== toIsoDate(r.VCH_DATE) ? { clrDate: toIsoDate(r.clr) } : {}),
    }));
    const card: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "CARD_COM_PRC","BANK_NAME" FROM "CARD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const upi: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "UPI_ID","UPI_AC_NAME" FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const h = rows[0]!;
    const { mainBook, slotOne } = await bookFamilyTx(tx, scope);
    // TR_CASH never stores the settlement account (REC_AC_CODE is only kept when it is not the book's slot 1), so a
    // desktop BANK book is the bank layout, a desktop CASH book the cash layout, and any other (generic) book is a
    // bank movement exactly when it names an account other than its slot 1.
    const named = text(h.REC_AC_CODE);
    const bank =
      mainBook === 'BANK REC' || mainBook === 'BANK PAY'
        ? true
        : mainBook === 'CASH REC' || mainBook === 'CASH PAY'
          ? false
          : named !== '' && named !== slotOne;
    return {
      voucherNo: text(h.VCH_NO),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      vchDate: toIsoDate(h.VCH_DATE),
      partyAc: text(h.AC_CODE),
      partyName: text(h.AC_NAME),
      amount: round2(lines.reduce((t, l) => t + l.amount, 0)),
      kasar: round2(lines.reduce((t, l) => t + l.kasar, 0)),
      bankCharges: round2(rows.reduce((t, r) => t + numv(r.BANK_CHARGES), 0)),
      lines,
      bankAc: named || (bank ? slotOne : ''),
      chqNo: text(h.CHQ_NO),
      chqPrintName: text(h.CHQ_PRINT_NAME),
      empCode: text(h.EMP_CODE),
      mode: card.length
        ? 'card'
        : upi.length
          ? 'upi'
          : !bank
            ? 'cash'
            : text(h.CHQ_NO)
              ? 'cheque'
              : 'bank',
      cardCommissionPct: numv(card[0]?.CARD_COM_PRC),
      bankName: text(card[0]?.BANK_NAME ?? upi[0]?.UPI_AC_NAME ?? h.BANK_NAME),
      upiId: text(upi[0]?.UPI_ID),
      description: text(h.IT_DESC),
      bookName: text(h.BOOK_NAME),
    };
  });
}

/** A payment written to PAY_DATA by the web before payments moved to CASH_DATA. */
async function readLegacyPaymentTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
): Promise<Record<string, unknown> | null> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","AC_CODE","AC_NAME",
            "NET_AMT","TOT_AMT","KASAR_AMT","BANK_AC","CASH_AMT","CHQ_AMT","CARD_AMT","CHQ_NO",
            "VCH_DESC","BOOK_NAME","EMP_CODE"
       FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const h = rows[0];
  if (!h) return null;
  const mode = numv(h.CHQ_AMT)
    ? 'cheque'
    : numv(h.CARD_AMT)
      ? 'card'
      : numv(h.CASH_AMT) || !text(h.BANK_AC)
        ? 'cash'
        : 'bank';
  return {
    voucherNo: text(h.VCH_NO),
    hiddenVoucherNo: text(h.HD_VCH_NO),
    mainUser: text(h.MAIN_USER),
    vchDate: toIsoDate(h.VCH_DATE),
    partyAc: text(h.AC_CODE),
    partyName: text(h.AC_NAME),
    amount: numv(h.NET_AMT) || numv(h.TOT_AMT),
    kasar: numv(h.KASAR_AMT),
    bankAc: text(h.BANK_AC),
    chqNo: text(h.CHQ_NO),
    empCode: text(h.EMP_CODE),
    mode,
    // PAY_DATA's narration column is VCH_DESC; CASH_DATA's is IT_DESC.
    description: text(h.VCH_DESC),
    bookName: text(h.BOOK_NAME),
  };
}

export async function getReceipt(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  return readCash(prisma, 'receipt', scope, requestedVoucherNo);
}

/** Read a saved payment (plan item F2.1). */
export async function getPayment(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  return readCash(prisma, 'payment', scope, requestedVoucherNo);
}
