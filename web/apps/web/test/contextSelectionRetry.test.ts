import { beforeEach, describe, expect, it, vi } from 'vitest';

const post = vi.fn();
vi.mock('../lib/api', async () => {
  const actual = await vi.importActual<typeof import('../lib/api')>('../lib/api');
  return { ...actual, post: (path: string, body: unknown) => post(path, body) };
});

const { ApiError } = await import('../lib/api');
const { postSelectionRetryingConflicts, CONFLICT_RETRY_DELAYS_MS } =
  await import('../lib/contextSelection');

const pending = { request: { selectionId: 'sel-1', coCode: '01' } } as never;
const conflict = () =>
  new ApiError('context-transaction-conflict', 409, { error: 'context-transaction-conflict' });
const ok = { context: {}, scoped: true, replayed: false };

describe('postSelectionRetryingConflicts (G172)', () => {
  beforeEach(() => {
    post.mockReset();
  });

  it('sends the same selection again after a transaction conflict', async () => {
    post.mockRejectedValueOnce(conflict()).mockResolvedValueOnce(ok);
    const waits: number[] = [];
    const result = await postSelectionRetryingConflicts(
      pending,
      () => true,
      async (ms) => {
        waits.push(ms);
      },
    );
    expect(result).toBe(ok);
    expect(post).toHaveBeenCalledTimes(2);
    expect(
      post.mock.calls.every(
        ([path, body]) => path === '/context/select' && body === (pending as any).request,
      ),
    ).toBe(true);
    expect(waits).toHaveLength(1);
    expect(waits[0]).toBeGreaterThanOrEqual(CONFLICT_RETRY_DELAYS_MS[0]);
    expect(waits[0]).toBeLessThan(CONFLICT_RETRY_DELAYS_MS[0] + 100);
  });

  it('gives up after the last retry with the conflict', async () => {
    post.mockImplementation(async () => {
      throw conflict();
    });
    await expect(
      postSelectionRetryingConflicts(
        pending,
        () => true,
        async () => {},
      ),
    ).rejects.toMatchObject({
      status: 409,
      body: { error: 'context-transaction-conflict' },
    });
    expect(post).toHaveBeenCalledTimes(CONFLICT_RETRY_DELAYS_MS.length + 1);
  });

  it('never retries another refusal, or after the page left', async () => {
    post.mockImplementation(async () => {
      throw new ApiError('context-stale', 409, { error: 'context-stale' });
    });
    await expect(
      postSelectionRetryingConflicts(
        pending,
        () => true,
        async () => {},
      ),
    ).rejects.toMatchObject({
      body: { error: 'context-stale' },
    });
    expect(post).toHaveBeenCalledTimes(1);
    post.mockReset();
    post.mockImplementation(async () => {
      throw conflict();
    });
    await expect(
      postSelectionRetryingConflicts(
        pending,
        () => false,
        async () => {},
      ),
    ).rejects.toMatchObject({
      status: 409,
    });
    expect(post).toHaveBeenCalledTimes(1);
  });
});
