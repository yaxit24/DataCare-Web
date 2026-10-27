'use client';
import { useCallback, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { monthStartLocal, todayLocal } from '../../../../lib/localDate';

interface Txn {
  coBook: string;
  vchNo: string;
  vchType: string;
  vchDate: string | null;
  acName: string;
  chqNo: string;
  dr: number;
  cr: number;
  amtBal: number;
  clrDate: string | null;
}
interface Data {
  bankAc: string;
  bankName: string;
  openingBal: number;
  rows: Txn[];
  book: number;
  cleared: number;
  uncleared: number;
}
const today = () => todayLocal();
const monthStart = () => monthStartLocal();

export default function BankReconPage() {
  const [bankAc, setBankAc] = useState('');
  const [from, setFrom] = useState(monthStart());
  const [to, setTo] = useState(today());
  const [data, setData] = useState<Data | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(
    async (ac: string) => {
      if (!ac.trim()) {
        setData(null);
        return;
      }
      setBusy(true);
      setMsg(null);
      try {
        const qs = new URLSearchParams({ bankAc: ac.trim() });
        if (from) qs.set('from', from);
        if (to) qs.set('to', to);
        setData(await get<Data>(`/bank-recon?${qs.toString()}`));
      } catch (e) {
        setMsg({
          kind: 'err',
          text: e instanceof ApiError ? e.body?.error || e.message : 'failed',
        });
      } finally {
        setBusy(false);
      }
    },
    [from, to],
  );

  async function toggle(t: Txn, on: boolean) {
    if (!data) return;
    try {
      await post('/bank-recon/clear', {
        bankAc: data.bankAc,
        items: [{ coBook: t.coBook, vchNo: t.vchNo, clrDate: on ? today() : null }],
      });
      await load(data.bankAc);
    } catch (e) {
      setMsg({ kind: 'err', text: e instanceof ApiError ? e.body?.error || e.message : 'failed' });
    }
  }

  const money = (n: number) =>
    Number(n || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });

  return (
    <div>
      <h1>Bank Reconciliation</h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Bank Account</label>
            <LookupPicker
              entity="accounts"
              value={bankAc}
              onChange={(v) => {
                setBankAc(v);
              }}
              onPick={(r) => load(String(r.code))}
            />
          </div>
          <div className="field">
            <label>From</label>
            <input type="date" value={from} onChange={(e) => setFrom(e.target.value)} />
          </div>
          <div className="field">
            <label>To</label>
            <input type="date" value={to} onChange={(e) => setTo(e.target.value)} />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="ghost" onClick={() => load(bankAc)} disabled={busy}>
              {busy ? 'Loading…' : 'Load'}
            </button>
          </div>
        </div>
      </div>

      {data && (
        <>
          <div className="panel">
            <div className="tiles">
              <div className="tile">
                <div className="muted">{data.bankName} · Opening</div>
                <div className="big kpi">{money(data.openingBal)}</div>
              </div>
              <div className="tile">
                <div className="muted">Book Balance</div>
                <div className="big kpi">{money(data.book)}</div>
              </div>
              <div className="tile">
                <div className="muted">Cleared</div>
                <div className="big kpi" style={{ color: 'var(--ok)' }}>
                  {money(data.cleared)}
                </div>
              </div>
              <div className="tile">
                <div className="muted">Uncleared (in transit)</div>
                <div
                  className="big kpi"
                  style={{ color: data.uncleared ? 'var(--err)' : undefined }}
                >
                  {money(data.uncleared)}
                </div>
              </div>
            </div>
          </div>
          <div className="panel" style={{ overflow: 'auto' }}>
            <h2>{data.rows.length} transaction(s)</h2>
            <table className="grid">
              <thead>
                <tr>
                  <th>Book</th>
                  <th>Vch</th>
                  <th>Type</th>
                  <th>Party</th>
                  <th>Date</th>
                  <th>Chq No</th>
                  <th className="num">Dr</th>
                  <th className="num">Cr</th>
                  <th className="num">Balance</th>
                  <th>Cleared</th>
                  <th>Clr Date</th>
                </tr>
              </thead>
              <tbody>
                <tr style={{ background: 'var(--muted-bg,#f3f4f6)' }}>
                  <td colSpan={8} style={{ textAlign: 'right', fontWeight: 600 }}>
                    Opening balance carried forward
                  </td>
                  <td className="num">
                    <b>{money(data.openingBal)}</b>
                  </td>
                  <td colSpan={2}></td>
                </tr>
                {data.rows.map((t, i) => (
                  <tr key={i}>
                    <td>{t.coBook}</td>
                    <td>{t.vchNo}</td>
                    <td>{t.vchType}</td>
                    <td>{t.acName || <span className="muted">—</span>}</td>
                    <td>{t.vchDate ?? ''}</td>
                    <td>{t.chqNo || <span className="muted">—</span>}</td>
                    <td className="num">{t.dr ? money(t.dr) : ''}</td>
                    <td className="num">{t.cr ? money(t.cr) : ''}</td>
                    <td className="num">{money(t.amtBal)}</td>
                    <td>
                      <input
                        type="checkbox"
                        checked={!!t.clrDate}
                        onChange={(e) => toggle(t, e.target.checked)}
                      />
                    </td>
                    <td>{t.clrDate ?? <span className="muted">—</span>}</td>
                  </tr>
                ))}
                {data.rows.length === 0 && (
                  <tr>
                    <td colSpan={11} className="muted">
                      No transactions in range.
                    </td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </>
      )}
    </div>
  );
}
