'use client';
import { useEffect, useMemo, useState } from 'react';

function todayLocal(): string {
  const d = new Date();
  d.setMinutes(d.getMinutes() - d.getTimezoneOffset());
  return d.toISOString().slice(0, 10);
}

function validAmount(value: string): number {
  const amount = Number(value || 0);
  return Number.isFinite(amount) ? amount : 0;
}

/**
 * Cheque Print — web operator surface for the desktop cheque print flow.
 *
 * Desktop cash/payment-style forms keep a separate `Chq Ac Name` (`CHQ_PRINT_NAME`) and then open
 * the shared `MS_PRINT` dialog. The server already renders the print-ready cheque HTML at
 * GET /finance/cheque-print; this page exposes the missing payee and A/c Payee inputs and opens that
 * exact endpoint for preview/printing.
 */
export default function ChequePrintPage() {
  const [payee, setPayee] = useState('');
  const [amount, setAmount] = useState('');
  const [date, setDate] = useState(todayLocal());
  const [chqNo, setChqNo] = useState('');
  const [acPayee, setAcPayee] = useState(true);
  const [previewHref, setPreviewHref] = useState('');
  const [message, setMessage] = useState('');

  useEffect(() => {
    const params = new URLSearchParams(window.location.search);
    const payeeParam = params.get('payee');
    const amountParam = params.get('amount');
    const dateParam = params.get('date');
    const chqNoParam = params.get('chqNo');
    const acPayeeParam = params.get('acPayee');
    if (payeeParam) setPayee(payeeParam);
    if (amountParam) setAmount(amountParam);
    if (dateParam) setDate(dateParam);
    if (chqNoParam) setChqNo(chqNoParam);
    if (acPayeeParam != null) setAcPayee(acPayeeParam === 'true' || acPayeeParam === '1');
  }, []);

  const chequeHref = useMemo(() => {
    const q = new URLSearchParams();
    q.set('payee', payee.trim());
    q.set('amount', String(validAmount(amount)));
    if (date) q.set('date', date);
    if (chqNo.trim()) q.set('chqNo', chqNo.trim());
    if (acPayee) q.set('acPayee', 'true');
    return `/api/finance/cheque-print?${q.toString()}`;
  }, [payee, amount, date, chqNo, acPayee]);

  const canRender = payee.trim().length > 0 && validAmount(amount) > 0;

  function requireInput(): boolean {
    if (canRender) {
      setMessage('');
      return true;
    }
    setMessage('Payee and a positive amount are required before preview or print.');
    return false;
  }

  function preview() {
    if (!requireInput()) return;
    setPreviewHref(chequeHref);
  }

  function openCheque(autoPrint = false) {
    if (!requireInput()) return;
    const q = chequeHref.includes('?') ? '&' : '?';
    window.open(`${chequeHref}${autoPrint ? `${q}autoPrint=true` : ''}`, '_blank');
  }

  return (
    <div>
      <h1>
        Cheque Print <span className="muted">— payee, amount and A/c Payee cheque slip</span>
      </h1>
      <p className="muted">
        Enter the cheque print name exactly as it should appear on the instrument. Preview and Print
        use the same authenticated API endpoint as voucher cheque printing:{' '}
        <code>/finance/cheque-print</code>.
      </p>

      <div className="panel">
        <div className="row">
          <div className="field" style={{ minWidth: 360 }}>
            <label>Payee / Chq Ac Name</label>
            <input
              value={payee}
              onChange={(e) => setPayee(e.target.value)}
              placeholder="name to print on cheque"
              autoFocus
            />
          </div>
          <div className="field">
            <label>Amount ₹</label>
            <input
              inputMode="decimal"
              value={amount}
              onChange={(e) => setAmount(e.target.value)}
              placeholder="0.00"
              style={{ width: 140, textAlign: 'right' }}
            />
          </div>
          <div className="field">
            <label>Date</label>
            <input type="date" value={date} onChange={(e) => setDate(e.target.value)} />
          </div>
          <div className="field">
            <label>Cheque No</label>
            <input
              value={chqNo}
              onChange={(e) => setChqNo(e.target.value)}
              style={{ width: 140 }}
            />
          </div>
          <label className="field" style={{ alignSelf: 'end', minWidth: 150 }}>
            <span>A/c Payee Only</span>
            <span>
              <input
                type="checkbox"
                checked={acPayee}
                onChange={(e) => setAcPayee(e.target.checked)}
              />{' '}
              print crossing
            </span>
          </label>
        </div>
        <div className="toolbar" style={{ marginTop: 10 }}>
          <button type="button" className="primary" onClick={preview} disabled={!canRender}>
            View Preview
          </button>
          <button
            type="button"
            className="ghost"
            onClick={() => openCheque(false)}
            disabled={!canRender}
          >
            Open View
          </button>
          <button
            type="button"
            className="ghost"
            onClick={() => openCheque(true)}
            disabled={!canRender}
          >
            Print
          </button>
          <button
            type="button"
            className="ghost"
            onClick={() => {
              setPayee('');
              setAmount('');
              setDate(todayLocal());
              setChqNo('');
              setAcPayee(true);
              setPreviewHref('');
              setMessage('');
            }}
          >
            Clear
          </button>
          <span className="spacer" />
          <span className="muted">
            {canRender ? 'Ready to preview or print' : 'Fill payee and amount'}
          </span>
        </div>
      </div>

      {message && <div className="msg err">{message}</div>}

      {previewHref && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar" style={{ justifyContent: 'space-between', marginBottom: 8 }}>
            <strong>Cheque preview</strong>
            <a className="ghost" href={previewHref} target="_blank" rel="noreferrer">
              Open printable cheque
            </a>
          </div>
          <iframe
            title="Cheque print preview"
            src={previewHref}
            style={{ width: 700, maxWidth: '100%', height: 340, border: '1px solid var(--line)' }}
          />
        </div>
      )}
    </div>
  );
}
