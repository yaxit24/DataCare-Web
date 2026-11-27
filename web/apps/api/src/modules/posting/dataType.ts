import { resolveBookDataTypeTx } from '../shared/bookPolicy.js';
/** Ac_Ledr.cs:61-64,565-584; TR_SALE.cs:16105-16107. */
const BOOK_TABLES = new Set([
  'AC_DATA',
  'LEDR_AC_DATA',
  'FINE_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'BAR_DETL',
  'BAR_CAN_DETL',
]);
const LITERAL_TABLES = new Set([
  'BILL_OS_DATA',
  'COMM_DATA',
  'ITM_LOT_DETL',
  'BUL_DATA',
  'DG_GOLD_DATA',
]);
/**
 * A row whose desktop writer hard-codes DATA_TYPE carries it under this key instead of taking its book's type, e.g.
 * the sale's approval stock-back row (Ac_Stock.cs:119 writes 'A'). A symbol, so it never reaches the INSERT.
 */
export const FIXED_DATA_TYPE: unique symbol = Symbol('fixedDataType');

export async function postingDataTypeTx(
  tx: any,
  tenantId: string,
  table: string,
  row: Record<string, unknown>,
  cache?: Map<string, string>,
): Promise<string> {
  const fixed = (row as { [FIXED_DATA_TYPE]?: unknown })[FIXED_DATA_TYPE];
  if (typeof fixed === 'string') return fixed;
  if (LITERAL_TABLES.has(table)) return 'A';
  if (!BOOK_TABLES.has(table)) return String(row.DATA_TYPE ?? 'A');
  return resolveBookDataTypeTx(tx, tenantId, row, cache);
}
