import { round } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { assertPeriodOpen, insertRowTx, postVoucherTx } from '../posting/posting.js';
import { fineFor, round3 } from '../shared/finePolicy.js';
import {
  assertFiscalDateTx,
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { resolveLiveTagIdentityTx } from './stock.js';

/**
 * Stock In / Stock Out (TR_INOUT — desktop INWORD / OUTWORD books).
 *
 * Desktop routing resolves both menu items to TR_INOUT. BOOK_DATA chooses the mode:
 *   Stock Out => MAIN_BOOK='OUTWORD', writes INOUT_DATA/INOUT_DETL, MAIN_STOCK '-', AC_DATA '-'.
 *   Stock In  => MAIN_BOOK='INWORD',  writes INOUT_DATA/INOUT_DETL, MAIN_STOCK '+', AC_DATA '+'.
 *
 * The implementation intentionally stays separate from Fine In/Out. Fine In/Out is a pure metal movement with
 * no AC_DATA/ROJ_MEL_DATA posting; INWORD/OUTWORD posts signed metal rows against the branch account resolved
 * from LOCT_MAST, matching Ac_Ledr.Stk_InOut_Ledr and Ac_Rojmel.Stk_InOut_Rojmel.
 */
export class StockInoutValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'StockInoutValidationError';
  }
}

export type StockInoutDirection = 'in' | 'out';

type CompleteScope = VoucherScope & { coYear: string; coBook: string };

type DirectionPolicy = {
  direction: StockInoutDirection;
  mainBook: 'INWORD' | 'OUTWORD';
  inout: 'I' | 'O';
  entry: 'I' | 'O';
  trType: 'I' | 'O';
  sign: '+' | '-';
  ledgerType: '01' | '02';
  ledgerContra: '00003' | '00008';
  transferField: 'fromLcCode' | 'toLcCode';
  label: 'Stock In' | 'Stock Out';
};

const POLICIES: Record<StockInoutDirection, DirectionPolicy> = {
  out: {
    direction: 'out',
    mainBook: 'OUTWORD',
    inout: 'O',
    entry: 'O',
    trType: 'O',
    sign: '-',
    ledgerType: '01',
    ledgerContra: '00003',
    transferField: 'toLcCode',
    label: 'Stock Out',
  },
  in: {
    direction: 'in',
    mainBook: 'INWORD',
    inout: 'I',
    entry: 'I',
    trType: 'I',
    sign: '+',
    ledgerType: '02',
    ledgerContra: '00008',
    transferField: 'fromLcCode',
    label: 'Stock In',
  },
};

export interface StockInoutLine {
  itCode: string;
  tagNo?: string;
  vchSrno?: number;
  lotNo?: string;
  itemLot?: string;
  designNo?: string;
  tblCode?: string;
  itmSize?: string;
  itmStyle?: string;
  itmColor?: string;
  hallmarkId?: string;
  pcs?: number;
  bagWt?: number;
  grossWt?: number;
  otherWt?: number;
  netWt?: number;
  ghtWt?: number;
  touch?: number;
  westPct?: number;
  fineWt?: number;
  labourPct?: number;
  labourType?: string;
  labourRate?: number;
  labourAmount?: number;
  otherAmount?: number;
  rate?: number;
  amount?: number;
  tagCost?: number;
  mrp?: number;
  remark?: string;
  karigarName?: string;
  karigarOtherWt?: number;
  karigarNetWt?: number;
  karigarGhtPct?: number;
  karigarGhtWt?: number;
  karigarTouch?: number;
  karigarWestPct?: number;
  karigarFine?: number;
  karigarLbrRate?: number;
  karigarLbrAmt?: number;
  karigarOthAmt?: number;
  rateType?: string;
  prCode?: string;
  itType?: string;
  lbrCode?: string;
  designImageId?: string;
  empIsu?: string;
  /** Per-line override for Stock In source location. */
  fromLcCode?: string;
  /** Per-line override for Stock Out target location. */
  toLcCode?: string;
}

export interface StockInoutInput {
  scope: VoucherScope;
  vchDate?: Date | string;
  mainUser?: string;
  employeeCode?: string;
  description?: string;
  fromLcCode?: string;
  toLcCode?: string;
  fromBook?: string;
  fromVchNo?: string | number;
  toBook?: string;
  toVchNo?: string | number;
  stockTransferred?: boolean;
  lines: StockInoutLine[];
}

type ResolvedBook = {
  coBook: string;
  vchType: string;
  mainBook: 'INWORD' | 'OUTWORD';
  inout: 'I' | 'O';
  bookName: string;
};

type WorkContext = {
  voucherNo: string;
  hiddenVoucherNo: string;
  mainUser: string;
  persistedClock?: unknown;
};

type LocationAccount = { acCode: string; acName: string };

type ComputedLine = {
  input: StockInoutLine;
  srNo: number;
  itCode: string;
  itType: string;
  transferLcCode: string;
  locationAccount?: LocationAccount;
  tagNo: string;
  vchSrno: number;
  pcs: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  ghtWt: number;
  touch: number;
  westPct: number;
  fineWt: number;
  rate: number;
  amount: number;
  labourAmount: number;
  otherAmount: number;
  netAmount: number;
};

const n = (value: unknown): number => (value == null || value === '' ? 0 : Number(value) || 0);
const text = (value: unknown): string => String(value ?? '').trim();
// Kernel half-up 2dp for posted money (N48). TR_INOUT re-displays stored amounts through Strings.Format "0.00"
// (TR_INOUT.cs:4540-4601, 5514-5613), but computes a line amount on entry as Math.Round(fine x rate, 0) with the
// rate per gram, per 10 g (RATE_TYPE '1'), per kg ('K') or per piece ('P') (TR_INOUT.cs:4105-4117). This writer
// still values a rated line as fine x rate at 2dp with no unit branch — gap G87.
const r2 = (value: number): number => round(value, 2);
const today = (): string => new Date().toISOString().slice(0, 10);
const short = (value: unknown, len: number): string => text(value).slice(0, len);
const nullable = (value: unknown, len?: number): string | null => {
  const out = len == null ? text(value) : short(value, len);
  return out || null;
};

function completeScope(scope: VoucherScope): asserts scope is CompleteScope {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new StockInoutValidationError(
      'stock in/out requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

function businessDate(value: Date | string | undefined): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value) || today();
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new StockInoutValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new StockInoutValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

function voucherKey(scope: CompleteScope, voucherNo: string) {
  return {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_YEAR: scope.coYear,
    CO_BOOK: scope.coBook,
    VCH_NO: voucherNo,
  };
}

function params(scope: CompleteScope, voucherNo: string): unknown[] {
  return [scope.tenantId, scope.coCode, scope.lcCode, scope.coYear, scope.coBook, voucherNo];
}

function normalizeMainBook(value: unknown): string {
  return text(value).toUpperCase().replace(/\s+/g, ' ');
}

async function resolveBookTx(
  tx: any,
  scope: CompleteScope,
  policy: DirectionPolicy,
): Promise<ResolvedBook> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce(nullif(upper(btrim("CUR_USE"::text)),''),'Y') <> 'N'
     )
     SELECT * FROM candidates WHERE priority=(SELECT min(priority) FROM candidates) ORDER BY row_id LIMIT 2`,
    scope.tenantId,
    scope.coCode,
    scope.coBook,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new StockInoutValidationError(
      rows.length
        ? `${policy.label} book configuration is ambiguous: ${scope.coBook}`
        : `${policy.label} book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  const mainBook = normalizeMainBook(row.MAIN_BOOK);
  if (mainBook && mainBook !== policy.mainBook) {
    throw new StockInoutValidationError(
      `book ${scope.coBook} is ${mainBook}, expected ${policy.mainBook}`,
    );
  }
  const inout = normalizeMainBook(row.BOOK_INOUT);
  if (inout && inout !== policy.inout) {
    throw new StockInoutValidationError(
      `book ${scope.coBook} direction is ${inout}, expected ${policy.inout}`,
    );
  }
  const tableName = normalizeMainBook(row.BOOK_TBL_NAME);
  if (tableName && tableName !== 'INOUT_DATA') {
    throw new StockInoutValidationError(
      `book ${scope.coBook} writes ${tableName}, expected INOUT_DATA`,
    );
  }
  return {
    coBook: text(row.CO_BOOK) || scope.coBook,
    vchType: text(row.BOOK_SNAME) || (policy.direction === 'in' ? 'IN' : 'OUT'),
    mainBook: policy.mainBook,
    inout: (inout || policy.inout) as 'I' | 'O',
    bookName: policy.mainBook,
  };
}

async function assertDatesOpenTx(
  tx: any,
  scope: CompleteScope,
  requested: { date: Date; iso: string },
  persistedDate?: unknown,
): Promise<void> {
  try {
    await assertFiscalDateTx(tx, scope, requested.iso);
  } catch (error) {
    if (error instanceof Error && error.name === 'FiscalDateValidationError') {
      throw new StockInoutValidationError(error.message);
    }
    throw error;
  }
  if (persistedDate != null) {
    await assertPeriodOpen(tx, scope.tenantId, {
      writes: [{ table: 'INOUT_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: persistedDate }] }],
      ledger: { table: 'AC_DATA', lines: [] },
    });
  }
  await assertPeriodOpen(tx, scope.tenantId, {
    writes: [{ table: 'INOUT_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: requested.date }] }],
    ledger: { table: 'AC_DATA', lines: [] },
  });
}

async function itemTypesTx(
  tx: any,
  scope: CompleteScope,
  itemCodes: string[],
): Promise<Map<string, string>> {
  const codes = Array.from(new Set(itemCodes.map(text).filter(Boolean)));
  if (!codes.length) return new Map();
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_TYPE" FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"::text=ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    codes,
  );
  return new Map(rows.map((row) => [text(row.IT_CODE), text(row.IT_TYPE) || 'G']));
}

async function locationAccountsTx(
  tx: any,
  scope: CompleteScope,
  lcCodes: string[],
): Promise<Map<string, LocationAccount>> {
  const codes = Array.from(new Set(lcCodes.map(text).filter(Boolean)));
  if (!codes.length) return new Map();
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "LC_CODE","LC_NAME","AC_CODE","AC_NAME" FROM "LOCT_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"::text=ANY($3::text[])
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    codes,
  );
  const map = new Map<string, LocationAccount>();
  for (const row of rows) {
    const lc = text(row.LC_CODE);
    if (!lc || map.has(lc)) continue;
    map.set(lc, { acCode: text(row.AC_CODE), acName: text(row.AC_NAME) || text(row.LC_NAME) });
  }
  for (const code of codes) {
    if (!map.has(code)) throw new StockInoutValidationError(`location not found: ${code}`);
  }
  return map;
}

function locationForLine(
  input: StockInoutInput,
  line: StockInoutLine,
  policy: DirectionPolicy,
): string {
  const raw =
    policy.direction === 'out'
      ? text(line.toLcCode) || text(input.toLcCode)
      : text(line.fromLcCode) || text(input.fromLcCode);
  if (!raw) throw new StockInoutValidationError(`${policy.label} requires ${policy.transferField}`);
  return raw.slice(0, 2);
}

function lineTag(value: unknown): string {
  const tag = text(value);
  return tag && tag !== 'Y' ? tag.slice(0, 15) : 'N';
}

function amountOf(line: StockInoutLine, fineWt: number): number {
  return line.amount != null ? r2(n(line.amount)) : r2(fineWt * n(line.rate));
}

async function computedLinesTx(
  tx: any,
  input: StockInoutInput,
  scope: CompleteScope,
  policy: DirectionPolicy,
): Promise<ComputedLine[]> {
  if (!input.lines?.length)
    throw new StockInoutValidationError(`${policy.label} requires at least one line`);

  const base = [] as Array<{
    input: StockInoutLine;
    srNo: number;
    itCode: string;
    transferLcCode: string;
    tagNo: string;
    vchSrno: number;
    stock?: Record<string, unknown>;
  }>;
  for (const [index, line] of input.lines.entries()) {
    const tagNo = lineTag(line.tagNo);
    let stock: Record<string, unknown> | undefined;
    let itCode = text(line.itCode);
    let vchSrno = n(line.vchSrno);
    if (policy.direction === 'out' && tagNo !== 'N') {
      const identity = await resolveLiveTagIdentityTx(tx, {
        CO_CODE: scope.coCode,
        LC_CODE: scope.lcCode,
        TAG_NO: tagNo,
        VCH_SRNO: line.vchSrno,
        IT_CODE: itCode || undefined,
      });
      stock = identity.stock;
      itCode = itCode || text(identity.IT_CODE) || text(stock.IT_CODE);
      vchSrno = n(line.vchSrno) || n(identity.VCH_SRNO);
    } else if (policy.direction === 'in' && tagNo !== 'N') {
      vchSrno = n(line.vchSrno) || index + 1;
    }
    if (!itCode)
      throw new StockInoutValidationError(`${policy.label} line ${index + 1} requires itCode`);
    base.push({
      input: line,
      srNo: index + 1,
      itCode,
      transferLcCode: locationForLine(input, line, policy),
      tagNo,
      vchSrno,
      stock,
    });
  }

  const types = await itemTypesTx(
    tx,
    scope,
    base.map((line) => line.itCode),
  );
  const missing = base.map((line) => line.itCode).find((code) => !types.has(code));
  if (missing) throw new StockInoutValidationError(`item not found: ${missing}`);

  const locations = await locationAccountsTx(
    tx,
    scope,
    base.map((line) => line.transferLcCode),
  );

  return base.map(({ input: line, srNo, itCode, transferLcCode, tagNo, vchSrno, stock }) => {
    const grossWt = line.grossWt != null ? n(line.grossWt) : n(stock?.ITM_GWT);
    const netWt = line.netWt != null ? n(line.netWt) : n(stock?.ITM_NWT);
    const touch = line.touch != null ? n(line.touch) : n(stock?.ITM_TOUCH);
    const fineWt =
      line.fineWt != null
        ? round3(n(line.fineWt))
        : fineFor('sale', { netWt, ghtWt: n(line.ghtWt), touch, westPct: n(line.westPct) });
    const amount = amountOf(line, fineWt);
    const labourAmount = n(line.labourAmount);
    const otherAmount = n(line.otherAmount);
    return {
      input: line,
      srNo,
      itCode,
      itType: text(line.itType) || types.get(itCode) || 'G',
      transferLcCode,
      locationAccount: locations.get(transferLcCode),
      tagNo,
      vchSrno,
      pcs: line.pcs != null ? n(line.pcs) : n(stock?.ITM_PCS),
      grossWt,
      otherWt: n(line.otherWt),
      netWt,
      ghtWt: n(line.ghtWt),
      touch,
      westPct: n(line.westPct),
      fineWt,
      rate: n(line.rate),
      amount,
      labourAmount,
      otherAmount,
      netAmount: r2(amount + labourAmount + otherAmount),
    };
  });
}

function headerRow(
  scope: CompleteScope,
  policy: DirectionPolicy,
  book: ResolvedBook,
  input: StockInoutInput,
  ctx: WorkContext,
  date: Date,
  lines: ComputedLine[],
) {
  const key = voucherKey(scope, ctx.voucherNo);
  const toLcCode =
    policy.direction === 'out' ? lines[0]?.transferLcCode : text(input.toLcCode) || scope.lcCode;
  const fromLcCode =
    policy.direction === 'in' ? lines[0]?.transferLcCode : text(input.fromLcCode) || scope.lcCode;
  return {
    ...key,
    VCH_DATE: date,
    VCH_TIME: voucherTimestamp(date, ctx.persistedClock),
    VCH_TYPE: book.vchType,
    INOUT_TYPE: book.inout,
    ENTRY_TYPE: policy.entry,
    BOOK_NAME: book.bookName,
    AC_CODE: '',
    TO_LC_CODE: short(toLcCode, 2) || null,
    FROM_LC_CODE: short(fromLcCode, 2) || null,
    TO_CO_BOOK: short(input.toBook, 3) || (policy.direction === 'out' ? null : scope.coBook),
    TO_VCH_NO: input.toVchNo != null ? formatVoucherNo(input.toVchNo) : null,
    FROM_CO_BOOK: short(input.fromBook, 3) || (policy.direction === 'in' ? null : scope.coBook),
    FROM_VCH_NO: input.fromVchNo != null ? formatVoucherNo(input.fromVchNo) : null,
    TOT_GWT: round3(lines.reduce((sum, line) => sum + line.grossWt, 0)),
    TOT_NWT: round3(lines.reduce((sum, line) => sum + line.netWt, 0)),
    TOT_FINE: round3(lines.reduce((sum, line) => sum + line.fineWt, 0)),
    TOT_LBR: r2(lines.reduce((sum, line) => sum + line.labourAmount, 0)),
    TOT_OTH: r2(lines.reduce((sum, line) => sum + line.otherAmount, 0)),
    TOT_NET_AMT: r2(lines.reduce((sum, line) => sum + line.netAmount, 0)),
    VCH_DESC: nullable(input.description, 150),
    EMP_CODE: nullable(input.employeeCode, 3),
    STK_TRFR: input.stockTransferred === true || policy.direction === 'in' ? 'Y' : 'N',
    HD_VCH_NO: ctx.hiddenVoucherNo,
    MAIN_USER: ctx.mainUser || null,
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  };
}

function detailRows(
  scope: CompleteScope,
  policy: DirectionPolicy,
  book: ResolvedBook,
  ctx: WorkContext,
  date: Date,
  lines: ComputedLine[],
  input: StockInoutInput,
): Record<string, unknown>[] {
  const key = voucherKey(scope, ctx.voucherNo);
  const vchTime = voucherTimestamp(date, ctx.persistedClock);
  return lines.map((line) => ({
    ...key,
    SR_NO: line.srNo,
    OLD_SRNO: line.srNo,
    VCH_DATE: date,
    VCH_TIME: vchTime,
    VCH_TYPE: book.vchType,
    INOUT_TYPE: book.inout,
    ENTRY_TYPE: policy.entry,
    BOOK_NAME: book.bookName,
    AC_CODE: policy.direction === 'out' ? line.transferLcCode : '',
    TO_LC_CODE:
      policy.direction === 'out' ? line.transferLcCode : text(input.toLcCode) || scope.lcCode,
    FROM_LC_CODE:
      policy.direction === 'in' ? line.transferLcCode : text(input.fromLcCode) || scope.lcCode,
    TO_CO_BOOK: nullable(input.toBook, 3),
    TO_VCH_NO: input.toVchNo != null ? formatVoucherNo(input.toVchNo) : null,
    FROM_CO_BOOK: nullable(input.fromBook, 3),
    FROM_VCH_NO: input.fromVchNo != null ? formatVoucherNo(input.fromVchNo) : null,
    IT_CODE: line.itCode,
    TAG_NO: line.tagNo,
    VCH_SRNO: line.tagNo === 'N' ? 0 : line.vchSrno,
    LOT_NO: nullable(line.input.lotNo, 15),
    ITM_LOT: nullable(line.input.itemLot ?? line.input.lotNo, 10),
    DESIGN_NO: nullable(line.input.designNo),
    TBL_CODE: short(line.input.tblCode, 3) || '000',
    ITM_SIZE: nullable(line.input.itmSize, 20),
    ITM_STYLE: nullable(line.input.itmStyle, 20),
    ITM_COLOR: nullable(line.input.itmColor, 15),
    HM_ID: nullable(line.input.hallmarkId, 10),
    ITM_PCS: line.pcs,
    BAG_WT: n(line.input.bagWt),
    ITM_GWT: line.grossWt,
    ITM_OTH_WT: line.otherWt,
    ITM_NWT: line.netWt,
    ITM_GHT_WT: line.ghtWt,
    ITM_TOUCH: line.touch,
    ITM_WEST_PRC: line.westPct,
    ITM_FINE: line.fineWt,
    LBR_PRC: n(line.input.labourPct),
    LBR_TYPE: nullable(line.input.labourType, 1),
    LBR_RATE: n(line.input.labourRate),
    LBR_AMT: line.labourAmount,
    OTH_AMT: line.otherAmount,
    ITM_RATE: line.rate,
    ITM_AMT: line.amount,
    TAG_COST: n(line.input.tagCost),
    ITM_MRP: n(line.input.mrp),
    ITM_REMARK: nullable(line.input.remark, 50),
    KR_NAME: nullable(line.input.karigarName, 5),
    KR_OTH_WT: n(line.input.karigarOtherWt),
    KR_NET_WT: n(line.input.karigarNetWt) || line.netWt,
    KR_GHT_PRC: n(line.input.karigarGhtPct),
    KR_GHT_WT: n(line.input.karigarGhtWt),
    KR_TOUCH: n(line.input.karigarTouch) || line.touch,
    KR_WEST_PRC: n(line.input.karigarWestPct) || line.westPct,
    KR_FINE: n(line.input.karigarFine) || line.fineWt,
    KR_LBR_RATE: n(line.input.karigarLbrRate),
    KR_LBR_AMT: n(line.input.karigarLbrAmt),
    KR_OTH_AMT: n(line.input.karigarOthAmt),
    RATE_TYPE: nullable(line.input.rateType, 1),
    IT_TYPE: line.itType,
    PR_CODE: nullable(line.input.prCode, 2),
    LBR_CODE: nullable(line.input.lbrCode, 4),
    DESIGN_IMG_ID: nullable(line.input.designImageId, 50),
    EMP_ISU: nullable(line.input.empIsu, 1),
    HD_VCH_NO: ctx.hiddenVoucherNo,
    MAIN_USER: ctx.mainUser || null,
    DATA_TRFR: 'N',
    DATA_TYPE: 'A',
  }));
}

function barRowsForStockIn(
  scope: CompleteScope,
  book: ResolvedBook,
  ctx: WorkContext,
  date: Date,
  lines: ComputedLine[],
): Record<string, unknown>[] {
  const key = voucherKey(scope, ctx.voucherNo);
  return lines
    .filter((line) => line.tagNo !== 'N')
    .map((line) => ({
      ...key,
      SR_NO: line.srNo,
      OLD_SRNO: line.srNo,
      VCH_DATE: date,
      STK_DATE: date.toISOString().slice(0, 10),
      VCH_TIME: voucherTimestamp(date, ctx.persistedClock),
      VCH_TYPE: book.vchType,
      INOUT_TYPE: book.inout,
      ENTRY_TYPE: 'I',
      BOOK_NAME: book.bookName,
      AC_CODE: '',
      IT_CODE: line.itCode,
      TAG_NO: line.tagNo,
      VCH_SRNO: line.vchSrno,
      LOT_NO: nullable(line.input.lotNo, 15),
      DESIGN_NO: nullable(line.input.designNo),
      TBL_CODE: short(line.input.tblCode, 3) || '000',
      ITM_SIZE: nullable(line.input.itmSize, 20),
      ITM_STYLE: nullable(line.input.itmStyle),
      ITM_COLOR: nullable(line.input.itmColor, 15),
      HM_ID: nullable(line.input.hallmarkId, 10),
      ITM_PCS: line.pcs,
      BAG_WT: n(line.input.bagWt),
      ITM_GWT: line.grossWt,
      ITM_OTH_WT: line.otherWt,
      ITM_NWT: line.netWt,
      ITM_GHT_WT: line.ghtWt,
      ITM_TOUCH: line.touch,
      ITM_WEST_PRC: line.westPct,
      ITM_FINE: line.fineWt,
      LBR_PRC: n(line.input.labourPct),
      LBR_TYPE: nullable(line.input.labourType, 1),
      LBR_RATE: n(line.input.labourRate),
      LBR_AMT: line.labourAmount,
      OTH_AMT: line.otherAmount,
      ITM_RATE: line.rate,
      ITM_AMT: line.amount,
      TAG_COST: n(line.input.tagCost),
      ITM_MRP: n(line.input.mrp),
      ITM_REMARK: nullable(line.input.remark),
      KR_NAME: nullable(line.input.karigarName, 5),
      KR_OTH_WT: n(line.input.karigarOtherWt),
      KR_NET_WT: n(line.input.karigarNetWt) || line.netWt,
      KR_GHT_PRC: n(line.input.karigarGhtPct),
      KR_GHT_WT: n(line.input.karigarGhtWt),
      KR_TOUCH: n(line.input.karigarTouch) || line.touch,
      KR_WEST_PRC: n(line.input.karigarWestPct) || line.westPct,
      KR_FINE: n(line.input.karigarFine) || line.fineWt,
      KR_LBR_RATE: n(line.input.karigarLbrRate),
      KR_LBR_AMT: n(line.input.karigarLbrAmt),
      KR_OTH_AMT: n(line.input.karigarOthAmt),
      RATE_TYPE: nullable(line.input.rateType, 1),
      IT_TYPE: line.itType,
      PR_CODE: nullable(line.input.prCode, 2),
      LBR_CODE: nullable(line.input.lbrCode, 4),
      DESIGN_IMG_ID: nullable(line.input.designImageId, 50),
      EMP_ISU: nullable(line.input.empIsu, 1),
      HD_VCH_NO: ctx.hiddenVoucherNo,
      MAIN_USER: ctx.mainUser || null,
      DATA_TRFR: 'N',
      DATA_TYPE: 'A',
    }));
}

function stockRows(
  scope: CompleteScope,
  policy: DirectionPolicy,
  book: ResolvedBook,
  ctx: WorkContext,
  date: Date,
  lines: ComputedLine[],
): Record<string, unknown>[] {
  const key = voucherKey(scope, ctx.voucherNo);
  return lines.map((line) => ({
    ...key,
    SR_NO: line.srNo,
    ISR_NO:
      policy.direction === 'in' && line.tagNo !== 'N'
        ? 2
        : line.input.lotNo || line.input.itemLot
          ? 3
          : 1,
    VCH_DATE: date,
    STK_DATE: date.toISOString().slice(0, 10),
    VCH_TYPE: book.vchType,
    BOOK_NAME: book.bookName,
    AC_CODE: '',
    IT_CODE: line.itCode,
    TAG_NO: line.tagNo,
    VCH_SRNO: line.tagNo === 'N' ? 0 : line.vchSrno,
    TBL_CODE: short(line.input.tblCode, 3) || '000',
    TR_TYPE: policy.trType,
    ITM_SIGN: policy.sign,
    ITM_QTY: 1,
    ITM_PCS: line.pcs,
    ITM_GWT: line.grossWt,
    ITM_NWT: line.netWt,
    ITM_TOUCH: line.touch,
    ITM_WEST: line.westPct,
    ITM_FINE: line.fineWt,
    ITM_RATE: line.rate,
    ITM_AMT: line.amount,
    LBR_RATE: n(line.input.labourRate),
    LBR_AMT: line.labourAmount,
    OTH_AMT: line.otherAmount,
    ITM_MRP: n(line.input.mrp),
    NET_AMT: line.netAmount,
    KR_NWT: n(line.input.karigarNetWt) || line.netWt,
    KR_TOUCH: n(line.input.karigarTouch) || line.touch,
    KR_WEST: n(line.input.karigarWestPct) || line.westPct,
    KR_FINE: n(line.input.karigarFine) || line.fineWt,
    DESIGN_NO: nullable(line.input.designNo),
    ITM_SIZE: nullable(line.input.itmSize, 20),
    ITM_LOT: nullable(line.input.itemLot ?? line.input.lotNo, 10),
    ITM_COLOR: nullable(line.input.itmColor, 15),
    GHT_PRC: n(line.input.karigarGhtPct),
    MAIN_USER: ctx.mainUser || null,
    DATA_TYPE: 'A',
  }));
}

function acLedgerRows(
  scope: CompleteScope,
  policy: DirectionPolicy,
  book: ResolvedBook,
  ctx: WorkContext,
  date: Date,
  lines: ComputedLine[],
): Record<string, unknown>[] {
  const key = voucherKey(scope, ctx.voucherNo);
  return lines
    .filter((line) => line.fineWt !== 0 && !!line.locationAccount?.acCode)
    .map((line) => ({
      ...key,
      VCH_TYPE: book.vchType,
      VCH_DATE: date,
      BOOK_NAME: book.bookName,
      AC_CODE: line.locationAccount!.acCode,
      LD_CODE: policy.ledgerContra,
      CR_AMT: 0,
      DR_AMT: 0,
      IT_TYPE: line.itType,
      SIGN: policy.sign,
      FINE_WT: line.fineWt,
      IT_DESC: nullable(line.input.remark, 50) || '',
      HD_VCH_NO: ctx.hiddenVoucherNo,
      DATA_TYPE: 'A',
      DATA_TRFR: 'N',
      MAIN_USER: ctx.mainUser || null,
      FINE_RATE: 0,
      PARTY_AC_CODE: line.locationAccount!.acCode,
      LDR_NAME: '',
      // Ac_Ledr.Stk_InOut_Ledr: head + STR(SR_NO) + '01' for OUTWORD, + '02' for INWORD.
      legKeySuffix: `${String(line.srNo).padStart(10, ' ')}${policy.ledgerType}`,
    }));
}

function rojmelKey(
  scope: CompleteScope,
  coBook: string,
  voucherNo: string,
  type: '01' | '02',
  srNo: number,
): string {
  // Ac_Rojmel.Stk_InOut_Rojmel: head + '01'/'02' + STR(SR_NO).
  return `${scope.coCode.padStart(2, '0').slice(0, 2)}${scope.lcCode.padStart(2, '0').slice(0, 2)}${scope.coYear.padEnd(9).slice(0, 9)}${coBook.padStart(3, '0').slice(0, 3)}${voucherNo.padStart(5, '0').slice(0, 5)}${type}${String(srNo).padStart(10, ' ')}`;
}

function rojmelRows(
  scope: CompleteScope,
  policy: DirectionPolicy,
  book: ResolvedBook,
  ctx: WorkContext,
  date: Date,
  lines: ComputedLine[],
): Record<string, unknown>[] {
  const key = voucherKey(scope, ctx.voucherNo);
  return lines
    .filter((line) => line.fineWt !== 0 && !!line.locationAccount?.acCode)
    .map((line) => ({
      ...key,
      LEDR_KEY: rojmelKey(scope, scope.coBook, ctx.voucherNo, policy.ledgerType, line.srNo),
      VCH_DATE: date,
      VCH_TYPE: book.vchType,
      BOOK_NAME: book.bookName,
      AC_CODE: line.locationAccount!.acCode,
      AC_NAME: '',
      LD_CODE: policy.ledgerContra,
      CR_AMT: 0,
      DR_AMT: 0,
      IT_TYPE: line.itType,
      SIGN: policy.sign,
      ITM_PCS: line.pcs,
      ITM_GWT: line.grossWt,
      ITM_NWT: line.netWt,
      ITM_TOUCH: line.touch,
      ITM_WEST: line.westPct,
      ITM_FINE: line.fineWt,
      ITM_RATE: 0,
      ITM_AMT: 0,
      LBR_RATE: 0,
      LBR_AMT: 0,
      OTH_AMT: 0,
      NET_AMT: 0,
      IT_DESC: nullable(line.input.remark, 50) || '',
      IT_CODE: '',
      MEMB_CODE: '',
      SCHM_CODE: '',
      REF_NO: '',
      DATA_TYPE: 'A',
    }));
}

async function writeStockInoutTx(
  tx: any,
  input: StockInoutInput,
  policy: DirectionPolicy,
  book: ResolvedBook,
  date: Date,
  ctx: WorkContext,
): Promise<{ vchNo: number; lines: number; fine: number }> {
  const scope = input.scope as CompleteScope;
  const lines = await computedLinesTx(tx, input, scope, policy);
  const header = headerRow(scope, policy, book, input, ctx, date, lines);
  const details = detailRows(scope, policy, book, ctx, date, lines, input);
  const taggedIn =
    policy.direction === 'in' ? barRowsForStockIn(scope, book, ctx, date, lines) : [];
  const stock = stockRows(scope, policy, book, ctx, date, lines);
  const ledger = acLedgerRows(scope, policy, book, ctx, date, lines);
  const daybook = rojmelRows(scope, policy, book, ctx, date, lines);

  await postVoucherTx(tx, scope.tenantId, {
    bookName: book.bookName,
    partyAc: '',
    ledger: { table: 'AC_DATA', lines: ledger },
    writes: [
      {
        table: 'TEMP_BOOK_DATA',
        rows: [
          {
            CO_CODE: scope.coCode,
            LC_CODE: scope.lcCode,
            CO_BOOK: scope.coBook,
            VCH_NO: ctx.hiddenVoucherNo,
            BOOK_NAME: book.bookName,
          },
        ],
      },
      { table: 'INOUT_DATA', rows: [header] },
      { table: 'INOUT_DETL', rows: details },
      ...(taggedIn.length ? [{ table: 'BAR_DETL', rows: taggedIn }] : []),
      { table: 'MAIN_STOCK', rows: stock },
      ...(daybook.length ? [{ table: 'ROJ_MEL_DATA', rows: daybook }] : []),
    ],
  });
  return {
    vchNo: Number(ctx.voucherNo),
    lines: lines.length,
    fine: round3(lines.reduce((sum, line) => sum + line.fineWt, 0)),
  };
}

async function createContextTx(
  tx: any,
  scope: CompleteScope,
  mainUser?: string,
): Promise<WorkContext> {
  return {
    voucherNo: formatVoucherNo(await nextVoucherNoTx(tx, scope)),
    hiddenVoucherNo: await nextHiddenVoucherNoTx(tx, scope),
    mainUser: text(mainUser),
  };
}

async function editContextTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  policy: DirectionPolicy,
  requested: { date: Date; iso: string },
  mainUser?: string,
): Promise<WorkContext> {
  const persisted = await headerTx(tx, scope, voucherNo, policy);
  await assertDatesOpenTx(tx, scope, requested, persisted.VCH_DATE);
  const hidden = text(persisted.HD_VCH_NO);
  return {
    voucherNo,
    hiddenVoucherNo: hidden ? formatVoucherNo(hidden) : voucherNo,
    mainUser: text(mainUser) || text(persisted.MAIN_USER),
    persistedClock: persisted.VCH_CLOCK,
  };
}

async function headerTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  policy: DirectionPolicy,
): Promise<Record<string, unknown>> {
  try {
    return await persistedVoucherHeaderTx(tx, {
      table: 'INOUT_DATA',
      scope,
      voucherNo,
      extraColumns: ['VCH_TYPE', 'BOOK_NAME', 'STK_TRFR'],
    });
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new StockInoutValidationError(`${policy.label} voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new StockInoutValidationError(`${policy.label} voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
}

async function saveStockInout(
  prisma: any,
  input: StockInoutInput,
  direction: StockInoutDirection,
): Promise<{ vchNo: number; lines: number; fine: number }> {
  completeScope(input.scope);
  const policy = POLICIES[direction];
  const requested = businessDate(input.vchDate);
  return withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const book = await resolveBookTx(tx, input.scope as CompleteScope, policy);
    await assertDatesOpenTx(tx, input.scope as CompleteScope, requested);
    return writeStockInoutTx(
      tx,
      input,
      policy,
      book,
      requested.date,
      await createContextTx(tx, input.scope as CompleteScope, input.mainUser),
    );
  });
}

async function editStockInout(
  prisma: any,
  input: StockInoutInput,
  direction: StockInoutDirection,
  requestedVoucherNo: number | string,
): Promise<{ vchNo: number; lines: number; fine: number }> {
  completeScope(input.scope);
  const scope = input.scope as CompleteScope;
  const policy = POLICIES[direction];
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requested = businessDate(input.vchDate);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const book = await resolveBookTx(tx, scope, policy);
    const ctx = await editContextTx(tx, scope, voucherNo, policy, requested, input.mainUser);
    // TR_INOUT save-on-edit deletes and rewrites INOUT_DATA/INOUT_DETL/INOUT_IDTL/MAIN_STOCK/AC/ROJMEL
    // without inserting DELETE_DATA. DELETE_DATA is only written by BtnDelete.
    await deleteVoucherWriteSetTx(tx, {
      tables: [
        'ROJ_MEL_DATA',
        'AC_DATA',
        'MAIN_STOCK',
        'BAR_DETL',
        'INOUT_IDTL',
        'INOUT_DETL',
        'INOUT_DATA',
      ],
      key: { scope, voucherNo },
      tempBook: { voucherNo: ctx.hiddenVoucherNo },
    });
    return writeStockInoutTx(tx, input, policy, book, requested.date, ctx);
  });
}

async function getStockInout(
  prisma: any,
  scopeInput: VoucherScope,
  direction: StockInoutDirection,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  completeScope(scopeInput);
  const scope = scopeInput as CompleteScope;
  const policy = POLICIES[direction];
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    await resolveBookTx(tx, scope, policy);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","EMP_CODE","VCH_DESC",
              "FROM_LC_CODE","TO_LC_CODE","FROM_CO_BOOK","FROM_VCH_NO","TO_CO_BOOK","TO_VCH_NO",
              "TOT_GWT","TOT_NWT","TOT_FINE","TOT_LBR","TOT_OTH","TOT_NET_AMT","STK_TRFR"
         FROM "INOUT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...params(scope, voucherNo),
    );
    if (headers.length !== 1) {
      throw new StockInoutValidationError(
        headers.length
          ? `${policy.label} voucher is ambiguous: ${voucherNo}`
          : `${policy.label} voucher not found: ${voucherNo}`,
      );
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","OLD_SRNO","IT_CODE","TAG_NO","VCH_SRNO","LOT_NO","ITM_LOT","DESIGN_NO","TBL_CODE",
              "ITM_SIZE","ITM_STYLE","ITM_COLOR","HM_ID","ITM_PCS","BAG_WT","ITM_GWT","ITM_OTH_WT",
              "ITM_NWT","ITM_GHT_WT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","LBR_PRC","LBR_TYPE",
              "LBR_RATE","LBR_AMT","OTH_AMT","ITM_RATE","ITM_AMT","TAG_COST","ITM_MRP","ITM_REMARK",
              "KR_NAME","KR_OTH_WT","KR_NET_WT","KR_GHT_PRC","KR_GHT_WT","KR_TOUCH","KR_WEST_PRC",
              "KR_FINE","KR_LBR_RATE","KR_LBR_AMT","KR_OTH_AMT","RATE_TYPE","IT_TYPE","PR_CODE",
              "LBR_CODE","DESIGN_IMG_ID","EMP_ISU","FROM_LC_CODE","TO_LC_CODE","FROM_CO_BOOK","FROM_VCH_NO",
              "TO_CO_BOOK","TO_VCH_NO"
         FROM "INOUT_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params(scope, voucherNo),
    );
    const header = headers[0]!;
    return {
      voucherNo,
      vchDate: text(header.VCH_DATE).slice(0, 10),
      hiddenVoucherNo: text(header.HD_VCH_NO),
      mainUser: text(header.MAIN_USER),
      employeeCode: text(header.EMP_CODE),
      description: text(header.VCH_DESC),
      fromLcCode: text(header.FROM_LC_CODE),
      toLcCode: text(header.TO_LC_CODE),
      fromBook: text(header.FROM_CO_BOOK),
      fromVchNo: text(header.FROM_VCH_NO),
      toBook: text(header.TO_CO_BOOK),
      toVchNo: text(header.TO_VCH_NO),
      stockTransferred: text(header.STK_TRFR) === 'Y',
      totals: {
        grossWt: n(header.TOT_GWT),
        netWt: n(header.TOT_NWT),
        fineWt: n(header.TOT_FINE),
        labourAmount: n(header.TOT_LBR),
        otherAmount: n(header.TOT_OTH),
        netAmount: n(header.TOT_NET_AMT),
      },
      lines: rows.map((row) => ({
        srNo: n(row.SR_NO),
        oldSrNo: n(row.OLD_SRNO),
        itCode: text(row.IT_CODE),
        tagNo: text(row.TAG_NO),
        vchSrno: n(row.VCH_SRNO),
        lotNo: text(row.LOT_NO),
        itemLot: text(row.ITM_LOT),
        designNo: text(row.DESIGN_NO),
        tblCode: text(row.TBL_CODE),
        itmSize: text(row.ITM_SIZE),
        itmStyle: text(row.ITM_STYLE),
        itmColor: text(row.ITM_COLOR),
        hallmarkId: text(row.HM_ID),
        pcs: n(row.ITM_PCS),
        bagWt: n(row.BAG_WT),
        grossWt: n(row.ITM_GWT),
        otherWt: n(row.ITM_OTH_WT),
        netWt: n(row.ITM_NWT),
        ghtWt: n(row.ITM_GHT_WT),
        touch: n(row.ITM_TOUCH),
        westPct: n(row.ITM_WEST_PRC),
        fineWt: n(row.ITM_FINE),
        labourPct: n(row.LBR_PRC),
        labourType: text(row.LBR_TYPE),
        labourRate: n(row.LBR_RATE),
        labourAmount: n(row.LBR_AMT),
        otherAmount: n(row.OTH_AMT),
        rate: n(row.ITM_RATE),
        amount: n(row.ITM_AMT),
        tagCost: n(row.TAG_COST),
        mrp: n(row.ITM_MRP),
        remark: text(row.ITM_REMARK),
        karigarName: text(row.KR_NAME),
        karigarOtherWt: n(row.KR_OTH_WT),
        karigarNetWt: n(row.KR_NET_WT),
        karigarGhtPct: n(row.KR_GHT_PRC),
        karigarGhtWt: n(row.KR_GHT_WT),
        karigarTouch: n(row.KR_TOUCH),
        karigarWestPct: n(row.KR_WEST_PRC),
        karigarFine: n(row.KR_FINE),
        karigarLbrRate: n(row.KR_LBR_RATE),
        karigarLbrAmt: n(row.KR_LBR_AMT),
        karigarOthAmt: n(row.KR_OTH_AMT),
        rateType: text(row.RATE_TYPE),
        itType: text(row.IT_TYPE),
        prCode: text(row.PR_CODE),
        lbrCode: text(row.LBR_CODE),
        designImageId: text(row.DESIGN_IMG_ID),
        empIsu: text(row.EMP_ISU),
        fromLcCode: text(row.FROM_LC_CODE),
        toLcCode: text(row.TO_LC_CODE),
        fromBook: text(row.FROM_CO_BOOK),
        fromVchNo: text(row.FROM_VCH_NO),
        toBook: text(row.TO_CO_BOOK),
        toVchNo: text(row.TO_VCH_NO),
      })),
    };
  });
}

async function deleteStockInout(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
  direction: StockInoutDirection,
): Promise<{ reversed: true }> {
  completeScope(input.scope);
  const scope = input.scope as CompleteScope;
  const policy = POLICIES[direction];
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const book = await resolveBookTx(tx, scope, policy);
    const persisted = await headerTx(tx, scope, voucherNo, policy);
    const persistedBusinessDate = businessDate(
      persisted.VCH_DATE instanceof Date
        ? persisted.VCH_DATE
        : text(persisted.VCH_DATE).slice(0, 10),
    );
    await assertDatesOpenTx(tx, scope, persistedBusinessDate, persisted.VCH_DATE);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","VCH_DATE","VCH_TIME","AC_CODE","IT_CODE","TAG_NO","IT_TYPE","ITM_NWT","HD_VCH_NO","MAIN_USER"
         FROM "INOUT_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      ...params(scope, voucherNo),
    );
    const deletedAt = new Date();
    for (const row of rows) {
      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
        ...voucherKey(scope, voucherNo),
        SR_NO: n(row.SR_NO),
        VCH_DATE: row.VCH_DATE,
        DELETE_DATE: deletedAt,
        VCH_TYPE: book.vchType,
        VCH_TIME: row.VCH_TIME ?? persisted.VCH_TIME,
        DELETE_TIME: deletedAt,
        BOOK_NAME: book.bookName,
        AC_CODE: text(row.AC_CODE),
        AC_NAME: '',
        VCH_VAL_DR: 0,
        VCH_VAL_CR: 0,
        FINE_TYPE: text(row.IT_TYPE),
        VCH_FINE_DR: 0,
        VCH_FINE_CR: n(row.ITM_NWT),
        HD_VCH_NO: text(row.HD_VCH_NO) || text(persisted.HD_VCH_NO),
        MAIN_USER: text(row.MAIN_USER) || text(persisted.MAIN_USER),
        DELETE_USER: text(input.deleteUser) || 'system',
        VCH_DESC: `ItCode/${text(row.IT_CODE)} TagNo/${text(row.TAG_NO)}`.slice(0, 150),
      });
    }
    await deleteVoucherWriteSetTx(tx, {
      tables: [
        'ROJ_MEL_DATA',
        'AC_DATA',
        'MAIN_STOCK',
        'BAR_DETL',
        'INOUT_IDTL',
        'INOUT_DETL',
        'INOUT_DATA',
      ],
      key: { scope, voucherNo },
      tempBook: {
        voucherNo: text(persisted.HD_VCH_NO)
          ? formatVoucherNo(text(persisted.HD_VCH_NO))
          : voucherNo,
      },
    });
    return { reversed: true };
  });
}

export const createStockOut = (prisma: any, input: StockInoutInput) =>
  saveStockInout(prisma, input, 'out');
export const getStockOut = (prisma: any, scope: VoucherScope, vchNo: number | string) =>
  getStockInout(prisma, scope, 'out', vchNo);
export const editStockOut = (prisma: any, input: StockInoutInput, vchNo: number | string) =>
  editStockInout(prisma, input, 'out', vchNo);
export const deleteStockOut = (
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
) => deleteStockInout(prisma, input, 'out');

export const createStockIn = (prisma: any, input: StockInoutInput) =>
  saveStockInout(prisma, input, 'in');
export const getStockIn = (prisma: any, scope: VoucherScope, vchNo: number | string) =>
  getStockInout(prisma, scope, 'in', vchNo);
export const editStockIn = (prisma: any, input: StockInoutInput, vchNo: number | string) =>
  editStockInout(prisma, input, 'in', vchNo);
export const deleteStockIn = (
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
) => deleteStockInout(prisma, input, 'in');
