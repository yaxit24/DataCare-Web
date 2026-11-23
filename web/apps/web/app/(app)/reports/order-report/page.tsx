'use client';
import { useCallback, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { get } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { LookupField, desktopText, focusControl, type HelpRow } from './LookupField';
import { ListField } from './ListField';
import { OrderReportGrid } from './OrderReportGrid';
import { isoDate, type OrderReportMode, type OrderResult } from './types';
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

const CITY_OPTIONS = ['SURAT', 'BARODA'];
const AREA_OPTIONS = ['ADAJAN', 'ALKAPURI'];
const LOCATIONS: readonly HelpRow[] = [
  { code: '00', name: 'Head Office' },
  { code: '01', name: 'Branch 01' },
];

const DATE_MESSAGE = 'Enter a valid date in dd/MM/yyyy format (for example 01/01/2026).';

export default function OrderReportPage() {
  const router = useRouter();
  const { lcCode } = useBusinessScope();
  const report = useOrderReport(lcCode);
  const { filters, setFilters } = report;
  const [validationError, setValidationError] = useState('');
  const [prompt, setPrompt] = useState(false);
  const [customerNames, setCustomerNames] = useState<string[]>([]);
  const [locationHelp, setLocationHelp] = useState<HelpRow[]>([]);

  const onEscape = useCallback(
    (event: ScreenKeyEvent) => {
      if (event.key !== 'Escape' || event.defaultPrevented) return;
      event.preventDefault();
      setPrompt(false);
      router.back();
    },
    [router],
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
      focusControl(next);
    };

  const loadBooks = useCallback(
    (term: string) => get<HelpRow[]>(`/lookup/books?q=${encodeURIComponent(term)}&limit=20`),
    [],
  );
  const loadAccounts = useCallback(
    (term: string) => get<HelpRow[]>(`/lookup/accounts?q=${encodeURIComponent(term)}&limit=20`),
    [],
  );
  const loadLocations = useCallback(
    async (term: string) =>
      LOCATIONS.filter((row) => row.code.toUpperCase().includes(term.toUpperCase())).map((row) => ({
        ...row,
      })),
    [],
  );
  /** D9: Cust Name help lists distinct names on the orders (SL_ORD_DATA), in every mode. */
  const loadCustomers = useCallback(
    async (term: string): Promise<HelpRow[]> => {
      let names = customerNames;
      if (!names.length) {
        const query = new URLSearchParams({
          mode: 'advance',
          fromDate: isoDate(filters.fromDate) ?? '2010-01-01',
          toDate: isoDate(filters.toDate) ?? '2010-01-01',
          lcCode: filters.lcCode,
        });
        const result = await get<OrderResult>(`/reports/order-report?${query.toString()}`);
        names = [
          ...new Set(
            result.rows
              .map((row) => String(row.cells.acName ?? ''))
              .filter((value) => value !== ''),
          ),
        ];
        setCustomerNames(names);
      }
      return names
        .filter((name) => name.toUpperCase().includes(term.toUpperCase()))
        .map((name) => ({ code: name, name }));
    },
    [customerNames, filters.fromDate, filters.toDate, filters.lcCode],
  );

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
            <div className="field">
              <label htmlFor="or-lc">lc Code</label>
              <input
                id="or-lc"
                aria-label="lc Code"
                value={filters.lcCode}
                disabled={lcCode !== '00'}
                onChange={(event) => setFilters({ lcCode: desktopText(event.target.value) })}
                onKeyDown={(event) => {
                  if (event.key !== 'Enter') return;
                  event.preventDefault();
                  const field = event.currentTarget;
                  if (!field.value) {
                    focusControl('Book');
                    return;
                  }
                  const exact = LOCATIONS.find(
                    (row) => row.code === field.value.trim().toUpperCase(),
                  );
                  if (exact) {
                    setFilters({ lcCode: exact.code });
                    focusControl('Book');
                  } else {
                    void loadLocations(field.value.trim()).then((rows) => {
                      if (rows.length) setLocationHelp(rows);
                    });
                  }
                }}
              />
              {locationHelp.length > 0 && (
                <div role="dialog" aria-label="lc Code help">
                  {locationHelp.map((row) => (
                    <button
                      type="button"
                      key={row.code}
                      onClick={() => {
                        setFilters({ lcCode: row.code });
                        setLocationHelp([]);
                        focusControl('Book');
                      }}
                    >
                      {row.code} · {row.name}
                    </button>
                  ))}
                </div>
              )}
            </div>
            <LookupField
              label="Book"
              value={filters.bookCode}
              onChange={(value) => setFilters({ bookCode: value })}
              load={loadBooks}
              maxLength={8}
              focusAfter="Pr Code"
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
              options={CITY_OPTIONS}
              onChange={(value) => setFilters({ city: value })}
            />
            <ListField
              label="Area"
              value={filters.area}
              options={AREA_OPTIONS}
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
            {BUTTONS.map((button, index) => (
              <button
                key={button.mode}
                type="button"
                className={index === 0 ? 'primary' : 'ghost'}
                disabled={report.busy}
                onClick={() => {
                  if (button.mode === 'summary') {
                    void runMode('summary').then(() => setPrompt(true));
                  } else {
                    void runMode(button.mode);
                  }
                }}
              >
                {button.caption}
              </button>
            ))}
            <span className="spacer" />
            <button type="button" className="ghost" onClick={report.clear}>
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
            <p>Only Design Summery Report..</p>
            <button
              type="button"
              onClick={() => {
                setPrompt(false);
                void runMode('summary', true);
              }}
            >
              Yes
            </button>
            <button
              type="button"
              onClick={() => {
                setPrompt(false);
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
