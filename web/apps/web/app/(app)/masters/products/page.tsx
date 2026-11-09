'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Product master (desktop MS_PRODUCT with CurMast 'Product', Master → Product), laid out as its form spec
 * (`web/apps/api/form-specs/DataCareNext.MS_PRODUCT.layout.json`) with the scheme boxes hidden: the SEARCH RECORD box and
 * the Code / Name list on the left; Code and Name on the right; Print, Save, Cancel, Delete and Exit along the bottom.
 * The title is the menu caption (MS_PRODUCT_Load sets lblBook to CurMast).
 *
 * - A new entry has blank boxes and the cursor in the code (CLEAR_DATA, MS_PRODUCT.cs:2217-2264). Enter on the list or a
 *   double click opens a product with the cursor in the name (DGV keys :2806-2949); the code box is read-only for an
 *   opened product (DISPLAY_DATA :2266-2340).
 * - Keys: typed letters are upper-cased and the apostrophe refused (:2361-2377). Enter on the code moves on and F1 goes
 *   to the search box (:2379-2393); Enter on a blank name says "Please Insert Product Name ...", else moves on to Save
 *   (:2434-2465, the next tab stop); Up and Down from any box move to the list and Esc leaves the screen
 *   (MS_PRODUCT_KeyDown :2529-2560). In the list F1 goes to the search box and Backspace shortens it.
 * - Leaving the code refuses a code another product has, and leaving the name a name another code has (:2395-2504); a
 *   refusal also stops Save and Delete, as the desktop's cancelled Validating suppresses the button's click.
 * - Save and Delete answer with the desktop texts and rights (:2570-2804); Delete asks first and then refuses a product an
 *   item uses or a default product. Print does nothing, as BtnPrint_Click is empty (:1914-1917).
 *
 * Deliberate differences: an opened product carries the version read with it. The search box drops SEARCH RECORD
 * whenever it gets the cursor. Cancel and Exit work while a box is refused.
 */
const NO_RIGHTS = 'You Have No Rights.....';
const SAVED = 'Data Are Saved.';
const DELETED = 'Delete Success.';
const DELETE_CONFIRM = 'Are You Sure To Delete This Record now?';
const SELECT_FOR_DELETE = 'Please Select Product For Delete.';
const NAME_REQUIRED = 'Please Insert Product Name ...';
const CODE_REQUIRED = 'Enter Product Code.';
const DESC_REQUIRED = 'Enter Product Name.';
const TWO_DIGITS = 'Please Insert Product Code 2 Digit...';
const SEARCH_TEXT = 'SEARCH RECORD';
const codeTaken = (name: string) =>
  `This Product Code already Exist in  '${name}'  Product Name...Please Change Pr Code...`;
const nameTaken = (code: string) =>
  `This Product Name already Exist in  '${code}'  Product Code...Please Change Pr Name...`;

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface ListRow {
  code: string;
  name: string;
}

/** UT_TASTING_KeyPress: every typed key upper-cased, the apostrophe refused. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function ProductMasterPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [list, setList] = useState<ListRow[]>([]);
  const [rights, setRights] = useState<Rights | null>(null);
  const [code, setCode] = useState('');
  const [name, setName] = useState('');
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [search, setSearch] = useState(SEARCH_TEXT);
  const [current, setCurrent] = useState(0);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const codeRef = useRef<HTMLInputElement>(null);
  const nameRef = useRef<HTMLInputElement>(null);
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);
  const focusAfterLoad = useRef<'code' | 'name' | null>(null);

  useEffect(() => {
    if (busy || !focusAfterLoad.current) return;
    const which = focusAfterLoad.current;
    focusAfterLoad.current = null;
    (which === 'name' ? nameRef : codeRef).current?.focus();
  }, [busy, entryMode, code]);

  /** CLEAR_DATA: blank boxes, the list read again, the cursor in the code. */
  const clear = useCallback(async () => {
    setBusy(true);
    try {
      const view = await get<{ rows: ListRow[]; rights: Rights }>('/masters/product-master');
      setList(view.rows);
      setRights(view.rights);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setCode('');
      setName('');
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

  /** Text1_TextChanged: PR_NAME LIKE 'text%'; the SEARCH RECORD text lists every product. */
  const shown = useMemo(() => {
    const wanted = search === SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted ? list.filter((row) => row.name.toUpperCase().startsWith(wanted)) : list;
  }, [list, search]);

  /** DISPLAY_DATA, then the cursor in the name (DGV_KeyDown and DGV_DoubleClick). */
  async function open(openCode: string) {
    if (!openCode) return;
    setBusy(true);
    setMsg(null);
    try {
      const found = await get<{ code: string; name: string; version: string }>(
        `/masters/product-master/${encodeURIComponent(openCode)}`,
      );
      setCode(found.code);
      setName(found.name);
      setEntryMode('E');
      setVersion(found.version);
      focusAfterLoad.current = 'name';
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  /** tPrCode_Validating: a new entry may not take a code another product has (none to check in an empty list). */
  function codeFree() {
    if (entryMode !== 'A' || list.length === 0) return true;
    const other = list.find((row) => row.code === code.trim());
    if (other && other.name.toUpperCase() !== name.trim()) {
      setMsg({ kind: 'err', text: codeTaken(other.name) });
      setTimeout(() => {
        codeRef.current?.focus();
        codeRef.current?.select();
      }, 0);
      return false;
    }
    return true;
  }
  /** tPrName_Validating: the name may not be another code's. */
  function nameFree() {
    const wanted = name.trim();
    const other =
      wanted && list.find((row) => row.name.toUpperCase() === wanted && row.code !== code.trim());
    if (other) {
      setMsg({ kind: 'err', text: nameTaken(other.code) });
      setTimeout(() => {
        nameRef.current?.focus();
        nameRef.current?.select();
      }, 0);
      return false;
    }
    return true;
  }

  const refusal = (error: unknown) =>
    error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error);

  async function save() {
    setMsg(null);
    if (!codeFree() || !nameFree()) return;
    if (entryMode === 'E' && rights && !rights.canUpdate)
      return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!code.trim()) {
      setMsg({ kind: 'err', text: CODE_REQUIRED });
      return codeRef.current?.focus();
    }
    if (!name.trim()) {
      setMsg({ kind: 'err', text: DESC_REQUIRED });
      return nameRef.current?.focus();
    }
    if (code.trim().length === 1) return setMsg({ kind: 'err', text: TWO_DIGITS });
    setBusy(true);
    try {
      if (entryMode === 'E')
        await put(`/masters/product-master/${encodeURIComponent(code.trim())}`, {
          name: name.trim(),
          expectedVersion: version,
        });
      else await post('/masters/product-master', { code: code.trim(), name: name.trim() });
      setMsg({ kind: 'ok', text: SAVED });
      await clear();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    setMsg(null);
    if (!codeFree() || !nameFree()) return;
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!code.trim()) return setMsg({ kind: 'err', text: SELECT_FOR_DELETE });
    // The desktop asks first, then refuses a product an item uses or a default product (:2771-2795).
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      const opened =
        entryMode === 'E' && version ? `?expectedVersion=${encodeURIComponent(version)}` : '';
      await del(`/masters/product-master/${encodeURIComponent(code.trim())}${opened}`);
      setMsg({ kind: 'ok', text: DELETED });
      await clear();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error) });
    } finally {
      setBusy(false);
    }
  }

  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  const toSearch = () => {
    setSearch((s) => (s === SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

  /** MS_PRODUCT_KeyDown with KeyPreview: Esc leaves the screen; Up and Down from a box move to the list. */
  function onScreenKeyDown(event: ScreenKeyEvent) {
    if (event.defaultPrevented) return;
    if (event.key === 'Escape') {
      event.preventDefault();
      router.back();
    } else if (
      (event.key === 'ArrowUp' || event.key === 'ArrowDown') &&
      !listRef.current?.contains(event.target as Node)
    ) {
      event.preventDefault();
      (listRows()[current] ?? listRows()[0])?.focus();
    }
  }
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);

  function onListKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    if (event.key === 'F1') {
      event.preventDefault();
      toSearch();
    } else if (event.key === 'Enter') {
      event.preventDefault();
      const row = shown[current];
      if (row) void open(row.code);
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

  return (
    <div ref={screenRef} onKeyDown={onScreenKeyDown}>
      <h1>Product</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      {/* The desktop's tab order is the boxes, the buttons, then the search box and the list (MS_PRODUCT form spec);
          the grid areas draw the list on the left as the form does. */}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '450px minmax(460px, 1fr)',
          gridTemplateAreas: '"list fields" "list buttons"',
          gap: '12px 24px',
          alignItems: 'start',
        }}
      >
        <div className="panel" style={{ gridArea: 'fields', minWidth: 460 }}>
          <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 8 }}>
            <label htmlFor="product-code" style={{ width: 124, display: 'inline-block' }}>
              Code
            </label>
            <input
              id="product-code"
              ref={codeRef}
              value={code}
              maxLength={2}
              readOnly={entryMode === 'E'}
              style={{ width: 65 }}
              onChange={(e) => setCode(typed(e.target.value))}
              onBlur={codeFree}
              onKeyDown={(event) => {
                if (event.key === 'F1') {
                  event.preventDefault();
                  toSearch();
                } else if (event.key === 'Enter') {
                  event.preventDefault();
                  if (code.trim()) nameRef.current?.focus();
                }
              }}
            />
          </div>
          <div className="row" style={{ alignItems: 'center', gap: 6 }}>
            <label htmlFor="product-name" style={{ width: 124, display: 'inline-block' }}>
              Name
            </label>
            <input
              id="product-name"
              ref={nameRef}
              value={name}
              maxLength={40}
              style={{ width: 312 }}
              onChange={(e) => setName(typed(e.target.value))}
              onBlur={nameFree}
              onKeyDown={(event) => {
                if (event.key !== 'Enter') return;
                event.preventDefault();
                if (!name.trim()) {
                  setMsg({ kind: 'err', text: NAME_REQUIRED });
                  nameRef.current?.focus();
                } else saveRef.current?.focus();
              }}
            />
          </div>
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
          {/* BtnPrint_Click is empty on the desktop (MS_PRODUCT.cs:1914-1917). */}
          <button type="button" className="ghost" disabled={busy} style={{ order: -1 }}>
            Print
          </button>
          <button
            type="button"
            className="ghost"
            disabled={busy}
            onClick={() => {
              setMsg(null);
              void clear();
            }}
          >
            Cancel
          </button>
          <button type="button" className="danger" disabled={busy} onClick={() => void remove()}>
            Delete
          </button>
          <button type="button" className="ghost" onClick={() => router.back()}>
            Exit
          </button>
        </div>
        <div className="panel" style={{ gridArea: 'list', width: 450 }}>
          <input
            ref={searchRef}
            aria-label="Search record"
            value={search}
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
                <th style={{ width: 80 }}>Code</th>
                <th>Name</th>
              </tr>
            </thead>
            <tbody ref={listRef} data-testid="product-list" onKeyDown={onListKeyDown}>
              {shown.map((row, i) => (
                <tr
                  key={row.code}
                  tabIndex={0}
                  aria-selected={i === current}
                  data-code={row.code}
                  className={i === current ? 'selected' : undefined}
                  onFocus={() => setCurrent(i)}
                  onDoubleClick={() => void open(row.code)}
                >
                  <td>{row.code}</td>
                  <td>{row.name}</td>
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
