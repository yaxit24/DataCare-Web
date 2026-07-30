import { describe, expect, it } from 'vitest';
import {
  buildMeltingStockProjections,
  calculateMeltingOutRow,
  calculateMeltingOutTotals,
  calculateMeltingResultRow,
  MeltingParityValidationError,
} from '../src/modules/manufacturing/meltingParity.js';

describe('desktop melting parity kernel', () => {
  it('calculates material-out net, fine and weighted average touch at desktop precision', () => {
    const first = calculateMeltingOutRow({
      itCode: 'SCRAP',
      pieces: 1,
      grossWt: 100,
      otherWt: 10,
      touch: 80,
    });
    const second = calculateMeltingOutRow({ itCode: 'FINE', grossWt: 10, touch: 0 });
    expect(first).toMatchObject({ netWt: 90, partyFine: 72 });
    expect(second).toMatchObject({ netWt: 10, partyFine: 10 });
    expect(calculateMeltingOutTotals([first, second])).toEqual({
      grossWt: 110,
      netWt: 100,
      partyFine: 82,
      averageTouch: 82,
    });
  });

  it('uses the first-row add-fine branch when conversion purity exceeds average touch', () => {
    const row = calculateMeltingResultRow(
      {
        itCode: 'MELT',
        grossWt: 100,
        touch: 80,
        conItCode: 'FINE',
        conPct: 90,
      },
      { rowIndex: 0, totalInputGrossWt: 100, averageTouch: 80 },
    );
    expect(row).toMatchObject({
      partyFine: 80,
      finePct: 100,
      fineAdd: 100,
      conWt: 0,
      meltWt: 200,
      recoveredGrossWt: 200,
      lossWt: 0,
    });
  });

  it('uses the conversion-weight branch and derives return, recovery and loss', () => {
    const row = calculateMeltingResultRow(
      {
        itCode: 'MELT',
        grossWt: 100,
        touch: 80,
        conItCode: 'ALLOY',
        conPct: 80,
        returnItCode: 'RETURN',
        returnWt: 10,
        recoveredGrossWt: 88,
      },
      { rowIndex: 0, totalInputGrossWt: 100, averageTouch: 85 },
    );
    expect(row).toMatchObject({
      partyFine: 80,
      conWt: 20,
      finePct: 0,
      fineAdd: 0,
      meltWt: 100,
      returnWt: 10,
      recoveredGrossWt: 88,
      lossWt: 2,
    });
  });

  it('treats later/no-input results as direct melt weight and rejects impossible values', () => {
    expect(
      calculateMeltingResultRow(
        { itCode: 'MELT', grossWt: 25, touch: 90, conPct: 99 },
        { rowIndex: 1, totalInputGrossWt: 100, averageTouch: 80 },
      ),
    ).toMatchObject({ meltWt: 25, partyFine: 22.5 });
    expect(() =>
      calculateMeltingResultRow(
        { itCode: 'MELT', grossWt: 10, conPct: 90, finePct: 90 },
        { rowIndex: 0, totalInputGrossWt: 10, averageTouch: 80 },
      ),
    ).toThrow(MeltingParityValidationError);
    expect(() => calculateMeltingOutRow({ itCode: 'SCRAP', grossWt: 5, otherWt: 6 })).toThrow(
      /cannot exceed/,
    );
  });

  it('builds all six desktop MAIN_STOCK projection families with exact signs', () => {
    const out = calculateMeltingOutRow({ itCode: 'SCRAP', grossWt: 100, touch: 80 });
    const addFine = calculateMeltingResultRow(
      {
        itCode: 'MELT1',
        grossWt: 100,
        touch: 80,
        conItCode: 'FINE',
        conPct: 90,
        returnItCode: 'RETURN',
        returnWt: 10,
      },
      { rowIndex: 0, totalInputGrossWt: 100, averageTouch: 80 },
    );
    const conversion = calculateMeltingResultRow(
      {
        itCode: 'MELT2',
        grossWt: 50,
        touch: 80,
        conItCode: 'ALLOY',
        conPct: 80,
      },
      { rowIndex: 0, totalInputGrossWt: 100, averageTouch: 85 },
    );
    const rows = buildMeltingStockProjections({
      outRows: [out],
      resultRows: [addFine, conversion],
      acCode: 'PARTY',
    });
    expect(new Set(rows.map((row) => row.isrNo))).toEqual(new Set([1, 2, 3, 4, 5, 6]));
    expect(rows.filter((row) => row.isrNo === 1)).toMatchObject([
      { itCode: 'SCRAP', sign: '-', trType: 'O', netWt: 100, fineWt: 80 },
    ]);
    expect(rows.find((row) => row.isrNo === 2)).toMatchObject({ sign: '+', trType: 'I' });
    expect(rows.find((row) => row.isrNo === 3)).toMatchObject({
      itCode: 'FINE',
      sign: '-',
      trType: 'O',
    });
    expect(rows.find((row) => row.isrNo === 4)).toMatchObject({
      itCode: 'ALLOY',
      sign: '-',
      trType: 'O',
      touch: 100,
    });
    expect(rows.find((row) => row.isrNo === 5)).toMatchObject({
      acCode: 'PARTY',
      sign: '-',
      trType: 'O',
    });
    expect(rows.find((row) => row.isrNo === 6)).toMatchObject({
      itCode: 'RETURN',
      sign: '+',
      trType: 'I',
    });
  });
});
