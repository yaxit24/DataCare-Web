import { withTxBudget } from '../shared/txBudget.js';
import {
  round,
  roundHalfEven,
  wholesaleBand,
  wholesaleGridTotals,
  wholesaleIssueLine,
  wholesaleReceiveLine,
  type WholesaleLineResult,
  type WholesaleLineSettings,
} from '@datacare/core';
import { settleMoneyMetal, type SettlementResult } from './settlement.js';
import { resolveSettingsBehaviorTx } from '../shared/settingsBehavior.js';
import { buildRateCutRojmel, rojmelMetalFor } from '../shared/rojmel.js';
import { formatVoucherNo, nextVoucherNoTx, type VoucherScope } from '../vouchers/numbering.js';
import { nextHiddenVoucherNoTx, voucherTimestamp } from '../vouchers/lifecycle.js';
import {
  insertRowTx,
  postVoucherTx,
  reverseVoucherTx,
  type LedgerLine,
} from '../posting/posting.js';
import { issueTagTx, restoreTagTx, type ResolvedTagIdentity, type TagKey } from '../stock/stock.js';

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
 * ledger → AC_DATA via postVoucherTx (assertBalanced + period-lock run inside), stock → MAIN_STOCK.
 *
 * LEG STRUCTURE: `Ac_Ledr.Wh_Sales_Ledr` (Ac_Ledr.cs:613-778), leg for leg, keyed by the desktop's own
 * two-digit leg codes. The value of fine that is CUT rides on the money leg itself — leg 01 is party Dr
 * `DR_AMT + SL_ITM_AMT` with IT_TYPE 'G', SIGN '+' and FINE_WT `CR_FINE` — while the metal the voucher
 * HANDLES has its own metal-only legs 23 (issued, '-') and 29 (received, '+'). An earlier revision posted a
 * web-invented "value" leg (IT_TYPE 'A') plus a positional metal leg, which is no desktop leg at all.
 *
 * The observed Live24 voucher 064/00004 (spec §4.1: 14965 / 15800 / 15) is a PURCHASE-side cut, and its six
 * rows are exactly legs 08/09 (Dr fine 2.050 × 7300), 45/46 (cash paid) and 51/52 (purchase kasar). Contract:
 * parity-plan-2026-09-10/evidence/implementation-2026-09-29-x16/contract.md.
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
/** Each workflow's book guard accepts only its MAIN_BOOK; Tour Sales (TR_TOUR_SALE) reuses the engine on TOUR SALES. */
const WORKFLOW_MAIN_BOOK = {
  'rate-cut': 'RATE CUT',
  'wholesale-sale': 'WH SALES',
  'wholesale-quotation': 'WH QUOT',
  'tour-sale': 'TOUR SALES',
} as const;
/** `Wh_Sale_Stk` moves stock for these books only, and only when `BOOK_INOUT` is 'O' (Ac_Stock.cs:151,153). */
const STOCK_MAIN_BOOKS = new Set([
  'WH SALES',
  'RATE CUT',
  'VP PARCEL',
  'BUL WH SALE',
  'TOUR SALES',
]);

/** Classification for one voucher, read from its own book row. */
export interface BookClassification {
  vchType: string;
  bookName: string;
  inoutType: string;
  /** `BOOK_DATA.DATA_TYPE`, which `Wh_Sale_Stk` stamps on every stock row (`B.DATA_TYPE`). */
  dataType: string;
  /** `BOOK_DATA.BOOK_NAME`, the display name the delete audit carries (TR_WH_SALE.cs:13569). */
  displayName: string;
  /** False when the book has no BOOK_DATA row and the classification is this module's fallback. */
  configured: boolean;
}

/** Resolve VCH_TYPE/BOOK_NAME from BOOK_DATA, falling back to the rate-cut constants. */
export async function resolveBookClassification(
  tx: any,
  tenantId: string,
  coCode: string,
  lcCode: string,
  coBook: string,
): Promise<BookClassification> {
  const rows: Array<{
    sname: string | null;
    main: string | null;
    inout: string | null;
    dtype: string | null;
    display: string | null;
  }> = await tx.$queryRawUnsafe(
    `SELECT "BOOK_SNAME" AS sname,"MAIN_BOOK" AS main,"BOOK_INOUT" AS inout,
            "DATA_TYPE" AS dtype,"BOOK_NAME" AS display FROM "BOOK_DATA"
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
    dataType: String(r?.dtype ?? '').trim() || 'A',
    displayName: String(r?.display ?? '').trim(),
    configured: rows.length > 0,
  };
}

export type RateCutBookGuard =
  'rate-cut' | 'wholesale-sale' | 'wholesale-quotation' | 'tour-sale' | 'bullion-sale';
/**
 * Which desktop form writes the rows. Both post through the same three routines (`Wh_Sales_Ledr`,
 * `Wh_Sales_Rojmel`, `Wh_Sale_Stk`), but their line rows and tax handling differ: TR_WH_SALE writes
 * `TAX_PRC`/`SL_TAX_AMT` 0 and its own receive-row shape, TR_BUL_SALE carries GST and the booking references.
 */
type RateCutWorkflow = 'wholesale' | 'bullion';

const normalizeMainBook = (value: unknown): string =>
  String(value ?? '')
    .trim()
    .toUpperCase();

/**
 * Whether this voucher moves stock: the `LEFT JOIN BOOK_DATA … WHERE MAIN_BOOK IN (…) AND BOOK_INOUT = 'O'` of
 * `Wh_Sale_Stk`. A book with no BOOK_DATA row matches nothing there, so the fallback classification moves
 * nothing either.
 */
export function bookMovesStock(classification: BookClassification): boolean {
  return (
    classification.configured &&
    STOCK_MAIN_BOOKS.has(normalizeMainBook(classification.bookName)) &&
    normalizeMainBook(classification.inoutType) === 'O'
  );
}

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
  if (mainBook !== WORKFLOW_MAIN_BOOK[guard]) {
    const other = (Object.keys(WORKFLOW_MAIN_BOOK) as Array<keyof typeof WORKFLOW_MAIN_BOOK>).find(
      (workflow) => WORKFLOW_MAIN_BOOK[workflow] === mainBook,
    );
    const label = (value: keyof typeof WORKFLOW_MAIN_BOOK): string =>
      ({
        'rate-cut': 'rate cut',
        'wholesale-quotation': 'wholesale quotation',
        'tour-sale': 'tour sale',
        'wholesale-sale': 'wholesale sale',
      })[value];
    throw new RateCutValidationError(
      other
        ? `book ${coBook} is ${classification.bookName}; use the ${label(other)} workflow`
        : `book ${coBook} is ${classification.bookName || 'unclassified'}; use a ${label(guard)} book`,
    );
  }
}

/**
 * BOOK_DETL SR_NO positions for the accounts this family posts to, as measured on books 034 and 064 and as
 * `Wh_Sales_Ledr` joins them (`B.SR_NO = n`). Keeping the numbers here rather than inline keeps the mapping
 * checkable against the table.
 */
const BOOK_DETL_SR = {
  goldAc: 1,
  purchaseAc: 2,
  cashAc: 3,
  kasarAc: 4,
  /** KASAR AVAK on book 064 — the Rojmel's purchase-kasar row (type 26) names it. */
  purchaseKasarAc: 5,
  lbrAc: 6,
  /** LABOUR EXP — legs 19/20 (purchase labour). */
  lbrExpAc: 7,
  /** SALES SILVER — the silver twins of the sale legs (04/05, 13, 25/26). */
  silverSaleAc: 8,
  /** PURCHASE SILVER — the silver twins of the purchase legs (06, 11/12, 31/32). */
  silverPurcAc: 9,
  othAc: 11,
  /** FINE KASAR — the Rojmel's kasar-fine rows (types 07/08). */
  fineKasarAc: 12,
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
  /**
   * A fine that is already known — a tag's stored `ITM_FINE`, which TR_WH_SALE copies onto the line
   * (TR_WH_SALE.cs:10697) and keeps unless the purity is changed or a hallmark fine is entered.
   */
  fine?: number;
  /**
   * The tag INSTANCE (`VCH_SRNO`) when a tag number exists more than once. Normally resolved from the tag
   * itself; an ambiguous tag without it is refused rather than guessed.
   */
  vchSrno?: number;
  /** `TBL_CODE` — the counter the piece stands on. A tag line takes it from the tag. */
  tblCode?: string;
  /** `ITM_SIZE`. A tag line takes it from the tag. */
  itemSize?: string;
  /** `HM_ID` / `HM_ID_WT` — hallmark id and its weight. A tag line takes them from the tag. */
  hallmarkId?: string;
  hallmarkIdWt?: number;
  /** `KR_NAME` — the karigar who made the piece. A tag line takes it from the tag. */
  karigarName?: string;
  designNo?: string;
  pcs?: number;
  grossWt?: number;
  othWt?: number;
  netWt?: number; // explicit net wt; if omitted, derived as gross − oth
  ghtPct?: number;
  /**
   * Explicit ghat WEIGHT (`ITM_GHT_WT`), winning over `ghtPct`. The receive grid types the weight (it has no
   * ghat %), and a reopened line carries only the stored weight — without this an edit lost the ghat.
   * Honoured by the TR_WH_SALE grid arithmetic (wholesale and rate cut); the bullion grid keeps `ghtPct`.
   */
  ghtWt?: number;
  touch?: number;
  westPct?: number; // → fine
  rate?: number;
  rateType?: 'P' | '1' | 'K' | 'G'; // → itmAmt
  /** '' is a real value: a tag whose labour basis is blank keeps it blank (Next23 034/4). */
  lbrType?: 'P' | 'N' | 'K' | 'G' | '';
  /** With a rate, TR_WH_SALE computes the labour amount from the basis weight; the typed amount is replaced. */
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
  goldAc?: string; // BOOK_DETL SR1 — sale (gold) control
  purchaseAc?: string; // BOOK_DETL SR2 — purchase (gold) control
  cashAc?: string; // BOOK_DETL SR3 — cash
  kasarAc?: string; // BOOK_DETL SR4 — kasar
  purchaseKasarAc?: string; // BOOK_DETL SR5 — purchase kasar (Rojmel type 26)
  lbrAc?: string; // BOOK_DETL SR6 — labour income
  lbrExpAc?: string; // BOOK_DETL SR7 — labour expense
  silverSaleAc?: string; // BOOK_DETL SR8 — sale (silver) control
  silverPurcAc?: string; // BOOK_DETL SR9 — purchase (silver) control
  othAc?: string; // BOOK_DETL SR11 — other charges
  fineKasarAc?: string; // BOOK_DETL SR12 — fine kasar (Rojmel types 07/08)
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
  /** The acting user (`MAIN_USER`), taken from the session by the route — never from the request body. */
  mainUser?: string;
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
  /** What the voucher settled, so a screen can show the derived side (e.g. 0.541 cut → ₹3517). */
  settlement?: {
    fineRate: number;
    drAmt: number;
    crAmt: number;
    drFine: number;
    crFine: number;
  };
}

// ────────────────────────────────────────────────────────────────────────────
// COMPUTE + LEG BUILD (pure, exported for unit tests)
// ────────────────────────────────────────────────────────────────────────────

export interface RateCutLineResult {
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
  /** OFine: other charges quoted per metal unit, converted into fine (TR_WH_SALE col 39 / receive col 28). */
  otherFine: number;
  /** The part of `othAmt` that became fine and so leaves the money totals (`SlOthAmtLess`). */
  othAmtInFine: number;
}

/**
 * Which grid arithmetic a line follows.
 *
 * `wholesale` is the TR_WH_SALE grid (`@datacare/core` wholesaleLine.ts), used by the Wholesale Sale and Rate
 * Cut workflows. Without it the older generic rule applies; TR_BUL_SALE's own grid (McxRate, Premium, AdjWt) has
 * not been derived yet, so the bullion workflow keeps that rule.
 */
export interface LineMath {
  wholesale?: WholesaleLineSettings;
  side?: 'issue' | 'receive';
}

function fromWholesale(result: WholesaleLineResult, itType: 'G' | 'S'): RateCutLineResult {
  return {
    netWt: result.netWt,
    ghtWt: result.ghtWt,
    fine: result.fine,
    rate: result.rate,
    itmAmt: result.itemAmount,
    lbrAmt: result.labourAmount,
    othAmt: result.otherAmount,
    totAmt: result.totalAmount,
    netAmt: result.netAmount,
    itType,
    otherFine: result.otherFine,
    othAmtInFine: result.otherAmountInFine,
  };
}

/** Run the per-line math for one grid row. */
export function computeLine(
  l: RateCutLine,
  voucherItType: 'G' | 'S',
  math: LineMath = {},
): RateCutLineResult {
  const itType = l.itType ?? voucherItType;
  if (math.wholesale) {
    const input = {
      pcs: l.pcs,
      grossWt: l.grossWt,
      othWt: l.othWt,
      netWt: l.netWt,
      ghtPct: l.ghtPct,
      ghtWt: hasValue(l.ghtWt) ? Number(l.ghtWt) : undefined,
      touch: l.touch,
      westPct: l.westPct,
      lessWt: l.lessWt,
      hallmarkFine: hasValue(l.hallmarkFine) ? Number(l.hallmarkFine) : undefined,
      lessTouch: hasValue(l.lessTouch) ? Number(l.lessTouch) : undefined,
      fine: l.fine,
      rate: l.rate,
      rateType: l.rateType,
      convRate: hasValue(l.convRate) ? Number(l.convRate) : undefined,
      convPct: hasValue(l.convPct) ? Number(l.convPct) : undefined,
      lbrType: l.lbrType,
      lbrRate: l.lbrRate,
      lbrAmt: l.lbrAmt,
      othAmt: l.othAmt,
      otherRate: hasValue(l.otherRate) ? Number(l.otherRate) : undefined,
      otherFine: hasValue(l.otherFine) ? Number(l.otherFine) : undefined,
      taxPct: l.taxPct,
    };
    return fromWholesale(
      math.side === 'receive'
        ? wholesaleReceiveLine(input, math.wholesale)
        : wholesaleIssueLine(input, math.wholesale),
      itType,
    );
  }
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
    itType,
    otherFine: 0,
    othAmtInFine: 0,
  };
}

export interface RateCutTotals {
  itType: 'G' | 'S';
  /**
   * SL_FINE / PR_FINE — the party's fine movement.
   *
   * On the TR_WH_SALE grid this is the fine of UNPRICED lines plus the other fine (`TotDrFine += fine` only where
   * the item amount is 0, TR_WH_SALE.cs:8344-8346). A priced line is settled in rupees on leg 01; counting its
   * metal on leg 23 as well charged the party twice.
   */
  totalFine: number;
  /** Every line's fine: the metal that moves in stock, priced or not. */
  handledFine: number;
  totalItmAmt: number;
  totalLbr: number;
  totalOth: number;
  totalTot: number;
  /** Σ line net, less other charges that became fine. */
  totalNet: number;
  totalTax: number;
  rate: number; // representative FINE_RATE for the metal leg (first line; single-rate is the common case)
  computed: RateCutLineResult[];
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
  math: LineMath = {},
): RateCutTotals {
  const computed = lines.map((l) => computeLine(l, voucherItType, math));
  const sum = (f: (c: RateCutLineResult) => number): number =>
    computed.reduce((s, c) => s + f(c), 0);
  // Metal leg FINE_RATE: the per-voucher rate. Common case = one rate; first line is representative. When no
  // line carries one, the voucher's own rate is used — see `RateCutInput.fineRate`.
  const rate = (computed.length ? computed[0]!.rate : 0) || num(voucherFineRate);
  if (math.wholesale) {
    const grid = wholesaleGridTotals(
      computed.map((c) => ({
        netWt: c.netWt,
        ghtWt: c.ghtWt,
        fine: c.fine,
        rate: c.rate,
        itemAmount: c.itmAmt,
        labourAmount: c.lbrAmt,
        otherAmount: c.othAmt,
        otherFine: c.otherFine,
        otherAmountInFine: c.othAmtInFine,
        totalAmount: c.totAmt,
        netAmount: c.netAmt,
      })),
    );
    return {
      itType: voucherItType,
      totalFine: grid.fine,
      handledFine: grid.handledFine,
      totalItmAmt: grid.itemAmount,
      totalLbr: grid.labourAmount,
      totalOth: grid.otherAmount,
      totalTot: round(
        sum((c) => c.totAmt),
        2,
      ),
      totalNet: grid.netAmount,
      // Only the receive grid backs tax out (col 33); an issued line's TOT_AMT is 0, so it carries no tax figure.
      totalTax:
        math.side === 'receive'
          ? round(
              sum((c) => c.totAmt - c.netAmt),
              2,
            )
          : 0,
      rate,
      computed,
    };
  }
  const totalFine = round3(sum((c) => c.fine));
  return {
    itType: voucherItType,
    totalFine,
    handledFine: totalFine,
    totalItmAmt: round0(sum((c) => c.itmAmt)),
    totalLbr: round0(sum((c) => c.lbrAmt)),
    totalOth: round0(sum((c) => c.othAmt)),
    totalTot: round0(sum((c) => c.totAmt)),
    totalNet: round0(sum((c) => c.netAmt)),
    totalTax: round0(sum((c) => c.totAmt - c.netAmt)),
    rate,
    computed,
  };
}

/**
 * The RATE_CUT_DATA figures `Wh_Sales_Ledr` reads (Ac_Ledr.cs:613-778). Every leg is a function of these
 * header columns and the book's BOOK_DETL slots — never of the lines directly — which is why a header-only
 * rate cut (25 of 25 real vouchers on book 064) posts as completely as a lined wholesale sale.
 */
export interface RateCutPostingFigures {
  /** Header `IT_TYPE`: 'G' posts the gold legs on slots 1/2, 'S' the silver twins on slots 8/9. */
  itType: 'G' | 'S';
  /** Header `FINE_RATE`, carried on the money legs 01/02 (04/05) and 08 (11). */
  fineRate: number;
  /** Settlement: `DR_AMT` (money for the fine cut) / `CR_AMT`, `CR_FINE` (fine cut) / `DR_FINE`. */
  drAmt: number;
  crAmt: number;
  drFine: number;
  crFine: number;
  /** Metal the voucher handles: issued (`SL_FINE`) and received (`PR_FINE`) line fine. */
  slFine: number;
  prFine: number;
  slItmAmt: number;
  prItmAmt: number;
  slLbrAmt: number;
  slOthAmt: number;
  prLbrAmt: number;
  prOthAmt: number;
  /** Received column of the settlement band (TR_WH_SALE.cs:14905). */
  slChqAmt: number;
  slCardAmt: number;
  slCashAmt: number;
  slKasarAmt: number;
  /** Payment column of the settlement band (TR_WH_SALE.cs:14904). */
  prChqAmt: number;
  prCardAmt: number;
  prCashAmt: number;
  prKasarAmt: number;
}

interface LedgerCtx {
  customer: string;
  figures: RateCutPostingFigures;
  /** BOOK_DETL slots of the book. A slot is required only when a leg that uses it fires. */
  accounts: RateCutAccounts;
  /** Cheque / card accounts of the received (sale) side and of the payment (purchase) side. */
  bankAc: string;
  cardAc: string;
  receivedBankAc: string;
  receivedCardAc: string;
  /** `CO_SET.TRAD_FINE` = 'Y' adds the mirrored fine legs 03/10/24/30 (06/13/26/32 for silver). */
  tradeFine: boolean;
  vchDate: Date;
  /** Classification read from the voucher's own BOOK_DATA row, never a module constant. */
  vchType: string;
  bookName: string;
  /** For the missing-slot message. */
  coBook: string;
  billNo?: string;
  hdVchNo?: string;
}

/** Money to the paisa: the header columns are numeric(18,2). Half-up on the decimal value, not the float. */
const money2 = (n: unknown): number => round(num(n), 2);

/**
 * Build the AC_DATA legs of one wholesale / rate-cut voucher — `Ac_Ledr.Wh_Sales_Ledr`, leg for leg.
 *
 * P is the party, Sn the book's BOOK_DETL slot n. Gold legs fire for header IT_TYPE 'G'; silver twins use
 * slots 8/9 for 'S'. TF legs fire only when `CO_SET.TRAD_FINE` is 'Y' (MS_OPNCOMP.cs:813-816: blank is N).
 *
 *   01/04  P Dr  DR_AMT+SL_ITM_AMT   G/S '+' CR_FINE, FINE_RATE   | 02/05  S1/S8 Cr same, FINE_RATE
 *   03/06  TF  S2/S9 '-' CR_FINE                                  | 10/13  TF  S1/S8 '+' DR_FINE
 *   08/11  P Cr  CR_AMT+PR_ITM_AMT   G/S '-' DR_FINE, FINE_RATE   | 09/12  S2/S9 Dr same, FINE_RATE 0
 *   15/16  SL_LBR  P Dr / S6 Cr      17/18  SL_OTH  P Dr / S11 Cr
 *   19/20  PR_LBR  P Cr / S7 Dr      21/22  PR_OTH  P Cr / S11 Dr
 *   23/25  P '-' SL_FINE on S1/S8    (TF 24/26 S1/S8 '+')
 *   29/31  P '+' PR_FINE on S2/S9    (TF 30/32 S2/S9 '-')
 *   35/36  SL_CHQ  P Cr / bank Dr    37/38  PR_CHQ  P Dr / bank Cr
 *   39/40  SL_CARD P Cr / card Dr    41/42  PR_CARD P Dr / card Cr
 *   43/44  SL_CASH P Cr / S3 Dr      45/46  PR_CASH P Dr / S3 Cr
 *   47/48  SL_KASAR > 0  P Cr / S4 Dr     49/50  SL_KASAR < 0  P Dr / S4 Cr (absolute)
 *   51/52  PR_KASAR      P Dr / S4 Cr
 *
 * `FINE_RATE` is carried only by 01/02 (04/05) and 08 (11); every other leg writes 0, including the metal-only
 * legs — the web wrote the rate there (6500 on 034/5 where the desktop has 0). `PARTY_AC_CODE` is set by the
 * caller passing `partyAc`: the party on its own legs, '' on contra legs.
 *
 * Money legs come in equal Dr/Cr pairs and metal-only legs carry no money, so Σ DR = Σ CR by construction.
 * A slot is looked up only when a leg that uses it fires; a missing slot refuses the voucher, because the
 * desktop's `INSERT … JOIN BOOK_DETL` would silently drop the leg and leave the voucher unbalanced.
 *
 * Deferred (contract "Open items"): 07/14 silver fine on a gold voucher, 27/28 and 33/34 fine kasar, 53/54
 * interest fine, 55/56 tax, 57-60 silver amounts, 61-64 TDS and 65-68 amount-only vouchers.
 */
export function buildRateCutLedger(key: VoucherKey, ctx: LedgerCtx): LedgerLine[] {
  const f = ctx.figures;
  const P = ctx.customer;
  const gold = f.itType !== 'S';
  const code = (goldLeg: number, silverLeg: number): number => (gold ? goldLeg : silverLeg);
  const saleSlot: keyof RateCutAccounts = gold ? 'goldAc' : 'silverSaleAc';
  const purchaseSlot: keyof RateCutAccounts = gold ? 'purchaseAc' : 'silverPurcAc';
  const slot = (field: keyof RateCutAccounts): string => {
    const configured = String(ctx.accounts[field] ?? '').trim();
    if (!configured) {
      throw new RateCutValidationError(
        `book ${ctx.coBook} has no BOOK_DETL account configured at SR_NO ${BOOK_DETL_SR[field]} (${field})`,
      );
    }
    return configured;
  };
  const base = {
    ...key,
    VCH_TYPE: ctx.vchType,
    VCH_DATE: ctx.vchDate,
    ...(ctx.billNo ? { BILL_NO: ctx.billNo } : {}),
    ...(ctx.hdVchNo ? { HD_VCH_NO: ctx.hdVchNo } : {}),
  };
  const lines: LedgerLine[] = [];
  const leg = (legType: number, row: Record<string, unknown>): void => {
    lines.push({
      ...base,
      IT_TYPE: 'A',
      SIGN: '',
      FINE_WT: 0,
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
      ...row,
      legType,
    } as LedgerLine);
  };
  /** A party-side money leg and its contra, in the desktop's order (party leg first). */
  const pair = (
    partyLeg: number,
    contraLeg: number,
    contra: string,
    partySide: 'DR' | 'CR',
    amount: number,
  ): void => {
    const value = money2(amount);
    const partyCol = partySide === 'DR' ? 'DR_AMT' : 'CR_AMT';
    const contraCol = partySide === 'DR' ? 'CR_AMT' : 'DR_AMT';
    leg(partyLeg, { AC_CODE: P, LD_CODE: contra, [partyCol]: value });
    leg(contraLeg, { AC_CODE: contra, LD_CODE: P, [contraCol]: value });
  };

  // ---- the fine cut into money, and the priced lines (01/02, 04/05) ----------------------------------
  const saleValue = money2(f.drAmt + f.slItmAmt);
  if (saleValue !== 0) {
    const account = slot(saleSlot);
    leg(code(1, 4), {
      AC_CODE: P,
      LD_CODE: account,
      DR_AMT: saleValue,
      IT_TYPE: f.itType,
      SIGN: '+',
      FINE_WT: round3(f.crFine),
      FINE_RATE: f.fineRate,
    });
    leg(code(2, 5), { AC_CODE: account, LD_CODE: P, CR_AMT: saleValue, FINE_RATE: f.fineRate });
  }
  if (ctx.tradeFine && f.crFine !== 0) {
    leg(code(3, 6), {
      AC_CODE: slot(purchaseSlot),
      LD_CODE: P,
      IT_TYPE: f.itType,
      SIGN: '-',
      FINE_WT: round3(f.crFine),
    });
  }

  // ---- money paid for a fine received (08/09, 11/12) -------------------------------------------------
  const purchaseValue = money2(f.crAmt + f.prItmAmt);
  if (purchaseValue !== 0) {
    const account = slot(purchaseSlot);
    leg(code(8, 11), {
      AC_CODE: P,
      LD_CODE: account,
      CR_AMT: purchaseValue,
      IT_TYPE: f.itType,
      SIGN: '-',
      FINE_WT: round3(f.drFine),
      FINE_RATE: f.fineRate,
    });
    leg(code(9, 12), { AC_CODE: account, LD_CODE: P, DR_AMT: purchaseValue });
  }
  if (ctx.tradeFine && f.drFine !== 0) {
    leg(code(10, 13), {
      AC_CODE: slot(saleSlot),
      LD_CODE: P,
      IT_TYPE: f.itType,
      SIGN: '+',
      FINE_WT: round3(f.drFine),
    });
  }

  // ---- labour and other charges (15-22) --------------------------------------------------------------
  if (f.slLbrAmt !== 0) pair(15, 16, slot('lbrAc'), 'DR', f.slLbrAmt);
  if (f.slOthAmt !== 0) pair(17, 18, slot('othAc'), 'DR', f.slOthAmt);
  if (f.prLbrAmt !== 0) pair(19, 20, slot('lbrExpAc'), 'CR', f.prLbrAmt);
  if (f.prOthAmt !== 0) pair(21, 22, slot('othAc'), 'CR', f.prOthAmt);

  // ---- the metal the voucher handles (23-26 issued, 29-32 received) ----------------------------------
  if (f.slFine !== 0) {
    const account = slot(saleSlot);
    const fineWt = round3(f.slFine);
    leg(code(23, 25), {
      AC_CODE: P,
      LD_CODE: account,
      IT_TYPE: f.itType,
      SIGN: '-',
      FINE_WT: fineWt,
    });
    if (ctx.tradeFine) {
      leg(code(24, 26), {
        AC_CODE: account,
        LD_CODE: P,
        IT_TYPE: f.itType,
        SIGN: '+',
        FINE_WT: fineWt,
      });
    }
  }
  if (f.prFine !== 0) {
    const account = slot(purchaseSlot);
    const fineWt = round3(f.prFine);
    leg(code(29, 31), {
      AC_CODE: P,
      LD_CODE: account,
      IT_TYPE: f.itType,
      SIGN: '+',
      FINE_WT: fineWt,
    });
    if (ctx.tradeFine) {
      leg(code(30, 32), {
        AC_CODE: account,
        LD_CODE: P,
        IT_TYPE: f.itType,
        SIGN: '-',
        FINE_WT: fineWt,
      });
    }
  }

  // ---- settlement: Received (sale) and Payment (purchase) columns (35-52) ----------------------------
  // Web adaptation kept from before: a cheque or card without its own account falls back to the cash slot.
  const bank = (account: string): string => account.trim() || slot('cashAc');
  if (f.slChqAmt !== 0) pair(35, 36, bank(ctx.bankAc), 'CR', f.slChqAmt);
  if (f.prChqAmt !== 0) pair(37, 38, bank(ctx.receivedBankAc), 'DR', f.prChqAmt);
  if (f.slCardAmt !== 0) pair(39, 40, bank(ctx.cardAc), 'CR', f.slCardAmt);
  if (f.prCardAmt !== 0) pair(41, 42, bank(ctx.receivedCardAc), 'DR', f.prCardAmt);
  if (f.slCashAmt !== 0) pair(43, 44, slot('cashAc'), 'CR', f.slCashAmt);
  if (f.prCashAmt !== 0) pair(45, 46, slot('cashAc'), 'DR', f.prCashAmt);
  // A positive received-side kasar is an allowance to the party (party Cr); a negative one is a charge.
  if (f.slKasarAmt > 0) pair(47, 48, slot('kasarAc'), 'CR', f.slKasarAmt);
  if (f.slKasarAmt < 0) pair(49, 50, slot('kasarAc'), 'DR', Math.abs(f.slKasarAmt));
  if (f.prKasarAmt !== 0) pair(51, 52, slot('kasarAc'), 'DR', f.prKasarAmt);

  return lines;
}

// ────────────────────────────────────────────────────────────────────────────
// PERSISTENCE ROWS (RATE_CUT_DATA header, RATE_CUT_ISU lines) — verified columns only
// ────────────────────────────────────────────────────────────────────────────

/** The header's derived totals — TR_WH_SALE.cs:12956-13050 and the band totals at :15633-15642. */
export interface RateCutHeaderTotals {
  /** `MSG2_TOTAL[1,4]` = round(DR_AMT + Σ issued NET_AMT): SL_NET_AMT and SL_TOT_AMT. */
  slNetAmt: number;
  /** `MSG2_TOTAL[1,3]` = round(CR_AMT + Σ received NET_AMT): PR_NET_AMT and PR_TOT_AMT. */
  prNetAmt: number;
  /** `MSG2_TOTAL[7,4]` = net − cheque − card − cash − kasar (the band's "Os Amt" row, derived, not typed). */
  slBillOs: number;
  prBillOs: number;
  /** `TotDrFine + DR_FINE + KSR_FINE_DR` and `TotCrFine + CR_FINE + KSR_FINE_CR` (fine kasar not modelled: 0). */
  totFineDr: number;
  totFineCr: number;
}

/**
 * Derive the header totals the desktop computes rather than accepts.
 *
 * `SL_BILL_OS` was taken from the request, and `SL_NET_AMT` from the lines alone. The desktop derives both: the
 * outstanding is the band's net less what was settled, and the net includes the money for the fine cut. On
 * Live24 064/00004 that gives `PR_BILL_OS` = 14965 − 15800 − 15 = −850, exactly the stored value.
 */
export function rateCutHeaderTotals(
  figures: RateCutPostingFigures,
  issuedNet: number,
  receivedNet: number,
): RateCutHeaderTotals {
  /**
   * The band arithmetic lives in `@datacare/core` (`wholesaleBand`) so the screen previews exactly what posts.
   * The net is `Math.Round(…, 0)` — banker's, as the desktop rounds it — where this used to round half-up, so a
   * 1000.50 net saved 1001 against the desktop's 1000.
   */
  const band = wholesaleBand({
    settlement: {
      drAmt: figures.drAmt,
      crAmt: figures.crAmt,
      drFine: figures.drFine,
      crFine: figures.crFine,
    },
    issued: { fine: figures.slFine, netAmount: issuedNet },
    received: { fine: figures.prFine, netAmount: receivedNet },
    receivedTender: {
      cash: figures.slCashAmt,
      cheque: figures.slChqAmt,
      card: figures.slCardAmt,
      kasar: figures.slKasarAmt,
    },
    paymentTender: {
      cash: figures.prCashAmt,
      cheque: figures.prChqAmt,
      card: figures.prCardAmt,
      kasar: figures.prKasarAmt,
    },
  });
  return {
    slNetAmt: band.receivedNet,
    prNetAmt: band.paymentNet,
    slBillOs: band.receivedOs,
    prBillOs: band.paymentOs,
    totFineDr: band.totFineDr,
    totFineCr: band.totFineCr,
  };
}

interface HeaderCtx {
  key: VoucherKey;
  input: RateCutInput;
  totals: RateCutTotals;
  receivedTotals: RateCutTotals;
  figures: RateCutPostingFigures;
  headerTotals: RateCutHeaderTotals;
  vchDate: Date;
  vchTime: Date;
  mainUser: string | null;
  rateBasis: 'G' | 'T' | 'K';
  settlement: SettlementResult;
  workflow: RateCutWorkflow;
}

function buildHeader(ctx: HeaderCtx): Record<string, unknown> {
  const { key, input, totals, receivedTotals, figures, headerTotals, vchDate } = ctx;
  const { rateBasis, settlement, workflow } = ctx;
  const p = input.pay ?? {};
  const rp = input.receivedPay ?? {};
  const fineRate = figures.fineRate;
  /**
   * TR_WH_SALE writes no tax on a wholesale or rate-cut voucher: `SL_TAX_AMT`, `PR_TAX_AMT` and `TAX_PRC` are the
   * literal 0 (TR_WH_SALE.cs:12992-13001). The bullion form carries GST (`Ac_Tax.Bul_Sales_GST`) and keeps the
   * computed figures.
   */
  const wholesale = workflow === 'wholesale';
  return {
    ...key,
    VCH_DATE: vchDate,
    VCH_TIME: ctx.vchTime,
    MAIN_USER: txt(ctx.mainUser, 15),
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
    /**
     * The settlement's OWN results (`BILL_TOTAL`, TR_WH_SALE.cs:15369-15503), not the request figures.
     *
     * `CR_FINE` / `DR_FINE` are what the voucher SETTLES in metal; `SL_FINE` / `PR_FINE` are what it HANDLES. When
     * the operator gives money and a rate, the desktop derives the fine and saves the derived value — so do we.
     * `DR_AMT` was 0 on every web rate cut because the header fine rate never reached the engine; on 034/5 the
     * desktop stores 3517 (0.541 × 6500) and on 034/6 32240 (4.960 × 6500).
     */
    DR_AMT: settlement.drAmt,
    CR_AMT: settlement.crAmt,
    CR_FINE: settlement.crFine,
    DR_FINE: settlement.drFine,
    SL_FINE: totals.totalFine,
    PR_FINE: receivedTotals.totalFine,
    /**
     * `nTotFineDr` / `nTotFineCr` (TR_WH_SALE.cs:15633-15634): the handled fine PLUS the settled fine. The web
     * wrote only `CR_FINE` into `TOT_FINE_CR` — 0.541 where the desktop has 24.541 on 034/5 (24.000 received plus
     * 0.541 cut) — so the voucher list, which shows these columns, halved or zeroed real movements.
     */
    TOT_FINE_DR: headerTotals.totFineDr,
    TOT_FINE_CR: headerTotals.totFineCr,
    SL_ITM_AMT: totals.totalItmAmt,
    SL_LBR_AMT: totals.totalLbr,
    SL_OTH_AMT: totals.totalOth,
    /**
     * `MSG2_TOTAL[1,4]` = round(DR_AMT + Σ line NET_AMT). The web used the line sum alone, with a fallback that
     * priced the cut fine only when the lines valued at zero — so a voucher with priced lines AND a cut lost the
     * cut. `wsale-034-00015` (CR_FINE 11.06 × 8900 = 98,434) is unchanged: its lines are 0 and DR_AMT is 98,434.
     */
    SL_TOT_AMT: headerTotals.slNetAmt,
    SL_TAX_AMT: wholesale ? 0 : totals.totalTax,
    SL_NET_AMT: headerTotals.slNetAmt,
    SL_CASH_AMT: figures.slCashAmt,
    SL_CHQ_AMT: figures.slChqAmt,
    SL_CARD_AMT: figures.slCardAmt,
    SL_KASAR_AMT: figures.slKasarAmt,
    SL_BILL_OS: headerTotals.slBillOs,
    PR_ITM_AMT: receivedTotals.totalItmAmt,
    PR_LBR_AMT: receivedTotals.totalLbr,
    PR_OTH_AMT: receivedTotals.totalOth,
    PR_TOT_AMT: headerTotals.prNetAmt,
    PR_TAX_AMT: wholesale ? 0 : receivedTotals.totalTax,
    PR_NET_AMT: headerTotals.prNetAmt,
    PR_CASH_AMT: figures.prCashAmt,
    PR_CHQ_AMT: figures.prChqAmt,
    PR_CARD_AMT: figures.prCardAmt,
    PR_KASAR_AMT: figures.prKasarAmt,
    PR_BILL_OS: headerTotals.prBillOs,
    TAX_CODE: p.taxCode ?? null,
    TAX_PRC: wholesale ? 0 : num(p.taxPct),
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

/** A line as it will be written: the request line with the tag's and the item's defaults applied. */
export interface EffectiveLine {
  line: RateCutLine;
  /** The reserved tag instance, when the voucher moves stock and the line names a tag. */
  tag?: ResolvedTagIdentity;
}

interface RowCtx {
  key: VoucherKey;
  input: RateCutInput;
  cls: BookClassification;
  vchDate: Date;
  /** `VCH_DATE + mTime` (TR_WH_SALE.cs:13139): the same stamp on header, lines and stock. */
  vchTime: Date;
  mainUser: string | null;
  workflow: RateCutWorkflow;
  /** `CO_SET.LBR_TYPE` — the receive grid's labour basis when a line names none. */
  companyLabourType: string;
}

const isTagged = (tagNo: unknown): boolean => {
  const t = String(tagNo ?? '').trim();
  return t !== '' && t.toUpperCase() !== 'N';
};

function buildLineRows(
  ctx: RowCtx,
  effective: EffectiveLine[],
  totals: RateCutTotals,
): Record<string, unknown>[] {
  const { key, input, cls, vchDate } = ctx;
  const wholesale = ctx.workflow === 'wholesale';
  return effective.map(({ line: l, tag }, i) => {
    const c = totals.computed[i]!;
    const ref = l.isuRef ?? {};
    const tagStock = tag?.stock ?? {};
    return {
      ...key,
      /**
       * `VCH_SRNO` is the TAG INSTANCE — `Conversion.Val(mSG[i, 57])`, filled from the tag's own `VCH_SRNO`
       * (TR_WH_SALE.cs:10095, :13136). The desktop rows of 034/4 carry 100312000009 and 100312000010; the web
       * wrote 0, so a sold tag could not be traced back to its stock row. A loose line has no instance: 0.
       */
      VCH_SRNO: tag ? tag.VCH_SRNO : isTagged(l.tagNo) ? num(l.vchSrno) : 0,
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
      TAG_NO: isTagged(l.tagNo) ? String(l.tagNo).trim() : 'N',
      /** A tag line's item is the TAG's item (TR_WH_SALE.cs:10049): the stock identity includes it. */
      IT_CODE: String(tag?.IT_CODE ?? '').trim() || l.itCode || null,
      DESIGN_NO: l.designNo ?? null,
      /**
       * Counter, size, hallmark and karigar the desktop copies from the tag onto the line (TR_WH_SALE.cs:10641-10736,
       * saved at :13089-13133). Missing on every web row: `TBL_CODE` '001', `KR_NAME` KJ/AB/SJ/YT, `ITM_SIZE` 3,
       * `HM_ID` UY76UY with its 12.000 g on the desktop rows of 034/4, 034/6 and Next25 034/1.
       */
      TBL_CODE: txt(l.tblCode, 3),
      ITM_SIZE: txt(l.itemSize, 20),
      HM_ID: txt(l.hallmarkId, 10),
      HM_ID_WT: num(l.hallmarkIdWt),
      KR_NAME: txt(l.karigarName, 5),
      VCH_TIME: ctx.vchTime,
      MAIN_USER: txt(ctx.mainUser, 15),
      ITM_PCS: num(l.pcs),
      ITM_GWT: num(l.grossWt),
      ITM_OTH_WT: num(l.othWt),
      ITM_NWT: c.netWt,
      ITM_GHT_WT: c.ghtWt,
      ITM_TOUCH: num(l.touch),
      ITM_WEST_PRC: num(l.westPct),
      ITM_FINE: c.fine,
      /**
       * A new grid row starts with the company's labour basis (`CommPassAdd`, TR_WH_SALE.cs:8362 col 34 =
       * `MsLbrType`); a tag then replaces it with the tag's own, blank included (Next23 034/4 saves '').
       */
      LBR_TYPE: l.lbrType ?? (wholesale ? txt(ctx.companyLabourType, 1) : null),
      LBR_RATE: num(l.lbrRate),
      LBR_AMT: c.lbrAmt,
      OTH_AMT: c.othAmt,
      ITM_RATE: c.rate,
      ITM_AMT: c.itmAmt,
      ITM_MRP: num(l.mrp),
      /**
       * TR_WH_SALE never computes grid column 43 (`TotAmt`) for a new line — it is only loaded back from
       * `TOT_AMT` on reopen — so a wholesale line saves 0 there while `NET_AMT` (column 41 = labour + other +
       * item amount, :9834) carries the value. Next25 034/1: `TOT_AMT` 0.00 with `NET_AMT` 500.00. The rule
       * lives in the grid arithmetic (`wholesaleIssueLine` returns `totalAmount: 0`), so the preview agrees.
       */
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
       * 'FINE GOLD' (6), 'DHAL OG' (4), 'L RING 916' and 'CHAIN 916' on Next23. The caller's description wins;
       * otherwise it is `ITEM_MAST.IT_NAME`, as the grid fills it when the item is entered (TR_WH_SALE.cs:11113).
       */
      ITM_REMARK: txt(l.itemName, 255),
      PR_CODE: txt(l.prCode, 2),
      /** Not assigned by the TR_WH_SALE save (:13062-13141): 0 on Next25 034/1 where the web wrote the pieces. */
      FINE_CUT_PCS: wholesale ? 0 : num(l.pcs),
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
      // OFine is derived on the TR_WH_SALE grid (col 39 = OthAmt / ORate); elsewhere it is as supplied.
      ITM_OTH_FINE: wholesale ? c.otherFine : Number(l.otherFine) || 0,
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
      // A reserved tag's own weights, when the caller gives none (grid columns 98/99 come from the tag).
      TAG_GWT: hasValue(l.tagGrossWt)
        ? Number(l.tagGrossWt)
        : tag && tagStock.ITM_GWT != null
          ? num(tagStock.ITM_GWT)
          : num(l.grossWt),
      TAG_NWT: hasValue(l.tagNetWt)
        ? Number(l.tagNetWt)
        : tag && tagStock.ITM_NWT != null
          ? num(tagStock.ITM_NWT)
          : c.netWt,
      MCX_RATE: Number(l.mcxRate) || 0,
      HM_FINE: Number(l.hallmarkFine) || 0,
      OLD_VCH_NO: null,
      NEW_VCH_NO: null,
    };
  });
}

/**
 * RATE_CUT_REC rows. The two desktop forms write different shapes, both measured:
 *
 *  - TR_WH_SALE (:13255-13320) writes `HM_ID_WT` 0, no `HM_ID2-4`, no `ISU_*` link, no `TAG_NWT`, no
 *    `OLD_VCH_SRNO`, and `EMP_CODE` from the header; `LBR_TYPE` is the grid's, which a new row takes from the
 *    company basis. The Next23/Next25 rows of 034/5, 034/6 and 034/2 show every one of these — `LBR_TYPE` G/N,
 *    `HM_ID_WT` 0.000 (web: the gross weight), `HM_ID2-4` NULL (web ''), `ISU_LC_CODE` NULL (web '00'),
 *    `EMP_CODE` 001 (web blank), `TAG_NWT` / `OLD_VCH_SRNO` 0 and `APR_ISU` / `EMP_ISU` 'N' (Next25).
 *  - TR_BUL_SALE (:9026-9100) links each received line to its booking (`ISU_*`, `ISU_LC_CODE` = location) and
 *    keeps the MCX quote; it is left as it was, apart from `HM_ID_WT`, which neither form fills from the weight.
 */
function buildReceivedLineRows(
  ctx: RowCtx,
  lines: RateCutLine[],
  totals: RateCutTotals,
): Record<string, unknown>[] {
  const { key, input, cls, vchDate } = ctx;
  const wholesale = ctx.workflow === 'wholesale';
  return lines.map((l, i) => {
    const c = totals.computed[i]!;
    const ref = l.isuRef ?? {};
    return {
      ...key,
      VCH_DATE: vchDate,
      VCH_TIME: ctx.vchTime,
      HD_VCH_NO: input.hdVchNo ?? null,
      AC_CODE: input.acCode,
      VCH_TYPE: cls.vchType,
      INOUT_TYPE: cls.inoutType,
      ENTRY_TYPE: 'P',
      BOOK_NAME: cls.bookName,
      SR_NO: i + 1,
      OLD_SRNO: i + 1,
      VCH_SRNO: 0,
      OLD_VCH_SRNO: wholesale ? 0 : i + 1,
      IT_CODE: l.itCode ?? null,
      ITM_REMARK: txt(l.itemName, 50),
      TBL_CODE: txt(l.tblCode, 3),
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
      LBR_TYPE: l.lbrType ?? (wholesale ? txt(ctx.companyLabourType, 1) : null),
      LBR_RATE: num(l.lbrRate),
      LBR_AMT: c.lbrAmt,
      OTH_AMT: c.othAmt,
      ITM_OTH_RATE: Number(l.otherRate) || 0,
      ITM_OTH_FINE: wholesale ? c.otherFine : Number(l.otherFine) || 0,
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
      TAG_NWT: hasValue(l.tagNetWt) ? Number(l.tagNetWt) : wholesale ? 0 : c.netWt,
      ISU_NO: ref.no ?? null,
      ISU_LC_CODE: txt(l.issueLcCode, 2) ?? (wholesale ? null : String(key.LC_CODE ?? '')),
      ISU_YRCD: ref.yrcd ?? null,
      ISU_DBCD: ref.dbcd ?? null,
      ISU_SRNO: ref.srno ?? null,
      WITH_STOCK: 'Y',
      MAIN_USER: txt(ctx.mainUser, 15),
      ...(wholesale ? { EMP_CODE: input.empCode ?? null, APR_ISU: 'N', EMP_ISU: 'N' } : {}),
      HM_ID_WT: 0,
      HM_ID2_WT: 0,
      HM_ID3_WT: 0,
      HM_ID4_WT: 0,
      FINE_CUT_PCS: wholesale ? 0 : num(l.pcs),
      FINE_CUT_GWT: 0,
      FINE_CUT_NWT: 0,
      FINE_CUT_FINE: 0,
      PR_CODE: txt(l.prCode, 2),
    };
  });
}

/**
 * MAIN_STOCK rows — `Ac_Stock.Wh_Sale_Stk` (Ac_Stock.cs:146-176), built from the very rows written above so the
 * two can never disagree, which is what the desktop's `INSERT … SELECT FROM RATE_CUT_ISU / RATE_CUT_REC` gives.
 *
 *   issued line   → SR_NO 1, TR_TYPE 'S', ITM_SIGN '-', the line's tag and tag instance, KR_* and TAG_COST
 *   received line → SR_NO 2, TR_TYPE 'P', ITM_SIGN '+', TAG_NO 'N', VCH_SRNO 0, ITM_MRP 0, KR_* = the line's
 *                   own net weight / touch / wastage / fine, KR_COST 0, ITM_LOT ''
 *
 * `ITM_NWT` is the net weight, except that old gold / old silver (`IT_CODE` OG / OS) takes the GROSS weight when
 * `CO_SET_NEW.OLD_GOLD_TYPE` is 'G' (`MsOldGoldType`, blank → 'N', MS_OPNCOMP.cs:1132-1135).
 *
 * The web wrote no stock at all, so a sold tag stayed in stock and could be sold again, and received metal never
 * reached the stock register. SR_NO 7 (approval return), 4 (tour) and 5/6 (tag weight difference) are deferred.
 */
function buildStockRows(
  ctx: RowCtx,
  issuedRows: Record<string, unknown>[],
  receivedRows: Record<string, unknown>[],
  oldGoldType: string,
): Record<string, unknown>[] {
  const { key, cls } = ctx;
  const stockDate = ctx.vchDate.toISOString().slice(0, 10);
  const netFor = (row: Record<string, unknown>): number => {
    const itCode = String(row.IT_CODE ?? '')
      .trim()
      .toUpperCase();
    return (itCode === 'OG' || itCode === 'OS') && oldGoldType === 'G'
      ? num(row.ITM_GWT)
      : num(row.ITM_NWT);
  };
  const common = (row: Record<string, unknown>) => ({
    ...key,
    ISR_NO: num(row.SR_NO),
    VCH_DATE: ctx.vchDate,
    STK_DATE: stockDate,
    VCH_TYPE: txt(cls.vchType, 6),
    BOOK_NAME: cls.bookName,
    AC_CODE: row.AC_CODE ?? null,
    IT_CODE: row.IT_CODE ?? null,
    TBL_CODE: row.TBL_CODE ?? null,
    ITM_QTY: 1,
    ITM_PCS: num(row.ITM_PCS),
    ITM_GWT: num(row.ITM_GWT),
    ITM_NWT: netFor(row),
    ITM_TOUCH: num(row.ITM_TOUCH),
    ITM_WEST: num(row.ITM_WEST_PRC),
    ITM_FINE: num(row.ITM_FINE),
    ITM_RATE: num(row.ITM_RATE),
    ITM_AMT: num(row.ITM_AMT),
    LBR_RATE: num(row.LBR_RATE),
    LBR_AMT: num(row.LBR_AMT),
    OTH_AMT: num(row.OTH_AMT),
    NET_AMT: num(row.NET_AMT),
    KR_LBR_AMT: 0,
    KR_OTH_AMT: 0,
    EMP_CODE: txt(row.EMP_CODE, 3),
    ENTRY_TIME: ctx.vchDate,
    MAIN_USER: txt(row.MAIN_USER, 15),
    DATA_TYPE: txt(cls.dataType, 1) ?? 'A',
    DESIGN_NO: row.DESIGN_NO ?? null,
    ITM_SIZE: txt(row.ITM_SIZE, 20),
    ITM_DESC: txt(row.ITM_REMARK, 255),
    GHT_PRC: 0,
    ITM_DISC: '0',
  });
  return [
    ...issuedRows.map((row) => ({
      ...common(row),
      SR_NO: 1,
      TAG_NO: txt(row.TAG_NO, 15) ?? 'N',
      VCH_SRNO: num(row.VCH_SRNO),
      TR_TYPE: 'S',
      ITM_SIGN: '-',
      ITM_MRP: num(row.ITM_MRP),
      KR_NWT: num(row.KR_NET_WT),
      KR_TOUCH: num(row.KR_TOUCH),
      KR_WEST: num(row.KR_WEST_PRC),
      KR_FINE: num(row.KR_FINE),
      KR_COST: num(row.TAG_COST),
      ITM_LOT: txt(row.ITM_LOT, 255),
    })),
    ...receivedRows.map((row) => ({
      ...common(row),
      SR_NO: 2,
      TAG_NO: 'N',
      VCH_SRNO: 0,
      TR_TYPE: 'P',
      ITM_SIGN: '+',
      ITM_MRP: 0,
      KR_NWT: num(row.ITM_NWT),
      KR_TOUCH: num(row.ITM_TOUCH),
      KR_WEST: num(row.ITM_WEST_PRC),
      KR_FINE: num(row.ITM_FINE),
      KR_COST: 0,
      ITM_LOT: '',
    })),
  ];
}

// ────────────────────────────────────────────────────────────────────────────
// POST / DELETE
// ────────────────────────────────────────────────────────────────────────────

/**
 * Post a RATE CUT / WHOLESALE voucher. Numbering, tag reservation, ledger and table writes commit atomically in
 * one tenant transaction; assertBalanced (Σ DR = Σ CR) and the period-lock check run inside postVoucherTx.
 *
 * Writes RATE_CUT_DATA (header), RATE_CUT_ISU / RATE_CUT_REC (lines), AC_DATA (`Wh_Sales_Ledr`), MAIN_STOCK
 * (`Wh_Sale_Stk`, on a stock-moving book) and ROJ_MEL_DATA. Still open: SL_IDTL / DM_DATA from the tag's
 * stones (`Dm_Wh_Tour_Sale_Detl`); the delete path already reverses those tables.
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
export async function readRateCut(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
  options: { bookGuard?: RateCutBookGuard } = {},
): Promise<Record<string, unknown>> {
  const voucherNo = formatVoucherNo(requestedVoucherNo);
  const key = keyOf(scope, Number(voucherNo), scope.coBook ?? RCT_BOOK);
  const t = (v: unknown) => String(v ?? '').trim();
  const n = (v: unknown) => Number(v ?? 0);
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
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
              "DR_AMT","CR_AMT","DR_FINE","CR_FINE","SL_FINE","MAIN_USER",
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
              "ISU_DBCD","ISU_NO","ISU_SRNO","ISU_LC_CODE",
              "TBL_CODE","ITM_SIZE","HM_ID","HM_ID_WT","KR_NAME"
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
      // The settlement as stored (BILL_TOTAL), so an edit round-trips what was typed or derived.
      settleDrAmt: n(h.DR_AMT),
      settleCrAmt: n(h.CR_AMT),
      settleDrFine: n(h.DR_FINE),
      settleCrFine: n(h.CR_FINE),
      mainUser: t(h.MAIN_USER),
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
        tblCode: t(l.TBL_CODE),
        itemSize: t(l.ITM_SIZE),
        hallmarkId: t(l.HM_ID),
        hallmarkIdWt: n(l.HM_ID_WT),
        karigarName: t(l.KR_NAME),
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

export async function writeRateCut(
  prisma: any,
  input: RateCutInput,
  options: { vchNo?: number | string; bookGuard?: RateCutBookGuard } = {},
): Promise<RateCutResult> {
  const customer = (input.acCode ?? '').toString().trim();
  if (!customer) throw new RateCutValidationError('rate-cut requires a party (customer) account');
  const issuedInput = input.lines ?? [];
  const receivedInput = input.receivedLines ?? [];
  /**
   * A HEADER-ONLY rate cut is a real voucher: all 25 rate cuts on Live24 book 064 have no detail rows at all and
   * carry the cut entirely in `DR_FINE`/`CR_FINE` × `FINE_RATE`. `Wh_Sales_Ledr` posts them from the header
   * alone (legs 01/02 and 08/09), so a voucher with no lines is accepted when it settles something.
   */
  const settles = [
    input.settleDrAmt,
    input.settleCrAmt,
    input.settleDrFine,
    input.settleCrFine,
  ].some((value) => num(value) !== 0);
  if (!issuedInput.length && !receivedInput.length && !settles) {
    throw new RateCutValidationError(
      'rate-cut requires at least one issued or received line, or a money/fine settlement',
    );
  }
  const quotation = options.bookGuard === 'wholesale-quotation';
  const workflow: RateCutWorkflow = options.bookGuard === 'bullion-sale' ? 'bullion' : 'wholesale';
  const itType: 'G' | 'S' = input.itType === 'S' ? 'S' : 'G';
  const vchDate = input.vchDate ? new Date(input.vchDate) : new Date();
  if (Number.isNaN(vchDate.getTime())) {
    throw new RateCutValidationError(`invalid voucher date: ${String(input.vchDate)}`);
  }
  const tenantId = input.scope.tenantId;
  const p = input.pay ?? {};
  const rp = input.receivedPay ?? {};

  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    // The metal-rate basis is a company setting, never a request field: it changes every derived figure.
    const behavior = await resolveSettingsBehaviorTx(tx, {
      tenantId,
      coCode: input.scope.coCode,
    });
    const settings = await readWholesaleSettingsTx(tx, tenantId, input.scope.coCode);
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
    const classification = await resolveBookClassification(
      tx,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      key.CO_BOOK,
    );
    assertRateCutBookGuard(classification, key.CO_BOOK, options.bookGuard);
    const movesStock = bookMovesStock(classification);

    /**
     * An EDIT is delete-and-rebuild in one transaction (TR_WH_SALE.cs:12756-13411). Its tags are given back
     * first — a `TAG_STOCK`-only tag is re-inserted, a `BAR_DETL` tag is freed when its '-' row goes — so the
     * rewrite can reserve the same tags again and a tag dropped from the voucher returns to stock. A reopened
     * voucher keeps its own time and `MAIN_USER` (TR_WH_SALE.cs:12196, :12325).
     */
    let persistedClock: string | undefined;
    let persistedUser: string | undefined;
    let hiddenVoucherNo = '';
    if (options.vchNo != null) {
      const prior = await persistedHeaderTx(tx, tenantId, key);
      persistedClock = prior?.VCH_CLOCK ? String(prior.VCH_CLOCK) : undefined;
      persistedUser = String(prior?.MAIN_USER ?? '').trim() || undefined;
      hiddenVoucherNo = String(prior?.HD_VCH_NO ?? '').trim();
      const restores = quotation ? [] : await releaseRateCutTagsTx(tx, tenantId, key);
      if (!quotation) await applyBookingDrawDownTx(tx, tenantId, key, -1);
      await reverseVoucherTx(tx, tenantId, { tables: RATE_CUT_WRITE_TABLES, key });
      if (hiddenVoucherNo) {
        await tx.$executeRawUnsafe(
          `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
            AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
          tenantId,
          key.CO_CODE,
          key.LC_CODE,
          key.CO_BOOK,
          hiddenVoucherNo,
        );
      }
      for (const tag of restores) await restoreTagTx(tx, tenantId, tag);
    }
    if (!hiddenVoucherNo) {
      const requested = String(input.hdVchNo ?? '').trim();
      hiddenVoucherNo = requested
        ? formatVoucherNo(requested)
        : await nextHiddenVoucherNoTx(tx, { ...input.scope, coBook: key.CO_BOOK });
    }
    const accounts = quotation
      ? ({} as RateCutAccounts)
      : await resolveBookAccounts(
          tx,
          tenantId,
          key.CO_CODE,
          key.LC_CODE,
          key.CO_BOOK,
          input.accounts,
        );
    /**
     * Choosing the party fills its name and mobile from the account master (TR_WH_SALE.cs:14621-14623,
     * `tAcName = AC_NAME`, `tMobile = AC_MOBILE`); the address lines and city are typed. An explicit value wins.
     * All three Next23 vouchers carry the party's mobile 9856525, which the web left blank.
     */
    const party = await readPartyTx(tx, tenantId, key.CO_CODE, key.LC_CODE, customer);
    const voucherInput: RateCutInput = {
      ...input,
      hdVchNo: hiddenVoucherNo,
      acName: hasValue(input.acName) ? input.acName : (party?.name ?? input.acName),
      mobile: hasValue(input.mobile) ? input.mobile : (party?.mobile ?? input.mobile),
    };

    // Reserve each issued tag instance inside this transaction, then apply the tag's and item's defaults.
    const tags = movesStock
      ? await reserveIssuedTagsTx(tx, key, issuedInput)
      : issuedInput.map(() => undefined);
    const items = await readItemsTx(tx, tenantId, key.CO_CODE, [
      ...issuedInput.map((line) => String(line.itCode ?? '')),
      ...tags.map((tag) => String(tag?.IT_CODE ?? '')),
      ...receivedInput.map((line) => String(line.itCode ?? '')),
    ]);
    /**
     * A new grid row starts on the company's labour basis — `CommPassAdd` col 34 and `CommPassAdd_Pr` col 23 are
     * set to `MsLbrType` (TR_WH_SALE.cs:8362, :6324) — and its labour is computed on that basis. The web wrote the
     * basis on the row but computed the labour gross-wise, so a company on net-wise labour posted gross-wise
     * amounts. A tag's own basis, blank included, is applied first and wins (:10702).
     */
    const withLabourBasis = (line: RateCutLine): RateCutLine =>
      workflow === 'wholesale' && line.lbrType == null
        ? { ...line, lbrType: companyLabourType(behavior.labourType) as RateCutLine['lbrType'] }
        : line;
    const effective: EffectiveLine[] = issuedInput.map((line, index) => {
      const tag = tags[index];
      const itCode = String(tag?.IT_CODE ?? line.itCode ?? '').trim();
      return {
        line: withLabourBasis(withDesktopDefaults(line, 'issue', tag?.stock, items.get(itCode))),
        ...(tag ? { tag } : {}),
      };
    });
    const receivedLines = receivedInput.map((line) =>
      withLabourBasis(
        withDesktopDefaults(
          line,
          'receive',
          undefined,
          items.get(String(line.itCode ?? '').trim()),
        ),
      ),
    );
    const issuedLines = effective.map((entry) => entry.line);
    // The TR_WH_SALE grid arithmetic (labour from its basis, conversion rate, less weight / hallmark fine, other
    // fine) on the wholesale workflow; TR_BUL_SALE's grid is not derived yet and keeps the older rule.
    const lineMath: LineMath =
      workflow === 'wholesale'
        ? {
            wholesale: {
              labourIncludesGhat: behavior.labourIncludesGhat,
              companyLabourType: companyLabourType(behavior.labourType),
            },
          }
        : {};
    const totals = rollup(issuedLines, itType, input.fineRate, { ...lineMath, side: 'issue' });
    const receivedTotals = rollup(receivedLines, itType, input.fineRate, {
      ...lineMath,
      side: 'receive',
    });

    // BILL_TOTAL: the header fine rate reaches the engine (it never did, so DR_AMT stayed 0 on every cut).
    const settlement = settleMoneyMetal({
      convRate: input.convRate,
      convPct: input.convPct,
      fineRate: input.fineRate,
      drAmt: input.settleDrAmt,
      crAmt: input.settleCrAmt,
      drFine: input.settleDrFine,
      crFine: input.settleCrFine,
      ratePar: behavior.rateBasis,
    });
    const figures: RateCutPostingFigures = {
      itType,
      /**
       * `FINE_RATE` is the header rate `nFineRate` and nothing else (TR_WH_SALE.cs:12975, TR_BUL_SALE alike): it is
       * typed or derived by BILL_TOTAL, never copied from a line. The web used the first line's rate when the
       * header had none, which put a rate on legs 01/02 that the desktop leaves at 0.
       */
      fineRate: settlement.fineRate,
      drAmt: settlement.drAmt,
      crAmt: settlement.crAmt,
      drFine: settlement.drFine,
      crFine: settlement.crFine,
      slFine: totals.totalFine,
      prFine: receivedTotals.totalFine,
      slItmAmt: totals.totalItmAmt,
      prItmAmt: receivedTotals.totalItmAmt,
      slLbrAmt: totals.totalLbr,
      slOthAmt: totals.totalOth,
      prLbrAmt: receivedTotals.totalLbr,
      prOthAmt: receivedTotals.totalOth,
      /**
       * A band cell keeps what was typed, formatted "0.00" (`MSG2_TOTAL_LeaveCell`, TR_WH_SALE.cs:15041-15047),
       * and is saved as `Val(cell)` (:12996-13014). These were rounded to whole rupees, so a cash receipt of
       * 1000.50 posted 1001 on the ledger and the outstanding moved by the same 50 paise.
       */
      slChqAmt: money2(p.chq),
      slCardAmt: money2(p.card),
      slCashAmt: money2(p.cash),
      slKasarAmt: money2(p.kasar),
      prChqAmt: money2(rp.chq),
      prCardAmt: money2(rp.card),
      prCashAmt: money2(rp.cash),
      prKasarAmt: money2(rp.kasar),
    };
    const postsSomething = [
      figures.slFine,
      figures.prFine,
      totals.totalNet,
      receivedTotals.totalNet,
      figures.drAmt,
      figures.crAmt,
      figures.drFine,
      figures.crFine,
    ].some((value) => num(value) !== 0);
    if (!postsSomething) {
      throw new RateCutValidationError('rate-cut voucher has no fine and no value to post');
    }
    const headerTotals = rateCutHeaderTotals(figures, totals.totalNet, receivedTotals.totalNet);
    const vchTime = voucherTimestamp(vchDate, persistedClock);
    const mainUser = persistedUser ?? (String(input.mainUser ?? '').trim() || null);
    const rowCtx: RowCtx = {
      key,
      input: voucherInput,
      cls: classification,
      vchDate,
      vchTime,
      mainUser,
      workflow,
      companyLabourType: companyLabourType(behavior.labourType),
    };

    const bankAc = String(p.bankAc ?? '').trim();
    const cardAc = String(p.cardAc ?? '').trim();
    const receivedBankAc = String(rp.bankAc ?? '').trim() || bankAc;
    const receivedCardAc = String(rp.cardAc ?? '').trim() || cardAc;
    const ledger = quotation
      ? []
      : buildRateCutLedger(key, {
          customer,
          figures,
          accounts,
          bankAc,
          cardAc,
          receivedBankAc,
          receivedCardAc,
          tradeFine: settings.tradeFine,
          vchDate,
          vchType: classification.vchType,
          bookName: classification.bookName,
          coBook: key.CO_BOOK,
          billNo: txt(input.billNo, 30) ?? undefined,
          hdVchNo: hiddenVoucherNo,
        });
    const gold = itType === 'G';
    // The Rojmel (day book), from the header's settlement figures. `buildRateCutRojmel` documents its inputs as
    // the SETTLED fine (`DR_FINE` / `CR_FINE`) and the band's outstanding; it was handed the lines' total fine and
    // the request's bill-outstanding instead. With the settled figures, header-only Live24 064/00004 gives its
    // four real rows: 01 (Dr fine 2.050 at 7300), 02 (14965), 13 (overpaid 850) and 26 (purchase kasar 15).
    // Remaining alignment for lined wholesale vouchers (types 05/06/14/27, the book-prefixed name) is open.
    const rojmelRows = quotation
      ? []
      : buildRateCutRojmel(
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
            partyName: voucherInput.acName ?? '',
            partyCode: customer,
          },
          {
            // BOOK_DETL slots are PER-BOOK: on the desktop's 064 slot 1 is 00003 and slot 2 is 00008, where
            // on book 026 slot 2 is 00001. Resolved rather than hardcoded for that reason.
            saleAc: String((gold ? accounts.goldAc : accounts.silverSaleAc) ?? ''),
            purchaseAc: String((gold ? accounts.purchaseAc : accounts.silverPurcAc) ?? ''),
            kasarFineAc: String(accounts.fineKasarAc ?? accounts.kasarAc ?? ''),
            purchaseKasarAc: String(accounts.purchaseKasarAc ?? accounts.kasarAc ?? ''),
            bankAc: receivedBankAc || String(accounts.cashAc ?? ''),
            metal: rojmelMetalFor(itType),
            fineRate: figures.fineRate,
            drFine: figures.drFine,
            crFine: figures.crFine,
            purchaseBillOs: headerTotals.prBillOs,
            saleBillOs: headerTotals.slBillOs,
            purchaseAmount: money2(figures.crAmt + figures.prItmAmt),
            saleAmount: money2(figures.drAmt + figures.slItmAmt),
            kasarFineDr: 0,
            kasarFineCr: 0,
            purchaseChequeAmount: figures.prChqAmt,
            purchaseKasarAmount: figures.prKasarAmt,
          },
        );
    const issuedRows = buildLineRows(rowCtx, effective, totals);
    const receivedRows = buildReceivedLineRows(rowCtx, receivedLines, receivedTotals);
    const stockRows = movesStock
      ? buildStockRows(rowCtx, issuedRows, receivedRows, settings.oldGoldType)
      : [];
    await insertRowTx(tx, 'TEMP_BOOK_DATA', tenantId, {
      CO_CODE: key.CO_CODE,
      LC_CODE: key.LC_CODE,
      CO_BOOK: key.CO_BOOK,
      VCH_NO: hiddenVoucherNo,
      BOOK_NAME: classification.displayName || classification.bookName,
    });
    await postVoucherTx(tx, tenantId, {
      ledger: { table: 'AC_DATA', lines: ledger },
      bookName: classification.bookName,
      // PARTY_AC_CODE is the party on its own legs and '' on contra legs (Wh_Sales_Ledr, every leg).
      partyAc: customer,
      writes: [
        {
          table: 'RATE_CUT_DATA',
          rows: [
            buildHeader({
              key,
              input: voucherInput,
              totals,
              receivedTotals,
              figures,
              headerTotals,
              vchDate,
              vchTime,
              mainUser,
              rateBasis: behavior.rateBasis,
              settlement,
              workflow,
            }),
          ],
        },
        { table: 'RATE_CUT_ISU', rows: issuedRows },
        { table: 'RATE_CUT_REC', rows: receivedRows },
        ...(stockRows.length ? [{ table: 'MAIN_STOCK', rows: stockRows }] : []),
        ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
      ],
    });
    if (!quotation) await applyBookingDrawDownTx(tx, tenantId, key, 1);
    return {
      vchNo: no,
      // The metal on the voucher, issued plus received, priced or not.
      fine: round3(totals.handledFine + receivedTotals.handledFine),
      netAmt: round0(headerTotals.slNetAmt + headerTotals.prNetAmt),
      settlement: {
        fineRate: figures.fineRate,
        drAmt: figures.drAmt,
        crAmt: figures.crAmt,
        drFine: figures.drFine,
        crFine: figures.crFine,
      },
    };
  });
}

/**
 * Every table the TR_WH_SALE delete clears (TR_WH_SALE.cs:13575-13588) that this family writes or may carry.
 * `TEMP_BOOK_DATA` is not in this array because it has no `CO_YEAR`; create/edit/delete manage its
 * hidden-voucher identity separately by company, location, book and HD_VCH_NO.
 */
const RATE_CUT_WRITE_TABLES = [
  'RATE_CUT_DATA',
  'RATE_CUT_ISU',
  'RATE_CUT_REC',
  'SL_IDTL',
  'AC_DATA',
  'ROJ_MEL_DATA',
  'MAIN_STOCK',
  'DM_DATA',
];

/** `CO_SET.TRAD_FINE` (blank → N, MS_OPNCOMP.cs:813-816) and `CO_SET_NEW.OLD_GOLD_TYPE` (blank → N, :1132-1135). */
async function readWholesaleSettingsTx(
  tx: any,
  tenantId: string,
  coCode: string,
): Promise<{ tradeFine: boolean; oldGoldType: string }> {
  const rows: Array<{ trad_fine: string | null; old_gold_type: string | null }> =
    await tx.$queryRawUnsafe(
      `SELECT (SELECT upper(btrim(coalesce("TRAD_FINE"::text,''))) FROM "CO_SET"
                WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text ORDER BY row_id LIMIT 1) AS trad_fine,
              (SELECT upper(btrim(coalesce("OLD_GOLD_TYPE"::text,''))) FROM "CO_SET_NEW"
                WHERE tenant_id=$1 AND "CO_CODE"::text=$2::text LIMIT 1) AS old_gold_type`,
      tenantId,
      String(coCode),
    );
  const row = rows[0];
  return {
    tradeFine: String(row?.trad_fine ?? '') === 'Y',
    oldGoldType: String(row?.old_gold_type ?? '') || 'N',
  };
}

/** The party's name and mobile as the account master holds them (TR_WH_SALE.cs:14621-14623). */
async function readPartyTx(
  tx: any,
  tenantId: string,
  coCode: string,
  lcCode: string,
  acCode: string,
): Promise<{ name?: string; mobile?: string } | undefined> {
  const rows: Array<{ AC_NAME: string | null; AC_MOBILE: string | null; LC_CODE: string | null }> =
    await tx.$queryRawUnsafe(
      `SELECT "AC_NAME","AC_MOBILE","LC_CODE" FROM "AC_MAST"
        WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "AC_CODE"=$3
        ORDER BY ("LC_CODE"=$4) DESC, row_id LIMIT 1`,
      tenantId,
      coCode,
      acCode,
      lcCode,
    );
  const row = rows[0];
  if (!row) return undefined;
  const text = (value: unknown): string | undefined => String(value ?? '').trim() || undefined;
  return { name: text(row.AC_NAME), mobile: text(row.AC_MOBILE) };
}

interface ItemInfo {
  name: string;
  prCode: string;
  rateType: string;
}

/** The item master fields a grid row takes when the item is entered (TR_WH_SALE.cs:11109-11116). */
async function readItemsTx(
  tx: any,
  tenantId: string,
  coCode: string,
  codes: string[],
): Promise<Map<string, ItemInfo>> {
  const wanted = [...new Set(codes.map((code) => code.trim()).filter(Boolean))];
  const out = new Map<string, ItemInfo>();
  if (!wanted.length) return out;
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "IT_CODE","IT_NAME","PR_CODE","RATE_TYPE" FROM "ITEM_MAST"
      WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "IT_CODE" = ANY($3::text[])`,
    tenantId,
    coCode,
    wanted,
  );
  const trim = (value: unknown): string => String(value ?? '').trim();
  for (const row of rows) {
    out.set(trim(row.IT_CODE), {
      name: trim(row.IT_NAME),
      prCode: trim(row.PR_CODE),
      rateType: trim(row.RATE_TYPE).toUpperCase(),
    });
  }
  return out;
}

const LABOUR_TYPES = new Set(['G', 'N', 'K', 'P']);
const RATE_TYPES = new Set(['G', '1', 'K', 'P']);

/** `MsLbrType` = `CO_SET.LBR_TYPE`, blank read as 'G' (MS_OPNCOMP.cs:664, :733-735). */
function companyLabourType(value: unknown): string {
  return (
    String(value ?? '')
      .trim()
      .toUpperCase()
      .slice(0, 1) || 'G'
  );
}

/**
 * Fill what the desktop grid fills when a tag or item is entered, leaving everything the caller supplied alone.
 *
 * A tag (TR_WH_SALE.cs:10641-10736) brings its weights, ghat %, touch, wastage and stored fine, its counter,
 * design, size, hallmark, karigar and product, its labour basis, labour rate, labour and other amounts, its item
 * rate, rate type, MRP and cost (`KR_COST` → TagCost, col 58). An item (:11109-11116) brings its name, product
 * and rate type. So an API caller can sell a tag by number alone, as the operator does, and the rows carry the
 * desktop's values instead of blanks. The receive grid has no tags and does not save a product (:13255-13320).
 */
function withDesktopDefaults(
  line: RateCutLine,
  side: 'issue' | 'receive',
  tag: Record<string, unknown> | undefined,
  item: ItemInfo | undefined,
): RateCutLine {
  const out: RateCutLine = { ...line };
  const text = (value: unknown): string => String(value ?? '').trim();
  if (tag) {
    const weighed = line.grossWt != null || line.netWt != null;
    if (!weighed) {
      if (tag.ITM_GWT != null) out.grossWt = num(tag.ITM_GWT);
      if (tag.ITM_NWT != null) out.netWt = num(tag.ITM_NWT);
      if (line.othWt == null && tag.ITM_OTH_WT != null) out.othWt = num(tag.ITM_OTH_WT);
    }
    if (line.pcs == null && tag.ITM_PCS != null) out.pcs = num(tag.ITM_PCS);
    if (line.ghtPct == null && tag.ITM_GHT_PRC != null) out.ghtPct = num(tag.ITM_GHT_PRC);
    if (line.touch == null && tag.ITM_TOUCH != null) out.touch = num(tag.ITM_TOUCH);
    if (line.westPct == null && tag.ITM_WEST_PRC != null) out.westPct = num(tag.ITM_WEST_PRC);
    // The tag's stored fine stands while the operator changes neither weight nor purity (:10697).
    if (
      line.fine == null &&
      !weighed &&
      line.touch == null &&
      line.westPct == null &&
      line.ghtPct == null &&
      line.ghtWt == null &&
      tag.ITM_FINE != null
    ) {
      out.fine = num(tag.ITM_FINE);
    }
    if (line.lbrRate == null && tag.LBR_RATE != null) out.lbrRate = num(tag.LBR_RATE);
    if (line.lbrAmt == null && tag.LBR_AMT != null) out.lbrAmt = num(tag.LBR_AMT);
    if (line.othAmt == null && tag.OTH_AMT != null) out.othAmt = num(tag.OTH_AMT);
    if (line.rate == null && tag.ITM_RATE != null) out.rate = num(tag.ITM_RATE);
    if (line.mrp == null && tag.ITM_MRP != null) out.mrp = num(tag.ITM_MRP);
    if (line.tagCost == null && tag.KR_COST != null) out.tagCost = num(tag.KR_COST);
    if (!hasValue(line.tblCode) && text(tag.TBL_CODE)) out.tblCode = text(tag.TBL_CODE);
    if (!hasValue(line.designNo) && text(tag.DESIGN_NO)) out.designNo = text(tag.DESIGN_NO);
    if (!hasValue(line.itemSize) && text(tag.ITM_SIZE)) out.itemSize = text(tag.ITM_SIZE);
    if (!hasValue(line.hallmarkId) && text(tag.HM_ID)) out.hallmarkId = text(tag.HM_ID);
    if (line.hallmarkIdWt == null && tag.HM_ID_WT != null) out.hallmarkIdWt = num(tag.HM_ID_WT);
    if (!hasValue(line.karigarName) && text(tag.KR_NAME)) out.karigarName = text(tag.KR_NAME);
    if (!hasValue(line.prCode) && text(tag.PR_CODE)) out.prCode = text(tag.PR_CODE);
    // The tag's basis replaces the row's company default, a blank one included (:10702, Next23 034/4 saves '').
    const labourType = text(tag.LBR_TYPE).toUpperCase();
    if (line.lbrType == null && (labourType === '' || LABOUR_TYPES.has(labourType))) {
      out.lbrType = labourType as RateCutLine['lbrType'];
    }
    const rateType = text(tag.RATE_TYPE).toUpperCase();
    if (line.rateType == null && RATE_TYPES.has(rateType)) {
      out.rateType = rateType as RateCutLine['rateType'];
    }
  }
  if (item) {
    if (!hasValue(line.itemName) && item.name) out.itemName = item.name;
    if (side === 'issue' && !tag && !hasValue(line.prCode) && item.prCode) {
      out.prCode = item.prCode;
    }
    if (out.rateType == null && RATE_TYPES.has(item.rateType)) {
      out.rateType = item.rateType as RateCutLine['rateType'];
    }
  }
  return out;
}

/**
 * Reserve every issued tag instance under its identity lock (`issueTagTx`): a `TAG_STOCK` row is removed, and
 * a `BAR_DETL` tag becomes unavailable through the '-' row this voucher writes. A tag that is not in stock is
 * refused (`TagNotAvailableError`, 400), and so is the same tag twice on one voucher — for a `BAR_DETL` tag the
 * second reservation would otherwise pass, because the first line's '-' row is only written at the end.
 */
async function reserveIssuedTagsTx(
  tx: any,
  key: VoucherKey,
  lines: RateCutLine[],
): Promise<Array<ResolvedTagIdentity | undefined>> {
  const asked = new Set<string>();
  const reserved = new Set<string>();
  const out: Array<ResolvedTagIdentity | undefined> = [];
  for (const [index, line] of lines.entries()) {
    if (!isTagged(line.tagNo)) {
      out.push(undefined);
      continue;
    }
    const tagNo = String(line.tagNo).trim();
    const requested = `${tagNo}\u0000${line.vchSrno ?? ''}`;
    if (asked.has(requested)) {
      throw new RateCutValidationError(`tag ${tagNo} appears more than once on this voucher`);
    }
    asked.add(requested);
    const lineItem = String(line.itCode ?? '').trim();
    const identity = await issueTagTx(tx, {
      CO_CODE: key.CO_CODE,
      LC_CODE: key.LC_CODE,
      TAG_NO: tagNo,
      ...(Number.isFinite(Number(line.vchSrno)) && line.vchSrno != null
        ? { VCH_SRNO: Number(line.vchSrno) }
        : {}),
      ...(lineItem ? { IT_CODE: lineItem } : {}),
    });
    const itCode = String(identity.IT_CODE ?? '').trim() || lineItem;
    if (!itCode) {
      throw new RateCutValidationError(
        `tag ${tagNo} on line ${index + 1} has no item; enter the line's item code`,
      );
    }
    const instance = `${tagNo}\u0000${identity.VCH_SRNO}\u0000${itCode}`;
    if (reserved.has(instance)) {
      throw new RateCutValidationError(`tag ${tagNo} appears more than once on this voucher`);
    }
    reserved.add(instance);
    out.push({ ...identity, IT_CODE: itCode });
  }
  return out;
}

/**
 * Give back the tags this voucher moved, before its rows are deleted (edit and delete).
 *
 * Only this voucher's own SR_NO 1 '-' stock rows count: a voucher saved before stock was written has none, and
 * its tags were never reserved, so there is nothing to return. A `BAR_DETL` tag needs no action — deleting its
 * '-' row makes it available again. A `TAG_STOCK`-only tag was removed on sale and is re-inserted with its own
 * weights, as the retail sale's `releaseSaleReferencesTx` does; one already back in `TAG_STOCK` is left alone.
 */
async function releaseRateCutTagsTx(
  tx: any,
  tenantId: string,
  key: VoucherKey,
): Promise<Array<Record<string, unknown> & TagKey>> {
  const moved: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT m."TAG_NO",coalesce(m."VCH_SRNO",0)::float8 AS vch_srno,m."IT_CODE",
            i."ITM_PCS"::float8 AS pcs,i."TAG_GWT"::float8 AS tag_gwt,i."TAG_NWT"::float8 AS tag_nwt,
            i."ITM_GWT"::float8 AS gwt,i."ITM_NWT"::float8 AS nwt,i."DESIGN_NO",i."ITM_SIZE",
            i."PR_CODE",i."IT_TYPE",i."LBR_TYPE"
       FROM "MAIN_STOCK" m
       LEFT JOIN "RATE_CUT_ISU" i
         ON i.tenant_id=m.tenant_id AND i."CO_CODE"=m."CO_CODE" AND i."LC_CODE"=m."LC_CODE"
        AND i."CO_YEAR"=m."CO_YEAR" AND i."CO_BOOK"=m."CO_BOOK" AND i."VCH_NO"=m."VCH_NO"
        AND i."SR_NO"=m."ISR_NO"
      WHERE m.tenant_id=$1 AND m."CO_CODE"=$2 AND m."LC_CODE"=$3 AND m."CO_YEAR"=$4
        AND m."CO_BOOK"=$5 AND m."VCH_NO"=$6 AND m."SR_NO"=1 AND m."ITM_SIGN"='-'
        AND upper(coalesce(nullif(btrim(m."TAG_NO"::text),''),'N'))<>'N'
      ORDER BY m."ISR_NO"
      FOR UPDATE OF m`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  const restores: Array<Record<string, unknown> & TagKey> = [];
  for (const row of moved) {
    const tagNo = String(row.TAG_NO ?? '').trim();
    const vchSrno = Number(row.vch_srno ?? 0);
    const itCode = String(row.IT_CODE ?? '').trim();
    const counts: Array<{ bar: number; stock: number }> = await tx.$queryRawUnsafe(
      `SELECT (SELECT count(*)::int FROM "BAR_DETL" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                AND "TAG_NO"::text=$4 AND coalesce("VCH_SRNO",0)=$5::numeric
                AND coalesce("IT_CODE"::text,'')=$6) AS bar,
              (SELECT count(*)::int FROM "TAG_STOCK" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
                AND "TAG_NO"::text=$4 AND coalesce("VCH_SRNO",0)=$5::numeric) AS stock`,
      tenantId,
      key.CO_CODE,
      key.LC_CODE,
      tagNo,
      vchSrno,
      itCode,
    );
    if (Number(counts[0]?.bar ?? 0) > 0 || Number(counts[0]?.stock ?? 0) > 0) continue;
    const text = (value: unknown): string | undefined => String(value ?? '').trim() || undefined;
    const restore: Record<string, unknown> & TagKey = {
      CO_CODE: key.CO_CODE,
      LC_CODE: key.LC_CODE,
      TAG_NO: tagNo,
      VCH_SRNO: vchSrno,
      ITM_PCS: num(row.pcs),
      ITM_GWT: num(row.tag_gwt) || num(row.gwt),
      ITM_NWT: num(row.tag_nwt) || num(row.nwt),
      STK_TYPE: 'R',
    };
    for (const [column, value] of [
      ['DESIGN_NO', text(row.DESIGN_NO)],
      ['ITM_SIZE', text(row.ITM_SIZE)],
      ['PR_CODE', text(row.PR_CODE)],
      ['IT_TYPE', text(row.IT_TYPE)],
      ['LBR_TYPE', text(row.LBR_TYPE)],
    ] as const) {
      if (value) restore[column] = value;
    }
    restores.push(restore);
  }
  return restores;
}

/** The stored header of one voucher, locked for the rewrite or delete that follows. */
async function persistedHeaderTx(
  tx: any,
  tenantId: string,
  key: VoucherKey,
): Promise<Record<string, unknown> | undefined> {
  const rows: Array<Record<string, unknown>> = await tx.$queryRawUnsafe(
    `SELECT "VCH_DATE","VCH_TIME",to_char("VCH_TIME",'HH24:MI:SS.MS') AS "VCH_CLOCK","MAIN_USER",
            "AC_CODE","AC_NAME","SL_NET_AMT"::float8 AS sl_net,"PR_NET_AMT"::float8 AS pr_net,
            "IT_TYPE","TOT_FINE_DR"::float8 AS tot_fine_dr,"TOT_FINE_CR"::float8 AS tot_fine_cr,
            "HD_VCH_NO","VCH_DESC"
       FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
        AND "CO_YEAR"=$4 AND "CO_BOOK"=$5 AND "VCH_NO"=$6
      ORDER BY row_id LIMIT 1 FOR UPDATE`,
    tenantId,
    key.CO_CODE,
    key.LC_CODE,
    key.CO_YEAR,
    key.CO_BOOK,
    key.VCH_NO,
  );
  return rows[0];
}

export async function postRateCut(prisma: any, input: RateCutInput): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { bookGuard: 'rate-cut' });
}

/** Desktop "Wh Sales": the same TR_WH_SALE voucher, on a `WH SALES` book only. */
export async function postWholesaleSale(prisma: any, input: RateCutInput): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { bookGuard: 'wholesale-sale' });
}

export async function editWholesaleSale(
  prisma: any,
  input: RateCutInput,
  vchNo: number | string,
): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { vchNo, bookGuard: 'wholesale-sale' });
}

export async function getWholesaleSale(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  return readRateCut(prisma, scope, requestedVoucherNo, { bookGuard: 'wholesale-sale' });
}

export async function deleteWholesaleSale(
  prisma: any,
  input: DeleteRateCutInput,
): Promise<{ reversed: true }> {
  return reverseRateCut(prisma, input, { bookGuard: 'wholesale-sale' });
}

/** Desktop WH QUOT: persisted TR_WH_SALE document with no ledger, Rojmel, stock or booking draw-down. */
export async function postWholesaleQuotation(
  prisma: any,
  input: RateCutInput,
): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { bookGuard: 'wholesale-quotation' });
}

export async function editWholesaleQuotation(
  prisma: any,
  input: RateCutInput,
  vchNo: number | string,
): Promise<RateCutResult> {
  return writeRateCut(prisma, input, { vchNo, bookGuard: 'wholesale-quotation' });
}

export async function getWholesaleQuotation(
  prisma: any,
  scope: VoucherScope,
  requestedVoucherNo: number | string,
): Promise<Record<string, unknown>> {
  return readRateCut(prisma, scope, requestedVoucherNo, { bookGuard: 'wholesale-quotation' });
}

export async function deleteWholesaleQuotation(
  prisma: any,
  input: DeleteRateCutInput,
): Promise<{ reversed: true }> {
  return reverseRateCut(prisma, input, { bookGuard: 'wholesale-quotation' });
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
 * Delete/reverse a RATE CUT / WHOLESALE voucher (TR_WH_SALE.cs:13552-13594): give its tags back, release its
 * booking draw-down, remove its rows from every table it can touch by voucher key and write the desktop's
 * DELETE_DATA audit row — all in one transaction.
 */
export async function reverseRateCut(
  prisma: any,
  input: DeleteRateCutInput,
  options: { bookGuard?: RateCutBookGuard } = {},
): Promise<{ reversed: true }> {
  const tenantId = input.scope.tenantId;
  const key = keyOf(input.scope, Number(input.vchNo), input.book ?? RCT_BOOK);
  const quotation = options.bookGuard === 'wholesale-quotation';
  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
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
    const header = await persistedHeaderTx(tx, tenantId, key);
    // Give the voucher's tags back before its stock rows go (see `releaseRateCutTagsTx`).
    const restores = quotation ? [] : await releaseRateCutTagsTx(tx, tenantId, key);
    // Release the booked weight BEFORE the reversal runs: the draw-down joins against
    // RATE_CUT_ISU, and `reverseVoucherTx` deletes those rows. Quotation never consumes a booking.
    if (!quotation) await applyBookingDrawDownTx(tx, tenantId, key, -1);
    const now = new Date();
    const text = (value: unknown, length: number): string =>
      String(value ?? '')
        .trim()
        .slice(0, length);
    await reverseVoucherTx(tx, tenantId, {
      /**
       * `TEMP_BOOK_DATA` is deliberately absent from reverseVoucherTx: it has no CO_YEAR, so it is
       * removed separately below by the header's HD_VCH_NO.
       */
      tables: RATE_CUT_WRITE_TABLES,
      key,
      /**
       * The desktop's delete audit (TR_WH_SALE.cs:13569, identical in TR_BUL_SALE.cs:9200): one row, SR_NO 0,
       * copied from the header — the voucher's own values, fines and user, the book's DISPLAY name cut to 20
       * characters, and the deleting user and time. The web wrote only the key and the book, so a deleted
       * wholesale voucher could not be told apart from any other in the delete register.
       */
      deleteLog: {
        table: 'DELETE_DATA',
        row: {
          ...key,
          SR_NO: 0,
          VCH_DATE: header?.VCH_DATE ?? null,
          DELETE_DATE: now,
          VCH_TYPE: text(classification.vchType, 6),
          VCH_TIME: header?.VCH_TIME ?? null,
          DELETE_TIME: now,
          BOOK_NAME: text(classification.configured ? classification.displayName : '', 20),
          AC_CODE: text(header?.AC_CODE, 8),
          AC_NAME: text(header?.AC_NAME, 50),
          VCH_VAL_DR: num(header?.sl_net),
          VCH_VAL_CR: num(header?.pr_net),
          FINE_TYPE: text(header?.IT_TYPE, 8),
          VCH_FINE_DR: num(header?.tot_fine_dr),
          VCH_FINE_CR: num(header?.tot_fine_cr),
          HD_VCH_NO: text(header?.HD_VCH_NO, 8),
          MAIN_USER: text(header?.MAIN_USER, 15),
          DELETE_USER: text(input.deleteUser ?? 'system', 15),
          VCH_DESC: text(header?.VCH_DESC, 150),
        },
      },
    });
    const hiddenVoucherNo = String(header?.HD_VCH_NO ?? '').trim();
    if (hiddenVoucherNo) {
      await tx.$executeRawUnsafe(
        `DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3
          AND "CO_BOOK"=$4 AND "VCH_NO"=$5`,
        tenantId,
        key.CO_CODE,
        key.LC_CODE,
        key.CO_BOOK,
        hiddenVoucherNo,
      );
    }
    for (const tag of restores) await restoreTagTx(tx, tenantId, tag);
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
