'use client';
import { useCallback, useEffect, useRef, useState, type KeyboardEvent } from 'react';
import { useRouter } from 'next/navigation';
import { del, get, post, ApiError } from '../../../../lib/api';
import { useScreenEscape, type ScreenKeyEvent } from '../../../../lib/screenEscape';
import {
  passwordReasonText,
  rightsScreenVisible,
  typedUserName,
  USER_NAME_MAX,
  USER_TEXT,
  USER_TYPES,
  userTypeOf,
  type UserType,
} from '../../../../lib/userCreate';
import { UserRightsGrid } from '../../../../components/UserRightsGrid';

interface UserRow {
  loginName: string;
  role: string;
  coCode: string;
}
type Box = 'name' | 'oldPassword' | 'newPassword' | 'confirmPassword' | 'userType';
/** The tab order of the form (MS_USER designer TabIndex 0-4, :1067-1098); Enter walks it and then Save (TabIndex 5). */
const ORDER: Box[] = ['name', 'oldPassword', 'newPassword', 'confirmPassword', 'userType'];
const LABEL: Record<Box, string> = {
  name: 'Create New User',
  oldPassword: 'Old Password',
  newPassword: 'New Password',
  confirmPassword: 'Confirm Password',
  userType: 'User Type',
};
const same = (a: string, b: string) => a.toUpperCase() === b.toUpperCase();

/**
 * User Create (desktop MS_USER, Company → User Create), laid out as the desktop form: Create New User, Old Password, New
 * Password, Confirm Password and User Type down the form, the User Name box of existing users beside them, and Save,
 * Print, Cancel, Delete and Exit along the bottom.
 *
 * - Typed letters are upper-cased and the apostrophe refused (MS_USER_KeyPress, :1786-1799); Enter moves on, but not from
 *   a blank name (:2153-2203, :2256-2263); Esc and Exit leave the screen (:1772-1810); Alt+S/P/C/D/X are the buttons.
 * - Leaving Create New User refuses an existing name unless a user was picked in User Name ("This User Name already
 *   Exist.Please Change User Name...", :2131-2150); a name that exists then selects its User Type (:2478-2498).
 *   Leaving Old Password blank for an existing user says "Please Insert Old Password" (:2222-2236); leaving Confirm
 *   Password different from New Password says "Password Not Match" and clears it (:2205-2220).
 * - Save, Delete and Print answer with the desktop's texts (:1820-2093); Print has no report on the desktop either.
 * - D36: the rights grid and Update User Right are hidden in the Lite edition (:1489-1495).
 *
 * Deliberate differences: a wrong old password is reported at Save (no endpoint answers "is this the password?");
 * a blank New Password in edit mode keeps the current one (the desktop would store a blank password); F1 in Old
 * Password does not show the stored password; Delete deactivates (D35); passwords follow D34.
 */
export default function UserCreatePage() {
  const router = useRouter();
  const [users, setUsers] = useState<UserRow[]>([]);
  const [showRights, setShowRights] = useState(false);
  const [values, setValues] = useState({
    name: '',
    oldPassword: '',
    newPassword: '',
    confirmPassword: '',
  });
  const [userType, setUserType] = useState<UserType>('User');
  const [entryMode, setEntryMode] = useState<'A' | 'E'>('A');
  const [picked, setPicked] = useState('');
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const [resetUser, setResetUser] = useState('');
  const [resetPassword, setResetPassword] = useState('');
  const boxes = useRef<Partial<Record<Box, HTMLInputElement | HTMLSelectElement | null>>>({});
  const saveRef = useRef<HTMLButtonElement>(null);
  /** The name box's Validating refused: like the desktop, the refusal also stops Save and Delete. */
  const nameRefused = useRef(false);

  const focusBox = (box: Box, select = false) =>
    setTimeout(() => {
      const el = boxes.current[box];
      el?.focus();
      if (select && el instanceof HTMLInputElement) el.select();
    }, 0);
  const say = useCallback((kind: 'ok' | 'err', text: string) => setMsg({ kind, text }), []);

  /** CLEAR_DATA / BtnCancel_Click (:2095-2117): blank boxes, the list read again, type User, add mode, cursor in name. */
  const clear = useCallback(async () => {
    setValues({ name: '', oldPassword: '', newPassword: '', confirmPassword: '' });
    setUserType('User');
    setEntryMode('A');
    setPicked('');
    nameRefused.current = false;
    try {
      setUsers(await get<UserRow[]>('/admin/users'));
    } catch (error) {
      say(
        'err',
        error instanceof ApiError && error.status === 403
          ? USER_TEXT.NO_RIGHTS
          : 'Failed to load users',
      );
    }
    focusBox('name');
  }, [say]);

  useEffect(() => {
    void clear();
    get<{ edition?: { code?: string } | null }>('/me')
      .then((me) => setShowRights(rightsScreenVisible(me?.edition)))
      .catch(() => setShowRights(false));
  }, [clear]);

  const set = (key: keyof typeof values, value: string) =>
    setValues((v) => ({ ...v, [key]: value }));
  const existing = (name: string) => users.find((u) => same(u.loginName, name.trim()));

  /** tUserName_Validating then tUserName_LostFocus. */
  function leaveName() {
    const name = values.name.trim();
    const found = name ? existing(name) : undefined;
    nameRefused.current = false;
    if (found && entryMode !== 'E') {
      nameRefused.current = true;
      say('err', USER_TEXT.NAME_EXISTS);
      focusBox('name', true);
      return;
    }
    if (found) setUserType(userTypeOf(found.role));
    else setEntryMode('A');
  }

  /** tOldPasword_Validating: an existing user's old password may not be left blank. */
  function leaveOldPassword() {
    if (entryMode === 'E' && existing(values.name) && !values.oldPassword) {
      say('err', USER_TEXT.OLD_PASSWORD_REQUIRED);
      focusBox('oldPassword');
    }
  }

  /** tConPasword_Validating: Confirm Password must equal New Password, else it is cleared. */
  function leaveConfirm() {
    if (values.newPassword !== values.confirmPassword) {
      say('err', USER_TEXT.PASSWORD_MISMATCH);
      set('confirmPassword', '');
      focusBox('confirmPassword');
    }
  }

  const failure = (error: unknown) => {
    const body = error instanceof ApiError ? (error.body as any) : null;
    if (error instanceof ApiError && error.status === 403) return say('err', USER_TEXT.NO_RIGHTS);
    if (body?.error === 'weak-password') {
      say('err', passwordReasonText(body.reasons));
      return focusBox('newPassword');
    }
    say('err', String(body?.message ?? body?.error ?? (error as Error)?.message ?? error));
    const field = body?.field as string | undefined;
    if (field === 'loginName') focusBox('name', true);
    else if (field && field in LABEL) focusBox(field as Box, true);
  };

  async function save() {
    setMsg(null);
    if (nameRefused.current) return say('err', USER_TEXT.NAME_EXISTS);
    const name = values.name.trim();
    if (!name) {
      say('err', USER_TEXT.NAME_REQUIRED);
      return focusBox('name');
    }
    if (values.newPassword !== values.confirmPassword) {
      say('err', USER_TEXT.PASSWORD_MISMATCH);
      return focusBox('confirmPassword');
    }
    const found = existing(name);
    setBusy(true);
    try {
      if (entryMode === 'E' && found)
        await post(`/admin/users/${encodeURIComponent(found.loginName)}/update`, {
          oldPassword: values.oldPassword,
          newPassword: values.newPassword,
          confirmPassword: values.confirmPassword,
          userType,
        });
      else
        await post('/admin/users', {
          loginName: name,
          password: values.newPassword,
          confirmPassword: values.confirmPassword,
          userType,
        });
      await clear();
      say('ok', USER_TEXT.CREATED);
    } catch (error) {
      failure(error);
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    setMsg(null);
    if (nameRefused.current) return say('err', USER_TEXT.NAME_EXISTS);
    const name = values.name.trim();
    if (!name) return say('err', USER_TEXT.SELECT_FOR_DELETE);
    if (!window.confirm(USER_TEXT.DELETE_CONFIRM)) return;
    setBusy(true);
    try {
      await del(`/admin/users/${encodeURIComponent(existing(name)?.loginName ?? name)}`);
      await clear();
      say('ok', USER_TEXT.DELETED);
    } catch (error) {
      failure(error);
    } finally {
      setBusy(false);
    }
  }

  /** BtnPrint_Click (:1811-1818) checks the print right and prints nothing: MS_USER has no report. */
  function print() {
    setMsg(null);
  }

  async function resetPasswordForUser() {
    if (!resetUser || !resetPassword) return;
    setBusy(true);
    try {
      await post(`/admin/users/${encodeURIComponent(resetUser)}/password-reset`, {
        newPassword: resetPassword,
      });
      say(
        'ok',
        `Password reset for "${resetUser}"; active sessions were revoked and a change is required at login.`,
      );
      setResetUser('');
      setResetPassword('');
    } catch (error) {
      failure(error);
    } finally {
      setBusy(false);
    }
  }

  function onBoxKeyDown(event: KeyboardEvent<HTMLElement>, box: Box) {
    if (event.key !== 'Enter') return;
    event.preventDefault();
    if (box === 'name' && !values.name.trim()) return;
    const next = ORDER[ORDER.indexOf(box) + 1];
    if (next) boxes.current[next]?.focus();
    else saveRef.current?.focus();
  }

  function onScreenKeyDown(event: ScreenKeyEvent & { altKey?: boolean; code?: string }) {
    if (event.defaultPrevented) return;
    if (event.key === 'Escape') {
      event.preventDefault();
      router.back();
      return;
    }
    if (!event.altKey) return;
    const action = {
      KeyS: save,
      KeyP: print,
      KeyC: clear,
      KeyD: remove,
      KeyX: () => router.back(),
    }[event.code ?? ''];
    if (!action) return;
    event.preventDefault();
    void action();
  }
  const screenRef = useScreenEscape<HTMLDivElement>(onScreenKeyDown);

  const password = (box: 'oldPassword' | 'newPassword' | 'confirmPassword', onBlur: () => void) => (
    <input
      id={`user-${box}`}
      type="password"
      autoComplete={box === 'oldPassword' ? 'current-password' : 'new-password'}
      ref={(el) => {
        boxes.current[box] = el;
      }}
      value={values[box]}
      style={{ width: 200 }}
      onChange={(e) => set(box, e.target.value)}
      onBlur={onBlur}
      onKeyDown={(e) => onBoxKeyDown(e, box)}
    />
  );
  const row = (box: Box, control: React.ReactNode) => (
    <div className="row" style={{ alignItems: 'center', gap: 8, marginBottom: 6 }}>
      <label htmlFor={`user-${box}`} style={{ width: 140 }}>
        {LABEL[box]}
      </label>
      {control}
    </div>
  );

  return (
    <div ref={screenRef} onKeyDown={onScreenKeyDown}>
      <h1>User Create</h1>
      {msg && (
        <div className={`msg ${msg.kind}`} role={msg.kind === 'err' ? 'alert' : 'status'}>
          {msg.text}
        </div>
      )}
      <div className="panel" style={{ display: 'flex', gap: 32, flexWrap: 'wrap' }}>
        <div>
          {row(
            'name',
            <input
              id="user-name"
              ref={(el) => {
                boxes.current.name = el;
              }}
              value={values.name}
              maxLength={USER_NAME_MAX}
              autoComplete="off"
              style={{ width: 200 }}
              onChange={(e) => {
                nameRefused.current = false;
                set('name', typedUserName(e.target.value));
              }}
              onBlur={leaveName}
              onKeyDown={(e) => onBoxKeyDown(e, 'name')}
            />,
          )}
          {row('oldPassword', password('oldPassword', leaveOldPassword))}
          {row(
            'newPassword',
            password('newPassword', () => {}),
          )}
          {row('confirmPassword', password('confirmPassword', leaveConfirm))}
          {row(
            'userType',
            <select
              id="user-userType"
              ref={(el) => {
                boxes.current.userType = el;
              }}
              value={userType}
              style={{ width: 200 }}
              onChange={(e) => setUserType(e.target.value as UserType)}
              onKeyDown={(e) => onBoxKeyDown(e, 'userType')}
            >
              {USER_TYPES.map((t) => (
                <option key={t}>{t}</option>
              ))}
            </select>,
          )}
        </div>
        <div className="row" style={{ alignItems: 'center', gap: 8, alignSelf: 'flex-start' }}>
          <label htmlFor="user-pick">User Name</label>
          {/* cboUser (AddCboItem :1507-1532): a blank entry, then the company's users by name. Picking one is the
              desktop's DISPLAY_DATA: edit mode, boxes cleared, and outside Lite the user's rights grid. */}
          <select
            id="user-pick"
            value={picked}
            style={{ width: 200 }}
            onChange={(e) => {
              setPicked(e.target.value);
              setValues({ name: '', oldPassword: '', newPassword: '', confirmPassword: '' });
              nameRefused.current = false;
              setEntryMode('E');
            }}
          >
            <option value="" />
            {users.map((u) => (
              <option key={u.loginName}>{u.loginName}</option>
            ))}
          </select>
        </div>
      </div>
      {showRights && <UserRightsGrid user={picked} onMessage={say} />}
      <div className="toolbar">
        <button ref={saveRef} className="primary" disabled={busy} onClick={() => void save()}>
          Save
        </button>
        <button className="ghost" disabled={busy} onClick={print}>
          Print
        </button>
        <button className="ghost" disabled={busy} onClick={() => void clear()}>
          Cancel
        </button>
        <button className="ghost" disabled={busy} onClick={() => void remove()}>
          Delete
        </button>
        <button className="ghost" onClick={() => router.back()}>
          Exit
        </button>
      </div>

      {/* Web addition: an administrator sets a temporary password, which forces a change at the next sign-in. It
          replaces the desktop's F1 in Old Password, which showed the stored password (not ported). */}
      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>Users</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>User Name</th>
              <th>User Type</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {users.map((u) => (
              <tr key={u.loginName}>
                <td>{u.loginName}</td>
                <td>{userTypeOf(u.role)}</td>
                <td>
                  <button
                    className="ghost"
                    onClick={() => {
                      setResetUser(u.loginName);
                      setResetPassword('');
                    }}
                  >
                    Reset password
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
        {resetUser && (
          <div className="row" style={{ alignItems: 'flex-end', marginTop: 8 }}>
            <div className="field">
              <label htmlFor="user-reset">Temporary password for {resetUser}</label>
              <input
                id="user-reset"
                type="password"
                autoComplete="new-password"
                value={resetPassword}
                onChange={(event) => setResetPassword(event.target.value)}
              />
            </div>
            <button
              className="ghost"
              disabled={busy || !resetPassword}
              onClick={resetPasswordForUser}
            >
              Reset and revoke sessions
            </button>
            <button className="ghost" onClick={() => setResetUser('')}>
              Close
            </button>
          </div>
        )}
      </div>
    </div>
  );
}
