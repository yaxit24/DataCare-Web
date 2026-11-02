import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { applyRepair, previewRepair, repairHistory } from '../src/modules/utilities/dataRepair.js';
import '../src/modules/utilities/dataRepairOps.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;

/** Source oracle: MS_UPDATE.cs:8815-8820. */
db('Data Refresh Approval Adj write set', () => {
  const prisma = new PrismaClient();
  const tenantId = 'refresh-approval';
  const otherTenant = 'refresh-approval-2';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025' };
  const tables = ['APR_DETL', 'SL_DETL', 'RATE_CUT_ISU', 'BAR_DETL', 'data_repair_run'];

  const wipe = async () => {
    for (const tenant of [tenantId, otherTenant]) {
      await withTenant(prisma, tenant, async (tx: any) => {
        await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
        for (const table of tables)
          await tx.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
      });
    }
  };

  const issue = async (
    tx: any,
    tenant: string,
    index: number,
    isuRec: string,
    overrides: { co?: string; lc?: string; year?: string; tag?: string } = {},
  ) =>
    tx.$executeRawUnsafe(
      `INSERT INTO "APR_DETL"
        (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "BOOK_NAME","TAG_NO","VCH_SRNO","ISU_REC")
       VALUES ($1,$2,$3,$4,'AIS',$5,1,$6,'APR ISU',$7,$8,$9)`,
      tenant,
      overrides.co ?? '01',
      overrides.lc ?? '01',
      overrides.year ?? '2024-2025',
      `I${index}`,
      index,
      overrides.tag ?? `TAG${index}`,
      100 + index,
      isuRec,
    );

  const reference = async (
    tx: any,
    table: 'APR_DETL' | 'SL_DETL' | 'RATE_CUT_ISU',
    bookName: string,
    index: number,
    overrides: { lc?: string; isuNo?: string } = {},
  ) =>
    tx.$executeRawUnsafe(
      `INSERT INTO "${table}"
        (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME",
         "ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO")
       VALUES ($1,'01',$2,'2024-2025','REF',$3,1,$4,'2024-2025','AIS',$5,$6)`,
      tenantId,
      overrides.lc ?? '01',
      `R${index}`,
      bookName,
      overrides.isuNo ?? `I${index}`,
      index,
    );

  const bar = async (
    tx: any,
    tenant: string,
    index: number,
    aprIsu: string,
    overrides: { co?: string; lc?: string; year?: string; tag?: string } = {},
  ) =>
    tx.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"
        (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME",
         "TAG_NO","VCH_SRNO","IT_CODE","APR_ISU")
       VALUES ($1,$2,$3,$4,'TAG','B1',1,'TAG OPENING',$5,$6,'GOLD',$7)`,
      tenant,
      overrides.co ?? '01',
      overrides.lc ?? '01',
      overrides.year ?? '2024-2025',
      overrides.tag ?? `TAG${index}`,
      100 + index,
      aprIsu,
    );

  const seed = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      // Four consumed issues start N; the unconsumed issue starts Y. Every value is the opposite oracle.
      for (let index = 1; index <= 5; index++)
        await issue(tx, tenantId, index, index < 5 ? 'N' : 'Y');
      for (let index = 1; index <= 5; index++)
        await bar(tx, tenantId, index, index < 5 ? 'Y' : 'N');
      await reference(tx, 'APR_DETL', 'APR RTN', 1);
      await reference(tx, 'SL_DETL', 'SALES', 2);
      await reference(tx, 'RATE_CUT_ISU', 'WH SALES', 3);
      await reference(tx, 'RATE_CUT_ISU', 'RATE CUT', 4);
      // Distractors must not consume TAG5.
      await reference(tx, 'SL_DETL', 'QUOTATION', 5);
      await reference(tx, 'SL_DETL', 'SALES', 5, { lc: '02' });
      await reference(tx, 'APR_DETL', 'APR RTN', 5, { isuNo: '' });
      // Same visible keys outside the selected location/year/company and tenant must remain byte-for-byte.
      await issue(tx, tenantId, 8, 'N', { lc: '02', tag: 'WRONG-LC' });
      await bar(tx, tenantId, 8, 'Y', { lc: '02', tag: 'WRONG-LC' });
      await issue(tx, tenantId, 9, 'N', { year: '2023-2024', tag: 'WRONG-YR' });
      await bar(tx, tenantId, 9, 'Y', { year: '2023-2024', tag: 'WRONG-YR' });
      await issue(tx, tenantId, 10, 'N', { co: '02', tag: 'WRONG-CO' });
      await bar(tx, tenantId, 10, 'Y', { co: '02', tag: 'WRONG-CO' });
    });

  const seedOther = () =>
    withTenant(prisma, otherTenant, async (tx: any) => {
      await issue(tx, otherTenant, 1, 'N');
      await bar(tx, otherTenant, 1, 'Y');
    });

  const physical = async (tenant = tenantId) => {
    const result: Record<string, Array<{ raw: string; revision: string }>> = {};
    for (const table of ['APR_DETL', 'SL_DETL', 'RATE_CUT_ISU', 'BAR_DETL']) {
      result[table] = await prisma.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text AS raw,xmin::text AS revision FROM "${table}" t
          WHERE tenant_id=$1 ORDER BY row_id`,
        tenant,
      );
    }
    return result;
  };

  beforeEach(wipe);
  afterAll(async () => {
    await wipe();
    await prisma.$disconnect();
  });

  it('applies the five-issue oracle, preserves every other byte, audits, and deduplicates replay', async () => {
    await seed();
    await seedOther();
    const before = await physical();
    const otherBefore = await physical(otherTenant);

    const preview = await previewRepair(prisma, 'approval-reconcile', scope, 'admin');
    expect(preview.applyAvailable).toBe(true);
    expect(preview.completionText).toBe('Approval Refersh Process Complete.');
    expect(preview.diffs).toEqual([
      { table: 'APR_DETL', insert: 0, update: 5, delete: 0 },
      { table: 'BAR_DETL', insert: 0, update: 5, delete: 0 },
    ]);

    const applied = await applyRepair(prisma, 'approval-reconcile', scope, {
      previewHash: preview.previewHash,
      operator: 'admin',
    });
    expect(applied.deduplicated).toBe(false);
    expect(applied.applied).toEqual(preview.diffs);

    const oracle = await withTenant(prisma, tenantId, async (tx: any) => ({
      issue: await tx.$queryRawUnsafe(
        `SELECT "TAG_NO" tag,"ISU_REC" flag FROM "APR_DETL"
          WHERE tenant_id=$1 AND "BOOK_NAME"='APR ISU' ORDER BY row_id`,
        tenantId,
      ),
      bar: await tx.$queryRawUnsafe(
        `SELECT "TAG_NO" tag,"APR_ISU" flag FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY row_id`,
        tenantId,
      ),
    }));
    expect(oracle.issue.slice(0, 5).map((row: any) => row.flag)).toEqual(['Y', 'Y', 'Y', 'Y', 'N']);
    expect(oracle.bar.slice(0, 5).map((row: any) => row.flag)).toEqual(['N', 'N', 'N', 'N', 'Y']);
    expect(oracle.issue.slice(5).map((row: any) => row.flag)).toEqual(['N', 'N', 'N']);
    expect(oracle.bar.slice(5).map((row: any) => row.flag)).toEqual(['Y', 'Y', 'Y']);

    const after = await physical();
    const changedKeys = (beforeRaw: string, afterRaw: string) => {
      const beforeRow = JSON.parse(beforeRaw);
      const afterRow = JSON.parse(afterRaw);
      return Object.keys(afterRow).filter(
        (key) => JSON.stringify(afterRow[key]) !== JSON.stringify(beforeRow[key]),
      );
    };
    for (let index = 0; index < 5; index++) {
      expect(changedKeys(before.APR_DETL[index]!.raw, after.APR_DETL[index]!.raw)).toEqual([
        'ISU_REC',
      ]);
      expect(changedKeys(before.BAR_DETL[index]!.raw, after.BAR_DETL[index]!.raw)).toEqual([
        'APR_ISU',
      ]);
    }
    expect(after.SL_DETL).toEqual(before.SL_DETL);
    expect(after.RATE_CUT_ISU).toEqual(before.RATE_CUT_ISU);
    expect(await physical(otherTenant)).toEqual(otherBefore);
    // Complete row JSON changes only where the source authorizes; unchanged-scope rows retain xmin too.
    expect(after.APR_DETL.slice(5)).toEqual(before.APR_DETL.slice(5));
    expect(after.BAR_DETL.slice(5)).toEqual(before.BAR_DETL.slice(5));

    const history = await repairHistory(prisma, { tenantId, coCode: '01' });
    expect(history.filter((row) => row.state === 'applied')).toHaveLength(1);
    const clean = await previewRepair(prisma, 'approval-reconcile', scope, 'admin');
    expect(clean.clean).toBe(true);
    expect(clean.diffs).toEqual([]);
    const replay = await applyRepair(prisma, 'approval-reconcile', scope, {
      previewHash: preview.previewHash,
      operator: 'admin',
    });
    expect(replay.deduplicated).toBe(true);
    expect(replay.applied).toEqual(applied.applied);
  });

  it('rolls back APR_DETL when a fault is injected at the APR_DETL to BAR_DETL boundary', async () => {
    await seed();
    const preview = await previewRepair(prisma, 'approval-reconcile', scope, 'admin');
    const before = await physical();
    const historyBefore = await repairHistory(prisma, { tenantId, coCode: '01' });
    const faultPrisma = new Proxy(prisma as any, {
      get(target, property) {
        if (property !== '$transaction') return Reflect.get(target, property, target);
        return (callback: (tx: any) => unknown, options: unknown) =>
          target.$transaction(
            (tx: any) =>
              callback(
                new Proxy(tx, {
                  get(transaction, member) {
                    if (member !== '$executeRawUnsafe')
                      return Reflect.get(transaction, member, transaction);
                    return (sql: string, ...params: unknown[]) => {
                      if (sql.includes('UPDATE "BAR_DETL" b SET "APR_ISU"'))
                        throw new Error('injected APR_DETL-to-BAR_DETL fault');
                      return transaction.$executeRawUnsafe(sql, ...params);
                    };
                  },
                }),
              ),
            options,
          );
      },
    });

    await expect(
      applyRepair(faultPrisma, 'approval-reconcile', scope, {
        previewHash: preview.previewHash,
        operator: 'admin',
      }),
    ).rejects.toThrow('injected APR_DETL-to-BAR_DETL fault');
    expect(await physical()).toEqual(before);
    expect(await repairHistory(prisma, { tenantId, coCode: '01' })).toEqual(historyBefore);
  });
});
