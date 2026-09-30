import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';
import {
  calculateEBillLine,
  calculateEBillTotals,
  eBillLabourRateDigits,
  eBillLineIsSaved,
  eBillTaxDigits,
  eInvoiceTcs,
  round,
  type EBillLineResult,
  type EBillPolicy,
  type EBillTotals,
} from '@datacare/core';
import { assertBalanced, assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import { resolveTaxPolicyTx } from '../shared/taxPolicy.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { partyCashReceivedTx } from '../finance/finance.js';
import { resolveBookSlotRowsTx, type BookSlotRow } from '../shared/postingAccounts.js';
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
  type CompleteFinanceScope,
  type VoucherIdentity,
} from '../finance/lifecycle.js';

/**
 * TR_SL_EBILL create / edit / delete in both of its modes (card X15):
 *
 *   E CRNT     credit note on an inward book — stock back in, GST reversed (TAX_SIGN '-')
 *   E INVOICE  outward e-invoice            — stock out, GST output (TAX_SIGN '+'), TCS/TDS
 *
 * The form, arithmetic and validations are shared; the posting helpers (Ac_Ledr.EInvoice_Ledr,
 * Ac_Rojmel.EInvoice_Rojmel, Ac_Stock.EInvoice_Stk / Dm_Sale_eInv_Detl, Ac_Tax.EInvoice_GST and
 * Vch_Remark) branch on BOOK_DATA.MAIN_BOOK. The source contract and every deliberate web adaptation
 * are in parity-plan-2026-09-10/evidence/implementation-2026-09-29-x15/ecrnt-lifecycle-contract.md.
 * This is NOT the ordinary Sale / Sale Return writer.
 */

export type EBillFamily = 'E CRNT' | 'E INVOICE';

export class EBillWriteValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'EBillWriteValidationError';
  }
}

/** A stale edit/delete: the saved voucher changed after the operator opened it. Mapped to 409. */
export class EBillConflictError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'EBillConflictError';
  }
}

export interface EBillEntryLineInput {
  oldSrNo?: number;
  itemCode?: string;
  remark?: string;
  designNo?: string;
  size?: string;
  tagNo?: string;
  hmId?: string;
  pcs?: number;
  bagWt?: number;
  grossWt?: number;
  lessWt?: number;
  ghatPercent?: number;
  touch?: number;
  westPercent?: number;
  rate?: number;
  rateType?: string;
  labourType?: string;
  labourRate?: number;
  labourPercent?: number;
  otherAmount?: number;
  mrp?: number;
  taxCode?: string;
}

export interface EBillEntryInput {
  scope: VoucherScope;
  vchDate: string | Date;
  partyCode: string;
  billNo?: string;
  ledgerCode?: string;
  employeeCode?: string;
  description?: string;
  cashAmount?: number;
  chequeAmount?: number;
  chequeAccount?: string;
  chequeNo?: string;
  cardAmount?: number;
  cardAccount?: string;
  cardCommission?: number;
  kasarAmount?: number;
  /** E INVOICE only: '' none, otherwise a TAX_MAST SR_NO 0 code (the desktop offers 25 / 00). */
  tdsCode?: string;
  /** E INVOICE only: '' automatic threshold rule, '00' none, otherwise a picked code. */
  tcsCode?: string;
  /** E INVOICE only: amount typed for a picked TCS code below the threshold on a new voucher. */
  tcsAmount?: number;
  lines: EBillEntryLineInput[];
  mainUser?: string;
  /** Revision returned by the entry reader; when present a changed voucher is refused (409). */
  expectedRevision?: string;
}

type Row = Record<string, unknown>;
type Account = { code: string; name: string; gstType: string };
type BookSlot = BookSlotRow;
type EBook = {
  family: EBillFamily;
  coBook: string;
  configuredName: string;
  shortName: string;
  mainBook: EBillFamily;
  inout: string;
  itemType: string;
  dataType: string;
  bookType: string;
  tableName: string;
  slots: Map<number, BookSlot>;
};
type TaxComponent = { group: string; percent: number };
type LineTax = {
  code: string;
  percent: number;
  igst: TaxComponent | null;
  cgst: TaxComponent | null;
  sgst: TaxComponent | null;
};
type TaxHead = { code: string; name: string; percent: number; account: string };
type ResolvedLine = {
  srNo: number;
  oldSrNo: number;
  itemCode: string;
  itemName: string;
  itemType: string;
  productCode: string;
  saleAccount: string;
  remark: string;
  designNo: string;
  size: string;
  hmId: string;
  bagWt: number;
  tax: LineTax;
  calc: EBillLineResult;
};
type Resolved = {
  party: Account;
  ledger: Account | null;
  employeeCode: string;
  interState: boolean;
  gstType: string;
  lines: ResolvedLine[];
  bill: EBillTotals;
  tcs: { code: string; percent: number; account: string; accountName: string };
  tds: { code: string; percent: number; account: string };
  chequeAccount: string;
  chequeNo: string;
  cardAccount: string;
  cardCommission: number;
  cashAccount: string;
  kasarAccount: string;
  taxAccount: string;
  taxAccountName: string;
};

const FAMILY: Record<
  EBillFamily,
  {
    inout: 'I' | 'O';
    invoice: boolean;
    label: string;
    roundOffSlot: number;
    roundOffSuffix: string;
    stockType: string;
    stockSign: string;
    taxSign: string;
  }
> = {
  'E CRNT': {
    inout: 'I',
    invoice: false,
    label: 'credit note',
    roundOffSlot: 4,
    roundOffSuffix: '16',
    stockType: 'I',
    stockSign: '+',
    taxSign: '-',
  },
  'E INVOICE': {
    inout: 'O',
    invoice: true,
    label: 'e-invoice',
    roundOffSlot: 5,
    roundOffSuffix: '15',
    stockType: 'S',
    stockSign: '-',
    taxSign: '+',
  },
};

/** BtnDelete_Click (7880-7896) removes these; save rebuilds SAVE_TABLES. */
const DELETE_TABLES = [
  'REMARK_DATA',
  'MAIN_STOCK',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'SL_ORD_ADJ',
  'TAX_DATA',
  'DM_DATA',
  'SL_DATA',
  'SL_DETL',
  'SL_IDTL',
  'SL_PR_DETL',
] as const;
/** Save deletes/re-inserts these (7493-7801, REMARK_DATA through Vch_Remark). */
const SAVE_TABLES = [
  'SL_DATA',
  'SL_DETL',
  'SL_IDTL',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'TAX_DATA',
  'DM_DATA',
  'REMARK_DATA',
] as const;

const num = (value: unknown): number => {
  const v = Number(value ?? 0);
  return Number.isFinite(v) ? v : Number.NaN;
};
/** Strings.Format "0.00" (half-up, away from zero) — the desktop's display/save rounding. */
const money = (value: unknown): number => round(Number(value ?? 0), 2);
const nonNegative = (value: unknown, label: string): number => {
  const v = num(value);
  if (!Number.isFinite(v) || v < 0)
    throw new EBillWriteValidationError(`${label} must be a valid non-negative number`);
  return v;
};
/** SQL Server STR(n): default width 10, right aligned (LEDR_KEY line suffixes). */
const sqlStr = (value: number): string => String(value).padStart(10, ' ');
const keyWhere = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;
const keyArgs = (scope: CompleteFinanceScope, voucherNo: string) => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];

function businessDate(value: string | Date, label = 'voucher date'): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (
    !/^\d{4}-\d{2}-\d{2}$/.test(raw) ||
    Number.isNaN(date.getTime()) ||
    date.toISOString().slice(0, 10) !== raw
  ) {
    throw new EBillWriteValidationError(`${label} is missing or invalid`);
  }
  return { date, iso: raw };
}

async function resolveBookTx(
  tx: any,
  family: EBillFamily,
  scope: CompleteFinanceScope,
): Promise<EBook> {
  const f = FAMILY[family];
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME","ITM_TYPE",
            "DATA_TYPE","BOOK_TYPE"
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
    throw new EBillWriteValidationError(
      rows.length
        ? `${f.label} book configuration is ambiguous: ${scope.coBook}`
        : `Please Creat Book From ${family}.... (book ${scope.coBook} not found)`,
    );
  }
  const row = rows[0]!;
  const table = text(row.BOOK_TBL_NAME).toUpperCase();
  if (
    text(row.MAIN_BOOK).toUpperCase() !== family ||
    text(row.BOOK_INOUT).toUpperCase() !== f.inout
  ) {
    throw new EBillWriteValidationError(
      `book ${scope.coBook} must be configured as ${family} / ${f.inout}`,
    );
  }
  if (table && table !== 'SL_DATA') {
    throw new EBillWriteValidationError(`book ${scope.coBook} must write SL_DATA`);
  }
  // Ac_Ledr.EInvoice_Ledr posts the per-line sale rows only when BOOK_DATA.ITM_TYPE = 'A'; any
  // other value would leave the party row without its counterpart.
  if (text(row.ITM_TYPE).toUpperCase() !== 'A') {
    throw new EBillWriteValidationError(
      `book ${scope.coBook} must have item type A for ${family} posting`,
    );
  }
  // EInvoice_Ledr/Rojmel read VCH_TYPE, BOOK_NAME and DATA_TYPE from the BOOK_DETL slot row.
  const slots = await resolveBookSlotRowsTx(tx, scope, 'party-control');
  return {
    family,
    coBook: text(row.CO_BOOK),
    configuredName: text(row.BOOK_NAME),
    shortName: text(row.BOOK_SNAME),
    mainBook: family,
    inout: text(row.BOOK_INOUT).toUpperCase(),
    itemType: text(row.ITM_TYPE).toUpperCase(),
    dataType: text(row.DATA_TYPE),
    bookType: text(row.BOOK_TYPE),
    tableName: text(row.BOOK_TBL_NAME),
    slots,
  };
}

function requireSlot(book: EBook, srNo: number, purpose: string): BookSlot {
  const slot = book.slots.get(srNo);
  if (!slot || !slot.accountCode) {
    throw new EBillWriteValidationError(
      `book ${book.coBook} BOOK_DETL slot ${srNo} (${purpose}) has no account`,
    );
  }
  return slot;
}

async function accountTx(
  tx: any,
  scope: VoucherScope,
  code: string,
  label: string,
): Promise<Account> {
  const accountCode = text(code);
  if (!accountCode) throw new EBillWriteValidationError(`${label} is required`);
  const rows: Row[] = await tx.$queryRawUnsafe(
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
    throw new EBillWriteValidationError(
      rows.length ? `${label} is ambiguous: ${accountCode}` : `${label} not found: ${accountCode}`,
    );
  }
  return {
    code: text(rows[0]!.AC_CODE),
    name: text(rows[0]!.AC_NAME),
    gstType: text(rows[0]!.AC_GST_TYPE).toUpperCase(),
  };
}

async function companySettingsTx(tx: any, scope: CompleteFinanceScope) {
  const behavior = await resolveSettingsBehaviorTx(tx, scope);
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT s."TAX_ROF", s."LBR_ROF", s."EMP_CODE_MANDATORY",
            (SELECT string_agg(DISTINCT upper(btrim(coalesce(c."CO_TYPE"::text,''))), ',')
               FROM "CO_MAST" c WHERE c.tenant_id=s.tenant_id AND c."CO_CODE"=s."CO_CODE") AS co_type
       FROM "CO_SET" s WHERE s.tenant_id=$1 AND s."CO_CODE"::text=$2::text`,
    scope.tenantId,
    scope.coCode,
  );
  const row = rows[0] ?? {};
  let taxDigits: number;
  let labourRateDigits: number;
  try {
    taxDigits = eBillTaxDigits(row.TAX_ROF);
    labourRateDigits = eBillLabourRateDigits(row.LBR_ROF);
  } catch (error) {
    throw new EBillWriteValidationError((error as Error).message);
  }
  const coType = text(row.co_type);
  if (coType.includes(',')) {
    throw new EBillWriteValidationError(`company ${scope.coCode} has conflicting CO_TYPE`);
  }
  return {
    behavior,
    taxDigits,
    labourRateDigits,
    employeeMandatory: text(row.EMP_CODE_MANDATORY).toUpperCase() === 'Y',
    companyType: coType,
    labourType: behavior.labourType || 'G',
  };
}

async function lineTaxTx(
  tx: any,
  scope: VoucherScope,
  party: Account,
  code: string,
): Promise<LineTax> {
  if (!code) return { code: '', percent: 0, igst: null, cgst: null, sgst: null };
  let policy;
  try {
    policy = await resolveTaxPolicyTx(tx, scope, { acCode: party.code, taxCode: code, taxPct: 0 });
  } catch (error) {
    throw new EBillWriteValidationError((error as Error).message);
  }
  const component = (srNo: number) => {
    const c = policy.components.get(srNo);
    return c ? { group: c.group, percent: c.pct } : null;
  };
  return {
    code: policy.taxCode,
    percent: policy.taxPct,
    igst: component(3),
    cgst: component(2),
    sgst: component(1),
  };
}

/** TAX_MAST head row (SR_NO 0), as the TCS/TDS/tax posting joins pin it. */
async function taxHeadTx(tx: any, scope: VoucherScope, code: string): Promise<TaxHead | null> {
  if (!code) return null;
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT t."TAX_CODE", t."TAX_NAME", t."TAX_PRC", t."TAX_AC", a."AC_NAME"
       FROM "TAX_MAST" t
       LEFT JOIN "AC_MAST" a ON a.tenant_id=t.tenant_id AND a."CO_CODE"=t."CO_CODE" AND a."AC_CODE"=t."TAX_AC"
      WHERE t.tenant_id=$1 AND t."CO_CODE"=$2 AND t."TAX_CODE"=$3 AND coalesce(t."SR_NO",0)=0
      LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length > 1)
    throw new EBillWriteValidationError(`tax code ${code} has more than one SR_NO 0 row`);
  if (!rows.length) return null;
  const r = rows[0]!;
  return {
    code: text(r.TAX_CODE),
    name: text(r.TAX_NAME) || text(r.AC_NAME),
    percent: Number(r.TAX_PRC ?? 0),
    account: text(r.TAX_AC),
  };
}

async function accountNameTx(tx: any, scope: VoucherScope, code: string): Promise<string> {
  if (!code) return '';
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return text(rows[0]?.AC_NAME);
}

async function itemTx(tx: any, scope: VoucherScope, code: string) {
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT i."IT_CODE",i."IT_NAME",i."IT_TYPE",i."PR_CODE",i."RATE_TYPE",i."TAG_TYPE",
            g."SALE_AC", count(g.*) OVER () AS group_count
       FROM "ITEM_MAST" i
       LEFT JOIN "GROUP_MAST" g
         ON g.tenant_id=i.tenant_id AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
      WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"=$3 LIMIT 3`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1) {
    throw new EBillWriteValidationError(
      rows.length ? `item configuration is ambiguous: ${code}` : `item not found: ${code}`,
    );
  }
  const r = rows[0]!;
  return {
    code: text(r.IT_CODE),
    name: text(r.IT_NAME),
    itemType: text(r.IT_TYPE),
    productCode: text(r.PR_CODE),
    rateType: text(r.RATE_TYPE),
    saleAccount: text(r.SALE_AC),
  };
}

/**
 * AcTcsAmt (tAcCode_KeyDown 8417): the party's AC_DATA debits (DATA_TYPE 'A') since the year opened,
 * across every book and branch of the company. Party 00045 is never read (the desktop keeps 0).
 */
async function priorPartyDebitsTx(
  tx: any,
  scope: CompleteFinanceScope,
  partyCode: string,
): Promise<number> {
  if (partyCode === '00045') return 0;
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(a."DR_AMT"),0)::float8 AS debits
       FROM "AC_DATA" a
      WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."AC_CODE"=$3 AND a."DATA_TYPE"='A'
        AND a."VCH_DATE" >= (
          SELECT left(y."OP_DATE"::text,10)::date FROM "YEAR_MAST" y
           WHERE y.tenant_id=$1 AND y."CO_CODE"=$2
             AND coalesce(nullif(btrim(y."CO_YEAR"::text),''),left(y."OP_DATE"::text,4))=$4
           ORDER BY y.row_id LIMIT 1)`,
    scope.tenantId,
    scope.coCode,
    partyCode,
    scope.coYear,
  );
  const value = Number(rows[0]?.debits ?? 0);
  if (!Number.isFinite(value))
    throw new EBillWriteValidationError('party debit total is unreadable');
  return round(value, 2);
}

async function resolveTx(
  tx: any,
  scope: CompleteFinanceScope,
  book: EBook,
  input: EBillEntryInput,
  creating: boolean,
): Promise<Resolved> {
  const f = FAMILY[book.family];
  const settings = await companySettingsTx(tx, scope);
  const partyCode = text(input.partyCode);
  if (!partyCode) throw new EBillWriteValidationError('Please Insert Party and try');
  const party = await accountTx(tx, scope, partyCode, 'party account');
  const ledgerCode = text(input.ledgerCode);
  const ledger = ledgerCode ? await accountTx(tx, scope, ledgerCode, 'ledger account') : null;
  const interState = party.gstType === 'I';
  const policy: EBillPolicy = {
    amountDigits: settings.behavior.allRoundingRemoved ? 2 : 0,
    taxDigits: settings.taxDigits,
    labourRateDigits: settings.labourRateDigits,
    labourIncludesGhat: settings.behavior.labourIncludesGhat,
    interState,
  };

  const tcsCode = text(input.tcsCode);
  const tdsCode = text(input.tdsCode);
  if (!f.invoice) {
    if (tcsCode || num(input.tcsAmount)) {
      throw new EBillWriteValidationError(
        'TCS is not supported on an E CRNT book: the desktop posts TCS to the ledger only for outward books',
      );
    }
    if (tdsCode) {
      throw new EBillWriteValidationError(
        'TDS is not supported on an E CRNT book: the desktop posts the TDS ledger pair only for outward books',
      );
    }
  }
  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new EBillWriteValidationError(`at least one ${f.label} line is required`);
  }
  if (input.lines.length > 500) throw new EBillWriteValidationError('too many lines');

  const lines: ResolvedLine[] = [];
  const usedOldSrNos = new Set<number>();
  let nextOldSrNo = Math.max(
    0,
    ...input.lines.map((l) => (Number.isSafeInteger(Number(l?.oldSrNo)) ? Number(l?.oldSrNo) : 0)),
  );
  for (const [index, raw] of input.lines.entries()) {
    const line = raw ?? {};
    if (text(line.tagNo) && text(line.tagNo).toUpperCase() !== 'N') {
      throw new EBillWriteValidationError(
        `line ${index + 1}: tagged ${f.label} lines are not supported yet; leave the tag blank`,
      );
    }
    for (const [key, label] of [
      ['pcs', 'pieces'],
      ['bagWt', 'bag weight'],
      ['grossWt', 'gross weight'],
      ['lessWt', 'less weight'],
      ['ghatPercent', 'ghat %'],
      ['touch', 'touch'],
      ['westPercent', 'wastage %'],
      ['rate', 'rate'],
      ['labourRate', 'labour rate'],
      ['labourPercent', 'labour %'],
      ['otherAmount', 'other amount'],
      ['mrp', 'MRP'],
    ] as const) {
      nonNegative((line as Row)[key], `line ${index + 1} ${label}`);
    }
    const itemCode = text(line.itemCode);
    const item = itemCode ? await itemTx(tx, scope, itemCode) : null;
    const taxCode = line.taxCode === undefined ? '10' : text(line.taxCode);
    const tax = await lineTaxTx(tx, scope, party, taxCode);
    const calc = calculateEBillLine(
      {
        pcs: num(line.pcs),
        grossWt: num(line.grossWt),
        lessWt: num(line.lessWt),
        ghatPercent: num(line.ghatPercent),
        touch: num(line.touch),
        westPercent: num(line.westPercent),
        rate: num(line.rate),
        rateType: line.rateType === undefined ? (item?.rateType ?? '') : text(line.rateType),
        labourType: line.labourType === undefined ? settings.labourType : text(line.labourType),
        labourRate: num(line.labourRate),
        labourPercent: num(line.labourPercent),
        otherAmount: num(line.otherAmount),
        mrp: num(line.mrp),
        taxPercent: tax.percent,
      },
      policy,
    );
    if (!eBillLineIsSaved(itemCode, calc)) continue; // TR_SL_EBILL.cs 7614 skips the row
    if (calc.netWt < 0) {
      throw new EBillWriteValidationError(`line ${index + 1}: less weight exceeds gross weight`);
    }
    if (!item && !ledger) {
      throw new EBillWriteValidationError(
        `line ${index + 1}: select an item (or a header ledger account for a non-item ${f.label})`,
      );
    }
    if (!ledger && !item!.saleAccount && calc.taxableAmount !== 0) {
      throw new EBillWriteValidationError(
        `item ${item!.code} has no group sale account for the ${f.label} ledger row`,
      );
    }
    // Ac_Tax.EInvoice_GST joins the component row (SR_NO 1/2/3); without it the tax is not reported.
    if (calc.taxAmount !== 0 && (interState ? !tax.igst : !tax.sgst || !tax.cgst)) {
      throw new EBillWriteValidationError(
        `tax ${tax.code} has no ${interState ? 'IGST (SR_NO 3)' : 'SGST/CGST (SR_NO 1/2)'} component rows`,
      );
    }
    let oldSrNo = Number(line.oldSrNo);
    if (!Number.isSafeInteger(oldSrNo) || oldSrNo <= 0 || usedOldSrNos.has(oldSrNo)) {
      oldSrNo = ++nextOldSrNo;
    }
    usedOldSrNos.add(oldSrNo);
    lines.push({
      srNo: index + 1,
      oldSrNo,
      itemCode,
      itemName: item?.name ?? '',
      itemType: item?.itemType ?? '',
      productCode: item?.productCode ?? '',
      saleAccount: item?.saleAccount ?? '',
      remark: text(line.remark).slice(0, 100),
      designNo: text(line.designNo).slice(0, 20),
      size: text(line.size).slice(0, 20),
      hmId: text(line.hmId).slice(0, 20),
      bagWt: money(line.bagWt),
      tax,
      calc,
    });
  }
  if (!lines.length) {
    throw new EBillWriteValidationError('enter at least one line with a weight or an amount');
  }

  const chequeAmount = nonNegative(input.chequeAmount, 'cheque amount');
  const cardAmount = nonNegative(input.cardAmount, 'card amount');
  const cashAmount = nonNegative(input.cashAmount, 'cash amount');
  const kasarAmount = nonNegative(input.kasarAmount, 'kasar amount');
  const tender = { cash: cashAmount, cheque: chequeAmount, card: cardAmount, kasar: kasarAmount };
  const calcs = lines.map((l) => l.calc);
  const gross = calculateEBillTotals(calcs, tender);

  // TCS / TDS (BILL_TOTAL 9074-9138) — outward E INVOICE books only.
  let tcs = { code: '', percent: 0, amount: 0, account: '', accountName: '' };
  let tds = { code: '', percent: 0, account: '' };
  if (f.invoice) {
    const requested = tcsCode && tcsCode !== '00' ? await taxHeadTx(tx, scope, tcsCode) : null;
    if (tcsCode && tcsCode !== '00' && !requested)
      throw new EBillWriteValidationError(`TCS code not found: ${tcsCode}`);
    const zeroHead = tcsCode === '00' ? await taxHeadTx(tx, scope, '00') : null;
    const threshold = await taxHeadTx(tx, scope, '20');
    let decided;
    try {
      decided = eInvoiceTcs({
        creating,
        netAmount: gross.netAmount,
        igst: gross.igst,
        cgst: gross.cgst,
        sgst: gross.sgst,
        priorDebits: creating ? await priorPartyDebitsTx(tx, scope, party.code) : 0,
        requestedCode: tcsCode,
        requestedPercent: requested?.percent ?? zeroHead?.percent ?? 0,
        thresholdPercent: threshold ? threshold.percent : null,
        typedAmount: nonNegative(input.tcsAmount, 'TCS amount'),
      });
    } catch (error) {
      throw new EBillWriteValidationError((error as Error).message);
    }
    const head = decided.code === '20' ? threshold : decided.code === '00' ? zeroHead : requested;
    if (decided.amount !== 0 && !head?.account) {
      throw new EBillWriteValidationError(`TCS code ${decided.code} has no ledger account`);
    }
    tcs = {
      code: decided.code,
      percent: decided.percent,
      amount: decided.amount,
      account: head?.account ?? '',
      accountName: head?.account ? await accountNameTx(tx, scope, head.account) : '',
    };
    if (tdsCode) {
      const head2 = await taxHeadTx(tx, scope, tdsCode);
      if (!head2) throw new EBillWriteValidationError(`TDS code not found: ${tdsCode}`);
      if (head2.percent !== 0 && !head2.account)
        throw new EBillWriteValidationError(`TDS code ${tdsCode} has no ledger account`);
      tds = { code: head2.code, percent: head2.percent, account: head2.account };
    }
  }
  const bill = calculateEBillTotals(calcs, {
    ...tender,
    tcsAmount: tcs.amount,
    tdsPercent: tds.percent,
  });

  // TR_SL_EBILL.cs 7366-7455, in desktop order.
  if (settings.behavior.cashLimit > 0 && party.code !== '00020') {
    const cashSlot = book.slots.get(2);
    const prior = cashSlot?.accountCode
      ? await partyCashReceivedTx(tx, scope, party.code, cashSlot.accountCode)
      : 0;
    if (money(bill.cash + prior) > settings.behavior.cashLimit) {
      throw new EBillWriteValidationError(
        `Cash Recieved Limit Amount = ${settings.behavior.cashLimit} \r\nOld Ledr Value Is ${prior} \r\nAnd Total Cash Amount Is ${money(bill.cash + prior)} You Can Not Receive More Then Cash Limit ...`,
      );
    }
  }
  const employeeCode = text(input.employeeCode);
  if (settings.employeeMandatory && !employeeCode) {
    throw new EBillWriteValidationError('Please Select Employee Code and Try......');
  }
  if (employeeCode) {
    const found: unknown[] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
      scope.tenantId,
      scope.coCode,
      employeeCode,
    );
    if (found.length !== 1)
      throw new EBillWriteValidationError(`employee not found: ${employeeCode}`);
  }
  const chequeAccount = text(input.chequeAccount);
  if (chequeAmount !== 0 && !chequeAccount) {
    throw new EBillWriteValidationError(
      'Please Select Bank Account And Try Because Chq Rec Amt <> 0......',
    );
  }
  const cardAccount = text(input.cardAccount);
  if (cardAmount !== 0 && !cardAccount) {
    throw new EBillWriteValidationError(
      'Please Select Card Bank Account And Try Because Card Amt <> 0......',
    );
  }
  if (creating && settings.companyType === 'B') {
    throw new EBillWriteValidationError(
      'You Cant Save This Voucher Becouse This Company Type is B......',
    );
  }
  if (chequeAccount) await accountTx(tx, scope, chequeAccount, 'bank account');
  if (cardAccount) await accountTx(tx, scope, cardAccount, 'card account');
  // 7496: the header is inserted only when MRP or pcs+gross+line net+kasar is non-zero.
  if (bill.mrpTotal === 0 && money(bill.pcs + bill.grossWt + bill.totalAmount + bill.kasar) === 0) {
    throw new EBillWriteValidationError(`the ${f.label} has no quantity or amount to save`);
  }
  if (bill.outstanding < 0) {
    throw new EBillWriteValidationError(`payments exceed the ${f.label} total`);
  }

  requireSlot(book, 1, 'party control');
  const cashAccount = bill.cash !== 0 ? requireSlot(book, 2, 'cash').accountCode : '';
  const kasarAccount = bill.kasar !== 0 ? requireSlot(book, 3, 'kasar').accountCode : '';
  if (bill.roundOff !== 0) requireSlot(book, f.roundOffSlot, 'round off');
  let taxAccount = '';
  let taxAccountName = '';
  if (bill.taxAmount !== 0) {
    // EInvoice_Ledr/Rojmel row 03 always post to TAX_MAST code '10' SR_NO 0, whatever the line codes.
    const head = await taxHeadTx(tx, scope, '10');
    if (!head?.account) {
      throw new EBillWriteValidationError(
        `TAX_MAST code 10 (SR_NO 0) must name the GST ledger account used by ${book.family} posting`,
      );
    }
    taxAccount = head.account;
    taxAccountName = await accountNameTx(tx, scope, head.account);
  }
  return {
    party,
    ledger,
    employeeCode,
    interState,
    gstType: party.gstType || 'L',
    lines,
    bill,
    tcs: {
      code: tcs.code,
      percent: tcs.percent,
      account: tcs.account,
      accountName: tcs.accountName,
    },
    tds,
    chequeAccount,
    chequeNo: text(input.chequeNo).slice(0, 20),
    cardAccount,
    cardCommission: money(nonNegative(input.cardCommission, 'card commission')),
    cashAccount,
    kasarAccount,
    taxAccount,
    taxAccountName,
  };
}

async function registrationTx(tx: any, scope: CompleteFinanceScope, voucherNo: string) {
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT (SELECT count(*) FROM "E_DATA" e WHERE e.tenant_id=$1 AND e."CO_CODE"=$2 AND e."LC_CODE"=$3
               AND e."CO_YEAR"=$4 AND e."CO_BOOK"=$5 AND e."VCH_NO"=$6)::int AS e_rows,
            (SELECT max(length(btrim(coalesce(s."IRN_NO",'')))) FROM "SL_DATA" s WHERE s.tenant_id=$1
               AND s."CO_CODE"=$2 AND s."LC_CODE"=$3 AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5
               AND s."VCH_NO"=$6)::int AS irn_len`,
    ...keyArgs(scope, voucherNo),
  );
  return Number(rows[0]?.e_rows ?? 0) > 0 || Number(rows[0]?.irn_len ?? 0) > 10;
}

/** Deterministic fingerprint of the persisted header and lines, for stale-edit detection. */
async function revisionTx(
  tx: any,
  scope: CompleteFinanceScope,
  voucherNo: string,
): Promise<string> {
  const rows: Row[] = await tx.$queryRawUnsafe(
    `SELECT coalesce((SELECT jsonb_agg(to_jsonb(a)-'tenant_id'-'row_id' ORDER BY row_id) FROM "SL_DATA" a WHERE ${keyWhere}),'[]')::text AS h,
            coalesce((SELECT jsonb_agg(to_jsonb(a)-'tenant_id'-'row_id' ORDER BY "SR_NO",row_id) FROM "SL_DETL" a WHERE ${keyWhere}),'[]')::text AS d,
            coalesce((SELECT jsonb_agg(to_jsonb(a)-'tenant_id'-'row_id' ORDER BY "SR_NO","ISR_NO",row_id) FROM "SL_IDTL" a WHERE ${keyWhere}),'[]')::text AS c,
            (SELECT count(*) FROM "E_DATA" a WHERE ${keyWhere})::int AS e`,
    ...keyArgs(scope, voucherNo),
  );
  const r = rows[0] ?? {};
  return createHash('sha256').update(`${r.h}|${r.d}|${r.c}|${r.e}`).digest('hex').slice(0, 32);
}

async function assertRevisionTx(
  tx: any,
  book: EBook,
  scope: CompleteFinanceScope,
  voucherNo: string,
  expected: string | undefined,
) {
  if (expected === undefined || expected === null || expected === '') return;
  const current = await revisionTx(tx, scope, voucherNo);
  if (current !== String(expected)) {
    throw new EBillConflictError(
      `${FAMILY[book.family].label} ${voucherNo} was changed after it was opened; reopen it and try again`,
    );
  }
}

async function writeTx(
  tx: any,
  scope: CompleteFinanceScope,
  book: EBook,
  identity: VoucherIdentity,
  input: EBillEntryInput,
  r: Resolved,
  preservedChildren: Row[],
): Promise<void> {
  const f = FAMILY[book.family];
  const inv = f.invoice;
  const key = voucherKey(scope, identity.voucherNo);
  const date = identity.voucherDate;
  const time = identity.voucherTime;
  const mainUser = identity.mainUser || null;
  const billNo = text(input.billNo).slice(0, 20);
  const description = text(input.description).slice(0, 150);
  const b = r.bill;
  /** The party side of a row: debit on an e-invoice, credit on a credit note (IIF(E INVOICE,..)). */
  const partySide = (amount: number) => (inv ? { DR_AMT: amount } : { CR_AMT: amount });
  const otherSide = (amount: number) => (inv ? { CR_AMT: amount } : { DR_AMT: amount });

  await insertHiddenIdentityTx(tx, scope, identity, book.configuredName);
  await insertRowTx(tx, 'SL_DATA', scope.tenantId, {
    ...key,
    AC_CODE: r.party.code,
    VCH_DATE: date,
    BILL_NO: billNo,
    HD_VCH_NO: identity.hiddenVoucherNo,
    AC_NAME: r.party.name,
    LDR_CODE: r.ledger?.code ?? '',
    NET_AMT: b.netAmount,
    DISC_PRC: 0,
    DISC_AMT: 0,
    TAX_CODE: '',
    TAX_PRC: 0,
    TAX_AMT: b.taxAmount,
    IGST_TAX: b.igst,
    CGST_TAX: b.cgst,
    SGST_TAX: b.sgst,
    TCS_CODE: r.tcs.code,
    TCS_PRC: r.tcs.percent,
    TCS_AMT: b.tcsAmount,
    ROF_AMT: b.roundOff,
    LBR_AMT: b.labourAmount,
    OTH_AMT: b.otherAmount,
    TOT_AMT: b.totalAmount,
    TDS_CODE: r.tds.code,
    TDS_PRC: r.tds.percent,
    TDS_AMT: b.tdsAmount,
    CHQ_AMT: b.cheque,
    CARD_AMT: b.card,
    CARD_COM_AMT: r.cardCommission,
    ADV_AMT: 0,
    CRNT_ADJ_AMT: 0,
    OLD_GL_AMT: 0,
    OLD_SL_AMT: 0,
    SCHM_AMT: 0,
    CASH_AMT: b.cash,
    CASH_PAID: 0,
    KASAR_AMT: b.kasar,
    BILL_OS: b.outstanding,
    OLD_GL: 0,
    OLD_SL: 0,
    CARD_AC: r.cardAccount,
    BANK_AC: r.chequeAccount,
    CHQ_NO: r.chequeNo,
    SCHM_AC: '0',
    POINT_VAL: 0,
    BANK_NAME: '',
    CARD_ADJ: '0',
    CR_DAYS: 0,
    AC_GST_TYPE: r.gstType,
    HM_AMT: 0,
    HM_TAX_CODE: '',
    HM_TAX_PRC: 0,
    HM_TAX_AMT: 0,
    RTN_TOT_AMT: 0,
    RTN_CHQ_AMT: 0,
    RTN_CARD_AMT: 0,
    RTN_CASH_AMT: 0,
    RTN_KASAR_AMT: 0,
    RTN_BILL_OS: 0,
    ISU_NO: '',
    ISU_LC_CODE: '',
    ISU_YRCD: '',
    ISU_DBCD: '',
    EMP_CODE: r.employeeCode,
    VCH_DESC: description,
    VCH_TIME: time,
    DATA_TRFR: 'N',
    MAIN_USER: mainUser,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    // 7598-7605: only book 025 keeps the IRN text; every other book stores "N".
    IRN_NO: 'N',
    ACK_NO: '',
    ACK_DATE: date,
    MOB_ENTRY_SAVE: 'Y',
    RATE_UNFIX: 'N',
    OZ_RATE: 0,
    OZ_CONV: 0,
    FX_RATE: 0,
    FX_CODE: '',
    MTL_RATE: 0,
  });

  const common = {
    ...key,
    VCH_DATE: date,
    HD_VCH_NO: identity.hiddenVoucherNo,
    AC_CODE: r.party.code,
    VCH_TYPE: book.shortName,
    INOUT_TYPE: book.inout,
    ENTRY_TYPE: 'O',
    BOOK_NAME: book.mainBook,
  };
  for (const line of r.lines) {
    const c = line.calc;
    await insertRowTx(tx, 'SL_DETL', scope.tenantId, {
      ...common,
      SR_NO: line.srNo,
      OLD_SRNO: line.oldSrNo,
      IT_CODE: line.itemCode,
      ITM_REMARK: line.remark,
      TAG_NO: 'N',
      TBL_CODE: '',
      DESIGN_NO: line.designNo,
      ITM_SIZE: line.size,
      BAG_WT: line.bagWt,
      ITM_PCS: c.pcs,
      ITM_GWT: c.grossWt,
      ITM_OTH_WT: c.lessWt,
      ITM_NWT: c.netWt,
      ITM_GHT_WT: c.ghatWt,
      ITM_TOUCH: c.touch,
      ITM_WEST_PRC: c.westPercent,
      ITM_FINE: c.fine,
      LBR_PRC: c.labourPercent,
      LBR_TYPE: c.labourType,
      LBR_RATE: c.labourRate,
      LBR_AMT: c.labourAmount,
      OTH_AMT: c.otherAmount,
      ITM_RATE: c.rate,
      ITM_AMT: c.itemAmount,
      ITM_MRP: c.mrp,
      TOT_AMT: c.taxableAmount,
      NET_AMT: c.taxableAmount,
      TAXABL_RATE: c.taxableRate,
      TAX_CODE: line.tax.code,
      TAX_PRC: c.taxPercent,
      ITM_IGST_AMT: c.igst,
      ITM_CGST_AMT: c.cgst,
      ITM_SGST_AMT: c.sgst,
      IT_TAX_AMT: c.taxAmount,
      GRAND_TOTAL: c.netAmount,
      DISC_PRC: 0,
      DISC_AMT: 0,
      KR_NET_WT: 0,
      KR_TOUCH: 0,
      KR_WEST_PRC: 0,
      KR_FINE: 0,
      KR_NAME: '',
      RATE_TYPE: c.rateType,
      IT_TYPE: line.itemType,
      PR_CODE: line.productCode,
      VCH_SRNO: 0,
      HM_ID: line.hmId,
      HM_ID2: '',
      HM_ID3: '',
      HM_ID4: '',
      HM_ID_WT: 0,
      HM_ID2_WT: 0,
      HM_ID3_WT: 0,
      HM_ID4_WT: 0,
      DESIGN_IMG_ID: '',
      ORD_TAG_STK_ADD: 'N',
      EMP_CODE: r.employeeCode,
      MAIN_USER: mainUser,
      VCH_TIME: time,
    });
  }
  // SL_IDTL: re-insert preserved children whose parent row (OLD_SRNO) survives (7715-7776).
  const parentByOld = new Map(r.lines.map((l) => [l.oldSrNo, l]));
  const keptChildren: Row[] = [];
  for (const child of preservedChildren) {
    const parent = parentByOld.get(Number(child.SR_NO));
    if (!parent) continue;
    const {
      tenant_id: _t,
      row_id: _r,
      ...rest
    } = child as Row & { tenant_id?: unknown; row_id?: unknown };
    const row = {
      ...rest,
      ...common,
      SR_NO: parent.oldSrNo,
      TAG_NO: 'N',
      VCH_SRNO: 0,
      MAIN_USER: mainUser,
    };
    keptChildren.push({ ...row, parentItemCode: parent.itemCode });
    await insertRowTx(tx, 'SL_IDTL', scope.tenantId, row);
  }

  // ---- AC_DATA (Ac_Ledr.EInvoice_Ledr) ----
  const base = `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}`;
  const slot1 = requireSlot(book, 1, 'party control');
  const ledgerRow = (suffix: string, slot: BookSlot | null, fields: Row) => ({
    ...key,
    VCH_TYPE: slot ? slot.shortName : book.shortName,
    VCH_DATE: date,
    LEDR_KEY: `${base}${suffix}`,
    BOOK_NAME: slot ? slot.mainBook : book.mainBook,
    BILL_NO: billNo,
    BILL_DATE: null,
    CHQ_NO: '',
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: 0,
    IT_DESC: '',
    ENTRY_TIME: time,
    HD_VCH_NO: identity.hiddenVoucherNo,
    CLR_DATE: null,
    DATA_TYPE: slot ? slot.dataType : book.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: mainUser,
    FINE_RATE: 0,
    PARTY_AC_CODE: '',
    LDR_NAME: '',
    CR_AMT: 0,
    DR_AMT: 0,
    ...fields,
  });
  const ledger: Row[] = [];
  if (b.totalAmount !== 0) {
    ledger.push(
      ledgerRow('01', slot1, {
        AC_CODE: r.party.code,
        LD_CODE: slot1.accountCode,
        ...partySide(b.totalAmount),
        PARTY_AC_CODE: r.party.code,
        LDR_NAME: r.party.name,
      }),
    );
  }
  for (const line of r.lines) {
    if (line.calc.taxableAmount === 0) continue;
    ledger.push(
      ledgerRow(`${sqlStr(line.srNo)}02`, null, {
        BILL_NO: '',
        AC_CODE: r.ledger ? r.ledger.code : line.saleAccount,
        LD_CODE: r.party.code,
        ...otherSide(line.calc.taxableAmount),
      }),
    );
  }
  if (b.taxAmount !== 0) {
    ledger.push(
      ledgerRow('03', null, {
        AC_CODE: r.taxAccount,
        LD_CODE: r.party.code,
        ...otherSide(b.taxAmount),
      }),
    );
  }
  // 04/05/06 require BOOK_DATA.BOOK_INOUT = 'O' (only an E INVOICE book qualifies).
  if (book.inout === 'O' && b.tcsAmount !== 0) {
    ledger.push(
      ledgerRow('04', null, {
        AC_CODE: r.tcs.account,
        LD_CODE: r.party.code,
        ...otherSide(b.tcsAmount),
      }),
    );
  }
  if (book.inout === 'O' && b.tdsAmount !== 0) {
    ledger.push(
      ledgerRow('05', null, {
        AC_CODE: r.party.code,
        LD_CODE: r.tds.account,
        ...otherSide(b.tdsAmount),
      }),
    );
    ledger.push(
      ledgerRow('06', null, {
        AC_CODE: r.tds.account,
        LD_CODE: r.party.code,
        ...partySide(b.tdsAmount),
      }),
    );
  }
  const pair = (
    first: string,
    second: string,
    contra: string,
    amount: number,
    slot: BookSlot,
    secondName = '',
  ) => {
    if (!amount) return;
    ledger.push(
      ledgerRow(first, slot, {
        AC_CODE: r.party.code,
        LD_CODE: contra,
        ...otherSide(amount),
        PARTY_AC_CODE: r.party.code,
      }),
    );
    ledger.push(
      ledgerRow(second, slot, {
        AC_CODE: contra,
        LD_CODE: r.party.code,
        ...partySide(amount),
        LDR_NAME: secondName,
      }),
    );
  };
  pair('07', '08', r.chequeAccount, b.cheque, slot1);
  pair('09', '10', r.cardAccount, b.card, slot1);
  if (b.cash) pair('11', '12', r.cashAccount, b.cash, requireSlot(book, 2, 'cash'), r.party.name);
  if (b.kasar) pair('13', '14', r.kasarAccount, b.kasar, requireSlot(book, 3, 'kasar'));
  if (b.roundOff !== 0) {
    const slot = requireSlot(book, f.roundOffSlot, 'round off');
    // The desktop writes the negative round-off itself into the column (DR for row 15, CR for row
    // 16), which unbalances the voucher; the web posts the absolute value on that side (documented
    // adaptations 1 and 7 in the X15 contract).
    const positive = b.roundOff > 0 ? b.roundOff : 0;
    const negative = b.roundOff < 0 ? -b.roundOff : 0;
    ledger.push(
      ledgerRow(f.roundOffSuffix, slot, {
        AC_CODE: slot.accountCode,
        LD_CODE: r.party.code,
        CR_AMT: inv ? positive : negative,
        DR_AMT: inv ? negative : positive,
      }),
    );
  }
  assertBalanced(ledger as any);
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);

  // ---- ROJ_MEL_DATA (Ac_Rojmel.EInvoice_Rojmel) ----
  const rojmelRow = (suffix: string, slot: BookSlot, fields: Row) => ({
    ...key,
    LEDR_KEY: `${base}${suffix}`,
    VCH_DATE: date,
    VCH_TYPE: slot.shortName,
    BOOK_NAME: slot.mainBook,
    AC_NAME: '',
    CR_AMT: 0,
    DR_AMT: 0,
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
    IT_DESC: description,
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: slot.dataType,
    ...fields,
  });
  const rojmel: Row[] = [];
  for (const line of r.lines) {
    const c = line.calc;
    if (c.taxableAmount === 0) continue;
    rojmel.push(
      rojmelRow(`01${sqlStr(line.srNo)}`, slot1, {
        AC_CODE: r.ledger ? r.ledger.code : line.saleAccount,
        LD_CODE: r.party.code,
        ...otherSide(c.taxableAmount),
        ITM_PCS: c.pcs,
        ITM_GWT: c.grossWt,
        ITM_NWT: c.netWt,
        ITM_RATE: c.rate,
        ITM_AMT: c.itemAmount,
        LBR_RATE: c.labourRate,
        LBR_AMT: c.labourAmount,
        OTH_AMT: c.otherAmount,
        NET_AMT: c.taxableAmount,
        IT_DESC: line.itemName,
        IT_CODE: line.itemCode,
      }),
    );
  }
  if (b.outstanding > 0) {
    rojmel.push(
      rojmelRow('02', slot1, {
        AC_CODE: r.party.code,
        LD_CODE: slot1.accountCode,
        ...partySide(b.outstanding),
        AC_NAME: r.party.name,
      }),
    );
  }
  if (b.taxAmount !== 0) {
    rojmel.push(
      rojmelRow('03', slot1, {
        AC_CODE: r.taxAccount,
        LD_CODE: r.party.code,
        ...otherSide(b.taxAmount),
        AC_NAME: r.taxAccountName,
      }),
    );
  }
  if (b.tcsAmount !== 0) {
    rojmel.push(
      rojmelRow('04', slot1, {
        AC_CODE: r.tcs.account,
        LD_CODE: r.party.code,
        ...otherSide(b.tcsAmount),
        AC_NAME: r.tcs.accountName,
      }),
    );
  }
  if (b.tdsAmount !== 0) {
    rojmel.push(
      rojmelRow('05', slot1, {
        AC_CODE: r.tds.account,
        LD_CODE: r.party.code,
        ...partySide(b.tdsAmount),
        AC_NAME: `TDS - ${r.party.name}`.slice(0, 50),
      }),
    );
  }
  if (b.cheque) {
    rojmel.push(
      rojmelRow('06', slot1, {
        AC_CODE: r.chequeAccount,
        LD_CODE: r.party.code,
        ...partySide(b.cheque),
      }),
    );
  }
  // 07 condition: CARD_ADJ = 'N' OR BOOK_DETL.BOOK_TYPE <> 'M'. SL_DATA.CARD_ADJ is saved as '0',
  // so only the book type decides.
  if (b.card && slot1.bookType !== 'M') {
    rojmel.push(
      rojmelRow('07', slot1, {
        AC_CODE: r.cardAccount,
        LD_CODE: r.party.code,
        ...partySide(b.card),
      }),
    );
  }
  if (b.kasar) {
    const slot3 = requireSlot(book, 3, 'kasar');
    rojmel.push(
      rojmelRow('08', slot3, {
        AC_CODE: slot3.accountCode,
        LD_CODE: r.party.code,
        ...partySide(b.kasar),
        AC_NAME: `KSR - ${r.party.name}`.slice(0, 50),
      }),
    );
  }
  // 09 (slot 5) and 10 (slot 4) exist only for E INVOICE and keep the desktop's signed values.
  if (inv && b.roundOff !== 0) {
    for (const [suffix, srNo, positiveCr] of [
      ['09', 5, true],
      ['10', 4, false],
    ] as const) {
      const slot = book.slots.get(srNo);
      if (!slot) continue;
      const positive = b.roundOff > 0 ? b.roundOff : 0;
      const negative = b.roundOff < 0 ? b.roundOff : 0;
      rojmel.push(
        rojmelRow(suffix, slot, {
          AC_CODE: r.party.code,
          LD_CODE: slot.accountCode,
          CR_AMT: positiveCr ? positive : negative,
          DR_AMT: positiveCr ? negative : positive,
          AC_NAME: `ROF - ${r.party.name}`.slice(0, 50),
        }),
      );
    }
  }
  for (const row of rojmel) await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, row);

  // ---- MAIN_STOCK (Ac_Stock.EInvoice_Stk) ----
  for (const line of r.lines) {
    const c = line.calc;
    await insertRowTx(tx, 'MAIN_STOCK', scope.tenantId, {
      ...key,
      SR_NO: 1,
      ISR_NO: line.srNo,
      VCH_DATE: date,
      STK_DATE: date.toISOString().slice(0, 10),
      VCH_TYPE: book.shortName,
      BOOK_NAME: book.mainBook,
      AC_CODE: r.party.code,
      IT_CODE: line.itemCode,
      TAG_NO: 'N',
      VCH_SRNO: 0,
      TBL_CODE: '',
      TR_TYPE: f.stockType,
      ITM_SIGN: f.stockSign,
      ITM_QTY: 1,
      ITM_PCS: c.pcs,
      ITM_GWT: c.grossWt,
      ITM_NWT: c.netWt,
      ITM_TOUCH: c.touch,
      ITM_WEST: 0,
      ITM_FINE: c.fine,
      ITM_RATE: c.rate,
      ITM_AMT: c.itemAmount,
      LBR_RATE: c.labourRate,
      LBR_AMT: c.labourAmount,
      OTH_AMT: c.otherAmount,
      ITM_MRP: c.mrp,
      NET_AMT: c.taxableAmount,
      KR_NWT: 0,
      KR_TOUCH: 0,
      KR_WEST: 0,
      KR_FINE: 0,
      KR_LBR_AMT: 0,
      KR_OTH_AMT: 0,
      KR_COST: 0,
      EMP_CODE: r.employeeCode,
      ENTRY_TIME: date,
      MAIN_USER: mainUser,
      DATA_TYPE: book.dataType,
      DESIGN_NO: line.designNo,
      ITM_SIZE: line.size,
      ITM_DESC: '',
      ITM_LOT: '',
      ITM_DISC: 0,
    });
  }

  // ---- TAX_DATA (Ac_Tax.EInvoice_GST) ----
  for (const line of r.lines) {
    const c = line.calc;
    if (c.taxableAmount === 0) continue;
    const taxRow = (srNo: number, amount: number, component: TaxComponent | null) => ({
      ...key,
      SR_NO: srNo,
      BOOK_NAME: book.mainBook,
      TRAN_TYPE: 'S',
      VCH_DATE: date,
      AC_CODE: r.party.code,
      TAX_CODE: line.tax.code,
      TAX_TYPE: component?.group ?? '',
      TAX_PRC: component?.percent ?? 0,
      NET_AMT: c.taxableAmount,
      TAX_AMT: amount,
      DISC_AMT: 0,
      TOT_AMT: c.netAmount,
      TAX_SIGN: f.taxSign,
      PARTY_NAME: r.party.name,
      R_CHARG: 'N',
      ISR_NO: line.srNo,
      TAX_FREE_AMT: 0,
      ZERO_RATED_AMT: 0,
    });
    if (!r.interState) {
      if (c.sgst !== 0)
        await insertRowTx(tx, 'TAX_DATA', scope.tenantId, taxRow(line.srNo, c.sgst, line.tax.sgst));
      if (c.cgst !== 0)
        await insertRowTx(
          tx,
          'TAX_DATA',
          scope.tenantId,
          taxRow(111 + line.srNo, c.cgst, line.tax.cgst),
        );
    } else if (c.igst !== 0) {
      await insertRowTx(tx, 'TAX_DATA', scope.tenantId, taxRow(line.srNo, c.igst, line.tax.igst));
    }
  }

  // ---- DM_DATA (Ac_Stock.Dm_Sale_eInv_Detl): E INVOICE components marked OTH_DETL_POSTING ----
  if (inv && keptChildren.length) {
    const codes = [...new Set(keptChildren.map((c) => text(c.IT_CODE)).filter(Boolean))];
    const posting: Row[] = codes.length
      ? await tx.$queryRawUnsafe(
          `SELECT "IT_CODE" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
              AND "IT_CODE" = ANY($3::text[]) AND "OTH_DETL_POSTING"='Y'`,
          scope.tenantId,
          scope.coCode,
          codes,
        )
      : [];
    const postingCodes = new Set(posting.map((p) => text(p.IT_CODE)));
    for (const child of keptChildren) {
      if (!postingCodes.has(text(child.IT_CODE))) continue;
      await insertRowTx(tx, 'DM_DATA', scope.tenantId, {
        ...key,
        MAIN_SRNO: 1,
        SR_NO: child.SR_NO,
        ISR_NO: child.ISR_NO,
        VCH_DATE: date,
        ENTRY_TYPE: 'S',
        BOOK_NAME: book.shortName,
        AC_CODE: r.party.code,
        IT_CODE: child.IT_CODE,
        DM_CODE: child.DM_CODE ?? null,
        DM_ORIGIN: child.DM_ORIGIN ?? null,
        DM_REMARK: child.DM_REMARK ?? null,
        DM_SIZE: child.DM_SIZE ?? null,
        DM_COLOR: child.DM_COLOR ?? null,
        DM_LOT_NO: '',
        DM_PCS: child.IT_PCS ?? 0,
        DM_WT: child.IT_GWT ?? 0,
        DM_SIGN: '-',
        DM_RATE: child.IT_RATE ?? 0,
        DM_AMT: child.IT_AMT ?? 0,
        EMP_CODE: '',
        TAG_NO: 'N',
        VCH_SRNO: 0,
        MAIN_IT_CODE: child.parentItemCode,
        INOUT_TYPE: 'S',
      });
    }
  }

  // ---- REMARK_DATA (Ac_Tax.Vch_Remark mode 0) ----
  if (description && book.tableName) {
    await insertRowTx(tx, 'REMARK_DATA', scope.tenantId, {
      ...key,
      SR_NO: 0,
      VCH_DATE: date,
      AC_CODE: r.party.code,
      AC_NAME: r.party.name,
      MAIN_BOOK: book.mainBook,
      VCH_REMARK: description,
    });
  }
}

export interface EBillSaveResult {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
  totals: EBillTotals;
  revision: string;
}

async function saveTx(
  tx: any,
  family: EBillFamily,
  input: EBillEntryInput,
  requestedVoucherNo?: string,
): Promise<EBillSaveResult> {
  const scope = completeFinanceScope(input.scope);
  const book = await resolveBookTx(tx, family, scope);
  const { date, iso } = businessDate(input.vchDate);
  await assertFiscalDateTx(tx, scope, iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
  const created = !requestedVoucherNo;
  let identity: VoucherIdentity;
  let preservedChildren: Row[] = [];
  if (requestedVoucherNo) {
    const edited = await editIdentityTx(tx, {
      table: 'SL_DATA',
      scope,
      requestedVoucherNo,
      requestedDate: date,
    });
    identity = edited.identity;
    await assertFiscalDateTx(
      tx,
      scope,
      new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10),
    );
    await assertRevisionTx(tx, book, scope, identity.voucherNo, input.expectedRevision);
    if (await registrationTx(tx, scope, identity.voucherNo)) {
      throw new EBillWriteValidationError(
        'You Cant Edit This Voucher Because Irn No Is Genrate..... (cancel the IRN first)',
      );
    }
    preservedChildren = await tx.$queryRawUnsafe(
      `SELECT * FROM "SL_IDTL" WHERE ${keyWhere} ORDER BY "SR_NO","ISR_NO",row_id`,
      ...keyArgs(scope, identity.voucherNo),
    );
  } else {
    identity = await createIdentityTx(tx, scope, date, input.mainUser);
  }
  const resolved = await resolveTx(tx, scope, book, input, created);
  if (!created) {
    await replaceWriteSetTx(tx, scope, identity.voucherNo, identity.hiddenVoucherNo, SAVE_TABLES);
  }
  await writeTx(tx, scope, book, identity, input, resolved, preservedChildren);
  return {
    voucherNo: identity.voucherNo,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    created,
    lines: resolved.lines.length,
    totals: resolved.bill,
    revision: await revisionTx(tx, scope, identity.voucherNo),
  };
}

export async function saveEBill(
  prisma: any,
  family: EBillFamily,
  input: EBillEntryInput,
  requestedVoucherNo?: string,
): Promise<EBillSaveResult> {
  return withTenant(prisma, input.scope.tenantId, (tx: any) =>
    saveTx(tx, family, input, requestedVoucherNo),
  );
}

export async function deleteEBill(
  prisma: any,
  family: EBillFamily,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
  options: { deleteUser?: string; expectedRevision?: string } = {},
): Promise<{ deleted: true; voucherNo: string }> {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, family, scope);
    const edited = await editIdentityTx(tx, {
      table: 'SL_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      checkRequestedDate: false,
      extraColumns: ['AC_CODE'],
    });
    await assertFiscalDateTx(
      tx,
      scope,
      new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10),
    );
    await assertRevisionTx(tx, book, scope, voucherNo, options.expectedRevision);
    if (await registrationTx(tx, scope, voucherNo)) {
      throw new EBillWriteValidationError(
        'You Cant Delete This Voucher Because Irn No Is Genrate.....',
      );
    }
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: { name: book.configuredName.slice(0, 20), shortName: book.shortName },
      header: edited.persisted,
      deleteUser: options.deleteUser,
      rows: [
        {
          srNo: 0,
          acCode: edited.persisted.AC_CODE,
          acName: (await accountNameTx(tx, scope, text(edited.persisted.AC_CODE))) || null,
          valueDr: 0,
          valueCr: 0,
          fineType: 'A',
          fineDr: 0,
          fineCr: 0,
          description: '0',
        },
      ],
    });
    await replaceWriteSetTx(tx, scope, voucherNo, edited.identity.hiddenVoucherNo, DELETE_TABLES);
    return { deleted: true as const, voucherNo };
  });
}

/** Editable, camel-cased view of a saved voucher, with its revision and edit/delete locks. */
export async function getEBillEntry(
  prisma: any,
  family: EBillFamily,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(
    prisma,
    scope.tenantId,
    async (tx: any) => {
      await resolveBookTx(tx, family, scope);
      const args = keyArgs(scope, voucherNo);
      const headers: Row[] = await tx.$queryRawUnsafe(
        `SELECT *, "VCH_DATE"::text AS "VCH_DAY", to_char("VCH_TIME",'HH24:MI:SS') AS "VCH_CLOCK"
           FROM "SL_DATA" WHERE ${keyWhere}`,
        ...args,
      );
      if (!headers.length) return null;
      if (headers.length !== 1)
        throw new EBillWriteValidationError(`${FAMILY[family].label} is ambiguous: ${voucherNo}`);
      const h = headers[0]!;
      const lines: Row[] = await tx.$queryRawUnsafe(
        `SELECT d.*, coalesce(i."IT_NAME",'') AS "IT_NAME" FROM "SL_DETL" d
           LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
          WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6
          ORDER BY d."SR_NO", d.row_id`,
        ...args,
      );
      const components: Row[] = await tx.$queryRawUnsafe(
        `SELECT count(*)::int AS n FROM "SL_IDTL" WHERE ${keyWhere}`,
        ...args,
      );
      const irnLocked = await registrationTx(tx, scope, voucherNo);
      const registration: Row[] = await tx.$queryRawUnsafe(
        `SELECT "IRN_NO","ACK_NO","ACK_DATE"::text AS "ACK_DATE" FROM "E_DATA" WHERE ${keyWhere}`,
        ...args,
      );
      return {
        family,
        voucherNo,
        hiddenVoucherNo: text(h.HD_VCH_NO),
        vchDate: text(h.VCH_DAY).slice(0, 10),
        voucherTime: text(h.VCH_CLOCK),
        mainUser: text(h.MAIN_USER),
        partyCode: text(h.AC_CODE),
        partyName: text(h.AC_NAME),
        gstType: text(h.AC_GST_TYPE),
        billNo: text(h.BILL_NO),
        ledgerCode: text(h.LDR_CODE),
        employeeCode: text(h.EMP_CODE),
        description: text(h.VCH_DESC),
        cashAmount: Number(h.CASH_AMT ?? 0),
        chequeAmount: Number(h.CHQ_AMT ?? 0),
        chequeAccount: text(h.BANK_AC),
        chequeNo: text(h.CHQ_NO),
        cardAmount: Number(h.CARD_AMT ?? 0),
        cardAccount: text(h.CARD_AC),
        cardCommission: Number(h.CARD_COM_AMT ?? 0),
        kasarAmount: Number(h.KASAR_AMT ?? 0),
        tcsCode: text(h.TCS_CODE),
        tcsPercent: Number(h.TCS_PRC ?? 0),
        tcsAmount: Number(h.TCS_AMT ?? 0),
        tdsCode: text(h.TDS_CODE),
        tdsPercent: Number(h.TDS_PRC ?? 0),
        totals: {
          netAmount: Number(h.NET_AMT ?? 0),
          igst: Number(h.IGST_TAX ?? 0),
          cgst: Number(h.CGST_TAX ?? 0),
          sgst: Number(h.SGST_TAX ?? 0),
          taxAmount: Number(h.TAX_AMT ?? 0),
          tcsAmount: Number(h.TCS_AMT ?? 0),
          tdsAmount: Number(h.TDS_AMT ?? 0),
          roundOff: Number(h.ROF_AMT ?? 0),
          totalAmount: Number(h.TOT_AMT ?? 0),
          outstanding: Number(h.BILL_OS ?? 0),
        },
        componentCount: Number(components[0]?.n ?? 0),
        irnLocked,
        registration: registration[0]
          ? {
              irn: text(registration[0].IRN_NO),
              ackNo: text(registration[0].ACK_NO),
              ackDate: text(registration[0].ACK_DATE),
            }
          : null,
        revision: await revisionTx(tx, scope, voucherNo),
        lines: lines.map((l) => {
          const net = Number(l.ITM_NWT ?? 0);
          const ghat = Number(l.ITM_GHT_WT ?? 0);
          return {
            srNo: Number(l.SR_NO),
            oldSrNo: Number(l.OLD_SRNO ?? l.SR_NO),
            itemCode: text(l.IT_CODE),
            itemName: text(l.IT_NAME),
            remark: text(l.ITM_REMARK),
            designNo: text(l.DESIGN_NO),
            size: text(l.ITM_SIZE),
            tagNo: text(l.TAG_NO) === 'N' ? '' : text(l.TAG_NO),
            hmId: text(l.HM_ID),
            pcs: Number(l.ITM_PCS ?? 0),
            bagWt: Number(l.BAG_WT ?? 0),
            grossWt: Number(l.ITM_GWT ?? 0),
            lessWt: Number(l.ITM_OTH_WT ?? 0),
            // ITM_GHT_PRC is not saved by TR_SL_EBILL; the percentage is recovered from the weights.
            ghatPercent: net !== 0 && ghat !== 0 ? round((ghat / net) * 100, 3) : 0,
            touch: Number(l.ITM_TOUCH ?? 0),
            westPercent: Number(l.ITM_WEST_PRC ?? 0),
            rate: Number(l.ITM_RATE ?? 0),
            rateType: text(l.RATE_TYPE),
            labourType: text(l.LBR_TYPE),
            labourRate: Number(l.LBR_RATE ?? 0),
            labourPercent: Number(l.LBR_PRC ?? 0),
            otherAmount: Number(l.OTH_AMT ?? 0),
            mrp: Number(l.ITM_MRP ?? 0),
            taxCode: text(l.TAX_CODE),
          };
        }),
      };
    },
    { isolationLevel: 'RepeatableRead' },
  );
}

/** Everything the entry screen needs to calculate like the server: settings, slots and tax codes. */
export async function getEBillEntryConfig(
  prisma: any,
  family: EBillFamily,
  scopeInput: VoucherScope,
) {
  const scope = completeFinanceScope(scopeInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, family, scope);
    const settings = await companySettingsTx(tx, scope);
    const heads: Row[] = await tx.$queryRawUnsafe(
      `SELECT "TAX_CODE","TAX_NAME","TAX_PRC" FROM "TAX_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND coalesce("SR_NO",0)=0 ORDER BY "TAX_CODE"`,
      scope.tenantId,
      scope.coCode,
    );
    const list = (filter: (code: string) => boolean) =>
      heads
        .filter((t) => filter(text(t.TAX_CODE)))
        .map((t) => ({
          code: text(t.TAX_CODE),
          name: text(t.TAX_NAME),
          percent: Number(t.TAX_PRC ?? 0),
        }));
    const threshold = heads.find((t) => text(t.TAX_CODE) === '20');
    return {
      family,
      book: {
        coBook: book.coBook,
        name: book.configuredName,
        shortName: book.shortName,
        slots: [...book.slots.values()].map((s) => ({ srNo: s.srNo, accountCode: s.accountCode })),
      },
      policy: {
        amountDigits: settings.behavior.allRoundingRemoved ? 2 : 0,
        taxDigits: settings.taxDigits,
        labourRateDigits: settings.labourRateDigits,
        labourIncludesGhat: settings.behavior.labourIncludesGhat,
      },
      defaultLabourType: settings.labourType,
      defaultTaxCode: '10',
      employeeMandatory: settings.employeeMandatory,
      cashLimit: settings.behavior.cashLimit,
      // Item GST help (TAX_CODE >= '10'); TCS help offers 20/00 and TDS help 25/00 (8826, 8892).
      taxCodes: list((code) => code >= '10'),
      tcsCodes: FAMILY[family].invoice ? list((code) => code === '20' || code === '00') : [],
      tdsCodes: FAMILY[family].invoice ? list((code) => code === '25' || code === '00') : [],
      tcsThresholdPercent:
        FAMILY[family].invoice && threshold ? Number(threshold.TAX_PRC ?? 0) : null,
    };
  });
}

/** AcTcsAmt for the entry screen's live TCS preview; the server recomputes on save. */
export async function eInvoiceTcsBasis(prisma: any, scopeInput: VoucherScope, partyCode: string) {
  const scope = completeFinanceScope(scopeInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, 'E INVOICE', scope);
    const party = await accountTx(tx, scope, partyCode, 'party account');
    return { partyCode: party.code, priorDebits: await priorPartyDebitsTx(tx, scope, party.code) };
  });
}

/** Refuse a second IRN before any provider call (BtnIrnGen_Click 9540-9545, 9712). */
export async function assertEBillNotRegistered(
  prisma: any,
  family: EBillFamily,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  await withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, family, scope);
    if (await registrationTx(tx, scope, voucherNo)) {
      throw new EBillWriteValidationError('No Need to Generate eInvoice its Alrady Exciest ....');
    }
  });
}

/** Scoped document data for the voucher print (SalesBillA4Gst.RPT). */
export async function eBillPrintData(
  prisma: any,
  family: EBillFamily,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, family, scope);
    const args = keyArgs(scope, voucherNo);
    const headers: Row[] = await tx.$queryRawUnsafe(
      `SELECT *, "VCH_DATE"::text AS "VCH_DATE" FROM "SL_DATA" WHERE ${keyWhere}`,
      ...args,
    );
    if (headers.length !== 1) return null;
    const lines: Row[] = await tx.$queryRawUnsafe(
      `SELECT d.*, COALESCE(NULLIF(i."HSN_CODE",''), g."HSN_CODE") AS "HSN_CODE", i."IT_NAME"
         FROM "SL_DETL" d
         LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
         LEFT JOIN "GROUP_MAST" g ON g.tenant_id=i.tenant_id AND g."CO_CODE"=i."CO_CODE" AND g."GR_CODE"=i."GR_CODE"
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6
        ORDER BY d."SR_NO", d.row_id`,
      ...args,
    );
    const company: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY CASE WHEN "LC_CODE"=$3 THEN 0 ELSE 1 END LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
    );
    const party: Row[] = await tx.$queryRawUnsafe(
      `SELECT * FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      text(headers[0]!.AC_CODE),
    );
    return {
      header: headers[0]!,
      lines: lines.map((line) => ({
        ...line,
        // SalesBillA4Gst prints the item name; the saved taxable (NET_AMT) includes other charges.
        IT_DESC: [text(line.IT_NAME), text(line.ITM_REMARK)].filter(Boolean).join(' · ') || null,
        PRINT_TAXABLE: line.NET_AMT,
      })),
      company: company[0] ?? null,
      party: party[0] ?? null,
    };
  });
}
