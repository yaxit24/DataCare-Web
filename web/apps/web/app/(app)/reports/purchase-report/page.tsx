'use client';
import { useRouter } from 'next/navigation';
import { useEffect, useRef, type KeyboardEvent } from 'react';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';
import { focusNext } from '../../../../components/focus';
import { PurchaseReportGrid } from './PurchaseReportGrid';
import { usePurchaseReport } from './usePurchaseReport';
import { ITEM_TYPES, PURCHASE_MODES, type PurchaseFilters, type PurchaseMode } from './types';

/**
 * Report → Purchase Rpt: the desktop RP_ALL form in its "Purchase Rpt" caption (MDI_FORM.cs:8911-8920,
 * RP_ALL.cs:6704-6707 shows PanelPurc). A dedicated static route so it takes precedence over the generic `[report]`
 * page, which cannot grow and cannot express the seven RP_ALL templates.
 *
 * Keyboard (RP_ALL.cs:7242-7265, 7291-7545): Enter moves From, To, lc Code, Book, Pr Code, Gr Code, Party, City,
 * Area and Item Type in tab order and runs from the last; F1 opens a lookup's help; Esc closes the form. The only
 * `button.primary` is Run; Print, Download PDF, Excel and CSV act only after a successful run.
 */
type LookupKey = 'lcCode' | 'coBook' | 'prCode' | 'grCode' | 'acCode';
const LOOKUPS: ReadonlyArray<{
  id: string;
  label: string;
  entity: string;
  key: LookupKey;
}> = [
  { id: 'location', label: 'lc Code', entity: 'locations', key: 'lcCode' },
  { id: 'book', label: 'Book', entity: 'books', key: 'coBook' },
  { id: 'product', label: 'Pr Code', entity: 'products', key: 'prCode' },
  { id: 'group', label: 'Gr Code', entity: 'groups', key: 'grCode' },
  { id: 'party', label: 'Party Code', entity: 'accounts', key: 'acCode' },
];

const fieldId = (id: string) => `purchase-report-${id}`;

export default function PurchaseReportPage() {
  const router = useRouter();
  const scope = useBusinessScope();
  const r = usePurchaseReport(scope.lcCode);
  const { filters, setFilters, options, result, error, busy } = r;
  const panelRef = useRef<HTMLDivElement>(null);

  // Esc closes the form (RP_ALL.cs:7257-7265) unless a lookup list is open: that list takes the Esc first.
  const back = useRef(router.back);
  back.current = router.back;
  useEffect(() => {
    const onKey = (e: globalThis.KeyboardEvent) => {
      if (e.key !== 'Escape' || e.defaultPrevented) return;
      if (document.querySelector('[data-lookup-open]')) return;
      e.preventDefault();
      back.current();
    };
    document.addEventListener('keydown', onKey);
    return () => document.removeEventListener('keydown', onKey);
  }, []);

  /**
   * Enter walks the selectors in tab order at once, as the desktop's KeyDown moves on while its code lookup runs
   * (RP_ALL.cs:7291-7545); Enter on the last selector runs the report. A lookup box resolves its typed code in the
   * background (LookupPicker) and never moves the focus itself, so a slow answer cannot pull the focus back.
   */
  const onEnter = (e: KeyboardEvent<HTMLDivElement>) => {
    if (e.key !== 'Enter') return;
    const target = e.target as HTMLElement;
    if (target instanceof HTMLButtonElement) return;
    e.preventDefault();
    if (target.id === fieldId('item-type')) {
      void r.run();
      return;
    }
    focusNext(target, panelRef.current ?? undefined);
  };

  const set = <K extends keyof PurchaseFilters>(key: K) => ({
    value: filters[key] as string,
    onChange: (v: PurchaseFilters[K]) => setFilters({ [key]: v } as Partial<PurchaseFilters>),
  });

  const lookup = (spec: (typeof LOOKUPS)[number]) => (
    <div className="field" key={spec.id}>
      <label htmlFor={fieldId(spec.id)}>{spec.label}</label>
      <LookupPicker
        id={fieldId(spec.id)}
        entity={spec.entity}
        ariaLabel={spec.label}
        value={filters[spec.key]}
        placeholder="F1"
        resolveTypedCode
        advanceOnPick={false}
        openOnFocus={false}
        onChange={(v) => setFilters({ [spec.key]: v.toUpperCase() } as Partial<PurchaseFilters>)}
        onPick={(row) => setFilters({ [spec.key]: String(row.code) } as Partial<PurchaseFilters>)}
      />
    </div>
  );
  const lookupOf = (id: string) => LOOKUPS.find((l) => l.id === id)!;

  const select = (
    id: string,
    label: string,
    key: 'city' | 'area',
    values: string[],
  ): React.ReactNode => (
    <div className="field">
      <label htmlFor={fieldId(id)}>{label}</label>
      <select
        id={fieldId(id)}
        value={filters[key]}
        onChange={(e) => setFilters({ [key]: e.target.value } as Partial<PurchaseFilters>)}
      >
        <option value=""></option>
        {values.map((v) => (
          <option key={v} value={v}>
            {v}
          </option>
        ))}
      </select>
    </div>
  );

  return (
    <div>
      <h1>Purchase Rpt</h1>
      <div className="panel" ref={panelRef} onKeyDown={onEnter}>
        <div className="row">
          <div className="field">
            <label htmlFor={fieldId('mode')}>Report</label>
            <select
              id={fieldId('mode')}
              value={filters.mode}
              onChange={(e) => setFilters({ mode: e.target.value as PurchaseMode })}
            >
              {PURCHASE_MODES.map((m) => (
                <option key={m.value} value={m.value}>
                  {m.label}
                </option>
              ))}
            </select>
          </div>
          <div className="field">
            <label htmlFor={fieldId('from')}>From</label>
            <input
              id={fieldId('from')}
              type="date"
              value={set('fromDate').value}
              onChange={(e) => set('fromDate').onChange(e.target.value)}
            />
          </div>
          <div className="field">
            <label htmlFor={fieldId('to')}>To</label>
            <input
              id={fieldId('to')}
              type="date"
              value={set('toDate').value}
              onChange={(e) => set('toDate').onChange(e.target.value)}
            />
          </div>
          {lookup(lookupOf('location'))}
          {lookup(lookupOf('book'))}
        </div>
        <div className="row">
          {lookup(lookupOf('product'))}
          {lookup(lookupOf('group'))}
          {lookup(lookupOf('party'))}
          {select('city', 'City', 'city', options.cities)}
          {select('area', 'Area', 'area', options.areas)}
          <div className="field">
            <label htmlFor={fieldId('item-type')}>Item Type</label>
            <select
              id={fieldId('item-type')}
              value={filters.itemType}
              onChange={(e) => setFilters({ itemType: e.target.value })}
            >
              {ITEM_TYPES.map((t) => (
                <option key={t.value} value={t.value}>
                  {t.label}
                </option>
              ))}
            </select>
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="primary" onClick={() => void r.run()} disabled={busy}>
              {busy ? 'Running…' : 'Run'}
            </button>
          </div>
        </div>
        {result && (
          <div className="row" style={{ marginTop: 8 }}>
            <button type="button" className="ghost" onClick={r.print} disabled={!r.ranQuery}>
              Print
            </button>
            <button
              type="button"
              className="ghost"
              onClick={() => void r.pdf()}
              disabled={!r.ranQuery}
            >
              Download PDF
            </button>
            <button type="button" className="ghost" onClick={r.excel} disabled={!r.ranQuery}>
              Excel
            </button>
            <button type="button" className="ghost" onClick={r.csv} disabled={!r.ranQuery}>
              CSV
            </button>
          </div>
        )}
      </div>

      {error && (
        <div className="msg err" role="alert" data-testid="purchase-report-error">
          {error}
        </div>
      )}
      {result && result.ignoredFilters.length > 0 && (
        <div className="msg" role="status">
          {result.caption} does not use {result.ignoredFilters.join(', ')}; the desktop leaves
          {result.ignoredFilters.length > 1 ? ' them' : ' it'} out of this report too.
        </div>
      )}
      {result && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2 style={{ marginTop: 0 }}>{result.title}</h2>
          <PurchaseReportGrid result={result} />
        </div>
      )}
    </div>
  );
}
