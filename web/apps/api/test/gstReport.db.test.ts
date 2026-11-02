import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { strFromU8, unzipSync } from 'fflate';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import type { PdfRenderer } from '../src/modules/reports/render.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'gst-report-db';
const OTHER_TENANT = 'gst-report-other';
const PASSWORD = 'Gst-Report!2026';
const SECRET = 'gst-report-test-signing-secret-over-thirty-two-characters';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const FROM = `${startYear}-04-01`;
const TO = `${startYear}-04-30`;
const DAY = `${startYear}-04-05`;

class CapturingRenderer implements PdfRenderer {
  html: string[] = [];
  async render(html: string): Promise<Buffer> {
    this.html.push(html);
    return Buffer.from('%PDF-1.4\n%gst-report\n%%EOF');
  }
}

(enabled ? describe : describe.skip)('RP_GST canonical HTTP report under forced RLS', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const renderer = new CapturingRenderer();
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async (tenant: string) => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows) {
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
    }
  };
  const login = async (name: string) => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': TENANT },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const values = response.headers['set-cookie'];
    return (Array.isArray(values) ? values : [values ?? ''])
      .map((value) => value.split(';', 1)[0])
      .join('; ');
  };
  const get = (user: string, url: string) =>
    app.inject({ method: 'GET', url, headers: { cookie: cookies[user]! } });
  const url = (view: string, section?: string, extra = '') =>
    `/reports/gst-report?view=${view}${section ? `&section=${section}` : ''}&fromDate=${FROM}&toDate=${TO}${extra}`;

  const insertTax = async (tenant: string, row: Record<string, unknown>) => {
    await exec(
      `INSERT INTO "TAX_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","BOOK_NAME","TRAN_TYPE","VCH_DATE","AC_CODE","TAX_CODE","TAX_TYPE","TAX_PRC","NET_AMT","TAX_AMT","DISC_AMT","TOT_AMT","TAX_SIGN","R_CHARG","BILL_NO","BILL_DATE","BILL_DBCD")
       VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10::date,$11,$12,$13,$14,$15,$16,$17,$18,$19,$20,$21,$22::date,$23)`,
      tenant,
      row.coCode ?? '01',
      row.lcCode ?? '01',
      row.coYear ?? YEAR,
      row.coBook,
      row.vchNo,
      row.srNo ?? 1,
      row.bookName,
      row.tranType ?? 'S',
      row.vchDate ?? DAY,
      row.acCode,
      row.taxCode ?? '91',
      row.taxType ?? null,
      row.taxRate ?? 3,
      row.netAmount ?? 0,
      row.taxAmount ?? 0,
      row.discountAmount ?? 0,
      row.invoiceValue ?? 0,
      row.taxSign ?? '+',
      row.reverseCharge ?? 'N',
      row.billNo ?? '',
      row.billDate ?? DAY,
      row.billBook ?? '',
    );
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe(TENANT);
    await wipe(OTHER_TENANT);
    await seedCompany(runtime, TENANT, '01', { coName: 'GST Test Jewellers', lcCode: '01' });
    await seedCompany(runtime, OTHER_TENANT, '01', { coName: 'Other Tenant', lcCode: '01' });
    await exec(
      `UPDATE "CO_MAST" SET "CO_STATE"='Gujarat',"CO_STATE_CODE"='24' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
    );
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES($1,'01','02','Other Location')`,
      TENANT,
    );
    await exec(
      `INSERT INTO "STATE_MAST"(tenant_id,"STATE_CODE","STATE_NAME") VALUES
       ($1,'24','Gujarat'),($1,'27','Maharashtra')`,
      TENANT,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GSTNO","AC_GST_TYPE","AC_STATE") VALUES
       ($1,'01','01','CREG','Buyer, Registered','24ABCDE1234F1Z5','L','Gujarat'),
       ($1,'01','01','UREG','Walk In','','L','Gujarat'),
       ($1,'01','01','UINT','Interstate Walk In','','I','Maharashtra'),
       ($1,'01','02','LOC2','Other Location Party','24LOC1234F1Z5','L','Gujarat'),
       ($1,'02','01','C2REG','Other Company Party','24COMP1234F1Z5','L','Gujarat')`,
      TENANT,
    );
    await exec(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC") VALUES
       ($1,'01','91',0,'GST 3%',3),($1,'01','92',0,'GST 5%',5)`,
      TENANT,
    );
    const books = [
      ['GSL', 'SALES', 'S'],
      ['GSR', 'SALES RETURNE', 'SR'],
      ['GPR', 'PURCHASE', 'P'],
      ['GRT', 'PURC RETURN', 'PR'],
      ['GSO', 'SALES ORDER', 'SO'],
      ['GOA', 'ORD ADJUST', 'OA'],
      ['GLB', 'LABOUR WORK', 'LW'],
      ['GEC', 'E CRNT', 'EC'],
      ['GT3', 'TAX 3B', 'T3'],
    ];
    for (const [code, main, prefix] of books) {
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_TYPE","BOOK_SR_NAME","CUR_USE")
         VALUES($1,'01','01',$2,$3::text,$3::varchar(30),'T',$4,'Y')`,
        TENANT,
        code,
        main,
        prefix,
      );
    }

    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: '00001',
      srNo: 1,
      bookName: 'SALES',
      acCode: 'CREG',
      taxCode: '91',
      netAmount: 1000,
      discountAmount: 10,
      invoiceValue: 1240,
    });
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: '00001',
      srNo: 3,
      bookName: 'SALES',
      acCode: 'CREG',
      taxCode: '92',
      taxRate: 5,
      netAmount: 200,
      invoiceValue: 1240,
    });
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: '00002',
      bookName: 'SALES',
      acCode: 'UREG',
      netAmount: 240000,
      invoiceValue: 250000,
    });
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: '00003',
      bookName: 'SALES',
      acCode: 'UREG',
      netAmount: 100,
      discountAmount: 10,
      invoiceValue: 103,
    });
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: '00004',
      bookName: 'SALES',
      acCode: 'UREG',
      netAmount: 50,
      discountAmount: 5,
      invoiceValue: 51.5,
    });
    await insertTax(TENANT, {
      coBook: 'GSR',
      vchNo: '00005',
      bookName: 'SALES RETURNE',
      acCode: 'CREG',
      netAmount: 80,
      invoiceValue: 82.4,
      billNo: '00001',
      billBook: 'GSL',
    });
    await insertTax(TENANT, {
      coBook: 'GRT',
      vchNo: '00006',
      bookName: 'PURC RETURN',
      acCode: 'UREG',
      netAmount: 240000,
      invoiceValue: 250000,
      billNo: 'P9',
      billBook: 'GPR',
    });
    await insertTax(TENANT, {
      coBook: 'GSO',
      vchNo: '00007',
      bookName: 'SALES ORDER',
      acCode: 'UREG',
      netAmount: 500,
      invoiceValue: 500,
    });
    await insertTax(TENANT, {
      coBook: 'GOA',
      vchNo: '00008',
      srNo: 11,
      bookName: 'ORD ADJUST',
      acCode: 'UREG',
      netAmount: 300,
      invoiceValue: 300,
    });
    await insertTax(TENANT, {
      coBook: 'GPR',
      vchNo: '00009',
      bookName: 'PURCHASE',
      tranType: 'P',
      acCode: 'CREG',
      netAmount: 400,
      invoiceValue: 412,
    });
    await insertTax(TENANT, {
      coBook: 'GPR',
      vchNo: '00010',
      bookName: 'PURCHASE',
      tranType: 'P',
      acCode: 'UINT',
      netAmount: 250000,
      invoiceValue: 250000,
    });
    await insertTax(TENANT, {
      coBook: 'GPR',
      vchNo: '00011',
      bookName: 'PURCHASE',
      tranType: 'P',
      acCode: 'UREG',
      netAmount: 75,
      invoiceValue: 77.25,
    });

    await insertTax(TENANT, {
      coBook: 'GT3',
      vchNo: '30001',
      bookName: 'TAX 3B',
      acCode: 'CREG',
      taxType: 'CGST',
      netAmount: 1000,
      taxAmount: 15,
      invoiceValue: 1030,
    });
    await insertTax(TENANT, {
      coBook: 'GT3',
      vchNo: '30001',
      srNo: 2,
      bookName: 'TAX 3B',
      acCode: 'CREG',
      taxType: 'SGST',
      netAmount: 1000,
      taxAmount: 15,
      invoiceValue: 1030,
    });
    await insertTax(TENANT, {
      coBook: 'GT3',
      vchNo: '30002',
      bookName: 'TAX 3B',
      tranType: 'P',
      acCode: 'UINT',
      taxType: 'IGST',
      netAmount: 500,
      taxAmount: 15,
      invoiceValue: 515,
      reverseCharge: 'Y',
    });
    await insertTax(TENANT, {
      coBook: 'GT3',
      vchNo: '30003',
      bookName: 'TAX 3B',
      tranType: 'P',
      acCode: 'CREG',
      taxType: 'CGST',
      netAmount: 400,
      taxAmount: 6,
      taxSign: '-',
      invoiceValue: 412,
    });
    await insertTax(TENANT, {
      coBook: 'GT3',
      vchNo: '30003',
      srNo: 2,
      bookName: 'TAX 3B',
      tranType: 'P',
      acCode: 'CREG',
      taxType: 'SGST',
      netAmount: 400,
      taxAmount: 6,
      taxSign: '-',
      invoiceValue: 412,
    });
    // Opposite-side returns must not leak into GSTR-3B outward or ITC: sales return is S/-, purchase
    // return is P/+. RP_GST's sign-only SQL double-counted these; the web keeps the statutory transaction side.
    await insertTax(TENANT, {
      coBook: 'GT3',
      vchNo: '30004',
      bookName: 'TAX 3B',
      tranType: 'S',
      acCode: 'CREG',
      taxType: 'SGST',
      netAmount: 999,
      taxAmount: 99,
      taxSign: '-',
      invoiceValue: 1098,
    });
    await insertTax(TENANT, {
      coBook: 'GT3',
      vchNo: '30005',
      bookName: 'TAX 3B',
      tranType: 'P',
      acCode: 'CREG',
      taxType: 'SGST',
      netAmount: 888,
      taxAmount: 88,
      taxSign: '+',
      invoiceValue: 976,
    });

    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GSTNO","AC_GST_TYPE","AC_STATE")
       VALUES($1,'01','01','OREG','Other Tenant Party','24OTHER1234F1Z5','L','Gujarat')`,
      OTHER_TENANT,
    );
    // Scope sentinels: each differs in exactly one mandatory dimension and must never leak.
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: 'LCSENT',
      bookName: 'SALES',
      acCode: 'LOC2',
      lcCode: '02',
      netAmount: 9999,
      invoiceValue: 9999,
    });
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: 'COSENT',
      bookName: 'SALES',
      acCode: 'C2REG',
      coCode: '02',
      netAmount: 9999,
      invoiceValue: 9999,
    });
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: 'YRSENT',
      bookName: 'SALES',
      acCode: 'CREG',
      coYear: `${startYear - 1}-${startYear}`,
      netAmount: 9999,
      invoiceValue: 9999,
    });
    await insertTax(TENANT, {
      coBook: 'GSL',
      vchNo: 'DTSENT',
      bookName: 'SALES',
      acCode: 'CREG',
      vchDate: `${startYear}-05-01`,
      netAmount: 9999,
      invoiceValue: 9999,
    });
    await insertTax(OTHER_TENANT, {
      coBook: 'GSL',
      vchNo: 'TNSENT',
      bookName: 'SALES',
      acCode: 'OREG',
      netAmount: 9999,
      invoiceValue: 9999,
    });

    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","RATE_TYPE","HSN_CODE") VALUES
       ($1,'01','ZG1','Gold Ring','G','G','7113'),($1,'01','ZO1','Repair','O','P','9983')`,
      TENANT,
    );
    await exec(
      `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME","AC_CODE","IT_CODE","ITM_PCS","ITM_NWT","NET_AMT","IT_TAX_AMT","IT_DISC_AMT")
       VALUES($1,'01','01',$2,'GSL','H001',1,$3::date,'SALES','CREG','ZG1',1,4.25,1000,30,10)`,
      TENANT,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "SL_DETL_RTN"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME","AC_CODE","IT_CODE","ITM_PCS","ITM_NWT","NET_AMT","RTN_IT_TAX_AMT")
       VALUES($1,'01','01',$2,'GSR','H002',1,$3::date,'SALES RETURNE','UINT','ZG1',1,1.25,200,6)`,
      TENANT,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "LBR_ISU_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME","AC_CODE","IT_CODE","ITM_PCS","ITM_NWT","NET_AMT","IT_TAX_AMT","LBR_AMT","IT_LBR_TAX")
       VALUES($1,'01','01',$2,'GLB','H003',1,$3::date,'LABOUR WORK','CREG','ZO1',2,2,40,'1.2',10,'0.3')`,
      TENANT,
      YEAR,
      DAY,
    );

    for (const [name, view, print] of [
      ['viewer', 'Y', 'N'],
      ['printer', 'Y', 'Y'],
      ['blocked', 'N', 'N'],
    ] as const) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','N','N',$4,'N')`,
        TENANT,
        name,
        await hashPassword(PASSWORD),
        print,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Report','Gst Report',$3,'N','N',$4)`,
        TENANT,
        name,
        view,
        print,
      );
    }
    app = await buildApp({
      prisma: runtime,
      secret: SECRET,
      secureCookies: false,
      pdfRenderer: renderer,
    });
    cookies.viewer = await login('viewer');
    cookies.printer = await login('printer');
    cookies.blocked = await login('blocked');
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipe(TENANT);
      await wipe(OTHER_TENANT);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('returns every settled GSTR-1 section with exact columns, values, totals and ordering', async () => {
    const b2b = await get('viewer', url('gstr1', 'B2B'));
    expect(b2b.statusCode, b2b.body).toBe(200);
    expect(b2b.json()).toMatchObject({
      title: 'Summary For B2B(4)',
      columns: [
        { header: 'GSTIN/UIN' },
        { header: 'Receiver Name' },
        { header: 'Invoice No' },
        { header: 'Invoice Date' },
        { header: 'Invoice Value' },
        { header: 'Plase Of Supply' },
        { header: 'R Charg' },
        { header: 'App% Rate' },
        { header: 'Invoice Type' },
        { header: 'E-Com GSTIN' },
        { header: 'Rate' },
        { header: 'Taxable Value' },
        { header: 'Cess Amt' },
      ],
      rows: [
        { invoiceNo: 'S-00001', rate: '3.00', taxableValue: '990' },
        { invoiceNo: 'S-00001', rate: '5.00', taxableValue: '200' },
      ],
      totals: { invoiceCount: '1', invoiceValue: '2480.00', taxableValue: '1190.00' },
    });
    expect(JSON.stringify(b2b.json())).not.toMatch(/SENT|9999/);

    const expected: Array<[string, unknown[], Record<string, string>]> = [
      [
        'B2CL',
        [{ invoiceNo: 'S-00002', invoiceValue: '250000.00', taxableValue: '240000.00' }],
        { invoiceCount: '1', taxableValue: '240000.00' },
      ],
      [
        'B2CS',
        [{ placeOfSupply: '24 - Gujarat', rate: '3.00', taxableValue: '135.00' }],
        { taxableValue: '135.00' },
      ],
      [
        'CDNR',
        [
          {
            refundVoucherNo: 'SR-00005',
            originalInvoiceNo: 'S-00001',
            noteType: 'C',
          },
        ],
        { noteCount: '1', taxableValue: '80.00' },
      ],
      [
        'CDNUR',
        [{ refundVoucherNo: 'PR-00006', originalInvoiceNo: 'P9', urType: 'B2CL', noteType: 'D' }],
        { noteCount: '1', taxableValue: '240000.00' },
      ],
      [
        'AT',
        [{ placeOfSupply: '24 - Gujarat', grossAdvance: '500.00' }],
        { grossAdvance: '500.00' },
      ],
      [
        'ATADJ',
        [{ placeOfSupply: '24 - Gujarat', grossAdvance: '300.00' }],
        { grossAdvance: '300.00' },
      ],
    ];
    for (const [section, rows, totals] of expected) {
      const response = await get('viewer', url('gstr1', section));
      expect(response.statusCode, `${section}: ${response.body}`).toBe(200);
      expect(response.json().rows).toMatchObject(rows);
      expect(response.json().totals).toMatchObject(totals);
    }
  });

  it('returns settled GSTR-2 purchase and return equivalents without changing old fixed routes', async () => {
    for (const [section, expected] of [
      ['B2B', { invoiceNo: 'P-00009', gstin: '24ABCDE1234F1Z5', taxableValue: '400.00' }],
      ['B2CL', { invoiceNo: 'P-00010', invoiceValue: '250000.00' }],
      ['B2CS', { placeOfSupply: '24 - Gujarat', taxableValue: '75.00' }],
      ['CDNR', { refundVoucherNo: 'SR-00005', noteType: 'C' }],
      ['CDNUR', { refundVoucherNo: 'PR-00006', noteType: 'D' }],
    ] as const) {
      const response = await get('viewer', url('gstr2', section));
      expect(response.statusCode, `${section}: ${response.body}`).toBe(200);
      expect(response.json().rows).toContainEqual(expect.objectContaining(expected));
    }
    const legacy = await get('viewer', `/reports/gstr2?fromDate=${FROM}&toDate=${TO}`);
    expect(legacy.statusCode).not.toBe(404);
  });

  it('returns HSN sale, return, item-labour and labour-service rows with exact splits', async () => {
    const response = await get('viewer', url('gstr1', 'HSN'));
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json().rows).toEqual([
      {
        hsn: '7113',
        description: 'Gold',
        uqc: 'GMS-GRAMMES',
        totalQuantity: '-1.25',
        totalValue: '-206.00',
        taxableValue: '-200.00',
        igstAmount: '-6.00',
        cgstAmount: '0.00',
        sgstAmount: '0.00',
        cessAmount: '0.00',
      },
      {
        hsn: '7113',
        description: 'Gold',
        uqc: 'GMS-GRAMMES',
        totalQuantity: '4.25',
        totalValue: '1020.00',
        taxableValue: '990.00',
        igstAmount: '0.00',
        cgstAmount: '15.00',
        sgstAmount: '15.00',
        cessAmount: '0.00',
      },
      {
        hsn: '9983',
        description: 'Other',
        uqc: 'PCS',
        totalQuantity: '2.00',
        totalValue: '41.20',
        taxableValue: '40.00',
        igstAmount: '0.00',
        cgstAmount: '0.60',
        sgstAmount: '0.60',
        cessAmount: '0.00',
      },
      {
        hsn: '998892',
        description: 'Other',
        uqc: 'PCS',
        totalQuantity: '2.00',
        totalValue: '10.30',
        taxableValue: '10.00',
        igstAmount: '0.00',
        cgstAmount: '0.15',
        sgstAmount: '0.15',
        cessAmount: '0.00',
      },
    ]);
    expect(response.json().totals).toMatchObject({
      totalValue: '865.50',
      taxableValue: '840.00',
      igstAmount: '-6.00',
      cgstAmount: '15.75',
      sgstAmount: '15.75',
    });
  });

  it('returns only the source-settled GSTR-3B rows', async () => {
    const response = await get('viewer', url('gstr3b', undefined, '&bookCode=GT3'));
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json().rows).toEqual([
      {
        table: '3.1',
        code: '(a)',
        nature: 'OutWord Taxable Supplies(Other then Zero rated)',
        placeOfSupply: '',
        taxableValue: '1000.00',
        igstAmount: '0.00',
        cgstAmount: '15.00',
        sgstAmount: '15.00',
        cessAmount: '',
      },
      {
        table: '3.1',
        code: '(d)',
        nature: 'InWord Supplies(Lible to Reverse Charge)',
        placeOfSupply: '',
        taxableValue: '500.00',
        igstAmount: '15.00',
        cgstAmount: '0.00',
        sgstAmount: '0.00',
        cessAmount: '',
      },
      {
        table: '4(A)',
        code: '(5)',
        nature: 'All Other ITC)',
        placeOfSupply: '',
        taxableValue: '400.00',
        igstAmount: '0.00',
        cgstAmount: '6.00',
        sgstAmount: '6.00',
        cessAmount: '',
      },
    ]);
    expect(response.json().metadata.blockedRows).toContain('6.2');
  });

  it('applies book, party, location, company, year and date scope and refuses location replacement', async () => {
    const filtered = await get(
      'viewer',
      url('gstr1', 'B2B', '&bookCode=GSL&partyCode=CREG&lcCode=01'),
    );
    expect(filtered.statusCode, filtered.body).toBe(200);
    expect(filtered.json().rows).toHaveLength(2);
    const wrongParty = await get('viewer', url('gstr1', 'B2B', '&partyCode=UREG'));
    expect(wrongParty.statusCode).toBe(200);
    expect(wrongParty.json().rows).toEqual([]);
    const wrongLocation = await get('viewer', url('gstr1', 'B2B', '&lcCode=02'));
    expect(wrongLocation.statusCode).toBe(409);
    expect(wrongLocation.json()).toEqual({ error: 'scope-mismatch' });
  });

  it('fails closed for missing, unknown and source-incomplete sections and invalid dates', async () => {
    for (const [target, status, error] of [
      [url('gstr1'), 400, 'missing-section'],
      [url('gstr1', 'WHAT'), 400, 'invalid-section'],
      [url('gstr1', 'EXP'), 422, 'section-not-supported'],
      [url('gstr1', 'EXEMP'), 422, 'section-not-supported'],
      [url('gstr1', 'DOCS'), 422, 'section-not-supported'],
      [url('gstr1', 'TCS'), 422, 'section-not-supported'],
      [url('gstr2', 'HSN'), 422, 'section-not-supported'],
      [url('gstr1', 'B2B', '&unexpected=x'), 400, 'invalid-query'],
      [url('gstr1', 'B2B', '&bookCode=LONG'), 400, 'invalid-query'],
      [
        `/reports/gst-report?view=gstr1&section=B2B&fromDate=${startYear - 1}-03-31&toDate=${TO}`,
        400,
        'date-outside-year',
      ],
      [`/reports/gst-report?view=gstr1&section=B2B&fromDate=no&toDate=${TO}`, 400, 'invalid-date'],
      [
        `/reports/gst-report?view=gstr1&section=B2B&fromDate=${TO}&toDate=${FROM}`,
        400,
        'invalid-date-range',
      ],
      [
        `/reports/gst-report?view=gstr3b&section=B2B&fromDate=${FROM}&toDate=${TO}`,
        400,
        'invalid-section',
      ],
    ] as const) {
      const response = await get('viewer', target);
      expect(response.statusCode, `${target}: ${response.body}`).toBe(status);
      expect(response.json().error).toBe(error);
    }
  });

  it('requires list rights for JSON and print rights for all exports', async () => {
    expect((await get('blocked', url('gstr1', 'B2B'))).statusCode).toBe(403);
    expect((await get('viewer', url('gstr1', 'B2B'))).statusCode).toBe(200);
    for (const extension of ['csv', 'xlsx', 'pdf']) {
      expect(
        (
          await get(
            'viewer',
            url('gstr1', 'B2B').replace('gst-report?', `gst-report/export.${extension}?`),
          )
        ).statusCode,
      ).toBe(403);
      expect(
        (
          await get(
            'printer',
            url('gstr1', 'B2B').replace('gst-report?', `gst-report/export.${extension}?`),
          )
        ).statusCode,
      ).toBe(200);
    }
  });

  it('exports CSV, XLSX and PDF from the same exact dataset', async () => {
    const query = `view=gstr1&section=B2CL&fromDate=${FROM}&toDate=${TO}`;
    const json = (await get('printer', `/reports/gst-report?${query}`)).json();
    const csv = await get('printer', `/reports/gst-report/export.csv?${query}`);
    expect(csv.statusCode, csv.body).toBe(200);
    expect(csv.headers['content-disposition']).toBe('attachment; filename="B2CL.csv"');
    expect(csv.body).toContain(
      `${json.rows[0].invoiceNo},${json.rows[0].invoiceDate},${json.rows[0].invoiceValue}`,
    );

    const xlsx = await get('printer', `/reports/gst-report/export.xlsx?${query}`);
    expect(xlsx.statusCode, xlsx.body).toBe(200);
    const parts = unzipSync(new Uint8Array(xlsx.rawPayload));
    const workbookText = Object.values(parts)
      .map((part) => strFromU8(part))
      .join('');
    expect(workbookText).toContain(json.rows[0].invoiceNo);
    expect(workbookText).toContain('Invoice Value');

    const pdf = await get('printer', `/reports/gst-report/export.pdf?${query}`);
    expect(pdf.statusCode, pdf.body).toBe(200);
    expect(pdf.rawPayload.subarray(0, 5).toString('latin1')).toBe('%PDF-');
    expect(renderer.html.at(-1)).toContain(json.rows[0].invoiceNo);
    expect(renderer.html.at(-1)).toContain('Invoice Value');
  });

  it('does not change business or staging data while executing reports and exports', async () => {
    const snapshot = async () =>
      owner.$queryRawUnsafe<Array<{ table_name: string; rows: number }>>(
        `SELECT table_name,count(*)::int AS rows FROM (
         SELECT 'TAX_DATA' AS table_name FROM "TAX_DATA" WHERE tenant_id=$1
         UNION ALL SELECT 'SL_DETL' FROM "SL_DETL" WHERE tenant_id=$1
         UNION ALL SELECT 'SL_DETL_RTN' FROM "SL_DETL_RTN" WHERE tenant_id=$1
         UNION ALL SELECT 'LBR_ISU_DETL' FROM "LBR_ISU_DETL" WHERE tenant_id=$1
       ) x GROUP BY table_name ORDER BY table_name`,
        TENANT,
      );
    const before = await snapshot();
    await get('printer', url('gstr1', 'B2B'));
    await get('printer', url('gstr1', 'HSN').replace('gst-report?', 'gst-report/export.csv?'));
    await get(
      'printer',
      url('gstr3b', undefined, '&bookCode=GT3').replace('gst-report?', 'gst-report/export.xlsx?'),
    );
    expect(await snapshot()).toEqual(before);
  });
});
