import { describe, it, expect } from 'vitest';
import {
  buildPurchaseFineLedger,
  buildPurchaseLedger,
  buildExpenseLegs,
  computeLine,
  lineFine,
} from '../src/modules/purchase/purchase.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';
import { purchaseExpenseSplit } from '../src/modules/shared/settingsBehavior.js';

const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'PUR', VCH_NO: '1' };

describe('purchase builders', () => {
  it('lineFine uses the standard purchase-item policy', () => {
    expect(lineFine({ itCode: 'I1', netWt: 10, touch: 91.6 })).toBe(9.16);
    expect(lineFine({ itCode: 'I1', fineWt: 5 })).toBe(5); // explicit wins
  });
  it('lineFine folds in ghat weight + wastage% (desktop (net+ght)×(touch+west)/100)', () => {
    expect(lineFine({ itCode: 'I1', netWt: 10, ghtWt: 2, touch: 90, westPct: 2 })).toBe(11.04); // (10+2)×(90+2)/100
    expect(lineFine({ itCode: 'I1', netWt: 10, touch: 91.6, westPct: 0, ghtWt: 0 })).toBe(9.16); // back-compat
  });
  it('lineFine selects the old-gold/Kun policy when its optional inputs are present', () => {
    expect(
      lineFine({
        itCode: 'OLD',
        netWt: 10,
        ghtWt: 2,
        touch: 90,
        westPct: 2,
        lesTouch: 5,
        kunFine: 0.4,
      }),
    ).toBe(10.84);
  });
  it('computeLine: metal = fine × rate, net = metal + labour', () => {
    const c = computeLine({
      itCode: 'I1',
      netWt: 10,
      touch: 100,
      rate: 100,
      labourType: 'fixed',
      labourFixed: 50,
    });
    expect(c.fine).toBe(10);
    expect(c.metal).toBe(1000);
    expect(c.net).toBe(1050);
  });
  it('buildPurchaseLedger balances (Cr supplier = Dr purchase + Dr tax)', () => {
    const lines = buildPurchaseLedger({
      key,
      acCode: 'SUPP',
      purchaseAc: 'PURCHASE',
      taxAc: 'GST-INPUT',
      roundAc: 'ROF',
      controlAc: 'CTRL',
      totals: { total: 1030, taxable: 1000, tax: 30, roundOff: 0 },
    });
    const b = ledgerBalance(lines);
    expect(b.balanced).toBe(true);
    expect(b.cr).toBe(1030); // supplier credited the full total
    expect(lines.length).toBe(3);
    expect(lines).toEqual(
      expect.arrayContaining([
        expect.objectContaining({ AC_CODE: 'SUPP', LD_CODE: 'CTRL', CR_AMT: 1030 }),
        expect.objectContaining({ AC_CODE: 'PURCHASE', LD_CODE: 'SUPP', DR_AMT: 1000 }),
        expect.objectContaining({ AC_CODE: 'GST-INPUT', LD_CODE: 'SUPP', DR_AMT: 30 }),
      ]),
    );
  });
});

describe('per-group expense allocation (GROUP_MAST.PURC_AC)', () => {
  const sum = (legs: { amount: number }[]) =>
    Math.round(legs.reduce((s, l) => s + l.amount, 0) * 100) / 100;
  it('single account → one leg = taxable', () => {
    expect(buildExpenseLegs([{ net: 800, ac: 'PURCHASE' }], 800, 800)).toEqual([
      { ac: 'PURCHASE', amount: 800 },
    ]);
  });
  it('multi-group splits proportional, Σ == taxable exactly', () => {
    const legs = buildExpenseLegs(
      [
        { net: 700, ac: 'GOLD_PURC' },
        { net: 300, ac: 'SILVER_PURC' },
      ],
      1000,
      1000,
    );
    expect(legs.length).toBe(2);
    expect(sum(legs)).toBe(1000);
  });
});

describe('desktop purchase fine sub-ledger policy', () => {
  it('posts only zero-money fixed-rate lines with workflow-specific gold/silver weights', () => {
    const lines = buildPurchaseFineLedger({
      key,
      acCode: 'SUPP',
      purchaseAc: 'PURCHASE',
      purcAcByItem: { GOLD: 'GOLD_PURC' },
      lines: [
        { itCode: 'GOLD', metal: 'G', fine: 10.111, otherFineWt: 0.222, metalAmount: 0 },
        { itCode: 'SILV', metal: 'S', fine: 20, silverFineWt: 5.555, metalAmount: 0 },
        { itCode: 'PAID', metal: 'G', fine: 99, metalAmount: 100 },
      ],
    });
    expect(lines).toHaveLength(2);
    expect(lines).toEqual(
      expect.arrayContaining([
        expect.objectContaining({ IT_TYPE: 'G', LD_CODE: 'GOLD_PURC', FINE_WT: 10.333 }),
        expect.objectContaining({ IT_TYPE: 'S', LD_CODE: '00009', FINE_WT: 5.555 }),
      ]),
    );
    expect(lines.every((line) => line.SIGN === '+' && line.DR_AMT === 0 && line.CR_AMT === 0)).toBe(
      true,
    );
    expect(
      buildPurchaseFineLedger({
        key,
        acCode: 'SUPP',
        purchaseAc: 'PURCHASE',
        rateUnfix: true,
        lines: [{ itCode: 'GOLD', metal: 'G', fine: 10, metalAmount: 0 }],
      }),
    ).toEqual([]);
  });
});

it.each([
  ['F', 900],
  ['G', 1200],
  ['N', 1100],
  ['P', 900],
] as const)('computeLine applies PR_AMT_TYPE=%s to metal amount', (type, expected) => {
  const c = computeLine(
    { itCode: 'I1', grossWt: 12, netWt: 10, ghtWt: 1, fineWt: 9, rate: 100 },
    undefined,
    type,
  );
  expect(c.metal).toBe(expected);
});

it('PURC_WITH_LBR allocates labour and other either with purchase or separately', () => {
  expect(purchaseExpenseSplit(120, 15, 5, true)).toEqual({ primary: 120, labourOther: 0 });
  expect(purchaseExpenseSplit(120, 15, 5, false)).toEqual({ primary: 100, labourOther: 20 });
});

describe('purchase fine legs are per LINE, not per metal/account', () => {
  // Measured on book 035: 42 real type-21 legs, and voucher 00004 alone has THREE - lines 1, 2 and 3 carrying
  // 12.712, 11.950 and 3.950, all gold and all against purchase account 00008. Aggregating by metal+account
  // collapsed them into a single leg of 28.612.
  //
  // The keys are 33 characters with `<line><leg>` right-aligned in 12 - the cash books' shape - while the SAME
  // BOOK's money legs are 23 with the leg type at 22-23. One table, two layouts, chosen by leg type:
  //
  //     [01002024-202503500004         121]  fine 12.712
  //     [01002024-202503500004         221]  fine 11.950
  //     [01002024-202503500004         321]  fine  3.950
  const key = {
    CO_CODE: '01',
    LC_CODE: '00',
    CO_YEAR: '2024-2025',
    CO_BOOK: '035',
    VCH_NO: '00004',
  };
  const line = (fine: number) => ({
    itCode: 'GOLD',
    metal: 'G' as const,
    fine,
    metalAmount: 0,
  });

  it('writes one leg per line, each with its own fine weight and line number', () => {
    const legs = buildPurchaseFineLedger({
      key,
      acCode: '000258',
      purchaseAc: '00008',
      lines: [line(12.712), line(11.95), line(3.95)],
    } as never);
    // THREE legs, not one aggregate of 28.612.
    expect(legs).toHaveLength(3);
    expect(legs.map((l) => Number((l as never as { FINE_WT: number }).FINE_WT))).toEqual([
      12.712, 11.95, 3.95,
    ]);
    // Each carries its line in the key tail, leg type 21.
    expect(legs.map((l) => (l as never as { legKeySuffix: string }).legKeySuffix.trim())).toEqual([
      '121',
      '221',
      '321',
    ]);
  });

  it('carries no money — a fine leg is weight only', () => {
    const legs = buildPurchaseFineLedger({
      key,
      acCode: '000258',
      purchaseAc: '00008',
      lines: [line(7.917)],
    } as never);
    const l = legs[0] as never as { DR_AMT: number; CR_AMT: number; IT_TYPE: string; SIGN: string };
    expect(Number(l.DR_AMT)).toBe(0);
    expect(Number(l.CR_AMT)).toBe(0);
    // All 42 real legs are IT_TYPE 'G' with SIGN '+' — metal coming IN on a purchase.
    expect(l.IT_TYPE).toBe('G');
    expect(l.SIGN).toBe('+');
  });
});
