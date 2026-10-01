import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../src/modules/shared/bookPolicy.js';
import { withTenant } from '@datacare/db';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Company provisioning must leave a company that can actually POST a voucher.
 *
 * This exists because running the application exposed a defect no unit test caught: provisioning created
 * `BOOK_DATA` but never `BOOK_DETL`, so the very first cash sale on a newly provisioned company failed
 * with `book SL account row 1 is missing`. `bookPolicy.resolveBookAccountTx` reads `BOOK_DETL` for the
 * posting account and fails closed rather than inventing one — correct behaviour that made a provisioning
 * gap look like a transaction bug.
 *
 * The assertion is behavioural, not structural: it resolves the same accounts the sale path resolves, so
 * it fails if any leg the sale needs is absent.
 *
 * EVERY statement here runs inside `withTenant`. The RLS policy is
 * `tenant_id::text = current_setting('app.tenant_id', true)`, and outside a tenant context that setting is
 * NULL, so the comparison is NULL and the table looks EMPTY: reads return 0 and DELETEs silently affect no
 * rows. An earlier draft of this test cleaned and counted outside the context and reported 0 rows for data
 * that was present, which looks exactly like a provisioning failure.
 */
d('company provisioning produces a postable company', () => {
  const prisma = new PrismaClient();
  // Short kebab tenant: tenant_id is varchar(24) on all 170 tables.
  const tenantId = 'provision-db';
  const CO = '01';
  const LC = '01';

  const clean = () =>
    withTenant(prisma, tenantId, async (tx: any) => {
      for (const t of [
        'BOOK_DETL',
        'BOOK_DATA',
        'AC_MAST',
        'TAX_MAST',
        'SRNO_MAST',
        'CO_SET',
        'LOCT_MAST',
        'YEAR_MAST',
        'CO_MAST',
      ]) {
        await tx.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
      }
    });

  const count = (table: string) =>
    withTenant(prisma, tenantId, async (tx: any) => {
      const r: any[] = await tx.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "${table}" WHERE "CO_CODE"=$1`,
        CO,
      );
      return Number(r[0]?.n ?? 0);
    });

  beforeAll(async () => {
    await clean();
    await seedCompany(prisma, tenantId, CO, { coName: 'Provision Test', lcCode: LC });
  });
  afterAll(async () => {
    await clean();
    await prisma.$disconnect();
  });

  it('creates the accounts the posting engine references by literal code', async () => {
    // 19 literal codes plus the six wholesale / rate-cut slot accounts (labour income and expense, silver
    // sale and purchase, other charges, fine kasar).
    expect(await count('AC_MAST')).toBe(25);
  });

  it('creates every book with its posting legs', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK", count(*)::int n FROM "BOOK_DETL" WHERE "CO_CODE"=$1 GROUP BY "CO_BOOK"`,
        CO,
      ),
    );
    expect(rows.length).toBe(23);
    // Three legs per book (1 = control/sales, 2 = cash/bank, 3 = round-off), except the cash books.
    // RCT and PAY carry the desktop cash-book layout, 1 = cash and 2 = kasar: Ac_Ledr.cs:567-581 joins
    // BOOK_DETL SR_NO 1 and SR_NO 2 for legs 01-08. Their slot 2 used to be CASH, which would have posted
    // a write-off to the cash account. The TR_WH_SALE books carry the twelve slots Wh_Sales_Ledr joins.
    // TSP (Tag Split) carries the five Tag_Split_Ledr slots (5 labour, 6/7 gold DR/CR, 8/9 silver DR/CR).
    const legs = Object.fromEntries(rows.map((r) => [String(r.CO_BOOK), Number(r.n)]));
    for (const [book, n] of Object.entries(legs))
      expect(n, book).toBe(
        book === 'RCT' || book === 'PAY'
          ? 2
          : book === 'WHS' || book === 'RTC'
            ? 12
            : book === 'TSP'
              ? 5
              : // OTH INC / OTH EXP each carry a single configured expense/income slot (TR_OTH_PURC reads
                // slot 1); TAG PURCHASE takes the standard three purchase legs like PURCHASE.
                book === 'OIN' || book === 'OEX'
                ? 1
                : 3,
      );
  });

  it('provisions the karigar issue and receipt books so a fresh company can use them (G19)', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME" FROM "BOOK_DATA"
          WHERE "CO_CODE"=$1 AND "CO_BOOK" IN ('KRI','KRR') ORDER BY "CO_BOOK"`,
        CO,
      ),
    );
    expect(rows).toEqual([
      { CO_BOOK: 'KRI', MAIN_BOOK: 'KARIGAR ISSUE', BOOK_INOUT: 'O', BOOK_TBL_NAME: 'KR_DATA' },
      { CO_BOOK: 'KRR', MAIN_BOOK: 'KARIGAR RECEIPT', BOOK_INOUT: 'I', BOOK_TBL_NAME: 'KR_DATA' },
    ]);
  });

  it('creates the wholesale and rate-cut books as the desktop classifies them', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME" FROM "BOOK_DATA"
          WHERE "CO_CODE"=$1 AND "CO_BOOK" IN ('WHS','RTC') ORDER BY "CO_BOOK"`,
        CO,
      ),
    );
    // Book 064 RCUT / RATE CUT and book 034 WSALE / WH SALES, both OUT books over RATE_CUT_DATA.
    expect(rows).toEqual([
      {
        CO_BOOK: 'RTC',
        BOOK_SNAME: 'RCUT',
        MAIN_BOOK: 'RATE CUT',
        BOOK_INOUT: 'O',
        BOOK_TBL_NAME: 'RATE_CUT_DATA',
      },
      {
        CO_BOOK: 'WHS',
        BOOK_SNAME: 'WSALE',
        MAIN_BOOK: 'WH SALES',
        BOOK_INOUT: 'O',
        BOOK_TBL_NAME: 'RATE_CUT_DATA',
      },
    ]);
  });

  it('creates the Tag Cancel and Tag Transfer books TR_TAG_CAN opens', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME","CUR_USE"
           FROM "BOOK_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK" IN ('TGC','TTR') ORDER BY "CO_BOOK"`,
        CO,
      ),
    );
    // MDI_FORM.cs:8586 CurBookHelp("TAG CANCEL") and :8664 CurBookHelp("TAG TRFR"); both number from
    // BAR_CAN_DATA (MS_UPDATE.cs:7825). The desktop's short names are TGCAN and TAGTR.
    expect(rows).toEqual([
      {
        CO_BOOK: 'TGC',
        BOOK_NAME: 'Tag Cancel',
        BOOK_SNAME: 'TGCAN',
        MAIN_BOOK: 'TAG CANCEL',
        BOOK_INOUT: 'O',
        BOOK_TBL_NAME: 'BAR_CAN_DATA',
        CUR_USE: 'Y',
      },
      {
        CO_BOOK: 'TTR',
        BOOK_NAME: 'Tag Transfer',
        BOOK_SNAME: 'TAGTR',
        MAIN_BOOK: 'TAG TRFR',
        BOOK_INOUT: 'O',
        BOOK_TBL_NAME: 'BAR_CAN_DATA',
        CUR_USE: 'Y',
      },
    ]);
  });

  it('creates the Tag Split book TR_TAG_SPLIT opens, with the absorption ledger slots', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME","CUR_USE"
           FROM "BOOK_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"='TSP'`,
        CO,
      ),
    );
    // MDI_FORM.cs:8686 CurBookHelp("TAG SPLIT"); numbered from LBR_DATA; short name TGSPL.
    expect(rows).toEqual([
      {
        CO_BOOK: 'TSP',
        BOOK_NAME: 'Tag Split',
        BOOK_SNAME: 'TGSPL',
        MAIN_BOOK: 'TAG SPLIT',
        BOOK_INOUT: 'O',
        BOOK_TBL_NAME: 'LBR_DATA',
        CUR_USE: 'Y',
      },
    ]);
    // Ac_Ledr.Tag_Split_Ledr joins BOOK_DETL SR_NO 5 (labour), 6/7 (gold DR/CR), 8/9 (silver DR/CR).
    const slots: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "SR_NO"::int AS sr,"AC_CODE" FROM "BOOK_DETL" WHERE "CO_CODE"=$1 AND "CO_BOOK"='TSP' ORDER BY "SR_NO"`,
        CO,
      ),
    );
    expect(slots).toEqual([
      { sr: 5, AC_CODE: 'LBREXP' },
      { sr: 6, AC_CODE: 'PURCHASE' },
      { sr: 7, AC_CODE: 'SALES' },
      { sr: 8, AC_CODE: 'PURCHASE' },
      { sr: 9, AC_CODE: 'SALES' },
    ]);
  });

  /**
   * Every workflow-backed book must resolve under its OWN workflow.
   *
   * This is the assertion that matters most: `workflowPolicy` demands the desktop's literal strings
   * `SALES RETURNE` and `PURC RETURN`. A provisioning table that spelled them `SALES RETURN` and
   * `PURCHASE RETURN` created books that looked right in the UI and failed only when a return was saved.
   * Seeding now derives from `workflowPolicy`, and this test fails if the two ever diverge again.
   */
  it.each([
    ['SL', 'SALES'],
    ['PR', 'PURCHASE'],
    ['SRT', 'SALES RETURN'],
    ['PRT', 'PURCHASE RETURN'],
  ])('book %s resolves under workflow %s', async (coBook, workflow) => {
    const scope = { tenantId, coCode: CO, lcCode: LC, coBook, coYear: '2024-2025' } as any;
    await withTenant(prisma, tenantId, async (tx: any) => {
      const policy = await resolveBookPolicyTx(tx, scope, workflow as any);
      // Row 1 is the control account every one of these workflows resolves first.
      expect(await resolveBookAccountTx(tx, scope, policy, 1)).toBeTruthy();
    });
  });

  it('resolves the exact accounts the sale path resolves', async () => {
    const scope = { tenantId, coCode: CO, lcCode: LC, coBook: 'SL', coYear: '2024-2025' } as any;
    const resolved = await withTenant(prisma, tenantId, async (tx: any) => {
      const policy = await resolveBookPolicyTx(tx, scope, 'SALES');
      // These are the three SR_NOs createSale() asks for; a missing row throws here.
      return {
        control: await resolveBookAccountTx(tx, scope, policy, 1),
        cash: await resolveBookAccountTx(tx, scope, policy, 2),
        round: await resolveBookAccountTx(tx, scope, policy, 3),
      };
    });
    expect(resolved).toEqual({ control: 'SALES', cash: 'CASH', round: 'ROUNDOFF' });
  });

  it('names every posting account as a real AC_MAST row', async () => {
    // A book pointing at an account that does not exist would post to a dangling ledger.
    const orphans: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT DISTINCT d."AC_CODE" FROM "BOOK_DETL" d
          WHERE d."CO_CODE"=$1
            AND NOT EXISTS (SELECT 1 FROM "AC_MAST" a
                             WHERE a."CO_CODE"=d."CO_CODE" AND a."AC_CODE"=d."AC_CODE")`,
        CO,
      ),
    );
    expect(orphans).toEqual([]);
  });

  /**
   * A provisioned company must be REACHABLE, not merely present.
   *
   * `resolveLoginScope` needs a location or `/context/select` answers `location-unavailable`, and
   * `businessScope.year()` needs a fiscal year or every business endpoint answers `scope-incomplete`.
   * Provisioning created books and accounts but neither of these, so a company created through the admin
   * screen could not be entered — found by provisioning a company in the running application.
   */
  it('creates the location and fiscal year the scope resolver needs', async () => {
    const loc: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(`SELECT "LC_CODE" FROM "LOCT_MAST" WHERE "CO_CODE"=$1`, CO),
    );
    expect(loc.map((r) => r.LC_CODE)).toEqual([LC]);
    const yr: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_YEAR","OP_DATE","CL_DATE" FROM "YEAR_MAST" WHERE "CO_CODE"=$1`,
        CO,
      ),
    );
    expect(yr.length).toBe(1);
    // April-to-March, the desktop's fiscal window.
    expect(new Date(yr[0].OP_DATE).getUTCMonth()).toBe(3);
    expect(new Date(yr[0].CL_DATE).getUTCMonth()).toBe(2);
    expect(String(yr[0].CO_YEAR)).toMatch(/^\d{4}-\d{4}$/);
  });

  it('is idempotent', async () => {
    const again = await seedCompany(prisma, tenantId, CO, { coName: 'Provision Test', lcCode: LC });
    expect(again.created.books).toBe(0);
    // 17 three-leg books (incl. TAG PURCHASE + KARIGAR ISSUE/RECEIPT) + RCT/PAY x 2 + WHS/RTC x 12
    // + TSP x 5 + OIN/OEX x 1, not doubled.
    expect(await count('BOOK_DETL')).toBe(83);
  });
});
