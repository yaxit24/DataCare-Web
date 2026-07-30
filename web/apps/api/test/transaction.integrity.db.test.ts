import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { createPurchase, deletePurchase } from '../src/modules/purchase/purchase.js';
import {
  createPurchaseReturn,
  deletePurchaseReturn,
} from '../src/modules/purchase/purchaseReturn.js';
import { createSale, deleteSale } from '../src/modules/sales/sales.js';
import { createSaleReturn, deleteSaleReturn } from '../src/modules/sales/salesReturn.js';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import { tagAvailable, TagNotAvailableError } from '../src/modules/stock/stock.js';
import { listPrintableTags } from '../src/modules/stock/tagPrint.js';
import { tagStockReport } from '../src/modules/reports/tagStock.js';
import { stockValuation } from '../src/modules/reports/reports.js';
import { stockByLocation } from '../src/modules/reports/reports7.js';
import {
  formatVoucherNo,
  nextVoucherNoTx,
  type VoucherScope,
} from '../src/modules/vouchers/numbering.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'task5-integrity';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';

const scope = (coBook: string, coYear = YEAR): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear,
  coBook,
});

databaseDescribe('database-backed transaction integrity', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'SL_ORD_ADJ',
      'SL_ORD_DETL',
      'UPI_DATA',
      'BILL_OS_DATA',
      'TAX_DATA',
      'AC_DATA',
      'SL_IDTL',
      'SL_PR_DETL',
      'ROJ_MEL_DATA',
      'SL_DETL',
      'SL_DATA',
      'BAR_IDTL',
      'BAR_DETL',
      'PR_IDTL',
      'LOT_DETL',
      'PR_DETL',
      'PR_DATA',
      'MAIN_STOCK',
      'TAG_STOCK',
      'SRNO_MAST',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'CUST','Customer','L'),($1,$2,$3,'SUPP','Supplier','L')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',1,'GST','GST 3%',3,'GSTLED')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,$2,'G01','Gold','SALEAC','PURCAC')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold','G','G01'),($1,$2,'LOOSE','Loose','G','G01')`,
      TENANT,
      CO,
    );
    for (const [book, name, shortName, mainBook, direction, table] of [
      ['SAL', 'Sales', 'SVX', 'SALES', 'O', 'SL_DATA'],
      ['S01', 'Sales One', 'S1X', 'SALES', 'O', 'SL_DATA'],
      ['S02', 'Sales Two', 'S2X', 'SALES', 'O', 'SL_DATA'],
      ['PUR', 'Purchase', 'PVX', 'PURCHASE', 'I', 'PR_DATA'],
      ['SRT', 'Sales Return', 'SRX', 'SALES RETURNE', 'I', 'SL_DATA'],
      ['PRT', 'Purchase Return', 'PRX', 'PURC RETURN', 'O', 'PR_DATA'],
    ]) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
         VALUES ($1,$2,$3,$4,$5,$6,$7,$8,'Y',$9)`,
        TENANT,
        CO,
        LC,
        book,
        name,
        shortName,
        mainBook,
        direction,
        table,
      );
    }
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       SELECT $1,$2,$3,b.book,s.sr,s.ac,b.main,b.io
         FROM (VALUES ('SAL','SALES','O'),('S01','SALES','O'),('S02','SALES','O'),
                      ('PUR','PURCHASE','I'),('SRT','SALES RETURNE','I'),('PRT','PURC RETURN','O')) b(book,main,io)
         CROSS JOIN (VALUES (1,'CTRL'),(2,'CASH'),(3,'ROUND')) s(sr,ac)`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO") VALUES ($1,$2,$3,0,0)`,
      TENANT,
      CO,
      LC,
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

  const allocateAndPersist = async (s: VoucherScope): Promise<number> =>
    withTenant(runtime, TENANT, async (tx: any) => {
      const no = await nextVoucherNoTx(tx, s);
      await tx.$executeRawUnsafe(
        `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE")
         VALUES ($1,$2,$3,$4,$5,$6,$7::date)`,
        TENANT,
        s.coCode,
        s.lcCode,
        s.coYear,
        s.coBook,
        formatVoucherNo(no),
        DAY,
      );
      return no;
    });

  it('allocates padded MAX+1 independently by company/location/year/book under concurrency', async () => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE")
       VALUES ($1,$2,$3,$4,'S01','00007',$5::date)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    const allocated = await Promise.all(
      Array.from({ length: 8 }, () => allocateAndPersist(scope('S01'))),
    );
    expect([...allocated].sort((a, b) => a - b)).toEqual([8, 9, 10, 11, 12, 13, 14, 15]);
    expect(await allocateAndPersist(scope('S02'))).toBe(1);
    expect(await allocateAndPersist(scope('S01', '2025-2026'))).toBe(1);

    await owner.$executeRawUnsafe(
      `DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='S01' AND "CO_YEAR"=$2 AND "VCH_NO"='00015'`,
      TENANT,
      YEAR,
    );
    expect(await allocateAndPersist(scope('S01'))).toBe(15);
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "VCH_NO" FROM "SL_DATA" WHERE tenant_id=$1 ORDER BY "CO_BOOK","CO_YEAR","VCH_NO"`,
      TENANT,
    )) as Array<{ VCH_NO: string }>;
    expect(rows.every((row) => /^\d{5}$/.test(row.VCH_NO))).toBe(true);
  }, 30_000);

  it('posts tagged and loose stock atomically and derives locked reversals from persisted state', async () => {
    const purchase = await createPurchase(
      runtime,
      {
        scope: scope('PUR'),
        acCode: 'SUPP',
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
      },
      [
        { itCode: 'GOLD', tagNo: 'TAG001', pcs: 1, netWt: 10, touch: 100, metalAmount: 1000 },
        { itCode: 'LOOSE', pcs: 1, netWt: 5, touch: 100, metalAmount: 500 },
      ],
    );
    expect(purchase.vchNo).toBe(1);
    const purchaseRows = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "PR_DATA" WHERE tenant_id=$1) pr,
         (SELECT count(*) FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAG001' AND "VCH_SRNO"=1) bar,
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='PUR') stock,
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='PUR' AND "TAG_NO"='N' AND "VCH_SRNO"=0) loose,
         (SELECT count(*) FROM "TAG_STOCK" WHERE tenant_id=$1) legacy_tags,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='PUR' AND "VCH_TYPE"='PVX'
            AND nullif(btrim(coalesce("LD_CODE"::text,'')),'') IS NOT NULL) configured_ledger,
         (SELECT count(*) FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='PUR'
            AND "BOOK_NAME"='PURCHASE' AND "TAX_CODE"='10' AND "TAX_TYPE"='GST') configured_tax`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    expect(Number(purchaseRows[0]?.pr)).toBe(1);
    expect(Number(purchaseRows[0]?.bar)).toBe(1);
    expect(Number(purchaseRows[0]?.stock)).toBe(2);
    expect(Number(purchaseRows[0]?.loose)).toBe(1);
    expect(Number(purchaseRows[0]?.legacy_tags)).toBe(0);
    expect(Number(purchaseRows[0]?.configured_ledger)).toBeGreaterThan(0);
    expect(Number(purchaseRows[0]?.configured_tax)).toBe(2);
    await owner.$executeRawUnsafe(
      `INSERT INTO "PR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO")
       VALUES ($1,$2,$3,$4,'PUR','00001',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO","TAG_SALE","TAG_GEN")
       VALUES ($1,$2,$3,$4,'SOR','00099',1,1,'Y','Y')`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `UPDATE "BAR_DETL" SET "ORD_LC_CODE"=$3,"ORD_YRCD"=$4,"ORD_DBCD"='SOR',"ORD_NO"='00099',"ORD_SRNO"=1
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "TAG_NO"='TAG001'`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await expect(
      listPrintableTags(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC }),
    ).resolves.toHaveLength(1);
    await expect(
      tagStockReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC }, 'stock'),
    ).resolves.toMatchObject({ totals: { count: 1 } });
    await expect(stockValuation(runtime, { tenantId: TENANT, coCode: CO })).resolves.toMatchObject({
      totals: { tags: 1 },
    });
    await expect(stockByLocation(runtime, { tenantId: TENANT, coCode: CO })).resolves.toMatchObject(
      { totals: { locations: 1 } },
    );

    const sale = await createSale(
      runtime,
      {
        scope: scope('SAL'),
        acCode: 'CUST',
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
      },
      [
        {
          itCode: 'GOLD',
          tagNo: 'TAG001',
          vchSrno: 1,
          pcs: 1,
          netWt: 10,
          touch: 100,
          metalAmount: 1100,
        },
        { itCode: 'LOOSE', pcs: 1, netWt: 1, touch: 100, metalAmount: 100 },
      ],
    );
    expect(sale.vchNo).toBe(1);
    const soldRows = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAL'
            AND "ITM_SIGN"='-' AND "VCH_TYPE"='SVX' AND "BOOK_NAME"='SALES') stock,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SAL' AND "VCH_TYPE"='SVX'
            AND nullif(btrim(coalesce("LD_CODE"::text,'')),'') IS NOT NULL) configured_ledger,
         (SELECT count(*) FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SAL'
            AND "BOOK_NAME"='SALES' AND "TAX_CODE"='10' AND "TAX_TYPE"='GST') configured_tax`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    expect(Number(soldRows[0]?.stock)).toBe(2);
    expect(Number(soldRows[0]?.configured_ledger)).toBeGreaterThan(0);
    expect(Number(soldRows[0]?.configured_tax)).toBe(2);
    await owner.$executeRawUnsafe(
      `INSERT INTO "UPI_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","UPI_AMT")
       VALUES ($1,$2,$3,$4,'SAL','00001',1,10)`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await owner.$executeRawUnsafe(
      `UPDATE "SL_DETL" SET "ORD_YRCD"=$4,"ORD_DBCD"='SOR',"ORD_NO"='00099',"ORD_SRNO"=1
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
          AND "CO_BOOK"='SAL' AND "VCH_NO"='00001' AND "TAG_NO"='TAG001'`,
      TENANT,
      CO,
      LC,
      YEAR,
    );
    await expect(
      listPrintableTags(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC }),
    ).resolves.toHaveLength(0);
    await expect(
      tagStockReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC }, 'stock'),
    ).resolves.toMatchObject({ totals: { count: 0 } });
    await expect(stockValuation(runtime, { tenantId: TENANT, coCode: CO })).resolves.toMatchObject({
      totals: { tags: 0 },
    });
    await expect(stockByLocation(runtime, { tenantId: TENANT, coCode: CO })).resolves.toMatchObject(
      { totals: { locations: 0 } },
    );

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$2 WHERE tenant_id=$1 AND "CO_CODE"=$3`,
      TENANT,
      DAY,
      CO,
    );
    await expect(
      deleteSale(runtime, { scope: scope('SAL'), vchNo: sale.vchNo }),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    const stillPosted = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00001'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(stillPosted[0]?.n).toBe(1);

    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );
    await expect(
      deletePurchase(runtime, { scope: scope('PUR'), vchNo: purchase.vchNo }),
    ).rejects.toThrow('tag already issued');
    await deleteSale(runtime, { scope: scope('SAL'), vchNo: sale.vchNo });
    await expect(
      tagAvailable(runtime, TENANT, {
        CO_CODE: CO,
        LC_CODE: LC,
        TAG_NO: 'TAG001',
        VCH_SRNO: 1,
        IT_CODE: 'GOLD',
      }),
    ).resolves.toBe(true);
    await expect(
      listPrintableTags(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC }),
    ).resolves.toHaveLength(1);
    await expect(
      tagStockReport(runtime, TENANT, { CO_CODE: CO, LC_CODE: LC }, 'stock'),
    ).resolves.toMatchObject({ totals: { count: 1 } });
    const saleReversal = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SAL' AND "VCH_NO"='00001') upi,
         (SELECT count(*) FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SOR'
            AND "VCH_NO"='00099' AND "TAG_SALE"='N') order_reset`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    expect(Number(saleReversal[0]?.upi)).toBe(0);
    expect(Number(saleReversal[0]?.order_reset)).toBe(1);
    await deletePurchase(runtime, { scope: scope('PUR'), vchNo: purchase.vchNo });

    const finalRows = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "SL_DATA" WHERE tenant_id=$1) sales,
         (SELECT count(*) FROM "PR_DATA" WHERE tenant_id=$1) purchases,
         (SELECT count(*) FROM "BAR_DETL" WHERE tenant_id=$1) tags,
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1) stock,
         (SELECT count(*) FROM "DELETE_DATA" WHERE tenant_id=$1) deleted,
         (SELECT count(*) FROM "PR_IDTL" WHERE tenant_id=$1) purchase_satellite,
         (SELECT count(*) FROM "SL_ORD_DETL" WHERE tenant_id=$1 AND "TAG_GEN"='N') purchase_order_reset`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    expect(Number(finalRows[0]?.sales)).toBe(0);
    expect(Number(finalRows[0]?.purchases)).toBe(0);
    expect(Number(finalRows[0]?.tags)).toBe(0);
    expect(Number(finalRows[0]?.stock)).toBe(0);
    // Sales contributes 1 header + 2 details; purchase now also contributes 1 header + 2 details.
    expect(Number(finalRows[0]?.deleted)).toBe(6);
    expect(Number(finalRows[0]?.purchase_satellite)).toBe(0);
    expect(Number(finalRows[0]?.purchase_order_reset)).toBe(1);
  }, 30_000);

  it('serializes the exact tag identity so concurrent sales cannot double-issue it', async () => {
    await createPurchase(
      runtime,
      { scope: scope('PUR'), acCode: 'SUPP', vchDate: DAY, taxRatePct: 3, interState: false },
      [{ itCode: 'GOLD', tagNo: 'TAGCON', pcs: 1, netWt: 2, touch: 100, metalAmount: 200 }],
    );
    const sell = (book: string) =>
      createSale(
        runtime,
        { scope: scope(book), acCode: 'CUST', vchDate: DAY, taxRatePct: 3, interState: false },
        [
          {
            itCode: 'GOLD',
            tagNo: 'TAGCON',
            vchSrno: 1,
            pcs: 1,
            netWt: 2,
            touch: 100,
            metalAmount: 220,
          },
        ],
      );
    const outcomes = await Promise.allSettled([sell('S01'), sell('S02')]);
    expect(outcomes.filter((result) => result.status === 'fulfilled')).toHaveLength(1);
    const failure = outcomes.find(
      (result) => result.status === 'rejected',
    ) as PromiseRejectedResult;
    expect(failure.reason).toBeInstanceOf(TagNotAvailableError);
    const issueRows = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"='TAGCON' AND "VCH_SRNO"=1 AND "ITM_SIGN"='-'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(issueRows[0]?.n).toBe(1);
  }, 30_000);

  it('round-trips sale and purchase returns with exact tag identity and configured return books', async () => {
    const purchase = await createPurchase(
      runtime,
      { scope: scope('PUR'), acCode: 'SUPP', vchDate: DAY, taxRatePct: 3, interState: false },
      [
        { itCode: 'GOLD', tagNo: 'TAGRT', pcs: 1, netWt: 3, touch: 100, metalAmount: 300 },
        { itCode: 'LOOSE', pcs: 1, netWt: 1, touch: 100, metalAmount: 100 },
      ],
    );
    const sale = await createSale(
      runtime,
      { scope: scope('SAL'), acCode: 'CUST', vchDate: DAY, taxRatePct: 3, interState: false },
      [
        {
          itCode: 'GOLD',
          tagNo: 'TAGRT',
          vchSrno: 1,
          pcs: 1,
          netWt: 3,
          touch: 100,
          metalAmount: 330,
        },
        { itCode: 'LOOSE', pcs: 1, netWt: 1, touch: 100, metalAmount: 110 },
      ],
    );
    const saleReturn = await createSaleReturn(
      runtime,
      {
        scope: scope('SRT'),
        acCode: 'CUST',
        origBook: 'SAL',
        origVchNo: sale.vchNo,
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
      },
      [
        { itCode: 'GOLD', tagNo: 'TAGRT', pcs: 1, netWt: 3, touch: 100, metalAmount: 330 },
        { itCode: 'LOOSE', pcs: 1, netWt: 1, touch: 100, metalAmount: 110 },
      ],
    );
    await expect(
      tagAvailable(runtime, TENANT, {
        CO_CODE: CO,
        LC_CODE: LC,
        TAG_NO: 'TAGRT',
        VCH_SRNO: 1,
        IT_CODE: 'GOLD',
      }),
    ).resolves.toBe(true);
    const returnRows = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SRT'
            AND "TAG_NO"='TAGRT' AND "VCH_SRNO"=1 AND "ITM_SIGN"='+') tagged,
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SRT'
            AND "TAG_NO"='N' AND "VCH_SRNO"=0 AND "ITM_SIGN"='+') loose,
         (SELECT count(*) FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT'
            AND "BOOK_NAME"='SALES RETURNE' AND "TRAN_TYPE"='S' AND "TAX_CODE"='10') tax,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SRT' AND "VCH_TYPE"='SRX') ledger`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    expect(Number(returnRows[0]?.tagged)).toBe(1);
    expect(Number(returnRows[0]?.loose)).toBe(1);
    expect(Number(returnRows[0]?.tax)).toBe(2);
    expect(Number(returnRows[0]?.ledger)).toBeGreaterThan(0);

    await deleteSaleReturn(runtime, { scope: scope('SRT'), vchNo: saleReturn.vchNo });
    await expect(
      tagAvailable(runtime, TENANT, {
        CO_CODE: CO,
        LC_CODE: LC,
        TAG_NO: 'TAGRT',
        VCH_SRNO: 1,
        IT_CODE: 'GOLD',
      }),
    ).resolves.toBe(false);
    await deleteSale(runtime, { scope: scope('SAL'), vchNo: sale.vchNo });

    const purchaseReturn = await createPurchaseReturn(
      runtime,
      {
        scope: scope('PRT'),
        acCode: 'SUPP',
        origBook: 'PUR',
        origVchNo: purchase.vchNo,
        vchDate: DAY,
        taxRatePct: 3,
        interState: false,
      },
      [
        {
          itCode: 'GOLD',
          tagNo: 'TAGRT',
          vchSrno: 1,
          pcs: 1,
          netWt: 3,
          touch: 100,
          metalAmount: 300,
        },
        { itCode: 'LOOSE', pcs: 1, netWt: 1, touch: 100, metalAmount: 100 },
      ],
    );
    await expect(
      tagAvailable(runtime, TENANT, {
        CO_CODE: CO,
        LC_CODE: LC,
        TAG_NO: 'TAGRT',
        VCH_SRNO: 1,
        IT_CODE: 'GOLD',
      }),
    ).resolves.toBe(false);
    const purchaseReturnRows = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='PRT'
            AND "TAG_NO"='TAGRT' AND "VCH_SRNO"=1 AND "ITM_SIGN"='-') tagged,
         (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='PRT'
            AND "TAG_NO"='N' AND "VCH_SRNO"=0 AND "ITM_SIGN"='-') loose,
         (SELECT count(*) FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='PRT'
            AND "BOOK_NAME"='PURC RETURN' AND "TRAN_TYPE"='P' AND "TAX_CODE"='10') tax,
         (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='PRT' AND "VCH_TYPE"='PRX') ledger`,
      TENANT,
    )) as Array<Record<string, bigint>>;
    expect(Number(purchaseReturnRows[0]?.tagged)).toBe(1);
    expect(Number(purchaseReturnRows[0]?.loose)).toBe(1);
    expect(Number(purchaseReturnRows[0]?.tax)).toBe(2);
    expect(Number(purchaseReturnRows[0]?.ledger)).toBeGreaterThan(0);

    await deletePurchaseReturn(runtime, { scope: scope('PRT'), vchNo: purchaseReturn.vchNo });
    await expect(
      tagAvailable(runtime, TENANT, {
        CO_CODE: CO,
        LC_CODE: LC,
        TAG_NO: 'TAGRT',
        VCH_SRNO: 1,
        IT_CODE: 'GOLD',
      }),
    ).resolves.toBe(true);
  }, 30_000);
});
