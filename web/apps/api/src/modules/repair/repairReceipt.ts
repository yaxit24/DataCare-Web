import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertPeriodOpen,
  insertRowTx,
  postVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';

/**
 * TR_REP_REC is a four-stage desktop repair workflow. This module implements the first stage,
 * CUSTREP RECEIPT (an item accepted from a customer for repair). KRREP ISSUE is implemented in the
 * source-linked repairKarigarIssue companion; later receipt/delivery stages remain separate and must
 * not be synthesized from the ordinary KR_DATA/KR_DETL job-work flow.
 */
const numOr0 = (v: unknown): number => (v == null ? 0 : Number(v) || 0);
const txt = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;

export const CUSTOMER_REPAIR_RECEIPT = 'CUSTREP RECEIPT';

export class RepairValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'RepairValidationError';
  }
}

export interface RepairLineInput {
  // ---- Hallmark / identity carried on the repair line (REP_DETL) ---------------------------------
  huid?: string; // HM_ID
  hallmarkId2?: string;
  hallmarkId3?: string;
  hallmarkId4?: string;
  hallmarkIdWt?: number;
  hallmarkId2Wt?: number;
  hallmarkId3Wt?: number;
  hallmarkId4Wt?: number;
  itmColor?: string; // ITM_COLOR
  itemLot?: string; // ITM_LOT
  designImageId?: string; // DESIGN_IMG_ID
  itCode: string;
  itmSize?: string;
  description?: string;
  pcs?: number;
  grossWt?: number;
  otherWt?: number;
  addWt?: number;
  lessWt?: number;
  lessTouch?: number;
  touch?: number;
  wastagePct?: number;
  rate?: number;
  /** Desktop ITEM_MAST.RATE_TYPE: P=piece, 1=per-10, K=per-1000, otherwise per unit. */
  rateType?: string;
  /** Desktop LBR_TYPE: P=piece, N=(net+less) weight, K=per-1000, otherwise gross weight. */
  labourType?: string;
  labourRate?: number;
  otherAmount?: number;
}

export interface RepairLineTotals {
  netWt: number;
  fineWt: number;
  lessFine: number;
  itemAmount: number;
  labourAmount: number;
  otherAmount: number;
  netAmount: number;
}

export interface RepairBillTotals {
  netAmount: number;
  discountAmount: number;
  taxAmount: number;
  totalAmount: number;
  outstandingAmount: number;
}

export interface CustomerRepairReceiptInput {
  scope: VoucherScope;
  vchNo?: string | number;
  acCode: string;
  acName?: string;
  vchDate?: Date | string;
  billNo?: string;
  employeeCode?: string;
  bankName?: string;
  description?: string;
  chequeAmount?: number;
  chequeAccount?: string;
  chequeNo?: string;
  cardAmount?: number;
  cardAccount?: string;
  cashAmount?: number;
  mainUser?: string;
  lines: RepairLineInput[];
}

export interface CustomerRepairReceiptResult {
  vchNo: number;
  voucherNo: string;
  headerVoucherNo: string;
  created: boolean;
  totals: RepairBillTotals;
}

export interface CustomerRepairReceiptView {
  voucherNo: string;
  headerVoucherNo: string;
  vchDate: string;
  billNo: string;
  acCode: string;
  acName: string;
  employeeCode: string;
  bankName: string;
  description: string;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  totals: RepairBillTotals;
  lines: Array<
    RepairLineInput &
      RepairLineTotals & {
        srNo: number;
        itemName: string;
        itType: string;
        rateType: string;
      }
  >;
}

interface RepairBookPolicy {
  coBook: string;
  vchType: string;
  mainBook: string;
  inout: string;
  dataType: string;
}

interface RepairBookAccount {
  acCode: string;
  vchType: string;
  dataType: string;
}

interface ResolvedParty {
  acCode: string;
  acName: string;
  gstType: string;
}

interface ResolvedItem {
  itCode: string;
  itemName: string;
  itType: string;
  rateType: string;
}

interface PreparedLine {
  input: RepairLineInput;
  item: ResolvedItem;
  totals: RepairLineTotals;
}

const num = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));

function finiteNonNegative(value: unknown, label: string): number {
  const parsed = num(value);
  if (!Number.isFinite(parsed) || parsed < 0) {
    throw new RepairValidationError(`${label} must be a non-negative number`);
  }
  return parsed;
}

/** .NET Math.Round default midpoint behavior (ToEven), used by TR_REP_REC monetary calculations. */
function roundEven(value: number, digits: number): number {
  const factor = 10 ** digits;
  const scaled = value * factor;
  const floor = Math.floor(scaled);
  const fraction = scaled - floor;
  const rounded =
    Math.abs(fraction - 0.5) < 1e-9
      ? Math.abs(floor) % 2 === 0
        ? floor
        : floor + 1
      : Math.round(scaled);
  return rounded / factor;
}

const r2 = (value: number): number => roundEven(value, 2);
const r3 = (value: number): number => roundEven(value, 3);
const whole = (value: number): number => roundEven(value, 0);

/** Exact CommPassTotal line decision table extracted from TR_REP_REC.cs. */
export function repairLineTotals(
  line: RepairLineInput,
  workflow: string = CUSTOMER_REPAIR_RECEIPT,
): RepairLineTotals {
  const pcs = finiteNonNegative(line.pcs, 'pieces');
  const grossWt = finiteNonNegative(line.grossWt, 'gross weight');
  const otherWt = finiteNonNegative(line.otherWt, 'other weight');
  const addWt = finiteNonNegative(line.addWt, 'add weight');
  const lessWt = finiteNonNegative(line.lessWt, 'less weight');
  const lessTouch = finiteNonNegative(line.lessTouch, 'less touch');
  const touch = finiteNonNegative(line.touch, 'touch');
  const wastagePct = finiteNonNegative(line.wastagePct, 'wastage');
  const rate = finiteNonNegative(line.rate, 'rate');
  const labourRate = finiteNonNegative(line.labourRate, 'labour rate');
  const otherAmount = r2(finiteNonNegative(line.otherAmount, 'other amount'));

  const netWt = r3(grossWt - otherWt);
  const fineWt = r3(touch + wastagePct === 0 ? addWt : (addWt * (touch + wastagePct)) / 100);
  const lessFine = r3(lessTouch === 0 ? 0 : (lessWt * lessTouch) / 100);

  let itemAmount = 0;
  if (rate !== 0 && fineWt + pcs !== 0) {
    const basis = workflow === 'CUSTREP ISSUE' ? addWt : fineWt;
    switch (String(line.rateType ?? '').toUpperCase()) {
      case 'P':
        itemAmount = whole(pcs * rate);
        break;
      case '1':
        itemAmount = whole(basis * (rate / 10));
        break;
      case 'K':
        itemAmount = whole(basis * (rate / 1000));
        break;
      default:
        itemAmount = whole(basis * rate);
        break;
    }
  }

  let labourAmount = 0;
  if (labourRate !== 0) {
    switch (String(line.labourType ?? '').toUpperCase()) {
      case 'P':
        labourAmount = whole(pcs * labourRate);
        break;
      case 'N':
        labourAmount = whole((netWt + lessWt) * labourRate);
        break;
      case 'K':
        labourAmount = whole((netWt + lessWt) * (labourRate / 1000));
        break;
      default:
        labourAmount = whole(grossWt * labourRate);
        break;
    }
  }

  return {
    netWt,
    fineWt,
    lessFine,
    itemAmount: r2(itemAmount),
    labourAmount: r2(labourAmount),
    otherAmount,
    netAmount: r2(itemAmount + labourAmount + otherAmount),
  };
}

/** Exact BILL_TOTAL shape: discount is on labour, tax is on net less discount, total rounds whole. */
export function repairBillTotals(
  lines: Array<Pick<RepairLineTotals, 'netAmount' | 'labourAmount'>>,
  input: {
    discountPct?: number;
    taxPct?: number;
    taxDigits?: number;
    chequeAmount?: number;
    cardAmount?: number;
    cashAmount?: number;
    kasarAmount?: number;
  } = {},
): RepairBillTotals {
  const discountPct = finiteNonNegative(input.discountPct, 'discount percentage');
  const taxPct = finiteNonNegative(input.taxPct, 'tax percentage');
  const cheque = finiteNonNegative(input.chequeAmount, 'cheque amount');
  const card = finiteNonNegative(input.cardAmount, 'card amount');
  const cash = finiteNonNegative(input.cashAmount, 'cash amount');
  const kasar = finiteNonNegative(input.kasarAmount, 'kasar amount');
  const taxDigits = input.taxDigits == null ? 2 : Number(input.taxDigits);
  if (!Number.isInteger(taxDigits) || taxDigits < 0 || taxDigits > 4) {
    throw new RepairValidationError('tax rounding digits must be between 0 and 4');
  }

  const lineNet = lines.reduce((sum, line) => sum + num(line.netAmount), 0);
  const labour = lines.reduce((sum, line) => sum + num(line.labourAmount), 0);
  if (lineNet === 0) {
    // Desktop BILL_TOTAL clears NET/DISC/TAX/TOTAL/BILL_OS when the detail net total is zero, even
    // if cheque/card/cash fields contain an advance (the tender ledger still posts separately).
    return {
      netAmount: 0,
      discountAmount: 0,
      taxAmount: 0,
      totalAmount: 0,
      outstandingAmount: 0,
    };
  }
  const netAmount = r2(whole(lineNet));
  const discountAmount = r2((labour * discountPct) / 100);
  const taxAmount = roundEven(((netAmount - discountAmount) * taxPct) / 100, taxDigits);
  const totalAmount = r2(whole(netAmount - discountAmount + taxAmount));
  return {
    netAmount,
    discountAmount,
    taxAmount,
    totalAmount,
    outstandingAmount: r2(totalAmount - cheque - card - cash - kasar),
  };
}

function completeScope(
  scope: VoucherScope,
): asserts scope is VoucherScope & { coYear: string; coBook: string } {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new RepairValidationError(
      'repair receipt requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

async function resolveRepairBookTx(tx: any, scope: VoucherScope): Promise<RepairBookPolicy> {
  completeScope(scope);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "CO_BOOK","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE","BOOK_TBL_NAME",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce(nullif(upper(btrim("CUR_USE"::text)),''),'Y') <> 'N'
     )
     SELECT * FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates)
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.coBook,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new RepairValidationError(
      rows.length
        ? `repair book configuration is ambiguous: ${scope.coBook}`
        : `repair book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = String(row.MAIN_BOOK ?? '')
    .trim()
    .toUpperCase();
  if (mainBook !== CUSTOMER_REPAIR_RECEIPT) {
    throw new RepairValidationError(
      `book ${scope.coBook} is ${mainBook || 'unclassified'}, expected ${CUSTOMER_REPAIR_RECEIPT}`,
    );
  }
  const table = String(row.BOOK_TBL_NAME ?? '')
    .trim()
    .toUpperCase();
  if (table && table !== 'REP_DATA') {
    throw new RepairValidationError(`book ${scope.coBook} writes ${table}, expected REP_DATA`);
  }
  const inout = String(row.BOOK_INOUT ?? '')
    .trim()
    .toUpperCase();
  if (!inout || inout.length !== 1) {
    throw new RepairValidationError(`book ${scope.coBook} has no one-character BOOK_INOUT`);
  }
  return {
    coBook: String(row.CO_BOOK ?? scope.coBook).trim(),
    vchType: String(row.BOOK_SNAME ?? '').trim() || String(scope.coBook),
    mainBook,
    inout,
    dataType: String(row.DATA_TYPE ?? '').trim() || 'A',
  };
}

async function resolveBookAccountTx(
  tx: any,
  scope: VoucherScope & { coBook?: string },
  policy: RepairBookPolicy,
): Promise<RepairBookAccount> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "AC_CODE","BOOK_SNAME","DATA_TYPE",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce("SR_NO",0)::numeric=1::numeric
          AND upper(btrim(coalesce("MAIN_BOOK"::text,'')))=$5
     )
     SELECT * FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates)
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    policy.coBook,
    scope.lcCode,
    policy.mainBook,
  );
  const acCode = rows.length === 1 ? String(rows[0]?.AC_CODE ?? '').trim() : '';
  if (rows.length !== 1 || !acCode) {
    throw new RepairValidationError(
      `book ${policy.coBook} cash/control account row 1 is ${rows.length ? 'ambiguous or blank' : 'missing'}`,
    );
  }
  return {
    acCode,
    vchType: String(rows[0]?.BOOK_SNAME ?? '').trim() || policy.vchType,
    dataType: String(rows[0]?.DATA_TYPE ?? '').trim() || policy.dataType,
  };
}

async function resolvePartyTx(
  tx: any,
  scope: VoucherScope,
  acCodeInput: string,
  suppliedName?: string,
): Promise<ResolvedParty> {
  const acCode = String(acCodeInput ?? '').trim();
  if (!acCode) throw new RepairValidationError('party account is required');
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "AC_CODE","AC_NAME","AC_GST_TYPE",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL OR btrim(coalesce("LC_CODE"::text,''))='')
     )
     SELECT * FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates)
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    acCode,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new RepairValidationError(
      rows.length ? `party account is ambiguous: ${acCode}` : `party account not found: ${acCode}`,
    );
  }
  const databaseName = String(rows[0]?.AC_NAME ?? '').trim();
  const acName =
    acCode === '00050' && String(suppliedName ?? '').trim()
      ? String(suppliedName).trim()
      : databaseName;
  return {
    acCode,
    acName,
    gstType: String(rows[0]?.AC_GST_TYPE ?? '').trim() || 'L',
  };
}

async function assertAccountTx(tx: any, scope: VoucherScope, acCodeInput: string, label: string) {
  const acCode = String(acCodeInput ?? '').trim();
  if (!acCode) throw new RepairValidationError(`${label} account is required`);
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL OR btrim(coalesce("LC_CODE"::text,''))='')
      LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    acCode,
    scope.lcCode,
  );
  if (rows.length !== 1)
    throw new RepairValidationError(`${label} account not found or ambiguous: ${acCode}`);
}

async function prepareLinesTx(
  tx: any,
  scope: VoucherScope,
  lines: RepairLineInput[],
): Promise<PreparedLine[]> {
  if (!Array.isArray(lines) || !lines.length) {
    throw new RepairValidationError('at least one repair item is required');
  }
  const codes = [...new Set(lines.map((line) => String(line.itCode ?? '').trim()).filter(Boolean))];
  if (codes.length !== lines.length && lines.some((line) => !String(line.itCode ?? '').trim())) {
    throw new RepairValidationError('every repair row requires an item');
  }
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME","IT_TYPE","RATE_TYPE" FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=ANY($3::text[])
      ORDER BY "IT_CODE"`,
    scope.tenantId,
    scope.coCode,
    codes,
  );
  const items = new Map<string, ResolvedItem>();
  for (const row of rows) {
    const itCode = String(row.IT_CODE ?? '').trim();
    if (!itCode) continue;
    if (items.has(itCode)) throw new RepairValidationError(`item is ambiguous: ${itCode}`);
    items.set(itCode, {
      itCode,
      itemName: String(row.IT_NAME ?? '').trim(),
      itType: String(row.IT_TYPE ?? '').trim(),
      rateType: String(row.RATE_TYPE ?? '').trim(),
    });
  }
  return lines.map((line) => {
    const itCode = String(line.itCode ?? '').trim();
    const item = items.get(itCode);
    if (!item) throw new RepairValidationError(`item not found: ${itCode}`);
    const input = { ...line, itCode, rateType: item.rateType };
    const totals = repairLineTotals(input);
    const meaningful =
      finiteNonNegative(line.pcs, 'pieces') !== 0 ||
      finiteNonNegative(line.grossWt, 'gross weight') !== 0 ||
      totals.netAmount !== 0 ||
      Boolean(String(line.description ?? '').trim());
    if (!meaningful)
      throw new RepairValidationError(
        `repair item ${itCode} has no quantity, weight, amount, or description`,
      );
    return { input, item, totals };
  });
}

async function nextHeaderVoucherNoTx(
  tx: any,
  scope: VoucherScope & { coBook: string },
): Promise<string> {
  const key = `repair-header|${scope.tenantId}|${scope.coCode}|${scope.lcCode}|${scope.coBook}`;
  await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', key);
  const rows: Array<{ n: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(max(CASE WHEN "VCH_NO"::text ~ '^[0-9]+$' THEN "VCH_NO"::text::bigint END),0)::bigint AS n
       FROM "TEMP_BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  return formatVoucherNo(Number(rows[0]?.n ?? 0) + 1);
}

function voucherKey(
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Record<string, string> {
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
}

function baseLedgerLine(
  key: Record<string, string>,
  input: CustomerRepairReceiptInput,
  policy: RepairBookPolicy,
  bookAccount: RepairBookAccount,
  party: ResolvedParty,
  vchDate: Date,
  headerVoucherNo: string,
): LedgerLine {
  return {
    ...key,
    VCH_TYPE: bookAccount.vchType,
    VCH_DATE: vchDate,
    BOOK_NAME: policy.mainBook,
    BILL_NO: String(input.billNo ?? '').trim(),
    CHQ_NO: '',
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: 0,
    IT_DESC: '',
    ENTRY_TIME: vchDate,
    HD_VCH_NO: headerVoucherNo,
    DATA_TYPE: bookAccount.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: String(input.mainUser ?? '').trim() || null,
    FINE_RATE: 0,
    PARTY_AC_CODE: party.acCode,
    LDR_NAME: '',
  };
}

function tenderLedgerLines(
  key: Record<string, string>,
  input: CustomerRepairReceiptInput,
  policy: RepairBookPolicy,
  bookAccount: RepairBookAccount,
  party: ResolvedParty,
  vchDate: Date,
  headerVoucherNo: string,
): LedgerLine[] {
  const base = baseLedgerLine(key, input, policy, bookAccount, party, vchDate, headerVoucherNo);
  const lines: LedgerLine[] = [];
  const addPair = (amount: number, contra: string) => {
    if (!amount) return;
    lines.push({ ...base, AC_CODE: party.acCode, LD_CODE: contra, CR_AMT: amount, DR_AMT: 0 });
    lines.push({
      ...base,
      AC_CODE: contra,
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: amount,
      PARTY_AC_CODE: '',
    });
  };
  addPair(
    finiteNonNegative(input.chequeAmount, 'cheque amount'),
    String(input.chequeAccount ?? '').trim(),
  );
  addPair(
    finiteNonNegative(input.cardAmount, 'card amount'),
    String(input.cardAccount ?? '').trim(),
  );
  addPair(finiteNonNegative(input.cashAmount, 'cash amount'), bookAccount.acCode);
  return lines;
}

function rojRows(
  key: Record<string, string>,
  input: CustomerRepairReceiptInput,
  policy: RepairBookPolicy,
  bookAccount: RepairBookAccount,
  party: ResolvedParty,
  vchDate: Date,
): Record<string, unknown>[] {
  const rows: Record<string, unknown>[] = [];
  const common = {
    ...key,
    VCH_DATE: vchDate,
    VCH_TYPE: bookAccount.vchType,
    BOOK_NAME: policy.mainBook,
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
    IT_DESC: '',
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: bookAccount.dataType,
  };
  let ordinal = 0;
  const ledKey = () =>
    `${key.CO_CODE}${key.LC_CODE}${key.CO_YEAR}${key.CO_BOOK}${key.VCH_NO}${String(++ordinal).padStart(2, '0')}`;
  const addPair = (amount: number, contra: string) => {
    if (!amount) return;
    rows.push({
      ...common,
      LEDR_KEY: ledKey(),
      AC_CODE: party.acCode,
      LD_CODE: contra,
      CR_AMT: amount,
      DR_AMT: 0,
      AC_NAME: '',
    });
    rows.push({
      ...common,
      LEDR_KEY: ledKey(),
      AC_CODE: contra,
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: amount,
      AC_NAME: '',
    });
  };
  addPair(
    finiteNonNegative(input.chequeAmount, 'cheque amount'),
    String(input.chequeAccount ?? '').trim(),
  );
  addPair(
    finiteNonNegative(input.cardAmount, 'card amount'),
    String(input.cardAccount ?? '').trim(),
  );
  const cash = finiteNonNegative(input.cashAmount, 'cash amount');
  if (cash) {
    rows.push({
      ...common,
      LEDR_KEY: ledKey(),
      AC_CODE: bookAccount.acCode,
      LD_CODE: party.acCode,
      CR_AMT: cash,
      DR_AMT: 0,
      AC_NAME: `REP - ${party.acName}`,
    });
  }
  return rows;
}

async function existingHeaderTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<Record<string, unknown> | null> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "REP_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
      LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  return rows[0] ?? null;
}

async function assertUnlinkedTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
) {
  const rows: Array<{ linked: unknown }> = await tx.$queryRawUnsafe(
    `SELECT count(*)::int AS linked FROM "REP_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        AND (upper(coalesce("REP_ADJ",'N'))='Y' OR upper(coalesce("ISU_ADJ",'N'))='Y')`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (Number(rows[0]?.linked ?? 0) > 0) {
    throw new RepairValidationError('repair receipt is linked to a later workflow stage');
  }
}

async function deleteVoucherRowsTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
) {
  const args = [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
  for (const table of [
    'REMARK_DATA',
    'TAX_DATA',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'REP_DETL',
    'REP_DATA',
  ]) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...args,
    );
  }
}

/** Create or edit a CUSTREP RECEIPT. An edit retains both desktop voucher identities. */
export async function saveCustomerRepairReceipt(
  prisma: any,
  input: CustomerRepairReceiptInput,
): Promise<CustomerRepairReceiptResult> {
  completeScope(input.scope);
  const scope = input.scope;
  const chequeAmount = finiteNonNegative(input.chequeAmount, 'cheque amount');
  const cardAmount = finiteNonNegative(input.cardAmount, 'card amount');
  const cashAmount = finiteNonNegative(input.cashAmount, 'cash amount');
  if (chequeAmount && !String(input.chequeAccount ?? '').trim()) {
    throw new RepairValidationError('bank account is required when cheque amount is non-zero');
  }
  if (cardAmount && !String(input.cardAccount ?? '').trim()) {
    throw new RepairValidationError('card account is required when card amount is non-zero');
  }
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  if (Number.isNaN(vchDate.getTime())) throw new RepairValidationError('voucher date is invalid');

  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveRepairBookTx(tx, scope);
    const bookAccount = await resolveBookAccountTx(tx, scope, policy);
    const party = await resolvePartyTx(tx, scope, input.acCode, input.acName);
    if (chequeAmount) await assertAccountTx(tx, scope, String(input.chequeAccount), 'bank');
    if (cardAmount) await assertAccountTx(tx, scope, String(input.cardAccount), 'card');
    await assertAccountTx(tx, scope, bookAccount.acCode, 'book cash/control');
    const prepared = await prepareLinesTx(tx, scope, input.lines);
    const totals = repairBillTotals(
      prepared.map((line) => line.totals),
      { chequeAmount, cardAmount, cashAmount },
    );

    const created = input.vchNo == null || String(input.vchNo).trim() === '';
    let voucherNo: string;
    let headerVoucherNo: string;
    if (created) {
      voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, scope));
      headerVoucherNo = await nextHeaderVoucherNoTx(tx, scope);
    } else {
      voucherNo = formatVoucherNo(input.vchNo as string | number);
      const existing = await existingHeaderTx(tx, scope, voucherNo);
      if (!existing) throw new RepairValidationError(`repair receipt not found: ${voucherNo}`);
      await assertUnlinkedTx(tx, scope, voucherNo);
      await assertPeriodOpen(tx, scope.tenantId, {
        ledger: {
          table: 'AC_DATA',
          lines: [{ CO_CODE: scope.coCode, VCH_DATE: existing.VCH_DATE }],
        },
      });
      headerVoucherNo = String(existing.HD_VCH_NO ?? '').trim();
      if (!headerVoucherNo)
        throw new RepairValidationError('existing repair receipt has no header voucher number');
      await deleteVoucherRowsTx(tx, scope, voucherNo);
    }

    const key = voucherKey(scope, voucherNo);
    const mainUser = String(input.mainUser ?? '').trim() || null;
    const header = {
      ...key,
      VCH_DATE: vchDate,
      BILL_NO: String(input.billNo ?? '').trim(),
      VCH_TIME: vchDate,
      AC_CODE: party.acCode,
      AC_NAME: party.acName,
      NET_AMT: totals.netAmount,
      DISC_PRC: 0,
      DISC_AMT: 0,
      TAX_CODE: null,
      TAX_PRC: 0,
      TAX_AMT: 0,
      AC_GST_TYPE: party.gstType,
      IGST_TAX: 0,
      CGST_TAX: 0,
      SGST_TAX: 0,
      ROF_AMT: 0,
      TOT_AMT: totals.totalAmount,
      CASH_AMT: cashAmount,
      CHQ_AMT: chequeAmount,
      BANK_AC: chequeAmount ? String(input.chequeAccount).trim() : null,
      CHQ_NO: String(input.chequeNo ?? '').trim(),
      BANK_NAME: String(input.bankName ?? '').trim(),
      CARD_AMT: cardAmount,
      CARD_AC: cardAmount ? String(input.cardAccount).trim() : null,
      KASAR_AMT: 0,
      BILL_OS: totals.outstandingAmount,
      HD_VCH_NO: headerVoucherNo,
      EMP_CODE: String(input.employeeCode ?? '').trim(),
      VCH_DESC: String(input.description ?? '').trim(),
      DATA_TRFR: 'N',
      MAIN_USER: mainUser,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    };
    const detailRows = prepared.map(({ input: line, item, totals: lineTotals }, index) => ({
      ...key,
      SR_NO: index + 1,
      OLD_SRNO: index + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'C',
      VCH_TIME: vchDate,
      BOOK_NAME: policy.mainBook,
      AC_CODE: party.acCode,
      IT_CODE: item.itCode,
      IT_NAME: item.itemName,
      IT_DESC: String(line.description ?? '').trim(),
      ITM_SIZE: String(line.itmSize ?? '').trim(),
      TAG_NO: null,
      DESIGN_NO: '',
      VCH_SRNO: 0,
      ITM_PCS: finiteNonNegative(line.pcs, 'pieces'),
      ITM_GWT: finiteNonNegative(line.grossWt, 'gross weight'),
      ITM_OTH_WT: finiteNonNegative(line.otherWt, 'other weight'),
      ADD_WT: finiteNonNegative(line.addWt, 'add weight'),
      LESS_WT: finiteNonNegative(line.lessWt, 'less weight'),
      ITM_NWT: lineTotals.netWt,
      ITM_TOUCH: finiteNonNegative(line.touch, 'touch'),
      ITM_WEST: finiteNonNegative(line.wastagePct, 'wastage'),
      ITM_FINE: lineTotals.fineWt,
      LESS_TOUCH: finiteNonNegative(line.lessTouch, 'less touch'),
      LESS_FINE: lineTotals.lessFine,
      ITM_RATE: finiteNonNegative(line.rate, 'rate'),
      ITM_AMT: lineTotals.itemAmount,
      LBR_TYPE: String(line.labourType ?? '')
        .trim()
        .toUpperCase(),
      LBR_RATE: finiteNonNegative(line.labourRate, 'labour rate'),
      LBR_AMT: lineTotals.labourAmount,
      RATE_TYPE: item.rateType,
      IT_TYPE: item.itType,
      OTH_AMT: lineTotals.otherAmount,
      NET_AMT: lineTotals.netAmount,
      REP_NO: voucherNo,
      REP_SRNO: index + 1,
      REP_LC: scope.lcCode,
      REP_YRCD: scope.coYear,
      REP_DBCD: scope.coBook,
      REP_AC_CODE: party.acCode,
      REP_AC_NAME: party.acName,
      REP_HD_VCH_NO: headerVoucherNo,
      REP_ADJ: 'N',
      ISU_ADJ: 'N',
      HD_VCH_NO: headerVoucherNo,
      // TR_REP_REC.cs stamps the hallmark ids with their weights, the colour, lot and design image on the
      // repair line — a hallmarked item taken in for repair must go back out with the same HUIDs.
      HM_ID: txt(line.huid, 10),
      HM_ID2: txt(line.hallmarkId2, 10),
      HM_ID3: txt(line.hallmarkId3, 10),
      HM_ID4: txt(line.hallmarkId4, 10),
      HM_ID_WT: numOr0(line.hallmarkIdWt),
      HM_ID2_WT: numOr0(line.hallmarkId2Wt),
      HM_ID3_WT: numOr0(line.hallmarkId3Wt),
      HM_ID4_WT: numOr0(line.hallmarkId4Wt),
      ITM_COLOR: txt(line.itmColor, 15),
      ITM_LOT: txt(line.itemLot, 10),
      DESIGN_IMG_ID: txt(line.designImageId, 50),
      MAIN_USER: mainUser,
    }));

    const writes: Array<{ table: string; rows: Record<string, unknown>[] }> = [
      { table: 'REP_DATA', rows: [header] },
      { table: 'REP_DETL', rows: detailRows },
    ];
    if (created) {
      writes.unshift({
        table: 'TEMP_BOOK_DATA',
        rows: [
          {
            CO_CODE: scope.coCode,
            LC_CODE: scope.lcCode,
            CO_BOOK: scope.coBook,
            VCH_NO: headerVoucherNo,
            BOOK_NAME: policy.mainBook,
          },
        ],
      });
    }
    const dailyRows = rojRows(key, input, policy, bookAccount, party, vchDate);
    if (dailyRows.length) writes.push({ table: 'ROJ_MEL_DATA', rows: dailyRows });
    if (String(input.description ?? '').trim()) {
      writes.push({
        table: 'REMARK_DATA',
        rows: [
          {
            ...key,
            SR_NO: 1,
            VCH_DATE: vchDate,
            AC_CODE: party.acCode,
            AC_NAME: party.acName,
            MAIN_BOOK: policy.mainBook,
            VCH_REMARK: String(input.description).trim(),
          },
        ],
      });
    }

    await postVoucherTx(tx, scope.tenantId, {
      ledger: {
        table: 'AC_DATA',
        lines: tenderLedgerLines(key, input, policy, bookAccount, party, vchDate, headerVoucherNo),
      },
      bookName: policy.mainBook,
      writes,
    });

    return {
      vchNo: Number(voucherNo),
      voucherNo,
      headerVoucherNo,
      created,
      totals,
    };
  });
}

function dateOnly(value: unknown): string {
  if (!value) return '';
  if (value instanceof Date) return value.toISOString().slice(0, 10);
  return String(value).slice(0, 10);
}

function asView(
  header: Record<string, unknown>,
  rows: Array<Record<string, unknown>>,
): CustomerRepairReceiptView {
  const lines = rows.map((row) => {
    const input: RepairLineInput = {
      itCode: String(row.IT_CODE ?? ''),
      itmSize: String(row.ITM_SIZE ?? ''),
      description: String(row.IT_DESC ?? ''),
      pcs: num(row.ITM_PCS),
      grossWt: num(row.ITM_GWT),
      otherWt: num(row.ITM_OTH_WT),
      addWt: num(row.ADD_WT),
      lessWt: num(row.LESS_WT),
      lessTouch: num(row.LESS_TOUCH),
      touch: num(row.ITM_TOUCH),
      wastagePct: num(row.ITM_WEST),
      rate: num(row.ITM_RATE),
      rateType: String(row.RATE_TYPE ?? ''),
      labourType: String(row.LBR_TYPE ?? ''),
      labourRate: num(row.LBR_RATE),
      otherAmount: num(row.OTH_AMT),
    };
    return {
      ...input,
      srNo: num(row.SR_NO),
      itemName: String(row.IT_NAME ?? ''),
      itType: String(row.IT_TYPE ?? ''),
      rateType: String(row.RATE_TYPE ?? ''),
      netWt: num(row.ITM_NWT),
      fineWt: num(row.ITM_FINE),
      lessFine: num(row.LESS_FINE),
      itemAmount: num(row.ITM_AMT),
      labourAmount: num(row.LBR_AMT),
      otherAmount: num(row.OTH_AMT),
      netAmount: num(row.NET_AMT),
    };
  });
  return {
    voucherNo: String(header.VCH_NO ?? ''),
    headerVoucherNo: String(header.HD_VCH_NO ?? ''),
    vchDate: dateOnly(header.VCH_DATE),
    billNo: String(header.BILL_NO ?? ''),
    acCode: String(header.AC_CODE ?? ''),
    acName: String(header.AC_NAME ?? ''),
    employeeCode: String(header.EMP_CODE ?? ''),
    bankName: String(header.BANK_NAME ?? ''),
    description: String(header.VCH_DESC ?? ''),
    chequeAmount: num(header.CHQ_AMT),
    chequeAccount: String(header.BANK_AC ?? ''),
    chequeNo: String(header.CHQ_NO ?? ''),
    cardAmount: num(header.CARD_AMT),
    cardAccount: String(header.CARD_AC ?? ''),
    cashAmount: num(header.CASH_AMT),
    totals: {
      netAmount: num(header.NET_AMT),
      discountAmount: num(header.DISC_AMT),
      taxAmount: num(header.TAX_AMT),
      totalAmount: num(header.TOT_AMT),
      outstandingAmount: num(header.BILL_OS),
    },
    lines,
  };
}

export async function getCustomerRepairReceipt(
  prisma: any,
  scopeInput: VoucherScope,
  vchNo: string | number,
): Promise<CustomerRepairReceiptView | null> {
  completeScope(scopeInput);
  const scope = scopeInput;
  const voucherNo = formatVoucherNo(vchNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveRepairBookTx(tx, scope);
    const header = await existingHeaderTx(tx, scope, voucherNo);
    if (!header) return null;
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "REP_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    return asView(header, rows);
  });
}

export async function listCustomerRepairReceipts(
  prisma: any,
  scopeInput: VoucherScope,
  limitInput = 50,
): Promise<
  Array<{ voucherNo: string; vchDate: string; acCode: string; acName: string; description: string }>
> {
  completeScope(scopeInput);
  const scope = scopeInput;
  const limit = Math.min(200, Math.max(1, Math.trunc(Number(limitInput) || 50)));
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveRepairBookTx(tx, scope);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE","AC_CODE","AC_NAME","VCH_DESC" FROM "REP_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5
        ORDER BY "VCH_NO" DESC LIMIT $6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      limit,
    );
    return rows.map((row) => ({
      voucherNo: String(row.VCH_NO ?? ''),
      vchDate: dateOnly(row.VCH_DATE),
      acCode: String(row.AC_CODE ?? ''),
      acName: String(row.AC_NAME ?? ''),
      description: String(row.VCH_DESC ?? ''),
    }));
  });
}

export async function deleteCustomerRepairReceipt(
  prisma: any,
  input: { scope: VoucherScope; vchNo: string | number; deleteUser?: string },
): Promise<{ reversed: true }> {
  completeScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveRepairBookTx(tx, scope);
    const existing = await existingHeaderTx(tx, scope, voucherNo);
    if (!existing) throw new RepairValidationError(`repair receipt not found: ${voucherNo}`);
    await assertUnlinkedTx(tx, scope, voucherNo);
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: existing.VCH_DATE }] },
    });
    const headerVoucherNo = String(existing.HD_VCH_NO ?? '').trim();
    await deleteVoucherRowsTx(tx, scope, voucherNo);
    if (headerVoucherNo) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "TEMP_BOOK_DATA"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
        scope.tenantId,
        scope.coCode,
        scope.lcCode,
        scope.coBook,
        headerVoucherNo,
      );
    }
    await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
      ...voucherKey(scope, voucherNo),
      VCH_DATE: existing.VCH_DATE,
      DELETE_DATE: new Date(),
      VCH_TYPE: policy.vchType,
      BOOK_NAME: policy.mainBook,
      AC_CODE: existing.AC_CODE,
      AC_NAME: existing.AC_NAME,
      HD_VCH_NO: headerVoucherNo || null,
      MAIN_USER: existing.MAIN_USER,
      DELETE_USER: String(input.deleteUser ?? '').trim() || 'system',
      VCH_DESC: existing.VCH_DESC,
    });
    return { reversed: true };
  });
}
