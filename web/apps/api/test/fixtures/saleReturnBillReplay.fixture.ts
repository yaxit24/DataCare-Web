import type { PrismaClient } from '@datacare/db';
import { expect } from 'vitest';
import independent from './saleReturnBillReplay.independent.json';
import type {
  SaleReturnBillReplayPhase,
  SaleReturnBillReplayState,
} from '../../src/modules/sales/saleReturnBillReplay.js';
import { assertIsolatedTestDatabase } from '../support/isolatedDatabase.js';

export { independent };
// The source-authored vector uses a logical SILVER label; ITEM_MAST stores five characters.
// Keep the frozen vector bytes/numeric expectations intact and adapt only its physical key.
export const billStoredItemCode = (value: string) => (value === 'SILVER' ? 'SILVR' : value);
export const billSelected = { coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'R11' };
export const billVoucher = '00017';
export const billTables = [
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
  'SRNO_MAST',
  'TAG_SET',
  'CO_SET',
  'CO_SET_NEW',
  'COL_MAST',
  'BOOK_DATA',
  'YEAR_MAST',
  'ITEM_MAST',
  'EMP_MAST',
  'TAX_MAST',
  'AC_MAST',
  'CONV_MAST',
] as const;
type Owner = Pick<PrismaClient, '$executeRawUnsafe' | '$queryRawUnsafe'>;

export function assertBillTestDatabase() {
  assertIsolatedTestDatabase();
  if (new URL(process.env.DATABASE_URL!).username !== 'app_user')
    throw new Error('Bill preview must run through app_user tenant isolation.');
}
export function billInsert(owner: Owner, table: string, values: Record<string, unknown>) {
  const columns = Object.keys(values)
    .map((key) => `"${key}"`)
    .join(',');
  return owner.$executeRawUnsafe(
    `INSERT INTO "${table}" (${columns}) SELECT ${columns} FROM jsonb_populate_record(NULL::"${table}",$1::jsonb)`,
    JSON.stringify(values),
  );
}
export function billKey(tenantId: string, coBook = 'R11', voucherNo = billVoucher) {
  return {
    tenant_id: tenantId,
    CO_CODE: billSelected.coCode,
    LC_CODE: billSelected.lcCode,
    CO_YEAR: billSelected.coYear,
    CO_BOOK: coBook,
    VCH_NO: voucherNo,
  };
}
export async function cleanBillFixture(owner: Owner, tenants: string[], authentication = false) {
  const tables = authentication
    ? ['audit_log', 'auth_session', ...billTables, 'USER_SET', 'LOGIN_MAST', 'LOCT_MAST', 'CO_MAST']
    : billTables;
  for (const table of tables)
    await owner.$executeRawUnsafe(
      `DELETE FROM "${table}" WHERE tenant_id=ANY($1::text[])`,
      tenants,
    );
}
export async function snapshotBillFixture(owner: Owner, tenants: string[]) {
  const result: Record<string, unknown> = {};
  for (const table of billTables)
    result[table] = await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t)::text AS raw,t.xmin::text AS revision,t.ctid::text AS locator
       FROM "${table}" t WHERE tenant_id=ANY($1::text[]) ORDER BY to_jsonb(t)::text`,
      tenants,
    );
  return result;
}
export async function seedBillFixture(owner: Owner, tenants: string[]) {
  for (const [index, tenantId] of tenants.entries()) {
    await billInsert(owner, 'CO_SET', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LOCK_DATE: null,
      EMP_CODE_MANDATORY: 'N',
      SL_AMT_TYPE: 'N',
      LBR_ROF: 2,
      LBR_RATE_GEN: 'N',
      ALL_ROF_REMOVE: 'N',
      LBR_TYPE: 'N',
      TAX_ROF: 2,
    });
    await billInsert(owner, 'CO_SET_NEW', {
      tenant_id: tenantId,
      CO_CODE: '01',
      LBR_WITH_GHT: 'N',
    });
    await billInsert(owner, 'YEAR_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      CO_YEAR: billSelected.coYear,
      OP_DATE: '2024-04-01',
      CL_DATE: '2025-03-31',
    });
    for (const [itCode, itType, name] of [
      ['GOLD', 'G', 'Source gold'],
      ['SILVER', 'S', 'Source silver'],
    ])
      await billInsert(owner, 'ITEM_MAST', {
        tenant_id: tenantId,
        CO_CODE: '01',
        IT_CODE: billStoredItemCode(itCode!),
        IT_TYPE: itType,
        RATE_TYPE: 'N',
        IT_NAME: index ? `Foreign ${name}` : name,
      });
    await billInsert(owner, 'TAX_MAST', {
      tenant_id: tenantId,
      CO_CODE: '01',
      TAX_CODE: '10',
      SR_NO: '0',
      TAX_NAME: index ? 'Foreign tax name' : 'Current tax label',
      TAX_PRC: '99', // Saved percentage10 and manual7 remain authoritative.
    });
    for (const [code, name] of [
      ['BANK', 'Current bank label'],
      ['CARD', 'Current card label'],
      ['CUST', 'Current customer master'],
    ])
      await billInsert(owner, 'AC_MAST', {
        tenant_id: tenantId,
        CO_CODE: '01',
        AC_CODE: code,
        AC_NAME: index ? `Foreign ${name}` : name,
      });
    for (const coBook of ['R11', 'R12']) {
      await billInsert(owner, 'BOOK_DATA', {
        tenant_id: tenantId,
        CO_CODE: '01',
        LC_CODE: '01',
        CO_BOOK: coBook,
        BOOK_NAME: coBook === 'R11' ? 'Incoming Return fixture' : 'Other Return fixture',
        MAIN_BOOK: 'SALES RETURNE',
        BOOK_INOUT: 'I',
        BOOK_TBL_NAME: 'SL_DATA',
        CUR_USE: 'Y',
        DATA_TYPE: 'B', // Posting type must not be used as a ledger mode.
      });
      const key = billKey(tenantId, coBook);
      await billInsert(owner, 'SL_DATA', {
        ...independent.header,
        ...key,
        AC_NAME: index
          ? 'Foreign saved customer'
          : coBook === 'R11'
            ? independent.header.AC_NAME
            : 'Other book saved customer',
      });
      for (const row of independent.rows)
        await billInsert(owner, 'SL_DETL_RTN', {
          ...row,
          ...key,
          IT_CODE: billStoredItemCode(row.IT_CODE),
        });
    }
  }
}
export const billEvent = (column: number, editorText: string) => ({
  fieldId: `x13.primary-incoming.c${String(column).padStart(2, '0')}`,
  editorText,
});
export const billJournal = (
  dto: SaleReturnBillReplayState,
  events: Array<{ fieldId: string; editorText: string }> = [],
  row = 0,
) => ({
  replayVersion: dto.replayVersion,
  rowIdentity: dto.rowReplay.rows[row]!.rowIdentity,
  events,
});
export function assertMatrixCells(
  phase: SaleReturnBillReplayPhase,
  expected: Record<string, string>,
) {
  expect(phase.bill.matrix).toHaveLength(9);
  for (const row of phase.bill.matrix) expect(row).toHaveLength(6);
  for (const [key, value] of Object.entries(expected)) {
    const [row, column] = key.split(',').map(Number);
    expect(phase.bill.matrix[row!]?.[column!], `source matrix[${key}]`).toBe(value);
  }
}
export function assertClosingUnavailable(phase: SaleReturnBillReplayPhase) {
  expect(phase.bill.closing).toMatchObject({ status: 'unavailable', amount: null, label: null });
  expect(phase.bill.closing).toHaveProperty('reason');
}
