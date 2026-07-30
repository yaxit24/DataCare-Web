'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';

interface Line {
  itCode: string;
  tagNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
}
const blank = (): Line => ({
  itCode: 'GOLD',
  tagNo: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function SaleReturnPage() {
  const { coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [billNo, setBillNo] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [origBook, setOrigBook] = useState('SAL');
  const [tender, setTender] = useState<Tender>({});
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [result, setResult] = useState<any>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // Import-from-bill: pull the original sale's customer + items so the return is a click away.
  async function importBill() {
    if (!billNo.trim()) {
      setErr('enter the original bill no first');
      return;
    }
    setErr('');
    try {
      const d: any = await get(
        `/sales-returns/import?vchNo=${encodeURIComponent(billNo.trim())}&coBook=${encodeURIComponent(origBook)}`,
      );
      setAcCode(d.acCode || '');
      setAcName(d.acName || '');
      setTaxRatePct(String(d.taxRatePct ?? 3));
      setInterState(!!d.interState);
      const ls: Line[] = (d.lines || []).map((l: any) => ({
        itCode: l.IT_CODE || 'GOLD',
        tagNo: l.TAG_NO || '',
        pcs: String(l.pcs || 1),
        grossWt: String(l.grossWt || ''),
        netWt: String(l.netWt || ''),
        touch: String(l.touch || ''),
        rate: String(l.rate || ''),
        making: l.labourAmount && l.netWt ? String(r2(l.labourAmount / l.netWt)) : '',
      }));
      setLines(ls.length ? ls : [blank()]);
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || 'import failed'
          : 'import failed',
      );
    }
  }

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

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        acCode,
        acName: acName || undefined,
        billNo: billNo || undefined,
        origVchNo: billNo || undefined,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        cashAmt: Number(tender.cashAmt || 0),
        chequeAmt: Number(tender.chequeAmt || 0),
        cardAmt: Number(tender.cardAmt || 0),
        upiAmt: Number(tender.upiAmt || 0),
        kasar: Number(tender.kasar || 0),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
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
            ...(l.making ? { labourType: 'per_gram', labourRate: n(l.making) } : {}),
          })),
      };
      setResult(await post('/sales-returns', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Sales Return</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="SRT" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
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
              <label>Orig Book</label>
              <input
                value={origBook}
                onChange={(e) => setOrigBook(e.target.value)}
                style={{ width: 64 }}
              />
            </div>
            <div className="field">
              <label>Orig Bill No</label>
              <div style={{ display: 'flex', gap: 4 }}>
                <input value={billNo} onChange={(e) => setBillNo(e.target.value)} />
                <button type="button" className="ghost" onClick={importBill}>
                  Import
                </button>
              </div>
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
          <h2>Returned Items</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
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
              {busy ? 'Saving…' : 'Save Return'}
            </button>
          </div>
        </div>
      </form>

      <TenderPanel
        total={totalPrev}
        value={tender}
        onChange={setTender}
        title="refund to the customer now (blank = full credit note)"
      />

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Return saved — Voucher #{result.vchNo} · credited ₹
            {Number(result.totals?.total ?? 0).toLocaleString('en-IN')} to customer
          </div>
          <div className="toolbar" style={{ marginTop: 6 }}>
            <button
              type="button"
              className="ghost"
              onClick={() =>
                window.open(
                  `/api/sales/credit-note?coBook=${encodeURIComponent(coBook)}&vchNo=${encodeURIComponent(String(result.vchNo))}&format=html`,
                  '_blank',
                )
              }
            >
              View Credit Note
            </button>
          </div>
        </div>
      )}
      <VoucherList
        table="SL_DATA"
        book={coBook}
        deleteBase="/sales-returns"
        printHref={(v) =>
          `/api/sales/credit-note?coBook=${encodeURIComponent(coBook)}&vchNo=${encodeURIComponent(v)}&format=html`
        }
        reloadKey={result?.vchNo}
      />
    </div>
  );
}
