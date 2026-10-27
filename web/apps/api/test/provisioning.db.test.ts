import { readFileSync } from 'node:fs';
import { dirname, resolve } from 'node:path';
import { fileURLToPath } from 'node:url';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { createPurchase } from '../src/modules/purchase/purchase.js';
import { createSale } from '../src/modules/sales/sales.js';
import { resolveBookAccountTx, resolveBookPolicyTx } from '../src/modules/shared/bookPolicy.js';
import { resolveTaxPolicyTx } from '../src/modules/shared/taxPolicy.js';
import { withTenant } from '@datacare/db';
import { tenantTables } from './support/tenantSnapshot.js';

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
  // The migration owner, for whole-tenant cleanup and for running the G82 migration body as deploy does.
  const owner = new PrismaClient({
    datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? '' } },
  });
  // Short kebab tenant: tenant_id is varchar(24) on all 170 tables.
  const tenantId = 'provision-db';
  const CO = '01';
  const LC = '01';

  const clean = async () => {
    // Every tenant-scoped table, so the vouchers the G82 ledger test posts (AC_DATA, PR_DATA, SL_DATA,
    // TAX_DATA, stock, day book, audit rows, ...) are removed as well as the provisioned masters. Through the
    // OWNER connection: the runtime role rightly cannot delete from the append-only audit_log.
    for (const t of await tenantTables(owner)) {
      await owner.$executeRawUnsafe(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
    }
  };

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
    await owner.$disconnect();
  });

  it('creates the accounts the posting engine references by literal code', async () => {
    // 19 literal codes plus the six wholesale / rate-cut slot accounts (labour income and expense, silver
    // sale and purchase, other charges, fine kasar), plus BRANCH (the stock in/out branch account, N91).
    expect(await count('AC_MAST')).toBe(26);
  });

  it('creates every book with its posting legs', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK", count(*)::int n FROM "BOOK_DETL" WHERE "CO_CODE"=$1 GROUP BY "CO_BOOK"`,
        CO,
      ),
    );
    expect(rows.length).toBe(27);
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

  it('provisions karigar and Jadtar issue/receipt books so a fresh company can use them (G19)', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME" FROM "BOOK_DATA"
          WHERE "CO_CODE"=$1 AND "CO_BOOK" IN ('KRI','KRR','JDI','JDR') ORDER BY "CO_BOOK"`,
        CO,
      ),
    );
    expect(rows).toEqual([
      { CO_BOOK: 'JDI', MAIN_BOOK: 'JDTR ISU', BOOK_INOUT: 'O', BOOK_TBL_NAME: 'MFG_DATA' },
      { CO_BOOK: 'JDR', MAIN_BOOK: 'JDTR REC', BOOK_INOUT: 'I', BOOK_TBL_NAME: 'MFG_DATA' },
      { CO_BOOK: 'KRI', MAIN_BOOK: 'KARIGAR ISSUE', BOOK_INOUT: 'O', BOOK_TBL_NAME: 'KR_DATA' },
      { CO_BOOK: 'KRR', MAIN_BOOK: 'KARIGAR RECEIPT', BOOK_INOUT: 'I', BOOK_TBL_NAME: 'KR_DATA' },
    ]);
  });

  it('creates the wholesale and rate-cut books as the desktop classifies them', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "CO_BOOK","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME" FROM "BOOK_DATA"
          WHERE "CO_CODE"=$1 AND "CO_BOOK" IN ('WHS','RTC','WHQ') ORDER BY "CO_BOOK"`,
        CO,
      ),
    );
    // Book 064 RCUT / RATE CUT, 034 WSALE / WH SALES and 434 WHQUT / WH QUOT are OUT books over RATE_CUT_DATA.
    expect(rows).toEqual([
      {
        CO_BOOK: 'RTC',
        BOOK_SNAME: 'RCUT',
        MAIN_BOOK: 'RATE CUT',
        BOOK_INOUT: 'O',
        BOOK_TBL_NAME: 'RATE_CUT_DATA',
      },
      {
        CO_BOOK: 'WHQ',
        BOOK_SNAME: 'WHQUT',
        MAIN_BOOK: 'WH QUOT',
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
    const slots: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT count(*)::int n FROM "BOOK_DETL" WHERE "CO_CODE"=$1 AND "CO_BOOK"='WHQ'`,
        CO,
      ),
    );
    expect(slots[0]?.n).toBe(0);
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
    // 19 three-leg books (incl. TAG PURCHASE, KARIGAR and JDTR issue/receipt) + RCT/PAY x 2
    // + WHS/RTC x 12 + TSP x 5 + OIN/OEX x 1 + SIN/SOT x 3 (stock in/out, N91), not doubled.
    expect(await count('BOOK_DETL')).toBe(95);
  });

  /**
   * G82: a named tax code must resolve on a web-provisioned company.
   *
   * The resolver (`shared/taxPolicy.ts`) and the desktop pin a code by its PARENT row `SR_NO = 0`
   * (`AND D.SR_NO = 0`); the component split lives at `SR_NO = 1` SGST, `2` CGST, `3` IGST. The old seed
   * wrote each code as a single `SR_NO = 1` row, so every save that named a tax code failed with
   * "tax code is not configured" on every web-provisioned company. These assertions are behavioural: the
   * resolver is the same code the sale and purchase paths call.
   *
   * `TAX_AC` stays unset, as the old seed left it: G82 changes the shape of the tax master and no posted
   * account (the account convention is decision D15).
   */
  it('provisions each GST tax code with its desktop parent + SGST/CGST/IGST rows (G82)', async () => {
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT coalesce("SR_NO",0)::int AS sr,"TAX_GROUP" AS grp,
                coalesce("TAX_PRC",0)::float AS prc,"TAX_AC" AS ac
           FROM "TAX_MAST" WHERE "CO_CODE"=$1 AND "TAX_CODE"='10' ORDER BY coalesce("SR_NO",0)`,
        CO,
      ),
    );
    expect(rows).toEqual([
      { sr: 0, grp: 'N', prc: 3, ac: null },
      { sr: 1, grp: 'SGST', prc: 1.5, ac: null },
      { sr: 2, grp: 'CGST', prc: 1.5, ac: null },
      { sr: 3, grp: 'IGST', prc: 3, ac: null },
    ]);
  });

  it('provisions TAX FREE and TCS as a single parent row at SR_NO 0 (G82)', async () => {
    for (const code of ['00', '20']) {
      const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT coalesce("SR_NO",0)::int AS sr FROM "TAX_MAST"
            WHERE "CO_CODE"=$1 AND "TAX_CODE"=$2 ORDER BY coalesce("SR_NO",0)`,
          CO,
          code,
        ),
      );
      expect(rows.map((r) => r.sr)).toEqual([0]);
    }
  });

  it('resolves a GST rate BY PERCENTAGE (no code) without a parent/component collision (G82)', async () => {
    // A sale or purchase created by rate resolves tax by PERCENTAGE, no code. A parent (SR_NO 0) and its IGST
    // component (SR_NO 3) share the full rate, so a 3% lookup matches both rows. They are one configuration
    // (the same code), so the resolver must return the parent, not report
    // "tax rate maps to multiple configurations: 3".
    const scope = { tenantId, coCode: CO, lcCode: LC, coBook: 'SL', coYear: '2024-2025' } as any;
    for (const total of [3, 5, 12, 18, 28]) {
      const policy = await withTenant(prisma, tenantId, (tx: any) =>
        resolveTaxPolicyTx(tx, scope, { acCode: 'CASH', taxPct: total }),
      );
      expect(policy.taxGroup).toBe('N'); // the parent, not the IGST component
      expect(policy.taxPct).toBe(total);
      // No account on the master, so each writer keeps its own fallback ('GST' sale, 'GSTINPUT' purchase).
      expect(policy.taxAc).toBeNull();
    }
  });

  it('resolves every GST tax code BY NAME without the G82 failure, with the right component split', async () => {
    const scope = { tenantId, coCode: CO, lcCode: LC, coBook: 'SL', coYear: '2024-2025' } as any;
    for (const [code, total] of [
      ['10', 3],
      ['11', 5],
      ['12', 12],
      ['13', 18],
      ['14', 28],
    ] as const) {
      const policy = await withTenant(prisma, tenantId, (tx: any) =>
        // acCode is any real AC_MAST row; it only drives the AC_GST_TYPE lookup. Before G82 this threw
        // "tax code is not configured".
        resolveTaxPolicyTx(tx, scope, { acCode: 'CASH', taxPct: total, taxCode: code }),
      );
      expect(policy.taxCode).toBe(code);
      expect(policy.taxGroup).toBe('N'); // the parent's group
      expect(policy.taxPct).toBe(total);
      expect(policy.taxAc).toBeNull();
      // Component split read from SR_NO 1..3.
      expect(policy.components.get(1)?.group).toBe('SGST');
      expect(policy.components.get(1)?.pct).toBe(total / 2);
      expect(policy.components.get(2)?.group).toBe('CGST');
      expect(policy.components.get(2)?.pct).toBe(total / 2);
      expect(policy.components.get(3)?.group).toBe('IGST');
      expect(policy.components.get(3)?.pct).toBe(total);
    }
  });

  /**
   * The forward migration repairs a company the OLD seed provisioned. This plants that exact legacy shape (one
   * row at SR_NO 1, the total rate, group 'N', no account) and runs the REAL migration file, so the test fails
   * if the migration and this expectation drift apart. A second company that is already correct, and a second
   * run, prove the migration is idempotent and leaves correct data alone.
   */
  it('migration repairs a legacy single-row GST master in place, idempotently (G82)', async () => {
    const LEGACY_CO = '09';
    await seedCompany(prisma, tenantId, LEGACY_CO, { coName: 'Legacy Co', lcCode: LC });
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(`DELETE FROM "TAX_MAST" WHERE "CO_CODE"=$1`, LEGACY_CO);
      for (const [code, prc] of [
        ['10', 3],
        ['13', 18],
      ] as const) {
        await tx.$executeRawUnsafe(
          `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP")
           VALUES ($1,$2,$3,1,$4,$5,'N')`,
          tenantId,
          LEGACY_CO,
          code,
          `GST ${prc}%`,
          prc,
        );
      }
    });
    const snapshotOf = async (coCode: string) =>
      (await withTenant(prisma, tenantId, (tx: any) =>
        tx.$queryRawUnsafe(
          `SELECT "TAX_CODE" AS code, coalesce("SR_NO",0)::int AS sr, "TAX_GROUP" AS grp,
                  coalesce("TAX_PRC",0)::float AS prc, "TAX_AC" AS ac
             FROM "TAX_MAST" WHERE "CO_CODE"=$1 ORDER BY "TAX_CODE", coalesce("SR_NO",0)`,
          coCode,
        ),
      )) as Array<Record<string, unknown>>;
    const correctBefore = await snapshotOf(CO);

    // The migration body is a single DO block; the owner role runs it across every tenant, as deploy does.
    const migrationSql = readFileSync(
      resolve(
        dirname(fileURLToPath(import.meta.url)),
        '../../../packages/db/prisma/migrations/20261002010000_tax_mast_parent_row/migration.sql',
      ),
      'utf8',
    );
    await owner.$executeRawUnsafe(migrationSql);
    const repaired = await snapshotOf(LEGACY_CO);
    expect(repaired).toEqual([
      { code: '10', sr: 0, grp: 'N', prc: 3, ac: null },
      { code: '10', sr: 1, grp: 'SGST', prc: 1.5, ac: null },
      { code: '10', sr: 2, grp: 'CGST', prc: 1.5, ac: null },
      { code: '10', sr: 3, grp: 'IGST', prc: 3, ac: null },
      { code: '13', sr: 0, grp: 'N', prc: 18, ac: null },
      { code: '13', sr: 1, grp: 'SGST', prc: 9, ac: null },
      { code: '13', sr: 2, grp: 'CGST', prc: 9, ac: null },
      { code: '13', sr: 3, grp: 'IGST', prc: 18, ac: null },
    ]);
    // An already-correct company is untouched, and a second run changes nothing.
    expect(await snapshotOf(CO)).toEqual(correctBefore);
    await owner.$executeRawUnsafe(migrationSql);
    expect(await snapshotOf(LEGACY_CO)).toEqual(repaired);

    const scope = {
      tenantId,
      coCode: LEGACY_CO,
      lcCode: LC,
      coBook: 'SL',
      coYear: '2024-2025',
    } as any;
    const policy = await withTenant(prisma, tenantId, (tx: any) =>
      resolveTaxPolicyTx(tx, scope, { acCode: 'CASH', taxPct: 18, taxCode: '13' }),
    );
    expect(policy.taxCode).toBe('13');
    expect(policy.taxPct).toBe(18);
    expect(policy.components.get(1)?.group).toBe('SGST');
    expect(policy.components.get(3)?.group).toBe('IGST');
  });

  /**
   * The ledger effect G82 must NOT have: with no account on the master, a purchase on a web-provisioned company
   * still posts its input tax to the purchase fallback, and a sale to the sale fallback, exactly as before G82.
   * Setting `TAX_AC` in provisioning would have moved purchase input tax onto the output account.
   */
  it('keeps the posted tax accounts unchanged: purchase input tax to GSTINPUT, sale tax to GST (G82)', async () => {
    const scopeFor = (coBook: string) =>
      ({ tenantId, coCode: CO, lcCode: LC, coBook, coYear: '2024-2025' }) as any;
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
         VALUES ($1,$2,$3,'G82SUP','G82 Supplier','L'),($1,$2,$3,'G82CUS','G82 Customer','L')`,
        tenantId,
        CO,
        LC,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
         VALUES ($1,$2,'G82','G82 Gold','SALES','PURCHASE')`,
        tenantId,
        CO,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
         VALUES ($1,$2,'G82IT','G82 Item','G','G82')`,
        tenantId,
        CO,
      );
    });
    const line = { itCode: 'G82IT', pcs: 1, grossWt: 2, netWt: 2, touch: 90, metalAmount: 1000 };
    const common = { vchDate: '2024-04-10', taxRatePct: 3, taxCode: '10', interState: false };
    const purchase = await createPurchase(
      prisma,
      { ...common, scope: scopeFor('PR'), acCode: 'G82SUP', acName: 'G82 Supplier' } as any,
      [{ ...line, metal: 'G' }] as any,
    );
    const sale = await createSale(
      prisma,
      { ...common, scope: scopeFor('SL'), acCode: 'G82CUS', acName: 'G82 Customer' } as any,
      [line] as any,
    );
    const taxAccounts = async (book: string, vchNo: number) =>
      (
        (await withTenant(prisma, tenantId, (tx: any) =>
          tx.$queryRawUnsafe(
            `SELECT DISTINCT "AC_CODE" AS ac FROM "AC_DATA"
              WHERE "CO_CODE"=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "AC_CODE" IN ('GST','GSTINPUT')`,
            CO,
            book,
            String(vchNo).padStart(5, '0'),
          ),
        )) as Array<{ ac: string }>
      ).map((r) => r.ac);
    expect(await taxAccounts('PR', purchase.vchNo)).toEqual(['GSTINPUT']);
    expect(await taxAccounts('SL', sale.vchNo)).toEqual(['GST']);
  });

  /**
   * A sale entered BY RATE (no tax code) on a provisioned company resolves the code's PARENT row, so it is that
   * code and its component rows apply: Ac_Tax.cs writes TAX_DATA from `C.TAX_GROUP` / `C.TAX_PRC` at
   * `C.SR_NO = 1` (SGST, TAX_AMT/2) and `C.SR_NO = 2` (CGST, TAX_AMT/2) for every sale, and the sale header
   * already stores the resolved code. Found in the G83 browser check: the rows carried the parent group 'N'.
   */
  it('writes SGST/CGST tax rows for a sale entered by rate on a provisioned company (G82)', async () => {
    const scope = { tenantId, coCode: CO, lcCode: LC, coBook: 'SL', coYear: '2024-2025' } as any;
    const sale = await createSale(
      prisma,
      {
        scope,
        acCode: 'G82CUS',
        acName: 'G82 Customer',
        vchDate: '2024-04-11',
        taxRatePct: 3,
        interState: false,
      } as any,
      [{ itCode: 'G82IT', pcs: 1, grossWt: 1, netWt: 1, touch: 90, metalAmount: 1000 }] as any,
    );
    const rows = (await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "SR_NO"::int AS sr, "TAX_CODE" AS code, "TAX_TYPE" AS type,
                coalesce("TAX_PRC",0)::float AS prc, coalesce("TAX_AMT",0)::float AS amt
           FROM "TAX_DATA" WHERE "CO_CODE"=$1 AND "CO_BOOK"='SL' AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
        CO,
        String(sale.vchNo).padStart(5, '0'),
      ),
    )) as Array<Record<string, unknown>>;
    // 1000 taxable at 3%: 30 tax, 15 + 15.
    expect(rows).toEqual([
      { sr: 1, code: '10', type: 'SGST', prc: 1.5, amt: 15 },
      { sr: 2, code: '10', type: 'CGST', prc: 1.5, amt: 15 },
    ]);
  });
});
