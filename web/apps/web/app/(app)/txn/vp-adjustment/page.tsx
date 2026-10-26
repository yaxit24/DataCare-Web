'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { todayLocal } from '../../../../lib/localDate';

type VpLine = {
  vpYear: string;
  vpBook: string;
  vpNo: string;
  receiptAmount: number;
  kasarAmount: number;
  description: string;
  partyCode?: string;
  partyName?: string;
  angdiyaCode?: string;
  angdiyaName?: string;
};

type VpView = {
  voucherNo: string;
  vchDate: string;
  employeeCode: string;
  hiddenVoucherNo: string;
  mainUser: string;
  lines: VpLine[];
};

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
};

const blankLine = (): VpLine => ({
  vpYear: '',
  vpBook: '',
  vpNo: '',
  receiptAmount: 0,
  kasarAmount: 0,
  description: '',
});

export default function VpAdjustmentPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => todayLocal());
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [rows, setRows] = useState<VpLine[]>([blankLine()]);
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const message = (caught: unknown, fallback: string) =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  const update = (index: number, patch: Partial<VpLine>) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, ...patch } : row)));

  const gridKeys = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 9,
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
    setRows([blankLine()]);
    setSaved(null);
    setError('');
  }

  async function load() {
    if (!coBook || !voucherNo.trim()) return;
    setBusy(true);
    setError('');
    try {
      const view = await get<VpView>(
        `/finance/vp-adjustment/${encodeURIComponent(voucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setVoucherNo(view.voucherNo);
      setLoadedVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setEmployeeCode(view.employeeCode || '');
      setRows(view.lines.length ? view.lines : [blankLine()]);
      setSaved({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        lines: view.lines.length,
      });
    } catch (caught) {
      setError(message(caught, 'VP adjustment load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    const lines = rows.filter(
      (row) => row.vpYear.trim() || row.vpBook.trim() || row.vpNo.trim() || row.receiptAmount !== 0,
    );
    if (!coBook || !lines.length) {
      setError('Select a configured VP REC book and enter at least one source VP line.');
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = {
        vchDate,
        employeeCode,
        lines: lines.map(
          ({
            partyCode: _partyCode,
            partyName: _partyName,
            angdiyaCode: _angdiyaCode,
            angdiyaName: _angdiyaName,
            ...line
          }) => line,
        ),
      };
      const result = loadedVoucherNo
        ? await put<SaveResult>(
            `/finance/vp-adjustment/${encodeURIComponent(loadedVoucherNo)}`,
            body,
          )
        : await post<SaveResult>('/finance/vp-adjustment', body);
      setSaved(result);
      setVoucherNo(result.voucherNo);
      setLoadedVoucherNo(result.voucherNo);
    } catch (caught) {
      setError(message(caught, 'VP adjustment save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete VP adjustment ${loadedVoucherNo}?`)) return;
    setBusy(true);
    setError('');
    try {
      await del(
        `/finance/vp-adjustment/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      reset();
    } catch (caught) {
      setError(message(caught, 'VP adjustment delete failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <main className="page">
      <h1>VP Adjustment</h1>
      <FormKeyHints actions={formKeys} />
      <section className="card">
        <div className="form-grid">
          <label>
            Configured book
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={['VP REC']} />
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
          <table aria-label="VP adjustment lines">
            <thead>
              <tr>
                <th>Source year</th>
                <th>Source book</th>
                <th>Source voucher</th>
                <th>Party</th>
                <th>Angdiya</th>
                <th>Receipt</th>
                <th>Kasar</th>
                <th>Description</th>
                <th aria-label="Row actions" />
              </tr>
            </thead>
            <tbody>
              {rows.map((row, rowIndex) => (
                <tr key={rowIndex}>
                  <td data-grid-row={rowIndex} data-grid-column={0}>
                    <input
                      aria-label={`Source year ${rowIndex + 1}`}
                      value={row.vpYear}
                      onChange={(event) => update(rowIndex, { vpYear: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={1}>
                    <input
                      aria-label={`Source book ${rowIndex + 1}`}
                      value={row.vpBook}
                      onChange={(event) => update(rowIndex, { vpBook: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={2}>
                    <input
                      aria-label={`Source voucher ${rowIndex + 1}`}
                      value={row.vpNo}
                      onChange={(event) => update(rowIndex, { vpNo: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={3}>
                    <input
                      aria-label={`Resolved party ${rowIndex + 1}`}
                      value={[row.partyCode, row.partyName].filter(Boolean).join(' — ')}
                      readOnly
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={4}>
                    <input
                      aria-label={`Resolved angdiya ${rowIndex + 1}`}
                      value={[row.angdiyaCode, row.angdiyaName].filter(Boolean).join(' — ')}
                      readOnly
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={5}>
                    <input
                      aria-label={`Receipt amount ${rowIndex + 1}`}
                      type="number"
                      min="0"
                      step="0.01"
                      value={row.receiptAmount}
                      onChange={(event) =>
                        update(rowIndex, { receiptAmount: Number(event.target.value) })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={6}>
                    <input
                      aria-label={`Kasar amount ${rowIndex + 1}`}
                      type="number"
                      min="0"
                      step="0.01"
                      value={row.kasarAmount}
                      onChange={(event) =>
                        update(rowIndex, { kasarAmount: Number(event.target.value) })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={7}>
                    <input
                      aria-label={`Description ${rowIndex + 1}`}
                      value={row.description}
                      onChange={(event) => update(rowIndex, { description: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={8}>
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
        <p data-testid="vp-adjustment-loaded">
          Loaded {loadedVoucherNo}
          {saved ? ` · hidden ${saved.hiddenVoucherNo}` : ''}
        </p>
      ) : null}
      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
