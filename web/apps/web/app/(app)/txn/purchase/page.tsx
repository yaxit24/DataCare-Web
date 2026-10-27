'use client';

import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';
import { useState } from 'react';
import { useRouter } from 'next/navigation';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { useBusinessScope, useRoundingPolicy } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { TenderPanel, type Tender } from '../../../../components/TenderPanel';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { VoucherList } from '../../../../components/VoucherList';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { EntityImagePanel } from '../../../../components/EntityImagePanel';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import SubDetailGrid, { stoneRowFromApi, useSubDetail } from '../../../../components/SubDetailGrid';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { fineFor, labourCharge, billTotals, lineNet as lineNetAmount } from '@datacare/core';
import { todayLocal } from '../../../../lib/localDate';

interface Line {
  itCode: string;
  tagNo: string;
  vchSrno?: number;
  metal?: 'G' | 'S';
  labourType?: 'per_gram' | 'per_piece' | 'percentage' | 'fixed';
  labourRate?: number;
  labourFixed?: number;
  otherFineWt?: number;
  silverFineWt?: number;
  otherAmount?: number;
  huid?: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  // Desktop purchase-grid columns the API accepts (TR_PURC mSG_PR); without controls the
  // operator cannot enter them.
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
const blank = (): Line => ({
  itCode: '', // desktop grids start empty; a demo default posts to the wrong item
  tagNo: '',
  metal: 'G',
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
const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;

export default function PurchaseEntryPage() {
  const { lcCode, coYear } = useBusinessScope();
  const roundingPolicy = useRoundingPolicy();
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
  /**
   * P4: `ITM_FINE_LOCK` — the desktop sets the fine cell's entry box read-only when this is on
   * (TR_PURC.cs:7145-7148, `TEXT_PR.ReadOnly = true`), so the computed fine cannot be overtyped.
   * There is nothing for the server to enforce: the value still posts, it just may not be retyped.
   * Blank default 'N' per MS_OPNCOMP.cs.
   */
  const companySettings = useCompanySettings();
  const fineLocked = companyFlag(companySettings, 'ITM_FINE_LOCK', 'N');
  // G11: per-gram labour is on (net + ghat) unless the company sets LBR_WITH_GHT='N' (blank default Y).
  const labourWithGhat = companyFlag(companySettings, 'LBR_WITH_GHT', 'Y');
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
  const [err, setErr] = useState('');
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
  const [tcsAmount, setTcsAmount] = useState('');
  const [tdsPct, setTdsPct] = useState('');
  const [tdsAmount, setTdsAmount] = useState('');
  const [hmAmount, setHmAmount] = useState('');
  const [hmTaxPct, setHmTaxPct] = useState('');
  const [rateUnfix, setRateUnfix] = useState(false);
  const [busy, setBusy] = useState(false);

  // Desktop parity: TR_PURC's item grid exposes the operator-typed fields as columns.
  const [fullGrid, setFullGrid] = useState(false);
  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  const calc = (l: Line) => {
    const fine = fineFor('purchaseItem', {
      netWt: n(l.netWt),
      touch: n(l.touch),
      ghtWt: n(l.ghtWt),
      westPct: n(l.westPct),
    });
    const metal = r2(fine * n(l.rate));
    // P5: per-gram labour is (net + ghat) x rate unless the company switches ghat off
    // (LBR_WITH_GHT, blank default 'Y'). This page sends ghtWt to the server, so computing the
    // preview from netWt alone understated labour by ghat x rate against what actually posts.
    const mk = labourCharge('per_gram', {
      netWt: n(l.netWt),
      ghatWt: n(l.ghtWt),
      withGhat: labourWithGhat,
      rate: n(l.making),
    });
    // G84: the server's line net is metal + labour + OTHER charges (purchase.ts calcLineNet); previewing
    // metal + making alone understated any line carrying an other-charge amount.
    const other = Number(l.otherAmount ?? 0) || 0;
    return { fine, metal, mk, net: lineNetAmount({ metal, labour: mk, other }) };
  };
  const lineNet = lines.reduce((s, l) => s + calc(l).net, 0);
  // G102: preview with the same arithmetic and company rounding policy the server posts, so the shown
  // total equals the saved total (no more previewing Math.round(taxable + tax)).
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

  function newPurchase() {
    setLoadedVchNo('');
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
    setLines([blank()]);
    setTender({});
  }

  async function loadPurchase() {
    if (!voucherLookup.trim()) return;
    setBusy(true);
    setErr('');
    try {
      const view = await get<any>(
        `/purchases/${encodeURIComponent(voucherLookup.trim())}?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setResult(null);
      setVchDate(String(view.vchDate));
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
      const loadedLines: Line[] = (view.lines ?? []).map((line: any) => ({
        itCode: String(line.itCode ?? ''),
        tagNo: String(line.tagNo ?? ''),
        vchSrno: Number(line.vchSrno ?? 0) || undefined,
        metal: line.metal === 'S' ? 'S' : 'G',
        pcs: str(line.pcs),
        grossWt: str(line.grossWt),
        netWt: str(line.netWt),
        touch: str(line.touch),
        rate: str(line.rate),
        making: line.labourType === 'per_gram' ? str(line.labourRate) : '',
        labourType: line.labourType,
        labourRate: Number(line.labourRate ?? 0) || undefined,
        labourFixed: Number(line.labourFixed ?? 0) || undefined,
        otherFineWt: Number(line.otherFineWt ?? 0) || undefined,
        silverFineWt: Number(line.silverFineWt ?? 0) || undefined,
        otherAmount: Number(line.otherAmount ?? 0) || undefined,
        huid: String(line.huid ?? '') || undefined,
      }));
      setLines(loadedLines.length ? loadedLines : [blank()]);
      // Repopulate the stone sub-detail per line. Without this the API returns the stones and the
      // screen still shows none, so an unchanged save posts an empty array and deletes them —
      // the reader fix alone does not close the loss, the round trip has to be closed at both ends.
      stones.load(
        (view.lines ?? []).map((line: any) =>
          (line.stones ?? []).map((stone: any) => stoneRowFromApi(stone)),
        ),
      );
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  async function removeLoadedPurchase() {
    if (!loadedVchNo || !window.confirm(`Delete voucher ${loadedVchNo}?`)) return;
    setBusy(true);
    setErr('');
    try {
      await del(
        `/purchases/${encodeURIComponent(loadedVchNo)}?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`,
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
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const body = {
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
        tcsAmount: tcsAmount ? n(tcsAmount) : undefined,
        tdsPct: tdsPct ? n(tdsPct) : undefined,
        tdsAmount: tdsAmount ? n(tdsAmount) : undefined,
        hmAmount: hmAmount ? n(hmAmount) : undefined,
        hmTaxPct: hmTaxPct ? n(hmTaxPct) : undefined,

        vchDate,
        urd,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        lines: lines
          // The ORIGINAL index is carried through the filter on purpose: stones are keyed by the
          // line the operator entered them against, and empty lines are dropped below, so a
          // filtered position would attach a stone block to the wrong item.
          .map((l, sourceIndex) => ({ l, sourceIndex }))
          .filter(({ l }) => l.itCode && (l.netWt || l.rate))
          .map(({ l, sourceIndex }) => ({
            stones: stones.inputsFor(sourceIndex),
            itCode: l.itCode,
            tagNo: l.tagNo || undefined,
            vchSrno: l.vchSrno,
            metal: l.metal,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
            rate: n(l.rate),
            otherFineWt: l.otherFineWt,
            silverFineWt: l.silverFineWt,
            otherAmount: l.otherAmount,
            tblCode: l.tblCode || undefined,
            designNo: l.designNo || undefined,
            itDesc: l.itDesc || undefined,
            lotNo: l.lotNo || undefined,
            itmLot: l.itmLot || undefined,
            withStock: l.withStock || undefined,
            bagWt: n(l.bagWt) || undefined,
            lessWt: n(l.lessWt) || undefined,
            lossWt: n(l.lossWt) || undefined,
            ghtPct: n(l.ghtPct) || undefined,
            ghtWt: n(l.ghtWt) || undefined,
            westPct: n(l.westPct) || undefined,
            fineWt: n(l.fineWt) || undefined,
            labourPct: n(l.labourPct) || undefined,
            lessTouch: n(l.lessTouch) || undefined,
            lesTouch: n(l.lesTouch) || undefined,
            kunFine: n(l.kunFine) || undefined,
            convRate: n(l.convRate) || undefined,
            convPct: n(l.convPct) || undefined,
            otherRate: n(l.otherRate) || undefined,
            mrp: n(l.mrp) || undefined,
            metalAmount: n(l.metalAmount) || undefined,
            commissionPct: n(l.commissionPct) || undefined,
            commissionAmount: n(l.commissionAmount) || undefined,
            fineCutPcs: n(l.fineCutPcs) || undefined,
            fineCutGrossWt: n(l.fineCutGrossWt) || undefined,
            fineCutNetWt: n(l.fineCutNetWt) || undefined,
            fineCutFine: n(l.fineCutFine) || undefined,
            prCode: l.prCode || undefined,
            urdRateType: l.urdRateType || undefined,

            huid: l.huid,
            ...(l.making
              ? { labourType: 'per_gram' as const, labourRate: n(l.making) }
              : l.labourType
                ? {
                    labourType: l.labourType,
                    labourRate: l.labourRate,
                    labourFixed: l.labourFixed,
                  }
                : {}),
          })),
        cashAmt: Number(tender.cashAmt || 0),
        chequeAmt: Number(tender.chequeAmt || 0),
        cardAmt: Number(tender.cardAmt || 0),
        upiAmt: Number(tender.upiAmt || 0),
        kasar: Number(tender.kasar || 0),
        cashAc: tender.cashAc || undefined,
        bankAc: tender.bankAc || undefined,
        kasarAc: tender.kasarAc || undefined,
      };
      const saved = loadedVchNo
        ? await put<any>(`/purchases/${encodeURIComponent(loadedVchNo)}`, body)
        : await post<any>('/purchases', body);
      setResult(saved);
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
      <form onSubmit={submit}>
        <VoucherChrome
          title="Purchase Invoice"
          vchNo={loadedVchNo ? Number(loadedVchNo) : (result?.vchNo ?? null)}
          date={vchDate}
          onDateChange={setVchDate}
          refNo={billNo}
          onRefNoChange={setBillNo}
          saving={busy}
          onExit={() => router.back()}
        />
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Voucher No</label>
              <input
                aria-label="Voucher No"
                value={voucherLookup}
                onChange={(e) => setVoucherLookup(e.target.value)}
                placeholder="00001"
              />
            </div>
            <button type="button" className="ghost" disabled={busy} onClick={loadPurchase}>
              Load
            </button>
            {loadedVchNo && (
              <span className="msg ok" data-testid="purchase-loaded">
                Loaded #{loadedVchNo}
              </span>
            )}
            {loadedVchNo && (
              <button
                type="button"
                className="danger"
                disabled={busy}
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
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                preferred="PUR"
                mainBooks={['PURCHASE']}
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
          <div className="toolbar" style={{ marginBottom: 6 }}>
            <h2 style={{ margin: 0 }}>Items</h2>
            <span className="spacer" />
            <GridModeToggle
              full={fullGrid}
              setFull={setFullGrid}
              extendedCount={extendedLineFields.length}
              testId="purchase-grid-mode"
            />
          </div>
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
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                <th className="num">Fine</th>
                <th className="num">Amount</th>
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
                    <ExtendedBodyCells
                      full={fullGrid}
                      fields={extendedLineFields}
                      line={l}
                      row={i}
                      baseColumns={0}
                      setValue={(row, key, value) => setLine(row, key, value)}
                      readOnlyFields={fineLocked ? (['fineWt'] as const) : undefined}
                    />
                    <td className="num">{c.fine.toLocaleString('en-IN')}</td>
                    <td className="num">{c.net.toLocaleString('en-IN')}</td>
                    <td>
                      <button
                        type="button"
                        className="danger"
                        onClick={() => {
                          setLines((ls) => ls.filter((_, j) => j !== i));
                          stones.removeLine(i);
                        }}
                      >
                        ×
                      </button>
                    </td>
                  </tr>
                );
              })}
            </tbody>
          </table>
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
                <input value={tcsAmount} onChange={(e) => setTcsAmount(e.target.value)} />
              </div>
              <div className="field">
                <label>TDS %</label>
                <input value={tdsPct} onChange={(e) => setTdsPct(e.target.value)} />
              </div>
              <div className="field">
                <label>TDS Amt</label>
                <input value={tdsAmount} onChange={(e) => setTdsAmount(e.target.value)} />
              </div>
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
          {lines.map((line, index) => (
            <details
              key={`purc-line-extra-${index}`}
              style={{ marginTop: 8, display: fullGrid ? 'none' : undefined }}
            >
              <summary>Item row {index + 1} desktop fields</summary>
              <div className="row">
                {extendedLineFields.map(([key, label]) => (
                  <div className="field" key={String(key)}>
                    <label>{label}</label>
                    <input
                      value={String(line[key] ?? '')}
                      onChange={(e) => setLine(index, key, e.target.value)}
                    />
                  </div>
                ))}
              </div>
            </details>
          ))}
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
              {busy ? 'Saving…' : loadedVchNo ? 'Update Purchase' : 'Save Purchase'}
            </button>
          </div>
        </div>
        <TenderPanel
          total={totalPrev}
          value={tender}
          onChange={setTender}
          title="pay the supplier now (blank = full on credit)"
        />
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
                  `/api/purchases/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(result.vchNo))}&format=html`,
                  '_blank',
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
        deleteBase="/purchases"
        printHref={(v) =>
          `/api/purchases/invoice?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(v)}&format=html`
        }
        reloadKey={result?.vchNo}
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
