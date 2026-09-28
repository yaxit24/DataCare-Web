'use client';

import { Fragment, useEffect, useRef, useState } from 'react';
import { get, post } from '../lib/api';
import type { SavedIncomingReturn } from '../lib/salesReturnForm';
import {
  returnReplayBaseline,
  returnReplayFailure,
  returnReplayFieldId,
  ReturnReplayGuard,
  type ReturnReplayEvent,
} from '../lib/salesReturnReplay';
import {
  readReturnBillReplayState,
  readReturnBillReplayResult,
  returnBillReplayPath,
  returnBillReplayRequest,
  returnBillTotalColumns,
  type ReturnBillReplayState,
  type ReturnBillReplayResult,
  type ReturnBillPhase,
} from '../lib/salesReturnBillReplay';

function display(value: string | null | undefined) {
  if (value === null || value === undefined) return <span className="muted">Not stored</span>;
  return value === '' ? <span className="muted">(blank)</span> : value;
}
function BillComparisons({
  state,
  result,
  changeCount,
  title,
}: {
  state: ReturnBillReplayState;
  result: ReturnBillReplayResult | null;
  changeCount: number;
  title: (id: string) => string;
}) {
  const phases: Array<{ id: string; label: string; phase: ReturnBillPhase | null }> = [
    { id: 'loaded', label: 'Saved amounts', phase: state.phases.loaded },
    { id: 'opened', label: 'On opening', phase: state.phases.opened },
    {
      id: 'preview',
      label: `After ${changeCount} changes`,
      phase: result?.phases.preview ?? state.phases.opened,
    },
  ];
  const sourceRows = [
    'Net amount',
    'Sale tax',
    'Total amount',
    'Cheque',
    'Card',
    'Cash',
    'Kasar',
    'Outstanding',
  ];
  const closing =
    result?.phases.preview.bill.closing ??
    state.phases.opened?.bill.closing ??
    state.phases.loaded?.bill.closing;
  return (
    <>
      <div
        style={{ overflowX: 'auto', maxWidth: '100%' }}
        data-testid="sale-return-bill-replay-saved-amounts"
      >
        <table className="grid">
          <caption>Exact saved amounts</caption>
          <thead>
            <tr>
              <th>Amount</th>
              <th>Saved value</th>
            </tr>
          </thead>
          <tbody>
            {(
              [
                ['RTN_NET_AMT', 'Incoming items'],
                ['NET_AMT', 'Outgoing items'],
                ['TAX_AMT', 'Bill tax'],
                ['RTN_TOT_AMT', 'Payment total'],
                ['TOT_AMT', 'Received total'],
                ['RTN_BILL_OS', 'Payment outstanding'],
                ['BILL_OS', 'Received outstanding'],
              ] as const
            ).map(([key, label]) => (
              <tr key={key}>
                <th scope="row">{label}</th>
                <td data-testid={`sale-return-bill-replay-saved-${key}`}>
                  {display(state.savedHeader[key])}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div
        style={{ overflowX: 'auto', maxWidth: '100%' }}
        data-testid="sale-return-bill-replay-totals"
      >
        <table className="grid">
          <caption>Incoming item totals</caption>
          <thead>
            <tr>
              <th>Field</th>
              <th>On opening</th>
              <th>After {changeCount} changes</th>
            </tr>
          </thead>
          <tbody>
            {returnBillTotalColumns.map((column) => (
              <tr key={column} data-testid={`sale-return-bill-replay-total-${column}`}>
                <th scope="row">{title(returnReplayFieldId(column))}</th>
                <td data-testid={`sale-return-bill-replay-total-${column}-opened`}>
                  {state.phases.opened
                    ? display(state.phases.opened.incomingTotals[String(column)])
                    : 'Unavailable'}
                </td>
                <td data-testid={`sale-return-bill-replay-total-${column}-preview`}>
                  {result?.phases.preview
                    ? display(result.phases.preview.incomingTotals[String(column)])
                    : state.phases.opened
                      ? display(state.phases.opened.incomingTotals[String(column)])
                      : 'Unavailable'}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div
        style={{ overflowX: 'auto', maxWidth: '100%' }}
        data-testid="sale-return-bill-replay-matrix"
      >
        <table className="grid">
          <caption>Bill payment and received amounts</caption>
          <thead>
            <tr>
              <th rowSpan={2}>Bill amount</th>
              {phases.map((p) => (
                <th key={p.label} colSpan={2} scope="colgroup">
                  {p.label}
                </th>
              ))}
            </tr>
            <tr>
              {phases.map((p) => (
                <Fragment key={p.label}>
                  <th>Payment</th>
                  <th>Received</th>
                </Fragment>
              ))}
            </tr>
          </thead>
          <tbody>
            {sourceRows.map((fallback, index) => (
              <tr key={index} data-testid={`sale-return-bill-replay-bill-${index + 1}`}>
                <th scope="row">{state.phases.loaded?.bill.matrix[index + 1]?.[0] || fallback}</th>
                {phases.map((p) => (
                  <Fragment key={p.label}>
                    {[3, 4].map((col) => (
                      <td
                        key={col}
                        data-testid={`sale-return-bill-replay-matrix-${p.id}-${index + 1}-${col}`}
                      >
                        {p.phase ? display(p.phase.bill.matrix[index + 1]?.[col]) : 'Unavailable'}
                      </td>
                    ))}
                  </Fragment>
                ))}
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      {state.phases.loaded && (
        <dl data-testid="sale-return-bill-replay-bill-details">
          <dt>Bill tax</dt>
          <dd>
            {display(state.phases.loaded.bill.matrix[2]?.[1])} ·{' '}
            {display(state.phases.loaded.bill.matrix[2]?.[2])}%
          </dd>
          <dt>Cheque account / number</dt>
          <dd>
            {display(state.phases.loaded.bill.matrix[4]?.[1])} ·{' '}
            {display(state.phases.loaded.bill.matrix[4]?.[2])}
          </dd>
          <dt>Card account</dt>
          <dd>{display(state.phases.loaded.bill.matrix[5]?.[1])}</dd>
        </dl>
      )}
      <p role="status" data-testid="sale-return-bill-replay-closing">
        Closing balance unavailable.{' '}
        {closing?.status === 'unavailable'
          ? closing.reason
          : 'A trusted customer balance is required.'}
      </p>
    </>
  );
}
/** Transient server-owned calculation. No totals, matrix or preview values reach a writer. */
export function SaleReturnBillReplayPanel({
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
  const [observation, setObservation] = useState<ReturnBillReplayState | null>(null);
  const [rowIdentity, setRowIdentity] = useState('');
  const [fieldId, setFieldId] = useState('');
  const [editorText, setEditorText] = useState('');
  const [result, setResult] = useState<ReturnBillReplayResult | null>(null);
  const [events, setEvents] = useState<ReturnReplayEvent[]>([]);
  const [busy, setBusy] = useState(false);
  const pending = useRef(false);
  const [failure, setFailure] = useState<ReturnType<typeof returnReplayFailure> | null>(null);
  const [validation, setValidation] = useState('');
  const [attempted, setAttempted] = useState<ReturnReplayEvent | null>(null);
  const row = observation?.rowReplay.rows.find(
    (candidate) => candidate.rowIdentity === rowIdentity,
  );
  const baseline = row ? returnReplayBaseline(row) : null;
  const preview = result?.preview ?? baseline;
  const cap = row?.fieldCapabilities.find((candidate) => candidate.fieldId === fieldId);
  const entryChanged = editorText !== (preview?.editorTextByField[fieldId] ?? '');
  const canCommit = Boolean(
    observation?.capabilities.canPreviewBill &&
    cap?.allowed &&
    preview &&
    !busy &&
    !failure?.needsReload &&
    events.length < 100,
  );
  const title = (id: string) => {
    const column = observation?.rowReplay.configuration.columns.find(
      (candidate) => candidate.id === id,
    );
    return column?.label || column?.originalLabel || id;
  };

  useEffect(() => {
    const owner = guard.current;
    return () => owner.invalidate();
  }, []);

  function selectRow(state: ReturnBillReplayState, selectedId: string) {
    const selected = state.rowReplay.rows.find((candidate) => candidate.rowIdentity === selectedId);
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
      const state = readReturnBillReplayState(
        await get<unknown>(returnBillReplayPath(document)),
        document,
      );
      if (!guard.current.current(token)) return;
      setObservation(state);
      const first =
        state.rowReplay.rows.find((candidate) =>
          candidate.fieldCapabilities.some((field) => field.allowed),
        ) ?? state.rowReplay.rows[0];
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
      request = returnBillReplayRequest(observation, row, events, event);
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
      const response = await post<unknown>(returnBillReplayPath(document, 'preview'), request);
      reading = true;
      const next = readReturnBillReplayResult(response, observation, row, request);
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
      data-testid="sale-return-bill-replay"
      style={{ minWidth: 0, marginTop: 16 }}
    >
      <h3>Totals and bill preview</h3>
      <p>
        Compare saved amounts, amounts on opening, and the effect of ordered item changes. This
        preview does not save amounts or change payments.
      </p>
      {!open ? (
        <>
          <button
            type="button"
            ref={opener}
            disabled={disabled}
            data-testid="sale-return-bill-replay-open"
            onClick={() => void start()}
          >
            Open totals and bill preview
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
              data-testid="sale-return-bill-replay-close"
              onClick={close}
            >
              Discard preview and close
            </button>
            <button
              type="button"
              className="ghost"
              data-testid="sale-return-bill-replay-reload"
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
              {observation
                ? 'Calculating item totals and bill preview…'
                : 'Loading saved totals and bill values…'}
            </p>
          )}
          {(failure || validation) && (
            <div role="alert" className="msg err" data-testid="sale-return-bill-replay-error">
              {failure?.conflict && (
                <span data-testid="sale-return-bill-replay-conflict">
                  The totals and bill observation changed.{' '}
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
          {observation && observation.rowReplay.rows.length === 0 && (
            <p role="status" data-testid="sale-return-bill-replay-empty">
              This saved return has no incoming items for a totals and bill preview.
            </p>
          )}
          {observation && (
            <>
              {observation.diagnostics.map((diagnostic, index) => (
                <p key={`${diagnostic.code}:${index}`} role="status">
                  {diagnostic.message}
                </p>
              ))}
              {!observation.capabilities.canPreviewBill && (
                <p role="status" data-testid="sale-return-bill-replay-readonly">
                  This return is available for review only. Totals and bill changes cannot be
                  previewed from this observation.
                </p>
              )}
            </>
          )}
          {observation && observation.rowReplay.rows.length > 0 && (
            <>
              <div className="row" style={{ flexWrap: 'wrap', alignItems: 'end' }}>
                <div className="field">
                  <label htmlFor="return-bill-preview-row">Saved item to preview</label>
                  <select
                    id="return-bill-preview-row"
                    data-testid="sale-return-bill-replay-row"
                    value={rowIdentity}
                    disabled={
                      busy || events.length > 0 || entryChanged || Boolean(failure?.needsReload)
                    }
                    onChange={(event) => selectRow(observation, event.target.value)}
                  >
                    {observation.rowReplay.rows.map((candidate) => (
                      <option key={candidate.rowIdentity} value={candidate.rowIdentity}>
                        Saved row {candidate.identity.srNo} ·{' '}
                        {candidate.identity.itCode ?? 'No item'}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="field">
                  <label htmlFor="return-bill-preview-field">Calculation field</label>
                  <select
                    id="return-bill-preview-field"
                    data-testid="sale-return-bill-replay-field"
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
                        {field.allowed && observation.capabilities.canPreviewBill
                          ? ''
                          : ' (read-only)'}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="field">
                  <label htmlFor="return-bill-preview-value">{title(fieldId)} preview entry</label>
                  <input
                    id="return-bill-preview-value"
                    ref={editor}
                    data-testid="sale-return-bill-replay-entry"
                    inputMode="decimal"
                    data-no-advance="true"
                    value={editorText}
                    maxLength={10}
                    disabled={!canCommit}
                    aria-describedby="return-bill-preview-field-reason"
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
                  data-testid="sale-return-bill-replay-commit"
                  onClick={() => void commit()}
                >
                  Preview totals after field change
                </button>
                <button
                  type="button"
                  className="ghost"
                  disabled={busy || !entryChanged || Boolean(failure?.needsReload)}
                  data-testid="sale-return-bill-replay-discard-entry"
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
              <p id="return-bill-preview-field-reason" className="muted">
                {cap?.allowed && observation.capabilities.canPreviewBill
                  ? 'Enter up to 10 characters, then choose Preview totals after field change or press Enter. Tab does not commit a change. A longer saved value stays visible until you deliberately replace it.'
                  : cap?.reason ||
                    'This saved return is available for review only; totals and bill changes cannot be previewed.'}
              </p>
              <p data-testid="sale-return-bill-replay-identity">
                Saved row {row?.identity.srNo} · Saved old row {row?.identity.oldSrNo ?? '—'} ·
                Return instance {row?.identity.vchSrno ?? '—'}
              </p>
              {row?.diagnostics.map((diagnostic, index) => (
                <p key={`${diagnostic.code}:${index}`} role="status">
                  {diagnostic.message}
                </p>
              ))}
              {observation.rowReplay.configuration.diagnostics.map((diagnostic, index) => (
                <p key={`${diagnostic.code}:${index}`} className="muted">
                  {diagnostic.message}
                </p>
              ))}
              {baseline && preview && (
                <div
                  style={{ overflowX: 'auto', maxWidth: '100%' }}
                  data-testid="sale-return-bill-replay-row-values"
                >
                  <table className="grid">
                    <caption>Selected item calculation</caption>
                    <thead>
                      <tr>
                        <th>Field</th>
                        <th>Loaded saved value</th>
                        <th>After {events.length} changes</th>
                      </tr>
                    </thead>
                    <tbody>
                      {row?.fieldCapabilities.map((field) => {
                        const column = String(Number(field.fieldId.slice(-2)));
                        return (
                          <tr
                            key={field.fieldId}
                            data-testid={`sale-return-bill-replay-value-${column}`}
                          >
                            <th scope="row">{title(field.fieldId)}</th>
                            <td>{display(baseline.visible[column])}</td>
                            <td>{display(preview.visible[column])}</td>
                          </tr>
                        );
                      })}
                    </tbody>
                  </table>
                </div>
              )}
              <p role="status" data-testid="sale-return-bill-replay-status">
                {events.length} field change{events.length === 1 ? '' : 's'} previewed in order.
                Saved amounts and payments are unchanged.
              </p>
              {events.length > 0 && (
                <details open data-testid="sale-return-bill-replay-events">
                  <summary>Ordered preview changes ({events.length})</summary>
                  <ol>
                    {events.map((event, index) => (
                      <li key={index}>
                        {title(event.fieldId)}:{' '}
                        {event.editorText.trim() === '' ? '(blank entry)' : event.editorText} ·{' '}
                        {result?.events[index]?.status}
                      </li>
                    ))}
                  </ol>
                </details>
              )}
            </>
          )}
          {observation && (
            <BillComparisons
              state={observation}
              result={result}
              changeCount={events.length}
              title={title}
            />
          )}
        </>
      )}
    </section>
  );
}
