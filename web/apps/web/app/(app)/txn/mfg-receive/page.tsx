'use client';
import { useState } from 'react';
import { post, put, get, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { VoucherList } from '../../../../components/VoucherList';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { fineFor } from '@datacare/core';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  extendedGridColumnCount,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';
import SubDetailGrid, {
  SUB_DETAIL_COMPONENT,
  useSubDetail,
} from '../../../../components/SubDetailGrid';

// MFG RECEIVE — metal IN from a process stage with ghat/loss reconciliation. Posts to the REAL
// /mfg/receive backend (receiveMfg) — NOT the karigar pipeline. Per line the accountable received
// weight is RecWt = netWt + ghtWt(=ITM_GHAT) + lossWt(=ITM_LOSS) (+ chol/ghis, not entered here).
interface Line {
  totalGrossWt: string;
  totalLessWt: string;
  karigarJobworkWt: string;
  karigarMinorityWt: string;
  karigarMinorityAmount: string;
  oldGrossWt: string;
  oldFine: string;
  oldLabourAmount: string;
  oldOther: string;
  addOtherWt: string;
  lessOtherWt: string;
  rtnChol: string;
  rtnGhis: string;
  itmGhat: string;
  mtrlWt: string;
  mtrlItCode: string;
  fittingItCode: string;
  isuItCode: string;
  dmPcs: string;
  dmWt: string;
  designSrNo: string;
  adjustDate: string;
  repYrcd: string;
  repDbcd: string;
  repNo: string;
  repSrno: string;
  repAcCode: string;
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  ghtWt: string;
  lossWt: string;
  totalNetWt: string;
  oldNetWt: string;
  rateType: string;
  prCode: string;
  itemRemark: string;
  lotNo: string;
  tagNo: string;
  designNo: string;
  size: string;
  othWt: string;
  ghtPct: string;
  westPct: string;
  fineWt: string;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  itRate: string;
  itAmt: string;
  netAmt: string;
  krName: string;
  ordNo: string;
  ordYrcd: string;
  ordDbcd: string;
  ordAcCode: string;
  ordDesign: string;
  ordSrno: string;
}
/**
 * P7 extended grid columns: desktop columns this form has and the web did not.
 *
 * Every entry was verified against the WRITER, not the API interface — a field present on the
 * interface is not necessarily persisted (purchase hard-codes ITM_SIZE to blank, and five
 * SaleLineInput fields have no SL_DETL column at all), and such a cell would silently discard
 * what the operator types.
 */
const extendedLineFields: Array<[keyof Line, string]> = [
  ['totalNetWt', 'TotNwt'],
  ['oldNetWt', 'OldNwt'],
  ['rateType', 'RateType'],
  ['prCode', 'PrCost'],
  ['itemRemark', 'Remark'],
  ['lotNo', 'LotNo'],
  ['tagNo', 'TagNo'],
  ['designNo', 'Design'],
  ['size', 'Size'],
  ['othWt', 'OthWt'],
  ['ghtPct', 'Ght%'],
  ['westPct', 'West%'],
  ['fineWt', 'Fine'],
  ['lbrType', 'LType'],
  ['lbrRate', 'LbrRate'],
  ['lbrAmt', 'LbrAmt'],
  ['othAmt', 'OthAmt'],
  ['itRate', 'ItRate'],
  ['itAmt', 'ItAmt'],
  ['netAmt', 'NetAmt'],
  ['krName', 'KrName'],
  ['ordNo', 'OrdNo'],
  ['ordYrcd', 'OrdYr'],
  ['ordDbcd', 'OrdBk'],
  ['ordAcCode', 'OrdAc'],
  ['ordDesign', 'OrdDesign'],
  ['ordSrno', 'OrdSr'],
];

/** Fields the API takes as numbers; everything else stays a string so codes are not mangled. */
const NUMERIC_EXTENDED = new Set<string>([
  'totalNetWt',
  'oldNetWt',
  'othWt',
  'ghtPct',
  'westPct',
  'fineWt',
  'lbrRate',
  'lbrAmt',
  'othAmt',
  'itRate',
  'itAmt',
  'netAmt',
  'ordSrno',
]);

const blank = (): Line => ({
  totalGrossWt: '',
  totalLessWt: '',
  karigarJobworkWt: '',
  karigarMinorityWt: '',
  karigarMinorityAmount: '',
  oldGrossWt: '',
  oldFine: '',
  oldLabourAmount: '',
  oldOther: '',
  addOtherWt: '',
  lessOtherWt: '',
  rtnChol: '',
  rtnGhis: '',
  itmGhat: '',
  mtrlWt: '',
  mtrlItCode: '',
  fittingItCode: '',
  isuItCode: '',
  dmPcs: '',
  dmWt: '',
  designSrNo: '',
  adjustDate: '',
  repYrcd: '',
  repDbcd: '',
  repNo: '',
  repSrno: '',
  repAcCode: '',
  itCode: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  ghtWt: '',
  lossWt: '',
  totalNetWt: '',
  oldNetWt: '',
  rateType: '',
  prCode: '',
  itemRemark: '',
  lotNo: '',
  tagNo: '',
  designNo: '',
  size: '',
  othWt: '',
  ghtPct: '',
  westPct: '',
  fineWt: '',
  lbrType: '',
  lbrRate: '',
  lbrAmt: '',
  othAmt: '',
  itRate: '',
  itAmt: '',
  netAmt: '',
  krName: '',
  ordNo: '',
  ordYrcd: '',
  ordDbcd: '',
  ordAcCode: '',
  ordDesign: '',
  ordSrno: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

/**
 * MfgLine fields the server accepted that no screen could send (parity plan P3-1).
 *
 * The desktop keeps these as grid columns the operator tabs across:
 * reconciliation (TotGwt/TotLwt and the issue-side comparison), the karigar job-work side
 * (KrJdtWt/KrMinoWt/KrMinoAmt), old-metal (OldGwt/OldFine/OldLbrAmt/OldOth), process losses
 * (RtnChol filings, RtnGhis polishing dust, ItmGhat), auxiliary material (MtrlWt/MtrlItCode,
 * FtngItCode), the stone roll-up (DmPcs/DmWt) and order/repair provenance.
 *
 * Chole and Ghis are not decoration: TR_MFG_ORD_REC.cs:4726 computes the accountable
 * difference as `IsNwt - (NetWt + GhtWt + Chole + Ghis + MtrlWt)`, so without them the screen
 * cannot state what the karigar owes.
 */
const extendedMfgFields: Array<[keyof Line, string]> = [
  ['totalGrossWt', 'TotGwt'],
  ['totalLessWt', 'TotLwt'],
  ['karigarJobworkWt', 'KrJdtWt'],
  ['karigarMinorityWt', 'KrMinoWt'],
  ['karigarMinorityAmount', 'KrMinoAmt'],
  ['oldGrossWt', 'OldGwt'],
  ['oldFine', 'OldFine'],
  ['oldLabourAmount', 'OldLbrAmt'],
  ['oldOther', 'OldOth'],
  ['addOtherWt', 'AddOthWt'],
  ['lessOtherWt', 'LessOthWt'],
  ['rtnChol', 'RtnChol'],
  ['rtnGhis', 'RtnGhis'],
  ['itmGhat', 'ItmGhat'],
  ['mtrlWt', 'MtrlWt'],
  ['mtrlItCode', 'MtrlItCode'],
  ['fittingItCode', 'FtngItCode'],
  ['isuItCode', 'IsuItCode'],
  ['dmPcs', 'DmPcs'],
  ['dmWt', 'DmWt'],
  ['designSrNo', 'DesignSrNo'],
  ['adjustDate', 'AdjDate'],
  ['repYrcd', 'RepYrCd'],
  ['repDbcd', 'RepDbCd'],
  ['repNo', 'RepNo'],
  ['repSrno', 'RepSrNo'],
  ['repAcCode', 'RepAcCode'],
];

export default function MfgReceivePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState(''); // RECEIPT_BOOK (issue uses 'MIS')
  const [karigarAc, setKarigarAc] = useState('');
  const [karigarName, setKarigarName] = useState('');
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [labourAmt, setLabourAmt] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop TR_MFG_ORD_REC hangs a sub-detail row set under each item line; the server
  // already persists it and this page sent nothing.
  const sub = useSubDetail(lines.length);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: extendedGridColumnCount(fullGrid, 7, extendedMfgFields.length),
    onAppendRow: () => {
      setLines((rows) => [...rows, blank()]);
      sub.appendLine();
    },
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      sub.removeLine(row);
      return true;
    },
    onEscape: () => {},
  });
  // The desktop's image buttons act on the current grid row.
  const [imageRow, setImageRow] = useState(0);
  const [result, setResult] = useState<{
    vchNo: number;
    fineReceived: number;
    recWt: number;
    netWt: number;
  } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const [loadedVch, setLoadedVch] = useState('');

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live preview: fine = net × touch / 100; recWt = net + ghat + loss (RTN_CHOL/RTN_GHIS not entered here)
  const fineOf = (l: Line) =>
    fineFor('mfg', { netWt: n(l.netWt), touch: n(l.touch), ghtWt: n(l.ghtWt) });
  const recOf = (l: Line) => r3(n(l.netWt) + n(l.ghtWt) + n(l.lossWt));
  const netTotal = r3(lines.reduce((s, l) => s + n(l.netWt), 0));
  const fineTotal = r3(lines.reduce((s, l) => s + fineOf(l), 0));
  const recTotal = r3(lines.reduce((s, l) => s + recOf(l), 0));

  function resetForm() {
    setLoadedVch('');
    setKarigarAc('');
    setKarigarName('');
    setPartyAc('');
    setPartyName('');
    setLabourAmt('');
    setLines([blank()]);
    sub.reset();
    setResult(null);
    setErr('');
  }

  // Reopen a saved MFG receive (GET /mfg/receive/:vchNo?coBook) for edit; the getMfg reader field
  // names match the form Line exactly, so each line is copied field-for-field (number->string); the
  // component sub-detail is replaced via sub.load(perLine).
  async function loadVoucher(vchNo: string) {
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const d = await get<any>(
        `/mfg/receive/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(coBook)}`,
      );
      setLoadedVch(String(d.voucherNo ?? vchNo));
      setKarigarAc(String(d.karigarAc ?? ''));
      setPartyAc(String(d.partyAc ?? ''));
      if (d.labourAmt != null) setLabourAmt(d.labourAmt ? String(d.labourAmt) : '');
      const str = (v: unknown) => (v == null || v === 0 || v === '' ? '' : String(v));
      const src: any[] = Array.isArray(d.lines) && d.lines.length ? d.lines : [];
      const template = blank();
      setLines(
        src.length
          ? src.map((l) => {
              const row: any = { ...template };
              for (const k of Object.keys(template)) row[k] = str(l[k]);
              if (!row.pcs) row.pcs = '1';
              return row as Line;
            })
          : [blank()],
      );
      const cstr = (v: unknown) => (v == null || v === 0 ? undefined : String(v));
      sub.load(
        (src.length ? src : [{}]).map((l) =>
          (Array.isArray(l.components) ? l.components : []).map((c: any) => {
            const r: Record<string, string> = {};
            for (const [k, v] of Object.entries(c)) {
              if (k === 'isrNo') continue;
              const sv = typeof v === 'number' ? cstr(v) : v ? String(v) : undefined;
              if (sv != null) r[k] = sv;
            }
            return r;
          }),
        ),
      );
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        lcCode,
        karigarAc: karigarAc || undefined,
        partyAc: partyAc || undefined,
        labourAmt: labourAmt ? n(labourAmt) : undefined,
        lines: lines

          // Original index carried through the filter: empty lines are dropped, so a

          // filtered position would attach a sub-detail block to a different item.

          .map((l, sourceIndex) => ({ l, sourceIndex }))

          .filter(({ l }) => l.itCode && l.netWt)

          .map(({ l, sourceIndex }) => ({
            // P7: writer-verified extended columns. A blank cell is OMITTED, never sent as 0 — an
            // explicit zero is an override at the writer and defeats the server's own derivation.
            ...Object.fromEntries(
              extendedLineFields
                .map(([key]) => [
                  key,
                  String((l as unknown as Record<string, unknown>)[key] ?? '').trim(),
                ])
                .filter(([, v]) => v !== '')
                .map(([key, v]) => [key, NUMERIC_EXTENDED.has(key as string) ? Number(v) : v]),
            ),
            components: sub.componentsFor(sourceIndex),
            totalGrossWt: n(l.totalGrossWt),
            totalLessWt: n(l.totalLessWt),
            karigarJobworkWt: n(l.karigarJobworkWt),
            karigarMinorityWt: n(l.karigarMinorityWt),
            karigarMinorityAmount: n(l.karigarMinorityAmount),
            oldGrossWt: n(l.oldGrossWt),
            oldFine: n(l.oldFine),
            oldLabourAmount: n(l.oldLabourAmount),
            oldOther: n(l.oldOther),
            addOtherWt: n(l.addOtherWt),
            lessOtherWt: n(l.lessOtherWt),
            rtnChol: n(l.rtnChol),
            rtnGhis: n(l.rtnGhis),
            itmGhat: n(l.itmGhat),
            mtrlWt: n(l.mtrlWt),
            mtrlItCode: l.mtrlItCode || undefined,
            fittingItCode: l.fittingItCode || undefined,
            isuItCode: l.isuItCode || undefined,
            dmPcs: n(l.dmPcs),
            dmWt: n(l.dmWt),
            designSrNo: n(l.designSrNo),
            adjustDate: l.adjustDate || undefined,
            repYrcd: l.repYrcd || undefined,
            repDbcd: l.repDbcd || undefined,
            repNo: l.repNo || undefined,
            repSrno: n(l.repSrno),
            repAcCode: l.repAcCode || undefined,
            itCode: l.itCode,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
            ghtWt: n(l.ghtWt),
            itmLoss: n(l.lossWt), // lossWt column → MfgLine.itmLoss
          })),
      };
      setResult(
        loadedVch
          ? await put(`/mfg/receive/${encodeURIComponent(loadedVch)}`, body)
          : await post('/mfg/receive', body),
      );
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
      <h1>Manufacturing Receive — metal IN</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="MRC" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Location</label>
              <input value={lcCode} readOnly />
            </div>
            <div className="field">
              <label>Karigar (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={karigarAc}
                onChange={setKarigarAc}
                onPick={(r) => setKarigarName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Karigar Name</label>
              <input value={karigarName} onChange={(e) => setKarigarName(e.target.value)} />
            </div>
            <div className="field">
              <label>Party (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={partyAc}
                onChange={setPartyAc}
                onPick={(r) => setPartyName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Party Name</label>
              <input value={partyName} onChange={(e) => setPartyName(e.target.value)} />
            </div>
            <div className="field">
              <label>Labour Amount ₹</label>
              <input value={labourAmt} onChange={(e) => setLabourAmt(e.target.value)} />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Metal Lines</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedMfgFields.length}
            testId="mfg-receive-grid-mode"
          />
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="mfg-receive-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Ght Wt</th>
                <th className="num">Loss Wt</th>
                <th className="num">Fine</th>
                <th className="num">RecWt</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedMfgFields} />
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
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
                      style={{ width: 110 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 44, textAlign: 'right' }}
                      value={l.pcs}
                      onChange={(e) => setLine(i, 'pcs', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.grossWt}
                      onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 64, textAlign: 'right' }}
                      value={l.netWt}
                      onChange={(e) => setLine(i, 'netWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.touch}
                      onChange={(e) => setLine(i, 'touch', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.ghtWt}
                      onChange={(e) => setLine(i, 'ghtWt', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 56, textAlign: 'right' }}
                      value={l.lossWt}
                      onChange={(e) => setLine(i, 'lossWt', e.target.value)}
                    />
                  </td>
                  <td className="num">{fineOf(l).toLocaleString('en-IN')}</td>
                  <td className="num">{recOf(l).toLocaleString('en-IN')}</td>
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedLineFields}
                    line={l}
                    row={i}
                    baseColumns={12}
                    setValue={(row, key, value) => setLine(row, key, value)}
                  />
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
              ))}
            </tbody>
          </table>
          <div className="row" style={{ marginTop: 8, alignItems: 'flex-end' }}>
            <div className="field">
              <label>Components for line</label>
              <select
                value={sub.activeLine}
                onChange={(e) => sub.setActiveLine(Number(e.target.value))}
              >
                {lines.map((l, i) => (
                  <option key={i} value={i}>
                    {i + 1}
                    {l.itCode ? ` — ${l.itCode}` : ''}
                  </option>
                ))}
              </select>
            </div>
            <div className="field">
              <span className="muted">{sub.totalRows} row(s) on this voucher</span>
            </div>
          </div>
          <SubDetailGrid
            rows={sub.rowsFor(sub.activeLine)}
            onRowsChange={(r) => sub.setRowsFor(sub.activeLine, r)}
            columns={SUB_DETAIL_COMPONENT}
            parentLabel={`line ${sub.activeLine + 1}`}
            desktopSource="TR_MFG_ORD_REC / MSG_IDTL (28 cols)"
          />
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
              Net {netTotal.toLocaleString('en-IN')} g · Fine {fineTotal.toLocaleString('en-IN')} ·{' '}
              <b>RecWt {recTotal.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : loadedVch ? `Update #${loadedVch}` : 'Save Receive'}
            </button>
            {loadedVch && (
              <button type="button" className="ghost" onClick={resetForm} disabled={busy}>
                New
              </button>
            )}
          </div>
        </div>
      </form>

      <VoucherList
        table="MFG_DATA"
        book={coBook}
        deleteBase="/mfg/receive"
        onLoad={(vchNo) => loadVoucher(vchNo)}
      />

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Saved — Voucher #{result.vchNo}</div>
          <div className="tiles">
            <div className="tile">
              <div className="muted">vchNo</div>
              <div className="big kpi">{result.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">fineReceived</div>
              <div className="big kpi">{Number(result.fineReceived).toLocaleString('en-IN')}</div>
            </div>
            <div className="tile">
              <div className="muted">recWt</div>
              <div className="big kpi">{Number(result.recWt).toLocaleString('en-IN')}</div>
            </div>
          </div>
        </div>
      )}
      <EntityImagePanel
        entityType="ITEM"
        entityKey={lines[imageRow]?.itCode ?? ''}
        instance={0}
        label="Item image"
        testId="mfg-receive-image"
      />
    </div>
  );
}
