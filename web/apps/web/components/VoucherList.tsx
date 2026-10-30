'use client';
import { type KeyboardEvent, useCallback, useEffect, useRef, useState } from 'react';
import { formatDesktopDate } from '@datacare/core';
import { get, del, ApiError } from '../lib/api';

/** Reusable recent-voucher list for transaction screens: navigate / print / delete / load-to-edit.
 *  `table`+`book` feed GET /vouchers/recent, which lists only the session's company, location and year
 *  in that book and returns each row's complete identity (N51 / G28). `deleteBase` is the module's
 *  reversible DELETE base (e.g. '/sales' → DELETE /sales/:vchNo). `printHref(vchNo)` and
 *  `onLoad(vchNo, identity)` are optional; callers act on the identity of the row clicked. */
export interface VoucherIdentity {
  coCode: string;
  lcCode: string;
  coYear: string;
  coBook: string;
  vchNo: string;
}
interface VRow extends VoucherIdentity {
  vchDate: string | null;
  vchType: string | null;
  acCode: string;
  acName: string;
  total: number;
}
export function VoucherList({
  table,
  book,
  deleteBase,
  printHref,
  onLoad,
  reloadKey,
  openKey,
}: {
  table: string;
  book: string;
  deleteBase?: string;
  printHref?: (vchNo: string) => string;
  onLoad?: (vchNo: string, identity: VoucherIdentity) => void;
  reloadKey?: unknown;
  /** Changing this opens the list and focuses its first voucher: the voucher number box's F1 (N172). */
  openKey?: number;
}) {
  const [rows, setRows] = useState<VRow[]>([]);
  const [open, setOpen] = useState(false);
  const [msg, setMsg] = useState('');
  const body = useRef<HTMLTableSectionElement | null>(null);
  const toggle = useRef<HTMLButtonElement | null>(null);
  const focusAfterLoad = useRef(false);
  // Counts finished loads. It changes in the same render as the rows, so the focus effect below sees them drawn.
  const [loads, setLoads] = useState(0);
  const load = useCallback(async () => {
    try {
      setRows(
        await get<VRow[]>(
          `/vouchers/recent?table=${encodeURIComponent(table)}&book=${encodeURIComponent(book)}`,
        ),
      );
    } catch (e) {
      setMsg(e instanceof ApiError ? e.body?.error || e.message : 'failed');
    }
    setLoads((count) => count + 1);
  }, [table, book]);
  useEffect(() => {
    if (open) void load();
  }, [open, load, reloadKey]);
  useEffect(() => {
    if (!focusAfterLoad.current) return;
    focusAfterLoad.current = false;
    // The first voucher's Load, or the list toggle when the list is empty.
    (
      body.current?.querySelector<HTMLButtonElement>('button[data-voucher-load]') ?? toggle.current
    )?.focus();
  }, [loads]);
  useEffect(() => {
    if (!openKey) return;
    focusAfterLoad.current = true;
    if (open) void load();
    else setOpen(true);
    // Only a new F1 press reopens the list; `open` and `load` changing must not.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [openKey]);

  /** Up and Down move between the vouchers' Load buttons, like the rows of the desktop list (MS_HELP). */
  function moveFocus(event: KeyboardEvent<HTMLButtonElement>) {
    if (event.key !== 'ArrowDown' && event.key !== 'ArrowUp') return;
    const buttons = Array.from(
      body.current?.querySelectorAll<HTMLButtonElement>('button[data-voucher-load]') ?? [],
    );
    const next =
      buttons[buttons.indexOf(event.currentTarget) + (event.key === 'ArrowDown' ? 1 : -1)];
    if (!next) return;
    event.preventDefault();
    next.focus();
  }

  async function remove(row: VoucherIdentity) {
    if (!deleteBase) return;
    const vchNo = row.vchNo;
    if (!confirm(`Delete voucher #${vchNo}? This reverses its ledger + stock.`)) return;
    setMsg('');
    try {
      // The recent list is scoped to this configured book; deletion must carry the same identity. Omitting
      // it made writers fall back to mnemonic literals (for example Purchase Return -> PRT) and could not
      // delete a real desktop-shaped book such as 348.
      await del(
        `${deleteBase}/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(row.coBook || book)}`,
      );
      setMsg(`Deleted #${vchNo}`);
      await load();
    } catch (e) {
      setMsg(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || 'delete failed'
          : 'delete failed',
      );
    }
  }
  const money = (n: number) => Number(n || 0).toLocaleString('en-IN');

  return (
    <div className="panel">
      <div className="toolbar" style={{ margin: 0 }}>
        <button type="button" className="ghost" ref={toggle} onClick={() => setOpen((o) => !o)}>
          {open ? '▾ Recent vouchers' : '▸ Recent vouchers'}
        </button>
        {open && (
          <button type="button" className="ghost" onClick={load}>
            Refresh
          </button>
        )}
        <span className="spacer" />
        {msg && <span className="muted">{msg}</span>}
      </div>
      {open && (
        <div style={{ overflow: 'auto', marginTop: 8 }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Vch</th>
                <th>Date</th>
                <th>Party</th>
                <th className="num">Total</th>
                <th></th>
              </tr>
            </thead>
            <tbody ref={body}>
              {rows.map((r, i) => (
                <tr key={`${r.coYear}|${r.lcCode}|${r.coBook}|${r.vchNo}|${i}`}>
                  <td>{r.vchNo}</td>
                  <td>{formatDesktopDate(r.vchDate)}</td>
                  <td>{r.acName || r.acCode}</td>
                  <td className="num">{money(r.total)}</td>
                  <td style={{ whiteSpace: 'nowrap' }}>
                    {onLoad && (
                      <button
                        type="button"
                        className="ghost"
                        data-voucher-load
                        onKeyDown={moveFocus}
                        onClick={() => onLoad(r.vchNo, r)}
                      >
                        Load
                      </button>
                    )}
                    {printHref && (
                      <a
                        className="ghost"
                        href={printHref(r.vchNo)}
                        target="_blank"
                        rel="noreferrer"
                        style={{ marginLeft: 4 }}
                      >
                        Print
                      </a>
                    )}
                    {deleteBase && (
                      <button
                        type="button"
                        className="danger"
                        style={{ marginLeft: 4 }}
                        onClick={() => remove(r)}
                      >
                        Delete
                      </button>
                    )}
                  </td>
                </tr>
              ))}
              {rows.length === 0 && (
                <tr>
                  <td colSpan={5} className="muted">
                    No recent vouchers.
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}

export default VoucherList;
