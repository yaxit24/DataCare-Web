'use client';
import { useState } from 'react';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { useBusinessScope, useRoundingPolicy } from '../../../../components/BusinessScope';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';
import { VoucherList } from '../../../../components/VoucherList';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';
import {
  blank,
  cell,
  extendedLineFields,
  lineCommand,
  lineFromPurchase,
  lineFromView,
  linePreview,
  setLineCell,
  updateLine,
  type Line,
} from '../../../../lib/purchaseReturnForm';
import { todayLocal } from '../../../../lib/localDate';
import { billTotals } from '@datacare/core';

const n = (v: string) => Number(v || 0);
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;
const today = () => todayLocal();
const failure = (e: unknown, fallback: string) =>
  e instanceof ApiError ? e.body?.message || e.body?.error || e.message : fallback;

/** Books a purchase return can come from: TR_PURC and TR_PURC_HM purchase books. */
const ORIGINAL_PURCHASE_BOOKS = ['PURCHASE', 'TAG PURCHASE'];

export default function PurchaseReturnPage() {
  // G11: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N' (blank default Y).
  const companySettings = useCompanySettings();
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
  const { coYear, lcCode } = useBusinessScope();
  const roundingPolicy = useRoundingPolicy();
  const [coBook, setCoBook] = useState('');
  // TR_KR_ISU reopens a saved voucher by number (tVchNo_KeyDown -> DISPLAY_DATA, :5709, :4612) and saves it
  // through the same handler as a new one; loadedVchNo is the voucher being edited ('' for a new one).
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [vchDate, setVchDate] = useState(today);
  // Header fields the screen does not show but must send back unchanged on an edit.
  const [taxCode, setTaxCode] = useState('');
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

  const setLine = (i: number, k: Parameters<typeof setLineCell>[1], v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? setLineCell(l, k, v) : l)));
  const scopeQuery = () =>
    `coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`;

  const previews = lines.map((l) => linePreview(l, labourWithGhat));
  const lineNet = previews.reduce((s, p) => s + p.net, 0);
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

  function newReturn() {
    setVoucherLookup('');
    setLoadedVchNo('');
    setVchDate(today());
    setTaxCode('');
    setOrigBook('');
    setOrigYear(coYear);
    setOrigVchNo('');
    setAcCode('');
    setAcName('');
    setBillNo('');
    setTaxRatePct('3');
    setDiscountAmount('');
    setInterState(false);
    setLines([blank()]);
    setImageRow(0);
    setTender({});
    setResult(null);
    setErr('');
  }

  /** Hydrate every field the API returns, so an unchanged save writes the same rows. */
  async function loadReturn(requested = voucherLookup) {
    if (!coBook || !requested.trim()) {
      setErr('select the return book and enter a voucher number first');
      return;
    }
    setErr('');
    setBusy(true);
    try {
      const view = await get<any>(
        `/purchase-returns/${encodeURIComponent(requested.trim())}?${scopeQuery()}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setResult(null);
      setVchDate(String(view.vchDate));
      setTaxCode(String(view.taxCode ?? ''));
      setOrigBook(String(view.origBook ?? ''));
      setOrigYear(String(view.origYear ?? '') || coYear);
      setOrigVchNo(String(view.origVchNo ?? ''));
      setAcCode(String(view.acCode ?? ''));
      setAcName(String(view.acName ?? ''));
      setBillNo(String(view.billNo ?? ''));
      setTaxRatePct(cell(view.taxRatePct) || '0');
      setDiscountAmount(cell(view.discountAmount));
      setInterState(!!view.interState);
      setTender({
        cashAmt: cell(view.cashAmt),
        chequeAmt: cell(view.chequeAmt),
        cardAmt: cell(view.cardAmt),
        kasar: cell(view.kasar),
        bankAc: String(view.bankAc ?? ''),
      });
      const loaded: Line[] = (view.lines ?? []).map((line: Record<string, unknown>) =>
        lineFromView(line),
      );
      setLines(loaded.length ? loaded : [blank()]);
      setImageRow(0);
    } catch (e) {
      setErr(failure(e, 'load failed'));
    } finally {
      setBusy(false);
    }
  }

  async function removeLoadedReturn() {
    if (!loadedVchNo || !window.confirm(`Delete purchase return ${loadedVchNo}?`)) return;
    setBusy(true);
    setErr('');
    try {
      await del(`/purchase-returns/${encodeURIComponent(loadedVchNo)}?${scopeQuery()}`);
      newReturn();
    } catch (e) {
      setErr(failure(e, 'delete failed'));
    } finally {
      setBusy(false);
    }
  }

  // Import the original purchase: supplier, tax and every line with its tag instance, so the operator
  // returns what was bought instead of retyping it (desktop TR_KR_ISU source picker, :6845-6975).
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
      setTaxRatePct(cell(view.taxRatePct) || '0');
      setInterState(!!view.interState);
      const imported: Line[] = (view.lines ?? []).map((line: Record<string, unknown>) =>
        lineFromPurchase(line),
      );
      setLines(imported.length ? imported : [blank()]);
    } catch (e) {
      setErr(failure(e, 'import failed'));
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
        vchDate,
        origBook: origVchNo.trim() ? origBook || undefined : undefined,
        origYear: origVchNo.trim() ? origYear || undefined : undefined,
        origVchNo: origVchNo.trim() || undefined,
        acCode,
        acName: acName || undefined,
        billNo: billNo || undefined,
        taxRatePct: Number(taxRatePct),
        taxCode: loadedVchNo ? taxCode || undefined : undefined,
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        // A loaded line is sent back as loaded; a new line only with the cells the operator filled.
        lines: lines.filter((l) => l.loaded || (l.itCode && (l.netWt || l.rate))).map(lineCommand),
        cashAmt: n(String(tender.cashAmt ?? '')),
        chequeAmt: n(String(tender.chequeAmt ?? '')),
        cardAmt: n(String(tender.cardAmt ?? '')),
        upiAmt: n(String(tender.upiAmt ?? '')),
        kasar: n(String(tender.kasar ?? '')),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
      };
      const saved = loadedVchNo
        ? await put<any>(`/purchase-returns/${encodeURIComponent(loadedVchNo)}`, body)
        : await post<any>('/purchase-returns', body);
      // Reload what was saved, so the screen holds the persisted voucher and a further save is an edit.
      await loadReturn(String(saved.vchNo).padStart(5, '0'));
      setResult(saved);
    } catch (e) {
      setErr(failure(e, 'failed'));
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
              <label>Voucher No</label>
              <input
                aria-label="Voucher No"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                placeholder="00001"
              />
            </div>
            <button type="button" className="ghost" disabled={busy} onClick={() => loadReturn()}>
              Load
            </button>
            {loadedVchNo && (
              <span className="msg ok" data-testid="purchase-return-loaded">
                Loaded #{loadedVchNo}
              </span>
            )}
            {loadedVchNo && (
              <button type="button" className="danger" disabled={busy} onClick={removeLoadedReturn}>
                Delete
              </button>
            )}
            <button type="button" className="ghost" disabled={busy} onClick={newReturn}>
              New
            </button>
            <div className="field">
              <label>Date</label>
              <input
                type="date"
                aria-label="Voucher date"
                value={vchDate}
                onChange={(e) => setVchDate(e.target.value)}
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
                ariaLabel="Supplier account"
                value={acCode}
                onChange={setAcCode}
                resolveTypedCode
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
                required={false}
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
                const c = previews[i] ?? linePreview(l, labourWithGhat);
                return (
                  <tr key={i} onFocus={() => setImageRow(i)}>
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
                        // A typed tag is a different instance: updateLine drops the old serial.
                        onChange={(v) => setLine(i, 'tagNo', v)}
                        style={{ width: 110 }}
                        onPick={(r) =>
                          setLines((ls) =>
                            ls.map((x, j) =>
                              j === i
                                ? updateLine(x, {
                                    tagNo: String(r.code),
                                    itCode: String(r.name || x.itCode),
                                    netWt: String(r.ITM_NWT ?? x.netWt),
                                    grossWt: String(r.ITM_GWT ?? x.grossWt),
                                    touch: String(r.ITM_TOUCH ?? x.touch),
                                    rate: String(r.ITM_RATE ?? x.rate),
                                  })
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
            <button className="primary" data-save-mnemonic disabled={busy}>
              {busy ? 'Saving…' : loadedVchNo ? `Save Return #${loadedVchNo}` : 'Save Return'}
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
          `/api/purchase-returns/${encodeURIComponent(v)}/print?${scopeQuery()}&format=html`
        }
        onLoad={(v) => {
          setVoucherLookup(v);
          void loadReturn(v);
        }}
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
