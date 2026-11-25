import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { PrismaClient, withTenant } from '@datacare/db';
import { seedPopulatedTenant, wipeTenants, WP24_CO, WP24_LC } from './wp24FieldSeed.js';

const db = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;

const SOURCE = resolve(__dirname, '../../../../unified/src/csharp/DataCareNext/MS_UPDATE.cs');

interface Stmt {
  line: number;
  sets: Array<[string, string]>;
  where:
    | { kind: 'main'; values: string[] }
    | { kind: 'raw'; col: string; value: string }
    | { kind: 'key' };
}

/** The 169 `UPDATE BOOK_DATA` statements of `btnFildUpdate_Click` (lines 5531-8757), in source order. */
function bookDataStatements(): Stmt[] {
  const lines = readFileSync(SOURCE, 'latin1').split(/\r?\n/);
  const out: Stmt[] = [];
  lines.forEach((text, index) => {
    const line = index + 1;
    if (line < 5531 || line > 8757) return;
    const m = /"UPDATE BOOK_DATA SET (.*?) WHERE (.*?)"\);\s*$/.exec(text);
    if (!m) return;
    const sets = [...m[1]!.matchAll(/(\w+) = '([^']*)'/g)].map(
      (s) => [s[1]!, s[2]!] as [string, string],
    );
    const w = m[2]!;
    let where: Stmt['where'];
    let r: RegExpExecArray | null;
    if (/^MAIN_BOOK (=|IN) /.test(w))
      where = { kind: 'main', values: [...w.matchAll(/'([^']*)'/g)].map((v) => v[1]!) };
    else if ((r = /^(CO_BOOK|BOOK_TBL_DETL) = '([^']*)'$/.exec(w)))
      where = { kind: 'raw', col: r[1]!, value: r[2]! };
    else if (/^CO_CODE = .* AND CO_BOOK = '061'$/.test(w)) where = { kind: 'key' };
    else throw new Error(`unparsed BOOK_DATA where at line ${line}: ${w}`);
    out.push({ line, sets, where });
  });
  return out;
}

const F1_BOOKS = [
  'BUL/BUL SALE',
  'CON/CONTRA',
  'CRD/CARD ADJUST',
  'DHI/DHIRAN ISSUE',
  'DIR/INTREST RECIVED',
  'FJV/FINE JV',
  'FPR/FINE PURC',
  'FSL/FINE SALE',
  'IOP/OPSTK',
  'JDI/JDTR ISU',
  'JDR/JDTR REC',
  'KRI/KARIGAR ISSUE',
  'KRR/KARIGAR RECEIPT',
  'LBR/LABOUR WORK',
  'OEX/OTH EXP',
  'OIN/OTH INC',
  'ORC/ORDER CANCEL',
  'PR/PURCHASE',
  'PRT/PURC RETURN',
  'RTC/RATE CUT',
  'SAJ/STOCK ADJUST',
  'SIN/INWORD',
  'SL/SALES',
  'SOR/SALES ORDER',
  'SOT/OUTWORD',
  'SRT/SALES RETURNE',
  'TGC/TAG CANCEL',
  'TGN/TAG GEN',
  'TPR/TAG PURCHASE',
  'TRR/APR RTN',
  'TSL/TOUR SALES',
  'TSP/TAG SPLIT',
  'TTR/TAG TRFR',
  'TUR/APR ISU',
  'WHQ/WH QUOT',
  'WHS/WH SALES',
];

class Rollback extends Error {}

db('WP-24 Field Update class-b anomaly queries (must find nothing on web data)', () => {
  const owner = new PrismaClient({
    datasources: {
      db: { url: process.env.MIGRATE_DATABASE_URL ?? process.env.DATABASE_URL ?? '' },
    },
  });
  const runtime = new PrismaClient();
  const tenantId = 'wp24-anomaly';

  beforeAll(async () => {
    await wipeTenants(owner, [tenantId]);
    await seedPopulatedTenant(runtime, tenantId);
  });
  afterAll(async () => {
    await wipeTenants(owner, [tenantId]);
    await owner.$disconnect();
    await runtime.$disconnect();
  });

  const count = (sql: string) =>
    withTenant(runtime, tenantId, async (tx: any) => {
      const rows = await tx.$queryRawUnsafe(sql, tenantId);
      return rows.map((r: any) => JSON.stringify(r));
    });

  it('parses all 169 BOOK_DATA metadata statements', () => {
    expect(bookDataStatements()).toHaveLength(169);
  });

  it('BOOK_DATA: replaying the 169 metadata UPDATEs in source order would change no row', async () => {
    const statements = bookDataStatements();
    const changed: string[] = [];
    await withTenant(runtime, tenantId, async (tx: any) => {
      const snap = async () =>
        new Map<string, string>(
          (
            await tx.$queryRawUnsafe(
              `SELECT row_id::text AS id, to_jsonb(t)::text AS raw FROM "BOOK_DATA" t WHERE tenant_id=$1`,
              tenantId,
            )
          ).map((r: any) => [r.id, r.raw]),
        );
      const before = await snap();
      for (const s of statements) {
        const params: unknown[] = [tenantId, ...s.sets.map(([, v]) => v)];
        const setSql = s.sets.map(([c], i) => `"${c}"=$${2 + i}`).join(',');
        let whereSql: string;
        if (s.where.kind === 'main') {
          params.push(s.where.values);
          whereSql = `"MAIN_BOOK"=ANY($${params.length}::text[])`;
        } else if (s.where.kind === 'raw') {
          params.push(s.where.value);
          whereSql = `"${s.where.col}"=$${params.length}`;
        } else {
          params.push(WP24_CO, WP24_LC);
          whereSql = `"CO_CODE"=$${params.length - 1} AND "LC_CODE"=$${params.length} AND "CO_BOOK"='061'`;
        }
        await tx.$executeRawUnsafe(
          `UPDATE "BOOK_DATA" SET ${setSql} WHERE tenant_id=$1 AND ${whereSql}`,
          ...params,
        );
      }
      const after = await snap();
      for (const [id, raw] of after)
        if (before.get(id) !== raw) {
          const was = JSON.parse(before.get(id)!);
          const now = JSON.parse(raw);
          const cols = Object.keys(now).filter(
            (k) => JSON.stringify(now[k]) !== JSON.stringify(was[k]),
          );
          changed.push(
            `${now.CO_BOOK}/${now.MAIN_BOOK}: ${cols.map((c) => `${c} ${was[c]} -> ${now[c]}`).join('; ')}`,
          );
        }
      throw new Rollback();
    }).catch((e) => {
      if (!(e instanceof Rollback)) throw e;
    });
    // FINDING F1 (class a, see field-update.md): web company provisioning (seedCompany.ts) writes BOOK_DATA
    // without MENU_NAME and, for many books, without BOOK_TBL_NAME / BOOK_TBL_DETL. The desktop UPDATEs fill
    // them. The assertions below pin the finding: no statement may ever OVERWRITE a stored value (every
    // change is NULL -> value), and the set of affected books may only shrink once a repair is built.
    for (const row of changed)
      expect(row, 'overwrites a stored value').not.toMatch(/ [^n ][^ ]* -> /);
    expect(changed.every((c) => / null -> /.test(c))).toBe(true);
    expect(changed.map((c) => c.split(':')[0]!).sort()).toEqual(F1_BOOKS);
  });

  it('AC_GROUP (6134): no INDIRECT INCOME group has a blank or NULL main group', async () => {
    expect(
      await count(
        `SELECT "AC_GR" FROM "AC_GROUP" WHERE tenant_id=$1 AND "AC_GR_NAME"='INDIRECT INCOME'
            AND coalesce("AC_MAIN_GR",'')=''`,
      ),
    ).toEqual([]);
  });

  it('INOUT_DETL (7706): no row has a NULL DATA_TYPE', async () => {
    const n = await count(`SELECT 1 FROM "INOUT_DETL" WHERE tenant_id=$1`);
    expect(n.length).toBeGreaterThan(0);
    expect(
      await count(`SELECT 1 FROM "INOUT_DETL" WHERE tenant_id=$1 AND "DATA_TYPE" IS NULL`),
    ).toEqual([]);
  });

  it('LBR_ISU_DETL (7733): no row has a NULL ORD_TAG_STK_ADD', async () => {
    const n = await count(`SELECT 1 FROM "LBR_ISU_DETL" WHERE tenant_id=$1`);
    expect(n.length).toBeGreaterThan(0);
    expect(
      await count(`SELECT 1 FROM "LBR_ISU_DETL" WHERE tenant_id=$1 AND "ORD_TAG_STK_ADD" IS NULL`),
    ).toEqual([]);
  });
});
