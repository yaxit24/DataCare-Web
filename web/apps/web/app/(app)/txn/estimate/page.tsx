'use client';
import { useState } from 'react';
import { post, downloadPdf, ApiError } from '../../../../lib/api';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { useRoundingPolicy } from '../../../../components/BusinessScope';
import { fineFor, labourCharge, billTotals, lineNet as lineNetAmount } from '@datacare/core';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

interface Line {
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  tagNo: string;
  ordNo: string;
  ordYrcd: string;
  ordDbcd: string;
  ordSrno: string;
  isuNo: string;
  isuYrcd: string;
  isuDbcd: string;
  isuSrno: string;
  ghtWt: string;
  westPct: string;
  fineWt: string;
  metalAmount: string;
  labourPct: string;
  labourFixed: string;
  otherAmount: string;
  huid: string;
  designNo: string;
  itmSize: string;
  lessWt: string;
  tblCode: string;
  mrp: string;
  bagWt: string;
  tagGrossWt: string;
  tagNetWt: string;
  ghtPct: string;
  itemLot: string;
  remark: string;
  discountPct: string;
  ghatAmount: string;
  rateWith: string;
  rateType: string;
  tagCost: string;
  karigarNetWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  karigarName: string;
  employeeCode: string;
  prCode: string;
  designImageId: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
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
  ['tagNo', 'TagNo'],
  ['ordNo', 'OrdNo'],
  ['ordYrcd', 'OrdYr'],
  ['ordDbcd', 'OrdBk'],
  ['ordSrno', 'OrdSr'],
  ['isuNo', 'IsuNo'],
  ['isuYrcd', 'IsuYr'],
  ['isuDbcd', 'IsuBk'],
  ['isuSrno', 'IsuSr'],
  ['ghtWt', 'GhtWt'],
  ['westPct', 'West%'],
  ['fineWt', 'Fine'],
  ['metalAmount', 'ItAmt'],
  ['labourPct', 'Lbr%'],
  ['labourFixed', 'LbrFix'],
  ['otherAmount', 'OthAmt'],
  ['huid', 'HuId'],
  ['designNo', 'Design'],
  ['itmSize', 'Size'],
  ['lessWt', 'LsWt'],
  ['tblCode', 'Counter'],
  ['mrp', 'Mrp'],
  ['bagWt', 'BagWt'],
  ['tagGrossWt', 'TagGwt'],
  ['tagNetWt', 'TagNwt'],
  ['ghtPct', 'Ght%'],
  ['itemLot', 'ItmLot'],
  ['remark', 'Remark'],
  ['discountPct', 'LDisc%'],
  ['ghatAmount', 'GhtAmt'],
  ['rateWith', 'RtWith'],
  ['rateType', 'RateType'],
  ['tagCost', 'TagCost'],
  ['karigarNetWt', 'KrNwt'],
  ['karigarTouch', 'KrTouch'],
  ['karigarWestPct', 'KrWst%'],
  ['karigarFine', 'KrFine'],
  ['karigarName', 'KrCode'],
  ['employeeCode', 'EmpCod'],
  ['prCode', 'PrCost'],
  ['designImageId', 'Image'],
  ['hallmarkId2', 'HmId2'],
  ['hallmarkId3', 'HmId3'],
  ['hallmarkId4', 'HmId4'],
  ['hallmarkIdWt', 'HmIdWt'],
  ['hallmarkId2Wt', 'HmId2Wt'],
  ['hallmarkId3Wt', 'HmId3Wt'],
  ['hallmarkId4Wt', 'HmId4Wt'],
];

/** Fields the API takes as numbers; everything else stays a string so codes are not mangled. */
const NUMERIC_EXTENDED = new Set<string>([
  'ordSrno',
  'isuSrno',
  'ghtWt',
  'westPct',
  'fineWt',
  'metalAmount',
  'labourPct',
  'otherAmount',
  'lessWt',
  'bagWt',
  'tagGrossWt',
  'tagNetWt',
  'ghtPct',
  'discountPct',
  'ghatAmount',
  'tagCost',
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
]);

const blank = (): Line => ({
  itCode: '', // desktop grids start empty; a demo default posts to the wrong item
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  tagNo: '',
  ordNo: '',
  ordYrcd: '',
  ordDbcd: '',
  ordSrno: '',
  isuNo: '',
  isuYrcd: '',
  isuDbcd: '',
  isuSrno: '',
  ghtWt: '',
  westPct: '',
  fineWt: '',
  metalAmount: '',
  labourPct: '',
  labourFixed: '',
  otherAmount: '',
  huid: '',
  designNo: '',
  itmSize: '',
  lessWt: '',
  tblCode: '',
  mrp: '',
  bagWt: '',
  tagGrossWt: '',
  tagNetWt: '',
  ghtPct: '',
  itemLot: '',
  remark: '',
  discountPct: '',
  ghatAmount: '',
  rateWith: '',
  rateType: '',
  tagCost: '',
  karigarNetWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  karigarName: '',
  employeeCode: '',
  prCode: '',
  designImageId: '',
  hallmarkId2: '',
  hallmarkId3: '',
  hallmarkId4: '',
  hallmarkIdWt: '',
  hallmarkId2Wt: '',
  hallmarkId3Wt: '',
  hallmarkId4Wt: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function EstimatePage() {
  // G11: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N' (blank default Y).
  const companySettings = useCompanySettings();
  const roundingPolicy = useRoundingPolicy();
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
  // G09: the letterhead is the active company's own CO_NAME; the server reads it when it builds the PDF.
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [lines, setLines] = useState<Line[]>([blank()]);
  const [fullGrid, setFullGrid] = useState(false);
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
  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line preview (matches sales/computeLine): fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
  const calc = (l: Line) => {
    const fine = fineFor('sale', { netWt: n(l.netWt), touch: n(l.touch) });
    const metal = r2(fine * n(l.rate));
    // P5/P7: this grid now carries ghat, so per-gram labour is (net + ghat) x rate unless the company
    // switches ghat off (LBR_WITH_GHT, desktop blank default 'Y').
    const mk = labourCharge('per_gram', {
      netWt: n(l.netWt),
      ghatWt: n(l.ghtWt),
      withGhat: labourWithGhat,
      rate: n(l.making),
    });
    const other = n(l.otherAmount);
    return { fine, metal, mk, net: lineNetAmount({ metal, labour: mk, other }) };
  };
  const lineNet = lines.reduce((s, l) => s + calc(l).net, 0);
  const previewTotals = billTotals(
    {
      lineNetTotal: lineNet,
      discountAmount: n(discountAmount),
      taxRatePct: n(taxRatePct),
      interState,
    },
    roundingPolicy,
  );
  const taxable = previewTotals.taxable;
  const taxPrev = previewTotals.tax;
  const totalPrev = previewTotals.total;

  /** The typed estimate request: the compute preview and the PDF use the same one. */
  function estimateRequest() {
    return {
      acCode: acCode || undefined,
      acName: acName || undefined,
      taxRatePct: Number(taxRatePct),
      interState,
      discountAmount: discountAmount ? Number(discountAmount) : undefined,
      lines: lines
        .filter((l) => l.itCode && (l.netWt || l.rate))
        .map((l) => ({
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
          itCode: l.itCode,
          pcs: n(l.pcs),
          grossWt: n(l.grossWt),
          netWt: n(l.netWt),
          touch: n(l.touch),
          rate: n(l.rate),
          ...(l.making ? { labourType: 'per_gram', labourRate: n(l.making) } : {}),
        })),
    };
  }

  async function compute(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setRes(null);
    setBusy(true);
    try {
      // compute-only preview — POST /estimate saves no voucher and writes no ledger
      setRes(await post('/estimate', estimateRequest()));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || 'failed' : 'failed');
    } finally {
      setBusy(false);
    }
  }

  function pdf() {
    if (!res) return;
    // N54: the server builds the PDF from the same typed request; the browser sends no HTML.
    void downloadPdf('/estimate/pdf', 'estimate', {
      method: 'POST',
      body: estimateRequest(),
    }).catch((e) => setErr(e instanceof ApiError ? e.body?.error || 'pdf failed' : 'pdf failed'));
  }

  return (
    <div>
      <h1>Estimate / Quotation</h1>
      <form onSubmit={compute}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Party (AC_CODE)</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={setAcCode}
                onPick={(r) => {
                  setAcName(String(r.name || ''));
                  if (r.AC_GST_TYPE) setInterState(String(r.AC_GST_TYPE) !== 'L');
                }}
              />
            </div>
            <div className="field">
              <label>Customer Name</label>
              <input value={acName} onChange={(e) => setAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Tax %</label>
              <input value={taxRatePct} onChange={(e) => setTaxRatePct(e.target.value)} />
            </div>
            <div className="field">
              <label>Discount ₹</label>
              <input value={discountAmount} onChange={(e) => setDiscountAmount(e.target.value)} />
            </div>
            <div className="field">
              <label>Inter-state</label>
              <select
                value={interState ? 'y' : 'n'}
                onChange={(e) => setInterState(e.target.value === 'y')}
              >
                <option value="n">No (CGST+SGST)</option>
                <option value="y">Yes (IGST)</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Items</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="estimate-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch%</th>
                <th className="num">Rate</th>
                <th className="num">Making/g</th>
                <th className="num">Fine</th>
                <th className="num">Amount</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => {
                const c = calc(l);
                return (
                  <tr key={i}>
                    <td>
                      <LookupPicker
                        entity="items"
                        value={l.itCode}
                        onChange={(v) => setLine(i, 'itCode', v)}
                        style={{ width: 80 }}
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
                        style={{ width: 72, textAlign: 'right' }}
                        value={l.rate}
                        onChange={(e) => setLine(i, 'rate', e.target.value)}
                      />
                    </td>
                    <td className="num">
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.making}
                        onChange={(e) => setLine(i, 'making', e.target.value)}
                      />
                    </td>
                    <td className="num">{c.fine.toLocaleString('en-IN')}</td>
                    <td className="num">{c.net.toLocaleString('en-IN')}</td>
                    <ExtendedBodyCells
                      full={fullGrid}
                      fields={extendedLineFields}
                      line={l}
                      row={i}
                      baseColumns={10}
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
                );
              })}
            </tbody>
          </table>
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
              Taxable ₹{taxable.toLocaleString('en-IN')} · Tax ₹{taxPrev.toLocaleString('en-IN')} ·{' '}
              <b>Total ₹{totalPrev.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Computing…' : 'Compute Estimate'}
            </button>
          </div>
        </div>
      </form>
      {err && <div className="msg err">{err}</div>}
      {res && (
        <div className="panel">
          <div className="toolbar">
            <h2 style={{ margin: 0 }}>Estimate</h2>
            <button className="ghost" onClick={pdf}>
              Download PDF
            </button>
          </div>
          <div className="tiles">
            {Object.entries(res.totals).map(([k, v]) => (
              <div className="tile" key={k}>
                <div className="muted">{k}</div>
                <div className="big kpi">{Number(v).toLocaleString('en-IN')}</div>
              </div>
            ))}
          </div>
        </div>
      )}
    </div>
  );
}
