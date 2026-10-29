'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';

/** Ledger Adjustment (desktop TR_LEDR_ADJ → LDR_ADJ_DATA + balanced AC_DATA).
 *  Books a KASAR/round-off difference against an account, contra to an adjustment account.
 *  Full lifecycle: create / reopen / edit / delete. It numbers in the Journal (JV) book family. */
export default function LedgerAdjustPage() {
  const [coBook, setCoBook] = useState('');
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
  const [loadedVch, setLoadedVch] = useState('');
  const set = (k: string, v: string) => setF((s) => ({ ...s, [k]: v }));

  function resetForm() {
    setLoadedVch('');
    setF({ acCode: '', adjAc: 'KASAR', amount: '', direction: 'debit', remark: '' });
    setRes(null);
    setMsg(null);
  }

  async function loadAdjust(vchNo: string) {
    setMsg(null);
    setRes(null);
    try {
      const d = await get<any>(
        `/ledger-adjust/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(vchNo);
      setF({
        acCode: String(d.acCode ?? ''),
        adjAc: String(d.adjAc ?? 'KASAR'),
        amount: String(d.amount ?? ''),
        direction: d.direction === 'credit' ? 'credit' : 'debit',
        remark: String(d.remark ?? ''),
      });
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.error || e.message : 'load failed',
      });
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!coBook) {
      setMsg({ kind: 'err', text: 'select the configured book first' });
      return;
    }
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
      const body = {
        coBook,
        acCode: f.acCode.trim(),
        adjAc: f.adjAc.trim() || undefined,
        amount: Number(f.amount),
        direction: f.direction === 'credit' ? 'credit' : 'debit',
        remark: f.remark.trim() || undefined,
      };
      const r = loadedVch
        ? await put<{ vchNo: number }>(`/ledger-adjust/${encodeURIComponent(loadedVch)}`, body)
        : await post<{ vchNo: number }>('/ledger-adjust', body);
      setRes(r);
      setMsg({
        kind: 'ok',
        text: `Adjustment ${loadedVch ? 'updated' : 'posted'} (voucher #${r.vchNo})`,
      });
      if (!loadedVch) setF((s) => ({ ...s, amount: '', remark: '' }));
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
          <label>Book</label>
          <BookSelect value={coBook} onChange={setCoBook} preferred="JV" mainBooks={['JOURNAL']} />
        </div>
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
          <span className="muted">Dr/Cr account ↔ {f.adjAc || 'KASAR'}</span>
          <span className="spacer" />
          {loadedVch && (
            <button type="button" onClick={resetForm} disabled={busy}>
              New
            </button>
          )}
          <button className="primary" disabled={busy || !coBook}>
            {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Post Adjustment'}
          </button>
        </div>
      </form>
      {coBook && (
        <VoucherList
          table="LDR_ADJ_DATA"
          book={coBook}
          deleteBase="/ledger-adjust"
          onLoad={(vchNo) => void loadAdjust(vchNo)}
          reloadKey={res?.vchNo}
        />
      )}
    </div>
  );
}
