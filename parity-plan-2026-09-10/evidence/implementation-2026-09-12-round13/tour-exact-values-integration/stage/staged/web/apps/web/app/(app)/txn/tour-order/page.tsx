'use client';
import { useCallback, useEffect, useRef, useState } from 'react';
import { get, post, put, del, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import SubDetailGrid, {
  SUB_DETAIL_COLUMNS,
  type SubDetailField,
} from '../../../../components/SubDetailGrid';
import {
  blank,
  blankOrderHeader,
  extendedHeaderFields,
  extendedRowFields,
  hydrateTourOrder,
  tourOrderPayload,
  tourOrderQuery,
  setTourOrderCell,
  commitTourOrderLabour,
  tourOrderLineNet,
  type Row,
} from '../../../../lib/tourOrderForm';
import { OrderImagePanel } from '../../../../components/OrderImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { round } from '@datacare/core';

const r2 = (x: number) => round(x, 2);

export default function TourOrderPage() {
  const scope = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [labourPolicy, setLabourPolicy] = useState<{
    scope: string;
    includesGhat: boolean;
    rateDecimals: number;
  } | null>(null);
  const [f, setF] = useState(blankOrderHeader);
  const [selected, setSelected] = useState<{
    voucherNo: string;
    version: string;
    scope: string;
    original: Record<string, any>;
    blocked?: string;
  } | null>(null);
  const [voucherLookup, setVoucherLookup] = useState('');
  const [listError, setListError] = useState('');
  const scopeQuery = tourOrderQuery(scope, coBook);
  const scopeRef = useRef(scopeQuery);
  scopeRef.current = scopeQuery;
  const listRequest = useRef(0);
  const documentRequest = useRef(0);
  const [rows, setRenderedRows] = useState<Row[]>([blank()]);
  const rowsRef = useRef(rows);
  // Input/change/blur events can run before React paints the next row snapshot. Apply each
  // update to the latest queued rows so a cell commit cannot replace a neighbouring edit.
  const setRows = useCallback((update: Row[] | ((current: Row[]) => Row[])) => {
    const next = typeof update === 'function' ? update(rowsRef.current) : update;
    rowsRef.current = next;
    setRenderedRows(next);
  }, []);
  const [policyAttempt, setPolicyAttempt] = useState(0);
  const [policyError, setPolicyError] = useState<{ scope: string; message: string } | null>(null);
  const policyRequest = useRef(0);
  // P1-5: desktop grids are keyboard-first — arrows move, Enter advances and appends at the end,
  // Ctrl/Cmd+D removes a row (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    onAppendRow: () => setRows((current) => [...current, blank()]),
    onRemoveRow: (row) => {
      setRows((current) =>
        current.length === 1 ? [blank()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  // Desktop SL_ORD_DATA header fields (TR_SALE_ORD:9120-9161).
  const [header, setHeader] = useState<Record<string, string>>({});
  const [orders, setOrders] = useState<Record<string, any>[]>([]);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (k: keyof typeof f, v: string) => setF((x) => ({ ...x, [k]: v }));
  const setRow = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? setTourOrderCell(r, k, v) : r)));
  const priorLabourCell = useRef<Record<number, Row>>({});
  const focusLabour = (index: number) => {
    priorLabourCell.current[index] = rowsRef.current[index]!;
  };
  const commitLabour = (index: number, field: keyof Row) => {
    if (!labourPolicy || labourPolicy.scope !== scopeQuery) return;
    try {
      const previous = priorLabourCell.current[index] ?? rowsRef.current[index]!;
      setRows((current) => {
        const changed = commitTourOrderLabour(previous, current[index]!, field, labourPolicy);
        priorLabourCell.current[index] = changed;
        return current.map((row, i) => (i === index ? changed : row));
      });
    } catch (error) {
      setMsg({
        kind: 'err',
        text: error instanceof Error ? error.message : 'Invalid labour value',
      });
    }
  };

  const resetForm = useCallback(() => {
    setF(blankOrderHeader());
    setHeader({});
    setRows([blank()]);
    setSelected(null);
    setVoucherLookup('');
    setImageRow(0);
  }, [setRows]);
  const lineNet = (r: Row) => {
    try {
      return tourOrderLineNet(r, labourPolicy ?? { includesGhat: true, rateDecimals: 2 });
    } catch {
      return 0;
    } // Invalid transient input is rejected when the form is submitted.
  };
  const total = r2(rows.reduce((sum, row) => sum + (row.itCode.trim() ? lineNet(row) : 0), 0));

  const load = useCallback(async () => {
    const request = ++listRequest.current;
    if (!coBook) {
      setOrders([]);
      return;
    }
    try {
      const result = await get<any[]>(`/tour-orders?${scopeQuery}`);
      if (request === listRequest.current && scopeRef.current === scopeQuery) {
        setOrders(result);
        setListError('');
      }
    } catch (error) {
      if (request === listRequest.current && scopeRef.current === scopeQuery) {
        setOrders([]);
        setListError(error instanceof Error ? error.message : 'Could not load tour orders');
      }
    }
  }, [coBook, scopeQuery]);
  useEffect(() => {
    let cancelled = false;
    const request = ++policyRequest.current;
    setLabourPolicy(null);
    setPolicyError(null);
    if (coBook)
      void get<{ labourIncludesGhat: boolean; labourRateDecimals: number }>(
        `/tour-orders/configuration?${scopeQuery}`,
      )
        .then((configuration) => {
          if (!cancelled && request === policyRequest.current && scopeRef.current === scopeQuery)
            setLabourPolicy({
              scope: scopeQuery,
              includesGhat: configuration.labourIncludesGhat,
              rateDecimals: configuration.labourRateDecimals,
            });
        })
        .catch((error) => {
          if (!cancelled && request === policyRequest.current && scopeRef.current === scopeQuery)
            setPolicyError({ scope: scopeQuery, message: errorText(error) });
        });
    return () => {
      cancelled = true;
    };
  }, [coBook, scopeQuery, policyAttempt]);
  const previewReady = labourPolicy?.scope === scopeQuery;
  const configurationError = policyError?.scope === scopeQuery ? policyError.message : null;
  useEffect(() => {
    documentRequest.current += 1;
    resetForm();
    setBusy(false);
    setMsg(null);
    setOrders([]);
    setListError('');
    void load();
  }, [load, resetForm]);

  async function openOrder(voucherNo: string) {
    if (!coBook || !voucherNo.trim()) return;
    const request = ++documentRequest.current;
    setBusy(true);
    setMsg(null);
    try {
      const document = await get<any>(
        `/tour-orders/${encodeURIComponent(voucherNo.trim())}?${scopeQuery}`,
      );
      if (request !== documentRequest.current || scopeRef.current !== scopeQuery) return;
      const hydrated = hydrateTourOrder(document);
      policyRequest.current += 1;
      setPolicyError(null);
      setLabourPolicy({
        scope: scopeQuery,
        includesGhat: document.labourIncludesGhat,
        rateDecimals: document.labourRateDecimals,
      });
      setF(hydrated.f);
      setHeader(hydrated.header);
      setRows(hydrated.rows);
      setImageRow(0);
      setSelected({
        voucherNo: document.voucherNo,
        scope: scopeQuery,
        version: document.version,
        original: structuredClone(document),
        blocked:
          document.editBlockedReason ||
          (document.lines?.some((line: any) => line.consumed)
            ? 'This order has already been issued, tagged or delivered.'
            : undefined),
      });
      setVoucherLookup(document.voucherNo);
    } catch (error) {
      if (request === documentRequest.current && scopeRef.current === scopeQuery)
        setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      if (request === documentRequest.current) setBusy(false);
    }
  }

  function errorText(error: unknown) {
    return error instanceof ApiError
      ? error.body?.message || error.body?.error || error.message
      : error instanceof Error
        ? error.message
        : 'Tour order action failed';
  }

  async function submit(event: React.FormEvent) {
    event.preventDefault();
    setMsg(null);
    if (!coBook) {
      setMsg({ kind: 'err', text: 'Select a configured Tour Order book' });
      return;
    }
    if (!previewReady) {
      setMsg({
        kind: 'err',
        text: 'Load the selected book’s order calculation settings before saving.',
      });
      return;
    }
    if (selected?.blocked) {
      setMsg({ kind: 'err', text: selected.blocked });
      return;
    }
    if (selected && !selected.version) {
      setMsg({ kind: 'err', text: 'Reload this order before saving' });
      return;
    }
    setBusy(true);
    try {
      const payload = tourOrderPayload(
        f,
        header,
        rowsRef.current,
        selected?.version,
        selected?.original,
      );
      const result = selected
        ? await put(`/tour-orders/${encodeURIComponent(selected.voucherNo)}?${scopeQuery}`, payload)
        : await post(`/tour-orders?${scopeQuery}`, payload);
      if (scopeRef.current !== scopeQuery) return;
      resetForm();
      setMsg({
        kind: 'ok',
        text: `Tour order #${result.vchNo} ${selected ? 'updated' : 'saved'} — total ₹${Number(result.total).toLocaleString('en-IN')}`,
      });
      await load();
    } catch (error) {
      if (scopeRef.current === scopeQuery) setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function removeOrder() {
    if (
      !selected ||
      !selected.version ||
      !confirm(
        `Delete Tour Order #${selected.voucherNo}? This reverses its advance and removes the order.`,
      )
    )
      return;
    setBusy(true);
    setMsg(null);
    try {
      await del(`/tour-orders/${encodeURIComponent(selected.voucherNo)}?${scopeQuery}`, {
        expectedVersion: selected.version,
      });
      if (scopeRef.current !== scopeQuery) return;
      resetForm();
      setMsg({ kind: 'ok', text: `Tour order #${selected.voucherNo} deleted` });
      await load();
    } catch (error) {
      if (scopeRef.current === scopeQuery) setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }
  const printHref = (voucherNo: string) =>
    `/api/tour-orders/confirmation?${scopeQuery}&vchNo=${encodeURIComponent(voucherNo)}&format=html`;

  return (
    <div>
      <h1>Tour Order</h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <div className="row">
          <div className="field">
            <label>Tour Order book</label>
            <BookSelect
              key={`${scope.coCode}/${scope.lcCode}/${scope.coYear}`}
              value={coBook}
              onChange={setCoBook}
              preferred="510"
              mainBooks={['TOUR ORDER']}
              disabled={busy}
            />
          </div>
          <div className="field">
            <label htmlFor="tour-order-number">Order number</label>
            <input
              id="tour-order-number"
              value={voucherLookup}
              onChange={(event) => setVoucherLookup(event.target.value)}
              disabled={busy}
            />
          </div>
          <button
            type="button"
            onClick={() => void openOrder(voucherLookup)}
            disabled={busy || !coBook || !voucherLookup.trim()}
          >
            Load order
          </button>
          <button
            type="button"
            onClick={() => {
              resetForm();
              setMsg(null);
            }}
            disabled={busy}
          >
            New order
          </button>
        </div>
        {selected && (
          <div className="toolbar">
            <strong>Editing order #{selected.voucherNo}</strong>
            <a href={printHref(selected.voucherNo)} target="_blank" rel="noreferrer">
              Print order
            </a>
            <button
              type="button"
              className="danger"
              onClick={removeOrder}
              disabled={busy || !!selected.blocked}
            >
              Delete order
            </button>
          </div>
        )}
        {selected?.blocked && <p className="msg err">{selected.blocked}</p>}
      </div>
      {coBook &&
        !previewReady &&
        (configurationError ? (
          <div role="alert" className="msg err">
            Could not load order calculation settings: {configurationError}
            <button type="button" onClick={() => setPolicyAttempt((attempt) => attempt + 1)}>
              Retry order settings
            </button>
          </div>
        ) : (
          <p role="status">Loading order calculation settings…</p>
        ))}
      <form onSubmit={submit}>
        <fieldset
          disabled={busy || !!selected?.blocked || !previewReady}
          style={{ border: 0, padding: 0, minWidth: 0 }}
        >
          <div className="field">
            <label htmlFor="tour-order-date">Order date</label>
            <input
              id="tour-order-date"
              type="date"
              value={f.vchDate}
              onChange={(event) => set('vchDate', event.target.value)}
              required
            />
          </div>
          <div className="panel">
            <div className="row">
              <div className="field" style={{ flex: 2 }}>
                <label>Customer</label>
                <LookupPicker
                  entity="accounts"
                  ariaLabel="Customer account"
                  value={f.acCode}
                  onChange={(v) => set('acCode', v)}
                  onPick={(r) => {
                    if (!f.acName) set('acName', String(r.name || ''));
                  }}
                />
              </div>
              <div className="field">
                <label htmlFor="tour-order-customer-name">Customer Name</label>
                <input
                  id="tour-order-customer-name"
                  value={f.acName}
                  onChange={(e) => set('acName', e.target.value)}
                />
              </div>
              <div className="field">
                <label htmlFor="tour-order-tax">Tax %</label>
                <input
                  id="tour-order-tax"
                  value={f.taxRatePct}
                  onChange={(e) => set('taxRatePct', e.target.value)}
                />
              </div>
              <div className="field">
                <label htmlFor="tour-order-advance">Advance ₹</label>
                <input
                  id="tour-order-advance"
                  value={f.advanceAmount}
                  onChange={(e) => set('advanceAmount', e.target.value)}
                />
              </div>
            </div>
          </div>

          <div className="panel" style={{ overflow: 'auto' }}>
            <h2>Tour Order Items</h2>
            <table className="grid" onKeyDown={handleGridKey}>
              <thead>
                <tr>
                  <th>Item</th>
                  <th>Design</th>
                  <th className="num">Pcs</th>
                  <th className="num">Gross</th>
                  <th className="num">Net</th>
                  <th className="num">Touch</th>
                  <th className="num">Rate</th>
                  <th className="num">Labour rate</th>
                  <th className="num">Net Amt</th>
                  <th>Remark</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {rows.map((r, i) => (
                  <tr key={i} onFocus={() => setImageRow(i)}>
                    <td>
                      <LookupPicker
                        entity="items"
                        ariaLabel={`Item code ${i + 1}`}
                        value={r.itCode}
                        onChange={(v) => setRow(i, 'itCode', v)}
                        style={{ width: 110 }}
                      />
                    </td>
                    <td>
                      <input
                        aria-label={`Design item ${i + 1}`}
                        value={r.designNo}
                        onChange={(e) => setRow(i, 'designNo', e.target.value)}
                        style={{ width: 80 }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Pieces item ${i + 1}`}
                        value={r.pcs}
                        onChange={(e) => setRow(i, 'pcs', e.target.value)}
                        style={{ width: 56, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Gross weight item ${i + 1}`}
                        value={r.grossWt}
                        onChange={(e) => setRow(i, 'grossWt', e.target.value)}
                        style={{ width: 76, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Net weight item ${i + 1}`}
                        value={r.netWt}
                        onChange={(e) => setRow(i, 'netWt', e.target.value)}
                        style={{ width: 76, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Touch item ${i + 1}`}
                        value={r.touch}
                        onChange={(e) => setRow(i, 'touch', e.target.value)}
                        style={{ width: 60, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Rate item ${i + 1}`}
                        value={r.rate}
                        onChange={(e) => setRow(i, 'rate', e.target.value)}
                        style={{ width: 80, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Labour rate item ${i + 1}`}
                        value={r.labourRate}
                        onFocus={() => focusLabour(i)}
                        onBlur={() => commitLabour(i, 'labourRate')}
                        onChange={(e) => setRow(i, 'labourRate', e.target.value)}
                        style={{ width: 70, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      {r.itCode.trim() && previewReady ? lineNet(r).toLocaleString('en-IN') : '—'}
                    </td>
                    <td>
                      <input
                        aria-label={`Remark item ${i + 1}`}
                        value={r.remark}
                        onChange={(e) => setRow(i, 'remark', e.target.value)}
                        style={{ width: 120 }}
                      />
                    </td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() =>
                          setRows((rs) =>
                            rs.length > 1 ? rs.filter((_, j) => j !== i) : [blank()],
                          )
                        }
                      >
                        ×
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
              <tfoot>
                <tr>
                  <td colSpan={8} style={{ textAlign: 'right', fontWeight: 600 }}>
                    Order total (pre-tax)
                  </td>
                  <td className="num">
                    <b>{previewReady ? total.toLocaleString('en-IN') : 'Calculated on save'}</b>
                  </td>
                  <td colSpan={2}></td>
                </tr>
              </tfoot>
            </table>
            <details style={{ marginTop: 8 }}>
              <summary>Order details</summary>
              <div className="row">
                {extendedHeaderFields.map(([key, label]) => (
                  <div className="field" key={key}>
                    <label htmlFor={`tour-header-${key}`}>{label}</label>
                    <input
                      id={`tour-header-${key}`}
                      value={header[key] ?? ''}
                      onChange={(e) => setHeader((h) => ({ ...h, [key]: e.target.value }))}
                    />
                  </div>
                ))}
              </div>
            </details>
            {rows.map((row, index) => (
              <details key={`ord-row-extra-${index}`} style={{ marginTop: 8 }}>
                <summary>Item {index + 1} specifications and components</summary>
                <div className="row">
                  {extendedRowFields.map(([key, label]) => (
                    <div className="field" key={String(key)}>
                      <label htmlFor={`tour-line-${index}-${String(key)}`}>{label}</label>
                      {key === 'labourType' ? (
                        <select
                          id={`tour-line-${index}-${String(key)}`}
                          value={row.labourType}
                          onChange={(event) => setRow(index, key, event.target.value)}
                        >
                          <option value="">Net weight (default)</option>
                          <option value="N">Net weight</option>
                          <option value="G">Gross weight</option>
                          <option value="P">Pieces</option>
                          <option value="K">Kilograms</option>
                          {row.labourType && !['N', 'G', 'P', 'K'].includes(row.labourType) && (
                            <option value={row.labourType}>
                              {row.labourType} — saved default basis
                            </option>
                          )}
                        </select>
                      ) : (
                        <input
                          id={`tour-line-${index}-${String(key)}`}
                          value={String(row[key] ?? '')}
                          onFocus={() => focusLabour(index)}
                          onBlur={() => commitLabour(index, key)}
                          onChange={(e) => setRow(index, key, e.target.value)}
                        />
                      )}
                    </div>
                  ))}
                </div>
                <SubDetailGrid
                  rows={row.components}
                  onRowsChange={(components) =>
                    setRows((current) =>
                      current.map((line, i) => (i === index ? { ...line, components } : line)),
                    )
                  }
                  columns={
                    Object.keys(SUB_DETAIL_COLUMNS).filter(
                      (field) =>
                        !['rtnPcs', 'rtnWt', 'brokPcs', 'brokWt', 'oldItmIsu'].includes(field),
                    ) as SubDetailField[]
                  }
                  parentLabel={`item ${index + 1}`}
                />
              </details>
            ))}
            <div className="toolbar" style={{ marginTop: 10 }}>
              <button
                type="button"
                className="ghost"
                onClick={() => setRows((rs) => [...rs, blank()])}
              >
                + Add line
              </button>
              <span className="spacer" />
              <button className="primary" disabled={busy || !coBook || !previewReady}>
                {busy ? 'Saving…' : selected ? 'Update Tour Order' : 'Save Tour Order'}
              </button>
            </div>
          </div>
        </fieldset>
      </form>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>Recent Tour Orders</h2>
        {listError && <p className="msg err">{listError}</p>}
        {coBook && (
          <button type="button" className="ghost" onClick={load} disabled={busy}>
            Refresh orders
          </button>
        )}
        <table className="grid">
          <thead>
            <tr>
              <th>Order #</th>
              <th>Date</th>
              <th>Customer</th>
              <th>Name</th>
              <th className="num">Total</th>
              <th className="num">Advance</th>
              <th>Actions</th>
            </tr>
          </thead>
          <tbody>
            {orders.map((o, i) => (
              <tr key={i}>
                <td>{o.vchNo}</td>
                <td>{o.vchDate ? String(o.vchDate).slice(0, 10) : ''}</td>
                <td>{o.acCode}</td>
                <td>{o.acName}</td>
                <td className="num">{Number(o.total).toLocaleString('en-IN')}</td>
                <td className="num">{Number(o.advance).toLocaleString('en-IN')}</td>
                <td>
                  <button type="button" onClick={() => void openOrder(o.vchNo)} disabled={busy}>
                    Edit #{o.vchNo}
                  </button>{' '}
                  <a href={printHref(o.vchNo)} target="_blank" rel="noreferrer">
                    Print
                  </a>
                </td>
              </tr>
            ))}
            {orders.length === 0 && (
              <tr>
                <td colSpan={7} className="muted">
                  No tour orders.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      <OrderImagePanel
        family="tour-orders"
        scope={scope}
        coBook={coBook}
        voucherNo={selected?.scope === scopeQuery ? selected.voucherNo : ''}
        srNo={rows[imageRow]?.srNo}
        revision={selected?.version ?? ''}
        disabled={busy}
        testId="tour-order-image"
      />
    </div>
  );
}
