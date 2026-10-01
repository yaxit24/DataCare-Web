import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteWholesaleQuotation,
  editWholesaleQuotation,
  getWholesaleQuotation,
  postWholesaleQuotation,
} from '../src/modules/sales/rateCut.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { footprintOf, voucherTables } from './support/footprint.js';
import { withTenant } from '@datacare/db';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;
const TENANT = 'wh-quotation-db';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const scope = { tenantId: TENANT, coCode: '01', lcCode: '01', coYear: YEAR, coBook: 'WHQ' };

const input = {
  scope,
  acCode: 'QUOTE01',
  acName: 'Quotation Customer',
  vchDate: DAY,
  itType: 'G' as const,
  lines: [
    {
      itCode: 'GOLD',
      itemName: 'Gold Ornament',
      pcs: 1,
      grossWt: 10,
      netWt: 10,
      touch: 91.6,
      rate: 6500,
      lbrType: 'G' as const,
      lbrRate: 50,
    },
  ],
  receivedLines: [
    { itCode: 'OLDG', itemName: 'Old Gold', grossWt: 2, netWt: 2, touch: 90, rate: 6000 },
  ],
};

d('Wholesale Quotation is a document-only TR_WH_SALE mode', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, TENANT);
  };

  beforeAll(async () => {
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await wipe();
    await seedCompany(runtime, TENANT, '01');
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,'01','01','QUOTE01','Quotation Customer','L')`,
      TENANT,
    );
  });
  afterAll(async () => {
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('creates, reopens, edits and deletes only RATE_CUT document rows plus hidden identity', async () => {
    const created = await postWholesaleQuotation(runtime, input);
    const tables = await voucherTables(owner);
    const touched = await footprintOf(
      owner,
      tables,
      TENANT,
      String(created.vchNo).padStart(5, '0'),
    );
    expect(touched).toEqual(['RATE_CUT_DATA', 'RATE_CUT_ISU', 'RATE_CUT_REC', 'TEMP_BOOK_DATA']);
    const opened = await getWholesaleQuotation(runtime, scope, created.vchNo);
    expect(opened).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      acCode: 'QUOTE01',
      lines: [{ itCode: 'GOLD' }],
      receivedLines: [{ itCode: 'OLDG' }],
    });

    await editWholesaleQuotation(
      runtime,
      { ...input, vchDesc: 'Revised quotation' },
      created.vchNo,
    );
    const edited = await getWholesaleQuotation(runtime, scope, created.vchNo);
    expect(edited).toMatchObject({ hiddenVoucherNo: '00001', vchDesc: 'Revised quotation' });
    const temp = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WHQ'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(temp[0]?.n).toBe(1);

    await deleteWholesaleQuotation(runtime, { scope, vchNo: created.vchNo, deleteUser: 'tester' });
    const after = await withTenant(runtime, TENANT, async (tx: any) => ({
      header: Number(
        (
          await tx.$queryRawUnsafe(
            `SELECT count(*) n FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WHQ'`,
            TENANT,
          )
        )[0]?.n ?? 0,
      ),
      temp: Number(
        (
          await tx.$queryRawUnsafe(
            `SELECT count(*) n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WHQ'`,
            TENANT,
          )
        )[0]?.n ?? 0,
      ),
    }));
    expect(after).toEqual({ header: 0, temp: 0 });
  });

  it('refuses WH SALES and RATE CUT books with zero quotation writes', async () => {
    for (const coBook of ['WHS', 'RTC']) {
      await expect(
        postWholesaleQuotation(runtime, { ...input, scope: { ...scope, coBook } }),
      ).rejects.toThrow(/use the (wholesale sale|rate cut) workflow/);
    }
    const rows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "RATE_CUT_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(rows[0]?.n).toBe(0);
  });
});
