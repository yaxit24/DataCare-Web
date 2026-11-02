'use client';
import { useCallback, useRef, useState } from 'react';
import { get, downloadPdf, ApiError } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';
import type { AccountLedgerResult, AccountLedgerView, LedgerFilters } from './types';

/**
 * Account Ledger controller (desktop RP_LEDR). Owns the filters, the last successful result, busy/error
 * state, and builds the API query ONCE so the screen, Print, Excel and CSV can never disagree. A stale
 * response (the operator changed the filters while a request was in flight) is discarded.
 */
export interface UseAccountLedger {
  filters: LedgerFilters;
  setFilters: (patch: Partial<LedgerFilters>) => void;
  result: AccountLedgerResult | null;
  error: string;
  busy: boolean;
  message: string;
  /** The view the displayed result belongs to (pinned so exports match the screen, not pending edits). */
  ranQuery: string | null;
  run: (overrides?: Partial<LedgerFilters>) => Promise<void>;
  openVoucherDetail: (acCode: string) => Promise<void>;
  print: () => void;
  excel: () => void;
  csv: () => void;
  pdf: () => Promise<void>;
}

const DEFAULTS: LedgerFilters = {
  view: 'summary',
  acCode: '',
  fromDate: '',
  toDate: '',
  withZero: false,
  fineType: 'G',
};

/** Build the canonical query string from filters. Business scope is added by the server from the session. */
export function buildQuery(f: LedgerFilters): string {
  const p = new URLSearchParams();
  p.set('view', f.view);
  if (f.acCode.trim()) p.set('acCode', f.acCode.trim());
  if (f.fromDate) p.set('fromDate', f.fromDate);
  if (f.toDate) p.set('toDate', f.toDate);
  if (f.withZero) p.set('withZero', 'true');
  if (f.view === 'ageing') p.set('fineType', f.fineType);
  return p.toString();
}

/** A view that needs an account before it can run (RP_LEDR detail/voucher drill-down). */
function needsAccount(view: AccountLedgerView): boolean {
  return view === 'detail' || view === 'voucher-summary';
}

export function useAccountLedger(): UseAccountLedger {
  const [filters, setFiltersState] = useState<LedgerFilters>(DEFAULTS);
  const [result, setResult] = useState<AccountLedgerResult | null>(null);
  const [error, setError] = useState('');
  const [message, setMessage] = useState('');
  const [busy, setBusy] = useState(false);
  const [ranQuery, setRanQuery] = useState<string | null>(null);
  const seq = useRef(0);

  const setFilters = useCallback((patch: Partial<LedgerFilters>) => {
    setFiltersState((prev) => ({ ...prev, ...patch }));
  }, []);

  const run = useCallback(
    async (overrides?: Partial<LedgerFilters>) => {
      const f = { ...filters, ...overrides };
      if (overrides) setFiltersState(f);
      setError('');
      setMessage('');
      if (needsAccount(f.view) && !f.acCode.trim()) {
        setResult(null);
        setRanQuery(null);
        setError('Select an account for this view.');
        return;
      }
      const query = buildQuery(f);
      const ticket = ++seq.current;
      setBusy(true);
      try {
        const data = await get<AccountLedgerResult>(`/reports/account-ledger?${query}`);
        if (ticket !== seq.current) return; // a newer request superseded this one
        setResult(data);
        setRanQuery(query);
        if (data.rows.length === 0) setMessage('No ledger entries for the selected filters.');
      } catch (e) {
        if (ticket !== seq.current) return;
        setResult(null);
        setRanQuery(null);
        setError(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
      } finally {
        if (ticket === seq.current) setBusy(false);
      }
    },
    [filters],
  );

  // Double-click / Enter on a summary or voucher row drills into that account's detail (RP_LEDR DGV_AC
  // double-click -> DGV_DETL).
  const openVoucherDetail = useCallback(
    async (acCode: string) => {
      await run({ view: 'detail', acCode });
    },
    [run],
  );

  const exportPath = useCallback(
    (ext: 'xlsx' | 'csv' | 'pdf'): string | null => {
      if (!ranQuery) return null;
      return `/reports/account-ledger/export.${ext}?${ranQuery}`;
    },
    [ranQuery],
  );

  const print = useCallback(() => {
    const path = exportPath('pdf');
    if (path) openDocument(`/api${path}`);
  }, [exportPath]);

  const excel = useCallback(() => {
    const path = exportPath('xlsx');
    if (path) openDocument(`/api${path}`);
  }, [exportPath]);

  const csv = useCallback(() => {
    const path = exportPath('csv');
    if (path) openDocument(`/api${path}`);
  }, [exportPath]);

  const pdf = useCallback(async () => {
    const path = exportPath('pdf');
    if (path) await downloadPdf(path, `account-ledger-${filters.view}`);
  }, [exportPath, filters.view]);

  return {
    filters,
    setFilters,
    result,
    error,
    busy,
    message,
    ranQuery,
    run,
    openVoucherDetail,
    print,
    excel,
    csv,
    pdf,
  };
}
