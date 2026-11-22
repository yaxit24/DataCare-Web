import { PrismaClient } from '@datacare/db';
import type { FastifyInstance } from 'fastify';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { buildApp } from '../src/app.js';
import { hashPassword } from '../src/modules/auth/password.js';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-30, Transaction > Wh Sales residuals (TR_WH_SALE): hand-typed item-detail rows for a loose line (SL_IDTL,
 * :13162-13250), fine kasar (KSR_FINE_DR/CR, :12980-12981, :15633-15634; ledger legs 27/28/33/34 Ac_Ledr.cs:685-705;
 * day book rows 07/08 Ac_Rojmel.cs:235-237), the lined Rojmel rows 05/06/14/27 and the version token. Every expected
 * figure is the desktop arithmetic worked by hand in the comments, never read back from the code.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenantId = 'wh-resid-db';
const PASSWORD = 'Wholesale-Resid!2026';
const SECRET = 'wholesale-residuals-test-signing-secret-over-thirty-two-chars';
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
const YEAR = `${startYear}-${startYear + 1}`;
const DAY = `${startYear}-06-15`;

// Row A: 2 pcs x 1.5 = 3.000 g; ConWt 3 x 0.1 = 0.300; ItAmt 101 x 3 = 303; Lbr 237.5 x 2 = 475;
// Disc round(303 x 5 / 100 = 15.15) = 15; Net 303 - 15 + 475 = 763.
const rowA = { itCode: 'DST', pcs: 2, pcsWt: 1.5, conPct: 0.1, krConPct: 0.05, rate: 101, discPct: 5, lbrRate: 237.5 };
// Row B: 2.000 g typed, ConWt 0.200, net amount typed 500 (no rate, no labour: the typed cell stays).
const rowB = { itCode: 'PLN', pcs: 2, grossWt: 2, conPct: 0.1, netAmt: 500 };
// Line: gross 5, OthWt = 0.3 + 0.2 = 0.5, NetWt 4.5, OthAmt = 763 + 500 = 1263, fine 4.5 x 91.6 / 100 = 4.122.
const looseLine = (details: unknown[] = [rowA, rowB]) => ({
  itCode: 'PLN', pcs: 2, grossWt: 5, touch: 91.6, details,
});

(enabled ? describe : describe.skip)('Wh Sales residuals (WP-30)', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  let app: FastifyInstance;
  let cookie = '';
  let seq = 0;
  const exec = (sql: string, ...p: unknown[]) => owner.$executeRawUnsafe(sql, ...p);
  const rows = (sql: string, ...p: unknown[]) => owner.$queryRawUnsafe<any[]>(sql, tenantId, ...p);
  const wipe = async () => {
    const found: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
      `SELECT DISTINCT table_name FROM information_schema.columns WHERE table_schema='public' AND column_name='tenant_id'`,
    );
    for (const r of found) await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, tenantId);
  };
  const seedTag = async (itCode: string) => {
    seq += 1;
    const tag = `RSD${String(seq).padStart(5, '0')}`;
    const srno = 100312000300 + seq;
    await exec(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME",
       "INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","TBL_CODE","EMP_ISU")
       VALUES ($1,'01','01',$2,'PR','0020${seq}',1,$3::date,'PURCHASE','I',$4,$5,$6,1,10,9.5,91.6,8.702,'001','N')`,
      tenantId, YEAR, DAY, tag, srno, itCode);
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
       "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES ($1,'01','01',$2,'PR','0020${seq}',2,1,$3::date,$4,$5,$6,'P','+',1,1,10,9.5)`,
      tenantId, YEAR, DAY, itCode, tag, srno);
    return { tag };
  };
  const body = (lines: unknown[], extra: Record<string, unknown> = {}) => ({
    coBook: 'WHS', vchDate: DAY, acCode: 'WHCUST', itType: 'G', lines, fineRate: 6500, pay: { cash: 1263 }, ...extra,
  });
  const tagBody = (tag: string, extra: Record<string, unknown> = {}) =>
    body([{ tagNo: tag }], { settleCrFine: 8.702, pay: { cash: 56563 }, ...extra });
  const inject = (method: 'POST' | 'PUT' | 'DELETE' | 'GET', url: string, payload?: unknown, headers: Record<string, string> = {}) =>
    app.inject({ method, url, headers: { cookie, ...headers }, payload: payload as any });
  const vno = (res: any) => String(res.json().vchNo).padStart(5, '0');
  const create = async (payload: unknown) => {
    const res = await inject('POST', '/wholesale-sales', payload);
    expect(res.statusCode, res.body).toBe(201);
    return vno(res);
  };
  const open = async (v: string) => (await inject('GET', `/wholesale-sales/${v}?coBook=WHS`)).json();
  const edit = (v: string, version: string, payload: Record<string, unknown>) =>
    inject('PUT', `/wholesale-sales/${v}`, { ...payload, expectedVersion: version });
  const remove = (v: string, version: string) =>
    inject('DELETE', `/wholesale-sales/${v}?expectedVersion=${version}`, { book: 'WHS' });
  const idtl = (v: string) =>
    rows(`SELECT * FROM "SL_IDTL" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO","ISR_NO"`, v);
  const header = async (v: string) =>
    (await rows(`SELECT * FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`, v))[0];
  const leg = async (v: string, code: string) =>
    (await rows(`SELECT * FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "LEDR_KEY" LIKE $3`, v, `%${code}`))[0];
  const roj = (v: string) =>
    rows(`SELECT * FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`, v);
  const footprint = async (v: string) => ({
    h: await rows(`SELECT * FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`, v),
    i: await rows(`SELECT * FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO"`, v),
    d: await idtl(v),
    a: await rows(`SELECT * FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "LEDR_KEY"`, v),
    r: await roj(v),
    s: await rows(`SELECT * FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO","ISR_NO"`, v),
    m: await rows(`SELECT * FROM "DM_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 ORDER BY "SR_NO","ISR_NO"`, v),
  });
  /** Everything except surrogate row ids, which a rewrite legitimately renews. */
  const strip = (x: any): any =>
    JSON.parse(JSON.stringify(x, (k, v) => (k === 'row_id' ? undefined : v)));

  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await wipe();
    await seedCompany(runtime, tenantId, '01');
    await exec(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01','WHCUST','Wholesale Customer','10')`, tenantId);
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE","OTH_DETL_POSTING")
       VALUES ($1,'01','DST','STUDDED RING','G','LR','G','Y'),($1,'01','PLN','PLAIN RING','G','LR','G','N')`, tenantId);
    await exec(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES($1,'01','wholesaler',$2,'ADMIN','Y','Y','Y','N')`, tenantId, await hashPassword(PASSWORD));
    app = await buildApp({ prisma: runtime, secret: SECRET, secureCookies: false });
    const response = await app.inject({
      method: 'POST', url: '/auth/login', headers: { 'x-tenant-id': tenantId },
      payload: { coCode: '01', lcCode: '01', coYear: YEAR, loginName: 'wholesaler', password: PASSWORD },
    });
    expect(response.statusCode, response.body).toBe(200);
    const value = response.headers['set-cookie'];
    cookie = (Array.isArray(value) ? value : [value ?? '']).map((p) => p.split(';', 1)[0]).join('; ');
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) await wipe();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('writes the loose rows to SL_IDTL (every column), rolls them into the line, DM_DATA for the posting item', async () => {
    const v = await create(body([looseLine()]));
    const d = await idtl(v);
    expect(d.map((r) => [Number(r.SR_NO), Number(r.ISR_NO)])).toEqual([[1, 1], [1, 2]]);
    expect(d[0]).toMatchObject({
      ENTRY_TYPE: 'W', AC_CODE: 'WHCUST', TAG_NO: 'N', IT_CODE: 'DST', MAIN_USER: 'wholesaler', HD_VCH_NO: expect.any(String),
    });
    expect(d[0].VCH_TYPE).toBe('WSALE');
    expect(d[0].BOOK_NAME).toBe('WH SALES');
    const num = (r: any) => ({
      pcs: Number(r.IT_PCS), pcsWt: Number(r.IT_PCS_WT), gwt: Number(r.IT_GWT), krWt: Number(r.KR_WT), con: Number(r.IT_CON_PRC),
      conWt: Number(r.IT_CON_WT), rate: Number(r.IT_RATE), amt: Number(r.IT_AMT), disc: Number(r.IT_DISC_PRC),
      discAmt: Number(r.IT_DISC_AMT), lr: Number(r.IT_LBR_RATE), la: Number(r.IT_LBR_AMT), net: Number(r.IT_NET_AMT),
      krCon: Number(r.KR_CON_PRC), krConWt: Number(r.KR_CON_WT),
    });
    expect(num(d[0])).toEqual({ pcs: 2, pcsWt: 1.5, gwt: 3, krWt: 3, con: 0.1, conWt: 0.3, rate: 101, amt: 303, disc: 5, discAmt: 15, lr: 237.5, la: 475, net: 763, krCon: 0.05, krConWt: 0 });
    expect(num(d[1])).toMatchObject({ pcs: 2, gwt: 2, krWt: 2, conWt: 0.2, amt: 0, net: 500, krConWt: 0 });
    // The posting item DST projects into DM_DATA; PLN does not.
    const m = await rows(`SELECT * FROM "DM_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`, v);
    expect(m.map((r) => [r.IT_CODE, Number(r.DM_PCS), Number(r.DM_WT), r.TAG_NO])).toEqual([['DST', 2, 3, 'N']]);
    const line = (await rows(`SELECT * FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "VCH_NO"=$2`, v))[0];
    expect([Number(line.ITM_OTH_WT), Number(line.ITM_NWT), Number(line.OTH_AMT), Number(line.ITM_FINE)]).toEqual([0.5, 4.5, 1263, 4.122]);
    expect(Number((await header(v)).SL_NET_AMT)).toBe(1263);
  });

  it('skips an empty row, keeps a blank-code row, restarts ISR_NO per line, refuses details on a tagged line', async () => {
    const v = await create(body([
      looseLine([rowA, {}]),
      { itCode: 'PLN', pcs: 1, grossWt: 1, touch: 91.6, details: [{ pcs: 1 }, {}] },
    ], { pay: { cash: 763 } }));
    const d = await idtl(v);
    expect(d.map((r) => [Number(r.SR_NO), Number(r.ISR_NO), r.IT_CODE])).toEqual([[1, 1, 'DST'], [2, 1, '']]);
    const t = await seedTag('PLN');
    const bad = await inject('POST', '/wholesale-sales', body([{ tagNo: t.tag, details: [rowA] }]));
    expect(bad.statusCode, bad.body).toBe(400);
  });

  it('refuses negative figures in a detail row and a negative kasar', async () => {
    for (const details of [[{ ...rowA, pcs: -1 }], [{ ...rowA, rate: -5 }], [{ ...rowA, netAmt: -1 }]]) {
      const res = await inject('POST', '/wholesale-sales', body([looseLine(details)]));
      expect(res.statusCode, res.body).toBe(400);
    }
    const t = await seedTag('PLN');
    for (const k of ['ksrFineDr', 'ksrFineCr']) {
      const res = await inject('POST', '/wholesale-sales', tagBody(t.tag, { [k]: -0.1 }));
      expect(res.statusCode, res.body).toBe(400);
    }
  });

  it('GET returns the rows, an unchanged save is identical to the stored footprint, and the version token guards edit and delete', async () => {
    const v = await create(body([looseLine()]));
    const first = await open(v);
    expect(first.lines[0].details.map((r: any) => [r.isrNo, r.itCode, r.itemName, r.pcs, r.netAmt])).toEqual([
      [1, 'DST', 'STUDDED RING', 2, 763], [2, 'PLN', 'PLAIN RING', 2, 500],
    ]);
    expect(first.version).toMatch(/^[0-9a-f]{64}$/);
    const before = strip(await footprint(v));
    // The form re-posts what it read: lines (with their details), kasar and the carried header fields.
    const repost = (view: any) => body(view.lines.map((l: any) => ({ ...l })), {
      vchDate: view.vchDate, billNo: view.billNo, empCode: view.empCode, ksrFineDr: view.ksrFineDr, ksrFineCr: view.ksrFineCr,
      pay: view.pay, settleDrAmt: view.settleDrAmt, settleCrAmt: view.settleCrAmt, settleDrFine: view.settleDrFine,
      settleCrFine: view.settleCrFine, fineRate: view.fineRate,
    });
    expect((await inject('PUT', `/wholesale-sales/${v}`, repost(first))).statusCode).toBe(400); // no token
    const ok = await edit(v, first.version, repost(first));
    expect(ok.statusCode, ok.body).toBe(200);
    const after = strip(await footprint(v));
    expect(after).toEqual(before);
    // The old token is now stale: a second save with it is a defined conflict, and so is a delete.
    const stale = await edit(v, first.version, repost(first));
    expect(stale.statusCode, stale.body).toBe(409);
    expect((await remove(v, first.version)).statusCode).toBe(409);
    expect((await idtl(v)).length).toBe(2);
    const current = await open(v);
    expect((await inject('DELETE', `/wholesale-sales/${v}`, { book: 'WHS' })).statusCode).toBe(400);
    const gone = await remove(v, current.version);
    expect(gone.statusCode, gone.body).toBe(200);
    const left = await footprint(v);
    expect(Object.values(left).every((x: any) => x.length === 0)).toBe(true);
    expect((await remove(v, current.version)).statusCode).toBe(409);
  });

  it('an edit that changes row B and drops row A rewrites the rows; the line roll-up follows', async () => {
    const v = await create(body([looseLine()]));
    const view = await open(v);
    // Row B: Pcs 3 with a rate, so ItAmt 101 x 2.000 g... (weight stays 2.000 typed, pcs x pcsWt not used) = 202.
    const changed = { ...view.lines[0], details: [{ ...view.lines[0].details[1], pcs: 3, rate: 101, netAmt: 0 }] };
    const res = await edit(v, view.version, body([changed], { pay: { cash: 202 } }));
    expect(res.statusCode, res.body).toBe(200);
    const d = await idtl(v);
    expect(d.length).toBe(1);
    expect([Number(d[0].ISR_NO), Number(d[0].IT_PCS), Number(d[0].IT_AMT), Number(d[0].IT_NET_AMT)]).toEqual([1, 3, 202, 202]);
    const line = (await rows(`SELECT * FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "VCH_NO"=$2`, v))[0];
    expect([Number(line.ITM_OTH_WT), Number(line.ITM_NWT), Number(line.OTH_AMT)]).toEqual([0.2, 4.8, 202]);
    // Sending no details key for a line that has rows is refused, not silently dropped.
    const next = await open(v);
    const noKey = { ...next.lines[0] };
    delete noKey.details;
    const refused = await edit(v, next.version, body([noKey]));
    expect(refused.statusCode, refused.body).toBe(400);
  });

  it('stores fine kasar, adds it to the totals, posts legs 27/28/33/34 and Rojmel rows 07/08, and an unchanged save keeps them', async () => {
    const t0 = await seedTag('PLN');
    const twin = await create(tagBody(t0.tag));
    const t = await seedTag('PLN');
    const v = await create(tagBody(t.tag, { ksrFineDr: 0.5, ksrFineCr: 0.25 }));
    const h = await header(v);
    const h0 = await header(twin);
    expect([Number(h.KSR_FINE_DR), Number(h.KSR_FINE_CR)]).toEqual([0.5, 0.25]);
    expect(Number(h.TOT_FINE_DR) - Number(h0.TOT_FINE_DR)).toBeCloseTo(0.5, 6);
    expect(Number(h.TOT_FINE_CR) - Number(h0.TOT_FINE_CR)).toBeCloseTo(0.25, 6);
    expect(Number(h.SL_FINE)).toBe(Number(h0.SL_FINE)); // the kasar never touches SL_FINE / PR_FINE
    const L = { 27: await leg(v, '27'), 28: await leg(v, '28'), 33: await leg(v, '33'), 34: await leg(v, '34') };
    const shape = (r: any) => [r.AC_CODE, r.SIGN, Number(r.FINE_WT), Number(r.DR_AMT), Number(r.CR_AMT), r.IT_TYPE];
    expect(shape(L[27])).toEqual(['WHCUST', '+', 0.25, 0, 0, 'G']);
    expect(shape(L[28])).toEqual(['FINEKSR', '-', 0.25, 0, 0, 'G']);
    expect(shape(L[33])).toEqual(['WHCUST', '-', 0.5, 0, 0, 'G']);
    expect(shape(L[34])).toEqual(['FINEKSR', '+', 0.5, 0, 0, 'G']);
    const sums = await rows(`SELECT sum("DR_AMT")::float8 d, sum("CR_AMT")::float8 c FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2`, v);
    expect(sums[0].d).toBe(sums[0].c);
    // Real reader: the party's gold position moves by +0.25 - 0.5 = -0.25 against the twin without kasar.
    const gold = async (acVch: string) =>
      Number((await rows(`SELECT sum(CASE WHEN "SIGN"='-' THEN -1 ELSE 1 END * coalesce("FINE_WT",0))::float8 g FROM "AC_DATA" WHERE tenant_id=$1 AND "VCH_NO"=$2 AND "AC_CODE"='WHCUST' AND "IT_TYPE"='G'`, acVch))[0].g);
    expect(Math.round((await gold(v) - (await gold(twin))) * 1000) / 1000).toBe(-0.25);
    const r = await roj(v);
    const r07 = r.find((x) => x.LEDR_KEY.endsWith('07'));
    const r08 = r.find((x) => x.LEDR_KEY.endsWith('08'));
    expect([r07.AC_NAME, r07.SIGN, Number(r07.ITM_FINE), Number(r07.DR_AMT), Number(r07.CR_AMT), r07.LD_CODE]).toEqual(['KSR - Wholesale Customer', '-', 0.5, 0, 0, 'FINEKSR']);
    expect([r08.AC_NAME, r08.SIGN, Number(r08.ITM_FINE)]).toEqual(['KSR - Wholesale Customer', '+', 0.25]);
    expect((await roj(twin)).some((x) => /0[78]$/.test(x.LEDR_KEY))).toBe(false);
    expect((await leg(twin, '27')) ?? null).toBeNull();
    const view = await open(v);
    expect([view.ksrFineDr, view.ksrFineCr]).toEqual([0.5, 0.25]);
    const before = strip(await footprint(v));
    const res = await edit(v, view.version, tagBody(t.tag, { vchDate: view.vchDate, billNo: view.billNo, ksrFineDr: 0.5, ksrFineCr: 0.25 }));
    expect(res.statusCode, res.body).toBe(200);
    expect(strip(await footprint(v))).toEqual(before);
    // Zero kasar removes the legs and rows (one transaction, reversed exactly once).
    const view2 = await open(v);
    expect((await edit(v, view2.version, tagBody(t.tag, { vchDate: view2.vchDate, ksrFineDr: 0, ksrFineCr: 0 }))).statusCode).toBe(200);
    expect(await leg(v, '33')).toBeUndefined();
    expect((await roj(v)).some((x) => /0[78]$/.test(x.LEDR_KEY))).toBe(false);
  });

  it('lined Rojmel rows: 05 per unpriced line, 14 for a negative outstanding, 27 labour; keys carry the line, names the book', async () => {
    // Line 1: fine only (no item amount) -> 05; line 2 priced with labour rate. Cash less than net leaves outstanding > 0;
    // overpaying makes SL_BILL_OS negative -> 14 on slot 8.
    const v = await create(body([
      { itCode: 'PLN', pcs: 1, grossWt: 10, touch: 91.6 },
      { itCode: 'PLN', pcs: 1, grossWt: 5, touch: 91.6, rate: 100, rateType: 'G', lbrType: 'G', lbrRate: 10 },
    ], { pay: { cash: 3000 } }));
    const h = await header(v);
    const r = await roj(v);
    const key5 = r.find((x) => x.LEDR_KEY.includes('05'));
    expect(key5.LEDR_KEY.endsWith('05         1')).toBe(true);
    expect([key5.AC_CODE, key5.LD_CODE, key5.SIGN, key5.IT_TYPE, Number(key5.ITM_PCS), Number(key5.ITM_GWT), Number(key5.ITM_NWT), Number(key5.ITM_TOUCH), Number(key5.ITM_FINE), key5.AC_NAME]).toEqual(['WHCUST', 'SALES', '-', 'G', 1, 10, 10, 91.6, 9.16, 'Wholesale Customer']);
    expect(r.filter((x) => /05 +\d+$/.test(x.LEDR_KEY)).length).toBe(1);
    if (Number(h.SL_BILL_OS) < 0) {
      const r14 = r.find((x) => x.LEDR_KEY.endsWith('14'));
      expect([r14.AC_CODE, r14.LD_CODE, Number(r14.CR_AMT), Number(r14.DR_AMT), r14.AC_NAME]).toEqual(['WHCUST', 'SLVSALE', Math.abs(Number(h.SL_BILL_OS)), 0, 'WSALE - Wholesale Customer']);
    }
    const lbr = Number(h.SL_LBR_AMT) + Number(h.SL_OTH_AMT);
    const r27 = r.find((x) => x.LEDR_KEY.endsWith('27'));
    if (lbr !== 0) expect([r27.AC_CODE, r27.LD_CODE, Number(r27.CR_AMT), r27.AC_NAME]).toEqual(['LBRINC', 'WHCUST', lbr, 'LBR - Wholesale Customer']);
    const r04 = r.find((x) => x.LEDR_KEY.endsWith('04'));
    if (r04) expect([r04.AC_CODE, r04.LD_CODE, r04.AC_NAME, r04.IT_TYPE]).toEqual(['SALES', 'WHCUST', 'WSALE - Wholesale Customer', 'A']);
  });

  it('a fault on the second SL_IDTL insert rolls the whole voucher back', async () => {
    await exec(`CREATE OR REPLACE FUNCTION wp30_fault() RETURNS trigger AS $$ BEGIN IF NEW."ISR_NO" = 2 AND NEW.tenant_id = '${tenantId}' THEN RAISE EXCEPTION 'wp30 fault'; END IF; RETURN NEW; END $$ LANGUAGE plpgsql`);
    await exec(`CREATE TRIGGER wp30_fault_trg BEFORE INSERT ON "SL_IDTL" FOR EACH ROW EXECUTE FUNCTION wp30_fault()`);
    try {
      const before = Number((await rows(`SELECT count(*)::int c FROM "AC_DATA" WHERE tenant_id=$1`))[0].c);
      const res = await inject('POST', '/wholesale-sales', body([looseLine()], { ksrFineDr: 0.5 }));
      expect(res.statusCode).toBeGreaterThanOrEqual(400);
      expect(Number((await rows(`SELECT count(*)::int c FROM "AC_DATA" WHERE tenant_id=$1`))[0].c)).toBe(before);
      const leftover = await rows(`SELECT count(*)::int c FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "KSR_FINE_DR"=0.5`);
      expect(leftover[0].c).toBe(0);
    } finally {
      await exec(`DROP TRIGGER IF EXISTS wp30_fault_trg ON "SL_IDTL"`);
      await exec(`DROP FUNCTION IF EXISTS wp30_fault()`);
    }
  });

  it('prints the rows under their line and the kasar row', async () => {
    const t = await seedTag('PLN');
    const v = await create(body([looseLine(), { tagNo: t.tag }], { ksrFineDr: 0.5, ksrFineCr: 0.25, pay: { cash: 1263 } }));
    const res = await inject('GET', `/wholesale-sales/${v}/print?coBook=WHS&format=html`);
    expect(res.statusCode, res.body).toBe(200);
    const text = res.body.replace(/<style>[\s\S]*?<\/style>/g, '').replace(/<[^>]+>/g, '|').replace(/\s*\|[\s|]*/g, '|');
    expect(text.indexOf('STUDDED RING')).toBeGreaterThan(-1);
    expect(text).toMatch(/STUDDED RING\|2\|3\.000\|.*101\.00.*\|763\.00/);
    expect(text).toMatch(/Kasar Fine\|0\.250\|0\.500/);
  });
});
