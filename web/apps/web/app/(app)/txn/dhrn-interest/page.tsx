'use client';
import { useState } from 'react';
import { get, post, put, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { openDocument } from '../../../../lib/openDocument';

// Dhrn (pledge loan) interest receipt (desktop TR_DHRN_INTREC). Booked against an issue voucher
// (ISU_NO) on the INTREST RECIVED book: collects assessed interest (and optionally received/kasar).
// Full lifecycle: create / reopen / edit / delete.
const inr = (x: number) => Number(x || 0).toLocaleString('en-IN');

export default function DhrnInterestPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [isuNo, setIsuNo] = useState('');
  const [isuBook, setIsuBook] = useState('DHI');
  const [borrowerAc, setBorrowerAc] = useState('');
  const [borrowerName, setBorrowerName] = useState('');
  const [interest, setInterest] = useState('');
  const [intReceived, setIntReceived] = useState('');
  const [intKasar, setIntKasar] = useState('');
  const [os, setOs] = useState<number | null>(null);
  const [res, setRes] = useState<{ vchNo: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [checking, setChecking] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');

  function resetForm() {
    setLoadedVch('');
    setIsuNo('');
    setBorrowerAc('');
    setBorrowerName('');
    setInterest('');
    setIntReceived('');
    setIntKasar('');
    setOs(null);
    setRes(null);
    setErr('');
  }

  async function loadInterest(vchNo: string) {
    setErr('');
    setRes(null);
    try {
      const d = await get<any>(
        `/dhrn/interest/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setIsuNo(String(d.isuNo ?? '').replace(/^0+/, '') || String(d.isuNo ?? ''));
      setIsuBook(String(d.isuBook ?? 'DHI'));
      setBorrowerAc(String(d.borrowerAc ?? ''));
      setBorrowerName(String(d.borrowerName ?? ''));
      setInterest(Number(d.interest ?? 0) ? String(d.interest) : '');
      setIntReceived(Number(d.intReceived ?? 0) ? String(d.intReceived) : '');
      setIntKasar(Number(d.intKasar ?? 0) ? String(d.intKasar) : '');
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed to load');
    }
  }

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
    if (!coBook) {
      setErr('select the interest-receipt book first');
      return;
    }
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        isuNo,
        isuBook: isuBook || undefined,
        isuYear: coYear,
        borrowerAc,
        borrowerName: borrowerName || undefined,
        interest: interest.trim() === '' ? undefined : Number(interest),
        intReceived: intReceived.trim() === '' ? undefined : Number(intReceived),
        intKasar: intKasar.trim() === '' ? undefined : Number(intKasar),
      };
      const out = loadedVch
        ? await put<{ vchNo: number }>(`/dhrn/interest/${encodeURIComponent(loadedVch)}`, body)
        : await post<{ vchNo: number }>('/dhrn/interest', body);
      setRes(out);
      if (!loadedVch) {
        setInterest('');
        setIntReceived('');
        setIntKasar('');
      }
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
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="DIR"
                mainBooks={['INTREST RECIVED']}
              />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Issue Book</label>
              <input value={isuBook} onChange={(e) => setIsuBook(e.target.value)} />
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
              <label>Interest (assessed)</label>
              <input
                value={interest}
                onChange={(e) => setInterest(e.target.value)}
                placeholder="blank = compute the accrued interest"
              />
              <small className="hint">
                Leave blank to compute the interest accrued to this date.
              </small>
            </div>
            <div className="field">
              <label>Interest received</label>
              <input
                value={intReceived}
                onChange={(e) => setIntReceived(e.target.value)}
                placeholder="blank = same as assessed"
              />
            </div>
            <div className="field">
              <label>Kasar (write-off)</label>
              <input value={intKasar} onChange={(e) => setIntKasar(e.target.value)} />
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
              Outstanding for issue <b>#{isuNo}</b>: <b>₹{inr(os)}</b>
            </div>
          )}
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="spacer" />
            {loadedVch && (
              <button type="button" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
            <button className="primary" data-save-mnemonic disabled={busy || !coBook}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Receive Interest'}
            </button>
            <button
              type="button"
              className="ghost"
              disabled={!borrowerAc}
              onClick={() =>
                openDocument(
                  `/api/dhrn/khata?acCode=${encodeURIComponent(borrowerAc)}&coYear=${encodeURIComponent(coYear)}&format=html`,
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
          <div className="msg ok">
            Interest {loadedVch ? 'updated' : 'received'} — Voucher #{res.vchNo}
          </div>
        </div>
      )}
      {coBook && (
        <VoucherList
          table="DHRN_REC_DATA"
          book={coBook}
          deleteBase="/dhrn/interest"
          onLoad={(vchNo) => void loadInterest(vchNo)}
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
