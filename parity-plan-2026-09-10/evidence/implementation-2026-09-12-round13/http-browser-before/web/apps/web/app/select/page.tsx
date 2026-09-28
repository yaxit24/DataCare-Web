'use client';
import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import { get, post, ApiError } from '../../lib/api';

interface Company {
  CO_CODE: string;
  CO_NAME: string;
}
interface Location {
  LC_CODE: string;
  LC_NAME: string;
}
interface YearRow {
  year: string;
}
interface SessionScope {
  coCode: string;
  lcCode: string;
  coYear: string | null;
  passwordResetRequired?: boolean;
}

export default function SelectPage() {
  const router = useRouter();
  const [companies, setCompanies] = useState<Company[]>([]);
  const [locations, setLocations] = useState<Location[]>([]);
  const [years, setYears] = useState<string[]>([]);
  const [currentCo, setCurrentCo] = useState('');
  const [coCode, setCoCode] = useState('');
  const [lcCode, setLcCode] = useState('');
  const [coYear, setCoYear] = useState('');
  const [err, setErr] = useState('');

  useEffect(() => {
    (async () => {
      try {
        const [me, companiesResult, locationsResult, yearsResult] = await Promise.all([
          get<SessionScope>('/me'),
          get<Company[]>('/context/companies'),
          get<Location[]>('/context/locations'),
          get<YearRow[]>('/context/years'),
        ]);
        if (me.passwordResetRequired) {
          router.push('/password-change');
          return;
        }
        const yearValues = yearsResult.map((row) => row.year).filter(Boolean);
        setCompanies(companiesResult);
        setLocations(locationsResult);
        setYears(yearValues);
        setCurrentCo(me.coCode);
        setCoCode(me.coCode);
        setLcCode(me.lcCode || locationsResult[0]?.LC_CODE || '');
        setCoYear(me.coYear || yearValues[0] || '');
      } catch (cause) {
        if (cause instanceof ApiError && cause.status === 401) router.push('/login');
        else if (cause instanceof ApiError && cause.body?.error === 'password-reset-required')
          router.push('/password-change');
        else setErr('Failed to load companies, locations, and years');
      }
    })();
  }, [router]);

  async function go(event: React.FormEvent) {
    event.preventDefault();
    setErr('');
    try {
      if (coCode !== currentCo) {
        await post('/context/select', { coCode });
      } else {
        await post('/context/select', { coCode, lcCode, coYear });
      }
      router.push('/dashboard');
    } catch (cause) {
      const message =
        cause instanceof ApiError ? cause.body?.error || cause.message : 'select failed';
      setErr(
        message === 'year-unavailable'
          ? 'Selected year is not available'
          : message === 'location-unavailable'
            ? 'Selected location is not available'
            : message,
      );
    }
  }

  const changingCompany = !!currentCo && coCode !== currentCo;

  return (
    <div className="login-wrap">
      <form className="login-card" onSubmit={go}>
        <h1>Open Company</h1>
        {err && <div className="msg err">{err}</div>}
        <div className="field">
          <label>Company</label>
          <select value={coCode} onChange={(event) => setCoCode(event.target.value)}>
            {companies.map((company) => (
              <option key={company.CO_CODE} value={company.CO_CODE}>
                {company.CO_CODE} — {company.CO_NAME}
              </option>
            ))}
          </select>
        </div>
        <div className="field">
          <label>Location</label>
          <select
            value={lcCode}
            disabled={changingCompany}
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
          <label>Financial Year</label>
          <select
            value={coYear}
            disabled={changingCompany}
            onChange={(event) => setCoYear(event.target.value)}
          >
            {years.map((year) => (
              <option key={year} value={year}>
                {year}
              </option>
            ))}
          </select>
        </div>
        {changingCompany && (
          <p className="muted">
            The target company’s default location and latest year will be selected.
          </p>
        )}
        <button
          className="primary"
          style={{ width: '100%', marginTop: 8 }}
          disabled={!coCode || (!changingCompany && (!lcCode || !coYear))}
        >
          Open
        </button>
      </form>
    </div>
  );
}
