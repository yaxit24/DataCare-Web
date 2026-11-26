import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N249 / G261: Tag Print's two residuals, the PRINT_MAST label-file choice and the SubTagPrint sub-report, through the
 * real Fastify routes on a forced-RLS database. Expected values come from the desktop source (see
 * orchestration/work/WP-34/study.md and cases.md):
 *
 * - Load (UT_TAG_PRINT.cs:4924-4954): the files of PRINT_TYPE TAG (QR with QR_CODE_GEN) by PRINT_FILE; the default is
 *   the row marked PRINT_SET_A 'Y', the last one when two are (no break), and empty when none is (:4954).
 * - Print hands the combo text to the report (:5200, :5209). Set (:5636-5655) marks the chosen file Y and the others N
 *   of its type and says "Tag Print Report Default Set" (:5653).
 * - The four Crystal label files differ: BarPrint13 has the `L.` line and no sub-report (BarPrint13.xml:10, :217); the
 *   other three embed SubTagPrint.rpt: OtherDetl uses IT_AMT (BarPrint10.xml:72, GhatTagPrnt.xml:61)
 *   but IT_NET_AMT for QR (QrPrint10.xml:72),
 *   linked by tag + VCH_SRNO (BarPrint10.xml:100-101), by voucher row incl. SR_NO (QrPrint10.xml:119) and by voucher
 *   only (GhatTagPrnt.xml:102).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tag-print-files';
const otherTenant = 'tag-print-files-b';
const PASSWORD = 'Tag-Print-Files!2026';
const SECRET = 'tag-print-files-test-signing-secret-over-thirty';
const ADMIN = 'tfadmin';
const CLERK = 'tfclerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const API = '/stock/tag-print-screen';
const FILES = ['QrPrint10', 'BarPrint10', 'BarPrint13', 'GhatTagPrnt'];

type Cookie = string;

(enabled ? describe : describe.skip)('N249 Tag Print label-file choice and SubTagPrint', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let admin: Cookie;
  let clerk: Cookie;
  let otherAdmin: Cookie;

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
  const wipe = async () => {
    const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const { table_name } of tables)
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table_name}" WHERE tenant_id IN ($1,$2)`,
        tenantId,
        otherTenant,
      );
  };
  const login = async (tenant: string, user: string): Promise<Cookie> => {
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const setCookie = response.headers['set-cookie'];
    return (Array.isArray(setCookie) ? setCookie : [setCookie ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  };
  const files = (rows: Array<[string, string, string]>, tenant = tenantId) =>
    Promise.all(
      rows.map(([type, file, flag]) =>
        exec(
          `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","PRINT_FILE","PRINT_SET_A") VALUES ($1,'01',$2,$3,$4)`,
          tenant,
          type,
          file,
          flag,
        ),
      ),
    );
  const marks = async (tenant = tenantId) =>
    (
      await query<any[]>(
        `SELECT "PRINT_TYPE","PRINT_FILE","PRINT_SET_A" FROM "PRINT_MAST" WHERE tenant_id=$1 ORDER BY "PRINT_TYPE","PRINT_FILE"`,
        tenant,
      )
    ).map((r) => `${r.PRINT_TYPE}/${r.PRINT_FILE}/${r.PRINT_SET_A}`);
  const setting = async (qr: 'Y' | 'N') => {
    const changed = await exec(
      `UPDATE "CO_SET_NEW" SET "QR_CODE_GEN"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
      qr,
    );
    if (!changed)
      await exec(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","QR_CODE_GEN") VALUES ($1,'01',$2)`,
        tenantId,
        qr,
      );
  };
  const staged = () =>
    query<any[]>(
      `SELECT "TAG_NO","VCH_NO","SR_NO" FROM "TAG_PRINT_DATA" WHERE tenant_id=$1 ORDER BY row_id`,
      tenantId,
    );

  /** The cases' voucher 88001 of book TOP: TP0001..TP0003 and two BAR_IDTL rows (tag 1 and tag 2). */
  const seedVoucher = async () => {
    for (const [t, srno, it] of [
      ['TP0001', 1, 'TPG1'],
      ['TP0002', 2, 'TPG1'],
      ['TP0003', 3, 'TPS1'],
    ] as const) {
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","TAG_NO","VCH_SRNO",
           "DESIGN_NO","TBL_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_MRP","LBR_PRC","KR_NAME","HM_ID","STK_DATE","VCH_TIME")
         VALUES ($1,'01','01',$2,'TOP','88001',$3,$4,$5,$3,$6,'T1',1,10.5,10,91.6,55000,8,'KARI1','HJOURNEY','2026-04-02',now())`,
        tenantId,
        YEAR,
        srno,
        it,
        t,
        `DSG-${t}`,
      );
      await exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IT_CODE","TAG_NO","VCH_SRNO","ITM_SIGN","ITM_GWT","ITM_NWT")
         VALUES ($1,'01','01',$2,'TOP','88001',$3,$4,$5,'+',10.5,10)`,
        tenantId,
        YEAR,
        it,
        t,
        srno,
      );
    }
    for (const [srno, tagNo, code, amt, netAmt] of [
      [1, 'TP0001', 'GLD1', 1234.5, 1100.4],
      [2, 'TP0002', 'GLD2', 99.4, 80.6],
    ] as const)
      await exec(
        `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","TAG_NO","VCH_SRNO","IT_CODE","IT_AMT","IT_NET_AMT")
         VALUES ($1,'01','01',$2,'TOP','88001',$3,$4,$3,$5,$6,$7)`,
        tenantId,
        YEAR,
        srno,
        tagNo,
        code,
        amt,
        netAmt,
      );
  };
  const print = (file: string | undefined, extra: Record<string, unknown> = {}, cookie = admin) =>
    request(cookie, 'POST', `${API}/print`, {
      bookCode: 'TOP',
      ...(file === undefined ? {} : { file }),
      tags: [
        { tagNo: 'TP0001', vchSrno: 1 },
        { tagNo: 'TP0002', vchSrno: 2 },
      ],
      ...extra,
    });
  /** Print `file` and return each label's text, in sheet order. */
  const sheet = async (file: string, extra: Record<string, unknown> = {}) => {
    const printed = await print(file, extra);
    expect(printed.statusCode, printed.body).toBe(200);
    const response = await request(admin, 'GET', `${API}/labels?file=${encodeURIComponent(file)}`);
    expect(response.statusCode).toBe(200);
    return {
      html: response.body,
      labels: response.body.split(/<div class="lbl[ "]/).slice(1),
    };
  };
  const labelOf = (labels: string[], tag: string) =>
    labels.find((l) => l.includes(`>*${tag}*<`) || l.includes(`>${tag}<`)) ?? '';

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    for (const tenant of [tenantId, otherTenant]) await seedCompany(runtime, tenant, '01');
    const passwordHash = await hashPassword(PASSWORD);
    for (const tenant of [tenantId, otherTenant])
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES ($1,'01',$2,$4,'ADMIN','Y','Y','Y','N'),($1,'01',$3,$4,'USER','Y','N','N','N')`,
        tenant,
        ADMIN,
        CLERK,
        passwordHash,
      );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES ($1,'01','01',$2,'Other','Tag Print','Y','N','N','N')`,
      tenantId,
      CLERK,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","GR_TYPE") VALUES ($1,'01','E1','GOLD','G'),($1,'01','E2','SILVER','S')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES
       ($1,'01','TPG1','E2E TAG GOLD RING','G','E1'),($1,'01','TPS1','E2E TAG SILVER RING','S','E2')`,
      tenantId,
    );
    await exec(
      `UPDATE "CO_MAST" SET "CO_NAME"='E2E SHOP' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    admin = await login(tenantId, ADMIN);
    clerk = await login(tenantId, CLERK);
    otherAdmin = await login(otherTenant, ADMIN);
  });

  beforeEach(async () => {
    for (const table of ['PRINT_MAST', 'TAG_PRINT_DATA', 'BAR_IDTL', 'MAIN_STOCK', 'BAR_DETL'])
      await exec(`DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`, tenantId, otherTenant);
    await setting('N');
    await seedVoucher();
  });

  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  describe('Load', () => {
    it('with files but none marked the default is empty; with two marked the last in PRINT_FILE order wins', async () => {
      await files(FILES.slice(1).map((f) => ['TAG', f, 'N']));
      let json = (await request(admin, 'GET', API)).json();
      expect(json.files).toEqual(['BarPrint10', 'BarPrint13', 'GhatTagPrnt']);
      expect(json.defaultFile).toBe('');
      await exec(
        `UPDATE "PRINT_MAST" SET "PRINT_SET_A"='Y' WHERE tenant_id=$1 AND "PRINT_FILE" IN ('BarPrint10','BarPrint13')`,
        tenantId,
      );
      json = (await request(admin, 'GET', API)).json();
      expect(json.defaultFile).toBe('BarPrint13');
      await exec(`DELETE FROM "PRINT_MAST" WHERE tenant_id=$1`, tenantId);
      json = (await request(admin, 'GET', API)).json();
      expect(json).toMatchObject({ files: [], defaultFile: '' });
    });

    it('lists the TAG files, or the QR files with QR_CODE_GEN on, each with its own default', async () => {
      await files([
        ['TAG', 'BarPrint10', 'N'],
        ['TAG', 'QrPrint10', 'Y'],
        ['QR', 'QrPrint10', 'N'],
        ['QR', 'QrPrint10-ALT', 'Y'],
      ]);
      let json = (await request(admin, 'GET', API)).json();
      expect(json).toMatchObject({ files: ['BarPrint10', 'QrPrint10'], defaultFile: 'QrPrint10' });
      await setting('Y');
      json = (await request(admin, 'GET', API)).json();
      expect(json).toMatchObject({
        qr: true,
        files: ['QrPrint10', 'QrPrint10-ALT'],
        defaultFile: 'QrPrint10-ALT',
      });
      expect(await marks()).toEqual([
        'QR/QrPrint10/N',
        'QR/QrPrint10-ALT/Y',
        'TAG/BarPrint10/N',
        'TAG/QrPrint10/Y',
      ]);
    });
  });

  describe('Set', () => {
    it('marks exactly one file Y, says the desktop text, leaves the staging and other tenants alone', async () => {
      await files([
        ['TAG', 'BarPrint10', 'Y'],
        ['TAG', 'BarPrint13', 'N'],
        ['TAG', 'GhatTagPrnt', 'N'],
      ]);
      await files([['TAG', 'BarPrint10', 'Y']], otherTenant);
      expect((await print('BarPrint10')).statusCode).toBe(200);
      const before = await staged();
      const response = await request(admin, 'POST', `${API}/default-file`, { file: 'BarPrint13' });
      expect(response.statusCode, response.body).toBe(200);
      expect(response.json()).toEqual({
        defaultFile: 'BarPrint13',
        message: 'Tag Print Report Default Set',
      });
      expect(await marks()).toEqual(['TAG/BarPrint10/N', 'TAG/BarPrint13/Y', 'TAG/GhatTagPrnt/N']);
      expect(await marks(otherTenant)).toEqual(['TAG/BarPrint10/Y']);
      expect(await staged()).toEqual(before);
      expect((await request(admin, 'GET', API)).json().defaultFile).toBe('BarPrint13');
    });

    it('QR mode sets the QR rows only', async () => {
      await files([
        ['TAG', 'BarPrint10', 'Y'],
        ['QR', 'QrPrint10', 'Y'],
        ['QR', 'QrPrint10-ALT', 'N'],
      ]);
      await setting('Y');
      const response = await request(admin, 'POST', `${API}/default-file`, {
        file: 'QrPrint10-ALT',
      });
      expect(response.statusCode, response.body).toBe(200);
      expect(await marks()).toEqual(['QR/QrPrint10/N', 'QR/QrPrint10-ALT/Y', 'TAG/BarPrint10/Y']);
    });

    it('refuses an empty or unknown name and clears nothing, and a file of another tenant is unknown', async () => {
      await files([['TAG', 'BarPrint10', 'Y']]);
      await files([['TAG', 'BarPrint13', 'N']], otherTenant);
      let response = await request(admin, 'POST', `${API}/default-file`, { file: '' });
      expect(response.statusCode).toBe(400);
      response = await request(admin, 'POST', `${API}/default-file`, { file: 'NoSuchFile' });
      expect(response.statusCode).toBe(400);
      expect(response.body).toContain('Unknown print file: NoSuchFile');
      response = await request(admin, 'POST', `${API}/default-file`, { file: 'BarPrint13' });
      expect(response.statusCode).toBe(400);
      expect(response.body).toContain('Unknown print file: BarPrint13');
      expect(await marks()).toEqual(['TAG/BarPrint10/Y']);
      expect(await marks(otherTenant)).toEqual(['TAG/BarPrint13/N']);
      // The other tenant's setup lists none of this tenant's files.
      expect((await request(otherAdmin, 'GET', API)).json().files).toEqual(['BarPrint13']);
    });

    it('needs the update right', async () => {
      await files([
        ['TAG', 'BarPrint10', 'Y'],
        ['TAG', 'BarPrint13', 'N'],
      ]);
      const response = await request(clerk, 'POST', `${API}/default-file`, { file: 'BarPrint13' });
      expect(response.statusCode).toBe(403);
      expect(await marks()).toEqual(['TAG/BarPrint10/Y', 'TAG/BarPrint13/N']);
    });

    it('two sessions setting different files leave exactly one default', async () => {
      await files([
        ['TAG', 'BarPrint10', 'Y'],
        ['TAG', 'BarPrint13', 'N'],
        ['TAG', 'GhatTagPrnt', 'N'],
      ]);
      const [a, b] = await Promise.all([
        request(admin, 'POST', `${API}/default-file`, { file: 'BarPrint13' }),
        request(admin, 'POST', `${API}/default-file`, { file: 'GhatTagPrnt' }),
      ]);
      expect([a.statusCode, b.statusCode]).toEqual([200, 200]);
      const yes = (await marks()).filter((m) => m.endsWith('/Y'));
      expect(yes).toHaveLength(1);
      expect(['TAG/BarPrint13/Y', 'TAG/GhatTagPrnt/Y']).toContain(yes[0]);
    });

    it('is atomic: a fault while the new default is written leaves the old one', async () => {
      await files([
        ['TAG', 'BarPrint10', 'Y'],
        ['TAG', 'BarPrint13', 'N'],
      ]);
      await exec(`CREATE OR REPLACE FUNCTION tp_files_fault() RETURNS trigger AS $$
        BEGIN
          IF NEW."PRINT_SET_A"='Y' AND OLD."PRINT_SET_A" IS DISTINCT FROM 'Y' THEN
            RAISE EXCEPTION 'tag print set fault';
          END IF;
          RETURN NEW;
        END $$ LANGUAGE plpgsql`);
      await exec(
        `CREATE TRIGGER tp_files_fault BEFORE UPDATE ON "PRINT_MAST" FOR EACH ROW EXECUTE FUNCTION tp_files_fault()`,
      );
      try {
        const response = await request(admin, 'POST', `${API}/default-file`, {
          file: 'BarPrint13',
        });
        expect(response.statusCode).toBeGreaterThanOrEqual(400);
        expect(await marks()).toEqual(['TAG/BarPrint10/Y', 'TAG/BarPrint13/N']);
      } finally {
        await exec(`DROP TRIGGER IF EXISTS tp_files_fault ON "PRINT_MAST"`);
        await exec(`DROP FUNCTION IF EXISTS tp_files_fault()`);
      }
    });
  });

  describe('Print', () => {
    it('refuses a file PRINT_MAST lacks before it clears anything, and writes only the staging', async () => {
      await files([['TAG', 'BarPrint10', 'Y']]);
      expect((await print('BarPrint10')).statusCode).toBe(200);
      const staging = await staged();
      const master = await marks();
      await exec(`DELETE FROM "PRINT_MAST" WHERE tenant_id=$1`, tenantId);
      const response = await print('BarPrint10');
      expect(response.statusCode).toBe(400);
      expect(response.body).toContain('Unknown print file: BarPrint10');
      expect(await staged()).toEqual(staging);
      await files([['TAG', 'BarPrint10', 'Y']]);
      expect(await marks()).toEqual(master);
      const images = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "IMAGE_DATA" WHERE tenant_id=$1`,
        tenantId,
      );
      expect(images[0]!.n).toBe(0);
    });

    it('refuses an empty Print file Name (UT_TAG_PRINT.cs:5209 names no report file) and clears nothing', async () => {
      await files([['TAG', 'BarPrint10', 'Y']]);
      expect((await print('BarPrint10')).statusCode).toBe(200);
      const staging = await staged();
      const response = await print('');
      expect(response.statusCode).toBe(400);
      expect(response.body).toContain('Unknown print file: ');
      expect(await staged()).toEqual(staging);
    });

    it('answers the chosen file, and a replay stages the same rows (no doubled labels)', async () => {
      await files([['TAG', 'BarPrint13', 'Y']]);
      const first = await print('BarPrint13');
      expect(first.json()).toEqual({ skipped: 0, staged: 2, file: 'BarPrint13' });
      const rows = await staged();
      const replay = await print('BarPrint13');
      expect(replay.statusCode).toBe(200);
      expect(await staged()).toEqual(rows);
      const { labels } = await sheet('BarPrint13');
      expect(labels).toHaveLength(2);
    });

    it('a request that sends no file at all stages, and the sheet without a file is the BarPrint10 layout', async () => {
      const printed = await print(undefined);
      expect(printed.statusCode, printed.body).toBe(200);
      const response = await request(admin, 'GET', `${API}/labels?file=`);
      expect(response.statusCode).toBe(200);
      const labels = response.body.split(/<div class="lbl[ "]/).slice(1);
      expect(labels).toHaveLength(2);
      expect(labelOf(labels, 'TP0001')).toContain('GLD1 / 1235');
    });
  });

  describe('Label sheet per file', () => {
    beforeEach(() => files(FILES.map((f) => ['TAG', f, f === 'BarPrint10' ? 'Y' : 'N'])));

    it('every file shows the karigar, shop, purity group, item, tag and the desktop weight lines, and no HUID line', async () => {
      for (const file of FILES) {
        const { html, labels } = await sheet(file);
        expect(labels, file).toHaveLength(2);
        for (const text of [
          'G.10.500',
          'N.10.000',
          'MRP: 55000',
          'KARI1',
          'E2E SHOP',
          '>E1<',
          'TPG1',
          'TP0001',
        ])
          expect(labelOf(labels, 'TP0001') || labels[0], `${file} ${text}`).toContain(text);
        expect(html, file).not.toContain('HUID');
        expect(html, file).not.toContain('HJOURNEY');
      }
    });

    it('BarPrint13: the L. line, *tag* text, no sub-report; BarPrint10: sub-report, no L. line', async () => {
      let { labels } = await sheet('BarPrint13');
      expect(labelOf(labels, 'TP0001')).toContain('L.0.500');
      expect(labelOf(labels, 'TP0001')).toContain('*TP0001*');
      expect(labels.join('')).not.toMatch(/GLD\d| \/ /);
      ({ labels } = await sheet('BarPrint10'));
      expect(labelOf(labels, 'TP0001')).toContain('*TP0001*');
      expect(labelOf(labels, 'TP0001')).not.toContain('L.0.500');
      expect(labelOf(labels, 'TP0001')).toContain('GLD1 / 1235');
    });

    it('QrPrint10 prints a QR picture of the tag number instead of the *tag* text and writes no IMAGE_DATA', async () => {
      await files([['QR', 'QrPrint10', 'Y']]);
      await setting('Y');
      const { labels } = await sheet('QrPrint10', { labelSkip: 2 });
      expect(labels).toHaveLength(4);
      const real = labels.filter((l) => l.includes('data-qr='));
      expect(real).toHaveLength(2);
      expect(real[0]).toContain('data-qr="TP0001"');
      expect(real[0]).toContain('<svg');
      expect(real[0]).not.toContain('*TP0001*');
      expect(labels.filter((l) => l.includes('blank'))).toHaveLength(2);
      const images = await query<Array<{ n: number }>>(`SELECT count(*)::int n FROM "IMAGE_DATA"`);
      expect(images[0]!.n).toBe(0);
    });

    it('the sub-report link and amount differ per file: QR uses net, barcode and ghat use IT_AMT', async () => {
      const lines = (label: string) => label.match(/GLD\d \/ \d+/g) ?? [];
      let { labels } = await sheet('BarPrint10');
      expect(lines(labelOf(labels, 'TP0001'))).toEqual(['GLD1 / 1235']);
      expect(lines(labelOf(labels, 'TP0002'))).toEqual(['GLD2 / 99']);
      ({ labels } = await sheet('QrPrint10'));
      expect(lines(labels[0]!)).toEqual(['GLD1 / 1100']);
      expect(lines(labels[1]!)).toEqual(['GLD2 / 81']);
      ({ labels } = await sheet('GhatTagPrnt'));
      for (const label of labels) expect(lines(label)).toEqual(['GLD1 / 1235', 'GLD2 / 99']);
    });

    it('the Lable Skip blanks print no sub-report line, the real labels all of them (GhatTagPrnt)', async () => {
      const { labels } = await sheet('GhatTagPrnt', { labelSkip: 2 });
      expect(labels).toHaveLength(4);
      for (const blank of labels.slice(0, 2)) expect(blank).not.toContain('GLD');
      for (const label of labels.slice(2)) {
        expect(label).toContain('GLD1 / 1235');
        expect(label).toContain('GLD2 / 99');
      }
    });

    it("another tenant's BAR_IDTL never prints, and the sheet is a print-time snapshot of the chosen file", async () => {
      await exec(
        `INSERT INTO "BAR_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","TAG_NO","VCH_SRNO","IT_CODE","IT_AMT")
         VALUES ($1,'01','01',$2,'TOP','88001',1,'TP0001',1,'LEAK',5)`,
        otherTenant,
        YEAR,
      );
      const { html } = await sheet('BarPrint10');
      expect(html).not.toContain('LEAK');
      await request(admin, 'POST', `${API}/default-file`, { file: 'BarPrint13' });
      const again = await request(admin, 'GET', `${API}/labels?file=BarPrint10`);
      expect(again.body).toContain('GLD1 / 1235');
      expect(again.body).not.toContain('L.0.500');
    });

    it("another tenant's labels show only its own staged rows", async () => {
      await print('BarPrint10');
      const other = await request(otherAdmin, 'GET', `${API}/labels?file=BarPrint10`);
      expect(other.statusCode).toBe(200);
      expect(other.body).not.toContain('TP0001');
    });
  });
});
