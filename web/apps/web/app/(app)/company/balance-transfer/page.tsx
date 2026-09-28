'use client';

import Link from 'next/link';
import { useState } from 'react';
import { ApiError, post } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

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

interface YearCloseResult {
  fromYear: string;
  toYear: string;
  accounts: number;
  carried: number;
  deleted: number;
  closingStockFine: number;
}

interface OpeningCarryResult {
  parties: number;
}

const inr = (n: number): string =>
  (Number(n) || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const wt = (n: number): string =>
  (Number(n) || 0).toLocaleString('en-IN', { minimumFractionDigits: 3, maximumFractionDigits: 3 });
const drCr = (n: number): string => `${inr(Math.abs(n))} ${n >= 0 ? 'Dr' : 'Cr'}`;
const metalOf = (t: string): string => (t === 'G' ? 'Gold' : t === 'S' ? 'Silver' : '—');
const nextYear = (y: string): string => {
  const n = Number(y);
  return Number.isFinite(n) && n > 0 ? String(n + 1) : '';
};
const errText = (e: unknown, fallback: string): string =>
  e instanceof ApiError ? e.body?.message || e.body?.error || e.message : fallback;

const relatedActions = [
  { label: 'Year-End Close', href: '/utilities/year-end', note: 'same AC_DATA opening transfer engine' },
  { label: 'Year Create', href: '/masters/year-create', note: 'financial year setup and OP_DATA carry-forward' },
  { label: 'Data Refresh', href: '/utilities/data-refresh', note: 'rebuild derived balances before/after transfer' },
  { label: 'Tag Stock', href: '/txn/stock', note: 'tag opening and stock workflows' },
  { label: 'Sales Order', href: '/txn/sales-order', note: 'open order workflow carried by order modules' },
  { label: 'Pledge / Dhiran', href: '/txn/dhrn-issue', note: 'pledge issue/receipt lifecycle' },
  { label: 'Loan Issue', href: '/txn/loan-issue', note: 'loan transfer lifecycle' },
  { label: 'MFG Issue', href: '/txn/mfg-issue', note: 'manufacturing WIP movement' },
];

export default function BalanceTransferPage() {
  const { coYear } = useBusinessScope();
  const [fromYear, setFromYear] = useState(coYear);
  const [toYear, setToYear] = useState(nextYear(coYear));
  const [preview, setPreview] = useState<PreviewResult | null>(null);
  const [yearClose, setYearClose] = useState<YearCloseResult | null>(null);
  const [openings, setOpenings] = useState<OpeningCarryResult | null>(null);
  const [busy, setBusy] = useState<'preview' | 'year-close' | 'openings' | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);

  async function runPreview() {
    if (!fromYear.trim()) {
      setMsg({ kind: 'err', text: 'From Year is required.' });
      return;
    }
    setBusy('preview');
    setMsg(null);
    setPreview(null);
    setYearClose(null);
    setOpenings(null);
    try {
      setPreview(await post<PreviewResult>('/balance-transfer/preview', { fromYear }));
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'Failed to preview transfer balances.') });
    } finally {
      setBusy(null);
    }
  }

  async function runYearClose() {
    if (!fromYear.trim() || !toYear.trim()) {
      setMsg({ kind: 'err', text: 'From Year and To Year are required.' });
      return;
    }
    if (fromYear === toYear) {
      setMsg({ kind: 'err', text: 'To Year must differ from From Year.' });
      return;
    }
    if (!preview) {
      setMsg({ kind: 'err', text: 'Preview the closing balances first.' });
      return;
    }
    const ok = window.confirm(
      `Transfer account closing balances from ${fromYear} into ${toYear}?\n\n` +
        `This rewrites the To Year opening batch for the same transfer scope.`,
    );
    if (!ok) return;
    setBusy('year-close');
    setMsg(null);
    try {
      const result = await post<YearCloseResult>('/balance-transfer/year-close', { fromYear, toYear });
      setYearClose(result);
      setMsg({
        kind: 'ok',
        text: `Transferred ${result.carried} account opening row${result.carried === 1 ? '' : 's'} into ${result.toYear}.`,
      });
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'Account balance transfer failed.') });
    } finally {
      setBusy(null);
    }
  }

  async function runOpenings() {
    if (!fromYear.trim() || !toYear.trim()) {
      setMsg({ kind: 'err', text: 'From Year and To Year are required.' });
      return;
    }
    if (fromYear === toYear) {
      setMsg({ kind: 'err', text: 'To Year must differ from From Year.' });
      return;
    }
    const ok = window.confirm(
      `Carry party openings from ${fromYear} into ${toYear}?\n\n` +
        `This replaces the To Year OP_DATA openings for this company.`,
    );
    if (!ok) return;
    setBusy('openings');
    setMsg(null);
    try {
      const result = await post<OpeningCarryResult>('/balance-transfer/openings', { fromYear, toYear });
      setOpenings(result);
      setMsg({
        kind: 'ok',
        text: `Carried ${result.parties} party opening balance${result.parties === 1 ? '' : 's'} into ${toYear}.`,
      });
    } catch (e) {
      setMsg({ kind: 'err', text: errText(e, 'Party opening carry-forward failed.') });
    } finally {
      setBusy(null);
    }
  }

  const rows = preview?.closings ?? [];

  return (
    <div>
      <h1>Balance TrFr</h1>
      <p className="muted">
        Desktop Balance TrFr opens the BtmSchm transfer console. This web surface exposes the
        production-safe carry-forward actions for account and party openings, scoped to the selected
        company/location/year session.
      </p>

      <div className="panel">
        <div className="toolbar">
          <div className="field" style={{ marginBottom: 0 }}>
            <label>From Year</label>
            <input value={fromYear} onChange={(e) => setFromYear(e.target.value)} style={{ width: 100 }} />
          </div>
          <div className="field" style={{ marginBottom: 0 }}>
            <label>To Year</label>
            <input value={toYear} onChange={(e) => setToYear(e.target.value)} style={{ width: 100 }} />
          </div>
          <button className="primary" onClick={runPreview} disabled={busy !== null}>
            {busy === 'preview' ? 'Previewing…' : 'Preview Ac Balance'}
          </button>
          <button className="ghost" onClick={runYearClose} disabled={busy !== null || !preview}>
            {busy === 'year-close' ? 'Transferring…' : 'Transfer Ac Balance'}
          </button>
          <button className="ghost" onClick={runOpenings} disabled={busy !== null}>
            {busy === 'openings' ? 'Carrying…' : 'Carry Party Openings'}
          </button>
        </div>
        <p className="muted" style={{ margin: 0 }}>
          Preview writes nothing. Transfer actions are idempotent for their target opening batch and
          require confirmation because they replace existing carry-forward rows.
        </p>
      </div>

      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      {(yearClose || openings) && (
        <div className="panel">
          <strong>Last transfer result</strong>
          <div className="tiles" style={{ marginTop: 12 }}>
            {yearClose && (
              <>
                <div className="tile"><span className="muted">Accounts carried</span><div className="big">{yearClose.carried}</div></div>
                <div className="tile"><span className="muted">Prior rows replaced</span><div className="big">{yearClose.deleted}</div></div>
                <div className="tile"><span className="muted">Closing stock fine</span><div className="big">{wt(yearClose.closingStockFine)}</div></div>
              </>
            )}
            {openings && <div className="tile"><span className="muted">Party openings carried</span><div className="big">{openings.parties}</div></div>}
          </div>
        </div>
      )}

      {preview && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar" style={{ justifyContent: 'space-between' }}>
            <strong>
              Ac Balance preview — {preview.fromYear} ({preview.accounts} account
              {preview.accounts === 1 ? '' : 's'})
            </strong>
            <span className="muted">Closing stock fine: <strong>{wt(preview.closingStockFine)}</strong></span>
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
                {rows.map((row) => (
                  <tr key={row.acCode}>
                    <td>{row.acCode}</td>
                    <td className="num">{inr(row.dr)}</td>
                    <td className="num">{inr(row.cr)}</td>
                    <td className="num">{drCr(row.balance)}</td>
                    <td>{row.sign === 'D' ? 'Dr' : 'Cr'}</td>
                    <td className="num">{row.fineWt ? wt(Math.abs(row.fineWt)) : '—'}</td>
                    <td>{metalOf(row.itType)}</td>
                  </tr>
                ))}
              </tbody>
              <tfoot>
                <tr className="totals">
                  <td>Total</td>
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

      <div className="panel">
        <strong>BtmSchm dashboard coverage</strong>
        <p className="muted">
          The desktop form also acts as a launcher for stock, order, pledge, loan, repair, lot and
          manufacturing transfer work. Those workflows remain available from their dedicated web modules.
        </p>
        <div className="tiles">
          {relatedActions.map((action) => (
            <Link key={action.href} className="tile" href={action.href}>
              <strong>{action.label}</strong>
              <div className="muted">{action.note}</div>
            </Link>
          ))}
        </div>
      </div>
    </div>
  );
}
