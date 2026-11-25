'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { ApiError, get, getDownload } from '../../../../lib/api';
import type { HuidFilters, HuidResult, HuidView } from './types';

/**
 * HuId Report controller (desktop RP_HUID). Owns the filters, the last successful result and the export
 * path, and builds the API query ONCE so the screen, Print and Excel can never disagree (the
 * account-ledger pattern). A stale response (the operator changed the filters while a request was in
 * flight) is discarded. Totals are the server's own sums; nothing is summed in the browser.
 */
export interface UseHuidReport {
  filters: HuidFilters;
  setFilters: (patch: Partial<HuidFilters>) => void;
  result: HuidResult | null;
  busy: boolean;
  error: string;
  /** A quiet status line (an empty result), never an alert: the desktop shows no message for one. */
  status: string;
  run: (view: HuidView, overrides?: Partial<HuidFilters>) => Promise<void>;
  /** Re-run the shown view with a new search text (the desktop filters the loaded rows). */
  searchAgain: (search: string) => void;
  print: () => void;
  excel: () => void;
  cancel: () => void;
}

/** The desktop message when the print right is missing (RP_HUID.cs:1361). */
export const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';

/** ISO today, the value the desktop copies into both date boxes (RP_HUID.cs:1620-1621). */
export function todayIso(): string {
  const now = new Date();
  const pad = (n: number) => String(n).padStart(2, '0');
  return `${now.getFullYear()}-${pad(now.getMonth() + 1)}-${pad(now.getDate())}`;
}

/** The filter values as the desktop opens the form (RP_HUID.cs:1555-1573): Gold, HuId All, the rest
 *  blank. The dates are set after mount (`initialDates`) so the server and the hydrated render agree. */
const initialFilters = (today = ''): HuidFilters => ({
  fromDate: today,
  toDate: today,
  itemType: 'G',
  product: '',
  group: '',
  tagNo: '',
  acCode: '',
  hallmark: 'all',
  search: '',
});

/** Resolve a typed product/group name to its code, as the desktop combo does by selected index
 *  (RP_HUID.cs:1574 reads `PR_NAME As Product,PR_CODE as Code`, :1597 the group list, and the filters use
 *  `AryPrCode[...]` / `AryGrCode[...]`, :1772 / :1815). An exact code is accepted as itself. */
export function resolveCode(
  list: ReadonlyArray<{ code: string; name: string }>,
  typed: string,
): string {
  const text = typed.trim();
  if (!text) return '';
  const upper = text.toUpperCase();
  const hit =
    list.find(
      (row) =>
        String(row.name ?? '')
          .trim()
          .toUpperCase() === upper,
    ) ??
    list.find(
      (row) =>
        String(row.code ?? '')
          .trim()
          .toUpperCase() === upper,
    );
  return hit ? String(hit.code) : text;
}

export function buildQuery(
  view: HuidView,
  f: HuidFilters,
  products: ReadonlyArray<{ code: string; name: string }>,
  groups: ReadonlyArray<{ code: string; name: string }>,
): string {
  const p = new URLSearchParams();
  p.set('view', view);
  p.set('from', f.fromDate);
  p.set('to', f.toDate);
  if (f.itemType) p.set('itemType', f.itemType);
  const product = resolveCode(products, f.product);
  if (product) p.set('product', product);
  const group = resolveCode(groups, f.group);
  if (group) p.set('group', group);
  if (f.tagNo.trim()) p.set('tagNo', f.tagNo.trim().toUpperCase());
  if (f.acCode.trim()) p.set('acCode', f.acCode.trim().toUpperCase());
  if (f.hallmark !== 'all') p.set('hallmark', f.hallmark);
  if (f.search.trim()) p.set('search', f.search.trim());
  return p.toString();
}

export function useHuidReport(
  products: ReadonlyArray<{ code: string; name: string }>,
  groups: ReadonlyArray<{ code: string; name: string }>,
): UseHuidReport {
  const [filters, setFiltersState] = useState<HuidFilters>(() => initialFilters());
  const [result, setResult] = useState<HuidResult | null>(null);
  const [error, setError] = useState('');
  const [status, setStatus] = useState('');
  const [busy, setBusy] = useState(false);
  /** The view of the displayed result, pinned so the search re-runs and the exports follow the screen. */
  const ranView = useRef<HuidView | null>(null);
  const [ranQuery, setRanQuery] = useState<string | null>(null);
  const seq = useRef(0);
  const searchTimer = useRef<ReturnType<typeof setTimeout> | null>(null);
  const latest = useRef(filters);
  latest.current = filters;

  const setFilters = useCallback((patch: Partial<HuidFilters>) => {
    setFiltersState((prev) => ({ ...prev, ...patch }));
  }, []);

  const run = useCallback(
    async (view: HuidView, overrides?: Partial<HuidFilters>) => {
      const f = { ...latest.current, ...overrides };
      if (overrides) setFiltersState(f);
      setError('');
      setStatus('');
      const query = buildQuery(view, f, products, groups);
      const ticket = ++seq.current;
      setBusy(true);
      try {
        const data = await get<HuidResult>(`/reports/huid?${query}`);
        if (ticket !== seq.current) return; // a newer request superseded this one
        setResult(data);
        ranView.current = view;
        setRanQuery(query);
        if (data.rows.length === 0) setStatus('No records for the selected filters.');
      } catch (e) {
        if (ticket !== seq.current) return;
        setResult(null);
        ranView.current = null;
        setRanQuery(null);
        setError(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
      } finally {
        if (ticket === seq.current) setBusy(false);
      }
    },
    [products, groups],
  );

  /** The desktop search filters the loaded rows (RP_HUID.cs:1669-1689); the web asks the same resolver, so
   *  the grid, the totals and every export keep agreeing on the searched rows. */
  const searchAgain = useCallback(
    (search: string) => {
      setFilters({ search });
      if (searchTimer.current) clearTimeout(searchTimer.current);
      if (!ranQuery || !ranView.current) return;
      searchTimer.current = setTimeout(() => {
        void run(ranView.current as HuidView, { search });
      }, 300);
    },
    [ranQuery, run, setFilters],
  );

  useEffect(
    () => () => {
      if (searchTimer.current) clearTimeout(searchTimer.current);
    },
    [],
  );

  /**
   * Download an export. The pre-check reads the response so a refused export can show the desktop's
   * message without navigating anywhere; the download itself then uses the real export URL, so what the
   * browser saves is the file the server built for exactly the shown query.
   */
  const exportFile = useCallback(
    async (ext: 'xlsx' | 'pdf'): Promise<void> => {
      if (!ranQuery) return;
      const path = `/reports/huid/export.${ext}?${ranQuery}`;
      try {
        await getDownload(path);
      } catch (e) {
        if (e instanceof ApiError && e.status === 403 && e.body?.action === 'print') {
          // RP_HUID.cs:1359-1361: the desktop's Excel button refuses without the print right.
          setError(NO_PRINT_RIGHTS);
        } else {
          setError(
            e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed',
          );
        }
        return;
      }
      const anchor = document.createElement('a');
      anchor.href = `/api${path}`;
      anchor.download = '';
      document.body.appendChild(anchor);
      anchor.click();
      anchor.remove();
    },
    [ranQuery],
  );

  const print = useCallback(() => {
    void exportFile('pdf');
  }, [exportFile]);

  const excel = useCallback(() => {
    void exportFile('xlsx');
  }, [exportFile]);

  /** The desktop Cancel clears the screen and resets the dates to today (RP_HUID.cs:1744 CLEAR_DATA,
   *  :1620-1621). No database write exists to undo: the report is read-only. */
  const cancel = useCallback(() => {
    if (searchTimer.current) clearTimeout(searchTimer.current);
    seq.current += 1;
    setFiltersState(initialFilters(todayIso()));
    setResult(null);
    ranView.current = null;
    setRanQuery(null);
    setError('');
    setStatus('');
    setBusy(false);
  }, []);

  return {
    filters,
    setFilters,
    result,
    busy,
    error,
    status,
    run,
    searchAgain,
    print,
    excel,
    cancel,
  };
}
