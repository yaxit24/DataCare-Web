import { readFileSync } from 'node:fs';
import { PrismaClient, withTenant } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { diffTenant, snapshotTenant } from './support/tenantSnapshot.js';

/**
 * N211 / G224: Approval Isu and Approval Rtn through the real HTTP routes and forced-RLS database.
 * Expected values are derived from the desktop source, never from the existing web writer:
 *
 * - MDI_FORM.cs:8300-8317 opens TR_APR_ISU only after CurBookHelp('APR ISU'/'APR RTN').
 * - MS_UPDATE.cs:7833 maps both families to APR_DATA/APR_DETL.
 * - TR_APR_ISU.cs:6015-6064 refuses, in order, a new type-B company, an out-of-year date, the
 *   lock date, a missing mandatory employee, missing edit rights, a missing party and missing VchNo.
 * - TR_APR_ISU.cs:6123-6240 writes APR_DATA and APR_DETL with FormBookSname, FormBookInOut and
 *   FormMainBook; :6324-6377 writes APR_IDTL; :6412-6431 marks the issue/return and BAR_DETL flags.
 * - Ac_Stock.cs:60-85 writes issue O/- and return I/+ MAIN_STOCK rows using BOOK_DATA.BOOK_SNAME
 *   and MAIN_BOOK; :887-892 projects APR_IDTL to signed DM_DATA.
 * - TR_APR_ISU.cs:6618-6642 refuses deletion of an outward issue after Approval Return or Wh Sales;
 *   :6648 audits each detail row; :6650-6704 reverses flags and removes the complete write set.
 * - TR_APR_ISU.cs:6712-6772 requires UserPrint and selects AprBill/AprBillImg. AprBill.spec.json
 *   fixes the header, item/stone columns, totals, Vch Desc and signature footer asserted below.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'n211-approval-routes';
const sentinelTenant = 'n211-approval-sentinel';
const PASSWORD = 'N211-Approval-Test!2026';
const SECRET = 'n211-approval-route-signing-secret-over-thirty-two';
const ADMIN = 'apadmin';
const VIEWER = 'apviewer';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const OUT_OF_YEAR = `${startYear - 1}-12-31`;
const ISSUE_BOOK = 'TUR';
const RETURN_BOOK = 'TRR';
const PARTY = 'APRPARTY';
const PARTY_NAME = 'Approval Customer';
const EMP = 'E01';
const ITEM = 'APR01';
const STONE = 'DIA01';
const TAG = 'APR00001';
const TAG2 = 'APR00002';
const TAG_SRNO = 991100001;
const BUSINESS_TABLES = [
  'APR_DATA',
  'APR_DETL',
  'APR_IDTL',
  'MAIN_STOCK',
  'DM_DATA',
  'BAR_DETL',
  'TEMP_BOOK_DATA',
  'REMARK_DATA',
  'DELETE_DATA',
] as const;

const APPROVAL_MIGRATION_SQL = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261101090000_approval_book_identity/migration.sql',
    import.meta.url,
  ),
  'utf8',
);
const APPROVAL_MIGRATION_DML = APPROVAL_MIGRATION_SQL.split(/;\s*(?:\n|$)/)
  .map((statement) => statement.replace(/^\s*--.*$/gm, '').trim())
  .filter((statement) => /^(UPDATE|INSERT)/.test(statement));
type Cookie = string;

(enabled ? describe : describe.skip)('N211 desktop Approval Isu / Approval Rtn lifecycle', () => {
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
  const admin = (method: string, url: string, payload?: unknown) =>
    request(adminCookie, method, url, payload);

  const wipeTenant = async (tenant: string) => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns
        WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${table_name}" WHERE tenant_id=$1`, tenant);
  };

  const login = async (name: string): Promise<Cookie> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    return (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };

  const seedTag = async (tagNo: string, serial: number) => {
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","TBL_CODE","DESIGN_NO","ITM_SIZE","ITM_RATE","ITM_AMT",
         "LBR_RATE","LBR_AMT","OTH_AMT","ITM_MRP","KR_NET_WT","KR_TOUCH","KR_WEST_PRC","KR_FINE",
         "KR_NAME","PR_CODE","IT_TYPE","APR_ISU","APP_TRFR")
       VALUES ($1,'01','01',$2,'TOP','09001',$3,$3,$4::date,'TAG OPENING','I',$5,$6,$7,1,10.5,10,
               91.6,2,9.36,'001','APR-DES','M',6123.45,61234,237.5,2375,125,63734,10,91,1,9.2,
               'KAR1','AP','G','N','N')`,
      tenantId,
      YEAR,
      serial - TAG_SRNO + 1,
      DAY,
      tagNo,
      serial,
      ITEM,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'TOP','09001',$3,1,$4::date,$5,$6,$7,'P','+',1,1,10.5,10)`,
      tenantId,
      YEAR,
      serial - TAG_SRNO + 1,
      DAY,
      ITEM,
      tagNo,
      serial,
    );
  };

  const issueBody = (overrides: Record<string, unknown> = {}) => ({
    coBook: ISSUE_BOOK,
    vchDate: DAY,
    partyAc: PARTY,
    empCode: EMP,
    vchDesc: 'TAKE FOR APPROVAL',
    lines: [
      {
        itCode: ITEM,
        tagNo: TAG,
        vchSrno: TAG_SRNO,
        pcs: 1,
        grossWt: 10.5,
        netWt: 10,
        touch: 91.6,
        westPct: 2,
        fineWt: 9.36,
        tblCode: '001',
        designNo: 'APR-DES',
        itmSize: 'M',
        rate: 6123.45,
        amount: 61234,
        labourRate: 237.5,
        labourAmount: 2375,
        otherAmount: 125,
        mrp: 63734,
        karigarNetWt: 10,
        karigarTouch: 91,
        karigarWestPct: 1,
        karigarFine: 9.2,
        karigarName: 'KAR1',
        prCode: 'AP',
        stones: [
          {
            itCode: STONE,
            dmCode: 'RD',
            dmName: 'Round',
            pcs: 2,
            grossWt: 0.25,
            rate: 5000,
            amount: 1250,
            netAmount: 1250,
            itType: 'D',
          },
        ],
      },
    ],
    ...overrides,
  });

  const createIssue = async (body = issueBody()) => {
    const response = await admin('POST', '/tour/issue', body);
    expect(response.statusCode, response.body).toBe(201);
    return response.json() as { vchNo: number; voucherNo: string; version: string; fine: number };
  };

  const returnBody = (issueNo: string, overrides: Record<string, unknown> = {}) => ({
    coBook: RETURN_BOOK,
    origBook: ISSUE_BOOK,
    origYear: YEAR,
    origVchNo: issueNo,
    vchDate: DAY,
    partyAc: PARTY,
    empCode: EMP,
    vchDesc: 'UNSOLD RETURN',
    lines: [{ origSrNo: 1, itCode: ITEM, tagNo: TAG, vchSrno: TAG_SRNO }],
    ...overrides,
  });

  const stockBalance = async (tagNo: string) => {
    const [row] = await query<Array<{ balance: number }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int balance
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      tagNo,
    );
    return Number(row?.balance ?? 0);
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipeTenant(tenantId);
    await wipeTenant(sentinelTenant);
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR")
       VALUES ($1,'01','01',$2,$3,'10')`,
      tenantId,
      PARTY,
      PARTY_NAME,
    );
    await exec(
      `INSERT INTO "EMP_MAST"(tenant_id,"CO_CODE","EMP_CODE","EMP_NAME") VALUES ($1,'01',$2,'Approval Employee')`,
      tenantId,
      EMP,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","OTH_DETL_POSTING")
       VALUES ($1,'01',$2,'Approval Ring','G','AP','Y'),($1,'01',$3,'Round Diamond','D','DI','Y')`,
      tenantId,
      ITEM,
      STONE,
    );
    const hash = await hashPassword(PASSWORD);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N'),($1,'01',$4,$3,'USER','Y','N','N','N')`,
      tenantId,
      ADMIN,
      hash,
      VIEWER,
    );
    for (const subMenu of ['Approval Isu', 'Approval Rtn'])
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES ($1,'01','01',$2,'Sales',$3,'Y','N','N','N')`,
        tenantId,
        VIEWER,
        subMenu,
      );
    await exec(
      `INSERT INTO "APR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE")
       VALUES ($1,'01','01',$2,'TUR','00001',$3::date,'SENTINEL')`,
      sentinelTenant,
      YEAR,
      DAY,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    adminCookie = await login(ADMIN);
    viewerCookie = await login(VIEWER);
  });

  beforeEach(async () => {
    for (const table of [
      'APR_IDTL',
      'DM_DATA',
      'REMARK_DATA',
      'TEMP_BOOK_DATA',
      'DELETE_DATA',
      'RATE_CUT_ISU',
      'APR_DETL',
      'APR_DATA',
    ])
      await exec(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
    await exec(
      `DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK" IN ('TOP','TUR','TRR')`,
      tenantId,
    );
    await exec(`DELETE FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TOP'`, tenantId);
    await exec(
      `UPDATE "CO_MAST" SET "CO_TYPE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    await exec(
      `UPDATE "CO_SET" SET "LOCK_DATE"=NULL,"EMP_CODE_MANDATORY"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    await seedTag(TAG, TAG_SRNO);
    await seedTag(TAG2, TAG_SRNO + 1);
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipeTenant(tenantId);
    if (owner) await wipeTenant(sentinelTenant);
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('provisions only the desktop APR ISU/APR RTN families over APR_DATA/APR_DETL', async () => {
    const books = await query<Array<Record<string, unknown>>>(
      `SELECT "CO_BOOK" book,"MAIN_BOOK" main,"BOOK_INOUT" inout,"BOOK_TBL_NAME" header,
              "BOOK_TBL_DETL" detail,"BOOK_SNAME" short
         FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK" IN ('TUR','TRR') ORDER BY "CO_BOOK"`,
      tenantId,
    );
    expect(books).toEqual([
      {
        book: 'TRR',
        main: 'APR RTN',
        inout: 'I',
        header: 'APR_DATA',
        detail: 'APR_DETL',
        short: 'TRR',
      },
      {
        book: 'TUR',
        main: 'APR ISU',
        inout: 'O',
        header: 'APR_DATA',
        detail: 'APR_DETL',
        short: 'TUR',
      },
    ]);
  });

  it('refuses another book family before writing and rejects unsupported request fields', async () => {
    const wrong = await admin('POST', '/tour/issue', issueBody({ coBook: RETURN_BOOK }));
    expect(wrong.statusCode, wrong.body).toBe(400);
    expect(wrong.body).toContain("MAIN_BOOK='APR ISU'");
    const extra = await admin(
      'POST',
      '/tour/issue',
      issueBody({ invented: 'must not be stripped' }),
    );
    expect(extra.statusCode, extra.body).toBe(400);
    expect(extra.body).toContain('unsupported field');
    expect(await query(`SELECT 1 FROM "APR_DATA" WHERE tenant_id=$1`, tenantId)).toEqual([]);
  });

  it('uses the desktop save-refusal order and exact texts without a partial write', async () => {
    const message = async (payload: Record<string, unknown>) => {
      const response = await admin('POST', '/tour/issue', issueBody(payload));
      expect(response.statusCode, response.body).toBe(400);
      return String(response.json().message);
    };
    await exec(`UPDATE "CO_MAST" SET "CO_TYPE"='B' WHERE tenant_id=$1`, tenantId);
    await exec(
      `UPDATE "CO_SET" SET "LOCK_DATE"=$2,"EMP_CODE_MANDATORY"='Y' WHERE tenant_id=$1`,
      tenantId,
      DAY,
    );
    expect(await message({ vchDate: OUT_OF_YEAR, empCode: '', partyAc: '' })).toBe(
      'You Cant Save This Voucher Becouse This Company Type is B......',
    );
    await exec(`UPDATE "CO_MAST" SET "CO_TYPE"=NULL WHERE tenant_id=$1`, tenantId);
    expect(await message({ vchDate: OUT_OF_YEAR, empCode: '', partyAc: '' })).toBe(
      'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...',
    );
    const [y, m, d] = DAY.split('-');
    expect(await message({ empCode: '', partyAc: '' })).toBe(
      `You Cant Save and Delete This Voucher Becouse Lock Date is = ${d}/${m}/${y} ....`,
    );
    await exec(`UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1`, tenantId);
    expect(await message({ empCode: '', partyAc: '' })).toBe(
      'Please Select Employee Code and Try......',
    );
    expect(await message({ partyAc: '' })).toBe('Please Insert Party and try');
    expect(await query(`SELECT 1 FROM "APR_DATA" WHERE tenant_id=$1`, tenantId)).toEqual([]);
    expect(await stockBalance(TAG)).toBe(1);
  });

  it('creates the desktop issue write set, reopens every field, no-ops unchanged, edits with a version, and prints AprBill', async () => {
    const sentinelBefore = await query(
      `SELECT * FROM "APR_DATA" WHERE tenant_id=$1`,
      sentinelTenant,
    );
    const created = await createIssue();
    expect(created).toMatchObject({ vchNo: 1, voucherNo: '00001', fine: 9.36 });
    expect(created.version).toMatch(/^[0-9a-f]{64}$/);

    const [header] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_NO" no,"AC_CODE" party,"EMP_CODE" emp,"VCH_DESC" description,"ISU_NO" issue,
              "HD_VCH_NO" hidden,"MAIN_USER" "user","USER_UPDATE" updated,"USER_DELETE" deleted
         FROM "APR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expect(header).toEqual({
      no: '00001',
      party: PARTY,
      emp: EMP,
      description: 'TAKE FOR APPROVAL',
      issue: null,
      hidden: '00001',
      user: ADMIN,
      updated: 'N',
      deleted: 'N',
    });
    const [line] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"INOUT_TYPE" inout,"ENTRY_TYPE" entry,
              "TAG_NO" tag,"VCH_SRNO"::float8 serial,"IT_CODE" item,"ITM_PCS"::float8 pcs,
              "ITM_GWT"::float8 gross,"ITM_NWT"::float8 net,"ITM_TOUCH"::float8 touch,
              "ITM_FINE"::float8 fine,"TBL_CODE" counter,"ISU_REC" received
         FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expect(line).toEqual({
      vtype: 'TUR',
      book: 'APR ISU',
      inout: 'O',
      entry: 'A',
      tag: TAG,
      serial: TAG_SRNO,
      item: ITEM,
      pcs: 1,
      gross: 10.5,
      net: 10,
      touch: 91.6,
      fine: 9.36,
      counter: '001',
      received: 'N',
    });
    const [stock] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"TR_TYPE" tr,"ITM_SIGN" sign,"DATA_TYPE" dtype,
              "AC_CODE" party,"TAG_NO" tag,"VCH_SRNO"::float8 serial,"ITM_FINE"::float8 fine
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expect(stock).toEqual({
      vtype: 'TUR',
      book: 'APR ISU',
      tr: 'O',
      sign: '-',
      dtype: 'A',
      party: PARTY,
      tag: TAG,
      serial: TAG_SRNO,
      fine: 9.36,
    });
    const [bar] = await query<Array<{ APR_ISU: string }>>(
      `SELECT "APR_ISU" FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      TAG,
    );
    expect(bar?.APR_ISU).toBe('Y');
    expect(await stockBalance(TAG)).toBe(0);
    expect(
      await query<Array<Record<string, unknown>>>(
        `SELECT "BOOK_NAME" book,"DM_SIGN" sign,"INOUT_TYPE" inout,"MAIN_SRNO"::int main
           FROM "DM_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
        tenantId,
      ),
    ).toEqual([{ book: 'TUR', sign: '-', inout: 'O', main: 1 }]);
    expect(
      await query(`SELECT 1 FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`, tenantId),
    ).toEqual([]);
    expect(await query(`SELECT * FROM "APR_DATA" WHERE tenant_id=$1`, sentinelTenant)).toEqual(
      sentinelBefore,
    );

    const reopened = await admin('GET', '/tour/00001?coBook=TUR');
    expect(reopened.statusCode, reopened.body).toBe(200);
    expect(reopened.json()).toMatchObject({
      voucherNo: '00001',
      vchDate: DAY,
      partyAc: PARTY,
      empCode: EMP,
      vchDesc: 'TAKE FOR APPROVAL',
      version: created.version,
      lines: [
        {
          oldSrNo: 1,
          itCode: ITEM,
          tagNo: TAG,
          vchSrno: TAG_SRNO,
          grossWt: 10.5,
          netWt: 10,
          touch: 91.6,
          stones: [{ itCode: STONE, dmCode: 'RD', pcs: 2, grossWt: 0.25 }],
        },
      ],
    });

    const unchangedBody = {
      coBook: ISSUE_BOOK,
      expectedVersion: reopened.json().version,
      vchDate: reopened.json().vchDate,
      partyAc: reopened.json().partyAc,
      empCode: reopened.json().empCode,
      vchDesc: reopened.json().vchDesc,
      lines: reopened.json().lines,
    };
    const before = await snapshotTenant(owner, tenantId, BUSINESS_TABLES);
    const unchanged = await admin('PUT', '/tour/00001', unchangedBody);
    expect(unchanged.statusCode, unchanged.body).toBe(200);
    const after = await snapshotTenant(owner, tenantId, BUSINESS_TABLES);
    expect(diffTenant(before, after)).toEqual({ added: {}, removed: {} });
    expect(unchanged.json().version).toBe(created.version);

    const edited = await admin('PUT', '/tour/00001', {
      ...unchangedBody,
      vchDesc: 'edited approval note',
    });
    expect(edited.statusCode, edited.body).toBe(200);
    expect(edited.json().version).not.toBe(created.version);
    const stale = await admin('PUT', '/tour/00001', {
      ...unchangedBody,
      vchDesc: 'stale overwrite',
    });
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json().error).toBe('voucher-version-conflict');

    const printed = await admin('GET', '/tour/00001/print?coBook=TUR&format=html');
    expect(printed.statusCode, printed.body).toBe(200);
    const [y, m, d] = DAY.split('-');
    for (const text of [
      '<title>Approval Issue</title>',
      'ORIGINAL',
      `${d}/${m}/${y}`,
      'Vch No :',
      '00001',
      PARTY_NAME,
      'SNO',
      'Item Name',
      'Pcs.',
      'Gr Wt.',
      'Net Wt',
      'Item Amt',
      'Oth Amt',
      'Net Amount',
      `${TAG} - Approval Ring`,
      'Round Diamond',
      'Total :',
      'Vch Desc :',
      'EDITED APPROVAL NOTE',
      'Party signature.',
      '>signature.<',
    ])
      expect(printed.body, text).toContain(text);
  });

  it('migrates a legacy web return pair so issue/delete dependency and return reversal stay lifecycle-safe', async () => {
    // Legacy writer 8ece8aa8~1 tour.ts:464-525 omitted ISU_YRCD/ISU_DBCD/ISU_LC_CODE and used
    // line ordinals as VCH_SRNO. Desktop TR_APR_ISU.cs:6412-6421 closes the linked source, while
    // :6618-6630 blocks issue deletion and :6679-6694 reopens it and restores BAR_DETL.APR_ISU.
    await exec(
      `UPDATE "BOOK_DATA" SET "MAIN_BOOK"=CASE "CO_BOOK" WHEN 'TUR' THEN 'APPROVAL ISSUE' ELSE 'APPROVAL RETURN' END
        WHERE tenant_id=$1 AND "CO_BOOK" IN ('TUR','TRR')`,
      tenantId,
    );
    await exec(
      `UPDATE "BOOK_DETL" SET "MAIN_BOOK"=CASE "CO_BOOK" WHEN 'TUR' THEN 'APPROVAL ISSUE' ELSE 'APPROVAL RETURN' END
        WHERE tenant_id=$1 AND "CO_BOOK" IN ('TUR','TRR')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "APR_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE",
         "VCH_TIME","HD_VCH_NO","AC_CODE","EMP_CODE","ISU_NO","MAIN_USER","USER_UPDATE","USER_DELETE") VALUES
       ($1,'01','01',$2,'TUR','00041',$3::date,$3::date,'00041',$4,$5,NULL,$6,'N','N'),
       ($1,'01','01',$2,'TRR','00042',$3::date,$3::date,'00042',$4,$5,'00041',$6,'N','N')`,
      tenantId,
      YEAR,
      DAY,
      PARTY,
      EMP,
      ADMIN,
    );
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","VCH_TIME","HD_VCH_NO","AC_CODE","EMP_CODE","VCH_TYPE","INOUT_TYPE","ENTRY_TYPE",
         "BOOK_NAME","VCH_SRNO","IT_CODE","TAG_NO","ISU_REC","EMP_SALE","ISU_NO","ISU_SRNO","ITM_PCS",
         "ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","MAIN_USER") VALUES
       ($1,'01','01',$2,'TUR','00041',1,1,$3::date,$3::date,'00041',$4,$5,'TOUR','O','A','EMP ISU',1,$6,$7,'R','N',NULL,NULL,1,10.5,10,91.6,9.36,$8),
       ($1,'01','01',$2,'TRR','00042',1,1,$3::date,$3::date,'00042',$4,$5,'TOURR','R','A','EMP REC',1,$6,$7,'R','N','00041',1,1,10.5,10,91.6,9.36,$8)`,
      tenantId,
      YEAR,
      DAY,
      PARTY,
      EMP,
      ITEM,
      TAG,
      ADMIN,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","VCH_TYPE","BOOK_NAME","AC_CODE","IT_CODE","TAG_NO","TR_TYPE","ITM_SIGN","ITM_QTY",
         "ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE") VALUES
       ($1,'01','01',$2,'TUR','00041',1,1,$3::date,'TOUR','EMP ISU',$4,$5,$6,'O','-',1,1,10.5,10,91.6,9.36),
       ($1,'01','01',$2,'TRR','00042',1,1,$3::date,'TOURR','EMP REC',$4,$5,$6,'R','+',1,1,10.5,10,91.6,9.36)`,
      tenantId,
      YEAR,
      DAY,
      PARTY,
      ITEM,
      TAG,
    );
    await exec(
      `UPDATE "BAR_DETL" SET "APR_ISU"='N',"APP_TRFR"='N' WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      TAG,
    );

    await withTenant(runtime, tenantId, async (tx: any) => {
      for (const statement of APPROVAL_MIGRATION_DML) await tx.$executeRawUnsafe(statement);
    });

    const issueView = await admin('GET', '/tour/00041?coBook=TUR');
    expect(issueView.statusCode, issueView.body).toBe(200);
    const blocked = await admin(
      'DELETE',
      `/tour/00041?coBook=TUR&expectedVersion=${issueView.json().version}`,
    );
    expect(blocked.statusCode, blocked.body).toBe(400);
    expect(blocked.json().message).toBe(
      'You Cant Delete this Voucher Because This Voucher Is Approval Returne....',
    );

    const returnView = await admin('GET', '/tour/return/00042?coBook=TRR');
    expect(returnView.statusCode, returnView.body).toBe(200);
    const removed = await admin(
      'DELETE',
      `/tour/return/00042?coBook=TRR&expectedVersion=${returnView.json().version}`,
    );
    expect(removed.statusCode, removed.body).toBe(200);
    expect(
      await query(
        `SELECT "ISU_REC" received,"VCH_SRNO"::float8 serial FROM "APR_DETL"
          WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"='00041'`,
        tenantId,
      ),
    ).toEqual([{ received: 'N', serial: TAG_SRNO }]);
    expect(
      await query(
        `SELECT "APR_ISU" apr,"APP_TRFR" transfer FROM "BAR_DETL"
          WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        tenantId,
        TAG,
      ),
    ).toEqual([{ apr: 'Y', transfer: 'N' }]);
  });

  it('refuses issue deletion after a return and after Wh Sales, with the exact desktop texts', async () => {
    const created = await createIssue();
    const returned = await admin('POST', '/tour/return', returnBody(created.voucherNo));
    expect(returned.statusCode, returned.body).toBe(201);
    const blockedReturn = await admin(
      'DELETE',
      `/tour/${created.voucherNo}?coBook=TUR&expectedVersion=${created.version}`,
    );
    expect(blockedReturn.statusCode, blockedReturn.body).toBe(400);
    expect(blockedReturn.json().message).toBe(
      'You Cant Delete this Voucher Because This Voucher Is Approval Returne....',
    );

    await admin(
      'DELETE',
      `/tour/return/${returned.json().voucherNo}?coBook=TRR&expectedVersion=${returned.json().version}`,
    );
    const fresh = (await admin('GET', '/tour/00001?coBook=TUR')).json();
    await exec(
      `INSERT INTO "RATE_CUT_ISU"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
         "ISU_YRCD","ISU_DBCD","ISU_NO","ISU_SRNO","BOOK_NAME")
       VALUES ($1,'01','01',$2::text,'WHS','00009',1,$2::text,'TUR','00001',1,'WH SALES')`,
      tenantId,
      YEAR,
    );
    const blockedSale = await admin(
      'DELETE',
      `/tour/00001?coBook=TUR&expectedVersion=${fresh.version}`,
    );
    expect(blockedSale.statusCode, blockedSale.body).toBe(400);
    expect(blockedSale.json().message).toBe(
      'You Cant Delete this Voucher Because This Voucher Use In Wh Sales....',
    );
  });

  it('creates, reopens, no-ops, edits, prints and deletes Approval Rtn with source and BAR reversals', async () => {
    const issue = await createIssue();
    const returned = await admin('POST', '/tour/return', returnBody(issue.voucherNo));
    expect(returned.statusCode, returned.body).toBe(201);
    expect(returned.json()).toMatchObject({ voucherNo: '00001', closedLines: 1, fine: 9.36 });
    expect(returned.json().version).toMatch(/^[0-9a-f]{64}$/);

    const [line] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"INOUT_TYPE" inout,"ENTRY_TYPE" entry,"ISU_REC" received,
              "ISU_YRCD" iy,"ISU_DBCD" ib,"ISU_NO" ino,"ISU_SRNO"::int isr,"VCH_SRNO"::float8 serial
         FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TRR'`,
      tenantId,
    );
    expect(line).toEqual({
      vtype: 'TRR',
      book: 'APR RTN',
      inout: 'I',
      entry: 'A',
      received: 'N',
      iy: YEAR,
      ib: ISSUE_BOOK,
      ino: issue.voucherNo,
      isr: 1,
      serial: TAG_SRNO,
    });
    const [stock] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"TR_TYPE" tr,"ITM_SIGN" sign,"DATA_TYPE" dtype
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TRR'`,
      tenantId,
    );
    expect(stock).toEqual({ vtype: 'TRR', book: 'APR RTN', tr: 'I', sign: '+', dtype: 'A' });
    const flags = async () =>
      (
        await query<Array<Record<string, unknown>>>(
          `SELECT
             (SELECT "ISU_REC" FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"='00001') issue,
             (SELECT "APR_ISU" FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$2) apr,
             (SELECT "APP_TRFR" FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$2) transfer`,
          tenantId,
          TAG,
        )
      )[0]!;
    expect(await flags()).toEqual({ issue: 'Y', apr: 'N', transfer: 'N' });
    expect(await stockBalance(TAG)).toBe(1);

    const reopened = await admin('GET', '/tour/return/00001?coBook=TRR');
    expect(reopened.statusCode, reopened.body).toBe(200);
    expect(reopened.json()).toMatchObject({
      voucherNo: '00001',
      origVchNo: issue.voucherNo,
      origBook: ISSUE_BOOK,
      origYear: YEAR,
      partyAc: PARTY,
      empCode: EMP,
      vchDesc: 'UNSOLD RETURN',
      lines: [{ origSrNo: 1, tagNo: TAG, vchSrno: TAG_SRNO }],
    });
    const body = {
      coBook: RETURN_BOOK,
      expectedVersion: reopened.json().version,
      origBook: reopened.json().origBook,
      origYear: reopened.json().origYear,
      origVchNo: reopened.json().origVchNo,
      vchDate: reopened.json().vchDate,
      partyAc: reopened.json().partyAc,
      empCode: reopened.json().empCode,
      vchDesc: reopened.json().vchDesc,
      lines: reopened.json().lines,
    };
    const before = await snapshotTenant(owner, tenantId, BUSINESS_TABLES);
    const unchanged = await admin('PUT', '/tour/return/00001', body);
    expect(unchanged.statusCode, unchanged.body).toBe(200);
    expect(diffTenant(before, await snapshotTenant(owner, tenantId, BUSINESS_TABLES))).toEqual({
      added: {},
      removed: {},
    });

    const edited = await admin('PUT', '/tour/return/00001', {
      ...body,
      vchDesc: 'edited return note',
    });
    expect(edited.statusCode, edited.body).toBe(200);
    const stale = await admin('PUT', '/tour/return/00001', { ...body, vchDesc: 'stale' });
    expect(stale.statusCode, stale.body).toBe(409);

    const printed = await admin('GET', '/tour/return/00001/print?coBook=TRR&format=html');
    expect(printed.statusCode, printed.body).toBe(200);
    expect(printed.body).toContain('<title>Approval Return</title>');
    expect(printed.body).toContain('EDITED RETURN NOTE');

    const removed = await admin(
      'DELETE',
      `/tour/return/00001?coBook=TRR&expectedVersion=${edited.json().version}`,
    );
    expect(removed.statusCode, removed.body).toBe(200);
    expect(await flags()).toEqual({ issue: 'N', apr: 'Y', transfer: 'N' });
    expect(await stockBalance(TAG)).toBe(0);
    expect(
      await query(`SELECT 1 FROM "APR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TRR'`, tenantId),
    ).toEqual([]);
    const audits = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"DELETE_USER" "user","VCH_FINE_CR"::float8 fine,
              "VCH_DESC" description FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TRR'`,
      tenantId,
    );
    expect(audits).toEqual([
      {
        vtype: 'TRR',
        book: 'Approval Return',
        user: ADMIN,
        fine: 10,
        description: `ItCode / ${ITEM}   TagNo / ${TAG}`,
      },
    ]);
  });

  it('deletes an unconsumed issue with the desktop audit and restores BAR availability', async () => {
    const created = await createIssue();
    const deleted = await admin(
      'DELETE',
      `/tour/${created.voucherNo}?coBook=TUR&expectedVersion=${created.version}`,
    );
    expect(deleted.statusCode, deleted.body).toBe(200);
    expect(await stockBalance(TAG)).toBe(1);
    const [bar] = await query<Array<{ APR_ISU: string }>>(
      `SELECT "APR_ISU" FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      TAG,
    );
    expect(bar?.APR_ISU).toBe('N');
    const audits = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"DELETE_USER" "user","VCH_FINE_CR"::float8 fine,
              "VCH_DESC" description FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expect(audits).toEqual([
      {
        vtype: 'TUR',
        book: 'Approval Issue',
        user: ADMIN,
        fine: 10,
        description: `ItCode / ${ITEM}   TagNo / ${TAG}`,
      },
    ]);
  });

  it('enforces the separate menu rights, including print rights, on both resources', async () => {
    const issue = await createIssue();
    const view = await request(viewerCookie, 'GET', '/tour/00001?coBook=TUR');
    expect(view.statusCode, view.body).toBe(200);
    const print = await request(viewerCookie, 'GET', '/tour/00001/print?coBook=TUR&format=html');
    expect(print.statusCode, print.body).toBe(403);
    expect(print.json()).toMatchObject({ error: 'forbidden', action: 'print' });
    const update = await request(viewerCookie, 'PUT', '/tour/00001', {
      ...issueBody(),
      expectedVersion: issue.version,
    });
    expect(update.statusCode, update.body).toBe(403);
    const remove = await request(
      viewerCookie,
      'DELETE',
      `/tour/00001?coBook=TUR&expectedVersion=${issue.version}`,
    );
    expect(remove.statusCode, remove.body).toBe(403);
    expect(await stockBalance(TAG)).toBe(0);
  });
});
