export class MeltingParityValidationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'MeltingParityValidationError';
  }
}

const number = (value: unknown): number => (value == null || value === '' ? 0 : Number(value));
const finite = (value: unknown, label: string): number => {
  const parsed = number(value);
  if (!Number.isFinite(parsed) || parsed < 0) {
    throw new MeltingParityValidationError(`${label} must be a non-negative number`);
  }
  return parsed;
};
export const meltingRound3 = (value: number): number =>
  Math.round((value + Number.EPSILON) * 1000) / 1000;
export const meltingRound2 = (value: number): number =>
  Math.round((value + Number.EPSILON) * 100) / 100;

export interface MeltingOutInput {
  itCode: string;
  pieces?: number;
  grossWt: number;
  otherWt?: number;
  touch?: number;
  lotNo?: string;
}

export interface MeltingOutRow extends MeltingOutInput {
  netWt: number;
  partyFine: number;
}

/** Desktop material-out grid: NWT=GWT-OTH; blank/zero touch treats net weight as fine. */
export function calculateMeltingOutRow(input: MeltingOutInput): MeltingOutRow {
  const grossWt = finite(input.grossWt, 'gross weight');
  const otherWt = finite(input.otherWt, 'other weight');
  const touch = finite(input.touch, 'touch');
  if (!String(input.itCode ?? '').trim()) {
    throw new MeltingParityValidationError('material-out item is required');
  }
  if (otherWt > grossWt) {
    throw new MeltingParityValidationError('other weight cannot exceed gross weight');
  }
  const netWt = meltingRound3(grossWt - otherWt);
  const partyFine = meltingRound3(netWt !== 0 && touch !== 0 ? (netWt * touch) / 100 : netWt);
  return {
    ...input,
    pieces: finite(input.pieces, 'pieces'),
    grossWt,
    otherWt,
    touch,
    netWt,
    partyFine,
  };
}

export interface MeltingOutTotals {
  grossWt: number;
  netWt: number;
  partyFine: number;
  averageTouch: number;
}

export function calculateMeltingOutTotals(rows: MeltingOutRow[]): MeltingOutTotals {
  const grossWt = meltingRound3(rows.reduce((sum, row) => sum + row.grossWt, 0));
  const netWt = meltingRound3(rows.reduce((sum, row) => sum + row.netWt, 0));
  const partyFine = meltingRound3(rows.reduce((sum, row) => sum + row.partyFine, 0));
  return {
    grossWt,
    netWt,
    partyFine,
    averageTouch: netWt === 0 ? 0 : meltingRound2((partyFine / netWt) * 100),
  };
}

export interface MeltingResultInput {
  itCode: string;
  grossWt: number;
  touch?: number;
  conItCode?: string;
  conPct?: number;
  conWt?: number;
  finePct?: number;
  fineAdd?: number;
  returnItCode?: string;
  returnWt?: number;
  recoveredGrossWt?: number;
  lotNo?: string;
}

export interface MeltingResultRow extends MeltingResultInput {
  partyFine: number;
  conWt: number;
  finePct: number;
  fineAdd: number;
  meltWt: number;
  returnWt: number;
  recoveredGrossWt: number;
  lossWt: number;
}

/** Desktop melt-result grid, including first-row average-touch conversion/add-fine branches. */
export function calculateMeltingResultRow(
  input: MeltingResultInput,
  context: { rowIndex: number; totalInputGrossWt: number; averageTouch: number },
): MeltingResultRow {
  if (!String(input.itCode ?? '').trim()) {
    throw new MeltingParityValidationError('melt-result item is required');
  }
  const grossWt = finite(input.grossWt, 'result gross weight');
  const touch = finite(input.touch, 'result touch');
  const conPct = finite(input.conPct, 'conversion percent');
  const averageTouch = finite(context.averageTouch, 'average touch');
  const totalInputGrossWt = finite(context.totalInputGrossWt, 'total input gross weight');
  const partyFine = meltingRound3(touch ? (grossWt * touch) / 100 : grossWt);
  let conWt = finite(input.conWt, 'conversion weight');
  let finePct = finite(input.finePct, 'fine percent');
  let fineAdd = finite(input.fineAdd, 'fine add');
  let meltWt: number;

  if (context.rowIndex !== 0 || totalInputGrossWt === 0) {
    meltWt = grossWt;
  } else if (conPct > averageTouch) {
    finePct = finePct || 100;
    if (finePct <= conPct) {
      throw new MeltingParityValidationError('fine percent must exceed conversion percent');
    }
    fineAdd = meltingRound3((grossWt * (conPct - averageTouch)) / (finePct - conPct));
    meltWt = meltingRound3(grossWt + fineAdd);
    conWt = 0;
  } else {
    fineAdd = 0;
    finePct = 0;
    if (partyFine !== 0 && conPct !== 0) {
      conWt = meltingRound3((partyFine / conPct) * 100 - partyFine);
      meltWt = meltingRound3(partyFine + conWt);
    } else {
      meltWt = meltingRound3(grossWt + conWt);
    }
  }

  const returnWt = finite(input.returnWt, 'return weight');
  if (returnWt > meltWt) {
    throw new MeltingParityValidationError('return weight cannot exceed melt weight');
  }
  const recoveredGrossWt =
    input.recoveredGrossWt == null
      ? meltingRound3(meltWt - returnWt)
      : finite(input.recoveredGrossWt, 'recovered gross weight');
  const lossWt = meltingRound3(meltWt - (returnWt + recoveredGrossWt));
  return {
    ...input,
    grossWt,
    touch,
    conPct,
    partyFine,
    conWt,
    finePct,
    fineAdd,
    meltWt,
    returnWt,
    recoveredGrossWt,
    lossWt,
  };
}

export interface MeltingStockProjection {
  isrNo: 1 | 2 | 3 | 4 | 5 | 6;
  sourceRow: number;
  itCode: string;
  sign: '+' | '-';
  trType: 'I' | 'O';
  netWt: number;
  fineWt: number;
  touch: number;
  acCode?: string;
}

/** Build the six desktop Mlting_Stk projection families; no money ledger is created. */
export function buildMeltingStockProjections(input: {
  outRows: MeltingOutRow[];
  resultRows: MeltingResultRow[];
  acCode?: string;
}): MeltingStockProjection[] {
  const projections: MeltingStockProjection[] = [];
  const hasInput = input.outRows.some((row) => row.grossWt !== 0);
  input.outRows.forEach((row, index) =>
    projections.push({
      isrNo: 1,
      sourceRow: index + 1,
      itCode: row.itCode,
      sign: '-',
      trType: 'O',
      netWt: row.netWt,
      fineWt: row.partyFine,
      touch: number(row.touch),
      acCode: input.acCode,
    }),
  );
  input.resultRows.forEach((row, index) => {
    const sourceRow = index + 1;
    if (hasInput) {
      projections.push({
        isrNo: 2,
        sourceRow,
        itCode: row.itCode,
        sign: '+',
        trType: 'I',
        netWt: row.recoveredGrossWt,
        fineWt: meltingRound3(row.partyFine + row.fineAdd),
        touch: number(row.conPct),
      });
    }
    if (row.conItCode && row.fineAdd !== 0) {
      projections.push({
        isrNo: 3,
        sourceRow,
        itCode: row.conItCode,
        sign: '-',
        trType: 'O',
        netWt: row.fineAdd,
        fineWt: row.fineAdd,
        touch: row.finePct,
      });
    }
    if (row.conItCode && row.conWt !== 0) {
      projections.push({
        isrNo: 4,
        sourceRow,
        itCode: row.conItCode,
        sign: '-',
        trType: 'O',
        netWt: row.conWt,
        fineWt: row.conWt,
        touch: 100,
      });
    }
    if (input.acCode) {
      projections.push({
        isrNo: 5,
        sourceRow,
        itCode: row.itCode,
        sign: '-',
        trType: 'O',
        netWt: row.recoveredGrossWt,
        fineWt: meltingRound3(row.partyFine + row.fineAdd),
        touch: number(row.conPct),
        acCode: input.acCode,
      });
    }
    if (row.returnItCode && row.returnWt !== 0) {
      projections.push({
        isrNo: 6,
        sourceRow,
        itCode: row.returnItCode,
        sign: '+',
        trType: 'I',
        netWt: row.returnWt,
        fineWt: row.returnWt,
        touch: 100,
      });
    }
  });
  return projections;
}
