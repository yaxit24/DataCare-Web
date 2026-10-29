import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createFineSalePurchase,
  getFineSalePurchase,
  editFineSalePurchase,
  deleteFineSalePurchase,
} from '../src/modules/bullion/fineSalePurchase.js';

/**
 * Fine Sale edit lifecycle (N147, G156).
 *
 * `createFineSalePurchase` could create, `getFineSalePurchase` could reopen (N121) and
 * `deleteFineSalePurchase` could reverse, but there was no editFineSalePurchase. This proves a fine
 * sale can be created, reopened into its input shape, EDITED (a line changed, so the metal/net/ledger
 * and the MAIN_STOCK fine custody re-derive with no orphan CUT_DETL/MAIN_STOCK rows), reopened again
 * to see the change, and deleted — all keeping the same voucher number.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'fine-sale-edit';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = 'FSL';
const PARTY = 'WALKIN';
const FINESALE = 'FINESALE';
const GST = 'GST';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows)
    await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed() {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF","ALL_ROF_REMOVE","RATE_PAR")
     VALUES ($1,$2,'N',2,2,2,'N','G')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name, gst] of [
    [PARTY, 'WALK-IN', 'L'],
    [FINESALE, 'FINE METAL SALE', 'L'],
    [GST, 'GST OUTPUT', 'L'],
  ]) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES ($1,$2,$3,$4,$5,$6)`,
      TENANT,
      CO,
      LC,
      code,
      name,
      gst,
    );
  }
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,'FSL','Fine Sale','FSL','FINE SALE','O','Y','CUT_DATA')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,'FSL',1,$4,'Fine Sale','FINE SALE','O')`,
    TENANT,
    CO,
    LC,
    FINESALE,
  );
}

const line = (fineWt: number, fineRate: number) => ({ fineWt, fineRate });

async function detlCount(vchNo: string): Promise<number> {
  const r = (await owner.$queryRawUnsafe(
    `SELECT count(*)::int n FROM "CUT_DETL" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
    TENANT,
    vchNo,
  )) as { n: number }[];
  return r[0]!.n;
}
async function stockFine(vchNo: string): Promise<number> {
  const r = (await owner.$queryRawUnsafe(
    `SELECT coalesce(sum("ITM_FINE"),0)::float f FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "VCH_NO"=$2`,
    TENANT,
    vchNo,
  )) as { f: number }[];
  return r[0]!.f;
}

describe.runIf(RUN)('fine sale edit lifecycle', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('creates, reopens, edits (same vchNo, re-derived stock) and deletes', async () => {
    const created = await createFineSalePurchase(runtime, {
      scope,
      side: 'SALE',
      partyAc: PARTY,
      itType: 'G',
      taxPct: 0,
      lines: [line(10, 6000), line(5, 6000)],
    } as never);
    const no = String(created.vchNo).padStart(5, '0');
    expect(created.totals.fine).toBeCloseTo(15, 3);
    expect(await detlCount(no)).toBe(2);
    // Sale fine custody magnitude (ITM_FINE is unsigned; ITM_SIGN carries direction).
    expect(await stockFine(no)).toBeCloseTo(15, 3);

    const reopened = await getFineSalePurchase(runtime, scope, created.vchNo);
    expect(reopened).toBeTruthy();
    expect(reopened!.side).toBe('SALE');
    expect(reopened!.partyAc).toBe(PARTY);
    expect(reopened!.lines).toHaveLength(2);

    // Edit: drop the second line and change the first — same voucher number.
    const edited = await editFineSalePurchase(
      runtime,
      {
        scope,
        side: 'SALE',
        partyAc: PARTY,
        itType: 'G',
        taxPct: 0,
        lines: [line(8, 6000)],
      } as never,
      created.vchNo,
    );
    expect(edited.vchNo).toBe(created.vchNo);
    expect(edited.totals.fine).toBeCloseTo(8, 3);

    const after = await getFineSalePurchase(runtime, scope, created.vchNo);
    expect(after!.lines).toHaveLength(1);
    // The old 2-line CUT_DETL and its stock are gone, replaced by the 1-line edit.
    expect(await detlCount(no)).toBe(1);
    expect(await stockFine(no)).toBeCloseTo(8, 3);

    await deleteFineSalePurchase(runtime, { scope, vchNo: created.vchNo, side: 'SALE' });
    expect(await detlCount(no)).toBe(0);
    expect(await stockFine(no)).toBeCloseTo(0, 3);
  });
});
