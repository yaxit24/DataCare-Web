'use client';
import { useCallback, useEffect, useId, useMemo, useState } from 'react';
import { useRouter } from 'next/navigation';
import { fiscalYearDates, formatDesktopDate } from '@datacare/core';
import { get, post, ApiError } from '../../../../lib/api';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';

/** Year Create (desktop MS_YEAR, YEAR_MAST): create a financial year.
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
  const router = useRouter();
  const [years, setYears] = useState<Year[]>([]);
  const [coYear, setCoYear] = useState('');
  const [opDate, setOpDate] = useState('');
  const [clDate, setClDate] = useState('');
  const [yearMonth, setYearMonth] = useState('04');
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

  // Keys of MS_YEAR: Esc closes the form (MS_YEAR_KeyDown, MS_YEAR.cs:951-957); Enter on a field goes to the next one
  // (SendKeys "{tab}", :1069-1137), and on the year code only when it is not blank (:1083). The order is the tab order
  // Year Code 0, Start Month 1, Opening Date 2, Closing Date 3, then the buttons.
  const order = [`${id}-year`, `${id}-month`, `${id}-op`, `${id}-cl`, `${id}-create`];
  const onScreenKeyDown = (event: ScreenKeyEvent) => {
    if (event.defaultPrevented) return;
    if (event.key === 'Escape') {
      event.preventDefault();
      router.back();
      return;
    }
    const at = order.indexOf((event.target as HTMLElement | null)?.id ?? '');
    if (event.key !== 'Enter' || at < 0 || at === order.length - 1) return;
    if (at === 0 && !coYear.trim()) return;
    event.preventDefault();
    document.getElementById(order[at + 1]!)?.focus();
  };
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);

  return (
    <div ref={screenRef} onKeyDown={(event) => onScreenKeyDown(event as unknown as ScreenKeyEvent)}>
      <h1>
        Year Create <span className="muted">— financial year</span>
      </h1>
      <button
        disabled={busy}
        onClick={() =>
          act(async () => {
            await get('/years/print');
            return '';
          })
        }
      >
        Print
      </button>
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
              autoFocus
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
              id={`${id}-create`}
              type="button"
              className="primary"
              disabled={busy || !coYear.trim() || !!preview.error}
              onClick={() =>
                act(async () => {
                  await post<{ coYear: string; opDate: string; clDate: string }>('/years', {
                    coYear: coYear.trim(),
                    opDate: opDate || undefined,
                    clDate: clDate || undefined,
                    yearMonth,
                  });
                  return 'New Year are Created...Now ReOpen Sofware...';
                })
              }
            >
              Create Year
            </button>
          </div>
        </div>
        {coYear.trim() && (
          <div className={preview.error ? 'msg err' : 'muted'} aria-live="polite">
            {preview.error ??
              `Opens ${formatDesktopDate(preview.opDate)}, closes ${formatDesktopDate(preview.clDate)}`}
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
                <td>{formatDesktopDate(y.opDate)}</td>
                <td>
                  {y.clDate ? (
                    formatDesktopDate(y.clDate)
                  ) : (
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
    </div>
  );
}
