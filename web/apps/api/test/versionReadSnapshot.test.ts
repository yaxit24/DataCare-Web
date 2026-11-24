import { describe, expect, it, vi } from 'vitest';
import { readRateCut } from '../src/modules/sales/rateCut.js';
import { getTagAdjust } from '../src/modules/stock/tagAdjust.js';

/**
 * N51 (D17): a GET that returns a `version` must read its rows and compute the token from one snapshot,
 * or a commit between the two statements hands out the old data with the new token. Both reads must run
 * under SNAPSHOT_READ (REPEATABLE READ). The transaction is refused before its body runs, so this needs no database.
 */
describe('version-returning GETs use the snapshot profile', () => {
  const scope = { tenantId: 't', coCode: '01', lcCode: '01', coYear: '2024-2025', coBook: 'RCT' };
  async function isolationOf(call: (prisma: any) => Promise<unknown>): Promise<unknown> {
    const $transaction = vi.fn(async () => {
      throw new Error('stop before the body');
    });
    await expect(call({ $transaction })).rejects.toThrow('stop before the body');
    return ($transaction.mock.calls[0] as unknown[] | undefined)?.[1];
  }

  it('Rate Cut / quotation read (rows + readWholesaleExtras token)', async () => {
    expect(await isolationOf((p) => readRateCut(p, scope as any, 1))).toMatchObject({
      isolationLevel: 'RepeatableRead',
    });
  });

  it('Tag Adjust load', async () => {
    expect(
      await isolationOf((p) => getTagAdjust(p, { ...scope, coBook: 'TAD' } as any, 1)),
    ).toMatchObject({
      isolationLevel: 'RepeatableRead',
    });
  });
});
