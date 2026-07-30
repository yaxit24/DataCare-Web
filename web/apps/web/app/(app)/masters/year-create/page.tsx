'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';

/** Year Create (YEAR_MAST): create a financial year, close/reopen it, and carry the prior year's
 *  closing party balances forward as the new year's opening (OP_DATA). */
interface Year {
  coYear: string;
  opDate: string | null;
  clDate: string | null;
  yearMonth: string;
  closed: boolean;
}

export default function YearCreatePage() {
  const [years, setYears] = useState<Year[]>([]);
  const [coYear, setCoYear] = useState('');
  const [opDate, setOpDate] = useState('');
  const [yearMonth, setYearMonth] = useState('4');
  const [cf, setCf] = useState({ fromYear: '', toYear: '' });
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async () => {
    try {
      setYears(await get<Year[]>('/years'));
    } catch (e) {
      setMsg({ kind: 'err', text: e instanceof ApiError ? e.body?.error || e.message : 'failed' });
    }
  }, []);
  useEffect(() => {
    void load();
  }, [load]);

  async function act(fn: () => Promise<any>, ok: string) {
    setBusy(true);
    setMsg(null);
    try {
      await fn();
      setMsg({ kind: 'ok', text: ok });
      await load();
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.detail || e.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Year Create <span className="muted">— financial-year open / close / carry-forward</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <h2>New year</h2>
        <div className="row">
          <div className="field">
            <label>Year (CO_YEAR)</label>
            <input
              value={coYear}
              onChange={(e) => setCoYear(e.target.value)}
              placeholder="e.g. 2025"
            />
          </div>
          <div className="field">
            <label>Opening Date</label>
            <input type="date" value={opDate} onChange={(e) => setOpDate(e.target.value)} />
          </div>
          <div className="field">
            <label>Start Month</label>
            <input
              value={yearMonth}
              onChange={(e) => setYearMonth(e.target.value)}
              style={{ width: 56 }}
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button
              type="button"
              className="primary"
              disabled={busy || !coYear.trim()}
              onClick={() =>
                act(
                  () =>
                    post('/years', {
                      coYear: coYear.trim(),
                      opDate: opDate || undefined,
                      yearMonth,
                    }),
                  `Year ${coYear} created`,
                )
              }
            >
              Create Year
            </button>
          </div>
        </div>
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>{years.length} year(s)</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>Year</th>
              <th>Opening</th>
              <th>Closing</th>
              <th>Start Mo.</th>
              <th>Status</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {years.map((y) => (
              <tr key={y.coYear}>
                <td>{y.coYear}</td>
                <td>{y.opDate ?? ''}</td>
                <td>{y.clDate ?? ''}</td>
                <td>{y.yearMonth}</td>
                <td>
                  {y.closed ? (
                    <span style={{ color: 'var(--err)' }}>Closed</span>
                  ) : (
                    <span style={{ color: 'var(--ok)' }}>Open</span>
                  )}
                </td>
                <td>
                  {y.closed ? (
                    <button
                      type="button"
                      className="ghost"
                      disabled={busy}
                      onClick={() =>
                        act(
                          () => post(`/years/${encodeURIComponent(y.coYear)}/reopen`, {}),
                          `Reopened ${y.coYear}`,
                        )
                      }
                    >
                      Reopen
                    </button>
                  ) : (
                    <button
                      type="button"
                      className="ghost"
                      disabled={busy}
                      onClick={() =>
                        act(
                          () => post(`/years/${encodeURIComponent(y.coYear)}/close`, {}),
                          `Closed ${y.coYear}`,
                        )
                      }
                    >
                      Close
                    </button>
                  )}
                </td>
              </tr>
            ))}
            {years.length === 0 && (
              <tr>
                <td colSpan={6} className="muted">
                  No years.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <div className="panel">
        <h2>Carry forward openings</h2>
        <div className="row">
          <div className="field">
            <label>From Year (closing)</label>
            <input
              value={cf.fromYear}
              onChange={(e) => setCf((c) => ({ ...c, fromYear: e.target.value }))}
              placeholder="2024"
            />
          </div>
          <div className="field">
            <label>To Year (opening)</label>
            <input
              value={cf.toYear}
              onChange={(e) => setCf((c) => ({ ...c, toYear: e.target.value }))}
              placeholder="2025"
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button
              type="button"
              className="primary"
              disabled={busy || !cf.fromYear.trim() || !cf.toYear.trim()}
              onClick={() =>
                act(async () => {
                  const r = await post<{ parties: number }>('/years/carry-forward', {
                    fromYear: cf.fromYear.trim(),
                    toYear: cf.toYear.trim(),
                  });
                  setMsg({
                    kind: 'ok',
                    text: `Carried ${r.parties} party opening(s) into ${cf.toYear}`,
                  });
                }, 'done')
              }
            >
              Carry Forward
            </button>
          </div>
          <div className="field muted" style={{ flex: 1, alignSelf: 'center' }}>
            Writes each party's From-year closing balance as the To-year opening (OP_DATA).
            Idempotent.
          </div>
        </div>
      </div>
    </div>
  );
}
