import { vbVal } from '@datacare/core';
import { withTxBudget } from '../shared/txBudget.js';
import { insertRowTx } from '../posting/posting.js';

/**
 * Auto Item (desktop MS_AUTO_ITEM with CurMast = 'AutoItem', menu Master → AutoItem; MDI_FORM.cs:7640-7649 opens the
 * form after setting MsUserRightForm to the caption). It makes a group's items from the product list in one go.
 *
 * - The group box is read-only (InitializeComponent, MS_AUTO_ITEM.cs:925-1390): Enter opens the group help by name with
 *   its type, trade type and HSN code (tGrCode_KeyDown :3432-3493), and a chosen group fills the type, trade type and
 *   HSN code boxes.
 * - DISPLAY_DATA (:2614-2650) lists every product of the company except HM, DM, OG, OS, SN, FN, RD, EM and OT by code
 *   and name, marked Y (shown in red) when an item of the group already has that product, else N; the grid is Sr. / Pr
 *   Code / Pr Name / MinStk / Y/N (MSG_CLEAR :1640-1683).
 * - BtnSave_Click (:2876-2923) creates, for every row with a product code and Y, the item PR_CODE + GR_CODE unless the
 *   group already has an item with that code: IT_NAME = the product name + " " + the group code, IT_TYPE = TAG_TYPE =
 *   the group type box, TRAD_TYPE, PR_CODE, GR_CODE, SAFE_NAME MAIN, the HSN box, UNIT_NAME GMS, RATE_TYPE G, MIN_STK =
 *   Val of the MinStk cell, MAIN_USER = the row's hidden user cell (blank for a product row DISPLAY_DATA lists, the user
 *   for a row added at the bottom, CommPassAdd :1957-1976), STK_DISPLAY Y, DATA_TRFR N and the flags N. Existing items
 *   and N rows are left as they are; then "Data Are Saved.". The save needs the edit right once a group is shown
 *   (DISPLAY_DATA sets EntryMode "E", :2648; the check is at :2668-2672).
 *
 * Deliberate differences, recorded on the gap: the creation runs in one transaction; a row whose code another group's
 * item already has is refused (the desktop sees only the group's items and inserts a second row with that code); a
 * product code typed into an added row must be in the product master; the web schema has no TAX_FREE_ITEM or
 * EMP_COM_PRC column, which the desktop writes N and 0.
 */
export class AutoItemError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'AutoItemValidationError';
  }
}

export interface AutoItemScope {
  tenantId: string;
  coCode: string;
}

/** The products DISPLAY_DATA leaves out of the list (MS_AUTO_ITEM.cs:2614). */
export const AUTO_ITEM_SKIPPED_PRODUCTS = [
  'HM',
  'DM',
  'OG',
  'OS',
  'SN',
  'FN',
  'RD',
  'EM',
  'OT',
] as const;

export interface AutoItemRow {
  prCode?: string;
  prName?: string;
  minStk?: number | string;
  /** The Y/N cell. */
  yn?: string;
  /** The row's hidden user cell: blank for a listed product, the user for a row added at the bottom. */
  added?: boolean;
}

export interface AutoItemInput {
  scope: AutoItemScope;
  user: string;
  grCode: string;
  grType?: string;
  tradeType?: string;
  hsnCode?: string;
  rows: AutoItemRow[];
}

const text = (value: unknown): string => String(value ?? '').trim();
/** MS_AUTO_ITEM_KeyPress upper-cases every key and drops the apostrophe (:2965-2978). */
const typed = (value: unknown): string => text(value).toUpperCase().replace(/'/g, '');

/** tGrCode_KeyDown: a group found by code, else the groups by name with type, trade type and HSN code. */
export async function autoItemGroups(prisma: any, scope: AutoItemScope, term: string, limit = 20) {
  const t = text(term);
  const rows: any[] = await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT "GR_CODE","GR_NAME","GR_TYPE","TRAD_TYPE","HSN_CODE" FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2
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
    hsn: text(r.HSN_CODE),
  }));
}

/** DISPLAY_DATA: the product grid for a group (blank group: every product marked N). */
export async function autoItemGrid(prisma: any, scope: AutoItemScope, grCodeRaw: string) {
  const grCode = typed(grCodeRaw);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const products: any[] = await tx.$queryRawUnsafe(
      `SELECT p."PR_CODE",p."PR_NAME",
              EXISTS (SELECT 1 FROM "ITEM_MAST" i WHERE i.tenant_id=p.tenant_id AND i."CO_CODE"=p."CO_CODE"
                        AND i."GR_CODE"=$3 AND i."PR_CODE"=p."PR_CODE") AS made
         FROM "PRODUCT_MAST" p
        WHERE p.tenant_id=$1 AND p."CO_CODE"=$2 AND NOT (coalesce(p."PR_CODE",'') = ANY($4::text[]))
        ORDER BY p."PR_CODE",p."PR_NAME",p.row_id`,
      scope.tenantId,
      scope.coCode,
      grCode,
      [...AUTO_ITEM_SKIPPED_PRODUCTS],
    );
    return {
      rows: products.map((p) => ({
        prCode: text(p.PR_CODE),
        prName: text(p.PR_NAME),
        yn: p.made ? 'Y' : 'N',
        made: Boolean(p.made),
      })),
    };
  });
}

export async function saveAutoItems(
  prisma: any,
  input: AutoItemInput,
): Promise<{ created: string[]; existing: string[] }> {
  const grCode = typed(input.grCode);
  const grType = typed(input.grType).slice(0, 1);
  const tradeType = typed(input.tradeType);
  const hsn = typed(input.hsnCode);
  if (tradeType.length > 2) throw new AutoItemError('trade type must be at most 2 characters');
  if (hsn.length > 10) throw new AutoItemError('HSN code must be at most 10 characters');
  const rows = (input.rows ?? []).map((row) => ({
    prCode: typed(row.prCode),
    prName: typed(row.prName),
    minStk: vbVal(row.minStk),
    yn: typed(row.yn),
    added: Boolean(row.added),
  }));
  for (const row of rows) {
    if (!row.prCode) continue;
    if (row.prCode.length > 2)
      throw new AutoItemError(`product code ${row.prCode} must be at most 2 characters`);
    if (row.prName.length > 50)
      throw new AutoItemError(`product name of ${row.prCode} must be at most 50 characters`);
  }
  // BtnSave_Click makes an item for a row with a product code and Y only (:2887).
  const wanted = rows.filter((row) => row.prCode && row.yn === 'Y');
  const created: string[] = [];
  const existing: string[] = [];
  if (!grCode || !wanted.length) return { created, existing };
  await withTxBudget(prisma, input.scope.tenantId, 'voucher', async (tx: any) => {
    const { tenantId, coCode } = input.scope;
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `item-master:${tenantId}:${coCode}`,
    );
    const [group] = await tx.$queryRawUnsafe(
      `SELECT 1 FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "GR_CODE"=$3 LIMIT 1`,
      tenantId,
      coCode,
      grCode,
    );
    if (!group) throw new AutoItemError(`group ${grCode} is not in the group master`);
    for (const row of wanted) {
      const code = `${row.prCode}${grCode}`;
      const [item] = await tx.$queryRawUnsafe(
        `SELECT "GR_CODE" FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE"=$3`,
        tenantId,
        coCode,
        code,
      );
      if (item && text(item.GR_CODE) === grCode) {
        existing.push(code);
        continue;
      }
      if (item)
        throw new AutoItemError(
          `item ${code} already exists in group ${text(item.GR_CODE)}; it is not made again for ${grCode}`,
        );
      if (row.added) {
        const [product] = await tx.$queryRawUnsafe(
          `SELECT 1 FROM "PRODUCT_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "PR_CODE"=$3 LIMIT 1`,
          tenantId,
          coCode,
          row.prCode,
        );
        if (!product) throw new AutoItemError(`product ${row.prCode} is not in the product master`);
      }
      await insertRowTx(tx, 'ITEM_MAST', tenantId, {
        CO_CODE: coCode,
        IT_CODE: code,
        IT_NAME: `${row.prName} ${grCode}`.slice(0, 50),
        IT_TYPE: grType,
        TAG_TYPE: grType,
        TRAD_TYPE: tradeType,
        PR_CODE: row.prCode,
        GR_CODE: grCode,
        SAFE_NAME: 'MAIN',
        HSN_CODE: hsn,
        UNIT_NAME: 'GMS',
        RATE_TYPE: 'G',
        MIN_STK: row.minStk,
        MAIN_USER: row.added ? input.user : '',
        STK_DISPLAY: 'Y',
        DATA_TRFR: 'N',
        TAG_IDTL_COL: 'N',
        OTH_DETL_POSTING: 'N',
        OTH_ITM_WT_REMOVE: 'N',
      });
      created.push(code);
    }
  });
  return { created, existing };
}
