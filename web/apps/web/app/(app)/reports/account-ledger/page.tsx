'use client';
import { useRouter } from 'next/navigation';
import { useEffect, useRef } from 'react';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useAccountLedger } from './useAccountLedger';
import { AccountLedgerGrid } from './AccountLedgerGrid';
import type { AccountLedgerView } from './types';

/**
 * Account Ledger report — the desktop RP_LEDR screen (Lite "Ledger Report" menu). A dedicated static route
 * so it takes precedence over the generic `[report]` page, which cannot grow and cannot express RP_LEDR's
 * account summary, voucher/detail drill-down and debit ageing.
 *
 * Keyboard (desktop parity, RP_LEDR.cs:5998-6095): Enter moves through the selectors and runs; F1 opens
 * the account lookup (owned by LookupPicker); Esc leaves a drill-down back to the summary, or the screen.
 * The only `button.primary` is Run (the surface crawl presses it); Print/Excel/CSV are ghost buttons that
 * act only after a successful run.
 */
const VIEWS: Array<{ value: AccountLedgerView; label: string }> = [
  { value: 'summary', label: 'Account Summary' },
  { value: 'detail', label: 'Ledger Detail' },
  { value: 'voucher-summary', label: 'Voucher Summary' },
  { value: 'ageing', label: 'Debit Ageing' },
];

const money = (n: number): string =>
  Number(n || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const wt = (n: number): string =>
  Number(n || 0).toLocaleString('en-IN', { minimumFractionDigits: 3, maximumFractionDigits: 3 });

export default function AccountLedgerPage() {
  const router = useRouter();
  const l = useAccountLedger();
  const { filters, setFilters, result, error, busy, message } = l;
  const needsAccount = filters.view === 'detail' || filters.view === 'voucher-summary';

  // Esc (desktop RP_LEDR.cs:5998-6095): from a drill-down return to the account summary; from the summary
  // leave the screen. A document listener so it works regardless of which control holds focus, matching the
  // desktop form-level key handler. A ref keeps the latest result/run without re-binding the listener.
  const escState = useRef({ result, run: l.run, back: router.back });
  escState.current = { result, run: l.run, back: router.back };
  useEffect(() => {
    const onKey = (e: KeyboardEvent) => {
      if (e.key !== 'Escape' || e.defaultPrevented) return;
      // A lookup/dialog open marks itself; let it handle its own Esc first.
      if (document.querySelector('[data-lookup-open]')) return;
      const { result: r, run, back } = escState.current;
      if (r && (r.view === 'detail' || r.view === 'voucher-summary')) {
        e.preventDefault();
        void run({ view: 'summary', acCode: '' });
      } else {
        back();
      }
    };
    document.addEventListener('keydown', onKey);
    return () => document.removeEventListener('keydown', onKey);
  }, []);

  return (
    <div>
      <h1>Ledger Report</h1>
      <div className="panel">
        <div className="row">
          <div className="field">
            <label htmlFor="al-view">Report</label>
            <select
              id="al-view"
              value={filters.view}
              onChange={(e) => setFilters({ view: e.target.value as AccountLedgerView })}
            >
              {VIEWS.map((v) => (
                <option key={v.value} value={v.value}>
                  {v.label}
                </option>
              ))}
            </select>
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label>Account{needsAccount ? ' *' : ''}</label>
            <LookupPicker
              entity="accounts"
              value={filters.acCode}
              ariaLabel="Account"
              resolveTypedCode
              onChange={(v) => setFilters({ acCode: v })}
              onPick={(r) => setFilters({ acCode: String(r.code) })}
            />
          </div>
          <div className="field">
            <label htmlFor="al-from">From</label>
            <input
              id="al-from"
              type="date"
              value={filters.fromDate}
              onChange={(e) => setFilters({ fromDate: e.target.value })}
            />
          </div>
          <div className="field">
            <label htmlFor="al-to">To</label>
            <input
              id="al-to"
              type="date"
              value={filters.toDate}
              onChange={(e) => setFilters({ toDate: e.target.value })}
              onKeyDown={(e) => {
                if (e.key === 'Enter') void l.run();
              }}
            />
          </div>
          {filters.view === 'ageing' && (
            <div className="field">
              <label htmlFor="al-fine">Fine</label>
              <select
                id="al-fine"
                value={filters.fineType}
                onChange={(e) => setFilters({ fineType: e.target.value as 'G' | 'S' })}
              >
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
          )}
          {filters.view === 'summary' && (
            <div className="field" style={{ alignSelf: 'end' }}>
              <label>
                <input
                  type="checkbox"
                  checked={filters.withZero}
                  onChange={(e) => setFilters({ withZero: e.target.checked })}
                />{' '}
                With Zero
              </label>
            </div>
          )}
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="primary" onClick={() => void l.run()} disabled={busy}>
              {busy ? 'Running…' : 'Run'}
            </button>
          </div>
        </div>
        {result && (
          <div className="row" style={{ marginTop: 8 }}>
            <button type="button" className="ghost" onClick={l.print} disabled={!l.ranQuery}>
              Print
            </button>
            <button
              type="button"
              className="ghost"
              onClick={() => void l.pdf()}
              disabled={!l.ranQuery}
            >
              Download PDF
            </button>
            <button type="button" className="ghost" onClick={l.excel} disabled={!l.ranQuery}>
              Excel
            </button>
            <button type="button" className="ghost" onClick={l.csv} disabled={!l.ranQuery}>
              CSV
            </button>
          </div>
        )}
      </div>

      {error && (
        <div className="msg err" role="alert" data-testid="ledger-error">
          {error}
        </div>
      )}
      {!error && message && (
        <div className="msg" role="status">
          {message}
        </div>
      )}

      {result && result.account && (
        <div className="panel">
          <strong>{result.account.acName ?? result.account.acCode}</strong>
          {result.account.city ? ` — ${result.account.city}` : ''}
          <div className="tiles" style={{ marginTop: 8 }}>
            <div className="tile">
              <div className="muted">Opening Amt</div>
              <div className="big kpi">{money(result.opening.amount)}</div>
            </div>
            <div className="tile">
              <div className="muted">Closing Amt</div>
              <div className="big kpi">{money(result.closing.amount)}</div>
            </div>
            <div className="tile">
              <div className="muted">Closing Gold</div>
              <div className="big kpi">{wt(result.closing.goldFine)}</div>
            </div>
            <div className="tile">
              <div className="muted">Closing Silver</div>
              <div className="big kpi">{wt(result.closing.silverFine)}</div>
            </div>
          </div>
        </div>
      )}

      {result && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <AccountLedgerGrid result={result} onOpenAccount={(ac) => void l.openVoucherDetail(ac)} />
        </div>
      )}
    </div>
  );
}
