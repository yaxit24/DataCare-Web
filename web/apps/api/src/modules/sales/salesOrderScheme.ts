import { round } from '@datacare/core';
import { resolveBookSlotAccountTx } from '../shared/postingAccounts.js';
import { SaleValidationError } from './sales.js';

/**
 * G206 (scheme tender) on the Sales Order, following the desktop source (owner decision, WP-03).
 *
 * - The Lite and Silver editions let the operator type the Scheme Amt cell, MSG2_TOTAL[8,3]
 *   (`TR_SALE_ORD.cs:11257-11267`, `MsSoftType` 'L' or 'S'). It is stored as SL_ORD_DATA.SCHM_AMT (`:9142`) and joins
 *   the advance MSG2_TOTAL[9,3] (`:11368`), so ADV_AMT includes it.
 * - Order_Rojmel writes type 05 for it (`Ac_Rojmel.cs:19`): AC_CODE '00079', LD_CODE the party, CR 0, DR SCHM_AMT,
 *   AC_NAME 'MADJ - ' + the party name, the advance row's other columns, key head + '05' with no line number, guarded
 *   by `SCHM_AMT <> 0`. The save calls it unconditionally (`TR_SALE_ORD.cs:9561-9563`).
 * - 00079 is the desktop's SCHEME BONUS A/C, slot 1 of its member-adjust books (`MS_UPDATE.cs:27378`); in the real
 *   data it is book 076 MEMB ADJUST's slot-1 account (Schm_Adj_RojMel names `B.AC_CODE` on its bonus rows,
 *   `Ac_Rojmel.cs:462`). The web never writes the literal: it resolves the MEMB ADJUST book's BOOK_DETL slot 1.
 * - Order_Ledr has no scheme leg (`Ac_Ledr.cs:28-61`), so the ledger is unchanged.
 * - The other editions open a MEMB ADJUST voucher from the cell instead (`:11269-11287`); that path is not built here.
 */

/** DC_Main.CurBookHelp's text when no book of the main book exists (`DC_Main.cs:1508`). */
export const NO_MEMB_ADJUST_BOOK = 'Please Creat Book From MEMB ADJUST....';

export const MEMB_ADJUST_MAIN_BOOK = 'MEMB ADJUST';

/** The request's Scheme Amt: a non-negative amount in paise, 0 when absent. */
export function orderSchemeOf(value: unknown): number {
  const n = value == null || value === '' ? 0 : Number(value);
  if (!Number.isFinite(n) || n < 0)
    throw new SaleValidationError('schemeAmount must be a non-negative number');
  return round(n, 2);
}

/**
 * The account Order_Rojmel type 05 debits: the MEMB ADJUST book's BOOK_DETL slot 1, in the writer's transaction.
 * No book refuses with the desktop text; two books, or a missing or blank slot, fail closed.
 */
export async function resolveSchemeAccountTx(
  tx: any,
  scope: { tenantId: string; coCode: string; lcCode: string },
): Promise<string> {
  const books: Array<{ book: string }> = await tx.$queryRawUnsafe(
    `SELECT btrim("CO_BOOK"::text) AS book FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND upper(btrim("MAIN_BOOK"::text))=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY "CO_BOOK"`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    MEMB_ADJUST_MAIN_BOOK,
  );
  if (!books.length) throw new SaleValidationError(NO_MEMB_ADJUST_BOOK);
  if (books.length > 1)
    throw new SaleValidationError(
      `MEMB ADJUST book configuration is ambiguous: ${books.map((b) => b.book).join(', ')}`,
    );
  return resolveBookSlotAccountTx(
    tx,
    { ...scope, coBook: books[0]!.book },
    'advance-settlement',
    1,
  );
}

/** Order_Rojmel type 05 beside the advance row (type 01), whose columns it shares. */
export function withSchemeRojmel<T extends Record<string, unknown>>(
  rows: T[],
  partyAc: string,
  partyName: string,
  scheme: number,
  schemeAc: string,
): T[] {
  if (!scheme) return rows;
  const advance = rows.find((row) => /^.{21}01$/.test(String(row.LEDR_KEY ?? '')));
  // ADV_AMT includes the scheme, so a scheme always has its advance row.
  if (!advance) throw new SaleValidationError('A scheme amount needs its advance row');
  return [
    ...rows,
    {
      ...advance,
      LEDR_KEY: `${String(advance.LEDR_KEY).slice(0, -2)}05`,
      AC_CODE: schemeAc,
      LD_CODE: partyAc,
      CR_AMT: 0,
      DR_AMT: scheme,
      AC_NAME: `MADJ - ${partyName}`.slice(0, 75),
    },
  ];
}
