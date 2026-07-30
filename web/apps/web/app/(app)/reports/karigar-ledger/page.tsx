'use client';
import { useState } from 'react';
import { get, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

/** Karigar Metal Ledger — per-karigar KR_DETL issue/receive movements + running fine balance, with print. */
interface Row {
  vchNo: string;
  vchDate: string | null;
  vchType: string;
  direction: string;
  itCode: string;
  netWt: number;
  issuedFine: number;
  receivedFine: number;
  balanceFine: number;
}
interface Rep {
  karigarAc: string;
  rows: Row[];
  totals: { issued: number; received: number; balanceFine: number };
}

export default function KarigarLedgerPage() {
  const [ac, setAc] = useState('');
  const [rep, setRep] = useState<Rep | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const num = (n: number) => Number(n || 0).toLocaleString('en-IN');

  async function load(code = ac) {
    if (!code.trim()) return;
    setBusy(true);
    setErr('');
    try {
      setRep(await get<Rep>(`/reports/karigar-ledger?ac=${encodeURIComponent(code.trim())}`));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Karigar Metal Ledger</h1>
      <div className="panel">
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Karigar</label>
            <LookupPicker
              entity="accounts"
              value={ac}
              onChange={setAc}
              onPick={(r) => load(String(r.code))}
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="ghost" onClick={() => load()} disabled={busy}>
              {busy ? '…' : 'Load'}
            </button>
          </div>
          {rep && (
            <div className="field" style={{ alignSelf: 'end' }}>
              <a
                className="ghost"
                href={`/api/reports/karigar-ledger.print?ac=${encodeURIComponent(ac.trim())}`}
                target="_blank"
                rel="noreferrer"
                style={{
                  padding: '6px 10px',
                  border: '1px solid var(--border,#ccc)',
                  borderRadius: 4,
                  textDecoration: 'none',
                }}
              >
                Print
              </a>
            </div>
          )}
        </div>
      </div>
      {err && <div className="msg err">{err}</div>}
      {rep && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="tiles" style={{ marginBottom: 8 }}>
            <div className="tile">
              <div className="muted">Issued Fine</div>
              <div className="big kpi">{num(rep.totals.issued)}</div>
            </div>
            <div className="tile">
              <div className="muted">Received Fine</div>
              <div className="big kpi">{num(rep.totals.received)}</div>
            </div>
            <div className="tile">
              <div className="muted">Balance Fine</div>
              <div
                className="big kpi"
                style={{ color: rep.totals.balanceFine ? 'var(--err)' : 'var(--ok)' }}
              >
                {num(rep.totals.balanceFine)}
              </div>
            </div>
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>Vch</th>
                <th>Date</th>
                <th>Type</th>
                <th>Item</th>
                <th className="num">Net Wt</th>
                <th className="num">Issued Fine</th>
                <th className="num">Received Fine</th>
                <th className="num">Balance</th>
              </tr>
            </thead>
            <tbody>
              {rep.rows.map((r, i) => (
                <tr key={i}>
                  <td>{r.vchNo}</td>
                  <td>{r.vchDate ?? ''}</td>
                  <td>{r.direction}</td>
                  <td>{r.itCode}</td>
                  <td className="num">{r.netWt || ''}</td>
                  <td className="num">{r.issuedFine || ''}</td>
                  <td className="num">{r.receivedFine || ''}</td>
                  <td className="num">{num(r.balanceFine)}</td>
                </tr>
              ))}
              {rep.rows.length === 0 && (
                <tr>
                  <td colSpan={8} className="muted">
                    No movements for this karigar.
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}
