'use client';
import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { ApiError, post } from '../../lib/api';

export default function PasswordChangePage() {
  const router = useRouter();
  const [currentPassword, setCurrentPassword] = useState('');
  const [newPassword, setNewPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');

  async function submit(event: React.FormEvent) {
    event.preventDefault();
    setError('');
    if (newPassword !== confirmPassword) {
      setError('New password and confirmation do not match.');
      return;
    }
    setBusy(true);
    try {
      await post('/auth/password/change', { currentPassword, newPassword, confirmPassword });
      router.push('/select');
    } catch (cause) {
      const body = cause instanceof ApiError ? cause.body : undefined;
      if (body?.error === 'weak-password') {
        setError(`Password does not meet policy (${(body.reasons ?? []).join(', ')}).`);
      } else if (body?.error === 'current-password-invalid') {
        setError('Current password is incorrect.');
      } else {
        setError('Password could not be changed.');
      }
    } finally {
      setBusy(false);
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
          disabled={busy || !currentPassword || !newPassword || !confirmPassword}
        >
          {busy ? 'Changing…' : 'Change Password'}
        </button>
      </form>
    </div>
  );
}
