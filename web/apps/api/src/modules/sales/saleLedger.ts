/**
 * The sale's AC_DATA legs, as Sales_Ledr posts and keys them (Ac_Ledr.cs:61-172). Pure; sales.ts writes them.
 */
import type { BillTotals } from '@datacare/core';
import { round as roundTo } from '@datacare/core';
import type { LedgerLine } from '../posting/posting.js';
import { lineLegKey, sqlStr, type LineLeg } from '../posting/lineLegs.js';

type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};

/**
 * The LEDR_KEY code of each sale leg, as Sales_Ledr writes it (Ac_Ledr.cs:61-172, the current DataCareNext build).
 *
 * The last two characters of a sale LEDR_KEY name the leg's ROLE. Settlement legs come in pairs of party credit and
 * receiving-account debit, the party first:
 *
 *     01 party Dr (TOT_AMT + DISC_AMT + TDS_AMT)        :64
 *     STR(SR_NO)+07 line item Cr (ITM_TYPE 'A' books)   :90       08 book item Cr (other books)   :92
 *     09 tax Cr :94     10 TCS Cr :96     11 hallmark Cr :107     12 hallmark tax Cr :109
 *     15/16 cheque :116-118     17/18 card :120-122     21/22+STR order advance (ORD_AC_CODE 00020) :131-133
 *     STR(SR_NO)+23/24 old metal :135-137     25/26 cash :139-141     27/28 cash paid, 'M' books :143-145
 *     29/30 cash paid, 'T' books :147-149     31/32 kasar :151-153     33/34 discount :155-157
 *     36/37+STR UPI :161-163
 *
 * The 2024-25 data was written by an older build with other codes (party 01, revenue 03, tax 04, bank 09/10, cash
 * 19/20, kasar 25/26, line 02); the owner chose the current source. The UAE-only legs 02-06 are not posted, nor
 * leg 35: the desktop posts it from ROF_AMT, which it stores 0 (see webRoundOff).
 */
export const SALE_LEG = {
  partyBill: 1,
  revenueLine: 7,
  revenue: 8,
  tax: 9,
  tcs: 10,
  hallmark: 11,
  hallmarkTax: 12,
  partyCheque: 15,
  cheque: 16,
  partyCard: 17,
  card: 18,
  partyOrder: 21,
  order: 22,
  partyOldMetal: 23,
  oldMetal: 24,
  partyCash: 25,
  cash: 26,
  partyCashPaidEstimate: 27,
  cashPaidEstimate: 28,
  partyCashPaidTax: 29,
  cashPaidTax: 30,
  partyKasar: 31,
  kasar: 32,
  partyDiscount: 33,
  discount: 34,
  partyUpi: 36,
  upi: 37,
  /**
   * The web's round-off leg, which the DESKTOP DOES NOT WRITE.
   *
   * The desktop posts leg 35 from SL_DATA.ROF_AMT only when it is non-zero (Ac_Ledr.cs:159), and ROF_AMT is 0.00 on
   * all 190 real sale headers: the desktop rounds the bill total and posts the sub-rupee residue nowhere, which is
   * why 89 of its sale vouchers are out of balance by under a rupee. The web balances instead, with this leg. Whether
   * to keep it, drop it, or post it as 35 is an open owner question (docs/FIRST-REAL-COMPARISON.md 3.4); until then
   * its code stays 99, outside every desktop code.
   */
  webRoundOff: 99,
} as const;

/** `code + STR(SR_NO)`: the tail of a desktop key that puts the row number AFTER the code (legs 21/22, 36/37). */
function codeThenLine(code: number, srNo: number): { legKeySuffix: string } {
  return { legKeySuffix: `${String(code).padStart(2, '0')}${sqlStr(srNo)}` };
}

/** A settlement pair: the party's credit, then the receiving account's debit. */
interface SaleSettlement {
  ac: string;
  amount: number;
}

/**
 * The amount of the web's round-off leg (SALE_LEG.webRoundOff): whatever balances the party's bill debit against the
 * item, tax and charge credits.
 *
 * On the header path the item leg is SL_DATA.NET_AMT and the party debit TOT_AMT + DISC_AMT, so this is the bill's
 * round-off. On the line path each item leg is its own line's NET_AMT (Ac_Ledr.cs:90), while the bill total is
 * rounded from the ROUNDED net (calc.ts billTotals, TOT_AMT_ROF): with paise on a line and a rupee-rounded bill the
 * two differ by the line nets' rounding, which the desktop leaves unposted. The web carries that residue in the same
 * round-off leg; nothing else about the leg changes.
 */
export function saleLedgerRoundOff(
  partyDebit: number,
  credits: ReadonlyArray<{ amount: number }>,
): number {
  return roundTo(partyDebit - credits.reduce((sum, leg) => sum + leg.amount, 0), 3);
}

/** The round-off leg would carry more than rounding: the item legs do not add up to the bill. */
export class SaleLedgerResidueError extends Error {
  constructor(roundOff: number, billRoundOff: number, bound: number) {
    super(
      `sale ledger does not agree with the bill total: round-off ${roundOff} against the bill's ${billRoundOff} ` +
        `(more than the ${bound} that rounding can explain)`,
    );
    this.name = 'SaleLedgerResidueError';
  }
}

/**
 * Build the balanced AC_DATA legs of a sale (pure), keyed as Sales_Ledr keys them (SALE_LEG above).
 *
 * - `totals.total` is the bill (SL_DATA.TOT_AMT, with hallmark and TCS); `totals.discount` the bill discount. The
 *   party's debit is their sum (Ac_Ledr.cs:64), the discount coming back as the 33/34 pair (:155-157).
 * - `incomeLegs`, on an ITM_TYPE 'A' book, are the lines (`srNo`, NET_AMT, group account): one 07 leg each (:90).
 *   Without them the book posts ONE 08 leg of `totals.net` (SL_DATA.NET_AMT) to `controlAc`, the book's slot-1
 *   account (:92).
 * - `charges` are TCS (10), hallmark (11) and hallmark tax (12), credits the party's bill debit already carries.
 */
export function buildSaleLedger(p: {
  key: VoucherKey;
  acCode: string;
  salesAc: string;
  taxAc: string;
  roundAc: string;
  controlAc?: string;
  rateUnfix?: boolean;
  vchType?: string;
  totals: Pick<BillTotals, 'total' | 'taxable' | 'tax' | 'roundOff'> &
    Partial<Pick<BillTotals, 'net' | 'discount'>>;
  incomeLegs?: LineLeg[];
  charges?: Array<{ legType: number; ac: string; amount: number }>;
  discountAc?: string;
  /**
   * The most the round-off leg may differ from the bill's own round-off (`totals.roundOff`). The difference is the
   * line nets' rounding into the bill total, so it is bounded; past the bound the save is refused.
   */
  maxRoundOffResidue?: number;
  payments?: {
    cash?: SaleSettlement;
    cheque?: SaleSettlement;
    card?: SaleSettlement;
    /** UPI_DATA rows in SR_NO order. */
    /** UPI_DATA rows, each with its own SR_NO (the key's line). */
    upi?: Array<SaleSettlement & { srNo: number }>;
    /** SL_ORD_ADJ rows in SR_NO order whose ORD_AC_CODE is 00020 (Ac_Ledr.cs:131). */
    orders?: SaleSettlement[];
    /** SL_PR_DETL rows in SR_NO order, each to its item group's PURC_AC. */
    oldMetal?: SaleSettlement[];
    kasar?: SaleSettlement;
    /** Cash paid back to the customer, and the book type that picks its codes (27/28 'M', 29/30 'T'). */
    cashPaid?: SaleSettlement & { bookType: string };
  };
}): LedgerLine[] {
  const base = { ...p.key, VCH_TYPE: p.vchType ?? 'SALE' };
  const lines: LedgerLine[] = [];
  const discount = p.totals.discount ?? 0;
  const charges = (p.charges ?? []).filter((charge) => charge.amount !== 0);

  if (!p.rateUnfix) {
    const partyDebit = roundTo(p.totals.total + discount, 3);
    if (p.totals.total !== 0)
      lines.push({
        ...base,
        legType: SALE_LEG.partyBill,
        AC_CODE: p.acCode,
        LD_CODE: p.controlAc ?? p.salesAc,
        DR_AMT: partyDebit,
        CR_AMT: 0,
        SIGN: 'D',
      });
    const income: LineLeg[] =
      p.incomeLegs && p.incomeLegs.length
        ? p.incomeLegs
        : // The book leg 08 is filtered `A.TOT_AMT <> 0` like the party's (Ac_Ledr.cs:92).
          p.totals.total !== 0
          ? [{ ac: p.controlAc ?? p.salesAc, amount: p.totals.net ?? p.totals.taxable }]
          : [];
    for (const leg of income)
      if (leg.amount !== 0)
        lines.push({
          ...base,
          ...lineLegKey(leg, leg.srNo == null ? SALE_LEG.revenue : SALE_LEG.revenueLine),
          AC_CODE: leg.ac,
          LD_CODE: p.acCode,
          DR_AMT: 0,
          CR_AMT: leg.amount,
          SIGN: 'C',
        });
    if (p.totals.tax !== 0)
      lines.push({
        ...base,
        legType: SALE_LEG.tax,
        AC_CODE: p.taxAc,
        LD_CODE: p.acCode,
        DR_AMT: 0,
        CR_AMT: p.totals.tax,
        SIGN: 'C',
      });
    for (const charge of charges)
      lines.push({
        ...base,
        legType: charge.legType,
        AC_CODE: charge.ac,
        LD_CODE: p.acCode,
        DR_AMT: 0,
        CR_AMT: charge.amount,
        SIGN: 'C',
      });
    const roundOff =
      p.totals.total === 0
        ? 0
        : saleLedgerRoundOff(partyDebit, [...income, { amount: p.totals.tax }, ...charges]);
    // The round-off leg may carry only rounding: past the caller's bound the item legs disagree with the bill.
    if (
      p.maxRoundOffResidue != null &&
      Math.abs(roundOff - p.totals.roundOff) > p.maxRoundOffResidue + 1e-9
    )
      throw new SaleLedgerResidueError(roundOff, p.totals.roundOff, p.maxRoundOffResidue);
    if (roundOff !== 0)
      lines.push({
        ...base,
        legType: SALE_LEG.webRoundOff,
        AC_CODE: p.roundAc,
        LD_CODE: p.acCode,
        DR_AMT: roundOff < 0 ? Math.abs(roundOff) : 0,
        CR_AMT: roundOff > 0 ? roundOff : 0,
        SIGN: roundOff > 0 ? 'C' : 'D',
      });
  } else {
    // An unfixed sale posts no bill, item or tax leg (Ac_Ledr.cs:64, :90, :92 `RATE_UNFIX <> 'Y'`). A charge on it is
    // billed to the customer by its own debit so the voucher stays balanced; the desktop has no such leg.
    for (const charge of charges) {
      lines.push({
        ...base,
        AC_CODE: charge.ac,
        LD_CODE: p.acCode,
        DR_AMT: 0,
        CR_AMT: charge.amount,
        SIGN: 'C',
      });
      lines.push({
        ...base,
        AC_CODE: p.acCode,
        LD_CODE: charge.ac,
        DR_AMT: charge.amount,
        CR_AMT: 0,
        SIGN: 'D',
      });
    }
  }

  /** A settlement pair, the party's leg first. `dir` 'in' credits the party (money received), 'out' debits it. */
  const pair = (
    s: SaleSettlement | undefined,
    keys: { party: Record<string, unknown>; account: Record<string, unknown> },
    dir: 'in' | 'out' = 'in',
    extra: Partial<LedgerLine> = {},
  ): void => {
    if (!s || s.amount === 0) return;
    const value = s.amount;
    lines.push({
      ...base,
      ...keys.party,
      ...extra,
      AC_CODE: p.acCode,
      LD_CODE: s.ac,
      DR_AMT: dir === 'out' ? value : 0,
      CR_AMT: dir === 'in' ? value : 0,
      SIGN: dir === 'in' ? 'C' : 'D',
    } as LedgerLine);
    lines.push({
      ...base,
      ...keys.account,
      ...extra,
      AC_CODE: s.ac,
      LD_CODE: p.acCode,
      DR_AMT: dir === 'in' ? value : 0,
      CR_AMT: dir === 'out' ? value : 0,
      SIGN: dir === 'in' ? 'D' : 'C',
    } as LedgerLine);
  };
  const leg = (code: number) => ({ legType: code });
  const pay = p.payments ?? {};
  pair(pay.cheque, { party: leg(SALE_LEG.partyCheque), account: leg(SALE_LEG.cheque) });
  pair(pay.card, { party: leg(SALE_LEG.partyCard), account: leg(SALE_LEG.card) });
  (pay.orders ?? []).forEach((order, i) =>
    pair(order, {
      party: codeThenLine(SALE_LEG.partyOrder, i + 1),
      account: codeThenLine(SALE_LEG.order, i + 1),
    }),
  );
  // Old metal is keyed after its SL_PR_DETL line, and writes BILL_NO '' (Ac_Ledr.cs:135-137 select '').
  (pay.oldMetal ?? []).forEach((metal, i) =>
    pair(
      metal,
      {
        party: lineLegKey({ srNo: i + 1 }, SALE_LEG.partyOldMetal),
        account: lineLegKey({ srNo: i + 1 }, SALE_LEG.oldMetal),
      },
      'in',
      { BILL_NO: '' } as Partial<LedgerLine>,
    ),
  );
  pair(pay.cash, { party: leg(SALE_LEG.partyCash), account: leg(SALE_LEG.cash) });
  if (pay.cashPaid && (pay.cashPaid.bookType === 'M' || pay.cashPaid.bookType === 'T'))
    pair(
      pay.cashPaid,
      pay.cashPaid.bookType === 'M'
        ? { party: leg(SALE_LEG.partyCashPaidEstimate), account: leg(SALE_LEG.cashPaidEstimate) }
        : { party: leg(SALE_LEG.partyCashPaidTax), account: leg(SALE_LEG.cashPaidTax) },
      'out',
    );
  pair(pay.kasar, { party: leg(SALE_LEG.partyKasar), account: leg(SALE_LEG.kasar) });
  // No RATE_UNFIX filter on the discount pair (Ac_Ledr.cs:155-157).
  if (discount !== 0)
    pair(
      { ac: p.discountAc ?? p.roundAc, amount: discount },
      { party: leg(SALE_LEG.partyDiscount), account: leg(SALE_LEG.discount) },
    );
  for (const upi of pay.upi ?? [])
    pair(upi, {
      party: codeThenLine(SALE_LEG.partyUpi, upi.srNo),
      account: codeThenLine(SALE_LEG.upi, upi.srNo),
    });
  return lines;
}
