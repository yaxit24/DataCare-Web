import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-19 architect decision Q10: GSTR-3B 3.1(a) counts every TAX_SIGN '+' row as RP_GST does (RP_GST.cs:3540-3561),
 * so a purchase return - written 'P'/'+' (Ac_Tax.cs:233; a debit note, an outward supply of the returned goods) - is
 * in it. The return is made by the real Purchase Return writer over HTTP; the expectation is worked by hand.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'gst-3b-purchase-return';
const PASSWORD = 'Gst-Purchase-Return!2026';
const SECRET = 'gst-purchase-return-route-signing-secret-over-32';
const LOGIN = 'gstreturnclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

(enabled ? describe : describe.skip)(
  'GSTR-3B counts a purchase return in 3.1(a) (WP-19 Q10)',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    let cookie = '';
    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
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
    const request = (method: 'GET' | 'POST', url: string, payload?: unknown) =>
      app.inject({
        method,
        url,
        headers: { cookie },
        ...(payload === undefined ? {} : { payload: payload as any }),
      });

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe();
      await seedCompany(runtime, tenantId, '01');
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','SUPP3B','Return Supplier','L','40')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC")
       VALUES ($1,'01','G01','Gold','PURCHASE')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","OTH_DETL_POSTING")
       VALUES ($1,'01','GOLD','Gold Ornament','G','G01','Y')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01','348','Purchase Return 348','P348','PURC RETURN','O','Y','PR_DATA')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,'01','01','348',1,'PURCHASE','PURC RETURN','O'),
              ($1,'01','01','348',2,'CASH','PURC RETURN','O'),
              ($1,'01','01','348',3,'ROUNDOFF','PURC RETURN','O')`,
        tenantId,
      );
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        tenantId,
        LOGIN,
        await hashPassword(PASSWORD),
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Purchase','Purchase Return','Y','Y','Y','Y'),
             ($1,'01','01',$2,'Report','Gst Report','Y','N','N','Y')`,
        tenantId,
        LOGIN,
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

    it('adds the purchase return to 3.1(a), the 3.1 total and 6.1 with the desktop arithmetic', async () => {
      const saved = await request('POST', '/purchase-returns', {
        coBook: '348',
        vchDate: DAY,
        acCode: 'SUPP3B',
        acName: 'Return Supplier',
        taxRatePct: 3,
        interState: false,
        lines: [{ itCode: 'GOLD', pcs: 1, grossWt: 5, netWt: 5, touch: 90, metalAmount: 450 }],
      });
      expect(saved.statusCode, saved.body).toBe(201);
      const vchNo = String(saved.json().vchNo).padStart(5, '0');
      // The writer's TAX_DATA rows: P/+ (Ac_Tax.cs:233), the local 3% split in two halves of 6.75 on 450.
      const taxRows = (await owner.$queryRawUnsafe(
        `SELECT "TRAN_TYPE" tran,"TAX_SIGN" sign,"TAX_TYPE" type,"NET_AMT"::float net,"TAX_AMT"::float tax
         FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='348' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
        tenantId,
        vchNo,
      )) as Array<{ tran: string; sign: string; type: string; net: number; tax: number }>;
      expect(taxRows).toEqual([
        { tran: 'P', sign: '+', type: 'SGST', net: 450, tax: 6.75 },
        { tran: 'P', sign: '+', type: 'CGST', net: 450, tax: 6.75 },
      ]);

      const report = await request(
        'GET',
        `/reports/gst-report?view=gstr3b&fromDate=${startYear}-04-01&toDate=${DAY}&partyCode=SUPP3B`,
      );
      expect(report.statusCode, report.body).toBe(200);
      const rows = report.json().rows as Array<Record<string, string>>;
      const at = (table: string, code: string) =>
        rows.find((row) => row.table === table && row.code === code)!;
      // RP_GST.cs:3540: SUM(IIF(TAX_TYPE IN ('IGST','SGST'),NET_AMT,0)) = 450 (the SGST row only), CGST 6.75, SGST 6.75.
      expect(at('3.1', '(a)')).toMatchObject({
        taxableValue: '450.00',
        igstAmount: '0.00',
        cgstAmount: '6.75',
        sgstAmount: '6.75',
      });
      // It is not reverse charge and not ITC (sign '+'), so (d) and 4(A)(5) have no rows: blank, as Format(NULL).
      expect(at('3.1', '(d)').taxableValue).toBe('');
      expect(at('4(A)', '(5)').taxableValue).toBe('');
      expect(rows[5]).toMatchObject({
        taxableValue: '450.00',
        cgstAmount: '6.75',
        sgstAmount: '6.75',
      });
      expect(at('6.1', 'Centrel Tax').nature).toBe('6.75');
      expect(at('6.1', 'State/Ut Tax').nature).toBe('6.75');
    });
  },
);
