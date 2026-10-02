import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, describe, expect, it } from 'vitest';
import { bindReport } from '../src/modules/reports/reportBind.js';
import { loadReportSpec, renderReportLayout } from '../src/modules/reports/reportEngine.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const databaseDescribe = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenants = ['order-rpt-contract-a', 'order-rpt-contract-b'];
const base = { tenantId: tenants[0]!, coCode: '91', lcCode: '01', coYear: '2026-2027' };
const scopes = [
  base,
  { ...base, tenantId: tenants[1]! },
  { ...base, coCode: '92' },
  { ...base, lcCode: '02' },
  { ...base, coYear: '2027-2028' },
];
const families = [
  { report: 'OrderBill', coBook: 'O91', orderFamily: 'SALES ORDER' as const, direction: 'O' },
  { report: 'TourOrdVch', coBook: 'T91', orderFamily: 'TOUR ORDER' as const, direction: 'I' },
];
const identity = (s: typeof base) => `${s.tenantId}/${s.coCode}/${s.lcCode}/${s.coYear}`;

databaseDescribe('full order document datasets, subreport and ledger cutoff', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const cleanup = async () => {
    for (const table of [
      'SL_PR_DETL',
      'SL_ORD_IDTL',
      'SL_ORD_DETL',
      'SL_ORD_DATA',
      'AC_DATA',
      'ITEM_MAST',
      'AC_MAST',
      'BOOK_DATA',
      'LOCT_MAST',
      'CO_SET_NEW',
      'CO_MAST',
    ])
      await owner.$executeRawUnsafe(
        `DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`,
        ...tenants,
      );
  };
  beforeAll(async () => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
    await cleanup();
    const seenCompany = new Set<string>(),
      seenBranch = new Set<string>();
    for (const s of scopes) {
      const companyKey = JSON.stringify([s.tenantId, s.coCode]);
      if (!seenCompany.has(companyKey)) {
        seenCompany.add(companyKey);
        await owner.$executeRawUnsafe(
          'INSERT INTO "CO_MAST"(tenant_id,"CO_CODE","CO_NAME") VALUES ($1,$2,$3)',
          s.tenantId,
          s.coCode,
          `Company ${companyKey}`,
        );
        for (const [code, name] of [
          ['P0001', 'Parent one'],
          ['P0002', 'Parent two'],
          ['C0001', 'Ruby'],
          ['C0002', 'Diamond'],
        ])
          await owner.$executeRawUnsafe(
            'INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME") VALUES ($1,$2,$3,$4)',
            s.tenantId,
            s.coCode,
            code,
            `${name} ${companyKey}`,
          );
      }
      const branchKey = JSON.stringify([s.tenantId, s.coCode, s.lcCode]);
      if (!seenBranch.has(branchKey)) {
        seenBranch.add(branchKey);
        await owner.$executeRawUnsafe(
          'INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME") VALUES ($1,$2,$3,\'PARTY\',$4)',
          s.tenantId,
          s.coCode,
          s.lcCode,
          `Party ${branchKey}`,
        );
        await owner.$executeRawUnsafe(
          'INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME") VALUES ($1,$2,$3,$4)',
          s.tenantId,
          s.coCode,
          s.lcCode,
          `Branch ${branchKey}`,
        );
        for (const family of families)
          await owner.$executeRawUnsafe(
            `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","MAIN_BOOK","BOOK_INOUT","BOOK_TBL_NAME","CUR_USE")
            VALUES ($1,$2,$3,$4,$5,$5,$6,'SL_ORD_DATA','Y')`,
            s.tenantId,
            s.coCode,
            s.lcCode,
            family.coBook,
            family.orderFamily,
            family.direction,
          );
      }
      for (const family of families) {
        const key = [s.tenantId, s.coCode, s.lcCode, s.coYear, family.coBook];
        for (const voucher of ['00001', '00002'])
          await owner.$executeRawUnsafe(
            `INSERT INTO "SL_ORD_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
            "VCH_DATE","VCH_TIME","AC_CODE","AC_NAME","NET_AMT","TAX_PRC","TAX_AMT","TOT_AMT","ADV_AMT","CASH_AMT","CARD_AMT","CHQ_AMT","DEL_DATE")
            VALUES($1,$2,$3,$4,$5,$6,'2026-04-03','2026-04-03 12:34:56','PARTY',$7,975.31,3,29.26,1004.57,105,105,0,0,'2026-04-09')`,
            ...key,
            voucher,
            `${family.report} ${identity(s)}`,
          );
        for (const [sr, item, amount, weight] of [
          [2, 'P0002', '975.31', '2.2'],
          [1, 'P0001', '0', '1.1'],
        ] as const)
          await owner.$executeRawUnsafe(
            `INSERT INTO "SL_ORD_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
            "SR_NO","IT_CODE","DESIGN_NO","ITM_PCS","ITM_GWT","ITM_NWT","NET_AMT","ITM_REMARK","TAG_NO")
            VALUES($1,$2,$3,$4,$5,'00001',$6,$7,$8,1,$9::numeric,$9::numeric,$10::numeric,$11,$12)`,
            ...key,
            sr,
            item,
            `DESIGN-${sr}`,
            weight,
            amount,
            sr === 2 ? `Remark ${identity(s)}` : null,
            sr === 1 ? 'TAG-001' : '',
          );
        for (const [sr, isr, item, weight] of [
          [1, 2, 'C0002', '0'],
          [2, 1, 'C0001', '0.303'],
          [1, 1, 'C0001', '0.101'],
        ] as const)
          await owner.$executeRawUnsafe(
            `INSERT INTO "SL_ORD_IDTL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
            "SR_NO","ISR_NO","IT_CODE","IT_PCS","IT_GWT") VALUES($1,$2,$3,$4,$5,'00001',$6,$7,$8,1,$9::numeric)`,
            ...key,
            sr,
            isr,
            item,
            weight,
          );
        for (const voucher of ['00001', '00002'])
          for (const [sr, weight] of [
            [2, '2.2'],
            [1, '1.1'],
          ] as const)
            await owner.$executeRawUnsafe(
              `INSERT INTO "SL_PR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO",
              "SR_NO","IT_CODE","IT_DESC","ITM_PCS","ITM_NWT","NET_AMT") VALUES($1,$2,$3,$4,$5,$6,$7,'C0001',$8,$7,$9::numeric,0)`,
              ...key,
              voucher,
              sr,
              `Received ${sr} ${identity(s)}`,
              weight,
            );
      }
      for (const [time, amount, type] of [
        ['11:00:00', '12.34', 'A'],
        ['11:30:00', '1.11', 'B'],
        ['12:34:56', '10.25', 'A'],
        ['13:00:00', '1000', 'A'],
      ])
        await owner.$executeRawUnsafe(
          `INSERT INTO "AC_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","AC_CODE","CR_AMT","DR_AMT","ENTRY_TIME","DATA_TYPE")
          VALUES($1,$2,$3,$4,'PARTY',$5::numeric,0,$6::timestamp,$7)`,
          s.tenantId,
          s.coCode,
          s.lcCode,
          s.coYear,
          amount,
          `2026-04-03 ${time}`,
          type,
        );
    }
  });
  afterAll(async () => {
    if (owner) await cleanup();
    await runtime?.$disconnect();
    await owner?.$disconnect();
  });

  it.each(families)(
    'binds $report scoped parents, components and received-metal without fanout',
    async (family) => {
      const spec = loadReportSpec(family.report)!;
      for (const s of scopes) {
        const result = await bindReport(runtime, spec, { ...s, ...family, vchNo: 1, copy: 'D' });
        expect(result).not.toBeNull();
        expect(result!.header['SL_ORD_DATA.AC_NAME']).toBe(`${family.report} ${identity(s)}`);
        expect(result!.detailRows.map((row) => row['SL_ORD_DETL.SR_NO'])).toEqual(['1', '2']);
        expect(result!.parentChild!.groups.map((group) => group.children.length)).toEqual([2, 1]);
        expect(result!.datasets.SL_ORD_IDTL!.map((row) => row['SL_ORD_IDTL.IT_GWT'])).toEqual([
          '0.101',
          '0',
          '0.303',
        ]);
        expect(
          result!.subreports!.OrdRec!.detailRows.map((row) => row['SL_PR_DETL.IT_DESC']),
        ).toEqual([`Received 1 ${identity(s)}`, `Received 2 ${identity(s)}`]);
        expect(result!.header['#RTotal0']).toBe('3.3');
        expect(result!.header['@OpAmt']).toBe('13.45');
        expect(result!.header['@ClAmt']).toBe('23.7');
        const html = renderReportLayout(spec, result!);
        const savedParentName = result!.detailRows[0]!['ITEM_MAST.IT_NAME'];
        const printedParentName =
          family.report === 'TourOrdVch'
            ? `TAG-001 - ${savedParentName}`
            : `${savedParentName} Dsgn : DESIGN-1`;
        expect(result!.detailRows[0]!['SL_ORD_DETL.TAG_NO']).toBe('TAG-001');
        expect(result!.detailRows[0]!['@ItemName']).toBe(printedParentName);
        // The master name includes JSON quotes; HTML escapes them while keeping the source label.
        expect(html).toContain(`>${printedParentName.replaceAll('"', '&quot;')}</div>`);
        expect(html).toContain('DUPLICATE FOR SUPPLIER');
        expect(html.match(/>975\.31</g)).toHaveLength(2); // one parent and one saved header net amount.
        expect(html.match(new RegExp(`>Received 1 ${identity(s)}<`, 'g'))).toHaveLength(1);
        expect(html).not.toContain('[IT_');
      }
    },
  );

  it('prints advance-only OrderVch with its received-metal subreport and refuses mismatched template shapes/families', async () => {
    const advance = loadReportSpec('OrderVch')!;
    const scope = { ...base, ...families[0]!, vchNo: 2 };
    const result = await bindReport(runtime, advance, scope);
    expect(result?.subreports?.OrdRec?.detailRows).toHaveLength(2);
    expect(renderReportLayout(advance, result!)).toContain('Order Advance');
    await expect(bindReport(runtime, advance, { ...scope, vchNo: 1 })).rejects.toThrow(
      'wrong-order-document-shape',
    );
    await expect(bindReport(runtime, loadReportSpec('OrderBill')!, scope)).rejects.toThrow(
      'wrong-order-document-shape',
    );
    await expect(bindReport(runtime, loadReportSpec('TourOrdVch')!, scope)).rejects.toThrow(
      'wrong-order-document-family',
    );
    await expect(
      bindReport(runtime, advance, { ...scope, orderFamily: undefined }),
    ).rejects.toThrow('wrong-order-document-family');
  });

  it('preserves same-day ledger time and honors the desktop data-type selector', async () => {
    const columns = await owner.$queryRawUnsafe<
      any[]
    >(`SELECT data_type FROM information_schema.columns
      WHERE table_name='AC_DATA' AND column_name='ENTRY_TIME'`);
    expect(columns[0]?.data_type).toBe('timestamp without time zone');
    const result = await bindReport(runtime, loadReportSpec('TourOrdVch')!, {
      ...base,
      ...families[1]!,
      vchNo: 1,
      orderDataType: 'A',
    });
    expect(result?.header['@OpAmt']).toBe('12.34');
    expect(result?.header['@ClAmt']).toBe('22.59');
  });

  it('preserves all six timestamp digits for previous, equal and later ledger entries in printed balances', async () => {
    const scope = { ...base, ...families[1]!, vchNo: 1 };
    const rows: bigint[] = [];
    await owner.$executeRawUnsafe(
      `UPDATE "SL_ORD_DATA" SET "VCH_TIME"='2026-04-03 12:34:56.123456'
      WHERE tenant_id=$1 AND "CO_CODE"='91' AND "LC_CODE"='01' AND "CO_YEAR"='2026-2027'
      AND "CO_BOOK"='T91' AND "VCH_NO"='00001'`,
      base.tenantId,
    );
    try {
      for (const [fraction, amount] of [
        ['123455', '2.11'],
        ['123456', '3.22'],
        ['123457', '4000'],
      ]) {
        const inserted = await owner.$queryRawUnsafe<{ row_id: bigint }[]>(
          `INSERT INTO "AC_DATA"
          (tenant_id,"CO_CODE","LC_CODE","CO_YEAR","AC_CODE","CR_AMT","DR_AMT","ENTRY_TIME","DATA_TYPE")
          VALUES($1,'91','01','2026-2027','PARTY',$2::numeric,0,$3::timestamp,'A') RETURNING row_id`,
          base.tenantId,
          amount,
          `2026-04-03 12:34:56.${fraction}`,
        );
        rows.push(inserted[0]!.row_id);
      }
      const spec = loadReportSpec('TourOrdVch')!;
      const bound = await bindReport(runtime, spec, scope);
      expect(bound?.header['@OpAmt']).toBe('25.81'); // 23.70 prior seconds + 2.11 one microsecond before.
      expect(bound?.header['@ClAmt']).toBe('29.03'); // Includes exactly 3.22 at the saved timestamp.
      expect(bound?.header).not.toHaveProperty('SL_ORD_DATA.__voucherTime');
      const html = renderReportLayout(spec, bound!);
      expect(html).toMatch(/data-field="\{@OpAmt\}"[^>]*>25\.81<\/div>/);
      expect(html).toMatch(/data-field="\{@ClAmt\}"[^>]*>29\.03<\/div>/);
    } finally {
      for (const id of rows)
        await owner.$executeRawUnsafe(
          'DELETE FROM "AC_DATA" WHERE tenant_id=$1 AND row_id=$2',
          base.tenantId,
          id,
        );
      await owner.$executeRawUnsafe(
        `UPDATE "SL_ORD_DATA" SET "VCH_TIME"='2026-04-03 12:34:56'
        WHERE tenant_id=$1 AND "CO_CODE"='91' AND "LC_CODE"='01' AND "CO_YEAR"='2026-2027'
        AND "CO_BOOK"='T91' AND "VCH_NO"='00001'`,
        base.tenantId,
      );
    }
  });

  it('does not manufacture a received row when none exists and refuses duplicate received serials', async () => {
    const s = { ...base, ...families[0]!, vchNo: 2 };
    const key = [s.tenantId, s.coCode, s.lcCode, s.coYear, s.coBook];
    const duplicate = await owner.$queryRawUnsafe<any[]>(
      `INSERT INTO "SL_PR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO")
      VALUES($1,$2,$3,$4,$5,'00002',1) RETURNING row_id`,
      ...key,
    );
    await expect(bindReport(runtime, loadReportSpec('OrderVch')!, s)).rejects.toThrow(
      'ambiguous-received-metal-serial',
    );
    await owner.$executeRawUnsafe(
      'DELETE FROM "SL_PR_DETL" WHERE tenant_id=$1 AND row_id=$2',
      s.tenantId,
      duplicate[0]!.row_id,
    );
    await owner.$executeRawUnsafe(
      `DELETE FROM "SL_PR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"='00002'`,
      ...key,
    );
    const result = await bindReport(runtime, loadReportSpec('OrderVch')!, s);
    expect(result?.header['@OldItem']).toBe('N');
    expect(result?.subreports?.OrdRec?.detailRows).toEqual([]);
    expect(renderReportLayout(loadReportSpec('OrderVch')!, result!)).not.toContain(
      'data-subreport="OrdRec"',
    );
  });

  it('refuses an absent timestamp instead of reporting false opening/closing balances', async () => {
    await owner.$executeRawUnsafe(
      `UPDATE "SL_ORD_DATA" SET "VCH_TIME"=NULL WHERE tenant_id=$1 AND "CO_CODE"='91' AND "LC_CODE"='01'
      AND "CO_YEAR"='2026-2027' AND "CO_BOOK"='T91' AND "VCH_NO"='00002'`,
      base.tenantId,
    );
    await expect(
      bindReport(runtime, loadReportSpec('OrderVch')!, { ...base, ...families[1]!, vchNo: 2 }),
    ).rejects.toThrow('missing-order-voucher-timestamp');
  });

  it('uses the company image setting only for orders containing parents, without ignoring the selected image variant', async () => {
    await owner.$executeRawUnsafe(
      'INSERT INTO "CO_SET_NEW"(tenant_id,"CO_CODE","ORD_IMG_PRINT") VALUES($1,\'91\',\'Y\')',
      base.tenantId,
    );
    try {
      for (const family of families)
        await expect(
          bindReport(runtime, loadReportSpec(family.report)!, { ...base, ...family, vchNo: 1 }),
        ).rejects.toMatchObject({
          report: family.report === 'OrderBill' ? 'OrdVchImg' : 'TourOrdImg',
          reason: 'order-image-template-mismatch',
        });
      expect(
        await bindReport(runtime, loadReportSpec('OrderVch')!, {
          ...base,
          ...families[0]!,
          vchNo: 2,
        }),
      ).not.toBeNull();
      expect(
        await bindReport(runtime, loadReportSpec('OrderBill')!, {
          ...base,
          coCode: '92',
          ...families[0]!,
          vchNo: 1,
        }),
      ).not.toBeNull();
    } finally {
      await owner.$executeRawUnsafe('DELETE FROM "CO_SET_NEW" WHERE tenant_id=$1', base.tenantId);
    }
  });

  it('reads received-metal and ledger values from the same snapshot when an edit commits after the header query', async () => {
    const s = { ...base, ...families[0]!, vchNo: 1 };
    const change = async (weight: string, amount: string) =>
      owner.$transaction(async (tx) => {
        await tx.$executeRawUnsafe(
          `UPDATE "SL_PR_DETL" SET "ITM_NWT"=$2::numeric WHERE tenant_id=$1 AND "CO_CODE"='91'
        AND "LC_CODE"='01' AND "CO_YEAR"='2026-2027' AND "CO_BOOK"='O91' AND "VCH_NO"='00001' AND "SR_NO"=1`,
          base.tenantId,
          weight,
        );
        await tx.$executeRawUnsafe(
          `UPDATE "AC_DATA" SET "CR_AMT"=$2::numeric WHERE tenant_id=$1 AND "CO_CODE"='91'
        AND "LC_CODE"='01' AND "CO_YEAR"='2026-2027' AND "AC_CODE"='PARTY' AND "ENTRY_TIME"='2026-04-03 12:34:56'`,
          base.tenantId,
          amount,
        );
      });
    let edited = false;
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
                    if (
                      !edited &&
                      sql.startsWith('SELECT *') &&
                      sql.includes(' FROM "SL_ORD_DATA"')
                    ) {
                      edited = true;
                      await change('9.9', '99.99');
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
      const spec = loadReportSpec('OrderBill')!;
      const before = await bindReport(concurrentRuntime, spec, s);
      expect(edited).toBe(true);
      expect(before?.subreports?.OrdRec?.header['Sum ({SL_PR_DETL.ITM_NWT})']).toBe('3.3');
      expect(before?.header['@ClAmt']).toBe('23.7');
      const after = await bindReport(runtime, spec, s);
      expect(after?.subreports?.OrdRec?.header['Sum ({SL_PR_DETL.ITM_NWT})']).toBe('12.1');
      expect(after?.header['@ClAmt']).toBe('113.44');
    } finally {
      await change('1.1', '10.25');
    }
  });
});
