'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

/** Counter Transfer (TR_COUNTER_TRFR): relocate stock from one counter to another (TBL_CODE). */
interface Row {
  itCode: string;
  tagNo: string;
  fromCounter: string;
  toCounter: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
}
const blank = (): Row => ({
  itCode: '',
  tagNo: '',
  fromCounter: '001',
  toCounter: '002',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function CounterTransferPage() {
  const [rows, setRows] = useState<Row[]>([blank()]);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    onAppendRow: () => setRows((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setRows((rows) => (rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row)));
      return true;
    },
    onEscape: () => {},
  });
  const [vchDate, setVchDate] = useState('');
  const [res, setRes] = useState<{ vchNo: number; lines: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));
  const fine = (r: Row) => r3((n(r.netWt) * n(r.touch)) / 100);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    const lines = rows
      .filter((r) => r.itCode.trim() && r.fromCounter.trim() && r.toCounter.trim())
      .map((r) => ({
        itCode: r.itCode.trim(),
        tagNo: r.tagNo.trim() || undefined,
        fromCounter: r.fromCounter.trim(),
        toCounter: r.toCounter.trim(),
        pcs: n(r.pcs),
        grossWt: n(r.grossWt),
        netWt: n(r.netWt),
        touch: n(r.touch),
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one line with item + from/to counters' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<{ vchNo: number; lines: number }>('/stock/counter-transfer', {
        vchDate: vchDate || undefined,
        lines,
      });
      setRes(r);
      setMsg({
        kind: 'ok',
        text: `Transferred ${r.lines} line(s) between counters (voucher #${r.vchNo})`,
      });
      setRows([blank()]);
    } catch (err) {
      setMsg({
        kind: 'err',
        text:
          err instanceof ApiError
            ? err.body?.detail || err.body?.message || err.body?.error || 'failed'
            : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Counter Transfer{' '}
        <span className="muted">— relocate stock between counters (total on-hand unchanged)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field muted" style={{ alignSelf: 'end' }}>
              moves stock out of the source counter and into the target counter · no money movement
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th>From Ctr</th>
                <th>To Ctr</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">Fine</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={r.itCode}
                      onChange={(v) => set(i, 'itCode', v)}
                      style={{ width: 90 }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={r.tagNo}
                      onChange={(v) => set(i, 'tagNo', v)}
                      style={{ width: 100 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.fromCounter}
                      onChange={(e) => set(i, 'fromCounter', e.target.value)}
                      style={{ width: 60 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.toCounter}
                      onChange={(e) => set(i, 'toCounter', e.target.value)}
                      style={{ width: 60 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.pcs}
                      onChange={(e) => set(i, 'pcs', e.target.value)}
                      style={{ width: 50, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.grossWt}
                      onChange={(e) => set(i, 'grossWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.netWt}
                      onChange={(e) => set(i, 'netWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.touch}
                      onChange={(e) => set(i, 'touch', e.target.value)}
                      style={{ width: 56, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">{fine(r).toLocaleString('en-IN')}</td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setRows((rs) => (rs.length > 1 ? rs.filter((_, j) => j !== i) : [blank()]))
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
              onClick={() => setRows((rs) => [...rs, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 12 }}>
              POST /stock/counter-transfer
            </span>
            <button className="primary" data-save-mnemonic disabled={busy}>
              {busy ? 'Posting…' : 'Post Transfer'}
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
