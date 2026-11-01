'use client';
import { useCallback, useEffect, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { ITEM_OPENING_TYPES, itemOpeningRow, round } from '@datacare/core';
import { del, get, put, ApiError } from '../../../../lib/api';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Item Opening (desktop TR_ITM_OPBL). Choose the metal type and press Enter: the grid lists every item of the type
 * with its opening (DISPLAY_DATA, TR_ITM_OPBL.cs:1269-1370). A row works out like CommPassTotal (:942-993) when one of
 * its number cells is left. Save writes the type's opening in book '000' with its stock rows, says "Data Are Saved."
 * and clears the screen (:1380-1490); Delete removes the type's opening (:1492-1517).
 *
 * Keys as TEXT_ENTRY_KeyDown (:1583-1670): Enter moves one cell right; Enter on NetAmt goes to the next row's Pcs, or
 * on the last row adds a row and goes to its ItCode; Enter on an empty ItCode goes to Save; the arrows move one cell.
 * Esc leaves the screen when the total gross and net weights are as loaded, otherwise goes to Save (:1553-1574).
 * Typed text is upper-cased and the apostrophe is refused (:1538-1551).
 *
 * Deliberate differences, each a case where the desktop loses or misfiles data:
 * - A cell keeps its typed value when it is left with an arrow key or when Save is pressed from it; the desktop drops
 *   it (MSG_LeaveCell stores nothing while UpDown is set, :887-889), and Esc counts it before deciding to leave.
 * - Save and Delete refuse while the chosen type differs from the grid's type, and Save refuses the blank type. The
 *   desktop would replace the chosen type's whole opening with the grid's rows.
 * - A save or delete carries the version read with the grid (N51): when another operator saved the type meanwhile,
 *   the server refuses it and the grid must be read again. The desktop's later save wins.
 */
interface Column {
  header: string;
  /** Decimal places of a number cell (its grid format); absent for a text cell. */
  places?: number;
  maxLength: number;
}
/** The grid's columns in desktop order and editor lengths (MSG_CLEAR :694-783, MSG_EnterCell :805-886). */
const COLUMNS: Column[] = [
  { header: 'Sr.', maxLength: 5 },
  { header: 'ItCode', maxLength: 5 },
  { header: 'Item Name', maxLength: 100 },
  { header: 'Rtype', maxLength: 1 },
  { header: 'Pcs', places: 0, maxLength: 8 },
  { header: 'GrWt', places: 3, maxLength: 10 },
  { header: 'NetWt', places: 3, maxLength: 10 },
  { header: 'Touch', places: 2, maxLength: 10 },
  { header: 'West%', places: 2, maxLength: 10 },
  { header: 'Fine', places: 3, maxLength: 10 },
  { header: 'Rate', places: 2, maxLength: 10 },
  { header: 'ItmAmt', places: 2, maxLength: 10 },
  { header: 'LType', maxLength: 1 },
  { header: 'LRate', places: 2, maxLength: 10 },
  { header: 'LbrAmt', places: 2, maxLength: 10 },
  { header: 'OthAmt', places: 2, maxLength: 10 },
  { header: 'NetAmt', places: 2, maxLength: 10 },
];
const IT_CODE = 1;
const RATE_TYPE = 3;
const PCS = 4;
const GROSS = 5;
const NET = 6;
const TOUCH = 7;
const WEST = 8;
const FINE = 9;
const RATE = 10;
const AMOUNT = 11;
const LBR_TYPE = 12;
const LBR_RATE = 13;
const LBR_AMT = 14;
const OTH_AMT = 15;
const NET_AMT = 16;
/** The cells DISPLAY_DATA blanks when zero; West% and LRate of a saved row show 0.00 (:1302-1331). */
const BLANK_WHEN_ZERO = new Set([
  PCS,
  GROSS,
  NET,
  TOUCH,
  FINE,
  RATE,
  AMOUNT,
  LBR_AMT,
  OTH_AMT,
  NET_AMT,
]);
const isNumber = (column: number) => COLUMNS[column]?.places !== undefined;

const SAVED = 'Data Are Saved.';
const DELETED = 'Delete Success.';
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const SELECT_TYPE = 'Please Select Metaltype....';
const SELECT_FOR_DELETE = 'Please Select Item For Delete.';
const DELETE_CONFIRM = 'Are You Sure To Delete All Item Opening From This Record now?';
const typeName = (code: string) => ITEM_OPENING_TYPES.find((t) => t.code === code)?.name ?? code;

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface LoadedRow {
  srNo: number;
  itCode: string;
  itName: string;
  rateType: string;
  saved: boolean;
  pcs: number;
  grossWt: number;
  netWt: number;
  touch: number;
  westPct: number;
  fineWt: number;
  rate: number;
  amount: number;
  lbrType: string;
  lbrRate: number;
  lbrAmt: number;
  othAmt: number;
  netAmt: number;
}
interface Grid {
  type: string;
  rows: LoadedRow[];
  /** The version token of the type's rows (N51); a save or delete sends it back. */
  version: string;
}
/** A grid row: the text of each cell, by desktop column. */
type Row = string[];

/** VB Conversion.Val: the leading number of the text, else 0. */
function val(text: string | undefined): number {
  const match = /^\s*[-+]?(\d+\.?\d*|\.\d+)/.exec(text ?? '');
  return match ? Number(match[0]) : 0;
}
/** VB Strings.Format(value, "0.000"): half away from zero, fixed places, no grouping. */
const format = (value: number, places: number) => round(value, places).toFixed(places);

const blankRow = (srNo: number): Row => COLUMNS.map((_, c) => (c === 0 ? String(srNo) : ''));

function loadedRow(r: LoadedRow): Row {
  const numbers: Record<number, number> = {
    [PCS]: r.pcs,
    [GROSS]: r.grossWt,
    [NET]: r.netWt,
    [TOUCH]: r.touch,
    [WEST]: r.westPct,
    [FINE]: r.fineWt,
    [RATE]: r.rate,
    [AMOUNT]: r.amount,
    [LBR_RATE]: r.lbrRate,
    [LBR_AMT]: r.lbrAmt,
    [OTH_AMT]: r.othAmt,
    [NET_AMT]: r.netAmt,
  };
  return COLUMNS.map((column, c) => {
    if (c === 0) return String(r.srNo);
    if (c === IT_CODE) return r.itCode;
    if (c === 2) return r.itName;
    if (c === RATE_TYPE) return r.rateType;
    if (c === LBR_TYPE) return r.lbrType;
    // An item without an opening shows every number cell blank.
    if (!r.saved) return '';
    const value = numbers[c] ?? 0;
    return BLANK_WHEN_ZERO.has(c) && value === 0 ? '' : format(value, column.places ?? 0);
  });
}

/** MSG_LeaveCell then CommPassTotal (:887-993): hold the cell in its format and work the row out again. */
function leaveCell(row: Row, column: number): Row {
  const places = COLUMNS[column]?.places;
  if (places === undefined) return row;
  const next = [...row];
  next[column] = format(val(next[column]), places);
  const worked = itemOpeningRow({
    rateType: next[RATE_TYPE],
    pcs: val(next[PCS]),
    grossWt: val(next[GROSS]),
    netWt: val(next[NET]),
    touch: val(next[TOUCH]),
    westPct: val(next[WEST]),
    rate: val(next[RATE]),
    amount: val(next[AMOUNT]),
    lbrType: next[LBR_TYPE],
    lbrRate: val(next[LBR_RATE]),
    lbrAmt: val(next[LBR_AMT]),
    othAmt: val(next[OTH_AMT]),
  });
  if (val(next[NET]) === 0) next[NET] = format(worked.netWt, 3);
  next[FINE] = format(worked.fineWt, 3);
  // CommPassTotal sets the item amount only when it prices the row; otherwise the typed amount stays.
  if (worked.amount !== round(val(next[AMOUNT]), 2)) next[AMOUNT] = format(worked.amount, 2);
  if (val(next[LBR_RATE]) !== 0) next[LBR_AMT] = format(worked.lbrAmt, 2);
  next[NET_AMT] = format(worked.netAmt, 2);
  return next;
}

/** MSG_TOT_FILL (:995-1026): pieces, gross, net, fine, item amount and net amount. */
function totals(rows: Row[]): Record<number, string> {
  const sum = (column: number, places: number) =>
    format(
      rows.reduce((total, row) => total + val(row[column]), 0),
      places,
    );
  return {
    [PCS]: sum(PCS, 0),
    [GROSS]: sum(GROSS, 3),
    [NET]: sum(NET, 3),
    [FINE]: sum(FINE, 3),
    [AMOUNT]: sum(AMOUNT, 2),
    [NET_AMT]: sum(NET_AMT, 2),
  };
}
/** The desktop's change check (OldValTot / NewValTot, :1023 and :1366): total gross plus total net weight. */
const weightTotal = (rows: Row[]) => {
  const t = totals(rows);
  return round(val(t[GROSS]) + val(t[NET]), 3);
};

const messageOf = (e: unknown) =>
  e instanceof ApiError
    ? e.status === 403
      ? NO_RIGHTS
      : e.body?.message || e.body?.detail || e.body?.error || e.message
    : `Error Found: ${e instanceof Error ? e.message : String(e)}`;
/** Desktop typing (TR_ITM_OPBL_KeyPress): upper case, no apostrophe. */
const typed = (text: string) => text.toUpperCase().replace(/'/g, '');

export default function ItemOpeningPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [type, setType] = useState('');
  const [loadedType, setLoadedType] = useState('');
  const [version, setVersion] = useState('');
  const [rows, setRows] = useState<Row[]>([blankRow(1)]);
  const [rights, setRights] = useState<Rights | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const typeRef = useRef<HTMLSelectElement>(null);
  const saveRef = useRef<HTMLButtonElement>(null);
  const gridRef = useRef<HTMLTableSectionElement>(null);
  // The latest rows and the cell last focused, so Save works out that cell even when it is pressed from inside it.
  const rowsRef = useRef(rows);
  rowsRef.current = rows;
  const lastCell = useRef<{ row: number; column: number } | null>(null);
  const loadedWeight = useRef(0);
  const pendingFocus = useRef<{ row: number; column: number } | null>(null);
  // CLEAR_DATA ends on the metal type; the select is disabled while a save runs, so focus it once that ends.
  const focusType = useRef(false);

  useEffect(() => {
    get<Rights>('/stock/item-opening/rights')
      .then(setRights)
      .catch((e) => setMsg({ kind: 'err', text: messageOf(e) }));
    typeRef.current?.focus();
  }, []);

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
    if (focusType.current && !busy && typeRef.current) {
      focusType.current = false;
      typeRef.current.focus();
    }
  }, [rows, busy, focusCell]);

  /** CLEAR_DATA (:1247-1268): one empty row, the blank metal type, focus on the type. */
  const clear = useCallback(() => {
    setRows([blankRow(1)]);
    setType('');
    setLoadedType('');
    setVersion('');
    lastCell.current = null;
    loadedWeight.current = 0;
    focusType.current = true;
    typeRef.current?.focus();
  }, []);

  /** DISPLAY_DATA for the type shown in the select (its own value, so a restored or autofilled choice counts). */
  async function load(code: string) {
    setMsg(null);
    setType(code);
    // cboItemTyp_KeyDown (:1672-1684): the cursor starts on row 1, Rtype.
    pendingFocus.current = { row: 0, column: RATE_TYPE };
    lastCell.current = null;
    if (!code) {
      // The blank type lists no items: one empty row.
      setRows([blankRow(1)]);
      setLoadedType('');
      setVersion('');
      loadedWeight.current = 0;
      return;
    }
    setBusy(true);
    try {
      const grid = await get<Grid>(`/stock/item-opening/type/${encodeURIComponent(code)}`);
      const next = grid.rows.length ? grid.rows.map(loadedRow) : [blankRow(1)];
      loadedWeight.current = weightTotal(next);
      setRows(next);
      setLoadedType(code);
      setVersion(grid.version);
    } catch (e) {
      pendingFocus.current = null;
      setMsg({ kind: 'err', text: messageOf(e) });
    } finally {
      setBusy(false);
    }
  }

  const setCell = (row: number, column: number, text: string) =>
    setRows((current) =>
      current.map((r, i) => (i === row ? r.map((t, c) => (c === column ? text : t)) : r)),
    );
  const leave = (row: number, column: number) =>
    setRows((current) => current.map((r, i) => (i === row ? leaveCell(r, column) : r)));

  async function save() {
    setMsg(null);
    if (rights && !rights.canUpdate) return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!type) return setMsg({ kind: 'err', text: SELECT_TYPE });
    if (type !== loadedType)
      return setMsg({
        kind: 'err',
        text: `Press Enter on Item Type to show the ${typeName(type)} items before saving.`,
      });
    const cell = lastCell.current;
    const current = rowsRef.current.map((r, i) =>
      cell && i === cell.row ? leaveCell(r, cell.column) : r,
    );
    setRows(current);
    setBusy(true);
    try {
      await put(`/stock/item-opening/type/${encodeURIComponent(type)}`, {
        expectedVersion: version,
        rows: current.map((r) => ({
          itCode: r[IT_CODE]!.trim(),
          pcs: val(r[PCS]),
          grossWt: val(r[GROSS]),
          netWt: val(r[NET]),
          touch: val(r[TOUCH]),
          westPct: val(r[WEST]),
          fineWt: val(r[FINE]),
          rate: val(r[RATE]),
          amount: val(r[AMOUNT]),
          lbrType: r[LBR_TYPE]!.trim(),
          lbrRate: val(r[LBR_RATE]),
          lbrAmt: val(r[LBR_AMT]),
          othAmt: val(r[OTH_AMT]),
          netAmt: val(r[NET_AMT]),
        })),
      });
      clear();
      setMsg({ kind: 'ok', text: SAVED });
    } catch (e) {
      setMsg({ kind: 'err', text: messageOf(e) });
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    setMsg(null);
    if (rights && !rights.canDelete) return setMsg({ kind: 'err', text: NO_RIGHTS });
    if (!type) return setMsg({ kind: 'err', text: SELECT_FOR_DELETE });
    // The delete removes the opening of the type shown, so the grid of that type must be on screen (its version).
    if (type !== loadedType)
      return setMsg({
        kind: 'err',
        text: `Press Enter on Item Type to show the ${typeName(type)} items before deleting.`,
      });
    if (!window.confirm(DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      await del(
        `/stock/item-opening/type/${encodeURIComponent(type)}?expectedVersion=${encodeURIComponent(version)}`,
      );
      clear();
      setMsg({ kind: 'ok', text: DELETED });
    } catch (e) {
      setMsg({ kind: 'err', text: messageOf(e) });
    } finally {
      setBusy(false);
    }
  }

  // The desktop prints nothing from this screen: Print only checks the right (BtnPrint_Click, :1371-1379).
  const print = () => {
    setMsg(rights && !rights.canPrint ? { kind: 'err', text: NO_PRINT_RIGHTS } : null);
  };

  // Up and Down move a row through the shared grid contract; this grid has no row removal.
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    columnCount: COLUMNS.length,
    onAppendRow: () => {},
    onRemoveRow: () => false,
    onEscape: () => {},
  });

  function onGridKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    const target = event.target as HTMLInputElement;
    const cell = target.closest<HTMLElement>('[data-grid-row][data-grid-column]');
    if (!cell || event.key === 'Escape') return; // Esc belongs to the screen
    const row = Number(cell.dataset.gridRow);
    const column = Number(cell.dataset.gridColumn);
    const plain = !event.altKey && !event.ctrlKey && !event.metaKey && !event.shiftKey;
    if (plain && event.key === 'Enter') {
      event.preventDefault();
      if (column === IT_CODE && !target.value.trim()) return void saveRef.current?.focus();
      if (column !== NET_AMT) return void focusCell(row, column + 1);
      if (row < rows.length - 1) return void focusCell(row + 1, PCS);
      pendingFocus.current = { row: row + 1, column: IT_CODE };
      setRows((current) => [...current, blankRow(current.length + 1)]);
      return;
    }
    // The desktop editor moves on the first press whatever the caret position (ItCode is the leftmost cell).
    if (plain && (event.key === 'ArrowLeft' || event.key === 'ArrowRight')) {
      event.preventDefault();
      const to = event.key === 'ArrowLeft' ? column - 1 : column + 1;
      if (to >= IT_CODE && to <= NET_AMT) focusCell(row, to);
      return;
    }
    handleGridKey(event);
  }

  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.key !== 'Escape' || event.defaultPrevented) return;
    // Esc that closes the metal-type list (a native dropdown) must not also close the screen.
    if ((event.target as HTMLElement).closest?.('select')) return;
    event.preventDefault();
    if (weightTotal(rowsRef.current) === loadedWeight.current) return router.back();
    saveRef.current?.focus();
  }

  const total = totals(rows);
  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Item Opening</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div className="panel">
        <div className="row" style={{ alignItems: 'flex-end' }}>
          <div className="field">
            <label htmlFor="item-opening-type">Item Type</label>
            <select
              id="item-opening-type"
              ref={typeRef}
              value={type}
              disabled={busy}
              onChange={(e) => setType(e.target.value)}
              onKeyDown={(e) => {
                if (e.key !== 'Enter') return;
                e.preventDefault();
                void load(e.currentTarget.value);
              }}
            >
              <option value=""> </option>
              {ITEM_OPENING_TYPES.map((t) => (
                <option key={t.code} value={t.code}>
                  {t.name}
                </option>
              ))}
            </select>
          </div>
          {loadedType && (
            <span className="muted" data-testid="item-opening-loaded">
              {typeName(loadedType)}: {rows.length} rows
            </span>
          )}
        </div>
      </div>
      <div className="panel" style={{ overflowX: 'auto' }}>
        <table aria-label="Item opening grid">
          <thead>
            <tr>
              {COLUMNS.map((column) => (
                <th
                  key={column.header}
                  scope="col"
                  className={column.places === undefined ? undefined : 'num'}
                >
                  {column.header}
                </th>
              ))}
            </tr>
          </thead>
          <tbody ref={gridRef} data-testid="item-opening-grid" onKeyDown={onGridKeyDown}>
            {rows.map((row, i) => (
              <tr key={i}>
                {COLUMNS.map((column, c) => (
                  <td
                    key={column.header}
                    data-grid-row={i}
                    data-grid-column={c}
                    className={isNumber(c) ? 'num' : undefined}
                  >
                    {c === 0 ? (
                      row[0]
                    ) : (
                      <input
                        aria-label={`${column.header} row ${i + 1}`}
                        value={row[c]}
                        maxLength={column.maxLength}
                        inputMode={isNumber(c) ? 'decimal' : undefined}
                        onFocus={() => {
                          lastCell.current = { row: i, column: c };
                        }}
                        onChange={(e) => setCell(i, c, typed(e.target.value))}
                        onBlur={() => leave(i, c)}
                        style={{
                          width: c === 2 ? 160 : isNumber(c) ? 72 : c === IT_CODE ? 64 : 36,
                          textAlign: isNumber(c) ? 'right' : undefined,
                        }}
                      />
                    )}
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
          <tfoot>
            <tr data-testid="item-opening-totals">
              {COLUMNS.map((column, c) => (
                <td key={column.header} className={isNumber(c) ? 'num' : undefined}>
                  {c === 2 ? 'Total :' : (total[c] ?? '')}
                </td>
              ))}
            </tr>
          </tfoot>
        </table>
      </div>
      <div className="row" style={{ gap: 8 }}>
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
        <button type="button" className="ghost" disabled={busy} onClick={clear}>
          Cancel
        </button>
        <button type="button" className="danger" disabled={busy} onClick={() => void remove()}>
          Delete
        </button>
        <button type="button" className="ghost" disabled={busy} onClick={print}>
          Print
        </button>
        <button type="button" className="ghost" onClick={() => router.back()}>
          Exit
        </button>
      </div>
      <FormKeyHints actions={formKeys} />
    </div>
  );
}
