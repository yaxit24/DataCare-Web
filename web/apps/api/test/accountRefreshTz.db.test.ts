// A non-UTC server: the suite pins TZ=UTC (vitest.config.ts), so this file moves the process to India Standard Time
// before anything builds a Date. Node re-reads TZ when it changes.
process.env.TZ = 'Asia/Kolkata';

import { createHash } from 'node:crypto';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { applyRepair, previewRepair } from '../src/modules/utilities/dataRepair.js';
import { postContra } from '../src/modules/finance/contra.js';
import { postFineJv } from '../src/modules/finance/fineJv.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import '../src/modules/utilities/dataRepairOps.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Data Refresh > Account check-and-repair on a server east of UTC. The stored VCH_TIME text must reach the expected
 * AC_DATA.ENTRY_TIME unchanged: a voucher saved by the writer previews clean, and an apply keeps ENTRY_TIME exactly.
 * Synthetic data only.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

const T = 'acct-refresh-tz-db';
const CO = '01';
const LC = '01';
const OPERATOR = 'tz-admin';
const PASSWORD = 'Account-Refresh-Tz-1!';

d('Data Refresh Account check-and-repair under Asia/Kolkata', () => {
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
  const entryTimes = (coBook: string) =>
    query<{ key: string; t: string }>(
      `SELECT "LEDR_KEY" key,"ENTRY_TIME"::text t FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY 1`,
      T,
      coBook,
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
      reason: 'repair postings on an IST server',
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
      ['TZCASH', 'Tz Cash'],
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
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG") VALUES ($1,$2,$3,$4,'ADMIN')`,
      T,
      CO,
      OPERATOR,
      await hashPassword(PASSWORD),
    );
    const contra = { scope: { ...scope, coBook: 'CON' }, mainUser: OPERATOR };
    await postContra(runtime, {
      ...contra,
      vchDate: `${y}-06-20`,
      lines: [
        { crdr: 'DR', acCode: 'TZBANK', amount: 410 },
        { crdr: 'CR', acCode: 'TZCASH', amount: 410 },
      ],
    });
    await postContra(runtime, {
      ...contra,
      vchDate: `${y}-06-21`,
      lines: [
        { crdr: 'CR', acCode: 'TZBANK', amount: 90 },
        { crdr: 'DR', acCode: 'TZCASH', amount: 90 },
      ],
    });
    await postFineJv(runtime, {
      scope: { ...scope, coBook: 'FJV' },
      metal: 'G',
      vchDate: `${y}-06-22`,
      mainUser: OPERATOR,
      lines: [
        { crdr: 'DR', acCode: 'TZBANK', fine: 2.5 },
        { crdr: 'CR', acCode: 'TZCASH', fine: 2.5 },
      ],
    });
  }, 120_000);

  afterAll(async () => {
    if (RUN) await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('previews writer-saved vouchers clean and keeps ENTRY_TIME exactly through an apply', async () => {
    for (const op of ['data-refresh-account-contra', 'data-refresh-account-fine-jv']) {
      const p = await preview(op);
      expect(p.samples, op).toEqual([]);
      expect(p.clean, op).toBe(true);
    }
    const before = await entryTimes('CON');
    await exec(
      `UPDATE "AC_DATA" SET "DR_AMT"="DR_AMT"+1 WHERE tenant_id=$1 AND "CO_BOOK"='CON' AND "VCH_NO"='00001' AND "DR_AMT"<>0`,
      T,
    );
    const p = await preview('data-refresh-account-contra');
    expect(p.diffs).toEqual([{ table: 'AC_DATA', insert: 0, update: 1, delete: 0 }]);
    await apply('data-refresh-account-contra', p.previewHash);
    expect(await entryTimes('CON')).toEqual(before);
    expect((await preview('data-refresh-account-contra')).clean).toBe(true);

    const fineBefore = await entryTimes('FJV');
    await exec(`DELETE FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='FJV'`, T);
    const fp = await preview('data-refresh-account-fine-jv');
    expect(fp.clean).toBe(false);
    await apply('data-refresh-account-fine-jv', fp.previewHash);
    expect(await entryTimes('FJV')).toEqual(fineBefore);
    expect((await preview('data-refresh-account-fine-jv')).clean).toBe(true);
  });
});
