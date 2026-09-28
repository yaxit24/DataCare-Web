'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

/** Stock Adjust (TR_STK_ADJ) — manual ±-sign stock correction → signed MAIN_STOCK movement (no ledger).
 *  Rich fields: Counter/Design/Size/LsWt/West%/Mrp/Karigar. Tag pick autofills item + weights. */
interface Row {
  itCode: string;
  tagNo: string;
  sign: '+' | '-';
  tblCode: string;
  designNo: string;
  itmSize: string;
  pcs: string;
  grossWt: string;
  lessWt: string;
  netWt: string;
  touch: string;
  westPct: string;
  mrp: string;
  krCode: string;
  rate: string;
}
const blank = (): Row => ({
  itCode: '',
  tagNo: '',
  sign: '+',
  tblCode: '001',
  designNo: '',
  itmSize: '',
  pcs: '',
  grossWt: '',
  lessWt: '',
  netWt: '',
  touch: '',
  westPct: '',
  mrp: '',
  krCode: '',
  rate: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function StockAdjustPage() {
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
  const fine = (r: Row) => r3((n(r.netWt) * (n(r.touch) + n(r.westPct))) / 100);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    const lines = rows
      .filter((r) => r.itCode.trim())
      .map((r) => ({
        itCode: r.itCode.trim(),
        tagNo: r.tagNo.trim() || undefined,
        sign: r.sign,
        pcs: n(r.pcs),
        grossWt: n(r.grossWt),
        netWt: n(r.netWt),
        touch: n(r.touch),
        rate: n(r.rate),
        tblCode: r.tblCode || undefined,
        designNo: r.designNo || undefined,
        itmSize: r.itmSize || undefined,
        lessWt: n(r.lessWt) || undefined,
        westPct: n(r.westPct) || undefined,
        mrp: n(r.mrp) || undefined,
        krCode: r.krCode || undefined,
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one line' });
      return;
    }
    if (rows.some((r) => r.itCode.trim() && r.sign !== '+' && r.sign !== '-')) {
      setMsg({ kind: 'err', text: 'each line needs a + or − sign' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<{ vchNo: number; lines: number }>('/stock/adjust', {
        vchDate: vchDate || undefined,
        lines,
      });
      setRes(r);
      setMsg({ kind: 'ok', text: `Stock adjusted — ${r.lines} line(s) (voucher #${r.vchNo})` });
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
        Stock Adjust <span className="muted">— TR_STK_ADJ (±-sign manual correction)</span>
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
              + adds to stock · − removes · fine = net × (touch + west%) / 100
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th>+/−</th>
                <th>Ctr</th>
                <th>Design</th>
                <th>Size</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Ls Wt</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">West%</th>
                <th className="num">Fine</th>
                <th className="num">MRP</th>
                <th>Karigar</th>
                <th className="num">Rate</th>
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
                      style={{ width: 84 }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={r.tagNo}
                      onChange={(v) => set(i, 'tagNo', v)}
                      style={{ width: 96 }}
                      onPick={(row) =>
                        setRows((rs) =>
                          rs.map((x, j) =>
                            j === i
                              ? {
                                  ...x,
                                  tagNo: String(row.code),
                                  itCode: String(row.name || x.itCode),
                                  netWt: String(row.ITM_NWT ?? x.netWt),
                                  grossWt: String(row.ITM_GWT ?? x.grossWt),
                                  touch: String(row.ITM_TOUCH ?? x.touch),
                                  rate: String(row.ITM_RATE ?? x.rate),
                                  mrp: String(row.ITM_MRP ?? x.mrp),
                                }
                              : x,
                          ),
                        )
                      }
                    />
                  </td>
                  <td>
                    <select value={r.sign} onChange={(e) => set(i, 'sign', e.target.value)}>
                      <option value="+">+ Add</option>
                      <option value="-">− Rem</option>
                    </select>
                  </td>
                  <td>
                    <input
                      value={r.tblCode}
                      onChange={(e) => set(i, 'tblCode', e.target.value)}
                      style={{ width: 36 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.designNo}
                      onChange={(e) => set(i, 'designNo', e.target.value)}
                      style={{ width: 58 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.itmSize}
                      onChange={(e) => set(i, 'itmSize', e.target.value)}
                      style={{ width: 44 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.pcs}
                      onChange={(e) => set(i, 'pcs', e.target.value)}
                      style={{ width: 44, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.grossWt}
                      onChange={(e) => set(i, 'grossWt', e.target.value)}
                      style={{ width: 60, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.lessWt}
                      onChange={(e) => set(i, 'lessWt', e.target.value)}
                      style={{ width: 50, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.netWt}
                      onChange={(e) => set(i, 'netWt', e.target.value)}
                      style={{ width: 60, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.touch}
                      onChange={(e) => set(i, 'touch', e.target.value)}
                      style={{ width: 50, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.westPct}
                      onChange={(e) => set(i, 'westPct', e.target.value)}
                      style={{ width: 46, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">{fine(r).toLocaleString('en-IN')}</td>
                  <td className="num">
                    <input
                      value={r.mrp}
                      onChange={(e) => set(i, 'mrp', e.target.value)}
                      style={{ width: 64, textAlign: 'right' }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="accounts"
                      value={r.krCode}
                      onChange={(v) => set(i, 'krCode', v)}
                      style={{ width: 84 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.rate}
                      onChange={(e) => set(i, 'rate', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
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
              POST /stock/adjust
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Posting…' : 'Post Adjustment'}
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
