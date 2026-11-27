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
 *     13/14 TDS: party Cr / TDS tax account Dr :112-114 (leg 01 adds TDS_AMT back)
 *     15/16 cheque :116-118     17/18 card :120-122     21/22+STR order advance (ORD_AC_CODE 00020) :131-133
 *     STR(SR_NO)+23/24 old metal :135-137     25/26 cash :139-141     27/28 cash paid, 'M' books :143-145
 *     29/30 cash paid, 'T' books :147-149     31/32 kasar :151-153     33/34 discount :155-157
 *     36/37+STR UPI :161-163
 *     35 round-off, the book's slot 5 (Cr when ROF_AMT > 0, Dr its absolute value when < 0) :159
 *
 * The 2024-25 data was written by an older build with other codes (party 01, revenue 03, tax 04, bank 09/10, cash
 * 19/20, kasar 25/26, line 02); the owner chose the current source. The UAE-only legs 02-06 are not posted.
 */
export const SALE_LEG = {
  partyBill: 1,
  revenueLine: 7,
  revenue: 8,
  tax: 9,
  tcs: 10,
  hallmark: 11,
  hallmarkTax: 12,
  partyTds: 13,
  tds: 14,
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
  /** The operator-typed round-off SL_DATA.ROF_AMT, one leg on the book's slot 5 (Ac_Ledr.cs:159); see saleRoundingResidue. */
  roundOff: 35,
  partyUpi: 36,
  upi: 37,
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
 * The sale's UNPOSTED rounding, Σ DR − Σ CR of its ledger (OWNER DECISION 1B, 2026-11-27; posting.ts
 * DesktopRoundingResidue): the party's bill debit (TOT_AMT + DISC_AMT + TDS_AMT, Ac_Ledr.cs:64) less the item, tax and
 * charge credits and the typed round-off leg 35 (:90-109, :159). The settlement, TDS and discount pairs balance
 * among themselves, so this is the whole imbalance.
 *
 * The desktop rounds TOT_AMT to TOT_AMT_ROF (TR_SALE.cs:19047) but stores in ROF_AMT only the round-off the operator
 * types (:15051), so the difference is posted nowhere. On the line path each item leg is its line's NET_AMT (:90)
 * while the bill rounds its NET_AMT first (:18957), which the desktop leaves unposted as well.
 */
export function saleRoundingResidue(
  partyDebit: number,
  credits: ReadonlyArray<{ amount: number }>,
  roundOff: number,
): number {
  return roundTo(partyDebit - credits.reduce((sum, leg) => sum + leg.amount, 0) - roundOff, 3);
}

/**
 * The most saleRoundingResidue may be: half a TOT_AMT_ROF unit for the bill total's rounding (TR_SALE.cs:19047),
 * and on the line path another half for the bill NET_AMT's (:18957).
 */
export function saleRoundingBound(billTotalDecimals: number, linePath: boolean): number {
  return roundTo(0.5 * 10 ** -billTotalDecimals * (linePath ? 2 : 1), 6);
}

/**
 * Build the AC_DATA legs of a sale (pure), keyed as Sales_Ledr keys them (SALE_LEG above). They balance but for the
 * bill total's unposted rounding (saleRoundingResidue), as the desktop's do.
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
  totals: Pick<BillTotals, 'total' | 'taxable' | 'tax'> &
    Partial<Pick<BillTotals, 'net' | 'discount' | 'roundOff'>>;
  incomeLegs?: LineLeg[];
  charges?: Array<{ legType: number; ac: string; amount: number }>;
  discountAc?: string;
  /** TDS (SL_DATA.TDS_AMT) and the TDS code's tax account: leg 01 adds it back, the 13/14 pair carries it. */
  tds?: SaleSettlement;
  /**
   * SL_DATA.ROF_AMT, the round-off the operator typed (0 when none), and the book's slot-5 account it posts to as leg
   * 35 (Ac_Ledr.cs:159 `B.SR_NO = 5 AND A.ROF_AMT <> 0`). Nothing else is posted for the bill total's rounding.
   */
  roundOff?: SaleSettlement;
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
    // TOT_AMT + DISC_AMT + TDS_AMT (Ac_Ledr.cs:64).
    const partyDebit = roundTo(p.totals.total + discount + (p.tds?.amount ?? 0), 3);
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
    // Leg 35: slot 5 Cr ROF_AMT when > 0, Dr ABS(ROF_AMT) when < 0, the party as LD_CODE, PARTY_AC_CODE ''.
    const roundOff = p.roundOff?.amount ?? 0;
    if (roundOff !== 0)
      lines.push({
        ...base,
        legType: SALE_LEG.roundOff,
        AC_CODE: p.roundOff!.ac,
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
    partyExtra: Partial<LedgerLine> = {},
  ): void => {
    if (!s || s.amount === 0) return;
    const value = s.amount;
    lines.push({
      ...base,
      ...keys.party,
      ...extra,
      ...partyExtra,
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
  // TDS: 13 credits the party against the TDS tax account with PARTY_AC_CODE '' (:112), 14 debits that account
  // (:114); both only when TDS_AMT <> 0.
  pair(p.tds, { party: leg(SALE_LEG.partyTds), account: leg(SALE_LEG.tds) }, 'in', {}, {
    PARTY_AC_CODE: '',
  } as Partial<LedgerLine>);
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
