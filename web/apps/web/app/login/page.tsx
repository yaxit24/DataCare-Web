'use client';
import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { post, ApiError } from '../../lib/api';

export default function LoginPage() {
  const router = useRouter();
  const [coCode, setCoCode] = useState('01');
  const [loginName, setLoginName] = useState('');
  const [password, setPassword] = useState('');
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setBusy(true);
    try {
      const result = await post<{ forcedReset?: boolean }>('/auth/login', {
        coCode,
        loginName,
        password,
      });
      router.push(result.forcedReset ? '/password-change' : '/select');
    } catch (e) {
      const m = e instanceof ApiError ? e.body?.error || e.message : 'login failed';
      setErr(m === 'invalid-credentials' ? 'Invalid company / user / password' : m);
    } finally {
      setBusy(false);
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
