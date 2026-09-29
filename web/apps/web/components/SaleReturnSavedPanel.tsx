'use client';

import { useEffect, useRef, useState } from 'react';
import { ApiError, get, put } from '../lib/api';
import {
  readSavedIncomingReturn,
  readSavedReturnRecent,
  savedReturnDraft,
  savedReturnHasChanges,
  savedReturnLineKey,
  savedReturnMetadataPatch,
  savedReturnPath,
  savedReturnQuery,
  savedReturnRecentPath,
  savedReturnScopeKey,
  savedReturnSaveFailure,
  SavedReturnRequestGuard,
  type SavedIncomingReturn,
  type SavedReturnDraft,
  type SavedReturnRaw,
  type SavedReturnRecent,
  type SavedReturnRequestToken,
} from '../lib/salesReturnForm';
import { BookSelect } from './BookSelect';
import { useBusinessScope } from './BusinessScope';
import { LookupPicker } from './LookupPicker';
import { SaleReturnReplayPanel } from './SaleReturnReplayPanel';
import { SaleReturnBillReplayPanel } from './SaleReturnBillReplayPanel';
import { SaleReturnLabourReplayPanel } from './SaleReturnLabourReplayPanel';
import {
  SavedReturnPreviewOwnership,
  type SavedReturnPreviewKind,
} from '../lib/salesReturnBillReplay';

type Selection = {
  context: number;
  generation: number;
  document: SavedIncomingReturn;
  draft: SavedReturnDraft;
  needsReload: boolean;
};

function message(error: unknown): string {
  return error instanceof ApiError
    ? String(error.body?.message || error.body?.error || error.message)
    : error instanceof Error
      ? error.message
      : 'The saved return request failed.';
}

function RawDetails({ raw, testId }: { raw: SavedReturnRaw; testId: string }) {
  return (
    <div style={{ overflowX: 'auto', maxWidth: '100%' }} data-testid={testId}>
      <table className="grid">
        <thead>
          <tr>
            <th>Saved field</th>
            <th>Exact value</th>
          </tr>
        </thead>
        <tbody>
          {Object.entries(raw).map(([key, value]) => (
            <tr key={key}>
              <th scope="row">{key}</th>
              <td style={{ whiteSpace: 'pre-wrap', overflowWrap: 'anywhere' }}>
                {value === null ? (
                  <span className="muted">NULL</span>
                ) : value === '' ? (
                  <span className="muted">(empty)</span>
                ) : (
                  value
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

/** Saved observations never pass through the legacy create/numeric replacement form. */
export function SaleReturnSavedPanel({
  onDirtyChange,
}: {
  onDirtyChange?: (dirty: boolean) => void;
}) {
  const business = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const scope = { ...business, coBook };
  const scopeKey = savedReturnScopeKey(scope);
  const guard = useRef(new SavedReturnRequestGuard());
  const context = guard.current.observe(scopeKey);
  const scopeRef = useRef(scope);
  scopeRef.current = scope;
  const [selection, setSelection] = useState<Selection | null>(null);
  const observationGeneration = useRef(0);
  const previewOwner = useRef(new SavedReturnPreviewOwnership());
  const selected = selection?.context === context ? selection : null;
  previewOwner.current.observe(selected);
  const previewKind = previewOwner.current.active(selected);
  const previewActive = previewKind !== null;
  const selectionRef = useRef<Selection | null>(selected);
  selectionRef.current = selected;
  const [voucher, setVoucher] = useState('');
  // The strict numeric-update draft is a single ordered c27 "Other amount" editor value. It is
  // kept separate from the metadata draft: the numeric write routes through the dedicated
  // updateSaleReturnNumeric coordinator, never the metadata patch or the legacy create form.
  const [numericOther, setNumericOther] = useState('');
  const [recent, setRecent] = useState<{ context: number; data: SavedReturnRecent } | null>(null);
  const [browseRequest, setBrowseRequest] = useState<SavedReturnRequestToken | null>(null);
  const [operation, setOperation] = useState<{
    token: SavedReturnRequestToken;
    kind: 'load' | 'save';
  } | null>(null);
  const operationRef = useRef(operation);
  const [error, setError] = useState<{ context: number; text: string; conflict: boolean } | null>(
    null,
  );
  const [notice, setNotice] = useState<{ context: number; text: string } | null>(null);
  const [, repaint] = useState(0);
  const busy = Boolean(operation && guard.current.current(operation.token));
  const saving = busy && operation?.kind === 'save';
  const browsing = Boolean(browseRequest && guard.current.current(browseRequest));
  const dirty = Boolean(selected && savedReturnHasChanges(selected.document, selected.draft));
  const editable = Boolean(
    selected &&
    selected.document.canUpdate &&
    selected.document.capabilities.canUpdate &&
    !selected.needsReload &&
    !busy &&
    !previewActive,
  );
  const currentError = error?.context === context ? error : null;
  const currentNotice = notice?.context === context ? notice : null;
  const listed = recent?.context === context ? recent.data.rows : [];
  const complete = Boolean(business.coCode && business.lcCode && business.coYear && coBook);

  useEffect(() => {
    setSelection(null);
    setRecent(null);
    setVoucher('');
    setNumericOther('');
    setError(null);
    setNotice(null);
    previewOwner.current.clear();
  }, [scopeKey]);
  useEffect(() => {
    onDirtyChange?.(dirty || previewActive);
  }, [dirty, previewActive, onDirtyChange]);
  useEffect(() => {
    const owner = guard.current;
    return () => {
      owner.invalidate();
      onDirtyChange?.(false);
    };
  }, [onDirtyChange]);

  function pendingDocument() {
    return Boolean(operationRef.current && guard.current.current(operationRef.current.token));
  }

  function canEdit(current: Selection) {
    return (
      current.document === selected?.document &&
      current.context === guard.current.observe(savedReturnScopeKey(scopeRef.current)) &&
      !pendingDocument() &&
      !previewOwner.current.active(current) &&
      !current.needsReload &&
      current.document.canUpdate &&
      current.document.capabilities.canUpdate
    );
  }

  function previewActivity(
    current: Selection,
    kind: SavedReturnPreviewKind,
    active: boolean,
  ): boolean {
    const latest = selectionRef.current;
    if (
      !latest ||
      latest.context !== current.context ||
      latest.generation !== current.generation ||
      latest.document !== current.document
    )
      return false;
    const eligible =
      !pendingDocument() &&
      !latest.needsReload &&
      !savedReturnHasChanges(latest.document, latest.draft);
    const accepted = previewOwner.current.change(current, kind, active, eligible);
    if (accepted) repaint((value) => value + 1);
    return accepted;
  }

  function reloadPreview(current: Selection) {
    const latest = selectionRef.current;
    if (
      latest?.context === current.context &&
      latest.generation === current.generation &&
      latest.document === current.document
    )
      void load(current.document.voucherNo, true);
  }

  function fail(errorValue: unknown, token: SavedReturnRequestToken, conflict = false) {
    if (guard.current.current(token))
      setError({ context: token.context, text: message(errorValue), conflict });
  }

  async function browse() {
    if (!complete || browsing || (pendingDocument() && operationRef.current?.kind === 'save'))
      return;
    const captured = { ...scopeRef.current };
    const token = guard.current.begin('browse');
    setBrowseRequest(token);
    setError(null);
    try {
      const data = readSavedReturnRecent(await get<unknown>(savedReturnRecentPath(captured)));
      if (guard.current.current(token)) setRecent({ context: token.context, data });
    } catch (caught) {
      fail(caught, token);
    } finally {
      if (guard.current.current(token)) setBrowseRequest(null);
    }
  }

  async function load(voucherNo: string, discard = false) {
    const current = selectionRef.current;
    if (
      !complete ||
      pendingDocument() ||
      (previewOwner.current.active(current) && !discard) ||
      (current && savedReturnHasChanges(current.document, current.draft) && !discard)
    )
      return;
    const captured = { ...scopeRef.current };
    const token = guard.current.begin('document');
    operationRef.current = { token, kind: 'load' };
    setOperation(operationRef.current);
    setError(null);
    setNotice(null);
    setSelection(null);
    previewOwner.current.clear();
    try {
      const document = readSavedIncomingReturn(
        await get<unknown>(savedReturnPath(captured, voucherNo)),
        captured,
        voucherNo,
      );
      if (!guard.current.current(token)) return;
      setVoucher(document.voucherNo);
      setSelection({
        context: token.context,
        generation: ++observationGeneration.current,
        document,
        draft: savedReturnDraft(document),
        needsReload: false,
      });
    } catch (caught) {
      fail(caught, token);
    } finally {
      if (guard.current.current(token)) {
        operationRef.current = null;
        setOperation(null);
      }
    }
  }

  function close() {
    if (pendingDocument() && operationRef.current?.kind === 'save') return;
    guard.current.invalidate();
    operationRef.current = null;
    selectionRef.current = null;
    setSelection(null);
    setOperation(null);
    setRecent(null);
    setVoucher('');
    setError(null);
    setNotice(null);
    previewOwner.current.clear();
    repaint((value) => value + 1);
  }

  function editHeader(employeeCode: string) {
    const current = selectionRef.current;
    if (!current || !canEdit(current) || !current.document.header.capabilities.employeeCode.allowed)
      return;
    const next = { ...current, draft: { ...current.draft, employeeCode } };
    selectionRef.current = next;
    setSelection(next);
  }

  function editLine(key: string, field: 'huid' | 'description', value: string) {
    const current = selectionRef.current;
    const line = current?.document.lines.find((row) => savedReturnLineKey(row.identity) === key);
    const previous = current?.draft.lines[key];
    if (!current || !canEdit(current) || !line?.capabilities[field].allowed || !previous) return;
    const next = {
      ...current,
      draft: {
        ...current.draft,
        lines: { ...current.draft.lines, [key]: { ...previous, [field]: value } },
      },
    };
    selectionRef.current = next;
    setSelection(next);
  }

  async function save() {
    const current = selectionRef.current;
    if (!current || !canEdit(current) || !savedReturnHasChanges(current.document, current.draft))
      return;
    const token = guard.current.begin('document');
    operationRef.current = { token, kind: 'save' };
    setOperation(operationRef.current);
    setError(null);
    setNotice(null);
    let committed = false;
    let dispatched = false;
    try {
      const patch = savedReturnMetadataPatch(current.document, current.draft);
      if (!patch) return;
      dispatched = true;
      const response = await put<unknown>(
        savedReturnPath(current.document.scope, current.document.voucherNo, 'metadata'),
        patch,
      );
      committed = true;
      const document = readSavedIncomingReturn(
        response,
        current.document.scope,
        current.document.voucherNo,
      );
      if (!guard.current.current(token)) return;
      setSelection({
        context: token.context,
        generation: ++observationGeneration.current,
        document,
        draft: savedReturnDraft(document),
        needsReload: false,
      });
      setNotice({ context: token.context, text: 'Saved metadata and reopened this return.' });
    } catch (caught) {
      if (!guard.current.current(token)) return;
      const failure = savedReturnSaveFailure(caught, { committed, dispatched });
      setSelection({ ...current, needsReload: failure.needsReload });
      setError({
        context: token.context,
        conflict: failure.conflict,
        text: failure.message,
      });
    } finally {
      if (guard.current.current(token)) {
        operationRef.current = null;
        setOperation(null);
      }
    }
  }

  async function saveNumeric() {
    const current = selectionRef.current;
    if (!current || !canEdit(current) || !numericOther.trim()) return;
    const token = guard.current.begin('document');
    operationRef.current = { token, kind: 'save' };
    setOperation(operationRef.current);
    setError(null);
    setNotice(null);
    let committed = false;
    let dispatched = false;
    try {
      dispatched = true;
      // Send only the observed document version and the single c27 Other editor value; the
      // coordinator re-observes and re-locks every dependency and adopts a fresh saved version.
      const response = await put<unknown>(
        savedReturnPath(current.document.scope, current.document.voucherNo, 'numeric'),
        { version: current.document.version, otherAmount: numericOther.trim() },
      );
      committed = true;
      if (!guard.current.current(token)) return;
      const fresh =
        response && typeof response === 'object' && !Array.isArray(response)
          ? String((response as Record<string, unknown>).documentVersion ?? '')
          : '';
      // Reload the saved return to adopt the fresh saved version and clear the numeric draft.
      setNumericOther('');
      setNotice({
        context: token.context,
        text: fresh
          ? `Saved numeric update; adopted fresh version ${fresh.slice(0, 12)}…`
          : 'Saved numeric update.',
      });
      if (guard.current.current(token)) {
        operationRef.current = null;
        setOperation(null);
      }
      void load(current.document.voucherNo, true);
      return;
    } catch (caught) {
      if (!guard.current.current(token)) return;
      const failure = savedReturnSaveFailure(caught, { committed, dispatched });
      setSelection({ ...current, needsReload: failure.needsReload });
      setError({ context: token.context, conflict: failure.conflict, text: failure.message });
    } finally {
      if (guard.current.current(token)) {
        operationRef.current = null;
        setOperation(null);
      }
    }
  }

  return (
    <section data-testid="sale-return-saved" style={{ minWidth: 0 }}>
      <p>
        Load a saved return to review exact saved values and edit permitted HUID, item description
        or employee details.
      </p>
      <div className="panel">
        <div className="row" style={{ alignItems: 'end', flexWrap: 'wrap' }}>
          <div className="field" data-testid="sale-return-saved-book">
            <label>Return book</label>
            <BookSelect
              key={JSON.stringify([business.coCode, business.lcCode, business.coYear])}
              value={coBook}
              onChange={setCoBook}
              preferred="SRT"
              mainBooks={['SALES RETURNE']}
              disabled={saving || dirty || previewActive}
            />
          </div>
          <div className="field">
            <label htmlFor="saved-return-voucher">Saved return voucher</label>
            <input
              id="saved-return-voucher"
              data-testid="sale-return-saved-voucher"
              value={voucher}
              onChange={(event) => setVoucher(event.target.value)}
              inputMode="numeric"
              disabled={busy || previewActive}
            />
          </div>
          <button
            type="button"
            onClick={() => void load(voucher)}
            disabled={!complete || busy || dirty || previewActive || !voucher.trim()}
            data-testid="sale-return-saved-load"
          >
            Load saved return
          </button>
          <button
            type="button"
            className="ghost"
            onClick={() => void browse()}
            disabled={!complete || browsing || saving}
            data-testid="sale-return-saved-browse"
          >
            {browsing ? 'Loading list…' : 'Browse saved returns'}
          </button>
          <button
            type="button"
            className="ghost"
            onClick={close}
            disabled={saving}
            data-testid="sale-return-saved-discard"
          >
            {dirty || previewActive ? 'Discard changes and close' : 'Close saved return'}
          </button>
        </div>
        <p className="muted">
          Company {business.coCode} · Location {business.lcCode} · Year {business.coYear}
        </p>
        {dirty && (
          <p className="muted">
            Save or discard these metadata changes before loading another return.
          </p>
        )}
      </div>

      {busy && <p role="status">{saving ? 'Saving metadata…' : 'Loading saved return…'}</p>}
      {currentError && (
        <div className="msg err" role="alert" data-testid="sale-return-saved-error">
          {currentError.conflict ? (
            <span data-testid="sale-return-saved-conflict">
              {currentError.text} Your entered changes are retained. Reload before another save.
            </span>
          ) : (
            currentError.text
          )}
        </div>
      )}
      {currentNotice && (
        <p className="msg ok" role="status">
          {currentNotice.text}
        </p>
      )}

      {recent?.context === context && (
        <div className="panel" style={{ overflowX: 'auto' }} data-testid="sale-return-saved-recent">
          <table className="grid">
            <thead>
              <tr>
                <th>Voucher</th>
                <th>Date</th>
                <th>Customer</th>
                <th>Incoming amount</th>
                <th>Outgoing amount</th>
                <th>Action</th>
              </tr>
            </thead>
            <tbody>
              {listed.map((row, index) => (
                <tr key={`${row.voucherNo}:${index}`}>
                  <td>{row.voucherNo}</td>
                  <td>{String(row.display.date ?? row.raw.VCH_DATE ?? '')}</td>
                  <td>
                    {String(row.display.customer ?? row.raw.AC_NAME ?? row.raw.AC_CODE ?? '')}
                  </td>
                  <td>{row.raw.RTN_NET_AMT ?? '—'}</td>
                  <td>{row.raw.NET_AMT ?? '—'}</td>
                  <td>
                    <button
                      type="button"
                      className="ghost"
                      disabled={busy || dirty || previewActive}
                      onClick={() => void load(row.voucherNo)}
                      aria-label={`Load saved return ${row.voucherNo}`}
                    >
                      Load
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          {!listed.length && <p>No saved returns in this book.</p>}
        </div>
      )}

      {selected && (
        <div className="panel" data-testid="sale-return-saved-context" style={{ minWidth: 0 }}>
          <h2>Saved return #{selected.document.voucherNo}</h2>
          <p>
            Company {selected.document.scope.coCode} · Location {selected.document.scope.lcCode} ·
            Year {selected.document.scope.coYear} · Book {selected.document.scope.coBook}
          </p>
          <p>
            Customer {selected.document.header.raw.AC_CODE} {selected.document.header.raw.AC_NAME} ·
            Date {selected.document.header.raw.VCH_DATE}
          </p>
          <p data-testid="sale-return-saved-original">
            Original sale: location {selected.document.header.raw.ISU_LC_CODE ?? '—'}, year{' '}
            {selected.document.header.raw.ISU_YRCD ?? '—'}, book{' '}
            {selected.document.header.raw.ISU_DBCD ?? '—'}, voucher{' '}
            {selected.document.header.raw.ISU_NO ?? '—'}
          </p>
          <p data-testid="sale-return-saved-amounts">
            Saved incoming amount {selected.document.header.raw.RTN_NET_AMT ?? '—'} · Saved outgoing
            amount {selected.document.header.raw.NET_AMT ?? '—'}
          </p>
          <p data-testid="sale-return-saved-provenance">
            Incoming items {selected.document.provenance.incomingLineCount} · Outgoing items{' '}
            {selected.document.provenance.outgoingLineCount} · Outgoing components{' '}
            {selected.document.provenance.outgoingComponentCount} · Return tag components{' '}
            {selected.document.provenance.tagComponentCount}
          </p>
          {(!selected.document.canUpdate || !selected.document.capabilities.canUpdate) && (
            <p role="status">
              {selected.document.capabilities.reason ||
                'Your access to this saved return is read-only.'}
            </p>
          )}
          {selected.needsReload && (
            <p role="status">Reload this saved return before making further changes.</p>
          )}

          <div className="field" data-testid="sale-return-saved-employee" style={{ maxWidth: 360 }}>
            <label>Header employee</label>
            {editable && selected.document.header.capabilities.employeeCode.allowed ? (
              <LookupPicker
                entity="employees"
                ariaLabel="Saved return employee"
                value={selected.draft.employeeCode}
                searchPath={`/lookup/employees?${savedReturnQuery(selected.document.scope)}`}
                onChange={editHeader}
                advanceOnPick={false}
              />
            ) : (
              <input
                aria-label="Saved return employee"
                value={selected.draft.employeeCode}
                readOnly
              />
            )}
            <span className="muted">{selected.document.header.display.employeeName}</span>
            {selected.document.header.display.employeeNameReason && (
              <span className="muted" data-testid="sale-return-saved-employee-name-reason">
                {selected.document.header.display.employeeNameReason}
              </span>
            )}
            {!selected.document.header.capabilities.employeeCode.allowed && (
              <span className="muted">
                {selected.document.header.capabilities.employeeCode.reason}
              </span>
            )}
          </div>

          <div style={{ overflowX: 'auto', maxWidth: '100%' }}>
            <table className="grid">
              <thead>
                <tr>
                  <th>Saved row</th>
                  <th>Saved old row</th>
                  <th>Return instance</th>
                  <th>Item / Tag</th>
                  <th>HUID</th>
                  <th>Receive Item</th>
                  <th>Saved net weight</th>
                  <th>Saved net amount</th>
                </tr>
              </thead>
              <tbody>
                {selected.document.lines.map((line) => {
                  const key = savedReturnLineKey(line.identity);
                  const draft = selected.draft.lines[key]!;
                  return (
                    <tr key={key} data-testid={`sale-return-saved-line-${line.identity.srNo}`}>
                      <td>{line.identity.srNo}</td>
                      <td>{line.identity.oldSrNo ?? '—'}</td>
                      <td>{line.identity.vchSrno ?? '—'}</td>
                      <td>
                        {line.identity.itCode} / {line.identity.tagNo ?? 'NULL'}
                      </td>
                      <td>
                        <input
                          aria-label={`HUID saved row ${line.identity.srNo}`}
                          data-testid={`sale-return-saved-huid-${line.identity.srNo}`}
                          value={draft.huid}
                          readOnly={!editable || !line.capabilities.huid.allowed}
                          onChange={(event) => editLine(key, 'huid', event.target.value)}
                          style={{ width: 120 }}
                        />
                        {!line.capabilities.huid.allowed && (
                          <small className="muted">{line.capabilities.huid.reason}</small>
                        )}
                      </td>
                      <td>
                        <input
                          aria-label={`Receive Item saved row ${line.identity.srNo}`}
                          data-testid={`sale-return-saved-description-${line.identity.srNo}`}
                          value={draft.description}
                          readOnly={!editable || !line.capabilities.description.allowed}
                          onChange={(event) => editLine(key, 'description', event.target.value)}
                          style={{ width: 250 }}
                          aria-describedby={
                            line.display.itemNameReason
                              ? `saved-return-item-name-reason-${line.identity.srNo}`
                              : undefined
                          }
                        />
                        {line.display.itemNameReason && (
                          <small
                            className="muted"
                            id={`saved-return-item-name-reason-${line.identity.srNo}`}
                            data-testid={`sale-return-saved-item-name-reason-${line.identity.srNo}`}
                            style={{ display: 'block', maxWidth: 250, whiteSpace: 'normal' }}
                          >
                            {line.display.itemNameReason}
                          </small>
                        )}
                        {!line.capabilities.description.allowed && (
                          <small className="muted">{line.capabilities.description.reason}</small>
                        )}
                      </td>
                      <td>{line.raw.ITM_NWT ?? 'NULL'}</td>
                      <td>{line.raw.NET_AMT ?? 'NULL'}</td>
                    </tr>
                  );
                })}
              </tbody>
            </table>
          </div>
          <div className="toolbar" style={{ marginTop: 12, flexWrap: 'wrap' }}>
            <button
              type="button"
              className="primary"
              onClick={() => void save()}
              disabled={!editable || !dirty}
              data-testid="sale-return-saved-save"
            >
              Save metadata
            </button>
            <button
              type="button"
              className="ghost"
              disabled={busy}
              data-testid="sale-return-saved-reload"
              onClick={() => void load(selected.document.voucherNo, true)}
            >
              {dirty || previewActive ? 'Reload and discard changes' : 'Reload saved return'}
            </button>
            <span className="muted">
              Saved amounts, source identities and other fields remain read-only.
            </span>
          </div>
          <div
            className="panel"
            data-testid="sale-return-saved-numeric"
            style={{ marginTop: 12 }}
          >
            <h3>Numeric update (contained profile)</h3>
            <p className="muted">
              Applies a single ordered "Other amount" (c27) editor value through the strict
              numeric-update coordinator. Supported only for the ordinary saved single-primary
              N/P/I/SR1 zero-tax profile; every other saved shape is refused server-side.
            </p>
            <div className="row" style={{ alignItems: 'end', flexWrap: 'wrap' }}>
              <div className="field" style={{ maxWidth: 200 }}>
                <label htmlFor="saved-return-numeric-other">Other amount (c27)</label>
                <input
                  id="saved-return-numeric-other"
                  data-testid="sale-return-saved-numeric-other"
                  value={numericOther}
                  onChange={(event) => setNumericOther(event.target.value)}
                  inputMode="decimal"
                  disabled={!editable || dirty}
                />
              </div>
              <button
                type="button"
                className="primary"
                data-testid="sale-return-saved-numeric-save"
                onClick={() => void saveNumeric()}
                disabled={!editable || dirty || !numericOther.trim()}
              >
                {saving ? 'Saving…' : 'Save numeric update'}
              </button>
            </div>
          </div>
          {(previewKind === null || previewKind === 'row') && (
            <SaleReturnReplayPanel
              key={`row:${selected.context}:${selected.generation}`}
              document={selected.document}
              disabled={dirty || busy || selected.needsReload}
              onActivityChange={(active) => previewActivity(selected, 'row', active)}
              onReload={() => reloadPreview(selected)}
            />
          )}
          {(previewKind === null || previewKind === 'bill') && (
            <SaleReturnBillReplayPanel
              key={`bill:${selected.context}:${selected.generation}`}
              document={selected.document}
              disabled={dirty || busy || selected.needsReload}
              onActivityChange={(active) => previewActivity(selected, 'bill', active)}
              onReload={() => reloadPreview(selected)}
            />
          )}
          {(previewKind === null || previewKind === 'labour') && (
            <SaleReturnLabourReplayPanel
              key={`labour:${selected.context}:${selected.generation}`}
              document={selected.document}
              disabled={dirty || busy || selected.needsReload}
              onActivityChange={(active) => previewActivity(selected, 'labour', active)}
              onReload={() => reloadPreview(selected)}
            />
          )}
          <details>
            <summary>Exact saved header</summary>
            <RawDetails raw={selected.document.header.raw} testId="sale-return-saved-header-raw" />
          </details>
          {selected.document.lines.map((line) => (
            <details key={savedReturnLineKey(line.identity)}>
              <summary>Exact saved row {line.identity.srNo}, image and hallmark details</summary>
              <RawDetails raw={line.raw} testId={`sale-return-saved-raw-${line.identity.srNo}`} />
            </details>
          ))}
          <details data-testid="sale-return-saved-related">
            <summary>Related saved records</summary>
            {(
              [
                ['outgoingLines', 'Outgoing items'],
                ['outgoingComponents', 'Outgoing item components'],
                ['tagHeaders', 'Return tag vouchers'],
                ['tagParents', 'Return tag items'],
                ['tagComponents', 'Return tag components'],
              ] as const
            ).map(([key, label]) => (
              <div key={key} data-testid={`sale-return-saved-related-${key}`}>
                <h3>
                  {label} ({selected.document.related[key].length})
                </h3>
                {selected.document.related[key].map((raw, index) => (
                  <details key={index}>
                    <summary>
                      {label} · saved row {raw.SR_NO ?? index + 1}
                      {raw.ISR_NO != null ? ` / component ${raw.ISR_NO}` : ''}
                    </summary>
                    <RawDetails raw={raw} testId={`sale-return-saved-related-${key}-${index}`} />
                  </details>
                ))}
              </div>
            ))}
          </details>
        </div>
      )}
    </section>
  );
}
