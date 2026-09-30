import { withTenant } from '@datacare/db';
import { assertBalanced, assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import { resolveTaxPolicyTx, type ResolvedTaxPolicy } from '../shared/taxPolicy.js';
import { assertFiscalDateTx } from '../vouchers/lifecycle.js';
import { formatVoucherNo, type VoucherScope } from '../vouchers/numbering.js';
import {
  completeFinanceScope,
  createIdentityTx,
  editIdentityTx,
  insertDesktopDeleteAuditTx,
  insertHiddenIdentityTx,
  replaceWriteSetTx,
  text,
  voucherKey,
  type VoucherIdentity,
} from '../finance/lifecycle.js';

export class OtherIncomeValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'OtherIncomeValidationError';
  }
}

export interface OtherIncomeLineInput {
  hsnCode?: string;
  itemName: string;
  netAmount: number;
  discountPercent?: number;
  discountAmount?: number;
  taxCode?: string;
  taxType?: 'F' | 'R';
}

export interface OtherIncomeInput {
  scope: VoucherScope;
  vchDate: string | Date;
  partyCode: string;
  billNo?: string;
  billDate?: string | Date;
  ledgerCode: string;
  chequeAmount?: number;
  chequeAccount?: string;
  chequeNo?: string;
  cardAmount?: number;
  cardAccount?: string;
  cashAmount?: number;
  cashAccount?: string;
  kasarAmount?: number;
  kasarAccount?: string;
  tdsCode?: string;
  employeeCode?: string;
  bankName?: string;
  description?: string;
  lines: OtherIncomeLineInput[];
  mainUser?: string;
}

/**
 * The two modes of desktop TR_OTH_PURC. "Other Income" opens it on an OTH INC book and "Other Expenses" on an
 * OTH EXP book (MDI_FORM.cs:8372-8394). One set of posting routines serves both and mirrors every amount on
 * the book's MAIN_BOOK: Ac_Ledr.Oth_Purc_Ledr (Ac_Ledr.cs:1600) writes each leg with
 * `CASE WHEN B.MAIN_BOOK = 'OTH INC' THEN <credit> ELSE <debit> END`, Ac_Rojmel.Oth_Purc_Rojmel
 * (Ac_Rojmel.cs:693) does the same, and Ac_Tax.Oth_Purc_GST (Ac_Tax.cs:205) types income tax rows 'S' / '+'
 * and expense tax rows 'P' / '-'.
 */
export type OtherPurcMode = 'OTH INC' | 'OTH EXP';

type OtherIncomeBook = {
  coBook: string;
  configuredName: string;
  vchType: string;
  mainBook: OtherPurcMode;
  inout: 'I' | 'O';
  dataType: string;
};

const MODE_TEXT: Record<
  OtherPurcMode,
  { voucher: string; party: string; ledger: string; settle: string; fallbackName: string }
> = {
  'OTH INC': {
    voucher: 'other-income',
    party: 'customer account',
    ledger: 'income ledger',
    settle: 'receipt',
    fallbackName: 'Other Income',
  },
  'OTH EXP': {
    voucher: 'other-expense',
    party: 'supplier account',
    ledger: 'expense ledger',
    settle: 'payment',
    fallbackName: 'Other Expenses',
  },
};

/** An amount on the side the income mode posts it; the expense mode posts the mirror (Oth_Purc_Ledr). */
const side = (mode: OtherPurcMode, incomeSide: 'DR' | 'CR', amount: number) =>
  (mode === 'OTH INC') === (incomeSide === 'DR')
    ? { DR_AMT: amount, CR_AMT: 0 }
    : { DR_AMT: 0, CR_AMT: amount };

type Account = { code: string; name: string; gstType: string };
type TaxComponent = { group: string; percent: number };
type LineTax = {
  code: string;
  totalPercent: number;
  taxAccount: string;
  igst: TaxComponent;
  cgst: TaxComponent;
  sgst: TaxComponent;
};
type ResolvedLine = {
  hsnCode: string;
  itemName: string;
  netAmount: number;
  discountPercent: number;
  discountAmount: number;
  taxCode: string;
  taxPercent: number;
  taxType: 'F' | 'R';
  taxableAmount: number;
  igstPercent: number;
  igstAmount: number;
  cgstPercent: number;
  cgstAmount: number;
  sgstPercent: number;
  sgstAmount: number;
  totalAmount: number;
  taxAccount: string;
  taxGroup: string;
};
type ResolvedInput = {
  party: Account;
  ledger: Account;
  employeeCode: string;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  cashAccount: string;
  kasarAmount: number;
  kasarAccount: string;
  tdsCode: string;
  tdsPercent: number;
  tdsAmount: number;
  tdsAccount: string;
  netAmount: number;
  discountAmount: number;
  igstAmount: number;
  cgstAmount: number;
  sgstAmount: number;
  grossAmount: number;
  totalAmount: number;
  outstandingAmount: number;
  lines: ResolvedLine[];
};

const money = (value: unknown): number => Math.round((Number(value ?? 0) + 1e-9) * 100) / 100;
const integerMoney = (value: unknown): number => Math.round(Number(value ?? 0));
const number = (value: unknown): number => Number(value ?? 0);
const positiveOrZero = (value: unknown, label: string): number => {
  const resolved = money(value);
  if (!Number.isFinite(resolved) || resolved < 0) {
    throw new OtherIncomeValidationError(`${label} must be a valid non-negative amount`);
  }
  return resolved;
};

function businessDate(value: string | Date, label = 'voucher date'): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new OtherIncomeValidationError(`${label} is missing or invalid`);
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new OtherIncomeValidationError(`${label} is missing or invalid`);
  }
  return { date, iso: raw };
}

async function resolveBookTx(
  tx: any,
  scope: VoucherScope,
  mode: OtherPurcMode,
): Promise<OtherIncomeBook> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME","DATA_TYPE"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (rows.length !== 1) {
    throw new OtherIncomeValidationError(
      rows.length
        ? `${MODE_TEXT[mode].voucher} book configuration is ambiguous: ${scope.coBook}`
        : `${MODE_TEXT[mode].voucher} book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  const inout = text(row.BOOK_INOUT).toUpperCase();
  const table = text(row.BOOK_TBL_NAME).toUpperCase();
  // Income keeps its measured direction (book 375: OTH INC / I). The posting routines read only MAIN_BOOK, so
  // an expense book keeps whatever direction it was configured with; blank is the payment side, 'O'.
  if (
    mainBook !== mode ||
    (mode === 'OTH INC' ? inout !== 'I' : inout !== '' && inout !== 'I' && inout !== 'O')
  ) {
    throw new OtherIncomeValidationError(
      mode === 'OTH INC'
        ? `book ${scope.coBook} must be configured as OTH INC / I`
        : `book ${scope.coBook} must be configured as OTH EXP`,
    );
  }
  if (table && table !== 'PAY_DATA') {
    throw new OtherIncomeValidationError(`book ${scope.coBook} must write PAY_DATA`);
  }
  return {
    coBook: text(row.CO_BOOK),
    configuredName: text(row.BOOK_NAME) || MODE_TEXT[mode].fallbackName,
    vchType: text(row.BOOK_SNAME) || text(row.CO_BOOK),
    mainBook: mode,
    inout: mode === 'OTH INC' ? 'I' : inout === 'I' ? 'I' : 'O',
    dataType: text(row.DATA_TYPE) || 'A',
  };
}

async function oneAccountTx(tx: any, scope: VoucherScope, code: string, label = 'account') {
  const accountCode = text(code);
  if (!accountCode) throw new OtherIncomeValidationError(`${label} is required`);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME","AC_GST_TYPE" FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        AND ("LC_CODE" IS NULL OR btrim("LC_CODE"::text)='' OR "LC_CODE"::text=$4)
      ORDER BY CASE WHEN "LC_CODE"::text=$4 THEN 0 ELSE 1 END,row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    accountCode,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new OtherIncomeValidationError(
      rows.length ? `${label} is ambiguous: ${accountCode}` : `${label} not found: ${accountCode}`,
    );
  }
  return {
    code: text(rows[0]!.AC_CODE),
    name: text(rows[0]!.AC_NAME),
    gstType: text(rows[0]!.AC_GST_TYPE).toUpperCase(),
  };
}

function component(policy: ResolvedTaxPolicy, srNo: number, taxCode: string): TaxComponent {
  const row = policy.components.get(srNo);
  if (!row) {
    throw new OtherIncomeValidationError(`tax ${taxCode} component ${srNo} is missing`);
  }
  return { group: row.group, percent: number(row.pct) };
}

async function lineTaxTx(
  tx: any,
  scope: VoucherScope,
  party: Account,
  taxCodeInput: unknown,
): Promise<LineTax> {
  const taxCode = text(taxCodeInput);
  const zero = { group: '', percent: 0 };
  if (!taxCode) {
    return { code: '', totalPercent: 0, taxAccount: '', igst: zero, cgst: zero, sgst: zero };
  }
  const policy = await resolveTaxPolicyTx(tx, scope, {
    acCode: party.code,
    taxCode,
    taxPct: 0,
    srNo: 0,
  });
  if (policy.taxPct === 0) {
    return {
      code: policy.taxCode,
      totalPercent: 0,
      taxAccount: text(policy.taxAc),
      igst: zero,
      cgst: zero,
      sgst: zero,
    };
  }
  const taxAccount = text(policy.taxAc);
  if (!taxAccount)
    throw new OtherIncomeValidationError(`tax ${policy.taxCode} has no ledger account`);
  await oneAccountTx(tx, scope, taxAccount, `tax ${policy.taxCode} ledger account`);
  return {
    code: policy.taxCode,
    totalPercent: policy.taxPct,
    taxAccount,
    igst: policy.interState ? component(policy, 3, policy.taxCode) : zero,
    cgst: policy.interState ? zero : component(policy, 2, policy.taxCode),
    sgst: policy.interState ? zero : component(policy, 1, policy.taxCode),
  };
}

async function employeeTx(tx: any, input: OtherIncomeInput): Promise<string> {
  const code = text(input.employeeCode);
  if (!code) return '';
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    code,
  );
  if (rows.length !== 1) throw new OtherIncomeValidationError(`employee not found: ${code}`);
  return code;
}

async function tdsTx(
  tx: any,
  scope: VoucherScope,
  codeInput: unknown,
  basis: number,
): Promise<{ code: string; percent: number; amount: number; account: string }> {
  const code = text(codeInput);
  if (!code) return { code: '', percent: 0, amount: 0, account: '' };
  if (basis < 0) throw new OtherIncomeValidationError('TDS basis is negative');
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAX_CODE","TAX_PRC","TAX_AC" FROM "TAX_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3
        AND coalesce("SR_NO",0)::numeric=0 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1 || !text(rows[0]!.TAX_AC)) {
    throw new OtherIncomeValidationError(
      rows.length ? `TDS tax configuration is ambiguous: ${code}` : `TDS tax not found: ${code}`,
    );
  }
  const account = text(rows[0]!.TAX_AC);
  await oneAccountTx(tx, scope, account, `TDS ${code} ledger account`);
  const percent = number(rows[0]!.TAX_PRC);
  return {
    code: text(rows[0]!.TAX_CODE),
    percent,
    amount: integerMoney((basis * percent) / 100),
    account,
  };
}

async function resolveInputTx(
  tx: any,
  input: OtherIncomeInput,
  mode: OtherPurcMode,
): Promise<ResolvedInput> {
  const words = MODE_TEXT[mode];
  const partyCode = text(input.partyCode);
  if (!partyCode) throw new OtherIncomeValidationError('Please Insert Party and try');
  const ledgerCode = text(input.ledgerCode);
  if (!ledgerCode) throw new OtherIncomeValidationError(`${words.ledger} is required`);
  const party = await oneAccountTx(tx, input.scope, partyCode, words.party);
  const ledger = await oneAccountTx(tx, input.scope, ledgerCode, words.ledger);

  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new OtherIncomeValidationError(`at least one ${words.voucher} line is required`);
  }
  const lines: ResolvedLine[] = [];
  for (const line of input.lines) {
    const itemName = text(line?.itemName).slice(0, 50);
    const netAmount = positiveOrZero(line?.netAmount, 'line net amount');
    if (!itemName || netAmount === 0) {
      throw new OtherIncomeValidationError(
        `every ${words.voucher} line requires a description and amount`,
      );
    }
    const taxType = (text(line?.taxType).toUpperCase() || 'F') as 'F' | 'R';
    if (taxType !== 'F' && taxType !== 'R') {
      throw new OtherIncomeValidationError('Please Select Type F = Forword or R = Reverse ...');
    }
    const discountPercent = number(line?.discountPercent);
    if (!Number.isFinite(discountPercent) || discountPercent < 0) {
      throw new OtherIncomeValidationError('discount percent must be a valid non-negative number');
    }
    const discountAmount =
      line?.discountAmount != null
        ? positiveOrZero(line.discountAmount, 'line discount amount')
        : integerMoney((netAmount * discountPercent) / 100);
    if (discountAmount > netAmount) {
      throw new OtherIncomeValidationError('line discount amount cannot exceed line net amount');
    }
    const tax = await lineTaxTx(tx, input.scope, party, line?.taxCode);
    const afterDiscount = money(netAmount - discountAmount);
    if (taxType === 'R' && tax.totalPercent <= -100) {
      throw new OtherIncomeValidationError(`tax ${tax.code} has invalid reverse percentage`);
    }
    const taxableAmount =
      taxType === 'R' && tax.totalPercent !== 0
        ? money((afterDiscount / (tax.totalPercent + 100)) * 100)
        : afterDiscount;
    const igstAmount = money((taxableAmount * tax.igst.percent) / 100);
    const cgstAmount = money((taxableAmount * tax.cgst.percent) / 100);
    const sgstAmount = money((taxableAmount * tax.sgst.percent) / 100);
    const totalAmount = money(taxableAmount + igstAmount + cgstAmount + sgstAmount);
    lines.push({
      hsnCode: text(line?.hsnCode).slice(0, 10),
      itemName,
      netAmount,
      discountPercent,
      discountAmount,
      taxCode: tax.code,
      taxPercent: tax.totalPercent,
      taxType,
      taxableAmount,
      igstPercent: tax.igst.percent,
      igstAmount,
      cgstPercent: tax.cgst.percent,
      cgstAmount,
      sgstPercent: tax.sgst.percent,
      sgstAmount,
      totalAmount,
      taxAccount: tax.taxAccount,
      taxGroup: tax.igst.group || tax.cgst.group || tax.sgst.group || '',
    });
  }

  const chequeAmount = positiveOrZero(input.chequeAmount, 'cheque amount');
  const cardAmount = positiveOrZero(input.cardAmount, 'card amount');
  const cashAmount = positiveOrZero(input.cashAmount, 'cash amount');
  const kasarAmount = positiveOrZero(input.kasarAmount, 'kasar amount');
  const chequeAccount = text(input.chequeAccount);
  const cardAccount = text(input.cardAccount);
  const cashAccount = text(input.cashAccount);
  const kasarAccount = text(input.kasarAccount);
  if (chequeAmount !== 0 && !chequeAccount) {
    throw new OtherIncomeValidationError('cheque account is required for cheque amount');
  }
  if (cardAmount !== 0 && !cardAccount) {
    throw new OtherIncomeValidationError('card account is required for card amount');
  }
  if (cashAmount !== 0 && !cashAccount) {
    throw new OtherIncomeValidationError('cash account is required for cash amount');
  }
  if (kasarAmount !== 0 && !kasarAccount) {
    throw new OtherIncomeValidationError('kasar account is required for kasar amount');
  }
  if (chequeAccount) await oneAccountTx(tx, input.scope, chequeAccount, 'cheque account');
  if (cardAccount) await oneAccountTx(tx, input.scope, cardAccount, 'card account');
  if (cashAccount) await oneAccountTx(tx, input.scope, cashAccount, 'cash account');
  if (kasarAccount) await oneAccountTx(tx, input.scope, kasarAccount, 'kasar account');

  const netAmount = money(lines.reduce((sum, line) => sum + line.taxableAmount, 0));
  const discountAmount = money(lines.reduce((sum, line) => sum + line.discountAmount, 0));
  const igstAmount = money(lines.reduce((sum, line) => sum + line.igstAmount, 0));
  const cgstAmount = money(lines.reduce((sum, line) => sum + line.cgstAmount, 0));
  const sgstAmount = money(lines.reduce((sum, line) => sum + line.sgstAmount, 0));
  const grossAmount = money(lines.reduce((sum, line) => sum + line.totalAmount, 0));
  const tds = await tdsTx(tx, input.scope, input.tdsCode, money(netAmount - discountAmount));
  const totalAmount = integerMoney(grossAmount - tds.amount);
  const outstandingAmount = money(
    totalAmount - chequeAmount - cardAmount - cashAmount - kasarAmount,
  );
  if (outstandingAmount < 0) {
    throw new OtherIncomeValidationError(`${words.settle} amounts exceed voucher total`);
  }
  return {
    party,
    ledger,
    employeeCode: await employeeTx(tx, input),
    chequeAmount,
    chequeAccount,
    chequeNo: text(input.chequeNo).slice(0, 10),
    cardAmount,
    cardAccount,
    cashAmount,
    cashAccount,
    kasarAmount,
    kasarAccount,
    tdsCode: tds.code,
    tdsPercent: tds.percent,
    tdsAmount: tds.amount,
    tdsAccount: tds.account,
    netAmount,
    discountAmount,
    igstAmount,
    cgstAmount,
    sgstAmount,
    grossAmount,
    totalAmount,
    outstandingAmount,
    lines,
  };
}

function ledgerBase(
  scope: ReturnType<typeof completeFinanceScope>,
  book: OtherIncomeBook,
  identity: VoucherIdentity,
  input: OtherIncomeInput,
  resolved: ResolvedInput,
  suffix: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    VCH_TYPE: book.vchType,
    VCH_DATE: identity.voucherDate,
    LEDR_KEY: `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}${suffix}`,
    BOOK_NAME: book.mainBook,
    BILL_NO: text(input.billNo).slice(0, 30) || identity.voucherNo,
    BILL_DATE: input.billDate ? businessDate(input.billDate, 'bill date').date : null,
    CHQ_NO: '',
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: 0,
    IT_DESC: '',
    ENTRY_TIME: identity.voucherTime,
    HD_VCH_NO: identity.hiddenVoucherNo,
    CLR_DATE: null,
    DATA_TYPE: book.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    FINE_RATE: 0,
    PARTY_AC_CODE: resolved.party.code,
    LDR_NAME: '',
  };
}

function rojmelBase(
  scope: ReturnType<typeof completeFinanceScope>,
  book: OtherIncomeBook,
  identity: VoucherIdentity,
  input: OtherIncomeInput,
  suffix: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    LEDR_KEY: `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}${suffix}`,
    VCH_DATE: identity.voucherDate,
    VCH_TYPE: book.vchType,
    BOOK_NAME: book.mainBook,
    AC_NAME: '',
    IT_TYPE: 'A',
    SIGN: '',
    ITM_PCS: 0,
    ITM_GWT: 0,
    ITM_NWT: 0,
    ITM_TOUCH: 0,
    ITM_WEST: 0,
    ITM_FINE: 0,
    ITM_RATE: 0,
    ITM_AMT: 0,
    LBR_RATE: 0,
    LBR_AMT: 0,
    OTH_AMT: 0,
    NET_AMT: 0,
    IT_DESC: text(input.description),
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: book.dataType,
  };
}

function addLedgerPair(
  ledger: Record<string, unknown>[],
  scope: ReturnType<typeof completeFinanceScope>,
  book: OtherIncomeBook,
  identity: VoucherIdentity,
  input: OtherIncomeInput,
  resolved: ResolvedInput,
  suffix: string,
  partyCode: string,
  contraCode: string,
  amount: number,
) {
  if (!amount) return;
  ledger.push({
    ...ledgerBase(scope, book, identity, input, resolved, suffix),
    AC_CODE: partyCode,
    LD_CODE: contraCode,
    ...side(book.mainBook, 'CR', amount),
    PARTY_AC_CODE: resolved.party.code,
  });
  ledger.push({
    ...ledgerBase(
      scope,
      book,
      identity,
      input,
      resolved,
      String(Number(suffix) + 1).padStart(2, '0'),
    ),
    AC_CODE: contraCode,
    LD_CODE: partyCode,
    ...side(book.mainBook, 'DR', amount),
    PARTY_AC_CODE: '',
  });
}

async function writeTx(
  tx: any,
  input: OtherIncomeInput,
  book: OtherIncomeBook,
  identity: VoucherIdentity,
  resolved: ResolvedInput,
): Promise<void> {
  const scope = completeFinanceScope(input.scope);
  const key = voucherKey(scope, identity.voucherNo);
  const billDate = input.billDate ? businessDate(input.billDate, 'bill date').date : null;
  await insertHiddenIdentityTx(tx, scope, identity, book.configuredName);

  await insertRowTx(tx, 'PAY_DATA', scope.tenantId, {
    ...key,
    VCH_DATE: identity.voucherDate,
    VCH_TIME: identity.voucherTime,
    BILL_NO: text(input.billNo).slice(0, 30) || identity.voucherNo,
    BILL_DATE: billDate,
    BILL_TYPE: '',
    VCH_TYPE: book.vchType,
    INOUT_TYPE: book.inout,
    ENTRY_TYPE: 'P',
    BOOK_NAME: book.mainBook,
    AC_CODE: resolved.party.code,
    AC_NAME: resolved.party.name,
    AC_TYPE: resolved.party.gstType,
    LEDR_CODE: resolved.ledger.code,
    NET_AMT: resolved.netAmount,
    DISC_AMT: resolved.discountAmount,
    IGST_TAX: resolved.igstAmount,
    CGST_TAX: resolved.cgstAmount,
    SGST_TAX: resolved.sgstAmount,
    TDS_CODE: resolved.tdsCode,
    TDS_PRC: resolved.tdsPercent,
    TDS_AMT: resolved.tdsAmount,
    TOT_AMT: resolved.totalAmount,
    CHQ_AMT: resolved.chequeAmount,
    CARD_AMT: resolved.cardAmount,
    CASH_AMT: resolved.cashAmount,
    KASAR_AMT: resolved.kasarAmount,
    BILL_OS: resolved.outstandingAmount,
    HD_VCH_NO: identity.hiddenVoucherNo,
    CARD_AC: resolved.cardAccount,
    BANK_AC: resolved.chequeAccount,
    CHQ_NO: resolved.chequeNo,
    BANK_NAME: text(input.bankName).slice(0, 50),
    EMP_CODE: resolved.employeeCode,
    VCH_DESC: text(input.description),
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  });

  for (let index = 0; index < resolved.lines.length; index++) {
    const line = resolved.lines[index]!;
    const srNo = index + 1;
    await insertRowTx(tx, 'PAY_DETL', scope.tenantId, {
      ...key,
      SR_NO: srNo,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      VCH_TYPE: book.vchType,
      INOUT_TYPE: book.inout,
      ENTRY_TYPE: 'P',
      BOOK_NAME: book.mainBook,
      AC_CODE: resolved.party.code,
      HSN_CODE: line.hsnCode,
      IT_NAME: line.itemName,
      TAX_CODE: line.taxCode,
      TAX_PRC: line.taxPercent,
      NET_AMT: line.netAmount,
      DISC_PRC: line.discountPercent,
      DISC_AMT: line.discountAmount,
      TAX_TYPE: line.taxType,
      TAXABLE_AMT: line.taxableAmount,
      IGST_TAX: line.igstAmount,
      CGST_TAX: line.cgstAmount,
      SGST_TAX: line.sgstAmount,
      IGST_PRC: line.igstPercent,
      CGST_PRC: line.cgstPercent,
      SGST_PRC: line.sgstPercent,
      TOT_AMT: line.totalAmount,
      MAIN_USER: identity.mainUser || null,
    });

    const taxRows =
      resolved.party.gstType === 'I'
        ? [
            {
              srNo,
              percent: line.igstPercent,
              amount: line.igstAmount,
              group: line.taxGroup || 'I',
            },
          ]
        : [
            { srNo, percent: line.sgstPercent, amount: line.sgstAmount, group: line.taxGroup },
            {
              srNo: 111 + srNo,
              percent: line.cgstPercent,
              amount: line.cgstAmount,
              group: line.taxGroup,
            },
          ];
    for (const taxRow of taxRows) {
      if (!line.taxCode || !taxRow.amount) continue;
      await insertRowTx(tx, 'TAX_DATA', scope.tenantId, {
        ...key,
        SR_NO: taxRow.srNo,
        BOOK_NAME: book.mainBook,
        TRAN_TYPE: book.mainBook === 'OTH INC' ? 'S' : 'P',
        VCH_DATE: identity.voucherDate,
        AC_CODE: resolved.party.code,
        TAX_CODE: line.taxCode,
        TAX_TYPE: taxRow.group,
        TAX_PRC: taxRow.percent,
        NET_AMT: line.taxableAmount,
        TAX_AMT: taxRow.amount,
        DISC_AMT: 0,
        TOT_AMT: line.totalAmount,
        TAX_SIGN: book.mainBook === 'OTH INC' ? '+' : '-',
        PARTY_NAME: resolved.party.name,
        R_CHARG: 'N',
        ISR_NO: srNo,
        TAX_FREE_AMT: 0,
        ZERO_RATED_AMT: '0',
      });
    }
  }

  const totalTax = money(resolved.igstAmount + resolved.cgstAmount + resolved.sgstAmount);
  const ledger: Record<string, unknown>[] = [
    {
      ...ledgerBase(scope, book, identity, input, resolved, '01'),
      AC_CODE: resolved.party.code,
      LD_CODE: resolved.ledger.code,
      ...side(book.mainBook, 'DR', money(resolved.totalAmount + resolved.tdsAmount)),
    },
    {
      ...ledgerBase(scope, book, identity, input, resolved, '02'),
      AC_CODE: resolved.ledger.code,
      LD_CODE: resolved.party.code,
      ...side(book.mainBook, 'CR', money(resolved.totalAmount + resolved.tdsAmount - totalTax)),
      PARTY_AC_CODE: '',
    },
  ];
  resolved.lines.forEach((line, index) => {
    const lineTax = money(line.igstAmount + line.cgstAmount + line.sgstAmount);
    if (!lineTax) return;
    ledger.push({
      ...ledgerBase(
        scope,
        book,
        identity,
        input,
        resolved,
        `04${String(index + 1).padStart(10, ' ')}`,
      ),
      AC_CODE: line.taxAccount,
      LD_CODE: resolved.party.code,
      ...side(book.mainBook, 'CR', lineTax),
      PARTY_AC_CODE: '',
      HD_VCH_NO: identity.voucherNo,
    });
  });
  if (resolved.tdsAmount) {
    ledger.push({
      ...ledgerBase(scope, book, identity, input, resolved, '05'),
      AC_CODE: resolved.party.code,
      LD_CODE: resolved.tdsAccount,
      ...side(book.mainBook, 'CR', resolved.tdsAmount),
    });
    ledger.push({
      ...ledgerBase(scope, book, identity, input, resolved, '06'),
      AC_CODE: resolved.tdsAccount,
      LD_CODE: resolved.party.code,
      ...side(book.mainBook, 'DR', resolved.tdsAmount),
      PARTY_AC_CODE: '',
    });
  }
  addLedgerPair(
    ledger,
    scope,
    book,
    identity,
    input,
    resolved,
    '07',
    resolved.party.code,
    resolved.chequeAccount,
    resolved.chequeAmount,
  );
  addLedgerPair(
    ledger,
    scope,
    book,
    identity,
    input,
    resolved,
    '09',
    resolved.party.code,
    resolved.cardAccount,
    resolved.cardAmount,
  );
  addLedgerPair(
    ledger,
    scope,
    book,
    identity,
    input,
    resolved,
    '11',
    resolved.party.code,
    resolved.cashAccount,
    resolved.cashAmount,
  );
  addLedgerPair(
    ledger,
    scope,
    book,
    identity,
    input,
    resolved,
    '13',
    resolved.party.code,
    resolved.kasarAccount,
    resolved.kasarAmount,
  );
  assertBalanced(ledger);
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);

  const rojmel: Record<string, unknown>[] = [];
  if (resolved.outstandingAmount) {
    rojmel.push({
      ...rojmelBase(scope, book, identity, input, '01'),
      AC_CODE: resolved.party.code,
      LD_CODE: resolved.ledger.code,
      ...side(book.mainBook, 'DR', resolved.outstandingAmount),
    });
  }
  if (resolved.totalAmount) {
    rojmel.push({
      ...rojmelBase(scope, book, identity, input, '02'),
      AC_CODE: resolved.ledger.code,
      LD_CODE: resolved.ledger.code,
      ...side(book.mainBook, 'CR', money(resolved.totalAmount + resolved.tdsAmount)),
    });
  }
  if (resolved.tdsAmount) {
    rojmel.push({
      ...rojmelBase(scope, book, identity, input, '03'),
      AC_CODE: resolved.tdsAccount,
      LD_CODE: resolved.party.code,
      ...side(book.mainBook, 'DR', resolved.tdsAmount),
    });
  }
  for (const [suffix, account, amount, name] of [
    ['04', resolved.chequeAccount, resolved.chequeAmount, ''],
    ['05', resolved.cardAccount, resolved.cardAmount, ''],
    ['06', resolved.kasarAccount, resolved.kasarAmount, `KSR - ${resolved.party.name}`],
  ] as const) {
    if (!amount) continue;
    rojmel.push({
      ...rojmelBase(scope, book, identity, input, suffix),
      AC_CODE: account,
      LD_CODE: resolved.party.code,
      ...side(book.mainBook, 'DR', amount),
      AC_NAME: name,
    });
  }
  for (const row of rojmel) await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, row);

  if (text(input.description)) {
    await insertRowTx(tx, 'REMARK_DATA', scope.tenantId, {
      ...key,
      SR_NO: 0,
      VCH_DATE: identity.voucherDate,
      AC_CODE: resolved.party.code,
      AC_NAME: resolved.party.name,
      MAIN_BOOK: book.mainBook,
      VCH_REMARK: text(input.description).slice(0, 250),
    });
  }
}

async function saveTx(
  tx: any,
  mode: OtherPurcMode,
  input: OtherIncomeInput,
  requestedVoucherNo?: string,
): Promise<{ voucherNo: string; hiddenVoucherNo: string; created: boolean; lines: number }> {
  const scope = completeFinanceScope(input.scope);
  const book = await resolveBookTx(tx, scope, mode);
  const { date, iso } = businessDate(input.vchDate);
  await assertFiscalDateTx(tx, scope, iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
  const resolved = await resolveInputTx(tx, input, mode);
  const created = !requestedVoucherNo;
  let identity: VoucherIdentity;
  if (requestedVoucherNo) {
    const edited = await editIdentityTx(tx, {
      table: 'PAY_DATA',
      scope,
      requestedVoucherNo,
      requestedDate: date,
    });
    identity = edited.identity;
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    await replaceWriteSetTx(tx, scope, identity.voucherNo, identity.hiddenVoucherNo, [
      'REMARK_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'TAX_DATA',
      'PAY_DATA',
      'PAY_DETL',
    ]);
  } else {
    identity = await createIdentityTx(tx, scope, date, input.mainUser);
  }
  await writeTx(tx, input, book, identity, resolved);
  return {
    voucherNo: identity.voucherNo,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    created,
    lines: resolved.lines.length,
  };
}

/** Save a TR_OTH_PURC voucher in either mode; `requestedVoucherNo` edits the saved voucher in place. */
export async function saveOtherPurc(
  prisma: any,
  mode: OtherPurcMode,
  input: OtherIncomeInput,
  requestedVoucherNo?: string,
) {
  return withTenant(prisma, input.scope.tenantId, (tx: any) =>
    saveTx(tx, mode, input, requestedVoucherNo),
  );
}

export const saveOtherIncome = (
  prisma: any,
  input: OtherIncomeInput,
  requestedVoucherNo?: string,
) => saveOtherPurc(prisma, 'OTH INC', input, requestedVoucherNo);
export const saveOtherExpense = (
  prisma: any,
  input: OtherIncomeInput,
  requestedVoucherNo?: string,
) => saveOtherPurc(prisma, 'OTH EXP', input, requestedVoucherNo);

export async function getOtherPurc(
  prisma: any,
  mode: OtherPurcMode,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const words = MODE_TEXT[mode];
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope, mode);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT p.*,p."VCH_DATE"::text AS "VCH_DAY",p."BILL_DATE"::text AS "BILL_DAY",
              to_char(p."VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK",
              coalesce(a."AC_NAME",p."AC_NAME",'') AS "MASTER_AC_NAME",
              coalesce(l."AC_NAME",'') AS "LEDR_NAME"
         FROM "PAY_DATA" p
         LEFT JOIN "AC_MAST" a
           ON a.tenant_id=p.tenant_id AND a."CO_CODE"=p."CO_CODE" AND a."AC_CODE"=p."AC_CODE"
         LEFT JOIN "AC_MAST" l
           ON l.tenant_id=p.tenant_id AND l."CO_CODE"=p."CO_CODE" AND l."AC_CODE"=p."LEDR_CODE"
        WHERE p.tenant_id=$1 AND p."CO_CODE"=$2 AND p."LC_CODE"=$3 AND p."CO_YEAR"=$4
          AND p."CO_BOOK"=$5 AND p."VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (headers.length !== 1) {
      throw new OtherIncomeValidationError(
        headers.length
          ? `${words.voucher} voucher is ambiguous: ${voucherNo}`
          : `${words.voucher} voucher not found: ${voucherNo}`,
      );
    }
    const lines: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "PAY_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const h = headers[0]!;
    return {
      voucherNo,
      vchDate: text(h.VCH_DAY).slice(0, 10),
      voucherTime: text(h.VCH_CLOCK),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      partyCode: text(h.AC_CODE),
      partyName: text(h.MASTER_AC_NAME),
      ledgerCode: text(h.LEDR_CODE),
      ledgerName: text(h.LEDR_NAME),
      billNo: text(h.BILL_NO),
      billDate: text(h.BILL_DAY).slice(0, 10),
      chequeAmount: number(h.CHQ_AMT),
      chequeAccount: text(h.BANK_AC),
      chequeNo: text(h.CHQ_NO),
      cardAmount: number(h.CARD_AMT),
      cardAccount: text(h.CARD_AC),
      cashAmount: number(h.CASH_AMT),
      kasarAmount: number(h.KASAR_AMT),
      outstandingAmount: number(h.BILL_OS),
      tdsCode: text(h.TDS_CODE),
      tdsPercent: number(h.TDS_PRC),
      tdsAmount: number(h.TDS_AMT),
      employeeCode: text(h.EMP_CODE),
      bankName: text(h.BANK_NAME),
      description: text(h.VCH_DESC),
      netAmount: number(h.NET_AMT),
      discountAmount: number(h.DISC_AMT),
      igstAmount: number(h.IGST_TAX),
      cgstAmount: number(h.CGST_TAX),
      sgstAmount: number(h.SGST_TAX),
      totalAmount: number(h.TOT_AMT),
      lines: lines.map((line) => ({
        srNo: number(line.SR_NO),
        hsnCode: text(line.HSN_CODE),
        itemName: text(line.IT_NAME),
        netAmount: number(line.NET_AMT),
        discountPercent: number(line.DISC_PRC),
        discountAmount: number(line.DISC_AMT),
        taxCode: text(line.TAX_CODE),
        taxPercent: number(line.TAX_PRC),
        taxType: text(line.TAX_TYPE),
        taxableAmount: number(line.TAXABLE_AMT),
        igstPercent: number(line.IGST_PRC),
        igstAmount: number(line.IGST_TAX),
        cgstPercent: number(line.CGST_PRC),
        cgstAmount: number(line.CGST_TAX),
        sgstPercent: number(line.SGST_PRC),
        sgstAmount: number(line.SGST_TAX),
        totalAmount: number(line.TOT_AMT),
      })),
    };
  });
}

export const getOtherIncome = (prisma: any, scope: VoucherScope, requestedVoucherNo: string) =>
  getOtherPurc(prisma, 'OTH INC', scope, requestedVoucherNo);
export const getOtherExpense = (prisma: any, scope: VoucherScope, requestedVoucherNo: string) =>
  getOtherPurc(prisma, 'OTH EXP', scope, requestedVoucherNo);

export async function deleteOtherPurc(
  prisma: any,
  mode: OtherPurcMode,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
): Promise<{ reversed: true; auditedLines: number }> {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, scope, mode);
    const edited = await editIdentityTx(tx, {
      table: 'PAY_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      checkRequestedDate: false,
    });
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT d.*,coalesce(a."AC_NAME",'') AS "MASTER_AC_NAME"
         FROM "PAY_DETL" d LEFT JOIN "AC_MAST" a
           ON a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE" AND a."AC_CODE"=d."AC_CODE"
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4
          AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO" FOR UPDATE OF d`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length)
      throw new OtherIncomeValidationError(
        `${MODE_TEXT[mode].voucher} voucher not found: ${voucherNo}`,
      );
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: { name: book.configuredName.slice(0, 20), shortName: book.vchType },
      header: { ...rows[0]!, HD_VCH_NO: voucherNo },
      deleteUser,
      rows: rows.map((row) => ({
        srNo: number(row.SR_NO),
        acCode: row.AC_CODE,
        acName: row.MASTER_AC_NAME,
        valueDr: 0,
        valueCr: number(row.TOT_AMT),
        fineType: 'A',
        fineDr: 0,
        fineCr: 0,
        description: text(row.IT_NAME),
      })),
    });
    await replaceWriteSetTx(tx, scope, voucherNo, edited.identity.hiddenVoucherNo, [
      'REMARK_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'TAX_DATA',
      'PAY_DATA',
      'PAY_DETL',
    ]);
    return { reversed: true, auditedLines: rows.length };
  });
}

export const deleteOtherIncome = (
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
) => deleteOtherPurc(prisma, 'OTH INC', scope, requestedVoucherNo, deleteUser);
export const deleteOtherExpense = (
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
) => deleteOtherPurc(prisma, 'OTH EXP', scope, requestedVoucherNo, deleteUser);
