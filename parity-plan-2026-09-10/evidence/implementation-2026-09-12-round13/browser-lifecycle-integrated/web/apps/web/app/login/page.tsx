'use client';
import { useRef, useState } from 'react';
import { post, ApiError } from '../../lib/api';
import { useOperationLease } from '../../components/useOperationLease';

export default function LoginPage() {
  const [coCode, setCoCode] = useState('01');
  const [loginName, setLoginName] = useState('');
  const [password, setPassword] = useState('');
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const busyRef = useRef(false);
  const { beginOperation } = useOperationLease();

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    if (busyRef.current) return;
    const isCurrent = beginOperation();
    if (!isCurrent()) return;
    busyRef.current = true;
    setErr('');
    setBusy(true);
    try {
      const result = await post<{ forcedReset?: boolean }>('/auth/login', {
        coCode,
        loginName,
        password,
      });
      if (!isCurrent()) return;
      window.location.assign(result.forcedReset ? '/password-change' : '/select');
    } catch (e) {
      if (!isCurrent()) return;
      const m = e instanceof ApiError ? e.body?.error || e.message : 'login failed';
      setErr(m === 'invalid-credentials' ? 'Invalid company / user / password' : m);
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
        <h1>DataCareNext</h1>
        <p className="muted" style={{ textAlign: 'center', marginTop: -8 }}>
          Jewellery ERP — sign in
        </p>
        {err && <div className="msg err">{err}</div>}
        <div className="field">
          <label>Company Code</label>
          <input
            aria-label="Company Code"
            value={coCode}
            onChange={(e) => setCoCode(e.target.value)}
            autoFocus
          />
        </div>
        <div className="field">
          <label>User</label>
          <input
            aria-label="User"
            value={loginName}
            onChange={(e) => setLoginName(e.target.value)}
          />
        </div>
        <div className="field">
          <label>Password</label>
          <input
            aria-label="Password"
            type="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
          />
        </div>
        <button className="primary" style={{ width: '100%', marginTop: 8 }} disabled={busy}>
          {busy ? 'Signing in…' : 'Sign In'}
        </button>
      </form>
    </div>
  );
}
