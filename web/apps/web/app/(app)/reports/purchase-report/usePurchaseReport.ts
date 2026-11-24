'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { ApiError, downloadPdf, get } from '../../../../lib/api';
import { todayLocal } from '../../../../lib/localDate';
import { openDocument } from '../../../../lib/openDocument';
import type { PurchaseFilters, PurchaseOptions, PurchaseResult } from './types';

/**
 * Purchase Rpt controller (desktop RP_ALL, "Purchase Rpt"). Owns the selectors, the last successful result and the
 * busy/error state, and builds the API query ONCE so the screen, Print, PDF, Excel and CSV can never disagree. A
 * stale response (the operator ran again while a request was in flight) is discarded. The grid shows what the
 * server returned: nothing is re-derived here.
 */
export interface UsePurchaseReport {
  filters: PurchaseFilters;
  setFilters: (patch: Partial<PurchaseFilters>) => void;
  options: PurchaseOptions;
  result: PurchaseResult | null;
  error: string;
  busy: boolean;
  /** The query the displayed result belongs to (pinned so exports match the screen, not pending edits). */
  ranQuery: string | null;
  run: () => Promise<void>;
  print: () => void;
  pdf: () => Promise<void>;
  excel: () => void;
  csv: () => void;
}

export const REVERSED_DATES_MESSAGE =
  'From date is after To date. Choose a date range with From on or before To.';

/** The canonical query of a run. Business scope is added by the server from the session. */
export function buildQuery(f: PurchaseFilters, sessionLcCode: string): string {
  const p = new URLSearchParams();
  p.set('mode', f.mode);
  p.set('fromDate', f.fromDate);
  p.set('toDate', f.toDate);
  // The lc box is locked outside head office (RP_ALL.cs:6660-6671): that session sends its own location. At
  // head office the box is editable and its value ('' = every location, or a branch code) travels as
  // reportLcCode, never as the session scope's lcCode, which the request-scope guard refuses to change.
  if (sessionLcCode === '00') p.set('reportLcCode', f.lcCode.trim());
  else p.set('lcCode', sessionLcCode);
  const text: Array<[string, string]> = [
    ['coBook', f.coBook],
    ['prCode', f.prCode],
    ['grCode', f.grCode],
    ['acCode', f.acCode],
    ['city', f.city],
    ['area', f.area],
    ['itemType', f.itemType],
  ];
  for (const [key, value] of text) if (value.trim()) p.set(key, value.trim());
  return p.toString();
}

export function usePurchaseReport(sessionLcCode: string): UsePurchaseReport {
  const [filters, setFiltersState] = useState<PurchaseFilters>(() => ({
    mode: 'report',
    fromDate: todayLocal(),
    toDate: todayLocal(),
    lcCode: sessionLcCode,
    coBook: '',
    prCode: '',
    grCode: '',
    acCode: '',
    city: '',
    area: '',
    itemType: '',
  }));
  const [options, setOptions] = useState<PurchaseOptions>({ cities: [], areas: [] });
  const [result, setResult] = useState<PurchaseResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const [ranQuery, setRanQuery] = useState<string | null>(null);
  const seq = useRef(0);

  useEffect(() => {
    let live = true;
    get<PurchaseOptions>('/reports/purchase-report/options')
      .then((o) => live && setOptions(o))
      .catch(() => {
        // The drop-downs stay empty; the report itself still runs.
      });
    return () => {
      live = false;
    };
  }, []);

  const setFilters = useCallback((patch: Partial<PurchaseFilters>) => {
    setFiltersState((prev) => ({ ...prev, ...patch }));
  }, []);

  const run = useCallback(async () => {
    setError('');
    if (filters.fromDate && filters.toDate && filters.fromDate > filters.toDate) {
      setResult(null);
      setRanQuery(null);
      setError(REVERSED_DATES_MESSAGE);
      return;
    }
    const query = buildQuery(filters, sessionLcCode);
    const ticket = ++seq.current;
    setBusy(true);
    try {
      const data = await get<PurchaseResult>(`/reports/purchase-report?${query}`);
      if (ticket !== seq.current) return;
      setResult(data);
      setRanQuery(query);
    } catch (e) {
      if (ticket !== seq.current) return;
      setResult(null);
      setRanQuery(null);
      setError(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      if (ticket === seq.current) setBusy(false);
    }
  }, [filters, sessionLcCode]);

  const exportPath = useCallback(
    (ext: 'pdf' | 'xlsx' | 'csv'): string | null =>
      ranQuery ? `/reports/purchase-report/export.${ext}?${ranQuery}` : null,
    [ranQuery],
  );
  const open = useCallback(
    (ext: 'pdf' | 'xlsx' | 'csv') => {
      const path = exportPath(ext);
      if (path) openDocument(`/api${path}`);
    },
    [exportPath],
  );
  const pdf = useCallback(async () => {
    const path = exportPath('pdf');
    if (path) await downloadPdf(path, `purchase-report-${result?.mode ?? filters.mode}`);
  }, [exportPath, result?.mode, filters.mode]);

  return {
    filters,
    setFilters,
    options,
    result,
    error,
    busy,
    ranQuery,
    run,
    print: () => open('pdf'),
    pdf,
    excel: () => open('xlsx'),
    csv: () => open('csv'),
  };
}
