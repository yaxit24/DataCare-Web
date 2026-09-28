import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  deleteDiamondSizes,
  deleteItemStockLimits,
  getDiamondSizes,
  getItemStockLimits,
  listDiamondSizeSummary,
  listItemStockLimitSummary,
  saveDiamondSizes,
  saveItemStockLimits,
} from '../src/modules/masters/stockLimit.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'stk-limit-parity';
const CO = '01';
const scope = { tenantId: TENANT, coCode: CO };
const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...params: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...params));

async function clean(): Promise<void> {
  for (const table of ['ITM_WT_MAST', 'DM_SIZE', 'LBR_MAST', 'ITEM_MAST']) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  }
}

databaseDescribe('MS_STK_LIMIT master parity writers', () => {
  beforeEach(async () => {
    await clean();
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ring','G','P1','G01'),
              ($1,$2,'SILV','Silver Chain','S','P2','S01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "LBR_MAST"(tenant_id,"CO_CODE","LBR_CODE","LBR_CATG","LBR_VAL")
       VALUES ($1,$2,'L1','MAKE',10),($1,$2,'L2','SET',20)`,
      TENANT,
      CO,
    );
  });

  afterAll(async () => {
    await clean();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('replaces Dm Size rows for one item and leaves other items untouched', async () => {
    await saveDiamondSizes(
      runtime,
      scope,
      'GOLD',
      [
        { dmSize: '1.00', dmWt: 0.25, pcsGht: 1.5, pcsLbr: 2.5, rateType: 'P', dmRate: 100 },
        { dmSize: '1.50', dmWt: 0.35, pcsGht: 1.6, pcsLbr: 2.6, rateType: 'W', dmRate: 150 },
      ],
      'TESTUSER',
    );
    await saveDiamondSizes(runtime, scope, 'SILV', [{ dmSize: 'S1', dmWt: 0.1 }]);

    await expect(getDiamondSizes(runtime, scope, 'GOLD')).resolves.toMatchObject([
      {
        srNo: 1,
        itCode: 'GOLD',
        itName: 'Gold Ring',
        dmSize: '1.00',
        dmWt: 0.25,
        pcsGht: 1.5,
        pcsLbr: 2.5,
        rateType: 'P',
        dmRate: 100,
      },
      {
        srNo: 2,
        itCode: 'GOLD',
        itName: 'Gold Ring',
        dmSize: '1.50',
        dmWt: 0.35,
        pcsGht: 1.6,
        pcsLbr: 2.6,
        rateType: 'W',
        dmRate: 150,
      },
    ]);

    await saveDiamondSizes(runtime, scope, 'GOLD', [{ dmSize: '2.00', dmWt: 0.45 }]);
    expect((await getDiamondSizes(runtime, scope, 'GOLD')).map((row) => row.dmSize)).toEqual([
      '2.00',
    ]);
    expect((await getDiamondSizes(runtime, scope, 'SILV')).map((row) => row.dmSize)).toEqual([
      'S1',
    ]);
    expect(
      (await listDiamondSizeSummary(runtime, scope)).map((row) => [row.itCode, row.dmSize]),
    ).toEqual([
      ['GOLD', '2.00'],
      ['SILV', 'S1'],
    ]);
  });

  it('deletes Dm Size rows by selected item', async () => {
    await saveDiamondSizes(runtime, scope, 'GOLD', [{ dmSize: '1.00', dmWt: 0.25 }]);
    await expect(deleteDiamondSizes(runtime, scope, 'GOLD')).resolves.toEqual({ deleted: 1 });
    await expect(getDiamondSizes(runtime, scope, 'GOLD')).resolves.toEqual([]);
  });

  it('replaces ItStk Limit rows with the full desktop grid columns and default design N', async () => {
    await saveItemStockLimits(runtime, scope, 'GOLD', '', [
      {
        fromWt: 0.001,
        toWt: 1,
        minPcs: 1,
        lbrCode: 'L1',
        ghtPct: 2.5,
        lbrPct: 3.5,
        minLbrPct: 1.25,
        lbrType: 'G',
        lbrRate: 250,
        lbrAmt: 50,
      },
    ]);

    expect(await getItemStockLimits(runtime, scope, 'GOLD', 'N')).toMatchObject([
      {
        srNo: 1,
        itCode: 'GOLD',
        itName: 'Gold Ring',
        itDesign: 'N',
        fromWt: 0.001,
        toWt: 1,
        minPcs: 1,
        lbrCode: 'L1',
        ghtPct: 2.5,
        lbrPct: 3.5,
        minLbrPct: 1.25,
        lbrType: 'G',
        lbrRate: 250,
        lbrAmt: 50,
      },
    ]);
  });

  it('deletes and rewrites ItStk Limit by item/design without removing another design', async () => {
    await saveItemStockLimits(runtime, scope, 'GOLD', 'N', [
      { fromWt: 0.001, toWt: 1, lbrCode: 'L1' },
    ]);
    await saveItemStockLimits(runtime, scope, 'GOLD', 'D1', [
      { fromWt: 1.001, toWt: 2, lbrCode: 'L2' },
    ]);
    await saveItemStockLimits(runtime, scope, 'GOLD', 'N', [
      { fromWt: 2.001, toWt: 3, lbrCode: 'L1', lbrRate: 300 },
    ]);

    expect(
      (await getItemStockLimits(runtime, scope, 'GOLD', 'N')).map((row) => [
        row.itDesign,
        row.fromWt,
        row.lbrRate,
      ]),
    ).toEqual([['N', 2.001, 300]]);
    expect(
      (await getItemStockLimits(runtime, scope, 'GOLD', 'D1')).map((row) => [
        row.itDesign,
        row.fromWt,
        row.lbrCode,
      ]),
    ).toEqual([['D1', 1.001, 'L2']]);
    expect(
      (await listItemStockLimitSummary(runtime, scope)).map((row) => [
        row.itCode,
        row.itDesign,
        row.rowCount,
      ]),
    ).toEqual([
      ['GOLD', 'D1', 1],
      ['GOLD', 'N', 1],
    ]);

    await expect(deleteItemStockLimits(runtime, scope, 'GOLD', 'D1')).resolves.toEqual({
      deleted: 1,
    });
    expect(await getItemStockLimits(runtime, scope, 'GOLD', 'D1')).toEqual([]);
    expect(await getItemStockLimits(runtime, scope, 'GOLD', 'N')).toHaveLength(1);
  });

  it('rejects invalid labour type using the desktop validation message', async () => {
    await expect(
      saveItemStockLimits(runtime, scope, 'GOLD', 'N', [
        { fromWt: 0.001, toWt: 1, lbrCode: 'L1', lbrType: 'X' },
      ]),
    ).rejects.toThrow(/Please Insert Lbr Type = G Gross/);
  });
});
