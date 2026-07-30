'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

// FINE IN/OUT (TR_FN_INOUT) — pure fine-metal movement to/from a refinery or inter-branch.
// IN = metal received (+), OUT = metal sent (−). Posts to the /inout/fine backend (fineInout),
// which writes INOUT_DATA + INOUT_DETL and a signed MAIN_STOCK movement per line.
interface Line {
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
}
const blank = (): Line => ({ itCode: '', pcs: '1', grossWt: '', netWt: '', touch: '' });
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

export default function FineInoutPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [direction, setDirection] = useState<'IN' | 'OUT'>('IN');
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [result, setResult] = useState<{ vchNo: number; fine: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live preview: fine = net × touch / 100
  const fineOf = (l: Line) => r3((n(l.netWt) * n(l.touch)) / 100);
  const netTotal = r3(lines.reduce((s, l) => s + n(l.netWt), 0));
  const fineTotal = r3(lines.reduce((s, l) => s + fineOf(l), 0));

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
        direction,
        partyAc: partyAc || undefined,
        lines: lines
          .filter((l) => l.itCode && l.netWt)
          .map((l) => ({
            itCode: l.itCode,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
          })),
      };
      setResult(await post('/inout/fine', body));
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
      <h1>Fine In/Out — pure metal {direction === 'IN' ? 'IN (received)' : 'OUT (sent)'}</h1>
      <p className="muted">
        Pure fine-metal movement to/from a refinery or another branch. IN adds fine to stock (+),
        OUT removes it (−).
      </p>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Direction</label>
              <select
                value={direction}
                onChange={(e) => setDirection(e.target.value as 'IN' | 'OUT')}
              >
                <option value="IN">IN — received</option>
                <option value="OUT">OUT — sent</option>
              </select>
            </div>
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="FIO" />
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
              Net {netTotal.toLocaleString('en-IN')} g ·{' '}
              <b>Fine {fineTotal.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : `Save ${direction}`}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Saved — Voucher #{result.vchNo} ({direction})
          </div>
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
    </div>
  );
}
