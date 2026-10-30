'use client';
import { useState } from 'react';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';
import { todayLocal } from '../../../../lib/localDate';
import { openDocument } from '../../../../lib/openDocument';

/**
 * Dhrn Os Letter (desktop RP_DHRN_OS) — a per-party pledge OUTSTANDING statement/letter. Pick the
 * borrower and an as-of date, then open the document (HTML preview or PDF) from GET /dhrn/os-letter.
 * Stateless: it reads + computes and posts nothing.
 */
export default function DhrnOsLetterPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [asOf, setAsOf] = useState(todayLocal());
  const [err, setErr] = useState('');

  function url(format: 'html' | 'pdf') {
    const q = new URLSearchParams({
      acCode: acCode.trim(),
      asOf,
      coYear: coYear ?? '',
      lcCode: lcCode ?? '',
      format,
    });
    return `/api/dhrn/os-letter?${q.toString()}`;
  }

  function open(format: 'html' | 'pdf') {
    setErr('');
    if (!acCode.trim()) {
      setErr('pick the borrower account first');
      return;
    }
    openDocument(url(format));
  }

  return (
    <div>
      <h1>
        Dhrn Os Letter <span className="muted">— pledge outstanding statement (RP_DHRN_OS)</span>
      </h1>
      {err && <div className="msg err">{err}</div>}
      <form className="panel" onSubmit={(e) => e.preventDefault()} style={{ maxWidth: 680 }}>
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Borrower (account)</label>
            <LookupPicker
              entity="accounts"
              value={acCode}
              onChange={setAcCode}
              onPick={(r) => setAcName(String(r.name || ''))}
            />
          </div>
          <div className="field">
            <label>Borrower name</label>
            <input value={acName} readOnly />
          </div>
          <div className="field">
            <label>As on date</label>
            <input type="date" value={asOf} onChange={(e) => setAsOf(e.target.value)} />
          </div>
        </div>
        <div className="toolbar" style={{ marginTop: 10 }}>
          <span className="muted">
            Lists every open pledge with principal, repaid, outstanding, accrued interest and total
            due.
          </span>
          <span className="spacer" />
          <button type="button" className="ghost" onClick={() => open('html')}>
            Preview
          </button>
          <button type="button" className="primary" onClick={() => open('pdf')}>
            Open Letter (PDF)
          </button>
        </div>
      </form>
    </div>
  );
}
