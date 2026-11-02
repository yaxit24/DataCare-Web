import { withTxBudget, SNAPSHOT_READ } from '../shared/txBudget.js';
import { toIsoDate } from '@datacare/core';
import {
  AccountLedgerValidationError,
  type AccountLedgerQuery,
  type AccountLedgerResult,
  type AccountLedgerView,
  type FineType,
  type LedgerScope,
} from './accountLedgerShared.js';
import {
  ageingDataset,
  detailDataset,
  summaryDataset,
  voucherSummaryDataset,
} from './accountLedgerQueries.js';

/**
 * Account Ledger report — the desktop `RP_LEDR` form (Lite "Ledger Report" menu,
 * MDI_FORM.cs:8871-8880), read-only and tenant/RLS-scoped. This file owns the request parser and the
 * orchestrator; the pure helpers and types are in accountLedgerShared.ts and the dataset SQL in
 * accountLedgerQueries.ts, so no file passes its size budget.
 *
 * WHY A DEDICATED MODULE
 * The web previously answered `/reports/account-ledger/:acCode` with a single-account money statement
 * whose running balance used `DR_AMT - CR_AMT` (modules/accounting/accounting.ts). The desktop form is
 * far richer and uses the OPPOSITE sign. RP_LEDR is an account-SUMMARY screen first (DGV_AC), then a
 * per-voucher or per-ledger-key DRILL-DOWN (DGV_VCH / DGV_DETL), plus a debit-AGEING view (DGV_MONTH).
 * All of it reports money AND signed gold/silver fine weight. See accountLedgerShared.ts for the desktop
 * sign conventions and the per-view citations.
 */

// Re-export the shared types, errors and pure helpers so callers and the unit tests have one entry point.
export {
  AccountLedgerValidationError,
  AccountNotFoundError,
  sideOf,
  splitSigned,
  summaryIsZero,
  runningBalances,
  ageDebitsFifo,
  AGE_BUCKETS,
} from './accountLedgerShared.js';
export type {
  AccountLedgerView,
  FineType,
  LedgerScope,
  AccountLedgerQuery,
  MetalTriple,
  SummaryRow,
  DetailRow,
  AgeingRow,
  AccountLedgerResult,
} from './accountLedgerShared.js';

const ISO = /^\d{4}-\d{2}-\d{2}$/;

function requireIso(label: string, v: string | undefined): string | undefined {
  if (v == null || v === '') return undefined;
  if (!ISO.test(v)) throw new AccountLedgerValidationError(`${label} must be YYYY-MM-DD`);
  try {
    // toIsoDate rejects a non-calendar date (e.g. 2024-02-31).
    return toIsoDate(v);
  } catch {
    throw new AccountLedgerValidationError(`${label} is not a calendar date`);
  }
}

/** Parse a request into a typed query, failing closed. Business scope is never read here. */
export function parseAccountLedgerQuery(q: Record<string, unknown>): AccountLedgerQuery {
  const str = (v: unknown): string | undefined => {
    if (v == null) return undefined;
    const s = String(v).trim();
    return s === '' ? undefined : s;
  };
  const bool = (v: unknown): boolean =>
    v === true || v === 'true' || v === '1' || v === 'Y' || v === 'y';

  const rawView = (str(q.view) ?? 'summary').toLowerCase();
  if (!['summary', 'detail', 'voucher-summary', 'ageing'].includes(rawView))
    throw new AccountLedgerValidationError(
      'view must be summary, detail, voucher-summary or ageing',
    );
  const view = rawView as AccountLedgerView;

  const acCode = str(q.acCode);
  if ((view === 'detail' || view === 'voucher-summary') && !acCode)
    throw new AccountLedgerValidationError(`${view} requires acCode`);
  if (acCode && acCode.length > 8)
    throw new AccountLedgerValidationError('acCode must be at most 8 characters');

  const fromDate = requireIso('fromDate', str(q.fromDate));
  const toDate = requireIso('toDate', str(q.toDate));
  if (fromDate && toDate && fromDate > toDate)
    throw new AccountLedgerValidationError('fromDate must not be after toDate');

  const dataType = str(q.dataType);
  if (dataType && !['A', 'B', 'C'].includes(dataType.toUpperCase()))
    throw new AccountLedgerValidationError('dataType must be A, B or C');

  const rawFine = str(q.fineType);
  const fineType = rawFine ? (rawFine.toUpperCase() as FineType) : undefined;
  if (fineType && fineType !== 'G' && fineType !== 'S')
    throw new AccountLedgerValidationError('fineType must be G or S');

  return {
    view,
    acCode,
    fromDate,
    toDate,
    dataType: dataType ? dataType.toUpperCase() : undefined,
    withZero: bool(q.withZero),
    openingOnly: bool(q.openingOnly),
    accountType: str(q.accountType),
    accountGroup: str(q.accountGroup),
    khataNo: str(q.khataNo),
    refAccount: str(q.refAccount),
    city: str(q.city),
    area: str(q.area),
    state: str(q.state),
    fineType: view === 'ageing' ? (fineType ?? 'G') : fineType,
    halfMonth: bool(q.halfMonth),
  };
}

/**
 * Resolve one Account Ledger request into exactly one dataset. Every output (screen JSON, PDF, XLSX, CSV)
 * calls this, so none can drift from another. Opens one tenant-scoped snapshot read.
 */
export async function accountLedgerReport(
  prisma: any,
  s: LedgerScope,
  q: AccountLedgerQuery,
): Promise<AccountLedgerResult> {
  return withTxBudget(prisma, s.tenantId, SNAPSHOT_READ, async (tx: any) => {
    switch (q.view) {
      case 'summary':
        return summaryDataset(tx, s, q);
      case 'detail':
        return detailDataset(tx, s, q, q.acCode!);
      case 'voucher-summary':
        return voucherSummaryDataset(tx, s, q, q.acCode!);
      case 'ageing':
        return ageingDataset(tx, s, q);
      default:
        throw new AccountLedgerValidationError(`unknown view: ${q.view as string}`);
    }
  });
}
