import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-18 HuId report over HTTP on the isolated database: `GET /reports/huid` and its exports.
 * Seed and expected values: `orchestration/work/WP-18/cases.md` ("Test data"); desktop: `RP_HUID.cs`.
 * Schema widths force short codes: GDRNG (GD-RING), GDCHN (GD-CHAIN), SVCHN (SV-CHAIN), RG (PR-RING),
 * CH (PR-CHAIN), PLN (GR-PLAIN), LNK (GR-LINK), SLV (GR-SILV). Case TG-008 has TAG_NO 'N'.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const T = 'huid-report-route-db';
const TB = 'huid-report-route-db-b';
const PASSWORD = 'Huid-Report-Route!2026';
const SECRET = 'huid-report-route-test-signing-secret-over-32-chars';
const now = new Date();
const Y = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${Y}-${Y + 1}`;
const PRIOR = `${Y - 1}-${Y}`;
const m = (md: string, year = Y) => `${year}-${md}`;
const WIN = { from: m('04-05'), to: m('06-30'), itemType: 'G' };
const IN = { view: 'in', ...WIN };
const OUT = { view: 'out', ...WIN };
const STOCK = { view: 'stock', to: WIN.to, itemType: 'G' };
// prettier-ignore
const GOLD_IN = ['TG-001', 'TG-002', 'TG-003', 'TG-004', 'TG-005', 'TG-006', 'TG-010', 'TG-012', 'TG-013', 'TG-015'];
// prettier-ignore
const GOLD_STOCK = ['TG-001', 'TG-002', 'TG-003', 'TG-004', 'TG-006', 'TG-011', 'TG-013', 'TG-014', 'TG-015', 'TG-016'];
const TOTAL_KEYS = ['qty', 'pcs', 'grwt', 'netWt', 'huWt', 'huWt2', 'huWt3', 'huWt4'] as const;
const SLOT_COLS: Array<[string, string]> = [
  ['HM_ID', 'HM_ID_WT'],
  ['HM_ID2', 'HM_ID2_WT'],
  ['HM_ID3', 'HM_ID3_WT'],
  ['HM_ID4', 'HM_ID4_WT'],
];

interface Origin {
  tag: string;
  it: string;
  d: string;
  s: string;
  n: number;
  c: string;
  p: number;
  g: number;
  w: number;
  ac: string;
  slots?: Array<[string, number] | null>;
  sold?: [string, string];
  back?: string;
  year?: string;
  co?: string;
  lc?: string;
  tenant?: string;
}
// prettier-ignore
const O = (tag: string, it: string, d: string, s: string, n: number, c: string, p: number, g: number, w: number, ac: string, x: Partial<Origin> = {}): Origin =>
  ({ tag, it, d: m(d), s: m(s), n, c, p, g, w, ac, ...x });
// prettier-ignore
const ORIGINS: Origin[] = [
  O('TG-001', 'GDRNG', '04-10', '04-10', 1, 'C1', 1, 10, 9.5, 'V1', { slots: [['HU0001', 0.5]] }),
  O('TG-002', 'GDCHN', '04-12', '04-12', 2, 'C1', 2, 20, 19, 'V2'),
  O('TG-003', 'GDRNG', '04-15', '04-15', 3, 'C2', 1, 8, 7.8, 'V2', { slots: [null, ['HU0003', 0.3]] }),
  O('TG-004', 'GDRNG', '04-16', '04-16', 4, 'C1', 1, 5, 4.9, 'V2', { slots: [['   ', 0]] }),
  O('TG-005', 'GDRNG', '04-20', '04-20', 5, 'C1', 1, 6, 5.8, 'V2', { slots: [['HU0005', 0.4]], sold: [m('04-25'), 'K1'] }),
  O('TG-006', 'GDRNG', '04-22', '04-22', 6, 'C2', 1, 4, 3.9, 'V2', { slots: [['HU0006', 0.2]], sold: [m('04-26'), 'K2'], back: m('04-28') }),
  O('TG-007', 'SVCHN', '05-05', '05-05', 7, 'C1', 3, 30, 29, 'V2', { slots: [['HS0007', 1]] }),
  O('N', 'GDRNG', '05-06', '05-06', 8, 'C1', 1, 2, 2, 'V2'),
  O('TG-009', 'GDRNG', '05-10', '05-10', 9, 'C1', 1, 7, 6.9, 'V2', { year: PRIOR, d: m('05-10', Y - 1), s: m('05-10', Y - 1) }),
  O('TG-010', 'GDRNG', '05-20', '07-15', 10, 'C1', 1, 3, 2.9, 'V2', { slots: [null, ['HU0010', 0.1]] }),
  O('TG-011', 'GDRNG', '04-02', '04-02', 11, 'C1', 1, 9, 8.9, 'V2', { slots: [['HU0011', 0.6]] }),
  O('TG-012', 'GDRNG', '05-25', '05-25', 0, 'C1', 1, 1, 1, 'V2'),
  O('TG-013', 'GDCHN', '04-18', '04-18', 13, 'C2', 1, 12, 11.5, 'V2', { slots: [null, null, null, ['HU0013', 0.25]] }),
  O('TG-014', 'GDRNG', '04-01', '04-01', 14, 'C1', 1, 1, 0.95, 'V2'),
  O('TG-015', 'GDCHN', '06-30', '06-30', 15, 'C1', 1, 2, 1.9, 'V2'),
  O('TG-016', 'GDRNG', '07-05', '06-30', 16, 'C1', 1, 1, 0.9, 'V2'),
  // Sentinels: another company (S1), another location (S2), another tenant (S3).
  O('TG-S1', 'GDRNG', '04-10', '04-10', 21, 'C1', 1, 1, 1, 'V1', { co: '02', slots: [['HUS001', 0.1]] }),
  O('TG-S2', 'GDRNG', '04-10', '04-10', 22, 'C1', 1, 1, 1, 'V1', { lc: '02', slots: [['HUS002', 0.2]] }),
  O('TG-S3', 'GDRNG', '04-10', '04-10', 23, 'C1', 1, 1, 1, 'V1', { tenant: TB, slots: [['HUT001', 0.3]] }),
];

(enabled ? describe : describe.skip)('WP-18 HuId report over HTTP', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookieA = '';
  let cookieB = '';
  let cookieViewer = '';
  let cookieStranger = '';
  const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
  const insert = (tenant: string, table: string, row: Record<string, unknown>) => {
    const cols = Object.keys(row);
    const names = cols.map((c) => `"${c}"`).join(',');
    const marks = cols.map((_, i) => `$${i + 2}`).join(',');
    return exec(
      `INSERT INTO "${table}"(tenant_id,${names}) VALUES($1,${marks})`,
      tenant,
      ...Object.values(row),
    );
  };
  const wipe = async () => {
    const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const row of rows)
      await exec(`DELETE FROM "${row.table_name}" WHERE tenant_id IN ($1,$2)`, T, TB);
  };
  /** `path` is '' for the screen, or '/export.csv' and the like. */
  const run = (params: Record<string, string>, cookie = cookieA, path = '') =>
    app.inject({
      method: 'GET',
      url: `/reports/huid${path}?${new URLSearchParams({ coYear: YEAR, ...params })}`,
      headers: { cookie },
    });
  const tags = async (params: Record<string, string>, cookie?: string) => {
    const r = await run(params, cookie);
    expect(r.statusCode, r.body).toBe(200);
    return (r.json().rows as Array<{ tagNo: string }>).map((row) => row.tagNo);
  };
  const totalsOf = async (params: Record<string, string>) => {
    const r = await run(params);
    expect(r.statusCode, r.body).toBe(200);
    return Object.fromEntries(TOTAL_KEYS.map((k) => [k, Number(r.json().totals[k])]));
  };
  // prettier-ignore
  const barChecksum = async () => (await owner.$queryRawUnsafe<Array<{ sum: string }>>(`SELECT md5(coalesce(string_agg(to_jsonb(b)::text,'|' ORDER BY b.row_id),'')) AS sum FROM "BAR_DETL" b WHERE b.tenant_id=$1 AND b."CO_CODE"='01'`, T))[0]?.sum;
  // prettier-ignore
  const stagingRows = async () => Number((await owner.$queryRawUnsafe<Array<{ n: number }>>(`SELECT count(*)::int AS n FROM "TAG_STOCK_PRINT" WHERE tenant_id=$1`, T))[0]?.n ?? 0);
  const login = async (tenant: string, name: string) => {
    const r = await app.inject({
      method: 'POST',
      url: '/auth/login',
      headers: { 'x-tenant-id': tenant },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
    });
    expect(r.statusCode, r.body).toBe(200);
    const value = r.headers['set-cookie'];
    return (Array.isArray(value) ? value : [value ?? '']).map((p) => p.split(';', 1)[0]).join('; ');
  };
  /** One user with one report caption; `print` sets FRM_PRINT and USER_PRINT. */
  const makeUser = async (tenant: string, name: string, subMenu: string, print: 'Y' | 'N') => {
    // prettier-ignore
    await insert(tenant, 'LOGIN_MAST', { CO_CODE: '01', LOGIN_NAME: name, LOGIN_PWD: await hashPassword(PASSWORD), LOGIN_CATG: 'USER', USER_UPDATE: 'N', USER_DELETE: 'N', USER_PRINT: print, PASSWORD_RESET_REQUIRED: 'N' });
    // prettier-ignore
    await insert(tenant, 'USER_SET', { CO_CODE: '01', LC_CODE: '01', USER_NAME: name, MAIN_MENU: 'Report', SUB_MENU: subMenu, FRM_VIEW: 'Y', FRM_EDIT: 'N', FRM_DELETE: 'N', FRM_PRINT: print });
  };
  // prettier-ignore
  const movement = (o: Origin, sign: '+' | '-', date: string, ac: string, vch: string) => ({ CO_CODE: o.co ?? '01', LC_CODE: o.lc ?? '01', CO_YEAR: o.year ?? YEAR, CO_BOOK: 'PR', VCH_NO: '00001', SR_NO: o.n, VCH_SRNO: o.n, VCH_DATE: date, STK_DATE: o.s, VCH_TYPE: vch, AC_CODE: ac, IT_CODE: o.it, TAG_NO: o.tag, TBL_CODE: o.c, ITM_SIGN: sign, ITM_PCS: o.p, ITM_GWT: o.g, ITM_NWT: o.w });
  const barRow = (o: Origin) => {
    // prettier-ignore
    const row: Record<string, unknown> = { CO_CODE: o.co ?? '01', LC_CODE: o.lc ?? '01', CO_YEAR: o.year ?? YEAR, CO_BOOK: 'PR', VCH_NO: '00001', SR_NO: o.n, VCH_DATE: o.d, STK_DATE: o.s, VCH_TYPE: 'PUR', AC_CODE: o.ac, TAG_NO: o.tag, VCH_SRNO: o.n, IT_CODE: o.it, TBL_CODE: o.c, ITM_PCS: o.p, ITM_GWT: o.g, ITM_NWT: o.w };
    (o.slots ?? []).forEach((slot, i) => {
      const cols = SLOT_COLS[i];
      if (slot && cols) [row[cols[0]], row[cols[1]]] = slot;
    });
    return row;
  };

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, T, '01');
    await seedCompany(runtime, TB, '01');
    // prettier-ignore
    for (const [code, type, pr, gr] of [['GDRNG', 'G', 'RG', 'PLN'], ['GDCHN', 'G', 'CH', 'LNK'], ['SVCHN', 'S', 'CH', 'SLV']])
      await insert(T, 'ITEM_MAST', { CO_CODE: '01', IT_CODE: code, IT_TYPE: type, PR_CODE: pr, GR_CODE: gr });
    for (const [code, name] of [
      ['PLN', 'Plain'],
      ['LNK', 'Link'],
      ['SLV', 'Silver'],
    ])
      await insert(T, 'GROUP_MAST', { CO_CODE: '01', GR_CODE: code, GR_NAME: name });
    for (const o of ORIGINS) {
      const tenant = o.tenant ?? T;
      await insert(tenant, 'BAR_DETL', barRow(o));
      await insert(tenant, 'MAIN_STOCK', movement(o, '+', o.d, o.ac, 'PUR'));
      if (o.sold) await insert(tenant, 'MAIN_STOCK', movement(o, '-', o.sold[0], o.sold[1], 'SAL'));
      if (o.back) await insert(tenant, 'MAIN_STOCK', movement(o, '+', o.back, o.ac, 'SRT'));
    }
    await makeUser(T, 'reporter', 'HuId Report', 'Y');
    await makeUser(T, 'viewer', 'HuId Report', 'N');
    await makeUser(T, 'stranger', 'Movement', 'N');
    await makeUser(TB, 'reporter', 'HuId Report', 'Y');
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    cookieA = await login(T, 'reporter');
    cookieB = await login(TB, 'reporter');
    cookieViewer = await login(T, 'viewer');
    cookieStranger = await login(T, 'stranger');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  // RP_HUID.cs:1761 {{AND C.VCH_DATE >= '}}: TG-011 and TG-014 are before From; TG-016 is after To.
  it('huid-report.filter.in-date-window', async () => expect(await tags(IN)).toEqual(GOLD_IN));

  // RP_HUID.cs:1795 {{AND A.ITM_SIGN = '-'}}: the two sales; the TG-006 return is not an Out row.
  it('huid-report.filter.out-date-window', async () =>
    expect(await tags(OUT)).toEqual(['TG-005', 'TG-006']));

  // RP_HUID.cs:1838 {{AND C.STK_DATE <= '}}: From is ignored; TG-010 (stock 15/07) is absent.
  it('huid-report.filter.stock-to-date-only', async () =>
    expect(await tags({ ...STOCK, from: m('06-20') })).toEqual(GOLD_STOCK));

  // RP_HUID.cs:1761 {{AND C.TAG_NO <> 'N'}}; RP_HUID.cs:1795 {{AND A.TAG_NO <> 'N'}}; RP_HUID.cs:1838 {{AND A.TAG_NO <> 'N'}}
  it('huid-report.filter.tag-n-excluded', async () => {
    const from = m('04-01');
    for (const params of [
      { ...IN, from },
      { ...OUT, from },
      { ...STOCK, from },
    ])
      expect(await tags(params)).not.toContain('N');
  });

  // RP_HUID.cs:1764 {{DC_Main.RsQry += " AND C.HM_ID <> ''";}}. TG-004 (blank spaces) has its own case.
  it('huid-report.filter.hallmark-with-first-slot', async () => {
    expect(await tags({ ...IN, hallmark: 'with' })).toEqual(['TG-001', 'TG-005', 'TG-006']);
    expect((await run({ ...IN, hallmark: 'maybe' })).statusCode).toBe(400);
  });

  // RP_HUID.cs:1768 {{DC_Main.RsQry += "AND C.HM_ID = '' ";}}
  it('huid-report.filter.hallmark-without-first-slot', async () =>
    expect(await tags({ ...IN, hallmark: 'without' })).toEqual([
      'TG-002',
      'TG-003',
      'TG-010',
      'TG-012',
      'TG-013',
      'TG-015',
    ]));

  // RP_HUID.cs:1757 {{AND HM_ID4 Is NULL}}: the first column of TG-003, TG-010 and TG-013 is NULL in the seed.
  it('huid-report.filter.hallmark-slot-two-to-four-counts-as-without', async () => {
    const rows = await owner.$queryRawUnsafe<Array<{ TAG_NO: string }>>(
      `SELECT "TAG_NO" FROM "BAR_DETL" WHERE tenant_id=$1 AND "HM_ID" IS NULL AND "TAG_NO" IN ('TG-003','TG-010','TG-013') ORDER BY 1`,
      T,
    );
    expect(rows.map((r) => r.TAG_NO)).toEqual(['TG-003', 'TG-010', 'TG-013']);
    expect(await tags({ ...IN, hallmark: 'without' })).toEqual(
      expect.arrayContaining(['TG-003', 'TG-010', 'TG-013']),
    );
  });

  // RP_HUID.cs:1784 {{DC_Main.RsQry = DC_Main.RsQry + "AND C.TAG_NO =  '" + tTagNo.Text + "'";}}: exact in In and Stock; no sale row for TG-001.
  it('huid-report.filter.tag-no-exact', async () => {
    expect(await tags({ ...IN, tagNo: 'TG-001' })).toEqual(['TG-001']);
    expect(await tags({ ...STOCK, tagNo: 'TG-001' })).toEqual(['TG-001']);
    expect(await tags({ ...OUT, tagNo: 'TG-001' })).toEqual([]);
  });

  // RP_HUID.cs:1778 {{if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)}}
  it('huid-report.filter.item-type-silver', async () =>
    expect(await tags({ ...IN, itemType: 'S' })).toEqual(['TG-007']));

  // RP_HUID.cs:1772 {{DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + AryPrCode[cboProduct.SelectedIndex] + "'";}}
  it('huid-report.filter.product-ring', async () =>
    expect(await tags({ ...IN, product: 'RG' })).toEqual([
      'TG-001',
      'TG-003',
      'TG-004',
      'TG-005',
      'TG-006',
      'TG-010',
      'TG-012',
    ]));

  // RP_HUID.cs:1815 {{DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + AryGrCode[cboGroup.SelectedIndex] + "'";}}
  it('huid-report.filter.group-link', async () =>
    expect(await tags({ ...IN, group: 'LNK' })).toEqual(['TG-002', 'TG-013', 'TG-015']));

  // RP_HUID.cs:1761 {{1 AS Qty,C.ITM_PCS as Pcs}}: the counter is a column, never a condition.
  it('huid-report.filter.counter-absent', async () =>
    expect(await tags({ ...IN, counter: 'C2' })).toEqual(GOLD_IN));

  // RP_HUID.cs:1761: the In conditions name no item code.
  it('huid-report.filter.item-code-absent', async () =>
    expect(await tags({ ...IN, itCode: 'SVCHN' })).toEqual(GOLD_IN));

  // RP_HUID.cs:1669 {{dataView.RowFilter = "HuId Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";}}
  it('huid-report.filter.search-first-column-set', async () =>
    expect(await tags({ ...IN, search: 'HU00' })).toEqual(['TG-001', 'TG-005', 'TG-006']));

  // RP_HUID.cs:1675 {{dataView.RowFilter = "HuId2 Like  '%" + ((TextEdit)tSerchAll).Text + "%' ";}}
  it('huid-report.filter.search-second-column-match', async () =>
    expect(await tags({ ...IN, search: 'HU0003' })).toEqual(['TG-003']));

  // RP_HUID.cs:1790 {{DC_Main.RsQry += "ORDER BY C.TAG_NO";}}
  it('huid-report.order.tag-no-ascending', async () => expect(await tags(IN)).toEqual(GOLD_IN));

  // RP_HUID.cs:2068 {{((ColumnView)GridView1).Columns["Qty"].Summary.Add((SummaryItemType)0, "Qty", "{0}");}}
  // Pcs 11; Grwt 71; NetWt 68.2; HuWt 0.5+0.4+0.2=1.1; HuWt2 0.3+0.1=0.4; HuWt4 0.25.
  it('huid-report.total.in-window-sums', async () =>
    expect(await totalsOf(IN)).toEqual({
      qty: 10,
      pcs: 11,
      grwt: 71,
      netWt: 68.2,
      huWt: 1.1,
      huWt2: 0.4,
      huWt3: 0,
      huWt4: 0.25,
    }));

  // RP_HUID.cs:2096 {{((ColumnView)GridView1).Columns["HuWt4"].Summary.Add((SummaryItemType)0, "HuWt4", "{0}");}}
  // Qty 2; Pcs 2; Grwt 10; NetWt 9.7; HuWt 0.4+0.2=0.6 (the origin's first slot).
  it('huid-report.total.out-window-sums', async () =>
    expect(await totalsOf(OUT)).toEqual({
      qty: 2,
      pcs: 2,
      grwt: 10,
      netWt: 9.7,
      huWt: 0.6,
      huWt2: 0,
      huWt3: 0,
      huWt4: 0,
    }));

  // RP_HUID.cs:1873 {{HAVING SUM(CASE WHEN ITM_SIGN='+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0}}
  it('huid-report.total.stock-rule-sum', async () => expect(await tags(STOCK)).toEqual(GOLD_STOCK));

  // RP_HUID.cs:1873: TG-012 has serial 0, so its sum is 0 and it is not in stock.
  it('huid-report.total.stock-rule-srno-zero', async () =>
    expect(await tags(STOCK)).not.toContain('TG-012'));

  // RP_HUID.cs:1873: TG-005 sums to 5-5=0 (out); TG-006 sums to 6-6+6=6 (in).
  it('huid-report.total.stock-rule-sold-and-returned', async () => {
    const list = await tags(STOCK);
    expect(list).toContain('TG-006');
    expect(list).not.toContain('TG-005');
  });

  // RP_HUID.cs:1761 {{AND C.VCH_DATE >= '}}: no date lies between the bounds. Stock keeps TG-011 and TG-014.
  it('huid-report.invalid.from-after-to-empty', async () => {
    expect(await tags({ ...IN, from: WIN.to, to: WIN.from })).toEqual([]);
    expect(await tags({ ...OUT, from: WIN.to, to: WIN.from })).toEqual([]);
    expect(await tags({ ...STOCK, to: m('04-05') })).toEqual(['TG-011', 'TG-014']);
  });

  // RP_HUID.cs:1876 {{RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);}}, then RP_HUID.cs:1877 {{DGV_FILL();}}
  it('huid-report.invalid.empty-result-no-message', async () => {
    const r = await run({ ...IN, itemType: 'S', product: 'RG' });
    expect(r.statusCode, r.body).toBe(200);
    expect(r.json().rows).toEqual([]);
    expect(r.json()).not.toHaveProperty('message');
  });

  // RP_HUID.cs:1669: the desktop joins the text into the filter; the web treats O'N as literal text.
  it('huid-report.invalid.search-apostrophe-no-error', async () => {
    const r = await run({ ...IN, search: "O'N" });
    expect(r.statusCode, r.body).toBe(200);
    expect(r.json().rows).toEqual([]);
  });

  it('huid-report.invalid.missing-view-and-bad-date-400', async () => {
    expect((await run({ from: WIN.from, to: WIN.to })).statusCode).toBe(400);
    expect((await run({ ...IN, from: '31/02/2026' })).statusCode).toBe(400);
  });

  // RP_HUID.cs:1761 {{WHERE C.CO_CODE = '}}: company 02 never appears, in a view or in the CSV.
  it('huid-report.scope.other-company-never-appears', async () => {
    for (const params of [IN, OUT, STOCK]) expect(await tags(params)).not.toContain('TG-S1');
    const csv = await run(IN, cookieA, '/export.csv');
    expect(csv.statusCode, csv.body).toBe(200);
    expect(csv.body).not.toContain('HUS001');
  });

  // RP_HUID.cs:1761 {{AND C.LC_CODE = '}}
  it('huid-report.scope.other-location-never-appears', async () => {
    for (const params of [IN, OUT, STOCK]) expect(await tags(params)).not.toContain('TG-S2');
  });

  // RP_HUID.cs:1838 {{AND A.CO_YEAR = '}}; RP_HUID.cs:1795 {{AND A.CO_YEAR = '}}
  it('huid-report.scope.prior-year-tag-never-appears', async () => {
    expect(await tags(OUT)).not.toContain('TG-009');
    expect(await tags(STOCK)).not.toContain('TG-009');
  });

  // The tenant boundary holds through row-level security and the tenant_id filter.
  it('huid-report.scope.other-tenant-never-appears', async () => {
    const win = { view: 'in', from: WIN.from, to: WIN.to };
    expect(await tags(win)).not.toContain('TG-S3');
    expect(await tags(win, cookieB)).toEqual(['TG-S3']);
  });

  it('huid-report.rights.view-refused-without-view-right', async () =>
    expect((await run(IN, cookieStranger)).statusCode).toBe(403));

  // RP_HUID.cs:1359 {{if (Operators.CompareString(UserPrint, "Y", false) != 0)}}: the web refuses with 403.
  it.each(['csv', 'xlsx', 'pdf'])(
    'huid-report.rights.print-refused-without-print-right.%s',
    async (kind) => {
      expect((await run(IN, cookieViewer)).statusCode).toBe(200);
      const r = await run(IN, cookieViewer, `/export.${kind}`);
      expect(r.statusCode, r.body).toBe(403);
      expect(r.json()).toEqual({ error: 'forbidden', action: 'print' });
    },
  );

  // RP_HUID.cs:1754 {{UPDATE BAR_DETL SET HM_ID = '' WHERE CO_CODE = '}}: the web must not write.
  it('huid-report.write.view-leaves-bar-detl-unchanged', async () => {
    const before = await barChecksum();
    for (const params of [IN, OUT, STOCK]) await tags(params);
    expect(await barChecksum()).toEqual(before);
    const nulls = await owner.$queryRawUnsafe<Array<{ ok: boolean }>>(
      `SELECT ("HM_ID2" IS NULL) AS ok FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TG-004'`,
      T,
    );
    expect(nulls[0]?.ok).toBe(true);
  });

  // RP_HUID.cs:2140 {{DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");}}: the web keeps no staging rows.
  it('huid-report.write.print-leaves-no-staging-rows', async () => {
    const staging = await stagingRows();
    const bar = await barChecksum();
    const pdf = await run(STOCK, cookieA, '/export.pdf');
    expect(pdf.statusCode, pdf.body).toBe(200);
    expect(await stagingRows()).toBe(staging);
    expect(await barChecksum()).toEqual(bar);
  });

  // RP_HUID.cs:1815 {{DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + AryGrCode[cboGroup.SelectedIndex] + "'";}}: matched by code, so a renamed group keeps its rows.
  it('huid-report.history.group-renamed-live-master', async () => {
    const first = await tags({ ...IN, group: 'LNK' });
    await exec(
      `UPDATE "GROUP_MAST" SET "GR_NAME"='Link renamed' WHERE tenant_id=$1 AND "GR_CODE"='LNK'`,
      T,
    );
    expect(await tags({ ...IN, group: 'LNK' })).toEqual(first);
    expect(first).toEqual(['TG-002', 'TG-013', 'TG-015']);
  });
});
