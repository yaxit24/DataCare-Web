import { readFileSync } from 'node:fs';
import { resolve } from 'node:path';
import { describe, expect, it } from 'vitest';
import {
  PARITY_CONTAINMENT_CODE,
  parityContainmentMessage,
  parityContainmentOperations,
  parityContainmentProblem,
  parityContainmentRule,
} from '../containment.mjs';

const expectedOperations = [
  'logical-restore',
  'production-cutover-load',
  'tag-weight-difference',
] as const;

/** Released with their own evidence (N18/N19); they must never silently return to the registry. */
const dischargedOperations = [
  'tag-opening-update',
  'tag-transfer',
  'tag-cancel',
  'tag-split',
] as const;

describe('WP-01 parity containment policy', () => {
  it('fails closed for every reviewed unsafe mutation with no environment bypass', () => {
    process.env.PARITY_UNSAFE_MUTATIONS = '*';
    try {
      expect(parityContainmentOperations).toEqual(expectedOperations);
      for (const operation of expectedOperations) {
        const rule = parityContainmentRule(operation);
        expect(rule).toMatchObject({ operation, blocked: true, workPackage: 'WP-01' });
        expect(rule.reason).not.toHaveLength(0);
        expect(rule.safeAlternative).not.toHaveLength(0);
        expect(rule.exitGate).not.toHaveLength(0);
      }
    } finally {
      delete process.env.PARITY_UNSAFE_MUTATIONS;
    }
  });

  it('returns a stable non-retryable HTTP problem without exposing an override', () => {
    const problem = parityContainmentProblem('tag-weight-difference');
    expect(problem).toEqual({
      statusCode: 503,
      body: {
        error: 'parity-containment',
        code: PARITY_CONTAINMENT_CODE,
        operation: 'tag-weight-difference',
        message: parityContainmentMessage('tag-weight-difference'),
        reason: parityContainmentRule('tag-weight-difference').reason,
        safeAlternative: parityContainmentRule('tag-weight-difference').safeAlternative,
        exitGate: parityContainmentRule('tag-weight-difference').exitGate,
        workPackage: 'WP-01',
        retryable: false,
      },
    });
    expect(Object.isFrozen(problem)).toBe(true);
    expect(Object.isFrozen(problem?.body)).toBe(true);
  });

  it('rejects unknown operation names instead of silently allowing them', () => {
    expect(() => parityContainmentRule('unknown' as never)).toThrow(
      'Unknown parity containment operation',
    );
  });

  it('keeps discharged operations out of the registry, and cites their evidence', () => {
    for (const operation of dischargedOperations) {
      expect(parityContainmentOperations).not.toContain(operation);
      expect(() => parityContainmentRule(operation as never)).toThrow(
        'Unknown parity containment operation',
      );
    }
    const registry = readFileSync(resolve(process.cwd(), 'containment.mjs'), 'utf8');
    expect(registry).toContain('DISCHARGED — `tag-cancel` and `tag-transfer`');
    expect(registry).toContain('implementation-2026-09-29-n18/contract.md');
    expect(registry).toContain('DISCHARGED — `tag-split`');
    expect(registry).toContain('implementation-2026-09-30-n19/contract.md');
  });

  it('guards the restore-drill CLI before database configuration or client construction', () => {
    const script = readFileSync(resolve(process.cwd(), '../../scripts/restore-drill.mjs'), 'utf8');
    const guard = script.indexOf("parityContainmentProblem('logical-restore')");
    const databaseConfig = script.indexOf('const databaseUrl = process.env.DATABASE_URL');
    const client = script.indexOf('const prisma = new PrismaClient');
    expect(guard).toBeGreaterThan(-1);
    expect(script).toContain('process.exit(1)');
    expect(guard).toBeLessThan(databaseConfig);
    expect(guard).toBeLessThan(client);
  });
});
