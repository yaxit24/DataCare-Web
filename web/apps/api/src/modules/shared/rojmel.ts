/**
 * The Rojmel — the jeweller's day book (ROJ_MEL_DATA).
 *
 * A second projection of a voucher that shows metal movement and money side by side, which the general
 * ledger cannot: `AC_DATA` carries only amounts. The desktop binds it to F11 and it is the report a
 * shop opens each morning.
 *
 * Everything here was measured against the real DataCareNext database (Live24, 3179 Rojmel rows), not
 * inferred from the decompiled source. Two readings taken from a handful of sampled rows turned out to
 * be wrong and are called out below, because a builder written on either would have produced wrong data.
 *
 * ## IT_TYPE is the METAL, not a stock/amount flag
 *   G gold (335 rows) · S silver (130) · O other (3) · A a money row (2711)
 * Confirmed by book: 026/029 Gold Tax Invoice → G, 027/030 Silver Tax Invoice → S, 035/037 Gold
 * Purchase → G. Metal rows carry pieces and weight (all 130 S rows and all 3 O rows have GWT > 0);
 * money rows do not.
 *
 * ## SIGN is direction, on metal rows only
 *   '-' metal out (sale) · '+' metal in (purchase) · blank on IT_TYPE 'A'
 *
 * ## LD_CODE is the CONTRA account
 * Not a stock ledger. On a real sale the party is 000888 and the sales account 00004, and each row
 * names the OTHER side in LD_CODE. `AC_NAME` is denormalised to the PARTY's name on every row,
 * including rows whose AC_CODE is the sales or tax account — it is the day book's display name.
 *
 * ## Composition of a sale — verified end to end on book 027 voucher 00001
 * The sale: party 000888, TOT_AMT 1560.00, TAX_AMT 45.45, NET_AMT 1515.00, two lines
 * (1 pc 10.360 g net 1087.00; 1 pc 4.600 g net 428.00). Three ledger legs: party Dr 1560.00,
 * sales Cr 1515.00, tax Cr 45.45. Four Rojmel rows:
 *
 *   AC_CODE 00004 sales  LD_CODE 000888 party  Cr 1087.00  S  '-'  1 pc  10.360 g   ← line 1
 *   AC_CODE 00004 sales  LD_CODE 000888 party  Cr  428.00  S  '-'  1 pc   4.600 g   ← line 2
 *   AC_CODE 000888 party LD_CODE 00004 sales   Dr 1560.00  A                        ← party leg
 *   AC_CODE 00085 tax    LD_CODE 000888 party  Cr   45.45  A                        ← tax leg
 *
 * 1087.00 + 428.00 = 1515.00 — the revenue leg split per line. So the rule is: the revenue leg becomes
 * one metal row per detail line carrying that line's pieces and weight; the party and tax legs become
 * money rows.
 */

/** Row-type code embedded in LEDR_KEY at offset 22 (1-based), from the real key distribution. */
export const ROJMEL_ROW_TYPE = {
  /** Item/detail line — carries a right-aligned line number suffix. 1862 real rows. */
  ITEM: '01',
  /** The party leg. 544 real rows. */
  PARTY: '02',
  /** The tax leg. 283 real rows. */
  TAX: '04',
} as const;

export type RojmelRowType = (typeof ROJMEL_ROW_TYPE)[keyof typeof ROJMEL_ROW_TYPE];

/** Metal classification for IT_TYPE. */
export type RojmelMetal = 'G' | 'S' | 'O' | 'A';

/**
 * Map an item's desktop type to the Rojmel metal letter.
 *
 * Deliberately conservative: an unrecognised code returns 'O' (other metal) rather than guessing gold,
 * because misfiling silver as gold would corrupt the metal totals a jeweller reconciles against.
 */
export function rojmelMetalFor(itemType: string | null | undefined): Exclude<RojmelMetal, 'A'> {
  const t = String(itemType ?? '')
    .trim()
    .toUpperCase();
  if (t === 'G') return 'G';
  if (t === 'S') return 'S';
  return 'O';
}

export interface RojmelKeyScope {
  coCode: string;
  lcCode: string;
  coYear: string;
}

/**
 * Build LEDR_KEY exactly as the desktop does.
 *
 * Layout, decoded from real keys such as `01002024-20250270000101         1`:
 *   CO_CODE(2) LC_CODE(2) CO_YEAR(9) CO_BOOK(3) VCH_NO(5) TYPE(2) [line number right-aligned in 10]
 *
 * The line suffix appears on ITEM rows only — real PARTY and TAX keys stop at 23 characters. Column is
 * varchar(50) and the longest real key is 43, so the layout fits with room to spare.
 */
export function rojmelLedrKey(
  scope: RojmelKeyScope,
  coBook: string,
  vchNo: string,
  rowType: RojmelRowType,
  lineNo?: number,
): string {
  const head =
    String(scope.coCode).padStart(2, '0').slice(0, 2) +
    String(scope.lcCode).padStart(2, '0').slice(0, 2) +
    String(scope.coYear).padEnd(9).slice(0, 9) +
    String(coBook).padStart(3, '0').slice(0, 3) +
    String(vchNo).padStart(5, '0').slice(0, 5) +
    rowType;
  return lineNo === undefined ? head : head + String(lineNo).padStart(10);
}

/** Every ROJ_MEL_DATA column the desktop populates, defaulted the way a blank desktop row is. */
export interface RojmelRow {
  /** Index signature so a row satisfies the generic write-set row type. */
  [column: string]: unknown;
  LEDR_KEY: string;
  VCH_DATE: unknown;
  VCH_TYPE: string;
  BOOK_NAME: string;
  AC_CODE: string;
  AC_NAME: string;
  LD_CODE: string;
  DR_AMT: number;
  CR_AMT: number;
  IT_TYPE: RojmelMetal;
  SIGN: string;
  ITM_PCS: number;
  ITM_GWT: number;
  ITM_NWT: number;
  ITM_TOUCH: number;
  ITM_WEST: number;
  ITM_FINE: number;
  ITM_RATE: number;
  ITM_AMT: number;
  LBR_RATE: number;
  LBR_AMT: number;
}

export interface RojmelContext {
  scope: RojmelKeyScope;
  /**
   * The voucher key columns spread onto every row. `postVoucherTx` does NOT add these — the scheme and
   * every other write set spreads its own key — so omitting them would write orphan rows with NULL
   * CO_CODE/CO_BOOK/VCH_NO that no report could ever find.
   */
  key: Record<string, unknown>;
  coBook: string;
  vchNo: string;
  vchDate: unknown;
  vchType: string;
  bookName: string;
  /** Denormalised onto AC_NAME of every row — the day book's display name. */
  partyName: string;
  partyCode: string;
}

/** A detail line contributing one metal row. */
export interface RojmelLine {
  lineNo: number;
  /** Ledger account the revenue posts to (AC_CODE on the metal row). */
  revenueAc: string;
  amount: number;
  metal: Exclude<RojmelMetal, 'A'>;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  wastage?: number;
  fine?: number;
  rate?: number;
  itemAmount?: number;
  labourRate?: number;
  labourAmount?: number;
}

const blank = (ctx: RojmelContext, ledrKey: string): RojmelRow => ({
  ...ctx.key,
  LEDR_KEY: ledrKey,
  VCH_DATE: ctx.vchDate,
  VCH_TYPE: ctx.vchType,
  BOOK_NAME: ctx.bookName,
  AC_CODE: '',
  AC_NAME: ctx.partyName,
  LD_CODE: '',
  DR_AMT: 0,
  CR_AMT: 0,
  IT_TYPE: 'A',
  SIGN: '',
  ITM_PCS: 0,
  ITM_GWT: 0,
  ITM_NWT: 0,
  ITM_TOUCH: 0,
  ITM_WEST: 0,
  ITM_FINE: 0,
  ITM_RATE: 0,
  ITM_AMT: 0,
  LBR_RATE: 0,
  LBR_AMT: 0,
});

/**
 * Project a sale (or any outward voucher) into its Rojmel rows.
 *
 * `outward` selects the direction: a sale sends metal out (`SIGN` '-') and debits the party; a purchase
 * brings metal in ('+') and credits it. The revenue leg is split per line so the day book shows each
 * item's weight against its amount.
 */
export function buildSaleRojmel(
  ctx: RojmelContext,
  lines: RojmelLine[],
  legs: { taxAc?: string; taxAmount?: number; partyAmount: number },
  outward = true,
): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const sign = outward ? '-' : '+';

  for (const l of lines) {
    if (!(l.amount || l.grossWt || l.pcs)) continue; // a wholly empty line is not a day-book event
    rows.push({
      ...blank(
        ctx,
        rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, ROJMEL_ROW_TYPE.ITEM, l.lineNo),
      ),
      AC_CODE: l.revenueAc,
      LD_CODE: ctx.partyCode,
      // Revenue is credited on an outward voucher, debited on an inward one.
      CR_AMT: outward ? l.amount : 0,
      DR_AMT: outward ? 0 : l.amount,
      IT_TYPE: l.metal,
      SIGN: sign,
      ITM_PCS: l.pcs ?? 0,
      ITM_GWT: l.grossWt ?? 0,
      ITM_NWT: l.netWt ?? 0,
      ITM_TOUCH: l.touch ?? 0,
      ITM_WEST: l.wastage ?? 0,
      ITM_FINE: l.fine ?? 0,
      ITM_RATE: l.rate ?? 0,
      ITM_AMT: l.itemAmount ?? l.amount,
      LBR_RATE: l.labourRate ?? 0,
      LBR_AMT: l.labourAmount ?? 0,
    });
  }

  // The party leg. Contra is the revenue account of the first line, mirroring the real row whose
  // LD_CODE was the sales account.
  const revenueAc = lines.find((l) => l.revenueAc)?.revenueAc ?? '';
  rows.push({
    ...blank(ctx, rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, ROJMEL_ROW_TYPE.PARTY)),
    AC_CODE: ctx.partyCode,
    LD_CODE: revenueAc,
    DR_AMT: outward ? legs.partyAmount : 0,
    CR_AMT: outward ? 0 : legs.partyAmount,
  });

  // The tax leg, only when there is tax — a zero-rated sale has no tax row in the desktop either.
  if (legs.taxAmount && legs.taxAc) {
    rows.push({
      ...blank(ctx, rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, ROJMEL_ROW_TYPE.TAX)),
      AC_CODE: legs.taxAc,
      LD_CODE: ctx.partyCode,
      CR_AMT: outward ? legs.taxAmount : 0,
      DR_AMT: outward ? 0 : legs.taxAmount,
    });
  }
  return rows;
}
