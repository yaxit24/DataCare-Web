import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { recentVouchers } from '../src/modules/vouchers/list.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N51 milestone 1 / G28: the recent-voucher list behind every transaction screen's Load, Print and Delete.
 *
 * It filtered on company and book only, so voucher 00001 from last year or from another location appeared
 * in this session's list. Load and Delete then acted by number on the session's own year and location, which
 * is a different voucher. With the same number in two books, two years and two locations, only the
 * session's own row may be listed, and it must carry its complete identity.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'voucher-list-scope-db';
const PASSWORD = 'Voucher-List-Scope!2026';
const SECRET = 'voucher-list-scope-test-signing-secret-over-thirty-two';
const LOGIN = 'clerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const LAST_YEAR = `${startYear - 1}-${startYear}`;

(enabled ? describe : describe.skip)(
  'recent vouchers are scoped to the full voucher identity',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let cookie = '';
    const wipe = async () => {
      const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of rows)
        await owner.$executeRawUnsafe(
          `DELETE FROM "${row.table_name}" WHERE tenant_id=$1`,
          tenantId,
        );
    };
    const sale = (lcCode: string, coYear: string, coBook: string, acName: string, amount: number) =>
      owner.$executeRawUnsafe(
        `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","TOT_AMT")
       VALUES ($1,'01',$2,$3,$4,'00001',$5::date,'CUST01',$6,$7)`,
        tenantId,
        lcCode,
        coYear,
        coBook,
        `${startYear}-06-15`,
        acName,
        amount,
      );

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      // Voucher 00001 four times: this session's row, and the same number in another year, another
      // location and another book.
      await sale('01', YEAR, 'SL1', 'This session', 1000);
      await sale('01', LAST_YEAR, 'SL1', 'Last year', 2000);
      await sale('02', YEAR, 'SL1', 'Other location', 3000);
      await sale('01', YEAR, 'SL2', 'Other book', 4000);
      await owner.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'ADMIN','Y','Y','Y','N')`,
        tenantId,
        LOGIN,
        await hashPassword(PASSWORD),
      );
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
      });
      expect(login.statusCode, login.body).toBe(200);
      const value = login.headers['set-cookie'];
      cookie = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    });
    afterAll(async () => {
      if (app) await app.close();
      if (owner) await wipe();
      if (runtime) await runtime.$disconnect();
      if (owner) await owner.$disconnect();
    });

    it('lists only the row in the requested company, location, year and book, with its identity', async () => {
      const rows = await recentVouchers(
        runtime,
        { tenantId, coCode: '01', lcCode: '01', coYear: YEAR },
        'SL_DATA',
        'SL1',
      );
      expect(rows).toEqual([
        {
          coCode: '01',
          lcCode: '01',
          coYear: YEAR,
          coBook: 'SL1',
          vchNo: '00001',
          vchDate: `${startYear}-06-15`,
          vchType: '',
          acCode: 'CUST01',
          acName: 'This session',
          total: 1000,
        },
      ]);
      // The other year and the other location each see only their own row.
      expect(
        (
          await recentVouchers(
            runtime,
            { tenantId, coCode: '01', lcCode: '01', coYear: LAST_YEAR },
            'SL_DATA',
            'SL1',
          )
        ).map((r) => r.acName),
      ).toEqual(['Last year']);
      expect(
        (
          await recentVouchers(
            runtime,
            { tenantId, coCode: '01', lcCode: '02', coYear: YEAR },
            'SL_DATA',
            'SL1',
          )
        ).map((r) => r.acName),
      ).toEqual(['Other location']);
    });

    it('fails closed without a complete scope instead of listing every year and location', async () => {
      for (const scope of [
        { tenantId, coCode: '01', lcCode: '', coYear: YEAR },
        { tenantId, coCode: '01', lcCode: '01', coYear: '' },
      ])
        expect(await recentVouchers(runtime, scope, 'SL_DATA', 'SL1')).toEqual([]);
      expect(
        await recentVouchers(
          runtime,
          { tenantId, coCode: '01', lcCode: '01', coYear: YEAR },
          'SL_DATA',
          '',
        ),
      ).toEqual([]);
    });

    it('over HTTP the list takes location and year from the session, not from the query', async () => {
      const response = await app.inject({
        method: 'GET',
        url: `/vouchers/recent?table=SL_DATA&book=SL1`,
        headers: { cookie },
      });
      expect(response.statusCode, response.body).toBe(200);
      expect(
        response
          .json()
          .map((r: Record<string, unknown>) => [r.lcCode, r.coYear, r.coBook, r.acName]),
      ).toEqual([['01', YEAR, 'SL1', 'This session']]);
    });
  },
);
