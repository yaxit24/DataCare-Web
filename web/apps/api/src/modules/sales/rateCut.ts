import { withTenant } from '@datacare/db';
import { settleMoneyMetal, type SettlementResult } from './settlement.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { buildRateCutRojmel, rojmelMetalFor } from '../shared/rojmel.js';
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
 * ACCOUNT CONFIG — now sourced from BOOK_DETL, as the desktop does.
 *
 * An earlier revision of this file stated "BOOK_DETL is EMPTY for book 064 in this dataset, so the precise
 * mapping cannot be reproduced" and shipped the placeholder codes 'SALEGOLD'/'CASH'/'KASAR'/'LABOUR'/'OTHER'.
 * **That statement was wrong.** BOOK_DETL holds 24 rows for books 034/064 (455 overall), and the mapping is
 * exactly the SR positions this file already documented:
 *
 *   SR1  00003 SALES GOLD A/C      SR2  00008 PURCHASE GOLD A/C   SR3  00001 CASH ON HAND
 *   SR4  00057 KASAR JAVK A/C      SR5  00042 KASAR AVAK A/C      SR6  00041 LABOUR INCOM. A/C
 *   SR7  00056 LABOUR EXP A/C      SR8  00004 SALES SILVER A/C    SR9  00009 PURCHASE SILVER A/C
 *   SR10 00061 INTEREST INCOME     SR11 00077 OTHER CHARGES       SR12 00098 FINE KASAR
 *
 * The placeholders were not merely cosmetic: **no AC_MAST row has AC_CODE 'SALEGOLD', 'CASH' or 'BANK'**, so
 * every ledger and day-book row written this way carried a contra pointing at an account that does not exist,
 * and any report joining LD_CODE → AC_MAST silently dropped it. Accounts remain overridable by input, but the
 * default is now resolved per book from BOOK_DETL.
 */

export class RateCutValidationError extends Error {
  constructor(msg: string) {
    super(msg);
    this.name = 'RateCutValidationError';
  }
}

/** Book code (CO_BOOK) stamped on RATE CUT vouchers (desktop parity). */
const RCT_BOOK = 'RTC'; // distinct from cash-receipt book 'RCT' (avoid voucher-number/delete collision)
/**
 * Fallback classification only. `VCH_TYPE` and `BOOK_NAME` MUST follow the BOOK, not this module: books
 * 034 (`WSALE` / `WH SALES`) and 064 (`RCUT` / `RATE CUT`) both carry `BOOK_TBL_NAME='RATE_CUT_DATA'`, so a
 * module-level constant stamped wholesale vouchers as rate-cut on AC_DATA, RATE_CUT_ISU and ROJ_MEL_DATA —
 * 84 field differences, and a wholesale voucher that reports as rate-cut. `VCH_TYPE` = `BOOK_SNAME` and
 * `BOOK_NAME` = `MAIN_BOOK`, measured on 39 of 40 real books, so both are read from BOOK_DATA per voucher.
 */
const RCT_BOOK_NAME = 'RATE CUT';
const RCT_TYPE = 'RCUT';
const BULLION_SALE_MAIN_BOOKS = new Set(['BUL WH SALE', 'BUL SALE']);

/** Classification for one voucher, read from its own book row. */
export interface BookClassification {
  vchType: string;
  bookName: string;
  inoutType: string;
}

/** Resolve VCH_TYPE/BOOK_NAME from BOOK_DATA, falling back to the rate-cut constants. */
export async function resolveBookClassification(
  tx: any,
  tenantId: string,
  coCode: string,
  lcCode: string,
  coBook: string,
): Promise<BookClassification> {
  const rows: Array<{ sname: string | null; main: string | null; inout: string | null }> =
    await tx.$queryRawUnsafe(
      `SELECT "BOOK_SNAME" AS sname,"MAIN_BOOK" AS main,"BOOK_INOUT" AS inout FROM "BOOK_DATA"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
      tenantId,
      coCode,
      lcCode,
      coBook,
    );
  const r = rows[0];
  return {
    vchType: String(r?.sname ?? '').trim() || RCT_TYPE,
    bookName: String(r?.main ?? '').trim() || RCT_BOOK_NAME,
    inoutType: String(r?.inout ?? '').trim() || 'O',
  };
}

type RateCutBookGuard = 'rate-cut' | 'bullion-sale';

const normalizeMainBook = (value: unknown): string =>
  String(value ?? '')
    .trim()
    .toUpperCase();

function assertRateCutBookGuard(
  classification: BookClassification,
  coBook: string,
  guard?: RateCutBookGuard,
): void {
  if (!guard) return;
  const mainBook = normalizeMainBook(classification.bookName);
  const isBullionSaleBook = BULLION_SALE_MAIN_BOOKS.has(mainBook);
  if (guard === 'bullion-sale') {
    if (!isBullionSaleBook) {
      throw new RateCutValidationError(
        `book ${coBook} is ${classification.bookName || 'unclassified'}; use a bullion-sale book`,
      );
    }
    return;
  }
  if (isBullionSaleBook) {
    throw new RateCutValidationError(
      `book ${coBook} is ${classification.bookName}; use the bullion sale workflow`,
    );
  }
}

/**
 * BOOK_DETL SR_NO positions for the accounts this family posts to, as measured on books 034 and 064.
 * Keeping the numbers here rather than inline keeps the mapping checkable against the table.
 */
const BOOK_DETL_SR = {
  goldAc: 1,
  purchaseAc: 2,
  cashAc: 3,
  kasarAc: 4,
  lbrAc: 6,
  othAc: 11,
} as const;

/**
 * Resolve the book's contra accounts from BOOK_DETL. Explicit input always wins; anything BOOK_DETL does not
 * configure is left undefined rather than defaulted to an invented code, so a missing configuration surfaces
 * as a validation failure instead of a row pointing at a nonexistent account.
 */
export async function resolveBookAccounts(
  tx: any,
  tenantId: string,
  coCode: string,
  lcCode: string,
  coBook: string,
  override?: RateCutAccounts,
): Promise<RateCutAccounts> {
  const rows: Array<{ SR_NO: number; AC_CODE: string | null }> = await tx.$queryRawUnsafe(
    `SELECT "SR_NO","AC_CODE" FROM "BOOK_DETL"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4`,
    tenantId,
    coCode,
    lcCode,
    coBook,
  );
  const bySr = new Map<number, string>();
  for (const r of rows) {
    const code = String(r.AC_CODE ?? '').trim();
    if (code) bySr.set(Number(r.SR_NO), code);
  }
  const out: RateCutAccounts = {};
  for (const [field, sr] of Object.entries(BOOK_DETL_SR) as Array<
    [keyof RateCutAccounts, number]
  >) {
    const explicit = String(override?.[field] ?? '').trim();
    const configured = bySr.get(sr);
    if (explicit) out[field] = explicit;
    else if (configured) out[field] = configured;
  }
  return out;
}

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
const hasValue = (v: unknown): boolean => v != null && String(v).trim() !== '';
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
  /** The item's purchase-code classification, written to `PR_CODE` — 'BK', 'FN', 'DH' on the captured lines. */
  prCode?: string;
  /**
   * The item's own name, written to `ITM_REMARK`.
   *
   * The desktop repeats the item master's name on each rate-cut line — 'BACHA KADALI - 916', 'FINE GOLD',
   * 'DHAL OG' across the captured rows. Supplied by the caller rather than read from `ITEM_MAST` inside the
   * builder, which is how the sale and purchase Rojmel callers already pass item names.
   */
  itemName?: string;
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
  purchaseAc?: string; // receive/purchase-side contra (BOOK_DETL SR2)
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
  /** Receive/purchase-side material grid, persisted to RATE_CUT_REC. */
  receivedLines?: RateCutLine[];
  pay?: RateCutPay;
  /** Purchase/receive-side settlement columns (`PR_*`) from desktop `MSG2_TOTAL` column 3. */
  receivedPay?: RateCutPay;
  accounts?: RateCutAccounts;
  // ---- Money/metal settlement (desktop BILL_TOTAL) ------------------------------------------------
  /** `nConvRate` / `nConvPrc`: conversion rate and purity the operator entered. */
  convRate?: number;
  convPct?: number;
  /**
   * The voucher's fine RATE, when the rate is fixed for the voucher rather than per line.
   *
   * `rollup` takes `FINE_RATE` from the first line, documented as "single-rate is the common case". It is not the
   * only case: `wsale-034-00015` carries no `ITM_RATE` and no `ITM_AMT` on any of its six lines and fixes the price
   * at the header instead — `CR_FINE 11.06 × FINE_RATE 8900 = 98,434`, which is exactly its `SL_NET_AMT`. Without a
   * voucher-level rate that voucher valued at **zero**: ₹98,434 of real trade posting as nothing.
   *
   * Rate cutting IS fixing a rate against a fine balance, so the header form of it is not an edge case.
   */
  fineRate?: number;
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

/**
 * No invented defaults. These codes do not exist in AC_MAST — writing them produced ledger rows whose contra
 * pointed nowhere. Accounts come from BOOK_DETL via resolveBookAccounts, or from explicit input.
 */
const DEFAULT_ACCOUNTS: RateCutAccounts = {};

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
export function rollup(
  lines: RateCutLine[],
  voucherItType: 'G' | 'S',
  /**
   * The voucher's fine rate, used when no line carries one.
   *
   * Optional and applied only as a fallback, so a voucher whose lines DO carry rates is unaffected.
   */
  voucherFineRate?: number,
): RateCutTotals {
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
    // Metal leg FINE_RATE: the per-voucher rate. Common case = one rate; first line is representative. When no
    // line carries one, the voucher's own rate is used — see `RateCutInput.fineRate`.
    rate: (computed.length ? computed[0]!.rate : 0) || num(voucherFineRate),
    computed,
  };
}

interface LedgerCtx {
  customer: string;
  itType: 'G' | 'S';
  totals: RateCutTotals;
  receivedTotals?: RateCutTotals;
  pay: Required<Pick<RateCutPay, 'cash' | 'chq' | 'card' | 'kasar'>> & {
    bankAc: string;
    cardAc: string;
  };
  receivedPay?: Required<Pick<RateCutPay, 'cash' | 'chq' | 'card' | 'kasar'>> & {
    bankAc: string;
    cardAc: string;
  };
  accounts: Required<RateCutAccounts>;
  vchDate: Date;
  /** Classification read from the voucher's own BOOK_DATA row, never a module constant. */
  vchType: string;
  bookName: string;
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
  const { customer, itType, totals, receivedTotals, pay, receivedPay, accounts, vchDate } = ctx;
  const base = { ...key, VCH_TYPE: ctx.vchType, VCH_DATE: vchDate };
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
  const receivedItmAmt = receivedTotals?.totalItmAmt ?? 0;

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

  // Receive/purchase side. This mirrors the existing split-leg style used above while writing the
  // purchase/control account from BOOK_DETL SR2. The desktop stores the receive material in
  // RATE_CUT_REC and the header PR_* totals; without these AC_DATA legs a receive-only rate cut would
  // reopen with rows but have no accounting movement.
  if (receivedItmAmt > 0) {
    lines.push(money(accounts.purchaseAc, customer, receivedItmAmt, 0));
    lines.push(money(customer, accounts.purchaseAc, 0, receivedItmAmt));
  }
  if ((receivedTotals?.totalFine ?? 0) > 0) {
    lines.push({
      ...base,
      AC_CODE: customer,
      LD_CODE: accounts.purchaseAc,
      IT_TYPE: itType,
      SIGN: '+',
      FINE_WT: receivedTotals!.totalFine,
      FINE_RATE: receivedTotals!.rate,
      DR_AMT: 0,
      CR_AMT: 0,
    });
  }
  if ((receivedPay?.cash ?? 0) > 0) {
    lines.push(money(customer, accounts.cashAc, receivedPay!.cash, 0));
    lines.push(money(accounts.cashAc, customer, 0, receivedPay!.cash));
  }
  if ((receivedPay?.chq ?? 0) > 0) {
    lines.push(money(customer, receivedPay!.bankAc, receivedPay!.chq, 0));
    lines.push(money(receivedPay!.bankAc, customer, 0, receivedPay!.chq));
  }
  if ((receivedPay?.card ?? 0) > 0) {
    lines.push(money(customer, receivedPay!.cardAc, receivedPay!.card, 0));
    lines.push(money(receivedPay!.cardAc, customer, 0, receivedPay!.card));
  }
  if ((receivedPay?.kasar ?? 0) > 0) {
    lines.push(money(customer, accounts.kasarAc, receivedPay!.kasar, 0));
    lines.push(money(accounts.kasarAc, customer, 0, receivedPay!.kasar));
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
  receivedTotals: RateCutTotals,
  vchDate: Date,
  rateBasis: 'G' | 'T' | 'K',
  settlement: SettlementResult,
): Record<string, unknown> {
  const p = input.pay ?? {};
  const rp = input.receivedPay ?? {};
  const fineRate = totals.rate || receivedTotals.rate;
  /**
   * The voucher's value when it is priced at the header: the fine being CUT, at the voucher's fine rate.
   *
   * `settleCrFine` is the quantity the voucher cuts (the desktop's `CR_FINE`); `totals.rate` is `FINE_RATE`,
   * which now falls back to `input.fineRate` when no line carries a rate. Rounded to whole rupees like every other
   * money column here.
   */
  const headerPricedAmount = round0(num(input.settleCrFine) * num(fineRate));
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
    /**
     * Audit flags the desktop stamps on every captured rate-cut header: `USER_DELETE` and `USER_UPDATE` `'N'`,
     * `MOB_ENTRY_SAVE` `'Y'` — 15 of 15 each. The web wrote none of them.
     *
     * `MOB_ENTRY_SAVE` reads as "saved from the counter rather than a mobile entry"; whatever its origin, it is
     * constant across every captured voucher and is what a desktop-written row looks like.
     */
    USER_UPDATE: 'N',
    USER_DELETE: 'N',
    MOB_ENTRY_SAVE: 'Y',
    FINE_RATE: fineRate,
    // Derived money/metal settlement (TR_TOUR_SALE.cs:12999-13130). Zero when the operator supplied no
    // conversion, so an ordinary rate-cut voucher is unchanged.
    CONV_RATE: input.convRate == null ? null : Number(input.convRate),
    CONV_PRC: input.convPct == null ? null : Number(input.convPct),
    DR_AMT: settlement.drAmt,
    CR_AMT: settlement.crAmt,
    SL_FINE: totals.totalFine,
    PR_FINE: receivedTotals.totalFine,
    /**
     * The SETTLEMENT fine legs, which are not the lines' total fine.
     *
     * Measured across the 15 captured headers:
     *
     *   `SL_FINE`     == the lines' total fine   14/15   (already correct)
     *   `TOT_FINE_DR` == the lines' total fine   13/15   — the web wrote 0
     *   `CR_FINE`     == 0                       14/15   — the web wrote the lines' total
     *   `DR_FINE`     == 0                       14/15   (already correct)
     *   `TOT_FINE_CR` == 0                       13/15   — the web wrote the lines' total
     *
     * The distinction matters: `SL_FINE` is the metal the voucher HANDLES, while `CR_FINE` is the metal it SETTLES.
     * Writing the handled fine into the settlement column credited the party a metal balance for the whole
     * consignment every time, when in 14 of 15 real vouchers nothing was settled in metal at all.
     *
     * `CR_FINE` now takes the caller's settlement value, so `wsale-034-00015` — the one voucher that does settle in
     * metal — keeps its 11.06. The two non-zero `TOT_FINE_CR` values (21.064 and 50.19) have no derivable relation
     * to any input available here, so that column defaults to 0 and those two remain open rather than guessed.
     */
    CR_FINE: num(input.settleCrFine),
    DR_FINE: num(input.settleDrFine),
    TOT_FINE_CR: num(input.settleCrFine),
    TOT_FINE_DR: totals.totalFine,
    SL_ITM_AMT: totals.totalItmAmt,
    SL_LBR_AMT: totals.totalLbr,
    SL_OTH_AMT: totals.totalOth,
    /**
     * A voucher priced at the HEADER is valued from its fine rate, not left at zero.
     *
     * These totals are summed from the lines, which is right whenever the lines carry amounts. When they do not —
     * `wsale-034-00015` has no `ITM_RATE` and no `ITM_AMT` on any of its six lines — the sum is 0 and a voucher
     * worth ₹98,434 posted as nothing. The desktop's own arithmetic is explicit:
     *
     *     CR_FINE 11.06  ×  FINE_RATE 8900  =  98,434  =  SL_NET_AMT  =  SL_TOT_AMT
     *
     * So the fallback prices the fine being CUT at the voucher's rate. It applies only when the lines value at
     * zero, so no voucher that works today can change.
     */
    SL_TOT_AMT: totals.totalTot || headerPricedAmount,
    SL_TAX_AMT: totals.totalTax,
    SL_NET_AMT: totals.totalNet || headerPricedAmount,
    SL_CASH_AMT: round0(num(p.cash)),
    SL_CHQ_AMT: round0(num(p.chq)),
    SL_CARD_AMT: round0(num(p.card)),
    SL_KASAR_AMT: round0(num(p.kasar)),
    SL_BILL_OS: round0(num(p.billOs)),
    PR_ITM_AMT: receivedTotals.totalItmAmt,
    PR_LBR_AMT: receivedTotals.totalLbr,
    PR_OTH_AMT: receivedTotals.totalOth,
    PR_TOT_AMT: receivedTotals.totalTot,
    PR_TAX_AMT: receivedTotals.totalTax,
    PR_NET_AMT: receivedTotals.totalNet,
    PR_CASH_AMT: round0(num(rp.cash)),
    PR_CHQ_AMT: round0(num(rp.chq)),
    PR_CARD_AMT: round0(num(rp.card)),
    PR_KASAR_AMT: round0(num(rp.kasar)),
    PR_BILL_OS: round0(num(rp.billOs)),
    TAX_CODE: p.taxCode ?? null,
    TAX_PRC: num(p.taxPct),
    BANK_AC: p.bankAc ?? rp.bankAc ?? null,
    CHQ_NO: p.chqNo ?? rp.chqNo ?? null,
    CARD_AC: p.cardAc ?? rp.cardAc ?? null,
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
  cls: BookClassification,
): Record<string, unknown>[] {
  return input.lines.map((l, i) => {
    const c = totals.computed[i]!;
    const ref = l.isuRef ?? {};
    return {
      ...key,
      /**
       * `VCH_SRNO` is 0 on a rate-cut line — 20 of 20 captured rows.
       *
       * It is a TAG identity, not a line ordinal: `SR_NO` and `OLD_SRNO` carry the ordinal. These lines are loose
       * metal, so there is no tag instance to name, and the web's `i + 1` invented one.
       */
      VCH_SRNO: 0,
      SR_NO: i + 1,
      // OLD_SRNO holds the line's own serial on original entry — measured equal to SR_NO on 20 of 20 real
      // RATE_CUT_ISU rows (and 103 of 103 PR_DETL rows). The web wrote 0, orphaning the back-reference.
      OLD_SRNO: i + 1,
      VCH_DATE: vchDate,
      VCH_TYPE: cls.vchType,
      INOUT_TYPE: cls.inoutType,
      /** 'W' on 20 of 20 captured rows — the wholesale entry type. */
      ENTRY_TYPE: 'W',
      /**
       * The karigar valuation columns, which on these rows track NET WEIGHT rather than fine — measured
       * `KR_NET_WT == ITM_NWT` and `KR_FINE == ITM_NWT` on 19 of 20 rows, the exception being a weightless line.
       */
      KR_NET_WT: c.netWt,
      KR_FINE: c.netWt,
      BOOK_NAME: cls.bookName,
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
      /**
       * 0 on all 20 captured lines, like its `FINE_CUT_GWT` / `FINE_CUT_NWT` siblings.
       *
       * The line's own fine is already in `ITM_FINE`; this column records fine CUT against a balance, which on
       * these vouchers is settled at the header. Copying the line fine here recorded the same metal twice.
       */
      FINE_CUT_FINE: 0,
      /**
       * The FINE-CUT weights are 0 on every captured rate-cut line — 20 of 20.
       *
       * They record a weight CUT against a fine balance, which is a different act from the metal being issued;
       * `ITM_GWT` / `ITM_NWT` and the tag weights already carry the line's own weight. Copying the line weight
       * here double-recorded it, and on a rate-cut voucher a duplicated weight is a duplicated metal position.
       */
      FINE_CUT_NWT: 0,
      FINE_CUT_GWT: 0,
      /** 'N' on 20 of 20 captured lines, as on a purchase line. */
      DESIGN_IMG_ID: 'N',
      /** The header's employee, carried onto every line — 20 of 20. */
      EMP_CODE: input.empCode ?? null,
      /**
       * The item's own name, which the desktop repeats on the line as a remark: 'BACHA KADALI - 916' (8 rows),
       * 'FINE GOLD' (6), 'DHAL OG' (4). Sourced from the line's supplied description so the module does not have
       * to read the item master mid-build.
       */
      ITM_REMARK: txt(l.itemName, 255),
      PR_CODE: txt(l.prCode, 2),
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
      LESS_TOUCH: Number(l.lessTouch) || 0,
      ITM_OTH_RATE: Number(l.otherRate) || 0,
      ITM_OTH_FINE: Number(l.otherFine) || 0,
      CONV_RATE: Number(l.convRate) || 0,
      CONV_PRC: Number(l.convPct) || 0,
      SILVER_FINE: Number(l.silverFine) || 0,
      ISU_LC_CODE: txt(l.issueLcCode, 255) ?? String(key.LC_CODE ?? ''),
      /**
       * Derived rather than required from the caller, measured across the 20 captured rate-cut lines:
       *
       *   `TAG_GWT`  == `ITM_GWT`   20/20        `TAG_NWT`  == `ITM_NWT`   20/20
       *   `KR_NET_WT` == `ITM_NWT`  19/20        `KR_FINE`  == `ITM_NWT`   19/20
       *
       * `KR_FINE` tracking NET WEIGHT rather than fine weight is not a transcription slip — it is what the rows
       * hold, on every line that carries weight. The exception in each pair is a line with no weight at all.
       *
       * These were all zero before, because the builder only wrote what the caller passed and no caller passes a
       * tag weight for a loose line.
       */
      TAG_GWT: hasValue(l.tagGrossWt) ? Number(l.tagGrossWt) : num(l.grossWt),
      TAG_NWT: hasValue(l.tagNetWt) ? Number(l.tagNetWt) : c.netWt,
      MCX_RATE: Number(l.mcxRate) || 0,
      HM_FINE: Number(l.hallmarkFine) || 0,
      OLD_VCH_NO: null,
      NEW_VCH_NO: null,
    };
  });
}

function buildReceivedLineRows(
  key: VoucherKey,
  input: RateCutInput,
  totals: RateCutTotals,
  vchDate: Date,
  cls: BookClassification,
): Record<string, unknown>[] {
  return (input.receivedLines ?? []).map((l, i) => {
    const c = computeLine(l, totals.itType);
    const ref = l.isuRef ?? {};
    return {
      ...key,
      VCH_DATE: vchDate,
      HD_VCH_NO: input.hdVchNo ?? null,
      AC_CODE: input.acCode,
      VCH_TYPE: cls.vchType,
      INOUT_TYPE: cls.inoutType,
      ENTRY_TYPE: 'P',
      BOOK_NAME: cls.bookName,
      SR_NO: i + 1,
      OLD_SRNO: i + 1,
      VCH_SRNO: 0,
      OLD_VCH_SRNO: i + 1,
      IT_CODE: l.itCode ?? null,
      ITM_REMARK: txt(l.itemName, 50),
      TAG_NO: 'N',
      DESIGN_NO: txt(l.designNo, 15),
      LOT_NO: txt(l.lotNo, 15),
      ITM_LOT: txt(l.itemLot, 10),
      ITM_PCS: num(l.pcs),
      ITM_GWT: num(l.grossWt),
      ITM_OTH_WT: num(l.othWt),
      ITM_NWT: c.netWt,
      ITM_GHT_WT: c.ghtWt,
      ITM_TOUCH: num(l.touch),
      ITM_WEST_PRC: num(l.westPct),
      LESS_TOUCH: Number(l.lessTouch) || 0,
      LESS_WT: num(l.lessWt),
      ITM_FINE: c.fine,
      ADJ_WT: num(l.adjustWt),
      SILVER_FINE: Number(l.silverFine) || 0,
      LBR_TYPE: l.lbrType ?? null,
      LBR_RATE: num(l.lbrRate),
      LBR_AMT: c.lbrAmt,
      OTH_AMT: c.othAmt,
      ITM_OTH_RATE: Number(l.otherRate) || 0,
      ITM_OTH_FINE: Number(l.otherFine) || 0,
      CONV_RATE: Number(l.convRate) || 0,
      CONV_PRC: Number(l.convPct) || 0,
      MCX_RATE: Number(l.mcxRate) || 0,
      ITM_RATE: c.rate,
      ITM_AMT: c.itmAmt,
      ITM_MRP: num(l.mrp),
      TOT_AMT: c.totAmt,
      TAX_PRC: num(l.taxPct),
      NET_AMT: c.netAmt,
      RATE_TYPE: l.rateType ?? 'G',
      IT_TYPE: c.itType,
      TAG_COST: num(l.tagCost),
      TAG_NWT: hasValue(l.tagNetWt) ? Number(l.tagNetWt) : c.netWt,
      ISU_NO: ref.no ?? null,
      ISU_LC_CODE: txt(l.issueLcCode, 2) ?? String(key.LC_CODE ?? ''),
      ISU_YRCD: ref.yrcd ?? null,
      ISU_DBCD: ref.dbcd ?? null,
      ISU_SRNO: ref.srno ?? null,
      WITH_STOCK: 'Y',
      MAIN_USER: null,
      HM_ID2: '',
      HM_ID3: '',
      HM_ID4: '',
      HM_ID_WT: num(l.grossWt),
      HM_ID2_WT: 0,
      HM_ID3_WT: 0,
      HM_ID4_WT: 0,
      FINE_CUT_PCS: num(l.pcs),
      FINE_CUT_GWT: 0,
      FINE_CUT_NWT: 0,
      FINE_CUT_FINE: 0,
      PR_CODE: txt(l.prCode, 2),
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
 * PHASE-2 TODO: project SL_IDTL (stone/diamond sub-lines), MAIN_STOCK
 * (ROJ_MEL_DATA is DONE — the sale-side day-book projection, types 03/04, from the real book-064 rows.)
 * (tag/stock movement) and DM_DATA (diamond stock) — deferred (spec §5.3). The delete path already
 * reverses those tables so a phase-2 voucher cleans up fully.
 */
/**
 * Read a saved rate-cut voucher — plan item F2.1.
 *
 * WHY THIS FAMILY NEEDED ITS OWN READER
 * ====================================
 * Rate-cut had no reader at all, so a saved voucher could not be reopened or reprinted. It matters more than
 * its 40 vouchers suggest: **wholesale sale routes through this same family**, because `BOOK_DATA` for
 * `MAIN_BOOK='WH SALES'` carries `BOOK_TBL_NAME='RATE_CUT_DATA'`. So this one reader serves both
 * `RATE CUT` (book 064, 25 vouchers) and `WH SALES` (book 034, 15).
 *
 * The returned shape is keyed the way `RateCutInput` is keyed — `acCode`, `itType`, `convPct`, `pay`, `lines`
 * — so post-then-get is symmetric and a round trip can assert on the caller's own field names.
 *
 * `FINE_RATE` is the rate that was cut and `TOT_FINE_DR`/`TOT_FINE_CR` the fine it was cut against; those are
 * the values a header-only rate-cut carries, which is why they are surfaced explicitly rather than left inside
 * a totals blob. (A header-only voucher is exactly what 25 of 25 real rate-cuts are — see decision D-1.)
 */
async function readRateCut(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
  options: { bookGuard?: RateCutBookGuard } = {},
): Promise<Record<string, unknown>> {
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const key = keyOf(scope, Number(voucherNo), scope.coBook ?? RCT_BOOK);
  const t = (v: unknown) => String(v ?? '').trim();
  const n = (v: unknown) => Number(v ?? 0);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const classification = await resolveBookClassification(
      tx,
      scope.tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_BOOK,
    );
    assertRateCutBookGuard(classification, key.CO_BOOK, options.bookGuard);
    const head: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "VCH_NO","VCH_DATE"::text,"HD_VCH_NO","BILL_NO","IT_TYPE","AC_CODE","AC_NAME",
              "RATE_PAR","FINE_RATE","CONV_RATE","CONV_PRC","TOT_FINE_DR","TOT_FINE_CR",
              "SL_NET_AMT","SL_TOT_AMT","SL_CASH_AMT","SL_CHQ_AMT","SL_CARD_AMT","SL_KASAR_AMT",
              "SL_BILL_OS","PR_FINE","PR_ITM_AMT","PR_LBR_AMT","PR_OTH_AMT","PR_TAX_AMT",
              "PR_NET_AMT","PR_TOT_AMT","PR_CASH_AMT","PR_CHQ_AMT","PR_CARD_AMT","PR_KASAR_AMT",
              "PR_BILL_OS","TAX_CODE","TAX_PRC","BANK_AC","CHQ_NO","CARD_AC","EMP_CODE","VCH_DESC",
              "ADD1","ADD2","ADD3","CITY","MOBILE","BANK_NAME"
         FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6`,
      scope.tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_YEAR,
      key.CO_BOOK,
      key.VCH_NO,
    );
    // Throw rather than return a blank record, as every sibling reader does.
    if (!head.length) throw new RateCutValidationError(`rate-cut voucher not found: ${voucherNo}`);
    const h = head[0]!;

    /**
     * Lines come from `RATE_CUT_ISU`, and an EMPTY set is legitimate — not an error. All 25 real rate-cut
     * vouchers on book 064 carry zero detail rows; the value sits entirely in the header. Wholesale vouchers
     * on book 034 do carry lines. Treating absent lines as "voucher not found" would make the commonest real
     * shape unreadable.
     */
    const lines: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","VCH_SRNO","IT_CODE","ITM_REMARK","TAG_NO","DESIGN_NO","LOT_NO",
              "ITM_LOT","ITM_PCS","ITM_GWT",
              "ITM_OTH_WT","ITM_NWT","ITM_GHT_WT","ITM_TOUCH","ITM_WEST_PRC",
              "LESS_TOUCH","LESS_WT",
              "LBR_TYPE","LBR_RATE","LBR_AMT","OTH_AMT","ITM_RATE","ITM_FINE",
              "ITM_OTH_RATE","ITM_OTH_FINE",
              "ITM_AMT","ITM_MRP","TOT_AMT","TAX_PRC","NET_AMT","RATE_TYPE",
              "CONV_RATE","CONV_PRC","TAG_COST","TAG_GWT","TAG_NWT",
              "PR_CODE","ADJ_WT","MCX_RATE","HM_FINE","SILVER_FINE","ISU_YRCD",
              "ISU_DBCD","ISU_NO","ISU_SRNO","ISU_LC_CODE"
         FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_YEAR,
      key.CO_BOOK,
      key.VCH_NO,
    );
    const receivedLines: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
      `SELECT "SR_NO","VCH_SRNO","IT_CODE","ITM_REMARK","TAG_NO","DESIGN_NO","LOT_NO",
              "ITM_LOT","ITM_PCS","ITM_GWT",
              "ITM_OTH_WT","ITM_NWT","ITM_GHT_WT","ITM_TOUCH","ITM_WEST_PRC",
              "LESS_TOUCH","LESS_WT",
              "LBR_TYPE","LBR_RATE","LBR_AMT","OTH_AMT","ITM_RATE","ITM_FINE",
              "ITM_OTH_RATE","ITM_OTH_FINE",
              "ITM_AMT","ITM_MRP","TOT_AMT","TAX_PRC","NET_AMT","RATE_TYPE",
              "CONV_RATE","CONV_PRC","TAG_COST","TAG_NWT",
              "PR_CODE","ADJ_WT","MCX_RATE","SILVER_FINE","ISU_YRCD","ISU_DBCD",
              "ISU_NO","ISU_SRNO","ISU_LC_CODE"
         FROM "RATE_CUT_REC" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6 ORDER BY "SR_NO"`,
      scope.tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_YEAR,
      key.CO_BOOK,
      key.VCH_NO,
    );

    return {
      voucherNo: t(h.VCH_NO),
      hiddenVoucherNo: t(h.HD_VCH_NO),
      vchDate: t(h.VCH_DATE).slice(0, 10),
      billNo: t(h.BILL_NO),
      acCode: t(h.AC_CODE),
      acName: t(h.AC_NAME),
      itType: t(h.IT_TYPE) === 'S' ? 'S' : 'G',
      rateBasis: t(h.RATE_PAR),
      // The rate that was cut, and the fine it was cut against.
      fineRate: n(h.FINE_RATE),
      fineDr: n(h.TOT_FINE_DR),
      fineCr: n(h.TOT_FINE_CR),
      convRate: n(h.CONV_RATE),
      convPct: n(h.CONV_PRC),
      netAmt: n(h.SL_NET_AMT) || n(h.SL_TOT_AMT) || n(h.PR_NET_AMT) || n(h.PR_TOT_AMT),
      receivedTotals: {
        fine: n(h.PR_FINE),
        itemAmount: n(h.PR_ITM_AMT),
        labourAmount: n(h.PR_LBR_AMT),
        otherAmount: n(h.PR_OTH_AMT),
        taxAmount: n(h.PR_TAX_AMT),
        totalAmount: n(h.PR_TOT_AMT),
        netAmount: n(h.PR_NET_AMT),
      },
      taxCode: t(h.TAX_CODE),
      taxRatePct: n(h.TAX_PRC),
      empCode: t(h.EMP_CODE),
      vchDesc: t(h.VCH_DESC),
      add1: t(h.ADD1),
      add2: t(h.ADD2),
      add3: t(h.ADD3),
      city: t(h.CITY),
      mobile: t(h.MOBILE),
      bankName: t(h.BANK_NAME),
      pay: {
        cash: n(h.SL_CASH_AMT),
        chq: n(h.SL_CHQ_AMT),
        card: n(h.SL_CARD_AMT),
        kasar: n(h.SL_KASAR_AMT),
        billOs: n(h.SL_BILL_OS),
        bankAc: t(h.BANK_AC),
        chqNo: t(h.CHQ_NO),
        cardAc: t(h.CARD_AC),
      },
      receivedPay: {
        cash: n(h.PR_CASH_AMT),
        chq: n(h.PR_CHQ_AMT),
        card: n(h.PR_CARD_AMT),
        kasar: n(h.PR_KASAR_AMT),
        billOs: n(h.PR_BILL_OS),
        bankAc: t(h.BANK_AC),
        chqNo: t(h.CHQ_NO),
        cardAc: t(h.CARD_AC),
      },
      lines: lines.map((l) => ({
        srNo: n(l.SR_NO),
        vchSrno: n(l.VCH_SRNO),
        itCode: t(l.IT_CODE),
        itemName: t(l.ITM_REMARK),
        tagNo: t(l.TAG_NO),
        designNo: t(l.DESIGN_NO),
        lotNo: t(l.LOT_NO),
        itemLot: t(l.ITM_LOT),
        pcs: n(l.ITM_PCS),
        grossWt: n(l.ITM_GWT),
        othWt: n(l.ITM_OTH_WT),
        netWt: n(l.ITM_NWT),
        ghtWt: n(l.ITM_GHT_WT),
        touch: n(l.ITM_TOUCH),
        westPct: n(l.ITM_WEST_PRC),
        lessTouch: n(l.LESS_TOUCH),
        lessWt: n(l.LESS_WT),
        lbrType: t(l.LBR_TYPE),
        lbrRate: n(l.LBR_RATE),
        lbrAmt: n(l.LBR_AMT),
        othAmt: n(l.OTH_AMT),
        otherRate: n(l.ITM_OTH_RATE),
        otherFine: n(l.ITM_OTH_FINE),
        rate: n(l.ITM_RATE),
        fine: n(l.ITM_FINE),
        amount: n(l.ITM_AMT),
        mrp: n(l.ITM_MRP),
        totalAmount: n(l.TOT_AMT),
        taxPct: n(l.TAX_PRC),
        netAmount: n(l.NET_AMT),
        rateType: t(l.RATE_TYPE),
        convRate: n(l.CONV_RATE),
        convPct: n(l.CONV_PRC),
        tagCost: n(l.TAG_COST),
        tagGrossWt: n(l.TAG_GWT),
        tagNetWt: n(l.TAG_NWT),
        prCode: t(l.PR_CODE),
        adjustWt: n(l.ADJ_WT),
        mcxRate: n(l.MCX_RATE),
        hallmarkFine: n(l.HM_FINE),
        silverFine: n(l.SILVER_FINE),
        issueLcCode: t(l.ISU_LC_CODE),
        isuRef: {
          yrcd: t(l.ISU_YRCD),
          dbcd: t(l.ISU_DBCD),
          no: t(l.ISU_NO),
          srno: n(l.ISU_SRNO),
        },
      })),
      receivedLines: receivedLines.map((l) => ({
        srNo: n(l.SR_NO),
        vchSrno: n(l.VCH_SRNO),
        itCode: t(l.IT_CODE),
        itemName: t(l.ITM_REMARK),
        tagNo: t(l.TAG_NO),
        designNo: t(l.DESIGN_NO),
        lotNo: t(l.LOT_NO),
        itemLot: t(l.ITM_LOT),
        pcs: n(l.ITM_PCS),
        grossWt: n(l.ITM_GWT),
        othWt: n(l.ITM_OTH_WT),
        netWt: n(l.ITM_NWT),
        ghtWt: n(l.ITM_GHT_WT),
        touch: n(l.ITM_TOUCH),
        westPct: n(l.ITM_WEST_PRC),
        lessTouch: n(l.LESS_TOUCH),
        lessWt: n(l.LESS_WT),
        lbrType: t(l.LBR_TYPE),
        lbrRate: n(l.LBR_RATE),
        lbrAmt: n(l.LBR_AMT),
        othAmt: n(l.OTH_AMT),
        otherRate: n(l.ITM_OTH_RATE),
        otherFine: n(l.ITM_OTH_FINE),
        rate: n(l.ITM_RATE),
        fine: n(l.ITM_FINE),
        amount: n(l.ITM_AMT),
        mrp: n(l.ITM_MRP),
        totalAmount: n(l.TOT_AMT),
        taxPct: n(l.TAX_PRC),
        netAmount: n(l.NET_AMT),
        rateType: t(l.RATE_TYPE),
        convRate: n(l.CONV_RATE),
        convPct: n(l.CONV_PRC),
        tagCost: n(l.TAG_COST),
        tagNetWt: n(l.TAG_NWT),
        prCode: t(l.PR_CODE),
        adjustWt: n(l.ADJ_WT),
        mcxRate: n(l.MCX_RATE),
        silverFine: n(l.SILVER_FINE),
        issueLcCode: t(l.ISU_LC_CODE),
        isuRef: {
          yrcd: t(l.ISU_YRCD),
          dbcd: t(l.ISU_DBCD),
          no: t(l.ISU_NO),
          srno: n(l.ISU_SRNO),
        },
      })),
    };
  });
}

export async function getRateCut(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  return readRateCut(prisma, scope, requestedVoucherNo, { bookGuard: 'rate-cut' });
}

export async function getBullionSale(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  return readRateCut(prisma, scope, requestedVoucherNo, { bookGuard: 'bullion-sale' });
}

async function writeRateCut(
  prisma: any,
  input: RateCutInput,
  options: { vchNo?: number | string; bookGuard?: RateCutBookGuard } = {},
): Promise<RateCutResult> {
  const customer = (input.acCode ?? '').toString().trim();
  if (!customer) throw new RateCutValidationError('rate-cut requires a party (customer) account');
  const issuedLines = input.lines ?? [];
  const receivedLines = input.receivedLines ?? [];
  if (!issuedLines.length && !receivedLines.length) {
    throw new RateCutValidationError('rate-cut requires at least one issued or received line');
  }
  const normalizedInput: RateCutInput = { ...input, lines: issuedLines, receivedLines };

  const itType: 'G' | 'S' = input.itType ?? 'G';
  /**
   * Placeholder until BOOK_DETL is read inside the transaction. Resolution needs `tx`, so the real accounts
   * and the book's own VCH_TYPE/BOOK_NAME are fetched below and assigned before any row is built.
   */
  let accounts: RateCutAccounts = { ...DEFAULT_ACCOUNTS, ...(input.accounts ?? {}) };
  let classification: BookClassification = {
    vchType: RCT_TYPE,
    bookName: RCT_BOOK_NAME,
    inoutType: 'O',
  };
  const totals = rollup(issuedLines, itType, input.fineRate);
  const receivedTotals = rollup(receivedLines, itType, input.fineRate);
  if (
    !(totals.totalFine > 0) &&
    !(totals.totalItmAmt > 0) &&
    !(receivedTotals.totalFine > 0) &&
    !(receivedTotals.totalItmAmt > 0)
  ) {
    throw new RateCutValidationError('rate-cut voucher has no fine and no value to post');
  }

  const p = input.pay ?? {};
  /**
   * The bank/card fallback is the book's cash account, so `pay` can only be finalised once BOOK_DETL has been
   * read inside the transaction. Amounts are settled here; the two account fields are filled at that point.
   */
  const payAmounts = {
    cash: round0(num(p.cash)),
    chq: round0(num(p.chq)),
    card: round0(num(p.card)),
    kasar: round0(num(p.kasar)),
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
    const no =
      options.vchNo == null ? await nextVoucherNoTx(tx, input.scope) : Number(options.vchNo);
    if (!Number.isSafeInteger(no) || no < 1) {
      throw new RateCutValidationError(`invalid voucher number: ${String(options.vchNo ?? '')}`);
    }
    const key = keyOf(input.scope, no, RCT_BOOK);
    /**
     * Read the book's own classification and contra accounts. Wholesale (034 `WSALE`/`WH SALES`) and rate-cut
     * (064 `RCUT`/`RATE CUT`) share this code path via BOOK_TBL_NAME='RATE_CUT_DATA', so neither value may be
     * a module constant. Accounts come from BOOK_DETL rather than invented codes absent from AC_MAST.
     */
    classification = await resolveBookClassification(
      tx,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_BOOK,
    );
    assertRateCutBookGuard(classification, key.CO_BOOK, options.bookGuard);
    if (options.vchNo != null) {
      await applyBookingDrawDownTx(tx, tenantId, key, -1);
      await reverseVoucherTx(tx, tenantId, {
        tables: [
          'RATE_CUT_DATA',
          'RATE_CUT_ISU',
          'RATE_CUT_REC',
          'SL_IDTL',
          'AC_DATA',
          'ROJ_MEL_DATA',
          'MAIN_STOCK',
          'DM_DATA',
        ],
        key,
      });
    }
    accounts = await resolveBookAccounts(
      tx,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_BOOK,
      input.accounts,
    );
    /**
     * Fail closed on an unconfigured book. Previously a missing BOOK_DETL row silently became 'SALEGOLD' — a
     * code absent from AC_MAST — so the voucher posted and every report joining the contra dropped the row.
     * A configuration gap must surface as a rejected voucher, not a silently unjoinable one.
     */
    for (const [field, sr] of Object.entries(BOOK_DETL_SR) as Array<
      [keyof RateCutAccounts, number]
    >) {
      if (!accounts[field]) {
        throw new RateCutValidationError(
          `book ${key.CO_BOOK} has no BOOK_DETL account configured at SR_NO ${sr} (${field})`,
        );
      }
    }
    const resolved = accounts as Required<RateCutAccounts>;
    const pay = {
      ...payAmounts,
      bankAc: (p.bankAc && p.bankAc.trim()) || resolved.cashAc,
      cardAc: (p.cardAc && p.cardAc.trim()) || resolved.cashAc,
    };
    const receivedPayInput = input.receivedPay ?? {};
    const receivedPay = {
      cash: round0(num(receivedPayInput.cash)),
      chq: round0(num(receivedPayInput.chq)),
      card: round0(num(receivedPayInput.card)),
      kasar: round0(num(receivedPayInput.kasar)),
      bankAc: (receivedPayInput.bankAc && receivedPayInput.bankAc.trim()) || pay.bankAc,
      cardAc: (receivedPayInput.cardAc && receivedPayInput.cardAc.trim()) || pay.cardAc,
    };
    const lines = buildRateCutLedger(key, {
      customer,
      itType,
      totals,
      receivedTotals,
      pay,
      receivedPay,
      accounts: resolved,
      vchDate,
      vchType: classification.vchType,
      bookName: classification.bookName,
    });
    // The Rojmel (day book). This module books the SALE side of a rate cut - CR_FINE carries the fixed
    // fine and DR_FINE is 0 - so it emits the sale-side row family: type 03 for the fine and 04 for the
    // amount, plus the kasar-fine pair when kasar applies to the metal rather than the money.
    //
    // Row shapes are taken from the real desktop rows of book 064, NOT from Ac_Rojmel.cs, which is a
    // later version and has the debit/credit assignment reversed on five of the nine live types. See
    // modules/shared/rojmel.ts `buildRateCutRojmel` for the sampled rows and the account-order flip.
    //
    // The purchase-side types (01, 02, 13, 22, 26) come from RATE_CUT_REC / PR_* when the receive-side
    // grid is populated.
    const rojmelRows = buildRateCutRojmel(
      {
        scope: {
          coCode: input.scope.coCode,
          lcCode: input.scope.lcCode,
          coYear: input.scope.coYear!,
        },
        key,
        coBook: key.CO_BOOK,
        vchNo: key.VCH_NO,
        vchDate,
        vchType: classification.vchType,
        bookName: classification.bookName,
        partyName: input.acName ?? '',
        partyCode: customer,
      },
      {
        // BOOK_DETL slots are PER-BOOK: on the desktop's 064 slot 1 is 00003 and slot 2 is 00008, where
        // on book 026 slot 2 is 00001. Resolved rather than hardcoded for that reason.
        saleAc: resolved.goldAc,
        purchaseAc: resolved.purchaseAc,
        kasarFineAc: resolved.kasarAc,
        purchaseKasarAc: resolved.kasarAc,
        bankAc: receivedPay.bankAc,
        metal: rojmelMetalFor(itType),
        fineRate: num(totals.rate || receivedTotals.rate),
        drFine: num(receivedTotals.totalFine),
        crFine: num(totals.totalFine),
        purchaseBillOs: num(receivedPayInput.billOs),
        // billOs is on the raw payment payload; `pay` normalises only the settled amounts.
        saleBillOs: num((p as Record<string, unknown>).billOs),
        purchaseAmount: num(receivedTotals.totalItmAmt) + num(settlement.crAmt),
        saleAmount: num(settlement.drAmt) + num(totals.totalItmAmt),
        kasarFineDr: 0,
        kasarFineCr: 0,
        purchaseChequeAmount: receivedPay.chq,
        purchaseKasarAmount: receivedPay.kasar,
      },
    );
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines },
      bookName: classification.bookName,
      writes: [
        {
          table: 'RATE_CUT_DATA',
          rows: [
            buildHeader(
              key,
              normalizedInput,
              totals,
              receivedTotals,
              vchDate,
              behavior.rateBasis,
              settlement,
            ),
          ],
        },
        {
          table: 'RATE_CUT_ISU',
          rows: buildLineRows(key, normalizedInput, totals, vchDate, classification),
        },
        {
          table: 'RATE_CUT_REC',
          rows: buildReceivedLineRows(key, normalizedInput, totals, vchDate, classification),
        },
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    await applyBookingDrawDownTx(tx, tenantId, key, 1);
    return no;
  });

  return {
    vchNo,
    fine: round3(totals.totalFine + receivedTotals.totalFine),
    netAmt: round0(totals.totalNet + receivedTotals.totalNet),
  };
}

export async function postRateCut(prisma: any, input: RateCutInput): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { bookGuard: 'rate-cut' });
}

export async function editRateCut(
  prisma: any,
  input: RateCutInput,
  vchNo: number | string,
): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { vchNo, bookGuard: 'rate-cut' });
}

export async function postBullionSale(prisma: any, input: RateCutInput): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { bookGuard: 'bullion-sale' });
}

export async function editBullionSale(
  prisma: any,
  input: RateCutInput,
  vchNo: number | string,
): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { vchNo, bookGuard: 'bullion-sale' });
}

/**
 * Consume or release booked bullion weight on `BUL_DATA.ADJ_WT`.
 *
 * A bullion booking locks a metal rate for a quantity. Availability is `ITM_GWT - ADJ_WT`, which is
 * exactly how the desktop offers bookings for selection: `AND A.ITM_GWT-A.ADJ_WT > 0`
 * (`TR_BUL_SALE.cs:4508` and `:7410`). A rate cut against a booking must therefore INCREASE
 * `ADJ_WT`, and reversing one must decrease it.
 *
 * The web wrote the link columns on `RATE_CUT_ISU` but never updated `BUL_DATA`, so a booking was
 * never consumed: `ITM_GWT - ADJ_WT` stayed at its full quantity and the same locked-rate booking
 * could be drawn down again and again with no guard. For a bullion desk that is over-delivery at a
 * stale rate, not a display glitch.
 *
 * Statements mirrored:
 *   save         `TR_BUL_SALE.cs:9101`  ADJ_WT = ADJ_WT + (B.ITM_GWT + B.ADJ_WT)
 *   edit/delete  `TR_BUL_SALE.cs:8816`, `:9202`  ADJ_WT = ADJ_WT - (B.ITM_GWT + B.ADJ_WT)
 *
 * Join, verbatim from those statements: `BUL_DATA.CO_YEAR = B.ISU_YRCD`,
 * `CO_BOOK = B.ISU_DBCD`, `VCH_NO = B.ISU_NO`, `OLD_SRNO = B.ISU_SRNO`, plus company and location.
 * Rows whose `ISU_NO` is null are unlinked rate cuts and correctly match nothing.
 *
 * `sign` is +1 to consume and -1 to release, so both directions share one definition and cannot
 * drift apart — the asymmetry between a save and its reversal is exactly how orphaned adjustments
 * appear.
 */
async function applyBookingDrawDownTx(
  tx: any,
  tenantId: string,
  key: Record<string, unknown>,
  sign: 1 | -1,
): Promise<void> {
  for (const table of ['RATE_CUT_ISU', 'RATE_CUT_REC'] as const) {
    await lockAndValidateBookingDrawDownForTableTx(tx, tenantId, key, sign, table);
    await applyBookingDrawDownForTableTx(tx, tenantId, key, sign, table);
  }
}

interface BookingDrawDownRow {
  line_sr: string;
  yrcd: string | null;
  dbcd: string | null;
  no: string | null;
  srno: number | null;
  draw_wt: number;
}

interface LockedBookingDrawDownRow extends BookingDrawDownRow {
  booking_wt: number;
  adjusted_wt: number;
}

const bookingLineKey = (row: BookingDrawDownRow): string =>
  [row.line_sr, row.yrcd ?? '', row.dbcd ?? '', row.no ?? '', String(row.srno ?? '')].join(
    '\u0000',
  );

const bookingSourceKey = (row: BookingDrawDownRow): string =>
  [row.yrcd ?? '', row.dbcd ?? '', row.no ?? '', String(row.srno ?? '')].join(' / ');

async function lockAndValidateBookingDrawDownForTableTx(
  tx: any,
  tenantId: string,
  key: Record<string, unknown>,
  sign: 1 | -1,
  table: 'RATE_CUT_ISU' | 'RATE_CUT_REC',
): Promise<void> {
  if (sign < 0) return;
  const linkedRows = (await tx.$queryRawUnsafe(
    `SELECT b."SR_NO"::text AS line_sr,b."ISU_YRCD" AS yrcd,b."ISU_DBCD" AS dbcd,
            b."ISU_NO" AS no,b."ISU_SRNO"::float8 AS srno,
            (coalesce(b."ITM_GWT",0) + coalesce(b."ADJ_WT",0))::float8 AS draw_wt
       FROM "${table}" AS b
      WHERE b.tenant_id = $1
        AND b."CO_CODE" = $2
        AND b."LC_CODE" = $3
        AND b."CO_YEAR" = $4
        AND b."CO_BOOK" = $5
        AND b."VCH_NO" = $6
        AND coalesce(b."ISU_NO",'') <> ''`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  )) as BookingDrawDownRow[];
  if (!linkedRows.length) return;

  const lockedRows = (await tx.$queryRawUnsafe(
    `SELECT b."SR_NO"::text AS line_sr,b."ISU_YRCD" AS yrcd,b."ISU_DBCD" AS dbcd,
            b."ISU_NO" AS no,b."ISU_SRNO"::float8 AS srno,
            (coalesce(b."ITM_GWT",0) + coalesce(b."ADJ_WT",0))::float8 AS draw_wt,
            coalesce(a."ITM_GWT",0)::float8 AS booking_wt,
            coalesce(a."ADJ_WT",0)::float8 AS adjusted_wt
       FROM "BUL_DATA" AS a
       JOIN "${table}" AS b
         ON a.tenant_id = b.tenant_id
        AND a."CO_CODE" = b."CO_CODE"
        AND a."LC_CODE" = b."LC_CODE"
        AND a."CO_YEAR" = b."ISU_YRCD"
        AND a."CO_BOOK" = b."ISU_DBCD"
        AND a."VCH_NO" = b."ISU_NO"
        AND a."OLD_SRNO" = b."ISU_SRNO"
      WHERE b.tenant_id = $1
        AND b."CO_CODE" = $2
        AND b."LC_CODE" = $3
        AND b."CO_YEAR" = $4
        AND b."CO_BOOK" = $5
        AND b."VCH_NO" = $6
        AND coalesce(b."ISU_NO",'') <> ''
      FOR UPDATE OF a`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  )) as LockedBookingDrawDownRow[];

  const matchedLines = new Set(lockedRows.map((row) => bookingLineKey(row)));
  const missing = linkedRows.find((row) => !matchedLines.has(bookingLineKey(row)));
  if (missing) {
    throw new RateCutValidationError(
      `${table} line ${missing.line_sr} references missing bullion booking ${bookingSourceKey(missing)}`,
    );
  }

  const bySource = new Map<
    string,
    { requested: number; bookingWt: number; adjustedWt: number; ref: string }
  >();
  for (const row of lockedRows) {
    const sourceKey = bookingSourceKey(row);
    const group = bySource.get(sourceKey) ?? {
      requested: 0,
      bookingWt: Number(row.booking_wt ?? 0),
      adjustedWt: Number(row.adjusted_wt ?? 0),
      ref: sourceKey,
    };
    group.requested = round3(group.requested + Number(row.draw_wt ?? 0));
    bySource.set(sourceKey, group);
  }

  for (const group of bySource.values()) {
    if (group.requested <= 0) continue;
    const available = round3(group.bookingWt - group.adjustedWt);
    if (group.requested - available > 0.0005) {
      throw new RateCutValidationError(
        `bullion booking ${group.ref} has only ${available.toFixed(3)} weight available; requested ${group.requested.toFixed(3)}`,
      );
    }
  }
}

async function applyBookingDrawDownForTableTx(
  tx: any,
  tenantId: string,
  key: Record<string, unknown>,
  sign: 1 | -1,
  table: 'RATE_CUT_ISU' | 'RATE_CUT_REC',
): Promise<void> {
  await tx.$executeRawUnsafe(
    `UPDATE "BUL_DATA" AS a
        SET "ADJ_WT" = coalesce(a."ADJ_WT",0) + $7 * (coalesce(b."ITM_GWT",0) + coalesce(b."ADJ_WT",0))
       FROM "${table}" AS b
      WHERE a.tenant_id = b.tenant_id
        AND a."CO_CODE"  = b."CO_CODE"
        AND a."LC_CODE"  = b."LC_CODE"
        AND a."CO_YEAR"  = b."ISU_YRCD"
        AND a."CO_BOOK"  = b."ISU_DBCD"
        AND a."VCH_NO"   = b."ISU_NO"
        AND a."OLD_SRNO" = b."ISU_SRNO"
        AND b.tenant_id = $1
        AND b."CO_CODE"  = $2
        AND b."LC_CODE"  = $3
        AND b."CO_YEAR"  = $4
        AND b."CO_BOOK"  = $5
        AND b."VCH_NO"   = $6`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
    sign,
  );
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
 * with the phase-2 SL_IDTL/MAIN_STOCK/DM_DATA writes (ROJ_MEL_DATA is done).
 */
async function reverseRateCut(
  prisma: any,
  input: DeleteRateCutInput,
  options: { bookGuard?: RateCutBookGuard } = {},
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), input.book ?? RCT_BOOK);
  return withTenant(prisma, tenantId, async (tx: any) => {
    // The audit row must record the voucher's OWN classification: this path serves both wholesale (034
    // WSALE) and rate-cut (064 RCUT), so a module constant would misfile every wholesale deletion.
    const classification = await resolveBookClassification(
      tx,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_BOOK,
    );
    assertRateCutBookGuard(classification, key.CO_BOOK, options.bookGuard);
    // Release the booked weight BEFORE the reversal runs: the draw-down joins against
    // RATE_CUT_ISU, and `reverseVoucherTx` deletes those rows. Reversing after would match nothing
    // and silently leave the booking consumed forever.
    await applyBookingDrawDownTx(tx, tenantId, key, -1);
    await reverseVoucherTx(tx, tenantId, {
      tables: [
        'RATE_CUT_DATA',
        'RATE_CUT_ISU',
        'RATE_CUT_REC',
        'SL_IDTL',
        'AC_DATA',
        'ROJ_MEL_DATA',
        'MAIN_STOCK',
        'DM_DATA',
        /**
         * `TEMP_BOOK_DATA` was listed here and must not be.
         *
         * `reverseVoucherTx` builds one WHERE clause from the full voucher key — including
         * `CO_YEAR` — and applies it to every table in this list. `TEMP_BOOK_DATA` has no `CO_YEAR`
         * column (hidden numbering is keyed by company, location, book and number only), so the
         * DELETE raised `42703 column "CO_YEAR" does not exist` and the whole transaction rolled
         * back. Deleting a rate cut therefore failed outright on both routes that offer it, and no
         * test called `deleteRateCut` to notice.
         *
         * Removing it rather than special-casing it is correct: this module never WRITES
         * `TEMP_BOOK_DATA` — it has no `insertHiddenIdentityTx` call — so there is nothing to
         * reverse. Modules that do write it reverse it through `deleteVoucherWriteSetTx`, which
         * keys that table without the year (`vouchers/lifecycle.ts:164-173`).
         */
      ],
      key,
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...key,
          VCH_TYPE: classification.vchType,
          BOOK_NAME: classification.bookName,
          DELETE_USER: input.deleteUser ?? 'system',
        },
      },
    });
    return { reversed: true };
  });
}

export async function deleteRateCut(
  prisma: any,
  input: DeleteRateCutInput,
): Promise<{ reversed: true }> {
  return reverseRateCut(prisma, input, { bookGuard: 'rate-cut' });
}

export async function deleteBullionSale(
  prisma: any,
  input: DeleteRateCutInput,
): Promise<{ reversed: true }> {
  return reverseRateCut(prisma, input, { bookGuard: 'bullion-sale' });
}
