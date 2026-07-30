'use client';
import { useCallback, useEffect, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';

export default function StockPage() {
  const [onhand, setOnhand] = useState<{ pcs: number; gwt: number; nwt: number } | null>(null);
  const [tags, setTags] = useState<Record<string, any>[]>([]);
  const [f, setF] = useState({
    tagNo: '',
    grCode: '',
    prCode: '',
    pcs: '1',
    gwt: '',
    nwt: '',
    mrp: '',
  });
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const set = (k: keyof typeof f, v: string) => setF((x) => ({ ...x, [k]: v }));

  const load = useCallback(async () => {
    const [oh, ts] = await Promise.all([get<any>('/stock/on-hand'), get<any[]>('/stock/tags')]);
    setOnhand(oh);
    setTags(ts);
  }, []);
  useEffect(() => {
    load().catch(() => {});
  }, [load]);

  async function addTag(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    try {
      await post('/stock/tags', {
        tagNo: f.tagNo,
        grCode: f.grCode || undefined,
        prCode: f.prCode || undefined,
        pcs: Number(f.pcs || 0),
        gwt: Number(f.gwt || 0),
        nwt: Number(f.nwt || 0),
        mrp: Number(f.mrp || 0),
      });
      setMsg({ kind: 'ok', text: `Tag ${f.tagNo} added to stock` });
      setF({ tagNo: '', grCode: '', prCode: '', pcs: '1', gwt: '', nwt: '', mrp: '' });
      await load();
    } catch (e) {
      const b = e instanceof ApiError ? e.body : null;
      setMsg({
        kind: 'err',
        text:
          b?.error === 'TagExistsError'
            ? 'Tag already in stock'
            : b?.message || b?.detail || 'Add failed',
      });
    }
  }

  return (
    <div>
      <h1>Stock / Tags</h1>
      <div className="tiles">
        <div className="tile">
          <div className="muted">Pieces</div>
          <div className="big kpi">{onhand?.pcs ?? '—'}</div>
        </div>
        <div className="tile">
          <div className="muted">Gross Wt</div>
          <div className="big kpi">{onhand?.gwt ?? '—'}</div>
        </div>
        <div className="tile">
          <div className="muted">Net Wt</div>
          <div className="big kpi">{onhand?.nwt ?? '—'}</div>
        </div>
        <div className="tile">
          <div className="muted">Tags</div>
          <div className="big kpi">{tags.length}</div>
        </div>
      </div>

      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form className="panel" onSubmit={addTag}>
        <h2>Stock-in (Tag Opening)</h2>
        <div className="row">
          <div className="field">
            <label>Tag No *</label>
            <input value={f.tagNo} onChange={(e) => set('tagNo', e.target.value)} required />
          </div>
          <div className="field">
            <label>Group</label>
            <input value={f.grCode} onChange={(e) => set('grCode', e.target.value)} />
          </div>
          <div className="field">
            <label>Product</label>
            <input value={f.prCode} onChange={(e) => set('prCode', e.target.value)} />
          </div>
          <div className="field">
            <label>Pcs</label>
            <input value={f.pcs} onChange={(e) => set('pcs', e.target.value)} />
          </div>
          <div className="field">
            <label>Gross Wt</label>
            <input value={f.gwt} onChange={(e) => set('gwt', e.target.value)} />
          </div>
          <div className="field">
            <label>Net Wt</label>
            <input value={f.nwt} onChange={(e) => set('nwt', e.target.value)} />
          </div>
          <div className="field">
            <label>MRP</label>
            <input value={f.mrp} onChange={(e) => set('mrp', e.target.value)} />
          </div>
        </div>
        <button className="primary">Add to Stock</button>
      </form>

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>In Stock</h2>
        <table className="grid">
          <thead>
            <tr>
              <th>Tag No</th>
              <th>Group</th>
              <th>Product</th>
              <th className="num">Pcs</th>
              <th className="num">Gross</th>
              <th className="num">Net</th>
              <th className="num">MRP</th>
            </tr>
          </thead>
          <tbody>
            {tags.map((t, i) => (
              <tr key={i}>
                <td>{t.TAG_NO}</td>
                <td>{t.GR_CODE}</td>
                <td>{t.PR_CODE}</td>
                <td className="num">{t.ITM_PCS}</td>
                <td className="num">{t.ITM_GWT}</td>
                <td className="num">{t.ITM_NWT}</td>
                <td className="num">{t.ITM_MRP}</td>
              </tr>
            ))}
            {tags.length === 0 && (
              <tr>
                <td colSpan={7} className="muted">
                  No tags in stock.
                </td>
              </tr>
            )}
          </tbody>
        </table>
      </div>
    </div>
  );
}
