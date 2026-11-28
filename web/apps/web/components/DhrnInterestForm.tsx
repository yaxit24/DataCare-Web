'use client';
import { useIdempotencyKey } from '../lib/idempotencyKey';
import { useState } from 'react';
import { get, post, postCommand, put, ApiError } from '../lib/api';
import { useBusinessScope } from './BusinessScope';
import { BookSelect } from './BookSelect';
import { LookupPicker } from './LookupPicker';
import { VoucherList } from './VoucherList';
import { openDocument } from '../lib/openDocument';

// Dhrn (pledge loan) interest receipt (desktop TR_DHRN_INTREC). Booked against an issue voucher
// (ISU_NO) on the INTREST RECIVED book: collects assessed interest (and optionally received/kasar).
// Full lifecycle: create / reopen / edit / delete.
const inr = (x: number) => Number(x || 0).toLocaleString('en-IN');

const loanFields: Array<[string, string, string?]> = [
  ['vchDate', 'Date', 'date'], ['billNo', 'Bill No'], ['isuYear', 'Reference Year'],
  ['dhrnDate', 'Loan Date', 'date'], ['loanAmount', 'Lon Amount'], ['oldReceived', 'Old Rec Lon'],
  ['outstandingAmount', 'Pending Loan'], ['principalReceived', 'Lon Rec'], ['unchakReceived', 'Unchak Lon Rec'],
  ['fromDate', 'From Date', 'date'], ['toDate', 'To Date', 'date'], ['intMonth', 'Interest Months'],
  ['intDay', 'Interest Days'], ['intPrc', 'Annual Interest %'], ['monthInterest', 'Monthly Interest Amount'],
  ['dhrnMonths', 'Loan Months'], ['settlementAc', 'Settlement Account'], ['kasarAc', 'Kasar Account'],
  ['empCode', 'Employee'], ['desc', 'Description'],
];
const numericFields = new Set(['loanAmount', 'oldReceived', 'outstandingAmount', 'principalReceived', 'unchakReceived', 'intMonth', 'intDay', 'intPrc', 'monthInterest', 'dhrnMonths', 'rateCutRate', 'rateCutPay']);
export default function DhrnInterestForm({ loan = false }: { loan?: boolean }) {
  const endpoint = loan ? '/loan/interest' : '/dhrn/interest';
  const command = useIdempotencyKey();
  const [extra, setExtra] = useState<Record<string, string>>({});
  const [version, setVersion] = useState('');
  const [loanType, setLoanType] = useState('A');
  const [copy, setCopy] = useState('original');
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [isuNo, setIsuNo] = useState('');
  const [isuBook, setIsuBook] = useState(loan ? '' : 'DHI');
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
    setExtra({});
    setVersion('');
    setLoanType('A');
    command.renew();
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
        `${endpoint}/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setVersion(d.version || '');
      setLoanType(d.loanType || 'A');
      setExtra(Object.fromEntries([...loanFields.map(([k]) => k), 'rateCutRate', 'rateCutPay', 'metalAc', 'intIncAc'].map((k) => [k, String(d[k] ?? '')])));
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
      if (loan) {
        const query = new URLSearchParams({ coBook, isuNo, isuBook, isuYear: extra.isuYear || coYear, borrowerAc });
        const r = await get<any>(`${endpoint}/reference?${query}`);
        setLoanType(r.loanType);
        setOs(Number(r.outstandingAmount));
        setExtra((prev) => ({ ...prev, ...Object.fromEntries(loanFields.filter(([k]) => r[k] != null).map(([k]) => [k, String(r[k])])) }));
        setInterest(String(r.interest));
      } else {
        const r = await get(`/dhrn/${encodeURIComponent(isuNo)}/outstanding`);
        setOs(Number(r.outstanding));
      }
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
        ...(loan ? Object.fromEntries(Object.entries(extra).filter(([, v]) => v !== '').map(([k, v]) => [k, numericFields.has(k) ? Number(v) : v])) : {}),
        ...(loan ? { loanType, expectedVersion: version || undefined } : {}),
        coBook,
        coYear,
        lcCode,
        isuNo,
        isuBook: isuBook || undefined,
        isuYear: extra.isuYear || coYear,
        borrowerAc,
        borrowerName: borrowerName || undefined,
        interest: interest.trim() === '' ? undefined : Number(interest),
        intReceived: intReceived.trim() === '' ? undefined : Number(intReceived),
        intKasar: intKasar.trim() === '' ? undefined : Number(intKasar),
      };
      const out = loadedVch
        ? await put<{ vchNo: number }>(`${endpoint}/${encodeURIComponent(loadedVch)}`, body)
        : loan ? await postCommand<{ vchNo: number }>(endpoint, body, command.key) : await post<{ vchNo: number }>(endpoint, body);
      setRes(out);
      if (loan) { command.renew(); await loadInterest(String(out.vchNo).padStart(5, '0')); setRes(out); }
      if (!loan && !loadedVch) {
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
      <h1>{loan ? 'Loan Intrest' : 'Pledge Loan — Interest Receipt'}</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={(book) => { setCoBook(book); resetForm(); }}
                preferred={loan ? undefined : 'DIR'}
                mainBooks={[loan ? 'LOAN INT ENTRY' : 'INTREST RECIVED']}
              />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Issue Book</label>
              <input aria-label="Issue Book" value={isuBook} onChange={(e) => setIsuBook(e.target.value)} />
            </div>
            <div className="field">
              <label>Issue Voucher No</label>
              <input
                aria-label="Issue Voucher No"
                value={isuNo}
                onChange={(e) => {
                  setIsuNo(e.target.value);
                  setOs(null);
                }}
                required
              />
            </div>
            <div className="field">
              <label>{loan ? 'Lender (AC_CODE)' : 'Borrower (AC_CODE)'}</label>
              <LookupPicker
                entity="accounts"
                value={borrowerAc}
                onChange={setBorrowerAc}
                onPick={(r) => setBorrowerName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>{loan ? 'Lender Name' : 'Borrower Name'}</label>
              <input aria-label="Party Name" value={borrowerName} onChange={(e) => setBorrowerName(e.target.value)} />
            </div>
          </div>
          {loan && <div className="row">
            <div className="field"><label htmlFor="loan-type">Loan Type</label><select id="loan-type" value={loanType} onChange={(e) => setLoanType(e.target.value)}><option value="A">Amount</option><option value="G">Gold</option><option value="S">Silver</option></select></div>
            {loanFields.map(([key, label, type]) => <div className="field" key={key}><label htmlFor={`loan-${key}`}>{label}</label><input id={`loan-${key}`} type={type || 'text'} value={extra[key] ?? (key === 'isuYear' ? coYear : '')} onChange={(e) => setExtra((v) => ({ ...v, [key]: e.target.value }))} /></div>)}
          </div>}
          <div className="row">
            <div className="field">
              <label>Interest (assessed)</label>
              <input
                aria-label="Interest (assessed)"
                value={interest}
                onChange={(e) => setInterest(e.target.value)}
                placeholder="blank = compute the accrued interest"
              />
              <small className="hint">
                Leave blank to compute the interest accrued to this date.
              </small>
            </div>
            <div className="field">
              <label>{loan ? 'Interest paid' : 'Interest received'}</label>
              <input
                aria-label={loan ? 'Interest paid' : 'Interest received'}
                value={intReceived}
                onChange={(e) => setIntReceived(e.target.value)}
                placeholder="blank = same as assessed"
              />
            </div>
            <div className="field">
              <label>Kasar (write-off)</label>
              <input aria-label="Kasar (write-off)" value={intKasar} onChange={(e) => setIntKasar(e.target.value)} />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <button
                type="button"
                className="ghost"
                onClick={checkOutstanding}
                disabled={checking}
              >
                {checking ? 'Checking…' : loan ? 'Load Loan Reference' : 'Check Outstanding'}
              </button>
            </div>
          </div>
          {loan && loanType !== 'A' && <div className="row">{[['rateCutRate', 'Fine Rate'], ['rateCutPay', 'Rate Cut Paid'], ['metalAc', 'Metal Conversion Account']].map(([key, label]) => <div className="field" key={key}><label htmlFor={`loan-${key}`}>{label}</label><input id={`loan-${key}`} value={extra[key!] || ''} onChange={(e) => setExtra((v) => ({ ...v, [key!]: e.target.value }))} /></div>)}</div>}
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
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : loan ? 'Save' : 'Receive Interest'}
            </button>
            {loan && <><select aria-label="Print Copy" value={copy} onChange={(e) => setCopy(e.target.value)}><option value="original">Original</option><option value="duplicate">Duplicate</option><option value="triplicate">Triplicate</option></select><button type="button" disabled={!loadedVch} onClick={() => openDocument(`/api/loan/interest/${loadedVch}/print?coBook=${encodeURIComponent(coBook)}&format=html&copy=${copy}`)}>Print</button></>}
            {!loan && <button
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
            </button>}
          </div>
        </div>
      </form>

      {err && <div className="msg err" role="alert">{err}</div>}
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
          deleteBase={endpoint}
          onLoad={(vchNo) => void loadInterest(vchNo)}
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
