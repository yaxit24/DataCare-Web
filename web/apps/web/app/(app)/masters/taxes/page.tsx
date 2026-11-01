'use client';
import { useCallback, useEffect, useMemo, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { round, vbVal } from '@datacare/core';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Tax master (desktop MS_TAX, Master → Tax), laid out as its form spec
 * (`web/apps/api/form-specs/DataCareNext.MS_TAX.layout.json`): the SEARCH RECORD box and the Code / Name list on the
 * left; Tax Type (the code), Tax Desc, Tax % with Add Tax %, and Ac Code with the account name on the right, over the
 * component grid Sr / Tax Type / Tax Name / Ac Code / Tax %; Print, Save, Cancel, Delete and Exit along the bottom.
 *
 * - A new entry has blank boxes, one empty grid row and the cursor in the code (CLEAR_DATA, MS_TAX.cs:1590-1614). Enter on
 *   the list opens a code with the cursor in the name and a double click with it in the code (DGV keys :1973-2002); the
 *   code box is read-only for an opened code (DISPLAY_DATA :1616-1668).
 * - Keys: typed letters are upper-cased and the apostrophe refused (:1689-1702). Enter on the code moves on and F1 goes
 *   to the search box (:1704-1718); Enter on a blank name says "Please Insert Tax Name ..." (:1742-1759); Enter on Tax %
 *   and Add Tax % shows Val of the box as 0.00 (:2004-2024); Enter on Ac Code takes a code found in the account master
 *   and goes to row 1 of the grid, else opens the help of group 12 and account 00013 (:2026-2063). In the grid Enter moves
 *   one cell right; on Ac Code it takes a found code or opens the help of every account; on Tax % it shows 0.000 and goes
 *   to the next row, and on the last row adds a row, or with a blank Tax % goes to Save; the arrows move one cell
 *   (TEXT_ENTRY_KeyDown :1200-1310). Esc leaves the screen (:1806-1814). In the list F1 goes to the search box and
 *   Backspace shortens it.
 * - Leaving the code refuses a code another tax has, and leaving the name a name another code has (:1720-1781).
 * - Save, Delete and Print answer with the desktop texts and rights (:1824-1971).
 *
 * Deliberate differences: an opened code's components are shown at their SR_NO rows (a blank row fills a gap), so a
 * save keeps each component's SR_NO; the desktop packs the rows and renumbers them on save, which moves IGST onto
 * CGST's SR_NO when a middle row was left at zero. An opened code carries the version read with it. The search box drops
 * SEARCH RECORD whenever it gets the cursor. A pick from an account help moves on at once, where the desktop waits for a
 * second Enter. Print shows the codes on the screen, because the TaxMast report layout is not in the repository.
 */
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const SAVED = 'Data Are Saved.';
const DELETED = 'Delete Success.';
const DELETE_CONFIRM = 'Are You Sure To Delete This Record now?';
const SELECT_FOR_DELETE = 'Please Select Tax Code For Delete.';
const NAME_REQUIRED = 'Please Insert Tax Name ...';
const CODE_REQUIRED = 'Enter Tax Code.';
const DESC_REQUIRED = 'Enter Tax Name.';
const SEARCH_TEXT = 'SEARCH RECORD';
const codeTaken = (name: string) =>
  `This Tax Code already Exist in  '${name}'  Tax Name...Please Change Tax Code...`;
const nameTaken = (code: string) =>
  `This Tax Name already Exist in  '${code}'  Tax Code...Please Change Tax Name...`;

/** The grid's columns after Sr (MSG_CLEAR :1094-1129), with the editor's MaxLength (MSG_EnterCell :1131-1176). */
const COLUMNS = [
  { key: 'taxType', header: 'Tax Type', maxLength: 5, width: 72 },
  { key: 'name', header: 'Tax Name', maxLength: 50, width: 190 },
  { key: 'account', header: 'Ac Code', maxLength: 8, width: 96 },
  { key: 'pct', header: 'Tax %', maxLength: 6, width: 72 },
] as const;
type ColumnKey = (typeof COLUMNS)[number]['key'];
const PCT = 3;
const ACCOUNT = 2;

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface ListRow {
  code: string;
  name: string;
}
type GridRow = Record<ColumnKey, string>;
interface Header {
  code: string;
  name: string;
  pct: string;
  addPct: string;
  account: string;
  accountName: string;
}
interface PrintRow {
  code: string;
  srNo: number;
  taxType: string;
  name: string;
  pct: number;
  addPct: number;
  account: string;
}

const blankRow = (): GridRow => ({ taxType: '', name: '', account: '', pct: '' });
const blankHeader: Header = {
  code: '',
  name: '',
  pct: '',
  addPct: '',
  account: '',
  accountName: '',
};
/** MS_TAX_KeyPress: every typed key upper-cased, the apostrophe refused. */
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
/** Strings.Format(Val(box), "0.00") and "0.000". */
const fixed = (value: string | number, places: number) =>
  round(vbVal(value), places).toFixed(places);
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function TaxMasterPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [list, setList] = useState<ListRow[]>([]);
  const [rights, setRights] = useState<Rights | null>(null);
  const [header, setHeader] = useState<Header>(blankHeader);
  const [rows, setRows] = useState<GridRow[]>([blankRow()]);
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [version, setVersion] = useState('');
  const [search, setSearch] = useState(SEARCH_TEXT);
  const [current, setCurrent] = useState(0);
  const [printRows, setPrintRows] = useState<PrintRow[] | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const codeRef = useRef<HTMLInputElement>(null);
  const nameRef = useRef<HTMLInputElement>(null);
  const pctRef = useRef<HTMLInputElement>(null);
  const addPctRef = useRef<HTMLInputElement>(null);
  const accountBox = useRef<HTMLDivElement>(null);
  const saveRef = useRef<HTMLButtonElement>(null);
  const searchRef = useRef<HTMLInputElement>(null);
  const listRef = useRef<HTMLTableSectionElement>(null);
  const gridRef = useRef<HTMLTableSectionElement>(null);
  const pendingFocus = useRef<{ row: number; column: number } | null>(null);
  const focusAfterLoad = useRef<'code' | 'name' | null>(null);

  const focusCell = useCallback((row: number, column: number) => {
    const input = gridRef.current?.querySelector<HTMLInputElement>(
      `[data-grid-row="${row}"][data-grid-column="${column}"] input`,
    );
    if (!input) return false;
    input.focus();
    input.select();
    return true;
  }, []);
  useEffect(() => {
    const target = pendingFocus.current;
    if (target && focusCell(target.row, target.column)) pendingFocus.current = null;
  }, [rows, focusCell]);
  useEffect(() => {
    if (busy || !focusAfterLoad.current) return;
    const which = focusAfterLoad.current;
    focusAfterLoad.current = null;
    (which === 'name' ? nameRef : codeRef).current?.focus();
  }, [busy, entryMode, header.code]);

  /** CLEAR_DATA: blank boxes, one empty grid row, the list read again, the cursor in the code. */
  const clear = useCallback(async () => {
    setBusy(true);
    try {
      const view = await get<{ rows: ListRow[]; rights: Rights }>('/masters/tax-master');
      setList(view.rows);
      setRights(view.rights);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setHeader(blankHeader);
      setRows([blankRow()]);
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

  /** Text1_TextChanged: TAX_NAME LIKE 'text%'; the SEARCH RECORD text lists every code. */
  const shown = useMemo(() => {
    const wanted = search === SEARCH_TEXT ? '' : search.toUpperCase();
    return wanted ? list.filter((row) => row.name.toUpperCase().startsWith(wanted)) : list;
  }, [list, search]);

  async function open(code: string, focus: 'code' | 'name') {
    if (!code) return;
    setBusy(true);
    setMsg(null);
    try {
      const found = await get<{
        code: string;
        name: string;
        pct: number;
        addPct: number;
        account: string;
        accountName: string;
        components: Array<{
          srNo: number;
          taxType: string;
          name: string;
          account: string;
          pct: number;
        }>;
        version: string;
      }>(`/masters/tax-master/${encodeURIComponent(code)}`);
      setHeader({
        code: found.code,
        name: found.name,
        pct: fixed(found.pct, 2),
        addPct: fixed(found.addPct, 2),
        account: found.account,
        accountName: found.accountName,
      });
      // Each component at its SR_NO row, then one empty row (DISPLAY_DATA :1640-1662).
      const last = found.components.reduce((max, c) => Math.max(max, Math.round(c.srNo)), 0);
      const grid: GridRow[] = Array.from({ length: last + 1 }, blankRow);
      for (const c of found.components)
        grid[Math.round(c.srNo) - 1] = {
          taxType: c.taxType,
          name: c.name,
          account: c.account,
          pct: fixed(c.pct, 3),
        };
      setRows(grid);
      setEntryMode('E');
      setVersion(found.version);
      focusAfterLoad.current = focus;
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    } finally {
      setBusy(false);
    }
  }

  const set = (key: keyof Header, value: string) => setHeader((h) => ({ ...h, [key]: value }));
  const setCell = (row: number, key: ColumnKey, value: string) =>
    setRows((current) => current.map((r, i) => (i === row ? { ...r, [key]: value } : r)));

  /** tTaxCode_Validating: a new entry may not take a code another tax has. */
  function codeFree() {
    if (entryMode !== 'A') return true;
    const other = list.find((row) => row.code === header.code.trim());
    if (other && other.name !== header.name.trim()) {
      setMsg({ kind: 'err', text: codeTaken(other.name) });
      setTimeout(() => {
        codeRef.current?.focus();
        codeRef.current?.select();
      }, 0);
      return false;
    }
    return true;
  }
  /** tTaxName_Validating: the name may not be another code's. */
  function nameFree() {
    const name = header.name.trim();
    const other = name && list.find((row) => row.name === name && row.code !== header.code.trim());
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

  const refusal = (error: unknown, forbidden: string) =>
    error instanceof ApiError && error.status === 403 ? forbidden : messageOf(error);

  async function save() {
    setMsg(null);
    if (entryMode === 'E' && rights && !rights.canUpdate)
      return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!header.code.trim()) {
      setMsg({ kind: 'err', text: CODE_REQUIRED });
      return codeRef.current?.focus();
    }
    if (!header.name.trim()) {
      setMsg({ kind: 'err', text: DESC_REQUIRED });
      return nameRef.current?.focus();
    }
    if (!codeFree() || !nameFree()) return;
    setBusy(true);
    try {
      const payload = {
        code: header.code.trim(),
        name: header.name.trim(),
        pct: header.pct,
        addPct: header.addPct,
        account: header.account.trim(),
        components: rows.map((r) => ({
          taxType: r.taxType.trim(),
          name: r.name.trim(),
          account: r.account.trim(),
          pct: r.pct,
        })),
      };
      if (entryMode === 'E')
        await put(`/masters/tax-master/${encodeURIComponent(payload.code)}`, {
          ...payload,
          expectedVersion: version,
        });
      else await post('/masters/tax-master', payload);
      setMsg({ kind: 'ok', text: SAVED });
      await clear();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    setMsg(null);
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!header.code.trim()) return setMsg({ kind: 'err', text: SELECT_FOR_DELETE });
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      const opened =
        entryMode === 'E' && version ? `?expectedVersion=${encodeURIComponent(version)}` : '';
      await del(`/masters/tax-master/${encodeURIComponent(header.code.trim())}${opened}`);
      setMsg({ kind: 'ok', text: DELETED });
      await clear();
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_RIGHTS) });
    } finally {
      setBusy(false);
    }
  }

  async function print() {
    setMsg(null);
    if (rights && !rights.canPrint) return setMsg({ kind: 'err', text: NO_PRINT_RIGHTS });
    try {
      const out = await get<{ rows: PrintRow[] }>('/masters/tax-master/print');
      setPrintRows(out.rows);
    } catch (error) {
      setMsg({ kind: 'err', text: refusal(error, NO_PRINT_RIGHTS) });
    }
  }

  const listRows = () =>
    Array.from(listRef.current?.querySelectorAll<HTMLTableRowElement>('tr') ?? []);
  const toSearch = () => {
    setSearch((s) => (s === SEARCH_TEXT ? '' : s));
    searchRef.current?.focus();
  };

  /** MS_TAX_KeyDown with KeyPreview: Esc leaves the screen. */
  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.defaultPrevented || event.key !== 'Escape') return;
    if ((event.target as HTMLElement).closest?.('[data-lookup-open="true"]')) return;
    event.preventDefault();
    router.back();
  }

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

  /** TEXT_ENTRY_KeyDown (:1200-1310): Enter moves right, on Tax % to the next row; the arrows move one cell. */
  function onGridKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    const target = event.target as HTMLInputElement;
    const cell = target.closest<HTMLElement>('[data-grid-row][data-grid-column]');
    if (!cell || event.key === 'Escape' || event.defaultPrevented) return;
    // An open account help keeps Enter, Up and Down for its list; Left and Right still move to the next cell.
    if (
      target.closest('[data-lookup-open="true"]') &&
      !['ArrowLeft', 'ArrowRight'].includes(event.key)
    )
      return;
    const row = Number(cell.dataset.gridRow);
    const column = Number(cell.dataset.gridColumn);
    const plain = !event.altKey && !event.ctrlKey && !event.metaKey && !event.shiftKey;
    if (!plain) return;
    if (event.key === 'Enter') {
      if (column === ACCOUNT) return; // the account picker resolves the typed code (onPick moves on)
      event.preventDefault();
      if (column !== PCT) return void focusCell(row, column + 1);
      const value = rows[row]?.pct ?? '';
      if (row === rows.length - 1) {
        if (!value.trim()) return void saveRef.current?.focus();
        setCell(row, 'pct', fixed(value, 3));
        pendingFocus.current = { row: row + 1, column: 0 };
        setRows((r) => [...r, blankRow()]);
        return;
      }
      setCell(row, 'pct', fixed(value, 3));
      return void focusCell(row + 1, 0);
    }
    const moves: Record<string, [number, number]> = {
      ArrowLeft: [0, -1],
      ArrowRight: [0, 1],
      ArrowUp: [-1, 0],
      ArrowDown: [1, 0],
    };
    const move = moves[event.key];
    if (!move) return;
    event.preventDefault();
    const toRow = row + move[0];
    const toColumn = column + move[1];
    if (toRow >= 0 && toRow < rows.length && toColumn >= 0 && toColumn < COLUMNS.length)
      focusCell(toRow, toColumn);
  }

  const onEnter = (next: () => void) => (event: KeyboardEvent<HTMLInputElement>) => {
    if (event.key !== 'Enter') return;
    event.preventDefault();
    next();
  };

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Tax Master</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      {/* The desktop's tab order is the boxes, the buttons, then the search box and the list (MS_TAX form spec); the
          grid areas draw the list on the left as the form does. */}
      <div
        style={{
          display: 'grid',
          gridTemplateColumns: '450px minmax(540px, 1fr)',
          gridTemplateAreas: '"list fields" "list buttons"',
          gap: '12px 24px',
          alignItems: 'start',
        }}
      >
        <div className="panel" style={{ gridArea: 'fields', minWidth: 540 }}>
          <div className="field">
            <label htmlFor="tax-code">Tax Type</label>
            <input
              id="tax-code"
              ref={codeRef}
              value={header.code}
              maxLength={2}
              readOnly={entryMode === 'E'}
              style={{ width: 73 }}
              onChange={(e) => set('code', typed(e.target.value))}
              onBlur={codeFree}
              onKeyDown={(event) => {
                if (event.key === 'F1') {
                  event.preventDefault();
                  toSearch();
                } else if (event.key === 'Enter') {
                  event.preventDefault();
                  if (header.code.trim()) nameRef.current?.focus();
                }
              }}
            />
          </div>
          <div className="field">
            <label htmlFor="tax-name">Tax Desc</label>
            <input
              id="tax-name"
              ref={nameRef}
              value={header.name}
              maxLength={40}
              style={{ width: 336 }}
              onChange={(e) => set('name', typed(e.target.value))}
              onBlur={nameFree}
              onKeyDown={onEnter(() => {
                if (!header.name.trim()) {
                  setMsg({ kind: 'err', text: NAME_REQUIRED });
                  nameRef.current?.focus();
                } else pctRef.current?.focus();
              })}
            />
          </div>
          <div className="row" style={{ gap: 12, alignItems: 'flex-end' }}>
            <div className="field">
              <label htmlFor="tax-pct">Tax %</label>
              <input
                id="tax-pct"
                ref={pctRef}
                value={header.pct}
                maxLength={6}
                inputMode="decimal"
                style={{ width: 73, textAlign: 'right' }}
                onChange={(e) => set('pct', e.target.value)}
                onKeyDown={onEnter(() => {
                  set('pct', fixed(header.pct, 2));
                  addPctRef.current?.focus();
                })}
              />
            </div>
            <div className="field">
              <label htmlFor="tax-add-pct">Add Tax %</label>
              <input
                id="tax-add-pct"
                ref={addPctRef}
                value={header.addPct}
                maxLength={6}
                inputMode="decimal"
                style={{ width: 73, textAlign: 'right' }}
                onChange={(e) => set('addPct', e.target.value)}
                onKeyDown={onEnter(() => {
                  set('addPct', fixed(header.addPct, 2));
                  accountBox.current?.querySelector('input')?.focus();
                })}
              />
            </div>
          </div>
          <div className="field">
            <label>Ac Code</label>
            <div ref={accountBox} className="row" style={{ gap: 6, alignItems: 'center' }}>
              <LookupPicker
                entity="accounts"
                searchPath="/masters/tax-master/accounts?kind=header"
                ariaLabel="Ac Code"
                value={header.account}
                placeholder=""
                resolveTypedCode
                onChange={(code) =>
                  setHeader((h) => ({
                    ...h,
                    account: code,
                    accountName: code === h.account ? h.accountName : '',
                  }))
                }
                // tTaxAcCode_KeyDown: a found code goes to row 1, Tax Type (:2056-2061), the next box after Ac Code.
                onPick={(row) =>
                  setHeader((h) => ({
                    ...h,
                    account: String(row.code),
                    accountName: String(row.name ?? ''),
                  }))
                }
                style={{ width: 96 }}
              />
              <input
                aria-label="Account Name"
                value={header.accountName}
                readOnly
                tabIndex={-1}
                style={{ width: 261 }}
              />
            </div>
          </div>
          <table className="grid" style={{ marginTop: 10 }}>
            <thead>
              <tr>
                <th style={{ width: 36 }}>Sr</th>
                {COLUMNS.map((c) => (
                  <th key={c.key} className={c.key === 'pct' ? 'num' : undefined}>
                    {c.header}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody ref={gridRef} data-testid="tax-components" onKeyDown={onGridKeyDown}>
              {rows.map((row, i) => (
                <tr key={i}>
                  <td className="num">{i + 1}</td>
                  {COLUMNS.map((column, c) => (
                    <td
                      key={column.key}
                      data-grid-row={i}
                      data-grid-column={c}
                      className={column.key === 'pct' ? 'num' : undefined}
                    >
                      {column.key === 'account' ? (
                        <LookupPicker
                          entity="accounts"
                          searchPath="/masters/tax-master/accounts?kind=component"
                          ariaLabel={`Ac Code row ${i + 1}`}
                          value={row.account}
                          placeholder=""
                          resolveTypedCode
                          onChange={(code) => setCell(i, 'account', code)}
                          // A found code moves on to Tax % (TEXT_ENTRY_KeyDown :1248-1268, then MSG.Col += 1).
                          onPick={(picked) => setCell(i, 'account', String(picked.code))}
                          style={{ width: column.width }}
                        />
                      ) : (
                        <input
                          aria-label={`${column.header} row ${i + 1}`}
                          value={row[column.key]}
                          maxLength={column.maxLength}
                          inputMode={column.key === 'pct' ? 'decimal' : undefined}
                          onChange={(e) =>
                            setCell(
                              i,
                              column.key,
                              column.key === 'pct' ? e.target.value : typed(e.target.value),
                            )
                          }
                          onBlur={() => {
                            if (column.key === 'pct' && row.pct.trim())
                              setCell(i, 'pct', fixed(row.pct, 3));
                          }}
                          style={{
                            width: column.width,
                            textAlign: column.key === 'pct' ? 'right' : undefined,
                          }}
                        />
                      )}
                    </td>
                  ))}
                </tr>
              ))}
            </tbody>
          </table>
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
          <button
            type="button"
            className="ghost"
            disabled={busy}
            style={{ order: -1 }}
            onClick={() => void print()}
          >
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
            <tbody ref={listRef} data-testid="tax-list" onKeyDown={onListKeyDown}>
              {shown.map((row, i) => (
                <tr
                  key={row.code}
                  tabIndex={0}
                  aria-selected={i === current}
                  data-code={row.code}
                  className={i === current ? 'selected' : undefined}
                  onFocus={() => setCurrent(i)}
                  onDoubleClick={() => void open(row.code, 'code')}
                >
                  <td>{row.code}</td>
                  <td>{row.name}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      </div>
      {printRows && (
        <section className="panel" data-testid="tax-print" aria-label="Tax Master print">
          <div className="row" style={{ justifyContent: 'space-between' }}>
            <h2 style={{ margin: 0 }}>Tax Master</h2>
            <div className="row" style={{ gap: 8 }}>
              <button type="button" className="ghost" onClick={() => window.print()}>
                Print now
              </button>
              <button type="button" className="ghost" onClick={() => setPrintRows(null)}>
                Close
              </button>
            </div>
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>Code</th>
                <th>Sr</th>
                <th>Tax Type</th>
                <th>Tax Name</th>
                <th className="num">Tax %</th>
                <th className="num">Add Tax %</th>
                <th>Ac Code</th>
              </tr>
            </thead>
            <tbody>
              {printRows.map((row) => (
                <tr key={`${row.code}-${row.srNo}`}>
                  <td>{row.code}</td>
                  <td>{row.srNo}</td>
                  <td>{row.taxType}</td>
                  <td>{row.name}</td>
                  <td className="num">{fixed(row.pct, row.srNo === 0 ? 2 : 3)}</td>
                  <td className="num">{fixed(row.addPct, 2)}</td>
                  <td>{row.account}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </section>
      )}
      <FormKeyHints actions={formKeys} />
    </div>
  );
}
