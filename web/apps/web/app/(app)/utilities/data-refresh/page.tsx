'use client';
import { useState } from 'react';

interface RefreshResult {
  ranAt: string;
  ledger: { dr: number; cr: number; diff: number };
  orphanParty: number | null;
  orphanDetl: number | null;
  counts: Record<string, number | null>;
  analyzed: boolean;
  checks: { label: string; ok: boolean; detail: string }[];
}

export default function DataRefreshPage() {
  const [busy, setBusy] = useState(false);
  const [res, setRes] = useState<RefreshResult | null>(null);
  const [err, setErr] = useState('');

  async function run() {
    setBusy(true);
    setErr('');
    setRes(null);
    try {
      const r = await fetch('/api/utilities/data-refresh', {
        method: 'POST',
        credentials: 'include',
      });
      if (!r.ok) throw new Error(`HTTP ${r.status}`);
      setRes(await r.json());
    } catch (e: any) {
      setErr(e.message || 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Data Refresh</h1>
      <div className="panel">
        <p>
          Verify and refresh this company&apos;s data: re-checks the double-entry ledger balance,
          key row counts, orphan detail lines, and refreshes the database query-planner statistics.
        </p>
        <p className="muted">
          This is a safe, read-only integrity refresh. Rebuilding stored balances/stock (a
          write-back recompute) is intentionally not performed here.
        </p>
        <button className="primary" onClick={run} disabled={busy}>
          {busy ? 'Refreshing…' : 'Run Data Refresh'}
        </button>
        {err && <p className="msg err">{err}</p>}
      </div>

      {res && (
        <div className="panel">
          <h3>
            Result{' '}
            <span className="muted" style={{ fontSize: 12 }}>
              · {new Date(res.ranAt).toLocaleString()}
            </span>
          </h3>
          <table>
            <thead>
              <tr>
                <th>Check</th>
                <th>Status</th>
                <th>Detail</th>
              </tr>
            </thead>
            <tbody>
              {res.checks.map((c) => (
                <tr key={c.label}>
                  <td>{c.label}</td>
                  <td style={{ color: c.ok ? '#137333' : '#c5221f', fontWeight: 600 }}>
                    {c.ok ? 'OK' : 'CHECK'}
                  </td>
                  <td>{c.detail}</td>
                </tr>
              ))}
            </tbody>
          </table>
          <h3 style={{ marginTop: 16 }}>Row counts</h3>
          <table>
            <thead>
              <tr>
                <th>Table</th>
                <th style={{ textAlign: 'right' }}>Rows</th>
              </tr>
            </thead>
            <tbody>
              {Object.entries(res.counts).map(([t, n]) => (
                <tr key={t}>
                  <td>{t}</td>
                  <td style={{ textAlign: 'right' }}>{n == null ? '—' : n.toLocaleString()}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}
