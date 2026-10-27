'use client';

import { useRef, useState, type FormEvent } from 'react';
import { ApiError, del, get, post, put } from '../lib/api';
import { BookSelect } from './BookSelect';
import { useBusinessScope } from './BusinessScope';
import { LookupPicker } from './LookupPicker';
import { useGridKeyboard } from './GridKeyboard';
import { ExtendedBodyCells, ExtendedHeaderCells, GridModeToggle } from './ExtendedGrid';
import { fineFor } from '@datacare/core';
import { todayLocal } from '../lib/localDate';

type Direction = 'in' | 'out';

interface Line {
  itCode: string;
  tagNo: string;
  vchSrno: string;
  itemLot: string;
  lotNo: string;
  designNo: string;
  tblCode: string;
  itmSize: string;
  itmStyle: string;
  itmColor: string;
  hallmarkId: string;
  pcs: string;
  bagWt: string;
  grossWt: string;
  otherWt: string;
  netWt: string;
  ghtWt: string;
  touch: string;
  westPct: string;
  fineWt: string;
  labourPct: string;
  labourType: string;
  labourRate: string;
  labourAmount: string;
  otherAmount: string;
  rate: string;
  amount: string;
  tagCost: string;
  mrp: string;
  remark: string;
  karigarName: string;
  karigarOtherWt: string;
  karigarNetWt: string;
  karigarGhtPct: string;
  karigarGhtWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  karigarLbrRate: string;
  karigarLbrAmt: string;
  karigarOthAmt: string;
  rateType: string;
  prCode: string;
  itType: string;
  lbrCode: string;
  designImageId: string;
  empIsu: string;
  fromLcCode: string;
  toLcCode: string;
}

const extendedLineFields: Array<[keyof Line, string]> = [
  ['tagNo', 'TagNo'],
  ['vchSrno', 'Tag SrNo'],
  ['itemLot', 'ItmLot'],
  ['lotNo', 'LotNo'],
  ['designNo', 'Design'],
  ['tblCode', 'Counter'],
  ['itmSize', 'Size'],
  ['itmStyle', 'Style'],
  ['itmColor', 'Color'],
  ['hallmarkId', 'HmId'],
  ['bagWt', 'BagWt'],
  ['otherWt', 'LsWt'],
  ['ghtWt', 'GhtWt'],
  ['labourPct', 'Lbr%'],
  ['labourType', 'LType'],
  ['labourRate', 'LbrRate'],
  ['labourAmount', 'LbrAmt'],
  ['otherAmount', 'OthAmt'],
  ['amount', 'ItAmt'],
  ['tagCost', 'TagCost'],
  ['mrp', 'Mrp'],
  ['remark', 'Remark'],
  ['karigarName', 'KrCode'],
  ['karigarOtherWt', 'KrOthWt'],
  ['karigarNetWt', 'KrNwt'],
  ['karigarGhtPct', 'KrGht%'],
  ['karigarGhtWt', 'KrGht'],
  ['karigarTouch', 'KrTouch'],
  ['karigarWestPct', 'KrWst%'],
  ['karigarFine', 'KrFine'],
  ['karigarLbrRate', 'KrLRate'],
  ['karigarLbrAmt', 'KrLAmt'],
  ['karigarOthAmt', 'KrOthAmt'],
  ['rateType', 'RateType'],
  ['prCode', 'PrCost'],
  ['itType', 'ItType'],
  ['lbrCode', 'LbrCode'],
  ['designImageId', 'Image'],
  ['empIsu', 'EmpIsu'],
  ['fromLcCode', 'From LC'],
  ['toLcCode', 'To LC'],
];

const numericFields = new Set<string>([
  'vchSrno',
  'bagWt',
  'otherWt',
  'ghtWt',
  'fineWt',
  'labourPct',
  'labourRate',
  'labourAmount',
  'otherAmount',
  'amount',
  'tagCost',
  'mrp',
  'karigarOtherWt',
  'karigarNetWt',
  'karigarGhtPct',
  'karigarGhtWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
  'karigarLbrRate',
  'karigarLbrAmt',
  'karigarOthAmt',
]);

const blank = (): Line => ({
  itCode: '',
  tagNo: '',
  vchSrno: '',
  itemLot: '',
  lotNo: '',
  designNo: '',
  tblCode: '',
  itmSize: '',
  itmStyle: '',
  itmColor: '',
  hallmarkId: '',
  pcs: '1',
  bagWt: '',
  grossWt: '',
  otherWt: '',
  netWt: '',
  ghtWt: '',
  touch: '',
  westPct: '',
  fineWt: '',
  labourPct: '',
  labourType: '',
  labourRate: '',
  labourAmount: '',
  otherAmount: '',
  rate: '',
  amount: '',
  tagCost: '',
  mrp: '',
  remark: '',
  karigarName: '',
  karigarOtherWt: '',
  karigarNetWt: '',
  karigarGhtPct: '',
  karigarGhtWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  karigarLbrRate: '',
  karigarLbrAmt: '',
  karigarOthAmt: '',
  rateType: '',
  prCode: '',
  itType: '',
  lbrCode: '',
  designImageId: '',
  empIsu: '',
  fromLcCode: '',
  toLcCode: '',
});

const n = (value: string) => Number(value || 0);
const str = (value: unknown) => (value == null || Number(value) === 0 ? '' : String(value));
const currentDate = () => todayLocal();
const errorText = (error: unknown) =>
  error instanceof ApiError
    ? error.body?.detail || error.body?.message || error.body?.error || error.message
    : 'request failed';

function lineFine(line: Line): number {
  if (line.fineWt.trim()) return n(line.fineWt);
  return fineFor('sale', {
    netWt: n(line.netWt),
    ghtWt: n(line.ghtWt),
    touch: n(line.touch),
    westPct: n(line.westPct),
  });
}

function linePayload(line: Line) {
  const extended = Object.fromEntries(
    extendedLineFields
      .map(([key]) => [key, String((line as unknown as Record<string, unknown>)[key] ?? '').trim()])
      .filter(([, value]) => value !== '')
      .map(([key, value]) => [key, numericFields.has(key as string) ? Number(value) : value]),
  );
  return {
    ...extended,
    itCode: line.itCode.trim(),
    pcs: n(line.pcs),
    grossWt: n(line.grossWt),
    netWt: n(line.netWt),
    touch: n(line.touch),
    westPct: n(line.westPct),
    rate: n(line.rate),
  };
}

export function StockInoutForm({ direction }: { direction: Direction }) {
  const { coYear, lcCode } = useBusinessScope();
  const isIn = direction === 'in';
  const label = isIn ? 'Stock In' : 'Stock Out';
  const endpoint = isIn ? '/stock/in' : '/stock/out';
  const mainBook = isIn ? 'INWORD' : 'OUTWORD';
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(currentDate);
  const [transferLcCode, setTransferLcCode] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [description, setDescription] = useState('');
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  const [busy, setBusy] = useState(false);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const submitRef = useRef<HTMLButtonElement>(null);
  const columnCount = fullGrid ? 8 + extendedLineFields.length : 8;

  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount,
    onAppendRow: () => setLines((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setLines((rows) => (rows.length > 1 ? rows.filter((_, index) => index !== row) : [blank()]));
      return true;
    },
    onEscape: () => submitRef.current?.focus(),
  });

  const setLine = (index: number, key: keyof Line, value: string) =>
    setLines((rows) =>
      rows.map((row, current) => (current === index ? { ...row, [key]: value } : row)),
    );

  const scopeQuery = `coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`;
  const fineTotal = lines.reduce((sum, line) => sum + lineFine(line), 0);
  const netTotal = lines.reduce((sum, line) => sum + n(line.netWt), 0);

  function newVoucher() {
    setLoadedVchNo('');
    setVoucherLookup('');
    setVchDate(currentDate());
    setTransferLcCode('');
    setEmployeeCode('');
    setDescription('');
    setLines([blank()]);
    setMsg(null);
  }

  async function loadVoucher() {
    if (!voucherLookup.trim() || !coBook) return;
    setBusy(true);
    setMsg(null);
    try {
      const view = await get<any>(
        `${endpoint}/${encodeURIComponent(voucherLookup.trim())}?${scopeQuery}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setVchDate(String(view.vchDate || currentDate()));
      setTransferLcCode(String(isIn ? view.fromLcCode || '' : view.toLcCode || ''));
      setEmployeeCode(String(view.employeeCode || ''));
      setDescription(String(view.description || ''));
      const loaded = (view.lines ?? []).map((row: any): Line => ({
        ...blank(),
        itCode: String(row.itCode ?? ''),
        tagNo: String(row.tagNo === 'N' ? '' : (row.tagNo ?? '')),
        vchSrno: str(row.vchSrno),
        itemLot: String(row.itemLot ?? ''),
        lotNo: String(row.lotNo ?? ''),
        designNo: String(row.designNo ?? ''),
        tblCode: String(row.tblCode ?? ''),
        itmSize: String(row.itmSize ?? ''),
        itmStyle: String(row.itmStyle ?? ''),
        itmColor: String(row.itmColor ?? ''),
        hallmarkId: String(row.hallmarkId ?? ''),
        pcs: str(row.pcs) || '1',
        bagWt: str(row.bagWt),
        grossWt: str(row.grossWt),
        otherWt: str(row.otherWt),
        netWt: str(row.netWt),
        ghtWt: str(row.ghtWt),
        touch: str(row.touch),
        westPct: str(row.westPct),
        fineWt: str(row.fineWt),
        labourPct: str(row.labourPct),
        labourType: String(row.labourType ?? ''),
        labourRate: str(row.labourRate),
        labourAmount: str(row.labourAmount),
        otherAmount: str(row.otherAmount),
        rate: str(row.rate),
        amount: str(row.amount),
        tagCost: str(row.tagCost),
        mrp: str(row.mrp),
        remark: String(row.remark ?? ''),
        karigarName: String(row.karigarName ?? ''),
        karigarOtherWt: str(row.karigarOtherWt),
        karigarNetWt: str(row.karigarNetWt),
        karigarGhtPct: str(row.karigarGhtPct),
        karigarGhtWt: str(row.karigarGhtWt),
        karigarTouch: str(row.karigarTouch),
        karigarWestPct: str(row.karigarWestPct),
        karigarFine: str(row.karigarFine),
        karigarLbrRate: str(row.karigarLbrRate),
        karigarLbrAmt: str(row.karigarLbrAmt),
        karigarOthAmt: str(row.karigarOthAmt),
        rateType: String(row.rateType ?? ''),
        prCode: String(row.prCode ?? ''),
        itType: String(row.itType ?? ''),
        lbrCode: String(row.lbrCode ?? ''),
        designImageId: String(row.designImageId ?? ''),
        empIsu: String(row.empIsu ?? ''),
        fromLcCode: String(row.fromLcCode ?? ''),
        toLcCode: String(row.toLcCode ?? ''),
      }));
      setLines(loaded.length ? loaded : [blank()]);
      setMsg({ kind: 'ok', text: `Loaded ${label} ${view.voucherNo}` });
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function removeVoucher() {
    if (!loadedVchNo || !window.confirm(`Delete ${label} ${loadedVchNo}?`)) return;
    setBusy(true);
    setMsg(null);
    try {
      await del(`${endpoint}/${encodeURIComponent(loadedVchNo)}?${scopeQuery}`);
      newVoucher();
      setMsg({ kind: 'ok', text: `${label} ${loadedVchNo} deleted` });
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  async function submit(event: FormEvent) {
    event.preventDefault();
    setMsg(null);
    const payloadLines = lines.filter((line) => line.itCode.trim()).map(linePayload);
    if (!payloadLines.length) {
      setMsg({ kind: 'err', text: 'enter at least one item line' });
      return;
    }
    if (!transferLcCode.trim()) {
      setMsg({ kind: 'err', text: `enter ${isIn ? 'source' : 'target'} location code` });
      return;
    }
    setBusy(true);
    try {
      const body = {
        coBook: coBook || undefined,
        coYear,
        lcCode,
        vchDate,
        employeeCode: employeeCode || undefined,
        description: description || undefined,
        ...(isIn ? { fromLcCode: transferLcCode } : { toLcCode: transferLcCode }),
        lines: payloadLines,
      };
      const saved = loadedVchNo
        ? await put<any>(`${endpoint}/${encodeURIComponent(loadedVchNo)}`, body)
        : await post<any>(endpoint, body);
      const no = String(saved.vchNo).padStart(5, '0');
      setLoadedVchNo(no);
      setVoucherLookup(no);
      setMsg({
        kind: 'ok',
        text: `${label} ${no} saved · fine ${Number(saved.fine ?? 0).toLocaleString('en-IN')}`,
      });
    } catch (error) {
      setMsg({ kind: 'err', text: errorText(error) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        {label} — {mainBook}
      </h1>
      <p className="muted">
        {isIn
          ? 'Receive stock into the current branch from another location. Posts INWORD detail, positive MAIN_STOCK, signed ledger, and Rojmel rows.'
          : 'Issue stock from the current branch to another location. Posts OUTWORD detail, negative MAIN_STOCK, signed ledger, and Rojmel rows.'}
      </p>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} mainBooks={[mainBook]} />
            </div>
            <div className="field">
              <label>Voucher Date</label>
              <input
                type="date"
                value={vchDate}
                onChange={(event) => setVchDate(event.target.value)}
              />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Current Location</label>
              <input value={lcCode} readOnly />
            </div>
            <div className="field">
              <label>{isIn ? 'From Location' : 'To Location'}</label>
              <input
                value={transferLcCode}
                onChange={(event) => setTransferLcCode(event.target.value)}
                required
              />
            </div>
            <div className="field">
              <label>Employee</label>
              <input
                value={employeeCode}
                onChange={(event) => setEmployeeCode(event.target.value)}
                maxLength={3}
              />
            </div>
            <div className="field" style={{ minWidth: 280 }}>
              <label>Description</label>
              <input value={description} onChange={(event) => setDescription(event.target.value)} />
            </div>
          </div>
          <div className="row" style={{ marginTop: 12 }}>
            <div className="field">
              <label>Voucher No</label>
              <input
                value={voucherLookup}
                onChange={(event) => setVoucherLookup(event.target.value)}
                placeholder="00001"
              />
            </div>
            <button
              type="button"
              className="ghost"
              disabled={busy || !coBook}
              onClick={loadVoucher}
            >
              Load
            </button>
            <button type="button" className="ghost" disabled={busy} onClick={newVoucher}>
              New
            </button>
            <button
              type="button"
              className="danger"
              disabled={busy || !loadedVchNo}
              onClick={removeVoucher}
            >
              Delete
            </button>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar">
            <h2 style={{ margin: 0 }}>Item Lines</h2>
            <span className="spacer" />
            <GridModeToggle
              full={fullGrid}
              setFull={setFullGrid}
              extendedCount={extendedLineFields.length}
              testId={`${direction}-stock-grid-mode`}
            />
          </div>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch%</th>
                <th className="num">West%</th>
                <th className="num">Rate</th>
                <th className="num">Fine</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                <th />
              </tr>
            </thead>
            <tbody>
              {lines.map((line, index) => (
                <tr key={index}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={line.itCode}
                      onChange={(value) => setLine(index, 'itCode', value)}
                      style={{ width: 120 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={line.pcs}
                      onChange={(event) => setLine(index, 'pcs', event.target.value)}
                      style={{ width: 52, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={line.grossWt}
                      onChange={(event) => setLine(index, 'grossWt', event.target.value)}
                      style={{ width: 72, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={line.netWt}
                      onChange={(event) => setLine(index, 'netWt', event.target.value)}
                      style={{ width: 72, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={line.touch}
                      onChange={(event) => setLine(index, 'touch', event.target.value)}
                      style={{ width: 64, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={line.westPct}
                      onChange={(event) => setLine(index, 'westPct', event.target.value)}
                      style={{ width: 64, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={line.rate}
                      onChange={(event) => setLine(index, 'rate', event.target.value)}
                      style={{ width: 80, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">{lineFine(line).toLocaleString('en-IN')}</td>
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedLineFields}
                    line={line}
                    row={index}
                    baseColumns={8}
                    setValue={(row, key, value) => setLine(row, key, value)}
                  />
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setLines((rows) =>
                          rows.length > 1 ? rows.filter((_, row) => row !== index) : [blank()],
                        )
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((rows) => [...rows, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Net {netTotal.toLocaleString('en-IN')} g ·{' '}
              <b>Fine {fineTotal.toLocaleString('en-IN')}</b>
            </span>
            <button ref={submitRef} className="primary" disabled={busy || !coBook}>
              {busy ? 'Saving…' : loadedVchNo ? `Update ${label}` : `Save ${label}`}
            </button>
          </div>
        </div>
      </form>
      {msg && (
        <p role="status" className={msg.kind === 'err' ? 'error' : 'ok'}>
          {msg.text}
        </p>
      )}
    </div>
  );
}
