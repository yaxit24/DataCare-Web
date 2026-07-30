'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, downloadCsv } from '../../../lib/api';

export default function AuditPage() {
  const [rows, setRows] = useState<Record<string, any>[]>([]);
  const load = useCallback(async () => {
    setRows(await get<any[]>('/audit').catch(() => []));
  }, []);
  useEffect(() => {
    load();
  }, [load]);

  return (
    <div>
      <h1>Audit Log</h1>
      <p className="muted">
        Every authenticated create/update/delete is recorded (user, action, endpoint, status).
      </p>
      <div className="toolbar">
        <button className="ghost" onClick={load}>
          Refresh
        </button>
        <button
          className="ghost"
          disabled={!rows.length}
          onClick={() => downloadCsv(rows, 'audit-log')}
        >
          Export CSV
        </button>
        <span className="muted">{rows.length} entries</span>
      </div>
      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              <th>Time</th>
              <th>User</th>
              <th>Co</th>
              <th>Action</th>
              <th>Endpoint</th>
              <th className="num">Status</th>
            </tr>
          </thead>
          <tbody>
            {rows.map((r, i) => (
              <tr key={i}>
                <td>{r.ts}</td>
                <td>{r.user}</td>
                <td>{r.company}</td>
                <td>{r.action}</td>
                <td>{r.path}</td>
                <td className="num" style={{ color: r.status >= 400 ? 'var(--err)' : 'var(--ok)' }}>
                  {r.status}
                </td>
              </tr>
            ))}
            {rows.length === 0 && (
              <tr>
                <td colSpan={6} className="muted">
                  No audit entries yet.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
