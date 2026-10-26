'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { todayLocal } from '../../../../lib/localDate';

/** Desktop "Contra Entry" opens with `CurBookHelp("CONTRA")` (MDI_FORM.cs:8100-8111). */
const CONTRA_MAIN_BOOKS = ['CONTRA'];

/** Contra (bank↔cash / account transfer): a two-line Dr/Cr voucher. The Dr account receives, the Cr
 *  account gives; both amounts must be equal (a balanced transfer). Posts Dr toAc / Cr fromAc. */
export default function ContraPage() {
  // The CONTRA book the voucher is numbered in; postContra refuses a voucher without one.
  const [coBook, setCoBook] = useState('');
  const [drAc, setDrAc] = useState('');
  const [crAc, setCrAc] = useState('');
  // P3: the receiving account's NAME, denormalised onto the voucher as the desktop does.
  const [toAcName, setToAcName] = useState('');
  const [drAmt, setDrAmt] = useState('');
  const [crAmt, setCrAmt] = useState('');
  const [itDesc, setItDesc] = useState('');
  const [vchDate, setVchDate] = useState(todayLocal());
  const [res, setRes] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const n = (v: string) => Number(v || 0);
  const equal = Math.abs(n(drAmt) - n(crAmt)) < 0.005 && n(drAmt) > 0;

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    if (!drAc.trim() || !crAc.trim()) {
      setErr('pick both the Dr and Cr accounts');
      return;
    }
    if (drAc.trim() === crAc.trim()) {
      setErr('Dr and Cr accounts must differ');
      return;
    }
    if (!equal) {
      setErr('Dr total must equal Cr total');
      return;
    }
    if (!coBook) {
      setErr('select the configured contra book first');
      return;
    }
    setBusy(true);
    try {
      setRes(
        await post('/contra', {
          coBook,
          toAc: drAc.trim(),
          fromAc: crAc.trim(),
          amount: n(drAmt),
          itDesc: itDesc || undefined,
          vchDate,
        }),
      );
      setDrAmt('');
      setCrAmt('');
      setItDesc('');
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.detail || e.body?.error || e.message
          : 'failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Contra <span className="muted">— account transfer (two-line Dr / Cr)</span>
      </h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} mainBooks={CONTRA_MAIN_BOOKS} />
            </div>
            <div className="field">
              <label>To A/c Name</label>
              <input value={toAcName} onChange={(e) => setToAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>Narration (ItDesc)</label>
              <input
                value={itDesc}
                onChange={(e) => setItDesc(e.target.value)}
                placeholder="e.g. cash deposited to bank"
              />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Dr / Cr</th>
                <th>Account</th>
                <th className="num">Debit</th>
                <th className="num">Credit</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>
                  <b>Dr</b> <span className="muted">(to)</span>
                </td>
                <td>
                  <LookupPicker
                    entity="accounts"
                    value={drAc}
                    onChange={setDrAc}
                    ariaLabel="Dr account"
                    style={{ width: 200 }}
                  />
                </td>
                <td className="num">
                  <input
                    aria-label="Dr amount"
                    value={drAmt}
                    onChange={(e) => setDrAmt(e.target.value)}
                    style={{ width: 120, textAlign: 'right' }}
                  />
                </td>
                <td className="num">
                  <span className="muted">—</span>
                </td>
              </tr>
              <tr>
                <td>
                  <b>Cr</b> <span className="muted">(from)</span>
                </td>
                <td>
                  <LookupPicker
                    entity="accounts"
                    value={crAc}
                    onChange={setCrAc}
                    ariaLabel="Cr account"
                    style={{ width: 200 }}
                  />
                </td>
                <td className="num">
                  <span className="muted">—</span>
                </td>
                <td className="num">
                  <input
                    aria-label="Cr amount"
                    value={crAmt}
                    onChange={(e) => setCrAmt(e.target.value)}
                    style={{ width: 120, textAlign: 'right' }}
                  />
                </td>
              </tr>
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={2} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Totals
                </td>
                <td className="num">
                  <b>{n(drAmt).toLocaleString('en-IN')}</b>
                </td>
                <td className="num">
                  <b>{n(crAmt).toLocaleString('en-IN')}</b>
                </td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className={equal ? 'muted' : 'msg err'} style={{ margin: 0 }}>
              {equal ? 'Balanced ✓' : 'Dr must equal Cr'}
            </span>
            <span className="spacer" />
            <button className="primary" disabled={busy || !equal || !coBook}>
              {busy ? 'Saving…' : 'Save Contra'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">Contra posted — Voucher #{res.vchNo}</div>
        </div>
      )}
    </div>
  );
}
