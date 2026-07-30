'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../lib/api';
import { LookupPicker } from './LookupPicker';
import { EntityImagePanel } from './EntityImagePanel';

/** Karigar (goldsmith) issue/receive. Issue = raw fine metal OUT; Receive = finished ornaments IN
 *  (wastage folded into fine), with per-line labour + optional GST + optional barcode tagging (F3). */
interface Line {
  itCode: string;
  designNo: string;
  tblCode: string;
  itmSize: string;
  pcs: string;
  grossWt: string;
  othWt: string;
  netWt: string;
  ghtWt: string;
  touch: string;
  westPct: string;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  tag: boolean;
  // Desktop karigar-grid columns (TR_PURC shared detail block).
  amount: string;
  bagWt: string;
  convPct: string;
  convRate: string;
  itDesc: string;
  lbrPct: string;
  lesWt: string;
  lessTouch: string;
  lossWt: string;
  lotNo: string;
  mrp: string;
  oldSrNo: string;
  otherFine: string;
  otherRate: string;
  rate: string;
  rateType: string;
  tagNo: string;
  totalAmount: string;
  withStock: string;
}
const extendedKarigarFields: Array<[keyof Line, string]> = [
  ['amount', 'Amount'],
  ['bagWt', 'Bag Wt'],
  ['convPct', 'Conv Pct'],
  ['convRate', 'Conv Rate'],
  ['itDesc', 'It Desc'],
  ['lbrPct', 'Lbr Pct'],
  ['lesWt', 'Les Wt'],
  ['lessTouch', 'Less Touch'],
  ['lossWt', 'Loss Wt'],
  ['lotNo', 'Lot No'],
  ['mrp', 'Mrp'],
  ['oldSrNo', 'Old Sr No'],
  ['otherFine', 'Other Fine'],
  ['otherRate', 'Other Rate'],
  ['rate', 'Rate'],
  ['rateType', 'Rate Type'],
  ['tagNo', 'Tag No'],
  ['totalAmount', 'Total Amount'],
  ['withStock', 'With Stock'],
];
const blank = (): Line => ({
  itCode: '',
  designNo: '',
  tblCode: '001',
  itmSize: '',
  pcs: '1',
  grossWt: '',
  othWt: '',
  netWt: '',
  ghtWt: '',
  touch: '',
  westPct: '',
  lbrType: 'G',
  lbrRate: '',
  lbrAmt: '',
  othAmt: '',
  tag: false,
  amount: '',
  bagWt: '',
  convPct: '',
  convRate: '',
  itDesc: '',
  lbrPct: '',
  lesWt: '',
  lessTouch: '',
  lossWt: '',
  lotNo: '',
  mrp: '',
  oldSrNo: '',
  otherFine: '',
  otherRate: '',
  rate: '',
  rateType: '',
  tagNo: '',
  totalAmount: '',
  withStock: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function KarigarForm({
  mode,
  label = 'Karigar',
}: {
  mode: 'issue' | 'receive';
  label?: string;
}) {
  const ep = mode === 'issue' ? '/karigar/issue' : '/karigar/receive';
  const title = mode === 'issue' ? `${label} Issue — metal OUT` : `${label} Receive — metal IN`;
  const rcv = mode === 'receive';
  const [karigarAc, setKarigarAc] = useState('');
  const [karigarName, setKarigarName] = useState('');
  const [labourGstPct, setLabourGstPct] = useState('5');
  const [interState, setInterState] = useState(false);
  const [lines, setLines] = useState<Line[]>([blank()]);
  // Shared by jobwork issue/receive and karigar issue/receive: the desktop images the tag on the
  // current grid row (TR_JDT_REC / TR_MFG_KR_ISU_REC), so one panel serves all four forms.
  const [imageRow, setImageRow] = useState(0);
  const [res, setRes] = useState<any>(null);
  const [bal, setBal] = useState<number | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string | boolean) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));
  const fine = (l: Line) => r3((n(l.netWt) * (n(l.touch) + (rcv ? n(l.westPct) : 0))) / 100);
  const totFine = r3(lines.reduce((s, l) => s + fine(l), 0));
  const totLabour = r2(lines.reduce((s, l) => s + n(l.lbrAmt), 0));
  const totGst = r2((totLabour * n(labourGstPct)) / 100);

  async function checkBalance(ac = karigarAc) {
    if (!ac) return;
    try {
      const r = await get<any>(`/karigar/${encodeURIComponent(ac)}/balance`);
      setBal(r.balance);
    } catch {
      setBal(null);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      const body: any = {
        karigarAc,
        karigarName: karigarName || undefined,
        lines: lines
          .filter((l) => l.netWt)
          .map((l) => ({
            itCode: l.itCode || undefined,
            designNo: l.designNo || undefined,
            tblCode: l.tblCode || undefined,
            itmSize: l.itmSize || undefined,
            amount: n(l.amount) || undefined,
            bagWt: n(l.bagWt) || undefined,
            convPct: n(l.convPct) || undefined,
            convRate: n(l.convRate) || undefined,
            itDesc: l.itDesc || undefined,
            lbrPct: n(l.lbrPct) || undefined,
            lesWt: n(l.lesWt) || undefined,
            lessTouch: n(l.lessTouch) || undefined,
            lossWt: n(l.lossWt) || undefined,
            lotNo: l.lotNo || undefined,
            mrp: n(l.mrp) || undefined,
            oldSrNo: n(l.oldSrNo) || undefined,
            otherFine: n(l.otherFine) || undefined,
            otherRate: n(l.otherRate) || undefined,
            rate: n(l.rate) || undefined,
            rateType: l.rateType || undefined,
            tagNo: n(l.tagNo) || undefined,
            totalAmount: n(l.totalAmount) || undefined,
            withStock: l.withStock || undefined,

            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            othWt: n(l.othWt),
            netWt: n(l.netWt),
            ghtWt: n(l.ghtWt),
            touch: n(l.touch),
            lbrType: l.lbrType || undefined,
            lbrRate: n(l.lbrRate),
            ...(rcv
              ? { westPct: n(l.westPct), lbrAmt: n(l.lbrAmt), othAmt: n(l.othAmt), tag: l.tag }
              : {}),
          })),
      };
      if (rcv) {
        body.labourGstPct = n(labourGstPct);
        body.interState = interState;
      }
      const r = await post(ep, body);
      setRes(r);
      setLines([blank()]);
      checkBalance();
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>{title}</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Karigar</label>
              <LookupPicker
                entity="accounts"
                value={karigarAc}
                onChange={(v) => {
                  setKarigarAc(v);
                }}
                onPick={(row) => {
                  if (row?.name) setKarigarName(String(row.name));
                  checkBalance(String(row.code));
                }}
              />
            </div>
            <div className="field">
              <label>Name</label>
              <input value={karigarName} onChange={(e) => setKarigarName(e.target.value)} />
            </div>
            {rcv && (
              <div className="field">
                <label>Labour GST %</label>
                <input
                  value={labourGstPct}
                  onChange={(e) => setLabourGstPct(e.target.value)}
                  style={{ width: 60 }}
                />
              </div>
            )}
            {rcv && (
              <div className="field">
                <label>Inter-state</label>
                <select
                  value={interState ? 'y' : 'n'}
                  onChange={(e) => setInterState(e.target.value === 'y')}
                >
                  <option value="n">No</option>
                  <option value="y">Yes</option>
                </select>
              </div>
            )}
            <div className="field" style={{ justifyContent: 'flex-end' }}>
              <button type="button" className="ghost" onClick={() => checkBalance()}>
                Check balance
              </button>
            </div>
          </div>
          {bal !== null && (
            <div className="msg">
              Metal balance for {karigarAc}: <b>{bal} fine</b>{' '}
              {bal > 0 ? '(karigar owes us)' : bal < 0 ? '(we owe karigar)' : '(settled)'}
            </div>
          )}
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Metal Lines</h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Item</th>
                <th>Design</th>
                <th>Ctr</th>
                <th>Size</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Oth Wt</th>
                <th className="num">Net Wt</th>
                <th className="num">Ght Wt</th>
                <th className="num">Touch%</th>
                {rcv && <th className="num">West%</th>}
                <th className="num">Fine</th>
                {rcv && (
                  <>
                    <th>LType</th>
                    <th className="num">LRate</th>
                    <th className="num">Lbr Amt</th>
                    <th className="num">Oth Amt</th>
                    <th>Tag</th>
                  </>
                )}
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={l.itCode}
                      onChange={(v) => setLine(i, 'itCode', v)}
                      style={{ width: 74 }}
                    />
                  </td>
                  <td>
                    <input
                      value={l.designNo}
                      onChange={(e) => setLine(i, 'designNo', e.target.value)}
                      style={{ width: 60 }}
                    />
                  </td>
                  <td>
                    <input
                      value={l.tblCode}
                      onChange={(e) => setLine(i, 'tblCode', e.target.value)}
                      style={{ width: 36 }}
                    />
                  </td>
                  <td>
                    <input
                      value={l.itmSize}
                      onChange={(e) => setLine(i, 'itmSize', e.target.value)}
                      style={{ width: 44 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 38, textAlign: 'right' }}
                      value={l.pcs}
                      onChange={(e) => setLine(i, 'pcs', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.grossWt}
                      onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 50, textAlign: 'right' }}
                      value={l.othWt}
                      onChange={(e) => setLine(i, 'othWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.netWt}
                      onChange={(e) => setLine(i, 'netWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 50, textAlign: 'right' }}
                      value={l.ghtWt}
                      onChange={(e) => setLine(i, 'ghtWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 50, textAlign: 'right' }}
                      value={l.touch}
                      onChange={(e) => setLine(i, 'touch', e.target.value)}
                    />
                  </td>
                  {rcv && (
                    <td className="num">
                      <input
                        style={{ width: 46, textAlign: 'right' }}
                        value={l.westPct}
                        onChange={(e) => setLine(i, 'westPct', e.target.value)}
                      />
                    </td>
                  )}
                  <td className="num">{fine(l).toLocaleString('en-IN')}</td>
                  {rcv && (
                    <>
                      <td>
                        <select
                          value={l.lbrType}
                          onChange={(e) => setLine(i, 'lbrType', e.target.value)}
                          style={{ width: 48 }}
                        >
                          <option value="G">/g</option>
                          <option value="P">/pc</option>
                          <option value="N">Fix</option>
                          <option value="%">%</option>
                        </select>
                      </td>
                      <td className="num">
                        <input
                          style={{ width: 52, textAlign: 'right' }}
                          value={l.lbrRate}
                          onChange={(e) => setLine(i, 'lbrRate', e.target.value)}
                        />
                      </td>
                      <td className="num">
                        <input
                          style={{ width: 60, textAlign: 'right' }}
                          value={l.lbrAmt}
                          onChange={(e) => setLine(i, 'lbrAmt', e.target.value)}
                        />
                      </td>
                      <td className="num">
                        <input
                          style={{ width: 54, textAlign: 'right' }}
                          value={l.othAmt}
                          onChange={(e) => setLine(i, 'othAmt', e.target.value)}
                        />
                      </td>
                      <td style={{ textAlign: 'center' }}>
                        <input
                          type="checkbox"
                          checked={l.tag}
                          onChange={(e) => setLine(i, 'tag', e.target.checked)}
                          title="tag into barcoded stock"
                        />
                      </td>
                    </>
                  )}
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() =>
                        setLines((ls) => (ls.length > 1 ? ls.filter((_, j) => j !== i) : [blank()]))
                      }
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
          {lines.map((line, index) => (
            <details key={`kr-line-extra-${index}`} style={{ marginTop: 8 }}>
              <summary>Row {index + 1} desktop fields</summary>
              <div className="row">
                {extendedKarigarFields.map(([key, label]) => (
                  <div className="field" key={String(key)}>
                    <label>{label}</label>
                    <input
                      value={String(line[key] ?? '')}
                      onChange={(e) => setLine(index, key, e.target.value)}
                    />
                  </div>
                ))}
              </div>
            </details>
          ))}
          <div className="toolbar" style={{ marginTop: 10 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setLines((ls) => [...ls, blank()])}
            >
              + Add line
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 16 }}>
              Fine <b>{totFine}</b>
              {rcv
                ? ` · Labour ₹${totLabour.toLocaleString('en-IN')} · GST ₹${totGst.toLocaleString('en-IN')}`
                : ''}
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Save'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="msg ok">
            Saved — Voucher #{res.vchNo} · fine {res.fineIssued ?? res.fineReceived}
            {res.labourAmt
              ? ` · labour ₹${res.labourAmt}` + (res.labourGst ? ` + GST ₹${res.labourGst}` : '')
              : ''}
          </div>
          {!rcv && (
            <div className="toolbar" style={{ marginTop: 6 }}>
              <button
                type="button"
                className="ghost"
                onClick={() =>
                  window.open(
                    `/api/karigar/issue-voucher?coBook=KIS&vchNo=${encodeURIComponent(String(res.vchNo))}&format=html`,
                    '_blank',
                  )
                }
              >
                View Issue Voucher
              </button>
            </div>
          )}
          {res.tagNos?.length ? (
            <div className="muted" style={{ marginTop: 6 }}>
              Generated barcodes: <code>{res.tagNos.join(', ')}</code>
            </div>
          ) : null}
        </div>
      )}
      <EntityImagePanel
        entityType="TAG"
        entityKey={lines[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="karigar-image"
      />
    </div>
  );
}
