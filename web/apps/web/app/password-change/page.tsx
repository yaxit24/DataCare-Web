'use client';
import { useEffect, useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { ApiError, post, loadPageSession, PageContextError } from '../../lib/api';
import { useOperationLease } from '../../components/useOperationLease';

export default function PasswordChangePage() {
  const router = useRouter();
  const [currentPassword, setCurrentPassword] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  const [ready, setReady] = useState(false);
  const busyRef = useRef(false);
  const { beginOperation } = useOperationLease();
  useEffect(() => {
    let cancelled = false;
    loadPageSession()
      .then(() => {
        if (!cancelled) setReady(true);
      })
      .catch((cause) => {
        if (cancelled) return;
        if (cause instanceof ApiError && cause.status === 401) router.push('/login');
        else setError(cause instanceof Error ? cause.message : 'Cannot load the current session.');
      });
    return () => {
      cancelled = true;
    };
  }, [router]);

  async function submit(event: React.FormEvent) {
    event.preventDefault();
    if (!ready || busyRef.current) return;
    setError('');
    if (newPassword !== confirmPassword) {
      setError('New password and confirmation do not match.');
      return;
    }
    const isCurrent = beginOperation();
    if (!isCurrent()) return;
    busyRef.current = true;
    setBusy(true);
    try {
      await post('/auth/password/change', { currentPassword, newPassword, confirmPassword });
      if (!isCurrent()) return;
      window.location.assign('/select');
    } catch (cause) {
      if (!isCurrent()) return;
      const body = cause instanceof ApiError ? cause.body : undefined;
      if (cause instanceof PageContextError) {
        setError(cause.message);
      } else if (body?.error === 'weak-password') {
        setError(`Password does not meet policy (${(body.reasons ?? []).join(', ')}).`);
      } else if (body?.error === 'current-password-invalid') {
        setError('Current password is incorrect.');
      } else {
        setError('Password could not be changed.');
      }
    } finally {
      if (isCurrent()) {
        busyRef.current = false;
        setBusy(false);
      }
    }
  }

  return (
    <div className="login-wrap">
      <form className="login-card" onSubmit={submit}>
        <h1>Change Password</h1>
        <p className="muted">
          Use at least 12 characters with uppercase, lowercase, number, and symbol.
        </p>
        {error && <div className="msg err">{error}</div>}
        <div className="field">
          <label>Current password</label>
          <input
            type="password"
            autoComplete="current-password"
            value={currentPassword}
            onChange={(event) => setCurrentPassword(event.target.value)}
            autoFocus
          />
        </div>
        <div className="field">
          <label>New password</label>
          <input
            type="password"
            autoComplete="new-password"
            value={newPassword}
            onChange={(event) => setNewPassword(event.target.value)}
          />
        </div>
        <div className="field">
          <label>Confirm new password</label>
          <input
            type="password"
            autoComplete="new-password"
            value={confirmPassword}
            onChange={(event) => setConfirmPassword(event.target.value)}
          />
        </div>
        <button
          className="primary"
          style={{ width: '100%', marginTop: 8 }}
          disabled={!ready || busy || !currentPassword || !newPassword || !confirmPassword}
        >
          {busy ? 'Changing…' : 'Change Password'}
        </button>
      </form>
    </div>
  );
}
