'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

interface Line {
  itCode: string;
  tagNo: string;
  huid: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
}
interface Totals {
  net: number;
  discount: number;
  taxable: number;
  tax: number;
  cgst: number;
  sgst: number;
  igst: number;
  roundOff: number;
  total: number;
}
const blank = (): Line => ({
  itCode: 'GOLD',
  tagNo: '',
  huid: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function HallmarkSalePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [acCode, setAcCode] = useState('WALKIN');
  const [acName, setAcName] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [hmCharge, setHmCharge] = useState('');
  const [cashAmt, setCashAmt] = useState('');
  const [cardAmt, setCardAmt] = useState('');
  const [upiAmt, setUpiAmt] = useState('');
  const [chequeAmt, setChequeAmt] = useState('');
  const [oldGoldNet, setOldGoldNet] = useState('');
  const [oldGoldTouch, setOldGoldTouch] = useState('');
  const [oldGoldRate, setOldGoldRate] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [result, setResult] = useState<{ vchNo: number; totals: Totals } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line preview: fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
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
  const hmAmt = n(hmCharge);
  const hmTax = r2((hmAmt * n(taxRatePct)) / 100);
  const grandTotalPrev = r2(totalPrev + hmAmt + hmTax);
  const oldGoldVal = r2(((n(oldGoldNet) * n(oldGoldTouch)) / 100) * n(oldGoldRate));
  const paid = r2(n(cashAmt) + n(cardAmt) + n(upiAmt) + n(chequeAmt) + oldGoldVal);
  const balanceDue = r2(grandTotalPrev - paid);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const oldGoldAmt = r2(((n(oldGoldNet) * n(oldGoldTouch)) / 100) * n(oldGoldRate));
      const body = {
        coBook,
        coYear,
        lcCode,
        acCode,
        acName: acName || undefined,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        hallmarkAmount: hmCharge ? n(hmCharge) : undefined,
        cashAmt: cashAmt ? n(cashAmt) : undefined,
        cardAmt: cardAmt ? n(cardAmt) : undefined,
        upiAmt: upiAmt ? n(upiAmt) : undefined,
        chequeAmt: chequeAmt ? n(chequeAmt) : undefined,
        oldGold:
          oldGoldAmt > 0
            ? [
                {
                  itCode: 'OG',
                  netWt: n(oldGoldNet),
                  touch: n(oldGoldTouch),
                  rate: n(oldGoldRate),
                  amount: oldGoldAmt,
                },
              ]
            : undefined,
        lines: lines
          .filter((l) => l.itCode && (l.netWt || l.rate))
          .map((l) => ({
            itCode: l.itCode,
            tagNo: l.tagNo || undefined,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
            rate: n(l.rate),
            huid: l.huid || undefined,
            ...(l.making ? { labourType: 'per_gram', labourRate: n(l.making) } : {}),
          })),
      };
      setResult(await post('/sales', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Hallmark Sale <span className="muted">(HUID)</span>
      </h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="HM" />
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
              <label>Hallmark chg ₹</label>
              <input value={hmCharge} onChange={(e) => setHmCharge(e.target.value)} />
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

        <div className="panel">
          <h2>Settlement</h2>
          <div className="row">
            <div className="field">
              <label>Cash ₹</label>
              <input value={cashAmt} onChange={(e) => setCashAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Card ₹</label>
              <input value={cardAmt} onChange={(e) => setCardAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>UPI ₹</label>
              <input value={upiAmt} onChange={(e) => setUpiAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Cheque ₹</label>
              <input value={chequeAmt} onChange={(e) => setChequeAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Net</label>
              <input value={oldGoldNet} onChange={(e) => setOldGoldNet(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Touch%</label>
              <input value={oldGoldTouch} onChange={(e) => setOldGoldTouch(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Rate</label>
              <input value={oldGoldRate} onChange={(e) => setOldGoldRate(e.target.value)} />
            </div>
          </div>
          <div className="muted" style={{ marginTop: 6 }}>
            Old gold ₹{oldGoldVal.toLocaleString('en-IN')} · Paid ₹{paid.toLocaleString('en-IN')} ·{' '}
            <b style={{ color: balanceDue > 0 ? 'var(--err)' : 'var(--ok)' }}>
              Balance due ₹{balanceDue.toLocaleString('en-IN')}
            </b>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Hallmarked Items</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th>HUID</th>
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
                    <td>
                      <LookupPicker
                        entity="tags"
                        value={l.tagNo}
                        onChange={(v) => setLine(i, 'tagNo', v)}
                        style={{ width: 110 }}
                        onPick={(r) =>
                          setLines((ls) =>
                            ls.map((x, j) =>
                              j === i
                                ? {
                                    ...x,
                                    tagNo: String(r.code),
                                    itCode: String(r.name || x.itCode),
                                    netWt: String(r.ITM_NWT ?? x.netWt),
                                    grossWt: String(r.ITM_GWT ?? x.grossWt),
                                    touch: String(r.ITM_TOUCH ?? x.touch),
                                    rate: String(r.ITM_RATE ?? x.rate),
                                  }
                                : x,
                            ),
                          )
                        }
                      />
                    </td>
                    <td>
                      <input
                        style={{ width: 110 }}
                        value={l.huid}
                        onChange={(e) => setLine(i, 'huid', e.target.value)}
                        placeholder="6-char HUID"
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
              Taxable ₹{taxable.toLocaleString('en-IN')} · Tax ₹{taxPrev.toLocaleString('en-IN')}
              {hmAmt > 0
                ? ` · HM ₹${hmAmt.toLocaleString('en-IN')}+tax ₹${hmTax.toLocaleString('en-IN')}`
                : ''}{' '}
              · <b>Total ₹{grandTotalPrev.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Save Hallmark Sale'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Saved — Voucher #{result.vchNo}</div>
          <div className="toolbar">
            <button
              type="button"
              className="ghost"
              onClick={() =>
                window.open(
                  `/api/sales/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(result.vchNo))}`,
                  '_blank',
                )
              }
            >
              View Invoice PDF
            </button>
          </div>
          <div className="tiles">
            {Object.entries(result.totals).map(([k, v]) => (
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
