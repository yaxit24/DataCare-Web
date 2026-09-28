import { withTenant } from '@datacare/db';
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

export class StoneDmCfValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'StoneDmCfValidationError';
  }
}

export interface StoneDmCfLineInput {
  tagNo?: string;
  vchSrno?: number;
  itCode?: string;
  designNo?: string;
  color?: string;
  purity?: string;
  size?: string;
  certificateNo?: string;
  tblCode?: string;
  pieces?: number;
  grossWt?: number;
  otherWt?: number;
  netWt?: number;
  fineWt?: number;
  labourAmount?: number;
  otherAmount?: number;
  tagCost?: number;
  mrp?: number;
  remark?: string;
  karigarName?: string;
  designImageId?: string;
}

export interface StoneDmCfInput {
  scope: VoucherScope;
  vchDate: string | Date;
  employeeCode?: string;
  description?: string;
  lines: StoneDmCfLineInput[];
  mainUser?: string;
}

interface StoneDmCfBookPolicy {
  coBook: string;
  vchType: string;
  displayName: string;
  mainBook: 'SF PRINT';
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

type CompleteScope = VoucherScope & { coYear: string; coBook: string };

type PreparedLine = {
  input: StoneDmCfLineInput;
  source: Record<string, unknown>;
  identityKey: string;
  oldSrNo?: number;
};

const n = (value: unknown): number => (value == null || value === '' ? 0 : Number(value) || 0);
const text = (value: unknown, max = 255): string => String(value ?? '').trim().slice(0, max);
const hasNumber = (value: unknown): boolean => value !== undefined && value !== null && String(value).trim() !== '';
const numOr = (value: unknown, fallback: unknown): number => (hasNumber(value) ? n(value) : n(fallback));
const txtOr = (value: unknown, fallback: unknown, max = 255): string => {
  const actual = text(value, max);
  return actual || text(fallback, max);
};

function completeScope(scope: VoucherScope): asserts scope is CompleteScope {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new StoneDmCfValidationError(
      'stone/dm-cf requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

function businessDate(value: string | Date): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : String(value ?? '').trim();
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new StoneDmCfValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new StoneDmCfValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

async function assertFiscalDateTx(tx: any, scope: CompleteScope, iso: string): Promise<void> {
  try {
    await assertVoucherFiscalDateTx(tx, scope, iso);
  } catch (error) {
    if (error instanceof Error && error.name === 'FiscalDateValidationError') {
      throw new StoneDmCfValidationError(error.message);
    }
    throw error;
  }
}

async function assertOpenTx(tx: any, input: StoneDmCfInput, date: Date): Promise<void> {
  await assertPeriodOpen(tx, input.scope.tenantId, {
    writes: [{ table: 'BAR_CAN_DATA', rows: [{ CO_CODE: input.scope.coCode, VCH_DATE: date }] }],
    ledger: { table: 'AC_DATA', lines: [] },
  });
}

async function resolveBookTx(tx: any, scope: VoucherScope): Promise<StoneDmCfBookPolicy> {
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
    throw new StoneDmCfValidationError(
      rows.length
        ? `stone/dm-cf book configuration is ambiguous: ${scope.coBook}`
        : `stone/dm-cf book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = text(row.MAIN_BOOK).toUpperCase();
  if (mainBook !== 'SF PRINT') {
    throw new StoneDmCfValidationError(
      `book ${scope.coBook} is ${mainBook || 'unclassified'}, expected SF PRINT`,
    );
  }
  const table = text(row.BOOK_TBL_NAME).toUpperCase();
  if (table && table !== 'BAR_CAN_DATA') {
    throw new StoneDmCfValidationError(
      `book ${scope.coBook} writes ${table}, expected BAR_CAN_DATA`,
    );
  }
  const inout = text(row.BOOK_INOUT).toUpperCase();
  if (inout.length !== 1) {
    throw new StoneDmCfValidationError(`book ${scope.coBook} has no one-character BOOK_INOUT`);
  }
  return {
    coBook: text(row.CO_BOOK),
    vchType: text(row.BOOK_SNAME, 6) || text(row.CO_BOOK),
    displayName: text(row.BOOK_NAME) || mainBook,
    mainBook: 'SF PRINT',
    inout,
  };
}

function voucherKey(scope: CompleteScope, voucherNo: string): Record<string, unknown> {
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
}

async function headerForUpdateTx(tx: any, scope: CompleteScope, voucherNo: string): Promise<PersistedHeader> {
  try {
    return (await persistedVoucherHeaderTx(tx, {
      table: 'BAR_CAN_DATA',
      scope,
      voucherNo,
      extraColumns: ['EMP_CODE', 'VCH_DESC'],
    })) as unknown as PersistedHeader;
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new StoneDmCfValidationError(`stone/dm-cf voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new StoneDmCfValidationError(`stone/dm-cf voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
}

function lineHasContent(line: StoneDmCfLineInput): boolean {
  return Boolean(
    text(line.tagNo) ||
      text(line.itCode) ||
      text(line.designNo) ||
      text(line.certificateNo) ||
      text(line.remark) ||
      n(line.pieces) + n(line.grossWt) + n(line.labourAmount) + n(line.otherAmount) + n(line.mrp) !== 0,
  );
}

function identityOfLine(line: StoneDmCfLineInput | Record<string, unknown>): string {
  const tagNo = text((line as any).tagNo ?? (line as any).TAG_NO);
  const vchSrno = n((line as any).vchSrno ?? (line as any).VCH_SRNO);
  return tagNo ? `${tagNo}|${vchSrno}` : '';
}

async function duplicateCheckTx(
  tx: any,
  scope: CompleteScope,
  tagNo: string,
  vchSrno: number,
  currentVoucherNo?: string,
): Promise<void> {
  const prior: Array<{ found: unknown }> = await tx.$queryRawUnsafe(
    `SELECT 1 AS found FROM "BAR_CAN_DETL" c
      WHERE c.tenant_id=$1 AND c."CO_CODE"=$2 AND c."LC_CODE"=$3
        AND upper(btrim(coalesce(c."BOOK_NAME"::text,'')))='SF PRINT'
        AND c."TAG_NO"=$4 AND coalesce(c."VCH_SRNO",0)::numeric=$5::numeric
        AND NOT (c."CO_YEAR"=$6 AND c."CO_BOOK"=$7 AND c."VCH_NO"=$8)
      LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    tagNo,
    vchSrno,
    scope.coYear,
    scope.coBook,
    currentVoucherNo ?? '',
  );
  if (prior.length) {
    throw new StoneDmCfValidationError(`tag is already present in another stone/dm-cf voucher: ${tagNo}|${vchSrno}`);
  }
}

async function sourceTagTx(
  tx: any,
  scope: CompleteScope,
  line: StoneDmCfLineInput,
): Promise<Record<string, unknown>> {
  const tagNo = text(line.tagNo, 15);
  if (!tagNo) return {};
  const params: unknown[] = [scope.tenantId, scope.coCode, scope.lcCode, tagNo];
  const filters = [
    `b.tenant_id=$1`,
    `b."CO_CODE"=$2`,
    `b."LC_CODE"=$3`,
    `b."TAG_NO"=$4`,
    `coalesce(upper(btrim(b."EMP_ISU"::text)),'N') <> 'Y'`,
  ];
  if (n(line.vchSrno) > 0) {
    params.push(n(line.vchSrno));
    filters.push(`coalesce(b."VCH_SRNO",0)::numeric=$${params.length}::numeric`);
  }
  if (text(line.itCode)) {
    params.push(text(line.itCode, 5));
    filters.push(`b."IT_CODE"::text=$${params.length}`);
  }
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT b.*,coalesce(i."IT_NAME",'') AS "IT_NAME"
       FROM "BAR_DETL" b
       LEFT JOIN "ITEM_MAST" i ON i.tenant_id=b.tenant_id AND i."CO_CODE"=b."CO_CODE"
                              AND i."IT_CODE"=b."IT_CODE"
      WHERE ${filters.join(' AND ')}
        AND ${barTagAvailableSql('b')}
      ORDER BY b.row_id FOR UPDATE OF b`,
    ...params,
  );
  if (rows.length !== 1) {
    throw new StoneDmCfValidationError(
      rows.length
        ? `stone/dm-cf tag is ambiguous; provide VCH_SRNO: ${tagNo}`
        : `stone/dm-cf tag is unavailable: ${tagNo}`,
    );
  }
  return rows[0]!;
}

async function prepareLinesTx(
  tx: any,
  scope: CompleteScope,
  lines: StoneDmCfLineInput[],
  existingSnapshots: Map<string, Record<string, unknown>>,
  existingOldSerials: Map<string, number>,
  currentVoucherNo?: string,
): Promise<PreparedLine[]> {
  const usable = lines.filter(lineHasContent);
  if (!usable.length) throw new StoneDmCfValidationError('at least one stone/dm-cf line is required');
  const seen = new Set<string>();
  const prepared: PreparedLine[] = [];
  let manual = 0;
  for (const line of usable) {
    const tagNo = text(line.tagNo, 15);
    if (tagNo) {
      const requestedSrno = n(line.vchSrno);
      const retained = requestedSrno > 0 ? existingSnapshots.get(`${tagNo}|${requestedSrno}`) : undefined;
      const source = retained ?? (await sourceTagTx(tx, scope, line));
      const vchSrno = n(source.VCH_SRNO || line.vchSrno);
      if (vchSrno <= 0) throw new StoneDmCfValidationError(`VCH_SRNO is required for tag ${tagNo}`);
      const identityKey = `${tagNo}|${vchSrno}`;
      if (seen.has(identityKey)) throw new StoneDmCfValidationError(`duplicate stone/dm-cf tag: ${identityKey}`);
      seen.add(identityKey);
      await duplicateCheckTx(tx, scope, tagNo, vchSrno, currentVoucherNo);
      prepared.push({
        input: line,
        source,
        identityKey,
        oldSrNo: existingOldSerials.get(identityKey),
      });
    } else {
      const pieces = n(line.pieces);
      const gross = n(line.grossWt);
      if (pieces + gross === 0) {
        throw new StoneDmCfValidationError('manual stone/dm-cf rows require pieces or gross weight');
      }
      manual += 1;
      prepared.push({ input: line, source: {}, identityKey: `manual|${manual}` });
    }
  }
  const totalPieces = prepared.reduce((sum, row) => sum + numOr(row.input.pieces, row.source.ITM_PCS), 0);
  const totalGross = prepared.reduce((sum, row) => sum + numOr(row.input.grossWt, row.source.ITM_GWT), 0);
  if (totalPieces + totalGross === 0) {
    throw new StoneDmCfValidationError('stone/dm-cf total pieces and gross weight are zero');
  }
  return prepared;
}

function detailRow(
  scope: CompleteScope,
  policy: StoneDmCfBookPolicy,
  input: StoneDmCfInput,
  voucherNo: string,
  hiddenVoucherNo: string,
  date: Date,
  now: Date,
  prepared: PreparedLine,
  srNo: number,
  oldSrNo: number,
): Record<string, unknown> {
  const { source, input: line } = prepared;
  return {
    ...voucherKey(scope, voucherNo),
    VCH_SRNO: numOr(line.vchSrno, source.VCH_SRNO),
    SR_NO: srNo,
    OLD_SRNO: oldSrNo,
    VCH_DATE: date,
    VCH_TIME: now,
    VCH_TYPE: policy.vchType,
    INOUT_TYPE: policy.inout,
    ENTRY_TYPE: 'T',
    BOOK_NAME: policy.mainBook,
    AC_CODE: '',
    IT_CODE: txtOr(line.itCode, source.IT_CODE, 5),
    TAG_NO: txtOr(line.tagNo, source.TAG_NO, 15),
    TBL_CODE: txtOr(line.tblCode, source.TBL_CODE, 3),
    DESIGN_NO: txtOr(line.designNo, source.DESIGN_NO, 50),
    ITM_SIZE: txtOr(line.size, source.ITM_SIZE, 20),
    ITM_SIGN: '-',
    ITM_PCS: numOr(line.pieces, source.ITM_PCS),
    BAG_WT: n(source.BAG_WT),
    ITM_GWT: numOr(line.grossWt, source.ITM_GWT),
    ITM_OTH_WT: numOr(line.otherWt, source.ITM_OTH_WT),
    ITM_NWT: numOr(line.netWt, source.ITM_NWT),
    ITM_GHT_WT: 0,
    ITM_TOUCH: 0,
    ITM_WEST_PRC: 0,
    ITM_FINE: numOr(line.fineWt, source.ITM_FINE),
    LBR_PRC: 0,
    LBR_TYPE: '',
    LBR_RATE: 0,
    LBR_AMT: numOr(line.labourAmount, source.LBR_AMT),
    OTH_AMT: numOr(line.otherAmount, source.OTH_AMT),
    ITM_RATE: 0,
    ITM_AMT: 0,
    TAG_COST: hasNumber(line.tagCost) ? n(line.tagCost) : n(source.KR_COST) !== 0 ? n(source.KR_COST) : n(source.TAG_COST),
    ITM_MRP: numOr(line.mrp, source.ITM_MRP),
    KR_NET_WT: 0,
    KR_TOUCH: 0,
    KR_WEST_PRC: 0,
    KR_FINE: 0,
    KR_NAME: txtOr(line.karigarName, source.KR_NAME, 5),
    RATE_TYPE: '',
    IT_TYPE: '',
    PR_CODE: '',
    TO_TBL_CODE: '',
    ITM_COLOUR: txtOr(line.color, source.ITM_COLOUR ?? source.ITM_COLOR, 50),
    ITM_POLISH: txtOr(line.purity, source.ITM_POLISH, 50),
    ITM_CF_NO: txtOr(line.certificateNo, source.ITM_CF_NO, 50),
    ITM_REMARK: txtOr(line.remark, source.ITM_REMARK, 50),
    HD_VCH_NO: hiddenVoucherNo,
    MAIN_USER: text(input.mainUser, 15) || null,
    DATA_TRFR: 'N',
    TBL_POSTING: 'N',
    DESIGN_IMG_ID: txtOr(line.designImageId, source.DESIGN_IMG_ID, 50),
  };
}

async function saveTx(
  tx: any,
  input: StoneDmCfInput,
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
  let mainUser = text(input.mainUser, 15);
  let persistedTime: unknown;
  let existingOldSerials = new Map<string, number>();
  let existingSnapshots = new Map<string, Record<string, unknown>>();
  if (requestedVoucherNo) {
    voucherNo = formatVoucherNo(requestedVoucherNo);
    const persisted = await headerForUpdateTx(tx, input.scope, voucherNo);
    await assertPeriodOpen(tx, input.scope.tenantId, {
      writes: [{ table: 'BAR_CAN_DATA', rows: [{ CO_CODE: input.scope.coCode, VCH_DATE: persisted.VCH_DATE }] }],
      ledger: { table: 'AC_DATA', lines: [] },
    });
    hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
    mainUser = text(persisted.MAIN_USER, 15) || mainUser;
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
      oldRows
        .map((row) => [identityOfLine(row), n(row.OLD_SRNO) || n(row.SR_NO)] as const)
        .filter(([identity]) => Boolean(identity)),
    );
    existingSnapshots = new Map(
      oldRows.map((row) => [identityOfLine(row), row] as const).filter(([identity]) => Boolean(identity)),
    );
  } else {
    voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, input.scope));
    hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, input.scope);
  }

  const prepared = await prepareLinesTx(
    tx,
    input.scope,
    input.lines,
    existingSnapshots,
    existingOldSerials,
    requestedVoucherNo ? voucherNo : undefined,
  );

  if (!created) {
    await deleteVoucherWriteSetTx(tx, {
      tables: ['REMARK_DATA', 'BAR_CAN_DETL', 'BAR_CAN_DATA'],
      key: { scope: input.scope, voucherNo },
      tempBook: { voucherNo: hiddenVoucherNo },
    });
  }

  const now = voucherTimestamp(date, persistedTime);
  await insertRowTx(tx, 'TEMP_BOOK_DATA', input.scope.tenantId, {
    CO_CODE: input.scope.coCode,
    LC_CODE: input.scope.lcCode,
    CO_BOOK: policy.coBook,
    VCH_NO: hiddenVoucherNo,
    BOOK_NAME: policy.displayName,
  });
  await insertRowTx(tx, 'BAR_CAN_DATA', input.scope.tenantId, {
    ...voucherKey(input.scope, voucherNo),
    VCH_DATE: date,
    VCH_TIME: now,
    AC_CODE: '',
    VCH_DESC: text(input.description),
    EMP_CODE: text(input.employeeCode, 3),
    HD_VCH_NO: hiddenVoucherNo,
    MAIN_USER: mainUser || null,
    DATA_TRFR: 'Y',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  });

  let nextOldSrNo = Math.max(0, ...existingOldSerials.values());
  for (let index = 0; index < prepared.length; index += 1) {
    const preparedLine = prepared[index]!;
    const oldSrNo = preparedLine.oldSrNo ?? ++nextOldSrNo;
    await insertRowTx(
      tx,
      'BAR_CAN_DETL',
      input.scope.tenantId,
      detailRow(input.scope, policy, { ...input, mainUser }, voucherNo, hiddenVoucherNo, date, now, preparedLine, index + 1, oldSrNo),
    );
  }

  const description = text(input.description);
  if (description) {
    await insertRowTx(tx, 'REMARK_DATA', input.scope.tenantId, {
      ...voucherKey(input.scope, voucherNo),
      SR_NO: 0,
      VCH_DATE: date,
      AC_CODE: '',
      AC_NAME: '',
      MAIN_BOOK: policy.mainBook,
      VCH_REMARK: description.slice(0, 250),
    });
  }

  return { voucherNo, hiddenVoucherNo, created, lines: prepared.length };
}

export async function saveStoneDmCf(
  prisma: any,
  input: StoneDmCfInput,
  requestedVoucherNo?: string,
): Promise<{ voucherNo: string; hiddenVoucherNo: string; created: boolean; lines: number }> {
  return withTenant(prisma, input.scope.tenantId, (tx: any) => saveTx(tx, input, requestedVoucherNo));
}

export async function getStoneDmCf(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
): Promise<Record<string, unknown>> {
  completeScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
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
      throw new StoneDmCfValidationError(
        headers.length
          ? `stone/dm-cf voucher is ambiguous: ${voucherNo}`
          : `stone/dm-cf voucher not found: ${voucherNo}`,
      );
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT c."SR_NO",c."OLD_SRNO",c."TAG_NO",c."VCH_SRNO",c."IT_CODE",
              coalesce(i."IT_NAME",'') AS "IT_NAME",c."DESIGN_NO",c."ITM_COLOUR",c."ITM_POLISH",
              c."ITM_SIZE",c."ITM_CF_NO",c."TBL_CODE",c."ITM_PCS",c."ITM_GWT",c."ITM_OTH_WT",
              c."ITM_NWT",c."ITM_FINE",c."LBR_AMT",c."OTH_AMT",c."TAG_COST",c."ITM_MRP",
              c."ITM_REMARK",c."KR_NAME",c."DESIGN_IMG_ID",c."ITM_SIGN",c."ENTRY_TYPE"
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
        color: text(row.ITM_COLOUR),
        purity: text(row.ITM_POLISH),
        size: text(row.ITM_SIZE),
        certificateNo: text(row.ITM_CF_NO),
        tblCode: text(row.TBL_CODE),
        pieces: n(row.ITM_PCS),
        grossWt: n(row.ITM_GWT),
        otherWt: n(row.ITM_OTH_WT),
        netWt: n(row.ITM_NWT),
        fineWt: n(row.ITM_FINE),
        labourAmount: n(row.LBR_AMT),
        otherAmount: n(row.OTH_AMT),
        tagCost: n(row.TAG_COST),
        mrp: n(row.ITM_MRP),
        remark: text(row.ITM_REMARK),
        karigarName: text(row.KR_NAME),
        designImageId: text(row.DESIGN_IMG_ID),
        sign: text(row.ITM_SIGN),
        entryType: text(row.ENTRY_TYPE),
      })),
    };
  });
}

export async function deleteStoneDmCf(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: string,
): Promise<{ reversed: true }> {
  completeScope(scope);
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope);
    const persisted = await headerForUpdateTx(tx, scope, voucherNo);
    await assertPeriodOpen(tx, scope.tenantId, {
      writes: [{ table: 'BAR_CAN_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: persisted.VCH_DATE }] }],
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

export async function listStoneDmCfSources(
  prisma: any,
  tenantId: string,
  scope: { CO_CODE: string; LC_CODE: string },
  filters?: { tblCode?: string; itCode?: string; tagNo?: string; vchSrno?: number; limit?: number; offset?: number },
): Promise<
  Array<{
    tagNo: string;
    vchSrno: number;
    itCode: string;
    itemName: string;
    designNo: string;
    size: string;
    tblCode: string;
    pieces: number;
    grossWt: number;
    otherWt: number;
    netWt: number;
    fineWt: number;
    labourAmount: number;
    otherAmount: number;
    tagCost: number;
    mrp: number;
    remark: string;
    karigarName: string;
    designImageId: string;
  }>
> {
  return withTenant(prisma, tenantId, async (tx: any) => {
    const params: unknown[] = [scope.CO_CODE, scope.LC_CODE];
    const clauses: string[] = [];
    if (filters?.tblCode) {
      params.push(filters.tblCode);
      clauses.push(`b."TBL_CODE"::text=$${params.length}`);
    }
    if (filters?.itCode) {
      params.push(filters.itCode);
      clauses.push(`b."IT_CODE"::text=$${params.length}`);
    }
    if (filters?.tagNo) {
      params.push(filters.tagNo);
      clauses.push(`b."TAG_NO"::text=$${params.length}`);
    }
    if (filters?.vchSrno != null && Number(filters.vchSrno) > 0) {
      params.push(Number(filters.vchSrno));
      clauses.push(`coalesce(b."VCH_SRNO",0)::numeric=$${params.length}::numeric`);
    }
    const limit = Math.min(Math.max(Number(filters?.limit) || 500, 1), 500);
    const offset = Math.max(Number(filters?.offset) || 0, 0);
    const extra = clauses.length ? ' AND ' + clauses.join(' AND ') : '';
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT b."TAG_NO" tag,b."VCH_SRNO" vs,b."IT_CODE" it,coalesce(i."IT_NAME",'') nm,
              b."DESIGN_NO" dn,b."ITM_SIZE" sz,b."TBL_CODE" tc,b."KR_NAME" kr,
              b."ITM_REMARK" remark,b."DESIGN_IMG_ID" image_id,
              coalesce(NULLIF(b."ITM_PCS"::text,'')::numeric,0)::float pcs,
              coalesce(NULLIF(b."ITM_GWT"::text,'')::numeric,0)::float gwt,
              coalesce(NULLIF(b."ITM_OTH_WT"::text,'')::numeric,0)::float owt,
              coalesce(NULLIF(b."ITM_NWT"::text,'')::numeric,0)::float nwt,
              coalesce(NULLIF(b."ITM_FINE"::text,'')::numeric,0)::float fine,
              coalesce(NULLIF(b."LBR_AMT"::text,'')::numeric,0)::float lamt,
              coalesce(NULLIF(b."OTH_AMT"::text,'')::numeric,0)::float oamt,
              coalesce(NULLIF(b."ITM_MRP"::text,'')::numeric,0)::float mrp,
              CASE WHEN coalesce(b."KR_COST",0) <> 0 THEN coalesce(b."KR_COST",0)
                   ELSE coalesce(NULLIF(b."TAG_COST"::text,'')::numeric,0)::float END AS tag_cost
         FROM "BAR_DETL" b
         LEFT JOIN "ITEM_MAST" i ON i.tenant_id=b.tenant_id AND i."CO_CODE"=b."CO_CODE"
                                AND i."IT_CODE"=b."IT_CODE"
        WHERE b."CO_CODE"::text=$1 AND b."LC_CODE"::text=$2${extra}
          AND coalesce(upper(btrim(b."EMP_ISU"::text)),'N') <> 'Y'
          AND ${barTagAvailableSql('b')}
        ORDER BY b."TAG_NO",coalesce(b."VCH_SRNO",0) LIMIT ${limit} OFFSET ${offset}`,
      ...params,
    );
    return rows.map((row) => ({
      tagNo: text(row.tag),
      vchSrno: n(row.vs),
      itCode: text(row.it),
      itemName: text(row.nm),
      designNo: text(row.dn),
      size: text(row.sz),
      tblCode: text(row.tc),
      pieces: n(row.pcs),
      grossWt: n(row.gwt),
      otherWt: n(row.owt),
      netWt: n(row.nwt),
      fineWt: n(row.fine),
      labourAmount: n(row.lamt),
      otherAmount: n(row.oamt),
      tagCost: n(row.tag_cost),
      mrp: n(row.mrp),
      remark: text(row.remark),
      karigarName: text(row.kr),
      designImageId: text(row.image_id),
    }));
  });
}
