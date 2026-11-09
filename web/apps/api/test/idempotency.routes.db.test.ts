import type { FastifyInstance } from 'fastify';
import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { purgeExpiredCommandReceipts } from '../src/modules/shared/idempotency.js';
import { withTxBudget } from '../src/modules/shared/txBudget.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * N52 (G29, D18; LITE-MASTER-PLAN WP-04): a replayed voucher create never posts a second voucher.
 *
 * Through the real Fastify routes on forced RLS, for Stock Adjust and Tag Cancel (TR_TAG_CAN on a STOCK ADJUST or
 * TAG CANCEL book, MDI_FORM.cs:8585-8627) and the four
 * TR_CASH menus (Cash/Bank Received → POST /receipts, /receipts/multi; Cash/Bank Payment → POST /payments,
 * /payments/multi). Expected values are the contract, not the current output: the same key and request replay the
 * first answer byte for byte and write nothing; the same key with another request is 409 idempotency-key-reused;
 * keys are per tenant; a refused save keeps no receipt; an expired receipt is purged and frees its key.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'idem-route-db';
const OTHER = 'idem-route-other';
const PASSWORD = 'Idempotency-Route!2026';
const SECRET = 'idempotency-route-test-signing-secret-over-thirty-two-chars';
const LOGIN = 'clerk';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const TAG = 'IDT00001';

const adjust = (netWt: number) => ({
  coBook: 'SAJ',
  vchDate: DAY,
  vchDesc: 'idempotency',
  lines: [{ itCode: 'IDL22', itmSign: '+', grossWt: netWt, netWt, touch: 91.6 }],
});
const receipt = (amount: number) => ({
  coBook: 'RCT',
  vchDate: DAY,
  partyAc: 'CUST01',
  partyName: 'Walk-in Customer',
  amount,
  mode: 'cash',
});
const payment = (amount: number) => ({ ...receipt(amount), coBook: 'PAY' });
const lines = (coBook: string, amount: number) => ({
  coBook,
  vchDate: DAY,
  mode: 'cash',
  lines: [{ partyAc: 'CUST01', partyName: 'Walk-in Customer', amount }],
});

(enabled ? describe : describe.skip)('N52 Idempotency-Key on voucher creates through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const wipe = async (tenant: string) => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
  };
  const post = (tenant: string, url: string, payload: unknown, key?: string) =>
    app.inject({
      method: 'POST',
      url,
      headers: {
        cookie: cookies[tenant] ?? '',
        ...(key === undefined ? {} : { 'idempotency-key': key }),
      },
      payload: payload as any,
    });
  const count = async (tenant: string, table: string, book: string) => {
    const [row] = await query<Array<{ n: number }>>(
      `SELECT count(DISTINCT "VCH_NO")::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      tenant,
      book,
    );
    return row!.n;
  };
  const stockRows = async (tenant: string) => {
    const [row] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ'`,
      tenant,
    );
    return row!.n;
  };
  const ledgerRows = async (tenant: string, book: string) => {
    const [row] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
      tenant,
      book,
    );
    return row!.n;
  };
  const receipts = async (tenant: string, key: string) =>
    query<Array<{ route: string; status: number; actor: string }>>(
      `SELECT route, response_status status, actor FROM "api_command_receipt"
        WHERE tenant_id=$1 AND idempotency_key=$2`,
      tenant,
      key,
    );
  const setUp = async (tenant: string) => {
    await seedCompany(runtime, tenant, '01');
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
       VALUES ($1,'01','IDL22','IDEM LOOSE 22K','G','ID','G')`,
      tenant,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','CUST01','Walk-in Customer','10')`,
      tenant,
    );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenant,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    for (const [mainMenu, subMenu] of [
      ['Other', 'Stock Adjust'],
      ['Other', 'Tag Cancel'],
      ['Transaction', 'Cash Received'],
      ['Transaction', 'Cash Payment'],
      ['Cash / Bank', 'Multi-Party Receipt'],
    ])
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,$3,$4,'Y','Y','Y','Y')`,
        tenant,
        LOGIN,
        mainMenu,
        subMenu,
      );
  };

  const tagBalance = async (tenant: string, tagNo: string) => {
    const [row] = await query<Array<{ bal: number }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS bal FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenant,
      tagNo,
    );
    return Number(row?.bal ?? 0);
  };
  /** A purchased tag in stock (BAR_DETL + its MAIN_STOCK in-row), as stockAdjust.routes.db.test.ts seeds it. */
  const seedTag = async (tenant: string, tagNo: string) => {
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","KR_NET_WT","KR_TOUCH","KR_FINE","TBL_CODE","KR_NAME",
         "PR_CODE","IT_TYPE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'PURCHASE','I',$4,100312000021,'IDL22',1,8.5,8.2,
               92,5,7.954,8.2,92,7.544,'001','KJ','ID','G','N')`,
      tenant,
      YEAR,
      DAY,
      tagNo,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'IDL22',$4,100312000021,'P','+',1,1,8.5,8.2)`,
      tenant,
      YEAR,
      DAY,
      tagNo,
    );
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe(TENANT);
    await wipe(OTHER);
    await setUp(TENANT);
    await setUp(OTHER);
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const tenant of [TENANT, OTHER]) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenant },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookies[tenant] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await wipe(TENANT);
      await wipe(OTHER);
    }
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('Stock Adjust: a replayed create answers the first response byte for byte and posts one voucher', async () => {
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000001';
    const before = {
      vouchers: await count(TENANT, 'BAR_CAN_DATA', 'SAJ'),
      stock: await stockRows(TENANT),
    };
    const first = await post(TENANT, '/stock/stock-adjust', adjust(5), key);
    expect(first.statusCode, first.body).toBe(201);
    expect(first.headers['idempotency-replayed']).toBeUndefined();
    const replay = await post(TENANT, '/stock/stock-adjust', adjust(5), key);
    expect(replay.statusCode, replay.body).toBe(201);
    expect(replay.body).toBe(first.body);
    expect(replay.headers['idempotency-replayed']).toBe('true');
    expect(replay.headers['content-type']).toMatch(/^application\/json/);
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before.vouchers + 1);
    expect(await stockRows(TENANT)).toBe(before.stock + 1);
    expect(await receipts(TENANT, key)).toEqual([
      { route: '/stock/stock-adjust', status: 201, actor: LOGIN },
    ]);
  });

  it('Stock Adjust: two identical requests racing with one key post one voucher and both get its answer', async () => {
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000002';
    const before = await count(TENANT, 'BAR_CAN_DATA', 'SAJ');
    const [a, b] = await Promise.all([
      post(TENANT, '/stock/stock-adjust', adjust(6), key),
      post(TENANT, '/stock/stock-adjust', adjust(6), key),
    ]);
    expect([a.statusCode, b.statusCode], `${a.body} | ${b.body}`).toEqual([201, 201]);
    expect(a.body).toBe(b.body);
    expect(
      [a.headers['idempotency-replayed'], b.headers['idempotency-replayed']].filter(Boolean),
    ).toEqual(['true']);
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before + 1);
  });

  it('Stock Adjust: the same key with a different body is 409 idempotency-key-reused and writes nothing', async () => {
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000003';
    const first = await post(TENANT, '/stock/stock-adjust', adjust(7), key);
    expect(first.statusCode, first.body).toBe(201);
    const before = {
      vouchers: await count(TENANT, 'BAR_CAN_DATA', 'SAJ'),
      stock: await stockRows(TENANT),
    };
    const changed = await post(TENANT, '/stock/stock-adjust', adjust(8), key);
    expect(changed.statusCode, changed.body).toBe(409);
    expect(changed.json()).toMatchObject({ error: 'idempotency-key-reused' });
    expect(changed.headers['idempotency-replayed']).toBeUndefined();
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before.vouchers);
    expect(await stockRows(TENANT)).toBe(before.stock);
  });

  it('a refused save keeps no receipt, so the corrected request with the same key saves once', async () => {
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000004';
    const before = await count(TENANT, 'BAR_CAN_DATA', 'SAJ');
    const refused = await post(
      TENANT,
      '/stock/stock-adjust',
      { ...adjust(9), lines: [{ itCode: 'IDL22', itmSign: 'X', grossWt: 9, netWt: 9 }] },
      key,
    );
    expect(refused.statusCode, refused.body).toBe(400);
    expect(refused.json().message).toBe('Please Insert Item Sign + or - then Try');
    expect(await receipts(TENANT, key)).toEqual([]);
    const corrected = await post(TENANT, '/stock/stock-adjust', adjust(9), key);
    expect(corrected.statusCode, corrected.body).toBe(201);
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before + 1);
    expect(await receipts(TENANT, key)).toHaveLength(1);
  });

  it('a fault after the voucher rows are written rolls the receipt back with them', async () => {
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000005';
    await exec(
      `CREATE OR REPLACE FUNCTION idem_stock_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
       BEGIN
         IF NEW.tenant_id = '${TENANT}' AND NEW."ITM_NWT" = 4.321 THEN RAISE EXCEPTION 'idem stock fault'; END IF;
         RETURN NEW;
       END $f$`,
    );
    await exec(
      `CREATE TRIGGER idem_stock_fault BEFORE INSERT ON "MAIN_STOCK" FOR EACH ROW EXECUTE FUNCTION idem_stock_fault()`,
    );
    const before = await count(TENANT, 'BAR_CAN_DATA', 'SAJ');
    try {
      const failed = await post(TENANT, '/stock/stock-adjust', adjust(4.321), key);
      expect(failed.statusCode, failed.body).toBeGreaterThanOrEqual(400);
    } finally {
      await exec(`DROP TRIGGER IF EXISTS idem_stock_fault ON "MAIN_STOCK"`);
      await exec(`DROP FUNCTION IF EXISTS idem_stock_fault()`);
    }
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before);
    expect(await receipts(TENANT, key)).toEqual([]);
    const retried = await post(TENANT, '/stock/stock-adjust', adjust(4.321), key);
    expect(retried.statusCode, retried.body).toBe(201);
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before + 1);
  });

  it('two tenants using the same key do not collide', async () => {
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000006';
    const before = {
      mine: await count(TENANT, 'BAR_CAN_DATA', 'SAJ'),
      other: await count(OTHER, 'BAR_CAN_DATA', 'SAJ'),
    };
    const mine = await post(TENANT, '/stock/stock-adjust', adjust(3), key);
    const other = await post(OTHER, '/stock/stock-adjust', adjust(3), key);
    expect(mine.statusCode, mine.body).toBe(201);
    expect(other.statusCode, other.body).toBe(201);
    expect(other.headers['idempotency-replayed']).toBeUndefined();
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before.mine + 1);
    expect(await count(OTHER, 'BAR_CAN_DATA', 'SAJ')).toBe(before.other + 1);
    // Forced RLS: the runtime role bound to one tenant sees none of the other's receipts.
    const visible = await withTxBudget(
      runtime,
      TENANT,
      'read',
      (tx) =>
        tx.$queryRaw<Array<{ tenant_id: string }>>`
        SELECT tenant_id FROM "api_command_receipt" WHERE idempotency_key = ${key}`,
    );
    expect(visible).toEqual([{ tenant_id: TENANT }]);
  });

  it('Tag Cancel: a replayed cancel answers the first voucher instead of refusing the already-cancelled tag', async () => {
    await seedTag(TENANT, TAG);
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000008';
    const body = { coBook: 'TGC', vchDate: DAY, lines: [{ tagNo: TAG }] };
    const before = await count(TENANT, 'BAR_CAN_DATA', 'TGC');
    const first = await post(TENANT, '/stock/tag-cancel', body, key);
    expect(first.statusCode, first.body).toBe(201);
    expect(await tagBalance(TENANT, TAG)).toBe(0);
    const replay = await post(TENANT, '/stock/tag-cancel', body, key);
    expect(replay.statusCode, replay.body).toBe(201);
    expect(replay.body).toBe(first.body);
    expect(replay.headers['idempotency-replayed']).toBe('true');
    expect(await count(TENANT, 'BAR_CAN_DATA', 'TGC')).toBe(before + 1);
    expect(await tagBalance(TENANT, TAG)).toBe(0);
    // Without the key the second save is the desktop's refusal: the tag is no longer in stock.
    const unkeyed = await post(TENANT, '/stock/tag-cancel', body);
    expect(unkeyed.statusCode, unkeyed.body).toBe(400);
    expect(await count(TENANT, 'BAR_CAN_DATA', 'TGC')).toBe(before + 1);
  });

  it('without the header a create behaves as before (an older page is not broken)', async () => {
    const before = await count(TENANT, 'BAR_CAN_DATA', 'SAJ');
    const a = await post(TENANT, '/stock/stock-adjust', adjust(2));
    const b = await post(TENANT, '/stock/stock-adjust', adjust(2));
    expect([a.statusCode, b.statusCode]).toEqual([201, 201]);
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before + 2);
  });

  it('refuses a malformed key before any write', async () => {
    const before = await count(TENANT, 'BAR_CAN_DATA', 'SAJ');
    for (const key of ['x'.repeat(129), 'has space']) {
      const response = await post(TENANT, '/stock/stock-adjust', adjust(1), key);
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json()).toMatchObject({ error: 'invalid-idempotency-key' });
    }
    expect(await count(TENANT, 'BAR_CAN_DATA', 'SAJ')).toBe(before);
  });

  it.each([
    ['/receipts', receipt(1250), 'CASH_DATA', 'RCT'],
    ['/payments', payment(640), 'PAY_DATA', 'PAY'],
    ['/receipts/multi', lines('RCT', 310), 'CASH_DATA', 'RCT'],
    ['/payments/multi', lines('PAY', 220), 'PAY_DATA', 'PAY'],
  ] as const)(
    'Cash/Bank %s: a replay posts one voucher and one set of ledger legs; a changed body is 409',
    async (url, body, table, book) => {
      const key = `cash-bank-${url.replace(/\W/g, '')}-0001`;
      const before = {
        vouchers: await count(TENANT, table, book),
        legs: await ledgerRows(TENANT, book),
      };
      const first = await post(TENANT, url, body, key);
      expect(first.statusCode, first.body).toBe(201);
      const legs = (await ledgerRows(TENANT, book)) - before.legs;
      expect(legs).toBeGreaterThan(0);
      const replay = await post(TENANT, url, body, key);
      expect(replay.statusCode, replay.body).toBe(201);
      expect(replay.body).toBe(first.body);
      expect(replay.headers['idempotency-replayed']).toBe('true');
      const changed = await post(TENANT, url, { ...body, vchDate: `${startYear}-06-16` }, key);
      expect(changed.statusCode, changed.body).toBe(409);
      expect(await count(TENANT, table, book)).toBe(before.vouchers + 1);
      expect(await ledgerRows(TENANT, book)).toBe(before.legs + legs);
    },
  );

  it('a key used on one route is refused on another route', async () => {
    const key = 'b6f1a0de-5d0c-4a59-9a43-000000000007';
    const first = await post(TENANT, '/receipts', receipt(90), key);
    expect(first.statusCode, first.body).toBe(201);
    const before = await count(TENANT, 'PAY_DATA', 'PAY');
    const elsewhere = await post(TENANT, '/payments', payment(90), key);
    expect(elsewhere.statusCode, elsewhere.body).toBe(409);
    expect(await count(TENANT, 'PAY_DATA', 'PAY')).toBe(before);
  });

  it('purges expired receipts of one tenant only, and an expired key is free again', async () => {
    const expired = 'b6f1a0de-5d0c-4a59-9a43-00000000000e';
    const live = 'b6f1a0de-5d0c-4a59-9a43-00000000000f';
    for (const [tenant, key, at] of [
      [TENANT, expired, `now() - interval '1 hour'`],
      [TENANT, live, `now() + interval '1 hour'`],
      [OTHER, expired, `now() - interval '1 hour'`],
    ] as const)
      await exec(
        `INSERT INTO "api_command_receipt"(tenant_id,idempotency_key,route,request_sha256,actor,response_status,response_body,expires_at)
         VALUES ($1,$2,'/stock/stock-adjust',repeat('0',64),$3,201,'{"vchNo":999}',${at})`,
        tenant,
        key,
        LOGIN,
      );
    // An expired receipt is not replayed: the key saves a new voucher (the claim takes the row over).
    const before = await count(OTHER, 'BAR_CAN_DATA', 'SAJ');
    const reused = await post(OTHER, '/stock/stock-adjust', adjust(1.5), expired);
    expect(reused.statusCode, reused.body).toBe(201);
    expect(reused.json().vchNo).not.toBe(999);
    expect(await count(OTHER, 'BAR_CAN_DATA', 'SAJ')).toBe(before + 1);

    expect(await purgeExpiredCommandReceipts(runtime, TENANT)).toBe(1);
    expect(await receipts(TENANT, expired)).toEqual([]);
    expect(await receipts(TENANT, live)).toHaveLength(1);
    expect(await receipts(OTHER, expired)).toHaveLength(1);
  });
});
