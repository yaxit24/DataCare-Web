import { withTenant } from '@datacare/db';
import { settleMoneyMetal, type SettlementResult } from './settlement.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { postVoucherTx, reverseVoucherTx, type LedgerLine } from '../posting/posting.js';

/**
 * RATE CUT (desktop book 064, VCH_TYPE `RCUT`, BOOK_NAME `RATE CUT`).
 *
 * Business model (spec §0): "cut the rate" = fix the price on metal previously sold/issued unfixed.
 * The voucher books the fixed metal VALUE (= fine × rate), moves the fixed FINE weight on the
 * customer's gold position (karigar-style metal leg), and settles in cash / cheque / card / kasar.
 * It is a metal-AND-money voucher, exactly the IT_TYPE 'G'/'S' + SIGN/FINE_WT/FINE_RATE pattern the
 * web engine already uses (manufacturing/karigar.ts, finance/fineJv.ts).
 *
 * Header → RATE_CUT_DATA (95 cols, verified live), line items → RATE_CUT_ISU (94 cols, verified live),
 * ledger → AC_DATA via postVoucherTx (assertBalanced + period-lock run inside).
 *
 * LEG STRUCTURE: this module follows the CANONICAL split-leg structure of
 * `Ac_Ledr.Wh_Sales_Ledr` (spec §3.4) — a separate money VALUE leg (IT_TYPE 'A') and a separate
 * metal-only leg (IT_TYPE 'G'/'S', DR=CR=0). It deliberately does NOT reproduce the older migrated
 * rows in this DB (spec §7.3), which folded money+metal onto one row and were produced by a
 * different/older ledger build. Money magnitudes still reconcile to the observed voucher
 * (14965 value / 15800 cash / 15 kasar ⇒ ΣDR = ΣCR = 30780).
 *
 * HONEST ACCOUNT-CONFIG CAVEAT (spec §7.2): the exact contra-accounts are sourced at runtime from
 * the book's BOOK_DETL SR_NO config in the desktop app (SR1 gold, SR3 cash, SR4 kasar, SR6 labour,
 * SR11 other). BOOK_DETL is EMPTY for book 064 in this dataset, so the precise mapping cannot be
 * reproduced here. Accounts are therefore configurable inputs with sensible defaults
 * ('SALEGOLD'/'CASH'/'KASAR'/'LABOUR'/'OTHER'); wire them to BOOK_DETL once that config is seeded.
 */

export class RateCutValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'RateCutValidationError';
  }
}

/** Book code (CO_BOOK), ledger BOOK_NAME and voucher type stamped on RATE CUT vouchers (desktop parity). */
const RCT_BOOK = 'RTC'; // distinct from cash-receipt book 'RCT' (avoid voucher-number/delete collision)
const RCT_BOOK_NAME = 'RATE CUT';
const RCT_TYPE = 'RCUT';

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

function keyOf(s: VoucherScope, vchNo: number, book: string): VoucherKey {
  return {
    CO_CODE: s.coCode,
    LC_CODE: s.lcCode,
    CO_YEAR: s.coYear ?? '',
    CO_BOOK: s.coBook ?? book,
    VCH_NO: formatVoucherNo(vchNo),
  };
}

const num = (v: unknown): number => (v == null || v === '' ? 0 : Number(v));
const txt = (v: unknown, len: number): string | null =>
  String(v ?? '')
    .trim()
    .slice(0, len) || null;
/** Several rate-cut columns are varchar(255) in the restored schema; a number is stored as its text. */
const numText = (v: unknown): string | null => (v == null || v === '' ? null : String(v));
/** Weights are carried to 3 dp in the live schema (FINE_WT, ITM_NWT…). */
export const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;
/** Amounts are nearest-rupee (Math.Round(...,0)) in the desktop CommPassTotal. */
export const round0 = (n: number): number => Math.round(n + Number.EPSILON);

// ────────────────────────────────────────────────────────────────────────────
// PURE COMPUTATION (spec §2 / §5.2) — unit-tested against the golden values.
// ────────────────────────────────────────────────────────────────────────────

/** Net weight = gross − other (CommPassTotal col10 = col8 − col9). */
export function netWtOf(grossWt: number, othWt: number): number {
  return round3(num(grossWt) - num(othWt));
}

/** Ght weight = netWt × ght% / 100 (col12 = col10 × col11 / 100). */
export function ghtWtOf(netWt: number, ghtPct: number): number {
  return round3((num(netWt) * num(ghtPct)) / 100);
}

/**
 * Fine weight (col15):
 *   touch + west ≠ 0 ⇒ (netWt + ghtWt) × (touch + west) / 100
 *   touch + west = 0 ⇒ netWt + ghtWt   (pure 100% metal, no touch reduction)
 */
export function fine(netWt: number, ghtWt: number, touch: number, westPct: number): number {
  const base = num(netWt) + num(ghtWt);
  const pct = num(touch) + num(westPct);
  return round3(pct === 0 ? base : (base * pct) / 100);
}

/**
 * Item amount by rate type (col17, CommPassTotal):
 *   'P'      → round0(pcs × rate)        per piece
 *   '1'      → round0(fine × rate / 10)  rate per 10 g
 *   'K'      → round0(fine × rate / 1000) rate per kg
 *   default  → round0(fine × rate)       per gram   (the observed branch: 2.050 × 7300 = 14965)
 * rateType is loosely typed so callers/tests may pass 'default'/'G' for the per-gram branch.
 */
export function itmAmt(fineWt: number, rate: number, rateType?: string, pcs = 0): number {
  switch (rateType) {
    case 'P':
      return round0(num(pcs) * num(rate));
    case '1':
      return round0((num(fineWt) * num(rate)) / 10);
    case 'K':
      return round0((num(fineWt) * num(rate)) / 1000);
    default:
      return round0(num(fineWt) * num(rate));
  }
}

/** Total amount (col24): MRP overrides; else labour + other + item amount. */
export function totAmt(mrp: number, lbrAmt: number, othAmt: number, itemAmt: number): number {
  return num(mrp) > 0 ? num(mrp) : num(lbrAmt) + num(othAmt) + num(itemAmt);
}

/** Net amount (col26): tax-inclusive back-out — taxPct 0 ⇒ totAmt, else round0(totAmt/(tax+100)×100). */
export function netAmt(totalAmt: number, taxPct: number): number {
  return num(taxPct) === 0 ? num(totalAmt) : round0((num(totalAmt) / (num(taxPct) + 100)) * 100);
}

// ────────────────────────────────────────────────────────────────────────────
// INPUT SHAPE (spec §5.1)
// ────────────────────────────────────────────────────────────────────────────

export interface RateCutLine {
  // ---- Full rate-cut basis (RATE_CUT_ISU / RATE_CUT_REC) ----------------------------------------
  lessWt?: number; // LESS_WT
  adjustWt?: number; // ADJ_WT
  tagCost?: number; // TAG_COST
  lotNo?: string; // LOT_NO
  itemLot?: string; // ITM_LOT
  lessTouch?: number | string; // LESS_TOUCH (varchar)
  otherRate?: number | string; // ITM_OTH_RATE (varchar)
  otherFine?: number | string; // ITM_OTH_FINE (varchar)
  convRate?: number | string; // CONV_RATE (varchar)
  convPct?: number | string; // CONV_PRC (varchar)
  silverFine?: number | string; // SILVER_FINE (varchar)
  issueLcCode?: string; // ISU_LC_CODE
  tagGrossWt?: number | string; // TAG_GWT (varchar)
  tagNetWt?: number | string; // TAG_NWT (varchar)
  mcxRate?: number | string; // MCX_RATE (varchar)
  hallmarkFine?: number | string; // HM_FINE (varchar)
  itCode?: string;
  tagNo?: string;
  designNo?: string;
  pcs?: number;
  grossWt?: number;
  othWt?: number;
  netWt?: number; // explicit net wt; if omitted, derived as gross − oth
  ghtPct?: number;
  touch?: number;
  westPct?: number; // → fine
  rate?: number;
  rateType?: 'P' | '1' | 'K' | 'G'; // → itmAmt
  lbrType?: 'P' | 'N' | 'K' | 'G';
  lbrRate?: number;
  lbrAmt?: number;
  othAmt?: number;
  mrp?: number;
  taxPct?: number;
  itType?: 'G' | 'S';
  /** original unfixed-sale lot this line fixes (RATE_CUT_ISU.ISU_* / FINE_CUT_*). */
  isuRef?: { yrcd?: string; dbcd?: string; no?: string; srno?: number };
}

export interface RateCutPay {
  cash?: number;
  chq?: number;
  chqNo?: string;
  bankAc?: string;
  card?: number;
  cardAc?: string;
  kasar?: number;
  billOs?: number;
  taxPct?: number;
  taxCode?: string;
}

export interface RateCutAccounts {
  goldAc?: string; // metal VALUE contra (BOOK_DETL SR1) — default 'SALEGOLD'
  cashAc?: string; // BOOK_DETL SR3 — default 'CASH'
  kasarAc?: string; // BOOK_DETL SR4 — default 'KASAR'
  lbrAc?: string; // BOOK_DETL SR6 — default 'LABOUR'
  othAc?: string; // BOOK_DETL SR11 — default 'OTHER'
}

export interface RateCutInput {
  // ---- Party contact snapshot (RATE_CUT_DATA) ----------------------------------------------------
  add1?: string;
  add2?: string;
  add3?: string;
  city?: string;
  mobile?: string;
  bankName?: string;
  scope: VoucherScope;
  vchDate?: Date | string;
  acCode: string; // the customer / party
  acName?: string;
  itType?: 'G' | 'S'; // voucher metal (default 'G')
  billNo?: string;
  hdVchNo?: string;
  empCode?: string;
  vchDesc?: string;
  lines: RateCutLine[];
  pay?: RateCutPay;
  accounts?: RateCutAccounts;
  // ---- Money/metal settlement (desktop BILL_TOTAL) ------------------------------------------------
  /** `nConvRate` / `nConvPrc`: conversion rate and purity the operator entered. */
  convRate?: number;
  convPct?: number;
  /** Money and metal legs the operator filled in; the engine derives whatever is left at zero. */
  settleDrAmt?: number;
  settleCrAmt?: number;
  settleDrFine?: number;
  settleCrFine?: number;
}

export interface RateCutResult {
  vchNo: number;
  fine: number;
  netAmt: number;
}

const DEFAULT_ACCOUNTS: Required<RateCutAccounts> = {
  goldAc: 'SALEGOLD',
  cashAc: 'CASH',
  kasarAc: 'KASAR',
  lbrAc: 'LABOUR',
  othAc: 'OTHER',
};

// ────────────────────────────────────────────────────────────────────────────
// COMPUTE + LEG BUILD (pure, exported for unit tests)
// ────────────────────────────────────────────────────────────────────────────

export interface ComputedLine {
  netWt: number;
  ghtWt: number;
  fine: number;
  rate: number;
  itmAmt: number;
  lbrAmt: number;
  othAmt: number;
  totAmt: number;
  netAmt: number;
  itType: 'G' | 'S';
}

/** Run the spec §2 per-line math for one grid row. */
export function computeLine(l: RateCutLine, voucherItType: 'G' | 'S'): ComputedLine {
  const nwt = l.netWt != null ? round3(num(l.netWt)) : netWtOf(num(l.grossWt), num(l.othWt));
  const ght = ghtWtOf(nwt, num(l.ghtPct));
  const f = fine(nwt, ght, num(l.touch), num(l.westPct));
  const rate = num(l.rate);
  const amt = itmAmt(f, rate, l.rateType ?? 'G', num(l.pcs));
  const lbr = round0(num(l.lbrAmt));
  const oth = round0(num(l.othAmt));
  const tot = totAmt(num(l.mrp), lbr, oth, amt);
  const net = netAmt(tot, num(l.taxPct));
  return {
    netWt: nwt,
    ghtWt: ght,
    fine: f,
    rate,
    itmAmt: amt,
    lbrAmt: lbr,
    othAmt: oth,
    totAmt: tot,
    netAmt: net,
    itType: l.itType ?? voucherItType,
  };
}

export interface RateCutTotals {
  itType: 'G' | 'S';
  totalFine: number;
  totalItmAmt: number;
  totalLbr: number;
  totalOth: number;
  totalTot: number;
  totalNet: number;
  totalTax: number;
  rate: number; // representative FINE_RATE for the metal leg (first line; single-rate is the common case)
  computed: ComputedLine[];
}

/** Aggregate the computed lines into the voucher totals used by the ledger + header. */
export function rollup(lines: RateCutLine[], voucherItType: 'G' | 'S'): RateCutTotals {
  const computed = lines.map((l) => computeLine(l, voucherItType));
  const sum = (f: (c: ComputedLine) => number): number => computed.reduce((s, c) => s + f(c), 0);
  return {
    itType: voucherItType,
    totalFine: round3(sum((c) => c.fine)),
    totalItmAmt: round0(sum((c) => c.itmAmt)),
    totalLbr: round0(sum((c) => c.lbrAmt)),
    totalOth: round0(sum((c) => c.othAmt)),
    totalTot: round0(sum((c) => c.totAmt)),
    totalNet: round0(sum((c) => c.netAmt)),
    totalTax: round0(sum((c) => c.totAmt - c.netAmt)),
    // Metal leg FINE_RATE: the per-voucher rate. Common case = one rate; first line is representative.
    rate: computed.length ? computed[0]!.rate : 0,
    computed,
  };
}

interface LedgerCtx {
  customer: string;
  itType: 'G' | 'S';
  totals: RateCutTotals;
  pay: Required<Pick<RateCutPay, 'cash' | 'chq' | 'card' | 'kasar'>> & {
    bankAc: string;
    cardAc: string;
  };
  accounts: Required<RateCutAccounts>;
  vchDate: Date;
}

/**
 * Build the balanced AC_DATA legs for a rate-cut voucher (canonical split-leg, spec §3.4).
 *
 * Every economic event is double-posted as a contra pair (AC_CODE on the party row, LD_CODE = the
 * contra account, mirrored on the other row) — so Σ DR = Σ CR by construction and assertBalanced
 * always passes. LD_CODE is set EXPLICITLY so enrichLedgerLine (which only fills LD_CODE when null)
 * preserves the contra account instead of overwriting it with the line ordinal.
 *
 *   (a) VALUE  (money, IT_TYPE 'A'):   customer DR itmAmt   /   goldAc  CR itmAmt
 *   (b) METAL  (IT_TYPE 'G'/'S'):      customer SIGN '-' FINE_WT totalFine FINE_RATE rate (DR=CR=0)
 *   (c) CASH   (if > 0):               cashAc   DR cash     /   customer CR cash
 *   (c) CHEQUE (if > 0):               bankAc   DR chq      /   customer CR chq
 *   (c) CARD   (if > 0):               cardAc   DR card     /   customer CR card
 *   (d) KASAR  (if > 0):               customer DR kasar    /   kasarAc CR kasar
 *   (e) LABOUR (if > 0):               customer DR lbr      /   lbrAc   CR lbr
 *   (e) OTHER  (if > 0):               customer DR oth      /   othAc   CR oth
 *
 * Worked example (spec §4.1): itmAmt 14965, cash 15800, kasar 15 ⇒
 *   Σ DR = 14965(cust) + 15800(cash) + 15(cust)  = 30780
 *   Σ CR = 14965(gold) + 15800(cust) + 15(kasar) = 30780   ✓ balanced
 * The customer's three legs net to the running-balance movement (DR 14965 + DR 15 − CR 15800 = CR 820),
 * i.e. value owed minus settlement, exactly the rate-cut model.
 */
export function buildRateCutLedger(key: VoucherKey, ctx: LedgerCtx): LedgerLine[] {
  const { customer, itType, totals, pay, accounts, vchDate } = ctx;
  const base = { ...key, VCH_TYPE: RCT_TYPE, VCH_DATE: vchDate };
  const money = (acCode: string, ldCode: string, dr: number, cr: number): LedgerLine => ({
    ...base,
    AC_CODE: acCode,
    LD_CODE: ldCode,
    IT_TYPE: 'A',
    DR_AMT: round0(dr),
    CR_AMT: round0(cr),
  });
  const lines: LedgerLine[] = [];
  const itmAmtT = totals.totalItmAmt;

  // (a) VALUE — customer owes the fixed metal value; gold/sales account is the contra.
  if (itmAmtT > 0) {
    lines.push(money(customer, accounts.goldAc, itmAmtT, 0)); // customer DR
    lines.push(money(accounts.goldAc, customer, 0, itmAmtT)); // goldAc  CR
  }

  // (b) METAL-ONLY (karigar-style) — the fixed fine leaves the customer's unfixed-gold position.
  if (totals.totalFine > 0) {
    lines.push({
      ...base,
      AC_CODE: customer,
      LD_CODE: accounts.goldAc,
      IT_TYPE: itType,
      SIGN: '-',
      FINE_WT: totals.totalFine,
      FINE_RATE: totals.rate,
      DR_AMT: 0,
      CR_AMT: 0,
    });
  }

  // (c) SETTLEMENT IN — contra account DR (asset in), customer CR (receivable down).
  if (pay.cash > 0) {
    lines.push(money(accounts.cashAc, customer, pay.cash, 0));
    lines.push(money(customer, accounts.cashAc, 0, pay.cash));
  }
  if (pay.chq > 0) {
    lines.push(money(pay.bankAc, customer, pay.chq, 0));
    lines.push(money(customer, pay.bankAc, 0, pay.chq));
  }
  if (pay.card > 0) {
    lines.push(money(pay.cardAc, customer, pay.card, 0));
    lines.push(money(customer, pay.cardAc, 0, pay.card));
  }

  // (d) KASAR — customer DR / kasar account CR (desktop/observed canonical direction).
  if (pay.kasar > 0) {
    lines.push(money(customer, accounts.kasarAc, pay.kasar, 0));
    lines.push(money(accounts.kasarAc, customer, 0, pay.kasar));
  }

  // (e) LABOUR / OTHER charges — only when entered; customer DR / income account CR.
  if (totals.totalLbr > 0) {
    lines.push(money(customer, accounts.lbrAc, totals.totalLbr, 0));
    lines.push(money(accounts.lbrAc, customer, 0, totals.totalLbr));
  }
  if (totals.totalOth > 0) {
    lines.push(money(customer, accounts.othAc, totals.totalOth, 0));
    lines.push(money(accounts.othAc, customer, 0, totals.totalOth));
  }

  return lines;
}

// ────────────────────────────────────────────────────────────────────────────
// PERSISTENCE ROWS (RATE_CUT_DATA header, RATE_CUT_ISU lines) — verified columns only
// ────────────────────────────────────────────────────────────────────────────

function buildHeader(
  key: VoucherKey,
  input: RateCutInput,
  totals: RateCutTotals,
  vchDate: Date,
  rateBasis: 'G' | 'T' | 'K',
  settlement: SettlementResult,
): Record<string, unknown> {
  const p = input.pay ?? {};
  return {
    ...key,
    VCH_DATE: vchDate,
    BILL_NO: input.billNo ?? null,
    HD_VCH_NO: input.hdVchNo ?? null,
    IT_TYPE: totals.itType,
    AC_CODE: input.acCode,
    AC_NAME: input.acName ?? null,
    // RATE_PAR mirrors the company's configured metal-rate basis. The desktop sets CurRatePar from
    // MsRatePar for a new voucher (TR_WH_SALE.cs:12086-12099) and writes it to RATE_PAR
    // (TR_WH_SALE.cs:12974). Hardcoding 'G' silently mislabels every voucher at a shop that quotes rates
    // per 10 grams or per kilogram, which then misreads on reopen.
    RATE_PAR: rateBasis,
    FINE_RATE: totals.rate,
    // Derived money/metal settlement (TR_TOUR_SALE.cs:12999-13130). Zero when the operator supplied no
    // conversion, so an ordinary rate-cut voucher is unchanged.
    CONV_RATE: input.convRate == null ? null : String(input.convRate),
    CONV_PRC: input.convPct == null ? null : String(input.convPct),
    DR_AMT: settlement.drAmt,
    CR_AMT: settlement.crAmt,
    SL_FINE: totals.totalFine,
    CR_FINE: totals.totalFine, // fixed fine moves OUT on the sale/rate-cut side
    DR_FINE: 0,
    TOT_FINE_CR: totals.totalFine,
    TOT_FINE_DR: 0,
    SL_ITM_AMT: totals.totalItmAmt,
    SL_LBR_AMT: totals.totalLbr,
    SL_OTH_AMT: totals.totalOth,
    SL_TOT_AMT: totals.totalTot,
    SL_TAX_AMT: totals.totalTax,
    SL_NET_AMT: totals.totalNet,
    SL_CASH_AMT: round0(num(p.cash)),
    SL_CHQ_AMT: round0(num(p.chq)),
    SL_CARD_AMT: round0(num(p.card)),
    SL_KASAR_AMT: round0(num(p.kasar)),
    SL_BILL_OS: round0(num(p.billOs)),
    TAX_CODE: p.taxCode ?? null,
    TAX_PRC: num(p.taxPct),
    BANK_AC: p.bankAc ?? null,
    CHQ_NO: p.chqNo ?? null,
    CARD_AC: p.cardAc ?? null,
    EMP_CODE: input.empCode ?? null,
    VCH_DESC: input.vchDesc ?? null,
    // Party contact block the desktop copies onto the voucher so a reprint shows the address as it was at
    // the time, not as the master reads today. ADD1..3, CITY and MOBILE are varchar(255) here.
    ADD1: txt(input.add1, 255),
    ADD2: txt(input.add2, 255),
    ADD3: txt(input.add3, 255),
    CITY: txt(input.city, 255),
    MOBILE: txt(input.mobile, 255),
    BANK_NAME: txt(input.bankName, 50),
    ENTRY_TIME: vchDate,
    // PR_* (purchase counter-side) stay 0 for a pure rate-cut.
  };
}

function buildLineRows(
  key: VoucherKey,
  input: RateCutInput,
  totals: RateCutTotals,
  vchDate: Date,
): Record<string, unknown>[] {
  return input.lines.map((l, i) => {
    const c = totals.computed[i]!;
    const ref = l.isuRef ?? {};
    return {
      ...key,
      VCH_SRNO: i + 1,
      SR_NO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: RCT_TYPE,
      INOUT_TYPE: 'O', // rate-cut/sale side is OUT (spec: BOOK_INOUT='O')
      BOOK_NAME: RCT_BOOK_NAME,
      AC_CODE: input.acCode,
      TAG_NO: l.tagNo && l.tagNo.trim() !== '' ? l.tagNo : 'N',
      IT_CODE: l.itCode ?? null,
      DESIGN_NO: l.designNo ?? null,
      ITM_PCS: num(l.pcs),
      ITM_GWT: num(l.grossWt),
      ITM_OTH_WT: num(l.othWt),
      ITM_NWT: c.netWt,
      ITM_GHT_WT: c.ghtWt,
      ITM_TOUCH: num(l.touch),
      ITM_WEST_PRC: num(l.westPct),
      ITM_FINE: c.fine,
      LBR_TYPE: l.lbrType ?? null,
      LBR_RATE: num(l.lbrRate),
      LBR_AMT: c.lbrAmt,
      OTH_AMT: c.othAmt,
      ITM_RATE: c.rate,
      ITM_AMT: c.itmAmt,
      ITM_MRP: num(l.mrp),
      TOT_AMT: c.totAmt,
      TAX_PRC: num(l.taxPct),
      NET_AMT: c.netAmt,
      RATE_TYPE: l.rateType ?? 'G',
      IT_TYPE: c.itType,
      HD_VCH_NO: input.hdVchNo ?? null,
      // link back to the original unfixed-sale lot being fixed (spec §3.2 ISU_*/FINE_CUT_*)
      ISU_YRCD: ref.yrcd ?? null,
      ISU_DBCD: ref.dbcd ?? null,
      ISU_NO: ref.no ?? null,
      ISU_SRNO: ref.srno ?? null,
      FINE_CUT_FINE: c.fine,
      FINE_CUT_NWT: c.netWt,
      FINE_CUT_GWT: num(l.grossWt),
      FINE_CUT_PCS: num(l.pcs),
      // TR_VP.cs stamps the full rate-cut basis on each line. Most of these are varchar(255) in the
      // restored schema, so they are written as text rather than coerced to numbers; LESS_WT, ADJ_WT,
      // TAG_COST, OLD_VCH_NO and NEW_VCH_NO are numeric.
      LESS_WT: num(l.lessWt),
      ADJ_WT: num(l.adjustWt),
      TAG_COST: num(l.tagCost),
      // ADD_USER is left unwritten: RateCutInput carries no acting user, and inventing one would put a
      // false name in an audit column. It is supplied by the header's MAIN_USER on the desktop.

      LOT_NO: txt(l.lotNo, 15),
      ITM_LOT: txt(l.itemLot, 255),
      LESS_TOUCH: numText(l.lessTouch),
      ITM_OTH_RATE: numText(l.otherRate),
      ITM_OTH_FINE: numText(l.otherFine),
      CONV_RATE: numText(l.convRate),
      CONV_PRC: numText(l.convPct),
      SILVER_FINE: numText(l.silverFine),
      ISU_LC_CODE: txt(l.issueLcCode, 255),
      TAG_GWT: numText(l.tagGrossWt),
      TAG_NWT: numText(l.tagNetWt),
      MCX_RATE: numText(l.mcxRate),
      HM_FINE: numText(l.hallmarkFine),
      OLD_VCH_NO: null,
      NEW_VCH_NO: null,
    };
  });
}

// ────────────────────────────────────────────────────────────────────────────
// POST / DELETE
// ────────────────────────────────────────────────────────────────────────────

/**
 * Post a RATE CUT voucher. Numbering + ledger + table writes commit atomically in one tenant
 * transaction. assertBalanced (Σ DR = Σ CR) and the period-lock check run inside postVoucherTx.
 *
 * Phase-1 writes RATE_CUT_DATA (header) + RATE_CUT_ISU (lines) + the balanced AC_DATA ledger.
 * PHASE-2 TODO: project SL_IDTL (stone/diamond sub-lines), ROJ_MEL_DATA (day-book), MAIN_STOCK
 * (tag/stock movement) and DM_DATA (diamond stock) — deferred (spec §5.3). The delete path already
 * reverses those tables so a phase-2 voucher cleans up fully.
 */
export async function postRateCut(prisma: any, input: RateCutInput): Promise<RateCutResult> {
  const customer = (input.acCode ?? '').toString().trim();
  if (!customer) throw new RateCutValidationError('rate-cut requires a party (customer) account');
  if (!input.lines?.length) throw new RateCutValidationError('rate-cut requires at least one line');

  const itType: 'G' | 'S' = input.itType ?? 'G';
  const accounts: Required<RateCutAccounts> = { ...DEFAULT_ACCOUNTS, ...(input.accounts ?? {}) };
  const totals = rollup(input.lines, itType);
  if (!(totals.totalFine > 0) && !(totals.totalItmAmt > 0)) {
    throw new RateCutValidationError('rate-cut voucher has no fine and no value to post');
  }

  const p = input.pay ?? {};
  const pay = {
    cash: round0(num(p.cash)),
    chq: round0(num(p.chq)),
    card: round0(num(p.card)),
    kasar: round0(num(p.kasar)),
    bankAc: (p.bankAc && p.bankAc.trim()) || accounts.cashAc,
    cardAc: (p.cardAc && p.cardAc.trim()) || accounts.cashAc,
  };
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  const tenantId = input.scope.tenantId;

  const vchNo = await withTenant(prisma, tenantId, async (tx: any) => {
    // The metal-rate basis is a company setting, never a request field: it changes every derived figure.
    const behavior = await resolveSettingsBehaviorTx(tx, {
      tenantId,
      coCode: input.scope.coCode,
    });
    const settlement = settleMoneyMetal({
      convRate: input.convRate,
      convPct: input.convPct,
      drAmt: input.settleDrAmt,
      crAmt: input.settleCrAmt,
      drFine: input.settleDrFine,
      crFine: input.settleCrFine,
      ratePar: behavior.rateBasis,
    });
    const no = await nextVoucherNoTx(tx, input.scope);
    const key = keyOf(input.scope, no, RCT_BOOK);
    const lines = buildRateCutLedger(key, { customer, itType, totals, pay, accounts, vchDate });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines },
      bookName: RCT_BOOK_NAME,
      writes: [
        {
          table: 'RATE_CUT_DATA',
          rows: [buildHeader(key, input, totals, vchDate, behavior.rateBasis, settlement)],
        },
        { table: 'RATE_CUT_ISU', rows: buildLineRows(key, input, totals, vchDate) },
      ],
    });
    return no;
  });

  return { vchNo, fine: totals.totalFine, netAmt: totals.totalNet };
}

export interface DeleteRateCutInput {
  scope: VoucherScope;
  vchNo: number | string;
  book?: string; // CO_BOOK used at creation (defaults to 'RCT')
  deleteUser?: string;
}

/**
 * Delete/reverse a RATE CUT voucher: remove its rows from every table it can touch (incl. the
 * phase-2 projections) by voucher key and write a DELETE_DATA audit row — all in one transaction.
 * Reversing tables that have no matching rows is a harmless no-op, so this is forward-compatible
 * with the phase-2 SL_IDTL/ROJ_MEL_DATA/MAIN_STOCK/DM_DATA writes.
 */
export async function deleteRateCut(
  prisma: any,
  input: DeleteRateCutInput,
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), input.book ?? RCT_BOOK);
  return withTenant(prisma, tenantId, async (tx: any) => {
    await reverseVoucherTx(tx, tenantId, {
      tables: [
        'RATE_CUT_DATA',
        'RATE_CUT_ISU',
        'SL_IDTL',
        'AC_DATA',
        'ROJ_MEL_DATA',
        'MAIN_STOCK',
        'DM_DATA',
        'TEMP_BOOK_DATA',
      ],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...key,
          VCH_TYPE: RCT_TYPE,
          BOOK_NAME: RCT_BOOK_NAME,
          DELETE_USER: input.deleteUser ?? 'system',
        },
      },
    });
    return { reversed: true };
  });
}
