'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

/** Tag Transfer (TR_TAG_TRFR): convert a barcoded tag into a bulk/loose item (e.g. broken chain → OLD GOLD). */
interface Row {
  tagNo: string;
  fromItCode: string;
  toItCode: string;
  tblCode: string;
  designNo: string;
  itmSize: string;
  pcs: string;
  grossWt: string;
  lessWt: string;
  netWt: string;
  touch: string;
  westPct: string;
  rate: string;
}
const blank = (): Row => ({
  tagNo: '',
  fromItCode: '',
  toItCode: '',
  tblCode: '000',
  designNo: '',
  itmSize: '',
  pcs: '',
  grossWt: '',
  lessWt: '',
  netWt: '',
  touch: '',
  westPct: '',
  rate: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function TagTransferPage() {
  const [rows, setRows] = useState<Row[]>([blank()]);
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
      .filter((r) => r.tagNo.trim() && r.toItCode.trim())
      .map((r) => ({
        tagNo: r.tagNo.trim(),
        fromItCode: r.fromItCode.trim() || undefined,
        toItCode: r.toItCode.trim(),
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
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one line with a tag + target item' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<{ vchNo: number; lines: number }>('/stock/tag-transfer', {
        vchDate: vchDate || undefined,
        lines,
      });
      setRes(r);
      setMsg({ kind: 'ok', text: `Transferred ${r.lines} tag(s) (voucher #${r.vchNo})` });
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
        Tag Transfer{' '}
        <span className="muted">— convert a tag into a bulk/old-gold item (fine conserved)</span>
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
              tag leaves barcode stock · its weight joins the target item · no money movement
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Tag</th>
                <th>From item</th>
                <th>→ To item</th>
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
                <th className="num">Rate</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={r.tagNo}
                      onChange={(v) => set(i, 'tagNo', v)}
                      style={{ width: 100 }}
                      onPick={(row) =>
                        setRows((rs) =>
                          rs.map((x, j) =>
                            j === i
                              ? {
                                  ...x,
                                  tagNo: String(row.code),
                                  fromItCode: String(row.name || x.fromItCode),
                                  netWt: String(row.ITM_NWT ?? x.netWt),
                                  grossWt: String(row.ITM_GWT ?? x.grossWt),
                                  touch: String(row.ITM_TOUCH ?? x.touch),
                                  rate: String(row.ITM_RATE ?? x.rate),
                                }
                              : x,
                          ),
                        )
                      }
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={r.fromItCode}
                      onChange={(v) => set(i, 'fromItCode', v)}
                      style={{ width: 74 }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={r.toItCode}
                      onChange={(v) => set(i, 'toItCode', v)}
                      style={{ width: 80 }}
                    />
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
                      style={{ width: 56 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.itmSize}
                      onChange={(e) => set(i, 'itmSize', e.target.value)}
                      style={{ width: 42 }}
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
              POST /stock/tag-transfer
            </span>
            <button className="primary" disabled={busy}>
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
