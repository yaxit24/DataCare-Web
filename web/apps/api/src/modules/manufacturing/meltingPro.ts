import { withTenant } from '@datacare/db';
import { assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import {
  assertFiscalDateTx as assertVoucherFiscalDateTx,
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  buildMeltingStockProjections,
  calculateMeltingOutRow,
  calculateMeltingOutTotals,
  calculateMeltingResultRow,
  meltingRound3,
  type MeltingOutInput,
  type MeltingOutRow,
  type MeltingResultInput,
  type MeltingResultRow,
} from './meltingParity.js';

export class MeltingProValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'MeltingProValidationError';
  }
}

export interface MeltingProOutInput extends MeltingOutInput {
  itemName?: string;
  itemType?: string;
}

export interface MeltingProResultInput extends MeltingResultInput {
  pieces?: number;
  itemName?: string;
  itemType?: string;
}

export interface MeltingProInput {
  scope: VoucherScope;
  vchDate: string | Date;
  acCode?: string;
  acName?: string;
  employeeCode?: string;
  description?: string;
  lotNo?: string;
  mainUser?: string;
  deleteUser?: string;
  outLines: MeltingProOutInput[];
  resultLines: MeltingProResultInput[];
}

interface MeltingBookPolicy {
  coBook: string;
  vchType: string;
  displayName: string;
  mainBook: 'MLT PRO';
  inout: string;
  dataType: string;
}

interface PersistedHeader {
  VCH_NO: unknown;
  VCH_DATE: unknown;
  VCH_TIME: unknown;
  VCH_CLOCK: unknown;
  HD_VCH_NO: unknown;
  MAIN_USER: unknown;
}

const text = (value: unknown): string => String(value ?? '').trim();
const n = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));

function completeScope(
  scope: VoucherScope,
): asserts scope is VoucherScope & { coYear: string; coBook: string } {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new MeltingProValidationError(
      'melting requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new MeltingProValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new MeltingProValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

async function resolveBookTx(tx: any, scope: VoucherScope): Promise<MeltingBookPolicy> {
  completeScope(scope);
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME",
              "DATA_TYPE",row_id,CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce(nullif(upper(btrim("CUR_USE"::text)),''),'Y') <> 'N'
     ) SELECT * FROM candidates
        WHERE priority=(SELECT min(priority) FROM candidates) ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.coBook,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new MeltingProValidationError(
      rows.length
        ? `melting book configuration is ambiguous: ${scope.coBook}`
        : `melting book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  if (mainBook !== 'MLT PRO') {
    throw new MeltingProValidationError(
      `book ${scope.coBook} is ${mainBook || 'unclassified'}, expected MLT PRO`,
    );
  }
  const table = text(row.BOOK_TBL_NAME).toUpperCase();
  if (table && table !== 'MLT_DATA') {
    throw new MeltingProValidationError(`book ${scope.coBook} writes ${table}, expected MLT_DATA`);
  }
  const inout = text(row.BOOK_INOUT).toUpperCase();
  if (inout.length !== 1) {
    throw new MeltingProValidationError(`book ${scope.coBook} has no one-character BOOK_INOUT`);
  }
  return {
    coBook: text(row.CO_BOOK),
    vchType: text(row.BOOK_SNAME) || text(row.CO_BOOK),
    displayName: text(row.BOOK_NAME) || 'MLT PRO',
    mainBook: 'MLT PRO',
    inout,
    dataType: text(row.DATA_TYPE) || 'A',
  };
}

async function assertFiscalDateTx(
  tx: any,
  scope: VoucherScope & { coYear: string },
  iso: string,
): Promise<void> {
  try {
    await assertVoucherFiscalDateTx(tx, scope, iso);
  } catch (error) {
    if (error instanceof Error && error.name === 'FiscalDateValidationError') {
      throw new MeltingProValidationError(error.message);
    }
    throw error;
  }
}

async function assertOpenTx(
  tx: any,
  tenantId: string,
  coCode: string,
  date: unknown,
): Promise<void> {
  await assertPeriodOpen(tx, tenantId, {
    writes: [{ table: 'MLT_DATA', rows: [{ CO_CODE: coCode, VCH_DATE: date }] }],
    ledger: { table: 'AC_DATA', lines: [] },
  });
}

function voucherKey(
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Record<string, unknown> {
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
}

async function headerForUpdateTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
): Promise<PersistedHeader> {
  try {
    return await persistedVoucherHeaderTx(tx, {
      table: 'MLT_DATA',
      scope,
      voucherNo,
      extraColumns: [],
    });
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new MeltingProValidationError(`melting voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new MeltingProValidationError(`melting voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
}

async function auditDetailsTx(
  tx: any,
  scope: VoucherScope & { coYear: string; coBook: string },
  voucherNo: string,
  policy: MeltingBookPolicy,
  deleteUser: string,
): Promise<number> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "MLT_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
      AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "ENTRY_TYPE","SR_NO" FOR UPDATE`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const now = new Date();
  for (const row of rows) {
    const inout = text(row.INOUT_TYPE);
    await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
      CO_CODE: row.CO_CODE,
      LC_CODE: row.LC_CODE,
      CO_YEAR: row.CO_YEAR,
      CO_BOOK: row.CO_BOOK,
      VCH_NO: row.VCH_NO,
      SR_NO: n(row.SR_NO),
      VCH_DATE: row.VCH_DATE,
      DELETE_DATE: now,
      VCH_TYPE: policy.vchType,
      VCH_TIME: row.VCH_TIME,
      DELETE_TIME: now,
      BOOK_NAME: policy.displayName,
      AC_CODE: text(row.AC_CODE),
      AC_NAME: '',
      VCH_VAL_DR: inout === 'O' ? n(row.ITM_NWT) : 0,
      VCH_VAL_CR: inout === 'I' ? n(row.ITM_NWT) : 0,
      FINE_TYPE: 'A',
      VCH_FINE_DR: 0,
      VCH_FINE_CR: 0,
      HD_VCH_NO: text(row.HD_VCH_NO),
      MAIN_USER: text(row.MAIN_USER),
      DELETE_USER: deleteUser.slice(0, 15),
      VCH_DESC: text(row.IT_NAME).slice(0, 50),
    });
  }
  return rows.length;
}

function prepare(input: MeltingProInput): {
  outRows: Array<MeltingOutRow & MeltingProOutInput>;
  resultRows: Array<MeltingResultRow & MeltingProResultInput>;
  totals: ReturnType<typeof calculateMeltingOutTotals>;
} {
  if (!Array.isArray(input.outLines) || !Array.isArray(input.resultLines)) {
    throw new MeltingProValidationError('material-out and result lines are required');
  }
  const outRows = input.outLines.map((row) => ({ ...row, ...calculateMeltingOutRow(row) }));
  const totals = calculateMeltingOutTotals(outRows);
  const resultRows = input.resultLines.map((row, rowIndex) => ({
    ...row,
    ...calculateMeltingResultRow(row, {
      rowIndex,
      totalInputGrossWt: totals.grossWt,
      averageTouch: totals.averageTouch,
    }),
  }));
  if (!outRows.length && !resultRows.length) {
    throw new MeltingProValidationError('at least one material-out or result line is required');
  }
  if (!resultRows.length) {
    throw new MeltingProValidationError('at least one melting result line is required');
  }
  if (totals.grossWt === 0 && !text(input.acCode)) {
    throw new MeltingProValidationError(
      'party/account is required when material-out weight is zero',
    );
  }
  for (const row of resultRows) {
    if ((row.fineAdd !== 0 || row.conWt !== 0) && !text(row.conItCode)) {
      throw new MeltingProValidationError(
        'conversion item is required for conversion/add-fine weight',
      );
    }
    if (row.returnWt !== 0 && !text(row.returnItCode)) {
      throw new MeltingProValidationError('return item is required for return weight');
    }
  }
  return { outRows, resultRows, totals };
}

async function insertStockTx(
  tx: any,
  input: MeltingProInput,
  policy: MeltingBookPolicy,
  voucherNo: string,
  date: Date,
  time: Date,
  outRows: Array<MeltingOutRow & MeltingProOutInput>,
  resultRows: Array<MeltingResultRow & MeltingProResultInput>,
): Promise<number> {
  const projections = buildMeltingStockProjections({
    outRows,
    resultRows,
    acCode: text(input.acCode) || undefined,
  });
  const key = voucherKey(
    input.scope as VoucherScope & { coYear: string; coBook: string },
    voucherNo,
  );
  for (const row of projections) {
    const source = row.isrNo === 1 ? outRows[row.sourceRow - 1]! : resultRows[row.sourceRow - 1]!;
    const result = row.isrNo === 1 ? undefined : resultRows[row.sourceRow - 1]!;
    const pcs =
      row.isrNo === 1 || row.isrNo === 2 || row.isrNo === 5 ? n((source as any).pieces) : 0;
    const mainTouch =
      row.isrNo === 4
        ? n(result?.conPct)
        : row.isrNo === 5
          ? n(result?.conPct) || n(result?.touch)
          : row.isrNo === 6
            ? 0
            : row.touch;
    const mainFine = row.isrNo === 5 ? n(result?.partyFine) : row.fineWt;
    const krTouch =
      row.isrNo === 2 || row.isrNo === 5
        ? n(result?.touch)
        : row.isrNo === 4
          ? 100
          : row.isrNo === 6
            ? row.netWt
            : row.touch;
    await insertRowTx(tx, 'MAIN_STOCK', input.scope.tenantId, {
      ...key,
      SR_NO: row.sourceRow,
      ISR_NO: row.isrNo,
      VCH_DATE: date,
      STK_DATE: date.toISOString().slice(0, 10),
      VCH_TYPE: policy.vchType,
      BOOK_NAME: policy.mainBook,
      AC_CODE: row.isrNo === 1 ? text(input.acCode) : row.isrNo === 5 ? text(input.acCode) : '',
      IT_CODE: text(row.itCode),
      TAG_NO: 'N',
      VCH_SRNO: 0,
      TBL_CODE: '',
      TR_TYPE: row.trType,
      ITM_SIGN: row.sign,
      ITM_QTY: row.isrNo === 1 || row.isrNo === 2 || row.isrNo === 5 ? 1 : 0,
      ITM_PCS: pcs,
      ITM_GWT: row.netWt,
      ITM_NWT: row.netWt,
      ITM_TOUCH: mainTouch,
      ITM_WEST: 0,
      ITM_FINE: mainFine,
      KR_NWT: String(row.netWt),
      KR_TOUCH: krTouch,
      KR_WEST: '0',
      KR_FINE: row.fineWt,
      EMP_CODE: '',
      ENTRY_TIME: time,
      MAIN_USER: text(input.mainUser) || null,
      DATA_TYPE: policy.dataType,
      ITM_LOT: row.isrNo === 2 && row.sourceRow === 1 ? text(result?.lotNo || input.lotNo) : '',
    });
  }
  return projections.length;
}

async function resolveAuthoritativeItemsTx(
  tx: any,
  input: MeltingProInput,
  prepared: ReturnType<typeof prepare>,
): Promise<void> {
  const codes = Array.from(
    new Set(
      [
        ...prepared.outRows.map((row) => row.itCode),
        ...prepared.resultRows.flatMap((row) => [row.itCode, row.conItCode, row.returnItCode]),
      ]
        .map(text)
        .filter(Boolean),
    ),
  );
  const rows: Array<{ IT_CODE: unknown; IT_NAME: unknown; IT_TYPE: unknown }> =
    await tx.$queryRawUnsafe(
      `SELECT "IT_CODE","IT_NAME","IT_TYPE" FROM "ITEM_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=ANY($3::text[])
        ORDER BY "IT_CODE"`,
      input.scope.tenantId,
      input.scope.coCode,
      codes,
    );
  const byCode = new Map<string, { name: string; type: string }>();
  for (const row of rows) {
    const code = text(row.IT_CODE);
    if (byCode.has(code)) {
      throw new MeltingProValidationError(`melting item is ambiguous: ${code}`);
    }
    byCode.set(code, { name: text(row.IT_NAME), type: text(row.IT_TYPE).toUpperCase() });
  }
  for (const code of codes) {
    if (!byCode.has(code)) throw new MeltingProValidationError(`melting item not found: ${code}`);
  }
  for (const row of [...prepared.outRows, ...prepared.resultRows]) {
    const item = byCode.get(text(row.itCode))!;
    row.itemName = item.name;
    row.itemType = item.type;
  }
}

async function oneFormModeTx(tx: any, input: MeltingProInput): Promise<boolean> {
  const rows: Array<{ MFG_ONE_FORM: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "MFG_ONE_FORM" FROM "CO_SET"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id`,
    input.scope.tenantId,
    input.scope.coCode,
  );
  if (rows.length !== 1) {
    throw new MeltingProValidationError('melting requires one unambiguous company setting row');
  }
  return (text(rows[0]?.MFG_ONE_FORM) || 'Y').toUpperCase() === 'Y';
}

async function saveTx(
  tx: any,
  input: MeltingProInput,

  requestedVoucherNo?: string,
): Promise<{
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  outLines: number;
  resultLines: number;
  stockRows: number;
}> {
  completeScope(input.scope);
  const policy = await resolveBookTx(tx, input.scope);
  const { date, iso } = businessDate(input.vchDate);
  await assertFiscalDateTx(tx, input.scope, iso);
  await assertOpenTx(tx, input.scope.tenantId, input.scope.coCode, date);
  const prepared = prepare(input);
  await resolveAuthoritativeItemsTx(tx, input, prepared);
  const oneFormMode = await oneFormModeTx(tx, input);

  const created = !requestedVoucherNo;
  let voucherNo: string;
  let hiddenVoucherNo: string;
  let mainUser = text(input.mainUser);
  let persistedTime: unknown;
  if (created) {
    voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, input.scope));
    hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, input.scope);
  } else {
    voucherNo = formatVoucherNo(requestedVoucherNo!);
    const persisted = await headerForUpdateTx(tx, input.scope, voucherNo);
    await assertOpenTx(tx, input.scope.tenantId, input.scope.coCode, persisted.VCH_DATE);
    hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    mainUser = text(persisted.MAIN_USER) || mainUser;
    persistedTime = persisted.VCH_CLOCK;
    await deleteVoucherWriteSetTx(tx, {
      tables: ['REMARK_DATA', 'MAIN_STOCK', 'MFG_ISU_REC', 'MFG_DETL', 'MLT_DETL', 'MLT_DATA'],
      key: { scope: input.scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
  }

  const key = voucherKey(input.scope, voucherNo);
  const time = voucherTimestamp(date, persistedTime);
  const lotNo = text(input.lotNo);
  const acCode = text(input.acCode);
  const employeeCode = text(input.employeeCode);
  const description = text(input.description);
  await insertRowTx(tx, 'TEMP_BOOK_DATA', input.scope.tenantId, {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_BOOK: policy.coBook,
    VCH_NO: hiddenVoucherNo,
    BOOK_NAME: policy.displayName,
  });
  await insertRowTx(tx, 'MLT_DATA', input.scope.tenantId, {
    ...key,
    VCH_DATE: date,
    VCH_TIME: time,
    VCH_TYPE: policy.vchType,
    INOUT_TYPE: policy.inout,
    ENTRY_TYPE: '',
    BOOK_NAME: policy.mainBook,
    AC_CODE: acCode,
    AC_NAME: text(input.acName),
    IT_TYPE: text(prepared.outRows[0]?.itemType || prepared.resultRows[0]?.itemType),
    HD_VCH_NO: hiddenVoucherNo,
    EMP_CODE: employeeCode,
    VCH_DESC: description.slice(0, 50),
    DATA_TRFR: 'N',
    MAIN_USER: mainUser || null,
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    ISU_WT: prepared.totals.grossWt,
    LOT_NO: lotNo,
  });

  for (let index = 0; index < prepared.outRows.length; index++) {
    const row = prepared.outRows[index]!;
    await insertRowTx(tx, 'MLT_DETL', input.scope.tenantId, {
      ...key,
      ENTRY_TYPE: 'O',
      SR_NO: index + 1,
      VCH_DATE: date,
      VCH_TIME: time,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      BOOK_NAME: policy.mainBook,
      AC_CODE: acCode,
      IT_CODE: text(row.itCode),
      IT_NAME: text(row.itemName),
      ITM_PCS: n(row.pieces),
      ITM_GWT: row.grossWt,
      ITM_OTH_WT: row.otherWt,
      ITM_NWT: row.netWt,
      ITM_TOUCH: row.touch,
      ITM_WEST: 0,
      PARTY_FINE: row.partyFine,
      NET_FINE: row.partyFine,
      IT_TYPE: text(row.itemType),
      CON_IT_CODE: '',
      CON_PRC: 0,
      CON_WT: 0,
      FINE_PRC: 0,
      FINE_ADD: 0,
      MLT_WT: 0,
      RTN_WT: 0,
      RTN_IT_CODE: '',
      LOSS_WT: 0,
      MAIN_USER: mainUser || null,
      ADD_USER: mainUser || null,
      HD_VCH_NO: hiddenVoucherNo,
      EMP_CODE: employeeCode,
      LOT_NO: text(row.lotNo),
    });
  }

  for (let index = 0; index < prepared.resultRows.length; index++) {
    const row = prepared.resultRows[index]!;
    const rowLot = text(row.lotNo || (index === 0 ? lotNo : ''));
    await insertRowTx(tx, 'MLT_DETL', input.scope.tenantId, {
      ...key,
      ENTRY_TYPE: 'I',
      SR_NO: index + 1,
      VCH_DATE: date,
      VCH_TIME: time,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      BOOK_NAME: policy.mainBook,
      AC_CODE: acCode,
      IT_CODE: text(row.itCode),
      IT_NAME: text(row.itemName),
      ITM_PCS: n(row.pieces),
      ITM_GWT: row.grossWt,
      ITM_OTH_WT: 0,
      ITM_NWT: row.recoveredGrossWt,
      ITM_TOUCH: row.touch,
      ITM_WEST: 0,
      PARTY_FINE: row.partyFine,
      NET_FINE: row.partyFine,
      IT_TYPE: text(row.itemType),
      CON_IT_CODE: text(row.conItCode),
      CON_PRC: row.conPct,
      CON_WT: row.conWt,
      FINE_PRC: row.finePct,
      FINE_ADD: row.fineAdd,
      MLT_WT: row.meltWt,
      RTN_WT: row.returnWt,
      RTN_IT_CODE: text(row.returnItCode),
      LOSS_WT: row.lossWt,
      MAIN_USER: mainUser || null,
      ADD_USER: mainUser || null,
      HD_VCH_NO: hiddenVoucherNo,
      EMP_CODE: employeeCode,
      LOT_NO: rowLot,
      ITM_LOT: index === 0 ? lotNo : '',
    });
  }

  const first = prepared.resultRows[0]!;
  await insertRowTx(tx, 'MFG_DETL', input.scope.tenantId, {
    ...key,
    SR_NO: 1,
    OLD_SRNO: 0,
    VCH_DATE: date,
    VCH_TIME: time,
    VCH_TYPE: policy.vchType,
    INOUT_TYPE: policy.inout,
    ENTRY_TYPE: 'X',
    BOOK_NAME: policy.mainBook,
    AC_CODE: '',
    IT_CODE: text(first.itCode),
    TAG_NO: lotNo,
    LOT_NO: lotNo,
    ITM_PCS: n(first.pieces),
    ITM_GWT: first.grossWt,
    ITM_OTH_WT: 0,
    ITM_NWT: first.grossWt,
    ITM_TOUCH: first.touch,
    ITM_WEST_PRC: 0,
    ITM_FINE: first.partyFine,
    RTN_CHOL: first.returnWt,
    RTN_GHIS: first.lossWt,
    CHOL_IT_CODE: text(first.returnItCode),
    LAST_IR_TYPE: 'X',
    IT_TYPE: text(first.itemType),
    HD_VCH_NO: hiddenVoucherNo,
    MAIN_USER: mainUser || null,
    ADD_USER: mainUser || null,
    DATA_TRFR: 'N',
  });

  const stockRows = await insertStockTx(
    tx,
    { ...input, mainUser },
    policy,
    voucherNo,
    date,
    time,
    prepared.outRows,
    prepared.resultRows,
  );

  // The desktop save removes the intermediate Mlting_Isu_Mfg rows, then retains this one-form,
  // first-lot issue only for output books.
  if (oneFormMode && policy.inout === 'O' && lotNo && text(first.itemType) === 'G') {
    await insertRowTx(tx, 'MFG_ISU_REC', input.scope.tenantId, {
      ...key,
      SR_NO: 1,
      ISR_NO: 1,
      VCH_DATE: date,
      VCH_TIME: time,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      BOOK_NAME: policy.mainBook,
      AC_CODE: '',
      KR_AC_CODE: '',
      IT_CODE: text(first.itCode),
      LOT_NO: lotNo,
      IT_TYPE: 'G',
      ITM_SIGN: '-',
      IR_TYPE: 'I',
      IR_PCS: 0,
      IR_WT: first.recoveredGrossWt,
      ITM_GWT: first.recoveredGrossWt,
      ITM_NWT: first.recoveredGrossWt,
      ITM_TOUCH: first.touch,
      ITM_WEST: 0,
      ITM_FINE: first.partyFine,
      ITM_LOSS: first.lossWt,
      IR_LC: input.scope.lcCode,
      IR_YRCD: input.scope.coYear,
      IR_DBCD: input.scope.coBook,
      IR_NO: voucherNo,
      IR_SRNO: 1,
      IR_AC: '',
      EMP_CODE: '',
      MAIN_USER: mainUser || null,
      REC_IT_CODE: text(first.itCode),
      LAST_IR_TYPE: 'X',
      DATA_TYPE: policy.dataType,
    });
  }

  if (description) {
    await insertRowTx(tx, 'REMARK_DATA', input.scope.tenantId, {
      ...key,
      SR_NO: 0,
      VCH_DATE: date,
      AC_CODE: acCode,
      AC_NAME: text(input.acName),
      MAIN_BOOK: policy.mainBook,
      VCH_REMARK: description.slice(0, 250),
    });
  }
  return {
    voucherNo,
    hiddenVoucherNo,
    created,
    outLines: prepared.outRows.length,
    resultLines: prepared.resultRows.length,
    stockRows,
  };
}

export async function saveMeltingPro(
  prisma: any,
  input: MeltingProInput,
  requestedVoucherNo?: string,
): Promise<{
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  outLines: number;
  resultLines: number;
  stockRows: number;
}> {
  return withTenant(prisma, input.scope.tenantId, (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getMeltingPro(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
): Promise<Record<string, unknown>> {
  completeScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT *,"VCH_DATE"::text AS "VCH_DATE_TEXT" FROM "MLT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (headers.length !== 1) {
      throw new MeltingProValidationError(
        headers.length
          ? `melting voucher is ambiguous: ${voucherNo}`
          : `melting voucher not found: ${voucherNo}`,
      );
    }
    const details: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "MLT_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
       ORDER BY "ENTRY_TYPE" DESC,"SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const h = headers[0]!;
    const mapOut = (row: Record<string, unknown>) => ({
      srNo: n(row.SR_NO),
      itCode: text(row.IT_CODE),
      itemName: text(row.IT_NAME),
      itemType: text(row.IT_TYPE),
      pieces: n(row.ITM_PCS),
      grossWt: n(row.ITM_GWT),
      otherWt: n(row.ITM_OTH_WT),
      netWt: n(row.ITM_NWT),
      touch: n(row.ITM_TOUCH),
      partyFine: n(row.PARTY_FINE),
      lotNo: text(row.LOT_NO),
    });
    const mapResult = (row: Record<string, unknown>) => ({
      srNo: n(row.SR_NO),
      itCode: text(row.IT_CODE),
      itemName: text(row.IT_NAME),
      itemType: text(row.IT_TYPE),
      pieces: n(row.ITM_PCS),
      grossWt: n(row.ITM_GWT),
      touch: n(row.ITM_TOUCH),
      partyFine: n(row.PARTY_FINE),
      conItCode: text(row.CON_IT_CODE),
      conPct: n(row.CON_PRC),
      conWt: n(row.CON_WT),
      finePct: n(row.FINE_PRC),
      fineAdd: n(row.FINE_ADD),
      meltWt: n(row.MLT_WT),
      returnItCode: text(row.RTN_IT_CODE),
      returnWt: n(row.RTN_WT),
      recoveredGrossWt: n(row.ITM_NWT),
      lossWt: n(row.LOSS_WT),
      lotNo: text(row.LOT_NO),
    });
    return {
      voucherNo: text(h.VCH_NO),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      vchDate: text(h.VCH_DATE_TEXT).slice(0, 10),
      acCode: text(h.AC_CODE),
      acName: text(h.AC_NAME),
      employeeCode: text(h.EMP_CODE),
      description: text(h.VCH_DESC),
      lotNo: text(h.LOT_NO),
      mainUser: text(h.MAIN_USER),
      outLines: details.filter((row) => text(row.ENTRY_TYPE) === 'O').map(mapOut),
      resultLines: details.filter((row) => text(row.ENTRY_TYPE) === 'I').map(mapResult),
    };
  });
}

export async function deleteMeltingPro(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
  deleteUser: string,
): Promise<{ reversed: true; auditedDetails: number }> {
  completeScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope);
    const persisted = await headerForUpdateTx(tx, scope, voucherNo);
    await assertOpenTx(tx, scope.tenantId, scope.coCode, persisted.VCH_DATE);
    const hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    const auditedDetails = await auditDetailsTx(tx, scope, voucherNo, policy, deleteUser);
    await deleteVoucherWriteSetTx(tx, {
      tables: ['REMARK_DATA', 'MAIN_STOCK', 'MFG_ISU_REC', 'MFG_DETL', 'MLT_DETL', 'MLT_DATA'],
      key: { scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
    return { reversed: true, auditedDetails };
  });
}
