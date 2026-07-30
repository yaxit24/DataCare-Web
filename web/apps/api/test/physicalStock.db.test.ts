import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import {
  deletePhysicalStock,
  getPhysicalStock,
  PhysicalStockValidationError,
  savePhysicalStock,
} from '../src/modules/stock/physicalStock.js';
import { physicalReconcile, physicalStockList } from '../src/modules/stock/stock.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'physical-stock-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'PHS';
const DAY = '2024-04-10';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};
const identityForTest = (row: { tagNo: string; vchSrno: number }): string =>
  `${row.tagNo}|${row.vchSrno}`;

databaseDescribe('database-backed physical-stock vouchers', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'REMARK_DATA',
      'BAR_CAN_DETL',
      'BAR_CAN_DATA',
      'TEMP_BOOK_DATA',
      'MAIN_STOCK',
      'BAR_DETL',
      'ITEM_MAST',
      'BOOK_DATA',
      'YEAR_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seedTag = async (tagNo: string, vchSrno: number, netWt: number): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "BAR_DETL"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "VCH_TYPE","INOUT_TYPE","ENTRY_TYPE","BOOK_NAME","IT_CODE","TAG_NO","VCH_SRNO",
         "DESIGN_NO","TBL_CODE","ITM_SIZE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT",
         "ITM_TOUCH","ITM_FINE","LBR_RATE","LBR_TYPE","LBR_AMT","OTH_AMT","TAG_COST",
         "ITM_MRP","KR_NAME","EMP_ISU","MAIN_USER")
       VALUES ($1,$2,$3,$4,'TOP',$5,$6,$7::date,'TGEN','I','O','TAG GEN','GOLD',$8,$9,
               'D1','001','M',1,$10,0,$10,100,$10,50,'P',50,10,1000,1500,'K1','N','seed')`,
      TENANT,
      CO,
      LC,
      YEAR,
      `O${vchSrno}`,
      vchSrno,
      DAY,
      tagNo,
      vchSrno,
      netWt,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","VCH_TYPE","BOOK_NAME","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE",
         "ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,$2,$3,$4,'TOP',$5,$6,1,$7::date,'TAGOP','TAG OPBL','GOLD',$8,$9,'P','+',1,$10,$10,$10)`,
      TENANT,
      CO,
      LC,
      YEAR,
      `O${vchSrno}`,
      vchSrno,
      DAY,
      tagNo,
      vchSrno,
      netWt,
    );
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
       VALUES ($1,$2,$3,'2024-04-01','2025-03-31'::timestamp)`,
      TENANT,
      CO,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,'Physical Stock','PHYS','PHY STOCK','O','Y','BAR_CAN_DATA')`,
      TENANT,
      CO,
      LC,
      BOOK,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
       VALUES ($1,$2,'GOLD','Gold Ornament','G')`,
      TENANT,
      CO,
    );
    await seedTag('TAG001', 1, 10);
    await seedTag('TAG002', 2, 12);
    await seedTag('TAG003', 3, 8);
    await seedTag('TAG004', 4, 9);
    await owner.$executeRawUnsafe(
      `UPDATE "BAR_DETL" SET "ITM_GHT_WT"=2,"ITM_WEST_PRC"=3,"LBR_PRC"=4,
              "ITM_RATE"=500,"ITM_AMT"=5000,"KR_NET_WT"=9,"KR_TOUCH"=91,
              "KR_WEST_PRC"=2,"KR_FINE"=8,"KR_COST"='1200',"RATE_TYPE"='R',
              "IT_TYPE"='G',"PR_CODE"='P1'
        WHERE tenant_id=$1 AND "TAG_NO"='TAG001'`,
      TENANT,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) {
      throw new Error('RUN_DB_INTEGRITY_TESTS requires MIGRATE_DATABASE_URL and DATABASE_URL');
    }
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('creates, reads, replaces and deletes an exact desktop physical-count snapshot without moving stock', async () => {
    const created = await savePhysicalStock(runtime, {
      scope,
      vchDate: DAY,
      employeeCode: 'E1',
      description: 'Annual count',
      mainUser: 'counter-user',
      lines: [
        { tagNo: 'TAG001', vchSrno: 1 },
        { tagNo: 'TAG002', vchSrno: 2 },
      ],
    });
    expect(created).toEqual({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: true,
      lines: 2,
    });
    const persisted = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "BAR_CAN_DATA" WHERE tenant_id=$1) headers,
         (SELECT count(*)::int FROM "BAR_CAN_DETL" WHERE tenant_id=$1) details,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_rows,
         (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1) remarks,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) stock_rows,
         (SELECT min("BOOK_NAME") FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_book_name,
         (SELECT min("ITM_SIGN") FROM "BAR_CAN_DETL" WHERE tenant_id=$1) sign,
         (SELECT min("ENTRY_TYPE") FROM "BAR_CAN_DETL" WHERE tenant_id=$1) entry_type,
         (SELECT min("BOOK_NAME") FROM "BAR_CAN_DETL" WHERE tenant_id=$1) book_name,
         (SELECT min("DATA_TRFR") FROM "BAR_CAN_DATA" WHERE tenant_id=$1) header_transfer,
         (SELECT min("VCH_TIME")::date::text FROM "BAR_CAN_DATA" WHERE tenant_id=$1) time_date,
         (SELECT min("ITM_GHT_WT")::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1) ght,
         (SELECT min("ITM_TOUCH")::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1) touch,
         (SELECT min("ITM_WEST_PRC")::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1) west,
         (SELECT min("LBR_PRC")::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1) lbr_prc,
         (SELECT min("LBR_RATE")::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1) lbr_rate,
         (SELECT min("ITM_RATE")::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1) item_rate,
         (SELECT min("KR_NET_WT")::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1) kr_net,
         (SELECT "TAG_COST"::float FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001') tag_cost`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      headers: 1,
      details: 2,
      temp_rows: 1,
      remarks: 1,
      stock_rows: 4,
      temp_book_name: 'Physical Stock',
      sign: '-',
      entry_type: 'T',
      book_name: 'PHY STOCK',
      header_transfer: 'Y',
      time_date: DAY,
      ght: 0,
      touch: 0,
      west: 0,
      lbr_prc: 0,
      lbr_rate: 0,
      item_rate: 0,
      kr_net: 0,
      tag_cost: 1200,
    });

    const view = await getPhysicalStock(runtime, scope, created.voucherNo);
    expect(view).toMatchObject({
      voucherNo: '00001',
      vchDate: DAY,
      employeeCode: 'E1',
      description: 'Annual count',
      hiddenVoucherNo: '00001',
      mainUser: 'counter-user',
      lines: [
        { tagNo: 'TAG001', vchSrno: 1, netWt: 10, sign: '-', entryType: 'T' },
        { tagNo: 'TAG002', vchSrno: 2, netWt: 12, sign: '-', entryType: 'T' },
      ],
    });

    // A metadata-only edit must retain the captured count even after the live tag changes/sells.
    await owner.$executeRawUnsafe(
      `UPDATE "BAR_DETL" SET "ITM_NWT"=99,"ITM_GWT"=99,"ITM_MRP"=9999
        WHERE tenant_id=$1 AND "TAG_NO"='TAG002' AND "VCH_SRNO"=2`,
      TENANT,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_NWT")
       VALUES ($1,$2,$3,$4,'SAL','SOLD2',1,1,$5::date,'GOLD','TAG002',2,'-',12)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );

    const edited = await savePhysicalStock(
      runtime,
      {
        scope,
        vchDate: DAY,
        employeeCode: 'E2',
        description: '',
        mainUser: 'different-user',
        lines: [{ tagNo: 'TAG002', vchSrno: 2 }],
      },
      created.voucherNo,
    );
    expect(edited).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: '00001',
      created: false,
      lines: 1,
    });
    const editedView = await getPhysicalStock(runtime, scope, created.voucherNo);
    expect(editedView).toMatchObject({
      employeeCode: 'E2',
      description: '',
      mainUser: 'counter-user',
      lines: [{ tagNo: 'TAG002', oldSrNo: 2, netWt: 12, grossWt: 12, mrp: 1500 }],
    });
    const remarkCount = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "REMARK_DATA" WHERE tenant_id=$1`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(remarkCount[0]?.n).toBe(0);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(deletePhysicalStock(runtime, scope, created.voucherNo)).rejects.toBeInstanceOf(
      PeriodLockValidationError,
    );
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(deletePhysicalStock(runtime, scope, created.voucherNo)).resolves.toEqual({
      reversed: true,
    });
    const remaining = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "BAR_CAN_DATA" WHERE tenant_id=$1) headers,
         (SELECT count(*)::int FROM "BAR_CAN_DETL" WHERE tenant_id=$1) details,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1) temp_rows,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1) stock_rows`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(remaining[0]).toEqual({ headers: 0, details: 0, temp_rows: 0, stock_rows: 5 });
  }, 30_000);

  it('rejects duplicates, unavailable tags, repeated counts and out-of-year dates atomically', async () => {
    await expect(
      savePhysicalStock(runtime, {
        scope,
        vchDate: DAY,
        lines: [
          { tagNo: 'TAG001', vchSrno: 1 },
          { tagNo: 'TAG001', vchSrno: 1 },
        ],
      }),
    ).rejects.toBeInstanceOf(PhysicalStockValidationError);
    await expect(
      savePhysicalStock(runtime, {
        scope,
        vchDate: DAY,
        lines: [{ tagNo: 'MISSING', vchSrno: 99 }],
      }),
    ).rejects.toThrow(/unavailable/);
    await expect(
      savePhysicalStock(runtime, {
        scope,
        vchDate: '2025-04-01',
        lines: [{ tagNo: 'TAG001', vchSrno: 1 }],
      }),
    ).rejects.toThrow(/outside fiscal year/);

    const first = await savePhysicalStock(runtime, {
      scope,
      vchDate: DAY,
      lines: [{ tagNo: 'TAG001', vchSrno: 1 }],
    });
    expect(first.voucherNo).toBe('00001');
    await expect(
      savePhysicalStock(runtime, {
        scope,
        vchDate: DAY,
        lines: [{ tagNo: 'TAG001', vchSrno: 1 }],
      }),
    ).rejects.toThrow(/already counted/);
    const counts = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "BAR_CAN_DATA" WHERE tenant_id=$1) headers,
         (SELECT count(*)::int FROM "BAR_CAN_DETL" WHERE tenant_id=$1) details`,
      TENANT,
    )) as Array<{ headers: number; details: number }>;
    expect(counts[0]).toEqual({ headers: 1, details: 1 });
  }, 30_000);

  it('checks the persisted date on update and permits server-resolved lines to be appended safely', async () => {
    const created = await savePhysicalStock(runtime, {
      scope,
      vchDate: DAY,
      description: 'Locked source date',
      lines: [{ tagNo: 'TAG001', vchSrno: 1 }],
    });
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );
    await expect(
      savePhysicalStock(
        runtime,
        {
          scope,
          vchDate: '2024-04-11',
          description: 'Must not move forward',
          lines: [{ tagNo: 'TAG001', vchSrno: 1 }],
        },
        created.voucherNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await getPhysicalStock(runtime, scope, created.voucherNo)).toMatchObject({
      vchDate: DAY,
      description: 'Locked source date',
      lines: [{ tagNo: 'TAG001' }],
    });

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(
      savePhysicalStock(
        runtime,
        {
          scope,
          vchDate: DAY,
          description: 'Added one tag',
          lines: [
            { tagNo: 'TAG001', vchSrno: 1 },
            { tagNo: 'TAG002', vchSrno: 2 },
          ],
        },
        created.voucherNo,
      ),
    ).resolves.toMatchObject({ created: false, lines: 2 });
    expect(await getPhysicalStock(runtime, scope, created.voucherNo)).toMatchObject({
      description: 'Added one tag',
      lines: [{ tagNo: 'TAG001' }, { tagNo: 'TAG002' }],
    });
  }, 30_000);

  it('reconciles exact tag instances and supports paged plus exact scan lookup', async () => {
    await seedTag('DUP', 5, 5);
    await seedTag('DUP', 6, 6);
    const result = await physicalReconcile(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC }, [
      { tagNo: 'DUP', vchSrno: 5 },
    ]);
    expect(result.bookCount).toBe(6);
    expect(result.matched).toContain('DUP|5');
    expect(result.missing).toContain('DUP|6');
    expect(result.detail).toEqual(
      expect.arrayContaining([
        expect.objectContaining({ tagNo: 'DUP', vchSrno: 5, status: 'matched', bookWt: 5 }),
        expect.objectContaining({ tagNo: 'DUP', vchSrno: 6, status: 'missing', bookWt: 6 }),
      ]),
    );

    const firstPage = await physicalStockList(
      runtime,
      TENANT,
      { CO_CODE: CO, LC_CODE: LC },
      { limit: 1, offset: 0 },
    );
    const secondPage = await physicalStockList(
      runtime,
      TENANT,
      { CO_CODE: CO, LC_CODE: LC },
      { limit: 1, offset: 1 },
    );
    expect(firstPage).toHaveLength(1);
    expect(secondPage).toHaveLength(1);
    expect(identityForTest(firstPage[0]!)).not.toBe(identityForTest(secondPage[0]!));
    const exact = await physicalStockList(
      runtime,
      TENANT,
      { CO_CODE: CO, LC_CODE: LC },
      { tagNo: 'DUP', vchSrno: 6 },
    );
    expect(exact).toMatchObject([{ tagNo: 'DUP', vchSrno: 6, netWt: 6 }]);
  }, 30_000);

  it('serializes independent main and hidden MAX+1 numbers for concurrent restricted writers', async () => {
    const [a, b] = await Promise.all([
      savePhysicalStock(runtime, {
        scope,
        vchDate: DAY,
        lines: [{ tagNo: 'TAG003', vchSrno: 3 }],
      }),
      savePhysicalStock(runtime, {
        scope,
        vchDate: DAY,
        lines: [{ tagNo: 'TAG004', vchSrno: 4 }],
      }),
    ]);
    expect([a.voucherNo, b.voucherNo].sort()).toEqual(['00001', '00002']);
    expect([a.hiddenVoucherNo, b.hiddenVoucherNo].sort()).toEqual(['00001', '00002']);
  }, 30_000);
});
