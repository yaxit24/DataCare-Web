'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

/** Design Issue against a Sales Order (TR_MFG_ORD_ISU) — issue a design into the shop against an open
 *  order line; writes MFG_DATA/DETL/ISU_REC (issue, IR_TYPE 'D', book DIS) + ORD_* link, and marks
 *  the consumed SL_ORD_DETL line DESIGN_ISU='Y'. Reverse re-opens it. POST /mfg/order-issue. */
interface Row {
  itCode: string;
  designNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  ordNo: string;
  ordSrno: string;
  ordAcCode: string;
  totalGrossWt: string;
  totalLessWt: string;
  totalNetWt: string;
  karigarJobworkWt: string;
  karigarMinorityWt: string;
  karigarMinorityAmount: string;
  oldGrossWt: string;
  oldNetWt: string;
  oldFine: string;
  oldLabourAmount: string;
  oldOther: string;
  addOtherWt: string;
  lessOtherWt: string;
  rateType: string;
  prCode: string;
  fittingItCode: string;
  adjustDate: string;
  isuItCode: string;
  itemRemark: string;
  lotNo: string;
  tagNo: string;
  designSrNo: string;
  size: string;
  othWt: string;
  ghtPct: string;
  ghtWt: string;
  westPct: string;
  fineWt: string;
  rtnChol: string;
  rtnGhis: string;
  itmGhat: string;
  itmLoss: string;
  mtrlWt: string;
  mtrlItCode: string;
  dmPcs: string;
  dmWt: string;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  itRate: string;
  itAmt: string;
  netAmt: string;
  krName: string;
  repYrcd: string;
  repDbcd: string;
  repNo: string;
  repSrno: string;
  repAcCode: string;
  ordYrcd: string;
  ordDbcd: string;
}
/**
 * P7 extended grid columns: desktop columns this form has and the web did not.
 *
 * Every entry was verified against the WRITER, not the API interface — a field present on the
 * interface is not necessarily persisted (purchase hard-codes ITM_SIZE to blank, and five
 * SaleLineInput fields have no SL_DETL column at all), and such a cell would silently discard
 * what the operator types.
 */
const extendedLineFields: Array<[keyof Row, string]> = [
  ['totalGrossWt', 'TotGwt'],
  ['totalLessWt', 'TotLsWt'],
  ['totalNetWt', 'TotNwt'],
  ['karigarJobworkWt', 'KrJobWt'],
  ['karigarMinorityWt', 'KrMinWt'],
  ['karigarMinorityAmount', 'KrMinAmt'],
  ['oldGrossWt', 'OldGwt'],
  ['oldNetWt', 'OldNwt'],
  ['oldFine', 'OldFine'],
  ['oldLabourAmount', 'OldLbrAmt'],
  ['oldOther', 'OldOth'],
  ['addOtherWt', 'AddOthWt'],
  ['lessOtherWt', 'LessOthWt'],
  ['rateType', 'RateType'],
  ['prCode', 'PrCost'],
  ['fittingItCode', 'FitItCode'],
  ['adjustDate', 'AdjDate'],
  ['isuItCode', 'IsuItCode'],
  ['itemRemark', 'Remark'],
  ['lotNo', 'LotNo'],
  ['tagNo', 'TagNo'],
  ['designSrNo', 'DesignSr'],
  ['size', 'Size'],
  ['othWt', 'OthWt'],
  ['ghtPct', 'Ght%'],
  ['ghtWt', 'GhtWt'],
  ['westPct', 'West%'],
  ['fineWt', 'Fine'],
  ['rtnChol', 'RtnChol'],
  ['rtnGhis', 'RtnGhis'],
  ['itmGhat', 'ItmGhat'],
  ['itmLoss', 'ItmLoss'],
  ['mtrlWt', 'MtrlWt'],
  ['mtrlItCode', 'MtrlItCode'],
  ['dmPcs', 'DmPcs'],
  ['dmWt', 'DmWt'],
  ['lbrType', 'LType'],
  ['lbrRate', 'LbrRate'],
  ['lbrAmt', 'LbrAmt'],
  ['othAmt', 'OthAmt'],
  ['itRate', 'ItRate'],
  ['itAmt', 'ItAmt'],
  ['netAmt', 'NetAmt'],
  ['krName', 'KrName'],
  ['repYrcd', 'RepYr'],
  ['repDbcd', 'RepBk'],
  ['repNo', 'RepNo'],
  ['repSrno', 'RepSr'],
  ['repAcCode', 'RepAc'],
  ['ordYrcd', 'OrdYr'],
  ['ordDbcd', 'OrdBk'],
];

/** Fields the API takes as numbers; everything else stays a string so codes are not mangled. */
const NUMERIC_EXTENDED = new Set<string>([
  'totalGrossWt',
  'totalLessWt',
  'totalNetWt',
  'karigarJobworkWt',
  'karigarMinorityWt',
  'karigarMinorityAmount',
  'oldGrossWt',
  'oldNetWt',
  'oldFine',
  'oldLabourAmount',
  'addOtherWt',
  'lessOtherWt',
  'designSrNo',
  'othWt',
  'ghtPct',
  'ghtWt',
  'westPct',
  'fineWt',
  'itmGhat',
  'itmLoss',
  'mtrlWt',
  'dmPcs',
  'dmWt',
  'lbrRate',
  'lbrAmt',
  'othAmt',
  'itRate',
  'itAmt',
  'netAmt',
  'repSrno',
]);

const blank = (): Row => ({
  itCode: '',
  designNo: '',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
  ordNo: '',
  ordSrno: '',
  ordAcCode: '',
  totalGrossWt: '',
  totalLessWt: '',
  totalNetWt: '',
  karigarJobworkWt: '',
  karigarMinorityWt: '',
  karigarMinorityAmount: '',
  oldGrossWt: '',
  oldNetWt: '',
  oldFine: '',
  oldLabourAmount: '',
  oldOther: '',
  addOtherWt: '',
  lessOtherWt: '',
  rateType: '',
  prCode: '',
  fittingItCode: '',
  adjustDate: '',
  isuItCode: '',
  itemRemark: '',
  lotNo: '',
  tagNo: '',
  designSrNo: '',
  size: '',
  othWt: '',
  ghtPct: '',
  ghtWt: '',
  westPct: '',
  fineWt: '',
  rtnChol: '',
  rtnGhis: '',
  itmGhat: '',
  itmLoss: '',
  mtrlWt: '',
  mtrlItCode: '',
  dmPcs: '',
  dmWt: '',
  lbrType: '',
  lbrRate: '',
  lbrAmt: '',
  othAmt: '',
  itRate: '',
  itAmt: '',
  netAmt: '',
  krName: '',
  repYrcd: '',
  repDbcd: '',
  repNo: '',
  repSrno: '',
  repAcCode: '',
  ordYrcd: '',
  ordDbcd: '',
});
const n = (v: string) => Number(v || 0);

export default function MfgOrderIssuePage() {
  const [karigarAc, setKarigarAc] = useState('');
  const [karigarName, setKarigarName] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [rows, setRows] = useState<Row[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: rows.length,
    onAppendRow: () => setRows((rows) => [...rows, blank()]),
    onRemoveRow: (row) => {
      setRows((rows) => (rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row)));
      return true;
    },
    onEscape: () => {},
  });
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  const [res, setRes] = useState<{ vchNo: number; fineIssued: number } | null>(null);
  const [msg, setMsg] = useState<{ kind: 'ok' | 'err'; text: string } | null>(null);
  const [busy, setBusy] = useState(false);
  const set = (i: number, k: keyof Row, v: string) =>
    setRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setMsg(null);
    setRes(null);
    if (!karigarAc.trim()) {
      setMsg({ kind: 'err', text: 'karigar/process account is required' });
      return;
    }
    const lines = rows
      .filter((r) => r.itCode.trim())
      .map((r) => ({
        // P7: writer-verified extended columns. A blank cell is OMITTED, never sent as 0 — an
        // explicit zero is an override at the writer and defeats the server's own derivation.
        ...Object.fromEntries(
          extendedLineFields
            .map(([key]) => [
              key,
              String((r as unknown as Record<string, unknown>)[key] ?? '').trim(),
            ])
            .filter(([, v]) => v !== '')
            .map(([key, v]) => [key, NUMERIC_EXTENDED.has(key as string) ? Number(v) : v]),
        ),
        itCode: r.itCode.trim(),
        designNo: r.designNo.trim() || undefined,
        pcs: n(r.pcs),
        grossWt: n(r.grossWt),
        netWt: n(r.netWt),
        touch: n(r.touch),
        ordNo: r.ordNo.trim() || undefined,
        ordSrno: r.ordSrno ? n(r.ordSrno) : undefined,
        ordAcCode: r.ordAcCode.trim() || undefined,
        ordDesign: r.designNo.trim() || undefined,
      }));
    if (!lines.length) {
      setMsg({ kind: 'err', text: 'enter at least one design line' });
      return;
    }
    setBusy(true);
    try {
      const r = await post<{ vchNo: number; fineIssued: number }>('/mfg/order-issue', {
        karigarAc: karigarAc.trim(),
        karigarName: karigarName || undefined,
        vchDate: vchDate || undefined,
        lines,
      });
      setRes(r);
      setMsg({
        kind: 'ok',
        text: `Design issued — voucher #${r.vchNo}, fine ${Number(r.fineIssued).toLocaleString('en-IN')} g (orders marked issued)`,
      });
      setRows([blank()]);
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
        Design Issue — against Sales Order <span className="muted">— TR_MFG_ORD_ISU</span>
      </h1>
      {msg && <div className={`msg ${msg.kind}`}>{msg.text}</div>}
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field" style={{ flex: 2 }}>
              <label>Karigar / Process</label>
              <LookupPicker
                entity="accounts"
                value={karigarAc}
                onChange={setKarigarAc}
                onPick={(r) => setKarigarName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Name</label>
              <input value={karigarName} onChange={(e) => setKarigarName(e.target.value)} />
            </div>
            <div className="field">
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
          </div>
        </div>
        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>
            Designs issued{' '}
            <span className="muted">(enter the open order # &amp; line they fulfil)</span>
          </h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="mfg-order-issue-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Design</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch</th>
                <th className="num">Order #</th>
                <th className="num">Ord Line</th>
                <th>Order Cust</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                <th></th>
              </tr>
            </thead>
            <tbody>
              {rows.map((r, i) => (
                <tr key={i}>
                  <td>
                    <LookupPicker
                      entity="items"
                      value={r.itCode}
                      onChange={(v) => set(i, 'itCode', v)}
                      style={{ width: 90 }}
                    />
                  </td>
                  <td>
                    <input
                      value={r.designNo}
                      onChange={(e) => set(i, 'designNo', e.target.value)}
                      style={{ width: 80 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.pcs}
                      onChange={(e) => set(i, 'pcs', e.target.value)}
                      style={{ width: 50, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.grossWt}
                      onChange={(e) => set(i, 'grossWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.netWt}
                      onChange={(e) => set(i, 'netWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.touch}
                      onChange={(e) => set(i, 'touch', e.target.value)}
                      style={{ width: 56, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.ordNo}
                      onChange={(e) => set(i, 'ordNo', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={r.ordSrno}
                      onChange={(e) => set(i, 'ordSrno', e.target.value)}
                      style={{ width: 56, textAlign: 'right' }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="accounts"
                      value={r.ordAcCode}
                      onChange={(v) => set(i, 'ordAcCode', v)}
                      style={{ width: 100 }}
                    />
                  </td>
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedLineFields}
                    line={r}
                    row={i}
                    baseColumns={10}
                    setValue={(row, key, value) => set(row, key, value)}
                  />
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
              + Add design
            </button>
            <span className="spacer" />
            <span className="muted" style={{ marginRight: 12 }}>
              POST /mfg/order-issue
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Issuing…' : 'Issue Designs'}
            </button>
          </div>
          {res && (
            <div className="tiles" style={{ marginTop: 10 }}>
              <div className="tile">
                <div className="muted">voucher</div>
                <div className="big kpi">#{res.vchNo}</div>
              </div>
            </div>
          )}
        </div>
      </form>
      <EntityImagePanel
        entityType="DESIGN"
        entityKey={rows[imageRow]?.designNo ?? ''}
        instance={0}
        label="Design image"
        testId="mfg-order-issue-image"
      />
    </div>
  );
}
