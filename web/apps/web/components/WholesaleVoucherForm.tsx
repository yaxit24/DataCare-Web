'use client';

import { useEffect, useMemo, useRef, useState, type CSSProperties } from 'react';
import type { WholesaleLineResult } from '@datacare/core';
import { ApiError, del, get, post, put } from '../lib/api';
import { useCompanySettings } from '../lib/companySettings';
import {
  WHOLESALE_WORKFLOWS,
  blankLine,
  blankVoucher,
  editLine,
  fineRateCaption,
  isActiveLine,
  lineFromTag,
  lineWithItem,
  money,
  previewVoucher,
  voucherFromSaved,
  voucherPayload,
  weight,
  wholesaleSettings,
  type GridPreview,
  type LineField,
  type SavedVoucher,
  type VoucherHeader,
  type VoucherLine,
  type VoucherState,
  type VoucherTender,
  type WholesaleWorkflow,
} from '../lib/wholesaleVoucher';
import { BookSelect } from './BookSelect';
import { useBusinessScope } from './BusinessScope';
import { GridModeToggle } from './ExtendedGrid';
import { useGridKeyboard } from './GridKeyboard';
import { LookupPicker, type LookupRow } from './LookupPicker';

/**
 * TR_WH_SALE on the web: one form for "Wh Sales" and "Rate Cut" (lib/wholesaleVoucher.ts explains the split).
 *
 * Layout follows the desktop form: the party header; the issue grid (`MSG`, what leaves the shop — tags or loose
 * metal); the receive grid (`MSG_PR`, metal the party brings in); the rate-cut band (Fine Rate, Convrt Rate,
 * Conv %, Ac Amt / Ac Fine Dr and Cr, Tot Fine Dr / Cr, Os Fine); and the settlement band `MSG2_TOTAL` with its
 * "Payment" (PR_*) and "Received" (SL_*) columns and rows Net / Cheque / Card / Cash / Kasar / Os
 * (TR_WH_SALE.cs:14904-14914). Every computed cell is the `@datacare/core` arithmetic the API posts with.
 */

type Side = 'issue' | 'receive';

type Column =
  | { kind: 'index' }
  | { kind: 'tag' }
  | { kind: 'item' }
  | { kind: 'input'; field: LineField; label: string; width?: number; text?: boolean }
  | {
      kind: 'computed';
      label: string;
      testId: string;
      value: (result: WholesaleLineResult) => string;
    }
  | { kind: 'rate'; label: string }
  | { kind: 'rateType' }
  | { kind: 'lbrType'; label: string }
  | { kind: 'labour'; label: string }
  | { kind: 'otherFine' }
  | { kind: 'ghat' }
  | { kind: 'remove' };

const num = (field: LineField, label: string, width = 78): Column => ({
  kind: 'input',
  field,
  label,
  width,
});
const txt = (field: LineField, label: string, width = 96): Column => ({
  kind: 'input',
  field,
  label,
  width,
  text: true,
});
const fineCell: Column = {
  kind: 'computed',
  label: 'Fine',
  testId: 'fine',
  value: (r) => weight(r.fine),
};
const itemAmountCell: Column = {
  kind: 'computed',
  label: 'ItAmt',
  testId: 'item-amount',
  value: (r) => money(r.itemAmount),
};
const netAmountCell: Column = {
  kind: 'computed',
  label: 'NetAmt',
  testId: 'net-amount',
  value: (r) => money(r.netAmount),
};

/** Issue grid `MSG`, in the desktop's column order (TR_WH_SALE.cs:7987-8182). */
const ISSUE_BASE: Column[] = [
  { kind: 'index' },
  { kind: 'tag' },
  { kind: 'item' },
  num('pcs', 'Pcs', 56),
  num('grossWt', 'GrWt'),
  num('othWt', 'OthWt'),
  num('netWt', 'NetWt'),
  num('touch', 'Touch', 64),
  num('westPct', 'West%', 64),
  fineCell,
  { kind: 'rate', label: 'ItRate' },
  { kind: 'rateType' },
  itemAmountCell,
  { kind: 'lbrType', label: 'LType' },
  num('lbrRate', 'LbrRate'),
  { kind: 'labour', label: 'LbrAmt' },
  num('othAmt', 'OthAmt'),
  netAmountCell,
];
const ISSUE_EXTENDED: Column[] = [
  txt('itemName', 'ItName', 140),
  txt('itemLot', 'ItmLot'),
  txt('lotNo', 'LotNo'),
  txt('tblCode', 'Counter', 64),
  txt('designNo', 'Design'),
  txt('itemSize', 'Size', 56),
  txt('hallmarkId', 'HuId'),
  txt('karigarName', 'KrName', 64),
  txt('prCode', 'PrCode', 64),
  num('ghtPct', 'Ght%', 64),
  { kind: 'ghat' },
  num('lessWt', 'LessWt'),
  num('hallmarkFine', 'HmFine'),
  num('convRate', 'ConRate'),
  num('convPct', 'Con%', 64),
  num('otherRate', 'ORate'),
  { kind: 'otherFine' },
  num('mrp', 'Mrp'),
  num('tagCost', 'TagCost'),
  num('taxPct', 'Tax%', 56),
  num('silverFine', 'SlvrFine'),
  num('tagGrossWt', 'TagGwt'),
  num('tagNetWt', 'TagNwt'),
  num('mcxRate', 'McxRate'),
  num('adjustWt', 'AdjWt'),
  txt('issueLcCode', 'IsuLc', 48),
  txt('issueYear', 'IsuYear'),
  txt('issueBook', 'IsuBook', 64),
  txt('issueNo', 'OrdNo', 72),
  num('issueSrno', 'IsuSr', 56),
];

/** Receive grid `MSG_PR` (TR_WH_SALE.cs:6154-6253): no tags, and the ghat is a typed weight. */
const RECEIVE_BASE: Column[] = [
  { kind: 'index' },
  { kind: 'item' },
  num('pcs', 'Pcs', 56),
  num('grossWt', 'GrWt'),
  num('othWt', 'OthWt'),
  num('netWt', 'NetWt'),
  num('ghtWt', 'GhtWt'),
  num('touch', 'Touch', 64),
  num('westPct', 'West%', 64),
  num('lessTouch', 'LTouch', 64),
  fineCell,
  { kind: 'rate', label: 'Rate' },
  { kind: 'rateType' },
  itemAmountCell,
  { kind: 'lbrType', label: 'Ltype' },
  num('lbrRate', 'LRate'),
  { kind: 'labour', label: 'LAmt' },
  num('othAmt', 'OthAmt'),
  netAmountCell,
];
const RECEIVE_EXTENDED: Column[] = [
  txt('itemName', 'ItName', 140),
  txt('itemLot', 'ItmLot'),
  txt('lotNo', 'LotNo'),
  txt('designNo', 'Design'),
  txt('prCode', 'PrCode', 64),
  num('convRate', 'ConRate'),
  num('convPct', 'Con%', 64),
  num('otherRate', 'ORate'),
  { kind: 'otherFine' },
  num('mrp', 'Mrp'),
  num('taxPct', 'TaxPrc', 56),
  num('silverFine', 'SlvFine'),
  num('tagCost', 'TagCost'),
  num('tagNetWt', 'TagNwt'),
  num('mcxRate', 'McxRate'),
  num('adjustWt', 'AdjWt'),
  txt('issueLcCode', 'IsuLc', 48),
  txt('issueYear', 'IsuYear'),
  txt('issueBook', 'IsuBook', 64),
  txt('issueNo', 'IsuNo', 72),
  num('issueSrno', 'IsuSr', 56),
];

const LABOUR_OPTIONS: Array<[string, string]> = [
  ['', '—'],
  ['G', 'Gross'],
  ['N', 'Net'],
  ['K', 'Kg'],
  ['P', 'Pcs'],
];
const RATE_OPTIONS: Array<[string, string]> = [
  ['', 'Item'],
  ['G', '1 g'],
  ['1', '10 g'],
  ['K', 'Kg'],
  ['P', 'Pc'],
];

const filled = (value: string) => value.trim() !== '';
const nonZero = (value: string) => Number(value.trim() || 0) !== 0;
const computedStyle: CSSProperties = {
  width: 88,
  textAlign: 'right',
  background: '#f4f6f9',
  border: '1px solid transparent',
};

const message = (caught: unknown, fallback: string): string =>
  caught instanceof ApiError
    ? String(caught.body?.message || caught.body?.error || caught.message)
    : fallback;

export function WholesaleVoucherForm({ workflow }: { workflow: WholesaleWorkflow }) {
  const cfg = WHOLESALE_WORKFLOWS[workflow];
  const { lcCode, coYear } = useBusinessScope();
  const companyValues = useCompanySettings();
  const settings = useMemo(() => wholesaleSettings(companyValues), [companyValues]);
  const [coBook, setCoBook] = useState('');
  const [voucher, setVoucher] = useState<VoucherState>(() => blankVoucher());
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [fullIssue, setFullIssue] = useState(false);
  const [fullReceive, setFullReceive] = useState(false);
  const [busy, setBusy] = useState(false);
  const [error, setError] = useState('');
  const [status, setStatus] = useState('');
  // The latest rows, for the tag resolver that runs after an await.
  const latest = useRef(voucher);
  useEffect(() => {
    latest.current = voucher;
  }, [voucher]);

  const preview = useMemo(() => previewVoucher(voucher, settings), [voucher, settings]);
  const { band, settlement } = preview;
  const h = voucher.header;
  const id = (name: string) => `${cfg.testId}-${name}`;

  // ---- state updates ---------------------------------------------------------------------------
  const setHeader = (field: keyof VoucherHeader, value: string) =>
    setVoucher((v) => ({ ...v, header: { ...v.header, [field]: value } }));
  const setTender = (
    column: 'receivedTender' | 'paymentTender',
    row: keyof VoucherTender,
    value: string,
  ) => setVoucher((v) => ({ ...v, [column]: { ...v[column], [row]: value } }));
  const linesKey = (side: Side) => (side === 'issue' ? 'issued' : 'received');
  const updateLine = (side: Side, index: number, change: (line: VoucherLine) => VoucherLine) =>
    setVoucher((v) => {
      const key = linesKey(side);
      const lines = v[key].map((line, i) => (i === index ? change(line) : line));
      // The desktop grid always keeps a spare row under the last one typed.
      if (isActiveLine(lines[lines.length - 1]!)) lines.push(blankLine());
      return { ...v, [key]: lines };
    });
  const setLine = (side: Side, index: number, field: LineField, value: string) =>
    updateLine(side, index, (line) => editLine(line, field, value));
  const appendLine = (side: Side) =>
    setVoucher((v) => ({ ...v, [linesKey(side)]: [...v[linesKey(side)], blankLine()] }));
  const removeLine = (side: Side, index: number): boolean => {
    setVoucher((v) => {
      const key = linesKey(side);
      const lines = v[key].filter((_, i) => i !== index);
      return { ...v, [key]: lines.length ? lines : [blankLine()] };
    });
    return true;
  };
  const pickTag = (index: number, row: LookupRow) =>
    updateLine('issue', index, (line) => lineFromTag(row, line));
  const pickItem = (side: Side, index: number, row: LookupRow) =>
    updateLine(side, index, (line) => lineWithItem(line, row));

  /**
   * A tag number typed without choosing from the list resolves on leaving the cell, as the desktop resolves it on
   * Enter — when it names exactly one available tag. Two live instances stay for the operator to choose.
   */
  async function resolveTypedTag(index: number) {
    const line = latest.current.issued[index];
    const typed = line?.tagNo.trim() ?? '';
    if (!line || !typed || line.explicit) return;
    try {
      const rows = await get<LookupRow[]>(
        `/lookup/available-tags?q=${encodeURIComponent(typed)}&limit=5`,
      );
      const exact = (rows ?? []).filter(
        (row) =>
          String(row.code ?? '')
            .trim()
            .toUpperCase() === typed.toUpperCase(),
      );
      if (exact.length !== 1) return;
      updateLine('issue', index, (current) =>
        current.explicit || current.tagNo.trim() !== typed
          ? current
          : lineFromTag(exact[0]!, current),
      );
    } catch {
      // The save resolves the tag server-side and reports a tag that is not in stock.
    }
  }

  // ---- voucher lifecycle -----------------------------------------------------------------------
  function reset() {
    setVoucher(blankVoucher());
    setVoucherNo('');
    setLoadedVoucherNo('');
    setError('');
    setStatus('');
  }

  async function open(no: string): Promise<SavedVoucher> {
    const view = await get<SavedVoucher>(
      `${cfg.endpoint}/${encodeURIComponent(no)}?coBook=${encodeURIComponent(coBook)}`,
    );
    setVoucher(voucherFromSaved(view));
    setVoucherNo(view.voucherNo);
    setLoadedVoucherNo(view.voucherNo);
    return view;
  }

  async function load() {
    if (!coBook || !voucherNo.trim()) return;
    setBusy(true);
    setError('');
    setStatus('');
    try {
      const view = await open(voucherNo.trim());
      setStatus(`Loaded voucher ${view.voucherNo}`);
    } catch (caught) {
      setError(message(caught, `${cfg.title} load failed`));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    setBusy(true);
    setError('');
    setStatus('');
    try {
      const body = voucherPayload(voucher, { coBook, coYear, lcCode });
      const verb = loadedVoucherNo ? 'Updated' : 'Saved';
      const result = loadedVoucherNo
        ? await put<{ vchNo: number }>(
            `${cfg.endpoint}/${encodeURIComponent(loadedVoucherNo)}`,
            body,
          )
        : await post<{ vchNo: number }>(cfg.endpoint, body);
      // From here the voucher exists: a further Save must update it, never post a second one.
      const saved = String(result.vchNo);
      setLoadedVoucherNo(saved);
      setVoucherNo(saved);
      try {
        // Reload what was stored, so every figure on screen is the saved one.
        const view = await open(saved);
        setStatus(`${verb} voucher ${view.voucherNo}`);
      } catch (caught) {
        setStatus(`${verb} voucher ${saved}`);
        setError(`Saved, but reloading it failed: ${message(caught, 'reload failed')}`);
      }
    } catch (caught) {
      setError(message(caught, `${cfg.title} save failed`));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete ${cfg.title} voucher ${loadedVoucherNo}?`)) {
      return;
    }
    setBusy(true);
    setError('');
    try {
      await del(
        `${cfg.endpoint}/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      const deleted = loadedVoucherNo;
      reset();
      setStatus(`Deleted voucher ${deleted}`);
    } catch (caught) {
      setError(message(caught, `${cfg.title} delete failed`));
    } finally {
      setBusy(false);
    }
  }

  const settles = [h.settleDrAmt, h.settleCrAmt, h.settleDrFine, h.settleCrFine].some(nonZero);
  const hasLines = voucher.issued.some(isActiveLine) || voucher.received.some(isActiveLine);
  const canSave = !!coBook && !!h.acCode.trim() && (hasLines || settles) && !busy;

  // ---- grids -----------------------------------------------------------------------------------
  const issueKeys = useGridKeyboard({
    rowCount: voucher.issued.length,
    onAppendRow: () => appendLine('issue'),
    onRemoveRow: (row) => removeLine('issue', row),
    onEscape: () => setError(''),
  });
  const receiveKeys = useGridKeyboard({
    rowCount: voucher.received.length,
    onAppendRow: () => appendLine('receive'),
    onRemoveRow: (row) => removeLine('receive', row),
    onEscape: () => setError(''),
  });

  function renderCell(
    column: Column,
    side: Side,
    line: VoucherLine,
    result: WholesaleLineResult | null,
    index: number,
    position: number,
  ) {
    const where = `${side === 'issue' ? 'Issue' : 'Receive'} line ${index + 1}`;
    const computed = (label: string, value: string, testId: string) => (
      <td key={position} className="num">
        <input
          readOnly
          tabIndex={-1}
          aria-label={`${label} ${where}`}
          data-testid={id(`${side}-${testId}-${index}`)}
          value={value}
          style={computedStyle}
        />
      </td>
    );
    const typed = (field: LineField, label: string, width = 78, text = false) => (
      <td key={position} className={text ? undefined : 'num'}>
        <input
          aria-label={`${label} ${where}`}
          value={line[field]}
          inputMode={text ? undefined : 'decimal'}
          onChange={(event) => setLine(side, index, field, event.target.value)}
          style={{ width, textAlign: text ? 'left' : 'right' }}
        />
      </td>
    );
    switch (column.kind) {
      case 'index':
        return <td key={position}>{index + 1}</td>;
      case 'tag':
        return (
          <td key={position} onBlur={() => void resolveTypedTag(index)}>
            <LookupPicker
              entity="available-tags"
              value={line.tagNo}
              onChange={(value) => setLine('issue', index, 'tagNo', value)}
              onPick={(row) => pickTag(index, row)}
              placeholder="tag… (F1)"
              ariaLabel={`TagNo ${where}`}
              style={{ minWidth: 130 }}
            />
          </td>
        );
      case 'item':
        // A tag decides its own item; the save resolves the tag by it.
        if (side === 'issue' && line.explicit && filled(line.tagNo)) {
          return (
            <td key={position}>
              <input
                readOnly
                aria-label={`ItCode ${where}`}
                value={line.itCode}
                title={line.itemName}
                style={{ width: 90, background: '#f4f6f9' }}
              />
            </td>
          );
        }
        return (
          <td key={position}>
            <LookupPicker
              entity="items"
              value={line.itCode}
              onChange={(value) => setLine(side, index, 'itCode', value)}
              onPick={(row) => pickItem(side, index, row)}
              placeholder="item… (F1)"
              ariaLabel={`ItCode ${where}`}
              style={{ minWidth: 110 }}
            />
          </td>
        );
      case 'input':
        return typed(column.field, column.label, column.width, column.text);
      case 'computed':
        return computed(column.label, result ? column.value(result) : '', column.testId);
      case 'rate':
        // A line conversion decides the rate (cols 29/30 → 31).
        return nonZero(line.convRate)
          ? computed(column.label, result ? money(result.rate) : '', 'rate')
          : typed('rate', column.label, 88);
      case 'rateType':
        return (
          <td key={position}>
            <select
              aria-label={`Rate per ${where}`}
              value={line.rateType}
              onChange={(event) => setLine(side, index, 'rateType', event.target.value)}
            >
              {RATE_OPTIONS.map(([value, label]) => (
                <option key={value} value={value}>
                  {label}
                </option>
              ))}
            </select>
          </td>
        );
      case 'lbrType':
        return (
          <td key={position}>
            <select
              aria-label={`${column.label} ${where}`}
              value={line.lbrTypeFromCompany ? settings.line.companyLabourType : line.lbrType}
              onChange={(event) => setLine(side, index, 'lbrType', event.target.value)}
            >
              {LABOUR_OPTIONS.map(([value, label]) => (
                <option key={value} value={value}>
                  {label}
                </option>
              ))}
            </select>
          </td>
        );
      case 'labour':
        // With a labour rate the amount is computed from its basis; without one it is typed.
        return nonZero(line.lbrRate)
          ? computed(column.label, result ? money(result.labourAmount) : '', 'labour')
          : typed('lbrAmt', column.label, 88);
      case 'otherFine':
        return nonZero(line.otherRate) && nonZero(line.othAmt)
          ? computed('OFine', result ? weight(result.otherFine) : '', 'other-fine')
          : typed('otherFine', 'OFine');
      case 'ghat':
        return filled(line.ghtPct)
          ? computed('GhtWt', result ? weight(result.ghtWt) : '', 'ghat')
          : typed('ghtWt', 'GhtWt');
      case 'remove':
        return (
          <td key={position}>
            <button
              type="button"
              className="ghost"
              aria-label={`Remove ${where}`}
              onClick={() => removeLine(side, index)}
            >
              ✕
            </button>
          </td>
        );
    }
  }

  const header = (column: Column, position: number) => {
    const label =
      column.kind === 'index'
        ? 'Sr'
        : column.kind === 'tag'
          ? 'TagNo'
          : column.kind === 'item'
            ? 'ItCode'
            : column.kind === 'rateType'
              ? 'Per'
              : column.kind === 'otherFine'
                ? 'OFine'
                : column.kind === 'ghat'
                  ? 'GhtWt'
                  : column.kind === 'remove'
                    ? ''
                    : column.label;
    const numeric = column.kind === 'input' ? !column.text : column.kind !== 'index';
    return (
      <th key={position} scope="col" className={numeric ? 'num' : undefined}>
        {label}
      </th>
    );
  };

  function grid(side: Side, lines: VoucherLine[], view: GridPreview, full: boolean) {
    const columns = [
      ...(side === 'issue' ? ISSUE_BASE : RECEIVE_BASE),
      ...(full ? (side === 'issue' ? ISSUE_EXTENDED : RECEIVE_EXTENDED) : []),
      { kind: 'remove' } as Column,
    ];
    const results = view.lines;
    const sum = (pick: (line: VoucherLine, result: WholesaleLineResult) => number) =>
      lines.reduce((total, line, i) => (results[i] ? total + pick(line, results[i]!) : total), 0);
    const totalsTestId = (name: string) => id(`${side}-total-${name}`);
    return (
      <>
        <div style={{ overflowX: 'auto', paddingBottom: 180, marginBottom: -172 }}>
          <table
            className="grid"
            aria-label={side === 'issue' ? 'Issue lines' : 'Receive lines'}
            onKeyDown={side === 'issue' ? issueKeys : receiveKeys}
          >
            <thead>
              <tr>{columns.map(header)}</tr>
            </thead>
            <tbody>
              {lines.map((line, index) => (
                <tr key={index}>
                  {columns.map((column, position) =>
                    renderCell(column, side, line, results[index] ?? null, index, position),
                  )}
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        <p className="muted" style={{ marginTop: 8 }}>
          Pcs <b data-testid={totalsTestId('pcs')}>{sum((l) => Number(l.pcs || 0))}</b> · GrWt{' '}
          <b data-testid={totalsTestId('gross')}>{weight(sum((l) => Number(l.grossWt || 0)))}</b> ·
          NetWt <b data-testid={totalsTestId('net-wt')}>{weight(sum((_, r) => r.netWt))}</b> · Fine{' '}
          <b data-testid={totalsTestId('fine')}>{weight(view.totals.handledFine)}</b> · ItAmt{' '}
          <b data-testid={totalsTestId('item-amount')}>{money(view.totals.itemAmount)}</b> · Lbr{' '}
          <b data-testid={totalsTestId('labour')}>{money(view.totals.labourAmount)}</b> · Oth{' '}
          <b data-testid={totalsTestId('other')}>{money(view.totals.otherAmount)}</b> · NetAmt{' '}
          <b data-testid={totalsTestId('net-amount')}>{money(view.totals.netAmount)}</b>
        </p>
      </>
    );
  }

  // ---- settlement ------------------------------------------------------------------------------
  const settleField = (
    field:
      | 'fineRate'
      | 'convRate'
      | 'convPct'
      | 'settleDrAmt'
      | 'settleCrAmt'
      | 'settleDrFine'
      | 'settleCrFine',
    label: string,
    derived?: number,
    format: (x: number) => string = money,
  ) => (
    <div className="field">
      <label htmlFor={id(field)}>{label}</label>
      <input
        id={id(field)}
        inputMode="decimal"
        value={h[field]}
        placeholder={derived ? format(derived) : ''}
        onChange={(event) => setHeader(field, event.target.value)}
      />
      {!filled(h[field]) && derived ? (
        <span className="muted" data-testid={id(`derived-${field}`)} style={{ fontSize: 11 }}>
          = {format(derived)} (derived)
        </span>
      ) : null}
    </div>
  );

  const readout = (label: string, value: string, testId: string) => (
    <div className="field">
      <label>{label}</label>
      <output
        aria-label={label}
        data-testid={id(testId)}
        style={{ ...computedStyle, width: 'auto', padding: '6px 8px', borderRadius: 4 }}
      >
        {value}
      </output>
    </div>
  );

  const tenderRow = (row: keyof VoucherTender, label: string) => (
    <tr>
      <th scope="row">{label}</th>
      {(['paymentTender', 'receivedTender'] as const).map((column) => (
        <td key={column} className="num">
          <input
            aria-label={`${column === 'paymentTender' ? 'Payment' : 'Received'} ${label}`}
            inputMode="decimal"
            value={voucher[column][row]}
            onChange={(event) => setTender(column, row, event.target.value)}
            style={{ width: 120, textAlign: 'right' }}
          />
        </td>
      ))}
      <td>
        {row === 'cheque' ? (
          <div className="row" style={{ gap: 8 }}>
            <LookupPicker
              entity="accounts"
              value={voucher.bankAc}
              onChange={(value) => setVoucher((v) => ({ ...v, bankAc: value }))}
              placeholder="bank a/c… (F1)"
              ariaLabel="Bank A/c"
              style={{ minWidth: 160 }}
            />
            <input
              aria-label="Cheque No"
              placeholder="cheque no"
              value={voucher.chqNo}
              onChange={(event) => setVoucher((v) => ({ ...v, chqNo: event.target.value }))}
              style={{ width: 120 }}
            />
          </div>
        ) : row === 'card' ? (
          <LookupPicker
            entity="accounts"
            value={voucher.cardAc}
            onChange={(value) => setVoucher((v) => ({ ...v, cardAc: value }))}
            placeholder="card a/c… (F1)"
            ariaLabel="Card A/c"
            style={{ minWidth: 160 }}
          />
        ) : null}
      </td>
    </tr>
  );

  const bandValue = (label: string, value: number, testId: string) => (
    <td className="num">
      <output aria-label={label} data-testid={id(testId)}>
        {money(value)}
      </output>
    </td>
  );

  return (
    <div>
      <h1>{cfg.title}</h1>
      <p className="muted">
        Desktop <code>TR_WH_SALE</code> — {cfg.desktop}. Books of <code>MAIN_BOOK</code>{' '}
        <code>{cfg.mainBook}</code> only;{' '}
        {workflow === 'wholesale-quotation' ? (
          <>
            persists quotation rows only (<code>RATE_CUT_DATA</code>, <code>RATE_CUT_ISU</code>/
            <code>RATE_CUT_REC</code>) with no ledger, Rojmel or stock movement.
          </>
        ) : (
          <>
            posts the rate-cut family (<code>RATE_CUT_DATA</code>, <code>RATE_CUT_ISU</code>/
            <code>RATE_CUT_REC</code>, <code>MAIN_STOCK</code>, <code>AC_DATA</code>,{' '}
            <code>ROJ_MEL_DATA</code>).
          </>
        )}
      </p>

      <div className="panel">
        <div className="row">
          <div className="field">
            <label>
              Book
              <BookSelect value={coBook} onChange={setCoBook} mainBooks={[cfg.mainBook]} />
            </label>
          </div>
          <div className="field">
            <label htmlFor={id('voucher-no')}>Voucher No</label>
            <div className="row" style={{ gap: 6, flexWrap: 'nowrap' }}>
              <input
                id={id('voucher-no')}
                value={voucherNo}
                onChange={(event) => setVoucherNo(event.target.value)}
                onKeyDown={(event) => {
                  if (event.key === 'Enter') {
                    event.preventDefault();
                    void load();
                  }
                }}
                placeholder="new"
                style={{ width: 90 }}
              />
              <button
                type="button"
                className="ghost"
                onClick={() => void load()}
                disabled={busy || !coBook || !voucherNo.trim()}
              >
                Load
              </button>
            </div>
          </div>
          <div className="field">
            <label htmlFor={id('date')}>Date</label>
            <input
              id={id('date')}
              type="date"
              value={h.vchDate}
              onChange={(event) => setHeader('vchDate', event.target.value)}
            />
          </div>
          <div className="field">
            <label htmlFor={id('bill-no')}>Bill No</label>
            <input
              id={id('bill-no')}
              value={h.billNo}
              onChange={(event) => setHeader('billNo', event.target.value)}
            />
          </div>
          <div className="field">
            <label htmlFor={id('item-type')}>Item Type</label>
            <select
              id={id('item-type')}
              value={h.itType}
              onChange={(event) => setHeader('itType', event.target.value)}
            >
              <option value="G">Gold</option>
              <option value="S">Silver</option>
            </select>
          </div>
        </div>
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Party</label>
            <LookupPicker
              entity="accounts"
              value={h.acCode}
              onChange={(value) => setHeader('acCode', value)}
              onPick={(row) =>
                // Choosing the party fills its name and mobile (TR_WH_SALE.cs:14621-14623).
                setVoucher((v) => ({
                  ...v,
                  header: {
                    ...v.header,
                    acCode: String(row.code ?? ''),
                    acName: String(row.name ?? ''),
                    mobile: String(row.AC_MOBILE ?? '').trim() || v.header.mobile,
                  },
                }))
              }
              placeholder="search accounts… (F1)"
              ariaLabel="Party"
            />
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label htmlFor={id('party-name')}>Party name</label>
            <input
              id={id('party-name')}
              value={h.acName}
              onChange={(event) => setHeader('acName', event.target.value)}
            />
          </div>
          <div className="field">
            <label htmlFor={id('mobile')}>Mobile</label>
            <input
              id={id('mobile')}
              value={h.mobile}
              onChange={(event) => setHeader('mobile', event.target.value)}
            />
          </div>
          <div className="field">
            <label htmlFor={id('city')}>City</label>
            <input
              id={id('city')}
              value={h.city}
              onChange={(event) => setHeader('city', event.target.value)}
            />
          </div>
        </div>
        <div className="row">
          {(['add1', 'add2', 'add3'] as const).map((field, i) => (
            <div className="field" key={field}>
              <label htmlFor={id(field)}>Address {i + 1}</label>
              <input
                id={id(field)}
                value={h[field]}
                onChange={(event) => setHeader(field, event.target.value)}
              />
            </div>
          ))}
          <div className="field">
            <label>Employee</label>
            <LookupPicker
              entity="employees"
              value={h.empCode}
              onChange={(value) => setHeader('empCode', value)}
              placeholder="employee… (F1)"
              ariaLabel="Employee"
            />
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label htmlFor={id('vch-desc')}>Vch Desc</label>
            <input
              id={id('vch-desc')}
              value={h.vchDesc}
              onChange={(event) => setHeader('vchDesc', event.target.value)}
            />
          </div>
        </div>
      </div>

      <div className="panel">
        <div className="toolbar" style={{ justifyContent: 'space-between' }}>
          <h2 style={{ margin: 0 }}>Issue</h2>
          <GridModeToggle
            full={fullIssue}
            setFull={setFullIssue}
            extendedCount={ISSUE_EXTENDED.length}
            testId={id('issue-grid-mode')}
          />
        </div>
        {grid('issue', voucher.issued, preview.issued, fullIssue)}
      </div>

      <div className="panel">
        <div className="toolbar" style={{ justifyContent: 'space-between' }}>
          <h2 style={{ margin: 0 }}>Receive</h2>
          <GridModeToggle
            full={fullReceive}
            setFull={setFullReceive}
            extendedCount={RECEIVE_EXTENDED.length}
            testId={id('receive-grid-mode')}
          />
        </div>
        {grid('receive', voucher.received, preview.received, fullReceive)}
      </div>

      {/* As on the desktop form, the rate-cut fields sit beside the settlement band (MSG2_TOTAL at 633,398). */}
      <div className="row" style={{ alignItems: 'flex-start' }}>
        <div className="panel" style={{ flex: '1 1 460px' }}>
          <h2 style={{ marginTop: 0 }}>Rate cut</h2>
          {/*
            The desktop's two columns (TR_WH_SALE.cs:5217-5539): each money field sits beside the metal it
            settles — Ac Amt Dr with Ac Fine Cr, Ac Amt Cr with Ac Fine Dr. Fine kasar (Ksr Fine Dr/Cr) is
            not modelled yet.
          */}
          <div
            style={{
              display: 'grid',
              gridTemplateColumns: 'repeat(2, minmax(150px, 1fr))',
              gap: '0 12px',
            }}
          >
            {readout('Tot Fine Cr', weight(band.totFineCr), 'tot-fine-cr')}
            {readout('Tot Fine Dr', weight(band.totFineDr), 'tot-fine-dr')}
            {settleField('settleDrAmt', 'Ac Amt Dr', settlement.drAmt)}
            {settleField('settleCrFine', 'Ac Fine Cr', settlement.crFine, weight)}
            {settleField('settleCrAmt', 'Ac Amt Cr', settlement.crAmt)}
            {settleField('settleDrFine', 'Ac Fine Dr', settlement.drFine, weight)}
            {settleField('convPct', 'Conv %')}
            {settleField('convRate', 'Convrt Rate')}
            {readout('Os Fine', weight(band.osFine), 'os-fine')}
            {settleField('fineRate', fineRateCaption(settings.ratePar), settlement.fineRate)}
          </div>
        </div>

        <div className="panel" style={{ flex: '0 1 auto' }}>
          <table className="grid" aria-label="Settlement" style={{ width: 'auto' }}>
            <thead>
              <tr>
                <th />
                <th scope="col" className="num">
                  Payment
                </th>
                <th scope="col" className="num">
                  Received
                </th>
                <th scope="col">Account</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <th scope="row">Net Amt</th>
                {bandValue('Payment Net Amt', band.paymentNet, 'payment-net')}
                {bandValue('Received Net Amt', band.receivedNet, 'received-net')}
                <td />
              </tr>
              {tenderRow('cheque', 'Cheque Amt')}
              {tenderRow('card', 'Card Amt')}
              {tenderRow('cash', 'Cash Amt')}
              {tenderRow('kasar', 'Kasar Amt')}
              <tr className="totals">
                <th scope="row">Os Amt</th>
                {bandValue('Payment Os Amt', band.paymentOs, 'payment-os')}
                {bandValue('Received Os Amt', band.receivedOs, 'received-os')}
                <td />
              </tr>
            </tbody>
          </table>
          <p>
            Diff Amount{' '}
            <b data-testid={id('diff-amount')}>
              {band.diffSide ? `${money(band.diffAmount)}  ${band.diffSide}` : '.'}
            </b>
          </p>
        </div>
      </div>

      {error ? (
        <p className="msg err" role="alert">
          {error}
        </p>
      ) : null}
      {status ? (
        <p className="msg ok" role="status" data-testid={id('status')}>
          {status}
        </p>
      ) : null}
      <div className="toolbar">
        <button type="button" className="primary" onClick={() => void save()} disabled={!canSave}>
          {busy ? 'Saving…' : loadedVoucherNo ? 'Update' : 'Save'}
        </button>
        <button
          type="button"
          className="danger"
          onClick={() => void remove()}
          disabled={busy || !loadedVoucherNo}
        >
          Delete
        </button>
        {workflow === 'wholesale-quotation' && loadedVoucherNo ? (
          <button
            type="button"
            className="ghost"
            onClick={() =>
              window.open(
                `/api/wholesale-quotations/${encodeURIComponent(loadedVoucherNo)}/print?coBook=${encodeURIComponent(coBook)}&format=html`,
                '_blank',
              )
            }
            disabled={busy}
          >
            Print
          </button>
        ) : null}
        <button type="button" className="ghost" onClick={reset} disabled={busy}>
          New
        </button>
      </div>
    </div>
  );
}
