import Fastify from 'fastify';
import { describe, expect, it, vi } from 'vitest';
import { registerDataRepairRoutes } from '../src/routes/dataRepair.js';
import { applyRepair } from '../src/modules/utilities/dataRepair.js';

vi.mock('../src/modules/utilities/dataRepair.js', async (original) => ({
  ...(await original<typeof import('../src/modules/utilities/dataRepair.js')>()),
  applyRepair: vi.fn(),
}));

describe('Data Refresh database error response', () => {
  it.each([
    { code: 'P2010', message: 'Raw query failed. Message: `ERROR: secret database detail`' },
    { message: 'duplicate key violates constraint: secret database detail' },
  ])('does not disclose database details', async (error) => {
    vi.mocked(applyRepair).mockRejectedValueOnce(error);
    const app = Fastify();
    registerDataRepairRoutes(app, {
      prisma: {},
      auth: { preHandler: async () => {} },
      guard: () => true,
      sess: () => ({ tenantId: 'synthetic', coCode: '01', lcCode: '01', coYear: '2024' }),
      run: async (_reply, _status, fn) => fn(),
    });
    try {
      const response = await app.inject({
        method: 'POST',
        url: '/utilities/data-refresh/data-refresh-account/apply',
        payload: {},
      });
      expect(response.statusCode).toBe(400);
      expect(response.json()).toEqual({
        error: 'invalid-data',
        detail: 'Data Refresh could not be applied because the data is invalid.',
      });
      expect(response.body).not.toContain('secret');
    } finally {
      await app.close();
    }
  });
});
