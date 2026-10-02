import { withTxBudget } from '../shared/txBudget.js';
import { assertBalanced, assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import {
  resolveBookAccountTx,
  resolveBookPolicyTx,
  type BookPolicy,
} from '../shared/bookPolicy.js';
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
} from './lifecycle.js';

export class VpAdjustmentValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'VpAdjustmentValidationError';
  }
}

export interface VpAdjustmentLineInput {
  vpYear: string;
  vpBook: string;
  vpNo: string;
  receiptAmount: number;
  kasarAmount?: number;
  description?: string;
}

export interface VpAdjustmentInput {
  scope: VoucherScope;
  vchDate: string | Date;
  employeeCode?: string;
  lines: VpAdjustmentLineInput[];
  mainUser?: string;
}

type ResolvedSource = {
  vpYear: string;
  vpBook: string;
  vpNo: string;
  vpHiddenVoucherNo: string;
  partyCode: string;
  partyName: string;
  angdiyaCode: string;
  angdiyaName: string;
  receiptAmount: number;
  kasarAmount: number;
  description: string;
  sourceItemType: string;
  sourceFine: number;
  sourceItemAmount: number;
};

type VpBookPolicy = BookPolicy & { configuredName: string; dataType: string };

const amount = (value: unknown): number =>
  Math.round((Number(value ?? 0) + Number.EPSILON) * 100) / 100;

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new VpAdjustmentValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new VpAdjustmentValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

function numericText(value: unknown, label: string): number {
  const raw = text(value);
  if (!raw) return 0;
  if (!/^-?\d+(?:\.\d+)?$/.test(raw)) {
    throw new VpAdjustmentValidationError(`${label} is not numeric`);
  }
  const parsed = Number(raw);
  if (!Number.isFinite(parsed)) throw new VpAdjustmentValidationError(`${label} is not numeric`);
  return amount(parsed);
}

async function resolveBookTx(tx: any, scope: VoucherScope): Promise<VpBookPolicy> {
  // TR_VP_ADJ.cs:2303-2309 takes the configured book's MAIN_BOOK, BOOK_SNAME and
  // BOOK_INOUT into FormMainBook/FormBookSname/FormBookInOut. VP_ADJ_DATA stamps those
  // exact values at 2672-2675. The shared policy fails closed unless this is VP REC / I.
  const policy = await resolveBookPolicyTx(tx, scope, 'VP REC');
  const rows: Array<{
    BOOK_NAME: unknown;
    DATA_TYPE: unknown;
    MAIN_BOOK: unknown;
    BOOK_INOUT: unknown;
  }> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME","DATA_TYPE","MAIN_BOOK","BOOK_INOUT" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (
    rows.length !== 1 ||
    text(rows[0]?.MAIN_BOOK).toUpperCase() !== 'VP REC' ||
    text(rows[0]?.BOOK_INOUT).toUpperCase() !== 'I'
  ) {
    throw new VpAdjustmentValidationError(`VP receipt book configuration is ambiguous`);
  }
  return {
    ...policy,
    configuredName: text(rows[0]!.BOOK_NAME) || policy.mainBook,
    dataType: text(rows[0]!.DATA_TYPE) || 'A',
  };
}

async function oneAccountTx(
  tx: any,
  scope: VoucherScope,
  code: string,
): Promise<{ code: string; name: string }> {
  const rows: Array<{ AC_CODE: unknown; AC_NAME: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME" FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (rows.length !== 1) {
    throw new VpAdjustmentValidationError(
      rows.length ? `account is ambiguous: ${code}` : `account not found: ${code}`,
    );
  }
  return { code: text(rows[0]!.AC_CODE), name: text(rows[0]!.AC_NAME) };
}

async function employeeTx(tx: any, input: VpAdjustmentInput): Promise<string> {
  const code = text(input.employeeCode);
  if (!code) return '';
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    code,
  );
  if (rows.length !== 1) throw new VpAdjustmentValidationError(`employee not found: ${code}`);
  return code;
}

async function sourceForUpdateTx(
  tx: any,
  scope: VoucherScope,
  key: { vpYear: string; vpBook: string; vpNo: string },
): Promise<Record<string, unknown>> {
  // TR_VP_ADJ.cs:1909-1960 resolves RATE_CUT_DATA by source year/book/voucher, joins the
  // source book, requires MAIN_BOOK='VP PARCEL', and exposes only rows with outstanding
  // VP_AMT-VP_ADJ_AMT. Party, angdiya, hidden identity, item type/fine and amounts below are
  // therefore server-resolved rather than accepted from the request.
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT r.*
       FROM "RATE_CUT_DATA" r
       JOIN "BOOK_DATA" b ON b.tenant_id=r.tenant_id AND b."CO_CODE"=r."CO_CODE"
        AND b."LC_CODE"=r."LC_CODE" AND b."CO_BOOK"=r."CO_BOOK"
      WHERE r.tenant_id=$1 AND r."CO_CODE"=$2 AND r."LC_CODE"=$3
        AND r."CO_YEAR"=$4 AND r."CO_BOOK"=$5 AND r."VCH_NO"=$6
        AND upper(btrim(coalesce(b."MAIN_BOOK"::text,'')))='VP PARCEL'
      FOR UPDATE OF r`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    key.vpYear,
    key.vpBook,
    key.vpNo,
  );
  if (rows.length !== 1) {
    throw new VpAdjustmentValidationError(
      rows.length
        ? `VP parcel source is ambiguous: ${key.vpBook}/${key.vpNo}`
        : `VP parcel source not found: ${key.vpBook}/${key.vpNo}`,
    );
  }
  return rows[0]!;
}

async function changeSourceAdjustmentTx(
  tx: any,
  scope: VoucherScope,
  key: { vpYear: string; vpBook: string; vpNo: string },
  delta: number,
): Promise<Record<string, unknown>> {
  const source = await sourceForUpdateTx(tx, scope, key);
  const current = numericText(source.VP_ADJ_AMT, 'VP_ADJ_AMT');
  const next = amount(current + delta);
  const total = numericText(source.VP_AMT, 'VP_AMT');
  if (next < 0 || next > total) {
    throw new VpAdjustmentValidationError(
      `VP adjustment exceeds outstanding amount for ${key.vpBook}/${key.vpNo}`,
    );
  }
  await tx.$executeRawUnsafe(
    // VP_ADJ_AMT is double precision after the column-type correction.
    `UPDATE "RATE_CUT_DATA" SET "VP_ADJ_AMT"=$1::double precision
      WHERE tenant_id=$2 AND "CO_CODE"=$3 AND "LC_CODE"=$4
        AND "CO_YEAR"=$5 AND "CO_BOOK"=$6 AND "VCH_NO"=$7`,
    next,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    key.vpYear,
    key.vpBook,
    key.vpNo,
  );
  source.VP_ADJ_AMT = next;
  return source;
}

async function reversePersistedSourcesTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
): Promise<void> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "VP_YRCD","VP_DBCD","VP_NO","REC_AMT","KASAR_AMT"
       FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  for (const row of rows) {
    await changeSourceAdjustmentTx(
      tx,
      scope,
      {
        vpYear: text(row.VP_YRCD),
        vpBook: text(row.VP_DBCD),
        vpNo: formatVoucherNo(text(row.VP_NO)),
      },
      -amount(Number(row.REC_AMT ?? 0) + Number(row.KASAR_AMT ?? 0)),
    );
  }
}

async function resolveLinesTx(tx: any, input: VpAdjustmentInput): Promise<ResolvedSource[]> {
  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new VpAdjustmentValidationError('at least one VP adjustment line is required');
  }
  const result: ResolvedSource[] = [];
  for (const line of input.lines) {
    const vpYear = text(line?.vpYear);
    const vpBook = text(line?.vpBook);
    const vpNo = formatVoucherNo(text(line?.vpNo));
    const receiptAmount = amount(line?.receiptAmount);
    const kasarAmount = amount(line?.kasarAmount);
    if (!vpYear || !vpBook || !vpNo || receiptAmount <= 0) {
      throw new VpAdjustmentValidationError(
        'every VP adjustment line requires source year, source book, source voucher, and positive receipt amount',
      );
    }
    if (!Number.isFinite(receiptAmount) || !Number.isFinite(kasarAmount) || kasarAmount < 0) {
      throw new VpAdjustmentValidationError(
        'VP receipt and kasar amounts must be valid non-negative numbers',
      );
    }
    const source = await changeSourceAdjustmentTx(
      tx,
      input.scope,
      { vpYear, vpBook, vpNo },
      amount(receiptAmount + kasarAmount),
    );
    const party = await oneAccountTx(tx, input.scope, text(source.AC_CODE));
    const angdiya = await oneAccountTx(tx, input.scope, text(source.AC_ANGDIYA));
    result.push({
      vpYear,
      vpBook,
      vpNo,
      vpHiddenVoucherNo: text(source.HD_VCH_NO),
      partyCode: party.code,
      partyName: party.name,
      angdiyaCode: angdiya.code,
      angdiyaName: angdiya.name,
      receiptAmount,
      kasarAmount,
      description: text(line?.description).slice(0, 150),
      sourceItemType: text(source.IT_TYPE),
      sourceFine: numericText(source.SL_FINE, 'SL_FINE'),
      sourceItemAmount: numericText(source.SL_ITM_AMT, 'SL_ITM_AMT'),
    });
  }
  return result;
}

function ledgerBase(
  scope: ReturnType<typeof completeFinanceScope>,
  policy: VpBookPolicy,
  identity: VoucherIdentity,
  line: ResolvedSource,
  ledgerKey: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    VCH_TYPE: policy.vchType,
    VCH_DATE: identity.voucherDate,
    LEDR_KEY: ledgerKey,
    BOOK_NAME: policy.mainBook,
    BILL_NO: '',
    BILL_DATE: null,
    CHQ_NO: '',
    IT_TYPE: 'A',
    SIGN: '',
    FINE_WT: 0,
    IT_DESC: line.description,
    ENTRY_TIME: identity.voucherTime,
    HD_VCH_NO: identity.hiddenVoucherNo,
    CLR_DATE: null,
    DATA_TYPE: policy.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    FINE_RATE: 0,
    PARTY_AC_CODE: line.partyCode,
    LDR_NAME: '',
  };
}

function rojmelBase(
  scope: ReturnType<typeof completeFinanceScope>,
  policy: VpBookPolicy,
  identity: VoucherIdentity,
  line: ResolvedSource,
  ledgerKey: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    LEDR_KEY: ledgerKey,
    VCH_DATE: identity.voucherDate,
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
    IT_DESC: line.description,
    IT_CODE: '',
    MEMB_CODE: '',
    SCHM_CODE: '',
    REF_NO: '',
    DATA_TYPE: policy.dataType,
  };
}

async function writeTx(
  tx: any,
  input: VpAdjustmentInput,
  policy: VpBookPolicy,
  identity: VoucherIdentity,
  lines: ResolvedSource[],
  employeeCode: string,
): Promise<void> {
  const scope = completeFinanceScope(input.scope);
  const receiptAccount = await resolveBookAccountTx(tx, scope, policy, 1);
  const kasarAccount = lines.some((line) => line.kasarAmount !== 0)
    ? await resolveBookAccountTx(tx, scope, policy, 2)
    : '';
  await oneAccountTx(tx, scope, receiptAccount);
  if (kasarAccount) await oneAccountTx(tx, scope, kasarAccount);
  // TR_VP_ADJ.cs:2639-2640 writes TEMP_BOOK_DATA from the current company/location/book,
  // preserved/new hidden VCH_NO and configured BOOK_DATA.BOOK_NAME (no fiscal-year column).
  await insertHiddenIdentityTx(tx, scope, identity, policy.configuredName);

  const ledger: Record<string, unknown>[] = [];
  for (let index = 0; index < lines.length; index++) {
    const line = lines[index]!;
    const srNo = index + 1;
    // TR_VP_ADJ.cs:2669-2696 is the complete VP_ADJ_DATA projection: scope/number/date,
    // configured type/inout/main book, SR_NO, server-resolved party and angdiya, REC_AMT,
    // KASAR_AMT, description, source VP identity including hidden number, voucher timestamp,
    // hidden number, employee, transfer/user flags and preserved MAIN_USER.
    await insertRowTx(tx, 'VP_ADJ_DATA', scope.tenantId, {
      ...voucherKey(scope, identity.voucherNo),
      SR_NO: srNo,
      VCH_DATE: identity.voucherDate,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'C',
      BOOK_NAME: policy.mainBook,
      VCH_TIME: identity.voucherTime,
      AC_CODE: line.partyCode,
      AC_NAME: line.partyName,
      REC_AMT: line.receiptAmount,
      KASAR_AMT: line.kasarAmount,
      IT_DESC: line.description,
      EMP_CODE: employeeCode,
      DATA_TRFR: 'N',
      HD_VCH_NO: identity.hiddenVoucherNo,
      VP_NO: line.vpNo,
      VP_LC_CODE: scope.lcCode,
      VP_YRCD: line.vpYear,
      VP_DBCD: line.vpBook,
      ANGDIYA_AC: line.angdiyaCode,
      ANGDIYA_NAME: line.angdiyaName,
      MAIN_USER: identity.mainUser || null,
      VP_HD_VCH_NO: line.vpHiddenVoucherNo,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    });

    const prefix = `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}${srNo}`;
    // Ac_Ledr.cs:1808-1829: REC_AMT has two balanced transfers (party DR / angdiya CR,
    // then party CR / BOOK_DETL SR1 DR); KASAR_AMT is party CR / BOOK_DETL SR2 DR.
    // Contra accounts therefore come from the source AC_ANGDIYA and configured BOOK_DETL.
    if (line.receiptAmount !== 0) {
      ledger.push({
        ...ledgerBase(scope, policy, identity, line, `${prefix}01`),
        AC_CODE: line.partyCode,
        LD_CODE: line.angdiyaCode,
        CR_AMT: 0,
        DR_AMT: line.receiptAmount,
      });
      ledger.push({
        ...ledgerBase(scope, policy, identity, line, `${prefix}02`),
        AC_CODE: line.angdiyaCode,
        LD_CODE: line.partyCode,
        CR_AMT: line.receiptAmount,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
      });
      ledger.push({
        ...ledgerBase(scope, policy, identity, line, `${prefix}03`),
        AC_CODE: line.partyCode,
        LD_CODE: receiptAccount,
        CR_AMT: line.receiptAmount,
        DR_AMT: 0,
      });
      ledger.push({
        ...ledgerBase(scope, policy, identity, line, `${prefix}04`),
        AC_CODE: receiptAccount,
        LD_CODE: line.partyCode,
        CR_AMT: 0,
        DR_AMT: line.receiptAmount,
        PARTY_AC_CODE: '',
      });
      // Ac_Ledr.cs:1830-1837 adds this metal-only source fine leg for ordinary registrations
      // only when the source is gold with zero SL_ITM_AMT. The special registration-number
      // branches are intentionally not guessed because no corresponding tenant setting exists.
      if (line.sourceItemType === 'G' && line.sourceItemAmount === 0 && line.sourceFine !== 0) {
        ledger.push({
          ...ledgerBase(scope, policy, identity, line, `${prefix}08`),
          AC_CODE: line.partyCode,
          LD_CODE: receiptAccount,
          CR_AMT: 0,
          DR_AMT: 0,
          IT_TYPE: 'G',
          SIGN: '+',
          FINE_WT: line.sourceFine,
        });
      }
    }
    if (line.kasarAmount !== 0) {
      ledger.push({
        ...ledgerBase(scope, policy, identity, line, `${prefix}05`),
        AC_CODE: line.partyCode,
        LD_CODE: kasarAccount,
        CR_AMT: line.kasarAmount,
        DR_AMT: 0,
        IT_DESC: '',
      });
      ledger.push({
        ...ledgerBase(scope, policy, identity, line, `${prefix}06`),
        AC_CODE: kasarAccount,
        LD_CODE: line.partyCode,
        CR_AMT: 0,
        DR_AMT: line.kasarAmount,
        IT_DESC: '',
        PARTY_AC_CODE: '',
      });
    }

    // Ac_Rojmel.cs:853-861 is the full ROJ_MEL_DATA projection: SR1 receipt account CR;
    // for kasar, party CR and configured SR2 DR. All stock/metal columns are zero.
    if (line.receiptAmount !== 0) {
      await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
        ...rojmelBase(scope, policy, identity, line, `${prefix}R01`),
        AC_CODE: receiptAccount,
        LD_CODE: line.partyCode,
        CR_AMT: line.receiptAmount,
        DR_AMT: 0,
        AC_NAME: line.partyName,
      });
    }
    if (line.kasarAmount !== 0) {
      await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
        ...rojmelBase(scope, policy, identity, line, `${prefix}R02`),
        AC_CODE: line.partyCode,
        LD_CODE: kasarAccount,
        CR_AMT: line.kasarAmount,
        DR_AMT: 0,
        AC_NAME: `KSR - ${line.partyName}`,
      });
      await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
        ...rojmelBase(scope, policy, identity, line, `${prefix}R03`),
        AC_CODE: kasarAccount,
        LD_CODE: line.partyCode,
        CR_AMT: 0,
        DR_AMT: line.kasarAmount,
        AC_NAME: `KSR - ${line.partyName}`,
      });
    }
  }
  assertBalanced(ledger);
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);
}

async function saveTx(
  tx: any,
  input: VpAdjustmentInput,
  requestedVoucherNo?: string,
): Promise<{
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
}> {
  const scope = completeFinanceScope(input.scope);
  const policy = await resolveBookTx(tx, scope);
  const { date, iso } = businessDate(input.vchDate);
  // TR_VP_ADJ.cs:2562-2599 exact desktop save validations include:
  // "You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....",
  // "You Cant Save This Voucher Becouse This Company Type is B......",
  // "You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...",
  // "You Cant Save and Delete This Voucher Becouse Lock Date is = ... ....",
  // "You Have No Rights.....", and "Please Insert VchNo and try". Rights are route-guarded;
  // licence/company-type are not request-controlled. Fiscal and lock checks fail closed here.
  await assertFiscalDateTx(tx, scope, iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
  const employeeCode = await employeeTx(tx, input);
  const created = !requestedVoucherNo;
  let identity: VoucherIdentity;
  if (requestedVoucherNo) {
    const edited = await editIdentityTx(tx, {
      table: 'VP_ADJ_DATA',
      scope,
      requestedVoucherNo,
      requestedDate: date,
    });
    identity = edited.identity;
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    await reversePersistedSourcesTx(tx, scope, identity.voucherNo);
    // TR_VP_ADJ.cs:2630-2712 reverses source adjustments, deletes/reinserts VP_ADJ_DATA,
    // TEMP_BOOK_DATA, AC_DATA and ROJ_MEL_DATA, then reapplies source totals. It does not
    // INSERT DELETE_DATA on edit (the only INSERT DELETE_DATA is the delete handler at 2758).
    await replaceWriteSetTx(tx, scope, identity.voucherNo, identity.hiddenVoucherNo, [
      'AC_DATA',
      'ROJ_MEL_DATA',
      'VP_ADJ_DATA',
    ]);
  } else {
    // TR_VP_ADJ.cs:2375 numbers from MAX(VCH_NO) in VP_ADJ_DATA; line 2387 independently
    // numbers TEMP_BOOK_DATA by company+location+book, deliberately without fiscal year.
    identity = await createIdentityTx(tx, scope, date, input.mainUser);
  }
  const lines = await resolveLinesTx(tx, input);
  await writeTx(tx, input, policy, identity, lines, employeeCode);
  return {
    voucherNo: identity.voucherNo,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    created,
    lines: lines.length,
  };
}

export async function saveVpAdjustment(
  prisma: any,
  input: VpAdjustmentInput,
  requestedVoucherNo?: string,
) {
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getVpAdjustment(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveBookTx(tx, scope);
    // TR_VP_ADJ.cs:2431-2451 loads the persisted header and explicitly preserves HD_VCH_NO,
    // MAIN_USER and the VCH_TIME wall clock; lines 2469-2503 restore every grid/source field.
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT d.*,d."VCH_DATE"::text AS "VCH_DAY",
              to_char(d."VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK"
         FROM "VP_ADJ_DATA" d
        WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4
          AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6 ORDER BY d."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length)
      throw new VpAdjustmentValidationError(`VP adjustment not found: ${voucherNo}`);
    const h = rows[0]!;
    return {
      voucherNo,
      vchDate: text(h.VCH_DAY).slice(0, 10),
      voucherTime: text(h.VCH_CLOCK),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      employeeCode: text(h.EMP_CODE),
      lines: rows.map((row) => ({
        srNo: Number(row.SR_NO ?? 0),
        vpYear: text(row.VP_YRCD),
        vpBook: text(row.VP_DBCD),
        vpNo: text(row.VP_NO),
        vpHiddenVoucherNo: text(row.VP_HD_VCH_NO),
        partyCode: text(row.AC_CODE),
        partyName: text(row.AC_NAME),
        angdiyaCode: text(row.ANGDIYA_AC),
        angdiyaName: text(row.ANGDIYA_NAME),
        receiptAmount: Number(row.REC_AMT ?? 0),
        kasarAmount: Number(row.KASAR_AMT ?? 0),
        description: text(row.IT_DESC),
      })),
    };
  });
}

export async function deleteVpAdjustment(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
): Promise<{ reversed: true; auditedLines: number }> {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveBookTx(tx, scope);
    const edited = await editIdentityTx(tx, {
      table: 'VP_ADJ_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      checkRequestedDate: false,
    });
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "VP_ADJ_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    // TR_VP_ADJ.cs:2758 is exactly one DELETE_DATA INSERT...SELECT, producing one audit row
    // per VP_ADJ_DATA row. Exact mapping: scope/VCH_NO/SR_NO/VCH_DATE/VCH_TIME/HD_VCH_NO/
    // MAIN_USER from A; DELETE_DATE/TIME and DELETE_USER at deletion; VCH_TYPE=BOOK_SNAME,
    // BOOK_NAME=BOOK_NAME; AC_CODE/AC_NAME from A; DR=REC_AMT only for INOUT_TYPE O,
    // CR=REC_AMT only for INOUT_TYPE I; FINE_TYPE='A', both fine values 0; description is
    // SUBSTRING(IT_DESC,1,149). KASAR_AMT is intentionally not mapped into the audit values.
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: { name: policy.configuredName, shortName: policy.vchType },
      header: rows[0]!,
      deleteUser,
      rows: rows.map((row) => ({
        srNo: Number(row.SR_NO ?? 0),
        acCode: row.AC_CODE,
        acName: row.AC_NAME,
        valueDr: text(row.INOUT_TYPE) === 'O' ? Number(row.REC_AMT ?? 0) : 0,
        valueCr: text(row.INOUT_TYPE) === 'I' ? Number(row.REC_AMT ?? 0) : 0,
        fineType: 'A',
        fineDr: 0,
        fineCr: 0,
        description: text(row.IT_DESC),
      })),
    });
    // TR_VP_ADJ.cs:2760-2779 reverses RATE_CUT_DATA.VP_ADJ_AMT and removes TEMP_BOOK_DATA,
    // AC_DATA, ROJ_MEL_DATA and VP_ADJ_DATA after auditing.
    await reversePersistedSourcesTx(tx, scope, voucherNo);
    await replaceWriteSetTx(tx, scope, voucherNo, edited.identity.hiddenVoucherNo, [
      'AC_DATA',
      'ROJ_MEL_DATA',
      'VP_ADJ_DATA',
    ]);
    return { reversed: true, auditedLines: rows.length };
  });
}
