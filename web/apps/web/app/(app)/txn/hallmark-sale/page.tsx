'use client';
import { useState } from 'react';
import { post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { fineFor, labourCharge } from '@datacare/core';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

interface Line {
  itCode: string;
  tagNo: string;
  huid: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  lessWt: string;
  ghtPct: string;
  ghtWt: string;
  westPct: string;
  fineWt: string;
  rateWith: string;
  rateType: string;
  metalAmount: string;
  labourType: string;
  labourPct: string;
  labourFixed: string;
  otherAmount: string;
  discountPct: string;
  ghatAmount: string;
  mrp: string;
  designNo: string;
  itmSize: string;
  style: string;
  itemLot: string;
  bagWt: string;
  remark: string;
  tblCode: string;
  tagGrossWt: string;
  tagNetWt: string;
  tagCost: string;
  karigarName: string;
  karigarNetWt: string;
  karigarTouch: string;
  karigarWestPct: string;
  karigarFine: string;
  employeeCode: string;
  prCode: string;
  ordNo: string;
  ordYrcd: string;
  ordDbcd: string;
  ordSrno: string;
  isuNo: string;
  isuYrcd: string;
  isuDbcd: string;
  isuSrno: string;
  designImageId: string;
  orderTagStockAdd: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
}
interface Totals {
  net: number;
  discount: number;
  taxable: number;
  tax: number;
  cgst: number;
  sgst: number;
  igst: number;
  roundOff: number;
  total: number;
}
/**
 * P7: fields deliberately NOT exposed on this grid, having been checked against the writer.
 *
 * Five have NO COLUMN IN SL_DETL at all despite the interface carrying a column comment
 * (ITM_MARGIN, TAG_LBR_PRC, TAG_LBR_RATE, TAG_LBR_AMT, TAG_OTH_AMT) — verified against
 * information_schema. Four more are declared on the contract but never read by the writer
 * (otherWt, itType, tagType, dataTransfer). Three are internal serials the server assigns
 * (tagSrNo, oldSrNo, vchSrno). `margin` is additionally server-derived on purpose: sales.ts:1866
 * notes a client-supplied cost would let the margin be manipulated.
 *
 * Exposing any of them would give the operator a cell that silently discards what they type, which is
 * worse than not showing the column — and it would inflate the depth metric with dead surface.
 * fineWt, metalAmount and labourFixed ARE exposed, because the writer honours each as an override.
 */
const NUMERIC_EXTENDED = new Set<string>([
  'lessWt',
  'ghtPct',
  'ghtWt',
  'westPct',
  'fineWt',
  'metalAmount',
  'labourPct',
  'labourFixed',
  'otherAmount',
  'discountPct',
  'ghatAmount',
  'mrp',
  'bagWt',
  'tagGrossWt',
  'tagNetWt',
  'tagCost',
  'karigarNetWt',
  'karigarTouch',
  'karigarWestPct',
  'karigarFine',
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
  'ordSrno',
  'isuSrno',
]);

const extendedLineFields: Array<[keyof Line, string]> = [
  ['lessWt', 'Ls Wt'],
  ['ghtPct', 'Ght%'],
  ['ghtWt', 'GhtWt'],
  ['westPct', 'West%'],
  ['fineWt', 'Fine'],
  ['rateWith', 'RtWith'],
  ['rateType', 'RateType'],
  ['metalAmount', 'ItAmt'],
  ['labourType', 'LType'],
  ['labourPct', 'Lbr%'],
  ['labourFixed', 'LbrFix'],
  ['otherAmount', 'OthAmt'],
  ['discountPct', 'LDisc%'],
  ['ghatAmount', 'GhtAmt'],
  ['mrp', 'Mrp'],
  ['designNo', 'Design'],
  ['itmSize', 'Size'],
  ['style', 'Style'],
  ['itemLot', 'ItmLot'],
  ['bagWt', 'BagWt'],
  ['remark', 'Remark'],
  ['tblCode', 'TblCode'],
  ['tagGrossWt', 'TagGwt'],
  ['tagNetWt', 'TagNwt'],
  ['tagCost', 'TagCost'],
  ['karigarName', 'KrCode'],
  ['karigarNetWt', 'KrNwt'],
  ['karigarTouch', 'KrTouch'],
  ['karigarWestPct', 'KrWst%'],
  ['karigarFine', 'KrFine'],
  ['employeeCode', 'EmpCod'],
  ['prCode', 'PrCost'],
  ['ordNo', 'OrdNo'],
  ['ordYrcd', 'OrdYr'],
  ['ordDbcd', 'OrdBk'],
  ['ordSrno', 'OrdSr'],
  ['isuNo', 'IsuNo'],
  ['isuYrcd', 'IsuYr'],
  ['isuDbcd', 'IsuBk'],
  ['isuSrno', 'IsuSr'],
  ['designImageId', 'Image'],
  ['orderTagStockAdd', 'OrdStk'],
  ['hallmarkId2', 'HmId2'],
  ['hallmarkId3', 'HmId3'],
  ['hallmarkId4', 'HmId4'],
  ['hallmarkIdWt', 'HmIdWt'],
  ['hallmarkId2Wt', 'HmId2Wt'],
  ['hallmarkId3Wt', 'HmId3Wt'],
  ['hallmarkId4Wt', 'HmId4Wt'],
];

const blank = (): Line => ({
  itCode: 'GOLD',
  tagNo: '',
  huid: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  lessWt: '',
  ghtPct: '',
  ghtWt: '',
  westPct: '',
  fineWt: '',
  rateWith: '',
  rateType: '',
  metalAmount: '',
  labourType: '',
  labourPct: '',
  labourFixed: '',
  otherAmount: '',
  discountPct: '',
  ghatAmount: '',
  mrp: '',
  designNo: '',
  itmSize: '',
  style: '',
  itemLot: '',
  bagWt: '',
  remark: '',
  tblCode: '',
  tagGrossWt: '',
  tagNetWt: '',
  tagCost: '',
  karigarName: '',
  karigarNetWt: '',
  karigarTouch: '',
  karigarWestPct: '',
  karigarFine: '',
  employeeCode: '',
  prCode: '',
  ordNo: '',
  ordYrcd: '',
  ordDbcd: '',
  ordSrno: '',
  isuNo: '',
  isuYrcd: '',
  isuDbcd: '',
  isuSrno: '',
  designImageId: '',
  orderTagStockAdd: '',
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

export default function HallmarkSalePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [acCode, setAcCode] = useState('WALKIN');
  const [acName, setAcName] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [hmCharge, setHmCharge] = useState('');
  const [cashAmt, setCashAmt] = useState('');
  const [cardAmt, setCardAmt] = useState('');
  const [upiAmt, setUpiAmt] = useState('');
  const [chequeAmt, setChequeAmt] = useState('');
  const [oldGoldNet, setOldGoldNet] = useState('');
  const [oldGoldTouch, setOldGoldTouch] = useState('');
  const [oldGoldRate, setOldGoldRate] = useState('');
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
  const [result, setResult] = useState<{ vchNo: number; totals: Totals } | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line preview: fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
  const calc = (l: Line) => {
    const fine = fineFor('sale', {
      netWt: n(l.netWt),
      touch: n(l.touch),
      ghtWt: n(l.ghtWt),
      westPct: n(l.westPct),
    });
    const metal = r2(fine * n(l.rate));
    // P5/P7: this page now carries ghat, and per-gram labour is (net + ghat) x rate unless the
    // company switches ghat off (LBR_WITH_GHT, blank default 'Y'). The structural guard in
    // derivedValueSources.test.ts caught this the moment ghtWt was added to the grid.
    const mk = labourCharge('per_gram', {
      netWt: n(l.netWt),
      ghatWt: n(l.ghtWt),
      withGhat: true,
      rate: n(l.making),
    });
    return { fine, metal, mk, net: r2(metal + mk) };
  };
  const lineNet = lines.reduce((s, l) => s + calc(l).net, 0);
  const taxable = r2(lineNet - n(discountAmount));
  const taxPrev = r2((taxable * n(taxRatePct)) / 100);
  const totalPrev = Math.round(taxable + taxPrev);
  const hmAmt = n(hmCharge);
  const hmTax = r2((hmAmt * n(taxRatePct)) / 100);
  const grandTotalPrev = r2(totalPrev + hmAmt + hmTax);
  const oldGoldVal = r2(((n(oldGoldNet) * n(oldGoldTouch)) / 100) * n(oldGoldRate));
  const paid = r2(n(cashAmt) + n(cardAmt) + n(upiAmt) + n(chequeAmt) + oldGoldVal);
  const balanceDue = r2(grandTotalPrev - paid);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const oldGoldAmt = r2(((n(oldGoldNet) * n(oldGoldTouch)) / 100) * n(oldGoldRate));
      const body = {
        coBook,
        coYear,
        lcCode,
        acCode,
        acName: acName || undefined,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        hallmarkAmount: hmCharge ? n(hmCharge) : undefined,
        cashAmt: cashAmt ? n(cashAmt) : undefined,
        cardAmt: cardAmt ? n(cardAmt) : undefined,
        upiAmt: upiAmt ? n(upiAmt) : undefined,
        chequeAmt: chequeAmt ? n(chequeAmt) : undefined,
        oldGold:
          oldGoldAmt > 0
            ? [
                {
                  itCode: 'OG',
                  netWt: n(oldGoldNet),
                  touch: n(oldGoldTouch),
                  rate: n(oldGoldRate),
                  amount: oldGoldAmt,
                },
              ]
            : undefined,
        lines: lines
          .filter((l) => l.itCode && (l.netWt || l.rate))
          .map((l) => ({
            itCode: l.itCode,
            tagNo: l.tagNo || undefined,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
            rate: n(l.rate),
            huid: l.huid || undefined,
            ...(l.making ? { labourType: 'per_gram', labourRate: n(l.making) } : {}),
            // P7: extended columns. A blank cell is OMITTED, never sent as 0 — an explicit zero is
            // an override at the writer and would defeat the server's own derivation.
            ...Object.fromEntries(
              extendedLineFields
                .map(([key]) => [
                  key,
                  String((l as unknown as Record<string, unknown>)[key] ?? '').trim(),
                ])
                .filter(([, v]) => v !== '')
                .map(([key, v]) => [key, NUMERIC_EXTENDED.has(key as string) ? Number(v) : v]),
            ),
          })),
      };
      setResult(await post('/sales', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>
        Hallmark Sale <span className="muted">(HUID)</span>
      </h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="HM" />
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
              <label>Hallmark chg ₹</label>
              <input value={hmCharge} onChange={(e) => setHmCharge(e.target.value)} />
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

        <div className="panel">
          <h2>Settlement</h2>
          <div className="row">
            <div className="field">
              <label>Cash ₹</label>
              <input value={cashAmt} onChange={(e) => setCashAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Card ₹</label>
              <input value={cardAmt} onChange={(e) => setCardAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>UPI ₹</label>
              <input value={upiAmt} onChange={(e) => setUpiAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Cheque ₹</label>
              <input value={chequeAmt} onChange={(e) => setChequeAmt(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Net</label>
              <input value={oldGoldNet} onChange={(e) => setOldGoldNet(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Touch%</label>
              <input value={oldGoldTouch} onChange={(e) => setOldGoldTouch(e.target.value)} />
            </div>
            <div className="field">
              <label>Old Gold Rate</label>
              <input value={oldGoldRate} onChange={(e) => setOldGoldRate(e.target.value)} />
            </div>
          </div>
          <div className="muted" style={{ marginTop: 6 }}>
            Old gold ₹{oldGoldVal.toLocaleString('en-IN')} · Paid ₹{paid.toLocaleString('en-IN')} ·{' '}
            <b style={{ color: balanceDue > 0 ? 'var(--err)' : 'var(--ok)' }}>
              Balance due ₹{balanceDue.toLocaleString('en-IN')}
            </b>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Hallmarked Items</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="hallmark-sale-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>Item</th>
                <th>Tag</th>
                <th>HUID</th>
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
                        style={{ width: 110 }}
                        value={l.huid}
                        onChange={(e) => setLine(i, 'huid', e.target.value)}
                        placeholder="6-char HUID"
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
                      baseColumns={11}
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
              Taxable ₹{taxable.toLocaleString('en-IN')} · Tax ₹{taxPrev.toLocaleString('en-IN')}
              {hmAmt > 0
                ? ` · HM ₹${hmAmt.toLocaleString('en-IN')}+tax ₹${hmTax.toLocaleString('en-IN')}`
                : ''}{' '}
              · <b>Total ₹{grandTotalPrev.toLocaleString('en-IN')}</b>
            </span>
            <button className="primary" disabled={busy}>
              {busy ? 'Saving…' : 'Save Hallmark Sale'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Saved — Voucher #{result.vchNo}</div>
          <div className="toolbar">
            <button
              type="button"
              className="ghost"
              onClick={() =>
                window.open(
                  `/api/sales/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(result.vchNo))}`,
                  '_blank',
                )
              }
            >
              View Invoice PDF
            </button>
          </div>
          <div className="tiles">
            {Object.entries(result.totals).map(([k, v]) => (
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
