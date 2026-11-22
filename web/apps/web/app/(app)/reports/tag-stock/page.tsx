'use client';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useRef, useState, type KeyboardEvent as ReactKeyEvent } from 'react';
import { get } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { isoToDesktop, parseDesktopDate } from './dateText';
import { TagStockGrid } from './TagStockGrid';
import { useTagStock } from './useTagStock';
import { IT_TYPES, type TagStockFilters, type TagStockTab, type TagStockView } from './types';
import { todayLocal } from '../../../../lib/localDate';

/**
 * Report → Tag Stock: the desktop RP_TAG form (MDI_FORM.cs:8891-8900), "Tag Wise" and "Tag Summ".
 *
 * Nothing runs on open; each mode button runs its own query (RP_TAG.cs:3977-4325): In/Out read the dated rows,
 * Stock/Mrp the signed-movement balance as of To (From is ignored), Apr the pending approvals, All the movement
 * history. Footer sums cover every row of the report (the API has no row cap) and follow the search box.
 * Keys: Escape closes (RP_TAG.cs:3865), Down/Up on a selector moves to the grid (:3871), Enter in a date moves on
 * after the date mask check (DC_Main.cs:1641), Alt+I/O/M/E/C/X and the first-letter mnemonics run the buttons.
 * Not here: the voucher zoom, Print window and Crystal layouts, the approval other-item columns (study gaps 10, 11, 13).
 */
const MODES: Array<{ tab: TagStockTab; label: string; alt: string }> = [
  { tab: 'stock', label: 'Stock Tag', alt: 's' },
  { tab: 'in', label: 'In Tag', alt: 'i' },
  { tab: 'out', label: 'Out Tag', alt: 'o' },
  { tab: 'mrp', label: 'Mrp Tag', alt: 'm' },
  { tab: 'apr', label: 'Apr Pending', alt: 'a' },
];

export default function TagStockPage() {
  const router = useRouter();
  const t = useTagStock();
  const { filters, setFilters, report, error, busy } = t;
  const [selected, setSelected] = useState(0);
  const [sizes, setSizes] = useState<string[]>([]);
  const [focusFrom, setFocusFrom] = useState(0);
  const grid = useRef<HTMLDivElement | null>(null);
  const fromRef = useRef<HTMLInputElement | null>(null);
  const toRef = useRef<HTMLInputElement | null>(null);
  const searchRef = useRef<HTMLInputElement | null>(null);
  const summ = filters.rptType === 'summ';

  useEffect(() => {
    let live = true;
    get<string[]>('/reports/tag-stock/sizes')
      .then((s) => live && setSizes(Array.isArray(s) ? s : []))
      .catch(() => undefined);
    return () => {
      live = false;
    };
  }, []);

  // Cancel returns the cursor to From once the cleared screen has rendered (RP_TAG.cs:3741).
  useEffect(() => {
    if (focusFrom > 0) fromRef.current?.focus();
  }, [focusFrom]);

  const rows = useMemo(() => {
    if (!report) return [];
    const q = filters.search.trim().toUpperCase();
    if (!q || report.view !== 'tag') return report.rows;
    return report.rows.filter((r) =>
      String(r.tagNo ?? '')
        .toUpperCase()
        .includes(q),
    );
  }, [report, filters.search]);

  const go = (tab: TagStockTab, view: TagStockView = 'tag') => {
    setSelected(0);
    void t.run(tab, summ && view === 'tag' ? 'item' : view);
  };
  const productStock = () => {
    setSelected(0);
    void t.run('stock', 'product');
  };
  const sixth = () => (summ ? productStock() : go('all'));
  const exit = () => router.back();

  /** The date mask: a typed date is checked on Enter; a bad one is refused, reset and kept selected. */
  const dateKey =
    (field: 'from' | 'to', next: React.RefObject<HTMLInputElement | null>) =>
    (e: ReactKeyEvent<HTMLInputElement>) => {
      if (e.key !== 'Enter') return;
      e.preventDefault();
      const parsed = parseDesktopDate(filters[field]);
      if ('error' in parsed) {
        t.setError(parsed.error);
        setFilters({ [field]: isoToDesktop(todayLocal()) } as Partial<TagStockFilters>);
        const input = e.currentTarget;
        setTimeout(() => input.select(), 0);
        return;
      }
      t.setError('');
      next.current?.focus();
    };

  const alt: Record<string, () => void> = {
    s: () => go('stock'),
    i: () => go('in'),
    o: () => go('out'),
    m: () => go('mrp'),
    a: () => go('apr'),
    l: sixth,
    e: () => t.exportAs('xlsx', filters.search),
    c: () => {
      t.reset();
      setSelected(0);
      setFocusFrom((n) => n + 1);
    },
    x: exit,
  };
  const onScreenKey = (e: ScreenKeyEvent) => {
    if (e.defaultPrevented) return;
    if (e.key === 'Escape') {
      if (document.querySelector('[data-lookup-open]')) return;
      e.preventDefault();
      exit();
    }
  };
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKey);
  const onKeyDown = (e: ReactKeyEvent<HTMLDivElement>) => {
    onScreenKey(e);
    if (e.altKey && !e.ctrlKey && !e.metaKey) {
      const letter = e.code.startsWith('Key') ? e.code.slice(3).toLowerCase() : e.key.toLowerCase();
      const fn = alt[letter];
      if (fn) {
        e.preventDefault();
        fn();
        return;
      }
    }
    if ((e.key === 'ArrowDown' || e.key === 'ArrowUp') && !e.defaultPrevented) {
      const el = e.target as HTMLElement;
      const textual = el.tagName === 'INPUT' && (el as HTMLInputElement).type === 'text';
      if (
        textual &&
        !document.querySelector('[data-lookup-open]') &&
        el.closest('[data-tag-stock-filters]')
      ) {
        e.preventDefault();
        grid.current?.focus();
      }
    }
  };

  const field = (label: string, id: string, node: React.ReactNode, wide = false) => (
    <div className="field" style={wide ? { flex: 2 } : undefined}>
      <label htmlFor={id}>{label}</label>
      {node}
    </div>
  );

  return (
    <div ref={screenRef} onKeyDown={onKeyDown}>
      <h1>Tag Stock</h1>
      <div className="panel" data-tag-stock-filters>
        <div className="row" style={{ flexWrap: 'wrap' }}>
          {field(
            'From',
            'ts-from',
            <input
              id="ts-from"
              ref={fromRef}
              type="text"
              inputMode="numeric"
              autoFocus
              value={filters.from}
              onChange={(e) => setFilters({ from: e.target.value })}
              onKeyDown={dateKey('from', toRef)}
              style={{ width: 110 }}
            />,
          )}
          {field(
            'To',
            'ts-to',
            <input
              id="ts-to"
              ref={toRef}
              type="text"
              inputMode="numeric"
              value={filters.to}
              onChange={(e) => setFilters({ to: e.target.value })}
              onKeyDown={dateKey('to', searchRef)}
              style={{ width: 110 }}
            />,
          )}
          {field(
            'Search',
            'ts-search',
            <input
              id="ts-search"
              ref={searchRef}
              type="text"
              value={filters.search}
              onChange={(e) =>
                setFilters({ search: e.target.value.toUpperCase().replace(/'/g, '') })
              }
              style={{ width: 120 }}
            />,
          )}
          {field(
            'It Type',
            'ts-ittype',
            <select
              id="ts-ittype"
              value={filters.itType}
              onChange={(e) => setFilters({ itType: e.target.value })}
            >
              {IT_TYPES.map((o) => (
                <option key={o.value} value={o.value}>
                  {o.label}
                </option>
              ))}
            </select>,
          )}
          <div className="field">
            <label>Item</label>
            <LookupPicker
              entity="items"
              ariaLabel="Item"
              value={filters.itCode}
              onChange={(v) => setFilters({ itCode: v })}
              onPick={(r) => setFilters({ itCode: String(r.code) })}
              advanceOnPick={false}
            />
          </div>
          <div className="field">
            <label>Product</label>
            <LookupPicker
              entity="products"
              ariaLabel="Product"
              value={filters.prCode}
              onChange={(v) => setFilters({ prCode: v })}
              onPick={(r) => setFilters({ prCode: String(r.code) })}
              advanceOnPick={false}
            />
          </div>
          {field(
            'TagNo',
            'ts-tagno',
            <input
              id="ts-tagno"
              type="text"
              value={filters.tagNo}
              onChange={(e) =>
                setFilters({ tagNo: e.target.value.toUpperCase().replace(/'/g, '') })
              }
              onKeyDown={(e) => {
                if (e.key === 'Enter' && filters.tagNo.trim()) {
                  e.preventDefault();
                  sixth();
                }
              }}
              style={{ width: 110 }}
            />,
          )}
        </div>
        <div className="row" style={{ marginTop: 8, flexWrap: 'wrap' }}>
          {MODES.map((m) => (
            <button
              key={m.tab}
              type="button"
              className="ghost"
              onClick={() => go(m.tab)}
              disabled={busy}
            >
              {m.label}
            </button>
          ))}
          <button type="button" className="ghost" onClick={sixth} disabled={busy}>
            {summ ? 'Product Stk' : 'All Tag'}
          </button>
          <button
            type="button"
            className="ghost"
            onClick={() => t.exportAs('xlsx', filters.search)}
          >
            Excel
          </button>
          <button type="button" className="ghost" onClick={() => t.exportAs('csv', filters.search)}>
            CSV
          </button>
          <button type="button" className="ghost" onClick={alt.c}>
            Cancel
          </button>
          <button type="button" className="ghost" onClick={exit}>
            Exit
          </button>
        </div>
        <div className="row" style={{ marginTop: 8, flexWrap: 'wrap' }}>
          <div className="field">
            <label>Group</label>
            <LookupPicker
              entity="groups"
              ariaLabel="Group"
              value={filters.grCode}
              onChange={(v) => setFilters({ grCode: v })}
              onPick={(r) => setFilters({ grCode: String(r.code) })}
              advanceOnPick={false}
            />
          </div>
          {field(
            'Size',
            'ts-size',
            <select
              id="ts-size"
              value={filters.size}
              onChange={(e) => setFilters({ size: e.target.value })}
            >
              <option value="" />
              {sizes.map((s) => (
                <option key={s} value={s}>
                  {s}
                </option>
              ))}
            </select>,
          )}
          {field(
            'Location',
            'ts-location',
            <input
              id="ts-location"
              type="text"
              value={filters.lcCode}
              onChange={(e) =>
                setFilters({ lcCode: e.target.value.toUpperCase().replace(/'/g, '') })
              }
              onKeyDown={(e) => {
                if (e.key === 'Enter') {
                  e.preventDefault();
                  t.clearGrid();
                }
              }}
              style={{ width: 60 }}
            />,
          )}
          <div className="field">
            <label>Book</label>
            <LookupPicker
              entity="books"
              ariaLabel="Book"
              value={filters.bookCode}
              onChange={(v) => setFilters({ bookCode: v })}
              onPick={(r) => setFilters({ bookCode: String(r.code) })}
              advanceOnPick={false}
            />
          </div>
          {field(
            'RptType',
            'ts-rpttype',
            <select
              id="ts-rpttype"
              value={filters.rptType}
              onChange={(e) => {
                setFilters({ rptType: e.target.value as 'tag' | 'summ' });
                t.clearGrid();
              }}
            >
              <option value="tag">Tag Wise</option>
              <option value="summ">Tag Summ</option>
            </select>,
          )}
        </div>
      </div>
      {error && (
        <div className="msg err" role="alert">
          {error}
        </div>
      )}
      {report && (
        <TagStockGrid
          columns={report.columns}
          rows={rows}
          selected={selected}
          onSelect={setSelected}
          gridRef={grid}
        />
      )}
    </div>
  );
}
