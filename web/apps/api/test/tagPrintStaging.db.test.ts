import { withTenant } from '@datacare/db';
import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { stageTagPrintRowsTx, TAG_PRINT_STAGING_COLUMNS } from '../src/modules/stock/tagPrint.js';

/**
 * Desktop label-print staging (TR_TAG_OPBL.cs:9189-9190, shared verbatim by UT_TAG_PRINT,
 * TR_TAG_SPLIT, TR_PHYSTK, TR_TAG_WT_DIFF and TR_ITM_LOT):
 *   DELETE FROM TAG_PRINT_DATA
 *   INSERT INTO TAG_PRINT_DATA(<58 columns>) SELECT <same> FROM BAR_DETL WHERE <voucher> AND SR_NO = L
 *
 * These assertions cover the FULL 58-column copy rather than a sample, plus the clear-first
 * behaviour and the tenant boundary that replaces desktop's unqualified DELETE.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'tag-print-stage-db';
const OTHER_TENANT = 'tag-print-stage-db-other';
const CO = '77';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'TOP';
const VCH = '00001';

databaseDescribe('database-backed tag print staging', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const tenant of [TENANT, OTHER_TENANT]) {
      for (const table of ['TAG_PRINT_DATA', 'BAR_DETL']) {
        await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
      }
    }
  };

  const seedTag = async (tenant: string, srNo: number, tagNo: string): Promise<void> => {
    const cols = ['CO_CODE', 'LC_CODE', 'CO_YEAR', 'CO_BOOK', 'VCH_NO', 'SR_NO', 'TAG_NO'];
    const values: unknown[] = [tenant, CO, LC, YEAR, BOOK, VCH, srNo, tagNo];
    // Populate every staged column so the copy assertion is meaningful for all 58.
    const extra: Record<string, unknown> = {
      OLD_SRNO: srNo,
      VCH_DATE: new Date('2024-04-10T00:00:00'),
      STK_DATE: new Date('2024-04-10T00:00:00'),
      VCH_TIME: new Date('2024-04-10T10:15:00'),
      VCH_TYPE: 'TGOP',
      INOUT_TYPE: 'I',
      ENTRY_TYPE: 'O',
      BOOK_NAME: 'Tag Opening',
      AC_CODE: 'AC1',
      IT_CODE: 'GOLD1',
      LOT_NO: 'LOT1',
      DESIGN_NO: 'D-1',
      TBL_CODE: '001',
      ITM_SIZE: 'M',
      ITM_PCS: 1,
      BAG_WT: 0.5,
      ITM_GWT: 10.5,
      ITM_OTH_WT: 0.25,
      ITM_NWT: 10.25,
      ITM_GHT_PRC: 1.5,
      ITM_GHT_WT: 0.15,
      ITM_TOUCH: 91.6,
      ITM_WEST_PRC: 2.5,
      ITM_FINE: 9.39,
      LBR_PRC: 5,
      LBR_RATE: 55,
      LBR_TYPE: 'G',
      LBR_AMT: 577.5,
      OTH_AMT: 25,
      ITM_RATE: 6_500,
      ITM_AMT: 66_625,
      TAG_COST: 1_250,
      ITM_MARGIN: 12.5,
      ITM_MRP: 74_500,
      ITM_REMARK: 'REMARK-1',
      SF_NO: 'SF-1',
      KR_NAME: 'KARX',
      VCH_SRNO: srNo,
      RATE_TYPE: 'R',
      IT_TYPE: 'G',
      TAG_TYPE: 'B',
      PR_CODE: 'PR',
      HM_ID: 'HUID12345',
      HM_ID2: 'HM2',
      HM_ID3: 'HM3',
      HM_ID4: 'HM4',
      HM_ID_WT: 1.1,
      HM_ID2_WT: 2.2,
      HM_ID3_WT: 3.3,
      HM_ID4_WT: 4.4,
      ITM_STYLE: 'STYLE-A',
    };
    const allCols = [...cols, ...Object.keys(extra)];
    const allValues = [...values, ...Object.values(extra)];
    const placeholders = allCols.map((_, i) => `$${i + 2}`).join(',');
    await owner.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"(tenant_id,${allCols.map((c) => `"${c}"`).join(',')})
       VALUES ($1,${placeholders})`,
      tenant,
      ...allValues.slice(1),
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(async () => {
    await cleanup();
  });

  it('copies every desktop-staged column from BAR_DETL', async () => {
    await seedTag(TENANT, 1, 'TAG-1');

    const staged = await withTenant(runtime, TENANT, (tx: any) =>
      stageTagPrintRowsTx(tx, TENANT, { coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK }, VCH),
    );
    expect(staged).toBe(1);

    const printed: any[] = await owner.$queryRawUnsafe(
      `SELECT * FROM "TAG_PRINT_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    const source: any[] = await owner.$queryRawUnsafe(
      `SELECT * FROM "BAR_DETL" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(printed).toHaveLength(1);

    for (const column of TAG_PRINT_STAGING_COLUMNS) {
      const from = source[0]![column];
      const to = printed[0]![column];
      const normalise = (v: unknown): string =>
        v instanceof Date ? v.toISOString() : String(v ?? '').trim();
      expect(normalise(to), `TAG_PRINT_DATA.${column}`).toBe(normalise(from));
    }
  });

  it('clears prior staging rows before copying, matching desktop DELETE-then-INSERT', async () => {
    await seedTag(TENANT, 1, 'TAG-1');
    await seedTag(TENANT, 2, 'TAG-2');

    await withTenant(runtime, TENANT, (tx: any) =>
      stageTagPrintRowsTx(tx, TENANT, { coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK }, VCH),
    );
    const first: any[] = await owner.$queryRawUnsafe(
      `SELECT "TAG_NO" FROM "TAG_PRINT_DATA" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    );
    expect(first.map((r) => r.TAG_NO)).toEqual(['TAG-1', 'TAG-2']);

    // Staging a single serial must leave exactly that row, not append to the previous batch.
    await withTenant(runtime, TENANT, (tx: any) =>
      stageTagPrintRowsTx(
        tx,
        TENANT,
        { coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK },
        VCH,
        [2],
      ),
    );
    const second: any[] = await owner.$queryRawUnsafe(
      `SELECT "TAG_NO" FROM "TAG_PRINT_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(second.map((r) => r.TAG_NO)).toEqual(['TAG-2']);
  });

  it('never clears or copies another tenant staging rows', async () => {
    await seedTag(TENANT, 1, 'TAG-1');
    await seedTag(OTHER_TENANT, 1, 'OTHER-1');
    await withTenant(runtime, OTHER_TENANT, (tx: any) =>
      stageTagPrintRowsTx(
        tx,
        OTHER_TENANT,
        { coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK },
        VCH,
      ),
    );

    // Desktop issues an unqualified DELETE; forced RLS confines it to the acting tenant.
    await withTenant(runtime, TENANT, (tx: any) =>
      stageTagPrintRowsTx(tx, TENANT, { coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK }, VCH),
    );

    const mine: any[] = await owner.$queryRawUnsafe(
      `SELECT "TAG_NO" FROM "TAG_PRINT_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    const theirs: any[] = await owner.$queryRawUnsafe(
      `SELECT "TAG_NO" FROM "TAG_PRINT_DATA" WHERE tenant_id=$1`,
      OTHER_TENANT,
    );
    expect(mine.map((r) => r.TAG_NO)).toEqual(['TAG-1']);
    expect(theirs.map((r) => r.TAG_NO)).toEqual(['OTHER-1']);
  });
});
