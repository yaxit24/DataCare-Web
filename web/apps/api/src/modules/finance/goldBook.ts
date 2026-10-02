import { withTxBudget } from '../shared/txBudget.js';
import { assertBalanced, assertPeriodOpen, insertRowTx } from '../posting/posting.js';
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

export class GoldBookValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'GoldBookValidationError';
  }
}

// Desktop validation evidence (TR_GOLD_BOOK.cs:2540-2605):
// - expired licence: "You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence...."
// - company type B: "You Cant Save This Voucher Becouse This Company Type is B......"
// - fiscal year: "You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date..."
// - period lock: "You Cant Save and Delete This Voucher Becouse Lock Date is = ... ...."
// - rights: "You Have No Rights....."; missing number: "Please Insert VchNo and try".
// Web delegates rights to the route guard and fiscal/lock checks to the shared fail-closed lifecycle;
// no request-controlled licence/company flag is accepted or invented here.

export interface GoldBookLineInput {
  acCode: string;
  amount: number;
  rate: number;
  fine: number;
  ledgerAccount: string;
  taxCode?: string;
  description?: string;
}

export interface GoldBookInput {
  scope: VoucherScope;
  vchDate: string | Date;
  employeeCode?: string;
  remark?: string;
  lines: GoldBookLineInput[];
  mainUser?: string;
}

type BookPolicy = {
  coBook: string;
  configuredName: string;
  mainBook: string;
  vchType: string;
  inout: string;
  dataType: string;
};

type ResolvedLine = {
  /** ITM_TYPE — metal class ('G' gold, 'S' silver) carried on the DG_GOLD_DATA row. */
  itType?: string;
  acCode: string;
  acName: string;
  mobile: string;
  amount: number;
  rate: number;
  fine: number;
  ledgerAccount: string;
  taxCode: string;
  taxPercent: number;
  taxAmount: number;
  taxAccount: string;
  total: number;
  description: string;
};

const money = (value: number): number => Math.round((value + Number.EPSILON) * 100) / 100;
const number = (value: unknown): number => Number(value ?? 0);

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new GoldBookValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new GoldBookValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

async function resolveBookTx(tx: any, scope: VoucherScope): Promise<BookPolicy> {
  const complete = completeFinanceScope(scope);
  // TR_GOLD_BOOK.cs:2330-2345 copies MAIN_BOOK, BOOK_SNAME and BOOK_INOUT from the
  // configured current book; the saved detail stamps those values at 2661-2666.
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id LIMIT 2`,
    complete.tenantId,
    complete.coCode,
    complete.lcCode,
    complete.coBook,
  );
  if (rows.length !== 1) {
    throw new GoldBookValidationError(
      rows.length
        ? `digital-gold book configuration is ambiguous: ${complete.coBook}`
        : `digital-gold book not found: ${complete.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  if (mainBook !== 'DG GOLD') {
    throw new GoldBookValidationError(
      `book ${complete.coBook} is ${mainBook || 'unclassified'}, expected DG GOLD`,
    );
  }
  const inout = text(row.BOOK_INOUT).toUpperCase();
  if (inout.length !== 1) {
    throw new GoldBookValidationError(`book ${complete.coBook} has no one-character BOOK_INOUT`);
  }
  return {
    coBook: text(row.CO_BOOK),
    configuredName: text(row.BOOK_NAME) || mainBook,
    mainBook,
    vchType: text(row.BOOK_SNAME) || text(row.CO_BOOK),
    inout,
    dataType: text(row.DATA_TYPE) || 'A',
  };
}

async function oneAccountTx(
  tx: any,
  scope: VoucherScope,
  acCode: string,
): Promise<{ code: string; name: string; mobile: string }> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME","AC_MOBILE" FROM "AC_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    acCode,
  );
  if (rows.length !== 1) {
    throw new GoldBookValidationError(
      rows.length ? `account is ambiguous: ${acCode}` : `account not found: ${acCode}`,
    );
  }
  return {
    code: text(rows[0]!.AC_CODE),
    name: text(rows[0]!.AC_NAME),
    mobile: text(rows[0]!.AC_MOBILE),
  };
}

async function resolveTaxTx(
  tx: any,
  scope: VoucherScope,
  taxCode: string,
): Promise<{ code: string; percent: number; account: string }> {
  if (!taxCode) return { code: '', percent: 0, account: '' };
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAX_CODE","TAX_PRC","TAX_AC" FROM "TAX_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAX_CODE"=$3
        AND coalesce("SR_NO",0)::numeric=0 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    taxCode,
  );
  if (rows.length !== 1 || !text(rows[0]!.TAX_AC)) {
    throw new GoldBookValidationError(
      rows.length ? `tax configuration is ambiguous: ${taxCode}` : `tax not found: ${taxCode}`,
    );
  }
  await oneAccountTx(tx, scope, text(rows[0]!.TAX_AC));
  return {
    code: text(rows[0]!.TAX_CODE),
    percent: number(rows[0]!.TAX_PRC),
    account: text(rows[0]!.TAX_AC),
  };
}

async function validateEmployeeTx(tx: any, input: GoldBookInput): Promise<string> {
  const employee = text(input.employeeCode);
  if (!employee) return '';
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    employee,
  );
  if (rows.length !== 1) throw new GoldBookValidationError(`employee not found: ${employee}`);
  return employee;
}

async function resolveLinesTx(tx: any, input: GoldBookInput): Promise<ResolvedLine[]> {
  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new GoldBookValidationError('at least one digital-gold line is required');
  }
  const rows: ResolvedLine[] = [];
  for (const line of input.lines) {
    const acCode = text(line?.acCode);
    const ledgerAccount = text(line?.ledgerAccount);
    const amount = money(number(line?.amount));
    const rate = money(number(line?.rate));
    const fine = number(line?.fine);
    if (!acCode || !ledgerAccount || !Number.isFinite(amount) || amount <= 0) {
      throw new GoldBookValidationError(
        'every digital-gold line requires account, ledger account, and positive amount',
      );
    }
    if (!Number.isFinite(rate) || rate < 0 || !Number.isFinite(fine) || fine < 0) {
      throw new GoldBookValidationError('digital-gold rate and fine must be non-negative numbers');
    }
    // TR_GOLD_BOOK.cs:1908-1999 and 2030-2050 resolve party/LDR account data from AC_MAST;
    // request-provided names, mobile numbers, tax rates and tax accounts are never authoritative.
    const account = await oneAccountTx(tx, input.scope, acCode);
    if (!account.mobile) {
      throw new GoldBookValidationError('Please Insert Mobile No With This Account And Try...');
    }
    await oneAccountTx(tx, input.scope, ledgerAccount);
    const tax = await resolveTaxTx(tx, input.scope, text(line?.taxCode));
    const taxAmount = money((amount * tax.percent) / 100);
    rows.push({
      acCode: account.code,
      acName: account.name,
      mobile: account.mobile,
      amount,
      rate,
      fine,
      ledgerAccount,
      taxCode: tax.code,
      taxPercent: tax.percent,
      taxAmount,
      taxAccount: tax.account,
      total: money(amount + taxAmount),
      description: text(line?.description).slice(0, 100),
    });
  }
  // Ac_Ledr.cs:2306-2314 hard-codes account 00003 for the amount/control leg.
  await oneAccountTx(tx, input.scope, '00003');
  return rows;
}

function baseLedger(
  scope: ReturnType<typeof completeFinanceScope>,
  policy: BookPolicy,
  identity: VoucherIdentity,
  line: ResolvedLine,
  key: string,
) {
  return {
    ...voucherKey(scope, identity.voucherNo),
    VCH_TYPE: policy.vchType,
    VCH_DATE: identity.voucherDate,
    LEDR_KEY: key,
    BOOK_NAME: policy.mainBook,
    BILL_NO: '',
    BILL_DATE: null,
    CHQ_NO: '',
    IT_DESC: line.description,
    ENTRY_TIME: identity.voucherTime,
    HD_VCH_NO: identity.hiddenVoucherNo,
    CLR_DATE: null,
    DATA_TYPE: policy.dataType,
    DATA_TRFR: 'N',
    MAIN_USER: identity.mainUser || null,
    FINE_RATE: 0,
    LDR_NAME: '',
  };
}

async function writeTx(
  tx: any,
  input: GoldBookInput,
  policy: BookPolicy,
  identity: VoucherIdentity,
  lines: ResolvedLine[],
  employeeCode: string,
): Promise<void> {
  const scope = completeFinanceScope(input.scope);
  const key = voucherKey(scope, identity.voucherNo);
  await insertHiddenIdentityTx(tx, scope, identity, policy.configuredName);

  const ledger: Record<string, unknown>[] = [];
  for (let index = 0; index < lines.length; index++) {
    const line = lines[index]!;
    const srNo = index + 1;
    // TR_GOLD_BOOK.cs:2655-2705 is the complete DG_GOLD_DATA save projection.
    await insertRowTx(tx, 'DG_GOLD_DATA', scope.tenantId, {
      ...key,
      SR_NO: srNo,
      VCH_DATE: identity.voucherDate,
      VCH_TIME: identity.voucherTime,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'S',
      BOOK_NAME: policy.mainBook,
      AC_CODE: line.acCode,
      AC_NAME: line.acName,
      AC_MOBILE: line.mobile,
      ITM_RATE: line.rate,
      ITM_AMT: line.amount,
      // TR_GOLD_BOOK.cs stamps the approval-transfer flag plus the metal type and movement sign on
      // every DG_GOLD_DATA row; 'N' means not yet transferred to an approval.
      APP_TRFR: 'N',
      ITM_TYPE: String(line.itType ?? 'G').slice(0, 1),
      ITM_SIGN: String(policy.inout) === 'O' ? '-' : '+',
      ITM_FINE: line.fine,
      LDR_AC: line.ledgerAccount,
      TAX_CODE: line.taxCode,
      TAX_PRC: line.taxPercent,
      TAX_AMT: line.taxAmount,
      TOT_AMT: line.total,
      IT_DESC: line.description,
      HD_VCH_NO: identity.hiddenVoucherNo,
      EMP_CODE: employeeCode,
      DATA_TRFR: 'N',
      DATA_TYPE: 'A',
      MAIN_USER: identity.mainUser || null,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
    });

    // Ac_Ledr.cs:2306-2314: party DR total; 00003 CR item amount; TAX_MAST.TAX_AC
    // CR tax; party CR total with fine metadata; selected/validated LDR_AC DR total.
    const prefix = `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}${srNo}`;
    ledger.push({
      ...baseLedger(scope, policy, identity, line, `${prefix}01`),
      AC_CODE: line.acCode,
      LD_CODE: '00003',
      CR_AMT: 0,
      DR_AMT: line.total,
      IT_TYPE: 'A',
      SIGN: '',
      FINE_WT: 0,
      PARTY_AC_CODE: line.acCode,
    });
    ledger.push({
      ...baseLedger(scope, policy, identity, line, `${prefix}02`),
      AC_CODE: '00003',
      LD_CODE: line.acCode,
      CR_AMT: line.amount,
      DR_AMT: 0,
      IT_TYPE: 'A',
      SIGN: '',
      FINE_WT: 0,
      PARTY_AC_CODE: line.acCode,
    });
    if (line.taxAmount !== 0) {
      ledger.push({
        ...baseLedger(scope, policy, identity, line, `${prefix}03`),
        AC_CODE: line.taxAccount,
        LD_CODE: line.acCode,
        CR_AMT: line.taxAmount,
        DR_AMT: 0,
        IT_TYPE: 'A',
        SIGN: '',
        FINE_WT: 0,
        PARTY_AC_CODE: '',
      });
    }
    ledger.push({
      ...baseLedger(scope, policy, identity, line, `${prefix}04`),
      AC_CODE: line.acCode,
      LD_CODE: line.ledgerAccount,
      CR_AMT: line.total,
      DR_AMT: 0,
      IT_TYPE: 'G',
      SIGN: '+',
      FINE_WT: line.fine,
      IT_DESC: 'Dg Gold Booking',
      FINE_RATE: line.rate,
      PARTY_AC_CODE: line.acCode,
    });
    ledger.push({
      ...baseLedger(scope, policy, identity, line, `${prefix}05`),
      AC_CODE: line.ledgerAccount,
      LD_CODE: line.acCode,
      CR_AMT: 0,
      DR_AMT: line.total,
      IT_TYPE: 'A',
      SIGN: '',
      FINE_WT: 0,
      PARTY_AC_CODE: line.acCode,
    });

    // Ac_Rojmel.cs:1038-1039 creates exactly the 00003 credit and LDR_AC debit rows;
    // the second row is suppressed for the desktop sentinel LDR_AC 00001.
    await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
      ...key,
      LEDR_KEY: `${prefix}R01`,
      VCH_DATE: identity.voucherDate,
      VCH_TYPE: policy.vchType,
      BOOK_NAME: policy.mainBook,
      AC_CODE: '00003',
      LD_CODE: line.acCode,
      CR_AMT: line.total,
      DR_AMT: 0,
      AC_NAME: line.acName,
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
    });
    if (line.ledgerAccount !== '00001') {
      await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
        ...key,
        LEDR_KEY: `${prefix}R02`,
        VCH_DATE: identity.voucherDate,
        VCH_TYPE: policy.vchType,
        BOOK_NAME: policy.mainBook,
        AC_CODE: line.ledgerAccount,
        LD_CODE: line.acCode,
        CR_AMT: 0,
        DR_AMT: line.total,
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
        IT_DESC: line.description,
        IT_CODE: '',
        MEMB_CODE: '',
        SCHM_CODE: '',
        REF_NO: '',
        DATA_TYPE: policy.dataType,
      });
    }
  }
  assertBalanced(ledger);
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);

  const remark = text(input.remark);
  if (remark) {
    await insertRowTx(tx, 'REMARK_DATA', scope.tenantId, {
      ...key,
      SR_NO: 0,
      VCH_DATE: identity.voucherDate,
      AC_CODE: '',
      AC_NAME: '',
      MAIN_BOOK: policy.mainBook,
      VCH_REMARK: remark.slice(0, 250),
    });
  }
}

async function saveTx(
  tx: any,
  input: GoldBookInput,
  requestedVoucherNo?: string,
): Promise<{ voucherNo: string; hiddenVoucherNo: string; created: boolean; lines: number }> {
  const scope = completeFinanceScope(input.scope);
  const policy = await resolveBookTx(tx, scope);
  const { date, iso } = businessDate(input.vchDate);
  await assertFiscalDateTx(tx, scope, iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
  const lines = await resolveLinesTx(tx, input);
  const employeeCode = await validateEmployeeTx(tx, input);
  let identity: VoucherIdentity;
  const created = !requestedVoucherNo;
  if (requestedVoucherNo) {
    const edited = await editIdentityTx(tx, {
      table: 'DG_GOLD_DATA',
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
    // TR_GOLD_BOOK.cs:2634-2713 rewrites the write set and TEMP row on edit, without DELETE_DATA.
    await replaceWriteSetTx(tx, scope, identity.voucherNo, identity.hiddenVoucherNo, [
      'REMARK_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'DG_GOLD_DATA',
    ]);
  } else {
    // TR_GOLD_BOOK.cs:2389 numbers from DG_GOLD_DATA; 2401 independently numbers TEMP_BOOK_DATA
    // by company+location+book without fiscal year. Shared lifecycle helpers preserve both rules.
    identity = await createIdentityTx(tx, scope, date, input.mainUser);
  }
  await writeTx(tx, input, policy, identity, lines, employeeCode);
  return {
    voucherNo: identity.voucherNo,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    created,
    lines: lines.length,
  };
}

export async function saveGoldBook(prisma: any, input: GoldBookInput, requestedVoucherNo?: string) {
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getGoldBook(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveBookTx(tx, scope);
    // TR_GOLD_BOOK.cs:2419-2460 loads the complete voucher and preserves HD_VCH_NO,
    // MAIN_USER and VCH_TIME while resolving display names from AC_MAST.
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT d.*,d."VCH_DATE"::text AS "VCH_DAY",to_char(d."VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK",
              coalesce(a."AC_NAME",d."AC_NAME",'') AS "MASTER_AC_NAME",
              coalesce(a."AC_MOBILE",d."AC_MOBILE",'') AS "MASTER_MOBILE"
         FROM "DG_GOLD_DATA" d
         LEFT JOIN "AC_MAST" a ON a.tenant_id=d.tenant_id AND a."CO_CODE"=d."CO_CODE"
                              AND a."AC_CODE"=d."AC_CODE"
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
      throw new GoldBookValidationError(`digital-gold voucher not found: ${voucherNo}`);
    const h = rows[0]!;
    const remarks: Array<{ VCH_REMARK: unknown }> = await tx.$queryRawUnsafe(
      `SELECT "VCH_REMARK" FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2
        AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    return {
      voucherNo,
      vchDate: text(h.VCH_DAY).slice(0, 10),
      voucherTime: text(h.VCH_CLOCK),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      employeeCode: text(h.EMP_CODE),
      remark: remarks
        .map((row) => text(row.VCH_REMARK))
        .filter(Boolean)
        .join(' '),
      lines: rows.map((row) => ({
        srNo: number(row.SR_NO),
        acCode: text(row.AC_CODE),
        acName: text(row.MASTER_AC_NAME),
        mobile: text(row.MASTER_MOBILE),
        amount: number(row.ITM_AMT),
        rate: number(row.ITM_RATE),
        fine: number(row.ITM_FINE),
        ledgerAccount: text(row.LDR_AC),
        taxCode: text(row.TAX_CODE),
        taxPercent: number(row.TAX_PRC),
        taxAmount: number(row.TAX_AMT),
        total: number(row.TOT_AMT),
        description: text(row.IT_DESC),
      })),
    };
  });
}

export async function deleteGoldBook(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
): Promise<{ reversed: true }> {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveBookTx(tx, scope);
    const edited = await editIdentityTx(tx, {
      table: 'DG_GOLD_DATA',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      checkRequestedDate: false,
    });
    const persistedIso = new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10);
    await assertFiscalDateTx(tx, scope, persistedIso);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "DG_GOLD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    // TR_GOLD_BOOK.cs:2758 inserts one DELETE_DATA row per DG_GOLD_DATA row: both amount
    // columns receive TOT_AMT, AC_NAME is blank, FINE_TYPE=A, fine DR/CR are zero, and IT_DESC
    // is the description. Lines 2760-2764 then remove the complete write set and TEMP identity.
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: { name: policy.configuredName, shortName: policy.vchType },
      header: rows[0]!,
      deleteUser,
      rows: rows.map((row) => ({
        srNo: number(row.SR_NO),
        acCode: row.AC_CODE,
        acName: '',
        valueDr: number(row.TOT_AMT),
        valueCr: number(row.TOT_AMT),
        fineType: 'A',
        fineDr: 0,
        fineCr: 0,
        description: text(row.IT_DESC),
      })),
    });
    await replaceWriteSetTx(tx, scope, voucherNo, edited.identity.hiddenVoucherNo, [
      'REMARK_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'DG_GOLD_DATA',
    ]);
    return { reversed: true };
  });
}
