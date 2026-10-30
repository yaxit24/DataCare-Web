'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import SubDetailGrid, { useSubDetail } from '../../../../components/SubDetailGrid';
import { fineFor } from '@datacare/core';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

interface Line {
  adjustGrossWt: string;
  adjustNetWt: string;
  metalColor: string;
  isuAcCode: string;
  isuAcName: string;
  isuLcCode: string;
  itCode: string;
  tagNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  lotNo: string;
  itmColor: string;
  tagCost: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
  lessTouch: string;
  lossWt: string;
  fineWt: string;
  remark: string;
  tblCode: string;
  designNo: string;
  itmSize: string;
  huid: string;
  bagWt: string;
  lessWt: string;
  ghtWt: string;
  westPct: string;
  labourPct: string;
  labourType: string;
  labourRate: string;
  labourAmount: string;
  otherAmount: string;
  mrp: string;
  karigarNetWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  karigarName: string;
  prCode: string;
  isuYrcd: string;
  isuDbcd: string;
  designImageId: string;
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
  ['lotNo', 'LotNo'],
  ['itmColor', 'Color'],
  ['tagCost', 'TagCost'],
  ['hallmarkId2', 'HmId2'],
  ['hallmarkId3', 'HmId3'],
  ['hallmarkId4', 'HmId4'],
  ['hallmarkIdWt', 'HmIdWt'],
  ['hallmarkId2Wt', 'HmId2Wt'],
  ['hallmarkId3Wt', 'HmId3Wt'],
  ['hallmarkId4Wt', 'HmId4Wt'],
  ['lessTouch', 'LTouch'],
  ['lossWt', 'LossWt'],
  ['fineWt', 'Fine'],
  ['remark', 'Remark'],
  ['tblCode', 'Counter'],
  ['designNo', 'Design'],
  ['itmSize', 'Size'],
  ['huid', 'HuId'],
  ['bagWt', 'BagWt'],
  ['lessWt', 'LsWt'],
  ['ghtWt', 'GhtWt'],
  ['westPct', 'West%'],
  ['labourPct', 'Lbr%'],
  ['labourType', 'LType'],
  ['labourRate', 'LbrRate'],
  ['labourAmount', 'LbrAmt'],
  ['otherAmount', 'OthAmt'],
  ['mrp', 'Mrp'],
  ['karigarNetWt', 'KrNwt'],
  ['karigarTouch', 'KrTouch'],
  ['karigarWestPct', 'KrWst%'],
  ['karigarFine', 'KrFine'],
  ['karigarName', 'KrCode'],
  ['prCode', 'PrCost'],
  ['isuYrcd', 'IsuYr'],
  ['isuDbcd', 'IsuBk'],
  ['designImageId', 'Image'],
];

/** Fields the API takes as numbers; everything else stays a string so codes are not mangled. */
const NUMERIC_EXTENDED = new Set<string>([
  'tagCost',
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
  'lessTouch',
  'lossWt',
  'fineWt',
  'bagWt',
  'lessWt',
  'ghtWt',
  'westPct',
  'labourPct',
  'labourRate',
  'labourAmount',
  'otherAmount',
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
]);

const blank = (): Line => ({
  adjustGrossWt: '',
  adjustNetWt: '',
  metalColor: '',
  isuAcCode: '',
  isuAcName: '',
  isuLcCode: '',
  itCode: '', // desktop grids start empty; a demo default posts to the wrong item
  tagNo: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  lotNo: '',
  itmColor: '',
  tagCost: '',
  hallmarkId2: '',
  hallmarkId3: '',
  hallmarkId4: '',
  hallmarkIdWt: '',
  hallmarkId2Wt: '',
  hallmarkId3Wt: '',
  hallmarkId4Wt: '',
  lessTouch: '',
  lossWt: '',
  fineWt: '',
  remark: '',
  tblCode: '',
  designNo: '',
  itmSize: '',
  huid: '',
  bagWt: '',
  lessWt: '',
  ghtWt: '',
  westPct: '',
  labourPct: '',
  labourType: '',
  labourRate: '',
  labourAmount: '',
  otherAmount: '',
  mrp: '',
  karigarNetWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  karigarName: '',
  prCode: '',
  isuYrcd: '',
  isuDbcd: '',
  designImageId: '',
});
const n = (v: string) => Number(v || 0);
const r3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;

/**
 * P3: Line fields the server accepted that no screen could send.
 *
 * TR_APR_ISU carries the approval line's adjusted weights and the SOURCE voucher the consignment came from (issue account, its location and name) plus the metal colour; the screen posted six numeric fields and nothing else.
 */
const extendedP3Fields: Array<[keyof Line, string]> = [
  ['adjustGrossWt', 'AdjGwt'],
  ['adjustNetWt', 'AdjNwt'],
  ['metalColor', 'Color'],
  ['isuAcCode', 'IsuAc'],
  ['isuAcName', 'IsuAcName'],
  ['isuLcCode', 'IsuLc'],
];

export default function TourIssuePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [salesmanAc, setSalesmanAc] = useState('');
  const [salesmanName, setSalesmanName] = useState('');
  const [vchDesc, setVchDesc] = useState('');
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop TR_APR_ISU hangs a sub-detail row set under each item line; the server
  // already persists it and this page sent nothing.
  const sub = useSubDetail(lines.length);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
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
  // The desktop's image buttons act on the CURRENT grid row, so the row that last held focus
  // owns the photograph. It persists after blur so clicking the panel does not clear it.
  const [imageRow, setImageRow] = useState(0);
  const [result, setResult] = useState<{ vchNo: number; fine: number } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line fine = net × touch / 100 (goods OUT on approval — no money)
  const fineOf = (l: Line) => fineFor('sale', { netWt: n(l.netWt), touch: n(l.touch) });
  const totalFine = r3(lines.reduce((s, l) => s + fineOf(l), 0));
  const totalNet = r3(lines.reduce((s, l) => s + n(l.netWt), 0));
  const totalPcs = lines.reduce((s, l) => s + n(l.pcs), 0);

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
        salesmanAc,
        salesmanName: salesmanName || undefined,
        vchDesc: vchDesc || undefined,
        lines: lines

          // Original index carried through the filter: empty lines are dropped, so a

          // filtered position would attach a sub-detail block to a different item.

          .map((l, sourceIndex) => ({ l, sourceIndex }))

          .filter(({ l }) => l.itCode && (l.netWt || l.grossWt || l.pcs))

          .map(({ l, sourceIndex }) => ({
            // P7: writer-verified extended columns. A blank cell is OMITTED, never sent as 0 — an
            // explicit zero is an override at the writer and defeats the server's derivation.
            ...Object.fromEntries(
              extendedLineFields
                .map(([key]) => [
                  key,
                  String((l as unknown as Record<string, unknown>)[key] ?? '').trim(),
                ])
                .filter(([, v]) => v !== '')
                .map(([key, v]) => [key, NUMERIC_EXTENDED.has(key as string) ? Number(v) : v]),
            ),
            adjustGrossWt: n(l.adjustGrossWt),
            adjustNetWt: n(l.adjustNetWt),
            metalColor: l.metalColor || undefined,
            isuAcCode: l.isuAcCode || undefined,
            isuAcName: l.isuAcName || undefined,
            isuLcCode: l.isuLcCode || undefined,
            stones: sub.inputsFor(sourceIndex),
            itCode: l.itCode,
            tagNo: l.tagNo || undefined,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
          })),
      };
      setResult(await post('/tour/issue', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Tour / Approval Issue</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="TUR"
                mainBooks={['APPROVAL ISSUE']}
              />
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
              <label>Salesman / Employee</label>
              <LookupPicker
                entity="accounts"
                value={salesmanAc}
                onChange={setSalesmanAc}
                onPick={(r) => setSalesmanName(String(r.name || ''))}
              />
            </div>
            <div className="field">
              <label>Name</label>
              <input value={salesmanName} onChange={(e) => setSalesmanName(e.target.value)} />
            </div>
            <div className="field" style={{ flex: 1 }}>
              <label>Description</label>
              <input value={vchDesc} onChange={(e) => setVchDesc(e.target.value)} />
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Items issued on approval</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedP3Fields.length}
            testId="tour-p3-mode"
          />
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="tour-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Fine</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedP3Fields} />
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
                      style={{ width: 80 }}
                    />
                  </td>
                  <td>
                    <LookupPicker
                      entity="tags"
                      value={l.tagNo}
                      onChange={(v) => setLine(i, 'tagNo', v)}
                      style={{ width: 110 }}
                      onPick={(r) =>
                        setLines((ls) =>
                          ls.map((x, j) =>
                            j === i
                              ? {
                                  ...x,
                                  tagNo: String(r.code),
                                  itCode: String(r.name || x.itCode),
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
              <label>Stones for line</label>
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
            parentLabel={`line ${sub.activeLine + 1}`}
            desktopSource="TR_APR_ISU / MSG_IDTL (21 cols)"
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
              Pcs {totalPcs} · Net {totalNet.toLocaleString('en-IN')} g ·{' '}
              <b>Fine {totalFine.toLocaleString('en-IN')} g</b>
            </span>
            <button className="primary" data-save-mnemonic disabled={busy || !salesmanAc}>
              {busy ? 'Saving…' : 'Issue on Tour'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Issued — Voucher #{result.vchNo}</div>
          <div className="tiles">
            <div className="tile">
              <div className="muted">vchNo</div>
              <div className="big kpi">{result.vchNo}</div>
            </div>
            <div className="tile">
              <div className="muted">fine</div>
              <div className="big kpi">{Number(result.fine).toLocaleString('en-IN')}</div>
            </div>
          </div>
        </div>
      )}
      {/* Desktop BtnImgS / BtnImgC / BtnImgD photograph the tag on the current grid row. */}
      <EntityImagePanel
        entityType="TAG"
        entityKey={lines[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="tour-image"
      />
    </div>
  );
}
