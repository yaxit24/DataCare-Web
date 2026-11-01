import type { FastifyInstance } from 'fastify';
import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Stock Adjust over HTTP (N222): the desktop menu opens TR_TAG_CAN on a STOCK ADJUST book (MDI_FORM.cs:8616-8627).
 * Expected values come from the desktop rules:
 * - each line carries a Sign; Enter refuses anything but + or - ("Please Insert Item Sign + or - then Try",
 *   TR_TAG_CAN.cs:4259-4263) and the register keeps it (BAR_CAN_DETL.ITM_SIGN, :5138-5145);
 * - Tag_Can_Stk posts one MAIN_STOCK row per line, TR_TYPE 'I' for + and 'O' for - (Ac_Stock.cs:53);
 * - StkAdj_Lot posts LOT_DETL for a line with a TagLot (Ac_Stock.cs:642-646), a column the grid shows only with
 *   Purchase LOT (MSG_CLEAR :2514-2526); Dm_Tag_Cancel_Detl posts DM_DATA for TAG CANCEL books only (Ac_Stock.cs:824-828);
 * - the provisioned book is the desktop's STADJ out book numbered from BAR_CAN_DATA (MS_UPDATE.cs:24207, :25049, :7825).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'stock-adjust-route-db';
const OTHER = 'stock-adjust-route-other';
const PASSWORD = 'Stock-Adjust-Route!2026';
const SECRET = 'stock-adjust-route-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;
const TAG = 'SAG00001';
const SRNO = 100312000011;

(enabled ? describe : describe.skip)('N222 Stock Adjust through HTTP', () => {
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
  const login = async (name: string, rights: Array<[string, string]>, userFlags = 'Y') => {
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER',$4,$4,$4,'N')`,
      tenantId,
      name,
      await hashPassword(PASSWORD),
      userFlags,
    );
    for (const [subMenu, edit] of rights)
      await exec(
        `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Other',$3,'Y',$4,$4,$4)`,
        tenantId,
        name,
        subMenu,
        edit,
      );
  };
  const balance = async (tagNo: string): Promise<number> => {
    const [row] = await query<Array<{ bal: number }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS bal FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      tagNo,
    );
    return Number(row?.bal ?? 0);
  };
  const looseWeight = async (itCode: string): Promise<number> => {
    const [row] = await query<Array<{ wt: string }>>(
      `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_NWT" ELSE -"ITM_NWT" END),0)::text AS wt
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "IT_CODE"=$2 AND "TAG_NO"='N'`,
      tenantId,
      itCode,
    );
    return Number(row?.wt ?? 0);
  };
  const writeSet = async () => {
    const counts: Record<string, number> = {};
    for (const table of ['BAR_CAN_DATA', 'BAR_CAN_DETL', 'BAR_CAN_IDTL', 'LOT_DETL', 'DM_DATA']) {
      const [row] = await query<Array<{ n: number }>>(
        `SELECT count(*)::int n FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ'`,
        tenantId,
      );
      counts[table] = row!.n;
    }
    const [stock] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ'`,
      tenantId,
    );
    counts.MAIN_STOCK = stock!.n;
    return counts;
  };
  const empty = {
    BAR_CAN_DATA: 0,
    BAR_CAN_DETL: 0,
    BAR_CAN_IDTL: 0,
    LOT_DETL: 0,
    DM_DATA: 0,
    MAIN_STOCK: 0,
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe(tenantId);
    await wipe(OTHER);
    await seedCompany(runtime, tenantId, '01');
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
       VALUES ($1,'01','SA916','S RING 916','G','SA','G'),($1,'01','SAL22','S LOOSE 22K','G','SA','G')`,
      tenantId,
    );
    // A purchased tag.
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","OLD_SRNO",
         "VCH_DATE","BOOK_NAME","INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT",
         "ITM_TOUCH","ITM_WEST_PRC","ITM_FINE","KR_NET_WT","KR_TOUCH","KR_FINE","TBL_CODE","KR_NAME",
         "PR_CODE","IT_TYPE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'PURCHASE','I',$4,$5,'SA916',1,8.5,8.2,
               92,5,7.954,8.2,92,7.544,'001','KJ','SA','G','N')`,
      tenantId,
      YEAR,
      DAY,
      TAG,
      SRNO,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
         "VCH_DATE","IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','00001',1,1,$3::date,'SA916',$4,$5,'P','+',1,1,8.5,8.2)`,
      tenantId,
      YEAR,
      DAY,
      TAG,
      SRNO,
    );
    // Another tenant's voucher number 00001 on a SAJ book: must never be read or touched.
    await owner.$executeRawUnsafe(
      `INSERT INTO "BAR_CAN_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DESC")
       VALUES ($1,'01','01',$2,'SAJ','00001','SENTINEL')`,
      OTHER,
      YEAR,
    );
    await login('adjuster', [['Stock Adjust', 'Y']]);
    // View right only, and no user-level update, delete or print (LOGIN_MAST), which would waive the form's.
    await login('viewer', [['Stock Adjust', 'N']], 'N');
    await login('canceller', [['Tag Cancel', 'Y']]);
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    for (const name of ['adjuster', 'viewer', 'canceller']) {
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
    if (owner) {
      await wipe(tenantId);
      await wipe(OTHER);
    }
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('provisions the desktop STADJ out book numbered from BAR_CAN_DATA', async () => {
    const books = await query<Array<Record<string, unknown>>>(
      `SELECT "BOOK_SNAME","BOOK_INOUT","BOOK_TBL_NAME","BOOK_TBL_DETL","CUR_USE" FROM "BOOK_DATA"
        WHERE tenant_id=$1 AND "MAIN_BOOK"='STOCK ADJUST'`,
      tenantId,
    );
    expect(books).toEqual([
      {
        BOOK_SNAME: 'STADJ',
        BOOK_INOUT: 'O',
        BOOK_TBL_NAME: 'BAR_CAN_DATA',
        BOOK_TBL_DETL: 'BAR_CAN_DETL',
        CUR_USE: 'Y',
      },
    ]);
  });

  it('keeps the menu to its own right and refuses another menu’s book', async () => {
    const asCanceller = await request('canceller', 'POST', '/stock/stock-adjust', {
      coBook: 'SAJ',
      vchDate: DAY,
      lines: [{ itCode: 'SAL22', itmSign: '+', grossWt: 1, netWt: 1 }],
    });
    expect(asCanceller.statusCode, asCanceller.body).toBe(403);
    const cancelAsAdjuster = await request('adjuster', 'GET', '/stock/tag-cancel?coBook=TGC');
    expect(cancelAsAdjuster.statusCode, cancelAsAdjuster.body).toBe(403);
    const listAsViewer = await request('viewer', 'GET', '/stock/stock-adjust?coBook=SAJ');
    expect(listAsViewer.statusCode, listAsViewer.body).toBe(200);

    const wrongBook = await request('adjuster', 'POST', '/stock/stock-adjust', {
      coBook: 'TGC',
      vchDate: DAY,
      lines: [{ itCode: 'SAL22', itmSign: '+', grossWt: 1, netWt: 1 }],
    });
    expect(wrongBook.statusCode, wrongBook.body).toBe(400);
    expect(wrongBook.json()).toMatchObject({
      error: 'TagCancelValidationError',
      message: 'book TGC is TAG CANCEL, not STOCK ADJUST — use Tag Cancel',
    });
    expect(await writeSet()).toEqual(empty);
  });

  it('refuses a line without + or - with the desktop text, writing nothing', async () => {
    for (const itmSign of [undefined, '', 'X', '*']) {
      const response = await request('adjuster', 'POST', '/stock/stock-adjust', {
        coBook: 'SAJ',
        vchDate: DAY,
        lines: [
          { itCode: 'SAL22', ...(itmSign === undefined ? {} : { itmSign }), grossWt: 2, netWt: 2 },
        ],
      });
      expect(response.statusCode, response.body).toBe(400);
      expect(response.json().message).toBe('Please Insert Item Sign + or - then Try');
    }
    // A Sign on the Tag Cancel menu is refused: it is a Stock Adjust column.
    const onCancel = await request('canceller', 'POST', '/stock/tag-cancel', {
      coBook: 'TGC',
      vchDate: DAY,
      lines: [{ tagNo: TAG, itmSign: '+' }],
    });
    expect(onCancel.statusCode, onCancel.body).toBe(400);
    expect(onCancel.json().message).toBe('row 1: Sign is a Stock Adjust column');
    // TagLot is hidden while Purchase LOT is off (the provisioned default, CO_SET_NEW.PURC_LOT 'N').
    const hiddenLot = await request('adjuster', 'POST', '/stock/stock-adjust', {
      coBook: 'SAJ',
      vchDate: DAY,
      lines: [{ itCode: 'SAL22', itmSign: '+', grossWt: 2, netWt: 2, lotNo: 'PL001' }],
    });
    expect(hiddenLot.statusCode, hiddenLot.body).toBe(400);
    expect(hiddenLot.json().message).toBe('row 1: TagLot is shown only with Purchase LOT');
    expect(await writeSet()).toEqual(empty);
    expect(await balance(TAG)).toBe(1);
  });

  it('runs the whole lifecycle: signed register, I/O stock rows, the tag lot, reopen, edit, print, delete', async () => {
    await exec(
      `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","PURC_LOT") VALUES ($1,'01','Y')`,
      tenantId,
    );
    const created = await request('adjuster', 'POST', '/stock/stock-adjust', {
      coBook: 'SAJ',
      vchDate: DAY,
      vchDesc: 'count correction',
      lines: [
        { itCode: 'SAL22', itmSign: '+', grossWt: 10, netWt: 10, touch: 91.6 },
        { tagNo: TAG, itmSign: '-', lotNo: 'pl001' },
      ],
    });
    expect(created.statusCode, created.body).toBe(201);
    expect(created.json()).toMatchObject({
      vchNo: 1,
      voucherNo: '00001',
      lines: 2,
      stockRows: 2,
      lotRows: 1,
      diamondRows: 0,
    });
    expect(await balance(TAG)).toBe(0);
    expect(await looseWeight('SAL22')).toBe(10);

    const details = await query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO","IT_CODE","TAG_NO","ITM_SIGN","LOT_NO","VCH_TYPE","INOUT_TYPE","BOOK_NAME"
         FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ' ORDER BY "SR_NO"`,
      tenantId,
    );
    expect(details).toEqual([
      {
        SR_NO: 1,
        IT_CODE: 'SAL22',
        TAG_NO: 'N',
        ITM_SIGN: '+',
        LOT_NO: '',
        VCH_TYPE: 'STADJ',
        INOUT_TYPE: 'O',
        BOOK_NAME: 'STOCK ADJUST',
      },
      {
        SR_NO: 2,
        IT_CODE: 'SA916',
        TAG_NO: TAG,
        ITM_SIGN: '-',
        LOT_NO: 'PL001',
        VCH_TYPE: 'STADJ',
        INOUT_TYPE: 'O',
        BOOK_NAME: 'STOCK ADJUST',
      },
    ]);
    const stock = await query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO","IT_CODE","TAG_NO","TR_TYPE","ITM_SIGN","VCH_TYPE","BOOK_NAME","ITM_NWT"::text nwt
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ' ORDER BY "SR_NO"`,
      tenantId,
    );
    expect(stock).toEqual([
      {
        SR_NO: 1,
        IT_CODE: 'SAL22',
        TAG_NO: 'N',
        TR_TYPE: 'I',
        ITM_SIGN: '+',
        VCH_TYPE: 'STADJ',
        BOOK_NAME: 'STOCK ADJUST',
        nwt: '10.000',
      },
      {
        SR_NO: 2,
        IT_CODE: 'SA916',
        TAG_NO: TAG,
        TR_TYPE: 'O',
        ITM_SIGN: '-',
        VCH_TYPE: 'STADJ',
        BOOK_NAME: 'STOCK ADJUST',
        nwt: '8.200',
      },
    ]);
    const lots = await query<Array<Record<string, unknown>>>(
      `SELECT "SR_NO","LOT_NO","IT_CODE","IT_SIGN","ENTRY_TYPE","VCH_TYPE","INOUT_TYPE","BOOK_NAME","HD_VCH_NO",
              "IT_PCS"::text pcs,"IT_GWT"::text gwt,"IT_NWT"::text nwt,"DATA_TRFR","TAG_NO","MAIN_USER"
         FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ'`,
      tenantId,
    );
    expect(lots).toEqual([
      {
        SR_NO: 2,
        LOT_NO: 'PL001',
        IT_CODE: 'SA916',
        IT_SIGN: '-',
        ENTRY_TYPE: 'L',
        VCH_TYPE: 'STADJ',
        INOUT_TYPE: 'O',
        BOOK_NAME: 'STOCK ADJUST',
        HD_VCH_NO: '00001',
        pcs: '1.000',
        gwt: '8.500',
        nwt: '8.200',
        DATA_TRFR: 'N',
        TAG_NO: '',
        MAIN_USER: 'adjuster',
      },
    ]);

    const read = await request('adjuster', 'GET', '/stock/stock-adjust/00001?coBook=SAJ');
    expect(read.statusCode, read.body).toBe(200);
    const view = read.json();
    expect(view).toMatchObject({
      mode: 'adjust',
      voucherNo: '00001',
      vchDesc: 'COUNT CORRECTION',
      book: { code: 'SAJ', shortName: 'STADJ', mainBook: 'STOCK ADJUST' },
    });
    expect(view.lines.map((l: Record<string, unknown>) => [l.itCode, l.tagNo, l.itmSign])).toEqual([
      ['SAL22', '', '+'],
      ['SA916', TAG, '-'],
    ]);

    // Edit: the loose line now takes 3 g out instead of adding 10 g; the tag line stays.
    const updated = await request('adjuster', 'PUT', '/stock/stock-adjust/00001', {
      coBook: 'SAJ',
      vchDate: DAY,
      vchDesc: view.vchDesc,
      lines: [
        { oldSrNo: 1, itCode: 'SAL22', itmSign: '-', grossWt: 3, netWt: 3, touch: 91.6 },
        { oldSrNo: 2, tagNo: TAG, vchSrno: SRNO, itmSign: '-', lotNo: 'PL001' },
      ],
    });
    expect(updated.statusCode, updated.body).toBe(200);
    expect(await looseWeight('SAL22')).toBe(-3);
    expect(await balance(TAG)).toBe(0);
    const reread = (
      await request('adjuster', 'GET', '/stock/stock-adjust/00001?coBook=SAJ')
    ).json();
    expect(reread.lines.map((l: Record<string, unknown>) => [l.itmSign, l.netWt])).toEqual([
      ['-', 3],
      ['-', 8.2],
    ]);
    expect(reread.hiddenVoucherNo).toBe(view.hiddenVoucherNo);
    const [lotAfterEdit] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ' AND "LOT_NO"='PL001'`,
      tenantId,
    );
    expect(lotAfterEdit!.n).toBe(1);

    const list = await request('adjuster', 'GET', '/stock/stock-adjust?coBook=SAJ');
    expect(list.statusCode, list.body).toBe(200);
    expect(JSON.stringify(list.json())).toContain('00001');

    const printed = await request(
      'adjuster',
      'GET',
      '/stock/stock-adjust/00001/print?coBook=SAJ&format=html',
    );
    expect(printed.statusCode, printed.body).toBe(200);
    // TagCanBill's {@ItemName}: TAG_NO + ' - ' + IT_NAME on a tag line, IT_NAME on a loose one.
    expect(printed.body).toContain(`${TAG} - S RING 916`);
    expect(printed.body).toContain('S LOOSE 22K');
    // BtnSave refuses an edit without the edit right (TR_TAG_CAN.cs:4980); Delete and Print check theirs.
    const editAsViewer = await request('viewer', 'PUT', '/stock/stock-adjust/00001', {
      coBook: 'SAJ',
      vchDate: DAY,
      lines: [{ oldSrNo: 1, itCode: 'SAL22', itmSign: '+', grossWt: 1, netWt: 1 }],
    });
    expect(editAsViewer.statusCode, editAsViewer.body).toBe(403);
    const deleteAsViewer = await request(
      'viewer',
      'DELETE',
      '/stock/stock-adjust/00001?coBook=SAJ',
    );
    expect(deleteAsViewer.statusCode, deleteAsViewer.body).toBe(403);
    const printAsViewer = await request(
      'viewer',
      'GET',
      '/stock/stock-adjust/00001/print?coBook=SAJ&format=html',
    );
    expect(printAsViewer.statusCode).toBe(403);

    const removed = await request('adjuster', 'DELETE', '/stock/stock-adjust/00001?coBook=SAJ');
    expect(removed.statusCode, removed.body).toBe(200);
    expect(await writeSet()).toEqual(empty);
    expect(await balance(TAG)).toBe(1);
    expect(await looseWeight('SAL22')).toBe(0);
    const [audit] = await query<Array<Record<string, unknown>>>(
      `SELECT "VCH_NO","DELETE_USER" FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ'`,
      tenantId,
    );
    expect(audit).toMatchObject({ VCH_NO: '00001', DELETE_USER: 'adjuster' });
    const sentinel = await owner.$queryRawUnsafe(
      `SELECT "VCH_DESC" FROM "BAR_CAN_DATA" WHERE tenant_id=$1`,
      OTHER,
    );
    expect(sentinel).toEqual([{ VCH_DESC: 'SENTINEL' }]);
    await exec(`DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1`, tenantId);
  });

  it('a + tag line adds the tag’s stock without taking the instance out, and its delete gives nothing back', async () => {
    const created = await request('adjuster', 'POST', '/stock/stock-adjust', {
      coBook: 'SAJ',
      vchDate: DAY,
      lines: [{ tagNo: TAG, itmSign: '+' }],
    });
    expect(created.statusCode, created.body).toBe(201);
    expect(await balance(TAG)).toBe(2);
    const [row] = await query<Array<Record<string, unknown>>>(
      `SELECT "TR_TYPE","ITM_SIGN" FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='SAJ'`,
      tenantId,
    );
    expect(row).toEqual({ TR_TYPE: 'I', ITM_SIGN: '+' });
    const voucherNo = created.json().voucherNo as string;
    const removed = await request(
      'adjuster',
      'DELETE',
      `/stock/stock-adjust/${voucherNo}?coBook=SAJ`,
    );
    expect(removed.statusCode, removed.body).toBe(200);
    expect(removed.json()).toMatchObject({ restoredTags: 0 });
    expect(await balance(TAG)).toBe(1);
    const [tagStock] = await query<Array<{ n: number }>>(
      `SELECT count(*)::int n FROM "TAG_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
      tenantId,
      TAG,
    );
    expect(tagStock!.n).toBe(0);
    expect(await writeSet()).toEqual(empty);
  });
  it('lists the TagLot help from LOT_DETL and the ItmLot help from loose MAIN_STOCK, with signed balances', async () => {
    const lot = (
      vchNo: string,
      srNo: number,
      lotNo: string,
      sign: string,
      pcs: number,
      gwt: number,
      nwt: number,
    ) =>
      exec(
        `INSERT INTO "LOT_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE",
           "ENTRY_TYPE","IT_CODE","LOT_NO","IT_PCS","IT_GWT","IT_NWT","IT_SIGN")
         VALUES ($1,'01','01',$2,'PR',$3,$4,$5::date,'L','SAL22',$6,$7,$8,$9,$10)`,
        tenantId,
        YEAR,
        vchNo,
        srNo,
        DAY,
        lotNo,
        pcs,
        gwt,
        nwt,
        sign,
      );
    await lot('00091', 1, 'PL009', '+', 2, 5, 4.8);
    await lot('00092', 1, 'PL009', '-', 1, 1, 1);
    await lot('00093', 1, 'PL010', '+', 1, 2, 2);
    await lot('00094', 1, 'PL010', '-', 1, 2, 2);
    const stock = (srNo: number, tagNo: string, itmLot: string, nwt: number) =>
      exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO",
           "VCH_DATE","IT_CODE","TAG_NO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT","ITM_LOT")
         VALUES ($1,'01','01',$2,'PR','00095',$3,1,$4::date,'SAL22',$5,'P','+',1,1,$6,$6,$7)`,
        tenantId,
        YEAR,
        srNo,
        DAY,
        tagNo,
        nwt,
        itmLot,
      );
    await stock(1, 'N', 'IL01', 3);
    await stock(2, 'SAG99999', 'IL02', 4);
    try {
      const tagLots = await request('adjuster', 'GET', '/stock/stock-adjust/lots?kind=tag&q=pl');
      expect(tagLots.statusCode, tagLots.body).toBe(200);
      expect(tagLots.json()).toEqual([
        { code: 'PL009', name: 'S LOOSE 22K', itCode: 'SAL22', pcs: 1, grossWt: 4, netWt: 3.8 },
      ]);
      const itemLots = await request('adjuster', 'GET', '/stock/stock-adjust/lots?kind=item&q=');
      expect(itemLots.statusCode, itemLots.body).toBe(200);
      expect(itemLots.json()).toEqual([
        { code: 'IL01', name: 'S LOOSE 22K', itCode: 'SAL22', pcs: 1, grossWt: 3, netWt: 3 },
      ]);
      const wrongKind = await request('adjuster', 'GET', '/stock/stock-adjust/lots?kind=x');
      expect(wrongKind.statusCode, wrongKind.body).toBe(400);
      const asCanceller = await request('canceller', 'GET', '/stock/stock-adjust/lots?kind=tag');
      expect(asCanceller.statusCode).toBe(403);
    } finally {
      await exec(`DELETE FROM "LOT_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='PR'`, tenantId);
      await exec(`DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "VCH_NO"='00095'`, tenantId);
    }
  });
});
