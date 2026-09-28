import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { Decimal } from 'decimal.js';
import { describe, expect, it } from 'vitest';
import {
  copySaleReturnIncomingLabour,
  SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION,
  type SaleReturnIncomingLabourCopyInput,
} from '../src/saleReturnIncomingLabour.js';
import type { SaleReturnIncomingState } from '../src/saleReturnIncoming.js';

type Raw = Record<string, string | null>;
type Candidate = {
  id: string;
  field: 13 | 29;
  editorText: string;
  baselineOverrides?: Record<string, string>;
  masterRaw?: Raw;
  observedMasters?: Raw[];
  expect: { status: string; visiblePatch?: Record<string, string> };
};
const bytes = readFileSync(
  new URL('./fixtures/saleReturnIncomingLabour.independent.json', import.meta.url),
);
const fixture = JSON.parse(bytes.toString()) as {
  baseline: SaleReturnIncomingState;
  cases: Candidate[];
};
const scope = { tenantId: 'labour-copy-test', coCode: '01' };
const token = 'a'.repeat(64);
const master = {
  tenant_id: scope.tenantId,
  CO_CODE: '01',
  LBR_CODE: 'S1',
  LBR_CATG: '01 Rate',
  LBR_VAL: '12.5',
  MAIN_USER: null,
};
function input(candidate = fixture.cases[0]!): SaleReturnIncomingLabourCopyInput {
  const state = structuredClone(fixture.baseline);
  const raw = candidate.observedMasters ?? (candidate.masterRaw ? [candidate.masterRaw] : []);
  return {
    scope: { ...scope },
    rowIdentity: state.rowIdentity,
    state: { ...state, visible: { ...state.visible, ...candidate.baselineOverrides } },
    field: candidate.field,
    editorText: candidate.editorText,
    expectedObservationVersion: token,
    observation: {
      version: SALE_RETURN_INCOMING_LABOUR_OBSERVATION_VERSION,
      scope: { ...scope },
      enteredCode: candidate.editorText,
      complete: true,
      observationVersion: token,
      masters: raw.map((row, index) => ({
        raw: { tenant_id: scope.tenantId, ...row },
        revision: String(100 + index),
        locator: `(0,${index + 1})`,
      })),
    },
  };
}
function valueInput(value: string | null): SaleReturnIncomingLabourCopyInput {
  const previous = input();
  return {
    ...previous,
    observation: {
      ...previous.observation,
      masters: [{ raw: { ...master, LBR_VAL: value }, revision: '100', locator: '(0,1)' }],
    },
  };
}
function expectRefusal(value: unknown, code: string) {
  const result = copySaleReturnIncomingLabour(value);
  expect(result.status).toBe('unsupported');
  expect(result.visiblePatch).toBeNull();
  expect(result.nextEvent).toBeNull();
  expect(result.diagnostics).toEqual([expect.objectContaining({ code })]);
  expect(Object.isFrozen(result)).toBe(true);
  return result;
}

describe('primary incoming labour-code resolved copy, before any calculation', () => {
  it('pins all 24 literal cases authored before the new copy or reader implementation', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '17ad183d4f9f143202fcdedac515aa58616a1d552dac06e01634212d44e941aa',
    );
    expect(fixture.cases).toHaveLength(24);
  });
  it.each(fixture.cases)(
    '$id retains exact raw/cache/journal and follows the literal copy patch',
    (candidate) => {
      const value = input(candidate);
      const before = structuredClone(value);
      const result = copySaleReturnIncomingLabour(value);
      expect(result.status).toBe(candidate.expect.status);
      expect(value).toEqual(before);
      expect(Object.isFrozen(value.state)).toBe(false);
      expect(Object.isFrozen(result)).toBe(true);
      if (result.status === 'ready') {
        expect(result.visiblePatch).toEqual(candidate.expect.visiblePatch);
        expect(result.state).toEqual({
          ...before.state,
          visible: { ...before.state.visible, ...candidate.expect.visiblePatch },
        });
        expect(result.state).not.toBe(value.state);
        expect(result.state.raw).not.toBe(value.state.raw);
        expect(result.nextEvent).toEqual({
          kind: 'calculateAfterCopy',
          rowIdentity: value.rowIdentity,
          activeColumn: candidate.field,
          editorText: candidate.editorText,
          cause: candidate.field === 13 ? 'labourCodeSelection' : 'tagLabourCodeSelection',
        });
        expect(result.observation).toEqual(before.observation);
        expect(result.diagnostics).toEqual([]);
        expect(Object.isFrozen(result.state.visible)).toBe(true);
        expect(Object.isFrozen(result.state.caches)).toBe(true);
        expect(Object.isFrozen(result.state.raw)).toBe(true);
        expect(Object.isFrozen(result.state.journal)).toBe(true);
        expect(Object.isFrozen(result.nextEvent)).toBe(true);
      } else {
        expect(result.state).toEqual(before.state);
        expect(result.visiblePatch).toBeNull();
        expect(result.nextEvent).toBeNull();
        expect(result.diagnostics).toHaveLength(1);
      }
    },
  );
  it('preserves prior committed journal events, unresolved policy and raw NULL without appending a fabricated event', () => {
    const value = input();
    const journal = [
      {
        event: {
          kind: 'leaveCell' as const,
          rowIdentity: value.rowIdentity,
          column: 3,
          text: 'exact old text',
          context: {
            currentRow: 1,
            clearing: false,
            editorVisible: true,
            committedColumnWidth: 300,
          },
        },
        calculated: false,
        policy: {
          saleAmountType: 'F',
          labourRoundingDecimals: 2,
          labourIncludesGhat: false,
          generateLabourRate: false,
          fineColumnWidth: null,
        },
      },
    ];
    const prior = { ...value.state, journal };
    const result = copySaleReturnIncomingLabour({ ...value, state: prior });
    expect(result.status).toBe('ready');
    expect(result.state?.journal).toEqual(journal);
    expect(result.state?.journal).not.toBe(journal);
    expect(result.state?.raw.TAG_LBR_CODE).toBeNull();
    expect(Object.isFrozen(journal)).toBe(false);
  });
  it('does not treat a space-only existing tag code as the source exactly-blank fallback', () => {
    const value = input();
    const result = copySaleReturnIncomingLabour({
      ...value,
      state: { ...value.state, visible: { ...value.state.visible, 29: ' ' } },
    });
    expect(result.status).toBe('ready');
    expect(result.visiblePatch).not.toHaveProperty('29');
    expect(result.state?.visible[29]).toBe(' ');
  });
  it.each([
    '12\n',
    '12\r',
    '12\u2028',
    '\t12',
    '',
    ' ',
    '1e2',
    'NaN',
    'Infinity',
    '12x',
    '1,000',
    '0x10',
    '0.0000000000000000001',
    '1000000000000000000000000000000000000',
    '999999999999999999999999999999999999.01',
  ])('contains unqualified value %j before changing the row', (value) => {
    const previous = valueInput(value);
    const result = expectRefusal(previous, 'unsupported-labour-value');
    expect(result.state).toEqual(previous.state);
    expect(result.observation?.masters[0]?.raw.LBR_VAL).toBe(value);
  });
  it.each([
    [' +12.5 ', '12.50'],
    ['-.004', '-0.00'],
    ['12.505', '12.51'],
    ['-12.505', '-12.51'],
    ['.5', '0.50'],
  ])('declared mathematical Format2 profile %s → %s', (value, expected) => {
    const result = copySaleReturnIncomingLabour(valueInput(value!));
    expect(result.status).toBe('ready');
    expect(result.visiblePatch?.[23]).toBe(expected);
  });
  it('preserves large exact cents under ambient Decimal precision7 without altering that global setting', () => {
    const old = Decimal.precision;
    Decimal.set({ precision: 7 });
    try {
      const result = copySaleReturnIncomingLabour(valueInput('99999999999999999999999999.015'));
      expect(result.status).toBe('ready');
      expect(result.visiblePatch?.[23]).toBe('99999999999999999999999999.02');
      expect(Decimal.precision).toBe(7);
    } finally {
      Decimal.set({ precision: old });
    }
  });
  it.each([
    ['different-row', 'row-identity-conflict'],
    ['raw-company', 'row-identity-conflict'],
    ['raw-tenant', 'row-identity-conflict'],
    ['token', 'observation-conflict'],
    ['scope', 'observation-conflict'],
    ['code', 'observation-conflict'],
    ['incomplete', 'invalid-observation'],
    ['foreign-tenant-master', 'invalid-observation'],
  ])('refuses %s without a copy or callback', (kind, code) => {
    const value = input();
    let changed: unknown = value;
    if (kind === 'different-row') changed = { ...value, rowIdentity: 'another-row' };
    if (kind === 'raw-company')
      changed = { ...value, state: { ...value.state, raw: { ...value.state.raw, CO_CODE: '02' } } };
    if (kind === 'raw-tenant')
      changed = {
        ...value,
        state: { ...value.state, raw: { ...value.state.raw, tenant_id: 'other' } },
      };
    if (kind === 'token') changed = { ...value, expectedObservationVersion: 'b'.repeat(64) };
    if (kind === 'scope')
      changed = {
        ...value,
        observation: { ...value.observation, scope: { ...scope, coCode: '02' } },
      };
    if (kind === 'code')
      changed = { ...value, observation: { ...value.observation, enteredCode: 'S2' } };
    if (kind === 'incomplete')
      changed = { ...value, observation: { ...value.observation, complete: false } };
    if (kind === 'foreign-tenant-master')
      changed = {
        ...value,
        observation: {
          ...value.observation,
          masters: [{ ...value.observation.masters[0]!, raw: { ...master, tenant_id: 'other' } }],
        },
      };
    expectRefusal(changed, code!);
  });
  it.each(['S12', ' S', 'S ', 'S\n', 'é'])('refuses unqualified editor code %j', (editorText) => {
    expectRefusal({ ...input(), editorText }, 'unsupported-code');
  });
  it.each(['exact-duplicate', 'company-space', 'company-case', 'code-space'])(
    'contains relevant master %s',
    (kind) => {
      const value = input();
      const company = kind === 'company-case' ? 'A' : '01';
      const editor = kind === 'code-space' ? 'S' : 'S1';
      const raw = { ...master, CO_CODE: company, LBR_CODE: editor };
      const alias = {
        ...raw,
        ...(kind === 'company-space'
          ? { CO_CODE: '01 ' }
          : kind === 'company-case'
            ? { CO_CODE: 'a' }
            : kind === 'code-space'
              ? { LBR_CODE: 'S ' }
              : {}),
      };
      const changed = {
        ...value,
        scope: { ...scope, coCode: company },
        editorText: editor,
        observation: {
          ...value.observation,
          scope: { ...scope, coCode: company },
          enteredCode: editor,
          masters: [raw, alias].map((row, index) => ({
            raw: row,
            revision: String(100 + index),
            locator: `(0,${index + 1})`,
          })),
        },
      };
      expectRefusal(changed, 'ambiguous-labour-master');
    },
  );
  it('contains c29 category04 NULL as an explicit initial profile limit, not an invented source assignment', () => {
    const value = valueInput(null);
    expectRefusal(
      {
        ...value,
        field: 29,
        observation: {
          ...value.observation,
          masters: [
            {
              ...value.observation.masters[0]!,
              raw: { ...master, LBR_CATG: '04 Wastage', LBR_VAL: null },
            },
          ],
        },
      },
      'unsupported-labour-value',
    );
  });
  it('rejects a missing visible slot rather than inventing blank; no malformed prior state is published', () => {
    const value = input();
    const cells = { ...value.state.visible };
    delete cells[29];
    const result = expectRefusal(
      { ...value, state: { ...value.state, visible: cells } },
      'invalid-row-state',
    );
    expect(result.state).toBeNull();
  });
  it('does not invoke a supplied getter or freeze caller objects', () => {
    const value = input();
    let called = false;
    Object.defineProperty(value, 'editorText', {
      get: () => {
        called = true;
        return 'S1';
      },
      enumerable: true,
    });
    expectRefusal(value, 'invalid-input');
    expect(called).toBe(false);
    expect(Object.isFrozen(value)).toBe(false);
  });
  it.each(['extra', 'symbol', 'cycle', 'sparse', 'prototype'])(
    'contains noncanonical plain-data envelope %s',
    (kind) => {
      const value = input();
      const record = value as unknown as Record<string | symbol, unknown>;
      if (kind === 'extra') record.extra = null;
      if (kind === 'symbol') record[Symbol('hidden')] = 'x';
      if (kind === 'cycle') record.state = value;
      if (kind === 'sparse') record.observation = { ...value.observation, masters: new Array(1) };
      if (kind === 'prototype') Object.setPrototypeOf(value, { inherited: 'value' });
      expectRefusal(value, 'invalid-input');
    },
  );
});
