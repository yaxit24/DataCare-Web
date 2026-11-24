import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { applyRepair, previewRepair, repairHistory } from '../src/modules/utilities/dataRepair.js';
import '../src/modules/utilities/dataRepairOps.js';
import { seedPopulatedTenant, wipeTenants, WP24_CO, WP24_LC, WP24_YEAR } from './wp24FieldSeed.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;

/** Source oracle: MS_UPDATE.cs:7214 (AC_MAIN_GR from AC_GROUP) and :8608 (DEFAULTER_AC NULL -> N). */
db('WP-24 Field Update class-a repairs', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient();
  const tenantId = 'wp24-field-update';
  const other = 'wp24-field-other';
  const scope = { tenantId, coCode: WP24_CO, lcCode: WP24_LC, coYear: WP24_YEAR };

  const snapshot = (tenant: string) =>
    withTenant(runtime, tenant, async (tx: any) => {
      const names = (await tx.$queryRawUnsafe(
        `SELECT DISTINCT c.table_name FROM information_schema.columns c
           JOIN information_schema.tables t ON t.table_schema=c.table_schema AND t.table_name=c.table_name
          WHERE c.table_schema='public' AND c.column_name='tenant_id' AND t.table_type='BASE TABLE'
          ORDER BY c.table_name`,
      )) as Array<{ table_name: string }>;
      const out: Record<string, string[]> = {};
      for (const { table_name: table } of names)
        out[table] = (
          (await tx.$queryRawUnsafe(
            `SELECT to_jsonb(t)::text AS raw FROM "${table}" t WHERE tenant_id=$1 ORDER BY to_jsonb(t)::text`,
            tenant,
          )) as Array<{ raw: string }>
        ).map((r) => r.raw);
      return out;
    });

  beforeEach(async () => {
    await wipeTenants(owner, [tenantId, other]);
    await seedPopulatedTenant(runtime, tenantId);
    await seedPopulatedTenant(runtime, other);
  });
  afterAll(async () => {
    await wipeTenants(owner, [tenantId, other]);
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  const corrupt = (tenant: string) =>
    withTenant(runtime, tenant, async (tx: any) => {
      // 010001: stale main group; 010002: NULL defaulter and stale; a system account: NULL defaulter only.
      await tx.$executeRawUnsafe(
        `UPDATE "AC_MAST" SET "AC_MAIN_GR"='Z' WHERE tenant_id=$1 AND "AC_CODE"='010001'`,
        tenant,
      );
      await tx.$executeRawUnsafe(
        `UPDATE "AC_MAST" SET "AC_MAIN_GR"='Z',"DEFAULTER_AC"=NULL WHERE tenant_id=$1 AND "AC_CODE"='010002'`,
        tenant,
      );
      await tx.$executeRawUnsafe(
        `UPDATE "AC_MAST" SET "DEFAULTER_AC"=NULL WHERE tenant_id=$1 AND "AC_CODE"='CASH'`,
        tenant,
      );
    });

  it('a freshly web-seeded tenant needs no adjustment except the seeded NULL defaulters', async () => {
    const preview = await previewRepair(runtime, 'data-refresh-field-update', scope, 'admin');
    expect(preview.applyAvailable).toBe(true);
    expect(preview.completionText).toBe('Field Is Update ok....Please Re open Software');
    // Every diff is a defaulter NULL on a seeded account; no group drift exists.
    for (const s of preview.samples) expect(s).not.toContain('main group');
  });

  it('repairs NULL defaulters across locations without repairing other-location main groups', async () => {
    const first = await previewRepair(runtime, 'data-refresh-field-update', scope, 'admin');
    if (!first.clean)
      await applyRepair(runtime, 'data-refresh-field-update', scope, {
        previewHash: first.previewHash,
        operator: 'admin',
      });

    // unified/src/csharp/DataCareNext/MS_UPDATE.cs:8608 has no location filter for NULL defaulters;
    // :7214 limits main-group repairs to the session location (01).
    expect(scope.lcCode).toBe('01');
    await withTenant(runtime, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `UPDATE "AC_MAST" SET "LC_CODE"='02', "AC_MAIN_GR"='Z',
           "DEFAULTER_AC"=CASE WHEN "AC_CODE"='010001' THEN NULL ELSE 'Y' END
         WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE" IN ('010001','010002')`,
        tenantId,
        scope.coCode,
      );
    });
    const before = await snapshot(tenantId);
    const otherBefore = await snapshot(other);
    const preview = await previewRepair(runtime, 'data-refresh-field-update', scope, 'admin');
    expect(preview.diffs).toEqual([{ table: 'AC_MAST', insert: 0, update: 1, delete: 0 }]);
    expect(preview.samples).toEqual(['AC_MAST 010001: defaulter blank -> N']);
    expect(await snapshot(tenantId)).toEqual({ ...before, data_repair_run: expect.any(Array) });

    const applied = await applyRepair(runtime, 'data-refresh-field-update', scope, {
      previewHash: preview.previewHash,
      operator: 'admin',
    });
    expect(applied.applied).toEqual(preview.diffs);
    const after = await snapshot(tenantId);
    const expectedAccounts = before.AC_MAST!.map((raw) => {
      const row = JSON.parse(raw);
      if (row.CO_CODE === scope.coCode && row.AC_CODE === '010001') row.DEFAULTER_AC = 'N';
      return row;
    });
    expect(after.AC_MAST!.map((raw) => JSON.parse(raw))).toEqual(expectedAccounts);
    for (const table of Object.keys(before)) {
      if (table !== 'AC_MAST' && table !== 'data_repair_run')
        expect(after[table], `unexpected write in ${table}`).toEqual(before[table]);
    }
    expect(await snapshot(other)).toEqual(otherBefore);
    expect((await previewRepair(runtime, 'data-refresh-field-update', scope, 'admin')).clean).toBe(
      true,
    );
  });

  it('previews, applies once in one transaction with an audit row, touches only intended rows', async () => {
    // Bring the tenant to the clean baseline first so the corruption is the only difference.
    const first = await previewRepair(runtime, 'data-refresh-field-update', scope, 'admin');
    if (!first.clean)
      await applyRepair(runtime, 'data-refresh-field-update', scope, {
        previewHash: first.previewHash,
        operator: 'admin',
      });
    await corrupt(tenantId);
    await corrupt(other);
    const before = await snapshot(tenantId);
    const otherBefore = await snapshot(other);

    const preview = await previewRepair(runtime, 'data-refresh-field-update', scope, 'admin');
    expect(preview.diffs).toEqual([{ table: 'AC_MAST', insert: 0, update: 3, delete: 0 }]);
    expect([...preview.samples].sort()).toEqual([
      'AC_MAST 010001: main group Z -> A',
      'AC_MAST 010002: main group Z -> L; defaulter blank -> N',
      'AC_MAST CASH: defaulter blank -> N',
    ]);
    expect(await snapshot(tenantId)).toEqual({
      ...before,
      data_repair_run: expect.any(Array),
    });

    const applied = await applyRepair(runtime, 'data-refresh-field-update', scope, {
      previewHash: preview.previewHash,
      operator: 'admin',
    });
    expect(applied.deduplicated).toBe(false);
    expect(applied.applied).toEqual(preview.diffs);

    const after = await snapshot(tenantId);
    for (const table of Object.keys(before)) {
      if (table !== 'AC_MAST' && table !== 'data_repair_run')
        expect(after[table], `unexpected write in ${table}`).toEqual(before[table]);
    }
    // Full row diff of AC_MAST: only AC_MAIN_GR / DEFAULTER_AC of the three corrupted rows differ.
    const key = (raw: string) => JSON.parse(raw);
    const changed = after.AC_MAST!.filter((r) => !before.AC_MAST!.includes(r)).map(key);
    expect(changed.map((r) => r.AC_CODE).sort()).toEqual(['010001', '010002', 'CASH']);
    const byCode = Object.fromEntries(changed.map((r) => [r.AC_CODE, r]));
    expect([byCode['010001'].AC_MAIN_GR, byCode['010002'].AC_MAIN_GR]).toEqual(['A', 'L']);
    expect([byCode['010002'].DEFAULTER_AC, byCode.CASH.DEFAULTER_AC]).toEqual(['N', 'N']);
    expect(after.AC_MAST).toHaveLength(before.AC_MAST!.length);
    expect(await snapshot(other)).toEqual(otherBefore);

    const history = await repairHistory(runtime, { tenantId, coCode: WP24_CO });
    // One apply for the seeded NULL defaulters (baseline) and one for the corruption.
    expect(history.filter((r) => r.state === 'applied')).toHaveLength(2);

    // Idempotent: second preview is clean, replaying the hash resolves to the audited run.
    const again = await previewRepair(runtime, 'data-refresh-field-update', scope, 'admin');
    expect(again.clean).toBe(true);
    const replay = await applyRepair(runtime, 'data-refresh-field-update', scope, {
      previewHash: preview.previewHash,
      operator: 'admin',
    });
    expect(replay.deduplicated).toBe(true);
  });
});
