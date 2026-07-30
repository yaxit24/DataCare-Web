'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

interface Row {
  itCode: string;
  designNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  remark: string;
  // Desktop order-grid columns (TR_SALE_ORD mSG).
  tblCode: string;
  itmColor: string;
  itmSize: string;
  rateFix: string;
  labourType: string;
  karigarName: string;
  rateType: string;
  itType: string;
  prCode: string;
  oldTblCode: string;
  tagStockLess: string;
  designImageId: string;
  huid: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  orderDeliveryDate: string;
  bagWt: string;
  lessWt: string;
  ghtPct: string;
  ghtWt: string;
  westPct: string;
  labourPct: string;
  labourRate: string;
  otherAmount: string;
  mrp: string;
  karigarNetWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  tagCost: string;
  vchSrno: string;
  oldSrNo: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
  dmCode: string;
  dmName: string;
  dmSize: string;
  dmSfNo: string;
  dmColor: string;
  dmOrigin: string;
  dmRemark: string;
  dmLeb: string;
  stonePcsWt: string;
  stoneConPct: string;
  stoneConWt: string;
  stoneRateType: string;
  stoneRate: string;
  stoneLabourRate: string;
  stoneLabourAmount: string;
  stoneKarigarWt: string;
  stoneKarigarLessPct: string;
  stoneKarigarConPct: string;
  stoneKarigarConWt: string;
  stoneKarigarRate: string;
  stoneKarigarAmount: string;
  stoneKarigarLabourRate: string;
  stoneKarigarLabourAmount: string;
  stoneKarigarNetAmount: string;
}
const blank = (): Row => ({
  dmCode: '',
  dmName: '',
  dmSize: '',
  dmSfNo: '',
  dmColor: '',
  dmOrigin: '',
  dmRemark: '',
  dmLeb: '',
  stonePcsWt: '',
  stoneConPct: '',
  stoneConWt: '',
  stoneRateType: '',
  stoneRate: '',
  stoneLabourRate: '',
  stoneLabourAmount: '',
  stoneKarigarWt: '',
  stoneKarigarLessPct: '',
  stoneKarigarConPct: '',
  stoneKarigarConWt: '',
  stoneKarigarRate: '',
  stoneKarigarAmount: '',
  stoneKarigarLabourRate: '',
  stoneKarigarLabourAmount: '',
  stoneKarigarNetAmount: '',
  itCode: '',
  designNo: '',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  remark: '',
  tblCode: '',
  itmColor: '',
  itmSize: '',
  rateFix: '',
  labourType: '',
  karigarName: '',
  rateType: '',
  itType: '',
  prCode: '',
  oldTblCode: '',
  tagStockLess: '',
  designImageId: '',
  huid: '',
  hallmarkId2: '',
  hallmarkId3: '',
  hallmarkId4: '',
  orderDeliveryDate: '',
  bagWt: '',
  lessWt: '',
  ghtPct: '',
  ghtWt: '',
  westPct: '',
  labourPct: '',
  labourRate: '',
  otherAmount: '',
  mrp: '',
  karigarNetWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  tagCost: '',
  vchSrno: '',
  oldSrNo: '',
  hallmarkIdWt: '',
  hallmarkId2Wt: '',
  hallmarkId3Wt: '',
  hallmarkId4Wt: '',
});
const extendedRowFields: Array<[keyof Row, string]> = [
  ['dmCode', 'Diamond Code'],
  ['dmName', 'Diamond Name'],
  ['dmSize', 'Diamond Size'],
  ['dmSfNo', 'Diamond SF No'],
  ['dmColor', 'Diamond Colour'],
  ['dmOrigin', 'Diamond Origin'],
  ['dmRemark', 'Diamond Remark'],
  ['dmLeb', 'Diamond Lab'],
  ['stonePcsWt', 'Stone Pcs Wt'],
  ['stoneConPct', 'Stone Con %'],
  ['stoneConWt', 'Stone Con Wt'],
  ['stoneRateType', 'Stone Rate Type'],
  ['stoneRate', 'Stone Rate'],
  ['stoneLabourRate', 'Stone Lbr Rate'],
  ['stoneLabourAmount', 'Stone Lbr Amt'],
  ['stoneKarigarWt', 'Stone Kr Wt'],
  ['stoneKarigarLessPct', 'Stone Kr Less %'],
  ['stoneKarigarConPct', 'Stone Kr Con %'],
  ['stoneKarigarConWt', 'Stone Kr Con Wt'],
  ['stoneKarigarRate', 'Stone Kr Rate'],
  ['stoneKarigarAmount', 'Stone Kr Amt'],
  ['stoneKarigarLabourRate', 'Stone Kr Lbr Rate'],
  ['stoneKarigarLabourAmount', 'Stone Kr Lbr Amt'],
  ['stoneKarigarNetAmount', 'Stone Kr Net Amt'],
  ['tblCode', 'Counter'],
  ['itmColor', 'Colour'],
  ['itmSize', 'Size'],
  ['rateFix', 'Rate Fix'],
  ['labourType', 'Labour Type'],
  ['karigarName', 'Karigar'],
  ['rateType', 'Rate Type'],
  ['itType', 'Item Type'],
  ['prCode', 'PR Code'],
  ['oldTblCode', 'Old Counter'],
  ['tagStockLess', 'Tag Stock Less'],
  ['designImageId', 'Design Image'],
  ['huid', 'HUID'],
  ['hallmarkId2', 'Hallmark 2'],
  ['hallmarkId3', 'Hallmark 3'],
  ['hallmarkId4', 'Hallmark 4'],
  ['orderDeliveryDate', 'Line Delivery Date'],
  ['bagWt', 'Bag Wt'],
  ['lessWt', 'Less Wt'],
  ['ghtPct', 'Ghat %'],
  ['ghtWt', 'Ghat Wt'],
  ['westPct', 'Wastage %'],
  ['labourPct', 'Labour %'],
  ['labourRate', 'Labour Rate'],
  ['otherAmount', 'Other Amt'],
  ['mrp', 'MRP'],
  ['karigarNetWt', 'Karigar Net Wt'],
  ['karigarTouch', 'Karigar Touch'],
  ['karigarWestPct', 'Karigar West %'],
  ['karigarFine', 'Karigar Fine'],
  ['tagCost', 'Tag Cost'],
  ['vchSrno', 'Vch SrNo'],
  ['oldSrNo', 'Old SrNo'],
  ['hallmarkIdWt', 'HM Wt'],
  ['hallmarkId2Wt', 'HM2 Wt'],
  ['hallmarkId3Wt', 'HM3 Wt'],
  ['hallmarkId4Wt', 'HM4 Wt'],
];
const extendedHeaderFields: Array<[string, string]> = [
  ['billNo', 'Bill No'],
  ['taxCode', 'Tax Code'],
  ['bankAc', 'Bank A/c'],
  ['bankName', 'Bank Name'],
  ['chequeNo', 'Cheque No'],
  ['cardAc', 'Card A/c'],
  ['cardAdj', 'Card Adj'],
  ['cashAc', 'Cash A/c'],
  ['address1', 'Address 1'],
  ['address2', 'Address 2'],
  ['address3', 'Address 3'],
  ['city', 'City'],
  ['mobile', 'Mobile'],
  ['empCode', 'Employee'],
  ['deliveryDate', 'Delivery Date'],
  ['functionDate', 'Function Date'],
  ['upiAmount', 'UPI Amt'],
  ['oldGoldFine', 'Old Gold Fine'],
  ['oldGoldAmount', 'Old Gold Amt'],
  ['oldSilverFine', 'Old Silver Fine'],
  ['oldSilverAmount', 'Old Silver Amt'],
  ['schemeAmount', 'Scheme Amt'],
  ['rateCutRate', 'Rate-cut Rate'],
  ['rateCutFine', 'Rate-cut Fine'],
  ['rateCutAmount', 'Rate-cut Amt'],
  ['adjustGold', 'Adj Gold'],
  ['adjustSilver', 'Adj Silver'],
  ['orderAdjustAmount', 'Order Adj Amt'],
  ['netAmount', 'Net Amt (override)'],
];
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function SalesOrderPage() {
  const [f, setF] = useState({ acCode: '', acName: '', taxRatePct: '3', advanceAmount: '' });
  const [rows, setRows] = useState<Row[]>([blank()]);
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  // Desktop SL_ORD_DATA header fields (TR_SALE_ORD:9120-9161).
  const [header, setHeader] = useState<Record<string, string>>({});
  const [orders, setOrders] = useState<Record<string, any>[]>([]);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (k: keyof typeof f, v: string) => setF((x) => ({ ...x, [k]: v }));
  const setRow = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));

  // line net = (net×touch/100)×rate + net×making/g  (mirrors the backend computation)
  const lineNet = (r: Row) => {
    const fine = r2((n(r.netWt) * n(r.touch)) / 100);
    return r2(fine * n(r.rate) + n(r.netWt) * n(r.making));
  };
  const total = r2(rows.reduce((s, r) => s + (r.itCode.trim() ? lineNet(r) : 0), 0));

  const load = useCallback(async () => {
    setOrders(await get<any[]>('/sales-orders').catch(() => []));
  }, []);
  useEffect(() => {
    load();
  }, [load]);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    if (!f.acCode.trim()) {
      setMsg({ kind: 'err', text: 'customer is required' });
      return;
    }
    const lines = rows
      .filter((r) => r.itCode.trim())
      .map((r) => ({
        itCode: r.itCode.trim(),
        designNo: r.designNo.trim() || undefined,
        pcs: n(r.pcs),
        grossWt: n(r.grossWt),
        netWt: n(r.netWt),
        touch: n(r.touch),
        rate: n(r.rate),
        making: n(r.making),
        remark: r.remark.trim() || undefined,
        tblCode: r.tblCode.trim() || undefined,
        itmColor: r.itmColor.trim() || undefined,
        itmSize: r.itmSize.trim() || undefined,
        rateFix: r.rateFix.trim() || undefined,
        labourType: r.labourType.trim() || undefined,
        karigarName: r.karigarName.trim() || undefined,
        rateType: r.rateType.trim() || undefined,
        itType: r.itType.trim() || undefined,
        prCode: r.prCode.trim() || undefined,
        oldTblCode: r.oldTblCode.trim() || undefined,
        tagStockLess: r.tagStockLess.trim() || undefined,
        designImageId: r.designImageId.trim() || undefined,
        huid: r.huid.trim() || undefined,
        hallmarkId2: r.hallmarkId2.trim() || undefined,
        hallmarkId3: r.hallmarkId3.trim() || undefined,
        hallmarkId4: r.hallmarkId4.trim() || undefined,
        orderDeliveryDate: r.orderDeliveryDate.trim() || undefined,
        bagWt: n(r.bagWt) || undefined,
        lessWt: n(r.lessWt) || undefined,
        ghtPct: n(r.ghtPct) || undefined,
        ghtWt: n(r.ghtWt) || undefined,
        westPct: n(r.westPct) || undefined,
        labourPct: n(r.labourPct) || undefined,
        labourRate: n(r.labourRate) || undefined,
        otherAmount: n(r.otherAmount) || undefined,
        mrp: n(r.mrp) || undefined,
        karigarNetWt: n(r.karigarNetWt) || undefined,
        karigarTouch: n(r.karigarTouch) || undefined,
        karigarWestPct: n(r.karigarWestPct) || undefined,
        karigarFine: n(r.karigarFine) || undefined,
        tagCost: n(r.tagCost) || undefined,
        vchSrno: n(r.vchSrno) || undefined,
        oldSrNo: n(r.oldSrNo) || undefined,
        hallmarkIdWt: n(r.hallmarkIdWt) || undefined,
        hallmarkId2Wt: n(r.hallmarkId2Wt) || undefined,
        hallmarkId3Wt: n(r.hallmarkId3Wt) || undefined,
        hallmarkId4Wt: n(r.hallmarkId4Wt) || undefined,
        // Stone / diamond sub-detail -> SL_ORD_IDTL (TR_SALE_ORD.cs DtIdtl grid).
        dmCode: r.dmCode.trim() || undefined,
        dmName: r.dmName.trim() || undefined,
        dmSize: r.dmSize.trim() || undefined,
        dmSfNo: r.dmSfNo.trim() || undefined,
        dmColor: r.dmColor.trim() || undefined,
        dmOrigin: r.dmOrigin.trim() || undefined,
        dmRemark: r.dmRemark.trim() || undefined,
        dmLeb: r.dmLeb.trim() || undefined,
        stoneRateType: r.stoneRateType.trim() || undefined,
        stonePcsWt: n(r.stonePcsWt) || undefined,
        stoneConPct: n(r.stoneConPct) || undefined,
        stoneConWt: n(r.stoneConWt) || undefined,
        stoneRate: n(r.stoneRate) || undefined,
        stoneLabourRate: n(r.stoneLabourRate) || undefined,
        stoneLabourAmount: n(r.stoneLabourAmount) || undefined,
        stoneKarigarWt: n(r.stoneKarigarWt) || undefined,
        stoneKarigarLessPct: n(r.stoneKarigarLessPct) || undefined,
        stoneKarigarConPct: n(r.stoneKarigarConPct) || undefined,
        stoneKarigarConWt: n(r.stoneKarigarConWt) || undefined,
        stoneKarigarRate: n(r.stoneKarigarRate) || undefined,
        stoneKarigarAmount: n(r.stoneKarigarAmount) || undefined,
        stoneKarigarLabourRate: n(r.stoneKarigarLabourRate) || undefined,
        stoneKarigarLabourAmount: n(r.stoneKarigarLabourAmount) || undefined,
        stoneKarigarNetAmount: n(r.stoneKarigarNetAmount) || undefined,
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one item line' });
      return;
    }
    setBusy(true);
    try {
      const r = await post('/sales-orders', {
        acCode: f.acCode.trim(),
        acName: f.acName || undefined,
        taxRatePct: Number(f.taxRatePct || 0),
        advanceAmount: Number(f.advanceAmount || 0),
        lines,
        billNo: header.billNo || undefined,
        taxCode: header.taxCode || undefined,
        bankAc: header.bankAc || undefined,
        bankName: header.bankName || undefined,
        chequeNo: header.chequeNo || undefined,
        cardAc: header.cardAc || undefined,
        cardAdj: header.cardAdj || undefined,
        cashAc: header.cashAc || undefined,
        address1: header.address1 || undefined,
        address2: header.address2 || undefined,
        address3: header.address3 || undefined,
        city: header.city || undefined,
        mobile: header.mobile || undefined,
        empCode: header.empCode || undefined,
        deliveryDate: header.deliveryDate || undefined,
        functionDate: header.functionDate || undefined,
        upiAmount: header.upiAmount ? Number(header.upiAmount) : undefined,
        oldGoldFine: header.oldGoldFine ? Number(header.oldGoldFine) : undefined,
        oldGoldAmount: header.oldGoldAmount ? Number(header.oldGoldAmount) : undefined,
        oldSilverFine: header.oldSilverFine ? Number(header.oldSilverFine) : undefined,
        oldSilverAmount: header.oldSilverAmount ? Number(header.oldSilverAmount) : undefined,
        schemeAmount: header.schemeAmount ? Number(header.schemeAmount) : undefined,
        rateCutRate: header.rateCutRate ? Number(header.rateCutRate) : undefined,
        rateCutFine: header.rateCutFine ? Number(header.rateCutFine) : undefined,
        rateCutAmount: header.rateCutAmount ? Number(header.rateCutAmount) : undefined,
        adjustGold: header.adjustGold ? Number(header.adjustGold) : undefined,
        adjustSilver: header.adjustSilver ? Number(header.adjustSilver) : undefined,
        orderAdjustAmount: header.orderAdjustAmount ? Number(header.orderAdjustAmount) : undefined,
        netAmount: header.netAmount ? Number(header.netAmount) : undefined,
      });
      setMsg({
        kind: 'ok',
        text: `Order #${r.vchNo} saved — total ₹${Number(r.total).toLocaleString('en-IN')}${r.advance ? `, advance ₹${Number(r.advance).toLocaleString('en-IN')}` : ''}`,
      });
      setF({ acCode: '', acName: '', taxRatePct: '3', advanceAmount: '' });
      setRows([blank()]);
      await load();
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Sales Order</h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field" style={{ flex: 2 }}>
              <label>Customer</label>
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
              <label>Customer Name</label>
              <input value={f.acName} onChange={(e) => set('acName', e.target.value)} />
            </div>
            <div className="field">
              <label>Tax %</label>
              <input value={f.taxRatePct} onChange={(e) => set('taxRatePct', e.target.value)} />
            </div>
            <div className="field">
              <label>Advance ₹</label>
              <input
                value={f.advanceAmount}
                onChange={(e) => set('advanceAmount', e.target.value)}
              />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Order Items</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Design</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">Rate</th>
                <th className="num">Making/g</th>
                <th className="num">Net Amt</th>
                <th>Remark</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={r.itCode}
                      onChange={(v) => setRow(i, 'itCode', v)}
                      style={{ width: 110 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.designNo}
                      onChange={(e) => setRow(i, 'designNo', e.target.value)}
                      style={{ width: 80 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.pcs}
                      onChange={(e) => setRow(i, 'pcs', e.target.value)}
                      style={{ width: 56, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.grossWt}
                      onChange={(e) => setRow(i, 'grossWt', e.target.value)}
                      style={{ width: 76, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.netWt}
                      onChange={(e) => setRow(i, 'netWt', e.target.value)}
                      style={{ width: 76, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.touch}
                      onChange={(e) => setRow(i, 'touch', e.target.value)}
                      style={{ width: 60, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.rate}
                      onChange={(e) => setRow(i, 'rate', e.target.value)}
                      style={{ width: 80, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.making}
                      onChange={(e) => setRow(i, 'making', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    {r.itCode.trim() ? lineNet(r).toLocaleString('en-IN') : ''}
                  </td>
                  <td>
                    <input
                      value={r.remark}
                      onChange={(e) => setRow(i, 'remark', e.target.value)}
                      style={{ width: 120 }}
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
                <td colSpan={8} style={{ textAlign: 'right', fontWeight: 600 }}>
                  Order total (pre-tax)
                </td>
                <td className="num">
                  <b>{total.toLocaleString('en-IN')}</b>
                </td>
                <td colSpan={2}></td>
              </tr>
            </tfoot>
          </table>
          <details style={{ marginTop: 8 }}>
            <summary>Desktop order header fields</summary>
            <div className="row">
              {extendedHeaderFields.map(([key, label]) => (
                <div className="field" key={key}>
                  <label>{label}</label>
                  <input
                    value={header[key] ?? ''}
                    onChange={(e) => setHeader((h) => ({ ...h, [key]: e.target.value }))}
                  />
                </div>
              ))}
            </div>
          </details>
          {rows.map((row, index) => (
            <details key={`ord-row-extra-${index}`} style={{ marginTop: 8 }}>
              <summary>Item row {index + 1} desktop fields</summary>
              <div className="row">
                {extendedRowFields.map(([key, label]) => (
                  <div className="field" key={String(key)}>
                    <label>{label}</label>
                    <input
                      value={String(row[key] ?? '')}
                      onChange={(e) => setRow(index, key, e.target.value)}
                    />
                  </div>
                ))}
              </div>
            </details>
          ))}
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
              POST /sales-orders
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Place Order'}
            </button>
          </div>
        </div>
      </form>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>Recent Orders</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>Order #</th>
              <th>Date</th>
              <th>Customer</th>
              <th>Name</th>
              <th className="num">Total</th>
              <th className="num">Advance</th>
            </tr>
          </thead>
          <tbody>
            {orders.map((o, i) => (
              <tr key={i}>
                <td>{o.vchNo}</td>
                <td>{o.vchDate ? String(o.vchDate).slice(0, 10) : ''}</td>
                <td>{o.acCode}</td>
                <td>{o.acName}</td>
                <td className="num">{Number(o.total).toLocaleString('en-IN')}</td>
                <td className="num">{Number(o.advance).toLocaleString('en-IN')}</td>
              </tr>
            ))}
            {orders.length === 0 && (
              <tr>
                <td colSpan={6} className="muted">
                  No orders.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      <VoucherList
        table="SL_ORD_DATA"
        book="SOR"
        deleteBase="/sales-orders"
        printHref={(v) =>
          `/api/sales/order-confirmation?coBook=SOR&vchNo=${encodeURIComponent(v)}&format=html`
        }
      />
      <EntityImagePanel
        entityType="DESIGN"
        entityKey={rows[imageRow]?.designNo ?? ''}
        instance={0}
        label="Design image"
        testId="sales-order-image"
      />
    </div>
  );
}
