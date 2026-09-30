import { PrismaClient } from '@prisma/client';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';

/**
 * N19 (X20) Tag Split over HTTP, on a company created by web provisioning — which now carries the desktop's
 * TR_TAG_SPLIT book (TSP `TAG SPLIT` / TGSPL, numbering from LBR_DATA, BOOK_DETL slots 5 labour, 6/7 gold DR/CR,
 * 8/9 silver DR/CR). The desktop menu "Tag Split" (MDI_FORM.cs:8686) answers to its own right, so the released
 * routes run through authentication, RBAC, business scope and the writer — no containment.
 *
 * Every expected value is the contract's
 * (parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'tag-split-route-db';
const PASSWORD = 'Tag-Split-Route!2026';
const SECRET = 'tag-split-route-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const TAG = 'RNG00001';
const SRNO = 100319000001;

(enabled ? describe : describe.skip)('N19 tag split through HTTP', () => {
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
         VALUES($1,'01','01',$2,'Inventory',$3,'Y','Y','Y','Y')`,
        tenantId,
        name,
        subMenu,
      );
  };
  /** Signed live balance of a tag instance (a split parent falls to 0; a child rises to 1). */
  const balance = async (tagNo: string): Promise<number> => {
    const [row] = await query<Array<{ bal: number }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS bal FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      tagNo,
    );
    return Number(row?.bal ?? 0);
  };
  const childTags = async (): Promise<Array<{ tag: string; nwt: number; fine: number }>> =>
    query<Array<{ tag: string; nwt: number; fine: number }>>(
      `SELECT "TAG_NO" tag,"ITM_NWT"::float8 nwt,"ITM_FINE"::float8 fine FROM "BAR_DETL"
        WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "SR_NO"`,
      tenantId,
    );

  beforeAll(async () => {
    for (const url of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!url || new URL(url).port !== '55433')
        throw new Error('tag split route fixtures require isolated database 55433');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    // Trade fine on: the ledger's mirror legs (even legs) only write when CO_SET.TRAD_FINE='Y'.
    await exec(
      `UPDATE "CO_SET" SET "TRAD_FINE"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    // A whole ring (parent) and its two half-ring child items, plus an account to absorb a short split.
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","TAG_TYPE","RATE_TYPE")
       VALUES ($1,'01','RNG','RING 916','G','RG','R','G'),($1,'01','RNGH','HALF RING','G','RH','H','G')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME")
       VALUES ($1,'01','01','SPLITAC','Split absorb')`,
      tenantId,
    );
    // The parent tag: a real, live BAR_DETL tag (net 10, fine 9.16).
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","ENTRY_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","KR_NET_WT","KR_TOUCH","KR_FINE","TBL_CODE","DESIGN_NO","ITM_SIZE",
         "KR_NAME","PR_CODE","IT_TYPE","TAG_TYPE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'PURCHASE','I','I',$4,$5,'RNG',1,10,10,
               91.6,0,9.16,10,91.6,9.16,'001','D-1','12','KJ','RG','G','R','N')`,
      tenantId,
      YEAR,
      DAY,
      TAG,
      SRNO,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'RNG',$4,$5,'P','+',1,1,10,10,9.16)`,
      tenantId,
      YEAR,
      DAY,
      TAG,
      SRNO,
    );
    // Provisioning already seeds a SRNO_MAST counter for (01,01); nudge it forward so children get high serials.
    await exec(
      `UPDATE "SRNO_MAST" SET "TAG_SRNO"=5000 WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01'`,
      tenantId,
    );
    await login('splitter', ['Tag Split']);
    await login('editor', ['Tag Split']);
    await login('outsider', ['Tag Cancel']);
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const name of ['splitter', 'editor', 'outsider']) {
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

  it('keeps the screen to its own right', async () => {
    const asOutsider = await request('outsider', 'POST', '/stock/tag-split', {
      coBook: 'TSP',
      vchDate: DAY,
      parents: [{ tagNo: TAG }],
      children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
    });
    expect(asOutsider.statusCode, asOutsider.body).toBe(403);
    const listAsOutsider = await request('outsider', 'GET', '/stock/tag-split?coBook=TSP');
    expect(listAsOutsider.statusCode, listAsOutsider.body).toBe(403);
    expect(await balance(TAG)).toBe(1);
  });

  it('refuses a book that is not a TAG SPLIT book, and a TAG SPLIT book not in use', async () => {
    // A non-TAG-SPLIT book (K1): the writer resolves the book and refuses it before touching stock.
    const wrongKind = await request('splitter', 'POST', '/stock/tag-split', {
      coBook: 'SAJ', // provisioned STOCK ADJUST book
      vchDate: DAY,
      parents: [{ tagNo: TAG }],
      children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
    });
    expect(wrongKind.statusCode, wrongKind.body).toBe(400);
    expect(wrongKind.json().message).toContain('is STOCK ADJUST, not TAG SPLIT');
    expect(await balance(TAG)).toBe(1);

    // A TAG SPLIT book flagged out of use (K1): the request scope layer refuses it before the writer even runs,
    // so it never reaches stock. (The writer keeps its own CUR_USE guard as defence in depth — see the lifecycle
    // DB test, which drives the writer directly.)
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01','SPX','Old Tag Split','TGSPX','TAG SPLIT','O','N','LBR_DATA')`,
      tenantId,
    );
    try {
      const notInUse = await request('splitter', 'POST', '/stock/tag-split', {
        coBook: 'SPX',
        vchDate: DAY,
        parents: [{ tagNo: TAG }],
        children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
      });
      expect([400, 409]).toContain(notInUse.statusCode);
    } finally {
      await exec(`DELETE FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SPX'`, tenantId);
    }
    expect(await balance(TAG)).toBe(1);
  });

  it('runs the whole Tag Split lifecycle on the provisioned TSP book', async () => {
    // Source (K13) reads the parent without consuming it.
    const source = await request(
      'splitter',
      'GET',
      `/stock/tag-split/source?coBook=TSP&tagNo=${TAG}`,
    );
    expect(source.statusCode, source.body).toBe(200);
    expect(source.json()).toMatchObject({
      tagNo: TAG,
      vchSrno: SRNO,
      source: 'BAR_DETL',
      itName: 'RING 916',
      line: { itCode: 'RNG', netWt: 10, fine: 9.16, krName: 'KJ' },
    });
    expect(await balance(TAG)).toBe(1);

    // Split the whole ring into two half rings, conserving the fine (6 + 4 = 10 net).
    const created = await request('splitter', 'POST', '/stock/tag-split', {
      coBook: 'TSP',
      vchDate: DAY,
      vchDesc: 'worn shank',
      parents: [{ tagNo: TAG }],
      children: [
        { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
        { itCode: 'RNGH', grossWt: 4, touch: 91.6 },
      ],
    });
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json()).toMatchObject({
      voucherNo: '00001',
      parents: 1,
      children: 2,
      stockRows: 3,
      ledgerRows: 0,
    });
    // The parent is consumed; two children exist, each a real BAR_DETL tag, conserving the fine.
    expect(await balance(TAG)).toBe(0);
    const kids = await childTags();
    expect(kids).toHaveLength(2);
    expect(kids.map((k) => k.nwt)).toEqual([6, 4]);
    expect(kids[0]!.fine).toBeCloseTo(5.496, 3);
    expect(kids[1]!.fine).toBeCloseTo(3.664, 3);
    for (const k of kids) expect(await balance(k.tag)).toBe(1);

    // Read the voucher back.
    const read = await request('splitter', 'GET', '/stock/tag-split/00001?coBook=TSP');
    expect(read.statusCode, read.body).toBe(200);
    const view = read.json();
    expect(view).toMatchObject({
      voucherNo: '00001',
      vchDesc: 'WORN SHANK',
      mainUser: 'splitter',
      book: { code: 'TSP', mainBook: 'TAG SPLIT' },
    });
    expect(view.parents).toHaveLength(1);
    expect(view.children).toHaveLength(2);
    expect(view.parents[0]).toMatchObject({ tagNo: TAG, vchSrno: SRNO, netWt: 10, fine: 9.16 });
    // The ORIGINAL stored header, read raw from the database (independent of the reissue logic under test).
    const [before] = await query<Array<Record<string, unknown>>>(
      `SELECT "HD_VCH_NO",to_char("VCH_TIME",'HH24:MI:SS') AS clock,"MAIN_USER" FROM "LBR_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='TSP' AND "VCH_NO"='00001'`,
      tenantId,
    );
    const hidden = String(before!.HD_VCH_NO);
    const clock = String(before!.clock);
    expect(hidden).toBeTruthy();
    // Sleep so a reset clock would land on a different second than the original save.
    await new Promise((r) => setTimeout(r, 1100));

    // Edit (PUT) by a DIFFERENT operator ('editor'): re-split the same parent into a single child of the whole
    // weight. The edit releases the old children, gives the parent back and re-consumes it — keeping the voucher's
    // hidden number, opened clock and ORIGINAL author (the acting operator must NOT overwrite MAIN_USER).
    const edited = await request('editor', 'PUT', '/stock/tag-split/00001', {
      coBook: 'TSP',
      vchDate: DAY,
      vchDesc: 'WORN SHANK',
      parents: [{ tagNo: TAG }],
      children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
    });
    expect(edited.statusCode, edited.body).toBe(200);
    const [afterRaw] = await query<Array<Record<string, unknown>>>(
      `SELECT "HD_VCH_NO",to_char("VCH_TIME",'HH24:MI:SS') AS clock,"MAIN_USER" FROM "LBR_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='TSP' AND "VCH_NO"='00001'`,
      tenantId,
    );
    expect(String(afterRaw!.HD_VCH_NO)).toBe(hidden); // K9: the hidden number is kept, not re-issued
    expect(String(afterRaw!.clock)).toBe(clock); // K9: the opened wall clock survives (not reset to "now")
    expect(String(afterRaw!.MAIN_USER)).toBe('splitter'); // K9: the edit does not overwrite the original author
    const afterEdit = (await request('editor', 'GET', '/stock/tag-split/00001?coBook=TSP')).json();
    expect(afterEdit).toMatchObject({
      voucherNo: '00001',
      hiddenVoucherNo: hidden,
      mainUser: 'splitter',
    });
    expect(afterEdit.children).toHaveLength(1);
    expect(afterEdit.children[0]).toMatchObject({ netWt: 10 });
    // K10: the edit released the two old children and re-consumed the parent (exactly one child now live).
    const editedKids = await childTags();
    expect(editedKids).toHaveLength(1);
    expect(await balance(editedKids[0]!.tag)).toBe(1);
    expect(await balance(TAG)).toBe(0);

    // List the book.
    const list = await request('splitter', 'GET', '/stock/tag-split?coBook=TSP');
    expect(list.statusCode, list.body).toBe(200);
    expect(list.json()).toMatchObject({
      nextVoucherNo: '00002',
      vouchers: [{ vchNo: '00001', vchDesc: 'WORN SHANK', children: 1 }], // the edit left one child
    });

    // The parent cannot be split again — it is no longer live.
    const again = await request('splitter', 'POST', '/stock/tag-split', {
      coBook: 'TSP',
      vchDate: DAY,
      parents: [{ tagNo: TAG }],
      children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
    });
    expect(again.statusCode, again.body).toBe(400);
    expect(again.json()).toMatchObject({ error: 'TagNotAvailableError' });

    // Delete reverses it, gives the parent back and writes a DELETE_DATA audit.
    const removed = await request('splitter', 'DELETE', '/stock/tag-split/00001?coBook=TSP');
    expect(removed.statusCode, removed.body).toBe(200);
    expect(removed.json()).toMatchObject({ reversed: true, vchNo: 1, parents: 1, children: 1 });
    expect(await balance(TAG)).toBe(1);
    for (const k of [...kids, ...editedKids]) expect(await balance(k.tag)).toBe(0);
    const [audit] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_TYPE","BOOK_NAME","DELETE_USER","VCH_DESC" FROM "DELETE_DATA" WHERE tenant_id=$1`,
      tenantId,
    );
    expect(audit).toEqual({
      VCH_TYPE: 'TGSPL',
      BOOK_NAME: 'Tag Split',
      DELETE_USER: 'splitter',
      VCH_DESC: `ItCode/RNG TagNo/${TAG}`,
    });
  });

  it('refuses a short split with no absorbing account, and posts the ledger when one is given', async () => {
    // Short by 1 (6 + 3 = 9 < 10) with no absorbing account: refused, nothing written.
    const refused = await request('splitter', 'POST', '/stock/tag-split', {
      coBook: 'TSP',
      vchDate: DAY,
      parents: [{ tagNo: TAG }],
      children: [
        { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
        { itCode: 'RNGH', grossWt: 3, touch: 91.6 },
      ],
    });
    expect(refused.statusCode, refused.body).toBe(400);
    expect(refused.json().message).toContain('Please Insert diff Wt in Received Grid');
    expect(await balance(TAG)).toBe(1);
    expect(
      await query(`SELECT 1 FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, tenantId),
    ).toEqual([]);

    // Same shortfall with an absorbing account: it posts and the gold DR fine legs are written.
    const created = await request('splitter', 'POST', '/stock/tag-split', {
      coBook: 'TSP',
      vchDate: DAY,
      acCode: 'SPLITAC',
      drTouch: 91.6,
      parents: [{ tagNo: TAG }],
      children: [
        { itCode: 'RNGH', grossWt: 6, touch: 91.6 },
        { itCode: 'RNGH', grossWt: 3, touch: 91.6 },
      ],
    });
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json().ledgerRows).toBeGreaterThanOrEqual(2);
    const legs = await query<Array<{ ac: string; sign: string }>>(
      `SELECT "AC_CODE" ac,"SIGN" sign FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "LEDR_KEY"`,
      tenantId,
    );
    // Legs 03/04: SPLITAC Dr and slot-6 (PURCHASE) Cr mirror.
    expect(legs).toEqual([
      { ac: 'SPLITAC', sign: '-' },
      { ac: 'PURCHASE', sign: '+' },
    ]);
    // Clean up so the deadlock test starts from a single live parent.
    const removed = await request('splitter', 'DELETE', '/stock/tag-split/00001?coBook=TSP');
    expect(removed.statusCode, removed.body).toBe(200);
    expect(await balance(TAG)).toBe(1);
  });

  it('keeps a voucher hidden number across an edit even when a later voucher has a higher one', async () => {
    // Two live parents -> two vouchers (hidden 00001, 00002). Editing the FIRST must keep its hidden number 00001,
    // NOT re-issue the next free one (which, with voucher 2 present, would be 00003). This is the case a single
    // voucher cannot exercise, because a re-issue there coincidentally lands back on the same number.
    const P1 = 'RNGE001';
    const P2 = 'RNGE002';
    for (const [tag, srno] of [
      [P1, SRNO + 10],
      [P2, SRNO + 11],
    ] as const) {
      await exec(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
           "VCH_DATE","BOOK_NAME","INOUT_TYPE","ENTRY_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
           "ITM_TOUCH","ITM_FINE","TBL_CODE","PR_CODE","IT_TYPE","TAG_TYPE","EMP_ISU")
         VALUES ($1,'01','01',$2,'PR','00001',3,3,$3::date,'PURCHASE','I','I',$4,$5,'RNG',1,10,10,91.6,9.16,'001','RG','G','R','N')`,
        tenantId,
        YEAR,
        DAY,
        tag,
        srno,
      );
      await exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
           "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
         VALUES ($1,'01','01',$2,'PR','00001',3,1,$3::date,'RNG',$4,$5,'P','+',1,1,10,10,9.16)`,
        tenantId,
        YEAR,
        DAY,
        tag,
        srno,
      );
    }
    const split = (tag: string) =>
      request('splitter', 'POST', '/stock/tag-split', {
        coBook: 'TSP',
        vchDate: DAY,
        parents: [{ tagNo: tag }],
        children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
      });
    const v1 = await split(P1);
    expect(v1.statusCode, v1.body).toBe(201);
    const v1no = v1.json().voucherNo as string;
    const v2 = await split(P2);
    expect(v2.statusCode, v2.body).toBe(201);
    const hiddenBefore = String(
      (
        await query<Array<Record<string, unknown>>>(
          `SELECT "HD_VCH_NO" FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' AND "VCH_NO"=$2`,
          tenantId,
          v1no,
        )
      )[0]!.HD_VCH_NO,
    );
    const editV1 = await request('splitter', 'PUT', `/stock/tag-split/${v1no}`, {
      coBook: 'TSP',
      vchDate: DAY,
      parents: [{ tagNo: P1 }],
      children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
    });
    expect(editV1.statusCode, editV1.body).toBe(200);
    const hiddenAfter = String(
      (
        await query<Array<Record<string, unknown>>>(
          `SELECT "HD_VCH_NO" FROM "LBR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' AND "VCH_NO"=$2`,
          tenantId,
          v1no,
        )
      )[0]!.HD_VCH_NO,
    );
    expect(hiddenAfter).toBe(hiddenBefore); // K9: the edit keeps the hidden number, never re-issues it
    // Clean up both vouchers so later tests start from the single seeded parent.
    for (const no of [v2.json().voucherNo, v1no])
      await request('splitter', 'DELETE', `/stock/tag-split/${no}?coBook=TSP`);
    for (const table of ['BAR_DETL', 'MAIN_STOCK'])
      await exec(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "TAG_NO" LIKE 'RNGE%'`, tenantId);
  });

  it('reports a deadlock with another writer as 409 Conflict, writes nothing and uses no number', async () => {
    // A second parent so the save locks two tags in sorted order and a concurrent writer can close a cycle.
    const SECOND = 'RNG00002';
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","ENTRY_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_FINE","TBL_CODE","PR_CODE","IT_TYPE","TAG_TYPE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',2,2,$3::date,'PURCHASE','I','I',$4,$5,'RNG',1,8,8,91.6,7.328,'001','RG','G','R','N')`,
      tenantId,
      YEAR,
      DAY,
      SECOND,
      SRNO + 1,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE")
       VALUES ($1,'01','01',$2,'PR','00001',2,1,$3::date,'RNG',$4,$5,'P','+',1,1,8,8,7.328)`,
      tenantId,
      YEAR,
      DAY,
      SECOND,
      SRNO + 1,
    );
    // K2.6: the save locks its tags sorted under the resolver's key, so it takes RNG00001 then waits for
    // RNG00002. A writer holding RNG00002 that then asks for RNG00001 closes a cycle PostgreSQL must break.
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
    const response = await request('splitter', 'POST', '/stock/tag-split', {
      coBook: 'TSP',
      vchDate: DAY,
      // Two parents, each split into one child of its own weight — conserves per parent.
      parents: [{ tagNo: TAG }, { tagNo: SECOND }],
      children: [
        { itCode: 'RNGH', grossWt: 10, touch: 91.6 },
        { itCode: 'RNGH', grossWt: 8, touch: 91.6 },
      ],
    });
    await other;
    expect(response.statusCode, response.body).toBe(409);
    expect(response.json()).toMatchObject({ error: 'TagSplitConflictError' });
    expect(await balance(TAG)).toBe(1);
    expect(await balance(SECOND)).toBe(1);
    for (const table of ['LBR_DATA', 'BAR_DATA', 'TEMP_BOOK_DATA'])
      expect(
        await query(`SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='TSP'`, tenantId),
        table,
      ).toEqual([]);
    // Retried, it succeeds on the number the failed attempt did not use.
    const retried = await request('splitter', 'POST', '/stock/tag-split', {
      coBook: 'TSP',
      vchDate: DAY,
      parents: [{ tagNo: TAG }, { tagNo: SECOND }],
      children: [
        { itCode: 'RNGH', grossWt: 10, touch: 91.6 },
        { itCode: 'RNGH', grossWt: 8, touch: 91.6 },
      ],
    });
    expect(retried.statusCode, retried.body).toBe(201);
    expect(retried.json()).toMatchObject({ voucherNo: '00001', parents: 2, children: 2 });
    const removed = await request('splitter', 'DELETE', '/stock/tag-split/00001?coBook=TSP');
    expect(removed.statusCode, removed.body).toBe(200);
    expect(await balance(TAG)).toBe(1);
    expect(await balance(SECOND)).toBe(1);
  }, 60_000);
});
