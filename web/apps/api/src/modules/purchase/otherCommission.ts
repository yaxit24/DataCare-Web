import { withTenant } from '@datacare/db';
import { assertBalanced, assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import { resolveBookAccountTx, type BookPolicy } from '../shared/bookPolicy.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
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

export class OtherCommissionValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'OtherCommissionValidationError';
  }
}

export interface OtherCommissionLineInput {
  itemCode: string;
  remark?: string;
  saleAmount: number;
  commissionPercent?: number;
  taxCode?: string;
  taxType?: 'F' | 'R';
}

export interface OtherCommissionInput {
  scope: VoucherScope;
  vchDate: string | Date;
  partyCode: string;
  billNo?: string;
  billDate?: string | Date;
  chequeAmount?: number;
  chequeAccount?: string;
  chequeNo?: string;
  cardAmount?: number;
  cardAccount?: string;
  cashAmount?: number;
  kasarAmount?: number;
  tdsCode?: string;
  employeeCode?: string;
  bankName?: string;
  description?: string;
  lines: OtherCommissionLineInput[];
  mainUser?: string;
}

type OtherCommissionBook = BookPolicy & { configuredName: string; dataType: string };
type Account = { code: string; name: string; gstType: string };
type TaxComponent = { percent: number; account: string; group: string };
type ResolvedTax = {
  code: string;
  totalPercent: number;
  group: string;
  igst: TaxComponent;
  cgst: TaxComponent;
  sgst: TaxComponent;
};
type ResolvedLine = {
  itemCode: string;
  itemName: string;
  remark: string;
  saleAmount: number;
  commissionPercent: number;
  taxableAmount: number;
  taxCode: string;
  taxPercent: number;
  taxType: 'F' | 'R';
  igstPercent: number;
  igstAmount: number;
  cgstPercent: number;
  cgstAmount: number;
  sgstPercent: number;
  sgstAmount: number;
  totalAmount: number;
  taxGroup: string;
};
type ResolvedInput = {
  party: Account;
  employeeCode: string;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  kasarAmount: number;
  tdsCode: string;
  tdsPercent: number;
  tdsAmount: number;
  tdsAccount: string;
  netAmount: number;
  igstAmount: number;
  cgstAmount: number;
  sgstAmount: number;
  grossAmount: number;
  totalAmount: number;
  outstandingAmount: number;
  lines: ResolvedLine[];
};

const money = (value: unknown): number =>
  Math.round((Number(value ?? 0) + Number.EPSILON) * 100) / 100;
const integerMoney = (value: unknown): number => Math.round(Number(value ?? 0));
const number = (value: unknown): number => Number(value ?? 0);

function businessDate(value: string | Date, label = 'voucher date'): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new OtherCommissionValidationError(`${label} is missing or invalid`);
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new OtherCommissionValidationError(`${label} is missing or invalid`);
  }
  return { date, iso: raw };
}

async function resolveBookTx(tx: any, scope: VoucherScope): Promise<OtherCommissionBook> {
  // Desktop TR_OTH_COMM.cs:3039-3047 copies the configured current book's MAIN_BOOK,
  // BOOK_SNAME (saved as VCH_TYPE), and BOOK_INOUT. The save projections at 3547-3550 and
  // 3606-3609 stamp those values. The shipped book seed is OTH COMM / O (MS_UPDATE.cs:27559).
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE"
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
    throw new OtherCommissionValidationError(
      rows.length
        ? `other-commission book configuration is ambiguous: ${scope.coBook}`
        : `other-commission book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  const inout = text(row.BOOK_INOUT).toUpperCase();
  if (mainBook !== 'OTH COMM' || inout !== 'O') {
    throw new OtherCommissionValidationError(
      `book ${scope.coBook} must be configured as OTH COMM / O`,
    );
  }
  return {
    coBook: text(row.CO_BOOK),
    configuredName: text(row.BOOK_NAME) || mainBook,
    vchType: text(row.BOOK_SNAME) || text(row.CO_BOOK),
    bookName: mainBook,
    mainBook,
    inout,
    dataType: text(row.DATA_TYPE) || 'A',
  };
}

async function oneAccountTx(tx: any, scope: VoucherScope, code: string): Promise<Account> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME","AC_GST_TYPE" FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        AND ("LC_CODE" IS NULL OR btrim("LC_CODE"::text)='' OR "LC_CODE"::text=$4)
      ORDER BY CASE WHEN "LC_CODE"::text=$4 THEN 0 ELSE 1 END,row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new OtherCommissionValidationError(
      rows.length ? `account is ambiguous: ${code}` : `account not found: ${code}`,
    );
  }
  return {
    code: text(rows[0]!.AC_CODE),
    name: text(rows[0]!.AC_NAME),
    gstType: text(rows[0]!.AC_GST_TYPE).toUpperCase(),
  };
}

async function resolveItemTx(
  tx: any,
  scope: VoucherScope,
  itemCode: string,
): Promise<{ code: string; name: string }> {
  // TR_OTH_COMM.cs:2411-2445 resolves grid Code/ItDesc from ITEM_MAST; PAY_DETL stores the
  // resolved values as HSN_CODE/IT_NAME at 3613-3614, never a client-supplied item name.
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME" FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 ORDER BY "IT_CODE" LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    itemCode,
  );
  if (rows.length !== 1) {
    throw new OtherCommissionValidationError(
      rows.length ? `item is ambiguous: ${itemCode}` : `item not found: ${itemCode}`,
    );
  }
  return { code: text(rows[0]!.IT_CODE), name: text(rows[0]!.IT_NAME) };
}

async function taxComponentsTx(
  tx: any,
  scope: VoucherScope,
  party: Account,
  taxCode: string,
): Promise<ResolvedTax> {
  if (!taxCode) {
    const zero = { percent: 0, account: '', group: '' };
    return { code: '', totalPercent: 0, group: '', igst: zero, cgst: zero, sgst: zero };
  }
  const headline = await resolveTaxPolicyTx(tx, scope, {
    acCode: party.code,
    taxCode,
    taxPct: 0,
    srNo: 0,
  });
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","TAX_PRC","TAX_AC","TAX_GROUP" FROM "TAX_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3
        AND coalesce("SR_NO",0)::numeric = ANY(ARRAY[0,1,2,3]::numeric[])
      ORDER BY "SR_NO",row_id`,
    scope.tenantId,
    scope.coCode,
    headline.taxCode,
  );
  const component = async (sr: number): Promise<TaxComponent> => {
    const selected = rows.filter((row) => number(row.SR_NO) === sr);
    if (selected.length !== 1) {
      throw new OtherCommissionValidationError(
        `tax ${headline.taxCode} component ${sr} is ${selected.length ? 'ambiguous' : 'missing'}`,
      );
    }
    const account = text(selected[0]!.TAX_AC);
    if (account) await oneAccountTx(tx, scope, account);
    return {
      percent: number(selected[0]!.TAX_PRC),
      account,
      group: text(selected[0]!.TAX_GROUP),
    };
  };
  const base = await component(0);
  const igst = party.gstType === 'I' ? await component(3) : { percent: 0, account: '', group: '' };
  const sgst = party.gstType !== 'I' ? await component(1) : { percent: 0, account: '', group: '' };
  const cgst = party.gstType !== 'I' ? await component(2) : { percent: 0, account: '', group: '' };
  return {
    code: headline.taxCode,
    totalPercent: base.percent,
    group: base.group || headline.taxGroup,
    igst,
    cgst,
    sgst,
  };
}

async function employeeTx(tx: any, input: OtherCommissionInput): Promise<string> {
  const code = text(input.employeeCode);
  if (!code) return '';
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    code,
  );
  if (rows.length !== 1) throw new OtherCommissionValidationError(`employee not found: ${code}`);
  return code;
}

async function tdsTx(
  tx: any,
  scope: VoucherScope,
  code: string,
  netAmount: number,
): Promise<{ code: string; percent: number; amount: number; account: string }> {
  if (!code) return { code: '', percent: 0, amount: 0, account: '' };
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAX_CODE","TAX_PRC","TAX_AC" FROM "TAX_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3
        AND coalesce("SR_NO",0)::numeric=0 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1 || !text(rows[0]!.TAX_AC)) {
    throw new OtherCommissionValidationError(
      rows.length ? `TDS tax configuration is ambiguous: ${code}` : `TDS tax not found: ${code}`,
    );
  }
  const account = text(rows[0]!.TAX_AC);
  await oneAccountTx(tx, scope, account);
  const percent = number(rows[0]!.TAX_PRC);
  // TR_OTH_COMM.cs:4737 calculates NET_AMT*TDS_PRC/100 using desktop-global MsTaxRof.
  // No persisted equivalent of MsTaxRof exists, so web uses the schema's two-decimal money scale
  // and never accepts a client-computed TDS amount.
  return {
    code: text(rows[0]!.TAX_CODE),
    percent,
    amount: money((netAmount * percent) / 100),
    account,
  };
}

async function resolveInputTx(tx: any, input: OtherCommissionInput): Promise<ResolvedInput> {
  const partyCode = text(input.partyCode);
  if (!partyCode) {
    // Exact desktop text: TR_OTH_COMM.cs:3482.
    throw new OtherCommissionValidationError('Please Insert Party and try');
  }
  const party = await oneAccountTx(tx, input.scope, partyCode);
  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new OtherCommissionValidationError('at least one other-commission line is required');
  }
  const lines: ResolvedLine[] = [];
  for (const line of input.lines) {
    const itemCode = text(line?.itemCode);
    const saleAmount = money(line?.saleAmount);
    const commissionPercent = number(line?.commissionPercent);
    const taxType = (text(line?.taxType).toUpperCase() || 'F') as 'F' | 'R';
    if (!itemCode || !Number.isFinite(saleAmount) || saleAmount <= 0) {
      throw new OtherCommissionValidationError(
        'every other-commission line requires an item and positive sale amount',
      );
    }
    if (!Number.isFinite(commissionPercent) || commissionPercent < 0) {
      throw new OtherCommissionValidationError('commission percent must be a non-negative number');
    }
    if (taxType !== 'F' && taxType !== 'R') {
      // Exact desktop text: TR_OTH_COMM.cs:2525.
      throw new OtherCommissionValidationError('Please Select Type F = Forword or R = Reverse ...');
    }
    const item = await resolveItemTx(tx, input.scope, itemCode);
    const tax = await taxComponentsTx(tx, input.scope, party, text(line?.taxCode));
    // TR_OTH_COMM.cs:2687-2729: commission is round(sale*percent/100,0); without commission,
    // reverse tax backs taxable out of sale, otherwise taxable=sale. GST components are then
    // taxable*configured component percent/100 and total is taxable+IGST+CGST+SGST.
    let taxableAmount: number;
    if (commissionPercent !== 0) {
      taxableAmount = integerMoney((saleAmount * commissionPercent) / 100);
    } else if (taxType === 'R') {
      if (tax.totalPercent <= -100) {
        throw new OtherCommissionValidationError(`tax ${tax.code} has invalid reverse percentage`);
      }
      taxableAmount = money((saleAmount / (tax.totalPercent + 100)) * 100);
    } else {
      taxableAmount = saleAmount;
    }
    const igstAmount = money((taxableAmount * tax.igst.percent) / 100);
    const cgstAmount = money((taxableAmount * tax.cgst.percent) / 100);
    const sgstAmount = money((taxableAmount * tax.sgst.percent) / 100);
    lines.push({
      itemCode: item.code,
      itemName: item.name,
      remark: text(line?.remark).slice(0, 50),
      saleAmount,
      commissionPercent,
      taxableAmount,
      taxCode: tax.code,
      taxPercent: tax.totalPercent,
      taxType,
      igstPercent: tax.igst.percent,
      igstAmount,
      cgstPercent: tax.cgst.percent,
      cgstAmount,
      sgstPercent: tax.sgst.percent,
      sgstAmount,
      totalAmount: money(taxableAmount + igstAmount + cgstAmount + sgstAmount),
      taxGroup: tax.group,
    });
  }
  const finiteNonnegative = (value: unknown, label: string): number => {
    const resolved = money(value);
    if (!Number.isFinite(resolved) || resolved < 0) {
      throw new OtherCommissionValidationError(`${label} must be a valid non-negative amount`);
    }
    return resolved;
  };
  const chequeAmount = finiteNonnegative(input.chequeAmount, 'cheque amount');
  const cardAmount = finiteNonnegative(input.cardAmount, 'card amount');
  const cashAmount = finiteNonnegative(input.cashAmount, 'cash amount');
  const kasarAmount = finiteNonnegative(input.kasarAmount, 'kasar amount');
  const chequeAccount = text(input.chequeAccount);
  const cardAccount = text(input.cardAccount);
  if (chequeAmount !== 0 && !chequeAccount) {
    throw new OtherCommissionValidationError('cheque account is required for cheque amount');
  }
  if (cardAmount !== 0 && !cardAccount) {
    throw new OtherCommissionValidationError('card account is required for card amount');
  }
  if (chequeAccount) await oneAccountTx(tx, input.scope, chequeAccount);
  if (cardAccount) await oneAccountTx(tx, input.scope, cardAccount);
  const netAmount = money(lines.reduce((sum, line) => sum + line.taxableAmount, 0));
  const igstAmount = money(lines.reduce((sum, line) => sum + line.igstAmount, 0));
  const cgstAmount = money(lines.reduce((sum, line) => sum + line.cgstAmount, 0));
  const sgstAmount = money(lines.reduce((sum, line) => sum + line.sgstAmount, 0));
  const grossAmount = money(lines.reduce((sum, line) => sum + line.totalAmount, 0));
  const tds = await tdsTx(tx, input.scope, text(input.tdsCode), netAmount);
  // TR_OTH_COMM.cs:4739-4740 rounds gross less TDS to whole currency and derives outstanding
  // after cheque/card/cash/kasar. These totals are always server-derived.
  const totalAmount = integerMoney(grossAmount - tds.amount);
  const outstandingAmount = money(
    totalAmount - chequeAmount - cardAmount - cashAmount - kasarAmount,
  );
  if (outstandingAmount < 0) {
    throw new OtherCommissionValidationError('payment amounts exceed voucher total');
  }
  return {
    party,
    employeeCode: await employeeTx(tx, input),
    chequeAmount,
    chequeAccount,
    chequeNo: text(input.chequeNo).slice(0, 10),
    cardAmount,
    cardAccount,
    cashAmount,
    kasarAmount,
    tdsCode: tds.code,
    tdsPercent: tds.percent,
    tdsAmount: tds.amount,
    tdsAccount: tds.account,
    netAmount,
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
  book: OtherCommissionBook,
  identity: VoucherIdentity,
  input: OtherCommissionInput,
  resolved: ResolvedInput,
  suffix: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    VCH_TYPE: book.vchType,
    VCH_DATE: identity.voucherDate,
    LEDR_KEY: `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}${suffix}`,
    BOOK_NAME: book.mainBook,
    BILL_NO: text(input.billNo).slice(0, 30),
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
  book: OtherCommissionBook,
  identity: VoucherIdentity,
  input: OtherCommissionInput,
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

async function writeTx(
  tx: any,
  input: OtherCommissionInput,
  book: OtherCommissionBook,
  identity: VoucherIdentity,
  resolved: ResolvedInput,
): Promise<void> {
  const scope = completeFinanceScope(input.scope);
  const key = voucherKey(scope, identity.voucherNo);
  // Desktop TR_OTH_COMM.cs:3130-3150 numbers PAY_DATA by company+location+year+book and
  // TEMP_BOOK_DATA independently by company+location+book (no year). Save lines 3530-3541 insert
  // the hidden identity using configured BOOK_DATA.BOOK_NAME; shared lifecycle locks both counters.
  await insertHiddenIdentityTx(tx, scope, identity, book.configuredName);
  const billDate = input.billDate ? businessDate(input.billDate, 'bill date').date : null;

  // Complete PAY_DATA projection from TR_OTH_COMM.cs:3542-3581. Totals, names, tax rates and
  // account metadata are resolved/calculated above; no matching request values are trusted.
  await insertRowTx(tx, 'PAY_DATA', scope.tenantId, {
    ...key,
    VCH_DATE: identity.voucherDate,
    VCH_TIME: identity.voucherTime,
    BILL_NO: text(input.billNo).slice(0, 30),
    BILL_DATE: billDate,
    BILL_TYPE: '',
    VCH_TYPE: book.vchType,
    INOUT_TYPE: book.inout,
    ENTRY_TYPE: 'P',
    BOOK_NAME: book.mainBook,
    AC_CODE: resolved.party.code,
    AC_NAME: resolved.party.name,
    AC_TYPE: resolved.party.gstType,
    LEDR_CODE: '',
    NET_AMT: resolved.netAmount,
    IGST_TAX: resolved.igstAmount,
    CGST_TAX: resolved.cgstAmount,
    SGST_TAX: resolved.sgstAmount,
    TOT_AMT: resolved.totalAmount,
    CASH_AMT: resolved.cashAmount,
    CHQ_AMT: resolved.chequeAmount,
    BANK_AC: resolved.chequeAccount,
    CHQ_NO: resolved.chequeNo,
    CARD_AMT: resolved.cardAmount,
    CARD_AC: resolved.cardAccount,
    KASAR_AMT: resolved.kasarAmount,
    BILL_OS: resolved.outstandingAmount,
    HD_VCH_NO: identity.hiddenVoucherNo,
    EMP_CODE: resolved.employeeCode,
    VCH_DESC: text(input.description),
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    BANK_NAME: text(input.bankName).slice(0, 50),
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    DISC_PRC: 0,
    DISC_AMT: 0,
    TDS_CODE: resolved.tdsCode,
    TDS_PRC: resolved.tdsPercent,
    TDS_AMT: resolved.tdsAmount,
  });

  for (let index = 0; index < resolved.lines.length; index++) {
    const line = resolved.lines[index]!;
    const srNo = index + 1;
    // Complete PAY_DETL projection from TR_OTH_COMM.cs:3594-3632. BILL_* and DISC_* are schema
    // columns not assigned by this form and are written as desktop defaults (blank/null/zero).
    await insertRowTx(tx, 'PAY_DETL', scope.tenantId, {
      ...key,
      SR_NO: srNo,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      BILL_NO: '',
      BILL_DATE: null,
      BILL_TYPE: '',
      VCH_TYPE: book.vchType,
      INOUT_TYPE: book.inout,
      ENTRY_TYPE: 'P',
      BOOK_NAME: book.mainBook,
      AC_CODE: resolved.party.code,
      HSN_CODE: line.itemCode,
      IT_NAME: line.itemName,
      TAX_CODE: line.taxCode,
      TAX_PRC: line.taxPercent,
      NET_AMT: line.saleAmount,
      TAX_TYPE: line.taxType,
      TAXABLE_AMT: line.taxableAmount,
      IGST_PRC: line.igstPercent,
      IGST_TAX: line.igstAmount,
      CGST_PRC: line.cgstPercent,
      CGST_TAX: line.cgstAmount,
      SGST_PRC: line.sgstPercent,
      SGST_TAX: line.sgstAmount,
      TOT_AMT: line.totalAmount,
      MAIN_USER: identity.mainUser || null,
      DISC_PRC: 0,
      DISC_AMT: 0,
      COMM_PRC: line.commissionPercent,
      IT_REMARK: line.remark,
    });

    // Ac_Tax.cs:277-285 writes one local row per SGST/CGST component (CGST SR=111+line SR)
    // or one interstate IGST row. TAX_MAST supplies type/rate; AC_MAST supplies party name.
    const taxRows =
      resolved.party.gstType === 'I'
        ? [{ srNo, percent: line.igstPercent, amount: line.igstAmount }]
        : [
            { srNo, percent: line.sgstPercent, amount: line.sgstAmount },
            { srNo: 111 + srNo, percent: line.cgstPercent, amount: line.cgstAmount },
          ];
    for (const taxRow of taxRows) {
      if (!line.taxCode || taxRow.amount === 0) continue;
      await insertRowTx(tx, 'TAX_DATA', scope.tenantId, {
        ...key,
        SR_NO: taxRow.srNo,
        BOOK_NAME: book.mainBook,
        TRAN_TYPE: 'S',
        VCH_DATE: identity.voucherDate,
        AC_CODE: resolved.party.code,
        TAX_CODE: line.taxCode,
        TAX_TYPE: line.taxGroup,
        TAX_PRC: taxRow.percent,
        NET_AMT: line.taxableAmount,
        TAX_AMT: taxRow.amount,
        DISC_AMT: 0,
        TOT_AMT: line.totalAmount,
        TAX_SIGN: '+',
        PARTY_NAME: resolved.party.name,
        R_CHARG: 'N',
        ISR_NO: 0,
        TAX_FREE_AMT: 0,
        ZERO_RATED_AMT: '0',
        BILL_NO: text(input.billNo).slice(0, 20),
        BILL_DATE: billDate,
        BILL_DBCD: scope.coBook,
        VCH_SRNO: String(srNo),
      });
    }
  }

  const cashAccount = await resolveBookAccountTx(tx, scope, book, 1);
  const commissionAccount = await resolveBookAccountTx(tx, scope, book, 2);
  const kasarAccount = resolved.kasarAmount ? await resolveBookAccountTx(tx, scope, book, 3) : '';
  await oneAccountTx(tx, scope, cashAccount);
  await oneAccountTx(tx, scope, commissionAccount);
  if (kasarAccount) await oneAccountTx(tx, scope, kasarAccount);
  // Ac_Ledr.cs:1921-1949 is the exact 13-leg template: SR2 commission contra, explicit desktop
  // output-tax account 00085, SR1 cash, selected validated bank/card accounts, SR3 kasar, and
  // TAX_MAST SR0 TDS account. Each optional movement is represented as a balanced pair.
  const outputTaxAccount = '00085';
  const totalTax = money(resolved.igstAmount + resolved.cgstAmount + resolved.sgstAmount);
  if (totalTax) await oneAccountTx(tx, scope, outputTaxAccount);
  const ledger: Record<string, unknown>[] = [];
  const addPair = (
    suffix: string,
    creditCode: string,
    debitCode: string,
    amount: number,
    partyOnCredit = false,
    partyOnDebit = false,
  ) => {
    if (!amount) return;
    ledger.push({
      ...ledgerBase(scope, book, identity, input, resolved, suffix),
      AC_CODE: creditCode,
      LD_CODE: debitCode,
      CR_AMT: amount,
      DR_AMT: 0,
      PARTY_AC_CODE: partyOnCredit ? resolved.party.code : '',
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
      AC_CODE: debitCode,
      LD_CODE: creditCode,
      CR_AMT: 0,
      DR_AMT: amount,
      PARTY_AC_CODE: partyOnDebit ? resolved.party.code : '',
    });
  };
  ledger.push({
    ...ledgerBase(scope, book, identity, input, resolved, '01'),
    AC_CODE: resolved.party.code,
    LD_CODE: commissionAccount,
    CR_AMT: 0,
    DR_AMT: money(resolved.totalAmount + resolved.tdsAmount),
  });
  ledger.push({
    ...ledgerBase(scope, book, identity, input, resolved, '02'),
    AC_CODE: commissionAccount,
    LD_CODE: resolved.party.code,
    CR_AMT: money(resolved.totalAmount + resolved.tdsAmount - totalTax),
    DR_AMT: 0,
    PARTY_AC_CODE: '',
  });
  if (totalTax) {
    ledger.push({
      ...ledgerBase(scope, book, identity, input, resolved, '03'),
      AC_CODE: outputTaxAccount,
      LD_CODE: resolved.party.code,
      CR_AMT: totalTax,
      DR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  }
  addPair('04', resolved.party.code, resolved.chequeAccount, resolved.chequeAmount, true);
  addPair('06', resolved.party.code, resolved.cardAccount, resolved.cardAmount, true);
  addPair('08', resolved.party.code, cashAccount, resolved.cashAmount, true);
  addPair('10', resolved.party.code, kasarAccount, resolved.kasarAmount, true);
  addPair('12', resolved.party.code, resolved.tdsAccount, resolved.tdsAmount);
  assertBalanced(ledger);
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);

  // Ac_Rojmel.cs:913-927 writes outstanding party DR/SR2 contra CR, plus cheque/card debits,
  // SR3 kasar debit and TDS-account debit. The full 34-column projection uses zero stock values.
  const rojmel: Record<string, unknown>[] = [];
  if (resolved.outstandingAmount) {
    rojmel.push({
      ...rojmelBase(scope, book, identity, input, '01'),
      AC_CODE: resolved.party.code,
      LD_CODE: commissionAccount,
      CR_AMT: 0,
      DR_AMT: resolved.outstandingAmount,
    });
  }
  rojmel.push({
    ...rojmelBase(scope, book, identity, input, '02'),
    AC_CODE: commissionAccount,
    LD_CODE: resolved.party.code,
    CR_AMT: money(resolved.totalAmount + resolved.tdsAmount),
    DR_AMT: 0,
  });
  for (const row of [
    ['03', resolved.chequeAccount, resolved.chequeAmount, ''],
    ['04', resolved.cardAccount, resolved.cardAmount, ''],
    ['05', kasarAccount, resolved.kasarAmount, `KSR - ${resolved.party.name}`],
    ['06', resolved.tdsAccount, resolved.tdsAmount, ''],
  ] as const) {
    if (!row[2]) continue;
    rojmel.push({
      ...rojmelBase(scope, book, identity, input, row[0]),
      AC_CODE: row[1],
      LD_CODE: resolved.party.code,
      CR_AMT: 0,
      DR_AMT: row[2],
      AC_NAME: row[3],
    });
  }
  for (const row of rojmel) await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, row);

  // Ac_Tax.cs:751 (Vch_Remark called by TR_OTH_COMM.cs:3646) maps PAY_DATA VCH_DESC to a
  // single SR0 REMARK_DATA row with party identity and MAIN_BOOK.
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
  input: OtherCommissionInput,
  requestedVoucherNo?: string,
): Promise<{ voucherNo: string; hiddenVoucherNo: string; created: boolean; lines: number }> {
  const scope = completeFinanceScope(input.scope);
  const book = await resolveBookTx(tx, scope);
  const { date, iso } = businessDate(input.vchDate);
  // Exact desktop save messages at TR_OTH_COMM.cs:3452-3489 include licence expiry, company B,
  // fiscal range, lock date, rights, missing party and missing voucher number. Rights are handled by
  // route guard; licence/company flags are not request-controlled. Fiscal/lock checks fail closed.
  await assertFiscalDateTx(tx, scope, iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
  const resolved = await resolveInputTx(tx, input);
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
    // TR_OTH_COMM.cs:3522-3646 deletes and rebuilds PAY_DATA/PAY_DETL/TEMP_BOOK_DATA/AC_DATA/
    // ROJ_MEL_DATA/TAX_DATA/REMARK_DATA on edit. INSERT DELETE_DATA exists only in delete handler
    // line 3726, so edit never creates an audit row. editIdentityTx preserves MAIN_USER,
    // HD_VCH_NO and VCH_TIME wall-clock loaded at lines 3170-3171 and 3237.
    await replaceWriteSetTx(tx, scope, identity.voucherNo, identity.hiddenVoucherNo, [
      'REMARK_DATA',
      'AC_DATA',
      'TAX_DATA',
      'ROJ_MEL_DATA',
      'PAY_DETL',
      'PAY_DATA',
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

export async function saveOtherCommission(
  prisma: any,
  input: OtherCommissionInput,
  requestedVoucherNo?: string,
) {
  return withTenant(prisma, input.scope.tenantId, (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getOtherCommission(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope);
    // TR_OTH_COMM.cs:3157-3237 loads PAY_DATA and preserves VCH_TIME wall-clock, HD_VCH_NO and
    // MAIN_USER; lines 3346-3372 restore PAY_DETL. Display names remain server/master-derived.
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT p.*,p."VCH_DATE"::text AS "VCH_DAY",p."BILL_DATE"::text AS "BILL_DAY",
              to_char(p."VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK",
              coalesce(a."AC_NAME",p."AC_NAME",'') AS "MASTER_AC_NAME"
         FROM "PAY_DATA" p LEFT JOIN "AC_MAST" a
           ON a.tenant_id=p.tenant_id AND a."CO_CODE"=p."CO_CODE" AND a."AC_CODE"=p."AC_CODE"
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
      throw new OtherCommissionValidationError(
        headers.length
          ? `other-commission voucher is ambiguous: ${voucherNo}`
          : `other-commission voucher not found: ${voucherNo}`,
      );
    }
    const lines: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT d.*,coalesce(i."IT_NAME",d."IT_NAME",'') AS "MASTER_ITEM_NAME"
         FROM "PAY_DETL" d LEFT JOIN "ITEM_MAST" i
           ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."HSN_CODE"
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4
          AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO"`,
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
      igstAmount: number(h.IGST_TAX),
      cgstAmount: number(h.CGST_TAX),
      sgstAmount: number(h.SGST_TAX),
      totalAmount: number(h.TOT_AMT),
      lines: lines.map((line) => ({
        srNo: number(line.SR_NO),
        itemCode: text(line.HSN_CODE),
        itemName: text(line.MASTER_ITEM_NAME),
        remark: text(line.IT_REMARK),
        saleAmount: number(line.NET_AMT),
        commissionPercent: number(line.COMM_PRC),
        taxableAmount: number(line.TAXABLE_AMT),
        taxCode: text(line.TAX_CODE),
        taxPercent: number(line.TAX_PRC),
        taxType: text(line.TAX_TYPE),
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

export async function deleteOtherCommission(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
): Promise<{ reversed: true; auditedLines: number }> {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, scope);
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
      throw new OtherCommissionValidationError(`other-commission voucher not found: ${voucherNo}`);
    // Exact DELETE_DATA mapping, TR_OTH_COMM.cs:3726: scope/VCH_NO/SR_NO/VCH_DATE/VCH_TIME/
    // MAIN_USER from PAY_DETL A; deletion date/time/user at deletion; VCH_TYPE=BOOK_SNAME;
    // BOOK_NAME=substring(BOOK_DATA.BOOK_NAME,1,20); AC_CODE=A.AC_CODE; AC_NAME=AC_MAST;
    // VCH_VAL_DR=0; VCH_VAL_CR=A.TOT_AMT; FINE_TYPE='A'; both fine values=0;
    // HD_VCH_NO=A.VCH_NO (not A.HD_VCH_NO); VCH_DESC=A.IT_NAME.
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
    // TR_OTH_COMM.cs:3728-3734 removes the complete write set, including hidden identity.
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
