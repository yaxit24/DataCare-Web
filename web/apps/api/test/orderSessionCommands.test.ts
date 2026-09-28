import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import type { PrismaClient } from '@prisma/client';
import type { Tx } from '@datacare/db';
import { beforeEach, describe, expect, it, vi } from 'vitest';
const admission = vi.hoisted(() => ({ call: vi.fn() }));
vi.mock('../src/modules/auth/sessionContextCommand.js', () => ({
  withSessionContextCommand: admission.call,
}));
import {
  createSalesOrder,
  createSalesOrderTx,
  cancelSalesOrder,
  cancelSalesOrderTx,
  createSalesOrderInSession,
  createTourOrderInSession,
  cancelSalesOrderInSession,
  cancelTourOrderInSession,
  editTourOrderInSession,
  type SalesOrderInput,
} from '../src/modules/sales/salesOrder.js';

const version = 'a'.repeat(64);
const scope = () => ({
  tenantId: 'next-order-unit',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  coBook: 'N13',
});
const identity = {
  tenantId: 'next-order-unit',
  sessionId: '11111111-1111-4111-8111-111111111111',
  loginName: 'operator',
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  contextEpoch: '7',
};
const input = (): SalesOrderInput => ({
  scope: scope(),
  acCode: 'PARTY',
  vchDate: '2024-07-10',
  taxRatePct: 0,
  netAmount: 260,
  advanceAmount: 25,
  lines: [],
  expectedVersion: version,
});
const prisma = {} as PrismaClient;
const entries = [
  {
    id: 'sales-create',
    form: 'Sales/Sales Order',
    action: 'create',
    invoke: (value: SalesOrderInput) =>
      createSalesOrderInSession(prisma, { identity, input: value }),
  },
  {
    id: 'tour-create',
    form: 'Karigar/Tour Order',
    action: 'create',
    invoke: (value: SalesOrderInput) =>
      createTourOrderInSession(prisma, { identity, input: value }),
  },
  {
    id: 'sales-cancel',
    form: 'Sales/Sales Order',
    action: 'delete',
    invoke: (value: SalesOrderInput) =>
      cancelSalesOrderInSession(prisma, {
        identity,
        input: {
          scope: value.scope,
          orderMainBook: value.orderMainBook,
          expectedVersion: value.expectedVersion,
          vchNo: 1,
        },
      }),
  },
  {
    id: 'tour-cancel',
    form: 'Karigar/Tour Order',
    action: 'delete',
    invoke: (value: SalesOrderInput) =>
      cancelTourOrderInSession(prisma, {
        identity,
        input: {
          scope: value.scope,
          orderMainBook: value.orderMainBook,
          expectedVersion: value.expectedVersion,
          vchNo: 1,
        },
      }),
  },
  {
    id: 'tour-edit',
    form: 'Karigar/Tour Order',
    action: 'update',
    invoke: (value: SalesOrderInput) =>
      editTourOrderInSession(prisma, { identity, input: value, voucherNo: 1 }),
  },
] as const;

beforeEach(() => admission.call.mockReset());
describe('five remaining order command entries: transaction-double checks only', () => {
  it('pins26 independently authored schedules without deriving financial expectations from the writer', () => {
    const bytes = readFileSync(
      new URL('./fixtures/orderCommand.independent.json', import.meta.url),
    );
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'c6f86ef10f4f948c570e417f4f1a0336df196fb1085b2028c1f79a1e432c979e',
    );
    expect(JSON.parse(bytes.toString()).schedules).toHaveLength(26);
  });
  it.each(entries)(
    '$id invokes required admission exactly once with fixed form/action and detached exact scope',
    async ({ invoke, form, action }) => {
      const value = input();
      admission.call.mockResolvedValue({ opaque: 'committed-result' });
      await expect(invoke(value)).resolves.toEqual({ opaque: 'committed-result' });
      expect(admission.call).toHaveBeenCalledTimes(1);
      const [client, retained, policy, work] = admission.call.mock.calls[0]!;
      expect(client).toBe(prisma);
      expect(retained).toBe(identity);
      expect(policy).toEqual({ form, action, scope: scope() });
      expect(policy.scope).not.toBe(value.scope);
      expect(Object.isFrozen(policy.scope)).toBe(true);
      expect(typeof work).toBe('function');
    },
  );
  it.each(entries)(
    '$id work begins with the detached selected book using the supplied Tx, after admission permits work',
    async ({ invoke }) => {
      const value = input();
      let work!: (tx: Tx) => Promise<unknown>;
      admission.call.mockImplementation(async (_p, _i, _policy, callback) => {
        work = callback;
        return 'captured';
      });
      await invoke(value);
      value.scope.coCode = '02';
      value.scope.coBook = 'N99';
      const stop = new Error('stop-at-first-real-business-query');
      const query = vi.fn(async () => {
        throw stop;
      });
      const tx = { $queryRawUnsafe: query } as unknown as Tx;
      await expect(work(tx)).rejects.toBe(stop);
      expect(query).toHaveBeenCalledTimes(1);
      expect(query.mock.calls[0]?.slice(1)).toEqual(['next-order-unit', '01', '01', 'N13']);
    },
  );
  it.each(entries)(
    '$id rejects cross-family policy input before admission',
    async ({ invoke, form }) => {
      const value = input();
      value.orderMainBook = form.startsWith('Sales/') ? 'TOUR ORDER' : 'SALES ORDER';
      await expect(invoke(value)).rejects.toMatchObject({ name: 'SaleValidationError' });
      expect(admission.call).not.toHaveBeenCalled();
    },
  );
  const malformed: unknown[] = [
    undefined,
    null,
    '',
    'A'.repeat(64),
    'a'.repeat(63),
    'a'.repeat(65),
    'a'.repeat(64) + '\n',
    'g'.repeat(64),
    1,
  ];
  it.each(entries.filter((entry) => entry.action !== 'create'))(
    '$id requires exact saved version at the service boundary',
    async ({ invoke }) => {
      for (const value of malformed) {
        const body = input();
        Object.assign(body, { expectedVersion: value });
        await expect(invoke(body)).rejects.toMatchObject({ name: 'SaleValidationError' });
      }
      expect(admission.call).not.toHaveBeenCalled();
    },
  );
  it('Sales create still refuses an absent date before admission', async () => {
    const value = input();
    delete value.vchDate;
    await expect(
      createSalesOrderInSession(prisma, { identity, input: value }),
    ).rejects.toBeInstanceOf(Error);
    expect(admission.call).not.toHaveBeenCalled();
  });
  it('Tour create retains its missing-date default and optional flattened components admission', async () => {
    const value = input();
    delete value.vchDate;
    value.lines = [{ itCode: 'GOLD', pcs: 1, grossWt: 10, netWt: 10, touch: 100, rate: 20 }];
    admission.call.mockResolvedValue('captured-without-running-business');
    await expect(createTourOrderInSession(prisma, { identity, input: value })).resolves.toBe(
      'captured-without-running-business',
    );
    expect(admission.call).toHaveBeenCalledTimes(1);
  });
  it.each(['create', 'cancel'] as const)(
    '%s compatibility wrapper opens one transaction; Tx entry opens none and both retain the first query',
    async (kind) => {
      const stop = new Error('stop-first-query');
      const query = vi.fn(async (_sql: string, ..._values: unknown[]) => {
        throw stop;
      });
      const execute = vi.fn(async (_sql: string, ..._values: unknown[]) => 1);
      const tx = { $queryRawUnsafe: query, $executeRawUnsafe: execute } as unknown as Tx;
      const transaction = vi.fn(async (work: (value: Tx) => Promise<unknown>) => work(tx));
      const client = { $transaction: transaction } as unknown as PrismaClient;
      if (kind === 'create') await expect(createSalesOrder(client, input())).rejects.toBe(stop);
      else
        await expect(cancelSalesOrder(client, { scope: scope(), vchNo: 1 })).rejects.toBe(stop);
      expect(transaction).toHaveBeenCalledTimes(1);
      expect(execute).toHaveBeenNthCalledWith(
        1,
        "SELECT set_config('app.tenant_id', $1, true)",
        'next-order-unit',
      );
      const first = query.mock.calls[0];
      query.mockClear();
      if (kind === 'create') await expect(createSalesOrderTx(tx, input())).rejects.toBe(stop);
      else
        await expect(cancelSalesOrderTx(tx, { scope: scope(), vchNo: 1 })).rejects.toBe(stop);
      expect(transaction).toHaveBeenCalledTimes(1);
      expect(query.mock.calls[0]).toEqual(first);
      expect(admission.call).not.toHaveBeenCalled();
    },
  );
  it('mounted five handlers require session entries; Tour only adds saved version and keeps its existing input adapter', () => {
    const source = readFileSync(new URL('../src/routes/txn.ts', import.meta.url), 'utf8');
    const handlers = [
      ['post', '/sales-orders', 'createSalesOrderInSession', false],
      ['delete', '/sales-orders/:vchNo', 'cancelSalesOrderInSession', true],
      ['post', '/tour-orders', 'createTourOrderInSession', false],
      ['put', '/tour-orders/:vchNo', 'editTourOrderInSession', true],
      ['delete', '/tour-orders/:vchNo', 'cancelTourOrderInSession', true],
    ] as const;
    for (const [method, path, entry, needsVersion] of handlers) {
      const start = source.indexOf('app.' + method + "('" + path + "'");
      expect(start).toBeGreaterThan(-1);
      const stop = source.indexOf('\n  app.', start + 1);
      const body = source.slice(start, stop < 0 ? undefined : stop);
      expect(body).toContain(entry + '(prisma');
      expect(body).toContain('identity: orderCommandIdentity(req)');
      if (needsVersion)
        expect(body).toContain('requireOrderVersion(body(req).expectedVersion)');
      if (path === '/tour-orders') expect(body).toContain('salesOrderInput(req)');
      if (path === '/sales-orders') expect(body).toContain('completeSalesOrderInput(req)');
    }
  });
});
