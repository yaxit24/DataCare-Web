import { round, toIsoDate } from '@datacare/core';
import { assertBalanced, type PostInput } from '../posting/posting.js';
import { configuredBookTx, num, requireBookFamily, text } from './lifecycle.js';
import { contraPostInput, contraRows } from './contra.js';
import { fineJvBookTx, fineJvPostInput } from './fineJv.js';

/**
 * Re-derivation of the postings of one saved Contra or Fine JV voucher, for Data Refresh > Account
 * (check-and-repair, docs/handbook/web/data-refresh.md).
 *
 * The desktop's AcRefresh deletes every AC_DATA and ROJ_MEL_DATA row and rebuilds them from the vouchers' own rows
 * (MS_UPDATE.cs:2401-2669): for both families Contra_Ledr (Ac_Ledr.cs:840-848) and Contra_Rojmel (Ac_Rojmel.cs:336-344)
 * read CONTRA_DATA row by row. The web keeps that source: the stored CONTRA_DATA rows are passed unchanged to the
 * same pure builders the writers use (contraPostInput, fineJvPostInput), so the expected postings are exactly what a
 * save of those rows would write. Nothing here writes, allocates a number or reads the grid back through the form.
 */
export class AccountRefreshDeriveError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'AccountRefreshDeriveError';
  }
}

/**
 * A derived posting. With `unverifiedReason` it is not a repair target but an explanation: when the stored postings
 * are not today's derivation, the voucher is reported `unverified` with that reason instead of being re-posted.
 */
export type RefreshCandidate = PostInput & { unverifiedReason?: string };

export interface RefreshVoucherScope {
  tenantId: string;
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
}

type StoredRow = Record<string, unknown>;

/** The stored CONTRA_DATA rows of one voucher, dates as text so the wall clock survives the round trip. */
async function storedContraRowsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<StoredRow[]> {
  const rows: StoredRow[] = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","LDR_TYPE","CRDR_TYPE","AC_CODE","AC_NAME","LD_CODE","DR_AMT","CR_AMT","DR_FINE","CR_FINE",
            "IT_TYPE","IT_DESC","VCH_DATE"::text AS "VCH_DATE","VCH_TIME"::text AS "VCH_TIME","HD_VCH_NO",
            "MAIN_USER","EMP_CODE"
       FROM "CONTRA_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_YEAR"=$4
        AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
    scope.tenantId,
    scope.coCode,
    scope.lcCode,
    scope.coYear,
    scope.coBook,
    voucherNo,
  );
  if (!rows.length)
    throw new AccountRefreshDeriveError(`voucher ${voucherNo} has no CONTRA_DATA rows`);
  if (rows.some((row) => !text(row.VCH_DATE)))
    throw new AccountRefreshDeriveError(`voucher ${voucherNo} has a row without VCH_DATE`);
  return rows;
}

/**
 * The stored VCH_TIME exactly as text. Passed on unchanged, it is cast back to `timestamp` by the database, so the
 * expected ENTRY_TIME equals the stored wall clock whatever the server's time zone (a JS Date would be serialised
 * from its UTC parts and shift by the zone offset).
 */
function wallClock(value: unknown, date: Date): Date | string {
  const raw = text(value);
  return raw || date;
}

const keyOf = (scope: RefreshVoucherScope, voucherNo: string) => ({
  CO_CODE: scope.coCode,
  LC_CODE: scope.lcCode,
  CO_YEAR: scope.coYear,
  CO_BOOK: scope.coBook,
  VCH_NO: voucherNo,
});

/** The posting a Contra save would write for the voucher's stored CONTRA_DATA rows (contra.ts contraPostInput). */
export async function deriveContraPostingsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<PostInput> {
  const book = await configuredBookTx(tx, scope);
  requireBookFamily(book, 'CONTRA', 'contra');
  const stored = await storedContraRowsTx(tx, scope, voucherNo);
  const head = stored[0]!;
  const vchDate = new Date(toIsoDate(head.VCH_DATE));
  // The rows exactly as contraRows shapes them, taken from storage instead of the grid (Contra_Ledr reads them so).
  const rows = stored.map((row) => ({
    SR_NO: num(row.SR_NO),
    LDR_TYPE: text(row.LDR_TYPE),
    CRDR_TYPE: (text(row.CRDR_TYPE).toUpperCase() === 'CR' ? 'CR' : 'DR') as 'DR' | 'CR',
    AC_CODE: text(row.AC_CODE),
    LD_CODE: text(row.LD_CODE),
    AC_NAME: (row.AC_NAME ?? null) as string | null,
    DR_AMT: num(row.DR_AMT),
    CR_AMT: num(row.CR_AMT),
    IT_DESC: (row.IT_DESC ?? null) as string | null,
  })) as ReturnType<typeof contraRows>;
  const posting = contraPostInput(rows, {
    key: keyOf(scope, voucherNo),
    book,
    vchDate,
    empCode: text(head.EMP_CODE),
    voucherTime: wallClock(head.VCH_TIME, vchDate),
    hiddenVoucherNo: String(head.HD_VCH_NO ?? ''),
    mainUser: String(head.MAIN_USER ?? ''),
  });
  // A voucher whose rows do not pair (the one-row shape of an early web writer) has no balanced posting to restore.
  try {
    assertBalanced(posting.ledger.lines);
  } catch {
    throw new AccountRefreshDeriveError(
      `voucher ${voucherNo}: its CONTRA_DATA rows do not give a balanced ledger`,
    );
  }
  return posting;
}

/** The posting a Fine JV save would write for the voucher's stored CONTRA_DATA rows (fineJv.ts fineJvPostInput). */
export async function deriveFineJvPostingsTx(
  tx: any,
  scope: RefreshVoucherScope,
  voucherNo: string,
): Promise<PostInput> {
  const book = await fineJvBookTx(tx, scope);
  const stored = await storedContraRowsTx(tx, scope, voucherNo);
  const head = stored[0]!;
  const voucherDate = new Date(toIsoDate(head.VCH_DATE));
  const voucherTime = wallClock(head.VCH_TIME, voucherDate);
  const metal = text(head.IT_TYPE).toUpperCase();
  if (metal !== 'G' && metal !== 'S')
    throw new AccountRefreshDeriveError(`voucher ${voucherNo}: IT_TYPE is not G or S`);
  // Fine legs carry no money, so the ledger balance proves nothing: the fines themselves must pair (TR_CONTRA.cs:2692,
  // one metal per voucher). A voucher that lost a row is reported, never "repaired" by deleting a good leg.
  const fine = (column: 'CR_FINE' | 'DR_FINE') =>
    round(
      stored.reduce((sum, row) => sum + num(row[column]), 0),
      3,
    );
  if (
    stored.length < 2 ||
    fine('CR_FINE') !== fine('DR_FINE') ||
    stored.some((row) => text(row.IT_TYPE).toUpperCase() !== metal)
  )
    throw new AccountRefreshDeriveError(
      `voucher ${voucherNo}: its CONTRA_DATA fines do not pair (Cr fine and Dr fine differ, one row, or mixed metals)`,
    );
  const rows = stored.map((row) => ({
    ...row,
    SR_NO: num(row.SR_NO),
    DR_AMT: num(row.DR_AMT),
    CR_AMT: num(row.CR_AMT),
    DR_FINE: num(row.DR_FINE),
    CR_FINE: num(row.CR_FINE),
    VCH_DATE: voucherDate,
    VCH_TIME: voucherTime,
  }));
  return fineJvPostInput(rows, {
    key: keyOf(scope, voucherNo),
    book,
    metal,
    voucherDate,
    voucherTime,
    hiddenVoucherNo: String(head.HD_VCH_NO ?? ''),
    mainUser: String(head.MAIN_USER ?? ''),
  });
}
