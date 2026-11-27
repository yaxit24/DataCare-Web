// A non-UTC server: the suite pins TZ=UTC (vitest.config.ts), so this file moves the process to India Standard Time
// before anything builds a Date. Node re-reads TZ when it changes.
process.env.TZ = 'Asia/Kolkata';

import { createHash } from 'node:crypto';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { applyRepair, previewRepair } from '../src/modules/utilities/dataRepair.js';
import { postPayment, postReceipt } from '../src/modules/finance/cashBank.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import '../src/modules/utilities/dataRepairOps.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Data Refresh > Account check-and-repair of Cash/Bank vouchers on a server east of UTC. The stored VCH_TIME text, and
 * the clearing date a bank leg takes as ENTRY_TIME when it differs from the voucher date (Ac_Ledr.cs:587), must reach
 * the expected AC_DATA rows unchanged: writer-saved vouchers preview clean and an apply keeps ENTRY_TIME exactly.
 * Synthetic data only.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const T = 'acct-refresh-cb-tz-db';
const CO = '01';
const LC = '01';
const OPERATOR = 'cbtz-admin';
const PASSWORD = 'Account-Refresh-CbTz-1!';
const OP = 'data-refresh-account-cash-bank';

d('Data Refresh Account check-and-repair of Cash/Bank under Asia/Kolkata', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient();
  const y =
    new Date().getMonth() + 1 >= 4 ? new Date().getFullYear() : new Date().getFullYear() - 1;
  const YEAR = `${y}-${y + 1}`;
  const scope = { tenantId: T, coCode: CO, lcCode: LC, coYear: YEAR };
  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, T, (tx: any) => tx.$executeRawUnsafe(sql, ...p));
  const query = <R = any>(sql: string, ...p: unknown[]): Promise<R[]> =>
    withTenant(owner, T, (tx: any) => tx.$queryRawUnsafe(sql, ...p));

  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    await withTenant(owner, T, async (tx: any) => {
      await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge"='on'`);
      for (const { table_name } of tables)
        await tx.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, T);
    });
  };
  const entryTimes = () =>
    query<{ key: string; d: string; t: string }>(
      `SELECT "LEDR_KEY" key,"VCH_DATE"::text d,"ENTRY_TIME"::text t FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK" IN ('BRC','CPY') ORDER BY 1`,
      T,
    );
  const preview = (op: string) => previewRepair(runtime, op, scope, OPERATOR);
  const apply = async (op: string, previewHash: string) => {
    const checksum = createHash('sha256').update(`${T}:${op}:${Date.now()}`).digest('hex');
    await exec(
      `INSERT INTO "company_backup_run"(tenant_id,co_code,checksum,document_version,generated_at,table_count,row_count,operator)
       VALUES ($1,$2,$3,1,now(),1,0,$4)`,
      T,
      CO,
      checksum,
      OPERATOR,
    );
    return applyRepair(runtime, op, scope, {
      previewHash,
      operator: OPERATOR,
      confirmation: `${op} ${CO}`,
      reason: 'repair cash/bank postings on an IST server',
      operatorPassword: PASSWORD,
      backupReference: checksum,
    });
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    expect(new Date(2026, 0, 1).getTimezoneOffset()).toBe(-330);
    await wipe();
    await seedCompany(runtime, T, CO);
    for (const [code, name] of [
      ['TZPARTY', 'Tz Party'],
      ['TZBANK', 'Tz Bank'],
    ])
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,$2,$3,$4,$5,'10')`,
        T,
        CO,
        LC,
        code,
        name,
      );
    for (const [code, main, inout, slots] of [
      ['BRC', 'BANK REC', 'I', ['TZBANK', 'KASAR']],
      ['CPY', 'CASH PAY', 'O', ['CASH', 'KASAR']],
    ] as const) {
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE")
         VALUES ($1,$2,$3,$4,$5,$4,$6,$7,'Y')`,
        T,
        CO,
        LC,
        code,
        main,
        main,
        inout,
      );
      for (const [index, ac] of slots.entries())
        await exec(
          `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
           VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9)`,
          T,
          CO,
          LC,
          code,
          index + 1,
          ac,
          main,
          main,
          inout,
        );
    }
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,$2,$3,$4,'ADMIN')`,
      T,
      CO,
      OPERATOR,
      await hashPassword(PASSWORD),
    );
    // Cleared later (ENTRY_TIME is the clearing date) and cleared the same day (ENTRY_TIME is VCH_TIME).
    for (const clrDate of [`${y}-06-25`, undefined])
      await postReceipt(runtime, {
        scope: { ...scope, coBook: 'BRC' },
        partyAc: 'TZPARTY',
        amount: 410,
        kasar: 2,
        mode: 'cheque',
        chqNo: '1234',
        clrDate,
        vchDate: `${y}-06-20`,
        mainUser: OPERATOR,
      });
    await postPayment(runtime, {
      scope: { ...scope, coBook: 'CPY' },
      partyAc: 'TZPARTY',
      amount: 90,
      mode: 'cash',
      vchDate: `${y}-06-21`,
      mainUser: OPERATOR,
    });
  }, 120_000);

  afterAll(async () => {
    if (RUN) await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('previews writer-saved vouchers clean and keeps VCH_DATE and ENTRY_TIME exactly through an apply', async () => {
    const p = await preview(OP);
    expect(p.samples).toEqual([]);
    expect(p.clean).toBe(true);
    const before = await entryTimes();
    expect(before.some((row) => row.t.startsWith(`${y}-06-25`))).toBe(true);
    await exec(
      `UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+1 WHERE tenant_id=$1 AND "CO_BOOK" IN ('BRC','CPY') AND "DR_AMT"<>0`,
      T,
    );
    await exec(`DELETE FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='BRC'`, T);
    const damaged = await preview(OP);
    expect(damaged.clean).toBe(false);
    await apply(OP, damaged.previewHash);
    expect(await entryTimes()).toEqual(before);
    expect((await preview(OP)).clean).toBe(true);
  });
});
