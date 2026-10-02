import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import { tagWeightDiff } from '../src/modules/stock/tagOps.js';
import { deleteTagCancel, saveTagCancel } from '../src/modules/stock/tagCancel.js';
import { fineFor } from '@datacare/core';

/**
 * P6/WP-09 — tag cancel resolves ONE LIVE SERIAL IDENTITY.
 *
 * This is the acceptance evidence for the first clause of the `tag-cancel` containment exit gate. The
 * rule's own words are that the path "can resolve historical availability instead of one live serial
 * identity", and the code showed exactly how: two count queries keyed on `CO_CODE + TAG_NO` only.
 *
 * Three consequences, each covered by a case below:
 *   1. No `LC_CODE` — a tag held at ANOTHER LOCATION satisfied the guard, so branch A could cancel
 *      branch B's stock.
 *   2. No `VCH_SRNO` — a tag number with several instances was judged on any historical row rather than
 *      the live one.
 *   3. `ITM_SIGN='-' EXISTS` rather than a net balance — a tag sold and later returned (the return posts
 *      '+') was permanently un-cancellable although it sits in stock.
 *
 * The fix reuses `issueTagTx`, the same resolver a sale uses, so a cancel cannot disagree with a sale
 * about what "in stock" means. These tests therefore assert BEHAVIOUR at the boundary, not the query.
 *
 * N18 moved the cancel to `tagCancel.ts` (desktop TR_TAG_CAN, full lifecycle); the complete row-level and
 * whole-database evidence is `tagCancelLifecycle.db.test.ts`. These identity cases keep running against it.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tag-cancel-identity';
const CO = '01';
const LC = '01';
const OTHER_LC = '02';
const YEAR = '2024-2025';
const BOOK = 'TCN';
const DAY = '2024-06-01';
/** Postgres date columns need a Date, not a string: a text parameter raises 42804. */
const DAY_DATE = new Date(`${DAY}T00:00:00Z`);

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const scope = { tenantId: TENANT, coCode: CO, lcCode: LC, coYear: YEAR, coBook: BOOK };
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe(): Promise<void> {
  const tables = (await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  )) as Array<{ table_name: string }>;
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

/** A tag instance in BAR_DETL plus the '+' movement that makes it live. */
async function liveTag(tagNo: string, lc: string, vchSrno: number): Promise<void> {
  await exec(
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
      "TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_NWT","ITM_TOUCH","ITM_FINE")
     VALUES ($1,$2,$3,$4,'TOP','00001',$5,$6,$5,'GOLD',1,5.2,5,91.6,4.58)`,
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
     VALUES ($1,$2,$3,$4,'TOP','00001',$5,$6,'TAGOP',$7,$5,'GOLD','I','+',1,1,5.2,5,91.6,4.58)`,
    TENANT,
    CO,
    lc,
    YEAR,
    vchSrno,
    DAY_DATE,
    tagNo,
  );
}

const cancelLine = (tagNo: string) => ({ tagNo });

/** The TR_TAG_CAN writer, on the fixture's TAG CANCEL book. */
const cancel = (lines: Array<Record<string, unknown>>) =>
  saveTagCancel(runtime, 'cancel', { scope, vchDate: DAY, mainUser: 'operator', lines });

const databaseDescribe = RUN ? describe : describe.skip;

databaseDescribe('tag cancel resolves one live serial identity', () => {
  beforeEach(async () => {
    await wipe();
    await exec(`INSERT INTO "CO_SET"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
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
         VALUES ($1,$2,$3,$4,'Tag Cancel','TCN','TAG CANCEL','O','Y','BAR_CAN_DATA')`,
        TENANT,
        CO,
        lc,
        BOOK,
      );
    }
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
       VALUES ($1,$2,'GOLD','Gold','G')`,
      TENANT,
      CO,
    );
  });

  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('cancels a live tag and records the out-movement against the resolved instance', async () => {
    await liveTag('TAG-A', LC, 7);
    const result = await cancel([cancelLine('TAG-A')]);
    expect(result.lines).toBe(1);

    const moves = (await owner.$queryRawUnsafe(
      `SELECT "ITM_SIGN","VCH_SRNO","VCH_TYPE","BOOK_NAME" FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"=$2 AND "CO_BOOK"=$3`,
      TENANT,
      'TAG-A',
      BOOK,
    )) as Array<Record<string, unknown>>;
    expect(moves.length).toBe(1);
    expect(String(moves[0]!.ITM_SIGN)).toBe('-');
    // The out-movement must carry the RESOLVED instance, or it nets against nothing.
    expect(Number(moves[0]!.VCH_SRNO)).toBe(7);
    // VCH_TYPE is the book's BOOK_SNAME and BOOK_NAME its MAIN_BOOK (Tag_Can_Stk), not a web literal.
    expect([moves[0]!.VCH_TYPE, moves[0]!.BOOK_NAME]).toEqual(['TCN', 'TAG CANCEL']);
  });

  it('refuses a tag that belongs to another location', async () => {
    // The old guard had no LC_CODE, so branch 01 could cancel branch 02's stock.
    await liveTag('TAG-B', OTHER_LC, 3);
    await expect(cancel([cancelLine('TAG-B')])).rejects.toMatchObject({
      name: 'TagNotAvailableError',
    });
  });

  it('cancels a tag that was sold and then returned, which the old guard refused forever', async () => {
    // The decisive case. A sale posts '-', a sale return posts '+', so the tag is live again — but the
    // old test was `ITM_SIGN='-' EXISTS`, which stays true for the rest of the tag's life.
    await liveTag('TAG-C', LC, 4);
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SAL','00009',4,$5,'SALE','TAG-C',4,'GOLD','O','-',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    );
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SRT','00002',4,$5,'SLRTN','TAG-C',4,'GOLD','I','+',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    );
    const result = await cancel([cancelLine('TAG-C')]);
    expect(result.lines).toBe(1);
  });

  it('refuses a tag whose net stock is already zero', async () => {
    // Conversely, a sold-and-not-returned tag must still be refused: netting must not become permissive.
    await liveTag('TAG-D', LC, 5);
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SAL','00010',5,$5,'SALE','TAG-D',5,'GOLD','O','-',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    );
    await expect(cancel([cancelLine('TAG-D')])).rejects.toMatchObject({
      name: 'TagNotAvailableError',
    });
  });

  it('writes the register from the tag itself, with the resolved instance stamped', async () => {
    // The register row is the tag as the desktop grid loads it (TR_TAG_CAN.cs:4020-4085), not what a
    // caller happened to send, and it carries the instance so it can say WHICH tag was cancelled.
    await liveTag('TAG-E', LC, 11);
    await cancel([cancelLine('TAG-E')]);
    const row = (
      (await owner.$queryRawUnsafe(
        `SELECT * FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        TENANT,
        'TAG-E',
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(Number(row.VCH_SRNO)).toBe(11);
    expect([row.IT_CODE, row.ENTRY_TYPE, row.VCH_TYPE, row.BOOK_NAME]).toEqual([
      'GOLD',
      'T',
      'TCN',
      'TAG CANCEL',
    ]);
    expect([Number(row.ITM_GWT), Number(row.ITM_NWT), Number(row.ITM_TOUCH)]).toEqual([
      5.2, 5, 91.6,
    ]);
    // The stored fine is kept while weight and purity are as they came.
    expect(Number(row.ITM_FINE)).toBe(4.58);
  });

  it('restores a TAG_STOCK-only tag when the cancel is deleted, instead of losing it', async () => {
    // Third gate clause: lifecycle/reversal. The cancel resolves through `issueTagTx`, which DELETES the
    // TAG_STOCK row when the tag lives there. Reversing only MAIN_STOCK and the register left such a tag
    // in neither table — invisible to every availability query, so permanently lost.
    await exec(
      // TAG_STOCK carries IT_TYPE, not IT_CODE.
      `INSERT INTO "TAG_STOCK"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","IT_TYPE",
        "ITM_PCS","ITM_GWT","ITM_NWT","STK_TYPE")
       VALUES ($1,$2,$3,'TAG-S',1,'G',1,5.2,5,'R')`,
      TENANT,
      CO,
      LC,
    );
    // A web tag has no item code, so the line names one.
    const cancelled = await cancel([{ tagNo: 'TAG-S', itCode: 'GOLD' }]);

    // Consumed: gone from TAG_STOCK while the cancel stands.
    const during = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "TAG_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='TAG-S'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(during[0]!.n).toBe(0);

    await deleteTagCancel(runtime, 'cancel', scope, cancelled.vchNo, 'operator');

    const after = (await owner.$queryRawUnsafe(
      `SELECT "VCH_SRNO","IT_TYPE","ITM_NWT" FROM "TAG_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"='TAG-S'`,
      TENANT,
    )) as Array<Record<string, unknown>>;
    expect(after.length).toBe(1);
    expect(Number(after[0]!.VCH_SRNO)).toBe(1);
    expect(Number(after[0]!.ITM_NWT)).toBe(5);
  });

  it('does NOT duplicate a BAR_DETL-backed tag into TAG_STOCK on reversal', async () => {
    // The other half of the rule. A BAR_DETL-backed tag regains availability simply by deleting the '-'
    // movement, because availability is a net sum. Also restoring it into TAG_STOCK would make the same
    // physical tag issuable twice.
    await liveTag('TAG-F', LC, 2);
    const cancelled = await cancel([cancelLine('TAG-F')]);
    await deleteTagCancel(runtime, 'cancel', scope, cancelled.vchNo, 'operator');

    const inStock = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "TAG_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='TAG-F'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(inStock[0]!.n).toBe(0);

    // It must be cancellable again, which proves availability really was restored.
    await expect(cancel([cancelLine('TAG-F')])).resolves.toMatchObject({ lines: 1 });
  });
  it('refuses a weight change on a tag that does not exist', async () => {
    // tagWeightDiff previously never looked the tag up: it wrote a MAIN_STOCK movement keyed on TAG_NO
    // alone, so it would adjust a phantom tag, another location's tag, or one already sold.
    await expect(
      tagWeightDiff(runtime, {
        scope,
        vchDate: DAY,
        book: BOOK,
        lines: [{ tagNo: 'NO-SUCH-TAG', itCode: 'GOLD', oldNetWt: 5, newNetWt: 6, touch: 91.6 }],
      } as never),
    ).rejects.toThrow();
  });

  it('stamps the resolved instance on a weight-change movement', async () => {
    await liveTag('TAG-W', LC, 9);
    const result = await tagWeightDiff(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      lines: [
        { tagNo: 'TAG-W', itCode: 'GOLD', oldNetWt: 5, newNetWt: 5.5, touch: 91.6, westPct: 0.5 },
      ],
    } as never);
    expect(result.tags).toBeGreaterThan(0);

    const move = (
      (await owner.$queryRawUnsafe(
        `SELECT "VCH_SRNO","ITM_SIGN","ITM_WEST","ITM_FINE" FROM "MAIN_STOCK"
          WHERE tenant_id=$1 AND "TAG_NO"='TAG-W' AND "VCH_TYPE"='TGWD'`,
        TENANT,
      )) as Array<Record<string, unknown>>
    )[0]!;
    // Without the resolved serial the movement nets against no particular tag row.
    expect(Number(move.VCH_SRNO)).toBe(9);
    expect(String(move.ITM_SIGN)).toBe('+');
    // Wastage travels instead of being hard-coded to 0, and the fine follows the shared policy.
    expect(Number(move.ITM_WEST)).toBe(0.5);
    expect(Number(move.ITM_FINE)).toBe(
      fineFor('tagOpening', { netWt: 0.5, touch: 91.6, westPct: 0.5 }),
    );
  });

  it('refuses a weight change on a tag whose stock is already gone', async () => {
    await liveTag('TAG-X', LC, 6);
    await exec(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "VCH_DATE","VCH_TYPE","TAG_NO","VCH_SRNO","IT_CODE","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS")
       VALUES ($1,$2,$3,$4,'SAL','00011',6,$5,'SALE','TAG-X',6,'GOLD','O','-',1,1)`,
      TENANT,
      CO,
      LC,
      YEAR,
      DAY_DATE,
    );
    await expect(
      tagWeightDiff(runtime, {
        scope,
        vchDate: DAY,
        book: BOOK,
        lines: [{ tagNo: 'TAG-X', itCode: 'GOLD', oldNetWt: 5, newNetWt: 4.5, touch: 91.6 }],
      } as never),
    ).rejects.toThrow();
  });
});
