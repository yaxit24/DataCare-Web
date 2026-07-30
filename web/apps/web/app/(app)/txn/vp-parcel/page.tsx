'use client';

import { useRouter } from 'next/navigation';
import { useState } from 'react';
import { BookSelect } from '../../../../components/BookSelect';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { ApiError, del, get, post, put } from '../../../../lib/api';

type ParcelLine = {
  tagNo: string;
  tagVoucherSrNo?: number;
  itemCode: string;
  itemName?: string;
  pcs: number;
  grossWt: number;
  otherWt: number;
  touch: number;
  westPct: number;
  rateType: string;
  rate: number;
  labourType: string;
  labourRate: number;
  otherAmount: number;
  remark: string;
  fineWt?: number;
  netAmount?: number;
  // Desktop RATE_CUT_ISU_REC line columns (TR_WH_SALE:13683).
  designImageId?: string;
  designNo?: string;
  ghatPct?: string;
  hallmarkId2?: string;
  hallmarkId2Wt?: string;
  hallmarkId3?: string;
  hallmarkId3Wt?: string;
  hallmarkId4?: string;
  hallmarkId4Wt?: string;
  hallmarkIdWt?: string;
  huid?: string;
  imageId?: string;
  itemColor?: string;
  itemLot?: string;
  itemStyle?: string;
  labourPct?: string;
  mrp?: string;
  size?: string;
  tableCode?: string;
};

type ParcelView = {
  voucherNo: string;
  vchDate: string;
  hiddenVoucherNo: string;
  mainUser: string;
  partyCode: string;
  partyName: string;
  angdiyaCode: string;
  billNo: string;
  employeeCode: string;
  description: string;
  lines: ParcelLine[];
};

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  lines: number;
};

const extendedParcelFields: Array<[string, string]> = [
  ['designImageId', 'Design Image Id'],
  ['designNo', 'Design No'],
  ['ghatPct', 'Ghat Pct'],
  ['hallmarkId2', 'Hallmark Id2'],
  ['hallmarkId2Wt', 'Hallmark Id2 Wt'],
  ['hallmarkId3', 'Hallmark Id3'],
  ['hallmarkId3Wt', 'Hallmark Id3 Wt'],
  ['hallmarkId4', 'Hallmark Id4'],
  ['hallmarkId4Wt', 'Hallmark Id4 Wt'],
  ['hallmarkIdWt', 'Hallmark Id Wt'],
  ['huid', 'Huid'],
  ['imageId', 'Image Id'],
  ['itemColor', 'Item Color'],
  ['itemLot', 'Item Lot'],
  ['itemStyle', 'Item Style'],
  ['labourPct', 'Labour Pct'],
  ['mrp', 'Mrp'],
  ['size', 'Size'],
  ['tableCode', 'Table Code'],
];
const blankLine = (): ParcelLine => ({
  tagNo: '',
  itemCode: '',
  pcs: 0,
  grossWt: 0,
  otherWt: 0,
  touch: 0,
  westPct: 0,
  rateType: 'G',
  rate: 0,
  labourType: 'G',
  labourRate: 0,
  otherAmount: 0,
  remark: '',
  designImageId: '',
  designNo: '',
  ghatPct: '',
  hallmarkId2: '',
  hallmarkId2Wt: '',
  hallmarkId3: '',
  hallmarkId3Wt: '',
  hallmarkId4: '',
  hallmarkId4Wt: '',
  hallmarkIdWt: '',
  huid: '',
  imageId: '',
  itemColor: '',
  itemLot: '',
  itemStyle: '',
  labourPct: '',
  mrp: '',
  size: '',
  tableCode: '',
});

export default function VpParcelPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [voucherNo, setVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [partyCode, setPartyCode] = useState('');
  const [angdiyaCode, setAngdiyaCode] = useState('');
  const [billNo, setBillNo] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [description, setDescription] = useState('');
  const [rows, setRows] = useState<ParcelLine[]>([blankLine()]);
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);

  const message = (caught: unknown, fallback: string) =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.error || caught.message
      : fallback;

  const update = (index: number, patch: Partial<ParcelLine>) =>
    setRows((current) => current.map((row, i) => (i === index ? { ...row, ...patch } : row)));

  const gridKeys = useGridKeyboard({
    rowCount: rows.length,
    columnCount: 14,
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
    setAngdiyaCode('');
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
      const view = await get<ParcelView>(
        `/sales/vp-parcel/${encodeURIComponent(voucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setVoucherNo(view.voucherNo);
      setLoadedVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setPartyCode(view.partyCode);
      setAngdiyaCode(view.angdiyaCode || '');
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
      setError(message(caught, 'VP parcel load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function save() {
    const lines = rows.filter(
      (row) => row.tagNo.trim() || row.itemCode.trim() || row.pcs !== 0 || row.grossWt !== 0,
    );
    if (!coBook || !partyCode.trim() || !lines.length) {
      setError('Select a VP PARCEL book, enter a party, and add at least one item or tag.');
      return;
    }
    setBusy(true);
    setError('');
    try {
      const body = {
        vchDate,
        partyCode,
        angdiyaCode,
        billNo,
        employeeCode,
        description,
        lines: lines.map(({ itemName: _itemName, fineWt: _fineWt, netAmount: _net, ...line }) =>
          line.tagNo.trim()
            ? { ...line, itemCode: undefined, tagNo: line.tagNo.trim() }
            : { ...line, tagNo: 'N' },
        ),
      };
      const result = loadedVoucherNo
        ? await put<SaveResult>(`/sales/vp-parcel/${encodeURIComponent(loadedVoucherNo)}`, body)
        : await post<SaveResult>('/sales/vp-parcel', body);
      setSaved(result);
      setVoucherNo(result.voucherNo);
      setLoadedVoucherNo(result.voucherNo);
    } catch (caught) {
      setError(message(caught, 'VP parcel save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete VP parcel ${loadedVoucherNo}?`)) return;
    setBusy(true);
    setError('');
    try {
      await del(
        `/sales/vp-parcel/${encodeURIComponent(loadedVoucherNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      reset();
    } catch (caught) {
      setError(message(caught, 'VP parcel delete failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <main className="page">
      <h1>VP Parcel</h1>
      <FormKeyHints actions={formKeys} />
      <section className="card">
        <div className="form-grid">
          <label>
            Configured book
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={['VP PARCEL']} />
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
            Angdiya code
            <input value={angdiyaCode} onChange={(event) => setAngdiyaCode(event.target.value)} />
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
          Enter a tag to resolve its item and physical weights from stock, or enter an item code and
          loose quantities. Account, item, tag, and book metadata are always resolved by the server.
        </p>
        <div className="table-wrap" onKeyDown={gridKeys}>
          <table aria-label="VP parcel lines">
            <thead>
              <tr>
                <th>Tag</th>
                <th>Item</th>
                <th>Pcs</th>
                <th>Gross</th>
                <th>Other wt</th>
                <th>Touch</th>
                <th>West %</th>
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
                      onChange={(event) => update(rowIndex, { itemCode: event.target.value })}
                      title={row.itemName}
                    />
                  </td>
                  {(
                    [
                      ['pcs', 0.001],
                      ['grossWt', 0.001],
                      ['otherWt', 0.001],
                      ['touch', 0.01],
                      ['westPct', 0.01],
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
                  <td data-grid-row={rowIndex} data-grid-column={7}>
                    <input
                      aria-label={`Rate type ${rowIndex + 1}`}
                      value={row.rateType}
                      onChange={(event) => update(rowIndex, { rateType: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={8}>
                    <input
                      aria-label={`Rate ${rowIndex + 1}`}
                      type="number"
                      step="0.01"
                      value={row.rate}
                      onChange={(event) => update(rowIndex, { rate: Number(event.target.value) })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={9}>
                    <input
                      aria-label={`Labour type ${rowIndex + 1}`}
                      value={row.labourType}
                      onChange={(event) => update(rowIndex, { labourType: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={10}>
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
                  <td data-grid-row={rowIndex} data-grid-column={11}>
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
                  <td data-grid-row={rowIndex} data-grid-column={12}>
                    <input
                      aria-label={`Remark ${rowIndex + 1}`}
                      value={row.remark}
                      onChange={(event) => update(rowIndex, { remark: event.target.value })}
                    />
                  </td>
                  <td data-grid-row={rowIndex} data-grid-column={13}>
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
          {rows.map((row, index) => (
            <details key={`vp-row-extra-${index}`} style={{ marginTop: 8 }}>
              <summary>Parcel row {index + 1} desktop fields</summary>
              <div className="row">
                {extendedParcelFields.map(([key, label]) => (
                  <div className="field" key={key}>
                    <label>{label}</label>
                    <input
                      value={String((row as Record<string, unknown>)[key] ?? '')}
                      onChange={(e) =>
                        update(index, { [key]: e.target.value } as Partial<ParcelLine>)
                      }
                    />
                  </div>
                ))}
              </div>
            </details>
          ))}
        </div>
        <button type="button" onClick={() => setRows((current) => [...current, blankLine()])}>
          Add row
        </button>
      </section>

      {loadedVoucherNo ? (
        <p data-testid="vp-parcel-loaded">
          Loaded {loadedVoucherNo}
          {saved ? ` · hidden ${saved.hiddenVoucherNo}` : ''}
        </p>
      ) : null}
      {error ? <p className="error">{error}</p> : null}
    </main>
  );
}
