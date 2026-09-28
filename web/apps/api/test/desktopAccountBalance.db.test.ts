import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { observeDesktopAccountBalanceTx } from '../src/modules/shared/desktopAccountBalance.js';
import independent from './fixtures/desktopAccountBalance.independent.json';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
type Raw = Record<string, string | null>;
type FixtureRow = { id: string; raw: Raw };
const tenantId = 'r12-ledger-service';
const otherTenant = 'r12-ledger-other';
const tenants = [tenantId, otherTenant];
const selected = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025' };
const input = {
  scope: selected,
  accountCode: 'CUST',
  cutoffLocalSecond: '2024-07-10 12:00:00',
  mode: 'C',
};
const tables = [
  'AC_DATA',
  'SL_DATA',
  'SL_DETL_RTN',
  'SL_DETL',
  'SL_IDTL',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'REMARK_DATA',
  'TEMP_BOOK_DATA',
  'SRNO_MAST',
  'TAG_SET',
  'CO_SET',
  'CO_SET_NEW',
  'COL_MAST',
  'BOOK_DATA',
  'YEAR_MAST',
  'ITEM_MAST',
  'EMP_MAST',
  'TAX_MAST',
  'AC_MAST',
  'CONV_MAST',
] as const;
const sourceRows = independent.rowSets['scope-mode-and-cutoff'] as FixtureRow[];
run('internal source-qualified MsAcBal observation without mode or closing authority', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const sql = (query: string, ...values: unknown[]) => owner.$executeRawUnsafe(query, ...values);
  const insert = async (rows: readonly FixtureRow[]) => {
    for (const row of rows) {
      const raw = {
        ...row.raw,
        tenant_id: row.raw.tenant_id === 'r12-other-tenant' ? otherTenant : tenantId,
      };
      const names = Object.keys(raw)
        .map((key) => `"${key}"`)
        .join(',');
      await sql(
        `INSERT INTO "AC_DATA"(${names}) SELECT ${names} FROM jsonb_populate_record(NULL::"AC_DATA",$1::jsonb)`,
        JSON.stringify(raw),
      );
    }
  };
  const observe = (value: unknown = input) =>
    withTenant(runtime, tenantId, (tx) => observeDesktopAccountBalanceTx(tx, value), {
      isolationLevel: 'RepeatableRead',
    });
  const cleanup = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id=ANY($1::text[])`, tenants);
  };
  const snapshot = async () => {
    const all: Record<string, unknown> = {};
    for (const table of tables)
      all[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id=ANY($1::text[]) ORDER BY to_jsonb(t)::text`,
        tenants,
      );
    return all;
  };
  beforeAll(() => {
    for (const value of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL]) {
      if (!value || new URL(value).port !== '55433')
        throw new Error('Only disposable parity database55433 is allowed.');
    }
    if (new URL(process.env.DATABASE_URL!).username !== 'app_user')
      throw new Error('Non-owner app_user runtime required.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(cleanup);
  afterAll(async () => {
    if (owner) {
      await cleanup();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });
  it('pins the independent fixture authored before reading the new reader', () => {
    const bytes = readFileSync(
      new URL('./fixtures/desktopAccountBalance.independent.json', import.meta.url),
    );
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '32f1d4533a01923972f650ed06c4825f0c4f567d2a44e383f609ed059018e6c7',
    );
  });
  it.each(independent.cases)('$id', async (fixture) => {
    const rows = ('rowSet' in fixture ? sourceRows : fixture.rows) as FixtureRow[];
    await insert(rows);
    const before = await snapshot();
    const result = await observe({ ...fixture.input, scope: selected });
    expect(result.status).toBe(fixture.expected.status);
    expect(result.opening).toMatchObject(fixture.expected.opening);
    expect(result.helperClosing).toMatchObject(fixture.expected.helperClosing);
    expect(result.observationVersion).toMatch(/^[a-f0-9]{64}$/);
    expect(result.scope).toEqual(selected);
    expect(result.mode).toBe(fixture.input.mode);
    expect(result.accountCode).toBe('CUST');
    expect(result.cutoffLocalSecond).toBe(input.cutoffLocalSecond);
    expect(await snapshot()).toEqual(before);
  });
  it('observes raw exact scale, NULL, both books, physical revisions and microsecond predicate evidence', async () => {
    await insert(sourceRows);
    const before = await snapshot();
    const result = await observe();
    const raw = result.observations.map((row) => row.raw);
    expect(raw.map((row) => row.LEDR_KEY).sort()).toEqual(
      [
        'a-main',
        'a-other-book',
        'at-second',
        'b-silver',
        'future-document-date',
        'null-mode',
        'other-mode',
      ].sort(),
    );
    expect(raw.find((row) => row.LEDR_KEY === 'a-main')).toMatchObject({
      CR_AMT: '10.00',
      DR_AMT: '2.00',
      FINE_WT: '1.250',
      ENTRY_TIME: expect.stringContaining('11:59:59.9'),
      IT_DESC: null,
    });
    expect(raw.find((row) => row.LEDR_KEY === 'null-mode')?.DATA_TYPE).toBeNull();
    expect(raw.find((row) => row.LEDR_KEY === 'other-mode')?.SIGN).toBeNull();
    expect(raw.find((row) => row.LEDR_KEY === 'a-other-book')?.CO_BOOK).toBe('Z09');
    for (const row of result.observations) {
      expect(row.revision).toMatch(/^\d+$/);
      expect(row.locator).toMatch(/^\(\d+,\d+\)$/);
      expect(row.physicalId).toMatch(/^\d+$/);
      expect(row.entryTimeLocal).toMatch(/^2024-07-10 /);
    }
    expect(await snapshot()).toEqual(before);
  });
  it('binds eligible same-value physical updates and present-row recreation', async () => {
    await insert([sourceRows[0]!]);
    const first = await observe();
    await sql('UPDATE "AC_DATA" SET "CR_AMT"="CR_AMT" WHERE tenant_id=$1', tenantId);
    const afterUpdate = await snapshot();
    const second = await observe();
    expect(second.observationVersion).not.toBe(first.observationVersion);
    expect(second.opening).toEqual(first.opening);
    expect(await snapshot()).toEqual(afterUpdate);
    await sql('DELETE FROM "AC_DATA" WHERE tenant_id=$1', tenantId);
    await insert([sourceRows[0]!]);
    const afterRecreate = await snapshot();
    const third = await observe();
    expect(third.observationVersion).not.toBe(second.observationVersion);
    expect(third.opening).toEqual(second.opening);
    expect(await snapshot()).toEqual(afterRecreate);
  });
  it('binds other-book eligible inserts but excludes future, null-time and foreign rows from its narrow token', async () => {
    await insert([sourceRows[0]!]);
    const first = await observe();
    await insert(
      sourceRows.filter((row) =>
        [
          'after-microsecond',
          'null-time',
          'foreign-tenant',
          'foreign-company',
          'foreign-location',
          'foreign-year',
          'foreign-account',
        ].includes(row.id),
      ),
    );
    const afterExcluded = await snapshot();
    const second = await observe();
    expect(second.observationVersion).toBe(first.observationVersion);
    expect(second.opening).toEqual(first.opening);
    expect(await snapshot()).toEqual(afterExcluded);
    await insert([sourceRows[1]!]);
    const afterIncluded = await snapshot();
    const third = await observe();
    expect(third.observationVersion).not.toBe(second.observationVersion);
    expect(third.opening).toMatchObject({ amount: '14.00', gold: '1.000' });
    expect(await snapshot()).toEqual(afterIncluded);
  });
  it('records the empty-set absence cycle limitation without claiming universal ABA detection', async () => {
    const empty = await observe();
    await insert([sourceRows[0]!]);
    expect((await observe()).observationVersion).not.toBe(empty.observationVersion);
    await sql('DELETE FROM "AC_DATA" WHERE tenant_id=$1', tenantId);
    const before = await snapshot();
    const absentAgain = await observe();
    expect(absentAgain.observationVersion).toBe(empty.observationVersion);
    expect(absentAgain.opening).toMatchObject({ groupPresent: false, amount: '0.00' });
    expect(await snapshot()).toEqual(before);
  });
  const invalidInputs: Array<{ id: string; value: unknown }> = [
    {
      id: 'missing-mode',
      value: { scope: selected, accountCode: 'CUST', cutoffLocalSecond: input.cutoffLocalSecond },
    },
    { id: 'extra-client-mode-alias', value: { ...input, DATA_TYPE: 'A' } },
    { id: 'unknown-book-predicate', value: { ...input, scope: { ...selected, coBook: 'R11' } } },
    {
      id: 'missing-account',
      value: { scope: selected, cutoffLocalSecond: input.cutoffLocalSecond, mode: 'C' },
    },
    { id: 'lowercase-account', value: { ...input, accountCode: 'cust' } },
    { id: 'blank-company', value: { ...input, scope: { ...selected, coCode: '' } } },
    { id: 'overwidth-account', value: { ...input, accountCode: 'TOO-LONG9' } },
    ...independent.inputRefusals.flatMap((group) =>
      group.values.map((value, index) => ({
        id: `${group.field}-${index}`,
        value: { ...input, [group.field]: value },
      })),
    ),
  ];
  it.each(invalidInputs)(
    'rejects $id without business writes or guessed defaults',
    async ({ value }) => {
      await insert([sourceRows[0]!]);
      const before = await snapshot();
      await expect(observe(value)).rejects.toMatchObject({
        statusCode: 400,
        code: 'invalid-input',
      });
      expect(await snapshot()).toEqual(before);
    },
  );
  it('accepts legitimate short company/location and maximum-width financial-year identities without padding', async () => {
    const value = {
      ...input,
      scope: { ...selected, coCode: '1', lcCode: '1', coYear: '2024-2025X' },
    };
    await insert([
      {
        ...sourceRows[0]!,
        raw: { ...sourceRows[0]!.raw, CO_CODE: '1', LC_CODE: '1', CO_YEAR: '2024-2025X' },
      },
    ]);
    const before = await snapshot();
    const result = await observe(value);
    expect(result.scope).toEqual(value.scope);
    expect(result.status).toBe('ready');
    expect(result.opening).toMatchObject({ groupPresent: true, amount: '8.00', gold: '1.250' });
    expect(await snapshot()).toEqual(before);
  });
  it.each(['read-committed', 'unbound-tenant', 'wrong-tenant'] as const)(
    'refuses untrusted transaction context %s',
    async (kind) => {
      await insert([sourceRows[0]!]);
      const before = await snapshot();
      const operation =
        kind === 'read-committed'
          ? withTenant(runtime, tenantId, (tx) => observeDesktopAccountBalanceTx(tx, input))
          : kind === 'wrong-tenant'
            ? withTenant(runtime, otherTenant, (tx) => observeDesktopAccountBalanceTx(tx, input), {
                isolationLevel: 'RepeatableRead',
              })
            : runtime.$transaction((tx) => observeDesktopAccountBalanceTx(tx, input), {
                isolationLevel: 'RepeatableRead',
              });
      await expect(operation).rejects.toMatchObject({
        statusCode: 400,
        code: 'invalid-transaction-context',
      });
      expect(await snapshot()).toEqual(before);
    },
  );
  it('allows an already tenant-bound Serializable caller without resolving any session mode', async () => {
    await insert([sourceRows[0]!]);
    const before = await snapshot();
    const result = await withTenant(
      runtime,
      tenantId,
      (tx) => observeDesktopAccountBalanceTx(tx, input),
      { isolationLevel: 'Serializable' },
    );
    expect(result.status).toBe('ready');
    expect(result.mode).toBe('C');
    expect(result.opening.amount).toBe('8.00');
    expect(await snapshot()).toEqual(before);
  });
  it.each<{ id: string; patch: Record<string, string>; mode: 'A' | 'C' }>([
    { id: 'account-case', patch: { AC_CODE: 'cust' }, mode: 'C' },
    { id: 'account-padding', patch: { AC_CODE: 'CUST ' }, mode: 'C' },
    { id: 'year-padding', patch: { CO_YEAR: '2024-2025 ' }, mode: 'C' },
    { id: 'mode-case', patch: { DATA_TYPE: 'a' }, mode: 'A' },
    { id: 'gold-case', patch: { IT_TYPE: 'g' }, mode: 'C' },
    { id: 'silver-case', patch: { IT_TYPE: 's' }, mode: 'C' },
    { id: 'fullwidth-plus', patch: { SIGN: '＋' }, mode: 'C' },
  ])(
    'contains a discovered $id candidate rather than silently returning a partial balance',
    async ({ id, patch, mode }) => {
      await insert([sourceRows[0]!]);
      const earlier = await observe({ ...input, mode });
      await insert([
        {
          id: `alias-${id}`,
          raw: {
            ...sourceRows[0]!.raw,
            ...patch,
            LEDR_KEY: `alias-${id}`,
          },
        },
      ]);
      const before = await snapshot();
      const result = await observe({ ...input, mode });
      expect(result.status).toBe('unsupported');
      expect(result.observationVersion).not.toBe(earlier.observationVersion);
      expect(result.observations).toHaveLength(2);
      expect(result.diagnostics.length).toBeGreaterThan(0);
      expect(result.opening).toMatchObject({ amount: null, gold: null, silver: null });
      expect(result.helperClosing).toMatchObject({ amount: null, gold: null, silver: null });
      expect(result.rawGroups.opening.length).toBeGreaterThan(0);
      expect(await snapshot()).toEqual(before);
    },
  );
  it('exposes source all-NULL SQL groups separately from initialized no-group output', async () => {
    const absent = await observe();
    expect(absent.rawGroups).toEqual({ opening: [], helperClosing: [] });
    const row = sourceRows[0]!;
    await insert([{ ...row, raw: { ...row.raw, CR_AMT: null, FINE_WT: null } }]);
    const before = await snapshot();
    const result = await observe();
    expect(result.status).toBe('unsupported');
    expect(result.opening).toMatchObject({
      groupPresent: true,
      eligibleRows: '1',
      amount: null,
      gold: null,
      silver: '0.000',
    });
    expect(result.rawGroups.opening).toEqual([
      expect.objectContaining({ accountCode: 'CUST', eligibleRows: '1', amount: null, gold: null }),
    ]);
    expect(await snapshot()).toEqual(before);
  });
  it('preserves fixed-decimal SQL sums beyond binary Number integer precision', async () => {
    await insert(
      ['large-one', 'large-two'].map((id) => ({
        id,
        raw: {
          ...sourceRows[0]!.raw,
          LEDR_KEY: id,
          CR_AMT: '9999999999999999.99',
          DR_AMT: '0.00',
          FINE_WT: '99999999999.999',
        },
      })),
    );
    const before = await snapshot();
    const result = await observe();
    expect(result.status).toBe('ready');
    // Two current-storage maxima; literal decimal addition, not a production calculation.
    expect(result.opening).toMatchObject({
      amount: '19999999999999999.98',
      gold: '199999999999.998',
      silver: '0.000',
    });
    expect(result.helperClosing).toEqual(result.opening);
    expect(result.rawGroups.opening[0]).toMatchObject({
      amount: '19999999999999999.98',
      gold: '199999999999.998',
    });
    expect(await snapshot()).toEqual(before);
  });
  it('contains PostgreSQL numeric NaN as unsupported rather than claiming a zero balance', async () => {
    await insert([{ ...sourceRows[0]!, raw: { ...sourceRows[0]!.raw, CR_AMT: 'NaN' } }]);
    const before = await snapshot();
    const result = await observe();
    expect(result.status).toBe('unsupported');
    expect(result.opening.amount).toBeNull();
    expect(result.rawGroups.opening[0]?.amount).toBe('NaN');
    expect(result.observations[0]?.raw.CR_AMT).toBe('NaN');
    expect(result.diagnostics.length).toBeGreaterThan(0);
    expect(await snapshot()).toEqual(before);
  });
  it('does not page the contributing ledger and observes raw rows plus groups in one SQL statement', async () => {
    await insert(
      Array.from({ length: 151 }, (_, index) => ({
        id: `many-${index}`,
        raw: {
          ...sourceRows[0]!.raw,
          LEDR_KEY: `many-${index}`,
          CR_AMT: '1.00',
          DR_AMT: '0.00',
          IT_TYPE: 'X',
          FINE_WT: null,
        },
      })),
    );
    const before = await snapshot();
    let statements = 0;
    const result = await withTenant(
      runtime,
      tenantId,
      async (tx) => {
        const observedTx = new Proxy(tx, {
          get(target, key) {
            if (key === '$queryRawUnsafe')
              return async (query: string, ...values: unknown[]) => {
                statements++;
                return target.$queryRawUnsafe(query, ...values);
              };
            const property = Reflect.get(target, key);
            return typeof property === 'function' ? property.bind(target) : property;
          },
        });
        return observeDesktopAccountBalanceTx(observedTx, input);
      },
      { isolationLevel: 'RepeatableRead' },
    );
    expect(statements).toBe(1);
    expect(result.observations).toHaveLength(151);
    expect(result.opening).toMatchObject({
      eligibleRows: '151',
      amount: '151.00',
      gold: '0.000',
      silver: '0.000',
    });
    expect(result.helperClosing).toEqual(result.opening);
    expect(await snapshot()).toEqual(before);
  });
  it('keeps multiple observations in the caller RepeatableRead snapshot coherent with a real second client', async () => {
    await insert([sourceRows[0]!]);
    await withTenant(
      runtime,
      tenantId,
      async (tx) => {
        const first = await observeDesktopAccountBalanceTx(tx, input);
        await sql('UPDATE "AC_DATA" SET "CR_AMT"=20 WHERE tenant_id=$1', tenantId);
        const second = await observeDesktopAccountBalanceTx(tx, input);
        expect(second).toEqual(first);
      },
      { isolationLevel: 'RepeatableRead' },
    );
    const before = await snapshot();
    const fresh = await observe();
    expect(fresh.opening.amount).toBe('18.00');
    expect(await snapshot()).toEqual(before);
  });
});
