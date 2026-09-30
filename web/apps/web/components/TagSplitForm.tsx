'use client';

import { useCallback, useEffect, useMemo, useRef, useState, type CSSProperties } from 'react';
import { ApiError, del, get, post, put } from '../lib/api';
import { useCompanySettings } from '../lib/companySettings';
import {
  blankChild,
  blankHeader,
  blankParent,
  childFromSaved,
  childTotals,
  commitChildCell,
  commitChildStone,
  conserves,
  duplicateParent,
  isActiveChild,
  neighbourVoucher,
  parentFromSaved,
  parentFromSource,
  parentNetTotal,
  setChildCell,
  showCell,
  splitBalance,
  tagSplitSettings,
  typedText,
  voucherPayload,
  withSpareChild,
  type ChildNumericCell,
  type ChildRow,
  type ParentRow,
  type SplitHeaderDraft,
  type StoneDraft,
  type TagSourceView,
} from '../lib/tagSplitVoucher';
import { BookSelect } from './BookSelect';
import { useBusinessScope } from './BusinessScope';
import { EntityImagePanel } from './EntityImagePanel';
import { useGridKeyboard } from './GridKeyboard';
import { LookupPicker, type LookupRow } from './LookupPicker';
import SubDetailGrid, { type SubDetailField, type SubDetailRow } from './SubDetailGrid';

/**
 * TR_TAG_SPLIT — split parent tags into child tags, conserving metal (contract K14). The pure half — rows, cell
 * events, payload, reopen — is `lib/tagSplitVoucher.ts`.
 */

interface Column {
  label: string;
  field: string;
  width: number;
  /** A child numeric cell the operator edits. */
  edit?: ChildNumericCell;
  /** A child text cell the operator edits. */
  text?: 'tblCode' | 'designNo' | 'itmSize';
  display?: boolean;
}

/** Parent grid (read-only): the tag being split. */
const PARENT_COLUMNS: readonly Column[] = [
  { label: 'Sr', field: 'sr', width: 28 },
  { label: 'TagNo', field: 'tagNo', width: 120 },
  { label: 'ItCode', field: 'itCode', width: 80 },
  { label: 'Design', field: 'designNo', width: 84 },
  { label: 'Size', field: 'itmSize', width: 48 },
  { label: 'Pcs', field: 'pcs', width: 40 },
  { label: 'GrWt', field: 'grossWt', width: 72, display: true },
  { label: 'NetWt', field: 'netWt', width: 72, display: true },
  { label: 'Touch', field: 'touch', width: 60, display: true },
  { label: 'Fine', field: 'fine', width: 72, display: true },
];

/** Child grid (editable): the new tags. TagNo is allocated on save. */
const CHILD_COLUMNS: readonly Column[] = [
  { label: 'Sr', field: 'sr', width: 28 },
  { label: 'ItCode', field: 'itCode', width: 88 },
  { label: 'TagNo', field: 'tagNo', width: 108, display: true },
  { label: 'Counter', field: 'tblCode', width: 48, text: 'tblCode' },
  { label: 'Design', field: 'designNo', width: 84, text: 'designNo' },
  { label: 'Size', field: 'itmSize', width: 48, text: 'itmSize' },
  { label: 'Pcs', field: 'pcs', width: 44, edit: 'pcs' },
  { label: 'GrWt', field: 'grossWt', width: 72, edit: 'grossWt' },
  { label: 'LsWt', field: 'lessWt', width: 64, edit: 'lessWt' },
  { label: 'NetWt', field: 'netWt', width: 72, edit: 'netWt' },
  { label: 'GhtWt', field: 'ghtWt', width: 64, edit: 'ghtWt' },
  { label: 'Touch', field: 'touch', width: 60, edit: 'touch' },
  { label: 'West%', field: 'westPct', width: 60, edit: 'westPct' },
  { label: 'Fine', field: 'fine', width: 72, edit: 'fine' },
  { label: 'LbrRate', field: 'lbrRate', width: 64, edit: 'lbrRate' },
  { label: 'LbrAmt', field: 'lbrAmt', width: 72, edit: 'lbrAmt' },
  { label: 'OthAmt', field: 'othAmt', width: 72, edit: 'othAmt' },
  { label: 'Mrp', field: 'mrp', width: 80, edit: 'mrp' },
];

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
const DECIMALS: Record<string, number> = {
  pcs: 0,
  grossWt: 3,
  lessWt: 3,
  netWt: 3,
  ghtWt: 3,
  touch: 2,
  westPct: 2,
  fine: 3,
  lbrRate: 2,
  lbrAmt: 2,
  othAmt: 2,
  mrp: 2,
};

const message = (caught: unknown, fallback: string): string =>
  caught instanceof ApiError
    ? String(caught.body?.message || caught.body?.error || caught.body?.detail || caught.message)
    : fallback;

interface SavedView {
  voucherNo: string;
  vchDate: string;
  voucherTime: string;
  hiddenVoucherNo: string;
  mainUser: string;
  empCode: string;
  acCode: string;
  vchDesc: string;
  drTouch?: number;
  crTouch?: number;
  crLbr?: number;
  parents: Array<Record<string, unknown>>;
  children: Array<Record<string, unknown>>;
}

interface Listing {
  nextVoucherNo: string;
  vouchers: Array<{
    vchNo: string;
    vchDate: string;
    partyName: string;
    vchDesc: string;
    mainUser: string;
    children: number;
  }>;
}

export function TagSplitForm() {
  const { lcCode, coYear } = useBusinessScope();
  const companyValues = useCompanySettings();
  const settings = useMemo(() => tagSplitSettings(companyValues), [companyValues]);
  const [coBook, setCoBook] = useState('');
  const [header, setHeader] = useState<SplitHeaderDraft>(() => blankHeader());
  const [parents, setParents] = useState<ParentRow[]>(() => [blankParent()]);
  const [children, setChildren] = useState<ChildRow[]>(() => [blankChild(settings)]);
  const [voucherNo, setVoucherNo] = useState('');
  const [loaded, setLoaded] = useState<SavedView | null>(null);
  const [listing, setListing] = useState<Listing | null>(null);
  const [showList, setShowList] = useState(false);
  const [activeChild, setActiveChild] = useState(0);
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  const [status, setStatus] = useState('');
  const latestParents = useRef(parents);
  useEffect(() => {
    latestParents.current = parents;
  }, [parents]);
  const id = (name: string) => `tag-split-${name}`;

  const parentNet = useMemo(() => parentNetTotal(parents), [parents]);
  const totals = useMemo(() => childTotals(children), [children]);
  const balance = useMemo(
    () => splitBalance(parents, children, Number(header.drTouch || 0), Number(header.crTouch || 0)),
    [parents, children, header.drTouch, header.crTouch],
  );
  const conserved = useMemo(() => conserves(parents, children), [parents, children]);

  useEffect(() => {
    setChildren((all) =>
      all.map((row) =>
        row.itCode || row.oldSrNo || row.lbrType === settings.companyLabourType
          ? row
          : { ...row, lbrType: settings.companyLabourType },
      ),
    );
  }, [settings.companyLabourType]);

  // ---- rows ----------------------------------------------------------------------------------------
  const updateParent = (index: number, change: (row: ParentRow) => ParentRow) =>
    setParents((all) => {
      const next = all.map((row, i) => (i === index ? change(row) : row));
      const last = next[next.length - 1];
      return last && last.fromTag ? [...next, blankParent()] : next;
    });
  const updateChild = (index: number, change: (row: ChildRow) => ChildRow) =>
    setChildren((all) =>
      withSpareChild(
        all.map((row, i) => (i === index ? change(row) : row)),
        settings,
      ),
    );

  const childKeys = useGridKeyboard({
    rowCount: children.length,
    onAppendRow: () => setChildren((all) => [...all, blankChild(settings)]),
    onRemoveRow: (row) => {
      if (!window.confirm('This Row Record will Removed permantley ?')) return false;
      setChildren((all) => {
        const left = all.filter((_, i) => i !== row);
        return left.length ? withSpareChild(left, settings) : [blankChild(settings)];
      });
      setActiveChild((position) => Math.max(0, Math.min(position, children.length - 2)));
      return true;
    },
    onEscape: () => setError(''),
  });

  // ---- parent entry --------------------------------------------------------------------------------
  const filling = useRef(new Set<number>());
  async function fillParent(index: number, tagNo: string, vchSrno?: number) {
    const wanted = typedText(tagNo).trim();
    if (!wanted) return;
    if (duplicateParent(latestParents.current, index, wanted)) {
      setError(`Duplicate Tag No: ${wanted}`);
      return;
    }
    filling.current.add(index);
    try {
      const query = new URLSearchParams({ coBook, tagNo: wanted });
      if (vchSrno) query.set('vchSrno', String(vchSrno));
      const source = await get<TagSourceView>(`/stock/tag-split/source?${query}`);
      updateParent(index, (row) => parentFromSource(source, row));
      setError('');
    } catch (caught) {
      setError(message(caught, 'tag lookup failed'));
    } finally {
      filling.current.delete(index);
    }
  }
  async function resolveTypedParent(index: number) {
    const row = latestParents.current[index];
    if (filling.current.has(index) || !row) return;
    const typed = row.tagNo.trim();
    if (!typed || typed === row.filledTag) return;
    try {
      const found = await get<LookupRow[]>(
        `/lookup/available-tags?q=${encodeURIComponent(typed)}&limit=10`,
      );
      const exact = (found ?? []).filter(
        (c) =>
          String(c.code ?? '')
            .trim()
            .toUpperCase() === typed,
      );
      if (exact.length === 1)
        await fillParent(index, typed, Number(exact[0]!.VCH_SRNO) || undefined);
      else if (exact.length > 1)
        setError(`Tag ${typed} has ${exact.length} live instances; pick one from the list (F1)`);
      else setError(`tag not available for split: ${typed}`);
    } catch (caught) {
      setError(message(caught, 'tag lookup failed'));
    }
  }

  // ---- lifecycle -----------------------------------------------------------------------------------
  const refreshListing = useCallback(async (book: string): Promise<Listing | null> => {
    if (!book) return null;
    try {
      const view = await get<Listing>(`/stock/tag-split?coBook=${encodeURIComponent(book)}`);
      setListing(view);
      return view;
    } catch (caught) {
      setError(message(caught, 'Tag Split list failed'));
      return null;
    }
  }, []);

  function clearScreen(next?: Listing | null) {
    setHeader(blankHeader());
    setParents([blankParent()]);
    setChildren([blankChild(settings)]);
    setLoaded(null);
    setActiveChild(0);
    setVoucherNo((next ?? listing)?.nextVoucherNo ?? '');
  }

  useEffect(() => {
    setLoaded(null);
    setParents([blankParent()]);
    setChildren([blankChild(settings)]);
    setHeader(blankHeader());
    setError('');
    setStatus('');
    void refreshListing(coBook).then((view) => setVoucherNo(view?.nextVoucherNo ?? ''));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [coBook]);

  async function open(no: string): Promise<SavedView> {
    const view = await get<SavedView>(
      `/stock/tag-split/${encodeURIComponent(no)}?coBook=${encodeURIComponent(coBook)}`,
    );
    setLoaded(view);
    setVoucherNo(view.voucherNo);
    setHeader({
      vchDate: view.vchDate,
      empCode: view.empCode,
      empName: '',
      acCode: view.acCode,
      acName: '',
      vchDesc: view.vchDesc,
      drTouch: view.drTouch ? String(view.drTouch) : '',
      crTouch: view.crTouch ? String(view.crTouch) : '',
      crLbr: view.crLbr ? String(view.crLbr) : '',
    });
    setParents([...view.parents.map(parentFromSaved), blankParent()]);
    setChildren(
      withSpareChild(
        view.children.map((line) => childFromSaved(line, settings)),
        settings,
      ),
    );
    setActiveChild(0);
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
      setError(message(caught, 'Tag Split load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function step(direction: 'previous' | 'next') {
    const numbers = (listing?.vouchers ?? []).map((v) => v.vchNo);
    const target = neighbourVoucher(numbers, loaded?.voucherNo ?? voucherNo, direction);
    if (!target) {
      setStatus(direction === 'next' ? 'Last Record...' : 'First Record...');
      return;
    }
    await load(target);
  }

  async function save() {
    const pending = parents.findIndex((p) => p.tagNo.trim() && p.tagNo.trim() !== p.filledTag);
    if (pending >= 0) {
      setError(
        `Parent ${pending + 1}: resolve tag ${parents[pending]!.tagNo.trim()} before saving`,
      );
      return;
    }
    if (!header.acCode.trim() && !conserved) {
      setError('The children must add up to the parent net weight, or set an absorbing account.');
      return;
    }
    setBusy(true);
    setError('');
    setStatus('');
    try {
      const body = voucherPayload(header, parents, children, { coBook, coYear, lcCode });
      const verb = loaded ? 'Updated' : 'Saved';
      const result = loaded
        ? await put<{ vchNo: number; voucherNo: string }>(
            `/stock/tag-split/${encodeURIComponent(loaded.voucherNo)}`,
            body,
          )
        : await post<{ vchNo: number; voucherNo: string }>('/stock/tag-split', body);
      const saved = result.voucherNo ?? String(result.vchNo).padStart(5, '0');
      try {
        const view = await open(saved);
        setStatus(`${verb} voucher ${view.voucherNo}`);
      } catch (caught) {
        setStatus(`${verb} voucher ${saved}`);
        setError(`Saved, but reloading it failed: ${message(caught, 'reload failed')}`);
      }
      void refreshListing(coBook);
    } catch (caught) {
      setError(message(caught, 'Tag Split save failed'));
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
        `/stock/tag-split/${encodeURIComponent(loaded.voucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      const deleted = loaded.voucherNo;
      const view = await refreshListing(coBook);
      clearScreen(view);
      setStatus(`Delete Success. Voucher ${deleted}`);
    } catch (caught) {
      setError(message(caught, 'Tag Split delete failed'));
    } finally {
      setBusy(false);
    }
  }

  const hasParent = parents.some((p) => p.fromTag);
  const hasChild = children.some((c) => c.itCode.trim());
  const canSave = !!coBook && hasParent && hasChild && !busy;
  const activeIndex = Math.min(activeChild, children.length - 1);
  const current = children[activeIndex];
  const stoneRows = (current?.stones ?? []) as SubDetailRow[];

  const parentCell = (column: Column, row: ParentRow, index: number) => {
    if (column.field === 'sr') return <td className="muted">{index + 1}</td>;
    if (column.field === 'tagNo') {
      return (
        <td onBlur={() => void resolveTypedParent(index)}>
          <LookupPicker
            entity="available-tags"
            value={row.tagNo}
            onChange={(value) => updateParent(index, (r) => ({ ...r, tagNo: typedText(value) }))}
            onPick={(picked) =>
              void fillParent(
                index,
                String(picked.code ?? ''),
                Number(picked.VCH_SRNO) || undefined,
              )
            }
            placeholder="parent tag… (F1)"
            ariaLabel={`TagNo parent ${index + 1}`}
            style={{ minWidth: column.width }}
          />
        </td>
      );
    }
    const value = String((row as unknown as Record<string, unknown>)[column.field] ?? '');
    return (
      <td className={column.display ? 'num' : undefined}>
        <input
          readOnly
          tabIndex={-1}
          aria-label={`${column.label} parent ${index + 1}`}
          value={column.display ? showCell(value, DECIMALS[column.field] ?? 3) : value}
          style={{
            width: column.width,
            ...(column.display ? computedStyle : { background: '#f4f6f9' }),
          }}
        />
      </td>
    );
  };

  const childCell = (column: Column, row: ChildRow, index: number) => {
    if (column.field === 'sr') return <td className="muted">{index + 1}</td>;
    if (column.field === 'itCode') {
      return (
        <td>
          <LookupPicker
            entity="items"
            value={row.itCode}
            onChange={(value) => updateChild(index, (r) => ({ ...r, itCode: typedText(value) }))}
            onPick={(picked) =>
              updateChild(index, (r) => ({
                ...r,
                itCode: String(picked.code ?? ''),
                itName: String(picked.name ?? ''),
                itType: String(picked.IT_TYPE ?? r.itType),
                rateType: String(picked.RATE_TYPE ?? r.rateType),
              }))
            }
            placeholder="item… (F1)"
            ariaLabel={`ItCode child ${index + 1}`}
            style={{ minWidth: column.width }}
          />
        </td>
      );
    }
    if (column.field === 'tagNo') {
      return (
        <td>
          <input
            readOnly
            tabIndex={-1}
            aria-label={`TagNo child ${index + 1}`}
            value={row.tagNo || (row.itCode ? '(on save)' : '')}
            style={{ width: column.width, ...computedStyle }}
          />
        </td>
      );
    }
    if (column.text) {
      return (
        <td>
          <input
            aria-label={`${column.label} child ${index + 1}`}
            value={String((row as unknown as Record<string, unknown>)[column.text] ?? '')}
            onChange={(event) =>
              updateChild(index, (r) => setChildCell(r, column.text!, event.target.value))
            }
            style={{ width: column.width, textTransform: 'uppercase' }}
          />
        </td>
      );
    }
    if (column.edit) {
      const cell = column.edit;
      return (
        <td className="num">
          <input
            aria-label={`${column.label} child ${index + 1}`}
            data-testid={id(`${cell}-${index}`)}
            value={String((row as unknown as Record<string, unknown>)[cell] ?? '')}
            inputMode="decimal"
            onChange={(event) =>
              updateChild(index, (r) => setChildCell(r, cell, event.target.value))
            }
            onFocus={() => setActiveChild(index)}
            onBlur={() => updateChild(index, (r) => commitChildCell(r, cell, settings))}
            style={{ width: column.width, textAlign: 'right' }}
          />
        </td>
      );
    }
    return <td />;
  };

  return (
    <div data-testid={id('form')}>
      <h1>Tag Split</h1>
      <p className="muted">
        Desktop TR_TAG_SPLIT on a TAG SPLIT book. A parent tag is consumed and child tags are
        created, conserving the metal (MAIN_STOCK parent −, children +).
      </p>
      <div className="panel">
        <div className="row" style={{ flexWrap: 'wrap', alignItems: 'flex-end' }}>
          <div className="field">
            <label>Book</label>
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={['TAG SPLIT']} />
          </div>
          <div className="field" style={{ flex: '0 0 auto' }}>
            <label htmlFor={id('vch-no')}>Vch No</label>
            <div className="toolbar" style={{ gap: 4, flexWrap: 'nowrap', marginBottom: 0 }}>
              <button
                type="button"
                className="ghost"
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
                  }
                }}
              />
              <button
                type="button"
                className="ghost"
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
                onClick={() => setShowList((o) => !o)}
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
              onChange={(e) => setHeader((h) => ({ ...h, vchDate: e.target.value }))}
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
            {header.empName ? (
              <span className="muted" data-testid={id('emp-name')}>
                {header.empName}
              </span>
            ) : null}
          </div>
          <div className="field">
            <label>Absorbing A/c</label>
            <LookupPicker
              entity="accounts"
              value={header.acCode}
              onChange={(value) =>
                setHeader((h) => ({ ...h, acCode: typedText(value), acName: '' }))
              }
              onPick={(picked) =>
                setHeader((h) => ({
                  ...h,
                  acCode: String(picked.code ?? ''),
                  acName: String(picked.name ?? ''),
                }))
              }
              placeholder="account… (F1)"
              ariaLabel="Absorbing account"
              style={{ width: 130 }}
            />
          </div>
          <div className="field" style={{ flex: 1, minWidth: 200 }}>
            <label htmlFor={id('vch-desc')}>Vch Desc</label>
            <input
              id={id('vch-desc')}
              data-testid={id('vch-desc')}
              value={header.vchDesc}
              maxLength={255}
              style={{ textTransform: 'uppercase' }}
              onChange={(e) => setHeader((h) => ({ ...h, vchDesc: typedText(e.target.value) }))}
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
                  <th className="num">Children</th>
                </tr>
              </thead>
              <tbody>
                {listing.vouchers.map((v) => (
                  <tr
                    key={v.vchNo}
                    style={{ cursor: 'pointer' }}
                    onClick={() => {
                      setShowList(false);
                      void load(v.vchNo);
                    }}
                  >
                    <td>{v.vchNo}</td>
                    <td>{v.vchDate}</td>
                    <td>{v.partyName}</td>
                    <td>{v.vchDesc}</td>
                    <td>{v.mainUser}</td>
                    <td className="num">{v.children}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        ) : null}
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h3 style={{ margin: '0 0 6px' }}>Parent (issued)</h3>
        <table className="grid dense" data-testid={id('parent-grid')}>
          <thead>
            <tr>
              {PARENT_COLUMNS.map((c) => (
                <th key={c.label} className={c.display ? 'num' : undefined}>
                  {c.label}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {parents.map((row, index) => (
              <tr key={row.id} data-testid={id(`parent-row-${index}`)}>
                {PARENT_COLUMNS.map((c) => (
                  <span key={c.field} style={{ display: 'contents' }}>
                    {parentCell(c, row, index)}
                  </span>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h3 style={{ margin: '0 0 6px' }}>Children (received)</h3>
        <table className="grid dense" onKeyDown={childKeys} data-testid={id('child-grid')}>
          <thead>
            <tr>
              {CHILD_COLUMNS.map((c) => (
                <th key={c.label} className={c.edit || c.display ? 'num' : undefined}>
                  {c.label}
                </th>
              ))}
            </tr>
          </thead>
          <tbody>
            {children.map((row, index) => (
              <tr
                key={row.id}
                data-testid={id(`child-row-${index}`)}
                onClick={() => setActiveChild(index)}
                style={index === activeIndex ? { outline: '1px solid #9bb4d6' } : undefined}
              >
                {CHILD_COLUMNS.map((c) => (
                  <span key={c.field} style={{ display: 'contents' }}>
                    {childCell(c, row, index)}
                  </span>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
        <div
          className="toolbar"
          data-testid={id('conservation')}
          style={{ marginTop: 6, color: conserved || header.acCode.trim() ? undefined : '#a11' }}
        >
          <span data-testid={id('parent-net')}>
            Parent net: {showCell(String(parentNet), 3) || '0.000'}
          </span>
          <span className="spacer" />
          <span data-testid={id('child-net')}>
            Children net: {showCell(String(totals.netWt), 3) || '0.000'}
          </span>
          <span className="spacer" />
          <span data-testid={id('difference')}>
            {balance.drWt
              ? `Short ${showCell(String(balance.drWt), 3)}`
              : balance.crWt
                ? `Surplus ${showCell(String(balance.crWt), 3)}`
                : 'Balanced'}
          </span>
        </div>
      </div>

      <div className="row" style={{ alignItems: 'flex-start', flexWrap: 'wrap' }}>
        <div style={{ flex: '1 1 1000px', minWidth: 0 }}>
          <SubDetailGrid
            rows={stoneRows.length ? stoneRows : [{}]}
            onRowsChange={(stones) =>
              updateChild(activeIndex, (r) => ({
                ...r,
                stones: stones as StoneDraft[],
                stonesEdited: true,
              }))
            }
            onCellCommit={(stoneIndex) =>
              updateChild(activeIndex, (r) => commitChildStone(r, stoneIndex, settings))
            }
            columns={STONE_COLUMNS}
            parentLabel={`child ${activeIndex + 1}${current?.itCode ? ` — ${current.itCode}` : ''}`}
            desktopSource="TR_TAG_SPLIT / MSG_RTN_IDTL"
            disabled={!current?.itCode.trim()}
            testId={id('stone')}
          />
        </div>
        <div style={{ flex: '0 1 360px', minWidth: 260 }}>
          {parents[0]?.fromTag && parents[0].filledTag ? (
            <EntityImagePanel
              entityType="TAG"
              entityKey={parents[0].filledTag}
              instance={Number(parents[0].vchSrno) || 0}
              label="Parent tag image"
              disabled
              testId={id('image')}
            />
          ) : (
            <div className="panel muted">Parent tag image — choose a parent tag</div>
          )}
        </div>
      </div>

      <div className="toolbar" style={{ marginTop: 10 }}>
        <button
          type="button"
          className="primary"
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
