'use client';

import {
  effectiveSaleRateWith,
  fineFor,
  labourCharge,
  percentageLabourRate,
  round,
  saleAmountBasis,
  saleItemAmount,
  saleItemAmountRounded,
  saleLineLabourAmount,
  PRECISION,
  applySaleGridEdit,
  computeSaleLine,
} from '@datacare/core';
import type { FineWorkflow, RoundingPolicy, SaleGridLabourCells } from '@datacare/core';

/** The exchange-row valuation the sale screens preview (G83); re-exported so a page needs one import. */
export { oldGoldRowAmount, type OldGoldCells } from './oldGoldRow';

/**
 * P5 — the per-cell recalculation kernel.
 *
 * WHY THIS EXISTS
 * The desktop recomputes a voucher line on every cell exit (`TR_SALE.cs:9400-9522`,
 * `MSG_LeaveCell` -> `CommPassTotal`), so the operator sees fine weight, amounts and the line total
 * update as they tab across. Roughly a quarter of the desktop's grid columns are these derived
 * roll-ups rather than entry cells, which is why they cannot be closed by wiring inputs: they have
 * to be COMPUTED and shown.
 *
 * WHY IT IMPORTS FROM @datacare/core INSTEAD OF REIMPLEMENTING
 * A second copy of the arithmetic would drift from the server's, and the difference would surface as
 * a voucher whose on-screen total is not the total that posts. Every figure here therefore comes from
 * the same `metalAmount` / `labourCharge` / `fineWeight` / `round` the API uses, including the
 * rounding kernel — WP-06 established that local helpers round negative midpoints wrongly, so
 * nothing here is allowed to do its own arithmetic on money or weight.
 *
 * The client result is a PREVIEW. The server stays authoritative and recomputes on save; this exists
 * so the operator is not typing blind, not to replace validation.
 */

/** The subset of a line the recalculation reads. Blank strings are treated as absent, never as 0. */
export interface RecalcLine {
  grossWt?: string | number;
  lessWt?: string | number;
  ghtWt?: string | number;
  ghtPct?: string | number;
  netWt?: string | number;
  touch?: string | number;
  westPct?: string | number;
  fineWt?: string | number;
  rate?: string | number;
  rateWith?: string;
  /** The item's RATE_TYPE: G (gram, default), 1 (per 10 g), K (per kg) or P (pieces). */
  rateType?: string;
  pcs?: string | number;
  labourType?: string;
  labourRate?: string | number;
  labourPct?: string | number;
  labourFixed?: string | number;
  otherAmount?: string | number;
  discountPct?: string | number;
  discountAmount?: string | number;
  ghatAmount?: string | number;
  /** Needed by the karigarIssue policy, which subtracts it from the fine. */
  lesWt?: string | number;
  /** Needed by purchaseOldGold and wholesaleSaleReturn, which subtract it from touch + wastage. */
  lesTouch?: string | number;
  /** Needed by purchaseOldGold, which adds it to the fine. */
  kunFine?: string | number;
}

export interface RecalcResult {
  netWt: number;
  ghtWt: number;
  fineWt: number;
  metalAmount: number;
  labourAmount: number;
  /** LBR_RATE derived from LBR_PRC on a percentage line (TR_SALE.cs:11021); undefined otherwise. */
  labourRate?: number;
  netLabourAmount: number;
  otherAmount: number;
  totalAmount: number;
}

/**
 * Which desktop fine policy this form follows.
 *
 * This is the SERVER'S OWN workflow union, not a local approximation. The first version of this file
 * defined its own two-value policy and got `sale` wrong twice: it dropped ghat from the base and lost
 * the `pct === 0 -> net + ght` fallback. A live sale return exposed it, posting ITM_FINE 5.065 where
 * this file predicted 4.605. There are TWELVE distinct policies in the desktop, each with its own
 * citation (finePolicy.ts, now in @datacare/core) — e.g. karigarIssue subtracts lesWt, karigarReceipt
 * is net-only, itemOpening ignores ghat entirely, purchaseOldGold subtracts lesTouch and adds kunFine.
 * Reimplementing any of them here would reintroduce exactly the drift this kernel exists to prevent.
 */
export type RecalcPolicy = FineWorkflow;

const n = (v: string | number | undefined): number => {
  if (v === undefined || v === null) return 0;
  const s = String(v).trim();
  if (s === '') return 0;
  const parsed = Number(s);
  return Number.isFinite(parsed) ? parsed : 0;
};

/** True when the operator has actually supplied the cell, as opposed to leaving it blank. */
const supplied = (v: string | number | undefined): boolean =>
  v !== undefined && v !== null && String(v).trim() !== '';
const labourTypeIsPct = (line: { labourType?: string }): boolean =>
  ['%', 'A'].includes(String(line.labourType ?? '').toUpperCase());

const LABOUR_TYPES: Record<string, 'per_gram' | 'per_piece' | 'percentage' | 'fixed'> = {
  G: 'per_gram',
  P: 'per_piece',
  '%': 'percentage',
  A: 'percentage',
  F: 'fixed',
};

/**
 * Recompute the derived cells of one line.
 *
 * `labourIncludesGhat` mirrors the company's `LBR_WITH_GHT`, whose desktop blank default is 'Y'
 * (`MS_OPNCOMP.cs`); defaulting it false here would understate per-gram labour on any line carrying
 * ghat weight, which is the defect this project already fixed once on the server side.
 *
 * `saleAmountType` is the company's `CO_SET.SL_AMT_TYPE`. A line with no RtWith of its own takes it
 * (TR_SALE.cs:9161), and blank means N (MS_OPNCOMP.cs:881-884).
 *
 * `roundingPolicy`, when given, makes the item and labour amounts the ones the API posts (`computeLine`): the item
 * rate rounded by ITM_RATE_ROF, ITM_AMT and LBR_AMT each rounded once at the Sale line precision (0, or 2 under
 * ALL_ROF_REMOVE: TR_SALE.cs:10343-10362), and a percentage's derived rate by LBR_ROF (:11021).
 *
 * `labourBasis` is the line's LBR_TYPE, the basis a percentage line's derived rate multiplies: a new Sale row takes
 * the company's CO_SET.LBR_TYPE (TR_SALE.cs:9135).
 */
export function recalcLine(
  line: RecalcLine,
  policy: RecalcPolicy = 'sale',
  options: {
    labourIncludesGhat?: boolean;
    saleAmountType?: string;
    roundingPolicy?: RoundingPolicy;
    labourBasis?: string;
  } = {},
): RecalcResult {
  const gross = n(line.grossWt);
  const less = n(line.lessWt);

  const netWt = supplied(line.netWt) ? n(line.netWt) : round(gross - less, PRECISION.weight);

  // Ghat weight is derived from its percentage unless the operator typed a weight directly, which is
  // the desktop's precedence: the explicit cell wins over the percentage.
  //
  // On the Sale grid the percentage is of NET weight: TR_SALE.cs:10581 writes
  // `ITM_GHT_WT = Format(ITM_NWT x ITM_GHT_PRC / 100, "0.000")`. The desktop oracle (run 42580947381, vector
  // ghat.pct1) gives 0.101 for gross 10.555, less 0.500 and 1 %; the gross basis previewed 0.106. Other forms keep
  // the gross basis until their own desktop rule is checked.
  const ghtPct = n(line.ghtPct);
  const ghtBase = policy === 'sale' ? netWt : gross;
  const ghtWt = supplied(line.ghtWt)
    ? n(line.ghtWt)
    : ghtPct > 0
      ? round((ghtBase * ghtPct) / 100, PRECISION.weight)
      : 0;

  // Fine comes from the server's own policy table, so the preview cannot disagree with the posting.
  const fine = supplied(line.fineWt)
    ? n(line.fineWt)
    : fineFor(policy, {
        netWt,
        ghtWt,
        touch: n(line.touch),
        westPct: n(line.westPct),
        lesWt: n(line.lesWt),
        lesTouch: n(line.lesTouch),
        kunFine: n(line.kunFine),
      });

  // The quantity the rate multiplies comes from the server's own `saleAmountBasis`
  // (TR_SALE.cs CommPassTotal 10716-10936). The inputs are the line's RtWith (else the company type)
  // and the item RATE_TYPE.
  //
  // This used to price 'F' on fine and everything else on net WITHOUT ghat, defaulting to F. So a blank
  // line on a blank company previewed on net while the server saved on fine, and G, P, ghat and
  // RATE_TYPE were ignored.
  const basis = saleAmountBasis(
    { pcs: n(line.pcs), grossWt: gross, netWt, ghtWt, fineWt: fine },
    effectiveSaleRateWith(line.rateWith, options.saleAmountType),
    line.rateType,
  );
  const rounding = options.roundingPolicy;
  const itemRate = rounding ? rounding.roundItemRate(n(line.rate)) : n(line.rate);
  const metal = rounding
    ? saleItemAmountRounded(basis, itemRate, rounding)
    : saleItemAmount(basis, itemRate);

  const labourType = LABOUR_TYPES[(line.labourType ?? 'G').toUpperCase()] ?? 'per_gram';
  const labourInput = {
    netWt,
    grossWt: gross,
    ghatWt: ghtWt,
    withGhat: options.labourIncludesGhat !== false,
    pcs: n(line.pcs),
    // A blank rate on a percentage row is derived from LBR_PRC; a typed one stands (TR_SALE.cs:10999).
    rate: supplied(line.labourRate) ? n(line.labourRate) : labourTypeIsPct(line) ? undefined : 0,
    pct: n(line.labourPct),
    // A percentage derives LBR_RATE from the ITEM RATE and multiplies the LBR_TYPE basis (TR_SALE.cs:11021,
    // :11084-11127), as the API's computeLine does; it is not a percentage of the item amount.
    itemRate,
    basis: options.labourBasis,
    fixed: n(line.labourFixed),
  };
  const labour = rounding
    ? saleLineLabourAmount(labourType, labourInput, rounding)
    : labourCharge(labourType, labourInput);
  const labourRate =
    labourType === 'percentage'
      ? (labourInput.rate ?? percentageLabourRate(itemRate, labourInput.pct, rounding))
      : undefined;

  // Net labour subtracts the line discount, by percentage or by amount (`TR_SALE.cs:11209`).
  const discount = supplied(line.discountAmount)
    ? n(line.discountAmount)
    : round((labour * n(line.discountPct)) / 100, PRECISION.amount);
  const netLabour = round(labour - discount, PRECISION.amount);

  const other = n(line.otherAmount);
  const ghatAmount = n(line.ghatAmount);
  const total = round(metal + netLabour + other + ghatAmount, PRECISION.amount);

  return {
    netWt,
    ghtWt,
    fineWt: fine,
    metalAmount: metal,
    labourAmount: labour,
    labourRate,
    netLabourAmount: netLabour,
    otherAmount: other,
    totalAmount: total,
  };
}

/**
 * The labour mode a Sale grid row posts, from its Lbr% and Making/g cells.
 *
 * TR_SALE.cs:10996-11021: when LBR_PRC is non-zero (and changed) and the row has an item rate, CommPassTotal derives
 * LBR_RATE from it, overwriting a typed rate; with no item rate it leaves the typed rate alone. So a row with both a
 * percentage and a rate is a percentage line, and otherwise a typed Making/g is a per-gram (net-weight) rate.
 */
export function saleLineLabourMode(cells: {
  lbrPct?: string | number;
  rate?: string | number;
  making?: string | number;
}): 'percentage' | 'per_gram' | undefined {
  if (n(cells.lbrPct) !== 0 && n(cells.rate) !== 0) return 'percentage';
  return supplied(cells.making) && n(cells.making) !== 0 ? 'per_gram' : undefined;
}

/** A Sale or Sales Quotation grid row: its Making/g and Lbr% cells besides the recalculation fields. */
export interface SaleGridRow extends Omit<RecalcLine, 'labourType' | 'labourRate' | 'labourPct'> {
  making?: string;
  lbrPct?: string;
  /** Column 83, the LBR_PRC the Making/g rate came from (`applySaleGridEdit`). */
  lbrPctApplied?: string;
  /** A typed ITM_AMT (detail panel). */
  metalAmount?: string;
}

/**
 * The preview of a Sale / Sales Quotation grid row: weights and fine from `recalcLine`, and the item amount, labour
 * rate and labour from core `computeSaleLine`, the ONE Sale line function the API's computeLine posts with (IEEE
 * double, .NET Math.Round, "0.00" cells; TR_SALE.cs CommPassTotal). A Lbr% row multiplies `options.labourBasis`, the
 * company LBR_TYPE a new row takes (:9135); a Making/g row without Lbr% is the per-gram N basis the API posts.
 */
export function recalcSaleGridRow(
  row: SaleGridRow,
  options: Parameters<typeof recalcLine>[2] = {},
): RecalcResult {
  const percentage = saleLineLabourMode(row) === 'percentage';
  const r = recalcLine({ ...row, labourRate: row.making, labourType: 'G' }, 'sale', options);
  const policy = options.roundingPolicy;
  const typedMaking = supplied(row.making) ? n(row.making) : null;
  const line = computeSaleLine(
    {
      pcs: n(row.pcs),
      grossWt: n(row.grossWt),
      netWt: r.netWt,
      ghtWt: r.ghtWt,
      fineWt: r.fineWt,
      rateWith: effectiveSaleRateWith(row.rateWith, options.saleAmountType),
      rateType: row.rateType,
      itemRate: policy ? policy.roundItemRate(n(row.rate)) : n(row.rate),
      itemAmount: supplied(row.metalAmount) && n(row.metalAmount) !== 0 ? n(row.metalAmount) : null,
      labourMode: percentage ? 'percentage' : typedMaking ? 'rate' : 'none',
      labourBasis: percentage ? (options.labourBasis ?? '') : 'N',
      labourPct: n(row.lbrPct),
      labourRate: percentage ? typedMaking : (typedMaking ?? 0),
      otherAmount: n(row.otherAmount),
    },
    {
      labourRateDecimals: policy?.labourDecimals ?? 2,
      allRoundingRemoved: policy?.allRoundingRemoved === true,
      labourWithGhat: options.labourIncludesGhat !== false,
    },
  );
  const discount = supplied(row.discountAmount)
    ? n(row.discountAmount)
    : round((line.labourAmount * n(row.discountPct)) / 100, PRECISION.amount);
  const netLabour = round(line.labourAmount - discount, PRECISION.amount);
  const total = round(
    line.itemAmount + netLabour + r.otherAmount + n(row.ghatAmount),
    PRECISION.amount,
  );
  return {
    ...r,
    metalAmount: line.itemAmount,
    labourAmount: line.labourAmount,
    labourRate: line.labourRate,
    netLabourAmount: netLabour,
    totalAmount: total,
  };
}

/**
 * The labour fields a Sale / Sales Quotation row posts. A Lbr% row posts `percentage` with its Making/g cell, which is
 * LBR_RATE as the grid holds it (derived when Lbr% was applied, or typed after it, or restored on reopen); the server
 * derives the rate only when the cell is blank (TR_SALE.cs:10999-11021). Otherwise Making/g is a per-gram rate, and a
 * row loaded with another labour type keeps it.
 */
export function saleGridRowLabour(row: {
  making?: string;
  lbrPct?: string;
  rate?: string;
  labourType?: 'per_gram' | 'per_piece' | 'percentage' | 'fixed';
  labourRate?: number;
  labourFixed?: number;
}): {
  labourType?: 'per_gram' | 'per_piece' | 'percentage' | 'fixed';
  labourRate?: number;
  labourFixed?: number;
} {
  if (saleLineLabourMode(row) === 'percentage') {
    return supplied(row.making)
      ? { labourType: 'percentage', labourRate: n(row.making) }
      : { labourType: 'percentage' };
  }
  if (row.making) return { labourType: 'per_gram', labourRate: n(row.making) };
  if (row.labourType) {
    return { labourType: row.labourType, labourRate: row.labourRate, labourFixed: row.labourFixed };
  }
  return {};
}

/** One cell edit of a Sale / Sales Quotation row in the desktop's event order (core `applySaleGridEdit`). */
export function editSaleGridRow<T extends SaleGridLabourCells>(
  row: T,
  key: keyof T,
  value: string,
  policy?: RoundingPolicy,
): T {
  return applySaleGridEdit(row, key, value, policy?.labourDecimals ?? 2, (v) =>
    policy ? policy.roundItemRate(v) : v,
  );
}
