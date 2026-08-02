import type { LedgerLine } from '../posting/posting.js';

/**
 * Shared settlement/tender legs (F2). Voucher bodies post their core ledger (e.g. Cr supplier total /
 * Dr expense), then APPEND these self-balanced pairs for the amount settled now — mirroring how sales
 * appends HM/TCS/Kasar. No tender ⇒ no legs ⇒ identical to the un-settled voucher (backward-compatible).
 *
 *  • payoutLegs  — money OUT (pay a supplier/expense): per tender, Dr party / Cr cash|bank ; kasar Dr party / Cr KASAR (discount received). Reduces the party's net Cr (payable) to the unpaid balance.
 *  • receiptLegs — money IN  (refund/receive): per tender, Dr cash|bank / Cr party ; kasar Dr KASAR / Cr party (write-off). Reduces the party's net Dr (receivable).
 */
const R2 = (x: number): number => Math.round((x + 1e-9) * 100) / 100;

export interface TenderParams {
  /** Per-book leg type codes; omitted keeps the reserved-band fallback. */
  legs?: TenderLegCodes;
  partyAc: string;
  cashAmt?: number;
  chequeAmt?: number;
  cardAmt?: number;
  upiAmt?: number;
  kasar?: number;
  cashAc?: string; // default 'CASH'
  bankAc?: string; // default 'BANK' (cheque+card+upi land here)
  kasarAc?: string; // default 'KASAR'
}
export interface TenderResult {
  legs: LedgerLine[];
  paidNow: number;
  kasar: number;
  cashAmt: number;
  bankPaid: number;
}

function amounts(p: TenderParams) {
  const cashAmt = R2(Number(p.cashAmt ?? 0));
  const bankPaid = R2(
    R2(Number(p.chequeAmt ?? 0)) + R2(Number(p.cardAmt ?? 0)) + R2(Number(p.upiAmt ?? 0)),
  );
  const kasar = R2(Number(p.kasar ?? 0));
  return { cashAmt, bankPaid, kasar, paidNow: R2(cashAmt + bankPaid) };
}

/** Payment OUT (purchase / other-expense): Dr party / Cr cash|bank + kasar Dr party / Cr KASAR. */
/**
 * Leg type codes for a tender pair, supplied by the CALLER.
 *
 * They are per book and cannot be defaulted here. Measured examples: a purchase settlement is 16 party Dr / 17
 * cash Cr on books 035/036, while a SALE settlement is 19/20 for cash and 09/10 for bank, and a cash-book
 * payment is 05/06. Four different pairs for the same role, so this helper takes them rather than guessing.
 *
 * A caller that has not measured its codes omits this and keeps the positional fallback, which lands in the
 * reserved 50+ band and is therefore visibly not a desktop code.
 */
export interface TenderLegCodes {
  cashParty?: number;
  cash?: number;
  bankParty?: number;
  bank?: number;
  kasarParty?: number;
  kasar?: number;
}

export function payoutLegs(base: Record<string, unknown>, p: TenderParams): TenderResult {
  const { cashAmt, bankPaid, kasar, paidNow } = amounts(p);
  const legs: LedgerLine[] = [];
  if (cashAmt > 0) {
    legs.push({
      ...base,
      ...(p.legs?.cashParty != null ? { legType: p.legs.cashParty } : {}),
      AC_CODE: p.partyAc,
      LD_CODE: p.cashAc ?? 'CASH',
      DR_AMT: cashAmt,
      CR_AMT: 0,
      SIGN: 'D',
    } as LedgerLine);
    legs.push({
      ...base,
      ...(p.legs?.cash != null ? { legType: p.legs.cash } : {}),
      AC_CODE: p.cashAc ?? 'CASH',
      LD_CODE: p.partyAc,
      DR_AMT: 0,
      CR_AMT: cashAmt,
      SIGN: 'C',
    } as LedgerLine);
  }
  if (bankPaid > 0) {
    legs.push({
      ...base,
      AC_CODE: p.partyAc,
      LD_CODE: p.bankAc ?? 'BANK',
      DR_AMT: bankPaid,
      CR_AMT: 0,
      SIGN: 'D',
    } as LedgerLine);
    legs.push({
      ...base,
      AC_CODE: p.bankAc ?? 'BANK',
      LD_CODE: p.partyAc,
      DR_AMT: 0,
      CR_AMT: bankPaid,
      SIGN: 'C',
    } as LedgerLine);
  }
  if (kasar > 0) {
    legs.push({
      ...base,
      AC_CODE: p.partyAc,
      LD_CODE: p.kasarAc ?? 'KASAR',
      DR_AMT: kasar,
      CR_AMT: 0,
      SIGN: 'D',
    } as LedgerLine);
    legs.push({
      ...base,
      AC_CODE: p.kasarAc ?? 'KASAR',
      LD_CODE: p.partyAc,
      DR_AMT: 0,
      CR_AMT: kasar,
      SIGN: 'C',
    } as LedgerLine);
  }
  return { legs, paidNow, kasar, cashAmt, bankPaid };
}

/** Money IN (refund / receive): Dr cash|bank / Cr party + kasar Dr KASAR / Cr party. */
export function receiptLegs(base: Record<string, unknown>, p: TenderParams): TenderResult {
  const { cashAmt, bankPaid, kasar, paidNow } = amounts(p);
  const legs: LedgerLine[] = [];
  if (cashAmt > 0) {
    legs.push({
      ...base,
      AC_CODE: p.cashAc ?? 'CASH',
      LD_CODE: p.partyAc,
      DR_AMT: cashAmt,
      CR_AMT: 0,
      SIGN: 'D',
    } as LedgerLine);
    legs.push({
      ...base,
      AC_CODE: p.partyAc,
      LD_CODE: p.cashAc ?? 'CASH',
      DR_AMT: 0,
      CR_AMT: cashAmt,
      SIGN: 'C',
    } as LedgerLine);
  }
  if (bankPaid > 0) {
    legs.push({
      ...base,
      AC_CODE: p.bankAc ?? 'BANK',
      LD_CODE: p.partyAc,
      DR_AMT: bankPaid,
      CR_AMT: 0,
      SIGN: 'D',
    } as LedgerLine);
    legs.push({
      ...base,
      AC_CODE: p.partyAc,
      LD_CODE: p.bankAc ?? 'BANK',
      DR_AMT: 0,
      CR_AMT: bankPaid,
      SIGN: 'C',
    } as LedgerLine);
  }
  if (kasar > 0) {
    legs.push({
      ...base,
      AC_CODE: p.kasarAc ?? 'KASAR',
      LD_CODE: p.partyAc,
      DR_AMT: kasar,
      CR_AMT: 0,
      SIGN: 'D',
    } as LedgerLine);
    legs.push({
      ...base,
      AC_CODE: p.partyAc,
      LD_CODE: p.kasarAc ?? 'KASAR',
      DR_AMT: 0,
      CR_AMT: kasar,
      SIGN: 'C',
    } as LedgerLine);
  }
  return { legs, paidNow, kasar, cashAmt, bankPaid };
}

/**
 * Desktop threshold decision shared by cash-receipt and sale tender writers.
 * TR_CASH.cs:2913-2922 blocks cumulative cash strictly above CASH_LIMIT.
 * TR_SALE.cs:15111-15128 requires a party PAN when taxable bill value is at/above PAN_CARD_VAL.
 */
export function tenderThresholdDecision(input: {
  cashAmount: number;
  priorCash: number;
  billValue: number;
  cashLimit: number;
  panCardVal: number;
}): { cashBlocked: boolean; panRequired: boolean } {
  return {
    cashBlocked:
      input.cashLimit > 0 &&
      R2(Number(input.cashAmount) + Number(input.priorCash)) > Number(input.cashLimit),
    panRequired: Number(input.billValue) >= Number(input.panCardVal),
  };
}
