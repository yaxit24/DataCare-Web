/**
 * Tag Split (X20), desktop TR_TAG_SPLIT. One or more PARENT tags are consumed and one or more CHILD tags are created,
 * conserving metal. This is a desktop-faithful writer: the parent is resolved and reserved through the shared
 * identity resolver under a sorted tag lock; each child gets a fresh allocated TAG_NO / VCH_SRNO / SRNO_MAST row and
 * a full BAR_DETL record so it is a real, sellable tag; the register (LBR_DATA/ISU_DETL/ISU_IDTL/REC_DETL,
 * BAR_DATA/DETL/IDTL), MAIN_STOCK (Tag_Split_Stk), the absorption ledger (AC_DATA Tag_Split_Ledr), the day book
 * (ROJ_MEL_DATA Tag_Split_Rojmel), the diamond register (DM_DATA Dm_Tag_Split_Detl) and the hidden number
 * (TEMP_BOOK_DATA) are written; edit and delete reverse it, give the parents back and refuse a child already moved on.
 *
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md.
 */
import { withTenant } from '@datacare/db';
import {
  tagSplitBalance,
  tagSplitConserves,
  tagSplitTotals,
  type TagSplitSettings,
} from '@datacare/core';
import {
  formatVoucherNo,
  nextTagNoTx,
  nextVoucherNoTx,
  type VoucherScope,
} from '../vouchers/numbering.js';
import {
  assertFiscalDateTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import { resolveBookSlotRowsTx } from '../shared/postingAccounts.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { issueTagTx, resolveLiveTagIdentityTx, restoreTagTx, type TagKey } from './stock.js';
import {
  TAG_SPLIT_MAIN_BOOK,
  TagSplitConflictError,
  TagSplitValidationError,
  barDataRow,
  childBarDetlRow,
  childReceiveRow,
  childStoneRows,
  dbText,
  deleteAuditRows,
  diamondRows,
  f2,
  f3,
  headerRow,
  ledgerRows,
  num,
  parentCellsFromBarDetl,
  parentDetailRow,
  parentStoneRows,
  resolveChild,
  rojmelRows,
  stockRows,
  stoneFromSaved,
  stoneFromTag,
  stonesFromInput,
  tempBookRow,
  typedText,
  NO_ITEM,
  type TagSplitBookPolicy,
  type TagSplitChildInput,
  type TagSplitItem,
  type TagSplitParentInput,
  type TagSplitStoneRow,
  type TagSplitWriteChild,
  type TagSplitWriteContext,
  type TagSplitWriteParent,
} from './tagSplitRows.js';

export { TAG_SPLIT_MAIN_BOOK, TagSplitConflictError, TagSplitValidationError };
export type { TagSplitParentInput, TagSplitChildInput };
export type { TagSplitStoneInput } from './tagSplitRows.js';

type CompleteScope = VoucherScope & { coYear: string; coBook: string };
function completeScope(scope: VoucherScope): CompleteScope {
  if (!scope.coYear || !scope.coBook) {
    throw new TagSplitValidationError('company year and book are required');
  }
  return scope as CompleteScope;
}

export interface TagSplitInput {
  scope: VoucherScope;
  vchDate?: unknown;
  empCode?: string;
  vchDesc?: string;
  acCode?: string;
  itType?: string;
  drTouch?: number;
  crTouch?: number;
  crLbr?: number;
  mainUser?: string;
  parents: TagSplitParentInput[];
  children: TagSplitChildInput[];
}

// ---- book -------------------------------------------------------------------------------------------

async function resolveBookTx(tx: any, scope: CompleteScope): Promise<TagSplitBookPolicy> {
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
    throw new TagSplitValidationError(
      `book ${scope.coBook} is not configured for location ${scope.lcCode}`,
    );
  }
  if (rows.length > 1) {
    throw new TagSplitValidationError(
      `book ${scope.coBook} is configured more than once for location ${scope.lcCode}`,
    );
  }
  const row = rows[0]!;
  if (typedText(row.MAIN_BOOK) !== TAG_SPLIT_MAIN_BOOK) {
    throw new TagSplitValidationError(
      `book ${scope.coBook} is ${typedText(row.MAIN_BOOK) || 'blank'}, not ${TAG_SPLIT_MAIN_BOOK}`,
    );
  }
  if (typedText(row.CUR_USE) !== 'Y') {
    throw new TagSplitValidationError(`book ${scope.coBook} is not in use`);
  }
  // The absorbing-ledger slots (5 labour, 6/7 gold DR/CR, 8/9 silver DR/CR) come from the shared posting-account
  // kernel, not an inline BOOK_DETL read — one resolver for every book so a duplicate slot fails closed the same
  // way everywhere (WP-06).
  const slotRows = await resolveBookSlotRowsTx(tx, scope, 'labour-expense');
  const slots: Record<number, string> = {};
  for (const [srNo, slot] of slotRows) slots[srNo] = slot.accountCode;
  return {
    name: dbText(row.BOOK_NAME),
    shortName: dbText(row.BOOK_SNAME).slice(0, 6),
    mainBook: TAG_SPLIT_MAIN_BOOK,
    inout: dbText(row.BOOK_INOUT).trim().slice(0, 1) || 'O',
    dataType: dbText(row.DATA_TYPE).trim().slice(0, 1) || 'A',
    slots,
  };
}

function businessDate(value: unknown): { date: Date; iso: string } {
  const raw =
    value instanceof Date
      ? value.toISOString().slice(0, 10)
      : value == null || String(value).trim() === ''
        ? new Date().toISOString().slice(0, 10)
        : String(value).trim().slice(0, 10);
  if (!/^\d{4}-\d{2}-\d{2}$/.test(raw))
    throw new TagSplitValidationError('voucher date is missing or invalid');
  const date = new Date(`${raw}T00:00:00.000Z`);
  if (Number.isNaN(date.getTime()))
    throw new TagSplitValidationError('voucher date is missing or invalid');
  return { date, iso: raw };
}

const isoOf = (value: unknown): string =>
  value instanceof Date ? value.toISOString().slice(0, 10) : dbText(value).slice(0, 10);

async function assertOpenTx(tx: any, scope: CompleteScope, date: Date): Promise<void> {
  await assertPeriodOpen(tx, scope.tenantId, {
    ledger: { table: 'AC_DATA', lines: [{ CO_CODE: scope.coCode, VCH_DATE: date }] },
  });
}

async function tradeFineTx(tx: any, scope: CompleteScope): Promise<boolean> {
  const rows: Array<{ TRAD_FINE: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "TRAD_FINE" FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  return typedText(rows[0]?.TRAD_FINE, 1) === 'Y';
}

async function itemsTx(
  tx: any,
  scope: VoucherScope,
  codes: Iterable<string>,
): Promise<Map<string, TagSplitItem>> {
  const wanted = [...new Set([...codes].map((c) => c.trim().toUpperCase()).filter(Boolean))];
  const out = new Map<string, TagSplitItem>();
  if (!wanted.length) return out;
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME","IT_TYPE","PR_CODE","TAG_TYPE","RATE_TYPE","OTH_DETL_POSTING"
       FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND upper(btrim("IT_CODE"::text)) = ANY($3::text[])`,
    scope.tenantId,
    scope.coCode,
    wanted,
  );
  for (const row of rows) {
    out.set(dbText(row.IT_CODE).trim().toUpperCase(), {
      itCode: dbText(row.IT_CODE),
      itName: dbText(row.IT_NAME),
      itType: dbText(row.IT_TYPE) || 'G',
      prCode: dbText(row.PR_CODE),
      tagType: dbText(row.TAG_TYPE),
      rateType: dbText(row.RATE_TYPE),
      postsDiamonds: typedText(row.OTH_DETL_POSTING, 1) === 'Y',
    });
  }
  return out;
}

async function employeeTx(tx: any, scope: CompleteScope, code: unknown): Promise<string> {
  const empCode = typedText(code, 3);
  if (!empCode) return '';
  const rows: Array<{ EMP_CODE: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "EMP_CODE" FROM "EMP_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND upper(btrim("EMP_CODE"::text))=$3 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    empCode,
  );
  if (!rows.length) throw new TagSplitValidationError(`employee ${empCode} not found`);
  return dbText(rows[0]!.EMP_CODE);
}

/** Copy the parent's TAG image (ENTITY_IMAGE) to a child instance, if the parent has one. Never touches the parent. */
async function copyTagImageTx(
  tx: any,
  scope: CompleteScope,
  parent: { tagNo: string; vchSrno: number },
  child: { tagNo: string; vchSrno: number },
  mainUser: string,
): Promise<void> {
  await tx.$executeRawUnsafe(
    `INSERT INTO "ENTITY_IMAGE"(tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE",
       "IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES","MAIN_USER")
     SELECT tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE",$6,$7,"IMAGE_TYPE","MIME_TYPE","IMAGE_SIZE","IMAGE_BYTES",$8
       FROM "ENTITY_IMAGE"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "ENTITY_TYPE"='TAG'
        AND "ENTITY_KEY"=$4 AND "INSTANCE"=$5
     ON CONFLICT (tenant_id,"CO_CODE","LC_CODE","ENTITY_TYPE","ENTITY_KEY","INSTANCE") DO NOTHING`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    parent.tagNo,
    parent.vchSrno,
    child.tagNo,
    child.vchSrno,
    mainUser.slice(0, 64) || null,
  );
}

async function accountNameTx(tx: any, scope: CompleteScope, acCode: string): Promise<string> {
  if (!acCode) return '';
  const rows: Array<{ AC_NAME: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    acCode,
  );
  if (!rows.length) throw new TagSplitValidationError(`account ${acCode} not found`);
  return dbText(rows[0]!.AC_NAME);
}

// ---- tags -------------------------------------------------------------------------------------------

async function lockTagsTx(tx: any, scope: VoucherScope, tagNos: Iterable<string>): Promise<void> {
  const sorted = [...new Set([...tagNos].filter(Boolean))].sort();
  for (const tagNo of sorted) {
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `tag-issue|${scope.coCode}|${scope.lcCode}|${tagNo}`,
    );
  }
}

async function firstBarDetlTx(
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

async function tagStonesTx(tx: any, source: Record<string, unknown>): Promise<TagSplitStoneRow[]> {
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

/**
 * Has this child tag instance moved on since this split created it (sold, cancelled, split again)?
 *
 * The split writes the child's only creation leg — a MAIN_STOCK '+' under this very voucher. Any CONSUMING ('-')
 * movement for the child that is NOT this split's own row means it has since been used, and the split can no longer
 * be edited or reversed. We must exclude this split's own voucher (not the empty book/number the previous version
 * excluded) so the check sees only later activity: a later sale or split's '-' leg nets its own '+' to zero, so a
 * signed balance would miss it — counting consuming legs outside this voucher is what detects it.
 */
async function tagMovedOnTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  tagNo: string,
  vchSrno: number,
): Promise<boolean> {
  const rows: Array<{ n: number }> = await tx.$queryRawUnsafe(
    `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='-' THEN 1 ELSE 0 END),0)::int AS n
       FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "TAG_NO"=$4 AND coalesce("VCH_SRNO",0)::numeric=$5::numeric
        AND NOT ("CO_BOOK"=$6 AND "VCH_NO"=$7)`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    tagNo,
    vchSrno,
    scope.coBook,
    voucherNo,
  );
  return num(rows[0]?.n) > 0;
}

// ---- saved voucher ----------------------------------------------------------------------------------

const voucherParams = (scope: CompleteScope, voucherNo: string) => [
  scope.tenantId,
  scope.coCode,
  scope.lcCode,
  scope.coYear,
  scope.coBook,
  voucherNo,
];

async function savedTx(tx: any, scope: CompleteScope, voucherNo: string) {
  const parents: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "LBR_ISU_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO", row_id`,
    ...voucherParams(scope, voucherNo),
  );
  const children: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT * FROM "LBR_REC_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO", row_id`,
    ...voucherParams(scope, voucherNo),
  );
  return { parents, children };
}

const savedTagNos = (rows: readonly Record<string, unknown>[]): string[] =>
  rows.map((r) => dbText(r.TAG_NO).trim()).filter((t) => t !== '' && t.toUpperCase() !== 'N');

const WRITE_SET = [
  'BAR_IDTL',
  'BAR_DETL',
  'BAR_DATA',
  'LBR_ISU_IDTL',
  'LBR_ISU_DETL',
  'LBR_REC_DETL',
  'LBR_DATA',
  'MAIN_STOCK',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
] as const;

async function deleteWriteSetTx(
  tx: any,
  scope: CompleteScope,
  voucherNo: string,
  hiddenVoucherNo: string,
) {
  for (const table of WRITE_SET) {
    await tx.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      ...voucherParams(scope, voucherNo),
    );
  }
  // The SRNO_MAST counter is deliberately NOT rolled back: like the desktop, an allocated tag serial is never
  // reused even after the voucher that created it is deleted (numbers are monotonic per company/location).
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

/** A parent tag the voucher consumed becomes available again; a TAG_STOCK-only parent is re-inserted (lossily). */
async function restoreParentsTx(
  tx: any,
  scope: CompleteScope,
  parents: readonly Record<string, unknown>[],
) {
  for (const line of parents) {
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
    for (const [col, val] of [
      ['DESIGN_NO', line.DESIGN_NO],
      ['ITM_SIZE', line.ITM_SIZE],
      ['PR_CODE', line.PR_CODE],
      ['IT_TYPE', line.IT_TYPE],
      ['DESIGN_IMG_ID', line.DESIGN_IMG_ID],
    ] as const) {
      const text = dbText(val).trim();
      if (text && !(col === 'DESIGN_IMG_ID' && text === 'N')) restore[col] = text;
    }
    await restoreTagTx(tx, scope.tenantId, restore);
  }
}

// ---- save -------------------------------------------------------------------------------------------

export interface TagSplitSaveResult {
  vchNo: number;
  voucherNo: string;
  hiddenVoucherNo: string;
  parents: number;
  children: number;
  stockRows: number;
  ledgerRows: number;
  diamondRows: number;
}

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
    return await withTenant(prisma, tenantId, fn, { maxWait: 10_000, timeout: 30_000 });
  } catch (error) {
    if (isConflict(error)) {
      throw new TagSplitConflictError(
        'another voucher changed these tags at the same time; nothing was saved — reload and try again',
      );
    }
    throw error;
  }
}

async function saveTx(
  tx: any,
  input: TagSplitInput,
  requestedVoucherNo?: string | number,
): Promise<TagSplitSaveResult> {
  const scope = completeScope(input.scope);
  const book = await resolveBookTx(tx, scope);
  const { date, iso } = businessDate(input.vchDate);
  await assertFiscalDateTx(tx, scope, iso);
  const behavior = await resolveSettingsBehaviorTx(tx, scope);
  const settings: TagSplitSettings = { labourIncludesGhat: behavior.labourIncludesGhat };
  const companyLabourType = behavior.labourType || 'G';
  const tradeFine = await tradeFineTx(tx, scope);
  const empCode = await employeeTx(tx, scope, input.empCode);
  const vchDesc = typedText(input.vchDesc, 255);
  const acCode = typedText(input.acCode, 8);
  const acName = acCode ? await accountNameTx(tx, scope, acCode) : '';

  const parentInputs = (Array.isArray(input.parents) ? input.parents : []).filter((p) =>
    typedText(p?.tagNo, 15),
  );
  const childInputs = (Array.isArray(input.children) ? input.children : []).filter(
    (c) => typedText(c?.itCode, 5) && num(c.grossWt) + num(c.mrp) + num(c.othAmt) !== 0,
  );
  if (!parentInputs.length)
    throw new TagSplitValidationError('enter at least one parent tag to split');
  if (!childInputs.length) throw new TagSplitValidationError('enter at least one child tag');

  // Duplicate parent tag number (:8501).
  const seen = new Set<string>();
  for (const p of parentInputs) {
    const t = typedText(p.tagNo, 15);
    if (seen.has(t)) throw new TagSplitValidationError(`${DESKTOP_MESSAGES.DUPLICATE_TAG}: ${t}`);
    seen.add(t);
  }

  // Edit: lock the header, then read what it holds.
  let voucherNo: string;
  let hiddenVoucherNo: string;
  let vchTime: Date;
  let mainUser: string;
  let saved: Awaited<ReturnType<typeof savedTx>> | null = null;
  let persistedHidden = '';
  if (requestedVoucherNo != null) {
    voucherNo = formatVoucherNo(requestedVoucherNo);
    let persisted: Record<string, unknown>;
    try {
      persisted = await persistedVoucherHeaderTx(tx, {
        table: 'LBR_DATA',
        scope,
        voucherNo,
        extraColumns: [],
      });
    } catch (error) {
      if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
        throw new TagSplitValidationError(`voucher not found: ${voucherNo}`);
      }
      if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
        throw new TagSplitValidationError(`voucher is ambiguous: ${voucherNo}`);
      }
      throw error;
    }
    await assertOpenTx(tx, scope, new Date(`${isoOf(persisted.VCH_DATE)}T00:00:00.000Z`));
    await assertOpenTx(tx, scope, date);
    saved = await savedTx(tx, scope, voucherNo);
    persistedHidden = dbText(persisted.HD_VCH_NO).trim();
    hiddenVoucherNo = persistedHidden;
    vchTime = voucherTimestamp(date, (persisted as { VCH_CLOCK?: unknown }).VCH_CLOCK);
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

  // Lock every tag the save touches — request parents and the saved voucher's own parents and children.
  await lockTagsTx(tx, scope, [
    ...parentInputs.map((p) => typedText(p.tagNo, 15)),
    ...(saved ? [...savedTagNos(saved.parents), ...savedTagNos(saved.children)] : []),
  ]);

  // Edit: refuse if a child already moved on; give the parents back and clear the voucher's rows.
  if (saved) {
    for (const child of saved.children) {
      const tagNo = dbText(child.TAG_NO).trim();
      if (
        tagNo &&
        tagNo.toUpperCase() !== 'N' &&
        (await tagMovedOnTx(tx, scope, voucherNo, tagNo, num(child.VCH_SRNO)))
      ) {
        throw new TagSplitValidationError(
          `child tag ${tagNo} has already been used and cannot be changed`,
        );
      }
    }
    await deleteWriteSetTx(tx, scope, voucherNo, persistedHidden);
    await restoreParentsTx(tx, scope, saved.parents);
    if (!hiddenVoucherNo) hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
  } else {
    voucherNo = formatVoucherNo(await nextVoucherNoTx(tx, scope));
    hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, scope);
  }

  // Resolve and reserve the parents.
  const parentItems = await itemsTx(
    tx,
    scope,
    parentInputs.map((p) => typedText(p.itCode ?? '', 5)),
  );
  const writeParents: TagSplitWriteParent[] = [];
  for (let i = 0; i < parentInputs.length; i++) {
    const p = parentInputs[i]!;
    const tagNo = typedText(p.tagNo, 15);
    const key: TagKey = {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      TAG_NO: tagNo,
      ...(p.vchSrno != null ? { VCH_SRNO: num(p.vchSrno) } : {}),
      ...(p.itCode ? { IT_CODE: typedText(p.itCode, 5) } : {}),
    };
    const identity = await issueTagTx(tx, key);
    const bar = await firstBarDetlTx(
      tx,
      scope,
      tagNo,
      num(identity.VCH_SRNO),
      identity.source === 'BAR_DETL' ? dbText(identity.IT_CODE) : '',
    );
    if (!bar) {
      throw new TagSplitValidationError(
        `parent tag ${tagNo} has no barcode record; only a BAR_DETL tag can be split`,
      );
    }
    const cells = parentCellsFromBarDetl(bar);
    writeParents.push({
      cells,
      srNo: i + 1,
      oldSrNo: i + 1,
      stones: await tagStonesTx(tx, bar),
    });
  }

  // Resolve the children, allocating each a fresh tag number.
  const childItems = await itemsTx(
    tx,
    scope,
    childInputs.map((c) => typedText(c.itCode ?? '', 5)),
  );
  // Stone item lookups must cover BOTH the parent tags' stones (loaded from BAR_IDTL, sent OUT of the diamond
  // register) and the children's typed stones (sent IN): Dm_Tag_Split_Detl posts an item only when its
  // OTH_DETL_POSTING = 'Y', so the parent's diamond would never post if its item were absent from this map.
  const stoneItemCodes = [
    ...writeParents.flatMap((p) => p.stones.map((s) => typedText(s.itCode ?? '', 5))),
    ...childInputs.flatMap((c) => (c.stones ?? []).map((s) => typedText(s.itCode ?? '', 5))),
  ];
  const stoneItems = await itemsTx(tx, scope, stoneItemCodes);
  const writeChildren: TagSplitWriteChild[] = [];
  for (let i = 0; i < childInputs.length; i++) {
    const c = childInputs[i]!;
    const itCode = typedText(c.itCode, 5);
    const item = childItems.get(itCode);
    if (!item) throw new TagSplitValidationError(`row ${i + 1}: item ${itCode} not found`);
    // Allocate the child's number. `nextTagNoTx` takes the tag advisory lock and advances SRNO_MAST under
    // FOR UPDATE, so the serial is already reserved race-safely and rolls back with the transaction; the child
    // becomes a real, sellable tag through its BAR_DETL row and MAIN_STOCK '+' leg (like a purchased tag), so no
    // TAG_STOCK reservation row is written — a BAR_DETL tag lives by its stock balance, not a TAG_STOCK row.
    const { srno, tagNo } = await nextTagNoTx(tx, scope, { prefix: item.prCode || itCode });
    const vchSrno = srno;
    const stones = stonesFromInput(c.stones ?? [], stoneItems);
    for (const stone of stones) {
      if (stone.itCode && !stoneItems.get(stone.itCode)) {
        throw new TagSplitValidationError(`row ${i + 1}: stone item ${stone.itCode} not found`);
      }
    }
    const cells = resolveChild({
      input: c,
      item,
      identity: { tagNo, vchSrno, tagSrno: srno },
      companyLabourType,
      stones,
      settings,
    });
    writeChildren.push({ cells, srNo: i + 2, oldSrNo: i + 1, stones });
  }

  // Conservation (K7): the child net total must equal the parent net total unless an absorbing account is given.
  const parentNet = f3(writeParents.reduce((s, p) => s + p.cells.netWt, 0));
  const childNet = tagSplitTotals(
    writeChildren.map((c) => ({ ...c.cells, sign: c.cells.sign })),
  ).netWt;
  if (!acCode && !tagSplitConserves(parentNet, childNet)) {
    throw new TagSplitValidationError(
      `${DESKTOP_MESSAGES.SPLIT_WEIGHT_DIFFERENCE} received ${childNet}, issued ${parentNet}`,
    );
  }
  const balanceCore = tagSplitBalance({
    parentNet,
    childNet,
    drTouch: num(input.drTouch),
    crTouch: num(input.crTouch),
  });
  const itType = typedText(input.itType, 1) || writeParents[0]?.cells.itType || 'G';

  const ctx: TagSplitWriteContext = {
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
    acCode,
    itType,
    balance: { ...balanceCore, crLbr: f2(input.crLbr) },
  };

  // Write set (K8), in the desktop's order.
  await insertRowTx(tx, 'TEMP_BOOK_DATA', scope.tenantId, tempBookRow(ctx));
  await insertRowTx(tx, 'LBR_DATA', scope.tenantId, headerRow(ctx));
  for (const p of writeParents) {
    await insertRowTx(tx, 'LBR_ISU_DETL', scope.tenantId, parentDetailRow(ctx, p));
    for (const stone of parentStoneRows(ctx, p))
      await insertRowTx(tx, 'LBR_ISU_IDTL', scope.tenantId, stone);
  }
  await insertRowTx(tx, 'BAR_DATA', scope.tenantId, barDataRow(ctx));
  for (const ch of writeChildren) {
    await insertRowTx(tx, 'LBR_REC_DETL', scope.tenantId, childReceiveRow(ctx, ch));
    await insertRowTx(tx, 'BAR_DETL', scope.tenantId, childBarDetlRow(ctx, ch));
    for (const stone of childStoneRows(ctx, ch))
      await insertRowTx(tx, 'BAR_IDTL', scope.tenantId, stone);
  }
  const stock = stockRows(ctx, writeParents, writeChildren);
  for (const row of stock) await insertRowTx(tx, 'MAIN_STOCK', scope.tenantId, row);
  const ledger = ledgerRows(ctx, tradeFine);
  for (const row of ledger) await insertRowTx(tx, 'AC_DATA', scope.tenantId, row);
  for (const row of rojmelRows(ctx, acName, acName))
    await insertRowTx(tx, 'ROJ_MEL_DATA', scope.tenantId, row);
  const diamonds = diamondRows(ctx, writeParents, writeChildren, stoneItems);
  for (const row of diamonds) await insertRowTx(tx, 'DM_DATA', scope.tenantId, row);

  // Child image lineage (K8.11): copy the parent's TAG image to each child instance, the web equivalent of the
  // desktop's Mobile_image_Save. The parent's own image row is never modified.
  const parent = writeParents[0]?.cells;
  if (parent) {
    for (const ch of writeChildren) {
      await copyTagImageTx(tx, scope, parent, ch.cells, mainUser);
    }
  }

  return {
    vchNo: Number(voucherNo),
    voucherNo,
    hiddenVoucherNo,
    parents: writeParents.length,
    children: writeChildren.length,
    stockRows: stock.length,
    ledgerRows: ledger.length,
    diamondRows: diamonds.length,
  };
}

export async function saveTagSplit(
  prisma: any,
  input: TagSplitInput,
  requestedVoucherNo?: string | number,
): Promise<TagSplitSaveResult> {
  return inTransaction(prisma, completeScope(input.scope).tenantId, (tx) =>
    saveTx(tx, input, requestedVoucherNo),
  );
}

// ---- delete -----------------------------------------------------------------------------------------

export async function deleteTagSplit(
  prisma: any,
  scopeInput: VoucherScope,
  vchNoInput: string | number,
  deleteUser?: string,
): Promise<{ reversed: true; vchNo: number; parents: number; children: number }> {
  const scope = completeScope(scopeInput);
  const voucherNo = formatVoucherNo(vchNoInput);
  return inTransaction(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, scope);
    let persisted: Record<string, unknown>;
    try {
      persisted = await persistedVoucherHeaderTx(tx, {
        table: 'LBR_DATA',
        scope,
        voucherNo,
        extraColumns: [],
      });
    } catch (error) {
      if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
        throw new TagSplitValidationError(`voucher not found: ${voucherNo}`);
      }
      throw error;
    }
    const savedDate = isoOf(persisted.VCH_DATE);
    await assertOpenTx(tx, scope, new Date(`${savedDate}T00:00:00.000Z`));
    await assertFiscalDateTx(tx, scope, savedDate);
    const { parents, children } = await savedTx(tx, scope, voucherNo);
    await lockTagsTx(tx, scope, [...savedTagNos(parents), ...savedTagNos(children)]);
    // A child that has moved on blocks the delete (K11.4).
    for (const child of children) {
      const tagNo = dbText(child.TAG_NO).trim();
      if (
        tagNo &&
        tagNo.toUpperCase() !== 'N' &&
        (await tagMovedOnTx(tx, scope, voucherNo, tagNo, num(child.VCH_SRNO)))
      ) {
        throw new TagSplitValidationError(
          `child tag ${tagNo} has already been used and cannot be reversed`,
        );
      }
    }
    const at = new Date();
    for (const row of deleteAuditRows(
      book,
      parents,
      String(deleteUser ?? '')
        .trim()
        .slice(0, 15),
      at,
    )) {
      await insertRowTx(tx, 'DELETE_DATA', scope.tenantId, row);
    }
    await deleteWriteSetTx(tx, scope, voucherNo, dbText(persisted.HD_VCH_NO).trim());
    await restoreParentsTx(tx, scope, parents);
    return {
      reversed: true,
      vchNo: Number(voucherNo),
      parents: parents.length,
      children: children.length,
    };
  });
}

// ---- reading (K13) ----------------------------------------------------------------------------------

const numOut = (value: unknown): number => num(value);

function lineView(
  row: Record<string, unknown>,
  stones: TagSplitStoneRow[],
): Record<string, unknown> {
  return {
    srNo: numOut(row.SR_NO),
    oldSrNo: numOut(row.OLD_SRNO),
    itCode: dbText(row.IT_CODE),
    itName: dbText(row.IT_NAME),
    tagNo: dbText(row.TAG_NO),
    vchSrno: numOut(row.VCH_SRNO),
    tagSrno: numOut(row.TAG_SRNO),
    tblCode: dbText(row.TBL_CODE),
    designNo: dbText(row.DESIGN_NO),
    itmSize: dbText(row.ITM_SIZE),
    sign: dbText(row.ITM_SIGN),
    bagWt: numOut(row.BAG_WT),
    pcs: numOut(row.ITM_PCS),
    grossWt: numOut(row.ITM_GWT),
    lessWt: numOut(row.ITM_OTH_WT),
    netWt: numOut(row.ITM_NWT),
    ghtWt: numOut(row.ITM_GHT_WT),
    touch: numOut(row.ITM_TOUCH),
    westPct: numOut(row.ITM_WEST_PRC),
    fine: numOut(row.ITM_FINE),
    lbrRate: numOut(row.LBR_RATE),
    lbrAmt: numOut(row.LBR_AMT),
    othAmt: numOut(row.OTH_AMT),
    rate: numOut(row.ITM_RATE),
    amount: numOut(row.ITM_AMT),
    mrp: numOut(row.ITM_MRP),
    krName: dbText(row.KR_NAME),
    krNetWt: numOut(row.KR_NET_WT),
    krTouch: numOut(row.KR_TOUCH),
    krWestPct: numOut(row.KR_WEST_PRC),
    krFine: numOut(row.KR_FINE),
    stones: stones.map((s) => ({
      isrNo: s.isrNo,
      itCode: s.itCode,
      itName: s.itName,
      pcs: s.pcs,
      grossWt: s.grossWt,
      karigarWt: s.karigarWt,
      conPct: s.conPct,
      rateType: s.rateType,
      rate: s.rate,
      amount: s.amount,
      lbrRate: s.lbrRate,
      lbrAmount: s.lbrAmount,
      netAmount: s.netAmount,
      itType: s.itType,
    })),
  };
}

async function stonesByLineTx(tx: any, scope: CompleteScope, table: string, voucherNo: string) {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT s.*, i."IT_NAME" FROM "${table}" s
       LEFT JOIN "ITEM_MAST" i ON i.tenant_id=s.tenant_id AND i."CO_CODE"=s."CO_CODE" AND i."IT_CODE"=s."IT_CODE"
      WHERE s.tenant_id=$1 AND s."CO_CODE"=$2 AND s."LC_CODE"=$3 AND s."CO_YEAR"=$4 AND s."CO_BOOK"=$5 AND s."VCH_NO"=$6
      ORDER BY s."SR_NO", s."ISR_NO", s.row_id`,
    ...voucherParams(scope, voucherNo),
  );
  const map = new Map<number, TagSplitStoneRow[]>();
  for (const stone of rows) {
    const srNo = num(stone.SR_NO);
    map.set(srNo, [...(map.get(srNo) ?? []), stoneFromSaved(stone)]);
  }
  return map;
}

export async function getTagSplit(
  prisma: any,
  scopeInput: VoucherScope,
  vchNoInput: string | number,
): Promise<Record<string, unknown>> {
  const scope = completeScope(scopeInput);
  const voucherNo = formatVoucherNo(vchNoInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, scope);
    const header: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      // LBR_DATA's primary key is the full voucher key, so at most one row matches — no row_id ordering (the
      // table has no row_id column; its identity is the composite key).
      `SELECT *, to_char("VCH_TIME",'HH24:MI:SS') AS "VCH_CLOCK" FROM "LBR_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
        LIMIT 1`,
      ...voucherParams(scope, voucherNo),
    );
    if (!header.length) throw new TagSplitValidationError(`voucher not found: ${voucherNo}`);
    const h = header[0]!;
    const withNames = async (table: string) =>
      (await tx.$queryRawUnsafe(
        `SELECT d.*, i."IT_NAME" FROM "${table}" d
           LEFT JOIN "ITEM_MAST" i ON i.tenant_id=d.tenant_id AND i."CO_CODE"=d."CO_CODE" AND i."IT_CODE"=d."IT_CODE"
          WHERE d.tenant_id=$1 AND d."CO_CODE"=$2 AND d."LC_CODE"=$3 AND d."CO_YEAR"=$4 AND d."CO_BOOK"=$5 AND d."VCH_NO"=$6
          ORDER BY d."SR_NO", d.row_id`,
        ...voucherParams(scope, voucherNo),
      )) as Array<Record<string, unknown>>;
    const parentRows = await withNames('LBR_ISU_DETL');
    const childRows = await withNames('LBR_REC_DETL');
    const parentStones = await stonesByLineTx(tx, scope, 'LBR_ISU_IDTL', voucherNo);
    const childStones = await stonesByLineTx(tx, scope, 'BAR_IDTL', voucherNo);
    return {
      voucherNo,
      vchDate: isoOf(h.VCH_DATE),
      voucherTime: dbText(h.VCH_CLOCK),
      hiddenVoucherNo: dbText(h.HD_VCH_NO),
      mainUser: dbText(h.MAIN_USER),
      empCode: dbText(h.EMP_CODE),
      acCode: dbText(h.AC_CODE),
      vchDesc: dbText(h.VCH_DESC),
      itType: dbText(h.IT_TYPE),
      drWt: num(h.DR_WT),
      crWt: num(h.CR_WT),
      drFine: num(h.DR_FINE),
      crFine: num(h.CR_FINE),
      crLbr: num(h.CR_LBR),
      book: {
        code: scope.coBook,
        name: book.name,
        shortName: book.shortName,
        mainBook: book.mainBook,
      },
      parents: parentRows.map((row) => lineView(row, parentStones.get(num(row.SR_NO)) ?? [])),
      children: childRows.map((row) => lineView(row, childStones.get(num(row.SR_NO)) ?? [])),
    };
  });
}

export async function listTagSplit(
  prisma: any,
  scopeInput: VoucherScope,
): Promise<{
  book: { code: string; name: string; mainBook: string };
  nextVoucherNo: string;
  vouchers: Array<Record<string, unknown>>;
}> {
  const scope = completeScope(scopeInput);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const book = await resolveBookTx(tx, scope);
    const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT a."VCH_NO", a."VCH_DATE"::text AS "VCH_DAY", b."AC_NAME", a."VCH_DESC", a."MAIN_USER",
              (SELECT count(*)::int FROM "LBR_REC_DETL" d WHERE d.tenant_id=a.tenant_id AND d."CO_CODE"=a."CO_CODE"
                AND d."LC_CODE"=a."LC_CODE" AND d."CO_YEAR"=a."CO_YEAR" AND d."CO_BOOK"=a."CO_BOOK" AND d."VCH_NO"=a."VCH_NO") AS children
         FROM "LBR_DATA" a
         LEFT JOIN LATERAL (SELECT "AC_NAME" FROM "AC_MAST" m WHERE m.tenant_id=a.tenant_id AND m."CO_CODE"=a."CO_CODE"
            AND m."AC_CODE"=a."AC_CODE" ORDER BY m.row_id LIMIT 1) b ON true
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
        vchDate: isoOf(row.VCH_DAY),
        partyName: dbText(row.AC_NAME),
        vchDesc: dbText(row.VCH_DESC),
        mainUser: dbText(row.MAIN_USER),
        children: num(row.children),
      })),
    };
  });
}

export async function tagSplitSource(
  prisma: any,
  scopeInput: VoucherScope,
  request: { tagNo?: string; vchSrno?: string | number; itCode?: string },
): Promise<Record<string, unknown>> {
  const scope = completeScope(scopeInput);
  const tagNo = typedText(request.tagNo, 15);
  if (!tagNo || tagNo === 'N') throw new TagSplitValidationError('enter a tag number');
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const key: TagKey = {
      CO_CODE: scope.coCode,
      LC_CODE: scope.lcCode,
      TAG_NO: tagNo,
      ...(request.vchSrno != null && String(request.vchSrno).trim() !== ''
        ? { VCH_SRNO: num(request.vchSrno) }
        : {}),
      ...(request.itCode ? { IT_CODE: typedText(request.itCode, 5) } : {}),
    };
    const identity = await resolveLiveTagIdentityTx(tx, key);
    const bar = await firstBarDetlTx(
      tx,
      scope,
      tagNo,
      num(identity.VCH_SRNO),
      identity.source === 'BAR_DETL' ? dbText(identity.IT_CODE) : '',
    );
    if (!bar) throw new TagSplitValidationError(`parent tag ${tagNo} has no barcode record`);
    const cells = parentCellsFromBarDetl(bar);
    const items = await itemsTx(tx, scope, [cells.itCode]);
    const stones = await tagStonesTx(tx, bar);
    return {
      tagNo,
      vchSrno: num(identity.VCH_SRNO),
      source: identity.source,
      itName: items.get(cells.itCode.trim().toUpperCase())?.itName ?? '',
      line: {
        tagNo,
        vchSrno: num(identity.VCH_SRNO),
        itCode: cells.itCode,
        tblCode: cells.tblCode,
        designNo: cells.designNo,
        itmSize: cells.itmSize,
        pcs: cells.pcs,
        grossWt: cells.grossWt,
        lessWt: cells.lessWt,
        netWt: cells.netWt,
        touch: cells.touch,
        westPct: cells.westPct,
        fine: cells.fine,
        krNetWt: cells.krNetWt,
        krFine: cells.krFine,
        krName: cells.krName,
        itType: cells.itType,
        prCode: cells.prCode,
      },
      stones: stones.map((s) => ({
        isrNo: s.isrNo,
        itCode: s.itCode,
        itName: s.itName,
        pcs: s.pcs,
        grossWt: s.grossWt,
        karigarWt: s.karigarWt,
        conPct: s.conPct,
        rateType: s.rateType,
        rate: s.rate,
        amount: s.amount,
        lbrRate: s.lbrRate,
        lbrAmount: s.lbrAmount,
        netAmount: s.netAmount,
        itType: s.itType,
      })),
    };
  });
}
