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
  type RateCutLine,
} from '../src/modules/sales/rateCut.js';
import { ledgerBalance } from '../src/modules/posting/posting.js';

const key = { CO_CODE: '01', LC_CODE: '01', CO_YEAR: '2024', CO_BOOK: 'RCT', VCH_NO: '4' };

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

describe('rate-cut ledger (spec §3.4 canonical split-leg; §4.1 worked voucher)', () => {
  // The §4.1 voucher: 2.050 fine @ 7300 ⇒ value 14965, cash 15800, kasar 15.
  const lines: RateCutLine[] = [{ netWt: 2.5, touch: 82, westPct: 0, rate: 7300, rateType: 'G' }];
  const totals = rollup(lines, 'G');

  it('rollup reproduces the golden value + fine', () => {
    expect(totals.totalFine).toBe(2.05);
    expect(totals.totalItmAmt).toBe(14965);
    expect(totals.rate).toBe(7300);
  });

  it('Σ DR === Σ CR (balanced) and equals 30780 for the worked voucher', () => {
    const ledger = buildRateCutLedger(key, {
      customer: '000286',
      itType: 'G',
      totals,
      pay: { cash: 15800, chq: 0, card: 0, kasar: 15, bankAc: 'CASH', cardAc: 'CASH' },
      accounts: {
        goldAc: 'SALESGOLD',
        purchaseAc: 'PURCGOLD',
        cashAc: 'CASH',
        kasarAc: 'KASAR',
        lbrAc: 'LABOUR',
        othAc: 'OTHER',
      },
      vchDate: new Date('2024-04-01'),
      vchType: 'RCUT',
      bookName: 'RATE CUT',
    });
    const b = ledgerBalance(ledger);
    expect(b.balanced).toBe(true);
    expect(b.dr).toBe(30780); // 14965 (value) + 15800 (cash) + 15 (kasar)
    expect(b.cr).toBe(30780);
  });

  it('emits the karigar-style metal-only leg (IT_TYPE G, SIGN −, FINE_WT, money 0)', () => {
    const ledger = buildRateCutLedger(key, {
      customer: '000286',
      itType: 'G',
      totals,
      pay: { cash: 15800, chq: 0, card: 0, kasar: 15, bankAc: 'CASH', cardAc: 'CASH' },
      accounts: {
        goldAc: 'SALESGOLD',
        purchaseAc: 'PURCGOLD',
        cashAc: 'CASH',
        kasarAc: 'KASAR',
        lbrAc: 'LABOUR',
        othAc: 'OTHER',
      },
      vchDate: new Date('2024-04-01'),
      vchType: 'RCUT',
      bookName: 'RATE CUT',
    });
    const metal = ledger.find((l) => l.IT_TYPE === 'G');
    expect(metal).toBeTruthy();
    expect(metal!.SIGN).toBe('-');
    expect(metal!.FINE_WT).toBe(2.05);
    expect(metal!.FINE_RATE).toBe(7300);
    expect(metal!.DR_AMT).toBe(0);
    expect(metal!.CR_AMT).toBe(0);
    // 6 money legs (value pair + cash pair + kasar pair) + 1 metal leg = 7
    expect(ledger).toHaveLength(7);
  });

  it('emits balanced receive-side value and metal legs from RATE_CUT_REC totals', () => {
    const receivedTotals = rollup(
      [{ netWt: 4, touch: 91, westPct: 0, rate: 7100, rateType: 'G' }],
      'G',
    );
    const ledger = buildRateCutLedger(key, {
      customer: '000286',
      itType: 'G',
      totals: rollup([], 'G'),
      receivedTotals,
      pay: { cash: 0, chq: 0, card: 0, kasar: 0, bankAc: 'CASH', cardAc: 'CASH' },
      accounts: {
        goldAc: 'SALESGOLD',
        purchaseAc: 'PURCGOLD',
        cashAc: 'CASH',
        kasarAc: 'KASAR',
        lbrAc: 'LABOUR',
        othAc: 'OTHER',
      },
      vchDate: new Date('2024-04-01'),
      vchType: 'RCUT',
      bookName: 'RATE CUT',
    });
    expect(ledgerBalance(ledger).balanced).toBe(true);
    expect(ledger).toHaveLength(3);
    expect(ledger).toEqual(
      expect.arrayContaining([
        expect.objectContaining({ AC_CODE: 'PURCGOLD', LD_CODE: '000286', DR_AMT: 25844 }),
        expect.objectContaining({ AC_CODE: '000286', LD_CODE: 'PURCGOLD', CR_AMT: 25844 }),
        expect.objectContaining({
          AC_CODE: '000286',
          LD_CODE: 'PURCGOLD',
          IT_TYPE: 'G',
          SIGN: '+',
          FINE_WT: 3.64,
          FINE_RATE: 7100,
        }),
      ]),
    );
  });

  it('stays balanced with cheque/card/labour/other settlement too', () => {
    const t2 = rollup(
      [{ netWt: 2.5, touch: 82, rate: 7300, rateType: 'G', lbrAmt: 200, othAmt: 50 }],
      'G',
    );
    const ledger = buildRateCutLedger(key, {
      customer: '000286',
      itType: 'G',
      totals: t2,
      pay: { cash: 5000, chq: 4000, card: 1000, kasar: 15, bankAc: 'HDFC', cardAc: 'CARDPOOL' },
      accounts: {
        goldAc: 'SALESGOLD',
        purchaseAc: 'PURCGOLD',
        cashAc: 'CASH',
        kasarAc: 'KASAR',
        lbrAc: 'LABOUR',
        othAc: 'OTHER',
      },
      vchDate: new Date('2024-04-01'),
      vchType: 'RCUT',
      bookName: 'RATE CUT',
    });
    expect(ledgerBalance(ledger).balanced).toBe(true);
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
