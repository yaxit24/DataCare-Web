import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import { deletePurchase, editPurchase, getPurchase } from '../modules/purchase/purchase.js';
import { requiredVersion } from '../modules/vouchers/version.js';

/**
 * A saved purchase, and a saved consignment purchase (TR_PURC): read, update and delete. The read returns the voucher's
 * `version`; an update sends it in the body and a delete in the query as `expectedVersion`, and a stale one is
 * `409 voucher-version-conflict` (N51, D17, G170). Moved out of routes/txn.ts with the version token.
 */
export function registerPurchaseVoucherRoutes(
  app: FastifyInstance,
  h: Pick<
    CrmRouteHelpers,
    'prisma' | 'auth' | 'guard' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'
  > & {
    purchaseInput: (req: FastifyRequest, b: Record<string, any>) => any;
  },
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf, purchaseInput } = h;
  const read = async (req: FastifyRequest, reply: FastifyReply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getPurchase(prisma, scopeOf(req), (req.params as any).vchNo));
  };
  const update = async (req: FastifyRequest, reply: FastifyReply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, async () =>
      editPurchase(
        prisma,
        purchaseInput(req, b),
        b.lines ?? [],
        (req.params as any).vchNo,
        requiredVersion(b.expectedVersion),
      ),
    );
  };
  const remove = async (req: FastifyRequest, reply: FastifyReply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, async () =>
      deletePurchase(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: mainUserOf(req),
        expectedVersion: requiredVersion((req.query as any)?.expectedVersion),
      }),
    );
  };
  // Literal paths: the route registry, its tests and docs_check read them from this file.
  app.get('/purchases/:vchNo', auth as any, read);
  app.put('/purchases/:vchNo', auth as any, update);
  app.delete('/purchases/:vchNo', auth as any, remove);
  app.get('/consignment-purchases/:vchNo', auth as any, read);
  app.put('/consignment-purchases/:vchNo', auth as any, update);
  app.delete('/consignment-purchases/:vchNo', auth as any, remove);
}
