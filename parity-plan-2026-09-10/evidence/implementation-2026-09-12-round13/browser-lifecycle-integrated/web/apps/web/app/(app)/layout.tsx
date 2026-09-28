'use client';
import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import {
  loadPageSession,
  getPageContextState,
  subscribePageContext,
  ApiError,
  PageContextError,
} from '../../lib/api';
import Shell, { type Session } from '../../components/Shell';
import { BusinessScopeProvider } from '../../components/BusinessScope';
import { KeyboardNav } from '../../components/KeyboardNav';
import { GlobalFormKeys } from '../../components/GlobalFormKeys';

export default function AppLayout({ children }: { children: React.ReactNode }) {
  const router = useRouter();
  const [session, setSession] = useState<Session | null>(null);
  const [contextState, setContextState] = useState(getPageContextState);
  useEffect(() => subscribePageContext(setContextState), []);
  const [state, setState] = useState<'loading' | 'ready' | 'error'>('loading');
  const [loadError, setLoadError] = useState('Cannot reach server.');
  const [reloadRequired, setReloadRequired] = useState(false);

  useEffect(() => {
    let cancelled = false;
    (async () => {
      try {
        const me = await loadPageSession<Session>();
        if (cancelled) return;
        if (me.passwordResetRequired) {
          router.push('/password-change');
          return;
        }
        if (!me.coYear) {
          router.push('/select');
          return;
        }
        setSession(me);
        setState('ready');
      } catch (e) {
        if (cancelled) return;
        if (e instanceof ApiError && e.status === 401) router.push('/login');
        else {
          setLoadError(e instanceof PageContextError ? e.message : 'Cannot reach server.');
          setReloadRequired(e instanceof PageContextError);
          setState('error');
        }
      }
    })();
    return () => {
      cancelled = true;
    };
  }, [router]);

  if (state === 'loading')
    return (
      <div className="login-wrap">
        <div className="muted">Loading…</div>
      </div>
    );
  if (state === 'error' || !session || !session.coYear)
    return (
      <div className="login-wrap">
        <div className="msg err" role="alert">
          <p>{loadError}</p>
          {reloadRequired && (
            <button onClick={() => window.location.reload()}>Reload current session</button>
          )}
        </div>
      </div>
    );
  return (
    <BusinessScopeProvider
      scope={{ coCode: session.coCode, lcCode: session.lcCode, coYear: session.coYear }}
    >
      <Shell session={session} contextStale={contextState.status === 'stale'}>
        {contextState.status === 'stale' && (
          <div className="msg err" role="alert" data-testid="context-stale-banner">
            <p>{contextState.message}</p>
            <button onClick={() => window.location.reload()}>
              Reload after copying unsaved work
            </button>
          </div>
        )}
        <KeyboardNav />
        <GlobalFormKeys />
        {children}
      </Shell>
    </BusinessScopeProvider>
  );
}
