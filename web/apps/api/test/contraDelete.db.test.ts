/**
 * Contra deletion reverses the whole voucher, including the day book.
 *
 * PLAN ITEM F1.1 — see FUNCTIONAL-PARITY-PLAN-2026-08-02.md
 *
 * WHY THIS WORKFLOW MATTERS
 * =========================
 * Delete-and-re-enter is how this business corrects a voucher. Measured on the real database:
 *
 *     SELECT count(*) FROM USER_DATA;    -- 0    the per-column EDIT audit: never used in the year
 *     SELECT count(*) FROM DELETE_DATA;  -- 72   across 17 voucher families
 *
 * CONTRA is the fourth most-deleted family, with 6 real deletions. Until now `POST /contra` had no reversal
 * at all, so a wrong contra could be created and never undone.
 *
 * WHY THE DAY-BOOK ASSERTION IS THE POINT
 * =======================================
 * The desktop carries **74 contra rows in ROJ_MEL_DATA**. The Rojmel is the combined metal-and-money day book
 * the shop reads every evening. A delete that removes the header and the ledger legs but leaves the Rojmel
 * rows behind produces a day book that no longer reconciles with the ledger — and nothing would surface it,
 * because both halves individually look consistent. So this test asserts the day book specifically, not just
 * that the voucher "went away".
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
// deleteContra is what DELETE /contra/:vchNo calls, so the test exercises the route's real path.
import { postContra, deleteContra } from '../src/modules/finance/finance.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'contra-delete';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = '017'; // desktop book 017 "JV", MAIN_BOOK 'CONTRA' — 37 real vouchers, 74 Rojmel rows

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx: any) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  );
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seed() {
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Contra Delete Co')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,'Main')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  // CASH_LIMIT 0 is what every real installation ships; see settingsRealValues.test.ts.
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","CASH_LIMIT","FINE_STK_TYPE") VALUES ($1,$2,0,'F')`,
    TENANT,
    CO,
  );
  await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
  for (const [code, name] of [
    ['00001', 'CASH ON HAND'],
    ['00008', 'BANK A/C'],
  ]) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
    );
  }
  // BOOK_SNAME is the VCH_TYPE — verified on 39 of 40 real books.
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Journal Voucher','JV','CONTRA','I','Y','CONTRA_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
}

const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };

/** Row counts for the contra write set: ['CONTRA_DATA','AC_DATA','ROJ_MEL_DATA'] (journal.ts:50). */
async function footprint(vchNo: string) {
  const out: Record<string, number> = {};
  for (const table of ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA', 'TEMP_BOOK_DATA']) {
    const rows: Array<{ n: bigint }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "${table}" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
      TENANT,
      CO,
      BOOK,
      vchNo,
    );
    out[table] = Number(rows[0]?.n ?? 0);
  }
  return out;
}

describe.runIf(RUN)('contra deletion (plan F1.1)', () => {
  beforeAll(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('reverses the header, the ledger legs AND the day-book rows', async () => {
    const created = await postContra(runtime, {
      scope,
      vchDate: '2024-04-10',
      // Contra is a bank<->cash transfer: row 1 DR the receiving account, row 2 CR the giver.
      lines: [
        { crdr: 'DR', acCode: '00008', amount: 5000 },
        { crdr: 'CR', acCode: '00001', amount: 5000 },
      ],
      mainUser: 'contra-del',
    } as never);

    const vchNo = String(created.vchNo).padStart(5, '0');
    const before = await footprint(vchNo);
    // A contra must exist and must be balanced across at least two ledger legs before deletion means anything.
    expect(before.CONTRA_DATA).toBeGreaterThan(0);
    expect(before.AC_DATA).toBeGreaterThanOrEqual(2);
    // Guard against a vacuous post-delete assertion: there must be day-book rows to clear.
    expect(before.ROJ_MEL_DATA, 'contra must project into the day book').toBeGreaterThan(0);

    await deleteContra(runtime, { scope, vchNo, deleteUser: 'contra-del' });

    const after = await footprint(vchNo);
    expect(after.CONTRA_DATA, 'header must be gone').toBe(0);
    expect(after.AC_DATA, 'ledger legs must be gone').toBe(0);
    // Load-bearing since F3.3: the guard below proves rows existed before the delete, so 0 here means the
    // reversal actually cleared the day book rather than there having been nothing to clear.
    expect(after.ROJ_MEL_DATA, 'day-book rows must be gone').toBe(0);
  });

  /**
   * F3.3 — the day-book projection, now implemented.
   *
   * The desktop writes **74 CONTRA rows in ROJ_MEL_DATA — exactly two per voucher across 37 vouchers**:
   *     type `01`  Cr leg   37 of 37 carry only CR_AMT
   *     type `02`  Dr leg   37 of 37 carry only DR_AMT
   *     both IT_TYPE 'A' (money), SIGN blank, LEDR_KEY 33 chars
   * Each row names the other side in LD_CODE. This test pins that shape, not merely a row count.
   *
   * The gap was found by adding a vacuity guard to the delete test above: asserting "0 day-book rows after
   * deletion" passed, and the guard asked whether there had been any to begin with. There had not.
   */
  it('projects a contra into two day-book rows, one per ledger leg', async () => {
    const created = await postContra(runtime, {
      scope,
      vchDate: '2024-04-14',
      // Contra is a bank<->cash transfer: row 1 DR the receiving account, row 2 CR the giver.
      lines: [
        { crdr: 'DR', acCode: '00008', amount: 3300 },
        { crdr: 'CR', acCode: '00001', amount: 3300 },
      ],
      mainUser: 'contra-del',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');
    const f = await footprint(vchNo);

    // The voucher itself posts correctly: header plus balanced ledger legs.
    expect(f.CONTRA_DATA).toBeGreaterThan(0);
    expect(f.AC_DATA).toBeGreaterThanOrEqual(2);
    // Two day-book rows, matching the desktop's 2-per-voucher across all 37 real contra vouchers.
    expect(f.ROJ_MEL_DATA, 'desktop writes exactly two contra day-book rows').toBe(2);

    const rows: Array<Record<string, unknown>> = await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","IT_TYPE","SIGN",
              COALESCE("DR_AMT",0)::float8 AS dr, COALESCE("CR_AMT",0)::float8 AS cr
         FROM "ROJ_MEL_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4
        ORDER BY "LEDR_KEY"`,
      TENANT,
      CO,
      BOOK,
      vchNo,
    );
    expect(rows).toHaveLength(2);

    const [cr, dr] = rows;
    // Row-type code sits at LEDR_KEY offset 22 (1-based); 01 is the Cr leg, 02 the Dr leg.
    expect(String(cr!.LEDR_KEY).slice(21, 23)).toBe('01');
    expect(String(dr!.LEDR_KEY).slice(21, 23)).toBe('02');
    // 33 characters: head(21) + type(2) + SR_NO right-aligned in 10.
    expect(String(cr!.LEDR_KEY)).toHaveLength(33);
    expect(String(dr!.LEDR_KEY)).toHaveLength(33);

    // A contra carries no metal: money rows only, no direction.
    for (const r of rows) {
      expect(String(r.IT_TYPE)).toBe('A');
      expect(String(r.SIGN ?? '').trim()).toBe('');
    }

    // Each row names the OTHER side in LD_CODE, and the amounts sit on opposite sides.
    expect(Number(cr!.cr)).toBeCloseTo(3300, 2);
    expect(Number(cr!.dr)).toBe(0);
    expect(Number(dr!.dr)).toBeCloseTo(3300, 2);
    expect(Number(dr!.cr)).toBe(0);
    expect(String(cr!.AC_CODE).trim()).toBe('00001'); // fromAc — money leaves here
    expect(String(cr!.LD_CODE).trim()).toBe('00008');
    expect(String(dr!.AC_CODE).trim()).toBe('00008'); // toAc — money arrives here
    expect(String(dr!.LD_CODE).trim()).toBe('00001');
  });

  it('records the deletion in DELETE_DATA, as the desktop does', async () => {
    const created = await postContra(runtime, {
      scope,
      vchDate: '2024-04-11',
      // Contra is a bank<->cash transfer: row 1 DR the receiving account, row 2 CR the giver.
      lines: [
        { crdr: 'DR', acCode: '00008', amount: 1200 },
        { crdr: 'CR', acCode: '00001', amount: 1200 },
      ],
      mainUser: 'contra-del',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');
    await deleteContra(runtime, { scope, vchNo, deleteUser: 'contra-del' });

    const audit: Array<{ n: number }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "DELETE_DATA"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
      TENANT,
      CO,
      BOOK,
      vchNo,
    );
    // The desktop wrote 72 DELETE_DATA rows in the year, 6 of them contra: a deletion is auditable, never silent.
    expect(Number(audit[0]?.n ?? 0)).toBeGreaterThan(0);
  });

  it('leaves an unrelated contra voucher untouched', async () => {
    const keep = await postContra(runtime, {
      scope,
      vchDate: '2024-04-12',
      // Contra is a bank<->cash transfer: row 1 DR the receiving account, row 2 CR the giver.
      lines: [
        { crdr: 'DR', acCode: '00008', amount: 700 },
        { crdr: 'CR', acCode: '00001', amount: 700 },
      ],
      mainUser: 'contra-del',
    } as never);
    const drop = await postContra(runtime, {
      scope,
      vchDate: '2024-04-13',
      // Contra is a bank<->cash transfer: row 1 DR the receiving account, row 2 CR the giver.
      lines: [
        { crdr: 'DR', acCode: '00008', amount: 900 },
        { crdr: 'CR', acCode: '00001', amount: 900 },
      ],
      mainUser: 'contra-del',
    } as never);

    const keepNo = String(keep.vchNo).padStart(5, '0');
    const dropNo = String(drop.vchNo).padStart(5, '0');
    const keptBefore = await footprint(keepNo);

    await deleteContra(runtime, { scope, vchNo: dropNo, deleteUser: 'contra-del' });

    expect(await footprint(keepNo)).toEqual(keptBefore);
    expect((await footprint(dropNo)).CONTRA_DATA).toBe(0);
  });
});
