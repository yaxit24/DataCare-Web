import { insertRowTx } from '../posting/posting.js';
import { withTxBudget } from '../shared/txBudget.js';
import type { UtilityScope } from './hddRegistry.js';

export interface WindowTile {
  menuName: string;
  sequence: string;
  displayName: string;
  shortName: string;
  tileName: string;
  itemShow: string;
  canView: boolean;
  canPrint: boolean;
}

export class WindowTileValidationError extends Error {
  override name = 'WindowTileValidationError';
}

const rowOf = (row: any): WindowTile => ({
  menuName: String(row.menuName ?? ''),
  sequence: String(row.sequence ?? ''),
  displayName: String(row.displayName ?? ''),
  shortName: String(row.shortName ?? ''),
  tileName: String(row.tileName ?? ''),
  itemShow: String(row.itemShow ?? ''),
  canView: row.canView === true,
  canPrint: row.canPrint === true,
});

export async function listWindowTiles(
  prisma: any,
  scope: UtilityScope,
  loginName: string,
): Promise<WindowTile[]> {
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    // UT_WINDOW selects TILE_DATA * (UT_WINDOW.cs:1253-1254) and consumes TILE_NAME,
    // DISPLAY_NAME and SM_MAIN_NAME for tile1..tile12 (UT_WINDOW.cs:1255-1326). The remaining
    // selected columns SR_NO, SHORT_NAME and ITM_SHOW are returned too. TILE_DATA has no company or
    // location columns, so tenant RLS is its maximum scope.
    // On activation desktop selects USER_SET * for current MCo_User + tile SUB_MENU + FRM_VIEW='Y'
    // (UT_WINDOW.cs:1434-1439). Web additionally constrains those rights to active company/location.
    const rows = await tx.$queryRawUnsafe(
      `SELECT t."SM_MAIN_NAME" AS "menuName",t."SR_NO" AS sequence,
              t."DISPLAY_NAME" AS "displayName",t."SHORT_NAME" AS "shortName",
              t."TILE_NAME" AS "tileName",t."ITM_SHOW" AS "itemShow",
              EXISTS(SELECT 1 FROM "USER_SET" u WHERE u.tenant_id=$1 AND u."CO_CODE"=$2
                AND u."LC_CODE"=$3 AND u."USER_NAME"=$4 AND u."SUB_MENU"=t."SM_MAIN_NAME"
                AND u."FRM_VIEW"='Y') AS "canView",
              EXISTS(SELECT 1 FROM "USER_SET" u WHERE u.tenant_id=$1 AND u."CO_CODE"=$2
                AND u."LC_CODE"=$3 AND u."USER_NAME"=$4 AND u."SUB_MENU"=t."SM_MAIN_NAME"
                AND u."FRM_PRINT"='Y') AS "canPrint"
         FROM "TILE_DATA" t WHERE t.tenant_id=$1
        ORDER BY NULLIF(t."SR_NO",'')::int NULLS LAST,t."TILE_NAME",t."SM_MAIN_NAME"`,
      scope.tenantId,
      scope.coCode,
      scope.lcCode,
      loginName,
    );
    return rows.map(rowOf);
  });
}

export async function getWindowTile(
  prisma: any,
  scope: UtilityScope,
  loginName: string,
  tileName: string,
): Promise<WindowTile> {
  const tile = (await listWindowTiles(prisma, scope, loginName)).find(
    (candidate) => candidate.tileName === tileName,
  );
  // Exact desktop fallback when a selected tag has no handled menu (UT_WINDOW.cs:2553).
  if (!tile) throw new WindowTileValidationError('No Menu Found.....');
  // Exact desktop message when current user lacks USER_SET.FRM_VIEW=Y (UT_WINDOW.cs:1434-1439).
  if (!tile.canView) throw new WindowTileValidationError('You Have No Rights.....');
  return tile;
}

/**
 * TILE_DATA writers.
 *
 * CORRECTION to an earlier note in this file, which said no writer was source-proven. That was true of
 * `UT_WINDOW` — it only ever selects — but the search was scoped to that one form. Two other forms do
 * write the table:
 *
 *   • `MS_USER.cs` seeds rows:
 *       `INSERT INTO TILE_DATA(SM_MAIN_NAME,SR_NO,DISPLAY_NAME,SHORT_NAME,TILE_NAME,ITM_SHOW) VALUES(…)`
 *     and later `UPDATE TILE_DATA SET SHORT_NAME = …`
 *   • `MS_WINDOW_SET.cs` reassigns the owning menu: `UPDATE TILE_DATA SET SM_MAIN_NAME = …`
 *
 * The table has no company or location column — it is tenant-global dashboard configuration, keyed by
 * `TILE_NAME`, which is why these operations take no scope beyond the tenant.
 */
export interface WindowTileInput {
  /** `TILE_NAME` — the key. */
  tileName: string;
  /** `SM_MAIN_NAME` — the owning main menu, reassignable by MS_WINDOW_SET. */
  mainName?: string;
  /** `SR_NO` — display order, a two-character string in the desktop ('00', '01', …). */
  srNo?: string | number;
  displayName?: string;
  shortName?: string;
  /** `ITM_SHOW` — 'Y' shows the tile. */
  show?: string;
}

const tileText = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;

/** `SR_NO` is varchar(2) and the desktop writes it zero-padded ('00'), so a number must be formatted. */
const tileSrNo = (v: unknown): string | null => {
  if (v == null || v === '') return null;
  const text = typeof v === 'number' ? String(v) : String(v).trim();
  return text.padStart(2, '0').slice(0, 2);
};

/**
 * Upsert one tile, keyed by `TILE_NAME`. Mirrors the desktop's seed-then-update pattern in a single
 * operation: `MS_USER` inserts a missing tile and updates an existing one's short name, while
 * `MS_WINDOW_SET` updates which main menu owns it.
 */
export async function saveWindowTile(
  prisma: any,
  tenantId: string,
  input: WindowTileInput,
): Promise<{ saved: true }> {
  const tileName = String(input.tileName ?? '').trim();
  if (!tileName) throw new Error('saveWindowTile: tileName is required');
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const existing: Array<{ n: number }> = await tx.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "TILE_DATA" WHERE "TILE_NAME"=$1`,
      tileName.slice(0, 10),
    );
    if (Number(existing[0]?.n ?? 0) > 0) {
      await tx.$executeRawUnsafe(
        `UPDATE "TILE_DATA"
            SET "SM_MAIN_NAME"=coalesce($2,"SM_MAIN_NAME"),
                "SR_NO"=coalesce($3,"SR_NO"),
                "DISPLAY_NAME"=coalesce($4,"DISPLAY_NAME"),
                "SHORT_NAME"=coalesce($5,"SHORT_NAME"),
                "ITM_SHOW"=coalesce($6,"ITM_SHOW")
          WHERE "TILE_NAME"=$1`,
        tileName.slice(0, 10),
        tileText(input.mainName, 25),
        tileSrNo(input.srNo),
        tileText(input.displayName, 25),
        tileText(input.shortName, 25),
        tileText(input.show, 1),
      );
      return { saved: true as const };
    }
    await insertRowTx(tx, 'TILE_DATA', tenantId, {
      SM_MAIN_NAME: tileText(input.mainName, 25),
      SR_NO: tileSrNo(input.srNo),
      DISPLAY_NAME: tileText(input.displayName, 25),
      SHORT_NAME: tileText(input.shortName, 25),
      TILE_NAME: tileName.slice(0, 10),
      ITM_SHOW: tileText(input.show, 1) ?? 'Y',
    });
    return { saved: true as const };
  });
}
