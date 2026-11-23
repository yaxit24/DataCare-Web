'use client';
import { useCallback, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { get } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { LookupField, focusControl, type HelpRow } from './LookupField';
import { ListField } from './ListField';
import { OrderReportGrid } from './OrderReportGrid';
import { isoDate, type OrderReportMode } from './types';
import { orderQuery, useOrderReport } from './useOrderReport';

/** PanelOrder captions verbatim, including the trailing space and the space after & (RP_ALL.cs:5360 etc.). */
const BUTTONS: ReadonlyArray<{ mode: OrderReportMode; caption: string }> = [
  { mode: 'report', caption: '&Order Report' },
  { mode: 'advance', caption: '&Order Advance' },
  { mode: 'adjust', caption: '&Order Adjust' },
  { mode: 'with-bill', caption: '&Order Wise Bill ' },
  { mode: 'pending', caption: '&Making Panding' },
  { mode: 'summary', caption: '& Making Summ' },
  { mode: 'bill-wise', caption: 'Bill Wise Adjust' },
];

const DATE_MESSAGE = 'Enter a valid date in dd/MM/yyyy format (for example 01/01/2026).';

export default function OrderReportPage() {
  const router = useRouter();
  const { lcCode } = useBusinessScope();
  const report = useOrderReport(lcCode);
  const { filters, setFilters } = report;
  const [validationError, setValidationError] = useState('');
  const [prompt, setPrompt] = useState(false);
  const locations = useRef<Promise<HelpRow[]> | null>(null);
  const summaryButton = useRef<HTMLButtonElement | null>(null);

  const onEscape = useCallback(
    (event: ScreenKeyEvent) => {
      if (event.key !== 'Escape' || event.defaultPrevented) return;
      event.preventDefault();
      if (prompt) {
        setPrompt(false);
        summaryButton.current?.focus();
        return;
      }
      router.back();
    },
    [router, prompt],
  );
  const screenRef = useScreenEscape<HTMLFormElement>(onEscape);

  const runMode = useCallback(
    async (mode: OrderReportMode, onlySummary = false) => {
      const built = orderQuery(mode, filters, onlySummary, lcCode);
      if (built.error) {
        setValidationError(built.error);
        return;
      }
      setValidationError('');
      if (mode !== 'summary') setPrompt(false);
      await report.run(mode, onlySummary);
    },
    [filters, lcCode, report],
  );

  const onDateKey =
    (field: 'fromDate' | 'toDate', next: string) => (event: KeyboardEvent<HTMLInputElement>) => {
      if (event.key !== 'Enter') return;
      event.preventDefault();
      if (!isoDate(filters[field])) {
        setValidationError(DATE_MESSAGE);
        return;
      }
      setValidationError('');
      focusControl(next === 'lc Code' && lcCode !== '00' ? 'Book' : next);
    };

  const loadBooks = useCallback(
    (term: string) => get<HelpRow[]>(`/lookup/books?q=${encodeURIComponent(term)}&limit=20`),
    [],
  );
  const loadAccounts = useCallback(
    (term: string) => get<HelpRow[]>(`/lookup/accounts?q=${encodeURIComponent(term)}&limit=20`),
    [],
  );
  const loadLocations = useCallback(async () => {
    locations.current ??= get<Array<{ LC_CODE: string; LC_NAME: string | null }>>(
      '/context/locations',
    )
      .then((rows) => rows.map((row) => ({ code: row.LC_CODE, name: row.LC_NAME ?? '' })))
      .catch((error: unknown) => {
        locations.current = null;
        throw error;
      });
    return locations.current;
  }, []);
  // MISSING: a company-scoped SL_ORD_DATA name lookup. A date-filtered report is not that help list.
  const loadCustomers = useCallback(async (): Promise<HelpRow[]> => {
    throw new Error('Customer name help is unavailable. Enter the full customer name to filter.');
  }, []);

  const error = validationError || report.error;
  const exportPathCsv = report.exportPath('csv');
  const exportPathXlsx = report.exportPath('xlsx');

  return (
    <div>
      <h1>Order Report</h1>
      <form
        ref={screenRef}
        aria-label="Order Report"
        onKeyDown={onEscape}
        onSubmit={(event) => event.preventDefault()}
      >
        <div className="panel">
          <div className="row">
            <div className="field">
              <label htmlFor="or-from">From</label>
              <input
                id="or-from"
                aria-label="From"
                value={filters.fromDate}
                autoFocus
                onChange={(event) => setFilters({ fromDate: event.target.value })}
                onKeyDown={onDateKey('fromDate', 'To')}
              />
            </div>
            <div className="field">
              <label htmlFor="or-to">To</label>
              <input
                id="or-to"
                aria-label="To"
                value={filters.toDate}
                onChange={(event) => setFilters({ toDate: event.target.value })}
                onKeyDown={onDateKey('toDate', 'lc Code')}
              />
            </div>
            <LookupField
              label="lc Code"
              value={filters.lcCode}
              disabled={lcCode !== '00'}
              onChange={(value) => setFilters({ lcCode: value })}
              load={loadLocations}
              maxLength={8}
              focusAfter="Book"
            />
            <LookupField
              label="Book"
              value={filters.bookCode}
              onChange={(value) => setFilters({ bookCode: value })}
              load={loadBooks}
              maxLength={8}
              focusAfter="Party Code"
            />
            <LookupField
              label="Pr Code"
              value={filters.prCode}
              onChange={(value) => setFilters({ prCode: value })}
              load={async () => []}
              maxLength={8}
              disabled
              focusAfter="Gr Code"
            />
            <LookupField
              label="Gr Code"
              value={filters.grCode}
              onChange={(value) => setFilters({ grCode: value })}
              load={async () => []}
              maxLength={8}
              disabled
              focusAfter="Party Code"
            />
            <LookupField
              label="Party Code"
              value={filters.partyCode}
              onChange={(value) => setFilters({ partyCode: value })}
              load={loadAccounts}
              maxLength={8}
              focusAfter="Cust Name"
            />
            <LookupField
              label="Cust Name"
              value={filters.custName}
              onChange={(value) => setFilters({ custName: value })}
              load={loadCustomers}
              maxLength={50}
              focusAfter="City"
            />
            <ListField
              label="City"
              value={filters.city}
              options={[]}
              onChange={(value) => setFilters({ city: value })}
            />
            <ListField
              label="Area"
              value={filters.area}
              options={[]}
              onChange={(value) => setFilters({ area: value })}
            />
            <div className="field" style={{ minWidth: 130 }}>
              <label htmlFor="or-item-type">Item Type</label>
              <input
                id="or-item-type"
                aria-label="Item Type"
                value={filters.itemType}
                disabled
                onChange={(event) => setFilters({ itemType: event.target.value })}
              />
            </div>
          </div>
          <div className="row" data-panel="order" style={{ marginTop: 10 }}>
            {BUTTONS.map((button) => (
              <button
                key={button.mode}
                type="button"
                className="ghost"
                ref={button.mode === 'summary' ? summaryButton : undefined}
                disabled={report.busy}
                onClick={() => {
                  if (button.mode === 'summary') {
                    const built = orderQuery('summary', filters, false, lcCode);
                    setValidationError(built.error ?? '');
                    if (!built.error) setPrompt(true);
                  } else {
                    void runMode(button.mode);
                  }
                }}
              >
                {button.caption}
              </button>
            ))}
            <span className="spacer" />
            <button
              type="button"
              className="ghost"
              onClick={() => {
                report.clear();
                setValidationError('');
                setPrompt(false);
                focusControl('From');
              }}
            >
              Cancel
            </button>
            <button type="button" className="ghost">
              Print
            </button>
            <button type="button" className="ghost" onClick={() => router.back()}>
              Exit
            </button>
          </div>
          <div className="row" style={{ marginTop: 8 }}>
            <button
              type="button"
              className="ghost"
              disabled={!exportPathCsv}
              onClick={() => exportPathCsv && openDocument(`/api${exportPathCsv}`)}
            >
              CSV
            </button>
            <button
              type="button"
              className="ghost"
              disabled={!exportPathXlsx}
              onClick={() => exportPathXlsx && openDocument(`/api${exportPathXlsx}`)}
            >
              XLSX
            </button>
          </div>
        </div>
        {error && (
          <div className="msg err" role="alert">
            {error}
          </div>
        )}
        {prompt && (
          <div role="dialog" aria-label="DataCareNext">
            <h2>DataCareNext</h2>
            <p>Only Design Summery Report..</p>
            <button
              type="button"
              onClick={() => {
                setPrompt(false);
                summaryButton.current?.focus();
                void runMode('summary', true);
              }}
            >
              Yes
            </button>
            <button
              type="button"
              onClick={() => {
                setPrompt(false);
                summaryButton.current?.focus();
                void runMode('summary', false);
              }}
            >
              No
            </button>
          </div>
        )}
      </form>
      {report.result && <OrderReportGrid report={report.result} />}
    </div>
  );
}
