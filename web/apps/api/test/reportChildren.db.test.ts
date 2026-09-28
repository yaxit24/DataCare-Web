import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { bindReport } from '../src/modules/reports/reportBind.js';
import { loadReportSpec, renderReportLayout } from '../src/modules/reports/reportEngine.js';

const databaseDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const TENANTS = ['rpt-child-contract-a', 'rpt-child-contract-b'];
const FAMILIES = [
  { prefix: 'SL', name: 'SalesBillHz', book: 'S91' },
  { prefix: 'PR', name: 'PurcBillA4Gst', book: 'P91' },
  { prefix: 'KR', name: 'KrRecVchGst', book: 'K91' },
];
const SCOPES = [
  { tenantId: TENANTS[0]!, coCode: '91', lcCode: '01', coYear: '2026-2027', label: 'BASE' },
  { tenantId: TENANTS[0]!, coCode: '91', lcCode: '02', coYear: '2026-2027', label: 'BRANCH' },
  { tenantId: TENANTS[0]!, coCode: '91', lcCode: '01', coYear: '2027-2028', label: 'YEAR' },
  { tenantId: TENANTS[0]!, coCode: '92', lcCode: '01', coYear: '2026-2027', label: 'COMPANY' },
  { tenantId: TENANTS[1]!, coCode: '91', lcCode: '01', coYear: '2026-2027', label: 'TENANT' },
];

databaseDescribe('actual report children and parent band cardinality', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const cleanup = async () => {
    for (const table of [
      ...FAMILIES.flatMap(({ prefix }) => [`${prefix}_IDTL`, `${prefix}_DETL`, `${prefix}_DATA`]),
      'ITEM_MAST',
      'AC_MAST',
      'CO_MAST',
      'BOOK_DATA',
      'LOCT_MAST',
    ])
      for (const tenant of TENANTS)
        await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, tenant);
  };
  beforeAll(async () => {
    const ownerUrl = process.env.MIGRATE_DATABASE_URL;
    const runtimeUrl = process.env.DATABASE_URL;
    if (!ownerUrl || !runtimeUrl)
      throw new Error('Report child fixtures require both database URLs');
    if ([ownerUrl, runtimeUrl].some((url) => new URL(url).port !== '55433'))
      throw new Error('Report child fixtures require the isolated test database on port 55433');
    owner = new PrismaClient({ datasources: { db: { url: ownerUrl } } });
    runtime = new PrismaClient({ datasources: { db: { url: runtimeUrl } } });
    await cleanup();
    const seenCompany = new Set<string>();
    const seenBranch = new Set<string>();
    for (const scope of SCOPES) {
      const { tenantId, coCode, lcCode, coYear, label } = scope;
      const companyKey = JSON.stringify([tenantId, coCode]);
      if (!seenCompany.has(companyKey)) {
        seenCompany.add(companyKey);
        await owner.$executeRawUnsafe(
          'INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,$3)',
          tenantId,
          coCode,
          `CO-${tenantId}-${coCode}`,
        );
        for (const [itCode, name] of [
          ['P0001', 'Parent One'],
          ['P0002', 'Parent Two'],
          ['C0001', 'Ruby component'],
          ['C0002', 'Diamond component'],
        ])
          await owner.$executeRawUnsafe(
            'INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES ($1,$2,$3,$4)',
            tenantId,
            coCode,
            itCode,
            `${name}-${coCode}-${tenantId.slice(-1)}`,
          );
      }
      const branchKey = JSON.stringify([tenantId, coCode, lcCode]);
      if (!seenBranch.has(branchKey)) {
        seenBranch.add(branchKey);
        await owner.$executeRawUnsafe(
          'INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,$3,$4,$5)',
          tenantId,
          coCode,
          lcCode,
          'PARTY91',
          `PARTY-${tenantId}-${coCode}-${lcCode}`,
        );
        await owner.$executeRawUnsafe(
          'INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,$4)',
          tenantId,
          coCode,
          lcCode,
          `LOCATION-${coCode}-${lcCode}`,
        );
        for (const { book } of FAMILIES)
          await owner.$executeRawUnsafe(
            'INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME") VALUES ($1,$2,$3,$4,$5)',
            tenantId,
            coCode,
            lcCode,
            book,
            `BOOK-${coCode}-${lcCode}-${book}`,
          );
      }
      for (const { prefix, book } of FAMILIES) {
        const key = [tenantId, coCode, lcCode, coYear, book, '00001'];
        await owner.$executeRawUnsafe(
          `INSERT INTO "${prefix}_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","NET_AMT","TOT_AMT") VALUES ($1,$2,$3,$4,$5,$6,'2026-04-03','PARTY91',$7,97531.45,97531.45)`,
          ...key,
          `${prefix}-${label}-CUSTOMER`,
        );
        for (const [srNo, item, parentAmount] of [
          [1, 'P0001', 43210.17],
          [2, 'P0002', 54321.28],
        ] as const) {
          await owner.$executeRawUnsafe(
            `INSERT INTO "${prefix}_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","IT_CODE","ITM_SIZE","ITM_PCS","ITM_GWT","NET_AMT") VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,17,25.75,$10)`,
            ...key,
            srNo,
            item,
            `PARENT-${srNo}-${label}`,
            parentAmount,
          );
          // Deliberately insert ISR_NO=2 first, and reuse both child serials under the next parent.
          for (const [isrNo, childItem, pcs, gwt, amount] of [
            [2, 'C0002', 5, 1.875, srNo === 1 ? 207.22 : 407.44],
            [1, 'C0001', 3, 0.125, srNo === 1 ? 103.11 : 303.33],
          ] as const)
            await owner.$executeRawUnsafe(
              `INSERT INTO "${prefix}_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","IT_CODE","DM_NAME","IT_PCS","IT_GWT","IT_RATE","IT_AMT","IT_NET_AMT") VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$10,$11,$12,123.45,$13,$13)`,
              ...key,
              srNo,
              isrNo,
              childItem,
              `CHILD-${srNo}-${isrNo}-${label}`,
              pcs,
              gwt,
              amount,
            );
        }
      }
    }
  }, 30_000);
  afterAll(async () => {
    if (owner) await cleanup();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it.each(FAMILIES)(
    'binds and renders distinct $prefix children with one occurrence of each parent total',
    async ({ prefix, name, book }) => {
      const spec = loadReportSpec(name)!;
      const bound = await bindReport(runtime, spec, { ...SCOPES[0]!, coBook: book, vchNo: 1 });
      expect(bound).not.toBeNull();
      expect(bound!.detailRows).toHaveLength(2);
      expect(bound!.datasets[`${prefix}_IDTL`]).toHaveLength(4);
      expect(bound!.detailRows.map((row) => row[`${prefix}_DETL.NET_AMT`])).toEqual([
        '43210.17',
        '54321.28',
      ]);
      expect(bound!.detailRows.some((row) => `${prefix}_IDTL.IT_AMT` in row)).toBe(false);
      const groups = bound!.parentChild!.groups;
      expect(
        groups.map((group) => group.children.map((row) => row[`${prefix}_IDTL.IT_NET_AMT`])),
      ).toEqual([
        ['103.11', '207.22'],
        ['303.33', '407.44'],
      ]);
      expect(groups[0]!.children.map((row) => row['ITEM_MAST_IDTL.IT_NAME'])).toEqual([
        'Ruby component-91-a',
        'Diamond component-91-a',
      ]);
      expect(bound!.header[`${prefix}_DATA.VCH_DATE`]).toBe('2026-04-03');
      const html = renderReportLayout(spec, bound!);
      expect((html.match(/data-kind="Detail"/g) ?? []).length).toBe(4);
      for (const amount of ['43210.17', '54321.28', '103.11', '207.22', '303.33', '407.44'])
        expect(
          (html.match(new RegExp(`>${amount.replace('.', '\\.')}<`, 'g')) ?? []).length,
          amount,
        ).toBe(1);
      expect(html.indexOf('>103.11<')).toBeLessThan(html.indexOf('>207.22<'));
      expect(html.indexOf('>207.22<')).toBeLessThan(html.indexOf('>54321.28<'));
      expect(html.indexOf('>54321.28<')).toBeLessThan(html.indexOf('>303.33<'));
      expect(html).not.toContain('[IT_NET_AMT]');
    },
  );

  it.each(SCOPES)(
    'selects matching header, parent, children, party and book for $label scope',
    async (scope) => {
      for (const { prefix, name, book } of FAMILIES) {
        const bound = (await bindReport(runtime, loadReportSpec(name)!, {
          ...scope,
          coBook: book,
          vchNo: 1,
        }))!;
        expect(bound.header[`${prefix}_DATA.AC_NAME`]).toBe(`${prefix}-${scope.label}-CUSTOMER`);
        expect(bound.header['AC_MAST.AC_NAME']).toBe(
          `PARTY-${scope.tenantId}-${scope.coCode}-${scope.lcCode}`,
        );
        expect(bound.header['BOOK_DATA.BOOK_NAME']).toBe(
          `BOOK-${scope.coCode}-${scope.lcCode}-${book}`,
        );
        expect(bound.header['LOCT_MAST.LC_NAME']).toBe(`LOCATION-${scope.coCode}-${scope.lcCode}`);
        expect(
          bound.datasets[`${prefix}_IDTL`]!.map((row) => row[`${prefix}_IDTL.DM_NAME`]),
        ).toEqual([
          `CHILD-1-1-${scope.label}`,
          `CHILD-1-2-${scope.label}`,
          `CHILD-2-1-${scope.label}`,
          `CHILD-2-2-${scope.label}`,
        ]);
        expect(
          bound.datasets[`${prefix}_IDTL`]!.every((row) =>
            row['ITEM_MAST_IDTL.IT_NAME']!.endsWith(`-${scope.coCode}-${scope.tenantId.slice(-1)}`),
          ),
        ).toBe(true);
      }
    },
  );

  it('reads one committed document version when a concurrent edit commits between dataset queries', async () => {
    const s = SCOPES[0]!;
    const keys = [s.tenantId, s.coCode, s.lcCode, s.coYear, 'S91', '00001'];
    const where =
      'tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6';
    const change = (total: string, childAmount: string) =>
      owner.$transaction(async (tx) => {
        await tx.$executeRawUnsafe(
          `UPDATE "SL_DATA" SET "TOT_AMT"=$7::numeric WHERE ${where}`,
          ...keys,
          total,
        );
        await tx.$executeRawUnsafe(
          `UPDATE "SL_IDTL" SET "IT_NET_AMT"=$7::numeric WHERE ${where} AND "SR_NO"=1 AND "ISR_NO"=1`,
          ...keys,
          childAmount,
        );
      });
    let editCommitted = false;
    // Only the scheduling boundary is instrumented; both reader and competing writer are real
    // PostgreSQL transactions using the same persisted document and different connections.
    const concurrentRuntime = {
      $transaction: (fn: (tx: any) => Promise<unknown>, options: any) =>
        runtime.$transaction(
          (tx) =>
            fn(
              new Proxy(tx, {
                get(target, property) {
                  if (property !== '$queryRawUnsafe') return Reflect.get(target, property);
                  return async (sql: string, ...params: unknown[]) => {
                    const rows = await target.$queryRawUnsafe(sql, ...params);
                    if (!editCommitted && sql.startsWith('SELECT * FROM "SL_DATA"')) {
                      editCommitted = true;
                      await change('99999.99', '999.99');
                    }
                    return rows;
                  };
                },
              }),
            ),
          options,
        ),
    };
    try {
      const spec = loadReportSpec('SalesBillHz')!;
      const bound = (await bindReport(concurrentRuntime, spec, { ...s, coBook: 'S91', vchNo: 1 }))!;
      expect(editCommitted).toBe(true);
      expect(bound.header['SL_DATA.TOT_AMT']).toBe('97531.45');
      expect(bound.datasets.SL_IDTL![0]!['SL_IDTL.IT_NET_AMT']).toBe('103.11');
      const after = (await bindReport(runtime, spec, { ...s, coBook: 'S91', vchNo: 1 }))!;
      expect(after.header['SL_DATA.TOT_AMT']).toBe('99999.99');
      expect(after.datasets.SL_IDTL![0]!['SL_IDTL.IT_NET_AMT']).toBe('999.99');
    } finally {
      await change('97531.45', '103.11');
    }
  });

  it('keeps a parent with no children, renders no fabricated child, and leaves other scopes intact', async () => {
    const s = SCOPES[0]!;
    await owner.$executeRawUnsafe(
      'DELETE FROM "SL_IDTL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 AND "SR_NO"=2',
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      'S91',
      '00001',
    );
    const spec = loadReportSpec('SalesBillHz')!;
    const bound = (await bindReport(runtime, spec, { ...s, coBook: 'S91', vchNo: 1 }))!;
    expect(bound.parentChild!.groups.map((group) => group.children.length)).toEqual([2, 0]);
    expect(bound.detailRows).toHaveLength(2);
    const html = renderReportLayout(spec, bound);
    expect((html.match(/data-kind="Detail"/g) ?? []).length).toBe(2);
    expect(html).toContain('>54321.28<');
    const untouched = (await bindReport(runtime, spec, {
      ...SCOPES[1]!,
      coBook: 'S91',
      vchNo: 1,
    }))!;
    expect(untouched.datasets.SL_IDTL).toHaveLength(4);
  });

  it('refuses an orphan component instead of dropping it from the printed document', async () => {
    const s = SCOPES[0]!;
    await owner.$executeRawUnsafe(
      'INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO") VALUES ($1,$2,$3,$4,$5,$6,99,1)',
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      'S91',
      '00001',
    );
    try {
      await expect(
        bindReport(runtime, loadReportSpec('SalesBillHz')!, { ...s, coBook: 'S91', vchNo: 1 }),
      ).rejects.toMatchObject({ code: 'unsupported-report-binding', reason: 'orphan-child' });
    } finally {
      await owner.$executeRawUnsafe(
        'DELETE FROM "SL_IDTL" WHERE tenant_id=$1 AND "SR_NO"=99',
        s.tenantId,
      );
    }
  });

  it('refuses duplicate component identity instead of repeating its amounts', async () => {
    const s = SCOPES[0]!;
    const inserted = await owner.$queryRawUnsafe<{ row_id: bigint }[]>(
      'INSERT INTO "SL_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO") VALUES ($1,$2,$3,$4,$5,$6,1,1) RETURNING row_id',
      s.tenantId,
      s.coCode,
      s.lcCode,
      s.coYear,
      'S91',
      '00001',
    );
    try {
      await expect(
        bindReport(runtime, loadReportSpec('SalesBillHz')!, { ...s, coBook: 'S91', vchNo: 1 }),
      ).rejects.toMatchObject({
        code: 'unsupported-report-binding',
        reason: 'ambiguous-child-serial',
      });
    } finally {
      await owner.$executeRawUnsafe(
        'DELETE FROM "SL_IDTL" WHERE tenant_id=$1 AND row_id=$2',
        s.tenantId,
        inserted[0]!.row_id,
      );
    }
  });
});
