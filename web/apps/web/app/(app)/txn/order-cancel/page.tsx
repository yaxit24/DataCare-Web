'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, del, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

interface Order {
  vchNo: string;
  book: string;
  vchDate: string | null;
  acCode: string;
  acName: string | null;
  total: number;
  advance: number;
  delDate: string | null;
}
const money = (n: number) =>
  Number(n || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });

export default function OrderCancelPage() {
  const [orders, setOrders] = useState<Order[]>([]);
  // The party on the highlighted order owns the photograph.
  const [imageRow, setImageRow] = useState(0);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const [cancelling, setCancelling] = useState<string | null>(null);
  // Refund flow (desktop Order Cancel: PaiidAc + Paid Amt + Kasar)
  const [refundFor, setRefundFor] = useState<Order | null>(null);
  const [paidAc, setPaidAc] = useState('CASH');
  const [paidAmt, setPaidAmt] = useState('');
  const [kasarAmt, setKasarAmt] = useState('');

  const load = useCallback(async () => {
    setBusy(true);
    try {
      setOrders(await get<Order[]>('/sales-orders'));
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.error || e.message : 'failed to load',
      });
    } finally {
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void load();
  }, [load]);

  function openRefund(o: Order) {
    setRefundFor(o);
    setPaidAc('CASH');
    setPaidAmt(String(o.advance || 0));
    setKasarAmt('');
    setMsg(null);
  }

  async function voidOrder(o: Order) {
    if (
      !window.confirm(
        `Void order #${o.vchNo} (${o.acName || o.acCode})? This reverses the order + any advance by voucher key.`,
      )
    )
      return;
    setCancelling(o.vchNo);
    setMsg(null);
    try {
      await del(`/sales-orders/${encodeURIComponent(o.vchNo)}`);
      setMsg({ kind: 'ok', text: `Order #${o.vchNo} voided` });
      await load();
    } catch (e) {
      setMsg({
        kind: 'err',
        text:
          e instanceof ApiError
            ? e.body?.detail || e.body?.message || e.body?.error || 'void failed'
            : 'void failed',
      });
    } finally {
      setCancelling(null);
    }
  }

  async function submitRefund() {
    if (!refundFor) return;
    setCancelling(refundFor.vchNo);
    setMsg(null);
    try {
      const r = await post<{ vchNo: number; refunded: number; kasar: number }>(
        `/sales-orders/${encodeURIComponent(refundFor.vchNo)}/cancel-refund`,
        {
          paidAc: paidAc.trim() || 'CASH',
          paidAmt: Number(paidAmt || 0),
          kasarAmt: Number(kasarAmt || 0),
        },
      );
      setMsg({
        kind: 'ok',
        text: `Order #${refundFor.vchNo} cancelled — refunded ₹${money(r.refunded)} via ${paidAc}${r.kasar ? ` (kasar ₹${money(r.kasar)})` : ''}`,
      });
      setRefundFor(null);
      await load();
    } catch (e) {
      setMsg({
        kind: 'err',
        text:
          e instanceof ApiError
            ? e.body?.detail || e.body?.message || e.body?.error || 'refund failed'
            : 'refund failed',
      });
    } finally {
      setCancelling(null);
    }
  }

  return (
    <div>
      <h1>
        Order Cancel{' '}
        <span className="muted">— void, or cancel with a refund through a chosen account</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}

      {refundFor && (
        <div className="panel">
          <h2>
            Refund &amp; cancel order #{refundFor.vchNo}{' '}
            <span className="muted">
              — {refundFor.acName || refundFor.acCode} · advance ₹{money(refundFor.advance)}
            </span>
          </h2>
          <div className="row" style={{ alignItems: 'flex-end', gap: 12 }}>
            <div className="field">
              <label>Refund via (PaiidAc)</label>
              <LookupPicker
                entity="accounts"
                value={paidAc}
                onChange={setPaidAc}
                placeholder="CASH"
              />
            </div>
            <div className="field">
              <label>Paid Amt</label>
              <input
                value={paidAmt}
                onChange={(e) => setPaidAmt(e.target.value)}
                style={{ width: 120, textAlign: 'right' }}
              />
            </div>
            <div className="field">
              <label>Kasar (write-off)</label>
              <input
                value={kasarAmt}
                onChange={(e) => setKasarAmt(e.target.value)}
                style={{ width: 120, textAlign: 'right' }}
              />
            </div>
            <button
              type="button"
              className="primary"
              disabled={cancelling === refundFor.vchNo}
              onClick={submitRefund}
            >
              {cancelling === refundFor.vchNo ? 'Processing…' : 'Refund & Cancel'}
            </button>
            <button type="button" className="ghost" onClick={() => setRefundFor(null)}>
              Close
            </button>
          </div>
          <p className="muted" style={{ margin: '6px 0 0' }}>
            Posts Dr customer (Paid + Kasar) / Cr {paidAc || 'CASH'} (refund) + Cr KASAR
            (write-off), and records an SL_ORD_ADJ row.
          </p>
        </div>
      )}

      <div className="panel" style={{ overflow: 'auto' }}>
        <div className="toolbar">
          <h2>{orders.length} order(s)</h2>
          <span className="spacer" />
          <button type="button" className="ghost" onClick={() => load()} disabled={busy}>
            {busy ? 'Loading…' : 'Refresh'}
          </button>
        </div>
        <table className="grid">
          <thead>
            <tr>
              <th>Vch</th>
              <th>Date</th>
              <th>Customer</th>
              <th className="num">Total</th>
              <th className="num">Advance</th>
              <th>Delivery</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {orders.map((o) => (
              <tr key={`${o.book}-${o.vchNo}`}>
                <td>{o.vchNo}</td>
                <td>{o.vchDate ? String(o.vchDate).slice(0, 10) : ''}</td>
                <td>{o.acName || o.acCode}</td>
                <td className="num">{money(o.total)}</td>
                <td className="num">{o.advance ? money(o.advance) : ''}</td>
                <td>
                  {o.delDate ? String(o.delDate).slice(0, 10) : <span className="muted">—</span>}
                </td>
                <td style={{ whiteSpace: 'nowrap' }}>
                  {o.advance > 0 && (
                    <button
                      type="button"
                      className="primary"
                      style={{ marginRight: 6 }}
                      disabled={cancelling === o.vchNo}
                      onClick={() => openRefund(o)}
                    >
                      Refund…
                    </button>
                  )}
                  <button
                    type="button"
                    className="danger"
                    disabled={cancelling === o.vchNo}
                    onClick={() => voidOrder(o)}
                  >
                    {cancelling === o.vchNo ? '…' : 'Void'}
                  </button>
                </td>
              </tr>
            ))}
            {orders.length === 0 && !busy && (
              <tr>
                <td colSpan={7} className="muted">
                  No sales orders.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
      <EntityImagePanel
        entityType="AC"
        entityKey={orders[imageRow]?.acCode ?? ''}
        instance={0}
        label="Party photo"
        testId="order-cancel-image"
      />
    </div>
  );
}
