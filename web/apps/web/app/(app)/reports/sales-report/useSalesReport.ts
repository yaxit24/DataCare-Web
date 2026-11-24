'use client';
import { useCallback, useRef, useState } from 'react';
import { ApiError, get, getDownload } from '../../../../lib/api';
import { todayLocal } from '../../../../lib/localDate';
import type { SalesFilters, SalesReportMode, SalesResult } from './types';

/** The answers to the two desktop Yes/No prompts (RP_ALL.cs:7584, :11749). */
export interface SalesAnswers {
  /** "Sales Return (Creditnote) Report" answered Yes. */
  returns?: boolean;
  /** "Only Item Sales With Order" answered Yes. */
  orderOnly?: boolean;
}

/** Employ items are `EMP_CODE-EMP_NAME` (RP_ALL.cs:7148); the web sends the whole code, not Mid(text,1,3) (inventory 6.3). */
export function employeeCode(text: string, options: readonly string[]): string {
  const value = text.trim();
  if (!value) return '';
  const hit = options.find((option) => option.toUpperCase() === value.toUpperCase());
  return hit ? hit.slice(0, hit.indexOf('-')) : value;
}

export function salesQuery(
  mode: SalesReportMode,
  filters: SalesFilters,
  answers: SalesAnswers,
  sessionLcCode: string,
  employees: readonly string[],
): string {
  const query = new URLSearchParams({
    mode,
    fromDate: filters.fromDate,
    toDate: filters.toDate,
  });
  query.set('lcCode', sessionLcCode !== '00' ? sessionLcCode : filters.lcCode);
  // `bookCode`, not `coBook`: `coBook` is also the session's book and would refuse a typed unknown book (409).
  const set = (name: string, value: string) => value.trim() && query.set(name, value.trim());
  set('bookCode', filters.bookCode);
  // Select Book only counts while its check box is ticked and at least one book was picked (RP_ALL.cs:11392).
  if (filters.selectBook && filters.books.length) query.set('books', filters.books.join(','));
  set('prCode', filters.prCode);
  set('grCode', filters.grCode);
  set('acCode', filters.partyCode);
  set('city', filters.city);
  set('area', filters.area);
  set('itemType', filters.itemType);
  set('empCode', employeeCode(filters.employ, employees));
  if (answers.returns) query.set('returns', 'yes');
  if (answers.orderOnly) query.set('orderOnly', 'yes');
  return query.toString();
}

const messageOf = (error: unknown): string => {
  if (error instanceof ApiError) return error.body?.message || error.body?.error || error.message;
  return 'Unable to run the Sales Report.';
};

export function useSalesReport(lcCode: string, employees: readonly string[]) {
  const [filters, setFiltersState] = useState<SalesFilters>(() => ({
    // RP_ALL.cs:7197, :7203: both boxes start at the system date.
    fromDate: todayLocal(),
    toDate: todayLocal(),
    lcCode,
    bookCode: '',
    selectBook: false,
    books: [],
    prCode: '',
    grCode: '',
    partyCode: '',
    city: '',
    area: '',
    itemType: '',
    employ: '',
  }));
  const [result, setResult] = useState<SalesResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const [ranQuery, setRanQuery] = useState<string | null>(null);
  const sequence = useRef(0);

  const setFilters = useCallback((patch: Partial<SalesFilters>) => {
    setFiltersState((current) => ({ ...current, ...patch }));
  }, []);

  /** One read of a built query. */
  const execute = useCallback(async (query: string): Promise<boolean> => {
    setError('');
    const ticket = ++sequence.current;
    setBusy(true);
    try {
      const body = await get<SalesResult>(`/reports/sales-report?${query}`);
      if (ticket !== sequence.current) return false;
      setResult(body);
      setRanQuery(query);
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
  }, []);

  /** One read per Run; `dates` are the SetDate-committed boxes. */
  const run = useCallback(
    (
      mode: SalesReportMode,
      answers: SalesAnswers,
      dates?: Pick<SalesFilters, 'fromDate' | 'toDate'>,
    ): Promise<boolean> =>
      execute(salesQuery(mode, { ...filters, ...dates }, answers, lcCode, employees)),
    [execute, filters, lcCode, employees],
  );

  /** Cancel (BtnCancel): the boxes go back to blank, the grid is dropped. */
  const clear = useCallback(() => {
    sequence.current += 1;
    setFiltersState((current) => ({
      ...current,
      lcCode: '',
      bookCode: '',
      selectBook: false,
      books: [],
      prCode: '',
      grCode: '',
      partyCode: '',
      city: '',
      area: '',
      itemType: '',
      employ: '',
    }));
    setResult(null);
    setError('');
    setRanQuery(null);
    setBusy(false);
  }, []);

  const download = useCallback(
    async (extension: 'csv' | 'xlsx') => {
      if (!ranQuery) return;
      try {
        const file = await getDownload(`/reports/sales-report/export.${extension}?${ranQuery}`);
        const url = URL.createObjectURL(file.blob);
        const anchor = document.createElement('a');
        anchor.href = url;
        anchor.download = file.filename || `sales-report.${extension}`;
        document.body.appendChild(anchor);
        anchor.click();
        anchor.remove();
        setTimeout(() => URL.revokeObjectURL(url), 1000);
      } catch (cause) {
        setError(messageOf(cause));
      }
    },
    [ranQuery],
  );

  return {
    filters,
    setFilters,
    result,
    error,
    setError,
    busy,
    ranQuery,
    run,
    execute,
    clear,
    download,
  };
}
