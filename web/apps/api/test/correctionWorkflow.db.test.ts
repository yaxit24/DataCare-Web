/**
 * The correction workflow: deleting and re-entering a voucher.
 *
 * PLAN ITEMS F1.2 (scheme) and F1.3 (single receipt / payment) — FUNCTIONAL-PARITY-PLAN-2026-08-02.md
 *
 * WHY THESE FAMILIES AND NOT OTHERS
 * =================================
 * This business does not edit vouchers, it deletes and re-enters them. Measured on the real database:
 *
 *     SELECT count(*) FROM USER_DATA;    -- 0     the per-column EDIT audit, never used in the year
 *     SELECT count(*) FROM DELETE_DATA;  -- 72    across 17 voucher families
 *
 * Neither of the families below could be reversed at all:
 *
 *   * SCHEME is the highest-volume workflow in the shop — 841 vouchers and 1635 day-book rows, more than
 *     sales — with 3 real deletions. `deleteSchemeInstallment` existed but was routed only for book 075
 *     (MEMB OPENING); the live instalment book is 074 (MEMB ENTRY), which holds all 841.
 *   * SINGLE receipt and payment had reversal only for their MULTI variants, while the single voucher is the
 *     common case: CASH REC 4, CASH PAY 3, BANK PAY 5, BANK REC 1 — 13 real deletions.
 *
 * WHAT THESE TESTS ASSERT, AND WHY THAT SHAPE
 * ===========================================
 * A delete that removes the header but leaves a balance behind is worse than no delete at all, because both
 * halves look internally consistent. `GAP-ANALYSIS-AND-PLAN.md` records two prior scheme defects that
 * **doubled member balances**, so the scheme test asserts the member's outstanding returns to its prior
 * value — not merely that rows disappeared.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { schemeInstallment, deleteSchemeInstallment } from '../src/modules/membership/scheme.js';
import {
  postReceipt,
  postPayment,
  deleteReceipt,
  deleteFinance,
} from '../src/modules/finance/finance.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'correction-wf';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
/** Real BOOK_DATA rows: 074 MBENT MEMB ENTRY (AD_DATA), RCT/PAY are the finance books. */
const SCHEME_BOOK = '074';
const RCT_BOOK = 'RCT';
const PAY_BOOK = 'PAY';

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
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Correction Co')`,
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
  // CASH_LIMIT 0 / FINE_STK_TYPE 'F' are what every real installation ships — settingsRealValues.test.ts.
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","CASH_LIMIT","FINE_STK_TYPE") VALUES ($1,$2,0,'F')`,
    TENANT,
    CO,
  );
  await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
  for (const [code, name] of [
    ['00001', 'CASH ON HAND'],
    ['00008', 'BANK A/C'],
    ['00050', 'CUSTOMER A'],
    ['SCHMAC', 'SCHEME CONTROL'],
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
  // BOOK_SNAME is the VCH_TYPE, verified on 39 of 40 real books. AD_DATA is book 074's real BOOK_TBL_NAME.
  for (const [book, name, sname, main, tbl] of [
    [SCHEME_BOOK, 'Member Monthly Entry', 'MBENT', 'MEMB ENTRY', 'AD_DATA'],
    [RCT_BOOK, 'Cash Receipt', 'CREC', 'CASH REC', 'CASH_DATA'],
    [PAY_BOOK, 'Cash Payment', 'CPAY', 'CASH PAY', 'CASH_DATA'],
  ]) {
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
          "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'I','Y',$8)`,
      TENANT,
      CO,
      LC,
      book,
      name,
      sname,
      main,
      tbl,
    );
    // P0-04: scheme, receipt and payment paths all resolve their settlement account from BOOK_DETL slot 1
    // and no longer fall back to the literal 'CASH', so every book here needs its slot configured.
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE")
         VALUES ($1,$2,$3,$4,1,'CASHAC')`,
      TENANT,
      CO,
      LC,
      book,
    );
  }
  // A scheme and one enrolled member for the instalment to attach to.
  // SCHM_AC is the scheme-liability account the instalment settles against (scheme.ts reads AD_MAST.SCHM_AC).
  await exec(
    `INSERT INTO "AD_MAST"(tenant_id,"CO_CODE","SCHM_CODE","SCHM_NAME","SCHM_AC")
     VALUES ($1,$2,'S1','GOLD SCHEME','SCHMAC')`,
    TENANT,
    CO,
  );
  // AD_MEMB carries no AC_CODE: the member record is keyed by SCHM_CODE + MEMB_CODE.
  await exec(
    `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME","MEMB_AMT")
     VALUES ($1,$2,$3,'S1','M1','MEMBER ONE',0)`,
    TENANT,
    CO,
    LC,
  );
}

const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: SCHEME_BOOK };
const financeScope = (book: string) => ({ ...scope, coBook: book });

async function rowCount(table: string, book: string, vchNo: string) {
  const rows: Array<{ n: number }> = await owner.$queryRawUnsafe(
    `SELECT count(*)::int AS n FROM "${table}"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
    TENANT,
    CO,
    book,
    vchNo,
  );
  return Number(rows[0]?.n ?? 0);
}

/** The member's accumulated scheme position: what a wrong reversal would corrupt. */
async function memberPosition() {
  const rows: Array<{ paid: number | null }> = await owner.$queryRawUnsafe(
    `SELECT COALESCE(SUM(COALESCE(NULLIF("MEMB_AMT"::text,'')::numeric,0)),0)::float8 AS paid
       FROM "AD_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "SCHM_CODE"='S1' AND "MEMB_CODE"='M1'`,
    TENANT,
    CO,
  );
  return Number(rows[0]?.paid ?? 0);
}

describe.runIf(RUN)('correction workflow: scheme instalment (plan F1.2)', () => {
  beforeAll(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('reverses an instalment and returns the member position to its prior value', async () => {
    const before = await memberPosition();

    const created = await schemeInstallment(runtime, {
      scope,
      schmCode: 'S1',
      membCode: 'M1',
      amount: 2500,
      vchDate: '2024-05-01',
      mainUser: 'corr-wf',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    // The instalment must actually have landed, or the reversal below proves nothing.
    expect(await rowCount('AD_DATA', SCHEME_BOOK, vchNo)).toBeGreaterThan(0);
    const after = await memberPosition();
    expect(after).toBeGreaterThan(before);

    await deleteSchemeInstallment(runtime, {
      scope,
      vchNo,
      book: SCHEME_BOOK,
      vchType: 'MBENT',
    } as never);

    expect(await rowCount('AD_DATA', SCHEME_BOOK, vchNo), 'AD_DATA rows must be gone').toBe(0);
    expect(await rowCount('AC_DATA', SCHEME_BOOK, vchNo), 'ledger legs must be gone').toBe(0);
    /**
     * The assertion that matters. Two prior scheme defects DOUBLED member balances
     * (GAP-ANALYSIS-AND-PLAN.md), so a reversal that removes rows while leaving the accumulated position
     * inflated is the exact failure this family has already had.
     */
    expect(await memberPosition(), 'member position must return to its prior value').toBeCloseTo(
      before,
      2,
    );
  });

  it('leaves a second instalment untouched when the first is reversed', async () => {
    const keep = await schemeInstallment(runtime, {
      scope,
      schmCode: 'S1',
      membCode: 'M1',
      amount: 1000,
      vchDate: '2024-06-01',
      mainUser: 'corr-wf',
    } as never);
    const drop = await schemeInstallment(runtime, {
      scope,
      schmCode: 'S1',
      membCode: 'M1',
      amount: 1500,
      vchDate: '2024-06-02',
      mainUser: 'corr-wf',
    } as never);
    const keepNo = String(keep.vchNo).padStart(5, '0');
    const dropNo = String(drop.vchNo).padStart(5, '0');

    const positionWithBoth = await memberPosition();
    await deleteSchemeInstallment(runtime, {
      scope,
      vchNo: dropNo,
      book: SCHEME_BOOK,
      vchType: 'MBENT',
    } as never);

    expect(
      await rowCount('AD_DATA', SCHEME_BOOK, keepNo),
      'the kept instalment survives',
    ).toBeGreaterThan(0);
    expect(await rowCount('AD_DATA', SCHEME_BOOK, dropNo)).toBe(0);
    // Exactly the reversed amount comes off, not more.
    expect(await memberPosition()).toBeCloseTo(positionWithBoth - 1500, 2);
  });
});

describe.runIf(RUN)('correction workflow: single receipt and payment (plan F1.3)', () => {
  beforeAll(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('reverses a single cash receipt, header and ledger together', async () => {
    const created = await postReceipt(runtime, {
      scope: financeScope(RCT_BOOK),
      mode: 'cash',
      partyAc: '00050',
      amount: 4000,
      cashAc: '00001',
      vchDate: '2024-05-05',
      mainUser: 'corr-wf',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    expect(await rowCount('CASH_DATA', RCT_BOOK, vchNo)).toBeGreaterThan(0);
    expect(await rowCount('AC_DATA', RCT_BOOK, vchNo)).toBeGreaterThanOrEqual(2);

    // deleteReceipt is purpose-built (finance.ts:1286): it reads the persisted CASH_DATA header and
    // reverses RECEIPT_WRITE_TABLES, so no VCH_TYPE is supplied by the caller.
    await deleteReceipt(runtime, {
      scope: financeScope(RCT_BOOK),
      vchNo,
      deleteUser: 'corr-wf',
    });

    expect(await rowCount('CASH_DATA', RCT_BOOK, vchNo), 'header gone').toBe(0);
    expect(await rowCount('AC_DATA', RCT_BOOK, vchNo), 'ledger legs gone').toBe(0);
    expect(await rowCount('DELETE_DATA', RCT_BOOK, vchNo), 'deletion is audited').toBeGreaterThan(
      0,
    );
  });

  it('reverses a single cash payment', async () => {
    const created = await postPayment(runtime, {
      scope: financeScope(PAY_BOOK),
      mode: 'cash',
      partyAc: '00050',
      amount: 1800,
      cashAc: '00001',
      vchDate: '2024-05-06',
      mainUser: 'corr-wf',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    // postPayment writes PAY_DATA, NOT CASH_DATA (finance.ts:512). Pointing a delete at the wrong header
    // table reverses nothing and still reports success, so the table is asserted explicitly here.
    expect(await rowCount('PAY_DATA', PAY_BOOK, vchNo)).toBeGreaterThan(0);

    await deleteFinance(runtime, {
      scope: financeScope(PAY_BOOK),
      vchNo,
      headerTable: 'PAY_DATA',
      book: PAY_BOOK,
      vchType: 'CPAY', // BPAY for bank — finance.ts:523
      deleteUser: 'corr-wf',
    });

    expect(await rowCount('PAY_DATA', PAY_BOOK, vchNo), 'header gone').toBe(0);
    expect(await rowCount('AC_DATA', PAY_BOOK, vchNo), 'ledger legs gone').toBe(0);
    expect(await rowCount('DELETE_DATA', PAY_BOOK, vchNo), 'deletion is audited').toBeGreaterThan(
      0,
    );
  });
});
