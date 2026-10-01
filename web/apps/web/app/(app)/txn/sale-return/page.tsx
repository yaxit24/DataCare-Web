'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { VoucherList } from '../../../../components/VoucherList';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { SaleReturnSavedPanel } from '../../../../components/SaleReturnSavedPanel';
import { fineFor, labourCharge } from '@datacare/core';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

interface Line {
  itCode: string;
  tagNo: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
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
  tblCode: string;
  mrp: string;
  ghtPct: string;
  itemLot: string;
  remark: string;
  discountPct: string;
  rateWith: string;
  rateType: string;
  tagCost: string;
  tagLabourPct: string;
  tagLabourRate: string;
  tagLabourAmount: string;
  tagOtherAmount: string;
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
const extendedLineFields: Array<[keyof Line, string]> = [
  ['ghtWt', 'GhtWt'],
  ['westPct', 'West%'],
  ['fineWt', 'Fine'],
  ['metalAmount', 'ItAmt'],
  ['labourPct', 'Lbr%'],
  ['labourFixed', 'LbrFix'],
  ['otherAmount', 'OthAmt'],
  ['huid', 'HmId'],
  ['designNo', 'Design'],
  ['itmSize', 'Size'],
  ['tblCode', 'Counter'],
  ['mrp', 'RtnMrp'],
  ['ghtPct', 'Ght%'],
  ['itemLot', 'ItmLot'],
  ['remark', 'Remark'],
  ['discountPct', 'LDisc%'],
  ['rateWith', 'RtWith'],
  ['rateType', 'RateType'],
  ['tagCost', 'TagCost'],
  // Desktop TR_SALE_RTN MSG_PR tag-labour columns (c29-c32); the writer stores TAG_LBR_*/TAG_OTH_AMT.
  ['tagLabourPct', 'Tag%'],
  ['tagLabourRate', 'TagLRate'],
  ['tagLabourAmount', 'TagLAmt'],
  ['tagOtherAmount', 'TagOtAmt'],
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

const NUMERIC_EXTENDED = new Set<string>([
  'ghtWt',
  'westPct',
  'fineWt',
  'metalAmount',
  'labourPct',
  'labourFixed',
  'otherAmount',
  'mrp',
  'ghtPct',
  'discountPct',
  'tagCost',
  'tagLabourPct',
  'tagLabourRate',
  'tagLabourAmount',
  'tagOtherAmount',
  'hallmarkIdWt',
  'hallmarkId2Wt',
  'hallmarkId3Wt',
  'hallmarkId4Wt',
]);

const blank = (): Line => ({
  itCode: 'GOLD',
  tagNo: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
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
  tblCode: '',
  mrp: '',
  ghtPct: '',
  itemLot: '',
  remark: '',
  discountPct: '',
  rateWith: '',
  rateType: '',
  tagCost: '',
  tagLabourPct: '',
  tagLabourRate: '',
  tagLabourAmount: '',
  tagOtherAmount: '',
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

export default function SaleReturnPage() {
  const [mode, setMode] = useState<'new' | 'saved'>('new');
  const [metadataDirty, setMetadataDirty] = useState(false);
  return (
    <div style={{ minWidth: 0 }}>
      <h1>Sales Return</h1>
      <div className="toolbar" aria-label="Sales Return workspace">
        <button
          type="button"
          className="ghost"
          aria-pressed={mode === 'new'}
          disabled={mode === 'saved' && metadataDirty}
          onClick={() => setMode('new')}
        >
          New return
        </button>
        <button
          type="button"
          className="ghost"
          aria-pressed={mode === 'saved'}
          onClick={() => setMode('saved')}
        >
          Saved returns
        </button>
      </div>
      {mode === 'saved' && <SaleReturnSavedPanel onDirtyChange={setMetadataDirty} />}
      <div hidden={mode !== 'new'}>
        <LegacySaleReturnForm />
      </div>
    </div>
  );
}

function LegacySaleReturnForm() {
  const { coYear } = useBusinessScope();
  // G11: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N' (blank default Y).
  const companySettings = useCompanySettings();
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
  const [coBook, setCoBook] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [billNo, setBillNo] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  // The original sale's book, chosen from the configured SALES books (G05). It used to be a free-text box
  // defaulting to the literal 'SAL', which a desktop-shaped company does not have.
  const [origBook, setOrigBook] = useState('');
  const [tender, setTender] = useState<Tender>({});
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
  const [result, setResult] = useState<any>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // Import-from-bill: pull the original sale's customer + items so the return is a click away.
  async function importBill() {
    if (!origBook || !billNo.trim()) {
      setErr('select the original sale book and enter its bill no first');
      return;
    }
    setErr('');
    try {
      const d: any = await get(
        `/sales-returns/import?vchNo=${encodeURIComponent(billNo.trim())}&coBook=${encodeURIComponent(origBook)}`,
      );
      setAcCode(d.acCode || '');
      setAcName(d.acName || '');
      setTaxRatePct(String(d.taxRatePct ?? 3));
      setInterState(!!d.interState);
      const ls: Line[] = (d.lines || []).map((l: any) => ({
        itCode: l.IT_CODE || 'GOLD',
        tagNo: l.TAG_NO || '',
        pcs: String(l.pcs || 1),
        grossWt: String(l.grossWt || ''),
        netWt: String(l.netWt || ''),
        touch: String(l.touch || ''),
        rate: String(l.rate || ''),
        making: l.labourAmount && l.netWt ? String(r2(l.labourAmount / l.netWt)) : '',
      }));
      setLines(ls.length ? ls : [blank()]);
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || 'import failed'
          : 'import failed',
      );
    }
  }

  // live line preview: fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
  const calc = (l: Line) => {
    const fine = fineFor('sale', {
      netWt: n(l.netWt),
      touch: n(l.touch),
      ghtWt: n(l.ghtWt),
      westPct: n(l.westPct),
    });
    const metal = r2(fine * n(l.rate));
    // P5/P7: the grid now carries ghat; per-gram labour is (net + ghat) x rate (LBR_WITH_GHT blank 'Y').
    const mk = labourCharge('per_gram', {
      netWt: n(l.netWt),
      ghatWt: n(l.ghtWt),
      withGhat: labourWithGhat,
      rate: n(l.making),
    });
    return { fine, metal, mk, net: r2(metal + mk) };
  };
  const lineNet = lines.reduce((s, l) => s + calc(l).net, 0);
  const taxable = r2(lineNet - n(discountAmount));
  const taxPrev = r2((taxable * n(taxRatePct)) / 100);
  const totalPrev = Math.round(taxable + taxPrev);

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
        coBook,
        coYear,
        acCode,
        acName: acName || undefined,
        billNo: billNo || undefined,
        origVchNo: billNo || undefined,
        origBook: billNo ? origBook || undefined : undefined,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        cashAmt: Number(tender.cashAmt || 0),
        chequeAmt: Number(tender.chequeAmt || 0),
        cardAmt: Number(tender.cardAmt || 0),
        upiAmt: Number(tender.upiAmt || 0),
        kasar: Number(tender.kasar || 0),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
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
            ...(l.making ? { labourType: 'per_gram', labourRate: n(l.making) } : {}),
            // P7: writer-verified extended columns; a blank cell is OMITTED, never sent as 0.
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
      setResult(await post('/sales-returns', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="SRT" />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
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
              <label>Orig Book</label>
              <BookSelect value={origBook} onChange={setOrigBook} mainBooks={['SALES']} />
            </div>
            <div className="field">
              <label>Orig Bill No</label>
              <div style={{ display: 'flex', gap: 4 }}>
                <input value={billNo} onChange={(e) => setBillNo(e.target.value)} />
                <button type="button" className="ghost" onClick={importBill}>
                  Import
                </button>
              </div>
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
          <h2>Returned Items</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedLineFields.length}
            testId="sale-return-grid-mode"
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
              {busy ? 'Saving…' : 'Save Return'}
            </button>
          </div>
        </div>
      </form>

      <TenderPanel
        total={totalPrev}
        value={tender}
        onChange={setTender}
        title="refund to the customer now (blank = full credit note)"
      />

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Return saved — Voucher #{result.vchNo} · credited ₹
            {Number(result.totals?.total ?? 0).toLocaleString('en-IN')} to customer
          </div>
          <div className="toolbar" style={{ marginTop: 6 }}>
            <button
              type="button"
              className="ghost"
              onClick={() =>
                window.open(
                  `/api/sales/credit-note?coBook=${encodeURIComponent(coBook)}&vchNo=${encodeURIComponent(String(result.vchNo))}&format=html`,
                  '_blank',
                )
              }
            >
              View Credit Note
            </button>
          </div>
        </div>
      )}
      <VoucherList
        table="SL_DATA"
        book={coBook}
        deleteBase="/sales-returns"
        printHref={(v) =>
          `/api/sales/credit-note?coBook=${encodeURIComponent(coBook)}&vchNo=${encodeURIComponent(v)}&format=html`
        }
        reloadKey={result?.vchNo}
      />
    </div>
  );
}
