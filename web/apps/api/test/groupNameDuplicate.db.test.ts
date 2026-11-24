import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import {
  createMaster,
  updateMaster,
  DuplicateKeyError,
} from '../src/modules/masters/master.service.js';
import { AC_GROUP_CONFIG, GROUP_MAST_CONFIG } from '../src/modules/masters/configs.js';

/**
 * A group name another code already uses is refused, with the desktop's words:
 *  - Item Group, MS_GROUP.cs:2029-2041 tGrName_Validating:
 *    "This Group Name already Exist in  '<code>'  Group Code... Please Change Group Name..."
 *  - Account Group, MS_AC_GROUP.cs:1695-1712 tGrName_Validating:
 *    "This Group Name already Exist in  '<code>'  Group Code...Please Change Gr Name..."
 * The check ignores the record's own code, so an edit that keeps its name still saves.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'group-name-duplicate';
const scope = { tenantId: TENANT, coCode: '07', lcCode: '01' };
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const clean = async (): Promise<void> => {
  for (const table of ['GROUP_MAST', 'AC_GROUP'])
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
};
const refusal = async (p: Promise<unknown>): Promise<string> =>
  p.then(
    () => 'accepted',
    (e) => (e instanceof DuplicateKeyError ? e.message : `other: ${String(e)}`),
  );
const names = async (table: string, col: string): Promise<string[]> =>
  (
    (await owner.$queryRawUnsafe(
      `SELECT "${col}" n FROM "${table}" WHERE tenant_id=$1 ORDER BY 1`,
      TENANT,
    )) as Array<{ n: string }>
  ).map((r) => r.n);

databaseDescribe('group name duplicate (tGrName_Validating)', () => {
  beforeEach(clean);
  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('refuses an item group name used by another code, on create and on edit, in the desktop words', async () => {
    await createMaster(runtime, scope, GROUP_MAST_CONFIG, {
      GR_CODE: 'G22',
      GR_NAME: 'GOLD 22K',
      GR_TYPE: 'G',
    });
    expect(
      await refusal(
        createMaster(runtime, scope, GROUP_MAST_CONFIG, {
          GR_CODE: 'G18',
          GR_NAME: 'gold 22k',
          GR_TYPE: 'G',
        }),
      ),
    ).toBe("This Group Name already Exist in  'G22'  Group Code... Please Change Group Name...");
    await createMaster(runtime, scope, GROUP_MAST_CONFIG, {
      GR_CODE: 'G18',
      GR_NAME: 'GOLD 18K',
      GR_TYPE: 'G',
    });
    expect(
      await refusal(
        updateMaster(runtime, scope, GROUP_MAST_CONFIG, { GR_CODE: 'G18', GR_NAME: 'GOLD 22K' }),
      ),
    ).toBe("This Group Name already Exist in  'G22'  Group Code... Please Change Group Name...");
    expect(await names('GROUP_MAST', 'GR_NAME')).toEqual(['GOLD 18K', 'GOLD 22K']);
  });

  it('a save of a name waits while another save of that name holds the lock', async () => {
    let release!: () => void;
    const held = new Promise<void>((r) => (release = r));
    let locked!: () => void;
    const isLocked = new Promise<void>((r) => (locked = r));
    const holder = owner.$transaction(
      async (tx: any) => {
        await tx.$executeRawUnsafe(
          'SELECT pg_advisory_xact_lock(hashtext($1))',
          `master-name:${TENANT}:GROUP_MAST:07:SAME NAME`,
        );
        locked();
        await held;
      },
      { timeout: 10_000 },
    );
    await isLocked;
    let settled = false;
    const save = createMaster(runtime, scope, GROUP_MAST_CONFIG, {
      GR_CODE: 'G1',
      GR_NAME: 'same name',
      GR_TYPE: 'G',
    }).finally(() => (settled = true));
    await new Promise((r) => setTimeout(r, 600));
    expect(settled).toBe(false);
    release();
    await holder;
    await save;
    expect(await names('GROUP_MAST', 'GR_NAME')).toEqual(['same name']);
  });

  it('lets a group keep its own name on edit', async () => {
    await createMaster(runtime, scope, GROUP_MAST_CONFIG, {
      GR_CODE: 'G22',
      GR_NAME: 'GOLD 22K',
      GR_TYPE: 'G',
    });
    await updateMaster(runtime, scope, GROUP_MAST_CONFIG, {
      GR_CODE: 'G22',
      GR_NAME: 'GOLD 22K',
      GR_TYPE: 'S',
    });
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "GR_TYPE" t FROM "GROUP_MAST" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ t: string }>;
    expect(rows.map((r) => r.t)).toEqual(['S']);
  });

  it('refuses an account group name used by another code, with the account group words', async () => {
    await createMaster(runtime, scope, AC_GROUP_CONFIG, { AC_GR: 'S1', AC_GR_NAME: 'SUNDRY' });
    expect(
      await refusal(
        createMaster(runtime, scope, AC_GROUP_CONFIG, { AC_GR: 'S2', AC_GR_NAME: 'SUNDRY' }),
      ),
    ).toBe("This Group Name already Exist in  'S1'  Group Code...Please Change Gr Name...");
    await updateMaster(runtime, scope, AC_GROUP_CONFIG, { AC_GR: 'S1', AC_GR_NAME: 'SUNDRY' });
    expect(await names('AC_GROUP', 'AC_GR_NAME')).toEqual(['SUNDRY']);
  });
});
