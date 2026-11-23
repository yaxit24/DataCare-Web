'use client';
import { useCallback, useRef, useState } from 'react';
import { ApiError, get } from '../../../../lib/api';
import {
  isoDate,
  ITEM_TYPES,
  type ApprovalFilters,
  type ApprovalReportMode,
  type ApprovalResult,
} from './types';

/** The constructor branch for "Approval Rpt": RP_ALL.cs:7185 {{mFromDt.Text = "01/01/2010";}}. */
export const DEFAULT_FROM = '01/01/2010';

/** dd/MM/yyyy of the operator's local day, the desktop RP_ALL.cs:7203 system date default. */
export function todayDisplay(): string {
  const now = new Date();
  return `${String(now.getDate()).padStart(2, '0')}/${String(now.getMonth() + 1).padStart(2, '0')}/${now.getFullYear()}`;
}

export const DATE_FORMAT_MESSAGE =
  'Enter a valid date in dd/MM/yyyy format (for example 01/01/2026).';

/**
 * Build the request of one approval button. Only the selectors the three click handlers append are sent
 * (RP_ALL.cs:8156-8192: location, book, party, product, city, area, item type, group). Cust Name is cleared by its
 * own Enter (RP_ALL.cs:9717) and is never an approval predicate; employee, state and Select Book are hidden.
 */
export function approvalQuery(
  mode: ApprovalReportMode,
  filters: ApprovalFilters,
  sessionLcCode = '',
): { query: string; error?: string } {
  const fromDate = isoDate(filters.fromDate);
  const toDate = isoDate(filters.toDate);
  // D7: the desktop converts on click without a guard (RP_ALL.cs:8152); the web refuses an unfinished date.
  if (!fromDate || !toDate) return { query: '', error: DATE_FORMAT_MESSAGE };
  const query = new URLSearchParams({ mode, fromDate, toDate });
  // The lc box is locked outside head office (RP_ALL.cs:6664); the server enforces the session location anyway (D9).
  query.set('lcCode', sessionLcCode !== '00' ? sessionLcCode : filters.lcCode.trim());
  // `bookCode`, not `coBook`: the API reads `coBook` as the session's own book.
  if (filters.bookCode.trim()) query.set('bookCode', filters.bookCode.trim());
  if (filters.partyCode.trim()) query.set('acCode', filters.partyCode.trim());
  if (filters.prCode.trim()) query.set('prCode', filters.prCode.trim());
  if (filters.grCode.trim()) query.set('grCode', filters.grCode.trim());
  if (filters.city.trim()) query.set('city', filters.city.trim());
  if (filters.area.trim()) query.set('area', filters.area.trim());
  if (filters.itemType && ITEM_TYPES.includes(filters.itemType))
    query.set('itemType', filters.itemType);
  return { query: query.toString() };
}

const messageOf = (error: unknown): string => {
  if (error instanceof ApiError) return error.body?.message || error.body?.error || error.message;
  return 'Unable to run the Approval Report.';
};

export function useApprovalReport(lcCode: string) {
  const [filters, setFiltersState] = useState<ApprovalFilters>(() => ({
    fromDate: DEFAULT_FROM,
    toDate: todayDisplay(),
    lcCode,
    bookCode: '',
    prCode: '',
    grCode: '',
    partyCode: '',
    custName: '',
    city: '',
    area: '',
    itemType: '',
  }));
  const [result, setResult] = useState<ApprovalResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const [ranQuery, setRanQuery] = useState<string | null>(null);
  const sequence = useRef(0);

  const setFilters = useCallback((patch: Partial<ApprovalFilters>) => {
    setFiltersState((current) => ({ ...current, ...patch }));
  }, []);

  const run = useCallback(
    async (mode: ApprovalReportMode): Promise<boolean> => {
      const built = approvalQuery(mode, filters, lcCode);
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
        const body = await get<ApprovalResult>(`/reports/approval-report?${built.query}`);
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

  /**
   * CLEAR_DATA (RP_ALL.cs:7213-7225): every TextBox becomes "" and every MaskedTextBox the empty mask; the combos
   * (City, Area, Item Type) keep their selection and no default is reapplied. The server still applies the session
   * location after the lc box is cleared (D9).
   */
  const clear = useCallback(() => {
    sequence.current += 1;
    setFiltersState((current) => ({
      ...current,
      fromDate: '',
      toDate: '',
      lcCode: '',
      bookCode: '',
      prCode: '',
      grCode: '',
      partyCode: '',
      custName: '',
    }));
    setResult(null);
    setError('');
    setRanQuery(null);
    setBusy(false);
  }, []);

  const exportPath = useCallback(
    (extension: 'csv' | 'xlsx' | 'pdf') =>
      ranQuery ? `/reports/approval-report/export.${extension}?${ranQuery}` : null,
    [ranQuery],
  );

  return { filters, setFilters, result, error, busy, ranQuery, run, clear, exportPath };
}
