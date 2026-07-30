'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

// MFG RECEIVE — metal IN from a process stage with ghat/loss reconciliation. Posts to the REAL
// /mfg/receive backend (receiveMfg) — NOT the karigar pipeline. Per line the accountable received
// weight is RecWt = netWt + ghtWt(=ITM_GHAT) + lossWt(=ITM_LOSS) (+ chol/ghis, not entered here).
interface Line {
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  ghtWt: string;
  lossWt: string;
}
const blank = (): Line => ({
  itCode: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  ghtWt: '',
  lossWt: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function MfgReceivePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState(''); // RECEIPT_BOOK (issue uses 'MIS')
  const [karigarAc, setKarigarAc] = useState('');
  const [karigarName, setKarigarName] = useState('');
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [labourAmt, setLabourAmt] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  const [result, setResult] = useState<{
    vchNo: number;
    fineReceived: number;
    recWt: number;
    netWt: number;
  } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live preview: fine = net × touch / 100; recWt = net + ghat + loss (RTN_CHOL/RTN_GHIS not entered here)
  const fineOf = (l: Line) => r3((n(l.netWt) * n(l.touch)) / 100);
  const recOf = (l: Line) => r3(n(l.netWt) + n(l.ghtWt) + n(l.lossWt));
  const netTotal = r3(lines.reduce((s, l) => s + n(l.netWt), 0));
  const fineTotal = r3(lines.reduce((s, l) => s + fineOf(l), 0));
  const recTotal = r3(lines.reduce((s, l) => s + recOf(l), 0));

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
        karigarAc: karigarAc || undefined,
        partyAc: partyAc || undefined,
        labourAmt: labourAmt ? n(labourAmt) : undefined,
        lines: lines
          .filter((l) => l.itCode && l.netWt)
          .map((l) => ({
            itCode: l.itCode,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
            ghtWt: n(l.ghtWt),
            itmLoss: n(l.lossWt), // lossWt column → MfgLine.itmLoss
          })),
      };
      setResult(await post('/mfg/receive', body));
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || e.body?.detail || e.message
          : 'failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Manufacturing Receive — metal IN</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="MRC" />
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
              <label>Karigar (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={karigarAc}
                onChange={setKarigarAc}
                onPick={(r) => setKarigarName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Karigar Name</label>
              <input value={karigarName} onChange={(e) => setKarigarName(e.target.value)} />
            </div>
            <div className="field">
              <label>Party (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={partyAc}
                onChange={setPartyAc}
                onPick={(r) => setPartyName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Party Name</label>
              <input value={partyName} onChange={(e) => setPartyName(e.target.value)} />
            </div>
            <div className="field">
              <label>Labour Amount ₹</label>
              <input value={labourAmt} onChange={(e) => setLabourAmt(e.target.value)} />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Metal Lines</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Ght Wt</th>
                <th className="num">Loss Wt</th>
                <th className="num">Fine</th>
                <th className="num">RecWt</th>
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
                      style={{ width: 110 }}
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
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.ghtWt}
                      onChange={(e) => setLine(i, 'ghtWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.lossWt}
                      onChange={(e) => setLine(i, 'lossWt', e.target.value)}
                    />
                  </td>
                  <td className="num">{fineOf(l).toLocaleString('en-IN')}</td>
                  <td className="num">{recOf(l).toLocaleString('en-IN')}</td>
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
              Net {netTotal.toLocaleString('en-IN')} g · Fine {fineTotal.toLocaleString('en-IN')} ·{' '}
              <b>RecWt {recTotal.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Save Receive'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Saved — Voucher #{result.vchNo}</div>
          <div className="tiles">
            <div className="tile">
              <div className="muted">vchNo</div>
              <div className="big kpi">{result.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">fineReceived</div>
              <div className="big kpi">{Number(result.fineReceived).toLocaleString('en-IN')}</div>
            </div>
            <div className="tile">
              <div className="muted">recWt</div>
              <div className="big kpi">{Number(result.recWt).toLocaleString('en-IN')}</div>
            </div>
          </div>
        </div>
      )}
      <EntityImagePanel
        entityType="ITEM"
        entityKey={lines[imageRow]?.itCode ?? ''}
        instance={0}
        label="Item image"
        testId="mfg-receive-image"
      />
    </div>
  );
}
