'use client';
import { useEffect, useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { get, loadPageSession, ApiError, PageContextError } from '../../lib/api';
import type { BrowserSessionContext } from '../../lib/pageContext';
import { useOperationLease } from '../../components/useOperationLease';
import {
  createPendingContextSelection,
  savePendingContextSelection,
  readPendingContextSelection,
  clearPendingContextSelection,
  submitPendingContextSelection,
  type PendingContextSelection,
} from '../../lib/contextSelection';

interface Company {
  CO_CODE: string;
  CO_NAME: string;
}
interface Location {
  LC_CODE: string;
  LC_NAME: string;
}
interface SessionScope {
  coCode: string;
  lcCode: string;
  coYear: string | null;
  passwordResetRequired?: boolean;
  context: BrowserSessionContext;
}

export default function SelectPage() {
  const router = useRouter();
  const [companies, setCompanies] = useState<Company[]>([]);
  const [locations, setLocations] = useState<Location[]>([]);
  const [years, setYears] = useState<string[]>([]);
  const [current, setCurrent] = useState<BrowserSessionContext | null>(null);
  const [coCode, setCoCode] = useState('');
  const [lcCode, setLcCode] = useState('');
  const [coYear, setCoYear] = useState('');
  const [pending, setPending] = useState<PendingContextSelection | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [ready, setReady] = useState(false);
  const [needsReload, setNeedsReload] = useState(false);
  const { beginOperation } = useOperationLease();
  const busyRef = useRef(false);

  useEffect(() => {
    let cancelled = false;
    (async () => {
      try {
        // Establish one authoritative page identity before starting context-specific list reads.
        const me = await loadPageSession<SessionScope>();
        if (cancelled) return;
        if (me.passwordResetRequired) {
          router.push('/password-change');
          return;
        }
        setCurrent(me.context);
        setPending(readPendingContextSelection(me.context));
        const [companyRows, locationRows, yearRows] = await Promise.all([
          get<Company[]>('/context/companies'),
          get<Location[]>('/context/locations'),
          get<Array<{ year: string }>>('/context/years'),
        ]);
        if (cancelled) return;
        const yearValues = yearRows.map((row) => row.year).filter(Boolean);
        setCompanies(companyRows);
        setLocations(locationRows);
        setYears(yearValues);
        setCoCode(me.coCode);
        setLcCode(me.lcCode || locationRows[0]?.LC_CODE || '');
        setCoYear(me.coYear || yearValues[0] || '');
        setReady(true);
      } catch (error) {
        if (cancelled) return;
        if (error instanceof ApiError && error.status === 401) router.push('/login');
        else if (error instanceof ApiError && error.body?.error === 'password-reset-required')
          router.push('/password-change');
        else setErr(error instanceof Error ? error.message : 'Failed to load company choices.');
      }
    })();
    return () => {
      cancelled = true;
    };
  }, [router]);

  async function go(event: React.FormEvent) {
    event.preventDefault();
    if (!current || busyRef.current || !ready || needsReload) return;
    const isCurrent = beginOperation();
    if (!isCurrent()) return;
    busyRef.current = true;
    setBusy(true);
    setErr('');
    try {
      const saved =
        pending ??
        createPendingContextSelection(
          current,
          coCode !== current.coCode ? { coCode } : { coCode, lcCode, coYear },
        );
      savePendingContextSelection(saved);
      setPending(saved);
      await submitPendingContextSelection(saved, { isCurrent });
      if (!isCurrent()) return;
      window.location.assign('/dashboard');
    } catch (error) {
      if (!isCurrent()) return;
      setNeedsReload(true);
      const key = error instanceof ApiError ? error.body?.error : undefined;
      setErr(
        key === 'target-password-reset-required'
          ? 'The target company requires a password reset. Sign in through that company or ask its administrator to reset the credential.'
          : key === 'year-unavailable'
            ? 'Selected year is not available.'
            : key === 'location-unavailable'
              ? 'Selected location is not available.'
              : error instanceof PageContextError
                ? error.message
                : error instanceof Error
                  ? error.message
                  : 'The company change could not be confirmed.',
      );
      busyRef.current = false;
      setBusy(false);
    }
  }

  async function useCurrentCompany() {
    if (!pending || !current || busyRef.current || needsReload || !ready) return;
    const isCurrent = beginOperation();
    if (!isCurrent()) return;
    busyRef.current = true;
    setBusy(true);
    try {
      const verified = await loadPageSession<SessionScope>();
      if (!isCurrent()) return;
      clearPendingContextSelection(pending.request.selectionId);
      setPending(null);
      setErr('');
      // This acknowledges the current observed company; it does not undo a committed selection.
      if (verified.context.coYear) window.location.assign('/dashboard');
    } catch (error) {
      if (!isCurrent()) return;
      setNeedsReload(true);
      setErr(error instanceof Error ? error.message : 'Recovery storage could not be cleared.');
    } finally {
      if (isCurrent()) {
        busyRef.current = false;
        setBusy(false);
      }
    }
  }

  const changingCompany = current !== null && coCode !== current.coCode;
  return (
    <div className="login-wrap">
      <form className="login-card" onSubmit={go}>
        <h1>Open Company</h1>
        {err && (
          <div className="msg err" role="alert">
            {err}
          </div>
        )}
        {pending && (
          <div className="msg" data-testid="pending-context-recovery">
            <p>A previous change to company {pending.request.coCode} needs confirmation.</p>
            <p>Retry uses the saved operation. It will not apply a completed change twice.</p>
            {current && (
              <p>
                Current company: {current.coCode}, location {current.lcCode}, year{' '}
                {current.coYear ?? 'not selected'}.
              </p>
            )}
            <button
              type="button"
              disabled={busy || needsReload || !ready}
              onClick={useCurrentCompany}
            >
              Use current company
            </button>
          </div>
        )}
        <div className="field">
          <label htmlFor="context-company">Company</label>
          <select
            id="context-company"
            value={coCode}
            disabled={!ready || busy || needsReload || !!pending}
            onChange={(event) => setCoCode(event.target.value)}
          >
            {companies.map((company) => (
              <option key={company.CO_CODE} value={company.CO_CODE}>
                {company.CO_CODE} — {company.CO_NAME}
              </option>
            ))}
          </select>
        </div>
        <div className="field">
          <label htmlFor="context-location">Location</label>
          <select
            id="context-location"
            value={lcCode}
            disabled={!ready || busy || needsReload || changingCompany || !!pending}
            onChange={(event) => setLcCode(event.target.value)}
          >
            {locations.map((location) => (
              <option key={location.LC_CODE} value={location.LC_CODE}>
                {location.LC_CODE} — {location.LC_NAME}
              </option>
            ))}
          </select>
        </div>
        <div className="field">
          <label htmlFor="context-year">Financial Year</label>
          <select
            id="context-year"
            value={coYear}
            disabled={!ready || busy || needsReload || changingCompany || !!pending}
            onChange={(event) => setCoYear(event.target.value)}
          >
            {years.map((year) => (
              <option key={year} value={year}>
                {year}
              </option>
            ))}
          </select>
        </div>
        {changingCompany && !pending && (
          <p className="muted">
            The target company’s default location and latest year will be selected.
          </p>
        )}
        <button
          className="primary"
          style={{ width: '100%', marginTop: 8 }}
          disabled={
            !ready ||
            busy ||
            needsReload ||
            (!pending && (!coCode || (!changingCompany && (!lcCode || !coYear))))
          }
        >
          {busy ? 'Opening…' : pending ? 'Retry saved company change' : 'Open'}
        </button>
        {err && (
          <button type="button" disabled={busy} onClick={() => window.location.reload()}>
            Reload current company
          </button>
        )}
      </form>
    </div>
  );
}
