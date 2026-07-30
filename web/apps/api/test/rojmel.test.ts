import { describe, it, expect } from 'vitest';
import {
  ROJMEL_ROW_TYPE,
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
    // Revenue debited, party credited — the mirror of a sale.
    expect(purchase[0]!.DR_AMT).toBe(1087);
    expect(purchase[0]!.CR_AMT).toBe(0);
    const party = purchase.find((r) => r.AC_CODE === '000888')!;
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
