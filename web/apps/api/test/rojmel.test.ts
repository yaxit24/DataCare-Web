import { describe, it, expect } from 'vitest';
import {
  ROJMEL_ROW_TYPE,
  buildFineJvRojmel,
  buildSchemeAdjRojmel,
  buildOrderRojmel,
  buildRateCutRojmel,
  buildCashRojmel,
  buildSaleRojmel,
  rojmelLedrKey,
  rojmelMetalFor,
  type RojmelContext,
} from '../src/modules/shared/rojmel.js';

/**
 * Golden vectors taken from a REAL desktop sale: Live24, book 027 voucher 00001.
 *
 * Party 000888, TOT_AMT 1560.00, TAX_AMT 45.45, NET_AMT 1515.00, two lines
 * (1 pc 10.360 g net 1087.00; 1 pc 4.600 g net 428.00). Sales account 00004, tax account 00085.
 * The desktop wrote exactly four Rojmel rows, reproduced in the first test below.
 */
const ctx: RojmelContext = {
  scope: { coCode: '01', lcCode: '00', coYear: '2024-2025' },
  // Spread onto every row; omitting it would write orphan rows no report could find.
  key: {
    CO_CODE: '01',
    LC_CODE: '00',
    CO_YEAR: '2024-2025',
    CO_BOOK: '027',
    VCH_NO: '00001',
  },
  coBook: '027',
  vchNo: '00001',
  vchDate: '2024-04-01',
  vchType: 'TSSL',
  bookName: 'SALES',
  partyName: 'A PARTY',
  partyCode: '000888',
};

const lines = [
  { lineNo: 1, revenueAc: '00004', amount: 1087, metal: 'S' as const, pcs: 1, grossWt: 10.36 },
  { lineNo: 2, revenueAc: '00004', amount: 428, metal: 'S' as const, pcs: 1, grossWt: 4.6 },
];

describe('LEDR_KEY layout (decoded from real keys)', () => {
  it('reproduces the real item key exactly, line number right-aligned in 10', () => {
    // Real: '01002024-20250270000101         1'
    expect(rojmelLedrKey(ctx.scope, '027', '00001', ROJMEL_ROW_TYPE.ITEM, 1)).toBe(
      '01002024-20250270000101         1',
    );
    expect(rojmelLedrKey(ctx.scope, '027', '00001', ROJMEL_ROW_TYPE.ITEM, 2)).toBe(
      '01002024-20250270000101         2',
    );
  });

  it('reproduces the real party and tax keys, which carry no line suffix', () => {
    expect(rojmelLedrKey(ctx.scope, '027', '00001', ROJMEL_ROW_TYPE.PARTY)).toBe(
      '01002024-20250270000102',
    );
    expect(rojmelLedrKey(ctx.scope, '027', '00001', ROJMEL_ROW_TYPE.TAX)).toBe(
      '01002024-20250270000104',
    );
  });

  it('fits the varchar(50) column (longest real key is 43)', () => {
    expect(
      rojmelLedrKey(ctx.scope, '027', '00001', ROJMEL_ROW_TYPE.ITEM, 999).length,
    ).toBeLessThanOrEqual(50);
  });
});

describe('IT_TYPE is the metal', () => {
  it('maps gold and silver from the item type', () => {
    expect(rojmelMetalFor('G')).toBe('G');
    expect(rojmelMetalFor('S')).toBe('S');
    expect(rojmelMetalFor('g')).toBe('G');
  });

  it('files an unknown code as other metal rather than guessing gold', () => {
    // Misfiling silver as gold would corrupt the metal totals a jeweller reconciles against, so the
    // conservative answer is 'O'.
    expect(rojmelMetalFor('X')).toBe('O');
    expect(rojmelMetalFor('')).toBe('O');
    expect(rojmelMetalFor(null)).toBe('O');
  });
});

describe('ITM_AMT is the metal amount, never the line total', () => {
  // Verified against the real database on book 027: ROJ_MEL_DATA.ITM_AMT mirrors SL_DETL.ITM_AMT exactly -
  // 354.00 where the line NET is 428.00 - and it is 0.00 on a labour-only line whose whole value is making
  // charges. Across all 3179 real Rojmel rows, ITM_AMT is non-zero on 285 and LBR_AMT on 246, so they are
  // separately populated components rather than either one carrying the total.
  //
  // The sale call site read LBR_AMT and NET_AMT from the persisted detail row but omitted ITM_AMT, so the
  // builder's `l.itemAmount ?? l.amount` fell back to the line net. A labour-only line reported 1087.00 metal
  // where the desktop has 0.00.
  //
  // Nothing caught it: the whole suite passed, and the real comparison could not see it either, because
  // ROJ_MEL_DATA had no ROW_KEYS entry and so reported 4 rows missing, 5 extra and ZERO differences.
  const split = [
    // A labour-only line: no metal value at all.
    {
      lineNo: 1,
      revenueAc: '00004',
      amount: 1087,
      itemAmount: 0,
      labourAmount: 1087,
      metal: 'S' as const,
      pcs: 1,
      grossWt: 10.36,
    },
    // Metal plus labour: 354 + 74 = 428.
    {
      lineNo: 2,
      revenueAc: '00004',
      amount: 428,
      itemAmount: 354,
      labourAmount: 74,
      metal: 'S' as const,
      pcs: 1,
      grossWt: 4.6,
    },
  ];

  it('keeps the metal amount and the labour amount separate', () => {
    const rows = buildSaleRojmel(ctx, split, { partyAmount: 1515 });
    const items = rows.filter((r) => (r.IT_CODE ?? '') !== '' || Number(r.ITM_GWT ?? 0) !== 0);
    expect(items).toHaveLength(2);
    // Line 1: zero metal, all labour. The line total 1087 must NOT appear in ITM_AMT.
    expect(Number(items[0]!.ITM_AMT)).toBe(0);
    expect(Number(items[0]!.LBR_AMT)).toBe(1087);
    // Line 2: the components, not the 428 total.
    expect(Number(items[1]!.ITM_AMT)).toBe(354);
    expect(Number(items[1]!.LBR_AMT)).toBe(74);
    expect(Number(items[1]!.ITM_AMT)).not.toBe(428);
  });
});

describe('a sale projects to the desktop’s four Rojmel rows', () => {
  const rows = buildSaleRojmel(ctx, lines, {
    taxAc: '00085',
    taxAmount: 45.45,
    partyAmount: 1560,
  });

  it('produces exactly the rows the desktop wrote', () => {
    expect(
      rows.map((r) => [
        r.AC_CODE,
        r.LD_CODE,
        r.DR_AMT,
        r.CR_AMT,
        r.IT_TYPE,
        r.SIGN,
        r.ITM_PCS,
        r.ITM_GWT,
      ]),
    ).toEqual([
      ['00004', '000888', 0, 1087, 'S', '-', 1, 10.36],
      ['00004', '000888', 0, 428, 'S', '-', 1, 4.6],
      ['000888', '00004', 1560, 0, 'A', '', 0, 0],
      ['00085', '000888', 0, 45.45, 'A', '', 0, 0],
    ]);
  });

  it('splits the revenue leg per line, summing to the net amount', () => {
    const metal = rows.filter((r) => r.IT_TYPE !== 'A');
    expect(metal).toHaveLength(2);
    expect(metal.reduce((t, r) => t + r.CR_AMT, 0)).toBeCloseTo(1515, 2); // = SL_DATA.NET_AMT
  });

  it('spreads the voucher key onto every row', () => {
    // postVoucherTx does not add the key; a row without it is an orphan with NULL CO_BOOK/VCH_NO.
    for (const r of rows) {
      expect(r.CO_CODE).toBe('01');
      expect(r.CO_BOOK).toBe('027');
      expect(r.VCH_NO).toBe('00001');
    }
  });

  it('denormalises the party name onto every row, including the tax row', () => {
    expect(rows.every((r) => r.AC_NAME === 'A PARTY')).toBe(true);
  });

  it('carries weight on metal rows and none on money rows', () => {
    expect(rows.filter((r) => r.IT_TYPE !== 'A').every((r) => r.ITM_GWT > 0)).toBe(true);
    expect(rows.filter((r) => r.IT_TYPE === 'A').every((r) => r.ITM_GWT === 0)).toBe(true);
  });

  it('omits the tax row entirely when the sale is not taxed', () => {
    const untaxed = buildSaleRojmel(ctx, lines, { partyAmount: 1515 });
    expect(untaxed).toHaveLength(3);
    expect(untaxed.some((r) => r.AC_CODE === '00085')).toBe(false);
  });

  it('reverses direction for an inward voucher (a purchase brings metal IN)', () => {
    const purchase = buildSaleRojmel(ctx, lines, { partyAmount: 1515 }, false);
    expect(purchase.filter((r) => r.IT_TYPE !== 'A').every((r) => r.SIGN === '+')).toBe(true);
    /**
     * Selected by ROW TYPE, not by array position.
     *
     * These lines carry no rate, so an inward voucher now also emits the unpriced-metal row (type `14`) measured on
     * all 51 captured purchases — one per line, on the party, carrying fine, with no money. Asserting `purchase[0]`
     * was asserting the emission ORDER, which the day book does not depend on: rows are identified by `LEDR_KEY`.
     */
    const typeOf = (r: { LEDR_KEY: string }) => r.LEDR_KEY.slice(21, 23);
    const money = purchase.find((r) => typeOf(r) === '01')!;
    expect(money.DR_AMT).toBe(1087);
    expect(money.CR_AMT).toBe(0);
    // One metal row per line, and it books weight rather than money.
    const metal = purchase.filter((r) => typeOf(r) === '14');
    expect(metal).toHaveLength(lines.length);
    expect(metal.every((r) => r.DR_AMT === 0 && r.CR_AMT === 0)).toBe(true);
    expect(metal.every((r) => r.AC_CODE === '000888')).toBe(true);
    const party = purchase.find((r) => r.AC_CODE === '000888' && r.IT_TYPE === 'A')!;
    expect(party.CR_AMT).toBe(1515);
    expect(party.DR_AMT).toBe(0);
  });

  it('skips a wholly empty line rather than writing a null day-book event', () => {
    const withBlank = buildSaleRojmel(
      ctx,
      [...lines, { lineNo: 3, revenueAc: '00004', amount: 0, metal: 'S' as const }],
      { partyAmount: 1515 },
    );
    expect(withBlank.filter((r) => r.IT_TYPE !== 'A')).toHaveLength(2);
  });
});

describe('the cash books take the PARTY’s direction, not the cash account’s', () => {
  // This convention was missed on a first pass because the test that settled every other family -
  // "does a row match its own AC_CODE's ledger leg?" - gives 47.2% on book 001 and 5.4% on book 002.
  // Grouped by row type it is 100% in every group: types 01 and 04 mirror the COUNTER-PARTY's leg,
  // types 02/03 and 05/06 mirror their own. The rule was never inconsistent; averaging hid it.
  const cashCtx: RojmelContext = {
    ...ctx,
    coBook: '002',
    partyCode: '000294',
    partyName: 'A PARTY',
  };

  it('a receipt credits the party, so the cash row is a CREDIT (real book 001 type 01)', () => {
    // Real: AC_CODE 00001 (cash) LD_CODE 000926 CR 60000.00, against a ledger that DEBITS cash.
    const rows = buildCashRojmel(
      { ...cashCtx, coBook: '001', partyCode: '000926' },
      { cashAc: '00001', cashAmount: 60000, direction: 'receipt' },
    );
    expect(rows).toHaveLength(1);
    expect(rows[0]!.AC_CODE).toBe('00001'); // names cash
    expect(rows[0]!.LD_CODE).toBe('000926'); // contra is the party
    expect(rows[0]!.CR_AMT).toBe(60000); // but takes the PARTY's credit
    expect(rows[0]!.DR_AMT).toBe(0);
    expect(String(rows[0]!.LEDR_KEY).slice(21, 23)).toBe('01');
  });

  it('a payment debits the party, so the cash row is a DEBIT (real book 002 type 04)', () => {
    // Real: AC_CODE 00001 (cash) LD_CODE 000294 DR 730.00, against a ledger that CREDITS cash.
    const rows = buildCashRojmel(cashCtx, {
      cashAc: '00001',
      cashAmount: 730,
      direction: 'payment',
    });
    expect(rows[0]!.DR_AMT).toBe(730);
    expect(rows[0]!.CR_AMT).toBe(0);
    // The type code is book-specific, not semantic: a payment's cash row is 04, a receipt's is 01.
    expect(String(rows[0]!.LEDR_KEY).slice(21, 23)).toBe('04');
  });

  it('carries no metal: a cash voucher moves money only', () => {
    const rows = buildCashRojmel(cashCtx, {
      cashAc: '00001',
      cashAmount: 730,
      direction: 'payment',
    });
    expect(rows[0]!.IT_TYPE).toBe('A');
    expect(rows[0]!.SIGN).toBe('');
    expect(rows[0]!.ITM_GWT).toBe(0);
  });

  it('gives the KASAR movement its own pair — types 02/03 on a receipt', () => {
    // Measured on book 001: 56 type-01 rows (one per voucher) against 25 each of 02 and 03 - one pair per
    // voucher that carried a write-off. The cash movement is ONE row; the kasar movement is TWO.
    //
    // Real voucher 001/00001 received 60000.00 with a 771.00 write-off and has THREE Rojmel rows. The web
    // wrote one, carrying 60771.00 - the party's total rather than the cash tendered.
    const rows = buildCashRojmel(cashCtx, {
      cashAc: '00001',
      cashAmount: 60000,
      direction: 'receipt',
      kasar: 771,
      kasarAc: '00057',
    });
    expect(rows).toHaveLength(3);
    // Type 01: the cash account, carrying the CASH figure and the party's direction.
    expect(rows[0]!.LEDR_KEY.slice(21, 23)).toBe('01');
    expect(rows[0]!.AC_CODE).toBe('00001');
    expect(Number(rows[0]!.CR_AMT)).toBe(60000);
    // Types 02/03: the party then the kasar account, self-balancing.
    expect(rows[1]!.LEDR_KEY.slice(21, 23)).toBe('02');
    expect(rows[1]!.AC_CODE).toBe(cashCtx.partyCode);
    expect(Number(rows[1]!.CR_AMT)).toBe(771);
    expect(rows[2]!.LEDR_KEY.slice(21, 23)).toBe('03');
    expect(rows[2]!.AC_CODE).toBe('00057');
    expect(Number(rows[2]!.DR_AMT)).toBe(771);
  });

  it('uses DIFFERENT kasar types on a payment — 05/06, not 02/03', () => {
    // Book 002's kasar rows are types 05 and 06. A receipt and a payment share no codes in the Rojmel either.
    const rows = buildCashRojmel(cashCtx, {
      cashAc: '00001',
      cashAmount: 5000,
      direction: 'payment',
      kasar: 160,
      kasarAc: '00042',
    });
    expect(rows.map((r) => r.LEDR_KEY.slice(21, 23))).toEqual(['04', '05', '06']);
    expect(rows[2]!.AC_CODE).toBe('00042');
  });

  it('writes nothing for a zero-amount voucher', () => {
    expect(
      buildCashRojmel(cashCtx, { cashAc: '00001', cashAmount: 0, direction: 'receipt' }),
    ).toEqual([]);
  });
});

describe('the party row is conditional on the bill being outstanding', () => {
  // Ac_Rojmel.Sales_Rojmel writes the party row only for a non-zero BILL_OS, splitting the sign across
  // two row types. Measured on the real database: of 47 sales with BILL_OS = 0, ZERO carry a party row;
  // of 42 with BILL_OS <> 0, all 42 do. Writing one unconditionally overstated the day's debtors.
  it('a fully settled sale writes no party row', () => {
    const rows = buildSaleRojmel(ctx, lines, { partyAmount: 0 });
    expect(rows.filter((r) => r.AC_CODE === ctx.partyCode)).toEqual([]);
    // The item rows are still there — the sale happened, the metal moved, nothing is owed.
    expect(rows.filter((r) => r.IT_TYPE !== 'A')).toHaveLength(2);
  });

  it('an overpaid sale credits the party and states the amount absolutely', () => {
    // BILL_OS < 0 is the customer in credit. The desktop uses ABS(BILL_OS) on a separate row type.
    const rows = buildSaleRojmel(ctx, lines, { partyAmount: -250 });
    const party = rows.find((r) => r.AC_CODE === ctx.partyCode)!;
    expect(party).toBeDefined();
    expect(party.CR_AMT).toBe(250);
    expect(party.DR_AMT).toBe(0);
  });

  it('an outstanding sale debits the party, as before', () => {
    const rows = buildSaleRojmel(ctx, lines, { partyAmount: 1560 });
    const party = rows.find((r) => r.AC_CODE === ctx.partyCode)!;
    expect(party.DR_AMT).toBe(1560);
    expect(party.CR_AMT).toBe(0);
  });
});

describe('item rows carry the detail columns the desktop copies from SL_DETL', () => {
  it('populates IT_CODE, IT_DESC, NET_AMT, LBR_AMT and OTH_AMT', () => {
    // All 245 real sale metal rows carry IT_DESC / IT_CODE / NET_AMT; 237 of 245 carry LBR_AMT.
    const rows = buildSaleRojmel(
      ctx,
      [
        {
          lineNo: 1,
          revenueAc: '00004',
          amount: 1087,
          metal: 'S' as const,
          pcs: 1,
          grossWt: 10.36,
          itemCode: 'MA925',
          itemName: 'SILVER PAYAL',
          labourRate: 12,
          labourAmount: 124.32,
          otherAmount: 5,
          netAmount: 1087,
        },
      ],
      { partyAmount: 1087 },
    );
    const item = rows.find((r) => r.IT_TYPE !== 'A')!;
    expect(item.IT_CODE).toBe('MA925');
    expect(item.IT_DESC).toBe('SILVER PAYAL');
    expect(item.NET_AMT).toBe(1087);
    expect(item.LBR_RATE).toBe(12);
    expect(item.LBR_AMT).toBe(124.32);
    expect(item.OTH_AMT).toBe(5);
  });

  it('leaves them blank rather than guessing when the caller omits them', () => {
    const rows = buildSaleRojmel(ctx, lines, { partyAmount: 1560 });
    const item = rows.find((r) => r.IT_TYPE !== 'A')!;
    expect(item.IT_CODE).toBe('');
    expect(item.IT_DESC).toBe('');
    // NET_AMT falls back to the line amount, which is what the desktop stores for a plain line.
    expect(item.NET_AMT).toBe(1087);
  });
});

describe('settlement rows appear only when their amount is non-zero', () => {
  // Ac_Rojmel.Sales_Rojmel guards every settlement insert with `AND <column> <> 0`. That is why sampling
  // vouchers never revealed these rows exist: a sale settled wholly in cash emits none of them. Each was
  // identified by matching real amounts against SL_DATA across the sale books - cheque 17/17 = CHQ_AMT,
  // kasar 100/100 = KASAR_AMT, advance 23/23 = ADV_AMT.
  it('emits nothing extra for a plain sale', () => {
    const rows = buildSaleRojmel(ctx, lines, {
      partyAmount: 1560,
      settlements: [
        { kind: 'cheque', account: 'BANK', amount: 0 },
        { kind: 'kasar', account: '00057', amount: 0 },
        { kind: 'advance', account: '00020', amount: 0 },
      ],
    });
    // Two item rows plus the party row, and nothing else.
    expect(rows).toHaveLength(3);
  });

  it('emits cheque, kasar and advance rows with their own key types when they apply', () => {
    const rows = buildSaleRojmel(ctx, lines, {
      partyAmount: 1000,
      settlements: [
        { kind: 'cheque', account: 'BANK', amount: 400 },
        { kind: 'kasar', account: '00057', amount: 10 },
        { kind: 'advance', account: '00020', amount: 150 },
      ],
    });
    const byType = new Map(rows.map((r) => [String(r.LEDR_KEY).slice(21, 23), r]));
    expect(byType.get('11')!.AC_CODE).toBe('BANK'); // cheque
    expect(byType.get('11')!.DR_AMT).toBe(400);
    expect(byType.get('13')!.DR_AMT).toBe(10); // kasar
    expect(byType.get('14')!.AC_CODE).toBe('00020'); // advance, the book's slot-4 account
    expect(byType.get('14')!.DR_AMT).toBe(150);
    // All are debits on an outward voucher: money in against the bill reduces what the party owes.
    for (const t of ['11', '13', '14']) expect(byType.get(t)!.CR_AMT).toBe(0);
  });

  it('an old-metal row keeps its weight even though IT_TYPE is a money row', () => {
    // The desktop stores pcs, gross, net, touch and fine on these rows so the day book can show metal
    // taken in exchange WITHOUT counting it as a metal sale - hence IT_TYPE 'A' with weight attached.
    const rows = buildSaleRojmel(ctx, lines, {
      partyAmount: 500,
      settlements: [
        {
          kind: 'oldMetal',
          account: '00010',
          amount: 834,
          lineNo: 1,
          pcs: 1,
          grossWt: 0.15,
          netWt: 0.15,
          touch: 75,
          fine: 0.112,
          description: 'OLD GOLD',
          itemCode: 'OG',
        },
      ],
    });
    const old = rows.find((r) => String(r.LEDR_KEY).slice(21, 23) === '16')!;
    expect(old.IT_TYPE).toBe('A'); // not a metal sale
    expect(old.ITM_GWT).toBe(0.15); // but it carries the weight
    expect(old.ITM_TOUCH).toBe(75);
    expect(old.ITM_FINE).toBe(0.112);
    expect(old.IT_DESC).toBe('OLD GOLD');
    expect(old.DR_AMT).toBe(834);
    // It must NOT land in the metal buckets of the report, which key on IT_TYPE.
    expect(rows.filter((r) => r.IT_TYPE !== 'A')).toHaveLength(2);
  });
});

describe('round-off (SOURCE-DERIVED, unverified against data)', () => {
  // Everything else in this file is checked against real rows. This is not: the company's database has
  // ROF_AMT non-zero on ZERO of 190 sales, and the same holds for CARD_AMT, DISC_AMT and TCS_AMT. The
  // shape comes from Ac_Rojmel.Sales_Rojmel alone, and that file is a LATER version than the code that
  // wrote the data. Amount, account and direction are trustworthy; the type code is a best reading.
  it('names the PARTY with the book account as contra, unlike the other settlements', () => {
    const rows = buildSaleRojmel(ctx, lines, {
      partyAmount: 1560,
      settlements: [{ kind: 'roundOff', account: '00076', amount: 0.4 }],
    });
    const rof = rows.find((r) => String(r.LEDR_KEY).slice(21, 23) === '22')!;
    expect(rof.AC_CODE).toBe(ctx.partyCode); // the party, not the round-off account
    expect(rof.LD_CODE).toBe('00076'); // the book's slot-5 account as contra
  });

  it('splits on its OWN sign, not the voucher direction', () => {
    const up = buildSaleRojmel(ctx, lines, {
      partyAmount: 1560,
      settlements: [{ kind: 'roundOff', account: '00076', amount: 0.4 }],
    }).find((r) => String(r.LEDR_KEY).slice(21, 23) === '22')!;
    expect(up.CR_AMT).toBe(0.4);
    expect(up.DR_AMT).toBe(0);

    const down = buildSaleRojmel(ctx, lines, {
      partyAmount: 1560,
      settlements: [{ kind: 'roundOff', account: '00076', amount: -0.35 }],
    }).find((r) => String(r.LEDR_KEY).slice(21, 23) === '22')!;
    // The desktop puts the NEGATIVE value straight into DR_AMT rather than its absolute value. Preserved
    // rather than tidied: a report summing DR_AMT depends on it.
    expect(down.DR_AMT).toBe(-0.35);
    expect(down.CR_AMT).toBe(0);
  });

  it('is omitted when the bill rounds to nothing', () => {
    const rows = buildSaleRojmel(ctx, lines, {
      partyAmount: 1560,
      settlements: [{ kind: 'roundOff', account: '00076', amount: 0 }],
    });
    expect(rows.some((r) => String(r.LEDR_KEY).slice(21, 23) === '22')).toBe(false);
  });
});

describe('rate cut / wholesale (book 064) — 9 live types of 40', () => {
  // Every direction below is taken from the REAL desktop rows of book 064, not from Ac_Rojmel.cs. That
  // file is a later version and has the debit/credit assignment reversed on five of these nine types, so
  // a plan draft written from the source alone had 02, 04, 22 and 26 backwards and wrongly claimed the
  // fine rows were money-free. Sampled real rows, one per type:
  //   t01 ac=party ld=00008 G '-' dr 0      cr 0/cond fine 36.200 rate 7578
  //   t02 ac=00008 ld=party A     dr 274324 cr 0      fine 0
  //   t03 ac=party ld=00003 G '+' dr 8000   cr 0      fine  1.169 rate 6844
  //   t04 ac=00003 ld=party A     dr 0      cr 8000   fine 0
  //   t07 ac=party ld=00098 G '-' dr 0      cr 0      fine  0.110 rate 0
  //   t08 ac=party ld=00098 G '+' dr 0      cr 0      fine  0.031 rate 0
  //   t13 ac=party ld=00008 G '-' dr 850    cr 0      fine  2.050 rate 7300
  //   t22 ac=bank  ld=party A     dr 0      cr 274324 fine 0
  //   t26 ac=00042 ld=party A     dr 0      cr 15     fine 0
  const rcCtx: RojmelContext = { ...ctx, coBook: '064', partyCode: '000939' };
  const SLOTS = {
    purchaseAc: '00008', // slot 2 on book 064 — NOT 00001, which is what slot 2 is on book 026
    saleAc: '00003', // slot 1
    kasarFineAc: '00098', // slot 12
    purchaseKasarAc: '00042', // slot 5
    bankAc: '000755',
  };
  const legs = (over: Record<string, unknown> = {}) => ({
    ...SLOTS,
    metal: 'G' as const,
    fineRate: 7578,
    drFine: 0,
    crFine: 0,
    purchaseBillOs: 0,
    saleBillOs: 0,
    purchaseAmount: 0,
    saleAmount: 0,
    kasarFineDr: 0,
    kasarFineCr: 0,
    purchaseChequeAmount: 0,
    purchaseKasarAmount: 0,
    ...over,
  });
  const typeOf = (r: { LEDR_KEY: unknown }) => String(r.LEDR_KEY).slice(21, 23);

  it('writes nothing when every amount is zero', () => {
    expect(buildRateCutRojmel(rcCtx, legs())).toEqual([]);
  });

  it('no rate-cut type carries a line number — all 66 real keys are 23 characters', () => {
    const rows = buildRateCutRojmel(
      rcCtx,
      legs({ drFine: 36.2, purchaseAmount: 274324, purchaseChequeAmount: 274324 }),
    );
    expect(rows.length).toBe(3);
    expect(rows.every((r) => String(r.LEDR_KEY).length === 23)).toBe(true);
  });

  it('purchase side: type 01 fine names the PARTY, type 02 amount names the SLOT — the accounts flip', () => {
    const rows = buildRateCutRojmel(rcCtx, legs({ drFine: 36.2, purchaseAmount: 274324 }));
    const fine = rows.find((r) => typeOf(r) === '01')!;
    const amount = rows.find((r) => typeOf(r) === '02')!;
    expect(fine.AC_CODE).toBe('000939'); // party
    expect(fine.LD_CODE).toBe('00008'); // slot 2
    expect(amount.AC_CODE).toBe('00008'); // reversed
    expect(amount.LD_CODE).toBe('000939');
    // Getting this backwards would misfile every row in the day book.
    expect(fine.AC_CODE).toBe(amount.LD_CODE);
    expect(fine.LD_CODE).toBe(amount.AC_CODE);
  });

  it('type 02 is a DEBIT and type 04 a CREDIT — the source has both reversed', () => {
    const purchase = buildRateCutRojmel(rcCtx, legs({ purchaseAmount: 274324 }));
    expect(purchase[0]!.DR_AMT).toBe(274324);
    expect(purchase[0]!.CR_AMT).toBe(0);
    const sale = buildRateCutRojmel(rcCtx, legs({ saleAmount: 8000 }));
    expect(sale[0]!.CR_AMT).toBe(8000);
    expect(sale[0]!.DR_AMT).toBe(0);
  });

  it('only the kasar-fine pair is money-free; types 01, 03 and 13 all carry money', () => {
    const kasar = buildRateCutRojmel(rcCtx, legs({ kasarFineDr: 0.11, kasarFineCr: 0.031 }));
    expect(kasar).toHaveLength(2);
    for (const r of kasar) {
      expect(r.DR_AMT).toBe(0);
      expect(r.CR_AMT).toBe(0);
      expect(r.ITM_RATE).toBe(0); // 0 of 6 real kasar-fine rows carry a rate
      expect(r.ITM_FINE).toBeGreaterThan(0);
    }
    // Type 03 carries a debit on 5 of 5 real rows, and 13 on 2 of 2.
    expect(
      buildRateCutRojmel(rcCtx, legs({ crFine: 1.169, saleBillOs: 8000 })).find(
        (r) => typeOf(r) === '03',
      )!.DR_AMT,
    ).toBe(8000);
    expect(
      buildRateCutRojmel(rcCtx, legs({ drFine: 2.05, purchaseBillOs: -850 })).find(
        (r) => typeOf(r) === '13',
      )!.DR_AMT,
    ).toBe(850);
  });

  it('direction: 01 and 07 send metal out, 03 and 08 bring it in', () => {
    expect(buildRateCutRojmel(rcCtx, legs({ drFine: 1 }))[0]!.SIGN).toBe('-');
    expect(buildRateCutRojmel(rcCtx, legs({ kasarFineDr: 1 }))[0]!.SIGN).toBe('-');
    expect(buildRateCutRojmel(rcCtx, legs({ crFine: 1 }))[0]!.SIGN).toBe('+');
    expect(buildRateCutRojmel(rcCtx, legs({ kasarFineCr: 1 }))[0]!.SIGN).toBe('+');
  });

  it('type 01 credits only when the bill is outstanding in the shop’s favour', () => {
    // 9 of 19 real type-01 rows carry a credit; the rest are fine-only.
    expect(buildRateCutRojmel(rcCtx, legs({ drFine: 5, purchaseBillOs: 1200 }))[0]!.CR_AMT).toBe(
      1200,
    );
    expect(buildRateCutRojmel(rcCtx, legs({ drFine: 5, purchaseBillOs: 0 }))[0]!.CR_AMT).toBe(0);
    // Negative goes to type 13 instead, absolute, on the debit side.
    const overpaid = buildRateCutRojmel(rcCtx, legs({ drFine: 5, purchaseBillOs: -850 }));
    expect(overpaid.find((r) => typeOf(r) === '01')!.CR_AMT).toBe(0);
    expect(overpaid.find((r) => typeOf(r) === '13')!.DR_AMT).toBe(850);
  });

  it('reproduces the desktop’s DOUBLE-COUNTED fine on an overpaid purchase', () => {
    // Verified on both real occurrences: voucher 00004 has PR_BILL_OS -850.00 and DR_FINE 2.050, and
    // 2.050 appears on BOTH the type-01 and type-13 rows; voucher 00020 has -122.00 and 3.814, likewise.
    // This inflates the day book's fine total and is very likely a desktop defect. It is reproduced
    // because parity with the desktop's report output is the requirement - "fixing" it would make the
    // two systems disagree on a figure the shop reconciles against. Do not deduplicate without a
    // decision from the owner.
    const rows = buildRateCutRojmel(rcCtx, legs({ drFine: 2.05, purchaseBillOs: -850 }));
    const fineRows = rows.filter((r) => r.ITM_FINE === 2.05);
    expect(fineRows).toHaveLength(2);
    expect(fineRows.map(typeOf).sort()).toEqual(['01', '13']);
  });

  it('settlement rows: cheque names the bank, kasar names the book slot, both CREDITS', () => {
    const rows = buildRateCutRojmel(
      rcCtx,
      legs({ purchaseChequeAmount: 274324, purchaseKasarAmount: 15 }),
    );
    const chq = rows.find((r) => typeOf(r) === '22')!;
    const ksr = rows.find((r) => typeOf(r) === '26')!;
    expect(chq.AC_CODE).toBe('000755');
    expect(chq.CR_AMT).toBe(274324);
    expect(ksr.AC_CODE).toBe('00042');
    expect(ksr.CR_AMT).toBe(15);
    for (const r of [chq, ksr]) {
      expect(r.DR_AMT).toBe(0);
      expect(r.IT_TYPE).toBe('A');
      expect(r.LD_CODE).toBe('000939');
    }
  });

  it('the metal letter comes from the caller, and no silver family exists to fire', () => {
    // All 40 real RATE_CUT_DATA rows are IT_TYPE 'G' — this shop never rate-cut silver — so the silver
    // row families (types 09-12, 15-20, 33-36) are deliberately not implemented. Passing 'S' produces
    // silver-labelled rows of the SAME nine types rather than a different family, which is the honest
    // behaviour: the shape is unverified for silver and inventing one would be a guess.
    const rows = buildRateCutRojmel({ ...rcCtx }, legs({ metal: 'S' as const, crFine: 1 }));
    expect(rows[0]!.IT_TYPE).toBe('S');
    expect(rows.map(typeOf)).toEqual(['03']);
  });
});

describe('sales order (book 020) — 4 live types of 8', () => {
  // Shapes from the real rows of book 020. Unlike the rate-cut routine, the source and the data AGREE here
  // on all four types - checked one by one, because the version divergence in Ac_Rojmel.cs is real but not
  // uniform across routines. Sampled real rows:
  //   t01 ac=party   ld=00001  A      cr 25000
  //   t02 ac=bank    ld=party  A      dr <cheque>
  //   t04 ac=00010   ld=party  A      dr 9300   gwt  1.690 fine  1.268  'OLD GOLD'
  //   t06 ac=party   ld=00010  G '+'  dr 0 cr 0 gwt 18.310 fine 18.000  'OLD GOLD'
  const ordCtx: RojmelContext = { ...ctx, coBook: '020', partyCode: '000519' };
  const SLOT1 = '00001'; // BOOK_DETL slot 1 on book 020 - verified as every real type-01 row's LD_CODE
  const legs = (over: Record<string, unknown> = {}) => ({
    advanceContraAc: SLOT1,
    bankAc: '000755',
    advanceAmount: 0,
    chequeAmount: 0,
    ...over,
  });
  const typeOf = (r: { LEDR_KEY: unknown }) => String(r.LEDR_KEY).slice(21, 23);
  const metalLine = (over: Record<string, unknown> = {}) => ({
    lineNo: 1,
    purchaseAc: '00010',
    netAmount: 0,
    metal: 'G' as const,
    pcs: 1,
    grossWt: 18.31,
    netWt: 18.31,
    touch: 98.3,
    fine: 18,
    itemCode: 'OG',
    itemName: 'OLD GOLD',
    ...over,
  });

  it('writes nothing when the order carries no money and no metal', () => {
    expect(buildOrderRojmel(ordCtx, legs())).toEqual([]);
  });

  it('the advance is a CREDIT on the party, contra = the book’s slot-1 account', () => {
    const [row] = buildOrderRojmel(ordCtx, legs({ advanceAmount: 25000 }));
    expect(typeOf(row!)).toBe('01');
    expect(row!.AC_CODE).toBe('000519'); // the party
    expect(row!.LD_CODE).toBe(SLOT1);
    expect(row!.CR_AMT).toBe(25000);
    expect(row!.DR_AMT).toBe(0);
    expect(row!.IT_TYPE).toBe('A'); // money row
  });

  it('the cheque row REVERSES the accounts and is a DEBIT', () => {
    const [row] = buildOrderRojmel(ordCtx, legs({ chequeAmount: 4000 }));
    expect(typeOf(row!)).toBe('02');
    expect(row!.AC_CODE).toBe('000755'); // the bank, not the party
    expect(row!.LD_CODE).toBe('000519'); // party moves to LD_CODE
    expect(row!.DR_AMT).toBe(4000);
    expect(row!.CR_AMT).toBe(0);
    // Assert the flip explicitly against the advance row - misreading it misfiles every row.
    const [adv] = buildOrderRojmel(ordCtx, legs({ advanceAmount: 1 }));
    expect(row!.AC_CODE).not.toBe(adv!.AC_CODE);
    expect(row!.LD_CODE).toBe(adv!.AC_CODE);
  });

  it('valued old metal is a money row that STILL carries weight', () => {
    const rows = buildOrderRojmel(ordCtx, {
      ...legs(),
      oldMetal: [metalLine({ netAmount: 9300, grossWt: 1.69, fine: 1.268 })],
    });
    const row = rows.find((r) => typeOf(r) === '04')!;
    // IT_TYPE stays 'A' deliberately: the day book shows metal taken in exchange WITHOUT counting it as a
    // metal sale. The report's buckets key on IT_TYPE, so 'G' here would double-count the shop's gold.
    expect(row.IT_TYPE).toBe('A');
    expect(row.DR_AMT).toBe(9300);
    expect(row.ITM_GWT).toBe(1.69);
    expect(row.ITM_FINE).toBe(1.268);
    expect(row.ITM_TOUCH).toBeGreaterThan(0);
    expect(row.IT_DESC).toBe('OLD GOLD');
    expect(row.AC_CODE).toBe('00010'); // purchase account
    expect(row.LD_CODE).toBe('000519'); // party
  });

  it('unvalued old metal is a money-free FINE row that feeds the report', () => {
    const rows = buildOrderRojmel(ordCtx, { ...legs(), oldMetal: [metalLine()] });
    const row = rows.find((r) => typeOf(r) === '06')!;
    expect(row.DR_AMT).toBe(0);
    expect(row.CR_AMT).toBe(0);
    expect(row.IT_TYPE).toBe('G'); // the metal letter, so RP_ROJMEL's fine summary sees it
    expect(row.SIGN).toBe('+'); // metal coming IN
    expect(row.ITM_FINE).toBe(18);
    // Accounts flip back to party-first on a fine row, the opposite of the valued row above.
    expect(row.AC_CODE).toBe('000519');
    expect(row.LD_CODE).toBe('00010');
  });

  it('the two old-metal types are mutually exclusive per line', () => {
    const valued = buildOrderRojmel(ordCtx, {
      ...legs(),
      oldMetal: [metalLine({ netAmount: 9300 })],
    }).map(typeOf);
    expect(valued).toContain('04');
    expect(valued).not.toContain('06');
    const unvalued = buildOrderRojmel(ordCtx, { ...legs(), oldMetal: [metalLine()] }).map(typeOf);
    expect(unvalued).toContain('06');
    expect(unvalued).not.toContain('04');
  });

  it('header rows are 23-character keys; detail rows are 33 with the line number', () => {
    const rows = buildOrderRojmel(ordCtx, {
      ...legs({ advanceAmount: 100, chequeAmount: 50 }),
      oldMetal: [metalLine({ netAmount: 1 })],
    });
    for (const r of rows) {
      const len = String(r.LEDR_KEY).length;
      expect(['01', '02'].includes(typeOf(r)) ? len : 33).toBe(len === 23 ? 23 : 33);
    }
    expect(String(rows.find((r) => typeOf(r) === '01')!.LEDR_KEY)).toHaveLength(23);
    expect(String(rows.find((r) => typeOf(r) === '02')!.LEDR_KEY)).toHaveLength(23);
    expect(String(rows.find((r) => typeOf(r) === '04')!.LEDR_KEY)).toHaveLength(33);
  });

  it('two detail lines produce DISTINCT keys — the direct guard against 23505', () => {
    // ROJ_MEL_DATA's primary key is LEDR_KEY alone, so two lines sharing a key collide outright.
    const rows = buildOrderRojmel(ordCtx, {
      ...legs(),
      oldMetal: [metalLine({ lineNo: 1 }), metalLine({ lineNo: 2 })],
    });
    expect(rows).toHaveLength(2);
    expect(rows[0]!.LEDR_KEY).not.toBe(rows[1]!.LEDR_KEY);
    expect(new Set(rows.map((r) => r.LEDR_KEY)).size).toBe(2);
  });

  it('never emits the dead or unexplained types 03, 05, 07 or 08', () => {
    // 03 card and 07 rate-cut fine are cleanly dead (CARD_AMT and RCUT_FINE are 0 of 76 orders); 08 UPI has
    // one row company-wide. 05 scheme adjust is an ANOMALY: SCHM_AMT is non-zero on 7 of 76 orders yet
    // there are ZERO type-05 rows, so emitting it would add rows the desktop does not have.
    const rows = buildOrderRojmel(ordCtx, {
      ...legs({ advanceAmount: 100, chequeAmount: 50 }),
      oldMetal: [metalLine({ netAmount: 1, lineNo: 1 }), metalLine({ lineNo: 2 })],
    });
    const types = rows.map(typeOf);
    for (const dead of ['03', '05', '07', '08']) expect(types).not.toContain(dead);
    expect(types.sort()).toEqual(['01', '02', '04', '06']);
  });
});

describe('scheme adjustment (book 076) — 3 live types of 8', () => {
  // 21 + 8 + 8 = 37, matching the book exactly. The five unbuilt types all require GOLD_WT or GOLD_AMT,
  // which is 0 on all 26 AD_ADJ rows, and SCHM_TYPE 'G'/'S' while all four of this company's schemes are
  // 'A'. Two independent facts, same conclusion.
  const adjCtx: RojmelContext = { ...ctx, coBook: '076', partyCode: '00004' };
  const line = (over: Record<string, unknown> = {}) => ({
    lineNo: 1,
    schemeAc: '000858', // AD_MAST.SCHM_AC
    bonusAc: '00079', // BOOK_DETL slot 1 on the desktop
    settlementAc: '00004',
    adjustedAmount: 26000,
    bonus: 18000,
    memberName: 'A MEMBER',
    ...over,
  });
  const typeOf = (r: { LEDR_KEY: unknown }) => String(r.LEDR_KEY).slice(21, 23);

  it('splits the principal from the bonus, so type 01 is ADJ_AMT LESS the bonus', () => {
    // Real arithmetic: ADJ_AMT = MEMB_AMT + MEMB_BONUS - MEMB_LESS, verified on every row. The bonus is
    // an expense the shop grants, not scheme money the member paid in, so it is charged separately.
    const rows = buildSchemeAdjRojmel(adjCtx, [line()]);
    const principal = rows.find((r) => typeOf(r) === '01')!;
    const bonus = rows.find((r) => typeOf(r) === '02')!;
    expect(principal.DR_AMT).toBe(8000); // 26000 - 18000
    expect(bonus.DR_AMT).toBe(18000);
    // The pair sums to the settlement credit, which is what makes the voucher hang together.
    expect(principal.DR_AMT + bonus.DR_AMT).toBe(rows.find((r) => typeOf(r) === '03')!.CR_AMT);
  });

  it('the scheme-side rows are debits; the settlement row is the credit mirror', () => {
    const rows = buildSchemeAdjRojmel(adjCtx, [line()]);
    const p = rows.find((r) => typeOf(r) === '01')!;
    const s3 = rows.find((r) => typeOf(r) === '03')!;
    expect(p.AC_CODE).toBe('000858'); // scheme liability named
    expect(p.LD_CODE).toBe('00004'); // settlement account as contra
    expect(s3.AC_CODE).toBe('00004'); // and the mirror reverses them
    expect(s3.LD_CODE).toBe('000858');
    expect(s3.CR_AMT).toBe(26000);
    expect(s3.DR_AMT).toBe(0);
  });

  it('the bonus row charges a DIFFERENT account from the principal', () => {
    const rows = buildSchemeAdjRojmel(adjCtx, [line()]);
    const p = rows.find((r) => typeOf(r) === '01')!;
    const b = rows.find((r) => typeOf(r) === '02')!;
    expect(b.AC_CODE).toBe('00079');
    expect(b.AC_CODE).not.toBe(p.AC_CODE);
  });

  it('omits type 01 when the whole adjustment was bonus', () => {
    // 21 type-01 rows against 26 AD_ADJ rows: on five, ADJ_AMT - MEMB_BONUS came to zero.
    const rows = buildSchemeAdjRojmel(adjCtx, [line({ adjustedAmount: 18000, bonus: 18000 })]);
    expect(rows.map(typeOf)).toEqual(['02', '03']);
  });

  it('omits the bonus row when no bonus was granted', () => {
    const rows = buildSchemeAdjRojmel(adjCtx, [line({ adjustedAmount: 7500, bonus: 0 })]);
    expect(rows.map(typeOf)).toEqual(['01', '03']);
    expect(rows.find((r) => typeOf(r) === '01')!.DR_AMT).toBe(7500);
  });

  it('suppresses the settlement row when the balance went onto a sales bill', () => {
    // SBILL_AMT <> 0 means the bill's own Rojmel rows carry the settlement; emitting here would
    // double-count it in the day book.
    const rows = buildSchemeAdjRojmel(adjCtx, [line({ settledAgainstBillAmount: 26000 })]);
    expect(rows.map(typeOf)).toEqual(['01', '02']);
  });

  it('carries no metal — a scheme adjustment moves money only', () => {
    for (const r of buildSchemeAdjRojmel(adjCtx, [line()])) {
      expect(r.IT_TYPE).toBe('A');
      expect(r.SIGN).toBe('');
      expect(r.ITM_GWT).toBe(0);
      expect(r.ITM_FINE).toBe(0);
    }
  });

  it('all three keys are 33 characters and two members do not collide', () => {
    // Every one of the 37 real keys is 33 characters: all three types carry STR(SR_NO), because one
    // voucher can adjust several members and LEDR_KEY is the whole primary key.
    const rows = buildSchemeAdjRojmel(adjCtx, [line({ lineNo: 1 }), line({ lineNo: 2 })]);
    expect(rows.every((r) => String(r.LEDR_KEY).length === 33)).toBe(true);
    expect(new Set(rows.map((r) => r.LEDR_KEY)).size).toBe(rows.length);
    expect(rows).toHaveLength(6); // three types × two members
  });

  it('never emits the five gold-scheme types', () => {
    const types = buildSchemeAdjRojmel(adjCtx, [line()]).map(typeOf);
    for (const dead of ['04', '05', '06', '07', '08']) expect(types).not.toContain(dead);
  });
});

describe('fine JV (book 078) — 2 types, the only wholly money-free family', () => {
  // 14 + 14 = 28, matching the book exactly. Source (Ac_Rojmel.Contra_Rojmel lines 342/344) and data agree.
  // Sampled real rows: ac=000939 ld=000275 G '+' fine 36.200; ac=000939 ld=000258 G '+' fine 42.240.
  const jvCtx: RojmelContext = { ...ctx, coBook: '078', partyCode: '' };
  const line = (over: Record<string, unknown> = {}) => ({
    lineNo: 1,
    acCode: '000939',
    ldCode: '000275',
    metal: 'G' as const,
    creditFine: 0,
    debitFine: 0,
    ...over,
  });
  const typeOf = (r: { LEDR_KEY: unknown }) => String(r.LEDR_KEY).slice(21, 23);

  it('carries fine and NOTHING else — no money, no gross weight', () => {
    // This is the defining property and what separates a fine JV from every other family here: it moves
    // pure fine between two accounts, so there is no article to weigh and no cash.
    const [row] = buildFineJvRojmel(jvCtx, [line({ creditFine: 36.2 })]);
    expect(row!.ITM_FINE).toBe(36.2);
    expect(row!.DR_AMT).toBe(0);
    expect(row!.CR_AMT).toBe(0);
    expect(row!.ITM_GWT).toBe(0);
    expect(row!.ITM_NWT).toBe(0);
    expect(row!.ITM_TOUCH).toBe(0);
    expect(row!.ITM_RATE).toBe(0);
  });

  it('credit fine is type 01 with SIGN +, debit fine is type 02 with SIGN -', () => {
    const cr = buildFineJvRojmel(jvCtx, [line({ creditFine: 5 })])[0]!;
    expect(typeOf(cr)).toBe('01');
    expect(cr.SIGN).toBe('+');
    const dr = buildFineJvRojmel(jvCtx, [line({ debitFine: 5 })])[0]!;
    expect(typeOf(dr)).toBe('02');
    expect(dr.SIGN).toBe('-');
  });

  it('copies the accounts straight across — no flip, no book slot', () => {
    // Unlike most families in this file there is no account reversal between row types and no BOOK_DETL
    // slot involved; both rows name the CONTRA_DATA line's own accounts.
    const rows = buildFineJvRojmel(jvCtx, [line({ creditFine: 5, debitFine: 3 })]);
    for (const r of rows) {
      expect(r.AC_CODE).toBe('000939');
      expect(r.LD_CODE).toBe('000275');
    }
  });

  it('one line can produce BOTH rows — the desktop guards the two inserts independently', () => {
    const rows = buildFineJvRojmel(jvCtx, [line({ creditFine: 5, debitFine: 3 })]);
    expect(rows.map(typeOf)).toEqual(['01', '02']);
    expect(rows[0]!.ITM_FINE).toBe(5);
    expect(rows[1]!.ITM_FINE).toBe(3);
  });

  it('writes nothing when a line carries no fine at all', () => {
    expect(buildFineJvRojmel(jvCtx, [line()])).toEqual([]);
  });

  it('keys are 33 characters and two lines do not collide', () => {
    const rows = buildFineJvRojmel(jvCtx, [
      line({ lineNo: 1, creditFine: 5 }),
      line({ lineNo: 2, creditFine: 7 }),
    ]);
    expect(rows.every((r) => String(r.LEDR_KEY).length === 33)).toBe(true);
    expect(new Set(rows.map((r) => r.LEDR_KEY)).size).toBe(2);
  });

  it('the metal letter comes from the line, not a default', () => {
    expect(buildFineJvRojmel(jvCtx, [line({ metal: 'S', creditFine: 1 })])[0]!.IT_TYPE).toBe('S');
  });
});
