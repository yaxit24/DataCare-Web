/**
 * The session data type filter of a report (owner decision 2026-11-25; PR #292 review round 3, finding 4).
 *
 * The desktop appends `AND DATA_TYPE = '<MsDataType>'` to every report query unless the type is 'C' (All):
 * e.g. DC_Main.cs:1471, 1851; Ac_Final.cs:151-182 (trial balance, P&L, balance sheet); RP_ROJMEL.cs:3048 (day book);
 * RP_CASH_BANK.cs:2123-2131; RP_OS.cs:3810-3816; RP_TAX.cs:1941-1947 and RP_ALL.cs:7653-7659 (on BOOK_DATA.DATA_TYPE).
 *
 * Deviation (documented, prevents data loss between types): a blank or NULL DATA_TYPE is read as 'A', as the posting
 * stamps and the desktop's own blank -> 'A' rule do (MS_BOOK.cs:2524; BtmSchm.cs:2765), so legacy rows written before
 * the column was stamped stay visible to the A session instead of vanishing from every typed session.
 *
 * Only the literal 'A' and 'B' produce a predicate, and they are inlined from a whitelist (never user text); any other
 * value (C, undefined) means no filter.
 */
export function reportDataType(type: unknown): 'A' | 'B' | undefined {
  return type === 'A' || type === 'B' ? type : undefined;
}

/** ` AND coalesce(nullif(btrim(<column>),''),'A')='<type>'`, or '' for All. `column` is a trusted SQL expression. */
export function dataTypeSql(type: unknown, column = '"DATA_TYPE"'): string {
  const t = reportDataType(type);
  return t ? ` AND coalesce(nullif(btrim(${column}),''),'A')='${t}'` : '';
}

/**
 * For tables without their own DATA_TYPE (SL_DATA, PR_DATA, TAX_DATA): keep a row when its book's BOOK_DATA.DATA_TYPE
 * is the session type, as the desktop's Crystal formulas do ({BOOK_DATA.DATA_TYPE}, RP_ALL.cs:7653-7659, 7919-7925;
 * RP_TAX.cs:1941-1947). The book row of the row's location wins over a company-wide ('00'/NULL) one; a voucher whose
 * book has no BOOK_DATA row, or a blank type, is read as 'A' (the bookDataType.ts rule). `alias` is a trusted alias.
 */
export function bookDataTypeSql(type: unknown, alias: string): string {
  const t = reportDataType(type);
  if (!t) return '';
  // A blank or NULL LC_CODE is company-wide, like '00' (BOOK_TYPE_SQL and resolveBookDataTypeTx in the same rule).
  return ` AND coalesce((SELECT nullif(btrim(bt."DATA_TYPE"),'') FROM "BOOK_DATA" bt
      WHERE bt.tenant_id=${alias}.tenant_id AND bt."CO_CODE"=${alias}."CO_CODE" AND bt."CO_BOOK"=${alias}."CO_BOOK"
        AND (bt."LC_CODE"=${alias}."LC_CODE" OR bt."LC_CODE"='00' OR bt."LC_CODE" IS NULL OR btrim(bt."LC_CODE")='')
      ORDER BY CASE WHEN bt."LC_CODE"=${alias}."LC_CODE" THEN 0 ELSE 1 END, bt.row_id LIMIT 1),'A')='${t}'`;
}
