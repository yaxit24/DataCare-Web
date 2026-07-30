'use client';
import { useEffect, useState } from 'react';
import Link from 'next/link';
import { get } from '../../../lib/api';
import { useBusinessScope } from '../../../components/BusinessScope';

export default function Dashboard() {
  const { coYear } = useBusinessScope();
  const [sales, setSales] = useState<{ count: number; total: number } | null>(null);
  const [tb, setTb] = useState<{ balanced: boolean; grandDr: number } | null>(null);

  useEffect(() => {
    (async () => {
      const sr = await get<any>(`/reports/sales-register?coYear=${coYear}`).catch(() => null);
      if (sr) setSales({ count: sr.rows?.length ?? 0, total: sr.totals?.totAmt ?? 0 });
      const t = await get<any>(`/reports/trial-balance?coYear=${coYear}`).catch(() => null);
      if (t) setTb({ balanced: !!t.balanced, grandDr: t.grandDr ?? 0 });
    })();
  }, [coYear]);

  return (
    <div>
      <h1>
        Dashboard <span className="muted">FY {coYear}</span>
      </h1>
      <div className="tiles">
        <div className="tile">
          <div className="muted">Sales Invoices</div>
          <div className="big kpi">{sales?.count ?? '—'}</div>
        </div>
        <div className="tile">
          <div className="muted">Sales Total (₹)</div>
          <div className="big kpi">{sales ? sales.total.toLocaleString('en-IN') : '—'}</div>
        </div>
        <div className="tile">
          <div className="muted">Trial Balance</div>
          <div className="big" style={{ color: tb?.balanced ? 'var(--ok)' : 'var(--err)' }}>
            {tb ? (tb.balanced ? 'Balanced' : 'Off') : '—'}
          </div>
        </div>
        <div className="tile">
          <div className="muted">Ledger Total (₹)</div>
          <div className="big kpi">{tb ? tb.grandDr.toLocaleString('en-IN') : '—'}</div>
        </div>
      </div>

      <div className="panel">
        <h2>Quick actions</h2>
        <div className="toolbar">
          <Link
            className="primary"
            href="/txn/sales"
            style={{ padding: '7px 14px', borderRadius: 4 }}
          >
            New Sale
          </Link>
          <Link
            className="ghost"
            href="/masters/accounts"
            style={{ padding: '7px 12px', borderRadius: 4 }}
          >
            Accounts
          </Link>
          <Link
            className="ghost"
            href="/masters/items"
            style={{ padding: '7px 12px', borderRadius: 4 }}
          >
            Items
          </Link>
          <Link
            className="ghost"
            href="/reports/sales-register"
            style={{ padding: '7px 12px', borderRadius: 4 }}
          >
            Sales Register
          </Link>
          <Link
            className="ghost"
            href="/reports/trial-balance"
            style={{ padding: '7px 12px', borderRadius: 4 }}
          >
            Trial Balance
          </Link>
        </div>
      </div>
    </div>
  );
}
