'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

interface Line {
  goldFine: string;
  acCode: string;
  debit: string;
  credit: string;
  fineWt: string;
  itType: string;
}
const blank = (): Line => ({
  acCode: '',
  debit: '',
  credit: '',
  fineWt: '',
  itType: 'A',
  goldFine: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function AcOpeningPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [lines, setLines] = useState<Line[]>([blank(), blank()]);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [result, setResult] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // Live double-entry totals: an opening posts only when Σ Debit == Σ Credit (and non-zero).
  const totDebit = r2(lines.reduce((s, l) => s + n(l.debit), 0));
  const totCredit = r2(lines.reduce((s, l) => s + n(l.credit), 0));
  const diff = r2(totDebit - totCredit);
  const balanced = totDebit === totCredit && totDebit > 0;
  const validLines = lines.filter((l) => l.acCode.trim() && (n(l.debit) > 0 || n(l.credit) > 0));
  const canSubmit = balanced && validLines.length >= 1;

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
        lines: validLines.map((l) => ({
          // P3: an opening balance can carry fine gold beside the money amount.
          goldFine: n(l.goldFine) || undefined,
          acCode: l.acCode,
          drAmt: Number(l.debit || 0),
          crAmt: Number(l.credit || 0),
          fineWt: Number(l.fineWt || 0),
          itType: l.itType || 'A',
        })),
      };
      setResult(await post('/ac-opbl', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Account Opening Balance</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="ACO" />
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
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Opening Balances</h2>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Account</th>
                <th className="num">Debit</th>
                <th className="num">Credit</th>
                <th className="num">Fine Wt</th>
                <th>Type</th>
                <th className="num">Gold Fine</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="accounts"
                      value={l.acCode}
                      onChange={(v) => setLine(i, 'acCode', v)}
                      style={{ width: 200 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 110, textAlign: 'right' }}
                      value={l.debit}
                      onChange={(e) => setLine(i, 'debit', e.target.value)}
                      disabled={n(l.credit) > 0}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 110, textAlign: 'right' }}
                      value={l.credit}
                      onChange={(e) => setLine(i, 'credit', e.target.value)}
                      disabled={n(l.debit) > 0}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 100, textAlign: 'right' }}
                      value={l.fineWt}
                      onChange={(e) => setLine(i, 'fineWt', e.target.value)}
                    />
                  </td>
                  <td>
                    <select value={l.itType} onChange={(e) => setLine(i, 'itType', e.target.value)}>
                      <option value="A">A · Amount</option>
                      <option value="G">G · Gold</option>
                      <option value="S">S · Silver</option>
                    </select>
                  </td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setLines((ls) =>
                          ls.length > 2
                            ? ls.filter((_, j) => j !== i)
                            : ls.map((x, j) => (j === i ? blank() : x)),
                        )
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td style={{ textAlign: 'right', fontWeight: 600 }}>Totals</td>
                <td className="num">
                  <b>{totDebit.toLocaleString('en-IN')}</b>
                </td>
                <td className="num">
                  <b>{totCredit.toLocaleString('en-IN')}</b>
                </td>
                <td colSpan={3}></td>
              </tr>
            </tfoot>
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
              Dr ₹{totDebit.toLocaleString('en-IN')} · Cr ₹{totCredit.toLocaleString('en-IN')} ·{' '}
              {balanced ? (
                <b style={{ color: 'var(--ok)' }}>Balanced ✓</b>
              ) : (
                <b style={{ color: 'var(--err)' }}>Difference ₹{diff.toLocaleString('en-IN')}</b>
              )}
            </span>
            <button className="primary" data-save-mnemonic disabled={busy || !canSubmit}>
              {busy ? 'Saving…' : 'Post Opening'}
            </button>
          </div>
          {!balanced && totDebit + totCredit > 0 && (
            <div className="muted" style={{ marginTop: 6 }}>
              Debits must equal credits to post.
            </div>
          )}
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Posted — Account Opening Voucher #{result.vchNo}</div>
        </div>
      )}
    </div>
  );
}
