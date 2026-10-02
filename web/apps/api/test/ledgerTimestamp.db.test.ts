import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { postVoucherTx } from '../src/modules/posting/posting.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'ledger-clock-parity';
const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024-2025', CO_BOOK: 'ORD', VCH_NO: '00001' };

(enabled ? describe : describe.skip)('desktop voucher-time ledger cutoffs', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const clean = async () => {
    for (const table of ['SL_ORD_DATA', 'AC_DATA', 'CO_SET'])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await clean();
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES($1,'01','')`,
      tenantId,
    );
  });
  afterAll(async () => {
    if (owner) await clean();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('inherits the document clock, keeps explicit leg time, and separates before/equal/after balances', async () => {
    const date = new Date('2024-07-01T00:00:00Z');
    const clock = new Date('2024-07-01T15:16:17.123Z');
    await withTenant(runtime, tenantId, (tx) =>
      postVoucherTx(tx, tenantId, {
        bookName: 'SALES ORDER',
        partyAc: 'PARTY',
        writes: [{ table: 'SL_ORD_DATA', rows: [{ ...key, VCH_DATE: date, VCH_TIME: clock }] }],
        ledger: {
          table: 'AC_DATA',
          lines: [
            { ...key, AC_CODE: 'PARTY', LD_CODE: 'CASH', CR_AMT: 40, DR_AMT: 0, legType: 1 },
            {
              ...key,
              AC_CODE: 'PARTY',
              LD_CODE: 'CASH',
              CR_AMT: 10,
              DR_AMT: 0,
              legType: 2,
              ENTRY_TIME: new Date('2024-07-01T14:00:00Z'),
            },
            { ...key, AC_CODE: 'CASH', LD_CODE: 'PARTY', DR_AMT: 50, CR_AMT: 0, legType: 3 },
          ],
        },
      }),
    );
    await withTenant(runtime, tenantId, async (tx) => {
      const rows: Array<{ date: string; time: string }> = await tx.$queryRawUnsafe(
        `SELECT "VCH_DATE"::text AS date, to_char("ENTRY_TIME",'YYYY-MM-DD HH24:MI:SS.MS') AS time
          FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
        tenantId,
      );
      expect(rows).toEqual([
        { date: '2024-07-01', time: '2024-07-01 15:16:17.123' },
        { date: '2024-07-01', time: '2024-07-01 14:00:00.000' },
        { date: '2024-07-01', time: '2024-07-01 15:16:17.123' },
      ]);
      const balances: Array<{ opening: string; closing: string }> = await tx.$queryRawUnsafe(
        `SELECT SUM("CR_AMT"-"DR_AMT") FILTER (WHERE "ENTRY_TIME" < $2::timestamp)::text AS opening,
                SUM("CR_AMT"-"DR_AMT") FILTER (WHERE "ENTRY_TIME" <= $2::timestamp)::text AS closing
           FROM "AC_DATA" WHERE tenant_id=$1 AND "AC_CODE"='PARTY'`,
        tenantId,
        '2024-07-01 15:16:17.123',
      );
      expect(balances).toEqual([{ opening: '10.00', closing: '50.00' }]);
    });
  });
});
