'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { ParityContainmentNotice } from '../../../../components/ParityContainmentNotice';
import { parityContainmentMessage, parityContainmentRule } from '@datacare/core/containment';
import { useGridKeyboard } from '../../../../components/GridKeyboard';

/**
 * Tag Weight Change (TR_TAG_WT_DIFF) entry — books the net weight difference (newNetWt − oldNetWt)
 * per tag. POSTs to /stock/tag-weight-diff which writes a signed MAIN_STOCK movement of |diff| plus a
 * balanced AC_DATA value pair (value = diffFine·rate). Picking a tag autofills its item/old net wt/
 * touch/rate from the BAR_DETL lookup, mirroring the desktop F-key lookup.
 */
interface Line {
  tagNo: string;
  itCode: string;
  oldNetWt: string;
  newNetWt: string;
  touch: string;
  rate: string;
}
const blank = (): Line => ({
  tagNo: '',
  itCode: '',
  oldNetWt: '',
  newNetWt: '',
  touch: '',
  rate: '',
});

// Live preview math — mirrors tagOps.tagWeightDiff (N/r3/r2) so the footer predicts the posted result.
const N = (v: string): number => Number(v || 0);
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
const r2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const lineDiff = (l: Line): number => r3(N(l.newNetWt) - N(l.oldNetWt)); // signed (new − old)
const lineDiffFine = (l: Line): number => r3((Math.abs(lineDiff(l)) * N(l.touch)) / 100); // |diff|·touch/100
const lineValue = (l: Line): number => r2(lineDiffFine(l) * N(l.rate)); // diffFine·rate
const containment = parityContainmentRule('tag-weight-difference');

export default function TagWeightDiffPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [partyAc, setPartyAc] = useState('');
  const [absorbItCode, setAbsorbItCode] = useState('');
  const [payAc, setPayAc] = useState('');
  const [payAmt, setPayAmt] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => setLines((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [res, setRes] = useState<any>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  // P3: absorbSign selects whether the weight difference is absorbed as a gain or a loss.
  const [absorbSign, setAbsorbSign] = useState('');
  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // Footer totals are signed by direction (increase +, decrease −) to match the backend's net result.
  const totDiff = r3(lines.reduce((s, l) => s + lineDiff(l), 0));
  const totDiffFine = r3(
    lines.reduce((s, l) => s + (lineDiff(l) >= 0 ? lineDiffFine(l) : -lineDiffFine(l)), 0),
  );
  const totValue = r2(
    lines.reduce((s, l) => s + (lineDiff(l) >= 0 ? lineValue(l) : -lineValue(l)), 0),
  );

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    if (containment.blocked) {
      setErr(parityContainmentMessage('tag-weight-difference'));
      return;
    }
    setBusy(true);
    try {
      setRes(
        await post('/stock/tag-weight-diff', {
          absorbSign: absorbSign.trim() || undefined,
          coBook: coBook || undefined,
          coYear: coYear || undefined,
          lcCode: lcCode || undefined,
          partyAc: partyAc || undefined,
          absorbItCode: absorbItCode || undefined,
          payAc: payAc || undefined,
          payAmt: Number(payAmt || 0) || undefined,
          lines: lines
            .filter((l) => l.tagNo && l.itCode)
            .map((l) => ({
              tagNo: l.tagNo,
              itCode: l.itCode,
              oldNetWt: Number(l.oldNetWt || 0),
              newNetWt: Number(l.newNetWt || 0),
              touch: Number(l.touch || 0),
              rate: Number(l.rate || 0),
            })),
        }),
      );
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || 'failed' : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Tag Weight Difference</h1>
      <ParityContainmentNotice operation="tag-weight-difference" />
      <p className="muted">
        Correct a tag&apos;s net weight. The net difference (new − old) is booked as a signed stock
        movement and valued at rate. Pick a tag to autofill its item, current net weight, touch and
        rate.
      </p>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Absorb Sign (+/-)</label>
              <input value={absorbSign} onChange={(e) => setAbsorbSign(e.target.value)} />
            </div>
          </div>
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="TWD" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly placeholder="(session default)" />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly placeholder="(session default)" />
            </div>
            <div className="field">
              <label>Karigar (party)</label>
              <LookupPicker entity="accounts" value={partyAc} onChange={setPartyAc} />
            </div>
            <div className="field">
              <label>Absorb item</label>
              <LookupPicker entity="items" value={absorbItCode} onChange={setAbsorbItCode} />
            </div>
            <div className="field">
              <label>Pay A/c</label>
              <LookupPicker entity="accounts" value={payAc} onChange={setPayAc} />
            </div>
            <div className="field">
              <label>Pay Amt</label>
              <input
                value={payAmt}
                onChange={(e) => setPayAmt(e.target.value)}
                placeholder="labour paid"
              />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Weight Changes</h2>
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Tag</th>
                <th>Item</th>
                <th className="num">Old Net Wt</th>
                <th className="num">New Net Wt</th>
                <th className="num">Touch %</th>
                <th className="num">Rate</th>
                <th className="num">Diff</th>
                <th className="num">Diff Fine</th>
                <th className="num">Value</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => {
                const d = lineDiff(l);
                return (
                  <tr key={i}>
                    <td>
                      <LookupPicker
                        entity="tags"
                        value={l.tagNo}
                        onChange={(v) => setLine(i, 'tagNo', v)}
                        style={{ width: 120 }}
                        onPick={(r) =>
                          setLines((ls) =>
                            ls.map((x, j) =>
                              j === i
                                ? {
                                    ...x,
                                    tagNo: String(r.code),
                                    itCode: String(r.name || x.itCode),
                                    oldNetWt: String(r.ITM_NWT ?? x.oldNetWt),
                                    touch: String(r.ITM_TOUCH ?? x.touch),
                                    rate: String(r.ITM_RATE ?? x.rate),
                                  }
                                : x,
                            ),
                          )
                        }
                      />
                    </td>
                    <td>
                      <input
                        style={{ width: 90 }}
                        value={l.itCode}
                        onChange={(e) => setLine(i, 'itCode', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 84, textAlign: 'right' }}
                        value={l.oldNetWt}
                        onChange={(e) => setLine(i, 'oldNetWt', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 84, textAlign: 'right' }}
                        value={l.newNetWt}
                        onChange={(e) => setLine(i, 'newNetWt', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 60, textAlign: 'right' }}
                        value={l.touch}
                        onChange={(e) => setLine(i, 'touch', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 72, textAlign: 'right' }}
                        value={l.rate}
                        onChange={(e) => setLine(i, 'rate', e.target.value)}
                      />
                    </td>
                    <td
                      className="num"
                      style={{ color: d > 0 ? 'var(--ok)' : d < 0 ? 'var(--err)' : undefined }}
                    >
                      {d}
                    </td>
                    <td className="num">{lineDiffFine(l)}</td>
                    <td className="num">{lineValue(l).toLocaleString('en-IN')}</td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() => setLines((ls) => ls.filter((_, j) => j !== i))}
                      >
                        ×
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
            <tfoot>
              <tr>
                <th colSpan={6} style={{ textAlign: 'right' }}>
                  Net totals
                </th>
                <th
                  className="num"
                  style={{
                    color: totDiff > 0 ? 'var(--ok)' : totDiff < 0 ? 'var(--err)' : undefined,
                  }}
                >
                  {totDiff}
                </th>
                <th className="num">{totDiffFine}</th>
                <th className="num">{totValue.toLocaleString('en-IN')}</th>
                <th></th>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add tag
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Net diff {totDiff} g · Diff fine {totDiffFine} g · Value ₹
              {totValue.toLocaleString('en-IN')}
            </span>
            <button className="primary" data-save-mnemonic disabled={busy || containment.blocked}>
              {busy ? 'Posting…' : 'Post Weight Change'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Weight-change voucher #{res.vchNo} posted — {res.tags} tag(s) · diff fine {res.diffFine}{' '}
            g · value ₹{Number(res.value ?? 0).toLocaleString('en-IN')}
          </div>
        </div>
      )}
    </div>
  );
}
