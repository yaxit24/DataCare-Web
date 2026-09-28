import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { postReceipt } from '../src/modules/finance/finance.js';
import { PostingAccountValidationError } from '../src/modules/shared/postingAccounts.js';

/**
 * P0-04 exit evidence: a missing posting account refuses the voucher and leaves NOTHING behind.
 *
 * The defect being closed was silent, not loud. `settlementAc` returned the literal `'CASH'` and every finance
 * path ended its account resolution with it, so a company whose book has no configured settlement account
 * still posted — to an account code that exists only in the provisioning seed. On a migrated company that is a
 * misposting discovered at year end.
 *
 * Refusing is only half the fix. The refusal must also be CLEAN: a voucher serial consumed by a rejected
 * attempt would leave a permanent gap in a legally numbered sequence, and a partial write would leave a
 * one-sided ledger. Both are asserted here against a real database, because the guarantee comes from the
 * transaction boundary rather than from the order of statements in the source.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'posting-ac-closed';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = '001';
const PARTY = '000926';
const CASH = '00001';
const KASAR = '00057';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const rows = async (sql: string, ...p: unknown[]) =>
  (await withTenant(owner, TENANT, (tx) => tx.$queryRawUnsafe(sql, ...p))) as Array<
    Record<string, unknown>
  >;

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

/** A postable company and book. `withSlot` decides whether the settlement account is CONFIGURED. */
async function seed(withSlot: boolean): Promise<void> {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF","ALL_ROF_REMOVE")
     VALUES ($1,$2,'N',2,2,2,'N')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name] of [
    [PARTY, 'CASH PARTY'],
    [CASH, 'CASH ON HAND'],
    [KASAR, 'KASAR JAVK A/C'],
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
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Cash Received','CREC','CASH REC','I','Y','CASH_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  if (withSlot) {
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE",
          "BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,1,$5,'Cash Received','CASH REC','I')`,
      TENANT,
      CO,
      LC,
      BOOK,
      CASH,
    );
  }
}

/**
 * Everything a rejected attempt could have consumed.
 *
 * `SRNO_MAST` holds the hidden voucher/tag serials, and the visible voucher number is MAX+1 over the book's
 * own header table, so both are captured: a refusal must move neither.
 */
const serialState = async (): Promise<Array<Record<string, unknown>>> =>
  rows(
    `SELECT coalesce("LC_CODE",'-') lc, coalesce("VCH_SRNO"::text,'-') vch,
            coalesce("TAG_SRNO"::text,'-') tag
       FROM "SRNO_MAST" WHERE tenant_id=$1 ORDER BY lc, vch, tag`,
    TENANT,
  );

const writtenRowCounts = async (): Promise<Record<string, number>> => {
  const out: Record<string, number> = {};
  for (const table of ['AC_DATA', 'CASH_DATA', 'ROJ_MEL_DATA', 'TEMP_BOOK_DATA']) {
    const r = await rows(`SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1`, TENANT);
    out[table] = Number(r[0]?.n ?? 0);
  }
  return out;
};

describe.runIf(RUN)('posting accounts fail closed', () => {
  beforeEach(async () => {
    await wipe();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('refuses a receipt when the book has no configured settlement account, consuming no serial', async () => {
    await seed(false);
    const serialsBefore = await serialState();
    const countsBefore = await writtenRowCounts();

    await expect(
      postReceipt(runtime, {
        scope,
        partyAc: PARTY,
        amount: 60000,
        mode: 'cash',
        vchDate: '2024-04-01',
      } as never),
    ).rejects.toMatchObject({
      name: 'PostingAccountValidationError',
      role: 'cash-settlement',
      detail: `book ${BOOK} slot 1 is missing`,
    });

    // Nothing written, and — the part a source reading cannot prove — no serial burnt. A rejected attempt
    // that advanced SRNO_MAST would leave a permanent hole in a legally numbered sequence.
    expect(await writtenRowCounts()).toEqual(countsBefore);
    expect(await serialState()).toEqual(serialsBefore);
  });

  it('refuses a write-off without a write-off account and still writes nothing', async () => {
    // The settlement account IS configured here, so the refusal can only come from the kasar leg — proving the
    // requirement is per account rather than one blanket check that happens to fire first.
    await seed(true);
    const serialsBefore = await serialState();

    await expect(
      postReceipt(runtime, {
        scope,
        partyAc: PARTY,
        amount: 60000,
        kasar: 771,
        mode: 'cash',
        vchDate: '2024-04-01',
      } as never),
    ).rejects.toBeInstanceOf(PostingAccountValidationError);

    expect(await writtenRowCounts()).toEqual({
      AC_DATA: 0,
      CASH_DATA: 0,
      ROJ_MEL_DATA: 0,
      TEMP_BOOK_DATA: 0,
    });
    expect(await serialState()).toEqual(serialsBefore);
  });

  it('posts to the CONFIGURED account, never to a literal, once configuration exists', async () => {
    await seed(true);
    await postReceipt(runtime, {
      scope,
      partyAc: PARTY,
      amount: 60000,
      kasar: 771,
      kasarAc: KASAR,
      mode: 'cash',
      vchDate: '2024-04-01',
    } as never);

    const ledger = await rows(
      `SELECT "AC_CODE" ac, "LD_CODE" ld FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      TENANT,
    );
    expect(ledger).toHaveLength(4);
    const used = new Set(ledger.flatMap((r) => [String(r.ac ?? ''), String(r.ld ?? '')]));
    // The configured slot account and the caller's write-off account, and NOT the placeholders that used to
    // reach these columns.
    expect(used.has(CASH)).toBe(true);
    expect(used.has(KASAR)).toBe(true);
    expect(used.has('CASH')).toBe(false);
    expect(used.has('KASAR')).toBe(false);

    const header = await rows(
      `SELECT "REC_AC_CODE" ac FROM "CASH_DATA" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(String(header[0]?.ac ?? '')).toBe(CASH);
  });
});
