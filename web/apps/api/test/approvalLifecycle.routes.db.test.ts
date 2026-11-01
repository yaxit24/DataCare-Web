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
const RETURN_ONLY = 'aprreturn';
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

function expectEveryStoredColumn(
  actual: Record<string, unknown>,
  expected: Record<string, unknown>,
): void {
  for (const key of Object.keys(expected))
    expect(actual, `unknown expected column ${key}`).toHaveProperty(key);
  for (const [key, value] of Object.entries(actual))
    expect(value, `stored column ${key}`).toEqual(
      Object.prototype.hasOwnProperty.call(expected, key) ? expected[key] : null,
    );
}

type Cookie = string;

(enabled ? describe : describe.skip)('N211 desktop Approval Isu / Approval Rtn lifecycle', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let adminCookie: Cookie;
  let viewerCookie: Cookie;
  let returnOnlyCookie: Cookie;

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
        lotNo: 'LOT-APR',
        itmColor: 'ROSE',
        tagCost: 501.25,
        hallmarkId2: 'HUID2',
        hallmarkId3: 'HUID3',
        hallmarkId4: 'HUID4',
        hallmarkIdWt: 0.101,
        hallmarkId2Wt: 0.102,
        hallmarkId3Wt: 0.103,
        hallmarkId4Wt: 0.104,
        adjustGrossWt: 0.11,
        adjustNetWt: 0.12,
        lessTouch: 0.13,
        lossWt: 0.14,
        remark: 'AUDITED LINE',
        isuAcName: 'Approval counter',
        metalColor: 'YELLOW',
        isuAcCode: 'APCTR',
        tblCode: '001',
        designNo: 'APR-DES',
        itmSize: 'M',
        huid: 'HUID1',
        bagWt: 0.15,
        lessWt: 0.5,
        ghtWt: 0.25,
        rate: 6123.45,
        amount: 61234,
        labourPct: 1.25,
        labourType: 'W',
        labourRate: 237.5,
        labourAmount: 2375,
        otherAmount: 125,
        mrp: 63734,
        discountPct: 2.5,
        discountAmount: 1593.35,
        netAmount: 62140.65,
        itType: 'G',
        karigarNetWt: 10,
        karigarTouch: 91,
        karigarWestPct: 1,
        karigarFine: 9.2,
        karigarName: 'KAR1',
        rateType: 'W',
        prCode: 'AP',
        designImageId: 'IMG-APR',
        stones: [
          {
            itCode: STONE,
            dmCode: 'RD',
            dmName: 'Round',
            dmSize: '1.2MM',
            dmSfNo: 'CERT-1',
            dmLeb: 'GIA',
            dmColor: 'EF',
            dmOrigin: 'LAB',
            dmRemark: 'VS',
            pcs: 2,
            pcsWt: 0.02,
            grossWt: 0.25,
            karigarWt: 0.24,
            conPct: 5,
            karigarLessPct: 1,
            karigarConPct: 4,
            karigarConWt: 0.01,
            rateType: 'W',
            rate: 5000,
            amount: 1250,
            lbrRate: 100,
            lbrAmount: 25,
            netAmount: 1275,
            conWt: 0.013,
            karigarRate: 4500,
            karigarAmount: 1080,
            karigarLabourRate: 90,
            karigarLabourAmount: 21.6,
            karigarNetAmount: 1101.6,
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
       VALUES ($1,'01',$2,$3,'ADMIN','Y','Y','Y','N'),
              ($1,'01',$4,$3,'USER','Y','N','N','N'),
              ($1,'01',$5,$3,'USER','N','N','N','N')`,
      tenantId,
      ADMIN,
      hash,
      VIEWER,
      RETURN_ONLY,
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
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01',$2,'Sales','Approval Rtn','Y','N','N','N')`,
      tenantId,
      RETURN_ONLY,
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
    returnOnlyCookie = await login(RETURN_ONLY);
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
    await exec(`DELETE FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"='TOP'`, tenantId);
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

  it('hydrates a selected tag from BAR_DETL and its BAR_IDTL components', async () => {
    // TR_APR_ISU.cs:5044-5137 copies the BAR_DETL cells and :5153-5202 loads BAR_IDTL stones.
    await exec(
      `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","TAG_NO","VCH_SRNO","IT_CODE","IT_TYPE","DM_CODE","DM_NAME","DM_SIZE","IT_PCS","IT_GWT",
         "IT_RATE_TYPE","IT_RATE","IT_AMT","IT_LBR_RATE","IT_LBR_AMT","IT_NET_AMT")
       VALUES ($1,'01','01',$2,'TOP','09001',1,1,$3::date,$4,$5,$6,'D','RD','Round','1.2MM',2,0.25,
               'W',5000,1250,100,25,1275)`,
      tenantId,
      YEAR,
      DAY,
      TAG,
      TAG_SRNO,
      STONE,
    );
    const response = await admin('GET', `/lookup/available-tags?q=${TAG}`);
    expect(response.statusCode, response.body).toBe(200);
    expect(response.json()).toMatchObject([
      {
        code: TAG,
        IT_CODE: ITEM,
        VCH_SRNO: TAG_SRNO,
        LOT_NO: null,
        TAG_COST: 0,
        HM_ID_WT: 0,
        KR_NET_WT: 10,
        IT_TYPE: 'G',
        stones: [
          {
            itCode: STONE,
            dmCode: 'RD',
            dmName: 'Round',
            dmSize: '1.2MM',
            pcs: 2,
            grossWt: 0.25,
            netAmount: 1275,
            itType: 'D',
          },
        ],
      },
    ]);
  });

  it('rejects invalid approval fields at the HTTP write boundary without a partial write', async () => {
    // TR_APR_ISU.cs:6155-6157 omits pcs-only zero-value rows; column widths come from APR_DETL/APR_IDTL.
    const cases = [
      issueBody({ lines: [{ itCode: ITEM, grossWt: 1, lotNo: 'X'.repeat(16) }] }),
      issueBody({ lines: [{ itCode: ITEM, grossWt: 1, amount: -1 }] }),
      issueBody({ lines: [{ itCode: ITEM, pcs: 1 }] }),
      issueBody({ lines: [{ itCode: 'MISS', grossWt: 1 }] }),
    ];
    for (const payload of cases) {
      const before = await snapshotTenant(owner, tenantId, BUSINESS_TABLES);
      const response = await admin('POST', '/tour/issue', payload);
      expect(response.statusCode, response.body).toBe(400);
      expect(diffTenant(before, await snapshotTenant(owner, tenantId, BUSINESS_TABLES))).toEqual({
        added: {},
        removed: {},
      });
    }
  });

  it('derives fine from net plus ghat and touch plus wastage, with the desktop fallback', async () => {
    // TR_APR_ISU.cs:4000-4067: (net+ght)*(touch+west)/100, or net+ght when purity is zero.
    const computed = await admin(
      'POST',
      '/tour/issue',
      issueBody({
        lines: [
          { itCode: ITEM, grossWt: 10.5, netWt: 10, ghtWt: 0.25, touch: 91.6, westPct: 2 },
          { itCode: ITEM, grossWt: 10.5, netWt: 10, ghtWt: 0.25, touch: 0, westPct: 0 },
        ],
      }),
    );
    expect(computed.statusCode, computed.body).toBe(201);
    expect(
      await query(
        `SELECT "ITM_FINE"::float8 fine FROM "APR_DETL"
          WHERE tenant_id=$1 AND "CO_BOOK"='TUR' ORDER BY "SR_NO"`,
        tenantId,
      ),
    ).toEqual([{ fine: 9.594 }, { fine: 10.25 }]);
    const printed = await admin('GET', '/tour/00001/print?coBook=TUR&format=html');
    expect(printed.statusCode, printed.body).toBe(200);
    expect(printed.body).toContain('N - Approval Ring');
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
              "ISU_LC_CODE" location,"HD_VCH_NO" hidden,"MAIN_USER" "user","USER_UPDATE" updated,
              "USER_DELETE" deleted
         FROM "APR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expect(header).toEqual({
      no: '00001',
      party: PARTY,
      emp: EMP,
      description: 'TAKE FOR APPROVAL',
      issue: null,
      location: '01',
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
    const [fullDetail] = await query<Array<{ row: Record<string, unknown> }>>(
      `SELECT to_jsonb(d)-ARRAY['tenant_id','row_id','VCH_TIME'] row
         FROM "APR_DETL" d WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expectEveryStoredColumn(fullDetail!.row, {
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: YEAR,
      CO_BOOK: 'TUR',
      VCH_NO: '00001',
      SR_NO: 1,
      OLD_SRNO: 1,
      VCH_DATE: DAY,
      HD_VCH_NO: '00001',
      AC_CODE: PARTY,
      EMP_CODE: EMP,
      VCH_TYPE: 'TUR',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'A',
      BOOK_NAME: 'APR ISU',
      VCH_SRNO: TAG_SRNO,
      IT_CODE: ITEM,
      TAG_NO: TAG,
      ISU_REC: 'N',
      EMP_SALE: 'N',
      ITM_PCS: 1,
      ITM_GWT: 10.5,
      ITM_NWT: 10,
      ITM_TOUCH: 91.6,
      ITM_FINE: 9.36,
      ITM_REMARK: 'AUDITED LINE',
      ORNA_REC_DATE: DAY,
      LOT_NO: 'LOT-APR',
      ITM_COLOR: 'ROSE',
      TAG_COST: 501.25,
      HM_ID: 'HUID1',
      HM_ID2: 'HUID2',
      HM_ID3: 'HUID3',
      HM_ID4: 'HUID4',
      HM_ID_WT: 0.101,
      HM_ID2_WT: 0.102,
      HM_ID3_WT: 0.103,
      HM_ID4_WT: 0.104,
      ADJ_GWT: 0.11,
      ADJ_NWT: 0.12,
      ITM_LESS_TCH: 0.13,
      ITM_LOSS_WT: 0.14,
      ISU_AC_NAME: 'Approval counter',
      MTL_COLOR: 'YELLOW',
      ISU_AC_CODE: 'APCTR',
      TBL_CODE: '001',
      DESIGN_NO: 'APR-DES',
      ITM_SIZE: 'M',
      BAG_WT: 0.15,
      ITM_OTH_WT: 0.5,
      ITM_GHT_WT: 0.25,
      ITM_WEST_PRC: 2,
      LBR_PRC: 1.25,
      LBR_TYPE: 'W',
      LBR_RATE: 237.5,
      LBR_AMT: 2375,
      OTH_AMT: 125,
      ITM_RATE: 6123.45,
      ITM_AMT: 61234,
      ITM_MRP: 63734,
      DISC_PRC: 2.5,
      DISC_AMT: 1593.35,
      NET_AMT: 62140.65,
      IT_TYPE: 'G',
      KR_NET_WT: 10,
      KR_TOUCH: 91,
      KR_WEST_PRC: 1,
      KR_FINE: 9.2,
      KR_NAME: 'KAR1',
      RATE_TYPE: 'W',
      PR_CODE: 'AP',
      ISU_LC_CODE: '01',
      DESIGN_IMG_ID: 'IMG-APR',
      MAIN_USER: ADMIN,
    });
    const [stock] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"TR_TYPE" tr,"ITM_SIGN" sign,"DATA_TYPE" dtype,
              "AC_CODE" party,"TAG_NO" tag,"VCH_SRNO"::float8 serial,"ITM_FINE"::float8 fine,
              "EMP_CODE" employee,"ITM_LOT" lot,"ITM_DISC" discount
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
      employee: '',
      lot: '',
      discount: '0',
    });
    const [fullStone] = await query<Array<{ row: Record<string, unknown> }>>(
      `SELECT to_jsonb(d)-ARRAY['tenant_id','row_id'] row
         FROM "APR_IDTL" d WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expectEveryStoredColumn(fullStone!.row, {
      CO_CODE: '01',
      LC_CODE: '01',
      CO_YEAR: YEAR,
      CO_BOOK: 'TUR',
      VCH_NO: '00001',
      SR_NO: 1,
      ISR_NO: 1,
      VCH_DATE: DAY,
      HD_VCH_NO: '00001',
      VCH_TYPE: 'TUR',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'A',
      BOOK_NAME: 'APR ISU',
      AC_CODE: PARTY,
      TAG_NO: TAG,
      VCH_SRNO: TAG_SRNO,
      IT_CODE: STONE,
      IT_TYPE: 'D',
      DM_CODE: 'RD',
      DM_NAME: 'Round',
      DM_SIZE: '1.2MM',
      DM_SFNO: 'CERT-1',
      DM_LEB: 'GIA',
      DM_COLOR: 'EF',
      DM_ORIGIN: 'LAB',
      DM_REMARK: 'VS',
      IT_PCS: 2,
      IT_PCS_WT: 0.02,
      IT_GWT: 0.25,
      KR_WT: 0.24,
      IT_CON_PRC: 5,
      IT_CON_WT: 0.013,
      IT_RATE_TYPE: 'W',
      IT_RATE: 5000,
      IT_AMT: 1250,
      IT_LBR_RATE: 100,
      IT_LBR_AMT: 25,
      IT_NET_AMT: 1275,
      KR_LESS_PRC: 1,
      KR_CON_PRC: 4,
      KR_CON_WT: 0.01,
      KR_RATE: 4500,
      KR_AMT: 1080,
      KR_LBR_RATE: 90,
      KR_LBR_AMT: 21.6,
      KR_NET_AMT: 1101.6,
      MAIN_USER: ADMIN,
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
      partyName: PARTY_NAME,
      empCode: EMP,
      empName: 'Approval Employee',
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
          discountPct: 2.5,
          discountAmount: 1593.35,
          netAmount: 62140.65,
          itType: 'G',
          stones: [
            {
              itCode: STONE,
              dmCode: 'RD',
              dmSize: '1.2MM',
              pcs: 2,
              grossWt: 0.25,
              karigarNetAmount: 1101.6,
            },
          ],
        },
      ],
    });
    expect(reopened.json().vchTime).toMatch(/^\d{2}:\d{2}:\d{2}(?:\.\d+)?$/);

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

  it('preserves a returned issue line and BAR marker when a sparse issue edit changes only the description', async () => {
    // Desktop DISPLAY_DATA restores OLD_SRNO, discounts, ISU_REC, EMP_SALE, linkage and CON_ISU_REC
    // (TR_APR_ISU.cs:5841-5913), and Save writes them back (:6170-6178,6223-6251).
    const issue = await createIssue();
    const returned = await admin('POST', '/tour/return', returnBody(issue.voucherNo));
    expect(returned.statusCode, returned.body).toBe(201);
    const reopened = await admin('GET', `/tour/${issue.voucherNo}?coBook=TUR`);
    expect(reopened.statusCode, reopened.body).toBe(200);

    const sparseLines = [
      {
        oldSrNo: 1,
        itCode: ITEM,
        tagNo: TAG,
        vchSrno: TAG_SRNO,
        pcs: 1,
        grossWt: 10.5,
        netWt: 10,
        touch: 91.6,
        fineWt: 9.36,
      },
    ];
    const unchangedBody = {
      coBook: ISSUE_BOOK,
      expectedVersion: reopened.json().version,
      vchDate: reopened.json().vchDate,
      partyAc: reopened.json().partyAc,
      empCode: reopened.json().empCode,
      vchDesc: reopened.json().vchDesc,
      // ApprovalGrid.tsx intentionally sends a sparse row and omits blank/default/internal columns.
      lines: sparseLines,
    };
    const beforeNoop = await snapshotTenant(owner, tenantId, BUSINESS_TABLES);
    const unchanged = await admin('PUT', `/tour/${issue.voucherNo}`, unchangedBody);
    expect(unchanged.statusCode, unchanged.body).toBe(200);
    expect(unchanged.json().version).toBe(reopened.json().version);
    expect(diffTenant(beforeNoop, await snapshotTenant(owner, tenantId, BUSINESS_TABLES))).toEqual({
      added: {},
      removed: {},
    });

    const edited = await admin('PUT', `/tour/${issue.voucherNo}`, {
      ...unchangedBody,
      vchDesc: 'description only after partial return',
    });
    expect(edited.statusCode, edited.body).toBe(200);
    expect(
      await query(
        `SELECT "OLD_SRNO"::int old_sr,"ISU_REC" received,"EMP_SALE" sale,
                coalesce("CON_ISU_REC",'') consignment
           FROM "APR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2`,
        tenantId,
        issue.voucherNo,
      ),
    ).toEqual([{ old_sr: 1, received: 'Y', sale: 'N', consignment: '' }]);
    expect(
      await query(
        `SELECT "APR_ISU" apr,"APP_TRFR" transfer FROM "BAR_DETL"
          WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        tenantId,
        TAG,
      ),
    ).toEqual([{ apr: 'N', transfer: 'N' }]);
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

  it('refuses the same approval source line twice in one return request without writing', async () => {
    // TR_APR_ISU.cs:4817-4824 scans the grid and refuses a repeated selected tag with exactly this text.
    const issue = await createIssue();
    const duplicate = returnBody(issue.voucherNo, {
      lines: [
        { origSrNo: 1, itCode: ITEM, tagNo: TAG, vchSrno: TAG_SRNO },
        { origSrNo: 1, itCode: ITEM, tagNo: TAG, vchSrno: TAG_SRNO },
      ],
    });
    const before = await snapshotTenant(owner, tenantId, BUSINESS_TABLES);
    const response = await admin('POST', '/tour/return', duplicate);
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().message).toBe('Duplicate Tag No');
    expect(diffTenant(before, await snapshotTenant(owner, tenantId, BUSINESS_TABLES))).toEqual({
      added: {},
      removed: {},
    });
    expect(await stockBalance(TAG)).toBe(0);
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
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"DELETE_USER" "user","AC_NAME" account,
              "FINE_TYPE" fine_type,"VCH_FINE_CR"::float8 fine,
              "VCH_DESC" description FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TRR'`,
      tenantId,
    );
    expect(audits).toEqual([
      {
        vtype: 'TRR',
        book: 'Approval Return',
        user: ADMIN,
        account: PARTY_NAME,
        fine_type: 'G',
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
      `SELECT "VCH_TYPE" vtype,"BOOK_NAME" book,"DELETE_USER" "user","AC_NAME" account,
              "FINE_TYPE" fine_type,"VCH_FINE_CR"::float8 fine,
              "VCH_DESC" description FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TUR'`,
      tenantId,
    );
    expect(audits).toEqual([
      {
        vtype: 'TUR',
        book: 'Approval Issue',
        user: ADMIN,
        account: PARTY_NAME,
        fine_type: 'G',
        fine: 10,
        description: `ItCode / ${ITEM}   TagNo / ${TAG}`,
      },
    ]);
  });

  it('lets a return-only user load Approval Isu source lines without granting issue-form access', async () => {
    const issue = await createIssue();
    const lines = await request(
      returnOnlyCookie,
      'GET',
      `/tour/${issue.voucherNo}/lines?coBook=TUR`,
    );
    expect(lines.statusCode, lines.body).toBe(200);
    expect(lines.json()).toMatchObject([{ srNo: 1, tagNo: TAG, open: true }]);
    const issueView = await request(returnOnlyCookie, 'GET', `/tour/${issue.voucherNo}?coBook=TUR`);
    expect(issueView.statusCode, issueView.body).toBe(403);
  });

  it('contains the non-atomic approval billing bridge without an orphan sale and refuses wrong rights', async () => {
    // Desktop bills approvals through the Sales Invoice Apr No workflow; TR_APR_ISU.cs:6618-6642 only
    // observes the downstream dependency. Until that cross-form transaction exists, this web-only bridge
    // must write nothing rather than create a sale and fail while marking the approval in a second tx.
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC")
       VALUES ($1,'01','APR','Approval items','SALES')`,
      tenantId,
    );
    await exec(
      `UPDATE "ITEM_MAST" SET "GR_CODE"='APR' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
      tenantId,
      ITEM,
    );
    const issue = await createIssue();
    const saleRows = async () =>
      query<Array<{ table_name: string; rows: number }>>(
        `SELECT 'AC_DATA' table_name,count(*)::int rows FROM "AC_DATA" WHERE tenant_id=$1
         UNION ALL SELECT 'SL_DATA',count(*)::int FROM "SL_DATA" WHERE tenant_id=$1
         UNION ALL SELECT 'SL_DETL',count(*)::int FROM "SL_DETL" WHERE tenant_id=$1
         ORDER BY table_name`,
        tenantId,
      );
    const before = await saleRows();
    const payload = {
      coBook: 'SL',
      acCode: PARTY,
      vchDate: DAY,
      taxRatePct: 0,
      interState: false,
      lines: [{ itCode: ITEM, pcs: 1, grossWt: 1, netWt: 1, touch: 91.6, rate: 1000 }],
    };
    const contained = await admin('POST', `/tour/${issue.voucherNo}/bill`, payload);
    expect(contained.statusCode, contained.body).toBe(409);
    expect(contained.json()).toEqual({
      error: 'approval-billing-unavailable',
      message:
        'Approval billing is unavailable until Sales Invoice import and approval closure are atomic.',
    });
    expect(await saleRows()).toEqual(before);
    expect(
      await query(
        `SELECT "ISU_REC" received FROM "APR_DETL"
          WHERE tenant_id=$1 AND "CO_BOOK"='TUR' AND "VCH_NO"=$2`,
        tenantId,
        issue.voucherNo,
      ),
    ).toEqual([{ received: 'N' }]);

    const wrongRights = await request(
      viewerCookie,
      'POST',
      `/tour/${issue.voucherNo}/bill`,
      payload,
    );
    expect(wrongRights.statusCode, wrongRights.body).toBe(403);
    expect(await saleRows()).toEqual(before);
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
