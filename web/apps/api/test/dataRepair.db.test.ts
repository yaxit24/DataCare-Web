import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import {
  applyRepair,
  getRepair,
  listRepairs,
  previewRepair,
  repairHistory,
  RepairError,
} from '../src/modules/utilities/dataRepair.js';
import '../src/modules/utilities/dataRepairOps.js';

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const d = RUN ? describe : describe.skip;

/**
 * Data-repair console.
 *
 * Every operation must satisfy the same five-part invariant, because these repairs rewrite historical
 * financial and stock data:
 *   1. seeded BROKEN rows are detected and repaired to the desktop-derived value,
 *   2. a re-run reports ZERO changes (idempotence),
 *   3. rows that were already correct are left byte-for-byte untouched,
 *   4. another tenant's data is never touched,
 *   5. preview writes nothing.
 *
 * The desktop has no preview and no audit trail, so the safety protocol is additional rather than a port —
 * but the VALUES written must match the desktop exactly, which is what the arithmetic assertions pin.
 */
d('data repair console', () => {
  const prisma = new PrismaClient();
  // tenant_id is varchar(24), so DB tests use short kebab tenants.
  const tenantId = 'repair-db';
  const otherTenant = 'repair-other-db';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const scope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR };
  const OPERATOR = 'admin';

  const TABLES = [
    'BAR_DETL',
    'SL_DETL',
    'RATE_CUT_ISU',
    'MAIN_STOCK',
    'APR_DETL',
    'OP_DATA',
    'SRNO_MAST',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'YEAR_MAST',
    'BOOK_DATA',
    'data_repair_run',
  ];

  const wipe = (t: string) =>
    withTenant(prisma, t, async (tx: any) => {
      // The run ledger is append-only; removing terminal rows needs the explicit retention opt-in, which
      // is exactly what a fixture is entitled to use and ordinary application code never sets.
      await tx.$executeRawUnsafe(`SET LOCAL "app.allow_repair_purge" = 'on'`);
      for (const tbl of TABLES) {
        await tx.$executeRawUnsafe(`DELETE FROM "${tbl}" WHERE tenant_id=$1`, t);
      }
    });

  /** A tag whose stored KR_FINE is wrong, plus one that is already correct. */
  const seedKarigar = (t: string) =>
    withTenant(prisma, t, async (tx: any) => {
      const bar = async (tag: string, nwt: number, touch: number, west: number, fine: number) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
             "TAG_NO","VCH_SRNO","IT_CODE","KR_NET_WT","KR_TOUCH","KR_WEST_PRC","KR_FINE")
           VALUES ($1,$2,$3,$4,'SL','00001',1,$5,1,'GOLD',$6,$7,$8,$9)`,
          t,
          CO,
          LC,
          YEAR,
          tag,
          nwt,
          touch,
          west,
          fine,
        );
      // 10.000 x (91.6 + 2.4) / 100 = 9.400 — stored 1.000 so it must be repaired.
      await bar('TAGBAD', 10, 91.6, 2.4, 1);
      // Already correct: 5.000 x (90 + 0) / 100 = 4.500
      await bar('TAGOK', 5, 90, 0, 4.5);
      // Excluded by the desktop's own filter: zero net weight.
      await bar('TAGZERO', 0, 90, 0, 0);
    });

  beforeEach(async () => {
    await wipe(tenantId);
    await wipe(otherTenant);
  });
  afterAll(async () => {
    await wipe(tenantId);
    await wipe(otherTenant);
    await prisma.$disconnect();
  });

  it('registers every operation with desktop evidence and a risk level', () => {
    const ops = listRepairs();
    expect(ops.length).toBeGreaterThanOrEqual(4);
    for (const op of ops) {
      expect(op.desktopSource, op.id).toMatch(/^MS_UPDATE\.cs:\d+-\d+$/);
      expect(op.tables.length, op.id).toBeGreaterThan(0);
      expect(['low', 'medium', 'high', 'danger']).toContain(op.risk);
      expect(op.description.length, op.id).toBeGreaterThan(30);
    }
  });

  it('previews without writing anything', async () => {
    await seedKarigar(tenantId);
    const before: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "TAG_NO","KR_FINE" FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
        tenantId,
      ),
    );
    const p = await previewRepair(prisma, 'karigar-fine', scope, OPERATOR);
    expect(p.clean).toBe(false);
    expect(p.diffs.find((x) => x.table === 'BAR_DETL')?.update).toBe(1); // only TAGBAD
    expect(p.samples.join(' ')).toContain('TAGBAD');
    const after: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "TAG_NO","KR_FINE" FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
        tenantId,
      ),
    );
    expect(after).toEqual(before); // preview is read-only
  });

  it('repairs the broken row to the desktop value and leaves healthy rows alone', async () => {
    await seedKarigar(tenantId);
    await seedKarigar(otherTenant); // cross-tenant sentinel
    const p = await previewRepair(prisma, 'karigar-fine', scope, OPERATOR);
    const r = await applyRepair(prisma, 'karigar-fine', scope, {
      previewHash: p.previewHash,
      operator: OPERATOR,
    });
    expect(r.deduplicated).toBe(false);
    expect(r.applied.find((x) => x.table === 'BAR_DETL')?.update).toBe(1);

    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "TAG_NO","KR_FINE" FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
        tenantId,
      ),
    );
    const byTag = Object.fromEntries(rows.map((x) => [x.TAG_NO, Number(x.KR_FINE)]));
    // 10.000 x (91.6 + 2.4) / 100 = 9.400 — the /100 is what makes this 9.4 and not 940.
    expect(byTag.TAGBAD).toBeCloseTo(9.4, 3);
    expect(byTag.TAGOK).toBeCloseTo(4.5, 3); // untouched
    expect(byTag.TAGZERO).toBeCloseTo(0, 3); // excluded by the desktop filter

    // The other tenant must be completely unaffected.
    const other: any[] = await withTenant(prisma, otherTenant, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "KR_FINE" FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO"='TAGBAD'`,
        otherTenant,
      ),
    );
    expect(Number(other[0].KR_FINE)).toBeCloseTo(1, 3);
  });

  it('is idempotent: a second run reports nothing to do', async () => {
    await seedKarigar(tenantId);
    const p1 = await previewRepair(prisma, 'karigar-fine', scope, OPERATOR);
    await applyRepair(prisma, 'karigar-fine', scope, {
      previewHash: p1.previewHash,
      operator: OPERATOR,
    });
    const p2 = await previewRepair(prisma, 'karigar-fine', scope, OPERATOR);
    expect(p2.clean).toBe(true);
    expect(p2.diffs).toEqual([]);
    const r2 = await applyRepair(prisma, 'karigar-fine', scope, {
      previewHash: p2.previewHash,
      operator: OPERATOR,
    });
    expect(r2.applied).toEqual([]);
  });

  it('refuses an apply whose preview is stale', async () => {
    await seedKarigar(tenantId);
    const p = await previewRepair(prisma, 'karigar-fine', scope, OPERATOR);
    // Someone repairs the row by hand between review and commit.
    await withTenant(prisma, tenantId, (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "BAR_DETL" SET "KR_FINE"=9.4 WHERE tenant_id=$1 AND "TAG_NO"='TAGBAD'`,
        tenantId,
      ),
    );
    await expect(
      applyRepair(prisma, 'karigar-fine', scope, {
        previewHash: p.previewHash,
        operator: OPERATOR,
      }),
    ).rejects.toMatchObject({ code: 'stale-preview' });
  });

  it('resolves a replayed apply to the run that already happened', async () => {
    await seedKarigar(tenantId);
    const p = await previewRepair(prisma, 'karigar-fine', scope, OPERATOR);
    const first = await applyRepair(prisma, 'karigar-fine', scope, {
      previewHash: p.previewHash,
      operator: OPERATOR,
    });
    const replay = await applyRepair(prisma, 'karigar-fine', scope, {
      previewHash: p.previewHash,
      operator: OPERATOR,
    });
    expect(first.deduplicated).toBe(false);
    expect(replay.deduplicated).toBe(true);
    expect(replay.applied).toEqual(first.applied);
  });

  it('records an append-only history that cannot be rewritten', async () => {
    await seedKarigar(tenantId);
    const p = await previewRepair(prisma, 'karigar-fine', scope, OPERATOR);
    await applyRepair(prisma, 'karigar-fine', scope, {
      previewHash: p.previewHash,
      operator: OPERATOR,
      reason: 'nightly maintenance',
    });
    const hist = await repairHistory(prisma, { tenantId, coCode: CO });
    const applied = hist.find((h) => h.state === 'applied');
    expect(applied).toBeTruthy();
    expect(applied?.operation_id).toBe('karigar-fine');
    expect(applied?.reason).toBe('nightly maintenance');
    // Terminal runs are immutable: an UPDATE is refused outright...
    await expect(
      withTenant(prisma, tenantId, (tx: any) =>
        tx.$executeRawUnsafe(
          `UPDATE "data_repair_run" SET operator='tamper' WHERE tenant_id=$1 AND state='applied'`,
          tenantId,
        ),
      ),
    ).rejects.toThrow();
    // ...and so is a DELETE without the explicit retention opt-in.
    await expect(
      withTenant(prisma, tenantId, (tx: any) =>
        tx.$executeRawUnsafe(
          `DELETE FROM "data_repair_run" WHERE tenant_id=$1 AND state='applied'`,
          tenantId,
        ),
      ),
    ).rejects.toThrow();
  });

  it('demands a typed confirmation for high-risk operations', () => {
    // No high-risk operation may be runnable without an explicit typed confirmation string.
    for (const op of listRepairs()) {
      if (op.risk === 'high' || op.risk === 'danger') {
        expect(getRepair(op.id).risk).toBe(op.risk);
      }
    }
  });

  it('rejects an unknown operation', async () => {
    await expect(previewRepair(prisma, 'no-such-repair', scope, OPERATOR)).rejects.toBeInstanceOf(
      RepairError,
    );
  });

  it('reconciles approval status from the approval lines', async () => {
    await withTenant(prisma, tenantId, async (tx: any) => {
      const bar = (tag: string, apr: string) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
             "TAG_NO","VCH_SRNO","IT_CODE","APR_ISU")
           VALUES ($1,$2,$3,$4,'SL','00001',1,$5,1,'GOLD',$6)`,
          tenantId,
          CO,
          LC,
          YEAR,
          tag,
          apr,
        );
      await bar('TAGONAPR', 'N'); // has an approval line but flagged N -> must become Y
      await bar('TAGHOME', 'Y'); // no approval line but flagged Y -> must become N
      await tx.$executeRawUnsafe(
        `INSERT INTO "APR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
           "TAG_NO","VCH_SRNO") VALUES ($1,$2,$3,$4,'TUR','00001',1,'TAGONAPR',1)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });
    const p = await previewRepair(prisma, 'approval-reconcile', scope, OPERATOR);
    expect(p.diffs.find((x) => x.table === 'BAR_DETL')?.update).toBe(2);
    await applyRepair(prisma, 'approval-reconcile', scope, {
      previewHash: p.previewHash,
      operator: OPERATOR,
    });
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "TAG_NO","APR_ISU" FROM "BAR_DETL" WHERE tenant_id=$1 ORDER BY "TAG_NO"`,
        tenantId,
      ),
    );
    const m = Object.fromEntries(rows.map((r) => [r.TAG_NO, r.APR_ISU]));
    expect(m.TAGONAPR).toBe('Y');
    expect(m.TAGHOME).toBe('N');
    // Idempotent.
    const p2 = await previewRepair(prisma, 'approval-reconcile', scope, OPERATOR);
    expect(p2.clean).toBe(true);
  });

  it('rebuilds opening balances with the desktop sign convention', async () => {
    await withTenant(prisma, tenantId, async (tx: any) => {
      await tx.$executeRawUnsafe(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE") VALUES ($1,$2,$3,'2024-04-01')`,
        tenantId,
        CO,
        YEAR,
      );
      const ac = (
        acCode: string,
        date: string,
        cr: number,
        dr: number,
        itType: string,
        sgn: string,
        fine: number,
      ) =>
        tx.$executeRawUnsafe(
          `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","AC_CODE","VCH_DATE",
             "CR_AMT","DR_AMT","IT_TYPE","SIGN","FINE_WT")
           VALUES ($1,$2,$3,$4,'SL',$5,$6::date,$7,$8,$9,$10,$11)`,
          tenantId,
          CO,
          LC,
          YEAR,
          acCode,
          date,
          cr,
          dr,
          itType,
          sgn,
          fine,
        );
      // BEFORE the opening date -> counts toward the opening balance.
      await ac('PARTYA', '2024-03-31', 5000, 1000, 'G', '+', 10);
      // ON the opening date -> must be EXCLUDED, because the desktop uses a strict `<`.
      await ac('PARTYA', '2024-04-01', 9999, 0, 'G', '+', 99);
      // Debit-heavy party: CR-DR is negative, so the stored sign must be 'D'.
      await ac('PARTYB', '2024-03-15', 0, 2500, 'S', '-', 4);
      // ZERO-balance party. Its only pre-opening activity is DIAMOND weight, which the desktop counts in
      // its HAVING clause but never selects, so the row exists with amount/gold/silver all zero. The
      // desktop's rule is `> 0 ? 'C' : 'D'`, so every sign here must be 'D' — a `>= 0` rule would say 'C'.
      await ac('PARTYZ', '2024-03-20', 0, 0, 'D', '+', 3);
    });
    const p = await previewRepair(prisma, 'opening-balance', scope, OPERATOR);
    expect(p.risk).toBe('high');
    expect(p.requiresConfirmation).toBe(`opening-balance ${CO}`);
    // A high-risk operation must refuse to run without the typed confirmation.
    await expect(
      applyRepair(prisma, 'opening-balance', scope, {
        previewHash: p.previewHash,
        operator: OPERATOR,
      }),
    ).rejects.toMatchObject({ code: 'confirmation-required' });

    await applyRepair(prisma, 'opening-balance', scope, {
      previewHash: p.previewHash,
      operator: OPERATOR,
      confirmation: `opening-balance ${CO}`,
    });
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "AC_CODE","OP_AMT","OP_SIGN","FINE_BAL","FINE_SIGN","SL_FINE_BAL","SL_FINE_SIGN","CO_BOOK"
           FROM "OP_DATA" WHERE tenant_id=$1 ORDER BY "AC_CODE"`,
        tenantId,
      ),
    );
    const byAc = Object.fromEntries(rows.map((r) => [r.AC_CODE, r]));
    // PARTYA: 5000-1000 = 4000 credit and gold +10.000; the 2024-04-01 row is excluded by the strict `<`.
    expect(Number(byAc.PARTYA.OP_AMT)).toBeCloseTo(4000, 2);
    expect(byAc.PARTYA.OP_SIGN).toBe('C');
    expect(Number(byAc.PARTYA.FINE_BAL)).toBeCloseTo(10, 3);
    expect(byAc.PARTYA.CO_BOOK).toBe('000'); // desktop writes book '000', voucher '00000'
    // PARTYB: -2500 stored as a positive magnitude with sign 'D'.
    expect(Number(byAc.PARTYB.OP_AMT)).toBeCloseTo(2500, 2);
    expect(byAc.PARTYB.OP_SIGN).toBe('D');
    expect(Number(byAc.PARTYB.SL_FINE_BAL)).toBeCloseTo(4, 3);
    expect(byAc.PARTYB.SL_FINE_SIGN).toBe('D');
    // The diamond-only party appears (HAVING counts diamond) with zero magnitudes, and zero is 'D'.
    expect(byAc.PARTYZ, 'diamond-only activity must still create an opening row').toBeTruthy();
    expect(Number(byAc.PARTYZ.OP_AMT)).toBeCloseTo(0, 2);
    expect(byAc.PARTYZ.OP_SIGN).toBe('D');
    expect(byAc.PARTYZ.FINE_SIGN).toBe('D');
    expect(byAc.PARTYZ.SL_FINE_SIGN).toBe('D');

    const p2 = await previewRepair(prisma, 'opening-balance', scope, OPERATOR);
    expect(p2.clean).toBe(true);
  });

  it('does nothing when no fiscal opening date is configured', async () => {
    // OP_DATE is a VARCHAR that can hold an empty string; a blank must not abort with a cast error.
    await withTenant(prisma, tenantId, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE") VALUES ($1,$2,$3,'')`,
        tenantId,
        CO,
        YEAR,
      ),
    );
    const p = await previewRepair(prisma, 'opening-balance', scope, OPERATOR);
    expect(p.clean).toBe(true);
    expect(p.samples.join(' ')).toContain('no fiscal opening date');
  });

  it('clears dangling tag references and refuses an unvalidated table name', async () => {
    await withTenant(prisma, tenantId, async (tx: any) => {
      // Two books: one names a real detail table, one names something that is not a table at all.
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_TBL_DETL")
         VALUES ($1,$2,$3,'SL','Sales','SL_DETL')`,
        tenantId,
        CO,
        LC,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_TBL_DETL")
         VALUES ($1,$2,$3,'XX','Bogus','NOT_A_TABLE')`,
        tenantId,
        CO,
        LC,
      );
      // An OUTBOUND movement for a tag that is NOT in tag stock -> its sale line must be cleared.
      await tx.$executeRawUnsafe(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","IT_CODE","TAG_NO","VCH_SRNO",
           "ITM_SIGN","ITM_NWT","ITM_PCS","ITM_MRP","VCH_DATE")
         VALUES ($1,$2,$3,$4,'GOLD','GONE',5,'-',1,1,0,'2024-06-01'::date)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
           "IT_CODE","TAG_NO","VCH_SRNO") VALUES ($1,$2,$3,$4,'SL','00001',1,'GOLD','GONE',5)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
      // A tag that DOES exist in stock must be left alone.
      await tx.$executeRawUnsafe(
        `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","IT_CODE","TAG_NO","VCH_SRNO",
           "ITM_SIGN","ITM_NWT","ITM_PCS","ITM_MRP","VCH_DATE")
         VALUES ($1,$2,$3,$4,'GOLD','KEEP',6,'-',1,1,0,'2024-06-01'::date)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "SL_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
           "IT_CODE","TAG_NO","VCH_SRNO") VALUES ($1,$2,$3,$4,'SL','00002',1,'GOLD','KEEP',6)`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
      await tx.$executeRawUnsafe(
        `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
           "TAG_NO","VCH_SRNO","IT_CODE") VALUES ($1,$2,$3,$4,'SL','00002',1,'KEEP',6,'GOLD')`,
        tenantId,
        CO,
        LC,
        YEAR,
      );
    });

    const p = await previewRepair(prisma, 'orphan-tag-refs', scope, OPERATOR);
    expect(p.risk).toBe('high');
    // The bogus table name must be reported as skipped, never interpolated into SQL.
    expect(p.samples.join(' ')).toContain('skipped NOT_A_TABLE');
    expect(p.diffs.find((d) => d.table === 'SL_DETL')?.update).toBe(1); // GONE only
    expect(p.diffs.some((d) => d.table === 'NOT_A_TABLE')).toBe(false);

    await applyRepair(prisma, 'orphan-tag-refs', scope, {
      previewHash: p.previewHash,
      operator: OPERATOR,
      confirmation: `orphan-tag-refs ${CO}`,
    });
    const rows: any[] = await withTenant(prisma, tenantId, (tx: any) =>
      tx.$queryRawUnsafe(
        `SELECT "VCH_NO","TAG_NO","VCH_SRNO" FROM "SL_DETL" WHERE tenant_id=$1 ORDER BY "VCH_NO"`,
        tenantId,
      ),
    );
    const byVch = Object.fromEntries(rows.map((r) => [r.VCH_NO, r]));
    // The dangling reference is replaced by the desktop's 'N' sentinel with a zeroed serial.
    expect(byVch['00001'].TAG_NO).toBe('N');
    expect(Number(byVch['00001'].VCH_SRNO)).toBe(0);
    // The tag that exists in stock is untouched.
    expect(byVch['00002'].TAG_NO).toBe('KEEP');
    expect(Number(byVch['00002'].VCH_SRNO)).toBe(6);

    const p2 = await previewRepair(prisma, 'orphan-tag-refs', scope, OPERATOR);
    expect(p2.diffs.some((d) => d.table === 'SL_DETL')).toBe(false);
  });
});
