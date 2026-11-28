import { deleteStrayPurchase } from '../src/modules/purchase/strayLink.js';
import type { FastifyInstance } from 'fastify';
import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { createSale, deleteSale, editSale } from '../src/modules/sales/sales.js';
import {
  linkedOldPurchaseHook,
  linkedOldPurchaseRequest,
  type LinkedOldPurchaseRequest,
  type PurchaseRightCheck,
} from '../src/modules/sales/linkedOldPurchaseSale.js';
import { deletePurchase, editPurchase, getPurchase } from '../src/modules/purchase/purchase.js';
import { formatVoucherNo as fmt } from '../src/modules/vouchers/numbering.js';
import { tenantTables } from './support/tenantSnapshot.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Owner decision 2B, PR2: a tax-invoice sale writes its linked old-gold (URD) purchase in the same transaction.
 * Desktop: TR_SALE.cs:18756-18842 (rows 9/10 open TR_PURC on 043/044), TR_PURC.cs:13724-13740 (party 00045 → 00050,
 * tSlBill), :13283-13312 (BILL_OS, TOT_AMT for 00050, net weight back), TR_SALE.cs:15064-15091 (OLD_GL_AMT/OLD_GL,
 * CASH_AMT gross-up), :19150/:19155 (BILL_OS), :16159-16175 (delete cascade); Ac_Rojmel.cs:156 (no purchase party row).
 * Synthetic fixtures only.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const CO = '01';
const LC = '01';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const GOLD_MISSING =
  "Create a Gold URD Purchase book in Books / Series (code 043 or a name starting 'Gold URD'), or choose one in Settings";

const LINE = {
  itCode: 'OGS22',
  pcs: 1,
  grossWt: 10,
  netWt: 10,
  touch: 91.6,
  rate: 6123.45,
  labourType: 'per_gram' as const,
  labourRate: 237.5,
};
const goldPurchase = (amount = 20000, over: Record<string, unknown> = {}) => ({
  acCode: 'IGNORED',
  vchDate: '2001-01-01',
  taxRatePct: 0,
  interState: false,
  lines: [
    { itCode: 'OLDG', pcs: 1, grossWt: 5.2, netWt: 5, touch: 90, metalAmount: amount, metal: 'G' },
  ],
  ...over,
});
const silverPurchase = (amount = 3000) => ({
  taxRatePct: 0,
  interState: false,
  lines: [
    { itCode: 'OLDS', pcs: 1, grossWt: 50, netWt: 48, touch: 80, metalAmount: amount, metal: 'S' },
  ],
});

const PURCHASE_TABLES = [
  'PR_DATA',
  'PR_DETL',
  'PR_IDTL',
  'MAIN_STOCK',
  'AC_DATA',
  'TAX_DATA',
  'ROJ_MEL_DATA',
  'TEMP_BOOK_DATA',
];

/** Seed a company with a T sale book SL, an M sale book EST, URD books 043/044 and synthetic parties and items. */
async function seedLinked(owner: PrismaClient, runtime: PrismaClient, tenant: string) {
  await seedCompany(runtime, tenant, CO, { coName: 'OG2', lcCode: LC });
  const copyBook = async (from: string, to: string, set: Record<string, string>) => {
    for (const table of ['BOOK_DATA', 'BOOK_DETL']) {
      const cols: string[] = (
        await owner.$queryRawUnsafe<Array<{ c: string }>>(
          `SELECT column_name c FROM information_schema.columns
            WHERE table_schema='public' AND table_name=$1 AND column_name<>'row_id' ORDER BY ordinal_position`,
          table,
        )
      ).map((r) => r.c);
      const select = cols
        .map((c) =>
          c === 'CO_BOOK' ? '$3' : table === 'BOOK_DATA' && c in set ? `'${set[c]}'` : `"${c}"`,
        )
        .join(',');
      await owner.$executeRawUnsafe(
        `INSERT INTO "${table}"(${cols.map((c) => `"${c}"`).join(',')})
         SELECT ${select} FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
        tenant,
        from,
        to,
      );
    }
  };
  await copyBook('PR', '043', { BOOK_NAME: 'Gold URD Purchase', BOOK_SNAME: 'GLURD' });
  await copyBook('PR', '044', { BOOK_NAME: 'Silver URD Purchase', BOOK_SNAME: 'SLURD' });
  await copyBook('SL', 'EST', { BOOK_NAME: 'Estimate', BOOK_TYPE: 'M' });
  await withTenant(runtime, tenant, async (tx: any) => {
    await tx.$executeRawUnsafe(
      `UPDATE "CO_SET_NEW" SET "TOT_AMT_ROF"=2 WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenant,
      CO,
    );
    await tx.$executeRawUnsafe(
      `UPDATE "CO_SET" SET "TAX_ROF"=NULL,"LBR_ROF"=NULL,"ITM_RATE_ROF"=NULL,"CASH_LIMIT"=NULL,"LOCK_DATE"=NULL
        WHERE tenant_id=$1 AND "CO_CODE"=$2`,
      tenant,
      CO,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,$2,$3,'OGCUST','Synthetic Old Gold Buyer','L','20'),
              ($1,$2,$3,'00045','SYNTHETIC CASH SALES','L','20'),
              ($1,$2,$3,'00050','SYNTHETIC CASH PURCHASE','L','20')`,
      tenant,
      CO,
      LC,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,$2,'OG1','Synthetic Gold','SALES','PURCHASE'),($1,$2,'OS1','Synthetic Silver','SALES','PURCHASE')`,
      tenant,
      CO,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'OGS22','Synthetic Gold 22','G','OG1'),($1,$2,'OLDG','Synthetic Old Gold','G','OG1'),
              ($1,$2,'OLDS','Synthetic Old Silver','S','OS1')`,
      tenant,
      CO,
    );
  });
}

d('Sale with a linked old-gold purchase (owner decision 2B, PR2)', () => {
  const TENANT = 'og2-linked-sale';
  const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'SL' };
  const prisma = new PrismaClient();
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  const allow: PurchaseRightCheck = async () => {};
  const rows = (sql: string, ...p: unknown[]): Promise<any[]> =>
    owner.$queryRawUnsafe(sql.replaceAll('$T', `'${TENANT}'`), ...p);
  const sale = (over: Record<string, unknown> = {}) =>
    ({
      scope,
      mainUser: 'og2clerk',
      acCode: 'OGCUST',
      acName: 'Synthetic Old Gold Buyer',
      vchDate: DAY,
      taxRatePct: 3,
      taxCode: '10',
      interState: false,
      ...over,
    }) as any;
  const create = (input: any, request?: LinkedOldPurchaseRequest, authorize = allow) =>
    createSale(
      prisma,
      input,
      [LINE],
      linkedOldPurchaseHook(input, request, authorize),
    ) as Promise<any>;
  const edit = (
    vchNo: number,
    version: string,
    input: any,
    request?: LinkedOldPurchaseRequest,
    authorize = allow,
  ) =>
    editSale(
      prisma,
      input,
      [LINE],
      vchNo,
      version,
      linkedOldPurchaseHook(input, request, authorize),
    ) as Promise<any>;
  const header = async (vchNo: number, book = 'SL') =>
    (
      await rows(
        `SELECT "TOT_AMT"::float tot,"BILL_OS"::float os,"CASH_AMT"::float cash,"OLD_GL_AMT"::float gl_amt,
                "OLD_GL"::float gl,"OLD_SL_AMT"::float sl_amt,"OLD_SL"::float sl
           FROM "SL_DATA" WHERE tenant_id=$T AND "CO_BOOK"=$1 AND "VCH_NO"=$2`,
        book,
        fmt(vchNo),
      )
    )[0];
  const purchases = (book: string) =>
    rows(
      `SELECT "VCH_NO","AC_CODE","AC_NAME","VCH_DATE"::text dt,"SL_BILL_NO","SL_BILL_LC","SL_BILL_YRCD",
              "SL_BILL_DBCD","BILL_OS"::float os,"TOT_AMT"::float tot
         FROM "PR_DATA" WHERE tenant_id=$T AND "CO_BOOK"=$1 ORDER BY "VCH_NO"`,
      book,
    );
  const count = async (table: string, book: string) =>
    (
      await rows(`SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$T AND "CO_BOOK"=$1`, book)
    )[0].n as number;
  const partyNet = async (ac: string) =>
    (
      await rows(
        `SELECT coalesce(sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)),0)::float n FROM "AC_DATA"
          WHERE tenant_id=$T AND btrim("AC_CODE")=$1 AND coalesce("FINE_WT",0)=0`,
        ac,
      )
    )[0].n as number;

  const clean = async () => {
    for (const t of await tenantTables(owner))
      await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id = $1`, TENANT);
  };
  beforeAll(clean);
  beforeEach(async () => {
    await clean();
    await seedLinked(owner, prisma, TENANT);
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
    await owner.$disconnect();
  });

  it('writes the gold purchase under the sale key and takes OLD_GL_AMT / OLD_GL from the stored purchase', async () => {
    const saved = await create(sale({ cashAmt: 10000 }), { gold: goldPurchase() as any });
    const no = fmt(saved.vchNo);
    const [pr] = await purchases('043');
    expect(pr).toMatchObject({
      AC_CODE: 'OGCUST',
      AC_NAME: 'Synthetic Old Gold Buyer',
      dt: DAY,
      SL_BILL_NO: no,
      SL_BILL_LC: LC,
      SL_BILL_YRCD: YEAR,
      SL_BILL_DBCD: 'SL',
    });
    expect(pr.os).toBeGreaterThan(0);
    const detl = await rows(
      `SELECT DISTINCT "SL_BILL_NO","SL_BILL_LC","SL_BILL_YRCD","SL_BILL_DBCD" FROM "PR_DETL"
        WHERE tenant_id=$T AND "CO_BOOK"='043'`,
    );
    expect(detl).toEqual([
      { SL_BILL_NO: no, SL_BILL_LC: LC, SL_BILL_YRCD: YEAR, SL_BILL_DBCD: 'SL' },
    ]);
    const h = await header(saved.vchNo);
    expect(h.gl_amt).toBe(pr.os);
    expect(h.gl).toBe(5);
    expect(h.sl_amt).toBe(0);
    expect(h.os).toBeCloseTo(h.tot - 10000 - pr.os, 2);
    expect(h.cash).toBe(10000); // a named party: no gross-up
    expect(saved.linkedOldPurchases).toEqual([
      expect.objectContaining({
        metal: 'G',
        coBook: '043',
        amount: pr.os,
        netWt: 5,
        created: true,
      }),
    ]);
    // The purchase's own ledger settles the party; the sale has no old-gold leg and the purchase no rojmel party row.
    expect(await count('AC_DATA', '043')).toBeGreaterThan(0);
    expect(
      (
        await rows(
          `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$T AND "CO_BOOK"='SL' AND btrim("AC_CODE")='PURCHASE'`,
        )
      )[0].n,
    ).toBe(0);
    expect(
      (
        await rows(
          `SELECT count(*)::int n FROM "ROJ_MEL_DATA" WHERE tenant_id=$T AND "CO_BOOK"='043' AND btrim("AC_CODE")='OGCUST'`,
        )
      )[0].n,
    ).toBe(0);
    expect(await partyNet('OGCUST')).toBeCloseTo(h.os, 2);
  });

  it('writes gold and silver purchases in their own URD books', async () => {
    const saved = await create(sale({ cashAmt: 5000 }), {
      gold: goldPurchase() as any,
      silver: silverPurchase() as any,
    });
    const [gold] = await purchases('043');
    const [silver] = await purchases('044');
    expect(silver.SL_BILL_NO).toBe(fmt(saved.vchNo));
    const h = await header(saved.vchNo);
    expect(h.gl_amt).toBe(gold.os);
    expect(h.sl_amt).toBe(silver.os);
    expect(h.sl).toBe(48);
    expect(h.os).toBeCloseTo(h.tot - 5000 - gold.os - silver.os, 2);
    expect(await partyNet('OGCUST')).toBeCloseTo(h.os, 2);
  });

  const cashOf = async (book: string, vchNo: string) =>
    (
      await rows(
        `SELECT coalesce(sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)),0)::float n FROM "AC_DATA"
          WHERE tenant_id=$T AND "CO_BOOK"=$1 AND "VCH_NO"=$2 AND btrim("AC_CODE")='CASH'`,
        book,
        vchNo,
      )
    )[0].n as number;
  const walkIn = (over: Record<string, unknown> = {}) =>
    sale({ acCode: '00045', acName: 'Walk In', ...over });

  it('cash party 00045: the purchase is booked on 00050, pays itself in cash, and CASH_AMT is grossed up', async () => {
    const probe = await create(walkIn({ cashAmt: 1 }));
    const total = (await header(probe.vchNo)).tot;
    const cash = Math.round(total - 3000); // TR_SALE.cs:19125-19150: Round(TOT − old − adv − kasar − UPI, 0)
    // The purchase is sent without any cash: the server sets it (TR_PURC.cs:15087-15090).
    const saved = await create(walkIn({ cashAmt: cash }), { gold: goldPurchase(3000) as any });
    const [pr] = await purchases('043');
    expect(pr.AC_CODE).toBe('00050');
    expect(pr.os).toBe(0);
    const stored = await rows(
      `SELECT "CASH_AMT"::float c FROM "PR_DATA" WHERE tenant_id=$T AND "CO_BOOK"='043' AND "VCH_NO"=$1`,
      pr.VCH_NO,
    );
    expect(stored[0].c).toBe(3000);
    expect(await cashOf('043', pr.VCH_NO)).toBe(-3000); // the purchase credits cash 3000
    expect(await partyNet('00050')).toBeCloseTo(0, 2);
    const h = await header(saved.vchNo);
    expect(h.gl_amt).toBe(pr.tot); // TOT_AMT for 00050 (TR_PURC.cs:13285)
    expect(h.os).toBeCloseTo(total - cash - pr.tot, 2);
    // old (3000) < cash → CASH_AMT = Math.Round(cash + old, 0) (TR_SALE.cs:15071-15080), posted on the cash leg.
    expect(h.cash).toBe(Math.round(cash + 3000));
    expect(await cashOf('SL', fmt(saved.vchNo))).toBe(Math.round(cash + 3000));
    // The cash book nets to the cash the customer actually paid.
    expect((await cashOf('SL', fmt(saved.vchNo))) + (await cashOf('043', pr.VCH_NO))).toBe(cash);
  });

  it('cash party 00045: any other cash or cash paid is refused with the expected figure', async () => {
    const probe = await create(walkIn({ cashAmt: 1 }));
    const total = (await header(probe.vchNo)).tot;
    const cash = Math.round(total - 3000);
    await expect(
      create(walkIn({ cashAmt: cash + 50 }), { gold: goldPurchase(3000) as any }),
    ).rejects.toThrow(`the cash must be ${cash.toFixed(2)} and cash paid 0.00`);
    // Old metal above the bill: no cash, the difference is paid back (TR_SALE.cs:19127-19138).
    const big = Math.round((total + 500) * 100) / 100;
    const paid = 500;
    await expect(
      create(walkIn({ cashAmt: 0 }), { gold: goldPurchase(big) as any }),
    ).rejects.toThrow(`cash must be 0.00 and cash paid ${paid.toFixed(2)}`);
    await expect(
      create(walkIn({ cashAmt: 0, cashPaid: paid }), {
        gold: goldPurchase(big, { chequeAmt: 10 }) as any,
      }),
    ).rejects.toThrow(/paid in cash only/);
    const saved = await create(walkIn({ cashAmt: 0, cashPaid: paid }), {
      gold: goldPurchase(big) as any,
    });
    const h = await header(saved.vchNo);
    expect(h.os).toBeCloseTo(0, 2);
    const party = await rows(
      `SELECT coalesce(sum(coalesce("DR_AMT",0)-coalesce("CR_AMT",0)),0)::float n FROM "AC_DATA"
        WHERE tenant_id=$T AND "CO_BOOK"='SL' AND "VCH_NO"=$1 AND btrim("AC_CODE")='00045'`,
      fmt(saved.vchNo),
    );
    expect(party[0].n).toBeCloseTo(0, 2);
    expect(await count('PR_DATA', '043')).toBe(1);
  });

  it('an edit without linkedOldPurchase is refused when the party or date no longer match the purchase', async () => {
    const saved = await create(sale({ cashAmt: 1000 }), { gold: goldPurchase() as any });
    const [pr] = await purchases('043');
    await expect(
      edit(saved.vchNo, saved.version, sale({ cashAmt: 1000, vchDate: `${startYear}-06-16` })),
    ).rejects.toThrow(
      `The old gold purchase 043/${pr.VCH_NO} is on party OGCUST dated ${DAY}, but this sale now needs party OGCUST dated ${startYear}-06-16: reopen the old-gold purchase`,
    );
    await expect(edit(saved.vchNo, saved.version, walkIn({ cashAmt: 1000 }))).rejects.toThrow(
      /now needs party 00050/,
    );
    expect((await header(saved.vchNo)).gl_amt).toBe(pr.os);
  });

  it('a create on a sale number that already has a linked purchase is refused, naming it', async () => {
    const saved = await create(sale({ cashAmt: 1000 }), { gold: goldPurchase() as any });
    const [pr] = await purchases('043');
    // A leftover: the sale is gone but its purchase still carries the key (as an abandoned desktop sale leaves it).
    await owner.$executeRawUnsafe(
      `DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
      TENANT,
      fmt(saved.vchNo),
    );
    await expect(create(sale({ cashAmt: 1000 }))).rejects.toThrow(
      `Purchase 043/${pr.VCH_NO} is already linked to sale SL/${fmt(saved.vchNo)}, left by a sale that was not saved`,
    );
  });

  it.each(['PURCHASE', 'TAG PURCHASE'])(
    'stray deletion on %s refuses a live sale, checks version, and reverses the complete purchase only',
    async (mainBook) => {
      const saved = await create(sale(), { gold: goldPurchase() as any });
      const [pr] = await purchases('043');
      const sentinelSale = await create(sale(), { gold: goldPurchase(12345) as any });
      // Synthetic imported TAG PURCHASE: retain a real purchase write set and legacy SL_BILL_*.
      await owner.$executeRawUnsafe(
        `UPDATE "BOOK_DATA" SET "MAIN_BOOK"=$2 WHERE tenant_id=$1 AND "CO_BOOK"='043'`,
        TENANT,
        mainBook,
      );
      const ps = { ...scope, coBook: '043' };
      const view = await getPurchase(prisma, ps, pr.VCH_NO);
      expect(view.linkedSale).toMatchObject({ exists: true, saleBillNo: fmt(saved.vchNo) });
      const input = {
        scope: ps,
        vchNo: pr.VCH_NO,
        expectedVersion: String(view.version),
        deleteUser: 'og2clerk',
      };
      await expect(deleteStrayPurchase(prisma, input)).rejects.toThrow(
        `Linked with sale SL/${fmt(saved.vchNo)}; delete it from the sale`,
      );
      expect(await count('PR_DATA', '043')).toBe(2);
      await owner.$executeRawUnsafe(
        `DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
        TENANT,
        fmt(saved.vchNo),
      );
      expect((await getPurchase(prisma, ps, pr.VCH_NO)).linkedSale).toMatchObject({
        exists: false,
      });
      await expect(
        deleteStrayPurchase(prisma, { ...input, expectedVersion: 'stale' }),
      ).rejects.toThrow();
      expect(await count('PR_DATA', '043')).toBe(2);
      const sentinel = (await purchases('043')).find(
        (p) => p.SL_BILL_NO === fmt(sentinelSale.vchNo),
      );
      const sentinelBefore = await getPurchase(prisma, ps, sentinel.VCH_NO);
      await expect(deleteStrayPurchase(prisma, input)).resolves.toEqual({ reversed: true });
      for (const table of [
        'PR_DATA',
        'PR_DETL',
        'PR_IDTL',
        'BAR_DATA',
        'BAR_DETL',
        'BAR_IDTL',
        'SL_PR_DETL',
        'ITM_LOT_DETL',
        'MAIN_STOCK',
        'AC_DATA',
        'TAX_DATA',
        'BILL_OS_DATA',
        'ROJ_MEL_DATA',
        'DM_DATA',
        'LOT_DETL',
        'REMARK_DATA',
      ]) {
        expect(
          (
            await rows(
              `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$T AND "CO_CODE"=$1
        AND "LC_CODE"=$2 AND "CO_YEAR"=$3 AND "CO_BOOK"='043' AND "VCH_NO"=$4`,
              CO,
              LC,
              YEAR,
              pr.VCH_NO,
            )
          )[0].n,
          table,
        ).toBe(0);
      }
      expect(await getPurchase(prisma, ps, sentinel.VCH_NO)).toEqual(sentinelBefore);
      expect(
        (
          await rows(
            `SELECT count(*)::int n FROM "TEMP_BOOK_DATA" WHERE tenant_id=$T AND "CO_BOOK"='043' AND "VCH_NO"=$1`,
            view.hiddenVoucherNo,
          )
        )[0].n,
      ).toBe(0);
      expect(
        (
          await rows(
            `SELECT count(*)::int n FROM "DELETE_DATA" WHERE tenant_id=$T AND "CO_BOOK"='043' AND "VCH_NO"=$1`,
            pr.VCH_NO,
          )
        )[0].n,
      ).toBe(2);
    },
  );

  it('stray deletion leaves a CON PUR receipt reference untouched', async () => {
    const saved = await create(sale(), { gold: goldPurchase() as any });
    const [pr] = await purchases('043');
    await owner.$executeRawUnsafe(
      `DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
      TENANT,
      fmt(saved.vchNo),
    );
    await owner.$executeRawUnsafe(
      `UPDATE "BOOK_DATA" SET "MAIN_BOOK"='CON PUR' WHERE tenant_id=$1 AND "CO_BOOK"='043'`,
      TENANT,
    );
    const ps = { ...scope, coBook: '043' };
    const before = await getPurchase(prisma, ps, pr.VCH_NO);
    expect(before.linkedSale).toBeNull();
    await expect(
      deleteStrayPurchase(prisma, {
        scope: ps,
        vchNo: pr.VCH_NO,
        expectedVersion: String(before.version),
        deleteUser: 'og2clerk',
      }),
    ).rejects.toThrow('This purchase has no sale link');
    expect(await getPurchase(prisma, ps, pr.VCH_NO)).toEqual(before);
    expect(await count('DELETE_DATA', '043')).toBe(0);
  });

  it('the request parser drops the urd flag and the link fields; the server sets them', () => {
    const parsed = linkedOldPurchaseRequest(
      {
        gold: {
          ...goldPurchase(),
          urd: true,
          linkedCashParty: true,
          saleBillNo: '99999',
          coBook: 'PR',
        },
      },
      (b) => ({ ...b, scope: { coBook: b.coBook } }),
    )!;
    expect(parsed.gold).not.toHaveProperty('urd');
    expect(parsed.gold).not.toHaveProperty('linkedCashParty');
    expect(parsed.gold).not.toHaveProperty('saleBillNo');
    expect(parsed.gold).not.toHaveProperty('scope');
  });

  it('an edit changes the purchase amount and the sale follows; absent linkedOldPurchase keeps it', async () => {
    const saved = await create(sale({ cashAmt: 1000 }), { gold: goldPurchase(20000) as any });
    const [before] = await purchases('043');
    const edited = await edit(saved.vchNo, saved.version, sale({ cashAmt: 1000 }), {
      gold: goldPurchase(25000) as any,
    });
    const after = await purchases('043');
    expect(after).toHaveLength(1);
    expect(after[0].VCH_NO).toBe(before.VCH_NO);
    expect(after[0].os).toBeGreaterThan(before.os);
    let h = await header(saved.vchNo);
    expect(h.gl_amt).toBe(after[0].os);
    expect(h.os).toBeCloseTo(h.tot - 1000 - after[0].os, 2);
    expect(await partyNet('OGCUST')).toBeCloseTo(h.os, 2);
    // An older page (no linkedOldPurchase) keeps the purchase and its amount.
    await edit(saved.vchNo, edited.version, sale({ cashAmt: 2000 }));
    h = await header(saved.vchNo);
    expect(await purchases('043')).toHaveLength(1);
    expect(h.gl_amt).toBe(after[0].os);
    expect(h.os).toBeCloseTo(h.tot - 2000 - after[0].os, 2);
  });

  it('an edit without the metal deletes its purchase through the purchase delete path', async () => {
    const saved = await create(sale({ cashAmt: 1000 }), { gold: goldPurchase() as any });
    await edit(saved.vchNo, saved.version, sale({ cashAmt: 1000 }), {});
    for (const table of PURCHASE_TABLES) expect(await count(table, '043'), table).toBe(0);
    const h = await header(saved.vchNo);
    expect(h.gl_amt).toBe(0);
    expect(h.os).toBeCloseTo(h.tot - 1000, 2);
    expect(await count('DELETE_DATA', '043')).toBeGreaterThan(0);
  });

  it('deleting the sale deletes its linked purchases in every table', async () => {
    const saved = await create(sale({ cashAmt: 1000 }), {
      gold: goldPurchase() as any,
      silver: silverPurchase() as any,
    });
    await deleteSale(prisma, {
      scope,
      vchNo: saved.vchNo,
      deleteUser: 'og2clerk',
      expectedVersion: saved.version,
    });
    for (const book of ['043', '044', 'SL'])
      for (const table of [...PURCHASE_TABLES.filter((t) => !t.startsWith('PR_')), 'SL_DATA'])
        if (!(book !== 'SL' && table === 'SL_DATA'))
          expect(await count(table, book), `${book} ${table}`).toBe(0);
    for (const book of ['043', '044'])
      for (const table of ['PR_DATA', 'PR_DETL'])
        expect(await count(table, book), `${book} ${table}`).toBe(0);
    expect(await partyNet('OGCUST')).toBeCloseTo(0, 2);
  });

  it('an invalid purchase rolls back the whole sale', async () => {
    await expect(
      create(sale({ cashAmt: 1000 }), {
        gold: goldPurchase(20000, { taxRatePct: undefined }) as any,
      }),
    ).rejects.toThrow(/taxRatePct/);
    expect(await count('SL_DATA', 'SL')).toBe(0);
    expect(await count('PR_DATA', '043')).toBe(0);
    expect(await count('AC_DATA', 'SL')).toBe(0);
  });

  it('refuses the linked purchase on a non-T book, and the exchange rows beside it', async () => {
    await expect(
      create(sale({ scope: { ...scope, coBook: 'EST' }, cashAmt: 1000 }), {
        gold: goldPurchase() as any,
      }),
    ).rejects.toThrow(/only for a tax-invoice \(T\) sale book; book EST is type 'M'/);
    await expect(
      create(sale({ cashAmt: 1000, oldGold: [{ metal: 'G', netWt: 1, amount: 5000 }] }), {
        gold: goldPurchase() as any,
      }),
    ).rejects.toThrow(/linked URD purchase on a tax-invoice book/);
    expect(await count('SL_DATA', 'EST')).toBe(0);
    expect(await count('SL_DATA', 'SL')).toBe(0);
    expect(await count('PR_DATA', '043')).toBe(0);
  });

  it('without a Gold URD book the resolver refusal comes back and nothing is written', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "BOOK_DATA" SET "CUR_USE"='N' WHERE tenant_id=$1 AND "CO_BOOK"='043'`,
      TENANT,
    );
    const attempt = create(sale({ cashAmt: 1000 }), { gold: goldPurchase() as any });
    await expect(attempt).rejects.toMatchObject({ name: 'UrdBookValidationError' });
    await expect(attempt).rejects.toThrow(GOLD_MISSING);
    expect(await count('SL_DATA', 'SL')).toBe(0);
  });

  it('refuses the sale when the Purchase right check refuses', async () => {
    const deny: PurchaseRightCheck = async () => {
      throw Object.assign(new Error('no purchase right'), { name: 'LinkedPurchaseForbiddenError' });
    };
    await expect(
      create(sale({ cashAmt: 1000 }), { gold: goldPurchase() as any }, deny),
    ).rejects.toThrow('no purchase right');
    expect(await count('SL_DATA', 'SL')).toBe(0);
  });

  it('a linked purchase still cannot be edited or deleted on its own', async () => {
    const saved = await create(sale({ cashAmt: 1000 }), { gold: goldPurchase() as any });
    const [pr] = await purchases('043');
    const pscope = { ...scope, coBook: '043' };
    const stored = (await getPurchase(prisma, pscope, pr.VCH_NO)) as any;
    const refusal = `Linked with sale SL/${fmt(saved.vchNo)}; open that sale`;
    await expect(
      editPurchase(
        prisma,
        { scope: pscope, acCode: 'OGCUST', vchDate: DAY, taxRatePct: 0, interState: false } as any,
        goldPurchase(1).lines as any,
        pr.VCH_NO,
        stored.version,
      ),
    ).rejects.toThrow(refusal);
    await expect(
      deletePurchase(prisma, { scope: pscope, vchNo: pr.VCH_NO, expectedVersion: stored.version }),
    ).rejects.toThrow(refusal);
    expect(await purchases('043')).toHaveLength(1);
  });
});

d('Sale with a linked old-gold purchase through HTTP: rights, idempotency, read', () => {
  const TENANT = 'og2-linked-sale-http';
  const PASSWORD = 'Linked-Old-Gold!2026';
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const rows = (sql: string, ...p: unknown[]): Promise<any[]> =>
    owner.$queryRawUnsafe(sql, TENANT, ...p);
  const body = (over: Record<string, unknown> = {}) => ({
    coBook: 'SL',
    acCode: 'OGCUST',
    acName: 'Synthetic Old Gold Buyer',
    vchDate: DAY,
    taxRatePct: 3,
    taxCode: '10',
    interState: false,
    cashAmt: 1000,
    lines: [LINE],
    linkedOldPurchase: { gold: goldPurchase() },
    ...over,
  });
  const post = (login: string, payload: unknown, key?: string) =>
    app.inject({
      method: 'POST',
      url: '/sales',
      headers: { cookie: cookies[login]!, ...(key ? { 'idempotency-key': key } : {}) },
      payload: payload as any,
    });

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    for (const t of await tenantTables(owner))
      await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id = $1`, TENANT);
    await seedLinked(owner, runtime, TENANT);
    for (const [login, menus] of [
      ['og2both', ['Sales', 'Purchase']],
      ['og2sale', ['Sales']],
      ['og2nodelete', ['Sales', 'Purchase']],
    ] as const) {
      await owner.$executeRawUnsafe(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        TENANT,
        login,
        await hashPassword(PASSWORD),
      );
      for (const menu of menus)
        await owner.$executeRawUnsafe(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES($1,'01','01',$2,'Transaction',$3,'Y','Y','Y','Y')`,
          TENANT,
          login,
          menu,
        );
    }
    app = await buildApp({
      prisma: runtime,
      secret: 'linked-old-gold-route-test-signing-secret-32+',
      secureCookies: false,
    });
    await owner.$executeRawUnsafe(
      `UPDATE "USER_SET" SET "FRM_DELETE"='N' WHERE tenant_id=$1 AND "USER_NAME"='og2nodelete'`,
      TENANT,
    );
    for (const login of ['og2both', 'og2sale', 'og2nodelete']) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': TENANT },
        payload: { coCode: CO, lcCode: LC, coYear: YEAR, loginName: login, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookies[login] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      for (const t of await tenantTables(owner))
        await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id = $1`, TENANT);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('refuses 403 naming Purchase when the operator has only the Sales right; nothing is written', async () => {
    const response = await post('og2sale', body());
    expect(response.statusCode, response.body).toBe(403);
    expect(response.json()).toMatchObject({
      error: 'forbidden',
      form: 'Purchase/Purchase Invoice',
      action: 'create',
      message: expect.stringMatching(/Purchase create right/),
    });
    expect(
      (await rows(`SELECT count(*)::int n FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL'`))[0]
        .n,
    ).toBe(0);
    // The same operator still saves a sale without old gold.
    const plain = await post('og2sale', body({ linkedOldPurchase: undefined }));
    expect(plain.statusCode, plain.body).toBe(201);
  });

  it('a retried request with the same Idempotency-Key writes one sale and one purchase', async () => {
    const key = '2b2b2b2b-0000-4000-8000-000000000001';
    const before = (
      await rows(`SELECT count(*)::int n FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='043'`)
    )[0].n;
    const first = await post('og2both', body(), key);
    expect(first.statusCode, first.body).toBe(201);
    const replay = await post('og2both', body(), key);
    expect(replay.statusCode, replay.body).toBe(201);
    expect(replay.body).toBe(first.body);
    expect(replay.headers['idempotency-replayed']).toBe('true');
    const after = (
      await rows(`SELECT count(*)::int n FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='043'`)
    )[0].n;
    expect(after).toBe(before + 1);

    // GET returns the linked purchase in the purchase reopen view; PUT edits it through the sale.
    const vchNo = first.json().vchNo;
    // Without the Purchase view right the read carries only the link key and the amounts (no purchase view).
    const limited = await app.inject({
      method: 'GET',
      url: `/sales/${vchNo}?coBook=SL`,
      headers: { cookie: cookies.og2sale! },
    });
    expect(limited.statusCode, limited.body).toBe(200);
    expect(limited.json().linkedOldPurchases).toEqual([
      {
        metal: 'G',
        coBook: '043',
        vchNo: expect.any(String),
        amount: expect.any(Number),
        netWt: 5,
      },
    ]);
    const read = await app.inject({
      method: 'GET',
      url: `/sales/${vchNo}?coBook=SL`,
      headers: { cookie: cookies.og2both! },
    });
    expect(read.statusCode, read.body).toBe(200);
    const sale = read.json();
    expect(sale.linkedOldPurchases).toHaveLength(1);
    expect(sale.linkedOldPurchases[0]).toMatchObject({ metal: 'G', coBook: '043' });
    expect(sale.linkedOldPurchases[0].purchase.lines).toHaveLength(1);
    const put = await app.inject({
      method: 'PUT',
      url: `/sales/${vchNo}`,
      headers: { cookie: cookies.og2both! },
      payload: {
        ...body({ linkedOldPurchase: { gold: goldPurchase(22000) } }),
        expectedVersion: sale.version,
      },
    });
    expect(put.statusCode, put.body).toBe(200);
    expect(put.json().linkedOldPurchases).toEqual([
      expect.objectContaining({ metal: 'G', coBook: '043', created: false }),
    ]);
  });

  it('stray-link route enforces Purchase delete rights, schema and live-sale refusal', async () => {
    const created = await post('og2both', body());
    expect(created.statusCode, created.body).toBe(201);
    const [pr] = await rows(
      `SELECT "VCH_NO" FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='043' AND "SL_BILL_NO"=$2`,
      fmt(created.json().vchNo),
    );
    const read = await app.inject({
      method: 'GET',
      url: `/purchases/${pr.VCH_NO}?coBook=043`,
      headers: { cookie: cookies.og2both! },
    });
    expect(read.statusCode, read.body).toBe(200);
    const url = `/purchases/${pr.VCH_NO}/delete-stray-link?coBook=043&expectedVersion=${encodeURIComponent(read.json().version)}`;
    const denied = await app.inject({
      method: 'POST',
      url,
      headers: { cookie: cookies.og2nodelete! },
      payload: {},
    });
    expect(denied.statusCode, denied.body).toBe(403);
    const invalid = await app.inject({
      method: 'POST',
      url,
      headers: { cookie: cookies.og2both! },
      payload: { bypass: true },
    });
    expect(invalid.statusCode, invalid.body).toBe(400);
    const live = await app.inject({
      method: 'POST',
      url,
      headers: { cookie: cookies.og2both! },
      payload: {},
    });
    expect(live.statusCode, live.body).toBe(400);
    expect(live.json().message).toContain('; delete it from the sale');
    await owner.$executeRawUnsafe(
      `DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2`,
      TENANT,
      fmt(created.json().vchNo),
    );
    const removed = await app.inject({
      method: 'POST',
      url,
      headers: { cookie: cookies.og2both! },
      payload: {},
    });
    expect(removed.statusCode, removed.body).toBe(200);
    expect(removed.json()).toEqual({ reversed: true });
  });

  it('refuses a non-T book with 400', async () => {
    const response = await post('og2both', body({ coBook: 'EST' }));
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().message).toMatch(/only for a tax-invoice \(T\) sale book/);
  });
});
