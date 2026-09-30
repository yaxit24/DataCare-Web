import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * N18 over HTTP, on a company created by web provisioning — which now carries the desktop's TR_TAG_CAN books
 * (TGC `TAG CANCEL` / TGCAN and TTR `TAG TRFR` / TAGTR, both numbering from BAR_CAN_DATA).
 *
 * The desktop menus "Tag Cancel" and "Tag Transfer" open the same form under their own right
 * (MDI_FORM.cs:8586, :8664), so each route family answers to its own right here too, and the released
 * operations run through authentication, RBAC, business scope and the writer — no containment.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tag-cancel-route-db';
const PASSWORD = 'Tag-Cancel-Route!2026';
const SECRET = 'tag-cancel-route-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const TAG = 'LRG00001';
const SRNO = 100312000009;

(enabled ? describe : describe.skip)('N18 tag cancel and tag transfer through HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  const cookies: Record<string, string> = {};
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const query = <T>(sql: string, ...params: unknown[]) =>
    owner.$queryRawUnsafe(sql, ...params) as Promise<T>;
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const request = (
    login: string,
    method: 'GET' | 'POST' | 'PUT' | 'DELETE',
    url: string,
    payload?: unknown,
  ) =>
    app.inject({
      method,
      url,
      headers: { cookie: cookies[login] ?? '' },
      ...(payload === undefined ? {} : { payload: payload as any }),
    });
  const login = async (name: string, rights: string[]) => {
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      name,
      await hashPassword(PASSWORD),
    );
    for (const subMenu of rights)
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Other',$3,'Y','Y','Y','Y')`,
        tenantId,
        name,
        subMenu,
      );
  };
  const balance = async (tagNo: string, itCode?: string): Promise<number> => {
    const [row] = await query<Array<{ bal: number }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS bal FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"=$2 AND ($3::text IS NULL OR "IT_CODE"=$3)`,
      tenantId,
      tagNo,
      itCode ?? null,
    );
    return Number(row?.bal ?? 0);
  };

  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('tag cancel route fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
       VALUES ($1,'01','LR916','L RING 916','G','LR','G'),($1,'01','OG','OLD GOLD','G','OG','G')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","KR_NET_WT","KR_TOUCH","KR_FINE","TBL_CODE","KR_NAME",
         "PR_CODE","IT_TYPE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'PURCHASE','I',$4,$5,'LR916',1,12.3,12.3,
               92,5,11.931,12.3,92,11.316,'001','KJ','LR','G','N')`,
      tenantId,
      YEAR,
      DAY,
      TAG,
      SRNO,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'LR916',$4,$5,'P','+',1,1,12.3,12.3)`,
      tenantId,
      YEAR,
      DAY,
      TAG,
      SRNO,
    );
    await login('canceller', ['Tag Cancel']);
    await login('transferrer', ['Tag Transfer']);
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const name of ['canceller', 'transferrer']) {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': tenantId },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const value = response.headers['set-cookie'];
      cookies[name] = (Array.isArray(value) ? value : [value ?? ''])
        .map((part) => part.split(';', 1)[0])
        .join('; ');
    }
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('keeps each menu to its own right', async () => {
    const cancelAsTransferrer = await request('transferrer', 'POST', '/stock/tag-cancel', {
      coBook: 'TGC',
      vchDate: DAY,
      lines: [{ tagNo: TAG }],
    });
    expect(cancelAsTransferrer.statusCode, cancelAsTransferrer.body).toBe(403);
    const listAsCanceller = await request('canceller', 'GET', '/stock/tag-transfer?coBook=TTR');
    expect(listAsCanceller.statusCode, listAsCanceller.body).toBe(403);
    expect(await balance(TAG)).toBe(1);
  });

  it('refuses a book of the other menu with a clear 400', async () => {
    const response = await request('canceller', 'POST', '/stock/tag-cancel', {
      coBook: 'TTR',
      vchDate: DAY,
      lines: [{ tagNo: TAG }],
    });
    expect(response.statusCode, response.body).toBe(400);
    expect(response.json()).toMatchObject({
      error: 'TagCancelValidationError',
      message: 'book TTR is TAG TRFR, not TAG CANCEL — use Tag Transfer',
    });
  });

  it('runs the whole Tag Cancel lifecycle on the provisioned TGC book', async () => {
    const source = await request(
      'canceller',
      'GET',
      `/stock/tag-cancel/source?coBook=TGC&tagNo=${TAG}`,
    );
    expect(source.statusCode, source.body).toBe(200);
    expect(source.json()).toMatchObject({
      tagNo: TAG,
      vchSrno: SRNO,
      source: 'BAR_DETL',
      itName: 'L RING 916',
      line: { itCode: 'LR916', netWt: 12.3, fine: 11.931, krNetWt: 12.3, krName: 'KJ' },
    });

    const created = await request('canceller', 'POST', '/stock/tag-cancel', {
      coBook: 'TGC',
      vchDate: DAY,
      vchDesc: 'broken hook',
      lines: [{ tagNo: TAG }],
    });
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json()).toMatchObject({ vchNo: 1, voucherNo: '00001', lines: 1, stockRows: 1 });
    expect(await balance(TAG)).toBe(0);

    const read = await request('canceller', 'GET', '/stock/tag-cancel/00001?coBook=TGC');
    expect(read.statusCode, read.body).toBe(200);
    const view = read.json();
    expect(view).toMatchObject({
      mode: 'cancel',
      voucherNo: '00001',
      vchDesc: 'BROKEN HOOK',
      mainUser: 'canceller',
      book: { code: 'TGC', shortName: 'TGCAN', mainBook: 'TAG CANCEL' },
    });
    expect(view.lines).toHaveLength(1);
    expect(view.lines[0]).toMatchObject({ tagNo: TAG, vchSrno: SRNO, oldSrNo: 1, fine: 11.931 });

    const [stock] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE","BOOK_NAME","TR_TYPE","ITM_SIGN","DATA_TYPE" FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "CO_BOOK"='TGC'`,
      tenantId,
    );
    expect(stock).toEqual({
      VCH_TYPE: 'TGCAN',
      BOOK_NAME: 'TAG CANCEL',
      TR_TYPE: 'O',
      ITM_SIGN: '-',
      DATA_TYPE: 'A',
    });

    // Reopen and save unchanged: every stored figure survives the round trip.
    const updated = await request('canceller', 'PUT', '/stock/tag-cancel/00001', {
      coBook: 'TGC',
      vchDate: DAY,
      vchDesc: view.vchDesc,
      lines: view.lines.map((line: Record<string, unknown>) => ({
        tagNo: line.tagNo,
        vchSrno: line.vchSrno,
        oldSrNo: line.oldSrNo,
        itCode: line.itCode,
        grossWt: line.grossWt,
        netWt: line.netWt,
        touch: line.touch,
        westPct: line.westPct,
        fine: line.fine,
        krNetWt: line.krNetWt,
        krFine: line.krFine,
      })),
    });
    expect(updated.statusCode, updated.body).toBe(200);
    const reread = (await request('canceller', 'GET', '/stock/tag-cancel/00001?coBook=TGC')).json();
    expect(reread.lines).toEqual(view.lines);
    expect(reread.hiddenVoucherNo).toBe(view.hiddenVoucherNo);

    const list = await request('canceller', 'GET', '/stock/tag-cancel?coBook=TGC');
    expect(list.statusCode, list.body).toBe(200);
    expect(list.json()).toMatchObject({
      nextVoucherNo: '00002',
      vouchers: [{ vchNo: '00001', vchDesc: 'BROKEN HOOK', lines: 1 }],
    });

    const again = await request('canceller', 'POST', '/stock/tag-cancel', {
      coBook: 'TGC',
      vchDate: DAY,
      lines: [{ tagNo: TAG }],
    });
    expect(again.statusCode, again.body).toBe(400);
    expect(again.json()).toMatchObject({ error: 'TagNotAvailableError' });

    const removed = await request('canceller', 'DELETE', '/stock/tag-cancel/00001?coBook=TGC');
    expect(removed.statusCode, removed.body).toBe(200);
    expect(removed.json()).toMatchObject({ reversed: true, vchNo: 1, lines: 1 });
    expect(await balance(TAG)).toBe(1);
    const [audit] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE","BOOK_NAME","DELETE_USER","VCH_DESC" FROM "DELETE_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(audit).toEqual({
      VCH_TYPE: 'TGCAN',
      BOOK_NAME: 'Tag Cancel',
      DELETE_USER: 'canceller',
      VCH_DESC: `ItCode/LR916 TagNo/${TAG}`,
    });
  });

  it('runs Tag Transfer on the provisioned TTR book and conserves the metal', async () => {
    const created = await request('transferrer', 'POST', '/stock/tag-transfer', {
      coBook: 'TTR',
      vchDate: DAY,
      lines: [{ tagNo: TAG, trfrItCode: 'OG' }],
    });
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json()).toMatchObject({ vchNo: 1, stockRows: 2, diamondRows: 0 });
    expect(await balance(TAG)).toBe(0);
    const rows = await query<Array<Record<string, unknown>>>(
      `SELECT "ISR_NO","IT_CODE","TAG_NO","ITM_SIGN","TR_TYPE","VCH_TYPE",
              "ITM_PCS"::float8 pcs,"ITM_GWT"::float8 gwt,"ITM_NWT"::float8 nwt,"ITM_FINE"::float8 fine
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='TTR' ORDER BY "ISR_NO"`,
      tenantId,
    );
    expect(rows).toEqual([
      {
        ISR_NO: 1,
        IT_CODE: 'LR916',
        TAG_NO: TAG,
        ITM_SIGN: '-',
        TR_TYPE: 'O',
        VCH_TYPE: 'TAGTR',
        pcs: 1,
        gwt: 12.3,
        nwt: 12.3,
        fine: 11.931,
      },
      {
        ISR_NO: 2,
        IT_CODE: 'OG',
        TAG_NO: 'N',
        ITM_SIGN: '+',
        TR_TYPE: 'I',
        VCH_TYPE: 'TAGTR',
        pcs: 1,
        gwt: 12.3,
        nwt: 12.3,
        fine: 11.931,
      },
    ]);

    const missing = await request('transferrer', 'PUT', '/stock/tag-transfer/00001', {
      coBook: 'TTR',
      vchDate: DAY,
      lines: [{ tagNo: TAG, oldSrNo: 1, trfrItCode: '' }],
    });
    expect(missing.statusCode, missing.body).toBe(400);
    expect(missing.json().message).toBe('row 1: enter the transfer item (TrfrItm)');
    // The refused edit changed nothing.
    expect(await balance(TAG)).toBe(0);
    expect(await balance('N', 'OG')).toBe(1);

    const removed = await request('transferrer', 'DELETE', '/stock/tag-transfer/00001?coBook=TTR');
    expect(removed.statusCode, removed.body).toBe(200);
    expect(await balance(TAG)).toBe(1);
    expect(await balance('N', 'OG')).toBe(0);
  });

  it('reports a deadlock with another writer as 409 Conflict, writes nothing and uses no number', async () => {
    const SECOND = 'LRG00002';
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_FINE","TBL_CODE","PR_CODE","IT_TYPE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',2,2,$3::date,'PURCHASE','I',$4,$5,'LR916',1,5,5,92,4.6,'001','LR','G','N')`,
      tenantId,
      YEAR,
      DAY,
      SECOND,
      SRNO + 1,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',2,1,$3::date,'LR916',$4,$5,'P','+',1,1,5,5)`,
      tenantId,
      YEAR,
      DAY,
      SECOND,
      SRNO + 1,
    );
    // K2.6: the save locks its tags in sorted order under the resolver's key, so it takes TAG and then waits for
    // SECOND. Another writer that holds SECOND and then asks for TAG closes a cycle PostgreSQL must break.
    const key = (tagNo: string) => `tag-issue|01|01|${tagNo}`;
    const waitingFor = async (tagNo: string) =>
      Number(
        (
          await query<Array<{ n: number }>>(
            `SELECT count(*)::int AS n FROM pg_locks
              WHERE locktype='advisory' AND NOT granted AND objsubid=1
                AND objid::bigint = (hashtext($1)::bigint & 4294967295)`,
            key(tagNo),
          )
        )[0]!.n,
      );
    let holding!: () => void;
    const held = new Promise<void>((resolve) => {
      holding = resolve;
    });
    const other = owner.$transaction(
      async (tx) => {
        // The deadlock detector runs in whichever waiter reaches deadlock_timeout first and aborts
        // THAT transaction. Give this helper a longer timeout than the server's default so the save
        // under test is always the victim; otherwise a loaded runner can abort this helper instead.
        await tx.$executeRawUnsafe("SET LOCAL deadlock_timeout = '10s'");
        await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', key(SECOND));
        holding();
        for (let i = 0; i < 400 && (await waitingFor(SECOND)) === 0; i++)
          await new Promise((resolve) => setTimeout(resolve, 25));
        await tx.$executeRawUnsafe('SELECT pg_advisory_xact_lock(hashtext($1))', key(TAG));
      },
      { maxWait: 10_000, timeout: 30_000 },
    );
    await held;
    const response = await request('canceller', 'POST', '/stock/tag-cancel', {
      coBook: 'TGC',
      vchDate: DAY,
      lines: [{ tagNo: TAG }, { tagNo: SECOND }],
    });
    await other;
    // The save was the deadlock's victim: a conflict to retry, not a 500 and not a data error.
    expect(response.statusCode, response.body).toBe(409);
    expect(response.json()).toMatchObject({ error: 'TagCancelConflictError' });
    expect(await balance(TAG)).toBe(1);
    expect(await balance(SECOND)).toBe(1);
    for (const table of ['BAR_CAN_DATA', 'BAR_CAN_DETL', 'TEMP_BOOK_DATA'])
      expect(
        await query(`SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='TGC'`, tenantId),
        table,
      ).toEqual([]);
    // Retried, it succeeds on the number the failed attempt did not use.
    const retried = await request('canceller', 'POST', '/stock/tag-cancel', {
      coBook: 'TGC',
      vchDate: DAY,
      lines: [{ tagNo: TAG }, { tagNo: SECOND }],
    });
    expect(retried.statusCode, retried.body).toBe(201);
    expect(retried.json()).toMatchObject({ voucherNo: '00001', lines: 2 });
    const removed = await request('canceller', 'DELETE', '/stock/tag-cancel/00001?coBook=TGC');
    expect(removed.statusCode, removed.body).toBe(200);
    expect(await balance(TAG)).toBe(1);
    expect(await balance(SECOND)).toBe(1);
  }, 60_000);
});
