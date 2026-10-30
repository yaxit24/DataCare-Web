import type { FastifyInstance, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import { neighbourVoucher, recentVouchers } from '../modules/vouchers/list.js';

/**
 * Voucher screen navigation: the recent-voucher list and the voucher number box's Up and Down keys (N172, G179).
 * Both are read-only and scoped to the session's company, location and year. A session without a year finds nothing
 * (fail closed) instead of searching every year's vouchers.
 */
export function registerVoucherNavigationRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'run'>,
): void {
  const { prisma, auth, scopeOf, run } = h;
  const listScope = (req: FastifyRequest) => {
    const s = scopeOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear ?? '' };
  };
  app.get('/vouchers/recent', auth as any, async (req) => {
    const qy = (req.query as Record<string, string | undefined>) || {};
    return recentVouchers(
      prisma,
      listScope(req),
      String(qy.table ?? ''),
      String(qy.book ?? ''),
      qy.limit ? Number(qy.limit) : 50,
    );
  });
  app.get('/vouchers/neighbour', auth as any, async (req, reply) => {
    const qy = (req.query as Record<string, string | undefined>) || {};
    return run(reply, 200, () =>
      neighbourVoucher(
        prisma,
        listScope(req),
        String(qy.table ?? ''),
        String(qy.book ?? ''),
        String(qy.from ?? ''),
        String(qy.direction ?? ''),
      ),
    );
  });
}
