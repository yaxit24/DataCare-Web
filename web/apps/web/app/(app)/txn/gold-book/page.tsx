'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { todayLocal } from '../../../../lib/localDate';

type GoldLine = {
  acCode: string;
  acName?: string;
  mobile?: string;
  amount: number;
  rate: number;
  fine: number;
  ledgerAccount: string;
  taxCode: string;
  description: string;
  taxPercent?: number;
  taxAmount?: number;
  total?: number;
};

type GoldView = {
  voucherNo: string;
  vchDate: string;
  employeeCode: string;
  remark: string;
  hiddenVoucherNo: string;
  mainUser: string;
  lines: GoldLine[];
};

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
};

const blankLine = (): GoldLine => ({
  acCode: '',
  amount: 0,
  rate: 0,
  fine: 0,
  ledgerAccount: '',
  taxCode: '',
  description: '',
});

export default function GoldBookPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => todayLocal());
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [remark, setRemark] = useState('');
  const [rows, setRows] = useState<GoldLine[]>([blankLine()]);
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const message = (caught: unknown, fallback: string) =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  const update = (index: number, patch: Partial<GoldLine>) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, ...patch } : row)));

  const gridKeys = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 8,
    onAppendRow: () => setRows((current) => [...current, blankLine()]),
    onRemoveRow: (index) => {
      if (rows.length === 1) return false;
      setRows((current) => current.filter((_, i) => i !== index));
      return true;
    },
    onEscape: () => setError(''),
  });

  function reset() {
    setVchDate(todayLocal());
    setVoucherNo('');
    setLoadedVoucherNo('');
    setEmployeeCode('');
    setRemark('');
    setRows([blankLine()]);
    setSaved(null);
    setError('');
  }

  async function load() {
    if (!coBook || !voucherNo.trim()) return;
    setBusy(true);
    setError('');
    try {
      const view = await get<GoldView>(
        `/finance/gold-book/${encodeURIComponent(voucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setVoucherNo(view.voucherNo);
      setLoadedVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setEmployeeCode(view.employeeCode || '');
      setRemark(view.remark || '');
      setRows(view.lines.length ? view.lines : [blankLine()]);
      setSaved({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        lines: view.lines.length,
      });
    } catch (caught) {
      setError(message(caught, 'digital-gold voucher load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    const lines = rows.filter((row) => row.acCode.trim() || Number(row.amount) !== 0);
    if (!coBook || !lines.length) {
      setError('Select a configured DG GOLD book and enter at least one line.');
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = { vchDate, employeeCode, remark, lines };
      const result = loadedVoucherNo
        ? await put<SaveResult>(`/finance/gold-book/${encodeURIComponent(loadedVoucherNo)}`, body)
        : await post<SaveResult>('/finance/gold-book', body);
      setSaved(result);
      setVoucherNo(result.voucherNo);
      setLoadedVoucherNo(result.voucherNo);
    } catch (caught) {
      setError(message(caught, 'digital-gold save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete digital-gold voucher ${loadedVoucherNo}?`)) {
      return;
    }
    setBusy(true);
    setError('');
    try {
      await del(
        `/finance/gold-book/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      reset();
    } catch (caught) {
      setError(message(caught, 'digital-gold delete failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <main className="page">
      <h1>Digital Gold Book</h1>
      <FormKeyHints actions={formKeys} />
      <section className="card">
        <div className="form-grid">
          <label>
            Configured book
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={['DG GOLD']} />
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
            Employee
            <input value={employeeCode} onChange={(event) => setEmployeeCode(event.target.value)} />
          </label>
          <label>
            Remark
            <input value={remark} onChange={(event) => setRemark(event.target.value)} />
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
          <table aria-label="Digital gold lines">
            <thead>
              <tr>
                <th>Account</th>
                <th>Amount</th>
                <th>Rate</th>
                <th>Fine</th>
                <th>Ledger account</th>
                <th>Tax</th>
                <th>Description</th>
                <th aria-label="Row actions" />
              </tr>
            </thead>
            <tbody>
              {rows.map((row, rowIndex) => (
                <tr key={rowIndex}>
                  <td data-grid-row={rowIndex} data-grid-column={0}>
                    <input
                      aria-label={`Account ${rowIndex + 1}`}
                      value={row.acCode}
                      onChange={(event) => update(rowIndex, { acCode: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={1}>
                    <input
                      aria-label={`Amount ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.amount}
                      onChange={(event) => update(rowIndex, { amount: Number(event.target.value) })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={2}>
                    <input
                      aria-label={`Rate ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.rate}
                      onChange={(event) => update(rowIndex, { rate: Number(event.target.value) })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={3}>
                    <input
                      aria-label={`Fine ${rowIndex + 1}`}
                      type="number"
                      step="0.001"
                      value={row.fine}
                      onChange={(event) => update(rowIndex, { fine: Number(event.target.value) })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={4}>
                    <input
                      aria-label={`Ledger account ${rowIndex + 1}`}
                      value={row.ledgerAccount}
                      onChange={(event) => update(rowIndex, { ledgerAccount: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={5}>
                    <input
                      aria-label={`Tax code ${rowIndex + 1}`}
                      value={row.taxCode}
                      onChange={(event) => update(rowIndex, { taxCode: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={6}>
                    <input
                      aria-label={`Description ${rowIndex + 1}`}
                      value={row.description}
                      onChange={(event) => update(rowIndex, { description: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={7}>
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

      {loadedVoucherNo ? (
        <p data-testid="gold-book-loaded">
          Loaded {loadedVoucherNo}
          {saved ? ` · hidden ${saved.hiddenVoucherNo}` : ''}
        </p>
      ) : null}
      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
