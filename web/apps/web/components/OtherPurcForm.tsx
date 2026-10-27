'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from './BookSelect';
import { LookupPicker } from './LookupPicker';
import { desktopGlobalFormKeyActions, FormKeyHints } from './FormKeys';
import { useGridKeyboard } from './GridKeyboard';
import { ApiError, del, get, post, put } from '../lib/api';
import { todayLocal } from '../lib/localDate';

/**
 * Desktop TR_OTH_PURC. "Other Income" opens it on an OTH INC book and "Other Expenses" on an OTH EXP book
 * (MDI_FORM.cs:8372-8394): the same header, the same HSN/description/tax grid (TR_OTH_PURC.cs:2351-2432) and
 * the same total band, posted by one set of routines that mirror every amount on the book's MAIN_BOOK. The web
 * keeps one form and one writer for both; only the book family, the endpoint and the captions differ.
 */
export type OtherPurcMode = 'OTH INC' | 'OTH EXP';

const MODE = {
  'OTH INC': {
    endpoint: '/other-income',
    title: 'Other Income',
    party: 'Customer',
    ledger: 'Income ledger',
    settle: 'Receipt totals',
    settled: 'received/write-off',
    testId: 'other-income',
  },
  'OTH EXP': {
    endpoint: '/other-purchase',
    title: 'Other Expenses',
    party: 'Supplier',
    ledger: 'Expense ledger',
    settle: 'Payment totals',
    settled: 'paid/write-off',
    testId: 'other-expense',
  },
} as const;

type IncomeLine = {
  hsnCode: string;
  itemName: string;
  netAmount: number;
  discountPercent: number;
  discountAmount?: number;
  taxCode: string;
  taxType: 'F' | 'R';
  taxableAmount?: number;
  igstAmount?: number;
  cgstAmount?: number;
  sgstAmount?: number;
  totalAmount?: number;
};

type IncomeView = {
  voucherNo: string;
  hiddenVoucherNo: string;
  vchDate: string;
  partyCode: string;
  partyName: string;
  ledgerCode: string;
  ledgerName: string;
  billNo: string;
  billDate: string;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  kasarAmount: number;
  tdsCode: string;
  employeeCode: string;
  bankName: string;
  description: string;
  totalAmount: number;
  outstandingAmount: number;
  lines: IncomeLine[];
};

type SaveResult = { voucherNo: string; hiddenVoucherNo: string; created: boolean; lines: number };

const today = () => todayLocal();
const money = (value: number) => Math.round((Number(value || 0) + 1e-9) * 100) / 100;
const blankLine = (): IncomeLine => ({
  hsnCode: '',
  itemName: '',
  netAmount: 0,
  discountPercent: 0,
  taxCode: '',
  taxType: 'F',
});

export function OtherPurcForm({ mode }: { mode: OtherPurcMode }) {
  const cfg = MODE[mode];
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [vchDate, setVchDate] = useState(today);
  const [partyCode, setPartyCode] = useState('');
  const [partyName, setPartyName] = useState('');
  // Desktop account 00067 is the default income ledger; an expense ledger has no fixed default.
  const defaultLedger = mode === 'OTH INC' ? '00067' : '';
  const [ledgerCode, setLedgerCode] = useState(defaultLedger);
  const [ledgerName, setLedgerName] = useState('');
  const [billNo, setBillNo] = useState('');
  const [billDate, setBillDate] = useState(today);
  const [chequeAmount, setChequeAmount] = useState(0);
  const [chequeAccount, setChequeAccount] = useState('');
  const [chequeNo, setChequeNo] = useState('');
  const [cardAmount, setCardAmount] = useState(0);
  const [cardAccount, setCardAccount] = useState('');
  const [cashAmount, setCashAmount] = useState(0);
  const [cashAccount, setCashAccount] = useState('00001');
  const [kasarAmount, setKasarAmount] = useState(0);
  const [kasarAccount, setKasarAccount] = useState('');
  const [tdsCode, setTdsCode] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [bankName, setBankName] = useState('');
  const [description, setDescription] = useState('');
  const [rows, setRows] = useState<IncomeLine[]>([blankLine()]);
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const message = (caught: unknown, fallback: string) =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  const update = (index: number, patch: Partial<IncomeLine>) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, ...patch } : row)));

  const gridKeys = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 7,
    onAppendRow: () => setRows((current) => [...current, blankLine()]),
    onRemoveRow: (index) => {
      if (rows.length === 1) return false;
      setRows((current) => current.filter((_, i) => i !== index));
      return true;
    },
    onEscape: () => setError(''),
  });

  function reset() {
    setVoucherNo('');
    setLoadedVoucherNo('');
    setVchDate(today());
    setPartyCode('');
    setPartyName('');
    setLedgerCode(defaultLedger);
    setLedgerName('');
    setBillNo('');
    setBillDate(today());
    setChequeAmount(0);
    setChequeAccount('');
    setChequeNo('');
    setCardAmount(0);
    setCardAccount('');
    setCashAmount(0);
    setCashAccount('00001');
    setKasarAmount(0);
    setKasarAccount('');
    setTdsCode('');
    setEmployeeCode('');
    setBankName('');
    setDescription('');
    setRows([blankLine()]);
    setSaved(null);
    setError('');
  }

  const eligibleRows = rows.filter((row) => row.itemName.trim() || Number(row.netAmount) !== 0);
  const enteredTotal = money(
    rows.reduce(
      (sum, row) => sum + Math.max(0, Number(row.netAmount || 0) - Number(row.discountAmount || 0)),
      0,
    ),
  );
  const receivedTotal = money(chequeAmount + cardAmount + cashAmount + kasarAmount);

  async function load() {
    if (!coBook || !voucherNo.trim()) return;
    setBusy(true);
    setError('');
    try {
      const view = await get<IncomeView>(
        `${cfg.endpoint}/${encodeURIComponent(voucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setVoucherNo(view.voucherNo);
      setLoadedVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setPartyCode(view.partyCode);
      setPartyName(view.partyName);
      setLedgerCode(view.ledgerCode || defaultLedger);
      setLedgerName(view.ledgerName || '');
      setBillNo(view.billNo || '');
      setBillDate(view.billDate || view.vchDate);
      setChequeAmount(view.chequeAmount || 0);
      setChequeAccount(view.chequeAccount || '');
      setChequeNo(view.chequeNo || '');
      setCardAmount(view.cardAmount || 0);
      setCardAccount(view.cardAccount || '');
      setCashAmount(view.cashAmount || 0);
      setKasarAmount(view.kasarAmount || 0);
      setTdsCode(view.tdsCode || '');
      setEmployeeCode(view.employeeCode || '');
      setBankName(view.bankName || '');
      setDescription(view.description || '');
      setRows(view.lines.length ? view.lines : [blankLine()]);
      setSaved({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        lines: view.lines.length,
      });
    } catch (caught) {
      setError(message(caught, `${cfg.title} voucher load failed`));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    if (!coBook || !partyCode.trim() || !ledgerCode.trim() || !eligibleRows.length) {
      setError(
        `Select an ${mode} book, ${cfg.party.toLowerCase()}, ${cfg.ledger.toLowerCase()}, and at least one line.`,
      );
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = {
        coBook,
        vchDate,
        partyCode,
        ledgerCode,
        billNo,
        billDate,
        chequeAmount,
        chequeAccount,
        chequeNo,
        cardAmount,
        cardAccount,
        cashAmount,
        cashAccount,
        kasarAmount,
        kasarAccount,
        tdsCode,
        employeeCode,
        bankName,
        description,
        lines: eligibleRows,
      };
      const result = loadedVoucherNo
        ? await put<SaveResult>(`${cfg.endpoint}/${encodeURIComponent(loadedVoucherNo)}`, body)
        : await post<SaveResult>(cfg.endpoint, body);
      setSaved(result);
      setVoucherNo(result.voucherNo);
      setLoadedVoucherNo(result.voucherNo);
    } catch (caught) {
      setError(message(caught, `${cfg.title} voucher save failed`));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete voucher ${loadedVoucherNo}?`)) return;
    setBusy(true);
    setError('');
    try {
      await del(
        `${cfg.endpoint}/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      reset();
    } catch (caught) {
      setError(message(caught, `${cfg.title} voucher delete failed`));
    } finally {
      setBusy(false);
    }
  }

  return (
    <main className="page">
      <h1>
        {cfg.title} <span className="muted">— TR_OTH_PURC / {mode}</span>
      </h1>
      <FormKeyHints actions={formKeys} />

      <section className="card">
        <div className="form-grid">
          <label>
            Configured book
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={[mode]} />
          </label>
          <label>
            Voucher No
            <input value={voucherNo} onChange={(event) => setVoucherNo(event.target.value)} />
          </label>
          <label>
            Voucher date
            <input
              type="date"
              value={vchDate}
              onChange={(event) => setVchDate(event.target.value)}
            />
          </label>
          <label>
            {cfg.party}
            <LookupPicker
              entity="accounts"
              value={partyCode}
              onChange={setPartyCode}
              onPick={(row) => setPartyName(String(row.name || ''))}
            />
          </label>
          <label>
            {cfg.party} name
            <input value={partyName} readOnly />
          </label>
          <label>
            {cfg.ledger}
            <LookupPicker
              entity="accounts"
              value={ledgerCode}
              onChange={setLedgerCode}
              onPick={(row) => setLedgerName(String(row.name || ''))}
            />
          </label>
          <label>
            Ledger name
            <input value={ledgerName} readOnly />
          </label>
          <label>
            Bill number
            <input value={billNo} onChange={(event) => setBillNo(event.target.value)} />
          </label>
          <label>
            Bill date
            <input
              type="date"
              value={billDate}
              onChange={(event) => setBillDate(event.target.value)}
            />
          </label>
          <label>
            Employee
            <input value={employeeCode} onChange={(event) => setEmployeeCode(event.target.value)} />
          </label>
          <label>
            Description
            <input value={description} onChange={(event) => setDescription(event.target.value)} />
          </label>
        </div>
        <div className="toolbar">
          <button type="button" onClick={load} disabled={busy || !coBook || !voucherNo.trim()}>
            Load
          </button>
          <button type="button" onClick={save} disabled={busy || !coBook}>
            {loadedVoucherNo ? 'Update' : 'Save'}
          </button>
          <button type="button" onClick={remove} disabled={busy || !loadedVoucherNo}>
            Delete
          </button>
          <button
            type="button"
            disabled={busy || !loadedVoucherNo}
            onClick={() =>
              window.open(
                `/api${cfg.endpoint}/${encodeURIComponent(loadedVoucherNo)}/print?coBook=${encodeURIComponent(coBook)}&format=html`,
                '_blank',
              )
            }
          >
            Print
          </button>
          <button type="button" onClick={reset} disabled={busy}>
            New
          </button>
        </div>
      </section>

      <section className="card">
        <div className="table-wrap" onKeyDown={gridKeys}>
          <table aria-label="Other income lines">
            <thead>
              <tr>
                <th>HSN</th>
                <th>Description</th>
                <th>Tax code</th>
                <th>Tax type</th>
                <th>Net amount</th>
                <th>Disc %</th>
                <th>Disc amount</th>
                <th aria-label="Row actions" />
              </tr>
            </thead>
            <tbody>
              {rows.map((row, rowIndex) => (
                <tr key={rowIndex}>
                  <td data-grid-row={rowIndex} data-grid-column={0}>
                    <input
                      value={row.hsnCode}
                      onChange={(event) => update(rowIndex, { hsnCode: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={1}>
                    <input
                      value={row.itemName}
                      onChange={(event) => update(rowIndex, { itemName: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={2}>
                    <input
                      value={row.taxCode}
                      onChange={(event) => update(rowIndex, { taxCode: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={3}>
                    <select
                      value={row.taxType}
                      onChange={(event) =>
                        update(rowIndex, { taxType: event.target.value as 'F' | 'R' })
                      }
                    >
                      <option value="F">Forward</option>
                      <option value="R">Reverse</option>
                    </select>
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={4}>
                    <input
                      type="number"
                      step="0.01"
                      value={row.netAmount}
                      onChange={(event) =>
                        update(rowIndex, { netAmount: Number(event.target.value) })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={5}>
                    <input
                      type="number"
                      step="0.01"
                      value={row.discountPercent}
                      onChange={(event) =>
                        update(rowIndex, {
                          discountPercent: Number(event.target.value),
                          discountAmount: undefined,
                        })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={6}>
                    <input
                      type="number"
                      step="0.01"
                      value={row.discountAmount ?? ''}
                      onChange={(event) =>
                        update(rowIndex, {
                          discountAmount:
                            event.target.value === '' ? undefined : Number(event.target.value),
                        })
                      }
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      aria-label={`Remove row ${rowIndex + 1}`}
                      onClick={() => {
                        if (rows.length > 1)
                          setRows((current) => current.filter((_, i) => i !== rowIndex));
                      }}
                    >
                      Remove
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
        <button type="button" onClick={() => setRows((current) => [...current, blankLine()])}>
          Add row
        </button>
      </section>

      <section className="card">
        <h2>{cfg.settle}</h2>
        <div className="form-grid">
          <label>
            Cheque amount
            <input
              type="number"
              value={chequeAmount}
              onChange={(event) => setChequeAmount(Number(event.target.value))}
            />
          </label>
          <label>
            Cheque account
            <LookupPicker entity="accounts" value={chequeAccount} onChange={setChequeAccount} />
          </label>
          <label>
            Cheque number
            <input value={chequeNo} onChange={(event) => setChequeNo(event.target.value)} />
          </label>
          <label>
            Card amount
            <input
              type="number"
              value={cardAmount}
              onChange={(event) => setCardAmount(Number(event.target.value))}
            />
          </label>
          <label>
            Card account
            <LookupPicker entity="accounts" value={cardAccount} onChange={setCardAccount} />
          </label>
          <label>
            Cash amount
            <input
              type="number"
              value={cashAmount}
              onChange={(event) => setCashAmount(Number(event.target.value))}
            />
          </label>
          <label>
            Cash account
            <LookupPicker entity="accounts" value={cashAccount} onChange={setCashAccount} />
          </label>
          <label>
            Kasar amount
            <input
              type="number"
              value={kasarAmount}
              onChange={(event) => setKasarAmount(Number(event.target.value))}
            />
          </label>
          <label>
            Kasar account
            <LookupPicker entity="accounts" value={kasarAccount} onChange={setKasarAccount} />
          </label>
          <label>
            TDS code
            <input value={tdsCode} onChange={(event) => setTdsCode(event.target.value)} />
          </label>
          <label>
            Bank name
            <input value={bankName} onChange={(event) => setBankName(event.target.value)} />
          </label>
        </div>
        <p className="muted">
          Entered total ₹{enteredTotal.toLocaleString('en-IN')} · {cfg.settled} ₹
          {receivedTotal.toLocaleString('en-IN')}
        </p>
      </section>

      {saved ? (
        <p data-testid={`${cfg.testId}-saved`}>
          Voucher {saved.voucherNo} · hidden {saved.hiddenVoucherNo} · lines {saved.lines}
        </p>
      ) : null}
      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
