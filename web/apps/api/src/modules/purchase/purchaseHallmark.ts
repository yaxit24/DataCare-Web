import { round, roundHalfEven } from '@datacare/core';

/**
 * WP-28 (N244 / G256): the hallmark receive branch of the desktop purchase (TR_PURC_HM, the 95-column `MSG_PR` grid),
 * the purchase-family book rule and the column carry that makes an unchanged reopen + save lossless.
 *
 * Kept out of `purchase.ts` (size ceiling) and pure, so the rules are unit-tested without a database.
 */

const text = (value: unknown): string => String(value ?? '').trim();
const num = (value: unknown): number => {
  const parsed = Number(value ?? 0);
  return Number.isFinite(parsed) ? parsed : 0;
};

/** Per-line hallmark-layout fields of `PurchaseLineInput` (TR_PURC_HM `mSG_PR` columns). */
export interface HallmarkLineInput {
  /** col 39 HmAmt -> PR_DETL.HM_ID_AMT (TR_PURC_HM.cs:8003), every book. */
  hmIdAmount?: number;
  /** col 7 Color -> ITM_COLOR (TR_PURC_HM.cs:7973), every book. */
  itmColor?: string;
  /** col 86 -> DESIGN_IMG_ID (TR_PURC_HM.cs:8006); the web's 'N' when absent. */
  designImgId?: string;
  /** cols 81 / 83 -> TAG_TYPE / TAG_SRNO (TR_PURC_HM.cs:8026-8028, :8067-8069), every book. */
  tagType?: string;
  tagSrno?: number;
  /** TAG PURCHASE only (TR_PURC_HM.cs:8023-8063): hallmark ids 2-4 and the four weights, col 55-63. */
  hmId2?: string;
  hmId3?: string;
  hmId4?: string;
  hmIdWt?: number;
  hmId2Wt?: number;
  hmId3Wt?: number;
  hmId4Wt?: number;
  /** TAG PURCHASE only: the tag band, cols 40-54 and 56. */
  tagOthWt?: number; // 40 TAG_OTH_WT
  tagNwt?: number; // 41 TAG_NWT
  lbrCode?: string; // 42 LBR_CODE
  tagTouch?: number; // 43 TAG_TOUCH
  tagWestPct?: number; // 44 TAG_WEST_PRC
  tagFine?: number; // 45 TAG_FINE
  tagRate?: number; // 46 TAG_IT_RATE
  tagAmount?: number; // 47 TAG_IT_AMT
  tagLbrPct?: number; // 48 TAG_LBR_PRC
  tagLbrRate?: number; // 49 TAG_LBR_RATE
  tagLbrAmt?: number; // 50 TAG_LBR_AMT
  tagOthAmt?: number; // 51 TAG_OTH_AMT
  tagTotCost?: number; // 52 TAG_TOT_COST
  tagMarginPct?: number; // 53 TAG_MARGIN_PRC
  tagMrp?: number; // 54 TAG_MRP
  tagCost?: number; // 34 PrCost -> TAG_COST
  krName?: string; // 56 KR_NAME
}

/**
 * Header `HM_AMT`: the desktop rounds the column-39 total with `Math.Round(x, 0)` (half to even, non-UAE):
 * TR_PURC_HM.cs:9995 `mSG2_TOTAL[5, 3] = Format(Math.Round(Val(MSG_PR_TOT[0, 39]), 0), "0.00")`.
 *
 * When no line carries a hallmark amount (the plain layout, or a voucher saved before the column existed) the
 * header charge the request names is kept as it is, so an older voucher's stored `HM_AMT` survives a reopen.
 */
export function hallmarkHeaderAmount(
  lines: ReadonlyArray<Pick<HallmarkLineInput, 'hmIdAmount'>>,
  headerAmount: number | undefined,
): number {
  // The column total is a running sum kept as text, each step `Format(Val(total) + Val(cell), "0.000")`
  // (TR_PURC_HM.cs:6544): a half-up 3-decimal round per step, so a double sum's drift never reaches Math.Round.
  const total = lines.reduce((sum, line) => round(sum + num(line.hmIdAmount), 3), 0);
  if (lines.some((line) => num(line.hmIdAmount) !== 0)) return roundHalfEven(total, 0);
  return num(headerAmount);
}

/**
 * The PR_DETL columns of the hallmark branch. TAG PURCHASE writes the hallmark ids, their weights and the tag band
 * from the grid (TR_PURC_HM.cs:8023-8063) and `WITH_STOCK = 'N'` (:8025); every other book writes the tag band as
 * zeros and blanks and leaves `HM_ID2-4` unset (:8064-8087, D5). Hallmark amount, colour, design image and the tag
 * type/serial are written for every book.
 */
export function hallmarkDetailColumns(
  line: HallmarkLineInput,
  isTagBook: boolean,
): Record<string, unknown> {
  const common = {
    HM_ID_AMT: num(line.hmIdAmount),
    ITM_COLOR: text(line.itmColor).slice(0, 15) || null,
    DESIGN_IMG_ID: text(line.designImgId).slice(0, 50) || 'N',
    TAG_TYPE: text(line.tagType).slice(0, 1) || null,
    TAG_SRNO: num(line.tagSrno),
  };
  if (isTagBook) {
    return {
      ...common,
      WITH_STOCK: 'N',
      HM_ID2: text(line.hmId2).slice(0, 10) || null,
      HM_ID3: text(line.hmId3).slice(0, 10) || null,
      HM_ID4: text(line.hmId4).slice(0, 10) || null,
      HM_ID_WT: num(line.hmIdWt),
      HM_ID2_WT: num(line.hmId2Wt),
      HM_ID3_WT: num(line.hmId3Wt),
      HM_ID4_WT: num(line.hmId4Wt),
      TAG_OTH_WT: num(line.tagOthWt),
      TAG_NWT: num(line.tagNwt),
      LBR_CODE: text(line.lbrCode).slice(0, 4),
      TAG_TOUCH: num(line.tagTouch),
      TAG_WEST_PRC: num(line.tagWestPct),
      TAG_FINE: num(line.tagFine),
      TAG_IT_RATE: num(line.tagRate),
      TAG_IT_AMT: num(line.tagAmount),
      TAG_LBR_PRC: num(line.tagLbrPct),
      TAG_LBR_RATE: num(line.tagLbrRate),
      TAG_LBR_AMT: num(line.tagLbrAmt),
      TAG_OTH_AMT: num(line.tagOthAmt),
      TAG_COST: num(line.tagCost),
      TAG_TOT_COST: num(line.tagTotCost),
      TAG_MARGIN_PRC: num(line.tagMarginPct),
      TAG_MRP: num(line.tagMrp),
      KR_NAME: text(line.krName).slice(0, 5),
    };
  }
  return {
    ...common,
    HM_ID2: null,
    HM_ID3: null,
    HM_ID4: null,
    HM_ID_WT: 0,
    HM_ID2_WT: 0,
    HM_ID3_WT: 0,
    HM_ID4_WT: 0,
    TAG_OTH_WT: 0,
    TAG_NWT: 0,
    LBR_CODE: '',
    TAG_TOUCH: 0,
    TAG_WEST_PRC: 0,
    TAG_FINE: 0,
    TAG_IT_RATE: 0,
    TAG_IT_AMT: 0,
    TAG_LBR_PRC: 0,
    TAG_LBR_RATE: 0,
    TAG_LBR_AMT: 0,
    TAG_OTH_AMT: 0,
    TAG_COST: 0,
    TAG_TOT_COST: 0,
    TAG_MARGIN_PRC: 0,
    TAG_MRP: 0,
    KR_NAME: '',
  };
}

/**
 * The BAR_DETL columns a TAG PURCHASE line takes from its tag band (TR_PURC_HM.cs:8237-8316):
 * net weight is the tag net unless it is zero (:8237-8243) while KR_NET_WT keeps the line net (:8246); a typed tag
 * amount wins with its own rate, total cost and margin (:8304-8308), else the line rate and amount, the purchase
 * cost and a zero margin (:8313-8316).
 */
export function tagBandBarColumns(
  line: HallmarkLineInput & { netWt?: number },
  calc: { rate: number; metal: number },
): Record<string, unknown> {
  const typedAmount = num(line.tagAmount) !== 0;
  return {
    ITM_NWT: num(line.tagNwt) === 0 ? num(line.netWt) : num(line.tagNwt),
    KR_NET_WT: num(line.netWt),
    ITM_RATE: typedAmount ? num(line.tagRate) : calc.rate,
    ITM_AMT: typedAmount ? num(line.tagAmount) : calc.metal,
    TAG_COST: typedAmount ? num(line.tagTotCost) : num(line.tagCost),
    ITM_MARGIN: typedAmount ? num(line.tagMarginPct) : 0,
  };
}

/** The reopen view of the hallmark fields, the inverse of `hallmarkDetailColumns` (TR_PURC_HM.cs:7469-7574). */
export function hallmarkLineView(row: Record<string, unknown>): Required<HallmarkLineInput> {
  return {
    hmIdAmount: num(row.HM_ID_AMT),
    itmColor: text(row.ITM_COLOR),
    designImgId: text(row.DESIGN_IMG_ID),
    tagType: text(row.TAG_TYPE),
    tagSrno: num(row.TAG_SRNO),
    hmId2: text(row.HM_ID2),
    hmId3: text(row.HM_ID3),
    hmId4: text(row.HM_ID4),
    hmIdWt: num(row.HM_ID_WT),
    hmId2Wt: num(row.HM_ID2_WT),
    hmId3Wt: num(row.HM_ID3_WT),
    hmId4Wt: num(row.HM_ID4_WT),
    tagOthWt: num(row.TAG_OTH_WT),
    tagNwt: num(row.TAG_NWT),
    lbrCode: text(row.LBR_CODE),
    tagTouch: num(row.TAG_TOUCH),
    tagWestPct: num(row.TAG_WEST_PRC),
    tagFine: num(row.TAG_FINE),
    tagRate: num(row.TAG_IT_RATE),
    tagAmount: num(row.TAG_IT_AMT),
    tagLbrPct: num(row.TAG_LBR_PRC),
    tagLbrRate: num(row.TAG_LBR_RATE),
    tagLbrAmt: num(row.TAG_LBR_AMT),
    tagOthAmt: num(row.TAG_OTH_AMT),
    tagTotCost: num(row.TAG_TOT_COST),
    tagMarginPct: num(row.TAG_MARGIN_PRC),
    tagMrp: num(row.TAG_MRP),
    tagCost: num(row.TAG_COST),
    krName: text(row.KR_NAME),
  };
}

/** The main books the purchase writer accepts. `CON PUR` is the consignment purchase served by the same writer. */
export const PURCHASE_FAMILY_MAIN_BOOKS = ['PURCHASE', 'TAG PURCHASE', 'CON PUR'] as const;

export class PurchaseFamilyError extends Error {
  constructor(message: string) {
    super(message);
    // Same name as PurchaseValidationError, so the route maps it to 400 like every other purchase refusal.
    this.name = 'PurchaseValidationError';
  }
}

/**
 * D7 (G6): the desktop opens the purchase forms only on books whose `MAIN_BOOK` is `PURCHASE` or `TAG PURCHASE`
 * (DC_Main.cs:1503 `CUR_USE = 'Y' AND MAIN_BOOK = '...'`, MDI_FORM.cs:7868, :8541). The web refuses any other book on
 * the server, including a book with no family at all, instead of trusting the screen's list.
 */
export function assertPurchaseFamilyBook(mainBook: string, coBook: string): void {
  const family = text(mainBook).toUpperCase();
  if ((PURCHASE_FAMILY_MAIN_BOOKS as readonly string[]).includes(family)) return;
  throw new PurchaseFamilyError(
    `book ${coBook} is ${family || 'not a configured book family'}; a purchase needs a PURCHASE or TAG PURCHASE book`,
  );
}

const NEVER_CARRIED = new Set(['tenant_id', 'row_id']);

/** NULL, '' or a numeric zero (number or a driver Decimal): the stored forms of an empty grid cell or text box. */
function isBlankCell(value: unknown): boolean {
  if (value == null || value === '' || value === 0) return true;
  if (
    typeof value === 'object' &&
    !(value instanceof Date) &&
    typeof value.toString === 'function'
  ) {
    const text = value.toString();
    return text !== '' && Number(text) === 0;
  }
  return false;
}

/**
 * D6: the persisted row's columns the writer does not own, under the row the writer built.
 *
 * The desktop reopens with `SELECT *` and writes every column back (TR_PURC_HM.cs:7216, :7462). The web rebuilds the
 * write set from the request, so a column it does not model (a desktop-written `OS_ADJ_AMT`, `DATA_TRFR`,
 * `OLD_VCH_NO`, ...) would fall to its default. Carrying the persisted value keeps it. A column the writer builds
 * always wins, even when it builds `null`, so a value the operator removed is never resurrected.
 *
 * One exception keeps the stored FORM of a blank: when the stored value and the built value are both blank (NULL, ''
 * or zero), the stored one is kept. The desktop writes a blank text box as '' (TR_PURC_HM.cs:7897 `EMP_CODE =
 * tEmpCode.Text`, :7968-7973), a voucher saved before WP-28 has NULL in the hallmark columns, and the writer builds
 * NULL or 0 for a blank; without this an unchanged save rewrote '' as NULL and NULL as 0. A non-blank value is never
 * kept over a built one, so this cannot resurrect anything.
 */
export function carryUnownedColumns(
  prior: Record<string, unknown> | undefined,
  built: Record<string, unknown>,
): Record<string, unknown> {
  if (!prior) return built;
  const carried: Record<string, unknown> = {};
  const blanks: Record<string, unknown> = {};
  for (const [column, value] of Object.entries(prior)) {
    if (NEVER_CARRIED.has(column)) continue;
    if (!(column in built)) carried[column] = value;
    else if (isBlankCell(value) && isBlankCell(built[column])) blanks[column] = value;
  }
  return { ...carried, ...built, ...blanks };
}
