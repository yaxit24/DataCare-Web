'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

/**
 * Year-End Close (Phase 12 / UT) — desktop Ac_Final.cs parity.
 *
 * Preview computes each account's closing balance (ΣDr − ΣCr) for the From Year plus the net
 * closing-stock fine (read-only, POST /year-end/preview). Carry-forward writes one opening leg
 * (VCH_TYPE 'ACOP', CO_BOOK '000') per account into the To Year (POST /year-end/close); it is
 * idempotent (replaces any prior opening) and guarded by a confirm. Scope (company / year /
 * location) is taken from the session on the server — the page only sends the From / To years.
 */

interface AccountClosing {
  acCode: string;
  dr: number;
  cr: number;
  balance: number;
  fineWt: number;
  itType: string;
  sign: 'D' | 'C';
}

interface PreviewResult {
  fromYear: string;
  accounts: number;
  closings: AccountClosing[];
  totals: { dr: number; cr: number; balance: number };
  closingStockFine: number;
}

interface CloseResult {
  fromYear: string;
  toYear: string;
  accounts: number;
  carried: number;
  deleted: number;
  closingStockFine: number;
}

const inr = (n: number): string =>
  (Number(n) || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const wt = (n: number): string =>
  (Number(n) || 0).toLocaleString('en-IN', { minimumFractionDigits: 3, maximumFractionDigits: 3 });
const metalOf = (t: string): string => (t === 'G' ? 'Gold' : t === 'S' ? 'Silver' : '—');
const drCr = (bal: number): string => `${inr(Math.abs(bal))} ${bal >= 0 ? 'Dr' : 'Cr'}`;
const nextYear = (y: string): string => {
  const n = Number(y);
  return Number.isFinite(n) && n > 0 ? String(n + 1) : '';
};
const apiErr = (e: unknown, fallback: string): string =>
  e instanceof ApiError ? e.body?.error || e.body?.message || e.message : fallback;

export default function YearEndPage() {
  const { coYear } = useBusinessScope();
  const [fromYear, setFromYear] = useState(coYear);
  const [toYear, setToYear] = useState(nextYear(coYear));
  const [preview, setPreview] = useState<PreviewResult | null>(null);
  const [result, setResult] = useState<CloseResult | null>(null);
  const [loadingPreview, setLoadingPreview] = useState(false);
  const [loadingClose, setLoadingClose] = useState(false);
  const [err, setErr] = useState('');

  async function runPreview() {
    if (!fromYear) return;
    setLoadingPreview(true);
    setErr('');
    setResult(null);
    setPreview(null);
    try {
      setPreview(await post<PreviewResult>('/year-end/preview', { fromYear }));
    } catch (e) {
      setErr(apiErr(e, 'Failed to compute closing balances'));
    } finally {
      setLoadingPreview(false);
    }
  }

  async function runClose() {
    if (!fromYear || !toYear) return;
    if (fromYear === toYear) {
      setErr('To Year must differ from From Year.');
      return;
    }
    const ok = window.confirm(
      `Carry forward closing balances from ${fromYear} into ${toYear}?\n\n` +
        `This writes one opening leg (VCH_TYPE ACOP, book 000) per account into ${toYear} and ` +
        `REPLACES any existing ${toYear} opening. Safe to re-run.`,
    );
    if (!ok) return;
    setLoadingClose(true);
    setErr('');
    try {
      setResult(await post<CloseResult>('/year-end/close', { fromYear, toYear }));
    } catch (e) {
      setErr(apiErr(e, 'Carry-forward failed'));
    } finally {
      setLoadingClose(false);
    }
  }

  const rows = preview?.closings ?? [];

  return (
    <div>
      <h1>Year-End Close</h1>
      <p className="muted">
        Compute each account&apos;s closing balance (ΣDr − ΣCr) for the From Year and carry it
        forward as the opening balance of the To Year. Mirrors the desktop final-accounts close
        (Trading_Stock + AcBalInsert).
      </p>

      <div className="panel">
        <div className="toolbar">
          <div className="field" style={{ marginBottom: 0 }}>
            <label>From Year</label>
            <input
              value={fromYear}
              onChange={(e) => setFromYear(e.target.value)}
              style={{ width: 90 }}
            />
          </div>
          <div className="field" style={{ marginBottom: 0 }}>
            <label>To Year</label>
            <input
              value={toYear}
              onChange={(e) => setToYear(e.target.value)}
              style={{ width: 90 }}
            />
          </div>
          <button className="primary" onClick={runPreview} disabled={loadingPreview || !fromYear}>
            {loadingPreview ? 'Computing…' : 'Preview Closing Balances'}
          </button>
          <button
            className="ghost"
            onClick={runClose}
            disabled={loadingClose || !preview || !fromYear || !toYear}
            title={!preview ? 'Preview the closing balances first' : ''}
          >
            {loadingClose ? 'Carrying…' : `Carry Forward to ${toYear || '…'}`}
          </button>
        </div>
        <p className="muted" style={{ margin: 0 }}>
          Preview is read-only. Carry-forward writes opening legs (VCH_TYPE <code>ACOP</code>,
          CO_BOOK <code>000</code>) into the To Year and is safe to re-run — it replaces the prior
          carry.
        </p>
      </div>

      {err && <div className="msg err">{err}</div>}

      {result && (
        <div className="msg ok">
          Carried forward {result.carried} account{result.carried === 1 ? '' : 's'} into{' '}
          {result.toYear}
          {result.deleted > 0
            ? ` (replaced ${result.deleted} prior opening row${result.deleted === 1 ? '' : 's'})`
            : ''}
          . Closing stock fine: <strong>{wt(result.closingStockFine)}</strong>.
        </div>
      )}

      {preview && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar" style={{ justifyContent: 'space-between' }}>
            <strong>
              Closing balances — {preview.fromYear} ({preview.accounts} account
              {preview.accounts === 1 ? '' : 's'})
            </strong>
            <span className="muted">
              Closing stock fine: <strong>{wt(preview.closingStockFine)}</strong>
            </span>
          </div>
          {rows.length === 0 ? (
            <span className="muted">No non-zero account balances for {preview.fromYear}.</span>
          ) : (
            <table className="grid">
              <thead>
                <tr>
                  <th>Account</th>
                  <th className="num">Debit</th>
                  <th className="num">Credit</th>
                  <th className="num">Balance</th>
                  <th>Opens</th>
                  <th className="num">Fine Wt</th>
                  <th>Metal</th>
                </tr>
              </thead>
              <tbody>
                {rows.map((c) => (
                  <tr key={c.acCode}>
                    <td>{c.acCode}</td>
                    <td className="num">{inr(c.dr)}</td>
                    <td className="num">{inr(c.cr)}</td>
                    <td className="num">{drCr(c.balance)}</td>
                    <td>{c.sign === 'D' ? 'Dr' : 'Cr'}</td>
                    <td className="num">{c.fineWt ? wt(Math.abs(c.fineWt)) : '—'}</td>
                    <td>{metalOf(c.itType)}</td>
                  </tr>
                ))}
              </tbody>
              <tfoot>
                <tr className="totals">
                  <td>Total ({rows.length})</td>
                  <td className="num">{inr(preview.totals.dr)}</td>
                  <td className="num">{inr(preview.totals.cr)}</td>
                  <td className="num">{drCr(preview.totals.balance)}</td>
                  <td colSpan={3} />
                </tr>
              </tfoot>
            </table>
          )}
        </div>
      )}
    </div>
  );
}
