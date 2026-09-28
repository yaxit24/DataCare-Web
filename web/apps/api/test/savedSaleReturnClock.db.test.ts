/** These cases exercise the actual saved JSONB reader, rather than
 * Prisma Date or SQL timestamp::text output.
 */
import { PrismaClient } from '@prisma/client';
import { withTenant } from '@datacare/db';
import { projectSavedSaleReturnClock } from '@datacare/core';
import { afterAll, beforeAll, beforeEach, describe, expect, it } from 'vitest';
import { readSavedSaleReturnIncomingTx } from '../src/modules/sales/savedSaleReturn.js';

const run = process.env.RUN_DB_INTEGRITY_TESTS === '1' ? describe : describe.skip;
const tenantId = 'r13-return-clock';
const otherTenant = 'r13-clock-other';
const tenants = [tenantId, otherTenant];
const scope = { tenantId, coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R13' };
const voucherNo = '00001';
const tables = [
  'AC_DATA', 'SL_DATA', 'SL_DETL_RTN', 'SL_DETL', 'SL_IDTL', 'BAR_DATA',
  'BAR_DETL', 'BAR_IDTL', 'MAIN_STOCK', 'TAX_DATA', 'BILL_OS_DATA', 'ROJ_MEL_DATA',
  'DM_DATA', 'REMARK_DATA', 'TEMP_BOOK_DATA', 'SRNO_MAST', 'TAG_SET', 'CO_SET',
  'CO_SET_NEW', 'COL_MAST', 'BOOK_DATA', 'YEAR_MAST', 'ITEM_MAST', 'EMP_MAST',
  'TAX_MAST', 'AC_MAST', 'CONV_MAST',
] as const;

run('saved Return clock projection from real PostgreSQL JSONB observations', () => {
  let owner: PrismaClient;
  let runtime: PrismaClient;
  const sql = (query: string, ...values: unknown[]) => owner.$executeRawUnsafe(query, ...values);
  const insert = async (table: 'CO_SET' | 'BOOK_DATA' | 'SL_DATA', values: Record<string, unknown>) => {
    const columns = Object.keys(values).map((key) => `"${key}"`).join(',');
    await sql(
      `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
      JSON.stringify(values),
    );
  };
  const cleanup = async () => {
    for (const table of tables)
      await sql(`DELETE FROM "${table}" WHERE tenant_id=ANY($1::text[])`, tenants);
  };
  // One owner query observes both fixture tenants, complete raw rows and physical
  // revisions. No timestamp is decoded to a JavaScript Date in this snapshot.
  const snapshot = () => owner.$queryRawUnsafe<Array<Record<string, unknown>>>(
    tables.map((table) =>
      `SELECT '${table}' AS "tableName",to_jsonb(t)::text AS raw,t.xmin::text AS revision,t.ctid::text AS locator FROM "${table}" t WHERE tenant_id=ANY($1::text[])`,
    ).join(' UNION ALL ') + ' ORDER BY "tableName",raw,revision,locator',
    tenants,
  );
  const replaceClock = (date: string | null, time: string | null) => sql(
    `UPDATE "SL_DATA" SET "VCH_DATE"=$2::date,"VCH_TIME"=$3::timestamp WHERE tenant_id=$1 AND "CO_BOOK"='R13' AND "VCH_NO"='00001'`,
    tenantId, date, time,
  );
  const load = (dateStyle = 'ISO, MDY', timeZone = 'UTC', no = voucherNo) =>
    withTenant(runtime, tenantId, async (tx) => {
      await tx.$executeRawUnsafe(
        `SELECT set_config('DateStyle',$1,true),set_config('TimeZone',$2,true)`,
        dateStyle, timeZone,
      );
      const settings = await tx.$queryRawUnsafe<Array<{
        dateStyle: string; timeZone: string; dateType: string; timeType: string;
      }>>(
        `SELECT current_setting('DateStyle') AS "dateStyle",current_setting('TimeZone') AS "timeZone",pg_typeof("VCH_DATE")::text AS "dateType",pg_typeof("VCH_TIME")::text AS "timeType" FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='R13' AND "VCH_NO"='00001'`,
        tenantId,
      );
      const saved = await readSavedSaleReturnIncomingTx(tx, scope, no);
      return { saved, settings: settings[0]! };
    }, { isolationLevel: 'RepeatableRead' });
  const adapterInput = (saved: Awaited<ReturnType<typeof load>>['saved']) => ({
    raw: { VCH_DATE: saved.dto.header.raw.VCH_DATE, VCH_TIME: saved.dto.header.raw.VCH_TIME },
    provenance: {
      documentIdentity: JSON.stringify({ ...scope, voucherNo }),
      documentVersion: saved.dto.version,
    },
  });
  const ready = (value: ReturnType<typeof projectSavedSaleReturnClock>) => {
    expect(value.status).toBe('ready');
    if (value.status !== 'ready') throw new Error('Expected a ready canonical saved clock.');
    return value.observation;
  };

  beforeAll(() => {
    for (const value of [process.env.DATABASE_URL, process.env.MIGRATE_DATABASE_URL])
      if (!value || new URL(value).port !== '55433')
        throw new Error('Only disposable parity database55433 is allowed.');
    if (new URL(process.env.DATABASE_URL!).username !== 'app_user')
      throw new Error('Restricted app_user runtime required.');
    owner = new PrismaClient({ datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } } });
    runtime = new PrismaClient();
  });
  beforeEach(async () => {
    await cleanup();
    for (const tenant of tenants) {
      await insert('CO_SET', { tenant_id: tenant, CO_CODE: '01', LOCK_DATE: null });
      await insert('BOOK_DATA', {
        tenant_id: tenant, CO_CODE: '01', LC_CODE: '01', CO_BOOK: 'R13',
        BOOK_NAME: 'Saved clock fixture', MAIN_BOOK: 'SALES RETURNE',
        BOOK_SNAME: 'SRTN', BOOK_INOUT: 'I', BOOK_TBL_NAME: 'SL_DATA', CUR_USE: 'Y',
      });
      await insert('SL_DATA', {
        tenant_id: tenant, CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024-2025',
        CO_BOOK: 'R13', VCH_NO: voucherNo, AC_CODE: 'CUST', EMP_CODE: '',
        VCH_DATE: '2024-07-10', VCH_TIME: '2024-07-09T12:34:56.123456',
        VCH_DESC: tenant === tenantId ? null : 'Unrelated tenant clock sentinel',
        USER_UPDATE: 'Y', USER_DELETE: 'N',
      });
    }
  });
  afterAll(async () => {
    if (owner) { await cleanup(); await owner.$disconnect(); }
    if (runtime) await runtime.$disconnect();
  });

  it.each<{ dateStyle: string; timeZone: string }>([
    { dateStyle: 'ISO, MDY', timeZone: 'UTC' },
    { dateStyle: 'SQL, DMY', timeZone: 'Asia/Kolkata' },
    { dateStyle: 'German, DMY', timeZone: 'America/New_York' },
  ])('preserves actual JSONB date/time under $dateStyle and $timeZone', async ({ dateStyle, timeZone }) => {
    const before = await snapshot();
    const observed = await load(dateStyle, timeZone);
    expect(observed.settings.dateStyle.replaceAll(' ', '').toLowerCase()).toBe(dateStyle.replaceAll(' ', '').toLowerCase());
    expect(observed.settings.timeZone).toBe(timeZone);
    expect(observed.settings.dateType).toBe('date');
    expect(observed.settings.timeType).toBe('timestamp without time zone');
    const input = adapterInput(observed.saved);
    expect(input.raw).toEqual({ VCH_DATE: '2024-07-10', VCH_TIME: '2024-07-09T12:34:56.123456' });
    expect(observed.saved.dto.header.raw.VCH_DESC).toBeNull();
    const priorInput = JSON.stringify(input);
    const clock = ready(projectSavedSaleReturnClock(input));
    expect(clock.cutoffLocalSecond).toBe('2024-07-10 12:34:56');
    expect(clock.raw).toEqual(input.raw);
    expect(clock.provenance).toEqual(input.provenance);
    expect(JSON.stringify(input)).toBe(priorInput);
    expect(Object.isFrozen(input.raw)).toBe(false);
    expect(await snapshot()).toEqual(before);
  });

  it('uses the saved voucher day and truncates six near-midnight digits without rollover', async () => {
    await replaceClock('2024-03-01', '2024-02-29T23:59:59.999999');
    const before = await snapshot();
    const { saved } = await load('SQL, DMY', 'Pacific/Auckland');
    const input = adapterInput(saved);
    expect(input.raw).toEqual({ VCH_DATE: '2024-03-01', VCH_TIME: '2024-02-29T23:59:59.999999' });
    expect(ready(projectSavedSaleReturnClock(input)).cutoffLocalSecond).toBe('2024-03-01 23:59:59');
    expect(await snapshot()).toEqual(before);
  });

  it('qualifies zero and one-to-six actual JSONB fraction digits without inventing padded raw text', async () => {
    const cases = [
      ['', ''], ['.1', '.1'], ['.12', '.12'], ['.123', '.123'],
      ['.1234', '.1234'], ['.12345', '.12345'], ['.123456', '.123456'],
      ['.120000', '.12'],
    ] as const;
    for (const [stored, expected] of cases) {
      await replaceClock('2024-07-10', `2024-07-09T00:00:00${stored}`);
      const before = await snapshot();
      const { saved } = await load();
      const input = adapterInput(saved);
      expect(input.raw.VCH_TIME).toBe(`2024-07-09T00:00:00${expected}`);
      expect(ready(projectSavedSaleReturnClock(input)).cutoffLocalSecond).toBe('2024-07-10 00:00:00');
      expect(await snapshot()).toEqual(before);
    }
  });

  it('keeps SQL NULL distinct and yields no derived cutoff for either absent saved value', async () => {
    const cases = [
      { date: null, time: '2024-07-09T12:34:56', field: 'VCH_DATE' },
      { date: '2024-07-10', time: null, field: 'VCH_TIME' },
    ] as const;
    for (const row of cases) {
      await replaceClock(row.date, row.time);
      const before = await snapshot();
      const { saved } = await load();
      const input = adapterInput(saved);
      expect(Object.hasOwn(input.raw, row.field)).toBe(true);
      expect(input.raw[row.field]).toBeNull();
      const result = projectSavedSaleReturnClock(input);
      expect(result.status).toBe('unsupported');
      expect(result.observation?.raw).toEqual(input.raw);
      expect(result.observation?.cutoffLocalSecond).toBeNull();
      expect(result.diagnostics).toEqual(expect.arrayContaining([
        expect.objectContaining({ code: 'null-saved-column', sourceField: row.field }),
      ]));
      expect(await snapshot()).toEqual(before);
    }
  });

  it('contains a deliberately incomplete adapter projection without claiming the SQL reader omitted a column', async () => {
    const before = await snapshot();
    const { saved } = await load();
    const observed = adapterInput(saved);
    expect(Object.hasOwn(observed.raw, 'VCH_TIME')).toBe(true);
    expect(observed.raw.VCH_TIME).toBe('2024-07-09T12:34:56.123456');
    // Explicit adapter-boundary omission: PostgreSQL's real table row still has
    // VCH_TIME. This tests missing-vs-NULL containment, not invented schema loss.
    const incomplete = { raw: { VCH_DATE: observed.raw.VCH_DATE }, provenance: observed.provenance };
    const result = projectSavedSaleReturnClock(incomplete);
    expect(result.status).toBe('unsupported');
    expect(result.observation?.raw).toEqual(incomplete.raw);
    expect(result.observation?.cutoffLocalSecond).toBeNull();
    expect(result.diagnostics).toEqual(expect.arrayContaining([
      expect.objectContaining({ code: 'missing-saved-column', sourceField: 'VCH_TIME' }),
    ]));
    expect(saved.dto.header.raw.VCH_TIME).toBe(observed.raw.VCH_TIME);
    expect(await snapshot()).toEqual(before);
  });

  it('does not invent a clock or call the adapter when the saved document itself is absent', async () => {
    const before = await snapshot();
    await expect(load('ISO, MDY', 'UTC', '99999')).rejects.toMatchObject({
      statusCode: 404, code: 'not-found',
    });
    expect(await snapshot()).toEqual(before);
  });
});
