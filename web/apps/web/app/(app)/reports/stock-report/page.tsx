'use client';
import { useRouter } from 'next/navigation';
import { formatDesktopDate } from '@datacare/core';
import { useEffect, useMemo, useRef, useState } from 'react';
import { downloadCsv } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import {
  DesktopDateInput,
  type DesktopDateInputHandle,
} from '../../../../components/DesktopDateInput';
import { CodeBox } from './CodeBox';
import { ItemPicker, type PickerItem } from './ItemPicker';
import { get } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';
import { MovementGrid, SummaryGrid } from './StockGrids';
import { NO_RIGHTS, useStockReport } from './useStockReport';
import { DIMENSIONS, ITEM_TYPES, type Dimension, type Filters } from './types';

/**
 * Report -> Stock Report: the desktop RP_STOCK form (MDI_FORM.cs:8881-8890), on its own route; Tag Stock
 * (RP_TAG) stays on /reports/tag-stock.
 *
 * A dimension button runs the summary (RP_STOCK.cs:5139-6088); a double click or Enter on a figure cell opens
 * the movements behind it (RP_STOCK.cs:2816) and Esc or Back returns (RP_STOCK.cs:3992). G, I and P run Group,
 * Item and Product (RP_STOCK.cs:3954-3987) when focus is not in a text box. Ticking Gross Wise Weight does not
 * refresh the grid (RP_STOCK.cs:5710). Print and Excel need the Print right.
 */
const TEXT_FILTERS: Array<[keyof Filters, string, string]> = [
  ['grCode', 'Gr Code', 'sr-gr'],
  ['prCode', 'Pr Code', 'sr-pr'],
  ['itCode', 'It Code', 'sr-it'],
  ['designNo', 'Design', 'sr-design'],
  ['safe', 'Safe', 'sr-safe'],
  ['tblCode', 'Counter', 'sr-counter'],
  ['tagNo', 'TagNo', 'sr-tag'],
  ['acCode', 'AcCode', 'sr-ac'],
];
/** The code boxes that open the master's help on Enter (RP_STOCK.cs:5721-6179); Safe, Counter and TagNo have none. */
const HELP_ENTITY: Partial<Record<keyof Filters, string>> = {
  prCode: 'products',
  grCode: 'groups',
  itCode: 'items',
  designNo: 'designs',
  acCode: 'accounts',
};
const KEY_DIMENSION: Record<string, Dimension> = { g: 'group', i: 'item', p: 'product' };

export default function StockReportPage() {
  const router = useRouter();
  const s = useStockReport();
  const { filters, setFilters, result, movements, error, message, busy } = s;
  const { coYear } = useBusinessScope();
  const fromDate = useRef<DesktopDateInputHandle>(null);
  const toDate = useRef<DesktopDateInputHandle>(null);
  const [search, setSearch] = useState('');
  const [picker, setPicker] = useState<PickerItem[] | null>(null);
  const gridRef = useRef<HTMLTableElement | null>(null);
  const buttons = useRef<Record<string, HTMLButtonElement | null>>({});

  const rows = useMemo(() => {
    if (!result) return [];
    const needle = search.trim().toLowerCase();
    return needle ? result.rows.filter((r) => r.name.toLowerCase().includes(needle)) : result.rows;
  }, [result, search]);

  const runDimension = (d: Dimension) => {
    setSearch('');
    void s.run(d);
    buttons.current[d]?.focus();
  };
  // RP_STOCK.cs:3713: the open-time warning about a movement dated after today (a MsgBox; To is already its date).
  useEffect(() => {
    if (s.futureWarning) window.alert(s.futureWarning);
  }, [s.futureWarning]);
  const latest = useRef({ runDimension, back: s.back, open: false, exit: router.back });
  latest.current = {
    runDimension,
    back: s.back,
    open: movements !== null,
    exit: router.back,
  };

  // Form-level keys (RP_STOCK.cs:3954-4012). Esc: Back from a drill-down, else close the screen.
  useEffect(() => {
    const onKey = (e: KeyboardEvent) => {
      if (e.defaultPrevented || e.ctrlKey || e.metaKey || e.altKey) return;
      if (e.key === 'Escape') {
        if (document.querySelector('[data-lookup-open]')) return;
        e.preventDefault();
        if (latest.current.open) latest.current.back();
        else latest.current.exit();
        return;
      }
      const target = e.target as HTMLElement | null;
      const typing = target && /^(INPUT|TEXTAREA|SELECT)$/.test(target.tagName);
      const dim = KEY_DIMENSION[e.key.toLowerCase()];
      if (dim && !typing) {
        e.preventDefault();
        latest.current.runDimension(dim);
      }
    };
    document.addEventListener('keydown', onKey);
    return () => document.removeEventListener('keydown', onKey);
  }, []);

  const print = async () => {
    // The Print right is checked first (RP_STOCK.cs:4024); the document is then built from the same query as the grid.
    const blob = await s.exportFile('csv');
    const url = s.printUrl();
    if (blob && url) openDocument(url);
  };
  const excel = async () => {
    if (movements) {
      // The Excel button writes the visible grid: the movement grid while a drill-down is open.
      const blob = await s.exportFile('csv');
      if (!blob) return;
      const t = movements.data.totals;
      const lines: Array<Record<string, string>> = movements.data.rows.map((r, i) => ({
        SrNo: String(i + 1),
        Vchtype: r.vchType ?? '',
        'Party Name': r.partyName,
        VchNo: r.vchNo ?? '',
        VchDate: formatDesktopDate(r.vchDate),
        TagNo: r.tagNo ?? '',
        ItName: r.itName,
        Pcs: String(r.pcs),
        GrWt: r.gwt.toFixed(3),
        NetWt: r.nwt.toFixed(3),
        Fine: r.fine.toFixed(3),
        Sign: r.sign,
      }));
      // The desktop writes every cell of the visible grid, the "Total :" row included (RP_STOCK.cs:3262-3283).
      if (lines.length)
        lines.push({
          SrNo: '',
          Vchtype: 'Total :',
          'Party Name': '',
          VchNo: '',
          VchDate: '',
          TagNo: '',
          ItName: '',
          Pcs: String(t.pcs),
          GrWt: t.gwt.toFixed(3),
          NetWt: t.nwt.toFixed(3),
          Fine: t.fine.toFixed(3),
          Sign: '',
        });
      downloadCsv(lines, 'stock-report-movements');
      return;
    }
    const blob = await s.exportFile('xlsx');
    if (!blob) return;
    const url = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = url;
    a.download = 'stock-report.xlsx';
    document.body.appendChild(a);
    a.click();
    a.remove();
    setTimeout(() => URL.revokeObjectURL(url), 1000);
  };

  /** InOut (RP_STOCK.cs:5857): list the items of the chosen Item Type with tick boxes. */
  const openPicker = async () => {
    s.notify('');
    try {
      setPicker(
        await get<PickerItem[]>(
          `/reports/stock-report/item-ledger/items?itemType=${encodeURIComponent(filters.itemType.slice(0, 1))}`,
        ),
      );
    } catch {
      setPicker([]);
    }
  };
  /** Ok of the picker (RP_STOCK.cs:5927): nothing ticked answers the desktop text, otherwise the ledger prints. */
  const pickerOk = (codes: string[]) => {
    setPicker(null);
    if (codes.length === 0) {
      s.notify('Item Selection Not Done...');
      return;
    }
    const q = new URLSearchParams({
      items: codes.join(','),
      fromDate: filters.fromDate,
      toDate: filters.toDate,
    });
    openDocument(`/api/reports/stock-report/item-ledger.pdf?${q.toString()}`);
  };

  if (s.noRights)
    return (
      <div>
        <h1>Stock Report</h1>
        <div className="msg err" role="alert" data-testid="stock-no-rights">
          {NO_RIGHTS}
        </div>
      </div>
    );

  return (
    <div>
      <h1>Stock Report</h1>
      <div className="panel">
        <div className="row">
          <div className="field">
            <DesktopDateInput
              ref={fromDate}
              id="sr-from"
              label="From"
              coYear={coYear}
              value={filters.fromDate}
              onChange={(iso) => setFilters({ fromDate: iso })}
              onAdvance={() => toDate.current?.focus()}
            />
          </div>
          <div className="field">
            <DesktopDateInput
              ref={toDate}
              id="sr-to"
              label="To"
              coYear={coYear}
              value={filters.toDate}
              onChange={(iso) => setFilters({ toDate: iso })}
              onAdvance={() => document.getElementById('sr-search')?.focus()}
            />
          </div>
          <div className="field">
            <label htmlFor="sr-search">Search</label>
            <input
              id="sr-search"
              data-sr-field
              value={search}
              placeholder="Name"
              onChange={(e) => setSearch(e.target.value)}
              onKeyDown={(e) => {
                if (e.key === 'ArrowUp' || e.key === 'ArrowDown') {
                  e.preventDefault();
                  gridRef.current?.querySelector<HTMLElement>('td[tabindex]')?.focus();
                }
              }}
            />
          </div>
          <div className="field">
            <label htmlFor="sr-ittype">Item Type</label>
            <select
              id="sr-ittype"
              data-sr-field
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
          <div className="field">
            <label htmlFor="sr-stype">Stock Type</label>
            <select
              id="sr-stype"
              data-sr-field
              value={filters.stockType}
              onChange={(e) => setFilters({ stockType: e.target.value as Filters['stockType'] })}
            >
              <option value="all">All</option>
              <option value="tag">Tag</option>
              <option value="item">Item</option>
            </select>
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <label>
              <input
                type="checkbox"
                checked={filters.gross}
                onChange={(e) => s.setGross(e.target.checked)}
              />{' '}
              Gross Wise Weight
            </label>
          </div>
        </div>
        <div className="row">
          {TEXT_FILTERS.map(([key, label, id]) => (
            <div className="field" key={key}>
              <label htmlFor={id}>{label}</label>
              {HELP_ENTITY[key] ? (
                <CodeBox
                  id={id}
                  entity={HELP_ENTITY[key]}
                  value={String(filters[key])}
                  onChange={(v) => setFilters({ [key]: v })}
                  blankIsKnown={key === 'acCode'}
                  onKnown={key === 'acCode' ? () => runDimension('item') : undefined}
                />
              ) : (
                <input
                  id={id}
                  data-sr-field
                  value={String(filters[key])}
                  style={{ width: 110 }}
                  onChange={(e) => setFilters({ [key]: e.target.value.toUpperCase() })}
                />
              )}
            </div>
          ))}
        </div>
        <div className="row">
          {DIMENSIONS.map((d) => (
            <button
              key={d.value}
              type="button"
              className="ghost"
              ref={(el) => {
                buttons.current[d.value] = el;
              }}
              disabled={!s.ready || busy}
              onClick={() => runDimension(d.value)}
            >
              {d.value === 'safe' && s.itemLot ? 'Item Lot' : d.label}
            </button>
          ))}
          <button
            type="button"
            className="ghost"
            disabled={!s.ready || busy}
            onClick={() => void openPicker()}
          >
            InOut
          </button>
          <span className="spacer" />
          <button type="button" className="ghost" onClick={() => void print()} disabled={!result}>
            Print
          </button>
          <button type="button" className="ghost" onClick={() => void excel()} disabled={!result}>
            Excel
          </button>
          <button type="button" className="ghost" onClick={() => void s.clear()}>
            Cancel
          </button>
          <button
            type="button"
            className="ghost"
            onClick={() => (movements ? s.back() : router.back())}
          >
            {movements ? 'Back' : 'Exit'}
          </button>
        </div>
      </div>
      {picker && <ItemPicker items={picker} onOk={pickerOk} onCancel={() => setPicker(null)} />}
      {error && (
        <div className="msg err" role="alert" data-testid="stock-error">
          {error}
        </div>
      )}
      {message && (
        <div className="msg err" role="alert" data-testid="stock-message">
          {message}
        </div>
      )}
      {result && !movements && (
        <>
          <p className="muted" data-testid="stock-title">
            {result.title} ({result.weight})
          </p>
          <SummaryGrid
            result={result}
            rows={rows}
            onDrill={s.drill}
            gridRef={gridRef}
            showTotal={search.trim() === ''}
          />
        </>
      )}
      {movements && (
        <MovementGrid
          data={movements.data}
          lotCaption={s.itemLot && s.dimension === 'safe'}
          onZoom={(row) => {
            void s.zoom(row).then((a) => {
              if (a?.action !== 'open') return;
              const q = new URLSearchParams({ vchNo: a.vchNo, coBook: a.coBook, lcCode: a.lcCode });
              if (a.mode) q.set('mode', a.mode);
              router.push(`${a.path}?${q.toString()}`);
            });
          }}
        />
      )}
    </div>
  );
}
