'use client';

import { useEffect, useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { LookupPicker } from '../../../../components/LookupPicker';
import { PartyBalance } from '../../../../components/PartyBalance';
import { RepairImagePanel } from '../../../../components/RepairImagePanel';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { todayLocal } from '../../../../lib/localDate';
import { openDocument } from '../../../../lib/openDocument';

interface RepairLine {
  /** Saved database serial; draft row positions are never photograph identities. */
  savedSrNo?: number;
  itCode: string;
  itemName: string;
  itmSize: string;
  description: string;
  pcs: string;
  grossWt: string;
  otherWt: string;
  touch: string;
  labourType: string;
  labourRate: string;
  otherAmount: string;
}

interface RepairLineView {
  srNo: number;
  itCode: string;
  itemName: string;
  itmSize?: string;
  description?: string;
  pcs?: number;
  grossWt?: number;
  otherWt?: number;
  netWt: number;
  touch?: number;
  labourType?: string;
  labourRate?: number;
  labourAmount: number;
  otherAmount: number;
  netAmount: number;
}

interface RepairTotals {
  netAmount: number;
  discountAmount: number;
  taxAmount: number;
  totalAmount: number;
  outstandingAmount: number;
}

interface RepairReceiptView {
  voucherNo: string;
  headerVoucherNo: string;
  vchDate: string;
  billNo: string;
  acCode: string;
  acName: string;
  employeeCode: string;
  bankName: string;
  description: string;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  totals: RepairTotals;
  lines: RepairLineView[];
}

interface SaveResult {
  vchNo: number;
  voucherNo: string;
  headerVoucherNo: string;
  created: boolean;
  totals: RepairTotals;
}

const blankLine = (): RepairLine => ({
  itCode: '',
  itemName: '',
  itmSize: '',
  description: '',
  pcs: '1',
  grossWt: '',
  otherWt: '',
  touch: '',
  labourType: 'N',
  labourRate: '',
  otherAmount: '',
});

const n = (value: string | number | undefined): number => Number(value || 0);
const r2 = (value: number): number => Math.round((value + Number.EPSILON) * 100) / 100;
const r3 = (value: number): number => Math.round((value + Number.EPSILON) * 1000) / 1000;
const gridCell = (row: number, column: number) => ({
  'data-grid-row': row,
  'data-grid-column': column,
});

function lineTotals(line: RepairLine) {
  const netWt = r3(n(line.grossWt) - n(line.otherWt));
  let labourAmount = 0;
  const rate = n(line.labourRate);
  switch (line.labourType.toUpperCase()) {
    case 'P':
      labourAmount = Math.round(n(line.pcs) * rate);
      break;
    case 'N':
      labourAmount = Math.round(netWt * rate);
      break;
    case 'K':
      labourAmount = Math.round(netWt * (rate / 1000));
      break;
    default:
      labourAmount = Math.round(n(line.grossWt) * rate);
      break;
  }
  return {
    netWt,
    labourAmount: r2(labourAmount),
    netAmount: r2(labourAmount + n(line.otherAmount)),
  };
}

function text(value: string | number | undefined): string {
  return value == null || Number(value) === 0 ? '' : String(value);
}

export default function RepairReceiptPage() {
  const router = useRouter();
  const { coCode, lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const imageScope = JSON.stringify([coCode, lcCode, coYear, coBook]);
  const [loadedImageScope, setLoadedImageScope] = useState('');
  const requestContext = useRef({ scope: imageScope, epoch: 0 });
  // Invalidate synchronously, including A→B→A before an older request resolves.
  if (requestContext.current.scope !== imageScope)
    requestContext.current = { scope: imageScope, epoch: 0 };
  const beginRequest = () => {
    const context = requestContext.current;
    const epoch = ++context.epoch;
    return () => requestContext.current === context && context.epoch === epoch;
  };
  const [vchDate, setVchDate] = useState(() => todayLocal());
  const [billNo, setBillNo] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [bankName, setBankName] = useState('');
  const [description, setDescription] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [chequeAmount, setChequeAmount] = useState('');
  const [chequeAccount, setChequeAccount] = useState('');
  const [chequeNo, setChequeNo] = useState('');
  const [cardAmount, setCardAmount] = useState('');
  const [cardAccount, setCardAccount] = useState('');
  const [cashAmount, setCashAmount] = useState('');
  const [lines, setLines] = useState<RepairLine[]>([blankLine()]);
  const [activeImageRow, setActiveImageRow] = useState(0);
  const [loadVoucherNo, setLoadVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [result, setResult] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const chequeRef = useRef<HTMLInputElement>(null);
  useEffect(() => {
    setBusy(false);
    setLoadedImageScope('');
  }, [imageScope]);
  useEffect(
    () => () => {
      requestContext.current.epoch += 1;
    },
    [],
  );

  const setLine = (index: number, field: keyof RepairLine, value: string) =>
    setLines((current) =>
      current.map((line, lineIndex) => (lineIndex === index ? { ...line, [field]: value } : line)),
    );

  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: 10,
    onAppendRow: () => setLines((current) => [...current, blankLine()]),
    onRemoveRow: (row) => {
      if (!window.confirm('Remove this repair item row?')) return false;
      setLines((current) =>
        current.length === 1 ? [blankLine()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => chequeRef.current?.focus(),
  });

  const calculated = lines.map(lineTotals);
  const estimate = r2(calculated.reduce((sum, line) => sum + line.netAmount, 0));
  const received = r2(n(chequeAmount) + n(cardAmount) + n(cashAmount));
  const outstanding = estimate === 0 ? 0 : r2(Math.round(estimate) - received);

  const reset = () => {
    requestContext.current.epoch += 1;
    setBusy(false);
    setBillNo('');
    setEmployeeCode('');
    setBankName('');
    setDescription('');
    setAcCode('');
    setAcName('');
    setChequeAmount('');
    setChequeAccount('');
    setChequeNo('');
    setCardAmount('');
    setCardAccount('');
    setCashAmount('');
    setLines([blankLine()]);
    setActiveImageRow(0);
    setLoadVoucherNo('');
    setLoadedVoucherNo('');
    setLoadedImageScope('');
    setResult(null);
    setError('');
  };

  const requestBody = () => ({
    coCode,
    coBook,
    coYear,
    lcCode,
    acCode,
    acName: acName || undefined,
    vchDate,
    billNo: billNo || undefined,
    employeeCode: employeeCode || undefined,
    bankName: bankName || undefined,
    description: description || undefined,
    chequeAmount: n(chequeAmount),
    chequeAccount: chequeAccount || undefined,
    chequeNo: chequeNo || undefined,
    cardAmount: n(cardAmount),
    cardAccount: cardAccount || undefined,
    cashAmount: n(cashAmount),
    lines: lines
      .filter(
        (line) =>
          line.itCode &&
          (n(line.pcs) ||
            n(line.grossWt) ||
            n(line.labourRate) ||
            n(line.otherAmount) ||
            line.description),
      )
      .map((line) => ({
        itCode: line.itCode,
        itmSize: line.itmSize || undefined,
        description: line.description || undefined,
        pcs: n(line.pcs),
        grossWt: n(line.grossWt),
        otherWt: n(line.otherWt),
        touch: n(line.touch),
        labourType: line.labourType || undefined,
        labourRate: n(line.labourRate),
        otherAmount: n(line.otherAmount),
      })),
  });

  function applySavedReceipt(view: RepairReceiptView) {
    setLoadedVoucherNo(view.voucherNo);
    setLoadVoucherNo(view.voucherNo);
    setVchDate(view.vchDate);
    setBillNo(view.billNo);
    setEmployeeCode(view.employeeCode);
    setBankName(view.bankName);
    setDescription(view.description);
    setAcCode(view.acCode);
    setAcName(view.acName);
    setChequeAmount(text(view.chequeAmount));
    setChequeAccount(view.chequeAccount);
    setChequeNo(view.chequeNo);
    setCardAmount(text(view.cardAmount));
    setCardAccount(view.cardAccount);
    setCashAmount(text(view.cashAmount));
    setLines(
      view.lines.length
        ? view.lines.map((line) => ({
            savedSrNo: line.srNo,
            itCode: line.itCode,
            itemName: line.itemName,
            itmSize: line.itmSize ?? '',
            description: line.description ?? '',
            pcs: text(line.pcs),
            grossWt: text(line.grossWt),
            otherWt: text(line.otherWt),
            touch: text(line.touch),
            labourType: line.labourType || 'N',
            labourRate: text(line.labourRate),
            otherAmount: text(line.otherAmount),
          }))
        : [blankLine()],
    );
    setResult({
      vchNo: Number(view.voucherNo),
      voucherNo: view.voucherNo,
      headerVoucherNo: view.headerVoucherNo,
      created: false,
      totals: view.totals,
    });
    setLoadedImageScope(imageScope);
    setActiveImageRow(0);
  }

  async function submit(event: React.FormEvent) {
    event.preventDefault();
    if (loadedVoucherNo && loadedImageScope !== imageScope) {
      setError(
        'Reload this receipt in the selected company, location, year and book before updating.',
      );
      return;
    }
    setError('');
    setBusy(true);
    const current = beginRequest();
    let written: SaveResult | null = null;
    try {
      const saved = loadedVoucherNo
        ? await put<SaveResult>(
            `/repair-receipts/${encodeURIComponent(loadedVoucherNo)}`,
            requestBody(),
          )
        : await post<SaveResult>('/repair-receipts', requestBody());
      if (!current()) return;
      written = saved;
      setResult(saved);
      setLoadedVoucherNo(saved.voucherNo);
      setLoadVoucherNo(saved.voucherNo);
      // The writer can assign fresh serials. Hydrate its saved rows before enabling photographs.
      setLoadedImageScope('');
      const query = new URLSearchParams({ coCode, lcCode, coYear, coBook });
      const view = await get<RepairReceiptView>(
        `/repair-receipts/${encodeURIComponent(saved.voucherNo)}?${query}`,
      );
      if (!current()) return;
      applySavedReceipt(view);
      setResult(saved);
    } catch (caught) {
      if (!current()) return;
      const reason =
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'repair receipt request failed';
      setError(
        written
          ? `Saved repair receipt ${written.voucherNo}; reload is required: ${reason}`
          : reason,
      );
    } finally {
      if (current()) setBusy(false);
    }
  }

  async function loadReceipt() {
    if (!coBook || !loadVoucherNo.trim()) return;
    setError('');
    setBusy(true);
    setLoadedImageScope('');
    const current = beginRequest();
    try {
      const query = new URLSearchParams({ coCode, lcCode, coYear, coBook });
      const view = await get<RepairReceiptView>(
        `/repair-receipts/${encodeURIComponent(loadVoucherNo.trim())}?${query}`,
      );
      if (!current()) return;
      applySavedReceipt(view);
    } catch (caught) {
      if (!current()) return;
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'repair receipt load failed',
      );
    } finally {
      if (current()) setBusy(false);
    }
  }

  async function removeReceipt() {
    if (loadedVoucherNo && loadedImageScope !== imageScope) {
      setError(
        'Reload this receipt in the selected company, location, year and book before deleting.',
      );
      return;
    }
    if (!loadedVoucherNo || !window.confirm(`Delete repair receipt ${loadedVoucherNo}?`)) return;
    setError('');
    setBusy(true);
    const current = beginRequest();
    try {
      await del(`/repair-receipts/${encodeURIComponent(loadedVoucherNo)}`, {
        coCode,
        lcCode,
        coYear,
        coBook,
      });
      if (current()) reset();
    } catch (caught) {
      if (!current()) return;
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'repair receipt delete failed',
      );
    } finally {
      if (current()) setBusy(false);
    }
  }

  return (
    <div>
      <PartyBalance acCode={acCode} />
      <form onSubmit={submit}>
        <VoucherChrome
          title="Repairing Received — Customer Receipt"
          vchNo={loadedVoucherNo || result?.voucherNo || null}
          date={vchDate}
          onDateChange={setVchDate}
          refNo={billNo}
          onRefNoChange={setBillNo}
          employee={employeeCode}
          onEmployeeChange={setEmployeeCode}
          bank={bankName}
          onBankChange={setBankName}
          vchDesc={description}
          onVchDescChange={setDescription}
          saving={busy}
          saveLabel={loadedVoucherNo ? 'Update' : 'Save'}
          onCancel={reset}
          onDelete={loadedVoucherNo ? removeReceipt : undefined}
          onExit={() => router.back()}
          onPrint={
            loadedVoucherNo && loadedImageScope === imageScope
              ? () =>
                  openDocument(
                    `/api/repair-receipts/${encodeURIComponent(loadedVoucherNo)}/print?${new URLSearchParams({ coCode, lcCode, coYear, coBook, format: 'html' })}`,
                  )
              : undefined
          }
        />

        <div className="panel">
          <div className="row" style={{ alignItems: 'flex-end' }}>
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                mainBooks={['CUSTREP RECEIPT']}
                disabled={Boolean(loadedVoucherNo)}
              />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
            <div className="field">
              <label>Load Vch No</label>
              <input
                value={loadVoucherNo}
                onChange={(event) => setLoadVoucherNo(event.target.value)}
                placeholder="00001"
                data-testid="repair-load-voucher"
              />
            </div>
            <button
              type="button"
              className="ghost"
              disabled={!coBook || busy}
              onClick={loadReceipt}
            >
              Load
            </button>
            <div className="field" data-testid="repair-party">
              <label>Party</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={(value) => {
                  setAcCode(value);
                  setAcName('');
                }}
                onPick={(row) => setAcName(String(row.name ?? ''))}
                style={{ width: 150 }}
              />
            </div>
            <div className="field">
              <label>Party Name</label>
              <input
                value={acName}
                readOnly={acCode !== '00050'}
                onChange={(e) => setAcName(e.target.value)}
              />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Repair Items</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Item Name</th>
                <th>Size</th>
                <th>Repairing Desc</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Other Wt</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th>Labour Type</th>
                <th className="num">Labour Rate</th>
                <th className="num">Labour Amt</th>
                <th className="num">Other Amt</th>
                <th className="num">Net Amt</th>
                <th></th>
              </tr>
            </thead>
            <tbody data-testid="repair-items-grid" onKeyDown={handleGridKey}>
              {lines.map((line, index) => {
                const totals = calculated[index]!;
                return (
                  <tr key={index} onFocusCapture={() => setActiveImageRow(index)}>
                    <td {...gridCell(index, 0)}>
                      <LookupPicker
                        entity="items"
                        value={line.itCode}
                        onChange={(value) => {
                          setLine(index, 'itCode', value);
                          setLine(index, 'itemName', '');
                        }}
                        onPick={(row) => setLine(index, 'itemName', String(row.name ?? ''))}
                        style={{ width: 90 }}
                      />
                    </td>
                    <td>
                      <input value={line.itemName} readOnly style={{ width: 150 }} />
                    </td>
                    <td {...gridCell(index, 1)}>
                      <input
                        value={line.itmSize}
                        onChange={(e) => setLine(index, 'itmSize', e.target.value)}
                        style={{ width: 65 }}
                      />
                    </td>
                    <td {...gridCell(index, 2)}>
                      <input
                        value={line.description}
                        onChange={(e) => setLine(index, 'description', e.target.value)}
                        style={{ width: 180 }}
                      />
                    </td>
                    <td className="num" {...gridCell(index, 3)}>
                      <input
                        value={line.pcs}
                        onChange={(e) => setLine(index, 'pcs', e.target.value)}
                        style={{ width: 45, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num" {...gridCell(index, 4)}>
                      <input
                        value={line.grossWt}
                        onChange={(e) => setLine(index, 'grossWt', e.target.value)}
                        style={{ width: 70, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num" {...gridCell(index, 5)}>
                      <input
                        value={line.otherWt}
                        onChange={(e) => setLine(index, 'otherWt', e.target.value)}
                        style={{ width: 70, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num" data-testid={`repair-net-${index}`}>
                      {totals.netWt.toFixed(3)}
                    </td>
                    <td className="num" {...gridCell(index, 6)}>
                      <input
                        value={line.touch}
                        onChange={(e) => setLine(index, 'touch', e.target.value)}
                        style={{ width: 60, textAlign: 'right' }}
                      />
                    </td>
                    <td {...gridCell(index, 7)}>
                      <select
                        value={line.labourType}
                        onChange={(e) => setLine(index, 'labourType', e.target.value)}
                        style={{ width: 70 }}
                      >
                        <option value="P">Piece</option>
                        <option value="N">Net Wt</option>
                        <option value="K">Per 1000</option>
                        <option value="G">Gross</option>
                      </select>
                    </td>
                    <td className="num" {...gridCell(index, 8)}>
                      <input
                        value={line.labourRate}
                        onChange={(e) => setLine(index, 'labourRate', e.target.value)}
                        style={{ width: 70, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">{totals.labourAmount.toFixed(2)}</td>
                    <td className="num" {...gridCell(index, 9)}>
                      <input
                        value={line.otherAmount}
                        onChange={(e) => setLine(index, 'otherAmount', e.target.value)}
                        style={{ width: 70, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">{totals.netAmount.toFixed(2)}</td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() =>
                          setLines((current) =>
                            current.length === 1
                              ? [blankLine()]
                              : current.filter((_, lineIndex) => lineIndex !== index),
                          )
                        }
                        aria-label={`Remove repair row ${index + 1}`}
                      >
                        ×
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((current) => [...current, blankLine()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span>
              Estimate{' '}
              <b data-testid="repair-estimate">₹{Math.round(estimate).toLocaleString('en-IN')}</b>
            </span>
          </div>
        </div>

        <div className="panel">
          <h2>Settlement Received</h2>
          <div className="row">
            <div className="field">
              <label>Cheque Amount</label>
              <input
                ref={chequeRef}
                value={chequeAmount}
                onChange={(e) => setChequeAmount(e.target.value)}
                data-testid="repair-cheque"
              />
            </div>
            <div className="field">
              <label>Cheque / Bank Account</label>
              <LookupPicker
                entity="accounts"
                value={chequeAccount}
                onChange={setChequeAccount}
                style={{ width: 150 }}
              />
            </div>
            <div className="field">
              <label>Cheque No</label>
              <input value={chequeNo} onChange={(e) => setChequeNo(e.target.value)} />
            </div>
            <div className="field">
              <label>Card Amount</label>
              <input value={cardAmount} onChange={(e) => setCardAmount(e.target.value)} />
            </div>
            <div className="field">
              <label>Card Account</label>
              <LookupPicker
                entity="accounts"
                value={cardAccount}
                onChange={setCardAccount}
                style={{ width: 150 }}
              />
            </div>
            <div className="field">
              <label>Cash Amount</label>
              <input
                value={cashAmount}
                onChange={(e) => setCashAmount(e.target.value)}
                data-testid="repair-cash"
              />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span>Received ₹{received.toLocaleString('en-IN')}</span>
            <span className="spacer" />
            <strong data-testid="repair-outstanding">
              Outstanding ₹{outstanding.toLocaleString('en-IN')}
            </strong>
          </div>
        </div>
      </form>

      <RepairImagePanel
        imageBook={coBook}
        imageYear={coYear}
        disabled={busy || loadedImageScope !== imageScope}
        vchNo={loadedVoucherNo || result?.voucherNo || ''}
        srNo={lines[Math.min(activeImageRow, Math.max(lines.length - 1, 0))]?.savedSrNo ?? 0}
        testId="repair-image"
      />

      {error && <div className="msg err">{error}</div>}
      {result && (
        <div className="msg ok" data-testid="repair-saved">
          Saved repair receipt {result.voucherNo} · header {result.headerVoucherNo} · outstanding ₹
          {result.totals.outstandingAmount.toLocaleString('en-IN')}
        </div>
      )}
      <p className="muted" style={{ marginTop: 8 }}>
        This batch covers Customer Repair Receipt only. Karigar issue/receipt and customer delivery
        remain separate workflow stages.
      </p>
    </div>
  );
}
