import { createHash, randomUUID } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { PrismaClient, type Prisma } from '@prisma/client';
import type { Tx } from '@datacare/db';
import { afterAll, afterEach, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  createSalesOrder,
  createSalesOrderInSession,
  createTourOrderInSession,
  cancelSalesOrderInSession,
  cancelTourOrderInSession,
  editTourOrderInSession,
  getSalesOrder,
  getTourOrder,
  type SalesOrderInput,
} from '../src/modules/sales/salesOrder.js';
import { selectSessionContext } from '../src/modules/auth/sessionContextSelection.js';
import type { SessionCommandIdentity } from '../src/modules/auth/sessionContextCommand.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'next-order-command',
  foreignTenant = 'next-order-foreign';
const sid = '11111111-1111-4111-8111-111111111111';
const identity: SessionCommandIdentity = {
  tenantId,
  sessionId: sid,
  loginName: 'operator',
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  contextEpoch: '7',
};
const ledger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
};
const families = ['sales', 'tour'] as const;
type Family = (typeof families)[number];
type Raw = Record<string, string | null>;
type Physical = { raw: string; revision: string; locator: string };
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
  'CO_SET',
  'CO_SET_NEW',
  'LOGIN_MAST',
  'USER_SET',
  'BOOK_DATA',
  'AC_MAST',
  'ITEM_MAST',
  'SRNO_MAST',
] as const;
const tables = [...orderTables, ...protectedTables];
const bytes = readFileSync(new URL('./fixtures/orderCommand.independent.json', import.meta.url));
const golden = JSON.parse(bytes.toString()) as {
  fixture: {
    vchDate: string;
    clock: string;
    account: string;
    cashAccount: string;
    parents: NonNullable<SalesOrderInput['lines']>;
    taxRatePct: number;
    advance: number;
    editedAdvance: number;
  };
};
const scope = (book = 'N13') => ({
  tenantId,
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: book,
});
const bookOf = (family: Family) => (family === 'sales' ? 'N13' : 'N14');
const input = (family: Family): SalesOrderInput => ({
  scope: scope(bookOf(family)),
  mainUser: 'original',
  acCode: golden.fixture.account,
  acName: 'Customer',
  cashAc: golden.fixture.cashAccount,
  vchDate: golden.fixture.vchDate,
  vchTime: golden.fixture.clock,
  taxRatePct: golden.fixture.taxRatePct,
  advanceAmount: golden.fixture.advance,
  lines: structuredClone(golden.fixture.parents),
});
const gate = () => {
  let release!: () => void;
  const promise = new Promise<void>((done) => {
    release = done;
  });
  return { promise, release };
};
const settle = <T>(promise: Promise<T>) =>
  promise.then(
    (value) => ({ value, error: undefined }),
    (error: unknown) => ({ value: undefined, error }),
  );
const awaitGate = <T>(
  barrier: Promise<void>,
  operation: Promise<{ value: T | undefined; error: unknown }>,
) =>
  Promise.race([
    barrier,
    operation.then((outcome) => {
      throw outcome.error ?? new Error('operation ended before test gate');
    }),
  ]);

db('remaining five order session commands on isolated PostgreSQL', () => {
  let owner: PrismaClient, runtime: PrismaClient, actor: PrismaClient;
  const commandName = 'order-next-' + randomUUID(),
    actorName = 'order-next-actor-' + randomUUID();
  let foreignBefore: Record<string, Physical[]> | undefined;
  let siblingBefore: Record<string, Physical[]> | undefined;
  let protectedBefore: Record<string, Physical[]> | undefined;
  const allowedProtectedChanges = new Set<string>();
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const clean = async () => {
    for (const table of tables)
      await sql('DELETE FROM "' + table + '" WHERE tenant_id=ANY($1::text[])', [
        tenantId,
        foreignTenant,
      ]);
  };
  const physical = async (
    selected: readonly string[] = tables,
    tenants = [tenantId, foreignTenant],
    book?: string,
  ) => {
    const rows: Record<string, Physical[]> = {};
    for (const table of selected)
      rows[table] = await owner.$queryRawUnsafe<Physical[]>(
        'SELECT to_jsonb(t)::text AS raw,xmin::text AS revision,ctid::text AS locator FROM "' +
          table +
          '" t WHERE tenant_id=ANY($1::text[])' +
          (book ? ' AND "CO_BOOK"=$2' : '') +
          ' ORDER BY to_jsonb(t)::text',
        tenants,
        ...(book ? [book] : []),
      );
    return rows;
  };
  const raw = async (table: (typeof orderTables)[number], book: string) => {
    const rows = await owner.$queryRawUnsafe<Array<{ raw: Raw }>>(
      'SELECT (SELECT jsonb_object_agg(j.key,j.value) FROM jsonb_each_text(to_jsonb(t)) j) raw FROM "' +
        table +
        '" t WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY to_jsonb(t)::text',
      tenantId,
      book,
    );
    return rows.map((row) => row.raw);
  };
  const read = (family: Family, no = 1) =>
    family === 'sales'
      ? getSalesOrder(runtime, scope(bookOf(family)), no)
      : getTourOrder(runtime, scope(bookOf(family)), no);
  const create = (family: Family, client = runtime, body = input(family)) =>
    family === 'sales'
      ? createSalesOrderInSession(client, { identity, input: body })
      : createTourOrderInSession(client, { identity, input: body });
  const cancel = async (family: Family, client = runtime, expectedVersion?: string) => {
    const version = expectedVersion ?? ((await read(family)).version as string);
    const request = {
      identity,
      input: {
        scope: scope(bookOf(family)),
        vchNo: 1,
        expectedVersion: version,
        deleteUser: 'operator',
      },
    };
    return family === 'sales'
      ? cancelSalesOrderInSession(client, request)
      : cancelTourOrderInSession(client, request);
  };
  const tourEdit = async () => {
    const saved = await read('tour');
    return {
      ...(saved as unknown as SalesOrderInput),
      scope: scope('N14'),
      expectedVersion: saved.version as string,
      advanceAmount: 40,
      cashAc: 'CASH',
    };
  };
  const select = (signAccess = async () => 'local-test-token') =>
    selectSessionContext(
      actor,
      {
        identity,
        request: {
          coCode: '02',
          lcCode: '01',
          coYear: '2024-2025',
          expectedContextEpoch: '7',
          selectionId: '22222222-2222-4222-8222-222222222222',
        },
      },
      { signAccess },
    );
  const waitForLock = async (name: string) => {
    const until = Date.now() + 3000;
    while (Date.now() < until) {
      const rows = await owner.$queryRawUnsafe<Array<{ waiting: boolean }>>(
        `SELECT EXISTS(SELECT 1 FROM pg_stat_activity WHERE application_name=$1 AND wait_event_type='Lock') waiting`,
        name,
      );
      if (rows[0]?.waiting) return;
      await new Promise((resolve) => setTimeout(resolve, 10));
    }
    throw new Error('expected actual lock wait for ' + name);
  };
  /** Test-only proxy still executes every SQL statement on the same real transaction. */
  const instrument = (before: (statement: string, tx: Tx) => Promise<void>): PrismaClient =>
    ({
      $transaction: <T>(
        work: (tx: Tx) => Promise<T>,
        options?: {
          isolationLevel?: Prisma.TransactionIsolationLevel;
          timeout?: number;
          maxWait?: number;
        },
      ) =>
        runtime.$transaction(async (tx) => {
          const proxy = new Proxy(tx, {
            get(target, property, receiver) {
              if (property === '$queryRawUnsafe' || property === '$executeRawUnsafe')
                return async (statement: string, ...values: unknown[]) => {
                  await before(statement, tx);
                  return Reflect.apply(Reflect.get(target, property), target, [
                    statement,
                    ...values,
                  ]);
                };
              return Reflect.get(target, property, receiver);
            },
          });
          return work(proxy);
        }, options),
    }) as unknown as PrismaClient;
  const assertFinance = async (family: Family, advance = 25, count = 1) => {
    const book = bookOf(family);
    const headers = await raw('SL_ORD_DATA', book);
    expect(headers).toHaveLength(count);
    for (const header of headers) {
      expect(header.TOT_AMT).toBe('260.00');
      expect(header.ADV_AMT).toBe(String(advance));
      expect(header.CO_YEAR).toBe('2024-2025');
      expect(header.AC_CODE).toBe('PARTY');
    }
    const legs = await raw('AC_DATA', book);
    expect(legs).toHaveLength(2 * count);
    for (const header of headers) {
      const pair = legs
        .filter((row) => row.VCH_NO === header.VCH_NO)
        .sort((a, b) => String(a.AC_CODE).localeCompare(String(b.AC_CODE)));
      expect(pair.map(({ AC_CODE, DR_AMT, CR_AMT }) => ({ AC_CODE, DR_AMT, CR_AMT }))).toEqual([
        { AC_CODE: 'CASH', DR_AMT: advance.toFixed(2), CR_AMT: '0.00' },
        { AC_CODE: 'PARTY', DR_AMT: '0.00', CR_AMT: advance.toFixed(2) },
      ]);
    }
    const rojmel = await raw('ROJ_MEL_DATA', book);
    expect(rojmel).toHaveLength(count);
    for (const row of rojmel)
      expect(row).toMatchObject({
        AC_CODE: 'PARTY',
        LD_CODE: 'CASH',
        DR_AMT: '0.00',
        CR_AMT: advance.toFixed(2),
      });
    const parents = await raw('SL_ORD_DETL', book);
    expect(parents).toHaveLength(2 * count);
    expect(parents.map((row) => [row.SR_NO, row.NET_AMT]).sort()).toEqual(
      Array.from({ length: count }, () => [
        ['7', '200.00'],
        ['19', '60.00'],
      ])
        .flat()
        .sort(),
    );
    const children = await raw('SL_ORD_IDTL', book);
    expect(children).toHaveLength(2 * count);
    for (const header of headers)
      expect(
        children
          .filter((row) => row.VCH_NO === header.VCH_NO)
          .map(({ SR_NO, ISR_NO, IT_CODE, IT_AMT }) => ({ SR_NO, ISR_NO, IT_CODE, IT_AMT }))
          .sort((a, b) => Number(a.ISR_NO) - Number(b.ISR_NO)),
      ).toEqual([
        { SR_NO: '7', ISR_NO: '3', IT_CODE: 'STN1', IT_AMT: '11.00' },
        { SR_NO: '7', ISR_NO: '13', IT_CODE: 'STN2', IT_AMT: '13.00' },
      ]);
  };

  beforeAll(() => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'c6f86ef10f4f948c570e417f4f1a0336df196fb1085b2028c1f79a1e432c979e',
    );
    for (const key of ['DATABASE_URL', 'MIGRATE_DATABASE_URL'] as const) {
      const url = new URL(process.env[key] ?? '');
      if (
        url.port !== '55433' ||
        (key === 'DATABASE_URL' && decodeURIComponent(url.username) !== 'app_user')
      )
        throw new Error('isolated55433/app_user wrapper required');
    }
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
    });
    const url = new URL(process.env.DATABASE_URL!);
    url.searchParams.set('application_name', commandName);
    runtime = new PrismaClient({ datasources: { db: { url: url.toString() } } });
    url.searchParams.set('application_name', actorName);
    actor = new PrismaClient({ datasources: { db: { url: url.toString() } } });
  });
  beforeEach(async () => {
    foreignBefore = siblingBefore = protectedBefore = undefined;
    allowedProtectedChanges.clear();
    await clean();
    for (const co of ['01', '02']) {
      await sql(
        `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","LC_CODE") VALUES($1,$2,'01')`,
        tenantId,
        co,
      );
      await sql(
        `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE") VALUES($1,$2,'01')`,
        tenantId,
        co,
      );
      await sql(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE") VALUES($1,$2,'2024-2025','2024-04-01','2025-03-31')`,
        tenantId,
        co,
      );
      await sql(
        `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LOCK_DATE","LAST_DAY_LOCK","LBR_ROF","ALL_ROF_REMOVE") VALUES($1,$2,NULL,'N',2,'N')`,
        tenantId,
        co,
      );
      await sql(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","LBR_WITH_GHT") VALUES($1,$2,'N')`,
        tenantId,
        co,
      );
      await sql(
        `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","PASSWORD_RESET_REQUIRED") VALUES($1,$2,'operator','fixture','USER','N')`,
        tenantId,
        co,
      );
    }
    await sql(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE") VALUES($1,'01','01','operator','Sales','Sales Order','Y','Y','Y'),($1,'01','01','operator','Karigar','Tour Order','Y','Y','Y')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","MAIN_BOOK","BOOK_INOUT","BOOK_SNAME","BOOK_NAME","CUR_USE","BOOK_TBL_NAME") VALUES($1,'01','01','N13','SALES ORDER','O','SORD','Next Sales','Y','SL_ORD_DATA'),($1,'01','01','N14','TOUR ORDER','I','TUROD','Next Tour','Y','SL_ORD_DATA'),($1,'01','01','N15','SALES ORDER','O','SORD','Sibling','Y','SL_ORD_DATA')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,'01','01','PARTY','Customer'),($1,'01','01','CASH','Cash')`,
      tenantId,
    );
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE") VALUES($1,'01','GOLD','Gold','G'),($1,'01','SILVR','Silver','S'),($1,'01','STN1','Stone1','D'),($1,'01','STN2','Stone2','D')`,
      tenantId,
    );
    await sql(
      `INSERT INTO auth_session(tenant_id,session_id,login_name,login_co_code,co_code,lc_code,co_year,refresh_jti_hash,created_at,last_used_at,expires_at,context_epoch,ledger_context) VALUES($1,$2,'operator','01','01','01','2024-2025',$3,'2020-01-01 00:00:00.123456+00','2020-01-01 00:00:00.123456+00',clock_timestamp()+interval '1 hour',7,$4::jsonb)`,
      tenantId,
      sid,
      'a'.repeat(64),
      JSON.stringify(ledger),
    );
    await sql(
      `INSERT INTO "AC_DATA"(tenant_id,"LEDR_KEY","CO_CODE","CO_BOOK","CR_AMT","DR_AMT","ENTRY_TIME") VALUES($1,'next-order-foreign-sentinel','01','N13',90071992547409.91,NULL,'2024-07-10 01:02:03.123456')`,
      foreignTenant,
    );
    await createSalesOrder(runtime, { ...input('sales'), scope: scope('N15') });
    foreignBefore = await physical(tables, [foreignTenant]);
    siblingBefore = await physical(orderTables, [tenantId], 'N15');
    protectedBefore = await physical(protectedTables);
  });
  afterEach(async () => {
    if (foreignBefore) expect(await physical(tables, [foreignTenant])).toEqual(foreignBefore);
    if (siblingBefore)
      expect(await physical(orderTables, [tenantId], 'N15')).toEqual(siblingBefore);
    if (protectedBefore) {
      const after = await physical(protectedTables);
      for (const table of protectedTables)
        if (!allowedProtectedChanges.has(table))
          expect(after[table]).toEqual(protectedBefore[table]);
    }
  });
  afterAll(async () => {
    if (owner) await clean();
    if (runtime) await runtime.$disconnect();
    if (actor) await actor.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it.each(families)(
    '%s create writes literal260 total and25 advance with all parent/child identities',
    async (family) => {
      expect(await create(family)).toMatchObject({ vchNo: 1, total: 260, advance: 25 });
      await assertFinance(family);
      const saved = await read(family);
      expect(saved).toMatchObject({
        voucherNo: '00001',
        hiddenVoucherNo: '00001',
        mainUser: 'original',
      });
      const stamps = await raw('SL_ORD_DETL', bookOf(family));
      for (const row of stamps)
        expect(row).toMatchObject({
          VCH_TYPE: family === 'sales' ? 'SORD' : 'TUROD',
          INOUT_TYPE: family === 'sales' ? 'O' : 'I',
          BOOK_NAME: family === 'sales' ? 'SALES ORDER' : 'TOUR ORDER',
        });
    },
  );
  it('Tour exact loaded decimal replaces25 with40 while retaining NULL, clock and children', async () => {
    await create('tour');
    await sql(
      `UPDATE "SL_ORD_DATA" SET "MOBILE"=NULL,"ENTRY_TIME"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='N14'`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_DETL" SET "BAG_WT"=NULL,"ITM_MRP"=999999999999999.99 WHERE tenant_id=$1 AND "CO_BOOK"='N14'`,
      tenantId,
    );
    await sql(
      `UPDATE "SL_ORD_IDTL" SET "KR_RATE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"='N14' AND "ISR_NO"=3`,
      tenantId,
    );
    const beforeParents = (await raw('SL_ORD_DETL', 'N14')).map(({ row_id: _id, ...row }) => row);
    const beforeChildren = (await raw('SL_ORD_IDTL', 'N14')).map(({ row_id: _id, ...row }) => row);
    const body = await tourEdit();
    // The Tour read projection now retains the exact saved input value directly.
    for (const line of body.lines ?? []) {
      const original = beforeParents.find((row) => row.SR_NO === String(line.srNo));
      expect(original?.ITM_MRP).toBe('999999999999999.99');
      expect(line.mrp).toBe(original!.ITM_MRP);
    }
    await editTourOrderInSession(runtime, { identity, input: body, voucherNo: 1 });
    await assertFinance('tour', 40);
    expect((await raw('SL_ORD_DETL', 'N14')).map(({ row_id: _id, ...row }) => row)).toEqual(
      beforeParents,
    );
    expect((await raw('SL_ORD_IDTL', 'N14')).map(({ row_id: _id, ...row }) => row)).toEqual(
      beforeChildren,
    );
    const header = (await raw('SL_ORD_DATA', 'N14'))[0]!;
    expect(header.MOBILE).toBeNull();
    expect(header.ENTRY_TIME).toBeNull();
    expect(header.VCH_TIME).toBe('2024-07-10T09:10:11.123456');
  });
  it.each(families)(
    '%s cancel removes all saved rows and records the original40 advance; highest number is reusable',
    async (family) => {
      await create(family, runtime, { ...input(family), advanceAmount: 40 });
      await cancel(family);
      for (const table of orderTables.filter((table) => table !== 'DELETE_DATA'))
        expect(await raw(table, bookOf(family))).toEqual([]);
      const evidence = await raw('DELETE_DATA', bookOf(family));
      expect(evidence).toHaveLength(1);
      expect(evidence[0]).toMatchObject({
        VCH_NO: '00001',
        HD_VCH_NO: '00001',
        VCH_VAL_DR: '0',
        VCH_VAL_CR: '40',
        MAIN_USER: 'original',
        DELETE_USER: 'operator',
      });
      expect((await create(family)).vchNo).toBe(1);
      expect(await raw('DELETE_DATA', bookOf(family))).toEqual(evidence);
    },
  );
  it.each(['sales-cancel', 'tour-cancel', 'tour-edit'] as const)(
    '%s rejects missing and malformed versions without changing saved rows',
    async (entry) => {
      const family = entry.startsWith('sales') ? 'sales' : 'tour';
      await create(family);
      const before = await physical();
      for (const value of [undefined, '', 'a'.repeat(64) + '\n']) {
        const request = {
          identity,
          input: { scope: scope(bookOf(family)), vchNo: 1, expectedVersion: value },
        };
        const operation =
          entry === 'tour-edit'
            ? editTourOrderInSession(runtime, {
                identity,
                input: { ...(await tourEdit()), expectedVersion: value },
                voucherNo: 1,
              })
            : family === 'sales'
              ? cancelSalesOrderInSession(runtime, request)
              : cancelTourOrderInSession(runtime, request);
        await expect(operation).rejects.toMatchObject({ name: 'SaleValidationError' });
      }
      expect(await physical()).toEqual(before);
    },
  );
  it.each(families)(
    '%s cancellation rejects a supplied stale version and retains all current rows',
    async (family) => {
      await create(family);
      const prior = (await read(family)).version as string;
      await sql(
        'UPDATE "SL_ORD_DATA" SET "VCH_DESC"=\'changed elsewhere\' WHERE tenant_id=$1 AND "CO_BOOK"=$2',
        tenantId,
        bookOf(family),
      );
      const before = await physical();
      await expect(cancel(family, runtime, prior)).rejects.toMatchObject({
        name: 'SalesOrderConflictError',
      });
      expect(await physical()).toEqual(before);
    },
  );
  it.each(families)(
    '%s create rolls back real TEMP insertion and allocation on a subsequent injected failure',
    async (family) => {
      const before = await physical();
      let injected = false;
      const client = instrument(async (statement) => {
        if (statement.startsWith('INSERT INTO "SL_ORD_DATA"')) {
          injected = true;
          throw new Error('after-real-temp-before-header');
        }
      });
      await expect(create(family, client)).rejects.toThrow('after-real-temp-before-header');
      expect(injected).toBe(true);
      expect(await physical()).toEqual(before);
      expect((await create(family)).vchNo).toBe(1);
    },
  );
  it.each(families)(
    '%s DELETE_DATA failure after real deletes restores the whole saved financial footprint',
    async (family) => {
      await create(family);
      const before = await physical();
      let injected = false;
      const client = instrument(async (statement) => {
        if (statement.startsWith('INSERT INTO "DELETE_DATA"')) {
          injected = true;
          throw new Error('cancel-evidence-failure');
        }
      });
      await expect(cancel(family, client)).rejects.toThrow('cancel-evidence-failure');
      expect(injected).toBe(true);
      expect(await physical()).toEqual(before);
    },
  );
  it.each(['sales-create', 'tour-create', 'sales-cancel', 'tour-cancel', 'tour-edit'] as const)(
    '%s final expiry refusal rolls back all real financial statements and the injected local clock change',
    async (entry) => {
      const family = entry.startsWith('sales') ? 'sales' : 'tour';
      if (!entry.endsWith('create')) await create(family);
      const edit = entry === 'tour-edit' ? await tourEdit() : undefined;
      const version = entry.endsWith('cancel')
        ? ((await read(family)).version as string)
        : undefined;
      const before = await physical();
      let injected = false;
      const client = instrument(async (statement, tx) => {
        if (statement.includes('AS "ledgerContext"') && statement.includes('clock_timestamp()')) {
          injected = true;
          await tx.$executeRawUnsafe(
            `UPDATE auth_session SET expires_at=clock_timestamp()-interval '1 microsecond' WHERE tenant_id=$1 AND session_id=$2`,
            tenantId,
            sid,
          );
        }
      });
      const operation = entry.endsWith('create')
        ? create(family, client)
        : edit
          ? editTourOrderInSession(client, { identity, input: edit, voucherNo: 1 })
          : cancel(family, client, version);
      await expect(operation).rejects.toMatchObject({ code: 'session-expired' });
      expect(injected).toBe(true);
      expect(await physical()).toEqual(before);
    },
  );
  it.each(families)(
    '%s concurrent creates retain number allocation locks and commit two distinct25 postings',
    async (family) => {
      const results = await Promise.all([create(family), create(family)]);
      expect(results.map((row) => row.vchNo).sort()).toEqual([1, 2]);
      await assertFinance(family, 25, 2);
      expect((await raw('TEMP_BOOK_DATA', bookOf(family))).map((row) => row.VCH_NO).sort()).toEqual(
        ['00001', '00002'],
      );
    },
  );
  it('concurrent Tour edits with one document version commit one40 replacement and one conflict', async () => {
    await create('tour');
    const body = await tourEdit();
    const outcomes = await Promise.all([
      settle(editTourOrderInSession(runtime, { identity, input: body, voucherNo: 1 })),
      settle(editTourOrderInSession(runtime, { identity, input: body, voucherNo: 1 })),
    ]);
    expect(outcomes.filter((row) => row.error === undefined)).toHaveLength(1);
    expect(outcomes.find((row) => row.error !== undefined)?.error).toMatchObject({
      name: 'SalesOrderConflictError',
    });
    await assertFinance('tour', 40);
  });
  it.each(families)(
    '%s View-only remains allowed to create but fresh missing Delete refuses cancellation',
    async (family) => {
      allowedProtectedChanges.add('USER_SET');
      await sql(
        `UPDATE "USER_SET" SET "FRM_EDIT"='N',"FRM_DELETE"='N' WHERE tenant_id=$1`,
        tenantId,
      );
      await create(family);
      const before = await physical();
      await expect(cancel(family)).rejects.toMatchObject({
        code: 'forbidden',
        statusCode: 403,
      });
      expect(await physical()).toEqual(before);
    },
  );
  it('Tour missing fresh Edit refuses replacement even when the retained identity was previously allowed', async () => {
    await create('tour');
    const body = await tourEdit();
    allowedProtectedChanges.add('USER_SET');
    await sql(`UPDATE "USER_SET" SET "FRM_EDIT"='N' WHERE tenant_id=$1`, tenantId);
    const before = await physical();
    await expect(
      editTourOrderInSession(runtime, { identity, input: body, voucherNo: 1 }),
    ).rejects.toMatchObject({ code: 'forbidden', statusCode: 403 });
    expect(await physical()).toEqual(before);
  });
  it('all five required entries refuse absent identity without any financial change', async () => {
    await create('sales');
    await create('tour');
    const salesVersion = (await read('sales')).version as string;
    const tourVersion = (await read('tour')).version as string;
    const body = await tourEdit();
    const before = await physical();
    const calls = [
      () => createSalesOrderInSession(runtime, { identity: undefined, input: input('sales') }),
      () => createTourOrderInSession(runtime, { identity: undefined, input: input('tour') }),
      () =>
        cancelSalesOrderInSession(runtime, {
          identity: undefined,
          input: { scope: scope(), vchNo: 1, expectedVersion: salesVersion },
        }),
      () =>
        cancelTourOrderInSession(runtime, {
          identity: undefined,
          input: { scope: scope('N14'), vchNo: 1, expectedVersion: tourVersion },
        }),
      () => editTourOrderInSession(runtime, { identity: undefined, input: body, voucherNo: 1 }),
    ];
    for (const call of calls) {
      await expect(call()).rejects.toMatchObject({ code: 'session-invalid' });
      expect(await physical()).toEqual(before);
    }
  });
  it('all five refuse a committed later epoch even when company/location/year remain identical', async () => {
    await create('sales');
    await create('tour');
    const salesVersion = (await read('sales')).version as string;
    const tourVersion = (await read('tour')).version as string;
    const body = await tourEdit();
    allowedProtectedChanges.add('auth_session');
    await sql(
      `UPDATE auth_session SET context_epoch=9 WHERE tenant_id=$1 AND session_id=$2`,
      tenantId,
      sid,
    );
    const before = await physical();
    const calls = [
      () => create('sales'),
      () => create('tour'),
      () => cancel('sales', runtime, salesVersion),
      () => cancel('tour', runtime, tourVersion),
      () => editTourOrderInSession(runtime, { identity, input: body, voucherNo: 1 }),
    ];
    for (const call of calls) {
      await expect(call()).rejects.toMatchObject({ code: 'context-stale' });
      expect(await physical()).toEqual(before);
    }
  });
  it.each(families)('%s cancel preserves the existing issued-state refusal', async (family) => {
    await create(family);
    await sql(
      'UPDATE "SL_ORD_DETL" SET "DESIGN_ISU"=\'Y\' WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      bookOf(family),
    );
    const version = (await read(family)).version as string,
      before = await physical();
    await expect(cancel(family, runtime, version)).rejects.toMatchObject({
      name: 'SaleValidationError',
    });
    expect(await physical()).toEqual(before);
  });
  it.each(families)(
    '%s cancel validates the persisted date against the existing period gate',
    async (family) => {
      await create(family);
      const version = (await read(family)).version as string;
      allowedProtectedChanges.add('CO_SET');
      await sql(
        `UPDATE "CO_SET" SET "LOCK_DATE"='2024-07-10' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        tenantId,
      );
      const before = await physical();
      await expect(cancel(family, runtime, version)).rejects.toMatchObject({
        name: 'PeriodLockValidationError',
      });
      expect(await physical()).toEqual(before);
    },
  );
  it('selection winning the real session lock refuses an already-started create before allocation', async () => {
    allowedProtectedChanges.add('auth_session');
    const signing = gate(),
      release = gate();
    const selection = settle(
      select(async () => {
        signing.release();
        await release.promise;
        return 'token';
      }),
    );
    let command: ReturnType<typeof settle<Awaited<ReturnType<typeof create>>>> | undefined;
    try {
      await awaitGate(signing.promise, selection);
      command = settle(create('tour'));
      await waitForLock(commandName);
      release.release();
      expect((await selection).error).toBeUndefined();
      expect((await command).error).toMatchObject({ code: 'context-stale' });
      expect(await raw('SL_ORD_DATA', 'N14')).toEqual([]);
      expect(await raw('TEMP_BOOK_DATA', 'N14')).toEqual([]);
    } finally {
      release.release();
      await selection;
      if (command) await command;
    }
  });
  it('selection waits behind a real create before its final check and cannot undo the committed posting', async () => {
    allowedProtectedChanges.add('auth_session');
    const entered = gate(),
      release = gate();
    const client = instrument(async (statement) => {
      if (statement.includes('AS "ledgerContext"') && statement.includes('clock_timestamp()')) {
        entered.release();
        await release.promise;
      }
    });
    const command = settle(create('sales', client));
    let selection: ReturnType<typeof settle<Awaited<ReturnType<typeof select>>>> | undefined;
    try {
      await awaitGate(entered.promise, command);
      selection = settle(select());
      await waitForLock(actorName);
      release.release();
      expect((await command).error).toBeUndefined();
      expect((await selection).value?.session).toMatchObject({
        coCode: '02',
        contextEpoch: '8',
      });
      await assertFinance('sales');
    } finally {
      release.release();
      await command;
      if (selection) await selection;
    }
  });
  it('create captures amounts, clock, scope and complete children before an actual session wait', async () => {
    const entered = gate(),
      release = gate();
    const holder = settle(
      owner.$transaction(async (tx) => {
        await tx.$queryRawUnsafe(
          `SELECT session_id FROM auth_session WHERE tenant_id=$1 AND session_id=$2 FOR UPDATE`,
          tenantId,
          sid,
        );
        entered.release();
        await release.promise;
      }),
    );
    let command: ReturnType<typeof settle<Awaited<ReturnType<typeof create>>>> | undefined;
    try {
      await awaitGate(entered.promise, holder);
      const body = input('tour');
      command = settle(create('tour', runtime, body));
      await waitForLock(commandName);
      body.scope.coBook = 'N15';
      body.advanceAmount = 999;
      body.vchTime = '22:22:22.222222';
      body.lines![0]!.components![0]!.amount = 999;
      body.lines!.splice(1);
      release.release();
      expect((await holder).error).toBeUndefined();
      expect((await command).value).toMatchObject({ advance: 25 });
      await assertFinance('tour');
      expect((await raw('SL_ORD_DATA', 'N14'))[0]!.VCH_TIME).toBe('2024-07-10T09:10:11.123456');
    } finally {
      release.release();
      await holder;
      if (command) await command;
    }
  });
});
