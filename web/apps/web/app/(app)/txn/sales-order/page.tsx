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
  hydrateSalesOrder,
  salesOrderPayload,
  salesOrderQuery,
  setSalesOrderCell,
  commitSalesOrderLabour,
  salesOrderLineNet,
  selectSalesOrderDesign,
  readonlyRowFields,
  readonlyHeaderFields,
  salesOrderTenderFields,
  type Row,
} from '../../../../lib/salesOrderForm';
import { OrderImagePanel } from '../../../../components/OrderImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { round, type SalesOrderDesignOption } from '@datacare/core';
import {
  SalesOrderDesignPicker,
  SalesOrderDesignPreview,
} from '../../../../components/SalesOrderDesignPicker';

const r2 = (x: number) => round(x, 2);

export default function SalesOrderPage() {
  const scope = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [labourPolicy, setLabourPolicy] = useState<{
    scope: string;
    includesGhat: boolean;
    rateDecimals: number;
    /** CO_SET.SL_AMT_TYPE: the weight the metal rate multiplies (N196, G205). */
    itemAmountType?: string;
    fiscalOpeningDate?: string;
    fiscalClosingDate?: string;
  } | null>(null);
  const [f, setF] = useState(blankOrderHeader);
  const headerDirty = useRef(new Set<string>());
  const [selection, setSelected] = useState<{
    voucherNo: string;
    version: string;
    scope: string;
    blocked?: string;
    original: Record<string, any>;
  } | null>(null);
  const [voucherLookup, setVoucherLookup] = useState('');
  const [listError, setListError] = useState('');
  const scopeQuery = salesOrderQuery(scope, coBook);
  const selected = selection?.scope === scopeQuery ? selection : null;
  const [editorScope, setEditorScope] = useState(scopeQuery);
  const editorCurrent = editorScope === scopeQuery;
  const scopeRef = useRef(scopeQuery);
  scopeRef.current = scopeQuery;
  const listRequest = useRef(0);
  const documentRequest = useRef(0);
  const [rows, setRenderedRows] = useState<Row[]>([blank(1)]);
  const parentSequence = useRef(1);
  const childSequences = useRef(new Map<string, number>());
  const appendRow = () => setRows((current) => [...current, blank(++parentSequence.current)]);
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
    onAppendRow: appendRow,
    onRemoveRow: (row) => {
      setRows((current) =>
        current.length === 1
          ? [blank(++parentSequence.current)]
          : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  const designInputRefs = useRef(new Map<string, HTMLInputElement>());
  const designReturnFocus = useRef<HTMLInputElement | null>(null);
  const [designContext, setDesignContext] = useState<{
    scope: string;
    rowKey: string;
    itemCode: string;
  } | null>(null);
  const [designPreview, setDesignPreview] = useState<{
    scope: string;
    rowKey: string;
    itemCode: string;
    selection: SalesOrderDesignOption;
  } | null>(null);
  const currentDesignRow =
    designContext?.scope === scopeQuery
      ? rows.find(
          (row) => row.clientKey === designContext.rowKey && row.itCode === designContext.itemCode,
        )
      : undefined;
  function openDesign(index: number) {
    const row = rowsRef.current[index];
    if (
      !row ||
      !row.itCode ||
      busy ||
      !previewReady ||
      !editorCurrent ||
      scopeRef.current !== scopeQuery ||
      selected?.blocked
    )
      return;
    designReturnFocus.current = designInputRefs.current.get(row.clientKey) ?? null;
    setDesignContext({ scope: scopeQuery, rowKey: row.clientKey, itemCode: row.itCode });
  }
  function pickDesign(option: SalesOrderDesignOption) {
    if (
      !designContext ||
      !currentDesignRow ||
      !editorCurrent ||
      scopeRef.current !== designContext.scope ||
      busy ||
      !previewReady ||
      selected?.blocked
    )
      return;
    const currentRow = rowsRef.current.find(
      (row) => row.clientKey === designContext.rowKey && row.itCode === designContext.itemCode,
    );
    if (!currentRow) return;
    const existing = !!selected?.original.lines?.some(
      (line: any) => String(line.srNo) === currentRow.srNo,
    );
    setRows((current) =>
      current.map((row) =>
        row.clientKey === currentDesignRow.clientKey
          ? selectSalesOrderDesign(row, option, existing)
          : row,
      ),
    );
    setDesignPreview({ ...designContext, selection: option });
  }
  // Desktop SL_ORD_DATA header fields (TR_SALE_ORD:9120-9161).
  const [header, setHeader] = useState<Record<string, string>>({});
  const [orderList, setOrderList] = useState<{ scope: string; rows: Record<string, any>[] }>({
    scope: scopeQuery,
    rows: [],
  });
  const orders = orderList.scope === scopeQuery ? orderList.rows : [];
  const setOrders = useCallback(
    (items: Record<string, any>[]) => setOrderList({ scope: scopeQuery, rows: items }),
    [scopeQuery],
  );
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (k: keyof typeof f, v: string) => {
    headerDirty.current.add(k);
    setF((x) => ({ ...x, [k]: v }));
  };
  const setRow = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? setSalesOrderCell(r, k, v) : r)));
  const priorLabourCell = useRef<Record<string, Row>>({});
  const focusLabour = (index: number) => {
    const row = rowsRef.current[index];
    if (row) priorLabourCell.current[row.clientKey] = row;
  };
  const commitLabour = (index: number, field: keyof Row) => {
    if (!labourPolicy || labourPolicy.scope !== scopeQuery) return;
    try {
      const row = rowsRef.current[index];
      if (!row) return;
      const previous = priorLabourCell.current[row.clientKey] ?? row;
      setRows((current) => {
        const changed = commitSalesOrderLabour(previous, current[index]!, field, labourPolicy);
        priorLabourCell.current[row.clientKey] = changed;
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
    documentRequest.current += 1;
    setEditorScope(scopeQuery);
    parentSequence.current = 1;
    childSequences.current.clear();
    headerDirty.current.clear();
    setDesignContext(null);
    setDesignPreview(null);
    setF(blankOrderHeader());
    setHeader({});
    setRows([blank(1)]);
    setSelected(null);
    setVoucherLookup('');
    setImageRow(0);
  }, [setRows, scopeQuery]);
  const lineNet = (r: Row) => {
    try {
      return salesOrderLineNet(r, labourPolicy ?? { includesGhat: true, rateDecimals: 2 });
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
      const result = await get<any[]>(`/sales-orders?${scopeQuery}`);
      if (request === listRequest.current && scopeRef.current === scopeQuery) {
        setOrders(result);
        setListError('');
      }
    } catch (error) {
      if (request === listRequest.current && scopeRef.current === scopeQuery) {
        setOrders([]);
        setListError(error instanceof Error ? error.message : 'Could not load sales orders');
      }
    }
  }, [coBook, scopeQuery, setOrders]);
  useEffect(() => {
    let cancelled = false;
    const request = ++policyRequest.current;
    setLabourPolicy(null);
    setPolicyError(null);
    if (coBook)
      void get<{
        labourIncludesGhat: boolean;
        labourRateDecimals: number;
        itemAmountType?: string;
        fiscalOpeningDate?: string;
        fiscalClosingDate?: string;
      }>(`/sales-orders/configuration?${scopeQuery}`)
        .then((configuration) => {
          if (!cancelled && request === policyRequest.current && scopeRef.current === scopeQuery)
            setLabourPolicy({
              scope: scopeQuery,
              includesGhat: configuration.labourIncludesGhat,
              rateDecimals: configuration.labourRateDecimals,
              itemAmountType: configuration.itemAmountType,
              fiscalOpeningDate: configuration.fiscalOpeningDate,
              fiscalClosingDate: configuration.fiscalClosingDate,
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
  }, [load, resetForm, setOrders]);

  async function openOrder(voucherNo: string) {
    if (!coBook || !voucherNo.trim()) return;
    resetForm();
    const generation = documentRequest.current;
    setBusy(true);
    setMsg(null);
    try {
      const document = await get<any>(
        `/sales-orders/${encodeURIComponent(voucherNo.trim())}?${scopeQuery}`,
      );
      if (generation !== documentRequest.current || scopeRef.current !== scopeQuery) return;
      if (
        document.coCode !== scope.coCode ||
        document.lcCode !== scope.lcCode ||
        document.coYear !== scope.coYear ||
        document.coBook !== coBook
      )
        throw new Error(
          'The saved order does not match the selected company, branch, year and book.',
        );
      const hydrated = hydrateSalesOrder(document);
      parentSequence.current = Math.max(
        0,
        ...hydrated.rows.map((row: Row) => Number(row.srNo || 0)),
      );
      for (const row of hydrated.rows)
        childSequences.current.set(
          row.clientKey,
          Math.max(0, ...row.components.map((child) => Number(child.isrNo || 0))),
        );
      policyRequest.current += 1;
      setPolicyError(null);
      setLabourPolicy({
        scope: scopeQuery,
        includesGhat: document.labourIncludesGhat,
        rateDecimals: document.labourRateDecimals,
        fiscalOpeningDate:
          labourPolicy?.scope === scopeQuery ? labourPolicy.fiscalOpeningDate : undefined,
        fiscalClosingDate:
          labourPolicy?.scope === scopeQuery ? labourPolicy.fiscalClosingDate : undefined,
      });
      setF(hydrated.f);
      setHeader(hydrated.header);
      setRows(hydrated.rows);
      setImageRow(0);
      setSelected({
        voucherNo: document.voucherNo,
        scope: scopeQuery,
        version: document.version,
        original: document,
        blocked:
          document.editBlockedReason ||
          (document.lines?.some((line: any) => line.consumed)
            ? 'This order has already been issued, tagged or delivered.'
            : undefined),
      });
      setVoucherLookup(document.voucherNo);
    } catch (error) {
      if (generation === documentRequest.current && scopeRef.current === scopeQuery)
        setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      if (generation === documentRequest.current && scopeRef.current === scopeQuery) setBusy(false);
    }
  }

  function errorText(error: unknown) {
    return error instanceof ApiError
      ? error.body?.message || error.body?.error || error.message
      : error instanceof Error
        ? error.message
        : 'Sales order action failed';
  }

  async function submit(event: React.FormEvent) {
    event.preventDefault();
    setMsg(null);
    if (!coBook) {
      setMsg({ kind: 'err', text: 'Select a configured Sales Order book' });
      return;
    }
    if (!previewReady || !editorCurrent) {
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
      const payload = salesOrderPayload(
        f,
        header,
        rowsRef.current,
        selected?.version,
        selected?.original,
        [...headerDirty.current],
      );
      const result = selected
        ? await put(
            `/sales-orders/${encodeURIComponent(selected.voucherNo)}?${scopeQuery}`,
            payload,
          )
        : await post(`/sales-orders?${scopeQuery}`, payload);
      if (scopeRef.current !== scopeQuery) return;
      resetForm();
      setMsg({
        kind: 'ok',
        text: `Sales order #${result.vchNo} ${selected ? 'updated' : 'saved'} — total ₹${Number(result.total).toLocaleString('en-IN')}`,
      });
      await load();
    } catch (error) {
      if (scopeRef.current === scopeQuery) setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      if (scopeRef.current === scopeQuery) setBusy(false);
    }
  }

  async function removeOrder() {
    if (
      !editorCurrent ||
      scopeRef.current !== scopeQuery ||
      !selected ||
      !selected.version ||
      !confirm(
        `Delete Sales Order #${selected.voucherNo}? This reverses its advance and removes the order.`,
      )
    )
      return;
    if (scopeRef.current !== scopeQuery || selected.scope !== scopeQuery) return;
    setBusy(true);
    setMsg(null);
    try {
      await del(`/sales-orders/${encodeURIComponent(selected.voucherNo)}?${scopeQuery}`, {
        expectedVersion: selected.version,
      });
      if (scopeRef.current !== scopeQuery) return;
      resetForm();
      setMsg({ kind: 'ok', text: `Sales order #${selected.voucherNo} deleted` });
      await load();
    } catch (error) {
      if (scopeRef.current === scopeQuery) setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      if (scopeRef.current === scopeQuery) setBusy(false);
    }
  }
  const savedImageRow = selected?.original.lines?.find(
    (line: any) => String(line.srNo) === rows[imageRow]?.srNo,
  );
  const savedImageCurrent =
    !!savedImageRow &&
    String(savedImageRow.designNo ?? '') === rows[imageRow]?.designNo &&
    String(savedImageRow.designImageId ?? '') === rows[imageRow]?.designImageId;
  const printHref = (voucherNo: string) =>
    `/api/sales/order-confirmation?${scopeQuery}&vchNo=${encodeURIComponent(voucherNo)}&format=html`;

  return (
    <div style={{ minWidth: 0, maxWidth: '100%' }}>
      <h1>Sales Order</h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <div className="row">
          <div className="field">
            <label>Sales Order book</label>
            <BookSelect
              key={`${scope.coCode}/${scope.lcCode}/${scope.coYear}`}
              value={coBook}
              onChange={setCoBook}
              mainBooks={['SALES ORDER']}
              disabled={busy}
            />
          </div>
          <div className="field">
            <label htmlFor="sales-order-number">Order number</label>
            <input
              id="sales-order-number"
              data-testid="sales-order-image-lookup"
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
      <form onSubmit={submit} aria-label="Sales Order editor" hidden={!editorCurrent}>
        <fieldset
          disabled={busy || !!selected?.blocked || !previewReady || !editorCurrent}
          style={{ border: 0, padding: 0, minWidth: 0 }}
        >
          <div className="field">
            <label htmlFor="sales-order-date">Order date</label>
            <input
              id="sales-order-date"
              type="date"
              min={previewReady ? labourPolicy?.fiscalOpeningDate : undefined}
              max={previewReady ? labourPolicy?.fiscalClosingDate : undefined}
              value={editorCurrent ? f.vchDate : ''}
              onChange={(event) => set('vchDate', event.target.value)}
              required
            />
            <small>
              Choose a date in the selected financial year. The desktop’s prior-year confirmation
              exception is not available here.
            </small>
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
                <label htmlFor="sales-order-customer-name">Customer Name</label>
                <input
                  id="sales-order-customer-name"
                  value={f.acName}
                  onChange={(e) => set('acName', e.target.value)}
                />
              </div>
              <div className="field">
                <label htmlFor="sales-order-tax">Tax %</label>
                <input
                  id="sales-order-tax"
                  value={f.taxRatePct}
                  onChange={(e) => set('taxRatePct', e.target.value)}
                />
              </div>
              <div className="field">
                <label htmlFor="sales-order-advance">Advance ₹</label>
                <input
                  id="sales-order-advance"
                  value={f.advanceAmount}
                  onChange={(e) => set('advanceAmount', e.target.value)}
                />
              </div>
            </div>
          </div>

          <div className="panel" style={{ overflow: 'auto' }}>
            <h2>Sales Order Items</h2>
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
                {(editorCurrent ? rows : []).map((r, i) => (
                  <tr key={r.clientKey} onFocus={() => setImageRow(i)}>
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
                        ref={(element) => {
                          if (element) designInputRefs.current.set(r.clientKey, element);
                          else designInputRefs.current.delete(r.clientKey);
                        }}
                        onKeyDown={(event) => {
                          if (event.key === 'F1') {
                            event.preventDefault();
                            event.stopPropagation();
                            openDesign(i);
                          }
                        }}
                        value={r.designNo}
                        onChange={(e) => setRow(i, 'designNo', e.target.value)}
                        style={{ width: 80 }}
                      />
                      <button
                        type="button"
                        onClick={() => openDesign(i)}
                        disabled={!r.itCode}
                        aria-label={`Choose design item ${i + 1}`}
                      >
                        Choose…
                      </button>
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Pieces item ${i + 1}`}
                        onFocus={() => focusLabour(i)}
                        onBlur={() => commitLabour(i, 'pcs')}
                        value={r.pcs}
                        onChange={(e) => setRow(i, 'pcs', e.target.value)}
                        style={{ width: 56, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Gross weight item ${i + 1}`}
                        onFocus={() => focusLabour(i)}
                        onBlur={() => commitLabour(i, 'grossWt')}
                        value={r.grossWt}
                        onChange={(e) => setRow(i, 'grossWt', e.target.value)}
                        style={{ width: 76, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Net weight item ${i + 1}`}
                        onFocus={() => focusLabour(i)}
                        onBlur={() => commitLabour(i, 'netWt')}
                        value={r.netWt}
                        onChange={(e) => setRow(i, 'netWt', e.target.value)}
                        style={{ width: 76, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Touch item ${i + 1}`}
                        onFocus={() => focusLabour(i)}
                        onBlur={() => commitLabour(i, 'touch')}
                        value={r.touch}
                        onChange={(e) => setRow(i, 'touch', e.target.value)}
                        style={{ width: 60, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        aria-label={`Rate item ${i + 1}`}
                        onFocus={() => focusLabour(i)}
                        onBlur={() => commitLabour(i, 'rate')}
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
                            rs.length > 1
                              ? rs.filter((_, j) => j !== i)
                              : [blank(++parentSequence.current)],
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
              <p className="muted">
                Saved settlement values are shown for reference. Separate tender, metal and
                allocation workflows are not available here.
              </p>
              <div className="row">
                {[...extendedHeaderFields, ...salesOrderTenderFields].map(([key, label]) => (
                  <div className="field" key={key}>
                    <label htmlFor={`sales-header-${key}`}>
                      {key === 'netAmount' ? 'Saved Net Amount' : label}
                      {readonlyHeaderFields.has(key) && (
                        <span aria-hidden="true" className="muted">
                          {' '}
                          · Read only
                        </span>
                      )}
                    </label>
                    <input
                      id={`sales-header-${key}`}
                      value={header[key] ?? ''}
                      readOnly={readonlyHeaderFields.has(key)}
                      style={
                        readonlyHeaderFields.has(key)
                          ? {
                              backgroundColor: '#eef2f6',
                              color: '#374151',
                              borderStyle: 'dashed',
                              cursor: 'default',
                            }
                          : undefined
                      }
                      aria-description={
                        key === 'netAmount'
                          ? 'Saved calculated amount; update the item values to change the order.'
                          : readonlyHeaderFields.has(key)
                            ? 'Saved value; settlement workflow is not available here'
                            : undefined
                      }
                      onChange={(e) => {
                        headerDirty.current.add(key);
                        setHeader((h) => ({ ...h, [key]: e.target.value }));
                      }}
                    />
                  </div>
                ))}
              </div>
            </details>
            {(editorCurrent ? rows : []).map((row, index) => (
              <details
                key={row.clientKey}
                style={{ marginTop: 8 }}
                onFocusCapture={() => setImageRow(index)}
              >
                <summary>Item {index + 1} specifications and components</summary>
                <div className="row">
                  {extendedRowFields.map(([key, label]) => (
                    <div className="field" key={String(key)}>
                      <label htmlFor={`sales-line-${index}-${String(key)}`}>{label}</label>
                      {key === 'labourType' ? (
                        <select
                          id={`sales-line-${index}-${String(key)}`}
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
                          id={`sales-line-${index}-${String(key)}`}
                          value={String(row[key] ?? '')}
                          readOnly={readonlyRowFields.has(String(key))}
                          aria-description={
                            readonlyRowFields.has(String(key)) ? 'Saved source identity' : undefined
                          }
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
                      current.map((line, i) => {
                        if (i !== index) return line;
                        const componentDirty = { ...line.componentDirty };
                        const next = components.map((cell) => {
                          const child = cell as Row['components'][number];
                          if (child.isrNo) {
                            const previous = line.components.find(
                              (saved) => saved.isrNo === child.isrNo,
                            );
                            const dirty = Object.keys(SUB_DETAIL_COLUMNS).filter(
                              (key) =>
                                String((previous as any)?.[key] ?? '') !==
                                String((child as any)[key] ?? ''),
                            );
                            componentDirty[child.isrNo] = [
                              ...new Set([...(componentDirty[child.isrNo] ?? []), ...dirty]),
                            ];
                            return child;
                          }
                          if (
                            !Object.keys(SUB_DETAIL_COLUMNS).some((key) =>
                              String((child as any)[key] ?? '').trim(),
                            )
                          )
                            return child;
                          const no = (childSequences.current.get(line.clientKey) ?? 0) + 1;
                          childSequences.current.set(line.clientKey, no);
                          return { ...child, isrNo: String(no) };
                        });
                        return { ...line, components: next, componentDirty };
                      }),
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
              <button type="button" className="ghost" onClick={appendRow}>
                + Add line
              </button>
              <span className="spacer" />
              <button
                className="primary"
                data-save-mnemonic
                disabled={busy || !coBook || !previewReady}
              >
                {busy ? 'Saving…' : selected ? 'Update Sales Order' : 'Save Sales Order'}
              </button>
            </div>
          </div>
        </fieldset>
      </form>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>Recent Sales Orders</h2>
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
                  No sales orders.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      {selected && (
        <div className="panel" data-testid="sales-order-saved-images">
          <label>
            Saved item{' '}
            <select
              data-testid="sales-order-image-parent"
              value={rows[imageRow]?.srNo ?? ''}
              onChange={(event) =>
                setImageRow(rows.findIndex((row) => row.srNo === event.target.value))
              }
            >
              {rows.map((row, index) => (
                <option key={row.clientKey} value={row.srNo}>
                  {row.srNo ?? index + 1} — {row.itCode} · {row.designNo || 'No design number'}
                </option>
              ))}
            </select>
          </label>
        </div>
      )}
      <SalesOrderDesignPicker
        open={!!currentDesignRow}
        scope={scope}
        coBook={coBook}
        itemCode={currentDesignRow?.itCode ?? ''}
        rowKey={currentDesignRow?.clientKey ?? ''}
        onSelect={pickDesign}
        onClose={() => setDesignContext(null)}
        returnFocusRef={designReturnFocus}
      />
      <SalesOrderDesignPreview
        scope={scope}
        coBook={coBook}
        itemCode={rows[imageRow]?.itCode ?? ''}
        rowKey={rows[imageRow]?.clientKey ?? ''}
        selection={
          designPreview?.scope === scopeQuery &&
          designPreview.rowKey === rows[imageRow]?.clientKey &&
          designPreview.itemCode === rows[imageRow]?.itCode &&
          designPreview.selection.designNo === rows[imageRow]?.designNo &&
          (designPreview.selection.designImageId ?? '') === rows[imageRow]?.designImageId
            ? designPreview.selection
            : null
        }
      />
      {selected && savedImageRow && !savedImageCurrent && (
        <p role="status" data-testid="sales-order-image-draft">
          Save and reload this order to use saved image actions for the changed design.
        </p>
      )}
      <OrderImagePanel
        family="sales-orders"
        scope={scope}
        coBook={coBook}
        voucherNo={savedImageCurrent && selected?.scope === scopeQuery ? selected.voucherNo : ''}
        srNo={savedImageCurrent ? String(savedImageRow.srNo) : undefined}
        revision={selected?.version ?? ''}
        disabled={busy || !savedImageCurrent}
        testId="sales-order-image"
      />
    </div>
  );
}
