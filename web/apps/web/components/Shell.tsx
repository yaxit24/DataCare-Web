'use client';
import Link from 'next/link';
import { usePathname, useRouter } from 'next/navigation';
import { useEffect, useState } from 'react';
import { NAV } from '../lib/nav';
import { get, post } from '../lib/api';

export interface Session {
  user: string;
  coCode: string;
  lcCode: string;
  coYear: string | null;
  passwordResetRequired?: boolean;
  rights: Record<string, boolean>;
  /** Per-form RBAC: null means explicit admin bypass; [] means no forms. */
  allowedForms: string[] | null;
}

export default function Shell({
  session,
  children,
}: {
  session: Session;
  children: React.ReactNode;
}) {
  const pathname = usePathname();
  const router = useRouter();

  // --- Phase 13: Company / Year switcher ---------------------------------
  // Current coCode/coYear come from the `session` prop (the /me payload the
  // app layout already fetched). On mount we load the available companies and
  // years; on change we re-scope the session and reload so all data refreshes.
  // If either list fails to load we leave `ready` false and fall back to the
  // original read-only chips (graceful degradation).
  const [companies, setCompanies] = useState<{ CO_CODE: string; CO_NAME: string }[]>([]);
  const [locations, setLocations] = useState<{ LC_CODE: string; LC_NAME: string }[]>([]);
  const [years, setYears] = useState<string[]>([]);
  const [coCode, setCoCode] = useState(session.coCode);
  const [lcCode, setLcCode] = useState(session.lcCode);
  const [coYear, setCoYear] = useState(session.coYear ?? '');
  const [ready, setReady] = useState(false);
  const [switching, setSwitching] = useState(false);

  useEffect(() => {
    let cancelled = false;
    (async () => {
      try {
        const [c, l, y] = await Promise.all([
          get<{ CO_CODE: string; CO_NAME: string }[]>('/context/companies'),
          get<{ LC_CODE: string; LC_NAME: string }[]>('/context/locations'),
          get<{ year: string }[]>('/context/years'),
        ]);
        if (cancelled) return;
        const yy = y.map((r) => r.year).filter(Boolean);
        if (c.length && l.length && yy.length) {
          setCompanies(c);
          setLocations(l);
          setYears(yy);
          setReady(true);
        }
      } catch {
        /* degrade gracefully: keep the static chips, hide the selector */
      }
    })();
    return () => {
      cancelled = true;
    };
  }, [session.coCode, session.lcCode, session.coYear]);

  async function switchContext(
    nextCo: string,
    nextLc: string,
    nextYear: string,
    deriveCompanyDefaults = false,
  ) {
    setCoCode(nextCo);
    setLcCode(nextLc);
    setCoYear(nextYear);
    if (!nextCo || switching) return;
    if (!deriveCompanyDefaults && (!nextLc || !nextYear)) return;
    setSwitching(true);
    try {
      await post(
        '/context/select',
        deriveCompanyDefaults
          ? { coCode: nextCo }
          : { coCode: nextCo, lcCode: nextLc, coYear: nextYear },
      );
      window.location.reload();
    } catch {
      setSwitching(false);
    }
  }

  async function logout() {
    await post('/auth/logout').catch(() => {});
    router.push('/login');
  }

  return (
    <div className="app">
      <header className="topbar">
        <span className="brand">DataCareNext</span>
        {ready ? (
          <>
            <select
              aria-label="Company"
              title="Switch company"
              value={coCode}
              disabled={switching}
              onChange={(e) => switchContext(e.target.value, lcCode, coYear, true)}
              style={{ color: 'var(--ink)', padding: '3px 6px', fontSize: 12, maxWidth: 220 }}
            >
              {companies.map((c) => (
                <option key={c.CO_CODE} value={c.CO_CODE}>
                  {c.CO_CODE} — {c.CO_NAME}
                </option>
              ))}
            </select>
            <select
              aria-label="Location"
              title="Switch location"
              value={lcCode}
              disabled={switching}
              onChange={(e) => switchContext(coCode, e.target.value, coYear)}
              style={{ color: 'var(--ink)', padding: '3px 6px', fontSize: 12, maxWidth: 180 }}
            >
              {locations.map((location) => (
                <option key={location.LC_CODE} value={location.LC_CODE}>
                  {location.LC_CODE} — {location.LC_NAME}
                </option>
              ))}
            </select>
            <select
              aria-label="Financial year"
              title="Switch financial year"
              value={coYear}
              disabled={switching}
              onChange={(e) => switchContext(coCode, lcCode, e.target.value)}
              style={{ color: 'var(--ink)', padding: '3px 6px', fontSize: 12 }}
            >
              {years.map((y) => (
                <option key={y} value={y}>
                  {y}
                </option>
              ))}
            </select>
          </>
        ) : (
          <>
            <span className="chip">Co {session.coCode}</span>
            <span className="chip">Loc {session.lcCode}</span>
            {session.coYear && <span className="chip">FY {session.coYear}</span>}
          </>
        )}
        <span className="spacer" />
        <span className="chip">👤 {session.user}</span>
        <button onClick={logout}>Logout</button>
      </header>
      <nav className="sidebar">
        {NAV.map((g) => {
          // Only explicit null (server-verified admin) means show all; [] hides every form.
          const allowed = session.allowedForms;
          const items =
            allowed === null
              ? g.items
              : g.items.filter((it) => allowed.includes(`${g.label}/${it.label}`));
          if (!items.length) return null;
          return (
            <div key={g.label}>
              <div className="group">{g.label}</div>
              {items.map((it) => {
                const active = pathname === it.href.split('?')[0];
                return (
                  <Link key={it.label + it.href} href={it.href} className={active ? 'active' : ''}>
                    {it.label}
                    {!it.ready && <span className="soon">soon</span>}
                  </Link>
                );
              })}
            </div>
          );
        })}
      </nav>
      <main className="content">{children}</main>
    </div>
  );
}
