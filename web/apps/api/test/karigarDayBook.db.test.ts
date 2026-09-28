/**
 * The karigar day book — plan item F3.1.
 *
 * WHY THIS WAS THE LAST IMPLEMENTABLE DAY-BOOK GAP
 * ===============================================
 * `ROJMEL-HANDBOOK.md` records karigar as the only remaining implementable Rojmel gap: the metal moved, the
 * ledger recorded it, but the evening day book did not show it. The desktop writes **29 rows across the two
 * karigar books** — 28 on 052 KARIGAR RECEIPT and 1 on 050 KARIGAR ISSUE — and the web wrote none.
 *
 * MEASURED SHAPE (all 29 real rows)
 * =================================
 *     book 052  type `11`  IT_TYPE G  SIGN '+'  len 33   21 rows   one per KR_DETL line, metal in
 *     book 050  type `05`  IT_TYPE G  SIGN '-'  len 33    1 row    one per KR_DETL line, metal out
 *     book 052  type `01`  IT_TYPE G  SIGN '+'  len 33    3 rows   NOT IMPLEMENTED
 *     book 052  type `02`  IT_TYPE A            len 23    2 rows   NOT IMPLEMENTED
 *     book 052  type `05`  IT_TYPE A            len 23    2 rows   NOT IMPLEMENTED
 *
 * Note `05` is a METAL row on book 050 and a MONEY row on book 052 — the type code alone does not identify a
 * row shape, the book does.
 *
 * Verified column sources:
 *   `AC_CODE` = the karigar, i.e. `KR_DATA.AC_CODE` — **21 of 21** real rows match.
 *   `LD_CODE` = the item group's `PURC_AC` — **25 of 25** real metal rows match.
 *   weights and fine are COPIED from the `KR_DETL` line, not recomputed, because the desktop copies them.
 *   `DR_AMT`/`CR_AMT`/`LBR_AMT` are zero on all 29 rows: a karigar metal row carries no money.
 *
 * THE PART DELIBERATELY LEFT OUT — stated so it cannot be mistaken for coverage.
 * The 7 unimplemented rows occur on exactly TWO vouchers (052/00005 and 052/00007), the only two carrying a
 * money settlement. Two vouchers cannot separate a rule from a coincidence, and `rojmel.ts` already records
 * two readings that were wrong when taken from a handful of sampled rows. The last test below pins that the
 * money rows are absent, so the day the evidence exists the assertion fails and asks to be updated.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { issueKarigar, receiveKarigar } from '../src/modules/manufacturing/karigar.js';
import { fineFor } from '@datacare/core';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'karigar-daybook';
const CO = '01';
const LC = '00';
const YEAR = '2024-2025';
/** Real books: 050 KISU KARIGAR ISSUE, 052 KREC KARIGAR RECEIPT, both BOOK_TBL_NAME='KR_DATA'. */
const ISSUE_BOOK = '050';
const RECEIVE_BOOK = '052';
/** Account 00008 is PURCHASE GOLD A/C in the real data, reached through GROUP_MAST.PURC_AC. */
const PURC_AC = '00008';
const KARIGAR = '000275';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });
const exec = (sql: string, ...p: unknown[]) =>
  withTenant(owner, TENANT, (tx: any) => tx.$executeRawUnsafe(sql, ...p));

async function wipe() {
  const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
    `SELECT table_name FROM information_schema.columns
      WHERE column_name='tenant_id' AND table_schema='public'`,
  );
  for (const t of tables) {
    await owner.$executeRawUnsafe(`DELETE FROM "${t.table_name}" WHERE tenant_id=$1`, TENANT);
  }
}

async function seed() {
  await exec(
    `INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,'Karigar Co')`,
    TENANT,
    CO,
  );
  await exec(
    `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,'Main')`,
    TENANT,
    CO,
    LC,
  );
  await exec(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     VALUES ($1,$2,$3,'2024-04-01','2025-03-31')`,
    TENANT,
    CO,
    YEAR,
  );
  // CASH_LIMIT 0 / FINE_STK_TYPE 'F' are what every real installation ships.
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","CASH_LIMIT","FINE_STK_TYPE") VALUES ($1,$2,0,'F')`,
    TENANT,
    CO,
  );
  await exec(`INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE") VALUES ($1,$2)`, TENANT, CO);
  for (const [code, name] of [
    [KARIGAR, 'KARIGAR ONE'],
    [PURC_AC, 'PURCHASE GOLD A/C'],
    ['LABOUR', 'LABOUR A/C'],
    ['00001', 'CASH ON HAND'],
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
  // The group's PURC_AC is what becomes the day-book row's LD_CODE.
  await exec(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC") VALUES ($1,$2,'GO','GOLD',$3)`,
    TENANT,
    CO,
    PURC_AC,
  );
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
     VALUES ($1,$2,'ORG','ORNAMENT GOLD','G','GO')`,
    TENANT,
    CO,
  );
  for (const [book, name, sname] of [
    [ISSUE_BOOK, 'Karigar Issue', 'KISU'],
    [RECEIVE_BOOK, 'Karigar Receipt', 'KREC'],
  ]) {
    await exec(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
          "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES ($1,$2,$3,$4,$5,$6,$7,'I','Y','KR_DATA')`,
      TENANT,
      CO,
      LC,
      book,
      name,
      sname,
      book === ISSUE_BOOK ? 'KARIGAR ISSUE' : 'KARIGAR RECEIPT',
    );
    await exec(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_NAME","MAIN_BOOK","BOOK_INOUT")
       VALUES ($1,$2,$3,$4,1,$5,$6,$7,'I')`,
      TENANT,
      CO,
      LC,
      book,
      PURC_AC,
      name,
      book === ISSUE_BOOK ? 'KARIGAR ISSUE' : 'KARIGAR RECEIPT',
    );
  }
}

const scopeFor = (book: string) => ({
  tenantId: TENANT,
  coCode: CO,
  lcCode: LC,
  coYear: YEAR,
  coBook: book,
});

async function dayBookRows(book: string, vchNo: string) {
  return (await owner.$queryRawUnsafe(
    `SELECT "LEDR_KEY","AC_CODE","LD_CODE","IT_TYPE","SIGN","IT_CODE",
            COALESCE("ITM_PCS",0)::float8 AS pcs, COALESCE("ITM_NWT",0)::float8 AS nwt,
            COALESCE("ITM_TOUCH",0)::float8 AS touch, COALESCE("ITM_FINE",0)::float8 AS fine,
            COALESCE("DR_AMT",0)::float8 AS dr, COALESCE("CR_AMT",0)::float8 AS cr
       FROM "ROJ_MEL_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "CO_BOOK"=$3 AND "VCH_NO"=$4
      ORDER BY "LEDR_KEY"`,
    TENANT,
    CO,
    book,
    vchNo,
  )) as Array<Record<string, unknown>>;
}

const line = (netWt: number) => ({
  itCode: 'ORG',
  pcs: 1,
  grossWt: netWt,
  netWt,
  touch: 92,
});

describe.runIf(RUN)('karigar day book (plan F3.1)', () => {
  beforeAll(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('a receipt writes one metal row per detail line, type 11, metal IN', async () => {
    const created = await receiveKarigar(runtime, {
      scope: scopeFor(RECEIVE_BOOK),
      karigarAc: KARIGAR,
      karigarName: 'KARIGAR ONE',
      vchDate: '2024-05-01',
      mainUser: 'kar-db',
      lines: [line(14.97), line(4.26)],
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');
    const rows = await dayBookRows(RECEIVE_BOOK, vchNo);

    // Two detail lines -> two day-book rows, exactly as real voucher 052/00009 does.
    expect(rows).toHaveLength(2);
    rows.forEach((r, i) => {
      // Row type at LEDR_KEY offset 22 (1-based); suffix is the line number right-aligned in 10.
      expect(String(r.LEDR_KEY).slice(21, 23)).toBe('11');
      expect(String(r.LEDR_KEY)).toHaveLength(33);
      expect(String(r.LEDR_KEY).slice(23).trim()).toBe(String(i + 1));
      expect(String(r.IT_TYPE)).toBe('G'); // the item's metal
      expect(String(r.SIGN)).toBe('+'); // metal IN on a receipt
      expect(String(r.AC_CODE).trim()).toBe(KARIGAR); // KR_DATA.AC_CODE — 21/21 real rows
      expect(String(r.LD_CODE).trim()).toBe(PURC_AC); // GROUP_MAST.PURC_AC — 25/25 real rows
      expect(String(r.IT_CODE).trim()).toBe('ORG');
      // A karigar metal row carries no money: zero on all 29 real rows.
      expect(Number(r.dr)).toBe(0);
      expect(Number(r.cr)).toBe(0);
    });
    // Weights are copied from the detail line, not recomputed.
    expect(Number(rows[0]!.nwt)).toBeCloseTo(14.97, 3);
    expect(Number(rows[1]!.nwt)).toBeCloseTo(4.26, 3);
    expect(Number(rows[0]!.touch)).toBeCloseTo(92, 3);
    // fine = net x touch / 100 for a receipt with no wastage: 14.97 x 92 / 100.
    expect(Number(rows[0]!.fine)).toBeCloseTo(13.772, 2);
  });

  it('an issue writes metal OUT, type 05', async () => {
    const created = await issueKarigar(runtime, {
      scope: scopeFor(ISSUE_BOOK),
      karigarAc: KARIGAR,
      karigarName: 'KARIGAR ONE',
      vchDate: '2024-05-02',
      mainUser: 'kar-db',
      lines: [line(14.96)],
    } as never);
    const vchNo = String(created.vchNo).padStart(5, '0');
    const rows = await dayBookRows(ISSUE_BOOK, vchNo);

    expect(rows).toHaveLength(1);
    const r = rows[0]!;
    // Real row 050/00001: key `01002024-20250500000105         1`, ac 000797, ld 00008, SIGN '-'.
    expect(String(r.LEDR_KEY).slice(21, 23)).toBe('05');
    expect(String(r.LEDR_KEY)).toHaveLength(33);
    expect(String(r.IT_TYPE)).toBe('G');
    expect(String(r.SIGN)).toBe('-'); // metal OUT on an issue
    expect(String(r.AC_CODE).trim()).toBe(KARIGAR);
    expect(String(r.LD_CODE).trim()).toBe(PURC_AC);
    expect(Number(r.nwt)).toBeCloseTo(14.96, 3);
  });

  it('a line whose item has no group purchase account contributes NO row, rather than a blank one', async () => {
    // A day-book row naming no account cannot be reconciled, so the builder skips it deliberately.
    await exec(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE")
       VALUES ($1,$2,'NOGRP','UNGROUPED','G','ZZ')`,
      TENANT,
      CO,
    );
    const created = await receiveKarigar(runtime, {
      scope: scopeFor(RECEIVE_BOOK),
      karigarAc: KARIGAR,
      vchDate: '2024-05-03',
      mainUser: 'kar-db',
      lines: [{ ...line(5), itCode: 'NOGRP' }],
    } as never);
    const rows = await dayBookRows(RECEIVE_BOOK, String(created.vchNo).padStart(5, '0'));
    expect(rows).toHaveLength(0);
  });

  it('PINS THE KNOWN GAP: the money rows of a settled receipt are not projected', async () => {
    /**
     * Types `01`, `02` and the money `05` total 7 real rows and appear on only two vouchers, so they are not
     * implemented. This assertion fails the day they are, which is the point: it asks to be updated rather
     * than letting a partial projection read as complete.
     *
     * Desktop reference: 052/00005 has types 01,01,02,05,11,11 and 052/00007 has 01,02,05,11,11.
     */
    const created = await receiveKarigar(runtime, {
      scope: scopeFor(RECEIVE_BOOK),
      karigarAc: KARIGAR,
      vchDate: '2024-05-04',
      mainUser: 'kar-db',
      labourAmt: 500,
      lines: [line(10)],
    } as never);
    const rows = await dayBookRows(RECEIVE_BOOK, String(created.vchNo).padStart(5, '0'));
    // Only the metal row: no money row is produced even though this receipt settles labour.
    expect(rows).toHaveLength(1);
    expect(rows.every((r) => String(r.IT_TYPE) !== 'A')).toBe(true);
  });
  it('writes the karigar cost basis onto a tag it creates, which a sale then copies', async () => {
    // P8: `stock.ts:88-93` records the measurement that a SALE LINE COPIES KR_NET_WT / KR_TOUCH / KR_FINE
    // FROM THE TAG — equal on 102 of 102 tagged sale lines in the real customer database, and not
    // derivable (KR_NET_WT x KR_TOUCH/100 fits only 7 of 92 rows). This writer CREATES tags from a
    // karigar receipt and wrote none of them, so the cost basis behind profit reporting was zero for
    // every karigar-made tag. Asserting the DATABASE, since the return value cannot show the omission.
    const created = await receiveKarigar(runtime, {
      scope: scopeFor(RECEIVE_BOOK),
      karigarAc: KARIGAR,
      karigarName: 'KARIGAR ONE',
      vchDate: '2024-05-01',
      mainUser: 'kar-tag',
      lines: [
        {
          ...line(10),
          tag: true,
          tagNo: 'KRTAG-1',
          westPct: 1.5,
          ghtWt: 0.4,
          mrp: 55000,
        },
      ],
    } as never);

    const row = (
      (await owner.$queryRawUnsafe(
        `SELECT * FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='KRTAG-1'`,
        TENANT,
      )) as Array<Record<string, unknown>>
    )[0]!;
    expect(row).toBeTruthy();

    // The cost basis a sale will copy.
    expect(Number(row.KR_NET_WT)).toBeCloseTo(10, 3);
    expect(Number(row.KR_TOUCH)).toBeCloseTo(92, 3);
    expect(Number(row.KR_WEST_PRC)).toBeCloseTo(1.5, 3);
    // karigarReceipt fine is net-only x (touch + wastage) — MS_UPDATE.cs:2691 — so it must match the
    // shared policy rather than a local formula.
    expect(Number(row.KR_FINE)).toBeCloseTo(
      fineFor('karigarReceipt', { netWt: 10, touch: 92, westPct: 1.5 }),
      3,
    );
    // Wastage and ghat on the tag itself, so it can reproduce its own fine.
    expect(Number(row.ITM_WEST_PRC)).toBeCloseTo(1.5, 3);
    expect(Number(row.ITM_GHT_WT)).toBeCloseTo(0.4, 3);
    expect(Number(row.ITM_MRP)).toBeCloseTo(55000, 2);
    // Attribution is NOT asserted here: writing MAIN_USER/HD_VCH_NO explicitly broke the karigar
    // reopen-and-save invariant, because an edit must keep the ORIGINAL creator. The write path
    // already handles it.
  });
});
