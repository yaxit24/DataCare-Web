import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import {
  getSavedSaleReturnIncoming,
  listSavedSaleReturnIncoming,
  updateSavedSaleReturnMetadata,
  SavedSaleReturnError,
  type SavedSaleReturnScope,
} from '../src/modules/sales/savedSaleReturn.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
run('saved incoming Sales Return metadata preservation', () => {
  const tenantId = 'return-saved-round6';
  const otherTenant = 'return-saved-other-r6';
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const scope = (coBook = 'R71'): SavedSaleReturnScope => ({
    tenantId,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook,
  });
  const key = (extra: Record<string, unknown> = {}) => ({
    tenant_id: tenantId,
    CO_CODE: '01',
    LC_CODE: '01',
    CO_YEAR: '2024-2025',
    CO_BOOK: 'R71',
    VCH_NO: '00001',
    ...extra,
  });
  const tables = [
    'SL_DATA',
    'SL_DETL_RTN',
    'SL_DETL',
    'SL_IDTL',
    'BAR_DATA',
    'BAR_DETL',
    'BAR_IDTL',
    'MAIN_STOCK',
    'AC_DATA',
    'TAX_DATA',
    'BILL_OS_DATA',
    'ROJ_MEL_DATA',
    'DM_DATA',
    'REMARK_DATA',
    'TEMP_BOOK_DATA',
    'BOOK_DATA',
    'ITEM_MAST',
    'EMP_MAST',
    'CO_SET',
  ];
  const sql = (statement: string, ...values: unknown[]) =>
    owner.$executeRawUnsafe(statement, ...values);
  const query = (statement: string, ...values: unknown[]) =>
    owner.$queryRawUnsafe<any[]>(statement, ...values);
  const insert = async (table: string, values: Record<string, unknown>) => {
    const columns = Object.keys(values)
      .map((column) => `"${column}"`)
      .join(',');
    await sql(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const clean = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id IN ($1,$2)`, tenantId, otherTenant);
  };
  async function snapshot(exclude: string[] = []) {
    const result: Record<string, unknown> = {};
    for (const table of tables) {
      const omitted = table === 'SL_DETL_RTN' ? exclude : [];
      result[table] = await query(
        `SELECT (to_jsonb(t)-$3::text[])::text AS raw FROM "${table}" t WHERE tenant_id IN ($1,$2) ORDER BY (to_jsonb(t)-$3::text[])::text`,
        tenantId,
        otherTenant,
        omitted,
      );
    }
    return result;
  }
  const get = () => getSavedSaleReturnIncoming(runtime, scope(), '00001');
  const patch = async (changes: { huid?: string; description?: string }, index = 0) => {
    const saved = await get();
    return { version: saved.version, lines: [{ identity: saved.lines[index]!.identity, changes }] };
  };
  beforeAll(async () => {
    for (const value of [process.env.MIGRATE_DATABASE_URL, process.env.DATABASE_URL]) {
      if (!value || new URL(value).port !== '55433')
        throw new Error('Isolated parity database55433 required.');
    }
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await clean();
    await insert('CO_SET', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LOCK_DATE: null,
      EMP_CODE_MANDATORY: 'N',
    });
    await insert('CO_SET', {
      tenant_id: otherTenant,
      CO_CODE: '01',
      LOCK_DATE: null,
      EMP_CODE_MANDATORY: 'N',
    });
    for (const t of [tenantId, otherTenant]) {
      for (const coBook of ['R71', 'R72'])
        await insert('BOOK_DATA', {
          tenant_id: t,
          CO_CODE: '01',
          LC_CODE: '01',
          CO_BOOK: coBook,
          MAIN_BOOK: 'SALES RETURNE',
          BOOK_NAME: `Return ${coBook}`,
          BOOK_SNAME: 'SRTN',
          BOOK_INOUT: 'I',
          CUR_USE: 'Y',
          BOOK_TBL_NAME: 'SL_DATA',
        });
    }
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      IT_CODE: 'GOLD',
      IT_NAME: 'Saved gold name',
    });
    await insert('EMP_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      EMP_CODE: '001',
      EMP_NAME: 'First employee',
    });
    await insert('EMP_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      EMP_CODE: '002',
      EMP_NAME: 'Second employee',
    });
    await insert(
      'SL_DATA',
      key({
        VCH_DATE: '2024-07-10',
        VCH_TIME: '2024-07-10T12:34:56.123456',
        ENTRY_TIME: '2024-07-10',
        HD_VCH_NO: 'H71',
        BILL_NO: 'Printed bill label',
        AC_CODE: 'PARTY',
        AC_NAME: 'Saved customer',
        ISU_NO: '00421',
        ISU_YRCD: '2022-2023',
        ISU_DBCD: 'S11',
        ISU_LC_CODE: '02',
        EMP_CODE: '001',
        VCH_DESC: 'Stored description',
        MAIN_USER: 'saved-owner',
        NET_AMT: '9999999999999999.99',
        TOT_AMT: '123.45',
        RTN_NET_AMT: 42.125,
        RTN_TOT_AMT: 47.25,
        DISC_AMT: null,
        IRN_NO: '0',
      }),
    );
    for (const [srNo, oldSrNo] of [
      [17, 31],
      [42, 58],
    ]) {
      await insert(
        'SL_DETL_RTN',
        key({
          SR_NO: srNo,
          OLD_SRNO: oldSrNo,
          VCH_SRNO: 500001.125,
          TAG_SRNO: 123.5,
          VCH_DATE: '2024-07-10',
          VCH_TIME: '2024-07-10T12:34:56.123456',
          HD_VCH_NO: 'H71',
          ENTRY_TYPE: 'P',
          INOUT_TYPE: 'I',
          BOOK_NAME: 'SALES RETURNE',
          AC_CODE: 'PARTY',
          IT_CODE: 'GOLD',
          TAG_NO: srNo === 17 ? 'N' : null,
          HM_ID: srNo === 17 ? null : '',
          ITM_REMARK: srNo === 17 ? 'Original description' : null,
          HM_ID2: 'H2',
          HM_ID3: null,
          HM_ID4: '',
          HM_ID_WT: '12345678901.123',
          HM_ID2_WT: '0.000',
          HM_ID3_WT: null,
          HM_ID4_WT: '0.456',
          DESIGN_IMG_ID: null,
          ITM_STYLE: 'Imported style',
          ITM_LOT: 'KEEPLOT',
          LBR_CODE: 'L1',
          TAG_LBR_CODE: 'TL01',
          TAG_MRP: '19.45',
          ITM_GHT_PRC: '2.3456',
          DISC_PRC: '7.1234',
          DISC_AMT: '11.23',
          LBR_RATE: '9999999999999999.99',
          ITM_FINE: null,
          ITM_AMT: '17.31',
          LBR_AMT: '77.37',
          NET_AMT: '94.68',
          TOT_AMT: '111.91',
          EMP_CODE: '001',
          APR_ISU: 'N',
          EMP_ISU: null,
          DATA_TYPE: 'A',
          MAIN_USER: 'saved-owner',
        }),
      );
    }
    await insert(
      'SL_DATA',
      key({ CO_BOOK: 'R72', VCH_DATE: '2024-07-11', AC_CODE: 'SIBLING', EMP_CODE: '001' }),
    );
    await insert(
      'SL_DETL_RTN',
      key({ CO_BOOK: 'R72', SR_NO: 17, IT_CODE: 'GOLD', HM_ID: 'OTHER', ENTRY_TYPE: 'P' }),
    );
    await insert(
      'SL_DATA',
      key({ tenant_id: otherTenant, VCH_DATE: '2024-07-11', AC_CODE: 'FOREIGN' }),
    );
    await insert(
      'SL_DETL_RTN',
      key({ tenant_id: otherTenant, SR_NO: 17, IT_CODE: 'GOLD', ENTRY_TYPE: 'P', HM_ID: 'TENANT' }),
    );
    await insert(
      'AC_DATA',
      key({
        LEDR_KEY: 'R71-AC-KEEP',
        AC_CODE: 'PARTY',
        DR_AMT: '12.34',
        CR_AMT: '0.00',
        VCH_DATE: '2024-07-10',
        ENTRY_TIME: '2024-07-10T12:34:56.123456',
      }),
    );
    await insert(
      'BILL_OS_DATA',
      key({ SR_NO: 1, AC_CODE: 'PARTY', BILL_AMT: '12.34', REC_AMT: '0.00' }),
    );
    await insert(
      'ROJ_MEL_DATA',
      key({ LEDR_KEY: 'R71-ROJ-KEEP', AC_CODE: 'PARTY', DR_AMT: '12.34', ITM_NWT: '2.123' }),
    );
    await insert(
      'MAIN_STOCK',
      key({
        SR_NO: 17,
        IT_CODE: 'GOLD',
        TAG_NO: 'N',
        VCH_SRNO: 500001.125,
        ITM_SIGN: '+',
        ITM_NWT: '2.123',
        ITM_FINE: null,
      }),
    );
    await insert('TEMP_BOOK_DATA', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LC_CODE: '01',
      CO_BOOK: 'R71',
      VCH_NO: 'H71',
      BOOK_NAME: 'SALES RETURNE',
    });
  });
  afterAll(async () => {
    if (owner) await clean();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });

  it('hydrates complete exact decimals, nulls, timestamps, source refs and stable saved identities', async () => {
    const saved = await get();
    expect(saved.header.raw).toMatchObject({
      NET_AMT: '9999999999999999.99',
      ISU_YRCD: '2022-2023',
      ISU_DBCD: 'S11',
      ISU_LC_CODE: '02',
      ISU_NO: '00421',
      VCH_TIME: '2024-07-10T12:34:56.123456',
      DISC_AMT: null,
      IRN_NO: '0',
    });
    expect(saved.lines.map((row) => row.identity.srNo)).toEqual(['17', '42']);
    expect(saved.lines[0]!.raw).toMatchObject({
      OLD_SRNO: '31',
      VCH_SRNO: '500001.125',
      TAG_SRNO: '123.5',
      LBR_RATE: '9999999999999999.99',
      HM_ID: null,
      HM_ID3: null,
      HM_ID4: '',
      HM_ID_WT: '12345678901.123',
      ITM_FINE: null,
      TAG_LBR_CODE: 'TL01',
      ITM_GHT_PRC: '2.3456',
      DISC_PRC: '7.1234',
    });
    expect(saved.lines[1]!.display.description).toBe('Saved gold name');
    expect(saved.lines[1]!.raw.ITM_REMARK).toBeNull();
    expect(saved.lines[0]!.raw).not.toHaveProperty('row_id');
    expect(saved.lines[0]!.raw).not.toHaveProperty('tenant_id');
    expect(saved.version).toMatch(/^[a-f0-9]{64}$/);
  });

  it('lists and reads only the configured complete tenant/book scope', async () => {
    const list = await listSavedSaleReturnIncoming(runtime, scope());
    expect(list.rows).toHaveLength(1);
    expect(list.rows[0]!.raw.AC_CODE).toBe('PARTY');
    expect((await getSavedSaleReturnIncoming(runtime, scope('R72'), 1)).header.raw.AC_CODE).toBe(
      'SIBLING',
    );
    expect(
      (await getSavedSaleReturnIncoming(runtime, { ...scope(), tenantId: otherTenant }, 1)).header
        .raw.AC_CODE,
    ).toBe('FOREIGN');
    await expect(
      getSavedSaleReturnIncoming(runtime, { ...scope(), coYear: '2023-2024' }, 1),
    ).rejects.toMatchObject({ statusCode: 404 });
    await expect(
      getSavedSaleReturnIncoming(runtime, { ...scope(), coBook: '' }, 1),
    ).rejects.toMatchObject({ statusCode: 400 });
    await sql(
      'UPDATE "BOOK_DATA" SET "MAIN_BOOK"=$2 WHERE tenant_id=$1 AND "CO_BOOK"=$3',
      tenantId,
      'SALES',
      'R71',
    );
    await expect(get()).rejects.toThrow(/expected SALES RETURNE/);
  });

  it('updates only explicitly selected metadata and preserves every other row including physical IDs', async () => {
    const before = await snapshot(['HM_ID', 'ITM_REMARK']);
    const request = await patch({ huid: 'HU123', description: 'Changed description' });
    const saved = await updateSavedSaleReturnMetadata(runtime, scope(), 1, request);
    expect(saved.lines[0]!.raw).toMatchObject({
      HM_ID: 'HU123',
      ITM_REMARK: 'Changed description',
    });
    expect(saved.lines[1]!.raw.ITM_REMARK).toBeNull();
    expect(saved.version).not.toBe(request.version);
    expect(await snapshot(['HM_ID', 'ITM_REMARK'])).toEqual(before);
    expect((await getSavedSaleReturnIncoming(runtime, scope('R72'), 1)).lines[0]!.raw.HM_ID).toBe(
      'OTHER',
    );
  });

  it('no-op commits do not rewrite rows or turn a display fallback into a stored description', async () => {
    const before = await snapshot();
    const initial = await get();
    const result = await updateSavedSaleReturnMetadata(runtime, scope(), 1, {
      version: initial.version,
      lines: [
        { identity: initial.lines[0]!.identity, changes: { description: 'Original description' } },
      ],
    });
    expect(result.version).toBe(initial.version);
    expect(await snapshot()).toEqual(before);
    expect(result.lines[1]!.raw.ITM_REMARK).toBeNull();
    const cleared = await updateSavedSaleReturnMetadata(runtime, scope(), 1, {
      version: result.version,
      lines: [{ identity: result.lines[1]!.identity, changes: { description: '', huid: '' } }],
    });
    expect(cleared.lines[1]!.raw.ITM_REMARK).toBe('');
    expect(cleared.lines[0]!.raw.HM_ID).toBeNull();
  });

  it('stamps one validated header employee across only proven existing employee-bearing rows', async () => {
    await insert(
      'BAR_DATA',
      key({
        VCH_DATE: '2024-07-10',
        VCH_TIME: '2024-07-10T12:34:56.123456',
        EMP_CODE: '001',
        VCH_DESC: 'Stored description',
        STK_IT_CODE: '',
      }),
    );
    const initial = await get();
    expect(initial.header.capabilities.employeeCode.allowed).toBe(true);
    const result = await updateSavedSaleReturnMetadata(runtime, scope(), 1, {
      version: initial.version,
      header: { employeeCode: '002' },
    });
    expect(result.header.raw.EMP_CODE).toBe('002');
    expect(result.lines.map((line) => line.raw.EMP_CODE)).toEqual(['002', '002']);
    expect(result.related.tagHeaders[0]!.EMP_CODE).toBe('002');
    expect(result.header.raw.VCH_TIME).toBe('2024-07-10T12:34:56.123456');
    expect(result.lines[0]!.raw.MAIN_USER).toBe('saved-owner');
    const unchanged = await snapshot();
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: result.version,
        header: { employeeCode: '999' },
      }),
    ).rejects.toMatchObject({ statusCode: 400 });
    expect(await snapshot()).toEqual(unchanged);
  });

  it('requires employee configuration and permits explicit blank only when optional', async () => {
    await sql('UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"=$2 WHERE tenant_id=$1', tenantId, 'Y');
    const saved = await get();
    const before = await snapshot();
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: saved.version,
        header: { employeeCode: '' },
      }),
    ).rejects.toMatchObject({ statusCode: 400 });
    expect(await snapshot()).toEqual(before);
    await sql('UPDATE "CO_SET" SET "EMP_CODE_MANDATORY"=$2 WHERE tenant_id=$1', tenantId, 'N');
    const fresh = await get();
    const cleared = await updateSavedSaleReturnMetadata(runtime, scope(), 1, {
      version: fresh.version,
      header: { employeeCode: '' },
    });
    expect(cleared.header.raw.EMP_CODE).toBe('');
    expect(cleared.lines.map((line) => line.raw.EMP_CODE)).toEqual(['', '']);
  });

  it.each([
    ['tagged', { TAG_NO: 'OLD-TAG' }],
    ['issued', { EMP_ISU: 'Y' }],
    ['approval', { APR_ISU: 'Y' }],
    ['unknown kind', { ENTRY_TYPE: 'X' }],
  ])(
    'keeps %s incoming rows readable but refuses metadata writes atomically',
    async (_label, changes) => {
      for (const [column, value] of Object.entries(changes as Record<string, string>))
        await sql(
          `UPDATE "SL_DETL_RTN" SET "${column}"=$2 WHERE tenant_id=$1 AND "CO_BOOK"='R71' AND "SR_NO"=17`,
          tenantId,
          value,
        );
      const saved = await get();
      const before = await snapshot();
      expect(saved.lines[0]!.capabilities.huid.allowed).toBe(false);
      await expect(
        updateSavedSaleReturnMetadata(runtime, scope(), 1, {
          version: saved.version,
          lines: [{ identity: saved.lines[0]!.identity, changes: { huid: 'FORBIDDEN' } }],
        }),
      ).rejects.toMatchObject({ statusCode: 422 });
      expect(await snapshot()).toEqual(before);
    },
  );

  it('denies unresolved tag companions even when their SR differs, without changing the original owner', async () => {
    await insert(
      'BAR_DETL',
      key({ SR_NO: 99, IT_CODE: 'GOLD', TAG_NO: 'N', VCH_SRNO: 500001.125, HM_ID: 'SOURCE' }),
    );
    const saved = await get();
    const before = await snapshot();
    expect(saved.lines[0]!.capabilities.huid.allowed).toBe(false);
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: saved.version,
        lines: [{ identity: saved.lines[0]!.identity, changes: { huid: 'NEW' } }],
      }),
    ).rejects.toMatchObject({ statusCode: 422 });
    expect(await snapshot()).toEqual(before);
  });

  it.each(['outgoing', 'outgoing child', 'diamond ledger', 'mismatched BAR header'])(
    'denies employee when %s effects cannot be proved',
    async (mode) => {
      if (mode === 'outgoing')
        await insert('SL_DETL', key({ SR_NO: 99, IT_CODE: 'GOLD', EMP_CODE: '001' }));
      if (mode === 'outgoing child')
        await insert('SL_IDTL', key({ SR_NO: 99, ISR_NO: 3, IT_CODE: 'GOLD' }));
      if (mode === 'diamond ledger')
        await insert('DM_DATA', key({ MAIN_SRNO: 1, SR_NO: 99, ISR_NO: 3, EMP_CODE: '001' }));
      if (mode === 'mismatched BAR header')
        await insert(
          'BAR_DATA',
          key({
            VCH_DATE: '2024-07-10',
            VCH_TIME: '2024-07-10T12:34:56.123455',
            EMP_CODE: '001',
            VCH_DESC: 'Stored description',
            STK_IT_CODE: '',
          }),
        );
      const saved = await get();
      const before = await snapshot();
      expect(saved.header.capabilities.employeeCode.allowed).toBe(false);
      await expect(
        updateSavedSaleReturnMetadata(runtime, scope(), 1, {
          version: saved.version,
          header: { employeeCode: '002' },
        }),
      ).rejects.toMatchObject({ statusCode: 422 });
      expect(await snapshot()).toEqual(before);
    },
  );

  it('protects saved period locks and the header update restriction without repairing raw data', async () => {
    await sql('UPDATE "CO_SET" SET "LOCK_DATE"=$2 WHERE tenant_id=$1', tenantId, '2024-07-10');
    let saved = await get();
    let before = await snapshot();
    expect(saved.capabilities.canUpdate).toBe(false);
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: saved.version,
        lines: [{ identity: saved.lines[0]!.identity, changes: { huid: 'DENY' } }],
      }),
    ).rejects.toMatchObject({ statusCode: 422 });
    expect(await snapshot()).toEqual(before);
    await sql('UPDATE "CO_SET" SET "LOCK_DATE"=NULL WHERE tenant_id=$1', tenantId);
    await sql(
      'UPDATE "SL_DATA" SET "USER_UPDATE"=$2 WHERE tenant_id=$1 AND "CO_BOOK"=$3',
      tenantId,
      'N',
      'R71',
    );
    saved = await get();
    before = await snapshot();
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: saved.version,
        header: { employeeCode: '002' },
      }),
    ).rejects.toMatchObject({ statusCode: 422 });
    expect(await snapshot()).toEqual(before);
  });

  it('rejects untrusted numeric/source fields, null, overlong, duplicated and foreign saved identities', async () => {
    const saved = await get();
    const before = await snapshot();
    const id = saved.lines[0]!.identity;
    const invalid: unknown[] = [
      { version: saved.version, lines: [{ identity: id, changes: { netAmount: 0 } }] },
      { version: saved.version, lines: [{ identity: id, changes: { designImageId: 'FORGED' } }] },
      { version: saved.version, lines: [{ identity: id, changes: { huid: null } }] },
      { version: saved.version, lines: [{ identity: id, changes: { huid: '12345678901' } }] },
      {
        version: saved.version,
        lines: [{ identity: id, changes: { description: 'x'.repeat(51) } }],
      },
      {
        version: saved.version,
        lines: [
          { identity: id, changes: { huid: 'ONE' } },
          { identity: id, changes: { huid: 'TWO' } },
        ],
      },
      { version: saved.version, header: { employeeCode: '001', netAmount: 0 } },
      {
        version: saved.version,
        lines: [{ identity: { ...id, srNo: 'Infinity' }, changes: { huid: 'A' } }],
      },
      { lines: [{ identity: id, changes: { huid: 'A' } }] },
    ];
    for (const value of invalid)
      await expect(updateSavedSaleReturnMetadata(runtime, scope(), 1, value)).rejects.toMatchObject(
        { statusCode: 400 },
      );
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: saved.version,
        lines: [{ identity: { ...id, vchSrno: '500001.126' }, changes: { huid: 'A' } }],
      }),
    ).rejects.toMatchObject({ statusCode: 409 });
    expect(await snapshot()).toEqual(before);
  });

  it('uses CAS so exactly one concurrent editor succeeds and stale retry cannot lose the winner', async () => {
    const saved = await get();
    const results = await Promise.allSettled(
      ['FIRST', 'SECOND'].map((huid) =>
        updateSavedSaleReturnMetadata(runtime, scope(), 1, {
          version: saved.version,
          lines: [{ identity: saved.lines[0]!.identity, changes: { huid } }],
        }),
      ),
    );
    expect(results.filter((r) => r.status === 'fulfilled')).toHaveLength(1);
    const failure = results.find((r) => r.status === 'rejected') as PromiseRejectedResult;
    expect(failure.reason).toBeInstanceOf(SavedSaleReturnError);
    expect(failure.reason.statusCode).toBe(409);
    const winner = await get();
    const before = await snapshot();
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: saved.version,
        header: { employeeCode: '002' },
      }),
    ).rejects.toMatchObject({ statusCode: 409 });
    expect(await snapshot()).toEqual(before);
    expect(['FIRST', 'SECOND']).toContain(winner.lines[0]!.raw.HM_ID);
  });

  it('invalidates a token after component ABA and parent recreation with the same values and physical ID', async () => {
    await insert(
      'BAR_IDTL',
      key({ SR_NO: 17, ISR_NO: 3, IT_CODE: 'GOLD', DM_NAME: 'FIRST', IT_GWT: '0.123' }),
    );
    const saved = await get();
    await sql('UPDATE "BAR_IDTL" SET "DM_NAME"=$2 WHERE tenant_id=$1', tenantId, 'SECOND');
    await sql('UPDATE "BAR_IDTL" SET "DM_NAME"=$2 WHERE tenant_id=$1', tenantId, 'FIRST');
    expect((await get()).version).not.toBe(saved.version);
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: saved.version,
        lines: [{ identity: saved.lines[0]!.identity, changes: { description: 'OLD TOKEN' } }],
      }),
    ).rejects.toMatchObject({ statusCode: 409 });
    const fresh = await get();
    const original = (
      await query(
        'SELECT to_jsonb(t)::text row FROM "SL_DATA" t WHERE tenant_id=$1 AND "CO_BOOK"=$2',
        tenantId,
        'R71',
      )
    )[0]!.row;
    await sql('DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2', tenantId, 'R71');
    await sql(
      'INSERT INTO "SL_DATA" SELECT * FROM jsonb_populate_record(NULL::"SL_DATA",$1::jsonb)',
      original,
    );
    expect(
      (
        await query(
          'SELECT to_jsonb(t)::text row FROM "SL_DATA" t WHERE tenant_id=$1 AND "CO_BOOK"=$2',
          tenantId,
          'R71',
        )
      )[0]!.row,
    ).toBe(original);
    expect((await get()).version).not.toBe(fresh.version);
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: fresh.version,
        lines: [{ identity: fresh.lines[0]!.identity, changes: { huid: 'STALE' } }],
      }),
    ).rejects.toMatchObject({ statusCode: 409 });
  });

  it('preserves both child datasets during allowed metadata edits and invalidates on outgoing changes', async () => {
    await insert(
      'BAR_IDTL',
      key({ SR_NO: 17, ISR_NO: 3, IT_CODE: 'GOLD', DM_NAME: 'Round', IT_GWT: '0.123' }),
    );
    await insert(
      'BAR_IDTL',
      key({ SR_NO: 17, ISR_NO: 9, IT_CODE: 'GOLD', DM_NAME: 'Oval', IT_GWT: '0.345' }),
    );
    await insert(
      'SL_IDTL',
      key({ SR_NO: 99, ISR_NO: 8, IT_CODE: 'GOLD', DM_NAME: 'Outgoing separate' }),
    );
    const initial = await get();
    const before = await snapshot(['HM_ID']);
    expect(initial.related.tagComponents.map((r) => r.IT_GWT).sort()).toEqual(['0.123', '0.345']);
    expect(initial.related.outgoingComponents).toHaveLength(1);
    const updated = await updateSavedSaleReturnMetadata(runtime, scope(), 1, {
      version: initial.version,
      lines: [{ identity: initial.lines[0]!.identity, changes: { huid: 'GOOD' } }],
    });
    expect(await snapshot(['HM_ID'])).toEqual(before);
    await insert('SL_DETL', key({ SR_NO: 99, IT_CODE: 'GOLD', ITM_AMT: '555.55' }));
    await expect(
      updateSavedSaleReturnMetadata(runtime, scope(), 1, {
        version: updated.version,
        lines: [{ identity: updated.lines[0]!.identity, changes: { huid: 'STALE' } }],
      }),
    ).rejects.toMatchObject({ statusCode: 409 });
  });

  it('rolls back the first actual write when the next update fails', async () => {
    const saved = await get();
    const before = await snapshot();
    let writes = 0;
    const failure = {
      $transaction: (fn: any, options: any) =>
        runtime.$transaction(
          async (tx) =>
            fn(
              new Proxy(tx, {
                get(target, prop) {
                  const original = Reflect.get(target, prop);
                  if (prop === '$executeRawUnsafe')
                    return async (...args: any[]) => {
                      if (/^UPDATE "SL_DETL_RTN"/.test(String(args[0])) && ++writes === 2)
                        throw new Error('fixture late write failure');
                      return original.apply(target, args);
                    };
                  return typeof original === 'function' ? original.bind(target) : original;
                },
              }),
            ),
          options,
        ),
    };
    await expect(
      updateSavedSaleReturnMetadata(failure, scope(), 1, {
        version: saved.version,
        lines: [
          { identity: saved.lines[0]!.identity, changes: { huid: 'FIRST' } },
          { identity: saved.lines[1]!.identity, changes: { description: 'FAIL SECOND' } },
        ],
      }),
    ).rejects.toThrow('fixture late write failure');
    expect(writes).toBe(2);
    expect(await snapshot()).toEqual(before);
    expect((await get()).version).toBe(saved.version);
  });

  it.each(['infinity', '-infinity', null])(
    'keeps saved date %s readable and blocks metadata even without a lock date',
    async (date) => {
      await sql(
        'UPDATE "SL_DATA" SET "VCH_DATE"=$2::date WHERE tenant_id=$1 AND "CO_BOOK"=$3',
        tenantId,
        date,
        'R71',
      );
      const saved = await get();
      const before = await snapshot();
      expect(saved.header.raw.VCH_DATE).toBe(date);
      expect(saved.capabilities.canUpdate).toBe(false);
      expect(saved.lines[0]!.capabilities.huid.reason).toMatch(/calendar date/);
      await expect(
        updateSavedSaleReturnMetadata(runtime, scope(), 1, {
          version: saved.version,
          lines: [{ identity: saved.lines[0]!.identity, changes: { huid: 'REFUSED' } }],
        }),
      ).rejects.toMatchObject({ statusCode: 422 });
      expect(await snapshot()).toEqual(before);
    },
  );

  it('accepts a valid leap-day saved date without rebuilding its independent persisted clock', async () => {
    await sql(
      'UPDATE "SL_DATA" SET "VCH_DATE"=$2::date WHERE tenant_id=$1 AND "CO_BOOK"=$3',
      tenantId,
      '2024-02-29',
      'R71',
    );
    const saved = await get();
    const before = await snapshot(['HM_ID']);
    expect(saved.lines[0]!.capabilities.huid.allowed).toBe(true);
    const result = await updateSavedSaleReturnMetadata(runtime, scope(), 1, {
      version: saved.version,
      lines: [{ identity: saved.lines[0]!.identity, changes: { huid: 'LEAP' } }],
    });
    expect(result.header.raw.VCH_DATE).toBe('2024-02-29');
    expect(result.header.raw.VCH_TIME).toBe('2024-07-10T12:34:56.123456');
    expect(await snapshot(['HM_ID'])).toEqual(before);
  });

  it('reports missing or duplicate item/employee masters independently from preserved raw descriptions', async () => {
    const original = await get();
    expect(original.lines[0]!.display.itemNameReason).toBeNull();
    expect(original.header.display.employeeNameReason).toBeNull();
    await insert('ITEM_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      IT_CODE: 'GOLD ',
      IT_NAME: 'Saved gold name',
    });
    await insert('EMP_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      EMP_CODE: '001',
      EMP_NAME: 'First employee',
    });
    let saved = await get();
    expect(saved.lines[0]!.display.itemName).toBeNull();
    expect(saved.lines[0]!.display.itemNameReason).toMatch(/multiple/);
    expect(saved.lines[0]!.display.description).toBe('Original description');
    expect(saved.header.display.employeeName).toBeNull();
    expect(saved.header.display.employeeNameReason).toMatch(/multiple/);
    let before = await snapshot();
    const unchanged = await updateSavedSaleReturnMetadata(runtime, scope(), 1, {
      version: saved.version,
      lines: [
        { identity: saved.lines[0]!.identity, changes: { description: 'Original description' } },
      ],
    });
    expect(unchanged.version).toBe(saved.version);
    expect(await snapshot()).toEqual(before);
    await sql('DELETE FROM "ITEM_MAST" WHERE tenant_id=$1', tenantId);
    await sql('DELETE FROM "EMP_MAST" WHERE tenant_id=$1 AND "EMP_CODE"=$2', tenantId, '001');
    saved = await get();
    before = await snapshot();
    expect(saved.lines[0]!.display.itemNameReason).toMatch(/not found/);
    expect(saved.header.display.employeeNameReason).toMatch(/not found/);
    expect(saved.lines[1]!.raw.ITM_REMARK).toBeNull();
    expect(saved.lines[1]!.display.description).toBe('');
    expect(await snapshot()).toEqual(before);
    await sql(
      'UPDATE "SL_DATA" SET "EMP_CODE"=NULL WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R71',
    );
    expect((await get()).header.display.employeeNameReason).toBeNull();
    await insert('EMP_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      EMP_CODE: '',
      EMP_NAME: 'Not a selected employee',
    });
    await sql(
      'UPDATE "SL_DATA" SET "EMP_CODE"=$3 WHERE tenant_id=$1 AND "CO_BOOK"=$2',
      tenantId,
      'R71',
      '',
    );
    expect((await get()).header.display).toEqual({ employeeName: null, employeeNameReason: null });
  });
});
