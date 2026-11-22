import { existsSync, readFileSync } from 'node:fs';
import { PrismaClient } from '@datacare/db';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

/**
 * WP-19 migration contract: 20261122090000 back-fills the LBR_ISU_DETL GST shares (TR_SALE_LBR.cs:9748-9830) for
 * labour rows written before the columns existed. LBR_ISU_DETL and LBR_DATA are forced-RLS, so under an RLS-bound
 * role the UPDATE would silently touch 0 rows. Like the other data migrations (20261109090000, 20261101090000) it
 * runs in one transaction behind a preflight that raises unless the role is superuser or BYPASSRLS. The back-fill
 * arithmetic itself is covered in gstReport.db.test.ts.
 */
const enabled = process.env.RUN_DB_INTEGRITY_TESTS === '1';
const migrationUrl = new URL(
  '../../../packages/db/prisma/migrations/20261122090000_labour_detail_gst_shares/migration.sql',
  import.meta.url,
);
const sql = existsSync(migrationUrl) ? readFileSync(migrationUrl, 'utf8') : '';
const statements: string[] = [];
if (sql) {
  let current: string[] = [];
  let quoted = false;
  for (const line of sql.split('\n')) {
    if (/^\s*--/.test(line)) continue;
    current.push(line);
    if ((line.match(/\$preflight\$/g) ?? []).length % 2 === 1) quoted = !quoted;
    if (!quoted && /;\s*$/.test(line)) {
      statements.push(current.join('\n').trim().replace(/;\s*$/, ''));
      current = [];
    }
  }
}

(enabled ? describe : describe.skip)('WP-19 labour GST share migration', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;

  beforeAll(() => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  afterAll(async () => {
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it('wraps the back-fill in one guarded transaction and refuses an RLS-bound migration role', async () => {
    expect(sql, 'the WP-19 migration file is missing').not.toBe('');
    expect(statements[0]).toMatch(/^ALTER TABLE "LBR_ISU_DETL"/);
    const begin = statements.indexOf('BEGIN');
    expect(begin).toBe(1);
    expect(statements[begin + 1]).toMatch(/^DO \$preflight\$/);
    expect(statements[begin + 2]).toBe('SET LOCAL row_security=off');
    expect(statements[begin + 3]).toMatch(/^WITH voucher AS/);
    expect(statements.at(-1)).toBe('COMMIT');
    expect(statements).toHaveLength(begin + 5);
    const preflight = statements[begin + 1]!;
    await expect(runtime.$executeRawUnsafe(preflight)).rejects.toThrow(
      'labour GST share backfill requires a migration role with complete tenant visibility',
    );
    await expect(owner.$executeRawUnsafe(preflight)).resolves.toBeDefined();
  });
});
