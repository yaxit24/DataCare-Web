'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

/** One open-bill row in the grid: the server-listed figures plus the user-entered receive / kasar. */
interface BillRow {
  coBook: string;
  vchNo: string;
  billAmt: number;
  recAmt: number;
  kasarAmt: number;
  openBal: number;
  rec: string; // editable "Receive" against this bill
  kasar: string; // editable write-off (kasar) against this bill
}

const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;
const inr = (x: number) => r2(x).toLocaleString('en-IN');

/**
 * BILL-TO-BILL settlement (desktop TR_BILL_TO). Pick a party and the page lists that party's
 * OUTSTANDING bills (open balance = BILL_AMT − REC_AMT − KASAR_AMT) from BILL_OS_DATA via
 * GET /bill-to-bill/open?acCode=. Enter a Receive (and optional Kasar write-off) against the bills you
 * want to clear, then Settle — which POSTs /bill-to-bill/settle { acCode, allocations } to add
 * REC_AMT/KASAR_AMT onto each chosen bill. The server refuses to overpay a bill beyond its open
 * balance; open balances refresh after a successful settlement.
 */
export default function BillToBillPage() {
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [bills, setBills] = useState<BillRow[]>([]);
  const [loaded, setLoaded] = useState(false);
  const [result, setResult] = useState<{
    settled: number;
    totalRec: number;
    totalKasar: number;
  } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loading, setLoading] = useState(false);
  const [tenders, setTenders] = useState<{ mode: string; bankAc: string; amount: string }[]>([
    { mode: 'cash', bankAc: '', amount: '' },
  ]);
  const setTn = (i: number, k: 'mode' | 'bankAc' | 'amount', v: string) =>
    setTenders((ts) => ts.map((t, j) => (j === i ? { ...t, [k]: v } : t)));
  // P1-5. The tender split is the operator-authored grid on this page; the bill list above it is a
  // selection of fetched rows, so the keyboard contract applies here only. There is no blank-row
  // factory, so the literal below matches the "Add tender" button (see the onClick further down).
  const handleTenderGridKey = useGridKeyboard({
    rowCount: tenders.length,
    onAppendRow: () => setTenders((ts) => [...ts, { mode: 'cash', bankAc: '', amount: '' }]),
    onRemoveRow: (row) => {
      setTenders((ts) =>
        ts.length === 1
          ? [{ mode: 'cash', bankAc: '', amount: '' }]
          : ts.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const tenderSum =
    Math.round(tenders.reduce((s, t) => s + (Number(t.amount) || 0), 0) * 100) / 100;

  async function loadBills(code: string) {
    setErr('');
    setResult(null);
    setBills([]);
    setLoaded(false);
    if (!code.trim()) return;
    setLoading(true);
    try {
      const rows = (await get(`/bill-to-bill/open?acCode=${encodeURIComponent(code)}`)) as any[];
      setBills(
        (rows || []).map((b) => ({
          coBook: String(b.coBook ?? ''),
          vchNo: String(b.vchNo ?? ''),
          billAmt: Number(b.billAmt ?? 0),
          recAmt: Number(b.recAmt ?? 0),
          kasarAmt: Number(b.kasarAmt ?? 0),
          openBal: Number(b.openBal ?? 0),
          rec: '',
          kasar: '',
        })),
      );
      setLoaded(true);
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || e.message
          : 'failed to load bills',
      );
    } finally {
      setLoading(false);
    }
  }

  const setRow = (i: number, k: 'rec' | 'kasar', v: string) =>
    setBills((bs) => bs.map((b, j) => (j === i ? { ...b, [k]: v } : b)));

  // Per-row applied (rec + kasar) and whether it overpays that bill's open balance.
  const rowApplied = (b: BillRow) => r2(n(b.rec) + n(b.kasar));
  const rowOver = (b: BillRow) => rowApplied(b) > r2(b.openBal) + 0.005;

  const totRec = r2(bills.reduce((s, b) => s + n(b.rec), 0));
  const totKasar = r2(bills.reduce((s, b) => s + n(b.kasar), 0));
  const allocCount = bills.filter((b) => rowApplied(b) > 0.005).length;
  const anyOver = bills.some(rowOver);
  const tenderMismatch = tenderSum > 0.005 && Math.abs(tenderSum - totRec) > 0.005;
  const canSubmit = !!acCode.trim() && allocCount >= 1 && !anyOver && !tenderMismatch;

  async function settle(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const allocations = bills
        .filter((b) => rowApplied(b) > 0.005)
        .map((b) => ({
          coBook: b.coBook,
          vchNo: b.vchNo,
          recAmt: n(b.rec) || undefined,
          kasarAmt: n(b.kasar) || undefined,
        }));
      const tenderRows = tenders
        .filter((t) => Number(t.amount) > 0)
        .map((t) => ({ mode: t.mode, bankAc: t.bankAc || undefined, amount: Number(t.amount) }));
      const res = (await post('/bill-to-bill/settle', {
        acCode,
        allocations,
        ...(tenderRows.length ? { tenders: tenderRows } : {}),
      })) as { settled: number; totalRec: number; totalKasar: number };
      setResult(res);
      await loadBills(acCode); // refresh open balances after settlement
    } catch (e) {
      setErr(
        e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'settlement failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Bill To Bill</h1>
      <form onSubmit={settle}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Party Code</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={(v) => {
                  setAcCode(v);
                  setLoaded(false);
                  setBills([]);
                  setResult(null);
                  setErr('');
                }}
                onPick={(r) => {
                  setAcCode(String(r.code));
                  setAcName(String(r.name || ''));
                  loadBills(String(r.code));
                }}
                style={{ width: 200 }}
              />
            </div>
            <div className="field" style={{ flex: 1 }}>
              <label>Party Name</label>
              <input value={acName} readOnly placeholder="—" />
            </div>
            <div className="field">
              <label>&nbsp;</label>
              <button
                type="button"
                className="ghost"
                disabled={!acCode.trim() || loading}
                onClick={() => loadBills(acCode)}
              >
                {loading ? 'Loading…' : 'Load bills'}
              </button>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Outstanding Bills</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Book</th>
                <th>Voucher</th>
                <th className="num">Bill Amt</th>
                <th className="num">Recd</th>
                <th className="num">Kasar</th>
                <th className="num">Open Bal</th>
                <th className="num">Receive</th>
                <th className="num">Kasar (w/off)</th>
                <th className="num">New Open</th>
              </tr>
            </thead>
            <tbody>
              {bills.map((b, i) => {
                const applied = rowApplied(b);
                const over = rowOver(b);
                const newOpen = r2(b.openBal - applied);
                return (
                  <tr key={b.coBook + '/' + b.vchNo + i}>
                    <td>{b.coBook}</td>
                    <td>{b.vchNo}</td>
                    <td className="num">{inr(b.billAmt)}</td>
                    <td className="num">{inr(b.recAmt)}</td>
                    <td className="num">{inr(b.kasarAmt)}</td>
                    <td className="num">
                      <b>{inr(b.openBal)}</b>
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 110, textAlign: 'right' }}
                        value={b.rec}
                        onChange={(e) => setRow(i, 'rec', e.target.value)}
                        placeholder="0.00"
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 100, textAlign: 'right' }}
                        value={b.kasar}
                        onChange={(e) => setRow(i, 'kasar', e.target.value)}
                        placeholder="0.00"
                      />
                    </td>
                    <td className="num" style={{ color: over ? 'crimson' : undefined }}>
                      {inr(newOpen)}
                      {over ? ' ⚠' : ''}
                    </td>
                  </tr>
                );
              })}
              {loaded && bills.length === 0 && (
                <tr>
                  <td colSpan={9} className="muted" style={{ textAlign: 'center' }}>
                    No outstanding bills for this party.
                  </td>
                </tr>
              )}
              {!loaded && (
                <tr>
                  <td colSpan={9} className="muted" style={{ textAlign: 'center' }}>
                    Pick a party to list their outstanding bills.
                  </td>
                </tr>
              )}
            </tbody>
            {bills.length > 0 && (
              <tfoot>
                <tr>
                  <td colSpan={6} style={{ textAlign: 'right', fontWeight: 600 }}>
                    Totals
                  </td>
                  <td className="num">
                    <b>{inr(totRec)}</b>
                  </td>
                  <td className="num">
                    <b>{inr(totKasar)}</b>
                  </td>
                  <td></td>
                </tr>
              </tfoot>
            )}
          </table>

          <div
            style={{ marginTop: 12, borderTop: '1px solid var(--border,#e5e7eb)', paddingTop: 10 }}
          >
            <h3 style={{ margin: '0 0 6px' }}>
              Tender{' '}
              <span className="muted" style={{ fontWeight: 400 }}>
                — split the receipt across cash / bank (Σ must equal Receiving)
              </span>
            </h3>
            <table className="grid" style={{ maxWidth: 520 }} onKeyDown={handleTenderGridKey}>
              <thead>
                <tr>
                  <th>Mode</th>
                  <th>Bank A/c</th>
                  <th className="num">Amount</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {tenders.map((t, i) => (
                  <tr key={i}>
                    <td>
                      <select value={t.mode} onChange={(e) => setTn(i, 'mode', e.target.value)}>
                        <option value="cash">Cash</option>
                        <option value="bank">Bank</option>
                        <option value="cheque">Cheque</option>
                        <option value="card">Card</option>
                        <option value="upi">UPI</option>
                      </select>
                    </td>
                    <td>
                      {t.mode === 'cash' ? (
                        <span className="muted">—</span>
                      ) : (
                        <LookupPicker
                          entity="accounts"
                          value={t.bankAc}
                          onChange={(v) => setTn(i, 'bankAc', v)}
                          style={{ width: 140 }}
                        />
                      )}
                    </td>
                    <td className="num">
                      <input
                        value={t.amount}
                        onChange={(e) => setTn(i, 'amount', e.target.value)}
                        style={{ width: 100, textAlign: 'right' }}
                      />
                    </td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() =>
                          setTenders((ts) =>
                            ts.length > 1
                              ? ts.filter((_, j) => j !== i)
                              : [{ mode: 'cash', bankAc: '', amount: '' }],
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
            <div className="toolbar" style={{ marginTop: 6 }}>
              <button
                type="button"
                className="ghost"
                onClick={() =>
                  setTenders((ts) => [...ts, { mode: 'cash', bankAc: '', amount: '' }])
                }
              >
                + Tender
              </button>
              <span className="spacer" />
              <span className={tenderMismatch ? 'msg err' : 'muted'} style={{ margin: 0 }}>
                Tender ₹{inr(tenderSum)} vs Receiving ₹{inr(totRec)}
                {tenderMismatch
                  ? ' — must match'
                  : tenderSum > 0.005
                    ? ' ✓'
                    : ' (blank = all cash)'}
              </span>
            </div>
          </div>

          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Receiving ₹{inr(totRec)} · Kasar ₹{inr(totKasar)} · <b>{allocCount}</b>{' '}
              {allocCount === 1 ? 'bill' : 'bills'}
            </span>
            <button className="primary" disabled={busy || !canSubmit}>
              {busy ? 'Settling…' : 'Settle'}
            </button>
          </div>
          {anyOver && (
            <div className="msg err" style={{ marginTop: 6 }}>
              A receive + kasar exceeds a bill&apos;s open balance — reduce it before settling.
            </div>
          )}
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Settled {result.settled} {result.settled === 1 ? 'bill' : 'bills'} — Received ₹
            {inr(Number(result.totalRec ?? 0))} · Kasar ₹{inr(Number(result.totalKasar ?? 0))}
          </div>
        </div>
      )}
    </div>
  );
}
