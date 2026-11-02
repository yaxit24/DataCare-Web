import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { approvalReport } from '../src/modules/reports/reportFamilyReports.js';
import { deleteTourReturn, tourIssue, tourReturn } from '../src/modules/tour/tour.js';

/**
 * Approval In Out must reconcile for approvals that the web itself produced.
 *
 * Desktop partition: every APR_DETL issue line is either pending (`ISU_REC = 'N'`, the Pending button,
 * RP_ALL.cs:8302) or resolved (`ISU_REC = 'Y'`, the AprInOut `InPcs` formula). Out - In = Pending must hold
 * for every line. The desktop only ever writes 'N' and 'Y' (TR_APR_ISU.cs:6414 sets 'Y' on a return,
 * :6666 sets 'N' when it is deleted; TR_SALE.cs:16113 sets 'Y' on a sale).
 *
 * The web's Approval Rtn screen is served by the Tour return writer, which closes a returned issue line with
 * 'R' (tour.ts) instead of 'Y'. A report that counts only 'Y' as In would show a returned approval as still
 * outstanding in In Out while the Pending mode, which lists only 'N', no longer shows it. These tests drive the
 * real writers and then both report modes.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const databaseDescribe = RUN ? describe : describe.skip;

const TENANT = 'apr-inout-web-return'; // tenant_id is varchar(24)
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const DAY = '2024-06-10';

const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: 'TUR' };
const reportScope = {
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  fromDate: '2024-06-01',
  toDate: '2024-06-30',
};

databaseDescribe('Approval In Out reconciles web-written approvals with the Pending mode', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const exec = (sql: string, ...p: unknown[]) =>
    withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

  const wipe = async (): Promise<void> => {
    const tables = (await owner.$queryRawUnsafe(
      `SELECT table_name FROM information_schema.columns
        WHERE column_name='tenant_id' AND table_schema='public'`,
    )) as Array<{ table_name: string }>;
    for (const table of tables) {
      await owner.$executeRawUnsafe(`DELETE FROM "${table.table_name}" WHERE tenant_id=$1`, TENANT);
    }
  };

  beforeAll(() => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl) throw new Error('MIGRATE_DATABASE_URL and DATABASE_URL required');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  beforeEach(async () => {
    await wipe();
    await exec(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE") VALUES ($1,$2,NULL)`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA","AC_STATE")
       VALUES ($1,$2,$3,'C001','Surat Customer','Surat','Ring Road','GJ')`,
      TENANT,
      CO,
      LC,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,$2,'GOLD','Gold Ring','G','P1','G01'),
              ($1,$2,'SILV','Silver Chain','S','P2','S01')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME")
       VALUES ($1,$2,'P1','Gold Product'),($1,$2,'P2','Silver Product')`,
      TENANT,
      CO,
    );
    // seedCompany.ts: the web's approval books are TUR / TRR, named APPROVAL ISSUE / APPROVAL RETURN.
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","DATA_TYPE")
       VALUES ($1,$2,$3,'TUR','Approval Issue','APPROVAL ISSUE','A'),
              ($1,$2,$3,'TRR','Approval Return','APPROVAL RETURN','A')`,
      TENANT,
      CO,
      LC,
    );
  });

  const issue = () =>
    tourIssue(runtime, {
      scope,
      vchDate: DAY,
      salesmanAc: 'C001',
      empCode: 'E01',
      mainUser: 'approver',
      lines: [
        { itCode: 'GOLD', tagNo: 'TAGA', pcs: 3, grossWt: 12, netWt: 11, touch: 91.6 },
        { itCode: 'SILV', tagNo: 'TAGB', pcs: 2, grossWt: 20, netWt: 19, touch: 80 },
      ],
    });

  const modes = async () => {
    const inout = await approvalReport(runtime, reportScope, { mode: 'inout' });
    const pending = await approvalReport(runtime, reportScope, { mode: 'pending' });
    // The builder returns a union of row shapes; this test only reads shared, named columns.
    const asRows = (rows: unknown) => rows as Array<Record<string, unknown>>;
    return {
      inout: asRows(inout.rows).map((r) => ({
        tag: r.tagNo,
        out: r.outPcs,
        in: r.inPcs,
        pending: r.pendingPcs,
      })),
      totals: inout.totals,
      pendingTags: asRows(pending.rows).map((r) => r.tagNo),
    };
  };

  it('shows a fresh web issue as fully pending in both modes', async () => {
    await issue();
    const view = await modes();
    expect(view.inout).toEqual([
      { tag: 'TAGA', out: 3, in: 0, pending: 3 },
      { tag: 'TAGB', out: 2, in: 0, pending: 2 },
    ]);
    expect(view.pendingTags).toEqual(['TAGA', 'TAGB']);
  });

  it('counts a line returned through the web Approval Rtn writer as In, and as no longer Pending', async () => {
    const created = await issue();
    await tourReturn(runtime, {
      scope,
      origVchNo: created.vchNo,
      vchDate: DAY,
      salesmanAc: 'C001',
      empCode: 'E01',
      mainUser: 'approver',
      lines: [{ origSrNo: 1, itCode: 'GOLD', tagNo: 'TAGA', pcs: 3, grossWt: 12, netWt: 11 }],
    });

    const view = await modes();
    // Line 1 was returned: Out 3, In 3, Pending 0. Line 2 is still with the party.
    expect(view.inout).toEqual([
      { tag: 'TAGA', out: 3, in: 3, pending: 0 },
      { tag: 'TAGB', out: 2, in: 0, pending: 2 },
    ]);
    expect(view.totals).toMatchObject({ outPcs: 5, inPcs: 3, pendingPcs: 2 });
    // The two modes of the same report family must agree on what is outstanding.
    expect(view.pendingTags).toEqual(['TAGB']);
    const pendingFromInOut = view.inout.filter((r) => Number(r.pending) > 0).map((r) => r.tag);
    expect(pendingFromInOut).toEqual(view.pendingTags);
  });

  it('reopens the line in both modes when the return voucher is deleted', async () => {
    const created = await issue();
    const returned = await tourReturn(runtime, {
      scope,
      origVchNo: created.vchNo,
      vchDate: DAY,
      salesmanAc: 'C001',
      empCode: 'E01',
      mainUser: 'approver',
      lines: [{ origSrNo: 1, itCode: 'GOLD', tagNo: 'TAGA', pcs: 3, grossWt: 12, netWt: 11 }],
    });
    await deleteTourReturn(runtime, { scope, vchNo: returned.vchNo });

    const view = await modes();
    expect(view.inout).toEqual([
      { tag: 'TAGA', out: 3, in: 0, pending: 3 },
      { tag: 'TAGB', out: 2, in: 0, pending: 2 },
    ]);
    expect(view.pendingTags).toEqual(['TAGA', 'TAGB']);
  });
});
