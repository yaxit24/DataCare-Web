'use client';

import { useState } from 'react';
import { get, post, del, ApiError } from '../../../../lib/api';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

type Line = {
  schmCode: string;
  membCode: string;
  acCode: string;
  acName: string;
  goldWt: string;
  goldRate: string;
  goldAmt: string;
  memberAmount: string;
  adjustAmount: string;
  bonus: string;
  less: string;
  empCode: string;
  vchDesc: string;
  saleBillNo: string;
  saleBillAmount: string;
};

const blankLine = (): Line => ({
  schmCode: '',
  membCode: '',
  acCode: '',
  acName: '',
  goldWt: '',
  goldRate: '',
  goldAmt: '',
  memberAmount: '',
  adjustAmount: '',
  bonus: '',
  less: '',
  empCode: '',
  vchDesc: '',
  saleBillNo: '',
  saleBillAmount: '',
});

const n = (value: string): number => Number(value || 0);
const r2 = (value: number): number => Math.round((value + Number.EPSILON) * 100) / 100;
const r3 = (value: number): number => Math.round((value + Number.EPSILON) * 1000) / 1000;
const money = (value: number): string => value.toLocaleString('en-IN');
const errText = (e: unknown): string =>
  e instanceof ApiError
    ? e.body?.message || e.body?.detail || e.body?.error || e.message || 'failed'
    : e instanceof Error
      ? e.message
      : 'failed';

export default function SchemeGoldAdjustPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [updateExpiry, setUpdateExpiry] = useState(false);
  const [lines, setLines] = useState<Line[]>([blankLine()]);
  const [loadNo, setLoadNo] = useState('');
  const [result, setResult] = useState<{
    vchNo: number;
    lines: number;
    goldWt: number;
    goldAmt: number;
    adjustedAmount: number;
  } | null>(null);
  const [message, setMessage] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);

  const setLine = (index: number, key: keyof Line, value: string) =>
    setLines((rows) => rows.map((row, i) => (i === index ? { ...row, [key]: value } : row)));

  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((rows) => [...rows, blankLine()]),
    onRemoveRow: (row) => {
      setLines((rows) => (rows.length === 1 ? [blankLine()] : rows.filter((_, i) => i !== row)));
      return true;
    },
    onEscape: () => {},
  });

  const computedGoldAmt = (line: Line) =>
    line.goldAmt.trim() ? n(line.goldAmt) : r2(n(line.goldWt) * n(line.goldRate));
  const totalGoldWt = r3(lines.reduce((sum, line) => sum + n(line.goldWt), 0));
  const totalGoldAmt = r2(lines.reduce((sum, line) => sum + computedGoldAmt(line), 0));
  const totalAdjust = r2(lines.reduce((sum, line) => sum + n(line.adjustAmount), 0));

  function requestLines() {
    return lines
      .filter(
        (line) =>
          line.schmCode.trim() ||
          line.membCode.trim() ||
          line.acCode.trim() ||
          line.goldWt.trim() ||
          line.goldAmt.trim() ||
          line.adjustAmount.trim(),
      )
      .map((line, index) => ({
        srNo: index + 1,
        schmCode: line.schmCode.trim(),
        membCode: line.membCode.trim(),
        acCode: line.acCode.trim() || line.membCode.trim() || undefined,
        acName: line.acName.trim() || undefined,
        goldWt: line.goldWt.trim() ? Number(line.goldWt) : undefined,
        goldRate: line.goldRate.trim() ? Number(line.goldRate) : undefined,
        goldAmt: line.goldAmt.trim() ? Number(line.goldAmt) : undefined,
        memberAmount: line.memberAmount.trim() ? Number(line.memberAmount) : undefined,
        adjustAmount: line.adjustAmount.trim() ? Number(line.adjustAmount) : undefined,
        bonus: line.bonus.trim() ? Number(line.bonus) : undefined,
        less: line.less.trim() ? Number(line.less) : undefined,
        empCode: line.empCode.trim() || undefined,
        vchDesc: line.vchDesc.trim() || undefined,
        saleBillNo: line.saleBillNo.trim() || undefined,
        saleBillAmount: line.saleBillAmount.trim() ? Number(line.saleBillAmount) : undefined,
      }));
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMessage(null);
    setResult(null);
    const bodyLines = requestLines();
    if (!coBook) {
      setMessage({ kind: 'err', text: 'select the MEMB GOLD ADJ book' });
      return;
    }
    if (!bodyLines.length) {
      setMessage({ kind: 'err', text: 'enter at least one adjustment row' });
      return;
    }
    const invalid = bodyLines.find((line) => !line.schmCode || !line.membCode || !line.acCode);
    if (invalid) {
      setMessage({ kind: 'err', text: 'each row requires scheme, member, and account' });
      return;
    }
    setBusy(true);
    try {
      const response = await post<typeof result>('/scheme/gold-adjust', {
        coBook,
        coYear,
        lcCode,
        vchDate: vchDate || undefined,
        updateExpiry,
        lines: bodyLines,
      });
      setResult(response);
      setMessage({
        kind: 'ok',
        text: `Gold adjustment voucher #${response?.vchNo} saved (${response?.lines} line${response?.lines === 1 ? '' : 's'})`,
      });
      setLoadNo(String(response?.vchNo ?? ''));
    } catch (e) {
      setMessage({ kind: 'err', text: errText(e) });
    } finally {
      setBusy(false);
    }
  }

  async function loadVoucher() {
    if (!loadNo.trim()) return;
    setMessage(null);
    setBusy(true);
    try {
      const query = coBook ? `?book=${encodeURIComponent(coBook)}` : '';
      const response = await get<{ vchDate: string; lines: Array<Record<string, unknown>> }>(
        `/scheme/gold-adjust/${encodeURIComponent(loadNo.trim())}${query}`,
      );
      setVchDate(String(response.vchDate || ''));
      setLines(
        response.lines.map((row) => ({
          schmCode: String(row.schmCode ?? ''),
          membCode: String(row.membCode ?? ''),
          acCode: String(row.acCode ?? ''),
          acName: String(row.acName ?? ''),
          goldWt: String(row.goldWt ?? ''),
          goldRate: String(row.goldRate ?? ''),
          goldAmt: String(row.goldAmt ?? ''),
          memberAmount: String(row.memberAmount ?? ''),
          adjustAmount: String(row.adjustAmount ?? ''),
          bonus: String(row.bonus ?? ''),
          less: String(row.less ?? ''),
          empCode: String(row.empCode ?? ''),
          vchDesc: String(row.vchDesc ?? ''),
          saleBillNo: String(row.saleBillNo ?? ''),
          saleBillAmount: String(row.saleBillAmount ?? ''),
        })),
      );
      setMessage({ kind: 'ok', text: `Loaded gold adjustment voucher #${loadNo.trim()}` });
    } catch (e) {
      setMessage({ kind: 'err', text: errText(e) });
    } finally {
      setBusy(false);
    }
  }

  async function deleteVoucher() {
    if (!loadNo.trim()) return;
    setMessage(null);
    setBusy(true);
    try {
      await del(`/scheme/gold-adjust/${encodeURIComponent(loadNo.trim())}`, {
        book: coBook || undefined,
      });
      setMessage({ kind: 'ok', text: `Deleted gold adjustment voucher #${loadNo.trim()}` });
      setResult(null);
      setLines([blankLine()]);
    } catch (e) {
      setMessage({ kind: 'err', text: errText(e) });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Member Gold Adjust</h1>
      <p className="muted">
        Desktop `TR_MEMB_ADJ` / `MEMB GOLD ADJ`: writes AD_ADJ, AD_OS, AC_DATA and Rojmel rows for
        gold weight and priced gold adjustments.
      </p>
      {message && <div className={`msg ${message.kind}`}>{message.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} mainBooks={['MEMB GOLD ADJ']} />
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
              <label>Voucher Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field" style={{ flexDirection: 'row', alignItems: 'center', gap: 8 }}>
              <input
                id="gold-adjust-expiry"
                type="checkbox"
                checked={updateExpiry}
                onChange={(e) => setUpdateExpiry(e.target.checked)}
              />
              <label htmlFor="gold-adjust-expiry" style={{ margin: 0 }}>
                Update member expiry date
              </label>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflowX: 'auto' }}>
          <div className="toolbar" style={{ marginBottom: 8 }}>
            <strong>Adjustment Lines</strong>
            <span className="spacer" />
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((rows) => [...rows, blankLine()])}
            >
              Add Row
            </button>
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>#</th>
                <th>Scheme</th>
                <th>Member</th>
                <th>Account</th>
                <th>Account Name</th>
                <th>Gold Wt</th>
                <th>Gold Rate</th>
                <th>Gold Amt</th>
                <th>Adj Amt</th>
                <th>Bonus</th>
                <th>Less</th>
                <th>Emp</th>
                <th>Remark</th>
                <th />
              </tr>
            </thead>
            <tbody>
              {lines.map((line, index) => (
                <tr key={index}>
                  <td>{index + 1}</td>
                  <td>
                    <input
                      data-grid-cell={`${index}:0`}
                      onKeyDown={handleGridKey}
                      value={line.schmCode}
                      onChange={(e) => setLine(index, 'schmCode', e.target.value)}
                      maxLength={3}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:1`}
                      onKeyDown={handleGridKey}
                      value={line.membCode}
                      onChange={(e) => setLine(index, 'membCode', e.target.value)}
                      maxLength={5}
                    />
                  </td>
                  <td style={{ minWidth: 150 }}>
                    <LookupPicker
                      entity="accounts"
                      value={line.acCode}
                      onChange={(v) => setLine(index, 'acCode', v)}
                      onPick={(r) => {
                        setLine(index, 'acCode', String(r.code));
                        setLine(index, 'acName', r.name ? String(r.name) : line.acName);
                      }}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:3`}
                      onKeyDown={handleGridKey}
                      value={line.acName}
                      onChange={(e) => setLine(index, 'acName', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:4`}
                      onKeyDown={handleGridKey}
                      value={line.goldWt}
                      onChange={(e) => setLine(index, 'goldWt', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:5`}
                      onKeyDown={handleGridKey}
                      value={line.goldRate}
                      onChange={(e) => setLine(index, 'goldRate', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:6`}
                      onKeyDown={handleGridKey}
                      value={line.goldAmt}
                      placeholder={
                        line.goldWt && line.goldRate ? String(computedGoldAmt(line)) : ''
                      }
                      onChange={(e) => setLine(index, 'goldAmt', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:7`}
                      onKeyDown={handleGridKey}
                      value={line.adjustAmount}
                      onChange={(e) => setLine(index, 'adjustAmount', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:8`}
                      onKeyDown={handleGridKey}
                      value={line.bonus}
                      onChange={(e) => setLine(index, 'bonus', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:9`}
                      onKeyDown={handleGridKey}
                      value={line.less}
                      onChange={(e) => setLine(index, 'less', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:10`}
                      onKeyDown={handleGridKey}
                      value={line.empCode}
                      onChange={(e) => setLine(index, 'empCode', e.target.value)}
                      maxLength={3}
                    />
                  </td>
                  <td>
                    <input
                      data-grid-cell={`${index}:11`}
                      onKeyDown={handleGridKey}
                      value={line.vchDesc}
                      onChange={(e) => setLine(index, 'vchDesc', e.target.value)}
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      className="ghost"
                      onClick={() =>
                        setLines((rows) =>
                          rows.length === 1 ? [blankLine()] : rows.filter((_, i) => i !== index),
                        )
                      }
                    >
                      Remove
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          <div className="tiles" style={{ marginTop: 10 }}>
            <div className="tile">
              <div className="muted">Gold Wt</div>
              <div className="big kpi">{totalGoldWt}</div>
            </div>
            <div className="tile">
              <div className="muted">Gold Amt ₹</div>
              <div className="big kpi">{money(totalGoldAmt)}</div>
            </div>
            <div className="tile">
              <div className="muted">Adj Amt ₹</div>
              <div className="big kpi">{money(totalAdjust)}</div>
            </div>
          </div>
        </div>

        <div className="toolbar">
          <button className="primary" data-save-mnemonic disabled={busy}>
            {busy ? 'Saving…' : 'Save Gold Adjust'}
          </button>
          <span className="spacer" />
          <input
            placeholder="Voucher no"
            value={loadNo}
            onChange={(e) => setLoadNo(e.target.value)}
            style={{ maxWidth: 140 }}
          />
          <button
            type="button"
            className="ghost"
            disabled={busy || !loadNo.trim()}
            onClick={loadVoucher}
          >
            Load
          </button>
          <button
            type="button"
            className="ghost"
            disabled={busy || !loadNo.trim()}
            onClick={deleteVoucher}
          >
            Delete
          </button>
        </div>
      </form>
      {result && (
        <div className="panel" style={{ marginTop: 12 }}>
          <div className="tiles">
            <div className="tile">
              <div className="muted">voucher</div>
              <div className="big kpi">#{result.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">lines</div>
              <div className="big kpi">{result.lines}</div>
            </div>
            <div className="tile">
              <div className="muted">gold wt</div>
              <div className="big kpi">{result.goldWt}</div>
            </div>
          </div>
        </div>
      )}
    </div>
  );
}
