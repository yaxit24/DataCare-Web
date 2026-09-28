import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { deleteTagCancel, tagCancel, tagWeightDiff } from '../src/modules/stock/tagOps.js';
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

const cancelLine = (tagNo: string) => ({
  tagNo,
  itCode: 'GOLD',
  pcs: 1,
  grossWt: 5.2,
  netWt: 5,
  touch: 91.6,
});

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
    const result = await tagCancel(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      lines: [cancelLine('TAG-A')],
    } as never);
    expect(result.tags).toBe(1);

    const moves = (await owner.$queryRawUnsafe(
      `SELECT "ITM_SIGN","VCH_SRNO" FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "TAG_NO"=$2 AND "VCH_TYPE"='TGCAN'`,
      TENANT,
      'TAG-A',
    )) as Array<Record<string, unknown>>;
    expect(moves.length).toBe(1);
    expect(String(moves[0]!.ITM_SIGN)).toBe('-');
    // The out-movement must carry the RESOLVED instance, or it nets against nothing.
    expect(Number(moves[0]!.VCH_SRNO)).toBe(7);
  });

  it('refuses a tag that belongs to another location', async () => {
    // The old guard had no LC_CODE, so branch 01 could cancel branch 02's stock.
    await liveTag('TAG-B', OTHER_LC, 3);
    await expect(
      tagCancel(runtime, {
        scope,
        vchDate: DAY,
        book: BOOK,
        lines: [cancelLine('TAG-B')],
      } as never),
    ).rejects.toThrow();
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
    const result = await tagCancel(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      lines: [cancelLine('TAG-C')],
    } as never);
    expect(result.tags).toBe(1);
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
    await expect(
      tagCancel(runtime, {
        scope,
        vchDate: DAY,
        book: BOOK,
        lines: [cancelLine('TAG-D')],
      } as never),
    ).rejects.toThrow();
  });
  it('records the full desktop cancel-detail grid in the register', async () => {
    // Second gate clause: "full cancel detail". BAR_CAN_DETL has 76 columns and the writer populated 17,
    // so the audit trail for a cancelled tag held less than the tag itself. Asserting the DATABASE rather
    // than the return value, because a field the writer ignores is indistinguishable from success.
    await liveTag('TAG-E', LC, 11);
    await tagCancel(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      lines: [
        {
          ...cancelLine('TAG-E'),
          ghtWt: 0.3,
          westPct: 0.75,
          lessWt: 0.2,
          tagLot: 'TL-1',
          designNo: 'D-CAN-1',
          tblCode: '006',
          itmSize: '15',
          itmStyle: 'ST-C',
          itmColor: 'WG',
          itmPolish: 'MATT',
          itDesc: 'cancelled ring',
          remark: 'damaged',
          hallmarkId: 'HUID5CD',
          itemType: 'G',
          labourPct: 2.5,
          labourType: 'G',
          labourRate: 42,
          labourAmount: 210,
          otherAmount: 18,
          mrp: 70000,
          rate: 6050,
          amount: 30250,
          tagCost: 133,
          tagNetWt: 5,
          rateType: 'F',
          prCode: 'P7',
          karigarName: 'KR-C',
          karigarNetWt: 4.9,
          karigarTouch: 90,
          karigarWestPct: 0.5,
          karigarFine: 4.43,
          designImageId: 'IMG-CAN-1',
          toTblCode: '007',
        },
      ],
    } as never);

    const row = (
      (await owner.$queryRawUnsafe(
        `SELECT * FROM "BAR_CAN_DETL" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        TENANT,
        'TAG-E',
      )) as Array<Record<string, unknown>>
    )[0]!;

    // The resolved instance must be stamped, or the register cannot say WHICH tag was cancelled.
    expect(Number(row.VCH_SRNO)).toBe(11);
    // Alphanumeric HUID survives.
    expect(String(row.HM_ID)).toBe('HUID5CD');
    expect(String(row.DESIGN_NO)).toBe('D-CAN-1');
    expect(String(row.TBL_CODE)).toBe('006');
    expect(String(row.ITM_SIZE)).toBe('15');
    expect(String(row.ITM_STYLE)).toBe('ST-C');
    expect(String(row.ITM_POLISH)).toBe('MATT');
    expect(String(row.IT_DESC)).toBe('cancelled ring');
    expect(String(row.ITM_REMARK)).toBe('damaged');
    expect(String(row.KR_NAME)).toBe('KR-C');
    expect(String(row.PR_CODE)).toBe('P7');
    expect(String(row.TO_TBL_CODE)).toBe('007');
    expect(String(row.DESIGN_IMG_ID)).toBe('IMG-CAN-1');
    expect(Number(row.ITM_OTH_WT)).toBe(0.2);
    expect(Number(row.ITM_GHT_WT)).toBe(0.3);
    expect(Number(row.ITM_WEST_PRC)).toBe(0.75);
    expect(Number(row.LBR_RATE)).toBe(42);
    expect(Number(row.LBR_AMT)).toBe(210);
    expect(Number(row.OTH_AMT)).toBe(18);
    expect(Number(row.ITM_MRP)).toBe(70000);
    expect(Number(row.ITM_AMT)).toBe(30250);
    expect(Number(row.TAG_COST)).toBe(133);
    expect(Number(row.KR_FINE)).toBe(4.43);
    // Wastage belongs in the fine base, so the cancel agrees with the tag it reverses.
    expect(Number(row.ITM_FINE)).toBe(
      fineFor('tagOpening', { netWt: 5, ghtWt: 0.3, touch: 91.6, westPct: 0.75 }),
    );
  });
  it('restores a TAG_STOCK-only tag when the cancel is deleted, instead of losing it', async () => {
    // Third gate clause: lifecycle/reversal. `tagCancel` resolves through `issueTagTx`, which DELETES the
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
    const cancelled = await tagCancel(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      lines: [cancelLine('TAG-S')],
    } as never);

    // Consumed: gone from TAG_STOCK while the cancel stands.
    const during = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "TAG_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='TAG-S'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(during[0]!.n).toBe(0);

    await deleteTagCancel(runtime, scope, cancelled.vchNo, BOOK);

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
    const cancelled = await tagCancel(runtime, {
      scope,
      vchDate: DAY,
      book: BOOK,
      lines: [cancelLine('TAG-F')],
    } as never);
    await deleteTagCancel(runtime, scope, cancelled.vchNo, BOOK);

    const inStock = (await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "TAG_STOCK" WHERE tenant_id=$1 AND "TAG_NO"='TAG-F'`,
      TENANT,
    )) as Array<{ n: number }>;
    expect(inStock[0]!.n).toBe(0);

    // It must be cancellable again, which proves availability really was restored.
    await expect(
      tagCancel(runtime, {
        scope,
        vchDate: DAY,
        book: BOOK,
        lines: [cancelLine('TAG-F')],
      } as never),
    ).resolves.toMatchObject({ tags: 1 });
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
