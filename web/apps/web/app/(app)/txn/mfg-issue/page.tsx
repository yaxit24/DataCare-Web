'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
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

// MFG ISSUE — metal OUT to a process stage. Posts to the REAL /mfg/issue backend (issueMfg),
// which writes MFG_DATA/MFG_DETL/MFG_ISU_REC (+ MAIN_STOCK) — NOT the karigar pipeline.
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
}
const blank = (): Line => ({
  itCode: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
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

export default function MfgIssuePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState(''); // ISSUE_BOOK
  const [karigarAc, setKarigarAc] = useState('');
  const [karigarName, setKarigarName] = useState('');
  const [partyAc, setPartyAc] = useState('');
  const [partyName, setPartyName] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop TR_MFG_ISU_REC hangs a sub-detail row set under each item line; the server
  // already persists it and this page sent nothing.
  const sub = useSubDetail(lines.length);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: extendedGridColumnCount(fullGrid, 5, extendedMfgFields.length),
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
  const [result, setResult] = useState<{ vchNo: number; fineIssued: number; netWt: number } | null>(
    null,
  );
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live preview: fine = net × touch / 100 (issue side — no ghat/wastage)
  const fineOf = (l: Line) => fineFor('mfg', { netWt: n(l.netWt), touch: n(l.touch) });
  const netTotal = r3(lines.reduce((s, l) => s + n(l.netWt), 0));
  const fineTotal = r3(lines.reduce((s, l) => s + fineOf(l), 0));

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
        lines: lines

          // Original index carried through the filter: empty lines are dropped, so a

          // filtered position would attach a sub-detail block to a different item.

          .map((l, sourceIndex) => ({ l, sourceIndex }))

          .filter(({ l }) => l.itCode && l.netWt)

          .map(({ l, sourceIndex }) => ({
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
          })),
      };
      setResult(await post('/mfg/issue', body));
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
      <h1>Manufacturing Issue — metal OUT</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="MIS" />
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
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Metal Lines</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedMfgFields.length}
            testId="mfg-issue-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Fine</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedMfgFields} />
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
                  <td className="num">{fineOf(l).toLocaleString('en-IN')}</td>
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
            desktopSource="TR_MFG_ISU_REC / MSG_IDTL (22 cols)"
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
              Net {netTotal.toLocaleString('en-IN')} g ·{' '}
              <b>Fine {fineTotal.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Save Issue'}
            </button>
          </div>
        </div>
      </form>

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
              <div className="muted">fineIssued</div>
              <div className="big kpi">{Number(result.fineIssued).toLocaleString('en-IN')}</div>
            </div>
          </div>
        </div>
      )}
      <EntityImagePanel
        entityType="ITEM"
        entityKey={lines[imageRow]?.itCode ?? ''}
        instance={0}
        label="Item image"
        testId="mfg-issue-image"
      />
    </div>
  );
}
