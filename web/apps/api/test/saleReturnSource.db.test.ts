import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  getSaleReturnSourceItems,
  listSaleReturnSourceVouchers,
  type SaleReturnSourceItemsQuery,
} from '../src/modules/sales/saleReturnSource.js';
import { assertIsolatedTestDatabase } from './support/isolatedDatabase.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('original sale source observation without Return admission', () => {
  const tenantId = 'return-source-round7';
  const otherTenant = 'return-src-other-r7';
  const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R71' };
  const source = { sourceYear: '2022-2023', sourceBook: 'S71', sourceVchNo: '00001' };
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const tables = [
    'SL_DATA',
    'SL_DETL',
    'SL_IDTL',
    'SL_DETL_RTN',
    'BOOK_DATA',
    'YEAR_MAST',
    'ITEM_MAST',
    'BAR_DATA',
    'BAR_DETL',
    'BAR_IDTL',
    'MAIN_STOCK',
    'AC_DATA',
    'TAX_DATA',
    'BILL_OS_DATA',
    'ROJ_MEL_DATA',
    'TEMP_BOOK_DATA',
  ];
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const insert = async (table: string, values: Record<string, unknown>) => {
    const cols = Object.keys(values)
      .map((key) => `"${key}"`)
      .join(',');
    await sql(
      `INSERT INTO "${table}" (${cols}) SELECT ${cols} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const key = (extra: Record<string, unknown> = {}) => ({
    tenant_id: tenantId,
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2022-2023',
    CO_BOOK: 'S71',
    VCH_NO: '00001',
    ...extra,
  });
  const get = (query: SaleReturnSourceItemsQuery = source) =>
    getSaleReturnSourceItems(runtime, scope, query);
  const cleanup = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN($1,$2)`, tenantId, otherTenant);
  };
  const snapshot = async () => {
    const result: Record<string, unknown> = {};
    for (const table of tables)
      result[table] = await owner.$queryRawUnsafe(
        `SELECT to_jsonb(t)::text raw,t.xmin::text revision,t.ctid::text locator FROM "${table}" t WHERE tenant_id IN($1,$2) ORDER BY to_jsonb(t)::text`,
        tenantId,
        otherTenant,
      );
    return result;
  };
  const addLink = async (
    extra: Record<string, unknown> = {},
    tags: Array<string | null> = ['TAG-A'],
  ) => {
    const values = key({
      CO_YEAR: '2023-2024',
      CO_BOOK: 'R71',
      VCH_NO: '00021',
      ISU_LC_CODE: '01',
      ISU_YRCD: '2022-2023',
      ISU_DBCD: 'S71',
      ISU_NO: '00001',
      AC_CODE: 'CUS',
      AC_NAME: 'Prior Return',
      ...extra,
    });
    await insert('SL_DATA', values);
    for (const [index, tag] of tags.entries())
      await insert('SL_DETL_RTN', {
        tenant_id: values.tenant_id,
        CO_CODE: values.CO_CODE,
        LC_CODE: values.LC_CODE,
        CO_YEAR: values.CO_YEAR,
        CO_BOOK: values.CO_BOOK,
        VCH_NO: values.VCH_NO,
        SR_NO: index + 1,
        OLD_SRNO: 31,
        TAG_NO: tag,
        VCH_SRNO: 917,
        IT_CODE: 'GOLD',
      });
  };
  beforeAll(() => {
    assertIsolatedTestDatabase();
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await cleanup();
    for (const tenant of [tenantId, otherTenant]) {
      for (const book of ['R71', 'S71', 'S72'])
        await insert('BOOK_DATA', {
          tenant_id: tenant,
          CO_CODE: '01',
          LC_CODE: '01',
          CO_BOOK: book,
          MAIN_BOOK: book === 'R71' ? 'SALES RETURNE' : 'SALES',
          BOOK_NAME: book === 'S72' ? 'Literal % original book' : `Original ${book}`,
          BOOK_INOUT: book === 'R71' ? 'I' : 'O',
          BOOK_TBL_NAME: 'SL_DATA',
          CUR_USE: 'Y',
        });
      for (const year of ['2022-2023', '2023-2024', '2024-2025'])
        await insert('YEAR_MAST', { tenant_id: tenant, CO_CODE: '01', CO_YEAR: year });
    }
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      IT_CODE: 'GOLD',
      IT_NAME: 'Company gold',
    });
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '02',
      IT_CODE: 'GOLD',
      IT_NAME: 'Other company sentinel',
    });
    await insert(
      'SL_DATA',
      key({
        VCH_DATE: '2022-05-04',
        VCH_TIME: '2022-05-04T12:13:14.123456',
        BILL_NO: 'Printed invoice differs',
        AC_CODE: 'CUS',
        AC_NAME: 'Original buyer',
        TOT_AMT: '9999999999999999.99',
        NET_AMT: null,
        ADD1: null,
        ADD2: '',
        ADD3: '  exact spaces  ',
      }),
    );
    // Deliberately reverse insertion order: the UI order follows saved SR, not row_id/ctid.
    for (const [sr, old, instance, tag] of [
      [42, 58, 580, 'TAG-B'],
      [17, 31, 301, 'TAG-A'],
    ] as const)
      await insert(
        'SL_DETL',
        key({
          SR_NO: sr,
          OLD_SRNO: old,
          VCH_SRNO: instance,
          VCH_TIME: '2022-05-04T12:13:14.123456',
          IT_CODE: 'GOLD',
          TAG_NO: tag,
          ITM_PCS: '0.000',
          ITM_GWT: '4.321',
          ITM_NWT: '3.123',
          ITM_RATE: '9999999999999999.99',
          ITM_FINE: null,
          ITM_REMARK: sr === 17 ? null : '',
          HM_ID: 'H1',
          HM_ID2: null,
          HM_ID3: '',
          HM_ID4: 'H4',
          HM_ID_WT: '0.123',
          HM_ID4_WT: '0.444',
          DESIGN_IMG_ID: sr === 17 ? 'OLD-IMG' : null,
          ITM_STYLE: '  STYLE  ',
          LBR_RATE: '17.19',
          TAX_PRC: '3.1250',
        }),
      );
    for (const isr of [10, 9, 3, 2])
      await insert(
        'SL_IDTL',
        key({
          SR_NO: 31,
          ISR_NO: isr,
          VCH_SRNO: 301,
          TAG_NO: 'TAG-A',
          IT_CODE: 'STONE',
          DM_NAME: `Component ${isr}`,
          DM_REMARK: isr === 3 ? null : '',
          IT_PCS: 0,
          IT_GWT: '0.123',
          IT_RATE: '9999999999999999.99',
          IT_AMT: null,
          KR_NET_AMT: '29.17',
        }),
      );
    for (const extra of [
      { CO_BOOK: 'S72' },
      { CO_YEAR: '2023-2024' },
      { LC_CODE: '02' },
      { CO_CODE: '02' },
      { tenant_id: otherTenant },
    ])
      await insert(
        'SL_DATA',
        key({
          ...extra,
          VCH_DATE: '2022-05-03',
          AC_NAME: 'Other scope sentinel',
          TOT_AMT: '10.00',
        }),
      );
    await insert('TEMP_BOOK_DATA', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LC_CODE: '01',
      CO_BOOK: 'R71',
      VCH_NO: '00022',
    });
    await insert(
      'MAIN_STOCK',
      key({
        SR_NO: 31,
        IT_CODE: 'GOLD',
        TAG_NO: 'TAG-A',
        VCH_SRNO: 301,
        ITM_SIGN: '-',
        ITM_GWT: '4.321',
      }),
    );
  });
  afterAll(async () => {
    if (owner) {
      await cleanup();
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });

  it('reads exact original parent OLD ownership and numerically ordered children without any writes', async () => {
    const before = await snapshot();
    const dto = await get();
    expect(dto.source).toEqual({
      coCode: '01',
      lcCode: '01',
      coYear: '2022-2023',
      coBook: 'S71',
      voucherNo: '00001',
    });
    expect(dto.scope).toEqual(scope);
    expect(dto.capabilities.canApplyIncoming).toBe(false);
    expect(dto.header.raw).toMatchObject({
      TOT_AMT: '9999999999999999.99',
      NET_AMT: null,
      ADD1: null,
      ADD2: '',
      ADD3: '  exact spaces  ',
      VCH_TIME: '2022-05-04T12:13:14.123456',
    });
    expect(dto.lines.map((line) => line.sourceRef.srNo)).toEqual(['17', '42']);
    expect(dto.lines.map((line) => line.sourceRef.oldSrNo)).toEqual(['31', '58']);
    expect(dto.lines[0]!.sourceRef).toMatchObject({
      vchSrno: '301',
      tagNo: 'TAG-A',
      itCode: 'GOLD',
    });
    expect(dto.lines[0]!.sourceRef.recordId).toMatch(/^[a-f0-9]{64}$/);
    expect(dto.lines[0]!.raw).toMatchObject({
      ITM_PCS: '0.000',
      ITM_RATE: '9999999999999999.99',
      ITM_FINE: null,
      ITM_REMARK: null,
      HM_ID2: null,
      HM_ID3: '',
      HM_ID4_WT: '0.444',
      DESIGN_IMG_ID: 'OLD-IMG',
    });
    expect(dto.lines[0]!.components.map((child) => child.identity.isrNo)).toEqual([
      '2',
      '3',
      '9',
      '10',
    ]);
    expect(dto.lines[0]!.components[1]!.raw).toMatchObject({
      SR_NO: '31',
      ISR_NO: '3',
      DM_REMARK: null,
      IT_RATE: '9999999999999999.99',
    });
    expect(dto.lines[1]!.components).toEqual([]);
    expect(dto.unresolvedComponents).toEqual([]);
    expect(dto.lines.every((line) => line.canSelect)).toBe(true);
    expect(dto.lines[0]!.display).toEqual({ itemName: 'Company gold', itemNameReason: null });
    expect(await snapshot()).toEqual(before);
    expect((await get()).version).toBe(dto.version);
  });
  it('browses exact books/historical years with bounded string pagination and literal search', async () => {
    const all = await listSaleReturnSourceVouchers(runtime, scope, {});
    expect(
      all.rows.map((row) => [row.source.coYear, row.source.coBook, row.source.voucherNo]),
    ).toEqual([
      ['2022-2023', 'S71', '00001'],
      ['2022-2023', 'S72', '00001'],
      ['2023-2024', 'S71', '00001'],
    ]);
    const page = await listSaleReturnSourceVouchers(runtime, scope, { offset: '1', limit: '1' });
    expect(page.rows).toHaveLength(1);
    expect(page.hasMore).toBe(true);
    const match = await listSaleReturnSourceVouchers(runtime, scope, { search: '%' });
    expect(match.rows.map((row) => row.source.coBook)).toEqual(['S72']);
    expect(match.rows[0]!.availability).toMatchObject({
      status: 'unsupported',
      reason: 'The original sale has no saved source items.',
    });
    expect(
      (await listSaleReturnSourceVouchers(runtime, scope, { search: 'Printed invoice' })).rows,
    ).toHaveLength(1);
    expect(
      (
        await listSaleReturnSourceVouchers(runtime, scope, {
          sourceYear: '2023-2024',
          sourceBook: 'S71',
        })
      ).rows,
    ).toHaveLength(1);
  });
  it('keeps configured original book separate from target Return and rejects wrong/missing configuration', async () => {
    expect((await get({ ...source, sourceBook: 'S72' })).header.raw.AC_NAME).toBe(
      'Other scope sentinel',
    );
    await expect(get({ ...source, sourceYear: '2021-2022' })).rejects.toMatchObject({
      statusCode: 422,
      code: 'configuration',
    });
    await expect(get({ ...source, sourceBook: 'R71' })).rejects.toMatchObject({ statusCode: 422 });
    await expect(
      getSaleReturnSourceItems(runtime, { ...scope, coBook: 'S71' }, source),
    ).rejects.toMatchObject({ statusCode: 422 });
    await sql(
      'UPDATE "BOOK_DATA" SET "CUR_USE"=\'N\' WHERE tenant_id=$1 AND "CO_BOOK"=\'S71\'',
      tenantId,
    );
    await expect(get()).rejects.toMatchObject({ statusCode: 422 });
  });
  it('rejects duplicate year/book/header identities instead of choosing the first', async () => {
    await insert('YEAR_MAST', { tenant_id: tenantId, CO_CODE: '01', CO_YEAR: '2022-2023' });
    await expect(get()).rejects.toMatchObject({ statusCode: 422 });
    await sql(
      'DELETE FROM "YEAR_MAST" WHERE row_id=(SELECT max(row_id) FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR"=\'2022-2023\')',
      tenantId,
    );
    await insert('BOOK_DATA', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LC_CODE: '01',
      CO_BOOK: 'S71',
      MAIN_BOOK: 'SALES',
      CUR_USE: 'Y',
    });
    await expect(get()).rejects.toMatchObject({ statusCode: 422 });
    await sql(
      'DELETE FROM "BOOK_DATA" WHERE row_id=(SELECT max(row_id) FROM "BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=\'S71\')',
      tenantId,
    );
    await insert('SL_DATA', key({ AC_NAME: 'Duplicate' }));
    await expect(get()).rejects.toMatchObject({ statusCode: 422, code: 'unsupported-state' });
    expect(
      (
        await listSaleReturnSourceVouchers(runtime, scope, {
          sourceBook: 'S71',
          sourceYear: '2022-2023',
        })
      ).rows.every((row) => row.availability.status === 'ambiguous'),
    ).toBe(true);
  });
  it('requires the selected target year and versions its configuration independently of the original year', async () => {
    const initial = await get();
    await sql(
      'UPDATE "YEAR_MAST" SET "OP_DATE"=\'2024-04-01\' WHERE tenant_id=$1 AND "CO_YEAR"=\'2024-2025\'',
      tenantId,
    );
    expect((await get()).version).not.toBe(initial.version);
    await sql('DELETE FROM "YEAR_MAST" WHERE tenant_id=$1 AND "CO_YEAR"=\'2024-2025\'', tenantId);
    await expect(get()).rejects.toMatchObject({ statusCode: 422, code: 'configuration' });
    await expect(listSaleReturnSourceVouchers(runtime, scope, {})).rejects.toMatchObject({
      statusCode: 422,
      code: 'configuration',
    });
  });
  it('uses exact persisted1 before00001 and preserves6–8 digit imported keys', async () => {
    expect((await get({ ...source, sourceVchNo: '1' })).source.voucherNo).toBe('00001');
    for (const voucher of ['1', '123456', '1234567', '12345678'])
      await insert('SL_DATA', key({ VCH_NO: voucher, AC_NAME: `Saved ${voucher}` }));
    for (const voucher of ['1', '123456', '1234567', '12345678'])
      expect((await get({ ...source, sourceVchNo: voucher })).header.raw.AC_NAME).toBe(
        `Saved ${voucher}`,
      );
    await expect(get({ ...source, sourceVchNo: '87654321' })).rejects.toMatchObject({
      statusCode: 404,
    });
  });
  it.each([
    { sourceYear: 2022 },
    { sourceBook: ['S71'] },
    { sourceVchNo: '1e2' },
    { sourceVchNo: ' 00001' },
    { sourceVchNo: '00000000' },
    { sourceVchNo: '123456789' },
    { sourceVchNo: 1 },
    { book: 'S71' },
  ])('rejects malformed source query %j', async (extra) => {
    await expect(
      get({ ...source, ...extra } as unknown as SaleReturnSourceItemsQuery),
    ).rejects.toMatchObject({ statusCode: 400 });
  });
  it.each([
    { offset: '01' },
    { offset: '-1' },
    { offset: 1.5 },
    { limit: '0' },
    { limit: '101' },
    { search: ['x'] },
    { sourceYear: ['2022-2023'] },
    { sourceBook: 71 },
    { extra: 'ignored' },
  ])('rejects malformed browse query %j', async (query) => {
    await expect(
      listSaleReturnSourceVouchers(runtime, scope, query as never),
    ).rejects.toMatchObject({ statusCode: 400 });
  });
  it('marks only matching tags returned across Return years/books, without admitting the source instance', async () => {
    await addLink();
    const dto = await get();
    expect(dto.lines[0]!.availability.status).toBe('returned');
    expect(dto.lines[1]!.availability.status).toBe('available');
    expect(dto.linkedReturns[0]!.source).toMatchObject({
      coYear: '2023-2024',
      coBook: 'R71',
      voucherNo: '00021',
    });
    expect(dto.linkedReturns[0]!.linesRaw[0]!.VCH_SRNO).toBe('917');
    expect(dto.lines[0]!.sourceRef.vchSrno).toBe('301');
    expect(dto.capabilities.canApplyIncoming).toBe(false);
    expect(
      (
        await listSaleReturnSourceVouchers(runtime, scope, {
          sourceYear: '2022-2023',
          sourceBook: 'S71',
        })
      ).rows[0]!.availability.status,
    ).toBe('returned');
  });
  it.each([
    { ISU_LC_CODE: '02' },
    { ISU_YRCD: '2023-2024' },
    { ISU_DBCD: 'S72' },
    { ISU_NO: '00002' },
    { LC_CODE: '02' },
  ])('does not borrow a known other original scope %j', async (extra) => {
    await addLink(extra);
    const dto = await get();
    expect(dto.linkedReturns).toEqual([]);
    expect(dto.lines.every((line) => line.canSelect)).toBe(true);
  });
  it.each([
    { ISU_LC_CODE: null },
    { ISU_LC_CODE: '' },
    { ISU_LC_CODE: '01 ' },
    { ISU_YRCD: '2022-2023 ' },
    { ISU_DBCD: 'S7 ' },
    { ISU_NO: '00001 ' },
  ])('retains and blocks noncanonical linked reference %j', async (extra) => {
    const selected = { ...source };
    if (extra.ISU_DBCD) {
      // varchar(3) discards a fourth trailing space; use a genuinely stored padded short book.
      for (const table of ['BOOK_DATA', 'SL_DATA', 'SL_DETL', 'SL_IDTL'])
        await sql(
          `UPDATE "${table}" SET "CO_BOOK"='S7' WHERE tenant_id=$1 AND "CO_BOOK"='S71'`,
          tenantId,
        );
      selected.sourceBook = 'S7';
    }
    await addLink(extra);
    const dto = await get(selected);
    expect(dto.linkedReturns).toHaveLength(1);
    expect(dto.lines.every((line) => line.availability.status === 'ambiguous')).toBe(true);
    expect(dto.linkedReturns[0]!.headerRaw).toMatchObject(extra);
  });
  it('keeps all source rows visible for orphan/NULL-tag prior Return evidence', async () => {
    await addLink({}, []);
    const orphan = await get();
    expect(orphan.lines).toHaveLength(2);
    expect(orphan.lines.every((line) => line.availability.status === 'ambiguous')).toBe(true);
    await insert(
      'SL_DETL_RTN',
      key({ CO_YEAR: '2023-2024', CO_BOOK: 'R71', VCH_NO: '00021', SR_NO: 1, TAG_NO: null }),
    );
    const nullTag = await get();
    expect(nullTag.lines).toHaveLength(2);
    expect(nullTag.lines.every((line) => !line.canSelect)).toBe(true);
  });
  it('does not guess children from duplicateOLD, conflictingtag/instance or web filtered-tag misindex', async () => {
    await sql('UPDATE "SL_DETL" SET "OLD_SRNO"=31 WHERE tenant_id=$1 AND "SR_NO"=42', tenantId);
    let dto = await get();
    expect(dto.unresolvedComponents).toHaveLength(4);
    expect(dto.lines.every((line) => !line.canSelect)).toBe(true);
    await sql('UPDATE "SL_DETL" SET "OLD_SRNO"=58 WHERE tenant_id=$1 AND "SR_NO"=42', tenantId);
    await sql(
      'UPDATE "SL_IDTL" SET "TAG_NO"=\'TAG-B\',"VCH_SRNO"=580 WHERE tenant_id=$1 AND "ISR_NO"=3',
      tenantId,
    );
    dto = await get();
    expect(dto.unresolvedComponents).toHaveLength(1);
    expect(dto.unresolvedComponents[0]!.raw).toMatchObject({
      SR_NO: '31',
      TAG_NO: 'TAG-B',
      VCH_SRNO: '580',
    });
    expect(dto.lines[1]!.components).toEqual([]);
  });
  it('preserves duplicated child identities and orphan components separately', async () => {
    await insert(
      'SL_IDTL',
      key({
        SR_NO: 31,
        ISR_NO: 3,
        TAG_NO: 'TAG-A',
        VCH_SRNO: 301,
        IT_CODE: 'STONE',
        DM_NAME: 'Duplicate child',
      }),
    );
    await insert(
      'SL_IDTL',
      key({ SR_NO: 999, ISR_NO: 1, TAG_NO: 'ORPHAN', IT_CODE: 'STONE', DM_NAME: 'Orphan child' }),
    );
    const dto = await get();
    expect(dto.unresolvedComponents).toHaveLength(3);
    expect(dto.lines[0]!.components).toHaveLength(3);
    expect(dto.lines.every((line) => !line.canSelect)).toBe(true);
  });
  it('recognizes uniqueOLD untaggedN/blank child but never merges repeated source tags', async () => {
    await sql('UPDATE "SL_DETL" SET "TAG_NO"=\'N\' WHERE tenant_id=$1 AND "SR_NO"=17', tenantId);
    await sql('UPDATE "SL_IDTL" SET "TAG_NO"=\'\' WHERE tenant_id=$1', tenantId);
    expect((await get()).lines[0]!.components).toHaveLength(4);
    await sql('UPDATE "SL_DETL" SET "TAG_NO"=\'N\' WHERE tenant_id=$1 AND "SR_NO"=42', tenantId);
    expect((await get()).lines.every((line) => line.availability.status === 'ambiguous')).toBe(
      true,
    );
  });
  it('reports blank/missing/ambiguous company item names without borrowing blank or other-company masters', async () => {
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      IT_CODE: '',
      IT_NAME: 'Blank master must not resolve',
    });
    await sql('UPDATE "SL_DETL" SET "IT_CODE"=\'\' WHERE tenant_id=$1 AND "SR_NO"=17', tenantId);
    let dto = await get();
    expect(dto.lines[0]!.display.itemName).toBe(null);
    expect(dto.lines[0]!.display.itemNameReason).toMatch(/blank/);
    expect(dto.lines[0]!.canSelect).toBe(false);
    await sql(
      'UPDATE "SL_DETL" SET "IT_CODE"=\'LOST\' WHERE tenant_id=$1 AND "SR_NO"=17',
      tenantId,
    );
    expect((await get()).lines[0]!.display.itemNameReason).toMatch(/not found/);
    await sql(
      'UPDATE "SL_DETL" SET "IT_CODE"=\'GOLD\' WHERE tenant_id=$1 AND "SR_NO"=17',
      tenantId,
    );
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      IT_CODE: 'GOLD ',
      IT_NAME: 'Company gold',
    });
    dto = await get();
    expect(dto.lines[0]!.display.itemNameReason).toMatch(/multiple/);
    expect(dto.lines[0]!.raw.ITM_REMARK).toBe(null);
  });
  it('invalidates observations for source/master/config/child/linked Return changes and ABA', async () => {
    let previous = (await get()).version;
    const originalVersion = previous;
    const changed = async () => {
      const next = (await get()).version;
      expect(next).not.toBe(previous);
      previous = next;
    };
    await sql(
      'UPDATE "SL_DATA" SET "AC_NAME"=\'Changed\' WHERE tenant_id=$1 AND "CO_BOOK"=\'S71\' AND "CO_YEAR"=\'2022-2023\'',
      tenantId,
    );
    await changed();
    await sql(
      'UPDATE "SL_DATA" SET "AC_NAME"=\'Original buyer\' WHERE tenant_id=$1 AND "CO_BOOK"=\'S71\' AND "CO_YEAR"=\'2022-2023\'',
      tenantId,
    );
    await changed();
    expect(previous).not.toBe(originalVersion);
    await sql('UPDATE "SL_DETL" SET "HM_ID"=\'H2\' WHERE tenant_id=$1 AND "SR_NO"=17', tenantId);
    await changed();
    await sql(
      'UPDATE "SL_IDTL" SET "DM_NAME"=\'Changed stone\' WHERE tenant_id=$1 AND "ISR_NO"=3',
      tenantId,
    );
    await changed();
    await sql(
      'UPDATE "ITEM_MAST" SET "IT_NAME"=\'Changed name\' WHERE tenant_id=$1 AND "CO_CODE"=\'01\' AND "IT_CODE"=\'GOLD\'',
      tenantId,
    );
    await changed();
    await sql(
      'UPDATE "YEAR_MAST" SET "OP_DATE"=\'2022-04-01\' WHERE tenant_id=$1 AND "CO_YEAR"=\'2022-2023\'',
      tenantId,
    );
    await changed();
    await sql(
      'UPDATE "BOOK_DATA" SET "BOOK_NAME"=\'Changed source book\' WHERE tenant_id=$1 AND "CO_BOOK"=\'S71\'',
      tenantId,
    );
    await changed();
    await addLink();
    await changed();
    await sql('UPDATE "SL_DETL_RTN" SET "HM_ID"=\'OTHER\' WHERE tenant_id=$1', tenantId);
    await changed();
    const beforeRecreate = await get();
    const saved = await owner.$queryRawUnsafe<Array<{ raw: Record<string, unknown> }>>(
      'SELECT (SELECT jsonb_object_agg(key,value) FROM jsonb_each_text(to_jsonb(t)-\'row_id\')) raw FROM "SL_IDTL" t WHERE tenant_id=$1 AND "ISR_NO"=3',
      tenantId,
    );
    await sql('DELETE FROM "SL_IDTL" WHERE tenant_id=$1 AND "ISR_NO"=3', tenantId);
    await changed();
    await insert('SL_IDTL', saved[0]!.raw);
    await changed();
    const recreated = await get();
    expect(recreated.version).not.toBe(beforeRecreate.version);
    expect(recreated.lines[0]!.components.map((child) => child.raw)).toEqual(
      beforeRecreate.lines[0]!.components.map((child) => child.raw),
    );
  });
});
