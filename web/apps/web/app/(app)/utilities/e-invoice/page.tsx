'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { todayLocal } from '../../../../lib/localDate';

/**
 * e-Invoice (IRN) — Phase 10 statutory.
 *
 * Lists recent sales invoices (GET /reports/sales-register) and, per row, generates an IRN by
 * POSTing { coBook, coYear, vchNo } to /einvoice/irn. The page surfaces the returned IRN / Ack No,
 * or the "ready-for-creds" message (the backend runs a deterministic Fake GSP transport until
 * GSP_ASPID/GSP_PASSWORD/GSP_GSTIN/GSP_USER/GSP_EINV_PWD are set, reported via mode==='fake').
 *
 * The sales register returns each voucher's persisted CO_BOOK. IRN, cancellation and invoice links
 * fail closed when legacy data lacks that book instead of substituting an unconfigured code.
 */

type Row = {
  vchNo: string;
  vchDate: string | null;
  billNo: string | null;
  acCode: string | null;
  party: string | null;
  netAmt: number;
  taxAmt: number;
  cgst: number;
  sgst: number;
  igst: number;
  totAmt: number;
  osAmt: number;
  coBook: string | null;
};

type Register = { rows: Row[]; totals: Partial<Record<keyof Row, number>> };

type IrnState =
  | { state: 'pending' }
  | { state: 'ok'; irn: string; ackNo: string; mode: string; message?: string }
  | { state: 'note'; mode: string; message: string }
  | { state: 'err'; error: string };

const inr = (n: number): string =>
  (Number(n) || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });

function fmtDate(d: string | null): string {
  if (!d) return '—';
  const dt = new Date(d);
  return isNaN(dt.getTime()) ? String(d) : dt.toLocaleDateString('en-IN');
}

const bookOf = (row: Row): string => String(row.coBook ?? '').trim();
const keyOf = (row: Row): string => `${bookOf(row) || 'missing-book'}/${row.vchNo}`;
const todayIso = (): string => todayLocal();

export default function EInvoicePage() {
  const { coYear } = useBusinessScope();
  const [fromDate, setFromDate] = useState(todayIso);
  const [toDate, setToDate] = useState(todayIso);
  const [reg, setReg] = useState<Register | null>(null);
  const [loading, setLoading] = useState(false);
  const [err, setErr] = useState('');
  const [provider, setProvider] = useState<{ provider?: string; status?: string } | null>(null);
  // Per-voucher IRN generation state, keyed by vchNo.
  const [results, setResults] = useState<Record<string, IrnState>>({});
  // GSP credential configuration status + connection-test result.
  const [gsp, setGsp] = useState<{
    mode: string;
    provider: string;
    host: string;
    sandbox: boolean;
    configured: boolean;
    vars: Record<string, boolean>;
    gstin: string | null;
  } | null>(null);
  const [gspTest, setGspTest] = useState<{ ok: boolean; detail: string } | null>(null);
  const [testing, setTesting] = useState(false);

  async function testConnection() {
    setTesting(true);
    setGspTest(null);
    try {
      const r = await post<{ ok: boolean; mode: string; detail: string }>('/einvoice/gsp-test', {});
      setGspTest({ ok: r.ok, detail: r.detail });
    } catch (e) {
      setGspTest({
        ok: false,
        detail: e instanceof ApiError ? e.body?.error || e.message : 'test failed',
      });
    } finally {
      setTesting(false);
    }
  }

  async function cancelIrn(row: Row) {
    const key = keyOf(row);
    const coBook = bookOf(row);
    if (!coBook) {
      setResults((current) => ({
        ...current,
        [key]: { state: 'err', error: 'Voucher has no persisted book code' },
      }));
      return;
    }
    if (!window.confirm(`Cancel the IRN for voucher #${row.vchNo}? (NIC allows cancel within 24h)`))
      return;
    setResults((m) => ({ ...m, [key]: { state: 'pending' } }));
    try {
      await post(`/einvoice/${encodeURIComponent(row.vchNo)}/cancel`, {
        coBook,
        reason: '3',
        remark: 'Cancelled from ERP',
      });
      setResults((m) => {
        const c = { ...m };
        delete c[key];
        return c;
      });
    } catch (e) {
      setResults((m) => ({
        ...m,
        [key]: {
          state: 'err',
          error:
            e instanceof ApiError ? e.body?.detail || e.body?.error || e.message : 'cancel failed',
        },
      }));
    }
  }

  const load = useCallback(async (yr: string, from: string, to: string) => {
    if (!yr) return;
    setLoading(true);
    setErr('');
    setReg(null);
    setResults({});
    try {
      const qs = new URLSearchParams({ coYear: yr });
      if (from) qs.set('fromDate', from);
      if (to) qs.set('toDate', to);
      setReg(await get<Register>(`/reports/sales-register?${qs.toString()}`));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'Failed to load sales register');
    } finally {
      setLoading(false);
    }
  }, []);

  // Load the current scoped register plus provider status and GSP configuration.
  useEffect(() => {
    load(coYear, fromDate, toDate);
    get('/integrations/status')
      .then((s: any) => setProvider(s?.einvoice ?? null))
      .catch(() => {});
    get('/einvoice/gsp-config')
      .then((c: any) => setGsp(c ?? null))
      .catch(() => {});
  }, [coYear, fromDate, toDate, load]);

  async function generate(row: Row) {
    const vchNo = row.vchNo;
    const key = keyOf(row);
    const coBook = bookOf(row);
    if (!coBook) {
      setResults((current) => ({
        ...current,
        [key]: { state: 'err', error: 'Voucher has no persisted book code' },
      }));
      return;
    }
    setResults((m) => ({ ...m, [key]: { state: 'pending' } }));
    try {
      const res: any = await post('/einvoice/irn', {
        coBook,
        coYear,
        vchNo,
      });
      const irn = String(res?.irn ?? res?.Irn ?? '');
      const ackNo = String(res?.ackNo ?? res?.AckNo ?? '');
      const mode = String(res?.mode ?? '');
      const message = String(res?.message ?? res?.note ?? '');
      if (irn) {
        setResults((m) => ({ ...m, [key]: { state: 'ok', irn, ackNo, mode, message } }));
      } else {
        // No IRN returned — treat as a ready-for-creds / informational response.
        setResults((m) => ({
          ...m,
          [key]: { state: 'note', mode, message: message || JSON.stringify(res) },
        }));
      }
    } catch (e) {
      let msg: string;
      if (e instanceof ApiError) {
        msg =
          e.status === 404
            ? 'Endpoint /einvoice/irn is not wired yet (pending coordinator).'
            : e.body?.error || e.message || `Request failed (${e.status})`;
      } else {
        msg = 'Request failed';
      }
      setResults((m) => ({ ...m, [key]: { state: 'err', error: msg } }));
    }
  }

  function renderStatus(row: Row) {
    const r = results[keyOf(row)];
    if (!r) return <span className="muted">Not generated</span>;
    if (r.state === 'pending') return <span className="muted">Generating…</span>;
    if (r.state === 'err') return <span style={{ color: 'var(--err)' }}>{r.error}</span>;
    if (r.state === 'note') {
      return (
        <span>
          {r.mode && <strong>{r.mode}</strong>} {r.message}
        </span>
      );
    }
    // ok
    const fake = r.mode === 'fake';
    return (
      <span style={{ color: 'var(--ok)' }}>
        <code title={r.irn} style={{ fontSize: 11 }}>
          {r.irn.length > 20 ? `${r.irn.slice(0, 20)}…` : r.irn}
        </code>
        {r.ackNo && <span className="muted"> · Ack {r.ackNo}</span>}
        {r.mode && (
          <span className="muted">
            {' '}
            · {fake ? 'wired (Fake) — set GSP creds to go live' : `live (${r.mode})`}
          </span>
        )}
      </span>
    );
  }

  const rows = reg?.rows ?? [];
  const totals = reg?.totals;
  const exportUrl = `/api/einvoice/export.xlsx?${new URLSearchParams({
    ...(fromDate ? { fromDate } : {}),
    ...(toDate ? { toDate } : {}),
  }).toString()}`;

  return (
    <div>
      <h1>e-Invoice (IRN)</h1>

      <div className="panel">
        <div className="toolbar">
          <div className="field" style={{ marginBottom: 0 }}>
            <label>Year</label>
            <input value={coYear} readOnly style={{ width: 90 }} />
          </div>
          <div className="field" style={{ marginBottom: 0 }}>
            <label>From</label>
            <input
              type="date"
              value={fromDate}
              onChange={(e) => setFromDate(e.target.value)}
              style={{ width: 150 }}
            />
          </div>
          <div className="field" style={{ marginBottom: 0 }}>
            <label>To</label>
            <input
              type="date"
              value={toDate}
              onChange={(e) => setToDate(e.target.value)}
              style={{ width: 150 }}
            />
          </div>
          <button
            className="primary"
            onClick={() => load(coYear, fromDate, toDate)}
            disabled={loading}
          >
            {loading ? 'Loading…' : 'Load Invoices'}
          </button>
          <a className="button ghost" href={exportUrl}>
            E-Excel
          </a>
          <span className="spacer" style={{ flex: 1 }} />
          {provider && (
            <span className="muted">
              {provider.provider}
              {provider.status ? ` — ${provider.status}` : ''}
            </span>
          )}
        </div>
        <p className="muted" style={{ margin: 0 }}>
          B2B sales invoices below can be registered with the IRP to obtain an IRN &amp; Ack No.
          Generation runs against the configured GSP; until live GSP credentials are set the backend
          returns a deterministic placeholder IRN (mode <code>fake</code>).
        </p>
      </div>

      {err && <div className="msg err">{err}</div>}

      {gsp && (
        <div className="panel">
          <div className="toolbar">
            <h2 style={{ margin: 0 }}>GSP Credentials</h2>
            <span
              className={`badge ${gsp.configured ? 'ok' : ''}`}
              style={{ marginLeft: 8, color: gsp.configured ? 'var(--ok)' : 'var(--err)' }}
            >
              {gsp.configured ? `LIVE · ${gsp.mode}` : 'NOT CONFIGURED (fake mode)'}
            </span>
            <span className="spacer" style={{ flex: 1 }} />
            <button className="ghost" onClick={testConnection} disabled={testing}>
              {testing ? 'Testing…' : 'Test Connection'}
            </button>
          </div>
          <div className="row" style={{ gap: 16, flexWrap: 'wrap' }}>
            <span className="muted">
              Provider: <strong>{gsp.provider}</strong>
            </span>
            <span className="muted">
              Host: <code>{gsp.host}</code> ({gsp.sandbox ? 'sandbox' : 'production'})
            </span>
            {gsp.gstin && (
              <span className="muted">
                GSTIN: <code>{gsp.gstin}</code>
              </span>
            )}
          </div>
          <div className="row" style={{ gap: 12, flexWrap: 'wrap', marginTop: 6 }}>
            {Object.entries(gsp.vars).map(([k, v]) => (
              <span key={k} className="muted" style={{ fontSize: 12 }}>
                {v ? '✅' : '⬜'} <code>{k}</code>
              </span>
            ))}
          </div>
          {gspTest && (
            <div className={`msg ${gspTest.ok ? 'ok' : 'err'}`} style={{ marginTop: 8 }}>
              {gspTest.detail}
            </div>
          )}
          {!gsp.configured && (
            <p className="muted" style={{ margin: '8px 0 0' }}>
              To go live, set these in the API environment and restart: <code>GSP_ASPID</code>,{' '}
              <code>GSP_PASSWORD</code>, <code>GSP_GSTIN</code>, <code>GSP_USER</code>,{' '}
              <code>GSP_EINV_PWD</code> (and <code>GSP_SANDBOX=0</code> for production). Credentials
              are read from the environment only — never stored in the database.
            </p>
          )}
        </div>
      )}

      <div className="panel" style={{ overflow: 'auto' }}>
        {loading ? (
          <span className="muted">Loading sales register…</span>
        ) : rows.length === 0 ? (
          <span className="muted">No sales invoices for {coYear || '—'}.</span>
        ) : (
          <table className="grid">
            <thead>
              <tr>
                <th>Voucher</th>
                <th>Date</th>
                <th>Bill No</th>
                <th>Party</th>
                <th className="num">Amount</th>
                <th>IRN / Status</th>
                <th>Action</th>
                <th>Invoice</th>
              </tr>
            </thead>
            <tbody>
              {rows.map((row) => {
                const r = results[keyOf(row)];
                const pending = r?.state === 'pending';
                const done = r?.state === 'ok';
                const book = bookOf(row);
                const pdfUrl = book
                  ? `/api/sales/invoice?coBook=${encodeURIComponent(book)}&coYear=${encodeURIComponent(
                      coYear,
                    )}&vchNo=${encodeURIComponent(row.vchNo)}`
                  : '';
                return (
                  <tr key={keyOf(row)}>
                    <td>{row.vchNo}</td>
                    <td>{fmtDate(row.vchDate)}</td>
                    <td>{row.billNo ?? '—'}</td>
                    <td>{row.party ?? row.acCode ?? '—'}</td>
                    <td className="num">{inr(row.totAmt)}</td>
                    <td>{renderStatus(row)}</td>
                    <td>
                      <button
                        className={done ? 'ghost' : 'primary'}
                        onClick={() => generate(row)}
                        disabled={pending || !book}
                        title={!book ? 'Voucher has no persisted book code' : undefined}
                      >
                        {pending ? 'Generating…' : done ? 'Re-generate IRN' : 'Generate IRN'}
                      </button>
                      {done && (
                        <button
                          className="danger"
                          style={{ marginLeft: 6 }}
                          onClick={() => cancelIrn(row)}
                          disabled={pending || !book}
                          title={!book ? 'Voucher has no persisted book code' : undefined}
                        >
                          Cancel IRN
                        </button>
                      )}
                    </td>
                    <td>
                      {book ? (
                        <a href={pdfUrl} target="_blank" rel="noopener noreferrer">
                          PDF
                        </a>
                      ) : (
                        <span className="muted">No book</span>
                      )}
                    </td>
                  </tr>
                );
              })}
            </tbody>
            {totals && (
              <tfoot>
                <tr className="totals">
                  <td colSpan={4}>Total ({rows.length} invoices)</td>
                  <td className="num">{inr(totals.totAmt ?? 0)}</td>
                  <td colSpan={3} />
                </tr>
              </tfoot>
            )}
          </table>
        )}
      </div>
    </div>
  );
}
