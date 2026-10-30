'use client';
import { useEffect, useState } from 'react';
import { get } from '../../../../lib/api';
import { openDocument } from '../../../../lib/openDocument';

interface Row {
  form: string;
  controlCount: number;
  grids: number;
  tabs: number;
  inputs?: number;
  buttons?: number;
}

/** Form Layouts — every desktop WinForms screen whose layout was extracted (InitializeComponent/resx).
 *  "View Layout" opens the pixel-exact reconstruction (fields/grids/tabs/buttons positioned as in the desktop). */
export default function FormLayoutsPage() {
  const [rows, setRows] = useState<Row[]>([]);
  const [q, setQ] = useState('');
  const [err, setErr] = useState('');
  useEffect(() => {
    get<Row[]>('/forms/layouts')
      .then(setRows)
      .catch(() => setErr('Failed to load form layouts'));
  }, []);
  const filtered = rows.filter((r) => r.form.toLowerCase().includes(q.toLowerCase()));
  const open = (name: string) => openDocument(`/api/forms/layout?name=${encodeURIComponent(name)}`);
  return (
    <div>
      <h1>
        Form Layouts <span className="muted">— {rows.length} desktop screens (pixel-exact)</span>
      </h1>
      <div className="toolbar">
        <input
          placeholder="filter forms… (e.g. TR_SALE)"
          value={q}
          onChange={(e) => setQ(e.target.value)}
          style={{ width: 260 }}
        />
        <span className="muted">{filtered.length} shown</span>
      </div>
      {err && <div className="msg err">{err}</div>}
      <div className="panel" style={{ overflow: 'auto' }}>
        <table className="grid">
          <thead>
            <tr>
              <th>Form</th>
              <th className="num">Controls</th>
              <th className="num">Inputs</th>
              <th className="num">Grids</th>
              <th className="num">Tabs</th>
              <th className="num">Buttons</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {filtered.map((r) => (
              <tr key={r.form}>
                <td>
                  <b>{r.form}</b>
                </td>
                <td className="num">{r.controlCount}</td>
                <td className="num">{r.inputs ?? ''}</td>
                <td className="num">{r.grids}</td>
                <td className="num">{r.tabs}</td>
                <td className="num">{r.buttons ?? ''}</td>
                <td style={{ whiteSpace: 'nowrap' }}>
                  <button className="ghost" onClick={() => open(r.form)}>
                    View Layout
                  </button>
                </td>
              </tr>
            ))}
            {filtered.length === 0 && (
              <tr>
                <td colSpan={7} className="muted">
                  No forms.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
