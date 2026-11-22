'use client';
import { formatDesktopDate } from '@datacare/core';
import { useEffect, useMemo, useRef, useState } from 'react';

/** One order of the OrdNo help (TR_SL_ORD_ADJ.cs:2499-2526). */
export interface PendingOrder {
  ordNo: string;
  acCode: string;
  acName: string;
  ordDate: string;
  ordYear: string;
  ordBook: string;
  hdVchNo: string;
  advAmt: number;
  adjAmt: number;
  openAmt: number;
  tags: OrderTag[];
}

/** One line of the tag grid (MSG_TAG: Sr, TagNo, OrdNo, ItCode, ItName, Counter, Design, Pcs, GrWt, LsWt, NetWt, Mrp). */
export interface OrderTag {
  srNo: number;
  ordNo: string;
  tagNo: string;
  itCode: string;
  itName: string;
  tblCode: string;
  designNo: string;
  pcs: number;
  gwt: number;
  othWt: number;
  nwt: number;
  mrp: number;
}

const money = (n: number) => Number(n || 0).toFixed(2);

/**
 * The desktop's MS_HELP for the OrdNo cell: Party Name, AcCode, VchNo, Order Date, Amount (the advance) and AdjAmt (what
 * sales and cancels already used), ordered by date and number. Typing filters, Up/Down move, Enter picks, Esc closes.
 */
export function OrderCancelOrderHelp({
  orders,
  onPick,
  onClose,
}: {
  orders: PendingOrder[];
  onPick: (order: PendingOrder) => void;
  onClose: () => void;
}) {
  const [filter, setFilter] = useState('');
  const [hi, setHi] = useState(0);
  const input = useRef<HTMLInputElement>(null);
  const shown = useMemo(() => {
    const f = filter.trim().toUpperCase();
    return f
      ? orders.filter((o) =>
          [o.acName, o.acCode, o.ordNo].some((v) => String(v).toUpperCase().includes(f)),
        )
      : orders;
  }, [orders, filter]);
  useEffect(() => input.current?.focus(), []);
  useEffect(() => setHi(0), [filter]);

  function onKeyDown(e: React.KeyboardEvent) {
    if (e.key === 'ArrowDown') {
      e.preventDefault();
      setHi((h) => Math.min(h + 1, shown.length - 1));
    } else if (e.key === 'ArrowUp') {
      e.preventDefault();
      setHi((h) => Math.max(h - 1, 0));
    } else if (e.key === 'Enter') {
      e.preventDefault();
      const order = shown[hi];
      if (order) onPick(order);
    } else if (e.key === 'Escape') {
      e.preventDefault();
      e.stopPropagation();
      onClose();
    }
  }

  return (
    <div
      className="panel"
      role="dialog"
      aria-label="Pending orders"
      data-lookup-open="true"
      onKeyDown={onKeyDown}
      style={{ position: 'relative', zIndex: 5 }}
    >
      <div className="row" style={{ alignItems: 'center' }}>
        <strong>Pending orders</strong>
        <input
          ref={input}
          aria-label="Search pending orders"
          value={filter}
          onChange={(e) => setFilter(e.target.value)}
          placeholder="party, code or order no…"
          style={{ marginLeft: 12, width: 260 }}
        />
        <span className="spacer" />
        <button type="button" className="ghost" onClick={onClose}>
          Close
        </button>
      </div>
      {shown.length === 0 ? (
        <p className="muted">No order has advance left to cancel.</p>
      ) : (
        <table className="grid" style={{ marginTop: 8 }}>
          <thead>
            <tr>
              <th>Party Name</th>
              <th>AcCode</th>
              <th>VchNo</th>
              <th>Order Dt</th>
              <th className="num">Amount</th>
              <th className="num">AdjAmt</th>
            </tr>
          </thead>
          <tbody>
            {shown.map((o, i) => (
              <tr
                key={`${o.ordYear}|${o.ordBook}|${o.ordNo}`}
                aria-selected={i === hi}
                data-order={o.ordNo}
                className={i === hi ? 'sel' : undefined}
                style={i === hi ? { background: 'var(--sel, #dbeafe)' } : undefined}
                onMouseEnter={() => setHi(i)}
                onClick={() => onPick(o)}
              >
                <td>{o.acName}</td>
                <td>{o.acCode}</td>
                <td>{o.ordNo}</td>
                <td>{formatDesktopDate(o.ordDate)}</td>
                <td className="num">{money(o.advAmt)}</td>
                <td className="num">{money(o.adjAmt)}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

/** The tag grid MSG_TAG (MSG_TAG_CLEAR, TR_SL_ORD_ADJ.cs:1478-1543), read-only: the tags the picked orders hold. */
export function OrderCancelTagGrid({ tags }: { tags: OrderTag[] }) {
  const n = (v: number) => Number(v || 0) || 0;
  return (
    <div className="panel" style={{ overflow: 'auto' }}>
      <table className="grid" aria-label="Order tags">
        <thead>
          <tr>
            {['Sr', 'TagNo', 'OrdNo', 'ItCode', 'ItName', 'Counter', 'Design'].map((h) => (
              <th key={h}>{h}</th>
            ))}
            {['Pcs', 'GrWt', 'LsWt', 'NetWt', 'Mrp'].map((h) => (
              <th key={h} className="num">
                {h}
              </th>
            ))}
          </tr>
        </thead>
        <tbody>
          {tags.map((t) => (
            <tr key={`${t.ordNo}-${t.srNo}`} data-tag={t.tagNo}>
              <td className="c">{t.srNo}</td>
              <td>{t.tagNo}</td>
              <td>{t.ordNo}</td>
              <td>{t.itCode}</td>
              <td>{t.itName}</td>
              <td>{t.tblCode}</td>
              <td>{t.designNo}</td>
              <td className="num">{t.pcs}</td>
              <td className="num">{n(t.gwt).toFixed(3)}</td>
              <td className="num">{n(t.othWt).toFixed(3)}</td>
              <td className="num">{n(t.nwt).toFixed(3)}</td>
              <td className="num">{money(n(t.mrp))}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
