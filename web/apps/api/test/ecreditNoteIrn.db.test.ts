import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { submitIrnForCreditNote } from '../src/modules/einvoice/einvoice.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const GSP_KEYS = ['GSP_ASPID', 'GSP_PASSWORD', 'GSP_GSTIN', 'GSP_USER', 'GSP_EINV_PWD', 'GSP_SANDBOX'] as const;
const originalEnv = Object.fromEntries(['NODE_ENV', ...GSP_KEYS].map((key) => [key, process.env[key]]));

databaseDescribe('TR_SL_EBILL E CrntNote IRN parity', () => {
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
  });
  const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
  const tenantId = 'e-crntnote-irn-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const DAY = new Date('2024-06-10T00:00:00Z');
  const scope = (coBook = '146') => ({ tenantId, coCode: CO, lcCode: LC, coYear: YEAR, coBook }) as any;

  const tables = ['E_DATA', 'SL_DETL', 'SL_DATA', 'BOOK_DATA', 'ITEM_MAST', 'AC_MAST', 'CO_MAST'];

  const exec = (sql: string, ...params: unknown[]) =>
    withTenant(owner, tenantId, (tx: any) => tx.$executeRawUnsafe(sql, ...params));

  async function clean() {
    for (const table of tables) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
    }
  }

  async function seed() {
    await exec(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","CO_SNAME","CO_ADD1","CO_CITY","CO_PIN","CO_STATE_CODE","CO_GST_NO")
       VALUES ($1,$2,'Datagenex Jewels','DGX','Ring Road','Surat','395003','24','24ABCDE1234F1Z5')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","BOOK_INOUT","BOOK_SR_NAME","MAIN_BOOK","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
       VALUES ($1,$2,$3,'146','E Credit Note','ECRNT','I','CN','E CRNT','Y','SL_DATA','SL_DETL'),
              ($1,$2,$3,'SAL','Sales','SALE','O','SL','SALES','Y','SL_DATA','SL_DETL')`,
      tenantId,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GSTNO","AC_STATE","AC_CITY","AC_PIN","AC_ADD1")
       VALUES ($1,$2,$3,'PARTY','GST Buyer','27ABCDE1234F1Z5','27','Mumbai','400001','Buyer Lane')`,
      tenantId,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","HSN_CODE","UNIT_NAME")
       VALUES ($1,$2,'GOLD','Gold Ring','G','711319','GMS')`,
      tenantId,
      CO,
    );
    await exec(
      `INSERT INTO "SL_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","BILL_NO",
         "AC_CODE","AC_NAME","AC_GST_TYPE","NET_AMT","TAX_PRC","TAX_AMT","IGST_TAX","CGST_TAX","SGST_TAX","ROF_AMT","TOT_AMT")
       VALUES ($1,$2,$3,$4,'146','00001',$5,'CN-legacy','PARTY','GST Buyer','I',1000,3,30,30,0,0,0,1030),
              ($1,$2,$3,$4,'SAL','00001',$5,'SL-legacy','PARTY','GST Buyer','I',1000,3,30,30,0,0,0,1030)`,
      tenantId,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "SL_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE",
         "IT_CODE","ITM_NWT","ITM_RATE","ITM_AMT","NET_AMT","TAX_PRC","ITM_IGST_AMT","GRAND_TOTAL")
       VALUES ($1,$2,$3,$4,'146','00001',1,$5,'PARTY','GOLD',10,100,1000,1000,3,30,1030),
              ($1,$2,$3,$4,'SAL','00001',1,$5,'PARTY','GOLD',10,100,1000,1000,3,30,1030)`,
      tenantId,
      CO,
      LC,
      YEAR,
      DAY,
    );
  }

  beforeEach(async () => {
    process.env.NODE_ENV = 'test';
    for (const key of GSP_KEYS) delete process.env[key];
    await clean();
    await seed();
  });

  afterAll(async () => {
    await clean();
    for (const [key, value] of Object.entries(originalEnv)) {
      if (value === undefined) delete process.env[key];
      else process.env[key] = value;
    }
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('generates a credit-note IRN and persists it only on the E CRNT voucher scope', async () => {
    const result = await submitIrnForCreditNote(runtime, scope(), { vchNo: '00001' });

    expect(result.mode).toBe('fake-development');
    expect(result.Irn).toHaveLength(64);
    expect(result.AckNo).toMatch(/^\d{12}$/);

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK","VCH_NO","IRN_NO","ACK_NO" FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "VCH_NO"='00001'
        ORDER BY "CO_BOOK"`,
      tenantId,
      CO,
      LC,
      YEAR,
    )) as Array<{ CO_BOOK: string; VCH_NO: string; IRN_NO: string | null; ACK_NO: string | null }>;

    expect(rows).toEqual([
      { CO_BOOK: '146', VCH_NO: '00001', IRN_NO: result.Irn, ACK_NO: result.AckNo },
      { CO_BOOK: 'SAL', VCH_NO: '00001', IRN_NO: null, ACK_NO: null },
    ]);

    const eRows = (await owner.$queryRawUnsafe(
      `SELECT "CO_BOOK","VCH_NO","IRN_NO","ACK_NO",octet_length("QR_DATA") AS "qrLen" FROM "E_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        ORDER BY "CO_BOOK"`,
      tenantId,
      CO,
      LC,
      YEAR,
    )) as Array<{ CO_BOOK: string; VCH_NO: string; IRN_NO: string | null; ACK_NO: string | null; qrLen: number }>;

    expect(eRows).toHaveLength(1);
    expect(eRows[0]).toMatchObject({ CO_BOOK: '146', VCH_NO: '00001', IRN_NO: result.Irn, ACK_NO: result.AckNo });
    expect(Number(eRows[0]!.qrLen)).toBeGreaterThan(0);
  });

  it('rejects a normal sales book when the E CrntNote workflow is requested', async () => {
    await expect(submitIrnForCreditNote(runtime, scope('SAL'), { vchNo: '00001' })).rejects.toThrow(
      "expected BOOK_DATA.MAIN_BOOK='E CRNT'",
    );
  });
});
