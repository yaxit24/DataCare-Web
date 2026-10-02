import { withTxBudget } from '../shared/txBudget.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertPeriodOpen,
  insertRowTx,
  postVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
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
  resolveRepairWorkflowBookAccountTx,
  resolveRepairWorkflowBookTx,
  resolveRepairWorkflowPartyTx,
  type RepairWorkflowBookAccount,
  type RepairWorkflowBookPolicy,
  type RepairWorkflowParty,
} from './repairWorkflowCommon.js';

/** Second stage of TR_REP_REC: issue an open customer-repair item to a karigar. */
export const KARIGAR_REPAIR_ISSUE = 'KRREP ISSUE';
export const CUSTOMER_REPAIR_RECEIPT_STAGE = 'CUSTREP RECEIPT';

export interface CustomerRepairSourceReference {
  coYear: string;
  coBook: string;
  voucherNo: string | number;
  srNo: number;
}

export interface KarigarRepairIssueInput {
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
  lines: CustomerRepairSourceReference[];
}

export interface KarigarRepairIssueTotals {
  netAmount: number;
  discountAmount: number;
  taxAmount: number;
  totalAmount: number;
  outstandingAmount: number;
}

export interface KarigarRepairIssueResult {
  vchNo: number;
  voucherNo: string;
  headerVoucherNo: string;
  created: boolean;
  totals: KarigarRepairIssueTotals;
}

export interface OpenCustomerRepairLine {
  code: string;
  name: string;
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  headerVoucherNo: string;
  vchDate: string;
  customerCode: string;
  customerName: string;
  itCode: string;
  itemName: string;
  description: string;
  itmSize: string;
  tagNo: string;
  pieces: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  touch: number;
  wastagePct: number;
  fineWt: number;
}

export interface KarigarRepairIssueLineView extends OpenCustomerRepairLine {
  issueSrNo: number;
}

export interface KarigarRepairIssueView {
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
  totals: KarigarRepairIssueTotals;
  lines: KarigarRepairIssueLineView[];
}

interface NormalizedSourceReference {
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  ordinal: number;
}

interface PreparedSource {
  ref: NormalizedSourceReference;
  row: Record<string, unknown>;
}

const ZERO_TOTALS: KarigarRepairIssueTotals = {
  netAmount: 0,
  discountAmount: 0,
  taxAmount: 0,
  totalAmount: 0,
  outstandingAmount: 0,
};

function normalizedSourceReferences(
  lines: CustomerRepairSourceReference[],
): NormalizedSourceReference[] {
  if (!Array.isArray(lines) || !lines.length) {
    throw new RepairWorkflowValidationError('at least one open customer repair is required');
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

function sourceKey(row: Record<string, unknown>): string {
  return `${String(row.CO_YEAR ?? '').trim()}|${String(row.CO_BOOK ?? '').trim()}|${String(
    row.VCH_NO ?? '',
  ).trim()}|${repairNumber(row.SR_NO)}`;
}

async function prepareOpenSourcesTx(
  tx: any,
  scope: VoucherScope,
  inputLines: CustomerRepairSourceReference[],
): Promise<PreparedSource[]> {
  const refs = normalizedSourceReferences(inputLines);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT A.*, H."AC_NAME" AS "SOURCE_AC_NAME", H."VCH_NO" AS "SOURCE_HEADER_EXISTS",
            R.ordinal AS "SOURCE_ORDINAL"
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
    throw new RepairWorkflowValidationError('one or more customer repair source rows do not exist');
  }
  return refs.map((ref) => {
    const key = `${ref.coYear}|${ref.coBook}|${ref.voucherNo}|${ref.srNo}`;
    const row = byKey.get(key);
    if (!row) throw new RepairWorkflowValidationError(`customer repair source not found: ${key}`);
    if (!row.SOURCE_HEADER_EXISTS) {
      throw new RepairWorkflowValidationError(`customer repair source header is missing: ${key}`);
    }
    if (
      String(row.BOOK_NAME ?? '')
        .trim()
        .toUpperCase() !== CUSTOMER_REPAIR_RECEIPT_STAGE
    ) {
      throw new RepairWorkflowValidationError(`source row ${key} is not a customer repair receipt`);
    }
    if (
      String(row.ISU_ADJ ?? 'N')
        .trim()
        .toUpperCase() !== 'N'
    ) {
      throw new RepairWorkflowValidationError(`customer repair source is already issued: ${key}`);
    }
    if (!String(row.IT_CODE ?? '').trim()) {
      throw new RepairWorkflowValidationError(`customer repair source has no item: ${key}`);
    }
    // TR_REP_REC saves an issue row only when copied ITM_NWT + issue NET_AMT is non-zero. Issue
    // amounts are zero, so a source with no net weight cannot form a desktop issue row.
    if (repairNumber(row.ITM_NWT) === 0) {
      throw new RepairWorkflowValidationError(`customer repair source has no net weight: ${key}`);
    }
    return { ref, row };
  });
}

async function markSourcesIssuedTx(
  tx: any,
  scope: VoucherScope,
  sources: PreparedSource[],
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
    JSON.stringify(sources.map(({ ref }) => ref)),
  );
  if (Number(changed) !== sources.length) {
    throw new RepairWorkflowValidationError('customer repair source linkage changed concurrently');
  }
}

async function releaseIssueSourcesTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<void> {
  await tx.$executeRawUnsafe(
    `UPDATE "REP_DETL" AS SOURCE SET "ISU_ADJ"='N'
       FROM "REP_DETL" AS ISSUE
      WHERE SOURCE.tenant_id=ISSUE.tenant_id AND SOURCE."CO_CODE"=ISSUE."CO_CODE"
        AND SOURCE."LC_CODE"=ISSUE."REP_LC" AND SOURCE."CO_YEAR"=ISSUE."REP_YRCD"
        AND SOURCE."CO_BOOK"=ISSUE."REP_DBCD" AND SOURCE."VCH_NO"=ISSUE."REP_NO"
        AND SOURCE."SR_NO"::numeric=ISSUE."REP_SRNO"::numeric
        AND ISSUE.tenant_id=$1 AND ISSUE."CO_CODE"=$2 AND ISSUE."LC_CODE"=$3
        AND ISSUE."CO_YEAR"=$4 AND ISSUE."CO_BOOK"=$5 AND ISSUE."VCH_NO"=$6`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
}

function baseLedgerLine(
  key: Record<string, string>,
  input: KarigarRepairIssueInput,
  policy: RepairWorkflowBookPolicy,
  bookAccount: RepairWorkflowBookAccount,
  party: RepairWorkflowParty,
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

function issueTenderLedgerLines(
  key: Record<string, string>,
  input: KarigarRepairIssueInput,
  policy: RepairWorkflowBookPolicy,
  bookAccount: RepairWorkflowBookAccount,
  party: RepairWorkflowParty,
  vchDate: Date,
  headerVoucherNo: string,
): LedgerLine[] {
  const base = baseLedgerLine(key, input, policy, bookAccount, party, vchDate, headerVoucherNo);
  const lines: LedgerLine[] = [];
  const addPair = (amount: number, contra: string) => {
    if (!amount) return;
    lines.push({ ...base, AC_CODE: party.acCode, LD_CODE: contra, CR_AMT: 0, DR_AMT: amount });
    lines.push({
      ...base,
      AC_CODE: contra,
      LD_CODE: party.acCode,
      CR_AMT: amount,
      DR_AMT: 0,
      PARTY_AC_CODE: '',
    });
  };
  addPair(
    repairNonNegative(input.chequeAmount, 'cheque amount'),
    String(input.chequeAccount ?? '').trim(),
  );
  addPair(
    repairNonNegative(input.cardAmount, 'card amount'),
    String(input.cardAccount ?? '').trim(),
  );
  addPair(repairNonNegative(input.cashAmount, 'cash amount'), bookAccount.acCode);
  return lines;
}

function issueRojRows(
  key: Record<string, string>,
  input: KarigarRepairIssueInput,
  policy: RepairWorkflowBookPolicy,
  bookAccount: RepairWorkflowBookAccount,
  party: RepairWorkflowParty,
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
      CR_AMT: 0,
      DR_AMT: amount,
      AC_NAME: '',
    });
    rows.push({
      ...common,
      LEDR_KEY: ledKey(),
      AC_CODE: contra,
      LD_CODE: party.acCode,
      CR_AMT: amount,
      DR_AMT: 0,
      AC_NAME: '',
    });
  };
  addPair(
    repairNonNegative(input.chequeAmount, 'cheque amount'),
    String(input.chequeAccount ?? '').trim(),
  );
  addPair(
    repairNonNegative(input.cardAmount, 'card amount'),
    String(input.cardAccount ?? '').trim(),
  );
  const cash = repairNonNegative(input.cashAmount, 'cash amount');
  if (cash) {
    // Ac_Rojmel.Rep_CustRec_KrIsu_Rojmel intentionally records the issue cash-book row as DR,
    // while AC_DATA records the cash account as CR.
    rows.push({
      ...common,
      LEDR_KEY: ledKey(),
      AC_CODE: bookAccount.acCode,
      LD_CODE: party.acCode,
      CR_AMT: 0,
      DR_AMT: cash,
      AC_NAME: `REP - ${party.acName}`,
    });
  }
  return rows;
}

function detailRows(
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
  headerVoucherNo: string,
  policy: RepairWorkflowBookPolicy,
  party: RepairWorkflowParty,
  vchDate: Date,
  mainUser: string | null,
  sources: PreparedSource[],
): Record<string, unknown>[] {
  const key = repairVoucherKey(scope, voucherNo);
  return sources.map(({ row }, index) => ({
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
    IT_CODE: String(row.IT_CODE ?? '').trim(),
    IT_NAME: String(row.IT_NAME ?? '').trim(),
    IT_DESC: String(row.IT_DESC ?? '').trim(),
    ITM_SIZE: String(row.ITM_SIZE ?? '').trim(),
    TAG_NO: String(row.TAG_NO ?? '').trim() || null,
    DESIGN_NO: '',
    VCH_SRNO: repairNumber(row.VCH_SRNO),
    ITM_PCS: repairNumber(row.ITM_PCS),
    ITM_GWT: repairNumber(row.ITM_GWT),
    ITM_OTH_WT: repairNumber(row.ITM_OTH_WT),
    ADD_WT: repairNumber(row.ADD_WT),
    LESS_WT: repairNumber(row.LESS_WT),
    ITM_NWT: repairNumber(row.ITM_NWT),
    ITM_TOUCH: repairNumber(row.ITM_TOUCH),
    ITM_WEST: repairNumber(row.ITM_WEST),
    ITM_FINE: repairNumber(row.ITM_FINE),
    LESS_TOUCH: 0,
    LESS_FINE: 0,
    ITM_RATE: 0,
    ITM_AMT: 0,
    LBR_TYPE: '',
    LBR_RATE: 0,
    LBR_AMT: 0,
    RATE_TYPE: String(row.RATE_TYPE ?? '').trim(),
    IT_TYPE: String(row.IT_TYPE ?? '').trim(),
    OTH_AMT: 0,
    NET_AMT: 0,
    REP_NO: String(row.VCH_NO ?? '').trim(),
    REP_SRNO: repairNumber(row.SR_NO),
    REP_LC: String(row.LC_CODE ?? '').trim(),
    REP_YRCD: String(row.CO_YEAR ?? '').trim(),
    REP_DBCD: String(row.CO_BOOK ?? '').trim(),
    REP_AC_CODE: String(row.AC_CODE ?? '').trim(),
    REP_AC_NAME: String(row.SOURCE_AC_NAME ?? row.REP_AC_NAME ?? '').trim(),
    REP_HD_VCH_NO: String(row.HD_VCH_NO ?? '').trim(),
    REP_ADJ: 'N',
    ISU_NO: voucherNo,
    ISU_SRNO: index + 1,
    ISU_LC: scope.lcCode,
    ISU_YRCD: scope.coYear,
    ISU_DBCD: scope.coBook,
    ISU_AC_CODE: party.acCode,
    ISU_AC_NAME: party.acName,
    ISU_HD_VCH_NO: headerVoucherNo,
    ISU_ADJ: 'N',
    HD_VCH_NO: headerVoucherNo,
    MAIN_USER: mainUser,
  }));
}

/** Create or edit KRREP ISSUE while retaining both voucher identities on edit. */
export async function saveKarigarRepairIssue(
  prisma: any,
  input: KarigarRepairIssueInput,
): Promise<KarigarRepairIssueResult> {
  assertCompleteRepairScope(input.scope);
  const scope = input.scope;
  const chequeAmount = repairNonNegative(input.chequeAmount, 'cheque amount');
  const cardAmount = repairNonNegative(input.cardAmount, 'card amount');
  const cashAmount = repairNonNegative(input.cashAmount, 'cash amount');
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
    const policy = await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_ISSUE);
    const bookAccount = await resolveRepairWorkflowBookAccountTx(tx, scope, policy);
    const party = await resolveRepairWorkflowPartyTx(tx, scope, input.acCode, input.acName);
    if (chequeAmount) {
      await assertRepairWorkflowAccountTx(tx, scope, String(input.chequeAccount), 'bank');
    }
    if (cardAmount) {
      await assertRepairWorkflowAccountTx(tx, scope, String(input.cardAccount), 'card');
    }
    await assertRepairWorkflowAccountTx(tx, scope, bookAccount.acCode, 'book cash/control');

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
        throw new RepairWorkflowValidationError(`karigar repair issue not found: ${voucherNo}`);
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
      // Release old references before re-resolving the replacement set. Any later failure rolls this
      // back, so a rejected edit cannot reopen the source repair.
      await releaseIssueSourcesTx(tx, scope, voucherNo);
    }

    const sources = await prepareOpenSourcesTx(tx, scope, input.lines);
    if (created) {
      voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, scope));
      headerVoucherNo = await nextRepairHeaderVoucherNoTx(tx, scope);
    } else {
      await deleteRepairVoucherRowsTx(tx, scope, voucherNo!);
    }

    const key = repairVoucherKey(scope, voucherNo!);
    const mainUser = String(input.mainUser ?? '').trim() || null;
    const header = {
      ...key,
      VCH_DATE: vchDate,
      BILL_NO: String(input.billNo ?? '').trim(),
      VCH_TIME: vchDate,
      AC_CODE: party.acCode,
      AC_NAME: party.acName,
      NET_AMT: 0,
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
      TOT_AMT: 0,
      CASH_AMT: cashAmount,
      CHQ_AMT: chequeAmount,
      BANK_AC: chequeAmount ? String(input.chequeAccount).trim() : null,
      CHQ_NO: String(input.chequeNo ?? '').trim(),
      BANK_NAME: String(input.bankName ?? '').trim(),
      CARD_AMT: cardAmount,
      CARD_AC: cardAmount ? String(input.cardAccount).trim() : null,
      KASAR_AMT: 0,
      BILL_OS: 0,
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
      {
        table: 'REP_DETL',
        rows: detailRows(
          scope,
          voucherNo!,
          headerVoucherNo!,
          policy,
          party,
          vchDate,
          mainUser,
          sources,
        ),
      },
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
    const dailyRows = issueRojRows(key, input, policy, bookAccount, party, vchDate);
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
        lines: issueTenderLedgerLines(
          key,
          input,
          policy,
          bookAccount,
          party,
          vchDate,
          headerVoucherNo!,
        ),
      },
      bookName: policy.mainBook,
      writes,
    });
    await markSourcesIssuedTx(tx, scope, sources);

    return {
      vchNo: Number(voucherNo!),
      voucherNo: voucherNo!,
      headerVoucherNo: headerVoucherNo!,
      created,
      totals: { ...ZERO_TOTALS },
    };
  });
}

function openLineFromRow(row: Record<string, unknown>): OpenCustomerRepairLine {
  const coYear = String(row.CO_YEAR ?? row.REP_YRCD ?? '').trim();
  const coBook = String(row.CO_BOOK ?? row.REP_DBCD ?? '').trim();
  const voucherNo = String(row.VCH_NO ?? row.REP_NO ?? '').trim();
  const srNo = repairNumber(row.SR_NO ?? row.REP_SRNO);
  const customerName = String(row.SOURCE_AC_NAME ?? row.REP_AC_NAME ?? '').trim();
  const itemName = String(row.IT_NAME ?? '').trim();
  return {
    code: `${coYear}/${coBook}/${voucherNo}/${srNo}`,
    name: [customerName, itemName].filter(Boolean).join(' · '),
    coYear,
    coBook,
    voucherNo,
    srNo,
    headerVoucherNo: String(row.HD_VCH_NO ?? row.REP_HD_VCH_NO ?? '').trim(),
    vchDate: repairDateOnly(row.VCH_DATE),
    customerCode: String(row.AC_CODE ?? row.REP_AC_CODE ?? '').trim(),
    customerName,
    itCode: String(row.IT_CODE ?? '').trim(),
    itemName,
    description: String(row.IT_DESC ?? '').trim(),
    itmSize: String(row.ITM_SIZE ?? '').trim(),
    tagNo: String(row.TAG_NO ?? '').trim(),
    pieces: repairNumber(row.ITM_PCS),
    grossWt: repairNumber(row.ITM_GWT),
    otherWt: repairNumber(row.ITM_OTH_WT),
    netWt: repairNumber(row.ITM_NWT),
    touch: repairNumber(row.ITM_TOUCH),
    wastagePct: repairNumber(row.ITM_WEST),
    fineWt: repairNumber(row.ITM_FINE),
  };
}

export async function listOpenCustomerRepairLines(
  prisma: any,
  scopeInput: VoucherScope,
  queryInput = '',
  limitInput = 50,
): Promise<OpenCustomerRepairLine[]> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  const query = String(queryInput ?? '').trim();
  const limit = Math.min(200, Math.max(1, Math.trunc(Number(limitInput) || 50)));
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_ISSUE);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT A.*, H."AC_NAME" AS "SOURCE_AC_NAME"
         FROM "REP_DETL" AS A
         JOIN "REP_DATA" AS H
           ON H.tenant_id=A.tenant_id AND H."CO_CODE"=A."CO_CODE" AND H."LC_CODE"=A."LC_CODE"
          AND H."CO_YEAR"=A."CO_YEAR" AND H."CO_BOOK"=A."CO_BOOK" AND H."VCH_NO"=A."VCH_NO"
        WHERE A.tenant_id=$1 AND A."CO_CODE"=$2 AND A."LC_CODE"=$3
          AND upper(btrim(coalesce(A."BOOK_NAME"::text,'')))=$4
          AND upper(coalesce(A."ISU_ADJ",'N'))='N'
          AND (btrim($5)='' OR A."VCH_NO"::text ILIKE '%'||$5||'%'
               OR H."AC_NAME"::text ILIKE '%'||$5||'%' OR A."IT_NAME"::text ILIKE '%'||$5||'%')
        ORDER BY A."VCH_DATE",A."VCH_NO",A."SR_NO"
        LIMIT $6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      CUSTOMER_REPAIR_RECEIPT_STAGE,
      query,
      limit,
    );
    return rows.map(openLineFromRow);
  });
}

function issueView(
  header: Record<string, unknown>,
  rows: Array<Record<string, unknown>>,
): KarigarRepairIssueView {
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
    chequeAmount: repairNumber(header.CHQ_AMT),
    chequeAccount: String(header.BANK_AC ?? ''),
    chequeNo: String(header.CHQ_NO ?? ''),
    cardAmount: repairNumber(header.CARD_AMT),
    cardAccount: String(header.CARD_AC ?? ''),
    cashAmount: repairNumber(header.CASH_AMT),
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
        VCH_DATE: row.SOURCE_VCH_DATE ?? row.VCH_DATE,
        HD_VCH_NO: row.REP_HD_VCH_NO,
        AC_CODE: row.REP_AC_CODE,
        SOURCE_AC_NAME: row.REP_AC_NAME,
      }),
      issueSrNo: repairNumber(row.SR_NO),
    })),
  };
}

export async function getKarigarRepairIssue(
  prisma: any,
  scopeInput: VoucherScope,
  vchNo: string | number,
): Promise<KarigarRepairIssueView | null> {
  assertCompleteRepairScope(scopeInput);
  const scope = scopeInput;
  let voucherNo: string;
  try {
    voucherNo = formatVoucherNo(vchNo);
  } catch {
    throw new RepairWorkflowValidationError(`invalid repair issue voucher: ${vchNo}`);
  }
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_ISSUE);
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

export async function listKarigarRepairIssues(
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
    await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_ISSUE);
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

export async function deleteKarigarRepairIssue(
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
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveRepairWorkflowBookTx(tx, scope, KARIGAR_REPAIR_ISSUE);
    const existing = await existingRepairHeaderTx(tx, scope, voucherNo);
    if (!existing) {
      throw new RepairWorkflowValidationError(`karigar repair issue not found: ${voucherNo}`);
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
