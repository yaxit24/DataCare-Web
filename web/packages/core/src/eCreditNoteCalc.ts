import { Decimal } from 'decimal.js';
import { round, roundHalfEven } from './money.js';

/**
 * E CRNT (E Credit Note) line and bill arithmetic — TR_SL_EBILL.CommPassTotal / BILL_TOTAL.
 *
 * Source (unified/src/csharp/DataCareNext/TR_SL_EBILL.cs, sha256 in the X15 contract):
 *   weights / fine            5150-5275   Strings.Format "0.000"  → half-up (`round`)
 *   item amount by RATE_TYPE  5360-5480   Math.Round(x, num5)     → half-even (`roundHalfEven`)
 *   labour rate from Lbr%     5625        Math.Round(x, MsLbrRof)
 *   labour amount by LBR_TYPE 5600-5640   Math.Round(x, digits)
 *   taxable / taxable rate    5755-5830
 *   GST split                 5102, 5403, 5407  Math.Round(x, MsTaxRof)
 *   line net                  5431        Math.Round(txbl + taxes, 0)
 *   bill totals               9062-9178
 *
 * Every Math.Round result is also displayed through Strings.Format "0.00", so a value rounded to more
 * than two places by a setting is then rounded half-up to two places, which is what the grid saves.
 *
 * Deliberate, documented limits of this profile (tracked as open X15 descendants):
 *   - operator overrides that back-compute a rate from a typed amount are not modelled;
 *   - TCS is not modelled (the E CRNT ledger only posts TCS for BOOK_INOUT='O' books, while the
 *     credit-note book is 'I', so a TCS amount would unbalance the desktop ledger);
 *   - the registration-specific DM035NPDM rounding branch is represented only through ALL_ROF_REMOVE.
 */

export type ECreditNoteRateType = string; // 'P' pieces, '1' per 10 g, 'K' per kg, anything else per gram
export type ECreditNoteLabourType = string; // 'P' pcs, 'N' net, 'K' kg (net+ghat), anything else gross

export interface ECreditNotePolicy {
  /** num5/digits: 0, or 2 when CO_SET.ALL_ROF_REMOVE = 'Y' (TR_SL_EBILL.cs 5123-5137). */
  amountDigits: 0 | 2;
  /** MsTaxRof from CO_SET.TAX_ROF (MS_OPNCOMP.cs 671/741-743). */
  taxDigits: number;
  /** MsLbrRof from CO_SET.LBR_ROF (MS_OPNCOMP.cs 691/817-819). */
  labourRateDigits: number;
  /** MsLbrWithGht from CO_SET_NEW.LBR_WITH_GHT (blank → 'Y'). */
  labourIncludesGhat: boolean;
  /** SL_DATA.AC_GST_TYPE / AC_MAST.AC_GST_TYPE = 'I'. */
  interState: boolean;
}

export interface ECreditNoteLineInput {
  pcs?: number;
  grossWt?: number;
  lessWt?: number;
  ghatPercent?: number;
  touch?: number;
  westPercent?: number;
  rate?: number;
  rateType?: ECreditNoteRateType;
  labourType?: ECreditNoteLabourType;
  labourRate?: number;
  labourPercent?: number;
  otherAmount?: number;
  mrp?: number;
  taxPercent?: number;
}

export interface ECreditNoteLineResult {
  pcs: number;
  grossWt: number;
  lessWt: number;
  netWt: number;
  ghatWt: number;
  touch: number;
  westPercent: number;
  fine: number;
  rate: number;
  rateType: string;
  itemAmount: number;
  labourType: string;
  labourPercent: number;
  labourRate: number;
  labourAmount: number;
  otherAmount: number;
  mrp: number;
  taxableAmount: number;
  taxableRate: number;
  taxPercent: number;
  igst: number;
  cgst: number;
  sgst: number;
  taxAmount: number;
  netAmount: number;
}

export interface ECreditNoteTender {
  cash?: number;
  cheque?: number;
  card?: number;
  kasar?: number;
  tdsPercent?: number;
}

export interface ECreditNoteBillResult {
  netAmount: number;
  igst: number;
  cgst: number;
  sgst: number;
  taxAmount: number;
  labourAmount: number;
  otherAmount: number;
  totalAmount: number;
  roundOff: number;
  tdsAmount: number;
  cash: number;
  cheque: number;
  card: number;
  kasar: number;
  outstanding: number;
  pcs: number;
  grossWt: number;
  netWt: number;
  mrpTotal: number;
}

const n = (value: unknown): number => {
  const v = Number(value ?? 0);
  if (!Number.isFinite(v)) throw new Error(`E CRNT calculation received a non-finite value`);
  return v;
};
const d = (value: number) => new Decimal(value);
/** Math.Round(x, digits) displayed through Strings.Format "0.00". */
const mathRound2 = (value: Decimal.Value, digits: number) => round(roundHalfEven(value, digits), 2);

export function calculateECreditNoteLine(
  input: ECreditNoteLineInput,
  policy: ECreditNotePolicy,
): ECreditNoteLineResult {
  const pcs = n(input.pcs);
  const grossWt = round(n(input.grossWt), 3);
  const lessWt = round(n(input.lessWt), 3);
  const touch = round(n(input.touch), 2);
  const westPercent = round(n(input.westPercent), 2);
  const ghatPercent = n(input.ghatPercent);
  const rate = n(input.rate);
  const rateType = String(input.rateType ?? '').trim();
  const labourType = String(input.labourType ?? '').trim();
  const labourPercent = n(input.labourPercent);
  const otherAmount = round(n(input.otherAmount), 2);
  const mrp = round(n(input.mrp), 2);
  const taxPercent = round(n(input.taxPercent), 2);

  // 5156-5168: NetWt = GrWt - LsWt ("0.000").
  const netWt = round(d(grossWt).minus(lessWt), 3);
  // 5170-5175: GhtWt = NetWt * GhtPrc / 100 when both are non-zero.
  const ghatWt =
    ghatPercent !== 0 && netWt !== 0 ? round(d(netWt).times(ghatPercent).div(100), 3) : 0;
  // 5176-5250: fine = (net + ghat) * (touch + wastage) / 100; with no touch/wastage it is net + ghat.
  const purity = d(touch).plus(westPercent);
  const fine = purity.isZero()
    ? round(d(netWt).plus(ghatWt), 3)
    : netWt === 0
      ? 0
      : round(d(netWt).plus(ghatWt).times(purity).div(100), 3);

  // 5360-5480: item amount only when a rate exists and there is something to price.
  let itemAmount = 0;
  if (rate !== 0 && d(fine).plus(netWt).plus(pcs).toNumber() !== 0) {
    const base = fine > 0 ? fine : netWt;
    const raw =
      rateType === 'P'
        ? d(pcs).times(rate)
        : rateType === '1'
          ? d(base).times(d(rate).div(10))
          : rateType === 'K'
            ? d(base).times(d(rate).div(1000))
            : d(base).times(rate);
    itemAmount = mathRound2(raw, policy.amountDigits);
  }

  // 5569-5575: labour rate derived from labour % of the item rate.
  let labourRate = round(n(input.labourRate), 2);
  if (labourPercent !== 0 && rate !== 0) {
    labourRate = mathRound2(d(rate).times(labourPercent).div(100), policy.labourRateDigits);
  }
  // 5580-5610: labour amount by LBR_TYPE.
  let labourAmount = 0;
  if (labourRate !== 0) {
    const net = d(netWt);
    const netGhat = net.plus(ghatWt);
    const raw =
      labourType === 'P'
        ? d(pcs).times(labourRate)
        : labourType === 'N'
          ? (policy.labourIncludesGhat ? netGhat : net).times(labourRate)
          : labourType === 'K'
            ? netGhat.times(d(labourRate).div(1000))
            : d(grossWt).times(labourRate);
    labourAmount = mathRound2(raw, policy.amountDigits);
  }

  // 5767-5810: taxable amount and taxable rate.
  let taxableAmount = round(d(labourAmount).plus(otherAmount).plus(itemAmount), 2);
  let taxableRate = 0;
  if (mrp !== 0) {
    taxableAmount = mrp;
    taxableRate = pcs !== 0 ? round(d(taxableAmount).div(pcs), 3) : 0;
  } else if (grossWt === 0) {
    taxableAmount = round(d(itemAmount).plus(otherAmount), 2);
    taxableRate = pcs !== 0 ? round(d(taxableAmount).div(pcs), 3) : 0;
  } else if (taxableAmount !== 0 && netWt !== 0) {
    taxableRate = round(d(taxableAmount).div(netWt), 3);
  }

  // 5102/5403/5407: GST on the taxable amount.
  let igst = 0;
  let cgst = 0;
  let sgst = 0;
  if (taxableAmount !== 0 && taxPercent !== 0) {
    if (policy.interState) {
      igst = mathRound2(d(taxableAmount).times(taxPercent).div(100), policy.taxDigits);
    } else {
      const half = mathRound2(
        d(taxableAmount).times(d(taxPercent).div(2)).div(100),
        policy.taxDigits,
      );
      cgst = half;
      sgst = half;
    }
  }
  const taxAmount = round(d(igst).plus(cgst).plus(sgst), 2);
  // 5431: line net rounded to whole rupees with .NET Math.Round (half-to-even).
  const netAmount = round(roundHalfEven(d(taxableAmount).plus(taxAmount), 0), 2);

  return {
    pcs,
    grossWt,
    lessWt,
    netWt,
    ghatWt,
    touch,
    westPercent,
    fine,
    rate,
    rateType,
    itemAmount,
    labourType,
    labourPercent,
    labourRate,
    labourAmount,
    otherAmount,
    mrp,
    taxableAmount,
    taxableRate,
    taxPercent,
    igst,
    cgst,
    sgst,
    taxAmount,
    netAmount,
  };
}

/** TR_SL_EBILL.cs 7614: a grid row is saved when it has an item with MRP, or any gross/labour/other/taxable value. */
export function eCreditNoteLineIsSaved(itemCode: string, line: ECreditNoteLineResult): boolean {
  return (
    (String(itemCode ?? '').trim() !== '' && line.mrp !== 0) ||
    d(line.grossWt)
      .plus(line.labourAmount)
      .plus(line.otherAmount)
      .plus(line.taxableAmount)
      .toNumber() !== 0
  );
}

/** TR_SL_EBILL.cs MSG_TOT_FILL (4341) and BILL_TOTAL (9062-9178). */
export function calculateECreditNoteBill(
  lines: readonly ECreditNoteLineResult[],
  tender: ECreditNoteTender = {},
): ECreditNoteBillResult {
  const sum = (pick: (line: ECreditNoteLineResult) => number, dp: number) =>
    round(
      lines.reduce((acc, line) => acc.plus(pick(line)), new Decimal(0)),
      dp,
    );
  const netAmount = sum((l) => l.taxableAmount, 2);
  const igst = sum((l) => l.igst, 2);
  const cgst = sum((l) => l.cgst, 2);
  const sgst = sum((l) => l.sgst, 2);
  const taxAmount = round(d(igst).plus(cgst).plus(sgst), 2);
  const lineNet = sum((l) => l.netAmount, 2);
  const tcs = 0;
  const totalAmount = round(d(lineNet).plus(tcs), 2);
  const roundOff = round(
    d(totalAmount).minus(d(netAmount).plus(tcs).plus(igst).plus(cgst).plus(sgst)),
    2,
  );
  const tdsPercent = n(tender.tdsPercent);
  const tdsAmount =
    tdsPercent !== 0 && netAmount !== 0
      ? round(roundHalfEven(d(netAmount).times(tdsPercent).div(100), 0), 2)
      : 0;
  const cash = round(n(tender.cash), 2);
  const cheque = round(n(tender.cheque), 2);
  const card = round(n(tender.card), 2);
  const kasar = round(n(tender.kasar), 2);
  const outstanding =
    netAmount !== 0
      ? round(d(totalAmount).minus(tdsAmount).minus(cash).minus(cheque).minus(card).minus(kasar), 2)
      : 0;
  return {
    netAmount,
    igst,
    cgst,
    sgst,
    taxAmount,
    labourAmount: sum((l) => l.labourAmount, 2),
    otherAmount: sum((l) => l.otherAmount, 2),
    totalAmount,
    roundOff,
    tdsAmount,
    cash,
    cheque,
    card,
    kasar,
    outstanding,
    pcs: sum((l) => l.pcs, 3),
    grossWt: sum((l) => l.grossWt, 3),
    netWt: sum((l) => l.netWt, 3),
    mrpTotal: sum((l) => l.mrp, 3),
  };
}

/** MS_OPNCOMP.cs 671/741-743: MsTaxRof = Math.Round(Val(TAX_ROF)); above 5 becomes 2. */
export function eCreditNoteTaxDigits(raw: unknown): number {
  const text = String(raw ?? '').trim();
  if (!text) return 0;
  const value = Number(text);
  if (!Number.isFinite(value)) throw new Error(`CO_SET.TAX_ROF is not numeric: ${text}`);
  const digits = roundHalfEven(value, 0);
  if (digits < 0) throw new Error(`CO_SET.TAX_ROF is negative: ${text}`);
  return digits > 5 ? 2 : digits;
}

/** MS_OPNCOMP.cs 691/817-819: MsLbrRof = CInt(LBR_ROF); above 3 becomes 0. */
export function eCreditNoteLabourRateDigits(raw: unknown): number {
  const text = String(raw ?? '').trim();
  if (!text) return 0;
  const value = Number(text);
  if (!Number.isFinite(value)) throw new Error(`CO_SET.LBR_ROF is not numeric: ${text}`);
  const digits = roundHalfEven(value, 0);
  if (digits < 0) throw new Error(`CO_SET.LBR_ROF is negative: ${text}`);
  return digits > 3 ? 0 : digits;
}
