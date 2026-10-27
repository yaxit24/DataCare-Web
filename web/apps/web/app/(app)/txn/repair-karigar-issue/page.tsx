'use client';

import { useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { LookupPicker, type LookupRow } from '../../../../components/LookupPicker';
import { PartyBalance } from '../../../../components/PartyBalance';
import { RepairImagePanel } from '../../../../components/RepairImagePanel';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { todayLocal } from '../../../../lib/localDate';

interface IssueSourceLine {
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
  itCode: string;
  itemName: string;
  description: string;
  itmSize: string;
  tagNo: string;
  pieces: number;
  grossWt: number;
  otherWt: number;
  netWt: number;
  touch: number;
  wastagePct: number;
  fineWt: number;
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
  chequeAmount: number;
  chequeAccount: string;
  chequeNo: string;
  cardAmount: number;
  cardAccount: string;
  cashAmount: number;
  totals: IssueTotals;
  lines: IssueSourceLine[];
}

interface SaveResult {
  vchNo: number;
  voucherNo: string;
  headerVoucherNo: string;
  created: boolean;
  totals: IssueTotals;
}

const blankLine = (): IssueSourceLine => ({
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
  itCode: '',
  itemName: '',
  description: '',
  itmSize: '',
  tagNo: '',
  pieces: 0,
  grossWt: 0,
  otherWt: 0,
  netWt: 0,
  touch: 0,
  wastagePct: 0,
  fineWt: 0,
});

const n = (value: string | number | undefined): number => Number(value || 0);
const text = (value: string | number | undefined): string =>
  value == null || Number(value) === 0 ? '' : String(value);
const gridCell = (row: number, column: number) => ({
  'data-grid-row': row,
  'data-grid-column': column,
});

function pickedSource(row: LookupRow): IssueSourceLine {
  return {
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
    itCode: String(row.itCode ?? ''),
    itemName: String(row.itemName ?? ''),
    description: String(row.description ?? ''),
    itmSize: String(row.itmSize ?? ''),
    tagNo: String(row.tagNo ?? ''),
    pieces: Number(row.pieces ?? 0),
    grossWt: Number(row.grossWt ?? 0),
    otherWt: Number(row.otherWt ?? 0),
    netWt: Number(row.netWt ?? 0),
    touch: Number(row.touch ?? 0),
    wastagePct: Number(row.wastagePct ?? 0),
    fineWt: Number(row.fineWt ?? 0),
  };
}

export default function RepairKarigarIssuePage() {
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
  const [chequeAmount, setChequeAmount] = useState('');
  const [chequeAccount, setChequeAccount] = useState('');
  const [chequeNo, setChequeNo] = useState('');
  const [cardAmount, setCardAmount] = useState('');
  const [cardAccount, setCardAccount] = useState('');
  const [cashAmount, setCashAmount] = useState('');
  const [lines, setLines] = useState<IssueSourceLine[]>([blankLine()]);
  const [activeImageRow, setActiveImageRow] = useState(0);
  const [loadVoucherNo, setLoadVoucherNo] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [result, setResult] = useState<SaveResult | null>(null);
  const [error, setError] = useState('');
  const [busy, setBusy] = useState(false);
  const chequeRef = useRef<HTMLInputElement>(null);

  const setLine = (index: number, value: IssueSourceLine) =>
    setLines((current) => current.map((line, lineIndex) => (lineIndex === index ? value : line)));

  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: 1,
    onAppendRow: () => setLines((current) => [...current, blankLine()]),
    onRemoveRow: (row) => {
      if (!window.confirm('Remove this customer repair source row?')) return false;
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
  const imageSource = lines[Math.min(activeImageRow, Math.max(lines.length - 1, 0))];
  const pieces = selected.reduce((sum, line) => sum + n(line.pieces), 0);
  const gross = selected.reduce((sum, line) => sum + n(line.grossWt), 0);
  const net = selected.reduce((sum, line) => sum + n(line.netWt), 0);
  const fine = selected.reduce((sum, line) => sum + n(line.fineWt), 0);
  const paid = n(chequeAmount) + n(cardAmount) + n(cashAmount);

  const reset = () => {
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
    chequeAmount: n(chequeAmount),
    chequeAccount: chequeAccount || undefined,
    chequeNo: chequeNo || undefined,
    cardAmount: n(cardAmount),
    cardAccount: cardAccount || undefined,
    cashAmount: n(cashAmount),
    lines: selected.map((line) => ({
      coYear: line.coYear,
      coBook: line.coBook,
      voucherNo: line.voucherNo,
      srNo: line.srNo,
    })),
  });

  async function submit(event: React.FormEvent) {
    event.preventDefault();
    setError('');
    setBusy(true);
    try {
      const saved = loadedVoucherNo
        ? await put<SaveResult>(
            `/repair-karigar-issues/${encodeURIComponent(loadedVoucherNo)}`,
            requestBody(),
          )
        : await post<SaveResult>('/repair-karigar-issues', requestBody());
      setResult(saved);
      setLoadedVoucherNo(saved.voucherNo);
      setLoadVoucherNo(saved.voucherNo);
    } catch (caught) {
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'karigar repair issue save failed',
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
        `/repair-karigar-issues/${encodeURIComponent(loadVoucherNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
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
      setChequeAmount(text(view.chequeAmount));
      setChequeAccount(view.chequeAccount);
      setChequeNo(view.chequeNo);
      setCardAmount(text(view.cardAmount));
      setCardAccount(view.cardAccount);
      setCashAmount(text(view.cashAmount));
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
          : 'karigar repair issue load failed',
      );
    } finally {
      setBusy(false);
    }
  }

  async function removeIssue() {
    if (!loadedVoucherNo || !window.confirm(`Delete repair issue ${loadedVoucherNo}?`)) return;
    setError('');
    setBusy(true);
    try {
      await del(`/repair-karigar-issues/${encodeURIComponent(loadedVoucherNo)}`, { coBook });
      reset();
    } catch (caught) {
      setError(
        caught instanceof ApiError
          ? caught.body?.message || caught.body?.error || caught.message
          : 'karigar repair issue delete failed',
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
          title="Repairing Issued — Karigar Issue"
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
                  window.open(
                    `/api/repair-karigar-issues/${encodeURIComponent(loadedVoucherNo)}/print?coBook=${encodeURIComponent(coBook)}&format=html`,
                    '_blank',
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
                mainBooks={['KRREP ISSUE']}
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
                data-testid="repair-issue-load-voucher"
              />
            </div>
            <button type="button" className="ghost" disabled={!coBook || busy} onClick={loadIssue}>
              Load
            </button>
            <div className="field" data-testid="repair-issue-party">
              <label>Karigar</label>
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
              <label>Karigar Name</label>
              <input
                value={acName}
                readOnly={acCode !== '00050'}
                onChange={(event) => setAcName(event.target.value)}
              />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Open Customer Repairs</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Customer Repair No</th>
                <th>Date</th>
                <th>Customer</th>
                <th>Item</th>
                <th>Repairing Desc</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Other Wt</th>
                <th className="num">Net</th>
                <th className="num">Touch%</th>
                <th className="num">Fine</th>
                <th></th>
              </tr>
            </thead>
            <tbody data-testid="repair-issue-grid" onKeyDown={handleGridKey}>
              {lines.map((line, index) => (
                <tr key={index} onFocusCapture={() => setActiveImageRow(index)}>
                  <td {...gridCell(index, 0)}>
                    <LookupPicker
                      entity="open customer repairs"
                      searchPath={`/repair-karigar-issues/open-lines?coBook=${encodeURIComponent(coBook)}`}
                      value={line.code}
                      onChange={(value) =>
                        setLine(index, value === line.code ? line : { ...blankLine(), code: value })
                      }
                      onPick={(row) => setLine(index, pickedSource(row))}
                      placeholder="F1 for open repair…"
                      style={{ width: 220 }}
                    />
                  </td>
                  <td>{line.vchDate}</td>
                  <td>{line.customerName || line.customerCode}</td>
                  <td>
                    {line.itemName || line.itCode}
                    {line.itmSize && <span className="muted"> · {line.itmSize}</span>}
                  </td>
                  <td>{line.description}</td>
                  <td className="num">{line.pieces || ''}</td>
                  <td className="num">{line.grossWt ? line.grossWt.toFixed(3) : ''}</td>
                  <td className="num">{line.otherWt ? line.otherWt.toFixed(3) : ''}</td>
                  <td className="num" data-testid={`repair-issue-net-${index}`}>
                    {line.netWt ? line.netWt.toFixed(3) : ''}
                  </td>
                  <td className="num">{line.touch || ''}</td>
                  <td className="num">{line.fineWt ? line.fineWt.toFixed(3) : ''}</td>
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
                      aria-label={`Remove repair source row ${index + 1}`}
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={5}>Total issued</td>
                <td className="num">{pieces || ''}</td>
                <td className="num">{gross.toFixed(3)}</td>
                <td></td>
                <td className="num">{net.toFixed(3)}</td>
                <td></td>
                <td className="num">{fine.toFixed(3)}</td>
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
            <span>{selected.length} customer repair item(s)</span>
          </div>
        </div>

        <div className="panel">
          <h2>Advance Paid</h2>
          <div className="row">
            <div className="field">
              <label>Cheque Amount</label>
              <input
                ref={chequeRef}
                value={chequeAmount}
                onChange={(event) => setChequeAmount(event.target.value)}
                data-testid="repair-issue-cheque"
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
                data-testid="repair-issue-cash"
              />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="spacer" />
            <strong data-testid="repair-issue-paid">Paid ₹{paid.toLocaleString('en-IN')}</strong>
          </div>
        </div>
      </form>

      {/* Desktop keys the KRREP ISSUE image to the selected customer repair row, not this voucher. */}
      <RepairImagePanel
        imageBook={imageSource?.coBook ?? ''}
        imageYear={imageSource?.coYear}
        vchNo={imageSource?.voucherNo ?? ''}
        srNo={imageSource?.srNo ?? 0}
        testId="repair-issue-image"
      />

      {error && <div className="msg err">{error}</div>}
      {result && (
        <div className="msg ok" data-testid="repair-issue-saved">
          Saved karigar repair issue {result.voucherNo} · header {result.headerVoucherNo}
        </div>
      )}
      <p className="muted" style={{ marginTop: 8 }}>
        This stage issues open Customer Repair Receipt rows to a karigar. Karigar receipt and final
        customer delivery remain separate workflow stages.
      </p>
    </div>
  );
}
