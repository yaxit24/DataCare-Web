'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

// Dhrn (pledge loan) interest-only collection. Booked against an issue voucher (ISU_NO): it collects
// accrued interest WITHOUT repaying principal, so the outstanding is unchanged.
const inr = (x: number) => Number(x || 0).toLocaleString('en-IN');

export default function DhrnInterestPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [isuNo, setIsuNo] = useState('');
  const [borrowerAc, setBorrowerAc] = useState('');
  const [borrowerName, setBorrowerName] = useState('');
  const [interest, setInterest] = useState('');
  const [os, setOs] = useState<number | null>(null); // last fetched/known outstanding
  const [res, setRes] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [checking, setChecking] = useState(false);

  // GET /dhrn/{isuNo}/outstanding → { isuNo, outstanding }
  async function checkOutstanding() {
    setErr('');
    setOs(null);
    if (!isuNo) {
      setErr('enter an Issue Voucher No first');
      return;
    }
    setChecking(true);
    try {
      const r = await get(`/dhrn/${encodeURIComponent(isuNo)}/outstanding`);
      setOs(Number(r.outstanding));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setChecking(false);
    }
  }

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
        isuNo,
        borrowerAc,
        borrowerName: borrowerName || undefined,
        // P1-1: same suppression as dhrn-receipt, with a worse symptom here.
        //
        // `dhrn.ts:756-760` computes the accrued interest when the field is absent, then
        // `:761-762` refuses a non-positive result. Sending an explicit 0 therefore did not
        // merely charge nothing — it made a blank field FAIL with "interest must be positive"
        // instead of computing what was owed, so the interest-only receipt was unusable
        // without hand-calculating the figure the server already knows.
        interest: interest.trim() === '' ? undefined : Number(interest),
      };
      const out = await post('/dhrn/interest', body);
      setRes(out);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Pledge Loan — Interest Receipt</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="DIN" />
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
              <label>Issue Voucher No</label>
              <input
                value={isuNo}
                onChange={(e) => {
                  setIsuNo(e.target.value);
                  setOs(null);
                }}
                required
              />
            </div>
            <div className="field">
              <label>Borrower (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={borrowerAc}
                onChange={setBorrowerAc}
                onPick={(r) => setBorrowerName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Borrower Name</label>
              <input value={borrowerName} onChange={(e) => setBorrowerName(e.target.value)} />
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label>Interest</label>
              {/* `required` was part of the same defect: it forced the operator to type a figure,
                  so the configured monthly/daily/compound calculation could never run even after
                  the payload was fixed. Desktop TR_DHRN_INTREC.cs:4265-4368 defaults the compound
                  flag and offers a month selector rather than demanding a hand-computed amount. */}
              <input
                value={interest}
                onChange={(e) => setInterest(e.target.value)}
                placeholder="blank = compute the accrued interest"
                aria-describedby="dhrn-interest-help"
              />
              <small id="dhrn-interest-help" className="hint">
                Leave blank to receive the interest accrued to this date; type a value only to
                override it.
              </small>
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <button
                type="button"
                className="ghost"
                onClick={checkOutstanding}
                disabled={checking}
              >
                {checking ? 'Checking…' : 'Check Outstanding'}
              </button>
            </div>
          </div>
          {os != null && (
            <div className="muted" style={{ marginTop: 6 }}>
              Outstanding for issue <b>#{isuNo}</b>: <b>₹{inr(os)}</b>{' '}
              <span className="muted">(unchanged by interest receipt)</span>
            </div>
          )}
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="spacer" />
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Receive Interest'}
            </button>
            <button
              type="button"
              className="ghost"
              disabled={!borrowerAc}
              onClick={() =>
                window.open(
                  `/api/dhrn/khata?acCode=${encodeURIComponent(borrowerAc)}&coYear=${encodeURIComponent(coYear)}&format=html`,
                  '_blank',
                )
              }
            >
              View Khata-Vahi
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">Interest received — Voucher #{res.vchNo}</div>
          <div className="tiles">
            <div className="tile">
              <div className="muted">vchNo</div>
              <div className="big kpi">{res.vchNo}</div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
