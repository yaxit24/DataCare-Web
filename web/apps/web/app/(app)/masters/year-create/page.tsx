'use client';
import { useCallback, useEffect, useId, useMemo, useState } from 'react';
import { fiscalYearDates } from '@datacare/core';
import { get, post, ApiError } from '../../../../lib/api';

/** Year Create (desktop MS_YEAR, YEAR_MAST): create a financial year and carry the prior year's closing
 *  party balances forward as the new year's opening (OP_DATA).
 *
 *  The closing date is the year's last day (MS_YEAR.cs:1035-1040 fills 01/04/yyyy – 31/03/yyyy+1), and every
 *  voucher is bounded by it, so this screen never clears or moves it. Period locking is Settings → lock
 *  date; year-end carry-forward is Utilities → Year-End Close. */
interface Year {
  coYear: string;
  opDate: string | null;
  clDate: string | null;
  yearMonth: string;
}

const errorText = (e: unknown): string =>
  e instanceof ApiError
    ? e.body?.message || e.body?.detail || e.body?.error || e.message
    : e instanceof Error
      ? e.message
      : 'failed';

export default function YearCreatePage() {
  const id = useId();
  const [years, setYears] = useState<Year[]>([]);
  const [coYear, setCoYear] = useState('');
  const [opDate, setOpDate] = useState('');
  const [clDate, setClDate] = useState('');
  const [yearMonth, setYearMonth] = useState('04');
  const [cf, setCf] = useState({ fromYear: '', toYear: '' });
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async () => {
    try {
      setYears(await get<Year[]>('/years'));
    } catch (e) {
      setMsg({ kind: 'err', text: errorText(e) });
    }
  }, []);
  useEffect(() => {
    void load();
  }, [load]);

  // What the server will store when a date is left blank (the same @datacare/core rule the API applies).
  const preview = useMemo(
    () => fiscalYearDates({ coYear, opDate, clDate, yearMonth }),
    [coYear, opDate, clDate, yearMonth],
  );

  async function act(fn: () => Promise<string>) {
    setBusy(true);
    setMsg(null);
    try {
      const text = await fn();
      setMsg({ kind: 'ok', text });
      await load();
    } catch (e) {
      setMsg({ kind: 'err', text: errorText(e) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Year Create <span className="muted">— financial year and opening carry-forward</span>
      </h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div className="panel">
        <h2>New year</h2>
        <div className="row">
          <div className="field">
            <label htmlFor={`${id}-year`}>Year (CO_YEAR)</label>
            <input
              id={`${id}-year`}
              value={coYear}
              onChange={(e) => setCoYear(e.target.value)}
              placeholder="e.g. 2027-2028"
              maxLength={9}
            />
          </div>
          <div className="field">
            <label htmlFor={`${id}-month`}>Start Month</label>
            <input
              id={`${id}-month`}
              value={yearMonth}
              onChange={(e) => setYearMonth(e.target.value)}
              inputMode="numeric"
              maxLength={2}
              style={{ width: 56 }}
            />
          </div>
          <div className="field">
            <label htmlFor={`${id}-op`}>Opening Date</label>
            <input
              id={`${id}-op`}
              type="date"
              value={opDate}
              onChange={(e) => setOpDate(e.target.value)}
            />
          </div>
          <div className="field">
            <label htmlFor={`${id}-cl`}>Closing Date</label>
            <input
              id={`${id}-cl`}
              type="date"
              value={clDate}
              onChange={(e) => setClDate(e.target.value)}
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button
              type="button"
              className="primary"
              disabled={busy || !coYear.trim() || !!preview.error}
              onClick={() =>
                act(async () => {
                  const r = await post<{ coYear: string; opDate: string; clDate: string }>(
                    '/years',
                    {
                      coYear: coYear.trim(),
                      opDate: opDate || undefined,
                      clDate: clDate || undefined,
                      yearMonth,
                    },
                  );
                  return `Year ${r.coYear} created (${r.opDate} to ${r.clDate})`;
                })
              }
            >
              Create Year
            </button>
          </div>
        </div>
        {coYear.trim() && (
          <div className={preview.error ? 'msg err' : 'muted'} aria-live="polite">
            {preview.error ?? `Opens ${preview.opDate}, closes ${preview.clDate}`}
          </div>
        )}
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>{years.length} year(s)</h2>
        <table className="grid">
          <thead>
            <tr>
              <th scope="col">Year</th>
              <th scope="col">Opening</th>
              <th scope="col">Closing</th>
              <th scope="col">Start Mo.</th>
            </tr>
          </thead>
          <tbody>
            {years.map((y) => (
              <tr key={y.coYear}>
                <td>{y.coYear}</td>
                <td>{y.opDate ?? ''}</td>
                <td>
                  {y.clDate ?? (
                    <span style={{ color: 'var(--err)' }}>
                      missing — vouchers cannot be posted in this year
                    </span>
                  )}
                </td>
                <td>{y.yearMonth}</td>
              </tr>
            ))}
            {years.length === 0 && (
              <tr>
                <td colSpan={4} className="muted">
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
            <label htmlFor={`${id}-from`}>From Year (closing)</label>
            <input
              id={`${id}-from`}
              value={cf.fromYear}
              onChange={(e) => setCf((c) => ({ ...c, fromYear: e.target.value }))}
              placeholder="2026-2027"
            />
          </div>
          <div className="field">
            <label htmlFor={`${id}-to`}>To Year (opening)</label>
            <input
              id={`${id}-to`}
              value={cf.toYear}
              onChange={(e) => setCf((c) => ({ ...c, toYear: e.target.value }))}
              placeholder="2027-2028"
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
                  return `Carried ${r.parties} party opening(s) into ${cf.toYear.trim()}`;
                })
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
