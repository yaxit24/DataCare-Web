import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { saveTagSplit, tagSplitSource } from '../src/modules/stock/tagSplit.js';

/**
 * N19 — Tag Split resolves ONE LIVE SERIAL IDENTITY for the parent, and mints a distinct live serial identity
 * for each child. Tag Split consumes its parent through the SAME `issueTagTx` resolver a sale uses, so it inherits
 * the P6/WP-09 guarantees proven for tag cancel (tagCancelIdentity.db.test.ts): keyed on CO_CODE + LC_CODE +
 * the resolved VCH_SRNO, and judged on a NET balance rather than "a '-' exists". These cases assert the parts
 * that are specific to a split — location isolation, net-balance liveness, and the freshly minted child identity.
 *
 * Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-30-n19/contract.md.
 */
const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tag-split-identity';
const CO = '01';
const LC = '01';
const OTHER_LC = '02';
const YEAR = '2024-2025';
const BOOK = 'TSP';
const DAY = '2024-06-01';
const DAY_DATE = new Date(`${DAY}T00:00:00Z`);

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));
const query = <T>(sql: string, ...p: unknown[]) => owner.$queryRawUnsafe(sql, ...p) as Promise<T>;

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables)
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
}

/** A whole-ring tag instance in BAR_DETL plus the '+' movement that makes it live (net 10, fine 9.16). */
async function liveTag(tagNo: string, lc: string, vchSrno: number): Promise<void> {
  await exec(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
      "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE","PR_CODE","IT_TYPE","TAG_TYPE")
     VALUES ($1,$2,$3,$4,'TOP','00001',$5,$6,$5,'RNG',1,10,10,91.6,9.16,'RG','G','R')`,
    TENANT,
    CO,
    lc,
    YEAR,
    vchSrno,
    tagNo,
  );
  await exec(
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
      "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS",
      "ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE")
     VALUES ($1,$2,$3,$4,'TOP','00001',$5,$6,'TAGOP',$7,$5,'RNG','I','+',1,1,10,10,91.6,9.16)`,
    TENANT,
    CO,
    lc,
    YEAR,
    vchSrno,
    DAY_DATE,
    tagNo,
  );
}

const split = (tagNo: string) =>
  saveTagSplit(runtime, {
    scope,
    vchDate: DAY,
    mainUser: 'operator',
    parents: [{ tagNo }],
    children: [{ itCode: 'RNGH', grossWt: 10, touch: 91.6 }],
  });

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('tag split resolves one live serial identity', () => {
  beforeEach(async () => {
    await wipe();
    await exec(
      `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","TRAD_FINE") VALUES ($1,$2,'Y')`,
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
    for (const lc of [LC, OTHER_LC]) {
      await exec(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
          "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
         VALUES ($1,$2,$3,$4,'Tag Split','TGSPL','TAG SPLIT','O','Y','LBR_DATA')`,
        TENANT,
        CO,
        lc,
        BOOK,
      );
      await exec(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE")
         VALUES ($1,$2,$3,$4,5,'LBREXP')`,
        TENANT,
        CO,
        lc,
        BOOK,
      );
    }
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","TAG_TYPE")
       VALUES ($1,$2,'RNG','Ring','G','RG','R'),($1,$2,'RNGH','Half Ring','G','RH','H')`,
      TENANT,
      CO,
    );
    await exec(
      `INSERT INTO "SRNO_MAST"(tenant_id,"CO_CODE","LC_CODE","TAG_SRNO","VCH_SRNO","TAG_NO","IT_CODE")
       VALUES ($1,$2,$3,7000,0,'','')`,
      TENANT,
      CO,
      LC,
    );
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('splits a live tag and records the parent out-movement against the resolved instance', async () => {
    await liveTag('TAG-A', LC, 71);
    const result = await split('TAG-A');
    expect(result).toMatchObject({ parents: 1, children: 1 });
    const [out] = await query<Array<Record<string, unknown>>>(
      `SELECT "ITM_SIGN","VCH_SRNO"::float8 id,"TR_TYPE" FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"='TAG-A' AND "CO_BOOK"='TSP'`,
      TENANT,
    );
    expect(out).toMatchObject({ ITM_SIGN: '-', id: 71, TR_TYPE: 'O' });
  });

  it('refuses a parent that belongs to another location', async () => {
    await liveTag('TAG-B', OTHER_LC, 33);
    await expect(split('TAG-B')).rejects.toMatchObject({ name: 'TagNotAvailableError' });
  });

  it('splits a parent sold and then returned (net live), which an "a minus exists" guard would refuse forever', async () => {
    await liveTag('TAG-C', LC, 44);
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SAL','00009',44,$5,'SALE','TAG-C',44,'RNG','O','-',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SRT','00002',44,$5,'SLRTN','TAG-C',44,'RNG','I','+',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    );
    await expect(split('TAG-C')).resolves.toMatchObject({ parents: 1, children: 1 });
  });

  it('refuses a parent whose net stock is already zero', async () => {
    await liveTag('TAG-D', LC, 55);
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SAL','00010',55,$5,'SALE','TAG-D',55,'RNG','O','-',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    );
    await expect(split('TAG-D')).rejects.toMatchObject({ name: 'TagNotAvailableError' });
  });

  it('refuses an ambiguous tag number with two live instances instead of picking the first', async () => {
    // Two live BAR_DETL instances share one number. The shared resolver must refuse rather than silently take
    // the first — the parent identity is otherwise indeterminate, and a wrong instance would be consumed.
    await liveTag('TAG-M', LC, 61);
    await liveTag('TAG-M', LC, 62);
    await expect(split('TAG-M')).rejects.toMatchObject({
      name: 'TagIdentityAmbiguousValidationError',
    });
    // Neither instance was consumed.
    for (const id of [61, 62]) {
      const rows = await query<Array<{ n: number }>>(
        `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS n
           FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='TAG-M' AND "VCH_SRNO"=$2`,
        TENANT,
        id,
      );
      expect(Number(rows[0]?.n)).toBe(1);
    }
  });

  it('mints each child as a distinct live serial identity, resolvable on its own', async () => {
    await liveTag('TAG-E', LC, 88);
    await split('TAG-E');
    const [child] = await query<Array<Record<string, unknown>>>(
      `SELECT "TAG_NO","VCH_SRNO"::float8 id FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='TSP' ORDER BY "SR_NO"`,
      TENANT,
    );
    // The child's number is freshly allocated (prefix from its item PR_CODE, serial past the seeded counter).
    expect(String(child!.TAG_NO)).toMatch(/^RH0*7\d{3}$/);
    expect(Number(child!.id)).toBeGreaterThan(7000);
    // The child resolves as its own live tag — it can itself be previewed for a further split.
    const preview = await tagSplitSource(runtime, scope, { tagNo: String(child!.TAG_NO) });
    expect(preview).toMatchObject({
      tagNo: String(child!.TAG_NO),
      source: 'BAR_DETL',
      line: { netWt: 10 },
    });
    // And it is NOT the parent's identity: the parent (TAG-E, 88) is no longer live.
    await expect(tagSplitSource(runtime, scope, { tagNo: 'TAG-E' })).rejects.toMatchObject({
      name: 'TagNotAvailableError',
    });
  });
});
