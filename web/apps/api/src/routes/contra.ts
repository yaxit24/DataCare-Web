import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { VoucherScope } from '../modules/vouchers/numbering.js';
import { deleteContra, editContra, getContra, postContra } from '../modules/finance/contra.js';
import { contraF1List } from '../modules/finance/contraList.js';

/**
 * Contra Entry (TR_CONTRA) voucher routes: save, reopen, edit, delete and the F1 list. The print stays in txn.ts with the
 * other document routes. A saved voucher's GET returns its `version`; PUT sends it in the body and DELETE in the query
 * as `expectedVersion`, and a stale one is `409 voucher-version-conflict` (D7, as purchaseVoucher.ts).
 */
export interface ContraRouteHelpers {
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

/** One TR_CONTRA grid row: Cr/Dr (column 1), account (2), name (3), description (4) and the amount (5 or 6). */
const CONTRA_BODY_SCHEMA = {
  type: 'object',
  properties: {
    lines: {
      type: 'array',
      maxItems: 200,
      items: {
        type: 'object',
        properties: {
          crdr: { type: 'string', enum: ['DR', 'CR'] },
          // Blank rows travel with the grid: row 1 is positional (TR_CONTRA.cs:2781).
          acCode: { type: 'string', maxLength: 8 },
          acName: { type: 'string', maxLength: 50 },
          // CONTRA_DATA.IT_DESC is varchar(150).
          itDesc: { type: 'string', maxLength: 150 },
          amount: { type: 'number' },
        },
      },
    },
    vchDate: { type: 'string', pattern: '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' },
    // CONTRA_DATA.EMP_CODE / EMP_MAST.EMP_CODE are varchar(3).
    empCode: { type: 'string', maxLength: 3 },
    expectedVersion: { type: 'string', maxLength: 64 },
  },
} as const;

export function registerContraRoutes(app: FastifyInstance, h: ContraRouteHelpers): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const withBody = { ...(auth as object), schema: { body: CONTRA_BODY_SCHEMA } };
  const input = (req: FastifyRequest) => {
    const b = body(req);
    return {
      scope: scopeOf(req),
      lines: Array.isArray(b.lines) ? b.lines : [], // the desktop grid (TR_CONTRA)
      vchDate: b.vchDate,
      empCode: b.empCode,
      expectedVersion: b.expectedVersion,
      mainUser: mainUserOf(req),
    };
  };

  app.post('/contra', withBody, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => postContra(prisma, input(req)));
  });
  // TR_CONTRA.BtnF1_Click (TR_CONTRA.cs:3140-3146): the registered literal path must come before /contra/:vchNo.
  app.get('/contra/list', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => contraF1List(prisma, scopeOf(req)));
  });
  app.get('/contra/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getContra(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/contra/:vchNo', withBody, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editContra(prisma, input(req), (req.params as any).vchNo));
  });
  app.delete('/contra/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteContra(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: mainUserOf(req),
        expectedVersion: (req.query as any)?.expectedVersion,
      }),
    );
  });
}
