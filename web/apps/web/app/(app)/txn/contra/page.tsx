'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
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
  // Stage D: the voucher currently loaded for edit, or null for a new one.
  const [loadedVch, setLoadedVch] = useState('');
  const n = (v: string) => Number(v || 0);
  const equal = Math.abs(n(drAmt) - n(crAmt)) < 0.005 && n(drAmt) > 0;

  function resetForm() {
    setLoadedVch('');
    setDrAc('');
    setCrAc('');
    setToAcName('');
    setDrAmt('');
    setCrAmt('');
    setItDesc('');
    setVchDate(todayLocal());
    setRes(null);
    setErr('');
  }

  async function loadContra(vchNo: string) {
    setErr('');
    setRes(null);
    try {
      const d = await get<any>(
        `/contra/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setDrAc(String(d.toAc ?? ''));
      setCrAc(String(d.fromAc ?? ''));
      setToAcName(String(d.toAcName ?? d.acName ?? ''));
      setDrAmt(String(d.amount ?? ''));
      setCrAmt(String(d.amount ?? ''));
      setItDesc(String(d.itDesc ?? ''));
      setVchDate(String(d.vchDate ?? todayLocal()).slice(0, 10));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed to load');
    }
  }

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
      const payload = {
        coBook,
        toAc: drAc.trim(),
        fromAc: crAc.trim(),
        toAcName: toAcName || undefined,
        amount: n(drAmt),
        itDesc: itDesc || undefined,
        vchDate,
      };
      const saved = loadedVch
        ? await put<{ vchNo: number }>(`/contra/${encodeURIComponent(loadedVch)}`, payload)
        : await post<{ vchNo: number }>('/contra', payload);
      setRes(saved);
      if (!loadedVch) {
        setDrAmt('');
        setCrAmt('');
        setItDesc('');
      }
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
            {loadedVch && (
              <button type="button" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
            <button className="primary" data-save-mnemonic disabled={busy || !equal || !coBook}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Contra'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Contra {loadedVch ? 'updated' : 'posted'} — Voucher #{res.vchNo}
          </div>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="CONTRA_DATA"
          book={coBook}
          deleteBase="/contra"
          onLoad={(vchNo) => void loadContra(vchNo)}
          printHref={(v) =>
            `/api/contra/${encodeURIComponent(v)}/print?coBook=${encodeURIComponent(coBook)}&format=html`
          }
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
