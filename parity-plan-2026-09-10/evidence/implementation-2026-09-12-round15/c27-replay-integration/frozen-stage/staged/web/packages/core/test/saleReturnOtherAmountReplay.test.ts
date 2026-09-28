import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, it, expect } from 'vitest';
import { replaySaleReturnOtherAmount } from '../src/saleReturnOtherAmountReplay.js';

const bytes = readFileSync(new URL('./fixtures/saleReturnOtherAmountReplay.independent.json', import.meta.url));
const fixture = JSON.parse(bytes.toString()) as { cases: Array<{ id: string; input: any; expected: any }> };
const sample = () => structuredClone(fixture.cases[1]!.input);
function frozen(x: unknown): void {
  if (x && typeof x === 'object') { expect(Object.isFrozen(x)).toBe(true); Object.values(x).forEach(frozen); }
}
describe('saved c27 complete hydration, ordered replay and Save fold', () => {
  it('pins 16 full literal phase expectations authored before implementation', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe('928fb13f279c70eba0401fa4c7115bc1cfed5a8070a75f3b28e4e4ee2c823d28');
    expect(fixture.cases).toHaveLength(16);
  });
  for (const vector of fixture.cases) it(vector.id, () => {
    const input = structuredClone(vector.input), before = structuredClone(input);
    const r = replaySaleReturnOtherAmount(input), e = vector.expected;
    expect(r.status).toBe(e.status);
    expect(r.loaded).toStrictEqual(e.loaded);
    expect(r.opened).toStrictEqual(e.opened);
    expect(r.prefixes).toStrictEqual(e.prefixes);
    expect(r.final).toStrictEqual(e.final);
    expect(r.canCommit).toBe(false);
    expect(r.observation).toStrictEqual(input);
    expect(r.observation).not.toBe(input);
    expect(input).toStrictEqual(before);
    expect(Object.isFrozen(input)).toBe(false);
    frozen(r);
    if (r.status === 'ready') {
      expect(r.diagnostics).toEqual([]);
      expect(r.candidate!.linePatch).toStrictEqual(e.linePatch);
      expect(r.candidate!.headerPatch).toStrictEqual(e.headerPatch);
      expect(r.candidate!.afterIncoming).toStrictEqual({ ...input.rawIncoming, ...e.linePatch });
      expect(r.candidate!.afterHeader).toStrictEqual({ ...input.rawHeader, ...e.headerPatch });
      expect(r.candidate!.hasLineOrHeaderChanges).toBe(Object.keys(e.linePatch).length + Object.keys(e.headerPatch).length > 0);
      expect(r.saveFold).toStrictEqual(e.final.incomingTotals);
      expect(r.final!.bill).toBe(r.prefixes.at(-1)?.bill ?? r.opened!.bill);
    } else { expect(r.candidate).toBeNull(); expect(r.diagnostics[0]!.code).toBe(e.code); }
  });
  it('preserves original editor text and every same-value event', () => {
    const r = replaySaleReturnOtherAmount({ ...sample(), events: ['0', '0.00', ' 0 '] });
    expect(r.status).toBe('ready');
    expect(r.prefixes).toHaveLength(3);
    expect(r.final!.row.journal.map(j => j.event.kind === 'leaveCell' && j.event.text)).toEqual(['0','0.00',' 0 ']);
    expect(r.candidate!.hasLineOrHeaderChanges).toBe(false);
  });
  it('stops at the first unsupported prefix even if a later value could restore the final amount', () => {
    const r = replaySaleReturnOtherAmount({ ...sample(), events: ['1','-11','2'] });
    expect(r.status).toBe('unsupported');expect(r.prefixes).toHaveLength(2);
    expect(r.diagnostics[0]).toMatchObject({ code: 'bar-header-membership', eventIndex: 1 });
    expect(r.final!.row.visible[27]).toBe('-11.00');
  });
  it('does not apply an invalid event or later events to the retained successful prefix', () => {
    const r = replaySaleReturnOtherAmount({ ...sample(), events: ['1','oops','2'] });
    expect(r.diagnostics[0]).toMatchObject({ code: 'event-calculation', eventIndex: 1 });
    expect(r.prefixes).toHaveLength(1);expect(r.final!.row.visible[27]).toBe('1.00');
  });
  const mutations: Array<[string,(x: any) => void,string]> = [
    ['extra request field', x => x.canCommit = true, 'invalid-input'],
    ['client phase injection', x => x.baseline = {}, 'invalid-input'],
    ['missing scope', x => delete x.rawIncoming.CO_YEAR, 'scope-conflict'],
    ['cross account', x => x.rawIncoming.AC_CODE = 'OTHER', 'scope-conflict'],
    ['old Y override', x => x.rawHeader.USER_UPDATE = 'Y', 'unsupported-profile'],
    ['tagged row', x => x.rawIncoming.TAG_NO = 'TAG1', 'unsupported-profile'],
    ['old serial mapping', x => x.rawIncoming.OLD_SRNO = '31', 'unsupported-profile'],
    ['missing projection raw', x => delete x.rawIncoming.DESIGN_NO, 'saved-row-projection'],
    ['item ambiguity', x => x.itemMasters.push({ ...x.itemMasters[0] }), 'saved-row-projection'],
    ['received amount', x => x.rawHeader.NET_AMT = '1', 'unsupported-header-profile'],
    ['received NULL', x => x.rawHeader.NET_AMT = null, 'unsupported-decimal'],
    ['nonzero header tender', x => x.rawHeader.RTN_CASH_AMT = '1', 'unsupported-header-profile'],
    ['unrepresentable old Float', x => x.rawHeader.RTN_BILL_OS = '110.1', 'header-storage'],
    ['saved-open drift', x => x.rawHeader.RTN_BILL_OS = '109', 'saved-open-drift'],
    ['hidden c27', x => x.c27ColumnWidth = 0, 'unsupported-policy'],
    ['missing policy', x => delete x.rowPolicy.fineColumnWidth, 'invalid-input'],
    ['fractional policy', x => x.taxRoundingDecimals = 1.5, 'invalid-input'],
    ['overlong input', x => x.events = ['12345678901'], 'invalid-input'],
    ['Unicode input', x => x.events = ['૧'], 'invalid-input'],
    ['oversized journal', x => x.events = Array(101).fill('0'), 'invalid-input'],
    ['unowned recalculation', x => { x.rawIncoming.ITM_AMT='101';x.rawIncoming.TOT_AMT='111';x.rawIncoming.NET_AMT='111';x.rawHeader.RTN_NET_AMT='111';x.rawHeader.RTN_TOT_AMT='111';x.rawHeader.RTN_BILL_OS='111'; }, 'row-save-projection'],
  ];
  for (const [name, mutate, code] of mutations) it(name, () => {
    const x=sample();mutate(x);const r=replaySaleReturnOtherAmount(x);
    expect(r.status).toBe('unsupported');expect(r.candidate).toBeNull();expect(r.canCommit).toBe(false);
    expect(r.diagnostics[0]!.code).toBe(code);frozen(r);
  });
  it('refuses getters without invoking them', () => {
    const x=sample();let calls=0;Object.defineProperty(x.rawIncoming,'NET_AMT',{enumerable:true,get(){calls++;return '110';}});
    expect(replaySaleReturnOtherAmount(x).diagnostics[0]!.code).toBe('invalid-input');expect(calls).toBe(0);
  });
  it('refuses sparse, decorated and inherited input shapes', () => {
    const sparse=sample();sparse.events=Array(1);
    const decorated=sample();decorated.events.extra='1';
    const inherited=Object.create(sample());
    for (const x of [sparse,decorated,inherited]) expect(replaySaleReturnOtherAmount(x).diagnostics[0]!.code).toBe('invalid-input');
  });
  it('detaches aliases and preserves opaque raw names and SQL text without prototype mutation', () => {
    const x=sample();Object.defineProperty(x.rawHeader,'__proto__',{value:'raw text',enumerable:true});
    const r=replaySaleReturnOtherAmount(x);expect(r.status).toBe('ready');
    x.rawHeader.AC_NAME='Changed later';x.events[0]='9';
    expect(r.candidate!.afterHeader.AC_NAME).toBe('Current customer');
    expect(Object.getOwnPropertyDescriptor(r.candidate!.afterHeader,'__proto__')!.value).toBe('raw text');
  });
});
