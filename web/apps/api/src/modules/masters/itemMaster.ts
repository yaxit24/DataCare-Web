import { vbVal } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';
import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { requiredVersion, versionOf } from '../vouchers/version.js';

/**
 * Item master (desktop MS_ITEM, menu Master → Item; MDI_FORM.cs:7650-7659 opens the form directly). One ITEM_MAST row
 * per item code: its product and group, type, tag type and trade type (from the group), name, safe, HSN code, unit,
 * rate basis, labour rate and %, ghat %, conversion %, discount %, item rate, other-detail rate and its type, bag weight
 * and the stock display flag.
 *
 * - The list is every item of the company ordered by name (MS_ITEM_Load, MS_ITEM.cs:2548-2784), shown as Code / Name /
 *   Safe (DGV_FILL :2795-2843); a search keeps the items whose name or code starts with the text (:3118-3139).
 * - The product and group boxes are read-only (InitializeComponent :2135, :2139): Enter opens the product help by name
 *   (tPrCode_KeyDown :3081-3116) and the group help by name with its type and trade type (tGrCode_KeyDown :3397-3450). A
 *   chosen group fills the item type, tag type and trade type, and on a new entry the item code (product + group) and
 *   name (product name + " " + group code). Leaving the group of a new entry whose item code exists asks "This Item
 *   already Exist in '<name>' Item Name...You Want to Creat New Item..." (tGrCode_Validating :3452-3495).
 * - Leaving the item code refuses a code another item has under another name (:3497-3517); leaving the name refuses a
 *   name another item has (:3603-3629).
 * - BtnSave_Click (:3165-3300) needs the edit right only for an opened item, refuses a blank product, group and item code
 *   with the desktop texts, and writes the item with Val of the number boxes, the first letter of the three combos and
 *   Y/N of the check boxes; MAIN_USER is the user for a new item and the stored one for an opened item (:2862, :3018).
 * - BtnDelete_Click (:3302-3355) needs the delete right and refuses an item with stock rows ("You Can't Delete Record
 *   This Item Use in Transaction...."), a default item ("You Cant Delete Record This Item Code Is Default Code....") and
 *   a blank code before it asks.
 * - btnTagValUpdate_Click (:3969-4015) sets the labour %, karigar touch and karigar wastage % of the item's tags at the
 *   location where they are zero, and recomputes KR_FINE = KR_NET_WT × (KR_TOUCH + KR_WEST_PRC) / 100 for the year.
 *
 * Deliberate differences, recorded on the gap:
 * - Save updates the item's row in place in one transaction. The desktop deletes the row and inserts one from a blank
 *   DataRow (:3225-3263), which writes NULL into every column the form does not show: the minimum stock of the Item Stock
 *   Limit screen, the averages and the opening touch and fine.
 * - Save refuses a product or group code that is not in its master (the desktop boxes take a code only from the help), a
 *   blank name (the desktop warns on leaving the name but saves it), and a box longer than its MaxLength.
 * - An opened item carries the version read with it (N51 tokens) over the boxes the screen shows.
 * - The Tag Value Update needs the edit right; the desktop button checks none.
 * - The edition- and registration-specific boxes (Ac Item, UniCode Name, Tax Free, Tag Oth Detail, Oth Detail Posting,
 *   App Item) are not shown in Lite; an opened item keeps their stored values and a new item writes 'N' or blank, as the
 *   desktop's unchecked hidden boxes do. The Excel import (Ctrl+O, btnExcel_Click :3856-3909) belongs to Data Import.
 */
export class ItemMasterValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'ItemMasterValidationError';
  }
}

export class ItemVersionConflictError extends Error {
  readonly code = 'item-version-conflict';
  readonly statusCode = 409;
  constructor() {
    super(
      'This item was changed by someone else after you opened it. Open it again before saving or deleting.',
    );
    this.name = 'ItemVersionConflictError';
  }
}

export interface ItemScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
}

/** Rate Per (cboRateType, MS_ITEM_Load :2696-2700); RATE_TYPE stores the first letter (:3241). */
export const ITEM_RATE_TYPES = [
  { letter: 'G', label: 'Gram Wise' },
  { letter: '1', label: '10Gm Wise' },
  { letter: 'K', label: 'Kg Wise' },
  { letter: 'P', label: 'Pcs Wise' },
] as const;
/** Oth Dtl Rate Type (cboOthRateType :2704-2707); OTH_RATE_TYPE stores the first letter (:3254). */
export const ITEM_OTHER_RATE_TYPES = [
  { letter: 'W', label: 'Weight' },
  { letter: 'P', label: 'Pcs' },
  { letter: 'F', label: 'Fix' },
] as const;
/** The items BtnDelete_Click never deletes (MS_ITEM.cs:3322-3340). */
export const DEFAULT_ITEMS = [
  'SN',
  'RD',
  'OS',
  'OG',
  'OE',
  'HM',
  'FSL',
  'DM',
  '24CT',
  '999',
  'ORG',
  'ORS',
  'ORD',
  'OO',
] as const;

/** The boxes the screen sends, with their ITEM_MAST column, kind and the box's MaxLength (form spec / resx). */
const TEXT_FIELDS = [
  ['itType', 'IT_TYPE', 1],
  ['tagType', 'TAG_TYPE', 1],
  ['tradeType', 'TRAD_TYPE', 2],
  ['safe', 'SAFE_NAME', 30],
  ['hsn', 'HSN_CODE', 10],
  ['unit', 'UNIT_NAME', 5],
] as const;
const NUMBER_FIELDS = [
  ['lbrRate', 'IT_LBR_RATE'],
  ['lbrPrc', 'LBR_PRC'],
  ['ghtPrc', 'IT_GHT_PRC'],
  ['conPrc', 'CON_PRC'],
  ['discPrc', 'DISC_PRC'],
  ['itemRate', 'ITEM_RATE'],
  ['othRate', 'OTH_RATE'],
  ['bagWt', 'IT_BAG_WT'],
] as const;
/** The check boxes Lite shows when the company setting is on (MS_ITEM_Load :2716-2733). */
const FLAG_FIELDS = [
  ['othItmWtRemove', 'OTH_ITM_WT_REMOVE'],
  ['lotStock', 'ITM_WITH_LOT_STK'],
] as const;
/** The stored boxes Lite does not show; a new item writes them as the desktop's cleared, hidden boxes do. */
const HIDDEN_DEFAULTS = {
  UNICODE_NAME: '',
  TAG_IDTL_COL: 'N',
  AC_ITEM: '',
  OTH_DETL_POSTING: 'N',
} as const;
/** The columns the screen shows; the version token covers these only (postings maintain the averages). */
const SHOWN_COLUMNS = [
  'PR_CODE',
  'GR_CODE',
  'IT_CODE',
  'IT_NAME',
  'IT_TYPE',
  'TAG_TYPE',
  'TRAD_TYPE',
  'SAFE_NAME',
  'HSN_CODE',
  'UNIT_NAME',
  'RATE_TYPE',
  'STK_DISPLAY',
  'LBR_PRC',
  'IT_LBR_RATE',
  'CON_PRC',
  'DISC_PRC',
  'ITEM_RATE',
  'OTH_RATE',
  'IT_BAG_WT',
  'IT_GHT_PRC',
  'OTH_RATE_TYPE',
  'MAIN_USER',
  'OTH_ITM_WT_REMOVE',
  'ITM_WITH_LOT_STK',
];

export type ItemInput = {
  productCode?: string;
  groupCode?: string;
  name?: string;
  rateType?: string;
  stockDisplay?: string;
  othRateType?: string;
} & Partial<Record<(typeof TEXT_FIELDS)[number][0], string>> &
  Partial<Record<(typeof NUMBER_FIELDS)[number][0], number | string>> &
  Partial<Record<(typeof FLAG_FIELDS)[number][0], boolean>>;

export interface ItemSaveInput {
  scope: ItemScope;
  user: string;
  entryMode: 'A' | 'E';
  code: string;
  values: ItemInput;
  expectedVersion?: unknown;
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_ITEM_KeyPress upper-cases every key and drops the apostrophe (MS_ITEM.cs:3066-3079). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');
const num = (value: unknown): number => (value == null ? 0 : Number(value));

/** Desktop text of tItCode_Validating (MS_ITEM.cs:3507). */
export const itemCodeTakenMessage = (name: string): string =>
  `This Item Code already Exist in  '${name}'  Item Name...Please Change It Code...`;
/** Desktop text of tItName_Validating (MS_ITEM.cs:3619); the desktop says "Item Code" here too. */
export const itemNameTakenMessage = (code: string): string =>
  `This Item Code already Exist in  '${code}'  Item Name...Please Change It Name...`;
/** Desktop question of tGrCode_Validating (MS_ITEM.cs:3473). */
export const itemExistsQuestion = (name: string): string =>
  `This Item already Exist in  '${name}' Item Name...You Want to Creat New Item...`;

const lockTx = (tx: any, scope: ItemScope) =>
  tx.$executeRawUnsafe(
    'SELECT pg_advisory_xact_lock(hashtext($1))',
    `item-master:${scope.tenantId}:${scope.coCode}`,
  );

async function itemVersionTx(tx: any, scope: ItemScope, code: string): Promise<string> {
  const rows: unknown[] = await tx.$queryRawUnsafe(
    `SELECT ${SHOWN_COLUMNS.map((c) => `"${c}"::text`).join(',')} FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  return versionOf({ ITEM_MAST: rows });
}

/** The two company settings that show a check box on the screen (CO_SET_NEW, read at company open, MS_OPNCOMP:1008-1011). */
async function itemSettingsTx(tx: any, scope: ItemScope) {
  const [row] = await tx.$queryRawUnsafe(
    `SELECT "OTH_ITM_WT_REMOVE","ITM_WITH_LOT_STK" FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"=$2 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  return {
    othItmWtRemove: text(row?.OTH_ITM_WT_REMOVE).toUpperCase() === 'Y',
    lotStock: text(row?.ITM_WITH_LOT_STK).toUpperCase() === 'Y',
  };
}

export async function listItems(prisma: any, scope: ItemScope) {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const rows: any[] = await tx.$queryRawUnsafe(
      `SELECT "IT_CODE","IT_NAME","SAFE_NAME" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
        ORDER BY "IT_NAME","IT_CODE"`,
      scope.tenantId,
      scope.coCode,
    );
    const distinct = async (column: 'UNIT_NAME' | 'SAFE_NAME') =>
      (
        (await tx.$queryRawUnsafe(
          `SELECT DISTINCT coalesce("${column}",'') v FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
          scope.tenantId,
          scope.coCode,
        )) as Array<{ v: string }>
      ).map((r) => text(r.v));
    return {
      rows: rows.map((r) => ({
        code: text(r.IT_CODE),
        name: text(r.IT_NAME),
        safe: text(r.SAFE_NAME),
      })),
      // AddCboItem (:3631-3673): the company's distinct units and safes.
      combos: { units: await distinct('UNIT_NAME'), safes: await distinct('SAFE_NAME') },
      settings: await itemSettingsTx(tx, scope),
    };
  });
}

/** tPrCode_KeyDown: a product code found in PRODUCT_MAST, else the products by name. */
export async function itemProducts(prisma: any, scope: ItemScope, term: string, limit = 20) {
  const t = text(term);
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "PR_CODE","PR_NAME" FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND ("PR_CODE"=$3 OR "PR_CODE" ILIKE $4 OR "PR_NAME" ILIKE $5)
        ORDER BY ("PR_CODE"=$3) DESC, "PR_NAME", "PR_CODE" LIMIT $6`,
      scope.tenantId,
      scope.coCode,
      t.toUpperCase(),
      `${t}%`,
      `%${t}%`,
      Math.min(Math.max(Number(limit) || 20, 1), 50),
    ),
  );
  return rows.map((r) => ({ code: text(r.PR_CODE), name: text(r.PR_NAME) }));
}

/** tGrCode_KeyDown: a group code found in GROUP_MAST, else the groups by name with their type and trade type. */
export async function itemGroups(prisma: any, scope: ItemScope, term: string, limit = 20) {
  const t = text(term);
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE" FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
          AND ("GR_CODE"=$3 OR "GR_CODE" ILIKE $4 OR "GR_NAME" ILIKE $5)
        ORDER BY ("GR_CODE"=$3) DESC, "GR_NAME", "GR_CODE" LIMIT $6`,
      scope.tenantId,
      scope.coCode,
      t.toUpperCase(),
      `${t}%`,
      `%${t}%`,
      Math.min(Math.max(Number(limit) || 20, 1), 50),
    ),
  );
  return rows.map((r) => ({
    code: text(r.GR_CODE),
    name: text(r.GR_NAME),
    type: text(r.GR_TYPE),
    trade: text(r.TRAD_TYPE),
  }));
}

export async function getItem(prisma: any, scope: ItemScope, codeRaw: string) {
  const code = typed(codeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const [row] = await tx.$queryRawUnsafe(
      `SELECT i.*, p."PR_NAME" pr_name, g."GR_NAME" gr_name
         FROM "ITEM_MAST" i
         LEFT JOIN LATERAL (SELECT "PR_NAME" FROM "PRODUCT_MAST" p WHERE p.tenant_id=i.tenant_id AND p."CO_CODE"=i."CO_CODE"
                             AND p."PR_CODE"=i."PR_CODE" ORDER BY p.row_id LIMIT 1) p ON true
         LEFT JOIN LATERAL (SELECT "GR_NAME" FROM "GROUP_MAST" g WHERE g.tenant_id=i.tenant_id AND g."CO_CODE"=i."CO_CODE"
                             AND g."GR_CODE"=i."GR_CODE" ORDER BY g.row_id LIMIT 1) g ON true
        WHERE i.tenant_id=$1 AND i."CO_CODE"=$2 AND i."IT_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (!row) return null;
    const [used] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    const view: Record<string, unknown> = {
      code,
      productCode: text(row.PR_CODE),
      productName: text(row.pr_name),
      groupCode: text(row.GR_CODE),
      groupName: text(row.gr_name),
      name: text(row.IT_NAME),
      rateType: text(row.RATE_TYPE),
      // DISPLAY_DATA shows No only for 'N' and Weight for anything but P and F (:2945-2963).
      stockDisplay: text(row.STK_DISPLAY) === 'N' ? 'N' : 'Y',
      othRateType: ['P', 'F'].includes(text(row.OTH_RATE_TYPE)) ? text(row.OTH_RATE_TYPE) : 'W',
      inStock: Boolean(used),
    };
    for (const [key, column] of TEXT_FIELDS) view[key] = text(row[column]);
    for (const [key, column] of NUMBER_FIELDS) view[key] = num(row[column]);
    for (const [key, column] of FLAG_FIELDS) view[key] = text(row[column]) === 'Y';
    view.version = await itemVersionTx(tx, scope, code);
    return view;
  });
}

export async function saveItem(prisma: any, input: ItemSaveInput): Promise<{ code: string }> {
  const code = typed(input.code);
  const v = input.values;
  const productCode = typed(v.productCode);
  const groupCode = typed(v.groupCode);
  const name = typed(v.name);
  if (!productCode) throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_PRODUCT_REQUIRED);
  if (!groupCode) throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_GROUP_REQUIRED);
  if (!code) throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_CODE_NULL);
  if (!name) throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_NAME_REQUIRED);
  if (code.length > 5)
    throw new ItemMasterValidationError('item code must be at most 5 characters');
  if (name.length > 50)
    throw new ItemMasterValidationError('item name must be at most 50 characters');
  const values: Record<string, unknown> = {
    PR_CODE: productCode,
    GR_CODE: groupCode,
    IT_NAME: name,
  };
  for (const [key, column, max] of TEXT_FIELDS) {
    const value = typed(v[key]);
    if (value.length > max)
      throw new ItemMasterValidationError(`${column} must be at most ${max} characters`);
    values[column] = value;
  }
  for (const [key, column] of NUMBER_FIELDS) values[column] = vbVal(v[key]);
  const rateType = typed(v.rateType || 'G').slice(0, 1);
  if (!ITEM_RATE_TYPES.some((t) => t.letter === rateType))
    throw new ItemMasterValidationError(`rate type ${rateType} is not one of the screen's types`);
  const othRateType = typed(v.othRateType || 'W').slice(0, 1);
  if (!ITEM_OTHER_RATE_TYPES.some((t) => t.letter === othRateType))
    throw new ItemMasterValidationError(
      `other rate type ${othRateType} is not one of the screen's types`,
    );
  values.RATE_TYPE = rateType;
  values.OTH_RATE_TYPE = othRateType;
  values.STK_DISPLAY = typed(v.stockDisplay) === 'N' ? 'N' : 'Y';
  const expected = input.entryMode === 'E' ? requiredVersion(input.expectedVersion) : null;
  await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { tenantId, coCode } = input.scope;
    await lockTx(tx, input.scope);
    if (expected && (await itemVersionTx(tx, input.scope, code)) !== expected)
      throw new ItemVersionConflictError();
    const settings = await itemSettingsTx(tx, input.scope);
    for (const [key, column] of FLAG_FIELDS) {
      const shown = key === 'othItmWtRemove' ? settings.othItmWtRemove : settings.lotStock;
      // A box the setting hides keeps the stored value; a new item writes N (CLEAR_DATA unchecks it).
      if (shown) values[column] = v[key] ? 'Y' : 'N';
    }
    const items: Array<{ IT_CODE: string; IT_NAME: string | null; MAIN_USER: string | null }> =
      await tx.$queryRawUnsafe(
        `SELECT "IT_CODE","IT_NAME","MAIN_USER" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        tenantId,
        coCode,
      );
    const same = items.find((r) => text(r.IT_CODE) === code);
    if (same && input.entryMode === 'A' && text(same.IT_NAME).toUpperCase() !== name)
      throw new ItemMasterValidationError(itemCodeTakenMessage(text(same.IT_NAME)));
    if (!same && input.entryMode === 'E') throw new ItemVersionConflictError();
    const namesake = items.find(
      (r) => text(r.IT_NAME).toUpperCase() === name && text(r.IT_CODE) !== code,
    );
    if (namesake) throw new ItemMasterValidationError(itemNameTakenMessage(text(namesake.IT_CODE)));
    const [product] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3 LIMIT 1`,
      tenantId,
      coCode,
      productCode,
    );
    if (!product)
      throw new ItemMasterValidationError(`product ${productCode} is not in the product master`);
    const [group] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3 LIMIT 1`,
      tenantId,
      coCode,
      groupCode,
    );
    if (!group)
      throw new ItemMasterValidationError(`group ${groupCode} is not in the group master`);
    if (same) {
      // MainUser: the stored user of an opened item (DISPLAY_DATA :3018), the signed-in user for a new entry (:2862).
      const set: Record<string, unknown> = {
        ...values,
        ...(input.entryMode === 'A' ? { MAIN_USER: input.user, ...HIDDEN_DEFAULTS } : {}),
      };
      const columns = Object.keys(set);
      await tx.$executeRawUnsafe(
        `UPDATE "ITEM_MAST" SET ${columns.map((c, i) => `"${c}"=$${i + 4}`).join(',')}
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3`,
        tenantId,
        coCode,
        code,
        ...Object.values(set),
      );
    } else {
      const flags = Object.fromEntries(
        FLAG_FIELDS.map(([, column]) => [column, values[column] ?? 'N']),
      );
      await insertRowTx(tx, 'ITEM_MAST', tenantId, {
        CO_CODE: coCode,
        IT_CODE: code,
        ...values,
        ...flags,
        ...HIDDEN_DEFAULTS,
        MAIN_USER: input.user,
      });
    }
  });
  return { code };
}

export async function deleteItem(
  prisma: any,
  scope: ItemScope,
  codeRaw: string,
  expectedVersion?: unknown,
): Promise<{ code: string; deleted: number }> {
  const code = typed(codeRaw);
  const expected =
    expectedVersion == null || expectedVersion === '' ? null : requiredVersion(expectedVersion);
  const deleted = await withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    await lockTx(tx, scope);
    // BtnDelete_Click's order (:3311-3345): stock rows, a default code, a blank code.
    const [used] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3 LIMIT 1`,
      scope.tenantId,
      scope.coCode,
      code,
    );
    if (used) throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_IN_TRANSACTION);
    if ((DEFAULT_ITEMS as readonly string[]).includes(code))
      throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_DEFAULT_CODE);
    if (!code) throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_SELECT_FOR_DELETE);
    if (expected && (await itemVersionTx(tx, scope, code)) !== expected)
      throw new ItemVersionConflictError();
    return tx.$executeRawUnsafe(
      `DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3`,
      scope.tenantId,
      scope.coCode,
      code,
    );
  });
  return { code, deleted: Number(deleted) };
}

/**
 * btnTagValUpdate_Click (MS_ITEM.cs:3969-4015), ported statement for statement. Each non-zero box sets its column on
 * the item's tags at the location where the column is zero (the karigar wastage only where the karigar touch is set),
 * outside the desktop's sold-tag subquery; then KR_FINE is recomputed for the item's tags of the year.
 */
export async function updateItemTagValues(
  prisma: any,
  scope: ItemScope,
  codeRaw: string,
  boxes: { lbrPrc?: unknown; krTouch?: unknown; krWestPrc?: unknown },
): Promise<{ code: string; labour: number; touch: number; wastage: number; fine: number }> {
  const code = typed(codeRaw);
  if (!code) throw new ItemMasterValidationError(DESKTOP_MESSAGES.ITEM_SELECT_FOR_DELETE);
  const lbr = vbVal(boxes.lbrPrc);
  const touch = vbVal(boxes.krTouch);
  const west = vbVal(boxes.krWestPrc);
  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    const { tenantId, coCode, lcCode, coYear } = scope;
    // The desktop's subquery keeps ITM_SIGN '-' rows and then asks for a positive signed sum of them (:3982).
    const soldTags = `SELECT a."TAG_NO" FROM "MAIN_STOCK" a WHERE a.tenant_id=$1 AND a."CO_CODE"=$2 AND a."LC_CODE"=$3
        AND a."ITM_SIGN"='-' AND a."TAG_NO"<>'N' AND a."IT_CODE"=$4
      GROUP BY a."TAG_NO" HAVING sum(CASE WHEN a."ITM_SIGN"='+' THEN a."VCH_SRNO" ELSE -a."VCH_SRNO" END) > 0`;
    const update = (column: string, value: number, extra = '') =>
      tx.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "${column}"=$5 WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "IT_CODE"=$4
            AND coalesce("${column}",0)=0 ${extra} AND "TAG_NO" NOT IN (${soldTags})`,
        tenantId,
        coCode,
        lcCode,
        code,
        value,
      );
    const labour = lbr !== 0 ? Number(await update('LBR_PRC', lbr)) : 0;
    const touched = touch !== 0 ? Number(await update('KR_TOUCH', touch)) : 0;
    const wastage =
      west !== 0 ? Number(await update('KR_WEST_PRC', west, `AND coalesce("KR_TOUCH",0)<>0`)) : 0;
    const fine = await tx.$executeRawUnsafe(
      `UPDATE "BAR_DETL" SET "KR_FINE" = "KR_NET_WT"::float8 * (coalesce("KR_TOUCH",0)::float8 + coalesce("KR_WEST_PRC",0)::float8) / 100
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "IT_CODE"=$5
          AND (coalesce("KR_TOUCH",0) + coalesce("KR_WEST_PRC",0)) <> 0 AND coalesce("KR_NET_WT",0) <> 0`,
      tenantId,
      coCode,
      lcCode,
      coYear,
      code,
    );
    return { code, labour, touch: touched, wastage, fine: Number(fine) };
  });
}
