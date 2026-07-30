'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';

/**
 * Tag Split (TR_TAG_SPLIT) — split one parent stock tag into several child tags. POSTs to
 * /stock/tag-split (splitTag), which writes one MAIN_STOCK out-movement for the parent (VCH_TYPE
 * 'TGSPL', ITM_SIGN '-', full weight/fine) and one in-movement per child (ITM_SIGN '+', fine =
 * net·touch/100). Pure inventory re-tag — no money ledger. Picking the parent tag autofills its
 * item/net/gross/touch/fine from the BAR_DETL lookup (mirroring the desktop F-key lookup); the
 * children must redistribute the parent's full net weight (remaining ≈ 0) before the split posts.
 */
interface Parent {
  tagNo: string;
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  fineWt: string;
}
interface Child {
  tagNo: string;
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
}
const blankParent = (): Parent => ({
  tagNo: '',
  itCode: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  fineWt: '',
});
const blankChild = (): Child => ({
  tagNo: '',
  itCode: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
});

// Live preview math — mirrors tagSplit.splitTag (N/r3) so the grid predicts the posted fine.
const N = (v: string): number => Number(v || 0);
const r3 = (n: number): number => Math.round((n + 1e-9) * 1000) / 1000;
const childFine = (c: Child): number => r3((N(c.netWt) * N(c.touch)) / 100); // net·touch/100

export default function TagSplitPage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [parent, setParent] = useState<Parent>(blankParent());
  const [children, setChildren] = useState<Child[]>([blankChild(), blankChild()]);
  const [res, setRes] = useState<{ vchNo: number; children: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setP = (k: keyof Parent, v: string) => setParent((p) => ({ ...p, [k]: v }));
  const setChild = (i: number, k: keyof Child, v: string) =>
    setChildren((cs) => cs.map((c, j) => (j === i ? { ...c, [k]: v } : c)));

  // Running balance: how much of the parent's net weight is still unallocated to children.
  const childNetSum = r3(children.reduce((s, c) => s + N(c.netWt), 0));
  const childFineSum = r3(children.reduce((s, c) => s + childFine(c), 0));
  const remaining = r3(N(parent.netWt) - childNetSum);
  const balanced = Math.abs(remaining) <= 0.01;
  const validChildren = children.filter((c) => c.tagNo && c.itCode);
  const canSubmit =
    !busy &&
    !!parent.tagNo &&
    !!parent.itCode &&
    N(parent.netWt) > 0 &&
    validChildren.length > 0 &&
    balanced;

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        parent: {
          tagNo: parent.tagNo,
          itCode: parent.itCode,
          pcs: N(parent.pcs),
          netWt: N(parent.netWt),
          grossWt: N(parent.grossWt),
          touch: N(parent.touch),
          fineWt: N(parent.fineWt),
        },
        children: validChildren.map((c) => ({
          tagNo: c.tagNo,
          itCode: c.itCode,
          pcs: N(c.pcs),
          netWt: N(c.netWt),
          grossWt: N(c.grossWt),
          touch: N(c.touch),
        })),
      };
      setRes(await post('/stock/tag-split', body));
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || e.body?.detail || e.message
          : 'failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Tag Split</h1>
      <p className="muted">
        Split one stock tag into several child tags. The parent posts a stock-out movement
        (MAIN_STOCK, VCH_TYPE &lsquo;TGSPL&rsquo;) and each child a stock-in — no money ledger.
        Children must redistribute the parent&apos;s full net weight.
      </p>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="TSP" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
          </div>
        </div>

        <div className="panel">
          <h2>Parent Tag</h2>
          <div className="row">
            <div className="field">
              <label>Tag</label>
              <LookupPicker
                entity="tags"
                value={parent.tagNo}
                onChange={(v) => setP('tagNo', v)}
                style={{ width: 160 }}
                onPick={(r) =>
                  setParent((p) => ({
                    ...p,
                    tagNo: String(r.code),
                    itCode: String(r.name ?? p.itCode),
                    netWt: String(r.ITM_NWT ?? p.netWt),
                    grossWt: String(r.ITM_GWT ?? p.grossWt),
                    touch: String(r.ITM_TOUCH ?? p.touch),
                    fineWt: String(r.ITM_FINE ?? p.fineWt),
                  }))
                }
              />
            </div>
            <div className="field">
              <label>Item</label>
              <input
                style={{ width: 100 }}
                value={parent.itCode}
                onChange={(e) => setP('itCode', e.target.value)}
              />
            </div>
            <div className="field">
              <label>Pcs</label>
              <input
                style={{ width: 56, textAlign: 'right' }}
                value={parent.pcs}
                onChange={(e) => setP('pcs', e.target.value)}
              />
            </div>
            <div className="field">
              <label>Gross Wt</label>
              <input
                style={{ width: 80, textAlign: 'right' }}
                value={parent.grossWt}
                onChange={(e) => setP('grossWt', e.target.value)}
              />
            </div>
            <div className="field">
              <label>Net Wt</label>
              <input
                style={{ width: 80, textAlign: 'right' }}
                value={parent.netWt}
                onChange={(e) => setP('netWt', e.target.value)}
              />
            </div>
            <div className="field">
              <label>Touch %</label>
              <input
                style={{ width: 64, textAlign: 'right' }}
                value={parent.touch}
                onChange={(e) => setP('touch', e.target.value)}
              />
            </div>
            <div className="field">
              <label>Fine</label>
              <input
                style={{ width: 80, textAlign: 'right' }}
                value={parent.fineWt}
                onChange={(e) => setP('fineWt', e.target.value)}
              />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Child Tags</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Tag</th>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch %</th>
                <th className="num">Fine</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {children.map((c, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={c.tagNo}
                      onChange={(v) => setChild(i, 'tagNo', v)}
                      style={{ width: 120 }}
                      onPick={(r) =>
                        setChildren((cs) =>
                          cs.map((x, j) =>
                            j === i
                              ? {
                                  ...x,
                                  tagNo: String(r.code),
                                  itCode: String(r.name ?? x.itCode),
                                  netWt: String(r.ITM_NWT ?? x.netWt),
                                  grossWt: String(r.ITM_GWT ?? x.grossWt),
                                  touch: String(r.ITM_TOUCH ?? x.touch),
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
                      value={c.itCode}
                      onChange={(e) => setChild(i, 'itCode', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 44, textAlign: 'right' }}
                      value={c.pcs}
                      onChange={(e) => setChild(i, 'pcs', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 76, textAlign: 'right' }}
                      value={c.netWt}
                      onChange={(e) => setChild(i, 'netWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 60, textAlign: 'right' }}
                      value={c.touch}
                      onChange={(e) => setChild(i, 'touch', e.target.value)}
                    />
                  </td>
                  <td className="num">{childFine(c)}</td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() => setChildren((cs) => cs.filter((_, j) => j !== i))}
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <th colSpan={3} style={{ textAlign: 'right' }}>
                  Children total
                </th>
                <th className="num">{childNetSum}</th>
                <th></th>
                <th className="num">{childFineSum}</th>
                <th></th>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setChildren((cs) => [...cs, blankChild()])}
            >
              + Add child
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Parent net {r3(N(parent.netWt))} g · children {childNetSum} g ·{' '}
              <b style={{ color: balanced ? 'var(--ok)' : 'var(--err)' }}>
                remaining {remaining} g
              </b>
            </span>
            <button className="primary" disabled={!canSubmit}>
              {busy ? 'Splitting…' : 'Split Tag'}
            </button>
          </div>
          {!balanced && (N(parent.netWt) > 0 || childNetSum > 0) && (
            <div className="msg" style={{ marginTop: 8 }}>
              Children net weight must equal the parent net weight (remaining must be ≈ 0) before
              the tag can be split.
            </div>
          )}
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Split voucher #{res.vchNo} created — parent split into {res.children} child tag(s)
          </div>
        </div>
      )}
    </div>
  );
}
