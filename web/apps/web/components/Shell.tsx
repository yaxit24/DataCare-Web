'use client';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import { useEffect, useRef, useState } from 'react';
import { NAV } from '../lib/nav';
import { editionNav, navItemForm } from '../lib/editionNav';
import { get, post } from '../lib/api';
import type { BrowserSessionContext } from '../lib/pageContext';
import { routeAvailability, type EditionCode, type RoundingFlagValues } from '@datacare/core';
import { useOperationLease } from './useOperationLease';
import {
  createPendingContextSelection,
  savePendingContextSelection,
  readPendingContextSelection,
  submitPendingContextSelection,
  type PendingContextSelection,
} from '../lib/contextSelection';

export interface Session {
  user: string;
  context: BrowserSessionContext;
  coCode: string;
  lcCode: string;
  coYear: string | null;
  passwordResetRequired?: boolean;
  /** Company money-rounding flags for previewing document totals (G102/G84). */
  roundingFlags?: RoundingFlagValues | null;
  rights: Record<string, boolean>;
  /** Per-form RBAC: null means explicit admin bypass; [] means no forms. */
  allowedForms: string[] | null;
  /** The running desktop edition (N171); null when the deployment has no edition gate. */
  edition?: { code: EditionCode; name: string; beta: boolean } | null;
}

export default function Shell({
  session,
  children,
  contextStale = false,
}: {
  session: Session;
  contextStale?: boolean;
  children: React.ReactNode;
}) {
  const pathname = usePathname();
  // N171: only the running edition's menus, as MDI_FORM loads MENU_DATA by SM_TYPE; Beta collects the rest.
  const edition = session.edition
    ? { code: session.edition.code, beta: session.edition.beta }
    : null;
  const editionMenus = editionNav(NAV, edition);
  const pageAvailability = edition ? routeAvailability(pathname, edition) : 'available';

  // --- Phase 13: Company / Year switcher ---------------------------------
  // Current coCode/coYear come from the `session` prop (the /me payload the
  // app layout already fetched). On mount we load the available companies and
  // years; on change we re-scope the session and reload so all data refreshes.
  // If either list fails to load we leave `ready` false and fall back to the
  // original read-only chips (graceful degradation).
  const [companies, setCompanies] = useState<{ CO_CODE: string; CO_NAME: string }[]>([]);
  const [locations, setLocations] = useState<{ LC_CODE: string; LC_NAME: string }[]>([]);
  const [years, setYears] = useState<string[]>([]);
  const [coCode] = useState(session.coCode);
  const [lcCode] = useState(session.lcCode);
  const [coYear] = useState(session.coYear ?? '');
  const [ready, setReady] = useState(false);
  const [switching, setSwitching] = useState(false);
  const operationBusy = useRef(false);
  const { beginOperation } = useOperationLease(pathname);
  const [pending, setPending] = useState<PendingContextSelection | null>(null);
  const [selectionError, setSelectionError] = useState('');
  useEffect(() => {
    // Shell survives client navigation. Release the departed route's local UI lock;
    // its durable pending operation and the document context guard remain intact.
    operationBusy.current = false;
    setSwitching(false);
  }, [pathname]);
  useEffect(() => {
    const blockCommands = (event: KeyboardEvent) => {
      if (
        operationBusy.current &&
        (event.key === 'Enter' ||
          /^F[0-9]+$/.test(event.key) ||
          ((event.ctrlKey || event.metaKey) && event.key.toLowerCase() === 's'))
      ) {
        event.preventDefault();
        event.stopImmediatePropagation();
      }
    };
    document.addEventListener('keydown', blockCommands, true);
    return () => document.removeEventListener('keydown', blockCommands, true);
  }, []);
  useEffect(() => {
    try {
      setPending(readPendingContextSelection(session.context));
    } catch {
      setSelectionError('Browser recovery storage is unavailable. Company changes are paused.');
    }
  }, [session.context]);

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
    if (!nextCo || operationBusy.current || pending || contextStale) return;
    if (!deriveCompanyDefaults && (!nextLc || !nextYear)) return;
    if (
      !window.confirm(
        'Changing company, branch or year closes this page. Save or copy any unsaved work first. Continue?',
      )
    )
      return;
    const isCurrent = beginOperation();
    if (!isCurrent()) return;
    operationBusy.current = true;
    setSwitching(true);
    setSelectionError('');
    try {
      const saved = createPendingContextSelection(
        session.context,
        deriveCompanyDefaults
          ? { coCode: nextCo }
          : { coCode: nextCo, lcCode: nextLc, coYear: nextYear },
      );
      savePendingContextSelection(saved);
      setPending(saved);
      await submitPendingContextSelection(saved, { isCurrent });
      if (!isCurrent()) return;
      window.location.reload();
    } catch (error) {
      if (!isCurrent()) return;
      setSelectionError(
        error instanceof Error ? error.message : 'The company change could not be confirmed.',
      );
      operationBusy.current = false;
      setSwitching(false);
    }
  }

  async function logout() {
    if (operationBusy.current) return;
    const isCurrent = beginOperation();
    if (!isCurrent()) return;
    operationBusy.current = true;
    setSwitching(true);
    await post('/auth/logout').catch(() => {});
    if (isCurrent()) window.location.assign('/login');
  }

  return (
    <div className="app">
      <header className="topbar">
        <span className="brand">DataCareNext</span>
        {session.edition && (
          <span className="chip" data-testid="edition">
            {session.edition.name}
            {session.edition.beta ? ' + Beta' : ''}
          </span>
        )}
        {ready ? (
          <>
            <select
              aria-label="Company"
              title="Switch company"
              value={coCode}
              disabled={switching || !!pending || contextStale || !!selectionError}
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
              disabled={switching || !!pending || contextStale || !!selectionError}
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
              disabled={switching || !!pending || contextStale || !!selectionError}
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
        <button disabled={switching} onClick={logout}>
          Logout
        </button>
      </header>
      <nav
        className="sidebar"
        onClickCapture={(event) => {
          if (switching) {
            event.preventDefault();
            event.stopPropagation();
          }
        }}
      >
        {editionMenus.groups.map((g) => {
          // Only explicit null (server-verified admin) means show all; [] hides every form.
          const allowed = session.allowedForms;
          const items =
            allowed === null
              ? g.items
              : g.items.filter((it) => allowed.includes(it.form ?? `${g.label}/${it.label}`));
          if (!items.length) return null;
          return (
            <div key={g.label}>
              <div className="group">{g.label}</div>
              {items.map((it) => {
                const active = pathname === it.href.split('?')[0];
                // G182: no prefetch. Each page drew about 240 route prefetches, one per navigation link.
                return (
                  <Link
                    key={it.label + it.href}
                    href={it.href}
                    prefetch={false}
                    className={active ? 'active' : ''}
                  >
                    {it.label}
                    {!it.ready && <span className="soon">soon</span>}
                  </Link>
                );
              })}
            </div>
          );
        })}
        {(() => {
          const allowed = session.allowedForms;
          const betaItems = editionMenus.beta.filter(
            (it) => allowed === null || allowed.includes(navItemForm(it.group, it)),
          );
          if (!betaItems.length) return null;
          return (
            <div key="beta" data-testid="beta-menus">
              <div className="group">Beta</div>
              {betaItems.map((it) => (
                <Link
                  key={`beta-${it.label}-${it.href}`}
                  href={it.href}
                  prefetch={false}
                  className={pathname === it.href.split('?')[0] ? 'active' : ''}
                >
                  {it.label} <span className="soon">beta</span>
                </Link>
              ))}
            </div>
          );
        })()}
      </nav>
      <main className="content">
        {(pending || selectionError) && (
          <div className="msg err" role="alert" data-testid="pending-context-recovery">
            {pending && (
              <p>A company change to {pending.request.coCode} is awaiting confirmation.</p>
            )}
            {selectionError && <p>{selectionError}</p>}
            {pending && (
              <button
                disabled={switching}
                onClick={() => {
                  if (
                    window.confirm(
                      'Company selection will close this page. Copy any unsaved work first. Continue?',
                    )
                  )
                    window.location.assign('/select');
                }}
              >
                Check company change
              </button>
            )}
          </div>
        )}
        <fieldset
          disabled={switching}
          style={{ border: 0, padding: 0, margin: 0, minWidth: 0 }}
          aria-busy={switching}
        >
          {pageAvailability === 'unavailable' ? (
            <div className="msg err" role="alert" data-testid="edition-unavailable">
              <p>This screen is not part of the {session.edition?.name} edition.</p>
            </div>
          ) : (
            <>
              {pageAvailability === 'beta' && (
                <div className="msg" role="status" data-testid="edition-beta">
                  <p>
                    Beta: this screen belongs to a higher edition than {session.edition?.name} and
                    is not part of its release.
                  </p>
                </div>
              )}
              {children}
            </>
          )}
        </fieldset>
      </main>
    </div>
  );
}
