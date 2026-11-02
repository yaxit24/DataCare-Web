'use client';
import { useCallback, useEffect, useMemo, useState } from 'react';
import { ApiError, get, post } from '../../../../lib/api';

const ORDER = [
  'data-refresh-account',
  'data-refresh-stock',
  'data-refresh-field-update',
  'approval-reconcile',
  'data-refresh-image-data',
  'data-refresh-old-field',
] as const;
const CAPTIONS: Record<(typeof ORDER)[number], string> = {
  'data-refresh-account': 'Account',
  'data-refresh-stock': 'Stock',
  'data-refresh-field-update': 'Field Update',
  'approval-reconcile': 'Approval Adj',
  'data-refresh-image-data': 'Image Data',
  'data-refresh-old-field': 'Old Field',
};

interface Operation {
  id: string;
  title: string;
  description: string;
  desktopSource: string;
  risk: 'low' | 'medium' | 'high' | 'danger';
  tables: string[];
  applyAvailable: boolean;
  blockedReason: string | null;
  completionText: string | null;
}
interface TableDiff {
  table: string;
  insert: number;
  update: number;
  delete: number;
}
interface Preview {
  operationId: string;
  previewHash: string;
  applyAvailable: boolean;
  blockedReason: string | null;
  completionText: string | null;
  diffs: TableDiff[];
  samples: string[];
  clean: boolean;
  authority: {
    confirmation: string | null;
    reason: boolean;
    reauthentication: boolean;
    backupReference: boolean;
  };
}
interface RunRow {
  operation_id: string;
  state: string;
  counts: TableDiff[] | null;
  applied_counts: TableDiff[] | null;
  operator: string;
  created_at: string;
}

const total = (diffs: TableDiff[] | null | undefined) =>
  (diffs ?? []).reduce((n, d) => n + d.insert + d.update + d.delete, 0);
const errorText = (error: unknown, fallback: string) =>
  error instanceof ApiError ? error.body?.message || error.body?.error || fallback : fallback;

export default function DataRefreshPage() {
  const [operations, setOperations] = useState<Operation[]>([]);
  const [runs, setRuns] = useState<RunRow[]>([]);
  const [active, setActive] = useState<Operation | null>(null);
  const [preview, setPreview] = useState<Preview | null>(null);
  const [busy, setBusy] = useState<'loading' | 'preview' | 'apply' | null>('loading');
  const [message, setMessage] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);

  const loadRuns = useCallback(async () => {
    try {
      const result = await get<{ runs: RunRow[] }>('/utilities/data-repair/runs');
      setRuns(result.runs);
    } catch {
      // History is useful evidence, but a history display failure must not change operation behavior.
    }
  }, []);

  useEffect(() => {
    Promise.all([
      get<{ operations: Operation[] }>('/utilities/data-repair/operations'),
      get<{ runs: RunRow[] }>('/utilities/data-repair/runs').catch(() => ({ runs: [] })),
    ])
      .then(([catalog, history]) => {
        setOperations(catalog.operations);
        setRuns(history.runs);
      })
      .catch((error) =>
        setMessage({ kind: 'err', text: errorText(error, 'Failed to load Data Refresh') }),
      )
      .finally(() => setBusy(null));
  }, []);

  const visible = useMemo(() => {
    const byId = new Map(operations.map((operation) => [operation.id, operation]));
    return ORDER.map((id) => ({
      id,
      operation: byId.get(id) ?? null,
      caption: CAPTIONS[id],
    }));
  }, [operations]);

  async function runPreview(operation: Operation) {
    setBusy('preview');
    setActive(operation);
    setPreview(null);
    setMessage(null);
    try {
      const result = await post<Preview>(`/utilities/data-repair/${operation.id}/preview`, {});
      setPreview(result);
      if (result.applyAvailable && result.clean) {
        setMessage({ kind: 'ok', text: 'No records need adjustment.' });
      }
      await loadRuns();
    } catch (error) {
      setMessage({ kind: 'err', text: errorText(error, 'Preview failed') });
    } finally {
      setBusy(null);
    }
  }

  async function runApply() {
    if (!active || !preview || !preview.applyAvailable) return;
    setBusy('apply');
    setMessage(null);
    try {
      const result = await post<{ applied: TableDiff[]; deduplicated: boolean }>(
        `/utilities/data-repair/${active.id}/apply`,
        { previewHash: preview.previewHash },
      );
      setMessage({
        kind: 'ok',
        text: result.deduplicated
          ? 'This repair had already been applied; nothing was repeated.'
          : preview.completionText || `Repaired ${total(result.applied)} record(s).`,
      });
      setPreview(null);
      setActive(null);
      await loadRuns();
    } catch (error) {
      setMessage({ kind: 'err', text: errorText(error, 'Apply failed') });
    } finally {
      setBusy(null);
    }
  }

  return (
    <main aria-busy={busy !== null}>
      <h1>Data Refresh</h1>
      <p className="muted">
        Preview every operation before it runs. Preview is audited. Apply, where available, uses one
        transaction and records the completed run.
      </p>
      <p className="muted">
        The web consistently gates all six actions through the existing admin-only Data Repair
        boundary. The owner-approved Data Refresh caption Print handoff remains tracked as G225; the
        desktop handlers themselves check Print only for Account and Stock.
      </p>

      {busy && (
        <div className="panel" aria-live="polite">
          <progress aria-label="Data Refresh progress" />{' '}
          {busy === 'loading' ? 'Loading…' : busy === 'preview' ? 'Previewing…' : 'Applying…'}
        </div>
      )}
      {message && (
        <div className={`msg ${message.kind}`} role={message.kind === 'err' ? 'alert' : 'status'}>
          {message.text}
        </div>
      )}

      <section className="panel" aria-labelledby="operations-heading">
        <h2 id="operations-heading">Operations</h2>
        <div className="row" role="group" aria-label="Data refresh operations">
          {visible.map(({ id, caption, operation }) => (
            <button
              key={id}
              type="button"
              className="primary"
              disabled={busy !== null || !operation}
              aria-describedby={`${id}-description`}
              onClick={() => operation && runPreview(operation)}
            >
              {caption}
            </button>
          ))}
        </div>
        <div className="grid" style={{ marginTop: 16 }}>
          {visible.map(({ id, caption, operation }) => (
            <div key={id} id={`${id}-description`}>
              <b>{caption}</b>: {operation?.description ?? 'Operation metadata unavailable.'}
            </div>
          ))}
        </div>
      </section>

      {active && preview && (
        <section className="panel" aria-labelledby="preview-heading">
          <h2 id="preview-heading">{CAPTIONS[active.id as (typeof ORDER)[number]]} preview</h2>
          <p>
            <code>{active.desktopSource}</code>
          </p>
          {preview.diffs.length > 0 ? (
            <table className="grid">
              <caption>Exact candidate counts</caption>
              <thead>
                <tr>
                  <th>Table</th>
                  <th className="num">Insert</th>
                  <th className="num">Update</th>
                  <th className="num">Delete</th>
                </tr>
              </thead>
              <tbody>
                {preview.diffs.map((item, index) => (
                  <tr key={`${item.table}-${index}`}>
                    <td>{item.table}</td>
                    <td className="num">{item.insert}</td>
                    <td className="num">{item.update}</td>
                    <td className="num">{item.delete}</td>
                  </tr>
                ))}
              </tbody>
            </table>
          ) : (
            <p>No row changes are classified for this milestone.</p>
          )}
          {preview.samples.length > 0 && (
            <>
              <h3>Classification and sample</h3>
              <ul>
                {preview.samples.slice(0, 20).map((sample, index) => (
                  <li key={`${index}-${sample}`}>
                    <code>{sample}</code>
                  </li>
                ))}
              </ul>
            </>
          )}
          {!preview.applyAvailable && (
            <div className="msg err" role="status">
              Preview only: {preview.blockedReason}
            </div>
          )}
          {preview.applyAvailable && !preview.clean && (
            <button type="button" className="primary" disabled={busy !== null} onClick={runApply}>
              Apply {CAPTIONS[active.id as (typeof ORDER)[number]]}
            </button>
          )}
        </section>
      )}

      <section className="panel" aria-labelledby="history-heading">
        <h2 id="history-heading">Audited history</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>When</th>
              <th>Operation</th>
              <th>State</th>
              <th className="num">Records</th>
              <th>Operator</th>
            </tr>
          </thead>
          <tbody>
            {runs.slice(0, 20).map((run, index) => (
              <tr key={`${run.operation_id}-${run.created_at}-${index}`}>
                <td>{new Date(run.created_at).toLocaleString()}</td>
                <td>{run.operation_id}</td>
                <td>{run.state}</td>
                <td className="num">
                  {total(run.state === 'applied' ? run.applied_counts : run.counts)}
                </td>
                <td>{run.operator}</td>
              </tr>
            ))}
            {runs.length === 0 && (
              <tr>
                <td colSpan={5}>No Data Refresh previews or applies have been recorded.</td>
              </tr>
            )}
          </tbody>
        </table>
      </section>
    </main>
  );
}
