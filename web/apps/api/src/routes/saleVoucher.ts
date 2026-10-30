import type { FastifyInstance, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import { deleteSale, editSale, getSale } from '../modules/sales/sales.js';
import { requiredVersion } from '../modules/vouchers/version.js';

/**
 * A saved sale: read, update and delete (TR_SALE). The read returns the voucher's `version`; an update sends it in the
 * body and a delete in the query as `expectedVersion`, and a stale one is `409 voucher-version-conflict` (N51, D17,
 * G170). Moved out of routes/txn.ts with the version token, to keep that file within its size budget.
 */
export function registerSaleVoucherRoutes(
  app: FastifyInstance,
  h: Pick<
    CrmRouteHelpers,
    'prisma' | 'auth' | 'guard' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'
  > & {
    saleInput: (req: FastifyRequest, b: Record<string, any>) => any;
  },
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf, saleInput } = h;
  app.get('/sales/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getSale(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/sales/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, async () =>
      editSale(
        prisma,
        saleInput(req, b),
        b.lines ?? [],
        (req.params as any).vchNo,
        requiredVersion(b.expectedVersion),
      ),
    );
  });
  app.delete('/sales/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, async () =>
      deleteSale(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: mainUserOf(req),
        expectedVersion: requiredVersion((req.query as any)?.expectedVersion),
      }),
    );
  });
}
