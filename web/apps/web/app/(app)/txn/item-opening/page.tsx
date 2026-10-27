'use client';
import { useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { todayLocal } from '../../../../lib/localDate';

/** Item (non-tag) Opening Balance — TR_ITM_OPBL → ITM_OPBL + MAIN_STOCK 'ITOBL'. Bulk/loose opening stock. */
interface Row {
  diamondWt: string;
  diamondRate: string;
  diamondAmount: string;
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
}
const blank = (): Row => ({
  itCode: '',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  diamondWt: '',
  diamondRate: '',
  diamondAmount: '',
});
const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const currentDate = () => todayLocal();
const gridCell = (row: number, column: number) => ({
  'data-grid-row': row,
  'data-grid-column': column,
});

export default function ItemOpeningPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [rows, setRows] = useState<Row[]>([blank()]);
  const [vchDate, setVchDate] = useState(currentDate);
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [res, setRes] = useState<{ vchNo: number; items: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const submitRef = useRef<HTMLButtonElement>(null);
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 6,
    onAppendRow: () => setRows((current) => [...current, blank()]),
    onRemoveRow: (row) => {
      if (!window.confirm('Remove this item row?')) return false;
      setRows((current) =>
        current.length > 1 ? current.filter((_, index) => index !== row) : [blank()],
      );
      return true;
    },
    onEscape: () => submitRef.current?.focus(),
  });
  const set = (i: number, k: keyof Row, v: string) =>
    setRows((current) => current.map((row, index) => (index === i ? { ...row, [k]: v } : row)));
  const fine = (row: Row) => Math.round(((n(row.netWt) * n(row.touch)) / 100) * 1000) / 1000;
  const scopeQuery = `coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`;
  const errorText = (error: unknown) =>
    error instanceof ApiError
      ? error.body?.detail || error.body?.message || error.body?.error || error.message
      : 'failed';

  function newVoucher() {
    setLoadedVchNo('');
    setVoucherLookup('');
    setVchDate(currentDate());
    setRows([blank()]);
    setRes(null);
    setMsg(null);
  }

  async function loadVoucher() {
    if (!voucherLookup.trim()) return;
    setBusy(true);
    setMsg(null);
    try {
      const view = await get<any>(
        `/stock/item-opening/${encodeURIComponent(voucherLookup.trim())}?${scopeQuery}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setVchDate(String(view.vchDate));
      const loaded = (view.lines ?? []).map((line: any): Row => ({
        diamondWt: String(line.diamondWt ?? ''),
        diamondRate: String(line.diamondRate ?? ''),
        diamondAmount: String(line.diamondAmount ?? ''),
        itCode: String(line.itCode ?? ''),
        pcs: str(line.pcs),
        grossWt: str(line.grossWt),
        netWt: str(line.netWt),
        touch: str(line.touch),
        rate: str(line.rate),
      }));
      setRows(loaded.length ? loaded : [blank()]);
      setRes(null);
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function removeVoucher() {
    if (!loadedVchNo || !window.confirm(`Delete voucher ${loadedVchNo}?`)) return;
    setBusy(true);
    setMsg(null);
    try {
      await del(`/stock/item-opening/${encodeURIComponent(loadedVchNo)}?${scopeQuery}`);
      newVoucher();
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    const lines = rows
      .filter((row) => row.itCode.trim())
      .map((row) => ({
        // P3: an opening row for a stone-set ornament values the diamond separately from the
        // metal; without these the opening valuation is metal-only.
        diamondWt: n(row.diamondWt) || undefined,
        diamondRate: n(row.diamondRate) || undefined,
        diamondAmount: n(row.diamondAmount) || undefined,
        itCode: row.itCode.trim(),
        pcs: n(row.pcs),
        grossWt: n(row.grossWt),
        netWt: n(row.netWt),
        touch: n(row.touch),
        rate: n(row.rate),
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one item' });
      return;
    }
    setBusy(true);
    try {
      const body = { coBook: coBook || undefined, coYear, lcCode, vchDate, lines };
      const saved = loadedVchNo
        ? await put<{ vchNo: number; items: number }>(
            `/stock/item-opening/${encodeURIComponent(loadedVchNo)}`,
            body,
          )
        : await post<{ vchNo: number; items: number }>('/stock/item-opening', body);
      const savedNo = String(saved.vchNo).padStart(5, '0');
      setLoadedVchNo(savedNo);
      setVoucherLookup(savedNo);
      setRes(saved);
      setMsg({
        kind: 'ok',
        text: `${loadedVchNo ? 'Opening updated' : 'Opening posted'} — ${saved.items} item(s) (voucher #${saved.vchNo})`,
      });
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <FormKeyHints actions={formKeys} />
      <h1>
        Item Opening Balance <span className="muted">— TR_ITM_OPBL (non-tag stock)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Voucher No</label>
              <input
                aria-label="Voucher No"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                placeholder="00001"
              />
            </div>
            <button type="button" className="ghost" disabled={busy} onClick={loadVoucher}>
              Load
            </button>
            {loadedVchNo && (
              <span className="msg ok" data-testid="item-opening-loaded">
                Loaded #{loadedVchNo}
              </span>
            )}
            {loadedVchNo && (
              <button type="button" className="danger" disabled={busy} onClick={removeVoucher}>
                Delete
              </button>
            )}
            <button type="button" className="ghost" disabled={busy} onClick={newVoucher}>
              New
            </button>
            <div className="field">
              <label>Date</label>
              <input
                aria-label="Date"
                type="date"
                value={vchDate}
                onChange={(e) => setVchDate(e.target.value)}
              />
            </div>
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="IOP"
                mainBooks={['OPSTK']}
              />
            </div>
            <div className="field muted" style={{ alignSelf: 'end' }}>
              IT_CODE ≤ 5 chars · fine = net × touch / 100
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">Fine</th>
                <th className="num">Rate</th>
                <th></th>
              </tr>
            </thead>
            <tbody data-testid="item-opening-grid" onKeyDown={handleGridKey}>
              {rows.map((row, i) => (
                <tr key={i}>
                  <td {...gridCell(i, 0)}>
                    <input
                      aria-label={`Item code row ${i + 1}`}
                      value={row.itCode}
                      maxLength={5}
                      onChange={(e) => set(i, 'itCode', e.target.value)}
                      style={{ width: 90 }}
                    />
                  </td>
                  {(['pcs', 'grossWt', 'netWt', 'touch'] as const).map((field, columnIndex) => (
                    <td {...gridCell(i, columnIndex + 1)} className="num" key={field}>
                      <input
                        aria-label={`Item opening ${field} row ${i + 1}`}
                        value={row[field]}
                        onChange={(e) => set(i, field, e.target.value)}
                        style={{
                          width: field === 'pcs' || field === 'touch' ? 70 : 90,
                          textAlign: 'right',
                        }}
                      />
                    </td>
                  ))}
                  <td className="num">{fine(row).toLocaleString('en-IN')}</td>
                  <td {...gridCell(i, 5)} className="num">
                    <input
                      aria-label={`Item opening rate row ${i + 1}`}
                      value={row.rate}
                      onChange={(e) => set(i, 'rate', e.target.value)}
                      style={{ width: 90, textAlign: 'right' }}
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      aria-label={`Remove item row ${i + 1}`}
                      onClick={() =>
                        setRows((current) =>
                          current.length > 1
                            ? current.filter((_, index) => index !== i)
                            : [blank()],
                        )
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setRows((current) => [...current, blank()])}
            >
              + Add item
            </button>
            <span className="spacer" />
            <button ref={submitRef} className="primary" disabled={busy}>
              {busy ? 'Posting…' : loadedVchNo ? 'Update Opening' : 'Post Opening'}
            </button>
          </div>
          {res && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">voucher</div>
                <div className="big kpi">#{res.vchNo}</div>
              </div>
            </div>
          )}
        </div>
      </form>
    </div>
  );
}
