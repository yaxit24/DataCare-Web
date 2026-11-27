import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';
import { tenantTables } from './support/tenantSnapshot.js';

/**
 * WP-28 (N244 / G256): Purchase residuals over HTTP, through the routes the Purchase screens use.
 *
 * The frozen case list is `orchestration/work/WP-28/cases.md`; the case id is named on each test. Desktop authority:
 * `TR_PURC_HM.cs` (hallmark purchase, 95-column receive grid) and `TR_PURC.cs`.
 *
 * LOSSLESS REOPEN (D6, G1, G2, G10). The desktop reopens a voucher with `SELECT *` (TR_PURC_HM.cs:7216, :7462) and holds
 * every column in a grid cell, so an unchanged save writes back what it read. The web edit deletes the whole write set
 * and rewrites it from the request, so every stored value must come back through `GET /purchases/:vchNo` and be sent
 * back by `PUT`. The test below dates the voucher in an EARLIER month, types the amount and the fine (so neither may
 * be recomputed), carries a hallmark line, a stone, header settlement fields and a bill number with a trailing space,
 * and then asserts that EVERY row of EVERY tenant table is identical after reopen + unchanged save (only the surrogate
 * `row_id` is ignored, because a rewritten row is a new physical row).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'wp28-purc-db';
const PASSWORD = 'Wp28-Purchase-Residuals!2026';
const SECRET = 'wp28-purchase-residuals-route-test-signing-secret';
const LOGIN = 'buyer28';
const BOOK = 'PR';
const TAG_BOOK = 'TPR';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
/** An earlier month than today, inside the open year: an edit must never default the date to today. */
const EARLIER_DAY = `${startYear}-04-15`;

const GOLD = {
  itCode: 'GLD01',
  pcs: 1,
  grossWt: 20.5,
  netWt: 20,
  touch: 91.6,
  rate: 6050,
  labourType: 'per_gram',
  labourRate: 150,
};
const SILVER = { itCode: 'SLV01', pcs: 3, grossWt: 100.4, netWt: 100, touch: 92.5, rate: 80 };

/** Every stored column of line 1 the study lists (G1), plus the hallmark-layout columns (G3). */
const GOLD_FULL = {
  ...GOLD,
  // Typed values: 18.320 x 6,050 would be 110,836.00 and the fine 18.320. Both must survive a reopen.
  metalAmount: 110800,
  fineWt: 18.3,
  hmIdAmount: 36.5,
  huid: 'HUID01',
  itmColor: 'RED',
  lotNo: 'L7',
  itmLot: '7',
  withStock: 'Y',
  lossWt: 0.2,
  ghtPct: 2,
  lessTouch: 0.5,
  convRate: 6000,
  convPct: 98,
  commissionAmount: 120,
  fineCutPcs: 2,
  fineCutGrossWt: 4,
  fineCutNetWt: 3.5,
  fineCutFine: 3.2,
  prCode: 'PC',
  designNo: 'D-11',
  stones: [
    {
      itCode: 'DIA',
      dmName: 'Round',
      pcs: 4,
      grossWt: 0.12,
      rate: 5000,
      amount: 600,
      netAmount: 600,
      itType: 'D',
    },
  ],
};
const SILVER_FULL = { ...SILVER, hmIdAmount: 40, itmColor: 'WHT' };

(enabled ? describe : describe.skip)('WP-28 purchase residuals over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const wipe = async () => {
    for (const table of await tenantTables(owner))
      await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
  };
  const call = (method: 'POST' | 'PUT' | 'GET' | 'DELETE', url: string, payload?: unknown) =>
    app.inject({ method, url, headers: { cookie }, payload: payload as any });
  const purchase = (lines: unknown[], extra: Record<string, unknown> = {}) => ({
    coBook: BOOK,
    acCode: 'SUPL',
    vchDate: EARLIER_DAY,
    taxRatePct: 3,
    interState: false,
    lines,
    ...extra,
  });
  const create = async (payload: unknown, url = '/purchases') => {
    const saved = await call('POST', url, payload);
    expect(saved.statusCode, saved.body).toBe(201);
    return String(saved.json().vchNo).padStart(5, '0');
  };
  /** Every row of every tenant table, without the surrogate key: the "complete database" evidence. */
  const snapshot = async (): Promise<Record<string, string[]>> => {
    const out: Record<string, string[]> = {};
    for (const table of await tenantTables(owner)) {
      // audit_log is the request trail (one row per HTTP call, with a clock), not voucher data.
      if (table === 'audit_log') continue;
      const rows = (await owner.$queryRawUnsafe(
        `SELECT (to_jsonb(t) - 'row_id')::text AS r FROM "${table}" t WHERE tenant_id=$1`,
        tenantId,
      )) as Array<{ r: string }>;
      if (rows.length) out[table] = rows.map((row) => row.r).sort();
    }
    return out;
  };
  /** What the Purchase screen does on an unchanged save: send back what it read, with the version token. */
  const reopenAndSaveUnchanged = async (vchNo: string, book = BOOK) => {
    const opened = await call('GET', `/purchases/${vchNo}?coBook=${book}`);
    expect(opened.statusCode, opened.body).toBe(200);
    const view = opened.json();
    const saved = await call('PUT', `/purchases/${vchNo}?coBook=${book}`, {
      ...view,
      coBook: book,
      expectedVersion: view.version,
    });
    expect(saved.statusCode, saved.body).toBe(200);
    return view;
  };
  const row = async (table: string, book: string, vchNo: string, extra = '') =>
    (await owner.$queryRawUnsafe(
      `SELECT * FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 ${extra}`,
      tenantId,
      book,
      vchNo,
    )) as Array<Record<string, any>>;
  const n = (value: unknown) => Number(value ?? 0);

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    // The TCS code's account, TAX_MAST SR_NO 0 (Ac_Ledr.cs:434): the purchase refuses a TCS amount without one.
    await owner.$executeRawUnsafe(
      `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_AC") VALUES ($1,'01','T1',0,'TCS','TCSLED')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
       VALUES ($1,'01','E1','WP28 GOLD','SALES','PURCHASE'),($1,'01','E2','WP28 SILVER','SLVSALE','SLVPURC')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,'01','GLD01','GOLD 22K ORNAMENT','G','E1'),($1,'01','SLV01','SILVER 925 ORNAMENT','S','E2')`,
      tenantId,
    );
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GR")
       VALUES ($1,'01','01','SUPL','LOCAL SUPPLIER','L','40'),($1,'01','01','BANKAC','WP28 BANK','L','10')`,
      tenantId,
    );
    // Books of other families and an unused purchase book, for the family cases (D7, D8).
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK",
         "BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,'01','01','PX','Purchase Unused','PX','PURCHASE','I','N','PR_DATA'),
              ($1,'01','01','PB','Purchase Blank Family','PB','','I','Y','PR_DATA')`,
      tenantId,
    );
    // PURC_WITH_HMTAX = Y (GST on the hallmark charge) and PR_TDS_TAX = Y (purchase TDS is stored).
    const updated = await exec(
      `UPDATE "CO_SET_NEW" SET "PURC_WITH_HMTAX"='Y',"PR_TDS_TAX"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
      tenantId,
    );
    if (!updated)
      await exec(
        `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","PURC_WITH_HMTAX","PR_TDS_TAX") VALUES ($1,'01','Y','Y')`,
        tenantId,
      );
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01',$2,$3,'USER','Y','Y','Y','N')`,
      tenantId,
      LOGIN,
      await hashPassword(PASSWORD),
    );
    await exec(
      `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
       VALUES($1,'01','01',$2,'Transaction','Purchase Invoice','Y','Y','Y','Y')`,
      tenantId,
      LOGIN,
    );
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: LOGIN, password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? ''])
      .map((part) => part.split(';', 1)[0])
      .join('; ');
  });
  beforeEach(async () => {
    // Voucher rows only; masters stay. Cases are independent of each other's vouchers.
    for (const table of await tenantTables(owner)) {
      const cols = (await owner.$queryRawUnsafe(
        `SELECT 1 FROM information_schema.columns WHERE table_schema='public' AND table_name=$1 AND column_name='VCH_NO'`,
        table,
      )) as unknown[];
      if (cols.length && table !== 'BOOK_DATA' && table !== 'BOOK_DETL')
        await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenantId);
    }
    await exec(
      `UPDATE "ITEM_MAST" SET "IT_TYPE"=CASE "IT_CODE" WHEN 'SLV01' THEN 'S' ELSE 'G' END WHERE tenant_id=$1`,
      tenantId,
    );
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  // purchase-invoice.reopen.all-detail-columns-unchanged-save, reopen.all-header-columns-unchanged-save,
  // field.line-* (14 columns), field.header-*, field.hm-tax-code-route, field.hm-amount-line-route,
  // children.stone-rows-kept, config.history-reopen-after-rate-and-tax-change (no recomputation).
  it('lossless reopen: an unchanged save of an earlier-month hallmark purchase keeps every row of every table', async () => {
    const vchNo = await create(
      purchase([GOLD_FULL, SILVER_FULL], {
        billNo: 'SB 0077 ', // as typed, trailing space included
        address1: '12 Gold St',
        city: 'Surat',
        mobile: '9876543210',
        bankName: 'WP28 BANK',
        chequeNo: '000123',
        cardAc: 'CD1',
        creditDays: 30,
        discountPct: 2,
        discountAmount: 100,
        tcsCode: 'T1',
        tcsPct: 1,
        tcsAmount: 10,
        tdsCode: 'TD1',
        tdsPct: 1,
        tdsAmount: 12,
        empCode: 'E7',
        vchDesc: 'wp28 lossless',
        hmTaxCode: '18',
        hmTaxPct: 18,
        cashAmt: 1000,
        chequeAmt: 500,
        bankAc: 'BANKAC',
      }),
    );
    const header = (await row('PR_DATA', BOOK, vchNo))[0]!;
    // Stored as typed, before any reopen.
    expect(header.BILL_NO).toBe('SB 0077 ');
    expect(header.EMP_CODE).toBe('E7');
    expect(header.HM_TAX_CODE).toBe('18');
    // TR_PURC_HM.cs:9995 Math.Round(36.50 + 40.00, 0) = 76 (half to even); tax Round(76 x 18 / 100, 2) = 13.68.
    expect([n(header.HM_AMT), n(header.HM_TAX_PRC), n(header.HM_TAX_AMT)]).toEqual([76, 18, 13.68]);
    const gold = (await row('PR_DETL', BOOK, vchNo, `ORDER BY "SR_NO"`))[0]!;
    expect([n(gold.ITM_AMT), n(gold.ITM_FINE), n(gold.HM_ID_AMT), gold.ITM_COLOR]).toEqual([
      110800,
      18.3,
      36.5,
      'RED',
    ]);

    const before = await snapshot();
    const view = await reopenAndSaveUnchanged(vchNo);
    // The reader hands back the stored date and the typed values, never today's date or a recomputation.
    expect(view.vchDate).toBe(EARLIER_DAY);
    expect(view.billNo).toBe('SB 0077 ');
    expect(view.lines[0]).toMatchObject({ metalAmount: 110800, fineWt: 18.3, hmIdAmount: 36.5 });
    const after = await snapshot();
    // Every table, every row, every column (except row_id): no difference of any kind.
    expect(after).toEqual(before);
    for (const table of ['AC_DATA', 'TAX_DATA', 'MAIN_STOCK', 'ROJ_MEL_DATA', 'PR_IDTL'])
      expect(before[table]?.length ?? 0, table).toBeGreaterThan(0);
  });

  // purchase-invoice.reopen.item-master-changed-keeps-stored (D12)
  it('lossless reopen keeps the stored IT_TYPE after the item master changes', async () => {
    const vchNo = await create(purchase([GOLD, SILVER]));
    await exec(
      `UPDATE "ITEM_MAST" SET "IT_TYPE"='G' WHERE tenant_id=$1 AND "IT_CODE"='SLV01'`,
      tenantId,
    );
    const before = await snapshot();
    await reopenAndSaveUnchanged(vchNo);
    expect(await snapshot()).toEqual(before);
  });

  // purchase-invoice.reopen.desktop-shaped-voucher: columns the web does not model survive an unchanged save.
  it('lossless reopen keeps desktop-only header and line columns the web screen does not show', async () => {
    const vchNo = await create(purchase([GOLD, SILVER]));
    await exec(
      `UPDATE "PR_DATA" SET "OS_ADJ_AMT"=250,"DATA_TRFR"='Y',"TOT_TAX_FREE_AMT"=12.5
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      tenantId,
      BOOK,
      vchNo,
    );
    await exec(
      `UPDATE "PR_DETL" SET "DESIGN_IMG_ID"='D5',"TAG_SRNO"=3,"ADD_USER"='desk',"OLD_VCH_NO"='00009'
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3 AND "SR_NO"=1`,
      tenantId,
      BOOK,
      vchNo,
    );
    const before = await snapshot();
    const view = await reopenAndSaveUnchanged(vchNo);
    expect(view.lines[0]).toMatchObject({ designImgId: 'D5', tagSrno: 3 });
    expect(await snapshot()).toEqual(before);
  });

  // Review finding (D6): the desktop stores a blank text box as '' (TR_PURC_HM.cs:7897 EMP_CODE = tEmpCode.Text,
  // :7898 VCH_DESC, :7854 HM_TAX_CODE, :7968-7973 IT_DESC/TBL_CODE/ITM_COLOR). The writer builds NULL for a blank,
  // so without care an unchanged save of a desktop-written voucher rewrote every '' as NULL. (A numeric NULL is
  // written as the column default 0 by the shared insert path; that is the repository's column-default rule.)
  it('lossless reopen keeps a desktop-stored empty string as stored', async () => {
    const vchNo = await create(purchase([GOLD, SILVER]));
    await exec(
      `UPDATE "PR_DATA" SET "EMP_CODE"='',"VCH_DESC"='',"HM_TAX_CODE"=''
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      tenantId,
      BOOK,
      vchNo,
    );
    await exec(
      `UPDATE "PR_DETL" SET "IT_DESC"='',"TBL_CODE"='',"DESIGN_NO"='',"ITM_COLOR"='',"TAG_TYPE"='',"HM_ID"='',
              "HM_ID2"='',"HM_ID3"='',"HM_ID4"='',"LOT_NO"='',"ITM_LOT"='',"WITH_STOCK"='',"PR_CODE"='',
              "URD_RATE_TYPE"=''
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3`,
      tenantId,
      BOOK,
      vchNo,
    );
    const before = await snapshot();
    await reopenAndSaveUnchanged(vchNo);
    expect(await snapshot()).toEqual(before);
  });

  // purchase-invoice.children.hm-ids-four-with-weights, children.tag-band-two-lines,
  // reopen.tag-band-from-pr-detl, formula.bar-detl-net-weight-rule, formula.bar-detl-rate-amount-rule
  it('TAG PURCHASE: four hallmark ids, weights and the tag band are stored per line and survive an unchanged save', async () => {
    const tagLine1 = {
      ...GOLD,
      tagNo: 'T-001',
      huid: 'H1',
      hmId2: 'H2',
      hmId3: 'H3',
      hmId4: 'H4',
      hmIdWt: 0.1,
      hmId2Wt: 0.2,
      hmId3Wt: 0.3,
      hmId4Wt: 0.4,
      tagOthWt: 0.5,
      tagNwt: 9.8,
      tagTouch: 91.6,
      tagRate: 6100,
      tagAmount: 61000,
      tagCost: 60000,
      tagTotCost: 61500,
      tagMarginPct: 5,
    };
    const tagLine2 = {
      ...SILVER,
      tagNo: 'T-002',
      huid: 'H5',
      hmIdWt: 0.05,
      tagNwt: 0,
      tagTouch: 75,
      tagCost: 20000,
      tagMarginPct: 8,
    };
    const vchNo = await create(purchase([tagLine1, tagLine2], { coBook: TAG_BOOK }));
    const lines = await row('PR_DETL', TAG_BOOK, vchNo, `ORDER BY "SR_NO"`);
    expect(lines.map((l) => [l.HM_ID, l.HM_ID2, l.HM_ID3, l.HM_ID4])).toEqual([
      ['H1', 'H2', 'H3', 'H4'],
      ['H5', null, null, null],
    ]);
    expect(
      lines.map((l) => [n(l.HM_ID_WT), n(l.HM_ID2_WT), n(l.HM_ID3_WT), n(l.HM_ID4_WT)]),
    ).toEqual([
      [0.1, 0.2, 0.3, 0.4],
      [0.05, 0, 0, 0],
    ]);
    expect(
      lines.map((l) => [n(l.TAG_OTH_WT), n(l.TAG_NWT), n(l.TAG_MARGIN_PRC), l.WITH_STOCK]),
    ).toEqual([
      [0.5, 9.8, 5, 'N'],
      [0, 0, 8, 'N'],
    ]);
    const tags = await row('BAR_DETL', TAG_BOOK, vchNo, `ORDER BY "SR_NO"`);
    // TR_PURC_HM.cs:8237-8246: ITM_NWT is the tag net unless it is zero; KR_NET_WT is the line net.
    expect(tags.map((t) => [t.TAG_NO, n(t.ITM_NWT), n(t.KR_NET_WT)])).toEqual([
      ['T-001', 9.8, 20],
      ['T-002', 100, 100],
    ]);
    // TR_PURC_HM.cs:8304-8316: a typed tag amount wins (rate 6,100, amount 61,000, cost col 52, margin col 53).
    expect(tags.map((t) => [n(t.ITM_RATE), n(t.TAG_COST), n(t.ITM_MARGIN)])).toEqual([
      [6100, 61500, 5],
      [80, 20000, 0],
    ]);
    expect(n(tags[0]!.ITM_AMT)).toBe(61000);
    const before = await snapshot();
    const view = await reopenAndSaveUnchanged(vchNo, TAG_BOOK);
    expect(view.lines[0]).toMatchObject({
      hmId2: 'H2',
      hmId4Wt: 0.4,
      tagNwt: 9.8,
      tagAmount: 61000,
    });
    expect(await snapshot()).toEqual(before);
  });

  // purchase-invoice.refusal.book-family-screen-mismatch (D5): a PURCHASE book never stores tag-band values.
  it('a PURCHASE book stores the tag band as zeros and blanks whatever the request says', async () => {
    const vchNo = await create(
      purchase([
        { ...GOLD, hmId2: 'H2', hmId2Wt: 0.2, tagNwt: 9.8, tagCost: 500, tagMarginPct: 5 },
      ]),
    );
    const line = (await row('PR_DETL', BOOK, vchNo))[0]!;
    expect([
      line.HM_ID2,
      n(line.HM_ID2_WT),
      n(line.TAG_NWT),
      n(line.TAG_COST),
      n(line.TAG_MARGIN_PRC),
    ]).toEqual([null, 0, 0, 0, 0]);
  });

  // purchase-invoice.formula.hm-zero-charge-no-tax
  it('a chosen hallmark tax code is stored even when no line carries a hallmark amount', async () => {
    const vchNo = await create(purchase([GOLD, SILVER], { hmTaxCode: '18', hmTaxPct: 18 }));
    const header = (await row('PR_DATA', BOOK, vchNo))[0]!;
    expect([
      header.HM_TAX_CODE,
      n(header.HM_TAX_PRC),
      n(header.HM_AMT),
      n(header.HM_TAX_AMT),
    ]).toEqual(['18', 18, 0, 0]);
  });

  // purchase-invoice.edit.hm-amount-changes-header-total
  it('editing a line hallmark amount re-derives the header charge and its tax (half to even)', async () => {
    const vchNo = await create(
      purchase(
        [
          { ...GOLD, hmIdAmount: 36.5 },
          { ...SILVER, hmIdAmount: 40 },
        ],
        {
          hmTaxCode: '18',
          hmTaxPct: 18,
        },
      ),
    );
    const view = (await call('GET', `/purchases/${vchNo}?coBook=${BOOK}`)).json();
    const edited = await call('PUT', `/purchases/${vchNo}?coBook=${BOOK}`, {
      ...view,
      coBook: BOOK,
      expectedVersion: view.version,
      lines: [{ ...view.lines[0], hmIdAmount: 46.5 }, view.lines[1]],
    });
    expect(edited.statusCode, edited.body).toBe(200);
    const header = (await row('PR_DATA', BOOK, vchNo))[0]!;
    // Round(46.50 + 40.00, 0) = Round(86.50, 0) = 86 (even); tax Round(86 x 18 / 100, 2) = 15.48.
    expect([n(header.HM_AMT), n(header.HM_TAX_AMT)]).toEqual([86, 15.48]);
    const ledger = await row('AC_DATA', BOOK, vchNo);
    const dr = ledger.reduce((s, l) => s + n(l.DR_AMT), 0);
    const cr = ledger.reduce((s, l) => s + n(l.CR_AMT), 0);
    expect(Math.round(dr * 100)).toBe(Math.round(cr * 100));
  });

  // purchase-invoice.refusal.book-not-purchase-family-create, rights.book-family-direct-api (D7)
  it('the server refuses a book outside the purchase family, and accepts PURCHASE and TAG PURCHASE', async () => {
    const counts = async () =>
      (
        (await owner.$queryRawUnsafe(
          `SELECT (SELECT count(*) FROM "PR_DATA" WHERE tenant_id=$1)::int pr,
                  (SELECT count(*) FROM "AC_DATA" WHERE tenant_id=$1)::int ac,
                  (SELECT count(*) FROM "MAIN_STOCK" WHERE tenant_id=$1)::int st`,
          tenantId,
        )) as Array<Record<string, number>>
      )[0];
    const empty = await counts();
    for (const book of ['SL', 'PX', 'PB', 'ZZ']) {
      const refused = await call('POST', '/purchases', purchase([GOLD], { coBook: book }));
      // SL and PB reach the purchase writer (400); PX (not in use) and ZZ (unknown) are refused earlier by the
      // business-scope check as book-unavailable (409). Either way nothing is written.
      expect([400, 409], `${book}: ${refused.body}`).toContain(refused.statusCode);
      if (book === 'SL' || book === 'PB') expect(refused.statusCode, refused.body).toBe(400);
    }
    expect(await counts()).toEqual(empty);
    await create(purchase([GOLD], { coBook: TAG_BOOK }));
    await create(purchase([GOLD]));
  });

  // purchase-invoice.refusal.book-not-purchase-family-edit
  it('an edit sent under a sales book is refused and the voucher is unchanged', async () => {
    const vchNo = await create(purchase([GOLD]));
    const view = (await call('GET', `/purchases/${vchNo}?coBook=${BOOK}`)).json();
    const before = await snapshot();
    const refused = await call('PUT', `/purchases/${vchNo}?coBook=SL`, {
      ...view,
      coBook: 'SL',
      expectedVersion: view.version,
    });
    expect(refused.statusCode, refused.body).toBe(400);
    expect(await snapshot()).toEqual(before);
  });

  // Version token on edit and delete (purchaseVoucher.ts, N51): a missing token is refused, nothing moves.
  it('edit and delete without the version token are refused', async () => {
    const vchNo = await create(purchase([GOLD]));
    const view = (await call('GET', `/purchases/${vchNo}?coBook=${BOOK}`)).json();
    const before = await snapshot();
    const { version: _version, ...withoutVersion } = view;
    const edit = await call('PUT', `/purchases/${vchNo}?coBook=${BOOK}`, {
      ...withoutVersion,
      coBook: BOOK,
    });
    expect(edit.statusCode, edit.body).toBe(400);
    const remove = await call('DELETE', `/purchases/${vchNo}?coBook=${BOOK}`);
    expect(remove.statusCode, remove.body).toBe(400);
    expect(await snapshot()).toEqual(before);
  });

  // purchase-invoice.lookup.books-family-list-server-side (D7, D8)
  it('GET /context/books?family= lists only the in-use books of that family, ordered by name', async () => {
    const list = async (family: string) =>
      (
        (await call('GET', `/context/books?family=${family}`)).json() as Array<{ CO_BOOK: string }>
      ).map((b) => b.CO_BOOK);
    expect(await list('purchase')).toEqual(['PR']);
    expect(await list('tag-purchase')).toEqual(['TPR']);
    const sales = await list('sales');
    expect(sales).toContain('SL');
    expect(sales).not.toContain('PR');
    const unknown = await call('GET', '/context/books?family=nonsense');
    expect(unknown.statusCode).toBe(400);
  });
});
