import { withTxBudget } from '../shared/txBudget.js';
import { assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import { barTagAvailableSql } from '../shared/stockSql.js';
import {
  assertFiscalDateTx as assertVoucherFiscalDateTx,
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';

export class PhysicalStockValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'PhysicalStockValidationError';
  }
}

export interface PhysicalStockLineInput {
  tagNo: string;
  vchSrno: number;
}

export interface PhysicalStockInput {
  scope: VoucherScope;
  vchDate: string | Date;
  employeeCode?: string;
  description?: string;
  lines: PhysicalStockLineInput[];
  mainUser?: string;
}

interface PhysicalBookPolicy {
  coBook: string;
  vchType: string;
  displayName: string;
  mainBook: string;
  inout: string;
}

interface PersistedHeader {
  VCH_NO: unknown;
  VCH_DATE: unknown;
  VCH_TIME: unknown;
  VCH_CLOCK: unknown;
  EMP_CODE: unknown;
  VCH_DESC: unknown;
  HD_VCH_NO: unknown;
  MAIN_USER: unknown;
}

const n = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));
const text = (value: unknown): string => String(value ?? '').trim();

function completeScope(
  scope: VoucherScope,
): asserts scope is VoucherScope & { coYear: string; coBook: string } {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new PhysicalStockValidationError(
      'physical stock requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : String(value ?? '').trim();
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new PhysicalStockValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new PhysicalStockValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

async function resolveBookTx(tx: any, scope: VoucherScope): Promise<PhysicalBookPolicy> {
  completeScope(scope);

  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME",row_id,
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
    throw new PhysicalStockValidationError(
      rows.length
        ? `physical-stock book configuration is ambiguous: ${scope.coBook}`
        : `physical-stock book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  if (mainBook !== 'PHY STOCK') {
    throw new PhysicalStockValidationError(
      `book ${scope.coBook} is ${mainBook || 'unclassified'}, expected PHY STOCK`,
    );
  }
  const table = text(row.BOOK_TBL_NAME).toUpperCase();
  if (table && table !== 'BAR_CAN_DATA') {
    throw new PhysicalStockValidationError(
      `book ${scope.coBook} writes ${table}, expected BAR_CAN_DATA`,
    );
  }
  const inout = text(row.BOOK_INOUT).toUpperCase();
  if (inout.length !== 1) {
    throw new PhysicalStockValidationError(`book ${scope.coBook} has no one-character BOOK_INOUT`);
  }
  return {
    coBook: text(row.CO_BOOK),
    vchType: text(row.BOOK_SNAME) || text(row.CO_BOOK),
    displayName: text(row.BOOK_NAME) || mainBook,
    mainBook,
    inout,
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
      throw new PhysicalStockValidationError(error.message);
    }
    throw error;
  }
}

async function assertOpenTx(tx: any, input: PhysicalStockInput, date: Date): Promise<void> {
  await assertPeriodOpen(tx, input.scope.tenantId, {
    writes: [{ table: 'BAR_CAN_DATA', rows: [{ CO_CODE: input.scope.coCode, VCH_DATE: date }] }],
    ledger: { table: 'AC_DATA', lines: [] },
  });
}

function key(scope: VoucherScope & { coYear: string; coBook: string }, voucherNo: string) {
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
    return (await persistedVoucherHeaderTx(tx, {
      table: 'BAR_CAN_DATA',
      scope,
      voucherNo,
      extraColumns: ['EMP_CODE', 'VCH_DESC'],
    })) as unknown as PersistedHeader;
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new PhysicalStockValidationError(`physical-stock voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new PhysicalStockValidationError(`physical-stock voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
}

async function sourceRowsTx(
  tx: any,
  input: PhysicalStockInput,
  existingSnapshots: Map<string, Record<string, unknown>>,
  currentVoucherNo?: string,
): Promise<Record<string, unknown>[]> {
  if (!Array.isArray(input.lines) || input.lines.length === 0) {
    throw new PhysicalStockValidationError('at least one physical tag is required');
  }
  const seen = new Set<string>();
  const resolved: Record<string, unknown>[] = [];
  for (const line of input.lines) {
    const tagNo = text(line?.tagNo);
    const vchSrno = n(line?.vchSrno);
    if (!tagNo || !Number.isFinite(vchSrno) || vchSrno <= 0) {
      throw new PhysicalStockValidationError(
        'every physical tag requires tagNo and positive vchSrno',
      );
    }
    const identity = `${tagNo}|${vchSrno}`;
    if (seen.has(identity)) {
      throw new PhysicalStockValidationError(`duplicate physical tag: ${identity}`);
    }
    seen.add(identity);
    const retained = existingSnapshots.get(identity);
    if (retained) {
      resolved.push(retained);
      continue;
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT b.* FROM "BAR_DETL" b
        WHERE b.tenant_id=$1 AND b."CO_CODE"=$2 AND b."LC_CODE"=$3
          AND b."TAG_NO"=$4 AND coalesce(b."VCH_SRNO",0)::numeric=$5::numeric
          AND coalesce(upper(btrim(b."EMP_ISU"::text)),'N') <> 'Y'
          AND ${barTagAvailableSql('b')}
        ORDER BY b.row_id FOR UPDATE`,
      input.scope.tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      tagNo,
      vchSrno,
    );
    if (rows.length !== 1) {
      throw new PhysicalStockValidationError(
        rows.length
          ? `physical tag is ambiguous: ${identity}`
          : `physical tag is unavailable: ${identity}`,
      );
    }
    const prior: Array<{ found: unknown }> = await tx.$queryRawUnsafe(
      `SELECT 1 AS found FROM "BAR_CAN_DETL" c
        WHERE c.tenant_id=$1 AND c."CO_CODE"=$2 AND c."LC_CODE"=$3
          AND upper(btrim(coalesce(c."BOOK_NAME"::text,'')))='PHY STOCK'
          AND c."TAG_NO"=$4 AND coalesce(c."VCH_SRNO",0)::numeric=$5::numeric
          AND NOT (c."CO_YEAR"=$6 AND c."CO_BOOK"=$7 AND c."VCH_NO"=$8)
        LIMIT 1`,
      input.scope.tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      tagNo,
      vchSrno,
      input.scope.coYear,
      input.scope.coBook,
      currentVoucherNo ?? '',
    );
    if (prior.length) {
      throw new PhysicalStockValidationError(`physical tag was already counted: ${identity}`);
    }
    resolved.push(rows[0]!);
  }
  return resolved;
}

async function saveTx(
  tx: any,
  input: PhysicalStockInput,
  requestedVoucherNo?: string,
): Promise<{ voucherNo: string; hiddenVoucherNo: string; created: boolean; lines: number }> {
  completeScope(input.scope);
  const policy = await resolveBookTx(tx, input.scope);
  const { date, iso } = businessDate(input.vchDate);
  await assertFiscalDateTx(tx, input.scope, iso);
  await assertOpenTx(tx, input, date);

  const created = !requestedVoucherNo;
  let voucherNo: string;
  let hiddenVoucherNo: string;
  let mainUser = text(input.mainUser);
  let persistedTime: unknown;
  let existingOldSerials = new Map<string, number>();
  let existingSnapshots = new Map<string, Record<string, unknown>>();
  if (requestedVoucherNo) {
    voucherNo = formatVoucherNo(requestedVoucherNo);
    const persisted = await headerForUpdateTx(tx, input.scope, voucherNo);
    await assertPeriodOpen(tx, input.scope.tenantId, {
      writes: [
        {
          table: 'BAR_CAN_DATA',
          rows: [{ CO_CODE: input.scope.coCode, VCH_DATE: persisted.VCH_DATE }],
        },
      ],
      ledger: { table: 'AC_DATA', lines: [] },
    });
    hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    mainUser = text(persisted.MAIN_USER) || mainUser;
    persistedTime = persisted.VCH_CLOCK;
    const oldRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_CAN_DETL"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
            AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      input.scope.tenantId,
      input.scope.coCode,
      input.scope.lcCode,
      input.scope.coYear,
      input.scope.coBook,
      voucherNo,
    );
    existingOldSerials = new Map(
      oldRows.map((row) => [
        `${text(row.TAG_NO)}|${n(row.VCH_SRNO)}`,
        n(row.OLD_SRNO) || n(row.SR_NO),
      ]),
    );
    existingSnapshots = new Map(
      oldRows.map((row) => [`${text(row.TAG_NO)}|${n(row.VCH_SRNO)}`, row]),
    );
  } else {
    voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, input.scope));
    hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, input.scope);
  }

  const sources = await sourceRowsTx(
    tx,
    input,
    existingSnapshots,
    requestedVoucherNo ? voucherNo : undefined,
  );
  const totalPieces = sources.reduce((sum, row) => sum + n(row.ITM_PCS), 0);
  const totalGross = sources.reduce((sum, row) => sum + n(row.ITM_GWT), 0);
  if (totalPieces + totalGross === 0) {
    throw new PhysicalStockValidationError('physical stock total pieces and gross weight are zero');
  }

  if (!created) {
    await deleteVoucherWriteSetTx(tx, {
      tables: ['REMARK_DATA', 'BAR_CAN_DETL', 'BAR_CAN_DATA'],
      key: { scope: input.scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
  }
  const voucherKey = key(input.scope, voucherNo);
  const now = voucherTimestamp(date, persistedTime);
  await insertRowTx(tx, 'TEMP_BOOK_DATA', input.scope.tenantId, {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_BOOK: policy.coBook,
    VCH_NO: hiddenVoucherNo,
    BOOK_NAME: policy.displayName,
  });
  await insertRowTx(tx, 'BAR_CAN_DATA', input.scope.tenantId, {
    ...voucherKey,
    VCH_DATE: date,
    VCH_TIME: now,
    AC_CODE: '',
    VCH_DESC: text(input.description),
    EMP_CODE: text(input.employeeCode),
    HD_VCH_NO: hiddenVoucherNo,
    MAIN_USER: mainUser || null,
    DATA_TRFR: 'Y',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  });

  let nextOldSerial = Math.max(0, ...existingOldSerials.values());
  for (let index = 0; index < sources.length; index++) {
    const source = sources[index]!;
    const identity = `${text(source.TAG_NO)}|${n(source.VCH_SRNO)}`;
    const oldSerial = existingOldSerials.get(identity) ?? ++nextOldSerial;
    await insertRowTx(tx, 'BAR_CAN_DETL', input.scope.tenantId, {
      ...voucherKey,
      VCH_SRNO: n(source.VCH_SRNO),
      SR_NO: index + 1,
      OLD_SRNO: oldSerial,
      VCH_DATE: date,
      VCH_TIME: now,
      VCH_TYPE: policy.vchType,
      INOUT_TYPE: policy.inout,
      ENTRY_TYPE: 'T',
      BOOK_NAME: policy.mainBook,
      AC_CODE: '',
      IT_CODE: text(source.IT_CODE),
      TAG_NO: text(source.TAG_NO),
      DESIGN_NO: text(source.DESIGN_NO),
      TBL_CODE: text(source.TBL_CODE),
      ITM_SIZE: text(source.ITM_SIZE),
      ITM_PCS: n(source.ITM_PCS),
      ITM_GWT: n(source.ITM_GWT),
      ITM_OTH_WT: n(source.ITM_OTH_WT),
      ITM_NWT: n(source.ITM_NWT),
      ITM_GHT_WT: 0,
      ITM_TOUCH: 0,
      ITM_WEST_PRC: 0,
      ITM_FINE: n(source.ITM_FINE),
      LBR_PRC: 0,
      LBR_RATE: 0,
      LBR_TYPE: '',
      LBR_AMT: n(source.LBR_AMT),
      OTH_AMT: n(source.OTH_AMT),
      ITM_RATE: 0,
      ITM_AMT: 0,
      TAG_COST: n(source.KR_COST) !== 0 ? n(source.KR_COST) : n(source.TAG_COST),
      ITM_MRP: n(source.ITM_MRP),
      ITM_REMARK: text(source.ITM_REMARK).slice(0, 50),
      KR_NET_WT: 0,
      KR_TOUCH: 0,
      KR_WEST_PRC: 0,
      KR_FINE: 0,
      KR_NAME: text(source.KR_NAME),
      RATE_TYPE: '',
      IT_TYPE: '',
      PR_CODE: '',
      TO_TBL_CODE: text(source.TO_TBL_CODE),
      ITM_COLOUR: text(source.ITM_COLOUR || source.ITM_COLOR),
      ITM_POLISH: text(source.ITM_POLISH),
      ITM_CF_NO: text(source.ITM_CF_NO),
      HD_VCH_NO: hiddenVoucherNo,
      MAIN_USER: mainUser || null,
      DATA_TRFR: 'N',
      ITM_SIGN: '-',
      TBL_POSTING: 'N',
      DESIGN_IMG_ID: text(source.DESIGN_IMG_ID),
    });
  }
  const description = text(input.description);
  if (description) {
    await insertRowTx(tx, 'REMARK_DATA', input.scope.tenantId, {
      ...voucherKey,
      SR_NO: 0,
      VCH_DATE: date,
      AC_CODE: '',
      AC_NAME: '',
      MAIN_BOOK: policy.mainBook,
      VCH_REMARK: description.slice(0, 250),
    });
  }
  return { voucherNo, hiddenVoucherNo, created, lines: sources.length };
}

export async function savePhysicalStock(
  prisma: any,
  input: PhysicalStockInput,
  requestedVoucherNo?: string,
): Promise<{ voucherNo: string; hiddenVoucherNo: string; created: boolean; lines: number }> {
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', (tx: any) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

export async function getPhysicalStock(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
): Promise<Record<string, unknown>> {
  completeScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveBookTx(tx, scope);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","EMP_CODE","VCH_DESC","HD_VCH_NO","MAIN_USER"
         FROM "BAR_CAN_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (headers.length !== 1) {
      throw new PhysicalStockValidationError(
        headers.length
          ? `physical-stock voucher is ambiguous: ${voucherNo}`
          : `physical-stock voucher not found: ${voucherNo}`,
      );
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT c."SR_NO",c."OLD_SRNO",c."TAG_NO",c."VCH_SRNO",c."IT_CODE",
              coalesce(i."IT_NAME",'') AS "IT_NAME",c."DESIGN_NO",c."ITM_SIZE",c."TBL_CODE",
              c."ITM_PCS",c."ITM_GWT",c."ITM_OTH_WT",c."ITM_NWT",c."LBR_AMT",c."OTH_AMT",
              c."ITM_MRP",c."KR_NAME",c."ITM_FINE",c."ITM_SIGN",c."ENTRY_TYPE"
         FROM "BAR_CAN_DETL" c
         LEFT JOIN "ITEM_MAST" i ON i.tenant_id=c.tenant_id AND i."CO_CODE"=c."CO_CODE"
                                AND i."IT_CODE"=c."IT_CODE"
        WHERE c.tenant_id=$1 AND c."CO_CODE"=$2 AND c."LC_CODE"=$3 AND c."CO_YEAR"=$4
          AND c."CO_BOOK"=$5 AND c."VCH_NO"=$6 ORDER BY c."SR_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    const h = headers[0]!;
    return {
      voucherNo: text(h.VCH_NO),
      vchDate: String(h.VCH_DATE).slice(0, 10),
      employeeCode: text(h.EMP_CODE),
      description: text(h.VCH_DESC),
      hiddenVoucherNo: text(h.HD_VCH_NO),
      mainUser: text(h.MAIN_USER),
      lines: rows.map((row) => ({
        srNo: n(row.SR_NO),
        oldSrNo: n(row.OLD_SRNO),
        tagNo: text(row.TAG_NO),
        vchSrno: n(row.VCH_SRNO),
        itCode: text(row.IT_CODE),
        itemName: text(row.IT_NAME),
        designNo: text(row.DESIGN_NO),
        itmSize: text(row.ITM_SIZE),
        tblCode: text(row.TBL_CODE),
        pieces: n(row.ITM_PCS),
        grossWt: n(row.ITM_GWT),
        otherWt: n(row.ITM_OTH_WT),
        netWt: n(row.ITM_NWT),
        labourAmount: n(row.LBR_AMT),
        otherAmount: n(row.OTH_AMT),
        mrp: n(row.ITM_MRP),
        karigarName: text(row.KR_NAME),
        fineWt: n(row.ITM_FINE),
        sign: text(row.ITM_SIGN),
        entryType: text(row.ENTRY_TYPE),
      })),
    };
  });
}

export async function deletePhysicalStock(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
): Promise<{ reversed: true }> {
  completeScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await resolveBookTx(tx, scope);
    const persisted = await headerForUpdateTx(tx, scope, voucherNo);
    await assertPeriodOpen(tx, scope.tenantId, {
      writes: [
        {
          table: 'BAR_CAN_DATA',
          rows: [{ CO_CODE: scope.coCode, VCH_DATE: persisted.VCH_DATE }],
        },
      ],
      ledger: { table: 'AC_DATA', lines: [] },
    });
    const hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    await deleteVoucherWriteSetTx(tx, {
      tables: ['REMARK_DATA', 'BAR_CAN_DETL', 'BAR_CAN_DATA'],
      key: { scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
    return { reversed: true };
  });
}
