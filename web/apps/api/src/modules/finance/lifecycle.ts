import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import {
  deleteVoucherWriteSetTx,
  nextHiddenVoucherNoTx,
  persistedVoucherHeaderTx,
  voucherTimestamp,
} from '../vouchers/lifecycle.js';
import { assertPeriodOpen, insertRowTx } from '../posting/posting.js';
import { assertFiscalDateTx } from '../vouchers/lifecycle.js';
import { toIsoDate } from '@datacare/core';

export class FinanceLifecycleValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'FinanceLifecycleValidationError';
  }
}

export const FINANCE_DATE_OUTSIDE_YEAR_MESSAGE =
  'You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...';

/**
 * A finance voucher's date must fall inside the open financial year. The Lite desktop checks this before save in
 * TR_CASH (cash and bank receipts and payments, TR_CASH.cs:2934-2941) and TR_CONTRA (contra,
 * TR_CONTRA.cs:2680-2685). The same check also exists on later-edition TR_EMP_JV (:2834-2839),
 * TR_LEDR_ADJ (:2880-2885) and TR_CARD_REC (:3214-3219), so those writers can reuse this helper when their menus
 * are completed. Dhiran writers do not use it because their desktop forms do not carry this check.
 */
export async function assertFinanceVoucherDateTx(
  tx: any,
  scope: VoucherScope,
  date: Date,
): Promise<void> {
  try {
    await assertFiscalDateTx(tx, completeFinanceScope(scope), toIsoDate(date));
  } catch (error) {
    // Preserve the fail-closed configuration error when YEAR_MAST is missing or ambiguous. Only translate the
    // ordinary out-of-range refusal to the exact operator-facing desktop text.
    if (error instanceof Error && /is outside fiscal year/.test(error.message))
      throw new FinanceLifecycleValidationError(FINANCE_DATE_OUTSIDE_YEAR_MESSAGE);
    throw error;
  }
}

export const FINANCE_EMPLOYEE_REQUIRED_MESSAGE = 'Please Select Employee Code and Try......';

/**
 * TR_CASH's employee box (tEmpCode): with CO_SET.EMP_CODE_MANDATORY = 'Y' (DC_Main.MsEmpCodeMendetry) a blank
 * employee is refused (TR_CASH.cs:2907-2911, before the cash limit, year and lock checks); a typed code must be a
 * company employee (the box is filled from the EMP_MAST help, :3608-3623). Returns the code the row stores.
 */
export async function financeEmployeeTx(
  tx: any,
  scope: VoucherScope,
  raw: unknown,
): Promise<string> {
  const code = text(raw);
  const settings: Array<{ mandatory: unknown }> = await tx.$queryRawUnsafe(
    `SELECT "EMP_CODE_MANDATORY" mandatory FROM "CO_SET" WHERE tenant_id=$1 AND "CO_CODE"=$2 ORDER BY row_id LIMIT 1`,
    scope.tenantId,
    scope.coCode,
  );
  if (!code && text(settings[0]?.mandatory).toUpperCase() === 'Y')
    throw new FinanceLifecycleValidationError(FINANCE_EMPLOYEE_REQUIRED_MESSAGE);
  if (!code) return '';
  const found: unknown[] = await tx.$queryRawUnsafe(
    `SELECT 1 FROM "EMP_MAST" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "EMP_CODE"=$3 LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    code,
  );
  if (!found.length)
    throw new FinanceLifecycleValidationError(`Employee ${code} is not in this company`);
  return code;
}

export type CompleteFinanceScope = VoucherScope & { coYear: string; coBook: string };
export type VoucherIdentity = {
  vchNo: number;
  voucherNo: string;
  hiddenVoucherNo: string;
  mainUser: string;
  voucherDate: Date;
  voucherTime: Date;
};

export const text = (value: unknown): string => String(value ?? '').trim();
export const num = (value: unknown): number => Number(value ?? 0);

export function completeFinanceScope(scope: VoucherScope): CompleteFinanceScope {
  if (!scope.tenantId || !scope.coCode || !scope.lcCode || !scope.coYear || !scope.coBook) {
    throw new FinanceLifecycleValidationError(
      'voucher requires tenant, company, location, fiscal year, and configured book',
    );
  }
  return scope as CompleteFinanceScope;
}

export function voucherKey(scope: VoucherScope, voucherNo: string) {
  const complete = completeFinanceScope(scope);
  return {
    CO_CODE: complete.coCode,
    LC_CODE: complete.lcCode,
    CO_YEAR: complete.coYear,
    CO_BOOK: complete.coBook,
    VCH_NO: voucherNo,
  };
}

export async function configuredBookTx(tx: any, scope: VoucherScope) {
  const complete = completeFinanceScope(scope);
  const rows: Array<{
    BOOK_NAME: unknown;
    BOOK_SNAME: unknown;
    MAIN_BOOK: unknown;
    BOOK_INOUT: unknown;
    DATA_TYPE: unknown;
  }> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","DATA_TYPE" FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4
        AND coalesce(nullif(btrim("CUR_USE"::text),''),'Y') <> 'N'
      ORDER BY row_id`,
    complete.tenantId,
    complete.coCode,
    complete.lcCode,
    complete.coBook,
  );
  if (rows.length !== 1) {
    throw new FinanceLifecycleValidationError(
      `voucher book configuration is ambiguous: ${complete.coBook}`,
    );
  }
  return {
    name: text(rows[0]!.BOOK_NAME),
    shortName: text(rows[0]!.BOOK_SNAME),
    mainBook: text(rows[0]!.MAIN_BOOK),
    inout: text(rows[0]!.BOOK_INOUT),
    dataType: text(rows[0]!.DATA_TYPE) || 'A',
  };
}

/**
 * CONTRA_DATA is shared by Contra (`CurBookHelp('CONTRA')`, MDI_FORM.cs:8100-8111), Fine JV
 * (`CurBookHelp('FINE JV')`, MDI_FORM.cs:8360-8365) and the web Journal. The desktop menu can only
 * open a book of its own family, so a route of one family must refuse another family's book before it
 * reads, rewrites or deletes that family's vouchers.
 */
export function requireBookFamily(
  book: { mainBook: string },
  mainBook: string,
  label: string,
): void {
  if (book.mainBook.trim().toUpperCase() !== mainBook)
    throw new FinanceLifecycleValidationError(
      `${label} requires BOOK_DATA.MAIN_BOOK='${mainBook}' for the configured book`,
    );
}

/**
 * Finance creates must validate their voucher date before allocating either the visible or hidden voucher identity.
 * The allocator takes transaction-scoped advisory locks, so rejecting first avoids an unnecessary lock wait as well as
 * making the desktop order explicit. Edit paths keep their persisted identity and call the guard before they read and
 * lock the saved voucher, so the year refusal comes before the lock-date refusal, as in TR_CASH and TR_CONTRA.
 */
export async function createFinanceIdentityTx(
  tx: any,
  scope: VoucherScope,
  requestedDate: Date,
  mainUser?: string,
): Promise<VoucherIdentity> {
  await assertFinanceVoucherDateTx(tx, scope, requestedDate);
  return createIdentityTx(tx, scope, requestedDate, mainUser);
}

export async function createIdentityTx(
  tx: any,
  scope: VoucherScope,
  requestedDate: Date,
  mainUser?: string,
): Promise<VoucherIdentity> {
  const complete = completeFinanceScope(scope);
  const vchNo = await nextVoucherNoTx(tx, complete);
  const hiddenVoucherNo = await nextHiddenVoucherNoTx(tx, complete);
  return {
    vchNo,
    voucherNo: formatVoucherNo(vchNo),
    hiddenVoucherNo,
    mainUser: text(mainUser),
    voucherDate: requestedDate,
    voucherTime: voucherTimestamp(requestedDate),
  };
}

export async function editIdentityTx(
  tx: any,
  options: {
    table: string;
    scope: VoucherScope;
    requestedVoucherNo: number | string;
    requestedDate: Date;
    checkRequestedDate?: boolean;
    extraColumns?: readonly string[];
  },
): Promise<{ identity: VoucherIdentity; persisted: Record<string, unknown> }> {
  const complete = completeFinanceScope(options.scope);
  const voucherNo = formatVoucherNo(options.requestedVoucherNo);
  let persisted: Record<string, unknown>;
  try {
    persisted = await persistedVoucherHeaderTx(tx, {
      table: options.table,
      scope: complete,
      voucherNo,
      extraColumns: options.extraColumns ?? [],
    });
  } catch (error) {
    if (error instanceof Error && error.name === 'PersistedVoucherNotFoundError') {
      throw new FinanceLifecycleValidationError(`voucher not found: ${voucherNo}`);
    }
    if (error instanceof Error && error.name === 'PersistedVoucherAmbiguousError') {
      throw new FinanceLifecycleValidationError(`voucher is ambiguous: ${voucherNo}`);
    }
    throw error;
  }
  // Desktop checks the displayed date. Web hardening checks BOTH persisted and requested dates and
  // fails closed before deleting any row, preventing a date move out of a locked period.
  const dates =
    options.checkRequestedDate === false
      ? [persisted.VCH_DATE]
      : [persisted.VCH_DATE, options.requestedDate];
  for (const date of dates) {
    await assertPeriodOpen(tx, options.scope.tenantId, {
      ledger: { table: 'AC_DATA', lines: [{ CO_CODE: options.scope.coCode, VCH_DATE: date }] },
    });
  }
  const hiddenVoucherNo = formatVoucherNo(text(persisted.HD_VCH_NO));
  return {
    persisted,
    identity: {
      vchNo: Number(voucherNo),
      voucherNo,
      hiddenVoucherNo,
      mainUser: text(persisted.MAIN_USER),
      voucherDate: options.requestedDate,
      voucherTime: voucherTimestamp(options.requestedDate, persisted.VCH_CLOCK),
    },
  };
}

export async function replaceWriteSetTx(
  tx: any,
  scope: VoucherScope,
  voucherNo: string,
  hiddenVoucherNo: string,
  tables: readonly string[],
): Promise<void> {
  const complete = completeFinanceScope(scope);
  // Desktop save-on-edit deletes/rebuilds its write set and never inserts DELETE_DATA.
  await deleteVoucherWriteSetTx(tx, {
    tables,
    key: { scope: complete, voucherNo },
    tempBook: { voucherNo: hiddenVoucherNo },
  });
}

export async function insertHiddenIdentityTx(
  tx: any,
  scope: VoucherScope,
  identity: VoucherIdentity,
  configuredBookName: string,
): Promise<void> {
  await insertRowTx(tx, 'TEMP_BOOK_DATA', scope.tenantId, {
    CO_CODE: scope.coCode,
    LC_CODE: scope.lcCode,
    CO_BOOK: scope.coBook,
    VCH_NO: identity.hiddenVoucherNo,
    BOOK_NAME: configuredBookName,
  });
}

export async function insertDesktopDeleteAuditTx(
  tx: any,
  options: {
    scope: VoucherScope;
    configuredBook: { name: string; shortName: string };
    header: Record<string, unknown>;
    rows: Array<{
      srNo: number;
      valueDr?: number;
      valueCr?: number;
      fineType?: string;
      fineDr?: number;
      fineCr?: number;
      description?: string;
      acCode?: unknown;
      acName?: unknown;
    }>;
    deleteUser?: string;
  },
): Promise<void> {
  const deletedAt = new Date();
  const h = options.header;
  for (const row of options.rows) {
    await insertRowTx(tx, 'DELETE_DATA', options.scope.tenantId, {
      ...voucherKey(options.scope, text(h.VCH_NO)),
      SR_NO: row.srNo,
      VCH_DATE: h.VCH_DATE,
      DELETE_DATE: deletedAt,
      VCH_TYPE: options.configuredBook.shortName,
      VCH_TIME: h.VCH_TIME,
      DELETE_TIME: deletedAt,
      BOOK_NAME: options.configuredBook.name,
      AC_CODE: row.acCode ?? h.AC_CODE ?? null,
      AC_NAME: row.acName ?? h.AC_NAME ?? null,
      VCH_VAL_DR: row.valueDr ?? 0,
      VCH_VAL_CR: row.valueCr ?? 0,
      FINE_TYPE: row.fineType || 'A',
      VCH_FINE_DR: row.fineDr ?? 0,
      VCH_FINE_CR: row.fineCr ?? 0,
      HD_VCH_NO: h.HD_VCH_NO,
      MAIN_USER: h.MAIN_USER,
      DELETE_USER: options.deleteUser ?? 'system',
      VCH_DESC: text(row.description).slice(0, 150),
    });
  }
}
