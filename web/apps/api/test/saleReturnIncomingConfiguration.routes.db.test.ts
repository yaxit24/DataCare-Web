import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'r8-return-config-http';
const otherTenant = 'r8-return-config-other';
const selected = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R81' };
const password = 'Return-Config-Route!2026';
type Role = 'view' | 'unrelated' | 'other';
const businessTables = [
  'SL_DATA',
  'SL_DETL',
  'SL_IDTL',
  'SL_DETL_RTN',
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'BILL_OS_DATA',
  'ROJ_MEL_DATA',
  'DM_DATA',
  'REMARK_DATA',
  'SRNO_MAST',
  'CO_SET',
  'CO_SET_NEW',
  'COL_MAST',
  'BOOK_DATA',
  'YEAR_MAST',
];
const query = (values: Record<string, unknown>) =>
  new URLSearchParams(
    Object.entries(values)
      .filter(([, value]) => value !== undefined)
      .map(([key, value]): [string, string] => [key, String(value)]),
  ).toString();

(enabled ? describe : describe.skip)(
  'incoming Return calculation configuration HTTP boundary',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    const cookies: Partial<Record<Role, string>> = {};
    const sql = (q: string, ...p: unknown[]) => owner.$executeRawUnsafe(q, ...p);
    const endpoint = (values: Record<string, unknown> = selected) =>
      `/sales-returns/incoming-calculation-configuration?${query(values)}`;
    const call = (url: string, role: Role | 'anonymous' = 'view') =>
      app.inject({
        method: 'GET',
        url,
        headers: role === 'anonymous' ? {} : { cookie: cookies[role] ?? '' },
      });
    const read = async (overrides: Record<string, unknown> = {}, role: Role = 'view') => {
      const response = await call(endpoint({ ...selected, ...overrides }), role);
      expect(response.statusCode, response.body).toBe(200);
      expect(response.headers['cache-control']).toBe('no-store');
      return response.json();
    };
    async function clean(all = false) {
      for (const tenant of [tenantId, otherTenant])
        for (const table of all
          ? [
              'audit_log',
              'auth_session',
              ...businessTables,
              'USER_SET',
              'LOGIN_MAST',
              'LOCT_MAST',
              'CO_MAST',
            ]
          : ['CO_SET', 'CO_SET_NEW', 'COL_MAST'])
          await sql(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
    }
    async function snapshot() {
      const result: Record<string, unknown> = {};
      for (const table of businessTables)
        result[table] = await owner.$queryRawUnsafe(
          `SELECT (SELECT jsonb_object_agg(e.key,e.value) FROM jsonb_each_text(to_jsonb(t)) e) raw
         FROM "${table}" t WHERE tenant_id IN ($1,$2) ORDER BY to_jsonb(t)::text`,
          tenantId,
          otherTenant,
        );
      return result;
    }
    async function seedSettings() {
      await clean();
      for (const tenant of [tenantId, otherTenant]) {
        await sql(
          `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","SL_AMT_TYPE","LBR_ROF","LBR_RATE_GEN","ALL_ROF_REMOVE","LBR_TYPE")
        VALUES($1,'01','F',4,'Y','N','G')`,
          tenant,
        );
        await sql(
          `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,'01','N')`,
          tenant,
        );
        await sql(
          `INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO","COL_RPT")
        VALUES($1,'01','SALES RETURNE','Fine',$2,'N','N'),
        ($1,'01','SALES','Fine','Sale fine','Y','Y'),
        ($1,'00','SALES RETURNE','Rate','Template only','N','N')`,
          tenant,
          tenant === tenantId ? 'Return fine' : 'Other business fine',
        );
      }
    }
    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await clean(true);
      const hashed = await hashPassword(password);
      for (const tenant of [tenantId, otherTenant]) {
        await sql(
          `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES($1,'01','Return configuration','01')`,
          tenant,
        );
        await sql(
          `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES($1,'01','01','Main'),($1,'01','02','Other')`,
          tenant,
        );
        await sql(
          `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
        VALUES($1,'01','2024-2025','2024-04-01','2025-03-31'),($1,'01','2023-2024','2023-04-01','2024-03-31')`,
          tenant,
        );
        await sql(
          `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME") VALUES
        ($1,'01','01','R81','Shop return','SALES RETURNE','I','Y','SL_DATA'),
        ($1,'01','01','R82','Second return','SALES RETURNE','I','Y','SL_DATA'),
        ($1,'01','01','S81','Sale','SALES','O','Y','SL_DATA'),
        ($1,'01','01','R83','Inactive return','SALES RETURNE','I','N','SL_DATA'),
        ($1,'01','01','R84','Wrong table','SALES RETURNE','I','Y','PR_DATA'),
        ($1,'01','01','R85','Wrong direction','SALES RETURNE','O','Y','SL_DATA'),
        ($1,'01','01','R86','Duplicate A','SALES RETURNE','I','Y','SL_DATA'),
        ($1,'01','01','R86','Duplicate B','SALES RETURNE','I','Y','SL_DATA')`,
          tenant,
        );
        for (const [name, form] of [
          ['view', 'Sales Return'],
          ['unrelated', 'Sales'],
        ] as const) {
          await sql(
            `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
          VALUES($1,'01',$2,$3,'USER','N','N','N','N')`,
            tenant,
            name,
            hashed,
          );
          await sql(
            `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
          VALUES($1,'01','01',$2,'Sales',$3,'Y','N','N','N')`,
            tenant,
            name,
            form,
          );
        }
      }
      app = await buildApp({
        prisma: runtime,
        secret: 'return-configuration-route-secret-over-thirty-two-characters',
        secureCookies: false,
      });
      for (const role of ['view', 'unrelated', 'other'] as const) {
        const response = await app.inject({
          method: 'POST',
          url: '/auth/login',
          headers: { 'x-tenant-id': role === 'other' ? otherTenant : tenantId },
          payload: {
            coCode: '01',
            lcCode: '01',
            coYear: selected.coYear,
            loginName: role === 'other' ? 'view' : role,
            password,
          },
        });
        expect(response.statusCode, response.body).toBe(200);
        const headers = response.headers['set-cookie'];
        cookies[role] = (Array.isArray(headers) ? headers : [headers ?? ''])
          .map((value) => value.split(';', 1)[0])
          .join('; ');
      }
    });
    beforeEach(seedSettings);
    afterAll(async () => {
      if (app) await app.close();
      if (owner) await clean(true);
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('exposes source-derived settings to a view-only user without numeric write authority', async () => {
      const dto = await read();
      expect(dto.scope).toEqual(selected);
      expect(dto).toMatchObject({
        form: 'TR_SALE_RTN',
        grid: 'MSG_PR',
        columnFamily: 'SALES RETURNE',
        widthMode: 'source-zero-predicate',
        policy: {
          saleAmountType: 'F',
          labourRoundingDecimals: 0,
          labourIncludesGhat: false,
          generateLabourRate: true,
          fineColumnWidth: 0,
        },
        newRowDefaults: { labourType: 'G' },
        capabilities: { canCalculate: true, canSaveNumeric: false },
      });
      expect(dto.version).toMatch(/^[a-f0-9]{64}$/);
      const fine = dto.columns.find((column: any) => column.sourceColumn === 18);
      expect(fine).toMatchObject({
        id: 'x13.primary-incoming.c18',
        label: 'Return fine',
        widthState: 'zero',
        configured: true,
      });
      expect(dto.columns.find((column: any) => column.sourceColumn === 19)).toMatchObject({
        label: 'Rate',
        widthState: 'nonzero',
        configured: false,
      });
      expect(Object.keys(dto.rawSettings).sort()).toEqual(
        [
          'CO_SET.ALL_ROF_REMOVE',
          'CO_SET.LBR_RATE_GEN',
          'CO_SET.LBR_ROF',
          'CO_SET.LBR_TYPE',
          'CO_SET.SL_AMT_TYPE',
          'CO_SET_NEW.LBR_WITH_GHT',
        ].sort(),
      );
      expect(dto.rawSettings['CO_SET.LBR_ROF']).toBe('4');
      expect(JSON.stringify(dto)).not.toMatch(/REF_NO|LOGIN_PWD|row_id|physicalId|"tenantId"/);
    });
    it('requires fresh owning-form rights and the selected company, branch and year', async () => {
      expect((await call(endpoint(), 'anonymous')).statusCode).toBe(401);
      expect((await call(endpoint(), 'unrelated')).statusCode).toBe(403);
      for (const override of [{ coCode: '02' }, { lcCode: '02' }, { coYear: '2023-2024' }])
        expect((await call(endpoint({ ...selected, ...override }))).statusCode).toBe(409);
      await sql(
        `UPDATE "USER_SET" SET "FRM_VIEW"='N' WHERE tenant_id=$1 AND "USER_NAME"='view'`,
        tenantId,
      );
      expect((await call(endpoint())).statusCode).toBe(403);
      await sql(
        `UPDATE "USER_SET" SET "FRM_VIEW"='Y' WHERE tenant_id=$1 AND "USER_NAME"='view'`,
        tenantId,
      );
    });
    it('requires all four scalar identity fields and rejects client calculation overrides', async () => {
      for (const key of Object.keys(selected))
        expect((await call(endpoint({ ...selected, [key]: undefined }))).statusCode, key).toBe(400);
      for (const extra of [
        { tenantId: otherTenant },
        { fineColumnWidth: 0 },
        { policy: '{}' },
        { edition: 'A' },
        { columnId: 'x13.primary-incoming.c18' },
        { caches: '{}' },
        { version: 'anything' },
        { sourceBook: 'S81' },
      ])
        expect((await call(endpoint({ ...selected, ...extra }))).statusCode).toBe(400);
      expect((await call(endpoint() + '&coBook=R82')).statusCode).toBe(400);
      expect((await call(endpoint({ ...selected, coBook: '   ' }))).statusCode).toBe(400);
    });
    it('rejects missing, wrong-family, inactive, duplicate, wrong-direction and wrong-table books', async () => {
      for (const coBook of ['R80', 'S81', 'R83', 'R84', 'R85', 'R86']) {
        const response = await call(endpoint({ ...selected, coBook }));
        // The shared business-scope guard rejects unavailable books before the resolver.
        expect(response.statusCode, `${coBook}: ${response.body}`).toBe(
          ['R80', 'R83'].includes(coBook) ? 409 : 422,
        );
        if (['R80', 'R83'].includes(coBook)) expect(response.json().error).toBe('book-unavailable');
      }
    });
    it('versions each target book and authenticated tenant separately while sharing company-family settings', async () => {
      const first = await read();
      const second = await read({ coBook: 'R82' });
      expect(second.policy).toEqual(first.policy);
      expect(second.version).not.toBe(first.version);
      const other = await read({}, 'other');
      expect(other.columns.find((column: any) => column.sourceColumn === 18).label).toBe(
        'Other business fine',
      );
      expect(other.version).not.toBe(first.version);
      expect((await read()).version).toBe(first.version);
    });
    it('reports missing and duplicate configuration as readable diagnostics without guessed defaults', async () => {
      await sql(`DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1`, tenantId);
      const missing = await read();
      expect(missing.policy).toBeNull();
      expect(missing.capabilities).toMatchObject({ canCalculate: false, canSaveNumeric: false });
      expect(missing.diagnostics.some((item: any) => item.blocking)).toBe(true);
      await seedSettings();
      await sql(
        `INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO") VALUES($1,'01','SALES RETURNE','Fine','Return fine','N')`,
        tenantId,
      );
      const duplicate = await read();
      expect(duplicate.policy).toBeNull();
      expect(duplicate.capabilities.canCalculate).toBe(false);
      expect(duplicate.version).not.toBe(missing.version);
    });
    it('retains noncanonical raw settings and applies the final precision override in source order', async () => {
      await sql(`UPDATE "CO_SET" SET "ALL_ROF_REMOVE"='Y' WHERE tenant_id=$1`, tenantId);
      expect((await read()).policy.labourRoundingDecimals).toBe(2);
      await sql(`UPDATE "CO_SET" SET "SL_AMT_TYPE"=' f ' WHERE tenant_id=$1`, tenantId);
      const malformed = await read();
      expect(malformed.rawSettings['CO_SET.SL_AMT_TYPE']).toBe(' f ');
      expect(malformed.policy).toBeNull();
      expect(malformed.capabilities.canCalculate).toBe(false);
    });
    it('does not write settings, vouchers, stock, numbering or ledger companions during reads', async () => {
      const before = await snapshot();
      await read();
      await read({ coBook: 'R82' });
      await read({}, 'other');
      expect(await snapshot()).toEqual(before);
    });
    it('invalidates observations after physical A-to-B-to-A and previously absent override insertion', async () => {
      const before = await read();
      await sql(
        `UPDATE "COL_MAST" SET "COL_NEW_NAME"='Changed' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='SALES RETURNE'`,
        tenantId,
      );
      const changed = await read();
      expect(changed.version).not.toBe(before.version);
      await sql(
        `UPDATE "COL_MAST" SET "COL_NEW_NAME"='Return fine' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "BOOK_NAME"='SALES RETURNE'`,
        tenantId,
      );
      const restored = await read();
      expect(restored.version).not.toBe(before.version);
      expect(restored.policy).toEqual(before.policy);
      await sql(
        `INSERT INTO "COL_MAST"(tenant_id,"CO_CODE","BOOK_NAME","COL_NAME","COL_NEW_NAME","YES_NO") VALUES($1,'01','SALES RETURNE','Rate','Rate','N')`,
        tenantId,
      );
      const inserted = await read();
      expect(inserted.version).not.toBe(restored.version);
      expect(inserted.columns.find((column: any) => column.sourceColumn === 19).widthState).toBe(
        'zero',
      );
    });
  },
);
