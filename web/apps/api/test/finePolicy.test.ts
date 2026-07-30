import { describe, expect, it } from 'vitest';
import { fineWt } from '../src/modules/shared/fine.js';
import { fineFor, type FineWorkflow } from '../src/modules/shared/finePolicy.js';

const matchingWorkflows: FineWorkflow[] = [
  'sale',
  'salesOrder',
  'purchaseItem',
  'tagOpening',
  'melting',
  'mfg',
];

describe('named desktop fine policies', () => {
  it.each(matchingWorkflows)('%s keeps the historical default formula', (workflow) => {
    expect(fineFor(workflow, { netWt: 10, ghtWt: 2, touch: 90, westPct: 2 })).toBe(11.04);
    expect(fineFor(workflow, { netWt: 10, ghtWt: 2, touch: 0, westPct: 0 })).toBe(12);
  });

  it('item opening follows both desktop branches and ignores ghat', () => {
    // TR_ITM_OPBL.cs:949-955: 10 × (90 + 2) / 100; 5g ghat is not part of the base.
    expect(fineFor('itemOpening', { netWt: 10, ghtWt: 5, touch: 90, westPct: 2 })).toBe(9.2);
    // The desktop gate is touch != 0, not touch + west != 0.
    expect(fineFor('itemOpening', { netWt: 10, ghtWt: 5, touch: 0, westPct: 2 })).toBe(10);
  });

  it('item lot follows both desktop branches and ignores ghat', () => {
    // TR_ITM_LOT.cs:2722-2732: 20 × (80 + 1) / 100; 3g ghat is ignored.
    expect(fineFor('itemLot', { netWt: 20, ghtWt: 3, touch: 80, westPct: 1 })).toBe(16.2);
    expect(fineFor('itemLot', { netWt: 20, ghtWt: 3, touch: 0, westPct: 0 })).toBe(20);
  });

  it('karigar issue follows both branches and subtracts lesWt', () => {
    // TR_KR_ISU.cs:3938-3944: (10 + 2) × (90 + 2) / 100 - 1.25.
    expect(
      fineFor('karigarIssue', {
        netWt: 10,
        ghtWt: 2,
        touch: 90,
        westPct: 2,
        lesWt: 1.25,
      }),
    ).toBe(9.79);
    expect(
      fineFor('karigarIssue', {
        netWt: 10,
        ghtWt: 2,
        touch: 0,
        westPct: 0,
        lesWt: 1.25,
      }),
    ).toBe(8.75);
  });

  it('purchase old-gold/Kun follows both branches with lesTouch and kunFine', () => {
    // TR_PURC.cs:7310-7317: (10 + 2) × (90 + 2 - 5) / 100 + 0.4.
    expect(
      fineFor('purchaseOldGold', {
        netWt: 10,
        ghtWt: 2,
        touch: 90,
        westPct: 2,
        lesTouch: 5,
        kunFine: 0.4,
      }),
    ).toBe(10.84);
    expect(
      fineFor('purchaseOldGold', {
        netWt: 10,
        ghtWt: 2,
        touch: 0,
        westPct: 0,
        lesTouch: 5,
        kunFine: 0.4,
      }),
    ).toBe(10.4);
  });

  it('wholesale sale return subtracts less-touch and keeps its net-plus-ghat fallback', () => {
    // TR_WH_SALE_RTN.cs:5729-5771: (10 + 2) × (90 + 2 - 5) / 100.
    expect(
      fineFor('wholesaleSaleReturn', {
        netWt: 10,
        ghtWt: 2,
        touch: 90,
        westPct: 2,
        lesTouch: 5,
      }),
    ).toBe(10.44);
    expect(
      fineFor('wholesaleSaleReturn', {
        netWt: 10,
        ghtWt: 2,
        touch: 0,
        westPct: 0,
        lesTouch: 5,
      }),
    ).toBe(12);
  });

  it('karigar receipt remains net-only per MS_UPDATE.cs:2691', () => {
    expect(fineFor('karigarReceipt', { netWt: 10, ghtWt: 5, touch: 90, westPct: 2 })).toBe(9.2);
    expect(fineFor('karigarReceipt', { netWt: 10, ghtWt: 5, touch: 0, westPct: 0 })).toBe(0);
  });
});

describe('fineWt backward compatibility', () => {
  it('retains historical sale, purchase-item, and tag-opening values', () => {
    expect(fineWt(10, 2, 90, 2)).toBe(11.04); // sale shape
    expect(fineWt(10, 0, 91.6, 0)).toBe(9.16); // purchase-item shape
    expect(fineWt(10, 2, 0, 0)).toBe(12); // tag-opening zero-pct shape
  });
});
