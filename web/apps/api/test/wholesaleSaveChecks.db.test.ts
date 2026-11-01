import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import {
  assertWholesaleItemCodes,
  WHOLESALE_MESSAGES,
} from '../src/modules/sales/wholesaleSaveChecks.js';
import { DESKTOP_MESSAGES } from '../src/modules/shared/desktopMessages.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * TR_WH_SALE's save refusals (TR_WH_SALE.cs:12779-12896) through POST/PUT /wholesale-sales on a web-provisioned
 * company. Each refusal must answer 400 with the desktop's own text and leave every table of the voucher family,
 * the hidden-number table and the tag's stock exactly as they were.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'wh-save-checks-db';
const PASSWORD = 'Wholesale-Checks!2026';
const SECRET = 'wholesale-checks-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const TABLES = [
  'RATE_CUT_DATA',
  'RATE_CUT_ISU',
  'RATE_CUT_REC',
  'MAIN_STOCK',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'TEMP_BOOK_DATA',
];

describe('assertWholesaleItemCodes', () => {
  it('refuses an item-less row with weight, labour, other or MRP, by its row number', () => {
    for (const field of ['grossWt', 'lbrAmt', 'othAmt', 'mrp'] as const)
      expect(() => assertWholesaleItemCodes([{ itCode: 'X' }, { [field]: 5 }])).toThrow(
        WHOLESALE_MESSAGES.itemCode(2),
      );
  });
  it('accepts a row with an item, a tag, or nothing that makes a value', () => {
    expect(() =>
      assertWholesaleItemCodes([
        { itCode: 'X', grossWt: 5 },
        { tagNo: 'T1', grossWt: 5 },
        { rate: 6500 } as never,
      ]),
    ).not.toThrow();
  });
});

(enabled ? describe : describe.skip)('TR_WH_SALE save refusals through HTTP', () => {
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
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const footprint = async () => {
    const out: Record<string, unknown[]> = {};
    for (const table of TABLES)
      out[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text AS r FROM "${table}" t WHERE tenant_id=$1 ORDER BY 1`,
        tenantId,
      );
    return out;
  };
  const post = (payload: unknown) =>
    app.inject({
      method: 'POST',
      url: '/wholesale-sales',
      headers: { cookie },
      payload: payload as any,
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','WHCUST','Wholesale Customer','10')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
       VALUES ($1,'01','LR916','L RING 916','G','LR','G'),($1,'01','999','999 GOLD','G','FN','G')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME",
         "INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","TBL_CODE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',1,$3::date,'PURCHASE','I','CHK00001',100312000101,'LR916',1,10,10,91.6,9.16,'001','N')`,
      tenantId,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',2,1,$3::date,'LR916','CHK00001',100312000101,'P','+',1,1,10,10)`,
      tenantId,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01','wholesaler',$2,'ADMIN','Y','Y','Y','N')`,
      tenantId,
      await hashPassword(PASSWORD),
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: {
        coCode: '01',
        lcCode: '01',
        coYear: YEAR,
        loginName: 'wholesaler',
        password: PASSWORD,
      },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });
  beforeEach(async () => {
    await exec(`UPDATE "AC_MAST" SET "DEFAULTER_AC"=NULL WHERE tenant_id=$1`, tenantId);
    await exec(
      `UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"=NULL,"LOCK_DATE"=NULL WHERE tenant_id=$1`,
      tenantId,
    );
    await exec(`UPDATE "CO_MAST" SET "CO_TYPE"=NULL WHERE tenant_id=$1`, tenantId);
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  // 9.160 fine cut at 6500 = Math.Round(59540); paid 50000 in cash leaves 9540 outstanding.
  const sale = (extra: Record<string, unknown> = {}) => ({
    coBook: 'WHS',
    vchDate: DAY,
    acCode: 'WHCUST',
    itType: 'G',
    lines: [{ tagNo: 'CHK00001' }],
    fineRate: 6500,
    settleCrFine: 9.16,
    pay: { cash: 59540 },
    ...extra,
  });
  const refuses = async (payload: unknown, message: string) => {
    const before = await footprint();
    const response = await post(payload);
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().message).toBe(message);
    expect(await footprint()).toEqual(before);
  };

  it('refuses a defaulter left owing, and saves a defaulter paid in full', async () => {
    await exec(
      `UPDATE "AC_MAST" SET "DEFAULTER_AC"='Y' WHERE tenant_id=$1 AND "AC_CODE"='WHCUST'`,
      tenantId,
    );
    await refuses(sale({ pay: { cash: 50000 } }), DESKTOP_MESSAGES.PARTY_IN_DEFAULTER_LIST);
    const paid = await post(sale());
    expect(paid.statusCode, paid.body).toBe(201);
    const deleted = await app.inject({
      method: 'DELETE',
      url: `/wholesale-sales/${paid.json().vchNo}`,
      headers: { cookie },
      payload: { book: 'WHS' } as any,
    });
    expect(deleted.statusCode, deleted.body).toBe(200);
  });
  it('refuses a missing employee when CO_SET.EMP_CODE_MANDATORY is Y', async () => {
    await exec(`UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"='Y' WHERE tenant_id=$1`, tenantId);
    await refuses(sale(), WHOLESALE_MESSAGES.employee);
  });
  it('refuses a new voucher in a company of type B', async () => {
    await exec(`UPDATE "CO_MAST" SET "CO_TYPE"='B' WHERE tenant_id=$1`, tenantId);
    await refuses(sale(), WHOLESALE_MESSAGES.companyTypeB);
  });
  it('refuses a cheque or a card amount without its bank account', async () => {
    await refuses(sale({ pay: { cash: 29540, chq: 30000 } }), DESKTOP_MESSAGES.CHEQUE_WITHOUT_BANK);
    await refuses(sale({ pay: { cash: 29540, card: 30000 } }), DESKTOP_MESSAGES.CARD_WITHOUT_BANK);
  });
  it('refuses a date outside the year, and a date on or before the lock date, with the desktop texts', async () => {
    await refuses(sale({ vchDate: `${startYear}-03-31` }), WHOLESALE_MESSAGES.outsideYear);
    await exec(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$2 WHERE tenant_id=$1`,
      tenantId,
      `${startYear}-06-20`,
    );
    await refuses(sale(), WHOLESALE_MESSAGES.lockDate(`${startYear}-06-20`));
    // The year comes first (TR_WH_SALE.cs:12833 before :12839).
    await refuses(sale({ vchDate: `${startYear}-03-31` }), WHOLESALE_MESSAGES.outsideYear);
  });
  it('refuses a receive row with weight but no item code, by its row number', async () => {
    await refuses(
      sale({ receivedLines: [{ grossWt: 5, touch: 100 }] }),
      WHOLESALE_MESSAGES.itemCode(1),
    );
  });
  it('prints WhSalesBill: party, tag, the Sales band and the opening/closing balances', async () => {
    const created = await post(sale({ pay: { cash: 50000, kasar: 40 } }));
    expect(created.statusCode, created.body).toBe(201);
    const vchNo = String(created.json().vchNo).padStart(5, '0');
    const printed = await app.inject({
      method: 'GET',
      url: `/wholesale-sales/${vchNo}/print?coBook=WHS&format=html`,
      headers: { cookie },
    });
    expect(printed.statusCode, printed.body).toBe(200);
    const html = printed.body;
    for (const expected of ['Wholesale Customer', 'CHK00001', '59,540.00', '50,000.00', '9,500.00'])
      expect(html).toContain(expected);
    // The party owes 9,500 after the voucher and nothing before it in this fresh company.
    expect(html).toMatch(/Oppning Bal :<\/td><td class="r">0\.00<\/td><td>Dr/);
    expect(html).toMatch(/Closing Bal :<\/td><td class="r">9,500\.00<\/td><td>Dr/);
    const deleted = await app.inject({
      method: 'DELETE',
      url: `/wholesale-sales/${vchNo}`,
      headers: { cookie },
      payload: { book: 'WHS' } as any,
    });
    expect(deleted.statusCode, deleted.body).toBe(200);
  });
});
