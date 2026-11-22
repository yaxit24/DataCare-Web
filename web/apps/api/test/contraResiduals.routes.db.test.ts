import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { accountLedgerReport } from '../src/modules/reports/accountLedgerReport.js';
import { dayBook } from '../src/modules/reports/reports.js';
import { cashBook } from '../src/modules/reports/reports2.js';
import { rojmel } from '../src/modules/reports/rojmelReport.js';
import { bankReconList } from '../src/modules/finance/bankRecon.js';
import { getContra } from '../src/modules/finance/contra.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-31 (N246 / G258): Contra Entry (desktop TR_CONTRA) multi-line grid and lifecycle through the real Fastify
 * routes on a forced-RLS database, and through the real readers (account ledger, cash book, bank book, day book,
 * Rojmel). Case ids are in orchestration/work/WP-31/cases.md.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'contra-residuals-db';
const otherTenant = 'contra-residuals-other';
const PASSWORD = 'Contra-Residuals!2026';
const SECRET = 'contra-residuals-test-signing-secret-over-thirty-two';
const ADMIN = 'cradmin';
const EDITOR = 'creditor'; // edit right, no delete, no print
const READER = 'crreader'; // view only
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const BOOK = 'CON';
const CASH = 'WP31CASH';
const BANK = 'WP31BANK';
const BANK2 = 'WP31BK2';
const NOT_SAME = 'You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....';
const TABLES = ['CONTRA_DATA', 'AC_DATA', 'ROJ_MEL_DATA', 'REMARK_DATA'] as const;

type Line = { crdr: 'DR' | 'CR'; acCode: string; amount: number; itDesc?: string };
const twoRows = (amount = 5000): Line[] => [
  { crdr: 'DR', acCode: BANK, amount },
  { crdr: 'CR', acCode: CASH, amount },
];
const threeRows = (): Line[] => [
  { crdr: 'DR', acCode: BANK, amount: 3000.5, itDesc: 'DEPOSIT' },
  { crdr: 'CR', acCode: CASH, amount: 1000.25, itDesc: 'FROM CASH' },
  { crdr: 'CR', acCode: BANK2, amount: 2000.25, itDesc: 'FROM B2' },
];

(enabled ? describe : describe.skip)('WP-31 Contra Entry grid and lifecycle through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let admin = '';
  let editor = '';
  let reader = '';

  const exec = (sql: string, ...p: unknown[]) => owner.$executeRawUnsafe(sql, ...p);
  const query = <T = Array<Record<string, any>>>(sql: string, ...p: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...p) as Promise<T>;
  const call = (cookie: string, method: string, url: string, payload?: unknown) =>
    app.inject({
      method: method as never,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as never }),
    });
  const asAdmin = (method: string, url: string, payload?: unknown) =>
    call(admin, method, url, payload);
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: YEAR };
  const body = (lines: unknown[], extra: Record<string, unknown> = {}) => ({
    coBook: BOOK,
    lcCode: '01',
    coYear: YEAR,
    vchDate: DAY,
    lines,
    ...extra,
  });
  const create = async (lines: unknown[] = twoRows(), extra: Record<string, unknown> = {}) => {
    const r = await asAdmin('POST', `/contra?coBook=${BOOK}`, body(lines, extra));
    expect(r.statusCode, r.body).toBe(201);
    return String(r.json().vchNo).padStart(5, '0');
  };
  const open = async (vchNo: string) => {
    const r = await asAdmin('GET', `/contra/${vchNo}?coBook=${BOOK}`);
    expect(r.statusCode, r.body).toBe(200);
    return r.json();
  };
  const edit = (vchNo: string, version: string | undefined, lines: unknown[], extra = {}) =>
    asAdmin(
      'PUT',
      `/contra/${vchNo}?coBook=${BOOK}`,
      body(lines, { ...(version ? { expectedVersion: version } : {}), ...extra }),
    );
  const remove = (vchNo: string, version?: string) =>
    asAdmin(
      'DELETE',
      `/contra/${vchNo}?coBook=${BOOK}${version ? `&expectedVersion=${version}` : ''}`,
    );
  const rowsOf = (table: string, vchNo: string) =>
    query(
      `SELECT to_jsonb(t) - 'row_id' AS j FROM "${table}" t
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "CO_YEAR"=$4 ORDER BY to_jsonb(t)::text`,
      tenantId,
      BOOK,
      vchNo,
      YEAR,
    ).then((r) => r.map((x) => x.j));
  const writeSet = async (vchNo: string) => {
    const out: Record<string, unknown[]> = {};
    for (const t of TABLES) out[t] = await rowsOf(t, vchNo);
    return out;
  };
  const counts = async (vchNo: string) => {
    const out: Record<string, number> = {};
    for (const t of [...TABLES, 'DELETE_DATA']) out[t] = (await rowsOf(t, vchNo)).length;
    return out;
  };
  const wipe = async (t: string) => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, t);
  };
  const login = async (user: string) => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const c = response.headers['set-cookie'];
    return (Array.isArray(c) ? c : [c ?? '']).map((p) => p.split(';', 1)[0]).join('; ');
  };
  const ledger = async (acCode: string, vchNo?: string) => {
    const r: any = await accountLedgerReport(runtime, scope, {
      view: 'detail',
      acCode,
      fromDate: `${startYear}-04-01`,
      toDate: `${startYear + 1}-03-31`,
    });
    return (r.rows as any[])
      .filter((x) => x.vchNo && (!vchNo || x.vchNo === vchNo))
      .map((x) => ({ vchNo: x.vchNo, dr: x.drAmt, cr: x.crAmt }));
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe(tenantId);
    await wipe(otherTenant);
    await seedCompany(runtime, tenantId, '01');
    await seedCompany(runtime, otherTenant, '01');
    await exec(
      `UPDATE "BOOK_DATA" SET "BOOK_INOUT"='O' WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      tenantId,
      BOOK,
    );
    for (const [code, name] of [
      [CASH, 'CASH ON HAND'],
      [BANK, 'BANK A/C'],
      [BANK2, 'BANK B/C'],
    ])
      for (const t of [tenantId, otherTenant])
        await exec(
          `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01',$2,$3,'10')`,
          t,
          code,
          name,
        );
    await exec(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,'01','E01','EMP ONE')`,
      tenantId,
    );
    const hash = await hashPassword(PASSWORD);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$5,'ADMIN','Y','Y','Y','N'),($1,'01',$3,$5,'USER','Y','N','N','N'),($1,'01',$4,$5,'USER','N','N','N','N')`,
      tenantId,
      ADMIN,
      EDITOR,
      READER,
      hash,
    );
    for (const [user, edit] of [
      [EDITOR, 'Y'],
      [READER, 'N'],
    ])
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES ($1,'01','01',$2,'Cash / Bank','Contra','Y',$3,'N','N')`,
        tenantId,
        user,
        edit,
      );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    admin = await login(ADMIN);
    editor = await login(EDITOR);
    reader = await login(READER);
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipe(tenantId);
      await wipe(otherTenant);
    }
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  beforeEach(async () => {
    for (const t of [...TABLES, 'TEMP_BOOK_DATA', 'DELETE_DATA', 'BANK_RECONCILE'])
      await exec(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenantId);
    await exec(
      `UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"=NULL,"LOCK_DATE"=NULL WHERE tenant_id=$1`,
      tenantId,
    );
    await exec(`UPDATE "CO_MAST" SET "CO_TYPE"=NULL WHERE tenant_id=$1`, tenantId);
  });

  // ---- contra.grid.* / contra.refusal.* -------------------------------------------------------------------
  it('contra.grid.mixed-sides-refused: two debit rows and a credit row are not a desktop grid', async () => {
    const r = await asAdmin(
      'POST',
      `/contra?coBook=${BOOK}`,
      body([
        { crdr: 'DR', acCode: BANK, amount: 100 },
        { crdr: 'DR', acCode: CASH, amount: 50 },
        { crdr: 'CR', acCode: BANK2, amount: 150 },
      ]),
    );
    expect(r.statusCode, r.body).toBe(400);
    expect(r.body).toContain('A contra row after the first must take the opposite side of row 1');
    expect(await query(`SELECT 1 FROM "CONTRA_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
  });

  it('contra.grid.empty-refused: an empty grid and a thin grid get the desktop Cr/Dr text', async () => {
    for (const lines of [[], [{ crdr: 'DR', acCode: BANK, amount: 100 }]]) {
      const r = await asAdmin('POST', `/contra?coBook=${BOOK}`, body(lines));
      expect(r.statusCode, r.body).toBe(400);
      expect(r.body).toContain(NOT_SAME);
    }
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(
      0,
    );
  });

  it('contra.grid.unknown-account: an account that is not in the company is refused, nothing written', async () => {
    const r = await asAdmin(
      'POST',
      `/contra?coBook=${BOOK}`,
      body([
        { crdr: 'DR', acCode: BANK, amount: 100 },
        { crdr: 'CR', acCode: '99999', amount: 100 },
      ]),
    );
    expect(r.statusCode, r.body).toBe(400);
    expect(r.body).toContain('Account code 99999 is not in this company');
    expect(await query(`SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
  });

  it('contra.accounts.any-company-account: any account of the company is accepted, an account of another company is not', async () => {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','WP31DEB','DEBTOR ONE','20') ON CONFLICT DO NOTHING`,
      tenantId,
    );
    await create([
      { crdr: 'DR', acCode: 'WP31DEB', amount: 10 },
      { crdr: 'CR', acCode: CASH, amount: 10 },
    ]);
    await exec(
      `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,'02','Second Co') ON CONFLICT DO NOTHING`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'02','01','WP31OTH','OTHER CO ACCOUNT','10')`,
      tenantId,
    );
    const r = await asAdmin(
      'POST',
      `/contra?coBook=${BOOK}`,
      body([
        { crdr: 'DR', acCode: 'WP31OTH', amount: 10 },
        { crdr: 'CR', acCode: CASH, amount: 10 },
      ]),
    );
    expect(r.statusCode, r.body).toBe(400);
    expect(r.body).toContain('Account code WP31OTH is not in this company');
    await exec(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"='02'`, tenantId);
    await exec(`DELETE FROM "CO_MAST" WHERE tenant_id=$1 AND "CO_CODE"='02'`, tenantId);
  });

  it('contra.refusal.employee-mandatory / company-type-b / check-order', async () => {
    await exec(`UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"='Y' WHERE tenant_id=$1`, tenantId);
    let r = await asAdmin('POST', `/contra?coBook=${BOOK}`, body(twoRows()));
    expect(r.statusCode, r.body).toBe(400);
    expect(r.body).toContain('Please Select Employee Code and Try......');
    r = await asAdmin('POST', `/contra?coBook=${BOOK}`, body(twoRows(), { empCode: 'ZZ9' }));
    expect(r.statusCode, r.body).toBe(400);
    expect(r.body).toContain('Employee ZZ9 is not in this company');
    // employee, then company type B, then year, then lock date, then totals (TR_CONTRA.cs:2668 .. :2694)
    await exec(`UPDATE "CO_MAST" SET "CO_TYPE"='B' WHERE tenant_id=$1`, tenantId);
    r = await asAdmin('POST', `/contra?coBook=${BOOK}`, body(twoRows(), { empCode: 'E01' }));
    expect(r.body).toContain('You Cant Save This Voucher Becouse This Company Type is B......');
    await exec(`UPDATE "CO_MAST" SET "CO_TYPE"=NULL WHERE tenant_id=$1`, tenantId);
    r = await asAdmin(
      'POST',
      `/contra?coBook=${BOOK}`,
      body(twoRows(), { empCode: 'E01', vchDate: `${startYear - 1}-12-31` }),
    );
    expect(r.body).toContain(
      'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
    );
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1`, tenantId, DAY);
    r = await asAdmin('POST', `/contra?coBook=${BOOK}`, body(twoRows(), { empCode: 'E01' }));
    expect(r.body).toContain('You Cant Save and Delete This Voucher Becouse Lock Date is = ');
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1`, tenantId);
    r = await asAdmin(
      'POST',
      `/contra?coBook=${BOOK}`,
      body(
        [
          { crdr: 'DR', acCode: BANK, amount: 5 },
          { crdr: 'CR', acCode: CASH, amount: 4 },
        ],
        {
          empCode: 'E01',
        },
      ),
    );
    expect(r.body).toContain(NOT_SAME);
    expect(await query(`SELECT 1 FROM "CONTRA_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
    // With the setting off and no employee the voucher saves with an empty employee.
    await exec(`UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"='N' WHERE tenant_id=$1`, tenantId);
    const no = await create();
    expect((await rowsOf('CONTRA_DATA', no)).every((x: any) => !x.EMP_CODE)).toBe(true);
  });

  // ---- create ---------------------------------------------------------------------------------------------
  it('contra.create.three-rows / mirror-description / write-set / remark-data / item-type-fixed', async () => {
    const vch = await create(threeRows(), {
      empCode: 'E01',
      itemType: 'G',
      itDesc: 'VOUCHER WIDE',
    });
    const rows = await rowsOf('CONTRA_DATA', vch);
    expect(
      rows
        .map((x: any) => [
          x.SR_NO,
          x.LDR_TYPE,
          x.CRDR_TYPE,
          x.AC_CODE,
          Number(x.DR_AMT),
          Number(x.CR_AMT),
          x.IT_DESC,
        ])
        .sort((a: any, b: any) => a[0] - b[0]),
    ).toEqual([
      [1, '0', 'CR', CASH, 0, 1000.25, 'FROM CASH'],
      [2, '1', 'DR', BANK, 1000.25, 0, 'DEPOSIT'],
      [3, '0', 'CR', BANK2, 0, 2000.25, 'FROM B2'],
      [4, '1', 'DR', BANK, 2000.25, 0, 'DEPOSIT'],
    ]);
    for (const x of rows as any[]) {
      expect(x.IT_TYPE).toBe('A');
      expect(x.EMP_CODE).toBe('E01');
      expect(x.INOUT_TYPE).toBe('O'); // the book's BOOK_INOUT (TR_CONTRA.cs:2774)
      expect(x.USER_UPDATE).toBe('N');
      expect(x.USER_DELETE).toBe('N');
      expect(x.DATA_TRFR).toBe('N');
      expect(Number(x.DR_FINE ?? 0)).toBe(0);
      expect(Number(x.CR_FINE ?? 0)).toBe(0);
    }
    const remarks = await rowsOf('REMARK_DATA', vch);
    expect(remarks.map((x: any) => [x.SR_NO, x.VCH_REMARK])).toEqual([
      [1, 'FROM CASH'],
      [2, 'DEPOSIT'],
      [3, 'FROM B2'],
      [4, 'DEPOSIT'],
    ]);
    const c = await counts(vch);
    expect(c).toEqual({
      CONTRA_DATA: 4,
      AC_DATA: 4,
      ROJ_MEL_DATA: 4,
      REMARK_DATA: 4,
      DELETE_DATA: 0,
    });
    const legs = await query(
      `SELECT trim(substr("LEDR_KEY",length("LEDR_KEY")-11,10))||right("LEDR_KEY",2) k,"AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY 1`,
      tenantId,
      BOOK,
      vch,
    );
    expect(legs).toEqual([
      { k: '101', ac: CASH, dr: 0, cr: 1000.25 },
      { k: '202', ac: BANK, dr: 1000.25, cr: 0 },
      { k: '301', ac: BANK2, dr: 0, cr: 2000.25 },
      { k: '402', ac: BANK, dr: 2000.25, cr: 0 },
    ]);
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(
      1,
    );
  });

  it('contra.create.remark-data: only described rows get a REMARK_DATA row', async () => {
    const vch = await create([
      { crdr: 'DR', acCode: BANK, amount: 30 },
      { crdr: 'CR', acCode: CASH, amount: 10, itDesc: 'X' },
      { crdr: 'CR', acCode: BANK2, amount: 20 },
    ]);
    // Row 1 has no description, so every mirror is blank; only the counter row of grid row 2 is described.
    expect((await rowsOf('REMARK_DATA', vch)).map((x: any) => [x.SR_NO, x.VCH_REMARK])).toEqual([
      [1, 'X'],
    ]);
  });

  it('contra.balance.every-dr-has-cr: five rows and a credit-first grid balance on every table', async () => {
    const five = await create([
      { crdr: 'DR', acCode: BANK, amount: 100 },
      ...[10, 20, 30, 40].map((n, i) => ({
        crdr: 'CR' as const,
        acCode: i % 2 ? CASH : BANK2,
        amount: n,
      })),
    ]);
    const crFirst = await create([
      { crdr: 'CR', acCode: BANK, amount: 100 },
      { crdr: 'DR', acCode: CASH, amount: 60 },
      { crdr: 'DR', acCode: BANK2, amount: 40 },
    ]);
    for (const vch of [five, crFirst]) {
      for (const t of ['AC_DATA', 'CONTRA_DATA']) {
        const s = (
          await query(
            `SELECT sum("DR_AMT")::float dr,sum("CR_AMT")::float cr FROM "${t}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
            tenantId,
            BOOK,
            vch,
          )
        )[0]!;
        expect(s.dr, `${t} ${vch}`).toBe(s.cr);
        expect(s.dr).toBe(100);
      }
    }
    const pairs = await rowsOf('CONTRA_DATA', crFirst);
    expect(
      pairs.map((x: any) => [x.SR_NO, x.LDR_TYPE, x.CRDR_TYPE, Number(x.DR_AMT), Number(x.CR_AMT)]),
    ).toEqual([
      [1, '0', 'DR', 60, 0],
      [2, '1', 'CR', 0, 60],
      [3, '0', 'DR', 40, 0],
      [4, '1', 'CR', 0, 40],
    ]);
  });

  it('contra.ledger.legs-and-rojmel: day-book keys put the leg code first, 33 characters', async () => {
    const vch = await create(twoRows());
    const r = await query(
      `SELECT substr("LEDR_KEY",22,2) t,length("LEDR_KEY") n,"AC_CODE" ac,"DR_AMT"::float dr,"CR_AMT"::float cr
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "LEDR_KEY"`,
      tenantId,
      BOOK,
      vch,
    );
    expect(r).toEqual([
      { t: '01', n: 33, ac: CASH, dr: 0, cr: 5000 },
      { t: '02', n: 33, ac: BANK, dr: 5000, cr: 0 },
    ]);
  });

  it('contra.retry.duplicate-request: two identical posts are two vouchers, n and n+1', async () => {
    const a = await create();
    const b = await create();
    expect(Number(b)).toBe(Number(a) + 1);
    expect((await rowsOf('CONTRA_DATA', a)).length).toBe(2);
  });

  // ---- reopen / edit --------------------------------------------------------------------------------------
  it('contra.reopen.grid-roundtrip: the grid, header and a 64-hex version come back', async () => {
    const vch = await create(threeRows(), { empCode: 'E01' });
    const g = await open(vch);
    expect(g.lines.map((l: any) => [l.crdr, l.acCode, l.amount, l.itDesc])).toEqual([
      ['DR', BANK, 3000.5, 'DEPOSIT'],
      ['CR', CASH, 1000.25, 'FROM CASH'],
      ['CR', BANK2, 2000.25, 'FROM B2'],
    ]);
    expect(g.empCode).toBe('E01');
    expect(g.vchDate).toBe(DAY);
    expect(g.version).toMatch(/^[0-9a-f]{64}$/);
  });

  it('contra.reopen.equal-rows-not-merged: identical rows stay separate and a second save changes nothing', async () => {
    const lines: Line[] = [
      { crdr: 'DR', acCode: BANK, amount: 200 },
      { crdr: 'CR', acCode: CASH, amount: 100, itDesc: 'A' },
      { crdr: 'CR', acCode: CASH, amount: 100, itDesc: 'A' },
    ];
    const vch = await create(lines);
    const g = await open(vch);
    expect(g.lines).toHaveLength(3);
    const before = await writeSet(vch);
    const r = await edit(vch, g.version, g.lines, { empCode: g.empCode });
    expect(r.statusCode, r.body).toBe(200);
    expect(await writeSet(vch)).toEqual(before);
  });

  it('contra.edit.unchanged-save: every stored column is identical after reopen and save', async () => {
    const oldDay = `${startYear}-04-15`;
    const vch = await create(threeRows(), { empCode: 'E01', vchDate: oldDay });
    const before = await writeSet(vch);
    const hidden = await query(
      `SELECT to_jsonb(t) - 'row_id' j FROM "TEMP_BOOK_DATA" t WHERE tenant_id=$1`,
      tenantId,
    );
    const g = await open(vch);
    // The page sends the loaded date; a client that omits it must not move the voucher to today either.
    for (const withDate of [true, false]) {
      const payload = body(g.lines, {
        expectedVersion: (await open(vch)).version,
        empCode: g.empCode,
      });
      if (!withDate) delete (payload as any).vchDate;
      else (payload as any).vchDate = g.vchDate;
      const r = await asAdmin('PUT', `/contra/${vch}?coBook=${BOOK}`, payload);
      expect(r.statusCode, r.body).toBe(200);
      expect(await writeSet(vch)).toEqual(before);
    }
    expect(
      await query(
        `SELECT to_jsonb(t) - 'row_id' j FROM "TEMP_BOOK_DATA" t WHERE tenant_id=$1`,
        tenantId,
      ),
    ).toEqual(hidden);
    expect((await counts(vch)).DELETE_DATA).toBe(0);
  });

  it('contra.edit.version-required: missing 400, stale 409, current succeeds with a new version', async () => {
    const vch = await create();
    const v1 = (await open(vch)).version;
    const before = await writeSet(vch);
    let r = await edit(vch, undefined, twoRows(4000));
    expect(r.statusCode, r.body).toBe(400);
    expect(r.body).toContain(
      'expectedVersion (the version returned when the voucher was opened) is required',
    );
    r = await edit(vch, 'a'.repeat(64), twoRows(4000));
    expect(r.statusCode, r.body).toBe(409);
    expect(r.json().code ?? r.body).toContain('voucher-version-conflict');
    expect(await writeSet(vch)).toEqual(before);
    r = await edit(vch, v1, twoRows(4000));
    expect(r.statusCode, r.body).toBe(200);
    const v2 = (await open(vch)).version;
    expect(v2).not.toBe(v1);
    expect(r.json().version).toBe(v2);
  });

  it('contra.concurrency.stale-edit: two sessions, one winner, one set of postings', async () => {
    const vch = await create();
    const v = (await open(vch)).version;
    const [a, b] = await Promise.all([edit(vch, v, twoRows(1111)), edit(vch, v, twoRows(2222))]);
    expect([a.statusCode, b.statusCode].sort()).toEqual([200, 409]);
    const winner = a.statusCode === 200 ? 1111 : 2222;
    expect((await counts(vch)).AC_DATA).toBe(2);
    expect(await ledger(BANK, vch)).toEqual([{ vchNo: vch, dr: winner, cr: 0 }]);
  });

  it('contra.edit.rewrite-once: readers show the new postings exactly once', async () => {
    const vch = await create(twoRows(5000));
    const v = (await open(vch)).version;
    const r = await edit(
      vch,
      v,
      [
        { crdr: 'DR', acCode: BANK, amount: 5000, itDesc: 'NEW TEXT' },
        { crdr: 'CR', acCode: BANK2, amount: 2000 },
        { crdr: 'CR', acCode: CASH, amount: 3000 },
      ],
      { empCode: undefined },
    );
    expect(r.statusCode, r.body).toBe(200);
    expect(await ledger(CASH, vch)).toEqual([{ vchNo: vch, dr: 0, cr: 3000 }]);
    expect(await ledger(BANK2, vch)).toEqual([{ vchNo: vch, dr: 0, cr: 2000 }]);
    expect(await ledger(BANK, vch)).toEqual([
      { vchNo: vch, dr: 2000, cr: 0 },
      { vchNo: vch, dr: 3000, cr: 0 },
    ]);
    const c = await counts(vch);
    expect(c).toMatchObject({ CONTRA_DATA: 4, AC_DATA: 4, ROJ_MEL_DATA: 4 });
    expect((await rowsOf('REMARK_DATA', vch)).map((x: any) => x.VCH_REMARK)).toEqual([
      'NEW TEXT',
      'NEW TEXT',
    ]);
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(
      1,
    );
    const day = await dayBook(runtime, { ...scope, fromDate: DAY, toDate: DAY } as never);
    const mine = day.rows.filter((x) => x.vchNo === vch);
    expect(mine).toHaveLength(4);
    expect(day.totals.balanced).toBe(true);
  });

  it('contra.edit.clearing-marks: a changed leg is un-cleared, an unchanged leg keeps its clearing date', async () => {
    const vch = await create(twoRows(5000));
    const clear = async () => {
      await exec(
        `UPDATE "AC_DATA" SET "CLR_DATE"='${startYear}-06-20'::date WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "AC_CODE"=$4`,
        tenantId,
        BOOK,
        vch,
        BANK,
      );
      await exec(
        `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE")
         SELECT tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE" FROM "AC_DATA"
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "AC_CODE"=$4`,
        tenantId,
        BOOK,
        vch,
        BANK,
      );
    };
    await clear();
    const state = () =>
      query(
        `SELECT a."AC_CODE" ac,a."CLR_DATE"::text clr,(SELECT count(*)::int FROM "BANK_RECONCILE" r WHERE r.tenant_id=a.tenant_id AND r."LEDR_KEY"=a."LEDR_KEY") marks
           FROM "AC_DATA" a WHERE a.tenant_id=$1 AND a."CO_BOOK"=$2 AND a."VCH_NO"=$3 ORDER BY a."AC_CODE"`,
        tenantId,
        BOOK,
        vch,
      );
    // Same accounts and amounts, new description: the bank leg stays cleared.
    let r = await edit(vch, (await open(vch)).version, [
      { crdr: 'DR', acCode: BANK, amount: 5000, itDesc: 'only text' },
      { crdr: 'CR', acCode: CASH, amount: 5000 },
    ]);
    expect(r.statusCode, r.body).toBe(200);
    expect(await state()).toEqual([
      { ac: BANK, clr: `${startYear}-06-20`, marks: 1 },
      { ac: CASH, clr: null, marks: 0 },
    ]);
    // A changed amount is a new bank movement: no clearing date and no orphan mark.
    r = await edit(vch, (await open(vch)).version, twoRows(4000));
    expect(r.statusCode, r.body).toBe(200);
    expect(await state()).toEqual([
      { ac: BANK, clr: null, marks: 0 },
      { ac: CASH, clr: null, marks: 0 },
    ]);
    expect(await query(`SELECT 1 FROM "BANK_RECONCILE" WHERE tenant_id=$1`, tenantId)).toHaveLength(
      0,
    );
  });

  // ---- delete ---------------------------------------------------------------------------------------------
  it('contra.delete.version-required: 400 without a token, 409 when stale, 200 with the current one', async () => {
    const vch = await create();
    const v = (await open(vch)).version;
    const before = await writeSet(vch);
    let r = await remove(vch);
    expect(r.statusCode, r.body).toBe(400);
    r = await remove(vch, 'b'.repeat(64));
    expect(r.statusCode, r.body).toBe(409);
    expect(await writeSet(vch)).toEqual(before);
    r = await remove(vch, v);
    expect(r.statusCode, r.body).toBe(200);
  });

  it('contra.delete.write-set: every table, the clearing marks, the audit and the readers', async () => {
    const vch = await create(threeRows(), { empCode: 'E01' });
    await exec(
      `UPDATE "AC_DATA" SET "CLR_DATE"='${DAY}'::date WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "AC_CODE"=$3`,
      tenantId,
      vch,
      BANK,
    );
    await exec(
      `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE")
       SELECT tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE" FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "AC_CODE"=$3`,
      tenantId,
      vch,
      BANK,
    );
    // The same number in another year must survive the delete (the desktop REMARK_DATA delete has no year).
    await exec(
      `INSERT INTO "REMARK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_REMARK") VALUES ($1,'01','01','1999-2000',$2,$3,1,'OLD YEAR')`,
      tenantId,
      BOOK,
      vch,
    );
    expect(await ledger(BANK2, vch)).toEqual([{ vchNo: vch, dr: 0, cr: 2000.25 }]);
    const r = await remove(vch, (await open(vch)).version);
    expect(r.statusCode, r.body).toBe(200);
    expect(await counts(vch)).toEqual({
      CONTRA_DATA: 0,
      AC_DATA: 0,
      ROJ_MEL_DATA: 0,
      REMARK_DATA: 0,
      DELETE_DATA: 4,
    });
    expect(await query(`SELECT 1 FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(
      0,
    );
    expect(await query(`SELECT 1 FROM "BANK_RECONCILE" WHERE tenant_id=$1`, tenantId)).toHaveLength(
      0,
    );
    expect(
      await query(
        `SELECT 1 FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_YEAR"='1999-2000'`,
        tenantId,
      ),
    ).toHaveLength(1);
    const audit = await query(
      `SELECT "SR_NO"::int sr,"VCH_VAL_DR"::float dr,"VCH_VAL_CR"::float cr,"DELETE_USER" u FROM "DELETE_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`,
      tenantId,
      vch,
    );
    expect(audit.map((x) => [x.sr, x.dr, x.cr])).toEqual([
      [1, 0, 1000.25],
      [2, 1000.25, 0],
      [3, 0, 2000.25],
      [4, 2000.25, 0],
    ]);
    expect(audit.every((x) => x.u === ADMIN)).toBe(true);
    for (const ac of [CASH, BANK, BANK2]) expect(await ledger(ac, vch)).toEqual([]);
    expect(
      (await dayBook(runtime, scope as never)).rows.filter((x) => x.vchNo === vch),
    ).toHaveLength(0);
    expect(
      (await cashBook(runtime, scope as never)).rows.filter((x) => x.voucher === `${BOOK}/${vch}`),
    ).toHaveLength(0);
    expect(
      (await rojmel(runtime, scope as never)).rows.filter((x: any) => x.vchNo === vch),
    ).toHaveLength(0);
  });

  it('contra.delete.reused-number-not-precleared: a new voucher that reuses the number starts uncleared', async () => {
    const vch = await create();
    await exec(
      `UPDATE "AC_DATA" SET "CLR_DATE"='${DAY}'::date WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "AC_CODE"=$3`,
      tenantId,
      vch,
      BANK,
    );
    await exec(
      `INSERT INTO "BANK_RECONCILE"(tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE")
       SELECT tenant_id,"CO_CODE","LC_CODE","LEDR_KEY","CLR_DATE" FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "AC_CODE"=$3`,
      tenantId,
      vch,
      BANK,
    );
    expect((await remove(vch, (await open(vch)).version)).statusCode).toBe(200);
    const again = await create();
    expect(again).toBe(vch);
    const list = await bankReconList(runtime, { tenantId, coCode: '01' }, BANK);
    expect(list.rows.filter((x) => x.vchNo === again).map((x) => x.clrDate)).toEqual([null]);
    expect(list.cleared).toBe(0);
  });

  it('contra.delete.not-found: a number that was never saved is refused and audited nowhere', async () => {
    const r = await remove('99999', 'c'.repeat(64));
    expect(r.statusCode, r.body).toBeGreaterThanOrEqual(400);
    expect(r.body).toContain('voucher not found');
    expect(await query(`SELECT 1 FROM "DELETE_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(0);
  });

  it('contra.lifecycle.edit-locked-and-out-of-year', async () => {
    const vch = await create();
    const before = await writeSet(vch);
    const v = (await open(vch)).version;
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1`, tenantId, DAY);
    let r = await edit(vch, v, twoRows(4000));
    expect(r.body).toContain('You Cant Save and Delete This Voucher Becouse Lock Date is = ');
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1`, tenantId);
    r = await edit(vch, v, twoRows(), { vchDate: `${startYear - 1}-12-31` });
    expect(r.body).toContain(
      'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
    );
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=$2::date WHERE tenant_id=$1`, tenantId, DAY);
    r = await remove(vch, v);
    expect(r.body).toContain('You Cant Save and Delete This Voucher Becouse Lock Date is = ');
    expect(await writeSet(vch)).toEqual(before);
  });

  // ---- rights, scope --------------------------------------------------------------------------------------
  it('contra.rights.edit-delete-need-role: edit and delete follow the role, flags stay N', async () => {
    const vch = await create();
    const v = (await open(vch)).version;
    const before = await writeSet(vch);
    let r = await call(
      reader,
      'PUT',
      `/contra/${vch}?coBook=${BOOK}`,
      body(twoRows(4000), { expectedVersion: v }),
    );
    expect(r.statusCode).toBe(403);
    r = await call(editor, 'DELETE', `/contra/${vch}?coBook=${BOOK}&expectedVersion=${v}`);
    expect(r.statusCode).toBe(403);
    r = await call(editor, 'GET', `/contra/${vch}/print?coBook=${BOOK}&format=html`);
    expect(r.statusCode).toBe(403);
    expect(await writeSet(vch)).toEqual(before);
    r = await call(
      editor,
      'PUT',
      `/contra/${vch}?coBook=${BOOK}`,
      body(twoRows(4000), { expectedVersion: v }),
    );
    expect(r.statusCode, r.body).toBe(200);
    expect(
      (await rowsOf('CONTRA_DATA', vch)).every(
        (x: any) => x.USER_UPDATE === 'N' && x.USER_DELETE === 'N',
      ),
    ).toBe(true);
  });

  it('contra.scope.cross-tenant: another tenant cannot read, edit or delete the voucher', async () => {
    const vch = await create();
    const other = { tenantId: otherTenant, coCode: '01', lcCode: '01', coYear: YEAR, coBook: BOOK };
    await expect(getContra(runtime, other, vch)).rejects.toThrow(/not found/);
    const before = await writeSet(vch);
    const { deleteContra } = await import('../src/modules/finance/contra.js');
    await expect(
      deleteContra(runtime, { scope: other, vchNo: vch, expectedVersion: 'd'.repeat(64) } as never),
    ).rejects.toThrow(/not found/);
    expect(await writeSet(vch)).toEqual(before);
  });

  // ---- atomicity ------------------------------------------------------------------------------------------
  it('contra.rollback.atomic-write: a fault in any later table leaves create, edit and delete unchanged', async () => {
    const guard = async (table: string, when: string) => {
      await exec(
        `CREATE OR REPLACE FUNCTION wp31_boom() RETURNS trigger LANGUAGE plpgsql AS $$ BEGIN RAISE EXCEPTION 'wp31 injected fault'; END $$`,
      );
      await exec(
        `CREATE TRIGGER wp31_boom BEFORE INSERT ON "${table}" FOR EACH ROW ${when} EXECUTE FUNCTION wp31_boom()`,
      );
    };
    const drop = (table: string) => exec(`DROP TRIGGER IF EXISTS wp31_boom ON "${table}"`);
    // A described row, so that REMARK_DATA is written too.
    const described = (amount: number): Line[] => [
      { crdr: 'DR', acCode: BANK, amount, itDesc: 'FAULT TEXT' },
      { crdr: 'CR', acCode: CASH, amount },
    ];
    const vch = await create(threeRows());
    const before = await writeSet(vch);
    for (const table of ['ROJ_MEL_DATA', 'REMARK_DATA']) {
      await guard(table, `WHEN (NEW.tenant_id='${tenantId}')`);
      try {
        const v = (await open(vch)).version;
        const e = await edit(vch, v, described(1234));
        expect(e.statusCode).toBeGreaterThanOrEqual(400);
        expect(await writeSet(vch)).toEqual(before);
        const c = await asAdmin('POST', `/contra?coBook=${BOOK}`, body(described(77)));
        expect(c.statusCode).toBeGreaterThanOrEqual(400);
        expect(
          await query(
            `SELECT 1 FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "VCH_NO"<>$2`,
            tenantId,
            vch,
          ),
        ).toHaveLength(0);
      } finally {
        await drop(table);
      }
    }
    await guard('DELETE_DATA', `WHEN (NEW.tenant_id='${tenantId}')`);
    try {
      const d = await remove(vch, (await open(vch)).version);
      expect(d.statusCode).toBeGreaterThanOrEqual(400);
      expect(await writeSet(vch)).toEqual(before);
      expect(await query(`SELECT 1 FROM "DELETE_DATA" WHERE tenant_id=$1`, tenantId)).toHaveLength(
        0,
      );
    } finally {
      await drop('DELETE_DATA');
    }
  });

  // ---- list, print, readers -------------------------------------------------------------------------------
  it('contra.list.desktop-groups: one line per voucher, account and description (TR_CONTRA.cs:3144)', async () => {
    const one = await create(twoRows());
    const two = await create(threeRows());
    const r = await asAdmin('GET', `/contra/list?coBook=${BOOK}`);
    expect(r.statusCode, r.body).toBe(200);
    const rows = r.json() as any[];
    const dmy = DAY.split('-').reverse().join('/');
    expect(
      rows.map((x) => [x.vchNo, x.vchDate, x.partyName, x.vchDesc, x.user, x.crAmt, x.drAmt]),
    ).toEqual([
      [one, dmy, 'BANK A/C', '', ADMIN, 0, 5000],
      [one, dmy, 'CASH ON HAND', '', ADMIN, 5000, 0],
      [two, dmy, 'BANK A/C', 'DEPOSIT', ADMIN, 0, 3000.5],
      [two, dmy, 'BANK B/C', 'FROM B2', ADMIN, 2000.25, 0],
      [two, dmy, 'CASH ON HAND', 'FROM CASH', ADMIN, 1000.25, 0],
    ]);
    await exec(
      `INSERT INTO "CONTRA_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","DR_AMT","CR_AMT") VALUES ($1,'01','01','1999-2000',$2,'00077',1,'1999-05-01'::date,$3,1,0)`,
      tenantId,
      BOOK,
      BANK,
    );
    const again = ((await asAdmin('GET', `/contra/list?coBook=${BOOK}`)).json() as any[]).map(
      (x) => x.vchNo,
    );
    expect(again).not.toContain('00077');
    expect((await call(reader, 'GET', `/contra/list?coBook=${BOOK}`)).statusCode).toBe(200);
    expect((await asAdmin('GET', `/contra/list?coBook=FJV`)).statusCode).toBeGreaterThanOrEqual(
      400,
    );
  });

  it('contra.print.multi-leg: the printed voucher lists every leg and the voucher total', async () => {
    const vch = await create(threeRows());
    const r = await asAdmin('GET', `/contra/${vch}/print?coBook=${BOOK}&format=html`);
    expect(r.statusCode, r.body).toBe(200);
    for (const text of [
      'BANK A/C',
      'CASH ON HAND',
      'BANK B/C',
      '3,000.50',
      '1,000.25',
      '2,000.25',
      'DEPOSIT',
      'FROM CASH',
      'FROM B2',
    ])
      expect(r.body, text).toContain(text);
  });

  it('contra.readers: account ledger, cash book, bank book, day book and Rojmel agree after create, edit and delete', async () => {
    const vch = await create(threeRows());
    expect(await ledger(BANK, vch)).toEqual([
      { vchNo: vch, dr: 1000.25, cr: 0 },
      { vchNo: vch, dr: 2000.25, cr: 0 },
    ]);
    expect(await ledger(CASH, vch)).toEqual([{ vchNo: vch, dr: 0, cr: 1000.25 }]);
    expect(await ledger(BANK2, vch)).toEqual([{ vchNo: vch, dr: 0, cr: 2000.25 }]);
    const book = (await cashBook(runtime, scope as never)).rows.filter(
      (x) => x.voucher === `${BOOK}/${vch}`,
    );
    expect([book.reduce((s, x) => s + x.dr, 0), book.reduce((s, x) => s + x.cr, 0)]).toEqual([
      3000.5, 3000.5,
    ]);
    const bank = await bankReconList(runtime, { tenantId, coCode: '01' }, BANK);
    expect(bank.rows.filter((x) => x.vchNo === vch).map((x) => x.dr)).toEqual([1000.25, 2000.25]);
    expect([bank.book, bank.cleared, bank.uncleared]).toEqual([3000.5, 0, 3000.5]);
    const day = await dayBook(runtime, scope as never);
    const mine = day.rows.filter((x) => x.vchNo === vch);
    expect([mine.reduce((s, x) => s + x.dr, 0), mine.reduce((s, x) => s + x.cr, 0)]).toEqual([
      3000.5, 3000.5,
    ]);
    const roj = (await rojmel(runtime, scope as never)).rows.filter((x: any) => x.vchNo === vch);
    expect(roj).toHaveLength(4);
    // Edit to a smaller two-row voucher: the third account has no line any more.
    expect((await edit(vch, (await open(vch)).version, twoRows(2000))).statusCode).toBe(200);
    expect(await ledger(BANK2, vch)).toEqual([]);
    expect(await ledger(BANK, vch)).toEqual([{ vchNo: vch, dr: 2000, cr: 0 }]);
    expect(
      (await rojmel(runtime, scope as never)).rows.filter((x: any) => x.vchNo === vch),
    ).toHaveLength(2);
  });
});
