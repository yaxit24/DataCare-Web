import { describe, expect, it, vi } from 'vitest';
import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { withTenant, type Tx } from '@datacare/db';
import type { PrismaClient } from '@prisma/client';
import {
  resolveLoginScope,
  resolveLoginScopeTx,
  resolveSelectedScope,
  resolveSelectedScopeTx,
  ScopeError,
} from '../src/modules/auth/businessScope.js';
import { loadPrincipal, loadPrincipalTx } from '../src/modules/rbac/authorization.js';
import independent from './fixtures/sessionContext.extraction.independent.json';

interface ReadStep {
  table: string;
  params: unknown[];
  rows?: unknown[];
  error?: Error;
}

/**
 * A transaction-boundary double, not a SQL/database emulator. Each read receives a literal,
 * preordered database result. The real withTenant helper supplies the tenant binding.
 */
function scriptedDb(steps: ReadStep[], bindingError?: Error, tenantId = 'tenant-scope-extraction') {
  const pending = [...steps];
  const trace: string[] = [];
  const query = vi.fn(async (sql: string, ...params: unknown[]) => {
    const next = pending.shift();
    if (!next) throw new Error(`Unexpected extra read: ${sql}`);
    expect(sql).toContain(`FROM "${next.table}"`);
    expect(sql).not.toMatch(/FOR\s+(?:UPDATE|SHARE)/i);
    expect(params).toEqual(next.params);
    trace.push(`read:${next.table}`);
    if (next.error) throw next.error;
    return structuredClone(next.rows ?? []);
  });
  const execute = vi.fn(async (sql: string, ...params: unknown[]) => {
    expect(sql).toBe("SELECT set_config('app.tenant_id', $1, true)");
    trace.push('bind');
    if (bindingError) throw bindingError;
    expect(params).toEqual([tenantId]);
    return 1;
  });
  // Only these raw methods are exercised. This explicit double does not claim to be a live Tx.
  const tx = { $queryRawUnsafe: query, $executeRawUnsafe: execute } as unknown as Tx;
  const transaction = vi.fn(async (fn: (value: Tx) => Promise<unknown>, options?: unknown) => {
    expect(options).toBeUndefined();
    trace.push('begin');
    try {
      const result = await fn(tx);
      trace.push('commit');
      return result;
    } catch (error) {
      trace.push('rollback');
      throw error;
    }
  });
  const prisma = { $transaction: transaction } as unknown as PrismaClient;
  return { prisma, tx, trace, transaction, query, execute, pending };
}

const login = { tenantId: 'tenant-scope-extraction', coCode: '02' };
const selected = { ...login, loginName: 'operator', isAdmin: false };
const principalInput = { ...login, loginName: 'operator', loginCoCode: '01' };
const principalRow = {
  CO_CODE: '02',
  LOGIN_NAME: 'operator',
  LOGIN_PWD: 'unchanged-secret-sentinel',
  LOGIN_CATG: 'USER',
  USER_UPDATE: 'Y',
  USER_DELETE: 'N',
  USER_PRINT: '1',
  PASSWORD_RESET_REQUIRED: 'TRUE',
};
const companyStep = (admin = false, name = 'operator'): ReadStep => ({
  table: 'CO_MAST',
  params: ['02', name, admin],
  rows: [{ CO_CODE: '02', LC_CODE: '03', allowed: true }],
});
const locationStep = (): ReadStep => ({
  table: 'LOCT_MAST',
  params: ['02', '', '03'],
  rows: [{ LC_CODE: '03' }],
});
const yearStep = (): ReadStep => ({
  table: 'YEAR_MAST',
  params: ['02', ''],
  rows: [{ year: '2025' }],
});
const principalStep = (): ReadStep => ({
  table: 'LOGIN_MAST',
  params: ['operator', '02', '01'],
  rows: [principalRow],
});

interface DecisionCase {
  id: string;
  reason: string;
  operation: string;
  input: {
    tenantId: string;
    coCode: string;
    lcCode?: string;
    coYear?: string;
    loginName?: string;
    isAdmin?: boolean;
    loginCoCode?: string;
  };
  queries: ReadStep[];
  expected: {
    value?: Record<string, unknown>;
    ownUndefinedKeys?: string[];
    errorName?: string;
    errorCode?: string;
    errorMessage?: string;
  };
}

// The independent reviewer froze these literals before inspecting the staged implementation.
const decisions: DecisionCase[] = independent.cases;
function invokeDecision(
  fixture: DecisionCase,
  db: ReturnType<typeof scriptedDb>,
  viaWrapper: boolean,
) {
  const input = fixture.input;
  if (fixture.operation === 'login') {
    return viaWrapper ? resolveLoginScope(db.prisma, input) : resolveLoginScopeTx(db.tx, input);
  }
  if (fixture.operation === 'selected') {
    if (typeof input.loginName !== 'string' || typeof input.isAdmin !== 'boolean') {
      throw new Error(`Malformed independent selected fixture ${fixture.id}`);
    }
    const selectedInput = { ...input, loginName: input.loginName, isAdmin: input.isAdmin };
    return viaWrapper
      ? resolveSelectedScope(db.prisma, selectedInput)
      : resolveSelectedScopeTx(db.tx, selectedInput);
  }
  if (fixture.operation === 'principal') {
    if (typeof input.loginName !== 'string' || typeof input.loginCoCode !== 'string') {
      throw new Error(`Malformed independent principal fixture ${fixture.id}`);
    }
    const principal = { ...input, loginName: input.loginName, loginCoCode: input.loginCoCode };
    return viaWrapper ? loadPrincipal(db.prisma, principal) : loadPrincipalTx(db.tx, principal);
  }
  throw new Error(`Unknown independent operation ${fixture.operation}`);
}

describe.each([false, true])('independent decision fixtures; public wrapper=%s', (viaWrapper) => {
  it.each(decisions)('$id $reason', async (fixture) => {
    const inputBefore = structuredClone(fixture.input);
    const queriesBefore = structuredClone(fixture.queries);
    const db = scriptedDb(fixture.queries, undefined, fixture.input.tenantId);
    const outcome = invokeDecision(fixture, db, viaWrapper);
    if (fixture.expected.errorName) {
      const expected: Record<string, unknown> = { name: fixture.expected.errorName };
      if (fixture.expected.errorCode) expected.code = fixture.expected.errorCode;
      if (fixture.expected.errorMessage) expected.message = fixture.expected.errorMessage;
      await expect(outcome).rejects.toMatchObject(expected);
    } else {
      if (!fixture.expected.value) throw new Error(`Missing expected value ${fixture.id}`);
      const expected = { ...fixture.expected.value };
      for (const key of fixture.expected.ownUndefinedKeys ?? []) expected[key] = undefined;
      await expect(outcome).resolves.toStrictEqual(expected);
    }
    expect(db.pending).toHaveLength(0);
    expect(db.query).toHaveBeenCalledTimes(fixture.queries.length);
    expect(db.transaction).toHaveBeenCalledTimes(viaWrapper ? 1 : 0);
    expect(db.execute).toHaveBeenCalledTimes(viaWrapper ? 1 : 0);
    const reads = fixture.queries.map((query) => `read:${query.table}`);
    expect(db.trace).toEqual(
      viaWrapper
        ? ['begin', 'bind', ...reads, fixture.expected.errorName ? 'rollback' : 'commit']
        : reads,
    );
    expect(fixture.input).toStrictEqual(inputBefore);
    expect(fixture.queries).toStrictEqual(queriesBefore);
  });
});

describe('session-context transaction extraction boundaries', () => {
  it('pins the independently authored decision fixture and all 31 cases', () => {
    const bytes = readFileSync(
      new URL('./fixtures/sessionContext.extraction.independent.json', import.meta.url),
    );
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '5fb741ce33c4615e1c1f905aef9dabf86ef97a58ca1514a56fe44bb46827c8d7',
    );
    expect(decisions).toHaveLength(31);
  });

  it('login binds once before all three reads and preserves optional-year output shape', async () => {
    const db = scriptedDb([companyStep(true, ''), locationStep(), { ...yearStep(), rows: [] }]);
    const result = await resolveLoginScope(db.prisma, login);
    expect(result).toStrictEqual({ ...login, lcCode: '03', coYear: undefined });
    expect(db.trace).toEqual([
      'begin',
      'bind',
      'read:CO_MAST',
      'read:LOCT_MAST',
      'read:YEAR_MAST',
      'commit',
    ]);
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.execute).toHaveBeenCalledTimes(1);
    expect(db.pending).toHaveLength(0);
  });

  it('selection binds once and keeps selected-user membership parameters', async () => {
    const db = scriptedDb([companyStep(), locationStep(), yearStep()]);
    await expect(resolveSelectedScope(db.prisma, selected)).resolves.toStrictEqual({
      ...login,
      lcCode: '03',
      coYear: '2025',
    });
    expect(db.trace).toEqual([
      'begin',
      'bind',
      'read:CO_MAST',
      'read:LOCT_MAST',
      'read:YEAR_MAST',
      'commit',
    ]);
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.execute).toHaveBeenCalledTimes(1);
    expect(db.pending).toHaveLength(0);
  });

  it('principal wrapper binds once, preserves credential-owner output, and never exposes the password', async () => {
    const db = scriptedDb([principalStep()]);
    await expect(loadPrincipal(db.prisma, principalInput)).resolves.toStrictEqual({
      loginName: 'operator',
      loginCoCode: '02',
      role: 'USER',
      isAdmin: false,
      rights: { userUpdate: true, userDelete: false, userPrint: true },
      passwordResetRequired: true,
    });
    expect(db.trace).toEqual(['begin', 'bind', 'read:LOGIN_MAST', 'commit']);
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.execute).toHaveBeenCalledTimes(1);
  });

  it('composes selection and principal reads in one caller-owned tenant transaction', async () => {
    const db = scriptedDb([companyStep(), locationStep(), yearStep(), principalStep()]);
    const result = await withTenant(db.prisma, login.tenantId, async (tx) => ({
      scope: await resolveSelectedScopeTx(tx, selected),
      principal: await loadPrincipalTx(tx, principalInput),
    }));
    expect(result.scope).toStrictEqual({ ...login, lcCode: '03', coYear: '2025' });
    expect(result.principal.loginCoCode).toBe('02');
    expect(db.trace).toEqual([
      'begin',
      'bind',
      'read:CO_MAST',
      'read:LOCT_MAST',
      'read:YEAR_MAST',
      'read:LOGIN_MAST',
      'commit',
    ]);
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.execute).toHaveBeenCalledTimes(1);
    expect(db.pending).toHaveLength(0);
  });

  it('direct login Tx helper neither begins nor binds a second transaction', async () => {
    const db = scriptedDb([companyStep(true, ''), locationStep(), yearStep()]);
    await expect(resolveLoginScopeTx(db.tx, login)).resolves.toStrictEqual({
      ...login,
      lcCode: '03',
      coYear: '2025',
    });
    expect(db.trace).toEqual(['read:CO_MAST', 'read:LOCT_MAST', 'read:YEAR_MAST']);
    expect(db.transaction).not.toHaveBeenCalled();
    expect(db.execute).not.toHaveBeenCalled();
  });

  it('tenant binding failure performs no scope or principal read', async () => {
    const failure = new Error('tenant binding failed');
    const db = scriptedDb([], failure);
    await expect(resolveSelectedScope(db.prisma, selected)).rejects.toBe(failure);
    expect(db.trace).toEqual(['begin', 'bind', 'rollback']);
    expect(db.query).not.toHaveBeenCalled();
  });

  it('late selection denial rejects the same transaction without a success result', async () => {
    const db = scriptedDb([companyStep(), locationStep(), { ...yearStep(), rows: [] }]);
    await expect(resolveSelectedScope(db.prisma, selected)).rejects.toMatchObject({
      name: 'ScopeError',
      code: 'year-unavailable',
      statusCode: 409,
    });
    expect(db.trace).toEqual([
      'begin',
      'bind',
      'read:CO_MAST',
      'read:LOCT_MAST',
      'read:YEAR_MAST',
      'rollback',
    ]);
    expect(db.transaction).toHaveBeenCalledTimes(1);
    expect(db.pending).toHaveLength(0);
  });

  it('unavailable company stops before location/year reads and retains ScopeError identity', async () => {
    const db = scriptedDb([{ ...companyStep(), rows: [{ CO_CODE: '02', allowed: false }] }]);
    await expect(resolveSelectedScope(db.prisma, selected)).rejects.toBeInstanceOf(ScopeError);
    expect(db.trace).toEqual(['begin', 'bind', 'read:CO_MAST', 'rollback']);
  });

  it('query failure escapes unchanged and prevents later principal reads in a composed transaction', async () => {
    const failure = new Error('query failure sentinel');
    const db = scriptedDb([companyStep(), { ...locationStep(), error: failure }]);
    await expect(
      withTenant(db.prisma, login.tenantId, async (tx) => {
        await resolveSelectedScopeTx(tx, selected);
        return loadPrincipalTx(tx, principalInput);
      }),
    ).rejects.toBe(failure);
    expect(db.trace).toEqual(['begin', 'bind', 'read:CO_MAST', 'read:LOCT_MAST', 'rollback']);
    expect(db.query).toHaveBeenCalledTimes(2);
  });
});
