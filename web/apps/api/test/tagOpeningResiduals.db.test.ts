import { randomUUID } from 'node:crypto';
import { PrismaClient, withTenant } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { withLotKarigarFill } from '../src/modules/stock/tagOpeningLifecycle.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { snapshotTenant, diffTenant, tenantTables } from './support/tenantSnapshot.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'wp32-tag-residuals';
const OTHER = 'wp32-tag-residuals-other';
const PASSWORD = 'WP32-synthetic-test-only!';
const SECRET = 'wp32-test-signing-key-at-least-thirty-two-characters';
const now = new Date();
const startYear = now.getMonth() >= 3 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-01`;
const BASE = '/stock/tag-opening';
const TABLES = [
  'BAR_DATA',
  'BAR_DETL',
  'BAR_IDTL',
  'MAIN_STOCK',
  'SRNO_MAST',
  'TEMP_BOOK_DATA',
  'LOT_DETL',
  'TAG_IMAGE_DATA',
  'IMAGE_DATA',
  'DM_DATA',
  'DELETE_DATA',
  'api_command_receipt',
] as const;
const books = [
  { book: '732', family: 'OPSTK' },
  { book: '733', family: 'TAG GEN' },
];
const line = (tagNo: string, tblCode = '001') => ({
  tagNo,
  tblCode,
  itCode: 'GOLD',
  pcs: 1,
  grossWt: 10.5,
  netWt: 10,
  touch: 90,
  westPct: 2,
  rate: 6000,
  hallmarkId2: 'H32A',
  hallmarkId2Wt: 1,
});
const payload = (
  book: string,
  tags: Array<Record<string, unknown>> = [line('W32A'), line('W32B')],
) => ({
  coBook: book,
  vchDate: DAY,
  stockItCode: 'LOOSE',
  lines: tags,
});
// tag-opening.create.lot-karigar-footprint: MISSING: lot-header/source-A route payload contract.
// tag-opening.keyboard.auto-save-footprint: blocked in cases.md; recovery contract is missing.
// tag-opening.rights.scope-sentinels: tenant variant below; company/location/year/Set remain unverified.

describe.runIf(RUN)('WP-32 tag opening residual HTTP contracts', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies = new Map<string, string>();
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T[]>;
  const snapshot = (tenant = TENANT, tables: readonly string[] = TABLES) =>
    snapshotTenant(owner, tenant, tables);
  const unchanged = async (
    before: Awaited<ReturnType<typeof snapshot>>,
    tenant = TENANT,
    tables: readonly string[] = TABLES,
  ) => {
    expect(diffTenant(before, await snapshot(tenant, tables))).toEqual({ added: {}, removed: {} });
  };
  const request = (
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    body?: unknown,
    tenant = TENANT,
    user = 'operator',
    key?: string,
  ) =>
    app.inject({
      method,
      url,
      headers: {
        cookie: cookies.get(`${tenant}/${user}`) ?? '',
        ...(key ? { 'idempotency-key': key } : {}),
      },
      ...(body === undefined ? {} : { payload: body as any }),
    });
  const url = (book: string, no: string, suffix = '') => `${BASE}/${no}${suffix}?coBook=${book}`;
  const create = async (book: string, tags = [line('W32A'), line('W32B')], tenant = TENANT) => {
    const response = await request('POST', BASE, payload(book, tags), tenant);
    expect(response.statusCode, response.body).toBe(201);
    return String(response.json().vchNo).padStart(5, '0');
  };
  const reopen = async (book: string, no: string) => {
    const response = await request('GET', url(book, no));
    expect(response.statusCode, response.body).toBe(200);
    return response.json();
  };
  const wipe = async () => {
    for (const table of await tenantTables(owner))
      await exec(`DELETE FROM "${table}" WHERE tenant_id = ANY($1::text[])`, [TENANT, OTHER]);
  };
  const setCookies = (tenant: string, user: string, value: string | string[] | undefined) => {
    const old = new Map(
      (cookies.get(`${tenant}/${user}`) ?? '')
        .split('; ')
        .filter(Boolean)
        .map((part) => [part.split('=')[0]!, part]),
    );
    for (const part of Array.isArray(value) ? value : [value ?? ''])
      if (part) old.set(part.split('=')[0]!, part.split(';')[0]!);
    cookies.set(`${tenant}/${user}`, [...old.values()].join('; '));
  };
  const seed = async (tenant: string) => {
    await seedCompany(runtime, tenant, '01');
    // seedCompany now supplies the installer CO_SET_NEW row.
    // Same item and book fixture structure as tagOpeningRoundTrip/tagOpeningStock.
    await exec(
      `UPDATE "CO_SET" SET "LBR_TYPE"='N',"LBR_ROF"=2,"TAX_ROF"=2,"ITM_RATE_ROF"=2
      WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenant,
    );
    for (const { book, family } of books)
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
       "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01',$2::text,$3::text,$2::text,$3::text,'I','Y','BAR_DATA')`,
        tenant,
        book,
        family,
      );
    for (const code of ['GOLD', 'LOOSE'])
      await exec(
        `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES ($1,'01',$2,$2,'G')`,
        tenant,
        code,
      );
    await exec(
      `INSERT INTO "PRINT_MAST"(tenant_id,"CO_CODE","PRINT_TYPE","PRINT_FILE","PRINT_SET_A") VALUES ($1,'01','TAG','A32','Y')`,
      tenant,
    );
    for (const user of ['operator', 'denied', 'noprint']) {
      await exec(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG",
        "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
        tenant,
        user,
        await hashPassword(PASSWORD),
      );
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU",
        "FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01',$2,'Inventory','Tag Opening',$3,'Y','Y',$4)`,
        tenant,
        user,
        user === 'denied' ? 'N' : 'Y',
        user === 'noprint' ? 'N' : 'Y',
      );
      const login = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenant },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: user, password: PASSWORD },
      });
      expect(login.statusCode, login.body).toBe(200);
      setCookies(tenant, user, login.headers['set-cookie']);
      const selected = await request(
        'POST',
        '/context/select',
        {
          coCode: '01',
          lcCode: '01',
          coYear: YEAR,
          expectedContextEpoch: login.json().context.contextEpoch,
          selectionId: randomUUID(),
        },
        tenant,
        user,
      );
      expect(selected.statusCode, selected.body).toBe(200);
      setCookies(tenant, user, selected.headers['set-cookie']);
    }
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    if (app) await app.close();
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    await wipe();
    cookies.clear();
    await seed(TENANT);
    await seed(OTHER);
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });
  const counter = async (value: 'Y' | 'N') => {
    // The desktop loads MsCntrStk from CO_SET_NEW.COUNTER_STK, not CO_SET.CNTR_STK:
    // MS_OPNCOMP.cs:949 {{SELECT * From CO_SET_NEW WHERE CO_CODE = '}} and
    // MS_OPNCOMP.cs:952 {{DC_Main.MsCntrStk = Conversions.ToString(...Rows[0]["COUNTER_STK"]...)}};
    // a blank column becomes 'N' (MS_OPNCOMP.cs:1024-1026). The desktop source wins over the packet's
    // CO_SET.CNTR_STK wording (AGENTS.md: "the desktop source wins over every document").
    await exec(
      `UPDATE "CO_SET_NEW" SET "COUNTER_STK"=$2 WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      TENANT,
      value,
    );
  };
  for (const { book, family } of books)
    describe(family, () => {
      for (const enabled of ['N', 'Y'] as const)
        for (const method of ['POST', 'PUT'] as const)
          it(`tag-opening.settings.pending / counter-required ${method} CNTR_STK=${enabled}`, async () => {
            const no = method === 'PUT' ? await create(book) : '';
            const opened = no ? await reopen(book, no) : undefined;
            await counter(enabled);
            const before = await snapshot();
            const body = {
              ...payload(book, [line('W32A'), line('W32B', '')]),
              ...(opened ? { expectedVersion: opened.version } : {}),
            };
            const result = await request(method, no ? url(book, no) : BASE, body);
            // TR_TAG_OPBL.cs:10793 {{if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)}}
            // TR_TAG_OPBL.cs:10801 {{Please Insert Counter Code and Try Because It is Mandatory...}}
            expect
              .soft(result.statusCode, result.body)
              .toBe(enabled === 'Y' ? 400 : method === 'POST' ? 201 : 200);
            if (enabled === 'Y') {
              expect
                .soft(result.json().message)
                .toBe('Please Insert Counter Code and Try Because It is Mandatory...');
              await unchanged(before);
            } else {
              const saved = await reopen(book, no || String(result.json().vchNo).padStart(5, '0'));
              expect(saved.lines[1].tblCode).toBe('');
            }
          });
      it('tag-opening.create.lot-karigar-footprint fills touch, wastage and fine from the lot header', async () => {
        // The lot header vector frozen in cases.md: lot L32, touch 92, wastage 1.50, source A, gross
        // 10.500, KrOthWt 0.500, KrGht 0 and a deliberately blank KrTouch.
        // TR_TAG_OPBL.cs:10990 {{if ((mSG[21] == 0) & (Operators.CompareString(tLotNo.Text, "", false) != 0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}
        // TR_TAG_OPBL.cs:10994 {{dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");}}
        // TR_TAG_OPBL.cs:10995 {{dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");}}
        // TR_TAG_OPBL.cs:10996 {{if ((Conversion.Val(mSG[DC_Main.i, 18]) != 0.0) & (Conversion.Val(nLotTouch.Text) != 0.0))}}
        // → KrNwt = 10.500 − 0.500 = 10.000 and KrFine = (10 + 0) × (92 + 1.5) / 100 = 9.35.
        const body = {
          ...payload(book, [{ ...line('W32A'), netWt: 10, karigarOthWt: 0.5, karigarGhtWt: 0 }]),
          lotNo: 'L32',
          lotTouch: 92,
          lotWestPrc: 1.5,
        };
        const saved = await request('POST', BASE, body);
        expect(saved.statusCode, saved.body).toBe(201);
        const no = String(saved.json().vchNo).padStart(5, '0');
        const [bar] = await query<any>(
          `SELECT coalesce("KR_NET_WT",0)::float net, coalesce("KR_TOUCH",0)::float touch,
                  coalesce("KR_WEST_PRC",0)::float west, coalesce("KR_FINE",0)::float fine
             FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          TENANT,
          book,
          no,
        );
        const [kr] = await query<any>(
          `SELECT coalesce("KR_NWT",0)::float net, coalesce("KR_TOUCH",0)::float touch,
                  coalesce("KR_WEST",0)::float west, coalesce("KR_FINE",0)::float fine
             FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "TAG_NO"<>'N'`,
          TENANT,
          book,
          no,
        );
        expect(bar).toEqual({ net: 10, touch: 92, west: 1.5, fine: 9.35 });
        expect(kr).toEqual({ net: 10, touch: 92, west: 1.5, fine: 9.35 });
        // Exactly one header, one tag, one child (the writer's BAR_IDTL row) and one identity.
        const [counts] = await query<any>(
          `SELECT (SELECT count(*) FROM "BAR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3)::int headers,
                  (SELECT count(*) FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3)::int tags,
                  (SELECT count(*) FROM "BAR_IDTL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3)::int children,
                  (SELECT count(*) FROM "SRNO_MAST" WHERE tenant_id=$1)::int counters`,
          TENANT,
          book,
          no,
        );
        expect(counts).toEqual({ headers: 1, tags: 1, children: 1, counters: 1 });
        // A reopen hands the lot-derived values back, so an unchanged save keeps them (T08's vector).
        const opened = await reopen(book, no);
        expect([
          opened.lines[0].karigarTouch,
          opened.lines[0].karigarWestPct,
          opened.lines[0].karigarFine,
        ]).toEqual([92, 1.5, 9.35]);
      });
      it('lot fill formats touch and wastage half away from zero and fine "0.00" from raw values', async () => {
        // TR_TAG_OPBL.cs:10994-10996: Strings.Format(Val(..),"0.00") for touch and wastage, and
        // KR_FINE = Format((KrNwt + KrGht) * (lotTouch + lotWest) / 100, "0.00") from the raw values.
        const vectors = [
          { net: 10, touch: 91.125, west: 0.125, kTouch: 91.13, kWest: 0.13, fine: 9.13 },
          { net: 10.333, touch: 91.37, west: 0.5, kTouch: 91.37, kWest: 0.5, fine: 9.49 },
        ];
        for (const v of vectors) {
          const saved = await request(
            'POST',
            BASE,
            {
              ...payload(book, [{ ...line('W32A'), karigarNetWt: v.net }]),
              lotNo: 'L32',
              lotTouch: v.touch,
              lotWestPrc: v.west,
            },
            TENANT,
            'operator',
          );
          expect(saved.statusCode, saved.body).toBe(201);
          const no = String(saved.json().vchNo).padStart(5, '0');
          const sql = (t: string, a: string, b: string, c: string) =>
            `SELECT "${a}"::float touch, "${b}"::float west, "${c}"::float fine FROM "${t}"
              WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "TAG_NO"<>'N'`;
          const [bar] = await query<any>(
            sql('BAR_DETL', 'KR_TOUCH', 'KR_WEST_PRC', 'KR_FINE'),
            TENANT,
            book,
            no,
          );
          const [stock] = await query<any>(
            sql('MAIN_STOCK', 'KR_TOUCH', 'KR_WEST', 'KR_FINE'),
            TENANT,
            book,
            no,
          );
          const want = { touch: v.kTouch, west: v.kWest, fine: v.fine };
          expect(bar).toEqual(want);
          expect(stock).toEqual(want);
        }
      });
      it('lot fill leaves KR_FINE unwritten when the KrNwt cell is zero', () => {
        const [row] = withLotKarigarFill({
          scope: {} as any,
          lotNo: 'L32',
          lotTouch: 92,
          lotWestPrc: 1.5,
          lines: [{ ...line('W32A'), netWt: 0, grossWt: 0, karigarGhtWt: 2 }],
        } as any);
        expect(row).toMatchObject({ karigarTouch: 92, karigarWestPct: 1.5, lotFine: 0 });
      });
      it('delete removes the tag image row of the voucher serial and keeps a decoy with serial 0', async () => {
        const no = await create(book, [line('W32A')]);
        const [tag] = await query<any>(
          `SELECT "TAG_NO", "VCH_SRNO"::float srno FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
          TENANT,
          book,
          no,
        );
        expect(tag.srno).not.toBe(0);
        for (const srno of [tag.srno, 0])
          await exec(
            `INSERT INTO "TAG_IMAGE_DATA"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IMAGE_TYPE")
             VALUES ($1,'01','01',$2,$3,'J')`,
            TENANT,
            tag.TAG_NO,
            srno,
          );
        const opened = await reopen(book, no);
        const removed = await request(
          'DELETE',
          url(book, no) + `&expectedVersion=${opened.version}`,
        );
        expect(removed.statusCode, removed.body).toBe(200);
        expect(
          await query(
            `SELECT "VCH_SRNO"::float srno FROM "TAG_IMAGE_DATA" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
            TENANT,
            tag.TAG_NO,
          ),
        ).toEqual([{ srno: 0 }]);
      });
      it('print waits while another job holds the tag print staging lock', async () => {
        const no = await create(book, [line('W32A')]);
        let release!: () => void;
        const held = new Promise<void>((r) => (release = r));
        let locked!: () => void;
        const isLocked = new Promise<void>((r) => (locked = r));
        const holder = owner.$transaction(
          async (tx: any) => {
            await tx.$executeRawUnsafe(
              'SELECT pg_advisory_xact_lock(hashtext($1))',
              `tag-print-data:${TENANT}`,
            );
            locked();
            await held;
          },
          { timeout: 10_000 },
        );
        await isLocked;
        let settled = false;
        const printed = request('POST', url(book, no, '/print'), { labelFile: 'A32' }).finally(
          () => (settled = true),
        );
        await new Promise((r) => setTimeout(r, 600));
        expect(settled).toBe(false);
        release();
        await holder;
        const result = await printed;
        expect(result.statusCode, result.body).toBe(200);
      });
      it('D-32-2 create denial uses the required message and changes nothing', async () => {
        const before = await snapshot();
        const result = await request('POST', BASE, payload(book), TENANT, 'denied');
        expect.soft(result.statusCode, result.body).toBe(403);
        // D-32-2 adopts this edit-message text for the hosted create guard.
        // TR_TAG_OPBL.cs:10787 {{You Have No Rights.....}}
        expect.soft(result.json().message).toBe('You Have No Rights.....');
        await unchanged(before);
      });
      it('tag-opening.rights.print-denied / D-32-2 print denial has no staging effects', async () => {
        const no = await create(book);
        const tables = [...TABLES, 'TAG_PRINT_DATA'];
        const before = await snapshot(TENANT, tables);
        const result = await request(
          'POST',
          url(book, no, '/print'),
          { labelSkip: 2.5, labelFile: 'A32' },
          TENANT,
          'noprint',
        );
        expect.soft(result.statusCode, result.body).toBe(403);
        // TR_TAG_OPBL.cs:11479 {{You Have No Print Rights.....}}
        expect.soft(result.json().message).toBe('You Have No Print Rights.....');
        await unchanged(before, TENANT, tables);
      });
      for (const method of ['PUT', 'DELETE'] as const)
        it(`D-32-3 ${method} requires expectedVersion`, async () => {
          const no = await create(book);
          const before = await snapshot();
          const result = await request(
            method,
            url(book, no),
            method === 'PUT' ? payload(book) : undefined,
          );
          expect.soft(result.statusCode, result.body).toBe(400);
          await unchanged(before);
        });
      it('tag-opening.concurrency.pending / D-32-3 rejects stale PUT and DELETE, accepts current tokens', async () => {
        const no = await create(book);
        const a = await reopen(book, no);
        const b = await reopen(book, no);
        expect(a.version).toMatch(/^[0-9a-f]{64}$/);
        expect(b.version).toBe(a.version);
        const first = await request('PUT', url(book, no), {
          ...payload(book, [{ ...line('W32A'), touch: 93 }, line('W32B')]),
          expectedVersion: a.version,
        });
        expect(first.statusCode, first.body).toBe(200);
        const fresh = await reopen(book, no);
        expect(fresh.version).toMatch(/^[0-9a-f]{64}$/);
        expect(fresh.version).not.toBe(a.version);
        expect(fresh.lines[0].touch).toBe(93);
        const before = await snapshot();
        for (const method of ['PUT', 'DELETE'] as const) {
          const result = await request(
            method,
            url(book, no) + (method === 'DELETE' ? `&expectedVersion=${b.version}` : ''),
            method === 'PUT' ? { ...payload(book), expectedVersion: b.version } : undefined,
          );
          expect.soft(result.statusCode, result.body).toBe(409);
          expect.soft(result.json().error).toBe('voucher-version-conflict');
          await unchanged(before);
        }
        const second = await request('PUT', url(book, no), {
          ...payload(book),
          expectedVersion: fresh.version,
        });
        expect(second.statusCode, second.body).toBe(200);
        const latest = await reopen(book, no);
        expect(latest.version).not.toBe(fresh.version);
        const removed = await request(
          'DELETE',
          url(book, no) + `&expectedVersion=${latest.version}`,
        );
        expect(removed.statusCode, removed.body).toBe(200);
        for (const table of ['BAR_DATA', 'BAR_DETL', 'BAR_IDTL', 'MAIN_STOCK'])
          expect(
            await query(`SELECT * FROM "${table}" WHERE tenant_id=$1`, TENANT),
            table,
          ).toHaveLength(0);
        // The tag serial counter survives the delete on both systems: the desktop's per-tag
        // SRNO_MAST delete (TR_TAG_OPBL.cs:11421) targets TAG_NO/VCH_SRNO rows and never the counter,
        // and the web keeps exactly one counter row per company/location (numbering.ts:177-213,
        // seeded by seedCompany with TAG_NO null), so only that row remains.
        expect(
          await query(`SELECT "TAG_NO", "VCH_SRNO" FROM "SRNO_MAST" WHERE tenant_id=$1`, TENANT),
        ).toEqual([{ TAG_NO: null, VCH_SRNO: '0' }]);
      });
      for (const changed of [false, true])
        it(`tag-opening.retry.${changed ? 'changed-body' : 'pending'}`, async () => {
          const key = randomUUID();
          const body = payload(book, [line('W32A')]);
          const first = await request('POST', BASE, body, TENANT, 'operator', key);
          expect(first.statusCode, first.body).toBe(201);
          const before = await snapshot();
          for (let attempt = 0; attempt < 2; attempt++) {
            const replay = await request(
              'POST',
              BASE,
              changed ? { ...body, lines: [{ ...line('W32A'), grossWt: 11.5 }] } : body,
              TENANT,
              'operator',
              key,
            );
            expect.soft(replay.statusCode, replay.body).toBe(changed ? 409 : 201);
            if (changed) expect.soft(replay.json().error).toBe('idempotency-key-reused');
            else expect.soft(replay.json()).toEqual(first.json());
            await unchanged(before);
          }
          expect(
            await query(
              `SELECT response_status FROM api_command_receipt WHERE tenant_id=$1 AND idempotency_key=$2`,
              TENANT,
              key,
            ),
          ).toEqual([{ response_status: 201 }]);
        });
      // TR_TAG_OPBL.cs:10857 {{Module_Save.TagEntTran = DC_Main.Dc.BeginTransaction();}}
      for (const table of ['MAIN_STOCK', 'BAR_DETL', 'BAR_IDTL'])
        for (const method of ['POST', 'PUT'] as const)
          it(`tag-opening.rollback.pending ${method} fault on ${table}`, async () => {
            const no = method === 'PUT' ? await create(book) : '';
            const opened = no ? await reopen(book, no) : undefined;
            const before = await snapshot();
            const other = await snapshot(OTHER);
            await installFault(table, 'INSERT');
            try {
              const failed = await request(method, no ? url(book, no) : BASE, {
                ...payload(book),
                ...(opened ? { expectedVersion: opened.version } : {}),
              });
              // A trigger fault surfaces as a Prisma P2010 raw-query failure, which `run` maps to a
              // 400 invalid-data carrying the database's message (routes/txn.ts error mapper) — the
              // taxonomy contraResiduals.routes.db.test.ts asserts (>= 400) for the same fault class.
              // The desktop has no HTTP status; what matters is that the request fails cleanly.
              expect.soft(failed.statusCode, failed.body).toBeGreaterThanOrEqual(400);
              expect(failed.body).toContain('wp32 injected fault');
              await unchanged(before);
              await unchanged(other, OTHER);
            } finally {
              await removeFault(table);
            }
            const retry = await request(method, no ? url(book, no) : BASE, {
              ...payload(book),
              ...(opened ? { expectedVersion: opened.version } : {}),
            });
            expect(retry.statusCode, retry.body).toBe(method === 'POST' ? 201 : 200);
          });
      for (const table of ['BAR_IDTL', 'MAIN_STOCK'])
        it(`tag-opening.rollback.delete-and-print DELETE fault on ${table}`, async () => {
          // The desktop removes per-tag SRNO_MAST rows first (TR_TAG_OPBL.cs:11421), but the web keeps
          // ONE counter row per company/location (schema uq_srno_mast_tenant_company_location,
          // numbering.ts:177-213), never per-tag rows — so no SRNO_MAST deletion can fail. The web's
          // first deletion family is the voucher's own set (BAR_IDTL), then MAIN_STOCK (:11426).
          const no = await create(book);
          const opened = await reopen(book, no);
          const before = await snapshot();
          await installFault(table, 'DELETE');
          try {
            const result = await request(
              'DELETE',
              url(book, no) + `&expectedVersion=${opened.version}`,
            );
            expect.soft(result.statusCode, result.body).toBeGreaterThanOrEqual(400);
            expect(result.body).toContain('wp32 injected fault');
            await unchanged(before);
          } finally {
            await removeFault(table);
          }
        });
      it('tag-opening.rollback.delete-and-print print fault after blanks', async () => {
        const no = await create(book);
        const tables = [...TABLES, 'TAG_PRINT_DATA'];
        const before = await snapshot(TENANT, tables);
        await installFault('TAG_PRINT_DATA', 'INSERT', true);
        try {
          const result = await request('POST', url(book, no, '/print'), {
            labelSkip: 2.5,
            labelFile: 'A32',
          });
          expect(result.statusCode, result.body).toBe(500);
          expect(result.body).toContain('wp32 injected fault');
          await unchanged(before, TENANT, tables);
        } finally {
          await removeFault('TAG_PRINT_DATA');
        }
      });
      it('tag-opening.rights.scope-sentinels isolates a second tenant with identical visible identities', async () => {
        const no = await create(book);
        expect(await create(book, [line('W32A'), line('W32B')], OTHER)).toBe(no);
        const tables = [...TABLES, 'TAG_PRINT_DATA', 'PRINT_MAST'];
        const foreign = await snapshot(OTHER, tables);
        expect(
          await withTenant(runtime, TENANT, (tx) =>
            tx.$queryRawUnsafe(`SELECT "VCH_NO" FROM "BAR_DATA" WHERE tenant_id=$1`, OTHER),
          ),
        ).toEqual([]);
        expect(
          await withTenant(runtime, TENANT, (tx) =>
            tx.$executeRawUnsafe(
              `UPDATE "BAR_DATA" SET "VCH_NO"='99999' WHERE tenant_id=$1`,
              OTHER,
            ),
          ),
        ).toBe(0);
        const opened = await reopen(book, no);
        const edit = await request('PUT', url(book, no), {
          ...payload(book),
          expectedVersion: opened.version,
        });
        expect(edit.statusCode, edit.body).toBe(200);
        const print = await request('POST', url(book, no, '/print'), {
          labelSkip: 0,
          labelFile: 'A32',
        });
        expect.soft(print.statusCode, print.body).toBe(200);
        await unchanged(foreign, OTHER, tables);
      });
      it('tag-opening.output.voucher-projection / D-32-6 rounds 2.5 to two blanks and copies all selected fields', async () => {
        const no = await create(book);
        await create(book, [line('W32EXCLUDED')]);
        const expected = [projection(book, no, 1), projection(book, no, 2)];
        // Freeze source values independently of the current writer before printing.
        // TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}}
        for (const row of expected) {
          const entries = Object.entries(row);
          await exec(
            `UPDATE "BAR_DETL" SET ${entries.map(([key], i) => `"${key}"=$${i + 5}`).join(',')}
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "SR_NO"=$4`,
            TENANT,
            book,
            no,
            row.SR_NO,
            ...entries.map(([, value]) => value),
          );
        }
        const before = await snapshot();
        const result = await request('POST', url(book, no, '/print'), {
          labelSkip: 2.5,
          labelFile: 'A32',
        });
        expect(result.statusCode, result.body).toBe(200);
        expect(result.headers['content-type']).toContain('text/html');
        // TR_TAG_OPBL.cs:11485 {{int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));}}
        expect(result.body.match(/class="lbl blank"/g)).toHaveLength(2);
        expect(result.body.match(/class="lbl"/g)).toHaveLength(2);
        expect(result.body.indexOf('class="lbl blank"')).toBeLessThan(
          result.body.indexOf('class="lbl"'),
        );
        expect(result.body).toContain('W32A');
        expect(result.body).toContain('W32B');
        expect(result.body).not.toContain('W32EXCLUDED');
        const staged = await query<Record<string, unknown>>(
          `SELECT * FROM "TAG_PRINT_DATA" WHERE tenant_id=$1 ORDER BY row_id`,
          TENANT,
        );
        expect(staged).toHaveLength(4);
        // TR_TAG_OPBL.cs:11489 {{Conversions.ToString(DC_Main.i) + ",'00',0)"}}
        expect(staged.slice(0, 2).map((row) => [row.IT_CODE, Number(row.VCH_SRNO)])).toEqual([
          ['00', 0],
          ['00', 0],
        ]);
        for (const [index, oracle] of expected.entries())
          for (const [column, value] of Object.entries(oracle)) {
            const actual = staged[index + 2]![column];
            const normalize = (v: unknown) => (v instanceof Date ? v.toISOString() : v);
            expect(
              typeof value === 'number' ? Number(actual) : normalize(actual),
              `tag ${index + 1}, ${column}`,
            ).toEqual(normalize(value));
          }
        await unchanged(before);
      });
    });
  async function installFault(
    table: string,
    operation: 'INSERT' | 'DELETE',
    realLabelsOnly = false,
  ) {
    // Existing pattern: idempotency.routes.db.test.ts; only fixed synthetic identifiers enter DDL.
    await exec(`CREATE OR REPLACE FUNCTION wp32_tag_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
      BEGIN
        IF ${operation === 'DELETE' ? 'OLD' : 'NEW'}.tenant_id = '${TENANT}' ${realLabelsOnly ? `AND NEW."IT_CODE" <> '00'` : ''} THEN
          RAISE EXCEPTION 'wp32 injected fault';
        END IF;
        RETURN ${operation === 'DELETE' ? 'OLD' : 'NEW'};
      END $f$`);
    await exec(
      `CREATE TRIGGER wp32_tag_fault AFTER ${operation} ON "${table}" FOR EACH ROW EXECUTE FUNCTION wp32_tag_fault()`,
    );
  }
  async function removeFault(table: string) {
    await exec(`DROP TRIGGER IF EXISTS wp32_tag_fault ON "${table}"`);
    await exec('DROP FUNCTION IF EXISTS wp32_tag_fault()');
  }
});
/** Every projected column is frozen independently of the implementation column list.
 * TR_TAG_OPBL.cs:11523 {{ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE}}
 */
function projection(book: string, no: string, sr: number) {
  return {
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: YEAR,
    CO_BOOK: book,
    VCH_NO: no,
    SR_NO: sr,
    OLD_SRNO: sr,
    VCH_DATE: new Date(`${DAY}T00:00:00.000Z`),
    STK_DATE: DAY,
    VCH_TIME: new Date(`${DAY}T12:34:56.000Z`),
    VCH_TYPE: 'TAGOP',
    INOUT_TYPE: 'I',
    ENTRY_TYPE: 'O',
    BOOK_NAME: 'WP32',
    AC_CODE: 'AC32',
    IT_CODE: 'GOLD',
    TAG_NO: sr === 1 ? 'W32A' : 'W32B',
    LOT_NO: 'L32',
    DESIGN_NO: 'D32',
    TBL_CODE: '001',
    ITM_SIZE: '18',
    ITM_PCS: sr,
    BAG_WT: 0.1,
    ITM_GWT: 10.5,
    ITM_OTH_WT: 0.5,
    ITM_NWT: 10,
    ITM_GHT_PRC: 0,
    ITM_GHT_WT: 0,
    ITM_TOUCH: 90,
    ITM_WEST_PRC: 2,
    ITM_FINE: (10 * (90 + 2)) / 100,
    LBR_PRC: 1,
    LBR_RATE: 2,
    LBR_TYPE: 'P',
    LBR_AMT: 3,
    OTH_AMT: 4,
    ITM_RATE: 5,
    ITM_AMT: 6,
    TAG_COST: 7,
    ITM_MARGIN: 8,
    ITM_MRP: 9,
    ITM_REMARK: 'WP32',
    SF_NO: 'SF32',
    KR_NAME: 'KR32',
    VCH_SRNO: 320 + sr,
    RATE_TYPE: 'G',
    IT_TYPE: 'G',
    TAG_TYPE: 'A',
    PR_CODE: 'P3',
    HM_ID: 'H32',
    HM_ID2: 'H32A',
    HM_ID3: 'H32B',
    HM_ID4: 'H32C',
    HM_ID_WT: 1,
    HM_ID2_WT: 2,
    HM_ID3_WT: 3,
    HM_ID4_WT: 4,
    ITM_COLOR: sr === 1 ? 'C32A' : 'C32B',
    LBR_CODE: sr === 1 ? 'L32A' : 'L32B',
    ITM_STYLE: sr === 1 ? 'S32A' : 'S32B',
  };
}
