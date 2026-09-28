'use client';
import { Fragment, useEffect, useRef, useState } from 'react';
import {
  get,
  post,
  getPageContextState,
  subscribePageContext,
  capturePageContextTicket,
  assertPageContextTicket,
} from '../lib/api';
import type { SavedIncomingReturn } from '../lib/salesReturnForm';
import { returnReplayBaseline, returnReplayFieldId } from '../lib/salesReturnReplay';
import {
  returnBillTotalColumns,
  type ReturnBillReplayState,
  type ReturnBillPhase,
} from '../lib/salesReturnBillReplay';
import {
  requireReturnLabourPage,
  readReturnLabourReplayState,
  returnLabourReplayPath,
  returnLabourInitialPrefix,
  returnLabourObserveRequest,
  returnLabourAppendRequest,
  readReturnLabourObservation,
  readReturnLabourReplayResult,
  validateReturnLabourRecovery,
  returnLabourFailure,
  returnLabourFields,
  ReturnLabourReplayLease,
  type ReturnLabourReplayState,
  type ReturnLabourPrefix,
  type ReturnLabourObservation,
  type ReturnLabourAppendInput,
  type ReturnLabourField,
} from '../lib/salesReturnLabourReplay';

function display(value: string | null | undefined) {
  if (value === null || value === undefined) return <span className="muted">Not stored</span>;
  return value === '' ? <span className="muted">(blank)</span> : value;
}
function LabourComparisons({
  state,
  result,
  changeCount,
  title,
}: {
  state: ReturnBillReplayState;
  result: ReturnLabourPrefix | null;
  changeCount: number;
  title: (id: string) => string;
}) {
  const phases: Array<{ id: string; label: string; phase: ReturnBillPhase | null }> = [
    { id: 'loaded', label: 'Saved amounts', phase: state.phases.loaded },
    { id: 'opened', label: 'On opening', phase: state.phases.opened },
    {
      id: 'preview',
      label: `After ${changeCount} changes`,
      phase: result?.phase ?? state.phases.opened,
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
    result?.phase.bill.closing ??
    state.phases.opened?.bill.closing ??
    state.phases.loaded?.bill.closing;
  return (
    <>
      <div
        style={{ overflowX: 'auto', maxWidth: '100%' }}
        data-testid="sale-return-labour-replay-saved-amounts"
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
                <td data-testid={`sale-return-labour-replay-saved-${key}`}>
                  {display(state.savedHeader[key])}
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
      <div
        style={{ overflowX: 'auto', maxWidth: '100%' }}
        data-testid="sale-return-labour-replay-totals"
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
              <tr key={column} data-testid={`sale-return-labour-replay-total-${column}`}>
                <th scope="row">{title(returnReplayFieldId(column))}</th>
                <td data-testid={`sale-return-labour-replay-total-${column}-opened`}>
                  {state.phases.opened
                    ? display(state.phases.opened.incomingTotals[String(column)])
                    : 'Unavailable'}
                </td>
                <td data-testid={`sale-return-labour-replay-total-${column}-preview`}>
                  {result?.phase
                    ? display(result.phase.incomingTotals[String(column)])
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
        data-testid="sale-return-labour-replay-matrix"
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
              <tr key={index} data-testid={`sale-return-labour-replay-bill-${index + 1}`}>
                <th scope="row">{state.phases.loaded?.bill.matrix[index + 1]?.[0] || fallback}</th>
                {phases.map((p) => (
                  <Fragment key={p.label}>
                    {[3, 4].map((col) => (
                      <td
                        key={col}
                        data-testid={`sale-return-labour-replay-matrix-${p.id}-${index + 1}-${col}`}
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
        <dl data-testid="sale-return-labour-replay-bill-details">
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
      <p role="status" data-testid="sale-return-labour-replay-closing">
        Closing balance unavailable.{' '}
        {closing?.status === 'unavailable'
          ? closing.reason
          : 'A trusted customer balance is required.'}
      </p>
    </>
  );
}
/** Transient server-owned calculation. No totals, matrix or preview values reach a writer. */
export function SaleReturnLabourReplayPanel({
  document,
  disabled = false,
  onActivityChange,
  onReload,
}: {
  document: SavedIncomingReturn;
  disabled?: boolean;
  onActivityChange: (active: boolean) => boolean;
  onReload: () => void;
}) {
  const lease = useRef(new ReturnLabourReplayLease());
  const documentKey = JSON.stringify([document.scope, document.voucherNo, document.version]);
  lease.current.observe(JSON.stringify([documentKey, disabled]));
  const mounted = useRef(false),
    pending = useRef(false),
    opener = useRef<HTMLButtonElement>(null),
    editor = useRef<HTMLInputElement>(null);
  const [page, setPage] = useState(getPageContextState);
  const [open, setOpen] = useState(false),
    [busy, setBusy] = useState(false);
  const [state, setState] = useState<ReturnLabourReplayState | null>(null);
  const [rowIdentity, setRowIdentity] = useState(''),
    [fieldId, setFieldId] = useState(''),
    [editorText, setEditorText] = useState('');
  const [prefix, setPrefix] = useState<ReturnLabourPrefix | null>(null);
  const [candidate, setCandidate] = useState<ReturnLabourObservation | null>(null);
  const [failure, setFailure] = useState<ReturnType<typeof returnLabourFailure> | null>(null);
  const [validation, setValidation] = useState('');
  const row = state?.billReplay.rowReplay.rows.find((r) => r.rowIdentity === rowIdentity);
  const meta = state?.rows.find((r) => r.rowIdentity === rowIdentity);
  const baseline = row ? returnReplayBaseline(row) : null;
  const preview = prefix?.preview ?? baseline;
  const isCode = returnLabourFields.includes(fieldId as ReturnLabourField);
  const allFields = [...(meta?.labourFields ?? []), ...(row?.fieldCapabilities ?? [])];
  const cap = allFields.find((f) => f.fieldId === fieldId);
  const currentText = (selectedField: string, from = preview) =>
    returnLabourFields.includes(selectedField as ReturnLabourField)
      ? (from?.visible[selectedField.split('.c')[1]!] ?? '')
      : (from?.editorTextByField[selectedField] ?? '');
  const entryChanged = editorText !== currentText(fieldId);
  const editorEligible = Boolean(
    state?.capabilities.canPreview &&
    cap?.allowed &&
    prefix &&
    page.status === 'ready' &&
    !disabled &&
    !failure?.needsReload &&
    prefix.events.length < 100,
  );
  const canEnter = editorEligible && !busy;
  const title = (id: string) => {
    const c = state?.billReplay.rowReplay.configuration.columns.find((c) => c.id === id);
    return c?.label ?? c?.originalLabel ?? id;
  };
  useEffect(() => {
    const mountedLease = lease.current;
    mounted.current = true;
    const unsubscribe = subscribePageContext((next) => {
      if (!mounted.current) return;
      mountedLease.invalidate();
      pending.current = false;
      setBusy(false);
      setCandidate(null);
      setPage(next);
      if (next.status !== 'ready')
        setFailure({
          needsReload: true,
          conflict: true,
          message: next.message ?? 'Reload the page session before continuing.',
        });
    });
    return () => {
      mounted.current = false;
      mountedLease.invalidate();
      pending.current = false;
      unsubscribe();
    };
  }, []);
  function begin() {
    requireReturnLabourPage(getPageContextState(), document);
    const pageTicket = capturePageContextTicket(),
      token = lease.current.begin();
    return () => {
      if (!mounted.current || !lease.current.current(token)) return false;
      try {
        assertPageContextTicket(pageTicket);
        return true;
      } catch {
        return false;
      }
    };
  }
  function selectRow(observation: ReturnLabourReplayState, id: string) {
    const selected = observation.rows.find((r) => r.rowIdentity === id);
    const field =
      selected?.labourFields.find((f) => f.allowed)?.fieldId ??
      selected?.labourFields[0]?.fieldId ??
      '';
    const next = returnLabourInitialPrefix(observation, id);
    setRowIdentity(id);
    setFieldId(field);
    setEditorText(next?.preview.visible[field.split('.c')[1]!] ?? '');
    setPrefix(next);
    setCandidate(null);
    setValidation('');
    setFailure(null);
  }
  async function start() {
    if (disabled || pending.current) return;
    let context;
    try {
      context = requireReturnLabourPage(getPageContextState(), document);
    } catch (error) {
      setValidation(error instanceof Error ? error.message : 'Reload the page session.');
      return;
    }
    if (onActivityChange(true) !== true) return;
    let current: () => boolean;
    try {
      current = begin();
    } catch (error) {
      onActivityChange(false);
      setValidation(error instanceof Error ? error.message : 'Reload the page session.');
      return;
    }
    pending.current = true;
    setOpen(true);
    setBusy(true);
    setFailure(null);
    setValidation('');
    try {
      const response = await get<unknown>(returnLabourReplayPath(document));
      if (!current()) return;
      const observation = readReturnLabourReplayState(response, document, context);
      if (!current()) return;
      setState(observation);
      const first =
        observation.rows.find((r) => r.labourFields.some((f) => f.allowed)) ?? observation.rows[0];
      selectRow(observation, first?.rowIdentity ?? '');
    } catch (error) {
      if (current()) setFailure(returnLabourFailure(error, true));
    } finally {
      if (current()) {
        pending.current = false;
        setBusy(false);
      }
    }
  }
  function close() {
    lease.current.invalidate();
    pending.current = false;
    setBusy(false);
    setOpen(false);
    setState(null);
    setPrefix(null);
    setCandidate(null);
    setRowIdentity('');
    setFieldId('');
    setEditorText('');
    setFailure(null);
    setValidation('');
    onActivityChange(false);
    const token = lease.current.begin();
    try {
      const pageTicket = capturePageContextTicket();
      requestAnimationFrame(() => {
        if (!mounted.current || !lease.current.current(token)) return;
        try {
          assertPageContextTicket(pageTicket);
          opener.current?.focus();
        } catch {
          /* Discard remains available on stale pages; focus does not. */
        }
      });
    } catch {
      /* No focus scheduled without a current page ticket. */
    }
  }
  function changeDraft(nextField: string, nextText: string) {
    lease.current.invalidate();
    pending.current = false;
    setBusy(false);
    setFieldId(nextField);
    setEditorText(nextText);
    setCandidate(null);
    setValidation('');
  }
  async function perform(mode: 'check' | 'commit' | 'enter') {
    if (!canEnter || pending.current || !state || !prefix || !row) return;
    const capturedState = state,
      capturedPrefix = prefix,
      capturedField = fieldId,
      capturedText = editorText,
      capturedRow = rowIdentity;
    let current: () => boolean;
    try {
      current = begin();
    } catch (error) {
      setFailure(returnLabourFailure(error, true));
      return;
    }
    pending.current = true;
    setBusy(true);
    setFailure(null);
    setValidation('');
    let request: ReturnLabourAppendInput | undefined,
      reading = false;
    try {
      let checked = candidate;
      if (isCode) {
        const lookup = returnLabourObserveRequest(
          capturedState,
          capturedRow,
          capturedPrefix,
          capturedField,
          capturedText,
        );
        if (mode === 'check' || mode === 'enter') {
          const response = await post<unknown>(returnLabourReplayPath(document, 'observe'), lookup);
          if (!current()) return;
          reading = true;
          checked = readReturnLabourObservation(response, capturedState, lookup);
          reading = false;
          if (!current()) return;
          setCandidate(checked);
          if (mode === 'check') return;
        } else if (
          !checked ||
          checked.rowIdentity !== capturedRow ||
          checked.prefixVersion !== capturedPrefix.prefixVersion ||
          checked.fieldId !== capturedField ||
          checked.editorText !== capturedText
        ) {
          setValidation('Check this exact labour code before previewing the selection.');
          return;
        }
        request = returnLabourAppendRequest(capturedState, capturedRow, capturedPrefix, {
          kind: 'labourEnter',
          fieldId: capturedField as ReturnLabourField,
          editorText: capturedText,
          observationVersion: checked!.observationVersion,
        });
      } else
        request = returnLabourAppendRequest(capturedState, capturedRow, capturedPrefix, {
          kind: 'moneyLeave',
          fieldId: capturedField,
          editorText: capturedText,
        });
      const response = await post<unknown>(returnLabourReplayPath(document, 'append'), request);
      if (!current()) return;
      reading = true;
      const next = readReturnLabourReplayResult(response, capturedState, request);
      if (!current()) return;
      setPrefix(next.prefix);
      setCandidate(null);
      setEditorText(currentText(capturedField, next.prefix.preview));
    } catch (error) {
      if (!current()) return;
      try {
        if (request) validateReturnLabourRecovery(error, request, capturedPrefix);
        setFailure(returnLabourFailure(error, reading));
      } catch (invalid) {
        setFailure(returnLabourFailure(invalid, true));
      }
    } finally {
      if (current()) {
        pending.current = false;
        setBusy(false);
        requestAnimationFrame(() => {
          if (current()) editor.current?.focus();
        });
      }
    }
  }
  return (
    <section
      className="panel"
      data-testid="sale-return-labour-replay"
      style={{ minWidth: 0, marginTop: 16 }}
    >
      <h3>Labour and bill preview</h3>
      <p>
        Check a labour code, then preview its effect on the selected item, totals and bill. Saved
        amounts and payments remain unchanged.
      </p>
      {!open ? (
        <>
          <button
            type="button"
            ref={opener}
            data-testid="sale-return-labour-replay-open"
            disabled={disabled || page.status !== 'ready'}
            onClick={() => void start()}
          >
            Open labour and bill preview
          </button>
          {(disabled || page.status !== 'ready') && (
            <p className="muted">
              {page.message ??
                'Save or discard metadata changes and load the page session before opening a preview.'}
            </p>
          )}
          {validation && <p role="alert">{validation}</p>}
        </>
      ) : (
        <>
          <div className="toolbar">
            <button type="button" data-testid="sale-return-labour-replay-close" onClick={close}>
              Discard preview and close
            </button>
            <button
              type="button"
              data-testid="sale-return-labour-replay-reload"
              onClick={() => {
                lease.current.invalidate();
                pending.current = false;
                onReload();
              }}
            >
              Reload saved return and discard preview
            </button>
          </div>
          {busy && (
            <p role="status">
              {state
                ? 'Checking the selection and preview…'
                : 'Loading saved labour and bill values…'}
            </p>
          )}
          {(failure || validation) && (
            <div role="alert" className="msg err" data-testid="sale-return-labour-replay-error">
              {failure?.message || validation}
              {failure?.needsReload && (
                <span> Copy the retained entry and reload before continuing.</span>
              )}
            </div>
          )}
          {state && !state.capabilities.canPreview && (
            <p data-testid="sale-return-labour-replay-readonly">
              This saved return is available for inspection only.{' '}
              {state.billReplay.diagnostics.map((d) => d.message).join(' ')}
            </p>
          )}
          {state?.rows.length === 0 && (
            <p data-testid="sale-return-labour-replay-empty">
              This saved return has no incoming rows to preview.
            </p>
          )}
          {state && state.rows.length > 0 && (
            <>
              <div className="toolbar" style={{ flexWrap: 'wrap' }}>
                <div className="field">
                  <label htmlFor="return-labour-row">Saved incoming item</label>
                  <select
                    id="return-labour-row"
                    data-testid="sale-return-labour-replay-row"
                    value={rowIdentity}
                    disabled={
                      busy ||
                      Boolean(prefix?.events.length) ||
                      entryChanged ||
                      Boolean(failure?.needsReload)
                    }
                    onChange={(e) => {
                      lease.current.invalidate();
                      selectRow(state, e.target.value);
                    }}
                  >
                    {state.billReplay.rowReplay.rows.map((r) => (
                      <option key={r.rowIdentity} value={r.rowIdentity}>
                        Saved row {r.identity.srNo} · {r.identity.itCode}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="field">
                  <label htmlFor="return-labour-field">Preview field</label>
                  <select
                    id="return-labour-field"
                    data-testid="sale-return-labour-replay-field"
                    value={fieldId}
                    disabled={busy || Boolean(failure?.needsReload)}
                    onChange={(e) => changeDraft(e.target.value, currentText(e.target.value))}
                  >
                    {allFields.map((f) => (
                      <option key={f.fieldId} value={f.fieldId}>
                        {title(f.fieldId)}
                        {f.allowed && state.capabilities.canPreview ? '' : ' (read-only)'}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="field">
                  <label htmlFor="return-labour-entry">{title(fieldId)} preview entry</label>
                  <input
                    id="return-labour-entry"
                    ref={editor}
                    data-testid="sale-return-labour-replay-entry"
                    data-no-advance="true"
                    inputMode={isCode ? 'text' : 'decimal'}
                    value={editorText}
                    maxLength={isCode ? 2 : 10}
                    disabled={!editorEligible}
                    onFocus={(e) => e.target.select()}
                    onChange={(e) => changeDraft(fieldId, e.target.value)}
                    onKeyDown={(e) => {
                      if (e.key === 'Enter') {
                        e.preventDefault();
                        e.stopPropagation();
                        if (!e.ctrlKey && !e.metaKey && !e.altKey && !e.shiftKey)
                          void perform('enter');
                      }
                    }}
                  />
                </div>
                {isCode && (
                  <button
                    type="button"
                    data-testid="sale-return-labour-replay-check"
                    disabled={!canEnter}
                    onClick={() => void perform('check')}
                  >
                    Check labour code
                  </button>
                )}
                <button
                  type="button"
                  className="primary"
                  data-testid="sale-return-labour-replay-commit"
                  disabled={!canEnter || (isCode && !candidate)}
                  onClick={() => void perform('commit')}
                >
                  {isCode ? 'Preview selection' : 'Preview field change'}
                </button>
                <button
                  type="button"
                  data-testid="sale-return-labour-replay-discard-entry"
                  disabled={busy || !entryChanged || Boolean(failure?.needsReload)}
                  onClick={() => changeDraft(fieldId, currentText(fieldId))}
                >
                  Discard field entry
                </button>
              </div>
              <p className="muted">
                {cap?.allowed
                  ? isCode
                    ? 'Enter an exact one- or two-character code. Check labour code does not change the preview. Preview selection commits it; Enter checks and commits once.'
                    : 'Enter up to 10 characters, then choose Preview field change or press Enter.'
                  : (cap?.reason ?? 'This field is read-only.')}{' '}
                Tab and leaving the field do not commit. Longer saved values remain visible until
                you deliberately replace them.
              </p>
              {candidate && (
                <p role="status" data-testid="sale-return-labour-replay-candidate">
                  Checked code {candidate.selection.LBR_CODE} · category{' '}
                  {candidate.selection.LBR_CATG} · value {candidate.selection.LBR_VAL}. No selection
                  has been committed by this check.
                </p>
              )}
              <p data-testid="sale-return-labour-replay-identity">
                Saved row {row?.identity.srNo} · Saved old row {row?.identity.oldSrNo ?? '—'} ·
                Return instance {row?.identity.vchSrno ?? '—'}
              </p>
              {baseline && preview && (
                <div style={{ overflowX: 'auto' }}>
                  <table className="grid">
                    <caption>Selected item preview</caption>
                    <thead>
                      <tr>
                        <th>Field</th>
                        <th>Loaded saved value</th>
                        <th>After {prefix?.events.length ?? 0} changes</th>
                      </tr>
                    </thead>
                    <tbody>
                      {allFields.map((f) => {
                        const c = f.fieldId.split('.c')[1]!;
                        return (
                          <tr key={f.fieldId} data-testid={`sale-return-labour-replay-value-${c}`}>
                            <th scope="row">{title(f.fieldId)}</th>
                            <td data-testid={`sale-return-labour-replay-value-${c}-loaded`}>
                              {display(baseline.visible[c])}
                            </td>
                            <td data-testid={`sale-return-labour-replay-value-${c}-preview`}>
                              {display(preview.visible[c])}
                            </td>
                          </tr>
                        );
                      })}
                    </tbody>
                  </table>
                </div>
              )}
              <p role="status" data-testid="sale-return-labour-replay-status">
                {prefix?.events.length ?? 0} field changes previewed in order. Saved amounts and
                payments are unchanged.
              </p>
              {!!prefix?.events.length && (
                <details open data-testid="sale-return-labour-replay-events">
                  <summary>Ordered preview changes ({prefix.events.length})</summary>
                  <ol>
                    {prefix.events.map((event, index) => (
                      <li key={index}>
                        {title(event.fieldId)}:{' '}
                        {event.editorText === '' ? '(blank entry)' : event.editorText} ·{' '}
                        {event.kind === 'labourEnter' ? 'resolved selection' : 'field change'}
                      </li>
                    ))}
                  </ol>
                </details>
              )}
            </>
          )}
          {state && (
            <LabourComparisons
              state={state.billReplay}
              result={prefix}
              changeCount={prefix?.events.length ?? 0}
              title={title}
            />
          )}
        </>
      )}
    </section>
  );
}
