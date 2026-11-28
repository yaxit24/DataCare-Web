import { deleteStrayPurchase } from '../modules/purchase/strayLink.js';
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
  app.post(
    '/purchases/:vchNo/delete-stray-link',
    {
      ...(auth as any),
      // Fastify's default AJV removes unknown keys; reject them before schema validation instead.
      preValidation: async (req, reply) => {
        const query = req.query as Record<string, unknown>;
        const body = req.body;
        if (
          Object.keys(query).some((key) => !['coBook', 'expectedVersion'].includes(key)) ||
          (body !== undefined &&
            (body === null ||
              typeof body !== 'object' ||
              Array.isArray(body) ||
              Object.keys(body).length))
        ) {
          return reply
            .code(400)
            .send({ error: 'invalid-request', message: 'Unexpected stray-link deletion fields' });
        }
      },
      schema: {
        params: {
          type: 'object',
          additionalProperties: false,
          required: ['vchNo'],
          properties: { vchNo: { type: 'string', minLength: 1, maxLength: 10 } },
        },
        querystring: {
          type: 'object',
          additionalProperties: false,
          required: ['coBook', 'expectedVersion'],
          properties: {
            coBook: { type: 'string', minLength: 1, maxLength: 3 },
            expectedVersion: { type: 'string', minLength: 1 },
          },
        },
        body: { type: 'object', additionalProperties: false, properties: {} },
      },
    },
    async (req, reply) => {
      if (!guard(req, reply, 'delete')) return;
      return run(reply, 200, () =>
        deleteStrayPurchase(prisma, {
          scope: scopeOf(req),
          vchNo: (req.params as any).vchNo,
          deleteUser: mainUserOf(req),
          expectedVersion: requiredVersion((req.query as any)?.expectedVersion),
        }),
      );
    },
  );
  // Literal paths: the route registry, its tests and docs_check read them from this file.
  app.get('/purchases/:vchNo', auth as any, read);
  app.put('/purchases/:vchNo', auth as any, update);
  app.delete('/purchases/:vchNo', auth as any, remove);
  app.get('/consignment-purchases/:vchNo', auth as any, read);
  app.put('/consignment-purchases/:vchNo', auth as any, update);
  app.delete('/consignment-purchases/:vchNo', auth as any, remove);
}
