'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

// Dhrn (pledge loan) repayment. A receipt is booked against an issue voucher (ISU_NO): it repays
// principal (+ interest) and reduces the outstanding. Outstanding = issue principal − Σ receipts.
const inr = (x: number) => Number(x || 0).toLocaleString('en-IN');

const extendedReceiptFields: Array<[string, string]> = [
  ['adjustDhiran', 'Adjust Dhiran'],
  ['adjustInterest', 'Adjust Interest'],
  ['advanceDhiranReceipt', 'Advance Dhiran Receipt'],
  ['billNo', 'Bill No'],
  ['cashAc', 'Cash Ac'],
  ['dhrnAdjustAmount', 'Dhrn Adjust Amount'],
  ['dhrnDate', 'Dhrn Date'],
  ['dhrnMonths', 'Dhrn Months'],
  ['empCode', 'Emp Code'],
  ['fromDate', 'From Date'],
  ['goldAmount', 'Gold Amount'],
  ['goldWeight', 'Gold Weight'],
  ['intIncAc', 'Int Inc Ac'],
  ['intPrc', 'Int Prc'],
  ['interestDays', 'Interest Days'],
  ['interestKasar', 'Interest Kasar'],
  ['interestMonths', 'Interest Months'],
  ['isuBook', 'Isu Book'],
  ['isuYear', 'Isu Year'],
  ['loanAc', 'Loan Ac'],
  ['loanType', 'Loan Type'],
  ['packetNo', 'Packet No'],
  ['panAdjustAmount', 'Pan Adjust Amount'],
  ['rateCutAmount', 'Rate Cut Amount'],
  ['rateCutOsAmount', 'Rate Cut Os Amount'],
  ['rateCutPayAmount', 'Rate Cut Pay Amount'],
  ['rateCutRate', 'Rate Cut Rate'],
  ['toDate', 'To Date'],
  ['vchDesc', 'Vch Desc'],
];
export default function DhrnReceiptPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [isuNo, setIsuNo] = useState('');
  const [borrowerAc, setBorrowerAc] = useState('');
  const [borrowerName, setBorrowerName] = useState('');
  const [principalRepaid, setPrincipalRepaid] = useState('');
  const [interest, setInterest] = useState('');
  const [os, setOs] = useState<number | null>(null); // last fetched/known outstanding
  const [res, setRes] = useState<{ vchNo: number; outstanding: number } | null>(null);
  const [err, setErr] = useState('');
  // Desktop DHRN_REC_DATA header fields (TR_DHRN_REC:6149-6200).
  const [extra, setExtra] = useState<Record<string, string>>({});
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
        principalRepaid: Number(principalRepaid || 0),
        interest: Number(interest || 0),
        adjustDhiran: extra.adjustDhiran ? Number(extra.adjustDhiran) : undefined,
        adjustInterest: extra.adjustInterest ? Number(extra.adjustInterest) : undefined,
        advanceDhiranReceipt: extra.advanceDhiranReceipt
          ? Number(extra.advanceDhiranReceipt)
          : undefined,
        billNo: extra.billNo || undefined,
        cashAc: extra.cashAc || undefined,
        dhrnAdjustAmount: extra.dhrnAdjustAmount ? Number(extra.dhrnAdjustAmount) : undefined,
        dhrnDate: extra.dhrnDate || undefined,
        dhrnMonths: extra.dhrnMonths ? Number(extra.dhrnMonths) : undefined,
        empCode: extra.empCode || undefined,
        fromDate: extra.fromDate || undefined,
        goldAmount: extra.goldAmount ? Number(extra.goldAmount) : undefined,
        goldWeight: extra.goldWeight ? Number(extra.goldWeight) : undefined,
        intIncAc: extra.intIncAc || undefined,
        intPrc: extra.intPrc ? Number(extra.intPrc) : undefined,
        interestDays: extra.interestDays ? Number(extra.interestDays) : undefined,
        interestKasar: extra.interestKasar ? Number(extra.interestKasar) : undefined,
        interestMonths: extra.interestMonths ? Number(extra.interestMonths) : undefined,
        isuBook: extra.isuBook || undefined,
        isuYear: extra.isuYear || undefined,
        loanAc: extra.loanAc || undefined,
        loanType: extra.loanType || undefined,
        packetNo: extra.packetNo || undefined,
        panAdjustAmount: extra.panAdjustAmount ? Number(extra.panAdjustAmount) : undefined,
        rateCutAmount: extra.rateCutAmount ? Number(extra.rateCutAmount) : undefined,
        rateCutOsAmount: extra.rateCutOsAmount ? Number(extra.rateCutOsAmount) : undefined,
        rateCutPayAmount: extra.rateCutPayAmount ? Number(extra.rateCutPayAmount) : undefined,
        rateCutRate: extra.rateCutRate ? Number(extra.rateCutRate) : undefined,
        toDate: extra.toDate || undefined,
        vchDesc: extra.vchDesc || undefined,
      };
      const out = await post('/dhrn/receipt', body);
      setRes(out);
      setOs(Number(out.outstanding)); // reflect post-repayment outstanding
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Pledge Loan — Repayment Receipt</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="DRC" />
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
              <label>Principal Repaid</label>
              <input
                value={principalRepaid}
                onChange={(e) => setPrincipalRepaid(e.target.value)}
                required
              />
            </div>
            <div className="field">
              <label>Interest</label>
              <input value={interest} onChange={(e) => setInterest(e.target.value)} />
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
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Receive Repayment'}
            </button>
          </div>
        </div>
        <details style={{ marginTop: 8 }}>
          <summary>Desktop receipt fields</summary>
          <div className="row">
            {extendedReceiptFields.map(([key, label]) => (
              <div className="field" key={key}>
                <label>{label}</label>
                <input
                  value={extra[key] ?? ''}
                  onChange={(e) => setExtra((x) => ({ ...x, [key]: e.target.value }))}
                />
              </div>
            ))}
          </div>
        </details>
      </form>

      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">Received — Voucher #{res.vchNo}</div>
          <div className="tiles">
            <div className="tile">
              <div className="muted">vchNo</div>
              <div className="big kpi">{res.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">outstanding</div>
              <div className="big kpi">{inr(res.outstanding)}</div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
