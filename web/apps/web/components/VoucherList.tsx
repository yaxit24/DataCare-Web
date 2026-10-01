'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, del, ApiError } from '../lib/api';

/** Reusable recent-voucher list for transaction screens: navigate / print / delete / load-to-edit.
 *  `table`+`book` feed GET /vouchers/recent; `deleteBase` is the module's reversible DELETE base
 *  (e.g. '/sales' → DELETE /sales/:vchNo). `printHref(vchNo)` and `onLoad(vchNo)` are optional. */
interface VRow {
  vchNo: string;
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
}: {
  table: string;
  book: string;
  deleteBase?: string;
  printHref?: (vchNo: string) => string;
  onLoad?: (vchNo: string) => void;
  reloadKey?: unknown;
}) {
  const [rows, setRows] = useState<VRow[]>([]);
  const [open, setOpen] = useState(false);
  const [msg, setMsg] = useState('');
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
  }, [table, book]);
  useEffect(() => {
    if (open) void load();
  }, [open, load, reloadKey]);

  async function remove(vchNo: string) {
    if (!deleteBase) return;
    if (!confirm(`Delete voucher #${vchNo}? This reverses its ledger + stock.`)) return;
    setMsg('');
    try {
      // The recent list is scoped to this configured book; deletion must carry the same identity. Omitting
      // it made writers fall back to mnemonic literals (for example Purchase Return -> PRT) and could not
      // delete a real desktop-shaped book such as 348.
      await del(`${deleteBase}/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(book)}`);
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
        <button type="button" className="ghost" onClick={() => setOpen((o) => !o)}>
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
            <tbody>
              {rows.map((r, i) => (
                <tr key={`${r.vchNo}-${i}`}>
                  <td>{r.vchNo}</td>
                  <td>{r.vchDate ?? ''}</td>
                  <td>{r.acName || r.acCode}</td>
                  <td className="num">{money(r.total)}</td>
                  <td style={{ whiteSpace: 'nowrap' }}>
                    {onLoad && (
                      <button type="button" className="ghost" onClick={() => onLoad(r.vchNo)}>
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
                        onClick={() => remove(r.vchNo)}
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
