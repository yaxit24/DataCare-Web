import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

/**
 * G169 over HTTP: a sale whose lines belong to two item groups with different income accounts.
 *
 * Before the fix the save failed with `duplicate key … AC_DATA_tenant_ledr_key_key`: both revenue legs were
 * keyed `…03`. Desktop authority: `Ac_Ledr.cs:90` (Sales_Ledr line path) credits each SL_DETL line's
 * `GROUP_MAST.SALE_AC` with `A.NET_AMT`, keyed `VCH_NO + STR(A.SR_NO) + <code>`.
 *
 * Expected rows are hand-computed from the desktop rules (the feature suite's lines A and B):
 *   gold   10 g net × 6,123.45 = 61,234.5 → 61,234 + making 237.50/g × 10 g = 2,375 → line net 63,609 (SALES)
 *   silver 50 g net × 85.50    =  4,275                                     → line net  4,275 (SLVSALE)
 *   (line amounts are whole rupees, Math.Round half to even: TR_SALE.cs:10343-10362)
 *   taxable 67,884; GST 3% = 2,036.52; total 69,920.52; no round-off (2 dp policy)
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'sale-2grp-revenue-db';
const PASSWORD = 'Two-Group-Revenue!2026';
const SECRET = 'two-group-revenue-route-test-signing-secret-32ch';
const LOGIN = 'counter';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

const GOLD_LINE = {
  itCode: 'GLD01',
  pcs: 1,
  grossWt: 10.25,
  netWt: 10,
  touch: 91.6,
  rate: 6123.45,
  labourType: 'per_gram',
  labourRate: 237.5,
};
const SILVER_LINE = { itCode: 'SLV01', pcs: 2, grossWt: 50.4, netWt: 50, touch: 92.5, rate: 85.5 };

/**
 * The key head is CO_CODE + LC_CODE + CO_YEAR + CO_BOOK + VCH_NO(5). The web-provisioned sale book is `SL`, two
 * characters rather than the desktop's three-digit book (provisioning convention, N58), so the head here is
 * 20 characters and a desktop-shaped key 23/33; the assertions below are on the TAIL after the head.
 */
const BOOK = 'SL';
const headOf = (vchNo: string) => `0101${YEAR}${BOOK}${vchNo}`;

(enabled ? describe : describe.skip)('G169 two-group sale revenue legs over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const call = (method: 'POST' | 'PUT' | 'GET' | 'DELETE', url: string, payload?: unknown) =>
    app.inject({ method, url, headers: { cookie }, payload: payload as any });
  const sale = (lines: unknown[], extra: Record<string, unknown> = {}) => ({
    coBook: BOOK,
    acCode: 'CUST01',
    vchDate: DAY,
    taxRatePct: 3,
    interState: false,
    lines,
    ...extra,
  });
  /** The voucher's AC_DATA rows; `tail` is the key after the head, which every key must start with. */
  const ledger = async (vchNo: string) => {
    const rows = (await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY" k,"AC_CODE" ac,"LD_CODE" ld,"DR_AMT"::float dr,"CR_AMT"::float cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
        ORDER BY length("LEDR_KEY"), "LEDR_KEY" COLLATE "C"`,
      tenantId,
      BOOK,
      vchNo,
    )) as Array<{ k: string; ac: string; ld: string; dr: number; cr: number }>;
    const head = headOf(vchNo);
    for (const row of rows) expect(row.k.startsWith(head), row.k).toBe(true);
    return rows.map((row) => ({ ...row, tail: row.k.slice(head.length) }));
  };
  const create = async (payload: unknown) => {
    const saved = await call('POST', '/sales', payload);
    expect(saved.statusCode, saved.body).toBe(201);
    return String(saved.json().vchNo).padStart(5, '0');
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    // The installer CO_SET_NEW seeded into the company has TOT_AMT_ROF 0 (whole-rupee totals, and so a round-off
    // leg). This suite's measured totals have no round-off (2 dp policy), a setting the desktop offers (0/1/2).
    await exec(
      `UPDATE "CO_SET_NEW" SET "TOT_AMT_ROF"=2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    // F02 sample data: each group names its own income account (GROUP_MAST.SALE_AC).
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,'01','E1','E2E GOLD','SALES','PURCHASE'),($1,'01','E2','E2E SILVER','SLVSALE','SLVPURC')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,'01','GLD01','GOLD 22K ORNAMENT','G','E1'),($1,'01','SLV01','SILVER 925 ORNAMENT','S','E2'),
              ($1,'01','GLD02','GOLD 22K CHAIN','G','E1')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','CUST01','LOCAL CUSTOMER','L','10')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Transaction','Sales Invoice','Y','Y','Y','Y')`,
      tenantId,
      LOGIN,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('T05 create: one revenue leg per line on its group account, party and tax unchanged, balanced', async () => {
    const vchNo = await create(sale([GOLD_LINE, SILVER_LINE]));
    const rows = await ledger(vchNo);
    expect(
      rows.map((r) => ({
        tail: r.tail,
        tailLength: r.tail.length,
        ac: r.ac,
        ld: r.ld,
        dr: r.dr,
        cr: r.cr,
      })),
    ).toEqual([
      // Party leg: the measured 2-character tail 01; its contra is the book's slot-1 account (Ac_Ledr.cs:64).
      { tail: '01', tailLength: 2, ac: 'CUST01', ld: 'SALES', dr: 69920.52, cr: 0 },
      // Tax leg: measured tail 04 (account: the documented GST default while TAX_MAST.TAX_AC is unset).
      { tail: '04', tailLength: 2, ac: 'GST', ld: 'CUST01', dr: 0, cr: 2036.52 },
      // Per-line revenue legs: STR(SR_NO) right-aligned in 10, then the revenue code 03 (12-character tail).
      { tail: '         103', tailLength: 12, ac: 'SALES', ld: 'CUST01', dr: 0, cr: 63609 },
      { tail: '         203', tailLength: 12, ac: 'SLVSALE', ld: 'CUST01', dr: 0, cr: 4275 },
    ]);
    const dr = rows.reduce((s, r) => s + r.dr, 0);
    const cr = rows.reduce((s, r) => s + r.cr, 0);
    expect(Math.round(dr * 100)).toBe(Math.round(cr * 100));
    // The detail lines carry the same amounts the revenue legs credit (Ac_Ledr.cs:90 credits A.NET_AMT).
    const details = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr,"IT_CODE" it,"NET_AMT"::float net FROM "SL_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      tenantId,
      BOOK,
      vchNo,
    )) as Array<{ sr: number; it: string; net: number }>;
    expect(details).toEqual([
      { sr: 1, it: 'GLD01', net: 63609 },
      { sr: 2, it: 'SLV01', net: 4275 },
    ]);
  });

  it('T08 reopen and unchanged save: the voucher ledger is identical afterwards', async () => {
    const payload = sale([GOLD_LINE, SILVER_LINE]);
    const vchNo = await create(payload);
    const reopened = await call('GET', `/sales/${vchNo}?coBook=${BOOK}`);
    expect(reopened.statusCode, reopened.body).toBe(200);
    expect((reopened.json().lines as unknown[]).length).toBe(2);
    const before = await ledger(vchNo);
    const saved = await call('PUT', `/sales/${vchNo}`, {
      ...payload,
      expectedVersion: reopened.json().version,
    });
    expect(saved.statusCode, saved.body).toBe(200);
    expect(await ledger(vchNo)).toEqual(before);
  });

  it('T09 edit: re-pricing the silver line moves only its own revenue leg, the tax and the party leg', async () => {
    const vchNo = await create(sale([GOLD_LINE, SILVER_LINE]));
    // Silver rate 85.50 → 90.00: 50 g × 90 = 4,500.00; taxable 68,109; GST 3% = 2,043.27; total 70,152.27.
    const { version } = (await call('GET', `/sales/${vchNo}?coBook=${BOOK}`)).json();
    const edited = await call('PUT', `/sales/${vchNo}`, {
      ...sale([GOLD_LINE, { ...SILVER_LINE, rate: 90 }]),
      expectedVersion: version,
    });
    expect(edited.statusCode, edited.body).toBe(200);
    const rows = await ledger(vchNo);
    expect(rows.map((r) => [r.tail, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'CUST01', 70152.27, 0],
      ['04', 'GST', 0, 2043.27],
      ['         103', 'SALES', 0, 63609],
      ['         203', 'SLVSALE', 0, 4500],
    ]);
  });

  it('T03 bill discount: the per-line legs share the taxable amount and still sum to it exactly', async () => {
    // Line amounts are whole rupees (TR_SALE.cs:10343-10362): gold 63,609, silver 4,275, net 67,884.
    // Discount 884 → taxable 67,000.00; GST 3% = 2,010.00; total 69,010.00.
    // Gold 67,000 × 63,609 / 67,884 = 62,780.6699… → 62,780.67; silver the remainder 4,219.33
    // (independently 4,219.3300… → 4,219.33).
    const vchNo = await create(sale([GOLD_LINE, SILVER_LINE], { discountAmount: 884 }));
    const rows = await ledger(vchNo);
    expect(rows.map((r) => [r.tail, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'CUST01', 69010, 0],
      ['04', 'GST', 0, 2010],
      ['         103', 'SALES', 0, 62780.67],
      ['         203', 'SLVSALE', 0, 4219.33],
    ]);
  });

  it('control: two lines on ONE account keep the measured single revenue leg (2-character tail 03)', async () => {
    // Two gold lines in group E1: 63,609 + 63,609 = 127,218.00; GST 3% = 3,816.54; total 131,034.54.
    const vchNo = await create(sale([GOLD_LINE, { ...GOLD_LINE, itCode: 'GLD02' }]));
    const rows = await ledger(vchNo);
    expect(rows.map((r) => [r.tail, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'CUST01', 131034.54, 0],
      ['03', 'SALES', 0, 127218],
      ['04', 'GST', 0, 3816.54],
    ]);
  });

  it('cash tender: the settlement pair keeps its measured codes 19/20 beside the per-line revenue legs', async () => {
    const vchNo = await create(sale([GOLD_LINE, SILVER_LINE], { cashAmt: 10000 }));
    const rows = await ledger(vchNo);
    expect(rows.map((r) => [r.tail, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'CUST01', 69920.52, 0],
      ['04', 'GST', 0, 2036.52],
      ['19', 'CUST01', 0, 10000],
      ['20', 'CASH', 10000, 0],
      ['         103', 'SALES', 0, 63609],
      ['         203', 'SLVSALE', 0, 4275],
    ]);
  });

  it('T10 delete: every ledger leg of the two-group voucher is reversed and DELETE_DATA is written', async () => {
    const vchNo = await create(sale([GOLD_LINE, SILVER_LINE]));
    const before = await snapshotTenant(owner, tenantId);
    const { version } = (await call('GET', `/sales/${vchNo}?coBook=${BOOK}`)).json();
    const deleted = await call(
      'DELETE',
      `/sales/${vchNo}?coBook=${BOOK}&expectedVersion=${version}`,
    );
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(await ledger(vchNo)).toEqual([]);
    const diff = diffTenant(before, await snapshotTenant(owner, tenantId));
    const removedLedger = (diff.removed.AC_DATA ?? []).filter(
      (row) => row.CO_BOOK === BOOK && row.VCH_NO === vchNo,
    );
    expect(
      removedLedger.map((row) => String(row.LEDR_KEY).slice(headOf(vchNo).length)).sort(),
    ).toEqual(['01', '04', '         103', '         203'].sort());
    expect((diff.added.DELETE_DATA ?? []).length).toBeGreaterThan(0);
    expect(diff.added.AC_DATA ?? []).toEqual([]);
  });
});
