import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  getDesignCalculationConfig,
  getDesignComponentDefaults,
  listDesignBook,
  saveDesignBook,
  type DesignBookLine,
} from '../src/modules/masters/designBook.js';
import type { DesignCalculationEvent } from '@datacare/core';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const scope = { tenantId: 'design-calc-db', coCode: '01' };
const foreign = { tenantId: 'design-calc-other', coCode: '01' };
const book = { bookName: 'CALC BOOK', prCode: 'RG' };
const parent = (field: string, value: number | string): DesignCalculationEvent => ({
  kind: 'parent',
  field,
  value,
});
const component = (field: string, value: number | string): DesignCalculationEvent => ({
  kind: 'component',
  isrNo: 7,
  field,
  value,
});
function first<T>(rows: readonly T[]): T {
  const value = rows[0];
  if (value === undefined) throw new Error('Expected database fixture row');
  return value;
}

(enabled ? describe : describe.skip)('X11 ordered calculation replay and company policy', () => {
  const prisma = new PrismaClient();
  async function cleanup() {
    for (const tenantId of [scope.tenantId, foreign.tenantId])
      await withTenant(prisma, tenantId, async (tx) => {
        for (const table of [
          'DESIGN_IDTL',
          'DESIGN_DETL',
          'CO_SET',
          'COL_MAST',
          'HDD_MAST',
          'ITEM_MAST',
        ])
          await tx.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
      });
  }
  const read = async () => first(await listDesignBook(prisma, scope, book.bookName, book.prCode));
  const save = (line: DesignBookLine, expectedVersion?: string) =>
    saveDesignBook(prisma, { scope, ...book, lines: [line], expectedVersion });
  beforeEach(async () => {
    await cleanup();
    await withTenant(prisma, scope.tenantId, async (tx) => {
      await tx.$executeRawUnsafe(
        "INSERT INTO \"CO_SET\"(tenant_id,\"CO_CODE\",\"LBR_TYPE\") VALUES ($1,'01','N'),($1,'02','P')",
        scope.tenantId,
      );
      await tx.$executeRawUnsafe(
        "INSERT INTO \"ITEM_MAST\"(tenant_id,\"CO_CODE\",\"IT_CODE\",\"IT_TYPE\",\"CON_PRC\",\"OTH_RATE_TYPE\",\"OTH_RATE\") VALUES ($1,'01','STONE','S',0.2,'P',50),($1,'02','OTHER','D',0.5,'F',999)",
        scope.tenantId,
      );
    });
  });
  afterAll(async () => {
    await cleanup();
    await prisma.$disconnect();
  });

  it('replays parent/component edits from DB baseline and ignores submitted derived values and master defaults', async () => {
    const config = await getDesignCalculationConfig(prisma, scope);
    const events: DesignCalculationEvent[] = [
      parent('grossWt', 10),
      parent('touch', 90),
      { kind: 'addComponent', isrNo: 7 },
      {
        kind: 'item',
        isrNo: 7,
        itCode: 'STONE',
        defaults: { itType: 'X', conversionPct: 99, rateType: 'K', rate: 9999 },
      },
      component('pcs', 4),
      component('pcsWt', 2),
      component('karigarLessPct', 10),
      component('labourRate', 2),
      { kind: 'refreshParent' },
      parent('rate', 100),
      parent('labourRate', 3.5),
    ];
    await save(
      {
        srNo: 10,
        designNo: 'CALC-1',
        style: 'Style kept',
        grCode: 'G01',
        grossWt: 999,
        amount: 9999,
        calculationVersion: config.version,
        calculationEvents: events,
        components: [{ isrNo: 7, itCode: 'STONE', amount: 9999, rate: 9999 }],
      },
      'new',
    );
    const result = await read();
    expect(result).toMatchObject({
      SR_NO: 10,
      ITM_STYLE: 'Style kept',
      GR_CODE: 'G01',
      LBR_TYPE: 'N',
    });
    expect(Number(result.ITM_GWT)).toBe(10);
    expect(Number(result.ITM_OTH_WT)).toBe(0.16);
    expect(Number(result.ITM_NWT)).toBe(9.84);
    expect(Number(result.ITM_FINE)).toBe(8.856);
    expect(Number(result.ITM_AMT)).toBe(886);
    expect(Number(result.LBR_AMT)).toBe(34);
    expect(Number(result.OTH_AMT)).toBe(208);
    const child = first(result.components as Record<string, unknown>[]);
    expect(child).toMatchObject({
      SR_NO: 10,
      ISR_NO: 7,
      IT_CODE: 'STONE',
      IT_TYPE: 'S',
      IT_RATE_TYPE: 'P',
    });
    for (const [key, expected] of Object.entries({
      IT_PCS: 4,
      IT_PCS_WT: 2,
      KR_WT: 8,
      IT_GWT: 0.8,
      IT_CON_WT: 0.16,
      IT_RATE: 50,
      IT_AMT: 200,
      IT_LBR_AMT: 8,
      IT_NET_AMT: 208,
    }))
      expect(Number(child[key]), key).toBe(expected);
  });
  it('keeps unchanged snapshots including null, zero, blank, hidden fields and component piece weight', async () => {
    await save({
      srNo: 10,
      designNo: 'IMPORTED',
      style: 'Old',
      grossWt: 15,
      netWt: 11,
      fineWt: 10,
      rate: null,
      tagCost: 713.45,
      netAmount: 991.17,
      labourType: '',
      ghatWt: 0.137,
      components: [
        {
          isrNo: 7,
          itCode: 'STONE',
          pcsWt: 0.251,
          karigarWt: 2,
          grossWt: 1,
          amount: null,
          labourAmount: 0,
        },
      ],
    });
    const before = await read();
    const config = await getDesignCalculationConfig(prisma, scope);
    await save(
      { srNo: 10, designNo: 'IMPORTED', calculationVersion: config.version, calculationEvents: [] },
      String(before.bookVersion),
    );
    expect(await read()).toEqual(before);
  });
  it('preserves metadata edits alongside calculation changes and retains manual zeros through saved updates', async () => {
    await save({
      srNo: 10,
      designNo: 'EDIT',
      style: 'Old',
      grCode: 'OLD',
      grossWt: 10,
      otherWt: 0,
      netWt: 10,
      fineWt: 10,
      touch: 0,
      rate: 0,
      amount: 91,
      labourRate: 0,
      labourAmount: 17,
      components: [],
    });
    const config = await getDesignCalculationConfig(prisma, scope);
    const before = await read();
    await save(
      {
        srNo: 10,
        designNo: 'EDIT',
        style: 'New style',
        grCode: 'NEW',
        calculationVersion: config.version,
        calculationEvents: [parent('rate', 0), parent('labourPct', 20)],
        components: [],
      },
      String(before.bookVersion),
    );
    const after = await read();
    expect(after).toMatchObject({ ITM_STYLE: 'New style', GR_CODE: 'NEW' });
    expect(Number(after.ITM_AMT)).toBe(91);
    expect(Number(after.LBR_AMT)).toBe(17);
  });
  it('resolves scoped settings/defaults, suppresses raw license identity and rejects foreign item identities', async () => {
    const config = await getDesignCalculationConfig(prisma, scope);
    expect(config).toMatchObject({
      defaultLabourType: 'N',
      automaticCost: false,
      tagCostVisible: true,
    });
    expect(await getDesignCalculationConfig(prisma, { ...scope, coCode: '02' })).toMatchObject({
      defaultLabourType: 'P',
    });
    expect(await getDesignCalculationConfig(prisma, foreign)).toMatchObject({
      defaultLabourType: 'G',
      automaticCost: false,
    });
    expect(await getDesignComponentDefaults(prisma, scope, 'STONE')).toEqual({
      itType: 'S',
      conversionPct: '0.2',
      rateType: 'P',
      rate: '50',
    });
    await expect(getDesignComponentDefaults(prisma, scope, 'OTHER')).rejects.toThrow('not found');
    await expect(getDesignComponentDefaults(prisma, foreign, 'STONE')).rejects.toThrow('not found');
    await withTenant(prisma, scope.tenantId, (tx) =>
      tx.$executeRawUnsafe(
        'INSERT INTO "HDD_MAST"(tenant_id,"REF_NO") VALUES ($1,\'AK004NEAK\')',
        scope.tenantId,
      ),
    );
    const automatic = await getDesignCalculationConfig(prisma, scope);
    expect(automatic.automaticCost).toBe(true);
    expect(JSON.stringify(automatic)).not.toContain('AK004NEAK');
    expect(automatic.version).not.toBe(config.version);
  });
  it('uses configured hidden TagCost and transient purchase-cost/margin to persist only the calculated MRP', async () => {
    await withTenant(prisma, scope.tenantId, (tx) =>
      tx.$executeRawUnsafe(
        'INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO","COL_RPT") VALUES ($1,\'01\',\'DESIGN DETL\',\'TagCost\',\'Private cost\',\'N\',\'N\')',
        scope.tenantId,
      ),
    );
    const config = await getDesignCalculationConfig(prisma, scope);
    expect(config.tagCostVisible).toBe(false);
    await save({
      designNo: 'MARGIN',
      calculationVersion: config.version,
      calculationEvents: [parent('purchaseCost', 100), parent('marginPct', 5)],
      components: [],
    });
    const result = await read();
    expect(Number(result.ITM_MRP)).toBe(105);
    expect(result).not.toHaveProperty('purchaseCost');
    expect(result).not.toHaveProperty('marginPct');
  });
  it('rejects stale settings and incomplete component histories atomically', async () => {
    await save({ designNo: 'BEFORE', grossWt: 10, components: [] });
    const before = await read();
    const config = await getDesignCalculationConfig(prisma, scope);
    await expect(
      save(
        { designNo: 'BAD', calculationVersion: 'old', calculationEvents: [parent('grossWt', 99)] },
        String(before.bookVersion),
      ),
    ).rejects.toThrow('settings changed');
    await expect(
      save(
        {
          designNo: 'BAD',
          calculationVersion: config.version,
          calculationEvents: [parent('grossWt', 99)],
          components: [{ isrNo: 7, itCode: 'STONE' }],
        },
        String(before.bookVersion),
      ),
    ).rejects.toThrow('missing from');
    await expect(
      save(
        {
          designNo: 'BAD',
          calculationVersion: config.version,
          calculationEvents: [component('rate', 99)],
        },
        String(before.bookVersion),
      ),
    ).rejects.toThrow('not found');
    expect(await read()).toEqual(before);
  });
  it('rejects conflicting configuration rows without selecting an arbitrary branch', async () => {
    await withTenant(prisma, scope.tenantId, (tx) =>
      tx.$executeRawUnsafe(
        'INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE") VALUES ($1,\'01\',\'P\')',
        scope.tenantId,
      ),
    );
    await expect(getDesignCalculationConfig(prisma, scope)).rejects.toThrow('Conflicting');
  });
});
