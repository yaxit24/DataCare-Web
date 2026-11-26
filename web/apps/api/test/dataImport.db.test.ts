import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import {
  DATA_IMPORT_MESSAGES,
  applyLiteImport,
  businessToday,
  previewLiteImport,
} from '../src/modules/utilities/dataImport.js';
import { fixtureBytes, liteFixture } from './fixtures/liteImport.js';

/**
 * Write set of Other → Data Import, Lite Soft (UT_IMPORT.cs:8413-8445) through the SourceReader fixture: the five steps
 * land in one transaction, a company with data is refused, a fault in any step rolls everything back, and another
 * tenant is never touched. Expected values are worked by hand from the desktop lines (see dataImportLite.test.ts).
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'data-import-db';
const OTHER = 'data-import-db-other';
const CO = '07';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const rows = (sql: string, ...p: unknown[]) => owner.$queryRawUnsafe(sql, TENANT, ...p) as Promise<any[]>;

async function wipe(tenant: string) {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns WHERE column_name='tenant_id' AND table_schema='public' GROUP BY table_name`,
  )) as { table_name: string }[];
  for (const t of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, tenant);
}

async function fingerprint(tenant: string): Promise<Record<string, string>> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name name FROM information_schema.columns
      WHERE table_schema='public' AND column_name='tenant_id' AND table_name NOT IN ('audit_log','api_command_receipt')
      GROUP BY table_name ORDER BY table_name`,
  )) as { name: string }[];
  const out: Record<string, string> = {};
  for (const { name } of tables) {
    const [r] = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int n, coalesce(md5(string_agg(t::text, E'\\n' ORDER BY t::text)), '') h FROM "${name}" t WHERE t.tenant_id=$1`,
      tenant,
    )) as any[];
    out[name] = `${r.n}:${r.h}`;
  }
  return out;
}

let scope: { tenantId: string; coCode: string; lcCode: string; coYear: string; user: string };
let clDate = '';
let opDate = '';

async function freshCompany() {
  await wipe(TENANT);
  await seedCompany(runtime, TENANT, CO);
  const [y] = await rows(
    `SELECT "CO_YEAR" y, "OP_DATE"::text op, to_char("CL_DATE",'YYYY-MM-DD') cl FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`,
    CO,
  );
  clDate = y.cl;
  opDate = String(y.op).slice(0, 10);
  scope = { tenantId: TENANT, coCode: CO, lcCode: '01', coYear: y.y, user: 'importer' };
  // A party keyed by the operator before the import, and the web system accounts: Lite_AcMast replaces the first and
  // keeps the second (AC_CODE >= '00101' minus the web chart's system codes).
  await owner.$executeRawUnsafe(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,'01','OLDPTY','TYPED BEFORE IMPORT')`,
    TENANT,
    CO,
  );
}

const file = (bytes?: Uint8Array) => ({ name: 'LITE.MDB', bytes: bytes ?? fixtureBytes(CO, scope.coYear, clDate) });

describe.skipIf(!RUN)('Data Import (Lite Soft) write set', () => {
  beforeAll(async () => {
    process.env.DATACARE_IMPORT_FIXTURE_READER = '1';
    await wipe(OTHER);
    await seedCompany(runtime, OTHER, CO);
  });
  afterAll(async () => {
    await wipe(TENANT);
    await wipe(OTHER);
    await owner.$disconnect();
    await runtime.$disconnect();
  });
  beforeEach(freshCompany);

  it('previews the five steps without writing', async () => {
    const before = await fingerprint(TENANT);
    const p = await previewLiteImport(runtime, scope, file());
    expect(p.refusal).toBeNull();
    expect(p.errors).toEqual([]);
    expect(p.question).toBe('Are You Sure To Import Old Software Data In Next Software ?');
    expect(p.steps.map((s) => [s.step, s.writes])).toEqual([
      ['Lite_AcMast', { AC_MAST: 2, AC_MAST_SRNO: 1, CO_SET: 1 }],
      ['Wh_Item', { PRODUCT_MAST: 1, GROUP_MAST: 2, TABLE_MAST: 1, ITEM_MAST: 3 }],
      ['WH_AcOpbl', { OP_DATA: 3, AC_DATA: 5 }],
      ['Lite_BarData', { BAR_DATA: 2, BAR_DETL: 3, BAR_IDTL: 2, MAIN_STOCK: 3 }],
      ['WH_ItOpbl', { ITM_OPBL: 2, MAIN_STOCK: 2 }],
    ]);
    expect(p.steps[0]!.replaces.AC_MAST).toBe(1); // OLDPTY only; CASH, SALES, … stay
    expect(p.ignoredTables).toEqual(['MSYS_SOMETHING']);
    expect(await fingerprint(TENANT)).toEqual(before);
  });

  it('writes every step in one transaction', async () => {
    const otherBefore = await fingerprint(OTHER);
    const p = await previewLiteImport(runtime, scope, file());
    const r = await applyLiteImport(runtime, scope, file(), p.previewHash);
    expect(r.message).toBe('Process Are Complete....');
    const today = businessToday();
    // Step 1
    const accounts = await rows(
      `SELECT "AC_CODE" c FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
      CO,
    );
    const codes = accounts.map((a) => a.c);
    expect(codes).toContain('00101');
    expect(codes).toContain('00102');
    expect(codes).toContain('CASH');
    expect(codes).not.toContain('OLDPTY');
    const [ramesh] = await rows(
      `SELECT "AC_ADD1","AC_GR","AC_AREA","BR_DATE","LAST_DATE","MAIN_USER","LC_CODE" FROM "AC_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"='00101'`,
      CO,
    );
    expect(ramesh).toEqual({
      AC_ADD1: "SHOP 4, O'NEIL ROAD",
      AC_GR: '20',
      AC_AREA: 'SADAR BAZAR NORTH EXTENSI',
      BR_DATE: '17/05/1980',
      LAST_DATE: '01/01/2010',
      MAIN_USER: 'ABC',
      LC_CODE: '01',
    });
    expect(
      await rows(`SELECT "AC_CODE" FROM "AC_MAST_SRNO" WHERE tenant_id=$1 AND "CO_CODE"=$2`, CO),
    ).toEqual([{ AC_CODE: '00102' }]);
    expect(
      await rows(`SELECT DISTINCT "VB_IMPORT" v FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2`, CO),
    ).toEqual([{ v: 'Y' }]);
    // Step 2: the company's installer masters are replaced by the file's
    expect(
      (await rows(`SELECT "IT_CODE" c FROM "ITEM_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`, CO)).map(
        (x) => x.c,
      ),
    ).toEqual(['CHN', 'RNG', 'SLB']);
    expect(
      await rows(
        `SELECT "GR_CODE","SALE_AC","PURC_AC" FROM "GROUP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
        CO,
      ),
    ).toEqual([
      { GR_CODE: 'GLD', SALE_AC: 'SALES', PURC_AC: 'PURCHASE' },
      { GR_CODE: 'SLV', SALE_AC: 'SLVSALE', PURC_AC: '' },
    ]);
    // Step 3: OP_DATA and AcOp_Ledr's legs, dated the day before the new opening date
    expect(
      await rows(
        `SELECT "AC_CODE","OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN","DATA_TYPE","CO_BOOK","VCH_NO"
           FROM "OP_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1`,
        CO,
      ),
    ).toEqual([
      { AC_CODE: '00101', OP_AMT: 750.45, OP_SIGN: 'C', FINE_BAL: 8.25, FINE_SIGN: 'C', SL_FINE_BAL: 0, SL_FINE_SIGN: 'D', DATA_TYPE: 'A', CO_BOOK: '000', VCH_NO: '00000' },
      { AC_CODE: '00102', OP_AMT: 500, OP_SIGN: 'D', FINE_BAL: 0, FINE_SIGN: 'D', SL_FINE_BAL: 100, SL_FINE_SIGN: 'C', DATA_TYPE: 'A', CO_BOOK: '000', VCH_NO: '00000' },
      { AC_CODE: 'CASH', OP_AMT: 2000, OP_SIGN: 'C', FINE_BAL: 0, FINE_SIGN: 'D', SL_FINE_BAL: 0, SL_FINE_SIGN: 'D', DATA_TYPE: 'A', CO_BOOK: '000', VCH_NO: '00000' },
    ]);
    const legs = await rows(
      `SELECT "AC_CODE", "CR_AMT"::float cr, "DR_AMT"::float dr, "VCH_DATE"::text d FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY 1, 2, 3`,
      CO,
    );
    expect(legs.length).toBe(5);
    const legDay = new Date(`${today}T00:00:00Z`);
    legDay.setUTCDate(legDay.getUTCDate() - 1);
    expect(new Set(legs.map((l) => l.d))).toEqual(new Set([legDay.toISOString().slice(0, 10)]));
    expect(legs.filter((l) => l.AC_CODE === '00101' && l.cr === 750.45)).toHaveLength(1);
    // Step 4
    const detl = await rows(
      `SELECT "VCH_NO","TAG_NO","SR_NO","VCH_SRNO","VCH_DATE"::text d,"KR_FINE"::float kf,"TAG_TYPE","CO_BOOK","LC_CODE"
         FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "VCH_SRNO"`,
      CO,
    );
    const tagDay = new Date(`${opDate}T00:00:00Z`);
    tagDay.setUTCDate(tagDay.getUTCDate() - 1);
    expect(detl.map((d) => [d.VCH_NO, d.TAG_NO, d.SR_NO, d.VCH_SRNO, d.d])).toEqual([
      ['00001', 'C1', 1, 1000011, tagDay.toISOString().slice(0, 10)],
      ['00002', 'R1', 1, 1000021, tagDay.toISOString().slice(0, 10)],
      ['00002', 'R2', 2, 1000022, tagDay.toISOString().slice(0, 10)],
    ]);
    expect(detl[1]).toMatchObject({ kf: 11.232, TAG_TYPE: 'G', CO_BOOK: '000', LC_CODE: '01' });
    const stock = await rows(
      `SELECT "VCH_TYPE","BOOK_NAME","TAG_NO","VCH_SRNO","ITM_QTY"::float q,"ITM_NWT"::float nwt,"ITM_FINE"::float f,"TR_TYPE","ITM_SIGN"
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "VCH_TYPE","VCH_SRNO","IT_CODE"`,
      CO,
    );
    expect(stock).toEqual([
      { VCH_TYPE: 'ITOBL', BOOK_NAME: 'ITM OPBL', TAG_NO: 'N', VCH_SRNO: 0, q: 2, nwt: 15.5, f: 14.198, TR_TYPE: 'P', ITM_SIGN: '+' },
      { VCH_TYPE: 'ITOBL', BOOK_NAME: 'ITM OPBL', TAG_NO: 'N', VCH_SRNO: 0, q: 0, nwt: 800, f: 740, TR_TYPE: 'P', ITM_SIGN: '+' },
      { VCH_TYPE: 'TAGOP', BOOK_NAME: 'TAG OPBL', TAG_NO: 'C1', VCH_SRNO: 1000011, q: 1, nwt: 20, f: 18.72, TR_TYPE: 'P', ITM_SIGN: '+' },
      { VCH_TYPE: 'TAGOP', BOOK_NAME: 'TAG OPBL', TAG_NO: 'R1', VCH_SRNO: 1000021, q: 1, nwt: 12, f: 11.232, TR_TYPE: 'P', ITM_SIGN: '+' },
      { VCH_TYPE: 'TAGOP', BOOK_NAME: 'TAG OPBL', TAG_NO: 'R2', VCH_SRNO: 1000022, q: 1, nwt: 8, f: 7.488, TR_TYPE: 'P', ITM_SIGN: '+' },
    ]);
    // Step 5 and the year
    expect(
      await rows(
        `SELECT "IT_CODE","VCH_NO","SR_NO","ITM_FINE"::float f FROM "ITM_OPBL" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY "SR_NO"`,
        CO,
      ),
    ).toEqual([
      { IT_CODE: 'CHN', VCH_NO: 'G', SR_NO: 1, f: 14.198 },
      { IT_CODE: 'SLB', VCH_NO: 'S', SR_NO: 2, f: 740 },
    ]);
    expect(
      await rows(`SELECT "OP_DATE" FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2`, CO),
    ).toEqual([{ OP_DATE: today }]);
    // Another tenant with the same company code is untouched.
    expect(await fingerprint(OTHER)).toEqual(otherBefore);
  });

  it('refuses a company that already has data, and a second import, writing nothing', async () => {
    const p = await previewLiteImport(runtime, scope, file());
    await applyLiteImport(runtime, scope, file(), p.previewHash);
    const before = await fingerprint(TENANT);
    const again = await previewLiteImport(runtime, scope, file());
    expect(again.refusal).toBe(DATA_IMPORT_MESSAGES.HAS_DATA);
    await expect(applyLiteImport(runtime, scope, file(), again.previewHash)).rejects.toMatchObject({
      code: 'has-data',
    });
    expect(await fingerprint(TENANT)).toEqual(before);
  });

  it('refuses a stale preview and a file with row errors, writing nothing', async () => {
    const before = await fingerprint(TENANT);
    await expect(applyLiteImport(runtime, scope, file(), '0'.repeat(64))).rejects.toMatchObject({
      code: 'stale-preview',
    });
    const f = liteFixture(CO, scope.coYear, clDate);
    (f.tables.BAR_DETL[0] as any).KR_NAME = 'KARIGAR-NAME-TOO-LONG';
    const bad = Buffer.from(JSON.stringify(f));
    const p = await previewLiteImport(runtime, scope, file(bad));
    expect(p.errors).toEqual([
      expect.objectContaining({ table: 'BAR_DETL', key: 'R1', reason: expect.stringMatching(/KR_NAME/) }),
    ]);
    await expect(applyLiteImport(runtime, scope, file(bad), p.previewHash)).rejects.toMatchObject({
      code: 'row-errors',
    });
    expect(await fingerprint(TENANT)).toEqual(before);
  });

  for (const table of ['AC_MAST', 'ITEM_MAST', 'AC_DATA', 'BAR_IDTL', 'ITM_OPBL']) {
    it(`a failure writing ${table} rolls every step back`, async () => {
      const before = await fingerprint(TENANT);
      const p = await previewLiteImport(runtime, scope, file());
      await owner.$executeRawUnsafe(
        `CREATE OR REPLACE FUNCTION data_import_fault() RETURNS trigger LANGUAGE plpgsql AS $f$
         BEGIN IF NEW.tenant_id = '${TENANT}' THEN RAISE EXCEPTION 'injected fault'; END IF; RETURN NEW; END $f$`,
      );
      await owner.$executeRawUnsafe(
        `CREATE TRIGGER data_import_fault BEFORE INSERT ON "${table}" FOR EACH ROW EXECUTE FUNCTION data_import_fault()`,
      );
      try {
        await expect(applyLiteImport(runtime, scope, file(), p.previewHash)).rejects.toThrow(
          /injected fault/,
        );
      } finally {
        await owner.$executeRawUnsafe(`DROP TRIGGER IF EXISTS data_import_fault ON "${table}"`);
        await owner.$executeRawUnsafe(`DROP FUNCTION IF EXISTS data_import_fault()`);
      }
      expect(await fingerprint(TENANT)).toEqual(before);
    });
  }
});
