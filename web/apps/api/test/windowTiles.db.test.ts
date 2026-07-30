import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { listWindowTiles, saveWindowTile } from '../src/modules/utilities/windowTiles.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * TILE_DATA writes. This table was previously listed as never written on the basis that `UT_WINDOW` only
 * selects from it — true of that form, but the search was too narrow: `MS_USER` seeds and renames tiles
 * and `MS_WINDOW_SET` reassigns the owning menu.
 */
d('window tile configuration', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const TENANT = 'window-tiles-db';

  const clean = async (): Promise<void> => {
    await owner.$executeRawUnsafe(`DELETE FROM "TILE_DATA" WHERE tenant_id=$1`, TENANT);
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
    await clean();
  });
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('seeds a tile with every desktop column', async () => {
    // MS_USER.cs: INSERT INTO TILE_DATA(SM_MAIN_NAME,SR_NO,DISPLAY_NAME,SHORT_NAME,TILE_NAME,ITM_SHOW)
    await saveWindowTile(runtime, TENANT, {
      tileName: 'OPNFRM',
      mainName: 'Opning Form',
      srNo: 0,
      displayName: 'Opning',
      shortName: 'Opn',
      show: 'Y',
    });
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "SM_MAIN_NAME","SR_NO","DISPLAY_NAME","SHORT_NAME","TILE_NAME","ITM_SHOW"
         FROM "TILE_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    const row = rows[0]!;
    expect(String(row.SM_MAIN_NAME).trim()).toBe('Opning Form');
    // SR_NO is varchar(2) and the desktop writes it zero-padded.
    expect(String(row.SR_NO)).toBe('00');
    expect(String(row.DISPLAY_NAME).trim()).toBe('Opning');
    expect(String(row.SHORT_NAME).trim()).toBe('Opn');
    expect(String(row.TILE_NAME).trim()).toBe('OPNFRM');
    expect(String(row.ITM_SHOW).trim()).toBe('Y');
  }, 30_000);

  it('updates the short name in place, as MS_USER does, without adding a row', async () => {
    await saveWindowTile(runtime, TENANT, { tileName: 'OPNFRM', shortName: 'Open' });
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "SHORT_NAME","SM_MAIN_NAME" FROM "TILE_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(rows).toHaveLength(1);
    expect(String(rows[0]!.SHORT_NAME).trim()).toBe('Open');
    // Fields not supplied must keep their previous value rather than being blanked.
    expect(String(rows[0]!.SM_MAIN_NAME).trim()).toBe('Opning Form');
  }, 30_000);

  it('reassigns the owning main menu, as MS_WINDOW_SET does', async () => {
    await saveWindowTile(runtime, TENANT, { tileName: 'OPNFRM', mainName: 'Transactions' });
    const rows: any[] = await owner.$queryRawUnsafe(
      `SELECT "SM_MAIN_NAME","SHORT_NAME" FROM "TILE_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(String(rows[0]!.SM_MAIN_NAME).trim()).toBe('Transactions');
    expect(String(rows[0]!.SHORT_NAME).trim()).toBe('Open');
  }, 30_000);

  it('is visible through the read path the dashboard uses', async () => {
    const tiles = await listWindowTiles(runtime, { tenantId: TENANT } as never);
    expect(Array.isArray(tiles)).toBe(true);
    expect(tiles.length).toBeGreaterThan(0);
  }, 30_000);

  it('requires a tile name', async () => {
    await expect(saveWindowTile(runtime, TENANT, { tileName: '  ' })).rejects.toThrow(/tileName/);
  });
});
