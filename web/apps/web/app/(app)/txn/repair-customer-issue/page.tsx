'use client';

import { useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { LookupPicker, type LookupRow } from '../../../../components/LookupPicker';
import { PartyBalance } from '../../../../components/PartyBalance';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { todayLocal } from '../../../../lib/localDate';
import { openDocument } from '../../../../lib/openDocument';

interface IssueLine {
  code: string;
  name: string;
  coYear: string;
  coBook: string;
  voucherNo: string;
  srNo: number;
  headerVoucherNo: string;
  vchDate: string;
  customerCode: string;
  customerName: string;
  karigarReceiptNo: string;
  karigarReceiptSrNo: number;
  karigarCode: string;
  karigarName: string;
  itCode: string;
  itemName: string;
  itType: string;
  rateType: string;
  description: string;
  itmSize: string;
  tagNo: string;
  vchSrNo: number;
  pieces: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  touch: number;
  wastagePct: number;
  fineWt: number;
  addWt: number;
  lessWt: number;
  lessTouch: number;
  lessFine: number;
  rate: number;
  labourAmount: number;
  otherAmount: number;
  labourType: string;
  labourRate: number;
  itemAmount: number;
  netAmount: number;
  issueSrNo?: number;
}

interface IssueTotals {
  netAmount: number;
  discountAmount: number;
  taxAmount: number;
  totalAmount: number;
  outstandingAmount: number;
}

interface RepairIssueView {
  voucherNo: string;
  headerVoucherNo: string;
  vchDate: string;
  billNo: string;
  acCode: string;
  acName: string;
  employeeCode: string;
  bankName: string;
  description: string;
  discountPct: number;
  taxCode: string;
  taxPct: number;
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  kasarAmount: number;
  totals: IssueTotals;
  lines: IssueLine[];
}

interface SaveResult {
  vchNo: number;
  voucherNo: string;
  headerVoucherNo: string;
  created: boolean;
  totals: IssueTotals;
}

const blankLine = (): IssueLine => ({
  code: '',
  name: '',
  coYear: '',
  coBook: '',
  voucherNo: '',
  srNo: 0,
  headerVoucherNo: '',
  vchDate: '',
  customerCode: '',
  customerName: '',
  karigarReceiptNo: '',
  karigarReceiptSrNo: 0,
  karigarCode: '',
  karigarName: '',
  itCode: '',
  itemName: '',
  itType: '',
  rateType: '',
  description: '',
  itmSize: '',
  tagNo: '',
  vchSrNo: 0,
  pieces: 0,
  grossWt: 0,
  otherWt: 0,
  netWt: 0,
  touch: 0,
  wastagePct: 0,
  fineWt: 0,
  addWt: 0,
  lessWt: 0,
  lessTouch: 0,
  lessFine: 0,
  rate: 0,
  labourAmount: 0,
  otherAmount: 0,
  labourType: '',
  labourRate: 0,
  itemAmount: 0,
  netAmount: 0,
});

const n = (value: string | number | undefined): number => Number(value || 0);
const text = (value: string | number | undefined): string =>
  value == null || Number(value) === 0 ? '' : String(value);
const gridCell = (row: number, column: number) => ({
  'data-grid-row': row,
  'data-grid-column': column,
});

function pickedSource(row: LookupRow): IssueLine {
  return {
    ...blankLine(),
    code: String(row.code ?? ''),
    name: String(row.name ?? ''),
    coYear: String(row.coYear ?? ''),
    coBook: String(row.coBook ?? ''),
    voucherNo: String(row.voucherNo ?? ''),
    srNo: Number(row.srNo ?? 0),
    headerVoucherNo: String(row.headerVoucherNo ?? ''),
    vchDate: String(row.vchDate ?? ''),
    customerCode: String(row.customerCode ?? ''),
    customerName: String(row.customerName ?? ''),
    karigarReceiptNo: String(row.karigarReceiptNo ?? ''),
    karigarReceiptSrNo: Number(row.karigarReceiptSrNo ?? 0),
    karigarCode: String(row.karigarCode ?? ''),
    karigarName: String(row.karigarName ?? ''),
    itCode: String(row.itCode ?? ''),
    itemName: String(row.itemName ?? ''),
    itType: String(row.itType ?? ''),
    rateType: String(row.rateType ?? ''),
    description: String(row.description ?? ''),
    itmSize: String(row.itmSize ?? ''),
    tagNo: String(row.tagNo ?? ''),
    vchSrNo: Number(row.vchSrNo ?? 0),
    pieces: Number(row.pieces ?? 0),
    grossWt: Number(row.grossWt ?? 0),
    otherWt: Number(row.otherWt ?? 0),
    netWt: Number(row.netWt ?? 0),
    touch: Number(row.touch ?? 0),
    wastagePct: Number(row.wastagePct ?? 0),
    fineWt: Number(row.fineWt ?? 0),
    addWt: Number(row.addWt ?? 0),
    lessWt: Number(row.lessWt ?? 0),
    lessTouch: Number(row.lessTouch ?? 0),
    lessFine: Number(row.lessFine ?? 0),
    rate: Number(row.rate ?? 0),
    labourAmount: Number(row.labourAmount ?? 0),
    otherAmount: Number(row.otherAmount ?? 0),
  };
}

/** Desktop CommPassTotal for CUSTREP ISSUE: the item amount prices ADD_WT, not the fine weight. */
function lineFine(line: IssueLine): number {
  const touch = n(line.touch) + n(line.wastagePct);
  return touch === 0 ? n(line.addWt) : (n(line.addWt) * touch) / 100;
}

function lineItemAmount(line: IssueLine): number {
  const rate = n(line.rate);
  if (rate === 0 || lineFine(line) + n(line.pieces) === 0) return 0;
  switch (line.rateType.toUpperCase()) {
    case 'P':
      return Math.round(n(line.pieces) * rate);
    case '1':
      return Math.round((n(line.addWt) * rate) / 10);
    case 'K':
      return Math.round((n(line.addWt) * rate) / 1000);
    default:
      return Math.round(n(line.addWt) * rate);
  }
}

function lineLabourAmount(line: IssueLine): number {
  const labourRate = n(line.labourRate);
  if (labourRate === 0) return n(line.labourAmount);
  const netWt = n(line.grossWt) - n(line.otherWt);
  switch (line.labourType.toUpperCase()) {
    case 'P':
      return Math.round(n(line.pieces) * labourRate);
    case 'N':
      return Math.round((netWt + n(line.lessWt)) * labourRate);
    case 'K':
      return Math.round(((netWt + n(line.lessWt)) * labourRate) / 1000);
    default:
      return Math.round(n(line.grossWt) * labourRate);
  }
}

const lineNetAmount = (line: IssueLine): number =>
  lineItemAmount(line) + lineLabourAmount(line) + n(line.otherAmount);

export default function RepairCustomerIssuePage() {
  const router = useRouter();
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => todayLocal());
  const [billNo, setBillNo] = useState('');
  const [employeeCode, setEmployeeCode] = useState('');
  const [bankName, setBankName] = useState('');
  const [description, setDescription] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [discountPct, setDiscountPct] = useState('');
  const [taxCode, setTaxCode] = useState('');
  const [chequeAmount, setChequeAmount] = useState('');
  const [chequeAccount, setChequeAccount] = useState('');
  const [chequeNo, setChequeNo] = useState('');
  const [cardAmount, setCardAmount] = useState('');
  const [cardAccount, setCardAccount] = useState('');
  const [cashAmount, setCashAmount] = useState('');
  const [kasarAmount, setKasarAmount] = useState('');
  const [lines, setLines] = useState<IssueLine[]>([blankLine()]);
  const [loadVoucherNo, setLoadVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [result, setResult] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const chequeRef = useRef<HTMLInputElement>(null);

  const setLine = (index: number, value: IssueLine) =>
    setLines((current) => current.map((line, lineIndex) => (lineIndex === index ? value : line)));
  const patchLine = (index: number, patch: Partial<IssueLine>) =>
    setLines((current) =>
      current.map((line, lineIndex) => (lineIndex === index ? { ...line, ...patch } : line)),
    );

  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: 6,
    onAppendRow: () => setLines((current) => [...current, blankLine()]),
    onRemoveRow: (row) => {
      if (!window.confirm('Remove this customer repair delivery row?')) return false;
      setLines((current) =>
        current.length === 1 ? [blankLine()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => chequeRef.current?.focus(),
  });

  const selected = lines.filter(
    (line) => line.coYear && line.coBook && line.voucherNo && line.srNo,
  );
  const pieces = selected.reduce((sum, line) => sum + n(line.pieces), 0);
  const gross = selected.reduce((sum, line) => sum + n(line.grossWt), 0);
  const fine = selected.reduce((sum, line) => sum + lineFine(line), 0);
  const detailNet = selected.reduce((sum, line) => sum + lineNetAmount(line), 0);
  const received = n(chequeAmount) + n(cardAmount) + n(cashAmount) + n(kasarAmount);

  const reset = () => {
    setBillNo('');
    setEmployeeCode('');
    setBankName('');
    setDescription('');
    setAcCode('');
    setAcName('');
    setDiscountPct('');
    setTaxCode('');
    setChequeAmount('');
    setChequeAccount('');
    setChequeNo('');
    setCardAmount('');
    setCardAccount('');
    setCashAmount('');
    setKasarAmount('');
    setLines([blankLine()]);
    setLoadVoucherNo('');
    setLoadedVoucherNo('');
    setResult(null);
    setError('');
  };

  const requestBody = () => ({
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
    discountPct: n(discountPct),
    taxCode: taxCode || undefined,
    chequeAmount: n(chequeAmount),
    chequeAccount: chequeAccount || undefined,
    chequeNo: chequeNo || undefined,
    cardAmount: n(cardAmount),
    cardAccount: cardAccount || undefined,
    cashAmount: n(cashAmount),
    kasarAmount: n(kasarAmount),
    lines: selected.map((line) => ({
      coYear: line.coYear,
      coBook: line.coBook,
      voucherNo: line.voucherNo,
      srNo: line.srNo,
      description: line.description,
      itmSize: line.itmSize,
      pcs: n(line.pieces),
      grossWt: n(line.grossWt),
      otherWt: n(line.otherWt),
      addWt: n(line.addWt),
      lessWt: n(line.lessWt),
      lessTouch: n(line.lessTouch),
      touch: n(line.touch),
      wastagePct: n(line.wastagePct),
      rate: n(line.rate),
      labourType: line.labourType || undefined,
      labourRate: n(line.labourRate),
      labourAmount: n(line.labourAmount),
      otherAmount: n(line.otherAmount),
    })),
  });

  async function submit(event: React.FormEvent) {
    event.preventDefault();
    setError('');
    setBusy(true);
    try {
      const saved = loadedVoucherNo
        ? await put<SaveResult>(
            `/repair-customer-issues/${encodeURIComponent(loadedVoucherNo)}`,
            requestBody(),
          )
        : await post<SaveResult>('/repair-customer-issues', requestBody());
      setResult(saved);
      setLoadedVoucherNo(saved.voucherNo);
      setLoadVoucherNo(saved.voucherNo);
    } catch (caught) {
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'customer repair issue save failed',
      );
    } finally {
      setBusy(false);
    }
  }

  async function loadIssue() {
    if (!coBook || !loadVoucherNo.trim()) return;
    setError('');
    setBusy(true);
    try {
      const view = await get<RepairIssueView>(
        `/repair-customer-issues/${encodeURIComponent(loadVoucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVoucherNo(view.voucherNo);
      setLoadVoucherNo(view.voucherNo);
      setVchDate(view.vchDate);
      setBillNo(view.billNo);
      setEmployeeCode(view.employeeCode);
      setBankName(view.bankName);
      setDescription(view.description);
      setAcCode(view.acCode);
      setAcName(view.acName);
      setDiscountPct(text(view.discountPct));
      setTaxCode(view.taxCode);
      setChequeAmount(text(view.chequeAmount));
      setChequeAccount(view.chequeAccount);
      setChequeNo(view.chequeNo);
      setCardAmount(text(view.cardAmount));
      setCardAccount(view.cardAccount);
      setCashAmount(text(view.cashAmount));
      setKasarAmount(text(view.kasarAmount));
      setLines(view.lines.length ? view.lines : [blankLine()]);
      setResult({
        vchNo: Number(view.voucherNo),
        voucherNo: view.voucherNo,
        headerVoucherNo: view.headerVoucherNo,
        created: false,
        totals: view.totals,
      });
    } catch (caught) {
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'customer repair issue load failed',
      );
    } finally {
      setBusy(false);
    }
  }

  async function removeIssue() {
    if (!loadedVoucherNo || !window.confirm(`Delete repair delivery ${loadedVoucherNo}?`)) return;
    setError('');
    setBusy(true);
    try {
      await del(`/repair-customer-issues/${encodeURIComponent(loadedVoucherNo)}`, { coBook });
      reset();
    } catch (caught) {
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'customer repair issue delete failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <PartyBalance acCode={acCode} />
      <form onSubmit={submit}>
        <VoucherChrome
          title="Repairing Delivered — Customer Issue"
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
          onDelete={loadedVoucherNo ? removeIssue : undefined}
          onExit={() => router.back()}
          onPrint={
            loadedVoucherNo
              ? () =>
                  openDocument(
                    `/api/repair-customer-issues/${encodeURIComponent(loadedVoucherNo)}/print?coBook=${encodeURIComponent(coBook)}&format=html`,
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
                mainBooks={['CUSTREP ISSUE']}
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
                data-testid="repair-custisu-load-voucher"
              />
            </div>
            <button type="button" className="ghost" disabled={!coBook || busy} onClick={loadIssue}>
              Load
            </button>
            <div className="field" data-testid="repair-custisu-party">
              <label>Customer</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={(value) => {
                  setAcCode(value);
                  setAcName('');
                  setLines([blankLine()]);
                }}
                onPick={(row) => setAcName(String(row.name ?? ''))}
                style={{ width: 150 }}
              />
            </div>
            <div className="field">
              <label>Customer Name</label>
              <input
                value={acName}
                readOnly={acCode !== '00050'}
                onChange={(event) => setAcName(event.target.value)}
              />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Repairs Ready for Delivery</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Customer Repair No</th>
                <th>Karigar</th>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Add Wt</th>
                <th className="num">Less Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Fine</th>
                <th className="num">Rate</th>
                <th>Lbr Type</th>
                <th className="num">Lbr Rate</th>
                <th className="num">Other Amt</th>
                <th className="num">Net Amt</th>
                <th></th>
              </tr>
            </thead>
            <tbody data-testid="repair-custisu-grid" onKeyDown={handleGridKey}>
              {lines.map((line, index) => (
                <tr key={index}>
                  <td {...gridCell(index, 0)}>
                    <LookupPicker
                      entity="repairs ready for delivery"
                      searchPath={`/repair-customer-issues/open-lines?coBook=${encodeURIComponent(coBook)}&acCode=${encodeURIComponent(acCode)}`}
                      value={line.code}
                      onChange={(value) =>
                        setLine(index, value === line.code ? line : { ...blankLine(), code: value })
                      }
                      onPick={(row) => setLine(index, pickedSource(row))}
                      placeholder="F1 for open repair…"
                      style={{ width: 200 }}
                    />
                  </td>
                  <td>
                    {line.karigarName || line.karigarCode || '—'}
                    {line.karigarReceiptNo && (
                      <span className="muted"> · {line.karigarReceiptNo}</span>
                    )}
                  </td>
                  <td>
                    {line.itemName || line.itCode}
                    {line.itmSize && <span className="muted"> · {line.itmSize}</span>}
                  </td>
                  <td className="num">{line.pieces || ''}</td>
                  <td className="num">{line.grossWt ? line.grossWt.toFixed(3) : ''}</td>
                  <td className="num" {...gridCell(index, 1)}>
                    <input
                      className="num"
                      value={text(line.addWt)}
                      onChange={(event) =>
                        patchLine(index, { addWt: Number(event.target.value || 0) })
                      }
                      data-testid={`repair-custisu-addwt-${index}`}
                    />
                  </td>
                  <td className="num">{line.lessWt ? line.lessWt.toFixed(3) : ''}</td>
                  <td className="num" {...gridCell(index, 2)}>
                    <input
                      className="num"
                      value={text(line.touch)}
                      onChange={(event) =>
                        patchLine(index, { touch: Number(event.target.value || 0) })
                      }
                    />
                  </td>
                  <td className="num" data-testid={`repair-custisu-fine-${index}`}>
                    {lineFine(line) ? lineFine(line).toFixed(3) : ''}
                  </td>
                  <td className="num" {...gridCell(index, 3)}>
                    <input
                      className="num"
                      value={text(line.rate)}
                      onChange={(event) =>
                        patchLine(index, { rate: Number(event.target.value || 0) })
                      }
                      data-testid={`repair-custisu-rate-${index}`}
                    />
                  </td>
                  <td>
                    <input
                      value={line.labourType}
                      maxLength={1}
                      onChange={(event) =>
                        patchLine(index, { labourType: event.target.value.toUpperCase() })
                      }
                      style={{ width: 46 }}
                    />
                  </td>
                  <td className="num" {...gridCell(index, 4)}>
                    <input
                      className="num"
                      value={text(line.labourRate)}
                      onChange={(event) =>
                        patchLine(index, { labourRate: Number(event.target.value || 0) })
                      }
                    />
                  </td>
                  <td className="num" {...gridCell(index, 5)}>
                    <input
                      className="num"
                      value={text(line.otherAmount)}
                      onChange={(event) =>
                        patchLine(index, { otherAmount: Number(event.target.value || 0) })
                      }
                    />
                  </td>
                  <td className="num" data-testid={`repair-custisu-net-${index}`}>
                    {lineNetAmount(line) ? lineNetAmount(line).toFixed(2) : ''}
                  </td>
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
                      aria-label={`Remove repair delivery row ${index + 1}`}
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={3}>Total delivered</td>
                <td className="num">{pieces || ''}</td>
                <td className="num">{gross.toFixed(3)}</td>
                <td colSpan={3}></td>
                <td className="num">{fine.toFixed(3)}</td>
                <td colSpan={4}></td>
                <td className="num" data-testid="repair-custisu-detail-net">
                  {detailNet.toFixed(2)}
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((current) => [...current, blankLine()])}
            >
              + Add source
            </button>
            <span className="spacer" />
            <span>{selected.length} repair item(s)</span>
          </div>
        </div>

        <div className="panel">
          <h2>Bill &amp; Settlement</h2>
          <div className="row">
            <div className="field">
              <label>Discount % (on labour)</label>
              <input
                value={discountPct}
                onChange={(event) => setDiscountPct(event.target.value)}
                data-testid="repair-custisu-discount"
              />
            </div>
            <div className="field">
              <label>Tax Code</label>
              <LookupPicker
                entity="taxes"
                value={taxCode}
                onChange={setTaxCode}
                style={{ width: 110 }}
              />
            </div>
            <div className="field">
              <label>Cheque Amount</label>
              <input
                ref={chequeRef}
                value={chequeAmount}
                onChange={(event) => setChequeAmount(event.target.value)}
                data-testid="repair-custisu-cheque"
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
              <input value={chequeNo} onChange={(event) => setChequeNo(event.target.value)} />
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label>Card Amount</label>
              <input value={cardAmount} onChange={(event) => setCardAmount(event.target.value)} />
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
                onChange={(event) => setCashAmount(event.target.value)}
                data-testid="repair-custisu-cash"
              />
            </div>
            <div className="field">
              <label>Kasar Amount</label>
              <input value={kasarAmount} onChange={(event) => setKasarAmount(event.target.value)} />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="spacer" />
            <strong data-testid="repair-custisu-received">
              Received ₹{received.toLocaleString('en-IN')}
            </strong>
          </div>
        </div>
      </form>

      {error && <div className="msg err">{error}</div>}
      {result && (
        <div className="msg ok" data-testid="repair-custisu-saved">
          Saved customer repair delivery {result.voucherNo} · header {result.headerVoucherNo} ·
          total ₹{result.totals.totalAmount.toLocaleString('en-IN')} · outstanding ₹
          {result.totals.outstandingAmount.toLocaleString('en-IN')}
        </div>
      )}
      <p className="muted" style={{ marginTop: 8 }}>
        Final repair stage: the repaired item is delivered back to the customer and billed. Rows may
        come straight from a Customer Repair Receipt or through a Karigar Repair Receipt; discount,
        tax, rounding and posted amounts are recalculated server-side from persisted configuration.
      </p>
    </div>
  );
}
