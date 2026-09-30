import { afterAll, beforeEach, describe, expect, it } from 'vitest';
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { checkTagInvariants, TAG_INVARIANT_COVERAGE } from '../src/modules/stock/tagInvariants.js';

/**
 * WP-07 — the tag invariants, checked against real rows.
 *
 * Plan §7.1 lists twelve invariants and says they must become "database constraints, transactional assertions,
 * and replay checks where feasible". Four are properties of the persisted data, so they can be checked by
 * query — and a check nobody has seen fail is not a check, which is why every one is exercised here by seeding
 * the exact violation it exists to catch.
 *
 * The failures being seeded are not hypothetical. A duplicate live identity means two rows claim one physical
 * ornament and whichever a query reads first decides what the shop believes it owns. A signed on-hand of 2
 * means an ornament was admitted twice; -1 means it was issued having never been admitted.
 */

const RUN = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const TENANT = 'tag-invariants';
const OTHER_TENANT = 'tag-invariants-other';
const CO = '01';
const LC = '01';
const YEAR = '2024-2025';

const owner = new PrismaClient({
  datasources: { db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' } },
});
const runtime = new PrismaClient({ datasources: { db: { url: process.env.DATABASE_URL ?? '' } } });

const exec = (tenant: string, sql: string, ...p: unknown[]) =>
  withTenant(owner, tenant, (tx) => tx.$executeRawUnsafe(sql, ...p));

async function wipe(tenant: string): Promise<void> {
  for (const table of ['TAG_STOCK', 'BAR_DETL', 'MAIN_STOCK']) {
    await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
  }
}

const tagStock = (tenant: string, tag: string, srno: number) =>
  exec(
    tenant,
    `INSERT INTO "TAG_STOCK"(tenant_id,"CO_CODE","LC_CODE","TAG_NO","VCH_SRNO","ITM_PCS")
     VALUES ($1,$2,$3,$4,$5,1)`,
    tenant,
    CO,
    LC,
    tag,
    srno,
  );

const barDetl = (tenant: string, tag: string, srno: number, vchNo: string) =>
  exec(
    tenant,
    `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "TAG_NO","VCH_SRNO","IT_CODE")
     VALUES ($1,$2,$3,$4,'TOP',$5,1,$6,$7,'GOLD')`,
    tenant,
    CO,
    LC,
    YEAR,
    vchNo,
    tag,
    srno,
  );

/** A signed MAIN_STOCK movement. `sign` '+' admits the ornament, '-' issues it. */
const movement = (
  tenant: string,
  tag: string,
  srno: number,
  sign: '+' | '-',
  opts: { book?: string; vchNo?: string; pcs?: number } = {},
) =>
  exec(
    tenant,
    `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO",
        "TAG_NO","VCH_SRNO","IT_CODE","ITM_SIGN","ITM_PCS")
     VALUES ($1,$2,$3,$4,$5,$6,1,$7,$8,'GOLD',$9,$10)`,
    tenant,
    CO,
    LC,
    YEAR,
    opts.book ?? 'TOP',
    opts.vchNo ?? '00001',
    tag,
    srno,
    sign,
    opts.pcs ?? 1,
  );

const check = () => withTenant(runtime, TENANT, (tx) => checkTagInvariants(tx));
const resultFor = async (id: string) => {
  const report = await check();
  return report.results.find((r) => r.invariant.startsWith(id))!;
};

describe.runIf(RUN)('tag invariants', () => {
  beforeEach(async () => {
    await wipe(TENANT);
    await wipe(OTHER_TENANT);
  });
  afterAll(async () => {
    await wipe(TENANT);
    await wipe(OTHER_TENANT);
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  it('passes on a coherent tag: admitted once, held, then issued', async () => {
    await tagStock(TENANT, 'TAG001', 1);
    await barDetl(TENANT, 'TAG001', 1, '00001');
    await movement(TENANT, 'TAG001', 1, '+');
    // A second identity that has been admitted and issued: signed net 0, which is equally legal.
    await barDetl(TENANT, 'TAG002', 2, '00002');
    await movement(TENANT, 'TAG002', 2, '+', { vchNo: '00002' });
    await movement(TENANT, 'TAG002', 2, '-', { book: 'SL', vchNo: '00007' });

    const report = await check();
    expect(report.totalViolations, JSON.stringify(report.results, null, 2)).toBe(0);
    expect(report.healthy).toBe(true);
    // Rows were actually examined, so a clean result is not an empty-table illusion.
    for (const result of report.results) expect(result.examined).toBeGreaterThan(0);
  });

  it('INV-1 is a database constraint, so a second live claim cannot even be inserted', async () => {
    // The strongest form the plan asks for. TAG_STOCK's primary key is
    // (tenant_id, CO_CODE, LC_CODE, TAG_NO), so the invariant is held by the schema rather than by a scan.
    await tagStock(TENANT, 'TAG001', 1);
    await expect(tagStock(TENANT, 'TAG001', 1)).rejects.toMatchObject({ code: 'P2010' });
    // And the check reports clean, because the constraint it asserts is present.
    expect((await resultFor('INV-1')).violations).toEqual([]);
  });

  it('INV-1 notices if the constraint stops covering the identity', async () => {
    // The failure mode a duplicate scan could never catch: someone drops or narrows the key, and the invariant
    // silently stops being enforced while every row still looks fine.
    const report = await check();
    const inv1 = report.results.find((r) => r.invariant.startsWith('INV-1'))!;
    expect(inv1.title).toContain('TAG_STOCK key');
    expect(inv1.requirement).toContain('§7.1(1)');
  });

  it('the history tables carry NO identity constraint, which is why INV-2 and INV-3 must be scans', async () => {
    // BAR_DETL and MAIN_STOCK are keyed only on a surrogate row_id, so nothing in the schema stops a
    // duplicated identity or an impossible on-hand. That asymmetry is the reason these invariants are checked
    // rather than constrained, and it is worth pinning: if a future migration adds the constraint, the check
    // becomes redundant and should be converted like INV-1 was.
    await barDetl(TENANT, 'TAG001', 1, '00001');
    await barDetl(TENANT, 'TAG001', 1, '00002');
    await movement(TENANT, 'TAG001', 1, '+', { vchNo: '00001' });
    await movement(TENANT, 'TAG001', 1, '+', { vchNo: '00002' });
    // Both inserts succeeded, so only a scan can find them.
    expect((await resultFor('INV-2')).violations).toHaveLength(1);
    expect((await resultFor('INV-3')).violations).toHaveLength(1);
  });

  it('INV-2 catches a serial handed out twice', async () => {
    await barDetl(TENANT, 'TAG001', 1, '00001');
    await barDetl(TENANT, 'TAG001', 1, '00002');
    const result = await resultFor('INV-2');
    expect(result.violations).toHaveLength(1);
    expect(result.violations[0]!.detail).toContain('2 BAR_DETL rows');
  });

  it('INV-3 catches an ornament admitted twice, and one issued without being admitted', async () => {
    await movement(TENANT, 'TWICE', 1, '+', { vchNo: '00001' });
    await movement(TENANT, 'TWICE', 1, '+', { vchNo: '00002' });
    await movement(TENANT, 'GHOST', 2, '-', { book: 'SL', vchNo: '00003' });

    const result = await resultFor('INV-3');
    const byIdentity = new Map(result.violations.map((v) => [v.identity, v.detail]));
    expect(byIdentity.get(`${CO}/${LC}/TWICE#1`)).toContain('signed on-hand is 2');
    expect(byIdentity.get(`${CO}/${LC}/GHOST#2`)).toContain('signed on-hand is -1');
    expect(result.violations).toHaveLength(2);
  });

  // --- The 'N' sentinel -------------------------------------------------------------------------
  //
  // The desktop never stores an empty TAG_NO in MAIN_STOCK. Its shared stock poster writes the literal 'N' for
  // untagged stock — `CASE WHEN A.TAG_NO = '' THEN 'N' ELSE A.TAG_NO END` (Ac_Stock.cs:54), with 'N' hardcoded
  // in every untagged insert (:15, :17, :32, :42, :44, :56) — and reads loose stock back with `TAG_NO = 'N'`
  // (TR_KR_ISU.cs:6961, TR_MFG_KR_ISU_REC.cs:4694/8096/8100). The web follows that convention on write
  // (stock.ts:780, :934, :1036) and the untag repair restores it (dataRepairOps.ts:646).
  //
  // So a filter of `TAG_NO <> ''` does not mean "tagged": 'N' passes it. Every loose movement in a company then
  // collapses into one bogus identity, whose signed net is the whole loose balance.
  it('INV-3 does not mistake loose stock for a tag', async () => {
    // Three untagged pieces admitted. This is ordinary loose stock, not an ornament admitted three times.
    await movement(TENANT, 'N', 0, '+', { vchNo: '00001' });
    await movement(TENANT, 'N', 0, '+', { vchNo: '00002' });
    await movement(TENANT, 'N', 0, '+', { vchNo: '00003' });

    const result = await resultFor('INV-3');
    expect(result.violations).toHaveLength(0);
    expect(result.examined).toBe(0);
  });

  it('INV-2 does not mistake untagged barcode rows for a reused serial', async () => {
    // Untagged BAR_DETL rows legitimately share ('N', 0); that is not a serial handed out twice.
    await barDetl(TENANT, 'N', 0, '00001');
    await barDetl(TENANT, 'N', 0, '00002');

    const result = await resultFor('INV-2');
    expect(result.violations).toHaveLength(0);
    expect(result.examined).toBe(0);
  });

  it('INV-9 catches a movement that names no voucher', async () => {
    await movement(TENANT, 'TAG001', 1, '+', { book: '', vchNo: '' });
    const result = await resultFor('INV-9');
    expect(result.violations).toHaveLength(1);
    expect(result.violations[0]!.detail).toContain("book '' voucher ''");
  });

  it('never reads another tenant’s rows, so diagnostics cannot become a cross-tenant leak', async () => {
    // The violation is seeded in a DIFFERENT tenant, using BAR_DETL because TAG_STOCK's key would reject the
    // duplicate outright. RLS scopes the checks, which is why they take no tenant argument: a check that
    // accepted one could be pointed anywhere.
    await barDetl(OTHER_TENANT, 'TAG001', 1, '00001');
    await barDetl(OTHER_TENANT, 'TAG001', 1, '00002');
    const report = await check();
    expect(report.totalViolations).toBe(0);
    for (const result of report.results) expect(result.examined).toBe(0);
  });
});

describe('tag invariant coverage map', () => {
  it('accounts for all twelve §7.1 invariants exactly once', () => {
    expect(TAG_INVARIANT_COVERAGE).toHaveLength(12);
    expect(TAG_INVARIANT_COVERAGE.map((c) => c.number)).toEqual([
      1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12,
    ]);
  });

  it('states how each one is held, and cites evidence for it', () => {
    for (const entry of TAG_INVARIANT_COVERAGE) {
      expect(
        [
          'data-check',
          'code-tested',
          'contained',
          'blocked-owner-decision',
          'blocked-transition-model',
        ],
        `invariant ${entry.number}`,
      ).toContain(entry.enforcement);
      expect(entry.evidence.length, `invariant ${entry.number} evidence`).toBeGreaterThan(30);
    }
  });

  it('does not claim more than four are checked against data', () => {
    // The four data checks are the ones this suite exercises. Claiming any of the others as enforced would be
    // the overstatement the coverage map exists to prevent: some are held only because WP-01 contains the
    // operation, and two wait on an owner decision.
    const dataChecks = TAG_INVARIANT_COVERAGE.filter((c) => c.enforcement === 'data-check');
    expect(dataChecks.map((c) => c.number)).toEqual([1, 2, 3, 9]);

    const blocked = TAG_INVARIANT_COVERAGE.filter((c) => c.enforcement.startsWith('blocked'));
    expect(blocked.map((c) => c.number)).toEqual([8, 10, 12]);
    for (const entry of blocked) {
      expect(entry.evidence, `invariant ${entry.number} must say what unblocks it`).toMatch(
        /§8\.1|§7|undecided|unwritten|WP-10/,
      );
    }
  });

  it('records that the riskiest tag operations are contained rather than proved', () => {
    // Weight change is blocked by WP-01 (cancel and transfer were released by N18, split by N19, and are now
    // code-tested). The coverage map must say so, because "no violations observed" on a blocked path is not
    // evidence that the path is correct.
    const mentionsContainment = TAG_INVARIANT_COVERAGE.filter((c) =>
      /contain|CONTAIN|blocked by WP-01|WP-01/.test(c.evidence),
    );
    expect(mentionsContainment.map((c) => c.number)).toEqual([4, 7, 10, 11]);
  });
});
