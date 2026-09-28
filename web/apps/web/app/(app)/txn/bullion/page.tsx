'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function BullionBookingPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [fineWt, setFineWt] = useState('');
  const [rate, setRate] = useState('');
  const [advanceAmt, setAdvanceAmt] = useState('');
  const [result, setResult] = useState<{ vchNo: number; amount: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  // P3: AMT_TYPE selects whether the booking settles against cash or bank (TR_BUL_BOOKING grid column AmtType).
  const [amtType, setAmtType] = useState('');

  // live preview: amount = fineWt × rate; balance due = amount − advance
  const amount = r2(n(fineWt) * n(rate));
  const advance = r2(n(advanceAmt));
  const balanceDue = r2(amount - advance);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      if (!partyAc) throw new Error('select a party account');
      if (!(n(fineWt) > 0)) throw new Error('fine weight must be positive');
      if (!(n(rate) > 0)) throw new Error('rate must be positive');
      const body = {
        amtType: amtType.trim() || undefined,
        coBook,
        coYear,
        lcCode,
        partyAc,
        fineWt: Number(fineWt),
        rate: Number(rate),
        advanceAmt: Number(advanceAmt || 0),
      };
      setResult(await post('/bullion/booking', body));
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || e.message
          : e instanceof Error
            ? e.message
            : 'failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Bullion Booking</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Amount Type</label>
              <input value={amtType} onChange={(e) => setAmtType(e.target.value)} />
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="BUL" />
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

        <div className="panel">
          <h2>Booking</h2>
          <div className="row">
            <div className="field">
              <label>Fine Wt</label>
              <input
                value={fineWt}
                onChange={(e) => setFineWt(e.target.value)}
                inputMode="decimal"
              />
            </div>
            <div className="field">
              <label>Rate</label>
              <input value={rate} onChange={(e) => setRate(e.target.value)} inputMode="decimal" />
            </div>
            <div className="field">
              <label>Advance ₹</label>
              <input
                value={advanceAmt}
                onChange={(e) => setAdvanceAmt(e.target.value)}
                inputMode="decimal"
              />
            </div>
            <div className="field">
              <label>Amount ₹</label>
              <input value={amount.toLocaleString('en-IN')} readOnly />
            </div>
          </div>
          <div className="muted" style={{ marginTop: 6 }}>
            Amount ₹{amount.toLocaleString('en-IN')} (fine {n(fineWt).toLocaleString('en-IN')} ×
            rate {n(rate).toLocaleString('en-IN')}) · Advance ₹{advance.toLocaleString('en-IN')} ·{' '}
            <b style={{ color: balanceDue > 0 ? 'var(--err)' : 'var(--ok)' }}>
              Balance due ₹{balanceDue.toLocaleString('en-IN')}
            </b>
          </div>
        </div>

        <div className="toolbar" style={{ marginTop: 10 }}>
          <span className="spacer" />
          <button className="primary" disabled={busy}>
            {busy ? 'Saving…' : 'Save Booking'}
          </button>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Saved — Voucher #{result.vchNo} · Amount ₹
            {Number(result.amount).toLocaleString('en-IN')}
          </div>
        </div>
      )}
    </div>
  );
}
