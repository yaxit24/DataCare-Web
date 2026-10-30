'use client';
import { useState } from 'react';
import { post, get, put, del, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

interface Line {
  bankCharges: string;
  chqPrintName: string;
  clearDate: string;
  itemDescriptionCode: string;
  partyAc: string;
  partyName: string;
  amount: string;
  mode: string;
  bankAc: string;
  chqNo: string;
  kasar: string;
}
const blank = (): Line => ({
  bankCharges: '',
  chqPrintName: '',
  clearDate: '',
  itemDescriptionCode: '',
  partyAc: '',
  partyName: '',
  amount: '',
  mode: 'cash',
  bankAc: '',
  chqNo: '',
  kasar: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;
const inr = (x: number) => x.toLocaleString('en-IN');

/**
 * Multi-Party Receipt (Phase 6 / TR_CASH grid). Collects money IN from several parties in ONE
 * receipt voucher: each row is a party + amount received + mode (+ cheque) + an optional kasar
 * (round-off / discount) written off so that party clears in full. Posts to /receipts/batch which
 * builds the balanced AC_DATA ledger (Dr cash/bank + Dr KASAR; Cr party for amount+kasar) and one
 * CASH_DATA row per line.
 */
/**
 * P3: Line fields the server accepted that no screen could send.
 *
 * Cheque clearing needs the bank's charge, the name to print on the instrument, the clearing date and the item-description code; without them a batch receipt cannot record what the bank actually did.
 */
const extendedP3Fields: Array<[keyof Line, string]> = [
  ['bankCharges', 'BankChg'],
  ['chqPrintName', 'ChqName'],
  ['clearDate', 'ClearDate'],
  ['itemDescriptionCode', 'ItDescCode'],
];

export default function BatchReceiptPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [lines, setLines] = useState<Line[]>([blank(), blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [result, setResult] = useState<{ vchNo: number; total: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [voucherSearch, setVoucherSearch] = useState('');
  const [loadedVch, setLoadedVch] = useState('');

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // Live totals: money received (Σ amount, the receipt total), kasar written off, and the gross
  // cleared (received + kasar) credited to the parties.
  const totRecv = r2(lines.reduce((s, l) => s + n(l.amount), 0));
  const totKasar = r2(lines.reduce((s, l) => s + n(l.kasar), 0));
  const totCleared = r2(totRecv + totKasar);
  const validLines = lines.filter((l) => l.partyAc.trim() && n(l.amount) > 0);
  const canSubmit = validLines.length >= 1 && totRecv > 0;

  function payload() {
    return {
      coBook,
      coYear,
      lcCode,
      vchDate: vchDate || undefined,
      lines: validLines.map((l) => ({
        bankCharges: n(l.bankCharges),
        chqPrintName: l.chqPrintName || undefined,
        clearDate: l.clearDate || undefined,
        itemDescriptionCode: l.itemDescriptionCode || undefined,
        partyAc: l.partyAc,
        partyName: l.partyName || undefined,
        amount: Number(l.amount || 0),
        mode: l.mode,
        bankAc: l.mode === 'cash' ? undefined : l.bankAc || undefined,
        chqNo: l.mode === 'cheque' ? l.chqNo || undefined : undefined,
        kasarAmt: Number(l.kasar || 0),
      })),
    };
  }

  function reset() {
    setVchDate('');
    setLines([blank(), blank()]);
    setVoucherSearch('');
    setLoadedVch('');
    setResult(null);
    setErr('');
  }

  async function loadVoucher(vchNo: string) {
    if (!coBook || !vchNo.trim()) {
      setErr('select the book and enter a voucher number first');
      return;
    }
    setBusy(true);
    setErr('');
    setResult(null);
    try {
      const d = await get<{
        voucherNo: string;
        vchDate: string;
        lines: Array<Record<string, unknown>>;
      }>(
        `/receipts/batch/${encodeURIComponent(vchNo.trim())}?coBook=${encodeURIComponent(coBook)}`,
      );
      const str = (v: unknown) => (v == null || v === 0 || v === '' ? '' : String(v));
      setLoadedVch(String(d.voucherNo ?? vchNo));
      setVoucherSearch(String(d.voucherNo ?? vchNo));
      setVchDate(String(d.vchDate ?? ''));
      const src = Array.isArray(d.lines) ? d.lines : [];
      setLines(
        src.length
          ? src.map((l) => ({
              bankCharges: str(l.bankCharges),
              chqPrintName: l.chqPrintName == null ? '' : String(l.chqPrintName),
              clearDate: l.clearDate == null ? '' : String(l.clearDate),
              itemDescriptionCode: str(l.itemDescriptionCode),
              partyAc: String(l.partyAc ?? ''),
              partyName: l.partyName == null ? '' : String(l.partyName),
              amount: str(l.amount),
              mode: String(l.mode ?? 'cash'),
              bankAc: l.bankAc == null ? '' : String(l.bankAc),
              chqNo: l.chqNo == null ? '' : String(l.chqNo),
              kasar: str(l.kasarAmt),
            }))
          : [blank(), blank()],
      );
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'load failed');
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVch || !window.confirm(`Delete multi-party receipt #${loadedVch}?`)) return;
    setBusy(true);
    setErr('');
    try {
      await del(`/receipts/batch/${encodeURIComponent(loadedVch)}`, { coBook, coYear, lcCode });
      reset();
    } catch (e) {
      setErr(
        e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'delete failed',
      );
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const r = loadedVch
        ? await put<{ vchNo: number; total: number }>(
            `/receipts/batch/${encodeURIComponent(loadedVch)}`,
            payload(),
          )
        : await post<{ vchNo: number; total: number }>('/receipts/batch', payload());
      setResult(r);
      setLoadedVch(String(r.vchNo));
      setVoucherSearch(String(r.vchNo));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Multi-Party Receipt</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="RCT"
                mainBooks={['RECEIPT']}
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
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field">
              <label>Voucher no.</label>
              <div className="row" style={{ gap: 6 }}>
                <input
                  aria-label="Voucher no."
                  value={voucherSearch}
                  onChange={(e) => setVoucherSearch(e.target.value)}
                  placeholder="load existing"
                  style={{ width: 110 }}
                />
                <button type="button" onClick={() => loadVoucher(voucherSearch)} disabled={busy}>
                  Load
                </button>
                <button type="button" className="ghost" onClick={reset} disabled={busy}>
                  New
                </button>
                {loadedVch && (
                  <button type="button" className="danger" onClick={remove} disabled={busy}>
                    Delete
                  </button>
                )}
              </div>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Collections</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedP3Fields.length}
            testId="batch-receipt-p3-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Party</th>
                <th>Name</th>
                <th className="num">Amount</th>
                <th>Mode</th>
                <th>Bank A/C</th>
                <th>Cheque No</th>
                <th className="num">Kasar</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedP3Fields} />
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="accounts"
                      value={l.partyAc}
                      onChange={(v) => setLine(i, 'partyAc', v)}
                      onPick={(r) => setLine(i, 'partyName', String(r.name || ''))}
                      style={{ width: 170 }}
                    />
                  </td>
                  <td>
                    <input
                      style={{ width: '100%', minWidth: 150 }}
                      value={l.partyName}
                      onChange={(e) => setLine(i, 'partyName', e.target.value)}
                      placeholder="party name"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 110, textAlign: 'right' }}
                      value={l.amount}
                      onChange={(e) => setLine(i, 'amount', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td>
                    <select value={l.mode} onChange={(e) => setLine(i, 'mode', e.target.value)}>
                      <option value="cash">Cash</option>
                      <option value="cheque">Cheque</option>
                      <option value="card">Card</option>
                      <option value="upi">UPI</option>
                      <option value="bank">Bank</option>
                    </select>
                  </td>
                  <td>
                    {l.mode === 'cash' ? (
                      <span className="muted">—</span>
                    ) : (
                      <LookupPicker
                        entity="accounts"
                        value={l.bankAc}
                        onChange={(v) => setLine(i, 'bankAc', v)}
                        style={{ width: 140 }}
                      />
                    )}
                  </td>
                  <td>
                    <input
                      style={{ width: 120 }}
                      value={l.chqNo}
                      onChange={(e) => setLine(i, 'chqNo', e.target.value)}
                      disabled={l.mode !== 'cheque'}
                      placeholder={l.mode === 'cheque' ? 'chq no' : ''}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 100, textAlign: 'right' }}
                      value={l.kasar}
                      onChange={(e) => setLine(i, 'kasar', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setLines((ls) =>
                          ls.length > 1
                            ? ls.filter((_, j) => j !== i)
                            : ls.map((x, j) => (j === i ? blank() : x)),
                        )
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td colSpan={2} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Totals
                </td>
                <td className="num">
                  <b>{inr(totRecv)}</b>
                </td>
                <td colSpan={3}></td>
                <td className="num">
                  <b>{inr(totKasar)}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>

          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Received ₹{inr(totRecv)} · Kasar ₹{inr(totKasar)} · Cleared ₹{inr(totCleared)}
              {' · '}
              <b>{validLines.length}</b> {validLines.length === 1 ? 'party' : 'parties'}
            </span>
            <button className="primary" disabled={busy || !canSubmit}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Post Receipt'}
            </button>
          </div>
          {!canSubmit && totRecv === 0 && (
            <div className="muted" style={{ marginTop: 6 }}>
              Add at least one party with an amount to post.
            </div>
          )}
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            {loadedVch ? 'Updated' : 'Posted'} — Receipt Voucher #{result.vchNo} · Total received ₹
            {inr(r2(Number(result.total ?? 0)))}
          </div>
        </div>
      )}

      <VoucherList
        table="CASH_DATA"
        book={coBook}
        deleteBase="/receipts/batch"
        onLoad={(vchNo) => loadVoucher(vchNo)}
      />
    </div>
  );
}
