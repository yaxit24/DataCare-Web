'use client';

import { useMemo, useState } from 'react';
import { useRouter } from 'next/navigation';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { LookupPicker } from '../../../../components/LookupPicker';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

type OutLine = {
  itCode: string;
  itemName: string;
  itemType: string;
  pieces: string;
  grossWt: string;
  otherWt: string;
  touch: string;
  lotNo: string;
};

type ResultLine = {
  recoveredFine: string;
  itCode: string;
  itemName: string;
  itemType: string;
  pieces: string;
  grossWt: string;
  touch: string;
  conPct: string;
  conWt: string;
  conItCode: string;
  finePct: string;
  fineAdd: string;
  returnWt: string;
  returnItCode: string;
  recoveredGrossWt: string;
  lotNo: string;
};

type SaveResult = {
  voucherNo: string;
  hiddenVoucherNo: string;
  created: boolean;
  outLines: number;
  resultLines: number;
  stockRows: number;
};

type VoucherView = {
  voucherNo: string;
  hiddenVoucherNo: string;
  vchDate: string;
  acCode: string;
  acName: string;
  employeeCode: string;
  description: string;
  lotNo: string;
  mainUser: string;
  outLines: Array<Record<string, string | number>>;
  resultLines: Array<Record<string, string | number>>;
};

const blankOut = (): OutLine => ({
  itCode: '',
  itemName: '',
  itemType: 'G',
  pieces: '',
  grossWt: '',
  otherWt: '',
  touch: '',
  lotNo: '',
});
const blankResult = (): ResultLine => ({
  recoveredFine: '',
  itCode: '',
  itemName: '',
  itemType: 'G',
  pieces: '',
  grossWt: '',
  touch: '',
  conPct: '',
  conWt: '',
  conItCode: '',
  finePct: '',
  fineAdd: '',
  returnWt: '',
  returnItCode: '',
  recoveredGrossWt: '',
  lotNo: '',
});
const num = (value: string | number | undefined): number => Number(value || 0);
const r3 = (value: number): number => Math.round((value + Number.EPSILON) * 1000) / 1000;
const r2 = (value: number): number => Math.round((value + Number.EPSILON) * 100) / 100;
const display = (value: number, digits = 3): string =>
  Number.isFinite(value) ? value.toFixed(digits) : (0).toFixed(digits);

function inputValue(row: Record<string, string | number>, key: string): string {
  const value = row[key];
  return value == null ? '' : String(value);
}

export default function MeltingPage() {
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [voucherSearch, setVoucherSearch] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [description, setDescription] = useState('');
  const [lotNo, setLotNo] = useState('');
  const [outLines, setOutLines] = useState<OutLine[]>([blankOut()]);
  // P1-5: desktop grids are keyboard-first — arrows move, Enter advances and appends at the end,
  // Ctrl/Cmd+D removes a row (TR_SALE.cs:12250-12320).
  const handleOutGridKey = useGridKeyboard({
    rowCount: outLines.length,
    onAppendRow: () => setOutLines((current) => [...current, blankOut()]),
    onRemoveRow: (row) => {
      setOutLines((current) =>
        current.length === 1 ? [blankOut()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [resultLines, setResultLines] = useState<ResultLine[]>([blankResult()]);
  // P1-5: desktop grids are keyboard-first — arrows move, Enter advances and appends at the end,
  // Ctrl/Cmd+D removes a row (TR_SALE.cs:12250-12320).
  const handleResultGridKey = useGridKeyboard({
    rowCount: resultLines.length,
    onAppendRow: () => setResultLines((current) => [...current, blankResult()]),
    onRemoveRow: (row) => {
      setResultLines((current) =>
        current.length === 1 ? [blankResult()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [saved, setSaved] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  // P3: a melt loses metal. The desktop records the loss percentage on the voucher and the
  // recovered fine per result line; the screen could send neither.
  const [lossPct, setLossPct] = useState('');

  const outComputed = useMemo(
    () =>
      outLines.map((row) => {
        const grossWt = num(row.grossWt);
        const otherWt = num(row.otherWt);
        const netWt = r3(grossWt - otherWt);
        const touch = num(row.touch);
        return {
          netWt,
          partyFine: r3(netWt && touch ? (netWt * touch) / 100 : netWt),
        };
      }),
    [outLines],
  );
  const outTotals = useMemo(() => {
    const grossWt = r3(outLines.reduce((sum, row) => sum + num(row.grossWt), 0));
    const netWt = r3(outComputed.reduce((sum, row) => sum + row.netWt, 0));
    const partyFine = r3(outComputed.reduce((sum, row) => sum + row.partyFine, 0));
    return {
      grossWt,
      netWt,
      partyFine,
      averageTouch: netWt ? r2((partyFine / netWt) * 100) : 0,
    };
  }, [outLines, outComputed]);
  const resultComputed = useMemo(
    () =>
      resultLines.map((row, index) => {
        const grossWt = num(row.grossWt);
        const touch = num(row.touch);
        const conPct = num(row.conPct);
        const partyFine = r3(touch ? (grossWt * touch) / 100 : grossWt);
        let conWt = num(row.conWt);
        let finePct = num(row.finePct);
        let fineAdd = num(row.fineAdd);
        let meltWt = grossWt;
        if (index === 0 && outTotals.grossWt !== 0) {
          if (conPct > outTotals.averageTouch) {
            finePct ||= 100;
            fineAdd =
              finePct > conPct
                ? r3((grossWt * (conPct - outTotals.averageTouch)) / (finePct - conPct))
                : 0;
            conWt = 0;
            meltWt = r3(grossWt + fineAdd);
          } else {
            fineAdd = 0;
            finePct = 0;
            if (partyFine && conPct) {
              conWt = r3((partyFine / conPct) * 100 - partyFine);
              meltWt = r3(partyFine + conWt);
            } else meltWt = r3(grossWt + conWt);
          }
        }
        const returnWt = num(row.returnWt);
        const recoveredGrossWt =
          row.recoveredGrossWt === '' ? r3(meltWt - returnWt) : num(row.recoveredGrossWt);
        return {
          partyFine,
          conWt,
          finePct,
          fineAdd,
          meltWt,
          returnWt,
          recoveredGrossWt,
          lossWt: r3(meltWt - returnWt - recoveredGrossWt),
        };
      }),
    [resultLines, outTotals],
  );

  const message = (caught: unknown, fallback: string): string =>
    caught instanceof ApiError
      ? caught.body?.message || caught.body?.detail || caught.body?.error || caught.message
      : fallback;
  const setOut = (index: number, key: keyof OutLine, value: string) =>
    setOutLines((rows) => rows.map((row, i) => (i === index ? { ...row, [key]: value } : row)));
  const setResult = (index: number, key: keyof ResultLine, value: string) =>
    setResultLines((rows) => rows.map((row, i) => (i === index ? { ...row, [key]: value } : row)));

  function reset() {
    setVchDate(new Date().toISOString().slice(0, 10));
    setVoucherSearch('');
    setLoadedVoucherNo('');
    setAcCode('');
    setAcName('');
    setEmployeeCode('');
    setDescription('');
    setLotNo('');
    setOutLines([blankOut()]);
    setResultLines([blankResult()]);
    setSaved(null);
    setError('');
  }

  function payload() {
    return {
      coBook,
      coYear,
      lcCode,
      vchDate,
      acCode: acCode || undefined,
      acName: acName || undefined,
      employeeCode: employeeCode || undefined,
      description: description || undefined,
      lotNo: lotNo || undefined,
      outLines: outLines
        .filter((row) => row.itCode.trim() || num(row.grossWt) !== 0)
        .map((row) => ({
          ...row,
          pieces: num(row.pieces),
          grossWt: num(row.grossWt),
          otherWt: num(row.otherWt),
          touch: num(row.touch),
        })),
      resultLines: resultLines
        .filter((row) => row.itCode.trim() || num(row.grossWt) !== 0)
        .map((row) => ({
          ...row,
          pieces: num(row.pieces),
          grossWt: num(row.grossWt),
          touch: num(row.touch),
          conPct: num(row.conPct),
          conWt: num(row.conWt),
          finePct: num(row.finePct),
          fineAdd: num(row.fineAdd),
          returnWt: num(row.returnWt),
          recoveredGrossWt: row.recoveredGrossWt === '' ? undefined : num(row.recoveredGrossWt),
        })),
    };
  }

  async function save() {
    if (!coBook) return setError('Select the configured MLT PRO book.');
    setBusy(true);
    setError('');
    try {
      const result = loadedVoucherNo
        ? await put<SaveResult>(`/melting/${encodeURIComponent(loadedVoucherNo)}`, payload())
        : await post<SaveResult>('/melting', payload());
      setSaved(result);
      setLoadedVoucherNo(result.voucherNo);
      setVoucherSearch(result.voucherNo);
    } catch (caught) {
      setError(message(caught, 'melting save failed'));
    } finally {
      setBusy(false);
    }
  }

  async function load() {
    if (!coBook || !voucherSearch.trim()) return setError('Select a book and enter a voucher.');
    setBusy(true);
    setError('');
    try {
      const view = await get<VoucherView>(
        `/melting/${encodeURIComponent(voucherSearch.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVoucherNo(view.voucherNo);
      setVoucherSearch(view.voucherNo);
      setVchDate(view.vchDate);
      setAcCode(view.acCode);
      setAcName(view.acName);
      setEmployeeCode(view.employeeCode);
      setDescription(view.description);
      setLotNo(view.lotNo);
      setOutLines(
        view.outLines.map((row) => ({
          itCode: inputValue(row, 'itCode'),
          itemName: inputValue(row, 'itemName'),
          itemType: inputValue(row, 'itemType') || 'G',
          pieces: inputValue(row, 'pieces'),
          grossWt: inputValue(row, 'grossWt'),
          otherWt: inputValue(row, 'otherWt'),
          touch: inputValue(row, 'touch'),
          lotNo: inputValue(row, 'lotNo'),
        })),
      );
      setResultLines(
        view.resultLines.map((row) => ({
          // P3: recovered fine must be restored on load, else a reopen-and-save blanks it.
          recoveredFine: inputValue(row, 'recoveredFine'),
          itCode: inputValue(row, 'itCode'),
          itemName: inputValue(row, 'itemName'),
          itemType: inputValue(row, 'itemType') || 'G',
          pieces: inputValue(row, 'pieces'),
          grossWt: inputValue(row, 'grossWt'),
          touch: inputValue(row, 'touch'),
          conPct: inputValue(row, 'conPct'),
          conWt: inputValue(row, 'conWt'),
          conItCode: inputValue(row, 'conItCode'),
          finePct: inputValue(row, 'finePct'),
          fineAdd: inputValue(row, 'fineAdd'),
          returnWt: inputValue(row, 'returnWt'),
          returnItCode: inputValue(row, 'returnItCode'),
          recoveredGrossWt: inputValue(row, 'recoveredGrossWt'),
          lotNo: inputValue(row, 'lotNo'),
        })),
      );
      setSaved({
        voucherNo: view.voucherNo,
        hiddenVoucherNo: view.hiddenVoucherNo,
        created: false,
        outLines: view.outLines.length,
        resultLines: view.resultLines.length,
        stockRows: 0,
      });
    } catch (caught) {
      setError(message(caught, 'melting load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete melting voucher ${loadedVoucherNo}?`)) return;
    setBusy(true);
    setError('');
    try {
      await del(`/melting/${encodeURIComponent(loadedVoucherNo)}`, { coBook, coYear, lcCode });
      reset();
    } catch (caught) {
      setError(message(caught, 'melting delete failed'));
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <FormKeyHints actions={formKeys} />
      <h1>Melting Process — MLT PRO</h1>
      <div className="panel">
        <div className="row">
          <div className="field">
            <label>Configured book</label>
            <BookSelect
              value={coBook}
              onChange={setCoBook}
              mainBooks={['MLT PRO']}
              disabled={busy}
            />
          </div>
          <div className="field">
            <label>Voucher date</label>
            <input
              aria-label="Voucher date"
              type="date"
              value={vchDate}
              onChange={(e) => setVchDate(e.target.value)}
            />
          </div>
          <div className="field">
            <label>Voucher no.</label>
            <div className="row" style={{ gap: 6 }}>
              <input
                aria-label="Voucher no."
                value={voucherSearch}
                onChange={(e) => setVoucherSearch(e.target.value)}
              />
              <button type="button" onClick={load} disabled={busy}>
                Load
              </button>
            </div>
          </div>
          <div className="field">
            <label>Employee</label>
            <input
              aria-label="Employee"
              value={employeeCode}
              onChange={(e) => setEmployeeCode(e.target.value)}
            />
          </div>
        </div>
        <div className="row">
          <div className="field">
            <label>Party / transfer account</label>
            <input
              aria-label="Party account"
              value={acCode}
              onChange={(e) => setAcCode(e.target.value)}
            />
          </div>
          <div className="field">
            <label>Party name</label>
            <input
              aria-label="Party name"
              value={acName}
              onChange={(e) => setAcName(e.target.value)}
            />
          </div>
          <div className="field">
            <label>Lot no.</label>
            <input aria-label="Lot no." value={lotNo} onChange={(e) => setLotNo(e.target.value)} />
          </div>
          <div className="field" style={{ flex: 2 }}>
            <label>Remark</label>
            <input
              aria-label="Remark"
              value={description}
              onChange={(e) => setDescription(e.target.value)}
            />
          </div>
        </div>
      </div>

      <div className="panel" style={{ overflowX: 'auto' }}>
        <h2>Material Out</h2>
        <table className="grid" data-testid="melting-out-grid" onKeyDown={handleOutGridKey}>
          <thead>
            <tr>
              <th>Sr</th>
              <th>Item</th>
              <th>Item name</th>
              <th>Type</th>
              <th>Pcs</th>
              <th>Gross wt</th>
              <th>Other wt</th>
              <th>Net wt</th>
              <th>Touch</th>
              <th>Fine</th>
              <th>Lot</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {outLines.map((row, index) => (
              <tr key={index} data-melting-out-row={index}>
                <td>{index + 1}</td>
                <td>
                  <LookupPicker
                    entity="items"
                    ariaLabel={`Material itCode ${index + 1}`}
                    value={row.itCode}
                    onChange={(value) => setOut(index, 'itCode', value)}
                    onPick={(item) => {
                      setOut(index, 'itemName', String(item.name ?? ''));
                      setOut(index, 'itemType', String(item.IT_TYPE ?? ''));
                    }}
                  />
                </td>
                <td>
                  <input
                    aria-label={`Material itemName ${index + 1}`}
                    value={row.itemName}
                    readOnly
                  />
                </td>
                <td>
                  <input
                    aria-label={`Material itemType ${index + 1}`}
                    value={row.itemType}
                    readOnly
                  />
                </td>
                {(['pieces', 'grossWt', 'otherWt'] as const).map((key) => (
                  <td key={key}>
                    <input
                      aria-label={`Material ${key} ${index + 1}`}
                      value={row[key]}
                      onChange={(e) => setOut(index, key, e.target.value)}
                    />
                  </td>
                ))}
                <td className="num" data-testid={`melting-out-net-${index}`}>
                  {display(outComputed[index]!.netWt)}
                </td>
                <td>
                  <input
                    aria-label={`Material touch ${index + 1}`}
                    value={row.touch}
                    onChange={(e) => setOut(index, 'touch', e.target.value)}
                  />
                </td>
                <td className="num" data-testid={`melting-out-fine-${index}`}>
                  {display(outComputed[index]!.partyFine)}
                </td>
                <td>
                  <input
                    aria-label={`Material lot ${index + 1}`}
                    value={row.lotNo}
                    onChange={(e) => setOut(index, 'lotNo', e.target.value)}
                  />
                </td>
                <td>
                  <button
                    type="button"
                    className="danger"
                    aria-label={`Remove material ${index + 1}`}
                    onClick={() => setOutLines((rows) => rows.filter((_, i) => i !== index))}
                  >
                    ×
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
          <tfoot>
            <tr>
              <th colSpan={5}>Totals / average</th>
              <th>{display(outTotals.grossWt)}</th>
              <th />
              <th>{display(outTotals.netWt)}</th>
              <th>{display(outTotals.averageTouch, 2)}</th>
              <th>{display(outTotals.partyFine)}</th>
              <th colSpan={2} />
            </tr>
          </tfoot>
        </table>
        <button
          type="button"
          className="ghost"
          onClick={() => setOutLines((rows) => [...rows, blankOut()])}
        >
          + Material row
        </button>
      </div>

      <div className="panel" style={{ overflowX: 'auto' }}>
        <h2>Melting Result</h2>
        <table className="grid" data-testid="melting-result-grid" onKeyDown={handleResultGridKey}>
          <thead>
            <tr>
              <th>Sr</th>
              <th>Item</th>
              <th>Item name</th>
              <th>Type</th>
              <th>Pcs</th>
              <th>Gross wt</th>
              <th>Touch</th>
              <th>Fine</th>
              <th>Con %</th>
              <th>Con wt</th>
              <th>Con item</th>
              <th>Fine %</th>
              <th>Add fine</th>
              <th>Melt wt</th>
              <th>Return wt</th>
              <th>Return item</th>
              <th>Recovered wt</th>
              <th>Loss wt</th>
              <th>Lot</th>
              <th />
            </tr>
          </thead>
          <tbody>
            {resultLines.map((row, index) => {
              const computed = resultComputed[index]!;
              return (
                <tr key={index} data-melting-result-row={index}>
                  <td>{index + 1}</td>
                  <td>
                    <LookupPicker
                      entity="items"
                      ariaLabel={`Result itCode ${index + 1}`}
                      value={row.itCode}
                      onChange={(value) => setResult(index, 'itCode', value)}
                      onPick={(item) => {
                        setResult(index, 'itemName', String(item.name ?? ''));
                        setResult(index, 'itemType', String(item.IT_TYPE ?? ''));
                      }}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`Result itemName ${index + 1}`}
                      value={row.itemName}
                      readOnly
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`Result itemType ${index + 1}`}
                      value={row.itemType}
                      readOnly
                    />
                  </td>
                  {(['pieces', 'grossWt', 'touch'] as const).map((key) => (
                    <td key={key}>
                      <input
                        aria-label={`Result ${key} ${index + 1}`}
                        value={row[key]}
                        onChange={(e) => setResult(index, key, e.target.value)}
                      />
                    </td>
                  ))}
                  <td className="num">{display(computed.partyFine)}</td>
                  <td>
                    <input
                      aria-label={`Result conversion percent ${index + 1}`}
                      value={row.conPct}
                      onChange={(e) => setResult(index, 'conPct', e.target.value)}
                    />
                  </td>
                  <td className="num">{display(computed.conWt)}</td>
                  <td>
                    <LookupPicker
                      entity="items"
                      ariaLabel={`Result conversion item ${index + 1}`}
                      value={row.conItCode}
                      onChange={(value) => setResult(index, 'conItCode', value)}
                    />
                  </td>
                  <td className="num">{display(computed.finePct, 2)}</td>
                  <td className="num">{display(computed.fineAdd)}</td>
                  <td className="num" data-testid={`melting-result-melt-${index}`}>
                    {display(computed.meltWt)}
                  </td>
                  <td>
                    <input
                      aria-label={`Result return weight ${index + 1}`}
                      value={row.returnWt}
                      onChange={(e) => setResult(index, 'returnWt', e.target.value)}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="items"
                      ariaLabel={`Result return item ${index + 1}`}
                      value={row.returnItCode}
                      onChange={(value) => setResult(index, 'returnItCode', value)}
                    />
                  </td>
                  <td>
                    <input
                      aria-label={`Result recovered weight ${index + 1}`}
                      value={row.recoveredGrossWt}
                      placeholder={display(computed.recoveredGrossWt)}
                      onChange={(e) => setResult(index, 'recoveredGrossWt', e.target.value)}
                    />
                  </td>
                  <td className="num" data-testid={`melting-result-loss-${index}`}>
                    {display(computed.lossWt)}
                  </td>
                  <td>
                    <input
                      aria-label={`Result lot ${index + 1}`}
                      value={row.lotNo}
                      onChange={(e) => setResult(index, 'lotNo', e.target.value)}
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      aria-label={`Remove result ${index + 1}`}
                      onClick={() => setResultLines((rows) => rows.filter((_, i) => i !== index))}
                    >
                      ×
                    </button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </table>
        <button
          type="button"
          className="ghost"
          onClick={() => setResultLines((rows) => [...rows, blankResult()])}
        >
          + Result row
        </button>
      </div>

      <div className="toolbar">
        <button type="button" className="ghost" onClick={reset} disabled={busy}>
          New
        </button>
        <span className="spacer" />
        {loadedVoucherNo && (
          <button type="button" className="danger" onClick={remove} disabled={busy}>
            Delete
          </button>
        )}
        <button type="button" className="primary" onClick={save} disabled={busy}>
          {busy ? 'Working…' : loadedVoucherNo ? 'Update' : 'Save'}
        </button>
      </div>
      {error && <div className="msg err">{error}</div>}
      {saved && (
        <div className="msg ok" data-testid="melting-saved">
          Saved melting voucher {saved.voucherNo} · hidden {saved.hiddenVoucherNo} ·{' '}
          {saved.stockRows} stock projection rows
        </div>
      )}
    </div>
  );
}
