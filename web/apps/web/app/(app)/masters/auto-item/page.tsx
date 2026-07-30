'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

/** Auto Item (MS_AUTO_ITEM): pick a group + tick the products to generate; each item's code is
 *  auto-derived as GR_CODE + PR_CODE and name as "<group> <product>". Bulk-inserts ITEM_MAST. */
interface PRow {
  prCode: string;
  prName: string;
  include: boolean;
}
const blank = (): PRow => ({ prCode: '', prName: '', include: true });

export default function AutoItemPage() {
  const [grCode, setGrCode] = useState('');
  const [grName, setGrName] = useState('');
  const [itType, setItType] = useState('G');
  const [hsnCode, setHsnCode] = useState('');
  const [rows, setRows] = useState<PRow[]>([blank()]);
  const [res, setRes] = useState<{ created: number; skipped: number; codes: string[] } | null>(
    null,
  );
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const setRow = (i: number, patch: Partial<PRow>) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, ...patch } : r)));

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!grCode.trim()) {
      setMsg({ kind: 'err', text: 'pick a group' });
      return;
    }
    const products = rows
      .filter((r) => r.prCode.trim() && r.include)
      .map((r) => ({ prCode: r.prCode.trim(), prName: r.prName || undefined, include: true }));
    if (!products.length) {
      setMsg({ kind: 'err', text: 'tick at least one product' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<{ created: number; skipped: number; codes: string[] }>(
        '/masters/auto-item',
        {
          grCode: grCode.trim(),
          grName: grName || undefined,
          itType,
          hsnCode: hsnCode || undefined,
          products,
        },
      );
      setRes(r);
      setMsg({
        kind: 'ok',
        text: `Generated ${r.created} item(s)${r.skipped ? `, ${r.skipped} already existed` : ''}`,
      });
    } catch (err) {
      setMsg({
        kind: 'err',
        text:
          err instanceof ApiError
            ? err.body?.detail || err.body?.message || err.body?.error || 'failed'
            : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Auto Item <span className="muted">— bulk-generate items for a group × products</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Group</label>
              <LookupPicker
                entity="groups"
                value={grCode}
                onChange={setGrCode}
                onPick={(r) => {
                  setGrCode(String(r.code));
                  setGrName(String(r.name || ''));
                }}
              />
            </div>
            <div className="field">
              <label>Group Name</label>
              <input value={grName} onChange={(e) => setGrName(e.target.value)} />
            </div>
            <div className="field">
              <label>Item Type</label>
              <select value={itType} onChange={(e) => setItType(e.target.value)}>
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
            <div className="field">
              <label>HSN</label>
              <input
                value={hsnCode}
                onChange={(e) => setHsnCode(e.target.value)}
                style={{ width: 80 }}
              />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Products</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>✓</th>
                <th>Product</th>
                <th>Name</th>
                <th>→ Item Code</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td style={{ textAlign: 'center' }}>
                    <input
                      type="checkbox"
                      checked={r.include}
                      onChange={(e) => setRow(i, { include: e.target.checked })}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="products"
                      value={r.prCode}
                      onChange={(v) => setRow(i, { prCode: v })}
                      onPick={(row) =>
                        setRow(i, { prCode: String(row.code), prName: String(row.name || '') })
                      }
                      style={{ width: 90 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.prName}
                      onChange={(e) => setRow(i, { prName: e.target.value })}
                      style={{ width: 150 }}
                    />
                  </td>
                  <td>
                    <code>{grCode && r.prCode ? `${grCode}${r.prCode}`.slice(0, 5) : '—'}</code>
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
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setRows((rs) => [...rs, blank()])}
            >
              + Add product
            </button>
            <span className="spacer" />
            <button className="primary" disabled={busy}>
              {busy ? 'Generating…' : 'Generate Items'}
            </button>
          </div>
          {res && res.codes.length > 0 && (
            <div className="msg ok" style={{ marginTop: 10 }}>
              Created: <code>{res.codes.join(', ')}</code>
            </div>
          )}
        </div>
      </form>
    </div>
  );
}
