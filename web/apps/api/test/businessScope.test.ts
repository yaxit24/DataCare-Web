import { describe, expect, it, vi } from 'vitest';
import { enforceRequestScope, ScopeError } from '../src/modules/auth/businessScope.js';

function db(rows: unknown[]) {
  const tx = {
    $executeRawUnsafe: vi.fn().mockResolvedValue(1),
    $queryRawUnsafe: vi.fn().mockResolvedValue(rows),
  };
  return { prisma: { $transaction: (fn: (arg: typeof tx) => unknown) => fn(tx) }, tx };
}

const session = { tenantId: 't1', coCode: '01', lcCode: '02', coYear: '2024-2025' };
const req = (body: unknown = {}, query: unknown = {}) => ({ body, query }) as any;

describe('authoritative request business scope', () => {
  it('rejects company, location, and year override attempts before a query runs', async () => {
    for (const body of [{ coCode: '99' }, { LC_CODE: '03' }, { coYear: '2023-2024' }]) {
      const { prisma, tx } = db([]);
      await expect(enforceRequestScope(prisma, req(body), session)).rejects.toMatchObject({
        code: 'scope-mismatch',
      });
      expect(tx.$queryRawUnsafe).not.toHaveBeenCalled();
    }
  });

  it('accepts repeated matching scope only as a compatibility assertion, not an override', async () => {
    const { prisma } = db([]);
    await expect(
      enforceRequestScope(
        prisma,
        req({ coCode: '01', lcCode: '02', coYear: '2024-2025' }),
        session,
      ),
    ).resolves.toEqual(session);
  });

  it('attaches a book only after BOOK_DATA validates it for company and location', async () => {
    const { prisma, tx } = db([{ '?column?': 1 }]);
    await expect(enforceRequestScope(prisma, req({ coBook: 'SAL' }), session)).resolves.toEqual({
      ...session,
      coBook: 'SAL',
    });
    const query = tx.$queryRawUnsafe.mock.calls.find((call) =>
      String(call[0]).includes('FROM "BOOK_DATA"'),
    );
    expect(query?.slice(1)).toEqual(['01', 'SAL', '02']);
  });

  it('rejects an unavailable or conflicting book', async () => {
    const { prisma } = db([]);
    await expect(
      enforceRequestScope(prisma, req({ coBook: 'BAD' }), session),
    ).rejects.toBeInstanceOf(ScopeError);
    await expect(
      enforceRequestScope(prisma, req({ coBook: 'SAL', book: 'PUR' }), session),
    ).rejects.toMatchObject({ code: 'scope-mismatch' });
  });

  it('requires a server-selected complete context', async () => {
    const { prisma } = db([]);
    await expect(
      enforceRequestScope(prisma, req(), { ...session, coYear: undefined }),
    ).rejects.toMatchObject({ code: 'scope-incomplete' });
  });
});
