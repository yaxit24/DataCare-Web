import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { getSaleReturnIncomingConfiguration } from '../src/modules/sales/saleReturnIncomingConfiguration.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('incoming Return configuration from exact scoped database observations', () => {
  const tenantId = 'return-config-round8';
  const otherTenant = 'return-config-other-r8';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R81' };
  const tables = [
    'CO_SET',
    'CO_SET_NEW',
    'COL_MAST',
    'BOOK_DATA',
    'YEAR_MAST',
    'SL_DATA',
    'SL_DETL_RTN',
    'BAR_IDTL',
    'MAIN_STOCK',
    'AC_DATA',
  ];
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const insert = async (table: string, values: Record<string, unknown>) => {
    const columns = Object.keys(values)
      .map((key) => `"${key}"`)
      .join(',');
    await sql(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const settings = (extra: Record<string, unknown> = {}) => ({
    tenant_id: tenantId,
    CO_CODE: '01',
    SL_AMT_TYPE: 'F',
    LBR_ROF: '2',
    LBR_RATE_GEN: 'N',
    ALL_ROF_REMOVE: 'N',
    LBR_TYPE: 'G',
    ADMIN_SMS: 'not a public configuration field',
    ...extra,
  });
  const column = (extra: Record<string, unknown> = {}) =>
    insert('COL_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      BOOK_NAME: 'SALES RETURNE',
      COL_NAME: 'Fine',
      COL_NEW_NAME: 'Fine',
      YES_NO: 'N',
      COL_RPT: 'Y',
      ...extra,
    });
  const get = () => getSaleReturnIncomingConfiguration(runtime, scope);
  const cleanup = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN($1,$2)`, tenantId, otherTenant);
  };
  const snapshot = async () => {
    const result: Record<string, unknown> = {};
    for (const table of tables)
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id IN($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
    return result;
  };
  beforeAll(() => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await cleanup();
    for (const tenant of [tenantId, otherTenant]) {
      await insert('CO_SET', settings({ tenant_id: tenant }));
      await insert('CO_SET_NEW', { tenant_id: tenant, CO_CODE: '01', LBR_WITH_GHT: 'Y' });
      await insert('YEAR_MAST', {
        tenant_id: tenant,
        CO_CODE: '01',
        CO_YEAR: '2024-2025',
        OP_DATE: '2024-04-01',
        CL_DATE: '2025-03-31T23:59:59.123456',
      });
      for (const book of ['R81', 'R82'])
        await insert('BOOK_DATA', {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: '01',
          CO_BOOK: book,
          MAIN_BOOK: 'SALES RETURNE',
          BOOK_NAME: `Custom ${book}`,
          BOOK_INOUT: 'I',
          BOOK_TBL_NAME: 'SL_DATA',
          CUR_USE: 'Y',
        });
    }
    const saved = {
      tenant_id: tenantId,
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: '2024-2025',
      CO_BOOK: 'R81',
      VCH_NO: '00001',
    };
    await insert('SL_DATA', {
      ...saved,
      VCH_DATE: '2024-07-08',
      VCH_TIME: '2024-07-08T12:13:14.123456',
      EMP_CODE: null,
      NET_AMT: '9999999999999999.99',
    });
    await insert('SL_DETL_RTN', {
      ...saved,
      SR_NO: 17,
      OLD_SRNO: 31,
      VCH_SRNO: 917,
      IT_CODE: 'GOLD',
      ITM_FINE: null,
      ITM_REMARK: '',
      ITM_RATE: '9999999999999999.99',
    });
    await insert('BAR_IDTL', {
      ...saved,
      SR_NO: 31,
      ISR_NO: 9,
      VCH_SRNO: 917,
      IT_CODE: 'STONE',
      IT_GWT: '0.123',
    });
  });
  afterAll(async () => {
    if (owner) {
      await cleanup();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('returns configured source policy and stable fields without changing raw saved data or provisioning columns', async () => {
    const before = await snapshot();
    const dto = await get();
    expect(dto.scope).toEqual({ coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R81' });
    expect(dto.policy).toEqual({
      saleAmountType: 'F',
      labourRoundingDecimals: 2,
      labourIncludesGhat: true,
      generateLabourRate: false,
      fineColumnWidth: 1000,
    });
    expect(dto.columns[6]!.widthState).toBe('unresolved');
    expect(dto.capabilities).toEqual({ canCalculate: true, canSaveNumeric: false });
    expect(dto.rawSettings).toHaveProperty('CO_SET.LBR_ROF', '2');
    expect(JSON.stringify(dto)).not.toContain('not a public configuration field');
    expect(await snapshot()).toEqual(before);
    expect((await get()).version).toBe(dto.version);
  });

  it('applies source empty-string defaults without converting NULL to blank', async () => {
    await sql(
      'UPDATE "CO_SET" SET "SL_AMT_TYPE"=\'\',"LBR_RATE_GEN"=\'\',"ALL_ROF_REMOVE"=\'\',"LBR_TYPE"=\'\' WHERE tenant_id=$1',
      tenantId,
    );
    await sql('UPDATE "CO_SET_NEW" SET "LBR_WITH_GHT"=\'\' WHERE tenant_id=$1', tenantId);
    const dto = await get();
    expect(dto.policy).toMatchObject({
      saleAmountType: 'N',
      labourIncludesGhat: true,
      generateLabourRate: false,
    });
    expect(dto.newRowDefaults.labourType).toBe('G');
    expect(dto.rawSettings['CO_SET.SL_AMT_TYPE']).toBe('');
    await sql('UPDATE "CO_SET" SET "SL_AMT_TYPE"=NULL WHERE tenant_id=$1', tenantId);
    const absent = await get();
    expect(absent.rawSettings['CO_SET.SL_AMT_TYPE']).toBeNull();
    expect(absent.policy).toBeNull();
  });

  it.each([
    ['4', 'N', 0],
    ['4', 'Y', 2],
    ['-1', 'Y', 2],
    ['-1', 'N', null],
    ['2.5', 'Y', null],
    ['2147483648', 'Y', null],
    ['NaN', 'Y', null],
    ['Infinity', 'Y', null],
    [null, 'Y', null],
  ] as const)(
    'reads exact stored precision %s with %s override as %s',
    async (precision, override, expected) => {
      await sql(
        'UPDATE "CO_SET" SET "LBR_ROF"=$2::float8,"ALL_ROF_REMOVE"=$3 WHERE tenant_id=$1',
        tenantId,
        precision,
        override,
      );
      const dto = await get();
      if (expected === null) expect(dto.policy).toBeNull();
      else expect(dto.policy?.labourRoundingDecimals).toBe(expected);
      expect(dto.rawSettings['CO_SET.LBR_ROF']).toBe(precision);
    },
  );

  it('resolves explicit Fine hiding, a blank caption, and restores source visibility when the row is removed', async () => {
    const baseline = await get();
    await column({ COL_NEW_NAME: '' });
    const hidden = await get();
    expect(hidden.policy?.fineColumnWidth).toBe(0);
    expect(hidden.columns[18]).toMatchObject({
      id: 'x13.primary-incoming.c18',
      label: '',
      widthState: 'zero',
    });
    expect(hidden.version).not.toBe(baseline.version);
    await sql('DELETE FROM "COL_MAST" WHERE tenant_id=$1', tenantId);
    const restored = await get();
    expect(restored.policy?.fineColumnWidth).toBe(1000);
    // Absence→insert→delete without a persistent revision row is indistinguishable after deletion.
    // The observation token does NOT claim a durable absent-row mutation history.
    expect(restored.version).toBe(baseline.version);
  });

  it('ignores company00 templates, unrelated companies, other tenants and other column families without fallback', async () => {
    const baseline = await get();
    await column({ CO_CODE: '00' });
    await column({ CO_CODE: '02' });
    await column({ tenant_id: otherTenant });
    await column({ BOOK_NAME: 'SALES' });
    await insert('CO_SET', settings({ CO_CODE: '02', LBR_ROF: '0' }));
    const dto = await get();
    expect(dto.policy).toEqual(baseline.policy);
    expect(dto.version).toBe(baseline.version);
  });

  it('contains missing and duplicate company settings instead of using another company or an arbitrary first row', async () => {
    await insert('CO_SET', settings());
    const duplicate = await get();
    expect(duplicate.policy).toBeNull();
    expect(duplicate.diagnostics).toContainEqual(
      expect.objectContaining({ code: 'settings-row-count' }),
    );
    await sql('DELETE FROM "CO_SET" WHERE tenant_id=$1', tenantId);
    await insert('CO_SET', settings({ CO_CODE: '00' }));
    expect((await get()).policy).toBeNull();
  });

  it('contains missing CO_SET_NEW and null visibility without rewriting them', async () => {
    await sql('DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1', tenantId);
    expect((await get()).diagnostics).toContainEqual(
      expect.objectContaining({ code: 'new-settings-row-count' }),
    );
    await insert('CO_SET_NEW', { tenant_id: tenantId, CO_CODE: '01', LBR_WITH_GHT: 'Y' });
    await column({ YES_NO: null });
    const before = await snapshot();
    const dto = await get();
    expect(dto.policy).toBeNull();
    expect(dto.columns[18]!.widthState).toBe('unresolved');
    expect(await snapshot()).toEqual(before);
  });

  it('contains identical duplicate original keys and preserves distinct IDs for shared captions', async () => {
    await column({ COL_NEW_NAME: 'Metal', YES_NO: 'Y' });
    await column({ COL_NAME: 'Rate', COL_NEW_NAME: 'Metal', YES_NO: 'Y' });
    const shared = await get();
    expect(shared.capabilities.canCalculate).toBe(true);
    expect(shared.columns[18]!.id).not.toBe(shared.columns[19]!.id);
    await column({ COL_NEW_NAME: 'Metal', YES_NO: 'Y' });
    const duplicate = await get();
    expect(duplicate.policy).toBeNull();
    expect(duplicate.columns[18]!.widthState).toBe('unresolved');
  });

  it.each([
    { COL_NAME: 'fine' },
    { COL_NAME: ' Fine ' },
    { BOOK_NAME: 'sales returne' },
    { BOOK_NAME: 'SALES RETURNE ' },
  ])('finds normalized collisions collected before exact family filtering: %j', async (extra) => {
    await column();
    await column(extra);
    const dto = await get();
    expect(dto.policy).toBeNull();
    expect(dto.columns[18]!.widthState).toBe('unresolved');
  });

  it('does not let blank keys configure hidden identities and distinguishes NULL labels from empty labels', async () => {
    await column({ COL_NAME: '', COL_NEW_NAME: 'Hidden identity' });
    expect((await get()).diagnostics).toContainEqual(
      expect.objectContaining({ code: 'invalid-column-key', blocking: true }),
    );
    await sql('DELETE FROM "COL_MAST" WHERE tenant_id=$1', tenantId);
    await column({ COL_NEW_NAME: null, YES_NO: 'Y' });
    const dto = await get();
    expect(dto.columns[18]!.label).toBeNull();
    expect(dto.policy).toBeNull();
  });

  it('versions every relevant physical setting update and A→B→A without exposing unrelated settings', async () => {
    const baseline = await get();
    await sql('UPDATE "CO_SET" SET "LBR_ROF"=3 WHERE tenant_id=$1', tenantId);
    const changed = await get();
    await sql('UPDATE "CO_SET" SET "LBR_ROF"=2 WHERE tenant_id=$1', tenantId);
    const restored = await get();
    expect(restored.rawSettings).toEqual(baseline.rawSettings);
    expect(restored.policy).toEqual(baseline.policy);
    expect(new Set([baseline.version, changed.version, restored.version]).size).toBe(3);
  });

  it('versions column update/recreation and relevant book/year physical observations', async () => {
    await column();
    const baseline = await get();
    await sql('UPDATE "COL_MAST" SET "COL_NEW_NAME"=\'Fine label\' WHERE tenant_id=$1', tenantId);
    const renamed = await get();
    await sql('UPDATE "COL_MAST" SET "COL_NEW_NAME"=\'Fine\' WHERE tenant_id=$1', tenantId);
    const reverted = await get();
    expect(reverted.policy).toEqual(baseline.policy);
    expect(new Set([baseline.version, renamed.version, reverted.version]).size).toBe(3);
    await sql('DELETE FROM "COL_MAST" WHERE tenant_id=$1', tenantId);
    await column();
    const recreated = await get();
    expect(recreated.version).not.toBe(reverted.version);
    await sql(
      'UPDATE "BOOK_DATA" SET "BOOK_NAME"=\'New custom name\' WHERE tenant_id=$1 AND "CO_BOOK"=\'R81\'',
      tenantId,
    );
    const renamedBook = await get();
    expect(renamedBook.version).not.toBe(recreated.version);
    await sql('UPDATE "YEAR_MAST" SET "OLD_METHOD"=\'Y\' WHERE tenant_id=$1', tenantId);
    expect((await get()).version).not.toBe(renamedBook.version);
  });

  it('preserves blank book direction/table compatibility but rejects explicit contradictions and missing/duplicate target year', async () => {
    await sql(
      'UPDATE "BOOK_DATA" SET "BOOK_INOUT"=\'\',"BOOK_TBL_NAME"=NULL WHERE tenant_id=$1',
      tenantId,
    );
    expect((await get()).capabilities.canCalculate).toBe(true);
    await sql('UPDATE "BOOK_DATA" SET "BOOK_INOUT"=\'O\' WHERE tenant_id=$1', tenantId);
    await expect(get()).rejects.toMatchObject({ statusCode: 422 });
    await sql('UPDATE "BOOK_DATA" SET "BOOK_INOUT"=\'I\' WHERE tenant_id=$1', tenantId);
    await insert('YEAR_MAST', { tenant_id: tenantId, CO_CODE: '01', CO_YEAR: '2024-2025' });
    await expect(get()).rejects.toMatchObject({ statusCode: 422 });
    await sql('DELETE FROM "YEAR_MAST" WHERE tenant_id=$1', tenantId);
    await expect(get()).rejects.toMatchObject({ statusCode: 422 });
  });

  it('shares the company Return column family across separately configured books but binds observations to full selected scope', async () => {
    await column();
    const first = await get();
    const second = await getSaleReturnIncomingConfiguration(runtime, { ...scope, coBook: 'R82' });
    expect(second.policy).toEqual(first.policy);
    expect(second.version).not.toBe(first.version);
    await expect(
      getSaleReturnIncomingConfiguration(runtime, { ...scope, lcCode: '02' }),
    ).rejects.toMatchObject({ statusCode: 422 });
    await expect(
      getSaleReturnIncomingConfiguration(runtime, { ...scope, coCode: '02' }),
    ).rejects.toMatchObject({ statusCode: 422 });
  });

  it('observes one RepeatableRead snapshot even when settings and an absent Fine override change between actual SQL reads', async () => {
    const baseline = await get();
    let changed = false;
    // Instrument transaction scheduling only: every result comes from real PostgreSQL queries.
    const schedulingClient = {
      $transaction: (callback: (tx: unknown) => Promise<unknown>, options: unknown) =>
        runtime.$transaction(
          async (tx) => {
            const scheduledTx = {
              $executeRawUnsafe: tx.$executeRawUnsafe.bind(tx),
              $queryRawUnsafe: async (statement: string, ...values: unknown[]) => {
                const result = await tx.$queryRawUnsafe(statement, ...values);
                if (!changed && statement.includes('FROM "CO_SET" t')) {
                  changed = true;
                  await sql('UPDATE "CO_SET" SET "LBR_ROF"=3 WHERE tenant_id=$1', tenantId);
                  await column();
                }
                return result;
              },
            };
            return callback(scheduledTx);
          },
          options as { isolationLevel: 'RepeatableRead' },
        ),
    };
    const coherent = await getSaleReturnIncomingConfiguration(schedulingClient, scope);
    expect(changed).toBe(true);
    expect(coherent).toEqual(baseline);
    const next = await get();
    expect(next.policy).toMatchObject({ labourRoundingDecimals: 3, fineColumnWidth: 0 });
    expect(next.version).not.toBe(baseline.version);
  });
});
