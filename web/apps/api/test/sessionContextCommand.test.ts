import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it, vi } from 'vitest';
import {
  BUDGETED_BIND_SQL,
  READ_BUDGET,
  VOUCHER_BUDGET,
  budgetedBindParams,
} from './support/txBudgetBinding.js';
import type { PrismaClient } from '@datacare/db';
import type { Tx } from '@datacare/db';
import {
  withSessionContextCommand,
  type SessionCommandIdentity,
  type SessionCommandPolicy,
} from '../src/modules/auth/sessionContextCommand.js';
import {
  authorizeForm,
  authorizeFormTx,
  type Principal,
} from '../src/modules/rbac/authorization.js';
import { ScopeError } from '../src/modules/auth/businessScope.js';
import { editSalesOrderInSession, type SalesOrderInput } from '../src/modules/sales/salesOrder.js';

const identity: SessionCommandIdentity = {
  tenantId: 'command-unit',
  sessionId: '11111111-1111-4111-8111-111111111111',
  loginName: 'operator',
  loginCoCode: '01',
  coCode: '01',
  lcCode: '01',
  coYear: '2024-2025',
  contextEpoch: '7',
};
const policy: SessionCommandPolicy = {
  form: 'Sales/Sales Order',
  action: 'update',
  scope: {
    tenantId: identity.tenantId,
    coCode: '01',
    lcCode: '01',
    coYear: '2024-2025',
    coBook: 'C13',
  },
};
const ledger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
};
interface Step {
  match: string;
  rows?: unknown[];
  error?: Error;
}
/** SQL observation/transaction double. Real withTenant binds tenant; no database or lock emulation. */
function scripted(steps: Step[], budget: { timeout: number } = VOUCHER_BUDGET) {
  const pending = [...steps];
  const trace: string[] = [];
  const query = vi.fn(async (sql: string, ..._params: unknown[]) => {
    const step = pending.shift();
    if (!step) throw new Error(`Unexpected query: ${sql}`);
    expect(sql).toContain(step.match);
    trace.push(step.match);
    if (step.error) throw step.error;
    return structuredClone(step.rows ?? []);
  });
  const execute = vi.fn(async (sql: string, ...params: unknown[]) => {
    expect(sql).toBe(BUDGETED_BIND_SQL);
    expect(params).toEqual(budgetedBindParams(identity.tenantId, budget));
    trace.push('bind');
    return 1;
  });
  const tx = { $queryRawUnsafe: query, $executeRawUnsafe: execute } as unknown as Tx;
  const transaction = vi.fn(async (work: (tx: Tx) => Promise<unknown>, options?: unknown) => {
    trace.push('begin');
    try {
      const result = await work(tx);
      trace.push('commit');
      return result;
    } catch (error) {
      trace.push('rollback');
      throw error;
    }
  });
  return {
    prisma: { $transaction: transaction } as unknown as PrismaClient,
    tx,
    query,
    execute,
    transaction,
    pending,
    trace,
  };
}
const live = (): Step => ({
  match: '"expires_at">clock_timestamp()',
  rows: [{ ...identity, ledgerContext: ledger, revoked: false, unexpired: true }],
});
const steps = (): Step[] => [
  {
    match: "current_setting('app.tenant_id'",
    rows: [{ tenant: identity.tenantId, isolation: 'read committed' }],
  },
  { match: 'FOR SHARE', rows: [{ ...identity, ledgerContext: ledger }] },
  live(),
  {
    match: 'FROM "LOGIN_MAST"',
    rows: [
      {
        CO_CODE: '01',
        LOGIN_NAME: 'operator',
        LOGIN_CATG: 'USER',
        PASSWORD_RESET_REQUIRED: 'N',
        USER_PRINT: 'Y',
      },
    ],
  },
  { match: 'FROM "CO_MAST"', rows: [{ CO_CODE: '01', LC_CODE: '01', allowed: true }] },
  { match: 'FROM "LOCT_MAST"', rows: [{ LC_CODE: '01' }] },
  { match: 'FROM "YEAR_MAST"', rows: [{ year: '2024-2025' }] },
  { match: 'FROM "USER_SET"', rows: [{ FRM_VIEW: 'Y', FRM_EDIT: 'Y' }] },
  live(),
];

describe('transaction-bound session command source contracts', () => {
  it('pins the26 independent preimplementation schedules unchanged', () => {
    const bytes = readFileSync(
      new URL('./fixtures/sessionCommand.independent.json', import.meta.url),
    );
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      'ed87f81e039273c6bd25c9a19184b7c964c7b48cbfd7a3bb39eb0c58032f4aa4',
    );
    expect(JSON.parse(bytes.toString()).schedules).toHaveLength(26);
  });
  it('one transaction binds once, locks SHARE first, resolves current authority and finally rechecks expiry', async () => {
    const db = scripted(steps());
    const work = vi.fn(async (tx: Tx, admitted: { context: unknown; principal: Principal }) => {
      expect(tx).toBe(db.tx);
      expect(admitted.context).toEqual({ ...identity, ledgerContext: ledger });
      expect(admitted.principal.passwordResetRequired).toBe(false);
      expect(Object.isFrozen(admitted)).toBe(true);
      db.trace.push('business');
      return 'committed-value';
    });
    expect(await withSessionContextCommand(db.prisma, identity, policy, work)).toBe(
      'committed-value',
    );
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.transaction.mock.calls[0]?.[1]).toEqual({
      ...VOUCHER_BUDGET,
      isolationLevel: 'ReadCommitted',
    });
    expect(db.execute).toHaveBeenCalledTimes(1);
    expect(db.pending).toHaveLength(0);
    expect(db.trace).toEqual([
      'begin',
      'bind',
      "current_setting('app.tenant_id'",
      'FOR SHARE',
      '"expires_at">clock_timestamp()',
      'FROM "LOGIN_MAST"',
      'FROM "CO_MAST"',
      'FROM "LOCT_MAST"',
      'FROM "YEAR_MAST"',
      'FROM "USER_SET"',
      'business',
      '"expires_at">clock_timestamp()',
      'commit',
    ]);
    for (const [sql] of db.query.mock.calls) {
      if (sql.includes('FROM "LOGIN_MAST"') || sql.includes('FROM "USER_SET"'))
        expect(sql).not.toMatch(/FOR\s+(UPDATE|SHARE)/);
      expect(sql).not.toMatch(/^\s*(UPDATE|INSERT|DELETE)\b/);
    }
  });
  it.each([
    { name: 'missing identity', identity: undefined, code: 'session-invalid' },
    {
      name: 'missing epoch',
      identity: { ...identity, contextEpoch: undefined },
      code: 'session-invalid',
    },
    { name: 'numeric epoch', identity: { ...identity, contextEpoch: 7 }, code: 'session-invalid' },
    {
      name: 'overflow epoch',
      identity: { ...identity, contextEpoch: '9223372036854775808' },
      code: 'session-invalid',
    },
    {
      name: 'unknown authority',
      identity: { ...identity, isAdmin: true },
      code: 'session-invalid',
    },
    {
      name: 'incomplete scope',
      identity: { ...identity, coYear: undefined },
      code: 'scope-incomplete',
    },
  ])('refuses $name before starting a transaction', async (fixture) => {
    const db = scripted([]);
    const work = vi.fn();
    await expect(
      withSessionContextCommand(db.prisma, fixture.identity, policy, work),
    ).rejects.toMatchObject({ code: fixture.code });
    expect(work).not.toHaveBeenCalled();
    expect(db.transaction).not.toHaveBeenCalled();
  });
  it('does not invoke accessor authority', async () => {
    const read = vi.fn(() => '7');
    const bad = { ...identity };
    Object.defineProperty(bad, 'contextEpoch', { enumerable: true, get: read });
    await expect(
      withSessionContextCommand(scripted([]).prisma, bad, policy, vi.fn()),
    ).rejects.toMatchObject({ code: 'session-invalid' });
    expect(read).not.toHaveBeenCalled();
  });
  it.each([
    {
      name: 'wrong binding',
      index: 0,
      rows: [{ tenant: 'foreign', isolation: 'read committed' }],
      code: 'invalid-transaction-context',
    },
    {
      name: 'wrong isolation',
      index: 0,
      rows: [{ tenant: identity.tenantId, isolation: 'repeatable read' }],
      code: 'invalid-transaction-context',
    },
    { name: 'missing session', index: 1, rows: [], code: 'session-invalid' },
    {
      name: 'new epoch same tuple',
      index: 1,
      rows: [{ ...identity, contextEpoch: '9', ledgerContext: ledger }],
      code: 'context-stale',
    },
    {
      name: 'revoked',
      index: 2,
      rows: [{ revoked: true, unexpired: true }],
      code: 'session-revoked',
    },
    {
      name: 'expired after wait',
      index: 2,
      rows: [{ revoked: false, unexpired: false }],
      code: 'session-expired',
    },
    {
      name: 'fresh forced reset',
      index: 3,
      rows: [
        { CO_CODE: '01', LOGIN_NAME: 'operator', LOGIN_CATG: 'USER', PASSWORD_RESET_REQUIRED: 'Y' },
      ],
      code: 'password-reset-required',
    },
    {
      name: 'view without edit',
      index: 7,
      rows: [{ FRM_VIEW: 'Y', FRM_EDIT: 'N' }],
      code: 'forbidden',
    },
  ])('$name never invokes business work', async (fixture) => {
    const queue = steps();
    queue[fixture.index] = { ...queue[fixture.index]!, rows: fixture.rows };
    const db = scripted(queue);
    const work = vi.fn();
    await expect(
      withSessionContextCommand(db.prisma, identity, policy, work),
    ).rejects.toMatchObject({ code: fixture.code });
    expect(work).not.toHaveBeenCalled();
    expect(db.trace.at(-1)).toBe('rollback');
  });
  it('final expiry failure aborts after work, with no session touch', async () => {
    const queue = steps();
    queue[8] = { ...live(), rows: [{ revoked: false, unexpired: false }] };
    const db = scripted(queue);
    const work = vi.fn(async () => 'prospective');
    await expect(
      withSessionContextCommand(db.prisma, identity, policy, work),
    ).rejects.toMatchObject({ code: 'session-expired' });
    expect(work).toHaveBeenCalledTimes(1);
    expect(db.trace.at(-1)).toBe('rollback');
    expect(db.execute).toHaveBeenCalledTimes(1);
  });
  it('final context mutation is refused even if the callback changed the same locked row', async () => {
    const queue = steps();
    queue[8] = {
      ...live(),
      rows: [
        { ...identity, contextEpoch: '8', ledgerContext: ledger, revoked: false, unexpired: true },
      ],
    };
    const db = scripted(queue);
    await expect(
      withSessionContextCommand(db.prisma, identity, policy, async () => 'prospective'),
    ).rejects.toMatchObject({ code: 'context-stale' });
    expect(db.trace.at(-1)).toBe('rollback');
  });
  it('policy accessors and unknown fields are refused before a transaction without invoking them', async () => {
    const db = scripted([]);
    const read = vi.fn(() => policy.scope);
    const bad = { ...policy };
    Object.defineProperty(bad, 'scope', { enumerable: true, get: read });
    await expect(
      withSessionContextCommand(db.prisma, identity, bad, vi.fn()),
    ).rejects.toMatchObject({ code: 'invalid-command-policy' });
    await expect(
      withSessionContextCommand(
        db.prisma,
        identity,
        { ...policy, mode: 'A' } as SessionCommandPolicy,
        vi.fn(),
      ),
    ).rejects.toMatchObject({ code: 'invalid-command-policy' });
    expect(read).not.toHaveBeenCalled();
    expect(db.transaction).not.toHaveBeenCalled();
  });
  it.each([403, 409])('preserves ScopeError status%s', async (status) => {
    const db = scripted(steps());
    await expect(
      withSessionContextCommand(db.prisma, identity, policy, async () => {
        throw new ScopeError('scope-mismatch', status);
      }),
    ).rejects.toMatchObject({ code: 'scope-mismatch', statusCode: status });
  });
  it.each([
    { code: 'P2034' },
    { code: '40001' },
    { code: '40P01' },
    { code: 'P2010', meta: { code: '40001' } },
    { code: 'P2010', meta: { code: '40P01' } },
  ])('contains proven transaction conflict $code with one attempt', async (descriptor) => {
    const db = scripted(steps());
    await expect(
      withSessionContextCommand(db.prisma, identity, policy, async () => {
        throw Object.assign(new Error('confirmed database conflict'), descriptor);
      }),
    ).rejects.toMatchObject({ code: 'session-command-conflict', statusCode: 409 });
    expect(db.transaction).toHaveBeenCalledTimes(1);
  });
  it.each(['transaction timeout', 'connection lost', 'unknown COMMIT acknowledgment'])(
    'does not relabel %s as rollback/context conflict',
    async (message) => {
      const db = scripted(steps());
      const error = new Error(message);
      await expect(
        withSessionContextCommand(db.prisma, identity, policy, async () => {
          throw error;
        }),
      ).rejects.toBe(error);
      expect(db.transaction).toHaveBeenCalledTimes(1);
    },
  );
  it('propagates a domain failure unchanged and does not retry', async () => {
    const db = scripted(steps());
    const error = new Error('business-failure');
    await expect(
      withSessionContextCommand(db.prisma, identity, policy, async () => {
        throw error;
      }),
    ).rejects.toBe(error);
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.trace.at(-1)).toBe('rollback');
  });
  it.each([undefined, '', 'new', 'a'.repeat(63), 'A'.repeat(64), 'a'.repeat(64) + '\n'])(
    'guarded order refuses missing/noncanonical version %s',
    async (expectedVersion) => {
      const db = scripted([]);
      const input: SalesOrderInput = {
        scope: policy.scope,
        acCode: 'PARTY',
        taxRatePct: 0,
        expectedVersion,
      };
      await expect(
        editSalesOrderInSession(db.prisma, { identity, input, voucherNo: 1 }),
      ).rejects.toMatchObject({ name: 'SaleValidationError' });
      expect(db.transaction).not.toHaveBeenCalled();
    },
  );
});

const principal: Principal = {
  loginName: 'operator',
  loginCoCode: '01',
  role: 'USER',
  isAdmin: false,
  passwordResetRequired: false,
  rights: { userUpdate: true, userDelete: true, userPrint: true },
};
const formCases = [
  { action: 'read', row: { FRM_VIEW: 'Y' }, allowed: true },
  { action: 'create', row: { FRM_VIEW: 'Y', FRM_EDIT: 'N' }, allowed: true },
  { action: 'update', row: { FRM_VIEW: 'Y', FRM_EDIT: 'N' }, allowed: false },
  { action: 'update', row: { FRM_VIEW: 'N', FRM_EDIT: 'Y' }, allowed: false },
  { action: 'update', row: { FRM_VIEW: 'true', FRM_EDIT: '1' }, allowed: true },
  { action: 'delete', row: { FRM_VIEW: '1', FRM_DELETE: 'Y' }, allowed: true },
  { action: 'print', row: { FRM_VIEW: 'Y', FRM_PRINT: ' Y' }, allowed: false },
] as const;
describe.each([false, true])('form Tx extraction wrapper=%s', (wrapped) => {
  it.each(formCases)('$action $row', async (fixture) => {
    // The public wrapper reads rights under the read budget; the Tx entry opens no transaction.
    const db = scripted([{ match: 'FROM "USER_SET"', rows: [fixture.row] }], READ_BUDGET);
    const input = {
      tenantId: identity.tenantId,
      lcCode: '01',
      principal,
      form: 'Sales/Sales Order',
      action: fixture.action,
    };
    const result = wrapped ? authorizeForm(db.prisma, input) : authorizeFormTx(db.tx, input);
    if (fixture.allowed)
      expect(await result).toEqual({ form: input.form, action: fixture.action, principal });
    else await expect(result).rejects.toMatchObject({ name: 'FormForbiddenError' });
    expect(db.transaction).toHaveBeenCalledTimes(wrapped ? 1 : 0);
    expect(db.query.mock.calls[0]?.[1]).toBe('01');
    expect(db.query.mock.calls[0]?.[2]).toBe('operator');
  });
});

describe('public form wrapper preserves administrator short circuits', () => {
  it('admin bypass returns without a transaction or SQL', async () => {
    const db = scripted([]);
    const admin = { ...principal, isAdmin: true };
    expect(
      await authorizeForm(db.prisma, {
        tenantId: identity.tenantId,
        lcCode: '01',
        principal: admin,
        form: 'Sales/Sales Order',
        action: 'update',
      }),
    ).toMatchObject({ principal: admin });
    expect(db.transaction).not.toHaveBeenCalled();
    expect(db.query).not.toHaveBeenCalled();
  });
  it('ordinary adminOnly refusal does not open a transaction', async () => {
    const db = scripted([]);
    await expect(
      authorizeForm(db.prisma, {
        tenantId: identity.tenantId,
        lcCode: '01',
        principal,
        form: 'Sales/Sales Order',
        action: 'update',
        adminOnly: true,
      }),
    ).rejects.toMatchObject({ name: 'FormForbiddenError' });
    expect(db.transaction).not.toHaveBeenCalled();
  });
  it('missing form row refuses; ordered first row remains authoritative', async () => {
    const input = {
      tenantId: identity.tenantId,
      lcCode: '01',
      principal,
      form: 'Sales/Sales Order',
      action: 'update' as const,
    };
    for (const rows of [
      [],
      [
        { FRM_VIEW: 'N', FRM_EDIT: 'Y' },
        { FRM_VIEW: 'Y', FRM_EDIT: 'Y' },
      ],
    ]) {
      const db = scripted([{ match: 'FROM "USER_SET"', rows }]);
      await expect(authorizeFormTx(db.tx, input)).rejects.toMatchObject({
        name: 'FormForbiddenError',
      });
      expect(db.query.mock.calls[0]?.[0]).toContain('ORDER BY "row_id"');
      expect(db.query.mock.calls[0]?.[0]).toContain('LIMIT 1');
    }
  });
});
