'use client';
import { useState } from 'react';
import { ApiError, del, get, post, put } from '../../../../lib/api';
import { useBusinessScope } from '../../../../components/BusinessScope';
import { BookSelect } from '../../../../components/BookSelect';
import { LookupPicker, type LookupRow } from '../../../../components/LookupPicker';
import { useGridKeyboard } from '../../../../components/GridKeyboard';
import {
  ExtendedBodyCells,
  ExtendedHeaderCells,
  extendedGridColumnCount,
  GridModeToggle,
} from '../../../../components/ExtendedGrid';

// BULLION SALE (desktop book 064, VCH_TYPE RCUT): "cut the rate" = fix the price on metal previously
// sold/issued unfixed. Books the fixed metal value (fine × rate), moves the fine on the customer's
// gold position, and settles in cash / kasar. The API recomputes the figures authoritatively; the
// previews below mirror the spec §2 formulas for the operator.

type RateType = 'G' | '1' | 'K' | 'P';

interface Line {
  itCode: string;
  itemName: string;
  tagNo: string;
  designNo: string;
  lotNo: string;
  itemLot: string;
  pcs: string;
  grossWt: string;
  othWt: string;
  netWt: string;
  ghtPct: string;
  lessWt: string;
  touch: string;
  west: string;
  lessTouch: string;
  rate: string;
  rateType: RateType;
  lbrType: string;
  lbrRate: string;
  lbrAmt: string;
  othAmt: string;
  otherRate: string;
  otherFine: string;
  mrp: string;
  taxPct: string;
  tagCost: string;
  tagGrossWt: string;
  tagNetWt: string;
  lineConvRate: string;
  lineConvPct: string;
  prCode: string;
  bookingLookup: string;
  // P3: accepted by RateCutLine and previously unreachable. mcxRate and hallmarkFine are the
  // bullion-desk quote inputs the desktop keeps as separate columns from the final rate
  // (TR_BUL_SALE.cs:5716-5887 MSG columns McxRate / Premium / HmFine); adjustWt links the line to
  // the booking weight it draws down; silverFine posts the silver leg.
  mcxRate: string;
  hallmarkFine: string;
  adjustWt: string;
  silverFine: string;
  issueLcCode: string;
  issueYear: string;
  issueBook: string;
  issueNo: string;
  issueSrno: string;
}

type ViewRow = Record<string, unknown>;

interface BullionSaleView {
  voucherNo: string | number;
  vchDate?: unknown;
  acCode?: unknown;
  acName?: unknown;
  itType?: unknown;
  fineRate?: unknown;
  convRate?: unknown;
  convPct?: unknown;
  add1?: unknown;
  add2?: unknown;
  add3?: unknown;
  city?: unknown;
  mobile?: unknown;
  bankName?: unknown;
  settleDrAmt?: unknown;
  settleCrAmt?: unknown;
  settleDrFine?: unknown;
  settleCrFine?: unknown;
  pay?: ViewRow;
  receivedPay?: ViewRow;
  lines?: ViewRow[];
  receivedLines?: ViewRow[];
}

interface BullionSaleResult {
  vchNo: number;
  fine: number;
  netAmt: number;
}

type DisplayResult = BullionSaleResult & { updated: boolean };

const blankLine = (): Line => ({
  itCode: '',
  itemName: '',
  tagNo: '',
  designNo: '',
  lotNo: '',
  itemLot: '',
  pcs: '',
  grossWt: '',
  othWt: '',
  netWt: '',
  ghtPct: '',
  lessWt: '',
  touch: '',
  west: '',
  lessTouch: '',
  rate: '',
  rateType: 'G',
  lbrType: '',
  lbrRate: '',
  lbrAmt: '',
  othAmt: '',
  otherRate: '',
  otherFine: '',
  mrp: '',
  taxPct: '',
  tagCost: '',
  tagGrossWt: '',
  tagNetWt: '',
  lineConvRate: '',
  lineConvPct: '',
  prCode: '',
  bookingLookup: '',
  mcxRate: '',
  hallmarkFine: '',
  adjustWt: '',
  silverFine: '',
  issueLcCode: '',
  issueYear: '',
  issueBook: '',
  issueNo: '',
  issueSrno: '',
});

const n = (v: string) => Number(v || 0);
const round3 = (x: number) => Math.round((x + 1e-9) * 1000) / 1000;
const round0 = (x: number) => Math.round(x + 1e-9);
const inr = (x: number) => round0(x).toLocaleString('en-IN');
const inputValue = (value: unknown): string => (value == null ? '' : String(value));
const viewRow = (value: unknown): ViewRow =>
  value != null && typeof value === 'object' ? (value as ViewRow) : {};

function lineFromView(row: ViewRow): Line {
  const ref = viewRow(row.isuRef);
  const rateType = inputValue(row.rateType);
  const netWt = Number(row.netWt ?? 0);
  const tagNo = inputValue(row.tagNo);
  return {
    ...blankLine(),
    itCode: inputValue(row.itCode),
    itemName: inputValue(row.itemName),
    tagNo: tagNo.toUpperCase() === 'N' ? '' : tagNo,
    designNo: inputValue(row.designNo),
    lotNo: inputValue(row.lotNo),
    itemLot: inputValue(row.itemLot),
    pcs: inputValue(row.pcs),
    grossWt: inputValue(row.grossWt),
    othWt: inputValue(row.othWt),
    netWt: inputValue(row.netWt),
    // The reader returns persisted ghat weight; this bullion grid edits and sends its percentage.
    ghtPct: row.ghtWt == null || netWt === 0 ? '' : inputValue((Number(row.ghtWt) * 100) / netWt),
    lessWt: inputValue(row.lessWt),
    touch: inputValue(row.touch),
    west: inputValue(row.westPct),
    lessTouch: inputValue(row.lessTouch),
    rate: inputValue(row.rate),
    rateType: ['G', '1', 'K', 'P'].includes(rateType) ? (rateType as RateType) : 'G',
    lbrType: inputValue(row.lbrType),
    lbrRate: inputValue(row.lbrRate),
    lbrAmt: inputValue(row.lbrAmt),
    othAmt: inputValue(row.othAmt),
    otherRate: inputValue(row.otherRate),
    otherFine: inputValue(row.otherFine),
    mrp: inputValue(row.mrp),
    taxPct: inputValue(row.taxPct),
    tagCost: inputValue(row.tagCost),
    tagGrossWt: inputValue(row.tagGrossWt),
    tagNetWt: inputValue(row.tagNetWt),
    lineConvRate: inputValue(row.convRate),
    lineConvPct: inputValue(row.convPct),
    prCode: inputValue(row.prCode),
    bookingLookup: inputValue(ref.no),
    mcxRate: inputValue(row.mcxRate),
    hallmarkFine: inputValue(row.hallmarkFine),
    adjustWt: inputValue(row.adjustWt),
    silverFine: inputValue(row.silverFine),
    issueLcCode: inputValue(row.issueLcCode),
    issueYear: inputValue(ref.yrcd),
    issueBook: inputValue(ref.dbcd),
    issueNo: inputValue(ref.no),
    issueSrno: inputValue(ref.srno),
  };
}

function lineNetWt(l: Line): number {
  return l.netWt.trim() ? round3(n(l.netWt)) : round3(n(l.grossWt) - n(l.othWt));
}

function lineGhtWt(l: Line): number {
  return round3((lineNetWt(l) * n(l.ghtPct)) / 100);
}

// spec §2 fine: (net + ght) × (touch + west)/100; touch+west=0 ⇒ net + ght.
function lineFine(l: Line): number {
  const base = lineNetWt(l) + lineGhtWt(l);
  const pct = n(l.touch) + n(l.west);
  return round3(pct === 0 ? base : (base * pct) / 100);
}

function lineItemAmt(l: Line): number {
  const f = lineFine(l);
  const rate = n(l.rate);
  switch (l.rateType) {
    case '1':
      return round0((f * rate) / 10);
    case 'K':
      return round0((f * rate) / 1000);
    case 'P':
      return round0(n(l.pcs) * rate);
    default:
      return round0(f * rate);
  }
}

function lineAmt(l: Line): number {
  const total =
    n(l.mrp) > 0 ? n(l.mrp) : lineItemAmt(l) + round0(n(l.lbrAmt)) + round0(n(l.othAmt));
  return n(l.taxPct) === 0 ? round0(total) : round0((total / (n(l.taxPct) + 100)) * 100);
}

/**
 * RateCutLine fields the server accepted that no screen could send (parity plan P3).
 *
 * The desktop keeps the bullion quote inputs as separate columns from the settled rate — MSG
 * columns McxRate, Premium and HmFine (TR_BUL_SALE.cs:5716-5887) — because a cut is quoted off the
 * MCX rate plus a premium, and the hallmark fine is accounted separately. AdjWt is the weight this
 * line draws down from a booking, which is what BUL_DATA.ADJ_WT now consumes.
 */
const extendedRateCutFields: Array<[keyof Line, string]> = [
  ['itemName', 'ItemName'],
  ['designNo', 'Design'],
  ['lotNo', 'LotNo'],
  ['itemLot', 'ItemLot'],
  ['pcs', 'Pcs'],
  ['grossWt', 'GrossWt'],
  ['othWt', 'OthWt'],
  ['ghtPct', 'Ght%'],
  ['lessWt', 'LessWt'],
  ['lessTouch', 'LessTouch'],
  ['lbrType', 'LbrType'],
  ['lbrRate', 'LbrRate'],
  ['lbrAmt', 'LbrAmt'],
  ['othAmt', 'OthAmt'],
  ['otherRate', 'OthRate'],
  ['otherFine', 'OthFine'],
  ['mrp', 'MRP'],
  ['taxPct', 'Tax%'],
  ['tagCost', 'TagCost'],
  ['tagGrossWt', 'TagGwt'],
  ['tagNetWt', 'TagNwt'],
  ['lineConvRate', 'LineConvRate'],
  ['lineConvPct', 'LineConv%'],
  ['prCode', 'PrCode'],
  ['mcxRate', 'McxRate'],
  ['hallmarkFine', 'HmFine'],
  ['adjustWt', 'AdjWt'],
  ['silverFine', 'SlvFine'],
  ['issueLcCode', 'IsuLc'],
  ['issueYear', 'IsuYear'],
  ['issueBook', 'IsuBook'],
  ['issueNo', 'IsuNo'],
  ['issueSrno', 'IsuSr'],
];

export default function BullionSalePage() {
  const { lcCode, coYear } = useBusinessScope();
  const [coBook, setCoBook] = useState('');
  const [vchDate, setVchDate] = useState('');
  const [voucherSearch, setVoucherSearch] = useState('');
  const [loadedVoucherNo, setLoadedVoucherNo] = useState('');
  const [fineRate, setFineRate] = useState('');
  const [convRate, setConvRate] = useState('');
  const [convPct, setConvPct] = useState('');
  const [acCode, setAcCode] = useState('');
  const [acName, setAcName] = useState('');
  const [itType, setItType] = useState<'G' | 'S'>('G');
  const [lines, setLines] = useState<Line[]>([blankLine()]);
  const [receivedLines, setReceivedLines] = useState<Line[]>([blankLine()]);
  const [fullGrid, setFullGrid] = useState(false);
  // Desktop grids are keyboard-driven: arrows move between cells, Enter advances and
  // appends a row at the end, Ctrl/Cmd+D removes one (TR_SALE.cs:12250-12320).
  const handleGridKey = useGridKeyboard({
    rowCount: lines.length,
    columnCount: extendedGridColumnCount(fullGrid, 9, extendedRateCutFields.length),
    onAppendRow: () => setLines((rows) => [...rows, blankLine()]),
    onRemoveRow: (row) => {
      setLines((rows) =>
        rows.length === 1 ? [blankLine()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const handleReceivedGridKey = useGridKeyboard({
    rowCount: receivedLines.length,
    columnCount: extendedGridColumnCount(fullGrid, 9, extendedRateCutFields.length),
    onAppendRow: () => setReceivedLines((rows) => [...rows, blankLine()]),
    onRemoveRow: (row) => {
      setReceivedLines((rows) =>
        rows.length === 1 ? [blankLine()] : rows.filter((_, index) => index !== row),
      );
      return true;
    },
    onEscape: () => {},
  });
  const [cash, setCash] = useState('');
  const [chq, setChq] = useState('');
  const [card, setCard] = useState('');
  const [kasar, setKasar] = useState('');
  const [billOs, setBillOs] = useState('');
  const [bankAc, setBankAc] = useState('');
  const [chqNo, setChqNo] = useState('');
  const [cardAc, setCardAc] = useState('');
  const [receivedCash, setReceivedCash] = useState('');
  const [receivedChq, setReceivedChq] = useState('');
  const [receivedCard, setReceivedCard] = useState('');
  const [receivedKasar, setReceivedKasar] = useState('');
  const [receivedBillOs, setReceivedBillOs] = useState('');
  const [receivedBankAc, setReceivedBankAc] = useState('');
  const [receivedChqNo, setReceivedChqNo] = useState('');
  const [receivedCardAc, setReceivedCardAc] = useState('');
  // P3: party address and the two-sided money/metal settlement the desktop's MSG2_TOTAL band
  // carries (TR_BUL_SALE.cs:9889, columns 3/4 are explicitly Payment and Received, :9981-9992).
  const [add1, setAdd1] = useState('');
  const [add2, setAdd2] = useState('');
  const [add3, setAdd3] = useState('');
  const [city, setCity] = useState('');
  const [mobile, setMobile] = useState('');
  const [bankName, setBankName] = useState('');
  const [settleDrAmt, setSettleDrAmt] = useState('');
  const [settleCrAmt, setSettleCrAmt] = useState('');
  const [settleDrFine, setSettleDrFine] = useState('');
  const [settleCrFine, setSettleCrFine] = useState('');
  const [result, setResult] = useState<DisplayResult | null>(null);
  const [err, setErr] = useState('');
  const [busy, setBusy] = useState(false);

  const setRow = (i: number, k: keyof Line, v: string) =>
    setLines((ls) => ls.map((l, j) => (j === i ? { ...l, [k]: v } : l)));
  const setReceivedRow = (i: number, k: keyof Line, v: string) =>
    setReceivedLines((rows) => rows.map((line, j) => (j === i ? { ...line, [k]: v } : line)));
  const bookingParams = new URLSearchParams({ itType });
  if (acCode.trim()) bookingParams.set('acCode', acCode.trim());
  const bookingSearchPath = `/lookup/bullion-bookings?${bookingParams.toString()}`;
  const bookingPatch = (line: Line, row: LookupRow): Line => ({
    ...line,
    bookingLookup: String(row.code ?? ''),
    issueLcCode: String(row.issueLcCode ?? row.LC_CODE ?? lcCode),
    issueYear: String(row.issueYear ?? row.CO_YEAR ?? ''),
    issueBook: String(row.issueBook ?? row.CO_BOOK ?? ''),
    issueNo: String(row.issueNo ?? row.VCH_NO ?? ''),
    issueSrno: String(row.issueSrno ?? row.SR_NO ?? ''),
    itCode: line.itCode || String(row.IT_CODE ?? ''),
    rate: line.rate || String(row.ITM_RATE ?? ''),
    mcxRate: line.mcxRate || String(row.MCX_RATE ?? ''),
  });
  const pickBooking = (i: number, row: LookupRow) =>
    setLines((rows) => rows.map((line, j) => (j === i ? bookingPatch(line, row) : line)));
  const pickReceivedBooking = (i: number, row: LookupRow) =>
    setReceivedLines((rows) => rows.map((line, j) => (j === i ? bookingPatch(line, row) : line)));
  const addRow = () => setLines((ls) => [...ls, blankLine()]);
  const addReceivedRow = () => setReceivedLines((rows) => [...rows, blankLine()]);
  const removeRow = (i: number) =>
    setLines((ls) => (ls.length > 1 ? ls.filter((_, j) => j !== i) : ls));
  const removeReceivedRow = (i: number) =>
    setReceivedLines((rows) => (rows.length > 1 ? rows.filter((_, j) => j !== i) : rows));

  const activeRows = (rows: Line[]) =>
    rows.filter(
      (l) =>
        lineNetWt(l) > 0 ||
        n(l.rate) > 0 ||
        n(l.pcs) > 0 ||
        l.itCode.trim() ||
        l.itemName.trim() ||
        l.tagNo.trim() ||
        l.designNo.trim() ||
        l.lotNo.trim() ||
        l.itemLot.trim() ||
        l.issueNo.trim(),
    );
  const linePayload = (l: Line) => ({
    itCode: l.itCode.trim() || undefined,
    itemName: l.itemName.trim() || undefined,
    tagNo: l.tagNo.trim() || undefined,
    designNo: l.designNo.trim() || undefined,
    lotNo: l.lotNo.trim() || undefined,
    itemLot: l.itemLot.trim() || undefined,
    pcs: l.pcs.trim() ? n(l.pcs) : undefined,
    grossWt: l.grossWt.trim() ? n(l.grossWt) : undefined,
    othWt: l.othWt.trim() ? n(l.othWt) : undefined,
    netWt: l.netWt.trim() ? n(l.netWt) : undefined,
    ghtPct: l.ghtPct.trim() ? n(l.ghtPct) : undefined,
    lessWt: l.lessWt.trim() ? n(l.lessWt) : undefined,
    touch: n(l.touch),
    westPct: n(l.west),
    lessTouch: l.lessTouch.trim() ? n(l.lessTouch) : undefined,
    rate: n(l.rate),
    rateType: l.rateType,
    itType,
    lbrType: l.lbrType.trim() || undefined,
    lbrRate: l.lbrRate.trim() ? n(l.lbrRate) : undefined,
    lbrAmt: l.lbrAmt.trim() ? n(l.lbrAmt) : undefined,
    othAmt: l.othAmt.trim() ? n(l.othAmt) : undefined,
    otherRate: l.otherRate.trim() ? n(l.otherRate) : undefined,
    otherFine: l.otherFine.trim() ? n(l.otherFine) : undefined,
    mrp: l.mrp.trim() ? n(l.mrp) : undefined,
    taxPct: l.taxPct.trim() ? n(l.taxPct) : undefined,
    tagCost: l.tagCost.trim() ? n(l.tagCost) : undefined,
    tagGrossWt: l.tagGrossWt.trim() ? n(l.tagGrossWt) : undefined,
    tagNetWt: l.tagNetWt.trim() ? n(l.tagNetWt) : undefined,
    convRate: l.lineConvRate.trim() ? n(l.lineConvRate) : undefined,
    convPct: l.lineConvPct.trim() ? n(l.lineConvPct) : undefined,
    prCode: l.prCode.trim() || undefined,
    mcxRate: l.mcxRate.trim() ? n(l.mcxRate) : undefined,
    hallmarkFine: l.hallmarkFine.trim() ? n(l.hallmarkFine) : undefined,
    adjustWt: l.adjustWt.trim() ? n(l.adjustWt) : undefined,
    silverFine: l.silverFine.trim() ? n(l.silverFine) : undefined,
    issueLcCode: l.issueLcCode.trim() || undefined,
    isuRef:
      l.issueYear.trim() || l.issueBook.trim() || l.issueNo.trim() || l.issueSrno.trim()
        ? {
            yrcd: l.issueYear.trim() || undefined,
            dbcd: l.issueBook.trim() || undefined,
            no: l.issueNo.trim() || undefined,
            srno: l.issueSrno.trim() ? n(l.issueSrno) : undefined,
          }
        : undefined,
  });

  const totalFine = round3(lines.reduce((s, l) => s + lineFine(l), 0));
  const totalAmt = round0(lines.reduce((s, l) => s + lineAmt(l), 0));
  const receivedTotalFine = round3(receivedLines.reduce((s, l) => s + lineFine(l), 0));
  const receivedTotalAmt = round0(receivedLines.reduce((s, l) => s + lineAmt(l), 0));
  const issueSettlementTotal = round0(n(cash) + n(chq) + n(card) + n(kasar) + n(billOs));
  const receivedSettlementTotal = round0(
    n(receivedCash) + n(receivedChq) + n(receivedCard) + n(receivedKasar) + n(receivedBillOs),
  );
  const hasLine = activeRows(lines).length > 0;
  const hasReceivedLine = activeRows(receivedLines).length > 0;
  const canSubmit =
    !!acCode &&
    (hasLine || hasReceivedLine) &&
    (totalFine > 0 || totalAmt > 0 || receivedTotalFine > 0 || receivedTotalAmt > 0);

  function reset() {
    setVchDate('');
    setVoucherSearch('');
    setLoadedVoucherNo('');
    setFineRate('');
    setConvRate('');
    setConvPct('');
    setAcCode('');
    setAcName('');
    setItType('G');
    setLines([blankLine()]);
    setReceivedLines([blankLine()]);
    setCash('');
    setChq('');
    setCard('');
    setKasar('');
    setBillOs('');
    setBankAc('');
    setChqNo('');
    setCardAc('');
    setReceivedCash('');
    setReceivedChq('');
    setReceivedCard('');
    setReceivedKasar('');
    setReceivedBillOs('');
    setReceivedBankAc('');
    setReceivedChqNo('');
    setReceivedCardAc('');
    setAdd1('');
    setAdd2('');
    setAdd3('');
    setCity('');
    setMobile('');
    setBankName('');
    setSettleDrAmt('');
    setSettleCrAmt('');
    setSettleDrFine('');
    setSettleCrFine('');
    setResult(null);
    setErr('');
  }

  function payload() {
    return {
      coBook,
      coYear,
      lcCode,
      vchDate: vchDate || undefined,
      acCode,
      acName,
      itType,
      fineRate: fineRate.trim() ? n(fineRate) : undefined,
      convRate: convRate.trim() ? n(convRate) : undefined,
      convPct: convPct.trim() ? n(convPct) : undefined,
      lines: activeRows(lines).map(linePayload),
      receivedLines: activeRows(receivedLines).map(linePayload),
      pay: {
        cash: n(cash) || undefined,
        chq: n(chq) || undefined,
        card: n(card) || undefined,
        kasar: n(kasar) || undefined,
        billOs: n(billOs) || undefined,
        bankAc: bankAc.trim() || undefined,
        chqNo: chqNo.trim() || undefined,
        cardAc: cardAc.trim() || undefined,
      },
      receivedPay: {
        cash: n(receivedCash) || undefined,
        chq: n(receivedChq) || undefined,
        card: n(receivedCard) || undefined,
        kasar: n(receivedKasar) || undefined,
        billOs: n(receivedBillOs) || undefined,
        bankAc: receivedBankAc.trim() || undefined,
        chqNo: receivedChqNo.trim() || undefined,
        cardAc: receivedCardAc.trim() || undefined,
      },
      add1: add1.trim() || undefined,
      add2: add2.trim() || undefined,
      add3: add3.trim() || undefined,
      city: city.trim() || undefined,
      mobile: mobile.trim() || undefined,
      bankName: bankName.trim() || undefined,
      settleDrAmt: settleDrAmt.trim() ? n(settleDrAmt) : undefined,
      settleCrAmt: settleCrAmt.trim() ? n(settleCrAmt) : undefined,
      settleDrFine: settleDrFine.trim() ? n(settleDrFine) : undefined,
      settleCrFine: settleCrFine.trim() ? n(settleCrFine) : undefined,
    };
  }

  async function submit(e: React.FormEvent) {
    e.preventDefault();
    setErr('');
    setResult(null);
    setBusy(true);
    try {
      const updated = Boolean(loadedVoucherNo);
      const saved = updated
        ? await put<BullionSaleResult>(
            `/bullion-sales/${encodeURIComponent(loadedVoucherNo)}`,
            payload(),
          )
        : await post<BullionSaleResult>('/bullion-sales', payload());
      const voucherNo = String(saved.vchNo);
      setResult({ ...saved, updated });
      setLoadedVoucherNo(voucherNo);
      setVoucherSearch(voucherNo);
    } catch (e) {
      setErr(e instanceof ApiError ? e.body?.message || e.body?.error || e.message : 'failed');
    } finally {
      setBusy(false);
    }
  }

  async function loadVoucher() {
    const requested = voucherSearch.trim();
    if (!coBook || !requested) {
      setErr('Select a book and enter a voucher.');
      return;
    }
    setBusy(true);
    setErr('');
    setResult(null);
    try {
      const view = await get<BullionSaleView>(
        `/bullion-sales/${encodeURIComponent(requested)}?coBook=${encodeURIComponent(coBook)}`,
      );
      const pay = view.pay ?? {};
      const receivedPay = view.receivedPay ?? {};
      const issueLines = (view.lines ?? []).map(lineFromView);
      const receiptLines = (view.receivedLines ?? []).map(lineFromView);
      const voucherNo = inputValue(view.voucherNo);
      setVchDate(inputValue(view.vchDate).slice(0, 10));
      setAcCode(inputValue(view.acCode));
      setAcName(inputValue(view.acName));
      setItType(view.itType === 'S' ? 'S' : 'G');
      setFineRate(inputValue(view.fineRate));
      setConvRate(inputValue(view.convRate));
      setConvPct(inputValue(view.convPct));
      setAdd1(inputValue(view.add1));
      setAdd2(inputValue(view.add2));
      setAdd3(inputValue(view.add3));
      setCity(inputValue(view.city));
      setMobile(inputValue(view.mobile));
      setBankName(inputValue(view.bankName));
      setSettleDrAmt(inputValue(view.settleDrAmt));
      setSettleCrAmt(inputValue(view.settleCrAmt));
      setSettleDrFine(inputValue(view.settleDrFine));
      setSettleCrFine(inputValue(view.settleCrFine));
      setCash(inputValue(pay.cash));
      setChq(inputValue(pay.chq));
      setCard(inputValue(pay.card));
      setKasar(inputValue(pay.kasar));
      setBillOs(inputValue(pay.billOs));
      setBankAc(inputValue(pay.bankAc));
      setChqNo(inputValue(pay.chqNo));
      setCardAc(inputValue(pay.cardAc));
      setReceivedCash(inputValue(receivedPay.cash));
      setReceivedChq(inputValue(receivedPay.chq));
      setReceivedCard(inputValue(receivedPay.card));
      setReceivedKasar(inputValue(receivedPay.kasar));
      setReceivedBillOs(inputValue(receivedPay.billOs));
      setReceivedBankAc(inputValue(receivedPay.bankAc));
      setReceivedChqNo(inputValue(receivedPay.chqNo));
      setReceivedCardAc(inputValue(receivedPay.cardAc));
      setLines(issueLines.length ? issueLines : [blankLine()]);
      setReceivedLines(receiptLines.length ? receiptLines : [blankLine()]);
      setLoadedVoucherNo(voucherNo);
      setVoucherSearch(voucherNo);
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || e.message
          : 'bullion sale load failed',
      );
    } finally {
      setBusy(false);
    }
  }

  async function remove() {
    if (!loadedVoucherNo || !window.confirm(`Delete bullion sale voucher ${loadedVoucherNo}?`)) {
      return;
    }
    setBusy(true);
    setErr('');
    try {
      await del(`/bullion-sales/${encodeURIComponent(loadedVoucherNo)}`, {
        coBook,
        coYear,
        lcCode,
        book: coBook,
      });
      reset();
    } catch (e) {
      setErr(
        e instanceof ApiError
          ? e.body?.message || e.body?.error || e.message
          : 'bullion sale delete failed',
      );
    } finally {
      setBusy(false);
    }
  }

  return (
    <div>
      <h1>Bullion Sale — Settlement Against Booking</h1>
      <form onSubmit={submit}>
        <div className="panel">
          <div className="row">
            <div className="field">
              <label>Book</label>
              <BookSelect
                value={coBook}
                onChange={setCoBook}
                mainBooks={['BUL WH SALE', 'BUL SALE']}
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
              <label>Date</label>
              <input type="date" value={vchDate} onChange={(e) => setVchDate(e.target.value)} />
            </div>
            <div className="field">
              <label>Voucher no.</label>
              <div className="row" style={{ gap: 6 }}>
                <input
                  aria-label="Voucher no."
                  value={voucherSearch}
                  onChange={(e) => setVoucherSearch(e.target.value)}
                />
                <button type="button" onClick={loadVoucher} disabled={busy}>
                  Load
                </button>
              </div>
            </div>
            <div className="field">
              <label>Fine Rate</label>
              <input
                value={fineRate}
                inputMode="decimal"
                onChange={(e) => setFineRate(e.target.value)}
                placeholder="header rate"
              />
            </div>
            <div className="field">
              <label>Conv Rate</label>
              <input
                value={convRate}
                inputMode="decimal"
                onChange={(e) => setConvRate(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Conv %</label>
              <input
                value={convPct}
                inputMode="decimal"
                onChange={(e) => setConvPct(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field" style={{ flex: 2 }}>
              <label>Party</label>
              <LookupPicker
                entity="accounts"
                value={acCode}
                onChange={setAcCode}
                onPick={(r) => {
                  setAcCode(String(r.code));
                  setAcName(String(r.name || ''));
                }}
                placeholder="search accounts…"
              />
              {acName && (
                <span className="muted" style={{ fontSize: 12 }}>
                  {acName}
                </span>
              )}
            </div>
            <div className="field">
              <label>Metal</label>
              <select value={itType} onChange={(e) => setItType(e.target.value as 'G' | 'S')}>
                <option value="G">Gold</option>
                <option value="S">Silver</option>
              </select>
            </div>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Issue / sale lines</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedRateCutFields.length}
            testId="bullion-sale-grid-mode"
          />
          <table className="grid" onKeyDown={handleGridKey}>
            <thead>
              <tr>
                <th>#</th>
                <th>Item</th>
                <th>Tag</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch %</th>
                <th className="num">West %</th>
                <th className="num">Rate</th>
                <th>Rate Type</th>
                <th>Booking</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedRateCutFields} />
                <th className="num">Fine</th>
                <th className="num">Net Amt</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {lines.map((l, i) => (
                <tr key={i}>
                  <td>{i + 1}</td>
                  <td>
                    <input
                      style={{ width: 90 }}
                      value={l.itCode}
                      onChange={(e) => setRow(i, 'itCode', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      style={{ width: 80 }}
                      value={l.tagNo}
                      onChange={(e) => setRow(i, 'tagNo', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 90, textAlign: 'right' }}
                      value={l.netWt}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'netWt', e.target.value)}
                      placeholder="0.000"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 70, textAlign: 'right' }}
                      value={l.touch}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'touch', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 70, textAlign: 'right' }}
                      value={l.west}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'west', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 90, textAlign: 'right' }}
                      value={l.rate}
                      inputMode="decimal"
                      onChange={(e) => setRow(i, 'rate', e.target.value)}
                      placeholder="0"
                    />
                  </td>
                  <td>
                    <select
                      value={l.rateType}
                      onChange={(e) => setRow(i, 'rateType', e.target.value as RateType)}
                    >
                      <option value="G">Per Gram</option>
                      <option value="1">Per 10g</option>
                      <option value="K">Per Kg</option>
                      <option value="P">Per Piece</option>
                    </select>
                  </td>
                  <td>
                    <LookupPicker
                      entity="bullion-bookings"
                      value={l.bookingLookup}
                      onChange={(value) => setRow(i, 'bookingLookup', value)}
                      onPick={(row) => pickBooking(i, row)}
                      searchPath={bookingSearchPath}
                      placeholder="search bookings…"
                      ariaLabel={`Bullion booking source line ${i + 1}`}
                      style={{ minWidth: 210 }}
                    />
                  </td>
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedRateCutFields}
                    line={l}
                    row={i}
                    baseColumns={9}
                    setValue={(row, key, value) => setRow(row, key, value)}
                  />
                  <td className="num">{lineFine(l).toLocaleString('en-IN')}</td>
                  <td className="num">{inr(lineAmt(l))}</td>
                  <td>
                    <button
                      type="button"
                      className="ghost"
                      onClick={() => removeRow(i)}
                      disabled={lines.length === 1}
                      title="remove line"
                    >
                      ✕
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td
                  colSpan={fullGrid ? 9 + extendedRateCutFields.length : 9}
                  style={{ textAlign: 'right', fontWeight: 600 }}
                >
                  Totals
                </td>
                <td className="num">
                  <b>{totalFine.toLocaleString('en-IN')}</b>
                </td>
                <td className="num">
                  <b>{inr(totalAmt)}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <details style={{ marginTop: 8 }}>
            <summary>Party address and two-sided settlement (desktop MSG2_TOTAL)</summary>
            {/* The desktop settlement band has explicit Payment and Received columns
                (TR_BUL_SALE.cs:9889, :9981-9992) so a party balance can be closed in rupees and
                fine metal in the same voucher. The screen offered only cash and kasar. */}
            <div className="row">
              <div className="field">
                <label>Address 1</label>
                <input value={add1} onChange={(e) => setAdd1(e.target.value)} />
              </div>
              <div className="field">
                <label>Address 2</label>
                <input value={add2} onChange={(e) => setAdd2(e.target.value)} />
              </div>
              <div className="field">
                <label>Address 3</label>
                <input value={add3} onChange={(e) => setAdd3(e.target.value)} />
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
            </div>
            <div className="row">
              <div className="field">
                <label>Settle Dr ₹</label>
                <input value={settleDrAmt} onChange={(e) => setSettleDrAmt(e.target.value)} />
              </div>
              <div className="field">
                <label>Settle Cr ₹</label>
                <input value={settleCrAmt} onChange={(e) => setSettleCrAmt(e.target.value)} />
              </div>
              <div className="field">
                <label>Settle Dr Fine</label>
                <input value={settleDrFine} onChange={(e) => setSettleDrFine(e.target.value)} />
              </div>
              <div className="field">
                <label>Settle Cr Fine</label>
                <input value={settleCrFine} onChange={(e) => setSettleCrFine(e.target.value)} />
              </div>
            </div>
          </details>

          <div className="toolbar" style={{ marginTop: 8 }}>
            <button type="button" className="ghost" onClick={addRow}>
              + Add line
            </button>
          </div>
        </div>

        <div className="panel" style={{ overflow: 'auto' }}>
          <h2>Received Lines</h2>
          <GridModeToggle
            full={fullGrid}
            setFull={setFullGrid}
            extendedCount={extendedRateCutFields.length}
            testId="bullion-sale-received-grid-mode"
          />
          <table className="grid" onKeyDown={handleReceivedGridKey}>
            <thead>
              <tr>
                <th>#</th>
                <th>Item</th>
                <th>Tag</th>
                <th className="num">Net Wt</th>
                <th className="num">Touch %</th>
                <th className="num">West %</th>
                <th className="num">Rate</th>
                <th>Rate Type</th>
                <th>Booking</th>
                <ExtendedHeaderCells full={fullGrid} fields={extendedRateCutFields} />
                <th className="num">Fine</th>
                <th className="num">Net Amt</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
              {receivedLines.map((l, i) => (
                <tr key={i}>
                  <td>{i + 1}</td>
                  <td>
                    <input
                      style={{ width: 90 }}
                      value={l.itCode}
                      onChange={(e) => setReceivedRow(i, 'itCode', e.target.value)}
                    />
                  </td>
                  <td>
                    <input
                      style={{ width: 80 }}
                      value={l.tagNo}
                      onChange={(e) => setReceivedRow(i, 'tagNo', e.target.value)}
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 90, textAlign: 'right' }}
                      value={l.netWt}
                      inputMode="decimal"
                      onChange={(e) => setReceivedRow(i, 'netWt', e.target.value)}
                      placeholder="0.000"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 70, textAlign: 'right' }}
                      value={l.touch}
                      inputMode="decimal"
                      onChange={(e) => setReceivedRow(i, 'touch', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 70, textAlign: 'right' }}
                      value={l.west}
                      inputMode="decimal"
                      onChange={(e) => setReceivedRow(i, 'west', e.target.value)}
                      placeholder="0.00"
                    />
                  </td>
                  <td className="num">
                    <input
                      style={{ width: 90, textAlign: 'right' }}
                      value={l.rate}
                      inputMode="decimal"
                      onChange={(e) => setReceivedRow(i, 'rate', e.target.value)}
                      placeholder="0"
                    />
                  </td>
                  <td>
                    <select
                      value={l.rateType}
                      onChange={(e) => setReceivedRow(i, 'rateType', e.target.value as RateType)}
                    >
                      <option value="G">Per Gram</option>
                      <option value="1">Per 10g</option>
                      <option value="K">Per Kg</option>
                      <option value="P">Per Piece</option>
                    </select>
                  </td>
                  <td>
                    <LookupPicker
                      entity="bullion-bookings"
                      value={l.bookingLookup}
                      onChange={(value) => setReceivedRow(i, 'bookingLookup', value)}
                      onPick={(row) => pickReceivedBooking(i, row)}
                      searchPath={bookingSearchPath}
                      placeholder="search bookings…"
                      ariaLabel={`Bullion booking source received line ${i + 1}`}
                      style={{ minWidth: 210 }}
                    />
                  </td>
                  <ExtendedBodyCells
                    full={fullGrid}
                    fields={extendedRateCutFields}
                    line={l}
                    row={i}
                    baseColumns={9}
                    setValue={(row, key, value) => setReceivedRow(row, key, value)}
                  />
                  <td className="num">{lineFine(l).toLocaleString('en-IN')}</td>
                  <td className="num">{inr(lineAmt(l))}</td>
                  <td>
                    <button
                      type="button"
                      className="ghost"
                      onClick={() => removeReceivedRow(i)}
                      disabled={receivedLines.length === 1}
                      title="remove received line"
                    >
                      ✕
                    </button>
                  </td>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td
                  colSpan={fullGrid ? 9 + extendedRateCutFields.length : 9}
                  style={{ textAlign: 'right', fontWeight: 600 }}
                >
                  Totals
                </td>
                <td className="num">
                  <b>{receivedTotalFine.toLocaleString('en-IN')}</b>
                </td>
                <td className="num">
                  <b>{inr(receivedTotalAmt)}</b>
                </td>
                <td></td>
              </tr>
            </tfoot>
          </table>
          <div className="toolbar" style={{ marginTop: 8 }}>
            <button type="button" className="ghost" onClick={addReceivedRow}>
              + Add receive line
            </button>
          </div>
        </div>

        <div className="panel">
          <h2>Settlement</h2>
          <h3>Issue / sale-side payment</h3>
          <div className="row">
            <div className="field">
              <label>Cash</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={cash}
                inputMode="decimal"
                onChange={(e) => setCash(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Cheque</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={chq}
                inputMode="decimal"
                onChange={(e) => setChq(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Card</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={card}
                inputMode="decimal"
                onChange={(e) => setCard(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Kasar</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={kasar}
                inputMode="decimal"
                onChange={(e) => setKasar(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Bill O/S</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={billOs}
                inputMode="decimal"
                onChange={(e) => setBillOs(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Cheque Bank A/c</label>
              <input value={bankAc} onChange={(e) => setBankAc(e.target.value)} />
            </div>
            <div className="field">
              <label>Cheque No</label>
              <input value={chqNo} onChange={(e) => setChqNo(e.target.value)} />
            </div>
            <div className="field">
              <label>Card A/c</label>
              <input value={cardAc} onChange={(e) => setCardAc(e.target.value)} />
            </div>
          </div>

          <h3>Receive / purchase-side payment</h3>
          <div className="row">
            <div className="field">
              <label>Received Cash</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={receivedCash}
                inputMode="decimal"
                onChange={(e) => setReceivedCash(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Received Cheque</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={receivedChq}
                inputMode="decimal"
                onChange={(e) => setReceivedChq(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Received Card</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={receivedCard}
                inputMode="decimal"
                onChange={(e) => setReceivedCard(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Received Kasar</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={receivedKasar}
                inputMode="decimal"
                onChange={(e) => setReceivedKasar(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Received Bill O/S</label>
              <input
                style={{ textAlign: 'right', width: 120 }}
                value={receivedBillOs}
                inputMode="decimal"
                onChange={(e) => setReceivedBillOs(e.target.value)}
                placeholder="0.00"
              />
            </div>
            <div className="field">
              <label>Received Bank A/c</label>
              <input value={receivedBankAc} onChange={(e) => setReceivedBankAc(e.target.value)} />
            </div>
            <div className="field">
              <label>Received Cheque No</label>
              <input value={receivedChqNo} onChange={(e) => setReceivedChqNo(e.target.value)} />
            </div>
            <div className="field">
              <label>Received Card A/c</label>
              <input value={receivedCardAc} onChange={(e) => setReceivedCardAc(e.target.value)} />
            </div>
          </div>
          <div className="toolbar" style={{ marginTop: 10 }}>
            <span className="muted">
              {canSubmit ? (
                <>
                  {hasLine && (
                    <>
                      Fix <b>{totalFine.toLocaleString('en-IN')}</b> fine{' '}
                      {itType === 'G' ? 'gold' : 'silver'} · value <b>₹{inr(totalAmt)}</b> · issue
                      settlement ₹{inr(issueSettlementTotal)}
                    </>
                  )}
                  {hasReceivedLine && (
                    <>
                      {hasLine ? ' · ' : ''}
                      Receive <b>{receivedTotalFine.toLocaleString('en-IN')}</b> fine · value ₹
                      {inr(receivedTotalAmt)} · receive settlement ₹{inr(receivedSettlementTotal)}
                    </>
                  )}
                </>
              ) : (
                'Pick a party and enter at least one issued or received line to post.'
              )}
            </span>
            <span className="spacer" />
            <button type="button" className="ghost" onClick={reset} disabled={busy}>
              New
            </button>
            {loadedVoucherNo && (
              <button type="button" className="danger" onClick={remove} disabled={busy}>
                Delete
              </button>
            )}
            <button className="primary" disabled={busy || !canSubmit}>
              {busy ? 'Saving…' : loadedVoucherNo ? 'Update Bullion Sale' : 'Save Bullion Sale'}
            </button>
          </div>
        </div>
      </form>

      {err && <div className="msg err">{err}</div>}
      {result && (
        <div className="panel">
          <div className="msg ok">
            {result.updated ? 'Updated' : 'Posted'} — Bullion Sale #{result.vchNo} · fine{' '}
            {Number(result.fine ?? 0).toLocaleString('en-IN')} · net ₹
            {inr(Number(result.netAmt ?? 0))}
          </div>
        </div>
      )}
    </div>
  );
}
