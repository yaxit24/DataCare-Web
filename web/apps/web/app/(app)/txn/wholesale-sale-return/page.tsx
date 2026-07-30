'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { ApiError, del, get, post, put } from '../../../../lib/api';

type ReturnLine = {
  tagNo: string;
  tagVoucherSrNo?: number;
  sourceYear?: string;
  sourceBook?: string;
  sourceVoucherNo?: string;
  itemCode: string;
  itemName?: string;
  pcs: number;
  grossWt: number;
  otherWt: number;
  touch: number;
  westPct: number;
  lessTouch: number;
  rateType: string;
  rate: number;
  labourType: string;
  labourRate: number;
  otherAmount: number;
  taxPct: number;
  remark: string;
  fineWt?: number;
  netAmount?: number;
};

type ReturnView = {
  voucherNo: string;
  vchDate: string;
  hiddenVoucherNo: string;
  mainUser: string;
  partyCode: string;
  partyName: string;
  billNo: string;
  employeeCode: string;
  description: string;
  lines: ReturnLine[];
};

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
};

const blankLine = (): ReturnLine => ({
  tagNo: '',
  itemCode: '',
  pcs: 0,
  grossWt: 0,
  otherWt: 0,
  touch: 0,
  westPct: 0,
  lessTouch: 0,
  rateType: 'G',
  rate: 0,
  labourType: 'G',
  labourRate: 0,
  otherAmount: 0,
  taxPct: 0,
  remark: '',
});

export default function WholesaleSaleReturnPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [partyCode, setPartyCode] = useState('');
  const [billNo, setBillNo] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [description, setDescription] = useState('');
  const [rows, setRows] = useState<ReturnLine[]>([blankLine()]);
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const message = (caught: unknown, fallback: string) =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  const update = (index: number, patch: Partial<ReturnLine>) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, ...patch } : row)));

  const gridKeys = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 15,
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
    setPartyCode('');
    setBillNo('');
    setEmployeeCode('');
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
      const view = await get<ReturnView>(
        `/sales/wholesale-sale-return/${encodeURIComponent(voucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setVoucherNo(view.voucherNo);
      setLoadedVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setPartyCode(view.partyCode);
      setBillNo(view.billNo || '');
      setEmployeeCode(view.employeeCode || '');
      setDescription(view.description || '');
      setRows(view.lines.length ? view.lines : [blankLine()]);
      setSaved({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        lines: view.lines.length,
      });
    } catch (caught) {
      setError(message(caught, 'Wholesale sale return load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    const lines = rows.filter(
      (row) => row.tagNo.trim() || row.itemCode.trim() || row.pcs !== 0 || row.grossWt !== 0,
    );
    if (!coBook || !partyCode.trim() || !lines.length) {
      setError('Select a WH RTN book, enter a party, and add at least one item or sold tag.');
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = {
        vchDate,
        partyCode,
        billNo,
        employeeCode,
        description,
        lines: lines.map(({ itemName: _itemName, fineWt: _fine, netAmount: _net, ...line }) =>
          line.tagNo.trim()
            ? { ...line, itemCode: undefined, tagNo: line.tagNo.trim() }
            : { ...line, tagNo: 'N' },
        ),
      };
      const result = loadedVoucherNo
        ? await put<SaveResult>(
            `/sales/wholesale-sale-return/${encodeURIComponent(loadedVoucherNo)}`,
            body,
          )
        : await post<SaveResult>('/sales/wholesale-sale-return', body);
      setSaved(result);
      setVoucherNo(result.voucherNo);
      setLoadedVoucherNo(result.voucherNo);
    } catch (caught) {
      setError(message(caught, 'Wholesale sale return save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete wholesale sale return ${loadedVoucherNo}?`)) {
      return;
    }
    setBusy(true);
    setError('');
    try {
      await del(
        `/sales/wholesale-sale-return/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      reset();
    } catch (caught) {
      setError(message(caught, 'Wholesale sale return delete failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <main className="page">
      <h1>Wholesale Sale Return</h1>
      <FormKeyHints actions={formKeys} />
      <section className="card">
        <div className="form-grid">
          <label>
            Configured book
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={['WH RTN']} />
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
            Party code
            <input value={partyCode} onChange={(event) => setPartyCode(event.target.value)} />
          </label>
          <label>
            Bill no
            <input value={billNo} onChange={(event) => setBillNo(event.target.value)} />
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
        <p>
          A tag is resolved from the selected party&apos;s WH SALES/TOUR SALES history. Item,
          account, tag, tax, and book metadata are always resolved by the server.
        </p>
        <div className="table-wrap" onKeyDown={gridKeys}>
          <table aria-label="Wholesale sale return lines">
            <thead>
              <tr>
                <th>Tag</th>
                <th>Item</th>
                <th>Pcs</th>
                <th>Gross</th>
                <th>Other wt</th>
                <th>Touch</th>
                <th>West %</th>
                <th>Less touch</th>
                <th>Rate type</th>
                <th>Rate</th>
                <th>Lbr type</th>
                <th>Lbr rate</th>
                <th>Other amt</th>
                <th>Remark</th>
                <th aria-label="Row actions" />
              </tr>
            </thead>
            <tbody>
              {rows.map((row, rowIndex) => (
                <tr key={rowIndex}>
                  <td data-grid-row={rowIndex} data-grid-column={0}>
                    <input
                      aria-label={`Tag ${rowIndex + 1}`}
                      value={row.tagNo}
                      onChange={(event) => update(rowIndex, { tagNo: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={1}>
                    <input
                      aria-label={`Item ${rowIndex + 1}`}
                      value={row.itemCode}
                      readOnly={Boolean(row.tagNo.trim() && row.tagNo.trim() !== 'N')}
                      title={row.itemName}
                      onChange={(event) => update(rowIndex, { itemCode: event.target.value })}
                    />
                  </td>
                  {(
                    [
                      ['pcs', 0.001],
                      ['grossWt', 0.001],
                      ['otherWt', 0.001],
                      ['touch', 0.01],
                      ['westPct', 0.01],
                      ['lessTouch', 0.01],
                    ] as const
                  ).map(([field, step], columnOffset) => (
                    <td key={field} data-grid-row={rowIndex} data-grid-column={columnOffset + 2}>
                      <input
                        aria-label={`${field} ${rowIndex + 1}`}
                        type="number"
                        step={step}
                        value={row[field]}
                        onChange={(event) =>
                          update(rowIndex, { [field]: Number(event.target.value) })
                        }
                      />
                    </td>
                  ))}
                  <td data-grid-row={rowIndex} data-grid-column={8}>
                    <input
                      aria-label={`Rate type ${rowIndex + 1}`}
                      value={row.rateType}
                      onChange={(event) => update(rowIndex, { rateType: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={9}>
                    <input
                      aria-label={`Rate ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.rate}
                      onChange={(event) => update(rowIndex, { rate: Number(event.target.value) })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={10}>
                    <input
                      aria-label={`Labour type ${rowIndex + 1}`}
                      value={row.labourType}
                      onChange={(event) => update(rowIndex, { labourType: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={11}>
                    <input
                      aria-label={`Labour rate ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.labourRate}
                      onChange={(event) =>
                        update(rowIndex, { labourRate: Number(event.target.value) })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={12}>
                    <input
                      aria-label={`Other amount ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.otherAmount}
                      onChange={(event) =>
                        update(rowIndex, { otherAmount: Number(event.target.value) })
                      }
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={13}>
                    <input
                      aria-label={`Remark ${rowIndex + 1}`}
                      value={row.remark}
                      onChange={(event) => update(rowIndex, { remark: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={14}>
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
        <p data-testid="wholesale-sale-return-loaded">
          Loaded {loadedVoucherNo}
          {saved ? ` · hidden ${saved.hiddenVoucherNo}` : ''}
        </p>
      ) : null}
      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
