import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N206 / G219: Fine JV (desktop TR_CONTRA with FormMainBook 'FINE JV') through the real Fastify routes on a
 * forced-RLS database. Every expected value below is taken from the desktop source, not from the web writer:
 *
 * - TR_CONTRA.cs:2760-2847 — the grid's row 1 is paired with every later row i: row i is written first
 *   (LDR_TYPE '0', its own Cr/Dr, CR_FINE = Cr column, DR_FINE = Dr column, LD_CODE = row 1), then row 1 is
 *   mirrored against it (LDR_TYPE '1', row 1's Cr/Dr, the opposite fine, LD_CODE = row i). The counter row
 *   takes row i's description and the mirror takes row 1's (:2800, :2868). Every save writes DATA_TRFR,
 *   USER_UPDATE and USER_DELETE 'N' and the screen's employee code (:2803-2815, :2871-2875).
 * - TR_CONTRA.cs:2742-2753 — TEMP_BOOK_DATA.BOOK_NAME is FormName, the BOOK_DATA.BOOK_NAME chosen by
 *   CurBookHelp (DC_Main.cs:1495-1531, TR_CONTRA.cs:2307).
 * - Ac_Ledr.cs:846-848 — one AC_DATA leg per CR_FINE / DR_FINE row keyed
 *   CO_CODE+LC_CODE+CO_YEAR+CO_BOOK+VCH_NO+STR(SR_NO)+'03'/'04'; STR() right-aligns in 10, so 33 characters.
 * - Ac_Rojmel.cs:342-344 — ROJ_MEL_DATA copies CONTRA_DATA.AC_NAME and IT_DESC.
 * - Ac_Tax.cs:686-694 (Vch_Remark mode 3, called at TR_CONTRA.cs:2890) — REMARK_DATA is deleted and rebuilt
 *   from every CONTRA_DATA row whose IT_DESC is not blank, with the AC_MAST name and the MAIN_BOOK.
 * - TR_CONTRA.cs:2666-2694 — refusals in desktop order: employee code when mandatory, company type B on a new
 *   voucher, a date outside the current year, the lock date, and unequal Cr/Dr totals.
 * - TR_CONTRA.cs:2961-2968 — delete audits every source row, then removes remarks, the hidden identity,
 *   ledger, day book, source rows and APR_IDTL.
 * - TR_CONTRA.cs:3000-3004, :3021, :3061-3069 — printing needs UserPrint and selects FineJvBill.RPT, whose
 *   title is 'Gold '/'Silver ' & BOOK_DATA.BOOK_NAME, whose detail prints AC_MAST.AC_NAME with CR_FINE and
 *   DR_FINE plus the IT_DESC line, and whose page footer is 'For : ' + CO_NAME, 'Party signature.' and
 *   'signature.' (report-specs/FineJvBill.spec.json).
 * - MDI_FORM.cs:8100-8111 and :8360-8365 — Contra Entry opens only CONTRA books and Fine Jv Entry only FINE
 *   JV books, so the shared CONTRA_DATA family routes must refuse each other's books.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'fine-jv-routes-db';
const PASSWORD = 'Fine-JV-Routes!2026';
const SECRET = 'fine-jv-routes-test-signing-secret-over-thirty-two';
const ADMIN = 'fjadmin';
const VIEWER = 'fjviewer';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const OUT_OF_YEAR = `${startYear - 1}-12-31`;
const BOOK = 'FJV';
const BOOK_NAME = 'Fine JV';
const FROM = 'FJFROM';
const TO = 'FJTO';
const TO2 = 'FJTO2';
const FROM_NAME = 'Fine JV From Local';
const TO_NAME = 'Fine JV To Local';
const TO2_NAME = 'Fine JV Second To';
const EMP = 'E01';
const STR = (n: number) => String(n).padStart(10, ' ');
const ledgerKey = (vchNo: string, srNo: number, type: '03' | '04') =>
  `0101${YEAR}${BOOK}${vchNo}${STR(srNo)}${type}`;

type Cookie = string;
type Line = { crdr: 'DR' | 'CR'; acCode: string; fine: number; itDesc?: string };

(enabled ? describe : describe.skip)('N206 Fine JV desktop grid through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let adminCookie: Cookie;
  let viewerCookie: Cookie;

  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const request = (cookie: Cookie, method: string, url: string, payload?: unknown) =>
    app.inject({
      method: method as never,
      url,
      headers: { cookie },
      ...(payload === undefined ? {} : { payload: payload as never }),
    });
  const adminRequest = (method: string, url: string, payload?: unknown) =>
    request(adminCookie, method, url, payload);
  const twoRows = (fine = 1.25): Line[] => [
    { crdr: 'DR', acCode: FROM, fine, itDesc: 'From detail' },
    { crdr: 'CR', acCode: TO, fine, itDesc: 'To detail' },
  ];
  const body = (overrides: Record<string, unknown> = {}) => ({
    coBook: BOOK,
    lcCode: '01',
    coYear: YEAR,
    vchDate: DAY,
    metal: 'G',
    lines: twoRows(),
    ...overrides,
  });
  const countWriteRows = async () =>
    (
      await query<
        Array<{ source: number; ledger: number; rojmel: number; temp: number; remarks: number }>
      >(
        `SELECT
          (SELECT count(*)::int FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) source,
          (SELECT count(*)::int FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) ledger,
          (SELECT count(*)::int FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) rojmel,
          (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) temp,
          (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2) remarks`,
        tenantId,
        BOOK,
      )
    )[0]!;
  const post = (payload: Record<string, unknown>) =>
    adminRequest('POST', `/fine-jv?coBook=${BOOK}`, payload);
  const create = async (overrides: Record<string, unknown> = {}) => {
    const response = await post(body(overrides));
    expect(response.statusCode, response.body).toBe(201);
    return String(response.json().vchNo).padStart(5, '0');
  };
  const source = (vchNo: string) =>
    query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO"::int sr,"AC_CODE" ac,coalesce("AC_NAME",'') name,"LD_CODE" ld,"CRDR_TYPE" crdr,
              "LDR_TYPE" ldr,coalesce("CR_FINE",0)::float cr,coalesce("DR_FINE",0)::float dr,
              coalesce("CR_AMT",0)::float cramt,coalesce("DR_AMT",0)::float dramt,"IT_TYPE" metal,
              coalesce("IT_DESC",'') "desc",coalesce("EMP_CODE",'') emp,"VCH_TYPE" vtype,
              "INOUT_TYPE" inout,"ENTRY_TYPE" entry,"BOOK_NAME" book,"HD_VCH_NO" hidden,
              "MAIN_USER" "user","VCH_DATE"::date::text "date",coalesce("DATA_TRFR",'') transfer,
              coalesce("USER_UPDATE",'') updated,coalesce("USER_DELETE",'') deleted
         FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      tenantId,
      BOOK,
      vchNo,
    );
  const ledger = (vchNo: string) =>
    query<Array<Record<string, unknown>>>(
      `SELECT "LEDR_KEY" key,length("LEDR_KEY")::int len,"AC_CODE" ac,"LD_CODE" ld,"SIGN" sign,
              coalesce("FINE_WT",0)::float fine,"IT_TYPE" metal,coalesce("IT_DESC",'') "desc",
              "BOOK_NAME" book,"VCH_TYPE" vtype,"HD_VCH_NO" hidden,coalesce("MAIN_USER",'') "user",
              coalesce("PARTY_AC_CODE",'') party,coalesce("DATA_TYPE",'') dtype,
              coalesce("DR_AMT",0)::float dr,coalesce("CR_AMT",0)::float cr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "LEDR_KEY"`,
      tenantId,
      BOOK,
      vchNo,
    );
  const remarks = (vchNo: string) =>
    query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO"::int sr,"AC_CODE" ac,coalesce("AC_NAME",'') name,"MAIN_BOOK" main,
              "VCH_REMARK" remark,"VCH_DATE"::date::text "date"
         FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "SR_NO"`,
      tenantId,
      BOOK,
      vchNo,
    );
  const sourceRow = (row: Record<string, unknown>, vchNo: string) => ({
    cramt: 0,
    dramt: 0,
    vtype: 'FJV',
    inout: 'I',
    entry: 'J',
    book: 'FINE JV',
    hidden: vchNo,
    user: ADMIN,
    date: DAY,
    transfer: 'N',
    updated: 'N',
    deleted: 'N',
    ...row,
  });
  const ledgerRow = (row: Record<string, unknown>, vchNo: string) => ({
    len: 33,
    book: 'FINE JV',
    vtype: 'FJV',
    hidden: vchNo,
    user: ADMIN,
    dtype: 'A',
    dr: 0,
    cr: 0,
    ...row,
  });

  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const login = async (user: string): Promise<Cookie> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const setCookie = response.headers['set-cookie'];
    return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `UPDATE "BOOK_DATA" SET "DATA_TYPE"='A',"BOOK_NAME"=$3
        WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_BOOK"=$2`,
      tenantId,
      BOOK,
      BOOK_NAME,
    );
    await exec(
      `UPDATE "CO_MAST" SET "CO_NAME"='Fine JV Jewellers',"BANK_NAME"='Not on Fine JV',
              "BANK_AC_NO"='000011112222',"BANK_RTGS_NO"='FJV0000000'
        WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
       VALUES ($1,'01','01',$2,$3,'10'),($1,'01','01',$4,$5,'10'),($1,'01','01',$6,$7,'10'),
              ($1,'01','02',$2,'Fine JV From Other Location','10'),
              ($1,'01','02',$4,'Fine JV To Other Location','10')`,
      tenantId,
      FROM,
      FROM_NAME,
      TO,
      TO_NAME,
      TO2,
      TO2_NAME,
    );
    await exec(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,'01',$2,'Employee One')`,
      tenantId,
      EMP,
    );
    const passwordHash = await hashPassword(PASSWORD);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N'),($1,'01',$4,$3,'USER','Y','N','N','N')`,
      tenantId,
      ADMIN,
      passwordHash,
      VIEWER,
    );
    for (const subMenu of ['Fine JV (metal transfer)', 'Contra', 'Journal Voucher'])
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES ($1,'01','01',$2,'Cash / Bank',$3,'Y','Y','N','N')`,
        tenantId,
        VIEWER,
        subMenu,
      );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    adminCookie = await login(ADMIN);
    viewerCookie = await login(VIEWER);
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('refuses malformed input, unknown accounts or employees, unequal totals and an out-of-year date without writing', async () => {
    const before = await countWriteRows();
    const refusals: Array<[Record<string, unknown>, string | undefined]> = [
      [body({ metal: 'X' }), undefined],
      [body({ unexpected: 'must not reach a writer' }), 'unsupported field'],
      [body({ lines: [{ ...twoRows()[0], extra: 'x' }, twoRows()[1]] }), 'unsupported field'],
      [body({ lines: [twoRows()[0]] }), undefined],
      [body({ lines: [{ ...twoRows()[0], fine: Number.NaN }, twoRows()[1]] }), undefined],
      [body({ lines: [{ ...twoRows()[0], acCode: 'NOFROM' }, twoRows()[1]] }), 'NOFROM'],
      [body({ empCode: 'E99' }), 'E99'],
      // TR_CONTRA.cs:2694
      [
        body({ lines: [twoRows(2)[0], twoRows(1.5)[1]] }),
        'You Cant Save This Voucher Becouse Cr Value and Dr Value is not same....',
      ],
      // TR_CONTRA.cs:2680-2685
      [
        body({ vchDate: OUT_OF_YEAR }),
        'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
      ],
    ];
    for (const [payload, message] of refusals) {
      const response = await post(payload);
      expect(response.statusCode, `${JSON.stringify(payload)} => ${response.body}`).toBe(400);
      if (message) expect(response.body).toContain(message);
    }
    expect(await countWriteRows()).toEqual(before);
  });

  it('refuses a missing mandatory employee and a new voucher in a company of type B, as TR_CONTRA does', async () => {
    const before = await countWriteRows();
    await exec(
      `UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    try {
      const missing = await post(body());
      expect(missing.statusCode, missing.body).toBe(400);
      expect(missing.body).toContain('Please Select Employee Code and Try......');
    } finally {
      await exec(
        `UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
    }
    await exec(
      `UPDATE "CO_MAST" SET "CO_TYPE"='B' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    try {
      const typeB = await post(body());
      expect(typeB.statusCode, typeB.body).toBe(400);
      expect(typeB.body).toContain(
        'You Cant Save This Voucher Becouse This Company Type is B......',
      );
    } finally {
      await exec(
        `UPDATE "CO_MAST" SET "CO_TYPE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
    }
    expect(await countWriteRows()).toEqual(before);
  });

  it('writes the desktop pair, 33-character fine legs, the book-named hidden identity, day book names and rebuilt remarks', async () => {
    const vchNo = await create({ empCode: EMP });
    expect(await source(vchNo)).toEqual([
      sourceRow(
        {
          sr: 1,
          ac: TO,
          name: TO_NAME,
          ld: FROM,
          crdr: 'CR',
          ldr: '0',
          cr: 1.25,
          dr: 0,
          metal: 'G',
          desc: 'To detail',
          emp: EMP,
        },
        vchNo,
      ),
      sourceRow(
        {
          sr: 2,
          ac: FROM,
          name: FROM_NAME,
          ld: TO,
          crdr: 'DR',
          ldr: '1',
          cr: 0,
          dr: 1.25,
          metal: 'G',
          desc: 'From detail',
          emp: EMP,
        },
        vchNo,
      ),
    ]);
    expect(await ledger(vchNo)).toEqual([
      ledgerRow(
        {
          key: ledgerKey(vchNo, 1, '03'),
          ac: TO,
          ld: FROM,
          sign: '+',
          fine: 1.25,
          metal: 'G',
          desc: 'To detail',
          party: TO,
        },
        vchNo,
      ),
      ledgerRow(
        {
          key: ledgerKey(vchNo, 2, '04'),
          ac: FROM,
          ld: TO,
          sign: '-',
          fine: 1.25,
          metal: 'G',
          desc: 'From detail',
          party: FROM,
        },
        vchNo,
      ),
    ]);
    const temp = await query<Array<{ name: string }>>(
      `SELECT "BOOK_NAME" name FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      tenantId,
      BOOK,
      vchNo,
    );
    expect(temp).toEqual([{ name: BOOK_NAME }]);
    const dayBook = await query<Array<{ ac: string; name: string; desc: string; dtype: string }>>(
      `SELECT "AC_CODE" ac,coalesce("AC_NAME",'') name,coalesce("IT_DESC",'') "desc",coalesce("DATA_TYPE",'') dtype
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ORDER BY "LEDR_KEY"`,
      tenantId,
      BOOK,
      vchNo,
    );
    expect(dayBook).toEqual([
      { ac: TO, name: TO_NAME, desc: 'To detail', dtype: 'A' },
      { ac: FROM, name: FROM_NAME, desc: 'From detail', dtype: 'A' },
    ]);
    expect(await remarks(vchNo)).toEqual([
      { sr: 1, ac: TO, name: TO_NAME, main: 'FINE JV', remark: 'To detail', date: DAY },
      { sr: 2, ac: FROM, name: FROM_NAME, main: 'FINE JV', remark: 'From detail', date: DAY },
    ]);
  });

  it('saves, reopens and prints a multi-account desktop grid', async () => {
    const vchNo = await create({
      lines: [
        { crdr: 'DR', acCode: FROM, fine: 5, itDesc: 'From detail' },
        { crdr: 'CR', acCode: TO, fine: 3, itDesc: 'first receiver' },
        { crdr: 'CR', acCode: TO2, fine: 2, itDesc: '' },
      ],
    });
    const rows = await source(vchNo);
    expect(rows.map((r) => [r.sr, r.ac, r.ld, r.crdr, r.ldr, r.cr, r.dr, r.desc])).toEqual([
      [1, TO, FROM, 'CR', '0', 3, 0, 'first receiver'],
      [2, FROM, TO, 'DR', '1', 0, 3, 'From detail'],
      [3, TO2, FROM, 'CR', '0', 2, 0, ''],
      [4, FROM, TO2, 'DR', '1', 0, 2, 'From detail'],
    ]);
    expect((await ledger(vchNo)).map((r) => [r.key, r.ac, r.sign, r.fine])).toEqual([
      [ledgerKey(vchNo, 1, '03'), TO, '+', 3],
      [ledgerKey(vchNo, 2, '04'), FROM, '-', 3],
      [ledgerKey(vchNo, 3, '03'), TO2, '+', 2],
      [ledgerKey(vchNo, 4, '04'), FROM, '-', 2],
    ]);
    expect((await remarks(vchNo)).map((r) => [r.sr, r.ac, r.remark])).toEqual([
      [1, TO, 'first receiver'],
      [2, FROM, 'From detail'],
      [4, FROM, 'From detail'],
    ]);

    const reopened = await adminRequest('GET', `/fine-jv/${vchNo}?coBook=${BOOK}`);
    expect(reopened.statusCode, reopened.body).toBe(200);
    expect(reopened.json()).toMatchObject({
      voucherNo: vchNo,
      vchDate: DAY,
      metal: 'G',
      empCode: '',
      bookName: BOOK_NAME,
      lines: [
        { crdr: 'DR', acCode: FROM, acName: FROM_NAME, itDesc: 'From detail', fine: 5 },
        { crdr: 'CR', acCode: TO, acName: TO_NAME, itDesc: 'first receiver', fine: 3 },
        { crdr: 'CR', acCode: TO2, acName: TO2_NAME, itDesc: '', fine: 2 },
      ],
    });

    const printed = await adminRequest('GET', `/fine-jv/${vchNo}/print?coBook=${BOOK}&format=html`);
    expect(printed.statusCode, printed.body).toBe(200);
    const html = printed.body;
    expect(html).toContain(`Gold ${BOOK_NAME}`);
    for (const text of ['Party Name', 'Cr Fine', 'Dr Fine', TO_NAME, TO2_NAME, 'first receiver'])
      expect(html).toContain(text);
    expect(html.split(FROM_NAME).length - 1).toBe(2);
    expect(html.split('From detail').length - 1).toBe(2);
    expect(html).toContain('3.000');
    expect(html).toContain('2.000');
    expect(html).toContain('For : Fine JV Jewellers');
    expect(html).toContain('Party signature.');
    expect(html).toContain('>signature.<');
    for (const absent of [
      'Total',
      'Authorised Signatory',
      'E.&amp;O.E.',
      'E.&O.E.',
      'Bank Details',
      '000011112222',
      'FJV0000000',
      'Other Location',
    ])
      expect(html).not.toContain(absent);
  });

  it('an edit keeps the omitted date, metal and employee, re-resolves a changed account, resets the desktop flags and rebuilds remarks', async () => {
    const vchNo = await create({ metal: 'S', empCode: EMP, lines: twoRows(2.5) });
    await exec(
      `UPDATE "CONTRA_DATA"
          SET "AC_NAME"=CASE WHEN "SR_NO"=1 THEN 'Imported To Name' ELSE 'Imported From Name' END,
              "DATA_TRFR"='Y',"USER_UPDATE"='Y',"USER_DELETE"='Y'
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      tenantId,
      BOOK,
      vchNo,
    );
    await exec(
      `INSERT INTO "REMARK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","AC_NAME","MAIN_BOOK","VCH_REMARK")
       VALUES ($1,'01','01',$2,$3,$4,0,$5::date,$6,'Imported To Name','FINE JV','Imported remark')`,
      tenantId,
      YEAR,
      BOOK,
      vchNo,
      DAY,
      TO,
    );

    const updated = await adminRequest('PUT', `/fine-jv/${vchNo}?coBook=${BOOK}`, {
      lines: [
        { crdr: 'DR', acCode: FROM, fine: 4.3216, itDesc: 'new from' },
        { crdr: 'CR', acCode: TO2, fine: 4.3216, itDesc: 'new to' },
      ],
    });
    expect(updated.statusCode, updated.body).toBe(200);
    expect(await source(vchNo)).toEqual([
      sourceRow(
        {
          sr: 1,
          ac: TO2,
          name: TO2_NAME,
          ld: FROM,
          crdr: 'CR',
          ldr: '0',
          cr: 4.322,
          dr: 0,
          metal: 'S',
          desc: 'new to',
          emp: EMP,
        },
        vchNo,
      ),
      sourceRow(
        {
          sr: 2,
          ac: FROM,
          name: 'Imported From Name',
          ld: TO2,
          crdr: 'DR',
          ldr: '1',
          cr: 0,
          dr: 4.322,
          metal: 'S',
          desc: 'new from',
          emp: EMP,
        },
        vchNo,
      ),
    ]);
    expect((await ledger(vchNo)).map((r) => [r.key, r.ac, r.sign, r.fine, r.metal])).toEqual([
      [ledgerKey(vchNo, 1, '03'), TO2, '+', 4.322, 'S'],
      [ledgerKey(vchNo, 2, '04'), FROM, '-', 4.322, 'S'],
    ]);
    expect((await remarks(vchNo)).map((r) => [r.sr, r.ac, r.name, r.remark])).toEqual([
      [1, TO2, TO2_NAME, 'new to'],
      [2, FROM, FROM_NAME, 'new from'],
    ]);
    const outOfYear = await adminRequest('PUT', `/fine-jv/${vchNo}?coBook=${BOOK}`, {
      vchDate: OUT_OF_YEAR,
      lines: twoRows(1),
    });
    expect(outOfYear.statusCode, outOfYear.body).toBe(400);
    expect((await source(vchNo)).map((r) => [r.date, Number(r.dr) + Number(r.cr)])).toEqual([
      [DAY, 4.322],
      [DAY, 4.322],
    ]);

    const hidden = String((await source(vchNo))[0]!.hidden);
    const deleted = await adminRequest('DELETE', `/fine-jv/${vchNo}?coBook=${BOOK}`);
    expect(deleted.statusCode, deleted.body).toBe(200);
    const left = await query<Array<Record<string, number>>>(
      `SELECT (SELECT count(*)::int FROM "REMARK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) remarks,
              (SELECT count(*)::int FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$4) temp,
              (SELECT count(*)::int FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3) source,
              (SELECT count(*)::int FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3
                  AND "DELETE_USER"=$5) audits`,
      tenantId,
      BOOK,
      vchNo,
      hidden,
      ADMIN,
    );
    expect(left).toEqual([{ remarks: 0, temp: 0, source: 0, audits: 2 }]);
  });

  it('answers forbidden, malformed and missing Fine JV requests precisely', async () => {
    const vchNo = await create();
    const denied = await request(
      viewerCookie,
      'GET',
      `/fine-jv/${vchNo}/print?coBook=${BOOK}&format=html`,
    );
    expect(denied.statusCode, denied.body).toBe(403);
    expect(denied.json()).toMatchObject({ error: 'forbidden', action: 'print' });
    const malformed = await adminRequest('GET', `/fine-jv/12ab/print?coBook=${BOOK}&format=html`);
    expect(malformed.statusCode, malformed.body).toBe(400);
    for (const [method, url] of [
      ['GET', `/fine-jv/99999/print?coBook=${BOOK}&format=html`],
      ['GET', `/fine-jv/99999?coBook=${BOOK}`],
      ['DELETE', `/fine-jv/99999?coBook=${BOOK}`],
    ] as const) {
      const response = await adminRequest(method, url);
      expect(response.statusCode, `${method} ${url} => ${response.body}`).toBe(404);
      expect(response.json()).toMatchObject({ error: 'fine-jv-not-found' });
    }
    const missingEdit = await adminRequest('PUT', `/fine-jv/99999?coBook=${BOOK}`, {
      lines: twoRows(),
    });
    expect(missingEdit.statusCode, missingEdit.body).toBe(404);
  });

  it('Contra and Journal routes refuse a Fine JV book and require print rights for their documents', async () => {
    const vchNo = await create();
    const fineRows = await source(vchNo);
    const before = await countWriteRows();
    const money = [
      { crdr: 'DR', acCode: TO, amount: 10 },
      { crdr: 'CR', acCode: FROM, amount: 10 },
    ];
    const journalLines = [
      { acCode: TO, drAmt: 10 },
      { acCode: FROM, crAmt: 10 },
    ];
    for (const [method, url, payload, family] of [
      ['POST', `/contra?coBook=${BOOK}`, { coBook: BOOK, vchDate: DAY, lines: money }, 'CONTRA'],
      ['GET', `/contra/${vchNo}?coBook=${BOOK}`, undefined, 'CONTRA'],
      ['PUT', `/contra/${vchNo}?coBook=${BOOK}`, { vchDate: DAY, lines: money }, 'CONTRA'],
      ['DELETE', `/contra/${vchNo}?coBook=${BOOK}`, undefined, 'CONTRA'],
      ['GET', `/contra/${vchNo}/print?coBook=${BOOK}&format=html`, undefined, 'CONTRA'],
      ['POST', `/journal?coBook=${BOOK}`, { vchDate: DAY, lines: journalLines }, 'JOURNAL'],
      ['GET', `/journal/${vchNo}?coBook=${BOOK}`, undefined, 'JOURNAL'],
      ['PUT', `/journal/${vchNo}?coBook=${BOOK}`, { vchDate: DAY, lines: journalLines }, 'JOURNAL'],
      ['DELETE', `/journal/${vchNo}?coBook=${BOOK}`, undefined, 'JOURNAL'],
      ['GET', `/journal/${vchNo}/print?coBook=${BOOK}&format=html`, undefined, 'JOURNAL'],
    ] as const) {
      const response = await adminRequest(method, url, payload);
      expect(response.statusCode, `${method} ${url} => ${response.body}`).toBe(400);
      expect(response.body).toContain(`MAIN_BOOK='${family}'`);
    }
    expect(await countWriteRows()).toEqual(before);
    expect(await source(vchNo)).toEqual(fineRows);

    const contra = await adminRequest('POST', '/contra?coBook=CON', {
      coBook: 'CON',
      vchDate: DAY,
      lines: money,
    });
    expect(contra.statusCode, contra.body).toBe(201);
    const contraNo = String(contra.json().vchNo).padStart(5, '0');
    const journal = await adminRequest('POST', '/journal?coBook=JV', {
      coBook: 'JV',
      vchDate: DAY,
      lines: journalLines,
    });
    expect(journal.statusCode, journal.body).toBe(201);
    const journalNo = String(journal.json().vchNo).padStart(5, '0');
    for (const url of [
      `/contra/${contraNo}/print?coBook=CON&format=html`,
      `/journal/${journalNo}/print?coBook=JV&format=html`,
    ]) {
      const refused = await request(viewerCookie, 'GET', url);
      expect(refused.statusCode, `${url} => ${refused.body}`).toBe(403);
      expect(refused.json()).toMatchObject({ error: 'forbidden', action: 'print' });
      const printed = await adminRequest('GET', url);
      expect(printed.statusCode, `${url} => ${printed.body}`).toBe(200);
    }
  });
});
