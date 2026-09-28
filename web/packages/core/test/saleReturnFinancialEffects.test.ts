import { readFileSync } from 'node:fs';
import { createHash } from 'node:crypto';
import { describe, it, expect } from 'vitest';
import { Decimal } from 'decimal.js';
import {
  planSaleReturnFinancialEffects,
  type SaleReturnFinancialInput,
  type SaleReturnFinancialProjection,
  type SaleReturnFinancialRole,
} from '../src/saleReturnFinancialEffects.js';
const fixturePath = new URL(
  './fixtures/saleReturnFinancialEffects.independent.json',
  import.meta.url,
);
const bytes = readFileSync(fixturePath);
type Mutable = Record<string, any>;
interface Case {
  id: string;
  note: string;
  input: SaleReturnFinancialInput;
  expected: {
    status: 'ready' | 'unsupported';
    before?: SaleReturnFinancialProjection;
    after?: SaleReturnFinancialProjection;
    patches?: Record<SaleReturnFinancialRole, Record<string, string>>;
    diagnosticCode?: string;
  };
}
const fixture = JSON.parse(bytes.toString()) as {
  cases: Case[];
  roles: SaleReturnFinancialRole[];
  tables: string[];
};
const base = () => structuredClone(fixture.cases[0]!.input) as unknown as Mutable;
const grouped = ['acData', 'acData', 'rojMel', 'rojMel', 'mainStock', 'taxData', 'taxData'];
function assertFrozen(v: unknown) {
  if (v && typeof v === 'object') {
    expect(Object.isFrozen(v)).toBe(true);
    for (const x of Object.values(v)) assertFrozen(x);
  }
}
function refuse(input: unknown) {
  const r = planSaleReturnFinancialEffects(input);
  expect(r.status).toBe('unsupported');
  expect(r.canCommit).toBe(false);
  expect(r.candidatePlan).toBeNull();
  expect(r.diagnostics.length).toBeGreaterThan(0);
  assertFrozen(r);
  return r;
}
describe('independent source literals', () => {
  it('preserves the pre-implementation30-case fixture pin', () => {
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '635e1e251837c0c5acc6acd39f2b7e2932ad19850b976d3a1f2d59cf5229a09b',
    );
    expect(fixture.cases).toHaveLength(30);
  });
  for (const c of fixture.cases)
    it(c.id + ' ' + c.note, () => {
      const before = structuredClone(c.input);
      const r = planSaleReturnFinancialEffects(c.input);
      expect(c.input).toEqual(before);
      expect(r.canCommit).toBe(false);
      expect(r.status).toBe(c.expected.status);
      assertFrozen(r);
      if (c.expected.status === 'ready') {
        expect(r.diagnostics).toEqual([]);
        expect(r.before).toEqual(c.expected.before);
        expect(r.after).toEqual(c.expected.after);
        expect(Object.values(r.before!).reduce((n, x) => n + Object.keys(x).length, 0)).toBe(221);
        expect(Object.values(r.after!).reduce((n, x) => n + Object.keys(x).length, 0)).toBe(221);
        expect(r.candidatePlan!.map((x) => x.role)).toEqual(fixture.roles);
        for (const p of r.candidatePlan!) {
          expect(p.patch).toEqual(c.expected.patches![p.role]);
          expect(p.candidateRaw).toEqual({ ...p.raw, ...c.expected.patches![p.role] });
          expect(p.raw).not.toBe(p.candidateRaw);
          expect(p.raw.tenant_id).toBe(c.input.tenantId);
          expect(p.version).toMatch(/^[a-f0-9]{64}$/);
        }
      } else {
        expect(r.candidatePlan).toBeNull();
        expect(r.diagnostics.map((d) => d.code)).toContain(c.expected.diagnosticCode);
      }
    });
  it('freezes separately qualified joint reader baseline without altering old30', () => {
    const jointBytes = readFileSync(
      new URL('./fixtures/saleReturnFinancialEffects.joint.independent.json', import.meta.url),
    );
    expect(createHash('sha256').update(jointBytes).digest('hex')).toBe(
      'd1d96417de35b406d8b50d47b8547dc0e788f323f953e3d26d71a9b77323390f',
    );
    const j = JSON.parse(jointBytes.toString()) as { case: Case };
    const r = planSaleReturnFinancialEffects(j.case.input);
    expect(r.status).toBe('ready');
    expect(r.before).toEqual(j.case.expected.before);
    expect(r.after).toEqual(j.case.expected.after);
  });
});
describe('all221 old source-owned values are actually admitted', () => {
  const original = fixture.cases[0]!;
  for (const [i, role] of fixture.roles.entries())
    for (const [field, value] of Object.entries(original.expected.before![role]))
      it(role + ' ' + field + ' mismatch refuses without any partial candidate', () => {
        const x = base();
        const group = grouped[i]!;
        const index =
          group === 'acData' || group === 'rojMel' ? i % 2 : group === 'taxData' ? i - 5 : 0;
        const raw = x.observed[group][index].raw;
        raw[field] =
          value === null
            ? 'unexpected'
            : typeof value === 'string' && /^[-+0-9. ]+$/.test(value) && value.trim() !== ''
              ? '987.25'
              : value + '!';
        refuse(x);
      });
});
describe('boundary, preservation and atomic candidate semantics', () => {
  it('a bad final tax row cannot publish the six earlier patches', () => {
    const x = base();
    x.observed.taxData[1].raw.TOT_AMT = '1.00';
    const r = refuse(x);
    expect(r.observed).toEqual(x.observed);
    expect(r.before).not.toBeNull();
    expect(r.after).not.toBeNull();
  });
  it('complete observations survive a semantically missing current-schema column', () => {
    const x = base();
    delete x.observed.mainStock[0].raw.ITM_COLOR;
    expect(refuse(x).observed).toEqual(x.observed);
  });
  it('retains valid sibling projection when the other phase is invalid', () => {
    const x = base();
    x.before.incoming.NET_AMT = 'NaN';
    const r = refuse(x);
    expect(r.before).toBeNull();
    expect(r.after).toEqual(fixture.cases[0]!.expected.after);
  });
  it('detaches all input objects including context/raw after success', () => {
    const x = base();
    const before = structuredClone(x);
    const r = planSaleReturnFinancialEffects(x);
    x.before.incoming.ITM_REMARK = 'later';
    x.after.header.AC_NAME = 'later';
    x.context.book[0].DATA_TYPE = 'C';
    x.observed.mainStock[0].raw.GRID_SCROLL = 'later';
    expect(r.source.before).toEqual(before.before);
    expect(r.source.after).toEqual(before.after);
    expect(r.context).toEqual(before.context);
    expect(r.observed).toEqual(before.observed);
    assertFrozen(r);
  });
  it('detaches all valid observations on malformed outer input', () => {
    const x = base();
    x.extra = true;
    const o = structuredClone(x.observed);
    const r = refuse(x);
    x.observed.acData[0].raw.CR_AMT = '1';
    expect(r.observed).toEqual(o);
  });
  it('same-value lexical source amount does not invent an update', () => {
    const x = base();
    x.after = structuredClone(x.before);
    x.after.incoming.OTH_AMT = '0.000';
    const r = planSaleReturnFinancialEffects(x);
    expect(r.status).toBe('ready');
    expect(r.candidatePlan!.every((p) => Object.keys(p.patch).length === 0)).toBe(true);
  });
  it('retains rawNULL source account name with SQL NULL concatenation', () => {
    const x = base();
    for (const p of ['before', 'after']) x[p].header.AC_NAME = null;
    x.observed.rojMel[1].raw.AC_NAME = null;
    for (const t of x.observed.taxData) t.raw.PARTY_NAME = null;
    const r = planSaleReturnFinancialEffects(x);
    expect(r.status).toBe('ready');
    expect(r.after!['return-taxbook-summary-rojmel'].AC_NAME).toBeNull();
    expect(r.after!['return-tax-sr1'].PARTY_NAME).toBeNull();
  });
  it('keeps mapped stableFloat observations without a newly synthesizedFloat patch', () => {
    const x = base();
    for (const p of ['before', 'after']) x[p].incoming.TAG_COST = '0.10';
    x.observed.mainStock[0].raw.KR_COST = '0.1';
    const r = planSaleReturnFinancialEffects(x);
    expect(r.status).toBe('ready');
    const stock = r.candidatePlan!.find((p) => p.table === 'MAIN_STOCK')!;
    expect(stock.patch).not.toHaveProperty('KR_COST');
    expect(stock.candidateRaw.KR_COST).toBe('0.1');
  });
  it('rejects a physical row_id outside PostgreSQL bigint', () => {
    const x = base();
    x.observed.acData[0].physicalIdentity = '9223372036854775808';
    x.observed.acData[0].raw.row_id = '9223372036854775808';
    refuse(x);
  });
  it('preserves precision independently of ambient Decimal configuration', () => {
    const precision = Decimal.precision;
    try {
      Decimal.set({ precision: 5 });
      const x = base();
      x.after.incoming.OTH_AMT = '99999999999999.99';
      x.after.incoming.NET_AMT = '100000000000109.99';
      x.after.incoming.TOT_AMT = '100000000000109.99';
      x.after.header.RTN_NET_AMT = '100000000000110';
      x.after.header.RTN_TOT_AMT = '100000000000110';
      x.after.header.RTN_BILL_OS = '100000000000110';
      const r = planSaleReturnFinancialEffects(x);
      expect(r.status).toBe('ready');
      expect(r.after!['incoming-stock'].OTH_AMT).toBe('99999999999999.99');
      expect(r.after!['incoming-customer-ledger'].CR_AMT).toBe('100000000000109.99');
      expect(r.after!['return-tax-sr2'].NET_AMT).toBe('100000000000110.00');
    } finally {
      Decimal.set({ precision });
    }
  });
  it.each(['1\n', '1\t', '1\u2028', '1e2', 'Infinity', 'NaN', ''])(
    'refuses numeric transport %j',
    (v) => {
      const x = base();
      x.after.incoming.OTH_AMT = v;
      refuse(x);
    },
  );
  it.each([null, undefined, 1, NaN, Infinity, [], new Date(), new String('x')])(
    'refuses non-record outer input %j',
    (v) => {
      refuse(v);
    },
  );
  it('never executes getters even with recoverable observations', () => {
    let read = 0;
    const x = base();
    Object.defineProperty(x, 'context', {
      enumerable: true,
      get() {
        read++;
        throw Error('must not execute');
      },
    });
    const r = refuse(x);
    expect(read).toBe(0);
    expect(r.observed).not.toBeNull();
  });
  it('rejects nested raw getters without executing them', () => {
    let read = 0;
    const x = base();
    Object.defineProperty(x.observed.acData[0].raw, 'CR_AMT', {
      enumerable: true,
      get() {
        read++;
        return '110.00';
      },
    });
    refuse(x);
    expect(read).toBe(0);
  });
  it('refuses cycles through raw values', () => {
    const x = base();
    x.before.incoming.future = x.before.incoming;
    refuse(x);
  });
  it('refuses custom-prototype context records', () => {
    const x = base();
    Object.setPrototypeOf(x.context, { inherited: true });
    refuse(x);
  });
  it('permits ordinary null-prototype own-data input', () => {
    const x = base();
    Object.setPrototypeOf(x, null);
    Object.setPrototypeOf(x.context.book[0], null);
    expect(planSaleReturnFinancialEffects(x).status).toBe('ready');
  });
  it('refuses symbol and nonenumerable outer keys', () => {
    for (const k of [Symbol('hidden'), 'hidden']) {
      const x = base();
      Object.defineProperty(x, k, { value: 1, enumerable: typeof k === 'symbol' });
      refuse(x);
    }
  });
  it('refuses sparse or getter-owned arrays', () => {
    let reads = 0;
    const x = base();
    Object.defineProperty(x.observed.acData, 0, {
      enumerable: true,
      get() {
        reads++;
        return {};
      },
    });
    refuse(x);
    expect(reads).toBe(0);
    const y = base();
    delete y.context.taxes[0];
    refuse(y);
  });
  it('refuses oversized raw data with bounded recoverable output', () => {
    const x = base();
    x.before.incoming.future = 'x'.repeat(65536);
    const r = refuse(x);
    expect(r.observed).toEqual(x.observed);
  });
});

describe('canonical metadata refuses terminal newlines without normalization', () => {
  it('rejects a newline-bearing tenant even when all supplied raw scopes echo it', () => {
    const x = base();
    x.tenantId += '\n';
    for (const p of ['before', 'after'])
      for (const t of ['incoming', 'header']) x[p][t].tenant_id = x.tenantId;
    for (const rows of Object.values(x.observed) as Mutable[][])
      for (const o of rows) o.raw.tenant_id = x.tenantId;
    refuse(x);
  });
  it.each(['companyShortName', 'openingDate'])(
    'rejects terminal newline in canonical context %s',
    (field) => {
      const x = base();
      x.context[field] += '\n';
      refuse(x);
    },
  );
  it('rejects terminal newline in complete raw clock without trimming it', () => {
    const x = base();
    for (const p of ['before', 'after'])
      for (const t of ['incoming', 'header']) x[p][t].VCH_TIME += '\n';
    refuse(x);
  });
  it('rejects newline-bearing physical row identifiers even when raw agrees', () => {
    const x = base();
    x.observed.acData[0].physicalIdentity += '\n';
    x.observed.acData[0].raw.row_id += '\n';
    refuse(x);
  });
});
