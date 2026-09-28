import { createHash } from 'node:crypto';
import { readFileSync } from 'node:fs';
import { withTenant, type Tx } from '@datacare/db';
import type { PrismaClient } from '@prisma/client';
import { describe, expect, it, vi } from 'vitest';
import { validateStoredScopeTx } from '../src/modules/auth/businessScope.js';
import independent from './fixtures/storedScope.independent.json';

interface ReadStep {
  table: string;
  params: unknown[];
  rows: unknown[];
  errorMessage?: string;
}
interface Decision {
  id: string;
  reason: string;
  input: Record<string, unknown>;
  queries: ReadStep[];
  expected: { value?: Record<string, unknown>; errorCode?: string };
  ownUndefinedInputKeys?: string[];
  ownUndefinedOutputKeys?: string[];
  sameErrorIdentity?: boolean;
}
const decisions: Decision[] = independent.cases;

/** Literal ordered observations, not a SQL emulator or a live transaction. */
function scriptedTransaction(steps: ReadStep[], tenantId: string) {
  const pending = [...steps];
  const trace: string[] = [];
  const sentinel = new Error('stored-scope-query-sentinel');
  const query = vi.fn(async (sql: string, ...params: unknown[]) => {
    const next = pending.shift();
    if (!next) throw new Error(`Unexpected read: ${sql}`);
    expect(sql).toContain(`FROM "${next.table}"`);
    expect(sql).not.toMatch(/FOR\s+(?:UPDATE|SHARE)/i);
    expect(params).toStrictEqual(next.params);
    trace.push(`read:${next.table}`);
    if (next.errorMessage) {
      expect(next.errorMessage).toBe(sentinel.message);
      throw sentinel;
    }
    return structuredClone(next.rows);
  });
  const execute = vi.fn(async (sql: string, ...params: unknown[]) => {
    expect(sql).toBe("SELECT set_config('app.tenant_id', $1, true)");
    expect(params).toStrictEqual([tenantId]);
    trace.push('bind');
    return 1;
  });
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
  return { tx, prisma, query, execute, transaction, pending, trace, sentinel };
}

function decisionInput(fixture: Decision) {
  const value = structuredClone(fixture.input);
  for (const key of fixture.ownUndefinedInputKeys ?? []) value[key] = undefined;
  // The frozen negative transport/corrupt-observation cases intentionally cross the typed boundary.
  return value as unknown as Parameters<typeof validateStoredScopeTx>[1];
}

describe('validateStoredScopeTx exact persisted decisions', () => {
  it.each(decisions)('$id $reason', async (fixture) => {
    const input = decisionInput(fixture);
    const before = structuredClone(input);
    const queriesBefore = structuredClone(fixture.queries);
    const db = scriptedTransaction(fixture.queries, input.tenantId);
    const result = validateStoredScopeTx(db.tx, input);
    if (fixture.sameErrorIdentity) {
      await expect(result).rejects.toBe(db.sentinel);
    } else if (fixture.expected.errorCode) {
      await expect(result).rejects.toMatchObject({
        name: 'ScopeError',
        code: fixture.expected.errorCode,
        statusCode: 409,
      });
    } else {
      if (!fixture.expected.value) throw new Error(`Missing expected value: ${fixture.id}`);
      const expected = { ...fixture.expected.value };
      for (const key of fixture.ownUndefinedOutputKeys ?? []) expected[key] = undefined;
      await expect(result).resolves.toStrictEqual(expected);
    }
    expect(db.pending).toHaveLength(0);
    expect(db.query).toHaveBeenCalledTimes(fixture.queries.length);
    expect(db.trace).toStrictEqual(fixture.queries.map((step) => `read:${step.table}`));
    expect(db.execute).not.toHaveBeenCalled();
    expect(db.transaction).not.toHaveBeenCalled();
    expect(input).toStrictEqual(before);
    expect(fixture.queries).toStrictEqual(queriesBefore);
  });

  it('retains the literal preimplementation decisions byte for byte', () => {
    const bytes = readFileSync(new URL('./fixtures/storedScope.independent.json', import.meta.url));
    expect(createHash('sha256').update(bytes).digest('hex')).toBe(
      '93c5dbdefd8d14cfef0718ca314e0c7cd7a84f961c587ce2298d752703711979',
    );
    expect(decisions).toHaveLength(16);
  });

  it('uses the caller tenant transaction once, without rebinding or opening a nested transaction', async () => {
    const fixture = decisions.find((item) => item.id === 'S01');
    if (!fixture) throw new Error('Missing S01');
    const input = decisionInput(fixture);
    const db = scriptedTransaction(fixture.queries, input.tenantId);
    const result = await withTenant(db.prisma, input.tenantId, (tx) =>
      validateStoredScopeTx(tx, input),
    );
    expect(result).toStrictEqual(fixture.expected.value);
    expect(db.trace).toStrictEqual([
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
});
