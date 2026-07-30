'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

interface Line {
  itCode: string;
  tagNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
}
const blank = (): Line => ({
  itCode: 'GOLD',
  tagNo: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function TourIssuePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [salesmanAc, setSalesmanAc] = useState('');
  const [salesmanName, setSalesmanName] = useState('');
  const [vchDesc, setVchDesc] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  // The desktop's image buttons act on the CURRENT grid row, so the row that last held focus
  // owns the photograph. It persists after blur so clicking the panel does not clear it.
  const [imageRow, setImageRow] = useState(0);
  const [result, setResult] = useState<{ vchNo: number; fine: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line fine = net × touch / 100 (goods OUT on approval — no money)
  const fineOf = (l: Line) => r3((n(l.netWt) * n(l.touch)) / 100);
  const totalFine = r3(lines.reduce((s, l) => s + fineOf(l), 0));
  const totalNet = r3(lines.reduce((s, l) => s + n(l.netWt), 0));
  const totalPcs = lines.reduce((s, l) => s + n(l.pcs), 0);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        salesmanAc,
        salesmanName: salesmanName || undefined,
        vchDesc: vchDesc || undefined,
        lines: lines
          .filter((l) => l.itCode && (l.netWt || l.grossWt || l.pcs))
          .map((l) => ({
            itCode: l.itCode,
            tagNo: l.tagNo || undefined,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
          })),
      };
      setResult(await post('/tour/issue', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Tour / Approval Issue</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="TUR" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
            <div className="field">
              <label>Salesman / Employee</label>
              <LookupPicker
                entity="accounts"
                value={salesmanAc}
                onChange={setSalesmanAc}
                onPick={(r) => setSalesmanName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Name</label>
              <input value={salesmanName} onChange={(e) => setSalesmanName(e.target.value)} />
            </div>
            <div className="field" style={{ flex: 1 }}>
              <label>Description</label>
              <input value={vchDesc} onChange={(e) => setVchDesc(e.target.value)} />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Items issued on approval</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Fine</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={l.itCode}
                      onChange={(v) => setLine(i, 'itCode', v)}
                      style={{ width: 80 }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={l.tagNo}
                      onChange={(v) => setLine(i, 'tagNo', v)}
                      style={{ width: 110 }}
                      onPick={(r) =>
                        setLines((ls) =>
                          ls.map((x, j) =>
                            j === i
                              ? {
                                  ...x,
                                  tagNo: String(r.code),
                                  itCode: String(r.name || x.itCode),
                                  netWt: String(r.ITM_NWT ?? x.netWt),
                                  grossWt: String(r.ITM_GWT ?? x.grossWt),
                                  touch: String(r.ITM_TOUCH ?? x.touch),
                                }
                              : x,
                          ),
                        )
                      }
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 44, textAlign: 'right' }}
                      value={l.pcs}
                      onChange={(e) => setLine(i, 'pcs', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.grossWt}
                      onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.netWt}
                      onChange={(e) => setLine(i, 'netWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.touch}
                      onChange={(e) => setLine(i, 'touch', e.target.value)}
                    />
                  </td>
                  <td className="num">{fineOf(l).toLocaleString('en-IN')}</td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() => setLines((ls) => ls.filter((_, j) => j !== i))}
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
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Pcs {totalPcs} · Net {totalNet.toLocaleString('en-IN')} g ·{' '}
              <b>Fine {totalFine.toLocaleString('en-IN')} g</b>
            </span>
            <button className="primary" disabled={busy || !salesmanAc}>
              {busy ? 'Saving…' : 'Issue on Tour'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Issued — Voucher #{result.vchNo}</div>
          <div className="tiles">
            <div className="tile">
              <div className="muted">vchNo</div>
              <div className="big kpi">{result.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">fine</div>
              <div className="big kpi">{Number(result.fine).toLocaleString('en-IN')}</div>
            </div>
          </div>
        </div>
      )}
      {/* Desktop BtnImgS / BtnImgC / BtnImgD photograph the tag on the current grid row. */}
      <EntityImagePanel
        entityType="TAG"
        entityKey={lines[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="tour-image"
      />
    </div>
  );
}
