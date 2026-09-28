'use client';
import { Fragment, useEffect, useRef, useState, type KeyboardEvent } from 'react';
import { get, post, put, del, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { designGridAction, designComponentReturnField } from '../../../../lib/designBookKeyboard';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { designCalculationTotals, type DesignComponentDefaults } from '@datacare/core';
import {
  blankDesign,
  designFromDb,
  designToPayload,
  type DesignDraft,
  type SavedRow,
  type DesignCalculationConfig,
  initializeDesignCalculations,
  commitDesignField,
  commitPendingDesignFields,
  addDesignComponent,
  removeDesignComponent,
  selectDesignComponentItem,
  refreshDesignParent,
  configuredDesignColumns,
  newDesignWithRepeat,
  enterDesignField,
  discardEmptyDesignComponent,
} from '../../../../lib/designBookDraft';

const apiErr = (error: unknown, fallback: string): string =>
  error instanceof ApiError
    ? error.body?.message || error.body?.error || error.message
    : error instanceof Error
      ? error.message
      : fallback;

export default function DesignBookPage() {
  const scope = useBusinessScope();
  const [bookName, setBookName] = useState('');
  const [prCode, setPrCode] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [editor, setEditor] = useState<{
    lines: DesignDraft[];
    msg: { kind: 'ok' | 'err'; text: string } | null;
  }>({ lines: [blankDesign(1)], msg: null });
  const { lines, msg } = editor;
  const editorRef = useRef(editor);
  const rootRef = useRef<HTMLDivElement>(null);
  const parentFocus = useRef({ serial: '1', field: 'grossWt' });
  const [focusRequest, setFocusRequest] = useState<{
    serial: string;
    field: string;
    child?: string;
    origin: Element | null;
    scope: string;
  } | null>(null);
  const [rowRemoval, setRowRemoval] = useState<{ serial: string; child?: string } | null>(null);
  const [loadedKey, setLoadedKey] = useState('');
  const [bookVersion, setBookVersion] = useState('new');
  const [savedImageGeneration, setSavedImageGeneration] = useState(0);
  const [selected, setSelected] = useState('1');
  const [busy, setBusy] = useState(false);
  const [confirmDelete, setConfirmDelete] = useState(false);
  const [calculationConfig, setCalculationConfig] = useState<DesignCalculationConfig | null>(null);
  const [itemPending, setItemPending] = useState(0);
  const itemRequests = useRef(new Map<string, Promise<boolean>>());
  const keyboardPending = useRef(false);
  const loadedKeyRef = useRef(loadedKey);
  loadedKeyRef.current = loadedKey;
  const nextSerial = useRef(2);
  const activeKey = JSON.stringify([scope.coCode, bookName.trim(), prCode.trim()]);
  const ready = loadedKey === activeKey;
  const activeLine = lines.find((line) => line.values.srNo === selected);
  const totals = designCalculationTotals(
    lines.map((line) => line.calculation?.state.values ?? line.values),
  );
  const parentColumns = configuredDesignColumns(calculationConfig);
  const componentColumns = configuredDesignColumns(calculationConfig, true);

  function mutateEditor(fn: (current: typeof editor) => typeof editor) {
    const next = fn(editorRef.current);
    editorRef.current = next;
    setEditor(next);
  }
  function requestFocus(
    serial: string,
    field: string,
    child?: string,
    origin = document.activeElement,
  ) {
    setFocusRequest({ serial, field, child, origin, scope: activeKey });
  }
  useEffect(() => {
    if (!focusRequest) return;
    const current = document.activeElement;
    if (
      focusRequest.scope !== activeKey ||
      (current &&
        current !== document.body &&
        current !== focusRequest.origin &&
        focusRequest.origin?.isConnected)
    ) {
      setFocusRequest(null);
      return;
    }
    const cell = rootRef.current?.querySelector<HTMLElement>(
      `[data-design-parent="${focusRequest.serial}"][data-design-field="${focusRequest.field}"]${focusRequest.child ? `[data-design-child="${focusRequest.child}"]` : ':not([data-design-child])'}`,
    );
    const input = cell?.querySelector<HTMLInputElement>('input:not([readonly])');
    if (!input) {
      setFocusRequest(null);
      return;
    }
    input.focus();
    input.select();
    setFocusRequest(null);
  }, [focusRequest, activeKey, lines, selected]);

  function setLines(next: DesignDraft[] | ((current: DesignDraft[]) => DesignDraft[])) {
    mutateEditor((current) => ({
      ...current,
      lines: typeof next === 'function' ? next(current.lines) : next,
    }));
  }
  function setMsg(next: typeof msg) {
    mutateEditor((current) => ({ ...current, msg: next }));
  }

  function updateLine(serial: string, fn: (line: DesignDraft) => DesignDraft) {
    mutateEditor((current) => {
      try {
        return {
          ...current,
          lines: current.lines.map((line) => (line.values.srNo === serial ? fn(line) : line)),
        };
      } catch (error) {
        // Defaults and refresh can encounter an invalid cell while an edit is still pending.
        // Keep its draft and return validation in the same atomic state update.
        return { ...current, msg: { kind: 'err', text: apiErr(error, 'Invalid design value') } };
      }
    });
  }
  function commitCell(serial: string, field: string, value: string, childSerial?: number) {
    const current = editorRef.current.lines.find((line) => line.values.srNo === serial);
    if (!current) return;
    try {
      const result = commitDesignField(current, field, value, childSerial);
      updateLine(serial, () => result);
    } catch (error) {
      setMsg({ kind: 'err', text: apiErr(error, 'Invalid design value') });
    }
  }
  function addLine() {
    if (!calculationConfig || itemPending > 0) return;
    try {
      const prepared = editorRef.current.lines.map(commitPendingDesignFields);
      const line = newDesignWithRepeat(
        nextSerial.current,
        prepared.at(-1),
        calculationConfig,
        bookVersion === 'new',
      );
      nextSerial.current++;
      setLines([...prepared, line]);
      setSelected(line.values.srNo);
      requestFocus(
        line.values.srNo,
        parentColumns.find((column) => !column.identity)?.key ?? 'pageNo',
      );
    } catch (error) {
      setMsg({ kind: 'err', text: apiErr(error, 'Invalid design value') });
    }
  }
  function removeLine(row: number) {
    const current = editorRef.current.lines;
    const next = current.filter((_, index) => index !== row);
    setLines(next);
    if (current[row]?.values.srNo === selected)
      setSelected(next[Math.min(row, next.length - 1)]?.values.srNo ?? '');
  }
  function moveLine(row: number, offset: number) {
    setLines((current) => {
      const result = [...current];
      const target = row + offset;
      if (target < 0 || target >= result.length) return current;
      [result[row], result[target]] = [result[target], result[row]];
      return result;
    });
  }
  function addComponent() {
    if (itemPending > 0) return;
    const before = editorRef.current.lines.find((line) => line.values.srNo === selected);
    updateLine(selected, addDesignComponent);
    const after = editorRef.current.lines.find((line) => line.values.srNo === selected);
    if (before && after && after.components.length > before.components.length)
      requestFocus(selected, 'itCode', after.components.at(-1)!.values.isrNo);
  }
  async function selectItem(
    parentSerial: string,
    childSerial: number,
    code: string,
    force = false,
  ): Promise<boolean> {
    const draft = editorRef.current.lines.find((line) => line.values.srNo === parentSerial);
    if (
      !code.trim() ||
      (!force &&
        draft?.calculation?.state.components.find((child) => child.isrNo === childSerial)?.values
          .itCode === code.trim())
    )
      return Boolean(code.trim());
    const requestKey = JSON.stringify([loadedKey, parentSerial, childSerial, code.trim()]);
    if (itemRequests.current.has(requestKey)) return itemRequests.current.get(requestKey)!;
    const expectedKey = loadedKey;
    setItemPending((count) => count + 1);
    const request = (async () => {
      try {
        const defaults = await get<DesignComponentDefaults>(
          `/masters/design-book/component-defaults?itCode=${encodeURIComponent(code.trim())}`,
        );
        let applied = false;
        updateLine(parentSerial, (line) => {
          const child = line.components.find((item) => Number(item.values.isrNo) === childSerial);
          if (expectedKey !== loadedKeyRef.current || child?.values.itCode.trim() !== code.trim())
            return line;
          const result = selectDesignComponentItem(
            commitPendingDesignFields(line),
            childSerial,
            code.trim(),
            defaults,
            force,
          );
          applied = true;
          return result;
        });
        return applied;
      } catch (error) {
        setMsg({ kind: 'err', text: apiErr(error, 'Component item could not be loaded') });
        return false;
      } finally {
        itemRequests.current.delete(requestKey);
        setItemPending((count) => count - 1);
      }
    })();
    itemRequests.current.set(requestKey, request);
    return request;
  }

  async function handleDesignKey(event: KeyboardEvent<HTMLTableElement>, components = false) {
    if (itemPending > 0) {
      if (event.key === 'Enter') event.preventDefault();
      return;
    }
    if (event.defaultPrevented || keyboardPending.current || !ready || busy) return;
    const target = event.target;
    if (!(target instanceof HTMLInputElement)) return;
    const cell = target.closest<HTMLElement>('[data-design-parent][data-design-field]');
    if (!cell) return;
    const serial = cell.dataset.designParent!;
    const childSerial = cell.dataset.designChild;
    const field = cell.dataset.designField!;
    let line = editorRef.current.lines.find((entry) => entry.values.srNo === serial);
    if (!line) return;
    const rows = components ? line.components : editorRef.current.lines;
    const row = components
      ? line.components.findIndex((entry) => entry.values.isrNo === childSerial)
      : editorRef.current.lines.indexOf(line);
    const action = designGridAction({
      key: event.key,
      field,
      value: target.value,
      row,
      rowCount: rows.length,
      fields: (components ? componentColumns : parentColumns)
        .filter((column) => !column.identity)
        .map((column) => column.key),
      components,
      command: event.ctrlKey || event.metaKey,
      shift: event.shiftKey,
      alt: event.altKey,
      atStart: target.selectionStart === 0 && target.selectionEnd === 0,
      atEnd:
        target.selectionStart === target.value.length &&
        target.selectionEnd === target.value.length,
    });
    if (action.kind === 'none') return;
    event.preventDefault();
    if (action.kind === 'confirmRemove') {
      setRowRemoval({ serial, child: childSerial });
      return;
    }
    const value = target.value;
    const expectedKey = loadedKey;
    try {
      if (action.kind === 'leaveComponents') {
        if (childSerial)
          updateLine(serial, (entry) => discardEmptyDesignComponent(entry, Number(childSerial)));
        const originField =
          parentFocus.current.serial === serial ? parentFocus.current.field : 'grossWt';
        requestFocus(
          serial,
          designComponentReturnField(
            originField,
            parentColumns.map((column) => column.key),
          ),
          undefined,
          target,
        );
        return;
      }
      if (event.key === 'Enter' && components && field === 'itCode') {
        keyboardPending.current = true;
        if (!(await selectItem(serial, Number(childSerial), value, true))) return;
        line = editorRef.current.lines.find((entry) => entry.values.srNo === serial)!;
      } else if (event.key === 'Enter') {
        let defaults: DesignComponentDefaults | undefined;
        const child = line.calculation?.state.components.find(
          (entry) => entry.isrNo === Number(childSerial),
        );
        if (
          components &&
          field === 'grossWt' &&
          Number(child?.values.pcs ?? 0) === 0 &&
          Number(child?.values.grossWt ?? 0) === 0
        ) {
          keyboardPending.current = true;
          defaults = await get<DesignComponentDefaults>(
            `/masters/design-book/component-defaults?itCode=${encodeURIComponent(String(child?.values.itCode ?? ''))}`,
          );
          const current = editorRef.current.lines.find((entry) => entry.values.srNo === serial);
          if (
            expectedKey !== loadedKeyRef.current ||
            current?.components.find((entry) => entry.values.isrNo === childSerial)?.values[
              field
            ] !== value ||
            current?.calculation?.state.components.find(
              (entry) => entry.isrNo === Number(childSerial),
            )?.values.itCode !== child?.values.itCode
          )
            return;
          line = current;
        }
        const committed = enterDesignField(
          line,
          field,
          value,
          components ? Number(childSerial) : undefined,
          defaults,
        );
        updateLine(serial, () => committed);
        line = committed;
      } else {
        const committed = commitDesignField(
          line,
          field,
          value,
          components ? Number(childSerial) : undefined,
        );
        updateLine(serial, () => committed);
        line = committed;
      }
      if (expectedKey !== loadedKeyRef.current) return;
      if (action.kind === 'enterComponents') {
        if (!line.components.length) {
          line = addDesignComponent(line);
          updateLine(serial, () => line!);
        }
        setSelected(serial);
        parentFocus.current = { serial, field: 'grossWt' };
        requestFocus(serial, 'itCode', line.components.at(-1)!.values.isrNo, target);
      } else if (action.kind === 'append') {
        if (components) {
          const added = addDesignComponent(line);
          updateLine(serial, () => added);
          requestFocus(serial, action.field, added.components.at(-1)!.values.isrNo, target);
        } else addLine();
      } else if (action.kind === 'move') {
        const nextParent = components ? serial : editorRef.current.lines[action.row]!.values.srNo;
        setSelected(nextParent);
        requestFocus(
          nextParent,
          action.field,
          components ? line.components[action.row]!.values.isrNo : undefined,
          target,
        );
      }
    } catch (error) {
      setMsg({ kind: 'err', text: apiErr(error, 'Invalid design value') });
    } finally {
      keyboardPending.current = false;
    }
  }

  function confirmRowRemoval() {
    if (!rowRemoval) return;
    const { serial, child } = rowRemoval;
    if (child)
      updateLine(serial, (line) =>
        removeDesignComponent(
          line,
          line.components.findIndex((entry) => entry.values.isrNo === child),
        ),
      );
    else removeLine(editorRef.current.lines.findIndex((line) => line.values.srNo === serial));
    setRowRemoval(null);
  }
  function hydrate(rows: SavedRow[], key: string, config = calculationConfig) {
    // Even an unchanged business snapshot replaces physical parents and invalidates photo tokens.
    setSavedImageGeneration((generation) => generation + 1);
    const drafts = (rows.length ? rows.map(designFromDb) : [blankDesign(1)]).map((line) =>
      config ? initializeDesignCalculations(line, config, !rows.length) : line,
    );
    setLines(drafts);
    nextSerial.current = Math.max(...drafts.map((line) => Number(line.values.srNo))) + 1;
    setSelected(drafts[0].values.srNo);
    setBookVersion(String(rows[0]?.bookVersion ?? 'new'));
    setLoadedKey(key);
    setConfirmDelete(false);
  }
  async function readBook() {
    const q = new URLSearchParams({ bookName: bookName.trim(), prCode: prCode.trim() });
    return get<SavedRow[]>(`/masters/design-book?${q.toString()}`);
  }
  async function load() {
    if (!bookName.trim() || !prCode.trim()) {
      setMsg({ kind: 'err', text: 'Book name and product are required before loading.' });
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      const [rows, config] = await Promise.all([
        readBook(),
        get<DesignCalculationConfig>('/masters/design-book/calculation-config'),
      ]);
      setCalculationConfig(config);
      hydrate(rows, activeKey, config);
      setMsg({
        kind: 'ok',
        text: rows.length
          ? `Loaded ${rows.length} designs.`
          : 'This book is empty. Enter its first design.',
      });
    } catch (error) {
      setMsg({ kind: 'err', text: apiErr(error, 'Failed to load design book') });
    } finally {
      setBusy(false);
    }
  }
  async function save() {
    if (!ready) {
      setMsg({ kind: 'err', text: 'Load the selected book and product before saving.' });
      return;
    }
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'Add a design, or use Delete Book to remove the saved book.' });
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      let prepared = lines.map(commitPendingDesignFields);
      // A typed item code can be saved without selecting the lookup suggestion.
      prepared = await Promise.all(
        prepared.map(async (line) => {
          let result = line;
          for (const child of line.components) {
            const code = child.values.itCode.trim();
            const serial = Number(child.values.isrNo);
            if (
              code &&
              result.calculation?.state.components.find((item) => item.isrNo === serial)?.values
                .itCode !== code
            ) {
              const defaults = await get<DesignComponentDefaults>(
                `/masters/design-book/component-defaults?itCode=${encodeURIComponent(code)}`,
              );
              result = selectDesignComponentItem(result, serial, code, defaults);
            }
          }
          return result;
        }),
      );
      setLines(prepared);
      const payload = {
        bookName: bookName.trim(),
        prCode: prCode.trim(),
        vchDate: vchDate || undefined,
        expectedVersion: bookVersion,
        lines: prepared.map(designToPayload),
      };
      const result =
        bookVersion === 'new'
          ? await post<{ written: number }>('/masters/design-book', payload)
          : await put<{ written: number }>('/masters/design-book', payload);
      hydrate(await readBook(), activeKey);
      setMsg({
        kind: 'ok',
        text: `Saved and reopened ${result.written} designs with their components.`,
      });
    } catch (error) {
      setMsg({ kind: 'err', text: apiErr(error, 'Failed to save design book') });
    } finally {
      setBusy(false);
    }
  }
  async function removeBook() {
    if (!ready || !confirmDelete) return;
    setBusy(true);
    setMsg(null);
    try {
      await del('/masters/design-book', {
        bookName: bookName.trim(),
        prCode: prCode.trim(),
        expectedVersion: bookVersion,
      });
      hydrate([], activeKey);
      setMsg({ kind: 'ok', text: 'Deleted the selected book and its components.' });
    } catch (error) {
      setMsg({ kind: 'err', text: apiErr(error, 'Failed to delete design book') });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div ref={rootRef}>
      <h1>Design Book</h1>
      <p className="muted">
        Maintain designs, component specifications, customer and karigar weights, costs and
        photographs by book and product.
      </p>
      <div className="panel">
        <div className="row">
          <div className="field">
            <label htmlFor="design-book-name">Book Name</label>
            <input
              id="design-book-name"
              value={bookName}
              onChange={(e) => setBookName(e.target.value)}
              disabled={busy}
              maxLength={20}
            />
          </div>
          <div className="field">
            <label>Product</label>
            <fieldset disabled={busy} style={{ border: 0, padding: 0 }}>
              <LookupPicker
                entity="products"
                value={prCode}
                onChange={setPrCode}
                style={{ width: 160 }}
              />
            </fieldset>
          </div>
          <div className="field">
            <label htmlFor="design-book-date">Date for new designs</label>
            <input
              id="design-book-date"
              type="date"
              value={vchDate}
              onChange={(e) => setVchDate(e.target.value)}
              disabled={busy}
            />
          </div>
          <button type="button" className="primary" onClick={load} disabled={busy}>
            Load
          </button>
          <button
            type="button"
            className="ghost"
            onClick={save}
            disabled={busy || itemPending > 0 || !ready}
          >
            {busy ? 'Working…' : 'Save Design Book'}
          </button>
          <button
            type="button"
            className="danger"
            onClick={() => setConfirmDelete(true)}
            disabled={busy || !ready || bookVersion === 'new'}
          >
            Delete Book
          </button>
        </div>
        {!ready && (
          <p className="muted">Load the selected book and product to create or edit its designs.</p>
        )}
        {confirmDelete && ready && (
          <div role="alert">
            <p>
              Delete all designs and components in {bookName} / {prCode}?
            </p>
            <button type="button" className="danger" disabled={busy} onClick={removeBook}>
              Confirm Delete Book
            </button>{' '}
            <button
              type="button"
              className="ghost"
              disabled={busy}
              onClick={() => setConfirmDelete(false)}
            >
              Keep Book
            </button>
          </div>
        )}
      </div>
      {msg && (
        <div className={`msg ${msg.kind}`} role="status">
          {msg.text}
        </div>
      )}
      {itemPending > 0 && (
        <p className="muted" role="status">
          Loading component defaults…
        </p>
      )}
      {rowRemoval && (
        <div
          className="panel"
          role="alertdialog"
          aria-label="Remove design row"
          onKeyDown={(event) => {
            if (event.key === 'Escape') {
              event.preventDefault();
              setRowRemoval(null);
            }
          }}
        >
          <p>
            Remove{' '}
            {rowRemoval.child
              ? `component ${rowRemoval.child} from design ${rowRemoval.serial}`
              : `design ${rowRemoval.serial} and its components`}
            ? Save the book to apply this change.
          </p>
          <button type="button" className="danger" onClick={confirmRowRemoval}>
            Confirm Remove Row
          </button>{' '}
          <button type="button" className="ghost" autoFocus onClick={() => setRowRemoval(null)}>
            Keep Row
          </button>
        </div>
      )}
      <fieldset disabled={busy || !ready} style={{ border: 0, padding: 0, margin: 0, minWidth: 0 }}>
        <div className="panel" style={{ minWidth: 0 }}>
          <div className="toolbar" data-design-toolbar="parent">
            <strong>{lines.length} designs</strong>
            <span className="spacer" />
            <button type="button" className="ghost" disabled={itemPending > 0} onClick={addLine}>
              + Add Design
            </button>
          </div>
          <div style={{ overflowX: 'auto', maxWidth: '100%' }}>
            <table className="grid" onKeyDown={(event) => void handleDesignKey(event)}>
              <thead>
                <tr>
                  <th>Components</th>
                  {parentColumns.map((column) => (
                    <th key={column.key}>{column.label}</th>
                  ))}
                  <th>Arrange</th>
                </tr>
              </thead>
              <tbody>
                {lines.map((line, row) => (
                  <tr key={line.values.srNo}>
                    <td>
                      <button
                        type="button"
                        className="ghost"
                        aria-pressed={selected === line.values.srNo}
                        onClick={() => setSelected(line.values.srNo)}
                      >
                        {line.components.length} components
                      </button>
                    </td>
                    {parentColumns.map((column, col) => (
                      <td
                        key={column.key}
                        data-design-parent={line.values.srNo}
                        data-design-field={column.key}
                      >
                        <input
                          data-row={row}
                          data-col={col}
                          aria-label={`${column.label} design ${row + 1}`}
                          value={line.values[column.key] ?? ''}
                          readOnly={column.identity}
                          onFocus={() => {
                            setSelected(line.values.srNo);
                            if (!column.identity)
                              parentFocus.current = { serial: line.values.srNo, field: column.key };
                          }}
                          inputMode={column.numeric ? 'decimal' : undefined}
                          onChange={(e) =>
                            updateLine(line.values.srNo, (current) => ({
                              ...current,
                              values: { ...current.values, [column.key]: e.target.value },
                            }))
                          }
                          onBlur={(e) => commitCell(line.values.srNo, column.key, e.target.value)}
                          style={{
                            width: column.identity ? 60 : 110,
                            textAlign: column.numeric ? 'right' : undefined,
                          }}
                        />
                      </td>
                    ))}
                    <td style={{ whiteSpace: 'nowrap' }}>
                      <button
                        type="button"
                        className="ghost"
                        aria-label={`Move design ${row + 1} up`}
                        disabled={row === 0}
                        onClick={() => moveLine(row, -1)}
                      >
                        ↑
                      </button>
                      <button
                        type="button"
                        className="ghost"
                        aria-label={`Move design ${row + 1} down`}
                        disabled={row === lines.length - 1}
                        onClick={() => moveLine(row, 1)}
                      >
                        ↓
                      </button>
                      <button
                        type="button"
                        className="danger"
                        aria-label={`Remove design ${row + 1}`}
                        onClick={() => removeLine(row)}
                      >
                        ×
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
              <tfoot>
                <tr>
                  <th>Total</th>
                  {parentColumns.map((column) => (
                    <td key={column.key} style={{ textAlign: 'right' }}>
                      {Object.hasOwn(totals, column.key) ? totals[column.key] : ''}
                    </td>
                  ))}
                  <td />
                </tr>
              </tfoot>
            </table>
          </div>
        </div>
        {activeLine && (
          <Fragment>
            <div className="panel" style={{ minWidth: 0 }}>
              <div className="toolbar" data-design-toolbar="component">
                <strong>
                  Components — {activeLine.values.designNo || 'New design'} (Sr {selected})
                </strong>
                <span className="spacer" />
                <button
                  type="button"
                  className="ghost"
                  onClick={() =>
                    updateLine(selected, (line) =>
                      refreshDesignParent(commitPendingDesignFields(line)),
                    )
                  }
                >
                  Recalculate design totals
                </button>
                <button
                  type="button"
                  className="ghost"
                  disabled={itemPending > 0}
                  onClick={addComponent}
                >
                  + Add Component
                </button>
              </div>
              <div style={{ overflowX: 'auto', maxWidth: '100%' }}>
                <table
                  className="grid"
                  onKeyDown={(event) => void handleDesignKey(event, true)}
                  onKeyDownCapture={(event) => {
                    const target = event.target;
                    if (
                      event.key === 'Enter' &&
                      !event.ctrlKey &&
                      !event.metaKey &&
                      !event.shiftKey &&
                      !event.altKey &&
                      target instanceof HTMLInputElement &&
                      !target.value.trim() &&
                      target.closest<HTMLElement>('[data-design-field]')?.dataset.designField ===
                        'itCode'
                    ) {
                      event.stopPropagation();
                      void handleDesignKey(event, true);
                    }
                  }}
                >
                  <thead>
                    <tr>
                      {componentColumns.map((column) => (
                        <th key={column.key}>{column.label}</th>
                      ))}
                      <th>Remove</th>
                    </tr>
                  </thead>
                  <tbody>
                    {activeLine.components.map((child, row) => (
                      <tr key={child.values.isrNo}>
                        {componentColumns.map((column, col) => (
                          <td
                            key={column.key}
                            data-design-parent={selected}
                            data-design-child={child.values.isrNo}
                            data-design-field={column.key}
                          >
                            {column.key === 'itCode' ? (
                              <div
                                onBlur={(e) => {
                                  if (!e.currentTarget.contains(e.relatedTarget as Node | null))
                                    void selectItem(
                                      selected,
                                      Number(child.values.isrNo),
                                      child.values.itCode,
                                    );
                                }}
                              >
                                <LookupPicker
                                  entity="items"
                                  value={child.values.itCode}
                                  onChange={(value) =>
                                    updateLine(selected, (line) => ({
                                      ...line,
                                      components: line.components.map((item, index) =>
                                        index === row
                                          ? { ...item, values: { ...item.values, itCode: value } }
                                          : item,
                                      ),
                                    }))
                                  }
                                  ariaLabel={`Item component ${row + 1}`}
                                  advanceOnPick={false}
                                  onPick={(item) => {
                                    const origin = document.activeElement;
                                    void selectItem(
                                      selected,
                                      Number(child.values.isrNo),
                                      String(item.code),
                                      true,
                                    ).then((success) => {
                                      if (success)
                                        requestFocus(selected, 'pcs', child.values.isrNo, origin);
                                    });
                                  }}
                                  style={{ width: 115 }}
                                />
                              </div>
                            ) : (
                              <input
                                value={child.values[column.key]}
                                readOnly={column.identity}
                                data-row={row}
                                data-col={col}
                                aria-label={`${column.label} component ${row + 1}`}
                                inputMode={column.numeric ? 'decimal' : undefined}
                                onChange={(e) =>
                                  updateLine(selected, (line) => ({
                                    ...line,
                                    components: line.components.map((item, index) =>
                                      index === row
                                        ? {
                                            ...item,
                                            values: {
                                              ...item.values,
                                              [column.key]: e.target.value,
                                            },
                                          }
                                        : item,
                                    ),
                                  }))
                                }
                                onBlur={(e) =>
                                  commitCell(
                                    selected,
                                    column.key,
                                    e.target.value,
                                    Number(child.values.isrNo),
                                  )
                                }
                                style={{
                                  width: column.identity ? 55 : 105,
                                  textAlign: column.numeric ? 'right' : undefined,
                                }}
                              />
                            )}
                          </td>
                        ))}
                        <td>
                          <button
                            type="button"
                            className="danger"
                            aria-label={`Remove component ${row + 1}`}
                            onClick={() =>
                              updateLine(selected, (line) => removeDesignComponent(line, row))
                            }
                          >
                            ×
                          </button>
                        </td>
                      </tr>
                    ))}
                  </tbody>
                </table>
              </div>
              {!activeLine.components.length && (
                <p className="muted">Add the items that make up this design.</p>
              )}
            </div>
          </Fragment>
        )}
      </fieldset>
      {activeLine?.saved?.DESIGN_IMG_ID && ready ? (
        <EntityImagePanel
          key={`${savedImageGeneration}:${String(activeLine.saved.DESIGN_IMG_ID)}`}
          endpoint="/masters/design-book/image"
          entityType="DESIGN"
          imageType="D"
          entityKey={String(activeLine.saved.DESIGN_IMG_ID)}
          label={`Design photo — ${activeLine.values.designNo}`}
          disabled={busy}
        />
      ) : null}
    </div>
  );
}
