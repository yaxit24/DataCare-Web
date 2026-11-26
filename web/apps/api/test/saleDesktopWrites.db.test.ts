import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { createSale, type SaleLineInput } from '../src/modules/sales/sales.js';
import { openAdvanceOfOrderTx } from '../src/modules/sales/orderCancel.js';
import { cancelIrnForSale } from '../src/modules/einvoice/einvoice.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * What the sale save writes, column by column, against the desktop (found by the desktop replay oracle on the
 * 2024-25 year; every value here is synthetic). Authorities: Sales_Ledr (Ac_Ledr.cs:61-172), Sales_GST
 * (Ac_Tax.cs:77-99), Sale_Stk (Ac_Stock.cs:98-132) and the TR_SALE save (TR_SALE.cs:15180-15800).
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'sale-desktop-writes-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-05-02';
const scopeOf = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

const saleInput = (coBook: string, overrides: Record<string, unknown> = {}) => ({
  scope: scopeOf(coBook),
  mainUser: 'tester',
  acCode: 'CUST',
  acName: 'Synthetic Customer',
  vchDate: DAY,
  taxRatePct: 3,
  taxCode: '10',
  interState: false,
  ...overrides,
});

const looseLine = (overrides: Partial<SaleLineInput> = {}): SaleLineInput => ({
  itCode: 'LOOSE',
  pcs: 0,
  grossWt: 2,
  netWt: 2,
  touch: 90,
  ghtWt: 0.1,
  rate: 5000,
  labourType: 'per_gram',
  labourRate: 100,
  otherAmount: 50,
  designNo: 'D-7',
  itmSize: '12',
  employeeCode: 'E01',
  tblCode: '002',
  ...overrides,
});

databaseDescribe('sale writes what the desktop writes', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const rows = (sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, TENANT, ...params) as Promise<Array<Record<string, any>>>;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DELETE_DATA',
      'SL_ORD_ADJ',
      'SL_ORD_DATA',
      'ROJ_MEL_DATA',
      'BILL_OS_DATA',
      'TAX_DATA',
      'AC_DATA',
      'SL_IDTL',
      'SL_PR_DETL',
      'SL_DETL',
      'SL_DATA',
      'TEMP_BOOK_DATA',
      'MAIN_STOCK',
      'TAG_STOCK',
      'BAR_IDTL',
      'BAR_DETL',
      'BOOK_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'GROUP_MAST',
      'TAX_MAST',
      'AC_MAST',
      'CO_SET_NEW',
      'CO_SET',
    ]) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
    }
  };

  const exec = (sql: string, ...params: unknown[]) =>
    owner.$executeRawUnsafe(sql, TENANT, ...params);

  const seed = async (): Promise<void> => {
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`, CO);
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,'CUST','Synthetic Customer','L'),($1,$2,$3,'00045','Counter Cash','L')`,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC")
       VALUES ($1,$2,'10',0,'GST','GST 3%',3,'GSTLED'),($1,$2,'10',1,'SGST','SGST',1.5,'GSTLED'),
              ($1,$2,'10',2,'CGST','CGST',1.5,'GSTLED'),($1,$2,'10',3,'IGST','IGST',3,'GSTLED')`,
      CO,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC")
       VALUES ($1,$2,'G01','Gold','SALEAC'),($1,$2,'G02','Other','OTHSALE')`,
      CO,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold','G','G01'),($1,$2,'LOOSE','Loose Gold','G','G01'),
              ($1,$2,'OTH','Other Item','O','G02'),($1,$2,'HM','Hallmark','O','G02')`,
      CO,
    );
    // TX: a tax-invoice book; ES: an estimate book that posts the item side per line (ITM_TYPE 'A').
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TYPE","ITM_TYPE")
       VALUES ($1,$2,$3,'TX','Tax Invoice','TXI','SALES','O','Y','SL_DATA','T','G'),
              ($1,$2,$3,'ES','Estimate','EST','SALES','O','Y','SL_DATA','M','A')`,
      CO,
      LC,
    );
    for (const book of ['TX', 'ES'])
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
         VALUES ($1,$2,$3,$4,1,'CTRL','SALES','O'),($1,$2,$3,$4,2,'CASH','SALES','O'),
                ($1,$2,$3,$4,3,'KASAR','SALES','O')`,
        CO,
        LC,
        book,
      );
    // A tag with two BAR_IDTL rows (a hallmark charge and a zero placeholder the save skips), and one without.
    for (const [tag, srno] of [
      ['TAGS', 11],
      ['TAGN', 12],
    ] as const) {
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
           "IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","KR_TOUCH","KR_FINE","EMP_ISU")
         VALUES ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD',$6,$7,1,10,10,9.16,92,9.2,'N')`,
        CO,
        LC,
        YEAR,
        DAY,
        tag,
        srno,
      );
      await exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
           "IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
         VALUES ($1,$2,$3,$4,'TOP','00001',1,$5::date,'GOLD',$6,$7,'+',1,10,10)`,
        CO,
        LC,
        YEAR,
        DAY,
        tag,
        srno,
      );
    }
    await exec(
      `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "TAG_NO","VCH_SRNO","IT_CODE","IT_TYPE","DM_CODE","IT_PCS","IT_GWT","KR_WT","IT_CON_PRC","IT_RATE_TYPE",
         "IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT","IT_CON_WT")
       VALUES ($1,$2,$3,$4,'TOP','00001',1,1,'TAGS',11,'HM','O','',4,0,0,0,'P',100,400,0,0,400,0),
              ($1,$2,$3,$4,'TOP','00001',1,2,'TAGS',11,'HM','O','',0,0,0,0,'',0,0,0,0,0,0)`,
      CO,
      LC,
      YEAR,
    );
    // Order 00009 exists in two years; the sale names the 2024-25 one.
    await exec(
      `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","ADV_AMT")
       VALUES ($1,$2,$3,'2023-2024','SOR','00009','2023-06-01'::date,'CUST',1000),
              ($1,$2,$3,'2024-2025','SOR','00009','2024-04-01'::date,'CUST',5000)`,
      CO,
      LC,
    );
  };

  beforeAll(async () => {
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL } } });
  });
  beforeEach(async () => {
    await cleanup();
    await seed();
  });
  afterAll(async () => {
    if (owner) await cleanup();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  const ledger = (book: string, vchNo: number) =>
    rows(
      `SELECT trim("LEDR_KEY") k, "AC_CODE", "PARTY_AC_CODE", "LDR_NAME", "BILL_NO",
              "DR_AMT"::float dr, "CR_AMT"::float cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=lpad($3::text,5,'0') ORDER BY "LEDR_KEY"`,
      book,
      vchNo,
    );

  /** Oracle A2, A8, A10, A14: PARTY_AC_CODE, LDR_NAME, kasar keys and the header's typed/default columns. */
  it('keys and names the ledger legs as Sales_Ledr does', async () => {
    const sale = await createSale(runtime, saleInput('TX', { cashAmt: 1000, kasarAmount: 5 }), [
      looseLine(),
    ]);
    const legs = await ledger('TX', sale.vchNo);
    const byLeg = new Map(legs.map((l) => [String(l.k).slice(-2), l]));
    // Party bill 01: the party on both PARTY_AC_CODE and AC_CODE, its name in LDR_NAME (Ac_Ledr.cs:64).
    expect(byLeg.get('01')).toMatchObject({
      AC_CODE: 'CUST',
      PARTY_AC_CODE: 'CUST',
      LDR_NAME: 'Synthetic Customer',
    });
    // Revenue 03 and tax 04: no party, no name (Ac_Ledr.cs:92, :94).
    expect(byLeg.get('03')).toMatchObject({ AC_CODE: 'SALEAC', PARTY_AC_CODE: '', LDR_NAME: '' });
    expect(byLeg.get('04')).toMatchObject({ AC_CODE: 'GSTLED', PARTY_AC_CODE: '', LDR_NAME: '' });
    // Cash pair: the party's credit carries the party; the cash debit carries the name (Ac_Ledr.cs:139-141).
    expect(byLeg.get('19')).toMatchObject({ AC_CODE: 'CUST', PARTY_AC_CODE: 'CUST', LDR_NAME: '' });
    expect(byLeg.get('20')).toMatchObject({
      AC_CODE: 'CASH',
      PARTY_AC_CODE: '',
      LDR_NAME: 'Synthetic Customer',
      dr: 1000,
    });
    // Kasar pair 25 (party credit) / 26 (kasar debit), not the unmapped 5x band.
    expect(byLeg.get('25')).toMatchObject({ AC_CODE: 'CUST', PARTY_AC_CODE: 'CUST', cr: 5 });
    expect(byLeg.get('26')).toMatchObject({ AC_CODE: 'KASAR', PARTY_AC_CODE: '', dr: 5 });
    expect(
      legs.filter((l) => Number(String(l.k).slice(-2)) >= 50 && String(l.k).slice(-2) !== '99'),
    ).toEqual([]);
    // BILL_NO is the typed Bill No box, blank by default, on the header and the legs (TR_SALE.cs:15196).
    expect(legs.every((l) => String(l.BILL_NO ?? '') === '')).toBe(true);
    const [header] = await rows(
      `SELECT "BILL_NO","IRN_NO","ACK_NO" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX'`,
    );
    expect(header).toEqual({ BILL_NO: '', IRN_NO: 'N', ACK_NO: 'N' });
  }, 30_000);

  /** Oracle B4: Sales_GST writes TAX_DATA for tax books only (Ac_Tax.cs:92-98); the tax leg still posts. */
  it('writes the GST register for a tax book and none for an estimate book', async () => {
    const taxBook = await createSale(runtime, saleInput('TX'), [looseLine()]);
    const estimate = await createSale(runtime, saleInput('ES'), [looseLine()]);
    const taxRows = (book: string, vchNo: number) =>
      rows(
        `SELECT "SR_NO" FROM "TAX_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=lpad($3::text,5,'0')`,
        book,
        vchNo,
      );
    expect(await taxRows('TX', taxBook.vchNo)).toHaveLength(2);
    expect(await taxRows('ES', estimate.vchNo)).toHaveLength(0);
    expect((await ledger('ES', estimate.vchNo)).some((l) => l.AC_CODE === 'GSTLED')).toBe(true);
  }, 30_000);

  /** Oracle A11: the sale's MAIN_STOCK row copies its SL_DETL line (Ac_Stock.cs:114). */
  it('copies the stock row from the sale line', async () => {
    const sale = await createSale(runtime, saleInput('TX'), [
      looseLine(),
      { ...looseLine({ tblCode: undefined }), itCode: 'GOLD', tagNo: 'TAGN', vchSrno: 12 },
    ]);
    const stock = await rows(
      `SELECT "SR_NO"::int sr, "ISR_NO"::int isr, "STK_DATE", "TBL_CODE", "TAG_NO", "VCH_SRNO"::int vs,
              "ITM_PCS"::float pcs, "LBR_RATE"::float lbr_rate, "OTH_AMT"::float oth, "EMP_CODE", "DESIGN_NO",
              "ITM_SIZE", "KR_NWT"::float kr_nwt, "KR_TOUCH"::float kr_touch, "KR_FINE"::float kr_fine,
              "ITM_WEST"::float west, "TR_TYPE", "ITM_SIGN"
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0')
        ORDER BY "ISR_NO"`,
      sale.vchNo,
    );
    expect(stock).toEqual([
      {
        sr: 1,
        isr: 1,
        STK_DATE: DAY,
        TBL_CODE: '002',
        TAG_NO: 'N',
        vs: 0,
        pcs: 0,
        lbr_rate: 100,
        oth: 50,
        EMP_CODE: 'E01',
        DESIGN_NO: 'D-7',
        ITM_SIZE: '12',
        kr_nwt: 2,
        kr_touch: 0,
        kr_fine: 0,
        west: 0,
        TR_TYPE: 'S',
        ITM_SIGN: '-',
      },
      expect.objectContaining({
        sr: 1,
        isr: 2,
        TAG_NO: 'TAGN',
        vs: 12,
        kr_touch: 92,
        kr_fine: 9.2,
      }),
    ]);
  }, 30_000);

  /** Oracle A12: a tagged line's SL_IDTL rows are the tag's BAR_IDTL rows (TR_SALE.cs:12683-12715, :15546-15620). */
  it("writes the tag's own stone rows to SL_IDTL, and none for a tag without them", async () => {
    const sale = await createSale(runtime, saleInput('TX'), [
      { ...looseLine({ tblCode: undefined }), itCode: 'GOLD', tagNo: 'TAGS', vchSrno: 11 },
      { ...looseLine({ tblCode: undefined }), itCode: 'GOLD', tagNo: 'TAGN', vchSrno: 12 },
    ]);
    const idtl = await rows(
      `SELECT "SR_NO"::int sr, "ISR_NO"::int isr, "TAG_NO", "VCH_SRNO"::int vs, "IT_CODE", "IT_TYPE",
              "IT_PCS"::float pcs, "IT_RATE_TYPE", "IT_RATE"::float rate, "IT_AMT"::float amt,
              "IT_NET_AMT"::float net, "VCH_DATE"::text vd
         FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0')`,
      sale.vchNo,
    );
    expect(idtl).toEqual([
      {
        sr: 1,
        isr: 1,
        TAG_NO: 'TAGS',
        vs: 11,
        IT_CODE: 'HM',
        IT_TYPE: 'O',
        pcs: 4,
        IT_RATE_TYPE: 'P',
        rate: 100,
        amt: 400,
        net: 400,
        vd: DAY,
      },
    ]);
  }, 30_000);

  /** Oracle A13: GHT_AMT, TAX_PRC, ORD_TAG_STK_ADD and DESIGN_IMG_ID of a new line. */
  it('fills the line columns the grid fills on a new row', async () => {
    const sale = await createSale(runtime, saleInput('TX'), [
      looseLine(),
      looseLine({ ghtWt: 0, taxPct: 5 }),
    ]);
    const detl = await rows(
      `SELECT "GHT_AMT"::float ght, "TAX_PRC"::float tax, "ORD_TAG_STK_ADD", "DESIGN_IMG_ID"
         FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0') ORDER BY "SR_NO"`,
      sale.vchNo,
    );
    expect(detl).toEqual([
      // Math.Round(0.1 x 5000, 0) (TR_SALE.cs:10647); a typed Tax% is kept (:15437); 'N' cells (:9146, :9160).
      { ght: 500, tax: 3, ORD_TAG_STK_ADD: 'N', DESIGN_IMG_ID: 'N' },
      { ght: 0, tax: 5, ORD_TAG_STK_ADD: 'N', DESIGN_IMG_ID: 'N' },
    ]);
  }, 30_000);

  /** Oracle C2 and the line path: an 'O' item sells; an ITM_TYPE 'A' book posts one keyed leg per line. */
  it("sells an item of type 'O' and posts the line path per line", async () => {
    const sale = await createSale(runtime, saleInput('ES'), [
      looseLine(),
      looseLine({ itCode: 'OTH', ghtWt: 0, labourType: undefined, labourRate: undefined }),
    ]);
    const [types] = await rows(
      `SELECT string_agg("IT_TYPE", ',' ORDER BY "SR_NO") t FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK"='ES' AND "VCH_NO"=lpad($2::text,5,'0')`,
      sale.vchNo,
    );
    expect(types?.t).toBe('G,O');
    const items = (await ledger('ES', sale.vchNo)).filter(
      (l) => l.cr > 0 && l.AC_CODE !== 'GSTLED',
    );
    // VCH_NO + STR(SR_NO) + '02' to each line's group account (Ac_Ledr.cs:90).
    expect(items.map((l) => [String(l.k).slice(-12), l.AC_CODE])).toEqual([
      ['         102', 'SALEAC'],
      ['         202', 'OTHSALE'],
    ]);
  }, 30_000);

  /** BILL_OS_DATA: none for the counter-cash party (TR_SALE.cs:15736); the USER_* column defaults 'N'. */
  it('writes the receivable row for a named customer only', async () => {
    const named = await createSale(runtime, saleInput('TX'), [looseLine()]);
    await createSale(runtime, saleInput('TX', { acCode: '00045', acName: 'Counter Cash' }), [
      looseLine(),
    ]);
    const os = await rows(
      `SELECT "VCH_NO","AC_CODE","USER_UPDATE","USER_DELETE" FROM "BILL_OS_DATA" WHERE tenant_id=$1`,
    );
    expect(os).toEqual([
      {
        VCH_NO: String(named.vchNo).padStart(5, '0'),
        AC_CODE: 'CUST',
        USER_UPDATE: 'N',
        USER_DELETE: 'N',
      },
    ]);
  }, 30_000);

  /** Oracle C3: an order number recurs each year; the sale's row names the year (TR_SALE.cs:7295). */
  it("reads the named year's order advance", async () => {
    const open = (year: string) =>
      runtime.$transaction(async (tx: any) => {
        await tx.$executeRawUnsafe(`SELECT set_config('app.tenant_id',$1,true)`, TENANT);
        return openAdvanceOfOrderTx(tx, scopeOf('TX'), '9', 'SOR', year);
      });
    expect((await open('2024-2025'))?.openAmt).toBe(5000);
    expect((await open('2023-2024'))?.openAmt).toBe(1000);
  }, 30_000);

  /** A sale stores IRN_NO 'N' (MS_UPDATE.cs:18686): cancelling it is refused, as the e-bill writer's IRN > 10 rule. */
  it("refuses to cancel the IRN of a bill that stores the default 'N'", async () => {
    const sale = await createSale(runtime, saleInput('TX'), [looseLine()]);
    const irnOf = async () =>
      (
        await rows(
          `SELECT "IRN_NO" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0')`,
          sale.vchNo,
        )
      )[0]?.IRN_NO;
    await expect(
      cancelIrnForSale(runtime, scopeOf('TX'), { coBook: 'TX', vchNo: sale.vchNo }),
    ).rejects.toThrow(/no IRN/);
    expect(await irnOf()).toBe('N');
    const irn = 'a'.repeat(64);
    await exec(
      `UPDATE "SL_DATA" SET "IRN_NO"=$2 WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($3::text,5,'0')`,
      irn,
      sale.vchNo,
    );
    const cancelled = await cancelIrnForSale(runtime, scopeOf('TX'), {
      coBook: 'TX',
      vchNo: sale.vchNo,
    });
    expect(cancelled.irn).toBe(irn);
    expect(await irnOf()).toBeNull();
  }, 30_000);
});
