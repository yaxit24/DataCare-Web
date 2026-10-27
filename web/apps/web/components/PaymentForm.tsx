'use client';
import { useEffect, useState } from 'react';
import Link from 'next/link';
import { post, ApiError } from '../lib/api';
import { financeMainBooks, initialFinanceMode } from '../lib/financeBooks';
import { BookSelect } from './BookSelect';
import { LookupPicker } from './LookupPicker';
import { PartyBalance } from './PartyBalance';
import { RateTicker } from './RateTicker';
import { useGridKeyboard } from './GridKeyboard';
import { todayLocal } from '../lib/localDate';

interface MLine {
  partyAc: string;
  partyName: string;
  amount: string;
  kasar: string;
  itDesc: string;
}
const mblank = (): MLine => ({ partyAc: '', partyName: '', amount: '', kasar: '', itDesc: '' });
const nn = (v: string) => Number(v || 0);

export default function PaymentForm({ kind }: { kind: 'receipt' | 'payment' }) {
  const ep = kind === 'receipt' ? '/receipts' : '/payments';
  const title = kind === 'receipt' ? 'Receipt' : 'Payment';
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [amount, setAmount] = useState('');
  const [mode, setMode] = useState('cash');
  // The configured book the voucher is numbered and posted in. The desktop fixes it before the form
  // opens (CurBookHelp by MAIN_BOOK). Without it every save was refused with HTTP 400
  // (PARITY-EVALUATION-2026-09-28 D1).
  const [coBook, setCoBook] = useState('');
  // TR_CASH saves the operator's voucher date (mVchDate, TR_CASH.cs:3021). The form had no date field,
  // so every receipt and payment was dated the moment it was saved.
  const [vchDate, setVchDate] = useState(() => todayLocal());
  const mainBooks = financeMainBooks(kind, mode);
  useEffect(() => {
    setMode(initialFinanceMode(window.location.search));
  }, []);
  const [bankAc, setBankAc] = useState('');
  const [chqNo, setChqNo] = useState('');
  const [chqPrintName, setChqPrintName] = useState('');
  const [pan, setPan] = useState('');
  const [kasar, setKasar] = useState('');
  const [empCode, setEmpCode] = useState('');
  const [cardCommissionPct, setCardCommissionPct] = useState('');
  const [bankName, setBankName] = useState('');
  const [upiId, setUpiId] = useState('');
  const [multi, setMulti] = useState(false);
  const [mlines, setMlines] = useState<MLine[]>([mblank()]);
  // P1-5: mounted once here so both /txn/payment and /txn/receipt honour the keyboard contract.
  // Only the multi-line mode renders a grid; the single-party mode has no rows to navigate.
  const handleGridKey = useGridKeyboard({
    rowCount: mlines.length,
    onAppendRow: () => setMlines((rows) => [...rows, mblank()]),
    onRemoveRow: (row) => {
      setMlines((rows) =>
        rows.length === 1 ? [mblank()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [res, setRes] = useState<{ vchNo: number; total?: number; coBook: string } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const setM = (i: number, k: keyof MLine, v: string) =>
    setMlines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));
  const mTotal = mlines.reduce((s, l) => s + nn(l.amount), 0);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    if (!coBook) {
      setErr('select the configured book first');
      return;
    }
    setBusy(true);
    try {
      if (multi) {
        const lines = mlines
          .filter((l) => l.partyAc.trim() && nn(l.amount) > 0)
          .map((l) => ({
            partyAc: l.partyAc.trim(),
            partyName: l.partyName || undefined,
            amount: nn(l.amount),
            kasar: l.kasar ? nn(l.kasar) : undefined,
            itDesc: l.itDesc || undefined,
          }));
        if (!lines.length) {
          setErr('add at least one line (party + amount)');
          return;
        }
        const r = await post<{ vchNo: number; total?: number }>(`${ep}/multi`, {
          coBook,
          vchDate,
          mode,
          bankAc: bankAc || undefined,
          chqNo: chqNo || undefined,
          empCode: empCode || undefined,
          lines,
        });
        setRes({ ...r, coBook });
        setMlines([mblank()]);
      } else {
        const r = await post<{ vchNo: number; total?: number }>(ep, {
          coBook,
          vchDate,
          partyAc,
          partyName: partyName || undefined,
          amount: Number(amount),
          mode,
          bankAc: bankAc || undefined,
          chqNo: chqNo || undefined,
          pan: pan || undefined,
          kasar: kasar ? Number(kasar) : undefined,
          ...(kind === 'receipt' && mode === 'card'
            ? {
                cardCommissionPct: cardCommissionPct ? Number(cardCommissionPct) : undefined,
                bankName: bankName || undefined,
              }
            : {}),
          ...(kind === 'receipt' && mode === 'upi'
            ? { upiId: upiId || undefined, bankName: bankName || undefined }
            : {}),
        });
        setRes({ ...r, coBook });
      }
    } catch (e) {
      // `detail` carries the database reason behind an `invalid-data` refusal (txn.ts run()).
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.detail || e.body?.error || e.message
          : 'failed',
      );
    } finally {
      setBusy(false);
    }
  }

  const bankNeeded = mode !== 'cash';

  return (
    <div>
      <h1>
        {title}{' '}
        <label style={{ fontSize: 13, fontWeight: 400, marginLeft: 12 }}>
          <input type="checkbox" checked={multi} onChange={(e) => setMulti(e.target.checked)} />{' '}
          Multi-line
        </label>
      </h1>
      <RateTicker />
      {!multi && <PartyBalance acCode={partyAc} />}
      <form className="panel" onSubmit={submit}>
        <div className="row">
          <div className="field">
            <label>Mode</label>
            <select aria-label="Mode" value={mode} onChange={(e) => setMode(e.target.value)}>
              <option value="cash">CASH</option>
              <option value="bank">BANK</option>
              <option value="card">CARD</option>
              <option value="upi">UPI</option>
              <option value="cheque">CHEQUE</option>
            </select>
          </div>
          <div className="field">
            <label>Book</label>
            <BookSelect value={coBook} onChange={setCoBook} mainBooks={mainBooks} />
          </div>
          <div className="field">
            <label>Date</label>
            <input
              type="date"
              aria-label="Voucher date"
              value={vchDate}
              onChange={(e) => setVchDate(e.target.value)}
              required
            />
          </div>
          {bankNeeded && (
            <div className="field">
              <label>Bank AC</label>
              <LookupPicker
                entity="accounts"
                value={bankAc}
                onChange={setBankAc}
                ariaLabel="Bank account"
              />
            </div>
          )}
          {mode === 'cheque' && (
            <>
              <div className="field">
                <label>Cheque No</label>
                <input value={chqNo} onChange={(e) => setChqNo(e.target.value)} />
              </div>
              <div className="field" style={{ minWidth: 260 }}>
                <label>Chq Ac Name</label>
                <input
                  value={chqPrintName}
                  onChange={(e) => setChqPrintName(e.target.value)}
                  placeholder="name to print on cheque"
                />
              </div>
            </>
          )}
          <div className="field">
            <label>Employee</label>
            <LookupPicker entity="employees" value={empCode} onChange={setEmpCode} />
          </div>
          {!multi && (
            <>
              <div className="field">
                <label>Party (AC_CODE)</label>
                <LookupPicker
                  entity="accounts"
                  value={partyAc}
                  onChange={setPartyAc}
                  ariaLabel="Party account"
                  onPick={(r) => {
                    const name = String(r.name || '');
                    setPartyName(name);
                    if (!chqPrintName.trim()) setChqPrintName(name);
                  }}
                />
              </div>
              <div className="field">
                <label>Party Name</label>
                <input value={partyName} onChange={(e) => setPartyName(e.target.value)} />
              </div>
              <div className="field">
                <label>Amount</label>
                <input
                  aria-label="Amount"
                  value={amount}
                  onChange={(e) => setAmount(e.target.value)}
                  required={!multi}
                />
              </div>
              {kind === 'receipt' && mode === 'card' && (
                <>
                  <div className="field">
                    <label>Card commission %</label>
                    <input
                      value={cardCommissionPct}
                      onChange={(e) => setCardCommissionPct(e.target.value)}
                    />
                  </div>
                  <div className="field">
                    <label>Acquiring bank</label>
                    <input value={bankName} onChange={(e) => setBankName(e.target.value)} />
                  </div>
                </>
              )}
              {kind === 'receipt' && mode === 'upi' && (
                <>
                  <div className="field">
                    <label>UPI txn / VPA</label>
                    <input value={upiId} onChange={(e) => setUpiId(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>UPI handle</label>
                    <input value={bankName} onChange={(e) => setBankName(e.target.value)} />
                  </div>
                </>
              )}
              <div className="field">
                <label>PAN (if &gt; cash limit)</label>
                <input value={pan} onChange={(e) => setPan(e.target.value)} />
              </div>
              <div className="field">
                <label>Kasar ₹ (write-off)</label>
                <input
                  aria-label="Kasar ₹ (write-off)"
                  value={kasar}
                  onChange={(e) => setKasar(e.target.value)}
                />
              </div>
            </>
          )}
        </div>

        {multi && (
          <div style={{ overflow: 'auto', marginTop: 8 }}>
            <table className="grid" onKeyDown={handleGridKey}>
              <thead>
                <tr>
                  <th>Party</th>
                  <th>Name</th>
                  <th className="num">Amount</th>
                  <th className="num">Kasar</th>
                  <th>Description</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {mlines.map((l, i) => (
                  <tr key={i}>
                    <td>
                      <LookupPicker
                        entity="accounts"
                        value={l.partyAc}
                        onChange={(v) => setM(i, 'partyAc', v)}
                        onPick={(r) => setM(i, 'partyName', String(r.name || ''))}
                        style={{ width: 130 }}
                      />
                    </td>
                    <td>
                      <input
                        value={l.partyName}
                        onChange={(e) => setM(i, 'partyName', e.target.value)}
                        style={{ width: 150 }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={l.amount}
                        onChange={(e) => setM(i, 'amount', e.target.value)}
                        style={{ width: 100, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={l.kasar}
                        onChange={(e) => setM(i, 'kasar', e.target.value)}
                        style={{ width: 70, textAlign: 'right' }}
                      />
                    </td>
                    <td>
                      <input
                        value={l.itDesc}
                        onChange={(e) => setM(i, 'itDesc', e.target.value)}
                        style={{ width: 160 }}
                      />
                    </td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() =>
                          setMlines((ls) =>
                            ls.length > 1 ? ls.filter((_, j) => j !== i) : [mblank()],
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
                    Total
                  </td>
                  <td className="num">
                    <b>{mTotal.toLocaleString('en-IN')}</b>
                  </td>
                  <td colSpan={3}></td>
                </tr>
              </tfoot>
            </table>
            <button
              type="button"
              className="ghost"
              style={{ marginTop: 8 }}
              onClick={() => setMlines((ls) => [...ls, mblank()])}
            >
              + Add line
            </button>
          </div>
        )}
        <div style={{ marginTop: 10 }}>
          <button className="primary" disabled={busy || !coBook}>
            {busy ? 'Saving…' : `Save ${title}`}
          </button>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Saved — Voucher #{res.vchNo}
            {res.total != null ? ` · total ₹${Number(res.total).toLocaleString('en-IN')}` : ''}
          </div>
          <div className="toolbar" style={{ marginTop: 6 }}>
            <button
              type="button"
              className="ghost"
              onClick={() =>
                window.open(
                  `/api/finance/${kind}-voucher?coBook=${encodeURIComponent(res.coBook)}&vchNo=${encodeURIComponent(String(res.vchNo))}&format=html`,
                  '_blank',
                )
              }
            >
              View {title} Voucher
            </button>
            {mode === 'cheque' && (
              <Link
                className="ghost"
                href={`/txn/cheque-print?payee=${encodeURIComponent((chqPrintName || partyName).trim())}&amount=${encodeURIComponent(String(amount || res.total || ''))}&chqNo=${encodeURIComponent(chqNo.trim())}&acPayee=true`}
              >
                Cheque Print
              </Link>
            )}
          </div>
        </div>
      )}
    </div>
  );
}
