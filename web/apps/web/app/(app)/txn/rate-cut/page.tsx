'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

// RATE CUT (desktop book 064, VCH_TYPE RCUT): "cut the rate" = fix the price on metal previously
// sold/issued unfixed. Books the fixed metal value (fine × rate), moves the fine on the customer's
// gold position, and settles in cash / kasar. The API recomputes the figures authoritatively; the
// previews below mirror the spec §2 formulas for the operator.

type RateType = 'G' | '1' | 'K' | 'P';

interface Line {
  itCode: string;
  tagNo: string;
  netWt: string;
  touch: string;
  west: string;
  rate: string;
  rateType: RateType;
}

const blankLine = (): Line => ({
  itCode: '',
  tagNo: '',
  netWt: '',
  touch: '',
  west: '',
  rate: '',
  rateType: 'G',
});

const n = (v: string) => Number(v || 0);
const round3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;
const round0 = (x: number) => Math.round(x + 1e-9);
const inr = (x: number) => round0(x).toLocaleString('en-IN');

// spec §2 fine: (net + ght) × (touch + west)/100; touch+west=0 ⇒ net (ght omitted in this grid).
function lineFine(l: Line): number {
  const net = n(l.netWt);
  const pct = n(l.touch) + n(l.west);
  return round3(pct === 0 ? net : (net * pct) / 100);
}
function lineAmt(l: Line): number {
  const f = lineFine(l);
  const rate = n(l.rate);
  switch (l.rateType) {
    case '1':
      return round0((f * rate) / 10);
    case 'K':
      return round0((f * rate) / 1000);
    case 'P':
      return round0(rate); // per-piece preview uses rate as the piece amount (pcs entered server-side)
    default:
      return round0(f * rate);
  }
}

export default function RateCutPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [itType, setItType] = useState<'G' | 'S'>('G');
  const [lines, setLines] = useState<Line[]>([blankLine()]);
  const [cash, setCash] = useState('');
  const [kasar, setKasar] = useState('');
  const [result, setResult] = useState<{ vchNo: number; fine: number; netAmt: number } | null>(
    null,
  );
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setRow = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));
  const addRow = () => setLines((ls) => [...ls, blankLine()]);
  const removeRow = (i: number) =>
    setLines((ls) => (ls.length > 1 ? ls.filter((_, j) => j !== i) : ls));

  const totalFine = round3(lines.reduce((s, l) => s + lineFine(l), 0));
  const totalAmt = round0(lines.reduce((s, l) => s + lineAmt(l), 0));
  const hasLine = lines.some((l) => n(l.netWt) > 0 || n(l.rate) > 0);
  const canSubmit = !!acCode && hasLine && (totalFine > 0 || totalAmt > 0);

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
        vchDate: vchDate || undefined,
        acCode,
        acName,
        itType,
        lines: lines
          .filter((l) => n(l.netWt) > 0 || n(l.rate) > 0)
          .map((l) => ({
            itCode: l.itCode || undefined,
            tagNo: l.tagNo || undefined,
            netWt: n(l.netWt),
            touch: n(l.touch),
            westPct: n(l.west),
            rate: n(l.rate),
            rateType: l.rateType,
            itType,
          })),
        pay: { cash: n(cash) || undefined, kasar: n(kasar) || undefined },
      };
      setResult((await post('/rate-cut', body)) as { vchNo: number; fine: number; netAmt: number });
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Rate Cut — Fix Metal Price</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="RCT" />
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
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>Party</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={setAcCode}
                onPick={(r) => {
                  setAcCode(String(r.code));
                  setAcName(String(r.name || ''));
                }}
                placeholder="search accounts…"
              />
              {acName && (
                <span className="muted" style={{ fontSize: 12 }}>
                  {acName}
                </span>
              )}
            </div>
            <div className="field">
              <label>Metal</label>
              <select value={itType} onChange={(e) => setItType(e.target.value as 'G' | 'S')}>
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Lines</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>#</th>
                <th>Item</th>
                <th>Tag</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch %</th>
                <th className="num">West %</th>
                <th className="num">Rate</th>
                <th>Rate Type</th>
                <th className="num">Fine</th>
                <th className="num">Amount</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>{i + 1}</td>
                  <td>
                    <input
                      style={{ width: 90 }}
                      value={l.itCode}
                      onChange={(e) => setRow(i, 'itCode', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      style={{ width: 80 }}
                      value={l.tagNo}
                      onChange={(e) => setRow(i, 'tagNo', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 90, textAlign: 'right' }}
                      value={l.netWt}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'netWt', e.target.value)}
                      placeholder="0.000"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 70, textAlign: 'right' }}
                      value={l.touch}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'touch', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 70, textAlign: 'right' }}
                      value={l.west}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'west', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 90, textAlign: 'right' }}
                      value={l.rate}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'rate', e.target.value)}
                      placeholder="0"
                    />
                  </td>
                  <td>
                    <select
                      value={l.rateType}
                      onChange={(e) => setRow(i, 'rateType', e.target.value as RateType)}
                    >
                      <option value="G">Per Gram</option>
                      <option value="1">Per 10g</option>
                      <option value="K">Per Kg</option>
                      <option value="P">Per Piece</option>
                    </select>
                  </td>
                  <td className="num">{lineFine(l).toLocaleString('en-IN')}</td>
                  <td className="num">{inr(lineAmt(l))}</td>
                  <td>
                    <button
                      type="button"
                      className="ghost"
                      onClick={() => removeRow(i)}
                      disabled={lines.length === 1}
                      title="remove line"
                    >
                      ✕
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={8} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Totals
                </td>
                <td className="num">
                  <b>{totalFine.toLocaleString('en-IN')}</b>
                </td>
                <td className="num">
                  <b>{inr(totalAmt)}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 8 }}>
            <button type="button" className="ghost" onClick={addRow}>
              + Add line
            </button>
          </div>
        </div>

        <div className="panel">
          <h2>Settlement</h2>
          <div className="row">
            <div className="field">
              <label>Cash</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={cash}
                inputMode="decimal"
                onChange={(e) => setCash(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Kasar</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={kasar}
                inputMode="decimal"
                onChange={(e) => setKasar(e.target.value)}
                placeholder="0.00"
              />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">
              {canSubmit ? (
                <>
                  Fix <b>{totalFine.toLocaleString('en-IN')}</b> fine{' '}
                  {itType === 'G' ? 'gold' : 'silver'} · value <b>₹{inr(totalAmt)}</b> · settle cash
                  ₹{inr(n(cash))} + kasar ₹{inr(n(kasar))}
                </>
              ) : (
                'Pick a party and enter at least one line to post.'
              )}
            </span>
            <span className="spacer" />
            <button className="primary" disabled={busy || !canSubmit}>
              {busy ? 'Saving…' : 'Save Rate Cut'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Posted — Rate Cut #{result.vchNo} · fine{' '}
            {Number(result.fine ?? 0).toLocaleString('en-IN')} · net ₹
            {inr(Number(result.netAmt ?? 0))}
          </div>
        </div>
      )}
    </div>
  );
}
