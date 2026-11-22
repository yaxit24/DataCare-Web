import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { VoucherScope } from '../modules/vouchers/numbering.js';
import {
  balanceTransferBlocked,
  balanceTransferContext,
  BalanceTransferBlockedError,
  carryAcBalance,
  carryItemStock,
  type BalanceTransferScope,
} from '../modules/ops/balanceTransfer.js';

/**
 * Company → Balance TrFr (desktop BtmSchm). One route per Lite dataset button (BtmSchm.cs:2724, :2921, :2169, :3003,
 * :4116); the desktop has no rights check inside the form, and the catalog right is Create (`C-----`), so every write is
 * a create. The company, location and year being closed come from the session; the body names only the Transfer Year,
 * which must be the one the server computes. Its own file so `txn.ts` does not grow.
 */
export interface BalanceTransferRouteHelpers {
  prisma: any;
  auth: any;
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  scopeOf: (req: FastifyRequest) => VoucherScope;
  run: (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => Promise<unknown>;
  body: (req: FastifyRequest) => Record<string, any>;
  mainUserOf: (req: FastifyRequest) => string;
}

const BODY_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['toYear'],
  properties: { toYear: { type: 'string', maxLength: 10 } },
} as const;

export function registerBalanceTransferRoutes(
  app: FastifyInstance,
  h: BalanceTransferRouteHelpers,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const scope = (req: FastifyRequest): BalanceTransferScope => {
    const s = scopeOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear };
  };
  const bodyRoute = { ...auth, schema: { body: BODY_SCHEMA } };

  app.get('/balance-transfer', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => balanceTransferContext(prisma, scope(req)));
  });
  app.post('/balance-transfer/ac-balance', bodyRoute, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 200, () =>
      carryAcBalance(prisma, scope(req), { toYear: b.toYear, mainUser: mainUserOf(req) }),
    );
  });
  app.post('/balance-transfer/item-stock', bodyRoute, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 200, () =>
      carryItemStock(prisma, scope(req), { toYear: b.toYear, mainUser: mainUserOf(req) }),
    );
  });
  const blocked =
    (dataset: 'tag-stock' | 'sales-order' | 'approval') =>
    async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'create')) return;
      const b = body(req);
      try {
        return await run(reply, 200, () =>
          balanceTransferBlocked(prisma, scope(req), dataset, {
            toYear: b.toYear,
            mainUser: mainUserOf(req),
          }),
        );
      } catch (e) {
        if (e instanceof BalanceTransferBlockedError)
          return reply
            .code(e.statusCode)
            .send({ error: 'balance-transfer-blocked', message: e.message });
        throw e;
      }
    };
  app.post('/balance-transfer/tag-stock', bodyRoute, blocked('tag-stock'));
  app.post('/balance-transfer/sales-order', bodyRoute, blocked('sales-order'));
  app.post('/balance-transfer/approval', bodyRoute, blocked('approval'));
}
