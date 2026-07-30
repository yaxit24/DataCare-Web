import { withTenant } from '@datacare/db';
import { assertPeriodOpen, insertRowTx, postVoucherTx } from '../posting/posting.js';
import { fineFor, type FineWorkflow } from '../shared/finePolicy.js';
import {
  assertFiscalDateTx,
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import {
  formatVoucherNo,
  nextTagNoTx,
  nextVoucherNoTx,
  type VoucherScope,
} from '../vouchers/numbering.js';

export class StockVoucherValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'StockVoucherValidationError';
  }
}

export interface TagOpeningLine {
  tagNo?: string;
  vchSrno?: number;
  itCode: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  fineWt?: number;
  rate?: number;
  mrp?: number;
  tblCode?: string;
  designNo?: string;
  itmSize?: string;
  lessWt?: number;
  lbrPct?: number;
  lbrType?: string;
  lbrRate?: number;
  lbrAmt?: number;
  othAmt?: number;
  tagCost?: number;
  // Desktop tag-grid columns (TR_TAG_OPBL.cs `mSG[i, c]`); each maps to one BAR_DETL column.
  // Item attributes — mSG 8/9/49/24/38/100/101.
  itmStyle?: string;
  itmColor?: string;
  itmMargin?: number;
  lbrCode?: string;
  slType?: string;
  empIsu?: string;
  designImageId?: string;
  // Retail pricing — mSG 47/48.
  mainMarginPct?: number;
  mainMrp?: number;
  // Hallmark identifiers and weights — mSG 82-88.
  hallmarkId2?: string;
  hallmarkId3?: string;
  hallmarkId4?: string;
  hallmarkIdWt?: number;
  hallmarkId2Wt?: number;
  hallmarkId3Wt?: number;
  hallmarkId4Wt?: number;
  // Karigar costing — mSG 35/36/37/39/40/41/42/45/53/60.
  karigarLbrRate?: number;
  karigarLbrAmt?: number;
  karigarOthAmt?: number;
  karigarOthRate?: number;
  karigarOthFine?: number;
  karigarTotFine?: number;
  karigarGwtTouch?: number;
  karigarCost?: number;
  karigarName?: string;
  karigarWaxWt?: number;
  // Jadtar (stone-set) weights — mSG 54-59.
  jdtJdtWt?: number;
  jdtGhtWt?: number;
  jdtKunWt?: number;
  jdtKunTouch?: number;
  jdtKunNet?: number;
  jdtWaxWt?: number;
  // Sales-order linkage — mSG 4/90/91/92/94/95/97.
  ordNo?: string;
  ordSrno?: number;
  ordYrcd?: string;
  ordDbcd?: string;
  ordAc?: string;
  ordLcCode?: string;
  sfNo?: string;
  // Manufacturing linkage — mSG 2/103/104/106.
  mfgNo?: string;
  mfgYrcd?: string;
  mfgDbcd?: string;
  mfgSrno?: number;
}

export interface TagOpeningInput {
  scope: VoucherScope;
  mainUser?: string;
  vchDate?: Date | string;
  stockItCode?: string;
  lines: TagOpeningLine[];
}

export interface ItemOpeningLine {
  /** Diamond component of an opening line (ITM_OPBL DM_WT / DM_RATE / DM_AMT). */
  diamondWt?: number;
  diamondRate?: number;
  diamondAmount?: number;
  itCode: string;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  fineWt?: number;
  rate?: number;
  amount?: number;
}

export interface ItemOpeningInput {
  scope: VoucherScope;
  mainUser?: string;
  vchDate?: Date | string;
  lines: ItemOpeningLine[];
}

export interface ItemLotLine {
  itCode: string;
  lotNo?: string;
  designNo?: string;
  itmSize?: string;
  prCode?: string;
  itType?: 'G' | 'S';
  pcs?: number;
  grossWt?: number;
  otherWt?: number;
  netWt?: number;
  touch?: number;
  ghtWt?: number;
  westPct?: number;
  fineWt?: number;
  rate?: number;
  making?: number;
  otherAmount?: number;
  remark?: string;
}

export interface ItemLotInput {
  scope: VoucherScope;
  mainUser?: string;
  vchDate?: Date | string;
  acCode?: string;
  lines: ItemLotLine[];
}

type CompleteScope = VoucherScope & { coYear: string; coBook: string };
type Kind = 'tag-opening' | 'item-opening' | 'item-lot';
type BookPolicy = { bookName: string; vchType: string };
type WriteContext = {
  voucherNo: string;
  hiddenVoucherNo: string;
  mainUser: string;
  persistedClock?: unknown;
  persistedTagSrnos?: Map<string, number>;
};

const n = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));
const text = (value: unknown): string => String(value ?? '').trim();
const r2 = (value: number): number => Math.round((value + 1e-9) * 100) / 100;
const today = (): string => new Date().toISOString().slice(0, 10);

function completeScope(scope: VoucherScope): asserts scope is CompleteScope {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new StockVoucherValidationError(
      'stock voucher requires tenant, company, location, fiscal year, and configured book',
    );
  }
}

function businessDate(value: Date | string | undefined): { date: Date; iso: string } {
  const raw = value instanceof Date ? value.toISOString().slice(0, 10) : text(value) || today();
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new StockVoucherValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new StockVoucherValidationError('voucher date is missing or invalid');
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

async function resolveBookTx(tx: any, scope: CompleteScope, kind: Kind): Promise<BookPolicy> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `WITH candidates AS (
       SELECT "BOOK_NAME","BOOK_SNAME",row_id,
              CASE WHEN "LC_CODE"=$4 THEN 0 ELSE 1 END AS priority
         FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3
          AND ("LC_CODE"=$4 OR "LC_CODE"='00' OR "LC_CODE" IS NULL)
          AND coalesce(nullif(upper(btrim("CUR_USE"::text)),''),'Y') <> 'N'
     )
     SELECT * FROM candidates WHERE priority=(SELECT min(priority) FROM candidates) ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.coBook,
    scope.lcCode,
  );
  if (rows.length !== 1) {
    throw new StockVoucherValidationError(
      rows.length
        ? `${kind} book configuration is ambiguous: ${scope.coBook}`
        : `${kind} book not found: ${scope.coBook}`,
    );
  }
  const row = rows[0]!;
  return {
    bookName: text(row.BOOK_NAME),
    vchType: text(row.BOOK_SNAME) || scope.coBook,
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
      throw new StockVoucherValidationError(error.message);
    }
    throw error;
  }
  if (persistedDate != null) {
    await assertPeriodOpen(tx, scope.tenantId, {
      writes: [{ table: 'BAR_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: persistedDate }] }],
      ledger: { table: 'AC_DATA', lines: [] },
    });
  }
  await assertPeriodOpen(tx, scope.tenantId, {
    writes: [{ table: 'BAR_DATA', rows: [{ CO_CODE: scope.coCode, VCH_DATE: requested.date }] }],
    ledger: { table: 'AC_DATA', lines: [] },
  });
}

async function headerTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  kind: Kind,
): Promise<Record<string, unknown>> {
  try {
    return await persistedVoucherHeaderTx(tx, {
      table: 'BAR_DATA',
      scope,
      voucherNo,
      extraColumns: ['STK_IT_CODE', 'AC_CODE'],
    });
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new StockVoucherValidationError(`${kind} voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new StockVoucherValidationError(`${kind} voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
}

async function itemTypesTx(
  tx: any,
  scope: CompleteScope,
  itemCodes: string[],
): Promise<Map<string, string>> {
  if (!itemCodes.length) return new Map();
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_TYPE" FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"::text=ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    itemCodes,
  );
  return new Map(rows.map((row) => [text(row.IT_CODE), text(row.IT_TYPE)]));
}

async function insertIdentityTx(
  tx: any,
  scope: CompleteScope,
  policy: BookPolicy,
  date: Date,
  input: { stockItCode?: string; acCode?: string },
  ctx: WriteContext,
): Promise<void> {
  // Desktop hidden numbering is TEMP_BOOK_DATA MAX(VCH_NO)+1 by company/location/book, without year:
  // TR_TAG_OPBL.cs:10360-10370 and TR_ITM_LOT.cs:3552-3562.
  await insertRowTx(tx, 'TEMP_BOOK_DATA', scope.tenantId, {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_BOOK: scope.coBook,
    VCH_NO: ctx.hiddenVoucherNo,
    BOOK_NAME: policy.bookName,
  });
  // Desktop open/edit preserves HD_VCH_NO, MAIN_USER and wall-clock time, then combines the new date
  // with that clock: TR_TAG_OPBL.cs:10388-10413,10890-10915; TR_ITM_LOT.cs:3577-3588,3785-3790.
  await insertRowTx(tx, 'BAR_DATA', scope.tenantId, {
    ...voucherKey(scope, ctx.voucherNo),
    VCH_DATE: date,
    VCH_TIME: voucherTimestamp(date, ctx.persistedClock),
    STK_IT_CODE: text(input.stockItCode) || null,
    AC_CODE: text(input.acCode) || null,
    OP_STK: 'Y',
    HD_VCH_NO: ctx.hiddenVoucherNo,
    MAIN_USER: ctx.mainUser || null,
    DATA_TRFR: 'N',
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
  });
}

async function assertTagOpeningUnconsumedTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
): Promise<Map<string, number>> {
  const sourceRows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "TAG_NO","VCH_SRNO","IT_CODE" FROM "BAR_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6
      ORDER BY "TAG_NO","VCH_SRNO","IT_CODE",row_id FOR UPDATE`,
    ...params(scope, voucherNo),
  );
  const persistedTagSrnos = new Map<string, number>();
  for (const source of sourceRows) {
    const tagNo = text(source.TAG_NO);
    if (persistedTagSrnos.has(tagNo)) {
      throw new StockVoucherValidationError(`tag opening has ambiguous duplicate tag: ${tagNo}`);
    }
    persistedTagSrnos.set(tagNo, n(source.VCH_SRNO));
    // Use the same identity lock as issueTagTx. A concurrent sale must either finish first and be
    // observed below, or wait until this edit/delete commits and then re-check availability.
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `tag-issue|${scope.coCode}|${scope.lcCode}|${tagNo}`,
    );
  }
  for (const source of sourceRows) {
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "TAG_NO","VCH_SRNO","IT_CODE" FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)=coalesce($5::numeric,0)
          AND coalesce("IT_CODE"::text,'')=coalesce($6::text,'') AND "ITM_SIGN"='-'
          AND NOT ("CO_YEAR"=$7 AND "CO_BOOK"=$8 AND "VCH_NO"=$9)
        ORDER BY row_id LIMIT 1 FOR UPDATE`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      source.TAG_NO,
      source.VCH_SRNO ?? 0,
      source.IT_CODE ?? '',
      scope.coYear,
      scope.coBook,
      voucherNo,
    );
    if (rows.length) {
      const row = rows[0]!;
      throw new StockVoucherValidationError(
        `tag ${text(row.TAG_NO)} (${n(row.VCH_SRNO)}) has already been consumed by a later voucher`,
      );
    }
  }
  return persistedTagSrnos;
}

type BalanceLine = {
  itCode: string;
  lotNo?: string;
  pcs: number;
  grossWt: number;
  netWt: number;
  fineWt: number;
};

const balanceKey = (line: Pick<BalanceLine, 'itCode' | 'lotNo'>): string =>
  `${line.itCode}\u0000${text(line.lotNo)}`;

async function assertLooseReplacementSafeTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  proposed: BalanceLine[],
  knownAffected?: Array<Pick<BalanceLine, 'itCode' | 'lotNo'>>,
): Promise<Array<Pick<BalanceLine, 'itCode' | 'lotNo'>>> {
  const oldRows: Array<Record<string, unknown>> = knownAffected
    ? []
    : await tx.$queryRawUnsafe(
        `SELECT "IT_CODE",coalesce("ITM_LOT"::text,'') AS lot_no FROM "MAIN_STOCK"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
            AND "CO_BOOK"=$5 AND "VCH_NO"=$6 FOR UPDATE`,
        ...params(scope, voucherNo),
      );
  const affectedLines = (
    knownAffected ?? [
      ...oldRows.map((row) => ({ itCode: text(row.IT_CODE), lotNo: text(row.lot_no) })),
      ...proposed,
    ]
  ).filter((line) => line.itCode);
  const affected = new Map(affectedLines.map((line) => [balanceKey(line), line]));
  if (!affected.size) return [];

  // Namespace: loose-stock|CO|LC|IT_CODE|LOT. Sort lock keys so multi-identity edits cannot deadlock.
  const lockKeys = [...affected.values()]
    .map((line) => `loose-stock|${scope.coCode}|${scope.lcCode}|${line.itCode}|${text(line.lotNo)}`)
    .sort();
  for (const lockKey of lockKeys) {
    await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', lockKey);
  }
  // Residual limitation: loose consumers (for example sales) do not yet take this lock; today it
  // serializes stock-voucher edits and any future participant in this namespace.

  const itemCodes = Array.from(new Set(affectedLines.map((line) => line.itCode)));
  const balances: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE",coalesce("ITM_LOT"::text,'') AS lot_no,
            coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_PCS",0) ELSE -coalesce("ITM_PCS",0) END),0)::float pcs,
            coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_GWT",0) ELSE -coalesce("ITM_GWT",0) END),0)::float gwt,
            coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_NWT",0) ELSE -coalesce("ITM_NWT",0) END),0)::float nwt,
            coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN coalesce("ITM_FINE",0) ELSE -coalesce("ITM_FINE",0) END),0)::float fine
       FROM "MAIN_STOCK"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "IT_CODE"::text=ANY($4::text[])
        AND NOT ("CO_YEAR"=$5 AND "CO_BOOK"=$6 AND "VCH_NO"=$7)
      GROUP BY "IT_CODE",coalesce("ITM_LOT"::text,'')`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    itemCodes,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  const totals = new Map<string, BalanceLine>();
  for (const [key, line] of affected) {
    totals.set(key, {
      itCode: line.itCode,
      lotNo: text(line.lotNo),
      pcs: 0,
      grossWt: 0,
      netWt: 0,
      fineWt: 0,
    });
  }
  for (const row of balances) {
    const line = { itCode: text(row.IT_CODE), lotNo: text(row.lot_no) };
    const key = balanceKey(line);
    if (!totals.has(key)) continue;
    totals.set(key, {
      ...line,
      pcs: n(row.pcs),
      grossWt: n(row.gwt),
      netWt: n(row.nwt),
      fineWt: n(row.fine),
    });
  }
  for (const line of proposed) {
    const total = totals.get(balanceKey(line))!;
    total.pcs += line.pcs;
    total.grossWt += line.grossWt;
    total.netWt += line.netWt;
    total.fineWt += line.fineWt;
  }
  for (const total of totals.values()) {
    if ([total.pcs, total.grossWt, total.netWt, total.fineWt].some((value) => value < -0.0005)) {
      throw new StockVoucherValidationError(
        `item ${total.itCode}${total.lotNo ? ` lot ${total.lotNo}` : ''} has already been consumed; this edit would strand negative stock`,
      );
    }
  }
  return [...affected.values()].map((line) => ({
    itCode: line.itCode,
    lotNo: text(line.lotNo),
  }));
}

function tagBalanceLines(lines: TagOpeningLine[]): BalanceLine[] {
  return lines.map((line) => ({
    itCode: text(line.itCode),
    pcs: n(line.pcs),
    grossWt: n(line.grossWt),
    netWt: n(line.netWt),
    fineWt: line.fineWt != null ? n(line.fineWt) : fineFor('tagOpening', line),
  }));
}

function itemBalanceLines(
  lines: ItemOpeningLine[] | ItemLotLine[],
  workflow: Extract<FineWorkflow, 'itemOpening' | 'itemLot'>,
): BalanceLine[] {
  return lines.map((line) => ({
    itCode: text(line.itCode),
    pcs: n(line.pcs),
    grossWt: n(line.grossWt),
    netWt: n(line.netWt),
    fineWt:
      line.fineWt != null
        ? n(line.fineWt)
        : fineFor(workflow, {
            netWt: line.netWt,
            ghtWt: line.ghtWt,
            touch: line.touch,
            westPct: line.westPct,
          }),
  }));
}

function itemLotBalanceLines(lines: ItemLotLine[], voucherNo: string): BalanceLine[] {
  return itemBalanceLines(lines, 'itemLot').map((line, index) => ({
    ...line,
    lotNo: (text(lines[index]?.lotNo) || `L${voucherNo}${index + 1}`).slice(0, 10),
  }));
}

async function writeTagOpeningTx(
  tx: any,
  input: TagOpeningInput,
  policy: BookPolicy,
  date: Date,
  ctx: WriteContext,
): Promise<{ vchNo: number; tags: number; tagNos: string[] }> {
  if (!input.lines?.length) {
    throw new StockVoucherValidationError('tag opening requires at least one tag line');
  }
  const scope = input.scope as CompleteScope;
  const key = voucherKey(scope, ctx.voucherNo);
  const types = await itemTypesTx(
    tx,
    scope,
    input.lines.map((line) => text(line.itCode)),
  );
  const missingItems = input.lines
    .map((line) => text(line.itCode))
    .filter((code) => !types.has(code));
  if (missingItems.length) {
    throw new StockVoucherValidationError(`tag opening item not found: ${missingItems[0]}`);
  }
  const duplicateTag = input.lines
    .map((line) => text(line.tagNo))
    .find((tagNo, index, values) => tagNo && values.indexOf(tagNo) !== index);
  if (duplicateTag)
    throw new StockVoucherValidationError(`duplicate tag identity: ${duplicateTag}`);
  const identities: Array<{ tagNo: string; vchSrno: number }> = [];
  for (const line of input.lines) {
    if (!text(line.itCode)) throw new StockVoucherValidationError('tag opening item is required');
    const persistedSrno = ctx.persistedTagSrnos?.get(text(line.tagNo));
    if (persistedSrno != null && persistedSrno > 0 && text(line.tagNo)) {
      identities.push({ tagNo: text(line.tagNo), vchSrno: persistedSrno });
    } else {
      const allocated = await nextTagNoTx(tx, scope, { prefix: text(line.itCode).slice(0, 3) });
      identities.push({
        tagNo: text(line.tagNo) || allocated.tagNo,
        vchSrno: allocated.srno,
      });
    }
  }
  const duplicate = identities.find(
    (identity, index) =>
      identities.findIndex(
        (other) => other.tagNo === identity.tagNo && other.vchSrno === identity.vchSrno,
      ) !== index,
  );
  if (duplicate) {
    throw new StockVoucherValidationError(`duplicate tag identity: ${duplicate.tagNo}`);
  }
  await insertIdentityTx(tx, scope, policy, date, { stockItCode: input.stockItCode }, ctx);
  const stamp = voucherTimestamp(date, ctx.persistedClock);
  const fineOf = (line: TagOpeningLine): number =>
    line.fineWt != null ? n(line.fineWt) : fineFor('tagOpening', line);
  const details = input.lines.map((line, index) => ({
    ...key,
    SR_NO: index + 1,
    OLD_SRNO: index + 1,
    VCH_DATE: date,
    STK_DATE: date.toISOString().slice(0, 10),
    VCH_TIME: stamp,
    VCH_TYPE: policy.vchType,
    BOOK_NAME: policy.bookName.slice(0, 20),
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    TBL_CODE: line.tblCode ?? '001',
    TAG_NO: identities[index]!.tagNo,
    VCH_SRNO: identities[index]!.vchSrno,
    IT_CODE: text(line.itCode),
    IT_TYPE: types.get(text(line.itCode)) || null,
    ITM_PCS: n(line.pcs),
    ITM_GWT: n(line.grossWt),
    ITM_NWT: n(line.netWt),
    ITM_TOUCH: n(line.touch),
    ITM_GHT_WT: n(line.ghtWt),
    ITM_WEST_PRC: n(line.westPct),
    ITM_FINE: fineOf(line),
    ITM_RATE: n(line.rate),
    ITM_MRP: n(line.mrp),
    DESIGN_NO: text(line.designNo) || null,
    ITM_SIZE: text(line.itmSize) || null,
    ITM_OTH_WT: n(line.lessWt),
    LBR_PRC: n(line.lbrPct),
    LBR_TYPE: text(line.lbrType) || null,
    LBR_RATE: n(line.lbrRate),
    LBR_AMT: n(line.lbrAmt),
    OTH_AMT: n(line.othAmt),
    TAG_COST: n(line.tagCost),
    HD_VCH_NO: ctx.hiddenVoucherNo,
    MAIN_USER: ctx.mainUser || null,
    DATA_TRFR: 'N',
    DATA_TYPE: 'A',
    // Desktop BAR_DETL columns from the tag grid (TR_TAG_OPBL.cs:9294-9400, 10925-11130).
    // A blank grid cell persists as '' / 0 on the desktop, so the same defaults apply here.
    ITM_STYLE: text(line.itmStyle).slice(0, 20) || null, // mSG[L,8]  :9317
    ITM_COLOR: text(line.itmColor).slice(0, 15) || null, // mSG[i,9]  :10967
    ITM_MARGIN: n(line.itmMargin), // mSG[L,49] :9348
    LBR_CODE: text(line.lbrCode).slice(0, 4) || null, // mSG[i,24] :11028
    SL_TYPE: text(line.slType).slice(0, 1) || null, // mSG[i,38] :11038
    EMP_ISU: text(line.empIsu).slice(0, 1) || null, // mSG[i,100]:11111
    DESIGN_IMG_ID: text(line.designImageId).slice(0, 50) || null, // mSG[i,101]:11112
    MAIN_MARGIN_PRC: n(line.mainMarginPct), // mSG[i,47] :11060
    MAIN_MRP: n(line.mainMrp), // mSG[i,48] :11061
    HM_ID2: text(line.hallmarkId2).slice(0, 10) || null, // mSG[L,82] :9376
    HM_ID3: text(line.hallmarkId3).slice(0, 10) || null, // mSG[L,83] :9377
    HM_ID4: text(line.hallmarkId4).slice(0, 10) || null, // mSG[L,84] :9378
    HM_ID_WT: n(line.hallmarkIdWt), // mSG[L,85] :9379
    HM_ID2_WT: n(line.hallmarkId2Wt), // mSG[L,86] :9380
    HM_ID3_WT: n(line.hallmarkId3Wt), // mSG[L,87] :9381
    HM_ID4_WT: n(line.hallmarkId4Wt), // mSG[L,88] :9382
    KR_LBR_RATE: n(line.karigarLbrRate), // mSG[L,35] :9341
    KR_LBR_AMT: n(line.karigarLbrAmt), // mSG[L,36] :9342
    KR_OTH_AMT: n(line.karigarOthAmt), // mSG[L,37] :9343
    KR_OTH_RATE: n(line.karigarOthRate), // mSG[i,39] :11039
    KR_OTH_FINE: n(line.karigarOthFine), // mSG[i,40] :11040
    KR_TOT_FINE: n(line.karigarTotFine), // mSG[i,41] :11041
    KR_GWT_TOUCH: n(line.karigarGwtTouch), // mSG[i,42] :11042
    KR_COST: n(line.karigarCost), // mSG[L,45] :9344
    KR_NAME: text(line.karigarName).slice(0, 5) || null, // mSG[L,53] :9351
    KR_WAX_WT: n(line.karigarWaxWt), // mSG[i,60] :11110
    JDT_JDT_WT: n(line.jdtJdtWt), // mSG[i,54] :11104
    JDT_GHT_WT: n(line.jdtGhtWt), // mSG[i,55] :11105
    JDT_KUN_WT: n(line.jdtKunWt), // mSG[i,56] :11106
    JDT_KUN_TOUCH: n(line.jdtKunTouch), // mSG[i,57] :11107
    JDT_KUN_NET: n(line.jdtKunNet), // mSG[i,58] :11108
    JDT_WAX_WT: n(line.jdtWaxWt), // mSG[i,59] :11109
    ORD_NO: text(line.ordNo).slice(0, 10) || null, // mSG[i,4]  :11097
    ORD_SRNO: n(line.ordSrno), // mSG[i,90] :11098
    ORD_YRCD: text(line.ordYrcd).slice(0, 9) || null, // mSG[i,91] :11099
    ORD_DBCD: text(line.ordDbcd).slice(0, 3) || null, // mSG[i,92] :11100
    ORD_AC: text(line.ordAc).slice(0, 10) || null, // mSG[i,94] :11101
    ORD_LC_CODE: text(line.ordLcCode).slice(0, 2) || null, // mSG[i,95] :11102
    SF_NO: text(line.sfNo).slice(0, 15) || null, // mSG[i,97] :11103
    MFG_NO: text(line.mfgNo).slice(0, 10) || null, // mSG[i,2]  :11116
    MFG_YRCD: text(line.mfgYrcd).slice(0, 10) || null, // mSG[i,103]:11123
    MFG_DBCD: text(line.mfgDbcd).slice(0, 3) || null, // mSG[i,104]:11124
    MFG_SRNO: n(line.mfgSrno), // mSG[i,106]:11125
  }));
  const itemDetails = input.lines.map((line, index) => ({
    ...key,
    SR_NO: index + 1,
    ISR_NO: 1,
    VCH_DATE: date,
    VCH_TYPE: policy.vchType,
    BOOK_NAME: policy.bookName.slice(0, 20),
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    TAG_NO: identities[index]!.tagNo,
    VCH_SRNO: identities[index]!.vchSrno,
    IT_CODE: text(line.itCode),
    IT_TYPE: types.get(text(line.itCode)) || null,
    IT_PCS: n(line.pcs),
    IT_GWT: n(line.grossWt),
    MAIN_USER: ctx.mainUser || null,
  }));
  const tagStock = input.lines.map((line, index) => ({
    ...key,
    SR_NO: index + 1,
    VCH_DATE: date,
    VCH_TYPE: 'TAGOP',
    BOOK_NAME: policy.bookName.slice(0, 20),
    TBL_CODE: line.tblCode ?? '001',
    IT_CODE: text(line.itCode),
    TAG_NO: identities[index]!.tagNo,
    VCH_SRNO: identities[index]!.vchSrno,
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: n(line.netWt) || n(line.pcs) || 1,
    ITM_PCS: n(line.pcs) || 1,
    ITM_GWT: n(line.grossWt),
    ITM_NWT: n(line.netWt),
    ITM_TOUCH: n(line.touch),
    ITM_FINE: fineOf(line),
    ITM_RATE: n(line.rate),
    ITM_MRP: n(line.mrp),
    LBR_AMT: n(line.lbrAmt),
    OTH_AMT: n(line.othAmt),
    MAIN_USER: ctx.mainUser || null,
  }));
  const relief = text(input.stockItCode)
    ? input.lines.map((line, index) => ({
        ...key,
        SR_NO: input.lines.length + index + 1,
        VCH_DATE: date,
        VCH_TYPE: 'TAGOP',
        BOOK_NAME: policy.bookName.slice(0, 20),
        TBL_CODE: line.tblCode ?? '001',
        IT_CODE: text(input.stockItCode),
        TAG_NO: 'N',
        VCH_SRNO: 0,
        TR_TYPE: 'O',
        ITM_SIGN: '-',
        ITM_QTY: n(line.netWt) || n(line.pcs) || 1,
        ITM_PCS: n(line.pcs) || 1,
        ITM_GWT: n(line.grossWt),
        ITM_NWT: n(line.netWt),
        ITM_TOUCH: n(line.touch),
        ITM_FINE: fineOf(line),
        MAIN_USER: ctx.mainUser || null,
      }))
    : [];
  await postVoucherTx(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [] },
    writes: [
      { table: 'BAR_DETL', rows: details },
      { table: 'BAR_IDTL', rows: itemDetails },
      { table: 'MAIN_STOCK', rows: [...tagStock, ...relief] },
    ],
  });
  return {
    vchNo: Number(ctx.voucherNo),
    tags: input.lines.length,
    tagNos: identities.map((x) => x.tagNo),
  };
}

async function writeItemOpeningTx(
  tx: any,
  input: ItemOpeningInput,
  policy: BookPolicy,
  date: Date,
  ctx: WriteContext,
): Promise<{ vchNo: number; items: number }> {
  if (!input.lines?.length) {
    throw new StockVoucherValidationError('item opening requires at least one line');
  }
  const scope = input.scope as CompleteScope;
  const key = voucherKey(scope, ctx.voucherNo);
  const fineOf = (line: ItemOpeningLine): number =>
    line.fineWt != null ? n(line.fineWt) : fineFor('itemOpening', line);
  const amountOf = (line: ItemOpeningLine): number =>
    line.amount != null ? n(line.amount) : r2(fineOf(line) * n(line.rate));
  await insertIdentityTx(tx, scope, policy, date, {}, ctx);
  const details = input.lines.map((line, index) => ({
    // TR_ITM_OPBL.cs carries the diamond weight, rate and amount on an opening line: a mixed ornament's
    // opening value has a stone component as well as a metal one. (BAR_DETL has no DM_* columns — an
    // earlier attempt put these on the tag-opening writer and failed with 42703 at the database.)
    DM_WT: n(line.diamondWt),
    DM_RATE: n(line.diamondRate),
    DM_AMT: n(line.diamondAmount),
    ...key,
    SR_NO: index + 1,
    IT_CODE: text(line.itCode),
    ITM_PCS: n(line.pcs),
    ITM_GWT: n(line.grossWt),
    ITM_NWT: n(line.netWt),
    ITM_TOUCH: n(line.touch),
    ITM_WEST_PRC: n(line.westPct),
    ITM_FINE: fineOf(line),
    ITM_RATE: n(line.rate),
    ITM_AMT: amountOf(line),
    NET_AMT: amountOf(line),
    MAIN_USER: ctx.mainUser || null,
    ADD_DATE: date.toISOString().slice(0, 10),
    DATA_TRFR: 'N',
    DATA_TYPE: 'A',
  }));
  const stock = input.lines.map((line, index) => ({
    ...key,
    SR_NO: index + 1,
    VCH_DATE: date,
    VCH_TYPE: 'ITOBL',
    BOOK_NAME: policy.bookName.slice(0, 20),
    TBL_CODE: '000',
    IT_CODE: text(line.itCode),
    TAG_NO: 'N',
    TR_TYPE: 'P',
    ITM_SIGN: '+',
    ITM_QTY: n(line.netWt) || n(line.pcs) || 1,
    ITM_PCS: n(line.pcs) || 1,
    ITM_GWT: n(line.grossWt),
    ITM_NWT: n(line.netWt),
    ITM_TOUCH: n(line.touch),
    ITM_FINE: fineOf(line),
    ITM_RATE: n(line.rate),
    ITM_AMT: amountOf(line),
    NET_AMT: amountOf(line),
    MAIN_USER: ctx.mainUser || null,
  }));
  await postVoucherTx(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [] },
    writes: [
      { table: 'ITM_OPBL', rows: details },
      { table: 'MAIN_STOCK', rows: stock },
    ],
  });
  return { vchNo: Number(ctx.voucherNo), items: input.lines.length };
}

async function writeItemLotTx(
  tx: any,
  input: ItemLotInput,
  policy: BookPolicy,
  date: Date,
  ctx: WriteContext,
): Promise<{ vchNo: number; lots: number }> {
  if (!input.lines?.length) {
    throw new StockVoucherValidationError('item lot requires at least one line');
  }
  const scope = input.scope as CompleteScope;
  const key = voucherKey(scope, ctx.voucherNo);
  const types = await itemTypesTx(
    tx,
    scope,
    input.lines.map((line) => text(line.itCode)),
  );
  const missingItems = input.lines
    .map((line) => text(line.itCode))
    .filter((code) => !types.has(code));
  if (missingItems.length) {
    throw new StockVoucherValidationError(`item lot item not found: ${missingItems[0]}`);
  }
  const fineOf = (line: ItemLotLine): number =>
    line.fineWt != null ? n(line.fineWt) : fineFor('itemLot', line);
  const metalOf = (line: ItemLotLine): number => r2(fineOf(line) * n(line.rate));
  const labourOf = (line: ItemLotLine): number => r2(n(line.netWt) * n(line.making));
  const netOf = (line: ItemLotLine): number =>
    r2(metalOf(line) + labourOf(line) + n(line.otherAmount));
  const lotNoOf = (line: ItemLotLine, index: number): string =>
    (text(line.lotNo) || `L${ctx.voucherNo}${index + 1}`).slice(0, 10);
  await insertIdentityTx(tx, scope, policy, date, { acCode: input.acCode }, ctx);
  const details = input.lines.map((line, index) => ({
    ...key,
    SR_NO: index + 1,
    VCH_DATE: date,
    STK_DATE: date,
    VCH_TYPE: policy.vchType,
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    BOOK_NAME: policy.bookName.slice(0, 20),
    AC_CODE: text(input.acCode) || null,
    LOT_NO: lotNoOf(line, index),
    DESIGN_NO: text(line.designNo) || null,
    TBL_CODE: '000',
    ITM_SIZE: text(line.itmSize) || null,
    IT_CODE: text(line.itCode),
    PR_CODE: text(line.prCode) || null,
    IT_TYPE: types.get(text(line.itCode)),
    ITM_PCS: n(line.pcs),
    ITM_GWT: n(line.grossWt),
    ITM_OTH_WT: n(line.otherWt),
    ITM_NWT: n(line.netWt),
    ITM_TOUCH: n(line.touch),
    ITM_WEST_PRC: n(line.westPct),
    ITM_FINE: fineOf(line),
    LBR_RATE: n(line.making),
    LBR_AMT: labourOf(line),
    OTH_AMT: n(line.otherAmount),
    ITM_RATE: n(line.rate),
    ITM_AMT: metalOf(line),
    ITM_REMARK: text(line.remark) || null,
    HD_VCH_NO: ctx.hiddenVoucherNo,
    MAIN_USER: ctx.mainUser || null,
    DATA_TYPE: 'A',
    DATA_TRFR: 'N',
  }));
  const stock = input.lines.map((line, index) => ({
    ...key,
    SR_NO: index + 1,
    ISR_NO: 2,
    VCH_DATE: date,
    STK_DATE: date.toISOString().slice(0, 10),
    VCH_TYPE: 'ITLOT',
    BOOK_NAME: policy.bookName.slice(0, 20),
    AC_CODE: text(input.acCode) || null,
    IT_CODE: text(line.itCode),
    TAG_NO: 'N',
    TBL_CODE: '000',
    TR_TYPE: 'I',
    ITM_SIGN: '+',
    ITM_QTY: 1,
    ITM_PCS: n(line.pcs) || 1,
    ITM_GWT: n(line.grossWt),
    ITM_NWT: n(line.netWt),
    ITM_TOUCH: n(line.touch),
    ITM_WEST: n(line.westPct),
    ITM_FINE: fineOf(line),
    ITM_RATE: n(line.rate),
    ITM_AMT: metalOf(line),
    LBR_AMT: labourOf(line),
    OTH_AMT: n(line.otherAmount),
    NET_AMT: netOf(line),
    DESIGN_NO: text(line.designNo) || null,
    ITM_SIZE: text(line.itmSize) || null,
    ITM_LOT: lotNoOf(line, index),
    MAIN_USER: ctx.mainUser || null,
  }));
  await postVoucherTx(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [] },
    writes: [
      { table: 'ITM_LOT_DETL', rows: details },
      { table: 'MAIN_STOCK', rows: stock },
    ],
  });
  return { vchNo: Number(ctx.voucherNo), lots: input.lines.length };
}

async function createContextTx(
  tx: any,
  scope: CompleteScope,
  mainUser: string | undefined,
): Promise<WriteContext> {
  return {
    voucherNo: formatVoucherNo(await nextVoucherNoTx(tx, scope)),
    hiddenVoucherNo: await nextHiddenVoucherNoTx(tx, scope),
    mainUser: text(mainUser),
  };
}

export async function tagOpening(prisma: any, input: TagOpeningInput) {
  completeScope(input.scope);
  const scope = input.scope;
  const requested = businessDate(input.vchDate);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope, 'tag-opening');
    await assertDatesOpenTx(tx, scope, requested);
    return writeTagOpeningTx(
      tx,
      input,
      policy,
      requested.date,
      await createContextTx(tx, scope, input.mainUser),
    );
  });
}

export async function itemOpening(prisma: any, input: ItemOpeningInput) {
  completeScope(input.scope);
  const scope = input.scope;
  const requested = businessDate(input.vchDate);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope, 'item-opening');
    await assertDatesOpenTx(tx, scope, requested);
    return writeItemOpeningTx(
      tx,
      input,
      policy,
      requested.date,
      await createContextTx(tx, scope, input.mainUser),
    );
  });
}

export async function itemLot(prisma: any, input: ItemLotInput) {
  completeScope(input.scope);
  const scope = input.scope;
  const requested = businessDate(input.vchDate);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope, 'item-lot');
    await assertDatesOpenTx(tx, scope, requested);
    return writeItemLotTx(
      tx,
      input,
      policy,
      requested.date,
      await createContextTx(tx, scope, input.mainUser),
    );
  });
}

async function getHeaderAndRows(
  prisma: any,
  scopeInput: VoucherScope,
  requestedVoucherNo: number | string,
  kind: Kind,
  table: string,
  columns: string,
): Promise<{
  header: Record<string, unknown>;
  rows: Array<Record<string, unknown>>;
  voucherNo: string;
}> {
  completeScope(scopeInput);
  const scope = scopeInput;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope, kind);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"VCH_TIME","HD_VCH_NO","MAIN_USER","STK_IT_CODE","AC_CODE"
         FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...params(scope, voucherNo),
    );
    if (headers.length !== 1) {
      throw new StockVoucherValidationError(
        headers.length
          ? `${kind} voucher is ambiguous: ${voucherNo}`
          : `${kind} voucher not found: ${voucherNo}`,
      );
    }
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT ${columns} FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      ...params(scope, voucherNo),
    );
    return { header: headers[0]!, rows, voucherNo };
  });
}

export async function getTagOpening(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  const { header, rows, voucherNo } = await getHeaderAndRows(
    prisma,
    scope,
    requestedVoucherNo,
    'tag-opening',
    'BAR_DETL',
    '"SR_NO","TAG_NO","VCH_SRNO","IT_CODE","TBL_CODE","DESIGN_NO","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_GHT_WT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","ITM_MRP","LBR_PRC","LBR_TYPE","LBR_RATE","LBR_AMT","OTH_AMT","TAG_COST"',
  );
  return {
    voucherNo,
    hiddenVoucherNo: text(header.HD_VCH_NO),
    mainUser: text(header.MAIN_USER),
    vchDate: text(header.VCH_DATE).slice(0, 10),
    stockItCode: text(header.STK_IT_CODE),
    lines: rows.map((row) => ({
      srNo: n(row.SR_NO),
      tagNo: text(row.TAG_NO),
      vchSrno: n(row.VCH_SRNO),
      itCode: text(row.IT_CODE),
      tblCode: text(row.TBL_CODE),
      designNo: text(row.DESIGN_NO),
      itmSize: text(row.ITM_SIZE),
      pcs: n(row.ITM_PCS),
      grossWt: n(row.ITM_GWT),
      lessWt: n(row.ITM_OTH_WT),
      netWt: n(row.ITM_NWT),
      ghtWt: n(row.ITM_GHT_WT),
      touch: n(row.ITM_TOUCH),
      westPct: n(row.ITM_WEST_PRC),
      fineWt: n(row.ITM_FINE),
      rate: n(row.ITM_RATE),
      mrp: n(row.ITM_MRP),
      lbrPct: n(row.LBR_PRC),
      lbrType: text(row.LBR_TYPE),
      lbrRate: n(row.LBR_RATE),
      lbrAmt: n(row.LBR_AMT),
      othAmt: n(row.OTH_AMT),
      tagCost: n(row.TAG_COST),
    })),
  };
}

export async function getItemOpening(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  const { header, rows, voucherNo } = await getHeaderAndRows(
    prisma,
    scope,
    requestedVoucherNo,
    'item-opening',
    'ITM_OPBL',
    '"SR_NO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","ITM_AMT"',
  );
  return {
    voucherNo,
    hiddenVoucherNo: text(header.HD_VCH_NO),
    mainUser: text(header.MAIN_USER),
    vchDate: text(header.VCH_DATE).slice(0, 10),
    lines: rows.map((row) => ({
      srNo: n(row.SR_NO),
      itCode: text(row.IT_CODE),
      pcs: n(row.ITM_PCS),
      grossWt: n(row.ITM_GWT),
      netWt: n(row.ITM_NWT),
      touch: n(row.ITM_TOUCH),
      westPct: n(row.ITM_WEST_PRC),
      fineWt: n(row.ITM_FINE),
      rate: n(row.ITM_RATE),
      amount: n(row.ITM_AMT),
    })),
  };
}

export async function getItemLot(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  const { header, rows, voucherNo } = await getHeaderAndRows(
    prisma,
    scope,
    requestedVoucherNo,
    'item-lot',
    'ITM_LOT_DETL',
    '"SR_NO","AC_CODE","IT_CODE","LOT_NO","DESIGN_NO","ITM_SIZE","PR_CODE","IT_TYPE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","ITM_RATE","LBR_RATE","OTH_AMT","ITM_REMARK"',
  );
  return {
    voucherNo,
    hiddenVoucherNo: text(header.HD_VCH_NO),
    mainUser: text(header.MAIN_USER),
    vchDate: text(header.VCH_DATE).slice(0, 10),
    acCode: text(header.AC_CODE) || text(rows[0]?.AC_CODE),
    lines: rows.map((row) => ({
      srNo: n(row.SR_NO),
      itCode: text(row.IT_CODE),
      lotNo: text(row.LOT_NO),
      designNo: text(row.DESIGN_NO),
      itmSize: text(row.ITM_SIZE),
      prCode: text(row.PR_CODE),
      itType: text(row.IT_TYPE) === 'S' ? 'S' : 'G',
      pcs: n(row.ITM_PCS),
      grossWt: n(row.ITM_GWT),
      otherWt: n(row.ITM_OTH_WT),
      netWt: n(row.ITM_NWT),
      touch: n(row.ITM_TOUCH),
      westPct: n(row.ITM_WEST_PRC),
      fineWt: n(row.ITM_FINE),
      rate: n(row.ITM_RATE),
      making: n(row.LBR_RATE),
      otherAmount: n(row.OTH_AMT),
      remark: text(row.ITM_REMARK),
    })),
  };
}

async function editContextTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  kind: Kind,
  requested: { date: Date; iso: string },
): Promise<WriteContext> {
  const persisted = await headerTx(tx, scope, voucherNo, kind);
  await assertDatesOpenTx(tx, scope, requested, persisted.VCH_DATE);
  return {
    voucherNo,
    hiddenVoucherNo: formatVoucherNo(text(persisted.HD_VCH_NO)),
    mainUser: text(persisted.MAIN_USER),
    persistedClock: persisted.VCH_CLOCK,
  };
}

export async function editTagOpening(
  prisma: any,
  input: TagOpeningInput,
  requestedVoucherNo: number | string,
) {
  completeScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requested = businessDate(input.vchDate);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope, 'tag-opening');
    const ctx = await editContextTx(tx, scope, voucherNo, 'tag-opening', requested);
    // Desktop blocks edits/deletes after a generated tag is consumed: TR_TAG_OPBL.cs:11373-11381.
    ctx.persistedTagSrnos = await assertTagOpeningUnconsumedTx(tx, scope, voucherNo);
    await deleteVoucherWriteSetTx(tx, {
      // Desktop edit rewrites the full set and TEMP_BOOK_DATA without DELETE_DATA:
      // TR_TAG_OPBL.cs:10852-10866; DELETE_DATA appears only in BtnDelete at 11391.
      tables: ['BAR_IDTL', 'BAR_DETL', 'MAIN_STOCK', 'BAR_DATA'],
      key: { scope, voucherNo },
      tempBook: { voucherNo: ctx.hiddenVoucherNo },
    });
    return writeTagOpeningTx(tx, input, policy, requested.date, ctx);
  });
}

export async function editItemOpening(
  prisma: any,
  input: ItemOpeningInput,
  requestedVoucherNo: number | string,
) {
  completeScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requested = businessDate(input.vchDate);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope, 'item-opening');
    const ctx = await editContextTx(tx, scope, voucherNo, 'item-opening', requested);
    const proposed = itemBalanceLines(input.lines, 'itemOpening');
    const affected = await assertLooseReplacementSafeTx(tx, scope, voucherNo, proposed);
    // TR_ITM_OPBL.cs:1399-1474 replaces ITM_OPBL/MAIN_STOCK; edit writes no DELETE_DATA.
    await deleteVoucherWriteSetTx(tx, {
      tables: ['ITM_OPBL', 'MAIN_STOCK', 'BAR_DATA'],
      key: { scope, voucherNo },
      tempBook: { voucherNo: ctx.hiddenVoucherNo },
    });
    const result = await writeItemOpeningTx(tx, input, policy, requested.date, ctx);
    await assertLooseReplacementSafeTx(tx, scope, voucherNo, proposed, affected);
    return result;
  });
}

export async function editItemLot(
  prisma: any,
  input: ItemLotInput,
  requestedVoucherNo: number | string,
) {
  completeScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const requested = businessDate(input.vchDate);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope, 'item-lot');
    const ctx = await editContextTx(tx, scope, voucherNo, 'item-lot', requested);
    const proposed = itemLotBalanceLines(input.lines, voucherNo);
    const affected = await assertLooseReplacementSafeTx(tx, scope, voucherNo, proposed);
    // TR_ITM_LOT.cs:3759-3761 and 3889-3892 replace header/detail/stock/TEMP_BOOK_DATA;
    // unlike deletion, edit has no DELETE_DATA insert.
    await deleteVoucherWriteSetTx(tx, {
      tables: ['ITM_LOT_DETL', 'MAIN_STOCK', 'BAR_DATA'],
      key: { scope, voucherNo },
      tempBook: { voucherNo: ctx.hiddenVoucherNo },
    });
    const result = await writeItemLotTx(tx, input, policy, requested.date, ctx);
    await assertLooseReplacementSafeTx(tx, scope, voucherNo, proposed, affected);
    return result;
  });
}

export async function deleteTagOpening(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
): Promise<{ reversed: true }> {
  completeScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const policy = await resolveBookTx(tx, scope, 'tag-opening');
    const persisted = await headerTx(tx, scope, voucherNo, 'tag-opening');
    const persistedBusinessDate = businessDate(
      persisted.VCH_DATE instanceof Date
        ? persisted.VCH_DATE
        : text(persisted.VCH_DATE).slice(0, 10),
    );
    await assertDatesOpenTx(tx, scope, persistedBusinessDate, persisted.VCH_DATE);
    await assertTagOpeningUnconsumedTx(tx, scope, voucherNo);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","VCH_DATE","VCH_TIME","AC_CODE","IT_CODE","TAG_NO","IT_TYPE","ITM_NWT","HD_VCH_NO","MAIN_USER"
         FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO" FOR UPDATE`,
      ...params(scope, voucherNo),
    );
    const deletedAt = new Date();
    // Exact desktop audit: detail rows only (no header), NWT in VCH_FINE_CR and configured book
    // identity. TR_TAG_OPBL.cs:11391.
    for (const row of rows) {
      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, {
        ...voucherKey(scope, voucherNo),
        SR_NO: n(row.SR_NO),
        VCH_DATE: row.VCH_DATE,
        DELETE_DATE: deletedAt,
        VCH_TYPE: policy.vchType,
        VCH_TIME: row.VCH_TIME ?? persisted.VCH_TIME,
        DELETE_TIME: deletedAt,
        BOOK_NAME: policy.bookName,
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
      tables: ['BAR_IDTL', 'BAR_DETL', 'MAIN_STOCK', 'BAR_DATA'],
      key: { scope, voucherNo },
      tempBook: { voucherNo: formatVoucherNo(text(persisted.HD_VCH_NO)) },
    });
    return { reversed: true };
  });
}

async function deleteLoose(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
  kind: 'item-opening' | 'item-lot',
): Promise<{ reversed: true }> {
  completeScope(input.scope);
  const scope = input.scope;
  const voucherNo = formatVoucherNo(input.vchNo);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    await resolveBookTx(tx, scope, kind);
    const persisted = await headerTx(tx, scope, voucherNo, kind);
    const persistedBusinessDate = businessDate(
      persisted.VCH_DATE instanceof Date
        ? persisted.VCH_DATE
        : text(persisted.VCH_DATE).slice(0, 10),
    );
    await assertDatesOpenTx(tx, scope, persistedBusinessDate, persisted.VCH_DATE);
    const affected = await assertLooseReplacementSafeTx(tx, scope, voucherNo, []);
    // Desktop emits no DELETE_DATA for either form: TR_ITM_OPBL.cs:1492-1521 and
    // TR_ITM_LOT.cs:3908-3931 delete only their write sets.
    await deleteVoucherWriteSetTx(tx, {
      tables:
        kind === 'item-opening'
          ? ['ITM_OPBL', 'MAIN_STOCK', 'BAR_DATA']
          : ['ITM_LOT_DETL', 'MAIN_STOCK', 'BAR_DATA'],
      key: { scope, voucherNo },
      tempBook: { voucherNo: formatVoucherNo(text(persisted.HD_VCH_NO)) },
    });
    await assertLooseReplacementSafeTx(tx, scope, voucherNo, [], affected);
    return { reversed: true };
  });
}

export async function deleteItemOpening(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
): Promise<{ reversed: true }> {
  return deleteLoose(prisma, input, 'item-opening');
}

export async function deleteItemLot(
  prisma: any,
  input: { scope: VoucherScope; vchNo: number | string; deleteUser?: string },
): Promise<{ reversed: true }> {
  return deleteLoose(prisma, input, 'item-lot');
}
