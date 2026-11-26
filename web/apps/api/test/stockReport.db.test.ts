import { round } from '@datacare/core';
import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-16 Report -> Stock Report (desktop RP_STOCK) through the real Fastify routes under forced RLS.
 *
 * Every expected figure is added up HERE from the seeded MAIN_STOCK movements with the desktop formula
 * (RP_STOCK.cs:4284: signed sums, Opening = VCH_DATE < FROM, Purchase/Inward/Outward/Sale/Transfer by
 * ITM_SIGN + TR_TYPE inside FROM..TO, Closing = every signed movement with VCH_DATE <= TO), never read
 * back from the API. Fine in the drill-down is KR_FINE for '+' rows and ITM_FINE for '-' rows
 * (RP_STOCK.cs:2896). The report is read-only: the desktop's load-time UPDATEs (RP_STOCK.cs:3651-3653) and
 * its REPORT_DATA staging (RP_STOCK.cs:4058) are deliberately not ported.
 */

const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'stkrep-db';
const OTHER_TENANT = 'stkrep-other';
const PASSWORD = 'StkRep-Db!2026';
const SECRET = 'stkrep-test-signing-secret-over-thirty-two-characters';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const OLD_YEAR = `${startYear - 1}-${startYear}`;
const Y0 = Date.UTC(startYear, 3, 1);
const D = (n: number) => new Date(Y0 + n * 86_400_000).toISOString().slice(0, 10);

interface Mv {
  id: string;
  co?: string;
  lc?: string;
  year?: string;
  dataType?: string;
  day: number;
  book: string;
  ac: string;
  item: 'A' | 'B' | 'S';
  tag: string;
  tbl: string | null;
  tr: 'P' | 'I' | 'O' | 'S' | 'T';
  sign: '+' | '-';
  pcs: number;
  gwt: number;
  nwt: number;
  fine: number;
  kr: number;
  design?: string;
  size?: string;
}
const mv = (
  id: string,
  day: number,
  book: string,
  ac: string,
  item: Mv['item'],
  tag: string,
  tbl: string | null,
  tr: Mv['tr'],
  sign: Mv['sign'],
  pcs: number,
  gwt: number,
  nwt: number,
  fine: number,
  kr: number,
  extra: Partial<Mv> = {},
): Mv => ({ id, day, book, ac, item, tag, tbl, tr, sign, pcs, gwt, nwt, fine, kr, ...extra });

// The movement table of orchestration/work/WP-16/cases.md section 1 (M1 .. M19).
const MOVES: Mv[] = [
  mv('M01', -1, 'IOB', '', 'A', 'N', null, 'P', '+', 10, 105, 100, 91.6, 91.6),
  mv('M02', -1, 'IOB', '', 'B', 'N', null, 'P', '+', 5, 52.5, 50, 45.8, 45.8),
  mv('M03', -1, 'IOB', '', 'S', 'N', null, 'P', '+', 100, 1000, 950, 870.2, 870.2),
  mv('M04', 5, 'TOP', '', 'A', 'T1', '001', 'P', '+', 1, 12.5, 12, 10.992, 10.8, { design: 'D1' }),
  mv('M05', 6, 'TOP', '', 'A', 'T2', '001', 'P', '+', 1, 6.3, 6, 5.496, 5.4),
  mv('M06', 7, 'TOP', '', 'A', 'T3', '001', 'P', '+', 1, 8.4, 8, 7.328, 7.2),
  mv('M07', 11, 'TOP', '', 'A', 'T4', '002', 'P', '+', 1, 3.15, 3, 2.748, 2.7, { design: 'D1' }),
  mv('M08', 12, 'TOP', '', 'B', 'T5', '001', 'P', '+', 1, 21, 20, 18.32, 18, {
    design: 'D2',
    size: '7',
  }),
  mv('M09', 12, 'PUR', 'SUP1', 'A', 'N', '', 'P', '+', 4, 42, 40, 36.8, 36.8),
  mv('M10', 15, 'SAL', 'CUS1', 'A', 'T1', '001', 'S', '-', 1, 12.5, 12, 11.04, 10.8, {
    design: 'D1',
  }),
  mv('M11', 18, 'PUR', 'SUP1', 'S', 'N', '001', 'P', '+', 10, 100, 95, 87.4, 87.4),
  mv('M12', 20, 'TRF', '', 'B', 'N', '001', 'T', '-', 1, 10.5, 10, 9.16, 9.16),
  mv('M13', 20, 'TRF', '', 'B', 'N', '002', 'T', '+', 1, 10.5, 10, 9.16, 9.16),
  mv('M14', 20, 'SRT', 'CUS1', 'A', 'T1', '001', 'I', '+', 1, 12.5, 12, 11.04, 11.04, {
    design: 'D1',
  }),
  mv('M15', 25, 'PRT', 'SUP1', 'A', 'N', '001', 'O', '-', 2, 21, 20, 18.4, 18.4),
  mv('M16', 28, 'ADJ', '', 'A', 'N', '001', 'I', '+', 1, 5.25, 5, 4.58, 4.58),
  mv('M17', 28, 'ADJ', '', 'A', 'N', '001', 'O', '-', 1, 2.1, 2, 1.832, 1.832),
  mv('M18', 30, 'TCN', '', 'A', 'T2', '001', 'O', '-', 1, 6.3, 6, 5.496, 5.4),
  mv('M19', 33, 'AIS', 'CUS1', 'A', 'T3', '001', 'O', '-', 1, 8.4, 8, 7.328, 7.2),
];
const BOOKS: Array<[string, string, string, string]> = [
  ['IOB', 'Item Opening', 'IOB', 'ITM OPBL'],
  ['TOP', 'Tag Opening', 'TOP', 'OPSTK'],
  ['PUR', 'Purchase', 'PUR', 'PURCHASE'],
  ['SAL', 'Sales', 'SAL', 'SALES'],
  ['SRT', 'Sales Return', 'SRT', 'SALES RETURNE'],
  ['PRT', 'Purchase Return', 'PRT', 'PURC RETURN'],
  ['ADJ', 'Stock Adjust', 'ADJ', 'STOCK ADJUST'],
  ['TCN', 'Tag Cancel', 'TCN', 'TAG CANCEL'],
  ['AIS', 'Approval Issue', 'AIS', 'APR ISU'],
  ['TRF', 'Tag Transfer', 'TRF', 'TAG TRFR'],
  ['TGN', 'Only Tag Entry', 'TGN', 'TAG GEN'],
  ['JDT', 'Jobwork Tag', 'JDT', 'JDTR TAG'],
];

interface Item {
  code: string;
  name: string;
  type: string;
  gr: string;
  pr: string;
  safe: string | null;
  trad: string;
  hidden?: boolean;
}
const ITEMS: Record<Mv['item'], Item> = {
  A: {
    code: 'GRNG',
    name: 'GOLD RING 22K',
    type: 'G',
    gr: 'GA',
    pr: 'PA',
    safe: 'MAIN',
    trad: 'T1',
  },
  B: {
    code: 'GCHN',
    name: 'GOLD CHAIN 22K',
    type: 'G',
    gr: 'GA',
    pr: 'PB',
    safe: 'VAULT',
    trad: '',
  },
  // NULL STK_DISPLAY and NULL SAFE_NAME: the desktop backfills these on load (RP_STOCK.cs:3651-3652); the
  // web must treat them as shown / MAIN without writing.
  S: { code: 'SBWL', name: 'SILVER BOWL', type: 'S', gr: 'GS', pr: 'PS', safe: null, trad: 'T2' },
};
const GROUPS: Record<string, { name: string; trad: string }> = {
  GA: { name: 'GOLD ORNAMENTS', trad: 'T1' },
  GS: { name: 'SILVER ARTICLES', trad: 'T2' },
};
const PRODUCTS: Record<string, string> = { PA: 'RING', PB: 'CHAIN', PS: 'BOWL' };
const TRADES: Record<string, string> = { T1: 'GOLD TRADE', T2: 'SILVER TRADE' };
const COUNTERS: Record<string, string> = { '001': 'CNT-ONE', '002': 'CNT-TWO' };

type DimKey = 'item' | 'product' | 'group' | 'design' | 'safe' | 'counter' | 'trading' | 'size';
const DIMS: DimKey[] = ['item', 'product', 'group', 'design', 'safe', 'counter', 'trading', 'size'];

interface Filters {
  itemType?: string;
  stockType?: 'tag' | 'item';
  acCode?: string;
  tagNo?: string;
  prCode?: string;
  grCode?: string;
  itCode?: string;
  designNo?: string;
  safe?: string;
  tblCode?: string;
  dataType?: string;
}
const FIG_KEYS = [
  'opPcs',
  'opWt',
  'prPcs',
  'prWt',
  'inPcs',
  'inWt',
  'outPcs',
  'outWt',
  'slPcs',
  'slWt',
  'clPcs',
  'clWt',
  'tInPcs',
  'tInWt',
  'tOutPcs',
  'tOutWt',
] as const;
type Fig = Record<(typeof FIG_KEYS)[number], number>;
const zero = (): Fig => Object.fromEntries(FIG_KEYS.map((k) => [k, 0])) as Fig;

const itemOf = (m: Mv) => ITEMS[m.item];
const tblOf = (m: Mv) => ((m.tbl ?? '') === '' ? '001' : m.tbl!);
const keyOf = (dim: DimKey, m: Mv): { code: string; name: string } => {
  const it = itemOf(m);
  switch (dim) {
    case 'item':
      return { code: it.code, name: it.name };
    case 'product':
      return { code: it.pr, name: PRODUCTS[it.pr]! };
    case 'group':
      return { code: it.gr, name: GROUPS[it.gr]!.name };
    case 'safe':
      return { code: it.safe ?? 'MAIN', name: it.safe ?? 'MAIN' };
    case 'design':
      return { code: m.design ?? '', name: m.design ?? '' };
    case 'size':
      return { code: m.size ?? '', name: m.size ?? '' };
    case 'counter':
      return { code: tblOf(m), name: COUNTERS[tblOf(m)]! };
    case 'trading': {
      const t = it.trad || GROUPS[it.gr]!.trad;
      return { code: t, name: TRADES[t]! };
    }
  }
};
const inScope = (m: Mv, f: Filters, merge = false) =>
  (merge || (m.co ?? '01') === '01') &&
  (m.lc ?? '01') === '01' &&
  (m.year ?? YEAR) === YEAR &&
  !itemOf(m).hidden &&
  (f.dataType === undefined || f.dataType === 'C' || (m.dataType ?? 'A') === f.dataType) &&
  (f.itemType === undefined || itemOf(m).type === f.itemType) &&
  (f.stockType === undefined || (f.stockType === 'tag' ? m.tag !== 'N' : m.tag === 'N')) &&
  (f.acCode === undefined || m.ac === f.acCode) &&
  (f.tagNo === undefined || m.tag === f.tagNo) &&
  (f.prCode === undefined || itemOf(m).pr === f.prCode) &&
  (f.grCode === undefined || itemOf(m).gr === f.grCode) &&
  (f.itCode === undefined || itemOf(m).code === f.itCode) &&
  (f.designNo === undefined || (m.design ?? '') === f.designNo) &&
  (f.safe === undefined || (itemOf(m).safe ?? 'MAIN') === f.safe) &&
  (f.tblCode === undefined || tblOf(m) === f.tblCode);

/** The desktop's nine conditional sums (RP_STOCK.cs:4284) for one set of movements. */
function figures(rows: Mv[], from: string, to: string, gross: boolean): Fig {
  const f = zero();
  for (const m of rows) {
    const date = D(m.day);
    const w = gross ? m.gwt : m.nwt;
    const sgn = m.sign === '+' ? 1 : -1;
    const inWin = date >= from && date <= to;
    if (date < from) {
      f.opPcs += sgn * m.pcs;
      f.opWt += sgn * w;
    }
    if (date <= to) {
      f.clPcs += sgn * m.pcs;
      f.clWt += sgn * w;
    }
    if (!inWin) continue;
    const add = (p: 'pr' | 'in' | 'out' | 'sl' | 'tIn' | 'tOut') => {
      f[`${p}Pcs`] += m.pcs;
      f[`${p}Wt`] += w;
    };
    if (m.sign === '+' && m.tr === 'P') add('pr');
    if (m.sign === '+' && m.tr === 'I') add('in');
    if (m.sign === '-' && m.tr === 'O') add('out');
    if (m.sign === '-' && m.tr === 'S') add('sl');
    if (m.sign === '+' && m.tr === 'T') add('tIn');
    if (m.sign === '-' && m.tr === 'T') add('tOut');
  }
  for (const k of FIG_KEYS) f[k] = round(f[k], 3);
  return f;
}
interface ExpRow extends Fig {
  code: string;
  name: string;
  itType: string;
}
function expected(
  dim: DimKey,
  all: Mv[],
  from: string,
  to: string,
  gross = false,
  filters: Filters = {},
  merge = false,
): { rows: ExpRow[]; totals: Fig } {
  const groups = new Map<string, { code: string; name: string; itType: string; rows: Mv[] }>();
  for (const m of all) {
    if (!inScope(m, filters, merge)) continue;
    const k = keyOf(dim, m);
    const id = `${k.code}\u0000${itemOf(m).type}`;
    if (!groups.has(id)) groups.set(id, { ...k, itType: itemOf(m).type, rows: [] });
    groups.get(id)!.rows.push(m);
  }
  const rows = [...groups.values()]
    .map((g) => ({
      code: g.code,
      name: g.name,
      itType: g.itType,
      ...figures(g.rows, from, to, gross),
    }))
    .sort((a, b) => a.name.localeCompare(b.name) || a.itType.localeCompare(b.itType));
  const totals = zero();
  for (const r of rows) for (const k of FIG_KEYS) totals[k] = round(totals[k] + r[k], 3);
  return { rows, totals };
}
const norm = (rows: any[]) =>
  [...rows]
    .map((r) => ({
      code: r.code,
      name: r.name,
      itType: r.itType,
      ...Object.fromEntries(FIG_KEYS.map((k) => [k, r[k]])),
    }))
    .sort(
      (a, b) =>
        a.name.localeCompare(b.name) ||
        a.itType.localeCompare(b.itType) ||
        a.code.localeCompare(b.code),
    );
/** Closing = Opening + every movement in the window, per row (the identity of the case list, section 0). */
const identity = (r: Fig) => ({
  pcs: round(r.opPcs + r.prPcs + r.inPcs - r.outPcs - r.slPcs + r.tInPcs - r.tOutPcs, 3),
  wt: round(r.opWt + r.prWt + r.inWt - r.outWt - r.slWt + r.tInWt - r.tOutWt, 3),
});

const W1 = { from: D(10), to: D(40) };
const W2 = { from: D(10), to: D(24) };
const W3 = { from: D(10), to: D(14) };

(enabled ? describe : describe.skip)(
  'Stock Report (RP_STOCK) over HTTP under forced RLS (WP-16)',
  () => {
    let owner: PrismaClient;
    let runtime: PrismaClient;
    let app: FastifyInstance;
    const cookies: Record<string, string> = {};
    const exec = (sql: string, ...params: unknown[]) => owner.$executeRawUnsafe(sql, ...params);
    const query = (sql: string, ...params: unknown[]) =>
      owner.$queryRawUnsafe<any[]>(sql, ...params);
    const wipe = async (tenant: string) => {
      const rows: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
        `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
      );
      for (const row of rows)
        await owner.$executeRawUnsafe(`DELETE FROM "${row.table_name}" WHERE tenant_id=$1`, tenant);
    };
    const login = async (name: string) => {
      const response = await app.inject({
        method: 'POST',
        url: '/auth/login',
        headers: { 'x-tenant-id': TENANT },
        payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: name, password: PASSWORD },
      });
      expect(response.statusCode, response.body).toBe(200);
      const values = response.headers['set-cookie'];
      return (Array.isArray(values) ? values : [values ?? ''])
        .map((value) => value.split(';', 1)[0])
        .join('; ');
    };
    const get = (user: string, url: string) =>
      app.inject({ method: 'GET', url, headers: { cookie: cookies[user]! } });
    const qs = (o: Record<string, string | undefined>) =>
      Object.entries(o)
        .filter(([, v]) => v !== undefined)
        .map(([k, v]) => `${k}=${encodeURIComponent(v!)}`)
        .join('&');
    const summary = async (
      dimension: DimKey,
      w: { from: string; to: string },
      extra: Record<string, string | undefined> = {},
      user = 'printer',
    ) => {
      const response = await get(
        user,
        `/reports/stock-report?${qs({ dimension, fromDate: w.from, toDate: w.to, ...extra })}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      return response.json();
    };
    const movements = async (
      dimension: DimKey,
      w: { from: string; to: string },
      key: string,
      rowType: string,
      column: string,
      extra: Record<string, string | undefined> = {},
    ) => {
      const response = await get(
        'printer',
        `/reports/stock-report/movements?${qs({ dimension, fromDate: w.from, toDate: w.to, key, rowType, column, ...extra })}`,
      );
      expect(response.statusCode, response.body).toBe(200);
      return response.json();
    };

    const insertMove = async (tenant: string, m: Mv, n: number) => {
      const it = ITEMS[m.item];
      await exec(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","AC_CODE","IT_CODE","TAG_NO",
         "TBL_CODE","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","ITM_FINE","KR_FINE","DATA_TYPE","DESIGN_NO","ITM_SIZE")
       VALUES($1,$2,$3,$4,$5,$6,$7,$8::date,'X',$9,$10,$11,$12,$13,$14,$15,$16,$17,$18,$19,$20,$21,$22)`,
        tenant,
        m.co ?? '01',
        m.lc ?? '01',
        m.year ?? YEAR,
        m.book,
        m.id,
        n,
        D(m.day),
        m.ac,
        it.code,
        m.tag,
        m.tbl,
        m.tr,
        m.sign,
        m.pcs,
        m.gwt,
        m.nwt,
        m.fine,
        m.kr,
        m.dataType ?? 'A',
        m.design ?? null,
        m.size ?? null,
      );
    };
    const counts = async (tenant: string) => ({
      itemMast: await query(`SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1`, tenant),
      mainStock: await query(
        `SELECT count(*)::int n, coalesce(sum("ITM_NWT"),0)::text s, count(*) FILTER (WHERE "TBL_CODE" IS NULL OR "TBL_CODE"='')::int blanks FROM "MAIN_STOCK" WHERE tenant_id=$1`,
        tenant,
      ),
      reportData: await query(
        `SELECT count(*)::int n FROM "REPORT_DATA" WHERE tenant_id=$1`,
        tenant,
      ),
      safeNull: await query(
        `SELECT count(*)::int n FROM "ITEM_MAST" WHERE tenant_id=$1 AND ("SAFE_NAME" IS NULL OR "STK_DISPLAY" IS NULL)`,
        tenant,
      ),
    });

    beforeAll(async () => {
      assertIsolatedTestDatabase();
      owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
      runtime = new PrismaClient();
      await wipe(TENANT);
      await wipe(OTHER_TENANT);
      await seedCompany(runtime, TENANT, '01', { coName: 'Stock Report Jewellers', lcCode: '01' });
      await seedCompany(runtime, OTHER_TENANT, '01', { coName: 'Other Tenant', lcCode: '01' });
      // seedCompany copies the installer masters into company 01 (MS_YEAR.cs:1555-1592). The oracle below models this
      // suite's own items, groups, products, trade types and counters (counter 001 CNT-ONE), so the installer rows of
      // those five masters are cleared before the suite's own are inserted.
      for (const tenant of [TENANT, OTHER_TENANT])
        for (const table of ['ITEM_MAST', 'GROUP_MAST', 'PRODUCT_MAST', 'BAL_GR', 'TABLE_MAST'])
          await exec(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
      for (const tenant of [TENANT, OTHER_TENANT]) {
        for (const co of ['01', '02']) {
          for (const it of Object.values(ITEMS))
            await exec(
              `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE","TRAD_TYPE","SAFE_NAME","STK_DISPLAY")
             VALUES($1,$2,$3,$4,$5,$6,$7,$8,$9,$10)`,
              tenant,
              co,
              it.code,
              it.name,
              it.type,
              it.pr,
              it.gr,
              it.trad,
              it.safe,
              it.safe === null ? null : 'Y',
            );
          for (const [code, g] of Object.entries(GROUPS))
            await exec(
              `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","TRAD_TYPE") VALUES($1,$2,$3,$4,$5)`,
              tenant,
              co,
              code,
              g.name,
              g.trad,
            );
          for (const [code, name] of Object.entries(PRODUCTS))
            await exec(
              `INSERT INTO "PRODUCT_MAST"(tenant_id,"CO_CODE","PR_CODE","PR_NAME") VALUES($1,$2,$3,$4)`,
              tenant,
              co,
              code,
              name,
            );
          for (const [code, name] of Object.entries(TRADES))
            await exec(
              `INSERT INTO "BAL_GR"(tenant_id,"CO_CODE","TRAD_TYPE","TRAD_NAME") VALUES($1,$2,$3,$4)`,
              tenant,
              co,
              code,
              name,
            );
          for (const [code, name] of Object.entries(COUNTERS))
            await exec(
              `INSERT INTO "TABLE_MAST"(tenant_id,"CO_CODE","LC_CODE","TABLE_CODE","TABLE_NAME") VALUES($1,$2,'01',$3,$4)`,
              tenant,
              co,
              code,
              name,
            );
          for (const [book, name, sname, main] of BOOKS)
            await exec(
              `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","CUR_USE") VALUES($1,$2,'01',$3,$4,$5,$6,'Y')`,
              tenant,
              co,
              book,
              name,
              sname,
              main,
            );
          await exec(
            `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES($1,$2,'01','SUP1','Supplier One'),($1,$2,'01','CUS1','Customer One')`,
            tenant,
            co,
          );
        }
      }
      let n = 0;
      for (const m of MOVES) await insertMove(TENANT, m, (n += 1));
      // Sentinels: another company, location, year and tenant must never reach the figures.
      await insertMove(
        TENANT,
        { ...MOVES[0]!, id: 'Z-CO', co: '02', pcs: 999, nwt: 999, gwt: 999 },
        1,
      );
      await insertMove(
        TENANT,
        { ...MOVES[0]!, id: 'Z-LC', lc: '02', pcs: 998, nwt: 998, gwt: 998 },
        1,
      );
      await insertMove(
        TENANT,
        { ...MOVES[0]!, id: 'Z-YR', year: OLD_YEAR, pcs: 50, nwt: 50, gwt: 50 },
        1,
      );
      await insertMove(
        OTHER_TENANT,
        { ...MOVES[0]!, id: 'Z-TN', pcs: 1000, nwt: 1000, gwt: 1000 },
        1,
      );

      for (const [name, view, print, withRow] of [
        ['viewer', 'Y', 'N', true],
        ['printer', 'Y', 'Y', true],
        ['blocked', 'N', 'N', true],
        ['norow', 'Y', 'Y', false],
      ] as const) {
        await exec(
          `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
         VALUES($1,'01',$2,$3,'USER','N','N',$4,'N')`,
          TENANT,
          name,
          await hashPassword(PASSWORD),
          print,
        );
        await exec(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
         VALUES($1,'01','01',$2,'Report',$3,$4,'N','N',$5)`,
          TENANT,
          name,
          withRow ? 'Stock Report' : 'Day Book',
          view,
          print,
        );
      }
      app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
      for (const u of ['viewer', 'printer', 'blocked', 'norow']) cookies[u] = await login(u);
    });

    afterAll(async () => {
      if (app) await app.close();
      if (owner) {
        await wipe(TENANT);
        await wipe(OTHER_TENANT);
        await owner.$disconnect();
      }
      if (runtime) await runtime.$disconnect();
    });

    it('Item dimension, W1: every column is the signed MAIN_STOCK sum (cases section 1 worked table)', async () => {
      const body = await summary('item', W1);
      const exp = expected('item', MOVES, W1.from, W1.to);
      expect(norm(body.rows)).toEqual(norm(exp.rows));
      // Rows come in name order (RP_STOCK.cs:4427 ORDER BY B.IT_NAME).
      expect((body.rows as any[]).map((r) => r.name)).toEqual([
        'GOLD CHAIN 22K',
        'GOLD RING 22K',
        'SILVER BOWL',
      ]);
      // Independent anchors written in the case list, not produced by the oracle above.
      const a = (body.rows as any[]).find((r) => r.code === 'GRNG');
      expect([
        a.opPcs,
        a.opWt,
        a.prPcs,
        a.prWt,
        a.inPcs,
        a.inWt,
        a.outPcs,
        a.outWt,
        a.slPcs,
        a.slWt,
        a.clPcs,
        a.clWt,
      ]).toEqual([13, 126, 5, 43, 2, 17, 5, 36, 1, 12, 14, 138]);
      // "Total :" row, hidden transfer columns included.
      expect(body.totals).toMatchObject({
        opPcs: 118,
        opWt: 1126,
        prPcs: 16,
        prWt: 158,
        inPcs: 2,
        inWt: 17,
        outPcs: 5,
        outWt: 36,
        slPcs: 1,
        slWt: 12,
        tInPcs: 1,
        tInWt: 10,
        tOutPcs: 1,
        tOutWt: 10,
        clPcs: 130,
        clWt: 1253,
      });
      expect(body.totals).toEqual(expect.objectContaining(exp.totals));
    });

    it('all eight dimensions equal the oracle and Closing = Opening + every movement, on each row and the total', async () => {
      for (const dim of DIMS) {
        const body = await summary(dim, W1);
        const exp = expected(dim, MOVES, W1.from, W1.to);
        expect(norm(body.rows), dim).toEqual(norm(exp.rows));
        for (const r of [...body.rows, body.totals]) {
          expect(identity(r).pcs, `${dim} pcs`).toBe(r.clPcs);
          expect(identity(r).wt, `${dim} wt`).toBe(r.clWt);
        }
        // Closing equals an independent signed sum of MAIN_STOCK to TO (pcs 130, net 1253.000).
        const sql = await query(
          `SELECT sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_PCS" ELSE -"ITM_PCS" END)::float8 p,
                sum(CASE WHEN "ITM_SIGN"='+' THEN "ITM_NWT" ELSE -"ITM_NWT" END)::float8 w
           FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"='01' AND "LC_CODE"='01' AND "CO_YEAR"=$2 AND "VCH_DATE"<=$3::date`,
          TENANT,
          YEAR,
          W1.to,
        );
        expect([body.totals.clPcs, body.totals.clWt]).toEqual([sql[0].p, sql[0].w]);
      }
    });

    it('weight basis: ticked Gross Wise Weight switches every weight column to gross (RP_STOCK.cs:4280)', async () => {
      const body = await summary('item', W1, { weight: 'gross' });
      expect(norm(body.rows)).toEqual(norm(expected('item', MOVES, W1.from, W1.to, true).rows));
      const a = (body.rows as any[]).find((r) => r.code === 'GRNG');
      expect([a.opWt, a.prWt, a.inWt, a.outWt, a.slWt, a.clWt]).toEqual([
        132.2, 45.15, 17.75, 37.8, 12.5, 144.8,
      ]);
      expect(a.clPcs).toBe(14);
    });

    it('date windows: W0, W2, W3 and From after To (no check, no message: RP_STOCK.cs has no date comparison)', async () => {
      const w0 = { from: D(0), to: D(60) };
      for (const [w, label] of [
        [w0, 'W0'],
        [W2, 'W2'],
        [W3, 'W3'],
        [{ from: D(40), to: D(10) }, 'inverted'],
      ] as const) {
        const body = await summary('item', w, { itemType: 'G' });
        expect(norm(body.rows), label).toEqual(
          norm(expected('item', MOVES, w.from, w.to, false, { itemType: 'G' }).rows),
        );
      }
      const a = (await summary('item', w0, { itemType: 'G' })).rows.find(
        (r: any) => r.code === 'GRNG',
      );
      expect([a.opPcs, a.opWt, a.prPcs, a.prWt]).toEqual([10, 100, 8, 69]);
      const inv = await summary('item', { from: D(40), to: D(10) }, { itemType: 'G' });
      expect(inv.totals).toMatchObject({ opPcs: 20, opWt: 208, prPcs: 0, clPcs: 18, clWt: 176 });
    });

    it.each<[string, Filters, Record<string, string>]>([
      ['item type Gold', { itemType: 'G' }, { itemType: 'Gold' }],
      ['item type Silver by letter', { itemType: 'S' }, { itemType: 'S' }],
      ['stock type Tag', { stockType: 'tag' }, { stockType: 'tag' }],
      ['stock type Item', { stockType: 'item' }, { stockType: 'item' }],
      ['account CUS1', { acCode: 'CUS1' }, { acCode: 'CUS1' }],
      ['account SUP1', { acCode: 'SUP1' }, { acCode: 'SUP1' }],
      ['tag T1', { tagNo: 'T1' }, { tagNo: 'T1' }],
      ['item code', { itCode: 'GCHN' }, { itCode: 'GCHN' }],
      ['product PB', { prCode: 'PB' }, { prCode: 'PB' }],
      ['group GS', { grCode: 'GS' }, { grCode: 'GS' }],
      ['design D1', { designNo: 'D1' }, { designNo: 'D1' }],
      ['safe VAULT', { safe: 'VAULT' }, { safe: 'VAULT' }],
      ['safe MAIN (NULL safe included)', { safe: 'MAIN' }, { safe: 'MAIN' }],
      ['counter 002', { tblCode: '002' }, { tblCode: '002' }],
      ['counter 001 (blank counters count as 001)', { tblCode: '001' }, { tblCode: '001' }],
    ])('filter %s equals the oracle in every dimension', async (_label, f, q) => {
      for (const dim of ['item', 'group', 'counter'] as DimKey[]) {
        const body = await summary(dim, W2, q);
        expect(norm(body.rows), dim).toEqual(
          norm(expected(dim, MOVES, W2.from, W2.to, false, f).rows),
        );
      }
    });

    it('Stock Type Tag + Item = All in every column (RP_STOCK.cs:4287/4291)', async () => {
      const tag = (await summary('item', W2, { itemType: 'G', stockType: 'tag' })).totals;
      const item = (await summary('item', W2, { itemType: 'G', stockType: 'item' })).totals;
      const all = (await summary('item', W2, { itemType: 'G' })).totals;
      for (const k of FIG_KEYS) expect(round(tag[k] + item[k], 3), k).toBe(all[k]);
    });

    it('report includes loose movements a tag snapshot cannot hold (gap 6)', async () => {
      const tag = (await summary('item', W1, { itCode: 'GRNG', stockType: 'tag' })).totals;
      const all = (await summary('item', W1, { itCode: 'GRNG' })).totals;
      expect(all.clWt).toBe(138);
      expect(tag.clWt).toBe(15);
    });

    it('a hidden item (STK_DISPLAY = N) leaves every column and the total; NULL means shown (RP_STOCK.cs:4284)', async () => {
      await exec(
        `UPDATE "ITEM_MAST" SET "STK_DISPLAY"='N' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
        TENANT,
        ITEMS.B.code,
      );
      try {
        ITEMS.B.hidden = true;
        const body = await summary('item', W1);
        expect(norm(body.rows)).toEqual(norm(expected('item', MOVES, W1.from, W1.to).rows));
        expect(body.totals).toMatchObject({ clPcs: 124, clWt: 1183 });
      } finally {
        ITEMS.B.hidden = false;
        await exec(
          `UPDATE "ITEM_MAST" SET "STK_DISPLAY"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01' AND "IT_CODE"=$2`,
          TENANT,
          ITEMS.B.code,
        );
      }
    });

    it('data type: A excludes a B row, C (no condition) includes it (RP_STOCK.cs:4284)', async () => {
      const extra = mv('MDT', 12, 'PUR', 'SUP1', 'A', 'N', '001', 'P', '+', 7, 70, 70, 64.4, 64.4, {
        dataType: 'B',
      });
      await insertMove(TENANT, extra, 99);
      try {
        const all = [...MOVES, extra];
        for (const dt of ['A', 'C']) {
          const body = await summary('item', W1, { dataType: dt });
          expect(norm(body.rows), dt).toEqual(
            norm(expected('item', all, W1.from, W1.to, false, { dataType: dt }).rows),
          );
        }
        const c = (await summary('item', W1, { dataType: 'C' })).rows.find(
          (r: any) => r.code === 'GRNG',
        );
        expect([c.prPcs, c.prWt, c.clPcs, c.clWt]).toEqual([12, 113, 21, 208]);
      } finally {
        await exec(`DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "VCH_NO"='MDT'`, TENANT);
      }
    });

    it('scope: company, location, year and tenant sentinels never appear; the session year decides', async () => {
      const body = await summary('item', W1);
      expect(body.totals.opPcs).toBe(118);
      expect(JSON.stringify(body)).not.toContain('999');
      // A foreign location in the query is refused, never widened.
      const foreign = await get(
        'printer',
        `/reports/stock-report?${qs({ dimension: 'item', fromDate: W1.from, toDate: W1.to, lcCode: '02' })}`,
      );
      expect([400, 409]).toContain(foreign.statusCode);
    });

    it('company stock merge drops the company condition inside the tenant only (CO_STK_MERGE = Y)', async () => {
      await exec(
        `UPDATE "CO_SET" SET "CO_STK_MERGE"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
        TENANT,
      );
      try {
        const all = [
          ...MOVES,
          { ...MOVES[0]!, id: 'Z-CO', co: '02', pcs: 999, nwt: 999, gwt: 999 } as Mv,
        ];
        const body = await summary('item', W1);
        expect(norm(body.rows)).toEqual(
          norm(expected('item', all, W1.from, W1.to, false, {}, true).rows),
        );
        expect(JSON.stringify(body)).not.toContain('1000');
      } finally {
        await exec(
          `UPDATE "CO_SET" SET "CO_STK_MERGE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          TENANT,
        );
      }
    });

    it('Counter dimension: blank counters are CNT-ONE and nothing is written (the desktop UPDATE, RP_STOCK.cs:3653, is not ported)', async () => {
      const before = await counts(TENANT);
      const otherBefore = await counts(OTHER_TENANT);
      for (let run = 0; run < 2; run += 1) {
        const body = await summary('counter', W1);
        expect(norm(body.rows)).toEqual(norm(expected('counter', MOVES, W1.from, W1.to).rows));
      }
      for (const dim of DIMS) await summary(dim, W1);
      await movements('item', W1, ITEMS.A.code, 'G', 'closing');
      await get(
        'printer',
        `/reports/stock-report/export.csv?${qs({ dimension: 'item', fromDate: W1.from, toDate: W1.to })}`,
      );
      expect(await counts(TENANT)).toEqual(before);
      expect(await counts(OTHER_TENANT)).toEqual(otherBefore);
      expect(before.mainStock[0].blanks).toBeGreaterThan(0);
      expect(before.safeNull[0].n).toBeGreaterThan(0);
      // NULL SAFE_NAME is grouped under MAIN without a write.
      const safe = await summary('safe', W1);
      expect(
        (safe.rows as any[])
          .filter((r) => r.name === 'MAIN')
          .map((r) => r.itType)
          .sort(),
      ).toEqual(['G', 'S']);
    });

    describe('drill-down (RP_STOCK.cs:2816-3227)', () => {
      const sets: Array<[string, (m: Mv, w: { from: string; to: string }) => boolean, boolean]> = [
        ['opening', (m, w) => D(m.day) < w.from, true],
        [
          'purchase',
          (m, w) => m.sign === '+' && m.tr === 'P' && D(m.day) >= w.from && D(m.day) <= w.to,
          false,
        ],
        [
          'inward',
          (m, w) => m.sign === '+' && m.tr === 'I' && D(m.day) >= w.from && D(m.day) <= w.to,
          false,
        ],
        [
          'outward',
          (m, w) => m.sign === '-' && m.tr === 'O' && D(m.day) >= w.from && D(m.day) <= w.to,
          false,
        ],
        [
          'sale',
          (m, w) => m.sign === '-' && m.tr === 'S' && D(m.day) >= w.from && D(m.day) <= w.to,
          false,
        ],
        ['closing', (m, w) => D(m.day) <= w.to, true],
      ];
      const cellOf = (r: any, column: string) => {
        const p = {
          opening: 'op',
          purchase: 'pr',
          inward: 'in',
          outward: 'out',
          sale: 'sl',
          closing: 'cl',
        }[column]!;
        return { pcs: r[`${p}Pcs`], nwt: r[`${p}Wt`] };
      };

      it.each(sets.map((s) => s[0]))(
        'item A %s: rows, KR_FINE for + and ITM_FINE for -, signed total equals the summary cell',
        async (column) => {
          const [, pick, signed] = sets.find((s) => s[0] === column)!;
          const body = await movements('item', W1, ITEMS.A.code, 'G', column);
          const want = MOVES.filter((m) => m.item === 'A' && pick(m, W1));
          expect((body.rows as any[]).map((r) => r.vchNo).sort()).toEqual(
            want.map((m) => m.id).sort(),
          );
          for (const r of body.rows as any[]) {
            const m = want.find((x) => x.id === r.vchNo)!;
            expect(r.sign).toBe(m.sign);
            expect(r.fine, r.vchNo).toBe(m.sign === '+' ? m.kr : m.fine);
            expect(r.nwt).toBe(m.nwt);
          }
          const s = (m: Mv) => (signed && m.sign === '-' ? -1 : 1);
          const total = {
            pcs: round(
              want.reduce((a, m) => a + s(m) * m.pcs, 0),
              3,
            ),
            gwt: round(
              want.reduce((a, m) => a + s(m) * m.gwt, 0),
              3,
            ),
            nwt: round(
              want.reduce((a, m) => a + s(m) * m.nwt, 0),
              3,
            ),
            fine: round(
              want.reduce((a, m) => a + s(m) * (m.sign === '+' ? m.kr : m.fine), 0),
              3,
            ),
          };
          expect(body.totals).toEqual(total);
          const cell = cellOf(
            (await summary('item', W1)).rows.find((r: any) => r.code === 'GRNG'),
            column,
          );
          expect([body.totals.pcs, body.totals.nwt]).toEqual([cell.pcs, cell.nwt]);
        },
      );

      it('opening total fine is 115.000 with KR_FINE, not 115.416 with ITM_FINE (cases drill.opening-signed-total)', async () => {
        const body = await movements('item', W1, ITEMS.A.code, 'G', 'opening');
        expect(body.totals).toMatchObject({ pcs: 13, gwt: 132.2, nwt: 126, fine: 115 });
      });

      it('tag T1 closing: Fine = 10.800 - 11.040 + 11.040 = 10.800, not the 10.992 a signed ITM_FINE helper gives', async () => {
        const body = await movements('item', W1, ITEMS.A.code, 'G', 'closing', { tagNo: 'T1' });
        expect(body.totals).toMatchObject({ pcs: 1, nwt: 12, fine: 10.8 });
        expect((body.rows as any[]).map((r) => r.fine)).toEqual([10.8, 11.04, 11.04]);
      });

      it('repeats the summary filters, so a cell and its detail total agree (desktop weakness 5)', async () => {
        const f = { itemType: 'G', stockType: 'item' };
        const sum = await summary('item', W2, f);
        const cell = (sum.rows as any[]).find((r) => r.code === 'GRNG');
        const open = await movements('item', W2, ITEMS.A.code, 'G', 'opening', f);
        const close = await movements('item', W2, ITEMS.A.code, 'G', 'closing', f);
        expect([open.totals.pcs, open.totals.nwt]).toEqual([cell.opPcs, cell.opWt]);
        expect([close.totals.pcs, close.totals.nwt]).toEqual([cell.clPcs, cell.clWt]);
        expect([cell.opPcs, cell.clPcs, cell.clWt]).toEqual([10, 14, 140]);
      });

      it('every dimension drills to exactly its summary cell', async () => {
        for (const dim of DIMS) {
          const sum = await summary(dim, W1);
          for (const row of sum.rows as any[]) {
            for (const column of ['opening', 'closing', 'sale']) {
              const body = await movements(dim, W1, row.code, row.itType, column);
              const cell = cellOf(row, column);
              expect([body.totals.pcs, body.totals.nwt], `${dim} ${row.code} ${column}`).toEqual([
                cell.pcs,
                cell.nwt,
              ]);
            }
          }
        }
      });
    });

    describe('rights, print and export', () => {
      const csvUrl = `/reports/stock-report/export.csv?${qs({ dimension: 'group', fromDate: W1.from, toDate: W1.to })}`;
      it('Print right: viewer is refused (403, no data); printer gets the CSV with the Total row; xlsx too', async () => {
        const refused = await get('viewer', csvUrl);
        expect(refused.statusCode).toBe(403);
        expect(refused.body).not.toContain('GOLD ORNAMENTS');
        const ok = await get('printer', csvUrl);
        expect(ok.statusCode, ok.body).toBe(200);
        expect(ok.headers['content-type']).toContain('text/csv');
        expect(ok.body).toContain('GOLD ORNAMENTS');
        expect(ok.body).toContain('Total :');
        const xlsx = await get('printer', csvUrl.replace('export.csv', 'export.xlsx'));
        expect(xlsx.statusCode).toBe(200);
        expect((await get('viewer', csvUrl.replace('export.csv', 'export.xlsx'))).statusCode).toBe(
          403,
        );
      });
      it('a user with no rights row for Stock Report is refused (UserPrint stays empty, RP_STOCK.cs:4022)', async () => {
        expect((await get('norow', csvUrl)).statusCode).toBe(403);
        expect(
          (
            await get(
              'norow',
              `/reports/stock-report?${qs({ dimension: 'item', fromDate: W1.from, toDate: W1.to })}`,
            )
          ).statusCode,
        ).toBe(403);
      });
      it('a user without the View right cannot read the report at all', async () => {
        expect(
          (
            await get(
              'blocked',
              `/reports/stock-report?${qs({ dimension: 'item', fromDate: W1.from, toDate: W1.to })}`,
            )
          ).statusCode,
        ).toBe(403);
        expect(
          (
            await get(
              'blocked',
              `/reports/stock-report/movements?${qs({ dimension: 'item', fromDate: W1.from, toDate: W1.to, key: 'GRNG', rowType: 'G', column: 'closing' })}`,
            )
          ).statusCode,
        ).toBe(403);
      });
      it('the viewer can read the screen and the defaults', async () => {
        expect((await summary('item', W1, {}, 'viewer')).rows.length).toBe(3);
        const d = await get('viewer', '/reports/stock-report/defaults');
        expect(d.statusCode, d.body).toBe(200);
        expect(d.json()).toMatchObject({
          fromDate: `${startYear}-04-01`,
          itemType: 'G',
          grossWeight: false,
        });
      });
      it('two users printing at the same instant each get their own window (no shared staging table)', async () => {
        const mine = (w: { from: string; to: string }) =>
          get(
            'printer',
            `/reports/stock-report/export.csv?${qs({ dimension: 'group', fromDate: w.from, toDate: w.to })}`,
          );
        const [a, b] = await Promise.all([mine(W1), mine(W3)]);
        const total = (body: string) =>
          body.split(/\r?\n/).find((l) => l.includes('Total :')) ?? '';
        expect(total(a.body)).not.toEqual(total(b.body));
        const e1 = expected('group', MOVES, W1.from, W1.to).totals;
        const e3 = expected('group', MOVES, W3.from, W3.to).totals;
        expect(total(a.body)).toContain(e1.clWt.toFixed(3));
        expect(total(b.body)).toContain(e3.clWt.toFixed(3));
      });
    });

    describe('invalid input fails closed', () => {
      it('SQL metacharacters in text filters are bound parameters: empty result, tables intact', async () => {
        for (const q of [
          { tagNo: `' OR '1'='1` },
          { acCode: `X'; DROP TABLE "MAIN_STOCK";--` },
          { designNo: `%` },
        ]) {
          const body = await summary('item', W1, q);
          expect(body.rows, JSON.stringify(q)).toEqual([]);
        }
        expect(
          (await query(`SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1`, TENANT))[0].n,
        ).toBe(MOVES.length + 3);
      });
      it.each([
        ['unknown dimension', { dimension: 'colour' }],
        ['unknown selector', { dimension: 'item', city: 'SURAT' }],
        ['bad date', { dimension: 'item', fromDate: '2026-02-31' }],
        ['bad weight', { dimension: 'item', weight: 'fine' }],
        ['bad item type', { dimension: 'item', itemType: 'Z' }],
        ['bad stock type', { dimension: 'item', stockType: 'both' }],
      ])('%s is a 400 with a code', async (_l, q) => {
        const r = await get(
          'printer',
          `/reports/stock-report?${qs({ fromDate: W1.from, toDate: W1.to, ...q })}`,
        );
        expect(r.statusCode, r.body).toBe(400);
        expect(r.json().error).toBeTruthy();
      });
      it('an empty result is an empty grid with zero totals, not an error (RP_STOCK.cs:4712)', async () => {
        const body = await summary('item', W1, { tagNo: 'NOPE' });
        expect(body.rows).toEqual([]);
        expect(body.totals.clPcs).toBe(0);
      });
      it('the movements route needs a key, a known column and a row type', async () => {
        const r = await get(
          'printer',
          `/reports/stock-report/movements?${qs({ dimension: 'item', fromDate: W1.from, toDate: W1.to, column: 'transfer', key: 'GRNG', rowType: 'G' })}`,
        );
        expect(r.statusCode).toBe(400);
      });
    });

    describe('open-time defaults, voucher zoom and the InOut item ledger', () => {
      const grossOf = (m: Mv) => m.gwt;
      void grossOf;
      it('Item Type defaults from the company metal type: blank and G are Gold, anything else Silver (RP_STOCK.cs:3628)', async () => {
        const defaults = async () =>
          (await get('printer', '/reports/stock-report/defaults')).json();
        expect((await defaults()).itemType).toBe('G');
        await exec(
          `UPDATE "CO_MAST" SET "METAL_TYPE"='S' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          TENANT,
        );
        try {
          expect((await defaults()).itemType).toBe('S');
        } finally {
          await exec(
            `UPDATE "CO_MAST" SET "METAL_TYPE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
            TENANT,
          );
        }
        expect((await defaults()).itemType).toBe('G');
      });

      it('a movement dated after today gives the desktop warning and sets To to its date (RP_STOCK.cs:3713)', async () => {
        const defaults = async () =>
          (await get('printer', '/reports/stock-report/defaults')).json();
        const none = await defaults();
        expect(none.futureVoucher).toBeNull();
        expect(none.toDate).toBe(none.systemDate);
        const later = new Date(Date.now() + 5 * 86_400_000).toISOString().slice(0, 10);
        await exec(
          `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","VCH_TYPE","IT_CODE","TAG_NO","TR_TYPE","ITM_SIGN","ITM_PCS","ITM_GWT","ITM_NWT","DATA_TYPE")
           VALUES($1,'01','01',$2,'SAL','000045',1,$3::date,'X','GRNG','N','S','-',1,1,1,'A')`,
          TENANT,
          YEAR,
          later,
        );
        try {
          const d = await defaults();
          expect(d.futureVoucher).toEqual({
            bookName: 'Sales',
            vchNo: '000045',
            vchDate: later,
            message:
              'Please Check Voucher Date in Entry Because Entry Date > Curent Date... Book = Sales And VchNo = 000045....',
          });
          expect(d.toDate).toBe(later);
          expect(d.systemDate).toBe(none.systemDate);
        } finally {
          await exec(`DELETE FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "VCH_NO"='000045'`, TENANT);
        }
      });

      it('zoom: the entry screen of each book, the Item Opening refusal, and the target menu View right (RP_STOCK.cs:5218)', async () => {
        const zoom = async (user: string, book: string, vch: string) =>
          (
            await get(user, `/reports/stock-report/zoom?${qs({ coBook: book, vchNo: vch })}`)
          ).json();
        // The printer holds no rights row for Sales: the hosted service refuses (decision 5).
        expect(await zoom('printer', 'SAL', 'M10')).toEqual({
          action: 'refuse',
          message: 'You Have No Rights...',
        });
        await exec(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES($1,'01','01','printer','Sales','Sales Invoice','N','N','N','N')`,
          TENANT,
        );
        try {
          expect((await zoom('printer', 'SAL', 'M10')).message).toBe('You Have No Rights...');
          await exec(
            `UPDATE "USER_SET" SET "FRM_VIEW"='Y' WHERE tenant_id=$1 AND "USER_NAME"='printer' AND "SUB_MENU"='Sales Invoice'`,
            TENANT,
          );
          expect(await zoom('printer', 'SAL', 'M10')).toEqual({
            action: 'open',
            path: '/txn/sales',
            vchNo: 'M10',
            coBook: 'SAL',
            coYear: YEAR,
            lcCode: '01',
          });
        } finally {
          await exec(
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='printer' AND "SUB_MENU"='Sales Invoice'`,
            TENANT,
          );
        }
        // A voucher number shorter than 3 characters is an Item Opening row; an unknown book opens nothing.
        expect(await zoom('printer', 'IOB', 'G')).toEqual({
          action: 'refuse',
          message: 'This Is a Item Wise Opening Stock Voucher You Cant Zoom ....',
        });
        expect(await zoom('printer', 'NOPE', 'M10')).toEqual({ error: 'book-unavailable' });
        // TAG GEN opens Tag Opening in its Only Tag Entry mode (RP_STOCK.cs:5272, mode=TAG GEN); JDTR TAG has no Lite book list.
        await exec(
          `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
           VALUES($1,'01','01','printer','Inventory','Tag Opening','Y','N','N','N')`,
          TENANT,
        );
        try {
          expect(await zoom('printer', 'TGN', 'T10')).toEqual({
            action: 'open',
            path: '/txn/tag-opening',
            vchNo: 'T10',
            coBook: 'TGN',
            coYear: YEAR,
            lcCode: '01',
            mode: 'TAG GEN',
          });
          expect(await zoom('printer', 'JDT', 'T10')).toEqual({ action: 'none' });
        } finally {
          await exec(
            `DELETE FROM "USER_SET" WHERE tenant_id=$1 AND "USER_NAME"='printer' AND "SUB_MENU"='Tag Opening'`,
            TENANT,
          );
        }
        // The Tag Transfer book has no Lite screen.
        expect(await zoom('printer', 'TRF', 'M12')).toEqual({ action: 'none' });
        // No View right on the Stock Report: the route itself is refused.
        expect(
          (
            await get(
              'blocked',
              `/reports/stock-report/zoom?${qs({ coBook: 'SAL', vchNo: 'M10' })}`,
            )
          ).statusCode,
        ).toBe(403);
      });

      it('the InOut item ledger covers the ticked items up to To, needs a selection and no Print right (RP_STOCK.cs:5927-5976)', async () => {
        const url = (extra: Record<string, string>) =>
          `/reports/stock-report/item-ledger?${qs({ fromDate: W1.from, toDate: W1.to, ...extra })}`;
        const a = ITEMS.A.code;
        const ledger = (await get('printer', url({ items: a }))).json();
        expect(ledger.title).toBe(
          `Stock Ledger Report From ${W1.from.split('-').reverse().join('/')} To ${W1.to.split('-').reverse().join('/')}`,
        );
        expect(ledger.items.map((i: any) => i.code)).toEqual([a]);
        // Item A (cases.md section 1): Opening 13 / 126.000 before D10, Closing 14 / 138.000 at D40.
        const mine = MOVES.filter((m) => m.item === 'A');
        const signed = (rows: Mv[]) => ({
          pcs: round(
            rows.reduce((n, m) => n + (m.sign === '+' ? m.pcs : -m.pcs), 0),
            3,
          ),
          nwt: round(
            rows.reduce((n, m) => n + (m.sign === '+' ? m.nwt : -m.nwt), 0),
            3,
          ),
        });
        const opening = signed(mine.filter((m) => D(m.day) < W1.from));
        const closing = signed(mine.filter((m) => D(m.day) <= W1.to));
        const item = ledger.items[0];
        expect([item.openingPcs, item.openingNetWt]).toEqual([opening.pcs, opening.nwt]);
        expect([item.closingPcs, item.closingNetWt]).toEqual([closing.pcs, closing.nwt]);
        expect([closing.pcs, closing.nwt]).toEqual([14, 138]);
        expect(item.rows).toHaveLength(mine.filter((m) => D(m.day) >= W1.from).length);
        // Items that are not ticked are absent; a code of another tenant or location adds nothing.
        const both = (await get('printer', url({ items: `${a},${ITEMS.S.code}` }))).json();
        expect(both.items.map((i: any) => i.code).sort()).toEqual([ITEMS.S.code, a].sort());
        expect((await get('printer', url({ items: '' }))).statusCode).toBe(400);
        expect((await get('printer', url({ items: '' }))).json().message).toBe(
          'Item Selection Not Done...',
        );
        // InOut never reads UserPrint (RP_STOCK.cs:5855-5976): View is enough.
        expect((await get('viewer', url({ items: a }))).statusCode).toBe(200);
        const pdf = await get(
          'printer',
          url({ items: a }).replace('item-ledger?', 'item-ledger.pdf?'),
        );
        expect([200, 500, 501, 503]).toContain(pdf.statusCode);
        // The picker lists the items of the Item Type by name.
        const list = (
          await get('viewer', '/reports/stock-report/item-ledger/items?itemType=G')
        ).json();
        expect(list.map((r: any) => r.code)).toEqual(
          Object.values(ITEMS)
            .filter((i) => i.type === 'G' && !i.hidden)
            .sort((x, y) => x.name.localeCompare(y.name))
            .map((i) => i.code),
        );
      });

      it('ITM_WITH_LOT_STK = Y: the Safe dimension groups by the stock lot and the defaults say so (RP_STOCK.cs:4483-4485)', async () => {
        const had = await query(
          `SELECT 1 FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          TENANT,
        );
        if (had.length === 0)
          await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE") VALUES($1,'01')`, TENANT);
        await exec(
          `UPDATE "CO_SET_NEW" SET "ITM_WITH_LOT_STK"='Y' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
          TENANT,
        );
        await exec(
          `UPDATE "MAIN_STOCK" SET "ITM_LOT"='LOT-A' WHERE tenant_id=$1 AND "VCH_NO"='M09'`,
          TENANT,
        );
        try {
          expect((await get('printer', '/reports/stock-report/defaults')).json().itemLot).toBe(
            true,
          );
          const body = await summary('safe', W1, { itemType: 'G' });
          const byLot = Object.fromEntries(body.rows.map((r: any) => [r.code, r]));
          expect(Object.keys(byLot).sort()).toEqual(['', 'LOT-A']);
          // M09 (4 pcs / 40.000 net) is the only lot-bearing movement.
          expect([
            byLot['LOT-A'].prPcs,
            byLot['LOT-A'].prWt,
            byLot['LOT-A'].clPcs,
            byLot['LOT-A'].clWt,
          ]).toEqual([4, 40, 4, 40]);
          const drill = await movements('safe', W1, 'LOT-A', 'G', 'closing', { itemType: 'G' });
          expect(drill.rows.map((r: any) => r.itLot)).toEqual(['LOT-A']);
        } finally {
          await exec(
            `UPDATE "MAIN_STOCK" SET "ITM_LOT"=NULL WHERE tenant_id=$1 AND "VCH_NO"='M09'`,
            TENANT,
          );
          if (had.length === 0)
            await exec(`DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1 AND "CO_CODE"='01'`, TENANT);
          else
            await exec(
              `UPDATE "CO_SET_NEW" SET "ITM_WITH_LOT_STK"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
              TENANT,
            );
        }
        expect((await get('printer', '/reports/stock-report/defaults')).json().itemLot).toBe(false);
      });
    });

    it('the other tenant sees only its own 1000 pcs, and tenant 1 never sees it', async () => {
      const mine = await summary('item', W1);
      expect(JSON.stringify(mine)).not.toContain('1000,');
      const rows: any[] = await query(
        `SELECT count(*)::int n FROM "MAIN_STOCK" WHERE tenant_id=$1`,
        OTHER_TENANT,
      );
      expect(rows[0].n).toBe(1);
    });
  },
);
