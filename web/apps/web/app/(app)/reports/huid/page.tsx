'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { useBusinessScope } from '../../../../components/BusinessScope';
import {
  DesktopDateInput,
  type DesktopDateInputHandle,
} from '../../../../components/DesktopDateInput';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { get } from '../../../../lib/api';
import { HuidGrid } from './HuidGrid';
import { HuidLookupField, focusControl } from './HuidLookupField';
import { todayIso, useHuidReport } from './useHuidReport';
import { HUID_VIEWS, type HelpRow, type HuidFilters, type HuidView } from './types';

/**
 * Report → HuId Report: the desktop RP_HUID form, caption "Tag Stock With HuId"
 * (RP_HUID.cs:1067 `lblBook.Text = "Tag Stock With HuId";`). A static route, so it takes precedence over
 * the generic `[report]` page, which cannot express RP_HUID's three views and their date rules.
 *
 * Controls follow the desktop's tab order (study Screen table): From, To (both on the system date,
 * RP_HUID.cs:1620-1621), Search, Item Type (Gold/Silver, :1555-1564), Product, Group, Tag No, the grid,
 * the three view buttons (:2153-2163 Tag_Summ("Stock"/"In"/"Out")), HuId Type and Ac Code. The bottom
 * buttons are Print, Excel, Cancel (clears the screen, :1744) and Exit; the desktop's Delete button does
 * nothing (:1369-1371) and is not ported. Alt plus the caption mnemonic runs each (the `&` captions,
 * :1121/:1177/:1149/:1049/:1036/:1023/:996).
 */
// The desktop help grid lists every row (RP_HUID.cs:2689-2729); the open list asks for the API's 50-row cap.
const lookup = (entity: string) => (term: string) =>
  get<HelpRow[]>(`/lookup/${entity}?q=${encodeURIComponent(term)}&limit=${term ? 20 : 50}`);

/** The desktop caption mnemonics: the letter the `&` marks, for the Alt shortcuts. */
function mnemonic(caption: string, letter: string) {
  const at = caption.toUpperCase().indexOf(letter.toUpperCase());
  if (at < 0) return caption;
  return (
    <>
      {caption.slice(0, at)}
      <u>{caption[at]}</u>
      {caption.slice(at + 1)}
    </>
  );
}

export default function HuidReportPage() {
  const router = useRouter();
  const { coYear } = useBusinessScope();
  const [products, setProducts] = useState<HelpRow[]>([]);
  const [groups, setGroups] = useState<HelpRow[]>([]);
  const report = useHuidReport(products, groups);
  const {
    filters,
    setFilters,
    result,
    busy,
    error,
    status,
    run,
    searchAgain,
    print,
    excel,
    cancel,
  } = report;
  const fromDate = useRef<DesktopDateInputHandle>(null);
  const toDate = useRef<DesktopDateInputHandle>(null);
  const grid = useRef<HTMLDivElement>(null);

  // The product and group lists the desktop reads at load (RP_HUID.cs:1574 PRODUCT_MAST, :1597 GROUP_MAST).
  useEffect(() => {
    let live = true;
    void get<HelpRow[]>('/lookup/products?limit=50')
      .then((rows) => live && setProducts(rows))
      .catch(() => undefined);
    void get<HelpRow[]>('/lookup/groups?limit=50')
      .then((rows) => live && setGroups(rows))
      .catch(() => undefined);
    return () => {
      live = false;
    };
  }, [setProducts, setGroups]);

  // The desktop opens with both dates on the system date (RP_HUID.cs:1620-1621). Set after mount so the
  // server render and the hydrated render agree; the value still comes from the browser's clock.
  useEffect(() => {
    setFilters({ fromDate: todayIso(), toDate: todayIso() });
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  /** SetDate on both boxes, then the view's query (the desktop runs Tag_Summ on the button click). */
  const startView = useCallback(
    (view: HuidView) => {
      const from = fromDate.current ? fromDate.current.commit() : filters.fromDate;
      if (!from) return; // SetDate refused; its message is up and the run stops
      const to = toDate.current ? toDate.current.commit() : filters.toDate;
      if (!to) return;
      void run(view, { fromDate: from, toDate: to });
    },
    [filters.fromDate, filters.toDate, run],
  );

  const onScreenKey = useCallback(
    (event: ScreenKeyEvent) => {
      if (event.defaultPrevented) return;
      // An open lookup help owns its keys first (the desktop help is modal).
      if (document.querySelector('[data-lookup-open="true"]')) return;
      // Up and Down arrows move the focus to the grid (RP_HUID.cs:1736-1738, form KeyPreview).
      if (event.key === 'ArrowUp' || event.key === 'ArrowDown') {
        event.preventDefault();
        grid.current?.focus();
        return;
      }
      if (event.key !== 'Escape') return;
      event.preventDefault();
      router.back();
    },
    [router],
  );
  const screenRef = useScreenEscape<HTMLFormElement>(onScreenKey);

  /** Alt + the caption mnemonic runs the button, as the desktop `&` captions do. */
  const actions = useRef({ startView, print, excel, cancel, back: () => router.back() });
  actions.current = { startView, print, excel, cancel, back: () => router.back() };
  useEffect(() => {
    const onKey = (event: KeyboardEvent) => {
      if (!event.altKey || event.ctrlKey || event.metaKey || !event.code.startsWith('Key')) return;
      const letter = event.code.slice(3).toUpperCase();
      const view = HUID_VIEWS.find((button) => button.key === `Key${letter}`);
      if (view) {
        event.preventDefault();
        actions.current.startView(view.view);
        return;
      }
      const table: Record<string, () => void> = {
        P: actions.current.print,
        E: actions.current.excel,
        C: actions.current.cancel,
        X: actions.current.back,
      };
      const hit = table[letter];
      if (!hit) return;
      event.preventDefault();
      hit();
    };
    document.addEventListener('keydown', onKey);
    return () => document.removeEventListener('keydown', onKey);
  }, []);

  const setTagNo = (value: string) => setFilters({ tagNo: value });
  const setAcCode = (value: string) => setFilters({ acCode: value });

  return (
    <div>
      <h1>Tag Stock With HuId</h1>
      <form
        ref={screenRef}
        aria-label="Tag Stock With HuId"
        onKeyDown={onScreenKey}
        onSubmit={(event) => event.preventDefault()}
      >
        <div className="panel">
          <div className="row">
            <div className="field">
              <DesktopDateInput
                ref={fromDate}
                id="huid-from"
                label="From"
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
                id="huid-to"
                label="To"
                coYear={coYear}
                value={filters.toDate}
                onChange={(iso) => setFilters({ toDate: iso })}
                onAdvance={() => focusControl('Search')}
              />
            </div>
            <div className="field" style={{ minWidth: 150 }}>
              <label htmlFor="huid-search">Search</label>
              <input
                id="huid-search"
                aria-label="Search"
                autoComplete="off"
                value={filters.search}
                onChange={(event) => searchAgain(event.target.value)}
                onKeyDown={(event) => {
                  // Enter leaves the box for the next control, as the desktop's Tab does.
                  if (event.key === 'Enter') {
                    event.preventDefault();
                    focusControl('Item Type');
                  }
                }}
              />
            </div>
            <div className="field">
              <label htmlFor="huid-item-type">Item Type</label>
              <select
                id="huid-item-type"
                value={filters.itemType}
                onChange={(event) =>
                  setFilters({ itemType: event.target.value === 'S' ? 'S' : 'G' })
                }
              >
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
            <div className="field">
              <label htmlFor="huid-product">Product</label>
              <input
                id="huid-product"
                aria-label="Product"
                autoComplete="off"
                maxLength={40}
                list="huid-products"
                value={filters.product}
                onChange={(event) => setFilters({ product: event.target.value })}
              />
              <datalist id="huid-products">
                {products.map((row) => (
                  <option key={row.code} value={row.name} />
                ))}
              </datalist>
            </div>
            <div className="field">
              <label htmlFor="huid-group">Group</label>
              <input
                id="huid-group"
                aria-label="Group"
                autoComplete="off"
                maxLength={40}
                list="huid-groups"
                value={filters.group}
                onChange={(event) => setFilters({ group: event.target.value })}
              />
              <datalist id="huid-groups">
                {groups.map((row) => (
                  <option key={row.code} value={row.name} />
                ))}
              </datalist>
            </div>
            <HuidLookupField
              label="Tag No"
              value={filters.tagNo}
              maxLength={15}
              onChange={setTagNo}
              load={lookup('tags')}
            />
            <div className="field">
              <label htmlFor="huid-hallmark">HuId Type</label>
              <select
                id="huid-hallmark"
                value={filters.hallmark}
                onChange={(event) =>
                  setFilters({
                    hallmark: event.target.value as HuidFilters['hallmark'],
                  })
                }
              >
                <option value="all">All</option>
                <option value="with">With HuId</option>
                <option value="without">Without HuId</option>
              </select>
            </div>
            <HuidLookupField
              label="Ac Code"
              value={filters.acCode}
              maxLength={8}
              selectAllOnResolve
              onChange={setAcCode}
              load={lookup('accounts')}
            />
          </div>
          <div className="row" style={{ marginTop: 8 }}>
            {HUID_VIEWS.map((button) => (
              <button
                type="button"
                key={button.view}
                className="ghost"
                disabled={busy}
                aria-keyshortcuts={`Alt+${button.caption[0]}`}
                onClick={() => startView(button.view)}
              >
                {mnemonic(button.caption, button.caption[0])}
              </button>
            ))}
          </div>
        </div>

        {error && (
          <div className="msg err" role="alert">
            {error}
          </div>
        )}
        {!error && status && (
          <div className="msg" role="status">
            {status}
          </div>
        )}

        <div className="panel" style={{ marginTop: 8, overflow: 'auto' }}>
          <HuidGrid ref={grid} result={result} />
        </div>

        <div className="row" style={{ marginTop: 8 }}>
          <button type="button" className="ghost" onClick={print} disabled={!result}>
            {mnemonic('Print', 'P')}
          </button>
          <button type="button" className="ghost" onClick={excel} disabled={!result}>
            {mnemonic('Excel', 'E')}
          </button>
          <button type="button" className="ghost" onClick={cancel}>
            {mnemonic('Cancel', 'C')}
          </button>
          <button type="button" className="ghost" onClick={() => router.back()}>
            E<u>x</u>it
          </button>
        </div>
      </form>
    </div>
  );
}
