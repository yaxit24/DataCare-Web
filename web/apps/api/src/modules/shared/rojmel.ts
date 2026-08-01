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
  rowType:
    | RojmelRowType
    | RojmelRateCutRowType
    | RojmelOrderRowType
    | RojmelSchemeAdjRowType
    | RojmelFineJvRowType
    // Sixth widening of this union. Each family's row types are measured separately and none has yet reused
    // another's, which is why the union grows rather than a shared enum being reached for.
    | (typeof ROJMEL_CASH_ROW_TYPE)[keyof typeof ROJMEL_CASH_ROW_TYPE],
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
/**
 * Cash Rojmel row types, measured across all rows of books 001 and 002.
 *
 *   book 001 CASH REC   01 cash 00001 Cr (56)   02 party Cr (25)   03 kasar 00057 Dr (25)
 *   book 002 CASH PAY   04 cash 00001 Dr (175)  05 party Dr (5)    06 kasar 00042 Cr (5)
 *
 * ASYMMETRIC on purpose: the cash movement is ONE row naming the cash account, while the kasar movement is a
 * PAIR naming the party and the kasar account separately. The counts prove it - 56 type-01 rows against 25 each
 * of 02 and 03, one per voucher that carried a write-off.
 *
 * Direction comes from the PARTY, not the named account: a receipt CREDITS type 01 even though the ledger
 * DEBITS cash. So the Rojmel's convention is not the ledger's and cannot be inherited from it.
 */
export const ROJMEL_CASH_ROW_TYPE = {
  RECEIPT: '01',
  RECEIPT_KASAR_PARTY: '02',
  RECEIPT_KASAR: '03',
  PAYMENT: '04',
  PAYMENT_KASAR_PARTY: '05',
  PAYMENT_KASAR: '06',
} as const;

export function buildCashRojmel(
  ctx: RojmelContext,
  p: {
    /** The cash or bank account the money moved through. */
    cashAc: string;
    /**
     * The CASH actually tendered — NOT the party's total.
     *
     * Real voucher 001/00001 received 60000.00 against a 771.00 write-off, and its type-01 Rojmel row carries
     * 60000.00. This parameter was previously `partyLegAmount` and callers passed amount + kasar, giving
     * 60771.00. The old name and its comment described the code's own behaviour rather than the desktop's, and
     * they only looked correct while the party's ledger leg was a single netted figure.
     */
    cashAmount: number;
    /** A receipt credits the party; a payment debits it. */
    direction: 'receipt' | 'payment';
    /** Write-off on this movement, which gets its own PAIR of rows. */
    kasar?: number;
    /** Receipt uses 00057 KASAR JAVK, payment 00042 KASAR AVAK — the account mirrors the money's direction. */
    kasarAc?: string;
    /**
     * The CASH_DATA line this movement belongs to.
     *
     * A multi-line voucher writes ONE ROW PER LINE, all of the same type, with the line number distinguishing
     * them. Real voucher 002/00029 has nine lines and nine type-04 rows keyed `...0002904` + 1 through 9.
     *
     * The multi-line paths wrote NO Rojmel rows at all - postReceiptLines and postPaymentLines never called
     * this builder - so the day book showed nothing for a nine-line cash payment.
     */
    lineNo?: number;
  },
): RojmelRow[] {
  const receipt = p.direction === 'receipt';
  const T = ROJMEL_CASH_ROW_TYPE;
  const rows: RojmelRow[] = [];
  const line = Number(p.lineNo ?? 1);
  if (p.cashAmount)
    rows.push({
      ...blank(
        ctx,
        rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, receipt ? T.RECEIPT : T.PAYMENT, line),
      ),
      AC_CODE: p.cashAc,
      LD_CODE: ctx.partyCode,
      // The party's direction, not the cash account's — this is the whole point of the convention.
      CR_AMT: receipt ? p.cashAmount : 0,
      DR_AMT: receipt ? 0 : p.cashAmount,
    });
  // The kasar movement is a PAIR: the party, then the kasar account. Types 02/03 on a receipt, 05/06 on a
  // payment - a receipt and a payment share no codes here either.
  const kasar = Number(p.kasar ?? 0);
  if (kasar && p.kasarAc) {
    rows.push(
      {
        ...blank(
          ctx,
          rojmelLedrKey(
            ctx.scope,
            ctx.coBook,
            ctx.vchNo,
            receipt ? T.RECEIPT_KASAR_PARTY : T.PAYMENT_KASAR_PARTY,
            line,
          ),
        ),
        AC_CODE: ctx.partyCode,
        LD_CODE: p.kasarAc,
        CR_AMT: receipt ? kasar : 0,
        DR_AMT: receipt ? 0 : kasar,
      },
      {
        ...blank(
          ctx,
          rojmelLedrKey(
            ctx.scope,
            ctx.coBook,
            ctx.vchNo,
            receipt ? T.RECEIPT_KASAR : T.PAYMENT_KASAR,
            line,
          ),
        ),
        AC_CODE: p.kasarAc,
        LD_CODE: ctx.partyCode,
        // The kasar account takes the OPPOSITE direction to the party, so the pair self-balances.
        CR_AMT: receipt ? 0 : kasar,
        DR_AMT: receipt ? kasar : 0,
      },
    );
  }
  return rows;
}

/**
 * Rate cut / wholesale row types (books 064 and 034), from `Ac_Rojmel.Wh_Sales_Rojmel`.
 *
 * That routine contains 40+ row types. Only these **nine** ever fired in a year of this shop's trading,
 * established by grouping the 66 real rows of book 064 by their `LEDR_KEY` type code and matching each
 * against a non-zero source column in `RATE_CUT_DATA`:
 *
 *   `01` 19 rows  purchase fine   `DR_FINE` non-zero on 20 of 40
 *   `02` 19 rows  purchase amount `CR_AMT` on 20
 *   `03`  5 rows  sale fine       `CR_FINE` on 6
 *   `04`  5 rows  sale amount     `DR_AMT` on 6
 *   `07`  4 rows  kasar fine out  `KSR_FINE_DR` on 4
 *   `08`  2 rows  kasar fine in   `KSR_FINE_CR` on 3
 *   `13`  2 rows  overpaid purch. `PR_BILL_OS` negative
 *   `22`  5 rows  purchase cheque `PR_CHQ_AMT` on 5
 *   `26`  5 rows  purchase kasar  `PR_KASAR_AMT` on 5
 *
 * Sums to 66, matching the book exactly. Everything else in the routine is dead here: **all 40
 * `RATE_CUT_DATA` rows are `IT_TYPE` `'G'`**, so every silver family is unused, as are interest fine, tax,
 * TDS, card and labour. They are not implemented — three more families resting on unverifiable shapes
 * would add surface without adding confidence.
 */
export const ROJMEL_RATECUT_ROW_TYPE = {
  PURCHASE_FINE: '01',
  PURCHASE_AMOUNT: '02',
  SALE_FINE: '03',
  SALE_AMOUNT: '04',
  KASAR_FINE_OUT: '07',
  KASAR_FINE_IN: '08',
  PURCHASE_OVERPAID: '13',
  PURCHASE_CHEQUE: '22',
  PURCHASE_KASAR: '26',
} as const;

export type RojmelRateCutRowType =
  (typeof ROJMEL_RATECUT_ROW_TYPE)[keyof typeof ROJMEL_RATECUT_ROW_TYPE];

export interface RateCutRojmelLegs {
  /** `BOOK_DETL` slot 2 — the purchase-side control. On book 064 this is `00008`. */
  purchaseAc: string;
  /** `BOOK_DETL` slot 1 — the sale-side control. On book 064 this is `00003`. */
  saleAc: string;
  /** `BOOK_DETL` slot 12 — kasar FINE. On book 064 this is `00098`. */
  kasarFineAc: string;
  /** `BOOK_DETL` slot 5 — purchase kasar AMOUNT. On book 064 this is `00042`. */
  purchaseKasarAc: string;
  /** The bank the cheque was drawn on; named in `AC_CODE` of the type-22 row. */
  bankAc: string;
  metal: Exclude<RojmelMetal, 'A'>;
  /** `FINE_RATE` — appears on the fine rows of types 01, 03 and 13, but not 07 or 08. */
  fineRate: number;
  /** `DR_FINE` — the purchase-side fine. */
  drFine: number;
  /** `CR_FINE` — the sale-side fine. */
  crFine: number;
  /** `PR_BILL_OS`. Positive lands on type 01 as a credit; negative on type 13 as a debit. */
  purchaseBillOs: number;
  /** `SL_BILL_OS`. Positive lands on type 03 as a debit. */
  saleBillOs: number;
  /** `CR_AMT + PR_ITM_AMT` — type 02, a DEBIT. */
  purchaseAmount: number;
  /** `DR_AMT + SL_ITM_AMT` — type 04, a CREDIT. */
  saleAmount: number;
  kasarFineDr: number;
  kasarFineCr: number;
  purchaseChequeAmount: number;
  purchaseKasarAmount: number;
}

/**
 * Project a rate-cut / wholesale voucher into its Rojmel rows.
 *
 * ## Every direction below was taken from the real rows, not from the source
 * `Ac_Rojmel.cs` is a later version than the code that wrote this data — independently proven by sale item
 * rows being type `'02'` in the source and `'01'` in the data. On five of these nine types the source's
 * debit/credit assignment is the OPPOSITE of what the data holds, so the data is authoritative throughout.
 * Sample rows, one per type, from book 064:
 *
 *   t01  ac=party  ld=00008  G '-'  dr 0        cr 0/cond  fine 36.200  rate 7578.00
 *   t02  ac=00008  ld=party  A      dr 274324   cr 0       fine 0
 *   t03  ac=party  ld=00003  G '+'  dr 8000     cr 0       fine  1.169  rate 6844.00
 *   t04  ac=00003  ld=party  A      dr 0        cr 8000    fine 0
 *   t07  ac=party  ld=00098  G '-'  dr 0        cr 0       fine  0.110  rate 0
 *   t08  ac=party  ld=00098  G '+'  dr 0        cr 0       fine  0.031  rate 0
 *   t13  ac=party  ld=00008  G '-'  dr 850      cr 0       fine  2.050  rate 7300.00
 *   t22  ac=bank   ld=party  A      dr 0        cr 274324  fine 0
 *   t26  ac=00042  ld=party  A      dr 0        cr 15      fine 0
 *
 * Note the account order flips: **fine rows name the party in `AC_CODE`**, while amount rows 02/04/26 name
 * the slot account there and the party in `LD_CODE`. Getting that backwards would misfile every row.
 *
 * ## Only types 07 and 08 are money-free
 * A plan draft asserted all fine rows carry no money. Wrong: type 03 carries a debit on 5 of 5 rows, type
 * 13 on 2 of 2, and type 01 a conditional credit on 9 of 19. Only the kasar-fine pair has both amounts
 * zero. The money-free fine row is a feature of `Fine_CUT_Rojmel`, which is dead code here.
 *
 * ## The purchase and sale sides are mutually exclusive
 * Across all 25 real vouchers, no voucher carries both type 01 and type 03. A rate cut is a fine purchase
 * or a fine sale, never both, so the two branches below cannot both fire on well-formed input.
 *
 * ## The desktop double-counts fine on an overpaid purchase, and this reproduces it
 * When `PR_BILL_OS` is negative the desktop writes the fine TWICE — once on type 01 and again on type 13.
 * Verified on both occurrences: voucher 00004 has `PR_BILL_OS` -850.00 and `DR_FINE` 2.050, and 2.050
 * appears on both rows; voucher 00020 has -122.00 and 3.814, likewise.
 *
 * That inflates the day book's fine total for those vouchers, and it is very likely a defect in the
 * desktop. It is reproduced deliberately, because parity with the desktop's report output is the
 * requirement and silently "fixing" it would make the two systems disagree on a figure the shop
 * reconciles against. **Do not deduplicate this without a decision from the owner.**
 */
export function buildRateCutRojmel(ctx: RojmelContext, legs: RateCutRojmelLegs): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const key = (t: RojmelRateCutRowType): string =>
    // No rate-cut type carries a line number: all 66 real keys are 23 characters, unlike the sale's item
    // rows at 33. Passing one would produce a key that matches nothing.
    rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, t);

  // ---- purchase side (the shop buys fine metal) ------------------------------------------------
  // Emitted when there is fine to record OR money outstanding, mirroring the source's
  // `(A.DR_FINE <> 0 OR A.PR_BILL_OS > 0)` guard.
  if (legs.drFine || legs.purchaseBillOs > 0) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.PURCHASE_FINE)),
      AC_CODE: ctx.partyCode,
      LD_CODE: legs.purchaseAc,
      // Credit only when the bill is outstanding in the shop's favour; 9 of 19 real rows carry one.
      CR_AMT: legs.purchaseBillOs > 0 ? legs.purchaseBillOs : 0,
      IT_TYPE: legs.metal,
      SIGN: '-', // fine metal coming IN is recorded as an outward sign on the purchase side
      ITM_FINE: legs.drFine,
      ITM_RATE: legs.fineRate,
    });
  }
  if (legs.purchaseAmount) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.PURCHASE_AMOUNT)),
      AC_CODE: legs.purchaseAc, // the slot account, NOT the party — the flip described above
      LD_CODE: ctx.partyCode,
      DR_AMT: legs.purchaseAmount,
    });
  }
  if (legs.purchaseBillOs < 0) {
    // Overpaid purchase. Carries the fine a second time; see the note above before changing this.
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.PURCHASE_OVERPAID)),
      AC_CODE: ctx.partyCode,
      LD_CODE: legs.purchaseAc,
      DR_AMT: Math.abs(legs.purchaseBillOs),
      IT_TYPE: legs.metal,
      SIGN: '-',
      ITM_FINE: legs.drFine,
      ITM_RATE: legs.fineRate,
    });
  }

  // ---- sale side (the shop sells fine metal) ---------------------------------------------------
  if (legs.crFine || legs.saleBillOs > 0) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.SALE_FINE)),
      AC_CODE: ctx.partyCode,
      LD_CODE: legs.saleAc,
      DR_AMT: legs.saleBillOs > 0 ? legs.saleBillOs : 0,
      IT_TYPE: legs.metal,
      SIGN: '+',
      ITM_FINE: legs.crFine,
      ITM_RATE: legs.fineRate,
    });
  }
  if (legs.saleAmount) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.SALE_AMOUNT)),
      AC_CODE: legs.saleAc,
      LD_CODE: ctx.partyCode,
      CR_AMT: legs.saleAmount,
    });
  }

  // ---- kasar on the fine itself (slot 12) — the only money-free rows ---------------------------
  if (legs.kasarFineDr) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.KASAR_FINE_OUT)),
      AC_CODE: ctx.partyCode,
      LD_CODE: legs.kasarFineAc,
      IT_TYPE: legs.metal,
      SIGN: '-',
      ITM_FINE: legs.kasarFineDr,
      // No rate on the kasar-fine rows: 0 of 6 real rows carry one, unlike types 01/03/13.
    });
  }
  if (legs.kasarFineCr) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.KASAR_FINE_IN)),
      AC_CODE: ctx.partyCode,
      LD_CODE: legs.kasarFineAc,
      IT_TYPE: legs.metal,
      SIGN: '+',
      ITM_FINE: legs.kasarFineCr,
    });
  }

  // ---- settlement on the purchase side ---------------------------------------------------------
  if (legs.purchaseChequeAmount) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.PURCHASE_CHEQUE)),
      AC_CODE: legs.bankAc,
      LD_CODE: ctx.partyCode,
      CR_AMT: legs.purchaseChequeAmount,
    });
  }
  if (legs.purchaseKasarAmount) {
    rows.push({
      ...blank(ctx, key(ROJMEL_RATECUT_ROW_TYPE.PURCHASE_KASAR)),
      AC_CODE: legs.purchaseKasarAc,
      LD_CODE: ctx.partyCode,
      CR_AMT: legs.purchaseKasarAmount,
    });
  }
  return rows;
}

/**
 * Sales-order row types (book 020), from `Ac_Rojmel.Order_Rojmel` (lines 9–28).
 *
 * That routine has eight row types. Only these **four** ever fired, established by grouping the 55 real
 * rows of book 020 by `LEDR_KEY` type and matching each against a non-zero source column:
 *
 *   `01` 41 rows  advance            `ADV_AMT` non-zero on 74 of 76 orders
 *   `02` 11 rows  cheque             `CHQ_AMT` on 21
 *   `04`  2 rows  old metal, valued  `SL_PR_DETL.NET_AMT <> 0`
 *   `06`  1 row   old metal, unvalued `SL_PR_DETL.ITM_FINE <> 0 AND NET_AMT = 0`
 *
 * 41 + 11 + 2 + 1 = 55, matching the book exactly.
 *
 * **Unlike the rate-cut routine, the source and the data AGREE here on all four types** — checked one by
 * one. `Ac_Rojmel.cs` is a later version than the code that wrote this data, but the divergence is not
 * uniform across routines, so each type is verified rather than assumed either way.
 *
 * Dead and deliberately not built: `03` card (`CARD_AMT` is 0 of 76), `07` rate-cut fine (`RCUT_FINE` 0 of
 * 76), `08` UPI (`UPI_DATA` has 1 row company-wide).
 *
 * **`05` scheme adjustment is an unresolved ANOMALY and must not be implemented on a guess.** `SCHM_AMT` is
 * non-zero on **7 of 76** orders, yet there are **zero** type-05 Rojmel rows — seven populated source rows
 * produced no output. Writing it would add rows the desktop does not have, which is a parity failure in the
 * opposite direction from a missing row and considerably harder to notice.
 */
export const ROJMEL_ORDER_ROW_TYPE = {
  /** Advance received against the order. CREDIT, contra = `BOOK_DETL` slot 1 (book 020: `00001`). */
  ADVANCE: '01',
  /** Cheque tendered. DEBIT, and `AC_CODE` is the BANK — the reverse account order from the advance row. */
  CHEQUE: '02',
  /** Old metal taken in WITH a value. Per line. */
  OLD_METAL_VALUED: '04',
  /** Old metal taken in with NO value assigned. Per line, money-free. */
  OLD_METAL_UNVALUED: '06',
} as const;

export type RojmelOrderRowType = (typeof ROJMEL_ORDER_ROW_TYPE)[keyof typeof ROJMEL_ORDER_ROW_TYPE];

/** One `SL_PR_DETL` line: old metal taken in against the order. */
export interface OrderOldMetalLine {
  lineNo: number;
  /** The group's purchase account (`GROUP_MAST.PURC_AC`). */
  purchaseAc: string;
  /** Non-zero routes the line to type 04; zero with fine routes it to type 06. */
  netAmount: number;
  metal: Exclude<RojmelMetal, 'A'>;
  pcs?: number;
  grossWt?: number;
  netWt?: number;
  touch?: number;
  fine?: number;
  itemCode?: string;
  itemName?: string;
}

export interface OrderRojmelLegs {
  /** `BOOK_DETL` slot 1 — the contra on the advance row. Book 020: `00001`. Resolve, never hardcode. */
  advanceContraAc: string;
  bankAc: string;
  advanceAmount: number;
  chequeAmount: number;
  oldMetal?: OrderOldMetalLine[];
}

/**
 * Project a sales order into its Rojmel rows.
 *
 * Sampled real rows, one per type, from book 020:
 *
 *   t01  ac=party    ld=00001   A       cr 25000                          (also 100000 on another)
 *   t02  ac=bank     ld=party   A       dr <cheque>
 *   t04  ac=00010    ld=000519  A       dr 9300     gwt 1.690  fine 1.268  'OLD GOLD'
 *   t06  ac=000633   ld=00010   G '+'   dr 0 cr 0   gwt 18.310 fine 18.000 'OLD GOLD'
 *
 * ## The account order flips between the two header rows
 * Type 01 names the **party** in `AC_CODE` with the book slot as contra. Type 02 is the reverse — the
 * **bank** in `AC_CODE` and the party in `LD_CODE`. Same flip appears between the fine and amount families
 * elsewhere in this file; getting it backwards misfiles every row.
 *
 * ## Type 04 is a money row that carries metal
 * `IT_TYPE` is `'A'` yet `ITM_PCS`, `ITM_GWT`, `ITM_NWT`, `ITM_TOUCH` and `ITM_FINE` are all populated.
 * Deliberate: the day book shows metal taken in exchange **without counting it as a metal sale**. The
 * report's metal buckets key on `IT_TYPE`, so labelling this `'G'` would double-count the shop's gold.
 *
 * ## Type 06 is a true fine row and feeds the report
 * Both amounts zero, `IT_TYPE` the metal letter, `SIGN '+'`. It is metal accepted with no price agreed yet,
 * and it is what `RP_ROJMEL`'s gold/silver fine summaries read — they filter `ITM_FINE <> 0` split by
 * `SIGN`.
 *
 * ## The two old-metal types are mutually exclusive per line
 * By construction: one requires `NET_AMT <> 0`, the other `NET_AMT = 0`. A line cannot produce both.
 *
 * ## Line numbers
 * Types `01`/`02` are header rows — one per voucher, keys 23 characters, **no** line number. Types
 * `04`/`06` are per detail line — keys **33** characters with the line number right-aligned in 10.
 * Verified against all 55 real keys. Omitting it on the detail rows collides with `23505`, since
 * `LEDR_KEY` is the whole primary key.
 */
export function buildOrderRojmel(ctx: RojmelContext, legs: OrderRojmelLegs): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const key = (t: RojmelOrderRowType, lineNo?: number): string =>
    rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, t, lineNo);

  // Advance: the party is credited with money received before delivery. 41 of the book's 55 rows.
  if (legs.advanceAmount) {
    rows.push({
      ...blank(ctx, key(ROJMEL_ORDER_ROW_TYPE.ADVANCE)),
      AC_CODE: ctx.partyCode,
      LD_CODE: legs.advanceContraAc,
      CR_AMT: legs.advanceAmount,
    });
  }

  // Cheque: the bank is named here, not the party — the reverse of the advance row.
  if (legs.chequeAmount) {
    rows.push({
      ...blank(ctx, key(ROJMEL_ORDER_ROW_TYPE.CHEQUE)),
      AC_CODE: legs.bankAc,
      LD_CODE: ctx.partyCode,
      DR_AMT: legs.chequeAmount,
    });
  }

  for (const l of legs.oldMetal ?? []) {
    if (l.netAmount) {
      // Valued: a money row that keeps its weight. IT_TYPE stays 'A' on purpose.
      rows.push({
        ...blank(ctx, key(ROJMEL_ORDER_ROW_TYPE.OLD_METAL_VALUED, l.lineNo)),
        AC_CODE: l.purchaseAc,
        LD_CODE: ctx.partyCode,
        DR_AMT: l.netAmount,
        ITM_PCS: l.pcs ?? 0,
        ITM_GWT: l.grossWt ?? 0,
        ITM_NWT: l.netWt ?? 0,
        ITM_TOUCH: l.touch ?? 0,
        ITM_FINE: l.fine ?? 0,
        IT_DESC: l.itemName ?? '',
        IT_CODE: l.itemCode ?? '',
      });
    } else if (l.fine) {
      // Unvalued: metal in, no price agreed. Money-free, and the accounts flip back to party-first.
      rows.push({
        ...blank(ctx, key(ROJMEL_ORDER_ROW_TYPE.OLD_METAL_UNVALUED, l.lineNo)),
        AC_CODE: ctx.partyCode,
        LD_CODE: l.purchaseAc,
        IT_TYPE: l.metal,
        SIGN: '+', // metal coming IN
        ITM_PCS: l.pcs ?? 0,
        ITM_GWT: l.grossWt ?? 0,
        ITM_NWT: l.netWt ?? 0,
        ITM_TOUCH: l.touch ?? 0,
        ITM_FINE: l.fine,
        IT_DESC: l.itemName ?? '',
        IT_CODE: l.itemCode ?? '',
      });
    }
  }
  return rows;
}

/**
 * Scheme-adjustment row types (book 076, "Member Advance Adjust"), from `Ac_Rojmel.Schm_Adj_RojMel`
 * (lines 458–478).
 *
 * That routine has eight row types. Only these **three** ever fired, from grouping the 37 real rows of
 * book 076 by `LEDR_KEY` type and matching each against a non-zero source column in `AD_ADJ`:
 *
 *   `01` 21 rows  the principal adjusted   `ADJ_AMT - MEMB_BONUS <> 0`
 *   `02`  8 rows  the bonus portion        `MEMB_BONUS <> 0` — and `MEMB_BONUS` is non-zero on exactly 8
 *   `03`  8 rows  the settlement side      `ADJ_AMT <> 0 AND AC_CODE <> '00001' AND SBILL_AMT = 0`
 *
 * 21 + 8 + 8 = 37, matching the book exactly. Source and data agree on all three directions, checked
 * individually.
 *
 * **Types `04` to `08` are dead here, and two independent facts say so.** All five require
 * `GOLD_WT <> 0` or `GOLD_AMT <> 0`, and `GOLD_WT` is **0 on all 26 `AD_ADJ` rows**. They also require
 * `AD_MAST.SCHM_TYPE IN ('G','S')`, and all four of this company's schemes are `SCHM_TYPE 'A'` —
 * amount-based, not metal-based. A gold savings scheme would light them up; this shop does not run one.
 */
export const ROJMEL_SCHEME_ADJ_ROW_TYPE = {
  /** The principal being adjusted, net of any bonus. DEBIT on the scheme liability. */
  PRINCIPAL: '01',
  /** The bonus portion, separated out. DEBIT on the book's slot-1 account. */
  BONUS: '02',
  /** The settlement side — the account the balance was applied to. CREDIT. */
  SETTLEMENT: '03',
} as const;

export type RojmelSchemeAdjRowType =
  (typeof ROJMEL_SCHEME_ADJ_ROW_TYPE)[keyof typeof ROJMEL_SCHEME_ADJ_ROW_TYPE];

export interface SchemeAdjRojmelLine {
  lineNo: number;
  /** `AD_MAST.SCHM_AC` — the scheme liability account being released. */
  schemeAc: string;
  /** `BOOK_DETL` slot 1 — where the bonus is charged. */
  bonusAc: string;
  /** `AD_ADJ.AC_CODE` — the account the matured balance is applied to. */
  settlementAc: string;
  /** `AD_ADJ.ADJ_AMT` = `MEMB_AMT + MEMB_BONUS - MEMB_LESS`, verified on every real row. */
  adjustedAmount: number;
  bonus: number;
  /** `AD_ADJ.SBILL_AMT`. Non-zero suppresses the settlement row — the bill carries it instead. */
  settledAgainstBillAmount?: number;
  memberName?: string;
}

/**
 * Project a scheme adjustment (maturity / advance adjust) into its Rojmel rows.
 *
 * ## Shapes, taken from the source and confirmed against the real rows
 *
 *   t01  AC_CODE = scheme liability   LD_CODE = settlement account   DEBIT   `ADJ_AMT - MEMB_BONUS`
 *   t02  AC_CODE = book slot 1        LD_CODE = settlement account   DEBIT   `MEMB_BONUS`
 *   t03  AC_CODE = settlement account LD_CODE = scheme liability     CREDIT  `ADJ_AMT`
 *
 * Types `01` and `02` are the **scheme side** — they name a scheme or bonus account and put the
 * settlement account in `LD_CODE`. Type `03` is the **mirror**: the settlement account named, the scheme
 * liability as contra. That pairing is the same shape contra and the member instalment use.
 *
 * ## The bonus is separated deliberately
 * Type `01` carries `ADJ_AMT - MEMB_BONUS`, not `ADJ_AMT`. The bonus is charged to a different account
 * (book slot 1) because it is an expense the shop grants, not scheme money the member paid in. Summing
 * `01` and `02` gives `ADJ_AMT`, which is why type `03` — the single settlement credit — balances against
 * the pair. **21 type-01 rows against 26 `AD_ADJ` rows**: on five rows the whole adjustment was bonus, so
 * `ADJ_AMT - MEMB_BONUS` came to zero and the guard suppressed the row.
 *
 * ## The settlement row is conditional in two ways
 * `AC_CODE <> '00001'` excludes a cash settlement — cash is implicit in a day book, the same reasoning
 * that gives a cash receipt no second row in `buildMoneyRojmel`. And `SBILL_AMT = 0` excludes a balance
 * applied to a sales bill, because the bill's own Rojmel rows already carry it. Both are honoured below;
 * the cash test is left to the caller, which knows its own account codes.
 *
 * ## Line numbers
 * All three types carry `STR(A.SR_NO)` and all 37 real keys are **33** characters. One voucher can adjust
 * several members, so the line number is what keeps the keys distinct — `LEDR_KEY` is the whole primary
 * key and two members sharing one would collide with `23505`.
 */
export function buildSchemeAdjRojmel(
  ctx: RojmelContext,
  lines: SchemeAdjRojmelLine[],
): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const key = (t: RojmelSchemeAdjRowType, lineNo: number): string =>
    rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, t, lineNo);

  for (const l of lines) {
    const principal = l.adjustedAmount - l.bonus;
    const label = l.memberName ? ` - ${l.memberName}` : '';

    if (principal) {
      rows.push({
        ...blank(ctx, key(ROJMEL_SCHEME_ADJ_ROW_TYPE.PRINCIPAL, l.lineNo)),
        AC_CODE: l.schemeAc,
        LD_CODE: l.settlementAc,
        DR_AMT: principal,
        IT_DESC: `S-ADJ${label}`,
      });
    }
    if (l.bonus) {
      rows.push({
        ...blank(ctx, key(ROJMEL_SCHEME_ADJ_ROW_TYPE.BONUS, l.lineNo)),
        AC_CODE: l.bonusAc,
        LD_CODE: l.settlementAc,
        DR_AMT: l.bonus,
        IT_DESC: `S-BONUS${label}`,
      });
    }
    // Suppressed when the balance went onto a sales bill: that bill's own rows already carry it, and
    // emitting here would double-count the settlement in the day book.
    if (l.adjustedAmount && !l.settledAgainstBillAmount) {
      rows.push({
        ...blank(ctx, key(ROJMEL_SCHEME_ADJ_ROW_TYPE.SETTLEMENT, l.lineNo)),
        AC_CODE: l.settlementAc,
        LD_CODE: l.schemeAc,
        CR_AMT: l.adjustedAmount,
      });
    }
  }
  return rows;
}

/**
 * Fine-JV row types (book 078), from `Ac_Rojmel.Contra_Rojmel` **lines 342 and 344**.
 *
 * One desktop routine serves two books: `MAIN_BOOK = 'CONTRA'` (book 017, see `buildJournalRojmel`) and
 * `MAIN_BOOK = 'FINE JV'` (book 078, here). Both read `CONTRA_DATA`; the contra book uses its money
 * columns and the fine JV its `DR_FINE`/`CR_FINE` columns.
 *
 * Measured on book 078 — 28 rows, and source and data agree exactly:
 *
 *   `01` 14 rows  `SIGN '+'`  `ITM_FINE = CR_FINE`  guard `CR_FINE <> 0`
 *   `02` 14 rows  `SIGN '-'`  `ITM_FINE = DR_FINE`  guard `DR_FINE <> 0`
 *
 * **Both types carry no money and no gross weight**: `DR_AMT`, `CR_AMT` and `ITM_GWT` are zero on all 28
 * real rows. A fine JV moves pure fine between two accounts — there is no physical article to weigh and
 * no cash involved, which is exactly what distinguishes it from every other family in this file.
 *
 * The equal counts (14 and 14) reflect one pair per voucher: a JV debits one fine position and credits
 * another, so both guards fire on every well-formed voucher.
 */
export const ROJMEL_FINEJV_ROW_TYPE = {
  /** Fine credited into an account — `SIGN '+'`, metal in. */
  CREDIT_FINE: '01',
  /** Fine debited out of an account — `SIGN '-'`, metal out. */
  DEBIT_FINE: '02',
} as const;

export type RojmelFineJvRowType =
  (typeof ROJMEL_FINEJV_ROW_TYPE)[keyof typeof ROJMEL_FINEJV_ROW_TYPE];

/** One `CONTRA_DATA` line of a fine JV. */
export interface FineJvRojmelLine {
  lineNo: number;
  /** `CONTRA_DATA.AC_CODE`. */
  acCode: string;
  /** `CONTRA_DATA.LD_CODE` — the contra account. */
  ldCode: string;
  metal: Exclude<RojmelMetal, 'A'>;
  /** `CR_FINE` → type `01`. */
  creditFine: number;
  /** `DR_FINE` → type `02`. */
  debitFine: number;
  description?: string;
}

/**
 * Project a fine JV into its Rojmel rows.
 *
 * Sampled real rows: `ac=000939 ld=000275 G '+' fine 36.200`, `ac=000939 ld=000258 G '+' fine 42.240`.
 * Accounts are copied straight from the `CONTRA_DATA` line — unlike most families in this file, there is
 * no account flip between row types and no `BOOK_DETL` slot involved.
 *
 * A single line can legitimately produce **both** rows: one `CONTRA_DATA` row may carry a debit fine and a
 * credit fine at once, and the desktop's two inserts are independently guarded.
 *
 * Keys are 33 characters — both types carry `Str(A.SR_NO)`, because a JV can move fine across several
 * account pairs in one voucher and `LEDR_KEY` is the whole primary key.
 */
export function buildFineJvRojmel(ctx: RojmelContext, lines: FineJvRojmelLine[]): RojmelRow[] {
  const rows: RojmelRow[] = [];
  const key = (t: RojmelFineJvRowType, lineNo: number): string =>
    rojmelLedrKey(ctx.scope, ctx.coBook, ctx.vchNo, t, lineNo);

  for (const l of lines) {
    // Fine only: no DR_AMT, no CR_AMT, no ITM_GWT. Verified zero on all 28 real rows.
    if (l.creditFine) {
      rows.push({
        ...blank(ctx, key(ROJMEL_FINEJV_ROW_TYPE.CREDIT_FINE, l.lineNo)),
        AC_CODE: l.acCode,
        LD_CODE: l.ldCode,
        IT_TYPE: l.metal,
        SIGN: '+',
        ITM_FINE: l.creditFine,
        IT_DESC: l.description ?? '',
      });
    }
    if (l.debitFine) {
      rows.push({
        ...blank(ctx, key(ROJMEL_FINEJV_ROW_TYPE.DEBIT_FINE, l.lineNo)),
        AC_CODE: l.acCode,
        LD_CODE: l.ldCode,
        IT_TYPE: l.metal,
        SIGN: '-',
        ITM_FINE: l.debitFine,
        IT_DESC: l.description ?? '',
      });
    }
  }
  return rows;
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
