'use client';
import { useCallback, useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';

interface Item {
  itCode: string;
  itName: string;
  lbrRate: number;
  lbrPct: number;
  mrp: number;
  west: number;
}
interface Edit {
  lbrRate: string;
  lbrPct: string;
  mrp: string;
  west: string;
}
const blankEdit = (): Edit => ({ lbrRate: '', lbrPct: '', mrp: '', west: '' });

export default function LabourUpdatePage() {
  const [grCode, setGrCode] = useState('');
  const [items, setItems] = useState<Item[]>([]);
  const [edits, setEdits] = useState<Record<string, Edit>>({});
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  // P2-4 per-item weight slabs (ITM_WT_MAST) — multiple labour bands keyed by SR_NO.
  interface Slab {
    fromWt: string;
    toWt: string;
    minPcs: string;
    lbrRate: string;
    lbrPct: string;
    lbrAmt: string;
  }
  const sblank = (): Slab => ({
    fromWt: '',
    toWt: '',
    minPcs: '',
    lbrRate: '',
    lbrPct: '',
    lbrAmt: '',
  });
  const [slabItem, setSlabItem] = useState('');
  const [slabs, setSlabs] = useState<Slab[]>([sblank()]);
  const setSlab = (i: number, k: keyof Slab, v: string) =>
    setSlabs((ss) => ss.map((s, j) => (j === i ? { ...s, [k]: v } : s)));

  async function loadSlabs(it: string) {
    setSlabItem(it);
    if (!it.trim()) {
      setSlabs([sblank()]);
      return;
    }
    try {
      const rows = await get<any[]>(`/labour-slabs?itCode=${encodeURIComponent(it.trim())}`);
      setSlabs(
        rows.length
          ? rows.map((r) => ({
              fromWt: String(r.fromWt || ''),
              toWt: String(r.toWt || ''),
              minPcs: String(r.minPcs || ''),
              lbrRate: String(r.lbrRate || ''),
              lbrPct: String(r.lbrPct || ''),
              lbrAmt: String(r.lbrAmt || ''),
            }))
          : [sblank()],
      );
    } catch {
      setSlabs([sblank()]);
    }
  }
  async function saveSlabs() {
    if (!slabItem.trim()) {
      setMsg({ kind: 'err', text: 'pick an item for slabs' });
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      const payload = slabs
        .filter((s) => s.fromWt || s.toWt || s.lbrRate || s.lbrAmt)
        .map((s) => ({
          fromWt: Number(s.fromWt || 0),
          toWt: Number(s.toWt || 0),
          minPcs: Number(s.minPcs || 0),
          lbrRate: Number(s.lbrRate || 0),
          lbrPct: Number(s.lbrPct || 0),
          lbrAmt: Number(s.lbrAmt || 0),
        }));
      const r = await post<{ saved: number }>('/labour-slabs', {
        itCode: slabItem.trim(),
        slabs: payload,
      });
      setMsg({ kind: 'ok', text: `Saved ${r.saved} weight slab(s) for ${slabItem}` });
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.detail || e.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  const load = useCallback(async (gr: string) => {
    if (!gr.trim()) {
      setItems([]);
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      const its = await get<Item[]>(`/labour-update?grCode=${encodeURIComponent(gr.trim())}`);
      setItems(its);
      setEdits(Object.fromEntries(its.map((i) => [i.itCode, blankEdit()])));
    } catch (e) {
      setMsg({ kind: 'err', text: e instanceof ApiError ? e.body?.error || e.message : 'failed' });
    } finally {
      setBusy(false);
    }
  }, []);

  const setEdit = (it: string, k: keyof Edit, v: string) =>
    setEdits((e) => ({ ...e, [it]: { ...(e[it] ?? blankEdit()), [k]: v } }));

  async function save() {
    const rows = items
      .map((i) => {
        const e = edits[i.itCode] ?? blankEdit();
        const row: any = { itCode: i.itCode };
        if (e.lbrRate !== '') row.lbrRate = Number(e.lbrRate);
        if (e.lbrPct !== '') row.lbrPct = Number(e.lbrPct);
        if (e.mrp !== '') row.mrp = Number(e.mrp);
        if (e.west !== '') row.west = Number(e.west);
        return row;
      })
      .filter((r) => Object.keys(r).length > 1);
    if (!rows.length) {
      setMsg({ kind: 'err', text: 'enter at least one New value' });
      return;
    }
    setBusy(true);
    setMsg(null);
    try {
      const r = await post<{ updated: number }>('/labour-update', { grCode, rows });
      setMsg({ kind: 'ok', text: `Updated ${r.updated} item(s)` });
      await load(grCode);
    } catch (e) {
      setMsg({
        kind: 'err',
        text: e instanceof ApiError ? e.body?.detail || e.body?.error || 'failed' : 'failed',
      });
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Labour &amp; MRP Update <span className="muted">— bulk Old→New per item group</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <div className="panel">
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Item Group</label>
            <LookupPicker
              entity="groups"
              value={grCode}
              onChange={setGrCode}
              onPick={(r) => load(String(r.code))}
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="ghost" onClick={() => load(grCode)} disabled={busy}>
              {busy ? 'Loading…' : 'Load'}
            </button>
          </div>
        </div>
      </div>

      {items.length > 0 && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">O.Lbr</th>
                <th className="num">N.Lbr</th>
                <th className="num">O.Lbr%</th>
                <th className="num">N.Lbr%</th>
                <th className="num">O.MRP</th>
                <th className="num">N.MRP</th>
                <th className="num">O.West%</th>
                <th className="num">N.West%</th>
              </tr>
            </thead>
            <tbody>
              {items.map((i) => {
                const e = edits[i.itCode] ?? blankEdit();
                const inp = (k: keyof Edit) => (
                  <input
                    value={e[k]}
                    onChange={(ev) => setEdit(i.itCode, k, ev.target.value)}
                    style={{ width: 64, textAlign: 'right' }}
                  />
                );
                return (
                  <tr key={i.itCode}>
                    <td title={i.itCode}>{i.itName || i.itCode}</td>
                    <td className="num muted">{i.lbrRate.toLocaleString('en-IN')}</td>
                    <td className="num">{inp('lbrRate')}</td>
                    <td className="num muted">{i.lbrPct}</td>
                    <td className="num">{inp('lbrPct')}</td>
                    <td className="num muted">{i.mrp.toLocaleString('en-IN')}</td>
                    <td className="num">{inp('mrp')}</td>
                    <td className="num muted">{i.west}</td>
                    <td className="num">{inp('west')}</td>
                  </tr>
                );
              })}
            </tbody>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">{items.length} item(s) · blank New = leave unchanged</span>
            <span className="spacer" />
            <button type="button" className="primary" onClick={save} disabled={busy}>
              {busy ? 'Saving…' : 'Save Changes'}
            </button>
          </div>
        </div>
      )}

      <div className="panel" style={{ overflow: 'auto' }}>
        <h2>
          Weight Slabs <span className="muted">— multiple labour bands per item (ITM_WT_MAST)</span>
        </h2>
        <div className="row">
          <div className="field" style={{ flex: 2 }}>
            <label>Item</label>
            <LookupPicker
              entity="items"
              value={slabItem}
              onChange={setSlabItem}
              onPick={(r) => loadSlabs(String(r.code))}
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="ghost" onClick={() => loadSlabs(slabItem)}>
              Load slabs
            </button>
          </div>
        </div>
        {slabItem && (
          <>
            <table className="grid" style={{ marginTop: 8, maxWidth: 720 }}>
              <thead>
                <tr>
                  <th className="num">From Wt</th>
                  <th className="num">To Wt</th>
                  <th className="num">Min Pcs</th>
                  <th className="num">Lbr Rate</th>
                  <th className="num">Lbr %</th>
                  <th className="num">Lbr Amt</th>
                  <th></th>
                </tr>
              </thead>
              <tbody>
                {slabs.map((s, i) => (
                  <tr key={i}>
                    <td className="num">
                      <input
                        value={s.fromWt}
                        onChange={(e) => setSlab(i, 'fromWt', e.target.value)}
                        style={{ width: 64, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={s.toWt}
                        onChange={(e) => setSlab(i, 'toWt', e.target.value)}
                        style={{ width: 64, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={s.minPcs}
                        onChange={(e) => setSlab(i, 'minPcs', e.target.value)}
                        style={{ width: 52, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={s.lbrRate}
                        onChange={(e) => setSlab(i, 'lbrRate', e.target.value)}
                        style={{ width: 64, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={s.lbrPct}
                        onChange={(e) => setSlab(i, 'lbrPct', e.target.value)}
                        style={{ width: 52, textAlign: 'right' }}
                      />
                    </td>
                    <td className="num">
                      <input
                        value={s.lbrAmt}
                        onChange={(e) => setSlab(i, 'lbrAmt', e.target.value)}
                        style={{ width: 64, textAlign: 'right' }}
                      />
                    </td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() =>
                          setSlabs((ss) =>
                            ss.length > 1 ? ss.filter((_, j) => j !== i) : [sblank()],
                          )
                        }
                      >
                        ×
                      </button>
                    </td>
                  </tr>
                ))}
              </tbody>
            </table>
            <div className="toolbar" style={{ marginTop: 8 }}>
              <button
                type="button"
                className="ghost"
                onClick={() => setSlabs((ss) => [...ss, sblank()])}
              >
                + Add slab
              </button>
              <span className="spacer" />
              <button type="button" className="primary" onClick={saveSlabs} disabled={busy}>
                {busy ? 'Saving…' : 'Save Slabs'}
              </button>
            </div>
          </>
        )}
      </div>
    </div>
  );
}
