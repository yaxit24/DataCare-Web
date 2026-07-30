'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

/** Approval Return (Tour IsuRec): unsold goods taken on approval come back into stock + close the issue lines. */
interface Row {
  origSrNo: string;
  itCode: string;
  tagNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
}
const blank = (): Row => ({
  origSrNo: '',
  itCode: '',
  tagNo: '',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function TourReturnPage() {
  const [origVchNo, setOrigVchNo] = useState('');
  const [salesmanAc, setSalesmanAc] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [rows, setRows] = useState<Row[]>([blank()]);
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  const [res, setRes] = useState<{ vchNo: number; fine: number; closedLines: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));
  const fine = (r: Row) => r3((n(r.netWt) * n(r.touch)) / 100);

  async function loadLines() {
    if (!origVchNo.trim()) {
      setMsg({ kind: 'err', text: 'enter the issue vch no first' });
      return;
    }
    try {
      const lines = await get<any[]>(`/tour/${encodeURIComponent(origVchNo.trim())}/lines`);
      const open = lines.filter((l) => l.open);
      setRows(
        open.length
          ? open.map((l) => ({
              origSrNo: String(l.srNo),
              itCode: String(l.itCode || ''),
              tagNo: l.tagNo || '',
              pcs: String(l.pcs || ''),
              grossWt: String(l.grossWt || ''),
              netWt: String(l.netWt || ''),
              touch: String(l.touch || ''),
            }))
          : [blank()],
      );
      setMsg({
        kind: 'ok',
        text: `Loaded ${open.length} open line(s) from issue #${origVchNo.trim()}`,
      });
    } catch (e) {
      setMsg({
        kind: 'err',
        text:
          e instanceof ApiError ? e.body?.message || e.body?.error || 'load failed' : 'load failed',
      });
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!origVchNo.trim()) {
      setMsg({ kind: 'err', text: 'enter the original tour issue voucher no' });
      return;
    }
    const lines = rows
      .filter((r) => r.itCode.trim())
      .map((r) => ({
        origSrNo: r.origSrNo ? Number(r.origSrNo) : undefined,
        itCode: r.itCode.trim(),
        tagNo: r.tagNo.trim() || undefined,
        pcs: n(r.pcs),
        grossWt: n(r.grossWt),
        netWt: n(r.netWt),
        touch: n(r.touch),
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one return line' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<{ vchNo: number; fine: number; closedLines: number }>('/tour/return', {
        origVchNo: origVchNo.trim(),
        salesmanAc: salesmanAc.trim() || undefined,
        vchDate: vchDate || undefined,
        lines,
      });
      setRes(r);
      setMsg({
        kind: 'ok',
        text: `Returned ${lines.length} line(s), closed ${r.closedLines} issue line(s) (voucher #${r.vchNo})`,
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
        Approval Return{' '}
        <span className="muted">— unsold tour goods back into stock (closes the issue)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Original Issue Vch No</label>
              <div style={{ display: 'flex', gap: 4 }}>
                <input
                  value={origVchNo}
                  onChange={(e) => setOrigVchNo(e.target.value)}
                  placeholder="tour issue #"
                />
                <button type="button" className="ghost" onClick={loadLines}>
                  Load lines
                </button>
              </div>
            </div>
            <div className="field">
              <label>Salesman</label>
              <LookupPicker entity="accounts" value={salesmanAc} onChange={setSalesmanAc} />
            </div>
            <div className="field">
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Orig Sr</th>
                <th>Item</th>
                <th>Tag</th>
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
                    <input
                      value={r.origSrNo}
                      onChange={(e) => set(i, 'origSrNo', e.target.value)}
                      style={{ width: 52, textAlign: 'right' }}
                    />
                  </td>
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
              POST /tour/return
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Posting…' : 'Post Return'}
            </button>
          </div>
          {res && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">voucher</div>
                <div className="big kpi">#{res.vchNo}</div>
              </div>
              <div className="tile">
                <div className="muted">fine back (g)</div>
                <div className="big kpi">{res.fine.toLocaleString('en-IN')}</div>
              </div>
              <div className="tile">
                <div className="muted">issue lines closed</div>
                <div className="big kpi">{res.closedLines}</div>
              </div>
            </div>
          )}
        </div>
      </form>
      {/* Desktop BtnImgS / BtnImgC / BtnImgD photograph the tag on the current grid row. */}
      <EntityImagePanel
        entityType="TAG"
        entityKey={rows[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="tour-return-image"
      />
    </div>
  );
}
