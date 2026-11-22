import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { createSale, deleteSale, editSale, getSale } from '../src/modules/sales/sales.js';
import {
  salePartyBalancesTx,
  salePrintFiles,
  setSalePrintDefault,
} from '../src/modules/sales/salePrintChoice.js';
import { salesBillData } from '../src/modules/sales/salesBill.js';
import { formatVoucherNo as fmt } from '../src/modules/vouchers/numbering.js';
import { insertRowTx } from '../src/modules/posting/posting.js';
import { tenantTables } from './support/tenantSnapshot.js';

/**
 * WP-26 (N243, G255): Sales Invoice residuals, database layer. Cases are named by their id in
 * `orchestration/work/WP-26/cases.md`; every expected figure is worked by hand from TR_SALE.cs (comment beside it).
 *
 * Company: web-provisioned (`seedCompany`), so the G82 tax shape applies. Line A: 10.000 g x 6,123.45 = 61,234.50
 * metal + 10.000 x 237.5 = 2,375.00 labour = 63,609.50 net; GST 3% = 1,908.285 -> 1,908.29; total 65,517.79.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const TENANT = 'wp26-sales-resid';
const OTHER = 'wp26-sales-other';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const TOTAL = 65517.79;
const scopeOf = (tenantId = TENANT) => ({
  tenantId,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: 'SL',
});

const LINE_A = {
  itCode: 'WGLD',
  pcs: 1,
  grossWt: 10,
  netWt: 10,
  touch: 91.6,
  rate: 6123.45,
  labourType: 'per_gram' as const,
  labourRate: 237.5,
};
const sale = (over: Record<string, unknown> = {}, tenantId = TENANT) =>
  ({
    scope: scopeOf(tenantId),
    mainUser: 'wp26',
    acCode: 'WCUST',
    acName: 'WP26 Customer',
    vchDate: DAY,
    taxRatePct: 3,
    taxCode: '10',
    interState: false,
    bankAc: 'BANK',
    ...over,
  }) as any;
const UPI = [
  { acCode: 'WU1', acName: 'PhonePe', type: 'PHONEPE', upiId: 'a@b', amount: 1000 },
  { acCode: 'WU2', acName: 'Gpay', type: 'GPAY', upiId: 'c@d', amount: 2500.5 },
];

/** What the screen sends back on an unchanged save: every field the reopened view carries. */
function inputFromView(view: any, over: Record<string, unknown> = {}) {
  const input = sale({
    acCode: view.acCode,
    acName: view.acName,
    vchDate: view.vchDate,
    billNo: view.billNo,
    taxRatePct: view.taxRatePct,
    taxCode: view.taxCode || undefined,
    interState: view.interState,
    rateUnfix: view.rateUnfix,
    cashAmt: view.cashAmt,
    cardAmt: view.cardAmt,
    chequeAmt: view.chequeAmt,
    bankAc: view.bankAc,
    kasarAmount: view.kasarAmount,
    empCode: view.empCode,
    memberCommissionAc: view.memberCommissionAc,
    withoutCommissionBill: view.withoutCommissionBill,
    upiRows: view.upiRows,
    creditNotes: view.creditNotes,
    orders: view.orders,
    oldGold: view.oldGold,
    ...over,
  });
  const lines = view.lines.map((l: any) => ({
    ...l,
    labourType: l.labourType ?? 'per_gram',
    labourRate: l.labourRate,
  }));
  return { input, lines };
}

d('WP-26 Sales Invoice residuals (database)', () => {
  const prisma = new PrismaClient();
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });

  const rows = (sql: string, ...p: unknown[]): Promise<any[]> =>
    withTenant(prisma, TENANT, (tx: any) => tx.$queryRawUnsafe(sql, ...p));
  const voucherRows = (table: string, vchNo: number | string, order = '"SR_NO"') =>
    rows(
      `SELECT * FROM "${table}" WHERE "CO_CODE"=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2 ORDER BY ${order}`,
      CO,
      fmt(vchNo),
    );
  const header = async (vchNo: number) => (await voucherRows('SL_DATA', vchNo, '"VCH_NO"'))[0];
  const strip = (list: any[], drop: string[] = []) =>
    list.map((r) => {
      const out = { ...r };
      for (const c of ['row_id', ...drop]) delete out[c];
      return JSON.parse(JSON.stringify(out, (_k, v) => (typeof v === 'bigint' ? v.toString() : v)));
    });

  const clean = async () => {
    for (const t of await tenantTables(owner))
      await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id = ANY($1::text[])`, [
        TENANT,
        OTHER,
      ]);
  };
  const seedMasters = async (tenantId: string) => {
    await seedCompany(prisma, tenantId, CO, { coName: 'WP26', lcCode: LC });
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
         VALUES ($1,$2,$3,'WCUST','WP26 Customer','L'),($1,$2,$3,'WU1','PhonePe','L'),($1,$2,$3,'WU2','Gpay','L'),
                ($1,$2,$3,'WM1','Member One','L')`,
        tenantId,
        CO,
        LC,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
         VALUES ($1,$2,'W26','WP26 Gold','SALES','PURCHASE')`,
        tenantId,
        CO,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
         VALUES ($1,$2,'WGLD','WP26 Gold 22','G','W26'),($1,$2,'OLDG','Old Gold','G','W26'),
                ($1,$2,'OLDS','Old Silver','S','W26'),($1,$2,'OLDP','Old Platinum','P','W26')`,
        tenantId,
        CO,
      );
      // Two more 3% GST parents beside the provisioned '10' (G82 shape: parent SR_NO 0 + components 1/2/3).
      for (const [code, name] of [
        ['A3', 'GST 3% A'],
        ['B3', 'GST 3% B'],
      ]) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP")
           VALUES ($1,$2,$3,0,$4,3,'N'),($1,$2,$3,1,'SGST',1.5,'SGST'),($1,$2,$3,2,'CGST',1.5,'CGST'),
                  ($1,$2,$3,3,'IGST',3,'IGST')`,
          tenantId,
          CO,
          code,
          name,
        );
      }
      // Orders with an advance (SL_ORD_DATA.ADV_AMT is the advance the reader counts).
      for (const [no, adv] of [
        ['00001', 5000],
        ['00002', 3000],
        ['00003', 2000],
        ['00007', 5000],
      ] as const) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO",
             "VCH_DATE","AC_CODE","AC_NAME","ADV_AMT") VALUES ($1,$2,$3,$4,'SOR',$5,$5,$6::date,'WCUST','WP26 Customer',$7)`,
          tenantId,
          CO,
          LC,
          YEAR,
          no,
          DAY,
          adv,
        );
      }
    });
  };

  beforeAll(async () => {
    await clean();
  });
  beforeEach(async () => {
    await clean();
    await seedMasters(TENANT);
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
    await owner.$disconnect();
  });

  it('sales-invoice.create.header-columns: MEMB_COM_AC_CODE, WHOUT_COMM_BILL, RATE_UNFIX, TAX_CODE, DATA_TRFR, USER_UPDATE', async () => {
    const r = await createSale(
      prisma,
      sale({
        memberCommissionAc: 'WM1',
        withoutCommissionBill: true,
        rateUnfix: true,
        taxCode: 'A3',
        cashAmt: TOTAL,
      }),
      [LINE_A],
    );
    const h = await header(r.vchNo);
    // TR_SALE.cs:15264, :15267, :15347, :15203, :15332, :15342
    expect([
      h.MEMB_COM_AC_CODE,
      h.WHOUT_COMM_BILL,
      h.RATE_UNFIX,
      h.TAX_CODE,
      h.DATA_TRFR,
      h.USER_UPDATE,
    ]).toEqual(['WM1', 'Y', 'Y', 'A3', 'N', 'N']);
    const plain = await createSale(prisma, sale({ cashAmt: TOTAL }), [LINE_A]);
    expect([
      (await header(plain.vchNo)).RATE_UNFIX,
      (await header(plain.vchNo)).WHOUT_COMM_BILL,
    ]).toEqual(['N', 'N']);
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect([
      view.memberCommissionAc,
      view.withoutCommissionBill,
      view.rateUnfix,
      view.taxCode,
    ]).toEqual(['WM1', true, true, 'A3']);
  });

  it('sales-invoice.reopen.desktop-saved-header-columns: an unchanged save writes the whole SL_DATA row back', async () => {
    const r = await createSale(prisma, sale({ cashAmt: TOTAL, taxCode: 'A3' }), [LINE_A]);
    // The columns a desktop save holds that the web would otherwise default (D8: DATA_TRFR/USER_* kept).
    await withTenant(prisma, TENANT, (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "SL_DATA" SET "MEMB_COM_AC_CODE"='WM1',"WHOUT_COMM_BILL"='Y',"DATA_TRFR"='Y',"USER_UPDATE"='Y',
           "USER_DELETE"='Y',"CARD_ADJ"='Y',"AC_MEMB_COM_VAL"=12,"IRN_NO"='IRN-1'
          WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1`,
        fmt(r.vchNo),
      ),
    );
    const before = strip([await header(r.vchNo)], ['VCH_TIME']);
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect([view.dataTransfer, view.userUpdate, view.userDelete]).toEqual([true, true, true]); // :14412-14417
    const { input, lines } = inputFromView(view);
    await editSale(prisma, input, lines, r.vchNo, view.version);
    expect(strip([await header(r.vchNo)], ['VCH_TIME'])).toEqual(before);
  });

  it('sales-invoice.edit.changed-save-marks-transfer: a changed save writes DATA_TRFR N, USER_UPDATE N, RE_TRFR Y', async () => {
    const r = await createSale(prisma, sale({ cashAmt: TOTAL }), [LINE_A]);
    await withTenant(prisma, TENANT, (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "SL_DATA" SET "DATA_TRFR"='Y',"USER_UPDATE"='Y' WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1`,
        fmt(r.vchNo),
      ),
    );
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    // cash 65,517.79 -> 65,516.79 with kasar 1.00: BILL_OS = 65,517.79 - 65,516.79 - 1.00 = 0.00
    const { input, lines } = inputFromView(view, { cashAmt: 65516.79, kasarAmount: 1 });
    await editSale(prisma, input, lines, r.vchNo, view.version);
    const h = await header(r.vchNo);
    expect([h.DATA_TRFR, h.USER_UPDATE, h.RE_TRFR, Number(h.BILL_OS)]).toEqual(['N', 'N', 'Y', 0]);
  });

  it('sales-invoice.create.upi-rows: two UPI_DATA rows, UPI_AMT is their sum, BILL_OS 0', async () => {
    // 1,000.00 + 2,500.50 = 3,500.50; cash = 65,517.79 - 3,500.50 = 62,017.29
    const r = await createSale(prisma, sale({ upiRows: UPI, cashAmt: 62017.29 }), [LINE_A]);
    const h = await header(r.vchNo);
    expect([Number(h.UPI_AMT), Number(h.BILL_OS)]).toEqual([3500.5, 0]);
    const upi = await voucherRows('UPI_DATA', fmt(r.vchNo));
    expect(
      upi.map((u) => [
        u.SR_NO,
        u.UPI_AC_CODE,
        u.UPI_AC_NAME,
        u.UPI_TYPE,
        u.UPI_ID,
        Number(u.UPI_AMT),
      ]),
    ).toEqual([
      [1, 'WU1', 'PhonePe', 'PHONEPE', 'a@b', 1000],
      [2, 'WU2', 'Gpay', 'GPAY', 'c@d', 2500.5],
    ]);
    // The real ledger reader: the voucher's AC_DATA balances and the bank leg carries the UPI tender.
    const legs = await rows(
      `SELECT sum("DR_AMT")::float dr, sum("CR_AMT")::float cr FROM "AC_DATA" WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1`,
      fmt(r.vchNo),
    );
    expect(Math.abs(legs[0].dr - legs[0].cr)).toBeLessThan(0.005);
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect(view.upiRows.map((u: any) => u.amount)).toEqual([1000, 2500.5]);
  });

  it('sales-invoice.refusal.upi-amount-mismatch: upiAmount 3,000.00 against rows 3,500.50 is refused, nothing written', async () => {
    await expect(
      createSale(prisma, sale({ upiRows: UPI, upiAmt: 3000, cashAmt: 62517.29 }), [LINE_A]),
    ).rejects.toThrow(/upiAmount/);
    for (const t of ['SL_DATA', 'UPI_DATA', 'AC_DATA', 'MAIN_STOCK'])
      expect((await rows(`SELECT count(*)::int n FROM "${t}" WHERE "CO_BOOK"='SL'`))[0].n).toBe(0);
  });

  it('sales-invoice.edit.upi-row-amount and children.upi-two-rows-dissimilar: rows rewrite per voucher only', async () => {
    const x = await createSale(prisma, sale({ upiRows: UPI, cashAmt: 62017.29 }), [LINE_A]);
    const y = await createSale(
      prisma,
      sale({
        upiRows: [{ acCode: 'WU1', acName: 'Paytm', type: 'PAYTM', upiId: 'e@f', amount: 700 }],
        cashAmt: 64817.79,
      }),
      [LINE_A],
    );
    let view: any = await getSale(prisma, scopeOf(), x.vchNo);
    // row 1 1,000.00 -> 1,200.00: UPI 3,700.50, cash 65,517.79 - 3,700.50 = 61,817.29
    let edit = inputFromView(view, {
      upiRows: [{ ...view.upiRows[0], amount: 1200 }, view.upiRows[1]],
      cashAmt: 61817.29,
    });
    await editSale(prisma, edit.input, edit.lines, x.vchNo, view.version);
    expect((await voucherRows('UPI_DATA', fmt(x.vchNo))).map((u) => Number(u.UPI_AMT))).toEqual([
      1200, 2500.5,
    ]);
    expect([
      Number((await header(x.vchNo)).UPI_AMT),
      Number((await header(x.vchNo)).BILL_OS),
    ]).toEqual([3700.5, 0]);
    // delete row 1: one row left, renumbered SR_NO 1; cash 65,517.79 - 2,500.50 = 63,017.29
    view = await getSale(prisma, scopeOf(), x.vchNo);
    edit = inputFromView(view, { upiRows: [view.upiRows[1]], cashAmt: 63017.29 });
    await editSale(prisma, edit.input, edit.lines, x.vchNo, view.version);
    const left = await voucherRows('UPI_DATA', fmt(x.vchNo));
    expect(left.map((u) => [u.SR_NO, u.UPI_AC_CODE, Number(u.UPI_AMT)])).toEqual([
      [1, 'WU2', 2500.5],
    ]);
    expect(Number((await header(x.vchNo)).UPI_AMT)).toBe(2500.5);
    const other = await voucherRows('UPI_DATA', fmt(y.vchNo));
    expect(other.map((u) => [u.UPI_ID, Number(u.UPI_AMT)])).toEqual([['e@f', 700]]);
  });

  it('sales-invoice.create.credit-note and children.credit-note-two-rows: CRNT_ADJ_AMT joins the bill outstanding', async () => {
    // CN1 4,000.00 + CN2 1,500.00 = 5,500.00; cash 65,517.79 - 5,500.00 = 60,017.79; BILL_OS 0.00
    const notes = [
      { crntNo: 'CN1', amount: 4000 },
      { crntNo: 'CN2', amount: 1500 },
    ];
    const r = await createSale(prisma, sale({ creditNotes: notes, cashAmt: 60017.79 }), [LINE_A]);
    const other = await createSale(
      prisma,
      sale({ creditNotes: [{ crntNo: 'CN3', amount: 800 }], cashAmt: 64717.79 }),
      [LINE_A],
    );
    let h = await header(r.vchNo);
    expect([Number(h.CRNT_ADJ_AMT), Number(h.BILL_OS)]).toEqual([5500, 0]);
    // remove CN2: CRNT_ADJ_AMT 4,000.00, cash 61,517.79 (65,517.79 - 4,000.00), BILL_OS 0.00
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect(view.creditNotes.map((c: any) => c.crntNo)).toEqual(['CN1', 'CN2']);
    const edit = inputFromView(view, { creditNotes: [view.creditNotes[0]], cashAmt: 61517.79 });
    await editSale(prisma, edit.input, edit.lines, r.vchNo, view.version);
    h = await header(r.vchNo);
    expect([Number(h.CRNT_ADJ_AMT), Number(h.BILL_OS)]).toEqual([4000, 0]);
    const crnt = await voucherRows('CRNT_DATA', fmt(r.vchNo));
    expect(crnt.map((c) => [c.SR_NO, c.CRNT_NO, Number(c.CRNT_AMT), c.ENTRY_TYPE])).toEqual([
      [1, 'CN1', 4000, 'S'],
    ]);
    const kept = await voucherRows('CRNT_DATA', fmt(other.vchNo));
    expect(kept.map((c) => [c.CRNT_NO, Number(c.CRNT_AMT)])).toEqual([['CN3', 800]]);
  });

  it('sales-invoice.create.order-advance-two-orders and children.order-advance-two-orders (desktop shape, D2)', async () => {
    // O1 5,000.00 + O2 3,000.00 = 8,000.00; cash 65,517.79 - 8,000.00 = 57,517.79
    const r = await createSale(
      prisma,
      sale({
        orders: [
          { ordNo: '00001', amount: 5000 },
          { ordNo: '00002', amount: 3000 },
        ],
        cashAmt: 57517.79,
      }),
      [LINE_A],
    );
    const z = await createSale(
      prisma,
      sale({ orders: [{ ordNo: '00003', amount: 2000 }], cashAmt: 63517.79 }),
      [LINE_A],
    );
    let h = await header(r.vchNo);
    expect([Number(h.ADV_AMT), Number(h.BILL_OS)]).toEqual([8000, 0]);
    const adj = await voucherRows('SL_ORD_ADJ', fmt(r.vchNo));
    expect(
      adj.map((a) => [
        a.SR_NO,
        a.ORD_NO,
        a.ORD_SIGN,
        Number(a.ORD_AMT),
        Number(a.PAID_AMT),
        a.ENTRY_TYPE,
        a.ORD_DBCD,
        a.ORD_AC_CODE,
      ]),
    ).toEqual([
      [1, '00001', '-', 5000, 0, 'S', 'SOR', 'WCUST'],
      [2, '00002', '-', 3000, 0, 'S', 'SOR', 'WCUST'],
    ]);
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect(view.orders.map((o: any) => [o.ordNo, o.amount])).toEqual([
      ['00001', 5000],
      ['00002', 3000],
    ]);
    // remove O2: ADV_AMT 5,000.00, cash 60,517.79 (65,517.79 - 5,000.00)
    const edit = inputFromView(view, { orders: [view.orders[0]], cashAmt: 60517.79 });
    await editSale(prisma, edit.input, edit.lines, r.vchNo, view.version);
    h = await header(r.vchNo);
    expect([Number(h.ADV_AMT), Number(h.BILL_OS)]).toEqual([5000, 0]);
    expect((await voucherRows('SL_ORD_ADJ', fmt(r.vchNo))).map((a) => a.ORD_NO)).toEqual(['00001']);
    expect((await voucherRows('SL_ORD_ADJ', fmt(z.vchNo))).map((a) => Number(a.ORD_AMT))).toEqual([
      2000,
    ]);
  });

  it('sales-invoice.refusal.duplicate-order: the same book and order twice is refused with "Duplicate Order No"', async () => {
    await expect(
      createSale(
        prisma,
        sale({
          orders: [
            { ordNo: '00001', amount: 1000 },
            { ordNo: '00001', amount: 1000 },
          ],
          cashAmt: 63517.79,
        }),
        [LINE_A],
      ),
    ).rejects.toThrow('Duplicate Order No');
    expect((await rows(`SELECT count(*)::int n FROM "SL_DATA"`))[0].n).toBe(0);
  });

  it('sales-invoice.concurrency.order-advance-double-use: two 4,000.00 uses of a 5,000.00 advance, one wins', async () => {
    const one = () =>
      createSale(prisma, sale({ orders: [{ ordNo: '00007', amount: 4000 }], cashAmt: 61517.79 }), [
        LINE_A,
      ]);
    const results = await Promise.allSettled([one(), one()]);
    expect(results.filter((x) => x.status === 'fulfilled')).toHaveLength(1);
    const lost = results.find((x) => x.status === 'rejected') as PromiseRejectedResult;
    expect(lost.reason?.statusCode).toBe(409);
    // 5,000.00 - 4,000.00 = 1,000.00 left; one SL_DATA row, one SL_ORD_ADJ row
    expect((await rows(`SELECT count(*)::int n FROM "SL_DATA"`))[0].n).toBe(1);
    const used = await rows(
      `SELECT sum("ORD_AMT")::float s FROM "SL_ORD_ADJ" WHERE "ORD_NO"='00007'`,
    );
    expect(used[0].s).toBe(4000);
  });

  it('sales-invoice.create.old-metal-gold-silver and oldmetal.header-gold-silver-split (G83, G8d)', async () => {
    // R1 OLDG type G net 10.000 amount 54,000.00; R2 OLDS type S net 100.000 amount 7,200.00;
    // R3 OLDP type P net 5.000 rate 200 N = 1,000.00; a blank row (net 0, amount 0) is not written.
    // cash = 65,517.79 - 54,000.00 - 8,200.00 = 3,317.79
    const r = await createSale(
      prisma,
      sale({
        cashAmt: 3317.79,
        oldGold: [
          { metal: 'G', itCode: 'OLDG', netWt: 10, amount: 54000, rateType: 'N' },
          { metal: 'S', itCode: 'OLDS', netWt: 100, amount: 7200, rateType: 'N' },
          {
            metal: 'S',
            itType: 'P',
            itCode: 'OLDP',
            netWt: 5,
            rate: 200,
            rateType: 'N',
            amount: 0,
          },
          { metal: 'G', itCode: 'OLDG', netWt: 0, amount: 0 },
        ],
      }),
      [LINE_A],
    );
    const h = await header(r.vchNo);
    expect([
      h.OLD_GL,
      Number(h.OLD_GL_AMT),
      h.OLD_SL,
      Number(h.OLD_SL_AMT),
      Number(h.BILL_OS),
    ]).toEqual([10, 54000, 105, 8200, 0]);
    const pr = await voucherRows('SL_PR_DETL', fmt(r.vchNo));
    expect(pr.map((p) => [p.IT_TYPE, Number(p.NET_AMT)])).toEqual([
      ['G', 54000],
      ['S', 7200],
      ['P', 1000],
    ]);
  });

  it('sales-invoice.oldmetal.one-figure-detail-header-ledger: NET_AMT = OLD_GL_AMT = ledger line = 54,000.00', async () => {
    // Round(10.000 x 5,400, 0) = 54,000.00; cash 65,517.79 - 54,000.00 = 11,517.79; BILL_OS 0.00
    const r = await createSale(
      prisma,
      sale({
        cashAmt: 11517.79,
        oldGold: [{ metal: 'G', itCode: 'OLDG', netWt: 10, rate: 5400, rateType: 'N', amount: 0 }],
      }),
      [LINE_A],
    );
    const no = fmt(r.vchNo);
    const h = await header(r.vchNo);
    const pr = await voucherRows('SL_PR_DETL', no);
    const leg = await rows(
      `SELECT sum("DR_AMT")::float dr FROM "AC_DATA" WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1 AND "AC_CODE"='OLDGOLD'`,
      no,
    );
    expect([Number(pr[0].NET_AMT), Number(h.OLD_GL_AMT), leg[0].dr, Number(h.BILL_OS)]).toEqual([
      54000, 54000, 54000, 0,
    ]);
  });

  it('sales-invoice.refusal.oldmetal-rate-type: a rate type other than N or F is refused with the desktop text', async () => {
    for (const rateType of ['X', 'n'])
      await expect(
        createSale(
          prisma,
          sale({
            cashAmt: 11517.79,
            oldGold: [{ itCode: 'OLDG', netWt: 10, rate: 5400, rateType, amount: 0 }],
          }),
          [LINE_A],
        ),
      ).rejects.toThrow('Please Slelect Rate type = N - Net Wise Or F - Fine Wise');
    expect((await rows(`SELECT count(*)::int n FROM "SL_DATA"`))[0].n).toBe(0);
  });

  it('sales-invoice.reopen.old-metal-rows-pr-cost-it-type, field.old-metal-pr-cost-route, edit.old-metal-weight', async () => {
    const r = await createSale(
      prisma,
      sale({
        cashAmt: 3317.79,
        oldGold: [
          { metal: 'G', itCode: 'OLDG', netWt: 10, amount: 54000, rateType: 'N', prCost: 52000 },
          { metal: 'S', itCode: 'OLDS', netWt: 100, amount: 7200, rateType: 'N', prCost: 6000 },
          {
            metal: 'S',
            itType: 'P',
            itCode: 'OLDP',
            netWt: 5,
            rate: 200,
            rateType: 'N',
            amount: 0,
            prCost: 900,
          },
        ],
      }),
      [LINE_A],
    );
    const no = fmt(r.vchNo);
    const before = strip(await voucherRows('SL_PR_DETL', no), ['VCH_TIME']);
    expect(before.map((p: any) => [p.IT_TYPE, Number(p.PR_COST)])).toEqual([
      ['G', 52000],
      ['S', 6000],
      ['P', 900],
    ]);
    let view: any = await getSale(prisma, scopeOf(), r.vchNo);
    let edit = inputFromView(view);
    await editSale(prisma, edit.input, edit.lines, r.vchNo, view.version);
    expect(strip(await voucherRows('SL_PR_DETL', no), ['VCH_TIME'])).toEqual(before);
    expect([(await header(r.vchNo)).OLD_GL, (await header(r.vchNo)).OLD_SL]).toEqual([10, 105]);
    // edit.old-metal-weight: one gold row 10.000 at 5,400 -> 11.000: Round(11.000 x 5,400, 0) = 59,400.00
    const one = await createSale(
      prisma,
      sale({
        cashAmt: 11517.79,
        oldGold: [
          { itCode: 'OLDG', netWt: 10, rate: 5400, rateType: 'N', amount: 0, prCost: 52000 },
        ],
      }),
      [LINE_A],
    );
    view = await getSale(prisma, scopeOf(), one.vchNo);
    // cash 65,517.79 - 59,400.00 = 6,117.79
    edit = inputFromView(view, {
      oldGold: [{ ...view.oldGold[0], netWt: 11, amount: 0 }],
      cashAmt: 6117.79,
    });
    await editSale(prisma, edit.input, edit.lines, one.vchNo, view.version);
    const h = await header(one.vchNo);
    const pr = await voucherRows('SL_PR_DETL', fmt(one.vchNo));
    expect([Number(pr[0].NET_AMT), Number(h.OLD_GL_AMT), h.OLD_GL, Number(pr[0].PR_COST)]).toEqual([
      59400, 59400, 11, 52000,
    ]);
  });

  it('sales-invoice.config.history-reopen-after-master-change: stored rate, amount and description are reopened', async () => {
    const r = await createSale(
      prisma,
      sale({
        cashAmt: 11517.79,
        oldGold: [
          {
            itCode: 'OLDG',
            description: 'Old Gold',
            netWt: 10,
            rate: 5400,
            rateType: 'N',
            amount: 0,
          },
        ],
      }),
      [LINE_A],
    );
    await withTenant(prisma, TENANT, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `UPDATE "ITEM_MAST" SET "IT_NAME"='Renamed' WHERE "IT_CODE"='OLDG'`,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "RATE_MAST"(tenant_id,"CO_CODE","LC_CODE","VCH_DATE","SR_NO","FINE_GL_RATE","FINE_SL_RATE")
         VALUES ($1,$2,$3,$4::date,1,70000,90000)`,
        TENANT,
        CO,
        LC,
        DAY,
      );
    });
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect([view.oldGold[0].rate, view.oldGold[0].amount, view.oldGold[0].description]).toEqual([
      5400,
      54000,
      'Old Gold',
    ]);
    const edit = inputFromView(view);
    await editSale(prisma, edit.input, edit.lines, r.vchNo, view.version);
    const pr = await voucherRows('SL_PR_DETL', fmt(r.vchNo));
    expect(Number(pr[0].NET_AMT)).toBe(54000);
  });

  it('sales-invoice.reopen.desktop-saved-stones-and-source-tables: 9 rows in six tables survive an unchanged save', async () => {
    // UPI 3,500.50 + credit note 4,000.00 + orders 8,000.00 = 15,500.50; cash 65,517.79 - 15,500.50 = 50,017.29
    const r = await createSale(
      prisma,
      sale({
        upiRows: UPI,
        creditNotes: [{ crntNo: 'CN1', amount: 4000 }],
        orders: [
          { ordNo: '00001', amount: 5000 },
          { ordNo: '00002', amount: 3000 },
        ],
        cashAmt: 50017.29,
      }),
      [LINE_A],
    );
    const no = fmt(r.vchNo);
    // Desktop-only rows: two stones on line 1, one POINT_DATA, one CARD_DATA.
    await withTenant(prisma, TENANT, async (tx: any) => {
      // Through insertRowTx, so the columns the desktop never leaves NULL carry its measured defaults.
      const hd = (
        await tx.$queryRawUnsafe(
          `SELECT "HD_VCH_NO" h FROM "SL_DATA" WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1`,
          no,
        )
      )[0].h;
      for (const [isr, dm] of [
        [1, 'DM01'],
        [2, 'DM02'],
      ] as const)
        await insertRowTx(tx, 'SL_IDTL', TENANT, {
          CO_CODE: CO,
          LC_CODE: LC,
          CO_YEAR: YEAR,
          CO_BOOK: 'SL',
          VCH_NO: no,
          SR_NO: 1,
          ISR_NO: isr,
          VCH_DATE: new Date(DAY),
          HD_VCH_NO: hd,
          VCH_TYPE: 'SL',
          INOUT_TYPE: 'O',
          ENTRY_TYPE: 'S',
          BOOK_NAME: 'SALES',
          AC_CODE: 'WCUST',
          TAG_NO: '',
          IT_CODE: 'STN',
          DM_CODE: dm,
          DM_NAME: 'Stone',
          IT_PCS: 2,
          IT_GWT: 0.2,
          IT_RATE: 500,
          IT_AMT: 1000,
        });
      await tx.$executeRawUnsafe(
        `INSERT INTO "POINT_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO") VALUES ($1,$2,$3,$4,'SL',$5,1)`,
        TENANT,
        CO,
        LC,
        YEAR,
        no,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "CARD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","CARD_AMT") VALUES ($1,$2,$3,$4,'SL',$5,10)`,
        TENANT,
        CO,
        LC,
        YEAR,
        no,
      );
    });
    const tables = ['SL_IDTL', 'UPI_DATA', 'CRNT_DATA', 'SL_ORD_ADJ', 'POINT_DATA', 'CARD_DATA'];
    const orderOf: Record<string, string> = { CARD_DATA: '"VCH_NO"' };
    const dump = async () => {
      const out: Record<string, unknown> = {};
      for (const t of tables) out[t] = strip(await voucherRows(t, no, orderOf[t]), ['VCH_TIME']);
      return out;
    };
    const before = await dump();
    expect(Object.values(before).reduce((s: number, v: any) => s + v.length, 0)).toBe(9); // 2+2+1+2+1+1
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect(view.lines[0].stones.map((s: any) => s.DM_CODE)).toEqual(['DM01', 'DM02']);
    const edit = inputFromView(view);
    await editSale(prisma, edit.input, edit.lines, r.vchNo, view.version);
    expect(await dump()).toEqual(before);
    expect(Number((await header(r.vchNo)).BILL_OS)).toBe(0);
  });

  it('sales-invoice.delete.removes-tender-and-source-rows: every child of the deleted voucher goes, the other stays', async () => {
    const make = () =>
      createSale(
        prisma,
        sale({ upiRows: UPI, creditNotes: [{ crntNo: 'CN1', amount: 4000 }], cashAmt: 58017.29 }),
        [LINE_A],
      );
    const gone = await make();
    const kept = await make();
    const view: any = await getSale(prisma, scopeOf(), gone.vchNo);
    await deleteSale(prisma, {
      scope: scopeOf(),
      vchNo: gone.vchNo,
      deleteUser: 'wp26',
      expectedVersion: view.version,
    });
    for (const t of ['UPI_DATA', 'CRNT_DATA', 'SL_DATA']) {
      expect(await voucherRows(t, fmt(gone.vchNo), '1')).toHaveLength(0);
      expect((await voucherRows(t, fmt(kept.vchNo), '1')).length).toBeGreaterThan(0);
    }
    expect((await rows(`SELECT count(*)::int n FROM "DELETE_DATA"`))[0].n).toBeGreaterThan(0);
  });

  it('sales-invoice.reopen.tax-code-two-codes-one-rate: the reopened code is sent back; the parent name is shown (G82)', async () => {
    const r = await createSale(prisma, sale({ taxCode: 'B3', cashAmt: TOTAL }), [LINE_A]);
    const view: any = await getSale(prisma, scopeOf(), r.vchNo);
    expect([view.taxCode, view.taxName]).toEqual(['B3', 'GST 3% B']); // TR_SALE.cs:14337, SR_NO = 0
    const edit = inputFromView(view);
    await editSale(prisma, edit.input, edit.lines, r.vchNo, view.version);
    expect((await header(r.vchNo)).TAX_CODE).toBe('B3');
  });

  it('sales-invoice.rights.tender-rows-other-tenant: another tenant cannot read or rewrite the voucher', async () => {
    await seedMasters(OTHER);
    const theirs = await createSale(prisma, sale({ upiRows: UPI, cashAmt: 62017.29 }, OTHER), [
      LINE_A,
    ]);
    await createSale(prisma, sale({ upiRows: UPI, cashAmt: 62017.29 }, OTHER), [LINE_A]);
    const count = () =>
      withTenant(prisma, OTHER, (tx: any) =>
        tx.$queryRawUnsafe(`SELECT count(*)::int n FROM "UPI_DATA"`),
      );
    const before = await count();
    await expect(getSale(prisma, scopeOf(), theirs.vchNo + 1)).rejects.toThrow(/not found/);
    await expect(
      editSale(prisma, sale({ upiRows: UPI, cashAmt: 62017.29 }), [LINE_A], theirs.vchNo + 1, 'x'),
    ).rejects.toThrow();
    expect(await count()).toEqual(before);
  });
  const seedPrintMast = async () => {
    const book = (
      await rows(
        `SELECT "MAIN_BOOK", coalesce("BOOK_TYPE",'') t FROM "BOOK_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"='SL'`,
        CO,
      )
    )[0];
    await withTenant(prisma, TENANT, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","BOOK_TYPE","PRINT_FILE","PRINT_SET_A")
         VALUES ($1,'01',$2,$3,'SalesBillGst','Y'),($1,'01',$2,$3,'SalesBillA4','N'),
                ($1,'02',$2,$3,'OtherCompany','Y'),($1,'01',$2,'ZZ','OtherBookType','N')`,
        TENANT,
        book.MAIN_BOOK,
        book.t,
      ),
    );
    return book;
  };

  it('sales-invoice.entry.print-file-list-and-default and entry.print-file-company-fallback (TR_SALE.cs:13933)', async () => {
    const book = await seedPrintMast();
    // 3 rows for company 01 and the book, 2 match the book type: blank + SalesBillA4 + SalesBillGst, Gst selected.
    expect(await salePrintFiles(prisma, scopeOf())).toEqual({
      files: ['', 'SalesBillA4', 'SalesBillGst'],
      selected: 'SalesBillGst',
      fromCompany: '01',
    });
    // Company 02 with no rows of its own for the book falls back to company 01 of the same tenant.
    await withTenant(prisma, TENANT, async (tx: any) => {
      await tx.$executeRawUnsafe(`DELETE FROM "PRINT_MAST" WHERE "CO_CODE"='02'`);
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_TYPE") VALUES ($1,'02',$2,'SL',$3,$4)`,
        TENANT,
        LC,
        book.MAIN_BOOK,
        book.t || null,
      );
    });
    const fallback = await salePrintFiles(prisma, { ...scopeOf(), coCode: '02' });
    expect([fallback.files, fallback.fromCompany]).toEqual([
      ['', 'SalesBillA4', 'SalesBillGst'],
      '01',
    ]);
  });

  it('sales-invoice.print.set-default-file: Set marks the chosen file Y and the others of the book N', async () => {
    await seedPrintMast();
    expect(await setSalePrintDefault(prisma, scopeOf(), 'SalesBillA4')).toEqual({
      message: 'Print Report Default Set',
    });
    const all = await rows(
      `SELECT "CO_CODE","BOOK_TYPE","PRINT_FILE","PRINT_SET_A" FROM "PRINT_MAST" ORDER BY "CO_CODE","PRINT_FILE"`,
    );
    expect(all.map((r) => [r.PRINT_FILE, r.PRINT_SET_A])).toEqual([
      ['OtherBookType', 'N'],
      ['SalesBillA4', 'Y'],
      ['SalesBillGst', 'N'],
      ['OtherCompany', 'Y'],
    ]);
    await expect(setSalePrintDefault(prisma, scopeOf(), 'Missing')).rejects.toThrow(/not found/);
  });

  it('sales-invoice.print.opening-closing-parameters: OpAmt/ClAmt are Sum(CR - DR) before and up to the voucher', async () => {
    // Opening 10,000.00 Dr on an earlier day; a credit sale of 65,517.79 Dr. Desktop MsAcBal sums CR - DR, so a debit
    // balance is negative: OpAmt = -10,000.00; ClAmt = -(10,000.00 + 65,517.79) = -75,517.79.
    await withTenant(prisma, TENANT, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","DR_AMT","CR_AMT","ENTRY_TIME")
         VALUES ($1,$2,$3,$4,'OPB','00001','2024-04-01'::date,'WCUST',10000,0,'2024-04-01 00:00:00')`,
        TENANT,
        CO,
        LC,
        YEAR,
      ),
    );
    const r = await createSale(prisma, sale({}), [LINE_A]);
    const data = await salesBillData(prisma, { ...scopeOf(), vchNo: fmt(r.vchNo) } as any, {
      balances: true,
    });
    expect(data?.balances).toEqual({ opAmt: -10000, clAmt: -75517.79 });
    const direct = await withTenant(prisma, TENANT, (tx: any) =>
      salePartyBalancesTx(tx, scopeOf() as any, 'WCUST', new Date('2024-04-01T00:00:00Z')),
    );
    expect(direct.opAmt).toBe(0);
  });
  it('review #250: negative UPI, credit-note and order amounts are refused, nothing written', async () => {
    for (const over of [
      { upiRows: [{ acCode: 'WU1', amount: -100 }] },
      { creditNotes: [{ crntNo: 'CN1', amount: -100 }] },
      { orders: [{ ordNo: '00001', amount: -100 }] },
    ])
      await expect(createSale(prisma, sale(over), [LINE_A])).rejects.toThrow(/cannot be negative/);
    expect((await rows(`SELECT count(*)::int n FROM "SL_DATA"`))[0].n).toBe(0);
  });

  it('review #250: orders named in opposite order by two concurrent invoices both save (one lock order)', async () => {
    const make = (a: string, b: string) =>
      createSale(
        prisma,
        sale({
          orders: [
            { ordNo: a, amount: 1000 },
            { ordNo: b, amount: 1000 },
          ],
        }),
        [LINE_A],
      );
    const results = await Promise.allSettled([make('00001', '00002'), make('00002', '00001')]);
    expect(results.map((r) => r.status)).toEqual(['fulfilled', 'fulfilled']);
    // 2 x 1,000.00 from each order: 00001 5,000 -> 3,000 open, 00002 3,000 -> 1,000 open
    const used = await rows(
      `SELECT "ORD_NO", sum("ORD_AMT")::float s FROM "SL_ORD_ADJ" GROUP BY "ORD_NO" ORDER BY 1`,
    );
    expect(used.map((u) => [u.ORD_NO, u.s])).toEqual([
      ['00001', 2000],
      ['00002', 2000],
    ]);
  });

  it('review #250: an order of another book is not used in place of the named one', async () => {
    await expect(
      createSale(prisma, sale({ orders: [{ ordNo: '00001', ordBook: 'XX', amount: 100 }] }), [
        LINE_A,
      ]),
    ).rejects.toThrow(/not found/);
  });

  it('cash limit: the fourth cash sale of 65,517.79 is refused (3 x 65,517.79 = 196,553.37; + 65,517.79 > 200,000), UPI rows are not cash', async () => {
    for (let i = 0; i < 3; i++) await createSale(prisma, sale({ cashAmt: TOTAL }), [LINE_A]);
    await expect(createSale(prisma, sale({ cashAmt: TOTAL }), [LINE_A])).rejects.toThrow(
      /Cash Recieved Limit Amount/,
    );
    const upi = await createSale(prisma, sale({ upiRows: [{ acCode: 'WU1', amount: TOTAL }] }), [
      LINE_A,
    ]);
    expect(Number((await header(upi.vchNo)).UPI_AMT)).toBe(TOTAL);
  });
});
