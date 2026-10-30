'use client';

import { useEffect, useMemo, useState } from 'react';
import { ApiError, del, get, getBlob, post, put } from '../lib/api';
import { LookupPicker } from './LookupPicker';
import { useGridKeyboard } from './GridKeyboard';
import {
  blankEBillDraft,
  blankEBillLine,
  draftFromEntry,
  eBillRequest,
  LABOUR_TYPES,
  previewEBill,
  RATE_TYPES,
  type EBillDraft,
  type EBillEntryConfig,
  type EBillEntryView,
  type EBillFamily,
  type EBillLineDraft,
} from '../lib/eBillEntry';
import { todayLocal } from '../lib/localDate';

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  revision: string;
};
const today = () => todayLocal();
const fmt = (value: number, dp = 2) =>
  Number(value || 0).toLocaleString('en-IN', {
    minimumFractionDigits: dp,
    maximumFractionDigits: dp,
  });
const errorText = (error: unknown) =>
  error instanceof ApiError
    ? error.body?.message || error.body?.detail || error.body?.error || error.message
    : error instanceof Error
      ? error.message
      : 'Request failed';

const NUMERIC: Array<[keyof EBillLineDraft, string, number]> = [
  ['pcs', 'Pcs', 0],
  ['grossWt', 'Gross wt', 3],
  ['lessWt', 'Less wt', 3],
  ['ghatPercent', 'Ghat %', 3],
  ['touch', 'Touch', 2],
  ['westPercent', 'Wastage %', 2],
  ['rate', 'Rate', 2],
  ['labourRate', 'Labour rate', 2],
  ['labourPercent', 'Labour %', 3],
  ['otherAmount', 'Other amt', 2],
  ['mrp', 'MRP', 2],
];

const FAMILY_UI: Record<
  EBillFamily,
  { api: string; noun: string; Noun: string; region: string; book: string; ledgerNote: string }
> = {
  'E CRNT': {
    api: '/e-credit-notes',
    noun: 'credit note',
    Noun: 'Credit note',
    region: 'Credit note entry',
    book: 'E CRNT',
    ledgerNote: 'non-item credit',
  },
  'E INVOICE': {
    api: '/e-invoices',
    noun: 'e-invoice',
    Noun: 'E-invoice',
    region: 'E-invoice entry',
    book: 'E INVOICE',
    ledgerNote: 'non-item income',
  },
};

/**
 * TR_SL_EBILL entry in either mode: create, reopen, edit, delete and print an E CRNT credit note or
 * an E INVOICE e-invoice. The browser previews totals with the shared core arithmetic; the API
 * recomputes and is authoritative.
 */
export function EBillEntry({
  family = 'E CRNT',
  coBook,
  coYear,
  scopeKey,
  editVoucherNo,
  onSaved,
  onDeleted,
}: {
  family?: EBillFamily;
  coBook: string;
  coYear: string;
  scopeKey: string;
  /** "<voucher>#<request sequence>" chosen from the saved-document view; each new value reloads. */
  editVoucherNo: string | null;
  onSaved: (voucherNo: string) => void;
  onDeleted: () => void;
}) {
  const ui = FAMILY_UI[family];
  const invoice = family === 'E INVOICE';
  const [config, setConfig] = useState<EBillEntryConfig | null>(null);
  const [draft, setDraft] = useState<EBillDraft>(() => blankEBillDraft(today()));
  const [loaded, setLoaded] = useState<EBillEntryView | null>(null);
  const [priorDebits, setPriorDebits] = useState(0);
  const [busy, setBusy] = useState(false);
  const [message, setMessage] = useState('');
  const query = new URLSearchParams({ coBook, coYear }).toString();

  useEffect(() => {
    setLoaded(null);
    setMessage('');
    setConfig(null);
    if (!coBook) return;
    let active = true;
    get<EBillEntryConfig>(`${ui.api}/entry-config?${query}`)
      .then((value) => {
        if (!active) return;
        setConfig(value);
        setDraft(blankEBillDraft(today(), value));
      })
      .catch((error) => active && setMessage(errorText(error)));
    return () => {
      active = false;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [scopeKey]);

  useEffect(() => {
    if (editVoucherNo && coBook) void open(editVoucherNo.split('#')[0]!);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [editVoucherNo]);

  const preview = useMemo(
    () => previewEBill(draft, config, { family, creating: !loaded, priorDebits }),
    [draft, config, family, loaded, priorDebits],
  );
  const locked = Boolean(loaded?.irnLocked);
  const set = (patch: Partial<EBillDraft>) => setDraft((d) => ({ ...d, ...patch }));
  const setLine = (index: number, patch: Partial<EBillLineDraft>) =>
    setDraft((d) => ({
      ...d,
      lines: d.lines.map((l, i) => (i === index ? { ...l, ...patch } : l)),
    }));
  const addLine = () =>
    setDraft((d) => ({ ...d, lines: [...d.lines, blankEBillLine(config ?? undefined)] }));
  const removeLine = (index: number) => {
    if (draft.lines.length === 1) return false;
    setDraft((d) => ({ ...d, lines: d.lines.filter((_, i) => i !== index) }));
    return true;
  };
  const gridKeys = useGridKeyboard({
    rowCount: draft.lines.length,
    columnCount: NUMERIC.length + 5,
    onAppendRow: addLine,
    onRemoveRow: removeLine,
    onEscape: () => setMessage(''),
  });

  async function act(task: () => Promise<void>) {
    setBusy(true);
    setMessage('');
    try {
      await task();
    } catch (error) {
      setMessage(errorText(error));
    } finally {
      setBusy(false);
    }
  }
  function reset() {
    setLoaded(null);
    setPriorDebits(0);
    setDraft(blankEBillDraft(today(), config ?? undefined));
    setMessage('');
  }
  /** tAcCode_KeyDown 8417: the party's AcTcsAmt drives the new-voucher TCS threshold preview. */
  async function loadTcsBasis(partyCode: string) {
    if (!invoice || !partyCode.trim()) return setPriorDebits(0);
    try {
      const basis = await get<{ priorDebits: number }>(
        `/e-invoices/tcs-basis?${query}&partyCode=${encodeURIComponent(partyCode.trim())}`,
      );
      setPriorDebits(Number(basis.priorDebits) || 0);
    } catch {
      setPriorDebits(0);
    }
  }
  async function open(voucherNo: string) {
    await act(async () => {
      const view = await get<EBillEntryView>(
        `${ui.api}/${encodeURIComponent(voucherNo)}/entry?${query}`,
      );
      setLoaded(view);
      setDraft(draftFromEntry(view));
      if (view.irnLocked)
        setMessage(
          `IRN is generated for this ${ui.noun}: cancel the IRN before editing or deleting.`,
        );
    });
  }
  async function save() {
    if (!draft.partyCode.trim()) return setMessage('Please Insert Party and try');
    if (config?.employeeMandatory && !draft.employeeCode.trim())
      return setMessage('Please Select Employee Code and Try......');
    await act(async () => {
      const body = eBillRequest(draft, coBook, family, loaded?.revision);
      const result = loaded
        ? await put<SaveResult>(`${ui.api}/${encodeURIComponent(loaded.voucherNo)}?${query}`, body)
        : await post<SaveResult>(`${ui.api}?${query}`, body);
      const view = await get<EBillEntryView>(
        `${ui.api}/${encodeURIComponent(result.voucherNo)}/entry?${query}`,
      );
      setLoaded(view);
      setDraft(draftFromEntry(view));
      setMessage(`${result.created ? 'Saved' : 'Updated'} ${ui.noun} ${result.voucherNo}.`);
      onSaved(result.voucherNo);
    });
  }
  async function remove() {
    if (!loaded || !window.confirm('Are You Sure To Delete This Voucher now?')) return;
    await act(async () => {
      await del(`${ui.api}/${encodeURIComponent(loaded.voucherNo)}?${query}`, {
        expectedRevision: loaded.revision,
      });
      const deleted = loaded.voucherNo;
      reset();
      setMessage(`Delete Success. ${ui.Noun} ${deleted} removed.`);
      onDeleted();
    });
  }
  async function print(copy?: 'O' | 'D') {
    if (!loaded) return;
    await act(async () => {
      const blob = await getBlob(
        `${ui.api}/${encodeURIComponent(loaded.voucherNo)}/print?${query}&format=html${copy ? `&copy=${copy}` : ''}`,
      );
      const url = URL.createObjectURL(blob);
      window.open(url, '_blank', 'noopener');
      setTimeout(() => URL.revokeObjectURL(url), 60_000);
    });
  }
  async function cancelIrn() {
    if (!loaded || !window.confirm(`Cancel the IRN registered for this ${ui.noun}?`)) return;
    await act(async () => {
      await post(`${ui.api}/${encodeURIComponent(loaded.voucherNo)}/irn/cancel?${query}`, {
        reason: '2',
        remark: `Cancelled from the ${family} entry`,
      });
      await open(loaded.voucherNo);
      setMessage(`IRN cancelled; the ${ui.noun} can be edited again.`);
    });
  }
  /** BtnIrnGen_Click (E INVOICE page only; E CRNT keeps its saved-document IRN action). */
  async function generateIrn() {
    if (!loaded) return;
    await act(async () => {
      const result = await post<{ irn: string; mode: string }>(
        `/e-invoices/${encodeURIComponent(loaded.voucherNo)}/irn?${query}`,
        {},
      );
      const voucherNo = loaded.voucherNo;
      await open(voucherNo);
      setMessage(`IRN generated for e-invoice ${voucherNo} (${result.mode}).`);
    });
  }

  const b = preview.bill;
  return (
    <section className="panel" aria-label={ui.region}>
      <h2>{loaded ? `Edit ${ui.noun} ${loaded.voucherNo}` : `New ${ui.noun}`}</h2>
      {!coBook && (
        <p className="muted">
          Select an {ui.book} book to enter {invoice ? 'an' : 'a'} {ui.noun}.
        </p>
      )}
      <fieldset disabled={busy || !coBook || locked} style={{ border: 0, padding: 0 }}>
        <div className="row" style={{ flexWrap: 'wrap', gap: 12 }}>
          <div className="field">
            <label htmlFor="crn-date">{ui.Noun} date</label>
            <input
              id="crn-date"
              type="date"
              value={draft.vchDate}
              onChange={(e) => set({ vchDate: e.target.value })}
            />
          </div>
          <div className="field">
            <label>Party</label>
            <LookupPicker
              entity="accounts"
              ariaLabel="Party account"
              value={draft.partyCode}
              onChange={(code) => set({ partyCode: code })}
              onPick={(row) => {
                set({
                  partyName: String(row.name ?? ''),
                  partyGstType: String(row.AC_GST_TYPE ?? ''),
                });
                if (!loaded) void loadTcsBasis(String(row.code ?? ''));
              }}
            />
          </div>
          <div className="field">
            <label htmlFor="crn-party-name">Party name</label>
            <input id="crn-party-name" value={draft.partyName} readOnly />
          </div>
          <div className="field">
            <label htmlFor="crn-gst">GST type</label>
            <select
              id="crn-gst"
              value={draft.partyGstType === 'I' ? 'I' : 'L'}
              onChange={(e) => set({ partyGstType: e.target.value })}
            >
              <option value="L">Local (CGST + SGST)</option>
              <option value="I">Inter-state (IGST)</option>
            </select>
          </div>
          <div className="field">
            <label htmlFor="crn-ref">Ref No</label>
            <input
              id="crn-ref"
              maxLength={20}
              value={draft.billNo}
              onChange={(e) => set({ billNo: e.target.value })}
            />
          </div>
          <div className="field">
            <label>Ledger ({ui.ledgerNote})</label>
            <LookupPicker
              entity="accounts"
              ariaLabel="Ledger account"
              value={draft.ledgerCode}
              onChange={(code) => set({ ledgerCode: code })}
            />
          </div>
          <div className="field">
            <label htmlFor="crn-emp">Employee{config?.employeeMandatory ? ' *' : ''}</label>
            <input
              id="crn-emp"
              value={draft.employeeCode}
              onChange={(e) => set({ employeeCode: e.target.value })}
            />
          </div>
          <div className="field" style={{ minWidth: 260 }}>
            <label htmlFor="crn-desc">Remarks</label>
            <input
              id="crn-desc"
              maxLength={150}
              value={draft.description}
              onChange={(e) => set({ description: e.target.value })}
            />
          </div>
        </div>
        <p className="muted">
          GST type is taken from the party master when a party is picked; the server always posts
          with the master value.
        </p>

        <div style={{ overflowX: 'auto' }} onKeyDown={gridKeys}>
          <table aria-label={`${ui.Noun} lines`}>
            <thead>
              <tr>
                <th>#</th>
                <th>Item</th>
                <th>Design</th>
                {NUMERIC.slice(0, 6).map(([, label]) => (
                  <th key={label}>{label}</th>
                ))}
                <th>Rate type</th>
                <th>Rate</th>
                <th>Labour type</th>
                {NUMERIC.slice(7).map(([, label]) => (
                  <th key={label}>{label}</th>
                ))}
                <th>Tax</th>
                <th>Net wt</th>
                <th>Fine</th>
                <th>Item amt</th>
                <th>Labour amt</th>
                <th>Taxable</th>
                <th>GST</th>
                <th>Net</th>
                <th aria-label="Row actions" />
              </tr>
            </thead>
            <tbody>
              {draft.lines.map((line, index) => {
                const calc = preview.lines[index]!;
                const numberCell = (
                  key: keyof EBillLineDraft,
                  label: string,
                  dp: number,
                  column: number,
                ) => (
                  <td key={key} data-grid-row={index} data-grid-column={column}>
                    <input
                      aria-label={`Line ${index + 1} ${label}`}
                      type="number"
                      min={0}
                      step={dp ? 1 / 10 ** dp : 1}
                      style={{ width: 90 }}
                      value={Number(line[key]) || ''}
                      onChange={(e) =>
                        setLine(index, {
                          [key]: Number(e.target.value),
                        } as Partial<EBillLineDraft>)
                      }
                    />
                  </td>
                );
                return (
                  <tr key={index} style={calc.saved ? undefined : { opacity: 0.6 }}>
                    <td>{index + 1}</td>
                    <td data-grid-row={index} data-grid-column={0} style={{ minWidth: 180 }}>
                      <LookupPicker
                        entity="items"
                        ariaLabel={`Line ${index + 1} item`}
                        value={line.itemCode}
                        onChange={(code) => setLine(index, { itemCode: code })}
                        onPick={(row) =>
                          setLine(index, {
                            itemName: String(row.name ?? ''),
                            ...(row.RATE_TYPE ? { rateType: String(row.RATE_TYPE) } : {}),
                          })
                        }
                      />
                      <div className="muted">{line.itemName}</div>
                    </td>
                    <td data-grid-row={index} data-grid-column={1}>
                      <input
                        aria-label={`Line ${index + 1} design`}
                        style={{ width: 80 }}
                        value={line.designNo}
                        onChange={(e) => setLine(index, { designNo: e.target.value })}
                      />
                    </td>
                    {NUMERIC.slice(0, 6).map(([key, label, dp], i) =>
                      numberCell(key, label, dp, 2 + i),
                    )}
                    <td data-grid-row={index} data-grid-column={8}>
                      <select
                        aria-label={`Line ${index + 1} rate type`}
                        value={line.rateType}
                        onChange={(e) => setLine(index, { rateType: e.target.value })}
                      >
                        {RATE_TYPES.map(([code, label]) => (
                          <option key={code} value={code}>
                            {label}
                          </option>
                        ))}
                      </select>
                    </td>
                    {numberCell('rate', 'Rate', 2, 9)}
                    <td data-grid-row={index} data-grid-column={10}>
                      <select
                        aria-label={`Line ${index + 1} labour type`}
                        value={line.labourType}
                        onChange={(e) => setLine(index, { labourType: e.target.value })}
                      >
                        {LABOUR_TYPES.map(([code, label]) => (
                          <option key={code} value={code}>
                            {label}
                          </option>
                        ))}
                      </select>
                    </td>
                    {NUMERIC.slice(7).map(([key, label, dp], i) =>
                      numberCell(key, label, dp, 11 + i),
                    )}
                    <td data-grid-row={index} data-grid-column={15}>
                      <select
                        aria-label={`Line ${index + 1} tax code`}
                        value={line.taxCode}
                        onChange={(e) => setLine(index, { taxCode: e.target.value })}
                      >
                        <option value="">No tax</option>
                        {(
                          config?.taxCodes ?? [
                            { code: line.taxCode, name: line.taxCode, percent: 0 },
                          ]
                        )
                          .filter((t) => t.code)
                          .map((t) => (
                            <option
                              key={t.code}
                              value={t.code}
                            >{`${t.code} · ${t.name || `${t.percent}%`}`}</option>
                          ))}
                      </select>
                    </td>
                    <td>{fmt(calc.netWt, 3)}</td>
                    <td>{fmt(calc.fine, 3)}</td>
                    <td>{fmt(calc.itemAmount)}</td>
                    <td>{fmt(calc.labourAmount)}</td>
                    <td>{fmt(calc.taxableAmount)}</td>
                    <td>{fmt(calc.taxAmount)}</td>
                    <td>{fmt(calc.netAmount)}</td>
                    <td>
                      <button
                        type="button"
                        aria-label={`Remove line ${index + 1}`}
                        onClick={() => removeLine(index)}
                      >
                        Remove
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
        </div>
        <button type="button" onClick={addLine}>
          Add line
        </button>

        <div className="row" style={{ flexWrap: 'wrap', gap: 12, marginTop: 12 }}>
          <div className="field">
            <label htmlFor="crn-cash">{invoice ? 'Cash received' : 'Cash paid'}</label>
            <input
              id="crn-cash"
              type="number"
              min={0}
              value={draft.cashAmount || ''}
              onChange={(e) => set({ cashAmount: Number(e.target.value) })}
            />
          </div>
          <div className="field">
            <label htmlFor="crn-chq">Cheque amount</label>
            <input
              id="crn-chq"
              type="number"
              min={0}
              value={draft.chequeAmount || ''}
              onChange={(e) => set({ chequeAmount: Number(e.target.value) })}
            />
          </div>
          <div className="field">
            <label>Bank account</label>
            <LookupPicker
              entity="accounts"
              ariaLabel="Bank account"
              value={draft.chequeAccount}
              onChange={(code) => set({ chequeAccount: code })}
            />
          </div>
          <div className="field">
            <label htmlFor="crn-chqno">Cheque no</label>
            <input
              id="crn-chqno"
              value={draft.chequeNo}
              onChange={(e) => set({ chequeNo: e.target.value })}
            />
          </div>
          <div className="field">
            <label htmlFor="crn-card">Card amount</label>
            <input
              id="crn-card"
              type="number"
              min={0}
              value={draft.cardAmount || ''}
              onChange={(e) => set({ cardAmount: Number(e.target.value) })}
            />
          </div>
          <div className="field">
            <label>Card account</label>
            <LookupPicker
              entity="accounts"
              ariaLabel="Card account"
              value={draft.cardAccount}
              onChange={(code) => set({ cardAccount: code })}
            />
          </div>
          <div className="field">
            <label htmlFor="crn-kasar">Kasar</label>
            <input
              id="crn-kasar"
              type="number"
              min={0}
              value={draft.kasarAmount || ''}
              onChange={(e) => set({ kasarAmount: Number(e.target.value) })}
            />
          </div>
        </div>
      </fieldset>

      {invoice && (
        <fieldset
          disabled={busy || !coBook || locked}
          className="row"
          style={{ border: 0, padding: 0, gap: 12, flexWrap: 'wrap', marginTop: 12 }}
        >
          <div className="field">
            <label htmlFor="crn-tcs">TCS</label>
            <select
              id="crn-tcs"
              value={draft.tcsCode}
              onChange={(e) => set({ tcsCode: e.target.value })}
            >
              <option value="">Automatic (50 lakh rule)</option>
              {(config?.tcsCodes ?? []).map((t) => (
                <option
                  key={t.code}
                  value={t.code}
                >{`${t.code} · ${t.name || `${t.percent}%`}`}</option>
              ))}
            </select>
          </div>
          {!loaded && draft.tcsCode && draft.tcsCode !== '00' && (
            <div className="field">
              <label htmlFor="crn-tcs-amt">TCS amount (below threshold)</label>
              <input
                id="crn-tcs-amt"
                type="number"
                min={0}
                value={draft.tcsAmount || ''}
                onChange={(e) => set({ tcsAmount: Number(e.target.value) })}
              />
            </div>
          )}
          <div className="field">
            <label htmlFor="crn-tds">TDS</label>
            <select
              id="crn-tds"
              value={draft.tdsCode}
              onChange={(e) => set({ tdsCode: e.target.value })}
            >
              <option value="">No TDS</option>
              {(config?.tdsCodes ?? []).map((t) => (
                <option
                  key={t.code}
                  value={t.code}
                >{`${t.code} · ${t.name || `${t.percent}%`}`}</option>
              ))}
            </select>
          </div>
          <p className="muted" style={{ alignSelf: 'end' }}>
            Party debits this year: {fmt(priorDebits)}
          </p>
        </fieldset>
      )}

      <table aria-label={`${ui.Noun} totals`} style={{ marginTop: 12, maxWidth: 520 }}>
        <tbody>
          {[
            ['Taxable amount', b.netAmount],
            ['IGST', b.igst],
            ['CGST', b.cgst],
            ['SGST', b.sgst],
            ...(invoice ? [['TCS', b.tcsAmount]] : []),
            ['Round off', b.roundOff],
            ['Total', b.totalAmount],
            ...(invoice ? [['TDS', b.tdsAmount]] : []),
            ['Cash / cheque / card / kasar', b.cash + b.cheque + b.card + b.kasar],
            ['Outstanding (Bill OS)', b.outstanding],
          ].map(([label, value]) => (
            <tr key={String(label)}>
              <th scope="row" style={{ textAlign: 'left' }}>
                {label}
              </th>
              <td style={{ textAlign: 'right' }}>{fmt(Number(value))}</td>
            </tr>
          ))}
        </tbody>
      </table>
      {loaded?.registration && (
        <p className="muted">
          IRN {loaded.registration.irn} · Ack {loaded.registration.ackNo}
          {loaded.registration.ackDate ? ` · ${loaded.registration.ackDate}` : ''}
        </p>
      )}
      {loaded && loaded.componentCount > 0 && (
        <p className="muted">
          {loaded.componentCount} stone/component row(s) are kept with their parent line when you
          update.
        </p>
      )}
      <div className="row" style={{ gap: 8, marginTop: 12 }}>
        <button
          type="button"
          className="primary"
          data-save-mnemonic
          disabled={busy || !coBook || locked}
          onClick={() => void save()}
        >
          {loaded ? `Update ${ui.noun}` : `Save ${ui.noun}`}
        </button>
        <button type="button" disabled={busy || !loaded || locked} onClick={() => void remove()}>
          Delete {ui.noun}
        </button>
        <button type="button" disabled={busy || !loaded} onClick={() => void print('O')}>
          Print original
        </button>
        <button type="button" disabled={busy || !loaded} onClick={() => void print('D')}>
          Print duplicate
        </button>
        {invoice && loaded && !locked && (
          <button type="button" disabled={busy} onClick={() => void generateIrn()}>
            Generate IRN
          </button>
        )}
        {locked && (
          <button type="button" disabled={busy} onClick={() => void cancelIrn()}>
            Cancel IRN
          </button>
        )}
        <button type="button" disabled={busy} onClick={reset}>
          New {ui.noun}
        </button>
      </div>
      {message && (
        <p role="alert" className="msg">
          {message}
        </p>
      )}
    </section>
  );
}
