import { describe, it, expect } from 'vitest';
import {
  netWtOf,
  ghtWtOf,
  fine,
  itmAmt,
  totAmt,
  netAmt,
  rollup,
  buildRateCutLedger,
  rateCutHeaderTotals,
  type RateCutLine,
  type RateCutPostingFigures,
} from '../src/modules/sales/rateCut.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';

const key = { CO_CODE: '01', LC_CODE: '00', CO_YEAR: '2023-2024', CO_BOOK: '034', VCH_NO: '00005' };

/**
 * BOOK_DETL of the real books 034/064 (Next23/Live24): SR1 00003 SALES GOLD, SR2 00008 PURCHASE GOLD,
 * SR3 00001 CASH, SR4 00057 KASAR JAVK, SR6 00041 LABOUR INCOME, SR7 00056 LABOUR EXP, SR8 00004 SALES SILVER,
 * SR9 00009 PURCHASE SILVER, SR11 00077 OTHER CHARGES.
 */
const accounts = {
  goldAc: '00003',
  purchaseAc: '00008',
  cashAc: '00001',
  kasarAc: '00057',
  lbrAc: '00041',
  lbrExpAc: '00056',
  silverSaleAc: '00004',
  silverPurcAc: '00009',
  othAc: '00077',
};

const zero: RateCutPostingFigures = {
  itType: 'G',
  fineRate: 0,
  drAmt: 0,
  crAmt: 0,
  drFine: 0,
  crFine: 0,
  slFine: 0,
  prFine: 0,
  slItmAmt: 0,
  prItmAmt: 0,
  slLbrAmt: 0,
  slOthAmt: 0,
  prLbrAmt: 0,
  prOthAmt: 0,
  slChqAmt: 0,
  slCardAmt: 0,
  slCashAmt: 0,
  slKasarAmt: 0,
  prChqAmt: 0,
  prCardAmt: 0,
  prCashAmt: 0,
  prKasarAmt: 0,
};

const ledgerFor = (
  figures: Partial<RateCutPostingFigures>,
  options: { tradeFine?: boolean; accounts?: Record<string, string>; party?: string } = {},
) =>
  buildRateCutLedger(key, {
    customer: options.party ?? '000209',
    figures: { ...zero, ...figures },
    accounts: options.accounts ?? accounts,
    bankAc: '',
    cardAc: '',
    receivedBankAc: '',
    receivedCardAc: '',
    tradeFine: options.tradeFine ?? false,
    vchDate: new Date('2023-06-01'),
    vchType: 'WSALE',
    bookName: 'WH SALES',
    coBook: '034',
  });

/** The fields the desktop rows were compared on, one object per leg, keyed by the desktop leg code. */
const shape = (lines: ReturnType<typeof ledgerFor>) =>
  lines.map((l) => ({
    leg: Number(l.legType),
    ac: l.AC_CODE,
    ld: l.LD_CODE,
    dr: l.DR_AMT,
    cr: l.CR_AMT,
    it: l.IT_TYPE,
    sign: l.SIGN,
    fine: l.FINE_WT,
    rate: l.FINE_RATE,
  }));

describe('rate-cut pure computation (spec §2)', () => {
  it('netWt = gross − other; ghtWt = net × ght% / 100', () => {
    expect(netWtOf(10.5, 0.5)).toBe(10);
    expect(ghtWtOf(10, 5)).toBe(0.5);
  });

  it('fine = (net + ght) × (touch + west)/100; touch+west=0 ⇒ net + ght', () => {
    expect(fine(2.5, 0, 82, 0)).toBe(2.05); // 2.5 × 82% = 2.050
    expect(fine(100, 0, 90, 2)).toBe(92); // touch + wastage folded in
    expect(fine(2.05, 0, 0, 0)).toBe(2.05); // 100% metal, no touch reduction
  });

  it('GOLDEN: fine 2.050 at rate 7300 (per-gram) ⇒ itmAmt 14965', () => {
    const f = fine(2.5, 0, 82, 0); // → 2.050
    expect(f).toBe(2.05);
    expect(itmAmt(f, 7300, 'default')).toBe(14965);
    expect(itmAmt(2.05, 7300, 'G')).toBe(14965); // 'G' is not P/1/K ⇒ default per-gram branch
  });

  it('itmAmt rate-type branches', () => {
    expect(itmAmt(0, 50, 'P', 3)).toBe(150); // per piece: 3 × 50
    expect(itmAmt(2.05, 73000, '1')).toBe(14965); // per 10 g: 2.05 × 73000 / 10
    expect(itmAmt(2.05, 7300000, 'K')).toBe(14965); // per kg: 2.05 × 7300000 / 1000
  });

  it('totAmt: MRP overrides else lbr+oth+itm; netAmt backs tax out', () => {
    expect(totAmt(0, 100, 50, 14965)).toBe(15115);
    expect(totAmt(20000, 100, 50, 14965)).toBe(20000); // MRP wins
    expect(netAmt(15000, 0)).toBe(15000); // no tax
    expect(netAmt(1100, 10)).toBe(1000); // 1100 / 110 × 100
  });
});

describe('Wh_Sales_Ledr legs against the desktop rows (contract V1-V6)', () => {
  it('V1 Next23 034/4 — an issue-only tag sale posts leg 23 alone, with FINE_RATE 0', () => {
    // Two LR916 tags: 12.300 g and 13.000 g at touch 92 + wastage 5 ⇒ 11.931 + 12.610 = 24.541 fine.
    const lines: RateCutLine[] = [
      { netWt: 12.3, touch: 92, westPct: 5 },
      { netWt: 13, touch: 92, westPct: 5 },
    ];
    const t = rollup(lines, 'G');
    expect(t.computed.map((c) => c.fine)).toEqual([11.931, 12.61]);
    expect(t.totalFine).toBe(24.541);
    expect(shape(ledgerFor({ slFine: t.totalFine }))).toEqual([
      // Desktop: LEDR_KEY 01002023-20240340000423, AC 000209, LD 00003, G '-' 24.541, FINE_RATE 0.
      {
        leg: 23,
        ac: '000209',
        ld: '00003',
        dr: 0,
        cr: 0,
        it: 'G',
        sign: '-',
        fine: 24.541,
        rate: 0,
      },
    ]);
  });

  it('V2 Next23 034/5 — received 24.000, 0.541 cut at 6500, 3517 cash: legs 01, 02, 29, 43, 44', () => {
    const lines = ledgerFor({
      fineRate: 6500,
      drAmt: 3517,
      crFine: 0.541,
      prFine: 24,
      slCashAmt: 3517,
    });
    expect(shape(lines)).toEqual([
      {
        leg: 1,
        ac: '000209',
        ld: '00003',
        dr: 3517,
        cr: 0,
        it: 'G',
        sign: '+',
        fine: 0.541,
        rate: 6500,
      },
      {
        leg: 2,
        ac: '00003',
        ld: '000209',
        dr: 0,
        cr: 3517,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 6500,
      },
      { leg: 29, ac: '000209', ld: '00008', dr: 0, cr: 0, it: 'G', sign: '+', fine: 24, rate: 0 },
      { leg: 43, ac: '000209', ld: '00001', dr: 0, cr: 3517, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 44, ac: '00001', ld: '000209', dr: 3517, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
    ]);
    expect(ledgerBalance(lines)).toMatchObject({ dr: 7034, cr: 7034, balanced: true });
  });

  it('V3 Next23 034/6 — two tags, 20.000 received, 4.960 cut at 6500: legs 01, 02, 23, 29', () => {
    expect(
      shape(ledgerFor({ fineRate: 6500, drAmt: 32240, crFine: 4.96, slFine: 24.96, prFine: 20 })),
    ).toEqual([
      {
        leg: 1,
        ac: '000209',
        ld: '00003',
        dr: 32240,
        cr: 0,
        it: 'G',
        sign: '+',
        fine: 4.96,
        rate: 6500,
      },
      {
        leg: 2,
        ac: '00003',
        ld: '000209',
        dr: 0,
        cr: 32240,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 6500,
      },
      {
        leg: 23,
        ac: '000209',
        ld: '00003',
        dr: 0,
        cr: 0,
        it: 'G',
        sign: '-',
        fine: 24.96,
        rate: 0,
      },
      { leg: 29, ac: '000209', ld: '00008', dr: 0, cr: 0, it: 'G', sign: '+', fine: 20, rate: 0 },
    ]);
  });

  it('V4 Next25 034/1 — other charges on a tag line post legs 17/18 on slot 11', () => {
    expect(shape(ledgerFor({ slOthAmt: 500, slFine: 10.793 }, { party: '000202' }))).toEqual([
      { leg: 17, ac: '000202', ld: '00077', dr: 500, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 18, ac: '00077', ld: '000202', dr: 0, cr: 500, it: 'A', sign: '', fine: 0, rate: 0 },
      {
        leg: 23,
        ac: '000202',
        ld: '00003',
        dr: 0,
        cr: 0,
        it: 'G',
        sign: '-',
        fine: 10.793,
        rate: 0,
      },
    ]);
  });

  it('V5 Next25 034/2 — 5.793 cut at 14000 is 81102; cash 81602 (legs 01, 02, 29, 43, 44)', () => {
    const lines = ledgerFor(
      { fineRate: 14000, drAmt: 81102, crFine: 5.793, prFine: 5, slCashAmt: 81602 },
      { party: '000202' },
    );
    expect(lines.map((l) => l.legType)).toEqual([1, 2, 29, 43, 44]);
    expect(lines.find((l) => l.legType === 1)).toMatchObject({ DR_AMT: 81102, FINE_WT: 5.793 });
    expect(lines.find((l) => l.legType === 43)).toMatchObject({ CR_AMT: 81602 });
  });

  it('V6 Live24 064/00004 — the header-only purchase-side cut is legs 08, 09, 45, 46, 51, 52 = 30780', () => {
    // spec-rate-cut.md §4.1: party 000286 Cr 14965 G '-' 2.050 @7300 on 00008; 00008 Dr 14965;
    // party Dr 15800 / 00001 Cr 15800; party Dr 15 / 00057 Cr 15.
    const lines = ledgerFor(
      { fineRate: 7300, crAmt: 14965, drFine: 2.05, prCashAmt: 15800, prKasarAmt: 15 },
      { party: '000286' },
    );
    expect(shape(lines)).toEqual([
      {
        leg: 8,
        ac: '000286',
        ld: '00008',
        dr: 0,
        cr: 14965,
        it: 'G',
        sign: '-',
        fine: 2.05,
        rate: 7300,
      },
      { leg: 9, ac: '00008', ld: '000286', dr: 14965, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 45, ac: '000286', ld: '00001', dr: 15800, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 46, ac: '00001', ld: '000286', dr: 0, cr: 15800, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 51, ac: '000286', ld: '00057', dr: 15, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 52, ac: '00057', ld: '000286', dr: 0, cr: 15, it: 'A', sign: '', fine: 0, rate: 0 },
    ]);
    expect(ledgerBalance(lines)).toMatchObject({ dr: 30780, cr: 30780, balanced: true });
  });
});

describe('Wh_Sales_Ledr rules not visible on the captured vouchers (contract W4-W6)', () => {
  it('a priced line folds into leg 01 with the handled fine on leg 23', () => {
    const t = rollup([{ netWt: 2.5, touch: 82, rate: 7300, rateType: 'G' }], 'G');
    expect(t.totalItmAmt).toBe(14965);
    const lines = ledgerFor({ fineRate: t.rate, slItmAmt: t.totalItmAmt, slFine: t.totalFine });
    expect(shape(lines)).toEqual([
      {
        leg: 1,
        ac: '000209',
        ld: '00003',
        dr: 14965,
        cr: 0,
        it: 'G',
        sign: '+',
        fine: 0,
        rate: 7300,
      },
      {
        leg: 2,
        ac: '00003',
        ld: '000209',
        dr: 0,
        cr: 14965,
        it: 'A',
        sign: '',
        fine: 0,
        rate: 7300,
      },
      { leg: 23, ac: '000209', ld: '00003', dr: 0, cr: 0, it: 'G', sign: '-', fine: 2.05, rate: 0 },
    ]);
  });

  it('W4 a silver voucher uses the silver twins on slots 8/9', () => {
    const lines = ledgerFor({
      itType: 'S',
      fineRate: 80,
      slItmAmt: 80000,
      slFine: 1000,
      prFine: 200,
      slCashAmt: 80000,
    });
    expect(lines.map((l) => [l.legType, l.AC_CODE, l.LD_CODE])).toEqual([
      [4, '000209', '00004'],
      [5, '00004', '000209'],
      [25, '000209', '00004'],
      [31, '000209', '00009'],
      [43, '000209', '00001'],
      [44, '00001', '000209'],
    ]);
    expect(lines.filter((l) => l.IT_TYPE === 'S').map((l) => l.legType)).toEqual([4, 25, 31]);
  });

  it('W5 TRAD_FINE adds the mirrored fine legs and leaves the money unchanged', () => {
    const figures = { fineRate: 6500, drAmt: 32240, crFine: 4.96, slFine: 24.96, prFine: 20 };
    const plain = ledgerFor(figures);
    const traded = ledgerFor(figures, { tradeFine: true });
    expect(traded.map((l) => l.legType)).toEqual([1, 2, 3, 23, 24, 29, 30]);
    expect(shape(traded).filter((l) => [3, 24, 30].includes(l.leg))).toEqual([
      { leg: 3, ac: '00008', ld: '000209', dr: 0, cr: 0, it: 'G', sign: '-', fine: 4.96, rate: 0 },
      {
        leg: 24,
        ac: '00003',
        ld: '000209',
        dr: 0,
        cr: 0,
        it: 'G',
        sign: '+',
        fine: 24.96,
        rate: 0,
      },
      { leg: 30, ac: '00008', ld: '000209', dr: 0, cr: 0, it: 'G', sign: '-', fine: 20, rate: 0 },
    ]);
    expect(ledgerBalance(traded)).toEqual(ledgerBalance(plain));
  });

  it('W6 kasar follows its sign: received +15 is 47/48, −15 is 49/50, payment 5 is 51/52', () => {
    expect(shape(ledgerFor({ slKasarAmt: 15 }))).toEqual([
      { leg: 47, ac: '000209', ld: '00057', dr: 0, cr: 15, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 48, ac: '00057', ld: '000209', dr: 15, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
    ]);
    expect(shape(ledgerFor({ slKasarAmt: -15 }))).toEqual([
      { leg: 49, ac: '000209', ld: '00057', dr: 15, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 50, ac: '00057', ld: '000209', dr: 0, cr: 15, it: 'A', sign: '', fine: 0, rate: 0 },
    ]);
    expect(shape(ledgerFor({ prKasarAmt: 5 }))).toEqual([
      { leg: 51, ac: '000209', ld: '00057', dr: 5, cr: 0, it: 'A', sign: '', fine: 0, rate: 0 },
      { leg: 52, ac: '00057', ld: '000209', dr: 0, cr: 5, it: 'A', sign: '', fine: 0, rate: 0 },
    ]);
  });

  it('labour, other charges and every tender post their own pair and stay balanced', () => {
    const lines = ledgerFor({
      slLbrAmt: 200,
      slOthAmt: 50,
      prLbrAmt: 30,
      prOthAmt: 20,
      slChqAmt: 4000,
      prChqAmt: 300,
      slCardAmt: 1000,
      prCardAmt: 100,
      slCashAmt: 5000,
      prCashAmt: 700,
    });
    expect(lines.map((l) => l.legType)).toEqual([
      15, 16, 17, 18, 19, 20, 21, 22, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46,
    ]);
    // Purchase labour lands on LABOUR EXP (slot 7), not LABOUR INCOME.
    expect(lines.find((l) => l.legType === 20)).toMatchObject({ AC_CODE: '00056', DR_AMT: 30 });
    expect(ledgerBalance(lines).balanced).toBe(true);
  });

  it('refuses a leg whose slot is not configured, instead of dropping it unbalanced', () => {
    const { lbrExpAc: _dropped, ...withoutSlot7 } = accounts;
    expect(() => ledgerFor({ prLbrAmt: 30 }, { accounts: withoutSlot7 })).toThrow(
      /SR_NO 7 \(lbrExpAc\)/,
    );
    // ...but a voucher that never uses slot 7 still posts without it.
    expect(ledgerFor({ slFine: 1 }, { accounts: withoutSlot7 })).toHaveLength(1);
  });
});

describe('header totals are derived, as BILL_TOTAL derives them', () => {
  it('SL_NET_AMT includes the cut money; bill outstanding is net less settlement; fine totals add both', () => {
    const totals = rateCutHeaderTotals(
      { ...zero, drAmt: 3517, crFine: 0.541, prFine: 24, slCashAmt: 3517 },
      0,
      0,
    );
    expect(totals).toEqual({
      slNetAmt: 3517,
      prNetAmt: 0,
      slBillOs: 0,
      prBillOs: 0,
      totFineDr: 0,
      totFineCr: 24.541,
    });
  });

  it('Live24 064/00004: PR_BILL_OS = 14965 − 15800 − 15 = −850, the stored value', () => {
    const totals = rateCutHeaderTotals(
      { ...zero, crAmt: 14965, drFine: 2.05, prCashAmt: 15800, prKasarAmt: 15 },
      0,
      0,
    );
    expect(totals).toMatchObject({ prNetAmt: 14965, prBillOs: -850, totFineDr: 2.05 });
  });
});

describe('a voucher priced at the HEADER is not valued at zero', () => {
  /**
   * `rollup` takes `FINE_RATE` from the first line, documented as "single-rate is the common case". It is not the
   * only case: real voucher `wsale-034-00015` carries no `ITM_RATE` and no `ITM_AMT` on any of its six lines and
   * fixes the price at the header — `CR_FINE 11.06 × FINE_RATE 8900 = 98,434`, its `SL_NET_AMT`.
   *
   * Before the voucher-level rate existed, that voucher valued at zero: ₹98,434 of real trade posting as nothing.
   */
  const headerPricedLines = [
    { lineNo: 1, itCode: 'BK916', pcs: 0, grossWt: 6.36, netWt: 6.36, touch: 92 },
    { lineNo: 2, itCode: 'BK916', pcs: 0, grossWt: 55, netWt: 55 },
  ];

  it('takes FINE_RATE from the voucher when no line carries one', () => {
    expect(rollup(headerPricedLines, 'G').rate).toBe(0);
    expect(rollup(headerPricedLines, 'G', 8900).rate).toBe(8900);
  });

  it('leaves a line rate untouched, so a normal voucher cannot change', () => {
    const priced = [{ ...headerPricedLines[0]!, rate: 7000 }];
    expect(rollup(priced, 'G', 8900).rate).toBe(7000);
  });
});
