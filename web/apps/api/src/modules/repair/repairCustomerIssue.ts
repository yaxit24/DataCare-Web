import { withTenant } from '@datacare/db';
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
import { karigarReceiptLabourOtherLegs } from './repairKarigarReceipt.js';
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
 * Fourth and final stage of desktop TR_REP_REC: CUSTREP ISSUE — the repaired item delivered back to
 * the customer and billed. Desktop offers two source kinds for the selected customer:
 *   1. an open CUSTREP RECEIPT row (REP_ADJ='N' and ISU_ADJ='N') delivered without a karigar leg, and
 *   2. an open KRREP RECEIPT row (ISU_ADJ='N') whose propagated REP_* customer link matches.
 * Both are addressed by the CUSTREP RECEIPT identity; when a karigar receipt exists it supplies
 * ADD_WT/LESS_WT/LESS_TOUCH/LESS_FINE plus labour/other defaults and becomes the ISU_* linkage.
 *
 * Ledger and Rojmel rows come from the same desktop functions as KRREP RECEIPT
 * (Rep_KrRec_CustIsu_Ledr / Rep_KrRec_CustIsu_Rojmel) with mirrored monetary direction and the
 * item leg posted to GROUP_MAST.SALE_AC instead of PURC_AC.
 */
export const CUSTOMER_REPAIR_ISSUE = 'CUSTREP ISSUE';
export const CUSTOMER_REPAIR_RECEIPT_SOURCE = 'CUSTREP RECEIPT';
export const KARIGAR_REPAIR_RECEIPT_SOURCE = 'KRREP RECEIPT';

export interface CustomerRepairIssueSourceReference {
  /** Fiscal year, book, voucher and serial of the customer's original CUSTREP RECEIPT row. */
  coYear: string;
  coBook: string;
  voucherNo: string | number;
  srNo: number;
}

export interface CustomerRepairIssueLineInput extends CustomerRepairIssueSourceReference {
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
  /** Desktop keeps LBR_AMT directly editable on this stage and prefills it from the source row. */
  labourAmount?: number;
  otherAmount?: number;
}

export interface CustomerRepairIssueInput {
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
  lines: CustomerRepairIssueLineInput[];
}

export interface CustomerRepairIssueResult {
  vchNo: number;
  voucherNo: string;
  headerVoucherNo: string;
  created: boolean;
  totals: RepairBillTotals;
}

export interface OpenCustomerRepairDeliveryLine {
  code: string;
  name: string;
  /** Customer receipt identity used as the row key. */
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  headerVoucherNo: string;
  vchDate: string;
  customerCode: string;
  customerName: string;
  /** Karigar receipt linkage when the item went through a karigar. */
  karigarReceiptNo: string;
  karigarReceiptSrNo: number;
  karigarCode: string;
  karigarName: string;
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
  addWt: number;
  lessWt: number;
  lessTouch: number;
  lessFine: number;
  rate: number;
  labourAmount: number;
  otherAmount: number;
}

export interface CustomerRepairIssueLineView extends OpenCustomerRepairDeliveryLine {
  issueSrNo: number;
  itemAmount: number;
  labourType: string;
  labourRate: number;
  netAmount: number;
}

export interface CustomerRepairIssueView {
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
  lines: CustomerRepairIssueLineView[];
}

interface NormalizedIssueReference {
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  ordinal: number;
}

interface PreparedIssueLine {
  ref: NormalizedIssueReference;
  /** The open CUSTREP RECEIPT row. */
  receipt: Record<string, unknown>;
  /** The linked open KRREP RECEIPT row, when the item passed through a karigar. */
  karigarReceipt: Record<string, unknown> | null;
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
  item: {
    itCode: string;
    itemName: string;
    itType: string;
    rateType: string;
    accounts: ItemAccounts;
  };
  totals: RepairLineTotals;
}

interface ItemAccounts {
  saleAc: string;
  purcAc: string;
}

interface IssueTaxPolicy {
  taxCode: string | null;
  taxPct: number;
  taxAccount: string | null;
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

function normalizedIssueReferences(
  lines: CustomerRepairIssueLineInput[],
): NormalizedIssueReference[] {
  if (!Array.isArray(lines) || !lines.length) {
    throw new RepairWorkflowValidationError('at least one open customer repair row is required');
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
        'source repair serial number must be a positive integer',
      );
    }
    let voucherNo: string;
    try {
      voucherNo = formatVoucherNo(line.voucherNo);
    } catch {
      throw new RepairWorkflowValidationError(`invalid source repair voucher: ${line.voucherNo}`);
    }
    const key = `${coYear}|${coBook}|${voucherNo}|${srNo}`;
    if (seen.has(key))
      throw new RepairWorkflowValidationError(`duplicate source repair row: ${key}`);
    seen.add(key);
    return { coYear, coBook, voucherNo, srNo, ordinal };
  });
}

function rowKey(row: Record<string, unknown>): string {
  return `${String(row.CO_YEAR ?? '').trim()}|${String(row.CO_BOOK ?? '').trim()}|${String(
    row.VCH_NO ?? '',
  ).trim()}|${repairNumber(row.SR_NO)}`;
}

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

async function resolveTaxDigitsTx(tx: any, scope: VoucherScope): Promise<number> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT DISTINCT btrim(coalesce("TAX_ROF"::text,'')) AS tax_rof
       FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text`,
    scope.tenantId,
    scope.coCode,
  );
  if (rows.length > 1) {
    throw new RepairWorkflowValidationError(
      `company ${scope.coCode} has conflicting CO_SET.TAX_ROF settings`,
    );
  }
  const raw = String(rows[0]?.tax_rof ?? '').trim();
  if (!raw) return 0;
  const parsed = Number(raw);
  if (!Number.isFinite(parsed)) {
    throw new RepairWorkflowValidationError(`CO_SET.TAX_ROF is not numeric: ${raw}`);
  }
  const digits = Math.round(parsed);
  if (digits < 0 || digits > 4) {
    throw new RepairWorkflowValidationError(`CO_SET.TAX_ROF is out of range: ${raw}`);
  }
  return digits;
}

async function resolveIssueTaxTx(
  tx: any,
  scope: VoucherScope,
  taxCodeInput: string | undefined,
): Promise<IssueTaxPolicy> {
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

/** CUSTREP ISSUE posts the item leg to GROUP_MAST.SALE_AC; the fine legs still reference PURC_AC. */
async function resolveItemAccountsTx(
  tx: any,
  scope: VoucherScope,
  itCodes: string[],
): Promise<Map<string, PreparedIssueLine['item']>> {
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
    throw new RepairWorkflowValidationError(
      `item not found: ${codes.filter((code) => !found.has(code)).join(', ')}`,
    );
  }
  const groupCodes = [
    ...new Set(items.map((row) => String(row.gr_code ?? '').trim()).filter(Boolean)),
  ];
  const groups: Array<Record<string, unknown>> = groupCodes.length
    ? await tx.$queryRawUnsafe(
        `SELECT "GR_CODE",btrim(coalesce("SALE_AC"::text,'')) AS sale_ac,
                btrim(coalesce("PURC_AC"::text,'')) AS purc_ac
           FROM "GROUP_MAST"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=ANY($3::text[])`,
        scope.tenantId,
        scope.coCode,
        groupCodes,
      )
    : [];
  const accounts = new Map<string, ItemAccounts>();
  for (const row of groups) {
    const grCode = String(row.GR_CODE ?? '').trim();
    if (accounts.has(grCode)) {
      throw new RepairWorkflowValidationError(`item group is ambiguous: ${grCode}`);
    }
    accounts.set(grCode, {
      saleAc: String(row.sale_ac ?? '').trim(),
      purcAc: String(row.purc_ac ?? '').trim(),
    });
  }
  const resolved = new Map<string, PreparedIssueLine['item']>();
  for (const row of items) {
    const itCode = String(row.IT_CODE ?? '').trim();
    const grCode = String(row.gr_code ?? '').trim();
    if (!grCode) throw new RepairWorkflowValidationError(`item ${itCode} has no item group`);
    const group = accounts.get(grCode);
    if (!group) throw new RepairWorkflowValidationError(`item group not found: ${grCode}`);
    if (!group.saleAc) {
      throw new RepairWorkflowValidationError(`item group ${grCode} has no SALE_AC account`);
    }
    if (!group.purcAc) {
      throw new RepairWorkflowValidationError(`item group ${grCode} has no PURC_AC account`);
    }
    await assertRepairWorkflowAccountTx(tx, scope, group.saleAc, `item group ${grCode} sale`);
    await assertRepairWorkflowAccountTx(tx, scope, group.purcAc, `item group ${grCode} purchase`);
    resolved.set(itCode, {
      itCode,
      itemName: String(row.IT_NAME ?? '').trim(),
      itType: String(row.IT_TYPE ?? '').trim(),
      rateType: String(row.RATE_TYPE ?? '').trim(),
      accounts: group,
    });
  }
  return resolved;
}

async function prepareIssueLinesTx(
  tx: any,
  scope: VoucherScope,
  customerAcCode: string,
  inputLines: CustomerRepairIssueLineInput[],
): Promise<PreparedIssueLine[]> {
  const refs = normalizedIssueReferences(inputLines);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT A.*, H."AC_NAME" AS "SOURCE_AC_NAME", H."VCH_NO" AS "SOURCE_HEADER_EXISTS"
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
  const byKey = new Map(rows.map((row) => [rowKey(row), row]));
  if (rows.length !== refs.length || byKey.size !== refs.length) {
    throw new RepairWorkflowValidationError('one or more customer repair source rows do not exist');
  }

  // Lock the karigar-receipt rows that reference these customer receipts, if any.
  const karigarRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT K.*
       FROM jsonb_to_recordset($4::jsonb)
              AS R("coYear" text,"coBook" text,"voucherNo" text,"srNo" numeric,ordinal int)
       JOIN "REP_DETL" AS K
         ON K.tenant_id=$1 AND K."CO_CODE"=$2 AND K."LC_CODE"=$3
        AND K."REP_YRCD"=R."coYear" AND K."REP_DBCD"=R."coBook"
        AND K."REP_NO"=R."voucherNo" AND K."REP_SRNO"::numeric=R."srNo"
        AND upper(btrim(coalesce(K."BOOK_NAME"::text,'')))=$5
      ORDER BY K."CO_YEAR",K."CO_BOOK",K."VCH_NO",K."SR_NO"
      FOR UPDATE OF K`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    JSON.stringify(refs),
    KARIGAR_REPAIR_RECEIPT_SOURCE,
  );
  const karigarByReceipt = new Map<string, Record<string, unknown>>();
  for (const row of karigarRows) {
    const key = `${String(row.REP_YRCD ?? '').trim()}|${String(row.REP_DBCD ?? '').trim()}|${String(
      row.REP_NO ?? '',
    ).trim()}|${repairNumber(row.REP_SRNO)}`;
    if (karigarByReceipt.has(key)) {
      throw new RepairWorkflowValidationError(
        `customer repair row ${key} has more than one karigar receipt`,
      );
    }
    karigarByReceipt.set(key, row);
  }

  const matched = refs.map((ref) => {
    const key = `${ref.coYear}|${ref.coBook}|${ref.voucherNo}|${ref.srNo}`;
    const receipt = byKey.get(key);
    if (!receipt) throw new RepairWorkflowValidationError(`customer repair not found: ${key}`);
    if (!receipt.SOURCE_HEADER_EXISTS) {
      throw new RepairWorkflowValidationError(`customer repair header is missing: ${key}`);
    }
    if (
      String(receipt.BOOK_NAME ?? '')
        .trim()
        .toUpperCase() !== CUSTOMER_REPAIR_RECEIPT_SOURCE
    ) {
      throw new RepairWorkflowValidationError(`source row ${key} is not a customer repair receipt`);
    }
    if (String(receipt.AC_CODE ?? '').trim() !== customerAcCode) {
      throw new RepairWorkflowValidationError(`customer repair ${key} belongs to another customer`);
    }
    if (
      String(receipt.REP_ADJ ?? 'N')
        .trim()
        .toUpperCase() !== 'N'
    ) {
      throw new RepairWorkflowValidationError(`customer repair is already delivered: ${key}`);
    }
    if (!String(receipt.IT_CODE ?? '').trim()) {
      throw new RepairWorkflowValidationError(`customer repair has no item: ${key}`);
    }
    const karigarReceipt = karigarByReceipt.get(key) ?? null;
    if (karigarReceipt) {
      if (
        String(karigarReceipt.ISU_ADJ ?? 'N')
          .trim()
          .toUpperCase() !== 'N'
      ) {
        throw new RepairWorkflowValidationError(
          `karigar repair receipt for ${key} is already delivered`,
        );
      }
    } else if (
      String(receipt.ISU_ADJ ?? 'N')
        .trim()
        .toUpperCase() !== 'N'
    ) {
      // No karigar leg exists, so the customer receipt itself must still be open.
      throw new RepairWorkflowValidationError(`customer repair is already issued: ${key}`);
    }
    return { ref, receipt, karigarReceipt };
  });

  const items = await resolveItemAccountsTx(
    tx,
    scope,
    matched.map(({ receipt }) => String(receipt.IT_CODE ?? '').trim()),
  );

  const prepared: PreparedIssueLine[] = [];
  for (const { ref, receipt, karigarReceipt } of matched) {
    const input = inputLines[ref.ordinal] as CustomerRepairIssueLineInput;
    const item = items.get(String(receipt.IT_CODE ?? '').trim());
    if (!item) {
      throw new RepairWorkflowValidationError(
        `item not resolved: ${String(receipt.IT_CODE ?? '')}`,
      );
    }
    // Desktop loads the customer receipt row, then overlays the karigar receipt weights and
    // labour/other defaults when a karigar receipt exists.
    const weightSource = karigarReceipt ?? receipt;
    const values = {
      description: optionalText(input.description, String(receipt.IT_DESC ?? '').trim()),
      itmSize: optionalText(input.itmSize, String(receipt.ITM_SIZE ?? '').trim()),
      pcs: optionalNumber(input.pcs, repairNumber(receipt.ITM_PCS), 'pieces'),
      grossWt: optionalNumber(input.grossWt, repairNumber(receipt.ITM_GWT), 'gross weight'),
      otherWt: optionalNumber(input.otherWt, repairNumber(receipt.ITM_OTH_WT), 'other weight'),
      addWt: optionalNumber(input.addWt, repairNumber(weightSource.ADD_WT), 'add weight'),
      lessWt: optionalNumber(input.lessWt, repairNumber(weightSource.LESS_WT), 'less weight'),
      lessTouch: optionalNumber(
        input.lessTouch,
        karigarReceipt ? repairNumber(karigarReceipt.LESS_TOUCH) : 0,
        'less touch',
      ),
      touch: optionalNumber(input.touch, repairNumber(receipt.ITM_TOUCH), 'touch'),
      wastagePct: optionalNumber(input.wastagePct, repairNumber(receipt.ITM_WEST), 'wastage'),
      rate: optionalNumber(input.rate, repairNumber(receipt.ITM_RATE), 'rate'),
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
        otherAmount: optionalNumber(
          input.otherAmount,
          repairNumber(weightSource.OTH_AMT),
          'other amount',
        ),
      },
      CUSTOMER_REPAIR_ISSUE,
    );
    // Desktop keeps the CUSTREP ISSUE labour amount directly editable and prefills it from the
    // karigar receipt (or the customer receipt), recomputing it only when a labour rate is entered.
    const carriedLabour = optionalNumber(
      input.labourAmount,
      repairNumber(weightSource.LBR_AMT),
      'labour amount',
    );
    const effective =
      values.labourRate === 0 && carriedLabour !== 0
        ? {
            ...totals,
            labourAmount: round2(carriedLabour),
            netAmount: round2(totals.itemAmount + carriedLabour + totals.otherAmount),
          }
        : totals;
    if (effective.netWt + effective.netAmount === 0) continue;
    prepared.push({ ref, receipt, karigarReceipt, values, item, totals: effective });
  }
  if (!prepared.length) {
    throw new RepairWorkflowValidationError(
      'no customer repair issue row has a net weight or net amount',
    );
  }
  return prepared;
}

/**
 * Desktop marks the customer receipt REP_ADJ='Y' and ISU_ADJ='Y', and marks the linked karigar
 * receipt ISU_ADJ='Y'.
 */
async function markIssueSourcesDeliveredTx(
  tx: any,
  scope: VoucherScope,
  prepared: PreparedIssueLine[],
): Promise<void> {
  const receipts = prepared.map(({ ref }) => ({
    coYear: ref.coYear,
    coBook: ref.coBook,
    voucherNo: ref.voucherNo,
    srNo: ref.srNo,
  }));
  const receiptChanged = await tx.$executeRawUnsafe(
    `UPDATE "REP_DETL" AS A SET "REP_ADJ"='Y',"ISU_ADJ"='Y'
       FROM jsonb_to_recordset($4::jsonb)
              AS R("coYear" text,"coBook" text,"voucherNo" text,"srNo" numeric)
      WHERE A.tenant_id=$1 AND A."CO_CODE"=$2 AND A."LC_CODE"=$3
        AND A."CO_YEAR"=R."coYear" AND A."CO_BOOK"=R."coBook"
        AND A."VCH_NO"=R."voucherNo" AND A."SR_NO"::numeric=R."srNo"
        AND upper(coalesce(A."REP_ADJ",'N'))='N'`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    JSON.stringify(receipts),
  );
  if (Number(receiptChanged) !== receipts.length) {
    throw new RepairWorkflowValidationError('customer repair linkage changed concurrently');
  }
  const karigarRows = prepared
    .filter(({ karigarReceipt }) => karigarReceipt)
    .map(({ karigarReceipt }) => ({
      coYear: String(karigarReceipt!.CO_YEAR ?? '').trim(),
      coBook: String(karigarReceipt!.CO_BOOK ?? '').trim(),
      voucherNo: String(karigarReceipt!.VCH_NO ?? '').trim(),
      srNo: repairNumber(karigarReceipt!.SR_NO),
    }));
  if (!karigarRows.length) return;
  const karigarChanged = await tx.$executeRawUnsafe(
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
    JSON.stringify(karigarRows),
  );
  if (Number(karigarChanged) !== karigarRows.length) {
    throw new RepairWorkflowValidationError('karigar repair receipt linkage changed concurrently');
  }
}

/**
 * Desktop delete releases ISU_ADJ on the ISU_* target and only REP_ADJ on the REP_* target, which
 * leaves a delivered customer receipt permanently flagged ISU_ADJ='Y' and therefore invisible to the
 * earlier stages. The web release resets both flags on the customer receipt so a reversed delivery
 * fully reopens the repair; this is a deliberate correction of a desktop release asymmetry.
 */
async function releaseIssueSourcesTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<void> {
  const args = [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
  await tx.$executeRawUnsafe(
    `UPDATE "REP_DETL" AS SOURCE SET "ISU_ADJ"='N'
       FROM "REP_DETL" AS ISSUE
      WHERE SOURCE.tenant_id=ISSUE.tenant_id AND SOURCE."CO_CODE"=ISSUE."CO_CODE"
        AND SOURCE."LC_CODE"=ISSUE."ISU_LC" AND SOURCE."CO_YEAR"=ISSUE."ISU_YRCD"
        AND SOURCE."CO_BOOK"=ISSUE."ISU_DBCD" AND SOURCE."VCH_NO"=ISSUE."ISU_NO"
        AND SOURCE."SR_NO"::numeric=ISSUE."ISU_SRNO"::numeric
        AND ISSUE.tenant_id=$1 AND ISSUE."CO_CODE"=$2 AND ISSUE."LC_CODE"=$3
        AND ISSUE."CO_YEAR"=$4 AND ISSUE."CO_BOOK"=$5 AND ISSUE."VCH_NO"=$6`,
    ...args,
  );
  await tx.$executeRawUnsafe(
    `UPDATE "REP_DETL" AS SOURCE SET "REP_ADJ"='N',"ISU_ADJ"='N'
       FROM "REP_DETL" AS ISSUE
      WHERE SOURCE.tenant_id=ISSUE.tenant_id AND SOURCE."CO_CODE"=ISSUE."CO_CODE"
        AND SOURCE."LC_CODE"=ISSUE."REP_LC" AND SOURCE."CO_YEAR"=ISSUE."REP_YRCD"
        AND SOURCE."CO_BOOK"=ISSUE."REP_DBCD" AND SOURCE."VCH_NO"=ISSUE."REP_NO"
        AND SOURCE."SR_NO"::numeric=ISSUE."REP_SRNO"::numeric
        AND upper(btrim(coalesce(SOURCE."BOOK_NAME"::text,'')))=$7
        AND ISSUE.tenant_id=$1 AND ISSUE."CO_CODE"=$2 AND ISSUE."LC_CODE"=$3
        AND ISSUE."CO_YEAR"=$4 AND ISSUE."CO_BOOK"=$5 AND ISSUE."VCH_NO"=$6`,
    ...args,
    CUSTOMER_REPAIR_RECEIPT_SOURCE,
  );
}

interface IssueLedgerContext {
  key: Record<string, string>;
  input: CustomerRepairIssueInput;
  policy: RepairWorkflowBookPolicy;
  party: RepairWorkflowParty;
  vchDate: Date;
  headerVoucherNo: string;
  accounts: { cash: string; partyTotal: string; labour: string; kasar: string };
  tax: IssueTaxPolicy;
  totals: RepairBillTotals;
  prepared: PreparedIssueLine[];
  labourLegs: number[];
  tender: { cheque: number; card: number; cash: number; kasar: number };
}

function issueLedgerLines(context: IssueLedgerContext): LedgerLine[] {
  const { key, input, policy, party, vchDate, headerVoucherNo, totals, prepared } = context;
  const ledgerKey = (srNo: number, tag: string): string =>
    `${key.CO_CODE}${key.LC_CODE}${key.CO_YEAR}${key.CO_BOOK}${key.VCH_NO}${pad2(srNo)}${tag}`;
  const base = {
    ...key,
    VCH_TYPE: policy.vchType,
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
    DATA_TYPE: policy.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: String(input.mainUser ?? '').trim() || null,
    FINE_RATE: 0,
    PARTY_AC_CODE: party.acCode,
    LDR_NAME: '',
  };
  const lines: LedgerLine[] = [];

  // CUSTREP ISSUE is the mirror of KRREP RECEIPT: the customer is debited the voucher total and the
  // item/labour/tax legs are credited.
  if (totals.totalAmount) {
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, '01'),
      AC_CODE: party.acCode,
      LD_CODE: context.accounts.partyTotal,
      CR_AMT: 0,
      DR_AMT: totals.totalAmount,
    });
  }
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    if (line.totals.itemAmount) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '02'),
        AC_CODE: line.item.accounts.saleAc,
        LD_CODE: party.acCode,
        CR_AMT: line.totals.itemAmount,
        DR_AMT: 0,
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
        CR_AMT: labour,
        DR_AMT: 0,
      });
    }
  });
  if (totals.taxAmount && context.tax.taxAccount) {
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, '04'),
      AC_CODE: context.tax.taxAccount,
      LD_CODE: party.acCode,
      CR_AMT: totals.taxAmount,
      DR_AMT: 0,
    });
  }
  const addTenderPair = (amount: number, contra: string, creditTag: string, debitTag: string) => {
    if (!amount) return;
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, creditTag),
      AC_CODE: party.acCode,
      LD_CODE: contra,
      CR_AMT: amount,
      DR_AMT: 0,
    });
    lines.push({
      ...base,
      LEDR_KEY: ledgerKey(0, debitTag),
      AC_CODE: contra,
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: amount,
      PARTY_AC_CODE: '',
    });
  };
  addTenderPair(context.tender.cheque, String(input.chequeAccount ?? '').trim(), '05', '06');
  addTenderPair(context.tender.card, String(input.cardAccount ?? '').trim(), '07', '08');
  addTenderPair(context.tender.cash, context.accounts.cash, '09', '10');
  addTenderPair(context.tender.kasar, context.accounts.kasar, '11', '12');

  // CUSTREP ISSUE metal legs: suffix 16 removes the delivered fine weight, suffix 17 adds the less
  // fine back. Both are zero-money and desktop restricts them to an outward-configured book.
  const fineLegs = policy.inout === 'O';
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    if (!fineLegs) return;
    if (line.totals.itemAmount === 0 && line.totals.fineWt) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '16'),
        AC_CODE: party.acCode,
        LD_CODE: line.item.accounts.purcAc,
        CR_AMT: 0,
        DR_AMT: 0,
        IT_TYPE: line.item.itType || 'A',
        SIGN: '-',
        FINE_WT: line.totals.fineWt,
      });
    }
    if (line.totals.lessFine && line.values.lessTouch) {
      lines.push({
        ...base,
        LEDR_KEY: ledgerKey(srNo, '17'),
        AC_CODE: party.acCode,
        LD_CODE: line.item.accounts.purcAc,
        CR_AMT: 0,
        DR_AMT: 0,
        IT_TYPE: line.item.itType || 'A',
        SIGN: '+',
        FINE_WT: line.totals.lessFine,
      });
    }
  });
  return lines;
}

function issueRojRows(context: IssueLedgerContext): Record<string, unknown>[] {
  const { key, input, policy, party, vchDate, totals, prepared } = context;
  const ledgerKey = (srNo: number, tag: string): string =>
    `${key.CO_CODE}${key.LC_CODE}${key.CO_YEAR}${key.CO_BOOK}${key.VCH_NO}${pad2(srNo)}${tag}`;
  const common = {
    ...key,
    VCH_DATE: vchDate,
    VCH_TYPE: policy.vchType,
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
    DATA_TYPE: policy.dataType,
    AC_NAME: '',
  };
  const rows: Record<string, unknown>[] = [];
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    if (line.totals.netAmount !== 0) {
      rows.push({
        ...common,
        LEDR_KEY: ledgerKey(srNo, '01'),
        AC_CODE: line.item.accounts.saleAc,
        LD_CODE: party.acCode,
        CR_AMT: line.totals.itemAmount,
        DR_AMT: 0,
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
        CR_AMT: labour,
        DR_AMT: 0,
        IT_CODE: line.item.itCode,
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
      CR_AMT: totals.taxAmount,
      DR_AMT: 0,
    });
  }
  if (totals.outstandingAmount) {
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '04'),
      AC_CODE: party.acCode,
      LD_CODE: context.accounts.cash,
      CR_AMT: 0,
      DR_AMT: totals.outstandingAmount,
      AC_NAME: party.acName,
    });
  }
  if (context.tender.cheque) {
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '05'),
      AC_CODE: String(input.chequeAccount ?? '').trim(),
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: context.tender.cheque,
    });
  }
  if (context.tender.card) {
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '06'),
      AC_CODE: String(input.cardAccount ?? '').trim(),
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: context.tender.card,
    });
  }
  if (context.tender.kasar) {
    // Same desktop asymmetry as KRREP RECEIPT: Rojmel kasar uses BOOK_DETL row 3 while AC_DATA uses
    // row 5, and there is no Rojmel cash row for this stage.
    rows.push({
      ...common,
      LEDR_KEY: ledgerKey(0, '07'),
      AC_CODE: context.accounts.labour,
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: context.tender.kasar,
      AC_NAME: `KSR - ${party.acName}`,
    });
  }
  prepared.forEach((line, index) => {
    const srNo = index + 1;
    const metal = {
      AC_CODE: party.acCode,
      LD_CODE: line.item.accounts.purcAc,
      CR_AMT: 0,
      DR_AMT: 0,
      AC_NAME: party.acName,
      IT_TYPE: line.item.itType || 'A',
      IT_CODE: line.item.itCode,
      IT_DESC: line.item.itemName,
    };
    if (line.totals.itemAmount === 0 && line.totals.fineWt) {
      rows.push({
        ...common,
        ...metal,
        LEDR_KEY: ledgerKey(srNo, '10'),
        SIGN: '-',
        ITM_GWT: line.values.addWt,
        ITM_NWT: line.values.addWt,
        ITM_TOUCH: line.values.touch,
        ITM_WEST: line.values.wastagePct,
        ITM_FINE: line.totals.fineWt,
      });
    }
    if (line.totals.lessFine && line.values.lessTouch) {
      // Desktop reuses the '10' key prefix for this second metal row, which would collide with the
      // row above for the same serial. The web uses a distinct '11' tag so both rows can persist.
      rows.push({
        ...common,
        ...metal,
        LEDR_KEY: ledgerKey(srNo, '11'),
        SIGN: '-',
        ITM_GWT: line.values.lessWt,
        ITM_NWT: line.values.lessWt,
        ITM_TOUCH: line.values.lessTouch,
        ITM_FINE: line.totals.lessFine,
      });
    }
  });
  return rows;
}

function issueDetailRows(
  context: IssueLedgerContext,
  mainUser: string | null,
): Record<string, unknown>[] {
  const { key, policy, party, vchDate, headerVoucherNo, prepared } = context;
  return prepared.map(({ receipt, karigarReceipt, values, item, totals }, index) => ({
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
    TAG_NO: String(receipt.TAG_NO ?? '').trim() || null,
    DESIGN_NO: String(receipt.DESIGN_NO ?? '').trim(),
    VCH_SRNO: repairNumber(receipt.VCH_SRNO),
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
    // REP_* always points at the customer's own CUSTREP RECEIPT row.
    REP_NO: String(receipt.VCH_NO ?? '').trim(),
    REP_SRNO: repairNumber(receipt.SR_NO),
    REP_LC: String(receipt.LC_CODE ?? '').trim(),
    REP_YRCD: String(receipt.CO_YEAR ?? '').trim(),
    REP_DBCD: String(receipt.CO_BOOK ?? '').trim(),
    REP_AC_CODE: String(receipt.AC_CODE ?? '').trim(),
    REP_AC_NAME: String(receipt.SOURCE_AC_NAME ?? receipt.REP_AC_NAME ?? '').trim(),
    REP_HD_VCH_NO: String(receipt.HD_VCH_NO ?? '').trim(),
    REP_ADJ: 'N',
    // ISU_* points at the karigar receipt when the item passed through a karigar.
    ISU_NO: karigarReceipt ? String(karigarReceipt.VCH_NO ?? '').trim() : '',
    ISU_SRNO: karigarReceipt ? repairNumber(karigarReceipt.SR_NO) : 0,
    ISU_LC: karigarReceipt ? String(karigarReceipt.LC_CODE ?? '').trim() : '',
    ISU_YRCD: karigarReceipt ? String(karigarReceipt.CO_YEAR ?? '').trim() : '',
    ISU_DBCD: karigarReceipt ? String(karigarReceipt.CO_BOOK ?? '').trim() : '',
    ISU_AC_CODE: karigarReceipt ? String(karigarReceipt.AC_CODE ?? '').trim() : '',
    ISU_AC_NAME: karigarReceipt ? String(karigarReceipt.ISU_AC_NAME ?? '').trim() : '',
    ISU_HD_VCH_NO: karigarReceipt ? String(karigarReceipt.HD_VCH_NO ?? '').trim() : '',
    ISU_ADJ: 'N',
    HD_VCH_NO: headerVoucherNo,
    EMP_CODE: String(context.input.employeeCode ?? '').trim(),
    MAIN_USER: mainUser,
  }));
}

/** Create or edit a CUSTREP ISSUE, retaining both desktop voucher identities on edit. */
export async function saveCustomerRepairIssue(
  prisma: any,
  input: CustomerRepairIssueInput,
): Promise<CustomerRepairIssueResult> {
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

  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveRepairWorkflowBookTx(tx, scope, CUSTOMER_REPAIR_ISSUE);
    const party = await resolveRepairWorkflowPartyTx(tx, scope, input.acCode, input.acName);
    const taxDigits = await resolveTaxDigitsTx(tx, scope);
    const tax = await resolveIssueTaxTx(tx, scope, input.taxCode);
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
        throw new RepairWorkflowValidationError(`invalid repair issue voucher: ${input.vchNo}`);
      }
      const existing = await existingRepairHeaderTx(tx, scope, voucherNo);
      if (!existing) {
        throw new RepairWorkflowValidationError(`customer repair issue not found: ${voucherNo}`);
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
          'existing repair issue has no header voucher number',
        );
      }
      await releaseIssueSourcesTx(tx, scope, voucherNo);
    }

    const prepared = await prepareIssueLinesTx(tx, scope, party.acCode, input.lines);
    const totals = repairBillTotals(
      prepared.map((line) => line.totals),
      {
        discountPct,
        taxPct: tax.taxPct,
        taxDigits,
        chequeAmount,
        cardAmount,
        cashAmount,
        kasarAmount,
      },
    );
    const itemCreditTotal = round2(prepared.reduce((sum, line) => sum + line.totals.itemAmount, 0));
    const { legs: labourLegs } = karigarReceiptLabourOtherLegs({
      totalAmount: totals.totalAmount,
      itemDebitTotal: itemCreditTotal,
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
    const context: IssueLedgerContext = {
      key,
      input,
      policy,
      party,
      vchDate,
      headerVoucherNo: headerVoucherNo!,
      accounts: {
        cash: cashAccount,
        partyTotal: partyTotalAccount,
        labour: labourAccount,
        kasar: kasarAccount,
      },
      tax,
      totals,
      prepared,
      labourLegs,
      tender: { cheque: chequeAmount, card: cardAmount, cash: cashAmount, kasar: kasarAmount },
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
      { table: 'REP_DETL', rows: issueDetailRows(context, mainUser) },
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
    const dailyRows = issueRojRows(context);
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
      ledger: { table: 'AC_DATA', lines: issueLedgerLines(context) },
      bookName: policy.mainBook,
      writes,
    });
    await markIssueSourcesDeliveredTx(tx, scope, prepared);

    return {
      vchNo: Number(voucherNo!),
      voucherNo: voucherNo!,
      headerVoucherNo: headerVoucherNo!,
      created,
      totals,
    };
  });
}

function openLineFromRow(row: Record<string, unknown>): OpenCustomerRepairDeliveryLine {
  const coYear = String(row.CO_YEAR ?? '').trim();
  const coBook = String(row.CO_BOOK ?? '').trim();
  const voucherNo = String(row.VCH_NO ?? '').trim();
  const srNo = repairNumber(row.SR_NO);
  const customerName = String(row.SOURCE_AC_NAME ?? '').trim();
  const itemName = String(row.IT_NAME ?? '').trim();
  const karigarName = String(row.KARIGAR_AC_NAME ?? '').trim();
  return {
    code: `${coYear}/${coBook}/${voucherNo}/${srNo}`,
    name: [itemName, karigarName && `via ${karigarName}`].filter(Boolean).join(' · '),
    coYear,
    coBook,
    voucherNo,
    srNo,
    headerVoucherNo: String(row.HD_VCH_NO ?? '').trim(),
    vchDate: repairDateOnly(row.VCH_DATE),
    customerCode: String(row.AC_CODE ?? '').trim(),
    customerName,
    karigarReceiptNo: String(row.KARIGAR_VCH_NO ?? '').trim(),
    karigarReceiptSrNo: repairNumber(row.KARIGAR_SR_NO),
    karigarCode: String(row.KARIGAR_AC_CODE ?? '').trim(),
    karigarName,
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
    addWt: repairNumber(row.SOURCE_ADD_WT ?? row.ADD_WT),
    lessWt: repairNumber(row.SOURCE_LESS_WT ?? row.LESS_WT),
    lessTouch: repairNumber(row.SOURCE_LESS_TOUCH ?? row.LESS_TOUCH),
    lessFine: repairNumber(row.SOURCE_LESS_FINE ?? row.LESS_FINE),
    rate: repairNumber(row.ITM_RATE),
    labourAmount: repairNumber(row.SOURCE_LBR_AMT ?? row.LBR_AMT),
    otherAmount: repairNumber(row.SOURCE_OTH_AMT ?? row.OTH_AMT),
  };
}

/**
 * Open deliverable rows for a customer: their own open CUSTREP RECEIPT rows, with the linked open
 * KRREP RECEIPT row (when the item went to a karigar) supplying add/less weights and labour defaults.
 */
export async function listOpenCustomerRepairDeliveries(
  prisma: any,
  scopeInput: VoucherScope,
  acCodeInput: string,
  queryInput = '',
  limitInput = 50,
): Promise<OpenCustomerRepairDeliveryLine[]> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  const acCode = String(acCodeInput ?? '').trim();
  if (!acCode) throw new RepairWorkflowValidationError('customer account is required');
  const query = String(queryInput ?? '').trim();
  const limit = Math.min(200, Math.max(1, Math.trunc(Number(limitInput) || 50)));
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, CUSTOMER_REPAIR_ISSUE);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT A.*, H."AC_NAME" AS "SOURCE_AC_NAME",
              K."VCH_NO" AS "KARIGAR_VCH_NO", K."SR_NO" AS "KARIGAR_SR_NO",
              K."AC_CODE" AS "KARIGAR_AC_CODE", K."ISU_AC_NAME" AS "KARIGAR_AC_NAME",
              K."ADD_WT" AS "SOURCE_ADD_WT", K."LESS_WT" AS "SOURCE_LESS_WT",
              K."LESS_TOUCH" AS "SOURCE_LESS_TOUCH", K."LESS_FINE" AS "SOURCE_LESS_FINE",
              K."LBR_AMT" AS "SOURCE_LBR_AMT", K."OTH_AMT" AS "SOURCE_OTH_AMT"
         FROM "REP_DETL" AS A
         JOIN "REP_DATA" AS H
           ON H.tenant_id=A.tenant_id AND H."CO_CODE"=A."CO_CODE" AND H."LC_CODE"=A."LC_CODE"
          AND H."CO_YEAR"=A."CO_YEAR" AND H."CO_BOOK"=A."CO_BOOK" AND H."VCH_NO"=A."VCH_NO"
         LEFT JOIN "REP_DETL" AS K
           ON K.tenant_id=A.tenant_id AND K."CO_CODE"=A."CO_CODE" AND K."LC_CODE"=A."LC_CODE"
          AND K."REP_YRCD"=A."CO_YEAR" AND K."REP_DBCD"=A."CO_BOOK" AND K."REP_NO"=A."VCH_NO"
          AND K."REP_SRNO"::numeric=A."SR_NO"::numeric
          AND upper(btrim(coalesce(K."BOOK_NAME"::text,'')))=$5
          AND upper(coalesce(K."ISU_ADJ",'N'))='N'
        WHERE A.tenant_id=$1 AND A."CO_CODE"=$2 AND A."LC_CODE"=$3
          AND upper(btrim(coalesce(A."BOOK_NAME"::text,'')))=$4
          AND A."AC_CODE"=$6
          AND upper(coalesce(A."REP_ADJ",'N'))='N'
          AND (upper(coalesce(A."ISU_ADJ",'N'))='N' OR K."VCH_NO" IS NOT NULL)
          AND (btrim($7)='' OR A."VCH_NO"::text ILIKE '%'||$7||'%'
               OR A."IT_NAME"::text ILIKE '%'||$7||'%' OR A."IT_DESC"::text ILIKE '%'||$7||'%')
        ORDER BY A."VCH_DATE",A."VCH_NO",A."SR_NO"
        LIMIT $8`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      CUSTOMER_REPAIR_RECEIPT_SOURCE,
      KARIGAR_REPAIR_RECEIPT_SOURCE,
      acCode,
      query,
      limit,
    );
    return rows.map(openLineFromRow);
  });
}

function issueView(
  header: Record<string, unknown>,
  rows: Array<Record<string, unknown>>,
): CustomerRepairIssueView {
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
        CO_YEAR: row.REP_YRCD,
        CO_BOOK: row.REP_DBCD,
        VCH_NO: row.REP_NO,
        SR_NO: row.REP_SRNO,
        HD_VCH_NO: row.REP_HD_VCH_NO,
        AC_CODE: row.REP_AC_CODE,
        SOURCE_AC_NAME: row.REP_AC_NAME,
        VCH_DATE: row.SOURCE_VCH_DATE ?? row.VCH_DATE,
        KARIGAR_VCH_NO: row.ISU_NO,
        KARIGAR_SR_NO: row.ISU_SRNO,
        KARIGAR_AC_CODE: row.ISU_AC_CODE,
        KARIGAR_AC_NAME: row.ISU_AC_NAME,
        SOURCE_ADD_WT: row.ADD_WT,
        SOURCE_LESS_WT: row.LESS_WT,
        SOURCE_LESS_TOUCH: row.LESS_TOUCH,
        SOURCE_LESS_FINE: row.LESS_FINE,
        SOURCE_LBR_AMT: row.LBR_AMT,
        SOURCE_OTH_AMT: row.OTH_AMT,
      }),
      issueSrNo: repairNumber(row.SR_NO),
      itemAmount: repairNumber(row.ITM_AMT),
      labourType: String(row.LBR_TYPE ?? ''),
      labourRate: repairNumber(row.LBR_RATE),
      netAmount: repairNumber(row.NET_AMT),
    })),
  };
}

export async function getCustomerRepairIssue(
  prisma: any,
  scopeInput: VoucherScope,
  vchNo: string | number,
): Promise<CustomerRepairIssueView | null> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(vchNo);
  } catch {
    throw new RepairWorkflowValidationError(`invalid repair issue voucher: ${vchNo}`);
  }
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, CUSTOMER_REPAIR_ISSUE);
    const header = await existingRepairHeaderTx(tx, scope, voucherNo);
    if (!header) return null;
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ISSUE.*, SOURCE."VCH_DATE" AS "SOURCE_VCH_DATE"
         FROM "REP_DETL" AS ISSUE
         LEFT JOIN "REP_DETL" AS SOURCE
           ON SOURCE.tenant_id=ISSUE.tenant_id AND SOURCE."CO_CODE"=ISSUE."CO_CODE"
          AND SOURCE."LC_CODE"=ISSUE."REP_LC" AND SOURCE."CO_YEAR"=ISSUE."REP_YRCD"
          AND SOURCE."CO_BOOK"=ISSUE."REP_DBCD" AND SOURCE."VCH_NO"=ISSUE."REP_NO"
          AND SOURCE."SR_NO"::numeric=ISSUE."REP_SRNO"::numeric
        WHERE ISSUE.tenant_id=$1 AND ISSUE."CO_CODE"=$2 AND ISSUE."LC_CODE"=$3
          AND ISSUE."CO_YEAR"=$4 AND ISSUE."CO_BOOK"=$5 AND ISSUE."VCH_NO"=$6
        ORDER BY ISSUE."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    return issueView(header, rows);
  });
}

export async function listCustomerRepairIssues(
  prisma: any,
  scopeInput: VoucherScope,
  limitInput = 50,
): Promise<
  Array<{ voucherNo: string; vchDate: string; acCode: string; acName: string; description: string }>
> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  const limit = Math.min(200, Math.max(1, Math.trunc(Number(limitInput) || 50)));
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, CUSTOMER_REPAIR_ISSUE);
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

export async function deleteCustomerRepairIssue(
  prisma: any,
  input: { scope: VoucherScope; vchNo: string | number; deleteUser?: string },
): Promise<{ reversed: true }> {
  assertCompleteRepairScope(input.scope);
  const scope = input.scope;
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(input.vchNo);
  } catch {
    throw new RepairWorkflowValidationError(`invalid repair issue voucher: ${input.vchNo}`);
  }
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveRepairWorkflowBookTx(tx, scope, CUSTOMER_REPAIR_ISSUE);
    const existing = await existingRepairHeaderTx(tx, scope, voucherNo);
    if (!existing) {
      throw new RepairWorkflowValidationError(`customer repair issue not found: ${voucherNo}`);
    }
    await assertRepairVoucherUnlinkedTx(tx, scope, voucherNo);
    await assertPeriodOpen(tx, scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: existing.VCH_DATE }] },
    });
    const headerVoucherNo = String(existing.HD_VCH_NO ?? '').trim();
    await releaseIssueSourcesTx(tx, scope, voucherNo);
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
