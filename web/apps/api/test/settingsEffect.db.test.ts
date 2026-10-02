import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { createPurchase } from '../src/modules/purchase/purchase.js';
import { createSale, SaleValidationError } from '../src/modules/sales/sales.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * Settings EFFECT tests (parity plan P4).
 *
 * The contract is deliberately not "the setting is stored" or "the setting is read" — both were true
 * of settings that changed nothing. It is: **run the same voucher twice with the setting flipped and
 * assert the outcomes differ.** A setting that produces identical results under both values is not
 * honoured, whatever the code looks like.
 *
 * This exists because 74 of the 130 persisted settings were editable in the UI, written on save, and
 * consumed by nothing — for one reason: `resolveSettingsBehaviorTx` read `CO_SET` only, and every one
 * of them lives in `CO_SET_NEW`. `check-settings-parity.mjs` could not see this, because it measures
 * whether a setting is EXPOSED, not whether it has effect.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'settings-effect-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';

databaseDescribe('settings that must change an outcome', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const scope = (coBook: string): VoucherScope => ({
    tenantId: TENANT,
    coCode: CO,
    lcCode: LC,
    coYear: YEAR,
    coBook,
  });

  const clean = async () => {
    const tables: string[] = await owner
      .$queryRawUnsafe<Array<{ table_name: string }>>(
        `SELECT table_name FROM information_schema.columns
          WHERE table_schema='public' AND column_name='tenant_id'`,
      )
      .then((rows) => rows.map((r) => r.table_name));
    for (const table of tables) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  /** Replace the CO_SET_NEW row with exactly the flags a case needs. */
  const setNewFlags = async (flags: Record<string, string>) => {
    await owner.$executeRawUnsafe(`DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1`, TENANT);
    const cols = Object.keys(flags);
    const values = cols.map((_, i) => `$${i + 3}`).join(',');
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE"${cols.length ? ',' + cols.map((c) => `"${c}"`).join(',') : ''})
       VALUES ($1,$2${cols.length ? ',' + values : ''})`,
      TENANT,
      CO,
      ...cols.map((c) => flags[c]),
    );
  };

  const seed = async () => {
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
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_TYPE")
       VALUES ($1,$2,$3,'CUST','Settings Customer','L'),($1,$2,$3,'SUPP','Settings Supplier','L')`,
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
       VALUES ($1,$2,'LOOSE','Loose Gold','G','G01')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'SAL','Settings Sale','SSL','SALES','O','Y','SL_DATA'),
              ($1,$2,$3,'PUR','Settings Purchase','SPR','PURCHASE','I','Y','PR_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'SAL',1,'CTRL','SALES','O'),($1,$2,$3,'SAL',2,'CASH','SALES','O'),
              ($1,$2,$3,'SAL',3,'ROUND','SALES','O'),
              ($1,$2,$3,'PUR',1,'CTRL','PURCHASE','I'),($1,$2,$3,'PUR',2,'CASH','PURCHASE','I'),
              ($1,$2,$3,'PUR',3,'ROUND','PURCHASE','I')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_SRNO","TAG_SRNO")
       VALUES ($1,$2,$3,0,0)`,
      TENANT,
      CO,
      LC,
    );
  };

  /** Put loose stock of `weight` into MAIN_STOCK so a sale has something to sell. */
  const stockIn = async (weight: number) => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "MAIN_STOCK"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,$2,$3,$4,'PUR','09999',1,$5::date,'LOOSE','N',0,'P','+',1,1,$6,$6)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
      weight,
    );
  };

  // createSale takes lines as a SEPARATE argument, like createPurchase.
  const saleHeader = (extra: Record<string, unknown> = {}) =>
    ({
      scope: scope('SAL'),
      acCode: 'CUST',
      vchDate: DAY,
      taxRatePct: 3,
      interState: false,
      ...extra,
    }) as never;
  const saleLines = (netWt: number) =>
    [{ itCode: 'LOOSE', pcs: 1, grossWt: netWt, netWt, touch: 100, rate: 6000 }] as never;
  const sell = (netWt: number, extra: Record<string, unknown> = {}) =>
    createSale(runtime, saleHeader(extra), saleLines(netWt));

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
    await clean();
    await seed();
  });

  afterAll(async () => {
    await clean();
    await owner?.$disconnect();
    await runtime?.$disconnect();
  });

  /**
   * `NEGATIVE_STK_SALE` — the case that can lose real money.
   *
   * Desktop refuses with "Negative Stock is Not Allow" (TR_SALE.cs:10398). Tagged lines were already
   * safe because `issueTagTx` reserves the instance; LOOSE lines had no check at all, so a shop could
   * sell metal it did not hold.
   */
  it('NEGATIVE_STK_SALE refuses an oversell when N and permits it when Y', async () => {
    await stockIn(1);

    await setNewFlags({ NEGATIVE_STK_SALE: 'N' });
    await expect(sell(2)).rejects.toBeInstanceOf(SaleValidationError);

    // Same voucher, flag flipped: a wholesale desk that books the purchase after the sale needs this.
    await setNewFlags({ NEGATIVE_STK_SALE: 'Y' });
    const allowed = await sell(2);
    expect(Number(allowed.vchNo)).toBeGreaterThan(0);
  }, 30_000);

  it('NEGATIVE_STK_SALE permits a sale within available stock either way', async () => {
    await stockIn(10);
    await setNewFlags({ NEGATIVE_STK_SALE: 'N' });
    const ok = await sell(4);
    expect(Number(ok.vchNo)).toBeGreaterThan(0);
  }, 30_000);

  /**
   * `SALES_WITH_HMTAX` / `PURC_WITH_HMTAX` — whether GST applies to the hallmark charge.
   *
   * The web computed it whenever an `hmAmount` was supplied, so a company configured not to charge it
   * was charging it anyway. The charge itself still posts either way; only its tax is gated.
   */
  it('SALES_WITH_HMTAX gates the hallmark tax but not the hallmark charge', async () => {
    await stockIn(20);
    await setNewFlags({ NEGATIVE_STK_SALE: 'Y', SALES_WITH_HMTAX: 'Y' });
    const taxed = await sell(1, { hallmarkAmount: 500 });

    await setNewFlags({ NEGATIVE_STK_SALE: 'Y', SALES_WITH_HMTAX: 'N' });
    const untaxed = await sell(1, { hallmarkAmount: 500 });

    const header = async (vchNo: unknown) => {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT "HM_AMT"::float8 AS hm, "HM_TAX_AMT"::float8 AS hmtax
           FROM "SL_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        TENANT,
        String(vchNo).padStart(5, '0'),
      )) as Array<{ hm: number; hmtax: number }>;
      return rows[0]!;
    };

    const on = await header(taxed.vchNo);
    const off = await header(untaxed.vchNo);
    // The charge is unaffected by the switch...
    expect(on.hm).toBeCloseTo(500, 2);
    expect(off.hm).toBeCloseTo(500, 2);
    // ...and the tax on it is exactly what the switch controls.
    expect(on.hmtax).toBeGreaterThan(0);
    expect(off.hmtax).toBe(0);
  }, 30_000);

  it('PURC_WITH_HMTAX gates the hallmark tax on a purchase', async () => {
    const purchase = () =>
      [
        {
          scope: scope('PUR'),
          acCode: 'SUPP',
          vchDate: DAY,
          taxRatePct: 3,
          interState: false,
          hmAmount: 400,
        },
        [{ itCode: 'LOOSE', pcs: 1, grossWt: 5, netWt: 5, touch: 100, rate: 6000 }],
      ] as const;

    await setNewFlags({ PURC_WITH_HMTAX: 'Y' });
    const [hOn, lOn] = purchase();
    const taxed = await createPurchase(runtime, hOn as never, lOn as never);

    await setNewFlags({ PURC_WITH_HMTAX: 'N' });
    const [hOff, lOff] = purchase();
    const untaxed = await createPurchase(runtime, hOff as never, lOff as never);

    const hmTaxOf = async (vchNo: unknown) => {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT "HM_TAX_AMT"::float8 AS hmtax FROM "PR_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        TENANT,
        String(vchNo).padStart(5, '0'),
      )) as Array<{ hmtax: number }>;
      return rows[0]!.hmtax;
    };
    expect(await hmTaxOf(taxed.vchNo)).toBeGreaterThan(0);
    expect(await hmTaxOf(untaxed.vchNo)).toBe(0);
  }, 30_000);

  /**
   * `PR_TDS_TAX` — the desktop writes TDS columns only when the company charges TDS, and explicitly
   * writes blank/zero otherwise (TR_PURC.cs:12160-12172).
   */
  it('PR_TDS_TAX gates whether purchase TDS is persisted at all', async () => {
    const purchase = () =>
      [
        {
          scope: scope('PUR'),
          acCode: 'SUPP',
          vchDate: DAY,
          taxRatePct: 3,
          interState: false,
          tdsCode: 'TDS1',
          tdsPct: 1,
          tdsAmount: 60,
        },
        [{ itCode: 'LOOSE', pcs: 1, grossWt: 5, netWt: 5, touch: 100, rate: 6000 }],
      ] as const;

    await setNewFlags({ PR_TDS_TAX: 'Y' });
    const [hOn, lOn] = purchase();
    const on = await createPurchase(runtime, hOn as never, lOn as never);

    await setNewFlags({ PR_TDS_TAX: 'N' });
    const [hOff, lOff] = purchase();
    const off = await createPurchase(runtime, hOff as never, lOff as never);

    const tdsOf = async (vchNo: unknown) => {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT coalesce("TDS_CODE",'') AS code, "TDS_AMT"::float8 AS amt
           FROM "PR_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        TENANT,
        String(vchNo).padStart(5, '0'),
      )) as Array<{ code: string; amt: number }>;
      return rows[0]!;
    };
    const enabled = await tdsOf(on.vchNo);
    const disabled = await tdsOf(off.vchNo);
    expect(enabled.code).toBe('TDS1');
    expect(enabled.amt).toBeCloseTo(60, 2);
    expect(disabled.code).toBe('');
    expect(disabled.amt).toBe(0);
  }, 30_000);

  /**
   * A company provisioned before `CO_SET_NEW` existed legitimately has no row. Failing closed there
   * would take a live company down to honour a setting it never had, so absence must read as
   * "every flag blank" and behave exactly as the product did before this phase.
   */
  it('treats a missing CO_SET_NEW row as all-flags-blank rather than an error', async () => {
    await owner.$executeRawUnsafe(`DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1`, TENANT);
    await stockIn(10);
    const ok = await sell(2);
    expect(Number(ok.vchNo)).toBeGreaterThan(0);
  }, 30_000);
  /**
   * `LBR_WITH_GHT` — whether ghat weight is part of the per-gram labour base.
   *
   * Desktop: `LbrAmt = (NetWt + GhtWt) x LbrRate`, dropping the ghat term only when the flag is 'N'
   * (TR_SALE.cs:11112-11123; the same branch in TR_APR_ISU.cs:4255 and TR_BUL_SALE.cs:5513, :5594,
   * :7121). Blank defaults to 'Y' (MS_OPNCOMP.cs:1224-1226).
   *
   * The web passed no ghat at all, so every per-gram labour charge on a line carrying ghat weight was
   * understated by `ghat x rate`. No existing test caught it because none combined ghat weight with a
   * per-gram labour rate — which is exactly how a money defect survives a green suite.
   */
  it('LBR_WITH_GHT includes ghat in the per-gram labour base, and excludes it when N', async () => {
    await stockIn(50);
    const lineWithGhat = () =>
      [
        {
          itCode: 'LOOSE',
          pcs: 1,
          grossWt: 11,
          netWt: 10,
          ghtWt: 2,
          touch: 100,
          rate: 6000,
          labourType: 'per_gram' as const,
          labourRate: 50,
        },
      ] as never;

    await setNewFlags({ NEGATIVE_STK_SALE: 'Y', LBR_WITH_GHT: 'Y' });
    const withGhat = await createSale(runtime, saleHeader(), lineWithGhat());

    await setNewFlags({ NEGATIVE_STK_SALE: 'Y', LBR_WITH_GHT: 'N' });
    const withoutGhat = await createSale(runtime, saleHeader(), lineWithGhat());

    const labourOf = async (vchNo: unknown) => {
      const rows = (await owner.$queryRawUnsafe(
        `SELECT "LBR_AMT"::float8 AS lbr FROM "SL_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
        TENANT,
        String(vchNo).padStart(5, '0'),
      )) as Array<{ lbr: number }>;
      return rows[0]!.lbr;
    };

    // (10 + 2) x 50 = 600 with ghat; 10 x 50 = 500 without.
    expect(await labourOf(withGhat.vchNo)).toBeCloseTo(600, 0);
    expect(await labourOf(withoutGhat.vchNo)).toBeCloseTo(500, 0);
  }, 30_000);
});
