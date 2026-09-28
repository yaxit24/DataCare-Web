'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';

/**
 * Data Repair console — the desktop's `MS_UPDATE` maintenance screen.
 *
 * The desktop runs each repair immediately on a button press with no preview and no record. Here every
 * operation is preview-then-apply: the operator sees exact per-table insert/update/delete counts and a
 * sample of affected records BEFORE anything is committed, and the run is recorded permanently.
 *
 * A destructive (high/danger) operation additionally requires a typed confirmation, a written reason, the
 * operator's own password, and the checksum of a recent company backup. The server derives those
 * requirements from the operation's risk and returns them on the preview, so this screen asks for exactly
 * what will be demanded rather than guessing.
 */

/** Kept in step with REPAIR_REASON_MIN_LENGTH in the API's dataRepair module. */
const REASON_MIN_LENGTH = 12;

interface Operation {
  id: string;
  title: string;
  description: string;
  desktopSource: string;
  risk: 'low' | 'medium' | 'high' | 'danger';
  tables: string[];
}
interface TableDiff {
  table: string;
  insert: number;
  update: number;
  delete: number;
}
interface Authority {
  confirmation: string | null;
  reason: boolean;
  reauthentication: boolean;
  backupReference: boolean;
}
interface Preview {
  operationId: string;
  previewHash: string;
  diffs: TableDiff[];
  samples: string[];
  clean: boolean;
  risk: string;
  requiresConfirmation: string | null;
  authority: Authority;
}
interface RunRow {
  operation_id: string;
  state: string;
  operator: string;
  reason: string | null;
  backup_reference: string | null;
  counts: TableDiff[] | null;
  applied_counts: TableDiff[] | null;
  created_at: string;
  applied_at: string | null;
}

const RISK_LABEL: Record<string, string> = {
  low: 'Low risk',
  medium: 'Changes data',
  high: 'High risk',
  danger: 'Destructive',
};

export default function DataRepairPage() {
  const [ops, setOps] = useState<Operation[]>([]);
  const [runs, setRuns] = useState<RunRow[]>([]);
  const [preview, setPreview] = useState<Preview | null>(null);
  const [active, setActive] = useState<Operation | null>(null);
  const [confirmation, setConfirmation] = useState('');
  const [reason, setReason] = useState('');
  const [operatorPassword, setOperatorPassword] = useState('');
  const [backupReference, setBackupReference] = useState('');
  const [busy, setBusy] = useState(false);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);

  const loadRuns = useCallback(async () => {
    try {
      const d = await get<{ runs: RunRow[] }>('/utilities/data-repair/runs');
      setRuns(d.runs);
    } catch {
      /* history is informational; a failure here must not block the console */
    }
  }, []);

  useEffect(() => {
    get<{ operations: Operation[] }>('/utilities/data-repair/operations')
      .then((d) => setOps(d.operations))
      .catch(() => setMsg({ kind: 'err', text: 'Failed to load repair operations' }));
    void loadRuns();
  }, [loadRuns]);

  const fail = (e: unknown, fallback: string) =>
    setMsg({
      kind: 'err',
      text: e instanceof ApiError ? e.body?.message || e.body?.error || fallback : fallback,
    });

  async function runPreview(op: Operation) {
    setBusy(true);
    setMsg(null);
    setPreview(null);
    setActive(op);
    setConfirmation('');
    setOperatorPassword('');
    setBackupReference('');
    try {
      const p = await post<Preview>(`/utilities/data-repair/${op.id}/preview`, {});
      setPreview(p);
      if (p.clean)
        setMsg({ kind: 'ok', text: 'Nothing to repair — the data is already consistent' });
      await loadRuns();
    } catch (e) {
      fail(e, 'Preview failed');
    } finally {
      setBusy(false);
    }
  }

  async function runApply() {
    if (!preview || !active) return;
    setBusy(true);
    setMsg(null);
    try {
      const r = await post<{ applied: TableDiff[]; deduplicated: boolean }>(
        `/utilities/data-repair/${active.id}/apply`,
        {
          previewHash: preview.previewHash,
          confirmation,
          reason,
          // Sent only when the server said this operation demands them, so a low-risk repair never
          // transmits a password.
          ...(preview.authority?.reauthentication ? { operatorPassword } : {}),
          ...(preview.authority?.backupReference ? { backupReference } : {}),
        },
      );
      const total = r.applied.reduce((a, d) => a + d.insert + d.update + d.delete, 0);
      setMsg({
        kind: 'ok',
        text: r.deduplicated
          ? 'This repair had already been applied; nothing was repeated'
          : `Repaired ${total} record(s)`,
      });
      setPreview(null);
      setActive(null);
      setReason('');
      setConfirmation('');
      setOperatorPassword('');
      setBackupReference('');
      await loadRuns();
    } catch (e) {
      fail(e, 'Apply failed');
    } finally {
      // The password never survives an attempt, successful or not.
      setOperatorPassword('');
      setBusy(false);
    }
  }

  const total = (d: TableDiff[] | null) =>
    (d ?? []).reduce((a, x) => a + x.insert + x.update + x.delete, 0);

  return (
    <div>
      <h1>
        Data Repair <span className="muted">— rebuild and reconcile derived data (MS_UPDATE)</span>
      </h1>
      <p className="muted">
        Each operation shows exactly what it will change before anything is committed. Every run is
        recorded permanently.
      </p>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      <div className="panel">
        <table className="grid">
          <thead>
            <tr>
              <th>Operation</th>
              <th>Risk</th>
              <th>Tables</th>
              <th>Desktop source</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {ops.map((o) => (
              <tr key={o.id}>
                <td>
                  <b>{o.title}</b>
                  <div className="muted">{o.description}</div>
                </td>
                <td>{RISK_LABEL[o.risk] ?? o.risk}</td>
                <td className="muted">{o.tables.join(', ')}</td>
                <td className="muted">
                  <code>{o.desktopSource}</code>
                </td>
                <td>
                  <button
                    type="button"
                    className="ghost"
                    disabled={busy}
                    onClick={() => runPreview(o)}
                  >
                    Preview
                  </button>
                </td>
              </tr>
            ))}
            {ops.length === 0 && (
              <tr>
                <td colSpan={5} className="muted">
                  No repair operations available.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>

      {preview && active && !preview.clean && (
        <div className="panel">
          <h2>
            {active.title} <span className="muted">— review before applying</span>
          </h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Table</th>
                <th className="num">Insert</th>
                <th className="num">Update</th>
                <th className="num">Delete</th>
              </tr>
            </thead>
            <tbody>
              {preview.diffs.map((d) => (
                <tr key={d.table}>
                  <td>{d.table}</td>
                  <td className="num">{d.insert}</td>
                  <td className="num">{d.update}</td>
                  <td className="num">{d.delete}</td>
                </tr>
              ))}
            </tbody>
          </table>
          {preview.samples.length > 0 && (
            <>
              <h3>Affected records (sample)</h3>
              <ul className="muted">
                {preview.samples.slice(0, 10).map((s) => (
                  <li key={s}>
                    <code>{s}</code>
                  </li>
                ))}
              </ul>
            </>
          )}
          <div className="row">
            <div className="field">
              <label htmlFor="reason">
                Reason (recorded)
                {preview.authority?.reason
                  ? ` — required, min ${REASON_MIN_LENGTH} characters`
                  : ''}
              </label>
              <input
                id="reason"
                value={reason}
                onChange={(e) => setReason(e.target.value)}
                required={preview.authority?.reason}
                aria-describedby="reason-help"
              />
              <span id="reason-help" className="muted">
                Recorded permanently against this run.
              </span>
            </div>
            {preview.requiresConfirmation && (
              <div className="field">
                <label htmlFor="confirmation">
                  Type <code>{preview.requiresConfirmation}</code> to confirm
                </label>
                <input
                  id="confirmation"
                  value={confirmation}
                  onChange={(e) => setConfirmation(e.target.value)}
                />
              </div>
            )}
          </div>
          {(preview.authority?.reauthentication || preview.authority?.backupReference) && (
            <div className="row">
              {preview.authority?.backupReference && (
                <div className="field">
                  <label htmlFor="backupReference">Backup checksum (last 24 hours)</label>
                  <input
                    id="backupReference"
                    value={backupReference}
                    onChange={(e) => setBackupReference(e.target.value)}
                    required
                    aria-describedby="backup-help"
                  />
                  <span id="backup-help" className="muted">
                    The <code>checksum</code> field of a recent backup of this company. Download one
                    from Backup first; the server verifies it exists and is recent.
                  </span>
                </div>
              )}
              {preview.authority?.reauthentication && (
                <div className="field">
                  <label htmlFor="operatorPassword">Confirm your password</label>
                  <input
                    id="operatorPassword"
                    type="password"
                    autoComplete="current-password"
                    value={operatorPassword}
                    onChange={(e) => setOperatorPassword(e.target.value)}
                    required
                    aria-describedby="reauth-help"
                  />
                  <span id="reauth-help" className="muted">
                    Re-entered so an unattended session cannot rewrite history.
                  </span>
                </div>
              )}
            </div>
          )}
          <button
            className="primary"
            disabled={
              busy ||
              Boolean(
                preview.requiresConfirmation && confirmation !== preview.requiresConfirmation,
              ) ||
              Boolean(preview.authority?.reason && reason.trim().length < REASON_MIN_LENGTH) ||
              Boolean(preview.authority?.reauthentication && !operatorPassword) ||
              Boolean(preview.authority?.backupReference && !backupReference.trim())
            }
            onClick={runApply}
          >
            {busy ? 'Applying…' : 'Apply repair'}
          </button>
        </div>
      )}

      <div className="panel">
        <h2>Run history</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>When</th>
              <th>Operation</th>
              <th>State</th>
              <th className="num">Records</th>
              <th>Operator</th>
              <th>Reason</th>
              <th>Backup</th>
            </tr>
          </thead>
          <tbody>
            {runs.map((r, i) => (
              <tr key={`${r.operation_id}-${r.created_at}-${i}`}>
                <td className="muted">{new Date(r.created_at).toLocaleString()}</td>
                <td>{r.operation_id}</td>
                <td>{r.state}</td>
                <td className="num">
                  {r.state === 'applied' ? total(r.applied_counts) : total(r.counts)}
                </td>
                <td>{r.operator}</td>
                <td className="muted">{r.reason ?? ''}</td>
                <td className="muted">
                  {r.backup_reference ? <code>{r.backup_reference.slice(0, 12)}…</code> : ''}
                </td>
              </tr>
            ))}
            {runs.length === 0 && (
              <tr>
                <td colSpan={7} className="muted">
                  No repairs have been run.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
