'use client';
import { useCallback, useRef, useState } from 'react';
import { ApiError, get } from '../../../../lib/api';
import {
  displayDate,
  isoDate,
  type OrderFilters,
  type OrderReportMode,
  type OrderResult,
} from './types';

/** The desktop constructor branch RP_ALL.cs:7177 {{mFromDt.Text = "01/01/2010";}} (D11). */
const DEFAULT_FROM = '01/01/2010';

/** dd/MM/yyyy of the operator's local day, the desktop RP_ALL.cs:7203 system date default. */
function todayDisplay(): string {
  const now = new Date();
  return `${String(now.getDate()).padStart(2, '0')}/${String(now.getMonth() + 1).padStart(2, '0')}/${now.getFullYear()}`;
}

export function orderQuery(
  mode: OrderReportMode,
  filters: OrderFilters,
  onlySummary = false,
  sessionLcCode = '',
): { query: string; error?: string } {
  const fromDate = isoDate(filters.fromDate);
  const toDate = isoDate(filters.toDate);
  // D10: the desktop has no guard, but its incomplete mask would crash Conversions.ToDate. The web refuses
  // an impossible or unfinished date instead (RP_ALL.cs:8380 builds a plain inclusive range).
  if (!fromDate || !toDate)
    return {
      query: '',
      error: 'Enter a valid date in dd/MM/yyyy format (for example 01/01/2026).',
    };
  const query = new URLSearchParams({ mode, fromDate, toDate });
  query.set('lcCode', sessionLcCode !== '00' ? sessionLcCode : filters.lcCode);
  if (filters.bookCode.trim()) query.set('coBook', filters.bookCode.trim());
  if (filters.partyCode.trim()) query.set('acCode', filters.partyCode.trim());
  if (filters.custName.trim()) query.set('custName', filters.custName.trim());
  if (filters.city) query.set('city', filters.city);
  if (filters.area) query.set('area', filters.area);
  if (mode === 'summary') query.set('onlySummary', onlySummary ? 'true' : 'false');
  // Pr Code, Gr Code and Item Type are dead selectors in this caption (D8): they never reach the request.
  return { query: query.toString() };
}

const messageOf = (error: unknown): string => {
  if (error instanceof ApiError) return error.body?.message || error.body?.error || error.message;
  return 'Unable to run the Order Report.';
};

export function useOrderReport(lcCode: string) {
  const [filters, setFiltersState] = useState<OrderFilters>(() => ({
    fromDate: DEFAULT_FROM,
    toDate: displayDate(todayDisplay()),
    lcCode,
    bookCode: '',
    partyCode: '',
    prCode: '',
    grCode: '',
    custName: '',
    city: '',
    area: '',
    itemType: '',
  }));
  const [result, setResult] = useState<OrderResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const [ranQuery, setRanQuery] = useState<string | null>(null);
  const sequence = useRef(0);

  const setFilters = useCallback((patch: Partial<OrderFilters>) => {
    setFiltersState((current) => ({ ...current, ...patch }));
  }, []);

  const run = useCallback(
    async (mode: OrderReportMode, onlySummary = false): Promise<boolean> => {
      const built = orderQuery(mode, filters, onlySummary, lcCode);
      if (built.error) {
        setError(built.error);
        setResult(null);
        setRanQuery(null);
        return false;
      }
      setError('');
      const ticket = ++sequence.current;
      setBusy(true);
      try {
        const body = await get<OrderResult>(`/reports/order-report?${built.query}`);
        if (ticket !== sequence.current) return false;
        setResult(body);
        setRanQuery(built.query);
        return true;
      } catch (cause) {
        if (ticket !== sequence.current) return false;
        setResult(null);
        setRanQuery(null);
        setError(messageOf(cause));
        return false;
      } finally {
        if (ticket === sequence.current) setBusy(false);
      }
    },
    [filters, lcCode],
  );

  const clear = useCallback(() => {
    sequence.current += 1;
    setFiltersState((current) => ({
      ...current,
      lcCode: '',
      fromDate: '',
      toDate: '',
      bookCode: '',
      partyCode: '',
      prCode: '',
      grCode: '',
      custName: '',
    }));
    setResult(null);
    setError('');
    setRanQuery(null);
    setBusy(false);
    // The desktop's CLEAR_DATA blanks the masks and text boxes but keeps the combo selections
    // (RP_ALL.cs:7221, study Keyboard); City, Area and Item Type are deliberately untouched.
  }, []);

  const exportPath = useCallback(
    (extension: 'csv' | 'xlsx') =>
      ranQuery ? `/reports/order-report/export.${extension}?${ranQuery}` : null,
    [ranQuery],
  );

  return { filters, setFilters, result, error, busy, ranQuery, run, clear, exportPath };
}
