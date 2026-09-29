import { round, roundHalfEven } from './money.js';

/**
 * TR_WH_SALE line arithmetic, shared by the writer (apps/api `rateCut.ts`) and the Wholesale Sale / Rate Cut
 * screen preview, so what the operator sees is what posts.
 *
 * Desktop sources (TR_WH_SALE.cs, sha256/16 bac1e3578f9c0284):
 * - issue grid `CommPassTotal`, 9160-9860 (column numbers below are that grid's);
 * - receive grid `CommPassTotal_Pr`, 6857-7040;
 * - totals `MSG_TOT_FILL` 8292-8350 and `MSG_PR_TOT_FILL` 7062-7112, and the band (`BILL_TOTAL` 15639-15640).
 *
 * Rounding follows the two desktop mechanisms (see money.ts): `Strings.Format(x, "0.000"/"0.00")` is half-up,
 * `Math.Round(x, n)` is half-to-even. Each expression keeps the desktop's operand order, because in double
 * arithmetic `fine * (rate / 10)` and `fine * rate / 10` can differ in the last bit — which decides a midpoint.
 *
 * Deliberately not modelled (recorded in the X16 contract): the fixed wastage column (FixWst%, col 22), the
 * header wastage override (`nWestPrc`), the "All" item type's MRP pricing (col 40 → 41 only when
 * `cboItemTyp.SelectedIndex == 2`, TR_WH_SALE.cs:9836-9860), pieces × piece-weight gross (col 7) and bag weight.
 */

export interface WholesaleLineSettings {
  /**
   * `CO_SET_NEW.LBR_WITH_GHT` (blank is 'Y', MS_OPNCOMP.cs:1224-1226). Net-wise labour ('N') is charged on net
   * weight alone only when this is 'N'; otherwise on net + ghat.
   */
  labourIncludesGhat: boolean;
  /** `CO_SET.LBR_TYPE` (`MsLbrType`): per-kg labour ('K') is on gross weight when this is 'G', else net + ghat. */
  companyLabourType: string;
}

export interface WholesaleLineInput {
  pcs?: number;
  grossWt?: number;
  othWt?: number;
  /** An explicit net weight wins over gross − other. */
  netWt?: number;
  ghtPct?: number;
  /**
   * An explicit ghat WEIGHT, which wins over `ghtPct`. The receive grid has no ghat % at all — its column 11 is
   * the typed ghat weight, saved as `RATE_CUT_REC.ITM_GHT_WT` (TR_WH_SALE.cs:6875, :13290) — and a reopened
   * issued line brings back only `ITM_GHT_WT` (col 19; RATE_CUT_ISU stores no ghat %, :12478).
   */
  ghtWt?: number;
  touch?: number;
  westPct?: number;
  /** Issue grid: LESS_WT comes off the fine and HM_FINE is added to it (cols 24 and 25). */
  lessWt?: number;
  hallmarkFine?: number;
  /** Receive grid: LESS_TOUCH comes off the purity (col 14). */
  lessTouch?: number;
  /**
   * A fine that is already known. A tag brings its stored `ITM_FINE` (TR_WH_SALE.cs:10697), and the grid keeps it
   * unless the operator changes the wastage or a hallmark fine is entered.
   */
  fine?: number;
  rate?: number;
  /** Item `RATE_TYPE`: P per piece, 1 per 10 g, K per kg, anything else per gram. */
  rateType?: string;
  /** Line conversion: when ConRate is set it decides the rate (cols 29/30 → 31). */
  convRate?: number;
  convPct?: number;
  /** LBR_TYPE: P pieces, N net, K per kg, anything else gross. */
  lbrType?: string;
  lbrRate?: number;
  /** The labour amount as typed; used only when there is no labour rate. */
  lbrAmt?: number;
  othAmt?: number;
  /** ORate: other charges quoted per unit of metal. With an amount, the amount becomes fine (OFine). */
  otherRate?: number;
  /** OFine as typed; used only when there is no other rate. */
  otherFine?: number;
  /** Receive grid: a tax % backs the tax out of the net (col 33). The issue grid has no such step. */
  taxPct?: number;
}

export interface WholesaleLineResult {
  netWt: number;
  ghtWt: number;
  fine: number;
  /** The rate the line is priced at: the conversion's when one is given, else the typed rate. */
  rate: number;
  itemAmount: number;
  labourAmount: number;
  otherAmount: number;
  /** OFine: other charges converted into fine (derived when ORate and OthAmt are both set). */
  otherFine: number;
  /** The other amount that became fine; it leaves the money totals (`SlOthAmtLess` / `PrOthAmtLess`). */
  otherAmountInFine: number;
  /** TOT_AMT. The issue grid never computes column 43, so an issued line saves 0 here. */
  totalAmount: number;
  netAmount: number;
}

const n = (value: unknown): number => {
  const x = Number(value ?? 0);
  return Number.isFinite(x) ? x : 0;
};

const code = (value: unknown): string =>
  String(value ?? '')
    .trim()
    .toUpperCase()
    .slice(0, 1);

/** `Strings.Format(x, "0.000")` — weights and fine. */
const format3 = (x: number): number => round(x, 3);
/** `Strings.Format(x, "0.00")` — money cells that are not rounded by Math.Round first. */
const format2 = (x: number): number => round(x, 2);
/** `Math.Round(x, 0)` — banker's rounding to whole rupees. */
const mathRound0 = (x: number): number => roundHalfEven(x, 0);

/** Cols 29/30 → 31: `Math.Round(ConRate / Con% * 100, 2)`, or ConRate alone; else the typed rate. */
function lineRate(input: WholesaleLineInput): number {
  const convRate = n(input.convRate);
  const convPct = n(input.convPct);
  if (convRate !== 0 && convPct !== 0) return roundHalfEven((convRate / convPct) * 100, 2);
  if (convRate !== 0) return format2(convRate);
  return n(input.rate);
}

/** Col 32 / receive col 21, TR_WH_SALE.cs:9690-9716 and 6937-6953. */
function itemAmountOf(rateType: string, pcs: number, fine: number, rate: number): number {
  if (rate === 0 || fine + pcs === 0) return 0;
  switch (rateType) {
    case 'P':
      return mathRound0(pcs * rate);
    case '1':
      return mathRound0(fine * (rate / 10));
    case 'K':
      return mathRound0(fine * (rate / 1000));
    default:
      return mathRound0(fine * rate);
  }
}

/** Col 36 / receive col 25, TR_WH_SALE.cs:9760-9800 and 6978-7004. Typed labour stands when there is no rate. */
function labourAmountOf(
  input: WholesaleLineInput,
  weights: { pcs: number; grossWt: number; netWt: number; ghtWt: number },
  settings: WholesaleLineSettings,
): number {
  const rate = n(input.lbrRate);
  if (rate === 0) return format2(n(input.lbrAmt));
  const { pcs, grossWt, netWt, ghtWt } = weights;
  switch (code(input.lbrType)) {
    case 'P':
      return mathRound0(pcs * rate);
    case 'N':
      return settings.labourIncludesGhat
        ? mathRound0((netWt + ghtWt) * rate)
        : mathRound0(netWt * rate);
    case 'K':
      return code(settings.companyLabourType) === 'G'
        ? mathRound0(grossWt * (rate / 1000))
        : mathRound0((netWt + ghtWt) * (rate / 1000));
    default:
      return mathRound0(grossWt * rate);
  }
}

/** Col 39 / receive col 28: `Math.Round(OthAmt [× 10 | × 1000] / ORate, 3)` by the item's rate type. */
function otherFineOf(input: WholesaleLineInput, rateType: string, othAmt: number): number {
  const otherRate = n(input.otherRate);
  if (otherRate === 0 || othAmt === 0) return n(input.otherFine);
  if (rateType === '1') return roundHalfEven((othAmt * 10) / otherRate, 3);
  if (rateType === 'K') return roundHalfEven((othAmt * 1000) / otherRate, 3);
  return roundHalfEven(othAmt / otherRate, 3);
}

function weightsOf(input: WholesaleLineInput) {
  const pcs = n(input.pcs);
  const grossWt = n(input.grossWt);
  const netWt = input.netWt != null ? format3(n(input.netWt)) : format3(grossWt - n(input.othWt));
  // Col 19 = col 17 × col 18 / 100 (TR_WH_SALE.cs:9361), unless the weight itself is given.
  const ghtWt =
    input.ghtWt != null ? format3(n(input.ghtWt)) : format3((netWt * n(input.ghtPct)) / 100);
  return { pcs, grossWt, netWt, ghtWt };
}

/**
 * One ISSUED line (RATE_CUT_ISU).
 *
 * Fine (col 26), TR_WH_SALE.cs:9436-9660:
 * - touch + wastage = 0: net + ghat − less weight + hallmark fine;
 * - otherwise (net + ghat) × (touch + wastage) / 100 − less weight + hallmark fine;
 * - a weightless line with a purity keeps its fine at 0 unless a hallmark fine is entered.
 */
export function wholesaleIssueLine(
  input: WholesaleLineInput,
  settings: WholesaleLineSettings,
): WholesaleLineResult {
  const weights = weightsOf(input);
  const { pcs, netWt, ghtWt } = weights;
  const pct = n(input.touch) + n(input.westPct);
  const lessWt = n(input.lessWt);
  const hallmarkFine = n(input.hallmarkFine);
  let fine: number;
  if (input.fine != null && hallmarkFine === 0) fine = format3(n(input.fine));
  else if (pct === 0) fine = format3(netWt + ghtWt - lessWt + hallmarkFine);
  else if (netWt === 0 && hallmarkFine === 0) fine = 0;
  else fine = format3(((netWt + ghtWt) * pct) / 100 - lessWt + hallmarkFine);

  const rateType = code(input.rateType);
  const rate = lineRate(input);
  const itemAmount = itemAmountOf(rateType, pcs, fine, rate);
  const labourAmount = labourAmountOf(input, weights, settings);
  const otherAmount = format2(n(input.othAmt));
  const otherFine = otherFineOf(input, rateType, otherAmount);
  // Col 41 = col 36 + col 37 + col 32 (TR_WH_SALE.cs:9834). No MRP override and no tax back-out on this grid.
  const netAmount = format2(labourAmount + otherAmount + itemAmount);
  return {
    netWt,
    ghtWt,
    fine,
    rate,
    itemAmount,
    labourAmount,
    otherAmount,
    otherFine,
    otherAmountInFine: n(input.otherRate) !== 0 ? otherAmount : 0,
    totalAmount: 0,
    netAmount,
  };
}

/**
 * One RECEIVED line (RATE_CUT_REC).
 *
 * Fine (col 15), TR_WH_SALE.cs:6872-6906: with a purity and a weight, (net + ghat) × (touch + wastage − less
 * touch) / 100; with no purity, net + ghat; a weightless line with a purity has no fine.
 * Net (col 30): the total (labour + other + item amount, col 32), or the total with the tax backed out when the
 * line carries a tax % (col 33).
 */
export function wholesaleReceiveLine(
  input: WholesaleLineInput,
  settings: WholesaleLineSettings,
): WholesaleLineResult {
  const weights = weightsOf(input);
  const { pcs, netWt, ghtWt } = weights;
  const touchPlusWest = n(input.touch) + n(input.westPct);
  let fine: number;
  if (input.fine != null) fine = format3(n(input.fine));
  else if (touchPlusWest === 0) fine = format3(netWt + ghtWt);
  else if (netWt === 0) fine = 0;
  else fine = format3(((netWt + ghtWt) * (touchPlusWest - n(input.lessTouch))) / 100);

  const rateType = code(input.rateType);
  const rate = lineRate(input);
  const itemAmount = itemAmountOf(rateType, pcs, fine, rate);
  const labourAmount = labourAmountOf(input, weights, settings);
  const otherAmount = format2(n(input.othAmt));
  const otherFine = otherFineOf(input, rateType, otherAmount);
  const totalAmount = format2(labourAmount + otherAmount + itemAmount);
  const taxPct = n(input.taxPct);
  const netAmount = taxPct === 0 ? totalAmount : mathRound0((totalAmount / (taxPct + 100)) * 100);
  return {
    netWt,
    ghtWt,
    fine,
    rate,
    itemAmount,
    labourAmount,
    otherAmount,
    otherFine,
    otherAmountInFine: n(input.otherRate) !== 0 ? otherAmount : 0,
    totalAmount,
    netAmount,
  };
}

export interface WholesaleGridTotals {
  /**
   * SL_FINE / PR_FINE: the fine of UNPRICED lines plus every line's other fine.
   *
   * `TotDrFine += fine` only where the line's item amount is 0 (TR_WH_SALE.cs:8344-8346; the receive grid at
   * :7105-7107; TR_BUL_SALE.cs:6011 and :5692 alike). A priced line is sold for money, so its metal does not
   * also move the party's fine balance — counting it posted the party twice, once in rupees and once in gold.
   */
  fine: number;
  /** Every line's fine: the metal the voucher moves in stock, priced or not. */
  handledFine: number;
  itemAmount: number;
  labourAmount: number;
  /** SL_OTH_AMT / PR_OTH_AMT: other charges less those converted into fine. */
  otherAmount: number;
  /** Money net of the lines: Σ net less the other charges converted into fine. */
  netAmount: number;
}

/** Totals of one grid, as `MSG_TOT_FILL` / `MSG_PR_TOT_FILL` accumulate them. */
export function wholesaleGridTotals(lines: WholesaleLineResult[]): WholesaleGridTotals {
  const sum = (pick: (line: WholesaleLineResult) => number): number =>
    lines.reduce((total, line) => total + pick(line), 0);
  const inFine = sum((line) => line.otherAmountInFine);
  return {
    fine: format3(sum((line) => (line.itemAmount === 0 ? line.fine : 0) + line.otherFine)),
    handledFine: format3(sum((line) => line.fine)),
    itemAmount: format2(sum((line) => line.itemAmount)),
    labourAmount: format2(sum((line) => line.labourAmount)),
    otherAmount: format2(sum((line) => line.otherAmount) - inFine),
    netAmount: format2(sum((line) => line.netAmount) - inFine),
  };
}

/** What was settled in one band column: rows 2 (cheque), 3 (card), 5 (cash) and 6 (kasar) of `MSG2_TOTAL`. */
export interface WholesaleTender {
  cash?: number;
  cheque?: number;
  card?: number;
  kasar?: number;
}

export interface WholesaleBandInput {
  /** The settlement after `settleMoneyMetal`: DR_AMT / CR_AMT and DR_FINE / CR_FINE. */
  settlement: { drAmt?: number; crAmt?: number; drFine?: number; crFine?: number };
  /** The issue grid's totals (SL side) and the receive grid's (PR side). */
  issued: Pick<WholesaleGridTotals, 'fine' | 'netAmount'>;
  received: Pick<WholesaleGridTotals, 'fine' | 'netAmount'>;
  /** Column 4, captioned "Received" — the SL_* tender (`pay` on the API). */
  receivedTender?: WholesaleTender;
  /** Column 3, captioned "Payment" — the PR_* tender (`receivedPay` on the API). */
  paymentTender?: WholesaleTender;
}

export interface WholesaleBand {
  /** `MSG2_TOTAL[1,4]`: SL_NET_AMT and SL_TOT_AMT. */
  receivedNet: number;
  /** `MSG2_TOTAL[7,4]`: SL_BILL_OS. */
  receivedOs: number;
  /** `MSG2_TOTAL[1,3]`: PR_NET_AMT and PR_TOT_AMT. */
  paymentNet: number;
  /** `MSG2_TOTAL[7,3]`: PR_BILL_OS. */
  paymentOs: number;
  /** `nTotFineDr` / `nTotFineCr` (TOT_FINE_DR / TOT_FINE_CR) and `nDiffFine`, captioned "Os Fine". */
  totFineDr: number;
  totFineCr: number;
  osFine: number;
  /** `lblDiffAmt`: the gap between the two outstandings, and which way it runs ("Pay" or "Rec"). */
  diffAmount: number;
  diffSide: 'Pay' | 'Rec' | '';
}

/**
 * The settlement band `MSG2_TOTAL` as BILL_TOTAL fills it (TR_WH_SALE.cs:15633-15667; TR_BUL_SALE.cs:10652-10658
 * has the same net rows).
 *
 * - Net = `Math.Round(DR_AMT + Σ issued NET_AMT − SlOthAmtLess, 0)` (banker's), and the Payment column the same
 *   with CR_AMT and the received lines. `netAmount` already has the other charges that became fine taken out.
 * - Os = net − cash − cheque − card − kasar, formatted "0.00". The Order row (4) is shown but not subtracted.
 * - Tot fine Dr = SL_FINE + DR_FINE (+ fine kasar, not modelled), Cr = PR_FINE + CR_FINE; Os fine = Dr − Cr.
 * - The difference label reads "<Payment Os − Received Os> Pay" or "<Received Os − Payment Os> Rec".
 * Silver amounts (`nSlvrDrAmt`/`nSlvrCrAmt`) are not modelled; they are 0 on every captured voucher.
 */
export function wholesaleBand(input: WholesaleBandInput): WholesaleBand {
  const tender = (value: WholesaleTender | undefined) => ({
    cash: n(value?.cash),
    cheque: n(value?.cheque),
    card: n(value?.card),
    kasar: n(value?.kasar),
  });
  const received = tender(input.receivedTender);
  const payment = tender(input.paymentTender);
  const receivedNet = mathRound0(n(input.settlement.drAmt) + n(input.issued.netAmount));
  const paymentNet = mathRound0(n(input.settlement.crAmt) + n(input.received.netAmount));
  // Desktop operand order: net − cash − cheque − card − kasar (:15641-15642).
  const receivedOs = format2(
    receivedNet - received.cash - received.cheque - received.card - received.kasar,
  );
  const paymentOs = format2(
    paymentNet - payment.cash - payment.cheque - payment.card - payment.kasar,
  );
  const totFineDr = format3(n(input.issued.fine) + n(input.settlement.drFine));
  const totFineCr = format3(n(input.received.fine) + n(input.settlement.crFine));
  const diffSide: WholesaleBand['diffSide'] =
    paymentOs > receivedOs ? 'Pay' : paymentOs < receivedOs ? 'Rec' : '';
  return {
    receivedNet,
    receivedOs,
    paymentNet,
    paymentOs,
    totFineDr,
    totFineCr,
    osFine: format3(totFineDr - totFineCr),
    diffAmount: diffSide === '' ? 0 : format2(Math.abs(paymentOs - receivedOs)),
    diffSide,
  };
}
