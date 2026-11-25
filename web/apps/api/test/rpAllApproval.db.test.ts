import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-13: Approval Rpt (desktop RP_ALL, caption "Approval Rpt") through the real Fastify route on the
 * isolated database under forced RLS. NEEDS A STACK RUN: the parity wrapper sets RUN_DB_INTEGRITY_TESTS.
 *
 * Every expected amount is added up here from the fixture lines with the desktop template formula
 * (AprPartyWise.xml / AprInOut.xml / AprPan.xml; RP_ALL.cs:8199, 8274, 8349), never read back from the
 * application. The three modes are the three approval buttons of RP_ALL.cs:8141-8365.
 */

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'wp13-approval-db';
const OTHER_TENANT = 'wp13-approval-other';
const PASSWORD = 'Wp13-Approval!2026';
const SECRET = 'wp13-approval-test-signing-secret-over-thirty-two-characters';
const now = new Date();
const Y = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${Y}-${Y + 1}`;
const OLD_YEAR = `${Y - 1}-${Y}`;
const FROM = '2010-01-01';
const TO = `${Y}-07-15`;
const D09 = `${Y}-07-09`;
const D10 = `${Y}-07-10`;
const D11 = `${Y}-07-11`;
const D12 = `${Y}-07-12`;
const D13 = `${Y}-07-13`;
const D14 = `${Y}-07-14`;
const OLD_DATE = `${Y - 1}-06-15`;
const BOOK = '018';
const RETURN_BOOK = 'A2';
const SALES_BOOK = 'X1';
const LEGACY_BOOK = 'L1';

interface LineSeed {
  vch: string;
  sr: number;
  date: string;
  ac: string;
  it: string;
  tag: string | null;
  pcs: number;
  gwt: number;
  nwt: number;
  oth: number;
  itmAmt: number;
  lbr: number;
  net: number;
  fine?: number;
  status?: string | null;
  lc?: string;
  co?: string;
  year?: string;
  book?: string;
  design?: string;
}

const line = (
  over: Partial<LineSeed> & Pick<LineSeed, 'vch' | 'sr' | 'date' | 'ac' | 'it'>,
): LineSeed => ({
  tag: `T${over.vch}${over.sr}`,
  pcs: 1,
  gwt: 10,
  nwt: 9,
  oth: 0.5,
  itmAmt: 100,
  lbr: 10,
  net: 110,
  fine: 0,
  status: 'N',
  lc: '01',
  co: '01',
  year: YEAR,
  book: BOOK,
  design: 'D1',
  ...over,
});

/** The worked vouchers of cases.md §Test data, each as its APR_DETL lines. */
const FIXTURES: Record<string, LineSeed[]> = {
  V1: [
    line({
      vch: 'V1',
      sr: 1,
      date: D10,
      ac: 'P1',
      it: 'I1',
      tag: 'T1',
      pcs: 1,
      gwt: 10.5,
      nwt: 10,
      itmAmt: 500,
      lbr: 50,
      oth: 10,
      net: 560,
      fine: 9.16,
      status: 'N',
      design: 'DES1',
    }),
    line({
      vch: 'V1',
      sr: 2,
      date: D10,
      ac: 'P1',
      it: 'I2',
      tag: 'T2',
      pcs: 2,
      gwt: 20,
      nwt: 19,
      itmAmt: 800,
      lbr: 80,
      oth: 20,
      net: 900,
      fine: 0,
      status: 'N',
      design: 'DES2',
    }),
  ],
  V2: [
    line({
      vch: 'V2',
      sr: 1,
      date: D12,
      ac: 'P2',
      it: 'I1',
      tag: 'T3',
      pcs: 3,
      gwt: 31.5,
      nwt: 30,
      itmAmt: 1500,
      lbr: 150,
      oth: 30,
      net: 1680,
      fine: 9.16,
      status: 'N',
      design: 'DES3',
    }),
  ],
  V3: [line({ vch: 'V3', sr: 1, date: D11, ac: 'P1', it: 'I1', lc: '02' })],
  V4: [line({ vch: 'V4', sr: 1, date: OLD_DATE, ac: 'P1', it: 'I1', year: OLD_YEAR })],
  V5: [line({ vch: 'V5', sr: 1, date: D10, ac: 'P1', it: 'I1', book: SALES_BOOK })],
  V6: [line({ vch: 'V6', sr: 1, date: D13, ac: 'P1', it: 'I1', book: RETURN_BOOK, status: 'Y' })],
  V7: [
    line({ vch: 'V7', sr: 1, date: D13, ac: 'P3', it: 'I1', status: null }),
    line({ vch: 'V7', sr: 2, date: D13, ac: 'P3', it: 'I1', status: '' }),
    line({ vch: 'V7', sr: 3, date: D13, ac: 'P3', it: 'I1', status: 'N' }),
    line({ vch: 'V7', sr: 4, date: D13, ac: 'P3', it: 'I1', status: 'Y' }),
    line({ vch: 'V7', sr: 5, date: D13, ac: 'P3', it: 'I1', status: 'R' }),
  ],
  V8: [
    line({
      vch: 'V8',
      sr: 1,
      date: D14,
      ac: 'P3',
      it: 'I1',
      tag: 'Z0',
      pcs: 0,
      gwt: 0,
      nwt: 0,
      oth: 5,
      net: 0,
    }),
    line({
      vch: 'V8',
      sr: 2,
      date: D14,
      ac: 'P3',
      it: 'I1',
      tag: 'Z0',
      pcs: 0,
      gwt: 0,
      nwt: 0,
      oth: 3,
      net: 0,
    }),
  ],
  V9: [
    line({ vch: 'V9', sr: 1, date: D14, ac: 'P3', it: 'I1', tag: 'N', pcs: 1 }),
    line({ vch: 'V9', sr: 2, date: D14, ac: 'P3', it: 'I1', tag: 'N', pcs: 2 }),
  ],
  V10: [line({ vch: 'V10', sr: 1, date: D10, ac: 'P1', it: 'I1', book: LEGACY_BOOK })],
  V11: [line({ vch: 'V11', sr: 1, date: D09, ac: 'P1', it: 'I1' })],
  V12: [line({ vch: 'V12', sr: 1, date: D13, ac: 'P1', it: 'I1' })],
  VSENT: [line({ vch: 'Z-CO', sr: 1, date: D10, ac: 'P1', it: 'I1', co: '02' })],
};

const V1L1 = FIXTURES.V1![0]!;
const V1L2 = FIXTURES.V1![1]!;
const V2L1 = FIXTURES.V2![0]!;

const round = (x: number, dp: number) => Number(x.toFixed(dp));
const sum = <T>(xs: T[], f: (x: T) => number, dp = 2) =>
  round(
    xs.reduce((s, x) => s + f(x), 0),
    dp,
  );

type Row = Record<string, any>;
const rowsOf = (b: any): Row[] => (Array.isArray(b?.rows) ? b.rows : []);
const totalsOf = (b: any): Record<string, number> =>
  b?.totals && typeof b.totals === 'object' ? b.totals : {};
/** Read a value whether the engine returns it flat or in a row's `cells` map. */
const field = (r: Row, ...keys: string[]): any => {
  for (const k of keys) {
    if (r[k] !== undefined && r[k] !== null) return r[k];
    if (r.cells && r.cells[k] !== undefined && r.cells[k] !== null) return r.cells[k];
  }
  return undefined;
};
const vchOf = (r: Row): string => String(field(r, 'vchNo', 'VCH_NO', 'voucherKey') ?? '');
const vchs = (b: any): string[] => [...new Set(rowsOf(b).map((r) => vchOf(r)))].sort();
const pcsOf = (r: Row): number => Number(field(r, 'pcs', 'itmPcs', 'outPcs') ?? 0);
const outOf = (r: Row): number => Number(field(r, 'outPcs', 'pcs') ?? 0);
const inOf = (r: Row): number => Number(field(r, 'inPcs') ?? 0);
const panOf = (r: Row): number => Number(field(r, 'pendingPcs', 'panPcs', 'pcs') ?? 0);
const gwtOf = (r: Row): number => Number(field(r, 'grossWt', 'grWt', 'gwt') ?? 0);
const othOf = (r: Row): number => Number(field(r, 'otherAmount', 'othAmt') ?? 0);
const itmAmtOf = (r: Row): number => Number(field(r, 'itemAmount', 'itmAmt') ?? 0);
const groupsOf = (b: any): any[] => (Array.isArray(b?.groups) ? b.groups : []);

(enabled ? describe : describe.skip)('Approval Rpt through HTTP under forced RLS (WP-13)', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async (tenant: string) => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of tables)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
  };
  const wipeData = async (tenant: string) => {
    for (const table of [
      'APR_DETL',
      'BOOK_DATA',
      'ITEM_MAST',
      'PRODUCT_MAST',
      'GROUP_MAST',
      'AC_MAST',
    ])
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
  };
  const loginAs = async (name: string, lcCode: string) => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': TENANT },
      payload: { coCode: '01', lcCode, coYear: YEAR, loginName: name, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const values = response.headers['set-cookie'];
    return (Array.isArray(values) ? values : [values ?? ''])
      .map((value) => value.split(';', 1)[0])
      .join('; ');
  };
  const login = (name: string) => loginAs(name, '01');
  const get = (user: string, url: string) =>
    app.inject({ method: 'GET', url, headers: { cookie: cookies[user]! } });
  const report = async (query = '', user = 'printer') => {
    const response = await get(
      user,
      `/reports/approval-report?fromDate=${FROM}&toDate=${TO}&${query}`,
    );
    expect(response.statusCode, response.body).toBe(200);
    return response.json();
  };
  /** A head-office (00) run, the desktop's editable lc box (RP_ALL.cs:6660). */
  const headReport = async (query = '', user = 'headprinter') => {
    const response = await get(
      user,
      `/reports/approval-report?fromDate=${FROM}&toDate=${TO}&${query}`,
    );
    expect(response.statusCode, response.body).toBe(200);
    return response.json();
  };

  const insertLine = async (tenant: string, l: LineSeed) => {
    await exec(
      `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","AC_CODE","BOOK_NAME","IT_CODE","TAG_NO","DESIGN_NO",
        "ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","ITM_AMT","LBR_AMT","OTH_AMT","NET_AMT","ISU_REC","ISU_AC_NAME","MAIN_USER")
       VALUES($1,$2,$3,$4,$5,$6,$7,$8::date,$9,$10,$11,$12,$13,$14,$15,$16,$17,$18,$19,$20,$21,$22,$23,$24)`,
      tenant,
      l.co ?? '01',
      l.lc ?? '01',
      l.year ?? YEAR,
      l.book ?? BOOK,
      l.vch,
      l.sr,
      l.date,
      l.ac,
      'APPROVAL ISSUE',
      l.it,
      l.tag,
      l.design ?? 'D1',
      l.pcs,
      l.gwt,
      l.nwt,
      l.fine ?? 0,
      l.itmAmt,
      l.lbr,
      l.oth,
      l.net,
      l.status ?? null,
      `Snapshot ${l.ac}`,
      'WP13USER',
    );
  };

  /** Re-seed only the fixtures a case needs, so no case inherits another case's rows. */
  const reset = async (names: string[], tenant = TENANT) => {
    await wipeData(TENANT);
    await wipeData(OTHER_TENANT);
    for (const t of [TENANT, OTHER_TENANT]) {
      await exec(
        `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_CITY","AC_AREA") VALUES
         ($1,'01','01','P1','Party P1','C1','AR1'),($1,'01','01','P2','Party P2','C2','AR2'),
         ($1,'01','01','P3','Party P3','C1','AR1'),($1,'01','02','P4','Party P4','C1','AR1')`,
        t,
      );
      await exec(
        `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES
         ($1,'01','P1','Product P1'),($1,'01','P2','Product P2')`,
        t,
      );
      await exec(
        `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME") VALUES
         ($1,'01','G1','Group G1'),($1,'01','G2','Group G2')`,
        t,
      );
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE") VALUES
         ($1,'01','I1','Gold Item','G','P1','G1'),($1,'01','I2','Silver Item','S','P2','G2'),
         ($1,'01','I4','Stone Item','R','P1','G1')`,
        t,
      );
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","DATA_TYPE") VALUES
         ($1,'01','01','018','Approval Issue','APR ISU','A'),($1,'01','01','A2','Approval Return','APR RTN','A'),
         ($1,'01','01','X1','Sales','SALES','A'),($1,'01','01','L1','Legacy Approval','APPROVAL ISSUE','A'),
         ($1,'01','02','018','Approval Issue Loc02','APR ISU','A')`,
        t,
      );
    }
    for (const name of names) {
      for (const l of FIXTURES[name] ?? []) await insertLine(tenant, l);
    }
    // A sentinel in the other tenant with the same visible voucher number as V1.
    await insertLine(OTHER_TENANT, line({ vch: 'V1', sr: 1, date: D10, ac: 'P1', it: 'I1' }));
    await insertLine(OTHER_TENANT, line({ vch: 'Z-TN', sr: 1, date: D10, ac: 'P1', it: 'I1' }));
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe(TENANT);
    await wipe(OTHER_TENANT);
    await seedCompany(runtime, TENANT, '01', { coName: 'WP13 Approval Jewellers', lcCode: '01' });
    await seedCompany(runtime, OTHER_TENANT, '01', { coName: 'Other Tenant', lcCode: '01' });
    for (const [name, view, print] of [
      ['viewer', 'Y', 'N'],
      ['printer', 'Y', 'Y'],
      ['blocked', 'N', 'N'],
    ] as const) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','N','N',$4,'N')`,
        TENANT,
        name,
        await hashPassword(PASSWORD),
        print,
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Report','Approval Report',$3,'N','N',$4)`,
        TENANT,
        name,
        view,
        print,
      );
    }
    // The head-office session of RP_ALL.cs:6660: location 00 exists, and its user holds the Approval
    // Report view+print rights at 00 (authorizeForm reads the session location's USER_SET row).
    await exec(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE")
       VALUES($1,'01','00','Head Office','BRANCH')`,
      TENANT,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01','headprinter',$2,'USER','N','N','Y','N')`,
      TENANT,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','00','headprinter','Report','Approval Report','Y','N','N','Y')`,
      TENANT,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    cookies.viewer = await login('viewer');
    cookies.printer = await login('printer');
    cookies.blocked = await login('blocked');
    cookies.headprinter = await loginAs('headprinter', '00');
  });

  beforeEach(async () => {
    await reset(['V1', 'V2', 'V3', 'V4', 'V5', 'V7', 'V8', 'V9', 'V10', 'V11', 'V12', 'VSENT']);
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipe(TENANT);
      await wipe(OTHER_TENANT);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('approval-report.filters.one-at-a-time: each selector appends only its own predicate', async () => {
    await reset(['V1', 'V2', 'V3']);
    const party = await report('mode=issue&acCode=P1');
    expect(rowsOf(party)).toHaveLength(2); // P1's two V1 lines only
    expect(vchs(party)).toEqual(['V1']);

    await reset(['V1', 'V2']);
    const product = await report('mode=issue&prCode=P1');
    expect(vchs(product), 'P1 is ITEM_MAST.PR_CODE, not IT_CODE').toEqual(['V1', 'V2']);
    expect(rowsOf(product).map(vchOf).sort()).toEqual(['V1', 'V2']);

    await reset(['V1', 'V2', 'V3', 'V9']);
    const city = await report('mode=issue&city=C1');
    expect(vchs(city), 'V2 is in city C2 and must be excluded').not.toContain('V2');
    expect(vchs(city)).toContain('V1');
    expect(vchs(city)).toContain('V9');

    await reset(['V1', 'V2']);
    const group = await report('mode=issue&grCode=G1');
    expect(vchs(group), 'G1 is the item group of I1').toEqual(['V1', 'V2']);

    // RP_ALL.cs:8156 {{CurFormula = CurFormula + " And {APR_DETL.LC_CODE} = '" + tLcCode.Text + "'";}}
    // Location 01 is the session location, so the location-02 voucher V3 is out in every mode.
    await reset(['V1', 'V2', 'V3']);
    for (const mode of ['issue', 'inout', 'pending']) {
      expect(vchs(await report(`mode=${mode}`))).not.toContain('V3');
    }
  });

  it('approval-report.filters.date-range-inclusive-and-year: inclusive endpoints and session year', async () => {
    await reset(['V1', 'V2', 'V4', 'V11', 'V12']);
    const body = await report('mode=issue'); // FROM=D10, TO=D12 by parameter
    const url = `/reports/approval-report?fromDate=${D10}&toDate=${D12}&mode=issue`;
    const r = await get('printer', url);
    expect(r.statusCode, r.body).toBe(200);
    expect(vchs(r.json()), 'V1 is on From and V2 is on To').toEqual(['V1', 'V2']);
    expect(vchs(r.json())).not.toContain('V11'); // the day before
    expect(vchs(r.json())).not.toContain('V12'); // the day after
    // RP_ALL.cs:8152 {{CurFormula = "{APR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {APR_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";}}
    expect(vchs(body)).toContain('V1');
  });

  it('approval-report.filters.item-type-first-character: Real Stone/Gold/Emitation/blank', async () => {
    await reset(['V1', 'V2']);
    await insertLine(TENANT, line({ vch: 'V15', sr: 1, date: D10, ac: 'P1', it: 'I4', tag: 'T4' }));
    const real = await report('mode=issue&itType=R');
    expect(vchs(real), 'Real Stone uses only the first character R').toEqual(['V15']);
    const gold = await report('mode=issue&itType=G');
    expect(vchs(gold)).toEqual(['V1', 'V2']);
    const emit = await report('mode=issue&itType=E');
    expect(rowsOf(emit), 'Emitation has no matching line in this seed').toHaveLength(0);
    // RP_ALL.cs:8180 {{CurFormula = CurFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";}}
    const blank = await report('mode=issue&itType=');
    expect(rowsOf(blank)).toHaveLength(4);
  });

  it('approval-report.filters.combined-and: party AND product AND city conjunct', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=issue&acCode=P1&prCode=P1&city=C1');
    // RP_ALL.cs:8162 {{if (Operators.CompareString(tAcCode.Text, "", false) != 0)}}
    expect(rowsOf(body)).toHaveLength(1);
    expect(vchs(body)).toEqual(['V1']);
  });

  it('approval-report.filters.main-book-family: every mode requires the APR ISU book family', async () => {
    await reset(['V1', 'V2', 'V5', 'V6', 'V10']);
    for (const mode of ['issue', 'inout', 'pending']) {
      const b = await report(`mode=${mode}`);
      // RP_ALL.cs:8153 {{CurFormula += " And {BOOK_DATA.MAIN_BOOK} = 'APR ISU'";}}
      expect(vchs(b), `${mode} must not show SALES or APR RTN books`).not.toContain('V5');
      expect(vchs(b), `${mode} must not show APR RTN books`).not.toContain('V6');
    }
    // D6: the web also accepts the provisioned legacy APPROVAL ISSUE family (V10), recorded explicitly.
    expect(vchs(await report('mode=issue'))).toContain('V10');
  });

  it('approval-report.filters.pending-exact-n: Pending selects exact N, legacy R is not N', async () => {
    await reset(['V7']);
    const pending = await report('mode=pending');
    // RP_ALL.cs:8302 {{CurFormula = "{APR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DETL.ISU_REC} = 'N' AND {APR_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {APR_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";}}
    expect(rowsOf(pending)).toHaveLength(1); // only the N line; null/blank/Y/R excluded
    expect(sum(rowsOf(pending), pcsOf, 3)).toBe(1);

    const inout = await report('mode=inout');
    // D6 records the web compatibility: legacy R counts as resolved as well as Y.
    expect(sum(rowsOf(inout), outOf, 3)).toBe(5);
    expect(sum(rowsOf(inout), inOf, 3)).toBe(2);
    expect(sum(rowsOf(inout), panOf, 3)).toBe(3);
  });

  it('approval-report.formula.issue-party-sums: voucher and party sums at stored precision', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=issue');
    // RP_ALL.cs:8199 {{DC_Main.RptName = "AprPartyWise";}}
    const v1 = rowsOf(body).filter((r) => vchOf(r) === 'V1');
    expect(sum(v1, pcsOf, 3)).toBe(3);
    expect(sum(v1, gwtOf, 3)).toBe(30.5);
    expect(sum(v1, (r) => Number(field(r, 'netWt', 'nwt') ?? 0), 3)).toBe(29);
    expect(sum(v1, itmAmtOf)).toBe(1300);
    expect(sum(v1, (r) => Number(field(r, 'labourAmount', 'lbrAmt') ?? 0))).toBe(130);
    expect(sum(v1, othOf)).toBe(30);

    const p2 = rowsOf(body).filter((r) => String(field(r, 'acCode') ?? '') === 'P2');
    expect(sum(p2, pcsOf, 3)).toBe(3);
    expect(sum(p2, gwtOf, 3)).toBe(31.5);
    expect(sum(p2, itmAmtOf)).toBe(1500);
    expect(
      rowsOf(body)
        .map((r) => Number(field(r, 'netAmount', 'netAmt') ?? 0))
        .sort((a, b) => a - b),
    ).toEqual([560, 900, 1680]);
    // AprPartyWise has no report-footer grand total (RP_ALL.cs:8199 selects it): the report-footer band
    // Section11 holds no field, so the result must not print one (Pcs is still summed at both bands).
    expect(body.grandTotal).toBe(false);
  });

  it('approval-report.formula.inout-out-in-pending: issue-line status before and after resolution', async () => {
    await reset(['V1', 'V2']);
    const before = await report('mode=inout');
    const byVch = (b: any, v: string) => rowsOf(b).filter((r) => vchOf(r) === v);
    expect(sum(byVch(before, 'V1'), outOf, 3)).toBe(3);
    expect(sum(byVch(before, 'V1'), inOf, 3)).toBe(0);
    expect(sum(byVch(before, 'V1'), panOf, 3)).toBe(3);
    const v2 = byVch(before, 'V2');
    expect(sum(v2, outOf, 3)).toBe(3);
    expect(sum(v2, panOf, 3)).toBe(3);

    // The return writer sets ISU_REC='Y' on V1L1 (TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}).
    await exec(
      `UPDATE "APR_DETL" SET "ISU_REC"='Y' WHERE tenant_id=$1 AND "VCH_NO"='V1' AND "SR_NO"=1`,
      TENANT,
    );
    const after = await report('mode=inout');
    const v1After = byVch(after, 'V1').filter(
      (r) => Number(field(r, 'srNo') ?? field(r, 'sr') ?? 0) === 1,
    );
    expect(sum(v1After, outOf, 3)).toBe(1);
    expect(sum(v1After, inOf, 3)).toBe(1);
    expect(sum(v1After, panOf, 3)).toBe(0);
    expect(sum(byVch(after, 'V2'), panOf, 3)).toBe(3);
  });

  it('approval-report.formula.inout-sum-levels: product headers, party footers and grand total', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=inout');
    // RP_ALL.cs:8274 {{DC_Main.RptName = "AprInOut";}}
    const pr1 = rowsOf(body).filter(
      (r) => String(field(r, 'productCode', 'prCode') ?? '') === 'P1',
    );
    const pr2 = rowsOf(body).filter(
      (r) => String(field(r, 'productCode', 'prCode') ?? '') === 'P2',
    );
    expect(
      sum(pr1, (r) => gwtOf(r), 3),
      'P1 header TagGwt = V1L1 + V2L1',
    ).toBe(42);
    expect(sum(pr1, (r) => Number(field(r, 'netWt', 'nwt') ?? 0), 3)).toBe(40);
    expect(sum(pr1, othOf)).toBe(40);
    expect(sum(pr1, outOf, 3)).toBe(4);
    expect(sum(pr1, panOf, 3)).toBe(4);
    expect(sum(pr2, gwtOf, 3)).toBe(20);
    expect(sum(pr2, outOf, 3)).toBe(2);

    const totals = totalsOf(body);
    expect(totals.outPcs, 'grand Out').toBe(6);
    expect(totals.inPcs).toBe(0);
    expect(totals.pendingPcs).toBe(6);
    expect(totals.grossWt).toBe(62);
    expect(totals.netWt).toBe(59);
    expect(totals.otherAmount).toBe(60);

    const levels = body.groupLevels as any[] | undefined;
    expect(Array.isArray(levels)).toBe(true);
    expect(levels!.length, 'AC_CODE → PR_CODE → VCH_DATE → TAG_NO').toBe(4);
    expect(
      levels!.some((l) => l.subtotal === 'header'),
      'product header sums',
    ).toBe(true);
    expect(
      levels!.some((l) => l.subtotal === 'footer'),
      'party and tag footers',
    ).toBe(true);
  });

  it('approval-report.formula.pending-signed-tags: PanPcs is raw ITM_PCS on APR ISU lines', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=pending');
    // RP_ALL.cs:8349 {{DC_Main.RptName = "AprPan";}}
    const p1 = rowsOf(body).filter((r) => String(field(r, 'acCode') ?? '') === 'P1');
    const p2 = rowsOf(body).filter((r) => String(field(r, 'acCode') ?? '') === 'P2');
    expect(sum(p1, panOf, 3)).toBe(3);
    expect(sum(p2, panOf, 3)).toBe(3);
    expect(sum(p1, othOf)).toBe(30);
    expect(sum(p2, othOf)).toBe(30);
    const totals = totalsOf(body);
    expect(totals.pendingPcs).toBe(6);
    expect(totals.otherAmount).toBe(60);
    expect(rowsOf(body).every((r) => Number(field(r, 'grossWt', 'gwt') ?? 0) > 0)).toBe(true);
  });

  it('approval-report.formula.pending-zero-footer-suppression: Z0 details print but tag footer is suppressed', async () => {
    await reset(['V1', 'V2', 'V8']);
    const body = await report('mode=pending');
    const z0 = rowsOf(body).filter((r) => String(field(r, 'tagNo') ?? '') === 'Z0');
    expect(z0).toHaveLength(2);
    expect(sum(z0, panOf, 3)).toBe(0);
    expect(sum(z0, othOf)).toBe(8);
    const totals = totalsOf(body);
    expect(totals.pendingPcs, 'suppression hides the footer, not the records').toBe(6);
    expect(totals.otherAmount).toBe(68);
    const z0Group = groupsOf(body).find((g) => String(g.key).includes('Z0'));
    expect(z0Group, 'a Z0 tag group exists for the two detail rows').toBeDefined();
    expect(z0Group!.subtotal, 'zero-pending tag footer must not print').toBe('none');
  });

  it('approval-report.formula.precision-preserved: sums keep stored precision, no pre-rounding', async () => {
    await reset(['V1', 'V2']);
    // ITM_GWT is Decimal(14,3); OTH_AMT is Decimal(18,2), so 0.005 is stored as 0.01 by PostgreSQL
    // (the closest representable value). The case's 0.005 sub-value cannot be stored in this column;
    // the assertion checks that the stored 3-place weights and 2-place amounts are not pre-rounded.
    await insertLine(
      TENANT,
      line({
        vch: 'V14',
        sr: 1,
        date: D10,
        ac: 'P1',
        it: 'I1',
        tag: 'Z1',
        pcs: 0,
        gwt: 0,
        nwt: 0,
        itmAmt: 0,
        lbr: 0,
        net: 0,
        oth: 0.01,
      }),
    );
    const body = await report('mode=inout');
    expect(sum(rowsOf(body), gwtOf, 3)).toBe(62);
    expect(sum(rowsOf(body), othOf)).toBe(60.01);
    const issue = await report('mode=issue');
    expect(sum(rowsOf(issue), itmAmtOf), 'ItmAmt is an Issue-column sum, not an InOut column').toBe(
      2800,
    );
    expect(sum(rowsOf(issue), othOf)).toBe(60.01);
  });

  it('approval-report.grouping.issue-voucher-party-bands: party → voucher → SR_NO', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=issue');
    expect(rowsOf(body).map(vchOf)).toEqual(['V1', 'V1', 'V2']);
    const levels = body.groupLevels as any[] | undefined;
    // AprPartyWise prints both footers: the voucher footer Section9 with Sum (..., {@Group}) and the party
    // footer Section10 "Party Total :" with Sum (..., {APR_DETL.AC_CODE}); the report footer is empty.
    expect(levels?.map((l) => l.subtotal)).toEqual(['footer', 'footer']);
    expect(levels?.[0]?.key).toBe('acCode');
    expect(levels?.[0]?.subtotalCaption).toBe('Party Total :');
    expect(levels?.[1]?.key).toContain('vch');
    expect(levels?.[1]?.subtotalCaption, 'the voucher footer has no caption').toBeUndefined();
    expect(body.grandTotal).toBe(false);
  });

  it('approval-report.formula.issue-band-totals: voucher and party footers sum the printed lines', async () => {
    await reset(['V1', 'V2', 'V11']);
    const body = await report('mode=issue');
    const groups = groupsOf(body);
    const party = (ac: string) => groups.find((g) => g.depth === 0 && g.key === ac);
    const voucher = (vch: string) =>
      groups.find((g) => g.depth === 1 && String(g.key).endsWith(vch));
    // P1 holds V1 (two lines) and V11 (one line); P2 holds V2.
    const p1Lines = [...FIXTURES.V1!, ...FIXTURES.V11!];
    const expectBand = (g: any, lines: LineSeed[]) => {
      expect(g, 'band exists').toBeDefined();
      expect(g.subtotal).toBe('footer');
      expect(g.totals.pcs, 'Sum ({APR_DETL.ITM_PCS}, ...)').toBe(sum(lines, (l) => l.pcs, 3));
      expect(g.totals.grossWt).toBe(sum(lines, (l) => l.gwt, 3));
      expect(g.totals.netWt).toBe(sum(lines, (l) => l.nwt, 3));
      expect(g.totals.itemAmount).toBe(sum(lines, (l) => l.itmAmt));
      expect(g.totals.labourAmount).toBe(sum(lines, (l) => l.lbr));
      expect(g.totals.otherAmount).toBe(sum(lines, (l) => l.oth));
      expect(g.totals.netAmount, 'NET_AMT has no summary field').toBeUndefined();
    };
    expectBand(party('P1'), p1Lines);
    expectBand(party('P2'), FIXTURES.V2!);
    expectBand(voucher('V1'), FIXTURES.V1!);
    expectBand(voucher('V11'), FIXTURES.V11!);
    // Detail prints IT_CODE and ITEM_MAST.IT_NAME (AprPartyWise.xml Detail Section8).
    const v1l2 = rowsOf(body).find((r) => vchOf(r) === 'V1' && Number(field(r, 'srNo')) === 2)!;
    expect(field(v1l2, 'itemCode')).toBe('I2');
    expect(field(v1l2, 'itemName')).toBe('Silver Item');
  });

  it('approval-report.formula.pending-band-totals: Pcs and Panding print at every band, Grand Total caption', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=pending');
    const lines = [...FIXTURES.V1!, ...FIXTURES.V2!];
    // AprPan.xml report footer: Text21 "Grand Total :", Sum ({@TagPcs}) and Sum ({@PanPcs}).
    expect(body.grandTotalCaption).toBe('Grand Total :');
    expect(totalsOf(body).pcs).toBe(sum(lines, (l) => l.pcs, 3));
    expect(totalsOf(body).pendingPcs).toBe(sum(lines, (l) => l.pcs, 3));
    const p1 = groupsOf(body).find((g) => g.depth === 0 && g.key === 'P1');
    expect(p1?.totals.pcs).toBe(sum(FIXTURES.V1!, (l) => l.pcs, 3));
    const inout = await report('mode=inout');
    expect(inout.grandTotalCaption).toBe('Grand Total :');
  });

  it('approval-report.grouping.inout-party-product-date-tag: four nesting levels', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=inout');
    const levels = body.groupLevels as any[] | undefined;
    expect(levels?.map((l) => l.key)).toEqual(['acCode', 'prCode', 'vchDate', 'tagNo']);
    const paths = rowsOf(body).map((r) => (r.groupPath ?? []) as string[]);
    expect(paths.every((p) => p.length === 4)).toBe(true);
    expect(rowsOf(body).map(vchOf)).toEqual(['V1', 'V1', 'V2']);
  });

  it('approval-report.grouping.pending-voucher-product-tag: AC_CODE → voucher → PR_CODE → TAG_NO', async () => {
    await reset(['V1', 'V2']);
    const body = await report('mode=pending');
    const levels = body.groupLevels as any[] | undefined;
    expect(levels?.map((l) => l.key)).toEqual(['acCode', 'vchGroup', 'prCode', 'tagNo']);
    expect(rowsOf(body).map(vchOf)).toEqual(['V1', 'V1', 'V2']);
    expect(body.grandTotal).toBe(true);
  });

  it('approval-report.grouping.repeated-blank-tags: two N-tag lines share one footer', async () => {
    await reset(['V9']);
    const inout = await report('mode=inout');
    expect(rowsOf(inout)).toHaveLength(2);
    expect(rowsOf(inout).every((r) => String(field(r, 'tagNo') ?? '') === 'N')).toBe(true);
    expect(sum(rowsOf(inout), outOf, 3)).toBe(3);
    expect(sum(rowsOf(inout), panOf, 3)).toBe(3);
    const tag = groupsOf(inout).find((g) => String(g.key).includes('N'));
    expect(tag?.rowCount).toBe(2);
    expect(tag?.totals?.pendingPcs ?? tag?.totals?.pcs).toBe(3);
    const pending = await report('mode=pending');
    expect(sum(rowsOf(pending), panOf, 3)).toBe(3);
  });

  it('approval-report.grouping.duplicate-master-no-amplification: the unique master key keeps one row per line', async () => {
    await reset(['V1', 'V2']);
    // The case asks for a duplicate CO_CODE+IT_CODE master. ITEM_MAST_pkey forbids it, so the safe join
    // key is already enforced by the schema; record that constraint and prove count-once totals.
    const keys: Array<{ column_name: string }> = await owner.$queryRawUnsafe(
      `SELECT kcu.column_name FROM information_schema.table_constraints tc
       JOIN information_schema.key_column_usage kcu ON kcu.constraint_name=tc.constraint_name
       WHERE tc.table_name='ITEM_MAST' AND tc.constraint_type='PRIMARY KEY'`,
    );
    expect(keys.map((k) => k.column_name).sort()).toEqual(
      ['CO_CODE', 'IT_CODE', 'tenant_id'].sort(),
    );
    for (const mode of ['issue', 'inout', 'pending']) {
      const body = await report(`mode=${mode}`);
      expect(rowsOf(body), `${mode} must count each issue line once`).toHaveLength(3);
      expect(sum(rowsOf(body), outOf, 3)).toBe(6);
    }
  });

  it('approval-report.invalid.reversed-range-empty: valid reversed dates yield an empty selection', async () => {
    const r = await get(
      'printer',
      `/reports/approval-report?fromDate=${D12}&toDate=${D10}&mode=issue`,
    );
    expect(r.statusCode, r.body).toBe(200);
    expect(rowsOf(r.json())).toEqual([]);
    const totals = totalsOf(r.json());
    for (const value of Object.values(totals)) expect(value).toBe(0);
    // D7: no validation message and no crash; the desktop only conjuncts inclusive endpoints
    // (RP_ALL.cs:8152 {{CurFormula = "{APR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {APR_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";}}).
  });

  it('approval-report.invalid.empty-period: no rows and no error in any mode', async () => {
    await reset([]);
    for (const mode of ['issue', 'inout', 'pending']) {
      const body = await report(`mode=${mode}`);
      expect(rowsOf(body), `${mode} empty period`).toEqual([]);
      // RP_ALL.cs:8201 {{Module_Save.ShowReportPreview();}} — preview is unconditional.
    }
  });

  it('approval-report.invalid.malformed-date-safe: impossible date is refused safely', async () => {
    const r = await get(
      'printer',
      '/reports/approval-report?fromDate=2026-02-31&toDate=' + TO + '&mode=issue',
    );
    expect(r.statusCode, r.body).toBe(400);
    expect(rowsOf(r.json())).toEqual([]);
    // RP_ALL.cs:8152 {{CurFormula = "{APR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DETL.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {APR_DETL.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";}}
  });

  it('approval-report.scope.tenant-company-location-sentinels: no cross-scope row appears', async () => {
    const body = await report('mode=issue&lcCode=');
    // RP_ALL.cs:6664 {{((Control)tLcCode).Enabled = false;}} — a cleared box never widens the scope.
    const text = JSON.stringify(body);
    for (const sentinel of ['V3', 'V4', 'V5', 'Z-CO', 'Z-TN'])
      expect(text, `${sentinel} must not appear`).not.toContain(sentinel);
  });

  it('approval-report.scope.year-scope: only the session fiscal year is returned', async () => {
    for (const mode of ['issue', 'inout', 'pending']) {
      expect(vchs(await report(`mode=${mode}`))).not.toContain('V4');
      // D4 keeps the web session-year filter; the desktop formula has no CO_YEAR predicate.
    }
  });

  it('approval-report.formula.all-location-twin-vouchers: same year/book/vch/sr in two locations both print and sum', async () => {
    await reset(['V1', 'V2']);
    // The location-02 twin of V1's first line: same CO_YEAR/CO_BOOK/VCH_NO/SR_NO as the location-01 line.
    // The old voucher key (year+book+number, no location) collapsed the two into one line, so the second
    // location's money vanished from every band (engine.ts runLayout skips a repeated line key).
    const twin = line({ vch: 'V1', sr: 1, date: D10, ac: 'P1', it: 'I1', tag: 'T1B', lc: '02' });
    await insertLine(TENANT, twin);
    // RP_ALL.cs:8154: a 00 session that clears the box appends no location clause, so both locations' rows
    // are selected — and AprPartyWise sums every selected row (AprPartyWise.xml SummaryFields; the desktop
    // never dedupes by number). The displayed grouping is unchanged: @Group stays year+book+number
    // (AprPartyWise.xml:268), so the twin prints inside the same voucher band.
    const body = await headReport('mode=issue&reportLcCode=');
    const rows = rowsOf(body);
    expect(rows).toHaveLength(4);
    const sr1 = rows.filter((r) => vchOf(r) === 'V1' && Number(field(r, 'srNo')) === 1);
    expect(sr1, 'both same-numbered lines print').toHaveLength(2);
    const lines = [...FIXTURES.V1!, twin, ...FIXTURES.V2!];
    const totals = totalsOf(body);
    expect(totals.pcs).toBe(sum(lines, (l) => l.pcs, 0));
    expect(totals.grossWt).toBe(sum(lines, (l) => l.gwt, 3));
    expect(totals.netWt).toBe(sum(lines, (l) => l.nwt, 3));
    expect(totals.itemAmount).toBe(sum(lines, (l) => l.itmAmt));
    expect(totals.otherAmount).toBe(sum(lines, (l) => l.oth));
    // The one shared voucher band sums all three V1 lines (pcs 1+2+1, gross 10.5+20+10, oth 10+20+0.5).
    const v1 = groupsOf(body).find((g) => g.depth === 1 && String(g.key).endsWith('V1'))!;
    expect(v1.rowCount).toBe(3);
    expect(v1.totals.pcs).toBe(4);
    expect(v1.totals.grossWt).toBe(40.5);
    expect(v1.totals.itemAmount).toBe(1400);
    expect(v1.totals.otherAmount).toBe(30.5);
    const p1 = groupsOf(body).find((g) => g.depth === 0 && g.key === 'P1')!;
    expect(p1.totals.pcs).toBe(4);
    expect(p1.totals.itemAmount).toBe(1400);
    // The location is part of the voucher key, so the two same-numbered vouchers count as two.
    expect(body.voucherCount).toBe(3);
    // InOut and Panding are the same selection over APR_DETL: the twin survives there too.
    for (const mode of ['inout', 'pending']) {
      const b = await headReport(`mode=${mode}&reportLcCode=`);
      expect(rowsOf(b), `${mode} prints every line of both locations`).toHaveLength(4);
      expect(totalsOf(b).grossWt).toBe(72);
      expect(totalsOf(b).otherAmount).toBe(60.5);
    }
  });

  it('approval-report.scope.head-office-branch-pick: a 00 session names one company branch', async () => {
    await reset(['V1', 'V2', 'V3']);
    // RP_ALL.cs:6660 leaves the lc box editable at 00 and RP_ALL.cs:8156 applies its value as
    // {APR_DETL.LC_CODE}; the branch travels as reportLcCode, validated against the company's locations.
    const branch = await headReport('mode=issue&reportLcCode=01');
    expect(vchs(branch)).toEqual(['V1', 'V2']);
    expect(vchs(branch)).not.toContain('V3');
    // The cleared box still lists every location (RP_ALL.cs:8154 appends no clause).
    const all = await headReport('mode=issue&reportLcCode=');
    expect(vchs(all)).toContain('V3');
    // The untouched box defaults to the session location 00 (RP_ALL.cs:6669), which holds no rows here.
    expect(rowsOf(await headReport('mode=issue'))).toEqual([]);
    // The export routes carry the same parameter, so a download can never widen the branch the screen chose.
    const csv = await get(
      'headprinter',
      `/reports/approval-report/export.csv?fromDate=${FROM}&toDate=${TO}&mode=issue&reportLcCode=01`,
    );
    expect(csv.statusCode, csv.body).toBe(200);
    const text = String(csv.body);
    expect(text, 'the branch export carries V1').toContain('V1');
    expect(text, 'the branch export drops V3 (lc 02)').not.toContain('V3');
    const xlsx = await get(
      'headprinter',
      `/reports/approval-report/export.xlsx?fromDate=${FROM}&toDate=${TO}&mode=issue&reportLcCode=01`,
    );
    expect(xlsx.statusCode, xlsx.body).toBe(200);
  });

  it('approval-report.scope.report-location-locked: a non-00 session cannot send a report location', async () => {
    await reset(['V1', 'V2', 'V3']);
    // RP_ALL.cs:6664 locks the box outside head office: any report location from another session is a
    // client mistake (the screen never sends one), refused with 400 while the session scope stays itself.
    for (const value of ['01', '02']) {
      const response = await get(
        'printer',
        `/reports/approval-report?fromDate=${FROM}&toDate=${TO}&mode=issue&reportLcCode=${value}`,
      );
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json().error).toBe('location-locked');
    }
    // The export routes refuse it identically through the app-level RP_ALL error mapping.
    const denied = await get(
      'printer',
      `/reports/approval-report/export.csv?fromDate=${FROM}&toDate=${TO}&mode=issue&reportLcCode=02`,
    );
    expect(denied.statusCode, denied.body).toBe(400);
    expect(denied.json().error).toBe('location-locked');
    // A head office naming a location the company does not have is refused as well.
    const bad = await get(
      'headprinter',
      `/reports/approval-report?fromDate=${FROM}&toDate=${TO}&mode=issue&reportLcCode=99`,
    );
    expect(bad.statusCode, bad.body).toBe(400);
    expect(bad.json().error).toBe('invalid-location');
  });

  it('approval-report.scope.view-print-rights: no view right 403, no print right refuses export', async () => {
    expect(
      (await get('blocked', `/reports/approval-report?fromDate=${FROM}&toDate=${TO}`)).statusCode,
    ).toBe(403);
    const denied = await get(
      'viewer',
      `/reports/approval-report/export.csv?fromDate=${FROM}&toDate=${TO}&mode=issue`,
    );
    expect([400, 403, 404], 'a view-only user cannot export').toContain(denied.statusCode);
    const allowed = await get(
      'printer',
      `/reports/approval-report/export.csv?fromDate=${FROM}&toDate=${TO}&mode=issue`,
    );
    expect(allowed.statusCode, allowed.body).toBe(200);
    // RP_ALL.cs:6777 {{UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));}}
  });

  it('approval-report.concurrency.request-local-state: two sessions keep their own mode and rows', async () => {
    await reset(['V1', 'V2']);
    const [a, b] = await Promise.all([
      report('mode=issue&acCode=P1', 'printer'),
      report('mode=pending&acCode=P2', 'viewer'),
    ]);
    expect(vchs(a), 'session A gets issue rows for P1').toEqual(['V1']);
    expect(vchs(b), 'session B gets pending rows for P2').toEqual(['V2']);
    expect(a.mode ?? 'issue').toBe('issue');
    expect(b.mode ?? 'pending').toBe('pending');
  });

  it('approval-report.concurrency.run-during-resolution: a report sees a consistent snapshot', async () => {
    const [read, write] = await Promise.all([
      report('mode=pending', 'printer'),
      exec(
        `UPDATE "APR_DETL" SET "ISU_REC"='Y' WHERE tenant_id=$1 AND "VCH_NO"='V1' AND "SR_NO"=1`,
        TENANT,
      ),
    ]);
    expect(write).toBeGreaterThanOrEqual(0);
    const statuses = rowsOf(read).map((r) => String(field(r, 'status') ?? ''));
    expect(statuses.every((s) => s === '' || s === 'N' || s === 'Y' || s === 'R')).toBe(true);
    const remaining: Array<{ c: bigint }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::bigint AS c FROM "APR_DETL" WHERE tenant_id=$1 AND "VCH_NO"='V1' AND "SR_NO"=1 AND "ISU_REC"='Y'`,
      TENANT,
    );
    expect(Number(remaining[0]!.c)).toBe(1);
  });

  it('approval-report.retry.duplicate-run-idempotent: a repeated run changes nothing durable', async () => {
    const before: Array<{ c: bigint }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::bigint AS c FROM "APR_DETL" WHERE tenant_id=$1`,
      TENANT,
    );
    const a = await report('mode=inout');
    const b = await report('mode=inout');
    expect(b).toEqual(a);
    const after: Array<{ c: bigint }> = await owner.$queryRawUnsafe(
      `SELECT count(*)::bigint AS c FROM "APR_DETL" WHERE tenant_id=$1`,
      TENANT,
    );
    expect(after[0]!.c).toBe(before[0]!.c);
  });

  it('approval-report.history.live-master-names: renamed masters replace snapshot names', async () => {
    await reset(['V1', 'V2']);
    await exec(
      `UPDATE "AC_MAST" SET "AC_NAME"='Renamed Party' WHERE tenant_id=$1 AND "AC_CODE"='P1'`,
      TENANT,
    );
    await exec(
      `UPDATE "BOOK_DATA" SET "BOOK_NAME"='Renamed Book' WHERE tenant_id=$1 AND "CO_BOOK"='018' AND "LC_CODE"='01'`,
      TENANT,
    );
    const body = await report('mode=issue');
    // RP_ALL.cs:8199 selects AprPartyWise, whose bands bind AC_MAST.AC_NAME and BOOK_DATA.BOOK_NAME.
    expect(rowsOf(body).map((r) => String(field(r, 'acName', 'partyName') ?? ''))).toContain(
      'Renamed Party',
    );
    expect(rowsOf(body).map((r) => String(field(r, 'bookName') ?? ''))).toContain('Renamed Book');
    expect(JSON.stringify(body)).not.toContain('Snapshot P1');
  });

  it('approval-report.journey.custody-reconcile: issued = pending + resolved pieces, weights and fine', async () => {
    await reset(['V1', 'V2']);
    // Return resolved V1L1 and the sale consumed V2 (TR_APR_ISU.cs:6414 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}};
    // TR_SALE.cs:16112 {{UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y'}}).
    await exec(
      `UPDATE "APR_DETL" SET "ISU_REC"='Y' WHERE tenant_id=$1 AND (("VCH_NO"='V1' AND "SR_NO"=1) OR "VCH_NO"='V2')`,
      TENANT,
    );
    const issue = await report('mode=issue');
    const inout = await report('mode=inout');
    const pending = await report('mode=pending');
    const resolved = rowsOf(inout).filter((r) => inOf(r) > 0);
    const outstanding = rowsOf(inout).filter((r) => panOf(r) > 0);
    expect(sum(rowsOf(issue), pcsOf, 3)).toBe(6);
    expect(sum(outstanding, panOf, 3), 'pending is V1L2 only').toBe(2);
    expect(sum(resolved, outOf, 3), 'resolved is V1L1 + V2').toBe(4);
    expect(sum(rowsOf(issue), gwtOf, 3)).toBe(62);
    expect(sum(outstanding, gwtOf, 3)).toBe(20);
    expect(sum(resolved, gwtOf, 3)).toBe(42);
    expect(sum(rowsOf(issue), (r) => Number(field(r, 'netWt', 'nwt') ?? 0), 3)).toBe(59);
    expect(sum(outstanding, (r) => Number(field(r, 'netWt', 'nwt') ?? 0), 3)).toBe(19);
    expect(sum(resolved, (r) => Number(field(r, 'netWt', 'nwt') ?? 0), 3)).toBe(40);
    expect(sum(rowsOf(pending), panOf, 3)).toBe(2);
    // D5: fine is test-only writer evidence, not a report column.
    const fine: Array<{ f: any }> = await owner.$queryRawUnsafe(
      `SELECT sum("ITM_FINE") AS f FROM "APR_DETL" WHERE tenant_id=$1 AND "TAG_NO" IN ('T1','T3')`,
      TENANT,
    );
    expect(Number(fine[0]!.f)).toBe(18.32);
  });
});
