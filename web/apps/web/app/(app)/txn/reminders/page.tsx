'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, ApiError } from '../../../../lib/api';

interface Recv {
  acCode: string;
  acName: string;
  mobile: string;
  outstanding: number;
  goldOs: number;
  silverOs: number;
  crDays: number;
  oldestAgeDays: number;
  daysOverdue: number;
  overdue: boolean;
}
interface Ord {
  vchNo: string;
  acCode: string;
  acName: string;
  delDate: string | null;
  total: number;
  daysToDelivery: number | null;
  overdue: boolean;
}
interface Data {
  receivables: Recv[];
  ordersDue: Ord[];
  summary: {
    overdueParties: number;
    totalOutstanding: number;
    ordersDue: number;
    ordersOverdue: number;
  };
}
const money = (n: number) =>
  Number(n || 0).toLocaleString('en-IN', { minimumFractionDigits: 2, maximumFractionDigits: 2 });
type Tab = 'recv' | 'orders' | 'bday' | 'dhiran';

/** Generic table for the ad-hoc datasets (birthdays, dhiran) — columns from the first row's keys. */
function GenericTable({ rows }: { rows: any[] }) {
  if (!rows?.length) return <div className="muted">No records.</div>;
  const cols = Object.keys(rows[0]).filter((k) => typeof rows[0][k] !== 'object');
  return (
    <table className="grid">
      <thead>
        <tr>
          {cols.map((c) => (
            <th key={c}>{c}</th>
          ))}
        </tr>
      </thead>
      <tbody>
        {rows.map((r, i) => (
          <tr key={i}>
            {cols.map((c) => (
              <td key={c}>{r[c] == null ? '' : String(r[c])}</td>
            ))}
          </tr>
        ))}
      </tbody>
    </table>
  );
}

export default function RemindersPage() {
  const [data, setData] = useState<Data | null>(null);
  const [tab, setTab] = useState<Tab>('recv');
  const [bdays, setBdays] = useState<any[] | null>(null);
  const [dhiran, setDhiran] = useState<any[] | null>(null);
  const [msg, setMsg] = useState<string | null>(null);
  const [busy, setBusy] = useState(false);

  const load = useCallback(async () => {
    setBusy(true);
    setMsg(null);
    try {
      setData(await get<Data>('/reminders'));
    } catch (e) {
      setMsg(e instanceof ApiError ? e.body?.error || e.message : 'failed to load');
    } finally {
      setBusy(false);
    }
  }, []);
  useEffect(() => {
    void load();
  }, [load]);

  useEffect(() => {
    if (tab === 'bday' && bdays === null)
      get<any>('/reminders/birthdays')
        .then((r) => setBdays(r.rows ?? r ?? []))
        .catch(() => setBdays([]));
    if (tab === 'dhiran' && dhiran === null)
      get<any>('/reports/dhrn-outstanding')
        .then((r) => setDhiran(r.rows ?? r ?? []))
        .catch(() => setDhiran([]));
  }, [tab, bdays, dhiran]);

  const TabBtn = ({ id, label, n }: { id: Tab; label: string; n?: number }) => (
    <button type="button" className={tab === id ? 'primary' : 'ghost'} onClick={() => setTab(id)}>
      {label}
      {n != null ? ` (${n})` : ''}
    </button>
  );

  return (
    <div>
      <h1>
        Reminders <span className="muted">— receivables · orders · birthdays · dhiran</span>
      </h1>
      {msg && <div className="msg err">{msg}</div>}
      {data && (
        <div className="panel">
          <div className="tiles">
            <div className="tile">
              <div className="muted">Overdue parties</div>
              <div
                className="big kpi"
                style={{ color: data.summary.overdueParties ? 'var(--err)' : undefined }}
              >
                {data.summary.overdueParties}
              </div>
            </div>
            <div className="tile">
              <div className="muted">Total outstanding</div>
              <div className="big kpi">{money(data.summary.totalOutstanding)}</div>
            </div>
            <div className="tile">
              <div className="muted">Orders due</div>
              <div className="big kpi">{data.summary.ordersDue}</div>
            </div>
            <div className="tile">
              <div className="muted">Orders overdue</div>
              <div
                className="big kpi"
                style={{ color: data.summary.ordersOverdue ? 'var(--err)' : undefined }}
              >
                {data.summary.ordersOverdue}
              </div>
            </div>
          </div>
        </div>
      )}

      <div className="toolbar">
        <TabBtn id="recv" label="Receivables" n={data?.receivables.length} />
        <TabBtn id="orders" label="Orders due" n={data?.ordersDue.length} />
        <TabBtn id="bday" label="Birthdays / Anniv" n={bdays?.length} />
        <TabBtn id="dhiran" label="Dhiran O/S" n={dhiran?.length} />
        <span className="spacer" />
        <button type="button" className="ghost" onClick={() => load()} disabled={busy}>
          {busy ? 'Loading…' : 'Refresh'}
        </button>
      </div>

      {tab === 'recv' && data && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Party</th>
                <th>Mobile</th>
                <th className="num">Outstanding</th>
                <th className="num">Gold (g)</th>
                <th className="num">Silver (g)</th>
                <th className="num">Oldest (days)</th>
                <th className="num">Credit days</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {data.receivables.map((r) => (
                <tr
                  key={r.acCode}
                  style={r.overdue ? { background: 'rgba(220,38,38,0.06)' } : undefined}
                >
                  <td>{r.acName}</td>
                  <td>{r.mobile}</td>
                  <td className="num">{money(r.outstanding)}</td>
                  <td className="num">{r.goldOs ? r.goldOs.toLocaleString('en-IN') : ''}</td>
                  <td className="num">{r.silverOs ? r.silverOs.toLocaleString('en-IN') : ''}</td>
                  <td className="num">{r.oldestAgeDays}</td>
                  <td className="num">{r.crDays}</td>
                  <td>
                    {r.overdue ? (
                      <span style={{ color: 'var(--err)', fontWeight: 600 }}>
                        {r.daysOverdue}d overdue
                      </span>
                    ) : (
                      <span className="muted">within terms</span>
                    )}
                  </td>
                </tr>
              ))}
              {data.receivables.length === 0 && (
                <tr>
                  <td colSpan={8} className="muted">
                    No outstanding receivables.
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      )}
      {tab === 'orders' && data && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Vch</th>
                <th>Customer</th>
                <th>Delivery</th>
                <th className="num">Total</th>
                <th>Status</th>
              </tr>
            </thead>
            <tbody>
              {data.ordersDue.map((o) => (
                <tr
                  key={o.vchNo}
                  style={o.overdue ? { background: 'rgba(220,38,38,0.06)' } : undefined}
                >
                  <td>{o.vchNo}</td>
                  <td>{o.acName || o.acCode}</td>
                  <td>{o.delDate ?? ''}</td>
                  <td className="num">{money(o.total)}</td>
                  <td>
                    {o.daysToDelivery == null ? (
                      ''
                    ) : o.overdue ? (
                      <span style={{ color: 'var(--err)', fontWeight: 600 }}>
                        {-o.daysToDelivery}d overdue
                      </span>
                    ) : (
                      `in ${o.daysToDelivery}d`
                    )}
                  </td>
                </tr>
              ))}
              {data.ordersDue.length === 0 && (
                <tr>
                  <td colSpan={5} className="muted">
                    No orders due.
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      )}
      {tab === 'bday' && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Birthdays / Anniversaries (today)</h2>
          {bdays === null ? <div className="muted">Loading…</div> : <GenericTable rows={bdays} />}
        </div>
      )}
      {tab === 'dhiran' && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Dhiran outstanding</h2>
          {dhiran === null ? <div className="muted">Loading…</div> : <GenericTable rows={dhiran} />}
        </div>
      )}
    </div>
  );
}
