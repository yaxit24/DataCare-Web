import { round, roundHalfEven } from '@datacare/core';

/**
 * G206: the Sales Order's old gold / old silver grid, TR_SALE_ORD MSG_OLD (Sr, ItCode, ItName, Pcs, GrWt, OthWt,
 * NetWt, Touch, Fine, RTyp, Rate, NetAmt; `:3957-4020`). The operator types the item, pieces, gross and other weight,
 * touch, rate type and the rate or the amount. CommPassTotal_Old (`:4427-4500`) derives the rest, and the API repeats
 * the same derivation when it saves, so the grid shows what the order will store.
 */
export type OldMetalRow = {
  key: string;
  itCode: string;
  itName: string;
  /** The item master's IT_TYPE, from the picked item ('G' is old gold, any other type counts as old silver). */
  itType: string;
  pcs: string;
  grossWt: string;
  otherWt: string;
  touch: string;
  /** Typed fine; used only when there is no touch. */
  fine: string;
  rateType: 'N' | 'F';
  rate: string;
  amount: string;
  /** Which of rate and amount the operator typed last; the other one is derived from it. */
  source: 'rate' | 'amount';
};

let nextOldMetalKey = 0;
export const blankOldMetalRow = (): OldMetalRow => ({
  key: `old-metal-${++nextOldMetalKey}`,
  itCode: '',
  itName: '',
  itType: '',
  pcs: '',
  grossWt: '',
  otherWt: '',
  touch: '',
  fine: '',
  rateType: 'F',
  rate: '',
  amount: '',
  source: 'amount',
});

const num = (value: string): number => {
  const n = Number(value);
  return Number.isFinite(n) && n > 0 ? n : 0;
};

export type DerivedOldMetal = {
  netWt: number;
  fine: number;
  rate: number;
  amount: number;
};

/** Net weight, fine, rate and amount of one row, as CommPassTotal_Old leaves them. */
export function deriveOldMetal(row: OldMetalRow): DerivedOldMetal {
  const netWt = round(num(row.grossWt) - num(row.otherWt), 3);
  const touch = num(row.touch);
  const fine =
    touch !== 0 && netWt !== 0
      ? round((netWt * touch) / 100, 3)
      : num(row.fine) !== 0
        ? round(num(row.fine), 3)
        : netWt;
  const basis = row.rateType === 'N' ? netWt : fine;
  let rate = round(num(row.rate), 2);
  let amount = round(num(row.amount), 2);
  if (basis !== 0) {
    if (row.source === 'amount') {
      if (amount !== 0) rate = roundHalfEven(amount / basis, 0);
    } else if (rate !== 0) {
      amount = roundHalfEven(basis * rate, 0);
    }
  }
  return { netWt, fine, rate, amount };
}

/** A row the order saves: an item code and a net weight or an amount (`TR_SALE_ORD.cs:9429-9431`). */
export const countsOldMetal = (row: OldMetalRow): boolean => {
  const d = deriveOldMetal(row);
  return !!row.itCode.trim() && d.netWt + d.amount !== 0;
};

/** The grid's totals by the item type, as BILL_TOTAL sums them (`:11345-11365`). */
export function oldMetalGridTotals(rows: readonly OldMetalRow[]) {
  const out = { goldAmount: 0, silverAmount: 0, goldFine: 0, silverFine: 0 };
  for (const row of rows) {
    if (!countsOldMetal(row)) continue;
    const d = deriveOldMetal(row);
    if (row.itType === 'G') {
      out.goldAmount += d.amount;
      out.goldFine += d.fine;
    } else {
      out.silverAmount += d.amount;
      out.silverFine += d.fine;
    }
  }
  return {
    goldAmount: round(out.goldAmount, 2),
    silverAmount: round(out.silverAmount, 2),
    goldFine: round(out.goldFine, 3),
    silverFine: round(out.silverFine, 3),
  };
}

/** The request's rows. Every grid row is sent so the Sr numbering holds; the API keeps the ones that count. */
export function oldMetalPayload(rows: readonly OldMetalRow[]) {
  return rows.map((row, index) => {
    for (const [label, value] of [
      ['Pcs', row.pcs],
      ['GrWt', row.grossWt],
      ['OthWt', row.otherWt],
      ['Touch', row.touch],
      ['Fine', row.fine],
      ['Rate', row.rate],
      ['NetAmt', row.amount],
    ] as const)
      if (value.trim() && !(Number.isFinite(Number(value)) && Number(value) >= 0))
        throw new Error(`${label} on old metal line ${index + 1} must be a non-negative number`);
    const d = deriveOldMetal(row);
    return {
      itCode: row.itCode.trim(),
      pcs: num(row.pcs),
      grossWt: num(row.grossWt),
      otherWt: num(row.otherWt),
      touch: num(row.touch),
      fine: num(row.fine),
      rateType: row.rateType,
      rate: d.rate,
      netAmt: d.amount,
    };
  });
}

/** Saved rows back into the grid. The amount is the source when there is one, as on a desktop reload. */
export function hydrateOldMetal(rows: unknown): OldMetalRow[] {
  if (!Array.isArray(rows)) return [];
  return rows.map((raw: Record<string, unknown>) => {
    const amount = Number(raw.netAmt ?? 0);
    const fixed = (value: unknown, dp: number) =>
      Number(value ?? 0) ? Number(value).toFixed(dp) : '';
    return {
      key: `old-metal-${++nextOldMetalKey}`,
      itCode: String(raw.itCode ?? ''),
      itName: String(raw.itName ?? ''),
      itType: String(raw.itType ?? ''),
      pcs: Number(raw.pcs ?? 0) ? String(Number(raw.pcs)) : '',
      grossWt: fixed(raw.grossWt, 3),
      otherWt: fixed(raw.otherWt, 3),
      touch: fixed(raw.touch, 2),
      fine: Number(raw.touch ?? 0) ? '' : fixed(raw.fine, 3),
      rateType: raw.rateType === 'N' ? 'N' : 'F',
      rate: fixed(raw.rate, 2),
      amount: fixed(amount, 2),
      source: amount ? 'amount' : 'rate',
    } satisfies OldMetalRow;
  });
}
