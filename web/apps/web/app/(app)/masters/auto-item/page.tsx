'use client';
import { useCallback, useEffect, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { round, vbVal } from '@datacare/core';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';

/**
 * Auto Item (desktop MS_AUTO_ITEM with CurMast 'AutoItem', Master → AutoItem): Group Code with the group name, type,
 * trade type and HSN code across the top, the Sr. / Pr Code / Pr Name / MinStk / Y/N grid below (MSG_CLEAR,
 * MS_AUTO_ITEM.cs:1640-1683), and Print, Save, Cancel, Delete and Exit along the bottom.
 *
 * - The cursor starts in the group code; the group comes from its help (tGrCode_KeyDown :3432-3493), which fills the
 *   name, type, trade type and HSN code and lists the products (DISPLAY_DATA :2614-2650): Y in red for a product the
 *   group already has, N otherwise. The cursor then goes to the first row's Y/N.
 * - Grid keys (TEXT_ENTRY_KeyDown :3040-3239, MSG_EnterCell / LeaveCell :1712-1956): typed letters are upper-cased
 *   (:2965-2978); Enter on Y/N needs Y or N ("Please Enter Y or N and Try Again...") and goes to the next row's Y/N, and
 *   on the last row adds a row with the cursor in its Pr Code; Enter on a blank Pr Code goes to Save; Enter elsewhere moves
 *   one cell right; MinStk shows Val as a whole number on leaving it; the arrows move one cell; F1 copies the cell above.
 *   Esc in the grid goes to Save, elsewhere it leaves the screen (MS_AUTO_ITEM_KeyDown :2980-3007).
 * - Save makes the Y rows' items and answers "Data Are Saved." (:2876-2923); it needs the edit right once a group is
 *   shown. Print and Delete only check their rights in this mode (:2652-2659, :2927-2944).
 *
 * Deliberate differences: a typed group code fills the HSN code too (the desktop fills it from the help only); the HSN
 * box holds ten characters (its designer MaxLength is 1); a pick moves on at once.
 */
const NO_RIGHTS = 'You Have No Rights.....';
const NO_PRINT_RIGHTS = 'You Have No Print Rights.....';
const SAVED = 'Data Are Saved.';
const YN_REQUIRED = 'Please Enter Y or N and Try Again...';

interface Rights {
  canUpdate: boolean;
  canDelete: boolean;
  canPrint: boolean;
}
interface Row {
  prCode: string;
  prName: string;
  minStk: string;
  yn: string;
  /** An item of the group already has this product (shown in red). */
  made: boolean;
  /** Added at the bottom of the grid by the operator (CommPassAdd). */
  added: boolean;
}
const COLUMNS = [
  { key: 'prCode', header: 'Pr Code', max: 2, width: 70 },
  { key: 'prName', header: 'Pr Name', max: 50, width: 240 },
  { key: 'minStk', header: 'MinStk', max: 6, width: 70 },
  { key: 'yn', header: 'Y/N', max: 10, width: 70 },
] as const;
type ColumnKey = (typeof COLUMNS)[number]['key'];
const YN = 3;
const MIN_STK = 2;

const blankRow = (): Row => ({
  prCode: '',
  prName: '',
  minStk: '',
  yn: '',
  made: false,
  added: true,
});
const typed = (value: string) => value.toUpperCase().replace(/'/g, '');
const messageOf = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.detail || error.body?.error || error.message)
    : String((error as Error)?.message ?? error);

export default function AutoItemPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [rights, setRights] = useState<Rights | null>(null);
  const [group, setGroup] = useState({ code: '', name: '', type: '', trade: '', hsn: '' });
  const [shown, setShown] = useState(false);
  const [rows, setRows] = useState<Row[]>([blankRow()]);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const groupBox = useRef<HTMLDivElement>(null);
  const gridRef = useRef<HTMLTableSectionElement>(null);
  const saveRef = useRef<HTMLButtonElement>(null);
  const pendingFocus = useRef<{ row: number; column: number } | null>(null);

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

  /** CLEAR_DATA: blank boxes, one empty grid row, the cursor in the group code; then the user's rights. */
  const clear = useCallback(async () => {
    // Reset first: a group typed while the rights request is out must not be wiped when it answers.
    setGroup({ code: '', name: '', type: '', trade: '', hsn: '' });
    setRows([blankRow()]);
    setShown(false);
    setTimeout(() => groupBox.current?.querySelector('input')?.focus(), 0);
    setBusy(true);
    try {
      const view = await get<{ rights: Rights }>('/masters/auto-item?grCode=');
      setRights(view.rights);
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void clear();
  }, [clear]);

  /** A chosen group: its boxes and DISPLAY_DATA, then the cursor in row 1's Y/N. */
  async function groupChosen(picked: {
    code: string;
    name: string;
    type?: unknown;
    trade?: unknown;
    hsn?: unknown;
  }) {
    setMsg(null);
    setGroup({
      code: picked.code,
      name: picked.name,
      type: String(picked.type ?? ''),
      trade: String(picked.trade ?? ''),
      hsn: String(picked.hsn ?? ''),
    });
    try {
      const view = await get<{
        rows: Array<{ prCode: string; prName: string; yn: string; made: boolean }>;
        rights: Rights;
      }>(`/masters/auto-item?grCode=${encodeURIComponent(picked.code)}`);
      setRights(view.rights);
      const listed = view.rows.map((r) => ({ ...r, minStk: '', added: false }));
      setRows(listed.length ? listed : [blankRow()]);
      setShown(true);
      pendingFocus.current = { row: 0, column: YN };
    } catch (error) {
      setMsg({ kind: 'err', text: messageOf(error) });
    }
  }

  const setCell = (row: number, key: ColumnKey, value: string) =>
    setRows((current) => current.map((r, i) => (i === row ? { ...r, [key]: value } : r)));

  async function save() {
    setMsg(null);
    // DISPLAY_DATA leaves the screen in edit mode, so a shown group needs the edit right (:2648, :2668-2672).
    if (shown && rights && !rights.canUpdate) return setMsg({ kind: 'err', text: NO_RIGHTS });
    // Without a group or a Y row the save loop writes nothing and still answers "Data Are Saved." (:2876-2923).
    if (!group.code.trim() || !rows.some((r) => r.yn.trim() === 'Y' && r.prCode.trim())) {
      setMsg({ kind: 'ok', text: SAVED });
      await clear();
      return;
    }
    setBusy(true);
    try {
      await post('/masters/auto-item', {
        grCode: group.code,
        grType: group.type,
        tradeType: group.trade,
        hsnCode: group.hsn,
        rows: rows.map(({ made, ...r }) => {
          void made;
          return { ...r, minStk: r.minStk };
        }),
      });
      setMsg({ kind: 'ok', text: SAVED });
      await clear();
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof ApiError && error.status === 403 ? NO_RIGHTS : messageOf(error),
      });
    } finally {
      setBusy(false);
    }
  }

  /** MSG_LeaveCell: MinStk keeps Strings.Format(Val, "0"). */
  const leaveMinStk = (row: number) => {
    const value = rows[row]?.minStk ?? '';
    if (value.trim()) setCell(row, 'minStk', round(vbVal(value), 0).toFixed(0));
  };

  function onGridKeyDown(event: KeyboardEvent<HTMLTableSectionElement>) {
    const target = event.target as HTMLInputElement;
    const cell = target.closest<HTMLElement>('[data-grid-row][data-grid-column]');
    if (!cell || event.defaultPrevented) return;
    const row = Number(cell.dataset.gridRow);
    const column = Number(cell.dataset.gridColumn);
    if (event.altKey || event.ctrlKey || event.metaKey || event.shiftKey) return;
    if (event.key === 'Escape') {
      // MS_AUTO_ITEM_KeyDown: Esc in the grid leaves the cell and goes to Save.
      event.preventDefault();
      event.stopPropagation();
      if (column === MIN_STK) leaveMinStk(row);
      saveRef.current?.focus();
      return;
    }
    if (event.key === 'F1') {
      event.preventDefault();
      if (row > 0) setCell(row, COLUMNS[column]!.key, rows[row - 1]![COLUMNS[column]!.key]);
      return;
    }
    if (event.key === 'Enter') {
      event.preventDefault();
      if (column === MIN_STK) leaveMinStk(row);
      if (column === 0 && !(rows[row]?.prCode ?? '').trim()) return void saveRef.current?.focus();
      if (column === YN) {
        const value = (rows[row]?.yn ?? '').trim();
        if (value !== 'Y' && value !== 'N') return setMsg({ kind: 'err', text: YN_REQUIRED });
        setMsg(null);
        if (row === rows.length - 1) {
          pendingFocus.current = { row: row + 1, column: 0 };
          setRows((r) => [...r, blankRow()]);
          return;
        }
        return void focusCell(row + 1, YN);
      }
      return void focusCell(row, column + 1);
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
    if (column === MIN_STK) leaveMinStk(row);
    const toRow = row + move[0];
    const toColumn = column + move[1];
    if (toRow >= 0 && toRow < rows.length && toColumn >= 0 && toColumn < COLUMNS.length)
      focusCell(toRow, toColumn);
  }

  function onScreenKeyDown(event: KeyboardEvent<HTMLDivElement>) {
    if (event.defaultPrevented || event.key !== 'Escape') return;
    if ((event.target as HTMLElement).closest?.('[data-lookup-open="true"]')) return;
    event.preventDefault();
    router.back();
  }

  return (
    <div onKeyDown={onScreenKeyDown}>
      <h1>Auto Item</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div className="panel" style={{ maxWidth: 760 }}>
        <div className="row" style={{ alignItems: 'center', gap: 6, marginBottom: 10 }}>
          <label style={{ width: 96 }}>Group Code</label>
          <div ref={groupBox}>
            <LookupPicker
              entity="groups"
              searchPath="/masters/auto-item/groups"
              ariaLabel="Group Code"
              value={group.code}
              placeholder=""
              resolveTypedCode
              onChange={(code) => setGroup((g) => ({ ...g, code: typed(code) }))}
              onPick={(picked) =>
                void groupChosen({
                  code: String(picked.code),
                  name: String(picked.name ?? ''),
                  type: picked.type,
                  trade: picked.trade,
                  hsn: picked.hsn,
                })
              }
              style={{ width: 83 }}
            />
          </div>
          <input
            aria-label="Group Name"
            value={group.name}
            readOnly
            tabIndex={-1}
            style={{ width: 270 }}
          />
          <input
            aria-label="Group Type"
            value={group.type}
            maxLength={1}
            style={{ width: 26 }}
            onChange={(e) => setGroup((g) => ({ ...g, type: typed(e.target.value) }))}
          />
          <input
            aria-label="Trade Type"
            value={group.trade}
            maxLength={2}
            style={{ width: 40 }}
            onChange={(e) => setGroup((g) => ({ ...g, trade: typed(e.target.value) }))}
          />
          <input
            aria-label="Hsn Code"
            value={group.hsn}
            maxLength={10}
            style={{ width: 104 }}
            onChange={(e) => setGroup((g) => ({ ...g, hsn: typed(e.target.value) }))}
          />
        </div>
        <table className="grid" style={{ marginLeft: 104 }}>
          <thead>
            <tr>
              <th style={{ width: 36 }}>Sr.</th>
              {COLUMNS.map((c) => (
                <th key={c.key} className={c.key === 'minStk' ? 'num' : undefined}>
                  {c.header}
                </th>
              ))}
            </tr>
          </thead>
          <tbody ref={gridRef} data-testid="auto-item-grid" onKeyDown={onGridKeyDown}>
            {rows.map((row, i) => (
              <tr
                key={i}
                data-made={row.made ? 'true' : undefined}
                style={row.made ? { color: 'red' } : undefined}
              >
                <td className="num">{i + 1}</td>
                {COLUMNS.map((column, c) => (
                  <td key={column.key} data-grid-row={i} data-grid-column={c}>
                    <input
                      aria-label={`${column.header} row ${i + 1}`}
                      value={row[column.key]}
                      maxLength={column.max}
                      inputMode={column.key === 'minStk' ? 'decimal' : undefined}
                      onChange={(e) =>
                        setCell(
                          i,
                          column.key,
                          column.key === 'minStk' ? e.target.value : typed(e.target.value),
                        )
                      }
                      onBlur={() => {
                        if (column.key === 'minStk') leaveMinStk(i);
                      }}
                      style={{
                        width: column.width,
                        color: row.made ? 'red' : undefined,
                        textAlign: column.key === 'minStk' ? 'right' : undefined,
                      }}
                    />
                  </td>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div
        className="row"
        style={{ gap: 8, justifyContent: 'flex-end', marginTop: 10, maxWidth: 760 }}
      >
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
          style={{ order: -1 }}
          onClick={() => {
            setMsg(null);
            // BtnPrint_Click (:2652-2659): the print right is checked and nothing else happens.
            if (rights && !rights.canPrint) setMsg({ kind: 'err', text: NO_PRINT_RIGHTS });
          }}
        >
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
        <button
          type="button"
          className="danger"
          onClick={() => {
            setMsg(null);
            // BtnDelete_Click (:2927-2944) deletes only in the Labour mode; here it checks the delete right.
            if (rights && !rights.canDelete) setMsg({ kind: 'err', text: NO_RIGHTS });
          }}
        >
          Delete
        </button>
        <button type="button" className="ghost" onClick={() => router.back()}>
          Exit
        </button>
      </div>
      <FormKeyHints actions={formKeys} />
    </div>
  );
}
