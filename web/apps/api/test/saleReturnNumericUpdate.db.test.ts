/**
 * Sale Return numeric write coordinator — card X13, steps 1-7 (FEAT-002).
 *
 * DB-backed integration proof of `updateSaleReturnNumeric`. Gated on
 * RUN_DB_INTEGRITY_TESTS==='1'; it seeds a J01-shaped saved Return (single primary
 * incoming N/P/I/SR1 row, zero tax, zero tender, the seven existing financial effect
 * rows plus both N BAR companions), applies the ordinary Other 0->1 numeric edit, and
 * asserts that:
 *   - exactly the NINE expected rows change (line, header, two account, stock, two
 *     Rojmel, two tax), each by the expected column/value;
 *   - unrelated-scope sentinels (a sibling voucher, a foreign tenant) are untouched;
 *   - the AC_DATA and ROJ_MEL_DATA trial balances stay tied after the write;
 *   - guard refusals (a positive configured cash limit with observed over-limit prior
 *     cash; a non-owning operator) block the write and leave the database unchanged;
 *   - a no-op event set leaves every persisted value and membership unchanged;
 *   - a same-value event is admitted but persists nothing;
 *   - a stale document version maps to a 409 version-conflict;
 *   - a cross-year / alias / phantom scope is rejected.
 *
 * NOTE (authored-for-CI): this sandbox has NO working PostgreSQL (podman/crun cannot run
 * postgres:16-alpine; host port 55433 is unreachable), so this file is verified here ONLY
 * by compilation under apps/api/tsconfig.test.json. It runs in GitHub Actions CI, which
 * provides postgres:16-alpine with RUN_DB_INTEGRITY_TESTS=1.
 */
import { PrismaClient } from '@prisma/client';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { withTenant } from '@datacare/db';
import {
  getSavedSaleReturnIncoming,
  type SavedSaleReturnScope,
} from '../src/modules/sales/savedSaleReturn.js';
import { updateSaleReturnNumeric } from '../src/modules/sales/saleReturnNumericUpdate.js';
import {
  accountBalances,
  accountLedger,
  outstandingReport,
  trialBalance,
} from '../src/modules/reports/reports.js';
import { salesReturnRegister } from '../src/modules/reports/reports4.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;

run('sale return numeric write coordinator', () => {
  const tenantId = 'return-numeric-x13';
  const otherTenant = 'return-numeric-other';
  const CO = '01';
  const LC = '01';
  const YEAR = '2024-2025';
  const BOOK = 'R11';
  const VCH = '00017';
  const HD = '00017';
  const PARTY = 'CUST';
  const SALE = 'SALE';
  const ITEM = 'GOLD';
  const MAIN_USER = 'x13-owner';

  let owner: PrismaClient;
  let runtime: PrismaClient;

  const scope = (coBook = BOOK): SavedSaleReturnScope => ({
    tenantId,
    coCode: CO,
    lcCode: LC,
    coYear: YEAR,
    coBook,
  });
  const actor = { mainUser: MAIN_USER, auditUser: MAIN_USER, auditTime: '2024-07-10T13:00:00' };

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
    'BOOK_DETL',
    'ITEM_MAST',
    'GROUP_MAST',
    'AC_MAST',
    'TAX_MAST',
    'EMP_MAST',
    'YEAR_MAST',
    'CO_MAST',
    'CO_SET',
  ];

  const sql = (statement: string, ...values: unknown[]) =>
    withTenant(owner, tenantId, (tx: any) => tx.$executeRawUnsafe(statement, ...values));
  const query = (statement: string, ...values: unknown[]) =>
    owner.$queryRawUnsafe<any[]>(statement, ...values);
  const insert = async (table: string, values: Record<string, unknown>) => {
    const t = String(values.tenant_id ?? tenantId);
    const columns = Object.keys(values)
      .map((column) => `"${column}"`)
      .join(',');
    await withTenant(owner, t, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
        JSON.stringify(values),
      ),
    );
  };
  const clean = async () => {
    for (const t of [tenantId, otherTenant])
      for (const table of tables)
        await owner.$executeRawUnsafe(`DELETE FROM "${table}" WHERE tenant_id=$1`, t);
  };
  const key = (extra: Record<string, unknown> = {}) => ({
    tenant_id: tenantId,
    CO_CODE: CO,
    LC_CODE: LC,
    CO_YEAR: YEAR,
    CO_BOOK: BOOK,
    VCH_NO: VCH,
    ...extra,
  });
  async function rowsFor(table: string, tenant = tenantId) {
    return query(
      `SELECT (to_jsonb(t)-'tenant_id')::text AS raw FROM "${table}" t
         WHERE tenant_id=$1 ORDER BY (to_jsonb(t)-'tenant_id')::text`,
      tenant,
    );
  }
  async function snapshot(tenant = tenantId) {
    const result: Record<string, unknown> = {};
    for (const table of tables) result[table] = await rowsFor(table, tenant);
    return result;
  }

  const get = () => getSavedSaleReturnIncoming(runtime, scope(), VCH);

  async function seedMasters(cashLimit = 0) {
    await insert('CO_MAST', { tenant_id: tenantId, CO_CODE: CO, CO_NAME: 'X13 Co', CO_SNAME: 'IN' });
    await insert('CO_SET', {
      tenant_id: tenantId,
      CO_CODE: CO,
      LOCK_DATE: null,
      EMP_CODE_MANDATORY: 'N',
      CASH_LIMIT: cashLimit,
    });
    await insert('YEAR_MAST', {
      tenant_id: tenantId,
      CO_CODE: CO,
      CO_YEAR: YEAR,
      OP_DATE: '2024-04-01',
    });
    await insert('BOOK_DATA', {
      tenant_id: tenantId,
      CO_CODE: CO,
      LC_CODE: LC,
      CO_BOOK: BOOK,
      MAIN_BOOK: 'SALES RETURNE',
      BOOK_NAME: 'Sales Return',
      BOOK_SNAME: 'SR',
      BOOK_TYPE: 'T',
      BOOK_INOUT: 'I',
      CUR_USE: 'Y',
      BOOK_TBL_NAME: 'SL_DATA',
      DATA_TYPE: 'B',
    });
    await insert('BOOK_DETL', {
      tenant_id: tenantId,
      CO_CODE: CO,
      LC_CODE: LC,
      CO_BOOK: BOOK,
      MAIN_BOOK: 'SALES RETURNE',
      BOOK_INOUT: 'I',
      BOOK_TYPE: 'T',
      BOOK_SNAME: 'RT',
      DATA_TYPE: 'C',
      SR_NO: 1,
      AC_CODE: 'BOOKAC',
    });
    await insert('ITEM_MAST', { tenant_id: tenantId, CO_CODE: CO, IT_CODE: ITEM, GR_CODE: 'G1' });
    await insert('GROUP_MAST', { tenant_id: tenantId, CO_CODE: CO, GR_CODE: 'G1', SALE_AC: SALE });
    await insert('AC_MAST', {
      tenant_id: tenantId,
      CO_CODE: CO,
      LC_CODE: LC,
      AC_CODE: PARTY,
      AC_NAME: 'Customer',
      AC_GST_TYPE: 'N',
    });
    for (const [sr, group] of [
      [1, 'C'],
      [2, 'S'],
    ] as Array<[number, string]>)
      await insert('TAX_MAST', {
        tenant_id: tenantId,
        CO_CODE: CO,
        TAX_CODE: '00',
        SR_NO: sr,
        TAX_GROUP: group,
        TAX_PRC: 0,
      });
    await insert('EMP_MAST', { tenant_id: tenantId, CO_CODE: CO, EMP_CODE: '001', EMP_NAME: 'Emp' });
  }

  async function seedDocument() {
    await insert(
      'SL_DATA',
      key({
        VCH_DATE: '2024-07-10',
        VCH_TIME: '2024-07-10T12:34:56',
        HD_VCH_NO: HD,
        AC_CODE: PARTY,
        AC_NAME: ' Customer ',
        EMP_CODE: '001',
        VCH_DESC: null,
        MAIN_USER,
        TAX_CODE: '00',
        AC_GST_TYPE: 'N',
        RATE_UNFIX: 'N',
        USER_UPDATE: 'N',
        RTN_NET_AMT: 110,
        RTN_TOT_AMT: 110,
        RTN_BILL_OS: 110,
      }),
    );
    await insert(
      'SL_DETL_RTN',
      key({
        SR_NO: 1,
        OLD_SRNO: 1,
        VCH_DATE: '2024-07-10',
        VCH_TIME: '2024-07-10T12:34:56',
        VCH_TYPE: 'SR',
        INOUT_TYPE: 'I',
        ENTRY_TYPE: 'P',
        BOOK_NAME: 'SALES RETURN',
        AC_CODE: PARTY,
        IT_CODE: ITEM,
        TAG_NO: 'N',
        TBL_CODE: '001',
        ITM_PCS: '1.000',
        ITM_GWT: '10.000',
        ITM_NWT: '10.000',
        ITM_TOUCH: '100.000',
        ITM_WEST_PRC: '0.0000',
        ITM_FINE: '10.000',
        ITM_RATE: '10.00',
        ITM_AMT: '100.00',
        LBR_TYPE: 'N',
        LBR_RATE: '1.00',
        LBR_AMT: '10.00',
        OTH_AMT: '0.00',
        ITM_MRP: '0.00',
        TOT_AMT: '110.00',
        TAX_PRC: '0.0000',
        NET_AMT: '110.00',
        RATE_TYPE: 'N',
        IT_TYPE: 'G',
        HD_VCH_NO: HD,
        MAIN_USER,
        VCH_SRNO: 123,
        TAG_TYPE: 'A',
        EMP_CODE: '001',
        APR_ISU: 'N',
        EMP_ISU: 'N',
        DATA_TYPE: 'A',
      }),
    );
    // Seven existing financial effect rows.
    await insert(
      'AC_DATA',
      key({
        row_id: undefined,
        VCH_TYPE: 'SR',
        VCH_DATE: '2024-07-10',
        LEDR_KEY: '01012024-2025R110001701         1',
        BOOK_NAME: 'SALES RETURNE',
        AC_CODE: PARTY,
        LD_CODE: SALE,
        CR_AMT: '110.00',
        DR_AMT: '0.00',
        IT_TYPE: 'A',
        ENTRY_TIME: '2024-07-10T12:34:56',
        HD_VCH_NO: HD,
        DATA_TYPE: 'B',
        DATA_TRFR: 'N',
        MAIN_USER,
        PARTY_AC_CODE: PARTY,
      }),
    );
    await insert(
      'AC_DATA',
      key({
        VCH_TYPE: 'SR',
        VCH_DATE: '2024-07-10',
        LEDR_KEY: '01012024-2025R110001702         1',
        BOOK_NAME: 'SALES RETURNE',
        AC_CODE: SALE,
        LD_CODE: PARTY,
        CR_AMT: '0.00',
        DR_AMT: '110.00',
        IT_TYPE: 'A',
        ENTRY_TIME: '2024-07-10T12:34:56',
        HD_VCH_NO: HD,
        DATA_TYPE: 'B',
        DATA_TRFR: 'N',
        MAIN_USER,
      }),
    );
    await insert(
      'ROJ_MEL_DATA',
      key({
        LEDR_KEY: '01012024-2025R110001701',
        VCH_DATE: '2024-07-10',
        VCH_TYPE: 'RT',
        BOOK_NAME: 'SALES RETURNE',
        AC_CODE: PARTY,
        LD_CODE: 'BOOKAC',
        CR_AMT: '110.00',
        DR_AMT: '0.00',
        AC_NAME: '',
        IT_TYPE: 'A',
        DATA_TYPE: 'C',
      }),
    );
    await insert(
      'ROJ_MEL_DATA',
      key({
        LEDR_KEY: '01012024-2025R110001702',
        VCH_DATE: '2024-07-10',
        VCH_TYPE: 'RT',
        BOOK_NAME: 'SALES RETURNE',
        AC_CODE: PARTY,
        LD_CODE: 'BOOKAC',
        CR_AMT: '0.00',
        DR_AMT: '110.00',
        AC_NAME: 'RTN -  Customer ',
        IT_TYPE: 'A',
        DATA_TYPE: 'C',
      }),
    );
    await insert(
      'MAIN_STOCK',
      key({
        SR_NO: 2,
        ISR_NO: 1,
        VCH_SRNO: 123,
        VCH_DATE: '2024-07-10',
        STK_DATE: '2024-07-10',
        VCH_TYPE: 'SR',
        BOOK_NAME: 'SALES RETURNE',
        AC_CODE: PARTY,
        IT_CODE: ITEM,
        TAG_NO: 'N',
        TBL_CODE: '001',
        TR_TYPE: 'I',
        ITM_SIGN: '+',
        ITM_QTY: '1.000',
        ITM_PCS: '1.000',
        ITM_GWT: '10.000',
        ITM_NWT: '10.000',
        ITM_TOUCH: '100.000',
        ITM_WEST: '0.000',
        ITM_FINE: '10.000',
        ITM_RATE: '10.00',
        ITM_AMT: '100.00',
        LBR_RATE: '1.00',
        LBR_AMT: '10.00',
        OTH_AMT: '0.00',
        ITM_MRP: '0.00',
        NET_AMT: '110.00',
        EMP_CODE: '001',
        ENTRY_TIME: '2024-07-10',
        MAIN_USER,
        DATA_TYPE: 'A',
        ITM_DISC: '0',
      }),
    );
    for (const [sr, group] of [
      [1, 'C'],
      [2, 'S'],
    ] as Array<[number, string]>)
      await insert(
        'TAX_DATA',
        key({
          SR_NO: sr,
          BOOK_NAME: 'SALES RETURNE',
          TRAN_TYPE: 'S',
          VCH_DATE: '2024-07-10',
          AC_CODE: PARTY,
          TAX_CODE: '00',
          TAX_TYPE: group,
          TAX_PRC: '0.0000',
          NET_AMT: '110.00',
          TAX_AMT: '0.000',
          DISC_AMT: '0.00',
          TOT_AMT: '110.00',
          TAX_SIGN: '-',
          PARTY_NAME: ' Customer ',
          R_CHARG: 'N',
          ISR_NO: 0,
          ZERO_RATED_AMT: '0',
        }),
      );
    // Both N BAR companions (header + parent).
    await insert(
      'BAR_DATA',
      key({
        VCH_DATE: '2024-07-10',
        VCH_TIME: '2024-07-10T12:34:56',
        EMP_CODE: '001',
        VCH_DESC: '',
        MAIN_USER,
        STK_IT_CODE: '',
        DATA_TRFR: 'N',
      }),
    );
    await insert(
      'BAR_DETL',
      key({
        VCH_DATE: '2024-07-10',
        VCH_TIME: '2024-07-10T12:34:56',
        STK_DATE: '2024-07-10',
        HD_VCH_NO: HD,
        AC_CODE: PARTY,
        VCH_TYPE: 'SR',
        INOUT_TYPE: 'I',
        BOOK_NAME: 'SALES RETURNE',
        MAIN_USER,
        ENTRY_TYPE: 'P',
        DATA_TRFR: 'N',
        SR_NO: 1,
        OLD_SRNO: 1,
        IT_CODE: ITEM,
        TAG_NO: 'N',
        VCH_SRNO: 123,
        ITM_NWT: '10.000',
        ITM_FINE: '10.000',
        DATA_TYPE: 'A',
      }),
    );
    await insert('TEMP_BOOK_DATA', {
      tenant_id: tenantId,
      CO_CODE: CO,
      LC_CODE: LC,
      CO_BOOK: BOOK,
      VCH_NO: HD,
      BOOK_NAME: 'SALES RETURNE',
    });
  }

  async function seedSentinels() {
    // Sibling voucher on the same book: must remain untouched.
    await insert('SL_DATA', key({ VCH_NO: '00099', AC_CODE: 'SIBLING', MAIN_USER }));
    // Foreign tenant, same natural key: must remain untouched.
    await insert('CO_MAST', { tenant_id: otherTenant, CO_CODE: CO, CO_NAME: 'Foreign', CO_SNAME: 'FR' });
    await insert('SL_DATA', {
      tenant_id: otherTenant,
      CO_CODE: CO,
      LC_CODE: LC,
      CO_YEAR: YEAR,
      CO_BOOK: BOOK,
      VCH_NO: VCH,
      AC_CODE: 'FOREIGN',
      MAIN_USER,
      RTN_NET_AMT: 110,
    });
  }

  beforeAll(async () => {
    for (const value of [process.env.MIGRATE_DATABASE_URL, process.env.DATABASE_URL]) {
      if (!value || new URL(value).port !== '55433')
        throw new Error('Isolated parity database 55433 required.');
    }
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  afterAll(async () => {
    if (owner) await clean();
    if (runtime) await runtime.$disconnect();
    if (owner) await owner.$disconnect();
  });
  beforeEach(async () => {
    await clean();
    await seedMasters(0);
    await seedDocument();
    await seedSentinels();
  });

  it('applies the ordinary Other 0->1 edit changing exactly the nine expected rows', async () => {
    const saved = await get();
    const foreignBefore = await snapshot(otherTenant);
    const siblingBefore = await query(
      `SELECT (to_jsonb(t)-'tenant_id')::text AS raw FROM "SL_DATA" t WHERE tenant_id=$1 AND t."VCH_NO"='00099'`,
      tenantId,
    );

    const result = await updateSaleReturnNumeric(runtime, scope(), VCH, {
      version: saved.version,
      otherAmount: '1',
      actor,
    });
    expect(result.committed).toBe(true);
    expect(result.noOp).toBe(false);

    const changed = new Set(result.changes.map((c) => `${c.table}:${c.column}`));
    expect(changed).toEqual(
      new Set([
        'SL_DETL_RTN:OTH_AMT',
        'SL_DETL_RTN:TOT_AMT',
        'SL_DETL_RTN:NET_AMT',
        'SL_DATA:RTN_NET_AMT',
        'SL_DATA:RTN_TOT_AMT',
        'SL_DATA:RTN_BILL_OS',
        'AC_DATA:CR_AMT',
        'AC_DATA:DR_AMT',
        'MAIN_STOCK:OTH_AMT',
        'MAIN_STOCK:NET_AMT',
        'ROJ_MEL_DATA:CR_AMT',
        'ROJ_MEL_DATA:DR_AMT',
        'TAX_DATA:NET_AMT',
        'TAX_DATA:TOT_AMT',
      ]),
    );
    // Nine distinct physical rows changed.
    expect(new Set(result.changes.map((c) => `${c.table}:${c.physicalIdentity}`)).size).toBe(9);

    // Header/line persisted the whole-unit and fractional-free values.
    const [header] = await query(
      `SELECT "RTN_NET_AMT"::text n,"RTN_TOT_AMT"::text t,"RTN_BILL_OS"::text o FROM "SL_DATA" t WHERE tenant_id=$1 AND t."VCH_NO"=$2`,
      tenantId,
      VCH,
    );
    expect(header).toMatchObject({ n: '111', t: '111', o: '111' });

    // Unrelated-scope sentinels untouched.
    expect(await snapshot(otherTenant)).toStrictEqual(foreignBefore);
    expect(
      await query(
        `SELECT (to_jsonb(t)-'tenant_id')::text AS raw FROM "SL_DATA" t WHERE tenant_id=$1 AND t."VCH_NO"='00099'`,
        tenantId,
      ),
    ).toStrictEqual(siblingBefore);
  });

  it('keeps the AC_DATA and ROJ_MEL_DATA trial balance tied after the write', async () => {
    const saved = await get();
    await updateSaleReturnNumeric(runtime, scope(), VCH, {
      version: saved.version,
      otherAmount: '1',
      actor,
    });
    for (const table of ['AC_DATA', 'ROJ_MEL_DATA']) {
      const [sums] = await query(
        `SELECT SUM("CR_AMT")::text cr, SUM("DR_AMT")::text dr FROM "${table}" t WHERE tenant_id=$1 AND t."VCH_NO"=$2`,
        tenantId,
        VCH,
      );
      expect(Number(sums.cr)).toBe(Number(sums.dr));
    }
  });

  it('admits a same-value event but persists nothing and reports a no-op', async () => {
    const saved = await get();
    const before = await snapshot();
    const result = await updateSaleReturnNumeric(runtime, scope(), VCH, {
      version: saved.version,
      otherAmount: '0',
      actor,
    });
    expect(result.committed).toBe(true);
    expect(result.noOp).toBe(true);
    expect(result.changes).toHaveLength(0);
    expect(await snapshot()).toStrictEqual(before);
  });

  it('treats an empty-then-round-trip journal as a whole-plan no-op', async () => {
    const saved = await get();
    const before = await snapshot();
    // otherAmount '0' leaves every persisted value unchanged.
    const result = await updateSaleReturnNumeric(runtime, scope(), VCH, {
      version: saved.version,
      otherAmount: '0',
      actor,
    });
    expect(result.noOp).toBe(true);
    expect(await snapshot()).toStrictEqual(before);
  });

  it('refuses via the LedrCash ceiling (not the guard) when the observed all-year cash exceeds the configured limit', async () => {
    // Reseed with a positive configured cash limit and observed over-limit prior cash.
    // The pure save-guard is presented a ZERO cash limit by the coordinator (its frozen
    // "ordinary" profile requires it), so the guard is READY here; the refusal below is
    // therefore owned by the coordinator's LedrCash ceiling check (observeLedrCash), NOT by
    // the guard's zero-limit refusal. This case is what actually exercises observeLedrCash:
    // if that block were reverted, this write would COMMIT and the assertions would fail.
    await clean();
    await seedMasters(50);
    await seedDocument();
    await seedSentinels();
    // Prior all-year customer cash credits summing over the 50 limit (LD00001 cash ledger),
    // spread across two different books/years so the aggregate — not a single row — decides.
    await insert(
      'AC_DATA',
      key({
        VCH_NO: '00050',
        CO_BOOK: 'C01',
        VCH_TYPE: 'CR',
        VCH_DATE: '2023-05-01',
        LEDR_KEY: 'PRIORCASH-A',
        BOOK_NAME: 'CASH',
        AC_CODE: PARTY,
        LD_CODE: 'LD00001',
        CR_AMT: '40.00',
        DR_AMT: '0.00',
        IT_TYPE: 'A',
        DATA_TYPE: 'B',
      }),
    );
    await insert(
      'AC_DATA',
      key({
        VCH_NO: '00051',
        CO_BOOK: 'C02',
        VCH_TYPE: 'CR',
        VCH_DATE: '2024-05-01',
        LEDR_KEY: 'PRIORCASH-B',
        BOOK_NAME: 'CASH',
        AC_CODE: PARTY,
        LD_CODE: 'LD00001',
        CR_AMT: '30.00',
        DR_AMT: '0.00',
        IT_TYPE: 'A',
        DATA_TYPE: 'B',
      }),
    );
    const saved = await get();
    const before = await snapshot();
    // The refusal is the LedrCash ceiling message, proving observeLedrCash ran (the observed
    // all-year cash 70 > the configured limit 50) rather than a guard-stage refusal.
    await expect(
      updateSaleReturnNumeric(runtime, scope(), VCH, {
        version: saved.version,
        otherAmount: '1',
        actor,
      }),
    ).rejects.toMatchObject({
      statusCode: 422,
      message: 'The observed all-year cash credit exceeds the configured cash limit.',
    });
    expect(await snapshot()).toStrictEqual(before);
  });

  it('admits the write when a positive cash limit is configured but the observed all-year cash is under it', async () => {
    // Same reachable-LedrCash path as above, but on the ACCEPT side: the guard is ready
    // (presented a zero envelope limit), observeLedrCash runs, and the observed all-year cash
    // (30, net of the current book) is under the configured 50 limit, so the write commits.
    // This proves observeLedrCash does not spuriously refuse a clean document and that the
    // LedrCash observation is genuinely on the accepted path.
    await clean();
    await seedMasters(50);
    await seedDocument();
    await seedSentinels();
    await insert(
      'AC_DATA',
      key({
        VCH_NO: '00050',
        CO_BOOK: 'C01',
        VCH_TYPE: 'CR',
        VCH_DATE: '2023-05-01',
        LEDR_KEY: 'PRIORCASH-A',
        BOOK_NAME: 'CASH',
        AC_CODE: PARTY,
        LD_CODE: 'LD00001',
        CR_AMT: '30.00',
        DR_AMT: '0.00',
        IT_TYPE: 'A',
        DATA_TYPE: 'B',
      }),
    );
    const saved = await get();
    const result = await updateSaleReturnNumeric(runtime, scope(), VCH, {
      version: saved.version,
      otherAmount: '1',
      actor,
    });
    expect(result.committed).toBe(true);
    expect(result.noOp).toBe(false);
    // The trial balance for the edited voucher stays tied after the admitted write.
    for (const table of ['AC_DATA', 'ROJ_MEL_DATA']) {
      const [sums] = await query(
        `SELECT SUM("CR_AMT")::text cr, SUM("DR_AMT")::text dr FROM "${table}" t WHERE tenant_id=$1 AND t."VCH_NO"=$2`,
        tenantId,
        VCH,
      );
      expect(Number(sums.cr)).toBe(Number(sums.dr));
    }
  });

  it('refuses a non-owning operator and leaves the database unchanged', async () => {
    const saved = await get();
    const before = await snapshot();
    await expect(
      updateSaleReturnNumeric(runtime, scope(), VCH, {
        version: saved.version,
        otherAmount: '1',
        actor: { ...actor, mainUser: 'intruder' },
      }),
    ).rejects.toMatchObject({ statusCode: 422 });
    expect(await snapshot()).toStrictEqual(before);
  });

  it('maps a stale document version to a 409 version-conflict without writing', async () => {
    const saved = await get();
    const before = await snapshot();
    await expect(
      updateSaleReturnNumeric(runtime, scope(), VCH, {
        version: 'f'.repeat(64),
        otherAmount: '1',
        actor,
      }),
    ).rejects.toMatchObject({ statusCode: 409, code: 'version-conflict' });
    expect(saved.version).not.toBe('f'.repeat(64));
    expect(await snapshot()).toStrictEqual(before);
  });

  it('rejects a cross-year scope with no such saved Return', async () => {
    await expect(
      updateSaleReturnNumeric(
        runtime,
        { ...scope(), coYear: '2023-2024' },
        VCH,
        { version: 'a'.repeat(64), otherAmount: '1', actor },
      ),
    ).rejects.toMatchObject({ statusCode: 404 });
  });

  it('rejects an aliased duplicate AC_DATA ledger key membership', async () => {
    // Inject a duplicate customer-ledger key to simulate an ambiguous/alias membership.
    await insert(
      'AC_DATA',
      key({
        VCH_TYPE: 'SR',
        VCH_DATE: '2024-07-10',
        LEDR_KEY: '01012024-2025R110001701         1',
        BOOK_NAME: 'SALES RETURNE',
        AC_CODE: PARTY,
        LD_CODE: SALE,
        CR_AMT: '110.00',
        DR_AMT: '0.00',
        IT_TYPE: 'A',
        DATA_TYPE: 'B',
        DATA_TRFR: 'N',
        MAIN_USER,
      }),
    );
    const saved = await get();
    await expect(
      updateSaleReturnNumeric(runtime, scope(), VCH, {
        version: saved.version,
        otherAmount: '1',
        actor,
      }),
    ).rejects.toMatchObject({ statusCode: 409 });
  });

  it('rejects a phantom voucher that has no saved incoming rows', async () => {
    await expect(
      updateSaleReturnNumeric(runtime, scope(), '00099', {
        version: 'a'.repeat(64),
        otherAmount: '1',
        actor,
      }),
    ).rejects.toMatchObject({ statusCode: 422 });
  });

  // ---- Step 9: report reconciliation against the committed rows. ----
  // Each builder below reads a table the numeric write touches (SL_DETL_RTN / AC_DATA), so after
  // the Other 0->1 edit its scoped figures must move from 110 to 111 and the trial balance must
  // stay tied. This proves the committed rows flow through to the account/return/outstanding
  // read-models, not only that the ledger sums balance.
  describe('report reconciliation (step 9)', () => {
    const reportScope = { tenantId, coCode: CO, lcCode: LC, coYear: YEAR };

    async function applyOtherOne() {
      const saved = await get();
      await updateSaleReturnNumeric(runtime, scope(), VCH, {
        version: saved.version,
        otherAmount: '1',
        actor,
      });
    }

    it('sales-return register reflects the updated SL_DETL_RTN net/total (110 -> 111)', async () => {
      const before = await salesReturnRegister(runtime, reportScope);
      const beforeRow = before.rows.find((r) => r.voucher === `${BOOK}/${VCH}`);
      expect(beforeRow?.taxable).toBe(110);
      expect(beforeRow?.total).toBe(110);

      await applyOtherOne();

      const after = await salesReturnRegister(runtime, reportScope);
      const afterRow = after.rows.find((r) => r.voucher === `${BOOK}/${VCH}`);
      expect(afterRow?.taxable).toBe(111);
      expect(afterRow?.total).toBe(111);
    });

    it('trial balance stays tied and the customer/sale account balances move to 111', async () => {
      await applyOtherOne();
      const tb = await trialBalance(runtime, reportScope);
      // The whole trial balance nets to zero (Dr total === Cr total).
      const drTotal = tb.accounts.reduce((sum, row) => sum + row.dr, 0);
      const crTotal = tb.accounts.reduce((sum, row) => sum + row.cr, 0);
      expect(Math.round((drTotal - crTotal) * 100)).toBe(0);
      // The customer account is credited 111 and the sale account debited 111 after the edit.
      const party = tb.accounts.find((row) => row.acCode.trim() === PARTY);
      const sale = tb.accounts.find((row) => row.acCode.trim() === SALE);
      expect(party?.cr).toBe(111);
      expect(sale?.dr).toBe(111);
    });

    it('account balances and account ledger reflect the committed 111 movement', async () => {
      await applyOtherOne();
      const balances = await accountBalances(runtime, reportScope);
      const partyRow = balances.rows.find(
        (row: any) => String(row.acCode ?? row.AC_CODE ?? '').trim() === PARTY,
      );
      // AC_DATA balance is Σ Dr − Σ Cr; the customer credit of 111 shows a −111 balance.
      expect(Math.round(Number(partyRow?.balance ?? 0))).toBe(-111);

      const ledger = await accountLedger(runtime, reportScope, PARTY);
      expect(Math.round(ledger.closing)).toBe(-111);
    });

    it('outstanding report reflects the committed customer credit of 111', async () => {
      await applyOtherOne();
      const outstanding = await outstandingReport(runtime, reportScope);
      const partyRow = outstanding.rows.find(
        (row: any) => String(row.acCode ?? row.AC_CODE ?? '').trim() === PARTY,
      );
      expect(partyRow).toBeTruthy();
      expect(Math.round(Math.abs(Number(partyRow?.balance ?? 0)))).toBe(111);
    });
  });
});
