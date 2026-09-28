'use client';

import { fineFor, labourCharge, metalAmount, round, PRECISION } from '@datacare/core';
import type { FineWorkflow } from '@datacare/core';

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
 */
export function recalcLine(
  line: RecalcLine,
  policy: RecalcPolicy = 'sale',
  options: { labourIncludesGhat?: boolean } = {},
): RecalcResult {
  const gross = n(line.grossWt);
  const less = n(line.lessWt);

  // Ghat weight is derived from its percentage unless the operator typed a weight directly, which is
  // the desktop's precedence: the explicit cell wins over the percentage.
  const ghtPct = n(line.ghtPct);
  const ghtWt = supplied(line.ghtWt)
    ? n(line.ghtWt)
    : ghtPct > 0
      ? round((gross * ghtPct) / 100, PRECISION.weight)
      : 0;

  const netWt = supplied(line.netWt) ? n(line.netWt) : round(gross - less, PRECISION.weight);

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

  // The rate base follows RtWith: 'F' prices the fine weight, anything else prices the net weight
  // (`TR_SALE.cs:10827-10932`).
  const rateBase = (line.rateWith ?? 'F').toUpperCase() === 'F' ? fine : netWt;
  const metal = metalAmount(rateBase, n(line.rate));

  const labourType = LABOUR_TYPES[(line.labourType ?? 'G').toUpperCase()] ?? 'per_gram';
  const labour = labourCharge(labourType, {
    netWt,
    ghatWt: ghtWt,
    withGhat: options.labourIncludesGhat !== false,
    pcs: n(line.pcs),
    rate: n(line.labourRate),
    pct: n(line.labourPct),
    metalAmount: metal,
    fixed: n(line.labourFixed),
  });

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
    netLabourAmount: netLabour,
    otherAmount: other,
    totalAmount: total,
  };
}
