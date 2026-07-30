'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { ApiError, del, get, post, put } from '../../../../lib/api';

type AmountLine = {
  acCode: string;
  acName?: string;
  chequeNo: string;
  amount: number;
  description: string;
};

type AmountView = {
  voucherNo: string;
  vchDate: string;
  employeeCode: string;
  remark: string;
  hiddenVoucherNo: string;
  mainUser: string;
  mainBook: string;
  fromLocation: string;
  fromBook: string;
  fromVoucherNo: string;
  toLocation: string;
  toBook: string;
  toVoucherNo: string;
  lines: AmountLine[];
};

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
  transfer: {
    fromLocation: string;
    fromBook: string;
    fromVoucherNo: string;
    toLocation: string;
    toBook: string;
    toVoucherNo: string;
  };
};

const blankLine = (): AmountLine => ({
  acCode: '',
  chequeNo: '',
  amount: 0,
  description: '',
});

export default function LocationAmountPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [remark, setRemark] = useState('');
  const [toLocation, setToLocation] = useState('');
  const [fromLocation, setFromLocation] = useState('');
  const [fromBook, setFromBook] = useState('');
  const [fromVoucherNo, setFromVoucherNo] = useState('');
  const [rows, setRows] = useState<AmountLine[]>([blankLine()]);
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const message = (caught: unknown, fallback: string) =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  const update = (index: number, patch: Partial<AmountLine>) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, ...patch } : row)));

  const gridKeys = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 5,
    onAppendRow: () => setRows((current) => [...current, blankLine()]),
    onRemoveRow: (index) => {
      if (rows.length === 1) return false;
      setRows((current) => current.filter((_, i) => i !== index));
      return true;
    },
    onEscape: () => setError(''),
  });

  function reset() {
    setVchDate(new Date().toISOString().slice(0, 10));
    setVoucherNo('');
    setLoadedVoucherNo('');
    setEmployeeCode('');
    setRemark('');
    setToLocation('');
    setFromLocation('');
    setFromBook('');
    setFromVoucherNo('');
    setRows([blankLine()]);
    setSaved(null);
    setError('');
  }

  async function load() {
    if (!coBook || !voucherNo.trim()) return;
    setBusy(true);
    setError('');
    try {
      const view = await get<AmountView>(
        `/finance/location-amount/${encodeURIComponent(voucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setVoucherNo(view.voucherNo);
      setLoadedVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setEmployeeCode(view.employeeCode || '');
      setRemark(view.remark || '');
      setToLocation(view.toLocation || '');
      setFromLocation(view.fromLocation || '');
      setFromBook(view.fromBook || '');
      setFromVoucherNo(view.fromVoucherNo || '');
      setRows(view.lines.length ? view.lines : [blankLine()]);
      setSaved({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        lines: view.lines.length,
        transfer: {
          fromLocation: view.fromLocation,
          fromBook: view.fromBook,
          fromVoucherNo: view.fromVoucherNo,
          toLocation: view.toLocation,
          toBook: view.toBook,
          toVoucherNo: view.toVoucherNo,
        },
      });
    } catch (caught) {
      setError(message(caught, 'location-amount voucher load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    const lines = rows.filter((row) => row.acCode.trim() || Number(row.amount) !== 0);
    if (!coBook || !lines.length) {
      setError('Select a configured AMT OUT/AMT IN book and enter at least one line.');
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = {
        vchDate,
        employeeCode,
        remark,
        toLocation,
        fromLocation,
        fromBook,
        fromVoucherNo,
        lines,
      };
      const result = loadedVoucherNo
        ? await put<SaveResult>(
            `/finance/location-amount/${encodeURIComponent(loadedVoucherNo)}`,
            body,
          )
        : await post<SaveResult>('/finance/location-amount', body);
      setSaved(result);
      setVoucherNo(result.voucherNo);
      setLoadedVoucherNo(result.voucherNo);
      setToLocation(result.transfer.toLocation);
      setFromLocation(result.transfer.fromLocation);
      setFromBook(result.transfer.fromBook);
      setFromVoucherNo(result.transfer.fromVoucherNo);
    } catch (caught) {
      setError(message(caught, 'location-amount save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete location amount ${loadedVoucherNo}?`)) return;
    setBusy(true);
    setError('');
    try {
      await del(
        `/finance/location-amount/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      reset();
    } catch (caught) {
      setError(message(caught, 'location-amount delete failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <main className="page">
      <h1>Location Amount Transfer</h1>
      <FormKeyHints actions={formKeys} />
      <section className="card">
        <div className="form-grid">
          <label>
            Configured book
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={['AMT OUT', 'AMT IN']} />
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
            Destination location (AMT OUT)
            <input value={toLocation} onChange={(event) => setToLocation(event.target.value)} />
          </label>
          <label>
            Source location (AMT IN)
            <input value={fromLocation} onChange={(event) => setFromLocation(event.target.value)} />
          </label>
          <label>
            Source book (AMT IN)
            <input value={fromBook} onChange={(event) => setFromBook(event.target.value)} />
          </label>
          <label>
            Source voucher (AMT IN)
            <input
              value={fromVoucherNo}
              onChange={(event) => setFromVoucherNo(event.target.value)}
            />
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
          <table aria-label="Location amount lines">
            <thead>
              <tr>
                <th>Account</th>
                <th>Cheque</th>
                <th>Amount</th>
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
                      aria-label={`Cheque ${rowIndex + 1}`}
                      value={row.chequeNo}
                      maxLength={2}
                      onChange={(event) => update(rowIndex, { chequeNo: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={2}>
                    <input
                      aria-label={`Amount ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.amount}
                      onChange={(event) => update(rowIndex, { amount: Number(event.target.value) })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={3}>
                    <input
                      aria-label={`Description ${rowIndex + 1}`}
                      value={row.description}
                      onChange={(event) => update(rowIndex, { description: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={4}>
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
        <p data-testid="location-amount-loaded">
          Loaded {loadedVoucherNo}
          {saved
            ? ` · hidden ${saved.hiddenVoucherNo} · destination ${saved.transfer.toBook}/${saved.transfer.toVoucherNo}`
            : ''}
        </p>
      ) : null}
      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
