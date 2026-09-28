import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import {
  MEMB_GOLD_ADJUST,
  deleteSchemeGoldAdjust,
  getSchemeGoldAdjust,
  schemeGoldAdjust,
} from '../src/modules/membership/scheme.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'scheme-gold-adjust';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
const BOOK = MEMB_GOLD_ADJUST.book;
const SCHEME = 'GLD';
const MEMB = '00001';
const MEMBER_AC = '000777';
const SCHEME_AC = '000858';
const GOLD_CONTROL_AC = '00008';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const rows = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as { table_name: string }[];
  for (const r of rows) await owner.$executeRawUnsafe(`DELETE FROM "${r.table_name}" WHERE tenant_id=$1`, TENANT);
}

async function seed() {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF","ALL_ROF_REMOVE")
     VALUES ($1,$2,'N',2,2,2,'N')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","TOT_AMT_ROF","PR_RATE_ROF") VALUES ($1,$2,0,2)`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  for (const [code, name] of [
    [MEMBER_AC, 'MEMBER LEDGER'],
    [SCHEME_AC, 'SCHEME LIABILITY'],
    [GOLD_CONTROL_AC, 'PURCHASE GOLD A/C'],
  ]) {
    await exec(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE")
       VALUES ($1,$2,$3,$4,$5,'L')`,
      TENANT,
      CO,
      LC,
      code,
      name,
    );
  }
  await exec(
    `INSERT INTO "AD_MAST"(tenant_id,"CO_CODE","SCHM_CODE","SCHM_NAME","SCHM_AC","SCHM_TYPE")
     VALUES ($1,$2,$3,'Gold Scheme',$4,'G')`,
    TENANT,
    CO,
    SCHEME,
    SCHEME_AC,
  );
  await exec(
    `INSERT INTO "AD_MEMB"(tenant_id,"CO_CODE","LC_CODE","SCHM_CODE","MEMB_CODE","MEMB_NAME")
     VALUES ($1,$2,$3,$4,$5,'Gold Member')`,
    TENANT,
    CO,
    LC,
    SCHEME,
    MEMB,
  );
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","DATA_TYPE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Member Gold Adjust','MGADJ','MEMB GOLD ADJ','O','Y','A','AD_ADJ')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  await exec(
    `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT")
     VALUES ($1,$2,$3,$4,1,$5,'Member Gold Adjust','MGADJ','MEMB GOLD ADJ','O')`,
    TENANT,
    CO,
    LC,
    BOOK,
    GOLD_CONTROL_AC,
  );
}

async function rows(table: string) {
  const order = table === 'AC_DATA' || table === 'ROJ_MEL_DATA' ? '"LEDR_KEY" NULLS LAST' : '"SR_NO" NULLS LAST';
  return (await owner.$queryRawUnsafe(
    `SELECT * FROM "${table}" WHERE tenant_id=$1 ORDER BY ${order}`,
    TENANT,
  )) as Array<Record<string, unknown>>;
}

describe.runIf(RUN)('scheme gold adjustment desktop lifecycle', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('writes AD_ADJ, AD_OS amount/gold rows, ledger, rojmel, readback and reversal', async () => {
    const result = await schemeGoldAdjust(runtime, {
      scope,
      vchDate: '2024-04-10',
      mainUser: 'gold-test',
      updateExpiry: true,
      lines: [
        {
          schmCode: SCHEME,
          membCode: MEMB,
          acCode: MEMBER_AC,
          acName: 'MEMBER LEDGER',
          goldWt: 2,
          goldRate: 6000,
          adjustAmount: 12000,
          less: 500,
          empCode: 'E01',
          vchDesc: 'priced gold adjustment',
        },
      ],
    });

    expect(result).toEqual({ vchNo: 1, lines: 1, goldWt: 2, goldAmt: 12000, adjustedAmount: 12000 });

    const adj = await rows('AD_ADJ');
    expect(adj).toHaveLength(1);
    expect(adj[0]).toMatchObject({
      CO_BOOK: BOOK,
      VCH_NO: '00001',
      VCH_TYPE: 'MGADJ',
      INOUT_TYPE: 'O',
      ENTRY_TYPE: 'A',
      BOOK_NAME: 'MEMB GOLD ADJ',
      SCHM_CODE: SCHEME,
      MEMB_CODE: MEMB,
      AC_CODE: MEMBER_AC,
      SIGN: '-',
      EMP_CODE: 'E01',
    });
    expect(Number(adj[0]!.GOLD_WT)).toBe(2);
    expect(Number(adj[0]!.GOLD_RATE)).toBe(6000);
    expect(Number(adj[0]!.GOLD_AMT)).toBe(12000);
    expect(Number(adj[0]!.ADJ_AMT)).toBe(12000);
    expect(Number(adj[0]!.MEMB_LESS)).toBe(500);

    const os = await rows('AD_OS');
    expect(os.map((r) => Number(r.SR_NO))).toEqual([1, 701]);
    expect(os[0]).toMatchObject({ ENTRY_TYPE: 'A', BOOK_NAME: 'MEMB GOLD ADJ', SIGN: '-', OS_TYPE: 'D', LD_CODE: MEMBER_AC });
    expect(Number(os[0]!.ADJ_AMT)).toBe(12500);
    expect(Number(os[1]!.ADJ_AMT)).toBe(0);
    expect(Number(os[1]!.GOLD_WT)).toBe(2);

    const ledger = await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","DR_AMT"::float dr,"CR_AMT"::float cr,"IT_TYPE",coalesce("SIGN",'') sign,"FINE_WT"::float fine
         FROM "AC_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      TENANT,
    ) as Array<Record<string, unknown>>;
    expect(ledger.map((r) => String(r.LEDR_KEY).slice(21, 23))).toEqual(['08', '09', '10', '11']);
    expect(ledger.every((r) => String(r.LEDR_KEY).length === 33)).toBe(true);
    expect(ledger.map((r) => [r.AC_CODE, r.LD_CODE, r.dr, r.cr])).toEqual([
      [MEMBER_AC, SCHEME_AC, 0, 500],
      [SCHEME_AC, MEMBER_AC, 500, 0],
      [GOLD_CONTROL_AC, MEMBER_AC, 11500, 0],
      [MEMBER_AC, GOLD_CONTROL_AC, 0, 11500],
    ]);

    const rojmel = await owner.$queryRawUnsafe(
      `SELECT "LEDR_KEY","AC_CODE","LD_CODE","DR_AMT"::float dr,"CR_AMT"::float cr,"IT_TYPE",coalesce("SIGN",'') sign
         FROM "ROJ_MEL_DATA" WHERE tenant_id=$1 ORDER BY "LEDR_KEY"`,
      TENANT,
    ) as Array<Record<string, unknown>>;
    expect(rojmel.map((r) => String(r.LEDR_KEY).slice(21, 23))).toEqual(['05', '06', '07', '08']);
    expect(rojmel.map((r) => [r.AC_CODE, r.LD_CODE, r.dr, r.cr, r.IT_TYPE, r.sign])).toEqual([
      [SCHEME_AC, MEMBER_AC, 0, 500, 'G', '+'],
      [MEMBER_AC, SCHEME_AC, 500, 0, 'G', '+'],
      [MEMBER_AC, GOLD_CONTROL_AC, 0, 11500, 'G', '+'],
      [GOLD_CONTROL_AC, MEMBER_AC, 11500, 0, 'G', '+'],
    ]);

    const readback = await getSchemeGoldAdjust(runtime, scope, 1);
    expect(readback.lines).toHaveLength(1);
    expect((readback.lines as Array<Record<string, unknown>>)[0]).toMatchObject({
      schmCode: SCHEME,
      membCode: MEMB,
      acCode: MEMBER_AC,
      goldWt: 2,
      goldRate: 6000,
      goldAmt: 12000,
      adjustAmount: 12000,
      less: 500,
    });

    const member = await owner.$queryRawUnsafe(
      `SELECT "EXP_DATE"::text AS exp FROM "AD_MEMB" WHERE tenant_id=$1`,
      TENANT,
    ) as Array<{ exp: string }>;
    expect(member[0]!.exp.slice(0, 10)).toBe('2024-04-10');

    await deleteSchemeGoldAdjust(runtime, { scope, vchNo: 1, deleteUser: 'tester' });
    expect(await rows('AD_ADJ')).toHaveLength(0);
    expect(await rows('AD_OS')).toHaveLength(0);
    expect(await rows('AC_DATA')).toHaveLength(0);
    expect(await rows('ROJ_MEL_DATA')).toHaveLength(0);
    const deleted = await rows('DELETE_DATA');
    expect(deleted).toHaveLength(1);
    expect(deleted[0]).toMatchObject({ CO_BOOK: BOOK, VCH_NO: '00001', VCH_TYPE: 'MGADJ', DELETE_USER: 'tester' });
    expect(Number(deleted[0]!.VCH_FINE_CR)).toBe(2);
  });
});
