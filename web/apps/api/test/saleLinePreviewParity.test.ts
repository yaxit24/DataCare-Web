import { describe, expect, it } from 'vitest';
import { lineNet, resolveRoundingPolicy, type RoundingPolicy } from '@datacare/core';
import { computeLine, type SaleLineInput } from '../src/modules/sales/sales.js';
import { desktopLabourTypeFor } from '../src/modules/shared/labourDesktop.js';

// The page's own module, loaded by path: it lives in apps/web, outside this package's TypeScript root.
type Row = Record<string, string>;
interface WebLineRecalc {
  editSaleGridRow<T extends Row>(row: T, key: keyof T, value: string, policy: RoundingPolicy): T;
  recalcSaleGridRow(
    row: Row,
    options: Record<string, unknown>,
  ): { metalAmount: number; labourAmount: number; labourRate?: number; otherAmount: number };
  saleGridRowLabour(row: Row): Pick<SaleLineInput, 'labourType' | 'labourRate' | 'labourFixed'>;
}
const WEB_LIB = new URL('../../web/lib/lineRecalc.ts', import.meta.url).href;
const { editSaleGridRow, recalcSaleGridRow, saleGridRowLabour } = (await import(
  /* @vite-ignore */ WEB_LIB
)) as WebLineRecalc;

/**
 * The Sale page preview and the API posting are ONE function (core computeSaleLine). Property check: 200 seeded random
 * grid rows, entered cell by cell through the page's edit handler, must preview exactly what computeLine posts for
 * the payload the page builds (item amount, labour rate, labour and line net).
 */
function prng(seed: number): () => number {
  let a = seed >>> 0;
  return () => {
    a = (a + 0x6d2b79f5) >>> 0;
    let t = a;
    t = Math.imul(t ^ (t >>> 15), t | 1);
    t ^= t + Math.imul(t ^ (t >>> 7), t | 61);
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}

describe('Sale preview = API posting (200 random rows)', () => {
  const rnd = prng(241);
  const pick = <T>(xs: readonly T[]): T => xs[Math.floor(rnd() * xs.length)]!;
  const fixed = (max: number, dp: number): string => (rnd() * max).toFixed(dp);
  const cases = Array.from({ length: 200 }, (_, i) => i);

  it.each(cases)('row %i', () => {
    const flags = {
      LBR_ROF: pick(['0', '2', '3']),
      ITM_RATE_ROF: '2',
      ALL_ROF_REMOVE: pick(['N', 'Y']),
    };
    const policy = resolveRoundingPolicy(flags);
    const companyBasis = pick(['', 'G', 'N', 'K', 'P']);
    const withGhat = rnd() < 0.7;
    const amountType = pick(['N', 'G', 'F', 'P']);
    const gross = fixed(60, 3);
    const net = (Number(gross) * (0.8 + rnd() * 0.2)).toFixed(3);
    let row = {
      pcs: String(1 + Math.floor(rnd() * 5)),
      grossWt: gross,
      netWt: net,
      touch: pick(['91.6', '75', '92.5', '99.5']),
      rateWith: pick(['', 'N', 'G', 'F', 'P']),
      rateType: pick(['', '', '1', 'K', 'P']),
      rate: '',
      making: '',
      lbrPct: '',
      lbrPctApplied: '',
      metalAmount: '',
      otherAmount: rnd() < 0.2 ? fixed(500, 2) : '',
    };
    // Cell by cell, in an order an operator may use: sometimes Lbr% before the rate, sometimes a typed Making/g after.
    const steps: [keyof typeof row, string][] = [];
    const rate = fixed(8000, 2);
    const pct = rnd() < 0.6 ? fixed(25, 2) : '';
    if (rnd() < 0.3) steps.push(['lbrPct', pct], ['rate', rate]);
    else steps.push(['rate', rate], ['lbrPct', pct]);
    if (rnd() < 0.3) steps.push(['making', fixed(900, pick([2, 3]))]);
    if (rnd() < 0.15) steps.push(['metalAmount', fixed(90000, 3)]);
    for (const [k, v] of steps) row = editSaleGridRow(row, k, v, policy);

    const preview = recalcSaleGridRow(row, {
      roundingPolicy: policy,
      labourBasis: companyBasis,
      labourIncludesGhat: withGhat,
      saleAmountType: amountType,
    });
    const labour = saleGridRowLabour(row);
    const n = (v: string): number | undefined => Number(v) || undefined;
    const payload: SaleLineInput = {
      itCode: 'X',
      pcs: Number(row.pcs),
      grossWt: Number(row.grossWt),
      netWt: Number(row.netWt),
      touch: Number(row.touch),
      rate: policy.roundItemRate(Number(row.rate)),
      rateWith: row.rateWith || undefined,
      rateType: row.rateType || undefined,
      labourPct: n(row.lbrPct),
      metalAmount: n(row.metalAmount),
      otherAmount: n(row.otherAmount),
      ...labour,
    };
    const posted = computeLine(payload, policy, amountType as 'N', withGhat, {
      basis: desktopLabourTypeFor(payload.labourType, companyBasis),
      rule: 'sale',
    });
    const previewNet = lineNet({
      metal: preview.metalAmount,
      labour: preview.labourAmount,
      other: preview.otherAmount,
    });
    expect({
      metal: preview.metalAmount,
      labour: preview.labourAmount,
      labourRate: preview.labourRate,
      net: previewNet,
    }).toEqual({
      metal: posted.metal,
      labour: posted.labour,
      labourRate: posted.labourRate,
      net: posted.net,
    });
  });
});
