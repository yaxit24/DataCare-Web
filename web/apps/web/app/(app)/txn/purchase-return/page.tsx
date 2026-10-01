'use client';
import { useState } from 'react';
import { get, post, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';
import { VoucherList } from '../../../../components/VoucherList';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
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
  /** The tag instance on the original purchase line. Server-owned identity; never typed by the operator. */
  vchSrno?: number;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  tblCode: string;
  designNo: string;
  itDesc: string;
  lotNo: string;
  itmLot: string;
  withStock: string;
  bagWt: string;
  lessWt: string;
  lossWt: string;
  ghtPct: string;
  ghtWt: string;
  westPct: string;
  fineWt: string;
  labourPct: string;
  lessTouch: string;
  lesTouch: string;
  kunFine: string;
  convRate: string;
  convPct: string;
  otherRate: string;
  mrp: string;
  metalAmount: string;
  commissionPct: string;
  commissionAmount: string;
  fineCutPcs: string;
  fineCutGrossWt: string;
  fineCutNetWt: string;
  fineCutFine: string;
  prCode: string;
  urdRateType: string;
}
const extendedLineFields: Array<[keyof Line, string]> = [
  ['tblCode', 'Counter'],
  ['designNo', 'Design'],
  ['itDesc', 'Item Desc'],
  ['lotNo', 'Lot No'],
  ['itmLot', 'Item Lot'],
  ['withStock', 'With Stock'],
  ['bagWt', 'Bag Wt'],
  ['lessWt', 'Less Wt'],
  ['lossWt', 'Loss Wt'],
  ['ghtPct', 'Ghat %'],
  ['ghtWt', 'Ghat Wt'],
  ['westPct', 'Wastage %'],
  ['fineWt', 'Fine Wt'],
  ['labourPct', 'Labour %'],
  ['lessTouch', 'Less Touch'],
  ['lesTouch', 'Old-gold Less Touch'],
  ['kunFine', 'Kun Fine'],
  ['convRate', 'Conv Rate'],
  ['convPct', 'Conv %'],
  ['otherRate', 'Other Rate'],
  ['mrp', 'MRP'],
  ['metalAmount', 'Metal Amt'],
  ['commissionPct', 'Comm %'],
  ['commissionAmount', 'Comm Amt'],
  ['fineCutPcs', 'Fine-cut Pcs'],
  ['fineCutGrossWt', 'Fine-cut Gross'],
  ['fineCutNetWt', 'Fine-cut Net'],
  ['fineCutFine', 'Fine-cut Fine'],
  ['prCode', 'PR Code'],
  ['urdRateType', 'URD Rate Type'],
];

const NUMERIC_EXTENDED = new Set<string>([
  'bagWt',
  'lessWt',
  'lossWt',
  'ghtPct',
  'ghtWt',
  'westPct',
  'fineWt',
  'labourPct',
  'lessTouch',
  'lesTouch',
  'kunFine',
  'convRate',
  'convPct',
  'otherRate',
  'mrp',
  'metalAmount',
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
  tblCode: '',
  designNo: '',
  itDesc: '',
  lotNo: '',
  itmLot: '',
  withStock: '',
  bagWt: '',
  lessWt: '',
  lossWt: '',
  ghtPct: '',
  ghtWt: '',
  westPct: '',
  fineWt: '',
  labourPct: '',
  lessTouch: '',
  lesTouch: '',
  kunFine: '',
  convRate: '',
  convPct: '',
  otherRate: '',
  mrp: '',
  metalAmount: '',
  commissionPct: '',
  commissionAmount: '',
  fineCutPcs: '',
  fineCutGrossWt: '',
  fineCutNetWt: '',
  fineCutFine: '',
  prCode: '',
  urdRateType: '',
});
const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

/** Books a purchase return can come from: TR_PURC and TR_PURC_HM purchase books. */
const ORIGINAL_PURCHASE_BOOKS = ['PURCHASE', 'TAG PURCHASE'];
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));

export default function PurchaseReturnPage() {
  // G11: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N' (blank default Y).
  const companySettings = useCompanySettings();
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
  const { coYear, lcCode } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  // The original purchase this return reverses. A tagged return must name it: the writer resolves each
  // returned tag against that voucher's own lines (purchaseReturn.ts resolvePurchaseReturnTags).
  const [origBook, setOrigBook] = useState('');
  const [origYear, setOrigYear] = useState(coYear);
  const [origVchNo, setOrigVchNo] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [billNo, setBillNo] = useState('');
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
  // The desktop's image buttons act on the CURRENT grid row, so the row that last held focus
  // owns the photograph. It persists after blur so clicking the panel does not clear it.
  const [imageRow, setImageRow] = useState(0);
  const [tender, setTender] = useState<Tender>({});
  const [result, setResult] = useState<any>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line preview: fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
  const calc = (l: Line) => {
    const fine = fineFor('purchaseItem', {
      netWt: n(l.netWt),
      touch: n(l.touch),
      ghtWt: n(l.ghtWt),
      westPct: n(l.westPct),
    });
    const metal = r2(fine * n(l.rate));
    // P5/P7: the grid now carries ghat, so per-gram labour is (net + ghat) x rate unless the
    // company switches ghat off (LBR_WITH_GHT, blank default 'Y').
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

  // Import the original purchase: supplier, tax and every line with its tag instance, so the operator
  // returns what was bought instead of retyping it (desktop TR_KR_ISU source picker, :6850-6895).
  async function importPurchase() {
    if (!origBook || !origVchNo.trim()) {
      setErr('select the original purchase book and voucher first');
      return;
    }
    setErr('');
    setBusy(true);
    try {
      const view = await get<any>(
        `/purchases/${encodeURIComponent(origVchNo.trim())}?coBook=${encodeURIComponent(origBook)}&coYear=${encodeURIComponent(origYear)}&lcCode=${encodeURIComponent(lcCode)}`,
      );
      setOrigVchNo(String(view.voucherNo));
      setAcCode(String(view.acCode ?? ''));
      setAcName(String(view.acName ?? ''));
      setBillNo(String(view.billNo ?? ''));
      setTaxRatePct(str(view.taxRatePct) || '0');
      setInterState(!!view.interState);
      const imported: Line[] = (view.lines ?? []).map((line: any) => ({
        ...blank(),
        itCode: String(line.itCode ?? ''),
        tagNo: String(line.tagNo ?? ''),
        vchSrno: Number(line.vchSrno ?? 0) || undefined,
        pcs: str(line.pcs) || '1',
        grossWt: str(line.grossWt),
        netWt: str(line.netWt),
        touch: str(line.touch),
        rate: str(line.rate),
        making: line.labourType === 'per_gram' ? str(line.labourRate) : '',
        ghtWt: str(line.ghtWt),
        westPct: str(line.westPct),
        designNo: String(line.designNo ?? ''),
        tblCode: String(line.tblCode ?? ''),
        itDesc: String(line.itDesc ?? ''),
        mrp: str(line.mrp),
      }));
      setLines(imported.length ? imported : [blank()]);
    } catch (e) {
      setErr(
        e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'import failed',
      );
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
        origBook: origVchNo.trim() ? origBook || undefined : undefined,
        origYear: origVchNo.trim() ? origYear || undefined : undefined,
        origVchNo: origVchNo.trim() || undefined,
        acCode,
        acName: acName || undefined,
        billNo: billNo || undefined,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        lines: lines
          .filter((l) => l.itCode && (l.netWt || l.rate))
          .map((l) => ({
            itCode: l.itCode,
            tagNo: l.tagNo || undefined,
            vchSrno: l.tagNo ? l.vchSrno : undefined,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
            rate: n(l.rate),
            ...(l.making ? { labourType: 'per_gram', labourRate: n(l.making) } : {}),
            // P7: extended columns; a blank cell is OMITTED, never sent as 0 (an explicit zero is an
            // override at the writer and would defeat the server's derivation).
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
        cashAmt: n(String(tender.cashAmt ?? '')),
        chequeAmt: n(String(tender.chequeAmt ?? '')),
        cardAmt: n(String(tender.cardAmt ?? '')),
        upiAmt: n(String(tender.upiAmt ?? '')),
        kasar: n(String(tender.kasar ?? '')),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
      };
      setResult(await post('/purchase-returns', body));
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Purchase Return</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                mainBooks={['PURC RETURN']}
                preferred="PRT"
              />
            </div>
            <div className="field">
              <label>Year</label>
              <input value={coYear} readOnly />
            </div>
            <div className="field">
              <label>Supplier (AC_CODE)</label>
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
              <label>Supplier Name</label>
              <input value={acName} onChange={(e) => setAcName(e.target.value)} />
            </div>
            <div className="field">
              <label>Orig Purchase Year</label>
              <input
                aria-label="Original purchase year"
                value={origYear}
                onChange={(e) => setOrigYear(e.target.value)}
                placeholder="2024-2025"
              />
            </div>
            <div className="field">
              <label>Orig Purchase Book</label>
              <BookSelect
                value={origBook}
                onChange={setOrigBook}
                mainBooks={ORIGINAL_PURCHASE_BOOKS}
              />
            </div>
            <div className="field">
              <label>Orig Voucher</label>
              <div style={{ display: 'flex', gap: 4 }}>
                <input
                  aria-label="Original purchase voucher"
                  value={origVchNo}
                  onChange={(e) => setOrigVchNo(e.target.value)}
                  placeholder="00001"
                />
                <button type="button" className="ghost" disabled={busy} onClick={importPurchase}>
                  Import
                </button>
              </div>
            </div>
            <div className="field">
              <label>Bill No</label>
              <input value={billNo} onChange={(e) => setBillNo(e.target.value)} />
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
            testId="purchase-return-grid-mode"
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
                        // A typed tag is a different instance: drop the serial imported with the old one.
                        onChange={(v) =>
                          setLines((ls) =>
                            ls.map((l, j) =>
                              j === i ? { ...l, tagNo: v, vchSrno: undefined } : l,
                            ),
                          )
                        }
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
                      baseColumns={9}
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
        <TenderPanel
          total={totalPrev}
          value={tender}
          onChange={setTender}
          title="refund received from supplier now (blank = credit their account)"
        />
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            Return saved — Voucher #{result.vchNo} · debited supplier ₹
            {Number(result.totals?.total ?? 0).toLocaleString('en-IN')}
          </div>
        </div>
      )}
      <VoucherList
        table="PR_DATA"
        book={coBook}
        deleteBase="/purchase-returns"
        printHref={(v) =>
          `/api/purchase-returns/${encodeURIComponent(v)}/print?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}&format=html`
        }
        reloadKey={result?.vchNo}
      />
      {/* Desktop BtnImgS / BtnImgC / BtnImgD photograph the tag on the current grid row. */}
      <EntityImagePanel
        entityType="TAG"
        entityKey={lines[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="purchase-return-image"
      />
    </div>
  );
}
