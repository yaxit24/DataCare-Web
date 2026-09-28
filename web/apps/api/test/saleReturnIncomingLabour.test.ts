import type { Tx } from '@datacare/db';
import { describe, expect, it, vi } from 'vitest';
import { readSaleReturnIncomingLabourTx } from '../src/modules/sales/saleReturnIncomingLabour.js';

const scope = { tenantId: 'labour-reader-unit', coCode: '01' };
const input = { scope, enteredCode: 'S1' };
const master = {
  raw: {
    tenant_id: scope.tenantId,
    CO_CODE: '01',
    LBR_CODE: 'S1',
    LBR_CATG: '01 Rate',
    LBR_VAL: '12.5',
    MAIN_USER: null,
  },
  revision: '123',
  locator: '(0,1)',
};
function connection(
  result: unknown = [{ tenant: scope.tenantId, isolation: 'repeatable read', masters: [master] }],
) {
  const query = vi.fn(async (..._args: unknown[]) => result);
  return { tx: { $queryRawUnsafe: query } as unknown as Tx, query };
}
describe('internal Return labour-master Tx reader boundary (controlled query adapter only)', () => {
  it('uses one parameterized complete observation and returns detached raw/physical inputs', async () => {
    const { tx, query } = connection();
    const before = structuredClone(master);
    const value = await readSaleReturnIncomingLabourTx(tx, input);
    expect(query).toHaveBeenCalledTimes(1);
    const [statement, ...parameters] = query.mock.calls[0]!;
    expect(parameters).toEqual([scope.tenantId, '01', 'S1']);
    expect(statement).toContain("current_setting('app.tenant_id',true)");
    expect(statement).toContain("current_setting('transaction_isolation')");
    expect(statement).toContain('jsonb_each_text(to_jsonb(t))');
    expect(statement).toContain('upper(btrim(t."CO_CODE"))=upper(btrim($2::text))');
    expect(statement).toContain('upper(btrim(t."LBR_CODE"))=upper(btrim($3::text))');
    expect(statement).not.toMatch(/\b(?:LIMIT|INSERT|UPDATE|DELETE|FOR SHARE)\b/i);
    expect(value.masters).toEqual([master]);
    expect(value.masters[0]?.raw).not.toBe(master.raw);
    expect(value.scope).not.toBe(scope);
    expect(value.observationVersion).toMatch(/^[a-f0-9]{64}$/);
    expect(Object.isFrozen(value.masters[0]?.raw)).toBe(true);
    expect(master).toEqual(before);
    expect(Object.isFrozen(master.raw)).toBe(false);
  });
  it('hashes extant raw+revision+locator and scope while ignoring observation row order', async () => {
    const alias = { ...master, raw: { ...master.raw, LBR_CODE: 's1' }, locator: '(0,2)' };
    const a = connection([
      { tenant: scope.tenantId, isolation: 'repeatable read', masters: [master, alias] },
    ]);
    const b = connection([
      { tenant: scope.tenantId, isolation: 'repeatable read', masters: [alias, master] },
    ]);
    const first = await readSaleReturnIncomingLabourTx(a.tx, input);
    expect(await readSaleReturnIncomingLabourTx(b.tx, input)).toEqual(first);
    for (const changed of [
      { ...master, revision: '124' },
      { ...master, locator: '(0,3)' },
      { ...master, raw: { ...master.raw, MAIN_USER: 'changed' } },
    ]) {
      const next = connection([
        { tenant: scope.tenantId, isolation: 'repeatable read', masters: [changed, alias] },
      ]);
      expect((await readSaleReturnIncomingLabourTx(next.tx, input)).observationVersion).not.toBe(
        first.observationVersion,
      );
    }
  });
  it.each([
    { tenant: 'other', isolation: 'repeatable read' },
    { tenant: null, isolation: 'repeatable read' },
    { tenant: scope.tenantId, isolation: 'read committed' },
  ])('refuses transaction context $tenant/$isolation', async (context) => {
    const { tx } = connection([{ ...context, masters: [] }]);
    await expect(readSaleReturnIncomingLabourTx(tx, input)).rejects.toMatchObject({
      code: 'invalid-transaction-context',
    });
  });
  it('keeps complete empty observations and explicitly accepts caller Serializable isolation', async () => {
    const { tx } = connection([{ tenant: scope.tenantId, isolation: 'serializable', masters: [] }]);
    expect(await readSaleReturnIncomingLabourTx(tx, input)).toMatchObject({
      complete: true,
      scope,
      enteredCode: 'S1',
      masters: [],
    });
  });
  it.each([
    null,
    {},
    { ...input, extra: true },
    { ...input, enteredCode: '' },
    { ...input, enteredCode: 'S12' },
    { ...input, enteredCode: 'S1\n' },
    { ...input, scope: { ...scope, coCode: '01 ' } },
  ])('refuses malformed internal input before any query %#', async (value) => {
    const { tx, query } = connection();
    await expect(readSaleReturnIncomingLabourTx(tx, value)).rejects.toMatchObject({
      code: 'invalid-input',
    });
    expect(query).not.toHaveBeenCalled();
  });
  it('does not invoke an input accessor', async () => {
    let called = false;
    const value = {
      scope,
      get enteredCode() {
        called = true;
        return 'S1';
      },
    };
    const { tx, query } = connection();
    await expect(readSaleReturnIncomingLabourTx(tx, value)).rejects.toMatchObject({
      code: 'invalid-input',
    });
    expect(called).toBe(false);
    expect(query).not.toHaveBeenCalled();
  });
  it('propagates a real query failure instead of inventing a missing-code observation', async () => {
    const error = new Error('database unavailable');
    const { tx, query } = connection();
    query.mockRejectedValueOnce(error);
    await expect(readSaleReturnIncomingLabourTx(tx, input)).rejects.toBe(error);
  });
  it('refuses a returned foreign-tenant or incomplete raw observation', async () => {
    for (const raw of [
      { ...master.raw, tenant_id: 'other' },
      { tenant_id: scope.tenantId, CO_CODE: '01', LBR_CODE: 'S1' },
    ]) {
      const { tx } = connection([
        { tenant: scope.tenantId, isolation: 'repeatable read', masters: [{ ...master, raw }] },
      ]);
      await expect(readSaleReturnIncomingLabourTx(tx, input)).rejects.toMatchObject({
        code: 'invalid-observation',
      });
    }
  });
});
