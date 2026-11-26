'use client';
import { useCallback, useRef, useState } from 'react';
import { ApiError, get, getDownload, getPageContextState } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';
import { todayLocal } from '../../../../lib/localDate';
import { isoToDesktop, parseDesktopDate } from './dateText';
import type { TagStockFilters, TagStockReport, TagStockTab, TagStockView } from './types';

/** The desktop text when the print right is missing (RP_TAG.cs:3259). */
export const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';

const blankFilters = (lcCode: string): TagStockFilters => {
  const today = isoToDesktop(todayLocal());
  return {
    rptType: 'tag',
    from: today,
    to: today,
    search: '',
    itType: '',
    itCode: '',
    prCode: '',
    grCode: '',
    tagNo: '',
    size: '',
    lcCode,
    bookCode: '',
  };
};

/**
 * State and requests of the Tag Stock screen. The desktop runs a query only on a mode button (RP_TAG.cs:3977); a
 * request answered after a newer one was sent is dropped, so the slow Stock answer never replaces the Out grid.
 */
export function useTagStock() {
  const sessionLc = () => getPageContextState().context?.lcCode ?? '';
  const [filters, setFiltersState] = useState<TagStockFilters>(() => blankFilters(sessionLc()));
  const [report, setReport] = useState<TagStockReport | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const seq = useRef(0);
  const ran = useRef<string | null>(null);

  const setFilters = useCallback(
    (patch: Partial<TagStockFilters>) => setFiltersState((f) => ({ ...f, ...patch })),
    [],
  );

  /** The query the report was asked with; null (and a message) when a date is not valid. */
  const queryFor = useCallback(
    (tab: TagStockTab, view: TagStockView, extra: Record<string, string> = {}): string | null => {
      const from = parseDesktopDate(filters.from);
      const to = parseDesktopDate(filters.to);
      for (const d of [from, to]) {
        if ('error' in d) {
          setError(d.error);
          return null;
        }
      }
      if ('error' in from || 'error' in to) return null;
      const q = new URLSearchParams({
        tab,
        view,
        fromDate: from.iso,
        toDate: to.iso,
        sysDate: todayLocal(),
        lcCode: filters.lcCode,
      });
      const f = filters;
      const opt: Array<[string, string]> = [
        ['itType', f.itType],
        ['itCode', f.itCode],
        ['prCode', f.prCode],
        ['grCode', f.grCode],
        ['tagNo', f.tagNo],
        ['size', f.size],
        ['bookCode', f.bookCode],
      ];
      for (const [k, v] of opt) if (v.trim()) q.set(k, v.trim());
      for (const [k, v] of Object.entries(extra)) q.set(k, v);
      return q.toString();
    },
    [filters],
  );

  const run = useCallback(
    async (tab: TagStockTab, view: TagStockView = 'tag') => {
      setError('');
      let query = queryFor(tab, view);
      if (query === null) return;
      const ticket = ++seq.current;
      setBusy(true);
      try {
        let data = await get<TagStockReport>(`/reports/tag-stock?${query}`);
        // RP_TAG.cs:4204: the "Tour Outword Stock Show....?" prompt appears only when employee issues exist.
        if (tab === 'apr' && data.hasEmpIssue && window.confirm('Tour Outword Stock Show....?')) {
          query = queryFor(tab, view, { aprKind: 'employee' }) ?? query;
          data = await get<TagStockReport>(`/reports/tag-stock?${query}`);
        } else if (
          // RP_TAG.cs:4210, :4221: otherwise Apr asks whether to show the other detail items of each tag.
          tab === 'apr' &&
          view === 'tag' &&
          window.confirm('Report With Other Detail Item Name...')
        ) {
          query = queryFor(tab, view, { otherItems: '1' }) ?? query;
          data = await get<TagStockReport>(`/reports/tag-stock?${query}`);
        }
        if (ticket !== seq.current) return;
        setReport(data);
        ran.current = query;
      } catch (e) {
        if (ticket !== seq.current) return;
        setReport(null);
        ran.current = null;
        setError(
          e instanceof ApiError ? (e.body?.message ?? e.body?.error ?? e.message) : 'failed',
        );
      } finally {
        if (ticket === seq.current) setBusy(false);
      }
    },
    [queryFor],
  );

  /** DGV_CLEAR: the grid and its footer go away (RP_TAG.cs:3736-3745, :9695). */
  const clearGrid = useCallback(() => {
    seq.current++;
    ran.current = null;
    setReport(null);
    setError('');
    setBusy(false);
  }, []);

  /** Cancel: every selector back to its default and the grid cleared. */
  const reset = useCallback(() => {
    setFiltersState(blankFilters(sessionLc()));
    clearGrid();
  }, [clearGrid]);

  /**
   * Excel and CSV download the file; Print and Summ open the print window. Each first asks for the document, so a user
   * without the print right sees the desktop text (RP_TAG.cs:3257-3260 BtnSave_Click) instead of a window holding a
   * JSON error, and the window opens only for a document that exists.
   */
  const exportAs = useCallback(
    async (
      ext: 'csv' | 'xlsx' | 'print' | 'summ-product' | 'summ-item',
      search: string,
    ): Promise<void> => {
      if (!ran.current) return;
      const q = new URLSearchParams(ran.current);
      if (search.trim()) q.set('search', search.trim());
      let path = `/reports/tag-stock.${ext}?${q.toString()}`;
      if (ext !== 'csv' && ext !== 'xlsx') {
        if (ext !== 'print') q.set('kind', ext);
        path = `/reports/tag-stock/print?${q.toString()}`;
      }
      try {
        await getDownload(path);
      } catch (e) {
        setError(
          e instanceof ApiError && e.status === 403
            ? NO_PRINT_RIGHTS
            : e instanceof ApiError
              ? (e.body?.message ?? e.body?.error ?? e.message)
              : 'failed',
        );
        return;
      }
      setError('');
      openDocument(`/api${path}`);
    },
    [],
  );

  return { filters, setFilters, report, error, setError, busy, run, clearGrid, reset, exportAs };
}
