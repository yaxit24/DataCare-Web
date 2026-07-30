'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';
import { VoucherList } from '../../../../components/VoucherList';

/** Other / expense purchase (TR_OTH_PURC) — non-stock buying (freight, packing, repairs…) with GST
 *  input credit. Dr expense + Dr input-GST / Cr supplier → PAY_DATA + TAX_DATA + BILL_OS. No inventory. */
interface Row {
  expenseAc: string;
  amount: string;
  description: string;
  hsnCode: string;
  taxType: 'F' | 'R';
  taxPct: string;
}
const blank = (): Row => ({
  expenseAc: '',
  amount: '',
  description: '',
  hsnCode: '',
  taxType: 'F',
  taxPct: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function OtherPurchasePage() {
  const [f, setF] = useState({
    acCode: '',
    acName: '',
    billNo: '',
    taxRatePct: '18',
    interState: false,
  });
  const [rows, setRows] = useState<Row[]>([blank()]);
  const [tender, setTender] = useState<Tender>({});
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (k: keyof typeof f, v: string | boolean) => setF((x) => ({ ...x, [k]: v }));
  const setRow = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));

  const lineCalc = (r: Row) => {
    const pct = r.taxPct.trim() ? n(r.taxPct) : n(f.taxRatePct);
    const amt = n(r.amount);
    const isR = r.taxType === 'R';
    const base = isR ? r2((amt * 100) / (100 + pct)) : amt;
    const tax = isR ? r2(amt - base) : r2((amt * pct) / 100);
    return { base, tax, gross: r2(base + tax) };
  };
  const taxable = r2(rows.reduce((s, r) => s + (r.expenseAc.trim() ? lineCalc(r).base : 0), 0));
  const tax = r2(rows.reduce((s, r) => s + (r.expenseAc.trim() ? lineCalc(r).tax : 0), 0));
  const total = Math.round(taxable + tax);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    if (!f.acCode.trim()) {
      setMsg({ kind: 'err', text: 'supplier is required' });
      return;
    }
    const lines = rows
      .filter((r) => r.expenseAc.trim() && n(r.amount) > 0)
      .map((r) => ({
        expenseAc: r.expenseAc.trim(),
        amount: n(r.amount),
        description: r.description.trim() || undefined,
        hsnCode: r.hsnCode.trim() || undefined,
        taxType: r.taxType,
        taxPct: r.taxPct.trim() ? n(r.taxPct) : undefined,
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one expense line (account + amount)' });
      return;
    }
    setBusy(true);
    try {
      const r = await post('/other-purchase', {
        acCode: f.acCode.trim(),
        acName: f.acName || undefined,
        billNo: f.billNo || undefined,
        taxRatePct: Number(f.taxRatePct || 0),
        interState: f.interState,
        lines,
        cashAmt: n(String(tender.cashAmt ?? '')),
        chequeAmt: n(String(tender.chequeAmt ?? '')),
        cardAmt: n(String(tender.cardAmt ?? '')),
        upiAmt: n(String(tender.upiAmt ?? '')),
        kasar: n(String(tender.kasar ?? '')),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
      });
      setMsg({
        kind: 'ok',
        text: `Saved — voucher #${r.vchNo}, total ₹${Number(r.totals?.total ?? total).toLocaleString('en-IN')}`,
      });
      setF({ acCode: '', acName: '', billNo: '', taxRatePct: '18', interState: false });
      setRows([blank()]);
      setTender({});
    } catch (err) {
      setMsg({
        kind: 'err',
        text:
          err instanceof ApiError
            ? err.body?.detail || err.body?.message || err.body?.error || 'failed'
            : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Other / Expense Purchase <span className="muted">— TR_OTH_PURC (non-stock, GST input)</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field" style={{ flex: 2 }}>
              <label>Supplier</label>
              <LookupPicker
                entity="accounts"
                value={f.acCode}
                onChange={(v) => set('acCode', v)}
                onPick={(r) => {
                  if (!f.acName) set('acName', String(r.name || ''));
                }}
              />
            </div>
            <div className="field">
              <label>Supplier Name</label>
              <input value={f.acName} onChange={(e) => set('acName', e.target.value)} />
            </div>
            <div className="field">
              <label>Bill No</label>
              <input value={f.billNo} onChange={(e) => set('billNo', e.target.value)} />
            </div>
            <div className="field">
              <label>Tax %</label>
              <input value={f.taxRatePct} onChange={(e) => set('taxRatePct', e.target.value)} />
            </div>
            <div className="field">
              <label>Inter-state</label>
              <select
                value={f.interState ? 'y' : 'n'}
                onChange={(e) => set('interState', e.target.value === 'y')}
              >
                <option value="n">No (CGST+SGST)</option>
                <option value="y">Yes (IGST)</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Expense Lines</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Expense account</th>
                <th>Description</th>
                <th>HSN</th>
                <th>Type</th>
                <th className="num">Tax%</th>
                <th className="num">Amount</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="accounts"
                      value={r.expenseAc}
                      onChange={(v) => setRow(i, 'expenseAc', v)}
                      style={{ width: 150 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.description}
                      onChange={(e) => setRow(i, 'description', e.target.value)}
                      style={{ width: 170 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.hsnCode}
                      onChange={(e) => setRow(i, 'hsnCode', e.target.value)}
                      style={{ width: 64 }}
                    />
                  </td>
                  <td>
                    <select
                      value={r.taxType}
                      onChange={(e) => setRow(i, 'taxType', e.target.value)}
                      style={{ width: 100 }}
                      title="F = tax on top; R = amount is tax-inclusive"
                    >
                      <option value="F">F · exclusive</option>
                      <option value="R">R · inclusive</option>
                    </select>
                  </td>
                  <td className="num">
                    <input
                      value={r.taxPct}
                      onChange={(e) => setRow(i, 'taxPct', e.target.value)}
                      placeholder={f.taxRatePct}
                      style={{ width: 50, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.amount}
                      onChange={(e) => setRow(i, 'amount', e.target.value)}
                      style={{ width: 100, textAlign: 'right' }}
                    />
                  </td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setRows((rs) => (rs.length > 1 ? rs.filter((_, j) => j !== i) : [blank()]))
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
                <td colSpan={5} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Taxable / tax / Total
                </td>
                <td className="num">
                  <b>{taxable.toLocaleString('en-IN')}</b> / {tax.toLocaleString('en-IN')} /{' '}
                  <b>{total.toLocaleString('en-IN')}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setRows((rs) => [...rs, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 12 }}>
              POST /other-purchase
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Save Purchase'}
            </button>
          </div>
        </div>
        <TenderPanel
          total={total}
          value={tender}
          onChange={setTender}
          title="pay the vendor now (blank = full on credit)"
        />
      </form>
      <VoucherList table="PAY_DATA" book="OPR" deleteBase="/other-purchase" />
    </div>
  );
}
