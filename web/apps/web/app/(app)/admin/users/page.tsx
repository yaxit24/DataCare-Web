'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';

interface UserRow {
  loginName: string;
  role: string;
  coCode: string;
  userUpdate: boolean;
  userDelete: boolean;
  userPrint: boolean;
}

/** Per-row editable state for the rights matrix (mirrors LOGIN_MAST USER_* + LOGIN_CATG). */
type RightsEdit = { catg: string; userUpdate: boolean; userDelete: boolean; userPrint: boolean };

const ROLES = ['ADMIN', 'USER'] as const;
const isAdmin = (role: string) => role.toUpperCase().startsWith('A');
const rowKey = (u: { coCode: string; loginName: string }) => `${u.coCode}/${u.loginName}`;

export default function UsersAdminPage() {
  const { coCode } = useBusinessScope();
  const [rows, setRows] = useState<UserRow[]>([]);
  const [form, setForm] = useState({ loginName: '', password: '', role: 'USER' });
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [showNew, setShowNew] = useState(false);
  const [busy, setBusy] = useState(false);
  // Phase 13 rights matrix: per-user editable USER_UPDATE/USER_DELETE/USER_PRINT + LOGIN_CATG.
  const [rights, setRights] = useState<Record<string, RightsEdit>>({});
  const [savingKey, setSavingKey] = useState<string | null>(null);
  // P1-3 per-form rights matrix (USER_SET Main/Sub × View/Edit/Delete/Print).
  const [catalog, setCatalog] = useState<{ mainMenu: string; subMenu: string }[]>([]);
  const [resetUser, setResetUser] = useState('');
  const [resetPassword, setResetPassword] = useState('');
  const [resetBusy, setResetBusy] = useState(false);
  const [frUser, setFrUser] = useState('');
  const [fr, setFr] = useState<
    Record<string, { view: boolean; edit: boolean; del: boolean; print: boolean }>
  >({});
  const [frBusy, setFrBusy] = useState(false);
  const fkey = (m: string, s: string) => `${m}/${s}`;
  const setFrCell = (
    k: string,
    patch: Partial<{ view: boolean; edit: boolean; del: boolean; print: boolean }>,
  ) =>
    setFr((m) => ({
      ...m,
      [k]: { ...(m[k] ?? { view: false, edit: false, del: false, print: false }), ...patch },
    }));

  async function loadFormRights(user: string) {
    setFrUser(user);
    setMsg(null);
    if (!user) {
      setFr({});
      return;
    }
    try {
      const cat = catalog.length
        ? catalog
        : await get<{ mainMenu: string; subMenu: string }[]>('/admin/form-catalog');
      if (!catalog.length) setCatalog(cat);
      const cur = await get<any[]>(`/admin/users/${encodeURIComponent(user)}/form-rights`);
      const m: Record<string, { view: boolean; edit: boolean; del: boolean; print: boolean }> = {};
      for (const r of cur)
        m[fkey(r.mainMenu, r.subMenu)] = {
          view: !!r.view,
          edit: !!r.edit,
          del: !!r.del,
          print: !!r.print,
        };
      setFr(m);
    } catch (e) {
      setMsg({
        kind: 'err',
        text:
          e instanceof ApiError && e.status === 403
            ? 'Admin access required'
            : 'Failed to load form rights',
      });
    }
  }
  async function saveFormRights() {
    if (!frUser) return;
    setFrBusy(true);
    setMsg(null);
    try {
      const rows = catalog
        .map((c) => ({
          mainMenu: c.mainMenu,
          subMenu: c.subMenu,
          ...(fr[fkey(c.mainMenu, c.subMenu)] ?? {
            view: false,
            edit: false,
            del: false,
            print: false,
          }),
        }))
        .filter((r) => r.view || r.edit || r.del || r.print);
      const r = await post(`/admin/users/${encodeURIComponent(frUser)}/form-rights`, { rows });
      setMsg({
        kind: 'ok',
        text: `Form rights saved for "${frUser}" — ${(r as any).saved} form(s) (none ⇒ no form access)`,
      });
    } catch {
      setMsg({ kind: 'err', text: 'Failed to save form rights' });
    } finally {
      setFrBusy(false);
    }
  }

  const load = useCallback(async () => {
    setMsg(null);
    const list = await get<UserRow[]>('/admin/users');
    setRows(list);
  }, []);

  // Default the new-user company to the active session company (falls back to '01').

  useEffect(() => {
    load().catch((e) => {
      const status = e instanceof ApiError ? e.status : 0;
      setMsg({
        kind: 'err',
        text: status === 403 ? 'Admin access required' : 'Failed to load users',
      });
    });
  }, [load]);

  // Seed the editable rights matrix from the loaded rows (admins normalise to 'ADMIN').
  useEffect(() => {
    const next: Record<string, RightsEdit> = {};
    for (const u of rows) {
      next[rowKey(u)] = {
        catg: isAdmin(u.role) ? 'ADMIN' : 'USER',
        userUpdate: u.userUpdate,
        userDelete: u.userDelete,
        userPrint: u.userPrint,
      };
    }
    setRights(next);
  }, [rows]);

  const editRight = (key: string, patch: Partial<RightsEdit>) =>
    setRights((m) => ({ ...m, [key]: { ...m[key], ...patch } }));

  async function saveRights(u: UserRow) {
    const key = rowKey(u);
    const e = rights[key];
    if (!e) return;
    const effAdmin = isAdmin(e.catg); // admins implicitly hold every right
    setMsg(null);
    setSavingKey(key);
    try {
      await post(`/admin/users/${encodeURIComponent(u.loginName)}/rights`, {
        catg: e.catg,
        userUpdate: effAdmin ? true : e.userUpdate,
        userDelete: effAdmin ? true : e.userDelete,
        userPrint: effAdmin ? true : e.userPrint,
      });
      setMsg({ kind: 'ok', text: `Rights saved for "${u.loginName}"` });
      await load();
    } catch (err) {
      const status = err instanceof ApiError ? err.status : 0;
      setMsg({
        kind: 'err',
        text:
          status === 403 ? 'Admin access required' : `Failed to save rights for "${u.loginName}"`,
      });
    } finally {
      setSavingKey(null);
    }
  }

  async function resetPasswordForUser() {
    if (!resetUser || !resetPassword) return;
    setResetBusy(true);
    setMsg(null);
    try {
      await post(`/admin/users/${encodeURIComponent(resetUser)}/password-reset`, {
        newPassword: resetPassword,
      });
      setMsg({
        kind: 'ok',
        text: `Password reset for "${resetUser}"; active sessions were revoked and a change is required at login.`,
      });
      setResetUser('');
      setResetPassword('');
    } catch (error) {
      const body = error instanceof ApiError ? error.body : null;
      setMsg({
        kind: 'err',
        text:
          body?.error === 'weak-password'
            ? `Weak password: ${(body.reasons ?? []).join(', ')}`
            : `Failed to reset password for "${resetUser}"`,
      });
    } finally {
      setResetBusy(false);
    }
  }
  async function create(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setBusy(true);
    try {
      await post('/admin/users', {
        coCode,
        loginName: form.loginName,
        password: form.password,
        role: form.role,
      });
      setMsg({ kind: 'ok', text: `User "${form.loginName}" created` });
      setForm({ loginName: '', password: '', role: 'USER' });
      setShowNew(false);
      await load();
    } catch (e) {
      const b = e instanceof ApiError ? e.body : null;
      const status = e instanceof ApiError ? e.status : 0;
      const text =
        b?.error === 'duplicate-user'
          ? 'Login name already exists'
          : b?.error === 'missing-or-invalid'
            ? 'Missing/invalid: ' + (b.fields?.join(', ') ?? 'fields')
            : status === 403
              ? 'Admin access required'
              : 'Create failed';
      setMsg({ kind: 'err', text });
    } finally {
      setBusy(false);
    }
  }

  const set = (k: keyof typeof form, v: string) => setForm((f) => ({ ...f, [k]: v }));

  return (
    <div>
      <h1>
        Users &amp; Rights <span className="muted">— LOGIN_MAST</span>
      </h1>

      <div className="toolbar">
        <button className="primary" onClick={() => setShowNew((s) => !s)}>
          {showNew ? 'Cancel' : '+ New user'}
        </button>
        <button
          className="ghost"
          onClick={() => load().catch(() => setMsg({ kind: 'err', text: 'Failed to load users' }))}
        >
          Refresh
        </button>
        <span className="muted">{rows.length} user(s)</span>
      </div>

      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      {showNew && (
        <form className="panel" onSubmit={create}>
          <h2>New user</h2>
          <div className="row">
            <div className="field">
              <label>Company (CO_CODE)</label>
              <input value={coCode} readOnly title="Current authenticated company" />
            </div>
            <div className="field">
              <label>Login name *</label>
              <input
                value={form.loginName}
                autoComplete="off"
                onChange={(e) => set('loginName', e.target.value)}
              />
            </div>
            <div className="field">
              <label>Password * (12+ mixed characters)</label>
              <input
                type="password"
                value={form.password}
                autoComplete="new-password"
                onChange={(e) => set('password', e.target.value)}
              />
            </div>
            <div className="field">
              <label>Role *</label>
              <select value={form.role} onChange={(e) => set('role', e.target.value)}>
                {ROLES.map((r) => (
                  <option key={r} value={r}>
                    {r}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <button className="primary" disabled={busy}>
            {busy ? 'Saving…' : 'Create user'}
          </button>
        </form>
      )}

      {resetUser && (
        <div className="panel">
          <h2>Reset password — {resetUser}</h2>
          <div className="row">
            <div className="field">
              <label>Temporary password (12+ mixed characters)</label>
              <input
                type="password"
                autoComplete="new-password"
                value={resetPassword}
                onChange={(event) => setResetPassword(event.target.value)}
              />
            </div>
            <div className="field" style={{ alignSelf: 'end' }}>
              <button
                className="primary"
                disabled={resetBusy || !resetPassword}
                onClick={resetPasswordForUser}
              >
                {resetBusy ? 'Resetting…' : 'Reset and revoke sessions'}
              </button>
            </div>
            <div className="field" style={{ alignSelf: 'end' }}>
              <button
                className="ghost"
                disabled={resetBusy}
                onClick={() => {
                  setResetUser('');
                  setResetPassword('');
                }}
              >
                Cancel
              </button>
            </div>
          </div>
        </div>
      )}

      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              <th>Login name</th>
              <th>Role</th>
              <th>Company</th>
              <th style={{ textAlign: 'center' }}>Update</th>
              <th style={{ textAlign: 'center' }}>Delete</th>
              <th style={{ textAlign: 'center' }}>Print</th>
              <th>Category</th>
              <th>Rights</th>
            </tr>
          </thead>
          <tbody>
            {rows.map((u) => {
              const key = rowKey(u);
              const e: RightsEdit = rights[key] ?? {
                catg: isAdmin(u.role) ? 'ADMIN' : 'USER',
                userUpdate: u.userUpdate,
                userDelete: u.userDelete,
                userPrint: u.userPrint,
              };
              const effAdmin = isAdmin(e.catg); // admins implicitly hold all rights → all-on/disabled
              const saving = savingKey === key;
              const box = (field: 'userUpdate' | 'userDelete' | 'userPrint') => (
                <input
                  type="checkbox"
                  aria-label={`${field} for ${u.loginName}`}
                  checked={effAdmin ? true : e[field]}
                  disabled={effAdmin || saving}
                  onChange={(ev) =>
                    editRight(key, { [field]: ev.target.checked } as Partial<RightsEdit>)
                  }
                />
              );
              return (
                <tr key={key}>
                  <td>{u.loginName}</td>
                  <td>
                    {u.role}
                    {isAdmin(u.role) && <span className="muted"> (admin)</span>}
                  </td>
                  <td>{u.coCode}</td>
                  <td style={{ textAlign: 'center' }}>{box('userUpdate')}</td>
                  <td style={{ textAlign: 'center' }}>{box('userDelete')}</td>
                  <td style={{ textAlign: 'center' }}>{box('userPrint')}</td>
                  <td>
                    <select
                      aria-label={`Category for ${u.loginName}`}
                      value={effAdmin ? 'ADMIN' : 'USER'}
                      disabled={saving}
                      onChange={(ev) => editRight(key, { catg: ev.target.value })}
                    >
                      <option value="ADMIN">Admin</option>
                      <option value="USER">User</option>
                    </select>
                  </td>
                  <td>
                    <button className="ghost" disabled={saving} onClick={() => saveRights(u)}>
                      {saving ? 'Saving…' : 'Save'}
                    </button>
                    <button
                      className="ghost"
                      disabled={saving}
                      onClick={() => {
                        setResetUser(u.loginName);
                        setResetPassword('');
                      }}
                    >
                      Reset password
                    </button>
                    {effAdmin && <span className="muted"> all rights</span>}
                  </td>
                </tr>
              );
            })}
            {rows.length === 0 && (
              <tr>
                <td colSpan={8} className="muted">
                  No users.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      <div className="panel" style={{ overflow: 'auto' }}>
        <div className="row" style={{ alignItems: 'flex-end' }}>
          <div className="field">
            <label>Form rights for user</label>
            <select value={frUser} onChange={(e) => loadFormRights(e.target.value)}>
              <option value="">— pick a user —</option>
              {rows.map((u) => (
                <option key={rowKey(u)} value={u.loginName}>
                  {u.loginName}
                </option>
              ))}
            </select>
          </div>
          <div className="field muted" style={{ flex: 1, alignSelf: 'center' }}>
            Tick the forms this user may access. Leaving every form unticked means{' '}
            <b>no form access</b>. Administrators are the only explicit all-access bootstrap role.
          </div>
          {frUser && (
            <div className="field" style={{ alignSelf: 'end' }}>
              <button className="primary" disabled={frBusy} onClick={saveFormRights}>
                {frBusy ? 'Saving…' : 'Save form rights'}
              </button>
            </div>
          )}
        </div>
        {frUser && catalog.length > 0 && (
          <table className="grid" style={{ marginTop: 8 }}>
            <thead>
              <tr>
                <th>Main</th>
                <th>Form</th>
                <th style={{ textAlign: 'center' }}>View</th>
                <th style={{ textAlign: 'center' }}>Edit</th>
                <th style={{ textAlign: 'center' }}>Delete</th>
                <th style={{ textAlign: 'center' }}>Print</th>
              </tr>
            </thead>
            <tbody>
              {catalog.map((c) => {
                const k = fkey(c.mainMenu, c.subMenu);
                const e = fr[k] ?? { view: false, edit: false, del: false, print: false };
                const cb = (f: 'view' | 'edit' | 'del' | 'print') => (
                  <input
                    type="checkbox"
                    checked={e[f]}
                    onChange={(ev) => setFrCell(k, { [f]: ev.target.checked } as any)}
                  />
                );
                return (
                  <tr key={k}>
                    <td className="muted">{c.mainMenu}</td>
                    <td>{c.subMenu}</td>
                    <td style={{ textAlign: 'center' }}>{cb('view')}</td>
                    <td style={{ textAlign: 'center' }}>{cb('edit')}</td>
                    <td style={{ textAlign: 'center' }}>{cb('del')}</td>
                    <td style={{ textAlign: 'center' }}>{cb('print')}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        )}
      </div>
    </div>
  );
}
