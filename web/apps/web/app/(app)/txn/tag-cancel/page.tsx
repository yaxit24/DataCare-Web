'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

// TAG CANCEL (TR_TAG_CAN) — remove one or more tags from stock. Posts to /stock/tag-cancel
// (tagCancel), which writes a MAIN_STOCK out-movement per tag (VCH_TYPE 'TGCAN', ITM_SIGN '-').
// Pure inventory removal — no money ledger. Mirrors the desktop Tag Cancellation screen.
interface Line {
  tagNo: string;
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  fineWt: string;
}
const blank = (): Line => ({
  tagNo: '',
  itCode: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  fineWt: '',
});
const n = (v: string) => Number(v || 0);

export default function TagCancelPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [res, setRes] = useState<{ vchNo: number; tags: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        lines: lines
          .filter((l) => l.tagNo && l.itCode)
          .map((l) => ({
            tagNo: l.tagNo,
            itCode: l.itCode,
            pcs: n(l.pcs),
            netWt: n(l.netWt),
            grossWt: n(l.grossWt),
            touch: n(l.touch),
            fineWt: n(l.fineWt),
          })),
      };
      setRes(await post('/stock/tag-cancel', body));
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
      <h1>Tag Cancellation</h1>
      <p className="muted">
        Cancel tags and remove them from stock. Each tag posts a stock-out movement (MAIN_STOCK,
        VCH_TYPE &lsquo;TGCAN&rsquo;) — no money ledger.
      </p>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="TGC" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Tags to Cancel</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Tag</th>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch %</th>
                <th className="num">Fine</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={l.tagNo}
                      onChange={(v) => setLine(i, 'tagNo', v)}
                      style={{ width: 120 }}
                      onPick={(r) =>
                        setLines((ls) =>
                          ls.map((x, j) =>
                            j === i
                              ? {
                                  ...x,
                                  tagNo: String(r.code),
                                  itCode: String(r.name ?? x.itCode),
                                  netWt: String(r.ITM_NWT ?? x.netWt),
                                  grossWt: String(r.ITM_GWT ?? x.grossWt),
                                  touch: String(r.ITM_TOUCH ?? x.touch),
                                  fineWt: String(r.ITM_FINE ?? x.fineWt),
                                }
                              : x,
                          ),
                        )
                      }
                    />
                  </td>
                  <td>
                    <input
                      value={l.itCode}
                      onChange={(e) => setLine(i, 'itCode', e.target.value)}
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
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.fineWt}
                      onChange={(e) => setLine(i, 'fineWt', e.target.value)}
                    />
                  </td>
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
              + Add tag
            </button>
            <span className="spacer" />
            <button className="primary" disabled={busy}>
              {busy ? 'Cancelling…' : 'Cancel Tags'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Cancel voucher #{res.vchNo} created — {res.tags} tag(s) cancelled
          </div>
        </div>
      )}
    </div>
  );
}
