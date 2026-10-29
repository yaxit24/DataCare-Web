import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { issueDhrn } from '../src/modules/dhrn/dhrn.js';
import { dhrnOsLetterData, dhrnOsLetterHtml } from '../src/modules/dhrn/dhrnOsLetter.js';
import type { VoucherScope } from '../src/modules/vouchers/numbering.js';

/**
 * N126 / G135: the Dhrn Os Letter per-party pledge outstanding statement (desktop RP_DHRN_OS).
 * Lists each open pledge with principal, repaid, outstanding, accrued interest and total due; a
 * stateless document that posts nothing.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;
const TENANT = 'dhrn-os-letter-db';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-04-10';

const scope = (coBook: string): VoucherScope => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook,
});

databaseDescribe('database-backed dhrn os letter', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  const cleanup = async (): Promise<void> => {
    for (const table of [
      'DHRN_ISU_DETL',
      'DHRN_ISU_DATA',
      'DHRN_DATA',
      'AC_DATA',
      'ROJ_MEL_DATA',
      'TEMP_BOOK_DATA',
      'SRNO_MAST',
      'BOOK_DATA',
      'BOOK_DETL',
      'AC_MAST',
      'CO_MAST',
      'CO_SET',
    ])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, TENANT);
  };

  const seed = async (): Promise<void> => {
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","DHRN_PRC") VALUES ($1,$2,NULL,12)`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Test Jewellers')`,
      TENANT,
      CO,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,'DHI','Dhiran Issue','DHIS','DHIRAN ISSUE','O','Y','DHRN_ISU_DATA')`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE")
       VALUES ($1,$2,$3,'BORR','Pledge Borrower','9876500000'),($1,$2,$3,'CASH','Cash Account',NULL)`,
      TENANT,
      CO,
      LC,
    );
    await owner.$executeRawUnsafe(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,'DHI',2,'CASH','DHIRAN ISSUE','O')`,
      TENANT,
      CO,
      LC,
    );
  };

  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });
  afterAll(async () => {
    await cleanup();
    await owner.$disconnect();
    await runtime.$disconnect();
  });
  beforeEach(async () => {
    await cleanup();
    await seed();
  });

  it('lists the open pledge with outstanding principal, accrued interest and total due', async () => {
    await issueDhrn(runtime, {
      scope: scope('DHI'),
      borrowerAc: 'BORR',
      borrowerName: 'Pledge Borrower',
      principal: 50_000,
      intPrc: 12,
      loanType: 'A',
      vchDate: DAY,
      mainUser: 'dhrn-user',
    } as never);

    const data = await dhrnOsLetterData(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      acCode: 'BORR',
      asOf: '2024-10-10', // 6 months later
    });
    expect(data).not.toBeNull();
    expect(data!.pledges).toHaveLength(1);
    const g = data!.pledges[0]!;
    expect(g.principal).toBe(50_000);
    expect(g.repaid).toBe(0);
    expect(g.outstanding).toBe(50_000);
    expect(g.intPrc).toBe(12);
    // interest accrued over ~6 months at 12% on 50000 is clearly positive
    expect(g.interest).toBeGreaterThan(0);
    expect(g.totalDue).toBeGreaterThan(50_000);
    expect(data!.totals.outstanding).toBe(50_000);
    expect(data!.asOf).toBe('2024-10-10');

    // the HTML renders the borrower, the letter wording and the total
    const html = dhrnOsLetterHtml(data!, {});
    expect(html).toContain('Pledge Outstanding Letter');
    expect(html).toContain('Pledge Borrower');
    expect(html).toContain('We are sorry for any inconvenience caused');
  });

  it('returns null for a party with no open pledges', async () => {
    const data = await dhrnOsLetterData(runtime, {
      tenantId: TENANT,
      coCode: CO,
      lcCode: LC,
      coYear: YEAR,
      acCode: 'NOBODY',
    });
    expect(data).toBeNull();
  });
});
