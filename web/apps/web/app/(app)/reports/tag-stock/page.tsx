'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';

/** Tag-Stock report — In / Out / Stock / MRP / Apr-Pending / All tabs over MAIN_STOCK/BAR_DETL/APR_DETL. */
type Tab = 'in' | 'out' | 'stock' | 'mrp' | 'apr' | 'all';
const TABS: { id: Tab; label: string }[] = [
  { id: 'stock', label: 'In Stock' },
  { id: 'in', label: 'In' },
  { id: 'out', label: 'Out' },
  { id: 'mrp', label: 'MRP' },
  { id: 'apr', label: 'Apr-Pending' },
  { id: 'all', label: 'All' },
];
interface Row {
  tagNo: string;
  itCode: string;
  designNo: string | null;
  tblCode: string | null;
  vchType: string | null;
  vchDate: string | null;
  pcs: number;
  grossWt: number;
  netWt: number;
  fine: number;
  mrp: number;
}
interface Rep {
  tab: Tab;
  rows: Row[];
  totals: { count: number; pcs: number; netWt: number; fine: number; mrp: number };
}

export default function TagStockReportPage() {
  const [tab, setTab] = useState<Tab>('stock');
  const [tblCode, setTblCode] = useState('');
  const [itCode, setItCode] = useState('');
  const [rep, setRep] = useState<Rep | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  // RP_TAG_IMAGE is a tag-image report: the desktop shows the photograph of the selected tag. Clicking a
  // row selects it, which is the closest honest equivalent on a list surface.
  const [imageRow, setImageRow] = useState(0);

  const qs = useCallback(() => {
    const q = new URLSearchParams({ tab });
    if (tblCode) q.set('tblCode', tblCode);
    if (itCode) q.set('itCode', itCode);
    return q;
  }, [tab, tblCode, itCode]);
  const load = useCallback(async () => {
    setBusy(true);
    setErr('');
    try {
      setRep(await get<Rep>(`/reports/tag-stock?${qs().toString()}`));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }, [qs]);
  useEffect(() => {
    void load();
  }, [load]);

  const num = (n: number) => Number(n || 0).toLocaleString('en-IN');

  return (
    <div>
      <h1>Tag-Stock Report</h1>
      <div className="panel">
        <div className="row">
          {TABS.map((t) => (
            <button
              key={t.id}
              type="button"
              className={tab === t.id ? 'primary' : 'ghost'}
              onClick={() => setTab(t.id)}
            >
              {t.label}
            </button>
          ))}
          <span className="spacer" />
          <div className="field">
            <label>Counter</label>
            <input
              value={tblCode}
              onChange={(e) => setTblCode(e.target.value)}
              style={{ width: 64 }}
            />
          </div>
          <div className="field">
            <label>Item</label>
            <LookupPicker entity="items" value={itCode} onChange={setItCode} />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="ghost" onClick={load} disabled={busy}>
              {busy ? '…' : 'Apply'}
            </button>
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <a
              className="ghost"
              href={`/api/reports/tag-stock.csv?${qs().toString()}`}
              target="_blank"
              rel="noreferrer"
              style={{
                padding: '6px 10px',
                border: '1px solid var(--border,#ccc)',
                borderRadius: 4,
                textDecoration: 'none',
              }}
            >
              Export CSV
            </a>
          </div>
        </div>
      </div>
      {err && <div className="msg err">{err}</div>}
      {rep && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="tiles" style={{ marginBottom: 8 }}>
            <div className="tile">
              <div className="muted">Tags</div>
              <div className="big kpi">{rep.totals.count}</div>
            </div>
            <div className="tile">
              <div className="muted">Net Wt</div>
              <div className="big kpi">{num(rep.totals.netWt)}</div>
            </div>
            <div className="tile">
              <div className="muted">Fine</div>
              <div className="big kpi">{num(rep.totals.fine)}</div>
            </div>
            <div className="tile">
              <div className="muted">MRP</div>
              <div className="big kpi">{num(rep.totals.mrp)}</div>
            </div>
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>Tag</th>
                <th>Item</th>
                <th>Design</th>
                <th>Ctr</th>
                {(tab === 'in' || tab === 'out' || tab === 'apr') && (
                  <>
                    <th>Type</th>
                    <th>Date</th>
                  </>
                )}
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Fine</th>
                <th className="num">MRP</th>
              </tr>
            </thead>
            <tbody>
              {rep.rows.map((r, i) => (
                <tr
                  key={i}
                  onClick={() => setImageRow(i)}
                  className={i === imageRow ? 'active' : undefined}
                  style={{ cursor: 'pointer' }}
                >
                  <td>{r.tagNo}</td>
                  <td>{r.itCode}</td>
                  <td>{r.designNo || ''}</td>
                  <td>{r.tblCode || ''}</td>
                  {(tab === 'in' || tab === 'out' || tab === 'apr') && (
                    <>
                      <td>{r.vchType || ''}</td>
                      <td>{r.vchDate || ''}</td>
                    </>
                  )}
                  <td className="num">{r.pcs || ''}</td>
                  <td className="num">{r.grossWt || ''}</td>
                  <td className="num">{r.netWt || ''}</td>
                  <td className="num">{r.fine || ''}</td>
                  <td className="num">{r.mrp ? num(r.mrp) : ''}</td>
                </tr>
              ))}
              {rep.rows.length === 0 && (
                <tr>
                  <td colSpan={11} className="muted">
                    No tags for this view.
                  </td>
                </tr>
              )}
            </tbody>
          </table>
        </div>
      )}
      {/* RP_TAG_IMAGE / RP_TAG_ESTMATE show the selected tag's photograph. */}
      <EntityImagePanel
        entityType="TAG"
        entityKey={rep?.rows[imageRow]?.tagNo ?? ''}
        instance={0}
        label="Tag image"
        testId="tag-stock-image"
      />
    </div>
  );
}
