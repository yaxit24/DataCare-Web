import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertPeriodOpen,
  insertRowTx,
  postVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import {
  repairBillTotals,
  repairLineTotals,
  type RepairBillTotals,
  type RepairLineTotals,
} from './repairReceipt.js';
import {
  RepairWorkflowValidationError,
  assertCompleteRepairScope,
  assertRepairVoucherUnlinkedTx,
  assertRepairWorkflowAccountTx,
  deleteRepairVoucherRowsTx,
  existingRepairHeaderTx,
  nextRepairHeaderVoucherNoTx,
  repairDateOnly,
  repairNonNegative,
  repairNumber,
  repairVoucherKey,
  resolveRepairWorkflowBookTx,
  resolveRepairWorkflowPartyTx,
  type RepairWorkflowBookPolicy,
  type RepairWorkflowParty,
} from './repairWorkflowCommon.js';

/**
 * Third stage of the desktop TR_REP_REC repair workflow: KRREP RECEIPT — the repaired item taken
 * back from the karigar against an open KRREP ISSUE row. This is deliberately separate from the
 * ordinary KR_DATA/KR_DETL job-work receipt: the desktop form persists REP_DATA/REP_DETL, keeps the
 * original customer REP_* linkage propagated from the selected issue, and binds ISU_* to that issue.
 */
export const KARIGAR_REPAIR_RECEIPT = 'KRREP RECEIPT';
export const KARIGAR_REPAIR_ISSUE_STAGE = 'KRREP ISSUE';

export interface KarigarRepairIssueSourceReference {
  coYear: string;
  coBook: string;
  voucherNo: string | number;
  srNo: number;
}

/**
 * A receipt row. Source identity selects the open KRREP ISSUE line; the remaining fields are the
 * desktop-editable receipt columns. Item/group/type/rate/link metadata stays server-authoritative.
 * Omitted weight/description fields fall back to the selected issue values, matching the desktop
 * behavior of loading the issue row into the grid before the operator edits it.
 */
export interface KarigarRepairReceiptLineInput extends KarigarRepairIssueSourceReference {
  description?: string;
  itmSize?: string;
  pcs?: number;
  grossWt?: number;
  otherWt?: number;
  addWt?: number;
  lessWt?: number;
  lessTouch?: number;
  touch?: number;
  wastagePct?: number;
  rate?: number;
  labourType?: string;
  labourRate?: number;
  otherAmount?: number;
}

export interface KarigarRepairReceiptInput {
  scope: VoucherScope;
  vchNo?: string | number;
  acCode: string;
  acName?: string;
  vchDate?: Date | string;
  billNo?: string;
  employeeCode?: string;
  bankName?: string;
  description?: string;
  discountPct?: number;
  taxCode?: string;
  chequeAmount?: number;
  chequeAccount?: string;
  chequeNo?: string;
  cardAmount?: number;
  cardAccount?: string;
  cashAmount?: number;
  kasarAmount?: number;
  mainUser?: string;
  lines: KarigarRepairReceiptLineInput[];
}

export interface KarigarRepairReceiptResult {
  vchNo: number;
  voucherNo: string;
  headerVoucherNo: string;
  created: boolean;
  totals: RepairBillTotals;
}

export interface OpenKarigarRepairIssueLine {
  code: string;
  name: string;
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  headerVoucherNo: string;
  vchDate: string;
  karigarCode: string;
  karigarName: string;
  customerCode: string;
  customerName: string;
  customerRepairNo: string;
  itCode: string;
  itemName: string;
  itType: string;
  rateType: string;
  description: string;
  itmSize: string;
  tagNo: string;
  vchSrNo: number;
  pieces: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  touch: number;
  wastagePct: number;
  fineWt: number;
}

export interface KarigarRepairReceiptLineView extends OpenKarigarRepairIssueLine {
  receiptSrNo: number;
  addWt: number;
  lessWt: number;
  lessTouch: number;
  lessFine: number;
  rate: number;
  itemAmount: number;
  labourType: string;
  labourRate: number;
  labourAmount: number;
  otherAmount: number;
  netAmount: number;
}

export interface KarigarRepairReceiptView {
  voucherNo: string;
  headerVoucherNo: string;
  vchDate: string;
  billNo: string;
  acCode: string;
  acName: string;
  employeeCode: string;
  bankName: string;
  description: string;
  discountPct: number;
  taxCode: string;
  taxPct: number;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  kasarAmount: number;
  totals: RepairBillTotals;
  lines: KarigarRepairReceiptLineView[];
}

interface NormalizedSourceReference {
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  ordinal: number;
}

interface PreparedReceiptLine {
  ref: NormalizedSourceReference;
  source: Record<string, unknown>;
  input: KarigarRepairReceiptLineInput;
  values: {
    description: string;
    itmSize: string;
    pcs: number;
    grossWt: number;
    otherWt: number;
    addWt: number;
    lessWt: number;
    lessTouch: number;
    touch: number;
    wastagePct: number;
    rate: number;
    labourType: string;
    labourRate: number;
  };
  item: { itCode: string; itemName: string; itType: string; rateType: string; purcAc: string };
  totals: RepairLineTotals;
}

interface ReceiptTaxPolicy {
  taxCode: string | null;
  taxPct: number;
  taxAccount: string | null;
}

interface ReceiptCompanySettings {
  taxDigits: number;
  tradeFine: boolean;
}

const round2 = (value: number): number => Math.round((value + Number.EPSILON) * 100) / 100;
const pad2 = (value: number | string): string => String(value).padStart(2, '0');

function optionalNumber(value: unknown, fallback: number, label: string): number {
  if (value == null || value === '') return fallback;
  return repairNonNegative(value, label);
}

function optionalText(value: unknown, fallback: string): string {
  if (value == null) return fallback;
  const text = String(value).trim();
  return text || fallback;
}

function normalizedSourceReferences(
  lines: KarigarRepairReceiptLineInput[],
): NormalizedSourceReference[] {
  if (!Array.isArray(lines) || !lines.length) {
    throw new RepairWorkflowValidationError('at least one open karigar repair issue is required');
  }
  const seen = new Set<string>();
  return lines.map((line, ordinal) => {
    const coYear = String(line?.coYear ?? '').trim();
    const coBook = String(line?.coBook ?? '').trim();
    const srNo = Number(line?.srNo);
    if (!coYear || !coBook) {
      throw new RepairWorkflowValidationError('every source row requires fiscal year and book');
    }
    if (!Number.isSafeInteger(srNo) || srNo < 1) {
      throw new RepairWorkflowValidationError(
        'source issue serial number must be a positive integer',
      );
    }
    let voucherNo: string;
    try {
      voucherNo = formatVoucherNo(line.voucherNo);
    } catch {
      throw new RepairWorkflowValidationError(`invalid source issue voucher: ${line.voucherNo}`);
    }
    const key = `${coYear}|${coBook}|${voucherNo}|${srNo}`;
    if (seen.has(key)) {
      throw new RepairWorkflowValidationError(`duplicate source issue row: ${key}`);
    }
    seen.add(key);
    return { coYear, coBook, voucherNo, srNo, ordinal };
  });
}

function sourceKey(row: Record<string, unknown>): string {
  return `${String(row.CO_YEAR ?? '').trim()}|${String(row.CO_BOOK ?? '').trim()}|${String(
    row.VCH_NO ?? '',
  ).trim()}|${repairNumber(row.SR_NO)}`;
}

/** Resolve one BOOK_DETL account row (desktop rows 1/2/3/5) with current-location preference. */
async function resolveBookDetlAccountTx(
  tx: any,
  scope: VoucherScope,
  policy: RepairWorkflowBookPolicy,
  srNo: number,
  label: string,
): Promise<string> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "AC_CODE",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DETL"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce("SR_NO",0)::numeric=$5::numeric
          AND upper(btrim(coalesce("MAIN_BOOK"::text,'')))=$6
     )
     SELECT * FROM candidates
      WHERE priority=(SELECT min(priority) FROM candidates)
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    policy.coBook,
    scope.lcCode,
    srNo,
    policy.mainBook,
  );
  const acCode = rows.length === 1 ? String(rows[0]?.AC_CODE ?? '').trim() : '';
  if (rows.length !== 1 || !acCode) {
    throw new RepairWorkflowValidationError(
      `book ${policy.coBook} ${label} account row ${srNo} is ${
        rows.length ? 'ambiguous or blank' : 'missing'
      }`,
    );
  }
  await assertRepairWorkflowAccountTx(tx, scope, acCode, `book ${label}`);
  return acCode;
}

/** CO_SET.TAX_ROF drives BILL_TOTAL tax rounding; CO_SET.TRAD_FINE drives the mirrored fine leg. */
async function resolveCompanySettingsTx(
  tx: any,
  scope: VoucherScope,
): Promise<ReceiptCompanySettings> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT DISTINCT btrim(coalesce("TAX_ROF"::text,'')) AS tax_rof,
                     upper(btrim(coalesce("TRAD_FINE"::text,''))) AS trad_fine
       FROM "CO_SET"
      WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
    scope.tenantId,
    scope.coCode,
  );
  if (rows.length > 1) {
    throw new RepairWorkflowValidationError(
      `company ${scope.coCode} has conflicting CO_SET tax-rounding/trade-fine settings`,
    );
  }
  const row = rows[0];
  const raw = String(row?.tax_rof ?? '').trim();
  // Desktop MS_OPNCOMP loads CO_SET.TAX_ROF through Val() then Math.Round, so an unset value means
  // whole-rupee tax rounding. A present but non-numeric or out-of-range value is a configuration
  // failure rather than a silent default.
  let taxDigits = 0;
  if (raw) {
    const parsed = Number(raw);
    if (!Number.isFinite(parsed)) {
      throw new RepairWorkflowValidationError(`CO_SET.TAX_ROF is not numeric: ${raw}`);
    }
    taxDigits = Math.round(parsed);
    if (taxDigits < 0 || taxDigits > 4) {
      throw new RepairWorkflowValidationError(`CO_SET.TAX_ROF is out of range: ${raw}`);
    }
  }
  return { taxDigits, tradeFine: String(row?.trad_fine ?? '') === 'Y' };
}

/** REP_DATA.TAX_CODE → TAX_MAST row SR_NO=0 → TAX_AC/TAX_PRC. Blank tax code means no tax. */
async function resolveReceiptTaxTx(
  tx: any,
  scope: VoucherScope,
  taxCodeInput: string | undefined,
): Promise<ReceiptTaxPolicy> {
  const taxCode = String(taxCodeInput ?? '').trim();
  if (!taxCode) return { taxCode: null, taxPct: 0, taxAccount: null };
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAX_PRC", btrim(coalesce("TAX_AC"::text,'')) AS tax_ac
       FROM "TAX_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3 AND coalesce("SR_NO",0)::numeric=0::numeric`,
    scope.tenantId,
    scope.coCode,
    taxCode,
  );
  if (rows.length !== 1) {
    throw new RepairWorkflowValidationError(
      rows.length
        ? `tax ${taxCode} row SR_NO=0 is ambiguous`
        : `tax ${taxCode} row SR_NO=0 is missing`,
    );
  }
  const taxPct = repairNonNegative(rows[0]?.TAX_PRC, `tax ${taxCode} percentage`);
  const taxAccount = String(rows[0]?.tax_ac ?? '').trim();
  if (taxPct !== 0 && !taxAccount) {
    throw new RepairWorkflowValidationError(`tax ${taxCode} has no TAX_AC account`);
  }
  if (taxAccount) await assertRepairWorkflowAccountTx(tx, scope, taxAccount, 'tax');
  return { taxCode, taxPct, taxAccount: taxAccount || null };
}

/** ITEM_MAST identity plus the GROUP_MAST.PURC_AC expense account used by the R3 item leg. */
async function resolveItemAccountsTx(
  tx: any,
  scope: VoucherScope,
  itCodes: string[],
): Promise<Map<string, PreparedReceiptLine['item']>> {
  const codes = [...new Set(itCodes.filter(Boolean))];
  if (!codes.length) throw new RepairWorkflowValidationError('no repair items to resolve');
  const items: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME","IT_TYPE","RATE_TYPE",btrim(coalesce("GR_CODE"::text,'')) AS gr_code
       FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    codes,
  );
  if (items.length !== codes.length) {
    const found = new Set(items.map((row) => String(row.IT_CODE ?? '').trim()));
    const missing = codes.filter((code) => !found.has(code));
    throw new RepairWorkflowValidationError(`item not found: ${missing.join(', ')}`);
  }
  const groupCodes = [
    ...new Set(items.map((row) => String(row.gr_code ?? '').trim()).filter(Boolean)),
  ];
  if (groupCodes.length !== new Set(items.map((row) => String(row.gr_code ?? '').trim())).size) {
    throw new RepairWorkflowValidationError('repair item group is missing on one or more items');
  }
  const groups: Array<Record<string, unknown>> = groupCodes.length
    ? await tx.$queryRawUnsafe(
        `SELECT "GR_CODE",btrim(coalesce("PURC_AC"::text,'')) AS purc_ac
           FROM "GROUP_MAST"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=ANY($3::text[])`,
        scope.tenantId,
        scope.coCode,
        groupCodes,
      )
    : [];
  const purchaseAccounts = new Map<string, string>();
  for (const row of groups) {
    const grCode = String(row.GR_CODE ?? '').trim();
    if (purchaseAccounts.has(grCode)) {
      throw new RepairWorkflowValidationError(`item group is ambiguous: ${grCode}`);
    }
    purchaseAccounts.set(grCode, String(row.purc_ac ?? '').trim());
  }
  const resolved = new Map<string, PreparedReceiptLine['item']>();
  for (const row of items) {
    const itCode = String(row.IT_CODE ?? '').trim();
    const grCode = String(row.gr_code ?? '').trim();
    if (!grCode) throw new RepairWorkflowValidationError(`item ${itCode} has no item group`);
    const purcAc = purchaseAccounts.get(grCode);
    if (purcAc == null) {
      throw new RepairWorkflowValidationError(`item group not found: ${grCode}`);
    }
    if (!purcAc) {
      throw new RepairWorkflowValidationError(`item group ${grCode} has no PURC_AC account`);
    }
    await assertRepairWorkflowAccountTx(tx, scope, purcAc, `item group ${grCode} purchase`);
    resolved.set(itCode, {
      itCode,
      itemName: String(row.IT_NAME ?? '').trim(),
      itType: String(row.IT_TYPE ?? '').trim(),
      rateType: String(row.RATE_TYPE ?? '').trim(),
      purcAc,
    });
  }
  return resolved;
}

/**
 * Desktop Rep_KrRec_CustIsu_Ledr credits the party with the rounded TOT_AMT but debits the raw item,
 * raw labour/other, and tax amounts, so its own SQL is unbalanced whenever a labour discount or a
 * whole-total rounding delta exists. The web posting layer always validates double entry, so the
 * configured BOOK_DETL row-3 labour/other debit absorbs the discount and rounding delta instead of
 * inventing a discount or round-off account. This is an explicit web adaptation of a desktop
 * inconsistency, not a desktop behavior.
 */
export function karigarReceiptLabourOtherLegs(input: {
  totalAmount: number;
  itemDebitTotal: number;
  taxAmount: number;
  rawLabourOther: number[];
}): { legs: number[]; target: number; adjustment: number } {
  const raw = input.rawLabourOther.map((value) => round2(Number(value) || 0));
  if (raw.some((value) => value < 0)) {
    throw new RepairWorkflowValidationError('labour/other amounts must be non-negative');
  }
  const target = round2(
    Number(input.totalAmount || 0) -
      Number(input.itemDebitTotal || 0) -
      Number(input.taxAmount || 0),
  );
  if (target < 0) {
    throw new RepairWorkflowValidationError(
      `labour/other ledger debit would be negative (${target}); item and tax amounts exceed the voucher total`,
    );
  }
  if (!raw.length) {
    if (target !== 0) {
      throw new RepairWorkflowValidationError(
        'labour/other ledger debit cannot be posted without a detail row',
      );
    }
    return { legs: [], target, adjustment: 0 };
  }
  const rawTotal = round2(raw.reduce((sum, value) => sum + value, 0));
  const adjustment = round2(target - rawTotal);
  if (target === 0) {
    return { legs: raw.map(() => 0), target, adjustment };
  }
  let legs: number[];
  if (rawTotal > 0) {
    legs = raw.map((value) => round2((value * target) / rawTotal));
    let absorb = 0;
    for (let index = 1; index < raw.length; index += 1) {
      if ((raw[index] as number) > (raw[absorb] as number)) absorb = index;
    }
    legs[absorb] = round2(
      (legs[absorb] as number) + (target - round2(legs.reduce((s, v) => s + v, 0))),
    );
  } else {
    legs = raw.map((_, index) => (index === 0 ? target : 0));
  }
  if (legs.some((value) => value < 0)) {
    throw new RepairWorkflowValidationError('labour/other ledger debit distribution went negative');
  }
  return { legs, target, adjustment };
}

async function prepareReceiptLinesTx(
  tx: any,
  scope: VoucherScope,
  karigarAcCode: string,
  inputLines: KarigarRepairReceiptLineInput[],
): Promise<PreparedReceiptLine[]> {
  const refs = normalizedSourceReferences(inputLines);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT A.*, H."AC_NAME" AS "SOURCE_AC_NAME", H."VCH_NO" AS "SOURCE_HEADER_EXISTS",
            H."VCH_DATE" AS "SOURCE_VCH_DATE"
       FROM jsonb_to_recordset($4::jsonb)
              AS R("coYear" text,"coBook" text,"voucherNo" text,"srNo" numeric,ordinal int)
       JOIN "REP_DETL" AS A
         ON A.tenant_id=$1 AND A."CO_CODE"=$2 AND A."LC_CODE"=$3
        AND A."CO_YEAR"=R."coYear" AND A."CO_BOOK"=R."coBook"
        AND A."VCH_NO"=R."voucherNo" AND A."SR_NO"::numeric=R."srNo"
       LEFT JOIN "REP_DATA" AS H
         ON H.tenant_id=A.tenant_id AND H."CO_CODE"=A."CO_CODE" AND H."LC_CODE"=A."LC_CODE"
        AND H."CO_YEAR"=A."CO_YEAR" AND H."CO_BOOK"=A."CO_BOOK" AND H."VCH_NO"=A."VCH_NO"
      ORDER BY A."CO_YEAR",A."CO_BOOK",A."VCH_NO",A."SR_NO"
      FOR UPDATE OF A`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    JSON.stringify(refs),
  );
  const byKey = new Map(rows.map((row) => [sourceKey(row), row]));
  if (rows.length !== refs.length || byKey.size !== refs.length) {
    throw new RepairWorkflowValidationError('one or more karigar repair issue rows do not exist');
  }
  const matched = refs.map((ref) => {
    const key = `${ref.coYear}|${ref.coBook}|${ref.voucherNo}|${ref.srNo}`;
    const source = byKey.get(key);
    if (!source) throw new RepairWorkflowValidationError(`karigar repair issue not found: ${key}`);
    if (!source.SOURCE_HEADER_EXISTS) {
      throw new RepairWorkflowValidationError(`karigar repair issue header is missing: ${key}`);
    }
    if (
      String(source.BOOK_NAME ?? '')
        .trim()
        .toUpperCase() !== KARIGAR_REPAIR_ISSUE_STAGE
    ) {
      throw new RepairWorkflowValidationError(`source row ${key} is not a karigar repair issue`);
    }
    if (String(source.AC_CODE ?? '').trim() !== karigarAcCode) {
      throw new RepairWorkflowValidationError(
        `karigar repair issue ${key} belongs to another karigar`,
      );
    }
    if (
      String(source.ISU_ADJ ?? 'N')
        .trim()
        .toUpperCase() !== 'N'
    ) {
      throw new RepairWorkflowValidationError(`karigar repair issue is already received: ${key}`);
    }
    if (!String(source.IT_CODE ?? '').trim()) {
      throw new RepairWorkflowValidationError(`karigar repair issue has no item: ${key}`);
    }
    return { ref, source };
  });

  const items = await resolveItemAccountsTx(
    tx,
    scope,
    matched.map(({ source }) => String(source.IT_CODE ?? '').trim()),
  );

  const prepared: PreparedReceiptLine[] = [];
  for (const { ref, source } of matched) {
    const input = inputLines[ref.ordinal] as KarigarRepairReceiptLineInput;
    const item = items.get(String(source.IT_CODE ?? '').trim());
    if (!item) {
      throw new RepairWorkflowValidationError(`item not resolved: ${String(source.IT_CODE ?? '')}`);
    }
    const values = {
      description: optionalText(input.description, String(source.IT_DESC ?? '').trim()),
      itmSize: optionalText(input.itmSize, String(source.ITM_SIZE ?? '').trim()),
      pcs: optionalNumber(input.pcs, repairNumber(source.ITM_PCS), 'pieces'),
      grossWt: optionalNumber(input.grossWt, repairNumber(source.ITM_GWT), 'gross weight'),
      otherWt: optionalNumber(input.otherWt, repairNumber(source.ITM_OTH_WT), 'other weight'),
      addWt: optionalNumber(input.addWt, 0, 'add weight'),
      lessWt: optionalNumber(input.lessWt, 0, 'less weight'),
      lessTouch: optionalNumber(input.lessTouch, 0, 'less touch'),
      touch: optionalNumber(input.touch, repairNumber(source.ITM_TOUCH), 'touch'),
      wastagePct: optionalNumber(input.wastagePct, repairNumber(source.ITM_WEST), 'wastage'),
      rate: optionalNumber(input.rate, 0, 'rate'),
      labourType: String(input.labourType ?? '')
        .trim()
        .toUpperCase(),
      labourRate: optionalNumber(input.labourRate, 0, 'labour rate'),
    };
    const totals = repairLineTotals(
      {
        itCode: item.itCode,
        pcs: values.pcs,
        grossWt: values.grossWt,
        otherWt: values.otherWt,
        addWt: values.addWt,
        lessWt: values.lessWt,
        lessTouch: values.lessTouch,
        touch: values.touch,
        wastagePct: values.wastagePct,
        rate: values.rate,
        rateType: item.rateType,
        labourType: values.labourType,
        labourRate: values.labourRate,
        otherAmount: optionalNumber(input.otherAmount, 0, 'other amount'),
      },
      KARIGAR_REPAIR_RECEIPT,
    );
    // TR_REP_REC persists a KRREP RECEIPT detail only when (net weight + net amount) is non-zero
    // and the item code is present.
    if (totals.netWt + totals.netAmount === 0) continue;
    prepared.push({ ref, source, input, values, item, totals });
  }
  if (!prepared.length) {
    throw new RepairWorkflowValidationError(
      'no karigar repair receipt row has a net weight or net amount',
    );
  }
  return prepared;
}

async function markIssueSourcesReceivedTx(
  tx: any,
  scope: VoucherScope,
  prepared: PreparedReceiptLine[],
): Promise<void> {
  const changed = await tx.$executeRawUnsafe(
    `UPDATE "REP_DETL" AS A SET "ISU_ADJ"='Y'
       FROM jsonb_to_recordset($4::jsonb)
              AS R("coYear" text,"coBook" text,"voucherNo" text,"srNo" numeric)
      WHERE A.tenant_id=$1 AND A."CO_CODE"=$2 AND A."LC_CODE"=$3
        AND A."CO_YEAR"=R."coYear" AND A."CO_BOOK"=R."coBook"
        AND A."VCH_NO"=R."voucherNo" AND A."SR_NO"::numeric=R."srNo"
        AND upper(coalesce(A."ISU_ADJ",'N'))='N'`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    JSON.stringify(
      prepared.map(({ ref }) => ({
        coYear: ref.coYear,
        coBook: ref.coBook,
        voucherNo: ref.voucherNo,
        srNo: ref.srNo,
      })),
    ),
  );
  if (Number(changed) !== prepared.length) {
    throw new RepairWorkflowValidationError('karigar repair issue linkage changed concurrently');
  }
}

async function releaseReceiptSourcesTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<void> {
  await tx.$executeRawUnsafe(
    `UPDATE "REP_DETL" AS SOURCE SET "ISU_ADJ"='N'
       FROM "REP_DETL" AS RECEIPT
      WHERE SOURCE.tenant_id=RECEIPT.tenant_id AND SOURCE."CO_CODE"=RECEIPT."CO_CODE"
        AND SOURCE."LC_CODE"=RECEIPT."ISU_LC" AND SOURCE."CO_YEAR"=RECEIPT."ISU_YRCD"
        AND SOURCE."CO_BOOK"=RECEIPT."ISU_DBCD" AND SOURCE."VCH_NO"=RECEIPT."ISU_NO"
        AND SOURCE."SR_NO"::numeric=RECEIPT."ISU_SRNO"::numeric
        AND upper(btrim(coalesce(SOURCE."BOOK_NAME"::text,'')))=$7
        AND RECEIPT.tenant_id=$1 AND RECEIPT."CO_CODE"=$2 AND RECEIPT."LC_CODE"=$3
        AND RECEIPT."CO_YEAR"=$4 AND RECEIPT."CO_BOOK"=$5 AND RECEIPT."VCH_NO"=$6`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
    KARIGAR_REPAIR_ISSUE_STAGE,
  );
}

interface ReceiptLedgerContext {
  key: Record<string, string>;
  input: KarigarRepairReceiptInput;
  policy: RepairWorkflowBookPolicy;
  party: RepairWorkflowParty;
  vchDate: Date;
  headerVoucherNo: string;
  vchType: string;
  dataType: string;
  accounts: { cash: string; partyTotal: string; labour: string; kasar: string };
  tax: ReceiptTaxPolicy;
  settings: ReceiptCompanySettings;
  totals: RepairBillTotals;
  prepared: PreparedReceiptLine[];
  labourLegs: number[];
  tender: { cheque: number; card: number; cash: number; kasar: number };
}

function receiptLedgerLines(context: ReceiptLedgerContext): LedgerLine[] {
  const { key, input, policy, party, vchDate, headerVoucherNo, totals, prepared } = context;
  const ledgerKey = (srNo: number, tag: string): string =>
    `${key.CO_CODE}${key.LC_CODE}${key.CO_YEAR}${key.CO_BOOK}${key.VCH_NO}${pad2(srNo)}${tag}`;
  const base = {
    ...key,
    VCH_TYPE: context.vchType,
    VCH_DATE: vchDate,
    BOOK_NAME: policy.mainBook,
    BILL_NO: String(input.billNo ?? '').trim(),
    // Repair tender ledger rows keep CHQ_NO blank; the cheque reference stays on REP_DATA.
    CHQ_NO: '',
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: 0,
    IT_DESC: '',
    ENTRY_TIME: vchDate,
    HD_VCH_NO: headerVoucherNo,
    DATA_TYPE: context.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: String(input.mainUser ?? '').trim() || null,
    FINE_RATE: 0,
    PARTY_AC_CODE: party.acCode,
    LDR_NAME: '',
  };
  const lines: LedgerLine[] = [];

  if (totals.totalAmount) {
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, '01'),
      AC_CODE: party.acCode,
      LD_CODE: context.accounts.partyTotal,
      CR_AMT: totals.totalAmount,
      DR_AMT: 0,
    });
  }
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    if (line.totals.itemAmount) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '02'),
        AC_CODE: line.item.purcAc,
        LD_CODE: party.acCode,
        CR_AMT: 0,
        DR_AMT: line.totals.itemAmount,
        PARTY_AC_CODE: party.acCode,
      });
    }
    const labour = context.labourLegs[index] ?? 0;
    if (labour) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '03'),
        AC_CODE: context.accounts.labour,
        LD_CODE: party.acCode,
        CR_AMT: 0,
        DR_AMT: labour,
      });
    }
  });
  if (totals.taxAmount && context.tax.taxAccount) {
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, '04'),
      AC_CODE: context.tax.taxAccount,
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: totals.taxAmount,
    });
  }
  const addTenderPair = (amount: number, contra: string, debitTag: string, creditTag: string) => {
    if (!amount) return;
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, debitTag),
      AC_CODE: party.acCode,
      LD_CODE: contra,
      CR_AMT: 0,
      DR_AMT: amount,
    });
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, creditTag),
      AC_CODE: contra,
      LD_CODE: party.acCode,
      CR_AMT: amount,
      DR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  };
  addTenderPair(context.tender.cheque, String(input.chequeAccount ?? '').trim(), '05', '06');
  addTenderPair(context.tender.card, String(input.cardAccount ?? '').trim(), '07', '08');
  addTenderPair(context.tender.cash, context.accounts.cash, '09', '10');
  addTenderPair(context.tender.kasar, context.accounts.kasar, '11', '12');

  // Fine legs carry metal weight only; CR/DR stay zero so double entry is unaffected. Desktop
  // restricts them to an inward-configured KRREP RECEIPT book (BOOK_INOUT='I').
  const fineLegs = policy.inout === 'I';
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    if (!fineLegs) return;
    if (line.totals.itemAmount === 0 && line.totals.fineWt) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '13'),
        AC_CODE: party.acCode,
        LD_CODE: line.item.purcAc,
        CR_AMT: 0,
        DR_AMT: 0,
        IT_TYPE: line.item.itType || 'A',
        SIGN: '+',
        FINE_WT: line.totals.fineWt,
      });
    }
    if (line.totals.lessFine) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '14'),
        AC_CODE: party.acCode,
        LD_CODE: line.item.purcAc,
        CR_AMT: 0,
        DR_AMT: 0,
        IT_TYPE: line.item.itType || 'A',
        SIGN: '-',
        FINE_WT: line.totals.lessFine,
      });
    }
    if (context.settings.tradeFine && line.totals.itemAmount === 0 && line.totals.fineWt) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '15'),
        AC_CODE: line.item.purcAc,
        LD_CODE: party.acCode,
        CR_AMT: 0,
        DR_AMT: 0,
        IT_TYPE: line.item.itType || 'A',
        SIGN: '-',
        FINE_WT: line.totals.fineWt,
      });
    }
  });
  return lines;
}

function receiptRojRows(context: ReceiptLedgerContext): Record<string, unknown>[] {
  const { key, input, policy, party, vchDate, totals, prepared } = context;
  const ledgerKey = (srNo: number, tag: string): string =>
    `${key.CO_CODE}${key.LC_CODE}${key.CO_YEAR}${key.CO_BOOK}${key.VCH_NO}${pad2(srNo)}${tag}`;
  const common = {
    ...key,
    VCH_DATE: vchDate,
    VCH_TYPE: context.vchType,
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
    DATA_TYPE: context.dataType,
    AC_NAME: '',
  };
  const rows: Record<string, unknown>[] = [];
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    if (line.totals.netAmount !== 0) {
      // Desktop emits this row from the detail net amount even when the item amount is zero, so a
      // labour-only row still records item metadata with zero money. Touch/wastage/fine are written
      // as literal zeros by Rep_KrRec_CustIsu_Rojmel; only the fine row carries metal metadata.
      rows.push({
        ...common,
        LEDR_KEY: ledgerKey(srNo, '01'),
        AC_CODE: line.item.purcAc,
        LD_CODE: party.acCode,
        CR_AMT: 0,
        DR_AMT: line.totals.itemAmount,
        IT_TYPE: line.item.itType || 'A',
        SIGN: '+',
        IT_CODE: line.item.itCode,
        ITM_PCS: line.values.pcs,
        ITM_GWT: line.values.grossWt,
        ITM_NWT: line.totals.netWt,
        ITM_RATE: line.values.rate,
        ITM_AMT: line.totals.itemAmount,
        LBR_RATE: line.values.labourRate,
        LBR_AMT: line.totals.labourAmount,
        OTH_AMT: line.totals.otherAmount,
        NET_AMT: line.totals.netAmount,
      });
    }
    const labour = context.labourLegs[index] ?? 0;
    if (labour) {
      rows.push({
        ...common,
        LEDR_KEY: ledgerKey(srNo, '02'),
        AC_CODE: context.accounts.labour,
        LD_CODE: party.acCode,
        CR_AMT: 0,
        DR_AMT: labour,
        IT_CODE: line.item.itCode,
        // Desktop uses ADD_WT for the labour/other Rojmel weight metadata and carries the detail
        // net amount, not the labour amount.
        ITM_GWT: line.values.addWt,
        ITM_NWT: line.values.addWt,
        LBR_RATE: line.values.labourRate,
        LBR_AMT: line.totals.labourAmount,
        OTH_AMT: line.totals.otherAmount,
        NET_AMT: line.totals.netAmount,
      });
    }
  });
  if (totals.taxAmount && context.tax.taxAccount) {
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '03'),
      AC_CODE: context.tax.taxAccount,
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: totals.taxAmount,
    });
  }
  if (totals.outstandingAmount) {
    // Desktop joins BOOK_DETL row 1 for this row, so the contra is the cash/control account.
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '04'),
      AC_CODE: party.acCode,
      LD_CODE: context.accounts.cash,
      CR_AMT: totals.outstandingAmount,
      DR_AMT: 0,
      AC_NAME: party.acName,
    });
  }
  if (context.tender.cheque) {
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '05'),
      AC_CODE: String(input.chequeAccount ?? '').trim(),
      LD_CODE: party.acCode,
      CR_AMT: context.tender.cheque,
      DR_AMT: 0,
    });
  }
  if (context.tender.card) {
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '06'),
      AC_CODE: String(input.cardAccount ?? '').trim(),
      LD_CODE: party.acCode,
      CR_AMT: context.tender.card,
      DR_AMT: 0,
    });
  }
  if (context.tender.kasar) {
    // Ac_Rojmel.Rep_KrRec_CustIsu_Rojmel books kasar against BOOK_DETL row 3, while AC_DATA uses
    // row 5. KRREP RECEIPT also has no Rojmel cash row and no Rojmel less-fine row.
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '07'),
      AC_CODE: context.accounts.labour,
      LD_CODE: party.acCode,
      CR_AMT: context.tender.kasar,
      DR_AMT: 0,
      AC_NAME: `KSR - ${party.acName}`,
    });
  }
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    if (line.totals.itemAmount === 0 && line.totals.fineWt) {
      rows.push({
        ...common,
        LEDR_KEY: ledgerKey(srNo, '09'),
        AC_CODE: party.acCode,
        LD_CODE: line.item.purcAc,
        CR_AMT: 0,
        DR_AMT: 0,
        AC_NAME: party.acName,
        IT_TYPE: line.item.itType || 'A',
        SIGN: '+',
        IT_CODE: line.item.itCode,
        IT_DESC: line.item.itemName,
        ITM_GWT: line.values.addWt,
        ITM_NWT: line.values.addWt,
        ITM_TOUCH: line.values.touch,
        ITM_WEST: line.values.wastagePct,
        ITM_FINE: line.totals.fineWt,
      });
    }
  });
  return rows;
}

function receiptDetailRows(
  context: ReceiptLedgerContext,
  mainUser: string | null,
): Record<string, unknown>[] {
  const { key, policy, party, vchDate, headerVoucherNo, prepared } = context;
  return prepared.map(({ source, values, item, totals }, index) => ({
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
    IT_DESC: values.description,
    ITM_SIZE: values.itmSize,
    TAG_NO: String(source.TAG_NO ?? '').trim() || null,
    DESIGN_NO: String(source.DESIGN_NO ?? '').trim(),
    VCH_SRNO: repairNumber(source.VCH_SRNO),
    ITM_PCS: values.pcs,
    ITM_GWT: values.grossWt,
    ITM_OTH_WT: values.otherWt,
    ADD_WT: values.addWt,
    LESS_WT: values.lessWt,
    ITM_NWT: totals.netWt,
    ITM_TOUCH: values.touch,
    ITM_WEST: values.wastagePct,
    ITM_FINE: totals.fineWt,
    LESS_TOUCH: values.lessTouch,
    LESS_FINE: totals.lessFine,
    ITM_RATE: values.rate,
    ITM_AMT: totals.itemAmount,
    LBR_TYPE: values.labourType,
    LBR_RATE: values.labourRate,
    LBR_AMT: totals.labourAmount,
    RATE_TYPE: item.rateType,
    IT_TYPE: item.itType,
    OTH_AMT: totals.otherAmount,
    NET_AMT: totals.netAmount,
    // Customer linkage is propagated from the selected issue's stored REP_* columns.
    REP_NO: String(source.REP_NO ?? '').trim(),
    REP_SRNO: repairNumber(source.REP_SRNO),
    REP_LC: String(source.REP_LC ?? '').trim(),
    REP_YRCD: String(source.REP_YRCD ?? '').trim(),
    REP_DBCD: String(source.REP_DBCD ?? '').trim(),
    REP_AC_CODE: String(source.REP_AC_CODE ?? '').trim(),
    REP_AC_NAME: String(source.REP_AC_NAME ?? '').trim(),
    REP_HD_VCH_NO: String(source.REP_HD_VCH_NO ?? '').trim(),
    REP_ADJ: 'N',
    // ISU_* points at the selected KRREP ISSUE row that this receipt consumes.
    ISU_NO: String(source.VCH_NO ?? '').trim(),
    ISU_SRNO: repairNumber(source.SR_NO),
    ISU_LC: String(source.LC_CODE ?? '').trim(),
    ISU_YRCD: String(source.CO_YEAR ?? '').trim(),
    ISU_DBCD: String(source.CO_BOOK ?? '').trim(),
    ISU_AC_CODE: String(source.AC_CODE ?? '').trim(),
    ISU_AC_NAME: String(source.SOURCE_AC_NAME ?? source.ISU_AC_NAME ?? '').trim(),
    ISU_HD_VCH_NO: String(source.HD_VCH_NO ?? '').trim(),
    ISU_ADJ: 'N',
    HD_VCH_NO: headerVoucherNo,
    EMP_CODE: String(context.input.employeeCode ?? '').trim(),
    MAIN_USER: mainUser,
  }));
}

/** Create or edit a KRREP RECEIPT, retaining both desktop voucher identities on edit. */
export async function saveKarigarRepairReceipt(
  prisma: any,
  input: KarigarRepairReceiptInput,
): Promise<KarigarRepairReceiptResult> {
  assertCompleteRepairScope(input.scope);
  const scope = input.scope;
  const chequeAmount = repairNonNegative(input.chequeAmount, 'cheque amount');
  const cardAmount = repairNonNegative(input.cardAmount, 'card amount');
  const cashAmount = repairNonNegative(input.cashAmount, 'cash amount');
  const kasarAmount = repairNonNegative(input.kasarAmount, 'kasar amount');
  const discountPct = repairNonNegative(input.discountPct, 'discount percentage');
  if (chequeAmount && !String(input.chequeAccount ?? '').trim()) {
    throw new RepairWorkflowValidationError(
      'bank account is required when cheque amount is non-zero',
    );
  }
  if (cardAmount && !String(input.cardAccount ?? '').trim()) {
    throw new RepairWorkflowValidationError(
      'card account is required when card amount is non-zero',
    );
  }
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  if (Number.isNaN(vchDate.getTime())) {
    throw new RepairWorkflowValidationError('voucher date is invalid');
  }

  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_RECEIPT);
    const party = await resolveRepairWorkflowPartyTx(tx, scope, input.acCode, input.acName);
    const settings = await resolveCompanySettingsTx(tx, scope);
    const tax = await resolveReceiptTaxTx(tx, scope, input.taxCode);
    if (chequeAmount) {
      await assertRepairWorkflowAccountTx(tx, scope, String(input.chequeAccount), 'bank');
    }
    if (cardAmount) {
      await assertRepairWorkflowAccountTx(tx, scope, String(input.cardAccount), 'card');
    }
    const cashAccount = await resolveBookDetlAccountTx(tx, scope, policy, 1, 'cash/control');
    const partyTotalAccount = await resolveBookDetlAccountTx(tx, scope, policy, 2, 'party total');
    const labourAccount = await resolveBookDetlAccountTx(tx, scope, policy, 3, 'labour/other');
    const kasarAccount = kasarAmount
      ? await resolveBookDetlAccountTx(tx, scope, policy, 5, 'kasar')
      : '';

    const created = input.vchNo == null || String(input.vchNo).trim() === '';
    let voucherNo: string;
    let headerVoucherNo: string;
    if (created) {
      voucherNo = '';
      headerVoucherNo = '';
    } else {
      try {
        voucherNo = formatVoucherNo(input.vchNo as string | number);
      } catch {
        throw new RepairWorkflowValidationError(`invalid repair receipt voucher: ${input.vchNo}`);
      }
      const existing = await existingRepairHeaderTx(tx, scope, voucherNo);
      if (!existing) {
        throw new RepairWorkflowValidationError(`karigar repair receipt not found: ${voucherNo}`);
      }
      await assertRepairVoucherUnlinkedTx(tx, scope, voucherNo);
      await assertPeriodOpen(tx, scope.tenantId, {
        ledger: {
          table: 'AC_DATA',
          lines: [{ CO_CODE: scope.coCode, VCH_DATE: existing.VCH_DATE }],
        },
      });
      headerVoucherNo = String(existing.HD_VCH_NO ?? '').trim();
      if (!headerVoucherNo) {
        throw new RepairWorkflowValidationError(
          'existing repair receipt has no header voucher number',
        );
      }
      // Release the previous issue references before resolving the replacement set; any later
      // failure rolls the release back, so a rejected edit cannot reopen the source issue.
      await releaseReceiptSourcesTx(tx, scope, voucherNo);
    }

    const prepared = await prepareReceiptLinesTx(tx, scope, party.acCode, input.lines);
    const totals = repairBillTotals(
      prepared.map((line) => line.totals),
      {
        discountPct,
        taxPct: tax.taxPct,
        taxDigits: settings.taxDigits,
        chequeAmount,
        cardAmount,
        cashAmount,
        kasarAmount,
      },
    );
    const itemDebitTotal = round2(prepared.reduce((sum, line) => sum + line.totals.itemAmount, 0));
    const { legs: labourLegs } = karigarReceiptLabourOtherLegs({
      totalAmount: totals.totalAmount,
      itemDebitTotal,
      taxAmount: totals.taxAmount,
      rawLabourOther: prepared.map((line) =>
        round2(line.totals.labourAmount + line.totals.otherAmount),
      ),
    });

    if (created) {
      voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, scope));
      headerVoucherNo = await nextRepairHeaderVoucherNoTx(tx, scope);
    } else {
      await deleteRepairVoucherRowsTx(tx, scope, voucherNo!);
    }

    const key = repairVoucherKey(scope, voucherNo!);
    const mainUser = String(input.mainUser ?? '').trim() || null;
    const interState = party.gstType.toUpperCase() === 'I';
    const context: ReceiptLedgerContext = {
      key,
      input,
      policy,
      party,
      vchDate,
      headerVoucherNo: headerVoucherNo!,
      vchType: policy.vchType,
      dataType: policy.dataType,
      accounts: {
        cash: cashAccount,
        partyTotal: partyTotalAccount,
        labour: labourAccount,
        kasar: kasarAccount,
      },
      tax,
      settings,
      totals,
      prepared,
      labourLegs,
      tender: {
        cheque: chequeAmount,
        card: cardAmount,
        cash: cashAmount,
        kasar: kasarAmount,
      },
    };

    const header = {
      ...key,
      VCH_DATE: vchDate,
      BILL_NO: String(input.billNo ?? '').trim(),
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'C',
      VCH_TIME: vchDate,
      BOOK_NAME: policy.mainBook,
      AC_CODE: party.acCode,
      AC_NAME: party.acName,
      NET_AMT: totals.netAmount,
      DISC_PRC: discountPct,
      DISC_AMT: totals.discountAmount,
      TAX_CODE: tax.taxCode,
      TAX_PRC: tax.taxPct,
      TAX_AMT: totals.taxAmount,
      AC_GST_TYPE: party.gstType,
      IGST_TAX: interState ? totals.taxAmount : 0,
      CGST_TAX: interState ? 0 : round2(totals.taxAmount / 2),
      SGST_TAX: interState ? 0 : round2(totals.taxAmount / 2),
      // Desktop BILL_TOTAL rounds the voucher total but leaves the displayed round-off row blank,
      // so REP_DATA.ROF_AMT stays zero and the rounding delta is implicit in TOT_AMT.
      ROF_AMT: 0,
      TOT_AMT: totals.totalAmount,
      CASH_AMT: cashAmount,
      CHQ_AMT: chequeAmount,
      BANK_AC: chequeAmount ? String(input.chequeAccount).trim() : null,
      CHQ_NO: String(input.chequeNo ?? '').trim(),
      BANK_NAME: String(input.bankName ?? '').trim(),
      CARD_AMT: cardAmount,
      CARD_AC: cardAmount ? String(input.cardAccount).trim() : null,
      KASAR_AMT: kasarAmount,
      BILL_OS: totals.outstandingAmount,
      HD_VCH_NO: headerVoucherNo!,
      EMP_CODE: String(input.employeeCode ?? '').trim(),
      VCH_DESC: String(input.description ?? '').trim(),
      DATA_TRFR: 'N',
      MAIN_USER: mainUser,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    };

    const writes: Array<{ table: string; rows: Record<string, unknown>[] }> = [
      { table: 'REP_DATA', rows: [header] },
      { table: 'REP_DETL', rows: receiptDetailRows(context, mainUser) },
    ];
    if (created) {
      writes.unshift({
        table: 'TEMP_BOOK_DATA',
        rows: [
          {
            CO_CODE: scope.coCode,
            LC_CODE: scope.lcCode,
            CO_BOOK: scope.coBook,
            VCH_NO: headerVoucherNo!,
            BOOK_NAME: policy.mainBook,
          },
        ],
      });
    }
    const dailyRows = receiptRojRows(context);
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
      ledger: { table: 'AC_DATA', lines: receiptLedgerLines(context) },
      bookName: policy.mainBook,
      writes,
    });
    await markIssueSourcesReceivedTx(tx, scope, prepared);

    return {
      vchNo: Number(voucherNo!),
      voucherNo: voucherNo!,
      headerVoucherNo: headerVoucherNo!,
      created,
      totals,
    };
  });
}

function openLineFromRow(row: Record<string, unknown>): OpenKarigarRepairIssueLine {
  const coYear = String(row.CO_YEAR ?? '').trim();
  const coBook = String(row.CO_BOOK ?? '').trim();
  const voucherNo = String(row.VCH_NO ?? '').trim();
  const srNo = repairNumber(row.SR_NO);
  const karigarName = String(row.SOURCE_AC_NAME ?? '').trim();
  const customerName = String(row.REP_AC_NAME ?? '').trim();
  const itemName = String(row.IT_NAME ?? '').trim();
  return {
    code: `${coYear}/${coBook}/${voucherNo}/${srNo}`,
    name: [customerName, itemName].filter(Boolean).join(' · '),
    coYear,
    coBook,
    voucherNo,
    srNo,
    headerVoucherNo: String(row.HD_VCH_NO ?? '').trim(),
    vchDate: repairDateOnly(row.VCH_DATE),
    karigarCode: String(row.AC_CODE ?? '').trim(),
    karigarName,
    customerCode: String(row.REP_AC_CODE ?? '').trim(),
    customerName,
    customerRepairNo: String(row.REP_NO ?? '').trim(),
    itCode: String(row.IT_CODE ?? '').trim(),
    itemName,
    itType: String(row.IT_TYPE ?? '').trim(),
    rateType: String(row.RATE_TYPE ?? '').trim(),
    description: String(row.IT_DESC ?? '').trim(),
    itmSize: String(row.ITM_SIZE ?? '').trim(),
    tagNo: String(row.TAG_NO ?? '').trim(),
    vchSrNo: repairNumber(row.VCH_SRNO),
    pieces: repairNumber(row.ITM_PCS),
    grossWt: repairNumber(row.ITM_GWT),
    otherWt: repairNumber(row.ITM_OTH_WT),
    netWt: repairNumber(row.ITM_NWT),
    touch: repairNumber(row.ITM_TOUCH),
    wastagePct: repairNumber(row.ITM_WEST),
    fineWt: repairNumber(row.ITM_FINE),
  };
}

/** Open KRREP ISSUE rows for the selected karigar, in the current company/location, any year/book. */
export async function listOpenKarigarRepairIssueLines(
  prisma: any,
  scopeInput: VoucherScope,
  acCodeInput: string,
  queryInput = '',
  limitInput = 50,
): Promise<OpenKarigarRepairIssueLine[]> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  const acCode = String(acCodeInput ?? '').trim();
  if (!acCode) throw new RepairWorkflowValidationError('karigar account is required');
  const query = String(queryInput ?? '').trim();
  const limit = Math.min(200, Math.max(1, Math.trunc(Number(limitInput) || 50)));
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_RECEIPT);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT A.*, H."AC_NAME" AS "SOURCE_AC_NAME"
         FROM "REP_DETL" AS A
         JOIN "REP_DATA" AS H
           ON H.tenant_id=A.tenant_id AND H."CO_CODE"=A."CO_CODE" AND H."LC_CODE"=A."LC_CODE"
          AND H."CO_YEAR"=A."CO_YEAR" AND H."CO_BOOK"=A."CO_BOOK" AND H."VCH_NO"=A."VCH_NO"
        WHERE A.tenant_id=$1 AND A."CO_CODE"=$2 AND A."LC_CODE"=$3
          AND upper(btrim(coalesce(A."BOOK_NAME"::text,'')))=$4
          AND upper(coalesce(A."ISU_ADJ",'N'))='N'
          AND A."AC_CODE"=$5
          AND (btrim($6)='' OR A."VCH_NO"::text ILIKE '%'||$6||'%'
               OR A."REP_AC_NAME"::text ILIKE '%'||$6||'%' OR A."IT_NAME"::text ILIKE '%'||$6||'%')
        ORDER BY A."VCH_DATE",A."VCH_NO",A."SR_NO"
        LIMIT $7`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      KARIGAR_REPAIR_ISSUE_STAGE,
      acCode,
      query,
      limit,
    );
    return rows.map(openLineFromRow);
  });
}

function receiptView(
  header: Record<string, unknown>,
  rows: Array<Record<string, unknown>>,
): KarigarRepairReceiptView {
  return {
    voucherNo: String(header.VCH_NO ?? ''),
    headerVoucherNo: String(header.HD_VCH_NO ?? ''),
    vchDate: repairDateOnly(header.VCH_DATE),
    billNo: String(header.BILL_NO ?? ''),
    acCode: String(header.AC_CODE ?? ''),
    acName: String(header.AC_NAME ?? ''),
    employeeCode: String(header.EMP_CODE ?? ''),
    bankName: String(header.BANK_NAME ?? ''),
    description: String(header.VCH_DESC ?? ''),
    discountPct: repairNumber(header.DISC_PRC),
    taxCode: String(header.TAX_CODE ?? ''),
    taxPct: repairNumber(header.TAX_PRC),
    chequeAmount: repairNumber(header.CHQ_AMT),
    chequeAccount: String(header.BANK_AC ?? ''),
    chequeNo: String(header.CHQ_NO ?? ''),
    cardAmount: repairNumber(header.CARD_AMT),
    cardAccount: String(header.CARD_AC ?? ''),
    cashAmount: repairNumber(header.CASH_AMT),
    kasarAmount: repairNumber(header.KASAR_AMT),
    totals: {
      netAmount: repairNumber(header.NET_AMT),
      discountAmount: repairNumber(header.DISC_AMT),
      taxAmount: repairNumber(header.TAX_AMT),
      totalAmount: repairNumber(header.TOT_AMT),
      outstandingAmount: repairNumber(header.BILL_OS),
    },
    lines: rows.map((row) => ({
      ...openLineFromRow({
        ...row,
        CO_YEAR: row.ISU_YRCD,
        CO_BOOK: row.ISU_DBCD,
        VCH_NO: row.ISU_NO,
        SR_NO: row.ISU_SRNO,
        HD_VCH_NO: row.ISU_HD_VCH_NO,
        AC_CODE: row.ISU_AC_CODE,
        SOURCE_AC_NAME: row.ISU_AC_NAME,
        VCH_DATE: row.SOURCE_VCH_DATE ?? row.VCH_DATE,
      }),
      receiptSrNo: repairNumber(row.SR_NO),
      addWt: repairNumber(row.ADD_WT),
      lessWt: repairNumber(row.LESS_WT),
      lessTouch: repairNumber(row.LESS_TOUCH),
      lessFine: repairNumber(row.LESS_FINE),
      rate: repairNumber(row.ITM_RATE),
      itemAmount: repairNumber(row.ITM_AMT),
      labourType: String(row.LBR_TYPE ?? ''),
      labourRate: repairNumber(row.LBR_RATE),
      labourAmount: repairNumber(row.LBR_AMT),
      otherAmount: repairNumber(row.OTH_AMT),
      netAmount: repairNumber(row.NET_AMT),
    })),
  };
}

export async function getKarigarRepairReceipt(
  prisma: any,
  scopeInput: VoucherScope,
  vchNo: string | number,
): Promise<KarigarRepairReceiptView | null> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(vchNo);
  } catch {
    throw new RepairWorkflowValidationError(`invalid repair receipt voucher: ${vchNo}`);
  }
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_RECEIPT);
    const header = await existingRepairHeaderTx(tx, scope, voucherNo);
    if (!header) return null;
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT RECEIPT.*, SOURCE."VCH_DATE" AS "SOURCE_VCH_DATE"
         FROM "REP_DETL" AS RECEIPT
         LEFT JOIN "REP_DETL" AS SOURCE
           ON SOURCE.tenant_id=RECEIPT.tenant_id AND SOURCE."CO_CODE"=RECEIPT."CO_CODE"
          AND SOURCE."LC_CODE"=RECEIPT."ISU_LC" AND SOURCE."CO_YEAR"=RECEIPT."ISU_YRCD"
          AND SOURCE."CO_BOOK"=RECEIPT."ISU_DBCD" AND SOURCE."VCH_NO"=RECEIPT."ISU_NO"
          AND SOURCE."SR_NO"::numeric=RECEIPT."ISU_SRNO"::numeric
        WHERE RECEIPT.tenant_id=$1 AND RECEIPT."CO_CODE"=$2 AND RECEIPT."LC_CODE"=$3
          AND RECEIPT."CO_YEAR"=$4 AND RECEIPT."CO_BOOK"=$5 AND RECEIPT."VCH_NO"=$6
        ORDER BY RECEIPT."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    return receiptView(header, rows);
  });
}

export async function listKarigarRepairReceipts(
  prisma: any,
  scopeInput: VoucherScope,
  limitInput = 50,
): Promise<
  Array<{ voucherNo: string; vchDate: string; acCode: string; acName: string; description: string }>
> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  const limit = Math.min(200, Math.max(1, Math.trunc(Number(limitInput) || 50)));
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_RECEIPT);
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
      vchDate: repairDateOnly(row.VCH_DATE),
      acCode: String(row.AC_CODE ?? ''),
      acName: String(row.AC_NAME ?? ''),
      description: String(row.VCH_DESC ?? ''),
    }));
  });
}

export async function deleteKarigarRepairReceipt(
  prisma: any,
  input: { scope: VoucherScope; vchNo: string | number; deleteUser?: string },
): Promise<{ reversed: true }> {
  assertCompleteRepairScope(input.scope);
  const scope = input.scope;
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(input.vchNo);
  } catch {
    throw new RepairWorkflowValidationError(`invalid repair receipt voucher: ${input.vchNo}`);
  }
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_RECEIPT);
    const existing = await existingRepairHeaderTx(tx, scope, voucherNo);
    if (!existing) {
      throw new RepairWorkflowValidationError(`karigar repair receipt not found: ${voucherNo}`);
    }
    await assertRepairVoucherUnlinkedTx(tx, scope, voucherNo);
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: existing.VCH_DATE }] },
    });
    const headerVoucherNo = String(existing.HD_VCH_NO ?? '').trim();
    await releaseReceiptSourcesTx(tx, scope, voucherNo);
    await deleteRepairVoucherRowsTx(tx, scope, voucherNo);
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
      ...repairVoucherKey(scope, voucherNo),
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
