import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { bindReport } from '../src/modules/reports/reportBind.js';
import {
  loadReportSpec,
  renderReportLayout,
  type RptSpec,
} from '../src/modules/reports/reportEngine.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'report-render-contract';
const CO = '91';
const LC = '01';
const YEAR = '2026-2027';
const VCH_NO = '00001';

type CriticalReport = {
  category: string;
  name: string;
  book: string;
  value: string;
  expectedKinds: string[];
};

const CRITICAL_REPORTS: CriticalReport[] = [
  {
    category: 'sales bill',
    name: 'SalesBillHz',
    book: 'S91',
    value: 'REPORT-SALE-CUSTOMER-91',
    expectedKinds: ['PageHeader', 'GroupHeader', 'Detail', 'ReportFooter'],
  },
  {
    category: 'purchase bill',
    name: 'PurcBillA4',
    book: 'P91',
    value: 'REPORT-PURCHASE-SUPPLIER-91',
    expectedKinds: ['PageHeader', 'GroupHeader', 'Detail', 'ReportFooter'],
  },
  {
    category: 'cash/receipt voucher',
    name: 'CashBankBill',
    book: 'C91',
    value: 'REPORT-CASH-RECEIPT-91',
    expectedKinds: ['PageHeader', 'GroupHeader', 'Detail', 'ReportFooter'],
  },
  {
    category: 'tag/label',
    name: 'TagStkRpt',
    book: 'T91',
    value: 'RPT-TAG-00091',
    expectedKinds: ['PageHeader', 'GroupHeader', 'Detail', 'ReportFooter'],
  },
  {
    category: 'ledger statement',
    name: 'AcLedger',
    book: 'L91',
    value: 'REPORT-LEDGER-NARRATION-91',
    expectedKinds: ['PageHeader', 'GroupHeader', 'Detail', 'ReportFooter'],
  },
];

databaseDescribe('database-backed critical Crystal report rendering', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async () => {
    for (const table of [
      'SL_DETL',
      'SL_DATA',
      'LOT_DETL',
      'PR_DETL',
      'PR_DATA',
      'CASH_DATA',
      'TAG_STOCK_PRINT',
      'BAR_DETL',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'AC_MAST',
      'CO_MAST',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
    await cleanup();

    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Report Contract Company')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,$2,$3,'LEDGER91','Report Ledger Party')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_NAME")
       VALUES ($1,$2,$3,$4,'S91',$5,'2026-04-01',$6)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VCH_NO,
      CRITICAL_REPORTS[0].value,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ITM_PCS","ITM_GWT","NET_AMT")
       VALUES ($1,$2,$3,$4,'S91',$5,1,2,12.345,9101.25)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VCH_NO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "PR_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_NAME")
       VALUES ($1,$2,$3,$4,'P91',$5,'2026-04-02',$6)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VCH_NO,
      CRITICAL_REPORTS[1].value,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "PR_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ITM_PCS","ITM_GWT","NET_AMT")
       VALUES ($1,$2,$3,$4,'P91',$5,1,3,23.456,9202.50)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VCH_NO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CASH_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_NAME","REC_AMT")
       VALUES ($1,$2,$3,$4,'C91',$5,1,'2026-04-03',$6,9303.75)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VCH_NO,
      CRITICAL_REPORTS[2].value,
    );
    // TAG_STOCK_PRINT is derived staging, not an authored table: the report binder clears and
    // repopulates it from BAR_DETL at bind time, mirroring RP_PHY_STOCK.cs:1830-1838. Seeding the
    // SOURCE row is therefore the correct fixture — seeding the staging table directly would be
    // wiped by the same staging step the desktop performs.
    await owner.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","TAG_NO")
       VALUES ($1,$2,$3,$4,'T91',$5,1,'2026-04-04',$6)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VCH_NO,
      CRITICAL_REPORTS[3].value,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_TYPE","VCH_DATE","AC_CODE","IT_DESC")
       VALUES ($1,$2,$3,$4,'L91',$5,'RCT','2026-04-05','LEDGER91',$6)`,
      TENANT,
      CO,
      LC,
      YEAR,
      VCH_NO,
      CRITICAL_REPORTS[4].value,
    );
  });

  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it.each(CRITICAL_REPORTS)(
    'renders seeded $category values through $name',
    async ({ name, book, value, expectedKinds }) => {
      const spec = loadReportSpec(name) as RptSpec;
      expect(spec, `${name} spec missing`).toBeTruthy();
      const bound = await bindReport(runtime, spec, {
        tenantId: TENANT,
        coCode: CO,
        coBook: book,
        vchNo: VCH_NO,
      });
      expect(bound, `${name} did not bind the seeded restricted-role row`).toBeTruthy();

      const html = renderReportLayout(spec, bound!);
      for (const kind of expectedKinds) expect(html).toContain(`data-kind="${kind}"`);
      expect((html.match(/class="ro /g) ?? []).length).toBeGreaterThan(0);
      expect(html).toMatch(/left:-?\d+px;top:-?\d+px;width:\d+px;/);
      expect(html).toContain(value);
      expect(html).not.toContain(`[${value}]`);
    },
    30_000,
  );
});
