'use client';

import { useEffect, useRef, useState } from 'react';
import { get, post } from '../lib/api';
import type { SavedIncomingReturn } from '../lib/salesReturnForm';
import {
  readReturnReplayResult,
  readReturnReplayState,
  returnReplayBaseline,
  returnReplayFailure,
  returnReplayFieldId,
  returnReplayPath,
  returnReplayRequest,
  ReturnReplayGuard,
  type ReturnReplayEvent,
  type ReturnReplayResult,
  type ReturnReplayState,
} from '../lib/salesReturnReplay';

/** Transient completed-cell simulation. Nothing from this component reaches a writer. */
export function SaleReturnReplayPanel({
  document,
  disabled,
  onActivityChange,
  onReload,
}: {
  document: SavedIncomingReturn;
  disabled: boolean;
  onActivityChange: (active: boolean) => boolean | void;
  onReload: () => void;
}) {
  const guard = useRef(new ReturnReplayGuard());
  guard.current.observe(document);
  const opener = useRef<HTMLButtonElement>(null);
  const editor = useRef<HTMLInputElement>(null);
  const [open, setOpen] = useState(false);
  const [observation, setObservation] = useState<ReturnReplayState | null>(null);
  const [rowIdentity, setRowIdentity] = useState('');
  const [fieldId, setFieldId] = useState('');
  const [editorText, setEditorText] = useState('');
  const [result, setResult] = useState<ReturnReplayResult | null>(null);
  const [events, setEvents] = useState<ReturnReplayEvent[]>([]);
  const [busy, setBusy] = useState(false);
  const pending = useRef(false);
  const [failure, setFailure] = useState<ReturnType<typeof returnReplayFailure> | null>(null);
  const [validation, setValidation] = useState('');
  const [attempted, setAttempted] = useState<ReturnReplayEvent | null>(null);
  const row = observation?.rows.find((candidate) => candidate.rowIdentity === rowIdentity);
  const baseline = row ? returnReplayBaseline(row) : null;
  const preview = result?.preview ?? baseline;
  const cap = row?.fieldCapabilities.find((candidate) => candidate.fieldId === fieldId);
  const entryChanged = editorText !== (preview?.editorTextByField[fieldId] ?? '');
  const canCommit = Boolean(
    observation?.capabilities.canPreview &&
    cap?.allowed &&
    preview &&
    !busy &&
    !failure?.needsReload &&
    events.length < 100,
  );
  const title = (id: string) => {
    const column = observation?.configuration.columns.find((candidate) => candidate.id === id);
    return column?.label || column?.originalLabel || id;
  };

  useEffect(() => {
    const owner = guard.current;
    return () => owner.invalidate();
  }, []);

  function selectRow(state: ReturnReplayState, selectedId: string) {
    const selected = state.rows.find((candidate) => candidate.rowIdentity === selectedId);
    const field =
      selected?.fieldCapabilities.find((candidate) => candidate.allowed)?.fieldId ??
      selected?.fieldCapabilities[0]?.fieldId ??
      '';
    setRowIdentity(selectedId);
    setFieldId(field);
    setEditorText(selected?.editorTextByField?.[field] ?? '');
    setResult(null);
    setEvents([]);
    setFailure(null);
    setValidation('');
    setAttempted(null);
  }

  async function start() {
    if (disabled || pending.current) return;
    // The parent validates live metadata/operation state before granting ownership.
    if (onActivityChange(true) === false) return;
    const token = guard.current.begin();
    pending.current = true;
    setBusy(true);
    setOpen(true);
    setFailure(null);
    setValidation('');
    try {
      const state = readReturnReplayState(await get<unknown>(returnReplayPath(document)), document);
      if (!guard.current.current(token)) return;
      setObservation(state);
      const first =
        state.rows.find((candidate) =>
          candidate.fieldCapabilities.some((field) => field.allowed),
        ) ?? state.rows[0];
      selectRow(state, first?.rowIdentity ?? '');
    } catch (error) {
      if (guard.current.current(token)) setFailure(returnReplayFailure(error, true));
    } finally {
      if (guard.current.current(token)) {
        pending.current = false;
        setBusy(false);
      }
    }
  }

  function close() {
    guard.current.invalidate();
    const token = guard.current.begin();
    pending.current = false;
    setBusy(false);
    setOpen(false);
    setObservation(null);
    setResult(null);
    setEvents([]);
    setEditorText('');
    setFailure(null);
    setValidation('');
    setAttempted(null);
    onActivityChange(false);
    requestAnimationFrame(() => {
      if (guard.current.current(token)) opener.current?.focus();
    });
  }

  async function commit() {
    if (!canCommit || pending.current || !observation || !row) return;
    const event = { fieldId, editorText };
    let request;
    try {
      request = returnReplayRequest(observation, row, events, event);
    } catch (error) {
      setValidation(error instanceof Error ? error.message : 'Check the entered number.');
      setAttempted(event);
      return;
    }
    const token = guard.current.begin();
    pending.current = true;
    setBusy(true);
    setFailure(null);
    setValidation('');
    setAttempted(event);
    let reading = false;
    try {
      const response = await post<unknown>(returnReplayPath(document, 'preview'), request);
      reading = true;
      const next = readReturnReplayResult(response, observation, row, request);
      if (!guard.current.current(token)) return;
      setResult(next);
      setEvents(request.events);
      setEditorText(next.preview.editorTextByField[fieldId] ?? '');
      setAttempted(null);
    } catch (error) {
      if (guard.current.current(token)) setFailure(returnReplayFailure(error, reading));
    } finally {
      if (guard.current.current(token)) {
        pending.current = false;
        setBusy(false);
        // A disabled editor is focused after its enabled render, never by a stale callback.
        requestAnimationFrame(() => {
          if (guard.current.current(token)) editor.current?.focus();
        });
      }
    }
  }

  return (
    <section
      className="panel"
      data-testid="sale-return-replay"
      style={{ minWidth: 0, marginTop: 16 }}
    >
      <h3>Calculation preview</h3>
      <p>Preview one saved item's calculation. Saved return amounts are unchanged.</p>
      {!open ? (
        <>
          <button
            type="button"
            ref={opener}
            disabled={disabled}
            data-testid="sale-return-replay-open"
            onClick={() => void start()}
          >
            Open calculation preview
          </button>
          {disabled && (
            <p className="muted">Save or discard metadata changes before opening a preview.</p>
          )}
        </>
      ) : (
        <>
          <div className="toolbar" style={{ flexWrap: 'wrap' }}>
            <button
              type="button"
              className="ghost"
              data-testid="sale-return-replay-close"
              onClick={close}
            >
              Discard preview and close
            </button>
            <button
              type="button"
              className="ghost"
              data-testid="sale-return-replay-reload"
              onClick={() => {
                guard.current.invalidate();
                onReload();
              }}
            >
              Reload saved return and discard preview
            </button>
          </div>
          {busy && (
            <p role="status">
              {observation ? 'Calculating row preview…' : 'Loading saved calculation values…'}
            </p>
          )}
          {(failure || validation) && (
            <div role="alert" className="msg err" data-testid="sale-return-replay-error">
              {failure?.conflict && (
                <span data-testid="sale-return-replay-conflict">
                  The calculation observation changed.{' '}
                </span>
              )}
              {failure?.message || validation}
              {attempted && <span> Your entry is retained: {attempted.editorText}.</span>}
              {failure?.needsReload && (
                <span>
                  {' '}
                  Reload the saved return before another preview. No saved amounts were changed.
                </span>
              )}
            </div>
          )}
          {observation && observation.rows.length === 0 && (
            <p role="status" data-testid="sale-return-replay-empty">
              This saved return has no incoming items to preview.
            </p>
          )}
          {observation && observation.rows.length > 0 && (
            <>
              <div className="row" style={{ flexWrap: 'wrap', alignItems: 'end' }}>
                <div className="field">
                  <label htmlFor="return-preview-row">Saved item to preview</label>
                  <select
                    id="return-preview-row"
                    data-testid="sale-return-replay-row"
                    value={rowIdentity}
                    disabled={
                      busy || events.length > 0 || entryChanged || Boolean(failure?.needsReload)
                    }
                    onChange={(event) => selectRow(observation, event.target.value)}
                  >
                    {observation.rows.map((candidate) => (
                      <option key={candidate.rowIdentity} value={candidate.rowIdentity}>
                        Saved row {candidate.identity.srNo} ·{' '}
                        {candidate.identity.itCode ?? 'No item'}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="field">
                  <label htmlFor="return-preview-field">Calculation field</label>
                  <select
                    id="return-preview-field"
                    data-testid="sale-return-replay-field"
                    value={fieldId}
                    disabled={busy || entryChanged || Boolean(failure?.needsReload)}
                    onChange={(event) => {
                      setFieldId(event.target.value);
                      setEditorText(preview?.editorTextByField[event.target.value] ?? '');
                      setFailure(null);
                      setValidation('');
                      setAttempted(null);
                    }}
                  >
                    {row?.fieldCapabilities.map((field) => (
                      <option key={field.fieldId} value={field.fieldId}>
                        {title(field.fieldId)}
                        {field.allowed ? '' : ' (read-only)'}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="field">
                  <label htmlFor="return-preview-value">{title(fieldId)} preview entry</label>
                  <input
                    id="return-preview-value"
                    ref={editor}
                    data-testid="sale-return-replay-entry"
                    inputMode="decimal"
                    data-no-advance="true"
                    value={editorText}
                    maxLength={10}
                    disabled={!canCommit}
                    aria-describedby="return-preview-field-reason"
                    aria-invalid={Boolean(validation || (failure && attempted))}
                    onFocus={(event) => event.target.select()}
                    onChange={(event) => {
                      setEditorText(event.target.value);
                      setValidation('');
                    }}
                    onKeyDown={(event) => {
                      if (event.key === 'Enter') {
                        event.preventDefault();
                        event.stopPropagation();
                        if (!event.ctrlKey && !event.metaKey) void commit();
                      }
                    }}
                  />
                </div>
                <button
                  type="button"
                  className="primary"
                  disabled={!canCommit}
                  data-testid="sale-return-replay-commit"
                  onClick={() => void commit()}
                >
                  Preview field change
                </button>
                <button
                  type="button"
                  className="ghost"
                  disabled={busy || !entryChanged || Boolean(failure?.needsReload)}
                  data-testid="sale-return-replay-discard-entry"
                  onClick={() => {
                    setEditorText(preview?.editorTextByField[fieldId] ?? '');
                    setValidation('');
                    setFailure(null);
                    setAttempted(null);
                  }}
                >
                  Discard field entry
                </button>
              </div>
              <p id="return-preview-field-reason" className="muted">
                {cap?.allowed
                  ? 'Enter up to 10 characters, then choose Preview field change or press Enter. Tab does not commit a change. A longer saved value stays visible until you deliberately replace it.'
                  : cap?.reason || 'This saved item is available for review only.'}
              </p>
              <p data-testid="sale-return-replay-identity">
                Saved row {row?.identity.srNo} · Saved old row {row?.identity.oldSrNo ?? '—'} ·
                Return instance {row?.identity.vchSrno ?? '—'}
              </p>
              {row?.diagnostics.map((diagnostic, index) => (
                <p key={`${diagnostic.code}:${index}`} role="status">
                  {diagnostic.message}
                </p>
              ))}
              {observation.configuration.diagnostics.map((diagnostic, index) => (
                <p key={`${diagnostic.code}:${index}`} className="muted">
                  {diagnostic.message}
                </p>
              ))}
              {baseline && preview && (
                <div
                  style={{ overflowX: 'auto', maxWidth: '100%' }}
                  data-testid="sale-return-replay-values"
                >
                  <table className="grid">
                    <thead>
                      <tr>
                        <th>Field</th>
                        <th>Loaded saved value</th>
                        <th>Row preview</th>
                      </tr>
                    </thead>
                    <tbody>
                      {observation.configuration.columns
                        .filter(
                          (column) =>
                            column.sourceColumn >= 9 &&
                            column.sourceColumn <= 38 &&
                            ![13, 22, 29].includes(column.sourceColumn),
                        )
                        .map((column) => (
                          <tr
                            key={column.id}
                            data-testid={`sale-return-replay-value-${column.sourceColumn}`}
                          >
                            <th scope="row">{title(returnReplayFieldId(column.sourceColumn))}</th>
                            <td>{baseline.visible[String(column.sourceColumn)]}</td>
                            <td
                              style={{
                                fontWeight:
                                  baseline.visible[String(column.sourceColumn)] !==
                                  preview.visible[String(column.sourceColumn)]
                                    ? 700
                                    : undefined,
                              }}
                            >
                              {preview.visible[String(column.sourceColumn)]}
                            </td>
                          </tr>
                        ))}
                    </tbody>
                  </table>
                </div>
              )}
              <p role="status" data-testid="sale-return-replay-status">
                {events.length} field change{events.length === 1 ? '' : 's'} previewed. Saved return
                amounts are unchanged.
                {result?.aggregateRequired &&
                  ' This is a row calculation; voucher, refund and accounting totals have not been recalculated.'}
              </p>
              {events.length > 0 && (
                <details open data-testid="sale-return-replay-events">
                  <summary>Ordered preview changes ({events.length})</summary>
                  <ol>
                    {events.map((event, index) => (
                      <li key={index}>
                        {title(event.fieldId)}: {event.editorText}
                      </li>
                    ))}
                  </ol>
                </details>
              )}
            </>
          )}
        </>
      )}
    </section>
  );
}
