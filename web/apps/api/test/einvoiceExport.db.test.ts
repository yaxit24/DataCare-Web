import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { unzipSync, strFromU8 } from 'fflate';
import { eInvoiceExportData, eInvoiceExportSheets } from '../src/modules/einvoice/einvoiceExport.js';
import { EInvoiceValidationError } from '../src/modules/einvoice/einvoice.js';
import { renderXlsx } from '../src/modules/reports/xlsx.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'einvoice-export';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = new Date('2024-06-10T00:00:00Z');

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const table of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seedSale(opts: { hsn?: string; gstNo?: string; pin?: string } = {}): Promise<void> {
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_TYPE","BOOK_SR_NAME","BOOK_NAME")
     VALUES ($1,$2,$3,'025','T','TS','Tax Sale')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GSTNO","AC_PIN","AC_STATE","AC_ADD1","AC_ADD2","AC_CITY","AC_MOBILE","AC_EMAIL")
     VALUES ($1,$2,$3,'CUST','GST Buyer',$4,$5,'24','Line 1','Line 2','Surat','9999999999','buyer@example.test')`,
    TENANT,
    CO,
    LC,
    opts.gstNo ?? '24ABCDE1234F1Z5',
    opts.pin ?? '395003',
  );
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","HSN_CODE","UNIT_NAME")
     VALUES ($1,$2,'GOLD','Gold Ring','G',$3,'GMS')`,
    TENANT,
    CO,
    opts.hsn ?? '711319',
  );
  await exec(
    `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","BILL_NO","AC_CODE","AC_NAME","NET_AMT","SGST_TAX","CGST_TAX","IGST_TAX","TAX_PRC","TOT_AMT")
     VALUES ($1,$2,$3,$4,'025','00001',$5,'TS-1','CUST','GST Buyer',1000,15,15,0,3,1030)`,
    TENANT,
    CO,
    LC,
    YEAR,
    DAY,
  );
  await exec(
    `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","IT_CODE","ITM_NWT","ITM_RATE","ITM_AMT","NET_AMT","TAX_PRC","IT_TAX_AMT")
     VALUES ($1,$2,$3,$4,'025','00001',1,$5,'CUST','GOLD',10,100,1000,1000,3,30)`,
    TENANT,
    CO,
    LC,
    YEAR,
    DAY,
  );
}

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('desktop e-invoice Excel export', () => {
  beforeEach(async () => {
    await wipe();
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('maps the UT_E_INVOICE header/detail grids into the einvoice and Items workbook sheets', async () => {
    await seedSale();

    const data = await eInvoiceExportData(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      fromDate: '2024-06-01',
      toDate: '2024-06-30',
    });

    expect(data.headers).toHaveLength(1);
    expect(data.items).toHaveLength(1);
    expect(data.headers[0]).toMatchObject({
      sType: 'B2B',
      dockType: 'Tax Invoice',
      dockNo: 'TS-00001',
      byGstn: '24ABCDE1234F1Z5',
      byLglName: 'GST Buyer',
      totTaxableVal: 1000,
      sgstAmt: 15,
      cgstAmt: 15,
      igstAmt: 0,
      totInvoiceVal: 1030,
    });
    expect(data.items[0]).toMatchObject({
      dockType: 'Tax Invoice',
      dockNo: 'TS-00001',
      slNo: 1,
      product: 'Gold Ring',
      hsnCode: '711319',
      qty: 10,
      unit: 'GRAMMES',
      unitRate: 100,
      taxableVal: 1000,
      sgstAmt: 15,
      cgstAmt: 15,
      igstAmt: 0,
      itemTotal: 1030,
    });

    const workbook = await renderXlsx(eInvoiceExportSheets(data), 'e-invoice');
    const files = unzipSync(new Uint8Array(workbook.buffer));
    const all = Object.values(files)
      .map((v) => strFromU8(v))
      .join('\n');
    expect(all).toContain('einvoice');
    expect(all).toContain('Items');
    expect(all).toContain('TS-00001');
    expect(all).toContain('711319');
  });

  it('fails closed like the desktop when an item HSN is missing', async () => {
    await seedSale({ hsn: '' });
    await expect(
      eInvoiceExportData(runtime, {
        tenantId: TENANT,
        coCode: CO,
        lcCode: LC,
        coYear: YEAR,
        fromDate: '2024-06-01',
        toDate: '2024-06-30',
      }),
    ).rejects.toThrow(EInvoiceValidationError);
  });
});
