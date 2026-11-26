import { readFileSync } from 'node:fs';
import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * Migration 20261126100000 (PR #292 review round 4): an existing OP_DETL / DM_DATA row takes its parent's data type
 * (OP_DATA / ITM_OPBL) when the parent has exactly one distinct type; no parent or mixed parents stay 'A'. The file's
 * own UPDATE statements are replayed on fixture rows (the ALTERs already ran with the schema).
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const tenant = 'opening-detail-type-mig';
const sql = readFileSync(
  new URL(
    '../../../packages/db/prisma/migrations/20261126100000_opening_detail_data_type/migration.sql',
    import.meta.url,
  ),
  'utf8',
);
const updates = [...sql.matchAll(/^UPDATE "(?:OP_DETL|DM_DATA)"[\s\S]*?;$/gm)].map((m) =>
  m[0].replace(/;$/, ''),
);

(enabled ? describe : describe.skip)('opening detail data type migration', () => {
  let owner: PrismaClient;
  const q = (s: string, ...p: unknown[]) => owner.$queryRawUnsafe<any[]>(s, ...p);
  const x = (s: string, ...p: unknown[]) => owner.$executeRawUnsafe(s, ...p);
  const wipe = async () => {
    for (const t of ['OP_DETL', 'OP_DATA', 'DM_DATA', 'ITM_OPBL'])
      await x(`DELETE FROM "${t}" WHERE tenant_id=$1`, tenant);
  };
  beforeAll(() => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
  });
  afterAll(async () => {
    await wipe();
    await owner?.$disconnect();
  });

  it('gives detail rows their single-type parent type; orphan and mixed-parent rows stay A', async () => {
    expect(updates).toHaveLength(2);
    await wipe();
    const op = (ac: string, type: string, vch: string) =>
      x(
        `INSERT INTO "OP_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","AC_CODE","OP_AMT","DATA_TYPE")
         VALUES ($1,'01','01','2026','OPB',$2,$3,1,$4)`,
        tenant,
        vch,
        ac,
        type,
      );
    await op('PB', 'B', '1');
    await op('PBLANK', ' ', '2');
    await op('PMIX', 'A', '3');
    await op('PMIX', 'B', '4');
    for (const ac of ['PB', 'PBLANK', 'PMIX', 'ORPHAN'])
      await x(
        `INSERT INTO "OP_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","AC_CODE","VCH_NO","SR_NO","DATA_TYPE")
         VALUES ($1,'01','01','2026','OPB',$2,'1','1','A')`,
        tenant,
        ac,
      );
    const itm = (item: string, type: string, sr: string) =>
      x(
        `INSERT INTO "ITM_OPBL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","IT_CODE","VCH_NO","SR_NO","DATA_TYPE")
         VALUES ($1,'01','01','2026','IOP',$2,'1',$3,$4)`,
        tenant,
        item,
        sr,
        type,
      );
    await itm('IB', 'B', '1');
    await itm('IMIX', 'A', '1');
    await itm('IMIX', 'B', '2');
    for (const [n, it] of ['IB', 'IMIX', 'IORPH'].entries())
      await x(
        `INSERT INTO "DM_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","IT_CODE","MAIN_SRNO","SR_NO","ISR_NO","DATA_TYPE")
         VALUES ($1,'01','01','2026','IOP','1',$2,1,$3,1,'A')`,
        tenant,
        it,
        n + 1,
      );
    await owner.$transaction(async (tx) => {
      await tx.$executeRawUnsafe('SET LOCAL row_security=off');
      for (const u of updates) await tx.$executeRawUnsafe(u);
    });
    const pick = (rows: any[]) => Object.fromEntries(rows.map((r) => [r.k, r.t]));
    expect(
      pick(await q(`SELECT "AC_CODE" k, "DATA_TYPE" t FROM "OP_DETL" WHERE tenant_id=$1`, tenant)),
    ).toEqual({ PB: 'B', PBLANK: 'A', PMIX: 'A', ORPHAN: 'A' });
    expect(
      pick(await q(`SELECT "IT_CODE" k, "DATA_TYPE" t FROM "DM_DATA" WHERE tenant_id=$1`, tenant)),
    ).toEqual({ IB: 'B', IMIX: 'A', IORPH: 'A' });
  });
});
