'use client';
import { useEffect, useRef, useState, type KeyboardEvent } from 'react';
import { get, post, ApiError } from '../lib/api';

/**
 * Company → Company, Ctrl+R "Reset Compnay" (MS_COMPANY.cs:6477-6480). The desktop ticks a box that wipes the company
 * at the next login (Module_Schm.cs:60-230, MS_LOGIN.cs:581-593); the web clears the data and keeps the company,
 * immediately, behind a second confirmation, for administrators only (docs/handbook/web/desktop-adaptations.md "Company reset"). The server
 * enforces every check; this panel only explains and collects them.
 */
type Kind = 'vouchers' | 'masters' | 'years';
type TableCount = { table: string; rows: number };
interface Plan {
  coCode: string;
  coName: string;
  keptYear: string | null;
  kept: TableCount[];
  deleted: (TableCount & { kind: Kind })[];
  kinds: Record<Kind, number>;
  keptTotal: number;
  deletedTotal: number;
  reasonMinLength: number;
  /** Ties the reset to these counts: the server refuses it when the data changed since. */
  fingerprint: string;
}
type Result = Plan & {
  archived: number;
  restoredDefaults: number;
  revokedSessions: number;
  ownCompany: boolean;
};

const KINDS: [Kind, string][] = [
  ['vouchers', 'Vouchers, stock, tags, postings and other entries'],
  ['masters', 'Masters (accounts, items, groups and the rest; the defaults are put back)'],
  ['years', 'Other financial years'],
];
const ARCHIVE_NOTE =
  'The deleted data is kept in a protected archive; support can recover it if needed.';
const errorText = (e: unknown) =>
  e instanceof ApiError
    ? String(e.body?.message || e.body?.error || e.message)
    : String((e as Error).message);

function CountList({ counts, label }: { counts: Plan; label: string }) {
  return (
    <ul aria-label={label}>
      {KINDS.map(([kind, text]) => (
        <li key={kind} data-kind={kind}>
          {text}: <strong>{counts.kinds[kind] ?? 0}</strong>
        </li>
      ))}
      <li>
        Total rows: <strong>{counts.deletedTotal}</strong>
      </li>
    </ul>
  );
}

function ConfirmDialog(props: {
  preview: Plan;
  onCancel: () => void;
  onDone: (result: Result) => void;
  onStale: (message: string) => void;
}) {
  const { preview } = props;
  const ref = useRef<HTMLDialogElement>(null);
  const [code, setCode] = useState('');
  const [name, setName] = useState('');
  const [password, setPassword] = useState('');
  const [reason, setReason] = useState('');
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  useEffect(() => {
    const dialog = ref.current;
    if (!dialog) return;
    dialog.showModal(); // the rest of the page is inert while it is open
    return () => dialog.close();
  }, []);
  const ready =
    code === preview.coCode &&
    name === preview.coName &&
    password.length > 0 &&
    reason.trim().length >= preview.reasonMinLength &&
    !busy;
  const trap = (event: KeyboardEvent<HTMLDialogElement>) => {
    if (event.key !== 'Tab') return;
    const controls = Array.from(
      event.currentTarget.querySelectorAll<HTMLElement>(
        'button:not([disabled]), input:not([disabled]), textarea:not([disabled])',
      ),
    );
    const first = controls[0];
    const last = controls.at(-1);
    if (!first || !last) return;
    const active = document.activeElement;
    if (event.shiftKey && (active === first || !event.currentTarget.contains(active))) {
      event.preventDefault();
      last.focus();
    } else if (!event.shiftKey && (active === last || !event.currentTarget.contains(active))) {
      event.preventDefault();
      first.focus();
    }
  };
  const submit = async () => {
    setBusy(true);
    setError('');
    try {
      props.onDone(
        await post<Result>(`/companies/${encodeURIComponent(preview.coCode)}/reset`, {
          coCode: code,
          coName: name,
          password,
          reason,
          fingerprint: preview.fingerprint,
        }),
      );
    } catch (e) {
      // The data moved since the preview: show the new counts before anything else is typed.
      if (e instanceof ApiError && e.body?.code === 'stale-preview')
        return props.onStale(errorText(e));
      setError(errorText(e));
      setBusy(false);
    }
  };
  return (
    <dialog
      ref={ref}
      aria-labelledby="company-reset-confirm-title"
      onKeyDown={trap}
      onCancel={(event) => {
        event.preventDefault();
        if (!busy) props.onCancel();
      }}
      style={{ maxWidth: 520, padding: 20, borderRadius: 8 }}
    >
      <h2 id="company-reset-confirm-title">Confirm company reset</h2>
      <p>
        This deletes {preview.deletedTotal} rows of company {preview.coCode} — {preview.coName}. The
        company, its settings, books, users, locations and year {preview.keptYear ?? '—'} stay.{' '}
        {ARCHIVE_NOTE} Type the company code and name exactly as shown to confirm.
      </p>
      <label htmlFor="company-reset-code">Company code ({preview.coCode})</label>
      <input
        id="company-reset-code"
        autoFocus
        autoComplete="off"
        value={code}
        onChange={(e) => setCode(e.target.value)}
      />
      <label htmlFor="company-reset-name">Company name ({preview.coName})</label>
      <input
        id="company-reset-name"
        autoComplete="off"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />
      <label htmlFor="company-reset-password">Your password</label>
      <input
        id="company-reset-password"
        type="password"
        autoComplete="current-password"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />
      <label htmlFor="company-reset-reason">
        Reason (at least {preview.reasonMinLength} characters)
      </label>
      <textarea
        id="company-reset-reason"
        rows={3}
        maxLength={500}
        value={reason}
        onChange={(e) => setReason(e.target.value)}
      />
      {error && (
        <p role="alert" className="msg">
          {error}
        </p>
      )}
      <div className="row">
        <button type="button" disabled={busy} onClick={props.onCancel}>
          Cancel
        </button>
        <button type="button" className="danger" disabled={!ready} onClick={submit}>
          {busy ? 'Clearing…' : `Clear all data of ${preview.coCode} — ${preview.coName}`}
        </button>
      </div>
    </dialog>
  );
}

export function CompanyResetPanel(props: {
  coCode: string;
  onClose: () => void;
  /** After a successful reset: the page reloads its list, or the whole app when it was the open company. */
  onReset: (ownCompany: boolean) => void;
}) {
  const [admin, setAdmin] = useState<boolean | null>(null);
  const [preview, setPreview] = useState<Plan | null>(null);
  const [error, setError] = useState('');
  const [confirming, setConfirming] = useState(false);
  const [result, setResult] = useState<Result | null>(null);
  const [stale, setStale] = useState('');
  const [reload, setReload] = useState(0);
  useEffect(() => {
    let active = true;
    void get<{ isAdmin: boolean }>('/me')
      .then((me) => active && setAdmin(Boolean(me.isAdmin)))
      .catch(() => active && setAdmin(false));
    return () => {
      active = false;
    };
  }, []);
  useEffect(() => {
    if (!admin || !props.coCode) return;
    let active = true;
    setPreview(null);
    setError('');
    void get<Plan>(`/companies/${encodeURIComponent(props.coCode)}/reset/preview`)
      .then((value) => active && setPreview(value))
      .catch((e) => active && setError(errorText(e)));
    return () => {
      active = false;
    };
  }, [admin, props.coCode, reload]);
  return (
    <section
      className="panel"
      role="dialog"
      aria-label="Reset Company"
      onKeyDown={(e) => {
        if (e.key === 'Escape' && !confirming) props.onClose();
      }}
    >
      <strong>Reset Company</strong>
      {admin === false && (
        <p>
          Only an administrator can reset a company. On the desktop this box appears only for a few
          licences. Nothing has been changed.
        </p>
      )}
      {admin && stale && !result && (
        <p role="alert" className="msg">
          {stale}
        </p>
      )}
      {admin && error && (
        <p role="alert" className="msg">
          {error}
        </p>
      )}
      {admin && !preview && !error && !result && <p role="status">Counting records…</p>}
      {result && (
        <div data-testid="company-reset-result">
          <p role="status">
            Company {result.coCode} — {result.coName} has been cleared: {result.deletedTotal} rows
            deleted and archived, {result.restoredDefaults} default master rows put back,{' '}
            {result.revokedSessions} other sign-ins ended.
          </p>
          <CountList counts={result} label="Deleted" />
        </div>
      )}
      {admin && preview && !result && (
        <>
          <p>
            Resetting company <strong>{preview.coCode}</strong> — <strong>{preview.coName}</strong>{' '}
            clears its data. It keeps the company details and settings, books and the accounts they
            post to, users and rights, locations and the financial year{' '}
            <strong>{preview.keptYear ?? '—'}</strong> ({preview.keptTotal} rows), and puts back the
            default masters a new company gets. It deletes:
          </p>
          <CountList counts={preview} label="Will be deleted" />
          <p data-testid="company-reset-archive">
            This cannot be undone from this screen. {ARCHIVE_NOTE} Other companies are not touched.
          </p>
          <button type="button" className="danger" onClick={() => setConfirming(true)}>
            Reset company…
          </button>
        </>
      )}
      <button type="button" autoFocus onClick={props.onClose}>
        Close
      </button>
      {confirming && preview && (
        <ConfirmDialog
          preview={preview}
          onCancel={() => setConfirming(false)}
          onStale={(message) => {
            setConfirming(false);
            setStale(message);
            setReload((n) => n + 1);
          }}
          onDone={(value) => {
            setConfirming(false);
            setResult(value);
            props.onReset(value.ownCompany);
          }}
        />
      )}
    </section>
  );
}
