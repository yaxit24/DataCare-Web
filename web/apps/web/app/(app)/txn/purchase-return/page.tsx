'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';
import { VoucherList } from '../../../../components/VoucherList';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

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

export default function PurchaseReturnPage() {
  const { coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [billNo, setBillNo] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [lines, setLines] = useState<Line[]>([blank()]);
  // The desktop's image buttons act on the CURRENT grid row, so the row that last held focus
  // owns the photograph. It persists after blur so clicking the panel does not clear it.
  const [imageRow, setImageRow] = useState(0);
  const [tender, setTender] = useState<Tender>({});
  const [result, setResult] = useState<any>(null);
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
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
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
        cashAmt: n(String(tender.cashAmt ?? '')),
        chequeAmt: n(String(tender.chequeAmt ?? '')),
        cardAmt: n(String(tender.cardAmt ?? '')),
        upiAmt: n(String(tender.upiAmt ?? '')),
        kasar: n(String(tender.kasar ?? '')),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
      };
      setResult(await post('/purchase-returns', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Purchase Return</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="PRT" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Supplier (AC_CODE)</label>
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
              <label>Supplier Name</label>
              <input value={acName} onChange={(e) => setAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Orig Bill No</label>
              <input value={billNo} onChange={(e) => setBillNo(e.target.value)} />
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
        <TenderPanel
          total={totalPrev}
          value={tender}
          onChange={setTender}
          title="refund received from supplier now (blank = credit their account)"
        />
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Return saved — Voucher #{result.vchNo} · debited supplier ₹
            {Number(result.totals?.total ?? 0).toLocaleString('en-IN')}
          </div>
        </div>
      )}
      <VoucherList
        table="PR_DATA"
        book={coBook}
        deleteBase="/purchase-returns"
        reloadKey={result?.vchNo}
      />
      {/* Desktop BtnImgS / BtnImgC / BtnImgD photograph the tag on the current grid row. */}
      <EntityImagePanel
        entityType="TAG"
        entityKey={lines[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="purchase-return-image"
      />
    </div>
  );
}
