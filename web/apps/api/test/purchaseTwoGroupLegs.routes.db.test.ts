import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

/**
 * G176 over HTTP: a purchase whose lines belong to two item groups with different expense accounts, and a purchase
 * whose labour is posted separately (PURC_WITH_LBR = 'N').
 *
 * Before the fix both failed with `duplicate key … AC_DATA_tenant_ledr_key_key`: every expense leg was keyed with the
 * purchase code 03. Desktop authority: `Ac_Ledr.cs:410` (Purc_Ledr line path) debits each PR_DETL line's
 * `GROUP_MAST.PURC_AC` with `A.NET_AMT`, keyed `VCH_NO + STR(A.SR_NO) + <code>`; `Ac_Ledr.cs:419-421` posts the labour
 * and other charges to the book's slot-4 account when the setting splits them out.
 *
 * Expected rows are hand-computed from the desktop rules (the feature suite's purchase lines; PR_AMT_TYPE 'F', so a
 * line's metal is fine × rate, fine = net × touch / 100 to 3 decimals):
 *   gold   20 g × 91.6% = 18.320 fine × 6,050 = 110,836.00 + making 150/g × 20 g = 3,000.00 → 113,836.00 (PURCHASE)
 *   silver 100 g × 92.5% = 92.500 fine × 80   =   7,400.00                         →   7,400.00 (SLVPURC)
 *   taxable 121,236.00; GST 3% = 3,637.08; total 124,873.08
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'purc-2grp-legs-db';
const PASSWORD = 'Two-Group-Purchase!2026';
const SECRET = 'two-group-purchase-route-test-signing-secret-32';
const LOGIN = 'buyer';
const BOOK = 'PR';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
/** CO_CODE + LC_CODE + CO_YEAR + CO_BOOK + VCH_NO(5); assertions are on the tail after it. */
const headOf = (vchNo: string) => `0101${YEAR}${BOOK}${vchNo}`;

const GOLD = {
  itCode: 'GLD01',
  pcs: 1,
  grossWt: 20.5,
  netWt: 20,
  touch: 91.6,
  rate: 6050,
  labourType: 'per_gram',
  labourRate: 150,
};
const SILVER = { itCode: 'SLV01', pcs: 3, grossWt: 100.4, netWt: 100, touch: 92.5, rate: 80 };

(enabled ? describe : describe.skip)('G176 two-group purchase expense legs over HTTP', () => {
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
  const purchase = (lines: unknown[], extra: Record<string, unknown> = {}) => ({
    coBook: BOOK,
    acCode: 'SUPL',
    vchDate: DAY,
    taxRatePct: 3,
    interState: false,
    lines,
    ...extra,
  });
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
    const saved = await call('POST', '/purchases', payload);
    expect(saved.statusCode, saved.body).toBe(201);
    return String(saved.json().vchNo).padStart(5, '0');
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    // F02 sample data: each group names its own expense account (GROUP_MAST.PURC_AC).
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
       VALUES ($1,'01','01','SUPL','LOCAL SUPPLIER','L','40')`,
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
       VALUES($1,'01','01',$2,'Transaction','Purchase Invoice','Y','Y','Y','Y')`,
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

  it('T05 create: one expense leg per line on its group account; party and tax on their measured codes', async () => {
    const vchNo = await create(purchase([GOLD, SILVER]));
    const rows = await ledger(vchNo);
    expect(rows.map((r) => [r.tail, r.ac, r.ld, r.dr, r.cr])).toEqual([
      // Party 01 Cr the bill; its contra is the book's slot-1 account (Ac_Ledr.cs:377).
      ['01', 'SUPL', 'PURCHASE', 0, 124873.08],
      // Input tax 06 (account: the documented GSTINPUT default while TAX_MAST.TAX_AC is unset).
      ['06', 'GSTINPUT', 'SUPL', 3637.08, 0],
      // Per-line expense legs: STR(SR_NO) right-aligned in 10, then the purchase code 03.
      ['         103', 'PURCHASE', 'SUPL', 113836, 0],
      ['         203', 'SLVPURC', 'SUPL', 7400, 0],
    ]);
    const details = (await owner.$queryRawUnsafe(
      `SELECT "SR_NO"::int sr,"IT_CODE" it,"NET_AMT"::float net FROM "PR_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      tenantId,
      BOOK,
      vchNo,
    )) as Array<{ sr: number; it: string; net: number }>;
    expect(details).toEqual([
      { sr: 1, it: 'GLD01', net: 113836 },
      { sr: 2, it: 'SLV01', net: 7400 },
    ]);
  });

  it('T08 reopen and unchanged save: the voucher ledger is identical afterwards', async () => {
    const payload = purchase([GOLD, SILVER]);
    const vchNo = await create(payload);
    const reopened = await call('GET', `/purchases/${vchNo}?coBook=${BOOK}`);
    expect(reopened.statusCode, reopened.body).toBe(200);
    const before = await ledger(vchNo);
    const saved = await call('PUT', `/purchases/${vchNo}`, {
      ...payload,
      expectedVersion: reopened.json().version,
    });
    expect(saved.statusCode, saved.body).toBe(200);
    expect(await ledger(vchNo)).toEqual(before);
  });

  it('T09 edit: re-pricing the silver line moves only its leg, the tax and the party leg', async () => {
    const vchNo = await create(purchase([GOLD, SILVER]));
    // Silver rate 80 → 85: 92.5 × 85 = 7,862.50; taxable 121,698.50; GST 3% = 3,650.955 → 3,650.96; total 125,349.46.
    const { version } = (await call('GET', `/purchases/${vchNo}?coBook=${BOOK}`)).json();
    const edited = await call('PUT', `/purchases/${vchNo}`, {
      ...purchase([GOLD, { ...SILVER, rate: 85 }]),
      expectedVersion: version,
    });
    expect(edited.statusCode, edited.body).toBe(200);
    expect((await ledger(vchNo)).map((r) => [r.tail, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'SUPL', 0, 125349.46],
      ['06', 'GSTINPUT', 3650.96, 0],
      ['         103', 'PURCHASE', 113836, 0],
      ['         203', 'SLVPURC', 7862.5, 0],
    ]);
  });

  it('control: two lines on ONE expense account keep the measured single purchase leg 03', async () => {
    // Two gold lines in group E1: 2 × 113,836 = 227,672.00; GST 3% = 6,830.16; total 234,502.16.
    const vchNo = await create(purchase([GOLD, { ...GOLD, itCode: 'GLD02' }]));
    expect((await ledger(vchNo)).map((r) => [r.tail, r.ac, r.dr, r.cr])).toEqual([
      ['01', 'SUPL', 0, 234502.16],
      ['03', 'PURCHASE', 227672, 0],
      ['06', 'GSTINPUT', 6830.16, 0],
    ]);
  });

  it('T10 delete: every leg of the two-group purchase is reversed and DELETE_DATA is written', async () => {
    const vchNo = await create(purchase([GOLD, SILVER]));
    const before = await snapshotTenant(owner, tenantId);
    const { version } = (await call('GET', `/purchases/${vchNo}?coBook=${BOOK}`)).json();
    const deleted = await call(
      'DELETE',
      `/purchases/${vchNo}?coBook=${BOOK}&expectedVersion=${version}`,
    );
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(await ledger(vchNo)).toEqual([]);
    const diff = diffTenant(before, await snapshotTenant(owner, tenantId));
    const removed = (diff.removed.AC_DATA ?? []).filter(
      (row) => row.CO_BOOK === BOOK && row.VCH_NO === vchNo,
    );
    expect(removed.map((row) => String(row.LEDR_KEY).slice(headOf(vchNo).length)).sort()).toEqual(
      ['01', '06', '         103', '         203'].sort(),
    );
    expect((diff.added.DELETE_DATA ?? []).length).toBeGreaterThan(0);
  });

  it('PURC_WITH_LBR = N: labour posts to the slot-4 account on its own key, beside the item leg', async () => {
    // The desktop splits labour and other charges to BOOK_DETL slot 4 (Ac_Ledr.cs:419-421). The provisioned purchase
    // book has slots 1-3 only, so the fixture adds slot 4 (LBREXP) and switches the setting.
    const updated = await exec(
      `UPDATE "CO_SET" SET "PURC_WITH_LBR"='N' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    expect(updated).toBe(1);
    const added = await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","AC_CODE","AC_NAME","DATA_TYPE")
       SELECT tenant_id,"CO_CODE","LC_CODE","CO_BOOK",4,"BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT",
              'LBREXP','LABOUR EXPENSE A/C',"DATA_TYPE"
         FROM "BOOK_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "SR_NO"=1`,
      tenantId,
      BOOK,
    );
    expect(added).toBe(1);
    try {
      // Gold only: primary 113,836 − 3,000 = 110,836 to PURCHASE; 3,000 to LBREXP; tax on 113,836 = 3,415.08.
      const vchNo = await create(purchase([GOLD]));
      const rows = await ledger(vchNo);
      const [party, item, tax, labour] = rows;
      expect([party, item, tax].map((r) => [r?.tail, r?.ac, r?.dr, r?.cr])).toEqual([
        ['01', 'SUPL', 0, 117251.08],
        ['03', 'PURCHASE', 110836, 0],
        ['06', 'GSTINPUT', 3415.08, 0],
      ]);
      // The labour leg's desktop code is not measured, so it sits in the unmapped band (50+), never on 03.
      expect([labour?.ac, labour?.dr, labour?.cr]).toEqual(['LBREXP', 3000, 0]);
      expect(Number(labour?.tail)).toBeGreaterThanOrEqual(50);
      expect(rows).toHaveLength(4);
    } finally {
      await exec(
        `UPDATE "CO_SET" SET "PURC_WITH_LBR"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
    }
  });

  // N51 (D17, G170): a purchase carries the same version token as a sale.
  it('N51: a stale purchase save or delete is a 409 that changes nothing', async () => {
    const vchNo = await create(purchase([GOLD]));
    const { version } = (await call('GET', `/purchases/${vchNo}?coBook=${BOOK}`)).json();
    expect(version).toMatch(/^[0-9a-f]{64}$/);
    const missing = await call('PUT', `/purchases/${vchNo}`, purchase([{ ...GOLD, rate: 6100 }]));
    expect(missing.statusCode, missing.body).toBe(400);
    const first = await call('PUT', `/purchases/${vchNo}`, {
      ...purchase([{ ...GOLD, rate: 6100 }]),
      expectedVersion: version,
    });
    expect(first.statusCode, first.body).toBe(200);
    const stale = await call('PUT', `/purchases/${vchNo}`, {
      ...purchase([{ ...GOLD, rate: 6200 }]),
      expectedVersion: version,
    });
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json()).toMatchObject({ error: 'voucher-version-conflict' });
    const staleDelete = await call(
      'DELETE',
      `/purchases/${vchNo}?coBook=${BOOK}&expectedVersion=${version}`,
    );
    expect(staleDelete.statusCode, staleDelete.body).toBe(409);
    const rates = (await owner.$queryRawUnsafe(
      `SELECT "ITM_RATE"::float rate FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      tenantId,
      BOOK,
      vchNo,
    )) as Array<{ rate: number }>;
    expect(rates.map((row) => row.rate)).toEqual([6100]);
    const deleted = await call(
      'DELETE',
      `/purchases/${vchNo}?coBook=${BOOK}&expectedVersion=${first.json().version}`,
    );
    expect(deleted.statusCode, deleted.body).toBe(200);
  });
});
