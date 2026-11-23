import { describe, expect, it } from 'vitest';
import {
  assertPurchaseFamilyBook,
  carryUnownedColumns,
  hallmarkDetailColumns,
  hallmarkHeaderAmount,
  tagBandBarColumns,
} from '../src/modules/purchase/purchaseHallmark.js';

/**
 * WP-28 (N244 / G256) pure rules of the hallmark receive branch (TR_PURC_HM). Cases from
 * `orchestration/work/WP-28/cases.md`; desktop lines are quoted on each expectation.
 */
describe('WP-28 hallmark purchase rules', () => {
  // purchase-invoice.formula.hm-amount-header-half-to-even
  it('header HM_AMT is Math.Round of the line column total, half to even (TR_PURC_HM.cs:9995)', () => {
    expect(hallmarkHeaderAmount([{ hmIdAmount: 36.5 }, { hmIdAmount: 40 }], undefined)).toBe(76);
    expect(hallmarkHeaderAmount([{ hmIdAmount: 46.5 }, { hmIdAmount: 40 }], undefined)).toBe(86);
    expect(hallmarkHeaderAmount([{ hmIdAmount: 36.5 }], undefined)).toBe(36);
    expect(hallmarkHeaderAmount([{ hmIdAmount: 37.5 }], undefined)).toBe(38);
    // No line amount: the header charge typed on the plain layout stays as typed.
    expect(hallmarkHeaderAmount([{}, { hmIdAmount: 0 }], 50.25)).toBe(50.25);
    expect(hallmarkHeaderAmount([{}], undefined)).toBe(0);
    // Review finding: the column total is a running sum kept as "0.000" text (TR_PURC_HM.cs:6544), so 0.1 + 5.3 + 0.1
    // is 5.500 and Math.Round gives 6 (half to even). A plain double sum is 5.499999999999999 and would give 5.
    expect(
      hallmarkHeaderAmount(
        [{ hmIdAmount: 0.1 }, { hmIdAmount: 5.3 }, { hmIdAmount: 0.1 }],
        undefined,
      ),
    ).toBe(6);
  });

  // purchase-invoice.children.hm-ids-four-with-weights, refusal.book-family-screen-mismatch (D5)
  it('hallmark ids 2-4, their weights and the tag band are written only for a TAG PURCHASE book', () => {
    const line = {
      hmIdAmount: 36.5,
      itmColor: 'RED',
      hmId2: 'H2',
      hmId3: 'H3',
      hmId4: 'H4',
      hmIdWt: 0.1,
      hmId2Wt: 0.2,
      hmId3Wt: 0.3,
      hmId4Wt: 0.4,
      tagNwt: 9.8,
      tagOthWt: 0.5,
      tagCost: 61000,
      tagTotCost: 61500,
      tagMarginPct: 5,
    };
    const tag = hallmarkDetailColumns(line, true);
    expect(tag).toMatchObject({
      HM_ID_AMT: 36.5,
      ITM_COLOR: 'RED',
      HM_ID2: 'H2',
      HM_ID3: 'H3',
      HM_ID4: 'H4',
      HM_ID_WT: 0.1,
      HM_ID2_WT: 0.2,
      HM_ID3_WT: 0.3,
      HM_ID4_WT: 0.4,
      TAG_NWT: 9.8,
      TAG_OTH_WT: 0.5,
      TAG_COST: 61000,
      TAG_TOT_COST: 61500,
      TAG_MARGIN_PRC: 5,
      WITH_STOCK: 'N', // TR_PURC_HM.cs:8025
    });
    const plain = hallmarkDetailColumns(line, false);
    expect(plain).toMatchObject({
      HM_ID_AMT: 36.5,
      ITM_COLOR: 'RED',
      HM_ID2: null,
      HM_ID2_WT: 0,
      TAG_NWT: 0,
      TAG_COST: 0,
      TAG_TOT_COST: 0, // TR_PURC_HM.cs:8087
      TAG_MARGIN_PRC: 0,
      KR_NAME: '',
    });
    expect(plain).not.toHaveProperty('WITH_STOCK');
  });

  // purchase-invoice.formula.bar-detl-net-weight-rule
  it('BAR_DETL net weight is the tag net unless zero; KR_NET_WT is the line net (TR_PURC_HM.cs:8237-8246)', () => {
    expect(
      tagBandBarColumns({ netWt: 10, tagNwt: 9.8 }, { rate: 6050, metal: 60500 }),
    ).toMatchObject({ ITM_NWT: 9.8, KR_NET_WT: 10 });
    expect(tagBandBarColumns({ netWt: 10, tagNwt: 0 }, { rate: 6050, metal: 60500 })).toMatchObject(
      {
        ITM_NWT: 10,
        KR_NET_WT: 10,
      },
    );
  });

  // purchase-invoice.formula.bar-detl-rate-amount-rule
  it('BAR_DETL rate and amount: a typed tag amount wins with its cost and margin (TR_PURC_HM.cs:8304-8316)', () => {
    expect(
      tagBandBarColumns(
        {
          netWt: 10,
          tagRate: 6100,
          tagAmount: 61000,
          tagTotCost: 61500,
          tagMarginPct: 5,
          tagCost: 60000,
        },
        { rate: 6050, metal: 60500 },
      ),
    ).toMatchObject({ ITM_RATE: 6100, ITM_AMT: 61000, TAG_COST: 61500, ITM_MARGIN: 5 });
    expect(
      tagBandBarColumns(
        { netWt: 10, tagAmount: 0, tagCost: 60000, tagMarginPct: 5 },
        { rate: 6050, metal: 60500 },
      ),
    ).toMatchObject({ ITM_RATE: 6050, ITM_AMT: 60500, TAG_COST: 60000, ITM_MARGIN: 0 });
  });

  // purchase-invoice.refusal.book-not-purchase-family-create (D7)
  it('only PURCHASE and TAG PURCHASE books are purchase books (CON PUR keeps its own route)', () => {
    expect(() => assertPurchaseFamilyBook('PURCHASE', 'PR')).not.toThrow();
    expect(() => assertPurchaseFamilyBook('TAG PURCHASE', 'TPR')).not.toThrow();
    expect(() => assertPurchaseFamilyBook('CON PUR', 'CP')).not.toThrow();
    expect(() => assertPurchaseFamilyBook('SALES', 'SL')).toThrow(
      /SL.*SALES.*PURCHASE or TAG PURCHASE/,
    );
    expect(() => assertPurchaseFamilyBook('', 'PB')).toThrow(/PB/);
  });

  // D6: columns the writer does not own come back from the persisted row; owned ones never do.
  it('carries persisted columns the writer does not own, and never overrides an owned one', () => {
    const prior = {
      tenant_id: 't',
      row_id: 9n,
      OS_ADJ_AMT: 250,
      HM_AMT: 76,
      NET_AMT: 100,
    };
    expect(carryUnownedColumns(prior, { NET_AMT: 120, HM_AMT: null })).toEqual({
      OS_ADJ_AMT: 250,
      NET_AMT: 120,
      HM_AMT: null,
    });
    expect(carryUnownedColumns(undefined, { NET_AMT: 1 })).toEqual({ NET_AMT: 1 });
  });

  // Review finding: a stored blank keeps its stored form ('' from the desktop, NULL from an older web save).
  it('keeps the stored form of a blank when the built value is blank too, and only then', () => {
    const prior = { EMP_CODE: '', HM_AMT: null, ITM_COLOR: '', TAG_SRNO: 0, HM_ID: 'H1', OTH: '' };
    expect(
      carryUnownedColumns(prior, {
        EMP_CODE: null,
        HM_AMT: 0,
        ITM_COLOR: 'RED',
        TAG_SRNO: null,
        HM_ID: null,
        OTH: null,
      }),
    ).toEqual({ EMP_CODE: '', HM_AMT: null, ITM_COLOR: 'RED', TAG_SRNO: 0, HM_ID: null, OTH: '' });
  });
});
