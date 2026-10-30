'use client';

import { useCallback, useEffect, useMemo, useRef, useState, type CSSProperties } from 'react';
import { ApiError, del, get, post, put } from '../lib/api';
import { useCompanySettings } from '../lib/companySettings';
import {
  TAG_CANCEL_MODES,
  blankHeader,
  blankRow,
  changeRow,
  commitCell,
  commitStone,
  duplicateTag,
  gridTotals,
  neighbourVoucher,
  rowFromSaved,
  rowFromSource,
  setCell,
  showCell,
  tagCancelSettings,
  typedText,
  unresolvedTag,
  voucherPayload,
  withSpareRow,
  type GridRow,
  type NumericCell,
  type StoneDraft,
  type TagCancelMode,
  type TagSourceView,
  type VoucherHeaderDraft,
} from '../lib/tagCancelVoucher';
import { BookSelect } from './BookSelect';
import { useBusinessScope } from './BusinessScope';
import { EntityImagePanel } from './EntityImagePanel';
import { useGridKeyboard } from './GridKeyboard';
import { LookupPicker, type LookupRow } from './LookupPicker';
import SubDetailGrid, { type SubDetailField, type SubDetailRow } from './SubDetailGrid';

/**
 * TR_TAG_CAN — Tag Cancel and Tag Transfer on one form (contract K15), as the desktop opens one form from both
 * menus. The pure half — rows, cell events, payload, reopen — is `lib/tagCancelVoucher.ts`.
 */

type ColumnKind =
  'index' | 'tag' | 'item' | 'text' | 'number' | 'display' | 'transferItem' | 'transferName';

interface GridColumn {
  label: string;
  kind: ColumnKind;
  field?: keyof GridRow;
  width?: number;
  maxLength?: number;
  /** `MSG_EnterCell` makes this cell read-only once the row holds a tag (cols 4/5/10/28). */
  tagLocked?: boolean;
}

/** The Tag Cancel grid's visible columns, in the desktop order (`MSG_CLEAR`, TR_TAG_CAN.cs:2426-2640). */
const CANCEL_COLUMNS: readonly GridColumn[] = [
  { label: 'Sr', kind: 'index', width: 28 },
  { label: 'TagNo', kind: 'tag', field: 'tagNo', width: 108 },
  { label: 'ItCode', kind: 'item', field: 'itCode', width: 80, tagLocked: true },
  { label: 'Counter', kind: 'text', field: 'tblCode', width: 48, maxLength: 3, tagLocked: true },
  { label: 'Design', kind: 'text', field: 'designNo', width: 84, maxLength: 20 },
  { label: 'Size', kind: 'text', field: 'itmSize', width: 48, maxLength: 20 },
  { label: 'BagWt', kind: 'number', field: 'bagWt', width: 64 },
  { label: 'Pcs', kind: 'number', field: 'pcs', width: 40, tagLocked: true },
  { label: 'GrWt', kind: 'number', field: 'grossWt', width: 72 },
  { label: 'LsWt', kind: 'number', field: 'lessWt', width: 64 },
  { label: 'NetWt', kind: 'number', field: 'netWt', width: 72 },
  { label: 'Ght%', kind: 'display', field: 'ghtPct', width: 48 },
  { label: 'GhtWt', kind: 'number', field: 'ghtWt', width: 64 },
  { label: 'Touch', kind: 'number', field: 'touch', width: 60 },
  { label: 'West%', kind: 'number', field: 'westPct', width: 60 },
  { label: 'Fine', kind: 'number', field: 'fine', width: 72 },
  { label: 'LbrRate', kind: 'number', field: 'lbrRate', width: 64 },
  { label: 'LbrAmt', kind: 'number', field: 'lbrAmt', width: 72 },
  { label: 'OthAmt', kind: 'number', field: 'othAmt', width: 72 },
  { label: 'Mrp', kind: 'number', field: 'mrp', width: 80 },
  { label: 'KrCode', kind: 'text', field: 'krName', width: 48, maxLength: 5, tagLocked: true },
];

/** The Tag Transfer grid: no ghat, labour, other amount, MRP or karigar; the transfer item instead (:2566-2600). */
const TRANSFER_COLUMNS: readonly GridColumn[] = [
  ...CANCEL_COLUMNS.filter((column) =>
    [
      'Sr',
      'TagNo',
      'ItCode',
      'Counter',
      'Design',
      'Size',
      'BagWt',
      'Pcs',
      'GrWt',
      'LsWt',
      'NetWt',
      'Touch',
      'West%',
      'Fine',
    ].includes(column.label),
  ),
  { label: 'TrfrItm', kind: 'transferItem', field: 'trfrItCode', width: 96 },
  { label: 'TrfrItmName', kind: 'transferName', field: 'trfrItName', width: 150 },
];

/** The stone grid's visible columns (`MSG_IDTL`, TR_TAG_CAN.cs:1865-1953; ItName is shown beside the picker). */
const STONE_COLUMNS: readonly SubDetailField[] = [
  'itCode',
  'pcs',
  'grossWt',
  'karigarWt',
  'conPct',
  'rateType',
  'rate',
  'amount',
  'lbrRate',
  'lbrAmount',
  'netAmount',
];

const computedStyle: CSSProperties = {
  textAlign: 'right',
  background: '#f4f6f9',
  border: '1px solid transparent',
};

const message = (caught: unknown, fallback: string): string =>
  caught instanceof ApiError
    ? String(caught.body?.message || caught.body?.error || caught.body?.detail || caught.message)
    : fallback;

interface SavedVoucherView {
  voucherNo: string;
  vchDate: string;
  voucherTime: string;
  hiddenVoucherNo: string;
  mainUser: string;
  empCode: string;
  empName: string;
  vchDesc: string;
  lines: Array<Record<string, unknown>>;
}

interface VoucherListing {
  nextVoucherNo: string;
  vouchers: Array<{
    vchNo: string;
    vchDate: string;
    partyName: string;
    vchDesc: string;
    mainUser: string;
    lines: number;
  }>;
}

export function TagCancelForm({ mode }: { mode: TagCancelMode }) {
  const cfg = TAG_CANCEL_MODES[mode];
  const columns = mode === 'cancel' ? CANCEL_COLUMNS : TRANSFER_COLUMNS;
  const { lcCode, coYear } = useBusinessScope();
  const companyValues = useCompanySettings();
  const settings = useMemo(() => tagCancelSettings(companyValues), [companyValues]);
  const [coBook, setCoBook] = useState('');
  const [header, setHeader] = useState<VoucherHeaderDraft>(() => blankHeader());
  const [rows, setRows] = useState<GridRow[]>(() => [blankRow(settings, mode)]);
  const [voucherNo, setVoucherNo] = useState('');
  const [loaded, setLoaded] = useState<SavedVoucherView | null>(null);
  const [listing, setListing] = useState<VoucherListing | null>(null);
  const [showList, setShowList] = useState(false);
  const [active, setActive] = useState(0);
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  const [status, setStatus] = useState('');
  // The latest rows, for the resolvers that run after an await.
  const latest = useRef(rows);
  useEffect(() => {
    latest.current = rows;
  }, [rows]);
  const id = (name: string) => `${cfg.testId}-${name}`;
  const current = rows[Math.min(active, rows.length - 1)];
  const totals = useMemo(() => gridTotals(rows), [rows]);
  // CommPassAdd runs after the company is open, so a new loose row always carries the company labour basis. Rows
  // created before `/settings` answered take it now; tag rows and reopened rows keep their own.
  useEffect(() => {
    setRows((all) =>
      all.map((row) =>
        row.fromTag || row.oldSrNo || row.lbrType === settings.companyLabourType
          ? row
          : { ...row, lbrType: settings.companyLabourType },
      ),
    );
  }, [settings.companyLabourType]);

  // ---- rows ----------------------------------------------------------------------------------------
  const updateRow = (index: number, change: (row: GridRow) => GridRow) =>
    setRows((all) => withSpareRow(changeRow(all, index, change, mode), settings, mode));
  const removeRow = (index: number): boolean => {
    // Ctrl+D: "This Row Record will Removed permantley ?" — the row goes with its stones (TR_TAG_CAN.cs:3712).
    if (!window.confirm('This Row Record will Removed permantley ?')) return false;
    setRows((all) => {
      const left = all.filter((_, i) => i !== index);
      return left.length ? withSpareRow(left, settings, mode) : [blankRow(settings, mode)];
    });
    setActive((position) => Math.max(0, Math.min(position, rows.length - 2)));
    setStatus('Please Save This Voucher Then Effect....');
    return true;
  };
  const gridKeys = useGridKeyboard({
    rowCount: rows.length,
    onAppendRow: () => setRows((all) => [...all, blankRow(settings, mode, all[all.length - 1])]),
    onRemoveRow: removeRow,
    onEscape: () => setError(''),
  });

  // ---- tag entry (TR_TAG_CAN.cs:3859-4090) ----------------------------------------------------------
  // Rows whose tag fill is in flight. Picking from the list also moves focus out of the cell, and the typed-number
  // resolution that leaving the cell starts must not race the pick (it would report an ambiguous number the operator
  // has just disambiguated).
  const filling = useRef(new Set<number>());
  async function fillTag(index: number, tagNo: string, vchSrno?: number) {
    const wanted = typedText(tagNo).trim();
    if (!wanted) return;
    if (duplicateTag(latest.current, index, wanted)) {
      setError(`Duplicate Tag No: ${wanted}`);
      return;
    }
    filling.current.add(index);
    try {
      const query = new URLSearchParams({ coBook, tagNo: wanted });
      if (vchSrno) query.set('vchSrno', String(vchSrno));
      const source = await get<TagSourceView>(`${cfg.endpoint}/source?${query}`);
      updateRow(index, (row) => rowFromSource(source, row, settings, mode));
      setActive(index);
      setError('');
    } catch (caught) {
      setError(message(caught, 'tag lookup failed'));
    } finally {
      filling.current.delete(index);
    }
  }

  /** A number typed without choosing from the list resolves on leaving the cell when it names one live instance. */
  async function resolveTypedTag(index: number) {
    const row = latest.current[index];
    if (filling.current.has(index) || !row || !unresolvedTag(row)) return;
    const typed = row.tagNo.trim();
    try {
      const found = await get<LookupRow[]>(
        `/lookup/available-tags?q=${encodeURIComponent(typed)}&limit=10`,
      );
      // A pick made while the lookup ran has settled the row already.
      const now = latest.current[index];
      if (filling.current.has(index) || !now || !unresolvedTag(now) || now.tagNo.trim() !== typed) {
        return;
      }
      const exact = (found ?? []).filter(
        (candidate) =>
          String(candidate.code ?? '')
            .trim()
            .toUpperCase() === typed,
      );
      if (exact.length === 1) {
        await fillTag(index, typed, Number(exact[0]!.VCH_SRNO) || undefined);
      } else if (exact.length > 1) {
        setError(`Tag ${typed} has ${exact.length} live instances; pick one from the list (F1)`);
      } else {
        setError(`tag not available for issue: ${typed}`);
      }
    } catch (caught) {
      setError(message(caught, 'tag lookup failed'));
    }
  }

  async function resolveTransferItem(index: number) {
    const row = latest.current[index];
    const code = row?.trfrItCode.trim() ?? '';
    if (!row || !code || row.trfrItName) return;
    try {
      const found = await get<LookupRow[]>(`/lookup/items?q=${encodeURIComponent(code)}&limit=10`);
      const exact = (found ?? []).find(
        (candidate) =>
          String(candidate.code ?? '')
            .trim()
            .toUpperCase() === code,
      );
      // Only the code that was looked up is named: a pick made meanwhile has named its own item.
      const settled = (r: GridRow | undefined) =>
        !r || r.trfrItCode.trim() !== code || !!r.trfrItName;
      if (settled(latest.current[index])) return;
      updateRow(index, (r) =>
        settled(r) ? r : { ...r, trfrItName: exact ? String(exact.name ?? '') : '' },
      );
      if (!exact) setError(`transfer item ${code} not found`);
    } catch {
      // The save checks the transfer item and names it if it does not exist.
    }
  }

  // ---- voucher lifecycle ----------------------------------------------------------------------------
  const refreshListing = useCallback(
    async (book: string): Promise<VoucherListing | null> => {
      if (!book) return null;
      try {
        const view = await get<VoucherListing>(
          `${cfg.endpoint}?coBook=${encodeURIComponent(book)}`,
        );
        setListing(view);
        return view;
      } catch (caught) {
        setError(message(caught, `${cfg.title} list failed`));
        return null;
      }
    },
    [cfg.endpoint, cfg.title],
  );

  function clearScreen(next?: VoucherListing | null) {
    setHeader(blankHeader());
    setRows([blankRow(settings, mode)]);
    setLoaded(null);
    setActive(0);
    setVoucherNo((next ?? listing)?.nextVoucherNo ?? '');
  }

  useEffect(() => {
    // CLEAR_DATA on a new book: the next number is MAX(VCH_NO) + 1 of the book.
    setLoaded(null);
    setRows([blankRow(settings, mode)]);
    setHeader(blankHeader());
    setActive(0);
    setError('');
    setStatus('');
    void refreshListing(coBook).then((view) => setVoucherNo(view?.nextVoucherNo ?? ''));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [coBook]);

  async function open(no: string): Promise<SavedVoucherView> {
    const view = await get<SavedVoucherView>(
      `${cfg.endpoint}/${encodeURIComponent(no)}?coBook=${encodeURIComponent(coBook)}`,
    );
    setLoaded(view);
    setVoucherNo(view.voucherNo);
    setHeader({
      vchDate: view.vchDate,
      empCode: view.empCode,
      empName: view.empName,
      vchDesc: view.vchDesc,
    });
    setRows(
      withSpareRow(
        view.lines.map((line) => rowFromSaved(line, settings, mode)),
        settings,
        mode,
      ),
    );
    setActive(0);
    return view;
  }

  async function load(no = voucherNo) {
    if (!coBook || !no.trim()) return;
    setBusy(true);
    setError('');
    setStatus('');
    try {
      const view = await open(no.trim());
      setStatus(`Loaded voucher ${view.voucherNo}`);
    } catch (caught) {
      setError(message(caught, `${cfg.title} load failed`));
    } finally {
      setBusy(false);
    }
  }

  async function step(direction: 'previous' | 'next') {
    const numbers = (listing?.vouchers ?? []).map((voucher) => voucher.vchNo);
    const target = neighbourVoucher(numbers, loaded?.voucherNo ?? voucherNo, direction);
    if (!target) {
      setStatus(direction === 'next' ? 'Last Record...' : 'First Record...');
      return;
    }
    await load(target);
  }

  async function save() {
    const pending = rows.findIndex(unresolvedTag);
    if (pending >= 0) {
      setError(`Row ${pending + 1}: resolve tag ${rows[pending]!.tagNo.trim()} before saving`);
      return;
    }
    setBusy(true);
    setError('');
    setStatus('');
    try {
      const body = voucherPayload(header, rows, mode, { coBook, coYear, lcCode });
      const verb = loaded ? 'Updated' : 'Saved';
      const result = loaded
        ? await put<{ vchNo: number; voucherNo: string }>(
            `${cfg.endpoint}/${encodeURIComponent(loaded.voucherNo)}`,
            body,
          )
        : await post<{ vchNo: number; voucherNo: string }>(cfg.endpoint, body);
      const saved = result.voucherNo ?? String(result.vchNo).padStart(5, '0');
      try {
        // Reload what was stored, so every figure on screen is the saved one.
        const view = await open(saved);
        setStatus(`${verb} voucher ${view.voucherNo}`);
      } catch (caught) {
        setStatus(`${verb} voucher ${saved}`);
        setError(`Saved, but reloading it failed: ${message(caught, 'reload failed')}`);
      }
      void refreshListing(coBook);
    } catch (caught) {
      setError(message(caught, `${cfg.title} save failed`));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loaded || !window.confirm('Are You Sure To Delete This Voucher now?')) return;
    setBusy(true);
    setError('');
    try {
      await del(
        `${cfg.endpoint}/${encodeURIComponent(loaded.voucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      const deleted = loaded.voucherNo;
      const view = await refreshListing(coBook);
      clearScreen(view);
      setStatus(`Delete Success. Voucher ${deleted}`);
    } catch (caught) {
      setError(message(caught, `${cfg.title} delete failed`));
    } finally {
      setBusy(false);
    }
  }

  const hasLines = rows.some((row) => row.fromTag || row.itCode.trim());
  const canSave = !!coBook && hasLines && !busy;

  // ---- cells ---------------------------------------------------------------------------------------
  function renderCell(column: GridColumn, row: GridRow, index: number, position: number) {
    // "line N", never "row N": the stone grid under this one labels its own cells "ItCode row N", "Pcs row N", ….
    const where = `line ${index + 1}`;
    const locked = column.tagLocked && row.fromTag;
    const field = column.field as keyof GridRow;
    switch (column.kind) {
      case 'index':
        return (
          <td key={position} className="muted">
            {index + 1}
          </td>
        );
      case 'tag':
        return (
          <td key={position} onBlur={() => void resolveTypedTag(index)}>
            <LookupPicker
              entity="available-tags"
              value={row.tagNo}
              onChange={(value) => updateRow(index, (r) => setCell(r, 'tagNo', value))}
              onPick={(picked) =>
                void fillTag(index, String(picked.code ?? ''), Number(picked.VCH_SRNO) || undefined)
              }
              placeholder="tag… (F1)"
              ariaLabel={`TagNo ${where}`}
              style={{ minWidth: column.width }}
            />
          </td>
        );
      case 'item':
        if (locked) {
          return (
            <td key={position}>
              <input
                readOnly
                aria-label={`ItCode ${where}`}
                value={row.itCode}
                title={row.itName}
                style={{ width: column.width, background: '#f4f6f9' }}
              />
            </td>
          );
        }
        return (
          <td key={position}>
            <LookupPicker
              entity="items"
              value={row.itCode}
              onChange={(value) => updateRow(index, (r) => setCell(r, 'itCode', value))}
              onPick={(picked) =>
                updateRow(index, (r) => ({
                  ...r,
                  itCode: String(picked.code ?? ''),
                  itName: String(picked.name ?? ''),
                  itType: String(picked.IT_TYPE ?? r.itType),
                  rateType: String(picked.RATE_TYPE ?? r.rateType),
                }))
              }
              placeholder="item… (F1)"
              ariaLabel={`ItCode ${where}`}
              style={{ minWidth: column.width }}
            />
          </td>
        );
      case 'text':
        return (
          <td key={position}>
            <input
              aria-label={`${column.label} ${where}`}
              value={String(row[field] ?? '')}
              readOnly={locked}
              maxLength={column.maxLength}
              onChange={(event) =>
                updateRow(index, (r) => setCell(r, field as never, event.target.value))
              }
              style={{
                width: column.width,
                textTransform: 'uppercase',
                ...(locked ? { background: '#f4f6f9' } : {}),
              }}
            />
          </td>
        );
      case 'number': {
        const cell = field as NumericCell;
        return (
          <td key={position} className="num">
            <input
              aria-label={`${column.label} ${where}`}
              data-testid={id(`${cell}-${index}`)}
              value={String(row[cell] ?? '')}
              readOnly={locked}
              inputMode="decimal"
              onChange={(event) => updateRow(index, (r) => setCell(r, cell, event.target.value))}
              onFocus={() => setActive(index)}
              onBlur={() => {
                if (locked) return;
                updateRow(index, (r) => commitCell(r, cell, settings));
              }}
              style={{
                width: column.width,
                textAlign: 'right',
                ...(locked ? { background: '#f4f6f9' } : {}),
              }}
            />
          </td>
        );
      }
      case 'display':
        return (
          <td key={position} className="num">
            <input
              readOnly
              tabIndex={-1}
              aria-label={`${column.label} ${where}`}
              value={showCell(String(row[field] ?? ''), 2)}
              style={{ width: column.width, ...computedStyle }}
            />
          </td>
        );
      case 'transferItem':
        return (
          <td key={position} onBlur={() => void resolveTransferItem(index)}>
            <LookupPicker
              entity="items"
              value={row.trfrItCode}
              onChange={(value) =>
                updateRow(index, (r) => ({ ...setCell(r, 'trfrItCode', value), trfrItName: '' }))
              }
              onPick={(picked) =>
                updateRow(index, (r) => ({
                  ...r,
                  trfrItCode: String(picked.code ?? ''),
                  trfrItName: String(picked.name ?? ''),
                }))
              }
              placeholder="item… (F1)"
              ariaLabel={`TrfrItm ${where}`}
              style={{ minWidth: column.width }}
            />
          </td>
        );
      case 'transferName':
        return (
          <td key={position}>
            <input
              readOnly
              tabIndex={-1}
              aria-label={`TrfrItmName ${where}`}
              value={row.trfrItName}
              style={{ width: column.width, background: '#f4f6f9' }}
            />
          </td>
        );
    }
  }

  const totalCell = (column: GridColumn): string => {
    switch (column.field) {
      case 'pcs':
        return String(totals.pcs);
      case 'bagWt':
        return showCell(String(totals.bagWt), 3);
      case 'grossWt':
        return showCell(String(totals.grossWt), 3);
      case 'lessWt':
        return showCell(String(totals.lessWt), 3);
      case 'netWt':
        return showCell(String(totals.netWt), 3);
      case 'ghtWt':
        return showCell(String(totals.ghtWt), 3);
      case 'fine':
        return showCell(String(totals.fine), 3);
      case 'lbrAmt':
        return showCell(String(totals.lbrAmt), 2);
      case 'othAmt':
        return showCell(String(totals.othAmt), 2);
      case 'mrp':
        return showCell(String(totals.mrp), 2);
      default:
        return '';
    }
  };

  const stoneRows = (current?.stones ?? []) as SubDetailRow[];
  const activeIndex = Math.min(active, rows.length - 1);

  return (
    <div data-testid={id('form')}>
      <h1>{cfg.title}</h1>
      <p className="muted">
        Desktop TR_TAG_CAN on a {cfg.mainBook} book.{' '}
        {mode === 'cancel'
          ? 'Each tag leaves stock (MAIN_STOCK, ITM_SIGN −) and is recorded in the cancel register with its stones.'
          : 'Each tag leaves stock and its metal moves to the transfer item as loose stock (MAIN_STOCK − and +).'}
      </p>
      <div className="panel">
        <div className="row" style={{ flexWrap: 'wrap', alignItems: 'flex-end' }}>
          <div className="field">
            <label>Book</label>
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={[cfg.mainBook]} />
          </div>
          <div className="field" style={{ flex: '0 0 auto' }}>
            <label htmlFor={id('vch-no')}>Vch No</label>
            <div className="toolbar" style={{ gap: 4, flexWrap: 'nowrap', marginBottom: 0 }}>
              <button
                type="button"
                className="ghost"
                title="Previous voucher (↓)"
                aria-label="Previous voucher"
                disabled={!coBook || busy}
                onClick={() => void step('previous')}
              >
                &lt;
              </button>
              <input
                id={id('vch-no')}
                data-testid={id('vch-no')}
                value={voucherNo}
                style={{ width: 80 }}
                onChange={(event) =>
                  setVoucherNo(event.target.value.replace(/\D/g, '').slice(0, 5))
                }
                onKeyDown={(event) => {
                  if (event.key === 'Enter') {
                    event.preventDefault();
                    void load();
                  } else if (event.key === 'F1') {
                    event.preventDefault();
                    setShowList((open) => !open);
                  } else if (event.key === 'ArrowUp') {
                    event.preventDefault();
                    void step('next');
                  } else if (event.key === 'ArrowDown') {
                    event.preventDefault();
                    void step('previous');
                  }
                }}
              />
              <button
                type="button"
                className="ghost"
                title="Next voucher (↑)"
                aria-label="Next voucher"
                disabled={!coBook || busy}
                onClick={() => void step('next')}
              >
                &gt;
              </button>
              <button
                type="button"
                className="ghost"
                data-testid={id('load')}
                disabled={!coBook || !voucherNo || busy}
                onClick={() => void load()}
              >
                Load
              </button>
              <button
                type="button"
                className="ghost"
                data-testid={id('list-toggle')}
                disabled={!coBook}
                onClick={() => setShowList((open) => !open)}
              >
                F1 List
              </button>
            </div>
          </div>
          <div className="field">
            <label htmlFor={id('vch-date')}>Vch Date</label>
            <input
              id={id('vch-date')}
              type="date"
              value={header.vchDate}
              onChange={(event) => setHeader((h) => ({ ...h, vchDate: event.target.value }))}
            />
          </div>
          <div className="field">
            <label>Employee</label>
            <LookupPicker
              entity="employees"
              value={header.empCode}
              onChange={(value) =>
                setHeader((h) => ({ ...h, empCode: typedText(value).slice(0, 3), empName: '' }))
              }
              onPick={(picked) =>
                setHeader((h) => ({
                  ...h,
                  empCode: String(picked.code ?? ''),
                  empName: String(picked.name ?? ''),
                }))
              }
              placeholder="employee… (F1)"
              ariaLabel="Employee"
              style={{ width: 150 }}
            />
            {header.empName ? <span className="muted">{header.empName}</span> : null}
          </div>
          <div className="field" style={{ flex: 1, minWidth: 220 }}>
            <label htmlFor={id('vch-desc')}>Vch Desc</label>
            <input
              id={id('vch-desc')}
              data-testid={id('vch-desc')}
              value={header.vchDesc}
              maxLength={255}
              style={{ textTransform: 'uppercase' }}
              onChange={(event) =>
                setHeader((h) => ({ ...h, vchDesc: typedText(event.target.value) }))
              }
            />
          </div>
          {loaded ? (
            <div className="field">
              <label>Hidden No / User</label>
              <span className="muted" data-testid={id('hidden-no')}>
                {loaded.hiddenVoucherNo} · {loaded.mainUser} · {loaded.voucherTime}
              </span>
            </div>
          ) : null}
        </div>
        {showList && listing ? (
          <div className="panel" data-testid={id('voucher-list')} style={{ marginTop: 8 }}>
            <table className="grid">
              <thead>
                <tr>
                  <th>VchNo</th>
                  <th>VchDate</th>
                  <th>PartyName</th>
                  <th>VchDesc</th>
                  <th>User</th>
                  <th className="num">Lines</th>
                </tr>
              </thead>
              <tbody>
                {listing.vouchers.map((voucher) => (
                  <tr
                    key={voucher.vchNo}
                    style={{ cursor: 'pointer' }}
                    onClick={() => {
                      setShowList(false);
                      void load(voucher.vchNo);
                    }}
                  >
                    <td>{voucher.vchNo}</td>
                    <td>{voucher.vchDate}</td>
                    <td>{voucher.partyName}</td>
                    <td>{voucher.vchDesc}</td>
                    <td>{voucher.mainUser}</td>
                    <td className="num">{voucher.lines}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        ) : null}
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid dense" onKeyDown={gridKeys} data-testid={id('grid')}>
          <thead>
            <tr>
              {columns.map((column) => (
                <th
                  key={column.label}
                  className={
                    column.kind === 'number' || column.kind === 'display' ? 'num' : undefined
                  }
                >
                  {column.label}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {rows.map((row, index) => (
              <tr
                key={row.id}
                data-testid={id(`row-${index}`)}
                onClick={() => setActive(index)}
                style={index === activeIndex ? { outline: '1px solid #9bb4d6' } : undefined}
              >
                {columns.map((column, position) => renderCell(column, row, index, position))}
              </tr>
            ))}
          </tbody>
          <tfoot>
            <tr data-testid={id('totals')}>
              {columns.map((column, position) => (
                <td key={position} className="num">
                  {position === 4 ? (
                    <b>Total :</b>
                  ) : (
                    <span data-testid={id(`total-${column.field ?? position}`)}>
                      {totalCell(column)}
                    </span>
                  )}
                </td>
              ))}
            </tr>
          </tfoot>
        </table>
        <div className="toolbar" style={{ marginTop: 6 }}>
          <span className="muted" data-testid={id('item-name')}>
            {current?.itName ? `${current.itName} : It Name` : 'Item Name'}
          </span>
          <span className="spacer" />
          <span className="muted">
            Enter adds a row · Ctrl+D removes one · a tag fills its row from stock
          </span>
        </div>
      </div>

      {/* The stone grid needs ~1100px for its 11 columns; the photograph sits beside it where the screen allows and
          wraps below it otherwise, so the stones never scroll sideways to make room for the picture. */}
      <div className="row" style={{ alignItems: 'flex-start', flexWrap: 'wrap' }}>
        <div style={{ flex: '1 1 1100px', minWidth: 0 }}>
          <SubDetailGrid
            rows={stoneRows.length ? stoneRows : [{}]}
            onRowsChange={(stones) =>
              updateRow(activeIndex, (r) => ({
                ...r,
                stones: stones as StoneDraft[],
                stonesEdited: true,
              }))
            }
            onCellCommit={(stoneIndex) => updateRow(activeIndex, (r) => commitStone(r, stoneIndex))}
            columns={STONE_COLUMNS}
            parentLabel={`line ${activeIndex + 1}${current?.tagNo ? ` — ${current.tagNo}` : ''}`}
            desktopSource="TR_TAG_CAN / MSG_IDTL"
            disabled={!current?.fromTag}
            testId={id('stone')}
          />
        </div>
        <div style={{ flex: '0 1 360px', minWidth: 260 }}>
          {current?.fromTag && current.filledTag ? (
            <EntityImagePanel
              entityType="TAG"
              entityKey={current.filledTag}
              instance={Number(current.vchSrno) || 0}
              label="Tag image"
              disabled
              testId={id('image')}
            />
          ) : (
            <div className="panel muted">Tag image — choose a tag line</div>
          )}
        </div>
      </div>

      <div className="toolbar" style={{ marginTop: 10 }}>
        <button
          type="button"
          className="primary"
          data-save-mnemonic
          data-testid={id('save')}
          disabled={!canSave}
          onClick={() => void save()}
        >
          {busy ? 'Saving…' : loaded ? 'Update' : 'Save'}
        </button>
        <button
          type="button"
          className="danger"
          data-testid={id('delete')}
          disabled={!loaded || busy}
          onClick={() => void remove()}
        >
          Delete
        </button>
        <button
          type="button"
          className="ghost"
          data-testid={id('new')}
          disabled={busy}
          onClick={() => {
            clearScreen();
            setError('');
            setStatus('');
          }}
        >
          Cancel
        </button>
      </div>
      {error && (
        <div className="msg err" role="alert" data-testid={id('error')}>
          {error}
        </div>
      )}
      {status && (
        <div className="msg ok" data-testid={id('status')}>
          {status}
        </div>
      )}
    </div>
  );
}
