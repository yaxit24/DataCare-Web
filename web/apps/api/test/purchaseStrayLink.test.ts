import Fastify from 'fastify';
import { describe, expect, it, vi } from 'vitest';
import {
  isSaleLinkedPurchase,
  purchaseSaleLinkStateTx,
} from '../src/modules/purchase/linkedSale.js';
import { registerPurchaseVoucherRoutes } from '../src/routes/purchaseVoucher.js';

const scope = { tenantId: 'synthetic', coCode: '01', lcCode: '02', coBook: '043' };
const header = {
  SL_BILL_NO: '00017 ',
  SL_BILL_LC: '03',
  SL_BILL_YRCD: '2025-2026',
  SL_BILL_DBCD: 'SL ',
};

describe('purchase sale-link metadata', () => {
  it.each([
    ['TAG PURCHASE', header, true],
    ['CON PUR', header, false],
    ['PURCHASE', { SL_BILL_NO: '  ' }, false],
    ['SALES', header, false],
  ])('classifies %s with the shared rule', (book, row, expected) => {
    expect(isSaleLinkedPurchase(book, row)).toBe(expected);
  });
  it('rejects ambiguous active book configuration', async () => {
    const query = vi
      .fn()
      .mockResolvedValue([{ MAIN_BOOK: 'PURCHASE' }, { MAIN_BOOK: 'TAG PURCHASE' }]);
    await expect(
      purchaseSaleLinkStateTx({ $queryRawUnsafe: query }, scope, header),
    ).rejects.toThrow('configuration is ambiguous');
  });
  it('never treats a consignment receipt or an unlinked purchase as a sale link', async () => {
    const query = vi.fn().mockResolvedValue([{ MAIN_BOOK: 'CON PUR' }]);
    expect(await purchaseSaleLinkStateTx({ $queryRawUnsafe: query }, scope, header)).toBeNull();
    expect(query).toHaveBeenCalledTimes(1);
    query.mockClear();
    expect(await purchaseSaleLinkStateTx({ $queryRawUnsafe: query }, scope, {})).toBeNull();
    expect(query).not.toHaveBeenCalled();
  });
  it.each([
    ['PURCHASE ', true],
    ['PURCHASE ', false],
    ['TAG PURCHASE', false],
  ] as const)(
    'returns metadata for %s with exists=%s using all persisted sale-key fields',
    async (mainBook, exists) => {
      const query = vi
        .fn()
        .mockResolvedValueOnce([{ MAIN_BOOK: mainBook }])
        .mockResolvedValueOnce(exists ? [{}] : []);
      expect(await purchaseSaleLinkStateTx({ $queryRawUnsafe: query }, scope, header)).toEqual({
        saleBillNo: '00017',
        saleBillLc: '03',
        saleBillYear: '2025-2026',
        saleBillBook: 'SL',
        exists,
      });
      expect(query.mock.calls[0]?.[0]).toContain('CUR_USE');
      expect(query.mock.calls[0]?.[0]).toContain('ORDER BY row_id');
      expect(query.mock.calls[1]?.slice(1)).toEqual([
        'synthetic',
        '01',
        '03',
        '2025-2026',
        'SL',
        '00017',
      ]);
    },
  );
});

it('stray deletion schema rejects missing version and extra fields before the delete guard', async () => {
  const app = Fastify();
  const guard = vi.fn((_req, reply, action) => {
    reply.code(403).send({ action });
    return false;
  });
  registerPurchaseVoucherRoutes(app, {
    prisma: {},
    auth: {},
    guard,
    scopeOf: () => scope,
    run: async () => {
      throw new Error('must not reach the writer');
    },
    body: () => ({}),
    mainUserOf: () => 'synthetic',
    purchaseInput: () => ({}),
  } as any);
  try {
    const url = '/purchases/00001/delete-stray-link?coBook=043';
    for (const [suffix, payload] of [
      ['', {}],
      ['&expectedVersion=v&unexpected=x', {}],
      ['&expectedVersion=v', { bypass: true }],
    ] as const) {
      const response = await app.inject({ method: 'POST', url: url + suffix, payload });
      expect(response.statusCode, response.body).toBe(400);
    }
    expect(guard).not.toHaveBeenCalled();
    const valid = await app.inject({
      method: 'POST',
      url: url + '&expectedVersion=v',
      payload: {},
    });
    expect(valid.statusCode).toBe(403);
    expect(valid.json()).toEqual({ action: 'delete' });
  } finally {
    await app.close();
  }
});
