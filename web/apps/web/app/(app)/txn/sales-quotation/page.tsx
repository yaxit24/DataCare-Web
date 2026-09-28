'use client';

import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  extendedGridColumnCount,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';
import { useRef, useState } from 'react';
import { useRouter } from 'next/navigation';
import { del, get, post, put, ApiError } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import { RateTicker } from '../../../../components/RateTicker';
import { PartyBalance } from '../../../../components/PartyBalance';
import { VoucherChrome } from '../../../../components/VoucherChrome';
import { VoucherList } from '../../../../components/VoucherList';
import { desktopGlobalFormKeyActions, FormKeyHints } from '../../../../components/FormKeys';
import { companyFlag, useCompanySettings } from '../../../../lib/companySettings';
import { recalcLine } from '../../../../lib/lineRecalc';

interface Line {
  itCode: string;
  tagNo: string;
  vchSrno?: number;
  labourType?: 'per_gram' | 'per_piece' | 'percentage' | 'fixed';
  labourRate?: number;
  labourFixed?: number;
  ordNo?: string;
  ordYrcd?: string;
  ordDbcd?: string;
  ordSrno?: number;
  isuNo?: string;
  isuYrcd?: string;
  isuDbcd?: string;
  isuSrno?: number;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  making: string;
  designNo: string;
  itmSize: string;
  lessWt: string;
  lbrPct: string;
  othAmt: string;
  bagWt: string;
  tagGrossWt: string;
  tagNetWt: string;
  ghtPct: string;
  style: string;
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
  // Desktop item-grid columns the API accepts that had no control: without them the operator
  // cannot enter wastage, ghat weight, HUID, counter, MRP or an explicit fine/amount override.
  westPct: string;
  ghtWt: string;
  fineWt: string;
  labourPct: string;
  tblCode: string;
  huid: string;
  mrp: string;
  otherAmount: string;
  discountAmount: string;
  metalAmount: string;
  metal: string;
  orderTagStockAdd: string;
  designImageId: string;
  hallmarkId2: string;
  hallmarkId3: string;
  hallmarkId4: string;
  hallmarkIdWt: string;
  hallmarkId2Wt: string;
  hallmarkId3Wt: string;
  hallmarkId4Wt: string;
  otherWt: string;
}
interface OgRow {
  metal: 'G' | 'S';
  itCode: string;
  pcs: string;
  grossWt: string;
  netWt: string;
  touch: string;
  rate: string;
  description: string;
  otherWt: string;
  conversionPct: string;
  conversionWt: string;
  rateType: string;
}
/** Voucher margin, returned only when the company shows bill profit. */
type SaleProfit = { total: number; lines: { basis: string; cost: number; profit: number }[] };

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
const blank = (): Line => ({
  otherWt: '',
  itCode: 'GOLD',
  tagNo: '',
  pcs: '1',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  making: '',
  designNo: '',
  itmSize: '',
  lessWt: '',
  lbrPct: '',
  othAmt: '',
  bagWt: '',
  westPct: '',
  ghtWt: '',
  fineWt: '',
  labourPct: '',
  tblCode: '',
  huid: '',
  mrp: '',
  otherAmount: '',
  discountAmount: '',
  metalAmount: '',
  metal: '',
  tagGrossWt: '',
  tagNetWt: '',
  ghtPct: '',
  style: '',
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
  orderTagStockAdd: '',
  designImageId: '',
  hallmarkId2: '',
  hallmarkId3: '',
  hallmarkId4: '',
  hallmarkIdWt: '',
  hallmarkId2Wt: '',
  hallmarkId3Wt: '',
  hallmarkId4Wt: '',
});
const ogBlank = (): OgRow => ({
  metal: 'G',
  itCode: 'OG',
  pcs: '',
  grossWt: '',
  netWt: '',
  touch: '',
  rate: '',
  description: '',
  otherWt: '',
  conversionPct: '',
  conversionWt: '',
  rateType: '',
});
const n = (v: string) => Number(v || 0);
const str = (v: unknown) => (v == null || Number(v) === 0 ? '' : String(v));
const r2 = (x: number) => Math.round((x + 1e-9) * 100) / 100;
/**
 * P7 dead cells removed, found by scripts/check-dead-cells.mjs.
 *
 * Nine columns were rendered here that the sales writer never reads, so every value an operator typed
 * into them was silently discarded — and the depth metric counted all nine as parity. Five have NO
 * SL_DETL COLUMN AT ALL despite the interface carrying a column comment (ITM_MARGIN, TAG_LBR_PRC,
 * TAG_LBR_RATE, TAG_LBR_AMT, TAG_OTH_AMT), verified against information_schema. `tagSrNo` and
 * `tagType` are server-assigned, `margin` is deliberately server-derived (sales.ts:1866 notes a
 * client-supplied cost would let the margin be manipulated), and `dataTransfer` and
 * `lineDiscountAmount` are read by nothing.
 *
 * The same nine were removed from hallmark-sale earlier; this page was never re-checked, which is why
 * the audit is now a script rather than a habit.
 */
/** TR_SALE:8976/8978 hides the saved ordinal and item-type cells.
 * OLD_SRNO and IT_TYPE remain server-owned; expose neither as a discarded operator edit.
 * The supported metal input below still undergoes the server's ITEM_MAST validation. */
const extendedLineFields: Array<[keyof Line, string]> = [
  ['otherWt', 'Other Wt'],

  ['bagWt', 'Bag Wt'],
  ['tagGrossWt', 'Tag Gross Wt'],
  ['tagNetWt', 'Tag Net Wt'],
  ['ghtPct', 'Ghat %'],
  ['style', 'Style'],
  ['itemLot', 'Item Lot'],
  ['remark', 'Remark'],
  ['discountPct', 'Line Disc %'],
  ['ghatAmount', 'Ghat Amt'],
  ['rateWith', 'Rate With'],
  ['rateType', 'Rate Type'],
  ['tagCost', 'Tag Cost'],
  ['karigarNetWt', 'Karigar Net Wt'],
  ['karigarTouch', 'Karigar Touch'],
  ['karigarWestPct', 'Karigar West %'],
  ['karigarFine', 'Karigar Fine'],
  ['karigarName', 'Karigar'],
  ['employeeCode', 'Line Employee'],
  ['prCode', 'PR Code'],
  ['orderTagStockAdd', 'Order Tag Stock Add'],
  ['designImageId', 'Design Image ID'],
  ['hallmarkId2', 'Hallmark ID 2'],
  ['hallmarkId3', 'Hallmark ID 3'],
  ['hallmarkId4', 'Hallmark ID 4'],
  ['hallmarkIdWt', 'Hallmark ID Wt'],
  ['hallmarkId2Wt', 'Hallmark ID 2 Wt'],
  ['hallmarkId3Wt', 'Hallmark ID 3 Wt'],
  ['hallmarkId4Wt', 'Hallmark ID 4 Wt'],
  ['westPct', 'Wastage %'],
  ['ghtWt', 'Ghat Wt'],
  ['fineWt', 'Fine Wt (override)'],
  ['labourPct', 'Labour % (alt)'],
  ['tblCode', 'Counter'],
  ['huid', 'HUID'],
  ['mrp', 'MRP'],
  ['otherAmount', 'Other Amt (alt)'],
  ['discountAmount', 'Disc Amt (alt)'],
  ['metalAmount', 'Metal Amt (override)'],
  ['metal', 'Metal (G/S)'],
];
const extendedHeaderFields: Array<[string, string]> = [
  ['cashAc', 'Cash Ac'],
  ['hmChargeAc', 'Hm Charge Ac'],
  ['hmTaxPct', 'Hm Tax Pct'],
  ['kasarAc', 'Kasar Ac'],
  ['oldGoldAc', 'Old Gold Ac'],
  ['rateUnfix', 'Rate Unfix'],
  ['roundAc', 'Round Ac'],
  ['salesAc', 'Sales Ac'],
  ['taxAc', 'Tax Ac'],
  ['taxCode', 'Tax Code'],
  ['tcsAc', 'Tcs Ac'],
  ['tcsAmount', 'Tcs Amount'],
];
const gridCell = (row: number, column: number) => ({
  'data-grid-row': row,
  'data-grid-column': column,
});

export default function SalesQuotationPage() {
  const { lcCode, coYear } = useBusinessScope();
  // Desktop posting-account overrides and hallmark/rate-unfix flags the API accepts.
  const [headerExtra, setHeaderExtra] = useState<Record<string, string>>({});
  const router = useRouter();
  const formKeys = desktopGlobalFormKeyActions((href) => router.push(href));
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState(() => new Date().toISOString().slice(0, 10));
  const [refNo, setRefNo] = useState('');
  const [acCode, setAcCode] = useState('WALKIN');
  const [acName, setAcName] = useState('');
  const [taxRatePct, setTaxRatePct] = useState('3');
  const [discountAmount, setDiscountAmount] = useState('');
  const [interState, setInterState] = useState(false);
  const [cashAmt, setCashAmt] = useState('');
  const [cardAmt, setCardAmt] = useState('');
  const [upiAmt, setUpiAmt] = useState('');
  const [chequeAmt, setChequeAmt] = useState('');
  const [hmCharge, setHmCharge] = useState('');
  const [tcsPct, setTcsPct] = useState('');
  const [kasar, setKasar] = useState('');
  const [ordNo, setOrdNo] = useState('');
  const [ordAmt, setOrdAmt] = useState('');
  const [crDays, setCrDays] = useState('');
  const [empCode, setEmpCode] = useState('');
  const [discountPct, setDiscountPct] = useState('');
  const [tcsCode, setTcsCode] = useState('');
  const [tdsCode, setTdsCode] = useState('');
  const [tdsPct, setTdsPct] = useState('');
  const [tdsAmount, setTdsAmount] = useState('');
  const [cardAc, setCardAc] = useState('');
  const [bankAc, setBankAc] = useState('');
  const [chequeNo, setChequeNo] = useState('');
  const [bankName, setBankName] = useState('');
  const [cardCommissionAmount, setCardCommissionAmount] = useState('');
  const [cashPaid, setCashPaid] = useState('');
  const [currentAdjustmentAmount, setCurrentAdjustmentAmount] = useState('');
  const [schemeAc, setSchemeAc] = useState('');
  const [schemeAmount, setSchemeAmount] = useState('');
  const [pointValue, setPointValue] = useState('');
  const [address1, setAddress1] = useState('');
  const [address2, setAddress2] = useState('');
  const [address3, setAddress3] = useState('');
  const [city, setCity] = useState('');
  const [mobile, setMobile] = useState('');
  const [issueNo, setIssueNo] = useState('');
  const [issueYear, setIssueYear] = useState('');
  const [issueBook, setIssueBook] = useState('');
  const [description, setDescription] = useState('');
  const [ornamentIssued, setOrnamentIssued] = useState(true);
  // Old-gold / old-silver EXCHANGE grid (metal taken in against the sale) — backend createSale.oldGold[]
  const [ogRows, setOgRows] = useState<OgRow[]>([]);
  const [lines, setLines] = useState<Line[]>([blank()]);
  /**
   * P4: `SL_NWT_LOCK` — the desktop makes the sale's net-weight cell read-only when set, so the
   * operator cannot retype a figure the tag or the gross/less computation produced
   * (the same idiom as TR_PURC.cs:7145-7148 `TEXT_PR.ReadOnly = true` for the fine cell).
   * Blank default is 'N' per MS_OPNCOMP.cs, i.e. unlocked.
   */
  const companySettings = useCompanySettings();
  const netWeightLocked = companyFlag(companySettings, 'SL_NWT_LOCK', 'N');
  // `billProfit` is present only when CO_SET_NEW.BILL_PROFIT is on, so its absence means "the shop does not
  // show margins" rather than "the margin is zero".
  const [result, setResult] = useState<{
    vchNo: number;
    totals: Totals;
    billProfit?: { total: number; lines: { basis: string; cost: number; profit: number }[] };
  } | null>(null);
  const [voucherLookup, setVoucherLookup] = useState('');
  const [loadedVchNo, setLoadedVchNo] = useState('');
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);
  const cashRef = useRef<HTMLInputElement>(null);
  // Desktop parity: TR_SALE's main item grid (MSG) exposes every operator-typed field as a grid
  // COLUMN, so an operator tabs across ~30 cells per line. Full grid mode promotes the same fields
  // from the per-row panel into real cells; compact stays the default for narrow screens.
  const [fullGrid, setFullGrid] = useState(false);
  const baseItemColumns = 13;
  const handleItemGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: extendedGridColumnCount(fullGrid, baseItemColumns, extendedLineFields.length),
    onAppendRow: () => setLines((current) => [...current, blank()]),
    onRemoveRow: (row) => {
      if (!window.confirm('Remove this item row?')) return false;
      setLines((current) =>
        current.length === 1 ? [blank()] : current.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => cashRef.current?.focus(),
  });

  const setLine = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));

  // live line preview: fine = net×touch/100, metal = fine×rate, making = net×making/g, net = metal+making
  /**
   * P5: the line preview now delegates to the shared recalculation kernel.
   *
   * The local arithmetic this replaces disagreed with the server in four ways, so the figures on
   * screen were not the figures that posted:
   *   - fine was rounded to 2dp; the server's fine precision is 3dp (`PRECISION.fine`)
   *   - `westPct` was ignored entirely, while the server's fine base is (touch + wastage)
   *   - making was `netWt x rate` with no ghat term, the same LBR_WITH_GHT understatement already
   *     fixed on the server (blank default 'Y', so ghat counts unless switched off)
   *   - it rounded locally instead of through the money kernel
   * Delegating means there is one implementation, so the preview cannot drift from the posting again.
   */
  const calc = (l: Line) => {
    const r = recalcLine({ ...l, labourRate: l.making, labourType: 'G' }, 'sale', {
      labourIncludesGhat: companyFlag(companySettings, 'LBR_WITH_GHT', 'Y'),
    });
    return { fine: r.fineWt, metal: r.metalAmount, mk: r.netLabourAmount, net: r.totalAmount };
  };
  const lineNet = lines.reduce((s, l) => s + calc(l).net, 0);
  const taxable = r2(lineNet - n(discountAmount));
  const taxPrev = r2((taxable * n(taxRatePct)) / 100);
  const ogAmt = (o: OgRow) => r2(((n(o.netWt) * n(o.touch)) / 100) * n(o.rate));
  const setOg = (i: number, k: keyof OgRow, v: string) =>
    setOgRows((rs) => rs.map((r, j) => (j === i ? { ...r, [k]: v } : r)));
  const oldGoldVal = r2(ogRows.reduce((s, o) => s + ogAmt(o), 0));
  const hmAmt = n(hmCharge);
  const hmTax = r2((hmAmt * n(taxRatePct)) / 100);
  const itemTotal = Math.round(taxable + taxPrev);
  const tcsAmt = r2((itemTotal * n(tcsPct)) / 100);
  const totalPrev = r2(itemTotal + hmAmt + hmTax + tcsAmt);
  const kasarAmt = n(kasar);
  const paid = r2(n(cashAmt) + n(cardAmt) + n(upiAmt) + n(chequeAmt) + oldGoldVal);
  const balanceDue = r2(totalPrev - paid - kasarAmt - n(ordAmt));

  function newSale() {
    setLoadedVchNo('');
    setVoucherLookup('');
    setResult(null);
    setErr('');
    setVchDate(new Date().toISOString().slice(0, 10));
    setRefNo('');
    setAcCode('WALKIN');
    setAcName('');
    setTaxRatePct('3');
    setDiscountAmount('');
    setInterState(false);
    setCashAmt('');
    setCardAmt('');
    setUpiAmt('');
    setChequeAmt('');
    setHmCharge('');
    setTcsPct('');
    setKasar('');
    setOrdNo('');
    setOrdAmt('');
    setCrDays('');
    setEmpCode('');
    setDiscountPct('');
    setTcsCode('');
    setTdsCode('');
    setTdsPct('');
    setTdsAmount('');
    setCardAc('');
    setBankAc('');
    setChequeNo('');
    setBankName('');
    setCardCommissionAmount('');
    setCashPaid('');
    setCurrentAdjustmentAmount('');
    setSchemeAc('');
    setSchemeAmount('');
    setPointValue('');
    setAddress1('');
    setAddress2('');
    setAddress3('');
    setCity('');
    setMobile('');
    setIssueNo('');
    setIssueYear('');
    setIssueBook('');
    setDescription('');
    setOrnamentIssued(true);
    setOgRows([]);
    setLines([blank()]);
  }

  async function loadSale() {
    if (!voucherLookup.trim()) return;
    setBusy(true);
    setErr('');
    try {
      const view = await get<any>(
        `/sales-quotations/${encodeURIComponent(voucherLookup.trim())}?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`,
      );
      setLoadedVchNo(String(view.voucherNo));
      setVoucherLookup(String(view.voucherNo));
      setResult(null);
      setVchDate(String(view.vchDate));
      setRefNo(String(view.billNo ?? ''));
      setAcCode(String(view.acCode ?? ''));
      setAcName(String(view.acName ?? ''));
      setTaxRatePct(str(view.taxRatePct) || '0');
      setDiscountAmount(str(view.discountAmount));
      setInterState(!!view.interState);
      setCashAmt(str(view.cashAmt));
      setCardAmt(str(view.cardAmt));
      setUpiAmt(str(view.upiAmt));
      setChequeAmt(str(view.chequeAmt));
      setHmCharge(str(view.hallmarkAmount));
      setTcsPct(str(view.tcsPct));
      setKasar(str(view.kasarAmount));
      setOrdNo(String(view.orderRef?.ordNo ?? ''));
      setOrdAmt(str(view.orderRef?.adjustAmt));
      setCrDays(str(view.crDays));
      setEmpCode(String(view.empCode ?? ''));
      setDiscountPct(str(view.discountPct));
      setTcsCode(String(view.tcsCode ?? ''));
      setTdsCode(String(view.tdsCode ?? ''));
      setTdsPct(str(view.tdsPct));
      setTdsAmount(str(view.tdsAmount));
      setCardAc(String(view.cardAc ?? ''));
      setBankAc(String(view.bankAc ?? ''));
      setChequeNo(String(view.chequeNo ?? ''));
      setBankName(String(view.bankName ?? ''));
      setCardCommissionAmount(str(view.cardCommissionAmount));
      setCashPaid(str(view.cashPaid));
      setCurrentAdjustmentAmount(str(view.currentAdjustmentAmount));
      setSchemeAc(String(view.schemeAc ?? ''));
      setSchemeAmount(str(view.schemeAmount));
      setPointValue(str(view.pointValue));
      setAddress1(String(view.address1 ?? ''));
      setAddress2(String(view.address2 ?? ''));
      setAddress3(String(view.address3 ?? ''));
      setCity(String(view.city ?? ''));
      setMobile(String(view.mobile ?? ''));
      setIssueNo(String(view.issueNo ?? ''));
      setIssueYear(String(view.issueYear ?? ''));
      setIssueBook(String(view.issueBook ?? ''));
      setDescription(String(view.description ?? ''));
      setOrnamentIssued(view.ornamentIssued !== false);
      setOgRows(
        (view.oldGold ?? []).map((row: any) => ({
          metal: row.metal === 'S' ? 'S' : 'G',
          itCode: String(row.itCode ?? ''),
          pcs: str(row.pcs),
          grossWt: str(row.grossWt),
          netWt: str(row.netWt),
          touch: str(row.touch),
          rate: str(row.rate),
          description: String(row.description ?? ''),
          otherWt: str(row.otherWt),
          conversionPct: str(row.conversionPct),
          conversionWt: str(row.conversionWt),
          rateType: String(row.rateType ?? ''),
        })),
      );
      const loadedLines: Line[] = (view.lines ?? []).map((line: any) => ({
        itCode: String(line.itCode ?? ''),
        tagNo: String(line.tagNo ?? ''),
        vchSrno: Number(line.vchSrno ?? 0) || undefined,
        pcs: str(line.pcs),
        grossWt: str(line.grossWt),
        netWt: str(line.netWt),
        touch: str(line.touch),
        rate: str(line.rate),
        making: line.labourType === 'per_gram' ? str(line.labourRate) : '',
        designNo: String(line.designNo ?? ''),
        itmSize: String(line.itmSize ?? ''),
        lessWt: str(line.lessWt),
        lbrPct: str(line.labourPct),
        othAmt: str(line.otherAmount),
        bagWt: str(line.bagWt),
        tagGrossWt: str(line.tagGrossWt),
        tagNetWt: str(line.tagNetWt),
        ghtPct: str(line.ghtPct),
        style: String(line.style ?? ''),
        itemLot: String(line.itemLot ?? ''),
        remark: String(line.remark ?? ''),
        discountPct: str(line.discountPct),
        lineDiscountAmount: str(line.discountAmount),
        ghatAmount: str(line.ghatAmount),
        rateWith: String(line.rateWith ?? ''),
        rateType: String(line.rateType ?? ''),
        tagCost: str(line.tagCost),
        karigarNetWt: str(line.karigarNetWt),
        karigarTouch: str(line.karigarTouch),
        karigarWestPct: str(line.karigarWestPct),
        karigarFine: str(line.karigarFine),
        karigarName: String(line.karigarName ?? ''),
        employeeCode: String(line.employeeCode ?? ''),
        prCode: String(line.prCode ?? ''),
        orderTagStockAdd: String(line.orderTagStockAdd ?? ''),
        designImageId: String(line.designImageId ?? ''),
        hallmarkId2: String(line.hallmarkId2 ?? ''),
        hallmarkId3: String(line.hallmarkId3 ?? ''),
        hallmarkId4: String(line.hallmarkId4 ?? ''),
        hallmarkIdWt: str(line.hallmarkIdWt),
        hallmarkId2Wt: str(line.hallmarkId2Wt),
        hallmarkId3Wt: str(line.hallmarkId3Wt),
        hallmarkId4Wt: str(line.hallmarkId4Wt),
        labourType: line.labourType,
        labourRate: Number(line.labourRate ?? 0) || undefined,
        labourFixed: Number(line.labourFixed ?? 0) || undefined,
        ordNo: String(line.ordNo ?? '') || undefined,
        ordYrcd: String(line.ordYrcd ?? '') || undefined,
        ordDbcd: String(line.ordDbcd ?? '') || undefined,
        ordSrno: Number(line.ordSrno ?? 0) || undefined,
        isuNo: String(line.isuNo ?? '') || undefined,
        isuYrcd: String(line.isuYrcd ?? '') || undefined,
        isuDbcd: String(line.isuDbcd ?? '') || undefined,
        isuSrno: Number(line.isuSrno ?? 0) || undefined,
      }));
      setLines(loadedLines.length ? loadedLines : [blank()]);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  async function removeLoadedSale() {
    if (!loadedVchNo || !window.confirm(`Delete voucher ${loadedVchNo}?`)) return;
    setBusy(true);
    setErr('');
    try {
      await del(
        `/sales-quotations/${encodeURIComponent(loadedVchNo)}?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&lcCode=${encodeURIComponent(lcCode)}`,
      );
      newSale();
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
      const oldGold = ogRows
        .filter((o) => ogAmt(o) > 0)

        .map((o) => ({
          itCode: o.itCode || (o.metal === 'S' ? 'OS' : 'OG'),
          pcs: n(o.pcs),
          grossWt: n(o.grossWt),
          netWt: n(o.netWt),
          touch: n(o.touch),
          metal: o.metal,
          description: o.description || undefined,
          rate: n(o.rate),
          otherWt: n(o.otherWt),
          conversionPct: n(o.conversionPct),
          conversionWt: n(o.conversionWt),
          rateType: o.rateType || undefined,
          amount: ogAmt(o),
        }));
      const body = {
        coBook,
        coYear,
        lcCode,
        acCode,
        acName: acName || undefined,
        vchDate,
        billNo: refNo || undefined,
        taxRatePct: Number(taxRatePct),
        interState,
        discountAmount: discountAmount ? Number(discountAmount) : undefined,
        discountPct: discountPct ? n(discountPct) : undefined,
        tcsCode: tcsCode || undefined,
        tdsCode: tdsCode || undefined,
        tdsPct: tdsPct ? n(tdsPct) : undefined,
        tdsAmount: tdsAmount ? n(tdsAmount) : undefined,
        hallmarkAmount: hmAmt > 0 ? hmAmt : undefined,
        tcsPct: n(tcsPct) > 0 ? n(tcsPct) : undefined,
        kasarAmount: kasarAmt > 0 ? kasarAmt : undefined,
        orderRef: ordNo.trim()
          ? { ordNo: ordNo.trim(), adjustAmt: n(ordAmt) > 0 ? n(ordAmt) : undefined }
          : undefined,
        crDays: crDays ? Number(crDays) : undefined,
        empCode: empCode || undefined,
        cardAc: cardAc || undefined,
        bankAc: bankAc || undefined,
        chequeNo: chequeNo || undefined,
        bankName: bankName || undefined,
        cardCommissionAmount: cardCommissionAmount ? n(cardCommissionAmount) : undefined,
        cashPaid: cashPaid ? n(cashPaid) : undefined,
        currentAdjustmentAmount: currentAdjustmentAmount ? n(currentAdjustmentAmount) : undefined,
        schemeAc: schemeAc || undefined,
        schemeAmount: schemeAmount ? n(schemeAmount) : undefined,
        pointValue: pointValue ? n(pointValue) : undefined,
        address1: address1 || undefined,
        address2: address2 || undefined,
        address3: address3 || undefined,
        city: city || undefined,
        mobile: mobile || undefined,
        issueNo: issueNo || undefined,
        issueYear: issueYear || undefined,
        issueBook: issueBook || undefined,
        description: description || undefined,
        ornamentIssued,
        cashAmt: cashAmt ? n(cashAmt) : undefined,
        cardAmt: cardAmt ? n(cardAmt) : undefined,
        upiAmt: upiAmt ? n(upiAmt) : undefined,
        chequeAmt: chequeAmt ? n(chequeAmt) : undefined,
        oldGold: oldGold.length ? oldGold : undefined,
        cashAc: headerExtra.cashAc || undefined,
        hmChargeAc: headerExtra.hmChargeAc || undefined,
        hmTaxPct: headerExtra.hmTaxPct ? Number(headerExtra.hmTaxPct) : undefined,
        kasarAc: headerExtra.kasarAc || undefined,
        oldGoldAc: headerExtra.oldGoldAc || undefined,
        rateUnfix: headerExtra.rateUnfix || undefined,
        roundAc: headerExtra.roundAc || undefined,
        salesAc: headerExtra.salesAc || undefined,
        taxAc: headerExtra.taxAc || undefined,
        taxCode: headerExtra.taxCode || undefined,
        tcsAc: headerExtra.tcsAc || undefined,
        tcsAmount: headerExtra.tcsAmount || undefined,
        lines: lines
          .filter((l) => l.itCode && (l.netWt || l.rate))
          .map((l) => ({
            itCode: l.itCode,
            tagNo: l.tagNo || undefined,
            vchSrno: l.vchSrno,
            pcs: n(l.pcs),
            grossWt: n(l.grossWt),
            netWt: n(l.netWt),
            touch: n(l.touch),
            rate: n(l.rate),
            designNo: l.designNo || undefined,
            itmSize: l.itmSize || undefined,
            lessWt: n(l.lessWt) || undefined,
            labourPct: n(l.lbrPct) || undefined,
            otherAmount: n(l.othAmt) || undefined,
            bagWt: n(l.bagWt) || undefined,
            tagGrossWt: n(l.tagGrossWt) || undefined,
            tagNetWt: n(l.tagNetWt) || undefined,
            ghtPct: n(l.ghtPct) || undefined,
            style: l.style || undefined,
            itemLot: l.itemLot || undefined,
            remark: l.remark || undefined,
            discountPct: n(l.discountPct) || undefined,
            discountAmount: n(l.discountAmount) || undefined,
            ghatAmount: n(l.ghatAmount) || undefined,
            rateWith: l.rateWith || undefined,
            rateType: l.rateType || undefined,
            tagCost: n(l.tagCost) || undefined,
            karigarNetWt: n(l.karigarNetWt) || undefined,
            karigarTouch: n(l.karigarTouch) || undefined,
            karigarWestPct: n(l.karigarWestPct) || undefined,
            karigarFine: n(l.karigarFine) || undefined,
            karigarName: l.karigarName || undefined,
            employeeCode: l.employeeCode || undefined,
            prCode: l.prCode || undefined,
            orderTagStockAdd: l.orderTagStockAdd || undefined,
            designImageId: l.designImageId || undefined,
            hallmarkId2: l.hallmarkId2 || undefined,
            hallmarkId3: l.hallmarkId3 || undefined,
            hallmarkId4: l.hallmarkId4 || undefined,
            hallmarkIdWt: n(l.hallmarkIdWt) || undefined,
            hallmarkId2Wt: n(l.hallmarkId2Wt) || undefined,
            hallmarkId3Wt: n(l.hallmarkId3Wt) || undefined,
            hallmarkId4Wt: n(l.hallmarkId4Wt) || undefined,
            // Ordinary sale other weight; return-only identifiers are not this writer's inputs.
            otherWt: n(l.otherWt) || undefined,
            ordNo: l.ordNo,
            ordYrcd: l.ordYrcd,
            ordDbcd: l.ordDbcd,
            ordSrno: l.ordSrno,
            isuNo: l.isuNo,
            isuYrcd: l.isuYrcd,
            isuDbcd: l.isuDbcd,
            isuSrno: l.isuSrno,
            // Desktop item-grid columns added to the detail panel; sent so they persist.
            westPct: n(l.westPct) || undefined,
            ghtWt: n(l.ghtWt) || undefined,
            fineWt: n(l.fineWt) || undefined,
            tblCode: l.tblCode || undefined,
            huid: l.huid || undefined,
            mrp: n(l.mrp) || undefined,
            metalAmount: n(l.metalAmount) || undefined,
            metal: l.metal === 'S' ? ('S' as const) : l.metal === 'G' ? ('G' as const) : undefined,
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
      };
      const saved = loadedVchNo
        ? await put<{ vchNo: number; totals: Totals; billProfit?: SaleProfit }>(
            `/sales-quotations/${encodeURIComponent(loadedVchNo)}`,
            body,
          )
        : await post<{ vchNo: number; totals: Totals; billProfit?: SaleProfit }>('/sales-quotations', body);
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
      <RateTicker />
      <PartyBalance acCode={acCode} />
      <form onSubmit={submit}>
        <VoucherChrome
          title="Sales Quotation"
          vchNo={loadedVchNo ? Number(loadedVchNo) : (result?.vchNo ?? null)}
          date={vchDate}
          onDateChange={setVchDate}
          refNo={refNo}
          onRefNoChange={setRefNo}
          saving={busy}
          onExit={() => router.back()}
          onPrint={
            loadedVchNo
              ? () =>
                  window.open(
                    `/api/sales-quotations/quotation?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(loadedVchNo)}&format=html&copy=O`,
                    '_blank',
                  )
              : undefined
          }
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
            <button type="button" className="ghost" disabled={busy} onClick={loadSale}>
              Load
            </button>
            {loadedVchNo && (
              <span className="msg ok" data-testid="sales-loaded">
                Loaded #{loadedVchNo}
              </span>
            )}
            {loadedVchNo && (
              <button type="button" className="danger" disabled={busy} onClick={removeLoadedSale}>
                Delete
              </button>
            )}
            <button type="button" className="ghost" disabled={busy} onClick={newSale}>
              New
            </button>
            <div className="field">
              <label>Book</label>
              <BookSelect value={coBook} onChange={setCoBook} preferred="099" mainBooks={['SL QUOT']} />
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
                  setAddress1(String(r.AC_ADD1 ?? ''));
                  setAddress2(String(r.AC_ADD2 ?? ''));
                  setAddress3(String(r.AC_ADD3 ?? ''));
                  setCity(String(r.AC_CITY ?? ''));
                  setMobile(String(r.AC_MOBILE ?? ''));
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

        <div className="panel">
          <h2>Settlement</h2>
          <div className="row">
            <div className="field">
              <label>Cash ₹</label>
              <input
                ref={cashRef}
                data-testid="sales-cash"
                value={cashAmt}
                onChange={(e) => setCashAmt(e.target.value)}
              />
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
              <label>Hallmark chg ₹</label>
              <input value={hmCharge} onChange={(e) => setHmCharge(e.target.value)} />
            </div>
            <div className="field">
              <label>TCS %</label>
              <input value={tcsPct} onChange={(e) => setTcsPct(e.target.value)} />
            </div>
            <div className="field">
              <label>Kasar ₹</label>
              <input value={kasar} onChange={(e) => setKasar(e.target.value)} />
            </div>
            <div className="field">
              <label>Ord No (advance)</label>
              <input
                value={ordNo}
                onChange={(e) => setOrdNo(e.target.value)}
                placeholder="sales order #"
              />
            </div>
            <div className="field">
              <label>Order Amt</label>
              <input
                value={ordAmt}
                onChange={(e) => setOrdAmt(e.target.value)}
                placeholder="advance to apply"
              />
            </div>
            <div className="field">
              <label>CR Days</label>
              <input
                value={crDays}
                onChange={(e) => setCrDays(e.target.value)}
                placeholder="credit days"
              />
            </div>
            <div className="field">
              <label>Employee</label>
              <LookupPicker entity="employees" value={empCode} onChange={setEmpCode} />
            </div>
          </div>
        </div>

        <div className="panel">
          <details>
            <summary>Desktop settlement and invoice fields</summary>
            <div className="row" style={{ marginTop: 10 }}>
              {[
                ['Discount %', discountPct, setDiscountPct],
                ['TCS Code', tcsCode, setTcsCode],
                ['TDS Code', tdsCode, setTdsCode],
                ['TDS %', tdsPct, setTdsPct],
                ['TDS Amount', tdsAmount, setTdsAmount],
                ['Cheque Bank A/c', bankAc, setBankAc],
                ['Card A/c', cardAc, setCardAc],
                ['Cheque No', chequeNo, setChequeNo],
                ['Bank Name', bankName, setBankName],
                ['Card Commission', cardCommissionAmount, setCardCommissionAmount],
                ['Cash Paid', cashPaid, setCashPaid],
                ['Current Adjustment', currentAdjustmentAmount, setCurrentAdjustmentAmount],
                ['Scheme A/c', schemeAc, setSchemeAc],
                ['Scheme Amount', schemeAmount, setSchemeAmount],
                ['Point Value', pointValue, setPointValue],
                ['Address 1', address1, setAddress1],
                ['Address 2', address2, setAddress2],
                ['Address 3', address3, setAddress3],
                ['City', city, setCity],
                ['Mobile', mobile, setMobile],
                ['Issue No', issueNo, setIssueNo],
                ['Issue Year', issueYear, setIssueYear],
                ['Issue Book', issueBook, setIssueBook],
                ['Description', description, setDescription],
              ].map(([label, value, setter]) => (
                <div className="field" key={String(label)}>
                  <label>{String(label)}</label>
                  <input
                    value={String(value)}
                    onChange={(e) => (setter as (value: string) => void)(e.target.value)}
                  />
                </div>
              ))}
              <div className="field">
                <label>Ornament Issued</label>
                <select
                  value={ornamentIssued ? 'y' : 'n'}
                  onChange={(e) => setOrnamentIssued(e.target.value === 'y')}
                >
                  <option value="y">Yes</option>
                  <option value="n">No</option>
                </select>
              </div>
            </div>
          </details>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>
            Old Gold / Silver Exchange{' '}
            <span className="muted">— metal taken in against the bill</span>
          </h2>
          <table className="grid">
            <thead>
              <tr>
                <th>Metal</th>
                <th>Item</th>
                <th className="num">Pcs</th>
                <th className="num">Gross</th>
                <th className="num">Net</th>
                <th className="num">Touch%</th>
                <th className="num">Rate</th>
                <th className="num">Amount</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {ogRows.map((o, i) => (
                <tr key={i}>
                  <td>
                    <select value={o.metal} onChange={(e) => setOg(i, 'metal', e.target.value)}>
                      <option value="G">Gold</option>
                      <option value="S">Silver</option>
                    </select>
                  </td>
                  <td>
                    <input
                      value={o.itCode}
                      maxLength={5}
                      onChange={(e) => setOg(i, 'itCode', e.target.value)}
                      style={{ width: 70 }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={o.pcs}
                      onChange={(e) => setOg(i, 'pcs', e.target.value)}
                      style={{ width: 48, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={o.grossWt}
                      onChange={(e) => setOg(i, 'grossWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={o.netWt}
                      onChange={(e) => setOg(i, 'netWt', e.target.value)}
                      style={{ width: 70, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={o.touch}
                      onChange={(e) => setOg(i, 'touch', e.target.value)}
                      style={{ width: 56, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">
                    <input
                      value={o.rate}
                      onChange={(e) => setOg(i, 'rate', e.target.value)}
                      style={{ width: 76, textAlign: 'right' }}
                    />
                  </td>
                  <td className="num">{ogAmt(o).toLocaleString('en-IN')}</td>
                  <td>
                    <button
                      type="button"
                      className="danger"
                      onClick={() => setOgRows((rs) => rs.filter((_, j) => j !== i))}
                    >
                      ×
                    </button>
                  </td>
                </tr>
              ))}
              {ogRows.length === 0 && (
                <tr>
                  <td colSpan={9} className="muted">
                    No exchange (optional).
                  </td>
                </tr>
              )}
            </tbody>
          </table>
          <div className="toolbar" style={{ marginTop: 8 }}>
            <button
              type="button"
              className="ghost"
              onClick={() => setOgRows((rs) => [...rs, ogBlank()])}
            >
              + Add exchange
            </button>
          </div>
          {ogRows.map((row, index) => (
            <details key={`old-metal-${index}`} style={{ marginTop: 8 }}>
              <summary>Exchange row {index + 1} desktop fields</summary>
              <div className="row">
                {[
                  ['Description', 'description'],
                  ['Other Wt', 'otherWt'],
                  ['Conversion %', 'conversionPct'],
                  ['Conversion Wt', 'conversionWt'],
                  ['Rate Type', 'rateType'],
                ].map(([label, key]) => (
                  <div className="field" key={key}>
                    <label>{label}</label>
                    <input
                      value={String(row[key as keyof OgRow])}
                      onChange={(e) => setOg(index, key as keyof OgRow, e.target.value)}
                    />
                  </div>
                ))}
              </div>
            </details>
          ))}
        </div>

        <div className="panel">
          <h2>Totals</h2>
          <div className="tiles">
            {[
              ['Net', lineNet],
              ['Discount', n(discountAmount)],
              ['Taxable', taxable],
              [`Tax ${taxRatePct}%`, taxPrev],
              ['Hallmark', hmAmt + hmTax],
              ['TCS', tcsAmt],
              ['Total', totalPrev],
              ['Cash', n(cashAmt)],
              ['Card', n(cardAmt)],
              ['UPI', n(upiAmt)],
              ['Cheque', n(chequeAmt)],
              ['Old Gold/Silver', oldGoldVal],
              ['Kasar', kasarAmt],
              ['Balance Due', balanceDue],
            ].map(([k, v]) => (
              <div className="tile" key={String(k)}>
                <div className="muted">{k}</div>
                <div
                  className="big kpi"
                  style={
                    k === 'Balance Due'
                      ? { color: Number(v) > 0 ? 'var(--err)' : 'var(--ok)' }
                      : undefined
                  }
                >
                  {Number(v).toLocaleString('en-IN')}
                </div>
              </div>
            ))}
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
              testId="sales-grid-mode"
            />
          </div>
          <table className="grid">
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
                <th>Design</th>
                <th>Size</th>
                <th className="num">Ls Wt</th>
                <th className="num">Lbr%</th>
                <th className="num">Oth Amt</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedLineFields} />
                {/* P5: derived roll-ups the desktop recomputes on every cell exit
                    (TR_SALE.cs:9400-9522). Read-only by nature: they are results, not entry cells. */}
                <th className="num">Fine</th>
                <th className="num">Total</th>
                <th className="num">Fine</th>
                <th className="num">Amount</th>
                <th></th>
              </tr>
            </thead>
            <tbody data-testid="sales-items-grid" onKeyDown={handleItemGridKey}>
              {lines.map((l, i) => {
                const c = calc(l);
                return (
                  <tr key={i}>
                    <td {...gridCell(i, 0)}>
                      <LookupPicker
                        entity="items"
                        value={l.itCode}
                        onChange={(v) => setLine(i, 'itCode', v)}
                        style={{ width: 80 }}
                      />
                    </td>
                    <td {...gridCell(i, 1)}>
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
                    <td className="num" {...gridCell(i, 2)}>
                      <input
                        style={{ width: 44, textAlign: 'right' }}
                        value={l.pcs}
                        onChange={(e) => setLine(i, 'pcs', e.target.value)}
                      />
                    </td>
                    <td className="num" {...gridCell(i, 3)}>
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.grossWt}
                        onChange={(e) => setLine(i, 'grossWt', e.target.value)}
                      />
                    </td>
                    <td className="num" {...gridCell(i, 4)}>
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.netWt}
                        onChange={(e) => setLine(i, 'netWt', e.target.value)}
                        readOnly={netWeightLocked}
                        aria-readonly={netWeightLocked}
                        title={
                          netWeightLocked
                            ? 'Net weight is locked by company setting SL_NWT_LOCK'
                            : undefined
                        }
                      />
                    </td>
                    <td className="num" {...gridCell(i, 5)}>
                      <input
                        style={{ width: 56, textAlign: 'right' }}
                        value={l.touch}
                        onChange={(e) => setLine(i, 'touch', e.target.value)}
                      />
                    </td>
                    <td className="num" {...gridCell(i, 6)}>
                      <input
                        style={{ width: 72, textAlign: 'right' }}
                        value={l.rate}
                        onChange={(e) => setLine(i, 'rate', e.target.value)}
                      />
                    </td>
                    <td className="num" {...gridCell(i, 7)}>
                      <input
                        style={{ width: 64, textAlign: 'right' }}
                        value={l.making}
                        onChange={(e) => setLine(i, 'making', e.target.value)}
                      />
                    </td>
                    <td {...gridCell(i, 8)}>
                      <input
                        value={l.designNo}
                        onChange={(e) => setLine(i, 'designNo', e.target.value)}
                        style={{ width: 60 }}
                      />
                    </td>
                    <td {...gridCell(i, 9)}>
                      <input
                        value={l.itmSize}
                        onChange={(e) => setLine(i, 'itmSize', e.target.value)}
                        style={{ width: 44 }}
                      />
                    </td>
                    <td className="num" {...gridCell(i, 10)}>
                      <input
                        style={{ width: 50, textAlign: 'right' }}
                        value={l.lessWt}
                        onChange={(e) => setLine(i, 'lessWt', e.target.value)}
                      />
                    </td>
                    <td className="num" {...gridCell(i, 11)}>
                      <input
                        style={{ width: 44, textAlign: 'right' }}
                        value={l.lbrPct}
                        onChange={(e) => setLine(i, 'lbrPct', e.target.value)}
                      />
                    </td>
                    <td className="num" {...gridCell(i, 12)}>
                      <input
                        style={{ width: 56, textAlign: 'right' }}
                        value={l.othAmt}
                        onChange={(e) => setLine(i, 'othAmt', e.target.value)}
                      />
                    </td>
                    <ExtendedBodyCells
                      full={fullGrid}
                      fields={extendedLineFields}
                      line={l}
                      row={i}
                      baseColumns={baseItemColumns}
                      setValue={(row, key, value) => setLine(row, key, value)}
                      cellProps={gridCell}
                    />
                    <td className="num">{c.fine.toLocaleString('en-IN')}</td>
                    <td className="num">{c.net.toLocaleString('en-IN')}</td>
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
          <details style={{ marginTop: 8 }}>
            <summary>Desktop posting accounts and flags</summary>
            <div className="row">
              {extendedHeaderFields.map(([key, label]) => (
                <div className="field" key={key}>
                  <label>{label}</label>
                  <input
                    value={headerExtra[key] ?? ''}
                    onChange={(e) => setHeaderExtra((h) => ({ ...h, [key]: e.target.value }))}
                  />
                </div>
              ))}
            </div>
          </details>
          {!fullGrid &&
            lines.map((line, index) => (
              <details key={`line-extra-${index}`} style={{ marginTop: 8 }}>
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
              {busy ? 'Saving…' : loadedVchNo ? 'Update Quotation' : 'Save Quotation'}
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
                  `/api/sales-quotations/quotation?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(result.vchNo))}`,
                  '_blank',
                )
              }
            >
              View Quotation PDF
            </button>
            <button
              type="button"
              className="ghost"
              onClick={() =>
                window.open(
                  `/api/sales-quotations/quotation?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(String(result.vchNo))}&format=html`,
                  '_blank',
                )
              }
            >
              View Quotation HTML
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
          {result.billProfit && (
            <div className="tiles">
              <div className="tile" data-testid="sales-bill-profit">
                <div className="muted">Bill profit</div>
                <div className="big kpi">
                  {result.billProfit.total.toLocaleString('en-IN', {
                    minimumFractionDigits: 2,
                  })}
                </div>
                {/* A line whose cost basis is unknown contributes nothing, so it is called out rather than
                    quietly counted as pure margin. */}
                {result.billProfit.lines.some((l) => l.basis === 'none') && (
                  <div className="muted">
                    {result.billProfit.lines.filter((l) => l.basis === 'none').length} line(s) have
                    no cost basis and are excluded
                  </div>
                )}
              </div>
            </div>
          )}
        </div>
      )}
      <VoucherList
        table="SL_DATA"
        book={coBook}
        deleteBase="/sales-quotations"
        printHref={(v) =>
          `/api/sales-quotations/quotation?coBook=${encodeURIComponent(coBook)}&coYear=${encodeURIComponent(coYear)}&vchNo=${encodeURIComponent(v)}&format=html&copy=O`
        }
        reloadKey={result?.vchNo}
      />
    </div>
  );
}
