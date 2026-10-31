import { fineFor } from './finePolicy.js';
import { round, roundHalfEven } from './money.js';

/**
 * Item Opening (desktop TR_ITM_OPBL) metal types: the screen's `cboItemTyp` (TR_ITM_OPBL.cs:1227-1234). The
 * first letter of the name is both ITEM_MAST.IT_TYPE and the opening's VCH_NO in book '000'.
 */
export const ITEM_OPENING_TYPES = [
  { code: 'G', name: 'Gold' },
  { code: 'S', name: 'Silver' },
  { code: 'D', name: 'Diamond' },
  { code: 'R', name: 'Real Stone' },
  { code: 'E', name: 'Emitation' },
  { code: 'O', name: 'Other' },
  { code: 'P', name: 'Platinum' },
] as const;

export type ItemOpeningTypeCode = (typeof ITEM_OPENING_TYPES)[number]['code'];

export function isItemOpeningType(value: unknown): value is ItemOpeningTypeCode {
  return ITEM_OPENING_TYPES.some((type) => type.code === value);
}

/** One grid row as typed: numbers or the text in the cell. */
export interface ItemOpeningRowInput {
  /** The item's ITEM_MAST.RATE_TYPE ('P' prices by the piece). */
  rateType?: string | null;
  pcs?: number | string | null;
  grossWt?: number | string | null;
  netWt?: number | string | null;
  touch?: number | string | null;
  westPct?: number | string | null;
  rate?: number | string | null;
  amount?: number | string | null;
  lbrType?: string | null;
  lbrRate?: number | string | null;
  lbrAmt?: number | string | null;
  othAmt?: number | string | null;
}

export interface ItemOpeningRow {
  pcs: number;
  grossWt: number;
  netWt: number;
  touch: number;
  westPct: number;
  fineWt: number;
  rate: number;
  amount: number;
  lbrType: string;
  lbrRate: number;
  lbrAmt: number;
  othAmt: number;
  netAmt: number;
}

const value = (input: unknown): number => {
  const parsed = typeof input === 'number' ? input : Number(String(input ?? '').trim() || 0);
  return Number.isFinite(parsed) ? parsed : 0;
};
const letter = (input: unknown): string =>
  String(input ?? '')
    .trim()
    .slice(0, 1)
    .toUpperCase();

/**
 * The row as TR_ITM_OPBL's CommPassTotal leaves it (TR_ITM_OPBL.cs:942-993). Each cell is first held in the format the
 * grid stores it in (MSG_LeaveCell, :887-925: pieces whole, weights to 3 places, the rest to 2), then:
 * - a blank net weight takes the gross weight;
 * - fine = net × (touch + wastage) / 100 when touch and net are set, else the net weight;
 * - item amount = pieces × rate for a piece-rated item without fine, else fine × rate when both are set, else as typed;
 * - labour, when a labour rate is set, by its type (P pieces, N net, K net per 1000, G gross, otherwise net) and
 *   rounded with .NET Math.Round (half to even) to whole rupees, else as typed;
 * - net amount = item amount + labour + other amount.
 */
export function itemOpeningRow(input: ItemOpeningRowInput): ItemOpeningRow {
  const pcs = round(value(input.pcs), 0);
  const grossWt = round(value(input.grossWt), 3);
  const typedNet = round(value(input.netWt), 3);
  const netWt = typedNet === 0 ? grossWt : typedNet;
  const touch = round(value(input.touch), 2);
  const westPct = round(value(input.westPct), 2);
  const fineWt = round(fineFor('itemOpening', { netWt, touch, westPct }), 3);
  const rate = round(value(input.rate), 2);
  let amount = round(value(input.amount), 2);
  if (letter(input.rateType) === 'P' && fineWt === 0 && pcs !== 0) amount = round(pcs * rate, 2);
  else if (rate !== 0 && fineWt !== 0) amount = round(fineWt * rate, 2);
  const lbrType = letter(input.lbrType);
  const lbrRate = round(value(input.lbrRate), 2);
  let lbrAmt = round(value(input.lbrAmt), 2);
  if (lbrRate !== 0) {
    const base =
      lbrType === 'P'
        ? pcs * lbrRate
        : lbrType === 'K'
          ? netWt * (lbrRate / 1000)
          : lbrType === 'G'
            ? grossWt * lbrRate
            : netWt * lbrRate;
    lbrAmt = roundHalfEven(base, 0);
  }
  const othAmt = round(value(input.othAmt), 2);
  const netAmt = round(amount + lbrAmt + othAmt, 2);
  return {
    pcs,
    grossWt,
    netWt,
    touch,
    westPct,
    fineWt,
    rate,
    amount,
    lbrType,
    lbrRate,
    lbrAmt,
    othAmt,
    netAmt,
  };
}

/** A row the desktop saves: BtnSave keeps rows whose gross weight plus pieces is not zero (TR_ITM_OPBL.cs:1420). */
export function itemOpeningRowSaved(row: Pick<ItemOpeningRow, 'grossWt' | 'pcs'>): boolean {
  return row.grossWt + row.pcs !== 0;
}

/** The grid's total line (MSG_TOT_FILL, TR_ITM_OPBL.cs:995-1026): pieces, gross, net, fine, item amount, net amount. */
export function itemOpeningTotals(rows: ItemOpeningRow[]) {
  const sum = (pick: (row: ItemOpeningRow) => number, dp: number) =>
    round(
      rows.reduce((total, row) => total + pick(row), 0),
      dp,
    );
  return {
    pcs: sum((row) => row.pcs, 0),
    grossWt: sum((row) => row.grossWt, 3),
    netWt: sum((row) => row.netWt, 3),
    fineWt: sum((row) => row.fineWt, 3),
    amount: sum((row) => row.amount, 2),
    netAmt: sum((row) => row.netAmt, 2),
  };
}
