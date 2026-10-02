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

export class LocationAmountValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'LocationAmountValidationError';
  }
}

// Desktop validation evidence (TR_LOCT_AMT.cs:3030-3090,3443-3466): employee mandatory is
// "Please Select Employee Code and Try......"; company type B, fiscal-year, lock, rights and
// missing-number checks use the same exact messages documented in TR_GOLD_BOOK. The received-OUT
// delete rejection is preserved verbatim below. Web route guards own rights; shared lifecycle code
// owns fail-closed fiscal and period checks, and no request-supplied licence/company state is trusted.

export interface LocationAmountLineInput {
  acCode: string;
  amount: number;
  chequeNo?: string;
  description?: string;
}

export interface LocationAmountInput {
  scope: VoucherScope;
  vchDate: string | Date;
  employeeCode?: string;
  remark?: string;
  toLocation?: string;
  fromLocation?: string;
  fromBook?: string;
  fromVoucherNo?: string;
  lines: LocationAmountLineInput[];
  mainUser?: string;
}

type BookPolicy = {
  coBook: string;
  configuredName: string;
  mainBook: 'AMT IN' | 'AMT OUT';
  vchType: string;
  inout: 'I' | 'O';
  dataType: string;
};

type ResolvedLine = {
  acCode: string;
  acName: string;
  amount: number;
  chequeNo: string;
  description: string;
};

type TransferIdentity = {
  fromLocation: string;
  fromBook: string;
  fromVoucherNo: string;
  toLocation: string;
  toBook: string;
  toVoucherNo: string;
};

const number = (value: unknown): number => Number(value ?? 0);
const money = (value: number): number => Math.round((value + Number.EPSILON) * 100) / 100;
const DESTINATION_BOOK = '159';

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new LocationAmountValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new LocationAmountValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

async function resolveBookAtTx(
  tx: any,
  scope: VoucherScope,
  lcCode = scope.lcCode,
  coBook = scope.coBook,
): Promise<BookPolicy> {
  const complete = completeFinanceScope(scope);
  // TR_LOCT_AMT.cs:2818-2836 copies MAIN_BOOK, BOOK_SNAME and BOOK_INOUT from the
  // configured current book; source rows stamp those fields at 3160-3185 and 3267-3292.
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE"
       FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id LIMIT 2`,
    complete.tenantId,
    complete.coCode,
    lcCode,
    coBook,
  );
  if (rows.length !== 1) {
    throw new LocationAmountValidationError(
      rows.length
        ? `location-amount book configuration is ambiguous: ${coBook}`
        : `location-amount book not found: ${coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  if (mainBook !== 'AMT IN' && mainBook !== 'AMT OUT') {
    throw new LocationAmountValidationError(
      `book ${coBook} is ${mainBook || 'unclassified'}, expected AMT IN or AMT OUT`,
    );
  }
  const expected = mainBook === 'AMT OUT' ? 'O' : 'I';
  const inout = text(row.BOOK_INOUT).toUpperCase();
  if (inout !== expected) {
    throw new LocationAmountValidationError(
      `book ${coBook} direction is ${inout || 'blank'}, expected ${expected}`,
    );
  }
  return {
    coBook: text(row.CO_BOOK),
    configuredName: text(row.BOOK_NAME) || mainBook,
    mainBook,
    vchType: text(row.BOOK_SNAME) || text(row.CO_BOOK),
    inout: expected,
    dataType: text(row.DATA_TYPE) || 'A',
  };
}

async function accountTx(
  tx: any,
  scope: VoucherScope,
  acCode: string,
): Promise<{ code: string; name: string }> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "AC_CODE","AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
      AND "AC_CODE"=$3 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    acCode,
  );
  if (rows.length !== 1) {
    throw new LocationAmountValidationError(
      rows.length ? `account is ambiguous: ${acCode}` : `account not found: ${acCode}`,
    );
  }
  return { code: text(rows[0]!.AC_CODE), name: text(rows[0]!.AC_NAME) };
}

async function locationTx(
  tx: any,
  scope: VoucherScope,
  lcCode: string,
): Promise<{ location: string; account: string }> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "LC_CODE","AC_CODE" FROM "LOCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
      AND "LC_CODE"=$3 ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    lcCode,
  );
  const acCode = rows.length === 1 ? text(rows[0]!.AC_CODE) : '';
  if (rows.length !== 1 || !acCode) {
    throw new LocationAmountValidationError(
      rows.length
        ? `location account is ambiguous or blank: ${lcCode}`
        : `location not found: ${lcCode}`,
    );
  }
  await accountTx(tx, scope, acCode);
  return { location: text(rows[0]!.LC_CODE), account: acCode };
}

async function resolveLinesTx(tx: any, input: LocationAmountInput): Promise<ResolvedLine[]> {
  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new LocationAmountValidationError('at least one location-amount line is required');
  }
  const result: ResolvedLine[] = [];
  for (const line of input.lines) {
    const acCode = text(line?.acCode);
    const amount = money(number(line?.amount));
    if (!acCode || !Number.isFinite(amount) || amount <= 0) {
      throw new LocationAmountValidationError(
        'every location-amount line requires an account and positive amount',
      );
    }
    // TR_LOCT_AMT.cs:2408-2480 resolves the line account from AC_MAST. AC_NAME supplied by a
    // client is ignored, and the persisted name is always the server-side master value.
    const account = await accountTx(tx, input.scope, acCode);
    result.push({
      acCode: account.code,
      acName: account.name,
      amount,
      chequeNo: text(line?.chequeNo).slice(0, 2),
      description: text(line?.description).slice(0, 200),
    });
  }
  return result;
}

async function employeeTx(tx: any, input: LocationAmountInput): Promise<string> {
  const settings: Array<{ EMP_CODE_MANDATORY: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "EMP_CODE_MANDATORY" FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2
      ORDER BY row_id LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
  );
  if (settings.length !== 1) {
    throw new LocationAmountValidationError(
      `employee configuration is ${settings.length ? 'ambiguous' : 'missing'}`,
    );
  }
  const employee = text(input.employeeCode);
  // TR_LOCT_AMT.cs:3034-3041 uses this exact desktop message when employee entry is mandatory.
  if (text(settings[0]!.EMP_CODE_MANDATORY).toUpperCase() === 'Y' && !employee) {
    throw new LocationAmountValidationError('Please Select Employee Code and Try......');
  }
  if (!employee) return '';
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 2`,
    input.scope.tenantId,
    input.scope.coCode,
    employee,
  );
  if (rows.length !== 1) throw new LocationAmountValidationError(`employee not found: ${employee}`);
  return employee;
}

async function nextDestinationNoTx(tx: any, scope: VoucherScope, lcCode: string): Promise<string> {
  const complete = completeFinanceScope(scope);
  await tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    [
      'loct-amt-destination',
      complete.tenantId,
      complete.coCode,
      lcCode,
      complete.coYear,
      DESTINATION_BOOK,
    ].join('|'),
  );
  // TR_LOCT_AMT.cs:3095-3105 hard-codes destination book 159 and numbers its LOCT_AMT voucher
  // independently by destination company/location/year/book.
  const rows: Array<{ max_no: unknown }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(max(CASE WHEN "VCH_NO"::text ~ '^[0-9]+$' THEN "VCH_NO"::int END),0)::int AS max_no
       FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5`,
    complete.tenantId,
    complete.coCode,
    lcCode,
    complete.coYear,
    DESTINATION_BOOK,
  );
  return formatVoucherNo(number(rows[0]?.max_no) + 1);
}

async function transferForCreateTx(
  tx: any,
  input: LocationAmountInput,
  policy: BookPolicy,
  identity: VoucherIdentity,
): Promise<TransferIdentity> {
  const scope = completeFinanceScope(input.scope);
  if (policy.mainBook === 'AMT OUT') {
    const toLocation = text(input.toLocation);
    if (!toLocation || toLocation === scope.lcCode) {
      throw new LocationAmountValidationError('AMT OUT requires a different destination location');
    }
    await locationTx(tx, scope, toLocation);
    const destinationPolicy = await resolveBookAtTx(tx, scope, toLocation, DESTINATION_BOOK);
    if (destinationPolicy.mainBook !== 'AMT IN') {
      throw new LocationAmountValidationError(
        `destination book ${DESTINATION_BOOK} at ${toLocation} is not AMT IN`,
      );
    }
    return {
      fromLocation: scope.lcCode,
      fromBook: scope.coBook,
      fromVoucherNo: identity.voucherNo,
      toLocation,
      toBook: DESTINATION_BOOK,
      toVoucherNo: await nextDestinationNoTx(tx, scope, toLocation),
    };
  }
  const fromLocation = text(input.fromLocation);
  const fromBook = text(input.fromBook);
  const fromVoucherNo = text(input.fromVoucherNo);
  if (!fromLocation || !fromBook || !fromVoucherNo) {
    throw new LocationAmountValidationError(
      'AMT IN requires source location, source book, and source voucher number',
    );
  }
  await locationTx(tx, scope, fromLocation);
  return {
    fromLocation,
    fromBook,
    fromVoucherNo: formatVoucherNo(fromVoucherNo),
    toLocation: scope.lcCode,
    toBook: scope.coBook,
    toVoucherNo: identity.voucherNo,
  };
}

async function persistedTransferTx(
  tx: any,
  scope: ReturnType<typeof completeFinanceScope>,
  voucherNo: string,
): Promise<TransferIdentity> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "FROM_LC_CODE","FROM_CO_BOOK","FROM_VCH_NO","TO_LC_CODE","TO_CO_BOOK","TO_VCH_NO"
       FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const first = rows[0];
  const transferColumns = [
    'FROM_LC_CODE',
    'FROM_CO_BOOK',
    'FROM_VCH_NO',
    'TO_LC_CODE',
    'TO_CO_BOOK',
    'TO_VCH_NO',
  ] as const;
  if (
    !first ||
    rows.some((row) => transferColumns.some((column) => text(row[column]) !== text(first[column])))
  ) {
    throw new LocationAmountValidationError('persisted transfer identity is missing or ambiguous');
  }
  return {
    fromLocation: text(first.FROM_LC_CODE),
    fromBook: text(first.FROM_CO_BOOK),
    fromVoucherNo: text(first.FROM_VCH_NO),
    toLocation: text(first.TO_LC_CODE),
    toBook: text(first.TO_CO_BOOK),
    toVoucherNo: text(first.TO_VCH_NO),
  };
}

async function deleteMirrorTx(
  tx: any,
  scope: ReturnType<typeof completeFinanceScope>,
  transfer: TransferIdentity,
): Promise<void> {
  await tx.$executeRawUnsafe(
    `DELETE FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
    scope.tenantId,
    scope.coCode,
    transfer.toLocation,
    scope.coYear,
    transfer.toBook,
    transfer.toVoucherNo,
  );
}

function commonLedger(
  scope: ReturnType<typeof completeFinanceScope>,
  policy: BookPolicy,
  identity: VoucherIdentity,
  line: ResolvedLine,
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
    LDR_NAME: '',
  };
}

async function writeTx(
  tx: any,
  input: LocationAmountInput,
  policy: BookPolicy,
  identity: VoucherIdentity,
  transfer: TransferIdentity,
  lines: ResolvedLine[],
  employeeCode: string,
): Promise<void> {
  const scope = completeFinanceScope(input.scope);
  const locationCode = policy.mainBook === 'AMT OUT' ? transfer.toLocation : transfer.fromLocation;
  const location = await locationTx(tx, scope, locationCode);
  if (policy.mainBook === 'AMT OUT') {
    await insertHiddenIdentityTx(tx, scope, identity, policy.configuredName);
  }
  const key = voucherKey(scope, identity.voucherNo);
  const ledger: Record<string, unknown>[] = [];

  for (let index = 0; index < lines.length; index++) {
    const line = lines[index]!;
    const srNo = index + 1;
    // TR_LOCT_AMT.cs:3160-3203 and 3267-3308 are the complete source LOCT_AMT projection.
    await insertRowTx(tx, 'LOCT_AMT', scope.tenantId, {
      ...key,
      SR_NO: srNo,
      VCH_DATE: identity.voucherDate,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'B',
      BOOK_NAME: policy.mainBook,
      FROM_LC_CODE: transfer.fromLocation,
      TO_LC_CODE: transfer.toLocation,
      AC_CODE: line.acCode,
      AC_NAME: line.acName,
      CHQ_NO: line.chequeNo,
      REC_AMT: line.amount,
      IT_DESC: line.description,
      EMP_CODE: employeeCode,
      DATA_TRFR: 'N',
      HD_VCH_NO: identity.hiddenVoucherNo,
      USER_UPDATE: 'N',
      USER_DELETE: 'N',
      MAIN_USER: identity.mainUser || null,
      AMT_TRFR: policy.mainBook === 'AMT IN' ? 'Y' : 'N',
      VCH_TIME: identity.voucherTime,
      FROM_CO_BOOK: transfer.fromBook,
      FROM_VCH_NO: transfer.fromVoucherNo,
      TO_CO_BOOK: transfer.toBook,
      TO_VCH_NO: transfer.toVoucherNo,
    });

    const prefix = `${scope.coCode}${scope.lcCode}${scope.coYear}${scope.coBook}${identity.voucherNo}${srNo}`;
    // Ac_Ledr.cs:1989-1996 obtains the contra from LOCT_MAST.AC_CODE. AMT IN credits the
    // source-location account and debits the party; AMT OUT debits destination-location and
    // credits the party. No request-supplied location account is accepted.
    if (policy.mainBook === 'AMT IN') {
      ledger.push({
        ...commonLedger(scope, policy, identity, line, `${prefix}01`),
        AC_CODE: location.account,
        LD_CODE: line.acCode,
        CR_AMT: line.amount,
        DR_AMT: 0,
        PARTY_AC_CODE: line.acCode,
      });
      ledger.push({
        ...commonLedger(scope, policy, identity, line, `${prefix}02`),
        AC_CODE: line.acCode,
        LD_CODE: location.account,
        CR_AMT: 0,
        DR_AMT: line.amount,
        PARTY_AC_CODE: '',
      });
    } else {
      ledger.push({
        ...commonLedger(scope, policy, identity, line, `${prefix}03`),
        AC_CODE: location.account,
        LD_CODE: line.acCode,
        CR_AMT: 0,
        DR_AMT: line.amount,
        PARTY_AC_CODE: line.acCode,
      });
      ledger.push({
        ...commonLedger(scope, policy, identity, line, `${prefix}04`),
        AC_CODE: line.acCode,
        LD_CODE: location.account,
        CR_AMT: line.amount,
        DR_AMT: 0,
        PARTY_AC_CODE: '',
      });
    }

    // Ac_Rojmel.cs:945-951 emits the same location/party monetary pair, suppressing the party
    // row only for desktop sentinel account 00001.
    const incoming = policy.mainBook === 'AMT IN';
    await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
      ...key,
      LEDR_KEY: `${prefix}R1`,
      VCH_DATE: identity.voucherDate,
      VCH_TYPE: policy.vchType,
      BOOK_NAME: policy.mainBook,
      AC_CODE: location.account,
      LD_CODE: line.acCode,
      CR_AMT: incoming ? line.amount : 0,
      DR_AMT: incoming ? 0 : line.amount,
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
    if (line.acCode !== '00001') {
      await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, {
        ...key,
        LEDR_KEY: `${prefix}R2`,
        VCH_DATE: identity.voucherDate,
        VCH_TYPE: policy.vchType,
        BOOK_NAME: policy.mainBook,
        AC_CODE: line.acCode,
        LD_CODE: location.account,
        CR_AMT: incoming ? 0 : line.amount,
        DR_AMT: incoming ? line.amount : 0,
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

  if (policy.mainBook === 'AMT OUT') {
    // TR_LOCT_AMT.cs:3206-3260 writes the mirrored AMTIN rows at destination book 159 without a
    // destination TEMP row; HD_VCH_NO is the destination main voucher number.
    for (let index = 0; index < lines.length; index++) {
      const line = lines[index]!;
      await insertRowTx(tx, 'LOCT_AMT', scope.tenantId, {
        CO_CODE: scope.coCode,
        LC_CODE: transfer.toLocation,
        CO_YEAR: scope.coYear,
        CO_BOOK: transfer.toBook,
        VCH_NO: transfer.toVoucherNo,
        SR_NO: index + 1,
        VCH_DATE: identity.voucherDate,
        VCH_TYPE: 'AMTIN',
        INOUT_TYPE: 'I',
        ENTRY_TYPE: 'B',
        BOOK_NAME: 'AMT IN',
        FROM_LC_CODE: transfer.fromLocation,
        TO_LC_CODE: transfer.toLocation,
        AC_CODE: line.acCode,
        AC_NAME: line.acName,
        CHQ_NO: line.chequeNo,
        REC_AMT: line.amount,
        IT_DESC: line.description,
        EMP_CODE: '',
        DATA_TRFR: 'N',
        HD_VCH_NO: transfer.toVoucherNo,
        USER_UPDATE: 'N',
        USER_DELETE: 'N',
        MAIN_USER: identity.mainUser || null,
        AMT_TRFR: 'N',
        VCH_TIME: identity.voucherTime,
        FROM_CO_BOOK: transfer.fromBook,
        FROM_VCH_NO: transfer.fromVoucherNo,
        TO_CO_BOOK: transfer.toBook,
        TO_VCH_NO: transfer.toVoucherNo,
      });
    }
  }

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

async function saveTx(tx: any, input: LocationAmountInput, requestedVoucherNo?: string) {
  const scope = completeFinanceScope(input.scope);
  const policy = await resolveBookAtTx(tx, scope);
  const { date, iso } = businessDate(input.vchDate);
  await assertFiscalDateTx(tx, scope, iso);
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
  const lines = await resolveLinesTx(tx, input);
  const employeeCode = await employeeTx(tx, input);
  const created = !requestedVoucherNo;
  if (created && policy.mainBook === 'AMT IN') {
    // TR_LOCT_AMT.cs:3206-3260 creates AMT IN as the mirrored side of AMT OUT, while
    // 3263-3308 marks that loaded mirror received (AMT_TRFR=Y). It does not establish an
    // unambiguous standalone AMT IN creation path, so POST refuses to invent one.
    throw new LocationAmountValidationError(
      'AMT IN must load an existing mirrored transfer before update',
    );
  }
  let identity: VoucherIdentity;
  let transfer: TransferIdentity;
  if (requestedVoucherNo) {
    const edited = await editIdentityTx(tx, {
      table: 'LOCT_AMT',
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
    transfer = await persistedTransferTx(tx, scope, identity.voucherNo);
    if (policy.mainBook === 'AMT OUT') {
      const requestedDestination = text(input.toLocation) || transfer.toLocation;
      if (requestedDestination !== transfer.toLocation) {
        throw new LocationAmountValidationError('AMT OUT destination cannot change on edit');
      }
      await deleteMirrorTx(tx, scope, transfer);
    }
    // TR_LOCT_AMT.cs:3135-3330 rewrites source, mirror, TEMP, ledger, rojmel and remark on edit;
    // it does not insert DELETE_DATA.
    await replaceWriteSetTx(tx, scope, identity.voucherNo, identity.hiddenVoucherNo, [
      'REMARK_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'LOCT_AMT',
    ]);
  } else {
    // TR_LOCT_AMT.cs:2857 numbers LOCT_AMT; 2869 independently numbers TEMP_BOOK_DATA without year.
    identity = await createIdentityTx(tx, scope, date, input.mainUser);
    transfer = await transferForCreateTx(tx, input, policy, identity);
  }
  await writeTx(tx, input, policy, identity, transfer, lines, employeeCode);
  return {
    voucherNo: identity.voucherNo,
    hiddenVoucherNo: identity.hiddenVoucherNo,
    created,
    lines: lines.length,
    transfer,
  };
}

export async function saveLocationAmount(
  prisma: any,
  input: LocationAmountInput,
  requestedVoucherNo?: string,
) {
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getLocationAmount(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
) {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveBookAtTx(tx, scope);
    // TR_LOCT_AMT.cs:2887-2935 loads all detail and preserves HD_VCH_NO, MAIN_USER,
    // VCH_TIME and both sides of the transfer identity.
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT l.*,l."VCH_DATE"::text AS "VCH_DAY",to_char(l."VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK",
              coalesce(a."AC_NAME",l."AC_NAME",'') AS "MASTER_AC_NAME"
         FROM "LOCT_AMT" l LEFT JOIN "AC_MAST" a ON a.tenant_id=l.tenant_id
          AND a."CO_CODE"=l."CO_CODE" AND a."AC_CODE"=l."AC_CODE"
        WHERE l.tenant_id=$1 AND l."CO_CODE"=$2 AND l."LC_CODE"=$3 AND l."CO_YEAR"=$4
          AND l."CO_BOOK"=$5 AND l."VCH_NO"=$6 ORDER BY l."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (!rows.length) {
      throw new LocationAmountValidationError(`location-amount voucher not found: ${voucherNo}`);
    }
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
      mainBook: text(h.BOOK_NAME),
      fromLocation: text(h.FROM_LC_CODE),
      fromBook: text(h.FROM_CO_BOOK),
      fromVoucherNo: text(h.FROM_VCH_NO),
      toLocation: text(h.TO_LC_CODE),
      toBook: text(h.TO_CO_BOOK),
      toVoucherNo: text(h.TO_VCH_NO),
      amountTransferred: text(h.AMT_TRFR),
      remark: remarks
        .map((row) => text(row.VCH_REMARK))
        .filter(Boolean)
        .join(' '),
      lines: rows.map((row) => ({
        srNo: number(row.SR_NO),
        acCode: text(row.AC_CODE),
        acName: text(row.MASTER_AC_NAME),
        chequeNo: text(row.CHQ_NO),
        amount: number(row.REC_AMT),
        description: text(row.IT_DESC),
      })),
    };
  });
}

export async function deleteLocationAmount(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: string,
  deleteUser?: string,
): Promise<{ reversed: true }> {
  const scope = completeFinanceScope(scopeInput);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const policy = await resolveBookAtTx(tx, scope);
    const edited = await editIdentityTx(tx, {
      table: 'LOCT_AMT',
      scope,
      requestedVoucherNo: voucherNo,
      requestedDate: new Date(),
      checkRequestedDate: false,
    });
    await assertFiscalDateTx(
      tx,
      scope,
      new Date(edited.persisted.VCH_DATE as any).toISOString().slice(0, 10),
    );
    const transfer = await persistedTransferTx(tx, scope, voucherNo);
    if (policy.mainBook === 'AMT OUT') {
      const received: unknown[] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND upper(coalesce("AMT_TRFR",''))='Y' LIMIT 1`,
        scope.tenantId,
        scope.coCode,
        transfer.toLocation,
        scope.coYear,
        transfer.toBook,
        transfer.toVoucherNo,
      );
      // TR_LOCT_AMT.cs:3457-3466 rejects deletion after the destination branch receives the mirror.
      if (received.length) {
        throw new LocationAmountValidationError(
          'You Cant Delete This Voucher Because Outword Branch Received This Voucher Please Detlet First Out Word Branch Vch First...',
        );
      }
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "LOCT_AMT" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    // TR_LOCT_AMT.cs:3471 maps each detail to DELETE_DATA: VCH_TYPE/BOOK_NAME from BOOK_DATA,
    // OUT amount to VCH_VAL_DR, IN amount to VCH_VAL_CR, FINE_TYPE=A, both fine values zero,
    // and IT_DESC truncated to 149. Lines 3472-3484 remove source, TEMP and the OUT mirror.
    await insertDesktopDeleteAuditTx(tx, {
      scope,
      configuredBook: { name: policy.configuredName, shortName: policy.vchType },
      header: rows[0]!,
      deleteUser,
      rows: rows.map((row) => ({
        srNo: number(row.SR_NO),
        acCode: row.AC_CODE,
        acName: row.AC_NAME,
        valueDr: text(row.INOUT_TYPE).toUpperCase() === 'O' ? number(row.REC_AMT) : 0,
        valueCr: text(row.INOUT_TYPE).toUpperCase() === 'I' ? number(row.REC_AMT) : 0,
        fineType: 'A',
        fineDr: 0,
        fineCr: 0,
        description: text(row.IT_DESC),
      })),
    });
    if (policy.mainBook === 'AMT OUT') await deleteMirrorTx(tx, scope, transfer);
    await replaceWriteSetTx(tx, scope, voucherNo, edited.identity.hiddenVoucherNo, [
      'REMARK_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'LOCT_AMT',
    ]);
    return { reversed: true };
  });
}
