'use client';
import { useEffect, useState } from 'react';
import { get } from '../../../../lib/api';

interface Row {
  report: string;
  areas: number;
  sections: number;
  objects: number;
  formulas: number;
}

/** Report Layouts — lists every desktop Crystal report whose pixel-exact layout was extracted
 *  (RptToXml geometry). "View Layout" opens the reconstructed A4 layout (bands + positioned fields). */
export default function ReportLayoutsPage() {
  const [rows, setRows] = useState<Row[]>([]);
  const [q, setQ] = useState('');
  const [err, setErr] = useState('');
  useEffect(() => {
    get<Row[]>('/reports/layouts')
      .then(setRows)
      .catch(() => setErr('Failed to load report layouts'));
  }, []);
  const filtered = rows.filter((r) => r.report.toLowerCase().includes(q.toLowerCase()));
  const open = (name: string) =>
    window.open(`/api/reports/layout?name=${encodeURIComponent(name)}&format=html`, '_blank');
  return (
    <div>
      <h1>
        Report Layouts{' '}
        <span className="muted">
          — {rows.length} desktop Crystal reports (pixel-exact geometry)
        </span>
      </h1>
      <div className="toolbar">
        <input
          placeholder="filter reports…"
          value={q}
          onChange={(e) => setQ(e.target.value)}
          style={{ width: 240 }}
        />
        <span className="muted">{filtered.length} shown</span>
      </div>
      {err && <div className="msg err">{err}</div>}
      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              <th>Report</th>
              <th className="num">Objects</th>
              <th className="num">Sections</th>
              <th className="num">Formulas</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {filtered.map((r) => (
              <tr key={r.report}>
                <td>
                  <b>{r.report}</b>
                </td>
                <td className="num">{r.objects}</td>
                <td className="num">{r.sections}</td>
                <td className="num">{r.formulas}</td>
                <td style={{ whiteSpace: 'nowrap' }}>
                  <button className="ghost" onClick={() => open(r.report)}>
                    View Layout
                  </button>
                </td>
              </tr>
            ))}
            {filtered.length === 0 && (
              <tr>
                <td colSpan={5} className="muted">
                  No reports.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
