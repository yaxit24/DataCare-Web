import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@datacare/db';
import { withTenant } from '@datacare/db';
import {
  editTagOpening,
  getTagOpening,
  tagOpening,
} from '../src/modules/stock/stockVoucherLifecycle.js';

/**
 * P0-06 / WP-08 — create a rich tag, reopen it, save it unchanged, and lose nothing.
 *
 * THE DEFECT THIS PROVES CLOSED
 * =============================
 * `writeTagOpeningTx` accepts 65 fields per tag line — the whole desktop grid, including every hallmark id
 * and weight, the karigar cost block, the JDT weights, and the order and manufacturing links. `getTagOpening`
 * returned 22 of them. `editTagOpening` deletes the entire write set and rebuilds it from its input, exactly as
 * the desktop does.
 *
 * Those three facts compose into silent data loss: reopen a tag, press save without touching anything, and 43
 * columns come back empty. No error, no warning, and nothing in the response to suggest the fields ever
 * existed. An operator would discover it when a HUID could not be produced for a hallmarked ornament.
 *
 * WHY THE TEST IS SHAPED THIS WAY
 * ===============================
 * It does not assert a list of field names — that would pass while the list drifted. It reads the FULL
 * persisted `BAR_DETL` row before and after, and demands equality on every column the writer controls. Any
 * field added to the writer and forgotten in the reader fails here without anyone updating this file, which is
 * the only way a symmetry invariant stays true.
 *
 * The route that performs this update is contained by WP-01, so the module is driven directly. Producing this
 * evidence is precisely what the containment rule's exit gate asks for.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tagop-roundtrip';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';
const BOOK = 'TOP';
const DAY = '2024-06-01';

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

async function seed(): Promise<void> {
  await exec(
    `INSERT INTO "CO_SET"(tenant_id,"CO_CODE","LBR_TYPE","LBR_ROF","TAX_ROF","ITM_RATE_ROF")
     VALUES ($1,$2,'N',2,2,2)`,
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
  await exec(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME",
        "MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES ($1,$2,$3,$4,'Tag Opening','TAGOP','TAG OPENING','I','Y','BAR_DATA')`,
    TENANT,
    CO,
    LC,
    BOOK,
  );
  await exec(
    `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE")
     VALUES ($1,$2,'GOLD','GOLD ORNAMENT','G')`,
    TENANT,
    CO,
  );
}

/**
 * A tag line with EVERY rich field populated and distinguishable.
 *
 * Values are deliberately non-zero and non-empty: a field defaulting to 0 or '' would round-trip by accident
 * and hide the very loss this test exists to detect. The hallmark ids carry letters, because that is the case
 * a numeric coercion destroys.
 */
const richLine = {
  tagNo: 'TAGRICH1',
  itCode: 'GOLD',
  pcs: 1,
  grossWt: 12.345,
  netWt: 11.111,
  touch: 91.6,
  ghtWt: 0.234,
  westPct: 2.5,
  rate: 6100,
  mrp: 99999.5,
  tblCode: '007',
  designNo: 'D-4711',
  itmSize: '16',
  lessWt: 1.234,
  lbrPct: 3.5,
  lbrType: 'P',
  lbrRate: 55.25,
  lbrAmt: 612.75,
  othAmt: 41.5,
  tagCost: 76543.21,
  itmStyle: 'ANTIQUE',
  itmColor: 'ROSE',
  itmMargin: 7.25,
  lbrCode: 'L07',
  slType: 'W',
  empIsu: 'N',
  designImageId: 'IMG-0001-A',
  mainMarginPct: 4.75,
  mainMrp: 101010.1,
  hallmarkId2: 'HUID2A9Z',
  hallmarkId3: 'HUID3B8Y',
  hallmarkId4: 'HUID4C7X',
  hallmarkIdWt: 1.001,
  hallmarkId2Wt: 2.002,
  hallmarkId3Wt: 3.003,
  hallmarkId4Wt: 4.004,
  karigarLbrRate: 12.5,
  karigarLbrAmt: 154.25,
  karigarOthAmt: 22.75,
  karigarOthRate: 5.5,
  karigarOthFine: 0.125,
  karigarTotFine: 10.875,
  karigarGwtTouch: 89.25,
  karigarCost: 65432.1,
  karigarName: 'KR07',
  karigarWaxWt: 0.456,
  jdtJdtWt: 1.111,
  jdtGhtWt: 2.222,
  jdtKunWt: 3.333,
  jdtKunTouch: 77.5,
  jdtKunNet: 4.444,
  jdtWaxWt: 5.555,
  ordNo: 'ORD-991',
  ordSrno: 17,
  ordYrcd: '2024-2025',
  ordDbcd: 'DB1',
  ordAc: 'PARTY0001',
  ordLcCode: '01',
  sfNo: 'SF-00001234',
  mfgNo: 'MFG-771',
  mfgYrcd: '2024-2025',
  mfgDbcd: 'DB2',
  mfgSrno: 23,
} as const;

/** The full persisted line, minus columns a re-save is entitled to change. */
async function persistedLine(): Promise<Record<string, unknown>> {
  const rows = (await withTenant(owner, TENANT, (tx) =>
    tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "SR_NO" LIMIT 1`,
      TENANT,
    ),
  )) as Array<Record<string, unknown>>;
  const row = { ...(rows[0] ?? {}) };
  // row_id is a surrogate; the edit path legitimately deletes and re-inserts, so a new one is expected.
  delete row.row_id;
  return row;
}

/**
 * The tag-opening SUB-DETAIL rows.
 *
 * `editTagOpening` DELETES BAR_IDTL and rebuilds it (stockVoucherLifecycle.ts:1264) while
 * `getTagOpening` does not return it — the shape of the write-without-read defect this project has
 * already fixed five times. Here it is NOT one: the rows are derived entirely from the same
 * `input.lines` (one row per line at ISR_NO 1, :682-696), so an unchanged save reconstructs them.
 * That was an assumption until this assertion, and turning assumptions into assertions is exactly what
 * the containment exit gate asks for.
 */
async function persistedSubDetail(): Promise<Array<Record<string, unknown>>> {
  const rows = (await withTenant(owner, TENANT, (tx) =>
    tx.$queryRawUnsafe(
      `SELECT * FROM "BAR_IDTL" WHERE tenant_id=$1 ORDER BY "SR_NO","ISR_NO"`,
      TENANT,
    ),
  )) as Array<Record<string, unknown>>;
  return rows.map((row) => {
    const copy = { ...row };
    delete copy.row_id;
    return copy;
  });
}

describe.runIf(RUN)('tag opening survives a reopen-and-save unchanged', () => {
  beforeEach(async () => {
    await wipe();
    await seed();
  });
  afterAll(async () => {
    await wipe();
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('returns every field it accepts, so a reopen loses nothing', async () => {
    await tagOpening(runtime, {
      scope,
      vchDate: DAY,
      mainUser: 'roundtrip-user',
      lines: [{ ...richLine }],
    } as never);

    const reopened = (await getTagOpening(runtime, scope, 1)) as {
      lines: Array<Record<string, unknown>>;
    };
    const line = reopened.lines[0]!;

    // Every input field must come back, with its value intact. Asserted field by field against the input
    // object itself, so adding a field to the input without adding it to the reader fails here.
    for (const [field, expected] of Object.entries(richLine)) {
      expect(line[field], `reopen dropped or changed ${field}`).toEqual(expected);
    }
  });

  it('keeps hallmark ids as text, because a HUID contains letters', async () => {
    await tagOpening(runtime, {
      scope,
      vchDate: DAY,
      mainUser: 'roundtrip-user',
      lines: [{ ...richLine }],
    } as never);
    const reopened = (await getTagOpening(runtime, scope, 1)) as {
      lines: Array<Record<string, unknown>>;
    };
    const line = reopened.lines[0]!;
    for (const field of ['hallmarkId2', 'hallmarkId3', 'hallmarkId4'] as const) {
      expect(typeof line[field], `${field} must stay a string`).toBe('string');
      expect(String(line[field])).toMatch(/[A-Z]/);
    }
  });

  it('preserves the ENTIRE persisted row across reopen and save unchanged', async () => {
    // The assertion P0-06 asks for. Before this fix, 43 columns came back empty here.
    await tagOpening(runtime, {
      scope,
      vchDate: DAY,
      mainUser: 'roundtrip-user',
      lines: [{ ...richLine }],
    } as never);
    const before = await persistedLine();
    const subBefore = await persistedSubDetail();

    const reopened = (await getTagOpening(runtime, scope, 1)) as {
      vchDate: string;
      stockItCode: string;
      lines: Array<Record<string, unknown>>;
    };
    // Feed the reopened payload straight back, which is what an operator pressing save does.
    await editTagOpening(
      runtime,
      {
        scope,
        vchDate: reopened.vchDate,
        mainUser: 'roundtrip-user',
        stockItCode: reopened.stockItCode || undefined,
        lines: reopened.lines,
      } as never,
      1,
    );
    const after = await persistedLine();
    const subAfter = await persistedSubDetail();

    expect(Object.keys(after).length).toBeGreaterThan(60);
    // The sub-detail must survive too, since edit deletes and rebuilds it.
    expect(subAfter.length).toBe(subBefore.length);
    const subChanged = subBefore.flatMap((row, index) =>
      Object.keys(row).filter(
        (column) => String(row[column] ?? '') !== String(subAfter[index]?.[column] ?? ''),
      ),
    );
    expect(
      subChanged,
      `an unchanged save must not alter BAR_IDTL, but changed: ${subChanged.join(', ')}`,
    ).toEqual([]);
    const changed = Object.keys(before).filter(
      (column) => String(before[column] ?? '') !== String(after[column] ?? ''),
    );
    expect(
      changed,
      `an unchanged save must not alter any column, but changed: ${changed.join(', ')}`,
    ).toEqual([]);
  });

  it('keeps the tag identity and its stock movement across the round trip', async () => {
    // Invariant 1 and 3 from plan §7.1, checked over the same round trip: the identity must not move and the
    // ornament must not be admitted twice by a re-save that deletes and re-inserts its movement.
    await tagOpening(runtime, {
      scope,
      vchDate: DAY,
      mainUser: 'roundtrip-user',
      lines: [{ ...richLine }],
    } as never);
    const reopened = (await getTagOpening(runtime, scope, 1)) as {
      vchDate: string;
      lines: Array<Record<string, unknown>>;
    };
    const identityBefore = { tagNo: reopened.lines[0]!.tagNo, vchSrno: reopened.lines[0]!.vchSrno };

    await editTagOpening(
      runtime,
      {
        scope,
        vchDate: reopened.vchDate,
        mainUser: 'roundtrip-user',
        lines: reopened.lines,
      } as never,
      1,
    );

    const after = (await getTagOpening(runtime, scope, 1)) as {
      lines: Array<Record<string, unknown>>;
    };
    expect({ tagNo: after.lines[0]!.tagNo, vchSrno: after.lines[0]!.vchSrno }).toEqual(
      identityBefore,
    );

    const onHand = (await withTenant(owner, TENANT, (tx) =>
      tx.$queryRawUnsafe(
        `SELECT sum(CASE WHEN "ITM_SIGN"::text='+'
                         THEN coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0)
                         ELSE -coalesce(NULLIF("ITM_PCS"::text,'')::numeric,0) END)::float net
           FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
        TENANT,
        identityBefore.tagNo,
      ),
    )) as Array<{ net: number }>;
    expect(Number(onHand[0]?.net), 'a re-save must not admit the ornament twice').toBe(1);
  });
});
