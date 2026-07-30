import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PeriodLockValidationError } from '../src/modules/posting/posting.js';
import {
  createPurchase,
  deletePurchase,
  editPurchase,
  getPurchase,
  PurchaseValidationError,
} from '../src/modules/purchase/purchase.js';
import { createSale } from '../src/modules/sales/sales.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';
import { footprintOf, ledgerLegs, voucherTables } from './support/footprint.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'purchase-lifecycle-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'PUR';
/**
 * Established empirically by posting a purchase and enumerating every VCH_NO table that received rows.
 *
 * Richer than a sale's because a purchase CREATES stock: it registers tags (BAR_DETL, BAR_IDTL) and the lot
 * they belong to (LOT_DETL) as well as posting the ledger and tax. Those three are the tables a silent
 * regression would be most costly in — stock that exists on the bill but not in the tag ledger.
 */
const FOOTPRINT_PURCHASE: string[] = [
  'AC_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'BILL_OS_DATA',
  'LOT_DETL',
  'MAIN_STOCK',
  'PR_DATA',
  'PR_DETL',
  'TAX_DATA',
];
const DAY = '2024-04-10';
const scope: VoucherScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: BOOK,
};

const purchaseInput = (overrides: Record<string, unknown> = {}) => ({
  scope,
  mainUser: 'original-user',
  acCode: 'SUPP',
  acName: 'Lifecycle Supplier',
  vchDate: DAY,
  taxRatePct: 3,
  interState: false,
  cashAmt: 10,
  cardAmt: 20,
  chequeAmt: 30,
  ...overrides,
});

const firstLines = [
  {
    itCode: 'GOLD',
    tagNo: 'TAG001',
    pcs: 1,
    grossWt: 10,
    netWt: 10,
    touch: 91.6,
    metalAmount: 1000,
    metal: 'G' as const,
  },
  {
    itCode: 'LOOSE',
    pcs: 1,
    grossWt: 2,
    netWt: 2,
    touch: 90,
    metalAmount: 200,
    metal: 'G' as const,
  },
];

const replacementLines = [
  {
    itCode: 'GOLD',
    tagNo: 'TAG002',
    pcs: 1,
    grossWt: 9,
    netWt: 8.5,
    touch: 92,
    metalAmount: 1100,
    metal: 'G' as const,
  },
  {
    itCode: 'LOOSE',
    pcs: 2,
    grossWt: 3,
    netWt: 3,
    touch: 88,
    metalAmount: 300,
    metal: 'G' as const,
  },
];

databaseDescribe('database-backed purchase voucher lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'BILL_OS_DATA',
      'TAX_DATA',
      'AC_DATA',
      'SL_IDTL',
      'ROJ_MEL_DATA',
      'SL_DETL',
      'SL_DATA',
      'SL_PR_DETL',
      'BAR_IDTL',
      'BAR_DETL',
      'BAR_DATA',
      'PR_IDTL',
      'PR_DETL',
      'PR_DATA',
      'ITM_LOT_DETL',
      'USER_DATA',
      'LOT_DETL',
      'MAIN_STOCK',
      'TEMP_BOOK_DATA',
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
       VALUES ($1,$2,$3,'SUPP','Lifecycle Supplier','L'),
              ($1,$2,$3,'CUST','Lifecycle Customer','L')`,
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
       VALUES ($1,$2,'GOLD','Gold','G','G01'),($1,$2,'LOOSE','Loose Gold','G','G01')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'PUR','Configured Purchase Book','CPB','PURCHASE','I','Y','PR_DATA'),
              ($1,$2,$3,'SAL','Configured Sales Book','CSB','SALES','O','Y','SL_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'PUR',1,'CTRL','PURCHASE','I'),
              ($1,$2,$3,'PUR',2,'CASH','PURCHASE','I'),
              ($1,$2,$3,'PUR',3,'ROUND','PURCHASE','I'),
              ($1,$2,$3,'SAL',1,'CTRL','SALES','O'),
              ($1,$2,$3,'SAL',2,'CASH','SALES','O'),
              ($1,$2,$3,'SAL',3,'ROUND','SALES','O')`,
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
    await owner.$executeRawUnsafe(
      `INSERT INTO "PR_DATA"(
         tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
       VALUES ($1,$2,$3,$4,'PUR','00007',$5::date,'SUPP')`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "TEMP_BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","VCH_NO","BOOK_NAME")
       VALUES ($1,$2,$3,'PUR','00040','Configured Purchase Book')`,
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

  it('creates, opens and edits with independent numbering and preserved identity without delete audit', async () => {
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    expect(created.vchNo).toBe(8);

    const persisted = (await owner.$queryRawUnsafe(
      `SELECT p."VCH_NO",p."HD_VCH_NO",p."MAIN_USER",p."VCH_TIME"::date::text time_date,
              to_char(p."VCH_TIME",'HH24:MI:SS.MS') clock,t."BOOK_NAME"
         FROM "PR_DATA" p JOIN "TEMP_BOOK_DATA" t
           ON t.tenant_id=p.tenant_id AND t."CO_CODE"=p."CO_CODE" AND t."LC_CODE"=p."LC_CODE"
          AND t."CO_BOOK"=p."CO_BOOK" AND t."VCH_NO"=p."HD_VCH_NO"
        WHERE p.tenant_id=$1 AND p."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(persisted[0]).toMatchObject({
      VCH_NO: '00008',
      HD_VCH_NO: '00041',
      MAIN_USER: 'original-user',
      time_date: DAY,
      BOOK_NAME: 'Configured Purchase Book',
    });
    const originalClock = String(persisted[0]?.clock);

    await expect(getPurchase(runtime, scope, created.vchNo)).resolves.toMatchObject({
      voucherNo: '00008',
      hiddenVoucherNo: '00041',
      mainUser: 'original-user',
      vchDate: DAY,
      acCode: 'SUPP',
      lines: [
        { itCode: 'GOLD', tagNo: 'TAG001', vchSrno: 1 },
        { itCode: 'LOOSE', tagNo: '' },
      ],
      tags: [{ itCode: 'GOLD', tagNo: 'TAG001', vchSrno: 1 }],
    });

    await expect(
      editPurchase(
        runtime,
        purchaseInput({
          mainUser: 'different-user',
          acName: 'request-controlled spoof',
          vchDate: '2024-04-11',
        }),
        replacementLines.map((line) => ({ ...line, metal: 'S' as const })),
        created.vchNo,
      ),
    ).resolves.toMatchObject({ vchNo: 8 });

    const edited = (await owner.$queryRawUnsafe(
      `SELECT p."HD_VCH_NO",p."MAIN_USER",p."AC_NAME",p."IT_TYPE",to_char(p."VCH_TIME",'HH24:MI:SS.MS') clock,
              p."VCH_TIME"::date::text time_date,
              (SELECT count(*)::int FROM "PR_DETL" d WHERE d.tenant_id=$1 AND d."VCH_NO"='00008') details,
              (SELECT count(*)::int FROM "DELETE_DATA" x WHERE x.tenant_id=$1) audits,
              (SELECT count(*)::int FROM "BAR_DETL" b WHERE b.tenant_id=$1
                AND b."CO_BOOK"='PUR' AND b."VCH_NO"='00008' AND b."TAG_NO"='TAG002') tags,
              (SELECT count(*)::int FROM "MAIN_STOCK" m WHERE m.tenant_id=$1
                AND m."CO_BOOK"='PUR' AND m."VCH_NO"='00008' AND m."TAG_NO"='TAG002'
                AND m."ITM_SIGN"='+') tag_receipts,
              (SELECT count(*)::int FROM "BAR_DETL" b WHERE b.tenant_id=$1
                AND b."CO_BOOK"='PUR' AND b."VCH_NO"='00008' AND b."TAG_NO"='TAG001') old_tags
         FROM "PR_DATA" p WHERE p.tenant_id=$1 AND p."VCH_NO"='00008'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(edited[0]).toMatchObject({
      HD_VCH_NO: '00041',
      MAIN_USER: 'original-user',
      AC_NAME: 'Lifecycle Supplier',
      IT_TYPE: 'G',
      clock: originalClock,
      time_date: '2024-04-11',
      details: 2,
      audits: 0,
      tags: 1,
      tag_receipts: 1,
      old_tags: 0,
    });

    // GV-PRDETL-001/002: TR_PURC.cs mSG_PR[Row,40] = lbrAmt + othAmt + itmAmt at TWO decimals (no
    // Math.Round — unlike the sale line total), and mSG_PR[Row,44] = total + commission when tax% = 0.
    const prMoney = (await owner.$queryRawUnsafe(
      `SELECT "ITM_AMT"::float itm, "LBR_AMT"::float lbr, "OTH_AMT"::float oth,
              "COMM_AMT"::float comm, "TOT_AMT"::float tot, "NET_AMT"::float net
         FROM "PR_DETL" WHERE tenant_id=$1 AND "VCH_NO"='00008' ORDER BY "SR_NO"`,
      TENANT,
    )) as Array<{ itm: number; lbr: number; oth: number; comm: number; tot: number; net: number }>;
    expect(prMoney.length).toBeGreaterThan(0);
    for (const row of prMoney) {
      const expectedTotal = Math.round((row.itm + row.lbr + row.oth) * 100) / 100;
      expect(row.tot).toBeCloseTo(expectedTotal, 2);
      expect(row.net).toBeCloseTo(Math.round((expectedTotal + row.comm) * 100) / 100, 2);
    }
  }, 30_000);

  it('rejects and fully rolls back edit after a created tag was sold', async () => {
    const created = await createPurchase(runtime, purchaseInput(), [firstLines[0]!]);
    await createSale(
      runtime,
      {
        scope: { ...scope, coBook: 'SAL' },
        mainUser: 'seller',
        acCode: 'CUST',
        acName: 'Lifecycle Customer',
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
          grossWt: 10,
          netWt: 10,
          touch: 91.6,
          metalAmount: 1100,
        },
      ],
    );
    const before = await getPurchase(runtime, scope, created.vchNo);

    await expect(
      editPurchase(runtime, purchaseInput(), replacementLines, created.vchNo),
    ).rejects.toEqual(
      expect.objectContaining<Partial<PurchaseValidationError>>({
        name: 'PurchaseValidationError',
        message: 'tag already issued and purchase cannot be edited: TAG001',
      }),
    );

    expect(await getPurchase(runtime, scope, created.vchNo)).toEqual(before);
    const state = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits,
         (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='PUR'
           AND "VCH_NO"='00008' AND "TAG_NO"='TAG001') purchase_tags,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAL'
           AND "TAG_NO"='TAG001' AND "VCH_SRNO"=1 AND "ITM_SIGN"='-') sale_issues`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(state[0]).toEqual({ audits: 0, purchase_tags: 1, sale_issues: 1 });
  }, 30_000);

  it('refuses a voucher whose footer totals are all zero, in desktop wording', async () => {
    // TR_PURC.cs: labour amount + pieces + gross weight + net amount all zero means no content.
    await expect(
      createPurchase(runtime, purchaseInput(), [
        {
          itCode: 'LOOSE',
          pcs: 0,
          grossWt: 0,
          netWt: 0,
          touch: 0,
          metalAmount: 0,
          metal: 'G' as const,
        },
      ]),
    ).rejects.toThrow('Please Insert Party Entry And Try.....');
  }, 30_000);

  it('freezes the item code of a tagged line on edit, in desktop wording', async () => {
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    // TR_PURC.cs ItCodeLock: TAG001 already carries GOLD in stock, so the item code cannot change.
    await expect(
      editPurchase(
        runtime,
        purchaseInput(),
        [{ ...firstLines[0], itCode: 'LOOSE' }, firstLines[1]],
        created.vchNo,
      ),
    ).rejects.toThrow(
      'You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag',
    );
  }, 30_000);

  it('allows an edit that keeps the tagged item code, and lets untagged lines change freely', async () => {
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    const edited = await editPurchase(
      runtime,
      purchaseInput(),
      [
        { ...firstLines[0], netWt: 9.5 },
        { ...firstLines[1], itCode: 'GOLD' },
      ],
      created.vchNo,
    );
    expect(String(edited.vchNo).padStart(5, '0')).toBe(String(created.vchNo).padStart(5, '0'));
  }, 30_000);

  it('rejects an edit locked by the persisted date and leaves the voucher unchanged', async () => {
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    const before = await getPurchase(runtime, scope, created.vchNo);
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"=$3`,
      DAY,
      TENANT,
      CO,
    );

    await expect(
      editPurchase(
        runtime,
        purchaseInput({ vchDate: '2024-04-20' }),
        replacementLines,
        created.vchNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);

    expect(await getPurchase(runtime, scope, created.vchNo)).toEqual(before);
    const state = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits,
         (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='PUR'
           AND "VCH_NO"='00008' AND "TAG_NO"='TAG001') tags,
         (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='PUR'
           AND "VCH_NO"='00008' AND "TAG_NO"='TAG001' AND "ITM_SIGN"='+') receipts`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(state[0]).toEqual({ audits: 0, tags: 1, receipts: 1 });
  }, 30_000);

  it('rejects an edit locked only by the requested date and leaves the voucher unchanged', async () => {
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    const before = await getPurchase(runtime, scope, created.vchNo);
    await owner.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "LOCK_DATE"='2024-04-09'::date WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      TENANT,
      CO,
    );

    await expect(
      editPurchase(
        runtime,
        purchaseInput({ vchDate: '2024-04-09' }),
        replacementLines,
        created.vchNo,
      ),
    ).rejects.toBeInstanceOf(PeriodLockValidationError);
    expect(await getPurchase(runtime, scope, created.vchNo)).toEqual(before);
  }, 30_000);

  it('deletes with one configured-book header audit plus one desktop-shaped row per purchase line', async () => {
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    await owner.$executeRawUnsafe(
      `UPDATE "PR_DATA" SET "TOT_AMT"=500,"CASH_AMT"=5,"CARD_AMT"=4,"CHQ_AMT"=3,
              "IT_TYPE"='G',"PARTY_FINE"=11.5,"VCH_DESC"='purchase deleted'
        WHERE tenant_id=$1 AND "VCH_NO"='00008'`,
      TENANT,
    );
    await expect(
      deletePurchase(runtime, { scope, vchNo: created.vchNo, deleteUser: 'current-user' }),
    ).resolves.toEqual({ reversed: true });

    const audits = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr,"VCH_TYPE" type,"BOOK_NAME" book,"AC_CODE" ac,"AC_NAME" name,
              "VCH_VAL_DR" dr,"VCH_VAL_CR" cr,"FINE_TYPE" fine_type,
              "VCH_FINE_DR"::float fine_dr,"VCH_FINE_CR"::float fine_cr,
              "HD_VCH_NO" hidden,"MAIN_USER" main_user,"DELETE_USER" delete_user,"VCH_DESC" description
         FROM "DELETE_DATA" WHERE tenant_id=$1 ORDER BY "SR_NO"`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(audits).toHaveLength(3);
    expect(audits[0]).toMatchObject({
      sr: 0,
      type: 'CPB',
      book: 'Configured Purchase Book',
      ac: 'SUPP',
      name: 'Lifecycle Supplier',
      dr: 12,
      cr: 500,
      fine_type: 'G',
      fine_dr: 0,
      fine_cr: 11.5,
      hidden: '00041',
      main_user: 'original-user',
      delete_user: 'current-user',
      description: 'purchase deleted',
    });
    expect(audits[1]).toMatchObject({
      sr: 1,
      type: 'CPB',
      book: 'Configured Purchase Book',
      name: 'Lifecycle Supplier',
      dr: 0,
      cr: 1000,
      fine_type: 'G',
      fine_cr: 9.16,
      description: 'ItCode/GOLD',
    });
    expect(audits[2]).toMatchObject({
      sr: 2,
      dr: 0,
      cr: 200,
      fine_type: 'G',
      fine_cr: 1.8,
      description: 'ItCode/LOOSE',
    });
    const remaining = (await owner.$queryRawUnsafe(
      `SELECT
         (SELECT count(*)::int FROM "PR_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00008') headers,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "VCH_NO"='00041') temp_rows`,
      TENANT,
    )) as Array<{ headers: number; temp_rows: number }>;
    expect(remaining[0]).toEqual({ headers: 0, temp_rows: 0 });
  }, 30_000);

  // Depth gate (Phase B): the desktop purchase header persists party address/contact, bank and
  // cheque reference, credit terms, bill discount % and the TDS/TCS settlement rows
  // (TR_PURC.cs:12982-13056). Asserted as a full set so a dropped column fails here.
  it('persists every desktop purchase header column', async () => {
    const created = await createPurchase(
      runtime,
      purchaseInput({
        address1: 'Shop 12, Gold Market',
        address2: 'Ring Road',
        address3: 'Near Temple',
        city: 'Rajkot',
        mobile: '9876543210',
        bankName: 'State Bank',
        chequeNo: 'CHQ-8891',
        cardAc: 'CARDAC',
        creditDays: 21,
        discountPct: 1.5,
        tcsCode: 'TCS1',
        tcsPct: 0.1,
        tcsAmount: 12.34,
        tdsCode: 'TDS1',
        tdsPct: 0.2,
        tdsAmount: 56.78,
      }),
      firstLines,
    );

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "ADD1","ADD2","ADD3","CITY","MOBILE","BANK_NAME","CHQ_NO","CARD_AC",
              "CR_DAYS"::float cr_days, "DISC_PRC"::float disc_prc,
              "TCS_CODE","TCS_PRC"::float tcs_prc,"TCS_AMT"::float tcs_amt,
              "TDS_CODE","TDS_PRC"::float tds_prc,"TDS_AMT"::float tds_amt,
              "OZ_RATE"::float oz_rate,"OZ_CONV"::float oz_conv,"FX_RATE"::float fx_rate,
              "FX_CODE","MTL_RATE"::float mtl_rate
         FROM "PR_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      String(created.vchNo).padStart(5, '0'),
    )) as Array<Record<string, unknown>>;
    expect(rows).toHaveLength(1);
    const row = rows[0]!;

    expect(String(row.ADD1 ?? '').trim()).toBe('Shop 12, Gold Market');
    expect(String(row.ADD2 ?? '').trim()).toBe('Ring Road');
    expect(String(row.ADD3 ?? '').trim()).toBe('Near Temple');
    expect(String(row.CITY ?? '').trim()).toBe('Rajkot');
    expect(String(row.MOBILE ?? '').trim()).toBe('9876543210');
    expect(String(row.BANK_NAME ?? '').trim()).toBe('State Bank');
    expect(String(row.CHQ_NO ?? '').trim()).toBe('CHQ-8891');
    expect(String(row.CARD_AC ?? '').trim()).toBe('CARDAC');
    expect(row.cr_days).toBe(21);
    expect(row.disc_prc).toBeCloseTo(1.5, 2);
    expect(String(row.TCS_CODE ?? '').trim()).toBe('TCS1');
    expect(row.tcs_prc).toBeCloseTo(0.1, 2);
    expect(row.tcs_amt).toBeCloseTo(12.34, 2);
    expect(String(row.TDS_CODE ?? '').trim()).toBe('TDS1');
    expect(row.tds_prc).toBeCloseTo(0.2, 2);
    expect(row.tds_amt).toBeCloseTo(56.78, 2);
    // Desktop writes literal zeros/blank for these on the purchase book.
    expect(row.oz_rate).toBe(0);
    expect(row.oz_conv).toBe(0);
    expect(row.fx_rate).toBe(0);
    expect(String(row.FX_CODE ?? '').trim()).toBe('');
    expect(row.mtl_rate).toBe(0);
  }, 30_000);

  // Depth gate (Phase B): PR_IDTL is the stone/diamond sub-detail the desktop writes from the
  // DtIdtlPr grid (TR_PURC.cs:13211-13243). It was previously never written by the web.
  it('writes the stone sub-detail and reverses it on delete', async () => {
    const created = await createPurchase(runtime, purchaseInput(), [
      {
        itCode: 'LOOSE',
        pcs: 1,
        grossWt: 5,
        netWt: 5,
        touch: 91.6,
        metalAmount: 500,
        metal: 'G' as const,
        stones: [
          {
            itCode: 'DIA1',
            dmCode: 'DM1',
            dmName: 'Round Brilliant',
            dmColor: 'VS1',
            dmSize: '2.5MM',
            dmOrigin: 'NATURAL',
            dmRemark: 'centre stone',
            dmSfNo: 'SF-9',
            pcs: 3,
            grossWt: 0.45,
            conPct: 12.5,
            rateType: 'C',
            rate: 45_000,
            amount: 20_250,
            lbrRate: 100,
            lbrAmount: 300,
            netAmount: 20_550,
            conWt: 0.05,
            itType: 'D',
          },
          { isrNo: 2, itCode: 'DIA2', dmCode: 'DM2', pcs: 2, grossWt: 0.2, amount: 5_000 },
        ],
      },
    ]);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr_no,"ISR_NO"::int isr_no,"IT_CODE","DM_CODE","DM_NAME","DM_COLOR",
              "DM_SIZE","DM_ORIGIN","DM_REMARK","DM_SFNO","IT_PCS"::float it_pcs,
              "IT_GWT"::float it_gwt,"IT_CON_PRC"::float con_prc,"IT_RATE_TYPE",
              "IT_RATE"::float it_rate,"IT_AMT"::float it_amt,"IT_LBR_RATE"::float lbr_rate,
              "IT_LBR_AMT"::float lbr_amt,"IT_NET_AMT"::float net_amt,"IT_CON_WT"::float con_wt,
              "IT_TYPE","AC_CODE","VCH_TYPE","ENTRY_TYPE","INOUT_TYPE","MAIN_USER"
         FROM "PR_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "ISR_NO"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(rows).toHaveLength(2);

    const first = rows[0]!;
    expect(first.sr_no).toBe(1);
    expect(first.isr_no).toBe(1);
    expect(String(first.IT_CODE).trim()).toBe('DIA1');
    expect(String(first.DM_CODE).trim()).toBe('DM1');
    expect(String(first.DM_NAME).trim()).toBe('Round Brilliant');
    expect(String(first.DM_COLOR).trim()).toBe('VS1');
    expect(String(first.DM_SIZE).trim()).toBe('2.5MM');
    expect(String(first.DM_ORIGIN).trim()).toBe('NATURAL');
    expect(String(first.DM_REMARK).trim()).toBe('centre stone');
    expect(String(first.DM_SFNO).trim()).toBe('SF-9');
    expect(first.it_pcs).toBe(3);
    expect(first.it_gwt).toBeCloseTo(0.45, 3);
    expect(first.con_prc).toBeCloseTo(12.5, 2);
    expect(String(first.IT_RATE_TYPE).trim()).toBe('C');
    expect(first.it_rate).toBeCloseTo(45_000, 2);
    expect(first.it_amt).toBeCloseTo(20_250, 2);
    expect(first.lbr_rate).toBeCloseTo(100, 2);
    expect(first.lbr_amt).toBeCloseTo(300, 2);
    expect(first.net_amt).toBeCloseTo(20_550, 2);
    expect(first.con_wt).toBeCloseTo(0.05, 3);
    expect(String(first.IT_TYPE).trim()).toBe('D');
    // Header-derived columns come from the book/scope, never from the request body.
    expect(String(first.AC_CODE).trim()).toBe('SUPP');
    expect(String(first.ENTRY_TYPE).trim()).toBe('P');
    expect(String(first.INOUT_TYPE).trim()).toBe('I');
    expect(String(first.MAIN_USER).trim()).toBe('original-user');
    // An explicit ISR_NO is honoured rather than renumbered.
    expect(rows[1]!.isr_no).toBe(2);
    expect(String(rows[1]!.IT_CODE).trim()).toBe('DIA2');

    await deletePurchase(runtime, {
      scope,
      vchNo: created.vchNo,
      deleteUser: 'deleter',
    });
    const after = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "PR_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<{ n: number }>;
    expect(after[0]!.n).toBe(0);
  }, 30_000);

  // Depth gate (Phase B): LOT_DETL is the lot register desktop populates after saving a purchase
  // (Ac_Stock.cs:624 `PrKr_Lot`, filtered to MAIN_BOOK IN ('PURCHASE','B2B PURC') and BOOK_INOUT='I').
  it('populates the lot register from the saved purchase and reverses it on delete', async () => {
    const created = await createPurchase(runtime, purchaseInput(), [
      {
        itCode: 'LOOSE',
        pcs: 2,
        grossWt: 6,
        netWt: 6,
        touch: 91.6,
        metalAmount: 600,
        metal: 'G' as const,
        lotNo: 'LOT-77',
        prCode: 'PR',
      },
    ]);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr_no,"LOT_NO","IT_CODE","IT_PCS"::float it_pcs,"IT_GWT"::float it_gwt,
              "IT_NWT"::float it_nwt,"IT_SIGN","ENTRY_TYPE","VCH_TYPE","INOUT_TYPE","BOOK_NAME",
              "AC_CODE","PR_CODE","DATA_TRFR","TAG_NO","VCH_SRNO"::int vch_srno,"HD_VCH_NO"
         FROM "LOT_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(rows).toHaveLength(1);
    const row = rows[0]!;
    expect(row.sr_no).toBe(1);
    expect(String(row.LOT_NO).trim()).toBe('LOT-77');
    expect(String(row.IT_CODE).trim()).toBe('LOOSE');
    expect(row.it_pcs).toBe(2);
    expect(row.it_gwt).toBeCloseTo(6, 2);
    expect(row.it_nwt).toBeCloseTo(6, 2);
    // Literals and book-derived values from the desktop statement.
    expect(String(row.IT_SIGN).trim()).toBe('+');
    expect(String(row.ENTRY_TYPE).trim()).toBe('L');
    expect(String(row.VCH_TYPE).trim()).toBe('CPB'); // BOOK_DATA.BOOK_SNAME
    expect(String(row.INOUT_TYPE).trim()).toBe('I'); // BOOK_DATA.BOOK_INOUT
    expect(String(row.BOOK_NAME).trim()).toBe('PURCHASE'); // BOOK_DATA.MAIN_BOOK
    expect(String(row.AC_CODE).trim()).toBe('SUPP');
    expect(String(row.PR_CODE).trim()).toBe('PR');
    expect(String(row.DATA_TRFR).trim()).toBe('N');
    expect(String(row.TAG_NO ?? '').trim()).toBe('');
    expect(row.vch_srno).toBe(0);
    // Desktop stamps HD_VCH_NO with the voucher number here, not the hidden number.
    expect(String(row.HD_VCH_NO).trim()).toBe(vchNo);

    await deletePurchase(runtime, { scope, vchNo: created.vchNo, deleteUser: 'deleter' });
    const gone = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "LOT_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<{ n: number }>;
    expect(gone[0]!.n).toBe(0);
  }, 30_000);

  // Depth gate (Phase B): USER_DATA is the desktop's per-field edit audit — one row per changed
  // header column on save-over-an-existing-voucher (TR_SALE_RTN.cs:13497-13545, shared by TR_PURC).
  // The web never wrote it, so edits left no record of what changed.
  it('records one USER_DATA row per changed header column on edit', async () => {
    const created = await createPurchase(
      runtime,
      purchaseInput({ mainUser: 'original-user', city: 'Rajkot', creditDays: 21 }),
      firstLines,
    );
    const vchNo = String(created.vchNo).padStart(5, '0');

    await editPurchase(
      runtime,
      purchaseInput({ mainUser: 'editing-user', city: 'Surat', creditDays: 30 }),
      firstLines,
      created.vchNo,
    );

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "COL_TYPE","OLD_VAL","NEW_VAL","USER_NAME","NEW_USER","BOOK_NAME","AC_CODE",
              "ENTRY_CHECK","CO_BOOK","VCH_NO"
         FROM "USER_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "COL_TYPE"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;

    const byColumn = new Map(rows.map((r) => [String(r.COL_TYPE).trim(), r]));
    // Both changed columns are recorded with their before/after values.
    expect(byColumn.has('CITY')).toBe(true);
    expect(byColumn.has('CR_DAYS')).toBe(true);
    expect(String(byColumn.get('CITY')!.OLD_VAL).trim()).toBe('Rajkot');
    expect(String(byColumn.get('CITY')!.NEW_VAL).trim()).toBe('Surat');
    expect(String(byColumn.get('CR_DAYS')!.OLD_VAL).trim()).toBe('21');
    expect(String(byColumn.get('CR_DAYS')!.NEW_VAL).trim()).toBe('30');
    // Unchanged columns must NOT appear: the audit records changes, not the whole header.
    expect(byColumn.has('AC_CODE')).toBe(false);
    expect(byColumn.has('TOT_AMT')).toBe(false);
    // Identity/bookkeeping columns are never reported as changes.
    for (const ignored of ['VCH_TIME', 'HD_VCH_NO', 'MAIN_USER', 'CO_CODE', 'VCH_NO']) {
      expect(byColumn.has(ignored), `${ignored} must not be audited`).toBe(false);
    }
    // Desktop pairs the original entering user with the editing user, and stamps ENTRY_CHECK 'N'.
    const sample = byColumn.get('CITY')!;
    expect(String(sample.USER_NAME).trim()).toBe('original-user');
    expect(String(sample.NEW_USER).trim()).toBe('editing-user');
    expect(String(sample.ENTRY_CHECK).trim()).toBe('N');
    expect(String(sample.AC_CODE).trim()).toBe('SUPP');
    // Desktop stamps the MAIN_BOOK here (FormMainBook), not the book's display name.
    expect(String(sample.BOOK_NAME).trim()).toBe('PURCHASE');

    // The audit survives deletion of the voucher it describes.
    await deletePurchase(runtime, { scope, vchNo: created.vchNo, deleteUser: 'deleter' });
    const after = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n FROM "USER_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
      TENANT,
      vchNo,
    )) as Array<{ n: number }>;
    expect(after[0]!.n).toBe(rows.length);
    expect(after[0]!.n).toBeGreaterThan(0);
  }, 30_000);

  // Depth gate (Phase B): every AC_DATA ledger row carries the desktop's 29-column shape
  // (Ac_Ledr.cs:13). The shared posting layer previously stamped 18 of them.
  it('stamps the full desktop ledger-row shape on AC_DATA', async () => {
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const rows = (await owner.$queryRawUnsafe(
      `SELECT "AC_CODE","LEDR_KEY","IT_TYPE","DATA_TYPE","BILL_NO","CHQ_NO","LDR_NAME","DATA_TRFR",
              "HD_VCH_NO","PARTY_AC_CODE","BOOK_NAME","FINE_RATE"::float fine_rate,
              "BILL_DATE"::text bill_date,"ENTRY_TIME"::text entry_time,"CLR_DATE"::text clr_date
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='PUR' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
      TENANT,
      vchNo,
    )) as Array<Record<string, any>>;
    expect(rows.length).toBeGreaterThan(0);

    for (const row of rows) {
      // Desktop literals on every ledger leg.
      expect(String(row.IT_TYPE).trim()).toBe('A');
      expect(String(row.DATA_TYPE).trim()).toBe('A');
      expect(String(row.DATA_TRFR).trim()).toBe('N');
      expect(String(row.BILL_NO ?? '').trim()).toBe('');
      expect(String(row.CHQ_NO ?? '').trim()).toBe('');
      expect(String(row.LDR_NAME ?? '').trim()).toBe('');
      expect(row.fine_rate).toBe(0);
      expect(String(row.HD_VCH_NO).trim()).toBe('00000');
      expect(row.bill_date).toBeNull();
      // PARTY_AC_CODE defaults to the leg's own account, as the desktop statement does.
      expect(String(row.PARTY_AC_CODE).trim()).toBe(String(row.AC_CODE).trim());
      // ENTRY_TIME / CLR_DATE take the row date.
      expect(String(row.entry_time ?? '')).toContain('2024-04-10');
      expect(String(row.clr_date ?? '')).toContain('2024-04-10');
      // Book name comes from the configured book, and the ledger key is stamped.
      expect(String(row.BOOK_NAME).trim()).toBe('PURCHASE');
      expect(String(row.LEDR_KEY).trim().length).toBeGreaterThan(10);
    }
  }, 30_000);

  it('writes exactly the declared set of tables, so a dropped write cannot pass unnoticed', async () => {
    // Same guard as the sales suite, for the reason established there: dropping every tax row from a voucher
    // passed 26 tests because nothing asserted WHICH tables received rows, only the content of the rows the
    // tests happened to read. The probe is schema-driven so a table nobody listed is still covered.
    const created = await createPurchase(runtime, purchaseInput(), firstLines);
    const vch = String(created.vchNo).padStart(5, '0');

    const tables = await voucherTables(owner);
    expect(tables.length, 'the schema must expose voucher tables to probe').toBeGreaterThan(30);
    const touched = await footprintOf(owner, tables, TENANT, vch);

    // Asserted as an exact SET so both directions fail: a table that stops receiving rows, and one that starts
    // receiving them unexpectedly - which is how a duplicate ledger posting appears.
    expect(touched).toEqual(FOOTPRINT_PURCHASE);

    // A footprint check alone would pass if AC_DATA received rows that did not balance.
    const legs = await ledgerLegs(owner, TENANT, vch);
    expect(legs.dr, 'the ledger must actually be posted').toBeGreaterThan(0);
    expect(legs.dr, 'and it must balance').toBeCloseTo(legs.cr, 2);
  });
});
