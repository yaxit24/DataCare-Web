'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, ApiError } from '../../../../lib/api';

interface VoucherRow {
  date: string | null;
  book: string | null;
  voucher: string;
  type: string | null;
  debit: number;
  credit: number;
  legs: number;
}
interface VoucherReport {
  rows: VoucherRow[];
  totals: { vouchers: number; debit: number; credit: number };
}

const fmtAmt = (n: number): string =>
  Number(n ?? 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
const fmtInt = (n: number): string => Number(n ?? 0).toLocaleString('en-IN');
/** API serialises VCH_DATE (a SQL date) as an ISO string — show just the YYYY-MM-DD part. */
const fmtDate = (d: string | null): string => (d ? String(d).slice(0, 10) : '\u2014');

export default function VoucherRegisterPage() {
  const [book, setBook] = useState('');
  const [fromDate, setFromDate] = useState('');
  const [toDate, setToDate] = useState('');
  const [data, setData] = useState<VoucherReport | null>(null);
  const [err, setErr] = useState('');
  const [loading, setLoading] = useState(false);

  const load = useCallback(async () => {
    setErr('');
    setLoading(true);
    const qs = new URLSearchParams();
    if (book.trim()) qs.set('book', book.trim());
    if (fromDate) qs.set('fromDate', fromDate);
    if (toDate) qs.set('toDate', toDate);
    const q = qs.toString();
    try {
      setData(await get<VoucherReport>(`/reports/voucher-register${q ? `?${q}` : ''}`));
    } catch (e) {
      setData(null);
      setErr(
        e instanceof ApiError ? e.body?.error || e.message : 'Failed to load voucher register',
      );
    } finally {
      setLoading(false);
    }
  }, [book, fromDate, toDate]);

  // Initial load + re-fetch whenever a date filter changes (Book applies via the button / Enter).
  useEffect(() => {
    load();
  }, [fromDate, toDate]); // eslint-disable-line react-hooks/exhaustive-deps

  const rows = data?.rows ?? [];
  const totals = data?.totals;

  return (
    <div>
      <h1>Voucher Register</h1>

      <div className="toolbar">
        <div className="field" style={{ marginBottom: 0 }}>
          <label>Book</label>
          <input
            value={book}
            placeholder="All books"
            onChange={(e) => setBook(e.target.value)}
            onKeyDown={(e) => {
              if (e.key === 'Enter') load();
            }}
            style={{ width: 120 }}
          />
        </div>
        <div className="field" style={{ marginBottom: 0 }}>
          <label>From date</label>
          <input type="date" value={fromDate} onChange={(e) => setFromDate(e.target.value)} />
        </div>
        <div className="field" style={{ marginBottom: 0 }}>
          <label>To date</label>
          <input type="date" value={toDate} onChange={(e) => setToDate(e.target.value)} />
        </div>
        <button className="primary" onClick={load} disabled={loading}>
          {loading ? 'Loading\u2026' : 'Apply'}
        </button>
      </div>

      {err && <div className="msg err">{err}</div>}

      {totals && (
        <div className="panel">
          <div className="tiles">
            <div className="tile">
              <div className="muted">Vouchers</div>
              <div className="big kpi">{fmtInt(totals.vouchers)}</div>
            </div>
            <div className="tile">
              <div className="muted">Debit</div>
              <div className="big kpi">{fmtAmt(totals.debit)}</div>
            </div>
            <div className="tile">
              <div className="muted">Credit</div>
              <div className="big kpi">{fmtAmt(totals.credit)}</div>
            </div>
          </div>
        </div>
      )}

      <div className="panel" style={{ overflow: 'auto' }}>
        {rows.length === 0 ? (
          <p className="muted">
            {loading ? 'Loading\u2026' : 'No vouchers for the selected filters.'}
          </p>
        ) : (
          <table className="grid">
            <thead>
              <tr>
                <th>date</th>
                <th>book</th>
                <th>voucher</th>
                <th>type</th>
                <th className="num">debit</th>
                <th className="num">credit</th>
                <th className="num">legs</th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, idx) => (
                <tr key={`${r.book}-${r.voucher}-${r.type}-${idx}`}>
                  <td>{fmtDate(r.date)}</td>
                  <td>{r.book ?? '\u2014'}</td>
                  <td>{r.voucher}</td>
                  <td>{r.type ?? '\u2014'}</td>
                  <td className="num">{fmtAmt(r.debit)}</td>
                  <td className="num">{fmtAmt(r.credit)}</td>
                  <td className="num">{fmtInt(r.legs)}</td>
                </tr>
              ))}
            </tbody>
          </table>
        )}
      </div>

      {rows.length === 500 && (
        <p className="muted" style={{ marginTop: 8 }}>
          Showing the 500 most recent vouchers. Narrow the date range or book to see more.
        </p>
      )}
    </div>
  );
}
