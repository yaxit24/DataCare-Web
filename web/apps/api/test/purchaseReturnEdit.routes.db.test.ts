import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { diffTenant, snapshotTenant, type TenantDiff } from './support/tenantSnapshot.js';

/**
 * N34 / G47 — the Purchase Return edit lifecycle over HTTP.
 *
 * Desktop authority: TR_KR_ISU in PURC RETURN mode saves a new and a reopened voucher through one handler
 * (BtnSave_Click, TR_KR_ISU.cs:4928-5355). On edit it keeps the voucher number, the hidden number (:4623), the
 * creator (:4689 -> :5126) and the time of day (:4622 -> :5123), deletes and re-posts the whole write set
 * (:5033-5035, :5240-5285) and writes no DELETE_DATA row; it refuses a date outside the year (:4964-4969) or on
 * or before the lock date (:4970-4975).
 *
 * Expected values are derived here from the desktop rules — fine = (net + ghat) x touch / 100, metal = fine x
 * rate, per-gram labour = (net + ghat) x rate, 3% GST split in halves — never read back from the web's output.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'prt-edit-route';
const otherTenant = 'prt-edit-route-sentinel';
const PASSWORD = 'Purchase-Return-Edit!2026';
const SECRET = 'purchase-return-edit-signing-secret-over-thirty-two-chars';
const CREATOR = 'returnclerk';
const EDITOR = 'editclerk';
const VIEWER = 'viewclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const MOVED_DAY = `${startYear}-06-20`;
const BOOK = '348';

/** Rows of every tenant table without the surrogate key, which a delete-and-reinsert renumbers. */
async function stableSnapshot(owner: PrismaClient, tenant: string) {
  const raw = await snapshotTenant(owner, tenant);
  return new Map(
    [...raw].map(([table, rows]) => [
      table,
      rows
        .map((row) => {
          const { row_id: _surrogate, ...rest } = JSON.parse(row) as Record<string, unknown>;
          return JSON.stringify(rest);
        })
        .sort(),
    ]),
  );
}

const rowsOf = (diff: TenantDiff) =>
  [...Object.entries(diff.added), ...Object.entries(diff.removed)].flatMap(([table, rows]) =>
    rows.map((row) => ({ table, row })),
  );

/**
 * Splits off the web's request log. `audit_log` gains one row per mutating request (refused ones included);
 * it is not part of the voucher's write set, so it is asserted on its own rather than ignored.
 */
const splitAudit = (diff: TenantDiff) => {
  const { audit_log: audits = [], ...added } = diff.added;
  return { business: { added, removed: diff.removed }, audits };
};

(enabled ? describe : describe.skip)('Purchase Return edit lifecycle over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  let vchNo = '';
  let hiddenNo = '';
  let clock = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      for (const tenant of [tenantId, otherTenant])
        await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
  };
  const request = (
    user: string,
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    payload?: unknown,
  ) =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[user] ?? '' },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const scopeQuery = `coBook=${BOOK}&coYear=${YEAR}&lcCode=01`;
  const reopen = async () => {
    const read = await request(CREATOR, 'GET', `/purchase-returns/${vchNo}?${scopeQuery}`);
    expect(read.statusCode, read.body).toBe(200);
    return read.json() as Record<string, any>;
  };
  /** What a client sends back for a reopened voucher: every field the API returned. */
  const payloadOf = (view: Record<string, any>, overrides: Record<string, unknown> = {}) => ({
    coBook: BOOK,
    vchDate: view.vchDate,
    acCode: view.acCode,
    acName: view.acName || undefined,
    billNo: view.billNo || undefined,
    origVchNo: view.origVchNo || undefined,
    origBook: view.origBook || undefined,
    origYear: view.origYear || undefined,
    taxRatePct: view.taxRatePct,
    taxCode: view.taxCode || undefined,
    interState: view.interState,
    discountAmount: view.discountAmount,
    cashAmt: view.cashAmt,
    chequeAmt: view.chequeAmt,
    cardAmt: view.cardAmt,
    kasar: view.kasar,
    bankAc: view.bankAc || undefined,
    lines: view.lines,
    ...overrides,
  });
  const header = async () =>
    (
      await query<Array<Record<string, unknown>>>(
        `SELECT "VCH_NO","HD_VCH_NO","MAIN_USER","VCH_DATE"::text AS "VCH_DATE",
                to_char("VCH_TIME",'HH24:MI:SS.MS') AS clock,"VCH_TIME"::date::text AS time_day,
                "NET_AMT"::float8,"TAX_AMT"::float8,"CGST_TAX"::float8,"SGST_TAX"::float8,
                "ROF_AMT"::float8,"TOT_AMT"::float8,"BILL_OS"::float8
           FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_YEAR"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4`,
        tenantId,
        YEAR,
        BOOK,
        vchNo,
      )
    )[0];
  const tagBalance = async () =>
    (
      await query<Array<{ n: number }>>(
        `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int n FROM "MAIN_STOCK"
          WHERE tenant_id=$1 AND "TAG_NO"='TGR1' AND "VCH_SRNO"=1 AND "IT_CODE"='GOLD'`,
        tenantId,
      )
    )[0]?.n;
  /** Every changed row must belong to the return under test: nothing else in the tenant moves. */
  const expectConfinedToVoucher = (diff: TenantDiff) => {
    for (const { table, row } of rowsOf(diff)) {
      if (table === 'TEMP_BOOK_DATA') {
        expect(row, table).toMatchObject({ CO_BOOK: BOOK, VCH_NO: hiddenNo });
        continue;
      }
      expect(row, table).toMatchObject({ CO_YEAR: YEAR, CO_BOOK: BOOK, VCH_NO: vchNo });
    }
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','SUPP01','Return Supplier','L','40')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC")
       VALUES ($1,'01','G01','Gold','PURCHASE')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","OTH_DETL_POSTING")
       VALUES ($1,'01','GOLD','Gold Ornament','G','G01','Y')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01',$2,'Purchase Return 348','P348','PURC RETURN','O','Y','PR_DATA')`,
      tenantId,
      BOOK,
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,'01','01',$2,1,'PURCHASE','PURC RETURN','O'),
              ($1,'01','01',$2,2,'CASH','PURC RETURN','O'),
              ($1,'01','01',$2,3,'ROUNDOFF','PURC RETURN','O')`,
      tenantId,
      BOOK,
    );
    // The original purchase the tagged line comes back from (a fixture, not the voucher under test). It
    // carries the same visible number the first return will get, so it is also a same-number sentinel.
    await exec(
      `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","VCH_DATE","TOT_AMT")
       VALUES ($1,'01','01',$2,'PR','00001','SUPP01',$3::date,6000)`,
      tenantId,
      YEAR,
      DAY,
    );
    await exec(
      `INSERT INTO "PR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',1,'GOLD','TGR1',1,1,5.2,5)`,
      tenantId,
      YEAR,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH")
       VALUES ($1,'01','01',$2,'PR','00001',1,'GOLD','TGR1',1,1,5.2,5,80)`,
      tenantId,
      YEAR,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',1,$3::date,'GOLD','TGR1',1,'I','+',1,5.2,5)`,
      tenantId,
      YEAR,
      DAY,
    );
    // Same number and book in another year, and the same complete key in another tenant.
    await exec(
      `INSERT INTO "PR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","TOT_AMT")
       VALUES ($1,'01','01','2019-2020',$2,'00001','SUPP01',111),
              ($3,'01','01',$4,$2,'00001','SUPP01',222)`,
      tenantId,
      BOOK,
      otherTenant,
      YEAR,
    );
    for (const [login, update] of [
      [CREATOR, 'Y'],
      [EDITOR, 'Y'],
      [VIEWER, 'N'],
    ] as const) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER',$4,'Y','Y','N')`,
        tenantId,
        login,
        await hashPassword(PASSWORD),
        update,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Purchase','Purchase Return','Y',$3,'Y','Y')`,
        tenantId,
        login,
        update,
      );
    }
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const login of [CREATOR, EDITOR, VIEWER]) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: login, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookies[login] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }

    const saved = await request(CREATOR, 'POST', '/purchase-returns', {
      coBook: BOOK,
      vchDate: DAY,
      acCode: 'SUPP01',
      acName: 'Return Supplier',
      origBook: 'PR',
      origYear: YEAR,
      origVchNo: '00001',
      taxRatePct: 3,
      interState: false,
      lines: [
        {
          itCode: 'GOLD',
          tagNo: 'TGR1',
          vchSrno: 1,
          pcs: 1,
          grossWt: 5.2,
          netWt: 5,
          touch: 80,
          rate: 1500,
          labourType: 'per_gram',
          labourRate: 40,
        },
        {
          itCode: 'GOLD',
          pcs: 2,
          grossWt: 2.5,
          netWt: 2.5,
          touch: 80,
          rate: 1900,
          designNo: 'D-7',
          lotNo: 'LT1',
          itmLot: 'IL1',
          withStock: 'Y',
          convRate: 1.5,
          convPct: 2,
          commissionAmount: 12.5,
          fineCutPcs: 1,
          fineCutGrossWt: 0.5,
          fineCutNetWt: 0.4,
          fineCutFine: 0.32,
          rateType: 'F',
          urdRateType: 'U',
          prCode: 'PC',
        },
      ],
    });
    expect(saved.statusCode, saved.body).toBe(201);
    vchNo = String(saved.json().vchNo).padStart(5, '0');
    const created = await header();
    hiddenNo = String(created?.HD_VCH_NO ?? '');
    clock = String(created?.clock ?? '');
  }, 60_000);

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('creates the independently derived write set and takes the tag out of stock', async () => {
    // Line 1: fine 5 x 80 / 100 = 4.000, metal 4 x 1500 = 6000, labour 5 x 40 = 200 -> 6200.
    // Line 2: fine 2.5 x 80 / 100 = 2.000, metal 2 x 1900 = 3800 -> 3800. Total 10000 + 3% (150 + 150).
    expect(await header()).toMatchObject({
      VCH_NO: vchNo,
      MAIN_USER: CREATOR,
      VCH_DATE: DAY,
      NET_AMT: 10000,
      TAX_AMT: 300,
      CGST_TAX: 150,
      SGST_TAX: 150,
      ROF_AMT: 0,
      TOT_AMT: 10300,
      BILL_OS: 10300,
    });
    expect(hiddenNo).toMatch(/^\d{5}$/);
    const lines = await query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO"::int,"TAG_NO","VCH_SRNO"::int,"ITM_FINE"::float8,"ITM_AMT"::float8,
              "LBR_TYPE","LBR_RATE"::float8,"LBR_AMT"::float8,"NET_AMT"::float8,"MAIN_USER","HD_VCH_NO"
         FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "CO_YEAR"=$4
        ORDER BY "SR_NO"`,
      tenantId,
      BOOK,
      vchNo,
      YEAR,
    );
    expect(lines).toEqual([
      {
        SR_NO: 1,
        TAG_NO: 'TGR1',
        VCH_SRNO: 1,
        ITM_FINE: 4,
        ITM_AMT: 6000,
        // Desktop basis code for per-gram labour (net wise), not the first letter of the web mode.
        LBR_TYPE: 'N',
        LBR_RATE: 40,
        LBR_AMT: 200,
        NET_AMT: 6200,
        MAIN_USER: CREATOR,
        HD_VCH_NO: hiddenNo,
      },
      {
        SR_NO: 2,
        TAG_NO: 'N',
        VCH_SRNO: 0,
        ITM_FINE: 2,
        ITM_AMT: 3800,
        // An empty labour-basis cell: TR_KR_ISU writes grid column 26 as it stands (:5197), i.e. ''.
        LBR_TYPE: '',
        LBR_RATE: 0,
        LBR_AMT: 0,
        NET_AMT: 3800,
        MAIN_USER: CREATOR,
        HD_VCH_NO: hiddenNo,
      },
    ]);
    const [legs] = await query<Array<{ dr: number; cr: number; party: number; purchase: number }>>(
      `SELECT sum("DR_AMT")::float8 dr, sum("CR_AMT")::float8 cr,
              sum(CASE WHEN "AC_CODE"='SUPP01' THEN "DR_AMT" ELSE 0 END)::float8 party,
              sum(CASE WHEN "AC_CODE"='PURCHASE' THEN "CR_AMT" ELSE 0 END)::float8 purchase
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "CO_YEAR"=$4`,
      tenantId,
      BOOK,
      vchNo,
      YEAR,
    );
    expect(legs).toEqual({ dr: 10300, cr: 10300, party: 10300, purchase: 10000 });
    expect(await tagBalance()).toBe(0);
  });

  it('reopens every persisted field, and an unchanged save changes no row anywhere', async () => {
    const view = await reopen();
    expect(view).toMatchObject({
      voucherNo: vchNo,
      hiddenVoucherNo: hiddenNo,
      mainUser: CREATOR,
      vchDate: DAY,
      origVchNo: '00001',
      origBook: 'PR',
      origYear: YEAR,
    });
    expect(view.lines[0]).toMatchObject({ tagNo: 'TGR1', vchSrno: 1, labourType: 'per_gram' });
    expect(view.lines[1]).toMatchObject({
      tagNo: '',
      metal: '',
      designNo: 'D-7',
      lotNo: 'LT1',
      itmLot: 'IL1',
      withStock: 'Y',
      convRate: 1.5,
      convPct: 2,
      commissionAmount: 12.5,
      fineCutPcs: 1,
      fineCutGrossWt: 0.5,
      fineCutNetWt: 0.4,
      fineCutFine: 0.32,
      rateType: 'F',
      urdRateType: 'U',
      prCode: 'PC',
    });

    const before = await stableSnapshot(owner, tenantId);
    const saved = await request(EDITOR, 'PUT', `/purchase-returns/${vchNo}`, payloadOf(view));
    expect(saved.statusCode, saved.body).toBe(200);
    expect(saved.json()).toMatchObject({ vchNo: Number(vchNo), totals: { total: 10300 } });
    const { business, audits } = splitAudit(
      diffTenant(before, await stableSnapshot(owner, tenantId)),
    );
    expect(business).toEqual({ added: {}, removed: {} });
    expect(audits).toMatchObject([
      { action: 'PUT', path: '/purchase-returns/:vchNo', status: 200, login_name: EDITOR },
    ]);
  });

  it('an edit of one line changes only that line and its effects, and keeps the identity', async () => {
    const view = await reopen();
    const before = await stableSnapshot(owner, tenantId);
    const lines = view.lines.map((line: Record<string, unknown>, index: number) => {
      if (index !== 1) return line;
      // The operator changes the net weight; fine and metal are derived again, as on the screen.
      const { fineWt: _fine, metalAmount: _metal, ...rest } = line;
      return { ...rest, netWt: 3.75 };
    });
    const saved = await request(EDITOR, 'PUT', `/purchase-returns/${vchNo}`, {
      ...payloadOf(view),
      lines,
    });
    expect(saved.statusCode, saved.body).toBe(200);
    const { business: diff, audits } = splitAudit(
      diffTenant(before, await stableSnapshot(owner, tenantId)),
    );
    expect(audits).toHaveLength(1);
    expectConfinedToVoucher(diff);
    // Line 1 and the hidden-number row are untouched; no audit row of any kind is written by an edit.
    expect(diff.added.PR_DETL?.map((row) => row.SR_NO)).toEqual([2]);
    expect(diff.added.MAIN_STOCK?.map((row) => row.SR_NO)).toEqual([2]);
    expect(diff.added.TEMP_BOOK_DATA).toBeUndefined();
    expect(diff.added.DELETE_DATA).toBeUndefined();
    expect(diff.added.USER_DATA).toBeUndefined();
    expect(diff.added.BAR_DETL).toBeUndefined();
    // Line 2: fine 3.75 x 80 / 100 = 3.000, metal 3 x 1900 = 5700. Total 11900 + 3% (178.50 + 178.50).
    const changed = diff.added.PR_DETL?.[0] ?? {};
    expect(
      Object.fromEntries(
        ['ITM_NWT', 'ITM_FINE', 'ITM_AMT', 'NET_AMT'].map((column) => [
          column,
          Number(changed[column]),
        ]),
      ),
    ).toEqual({ ITM_NWT: 3.75, ITM_FINE: 3, ITM_AMT: 5700, NET_AMT: 5700 });
    expect(await header()).toMatchObject({
      VCH_NO: vchNo,
      HD_VCH_NO: hiddenNo,
      MAIN_USER: CREATOR,
      clock,
      NET_AMT: 11900,
      TAX_AMT: 357,
      CGST_TAX: 178.5,
      SGST_TAX: 178.5,
      ROF_AMT: 0,
      TOT_AMT: 12257,
    });
    const [legs] = await query<Array<{ dr: number; cr: number; party: number }>>(
      `SELECT sum("DR_AMT")::float8 dr, sum("CR_AMT")::float8 cr,
              sum(CASE WHEN "AC_CODE"='SUPP01' THEN "DR_AMT" ELSE 0 END)::float8 party
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "CO_YEAR"=$4`,
      tenantId,
      BOOK,
      vchNo,
      YEAR,
    );
    expect(legs).toEqual({ dr: 12257, cr: 12257, party: 12257 });
    expect(await tagBalance()).toBe(0);
  });

  it('moves the date but keeps the number, hidden number, creator and time of day', async () => {
    const view = await reopen();
    const saved = await request(
      EDITOR,
      'PUT',
      `/purchase-returns/${vchNo}`,
      payloadOf(view, { vchDate: MOVED_DAY }),
    );
    expect(saved.statusCode, saved.body).toBe(200);
    expect(await header()).toMatchObject({
      VCH_NO: vchNo,
      HD_VCH_NO: hiddenNo,
      MAIN_USER: CREATOR,
      VCH_DATE: MOVED_DAY,
      time_day: MOVED_DAY,
      clock,
      TOT_AMT: 12257,
    });
    const [rows] = await query<Array<{ stale: number; temp: number; audits: number }>>(
      `SELECT
         (SELECT count(*)::int FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
            AND "CO_YEAR"=$4 AND "VCH_DATE"::date<>$5::date) stale,
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2
            AND "VCH_NO"=$6) temp,
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1) audits`,
      tenantId,
      BOOK,
      vchNo,
      YEAR,
      MOVED_DAY,
      hiddenNo,
    );
    expect(rows).toEqual({ stale: 0, temp: 1, audits: 0 });
  });

  it('refuses locked, out-of-year, unauthorised, missing and wrong-book edits without changes', async () => {
    const view = await reopen();
    const before = await stableSnapshot(owner, tenantId);
    const put = (user: string, payload: unknown, voucher = vchNo) =>
      request(user, 'PUT', `/purchase-returns/${voucher}`, payload);
    const setLock = (day: string | null) =>
      exec(
        `UPDATE "CO_SET" SET "LOCK_DATE"=$1::date WHERE tenant_id=$2 AND "CO_CODE"='01'`,
        day,
        tenantId,
      );

    // Persisted date locked: the voucher may not be moved out of its locked period.
    await setLock(MOVED_DAY);
    const lockedOld = await put(EDITOR, payloadOf(view, { vchDate: `${startYear}-07-01` }));
    expect(lockedOld.statusCode, lockedOld.body).toBe(400);
    expect(lockedOld.json().error).toBe('PeriodLockValidationError');
    // Requested date locked although the persisted one is open.
    await setLock(`${startYear}-06-10`);
    const lockedNew = await put(EDITOR, payloadOf(view, { vchDate: `${startYear}-06-05` }));
    expect(lockedNew.statusCode, lockedNew.body).toBe(400);
    expect(lockedNew.json().error).toBe('PeriodLockValidationError');
    await setLock(null);

    const outOfYear = await put(EDITOR, payloadOf(view, { vchDate: `${startYear + 1}-04-15` }));
    expect(outOfYear.statusCode, outOfYear.body).toBe(400);
    expect(outOfYear.json().error).toBe('FiscalDateValidationError');

    const viewer = await put(VIEWER, payloadOf(view));
    expect(viewer.statusCode, viewer.body).toBe(403);

    const missing = await put(EDITOR, payloadOf(view), '00099');
    expect(missing.statusCode, missing.body).toBe(400);
    expect(missing.json().message).toMatch(/purchase return not found: 00099/);

    // Book PR is a purchase book: the edit must not rewrite a purchase through the return writer.
    const wrongBook = await put(EDITOR, payloadOf(view, { coBook: 'PR' }), '00001');
    expect(wrongBook.statusCode, wrongBook.body).toBe(400);
    expect(wrongBook.json().error).toBe('BookPolicyValidationError');

    const { business, audits } = splitAudit(
      diffTenant(before, await stableSnapshot(owner, tenantId)),
    );
    expect(business).toEqual({ added: {}, removed: {} });
    expect(audits.every((row) => Number(row.status) >= 400)).toBe(true);
  });

  it('refuses a UPI refund, which neither the desktop tender nor PR_DATA can hold', async () => {
    const view = await reopen();
    const before = await stableSnapshot(owner, tenantId);
    for (const [method, url] of [
      ['PUT', `/purchase-returns/${vchNo}`],
      ['POST', '/purchase-returns'],
    ] as const) {
      const refused = await request(
        EDITOR,
        method,
        url,
        payloadOf(view, { upiAmt: 100, bankAc: 'CASH' }),
      );
      expect(refused.statusCode, refused.body).toBe(400);
      expect(refused.json().message).toMatch(/no UPI tender/);
    }
    const { business } = splitAudit(diffTenant(before, await stableSnapshot(owner, tenantId)));
    expect(business).toEqual({ added: {}, removed: {} });
  });

  it('dropping the tagged line puts the tag back in stock, and delete after edits reverses all', async () => {
    const view = await reopen();
    const sentinels = await query<Array<Record<string, unknown>>>(
      `SELECT tenant_id,"CO_YEAR","CO_BOOK","VCH_NO","TOT_AMT"::float8 FROM "PR_DATA"
        WHERE (tenant_id=$1 AND ("CO_YEAR"<>$2 OR "CO_BOOK"<>$3)) OR tenant_id=$4
        ORDER BY tenant_id,"CO_YEAR","CO_BOOK"`,
      tenantId,
      YEAR,
      BOOK,
      otherTenant,
    );
    expect(sentinels).toHaveLength(3);

    const saved = await request(EDITOR, 'PUT', `/purchase-returns/${vchNo}`, {
      ...payloadOf(view),
      lines: [view.lines[1]],
    });
    expect(saved.statusCode, saved.body).toBe(200);
    expect(await tagBalance()).toBe(1);
    const [left] = await query<Array<{ lines: number; issued: number }>>(
      `SELECT (SELECT count(*)::int FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2
                 AND "VCH_NO"=$3 AND "CO_YEAR"=$4) lines,
              (SELECT count(*)::int FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2
                 AND "VCH_NO"=$3 AND "TAG_NO"='TGR1') issued`,
      tenantId,
      BOOK,
      vchNo,
      YEAR,
    );
    expect(left).toEqual({ lines: 1, issued: 0 });

    const removed = await request(CREATOR, 'DELETE', `/purchase-returns/${vchNo}?${scopeQuery}`);
    expect(removed.statusCode, removed.body).toBe(200);
    const [after] = await query<Array<Record<string, number>>>(
      `SELECT ${[
        'PR_DATA',
        'PR_DETL',
        'AC_DATA',
        'TAX_DATA',
        'MAIN_STOCK',
        'DM_DATA',
        'ROJ_MEL_DATA',
      ]
        .map(
          (table) =>
            `(SELECT count(*)::int FROM "${table}" WHERE tenant_id=$1 AND "CO_YEAR"=$2
                AND "CO_BOOK"=$3 AND "VCH_NO"=$4) "${table}"`,
        )
        .join(',')},
         (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"=$5) "TEMP_BOOK_DATA",
         (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$3
            AND "VCH_NO"=$4) "DELETE_DATA"`,
      tenantId,
      YEAR,
      BOOK,
      vchNo,
      hiddenNo,
    );
    expect(after).toEqual({
      PR_DATA: 0,
      PR_DETL: 0,
      AC_DATA: 0,
      TAX_DATA: 0,
      MAIN_STOCK: 0,
      DM_DATA: 0,
      ROJ_MEL_DATA: 0,
      TEMP_BOOK_DATA: 0,
      DELETE_DATA: 1,
    });
    expect(await tagBalance()).toBe(1);
    expect(
      await query(
        `SELECT tenant_id,"CO_YEAR","CO_BOOK","VCH_NO","TOT_AMT"::float8 FROM "PR_DATA"
          WHERE (tenant_id=$1 AND ("CO_YEAR"<>$2 OR "CO_BOOK"<>$3)) OR tenant_id=$4
          ORDER BY tenant_id,"CO_YEAR","CO_BOOK"`,
        tenantId,
        YEAR,
        BOOK,
        otherTenant,
      ),
    ).toEqual(sentinels);
  });
});
