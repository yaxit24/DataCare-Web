'use client';

import { useState } from 'react';
import { PurchaseSaleLink, PurchaseEntryFields } from '../../../../components/PurchaseSaleLink';
import { useRouter } from 'next/navigation';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { usePrintGate } from '../../../../lib/formRights';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { VoucherList } from '../../../../components/VoucherList';
import { useVoucherNumberKeys, VoucherNumberNote } from '../../../../components/VoucherNumberKeys';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import SubDetailGrid, { stoneRowFromApi, useSubDetail } from '../../../../components/SubDetailGrid';
import { companyFlag, useCompanySettingsState } from '../../../../lib/companySettings';
import {
  blankPurchaseLine as blank,
  PurchaseLineDetails,
  PurchaseLineGrid,
  purchaseLineFromView,
  purchaseLinesBody,
  usePurchasePricing,
  type PurchaseLine as Line,
} from '../../../../components/PurchaseEntryForm';
import { todayLocal } from '../../../../lib/localDate';
import { carryPurchaseHeader } from '../../../../lib/purchaseCarry';
import HallmarkPurchasePage from '../purchase-hm/page';
import { openDocument } from '../../../../lib/openDocument';
import { useVoucherZoom } from '../../../../lib/voucherZoom';

const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const editableString = (v: unknown) => (v == null ? '' : String(v));

/**
 * WP-28 (D1, D2): the one `Purchase` entry opens the layout the company setting chooses, as the desktop does:
 * MDI_FORM.cs:7866 opens TR_PURC_HM when `MsPurcWithHmTax` is Y, else TR_PURC (MDI_FORM.cs:7884). A blank setting is
 * N (MS_OPNCOMP.cs:1114). The setting is read when the screen opens.
 */
export default function PurchaseEntryPage() {
  const settings = useCompanySettingsState();
  if (settings.status === 'loading') return <div className="muted">Loading purchase settings…</div>;
  return settings.status === 'ready' && companyFlag(settings.values, 'PURC_WITH_HMTAX', 'N') ? (
    <HallmarkPurchasePage />
  ) : (
    <PlainPurchasePage />
  );
}

function PlainPurchasePage() {
  const { lcCode, coYear } = useBusinessScope();
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => todayLocal());
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [billNo, setBillNo] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [urd, setUrd] = useState(false);
  const [lines, setLines] = useState<Line[]>([blank()]);
  const pricing = usePurchasePricing();
  const { settingsState, settingsReady, tdsOn } = pricing;
  // Desktop TR_PURC carries TWO sub-detail grids: MSG_IDTL (34 cols, tag side) and MSG_PR_IDTL
  // (25 cols, purchase side). `purchase.ts:133` already accepts `stones` per line and persists it
  // at `:953`; this page sent nothing, so the whole stone workflow was unreachable.
  const stones = useSubDetail(lines.length);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    onAppendRow: () => {
      setLines((rows) => [...rows, blank()]);
      stones.appendLine();
    },
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blank()] : rows.filter((_, index) => index !== row),
      );
      stones.removeLine(row);
      return true;
    },
    onEscape: () => {},
  });
  // The desktop's image buttons act on the CURRENT grid row, so the row that last held focus
  // owns the photograph. It persists after blur so clicking the panel does not clear it.
  const [imageRow, setImageRow] = useState(0);
  const [tender, setTender] = useState<Tender>({});
  const [result, setResult] = useState<any>(null);
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [loadedVersion, setLoadedVersion] = useState(''); // N51 (D17): sent on update and delete
  // WP-28 (D6): the stored voucher as read; every value this screen does not show is sent back on save.
  const [loadedView, setLoadedView] = useState<Record<string, unknown> | null>(null);
  const [err, setErr] = useState('');
  const printGate = usePrintGate('Purchase/Purchase Invoice', setErr); // TR_PURC.cs:13541-13548
  // Desktop purchase header fields (TR_PURC:12982-13056) — party contact, bank/cheque,
  // credit terms, discount, TDS/TCS, hallmark charge and the posting-account overrides.
  const [address1, setAddress1] = useState('');
  const [address2, setAddress2] = useState('');
  const [address3, setAddress3] = useState('');
  const [city, setCity] = useState('');
  const [mobile, setMobile] = useState('');
  const [bankName, setBankName] = useState('');
  const [chequeNo, setChequeNo] = useState('');
  const [cardAc, setCardAc] = useState('');
  const [taxCode, setTaxCode] = useState('');
  const [tcsCode, setTcsCode] = useState('');
  const [tdsCode, setTdsCode] = useState('');
  const [saleBillNo, setSaleBillNo] = useState('');
  const [saleBillBook, setSaleBillBook] = useState('');
  const [purchaseAc, setPurchaseAc] = useState('');
  const [taxAc, setTaxAc] = useState('');
  const [roundAc, setRoundAc] = useState('');
  const [hmChargeAc, setHmChargeAc] = useState('');
  const [creditDays, setCreditDays] = useState('');
  const [discountPct, setDiscountPct] = useState('');
  const [tcsPct, setTcsPct] = useState('');
  const [tdsPct, setTdsPct] = useState('');
  const [roundOff, setRoundOff] = useState(''); // PR_DATA.ROF_AMT, the typed row 4 (TR_PURC.cs:12600)
  const [tdsAmount, setTdsAmount] = useState('');
  const [hmAmount, setHmAmount] = useState('');
  const [hmTaxPct, setHmTaxPct] = useState('');
  const [rateUnfix, setRateUnfix] = useState(false);
  const [busy, setBusy] = useState(false);

  // Desktop parity: TR_PURC's item grid exposes the operator-typed fields as columns.
  const [fullGrid, setFullGrid] = useState(false);
  const setLine = pricing.lineSetter(setLines);
  const { taxable, taxPrev, tcsAmount, rofAmt, totalPrev } = pricing.bill({
    lines,
    discountAmount,
    taxRatePct,
    interState,
    tcsPct,
    roundOff,
  });

  function newPurchase() {
    setLoadedVchNo('');
    setLoadedVersion('');
    setLoadedView(null);
    setVoucherLookup('');
    setResult(null);
    setErr('');
    setVchDate(todayLocal());
    setAcCode('');
    setAcName('');
    setBillNo('');
    setTaxRatePct('3');
    setDiscountAmount('');
    setInterState(false);
    setUrd(false);
    setRoundOff('');
    setLines([blank()]);
    setTender({});
  }

  useVoucherZoom({
    ready: !!coBook,
    book: coBook,
    setBook: setCoBook,
    load: (vchNo, book) => openPurchase(vchNo, book),
  });

  async function loadPurchase() {
    await openPurchase(voucherLookup);
  }

  /** Open a saved purchase of the selected book; resolves whether it loaded. */
  async function openPurchase(requested: string, book = coBook): Promise<boolean> {
    const vchNo = requested.trim();
    if (!vchNo || !book) return false;
    if (book !== coBook) setCoBook(book);
    setBusy(true);
    setErr('');
    try {
      const view = await get<any>(
        `/purchases/${encodeURIComponent(vchNo)}?coBook=${encodeURIComponent(book)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setLoadedVersion(String(view.version ?? ''));
      setLoadedView(view);
      setVoucherLookup(String(view.voucherNo));
      setResult(null);
      setVchDate(String(view.vchDate));
      // WP-28 (G2): the header fields this screen shows, from the stored voucher.
      setAddress1(editableString(view.address1));
      setAddress2(editableString(view.address2));
      setAddress3(editableString(view.address3));
      setCity(editableString(view.city));
      setMobile(editableString(view.mobile));
      setBankName(editableString(view.bankName));
      setChequeNo(editableString(view.chequeNo));
      setCardAc(editableString(view.cardAc));
      setTaxCode(editableString(view.taxCode));
      setTcsCode(editableString(view.tcsCode));
      setTdsCode(editableString(view.tdsCode));
      setSaleBillNo(editableString(view.saleBillNo));
      setSaleBillBook(editableString(view.saleBillBook));
      setCreditDays(str(view.creditDays));
      setDiscountPct(str(view.discountPct));
      setTcsPct(str(view.tcsPct));
      setTdsPct(str(view.tdsPct));
      setRoundOff(str(view.roundOffAmount));
      setTdsAmount(str(view.tdsAmount));
      setHmAmount(str(view.hmAmount));
      setHmTaxPct(str(view.hmTaxPct));
      setRateUnfix(!!view.rateUnfix);
      setAcCode(String(view.acCode ?? ''));
      setAcName(String(view.acName ?? ''));
      setBillNo(String(view.billNo ?? ''));
      setTaxRatePct(str(view.taxRatePct) || '0');
      setDiscountAmount(str(view.discountAmount));
      setInterState(!!view.interState);
      setUrd(!!view.urd);
      setTender({
        cashAmt: str(view.cashAmt),
        chequeAmt: str(view.chequeAmt),
        cardAmt: str(view.cardAmt),
        upiAmt: str(view.upiAmt),
        kasar: str(view.kasar),
        bankAc: String(view.bankAc ?? ''),
      });
      const loadedLines: Line[] = (view.lines ?? []).map(purchaseLineFromView);
      setLines(loadedLines.length ? loadedLines : [blank()]);
      // Repopulate the stone sub-detail per line. Without this the API returns the stones and the
      // screen still shows none, so an unchanged save posts an empty array and deletes them —
      // the reader fix alone does not close the loss, the round trip has to be closed at both ends.
      stones.load(
        (view.lines ?? []).map((line: any) =>
          (line.stones ?? []).map((stone: any) => stoneRowFromApi(stone)),
        ),
      );
      return true;
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
      return false;
    } finally {
      setBusy(false);
    }
  }

  // N172 (G179): the voucher number box's F1, Up, Down and Enter (tVchNo_KeyDown, TR_PURC.cs:14407-14432).
  const numberKeys = useVoucherNumberKeys({
    table: 'PR_DATA',
    book: coBook,
    value: voucherLookup,
    open: (vchNo) => openPurchase(vchNo),
    fresh: newPurchase,
  });

  async function removeLoadedPurchase() {
    if (!loadedVchNo || !window.confirm(`Delete voucher ${loadedVchNo}?`)) return;
    setBusy(true);
    setErr('');
    try {
      await del(
        `/purchases/${encodeURIComponent(loadedVchNo)}?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}&expectedVersion=${encodeURIComponent(loadedVersion)}`,
      );
      newPurchase();
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    if (loadedView?.linkedSale) return;
    if (!settingsReady) {
      setErr(
        settingsState.status === 'error'
          ? 'Purchase settings could not be loaded. Reload this page before saving.'
          : 'Purchase settings are still loading. Wait before saving.',
      );
      return;
    }
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = carryPurchaseHeader(loadedVchNo ? loadedView : null, {
        coBook,
        coYear,
        lcCode,
        acCode,
        acName: acName || undefined,
        billNo: billNo || undefined,
        rateUnfix: rateUnfix || undefined,
        address1: address1 || undefined,
        address2: address2 || undefined,
        address3: address3 || undefined,
        city: city || undefined,
        mobile: mobile || undefined,
        bankName: bankName || undefined,
        chequeNo: chequeNo || undefined,
        cardAc: cardAc || undefined,
        taxCode: taxCode || undefined,
        tcsCode: tcsCode || undefined,
        tdsCode: tdsCode || undefined,
        saleBillNo: saleBillNo || undefined,
        saleBillBook: saleBillBook || undefined,
        purchaseAc: purchaseAc || undefined,
        taxAc: taxAc || undefined,
        roundAc: roundAc || undefined,
        hmChargeAc: hmChargeAc || undefined,
        creditDays: creditDays ? n(creditDays) : undefined,
        discountPct: discountPct ? n(discountPct) : undefined,
        tcsPct: tcsPct ? n(tcsPct) : undefined,
        tcsAmount,
        tdsPct: tdsPct ? n(tdsPct) : undefined,
        roundOffAmount: rofAmt !== 0 ? rofAmt : undefined,
        tdsAmount: tdsAmount ? n(tdsAmount) : undefined,
        hmAmount: hmAmount ? n(hmAmount) : undefined,
        hmTaxPct: hmTaxPct ? n(hmTaxPct) : undefined,

        vchDate,
        urd,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        lines: purchaseLinesBody(lines, stones.inputsFor),
        cashAmt: Number(tender.cashAmt || 0),
        chequeAmt: Number(tender.chequeAmt || 0),
        cardAmt: Number(tender.cardAmt || 0),
        upiAmt: Number(tender.upiAmt || 0),
        kasar: Number(tender.kasar || 0),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
      });
      const saved = loadedVchNo
        ? await put<any>(`/purchases/${encodeURIComponent(loadedVchNo)}`, {
            ...body,
            expectedVersion: loadedVersion,
          })
        : await post<any>('/purchases', body);
      setResult(saved);
      setLoadedVersion(String(saved.version ?? '')); // N51: create and update return it
      const savedNo = String(saved.vchNo).padStart(5, '0');
      setLoadedVchNo(savedNo);
      setVoucherLookup(savedNo);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <FormKeyHints actions={formKeys} />
      <PurchaseSaleLink
        view={loadedView}
        book={coBook}
        voucher={loadedVchNo}
        version={loadedVersion}
        onClear={newPurchase}
      >
        <form onSubmit={submit}>
          <PurchaseEntryFields view={loadedView}>
            <VoucherChrome
              title="Purchase Invoice"
              vchNo={loadedVchNo ? Number(loadedVchNo) : (result?.vchNo ?? null)}
              date={vchDate}
              onDateChange={setVchDate}
              dateInputRef={numberKeys.dateRef}
              refNo={billNo}
              onRefNoChange={setBillNo}
              saving={busy}
            />
          </PurchaseEntryFields>
          <div className="panel">
            <div className="row">
              <div className="field">
                <label>Voucher No</label>
                <input
                  aria-label="Voucher No"
                  value={voucherLookup}
                  onChange={(e) => setVoucherLookup(e.target.value)}
                  onKeyDown={numberKeys.onKeyDown}
                  placeholder="00001"
                />
              </div>
              <button type="button" className="ghost" disabled={busy} onClick={loadPurchase}>
                Load
              </button>
              <VoucherNumberNote note={numberKeys.note} />
              {loadedVchNo && (
                <span className="msg ok" data-testid="purchase-loaded">
                  Loaded #{loadedVchNo}
                </span>
              )}
              {loadedVchNo && (
                <button
                  type="button"
                  className="danger"
                  disabled={busy || !!loadedView?.linkedSale}
                  onClick={removeLoadedPurchase}
                >
                  Delete
                </button>
              )}
              <button type="button" className="ghost" disabled={busy} onClick={newPurchase}>
                New
              </button>
              <div className="field">
                <label>Book</label>
                {/* TR_PURC opens on CurBookHelp("PURCHASE") (MDI_FORM.cs:7868); the writer refuses any other
                  MAIN_BOOK, so only purchase books are offered. */}
                <BookSelect value={coBook} onChange={setCoBook} preferred="PUR" family="purchase" />
              </div>
              <div className="field">
                <label>Year</label>
                <input value={coYear} readOnly />
              </div>
              <div className="field">
                <label>Location</label>
                <input value={lcCode} readOnly />
              </div>
              <button type="button" className="ghost" onClick={() => router.back()}>
                Exit
              </button>
            </div>
          </div>
          <PurchaseEntryFields view={loadedView}>
            <div className="panel">
              <div className="row">
                <div className="field">
                  <label>Supplier (AC_CODE)</label>
                  <LookupPicker
                    entity="accounts"
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
                  <label>Bill No</label>
                  <input value={billNo} onChange={(e) => setBillNo(e.target.value)} />
                </div>
                <div className="field">
                  <label>Tax %</label>
                  <input value={taxRatePct} onChange={(e) => setTaxRatePct(e.target.value)} />
                </div>
                <div className="field">
                  <label>Discount ₹</label>
                  <input
                    value={discountAmount}
                    onChange={(e) => setDiscountAmount(e.target.value)}
                  />
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
                <div className="field">
                  <label>URD (no GST)</label>
                  <select value={urd ? 'y' : 'n'} onChange={(e) => setUrd(e.target.value === 'y')}>
                    <option value="n">No</option>
                    <option value="y">Yes — unregistered dealer</option>
                  </select>
                </div>
              </div>
            </div>
            <div className="panel" style={{ overflow: 'auto' }}>
              <PurchaseLineGrid
                lines={lines}
                setLines={setLines}
                setLine={setLine}
                pricing={pricing}
                fullGrid={fullGrid}
                setFullGrid={setFullGrid}
                testId="purchase-grid-mode"
                onGridKey={handleGridKey}
                onRemoveLine={(i) => {
                  setLines((ls) => ls.filter((_, j) => j !== i));
                  stones.removeLine(i);
                }}
              />
              {/* Sub-detail for the line the operator last touched, mirroring the desktop's
              RowColChange filtering (TR_SALE.cs:16791-16876). A line selector is offered because
              the web grid has no notion of a "current row" the way MSFlexGrid does. */}
              <div className="row" style={{ marginTop: 8, alignItems: 'flex-end' }}>
                <div className="field">
                  <label>Stones for item line</label>
                  <select
                    value={stones.activeLine}
                    onChange={(e) => stones.setActiveLine(Number(e.target.value))}
                  >
                    {lines.map((l, i) => (
                      <option key={i} value={i}>
                        {i + 1}
                        {l.itCode ? ` — ${l.itCode}` : ''}
                        {l.tagNo ? ` / ${l.tagNo}` : ''}
                      </option>
                    ))}
                  </select>
                </div>
                <div className="field">
                  <span className="muted">{stones.totalRows} stone row(s) on this voucher</span>
                </div>
              </div>
              <SubDetailGrid
                rows={stones.rowsFor(stones.activeLine)}
                onRowsChange={(rows) => stones.setRowsFor(stones.activeLine, rows)}
                parentLabel={`item line ${stones.activeLine + 1}`}
                desktopSource="TR_PURC / MSG_IDTL (34 cols) + MSG_PR_IDTL (25 cols)"
              />
              <details style={{ marginTop: 8 }}>
                <summary>Desktop header fields</summary>
                <div className="row">
                  <div className="field">
                    <label>Rate Unfixed</label>
                    <input
                      type="checkbox"
                      checked={rateUnfix}
                      onChange={(e) => setRateUnfix(e.target.checked)}
                    />
                  </div>
                  <div className="field">
                    <label>Address 1</label>
                    <input value={address1} onChange={(e) => setAddress1(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Address 2</label>
                    <input value={address2} onChange={(e) => setAddress2(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Address 3</label>
                    <input value={address3} onChange={(e) => setAddress3(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>City</label>
                    <input value={city} onChange={(e) => setCity(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Mobile</label>
                    <input value={mobile} onChange={(e) => setMobile(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Bank Name</label>
                    <input value={bankName} onChange={(e) => setBankName(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Cheque No</label>
                    <input value={chequeNo} onChange={(e) => setChequeNo(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Card A/c</label>
                    <input value={cardAc} onChange={(e) => setCardAc(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Tax Code</label>
                    <input value={taxCode} onChange={(e) => setTaxCode(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>TCS Code</label>
                    <input value={tcsCode} onChange={(e) => setTcsCode(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>TDS Code</label>
                    <input value={tdsCode} onChange={(e) => setTdsCode(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Sale Bill No</label>
                    <input value={saleBillNo} onChange={(e) => setSaleBillNo(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Sale Bill Book</label>
                    <input value={saleBillBook} onChange={(e) => setSaleBillBook(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Purchase A/c</label>
                    <input value={purchaseAc} onChange={(e) => setPurchaseAc(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Tax A/c</label>
                    <input value={taxAc} onChange={(e) => setTaxAc(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Round-off A/c</label>
                    <input value={roundAc} onChange={(e) => setRoundAc(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Hallmark A/c</label>
                    <input value={hmChargeAc} onChange={(e) => setHmChargeAc(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Credit Days</label>
                    <input value={creditDays} onChange={(e) => setCreditDays(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Disc %</label>
                    <input value={discountPct} onChange={(e) => setDiscountPct(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>TCS %</label>
                    <input value={tcsPct} onChange={(e) => setTcsPct(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>TCS Amt</label>
                    <input value={tcsAmount} readOnly />
                  </div>
                  <div className="field">
                    <label>TDS %</label>
                    <input value={tdsPct} onChange={(e) => setTdsPct(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>TDS Amt</label>
                    <input value={tdsAmount} onChange={(e) => setTdsAmount(e.target.value)} />
                  </div>
                  {!tdsOn && (
                    <div className="field">
                      <label>Round Off</label>
                      <input value={roundOff} onChange={(e) => setRoundOff(e.target.value)} />
                    </div>
                  )}
                  <div className="field">
                    <label>Hallmark Amt</label>
                    <input value={hmAmount} onChange={(e) => setHmAmount(e.target.value)} />
                  </div>
                  <div className="field">
                    <label>Hallmark GST %</label>
                    <input value={hmTaxPct} onChange={(e) => setHmTaxPct(e.target.value)} />
                  </div>
                </div>
              </details>
              <PurchaseLineDetails lines={lines} fullGrid={fullGrid} setLine={setLine} />
              <div className="toolbar" style={{ marginTop: 10 }}>
                <button
                  type="button"
                  className="ghost"
                  onClick={() => setLines((ls) => [...ls, blank()])}
                >
                  + Add line
                </button>
                <span className="spacer" />
                {settingsReady ? (
                  <span className="muted" style={{ marginRight: 16 }}>
                    Taxable ₹{taxable.toLocaleString('en-IN')} · Tax ₹
                    {taxPrev.toLocaleString('en-IN')} ·{' '}
                    <b>Total ₹{totalPrev.toLocaleString('en-IN')}</b>
                  </span>
                ) : (
                  <span className="muted" style={{ marginRight: 16 }}>
                    {settingsState.status === 'error'
                      ? 'Purchase totals unavailable because settings failed to load.'
                      : 'Loading purchase settings…'}
                  </span>
                )}
                <button className="primary" disabled={busy || !settingsReady}>
                  {busy ? 'Saving…' : loadedVchNo ? 'Update Purchase' : 'Save Purchase'}
                </button>
              </div>
            </div>
            {settingsReady && (
              <TenderPanel
                total={totalPrev}
                value={tender}
                onChange={setTender}
                title="pay the supplier now (blank = full on credit)"
              />
            )}
            {settingsState.status === 'error' && (
              <div className="msg err" role="alert" data-testid="purchase-settings-error">
                Purchase settings could not be loaded. Reload this page before saving.
              </div>
            )}
          </PurchaseEntryFields>
        </form>
      </PurchaseSaleLink>
      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">Saved — Voucher #{result.vchNo}</div>
          <div className="toolbar">
            <button
              type="button"
              className="ghost"
              onClick={() =>
                printGate.open(
                  `/api/purchases/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(result.vchNo))}&format=html`,
                )
              }
            >
              View Purchase Bill
            </button>
          </div>
          {result.totals && (
            <div className="tiles">
              {Object.entries(result.totals).map(([k, v]) => (
                <div className="tile" key={k}>
                  <div className="muted">{k}</div>
                  <div className="big kpi">{Number(v).toLocaleString('en-IN')}</div>
                </div>
              ))}
            </div>
          )}
        </div>
      )}
      <VoucherList
        table="PR_DATA"
        book={coBook}
        deleteBase={loadedView?.linkedSale ? undefined : '/purchases'}
        onLoad={(_vchNo, identity) => void openPurchase(identity.vchNo, identity.coBook)}
        openKey={numberKeys.listKey}
        printHref={(v) =>
          `/api/purchases/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(v)}&format=html`
        }
        reloadKey={result?.vchNo}
        canPrint={printGate.canPrint}
      />
      {/* Desktop BtnImgS / BtnImgC / BtnImgD photograph the tag on the current grid row. */}
      <EntityImagePanel
        entityType="TAG"
        entityKey={lines[imageRow]?.tagNo ?? ''}
        instance={imageRow + 1}
        label="Tag image"
        testId="purchase-image"
      />
    </div>
  );
}
