import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, expect, it } from 'vitest';
import { describe } from 'vitest';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { createSale, deleteSale, editSale, getSale } from '../src/modules/sales/sales.js';
import { orderAdvanceAvailableTx } from '../src/modules/sales/salesOrder.js';
import { formatVoucherNo as fmt } from '../src/modules/vouchers/numbering.js';
import { tenantTables } from './support/tenantSnapshot.js';

/**
 * Owner decision 3B (2026-11-27): a sale may adjust another customer's order advance, or more than the order's open
 * advance, as the desktop allows (TR_SALE.cs:7206-7320, :15505-15530; Ac_Ledr.cs:131-133), but only with the
 * operator's confirmation of exactly those facts. Synthetic fixtures only.
 *
 * Line A: metal round(10.000 x 6,123.45, 0) = 61,234 + labour 2,375 = 63,609; GST 3% 1,908.27; total 65,517.27.
 * Orders: 00007 own customer (5,000.00), 00008 OTHER customer (3,000.00), 00009 the ORDER ADVANCE account 00020
 * (1,000.00).
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const TENANT = 'oadv-confirm';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';
const TOTAL = 65517.27;
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'SL' };

const LINE_A = {
  itCode: 'OAGLD',
  pcs: 1,
  grossWt: 10,
  netWt: 10,
  touch: 91.6,
  rate: 6123.45,
  labourType: 'per_gram' as const,
  labourRate: 237.5,
};
const sale = (over: Record<string, unknown> = {}) =>
  ({
    scope,
    mainUser: 'clerk1',
    acCode: 'OACUST',
    acName: 'Synthetic Buyer',
    vchDate: DAY,
    taxRatePct: 3,
    taxCode: '10',
    interState: false,
    ...over,
  }) as any;
const ack = (orderKey: string, orderParty: string, openAmount: number, adjustAmount: number) => ({
  orderKey,
  orderParty,
  openAmount,
  adjustAmount,
});

d('Order advance confirmation (owner decision 3B)', () => {
  const prisma = new PrismaClient();
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  const rows = (sql: string, ...p: unknown[]): Promise<any[]> =>
    withTenant(prisma, TENANT, (tx: any) => tx.$queryRawUnsafe(sql, ...p));
  const open = (no: string) =>
    withTenant(
      prisma,
      TENANT,
      async (tx: any) =>
        (await orderAdvanceAvailableTx(tx, { ...scope, coBook: 'SOR' }, no, 'SOR')).available,
    );
  const adjRows = (vchNo: number) =>
    rows(
      `SELECT "ORD_NO","ORD_AC_CODE","ORD_SIGN","ORD_AMT"::float amt,"AC_CODE" FROM "SL_ORD_ADJ"
        WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1 ORDER BY "SR_NO"`,
      fmt(vchNo),
    );
  const audit = () =>
    rows(
      `SELECT "VCH_NO","AC_CODE","USER_NAME","NEW_USER","COL_TYPE","OLD_VAL","NEW_VAL","ENTRY_TIME"
         FROM "USER_DATA" WHERE "COL_TYPE"='ORD_ADV_CONFIRM' ORDER BY row_id`,
    );
  const legs = (vchNo: number, code: string) =>
    rows(
      `SELECT "AC_CODE","LD_CODE","CR_AMT"::float cr,"DR_AMT"::float dr FROM "AC_DATA"
        WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1 AND "LEDR_KEY" LIKE $2 ORDER BY "LEDR_KEY"`,
      fmt(vchNo),
      `%SL${fmt(vchNo)}${code}%`,
    );
  const header = async (vchNo: number) =>
    (
      await rows(
        `SELECT "ADV_AMT"::float adv,"AC_CODE" FROM "SL_DATA" WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1`,
        fmt(vchNo),
      )
    )[0];
  const count = async (table: string) =>
    (await rows(`SELECT count(*)::int n FROM "${table}" WHERE "CO_BOOK"='SL'`))[0].n;

  const clean = async () => {
    for (const t of await tenantTables(owner))
      await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id = $1`, TENANT);
  };
  const seed = async () => {
    await seedCompany(prisma, TENANT, CO, { coName: 'OADV', lcCode: LC });
    await withTenant(prisma, TENANT, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `UPDATE "CO_SET_NEW" SET "TOT_AMT_ROF"=2 WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        TENANT,
        CO,
      );
      await tx.$executeRawUnsafe(
        `UPDATE "CO_SET" SET "TAX_ROF"=NULL,"LBR_ROF"=NULL,"ITM_RATE_ROF"=NULL,"CASH_LIMIT"=NULL WHERE tenant_id=$1 AND "CO_CODE"=$2`,
        TENANT,
        CO,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
         VALUES ($1,$2,$3,'OACUST','Synthetic Buyer','L'),($1,$2,$3,'OAOTHR','Synthetic Other','L')`,
        TENANT,
        CO,
        LC,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
         VALUES ($1,$2,'OA1','Synthetic Gold','SALES','PURCHASE')`,
        TENANT,
        CO,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
         VALUES ($1,$2,'OAGLD','Synthetic Gold 22','G','OA1')`,
        TENANT,
        CO,
      );
      for (const [no, ac, name, adv] of [
        ['00007', 'OACUST', 'Synthetic Buyer', 5000],
        ['00008', 'OAOTHR', 'Synthetic Other', 3000],
        ['00009', '00020', 'ORDER ADVANCE', 1000],
      ] as const)
        await tx.$executeRawUnsafe(
          `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","HD_VCH_NO",
             "VCH_DATE","AC_CODE","AC_NAME","ADV_AMT") VALUES ($1,$2,$3,$4,'SOR',$5,$5,$6::date,$7,$8,$9)`,
          TENANT,
          CO,
          LC,
          YEAR,
          no,
          DAY,
          ac,
          name,
          adv,
        );
    });
  };

  beforeAll(clean);
  beforeEach(async () => {
    await clean();
    await seed();
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
    await owner.$disconnect();
  });

  it("refuses another customer's order without an acknowledgement, stating the facts; nothing is written", async () => {
    const attempt = createSale(
      prisma,
      sale({ orders: [{ ordNo: '00008', amount: 2000 }], cashAmt: TOTAL - 2000 }),
      [LINE_A],
    );
    await expect(attempt).rejects.toMatchObject({
      code: 'order-advance-confirm',
      statusCode: 409,
      details: {
        reason: 'confirm',
        rows: [
          {
            orderKey: 'SOR/2024-2025/00008',
            ordNo: '00008',
            orderParty: 'OAOTHR',
            orderPartyName: 'Synthetic Other',
            saleParty: 'OACUST',
            salePartyName: 'Synthetic Buyer',
            openAmount: 3000,
            adjustAmount: 2000,
            overBy: 0,
            otherCustomer: true,
          },
        ],
      },
    });
    await expect(attempt).rejects.toThrow(
      /Order 00008 \(SOR\) belongs to Synthetic Other \(OAOTHR\), not to this bill's customer\. It has 3000\.00 advance open\. You are adjusting 2000\.00 on Synthetic Buyer \(OACUST\)'s bill\./,
    );
    expect(await count('SL_DATA')).toBe(0);
    expect(await audit()).toEqual([]);
    expect(await open('00008')).toBe(3000);
  });

  it('accepts it with a matching acknowledgement: desktop rows, no 21/22 legs for a customer order, audit and note', async () => {
    const r = await createSale(
      prisma,
      sale({
        orders: [{ ordNo: '00008', amount: 2000 }],
        cashAmt: TOTAL - 2000,
        orderAdvanceAck: [ack('SOR/2024-2025/00008', 'OAOTHR', 3000, 2000)],
      }),
      [LINE_A],
    );
    // TR_SALE.cs:15505-15530: ORD_AC_CODE is the order's party; ADV_AMT is the grid total (:15062).
    expect(await adjRows(r.vchNo)).toEqual([
      { ORD_NO: '00008', ORD_AC_CODE: 'OAOTHR', ORD_SIGN: '-', amt: 2000, AC_CODE: 'OACUST' },
    ]);
    expect(await header(r.vchNo)).toEqual({ adv: 2000, AC_CODE: 'OACUST' });
    // Ac_Ledr.cs:131-133: legs 21/22 only when ORD_AC_CODE = 00020.
    expect(await legs(r.vchNo, '21')).toEqual([]);
    expect(await open('00008')).toBe(1000);
    const trail = await audit();
    expect(trail).toHaveLength(1);
    expect(trail[0]).toMatchObject({
      VCH_NO: fmt(r.vchNo),
      AC_CODE: 'OACUST',
      USER_NAME: 'clerk1',
      NEW_USER: 'clerk1',
      OLD_VAL: 'SOR/2024-2025/00008|OAOTHR|3000.00',
      NEW_VAL: '2000.00|P|Y',
    });
    expect(trail[0].ENTRY_TIME).toBeTruthy();
    const view: any = await getSale(prisma, scope, r.vchNo);
    expect(view.orderAdvanceNotes).toHaveLength(1);
    expect(view.orderAdvanceNotes[0]).toMatch(
      /^Order advance from another customer's order \(OAOTHR\): order 00008, 2000\.00 adjusted — confirmed by clerk1 on \d{2}\/\d{2}\/\d{4}$/,
    );
  });

  it('refuses a stale acknowledgement (the open advance moved) with the new facts', async () => {
    await expect(
      createSale(
        prisma,
        sale({
          orders: [{ ordNo: '00008', amount: 2000 }],
          cashAmt: TOTAL - 2000,
          orderAdvanceAck: [ack('SOR/2024-2025/00008', 'OAOTHR', 2500, 2000)],
        }),
        [LINE_A],
      ),
    ).rejects.toMatchObject({
      code: 'order-advance-confirm',
      details: { reason: 'stale', rows: [{ openAmount: 3000, adjustAmount: 2000 }] },
    });
    // Another amount, or another party, than the one confirmed is stale too.
    for (const wrong of [
      ack('SOR/2024-2025/00008', 'OAOTHR', 3000, 1500),
      ack('SOR/2024-2025/00008', 'OACUST', 3000, 2000),
    ])
      await expect(
        createSale(
          prisma,
          sale({
            orders: [{ ordNo: '00008', amount: 2000 }],
            cashAmt: TOTAL - 2000,
            orderAdvanceAck: [wrong],
          }),
          [LINE_A],
        ),
      ).rejects.toMatchObject({ details: { reason: 'stale' } });
    expect(await count('SL_DATA')).toBe(0);
    expect(await audit()).toEqual([]);
  });

  it('over-open on the own order: refused, then confirmed; the open advance goes negative as on the desktop', async () => {
    const over = sale({ orders: [{ ordNo: '00007', amount: 6000 }], cashAmt: TOTAL - 6000 });
    await expect(createSale(prisma, over, [LINE_A])).rejects.toMatchObject({
      statusCode: 409,
      details: {
        reason: 'confirm',
        rows: [{ otherCustomer: false, openAmount: 5000, adjustAmount: 6000, overBy: 1000 }],
      },
    });
    await expect(createSale(prisma, over, [LINE_A])).rejects.toThrow(
      /It has 5000\.00 advance open\. You are adjusting 6000\.00 on Synthetic Buyer \(OACUST\)'s bill, 1000\.00 more than is open\./,
    );
    const r = await createSale(
      prisma,
      { ...over, orderAdvanceAck: [ack('SOR/2024-2025/00007', 'OACUST', 5000, 6000)] },
      [LINE_A],
    );
    expect(await adjRows(r.vchNo)).toEqual([
      { ORD_NO: '00007', ORD_AC_CODE: 'OACUST', ORD_SIGN: '-', amt: 6000, AC_CODE: 'OACUST' },
    ]);
    expect(await open('00007')).toBe(-1000);
    expect((await audit())[0]).toMatchObject({ NEW_VAL: '6000.00|O|Y' });
    const view: any = await getSale(prisma, scope, r.vchNo);
    expect(view.orderAdvanceNotes[0]).toMatch(
      /^Order advance 1000\.00 more than the 5000\.00 open/,
    );
  });

  it('the ORDER ADVANCE account order needs no party confirmation and posts legs 21/22', async () => {
    const r = await createSale(
      prisma,
      sale({ orders: [{ ordNo: '00009', amount: 1000 }], cashAmt: TOTAL - 1000 }),
      [LINE_A],
    );
    expect(await adjRows(r.vchNo)).toEqual([
      { ORD_NO: '00009', ORD_AC_CODE: '00020', ORD_SIGN: '-', amt: 1000, AC_CODE: 'OACUST' },
    ]);
    // Ac_Ledr.cs:131: leg 21 Cr the sale party 1,000.00 (LD_CODE 00020); leg 22 Dr 00020.
    expect(await legs(r.vchNo, '21')).toEqual([
      { AC_CODE: 'OACUST', LD_CODE: '00020', cr: 1000, dr: 0 },
    ]);
    expect(await audit()).toEqual([]);
  });

  it("an ORD_AC_CODE in the request cannot replace the order's own party", async () => {
    await expect(
      createSale(
        prisma,
        sale({
          orders: [{ ordNo: '00008', amount: 500, ordAcCode: '00020' }],
          cashAmt: TOTAL - 500,
        }),
        [LINE_A],
      ),
    ).rejects.toMatchObject({ code: 'order-advance-confirm' });
  });

  it("a forged ORD_LC / ORD_HD_VCH_NO in the request is ignored: the row carries the order's own key", async () => {
    // Without the fix ORD_LC '02' would pass the check against location 01's 5,000.00 and be stored against 02,
    // where the open-advance sum (coalesce(ORD_LC, LC_CODE)) would never count it: the advance could be used twice.
    const r = await createSale(
      prisma,
      sale({
        orders: [{ ordNo: '00007', amount: 5000, ordLc: '02', ordHdVchNo: '99999' }],
        cashAmt: TOTAL - 5000,
      }),
      [LINE_A],
    );
    const [row] = await rows(
      `SELECT "ORD_LC","ORD_HD_VCH_NO","ORD_YRCD","ORD_DBCD" FROM "SL_ORD_ADJ" WHERE "CO_BOOK"='SL' AND "VCH_NO"=$1`,
      fmt(r.vchNo),
    );
    expect(row).toEqual({
      ORD_LC: LC,
      ORD_HD_VCH_NO: '00007',
      ORD_YRCD: YEAR,
      ORD_DBCD: 'SOR',
    });
    expect(await open('00007')).toBe(0);
    // The advance is used up at 01: a second sale asking the same 5,000.00 again needs a confirmation.
    await expect(
      createSale(
        prisma,
        sale({ orders: [{ ordNo: '00007', amount: 5000, ordLc: '02' }], cashAmt: TOTAL - 5000 }),
        [LINE_A],
      ),
    ).rejects.toMatchObject({
      code: 'order-advance-confirm',
      details: { rows: [{ openAmount: 0, overBy: 5000 }] },
    });
  });

  it('edit asks again while the situation holds, and edit or delete puts the advance back', async () => {
    const confirmed = [ack('SOR/2024-2025/00008', 'OAOTHR', 3000, 2000)];
    const r = await createSale(
      prisma,
      sale({
        orders: [{ ordNo: '00008', amount: 2000 }],
        cashAmt: TOTAL - 2000,
        orderAdvanceAck: confirmed,
      }),
      [LINE_A],
    );
    let view: any = await getSale(prisma, scope, r.vchNo);
    // The edit excludes the sale's own earlier use, so the open advance is the full 3,000.00 again.
    await expect(
      editSale(
        prisma,
        sale({ orders: [{ ordNo: '00008', amount: 2500 }], cashAmt: TOTAL - 2500 }),
        [LINE_A],
        r.vchNo,
        view.version,
      ),
    ).rejects.toMatchObject({
      details: { rows: [{ openAmount: 3000, adjustAmount: 2500 }] },
    });
    expect(await open('00008')).toBe(1000);
    const edited = await editSale(
      prisma,
      sale({
        mainUser: 'clerk2',
        orders: [{ ordNo: '00008', amount: 2500 }],
        cashAmt: TOTAL - 2500,
        orderAdvanceAck: [ack('SOR/2024-2025/00008', 'OAOTHR', 3000, 2500)],
      }),
      [LINE_A],
      r.vchNo,
      view.version,
    );
    expect(await open('00008')).toBe(500);
    expect(await adjRows(r.vchNo)).toEqual([
      { ORD_NO: '00008', ORD_AC_CODE: 'OAOTHR', ORD_SIGN: '-', amt: 2500, AC_CODE: 'OACUST' },
    ]);
    const trail = await audit();
    expect(trail.map((t: any) => [t.USER_NAME, t.NEW_USER, t.NEW_VAL])).toEqual([
      ['clerk1', 'clerk1', '2000.00|P|Y'],
      ['clerk1', 'clerk2', '2500.00|P|Y'],
    ]);
    view = await getSale(prisma, scope, r.vchNo);
    expect(view.orderAdvanceNotes).toEqual([
      expect.stringMatching(/2500\.00 adjusted — confirmed by clerk2/),
    ]);
    // An edit to the own order only: no confirmation, the other order's advance is whole again, no note.
    const own = await editSale(
      prisma,
      sale({ orders: [{ ordNo: '00007', amount: 1000 }], cashAmt: TOTAL - 1000 }),
      [LINE_A],
      r.vchNo,
      (edited as any).version,
    );
    expect(await open('00008')).toBe(3000);
    expect(((await getSale(prisma, scope, r.vchNo)) as any).orderAdvanceNotes).toEqual([]);
    // Back on the other customer's order, then delete: every row goes, the advance is whole, the audit stays.
    const back = await editSale(
      prisma,
      sale({
        orders: [{ ordNo: '00008', amount: 3000 }],
        cashAmt: TOTAL - 3000,
        orderAdvanceAck: [ack('SOR/2024-2025/00008', 'OAOTHR', 3000, 3000)],
      }),
      [LINE_A],
      r.vchNo,
      (own as any).version,
    );
    expect(await open('00008')).toBe(0);
    await deleteSale(prisma, {
      scope,
      vchNo: r.vchNo,
      deleteUser: 'clerk2',
      expectedVersion: (back as any).version,
    });
    expect(await open('00008')).toBe(3000);
    expect(await open('00007')).toBe(5000);
    expect(await adjRows(r.vchNo)).toEqual([]);
    expect(await count('SL_DATA')).toBe(0);
    expect(await audit()).toHaveLength(3);
  });
});
