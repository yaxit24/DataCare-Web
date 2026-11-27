import { createHash } from 'node:crypto';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { applyRepair, previewRepair } from '../src/modules/utilities/dataRepair.js';
import {
  registerAccountRefreshFamily,
  type AccountCheck,
} from '../src/modules/utilities/accountRefresh.js';
import { deriveContraPostingsTx } from '../src/modules/finance/contraRefresh.js';
import { editContra, getContra, postContra } from '../src/modules/finance/contra.js';
import { editFineJv, getFineJv, postFineJv } from '../src/modules/finance/fineJv.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import '../src/modules/utilities/dataRepairOps.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Data Refresh > Account check-and-repair, Contra and Fine Jv (owner decision 2026-11-27; MS_UPDATE.cs:2334-2669,
 * Contra_Ledr Ac_Ledr.cs:840-848, Contra_Rojmel Ac_Rojmel.cs:336-344). Synthetic data only.
 *
 * Every voucher saved through the normal writer must preview clean (that is what puts the family on the
 * ACCOUNT_REFRESH_VERIFIED allowlist); a damaged voucher is flagged alone with the exact difference and the apply puts
 * back the writer's rows; locked, orphan, untouched-book and other-tenant rows never change.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const T = 'acct-refresh-db';
const OTHER = 'acct-refresh-other-db';
const CO = '01';
const LC = '01';
const y = new Date().getMonth() + 1 >= 4 ? new Date().getFullYear() : new Date().getFullYear() - 1;
const YEAR = `${y}-${y + 1}`;
const OPERATOR = 'refresh-admin';
const PASSWORD = 'Account-Refresh-1!';
const CONTRA = 'data-refresh-account-contra';
const FINE = 'data-refresh-account-fine-jv';
const ACCOUNTS = [
  ['RFCASH', 'Refresh Cash'],
  ['RFBANK', 'Refresh Bank'],
  ['RFEXP1', 'Refresh Expense One'],
  ['RFEXP2', 'Refresh Expense Two'],
];

d('Data Refresh Account check-and-repair (Contra, Fine Jv)', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient();
  const scope = (tenantId = T) => ({ tenantId, coCode: CO, lcCode: LC, coYear: YEAR });
  const book = (coBook: string, tenantId = T) => ({ ...scope(tenantId), coBook });
  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, T, (tx: any) => tx.$executeRawUnsafe(sql, ...p));
  const query = <R = any>(sql: string, ...p: unknown[]): Promise<R[]> =>
    withTenant(owner, T, (tx: any) => tx.$queryRawUnsafe(sql, ...p));

  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const tenant of [T, OTHER])
      await withTenant(owner, tenant, async (tx: any) => {
        await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
        for (const { table_name } of tables)
          await tx.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenant);
      });
  };

  const seedTenant = async (tenant: string) => {
    await seedCompany(runtime, tenant, CO);
    await withTenant(owner, tenant, async (tx: any) => {
      for (const [code, name] of ACCOUNTS)
        await tx.$executeRawUnsafe(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
           VALUES ($1,$2,$3,$4,$5,'10')`,
          tenant,
          CO,
          LC,
          code,
          name,
        );
    });
  };

  const contraLines = (
    a: number,
    shape: 'two' | 'three' | 'credit-first' = 'two',
  ): Array<{ crdr: 'DR' | 'CR'; acCode: string; amount: number; itDesc?: string }> =>
    shape === 'two'
      ? [
          { crdr: 'DR', acCode: 'RFBANK', amount: a },
          { crdr: 'CR', acCode: 'RFCASH', amount: a },
        ]
      : shape === 'three'
        ? [
            { crdr: 'DR', acCode: 'RFBANK', amount: a, itDesc: 'Deposit split' },
            { crdr: 'CR', acCode: 'RFCASH', amount: a - 25.5, itDesc: 'Till cash' },
            { crdr: 'CR', acCode: 'RFEXP1', amount: 25.5 },
          ]
        : [
            { crdr: 'CR', acCode: 'RFBANK', amount: a, itDesc: 'Withdrawal' },
            { crdr: 'DR', acCode: 'RFCASH', amount: a - 10 },
            { crdr: 'DR', acCode: 'RFEXP2', amount: 10, itDesc: 'Charges' },
          ];
  const contra = async (
    date: string,
    amount: number,
    shape?: 'two' | 'three' | 'credit-first',
    tenant = T,
  ) => {
    const result = await postContra(runtime, {
      scope: book('CON', tenant),
      lines: contraLines(amount, shape),
      vchDate: date,
      mainUser: OPERATOR,
    });
    return String(result.vchNo).padStart(5, '0');
  };
  const fineJv = async (date: string, fine: number, metal: 'G' | 'S', three = false) => {
    const result = await postFineJv(runtime, {
      scope: book('FJV'),
      metal,
      vchDate: date,
      mainUser: OPERATOR,
      lines: three
        ? [
            { crdr: 'DR', acCode: 'RFEXP1', fine, itDesc: 'Fine in' },
            { crdr: 'CR', acCode: 'RFEXP2', fine: fine - 1.25, itDesc: 'Fine out' },
            { crdr: 'CR', acCode: 'RFCASH', fine: 1.25 },
          ]
        : [
            { crdr: 'DR', acCode: 'RFEXP1', fine, itDesc: 'Fine transfer' },
            { crdr: 'CR', acCode: 'RFEXP2', fine },
          ],
    });
    return String(result.vchNo).padStart(5, '0');
  };

  /** A voucher's posting rows without row identity, in a stable order. */
  const postings = async (coBook: string, vchNo: string, tenant = T) => {
    const out: Record<string, unknown[]> = {};
    for (const table of ['AC_DATA', 'ROJ_MEL_DATA', 'TAX_DATA'])
      out[table] = await withTenant(owner, tenant, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT to_jsonb(t) - 'row_id' AS r FROM "${table}" t
            WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
            ORDER BY to_jsonb(t)::text`,
          tenant,
          CO,
          LC,
          YEAR,
          coBook,
          vchNo,
        ),
      );
    return out;
  };

  const preview = (op = CONTRA, tenant = T) => previewRepair(runtime, op, scope(tenant), OPERATOR);
  type Page = Pick<AccountCheck, 'summary' | 'vouchers'> & { total: number };
  const detailOf = (p: { detail?: unknown }) => p.detail as Page;

  const backup = async () => {
    const checksum = createHash('sha256')
      .update(`${T}:${Date.now()}:${Math.random()}`)
      .digest('hex');
    await exec(
      `INSERT INTO "company_backup_run"(tenant_id,co_code,checksum,document_version,generated_at,table_count,row_count,operator)
       VALUES ($1,$2,$3,1,now(),1,0,$4)`,
      T,
      CO,
      checksum,
      OPERATOR,
    );
    return checksum;
  };
  const apply = async (previewHash: string, op = CONTRA) =>
    applyRepair(runtime, op, scope(), {
      previewHash,
      operator: OPERATOR,
      confirmation: `${op} ${CO}`,
      reason: 'repair contra postings after a fault',
      operatorPassword: PASSWORD,
      backupReference: await backup(),
    });

  const fixtures: Record<'contra' | 'fine', Array<{ coBook: string; vchNo: string }>> = {
    contra: [],
    fine: [],
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    await wipe();
    await seedTenant(T);
    await seedTenant(OTHER);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,$2,$3,$4,'ADMIN')`,
      T,
      CO,
      OPERATOR,
      await hashPassword(PASSWORD),
    );
    // The contra and fine-jv write-set fixtures: every grid shape the writers accept, created and edited.
    fixtures.contra.push({ coBook: 'CON', vchNo: await contra(`${y}-05-10`, 500) });
    fixtures.contra.push({ coBook: 'CON', vchNo: await contra(`${y}-06-12`, 1250.75, 'three') });
    fixtures.contra.push({ coBook: 'CON', vchNo: await contra(`${y}-07-01`, 980, 'credit-first') });
    const edited = await contra(`${y}-07-20`, 300);
    await editContra(
      runtime,
      {
        scope: book('CON'),
        lines: contraLines(444.4, 'three'),
        vchDate: `${y}-07-21`,
        mainUser: OPERATOR,
        expectedVersion: (await getContra(runtime, book('CON'), edited)).version,
      },
      edited,
    );
    fixtures.contra.push({ coBook: 'CON', vchNo: edited });
    fixtures.contra.push({ coBook: 'CON', vchNo: await contra(`${y}-08-03`, 75) });
    fixtures.fine.push({ coBook: 'FJV', vchNo: await fineJv(`${y}-06-15`, 12.345, 'G') });
    fixtures.fine.push({ coBook: 'FJV', vchNo: await fineJv(`${y}-06-16`, 50.5, 'S', true) });
    const fineEdited = await fineJv(`${y}-06-17`, 3, 'G');
    await editFineJv(
      runtime,
      {
        scope: book('FJV'),
        metal: 'S',
        vchDate: `${y}-06-18`,
        lines: [
          { crdr: 'CR', acCode: 'RFEXP2', fine: 7.125, itDesc: 'Edited' },
          { crdr: 'DR', acCode: 'RFEXP1', fine: 7.125 },
        ],
        expectedVersion: (await getFineJv(runtime, book('FJV'), fineEdited)).version,
      },
      fineEdited,
    );
    fixtures.fine.push({ coBook: 'FJV', vchNo: fineEdited });
    // The second tenant's sentinel voucher, damaged so that a scope leak would repair it.
    const sentinel = await contra(`${y}-05-11`, 600, 'two', OTHER);
    await withTenant(owner, OTHER, (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "AC_DATA" SET "DR_AMT"=1 WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2 AND "DR_AMT"<>0`,
        OTHER,
        sentinel,
      ),
    );
  }, 120_000);

  afterAll(async () => {
    if (RUN) await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('save-then-check: every contra and fine-jv voucher saved by the writer previews clean', async () => {
    for (const [op, list] of [
      [CONTRA, fixtures.contra],
      [FINE, fixtures.fine],
    ] as const) {
      const p = await preview(op);
      const detail = detailOf(p);
      expect(detail.vouchers, `${op}: ${JSON.stringify(detail.vouchers).slice(0, 2000)}`).toEqual(
        [],
      );
      expect(detail.summary).toMatchObject({ match: list.length, total: list.length });
      expect(p.clean).toBe(true);
      expect(p.applyAvailable).toBe(true);
    }
  });

  it('flags only the damaged vouchers, repairs them to the writer rows and keeps CLR_DATE', async () => {
    const [dropped, changed, stray, untouched] = fixtures.contra;
    const writer = {
      dropped: await postings('CON', dropped!.vchNo),
      changed: await postings('CON', changed!.vchNo),
      stray: await postings('CON', stray!.vchNo),
      untouched: await postings('CON', untouched!.vchNo),
    };
    const legs = await query<{ key: string }>(
      `SELECT "LEDR_KEY" key FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`,
      T,
      dropped!.vchNo,
    );
    const droppedKey = legs[0]!.key;
    await exec(`DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND "LEDR_KEY"=$2`, T, droppedKey);
    const changedLegs = await query<{ key: string }>(
      `SELECT "LEDR_KEY" key FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2 AND "DR_AMT"<>0 ORDER BY "LEDR_KEY"`,
      T,
      changed!.vchNo,
    );
    const changedKey = changedLegs[0]!.key;
    await exec(
      `UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+1 WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      T,
      changedKey,
    );
    // A clearing mark on the damaged leg and on an intact one: both survive the replace by LEDR_KEY.
    await exec(
      `UPDATE "AC_DATA" SET "CLR_DATE"=$3::date WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2`,
      T,
      changed!.vchNo,
      `${y}-09-30`,
    );
    const strayKey = `${CO}${LC}${YEAR}CON${stray!.vchNo}99         9`;
    await exec(
      `INSERT INTO "ROJ_MEL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","AC_CODE","DR_AMT","CR_AMT")
       VALUES ($1,$2,$3,$4,'CON',$5,$6,$7::date,'RFEXP1',5,0)`,
      T,
      CO,
      LC,
      YEAR,
      stray!.vchNo,
      strayKey,
      `${y}-07-01`,
    );

    const p = await preview();
    const listed = detailOf(p).vouchers;
    expect(listed.map((v) => [v.vchNo, v.status])).toEqual([
      [dropped!.vchNo, 'differs'],
      [changed!.vchNo, 'differs'],
      [stray!.vchNo, 'differs'],
    ]);
    const tableOf = (vchNo: string, table: string) =>
      listed.find((v) => v.vchNo === vchNo)!.tables.find((t) => t.table === table)!;
    expect(tableOf(dropped!.vchNo, 'AC_DATA')).toMatchObject({
      onlyExpected: [droppedKey],
      onlyStored: [],
      changed: [],
    });
    expect(tableOf(changed!.vchNo, 'AC_DATA').changed).toEqual([
      expect.objectContaining({ key: changedKey, col: 'DR_AMT' }),
    ]);
    expect(tableOf(stray!.vchNo, 'ROJ_MEL_DATA')).toMatchObject({
      onlyStored: [strayKey],
      onlyExpected: [],
    });
    expect(p.diffs).toEqual(
      expect.arrayContaining([
        { table: 'AC_DATA', insert: 1, update: 1, delete: 0 },
        { table: 'ROJ_MEL_DATA', insert: 0, update: 0, delete: 1 },
      ]),
    );
    const sentinelBefore = await postings('CON', '00001', OTHER);

    const applied = await apply(p.previewHash);
    expect(applied.deduplicated).toBe(false);
    const after = {
      dropped: await postings('CON', dropped!.vchNo),
      changed: await postings('CON', changed!.vchNo),
      stray: await postings('CON', stray!.vchNo),
      untouched: await postings('CON', untouched!.vchNo),
    };
    expect(after.dropped).toEqual(writer.dropped);
    expect(after.stray).toEqual(writer.stray);
    expect(after.untouched).toEqual(writer.untouched);
    // The amount is the writer's again and every leg keeps the clearing date it had.
    const clr = `${y}-09-30`;
    expect(after.changed.AC_DATA).toEqual(
      (writer.changed.AC_DATA as Array<{ r: Record<string, unknown> }>).map((row) => ({
        r: { ...row.r, CLR_DATE: clr },
      })),
    );
    expect(await postings('CON', '00001', OTHER)).toEqual(sentinelBefore);

    // Idempotent: the same hash replays, the next preview is clean, a stale hash is refused.
    expect((await apply(p.previewHash)).deduplicated).toBe(true);
    const again = await preview();
    expect(again.clean).toBe(true);
    expect(detailOf(again).vouchers).toEqual([]);
    await expect(apply('0'.repeat(64))).rejects.toMatchObject({ code: 'stale-preview' });

    const runs = await query<{
      before_rows: Array<{ vchNo: string; rows: Record<string, unknown[]> }>;
    }>(
      `SELECT before_rows FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id=$2 AND state='applied'`,
      T,
      CONTRA,
    );
    expect(runs).toHaveLength(1);
    const before = runs[0]!.before_rows;
    expect(before.map((b) => b.vchNo)).toEqual([dropped!.vchNo, changed!.vchNo, stray!.vchNo]);
    expect(
      (before[2]!.rows.ROJ_MEL_DATA as Array<{ LEDR_KEY: string }>).some(
        (r) => r.LEDR_KEY === strayKey,
      ),
    ).toBe(true);
  });

  it('never changes a voucher in a locked period', async () => {
    const [first] = fixtures.contra;
    await exec(
      `UPDATE "AC_DATA" SET "CR_AMT"="CR_AMT"+2 WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2 AND "CR_AMT"<>0`,
      T,
      first!.vchNo,
    );
    const damaged = await postings('CON', first!.vchNo);
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1`, T, `${y}-05-31`);
    try {
      const p = await preview();
      expect(detailOf(p).vouchers.map((v) => [v.vchNo, v.status])).toEqual([
        [first!.vchNo, 'locked'],
      ]);
      expect(p.clean).toBe(true);
      expect(p.diffs).toEqual([]);
      await apply(p.previewHash);
      expect(await postings('CON', first!.vchNo)).toEqual(damaged);
    } finally {
      await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1`, T);
    }
    // Unlocked, it is repaired like any other.
    const p = await preview();
    await apply(p.previewHash);
    expect((await preview()).clean).toBe(true);
  });

  it('rolls every voucher back when the apply fails part way', async () => {
    const [, second, third] = fixtures.contra;
    await exec(
      `DELETE FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2`,
      T,
      second!.vchNo,
    );
    // The third voucher's first leg is moved to another book: its key stays taken, so re-inserting it fails.
    const moved = await query<{ key: string }>(
      `SELECT "LEDR_KEY" key FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY" LIMIT 1`,
      T,
      third!.vchNo,
    );
    await exec(
      `UPDATE "AC_DATA" SET "CO_BOOK"='ZZZ' WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      T,
      moved[0]!.key,
    );
    const secondBefore = await postings('CON', second!.vchNo);
    const p = await preview();
    expect(detailOf(p).vouchers.map((v) => v.vchNo)).toEqual([second!.vchNo, third!.vchNo]);
    await expect(apply(p.previewHash)).rejects.toThrow();
    expect(await postings('CON', second!.vchNo)).toEqual(secondBefore);
    const applied = await query(
      `SELECT 1 FROM "data_repair_run" WHERE tenant_id=$1 AND preview_hash=$2 AND state='applied'`,
      T,
      p.previewHash,
    );
    expect(applied).toEqual([]);
    await exec(
      `UPDATE "AC_DATA" SET "CO_BOOK"='CON' WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      T,
      moved[0]!.key,
    );
    await apply((await preview()).previewHash);
    expect((await preview()).clean).toBe(true);
  });

  it('refuses a preview overtaken by a voucher edit', async () => {
    const [, , , , last] = fixtures.contra;
    await exec(
      `DELETE FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2`,
      T,
      last!.vchNo,
    );
    const p = await preview();
    expect(p.clean).toBe(false);
    await editContra(
      runtime,
      {
        scope: book('CON'),
        lines: contraLines(80),
        vchDate: `${y}-08-03`,
        mainUser: OPERATOR,
        expectedVersion: (await getContra(runtime, book('CON'), last!.vchNo)).version,
      },
      last!.vchNo,
    );
    await expect(apply(p.previewHash)).rejects.toMatchObject({ code: 'stale-preview' });
    // The edit rewrote the whole posting, so the voucher is clean again.
    expect((await preview()).clean).toBe(true);
  });

  it('reports orphans and untouched books without changing them, and repairs Fine Jv', async () => {
    const orphanNo = '09999';
    await exec(
      `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","LEDR_KEY","VCH_DATE","AC_CODE","DR_AMT","CR_AMT")
       VALUES ($1,$2,$3,$4,'CON',$5,$6,$7::date,'RFCASH',9,0)`,
      T,
      CO,
      LC,
      YEAR,
      orphanNo,
      `${CO}${LC}${YEAR}CON${orphanNo}         102`,
      `${y}-06-01`,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE")
       VALUES ($1,$2,$3,'888','System Contra','SYS','CONTRA','I','Y')`,
      T,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "CONTRA_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","LD_CODE","DR_AMT","CR_AMT","LDR_TYPE","CRDR_TYPE")
       VALUES ($1,$2,$3,$4,'888','00001',1,$5::date,'RFCASH','RFBANK',0,5,'0','CR')`,
      T,
      CO,
      LC,
      YEAR,
      `${y}-06-01`,
    );
    const fineNo = fixtures.fine[1]!.vchNo;
    const fineWriter = await postings('FJV', fineNo);
    await exec(
      `UPDATE "AC_DATA" SET "FINE_WT"="FINE_WT"+0.5 WHERE tenant_id=$1 AND "CO_BOOK"='FJV' AND "VCH_NO"=$2 AND "SIGN"='+'`,
      T,
      fineNo,
    );
    const p = await preview();
    expect(detailOf(p).vouchers.map((v) => [v.coBook, v.vchNo, v.status])).toEqual([
      ['CON', orphanNo, 'orphan'],
    ]);
    expect(p.clean).toBe(true);
    await apply(p.previewHash);
    expect(
      await query(`SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`, T, orphanNo),
    ).toHaveLength(1);

    const fp = await preview(FINE);
    expect(detailOf(fp).vouchers.map((v) => [v.vchNo, v.status])).toEqual([[fineNo, 'differs']]);
    await apply(fp.previewHash, FINE);
    expect(await postings('FJV', fineNo)).toEqual(fineWriter);
    expect((await preview(FINE)).clean).toBe(true);
  });

  it('reports a Fine Jv whose fines no longer pair as unverified and leaves its postings alone', async () => {
    const fineNo = fixtures.fine[0]!.vchNo;
    const before = await postings('FJV', fineNo);
    const contraRows = await query(
      `SELECT to_jsonb(t) - 'row_id' r FROM "CONTRA_DATA" t WHERE tenant_id=$1 AND "CO_BOOK"='FJV' AND "VCH_NO"=$2`,
      T,
      fineNo,
    );
    await exec(
      `DELETE FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='FJV' AND "VCH_NO"=$2 AND "SR_NO"=2`,
      T,
      fineNo,
    );
    const p = await preview(FINE);
    const listed = detailOf(p).vouchers;
    expect(listed.map((v) => [v.vchNo, v.status])).toEqual([[fineNo, 'unverified']]);
    expect(listed[0]!.reason).toMatch(/fines do not pair/);
    expect(p.diffs).toEqual([]);
    await apply(p.previewHash, FINE);
    expect(await postings('FJV', fineNo)).toEqual(before);
    expect(contraRows).toHaveLength(2);
  });

  it('warns that a clearing mark on a leg the voucher no longer posts will be dropped', async () => {
    const vchNo = fixtures.contra[1]!.vchNo;
    const [leg] = await query<{ key: string }>(
      `SELECT "LEDR_KEY" key FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"=$2 ORDER BY "LEDR_KEY" LIMIT 1`,
      T,
      vchNo,
    );
    const strayKey = `${leg!.key}X`;
    await exec(
      `UPDATE "AC_DATA" SET "LEDR_KEY"=$3,"CLR_DATE"=$4::date WHERE tenant_id=$1 AND "LEDR_KEY"=$2`,
      T,
      leg!.key,
      strayKey,
      `${y}-10-01`,
    );
    const p = await preview();
    const listed = detailOf(p).vouchers.filter((v) => v.coBook === 'CON' && v.vchNo === vchNo);
    expect(listed).toHaveLength(1);
    expect(listed[0]!.warnings).toEqual([
      `bank clearing mark ${y}-10-01 on ${strayKey} will be dropped`,
    ]);
    expect(p.samples.join('\n')).toMatch(/will be dropped/);
    await apply(p.previewHash);
    const [run] = await query<{ before_rows: Array<{ vchNo: string; warnings?: string[] }> }>(
      `SELECT before_rows FROM "data_repair_run" WHERE tenant_id=$1 AND operation_id=$2 AND state='applied'
        ORDER BY row_id DESC LIMIT 1`,
      T,
      CONTRA,
    );
    expect(run!.before_rows.find((b) => b.vchNo === vchNo)!.warnings).toEqual(listed[0]!.warnings);
    expect(
      await query(`SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1 AND "LEDR_KEY"=$2`, T, strayKey),
    ).toEqual([]);
  });

  it('keeps a family that is not on the verified list preview-only', async () => {
    registerAccountRefreshFamily({
      id: 'test-unverified',
      title: 'Test Unverified',
      mainBook: 'CONTRA',
      headerTable: 'CONTRA_DATA',
      versionTables: ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA'],
      desktopSource: 'test only',
      derive: deriveContraPostingsTx,
      lock: async () => {},
    });
    const op = 'data-refresh-account-test-unverified';
    const p = await preview(op);
    expect(p.applyAvailable).toBe(false);
    expect(p.blockedReason).toMatch(/not available until the family is verified/);
    await expect(apply(p.previewHash, op)).rejects.toMatchObject({ code: 'preview-only' });
  });
});
