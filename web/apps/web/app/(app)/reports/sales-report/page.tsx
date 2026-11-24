'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { useBusinessScope } from '../../../../components/BusinessScope';
import {
  DesktopDateInput,
  type DesktopDateInputHandle,
} from '../../../../components/DesktopDateInput';
import { get } from '../../../../lib/api';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { BookPicker, type BookRow } from './BookPicker';
import { ListField } from './ListField';
import { LookupField, focusControl, type HelpRow } from './LookupField';
import { SalesButtons, keyOf } from './SalesButtons';
import { SalesReportGrid, openPrintPreview } from './SalesReportGrid';
import {
  FILTER_CAPTIONS,
  ITEM_TYPES,
  SALES_BUTTONS,
  SALES_PROMPTS,
  type SalesButton,
  type SalesFilters,
} from './types';
import { useSalesReport } from './useSalesReport';

/**
 * Report → Sales Report: the desktop RP_ALL form with the caption "Sales Report" (MDI_FORM.cs:8901-8910,
 * RP_ALL.cs:6676-6698). Selectors in tab order (:4778-6549), PanelSale buttons (:4364-4378); the report itself is the
 * shared RP_ALL engine's (GET /reports/sales-report). Backed by docs/parity/rpall-sales-inventory.md.
 */
const RESTORE_KEY = 'sales-report:restore';

const lookup = (entity: string) => (term: string) =>
  get<HelpRow[]>(`/lookup/${entity}?q=${encodeURIComponent(term)}&limit=20`);
const options = (rows: Array<{ code: unknown; name?: unknown }>, join = false): string[] => [
  ...new Set(
    rows
      .map((row) =>
        join
          ? `${String(row.code ?? '').trim()}-${String(row.name ?? '').trim()}`
          : String(row.code ?? '').trim(),
      )
      .filter((text) => text && text !== '-'),
  ),
];

export default function SalesReportPage() {
  const router = useRouter();
  const { lcCode, coYear } = useBusinessScope();
  const [employees, setEmployees] = useState<string[]>([]);
  const [cities, setCities] = useState<string[]>([]);
  const [areas, setAreas] = useState<string[]>([]);
  const report = useSalesReport(lcCode, employees);
  const { filters, setFilters, result, execute } = report;
  const [prompt, setPrompt] = useState<{
    button: SalesButton;
    dates: Pick<SalesFilters, 'fromDate' | 'toDate'>;
  } | null>(null);
  const [bookRows, setBookRows] = useState<BookRow[]>([]);
  const [bookPanel, setBookPanel] = useState(false);
  const [bookMessage, setBookMessage] = useState('');
  const [locationRows, setLocationRows] = useState<Promise<HelpRow[]> | null>(null);
  const fromDate = useRef<DesktopDateInputHandle>(null);
  const toDate = useRef<DesktopDateInputHandle>(null);
  const lastButton = useRef<HTMLButtonElement | null>(null);

  const onEscape = useCallback(
    (event: ScreenKeyEvent) => {
      if (event.key !== 'Escape' || event.defaultPrevented) return;
      event.preventDefault();
      if (prompt) {
        setPrompt(null);
        lastButton.current?.focus();
        return;
      }
      router.back();
    },
    [router, prompt],
  );
  const screenRef = useScreenEscape<HTMLFormElement>(onEscape);

  // The City, Area and Employ combos load once when the form opens (RP_ALL.cs:7087-7156).
  useEffect(() => {
    let live = true;
    const load = (entity: string, set: (values: string[]) => void, join = false) =>
      get<Array<{ code: unknown; name?: unknown }>>(`/lookup/${entity}?limit=50`)
        .then((rows) => live && set(options(rows, join).sort()))
        .catch(() => undefined);
    void load('cities', setCities);
    void load('areas', setAreas);
    void load('employees', setEmployees, true);
    // Back from a zoom to a voucher: the form shows the report it had (the desktop form stays open under the voucher).
    try {
      const saved = sessionStorage.getItem(RESTORE_KEY);
      if (saved) {
        sessionStorage.removeItem(RESTORE_KEY);
        const { filters: previous, query } = JSON.parse(saved) as {
          filters: SalesFilters;
          query: string;
        };
        setFilters(previous);
        void execute(query);
      }
    } catch {
      // storage unavailable: the form simply opens empty
    }
    return () => {
      live = false;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  /** SetDate on both boxes (RP_ALL.cs:7510-7540); a refusal shows its message and stops the run. */
  const commitDates = () => {
    const from = fromDate.current ? fromDate.current.commit() : filters.fromDate;
    if (!from) return null;
    const to = toDate.current ? toDate.current.commit() : filters.toDate;
    return to ? { fromDate: from, toDate: to } : null;
  };
  const start = (button: SalesButton) => {
    if (!button.mode) return;
    const dates = commitDates();
    if (!dates) return;
    if (button.prompt) setPrompt({ button, dates });
    else void report.run(button.mode, {}, dates);
  };
  const answer = (yes: boolean) => {
    if (!prompt?.button.mode) return;
    const { button, dates } = prompt;
    setPrompt(null);
    lastButton.current?.focus();
    void report.run(
      button.mode!,
      button.prompt === 'order' ? { orderOnly: yes } : { returns: yes },
      dates,
    );
  };

  // Alt + the caption's mnemonic runs the button (the first one wins, as the duplicates cycle in WinForms).
  const startRef = useRef(start);
  startRef.current = start;
  useEffect(() => {
    const onKey = (event: KeyboardEvent) => {
      if (!event.altKey || event.ctrlKey || event.metaKey || !event.code.startsWith('Key')) return;
      const letter = event.code.slice(3);
      const hit = SALES_BUTTONS.find((button) => button.mode && keyOf(button.caption) === letter);
      if (!hit) return;
      event.preventDefault();
      startRef.current(hit);
    };
    document.addEventListener('keydown', onKey);
    return () => document.removeEventListener('keydown', onKey);
  }, []);

  const loadLocations = useCallback(() => {
    const rows =
      locationRows ??
      get<Array<{ LC_CODE: string; LC_NAME: string | null }>>('/context/locations').then((found) =>
        found.map((row) => ({ code: row.LC_CODE, name: row.LC_NAME ?? '' })),
      );
    if (!locationRows) setLocationRows(rows);
    return rows;
  }, [locationRows]);

  const toggleBookSelect = (checked: boolean) => {
    setFilters({ selectBook: checked });
    setBookPanel(checked);
    if (checked && bookRows.length === 0)
      void get<Array<{ code: string; name?: string }>>('/lookup/books?limit=50')
        .then((rows) =>
          setBookRows(
            rows.map((row) => ({ code: String(row.code), name: String(row.name ?? '') })),
          ),
        )
        .catch(() => undefined);
  };

  const zoom = (voucherKey: string) => {
    const [location, book, number] = voucherKey.split('|');
    if (!book || !number || !report.ranQuery) return;
    try {
      sessionStorage.setItem(RESTORE_KEY, JSON.stringify({ filters, query: report.ranQuery }));
    } catch {
      // the form then opens empty on return
    }
    const target = new URLSearchParams({ vchNo: number, coBook: book, lcCode: location ?? lcCode });
    router.push(`/txn/sales?${target.toString()}`);
  };

  const ignored = (result?.ignoredFilters ?? []).map((key) => FILTER_CAPTIONS[key] ?? key);

  return (
    <div>
      <h1>Sales Report</h1>
      <form
        ref={screenRef}
        aria-label="Sales Report"
        onKeyDown={onEscape}
        onSubmit={(event) => event.preventDefault()}
      >
        <div className="panel">
          <div className="row">
            <div className="field">
              <DesktopDateInput
                ref={fromDate}
                id="sr-from"
                label="From Date"
                coYear={coYear}
                value={filters.fromDate}
                autoFocus
                onChange={(iso) => setFilters({ fromDate: iso })}
                onAdvance={() => toDate.current?.focus()}
              />
            </div>
            <div className="field">
              <DesktopDateInput
                ref={toDate}
                id="sr-to"
                label="To Date"
                coYear={coYear}
                value={filters.toDate}
                onChange={(iso) => setFilters({ toDate: iso })}
                onAdvance={() => focusControl(lcCode === '00' ? 'lc Code' : 'Book')}
              />
            </div>
            <LookupField
              label="lc Code"
              value={filters.lcCode}
              disabled={lcCode !== '00'}
              maxLength={8}
              onChange={(value) => setFilters({ lcCode: value })}
              load={loadLocations}
              focusAfter="Book"
            />
            <LookupField
              label="Book"
              value={filters.bookCode}
              maxLength={8}
              onChange={(value) => setFilters({ bookCode: value })}
              load={lookup('books')}
              focusAfter="Pr Code"
            />
            <LookupField
              label="Pr Code"
              value={filters.prCode}
              maxLength={10}
              onChange={(value) => setFilters({ prCode: value })}
              load={lookup('products')}
              focusAfter="Gr Code"
              focusEmpty="City"
            />
            <LookupField
              label="Gr Code"
              value={filters.grCode}
              maxLength={10}
              onChange={(value) => setFilters({ grCode: value })}
              load={lookup('groups')}
              focusAfter="Party Code"
            />
            <LookupField
              label="Party Code"
              value={filters.partyCode}
              maxLength={8}
              onChange={(value) => setFilters({ partyCode: value })}
              load={lookup('accounts')}
              focusAfter="City"
            />
            <ListField
              label="City"
              value={filters.city}
              options={cities}
              onChange={(value) => setFilters({ city: value })}
            />
            <ListField
              label="Area"
              value={filters.area}
              options={areas}
              onChange={(value) => setFilters({ area: value })}
            />
            <div className="field" style={{ minWidth: 130 }}>
              <label htmlFor="sr-item-type">Item Type</label>
              <select
                id="sr-item-type"
                aria-label="Item Type"
                value={filters.itemType}
                onChange={(event) => setFilters({ itemType: event.target.value })}
                onKeyDown={(event) => {
                  if (event.key === 'Enter') {
                    event.preventDefault();
                    focusControl('Employ');
                  }
                }}
              >
                {ITEM_TYPES.map((type) => (
                  <option key={type} value={type}>
                    {type}
                  </option>
                ))}
              </select>
            </div>
            {/* Shown for the Sales Report caption (RP_ALL.cs:6679-6681); State only for DM019NEDM, never in Lite. */}
            <ListField
              label="Employ"
              value={filters.employ}
              options={employees}
              onChange={(value) => setFilters({ employ: value })}
            />
            <div className="field">
              <label htmlFor="sr-select-book">Select Book</label>
              <input
                id="sr-select-book"
                type="checkbox"
                aria-label="Select Book"
                checked={filters.selectBook}
                onChange={(event) => toggleBookSelect(event.target.checked)}
              />
            </div>
          </div>
          {bookPanel && (
            <BookPicker
              rows={bookRows}
              picked={filters.books}
              onOk={(codes) => {
                setFilters({ books: codes });
                setBookPanel(false);
                setBookMessage(
                  codes.length ? 'Book Selection is Ok...' : 'Book Selection Not Done...',
                );
              }}
              onCancel={() => {
                setFilters({ books: [] });
                setBookPanel(false);
              }}
            />
          )}
          <SalesButtons
            busy={report.busy}
            onRun={(button, element) => {
              lastButton.current = element;
              start(button);
            }}
          />
          <div className="row" style={{ marginTop: 8 }}>
            <button
              type="button"
              className="ghost"
              disabled={!result}
              onClick={() => result && openPrintPreview(result)}
            >
              <u>P</u>rint
            </button>
            <button
              type="button"
              className="ghost"
              onClick={() => {
                report.clear();
                setPrompt(null);
                setBookPanel(false);
                setBookMessage('');
                focusControl('From Date');
              }}
            >
              <u>C</u>ancel
            </button>
            <button type="button" className="ghost" onClick={() => router.back()}>
              E<u>x</u>it
            </button>
            <span className="spacer" />
            <button
              type="button"
              className="ghost"
              disabled={!report.ranQuery}
              onClick={() => void report.download('csv')}
            >
              CSV
            </button>
            <button
              type="button"
              className="ghost"
              disabled={!report.ranQuery}
              onClick={() => void report.download('xlsx')}
            >
              Excel
            </button>
          </div>
        </div>
        {report.error && (
          <div className="msg err" role="alert">
            {report.error}
          </div>
        )}
        {bookMessage && (
          <div className="panel" role="alertdialog" aria-label={bookMessage}>
            <p style={{ margin: '0 0 8px' }}>{bookMessage}</p>
            <button type="button" onClick={() => setBookMessage('')}>
              OK
            </button>
          </div>
        )}
        {prompt?.button.prompt && (
          <div role="dialog" aria-label="DataCareNext">
            <h2>DataCareNext</h2>
            <p>{SALES_PROMPTS[prompt.button.prompt].text}</p>
            {(['Yes', 'No'] as const).map((choice) => (
              <button
                key={choice}
                type="button"
                autoFocus={choice === SALES_PROMPTS[prompt.button.prompt!].defaultAnswer}
                onClick={() => answer(choice === 'Yes')}
              >
                {choice}
              </button>
            ))}
          </div>
        )}
      </form>
      {ignored.length > 0 && (
        <div className="msg" role="status">
          Selectors ignored by this report: {ignored.join(', ')}
        </div>
      )}
      {result && <SalesReportGrid report={result} onZoom={zoom} />}
    </div>
  );
}
