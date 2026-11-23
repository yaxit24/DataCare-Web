'use client';
import { useCallback, useMemo, useRef, useState } from 'react';
import { ApiError, downloadPdf, get } from '../../../../lib/api';
import { todayLocal } from '../../../../lib/localDate';
import { openDocument } from '../../../../lib/openDocument';
import type { GstFilters, GstReportResult, GstView } from './types';

const fiscalBounds = (coYear: string): { start: string; end: string } => {
  const match = /^(\d{4})-(\d{4})$/.exec(coYear);
  if (!match) return { start: '', end: '' };
  return { start: `${match[1]}-04-01`, end: `${match[2]}-03-31` };
};

const defaultTo = (coYear: string): string => {
  const { start, end } = fiscalBounds(coYear);
  const today = todayLocal();
  if (!start || !end) return today;
  if (today < start) return start;
  if (today > end) return end;
  return today;
};

export function gstQuery(view: GstView, filters: GstFilters): string {
  const query = new URLSearchParams({
    view,
    fromDate: filters.fromDate,
    toDate: filters.toDate,
  });
  if (view !== 'gstr3b' && filters.section) query.set('section', filters.section);
  if (filters.bookCode.trim()) query.set('bookCode', filters.bookCode.trim());
  if (filters.partyCode.trim()) query.set('partyCode', filters.partyCode.trim());
  return query.toString();
}

const messageOf = (error: unknown): string => {
  if (!(error instanceof ApiError)) return 'Unable to run the GST report.';
  const code = String(error.body?.error ?? '');
  if (code === 'missing-section') return 'Please Select Section Type And Try...';
  if (code === 'date-outside-year') return 'Date must be inside the selected financial year.';
  if (code === 'invalid-date-range') return 'From Date must not be after To Date.';
  if (code === 'section-not-supported')
    return `The ${String(error.body?.section ?? 'selected')} section is not settled by the desktop source.`;
  if (code === 'csv-not-settled') return EXP_CSV_BLOCKED;
  return error.body?.message || code || error.message;
};

/** WP-19 decision Q9: the EXP.csv bytes wait for a Windows desktop run; the web writes no invented file. */
const EXP_CSV_BLOCKED =
  'EXP.csv is not produced: its desktop byte layout is not yet confirmed on Windows.';

export function useGstReport(coYear: string) {
  const bounds = useMemo(() => fiscalBounds(coYear), [coYear]);
  const [filters, setFiltersState] = useState<GstFilters>(() => ({
    section: '',
    fromDate: fiscalBounds(coYear).start,
    toDate: defaultTo(coYear),
    bookCode: '',
    partyCode: '',
  }));
  const [report, setReport] = useState<GstReportResult | null>(null);
  const [error, setError] = useState('');
  const [message, setMessage] = useState('');
  const [busyView, setBusyView] = useState<GstView | null>(null);
  const [ranQuery, setRanQuery] = useState<string | null>(null);
  const sequence = useRef(0);

  const setFilters = useCallback((patch: Partial<GstFilters>) => {
    setFiltersState((current) => ({ ...current, ...patch }));
  }, []);

  const run = useCallback(
    async (view: GstView, dates: Partial<Pick<GstFilters, 'fromDate' | 'toDate'>> = {}) => {
      setError('');
      setMessage('');
      const current = { ...filters, ...dates };
      if (view !== 'gstr3b' && !current.section) {
        setReport(null);
        setRanQuery(null);
        setError('Please Select Section Type And Try...');
        return;
      }
      const query = gstQuery(view, current);
      const ticket = ++sequence.current;
      setBusyView(view);
      try {
        const result = await get<GstReportResult>(`/reports/gst-report?${query}`);
        if (ticket !== sequence.current) return;
        setReport(result);
        setRanQuery(query);
        // EXP and EXEMP return before their query and DOCS has none (RP_GST.cs:2700-2723): no message.
        if (result.rows.length === 0 && !result.metadata.headerOnly)
          setMessage('No Record Found....');
      } catch (cause) {
        if (ticket !== sequence.current) return;
        setReport(null);
        setRanQuery(null);
        setError(messageOf(cause));
      } finally {
        if (ticket === sequence.current) setBusyView(null);
      }
    },
    [filters],
  );

  const exportPath = useCallback(
    (extension: 'csv' | 'xlsx' | 'pdf'): string | null =>
      ranQuery ? `/reports/gst-report/export.${extension}?${ranQuery}` : null,
    [ranQuery],
  );
  const csv = useCallback(() => {
    // BtnCsvFile_Click (RP_GST.cs:3077-3110) writes nothing and says nothing for EXEMP (`case 9: break;`) and DOCS.
    if (report?.section === 'EXEMP' || report?.section === 'DOCS') return;
    if (report?.section === 'EXP') {
      setError(EXP_CSV_BLOCKED);
      return;
    }
    const path = exportPath('csv');
    if (path) openDocument(`/api${path}`);
  }, [exportPath, report?.section]);
  /** "Gsrt1 Csv" (btnGstrCsv_Click, RP_GST.cs:3819-3943): every section B2B..HSN for the screen's filters. */
  const workbook = useCallback(
    (dates: Partial<Pick<GstFilters, 'fromDate' | 'toDate'>> = {}) => {
      const current = { ...filters, ...dates };
      const query = new URLSearchParams({ fromDate: current.fromDate, toDate: current.toDate });
      if (current.bookCode.trim()) query.set('bookCode', current.bookCode.trim());
      if (current.partyCode.trim()) query.set('partyCode', current.partyCode.trim());
      openDocument(`/api/reports/gst-report/workbook.xlsx?${query.toString()}`);
    },
    [filters],
  );
  const pdf = useCallback(async () => {
    const path = exportPath('pdf');
    if (path) await downloadPdf(path, report?.fileName || 'gst-report');
  }, [exportPath, report?.fileName]);

  return {
    bounds,
    filters,
    setFilters,
    report,
    error,
    message,
    busyView,
    ranQuery,
    run,
    csv,
    workbook,
    pdf,
  };
}
