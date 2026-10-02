import { randomUUID } from 'node:crypto';
import { PrismaClient } from '@datacare/db';
import type { Tx } from '@datacare/db';
import { SignJWT } from 'jose';
import type { FastifyInstance, InjectOptions, LightMyRequestResponse } from 'fastify';
import { afterAll, afterEach, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { verifyAccessToken, type SessionClaims } from '../src/modules/auth/jwt.js';
import type { SessionCommandIdentity } from '../src/modules/auth/sessionContextCommand.js';
import {
  createSalesOrder,
  editSalesOrderInSession,
  getSalesOrder,
  type SalesOrderInput,
} from '../src/modules/sales/salesOrder.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'order-session-command';
const foreignTenant = 'order-session-other';
const tenants = [tenantId, foreignTenant];
const secret = 'sales-order-command-real-http-secret-at-least-thirty-two-characters';
const password = 'Order-Command-Test!2026';
const scope = (coBook = 'C13') => ({
  tenantId,
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook,
});
type Raw = Record<string, string | null>;
type Physical = { raw: string; revision: string; locator: string };
type Context = {
  sessionId: string;
  contextEpoch: string;
  coCode: string;
  lcCode: string;
  coYear: string | null;
};
type Audit = Physical & {
  id: string;
  tenantId: string;
  loginName: string;
  coCode: string;
  action: string;
  path: string;
  status: number;
};
type Signed = { cookie: string; claims: SessionClaims; context: Context };
type Outcome<T> = { status: 'fulfilled'; value: T } | { status: 'rejected'; reason: unknown };
const orderTables = [
  'SL_ORD_DATA',
  'SL_ORD_DETL',
  'SL_ORD_IDTL',
  'SL_PR_DETL',
  'SL_ORD_ADJ',
  'UPI_DATA',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'TEMP_BOOK_DATA',
  'DELETE_DATA',
] as const;
const protectedTables = [
  'auth_session',
  'CO_MAST',
  'LOCT_MAST',
  'YEAR_MAST',
  'LOGIN_MAST',
  'USER_SET',
  'CO_SET',
  'CO_SET_NEW',
  'BOOK_DATA',
  'AC_MAST',
  'ITEM_MAST',
] as const;
const path = (coBook = 'C13') =>
  `/sales-orders/00001?${new URLSearchParams({ coCode: '01', lcCode: '01', coYear: '2024-2025', coBook })}`;
const page = (context: Context) => ({
  'x-session-context-id': context.sessionId,
  'x-session-context-epoch': context.contextEpoch,
});
const cookies = (response: LightMyRequestResponse) => {
  const value = response.headers['set-cookie'];
  return (Array.isArray(value) ? value : value === undefined ? [] : [String(value)])
    .map((value) => value.split(';', 1)[0]!)
    .join('; ');
};
const accessCookie = (cookie: string) => {
  const pair = cookie.split('; ').find((value) => value.startsWith('access='));
  if (!pair) throw new Error('Real login did not issue an access cookie');
  return decodeURIComponent(pair.slice('access='.length));
};
const identity = (signed: Signed): SessionCommandIdentity => ({
  tenantId: signed.claims.tenantId,
  sessionId: signed.claims.sid,
  loginName: signed.claims.sub,
  loginCoCode: signed.claims.loginCoCode,
  coCode: signed.claims.coCode,
  lcCode: signed.claims.lcCode,
  coYear: signed.claims.coYear,
  contextEpoch: signed.claims.contextEpoch,
});
const deferred = <T>() => {
  let resolve!: (value: T) => void;
  const promise = new Promise<T>((done) => {
    resolve = done;
  });
  return { promise, resolve };
};
const settle = <T>(promise: Promise<T>) =>
  promise.then(
    (value) => ({ status: 'fulfilled' as const, value }),
    (reason: unknown) => ({ status: 'rejected' as const, reason }),
  );

run('Sales Order financial edit joins the admitted HTTP session transaction', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let hash: string;
  let signed: Signed;
  let testNumber = 0;
  let requestNumber = 0;
  let afterAuthorization: (() => Promise<void>) | undefined;
  let observedAuthorization = false;
  let foreignBefore: Record<string, Physical[]>;
  const responses = new Map<string, () => void>();
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const clean = async () => {
    for (const table of ['audit_log', ...orderTables, ...protectedTables])
      await sql(`DELETE FROM "${table}" WHERE tenant_id=ANY($1::text[])`, tenants);
  };
  const physical = async (tables: readonly string[], book?: string, selectedTenants = tenants) => {
    const result: Record<string, Physical[]> = {};
    for (const table of tables)
      result[table] = await owner.$queryRawUnsafe<Physical[]>(
        `SELECT to_jsonb(t)::text raw,xmin::text revision,ctid::text locator FROM "${table}" t
         WHERE tenant_id=ANY($1::text[])${book === undefined ? '' : ' AND "CO_BOOK"=$2'} ORDER BY to_jsonb(t)::text`,
        selectedTenants,
        ...(book === undefined ? [] : [book]),
      );
    return result;
  };
  const exact = async () => ({
    orders: await physical(orderTables),
    protected: await physical(protectedTables),
  });
  const business = async (book = 'C13') => {
    const result: Record<string, Raw[]> = {};
    for (const table of orderTables) {
      const rows = await owner.$queryRawUnsafe<Array<{ raw: Raw }>>(
        `SELECT (SELECT jsonb_object_agg(j.key,j.value) FROM jsonb_each_text(to_jsonb(t)-'row_id') j) AS raw
         FROM "${table}" t WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY (to_jsonb(t)-'row_id')::text`,
        tenantId,
        book,
      );
      result[table] = rows.map((row) => row.raw);
    }
    return result;
  };
  const audit = () =>
    owner.$queryRawUnsafe<Audit[]>(
      `SELECT id::text id,tenant_id AS "tenantId",login_name AS "loginName",co_code AS "coCode",
       action,path,status,to_jsonb(t)::text raw,xmin::text revision,ctid::text locator
     FROM audit_log t WHERE tenant_id=ANY($1::text[]) ORDER BY t.id`,
      tenants,
    );
  const request = async (
    method: 'GET' | 'POST' | 'PUT',
    url: string,
    payload: unknown,
    cookie = signed?.cookie ?? '',
    headers: Record<string, string> = {},
    expectedAudit?: { status: number; coCode?: string },
  ) => {
    const before = await audit();
    const id = String(++requestNumber);
    const done = deferred<void>();
    responses.set(id, () => done.resolve());
    let timer: ReturnType<typeof setTimeout> | undefined;
    try {
      const response = await app.inject({
        method,
        url,
        remoteAddress: `127.0.1.${testNumber}`,
        headers: { cookie, ...headers, 'x-order-command-test': id },
        ...(payload === undefined ? {} : { payload: payload as InjectOptions['payload'] }),
      });
      // Observe the real production onResponse audit completion, which can follow inject's reply.
      await Promise.race([
        done.promise,
        new Promise<never>((_, reject) => {
          timer = setTimeout(
            () => reject(new Error('Actual onResponse hook did not finish')),
            5000,
          );
        }),
      ]);
      const after = await audit();
      expect(
        after.slice(0, before.length),
        'old audit rows, including physical identities',
      ).toEqual(before);
      const appended = after.slice(before.length);
      expect(appended).toHaveLength(expectedAudit ? 1 : 0);
      if (expectedAudit) {
        const entry = appended[0]!;
        expect({
          tenantId: entry.tenantId,
          loginName: entry.loginName,
          coCode: entry.coCode,
          action: entry.action,
          path: entry.path,
          status: entry.status,
        }).toEqual({
          tenantId,
          loginName: 'operator',
          coCode: expectedAudit.coCode ?? '01',
          action: method,
          path: url.startsWith('/sales-orders/') ? '/sales-orders/:vchNo' : url.split('?')[0],
          status: expectedAudit.status,
        });
        expect(entry.id).toMatch(/^[1-9][0-9]*$/);
        expect(entry.revision).toMatch(/^[0-9]+$/);
        expect(entry.locator).toMatch(/^\([0-9]+,[0-9]+\)$/);
      }
      return response;
    } finally {
      if (timer !== undefined) clearTimeout(timer);
      responses.delete(id);
    }
  };
  const login = async (): Promise<Signed> => {
    const response = await request(
      'POST',
      '/auth/login',
      {
        loginName: 'operator',
        password,
        coCode: '01',
        lcCode: '01',
        coYear: '2024-2025',
      },
      '',
      { 'x-tenant-id': tenantId },
    );
    expect(response.statusCode, response.body).toBe(200);
    const cookie = cookies(response);
    const claims = await verifyAccessToken(accessCookie(cookie), secret);
    const body = response.json<{
      context: Context;
      ledgerContext: unknown;
    }>();
    expect(body.context).toEqual({
      sessionId: claims.sid,
      contextEpoch: '1',
      coCode: '01',
      lcCode: '01',
      coYear: '2024-2025',
    });
    expect(body.ledgerContext).toEqual({
      version: 'server-session-ledger-context-v1',
      status: 'unknown',
      mode: null,
      reason: 'vendor-authority-unresolved',
    });
    return { cookie, claims, context: body.context };
  };
  const load = async () => getSalesOrder(runtime, scope(), '00001');
  const edit = async (advanceAmount = 125): Promise<SalesOrderInput> => {
    const doc = await load();
    return {
      ...doc,
      scope: scope(),
      expectedVersion: doc.version,
      dirtyFields: ['advanceAmount'],
      advanceAmount,
      mainUser: 'new-user',
    } as unknown as SalesOrderInput;
  };
  const command = (
    input: SalesOrderInput,
    authority: unknown = identity(signed),
    client = runtime,
  ) =>
    editSalesOrderInSession(client, {
      identity: authority,
      input,
      voucherNo: '00001',
    });
  const initial = (book: string): SalesOrderInput => ({
    scope: scope(book),
    vchDate: '2024-07-10',
    vchTime: '12:34:56.123456',
    mainUser: 'original-user',
    acCode: 'PARTY',
    acName: 'Saved customer',
    taxRatePct: 0,
    advanceAmount: 100,
    cashAc: 'CASH',
    lines: [
      {
        srNo: 7,
        itCode: 'GL',
        designNo: 'CUSTOM',
        designImageId: 'N',
        pcs: 1,
        grossWt: 2.1,
        netWt: 2,
        touch: 100,
        rate: 100,
        labourAmount: 0,
        labourRate: 0,
        labourPct: 0,
        components: [
          {
            isrNo: 3,
            itCode: 'DM',
            dmName: 'Round exact',
            pcs: 1,
            grossWt: 0.123,
            amount: 11.11,
            lbrAmount: 1.01,
            netAmount: 12.12,
          },
          {
            isrNo: 13,
            itCode: 'DM',
            dmName: 'Oval exact',
            pcs: 2,
            grossWt: 0.456,
            amount: 22.22,
            lbrAmount: 2.02,
            netAmount: 24.24,
          },
        ],
      },
    ],
  });
  const numeric = (value: string | null | undefined) => {
    if (typeof value !== 'string' || !/^-?[0-9]+(?:\.[0-9]+)?$/.test(value))
      throw new Error(`Unexpected finite SQL decimal: ${String(value)}`);
    // Representation normalization only; no Number arithmetic or expected values derived from SUT.
    return value.replace(/\.0+$/, '');
  };
  const footprint = async (advance: '100' | '125') => {
    const rows = await business();
    expect(rows.SL_ORD_DATA).toHaveLength(1);
    expect(numeric(rows.SL_ORD_DATA![0]!.ADV_AMT)).toBe(advance);
    expect(rows.AC_DATA).toHaveLength(2);
    expect(
      rows
        .AC_DATA!.map((row) => ({
          ac: row.AC_CODE,
          dr: numeric(row.DR_AMT),
          cr: numeric(row.CR_AMT),
          sign: row.SIGN,
        }))
        .sort((a, b) => String(a.ac).localeCompare(String(b.ac))),
    ).toEqual([
      { ac: 'CASH', dr: advance, cr: '0', sign: '' },
      { ac: 'PARTY', dr: '0', cr: advance, sign: '' },
    ]);
    expect(rows.ROJ_MEL_DATA).toHaveLength(1);
    expect(rows.ROJ_MEL_DATA![0]).toMatchObject({
      AC_CODE: 'PARTY',
      LD_CODE: 'CASH',
      LEDR_KEY: '01012024-2025C130000101',
      VCH_TYPE: 'SORD',
      BOOK_NAME: 'SALES ORDER',
    });
    expect(numeric(rows.ROJ_MEL_DATA![0]!.DR_AMT)).toBe('0');
    expect(numeric(rows.ROJ_MEL_DATA![0]!.CR_AMT)).toBe(advance);
    expect(rows.SL_ORD_DETL).toHaveLength(1);
    expect(numeric(rows.SL_ORD_DETL![0]!.SR_NO)).toBe('7');
    expect(rows.SL_ORD_IDTL!.map((row) => numeric(row.ISR_NO)).sort()).toEqual(['13', '3']);
    return rows;
  };
  const expectAdvanceOnly = async (before: Record<string, Raw[]>) => {
    const after = await footprint('125');
    for (const table of orderTables) {
      const omit =
        table === 'SL_ORD_DATA'
          ? ['ADV_AMT']
          : table === 'AC_DATA' || table === 'ROJ_MEL_DATA'
            ? ['DR_AMT', 'CR_AMT']
            : [];
      const unchanged = (rows: Raw[]) =>
        rows
          .map((row) =>
            Object.fromEntries(Object.entries(row).filter(([key]) => !omit.includes(key))),
          )
          .sort((a, b) => JSON.stringify(a).localeCompare(JSON.stringify(b)));
      expect(
        unchanged(after[table]!),
        `complete ${table} business values except explicit advance amount`,
      ).toEqual(unchanged(before[table]!));
    }
    const doc = await load();
    expect(doc).toMatchObject({
      advanceAmount: 125,
      vchTime: '12:34:56.123456',
      mainUser: 'original-user',
      mobile: null,
    });
    expect(after.SL_ORD_DETL![0]).toMatchObject({
      BAG_WT: null,
      ITM_MRP: '999999999999999.99',
      LOT_NO: 'IMPORTED-LOT',
      TAG_GEN: null,
    });
    const child = after.SL_ORD_IDTL!.find((row) => numeric(row.ISR_NO) === '3');
    expect(child).toMatchObject({ KR_RATE: null, TAG_NO: 'IMPORTED-CHILD' });
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    if (new URL(process.env.DATABASE_URL!).username !== 'app_user')
      throw new Error('app_user runtime required');
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
    });
    runtime = new PrismaClient();
    hash = await hashPassword(password);
    app = await buildApp({ prisma: runtime, secret, secureCookies: false });
    app.addHook('preHandler', async (req, reply) => {
      if (
        !afterAuthorization ||
        req.method !== 'PUT' ||
        req.routeOptions.url !== '/sales-orders/:vchNo'
      )
        return;
      // The application's real central hook ran first. No auth result is manufactured here.
      expect(reply.sent).toBe(false);
      expect((req as unknown as { routeAuthorized?: boolean }).routeAuthorized).toBe(true);
      observedAuthorization = true;
      const callback = afterAuthorization;
      afterAuthorization = undefined;
      await callback();
    });
    app.addHook('onResponse', async (req) => {
      const id = req.headers['x-order-command-test'];
      if (typeof id === 'string') responses.get(id)?.();
    });
  });
  beforeEach(async () => {
    testNumber++;
    afterAuthorization = undefined;
    observedAuthorization = false;
    await clean();
    for (const company of ['01', '02']) {
      await sql(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME","LC_CODE") VALUES($1,$2,'Command company','01')`,
        tenantId,
        company,
      );
      await sql(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES($1,$2,'01','Main')`,
        tenantId,
        company,
      );
      await sql(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,$2,'2024-2025','2024-04-01','2025-03-31')`,
        tenantId,
        company,
      );
      await sql(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED") VALUES($1,$2,'operator',$3,'USER','Y','Y','Y','N')`,
        tenantId,
        company,
        hash,
      );
      await sql(
        `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","LAST_DAY_LOCK","LBR_ROF") VALUES($1,$2,NULL,'N',2)`,
        tenantId,
        company,
      );
      await sql(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,$2,'N')`,
        tenantId,
        company,
      );
    }
    await sql(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT") VALUES($1,'01','01','operator','Sales','Sales Order','Y','Y','Y','Y')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE","BOOK_TBL_NAME") VALUES($1,'01','01','C13','SALES ORDER','O','SORD','Command One','Y','SL_ORD_DATA'),($1,'01','01','C14','SALES ORDER','O','SORD','Command Two','Y','SL_ORD_DATA')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','Saved customer'),($1,'01','01','CASH','Cash')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","PR_CODE") VALUES($1,'01','GL','Gold','01'),($1,'01','DM','Diamond','02')`,
      tenantId,
    );
    await createSalesOrder(runtime, initial('C13'));
    await createSalesOrder(runtime, initial('C14'));
    await sql(
      `UPDATE "SL_ORD_DATA" SET "MOBILE"=NULL,"ENTRY_TIME"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='C13'`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_DETL" SET "BAG_WT"=NULL,"ITM_MRP"=999999999999999.99,"LOT_NO"='IMPORTED-LOT',"TAG_GEN"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='C13'`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_IDTL" SET "KR_RATE"=NULL,"TAG_NO"='IMPORTED-CHILD' WHERE tenant_id=$1 AND "CO_BOOK"='C13' AND "ISR_NO"=3`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_DATA"(tenant_id,"LEDR_KEY","CO_CODE","CO_BOOK","CR_AMT","DR_AMT","ENTRY_TIME") VALUES($1,'foreign-command-sentinel','01','C13',90071992547409.91,NULL,'2024-04-03 12:34:56.123456')`,
      foreignTenant,
    );
    signed = await login();
    foreignBefore = await physical([...orderTables, ...protectedTables], undefined, [
      foreignTenant,
    ]);
  });
  afterEach(async () => {
    expect(
      await physical([...orderTables, ...protectedTables], undefined, [foreignTenant]),
    ).toEqual(foreignBefore);
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await clean();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('the real session entry changes only advance100→125 and preserves children, raw precision, clock and accounting ownership', async () => {
    const before = await footprint('100');
    const guard = await physical(protectedTables),
      sibling = await physical(orderTables, 'C14');
    const allAudit = await audit();
    const previous = await load();
    const result = await command(await edit());
    expect(result).toMatchObject({ vchNo: 1, advance: 125 });
    await expectAdvanceOnly(before);
    expect((await load()).version).not.toBe(previous.version);
    expect(await physical(protectedTables)).toEqual(guard);
    expect(await physical(orderTables, 'C14')).toEqual(sibling);
    expect(await audit()).toEqual(allAudit);
  });

  it('mounted authenticated PUT uses the retained context and one balanced125 posting; an old document retry conflicts without another write', async () => {
    const saved = await request('GET', path(), undefined, signed.cookie, page(signed.context));
    expect(saved.statusCode, saved.body).toBe(200);
    const doc = saved.json<Record<string, unknown>>();
    const input = {
      ...doc,
      expectedVersion: doc.version,
      dirtyFields: ['advanceAmount'],
      advanceAmount: 125,
    };
    const before = await footprint('100'),
      protectedBefore = await physical(protectedTables);
    const sibling = await physical(orderTables, 'C14');
    const success = await request('PUT', path(), input, signed.cookie, page(signed.context), {
      status: 200,
    });
    expect(success.statusCode, success.body).toBe(200);
    expect(success.json()).toMatchObject({ vchNo: 1, advance: 125 });
    expect(success.headers['set-cookie']).toBeUndefined();
    await expectAdvanceOnly(before);
    expect(await physical(protectedTables)).toEqual(protectedBefore);
    expect(await physical(orderTables, 'C14')).toEqual(sibling);
    const committed = await exact();
    const conflict = await request('PUT', path(), input, signed.cookie, page(signed.context), {
      status: 409,
    });
    expect(conflict.statusCode, conflict.body).toBe(409);
    expect(conflict.json().error).toBe('SalesOrderConflictError');
    expect(await exact()).toEqual(committed);
  });

  it('missing authority, malformed epoch and mismatched captured scope cannot reach the financial writer', async () => {
    const input = await edit(),
      before = await exact();
    const { contextEpoch: _epoch, ...noEpoch } = identity(signed);
    await expect(
      editSalesOrderInSession(runtime, {
        identity: undefined,
        input,
        voucherNo: '00001',
      }),
    ).rejects.toMatchObject({ code: 'session-invalid', statusCode: 401 });
    for (const authority of [
      null,
      noEpoch,
      { ...identity(signed), contextEpoch: 1 },
      { ...identity(signed), sessionId: randomUUID() },
    ])
      await expect(command(input, authority)).rejects.toMatchObject({
        code: 'session-invalid',
        statusCode: 401,
      });
    await expect(
      command({ ...input, scope: scope('C13') }, { ...identity(signed), coCode: '02' }),
    ).rejects.toMatchObject({ code: 'scope-mismatch', statusCode: 409 });
    expect(await exact()).toEqual(before);
  });

  it('the actual command refuses a later committed epoch even if the company/location/year strings returned to A', async () => {
    const input = await edit();
    await sql(
      `UPDATE auth_session SET context_epoch=3 WHERE tenant_id=$1 AND session_id=$2`,
      tenantId,
      signed.context.sessionId,
    );
    const before = await exact();
    await expect(command(input)).rejects.toMatchObject({
      code: 'context-stale',
      statusCode: 409,
    });
    expect(await exact()).toEqual(before);
  });

  it('an actual row-lock wait cannot rebase captured input scope, amount, parent or child values', async () => {
    const input = await edit();
    const before = await footprint('100'),
      protectedBefore = await physical(protectedTables),
      sibling = await physical(orderTables, 'C14');
    const locked = deferred<void>(),
      release = deferred<void>(),
      pid = deferred<number>();
    const holder = settle(
      owner.$transaction(async (tx) => {
        await tx.$queryRawUnsafe(
          `SELECT session_id FROM auth_session WHERE tenant_id=$1 AND session_id=$2 FOR UPDATE`,
          tenantId,
          signed.context.sessionId,
        );
        locked.resolve();
        await release.promise;
      }),
    );
    // Only the transaction PID is observed. The transaction and every application query are real PG.
    const observed = {
      $transaction: <T>(
        callback: (tx: Tx) => Promise<T>,
        options?: Parameters<PrismaClient['$transaction']>[1],
      ) =>
        runtime.$transaction(async (tx) => {
          const rows = await tx.$queryRawUnsafe<Array<{ pid: number }>>(
            'SELECT pg_backend_pid()::int pid',
          );
          pid.resolve(rows[0]!.pid);
          return callback(tx);
        }, options),
    } as unknown as PrismaClient;
    let operation: Promise<Outcome<Awaited<ReturnType<typeof command>>>> | undefined;
    let failure: unknown;
    try {
      await Promise.race([
        locked.promise,
        holder.then(() => {
          throw new Error('Holder completed before lock');
        }),
      ]);
      operation = settle(command(input, identity(signed), observed));
      const backend = await Promise.race([
        pid.promise,
        operation.then(() => {
          throw new Error('Command completed before PID');
        }),
      ]);
      let blocked = false;
      for (let attempt = 0; attempt < 100; attempt++) {
        const rows = await owner.$queryRawUnsafe<Array<{ blocked: boolean }>>(
          `SELECT EXISTS(SELECT 1 FROM pg_stat_activity WHERE pid=$1 AND wait_event_type='Lock' AND cardinality(pg_blocking_pids(pid))>0) AS blocked`,
          backend,
        );
        if (rows[0]!.blocked) {
          blocked = true;
          break;
        }
        await new Promise((resolve) => setTimeout(resolve, 10));
      }
      expect(blocked, 'observed PostgreSQL lock wait, not a timing-only overlap').toBe(true);
      input.scope.coBook = 'C14';
      input.advanceAmount = 999;
      input.lines![0]!.remark = 'MUTATED AFTER ADMISSION';
      input.lines![0]!.components![0]!.dmName = 'MUTATED CHILD';
    } catch (error) {
      failure = error;
    } finally {
      release.resolve();
    }
    const held = await holder,
      result = operation ? await operation : undefined;
    if (failure) throw failure;
    if (held.status === 'rejected') throw held.reason;
    expect(result).toMatchObject({
      status: 'fulfilled',
      value: { advance: 125 },
    });
    await expectAdvanceOnly(before);
    expect(await physical(protectedTables)).toEqual(protectedBefore);
    expect(await physical(orderTables, 'C14')).toEqual(sibling);
  });

  it('fresh FRM_EDIT denial after the real central HTTP authorization is enforced inside the command', async () => {
    const input = await edit(),
      orders = await physical(orderTables);
    let afterChange: Awaited<ReturnType<typeof exact>> | undefined;
    afterAuthorization = async () => {
      await sql(
        `UPDATE "USER_SET" SET "FRM_EDIT"='N' WHERE tenant_id=$1 AND "USER_NAME"='operator'`,
        tenantId,
      );
      afterChange = await exact();
    };
    const response = await request('PUT', path(), input, signed.cookie, page(signed.context), {
      status: 403,
    });
    expect(observedAuthorization).toBe(true);
    expect(response.statusCode, response.body).toBe(403);
    expect(response.json()).toMatchObject({
      error: 'forbidden',
      form: 'Sales/Sales Order',
      action: 'update',
    });
    expect(afterChange).toBeDefined();
    expect(await exact()).toEqual(afterChange);
    expect(await physical(orderTables)).toEqual(orders);
  });

  it('fresh forced-reset refusal after central HTTP authorization rolls back before order replacement', async () => {
    const input = await edit();
    let changed: Awaited<ReturnType<typeof exact>> | undefined;
    afterAuthorization = async () => {
      await sql(
        `UPDATE "LOGIN_MAST" SET "PASSWORD_RESET_REQUIRED"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
      changed = await exact();
    };
    const response = await request('PUT', path(), input, signed.cookie, page(signed.context), {
      status: 403,
    });
    expect(observedAuthorization).toBe(true);
    expect(response.statusCode, response.body).toBe(403);
    expect(response.json().error).toBe('password-reset-required');
    expect(changed).toBeDefined();
    expect(await exact()).toEqual(changed);
  });

  it('mounted PUT refuses absent cookies and correctly signed legacy claims with no epoch', async () => {
    const input = await edit(),
      before = await exact();
    const { contextEpoch: _epoch, ...legacy } = signed.claims;
    const token = await new SignJWT(legacy)
      .setProtectedHeader({ alg: 'HS256', typ: 'JWT' })
      .setIssuer('datacare-api')
      .setAudience('datacare-web')
      .setIssuedAt()
      .setExpirationTime('5m')
      .sign(new TextEncoder().encode(secret));
    for (const cookie of ['', `access=${encodeURIComponent(token)}`]) {
      const response = await request('PUT', path(), input, cookie, page(signed.context));
      expect(response.statusCode, response.body).toBe(401);
    }
    expect(await exact()).toEqual(before);
  });

  it('real A→B→A selection invalidates the old bearer and same-scope page epoch before any PUT dispatch', async () => {
    const original = signed,
      input = await edit();
    const orderBefore = await physical(orderTables);
    for (const company of ['02', '01']) {
      const response = await request(
        'POST',
        '/context/select',
        {
          coCode: company,
          lcCode: '01',
          coYear: '2024-2025',
          expectedContextEpoch: signed.context.contextEpoch,
          selectionId: randomUUID(),
        },
        signed.cookie,
        page(signed.context),
        { status: 200, coCode: signed.context.coCode },
      );
      expect(response.statusCode, response.body).toBe(200);
      const cookie = cookies(response);
      signed = {
        cookie,
        claims: await verifyAccessToken(accessCookie(cookie), secret),
        context: response.json<{ context: Context }>().context,
      };
    }
    expect(signed.context).toEqual({
      ...original.context,
      contextEpoch: '3',
    });
    const before = await exact();
    const oldBearer = await request('PUT', path(), input, original.cookie, page(original.context));
    expect(oldBearer.statusCode, oldBearer.body).toBe(401);
    const oldPage = await request('PUT', path(), input, signed.cookie, page(original.context));
    expect(oldPage.statusCode, oldPage.body).toBe(409);
    expect(oldPage.json().error).toBe('context-stale');
    expect(await exact()).toEqual(before);
    expect(await physical(orderTables)).toEqual(orderBefore);
  });

  it('missing/noncanonical versions and incomplete children are rejected by mounted PUT without data replacement', async () => {
    const input = await edit(),
      before = await exact();
    for (const expectedVersion of [undefined, '', 'g'.repeat(64), `${input.expectedVersion}\n`]) {
      const response = await request(
        'PUT',
        path(),
        { ...input, expectedVersion },
        signed.cookie,
        page(signed.context),
        { status: 400 },
      );
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json().message).toMatch(/version/i);
    }
    const incomplete = structuredClone(input);
    delete incomplete.lines![0]!.components;
    const response = await request('PUT', path(), incomplete, signed.cookie, page(signed.context), {
      status: 400,
    });
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().message).toMatch(/complete.*components/i);
    expect(await exact()).toEqual(before);
  });

  it('a component validation failure after destructive replacement began restores the whole original write set', async () => {
    const input = await edit();
    input.lines![0]!.components![0]!.itCode = '';
    const before = await exact();
    const response = await request('PUT', path(), input, signed.cookie, page(signed.context), {
      status: 400,
    });
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().message).toMatch(/component 1: item is required/);
    expect(await exact()).toEqual(before);
  });

  it('the participating edit preserves existing issued-order refusal and transaction rollback', async () => {
    await sql(
      `UPDATE "SL_ORD_DETL" SET "TAG_GEN"='Y' WHERE tenant_id=$1 AND "CO_BOOK"='C13'`,
      tenantId,
    );
    const input = await edit(),
      before = await exact();
    const response = await request('PUT', path(), input, signed.cookie, page(signed.context), {
      status: 400,
    });
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().message).toMatch(/issued|tagged|delivered|adjusted/);
    expect(await exact()).toEqual(before);
  });

  it('the participating edit preserves saved-date period lock refusal without changing session/config or finance', async () => {
    const input = await edit();
    await sql(
      `UPDATE "CO_SET" SET "LOCK_DATE"='2024-07-10' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    const before = await exact();
    const response = await request('PUT', path(), input, signed.cookie, page(signed.context), {
      status: 400,
    });
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json().error).toBe('PeriodLockValidationError');
    expect(await exact()).toEqual(before);
  });

  it('exact stored-year validation cannot fall back to another configured year inside a financial command', async () => {
    const input = await edit();
    await sql(`DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"='01'`, tenantId);
    await sql(
      `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,'01','2025-2026','2025-04-01','2026-03-31')`,
      tenantId,
    );
    const before = await exact();
    await expect(command(input)).rejects.toMatchObject({
      code: 'year-unavailable',
      statusCode: 409,
    });
    expect(await exact()).toEqual(before);
  });

  it('two real same-session edits with one document version commit one125 advance and one domain conflict', async () => {
    const input = await edit(),
      before = await footprint('100');
    const protectedBefore = await physical(protectedTables),
      sibling = await physical(orderTables, 'C14');
    const outcomes = await Promise.all([
      settle(command(input)),
      settle(command(structuredClone(input))),
    ]);
    expect(outcomes.filter((value) => value.status === 'fulfilled')).toHaveLength(1);
    const failed = outcomes.filter((value) => value.status === 'rejected');
    expect(failed).toHaveLength(1);
    expect(failed[0]).toMatchObject({
      reason: { name: 'SalesOrderConflictError' },
    });
    await expectAdvanceOnly(before);
    expect(await physical(protectedTables)).toEqual(protectedBefore);
    expect(await physical(orderTables, 'C14')).toEqual(sibling);
  });
});
