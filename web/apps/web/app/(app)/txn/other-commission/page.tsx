'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { ApiError, del, get, post, put } from '../../../../lib/api';

type CommissionLine = {
  itemCode: string;
  itemName?: string;
  remark: string;
  saleAmount: number;
  commissionPercent: number;
  taxCode: string;
  taxType: 'F' | 'R';
  taxableAmount?: number;
  taxPercent?: number;
  igstAmount?: number;
  cgstAmount?: number;
  sgstAmount?: number;
  totalAmount?: number;
};

type CommissionView = {
  voucherNo: string;
  hiddenVoucherNo: string;
  vchDate: string;
  partyCode: string;
  partyName: string;
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
  lines: CommissionLine[];
};

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
};

const today = () => new Date().toISOString().slice(0, 10);
const blankLine = (): CommissionLine => ({
  itemCode: '',
  remark: '',
  saleAmount: 0,
  commissionPercent: 0,
  taxCode: '',
  taxType: 'F',
});

export default function OtherCommissionPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [vchDate, setVchDate] = useState(today);
  const [partyCode, setPartyCode] = useState('');
  const [partyName, setPartyName] = useState('');
  const [billNo, setBillNo] = useState('');
  const [billDate, setBillDate] = useState(today);
  const [chequeAmount, setChequeAmount] = useState(0);
  const [chequeAccount, setChequeAccount] = useState('');
  const [chequeNo, setChequeNo] = useState('');
  const [cardAmount, setCardAmount] = useState(0);
  const [cardAccount, setCardAccount] = useState('');
  const [cashAmount, setCashAmount] = useState(0);
  const [kasarAmount, setKasarAmount] = useState(0);
  const [tdsCode, setTdsCode] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [bankName, setBankName] = useState('');
  const [description, setDescription] = useState('');
  const [rows, setRows] = useState<CommissionLine[]>([blankLine()]);
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const message = (caught: unknown, fallback: string) =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  const update = (index: number, patch: Partial<CommissionLine>) =>
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
    setBillNo('');
    setBillDate(today());
    setChequeAmount(0);
    setChequeAccount('');
    setChequeNo('');
    setCardAmount(0);
    setCardAccount('');
    setCashAmount(0);
    setKasarAmount(0);
    setTdsCode('');
    setEmployeeCode('');
    setBankName('');
    setDescription('');
    setRows([blankLine()]);
    setSaved(null);
    setError('');
  }

  async function load() {
    if (!coBook || !voucherNo.trim()) return;
    setBusy(true);
    setError('');
    try {
      const view = await get<CommissionView>(
        `/other-commission/${encodeURIComponent(voucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setVoucherNo(view.voucherNo);
      setLoadedVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setPartyCode(view.partyCode);
      setPartyName(view.partyName);
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
      setError(message(caught, 'other-commission voucher load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    const lines = rows.filter((row) => row.itemCode.trim() || Number(row.saleAmount) !== 0);
    if (!coBook || !partyCode.trim() || !lines.length) {
      setError('Select a configured OTH COMM book, party, and at least one line.');
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = {
        vchDate,
        partyCode,
        billNo,
        billDate,
        chequeAmount,
        chequeAccount,
        chequeNo,
        cardAmount,
        cardAccount,
        cashAmount,
        kasarAmount,
        tdsCode,
        employeeCode,
        bankName,
        description,
        lines,
      };
      const result = loadedVoucherNo
        ? await put<SaveResult>(`/other-commission/${encodeURIComponent(loadedVoucherNo)}`, body)
        : await post<SaveResult>('/other-commission', body);
      setSaved(result);
      setVoucherNo(result.voucherNo);
      setLoadedVoucherNo(result.voucherNo);
    } catch (caught) {
      setError(message(caught, 'other-commission voucher save failed'));
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
        `/other-commission/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      reset();
    } catch (caught) {
      setError(message(caught, 'other-commission voucher delete failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <main className="page">
      <h1>Other Commission / Expense Voucher</h1>
      <FormKeyHints actions={formKeys} />
      <section className="card">
        <div className="form-grid">
          <label>
            Configured book
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={['OTH COMM']} />
          </label>
          <label>
            Voucher No
            <input
              aria-label="Voucher No"
              value={voucherNo}
              onChange={(event) => setVoucherNo(event.target.value)}
            />
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
            Party account
            <input value={partyCode} onChange={(event) => setPartyCode(event.target.value)} />
          </label>
          <label>
            Party name
            <input value={partyName} readOnly />
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
          <button type="button" onClick={reset} disabled={busy}>
            New
          </button>
        </div>
      </section>

      <section className="card">
        <div className="table-wrap" onKeyDown={gridKeys}>
          <table aria-label="Other commission lines">
            <thead>
              <tr>
                <th>Item</th>
                <th>Remark</th>
                <th>Sale amount</th>
                <th>Commission %</th>
                <th>Tax</th>
                <th>Tax type</th>
                <th aria-label="Row actions" />
              </tr>
            </thead>
            <tbody>
              {rows.map((row, rowIndex) => (
                <tr key={rowIndex}>
                  <td data-grid-row={rowIndex} data-grid-column={0}>
                    <input
                      aria-label={`Item ${rowIndex + 1}`}
                      value={row.itemCode}
                      onChange={(event) => update(rowIndex, { itemCode: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={1}>
                    <input
                      aria-label={`Remark ${rowIndex + 1}`}
                      value={row.remark}
                      onChange={(event) => update(rowIndex, { remark: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={2}>
                    <input
                      aria-label={`Sale amount ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.saleAmount}
                      onChange={(event) =>
                        update(rowIndex, { saleAmount: Number(event.target.value) })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={3}>
                    <input
                      aria-label={`Commission percent ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.commissionPercent}
                      onChange={(event) =>
                        update(rowIndex, { commissionPercent: Number(event.target.value) })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={4}>
                    <input
                      aria-label={`Tax code ${rowIndex + 1}`}
                      value={row.taxCode}
                      onChange={(event) => update(rowIndex, { taxCode: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={5}>
                    <select
                      aria-label={`Tax type ${rowIndex + 1}`}
                      value={row.taxType}
                      onChange={(event) =>
                        update(rowIndex, { taxType: event.target.value as 'F' | 'R' })
                      }
                    >
                      <option value="F">Forward</option>
                      <option value="R">Reverse</option>
                    </select>
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={6}>
                    <button
                      type="button"
                      aria-label={`Remove row ${rowIndex + 1}`}
                      onClick={() => {
                        if (rows.length > 1) {
                          setRows((current) => current.filter((_, i) => i !== rowIndex));
                        }
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
            <input
              value={chequeAccount}
              onChange={(event) => setChequeAccount(event.target.value)}
            />
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
            <input value={cardAccount} onChange={(event) => setCardAccount(event.target.value)} />
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
            Kasar amount
            <input
              type="number"
              value={kasarAmount}
              onChange={(event) => setKasarAmount(Number(event.target.value))}
            />
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
      </section>

      {loadedVoucherNo ? (
        <p data-testid="other-commission-loaded">
          Loaded {loadedVoucherNo}
          {saved ? ` · hidden ${saved.hiddenVoucherNo}` : ''}
        </p>
      ) : null}
      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
