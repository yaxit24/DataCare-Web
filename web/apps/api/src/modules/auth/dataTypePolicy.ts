/** Owner decision 2026-11-25; desktop DC_Main.cs:1491-1502. */
export function validateDataTypeAccess(
  allowed: unknown,
  defaultType: unknown,
): { allowed: string; defaultType: string } {
  if (
    typeof allowed !== 'string' ||
    !['A', 'B', 'C', 'AB', 'AC', 'BC', 'ABC'].includes(allowed) ||
    typeof defaultType !== 'string' ||
    !/^[ABC]$/.test(defaultType) ||
    !allowed.includes(defaultType)
  ) {
    throw Object.assign(new Error('invalid-data-type-access'), { statusCode: 400 });
  }
  return { allowed, defaultType };
}
/** MS_ACCT.cs:7861-7895, TR_ITM_OPBL.cs:1272. */
export function openingDataType(type: unknown): string {
  return type === 'B' ? 'B' : 'A';
}
export function sessionReportQuery(
  query: Record<string, unknown>,
  type: string,
): Record<string, unknown> {
  // The client never chooses the data type: any supplied selector is replaced; non-All sessions always carry theirs.
  const out = { ...query };
  if ('dataType' in out || type !== 'C') out.dataType = type;
  if ('orderDataType' in out) out.orderDataType = type;
  return out;
}
/**
 * A row's data type as SQL: blank or NULL reads as 'A' (MS_BOOK.cs:2524 stores blank as 'A'; BtmSchm.cs:2765 groups
 * blank with 'A'). `column` is a trusted, quoted column reference, never user input.
 */
export function rowDataTypeSql(column = '"DATA_TYPE"'): string {
  return `COALESCE(NULLIF(btrim(${column}),''),'A')`;
}
