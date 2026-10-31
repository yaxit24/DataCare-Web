import { PrismaClient, withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  deleteTagOpening,
  editTagOpening,
  tagOpening,
} from '../src/modules/stock/stockVoucherLifecycle.js';

/**
 * N203 / G215: the stock rows of Tag Opening and Only Tag Entry follow Ac_Stock.Tag_Opbl_Stk (Ac_Stock.cs:22-36).
 *
 * - An opening book (OPSTK, and the web's TAG OPENING) writes one purchase-in row per tag: TR_TYPE 'P', VCH_TYPE
 *   'TAGOP', BOOK_NAME 'TAG OPBL', ITM_QTY 1, with the tag's wastage, labour rate, karigar cost and design. It draws on
 *   no loose stock, even when a stock item is sent (the field is hidden for OPSTK, TR_TAG_OPBL.cs:10303-10310).
 * - An Only Tag Entry book (TAG GEN) needs the stock item ("Stock item code Insert First...", :10815); each tag is an
 *   issue-in (TR_TYPE 'I', VCH_TYPE = the book's short name, BOOK_NAME 'TAG GEN') and the stock item goes out once by
 *   the voucher's totals (TR_TYPE 'O', '-', TAG_NO 'N', SR_NO 0).
 * - A tag number typed twice is refused with "Duplicate Tag No" (:8562); deleting a voucher whose tag was sold is
 *   refused with the desktop's text (:11383).
 * The migrated desktop data agrees: 1169 opening tag rows are P/TAGOP/'TAG OPBL', and Only Tag Entry has 159 I/+ tag
 * rows with 31 O/- 'N' rows, one per voucher.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tagop-stock';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-06-01';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scopeOf = (coBook: string) => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const rows = <T = any>(sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$queryRawUnsafe(sql, ...p)) as Promise<T[]>;

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed(): Promise<void> {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF") VALUES ($1,$2,'N',2,2,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [book, name, short, family] of [
    ['000', 'Opening Stock', 'OPSTK', 'OPSTK'],
    ['TGN', 'Only Tag Entry', 'TGEN', 'TAG GEN'],
  ])
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'I','Y','BAR_DATA')`,
      TENANT,
      CO,
      LC,
      book,
      name,
      short,
      family,
    );
  for (const [code, name, type] of [
    ['GOLD', 'GOLD ORNAMENT', 'G'],
    ['LOOSE', 'GOLD LOOSE STOCK', 'G'],
  ])
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,$2,$3,$4,$5)`,
      TENANT,
      CO,
      code,
      name,
      type,
    );
}

const line = (
  tagNo: string,
  grossWt: number,
  netWt: number,
  extra: Record<string, unknown> = {},
) => ({
  tagNo,
  itCode: 'GOLD',
  pcs: 1,
  grossWt,
  netWt,
  touch: 91.6,
  westPct: 2,
  rate: 6000,
  lbrRate: 450,
  karigarCost: 1200,
  designNo: 'D-12',
  ...extra,
});
const stock = (book: string, vchNo: string) =>
  rows(
    `SELECT coalesce("SR_NO",0)::int sr, "VCH_TYPE" vt, "BOOK_NAME" bn, "IT_CODE" it, "TAG_NO" tag, "TR_TYPE" tr,
            "ITM_SIGN" sg, coalesce("ITM_QTY",0)::float qty, coalesce("ITM_PCS",0)::float pcs,
            coalesce("ITM_GWT",0)::float gwt, coalesce("ITM_NWT",0)::float nwt, coalesce("ITM_FINE",0)::float fine,
            coalesce("ITM_WEST",0)::float west, coalesce("LBR_RATE",0)::float lrate, coalesce("KR_COST",0)::float krcost,
            coalesce("DESIGN_NO",'') design
       FROM "MAIN_STOCK" WHERE "CO_BOOK"=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO","TAG_NO"`,
    book,
    vchNo,
  );

describe.skipIf(!RUN)('Tag Opening and Only Tag Entry stock rows (Ac_Stock.Tag_Opbl_Stk)', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('an opening book writes one P/TAGOP/TAG OPBL row per tag and draws on no loose stock', async () => {
    const saved = await tagOpening(runtime, {
      scope: scopeOf('000'),
      mainUser: 'ADMIN',
      vchDate: DAY,
      stockItCode: 'LOOSE',
      lines: [line('T-1', 10.5, 10), line('T-2', 5.25, 5)],
    });
    const vchNo = String(saved.vchNo).padStart(5, '0');
    const posted = await stock('000', vchNo);
    expect(
      posted.map((r) => [r.sr, r.vt, r.bn, r.it, r.tag, r.tr, r.sg, r.qty, r.gwt, r.nwt]),
    ).toEqual([
      [1, 'TAGOP', 'TAG OPBL', 'GOLD', 'T-1', 'P', '+', 1, 10.5, 10],
      [2, 'TAGOP', 'TAG OPBL', 'GOLD', 'T-2', 'P', '+', 1, 5.25, 5],
    ]);
    // Fine = (net + ghat) × (touch + wastage) / 100 (TR_TAG_OPBL.cs:6590): 10 × 93.6 / 100 = 9.36. The row keeps the tag's
    // wastage, labour rate, karigar
    // cost and design, as Tag_Opbl_Stk copies them from BAR_DETL.
    expect(posted.map((r) => [r.fine, r.west, r.lrate, r.krcost, r.design])).toEqual([
      [9.36, 2, 450, 1200, 'D-12'],
      [4.68, 2, 450, 1200, 'D-12'],
    ]);
    const [header] = await rows(
      `SELECT "STK_IT_CODE" stk FROM "BAR_DATA" WHERE "CO_BOOK"='000' AND "VCH_NO"=$1`,
      vchNo,
    );
    expect(header.stk).toBeNull();
  });

  it('Only Tag Entry needs the stock item, then writes I rows and one O row for the stock item', async () => {
    await expect(
      tagOpening(runtime, { scope: scopeOf('TGN'), vchDate: DAY, lines: [line('G-1', 10.5, 10)] }),
    ).rejects.toThrow('Stock item code Insert First...');
    expect(await rows(`SELECT 1 FROM "BAR_DATA"`)).toHaveLength(0);
    const saved = await tagOpening(runtime, {
      scope: scopeOf('TGN'),
      mainUser: 'ADMIN',
      vchDate: DAY,
      stockItCode: 'LOOSE',
      lines: [line('G-1', 10.5, 10), line('G-2', 5.25, 5)],
    });
    const vchNo = String(saved.vchNo).padStart(5, '0');
    const posted = await stock('TGN', vchNo);
    expect(
      posted.map((r) => [
        r.sr,
        r.vt,
        r.bn,
        r.it,
        r.tag,
        r.tr,
        r.sg,
        r.qty,
        r.pcs,
        r.gwt,
        r.nwt,
        r.fine,
      ]),
    ).toEqual([
      [0, 'TGEN', 'TAG GEN', 'LOOSE', 'N', 'O', '-', 1, 2, 15.75, 15, 14.04],
      [1, 'TGEN', 'TAG GEN', 'GOLD', 'G-1', 'I', '+', 1, 1, 10.5, 10, 9.36],
      [2, 'TGEN', 'TAG GEN', 'GOLD', 'G-2', 'I', '+', 1, 1, 5.25, 5, 4.68],
    ]);
    const [header] = await rows(
      `SELECT "STK_IT_CODE" stk FROM "BAR_DATA" WHERE "CO_BOOK"='TGN' AND "VCH_NO"=$1`,
      vchNo,
    );
    expect(header.stk).toBe('LOOSE');
    // An edit rewrites the rows the same way: one tag left, so the stock item goes out by that tag alone.
    await editTagOpening(
      runtime,
      { scope: scopeOf('TGN'), vchDate: DAY, stockItCode: 'LOOSE', lines: [line('G-1', 10.5, 10)] },
      vchNo,
    );
    expect((await stock('TGN', vchNo)).map((r) => [r.tr, r.it, r.gwt, r.fine])).toEqual([
      ['O', 'LOOSE', 10.5, 9.36],
      ['I', 'GOLD', 10.5, 9.36],
    ]);
  });

  it('refuses a tag number typed twice with the desktop message', async () => {
    await expect(
      tagOpening(runtime, {
        scope: scopeOf('000'),
        vchDate: DAY,
        lines: [line('DUP', 1, 1), line('DUP', 2, 2)],
      }),
    ).rejects.toThrow('Duplicate Tag No');
  });

  it('refuses to delete a voucher whose tag was sold, with the desktop message', async () => {
    const saved = await tagOpening(runtime, {
      scope: scopeOf('000'),
      vchDate: DAY,
      lines: [line('SOLD-1', 10.5, 10)],
    });
    const vchNo = String(saved.vchNo).padStart(5, '0');
    const [tag] = await rows(`SELECT "VCH_SRNO" srno FROM "BAR_DETL" WHERE "TAG_NO"='SOLD-1'`);
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,$2,$3,$4,'SL','00001',1,'2024-06-02'::date,'GOLD','SOLD-1',$5,'S','-',1,10.5,10)`,
      TENANT,
      CO,
      LC,
      YEAR,
      tag.srno,
    );
    await expect(deleteTagOpening(runtime, { scope: scopeOf('000'), vchNo })).rejects.toThrow(
      'You Cant Delete This Voucher Because  Tag Use in Sales Transection....',
    );
    expect(await stock('000', vchNo)).toHaveLength(1);
  });
});
