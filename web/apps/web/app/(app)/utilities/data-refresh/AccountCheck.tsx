'use client';
import { useEffect, useRef, useState } from 'react';
import { ApiError, get, post } from '../../../../lib/api';

/**
 * Data Refresh > Account as check-and-repair (owner decision 2026-11-27; MS_UPDATE.cs:2334-2669). The operator picks a
 * voucher family, sees which vouchers' AC_DATA / ROJ_MEL_DATA / TAX_DATA differ from what their own rows post, and
 * applies the repair to those vouchers only. A family not yet verified previews but cannot apply.
 */
export interface AccountFamily {
  id: string;
  title: string;
  operationId: string;
  verified: boolean;
}
interface TableDiff {
  table: string;
  insert: number;
  update: number;
  delete: number;
}
interface TableCheck {
  table: string;
  onlyStored: string[];
  onlyExpected: string[];
  changed: Array<{ key: string; col: string }>;
}
interface VoucherCheck {
  coBook: string;
  vchNo: string;
  vchDate: string | null;
  status: string;
  reason?: string;
  tables: TableCheck[];
  orphanRows?: Record<string, number>;
  warnings?: string[];
}
interface Page {
  summary: Record<string, number>;
  total: number;
  offset: number;
  vouchers: VoucherCheck[];
}
interface Preview {
  previewHash: string;
  applyAvailable: boolean;
  blockedReason: string | null;
  completionText: string | null;
  clean: boolean;
  diffs: TableDiff[];
  requiresConfirmation: string | null;
  authority: { reason: boolean; reauthentication: boolean; backupReference: boolean };
  detail: Page;
}

const REASON_MIN_LENGTH = 12;
const STATUSES = ['match', 'differs', 'missing', 'locked', 'orphan', 'unverified'] as const;
const errorText = (error: unknown, fallback: string) =>
  error instanceof ApiError ? error.body?.message || error.body?.error || fallback : fallback;

function differenceText(v: VoucherCheck): string {
  if (v.orphanRows)
    return Object.entries(v.orphanRows)
      .map(([table, n]) => `${table}: ${n} row(s) without a voucher`)
      .join('; ');
  const tables = v.tables.map((t) => {
    const cols = [...new Set(t.changed.map((c) => c.col))];
    return `${t.table}: ${t.onlyExpected.length} missing, ${t.onlyStored.length} extra, ${
      new Set(t.changed.map((c) => c.key)).size
    } changed${cols.length ? ` (${cols.join(', ')})` : ''}`;
  });
  return [...tables, v.reason ?? '', ...(v.warnings ?? []).map((w) => `Warning: ${w}`)]
    .filter(Boolean)
    .join('; ');
}

export function AccountCheck({
  families,
  disabled,
  onRun,
}: {
  families: AccountFamily[];
  disabled: boolean;
  onRun: () => Promise<void>;
}) {
  const [familyId, setFamilyId] = useState(families[0]?.id ?? '');
  const [preview, setPreview] = useState<Preview | null>(null);
  const [page, setPage] = useState<Page | null>(null);
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [confirmation, setConfirmation] = useState('');
  const [reason, setReason] = useState('');
  const [operatorPassword, setOperatorPassword] = useState('');
  const [backupReference, setBackupReference] = useState('');
  const headingRef = useRef<HTMLHeadingElement>(null);
  const family = families.find((f) => f.id === familyId) ?? null;

  useEffect(() => {
    if (preview && !busy) headingRef.current?.focus();
  }, [preview, busy]);

  async function check() {
    if (!family) return;
    setBusy(true);
    setMessage(null);
    setPreview(null);
    setPage(null);
    try {
      const result = await post<Preview>(
        `/utilities/data-refresh/${family.operationId}/preview`,
        {},
      );
      setPreview(result);
      setPage(result.detail);
      if (result.clean) setMessage({ kind: 'ok', text: 'No records need adjustment.' });
      await onRun();
    } catch (error) {
      setMessage({ kind: 'err', text: errorText(error, 'Check failed') });
    } finally {
      setBusy(false);
    }
  }

  async function turnPage(offset: number) {
    if (!family) return;
    setBusy(true);
    try {
      setPage(
        await get<Page>(
          `/utilities/data-refresh/account/${family.id}/vouchers?offset=${offset}&limit=100`,
        ),
      );
    } catch (error) {
      setMessage({ kind: 'err', text: errorText(error, 'Could not load the voucher list') });
    } finally {
      setBusy(false);
    }
  }

  async function apply() {
    if (!family || !preview) return;
    setBusy(true);
    setMessage(null);
    try {
      const result = await post<{ applied: TableDiff[]; deduplicated: boolean }>(
        `/utilities/data-refresh/${family.operationId}/apply`,
        {
          previewHash: preview.previewHash,
          confirmation,
          reason,
          ...(preview.authority.reauthentication ? { operatorPassword } : {}),
          ...(preview.authority.backupReference ? { backupReference } : {}),
        },
      );
      const count = result.applied.reduce((n, d) => n + d.insert + d.update + d.delete, 0);
      setMessage({
        kind: 'ok',
        text: result.deduplicated
          ? 'This repair had already been applied; nothing was repeated.'
          : `${preview.completionText ?? 'Repaired.'} ${count} posting row(s) repaired.`,
      });
      setPreview(null);
      setPage(null);
      setOperatorPassword('');
      await onRun();
    } catch (error) {
      setMessage({ kind: 'err', text: errorText(error, 'Apply failed') });
    } finally {
      setBusy(false);
    }
  }

  const applyBlocked =
    !preview ||
    Boolean(preview.requiresConfirmation && confirmation !== preview.requiresConfirmation) ||
    (preview.authority.reason && reason.trim().length < REASON_MIN_LENGTH) ||
    (preview.authority.reauthentication && !operatorPassword) ||
    (preview.authority.backupReference && !backupReference.trim());

  return (
    <section className="panel" aria-labelledby="account-check-heading" aria-busy={busy}>
      <h3 id="account-check-heading">Account check and repair</h3>
      <p className="muted">
        For one voucher family, compares each voucher&apos;s AC_DATA, ROJ_MEL_DATA and TAX_DATA with
        what the voucher&apos;s own rows post, then repairs only the vouchers that differ, in one
        audited transaction that keeps the replaced rows. Vouchers in a locked period, postings
        without a voucher and books 888/000 are never changed; clearing dates are kept.
      </p>
      <div className="row">
        <div className="field">
          <label htmlFor="account-family">Voucher family</label>
          <select
            id="account-family"
            value={familyId}
            onChange={(e) => {
              setFamilyId(e.target.value);
              setPreview(null);
              setPage(null);
              setMessage(null);
            }}
          >
            {families.map((f) => (
              <option key={f.id} value={f.id}>
                {f.title}
              </option>
            ))}
          </select>
        </div>
        <button
          type="button"
          className="primary"
          disabled={disabled || busy || !family}
          onClick={check}
        >
          Check vouchers
        </button>
      </div>
      {message && (
        <div className={`msg ${message.kind}`} role={message.kind === 'err' ? 'alert' : 'status'}>
          {message.text}
        </div>
      )}
      {preview && page && family && (
        <>
          <h3 id="account-check-result" ref={headingRef} tabIndex={-1}>
            {family.title} check
          </h3>
          <table className="grid">
            <caption>Vouchers by status</caption>
            <thead>
              <tr>
                {STATUSES.map((s) => (
                  <th key={s} className="num">
                    {s}
                  </th>
                ))}
              </tr>
            </thead>
            <tbody>
              <tr>
                {STATUSES.map((s) => (
                  <td key={s} className="num" data-status={s}>
                    {page.summary[s] ?? 0}
                  </td>
                ))}
              </tr>
            </tbody>
          </table>
          {page.vouchers.length > 0 && (
            <table className="grid" aria-label={`${family.title} vouchers needing attention`}>
              <thead>
                <tr>
                  <th>Book</th>
                  <th>Voucher</th>
                  <th>Date</th>
                  <th>Status</th>
                  <th>Difference</th>
                </tr>
              </thead>
              <tbody>
                {page.vouchers.map((v) => (
                  <tr key={`${v.coBook}/${v.vchNo}`} data-voucher={`${v.coBook}/${v.vchNo}`}>
                    <td>{v.coBook}</td>
                    <td>{v.vchNo}</td>
                    <td>{v.vchDate ?? ''}</td>
                    <td>{v.status}</td>
                    <td>{differenceText(v)}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          )}
          {page.total > page.vouchers.length && (
            <div className="row">
              <button
                type="button"
                disabled={busy || page.offset === 0}
                onClick={() => turnPage(Math.max(0, page.offset - 100))}
              >
                Previous vouchers
              </button>
              <button
                type="button"
                disabled={busy || page.offset + page.vouchers.length >= page.total}
                onClick={() => turnPage(page.offset + 100)}
              >
                Next vouchers
              </button>
            </div>
          )}
          {!preview.applyAvailable && (
            <div className="msg err" role="status">
              Apply not available until verified: {preview.blockedReason}
            </div>
          )}
          {preview.applyAvailable && !preview.clean && (
            <>
              <div className="row">
                <div className="field">
                  <label htmlFor="account-reason">
                    Reason (recorded) — required, min {REASON_MIN_LENGTH} characters
                  </label>
                  <input
                    id="account-reason"
                    value={reason}
                    onChange={(e) => setReason(e.target.value)}
                  />
                </div>
                {preview.requiresConfirmation && (
                  <div className="field">
                    <label htmlFor="account-confirmation">
                      Type <code>{preview.requiresConfirmation}</code> to confirm
                    </label>
                    <input
                      id="account-confirmation"
                      value={confirmation}
                      onChange={(e) => setConfirmation(e.target.value)}
                    />
                  </div>
                )}
              </div>
              <div className="row">
                {preview.authority.backupReference && (
                  <div className="field">
                    <label htmlFor="account-backup">Backup checksum (last 24 hours)</label>
                    <input
                      id="account-backup"
                      value={backupReference}
                      onChange={(e) => setBackupReference(e.target.value)}
                    />
                  </div>
                )}
                {preview.authority.reauthentication && (
                  <div className="field">
                    <label htmlFor="account-password">Confirm your password</label>
                    <input
                      id="account-password"
                      type="password"
                      autoComplete="current-password"
                      value={operatorPassword}
                      onChange={(e) => setOperatorPassword(e.target.value)}
                    />
                  </div>
                )}
              </div>
              <button
                type="button"
                className="primary"
                disabled={busy || Boolean(applyBlocked)}
                onClick={apply}
              >
                Apply {family.title} repair
              </button>
            </>
          )}
        </>
      )}
    </section>
  );
}
