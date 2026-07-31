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
  /**
   * Settlement and adjustment rows, each identified by matching real amounts against `SL_DATA` columns
   * across the sale books:
   *   `11` cheque    — 17/17 rows equal `CHQ_AMT`
   *   `13` kasar     — 100/100 rows equal `KASAR_AMT`
   *   `14` advance   — 23/23 rows equal `ADV_AMT`, on the book's advance account
   *   `16` old gold  — `SL_PR_DETL` lines, carrying weight, `IT_DESC` 'OLD GOLD'
   *
   * The accounts come from `BOOK_DETL`, which is a per-book account SLOT table — `SR_NO` 1 sale,
   * 2 cash, 3 kasar, 4 advance, 5 discount, 6 labour income, 7 cash purchase, 8 scheme bonus. That is
   * what the account literals in `Ac_Rojmel.cs` are selecting.
   */
  CHEQUE: '11',
  KASAR: '13',
  ADVANCE: '14',
  OLD_METAL: '16',
  /**
   * Round-off. **SOURCE-DERIVED, NOT VERIFIED AGAINST DATA** — unlike every other type here.
   *
   * This company's database has `ROF_AMT` non-zero on ZERO of 190 sales, so there is no real row to
   * check against; the same is true of `CARD_AMT`, `DISC_AMT` and `TCS_AMT`. The shape below comes from
   * `Ac_Rojmel.Sales_Rojmel` alone, and that file has already been shown to be a LATER version than the
   * code which wrote this data (its sale item rows are type `'02'`, the data's are `'01'`). So the
   * amount, account and direction are trustworthy; the type code is a best reading and cannot be
   * confirmed until a database that actually uses round-off is available.
   */
  ROUND_OFF: '22',
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
  OTH_AMT: number;
  NET_AMT: number;
  IT_DESC: string;
  IT_CODE: string;
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

/**
 * A settlement or adjustment row on a sale: cheque, kasar, advance or old metal.
 *
 * `account` is the account the row names, which for kasar/advance/discount comes from the book's own
 * `BOOK_DETL` slot rather than being chosen by the caller.
 */
export interface RojmelSettlement {
  kind: 'cheque' | 'kasar' | 'advance' | 'oldMetal' | 'roundOff';
  account: string;
  amount: number;
  /** Old-metal rows carry the line's weight; the others do not. */
  lineNo?: number;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fine?: number;
  description?: string;
  itemCode?: string;
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
  /** OTH_AMT and NET_AMT, copied from SL_DETL as `Sales_Rojmel` does. */
  otherAmount?: number;
  netAmount?: number;
  /** IT_CODE and IT_DESC. All 245 real sale metal rows carry both. */
  itemCode?: string;
  itemName?: string;
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
  OTH_AMT: 0,
  NET_AMT: 0,
  IT_DESC: '',
  IT_CODE: '',
});

/**
 * Project a money-only voucher (no metal) into its Rojmel rows.
 *
 * Derived from the desktop's member-entry book 074, which carries 1635 real Rojmel rows against 1311
 * instalment lines — the mismatch is the whole rule, and it is not a rounding artifact:
 *
 *   type `01`, one per line: the LIABILITY leg. AC_CODE the liability account, LD_CODE the account the
 *   money arrived in, amount on the CREDIT side. 1311 rows, exactly one per line.
 *
 *   type `02`, one per line BUT ONLY WHEN THE MONEY LANDS IN A BANK: the receipt leg, AC_CODE the bank,
 *   LD_CODE the liability, amount on the DEBIT side. 324 rows over 216 vouchers, and every one of the
 *   four accounts involved is a bank (OLD AXIS CURRENT 288, AXIS CURRENT 33, AXIS OD 2, AXIS B K
 *   DHAKAN 1). Decisive check: of the bank-receipt vouchers, **216 have a type-02 row and 0 do not**.
 *
 * A cash receipt gets no second row, which is what you would expect of a book that IS the cash book —
 * cash movement is implicit in it, a bank movement is a contra that has to be stated.
 *
 * Both rows follow the ledger's own direction, unlike the cash-payment books, where the Rojmel inverts
 * the cash leg's sign; that convention is NOT implemented here because it has not been derived.
 */
export function buildMoneyRojmel(
  ctx: RojmelContext,
  lines: {
    lineNo: number;
    /** The liability / control account this voucher credits. */
    controlAc: string;
    /** The cash or bank account the money arrived in. */
    receiptAc: string;
    amount: number;
    /** True when the money landed in a bank rather than cash — drives the second row. */
    banked: boolean;
  }[],
): RojmelRow[] {
  const rows: RojmelRow[] = [];
  for (const l of lines) {
    if (!l.amount) continue;
    rows.push({
      ...blank(
        ctx,
        rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, ROJMEL_ROW_TYPE.ITEM, l.lineNo),
      ),
      AC_CODE: l.controlAc,
      LD_CODE: l.receiptAc,
      CR_AMT: l.amount,
    });
    if (l.banked) {
      rows.push({
        ...blank(
          ctx,
          rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, ROJMEL_ROW_TYPE.PARTY, l.lineNo),
        ),
        AC_CODE: l.receiptAc,
        LD_CODE: l.controlAc,
        DR_AMT: l.amount,
      });
    }
  }
  return rows;
}

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
  legs: {
    taxAc?: string;
    taxAmount?: number;
    partyAmount: number;
    /**
     * Settlement and adjustment rows. Each is written ONLY when its amount is non-zero, exactly as
     * `Ac_Rojmel.Sales_Rojmel` guards every one of its inserts with `AND <column> <> 0`. A sale settled
     * wholly in cash produces none of them, which is why sampling vouchers never revealed they exist.
     */
    settlements?: RojmelSettlement[];
  },
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
      OTH_AMT: l.otherAmount ?? 0,
      NET_AMT: l.netAmount ?? l.amount,
      IT_DESC: l.itemName ?? '',
      IT_CODE: l.itemCode ?? '',
    });
  }

  // The party leg, and it is CONDITIONAL. `Sales_Rojmel` writes it only when the bill is outstanding,
  // splitting on the sign: one row type for BILL_OS > 0 (debit) and another for BILL_OS < 0 (credit,
  // absolute). Measured on the real database: of 47 sales with BILL_OS = 0, ZERO carry a party row; of
  // 42 with BILL_OS <> 0, all 42 do. A fully settled bill leaves no receivable for a day book to show,
  // so writing one unconditionally overstated the day's debtors.
  //
  // Contra is the revenue account of the first line, mirroring the real row whose LD_CODE was the sales
  // account.
  const revenueAc = lines.find((l) => l.revenueAc)?.revenueAc ?? '';
  const outstanding = legs.partyAmount;
  if (outstanding) {
    // A negative outstanding means the customer overpaid: the party is credited, not debited, and the
    // amount is stated absolutely.
    const owed = outstanding > 0;
    const amount = Math.abs(outstanding);
    rows.push({
      ...blank(ctx, rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, ROJMEL_ROW_TYPE.PARTY)),
      AC_CODE: ctx.partyCode,
      LD_CODE: revenueAc,
      DR_AMT: outward === owed ? amount : 0,
      CR_AMT: outward === owed ? 0 : amount,
    });
  }

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

  // Settlement and adjustment rows. All four are DEBITS on an outward voucher: money or metal coming in
  // against the bill reduces what the party owes. Old-metal rows keep their weight even though IT_TYPE
  // is 'A' — the desktop stores pcs, gross, net, touch and fine on them, so the day book can show metal
  // taken in exchange without counting it as a metal sale.
  const TYPE_OF: Record<RojmelSettlement['kind'], RojmelRowType> = {
    cheque: ROJMEL_ROW_TYPE.CHEQUE,
    kasar: ROJMEL_ROW_TYPE.KASAR,
    advance: ROJMEL_ROW_TYPE.ADVANCE,
    oldMetal: ROJMEL_ROW_TYPE.OLD_METAL,
    roundOff: ROJMEL_ROW_TYPE.ROUND_OFF,
  };
  for (const st of legs.settlements ?? []) {
    if (!st.amount) continue; // the desktop guards every settlement insert with `<> 0`
    if (st.kind === 'roundOff') {
      // Round-off is shaped differently from the other settlements: it names the PARTY in AC_CODE with
      // the book's slot-5 account as contra, and it splits on its own sign rather than on the voucher
      // direction — `CASE WHEN ROF_AMT > 0 THEN ROF_AMT ELSE 0` on the credit side and the mirror on the
      // debit. Note the desktop puts the NEGATIVE value straight into DR_AMT rather than its absolute
      // value; that is preserved here rather than tidied, because a report summing DR_AMT depends on it.
      rows.push({
        ...blank(ctx, rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, ROJMEL_ROW_TYPE.ROUND_OFF)),
        AC_CODE: ctx.partyCode,
        LD_CODE: st.account,
        CR_AMT: st.amount > 0 ? st.amount : 0,
        DR_AMT: st.amount < 0 ? st.amount : 0,
      });
      continue;
    }
    rows.push({
      ...blank(ctx, rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, TYPE_OF[st.kind], st.lineNo)),
      AC_CODE: st.account,
      LD_CODE: ctx.partyCode,
      DR_AMT: outward ? st.amount : 0,
      CR_AMT: outward ? 0 : st.amount,
      ITM_PCS: st.pcs ?? 0,
      ITM_GWT: st.grossWt ?? 0,
      ITM_NWT: st.netWt ?? 0,
      ITM_TOUCH: st.touch ?? 0,
      ITM_FINE: st.fine ?? 0,
      IT_DESC: st.description ?? '',
      IT_CODE: st.itemCode ?? '',
    });
  }
  return rows;
}

/**
 * Project a cash or bank receipt/payment into its Rojmel row.
 *
 * The cash books use a different convention from every other family, and it took a row-type breakdown to
 * see it. Measured across the real data, grouped by the row-type code in `LEDR_KEY`:
 *
 *   book 001 (Cash Received)  type `01`  56 rows  → mirrors the COUNTER-PARTY's ledger leg (100%)
 *                             type `02`  25 rows  → mirrors its own leg (100%)
 *                             type `03`  25 rows  → mirrors its own leg (100%)
 *   book 002 (Cash Payment)   type `04` 175 rows  → mirrors the COUNTER-PARTY's leg (100%)
 *                             type `05`   5 rows  → own leg (100%)
 *                             type `06`   5 rows  → own leg (100%)
 *
 * Ungrouped the same test gives 47.2% and 5.4%, which is why an earlier pass concluded the convention was
 * "not derived" and declined to implement it. The rule was never inconsistent — it is per row type, and
 * averaging across types hid it.
 *
 * So the cash row names the cash/bank account in `AC_CODE` and the party in `LD_CODE`, but takes its
 * DEBIT/CREDIT from the PARTY's leg. A receipt credits the party, so the row is a credit; a payment
 * debits the party, so the row is a debit. That reads naturally as a cash book: one line per movement,
 * showing who it was with and which way it went.
 *
 * The type code is **book-specific**, not semantic: a receipt's cash row is `01` and a payment's is `04`.
 * Do not reuse the sale's constants here.
 *
 * NOT implemented: types `02`/`03` and `05`/`06`, which are contra-style pairs (own leg, like a journal)
 * for a settlement leg inside the voucher that did not go through cash — 60 rows in total. Their trigger
 * condition is a multi-settlement voucher, which has not been derived. A voucher carrying only a cash
 * settlement produces just the one row.
 */
export const ROJMEL_CASH_ROW_TYPE = { RECEIPT: '01', PAYMENT: '04' } as const;

export function buildCashRojmel(
  ctx: RojmelContext,
  p: {
    /** The cash or bank account the money moved through. */
    cashAc: string;
    /** The amount on the PARTY's ledger leg — not necessarily the cash tendered. */
    partyLegAmount: number;
    /** A receipt credits the party; a payment debits it. */
    direction: 'receipt' | 'payment';
  },
): RojmelRow[] {
  if (!p.partyLegAmount) return [];
  const receipt = p.direction === 'receipt';
  return [
    {
      ...blank(
        ctx,
        rojmelLedrKey(
          ctx.scope,
          ctx.coBook,
          ctx.vchNo,
          receipt ? ROJMEL_CASH_ROW_TYPE.RECEIPT : ROJMEL_CASH_ROW_TYPE.PAYMENT,
          1,
        ),
      ),
      AC_CODE: p.cashAc,
      LD_CODE: ctx.partyCode,
      // The party's direction, not the cash account's — this is the whole point of the convention.
      CR_AMT: receipt ? p.partyLegAmount : 0,
      DR_AMT: receipt ? 0 : p.partyLegAmount,
    },
  ];
}

/**
 * Project a journal / contra voucher into its Rojmel rows.
 *
 * Rule established by measurement, not inference: **every one of the 74 real Rojmel rows on contra book
 * 017 carries the same DR/CR as its own AC_CODE's ledger leg** (100%). The same test on the scheme book
 * 074 also gives 100% over 1635 rows, so the two families share one rule and this builder is a
 * generalisation of a verified pattern rather than a new guess.
 *
 * The same test is why the CASH books are not implemented: book 001 matches on only 47.2% of rows and
 * book 002 on 5.4%, so they follow a different convention that has not been derived.
 *
 * `LD_CODE` is the contra account. All 37 real contra vouchers carry exactly two rows, so "the other
 * side" is unambiguous there. For a journal with more than two lines this takes the first account on the
 * opposite side, consistent with how a sale's party row names the first revenue account — but note that
 * the multi-line case is NOT covered by the real data examined.
 */
export function buildJournalRojmel(
  ctx: RojmelContext,
  lines: { lineNo: number; acCode: string; drAmt: number; crAmt: number }[],
): RojmelRow[] {
  const firstDr = lines.find((l) => l.drAmt > 0);
  const firstCr = lines.find((l) => l.crAmt > 0);
  return lines
    .filter((l) => l.drAmt > 0 || l.crAmt > 0)
    .map((l) => {
      // The contra is the first account on the OTHER side of the entry.
      const other = l.drAmt > 0 ? firstCr : firstDr;
      return {
        ...blank(
          ctx,
          rojmelLedrKey(
            ctx.scope,
            ctx.coBook,
            ctx.vchNo,
            l.drAmt > 0 ? ROJMEL_ROW_TYPE.PARTY : ROJMEL_ROW_TYPE.ITEM,
            l.lineNo,
          ),
        ),
        AC_CODE: l.acCode,
        LD_CODE: other?.acCode ?? '',
        DR_AMT: l.drAmt,
        CR_AMT: l.crAmt,
      };
    });
}
