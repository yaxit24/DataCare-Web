'use client';
import { useEffect, useState } from 'react';
import { useRouter } from 'next/navigation';
import { get, ApiError } from '../../lib/api';
import Shell, { type Session } from '../../components/Shell';
import { BusinessScopeProvider } from '../../components/BusinessScope';
import { KeyboardNav } from '../../components/KeyboardNav';
import { GlobalFormKeys } from '../../components/GlobalFormKeys';

export default function AppLayout({ children }: { children: React.ReactNode }) {
  const router = useRouter();
  const [session, setSession] = useState<Session | null>(null);
  const [state, setState] = useState<'loading' | 'ready' | 'error'>('loading');

  useEffect(() => {
    (async () => {
      try {
        const me = await get<Session>('/me');
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
        if (e instanceof ApiError && e.status === 401) router.push('/login');
        else setState('error');
      }
    })();
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
        <div className="msg err">Cannot reach server.</div>
      </div>
    );
  return (
    <BusinessScopeProvider
      scope={{ coCode: session.coCode, lcCode: session.lcCode, coYear: session.coYear }}
    >
      <Shell session={session}>
        <KeyboardNav />
        <GlobalFormKeys />
        {children}
      </Shell>
    </BusinessScopeProvider>
  );
}
