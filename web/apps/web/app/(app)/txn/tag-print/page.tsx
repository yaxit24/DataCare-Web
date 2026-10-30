'use client';
import { useState } from 'react';
import { get, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { openDocument } from '../../../../lib/openDocument';

/** Tag Print — list in-stock tags (BAR_DETL) and open a print-ready label sheet for the selected tags. */
interface Tag {
  tagNo: string;
  itCode: string;
  designNo: string | null;
  tblCode: string | null;
  netWt: number;
  grossWt: number;
  mrp: number;
}

export default function TagPrintPage() {
  const [tblCode, setTblCode] = useState('');
  const [itCode, setItCode] = useState('');
  const [tagFrom, setTagFrom] = useState('');
  const [tagTo, setTagTo] = useState('');
  const [tags, setTags] = useState<Tag[]>([]);
  const [sel, setSel] = useState<Record<string, boolean>>({});
  const [err, setErr] = useState('');
  // Blank stickers to leave before the first label, so a part-used sheet is not wasted (desktop
  // nLableSkip, present on eleven TR_* forms plus UT_TAG_PRINT).
  const [labelSkip, setLabelSkip] = useState('0');

  function qs() {
    const q = new URLSearchParams();
    if (tblCode) q.set('tblCode', tblCode);
    if (itCode) q.set('itCode', itCode);
    if (tagFrom) q.set('tagFrom', tagFrom);
    if (tagTo) q.set('tagTo', tagTo);
    return q;
  }
  async function load() {
    setErr('');
    try {
      const list = await get<Tag[]>(`/stock/tag-print?${qs().toString()}`);
      setTags(list);
      setSel(Object.fromEntries(list.map((t) => [t.tagNo, true])));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || 'failed' : 'failed');
    }
  }
  const selected = tags.filter((t) => sel[t.tagNo]).map((t) => t.tagNo);
  function print() {
    const q = qs();
    if (selected.length && selected.length !== tags.length) q.set('tags', selected.join(','));
    if (Number(labelSkip) > 0) q.set('labelSkip', String(Number(labelSkip)));
    openDocument(`/api/stock/tag-print/label?${q.toString()}`);
  }

  return (
    <div>
      <h1>
        Tag Print <span className="muted">— (re)print barcode labels for in-stock tags</span>
      </h1>
      <div className="panel">
        <div className="row">
          <div className="field">
            <label>Counter</label>
            <input
              value={tblCode}
              onChange={(e) => setTblCode(e.target.value)}
              placeholder="all"
              style={{ width: 70 }}
            />
          </div>
          <div className="field">
            <label>Item</label>
            <LookupPicker entity="items" value={itCode} onChange={setItCode} />
          </div>
          <div className="field">
            <label>Tag from</label>
            <input
              value={tagFrom}
              onChange={(e) => setTagFrom(e.target.value)}
              style={{ width: 110 }}
            />
          </div>
          <div className="field">
            <label>Tag to</label>
            <input
              value={tagTo}
              onChange={(e) => setTagTo(e.target.value)}
              style={{ width: 110 }}
            />
          </div>
          <div className="field" style={{ alignSelf: 'end' }}>
            <button type="button" className="primary" onClick={load}>
              Load
            </button>
          </div>
        </div>
      </div>
      {err && <div className="msg err">{err}</div>}
      {tags.length > 0 && (
        <div className="panel" style={{ overflow: 'auto' }}>
          <div className="toolbar" style={{ marginBottom: 8 }}>
            <span className="muted">
              {tags.length} tags · <b>{selected.length}</b> selected
            </span>
            <span className="spacer" />
            <button
              type="button"
              className="ghost"
              onClick={() => setSel(Object.fromEntries(tags.map((t) => [t.tagNo, true])))}
            >
              All
            </button>
            <button type="button" className="ghost" onClick={() => setSel({})}>
              None
            </button>
            <label htmlFor="labelSkip" className="muted">
              Skip labels
            </label>
            <input
              id="labelSkip"
              type="number"
              min={0}
              step={1}
              style={{ width: 70 }}
              value={labelSkip}
              onChange={(e) => setLabelSkip(e.target.value)}
            />
            <button type="button" className="primary" onClick={print} disabled={!selected.length}>
              Print labels ({selected.length})
            </button>
          </div>
          <table className="grid">
            <thead>
              <tr>
                <th>✓</th>
                <th>Tag</th>
                <th>Item</th>
                <th>Design</th>
                <th>Ctr</th>
                <th className="num">Net</th>
                <th className="num">Gross</th>
                <th className="num">MRP</th>
              </tr>
            </thead>
            <tbody>
              {tags.map((t) => (
                <tr key={t.tagNo}>
                  <td style={{ textAlign: 'center' }}>
                    <input
                      type="checkbox"
                      checked={!!sel[t.tagNo]}
                      onChange={(e) => setSel((s) => ({ ...s, [t.tagNo]: e.target.checked }))}
                    />
                  </td>
                  <td>{t.tagNo}</td>
                  <td>{t.itCode}</td>
                  <td>{t.designNo || ''}</td>
                  <td>{t.tblCode || ''}</td>
                  <td className="num">{t.netWt}</td>
                  <td className="num">{t.grossWt}</td>
                  <td className="num">{t.mrp ? t.mrp.toLocaleString('en-IN') : ''}</td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}
