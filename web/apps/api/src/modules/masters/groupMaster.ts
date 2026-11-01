import { vbVal } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';

/**
 * Item Group master (desktop MS_GROUP, menu Master → Group; MDI_FORM.cs:7630-7636 opens the form directly). One
 * GROUP_MAST row per group code: its metal type, trade type, rate and purchase touch, melting and wastage %, the sales
 * and purchase accounts the sale and purchase postings credit and debit per item group (`sales.ts`, G169), the HSN
 * code, the rate tax % and whether its rate shows on the main screen.
 *
 * - The list is every group ordered by code (CLEAR_DATA, MS_GROUP.cs:1732), shown as Code / Name (DGV_FILL
 *   :1666-1711); a search keeps the names that start with the typed text (Text1_TextChanged :2050-2071).
 * - DISPLAY_DATA (:1738-1808) shows the touches, melting, wastage and tax % as 0.00 and each account with its name.
 * - BtnSave_Click (:1825-1919) needs the edit right only for an opened group (:1844-1848), refuses a blank sales or
 *   purchase account ("Please Select Sales and Purchase Account And Try", :1849-1854) and then a blank code or name
 *   ("Enter Group Detail", :1857-1861), writes the group's row with Val of each number box, GR_TYPE = the first letter
 *   of the item type and RATE_DISPLAY Y or N (:1862-1885), sets the trade type, item type and HSN code on every item of
 *   the group (:1887), and answers "Data Are Saved." (:1889). MAIN_USER is the user for a new group and the stored one
 *   for an opened group (MainUser, :1725 and :1802).
 * - Leaving the code refuses a code another group has, and leaving the name a name another code has
 *   (tGrCode_Validating :2006-2026, tGrName_Validating :2028-2048).
 * - BtnDelete_Click (:1921-1954) needs the delete right, refuses a blank code ("Please Select Group For Delete.") and a
 *   group an item uses ("You Cant Delete Record This Group Code Use in Item Master....", :1940-1944) before it asks.
 *
 * Deliberate differences from the desktop, recorded on the gap:
 * - Save updates the group's row in place and runs with the item update in one transaction. The desktop deletes the
 *   row and inserts a new one from a blank DataRow (:1862-1886), which writes NULL into every column the form does not
 *   show: the day's rate the Daily Rate screen keeps in GR_RATE and the average and day-close fields. A second row of the
 *   same code is removed, as the desktop's delete leaves one row.
 * - Save refuses an account code that is not in AC_MAST (the desktop looks a code up only on Enter), a name over the
 *   box's 40 characters, and a trade type over the 2 characters ITEM_MAST.TRAD_TYPE holds (the desktop's item update
 *   fails on a longer one after the group is already written).
 * - An opened group carries the version read with it (N51 tokens): a save or delete after another operator's change is
 *   refused with 409 where the desktop's later save wins.
 * - The Add Touch box (ADD_TOUCH) is shown only for one registration (SSRegSrNo VK289NEPH, MS_GROUP.cs:1638-1641) and
 *   the web schema has no such column, so it is left out.
 */
export class GroupMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'GroupMasterValidationError';
  }
}

export class GroupVersionConflictError extends Error {
  readonly code = 'group-version-conflict';
  readonly statusCode = 409;
  constructor() {
    super(
      'This group was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'GroupVersionConflictError';
  }
}

export interface GroupScope {
  tenantId: string;
  coCode: string;
}

/** The Item Type combo's entries in order (MS_GROUP_Load :1642-1648); GR_TYPE stores the first letter (:1868). */
export const GROUP_ITEM_TYPES = [
  { letter: 'G', label: 'Gold' },
  { letter: 'S', label: 'Silver' },
  { letter: 'D', label: 'Diamond' },
  { letter: 'R', label: 'Real Stone' },
  { letter: 'E', label: 'Emitation' },
  { letter: 'O', label: 'Other' },
  { letter: 'P', label: 'Platinum' },
] as const;

export interface GroupSaveInput {
  scope: GroupScope;
  /** The signed-in user, written as MAIN_USER for a new group (CLEAR_DATA, MS_GROUP.cs:1725). */
  user: string;
  /** 'A' for a new group, 'E' for one opened from the list (the desktop's EntryMode). */
  entryMode: 'A' | 'E';
  code: string;
  name: string;
  itemType?: string;
  tradeType?: string;
  rateTouch?: number | string;
  purcTouch?: number | string;
  melting?: number | string;
  west?: number | string;
  saleAc?: string;
  purcAc?: string;
  hsn?: string;
  taxPct?: number | string;
  rateDisplay?: boolean;
  /** The version read when the group was opened; required for an opened one ('E'). */
  expectedVersion?: unknown;
}

export interface GroupView {
  code: string;
  name: string;
  itemType: string;
  tradeType: string;
  rateTouch: number;
  purcTouch: number;
  melting: number;
  west: number;
  taxPct: number;
  saleAc: string;
  saleAcName: string;
  purcAc: string;
  purcAcName: string;
  hsn: string;
  rateDisplay: boolean;
  /** Items of the group: BtnDelete_Click refuses such a group before it asks (:1940-1944). */
  items: number;
  version: string;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_GROUP_KeyPress upper-cases every key and drops the apostrophe (MS_GROUP.cs:1975-1988). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');

/** Desktop text of tGrCode_Validating (MS_GROUP.cs:2016). */
export const groupCodeTakenMessage = (name: string): string =>
  `This Group Code already Exist in  '${name}'  Group Name... Please Change Group Code...`;
/** Desktop text of tGrName_Validating (MS_GROUP.cs:2038). */
export const groupNameTakenMessage = (code: string): string =>
  `This Group Name already Exist in  '${code}'  Group Code... Please Change Group Name...`;

const lockTx = (tx: any, scope: GroupScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `group-master:${scope.tenantId}:${scope.coCode}`,
  );

/**
 * SHA-256 of the columns the screen shows, with the row ids. The Daily Rate screen writes GR_RATE on every rate save
 * (`dailyRate.ts`), which must not refuse an operator's open group.
 */
async function groupVersionTx(tx: any, scope: GroupScope, code: string): Promise<string> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT row_id::text,"GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","GR_TOUCH","GR_PURC_TOUCH","MELTING_PRC",
            "WEST_PRC","TAX_PRC"::text,"SALE_AC","PURC_AC","HSN_CODE","RATE_DISPLAY","MAIN_USER"
       FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3 ORDER BY row_id`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return versionOf({ GROUP_MAST: rows });
}

export async function listGroups(
  prisma: any,
  scope: GroupScope,
): Promise<{ rows: Array<{ code: string; name: string }> }> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: Array<{ GR_CODE: string | null; GR_NAME: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT "GR_CODE","GR_NAME" FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
          ORDER BY "GR_CODE","row_id"`,
        scope.tenantId,
        scope.coCode,
      );
    return { rows: rows.map((row) => ({ code: text(row.GR_CODE), name: text(row.GR_NAME) })) };
  });
}

const accountNameTx = async (tx: any, scope: GroupScope, code: string): Promise<string> => {
  if (!code) return '';
  const [row] = await tx.$queryRawUnsafe(
    `SELECT "AC_NAME" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return text(row?.AC_NAME);
};

export async function getGroup(
  prisma: any,
  scope: GroupScope,
  codeRaw: string,
): Promise<GroupView | null> {
  const code = typed(codeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const [row] = await tx.$queryRawUnsafe(
      `SELECT "GR_NAME","GR_TYPE","TRAD_TYPE",coalesce("GR_TOUCH",0)::float8 rate_touch,
              coalesce("GR_PURC_TOUCH",0)::float8 purc_touch,coalesce("MELTING_PRC",0)::float8 melting,
              coalesce("WEST_PRC",0)::float8 west,coalesce("TAX_PRC",0)::float8 tax_pct,"SALE_AC","PURC_AC",
              "HSN_CODE","RATE_DISPLAY"
         FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3 ORDER BY row_id LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (!row) return null;
    const [{ n }] = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    const saleAc = text(row.SALE_AC);
    const purcAc = text(row.PURC_AC);
    return {
      code,
      name: text(row.GR_NAME),
      itemType: text(row.GR_TYPE),
      tradeType: text(row.TRAD_TYPE),
      rateTouch: Number(row.rate_touch),
      purcTouch: Number(row.purc_touch),
      melting: Number(row.melting),
      west: Number(row.west),
      taxPct: Number(row.tax_pct),
      saleAc,
      saleAcName: await accountNameTx(tx, scope, saleAc),
      purcAc,
      purcAcName: await accountNameTx(tx, scope, purcAc),
      hsn: text(row.HSN_CODE),
      // DISPLAY_DATA ticks the box only for 'Y' (:1792-1799).
      rateDisplay: text(row.RATE_DISPLAY) === 'Y',
      items: Number(n),
      version: await groupVersionTx(tx, scope, code),
    };
  });
}

export async function saveGroup(
  prisma: any,
  input: GroupSaveInput,
): Promise<{ code: string; items: number }> {
  const code = typed(input.code);
  const name = typed(input.name);
  const saleAc = typed(input.saleAc);
  const purcAc = typed(input.purcAc);
  if (!saleAc || !purcAc)
    throw new GroupMasterValidationError(DESKTOP_MESSAGES.GROUP_ACCOUNTS_REQUIRED);
  if (!code || !name) throw new GroupMasterValidationError(DESKTOP_MESSAGES.GROUP_DETAIL_REQUIRED);
  if (code.length > 3) throw new GroupMasterValidationError('group code must be 1 to 3 characters');
  if (name.length > 40)
    throw new GroupMasterValidationError('group name must be at most 40 characters');
  const tradeType = typed(input.tradeType);
  if (tradeType.length > 2)
    throw new GroupMasterValidationError(
      'trade type must be at most 2 characters (the items of the group keep it in ITEM_MAST.TRAD_TYPE)',
    );
  const hsn = typed(input.hsn);
  if (hsn.length > 10)
    throw new GroupMasterValidationError('HSN code must be at most 10 characters');
  const itemType = typed(input.itemType || 'G').slice(0, 1);
  if (!GROUP_ITEM_TYPES.some((t) => t.letter === itemType))
    throw new GroupMasterValidationError(`item type ${itemType} is not one of the screen's types`);
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  const values = {
    GR_NAME: name,
    TRAD_TYPE: tradeType,
    GR_TYPE: itemType,
    GR_TOUCH: vbVal(input.rateTouch),
    GR_PURC_TOUCH: vbVal(input.purcTouch),
    MELTING_PRC: vbVal(input.melting),
    WEST_PRC: vbVal(input.west),
    TAX_PRC: vbVal(input.taxPct),
    SALE_AC: saleAc,
    PURC_AC: purcAc,
    HSN_CODE: hsn,
    RATE_DISPLAY: input.rateDisplay ? 'Y' : 'N',
  };
  const items = await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { tenantId, coCode } = input.scope;
    await lockTx(tx, input.scope);
    if (expected && (await groupVersionTx(tx, input.scope, code)) !== expected)
      throw new GroupVersionConflictError();
    const groups: Array<{ row_id: bigint; GR_CODE: string | null; GR_NAME: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT row_id,"GR_CODE","GR_NAME" FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id`,
        tenantId,
        coCode,
      );
    const same = groups.filter((row) => text(row.GR_CODE) === code);
    // tGrCode_Validating: a code already used by another name is refused on a new entry.
    if (same[0] && input.entryMode === 'A' && text(same[0].GR_NAME).toUpperCase() !== name)
      throw new GroupMasterValidationError(groupCodeTakenMessage(text(same[0].GR_NAME)));
    // An opened group that another operator deleted meanwhile is not brought back.
    if (!same[0] && input.entryMode === 'E') throw new GroupVersionConflictError();
    // tGrName_Validating: a name already used by another code is refused.
    const namesake = groups.find(
      (row) => text(row.GR_NAME).toUpperCase() === name && text(row.GR_CODE) !== code,
    );
    if (namesake)
      throw new GroupMasterValidationError(groupNameTakenMessage(text(namesake.GR_CODE)));
    for (const [what, value] of [
      ['sales', saleAc],
      ['purchase', purcAc],
    ] as const) {
      const [found] = await tx.$queryRawUnsafe(
        `SELECT 1 FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3 LIMIT 1`,
        tenantId,
        coCode,
        value,
      );
      if (!found)
        throw new GroupMasterValidationError(
          `${what} account ${value} is not in the account master`,
        );
    }
    if (same[0]) {
      // MainUser: the stored user for an opened group, the signed-in user for a new entry (:1725, :1802, :1883).
      const mainUser = input.entryMode === 'A' ? { MAIN_USER: input.user } : {};
      const set = { ...values, ...mainUser };
      const columns = Object.keys(set);
      await tx.$executeRawUnsafe(
        `UPDATE "GROUP_MAST" SET ${columns.map((c, i) => `"${c}"=$${i + 3}`).join(',')}
          WHERE tenant_id=$1 AND row_id=$2`,
        tenantId,
        same[0].row_id,
        ...Object.values(set),
      );
      if (same.length > 1)
        await tx.$executeRawUnsafe(
          `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3 AND row_id<>$4`,
          tenantId,
          coCode,
          code,
          same[0].row_id,
        );
    } else {
      await insertRowTx(tx, 'GROUP_MAST', tenantId, {
        CO_CODE: coCode,
        GR_CODE: code,
        ...values,
        MAIN_USER: input.user,
      });
    }
    // Every item of the group takes its trade type, item type and HSN code (:1887).
    return tx.$executeRawUnsafe(
      `UPDATE "ITEM_MAST" SET "TRAD_TYPE"=$4,"IT_TYPE"=$5,"HSN_CODE"=$6
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3`,
      tenantId,
      coCode,
      code,
      tradeType,
      itemType,
      hsn,
    );
  });
  return { code, items: Number(items) };
}

/**
 * BtnDelete_Click deletes the group in the box unless an item uses it. An opened group sends the version read with it,
 * which must still be current; a group that was not opened is deleted as the desktop does, by code.
 */
export async function deleteGroup(
  prisma: any,
  scope: GroupScope,
  codeRaw: string,
  expectedVersion?: unknown,
): Promise<{ code: string; deleted: number }> {
  const code = typed(codeRaw);
  if (!code) throw new GroupMasterValidationError(DESKTOP_MESSAGES.GROUP_SELECT_FOR_DELETE);
  const expected =
    expectedVersion == null || expectedVersion === '' ? null : requiredVersion(expectedVersion);
  const deleted = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    if (expected && (await groupVersionTx(tx, scope, code)) !== expected)
      throw new GroupVersionConflictError();
    const [used] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (used) throw new GroupMasterValidationError(DESKTOP_MESSAGES.GROUP_IN_ITEM_MASTER);
    return tx.$executeRawUnsafe(
      `DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      code,
    );
  });
  return { code, deleted: Number(deleted) };
}

/**
 * The account helps. Enter on Sales Ac takes a code found in group 25, else lists group 25 by name without 00099
 * (tSalesAc_KeyDown, MS_GROUP.cs:2195-2231, :2204 and :2208); Enter on Purchase Ac does the same over group 30
 * (tPurcAc_KeyDown :2233-2269, :2242 and :2246).
 */
export async function groupAccounts(
  prisma: any,
  scope: GroupScope,
  kind: 'sale' | 'purchase',
  term: string,
  limit = 20,
): Promise<Array<{ code: string; name: string; group: string }>> {
  const typedTerm = text(term);
  const group = kind === 'sale' ? '25' : '30';
  const listed = kind === 'sale' ? `AND "AC_CODE"<>'00099'` : '';
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "AC_CODE","AC_NAME","AC_GR" FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_GR"=$7
          AND ("AC_CODE"=$3 OR (("AC_CODE" ILIKE $4 OR "AC_NAME" ILIKE $5) ${listed}))
        ORDER BY ("AC_CODE"=$3) DESC, "AC_NAME", "AC_CODE"
        LIMIT $6`,
      scope.tenantId,
      scope.coCode,
      typedTerm.toUpperCase(),
      `${typedTerm}%`,
      `%${typedTerm}%`,
      Math.min(Math.max(Number(limit) || 20, 1), 50),
      group,
    ),
  );
  return rows.map((row) => ({
    code: text(row.AC_CODE),
    name: text(row.AC_NAME),
    group: text(row.AC_GR),
  }));
}

/** The trade type help: a code found in BAL_GR moves on, else BAL_GR is listed by name (tGTradTyp_KeyDown :2271-2304). */
export async function groupTradeTypes(
  prisma: any,
  scope: GroupScope,
  term: string,
  limit = 20,
): Promise<Array<{ code: string; name: string }>> {
  const typedTerm = text(term);
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "TRAD_TYPE","TRAD_NAME" FROM "BAL_GR"
        WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND ("TRAD_TYPE"=$3 OR "TRAD_TYPE" ILIKE $4 OR "TRAD_NAME" ILIKE $5)
        ORDER BY ("TRAD_TYPE"=$3) DESC, "TRAD_NAME", "TRAD_TYPE"
        LIMIT $6`,
      scope.tenantId,
      scope.coCode,
      typedTerm.toUpperCase(),
      `${typedTerm}%`,
      `%${typedTerm}%`,
      Math.min(Math.max(Number(limit) || 20, 1), 50),
    ),
  );
  return rows.map((row) => ({ code: text(row.TRAD_TYPE), name: text(row.TRAD_NAME) }));
}

/** The rows BtnPrint_Click hands to the GroupMast report for the company (MS_GROUP.cs:1818-1819): every group by code. */
export async function groupPrintRows(
  prisma: any,
  scope: GroupScope,
): Promise<
  Array<{
    code: string;
    name: string;
    itemType: string;
    tradeType: string;
    rateTouch: number;
    purcTouch: number;
    melting: number;
    west: number;
    saleAc: string;
    purcAc: string;
    hsn: string;
    taxPct: number;
  }>
> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE",coalesce("GR_TOUCH",0)::float8 rate_touch,
              coalesce("GR_PURC_TOUCH",0)::float8 purc_touch,coalesce("MELTING_PRC",0)::float8 melting,
              coalesce("WEST_PRC",0)::float8 west,"SALE_AC","PURC_AC","HSN_CODE",coalesce("TAX_PRC",0)::float8 tax_pct
         FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "GR_CODE","row_id"`,
      scope.tenantId,
      scope.coCode,
    );
    return rows.map((row) => ({
      code: text(row.GR_CODE),
      name: text(row.GR_NAME),
      itemType: text(row.GR_TYPE),
      tradeType: text(row.TRAD_TYPE),
      rateTouch: Number(row.rate_touch),
      purcTouch: Number(row.purc_touch),
      melting: Number(row.melting),
      west: Number(row.west),
      saleAc: text(row.SALE_AC),
      purcAc: text(row.PURC_AC),
      hsn: text(row.HSN_CODE),
      taxPct: Number(row.tax_pct),
    }));
  });
}
