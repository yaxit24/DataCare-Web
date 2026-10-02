import { withTxBudget } from '../shared/txBudget.js';
import { tagCancelLineQualifies, tagCancelTotals, type TagCancelTotals } from '@datacare/core';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  assertFiscalDateTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import {
  issueTagTx,
  resolveLiveTagIdentityTx,
  restoreTagTx,
  type ResolvedTagIdentity,
  type TagKey,
} from './stock.js';
import {
  TAG_CANCEL_MAIN_BOOKS,
  TagCancelConflictError,
  TagCancelValidationError,
  applyLineInput,
  cellsFromBarDetl,
  cellsFromSaved,
  cellsFromTagStock,
  dbText,
  deleteAuditRows,
  detailRow,
  diamondRows,
  headerRow,
  looseCells,
  num,
  replayBaseline,
  stockRows,
  stoneFromSaved,
  stoneFromTag,
  stoneRows,
  stonesFromInput,
  tempBookRow,
  typedText,
  type TagCancelBookPolicy,
  type TagCancelItem,
  type TagCancelLineInput,
  type TagCancelMode,
  type TagCancelRowCells,
  type TagCancelStoneRow,
  type TagCancelWriteContext,
  type TagCancelWriteLine,
} from './tagCancelRows.js';

export {
  TAG_CANCEL_MAIN_BOOKS,
  TagCancelConflictError,
  TagCancelValidationError,
  type TagCancelLineInput,
  type TagCancelMode,
};
export type { TagCancelStoneInput } from './tagCancelRows.js';

/**
 * Tag Cancel (X19) and Tag Transfer (X18) — desktop `TR_TAG_CAN`, which serves both menus on a book of its own
 * `MAIN_BOOK` (MDI_FORM.cs:8586 "TAG CANCEL", :8664 "TAG TRFR").
 *
 * Contract: `parity-plan-2026-09-10/evidence/implementation-2026-09-29-n18/contract.md` (K1-K16). Summary:
 *
 * - One writer, two modes; the book must be a `CUR_USE = 'Y'` book of the mode's `MAIN_BOOK` (K1).
 * - A tag line cancels exactly one LIVE instance, through the resolver a sale uses (`issueTagTx`); every tag the save
 *   touches is locked first, in sorted order, so a cancel, a transfer and a sale of one tag serialise (K2).
 * - The register rows carry exactly the desktop's columns; the source tag (BAR_DETL, BAR_IDTL, its image) is never
 *   modified, so its children and image are what a reversal makes available again (K6).
 * - MAIN_STOCK follows `Tag_Can_Stk`, DM_DATA `Dm_Tag_Cancel_Detl`, TEMP_BOOK_DATA the hidden number (K7-K9).
 * - Edit releases the voucher's own tags and resolves every line again; delete writes the desktop's DELETE_DATA and
 *   removes the whole write set in one transaction (K10-K11).
 */

type CompleteScope = VoucherScope & { coYear: string; coBook: string };

export interface TagCancelInput {
  scope: VoucherScope;
  /** Voucher date, `YYYY-MM-DD`; today when omitted (the form starts on the system date). */
  vchDate?: string | Date;
  /** Employee (tEmpCode). */
  empCode?: string;
  /** Vch Desc. */
  vchDesc?: string;
  /** The acting user; an edit keeps the voucher's own. */
  mainUser?: string;
  lines: TagCancelLineInput[];
}

export interface TagCancelSaveResult {
  vchNo: number;
  voucherNo: string;
  hiddenVoucherNo: string;
  lines: number;
  stones: number;
  stockRows: number;
  diamondRows: number;
}

export interface TagCancelStoneView {
  isrNo: number;
  itCode: string;
  itName: string;
  pcs: number;
  grossWt: number;
  karigarWt: number;
  conPct: number;
  rateType: string;
  rate: number;
  amount: number;
  lbrRate: number;
  lbrAmount: number;
  netAmount: number;
  conWt: number;
  karigarConWt: number;
  itType: string;
}

export interface TagCancelLineView extends Omit<TagCancelRowCells, 'krOthWt' | 'krGhtWt'> {
  srNo: number;
  oldSrNo: number;
  itName: string;
  trfrItName: string;
  stones: TagCancelStoneView[];
}

export interface TagCancelVoucherView {
  mode: TagCancelMode;
  book: { code: string; name: string; shortName: string; mainBook: string };
  vchNo: number;
  voucherNo: string;
  vchDate: string;
  voucherTime: string;
  hiddenVoucherNo: string;
  mainUser: string;
  empCode: string;
  empName: string;
  vchDesc: string;
  lines: TagCancelLineView[];
  totals: TagCancelTotals;
}

// ---- scope, book, date -----------------------------------------------------------------------------

function completeScope(scope: VoucherScope): CompleteScope {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new TagCancelValidationError(
      'the voucher needs a company, location, fiscal year and book',
    );
  }
  return scope as CompleteScope;
}

/**
 * K1: exactly one BOOK_DATA row for the company, location and book, in use, of the mode's MAIN_BOOK
 * (`CurBookHelp` offers only `CUR_USE = 'Y'` books of the menu's MAIN_BOOK, and `Tag_Can_Stk` insert 1 joins on
 * `CUR_USE = 'Y'`).
 */
async function resolveBookTx(
  tx: any,
  scope: CompleteScope,
  mode: TagCancelMode,
): Promise<TagCancelBookPolicy> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE","CUR_USE"
       FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
      ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coBook,
  );
  if (!rows.length) {
    throw new TagCancelValidationError(
      `book ${scope.coBook} is not configured for location ${scope.lcCode}`,
    );
  }
  if (rows.length > 1) {
    throw new TagCancelValidationError(
      `book ${scope.coBook} is configured more than once for location ${scope.lcCode}`,
    );
  }
  const row = rows[0]!;
  const expected = TAG_CANCEL_MAIN_BOOKS[mode];
  const mainBook = typedText(row.MAIN_BOOK);
  if (mainBook !== expected) {
    const other = mode === 'cancel' ? 'Tag Transfer' : 'Tag Cancel';
    const hint =
      mainBook === TAG_CANCEL_MAIN_BOOKS[mode === 'cancel' ? 'transfer' : 'cancel']
        ? ` — use ${other}`
        : '';
    throw new TagCancelValidationError(
      `book ${scope.coBook} is ${mainBook || 'blank'}, not ${expected}${hint}`,
    );
  }
  if (typedText(row.CUR_USE) !== 'Y') {
    throw new TagCancelValidationError(`book ${scope.coBook} is not in use`);
  }
  return {
    name: dbText(row.BOOK_NAME),
    shortName: dbText(row.BOOK_SNAME).slice(0, 6),
    mainBook: expected,
    inout: dbText(row.BOOK_INOUT).trim().slice(0, 1),
    dataType: dbText(row.DATA_TYPE).trim().slice(0, 1) || 'A',
  };
}

function todayIso(): string {
  const now = new Date();
  const pad = (value: number) => String(value).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
}

function businessDate(value: unknown): { date: Date; iso: string } {
  const raw =
    value instanceof Date
      ? value.toISOString().slice(0, 10)
      : value == null || String(value).trim() === ''
        ? todayIso()
        : String(value).trim().slice(0, 10);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw)) {
    throw new TagCancelValidationError('voucher date is missing or invalid');
  }
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()) || date.toISOString().slice(0, 10) !== raw) {
    throw new TagCancelValidationError('voucher date is missing or invalid');
  }
  return { date, iso: raw };
}

const isoOf = (value: unknown): string =>
  value instanceof Date ? value.toISOString().slice(0, 10) : dbText(value).slice(0, 10);

async function assertOpenTx(tx: any, scope: CompleteScope, date: Date): Promise<void> {
  // TR_TAG_CAN.cs:4965 — "You Cant Save and Delete This Voucher Becouse Lock Date is = …".
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
}

// ---- masters ----------------------------------------------------------------------------------------

async function employeeTx(tx: any, scope: CompleteScope, code: unknown): Promise<string> {
  const empCode = typedText(code, 3);
  if (!empCode) return '';
  const rows: Array<{ EMP_CODE: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "EMP_CODE" FROM "EMP_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND upper(btrim("EMP_CODE"::text))=$3
      ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    empCode,
  );
  if (!rows.length) throw new TagCancelValidationError(`employee ${empCode} not found`);
  return dbText(rows[0]!.EMP_CODE);
}

async function itemsTx(
  tx: any,
  scope: VoucherScope,
  codes: Iterable<string>,
): Promise<Map<string, TagCancelItem>> {
  const wanted = [...new Set([...codes].map((code) => code.trim().toUpperCase()).filter(Boolean))];
  const out = new Map<string, TagCancelItem>();
  if (!wanted.length) return out;
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE","OTH_DETL_POSTING"
       FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND upper(btrim("IT_CODE"::text)) = ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    wanted,
  );
  for (const row of rows) {
    const itCode = dbText(row.IT_CODE).trim().toUpperCase();
    out.set(itCode, {
      itCode: dbText(row.IT_CODE),
      itName: dbText(row.IT_NAME),
      itType: dbText(row.IT_TYPE),
      prCode: dbText(row.PR_CODE),
      rateType: dbText(row.RATE_TYPE),
      postsDiamonds: typedText(row.OTH_DETL_POSTING, 1) === 'Y',
    });
  }
  return out;
}

// ---- tag identity -----------------------------------------------------------------------------------

/**
 * K2.6: lock every tag number the save touches, in sorted order, under the key the shared resolver uses. Taken
 * before any tag is resolved, released or written, so two writers never hold two tags in opposite orders.
 */
async function lockTagsTx(tx: any, scope: VoucherScope, tagNos: Iterable<string>): Promise<void> {
  const sorted = [...new Set([...tagNos].filter(Boolean))].sort();
  for (const tagNo of sorted) {
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `tag-issue|${scope.coCode}|${scope.lcCode}|${tagNo}`,
    );
  }
}

/** The first BAR_DETL row of an instance (`availableBarTags` keeps the same row). */
async function barSourceTx(
  tx: any,
  scope: VoucherScope,
  tagNo: string,
  vchSrno: number,
  itCode: string,
): Promise<Record<string, unknown> | null> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "BAR_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "TAG_NO"=$4
        AND coalesce("VCH_SRNO",0)::numeric=$5::numeric
        AND ($6::text='' OR coalesce("IT_CODE"::text,'')=$6)
      ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    tagNo,
    vchSrno,
    itCode,
  );
  return rows[0] ?? null;
}

/**
 * K5.1: the tag's stones — the BAR_IDTL rows of the first BAR_DETL row's voucher and line (`SR_NO` = that row's
 * OLD_SRNO, same TAG_NO), the join `Dm_Counter_Trfr_Detl` uses (Ac_Stock.cs:833).
 */
async function tagStonesTx(tx: any, source: Record<string, unknown>): Promise<TagCancelStoneRow[]> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT s.*, i."IT_NAME"
       FROM "BAR_IDTL" s
       LEFT JOIN "ITEM_MAST" i ON i.tenant_id=s.tenant_id AND i."CO_CODE"=s."CO_CODE" AND i."IT_CODE"=s."IT_CODE"
      WHERE s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3
        AND s."CO_YEAR" IS NOT DISTINCT FROM $4 AND s."CO_BOOK" IS NOT DISTINCT FROM $5
        AND s."VCH_NO" IS NOT DISTINCT FROM $6
        AND coalesce(s."SR_NO",0)::numeric=$7::numeric AND s."TAG_NO"=$8
      ORDER BY s."ISR_NO", s.row_id`,
    source.tenant_id,
    source.CO_CODE,
    source.LC_CODE,
    source.CO_YEAR ?? null,
    source.CO_BOOK ?? null,
    source.VCH_NO ?? null,
    num(source.OLD_SRNO ?? source.SR_NO),
    source.TAG_NO,
  );
  return rows.map((row, index) => stoneFromTag(row, index + 1));
}

interface TagSource {
  identity: ResolvedTagIdentity;
  cells: TagCancelRowCells;
  itName: string;
  stones: TagCancelStoneRow[];
}

/**
 * Resolve one tag line to its live instance and the row it starts from (K2, K3). `consume` reserves it for the
 * voucher (`issueTagTx`: a TAG_STOCK row is removed; a BAR_DETL instance becomes unavailable when the '-' row is
 * written); the preview resolves without consuming.
 */
async function tagSourceTx(
  tx: any,
  scope: VoucherScope,
  request: { tagNo: string; vchSrno?: number; itCode?: string; row: number },
  consume: boolean,
): Promise<TagSource> {
  const key: TagKey = {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    TAG_NO: request.tagNo,
    ...(request.vchSrno != null ? { VCH_SRNO: request.vchSrno } : {}),
    ...(request.itCode ? { IT_CODE: request.itCode } : {}),
  };
  const identity = consume ? await issueTagTx(tx, key) : await resolveLiveTagIdentityTx(tx, key);
  const vchSrno = num(identity.VCH_SRNO);
  const bar = await barSourceTx(
    tx,
    scope,
    request.tagNo,
    vchSrno,
    identity.source === 'BAR_DETL' ? dbText(identity.IT_CODE) : '',
  );
  if (bar) {
    const cells = cellsFromBarDetl(bar);
    if (request.itCode && typedText(cells.itCode, 5) !== typedText(request.itCode, 5)) {
      throw new TagCancelValidationError(
        `row ${request.row}: tag ${request.tagNo} is item ${cells.itCode}, not ${request.itCode}`,
      );
    }
    const items = await itemsTx(tx, scope, [cells.itCode]);
    return {
      identity,
      cells,
      itName: items.get(cells.itCode.trim().toUpperCase())?.itName ?? '',
      stones: await tagStonesTx(tx, bar),
    };
  }
  // A web tag that lives only in TAG_STOCK: no item code, so the line must name one.
  const itCode = typedText(request.itCode, 5);
  if (!itCode) {
    throw new TagCancelValidationError(
      `row ${request.row}: tag ${request.tagNo} has no item; enter the line's item code`,
    );
  }
  const items = await itemsTx(tx, scope, [itCode]);
  const item = items.get(itCode);
  if (!item) throw new TagCancelValidationError(`row ${request.row}: item ${itCode} not found`);
  return {
    identity,
    cells: cellsFromTagStock(identity.stock, item),
    itName: item.itName,
    stones: [],
  };
}

// ---- the voucher's own rows ---------------------------------------------------------------------------

const voucherParams = (scope: CompleteScope, voucherNo: string) => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];
const VOUCHER_WHERE = `tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
  AND "CO_BOOK"=$5 AND "VCH_NO"=$6`;

async function savedLinesTx(tx: any, scope: CompleteScope, voucherNo: string) {
  const lines: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT d.*, i."IT_NAME", t."IT_NAME" AS "TRFR_IT_NAME"
       FROM "BAR_CAN_DETL" d
       LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
       LEFT JOIN "ITEM_MAST" t ON t.tenant_id=d.tenant_id AND t."CO_CODE"=d."CO_CODE"
                             AND t."IT_CODE"=d."TRFR_IT_CODE"
      WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4
        AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6
      ORDER BY d."SR_NO", d.row_id`,
    ...voucherParams(scope, voucherNo),
  );
  const stones: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT s.*, i."IT_NAME"
       FROM "BAR_CAN_IDTL" s
       LEFT JOIN "ITEM_MAST" i ON i.tenant_id=s.tenant_id AND i."CO_CODE"=s."CO_CODE" AND i."IT_CODE"=s."IT_CODE"
      WHERE s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3 AND s."CO_YEAR"=$4
        AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
      ORDER BY s."SR_NO", s."ISR_NO", s.row_id`,
    ...voucherParams(scope, voucherNo),
  );
  const stonesByLine = new Map<number, TagCancelStoneRow[]>();
  for (const stone of stones) {
    const srNo = num(stone.SR_NO);
    stonesByLine.set(srNo, [...(stonesByLine.get(srNo) ?? []), stoneFromSaved(stone)]);
  }
  return { lines, stonesByLine };
}

const savedTagNos = (lines: readonly Record<string, unknown>[]): string[] =>
  lines
    .map((line) => dbText(line.TAG_NO).trim())
    .filter((tagNo) => tagNo !== '' && tagNo.toUpperCase() !== 'N');

/**
 * K11.3: the tags a voucher consumed that nothing else vouches for. A BAR_DETL instance becomes available again when
 * its '-' row is deleted; a web TAG_STOCK tag was removed on save and is re-inserted from the register row — unless a
 * BAR_DETL instance or a TAG_STOCK row already exists (the rule `releaseRateCutTagsTx` applies).
 */
async function tagStockRestoresTx(
  tx: any,
  scope: CompleteScope,
  lines: readonly Record<string, unknown>[],
): Promise<Array<Record<string, unknown> & TagKey>> {
  const restores: Array<Record<string, unknown> & TagKey> = [];
  for (const line of lines) {
    const tagNo = dbText(line.TAG_NO).trim();
    if (!tagNo || tagNo.toUpperCase() === 'N') continue;
    const vchSrno = num(line.VCH_SRNO);
    const counts: Array<{ bar: number; stock: number }> = await tx.$queryRawUnsafe(
      `SELECT (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)::numeric=$5::numeric) AS bar,
              (SELECT count(*)::int FROM "TAG_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)::numeric=$5::numeric) AS stock`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      tagNo,
      vchSrno,
    );
    if (num(counts[0]?.bar) > 0 || num(counts[0]?.stock) > 0) continue;
    const restore: Record<string, unknown> & TagKey = {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      TAG_NO: tagNo,
      VCH_SRNO: vchSrno,
      ITM_PCS: num(line.ITM_PCS),
      ITM_GWT: num(line.ITM_GWT),
      ITM_NWT: num(line.ITM_NWT),
      STK_TYPE: 'R',
    };
    for (const [column, value] of [
      ['DESIGN_NO', line.DESIGN_NO],
      ['ITM_SIZE', line.ITM_SIZE],
      ['PR_CODE', line.PR_CODE],
      ['IT_TYPE', line.IT_TYPE],
      ['LBR_TYPE', line.LBR_TYPE],
      ['DESIGN_IMG_ID', line.DESIGN_IMG_ID],
    ] as const) {
      const text = dbText(value).trim();
      if (text && !(column === 'DESIGN_IMG_ID' && text === 'N')) restore[column] = text;
    }
    for (const [column, value] of [
      ['LBR_PRC', line.LBR_PRC],
      ['LBR_RATE', line.LBR_RATE],
      ['LBR_AMT', line.LBR_AMT],
      ['OTH_AMT', line.OTH_AMT],
      ['ITM_MRP', line.ITM_MRP],
    ] as const) {
      if (num(value) !== 0) restore[column] = num(value);
    }
    restores.push(restore);
  }
  return restores;
}

const WRITE_SET = [
  'BAR_CAN_IDTL',
  'BAR_CAN_DETL',
  'BAR_CAN_DATA',
  'DM_DATA',
  'MAIN_STOCK',
  'LOT_DETL',
] as const;

async function deleteWriteSetTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  hiddenVoucherNo: string,
): Promise<void> {
  for (const table of WRITE_SET) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE ${VOUCHER_WHERE}`,
      ...voucherParams(scope, voucherNo),
    );
  }
  if (hiddenVoucherNo) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coBook,
      hiddenVoucherNo,
    );
  }
}

// ---- save ---------------------------------------------------------------------------------------------

/** A loose row whose item is still blank: the save refuses it once it carries anything (:5006). */
const NO_ITEM: TagCancelItem = {
  itCode: '',
  itName: '',
  itType: '',
  prCode: '',
  rateType: '',
  postsDiamonds: false,
};

const isTagged = (tagNo: unknown): boolean => {
  const tag = typedText(tagNo, 15);
  return tag !== '' && tag !== 'N';
};

const hasContent = (line: TagCancelLineInput): boolean =>
  Object.entries(line ?? {}).some(
    ([field, value]) =>
      field !== 'stones' &&
      value != null &&
      !(typeof value === 'string' && value.trim() === '') &&
      !(typeof value === 'number' && value === 0),
  ) ||
  (Array.isArray(line?.stones) && line.stones.length > 0);

async function saveTx(
  tx: any,
  mode: TagCancelMode,
  input: TagCancelInput,
  requestedVoucherNo?: string | number,
): Promise<TagCancelSaveResult> {
  const scope = completeScope(input.scope);
  const book = await resolveBookTx(tx, scope, mode);
  const { date, iso } = businessDate(input.vchDate);
  // TR_TAG_CAN.cs:4960 — "You Cant Save Entry Because Voucher Date Not In Current Year...".
  await assertFiscalDateTx(tx, scope, iso);
  const behavior = await resolveSettingsBehaviorTx(tx, scope);
  const settings = { labourIncludesGhat: behavior.labourIncludesGhat };
  const companyLabourType = behavior.labourType || 'G';
  const empCode = await employeeTx(tx, scope, input.empCode);
  const vchDesc = typedText(input.vchDesc, 255);

  // Blank spare rows are the grid's, not the operator's.
  const lines = (Array.isArray(input.lines) ? input.lines : []).map((line, index) => ({
    line: line ?? {},
    row: index + 1,
  }));
  const active = lines.filter(({ line }) => hasContent(line));
  if (!active.length) throw new TagCancelValidationError('enter at least one tag or item line');

  // "Duplicate Tag No" (TR_TAG_CAN.cs:3907-3915): by number, whatever the serials.
  const seen = new Set<string>();
  for (const { line } of active) {
    if (!isTagged(line.tagNo)) continue;
    const tagNo = typedText(line.tagNo, 15);
    if (seen.has(tagNo)) {
      throw new TagCancelValidationError(`${DESKTOP_MESSAGES.DUPLICATE_TAG}: ${tagNo}`);
    }
    seen.add(tagNo);
  }

  // Edit: lock the voucher, then read what it holds.
  let voucherNo: string;
  let hiddenVoucherNo: string;
  let vchTime: Date;
  let mainUser: string;
  let saved: Awaited<ReturnType<typeof savedLinesTx>> | null = null;
  let persistedHidden = '';
  if (requestedVoucherNo != null) {
    voucherNo = formatVoucherNo(requestedVoucherNo);
    let persisted: Record<string, unknown>;
    try {
      persisted = await persistedVoucherHeaderTx(tx, {
        table: 'BAR_CAN_DATA',
        scope,
        voucherNo,
        extraColumns: [],
      });
    } catch (error) {
      if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
        throw new TagCancelValidationError(`voucher not found: ${voucherNo}`);
      }
      if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
        throw new TagCancelValidationError(`voucher is ambiguous: ${voucherNo}`);
      }
      throw error;
    }
    // Web hardening: the saved date and the new date must both be open, so an edit cannot move a voucher out of a
    // locked period (the desktop checks the date on screen).
    await assertOpenTx(tx, scope, new Date(`${isoOf(persisted.VCH_DATE)}T00:00:00.000Z`));
    await assertOpenTx(tx, scope, date);
    saved = await savedLinesTx(tx, scope, voucherNo);
    persistedHidden = dbText(persisted.HD_VCH_NO).trim();
    hiddenVoucherNo = persistedHidden;
    // An edit keeps the voucher's clock and user (`DISPLAY_DATA` reloads VCH_TIME and MAIN_USER, :4722-4731).
    vchTime = voucherTimestamp(date, persisted.VCH_CLOCK);
    mainUser = dbText(persisted.MAIN_USER);
  } else {
    await assertOpenTx(tx, scope, date);
    voucherNo = '';
    hiddenVoucherNo = '';
    vchTime = voucherTimestamp(date);
    mainUser = String(input.mainUser ?? '')
      .trim()
      .slice(0, 15);
  }

  // K2.6: every tag the save touches, sorted, before anything is resolved, released or written.
  await lockTagsTx(tx, scope, [
    ...active
      .filter(({ line }) => isTagged(line.tagNo))
      .map(({ line }) => typedText(line.tagNo, 15)),
    ...(saved ? savedTagNos(saved.lines) : []),
  ]);

  // K10: give the voucher's own tags back and clear its rows before the lines are resolved again.
  if (saved) {
    const restores = await tagStockRestoresTx(tx, scope, saved.lines);
    await deleteWriteSetTx(tx, scope, voucherNo, persistedHidden);
    for (const restore of restores) await restoreTagTx(tx, scope.tenantId, restore);
    // Web adaptation: a voucher saved without a hidden number gets one rather than a blank TEMP_BOOK_DATA row.
    if (!hiddenVoucherNo) hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
  } else {
    voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, scope));
    hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
  }

  const savedByOld = new Map<number, Record<string, unknown>>();
  for (const line of saved?.lines ?? []) savedByOld.set(num(line.OLD_SRNO), line);
  const keptOld = new Set<number>();

  // Items named by the request: loose items, transfer items and the items of typed stones.
  const requestItems = await itemsTx(tx, scope, [
    ...active.map(({ line }) => typedText(line.itCode, 5)),
    ...active.map(({ line }) => typedText(line.trfrItCode, 5)),
    ...active.flatMap(({ line }) =>
      (line.stones ?? []).map((stone) => typedText(stone?.itCode, 5)),
    ),
  ]);

  interface Resolved {
    cells: TagCancelRowCells;
    kept: Record<string, unknown> | null;
    stones: TagCancelStoneRow[];
    row: number;
  }
  const resolved: Resolved[] = [];
  for (const { line, row } of active) {
    const tagged = isTagged(line.tagNo);
    const tagNo = tagged ? typedText(line.tagNo, 15) : '';
    let kept: Record<string, unknown> | null = null;
    if (line.oldSrNo != null && String(line.oldSrNo).trim() !== '') {
      if (!saved) {
        throw new TagCancelValidationError(
          `row ${row}: oldSrNo applies only when editing a voucher`,
        );
      }
      const oldSrNo = num(line.oldSrNo);
      kept = savedByOld.get(oldSrNo) ?? null;
      if (!kept) {
        throw new TagCancelValidationError(
          `row ${row}: line ${oldSrNo} is not on voucher ${voucherNo}`,
        );
      }
      if (keptOld.has(oldSrNo)) {
        throw new TagCancelValidationError(`row ${row}: line ${oldSrNo} is given twice`);
      }
      keptOld.add(oldSrNo);
    }
    const keptTag = kept ? dbText(kept.TAG_NO).trim().toUpperCase() : '';
    const keptTagged = kept ? keptTag !== '' && keptTag !== 'N' : false;
    const sameTag =
      kept != null &&
      tagged &&
      keptTagged &&
      keptTag === tagNo &&
      (line.vchSrno == null || num(line.vchSrno) === num(kept.VCH_SRNO));
    const sameLoose = kept != null && !tagged && !keptTagged;
    const stonesGiven = Array.isArray(line.stones);
    const givenStones = stonesGiven ? stonesFromInput(line.stones!, requestItems) : [];
    if (!tagged && givenStones.length) {
      // The desktop cannot save a loose line's stones: the parent's blank tag id fails the IDTL write (:5227).
      throw new TagCancelValidationError(`row ${row}: stones belong to a tag line`);
    }
    for (const stone of givenStones) {
      if (stone.itCode && !requestItems.get(stone.itCode)) {
        throw new TagCancelValidationError(`row ${row}: stone item ${stone.itCode} not found`);
      }
    }

    let base: TagCancelRowCells;
    let loaded: TagCancelRowCells | null;
    let sourceStones: TagCancelStoneRow[] = [];
    if (tagged) {
      const source = await tagSourceTx(
        tx,
        scope,
        {
          tagNo,
          vchSrno:
            line.vchSrno != null && String(line.vchSrno).trim() !== ''
              ? num(line.vchSrno)
              : sameTag
                ? num(kept!.VCH_SRNO)
                : undefined,
          itCode: typedText(line.itCode, 5) || undefined,
          row,
        },
        true,
      );
      base = sameTag
        ? { ...cellsFromSaved(kept!), vchSrno: num(source.identity.VCH_SRNO) }
        : source.cells;
      loaded = base;
      sourceStones = sameTag ? (saved!.stonesByLine.get(num(kept!.OLD_SRNO)) ?? []) : source.stones;
    } else {
      const itCode = typedText(line.itCode, 5);
      const item = itCode ? requestItems.get(itCode) : undefined;
      if (itCode && !item)
        throw new TagCancelValidationError(`row ${row}: item ${itCode} not found`);
      if (sameLoose) {
        const savedCells = cellsFromSaved(kept!);
        base =
          item && typedText(savedCells.itCode, 5) !== itCode
            ? {
                ...savedCells,
                itCode: item.itCode,
                rateType: item.rateType,
                itType: item.itType,
                prCode: item.prCode,
              }
            : savedCells;
        loaded = base;
      } else {
        base = looseCells(item ?? NO_ITEM, companyLabourType);
        loaded = null;
      }
    }

    const stones = stonesGiven ? givenStones : sourceStones;
    let cells = applyLineInput({
      mode,
      row,
      tagged,
      base,
      baseline: replayBaseline(loaded),
      input: line,
      stones,
      stonesGiven,
      settings,
    });

    if (mode === 'transfer') {
      // K13.1 (web adaptation): the desktop lets TrfrItm be blank, which silently turns the line into a cancel.
      const trfrItCode = typedText(
        line.trfrItCode ?? (sameTag || sameLoose ? cells.trfrItCode : ''),
        5,
      );
      if (!trfrItCode) {
        throw new TagCancelValidationError(`row ${row}: enter the transfer item (TrfrItm)`);
      }
      const trfrItems =
        requestItems.get(trfrItCode) != null
          ? requestItems
          : await itemsTx(tx, scope, [trfrItCode]);
      const trfrItem = trfrItems.get(trfrItCode);
      if (!trfrItem) {
        throw new TagCancelValidationError(`row ${row}: transfer item ${trfrItCode} not found`);
      }
      cells = { ...cells, trfrItCode: trfrItem.itCode };
    }
    resolved.push({ cells, kept, stones, row });
  }

  // The save's row filter (TR_TAG_CAN.cs:5099) and the item check (:5006).
  const writeCandidates = resolved.filter(({ cells, row }) => {
    const tagged = isTagged(cells.tagNo);
    const qualifies = tagCancelLineQualifies({
      itCode: cells.itCode,
      tagNo: cells.tagNo,
      mrp: cells.mrp,
      pcs: cells.pcs,
      grossWt: cells.grossWt,
      netWt: cells.netWt,
      lbrAmt: cells.lbrAmt,
      othAmt: cells.othAmt,
    });
    if (!qualifies && tagged) {
      // Web adaptation: the desktop skips such a row and leaves the tag in stock without saying so.
      throw new TagCancelValidationError(
        `row ${row}: tag ${cells.tagNo} has no pieces, weight or amount to ${mode === 'cancel' ? 'cancel' : 'transfer'}`,
      );
    }
    if (qualifies && !cells.itCode.trim()) {
      throw new TagCancelValidationError(`Please Select Item Code In Row ${row} and Try......`);
    }
    return qualifies;
  });
  if (!writeCandidates.length)
    throw new TagCancelValidationError('enter at least one tag or item line');

  // K9: SR_NO by position; OLD_SRNO kept for a line from the saved voucher, else the next free one.
  let nextOld = Math.max(0, ...(saved?.lines ?? []).map((line) => num(line.OLD_SRNO)));
  const writeLines: TagCancelWriteLine[] = writeCandidates.map(({ cells, kept, stones }, index) => {
    const srNo = index + 1;
    const oldSrNo = kept ? num(kept.OLD_SRNO) : saved ? ++nextOld : srNo;
    return { cells, srNo, oldSrNo, stones };
  });

  // TR_TAG_CAN.cs:5009: the header and TEMP_BOOK_DATA are written only when the voucher carries something.
  const totals = tagCancelTotals(writeLines.map(({ cells }) => cells));
  if (
    totals.mrp === 0 &&
    totals.pcs + totals.grossWt + totals.netWt + totals.lbrAmt + totals.othAmt === 0
  ) {
    throw new TagCancelValidationError('the voucher has no pieces, weight or amount');
  }

  const ctx: TagCancelWriteContext = {
    mode,
    key: {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      CO_YEAR: scope.coYear,
      CO_BOOK: scope.coBook,
      VCH_NO: voucherNo,
    },
    book,
    hiddenVoucherNo,
    vchDate: date,
    vchTime,
    mainUser,
    empCode,
    vchDesc,
  };
  const stoneItems = await itemsTx(
    tx,
    scope,
    writeLines.flatMap((line) => line.stones.map((stone) => stone.itCode)),
  );

  await insertRowTx(tx, 'TEMP_BOOK_DATA', scope.tenantId, tempBookRow(ctx));
  await insertRowTx(tx, 'BAR_CAN_DATA', scope.tenantId, headerRow(ctx));
  const details = writeLines.map((line) => detailRow(ctx, line));
  for (const detail of details) await insertRowTx(tx, 'BAR_CAN_DETL', scope.tenantId, detail);
  let stoneCount = 0;
  for (const line of writeLines) {
    for (const stone of stoneRows(ctx, line)) {
      await insertRowTx(tx, 'BAR_CAN_IDTL', scope.tenantId, stone);
      stoneCount += 1;
    }
  }
  const stock = stockRows(ctx, details);
  for (const row of stock) await insertRowTx(tx, 'MAIN_STOCK', scope.tenantId, row);
  const diamonds = diamondRows(ctx, writeLines, stoneItems);
  for (const row of diamonds) await insertRowTx(tx, 'DM_DATA', scope.tenantId, row);

  return {
    vchNo: Number(voucherNo),
    voucherNo,
    hiddenVoucherNo,
    lines: writeLines.length,
    stones: stoneCount,
    stockRows: stock.length,
    diamondRows: diamonds.length,
  };
}

/** A deadlock or serialisation failure aborts the whole transaction; report it as a conflict, not a data error. */
function isConflict(error: unknown): boolean {
  const code = (error as { code?: unknown })?.code;
  const message = String((error as { message?: unknown })?.message ?? '');
  return (
    code === 'P2034' ||
    /\b40P01\b|\b40001\b|deadlock detected|could not serialize access/i.test(message)
  );
}

async function inTransaction<T>(
  prisma: any,
  tenantId: string,
  fn: (tx: any) => Promise<T>,
): Promise<T> {
  try {
    return await withTxBudget(prisma, tenantId, 'heavy', fn);
  } catch (error) {
    if (isConflict(error)) {
      throw new TagCancelConflictError(
        'another voucher changed these tags at the same time; nothing was saved — reload and try again',
      );
    }
    throw error;
  }
}

export async function saveTagCancel(
  prisma: any,
  mode: TagCancelMode,
  input: TagCancelInput,
  requestedVoucherNo?: string | number,
): Promise<TagCancelSaveResult> {
  return inTransaction(prisma, input.scope.tenantId, (tx) =>
    saveTx(tx, mode, input, requestedVoucherNo),
  );
}

// ---- read ---------------------------------------------------------------------------------------------

const stoneView = (stone: TagCancelStoneRow): TagCancelStoneView => ({ ...stone });

function lineView(
  row: Record<string, unknown>,
  stones: readonly TagCancelStoneRow[],
): TagCancelLineView {
  const { krOthWt: _o, krGhtWt: _g, ...cells } = cellsFromSaved(row);
  return {
    ...cells,
    srNo: num(row.SR_NO),
    oldSrNo: num(row.OLD_SRNO),
    itName: dbText(row.IT_NAME),
    trfrItName: dbText(row.TRFR_IT_NAME),
    stones: stones.map(stoneView),
  };
}

/** `DISPLAY_DATA` (TR_TAG_CAN.cs:4702-4880): the header, every line with its stones, and the totals row. */
export async function getTagCancel(
  prisma: any,
  mode: TagCancelMode,
  scopeInput: VoucherScope,
  vchNoInput: string | number,
): Promise<TagCancelVoucherView> {
  const scope = completeScope(scopeInput);
  const voucherNo = formatVoucherNo(vchNoInput);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const book = await resolveBookTx(tx, scope, mode);
    const headers: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT h.*, h."VCH_DATE"::text AS "VCH_DAY", to_char(h."VCH_TIME",'HH24:MI:SS') AS "VCH_CLOCK",
              e."EMP_NAME"
         FROM "BAR_CAN_DATA" h
         LEFT JOIN LATERAL (
           SELECT "EMP_NAME" FROM "EMP_MAST" m
            WHERE m.tenant_id=h.tenant_id AND m."CO_CODE"=h."CO_CODE" AND m."EMP_CODE"=h."EMP_CODE"
            ORDER BY m.row_id LIMIT 1
         ) e ON true
        WHERE h.tenant_id=$1 AND h."CO_CODE"=$2 AND h."LC_CODE"=$3 AND h."CO_YEAR"=$4
          AND h."CO_BOOK"=$5 AND h."VCH_NO"=$6
        ORDER BY h.row_id LIMIT 1`,
      ...voucherParams(scope, voucherNo),
    );
    const header = headers[0];
    if (!header) throw new TagCancelValidationError(`voucher not found: ${voucherNo}`);
    const { lines, stonesByLine } = await savedLinesTx(tx, scope, voucherNo);
    const views = lines.map((row) => lineView(row, stonesByLine.get(num(row.OLD_SRNO)) ?? []));
    return {
      mode,
      book: {
        code: scope.coBook,
        name: book.name,
        shortName: book.shortName,
        mainBook: book.mainBook,
      },
      vchNo: Number(voucherNo),
      voucherNo,
      vchDate: dbText(header.VCH_DAY).slice(0, 10),
      voucherTime: dbText(header.VCH_CLOCK),
      hiddenVoucherNo: dbText(header.HD_VCH_NO),
      mainUser: dbText(header.MAIN_USER),
      empCode: dbText(header.EMP_CODE),
      empName: dbText(header.EMP_NAME),
      vchDesc: dbText(header.VCH_DESC),
      lines: views,
      totals: tagCancelTotals(views),
    };
  });
}

/** The voucher help (`BtnF1_Click`, TR_TAG_CAN.cs:5571) and the next number `CLEAR_DATA` shows. */
export async function listTagCancel(
  prisma: any,
  mode: TagCancelMode,
  scopeInput: VoucherScope,
): Promise<{
  book: { code: string; name: string; mainBook: string };
  nextVoucherNo: string;
  vouchers: Array<{
    vchNo: string;
    vchDate: string;
    partyName: string;
    vchDesc: string;
    mainUser: string;
    lines: number;
  }>;
}> {
  const scope = completeScope(scopeInput);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const book = await resolveBookTx(tx, scope, mode);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."VCH_NO", a."VCH_DATE"::text AS "VCH_DAY", b."AC_NAME", a."VCH_DESC", a."MAIN_USER",
              (SELECT count(*)::int FROM "BAR_CAN_DETL" d
                WHERE d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE" AND d."LC_CODE"=a."LC_CODE"
                  AND d."CO_YEAR"=a."CO_YEAR" AND d."CO_BOOK"=a."CO_BOOK" AND d."VCH_NO"=a."VCH_NO") AS lines
         FROM "BAR_CAN_DATA" a
         LEFT JOIN LATERAL (
           SELECT "AC_NAME" FROM "AC_MAST" m
            WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE" AND m."AC_CODE"=a."AC_CODE"
            ORDER BY m.row_id LIMIT 1
         ) b ON true
        WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3 AND a."CO_YEAR"=$4 AND a."CO_BOOK"=$5
        ORDER BY a."VCH_NO"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      scope.coYear,
      scope.coBook,
    );
    const max = rows.reduce(
      (high, row) =>
        Math.max(high, /^\d+$/.test(dbText(row.VCH_NO).trim()) ? Number(row.VCH_NO) : 0),
      0,
    );
    return {
      book: { code: scope.coBook, name: book.name, mainBook: book.mainBook },
      nextVoucherNo: formatVoucherNo(max + 1),
      vouchers: rows.map((row) => ({
        vchNo: dbText(row.VCH_NO),
        vchDate: dbText(row.VCH_DAY).slice(0, 10),
        partyName: dbText(row.AC_NAME),
        vchDesc: dbText(row.VCH_DESC),
        mainUser: dbText(row.MAIN_USER),
        lines: num(row.lines),
      })),
    };
  });
}

/**
 * The tag fill for one live instance, without reserving it (K14) — the same resolver and the same fill the save
 * uses, so the grid shows what will be saved. Two live instances without a serial are refused, as the save refuses
 * them; the available-tag list names each instance.
 */
export async function tagCancelSource(
  prisma: any,
  scopeInput: VoucherScope,
  query: { tagNo?: string; vchSrno?: number | string; itCode?: string },
): Promise<{
  tagNo: string;
  vchSrno: number;
  source: 'BAR_DETL' | 'TAG_STOCK';
  itName: string;
  line: Omit<TagCancelRowCells, 'krOthWt' | 'krGhtWt'>;
  stones: TagCancelStoneView[];
}> {
  if (!scopeInput.tenantId || !scopeInput.coCode || !scopeInput.lcCode) {
    throw new TagCancelValidationError('the tag lookup needs a company and location');
  }
  const tagNo = typedText(query.tagNo, 15);
  if (!tagNo || tagNo === 'N') throw new TagCancelValidationError('enter a tag number');
  const vchSrno =
    query.vchSrno != null && String(query.vchSrno).trim() !== '' ? num(query.vchSrno) : undefined;
  return withTxBudget(prisma, scopeInput.tenantId, 'read', async (tx: any) => {
    const source = await tagSourceTx(
      tx,
      scopeInput,
      { tagNo, vchSrno, itCode: typedText(query.itCode, 5) || undefined, row: 1 },
      false,
    );
    const { krOthWt: _o, krGhtWt: _g, ...line } = source.cells;
    return {
      tagNo,
      vchSrno: num(source.identity.VCH_SRNO),
      source: source.identity.source,
      itName: source.itName,
      line,
      stones: source.stones.map(stoneView),
    };
  });
}

// ---- delete -------------------------------------------------------------------------------------------

/**
 * `BtnDelete_Click` (TR_TAG_CAN.cs:5331-5362): the desktop's DELETE_DATA per line, then the whole write set and the
 * TEMP_BOOK_DATA row — here in one transaction — and the voucher's tags are given back (K11).
 */
export async function deleteTagCancel(
  prisma: any,
  mode: TagCancelMode,
  scopeInput: VoucherScope,
  vchNoInput: string | number,
  deleteUser?: string,
): Promise<{ reversed: true; vchNo: number; lines: number; restoredTags: number }> {
  const scope = completeScope(scopeInput);
  const voucherNo = formatVoucherNo(vchNoInput);
  return inTransaction(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, scope, mode);
    let persisted: Record<string, unknown>;
    try {
      persisted = await persistedVoucherHeaderTx(tx, {
        table: 'BAR_CAN_DATA',
        scope,
        voucherNo,
        extraColumns: [],
      });
    } catch (error) {
      if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
        throw new TagCancelValidationError(`voucher not found: ${voucherNo}`);
      }
      throw error;
    }
    const savedDate = isoOf(persisted.VCH_DATE);
    await assertOpenTx(tx, scope, new Date(`${savedDate}T00:00:00.000Z`));
    await assertFiscalDateTx(tx, scope, savedDate);
    const { lines } = await savedLinesTx(tx, scope, voucherNo);
    await lockTagsTx(tx, scope, savedTagNos(lines));
    const restores = await tagStockRestoresTx(tx, scope, lines);
    const at = new Date();
    for (const row of deleteAuditRows(
      book,
      lines,
      String(deleteUser ?? '')
        .trim()
        .slice(0, 15),
      at,
    )) {
      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, row);
    }
    await deleteWriteSetTx(tx, scope, voucherNo, dbText(persisted.HD_VCH_NO).trim());
    for (const restore of restores) await restoreTagTx(tx, scope.tenantId, restore);
    return {
      reversed: true,
      vchNo: Number(voucherNo),
      lines: lines.length,
      restoredTags: restores.length,
    };
  });
}
