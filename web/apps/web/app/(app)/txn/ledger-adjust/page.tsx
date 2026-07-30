'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

/** Ledger Adjustment (desktop TR_LEDR_ADJ → LDR_ADJ_DATA + balanced AC_DATA).
 *  Books a KASAR/round-off difference against an account, contra to an adjustment account. */
export default function LedgerAdjustPage() {
  const [f, setF] = useState({
    acCode: '',
    adjAc: 'KASAR',
    amount: '',
    direction: 'debit',
    remark: '',
  });
  const [res, setRes] = useState<{ vchNo: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (k: string, v: string) => setF((s) => ({ ...s, [k]: v }));

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!f.acCode.trim()) {
      setMsg({ kind: 'err', text: 'account is required' });
      return;
    }
    if (!(Number(f.amount) > 0)) {
      setMsg({ kind: 'err', text: 'amount must be positive' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<{ vchNo: number }>('/ledger-adjust', {
        acCode: f.acCode.trim(),
        adjAc: f.adjAc.trim() || undefined,
        amount: Number(f.amount),
        direction: f.direction === 'credit' ? 'credit' : 'debit',
        remark: f.remark.trim() || undefined,
      });
      setRes(r);
      setMsg({ kind: 'ok', text: `Adjustment posted (voucher #${r.vchNo})` });
      setF((s) => ({ ...s, amount: '', remark: '' }));
    } catch (err) {
      setMsg({
        kind: 'err',
        text: err instanceof ApiError ? err.body?.message || err.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Ledger Adjustment <span className="muted">— TR_LEDR_ADJ</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form className="panel" onSubmit={submit} style={{ maxWidth: 640 }}>
        <div className="field">
          <label>Account to adjust</label>
          <LookupPicker entity="accounts" value={f.acCode} onChange={(v) => set('acCode', v)} />
        </div>
        <div className="row">
          <div className="field">
            <label>Adjustment / KASAR account</label>
            <input value={f.adjAc} onChange={(e) => set('adjAc', e.target.value)} />
          </div>
          <div className="field">
            <label>Direction</label>
            <select value={f.direction} onChange={(e) => set('direction', e.target.value)}>
              <option value="debit">Debit the account</option>
              <option value="credit">Credit the account</option>
            </select>
          </div>
          <div className="field">
            <label>Amount ₹</label>
            <input value={f.amount} onChange={(e) => set('amount', e.target.value)} required />
          </div>
        </div>
        <div className="field">
          <label>Remark</label>
          <input
            value={f.remark}
            onChange={(e) => set('remark', e.target.value)}
            placeholder="reason for the adjustment"
          />
        </div>
        <div className="toolbar" style={{ marginTop: 10 }}>
          <span className="muted">POST /ledger-adjust · Dr/Cr account ↔ {f.adjAc || 'KASAR'}</span>
          <span className="spacer" />
          <button className="primary" disabled={busy}>
            {busy ? 'Posting…' : 'Post Adjustment'}
          </button>
        </div>
        {res && (
          <div className="tiles" style={{ marginTop: 10 }}>
            <div className="tile">
              <div className="muted">voucher</div>
              <div className="big kpi">#{res.vchNo}</div>
            </div>
          </div>
        )}
      </form>
    </div>
  );
}
