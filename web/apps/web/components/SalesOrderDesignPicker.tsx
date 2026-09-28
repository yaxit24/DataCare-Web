'use client';

import { useEffect, useRef, useState, type RefObject } from 'react';
import type { SalesOrderDesignList, SalesOrderDesignOption } from '@datacare/core';
import { ApiError, get } from '../lib/api';

type Scope = { coCode: string; lcCode: string; coYear: string };
type Image =
  { state: 'absent' } | { state: 'present'; mimeType: string; data: string; source: string };
const errorText = (error: unknown) =>
  error instanceof ApiError
    ? String(error.body?.message || error.body?.error || error.message)
    : error instanceof Error
      ? error.message
      : 'The saved design could not be loaded.';

/** Read-only preview of the exact selected source, including for an unsaved order row. */
export function SalesOrderDesignPreview({
  scope,
  coBook,
  itemCode,
  rowKey,
  selection,
}: {
  scope: Scope;
  coBook: string;
  itemCode: string;
  rowKey: string;
  selection: SalesOrderDesignOption | null;
}) {
  const query = new URLSearchParams({
    ...scope,
    coBook,
    itCode: itemCode,
    prCode: selection?.source.prCode ?? '',
    bookName: selection?.source.bookName ?? '',
    srNo: String(selection?.source.srNo ?? ''),
    oldSrNo: selection?.source.oldSrNo == null ? '' : String(selection.source.oldSrNo),
    version: selection?.source.version ?? '',
  }).toString();
  const path = `/sales-orders/design-image?${query}`;
  const identity = selection && rowKey ? `${rowKey}:${path}` : '';
  const current = useRef(identity);
  current.current = identity;
  const [result, setResult] = useState<{ identity: string; image?: Image; error?: string } | null>(
    null,
  );
  useEffect(() => {
    let active = true;
    if (identity)
      void get<Image>(path)
        .then((image) => {
          if (active && current.current === identity) setResult({ identity, image });
        })
        .catch((error) => {
          if (active && current.current === identity)
            setResult({ identity, error: errorText(error) });
        });
    return () => {
      active = false;
    };
  }, [identity, path]);
  if (!selection) return null;
  const found = result?.identity === identity ? result : null;
  return (
    <figure aria-label="Selected Design Book image" style={{ margin: 0 }}>
      <figcaption>
        {selection.bookName} / {selection.designNo || '(empty design)'}
      </figcaption>
      {!found && <p role="status">Loading design image…</p>}
      {found?.error && <p role="alert">{found.error}</p>}
      {found?.image?.state === 'absent' && <p>No image is stored for this design.</p>}
      {found?.image?.state === 'present' && (
        <img
          src={`data:${found.image.mimeType};base64,${found.image.data}`}
          alt={`Design ${selection.designNo} from ${selection.bookName}`}
          style={{ maxWidth: '100%', width: 180, maxHeight: 180, objectFit: 'contain' }}
        />
      )}
    </figure>
  );
}

/** Native modal supplies keyboard focus containment; Escape/cancel never emits a selection event. */
export function SalesOrderDesignPicker({
  open,
  scope,
  coBook,
  itemCode,
  rowKey,
  onSelect,
  onClose,
  returnFocusRef,
}: {
  open: boolean;
  scope: Scope;
  coBook: string;
  itemCode: string;
  rowKey: string;
  onSelect: (selection: SalesOrderDesignOption) => void;
  onClose: () => void;
  returnFocusRef: RefObject<HTMLInputElement | null>;
}) {
  const dialog = useRef<HTMLDialogElement>(null);
  const searchInput = useRef<HTMLInputElement>(null);
  const [search, setSearch] = useState('');
  const [request, setRequest] = useState({ search: '', offset: 0, attempt: 0 });
  const [loaded, setLoaded] = useState<{
    identity: string;
    payload?: SalesOrderDesignList;
    error?: string;
  } | null>(null);
  const [preview, setPreview] = useState<{
    context: string;
    selection: SalesOrderDesignOption;
  } | null>(null);
  const context = open
    ? JSON.stringify([scope.coCode, scope.lcCode, scope.coYear, coBook, itemCode, rowKey])
    : '';
  const query = new URLSearchParams({
    ...scope,
    coBook,
    itCode: itemCode,
    search: request.search,
    offset: String(request.offset),
    limit: '25',
  }).toString();
  const path = `/sales-orders/designs?${query}`;
  const ready = Boolean(
    open && scope.coCode && scope.lcCode && scope.coYear && coBook && itemCode && rowKey,
  );
  const identity = ready ? `${context}:${path}:${request.attempt}` : '';
  const current = useRef(identity);
  current.current = identity;
  const callbacks = useRef({ onClose, returnFocusRef });
  callbacks.current = { onClose, returnFocusRef };
  useEffect(() => {
    if (!open) return;
    const element = dialog.current;
    if (!element) return;
    element.showModal();
    searchInput.current?.focus();
    return () => {
      element.close();
      callbacks.current.returnFocusRef.current?.focus();
    };
  }, [open]);
  useEffect(() => {
    setSearch('');
    setRequest({ search: '', offset: 0, attempt: 0 });
    setPreview(null);
  }, [context]);
  useEffect(() => {
    let active = true;
    if (identity)
      void get<SalesOrderDesignList>(path)
        .then((payload) => {
          if (active && current.current === identity) setLoaded({ identity, payload });
        })
        .catch((error) => {
          if (active && current.current === identity)
            setLoaded({ identity, error: errorText(error) });
        });
    return () => {
      active = false;
    };
  }, [identity, path]);
  if (!open) return null;
  const result = loaded?.identity === identity ? loaded : null;
  const payload = result?.payload;
  const chosen = preview?.context === context ? preview.selection : null;
  const choose = (selection: SalesOrderDesignOption) => {
    if (!ready || current.current !== identity || !payload?.rows.includes(selection)) return;
    onSelect(selection);
    onClose();
  };
  return (
    <dialog
      ref={dialog}
      aria-labelledby="sales-design-picker-title"
      onKeyDown={(event) => {
        if (event.key !== 'Tab') return;
        // Native modal inertness does not prevent Tab wrapping into browser chrome.
        // Keep the operator's forward/backward cycle within the actual available controls.
        const controls = Array.from(
          event.currentTarget.querySelectorAll<HTMLElement>(
            'button:not([disabled]), input:not([disabled]), select:not([disabled]), textarea:not([disabled]), a[href], [tabindex]:not([tabindex="-1"])',
          ),
        ).filter((element) => element.tabIndex >= 0 && element.getClientRects().length > 0);
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
      }}
      className="sales-design-picker"
      onCancel={(event) => {
        event.preventDefault();
        onClose();
      }}
      style={{
        width: 'min(1120px, calc(100vw - 32px))',
        maxHeight: 'calc(100vh - 32px)',
        padding: 20,
        border: '1px solid #cbd5e1',
        borderRadius: 8,
        background: '#fff',
        color: '#0f172a',
      }}
    >
      <style>{'.sales-design-picker::backdrop { background: rgb(15 23 42 / 50%); }'}</style>
      <div
        style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', gap: 16 }}
      >
        <h2 id="sales-design-picker-title">Choose Design Book design</h2>
        <button type="button" onClick={onClose} aria-label="Close Design Book selection">
          Close
        </button>
      </div>
      <p>
        Designs for item {itemCode || '—'}. Selecting a design preserves the order’s weights and
        components.
      </p>
      <form
        onSubmit={(event) => {
          event.preventDefault();
          setRequest((value) => ({ search, offset: 0, attempt: value.attempt + 1 }));
        }}
        style={{
          display: 'flex',
          gap: 8,
          alignItems: 'center',
          flexWrap: 'wrap',
          marginBottom: 12,
        }}
      >
        <label htmlFor="sales-design-search">Search designs</label>
        <input
          ref={searchInput}
          id="sales-design-search"
          value={search}
          maxLength={100}
          onChange={(event) => setSearch(event.target.value)}
        />
        <button type="submit" disabled={!ready}>
          Search
        </button>
      </form>
      {!ready && (
        <p role="alert">Select a company, branch, year, Sales Order book and item first.</p>
      )}
      {ready && !result && <p role="status">Loading designs…</p>}
      {result?.error && <p role="alert">{result.error}</p>}
      {payload && (
        <>
          <div style={{ overflowX: 'auto', maxWidth: '100%' }}>
            <table
              aria-label="Available Design Book designs"
              style={{ width: '100%', borderCollapse: 'collapse' }}
            >
              <thead>
                <tr>
                  {[
                    'Design',
                    'Book',
                    payload.thirdColumnLabel,
                    'Size',
                    'Karigar',
                    'Gross weight',
                    'Touch',
                    'West %',
                    'Labour %',
                    'Labour rate',
                    'Actions',
                  ].map((label) => (
                    <th
                      key={label}
                      style={{
                        padding: 8,
                        textAlign: 'left',
                        whiteSpace: 'nowrap',
                        borderBottom: '1px solid #cbd5e1',
                      }}
                    >
                      {label}
                    </th>
                  ))}
                </tr>
              </thead>
              <tbody>
                {payload.rows.map((selection) => (
                  <tr key={JSON.stringify(selection.source)}>
                    {[
                      selection.designNo || '(empty design)',
                      selection.bookName,
                      payload.thirdColumnLabel === 'Remark'
                        ? selection.remark
                        : selection.productName,
                      selection.itmSize,
                      selection.karigarName,
                      selection.grossWt,
                      selection.touch,
                      selection.westPct,
                      selection.labourPct,
                      selection.labourRate,
                    ].map((value, index) => (
                      <td
                        key={index}
                        style={{
                          padding: 8,
                          borderBottom: '1px solid #e2e8f0',
                          whiteSpace: 'nowrap',
                        }}
                      >
                        {value ?? '—'}
                      </td>
                    ))}
                    <td style={{ padding: 8, whiteSpace: 'nowrap' }}>
                      <button
                        type="button"
                        aria-label={`Use ${selection.designNo || 'empty design'} from ${selection.bookName}, serial ${selection.source.srNo}`}
                        onClick={() => choose(selection)}
                      >
                        Use design
                      </button>{' '}
                      <button
                        type="button"
                        aria-label={`Preview ${selection.designNo || 'empty design'} from ${selection.bookName}, serial ${selection.source.srNo}`}
                        onClick={() => setPreview({ context, selection })}
                      >
                        Preview
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
          {!payload.rows.length && <p>No designs match this item and search.</p>}
          <div style={{ display: 'flex', alignItems: 'center', gap: 12, marginBlock: 12 }}>
            <button
              type="button"
              disabled={!payload.offset}
              onClick={() =>
                setRequest((value) => ({
                  ...value,
                  offset: Math.max(0, payload.offset - payload.limit),
                }))
              }
            >
              Previous designs
            </button>
            <span>
              {payload.rows.length
                ? `${payload.offset + 1}–${payload.offset + payload.rows.length}`
                : '0 designs'}
            </span>
            <button
              type="button"
              disabled={!payload.hasMore}
              onClick={() =>
                setRequest((value) => ({ ...value, offset: payload.offset + payload.limit }))
              }
            >
              Next designs
            </button>
          </div>
        </>
      )}
      <SalesOrderDesignPreview
        scope={scope}
        coBook={coBook}
        itemCode={itemCode}
        rowKey={rowKey}
        selection={chosen}
      />
    </dialog>
  );
}
