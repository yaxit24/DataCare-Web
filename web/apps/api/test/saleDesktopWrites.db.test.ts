import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { createSale, editSale, getSale, type SaleLineInput } from '../src/modules/sales/sales.js';
import { openAdvanceOfOrderTx } from '../src/modules/sales/orderCancel.js';
import { cancelIrnForSale } from '../src/modules/einvoice/einvoice.js';
import { bankReconClear, bankReconList } from '../src/modules/finance/bankRecon.js';
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
      'BANK_RECONCILE',
      'UPI_DATA',
      'USER_DATA',
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
              ($1,$2,'10',2,'CGST','CGST',1.5,'GSTLED'),($1,$2,'10',3,'IGST','IGST',3,'GSTLED'),
              ($1,$2,'T1',0,'TCS','TCS 1%',1,'TCSLED'),($1,$2,'T2',0,'TCS','TCS no ledger',1,NULL),
              ($1,$2,'D1',0,'TDS','TDS 1%',1,'TDSLED')`,
      CO,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC")
       VALUES ($1,$2,'G01','Gold','SALEAC'),($1,$2,'G02','Other','OTHSALE')`,
      CO,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC")
       VALUES ($1,$2,'G03','Old Gold','OGPURC')`,
      CO,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold','G','G01'),($1,$2,'LOOSE','Loose Gold','G','G01'),
              ($1,$2,'OTH','Other Item','O','G02'),($1,$2,'HM','Hallmark','O','G02'),
              ($1,$2,'OG','Old Gold','G','G03')`,
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
                ($1,$2,$3,$4,3,'KASAR','SALES','O'),($1,$2,$3,$4,5,'DISCAC','SALES','O')`,
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
    // Book item leg 08 to the slot-1 account and tax 09: no party, no name (Ac_Ledr.cs:92, :94).
    expect(byLeg.get('08')).toMatchObject({ AC_CODE: 'CTRL', PARTY_AC_CODE: '', LDR_NAME: '' });
    expect(byLeg.get('09')).toMatchObject({ AC_CODE: 'GSTLED', PARTY_AC_CODE: '', LDR_NAME: '' });
    // Cash pair 25/26: the party's credit carries the party; the cash debit carries the name (Ac_Ledr.cs:139-141).
    expect(byLeg.get('25')).toMatchObject({ AC_CODE: 'CUST', PARTY_AC_CODE: 'CUST', LDR_NAME: '' });
    expect(byLeg.get('26')).toMatchObject({
      AC_CODE: 'CASH',
      PARTY_AC_CODE: '',
      LDR_NAME: 'Synthetic Customer',
      dr: 1000,
    });
    // Kasar pair 31 (party credit) / 32 (kasar debit), not the unmapped 5x band (Ac_Ledr.cs:151-153).
    expect(byLeg.get('31')).toMatchObject({ AC_CODE: 'CUST', PARTY_AC_CODE: 'CUST', cr: 5 });
    expect(byLeg.get('32')).toMatchObject({ AC_CODE: 'KASAR', PARTY_AC_CODE: '', dr: 5 });
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
        sr: 3,
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
        sr: 3,
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
    // VCH_NO + STR(SR_NO) + '07' to each line's group account (Ac_Ledr.cs:90).
    expect(items.map((l) => [String(l.k).slice(-12), l.AC_CODE])).toEqual([
      ['         107', 'SALEAC'],
      ['         207', 'OTHSALE'],
    ]);
  }, 30_000);

  /** Item 4: a book whose ITM_TYPE is not 'A' posts ONE item leg, the bill net to its slot-1 account (Ac_Ledr.cs:92). */
  it("posts one '08' item leg to the book account on a non-'A' book, whatever the item groups", async () => {
    const sale = await createSale(runtime, saleInput('TX'), [
      looseLine(),
      looseLine({ itCode: 'OTH', ghtWt: 0 }),
    ]);
    const [header] = await rows(
      `SELECT "NET_AMT"::float net FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0')`,
      sale.vchNo,
    );
    const items = (await ledger('TX', sale.vchNo)).filter(
      (l) => l.cr > 0 && l.AC_CODE !== 'GSTLED',
    );
    expect(items.map((l) => [String(l.k).slice(-2), l.AC_CODE, l.cr])).toEqual([
      ['08', 'CTRL', header?.net],
    ]);
  }, 30_000);

  /** Every settlement pair on Sales_Ledr's code, the party first (Ac_Ledr.cs:116-163). */
  it('keys cheque, card, UPI, old metal, cash paid and discount as Sales_Ledr does', async () => {
    const sale = await createSale(
      runtime,
      saleInput('TX', {
        discountAmount: 100,
        chequeAmt: 1000,
        bankAc: 'BANKAC',
        cardAmt: 500,
        cardAc: 'CARDAC',
        upiAmt: 300,
        upiRows: [{ acCode: 'UPIAC', amount: 300 }],
        cashAmt: 200,
        cashPaid: 40,
        oldGold: [{ metal: 'G', itCode: 'OG', netWt: 1, touch: 100, rate: 6000, amount: 6000 }],
      }),
      [looseLine()],
    );
    const legs = await ledger('TX', sale.vchNo);
    const vch = String(sale.vchNo).padStart(5, '0');
    const tail = (k: unknown) =>
      String(k)
        .slice(String(k).indexOf(`TX${vch}`) + 7)
        .trim();
    const shape = legs.map((l) => [tail(l.k), l.AC_CODE, l.dr, l.cr]);
    expect(shape).toEqual(
      expect.arrayContaining([
        ['15', 'CUST', 0, 1000],
        ['16', 'BANKAC', 1000, 0],
        ['17', 'CUST', 0, 500],
        ['18', 'CARDAC', 500, 0],
        ['123', 'CUST', 0, 6000],
        ['124', 'OGPURC', 6000, 0],
        ['25', 'CUST', 0, 200],
        ['26', 'CASH', 200, 0],
        ['29', 'CUST', 40, 0],
        ['30', 'CASH', 0, 40],
        ['33', 'CUST', 0, 100],
        ['34', 'DISCAC', 100, 0],
        ['36         1', 'CUST', 0, 300],
        ['37         1', 'UPIAC', 300, 0],
      ]),
    );
    // The party's bill debit is TOT_AMT + DISC_AMT (Ac_Ledr.cs:64); the old-metal pair writes BILL_NO '' (:135-137).
    const [header] = await rows(
      `SELECT "TOT_AMT"::float tot, "DISC_AMT"::float disc, "BILL_OS"::float os, "CASH_PAID"::float paid
         FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0')`,
      sale.vchNo,
    );
    expect(legs.find((l) => String(l.k).endsWith('01'))?.dr).toBe(header!.tot + header!.disc);
    const sum = (side: 'dr' | 'cr') =>
      Math.round(legs.reduce((t, l) => t + Number(l[side]), 0) * 100) / 100;
    expect(sum('dr')).toBe(sum('cr'));
    // BILL_OS adds the cash paid back (TR_SALE.cs:19386).
    expect(header!.os).toBe(
      Math.round((header!.tot - 1000 - 500 - 300 - 200 - 6000 + 40) * 100) / 100,
    );
    // Old metal comes into stock as section 4 (Ac_Stock.cs:116).
    const [stock] = await rows(
      `SELECT "SR_NO"::int sr FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TX'
          AND "VCH_NO"=lpad($2::text,5,'0') AND "ITM_SIGN"='+'`,
      sale.vchNo,
    );
    expect(stock?.sr).toBe(4);
  }, 30_000);

  /** Bank reconciliation lists and clears a sale's cheque by its bank account's own leg, now keyed 16. */
  it("lists and clears the sale's cheque leg in bank reconciliation", async () => {
    const sale = await createSale(
      runtime,
      saleInput('TX', { chequeAmt: 700, bankAc: 'BANKAC', chequeNo: '123456' }),
      [looseLine()],
    );
    const scope = { tenantId: TENANT, coCode: CO };
    const listed = await bankReconList(runtime, scope, 'BANKAC');
    const vch = String(sale.vchNo).padStart(5, '0');
    expect(listed.rows.filter((r) => r.coBook === 'TX' && r.vchNo === vch)).toEqual([
      expect.objectContaining({ dr: 700, cr: 0, clrDate: null }),
    ]);
    expect(
      await bankReconClear(runtime, scope, 'BANKAC', [
        { coBook: 'TX', vchNo: vch, clrDate: '2024-05-10' },
      ]),
    ).toEqual({ updated: 1 });
    const [cleared] = await rows(
      `SELECT trim("LEDR_KEY") k, "CLR_DATE"::text clr FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=$2 AND "AC_CODE"='BANKAC'`,
      vch,
    );
    expect(String(cleared?.k).slice(-2)).toBe('16');
    expect(cleared?.clr).toBe('2024-05-10');
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

  /** A line-path book with paise on a line and the bill total rounded to rupees still saves, balanced. */
  it('balances a line-path bill whose line nets carry paise under a rupee-rounded bill total', async () => {
    await exec(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF") VALUES ($1,$2,'0')`,
      CO,
    );
    const sale = await createSale(runtime, saleInput('ES'), [
      looseLine({ otherAmount: 50.37 }),
      looseLine({ itCode: 'OTH', ghtWt: 0, otherAmount: 10.41 }),
    ]);
    const legs = await ledger('ES', sale.vchNo);
    const sum = (side: 'dr' | 'cr') =>
      Math.round(legs.reduce((s, l) => s + Number(l[side]), 0) * 100) / 100;
    expect(sum('dr')).toBe(sum('cr'));
    const [detl] = await rows(
      `SELECT array_agg("NET_AMT"::float ORDER BY "SR_NO") nets FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK"='ES' AND "VCH_NO"=lpad($2::text,5,'0')`,
      sale.vchNo,
    );
    // Each line leg is its own line's NET_AMT (Ac_Ledr.cs:90), paise and all.
    const lineLegs = legs.filter((l) => /^\s+\d+0[27]$/.test(String(l.k).slice(-12)));
    expect(lineLegs.map((l) => l.cr)).toEqual(detl?.nets);
    expect(detl?.nets.some((n: number) => !Number.isInteger(n))).toBe(true);
  }, 30_000);

  /** Review fixes: UPI by its own rows, KASAR_AMT + POINT_VAL, TCS to its code's TAX_AC, discount on an unfixed sale. */
  it('posts UPI per UPI_DATA row SR_NO, kasar with points, TCS to its tax account', async () => {
    const sale = await createSale(
      runtime,
      saleInput('TX', {
        upiRows: [
          { acCode: 'UPIA', amount: 100 },
          { acCode: '', amount: 50 },
          { acCode: 'UPIB', amount: 200 },
        ],
        kasarAmount: 5,
        pointValue: 7,
        tcsCode: 'T1',
        tcsAmount: 12,
      }),
      [looseLine()],
    );
    const vch = String(sale.vchNo).padStart(5, '0');
    const legs = await ledger('TX', sale.vchNo);
    const tail = (k: unknown) =>
      String(k)
        .slice(String(k).indexOf(`TX${vch}`) + 7)
        .trim();
    const shape = legs.map((l) => [tail(l.k), l.AC_CODE, l.dr, l.cr]);
    const upi = await rows(
      `SELECT "SR_NO"::int sr, "UPI_AC_CODE" ac FROM "UPI_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX'
          AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      vch,
    );
    // The blank-account row is not a UPI row (TR_SALE.cs:6862); the legs carry UPI_DATA's own SR_NO (:161-163).
    expect(upi).toEqual([
      { sr: 1, ac: 'UPIA' },
      { sr: 2, ac: 'UPIB' },
    ]);
    expect(shape).toEqual(
      expect.arrayContaining([
        ['36         1', 'CUST', 0, 100],
        ['37         1', 'UPIA', 100, 0],
        ['36         2', 'CUST', 0, 200],
        ['37         2', 'UPIB', 200, 0],
        ['31', 'CUST', 0, 12],
        ['32', 'KASAR', 12, 0],
        ['10', 'TCSLED', 0, 12],
      ]),
    );
  }, 30_000);

  it('refuses a UPI amount without UPI rows and a zero bill with priced items; TCS falls back to its ledger', async () => {
    await expect(
      createSale(runtime, saleInput('TX', { upiAmt: 300 }), [looseLine()]),
    ).rejects.toThrow(/UPI amount needs its UPI rows/);
    // A TCS code without TAX_AC posts to the provisioned TCS ledger, as the tax leg falls back to GST.
    const unset = await createSale(runtime, saleInput('TX', { tcsCode: 'T2', tcsAmount: 5 }), [
      looseLine(),
    ]);
    expect(
      (await ledger('TX', unset.vchNo)).filter((l) => String(l.k).trim().endsWith('10')),
    ).toEqual([expect.objectContaining({ AC_CODE: 'TCS', cr: 5 })]);
    const priced = await createSale(runtime, saleInput('TX'), [looseLine()]);
    const [h] = await rows(
      `SELECT "NET_AMT"::float net FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0')`,
      priced.vchNo,
    );
    await expect(
      createSale(runtime, saleInput('TX', { discountAmount: h!.net, taxRatePct: 0 }), [
        looseLine(),
      ]),
    ).rejects.toThrow(/bill total is zero but its items are priced/);
  }, 30_000);

  it('posts the discount pair on an unfixed sale too (Ac_Ledr.cs:155-157 has no RATE_UNFIX filter)', async () => {
    const sale = await createSale(
      runtime,
      saleInput('TX', { rateUnfix: true, discountAmount: 25 }),
      [looseLine()],
    );
    const legs = await ledger('TX', sale.vchNo);
    expect(
      legs.filter((l) => /3[34]$/.test(String(l.k).trim())).map((l) => [l.AC_CODE, l.dr, l.cr]),
    ).toEqual([
      ['CUST', 0, 25],
      ['DISCAC', 25, 0],
    ]);
  }, 30_000);

  /** An edit keeps the bank clearing, and moves an older build's BANK_RECONCILE key (…10) to the new leg (…16). */
  it('carries a cleared cheque leg across an edit, re-keying its BANK_RECONCILE row', async () => {
    const sale = await createSale(
      runtime,
      saleInput('TX', { chequeAmt: 700, bankAc: 'BANKAC', chequeNo: '111' }),
      [looseLine()],
    );
    const vch = String(sale.vchNo).padStart(5, '0');
    const [bank] = await rows(
      `SELECT "LEDR_KEY" k FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=$2 AND "AC_CODE"='BANKAC'`,
      vch,
    );
    const newKey = String(bank!.k);
    const oldKey = `${newKey.slice(0, -2)}10`;
    // The older build's key and a cleared reconciliation row, as an imported voucher carries them.
    await exec(
      `UPDATE "AC_DATA" SET "LEDR_KEY"=$2,"CLR_DATE"='2024-05-20' WHERE tenant_id=$1 AND "LEDR_KEY"=$3`,
      oldKey,
      newKey,
    );
    await exec(
      `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE") VALUES ($1,$2,$3,$4,'2024-05-20')`,
      CO,
      LC,
      oldKey,
    );
    const view: any = await getSale(runtime, scopeOf('TX'), sale.vchNo);
    await editSale(
      runtime,
      saleInput('TX', { chequeAmt: 700, bankAc: 'BANKAC', chequeNo: '111', description: 'edited' }),
      [looseLine()],
      sale.vchNo,
      view.version,
    );
    const [after] = await rows(
      `SELECT "LEDR_KEY" k, "CLR_DATE"::text clr FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=$2 AND "AC_CODE"='BANKAC'`,
      vch,
    );
    expect(after).toEqual({ k: newKey, clr: '2024-05-20' });
    expect(
      await rows(
        `SELECT "LEDR_KEY" k, "CLR_DATE"::text clr FROM "BANK_RECONCILE" WHERE tenant_id=$1`,
      ),
    ).toEqual([{ k: newKey, clr: '2024-05-20' }]);
  }, 30_000);

  /**
   * SL_TDS_TAX 'Y' (TR_SALE.cs:19261-19275): TDS = Math.Round((net - discount) x 1% , 0) and TOT_AMT takes it off before
   * the bill rounding; ROF_AMT 0. Leg 01 = TOT + DISC + TDS (Ac_Ledr.cs:64), 13 party Cr / 14 TDS account Dr (:112-114).
   */
  it('posts a TDS sale as Sales_Ledr does and balances', async () => {
    await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","SL_TDS_TAX") VALUES ($1,$2,'Y')`, CO);
    const sale = await createSale(
      runtime,
      saleInput('TX', { tdsCode: 'D1', tdsPct: 1, discountAmount: 37.5 }),
      [looseLine()],
    );
    const [h] = await rows(
      `SELECT "NET_AMT"::float net,"DISC_AMT"::float disc,"TAX_AMT"::float tax,"TDS_AMT"::float tds,
              "TOT_AMT"::float tot,"ROF_AMT"::float rof
         FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=lpad($2::text,5,'0')`,
      sale.vchNo,
    );
    // Independently: net 10,760; TDS = Round((10,760 - 37.50) x 1 / 100, 0) = Round(107.225) = 107.
    expect(h!.net).toBe(10760);
    expect(h!.tds).toBe(107);
    expect(h!.rof).toBe(0);
    expect(h!.tot).toBe(Math.round((h!.net + h!.tax - h!.tds - h!.disc) * 100) / 100);
    const vch = String(sale.vchNo).padStart(5, '0');
    const legs = await ledger('TX', sale.vchNo);
    const tail = (k: unknown) =>
      String(k)
        .slice(String(k).indexOf(`TX${vch}`) + 7)
        .trim();
    const byTail = new Map(legs.map((l) => [tail(l.k), l]));
    expect(byTail.get('01')).toMatchObject({ AC_CODE: 'CUST', dr: h!.tot + h!.disc + h!.tds });
    expect(byTail.get('13')).toMatchObject({ AC_CODE: 'CUST', PARTY_AC_CODE: '', cr: 107, dr: 0 });
    expect(byTail.get('14')).toMatchObject({ AC_CODE: 'TDSLED', dr: 107, cr: 0 });
    expect(byTail.has('99')).toBe(false);
    const sum = (side: 'dr' | 'cr') =>
      Math.round(legs.reduce((t, l) => t + Number(l[side]), 0) * 100) / 100;
    expect(sum('dr')).toBe(sum('cr'));
  }, 30_000);

  /**
   * An old web TDS sale kept the typed TDS inside TOT_AMT. Re-saving it totals it as the desktop does, and BILL_OS_DATA is
   * rewritten from the new total, as TR_SALE's save rewrites it on every edit (TR_SALE.cs:15760).
   */
  it('re-totals an old web TDS sale on edit and rewrites its receivable', async () => {
    await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","SL_TDS_TAX") VALUES ($1,$2,'Y')`, CO);
    const input = saleInput('TX', { tdsCode: 'D1', tdsPct: 1 });
    const sale = await createSale(runtime, input, [looseLine()]);
    const vch = String(sale.vchNo).padStart(5, '0');
    const header = async () =>
      (
        await rows(
          `SELECT "TOT_AMT"::float tot,"BILL_OS"::float os,"TDS_AMT"::float tds FROM "SL_DATA"
            WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=$2`,
          vch,
        )
      )[0]!;
    const fresh = await header();
    // The old web wrote the typed TDS and left it in the total.
    await exec(
      `UPDATE "SL_DATA" SET "TOT_AMT"="TOT_AMT"+$3,"BILL_OS"="BILL_OS"+$3,"TDS_AMT"=50
        WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=$2`,
      vch,
      fresh.tds,
    );
    const view: any = await getSale(runtime, scopeOf('TX'), sale.vchNo);
    await editSale(runtime, input, [looseLine()], sale.vchNo, view.version);
    expect(await header()).toEqual(fresh);
    const [os] = await rows(
      `SELECT "BILL_AMT"::float amt FROM "BILL_OS_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TX' AND "VCH_NO"=$2`,
      vch,
    );
    expect(os?.amt).toBe(fresh.tot);
  }, 30_000);
});
