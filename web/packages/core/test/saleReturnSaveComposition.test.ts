import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it } from 'vitest';
import { replaySaleReturnOtherAmount } from '../src/saleReturnOtherAmountReplay.js';
import { projectSavedSaleReturnEffectContext } from '../src/saleReturnEffectContext.js';
import { planSaleReturnFinancialEffects } from '../src/saleReturnFinancialEffects.js';
import { matchSaleReturnNBarCompanions } from '../src/saleReturnNBarCompanions.js';
import { evaluateSavedSaleReturnSaveGuards } from '../src/saleReturnSaveGuards.js';

const bytes = readFileSync(
  new URL('./fixtures/saleReturnSaveComposition.independent.json', import.meta.url),
);
const fixture = JSON.parse(bytes.toString());
const sample = () => structuredClone(fixture);
function calculate(x: any, events = ['1']) {
  const replay = replaySaleReturnOtherAmount({ ...x.replayInput, events });
  expect(replay.status, JSON.stringify(replay.diagnostics)).toBe('ready');
  if (!replay.candidate || !replay.opened || !replay.final || !replay.saveFold)
    throw new Error('Shared literal refused calculation');
  const storage = projectSavedSaleReturnEffectContext(x.storageInput);
  expect(storage.status).toBe('ready');
  if (storage.status !== 'ready') throw new Error('Shared literal refused storage context');
  const financialInput = {
    ...x.financial,
    context: { ...x.financial.context, storage: storage.storage },
    after: { incoming: replay.candidate.afterIncoming, header: replay.candidate.afterHeader },
  };
  const financial = planSaleReturnFinancialEffects(financialInput);
  const barInput = {
    ...x.bar,
    before: {
      visible: replay.opened.row.visible,
      incomingTotals: replay.opened.incomingTotals.cells,
    },
    after: { visible: replay.final.row.visible, incomingTotals: replay.saveFold.cells },
  };
  const bar = matchSaleReturnNBarCompanions(barInput);
  const guardInput = structuredClone(x.guardInput);
  guardInput.observations.beforeBill.value.matrix = replay.opened.bill.matrix;
  guardInput.observations.bill.value = {
    phase: 'post-events-before-save-fold',
    nAcCrAmt: replay.final.bill.incomingRounded,
    nAcDrAmt: replay.final.bill.outgoingRounded,
    matrix: replay.final.bill.matrix,
  };
  guardInput.observations.saveFold.value = {
    phase: 'save-fold-outgoing-then-incoming-no-bill',
    upDown: false,
    incomingFine18: replay.saveFold.cells[18],
    incomingNet38: replay.saveFold.cells[38],
    outgoingTotal24: '0.00',
  };
  const guards = evaluateSavedSaleReturnSaveGuards(guardInput);
  return { replay, storage, financial, bar, guards, guardInput, barInput };
}
describe('one supplied saved Return fixture across the separate pure Save prerequisites', () => {
  it('pins the independently frozen joint fixture and its complete financial target denominator', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '1707748615eed0f437e6d129abf0257187950b821173a860440eefeed7230883',
    );
    expect(
      Object.values(fixture.expectedFinancial.before).reduce(
        (n: number, raw) => n + Object.keys(raw as object).length,
        0,
      ),
    ).toBe(221);
    expect(
      Object.values(fixture.expectedFinancial.after).reduce(
        (n: number, raw) => n + Object.keys(raw as object).length,
        0,
      ),
    ).toBe(221);
  });
  it('hydrates and replays Other1, matches N companions and all221 financial fields, and satisfies the supplied fine10 guard facts', () => {
    const x = sample(),
      before = structuredClone(x),
      r = calculate(x);
    expect(r.storage.storage).toStrictEqual(x.expectedStorage);
    expect(r.financial.status, JSON.stringify(r.financial.diagnostics)).toBe('ready');
    expect(r.financial.before).toStrictEqual(x.expectedFinancial.before);
    expect(r.financial.after).toStrictEqual(x.expectedFinancial.after);
    expect(
      Object.fromEntries(r.financial.candidatePlan!.map((p) => [p.role, p.patch])),
    ).toStrictEqual(x.expectedFinancial.patches);
    expect(r.financial.candidatePlan).toHaveLength(7);
    for (const p of r.financial.candidatePlan!)
      expect(p.candidateRaw).toStrictEqual({ ...p.raw, ...p.patch });
    expect(r.bar.status, JSON.stringify(r.bar.diagnostics)).toBe('matched');
    expect(r.bar.observed).toStrictEqual(x.bar.observed);
    expect(r.guards.status, JSON.stringify(r.guards.diagnostic)).toBe('ready');
    expect(r.guardInput).toStrictEqual(x.guardInput);
    for (const v of [r.replay, r.storage, r.financial, r.bar, r.guards])
      expect(v.canCommit).toBe(false);
    expect(x).toStrictEqual(before);
  });
  it('keeps row110.49 separate from whole-unit header110 across accounting, stock, Rojmel and tax', () => {
    const x = sample(),
      r = calculate(x, ['0.49']);
    expect(r.replay.candidate!.afterIncoming.NET_AMT).toBe('110.49');
    expect(r.replay.candidate!.afterHeader.RTN_NET_AMT).toBe('110');
    expect(r.financial.status, JSON.stringify(r.financial.diagnostics)).toBe('ready');
    expect(r.financial.before).toStrictEqual(x.expectedFractionalFinancial.before);
    expect(r.financial.after).toStrictEqual(x.expectedFractionalFinancial.after);
    expect(
      Object.fromEntries(r.financial.candidatePlan!.map((p) => [p.role, p.patch])),
    ).toStrictEqual(x.expectedFractionalFinancial.patches);
    expect(r.bar.status).toBe('matched');
    expect(r.guards.status).toBe('ready');
  });
  it('retains every event while empty, same-value and round-trip journals leave all nine numeric target rows unchanged', () => {
    for (const events of [[], ['0'], ['1', '0']]) {
      const r = calculate(sample(), events);
      expect(r.replay.final!.row.journal).toHaveLength(events.length);
      expect(r.replay.candidate!.hasLineOrHeaderChanges).toBe(false);
      expect(r.financial.status).toBe('ready');
      for (const p of r.financial.candidatePlan!) {
        expect(p.patch).toEqual({});
        expect(p.candidateRaw).toStrictEqual(p.raw);
      }
      expect(r.bar.status).toBe('matched');
      expect(r.guards.status).toBe('ready');
    }
  });
  it('does not treat ready financial projections as proof of a mismatched BAR companion', () => {
    const x = sample();
    x.bar.observed.barDetl[0].raw.TAG_COST = '1.00';
    const r = calculate(x);
    expect(r.financial.status).toBe('ready');
    expect(r.bar.status).toBe('unsupported');
    expect(r.bar.canCommit).toBe(false);
  });
  it('keeps unresolved edition authority visible even when calculations and effect projections qualify', () => {
    const x = sample();
    x.guardInput.observations.edition = {
      status: 'unavailable',
      revision: 'missing-provider',
      reason: 'No trusted edition source.',
    };
    const r = calculate(x);
    expect(r.financial.status).toBe('ready');
    expect(r.guards.status).toBe('unsupported');
    expect(r.guards.canCommit).toBe(false);
  });
});
