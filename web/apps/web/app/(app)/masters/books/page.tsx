'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import {
  BookSlotGrid,
  type BookSlotGridHandle,
  type BookSlotRow,
} from '../../../../components/BookSlotGrid';
import {
  NO_RIGHTS,
  NO_PRINT_RIGHTS,
  RESERVED,
  SHORT_REQUIRED,
  DETAIL_REQUIRED,
  NAME_FIRST,
  SAVED,
  SELECT_FOR_DELETE,
  DELETE_CONFIRM,
  DELETED,
  SEARCH_TEXT,
  RESERVED_CODES,
  codeTaken,
  nameTaken,
  CUR_USE,
  ITEM_TYPES,
  DIRECTIONS,
  INVOICE_TYPES,
  blankHeader,
  typed,
  toRows,
  messageOf,
  type Rights,
  type ListRow,
  type Header,
  type SlotView,
} from './bookScreen';

/**
 * Company → Books (desktop MS_BOOK, opened directly by MDI_FORM.cs:7443-7448): "Book Master". The boxes in the form's
 * tab order (Book Code, Book Name, Book Short, Cur In Use, Transaction Name, Item Type, Tran In / Out, Invoice Type,
 * ReSet Book, Vch Serice, Trfr Book, With Mobile Entry), the slot grid Sr / Account Desc / AcCode / AcName, the
 * Code / Name / Trfr list with its search box, and Save, Print, Cancel, Delete, Exit.
 *
 * - CLEAR_DATA (:2434-2466): blank boxes, Yes / All / Inword / Free, a blank family, an empty grid, add mode, the
 *   cursor in the code. Enter on a code a book has opens it (:2996-3003); Enter on the list or a double click opens the
 *   selected book with the cursor in the name (:2895-2903, :3015).
 * - An opened book's code and mobile-entry box are read-only and its direction and invoice type disabled
 *   (:2526, :2564-2566). Ctrl+O, which re-enables them on the desktop, is not ported (decision D6); nor are the
 *   edition A/E Data Type box and Reset All button or the edition E employee boxes (:2113, :3064).
 * - Enter moves through the boxes (:2917); a blank name refuses Enter in Book Name and Book Short (:2875-2882); the
 *   Transaction Name Enter rebuilds the grid from the family's template and, for a new book, sets the direction from
 *   its first row (:2922-2970); ReSet Book and Trfr Book Enter go to Vch Serice (:3037, :3058); Vch Serice Enter starts
 *   the grid at row 1 (:2978-2982). F1 goes to the search box; Esc leaves the screen (:2849-2851). Alt+S/P/C/D/X are the
 *   buttons' mnemonics (:1623-1676).
 * - Save, Delete and Print answer with the desktop texts and rights (:2570-2726). With the Print right the desktop's
 *   Print does nothing; the list's CSV export behind the same right is a web addition (decision D7).
 * Web rules (G252): the server refuses what the screen refuses; a book with vouchers keeps its family (D4); an opened
 * book carries its version.
 */
export default function BooksPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [list, setList] = useState<ListRow[]>([]);
  const [families, setFamilies] = useState<string[]>([]);
  const [rights, setRights] = useState<Rights | null>(null);
  const [header, setHeader] = useState<Header>(blankHeader);
  const [slots, setSlots] = useState<BookSlotRow[]>([]);
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [search, setSearch] = useState(SEARCH_TEXT);
  const [current, setCurrent] = useState(0);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const refs = {
    code: useRef<HTMLInputElement>(null),
    name: useRef<HTMLInputElement>(null),
    short: useRef<HTMLInputElement>(null),
    curUse: useRef<HTMLSelectElement>(null),
    family: useRef<HTMLSelectElement>(null),
    itemType: useRef<HTMLSelectElement>(null),
    inout: useRef<HTMLSelectElement>(null),
    bookType: useRef<HTMLSelectElement>(null),
    resetBook: useRef<HTMLInputElement>(null),
    vchSeries: useRef<HTMLInputElement>(null),
    trfrBook: useRef<HTMLInputElement>(null),
    mobileEntry: useRef<HTMLInputElement>(null),
  };
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);
  const gridHandle = useRef<BookSlotGridHandle | null>(null);
  const focusAfterLoad = useRef<'code' | 'name' | null>(null);
  /** The newest open/template request: an older answer arriving late is dropped. */
  const requestNo = useRef(0);

  useEffect(() => {
    if (busy || !focusAfterLoad.current) return;
    const which = focusAfterLoad.current;
    focusAfterLoad.current = null;
    refs[which].current?.focus();
  });

  /** CLEAR_DATA: blank boxes, the combos' first entries, an empty grid, the list read again, the cursor in the code. */
  const clear = useCallback(async () => {
    requestNo.current += 1;
    setBusy(true);
    try {
      const view = await get<{ rows: ListRow[]; families: string[]; rights: Rights }>(
        '/masters/books-master',
      );
      setList(view.rows);
      setFamilies(view.families);
      setRights(view.rights);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setHeader(blankHeader);
      setSlots([]);
      setEntryMode('A');
      setVersion('');
      setSearch(SEARCH_TEXT);
      setCurrent(0);
      focusAfterLoad.current = 'code';
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void clear();
  }, [clear]);

  /** Text1_TextChanged: BOOK_NAME LIKE 'text%' OR CO_BOOK LIKE 'text%' (:2824); SEARCH RECORD lists every book. */
  const shown = useMemo(() => {
    const wanted = search === SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted
      ? list.filter(
          (row) => row.name.toUpperCase().startsWith(wanted) || row.code.startsWith(wanted),
        )
      : list;
  }, [list, search]);

  /** DISPLAY_DATA (:2468-2568): the header, the family template under the saved slots, edit mode. */
  async function open(code: string, focus: 'code' | 'name') {
    if (!code) return;
    const mine = ++requestNo.current;
    setBusy(true);
    setMsg(null);
    try {
      const found = await get<Header & { slots: SlotView[]; version: string }>(
        `/masters/books-master/${encodeURIComponent(code)}`,
      );
      if (mine !== requestNo.current) return;
      setHeader({
        code: found.code,
        name: found.name,
        short: found.short,
        curUse: found.curUse,
        family: found.family,
        itemType: found.itemType,
        inout: found.inout,
        bookType: found.bookType,
        resetBook: found.resetBook,
        vchSeries: found.vchSeries,
        trfrBook: found.trfrBook,
        mobileEntry: found.mobileEntry,
      });
      setSlots(toRows(found.slots));
      setEntryMode('E');
      setVersion(found.version);
      focusAfterLoad.current = focus;
    } catch (error) {
      if (mine === requestNo.current) setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      if (mine === requestNo.current) setBusy(false);
    }
  }

  /** cboTrnsNm_KeyDown (:2922-2970): the family's grid; a new book takes the first row's direction. */
  async function loadFamily(family: string) {
    const mine = ++requestNo.current;
    if (!family) return setSlots([]);
    try {
      const code = entryMode === 'E' ? `&code=${encodeURIComponent(header.code)}` : '';
      const template = await get<{ inout: string; slots: SlotView[] }>(
        `/masters/books-master/template?family=${encodeURIComponent(family)}${code}`,
      );
      if (mine !== requestNo.current) return;
      setSlots(toRows(template.slots));
      if (entryMode === 'A' && template.inout) setHeader((h) => ({ ...h, inout: template.inout }));
    } catch (error) {
      if (mine === requestNo.current) setMsg({ kind: 'err', text: messageOf(error) });
    }
  }

  const set = (key: keyof Header, value: string) => setHeader((h) => ({ ...h, [key]: value }));
  const fail = (text: string, focus?: keyof typeof refs) => {
    setMsg({ kind: 'err', text });
    if (focus)
      setTimeout(() => {
        refs[focus].current?.focus();
        (refs[focus].current as HTMLInputElement | null)?.select?.();
      }, 0);
    return false;
  };

  /** tBkCode_Validating (:2768-2781): a new book may not take a code another book has. */
  function codeFree() {
    if (entryMode !== 'A') return true;
    const other = list.find((row) => row.code === header.code.trim());
    if (other && other.name.toUpperCase() !== header.name.trim().toUpperCase())
      return fail(codeTaken(other.name), 'code');
    return true;
  }
  /** tBkName_Validating (:2790-2803): the name may not be another code's. */
  function nameFree() {
    const name = header.name.trim().toUpperCase();
    const other =
      name &&
      list.find((row) => row.name.toUpperCase() === name && row.code !== header.code.trim());
    if (other) return fail(nameTaken(other.code), 'name');
    return true;
  }

  const refusal = (error: unknown, forbidden: string) =>
    error instanceof ApiError && error.status === 403 ? forbidden : messageOf(error);

  /** BtnSave_Click (:2579-2685), its checks in its order. */
  async function save() {
    setMsg(null);
    if (entryMode === 'E' && rights && !rights.canUpdate) return void fail(NO_RIGHTS);
    const code = header.code.trim();
    if (RESERVED_CODES.includes(code)) return void fail(RESERVED, 'code');
    if (!header.short.trim()) return void fail(SHORT_REQUIRED, 'short');
    if (!code || !header.name.trim()) return void fail(DETAIL_REQUIRED);
    if (!codeFree() || !nameFree()) return;
    setBusy(true);
    try {
      const payload = {
        ...header,
        code,
        name: header.name.trim(),
        slots: slots.map((row) => ({ srNo: row.srNo, acCode: row.acCode.trim() })),
      };
      if (entryMode === 'E')
        await put(`/masters/books-master/${encodeURIComponent(code)}`, {
          ...payload,
          expectedVersion: version,
        });
      else await post('/masters/books-master', payload);
      await clear();
      setMsg({ kind: 'ok', text: SAVED });
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
      setBusy(false);
    }
  }

  /** BtnDelete_Click (:2687-2726). */
  async function remove() {
    setMsg(null);
    if (rights && !rights.canDelete) return void fail(NO_RIGHTS);
    const code = header.code.trim();
    if (!code) return void fail(SELECT_FOR_DELETE);
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      const opened =
        entryMode === 'E' && version ? `?expectedVersion=${encodeURIComponent(version)}` : '';
      await del(`/masters/books-master/${encodeURIComponent(code)}${opened}`);
      await clear();
      setMsg({ kind: 'ok', text: DELETED });
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
      setBusy(false);
    }
  }

  /** BtnPrint_Click (:2570-2577): without the right the desktop text; with it the desktop does nothing. */
  function print() {
    setMsg(null);
    if (rights && !rights.canPrint) fail(NO_PRINT_RIGHTS);
  }
  /** Web addition behind the Print right (D7): the list as CSV. */
  async function exportCsv() {
    setMsg(null);
    if (rights && !rights.canPrint) return void fail(NO_PRINT_RIGHTS);
    try {
      const out = await get<{ rows: ListRow[] }>('/masters/books-master/print');
      const cell = (value: string) => `"${value.replace(/"/g, '""')}"`;
      const csv = [
        'Code,Name,Trfr',
        ...out.rows.map((r) => [r.code, r.name, r.trfr].map(cell).join(',')),
      ];
      const link = document.createElement('a');
      link.href = URL.createObjectURL(new Blob([csv.join('\n')], { type: 'text/csv' }));
      link.download = 'books.csv';
      link.click();
      URL.revokeObjectURL(link.href);
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_PRINT_RIGHTS) });
    }
  }

  const toSearch = () => {
    setSearch((s) => (s === SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

  /** MS_BOOK_KeyDown with KeyPreview: Esc leaves the screen (:2849-2851); Alt+S/P/C/D/X press the buttons. */
  function onScreenKeyDown(event: ScreenKeyEvent & { altKey?: boolean; metaKey?: boolean }) {
    if (event.defaultPrevented) return;
    if (event.key === 'Escape') {
      if ((event.target as HTMLElement).closest?.('[data-lookup-open="true"]')) return;
      event.preventDefault();
      return router.back();
    }
    if (!event.altKey || event.ctrlKey || event.metaKey || busy) return;
    const actions: Record<string, () => unknown> = {
      s: save,
      p: print,
      c: clear,
      d: remove,
      x: () => router.back(),
    };
    const action = actions[event.key.toLowerCase()];
    if (!action) return;
    event.preventDefault();
    void action();
  }
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);

  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  function onListKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    if (event.key === 'F1') {
      event.preventDefault();
      toSearch();
    } else if (event.key === 'Enter') {
      event.preventDefault();
      const row = shown[current];
      if (row) void open(row.code, 'name');
    } else if (event.key === 'Backspace') {
      event.preventDefault();
      setSearch((s) => (s === SEARCH_TEXT ? s : s.slice(0, -1)));
      setCurrent(0);
    } else if (event.key === 'ArrowDown' || event.key === 'ArrowUp') {
      event.preventDefault();
      const next = Math.max(
        0,
        Math.min(shown.length - 1, current + (event.key === 'ArrowDown' ? 1 : -1)),
      );
      setCurrent(next);
      listRows()[next]?.focus();
    }
  }

  /** Enter moves on (SendKeys "{TAB}"), skipping a disabled box. */
  const enterTo =
    (next: () => void) => (event: KeyboardEvent<HTMLInputElement | HTMLSelectElement>) => {
      if (event.key !== 'Enter') return;
      event.preventDefault();
      next();
    };
  const nameFirst = (next: keyof typeof refs) =>
    enterTo(() =>
      header.name.trim() ? refs[next].current?.focus() : void fail(NAME_FIRST, 'name'),
    );
  const locked = entryMode === 'E';
  const box = (
    key: 'code' | 'name' | 'short' | 'resetBook' | 'vchSeries' | 'trfrBook' | 'mobileEntry',
    label: string,
    maxLength: number,
    width: number,
    extra: Partial<React.InputHTMLAttributes<HTMLInputElement>> = {},
  ) => (
    <div className="field">
      <label htmlFor={`book-${key}`}>{label}</label>
      <input
        id={`book-${key}`}
        ref={refs[key]}
        value={header[key]}
        maxLength={maxLength}
        style={{ width }}
        onChange={(e) => set(key, key === 'name' ? e.target.value : typed(e.target.value))}
        {...extra}
      />
    </div>
  );
  const combo = (
    key: 'curUse' | 'itemType' | 'inout' | 'bookType',
    label: string,
    entries: string[],
    next: () => void,
    disabled = false,
  ) => (
    <div className="field">
      <label htmlFor={`book-${key}`}>{label}</label>
      <select
        id={`book-${key}`}
        ref={refs[key]}
        value={header[key]}
        disabled={disabled}
        style={{ width: 130 }}
        onChange={(e) => set(key, e.target.value)}
        onKeyDown={enterTo(next)}
      >
        {entries.map((entry) => (
          <option key={entry} value={entry[0]}>
            {entry}
          </option>
        ))}
      </select>
    </div>
  );
  const afterItemType = () => (locked ? refs.resetBook : refs.inout).current?.focus();
  const afterDirection = () => (locked ? refs.resetBook : refs.bookType).current?.focus();

  return (
    <div ref={screenRef} onKeyDown={onScreenKeyDown}>
      <h1>Book Master</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: 'minmax(600px, 1fr) 360px',
          gridTemplateAreas: '"fields list" "buttons list"',
          gap: '12px 24px',
          alignItems: 'start',
        }}
      >
        <div className="panel" style={{ gridArea: 'fields' }}>
          <div className="row" style={{ gap: 12, flexWrap: 'wrap', alignItems: 'flex-end' }}>
            {box('code', 'Book Code', 3, 60, {
              readOnly: locked,
              onBlur: codeFree,
              onKeyDown: (event) => {
                if (event.key === 'F1') {
                  event.preventDefault();
                  toSearch();
                } else if (event.key === 'Enter') {
                  event.preventDefault();
                  const code = header.code.trim();
                  if (!locked && code && list.some((row) => row.code === code))
                    void open(code, 'name');
                  else refs.name.current?.focus();
                }
              },
            })}
            {box('name', 'Book Name', 50, 300, { onBlur: nameFree, onKeyDown: nameFirst('short') })}
            {box('short', 'Book Short', 5, 70, { onKeyDown: nameFirst('curUse') })}
          </div>
          <div className="row" style={{ gap: 12, flexWrap: 'wrap', alignItems: 'flex-end' }}>
            {combo('curUse', 'Cur In Use', CUR_USE, () => refs.family.current?.focus())}
            <div className="field">
              <label htmlFor="book-family">Transaction Name</label>
              <select
                id="book-family"
                ref={refs.family}
                value={header.family}
                style={{ width: 200 }}
                onChange={(e) => {
                  set('family', e.target.value);
                  void loadFamily(e.target.value);
                }}
                onKeyDown={enterTo(() => refs.itemType.current?.focus())}
              >
                <option value="" />
                {[...new Set([...families, header.family].filter(Boolean))].map((family) => (
                  <option key={family} value={family}>
                    {family}
                  </option>
                ))}
              </select>
            </div>
            {combo('itemType', 'Item Type', ITEM_TYPES, afterItemType)}
            {combo('inout', 'Tran In / Out', DIRECTIONS, afterDirection, locked)}
            {combo(
              'bookType',
              'Invoice Type',
              INVOICE_TYPES,
              () => refs.resetBook.current?.focus(),
              locked,
            )}
          </div>
          <div className="row" style={{ gap: 12, flexWrap: 'wrap', alignItems: 'flex-end' }}>
            {box('resetBook', 'ReSet Book', 5, 70, {
              onKeyDown: enterTo(() => refs.vchSeries.current?.focus()),
            })}
            {box('vchSeries', 'Vch Serice', 15, 150, {
              onKeyDown: enterTo(() => {
                if (!gridHandle.current?.start()) refs.trfrBook.current?.focus();
              }),
            })}
            {box('trfrBook', 'Trfr Book', 5, 70, {
              onKeyDown: enterTo(() => refs.vchSeries.current?.focus()),
            })}
            {box('mobileEntry', 'With Mobile Entry', 1, 40, {
              readOnly: locked,
              onKeyDown: enterTo(() => saveRef.current?.focus()),
            })}
          </div>
          <BookSlotGrid
            rows={slots}
            onChange={(index, patch) =>
              setSlots((rows) => rows.map((row, i) => (i === index ? { ...row, ...patch } : row)))
            }
            saveRef={saveRef}
            handleRef={gridHandle}
            disabled={busy}
          />
        </div>
        <div className="row" style={{ gridArea: 'buttons', gap: 8, justifyContent: 'flex-end' }}>
          <button
            ref={saveRef}
            type="button"
            className="primary"
            data-save-mnemonic
            disabled={busy}
            onClick={() => void save()}
          >
            Save
          </button>
          <button type="button" className="ghost" disabled={busy} onClick={print}>
            Print
          </button>
          <button type="button" className="ghost" disabled={busy} onClick={() => void clear()}>
            Cancel
          </button>
          <button type="button" className="danger" disabled={busy} onClick={() => void remove()}>
            Delete
          </button>
          <button type="button" className="ghost" onClick={() => router.back()}>
            Exit
          </button>
          <button type="button" className="ghost" disabled={busy} onClick={() => void exportCsv()}>
            Export CSV
          </button>
        </div>
        <div className="panel" style={{ gridArea: 'list', width: 360 }}>
          <input
            ref={searchRef}
            aria-label="Search record"
            value={search}
            maxLength={50}
            onFocus={() => setSearch((s) => (s === SEARCH_TEXT ? '' : s))}
            onChange={(e) => {
              setSearch(typed(e.target.value));
              setCurrent(0);
            }}
            style={{ width: '100%' }}
          />
          <table className="grid" style={{ marginTop: 6 }}>
            <thead>
              <tr>
                <th style={{ width: 60 }}>Code</th>
                <th>Name</th>
                <th style={{ width: 60 }}>Trfr</th>
              </tr>
            </thead>
            <tbody ref={listRef} data-testid="book-list" onKeyDown={onListKeyDown}>
              {shown.map((row, i) => (
                <tr
                  key={row.code}
                  tabIndex={0}
                  aria-selected={i === current}
                  data-code={row.code}
                  className={i === current ? 'selected' : undefined}
                  onFocus={() => setCurrent(i)}
                  onDoubleClick={() => void open(row.code, 'name')}
                >
                  <td>{row.code}</td>
                  <td>{row.name}</td>
                  <td>{row.trfr}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      <FormKeyHints actions={formKeys} />
    </div>
  );
}
