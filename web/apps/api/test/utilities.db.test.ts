import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteHddRegistry,
  getHddRegistry,
  listHddRegistry,
  saveHddRegistry,
} from '../src/modules/utilities/hddRegistry.js';
import {
  deleteUserRequest,
  getUserRequest,
  listUserRequests,
  saveUserRequest,
  UserRequestValidationError,
} from '../src/modules/utilities/userRequest.js';
import {
  getWindowTile,
  listWindowTiles,
  WindowTileValidationError,
} from '../src/modules/utilities/windowTiles.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'utilities-db';
const OTHER_TENANT = 'utilities-other';
const CO = '01';
const OTHER_CO = '02';
const LC = '01';
const YEAR = '2024-2025';
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR };
const otherScope = { tenantId: OTHER_TENANT, coCode: CO, lcCode: LC, coYear: YEAR };

// Restricted-role integration style: owner only seeds/inspects/cleans; every service call uses
// DATABASE_URL (app_user), proving RLS-compatible writes rather than owner-bypass behavior.
databaseDescribe('database-backed desktop utilities', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const table of [
      'USER_REQUEST',
      'USER_SET',
      'TILE_DATA',
      'HDD_MAST',
      'MAIN_STOCK',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'AC_MAST',
    ]) {
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
        TENANT,
        OTHER_TENANT,
      );
    }
  };

  const seed = async () => {
    for (const tenant of [TENANT, OTHER_TENANT]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
         VALUES ($1,$2,$3,'00010',$4)`,
        tenant,
        CO,
        LC,
        tenant === TENANT ? 'Scoped Account' : 'Other Account',
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(
           tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","MAIN_USER")
         VALUES ($1,$2,$3,$4,'SAL','00000001','2024-04-10','00010',$5)`,
        tenant,
        CO,
        LC,
        YEAR,
        tenant === TENANT ? 'owner-user' : 'other-owner',
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "TILE_DATA"(
           tenant_id,"SM_MAIN_NAME","SR_NO","DISPLAY_NAME","SHORT_NAME","TILE_NAME","ITM_SHOW")
         VALUES ($1,'Sales Invoice','01',$2,'Sale','tile1','Y')`,
        tenant,
        tenant === TENANT ? 'Scoped Sale' : 'Other Sale',
      );
      await owner.$executeRawUnsafe(
        `INSERT INTO "USER_SET"(
           tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_PRINT")
         VALUES ($1,$2,$3,'requester','Sales','Sales Invoice','Y',$4)`,
        tenant,
        CO,
        LC,
        tenant === TENANT ? 'N' : 'Y',
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","MAIN_USER")
       VALUES ($1,$2,$3,$4,'PUR','00000002','2024-04-11','00010','stock-owner')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TILE_DATA"(
         tenant_id,"SM_MAIN_NAME","SR_NO","DISPLAY_NAME","SHORT_NAME","TILE_NAME","ITM_SHOW")
       VALUES ($1,'Purchase Invoice','02','Scoped Purchase','Purchase','tile2','N')`,
      TENANT,
    );
    // Same user/right in another company must not grant access in the active company.
    await owner.$executeRawUnsafe(
      `INSERT INTO "USER_SET"(
         tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_PRINT")
       VALUES ($1,$2,$3,'requester','Purchase','Purchase Invoice','Y','Y')`,
      TENANT,
      OTHER_CO,
      LC,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('creates, updates, lists, gets and deletes only tenant-scoped HDD REF_NO', async () => {
    await saveHddRegistry(runtime, otherScope, 'OTHER00001');
    expect(await saveHddRegistry(runtime, scope, 'HDD0000001')).toEqual({
      refNo: 'HDD0000001',
      message: 'Hdd Is Update...',
    });
    expect(await listHddRegistry(runtime, scope)).toEqual([
      expect.objectContaining({ refNo: 'HDD0000001' }),
    ]);
    expect(await getHddRegistry(runtime, scope, 'HDD0000001')).toEqual(
      expect.objectContaining({ refNo: 'HDD0000001' }),
    );

    await saveHddRegistry(runtime, scope, 'HDD0000002');
    const persisted = (await owner.$queryRawUnsafe(
      `SELECT tenant_id,"REF_NO" FROM "HDD_MAST"
       WHERE tenant_id IN ($1,$2) ORDER BY tenant_id`,
      TENANT,
      OTHER_TENANT,
    )) as Array<{ tenant_id: string; REF_NO: string }>;
    expect(persisted).toEqual([
      { tenant_id: TENANT, REF_NO: 'HDD0000002' },
      { tenant_id: OTHER_TENANT, REF_NO: 'OTHER00001' },
    ]);

    expect(await deleteHddRegistry(runtime, scope, 'HDD0000002')).toEqual({ deleted: 1 });
    expect(await listHddRegistry(runtime, scope)).toEqual([]);
    expect(await listHddRegistry(runtime, otherScope)).toEqual([
      expect.objectContaining({ refNo: 'OTHER00001' }),
    ]);
    // Desktop has no empty REF_NO validation; do not invent one.
    await expect(saveHddRegistry(runtime, scope, '')).resolves.toMatchObject({ refNo: '' });
    await expect(saveHddRegistry(runtime, scope, 'ELEVEN-CHARS')).rejects.toThrow(
      'REF_NO must be at most 10 characters',
    );
  });

  it('persists all desktop USER_REQUEST columns from AC_DATA and supports scoped lifecycle', async () => {
    await saveUserRequest(runtime, {
      scope: otherScope,
      coBook: 'SAL',
      vchNo: '00000001',
      acCode: '00010',
      editUser: 'requester',
      remark: 'Other tenant reason',
      requestType: 'E',
    });
    expect(
      await saveUserRequest(runtime, {
        scope,
        coBook: 'SAL',
        vchNo: '00000001',
        acCode: '00010',
        editUser: 'requester',
        remark: 'Need edit permission',
        requestType: 'E',
      }),
    ).toEqual({ saved: true, message: 'Request Sent Successfully...' });

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT "CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE"::text,
              "AC_CODE","AC_NAME","TOT_AMT"::float,"TOT_FINE"::float,"ITM_TYPE","EMP_CODE",
              "USER_NAME","EDIT_USER","EDIT_RMARK","REQ_TIME","REQ_TYPE","PARMATION_TYPE"
         FROM "USER_REQUEST" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(persisted).toHaveLength(1);
    expect(persisted[0]).toMatchObject({
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: 'SAL',
      VCH_NO: '00000001',
      VCH_DATE: '2024-04-10',
      AC_CODE: '00010',
      AC_NAME: 'Scoped Account',
      TOT_AMT: 0,
      TOT_FINE: 0,
      ITM_TYPE: '',
      EMP_CODE: '',
      USER_NAME: 'owner-user',
      EDIT_USER: 'requester',
      EDIT_RMARK: 'Need edit permission',
      REQ_TYPE: 'E',
      PARMATION_TYPE: 'P',
    });
    expect(persisted[0]!.REQ_TIME).toBeInstanceOf(Date);
    expect(await listUserRequests(runtime, scope)).toEqual([
      expect.objectContaining({
        coBook: 'SAL',
        vchNo: '00000001',
        acName: 'Scoped Account',
        remark: 'Need edit permission',
        userName: 'owner-user',
      }),
    ]);
    expect(await getUserRequest(runtime, scope, 'SAL', '00000001')).toMatchObject({
      requestType: 'E',
      permissionType: 'P',
    });

    await saveUserRequest(runtime, {
      scope,
      coBook: 'SAL',
      vchNo: '00000001',
      acCode: '00010',
      editUser: 'requester',
      remark: 'Need delete permission',
      requestType: 'D',
    });
    expect(await getUserRequest(runtime, scope, 'SAL', '00000001')).toMatchObject({
      remark: 'Need delete permission',
      requestType: 'D',
      editUser: 'requester',
    });
    expect(await listUserRequests(runtime, otherScope)).toEqual([
      expect.objectContaining({ remark: 'Other tenant reason' }),
    ]);

    expect(await deleteUserRequest(runtime, scope, 'SAL', '00000001')).toEqual({ deleted: 1 });
    expect(await getUserRequest(runtime, scope, 'SAL', '00000001')).toBeNull();
    expect(await getUserRequest(runtime, otherScope, 'SAL', '00000001')).not.toBeNull();
  });

  it('derives USER_REQUEST from MAIN_STOCK and rejects desktop-invalid input exactly', async () => {
    await saveUserRequest(runtime, {
      scope,
      coBook: 'PUR',
      vchNo: '00000002',
      acCode: '00010',
      editUser: 'requester',
      remark: 'Stock request',
      requestType: 'E',
    });
    expect(await getUserRequest(runtime, scope, 'PUR', '00000002')).toMatchObject({
      vchDate: '2024-04-11',
      acName: 'Scoped Account',
      userName: 'stock-owner',
    });
    await expect(
      saveUserRequest(runtime, {
        scope,
        coBook: 'SAL',
        vchNo: '00000001',
        acCode: '00010',
        editUser: 'requester',
        remark: '',
        requestType: 'E',
      }),
    ).rejects.toEqual(
      expect.objectContaining({
        name: 'UserRequestValidationError',
        message: 'Please Insert Reseon For Edit Or Delete in Remarks...',
      }),
    );
    await expect(
      saveUserRequest(runtime, {
        scope,
        coBook: 'SAL',
        vchNo: '00000001',
        acCode: '00010',
        editUser: 'requester',
        remark: 'Reason',
        requestType: 'X' as 'E',
      }),
    ).rejects.toBeInstanceOf(UserRequestValidationError);
  });

  it('lists/gets tenant tiles, returns all desktop columns, and applies scoped USER_SET rights', async () => {
    expect(await listWindowTiles(runtime, scope, 'requester')).toEqual([
      {
        menuName: 'Sales Invoice',
        sequence: '01',
        displayName: 'Scoped Sale',
        shortName: 'Sale',
        tileName: 'tile1',
        itemShow: 'Y',
        canView: true,
        canPrint: false,
      },
      {
        menuName: 'Purchase Invoice',
        sequence: '02',
        displayName: 'Scoped Purchase',
        shortName: 'Purchase',
        tileName: 'tile2',
        itemShow: 'N',
        canView: false,
        canPrint: false,
      },
    ]);
    expect(await getWindowTile(runtime, scope, 'requester', 'tile1')).toMatchObject({
      displayName: 'Scoped Sale',
      canView: true,
    });
    expect(await listWindowTiles(runtime, otherScope, 'requester')).toEqual([
      expect.objectContaining({ displayName: 'Other Sale', canPrint: true }),
    ]);
    await expect(getWindowTile(runtime, scope, 'requester', 'tile2')).rejects.toEqual(
      expect.objectContaining({
        name: 'WindowTileValidationError',
        message: 'You Have No Rights.....',
      }),
    );
    await expect(getWindowTile(runtime, scope, 'requester', 'tile99')).rejects.toEqual(
      expect.objectContaining({
        name: 'WindowTileValidationError',
        message: 'No Menu Found.....',
      }),
    );
    expect(new WindowTileValidationError('x')).toBeInstanceOf(Error);

    const count = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "TILE_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(count[0]!.n).toBe(2); // UT_WINDOW is intentionally read-only: no source-proven writer.
  });
});
