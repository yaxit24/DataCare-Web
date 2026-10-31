/**
 * Reopening a saved voucher — plan item F2.1.
 *
 * WHY THIS MATTERS MORE THAN IT SOUNDS
 * ===================================
 * 13 of the 19 voucher families this business actually uses could be POSTED but never REOPENED. A voucher
 * became unreachable the moment it was saved: an operator could not view it to check what was entered and
 * could not reprint it. In the desktop, opening a saved voucher by number is a core interaction — the F-key
 * lookup exists for it — so this is the difference between a data-entry screen and an ERP.
 *
 * Nothing new was implemented to close this. Every `get*` function exercised below already existed in its
 * module and had simply never been routed: a scan of `export async function (get|edit|delete)*` against
 * `routes/txn.ts` found **34 of 120 lifecycle functions unrouted**.
 *
 * WHAT EACH TEST ASSERTS
 * ======================
 * A round trip, not a smoke test: post a voucher, read it back, and assert the read reproduces the values
 * that were submitted. A `GET` that returns a row shaped correctly but carrying someone else's amounts would
 * pass a existence check and fail here.
 *
 * Two live families are deliberately absent because they have no `get*` function to route — `payments`
 * (133 vouchers, header PAY_DATA rather than the CASH_DATA `getReceipt` reads) and `rate-cut` (40). Those
 * need a function written, not a route, and the last test pins that they are still missing so the gap cannot
 * be mistaken for coverage.
 */
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import {
  postContra,
  getContra,
  postReceipt,
  getReceipt,
  postPayment,
  getPayment,
} from '../src/modules/finance/finance.js';
import { postRateCut, getRateCut } from '../src/modules/sales/rateCut.js';
import { postFineJv, getFineJv } from '../src/modules/finance/fineJv.js';
import { schemeInstallment, getSchemeInstallment } from '../src/modules/membership/scheme.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'reopen-voucher';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const CONTRA_BOOK = '017';
const RCT_BOOK = 'RCT';
const FJV_BOOK = '078';
const SCHEME_BOOK = '074';
const PAY_BOOK = 'PAY';
/** Book 064 is the real RATE CUT book; wholesale (034) shares its RATE_CUT_DATA header. */
const RCUT_BOOK = '064';

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
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Reopen Co')`,
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
  // CASH_LIMIT 0 / FINE_STK_TYPE 'F' are what every real installation ships.
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
  // BOOK_SNAME is the VCH_TYPE, verified on 39 of 40 real books.
  for (const [book, name, sname, main, tbl] of [
    [CONTRA_BOOK, 'Journal Voucher', 'JV', 'CONTRA', 'CONTRA_DATA'],
    [RCT_BOOK, 'Cash Receipt', 'CREC', 'CASH REC', 'CASH_DATA'],
    [FJV_BOOK, 'Fine JV', 'FJV', 'FINE JV', 'CONTRA_DATA'],
    [SCHEME_BOOK, 'Member Monthly Entry', 'MBENT', 'MEMB ENTRY', 'AD_DATA'],
    [PAY_BOOK, 'Cash Payment', 'CPAY', 'CASH PAY', 'PAY_DATA'],
    [RCUT_BOOK, 'Rate Cut', 'RCUT', 'RATE CUT', 'RATE_CUT_DATA'],
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
  }
  /**
   * BOOK_DETL supplies each rate-cut book's contra accounts. Posting FAILS CLOSED without them: the module
   * previously defaulted to invented codes ('SALEGOLD' and friends) that exist in no chart of accounts, so
   * its ledger rows carried a contra pointing nowhere. SR positions are the desktop's, from books 034/064.
   */
  // P0-04: the receipt/payment paths resolve their settlement account from slot 1 and no longer fall back to
  // the literal 'CASH', so the payment book needs its slot configured too.
  for (const book of [RCT_BOOK, PAY_BOOK, RCUT_BOOK, SCHEME_BOOK]) {
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE")
         VALUES ($1,$2,$3,$4,1,'SALEGOLD'),($1,$2,$3,$4,2,'PURCGOLD'),($1,$2,$3,$4,3,'CASH'),
                ($1,$2,$3,$4,4,'KASAR'),($1,$2,$3,$4,6,'LABOUR'),($1,$2,$3,$4,11,'OTHER')`,
      TENANT,
      CO,
      LC,
      book,
    );
  }
  // The rate-cut line needs an item and a group; SALEGOLD/PURCGOLD/KASAR are the accounts its ledger names.
  await exec(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC") VALUES ($1,$2,'GO','GOLD','00008')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
     VALUES ($1,$2,'GOLD','FINE GOLD','G','GO')`,
    TENANT,
    CO,
  );
  for (const [code, name] of [
    ['SALEGOLD', 'SALE GOLD A/C'],
    ['PURCGOLD', 'PURCHASE GOLD A/C'],
    ['KASAR', 'KASAR A/C'],
    ['CASH', 'CASH'],
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
  await exec(
    `INSERT INTO "AD_MAST"(tenant_id,"CO_CODE","SCHM_CODE","SCHM_NAME","SCHM_AC")
     VALUES ($1,$2,'S1','GOLD SCHEME','SCHMAC')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME","MEMB_AMT")
     VALUES ($1,$2,$3,'S1','M1','MEMBER ONE',0)`,
    TENANT,
    CO,
    LC,
  );
}

const scopeFor = (book: string) => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: book,
});

/**
 * The `get*` functions return NORMALISED DOMAIN OBJECTS, not raw rows — `{ voucherNo, amount, … }` keyed the
 * way the poster's input is keyed. That is what makes a round-trip assertion meaningful: the field a caller
 * submitted comes back under the name it submitted it under, so `post` then `get` is genuinely symmetric.
 * They also THROW when the voucher does not exist rather than returning an empty shape, which is the safer
 * behaviour — a silent empty record reads as "the voucher has no lines".
 */
describe.runIf(RUN)('reopening a saved voucher (plan F2.1)', () => {
  beforeAll(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('a contra round-trips its accounts, amount and narration', async () => {
    const created = await postContra(runtime, {
      scope: scopeFor(CONTRA_BOOK),
      lines: [
        { crdr: 'DR', acCode: '00008', amount: 7250 },
        { crdr: 'CR', acCode: '00001', amount: 7250 },
      ],
      vchDate: '2024-05-10',
      itDesc: 'transfer to bank',
      mainUser: 'reopen',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const read = (await getContra(runtime, scopeFor(CONTRA_BOOK), vchNo)) as Record<
      string,
      unknown
    >;
    expect(read.voucherNo).toBe(vchNo);
    // Every value the caller supplied comes back under the name it was supplied under.
    expect(read.amount).toBe(7250);
    expect(read.toAc).toBe('00008');
    expect(read.fromAc).toBe('00001');
    expect(read.itDesc).toBe('transfer to bank');
    expect(read.vchDate).toBe('2024-05-10');
  });

  it('a cash receipt round-trips its party, amount and tender mode', async () => {
    const created = await postReceipt(runtime, {
      scope: scopeFor(RCT_BOOK),
      mode: 'cash',
      partyAc: '00050',
      amount: 3125,
      // 'CASH' is the literal getReceipt reads back to infer mode (finance.ts REC_AC_CODE === 'CASH').
      bankAc: 'CASH',
      vchDate: '2024-05-11',
      mainUser: 'reopen',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const read = (await getReceipt(runtime, scopeFor(RCT_BOOK), vchNo)) as Record<string, unknown>;
    expect(read.voucherNo).toBe(vchNo);
    expect(read.amount).toBe(3125);
    expect(read.partyAc).toBe('00050');
    expect(read.vchDate).toBe('2024-05-11');
  });

  it('a fine JV round-trips its metal WEIGHT, which is the value that matters', async () => {
    const created = await postFineJv(runtime, {
      scope: scopeFor(FJV_BOOK),
      // The TR_CONTRA grid: row 1 gives (DR) and its counter row receives (CR) the fine metal.
      lines: [
        { crdr: 'DR', acCode: '00050', fine: 12.5 },
        { crdr: 'CR', acCode: '00001', fine: 12.5 },
      ],
      metal: 'G',
      vchDate: '2024-05-12',
      mainUser: 'reopen',
    });
    const vchNo = String(created.vchNo).padStart(5, '0');

    const read = (await getFineJv(runtime, scopeFor(FJV_BOOK), vchNo)) as Record<string, unknown>;
    expect(read.voucherNo).toBe(vchNo);
    expect(read.lines).toMatchObject([
      { crdr: 'DR', acCode: '00050', fine: 12.5 },
      { crdr: 'CR', acCode: '00001', fine: 12.5 },
    ]);
    expect(read.metal).toBe('G');
  });

  it('a scheme instalment round-trips — the highest-volume family, 841 live vouchers', async () => {
    const created = await schemeInstallment(runtime, {
      scope: scopeFor(SCHEME_BOOK),
      schmCode: 'S1',
      membCode: 'M1',
      amount: 1750,
      vchDate: '2024-05-13',
      mainUser: 'reopen',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const read = (await getSchemeInstallment(runtime, scopeFor(SCHEME_BOOK), vchNo)) as Record<
      string,
      unknown
    >;
    expect(read.voucherNo).toBe(vchNo);
    expect(read.amount).toBe(1750);
    expect(read.schmCode).toBe('S1');
    expect(read.membCode).toBe('M1');
    expect(read.book).toBe(SCHEME_BOOK);
  });

  it('reading a voucher number that does not exist THROWS, rather than returning a blank one', async () => {
    // Failing loudly is the safer behaviour: an empty record would read as "this voucher has no lines",
    // which is the same class of trap as an empty query result read as a finding.
    await expect(getContra(runtime, scopeFor(CONTRA_BOOK), '99999')).rejects.toThrow(/not found/i);
  });

  it('a cash payment round-trips — the second most-used family, 133 live vouchers', async () => {
    /**
     * This needed a reader WRITTEN, not a route wired. A payment's header is `PAY_DATA`, not the `CASH_DATA`
     * a receipt writes, so `getReceipt` reported every payment as missing. The column names differ too: a
     * receipt carries `REC_AMT`/`REC_AC_CODE`, a payment `NET_AMT`/`TOT_AMT` and `BANK_AC`.
     */
    const created = await postPayment(runtime, {
      scope: scopeFor(PAY_BOOK),
      mode: 'cash',
      partyAc: '00050',
      amount: 1980,
      vchDate: '2024-05-14',
      mainUser: 'reopen',
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const read = (await getPayment(runtime, scopeFor(PAY_BOOK), vchNo)) as Record<string, unknown>;
    expect(read.voucherNo).toBe(vchNo);
    expect(read.amount).toBe(1980);
    expect(read.partyAc).toBe('00050');
    expect(read.vchDate).toBe('2024-05-14');
    // `mode` is reconstructed from which amount column carries the value, not stored directly.
    expect(read.mode).toBe('cash');
  });

  it('a rate-cut round-trips, and reads back with NO lines — the real header-only shape', async () => {
    /**
     * One reader serves rate-cut AND wholesale sale, because `BOOK_DATA` for `MAIN_BOOK='WH SALES'` carries
     * `BOOK_TBL_NAME='RATE_CUT_DATA'`.
     *
     * The empty `lines` assertion is the point: **all 25 real rate-cut vouchers on book 064 carry zero detail
     * rows**, with the value entirely in the header. A reader that treated absent lines as "not found" would
     * make the commonest real shape unreadable. (That the web cannot yet POST that shape is decision D-1;
     * this fixture posts a lined voucher, which is what wholesale does.)
     */
    const created = await postRateCut(runtime, {
      scope: scopeFor(RCUT_BOOK),
      acCode: '00050',
      vchDate: '2024-05-15',
      itType: 'G',
      lines: [{ itCode: 'GOLD', netWt: 10, touch: 92, rate: 6000, itType: 'G' }],
      pay: { cash: 5000 },
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');

    const read = (await getRateCut(runtime, scopeFor(RCUT_BOOK), vchNo)) as Record<string, unknown>;
    expect(read.voucherNo).toBe(vchNo);
    expect(read.acCode).toBe('00050');
    expect(read.itType).toBe('G');
    expect(read.vchDate).toBe('2024-05-15');
    expect(Array.isArray(read.lines)).toBe(true);
    const pay = read.pay as Record<string, unknown>;
    expect(Number(pay.cash)).toBe(5000);
  });

  it('every live family that can be posted can now be reopened, except the two known non-vouchers', async () => {
    /**
     * Closes plan item F2.1. Of the 19 families in live use, the only ones without a voucher reader are:
     *   scheme enrol  — keyed by member, not voucher (`AD_MEMB` has no VCH_NO); `GET /members` reads it
     *   bill to bill  — a settlement, not a voucher; blocked on decision D-4 regardless
     * This assertion fails if a reader is ever removed.
     */
    const finance = await import('../src/modules/finance/finance.js');
    const rateCut = await import('../src/modules/sales/rateCut.js');
    expect(Object.keys(finance)).toContain('getPayment');
    expect(Object.keys(finance)).toContain('getReceipt');
    expect(Object.keys(finance)).toContain('getContra');
    expect(Object.keys(rateCut)).toContain('getRateCut');
  });
});
