import { round, roundHalfEven, type BillTotals } from '@datacare/core';
import {
  assertVoucherBalanced,
  type LedgerLine,
  type PostInput,
  type DesktopRoundingResidue,
} from '../posting/posting.js';
import { buildLineLegs, lineLegKey, type LineLeg } from '../posting/lineLegs.js';
import { payoutLegs } from '../finance/tender.js';
import { gstTaxRows } from '../shared/taxDataRows.js';
import type { ResolvedTaxPolicy } from '../shared/taxPolicy.js';
import { buildPurchaseRojmel, type PurchaseRojmelOptions } from '../shared/purchaseRojmel.js';
import { purchaseExpenseSplit } from '../shared/settingsBehavior.js';
import { rojmelMetalFor } from '../shared/rojmel.js';
import { PurchaseValidationError } from './purchaseValidation.js';
type VoucherKey = {
  CO_CODE: string;
  LC_CODE: string;
  CO_YEAR: string;
  CO_BOOK: string;
  VCH_NO: string;
};
const num = (v: unknown): number => Number(v ?? 0);
const text = (v: unknown): string => String(v ?? '').trim();
const round2 = (n: number): number => Math.round((n + Number.EPSILON) * 100) / 100;
const round3 = (n: number): number => Math.round((n + Number.EPSILON) * 1000) / 1000;
export function buildPurchaseLedger(p: {
  key: VoucherKey;
  acCode: string;
  purchaseAc: string;
  taxAc: string;
  roundAc: string;
  controlAc?: string;
  vchType?: string;
  totals: Pick<BillTotals, 'total' | 'taxable' | 'tax' | 'roundOff'>;
  expenseLegs?: LineLeg[];
  tcs?: number;
  tcsAc?: string;
  /** Non-A books with PURC_WITH_LBR='N': labour/other to slot 4 (Ac_Ledr.cs:419-421). */
  labourLeg?: { ac: string; amount: number };
}): LedgerLine[] {
  const base = { ...p.key, VCH_TYPE: p.vchType ?? 'PURC' };
  const lines: LedgerLine[] = [];
  if (p.totals.total + (p.tcs ?? 0) !== 0)
    lines.push({
      ...base,
      AC_CODE: p.acCode,
      legType: PURC_LEG.party,
      LD_CODE: p.controlAc ?? p.purchaseAc,
      DR_AMT: 0,
      CR_AMT: round2(p.totals.total + (p.tcs ?? 0)),
      SIGN: 'C',
    });
  const expense =
    p.expenseLegs && p.expenseLegs.length
      ? p.expenseLegs
      : [{ ac: p.purchaseAc, amount: p.totals.taxable }];
  for (const leg of expense)
    if (leg.amount !== 0)
      lines.push({
        ...base,
        ...lineLegKey(leg, PURC_LEG.purchase), // G176: per-line key on a multi-account bill
        AC_CODE: leg.ac,
        LD_CODE: p.acCode,
        DR_AMT: leg.amount,
        CR_AMT: 0,
        SIGN: 'D',
      });
  if (p.labourLeg && p.labourLeg.amount !== 0)
    lines.push({
      ...base,
      AC_CODE: p.labourLeg.ac,
      LD_CODE: p.acCode,
      DR_AMT: p.labourLeg.amount,
      CR_AMT: 0,
      SIGN: 'D',
    });
  if (p.totals.tax !== 0)
    lines.push({
      ...base,
      legType: PURC_LEG.tax,
      AC_CODE: p.taxAc,
      LD_CODE: p.acCode,
      DR_AMT: p.totals.tax,
      CR_AMT: 0,
      SIGN: 'D',
    });
  // Ac_Ledr.cs:434: parent TAX_MAST account, debit TCS, supplier as LD_CODE.
  if (p.tcs && !p.tcsAc) throw new PurchaseValidationError('TCS posting account is required');
  if (p.tcs)
    lines.push({
      ...base,
      legType: PURC_LEG.tcs,
      AC_CODE: p.tcsAc!,
      LD_CODE: p.acCode,
      DR_AMT: p.tcs,
      CR_AMT: 0,
      SIGN: 'D',
    });
  if (p.totals.roundOff > 0)
    lines.push({
      ...base,
      legType: PURC_LEG.roundOff,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: p.totals.roundOff,
      CR_AMT: 0,
      SIGN: 'D',
    });
  else if (p.totals.roundOff < 0)
    lines.push({
      ...base,
      legType: PURC_LEG.roundOff,
      AC_CODE: p.roundAc,
      LD_CODE: p.acCode,
      DR_AMT: 0,
      CR_AMT: Math.abs(p.totals.roundOff),
      SIGN: 'C',
    });
  return lines;
}

/** Allocate the bill taxable across distinct per-group expense accounts, proportional to each group's
 *  line-net share; the last account absorbs the rounding remainder so Σ legs == taxable exactly. */
export function buildExpenseLegs(
  items: { net: number; ac: string }[],
  taxable: number,
  lineNetTotal: number,
): { ac: string; amount: number }[] {
  const R2 = (x: number): number => Math.round((x + 1e-9) * 100) / 100;
  const byAc = new Map<string, number>();
  for (const it of items) byAc.set(it.ac, R2((byAc.get(it.ac) ?? 0) + it.net));
  const acs = [...byAc.keys()];
  // Every item carries a resolved expense account (writer resolves purchaseAc fail-closed, per-group
  // PURC_AC falls back to it), so acs is never empty here; guard the invariant rather than a literal.
  if (acs.length <= 1) {
    const only = acs[0];
    if (!only) throw new PurchaseValidationError('purchase expense account could not be resolved');
    return [{ ac: only, amount: R2(taxable) }];
  }
  const legs: { ac: string; amount: number }[] = [];
  let allocated = 0;
  for (let i = 0; i < acs.length; i++) {
    const ac = acs[i] as string;
    const amount =
      i === acs.length - 1
        ? R2(taxable - allocated)
        : lineNetTotal > 0
          ? R2((taxable * (byAc.get(ac) as number)) / lineNetTotal)
          : 0;
    if (i < acs.length - 1) allocated = R2(allocated + amount);
    legs.push({ ac, amount });
  }
  return legs;
}

export function buildPurchaseFineLedger(p: {
  key: VoucherKey;
  acCode: string;
  purchaseAc: string;
  vchType?: string;
  rateUnfix?: boolean;
  purcAcByItem?: Record<string, string>;
  lines: Array<{
    itCode: string;
    metal?: 'G' | 'S';
    fine: number;
    metalAmount: number;
    otherFineWt?: number;
    silverFineWt?: number;
  }>;
}): LedgerLine[] {
  if (p.rateUnfix) return [];
  // ONE FINE LEG PER LINE, not one per metal/account combination.
  //
  // Measured on book 035: 42 real type-21 legs across 11 accounts, and voucher 00004 alone has THREE - lines 1,
  // 2 and 3 carrying 12.712, 11.950 and 3.950, all gold and all against purchase account 00008. Aggregating by
  // `${metal}|${ldCode}` collapsed those into a single leg of 28.612.
  //
  // THE KEY IS A DIFFERENT LAYOUT FROM THE SAME BOOK'S MONEY LEGS. Money legs 01/03/06/16/17 are 23 characters
  // with the leg type at 22-23; these fine legs are 33 with `<line><leg>` right-aligned in 12 - the cash books'
  // shape. So one table of one book uses two layouts, chosen by leg type. Real keys:
  //
  //     [01002024-202503500004         121]  fine 12.712
  //     [01002024-202503500004         221]  fine 11.950
  //     [01002024-202503500004         321]  fine  3.950
  //
  // `legKeySuffix` carries it per row, which is why that mechanism is per-LINE rather than per-family.
  const suffix = (line: number): string =>
    `${line}${String(FINE_LEG).padStart(2, '0')}`.padStart(12, ' ');
  const out: LedgerLine[] = [];
  p.lines.forEach((line, idx) => {
    if (round2(line.metalAmount) !== 0) return;
    const metal = line.metal ?? 'G';
    const ldCode = metal === 'S' ? '00009' : (p.purcAcByItem?.[line.itCode.trim()] ?? p.purchaseAc);
    const fine =
      metal === 'S' ? round3(num(line.silverFineWt)) : round3(line.fine + num(line.otherFineWt));
    if (fine === 0) return;
    out.push({
      ...p.key,
      legKeySuffix: suffix(idx + 1),
      VCH_TYPE: p.vchType ?? 'PURC',
      AC_CODE: p.acCode,
      LD_CODE: ldCode,
      IT_TYPE: metal,
      SIGN: '+',
      FINE_WT: fine,
      FINE_RATE: 0,
      DR_AMT: 0,
      CR_AMT: 0,
    });
  });
  return out;
}

/**
 * The purchase FINE leg's type code, measured on books 035 and 036: type 21, on all 42 real legs.
 *
 * The money legs use different codes entirely - 01 party Cr, 03 purchase Dr, 06 tax Dr, 16/17 the settlement
 * pair, 18/19 the kasar pair - and they are 23-character keys while these are 33.
 */
const FINE_LEG = 21;

/**
 * Purchase leg type codes, measured across books 035 and 036.
 *
 *   01 party      Cr   (17)   the bill - the sale's shape with the directions inverted
 *   03 purchase   Dr   (17)   00008 gold / 00009 silver
 *   06 tax 00085  Dr    (2)
 *   16 party Dr / 17 cash Cr   (5)   paying the supplier
 *   18 party Dr / 19 kasar 00042 Cr  (2)   book 036 only
 *   21 fine legs       (42)   weight only, 33-character keys - see buildPurchaseFineLedger
 *
 * NOTE THE TAX CODE. Purchase uses 06 where the SALE family uses 04 for the same role. So the codes are not a
 * universal role map even for identical roles - they are per book, which is the third independent confirmation
 * of that after the cash/bank split and the receipt/payment split.
 */
export const PURC_LEG = {
  party: 1,
  purchase: 3,
  tax: 6,
  /** TCS (Ac_Ledr.cs:434). The keys here follow the build that wrote the 2024-25 data, which numbers TCS 07. */
  tcs: 7,
  settleParty: 16,
  settleCash: 17,
  kasarParty: 18,
  kasar: 19,
  /** The typed round-off PR_DATA.ROF_AMT on slot 3 (Ac_Ledr.cs:460); nothing posts the bill total's own rounding. */
  roundOff: 26,
} as const;

export interface PurchasePostingSettings {
  vchType: string;
  bookName: string;
  purchaseAc: string;
  controlAc: string;
  taxAc: string;
  tcsAc: string;
  roundAc: string;
  cashAc: string;
  kasarAc: string;
  hmChargeAc?: string;
  /** Writer-only fallback when the supplier master has no name; PR_DATA does not retain it. */
  partyName?: string;
  labourAc?: string;
  linePathBook: boolean;
  withLabour: boolean;
  purcAcByItem: Record<string, string>;
  itemNameByItem: Record<string, string>;
  taxPolicy: ResolvedTaxPolicy;
  rojmelOptions: PurchaseRojmelOptions;
  roundBillTotal: (n: number) => number;
  roundTaxAmount: (n: number) => number;
  billTotalDecimals: number;
  /** UPI is not persisted. Refresh only admits a zero unexplained settlement residual. */
  upiAmt?: number;
}

/**
 * Pure posting projection of PR_DATA/PR_DETL. Ac_Ledr.cs:377-476, Ac_Rojmel.cs:115-177,
 * Ac_Tax.cs:111-132 (unified/src/csharp_nextdm/DataCareNext).
 * No rate, fine, tax or TCS recalculation: these are saved economic facts. Keep the web's measured
 * role numbering and existing tax-base/HM semantics; this extraction is not a parity correction.
 */
export function purchasePostInput(
  h: Record<string, unknown>,
  details: Record<string, unknown>[],
  s: PurchasePostingSettings,
): PostInput {
  const key: VoucherKey = {
    CO_CODE: text(h.CO_CODE),
    LC_CODE: text(h.LC_CODE),
    CO_YEAR: text(h.CO_YEAR),
    CO_BOOK: text(h.CO_BOOK),
    VCH_NO: text(h.VCH_NO),
  };
  const acCode = text(h.AC_CODE);
  const supplierName = text(h.AC_NAME);
  const taxable = s.roundBillTotal(num(h.NET_AMT) - num(h.DISC_AMT));
  const tcs = num(h.TCS_AMT);
  const tax = num(h.TAX_AMT);
  const rof = num(h.ROF_AMT);
  const gross = taxable + tax + tcs + rof;
  const billWithTcs = s.roundBillTotal(gross);
  const residue: DesktopRoundingResidue = {
    amount: billWithTcs === 0 ? 0 : roundHalfEven(gross - billWithTcs, 3),
    bound: 0.5 * 10 ** -s.billTotalDecimals,
  };
  // PR_DETL.NET_AMT includes commission; the writer's posting net does not. Use component totals,
  // matching purchaseLineAmounts' two-decimal net, without re-running its rate/labour calculation.
  const net = (d: Record<string, unknown>) =>
    round(num(d.ITM_AMT) + num(d.LBR_AMT) + num(d.OTH_AMT), 2);
  const splits = details.map((d) =>
    purchaseExpenseSplit(net(d), num(d.LBR_AMT), num(d.OTH_AMT), s.linePathBook || s.withLabour),
  );
  const labourOther = round2(splits.reduce((n, d) => n + d.labourOther, 0));
  const expenseLegs = s.linePathBook
    ? buildLineLegs(
        details.map((d, i) => ({
          net: splits[i]!.primary,
          ac: s.purcAcByItem[text(d.IT_CODE)] ?? s.purchaseAc,
        })),
        round2(taxable - labourOther),
        splits.reduce((n, d) => n + d.primary, 0),
      )
    : [{ ac: s.controlAc, amount: round2(taxable - labourOther) }];
  const ledger = buildPurchaseLedger({
    key,
    acCode,
    purchaseAc: s.purchaseAc,
    controlAc: s.controlAc,
    taxAc: s.taxAc,
    roundAc: s.roundAc,
    vchType: s.vchType,
    totals: { total: billWithTcs - tcs, taxable, tax, roundOff: rof },
    expenseLegs,
    tcs,
    tcsAc: s.tcsAc,
    labourLeg: labourOther ? { ac: s.labourAc!, amount: labourOther } : undefined,
  });
  const hmAmt = num(h.HM_AMT),
    hmTax = num(h.HM_TAX_AMT),
    hmPct = num(h.HM_TAX_PRC);
  if (hmAmt > 0) {
    const base = { ...key, VCH_TYPE: s.vchType };
    ledger.push({
      ...base,
      AC_CODE: s.hmChargeAc ?? 'HMCHRG',
      LD_CODE: acCode,
      DR_AMT: hmAmt,
      CR_AMT: 0,
      SIGN: 'D',
    });
    if (hmTax > 0)
      ledger.push({
        ...base,
        AC_CODE: s.taxAc,
        LD_CODE: acCode,
        DR_AMT: hmTax,
        CR_AMT: 0,
        SIGN: 'D',
      });
    ledger.push({
      ...base,
      AC_CODE: acCode,
      LD_CODE: s.hmChargeAc ?? 'HMCHRG',
      DR_AMT: 0,
      CR_AMT: round2(hmAmt + hmTax),
      SIGN: 'C',
    });
  }
  assertVoucherBalanced(ledger, residue);
  ledger.push(
    ...payoutLegs(
      { ...key, VCH_TYPE: s.vchType },
      {
        partyAc: acCode,
        cashAmt: num(h.CASH_AMT),
        chequeAmt: num(h.CHQ_AMT),
        cardAmt: num(h.CARD_AMT),
        upiAmt: s.upiAmt,
        kasar: num(h.KASAR_AMT),
        cashAc: s.cashAc,
        bankAc: text(h.BANK_AC),
        kasarAc: s.kasarAc,
        legs: { cashParty: PURC_LEG.settleParty, cash: PURC_LEG.settleCash },
      },
    ).legs,
  );
  ledger.push(
    ...buildPurchaseFineLedger({
      key,
      acCode,
      purchaseAc: s.purchaseAc,
      vchType: s.vchType,
      rateUnfix: text(h.RATE_UNFIX) === 'Y',
      purcAcByItem: s.purcAcByItem,
      lines: details.map((d) => ({
        itCode: text(d.IT_CODE),
        metal: text(d.IT_TYPE) as 'G' | 'S',
        fine: num(d.ITM_FINE),
        metalAmount: num(d.ITM_AMT),
        otherFineWt: num(d.ITM_OTH_FINE),
        silverFineWt: num(d.SILVER_FINE),
      })),
    }),
  );
  for (const line of ledger) {
    line.VCH_DATE = h.VCH_DATE;
    line.ENTRY_TIME = h.VCH_TIME;
    if (line.legType === PURC_LEG.party || line.legType === PURC_LEG.settleCash)
      line.LDR_NAME = supplierName;
  }
  const taxBase = {
    ...key,
    TRAN_TYPE: 'P',
    BOOK_NAME: s.bookName,
    VCH_DATE: h.VCH_DATE,
    AC_CODE: acCode,
    PARTY_NAME: supplierName || null,
    NET_AMT: taxable,
    DISC_AMT: num(h.DISC_AMT),
    TOT_AMT: billWithTcs,
    TAX_SIGN: '-',
    TAX_CODE: s.taxPolicy.taxCode,
  };
  const interState = text(h.AC_GST_TYPE) === 'I';
  const taxRows: Record<string, unknown>[] = tax
    ? gstTaxRows(taxBase, s.taxPolicy, {
        interState,
        ratePct: num(h.TAX_PRC),
        igst: num(h.IGST_TAX),
        sgst: num(h.SGST_TAX),
        cgst: num(h.CGST_TAX),
      })
    : [];
  if (hmAmt > 0 && hmTax > 0) {
    const cgst = s.roundTaxAmount(hmTax / 2);
    for (const amount of interState ? [hmTax] : [cgst, s.roundTaxAmount(hmTax - cgst)]) {
      taxRows.push({
        ...taxBase,
        NET_AMT: hmAmt,
        SR_NO: taxRows.length + 1,
        TAX_TYPE: s.taxPolicy.taxGroup,
        TAX_PRC: interState ? hmPct : Math.round((hmPct / 2 + 1e-9) * 100) / 100,
        TAX_AMT: amount,
      });
    }
  }
  const rojmelRows = buildPurchaseRojmel(
    {
      scope: { coCode: key.CO_CODE, lcCode: key.LC_CODE, coYear: key.CO_YEAR },
      key,
      coBook: key.CO_BOOK,
      vchNo: key.VCH_NO,
      vchDate: h.VCH_DATE as Date,
      vchType: s.vchType,
      bookName: s.bookName,
      partyName: s.partyName ?? supplierName,
      partyCode: acCode,
      voucherDescription: text(h.VCH_DESC),
      partyMasterName: supplierName,
    },
    details.map((d) => ({
      lineNo: num(d.SR_NO),
      revenueAc: s.purcAcByItem[text(d.IT_CODE)] ?? s.purchaseAc,
      amount: net(d),
      itemCode: text(d.IT_CODE),
      itemName: s.itemNameByItem[text(d.IT_CODE)] ?? '',
      metal: rojmelMetalFor(text(d.IT_TYPE)),
      pcs: num(d.ITM_PCS),
      grossWt: num(d.ITM_GWT),
      netWt: num(d.ITM_NWT),
      touch: num(d.ITM_TOUCH),
      wastage: num(d.ITM_WEST_PRC),
      fine: num(d.ITM_FINE),
      otherFine: num(d.ITM_OTH_FINE),
      silverFine: num(d.SILVER_FINE),
      rate: num(d.ITM_RATE),
      itemAmount: num(d.ITM_AMT),
      labourRate: num(d.LBR_RATE),
      labourAmount: num(d.LBR_AMT),
      otherAmount: num(d.OTH_AMT),
      netAmount: net(d),
    })),
    h,
    s.rojmelOptions,
  );
  return {
    ledger: { table: 'AC_DATA', lines: ledger },
    bookName: s.bookName,
    partyAc: acCode,
    desktopRoundingResidue: residue,
    writes: [
      ...(taxRows.length ? [{ table: 'TAX_DATA', rows: taxRows }] : []),
      ...(rojmelRows.length ? [{ table: 'ROJ_MEL_DATA', rows: rojmelRows }] : []),
    ],
  };
}
