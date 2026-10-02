import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { describe, expect, it, vi } from 'vitest';
import {
  BUDGETED_BIND_SQL,
  VOUCHER_BUDGET,
  budgetedBindParams,
} from './support/txBudgetBinding.js';
import type { PrismaClient } from '@datacare/db';
import type { Tx } from '@datacare/db';
import {
  withSessionContextSerializableCommand,
  SESSION_CONTEXT_SERIALIZABLE_COMMAND_VERSION,
  type SessionSerializableCommandIdentity,
  type SessionSerializableCommandPolicy,
} from '../src/modules/auth/sessionContextSerializableCommand.js';

const fixtureBytes = readFileSync(
  new URL('./fixtures/sessionSerializableCommand.independent.json', import.meta.url),
);
const fixture = JSON.parse(fixtureBytes.toString()) as {
  identity: SessionSerializableCommandIdentity;
  policy: SessionSerializableCommandPolicy;
  unitCases: Array<{
    id: string;
    scenario: string;
    expected: { code: string; statusCode: number | null };
  }>;
  databaseSchedules: unknown[];
};
type Mutable<T> = T extends object ? { -readonly [K in keyof T]: Mutable<T[K]> } : T;
const mutable = <T>(value: T): Mutable<T> => structuredClone(value) as Mutable<T>;
const qualificationsBytes = readFileSync(
  new URL('./fixtures/sessionSerializableCommand.qualifications.json', import.meta.url),
);
const qualification = JSON.parse(qualificationsBytes.toString()) as {
  corrections: Array<{
    id: string;
    expected: { code: string; statusCode: number };
  }>;
};
const identity = fixture.identity;
const policy = fixture.policy;
const ledger = {
  version: 'server-session-ledger-context-v1',
  status: 'unknown',
  mode: null,
  reason: 'vendor-authority-unresolved',
};
interface Step {
  match: string;
  rows?: unknown[];
  error?: unknown;
}
/** Scripted SQL observations use the real Tx helpers. This double does not simulate MVCC/locks. */
function scripted(steps: Step[], commitError?: unknown) {
  const pending = [...steps];
  const trace: string[] = [];
  const query = vi.fn(async (sql: string, ..._params: unknown[]) => {
    const next = pending.shift();
    if (!next) throw new Error(`Unexpected query: ${sql}`);
    expect(sql).toContain(next.match);
    trace.push(next.match);
    if (next.error !== undefined) throw next.error;
    return structuredClone(next.rows ?? []);
  });
  const execute = vi.fn(async (sql: string, ...params: unknown[]) => {
    expect(sql).toBe(BUDGETED_BIND_SQL);
    expect(params).toEqual(budgetedBindParams(identity.tenantId, VOUCHER_BUDGET));
    trace.push('bind');
    return 1;
  });
  const tx = {
    $queryRawUnsafe: query,
    $executeRawUnsafe: execute,
  } as unknown as Tx;
  const transaction = vi.fn(async (work: (tx: Tx) => Promise<unknown>, _options?: unknown) => {
    trace.push('begin');
    try {
      const value = await work(tx);
      if (commitError !== undefined) throw commitError;
      trace.push('commit');
      return value;
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
const stored = () => ({ ...identity, ledgerContext: structuredClone(ledger) });
const live = (): Step => ({
  match: '"expires_at">clock_timestamp()',
  rows: [{ ...stored(), revoked: false, unexpired: true }],
});
const steps = (): Step[] => [
  {
    match: "current_setting('app.tenant_id'",
    rows: [{ tenant: identity.tenantId, isolation: 'serializable' }],
  },
  { match: 'FOR SHARE', rows: [stored()] },
  live(),
  {
    match: 'FROM "LOGIN_MAST"',
    rows: [
      {
        CO_CODE: '01',
        LOGIN_NAME: 'operator',
        LOGIN_CATG: 'USER',
        PASSWORD_RESET_REQUIRED: 'N',
        USER_UPDATE: 'N',
        USER_DELETE: 'N',
      },
    ],
  },
  {
    match: 'FROM "CO_MAST"',
    rows: [{ CO_CODE: '01', LC_CODE: '01', allowed: true }],
  },
  { match: 'FROM "LOCT_MAST"', rows: [{ LC_CODE: '01' }] },
  { match: 'FROM "YEAR_MAST"', rows: [{ year: '2024-2025' }] },
  {
    match: 'FROM "USER_SET"',
    rows: [{ FRM_VIEW: 'Y', FRM_EDIT: 'Y', FRM_DELETE: 'N' }],
  },
  live(),
];
function changeRow(sequence: Step[], index: number, values: Record<string, unknown>) {
  sequence[index]!.rows = [
    { ...(sequence[index]!.rows![0] as Record<string, unknown>), ...values },
  ];
}

describe('separate Serializable fixed Return update contract', () => {
  it('pins the independent36 outcomes and17 schedules authored before implementation', () => {
    expect(createHash('sha256').update(fixtureBytes).digest('hex')).toBe(
      '719f298df0a0f1e18b0c10f7fabc57933b682f0916f6140cd26ac0724ff68486',
    );
    expect(fixture.unitCases).toHaveLength(36);
    expect(fixture.databaseSchedules).toHaveLength(17);
    expect(SESSION_CONTEXT_SERIALIZABLE_COMMAND_VERSION).toBe(
      'session-serializable-return-update-v1',
    );
  });
  it('pins the single pre-code source qualification and leaves every other literal unchanged', () => {
    expect(createHash('sha256').update(qualificationsBytes).digest('hex')).toBe(
      '1a84a5c10a5d7029af031b28a6f3707531305403b3fe76b6e721f5185d550795',
    );
    expect(qualification.corrections).toHaveLength(1);
    expect(qualification.corrections[0]).toMatchObject({
      id: 'S26',
      expected: { code: 'company-unavailable', statusCode: 409 },
    });
  });
  it.each(fixture.unitCases)(
    '$id $scenario has its independently specified outcome',
    async ({ id, scenario, expected: originalExpected }) => {
      const expected =
        qualification.corrections.find((entry) => entry.id === id)?.expected ?? originalExpected;
      const sequence = steps();
      let supplied: unknown = mutable(identity);
      let fixedPolicy = mutable(policy);
      let commitError: unknown;
      let originalError: unknown;
      switch (scenario) {
        case 'ready':
          break;
        case 'numeric-epoch':
          supplied = { ...identity, contextEpoch: 7 };
          break;
        case 'leading-zero-epoch':
          supplied = { ...identity, contextEpoch: '07' };
          break;
        case 'overflow-epoch':
          supplied = { ...identity, contextEpoch: '9223372036854775808' };
          break;
        case 'authority-extra':
          supplied = { ...identity, isAdmin: true };
          break;
        case 'missing-year':
          supplied = { ...identity, coYear: undefined };
          break;
        case 'scope-mismatch':
          fixedPolicy.scope.coCode = '02';
          break;
        case 'mutable-action':
          fixedPolicy = {
            ...policy,
            action: 'read',
          } as Mutable<SessionSerializableCommandPolicy>;
          break;
        case 'mutable-form':
          fixedPolicy = {
            ...policy,
            form: 'Master/Account',
          } as Mutable<SessionSerializableCommandPolicy>;
          break;
        case 'admin-override':
          fixedPolicy = {
            ...policy,
            adminOnly: true,
          } as Mutable<SessionSerializableCommandPolicy>;
          break;
        case 'repeatable-isolation':
          changeRow(sequence, 0, { isolation: 'repeatable read' });
          break;
        case 'update-denied':
          changeRow(sequence, 7, { FRM_VIEW: 'Y', FRM_EDIT: 'N' });
          break;
        case 'year-unavailable':
          sequence[6]!.rows = [];
          break;
        case 'company-forbidden':
          changeRow(sequence, 4, { allowed: false });
          break;
        case 'wrong-tenant':
          changeRow(sequence, 0, { tenant: 'foreign' });
          break;
        case 'wrong-isolation':
          changeRow(sequence, 0, { isolation: 'read committed' });
          break;
        case 'missing-session':
          sequence[1]!.rows = [];
          break;
        case 'foreign-subject':
          changeRow(sequence, 1, { loginCoCode: '02' });
          break;
        case 'stale-epoch':
          changeRow(sequence, 1, { contextEpoch: '8' });
          break;
        case 'scope-aba':
          changeRow(sequence, 1, { contextEpoch: '9' });
          break;
        case 'malformed-ledger':
          changeRow(sequence, 1, { ledgerContext: { ...ledger, mode: 'A' } });
          break;
        case 'revoked':
          changeRow(sequence, 2, { revoked: true });
          break;
        case 'expired':
          changeRow(sequence, 2, { unexpired: false });
          break;
        case 'principal-missing':
          sequence[3]!.rows = [];
          break;
        case 'forced-reset':
          changeRow(sequence, 3, { PASSWORD_RESET_REQUIRED: 'Y' });
          break;
        case 'view-denied':
          changeRow(sequence, 7, { FRM_VIEW: 'N', FRM_EDIT: 'Y' });
          break;
        case 'final-expiry':
          changeRow(sequence, 8, { unexpired: false });
          break;
        case 'final-epoch':
          changeRow(sequence, 8, { contextEpoch: '8' });
          break;
        case 'final-ledger':
          changeRow(sequence, 8, {
            ledgerContext: {
              ...ledger,
              reason: 'legacy-session-uninitialized',
            },
          });
          break;
        case 'raw-serialization':
          sequence[1]!.error = { code: '40001' };
          break;
        case 'prisma-conflict':
          commitError = { code: 'P2034' };
          break;
        case 'wrapped-serialization':
          sequence[1]!.error = { code: 'P2010', meta: { code: '40001' } };
          break;
        case 'raw-deadlock':
          sequence[1]!.error = { code: '40P01' };
          break;
        case 'wrapped-deadlock':
          sequence[1]!.error = { code: 'P2010', meta: { code: '40P01' } };
          break;
        case 'connection-failure':
          originalError = Object.assign(new Error('connection-lost'), {
            code: '08006',
          });
          sequence[1]!.error = originalError;
          break;
        case 'unknown-commit':
          originalError = new Error('unknown-commit');
          commitError = originalError;
          break;
        default:
          throw new Error(`Unmapped independent scenario ${scenario}`);
      }
      const db = scripted(sequence, commitError);
      const work = vi.fn(async () => 'command-result');
      const result = withSessionContextSerializableCommand(db.prisma, supplied, fixedPolicy, work);
      if (expected.code === 'success') {
        await expect(result).resolves.toBe('command-result');
        expect(work).toHaveBeenCalledTimes(1);
        expect(db.pending).toHaveLength(0);
      } else if (expected.code === 'propagate-original') {
        await expect(result).rejects.toBe(originalError);
      } else {
        await expect(result).rejects.toMatchObject({
          code: expected.code,
          statusCode: expected.statusCode,
        });
      }
      const afterWork = [
        'ready',
        'final-expiry',
        'final-epoch',
        'final-ledger',
        'prisma-conflict',
        'unknown-commit',
      ];
      expect(work).toHaveBeenCalledTimes(afterWork.includes(scenario) ? 1 : 0);
      expect(db.transaction.mock.calls.length).toBeLessThanOrEqual(1);
      if (scenario === 'view-denied' || scenario === 'update-denied') {
        await expect(result).rejects.toMatchObject({
          form: 'Sales/Sales Return',
          action: 'update',
        });
      }
    },
  );
  it('runs one Serializable transaction; locks SHARE before plain authority reads and checks live context after work', async () => {
    const db = scripted(steps());
    await withSessionContextSerializableCommand(
      db.prisma,
      identity,
      policy,
      async (tx, admitted) => {
        expect(tx).toBe(db.tx);
        expect(admitted.context).toEqual({
          ...identity,
          ledgerContext: ledger,
        });
        expect(admitted.authorization.action).toBe('update');
        expect(admitted.authorization.principal).toBe(admitted.principal);
        for (const value of [
          admitted,
          admitted.context,
          admitted.context.ledgerContext,
          admitted.principal,
          admitted.principal.rights,
          admitted.authorization,
        ])
          expect(Object.isFrozen(value)).toBe(true);
        db.trace.push('work');
      },
    );
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.transaction.mock.calls[0]?.[1]).toEqual({
      ...VOUCHER_BUDGET,
      isolationLevel: 'Serializable',
    });
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
      'work',
      '"expires_at">clock_timestamp()',
      'commit',
    ]);
    expect(db.execute).toHaveBeenCalledTimes(1);
    for (const [sql] of db.query.mock.calls) {
      expect(sql).not.toMatch(/^\s*(UPDATE|INSERT|DELETE)\b/);
      if (/FROM "(?:LOGIN_MAST|USER_SET)"/.test(sql))
        expect(sql).not.toMatch(/FOR\s+(UPDATE|SHARE)/);
      expect(sql).not.toMatch(/SET\s+TRANSACTION.*READ\s+ONLY/i);
    }
  });
  it('detaches supplied identity and policy before the first await', async () => {
    const supplied = mutable(identity);
    const fixedPolicy = mutable(policy);
    const db = scripted(steps());
    const pending = withSessionContextSerializableCommand(
      db.prisma,
      supplied,
      fixedPolicy,
      async (_tx, admitted) => {
        expect(admitted.context).toEqual({
          ...identity,
          ledgerContext: ledger,
        });
        expect(admitted.authorization.form).toBe('Sales/Sales Return');
        return 'detached';
      },
    );
    supplied.contextEpoch = '9';
    supplied.coCode = '02';
    fixedPolicy.scope.coCode = '02';
    fixedPolicy.scope.coBook = 'Z99';
    await expect(pending).resolves.toBe('detached');
    expect(db.query.mock.calls.find(([sql]) => sql.includes('FOR SHARE'))?.slice(1)).toEqual([
      identity.tenantId,
      identity.sessionId,
    ]);
  });
  it.each(['identity', 'policy', 'scope'] as const)(
    'rejects a %s getter without invoking it or opening a transaction',
    async (kind) => {
      const getter = vi.fn(() => {
        throw new Error('getter was invoked');
      });
      const supplied = mutable(identity);
      const fixedPolicy = mutable(policy);
      Object.defineProperty(
        kind === 'identity' ? supplied : kind === 'policy' ? fixedPolicy : fixedPolicy.scope,
        kind === 'identity' ? 'loginName' : kind === 'policy' ? 'scope' : 'coCode',
        { enumerable: true, get: getter },
      );
      const db = scripted([]);
      await expect(
        withSessionContextSerializableCommand(
          db.prisma,
          supplied,
          fixedPolicy,
          async () => undefined,
        ),
      ).rejects.toMatchObject({
        code: kind === 'identity' ? 'session-invalid' : 'invalid-serializable-command-policy',
      });
      expect(getter).not.toHaveBeenCalled();
      expect(db.transaction).not.toHaveBeenCalled();
    },
  );
  it.each(['unknown', 'symbol', 'non-enumerable', 'prototype', 'array', 'null'] as const)(
    'contains %s identity envelope before SQL',
    async (kind) => {
      let supplied: unknown = mutable(identity);
      if (kind === 'unknown') supplied = { ...identity, rights: {} };
      if (kind === 'symbol')
        Object.defineProperty(supplied, Symbol('extra'), {
          value: true,
          enumerable: true,
        });
      if (kind === 'non-enumerable')
        Object.defineProperty(supplied, 'loginName', {
          value: identity.loginName,
          enumerable: false,
        });
      if (kind === 'prototype')
        supplied = Object.assign(Object.create({ inherited: true }), identity);
      if (kind === 'array') supplied = [];
      if (kind === 'null') supplied = null;
      const db = scripted([]);
      await expect(
        withSessionContextSerializableCommand(db.prisma, supplied, policy, async () => undefined),
      ).rejects.toMatchObject({ code: 'session-invalid' });
      expect(db.transaction).not.toHaveBeenCalled();
    },
  );
  it.each(['adminOnly', 'unknown-scope', 'empty-book'] as const)(
    'refuses %s in fixed policy',
    async (kind) => {
      let fixedPolicy = mutable(policy);
      if (kind === 'adminOnly')
        fixedPolicy = {
          ...policy,
          adminOnly: true,
        } as Mutable<SessionSerializableCommandPolicy>;
      if (kind === 'unknown-scope')
        fixedPolicy = {
          ...policy,
          scope: { ...policy.scope, authority: true },
        } as Mutable<SessionSerializableCommandPolicy>;
      if (kind === 'empty-book') fixedPolicy.scope.coBook = '';
      const db = scripted([]);
      await expect(
        withSessionContextSerializableCommand(
          db.prisma,
          identity,
          fixedPolicy,
          async () => undefined,
        ),
      ).rejects.toMatchObject({
        code: kind === 'empty-book' ? 'scope-incomplete' : 'invalid-serializable-command-policy',
      });
      expect(db.transaction).not.toHaveBeenCalled();
    },
  );
  it.each(['9007199254740993', '9223372036854775807'])(
    'preserves epoch %s beyond Number exactly',
    async (epoch) => {
      const sequence = steps();
      changeRow(sequence, 1, { contextEpoch: epoch });
      changeRow(sequence, 8, { contextEpoch: epoch });
      const db = scripted(sequence);
      await expect(
        withSessionContextSerializableCommand(
          db.prisma,
          { ...identity, contextEpoch: epoch },
          policy,
          async (_tx, admitted) => admitted.context.contextEpoch,
        ),
      ).resolves.toBe(epoch);
    },
  );
  it('retains distinct immutable login company and selected credential owner', async () => {
    const sequence = steps();
    changeRow(sequence, 1, { coCode: '02' });
    changeRow(sequence, 8, { coCode: '02' });
    changeRow(sequence, 3, { CO_CODE: '02' });
    changeRow(sequence, 4, { CO_CODE: '02' });
    const db = scripted(sequence);
    await withSessionContextSerializableCommand(
      db.prisma,
      { ...identity, coCode: '02' },
      { ...policy, scope: { ...policy.scope, coCode: '02' } },
      async (_tx, admitted) => {
        expect(admitted.context.loginCoCode).toBe('01');
        expect(admitted.principal.loginCoCode).toBe('02');
      },
    );
    expect(
      db.query.mock.calls.find(([sql]) => sql.includes('FROM "LOGIN_MAST"'))?.slice(1),
    ).toEqual(['operator', '02', '01']);
  });
  it.each([
    'tenantId',
    'sessionId',
    'loginName',
    'loginCoCode',
    'coCode',
    'lcCode',
    'coYear',
  ] as const)('final check does not reduce %s equality to epoch alone', async (field) => {
    const sequence = steps();
    changeRow(sequence, 8, {
      [field]: field === 'coYear' ? '2025-2026' : 'different',
    });
    const db = scripted(sequence);
    const subject = ['tenantId', 'sessionId', 'loginName', 'loginCoCode'].includes(field);
    await expect(
      withSessionContextSerializableCommand(db.prisma, identity, policy, async () => 'discarded'),
    ).rejects.toMatchObject({
      code: subject ? 'session-invalid' : 'context-stale',
    });
    expect(db.trace.at(-1)).toBe('rollback');
  });
  it('preserves a callback failure and does not manufacture a successful final read', async () => {
    const sequence = steps().slice(0, -1);
    const db = scripted(sequence);
    const error = new Error('read-failed');
    await expect(
      withSessionContextSerializableCommand(db.prisma, identity, policy, async () => {
        throw error;
      }),
    ).rejects.toBe(error);
    expect(db.trace.at(-1)).toBe('rollback');
    expect(db.pending).toHaveLength(0);
  });
  it('preserves exact stored-scope error code/status instead of inventing defaults', async () => {
    const sequence = steps();
    sequence[6]!.rows = [];
    const db = scripted(sequence);
    await expect(
      withSessionContextSerializableCommand(db.prisma, identity, policy, async () => undefined),
    ).rejects.toMatchObject({ code: 'year-unavailable', statusCode: 409 });
  });
  it.each(['identity', 'policy', 'scope'] as const)(
    'contains a revoked reflection proxy in %s without SQL',
    async (kind) => {
      const revoked = Proxy.revocable({}, {});
      revoked.revoke();
      const db = scripted([]);
      const supplied = kind === 'identity' ? revoked.proxy : identity;
      const suppliedPolicy =
        kind === 'policy' ? revoked.proxy : kind === 'scope' ? { scope: revoked.proxy } : policy;
      await expect(
        withSessionContextSerializableCommand(
          db.prisma,
          supplied,
          suppliedPolicy as SessionSerializableCommandPolicy,
          async () => undefined,
        ),
      ).rejects.toMatchObject({
        code: kind === 'identity' ? 'session-invalid' : 'invalid-serializable-command-policy',
      });
      expect(db.transaction).not.toHaveBeenCalled();
    },
  );
  it.each(['tenantId', 'coCode', 'lcCode', 'coYear', 'coBook'] as const)(
    'bounds policy %s text without truncation',
    async (field) => {
      const db = scripted([]);
      await expect(
        withSessionContextSerializableCommand(
          db.prisma,
          identity,
          { scope: { ...policy.scope, [field]: 'x'.repeat(256) } },
          async () => undefined,
        ),
      ).rejects.toMatchObject({
        code: 'invalid-serializable-command-policy',
        statusCode: 500,
      });
      expect(db.transaction).not.toHaveBeenCalled();
    },
  );
  it('admin still binds, locks and validates scope; fixed update does not query USER_SET', async () => {
    const sequence = steps();
    changeRow(sequence, 3, { LOGIN_CATG: 'ADMIN' });
    sequence.splice(7, 1);
    const db = scripted(sequence);
    await withSessionContextSerializableCommand(
      db.prisma,
      identity,
      policy,
      async (_tx, admitted) => {
        expect(admitted.principal.isAdmin).toBe(true);
        expect(admitted.authorization).toMatchObject({
          form: 'Sales/Sales Return',
          action: 'update',
        });
      },
    );
    expect(db.pending).toHaveLength(0);
    expect(db.trace).toContain('FOR SHARE');
    expect(db.trace).toContain('FROM "CO_MAST"');
    expect(db.trace).not.toContain('FROM "USER_SET"');
  });

  it.each([
    {
      name: 'numeric',
      value: 17,
      code: 'invalid-serializable-command-policy',
      statusCode: 500,
    },
    {
      name: 'null',
      value: null,
      code: 'invalid-serializable-command-policy',
      statusCode: 500,
    },
    { name: 'blank', value: ' ', code: 'scope-incomplete', statusCode: 409 },
    {
      name: 'padded',
      value: 'R1 ',
      code: 'invalid-serializable-command-policy',
      statusCode: 500,
    },
    {
      name: 'newline',
      value: 'R1\n',
      code: 'invalid-serializable-command-policy',
      statusCode: 500,
    },
  ])(
    'refuses $name policy book without coercion or trimming',
    async ({ value, code, statusCode }) => {
      const db = scripted([]);
      await expect(
        withSessionContextSerializableCommand(
          db.prisma,
          identity,
          {
            scope: { ...policy.scope, coBook: value },
          } as SessionSerializableCommandPolicy,
          async () => undefined,
        ),
      ).rejects.toMatchObject({ code, statusCode });
      expect(db.transaction).not.toHaveBeenCalled();
    },
  );
});
