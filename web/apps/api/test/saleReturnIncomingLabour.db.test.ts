import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  copySaleReturnIncomingLabour,
  createSaleReturnIncomingState,
  type SaleReturnIncomingLabourObservation,
} from '@datacare/core';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { readSaleReturnIncomingLabourTx } from '../src/modules/sales/saleReturnIncomingLabour.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'labour-admission-db';
const otherTenant = 'labour-admission-other';
const tenants = [tenantId, otherTenant];
const scope = { tenantId, coCode: '01' };
const tables = ['LBR_MAST', 'CO_SET', 'AC_DATA', 'SL_DATA', 'SL_DETL_RTN'] as const;
run(
  'internal Return labour-master observation on PostgreSQL, without route or write admission',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    const sql = (statement: string, ...values: unknown[]) =>
      owner.$executeRawUnsafe(statement, ...values);
    const cleanup = async () => {
      for (const table of tables)
        await sql(`DELETE FROM "${table}" WHERE tenant_id=ANY($1::text[])`, tenants);
    };
    const insert = (
      code = 'S1',
      value: string | null = '12.5',
      company = '01',
      tenant = tenantId,
      category = '01 Rate',
    ) =>
      sql(
        'INSERT INTO "LBR_MAST"(tenant_id,"CO_CODE","LBR_CODE","LBR_CATG","LBR_VAL","MAIN_USER") VALUES($1,$2,$3,$4,$5::double precision,NULL)',
        tenant,
        company,
        code,
        category,
        value,
      );
    const observe = (code = 'S1', company = '01') =>
      withTenant(
        runtime,
        tenantId,
        (tx) =>
          readSaleReturnIncomingLabourTx(tx, {
            scope: { tenantId, coCode: company },
            enteredCode: code,
          }),
        { isolationLevel: 'RepeatableRead' },
      );
    const snapshot = async () => {
      const result: Record<string, unknown> = {};
      for (const table of tables)
        result[table] = await owner.$queryRawUnsafe(
          `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id=ANY($1::text[]) ORDER BY to_jsonb(t)::text`,
          tenants,
        );
      return result;
    };
    const copy = (observation: SaleReturnIncomingLabourObservation, field: 13 | 29 = 13) => {
      const state = createSaleReturnIncomingState({
        rowIdentity: 'saved-row-17-old31',
        raw: { CO_CODE: observation.scope.coCode, SR_NO: '17', HM_ID: null },
        cells: {
          ...Object.fromEntries(Array.from({ length: 71 }, (_, n) => [n, ''])),
          0: '1',
          22: 'N',
          45: '1.234',
          58: '23.00',
        },
        cacheMode: 'provided',
      });
      return copySaleReturnIncomingLabour({
        state,
        rowIdentity: state.rowIdentity,
        scope: observation.scope,
        field,
        editorText: observation.enteredCode,
        expectedObservationVersion: observation.observationVersion,
        observation,
      });
    };
    beforeAll(async () => {
      for (const value of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL]) {
        if (
          !value ||
          new URL(value).port !== '55433' ||
          !['localhost', '127.0.0.1'].includes(new URL(value).hostname)
        )
          throw new Error('Only isolated local55433 is allowed.');
      }
      if (new URL(process.env.DATABASE_URL!).username !== 'app_user')
        throw new Error('app_user runtime required.');
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      const roles = await runtime.$queryRawUnsafe<
        Array<{ rolsuper: boolean; rolbypassrls: boolean }>
      >('SELECT rolsuper,rolbypassrls FROM pg_roles WHERE rolname=current_user');
      expect(roles).toEqual([{ rolsuper: false, rolbypassrls: false }]);
    });
    beforeEach(async () => {
      await cleanup();
      await sql(
        'INSERT INTO "AC_DATA"(tenant_id,"LEDR_KEY","CO_CODE","CO_BOOK","CR_AMT","DR_AMT","ENTRY_TIME") VALUES($1,\'labour-unchanged\',\'01\',\'R01\',90071992547409.91,NULL,\'2024-04-03 12:34:56.123456\')',
        tenantId,
      );
      await sql(
        'INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LAST_DAY_LOCK","LOCK_DATE") VALUES($1,\'01\',\'Y\',\'2024-04-03\')',
        tenantId,
      );
    });
    afterAll(async () => {
      if (owner) {
        await cleanup();
        await owner.$disconnect();
      }
      if (runtime) await runtime.$disconnect();
    });
    it('observes raw NULL and Float text with full composite identity, then copies zero without any physical writes', async () => {
      await insert('S1', '0');
      const before = await snapshot();
      const value = await observe();
      expect(value.masters).toHaveLength(1);
      expect(value.masters[0]?.raw).toEqual({
        tenant_id: tenantId,
        CO_CODE: '01',
        LBR_CODE: 'S1',
        LBR_CATG: '01 Rate',
        LBR_VAL: '0',
        MAIN_USER: null,
      });
      expect(value.masters[0]?.revision).toMatch(/^[0-9]+$/);
      expect(value.masters[0]?.locator).toMatch(/^\([0-9]+,[0-9]+\)$/);
      expect(value.observationVersion).toMatch(/^[a-f0-9]{64}$/);
      const result = copy(value);
      expect(result.status).toBe('ready');
      expect(result.visiblePatch).toEqual({
        13: 'S1',
        29: 'S1',
        23: '0.00',
        24: '',
        21: '',
        14: '',
        17: '',
        28: '',
      });
      expect(result.state?.caches[58]).toBe('23.00');
      expect(result.state?.journal).toEqual([]);
      expect(await snapshot()).toEqual(before);
    });
    it.each(['code-case', 'code-space', 'company-case', 'company-space'])(
      'discovers and refuses real %s PK aliases',
      async (kind) => {
        const code = kind === 'code-space' ? 'S' : 'S1';
        const company = kind.startsWith('company') ? 'A' : '01';
        await insert(code, '12.5', company);
        await insert(
          kind === 'code-case' ? 's1' : kind === 'code-space' ? 'S ' : code,
          '99',
          kind === 'company-case' ? 'a' : kind === 'company-space' ? 'A ' : company,
        );
        const before = await snapshot();
        const value = await observe(code, company);
        expect(value.masters).toHaveLength(2);
        const result = copy(value);
        expect(result.status).toBe('unsupported');
        expect(result.diagnostics).toEqual([
          expect.objectContaining({ code: 'ambiguous-labour-master' }),
        ]);
        expect(result.visiblePatch).toBeNull();
        expect(await snapshot()).toEqual(before);
      },
    );
    it('does not fall back to another company or tenant', async () => {
      await insert('S1', '50', '02');
      await insert('S1', '90', '01', otherTenant);
      const before = await snapshot();
      const value = await observe();
      expect(value.masters).toEqual([]);
      expect(copy(value).status).toBe('lookup-required');
      expect(await snapshot()).toEqual(before);
    });
    it.each([null, 'NaN', 'Infinity'])(
      'retains raw SQL value %s and contains unqualified numeric projection',
      async (value) => {
        await insert('S1', value);
        const before = await snapshot();
        const observation = await observe();
        const raw = observation.masters[0]?.raw.LBR_VAL;
        if (value === null) expect(raw).toBeNull();
        else expect(raw).toBe(value);
        expect(copy(observation)).toMatchObject({
          status: 'unsupported',
          visiblePatch: null,
          nextEvent: null,
          diagnostics: [{ code: 'unsupported-labour-value', message: expect.any(String) }],
        });
        expect(await snapshot()).toEqual(before);
      },
    );
    it('retains PostgreSQL JSONB Float normalization without a JavaScript numeric roundtrip', async () => {
      await insert('S1', '1e30');
      const before = await snapshot();
      const observation = await observe();
      // JSONB numeric text expands a Float exponent; direct float8::text is a different representation.
      expect(observation.masters[0]?.raw.LBR_VAL).toBe('1000000000000000000000000000000');
      const result = copy(observation);
      expect(result.status).toBe('ready');
      expect(result.visiblePatch?.[23]).toBe('1000000000000000000000000000000.00');
      expect(await snapshot()).toEqual(before);
    });
    it('changes observation token on a same-value physical update and on delete/recreate', async () => {
      await insert();
      const first = await observe();
      await sql('UPDATE "LBR_MAST" SET "LBR_VAL"="LBR_VAL" WHERE tenant_id=$1', tenantId);
      const beforeRead = await snapshot();
      const changed = await observe();
      expect(changed.observationVersion).not.toBe(first.observationVersion);
      expect(changed.masters[0]?.raw).toEqual(first.masters[0]?.raw);
      expect(await snapshot()).toEqual(beforeRead);
      await sql('DELETE FROM "LBR_MAST" WHERE tenant_id=$1', tenantId);
      await insert();
      const recreated = await observe();
      expect(recreated.observationVersion).not.toBe(changed.observationVersion);
      expect(recreated.masters[0]?.raw).toEqual(changed.masters[0]?.raw);
    });
    it('explicitly restores an absent token after insert/delete; no durable absent-row history is claimed', async () => {
      const absent = await observe();
      await insert();
      expect((await observe()).observationVersion).not.toBe(absent.observationVersion);
      await sql('DELETE FROM "LBR_MAST" WHERE tenant_id=$1', tenantId);
      expect(await observe()).toEqual(absent);
    });
    it('keeps the caller RepeatableRead snapshot through an external master change, then observes it in the next transaction', async () => {
      await insert();
      let first!: SaleReturnIncomingLabourObservation;
      await withTenant(
        runtime,
        tenantId,
        async (tx) => {
          first = await readSaleReturnIncomingLabourTx(tx, { scope, enteredCode: 'S1' });
          await sql('UPDATE "LBR_MAST" SET "LBR_VAL"=99 WHERE tenant_id=$1', tenantId);
          const later = await readSaleReturnIncomingLabourTx(tx, { scope, enteredCode: 'S1' });
          expect(later).toEqual(first);
        },
        { isolationLevel: 'RepeatableRead' },
      );
      const current = await observe();
      expect(current.observationVersion).not.toBe(first.observationVersion);
      expect(current.masters[0]?.raw.LBR_VAL).toBe('99');
    });
    it('refuses a different bound tenant and read-committed caller without writes', async () => {
      await insert();
      const before = await snapshot();
      await expect(
        withTenant(
          runtime,
          otherTenant,
          (tx) => readSaleReturnIncomingLabourTx(tx, { scope, enteredCode: 'S1' }),
          { isolationLevel: 'RepeatableRead' },
        ),
      ).rejects.toMatchObject({ code: 'invalid-transaction-context' });
      await expect(
        withTenant(
          runtime,
          tenantId,
          (tx) => readSaleReturnIncomingLabourTx(tx, { scope, enteredCode: 'S1' }),
          { isolationLevel: 'ReadCommitted' },
        ),
      ).rejects.toMatchObject({ code: 'invalid-transaction-context' });
      expect(await snapshot()).toEqual(before);
    });
    it('accepts Serializable caller observation without taking write ownership', async () => {
      await insert();
      const before = await snapshot();
      const result = await withTenant(
        runtime,
        tenantId,
        (tx) => readSaleReturnIncomingLabourTx(tx, { scope, enteredCode: 'S1' }),
        { isolationLevel: 'Serializable' },
      );
      expect(copy(result).status).toBe('ready');
      expect(await snapshot()).toEqual(before);
    });
  },
);
