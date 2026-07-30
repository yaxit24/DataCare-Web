'use client';
import { useState } from 'react';
import { post, downloadPdf, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

interface Line {
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
}
const blank = (): Line => ({
  itCode: 'GOLD',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function EstimatePage() {
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [res, setRes] = useState<any>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line preview (matches sales/computeLine): fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
  const calc = (l: Line) => {
    const fine = r2((n(l.netWt) * n(l.touch)) / 100);
    const metal = r2(fine * n(l.rate));
    const mk = r2(n(l.netWt) * n(l.making));
    return { fine, metal, mk, net: r2(metal + mk) };
  };
  const lineNet = lines.reduce((s, l) => s + calc(l).net, 0);
  const taxable = r2(lineNet - n(discountAmount));
  const taxPrev = r2((taxable * n(taxRatePct)) / 100);
  const totalPrev = Math.round(taxable + taxPrev);

  async function compute(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      // compute-only preview — POST /estimate saves no voucher and writes no ledger
      setRes(
        await post('/estimate', {
          acCode: acCode || undefined,
          acName: acName || undefined,
          taxRatePct: Number(taxRatePct),
          interState,
          discountAmount: discountAmount ? Number(discountAmount) : undefined,
          lines: lines
            .filter((l) => l.itCode && (l.netWt || l.rate))
            .map((l) => ({
              itCode: l.itCode,
              pcs: n(l.pcs),
              grossWt: n(l.grossWt),
              netWt: n(l.netWt),
              touch: n(l.touch),
              rate: n(l.rate),
              ...(l.making ? { labourType: 'per_gram', labourRate: n(l.making) } : {}),
            })),
        }),
      );
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || 'failed' : 'failed');
    } finally {
      setBusy(false);
    }
  }

  function pdf() {
    if (!res) return;
    const esc = (s: any) =>
      String(s ?? '').replace(
        /[&<>]/g,
        (c) => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;' })[c] as string,
      );
    const rows = res.lines
      .map(
        (l: any) =>
          `<tr><td>${l.sr}</td><td>${esc(l.itCode)}</td><td style="text-align:right">${l.metal}</td><td style="text-align:right">${l.labour}</td><td style="text-align:right">${l.net}</td></tr>`,
      )
      .join('');
    const t = res.totals;
    const html = `<!doctype html><html><head><meta charset="utf-8"><style>body{font:12px Arial;padding:24px}h1{color:#0b5cab}table{border-collapse:collapse;width:100%}th,td{border:1px solid #bbb;padding:5px 7px;font-size:11px}th{background:#eef3f9}</style></head><body><h1>DHAKAN JEWELLERS</h1><div><b>ESTIMATE / QUOTATION</b> &middot; ${esc(acName || acCode || 'Customer')} &middot; ${new Date().toLocaleDateString('en-IN')}</div><table><thead><tr><th>#</th><th>Item</th><th>Metal</th><th>Labour</th><th>Net</th></tr></thead><tbody>${rows}</tbody></table><p style="text-align:right">Taxable: ${t.taxable} &nbsp; Tax: ${t.tax} &nbsp; <b>Total: ${t.total}</b></p><p class="muted">This is an estimate, not a tax invoice.</p></body></html>`;
    downloadPdf(html, 'estimate');
  }

  return (
    <div>
      <h1>Estimate / Quotation</h1>
      <form onSubmit={compute}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Party (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={setAcCode}
                onPick={(r) => {
                  setAcName(String(r.name || ''));
                  if (r.AC_GST_TYPE) setInterState(String(r.AC_GST_TYPE) !== 'L');
                }}
              />
            </div>
            <div className="field">
              <label>Customer Name</label>
              <input value={acName} onChange={(e) => setAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Tax %</label>
              <input value={taxRatePct} onChange={(e) => setTaxRatePct(e.target.value)} />
            </div>
            <div className="field">
              <label>Discount ₹</label>
              <input value={discountAmount} onChange={(e) => setDiscountAmount(e.target.value)} />
            </div>
            <div className="field">
              <label>Inter-state</label>
              <select
                value={interState ? 'y' : 'n'}
                onChange={(e) => setInterState(e.target.value === 'y')}
              >
                <option value="n">No (CGST+SGST)</option>
                <option value="y">Yes (IGST)</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Items</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Rate</th>
                <th className="num">Making/g</th>
                <th className="num">Fine</th>
                <th className="num">Amount</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => {
                const c = calc(l);
                return (
                  <tr key={i}>
                    <td>
                      <LookupPicker
                        entity="items"
                        value={l.itCode}
                        onChange={(v) => setLine(i, 'itCode', v)}
                        style={{ width: 80 }}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 44, textAlign: 'right' }}
                        value={l.pcs}
                        onChange={(e) => setLine(i, 'pcs', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.grossWt}
                        onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.netWt}
                        onChange={(e) => setLine(i, 'netWt', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 56, textAlign: 'right' }}
                        value={l.touch}
                        onChange={(e) => setLine(i, 'touch', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 72, textAlign: 'right' }}
                        value={l.rate}
                        onChange={(e) => setLine(i, 'rate', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.making}
                        onChange={(e) => setLine(i, 'making', e.target.value)}
                      />
                    </td>
                    <td className="num">{c.fine.toLocaleString('en-IN')}</td>
                    <td className="num">{c.net.toLocaleString('en-IN')}</td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() => setLines((ls) => ls.filter((_, j) => j !== i))}
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
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Taxable ₹{taxable.toLocaleString('en-IN')} · Tax ₹{taxPrev.toLocaleString('en-IN')} ·{' '}
              <b>Total ₹{totalPrev.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Computing…' : 'Compute Estimate'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="toolbar">
            <h2 style={{ margin: 0 }}>Estimate</h2>
            <button className="ghost" onClick={pdf}>
              Download PDF
            </button>
          </div>
          <div className="tiles">
            {Object.entries(res.totals).map(([k, v]) => (
              <div className="tile" key={k}>
                <div className="muted">{k}</div>
                <div className="big kpi">{Number(v).toLocaleString('en-IN')}</div>
              </div>
            ))}
          </div>
        </div>
      )}
    </div>
  );
}
