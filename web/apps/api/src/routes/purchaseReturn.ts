import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { VoucherScope } from '../modules/vouchers/numbering.js';
import {
  createPurchaseReturn,
  purchaseReturnInputFromBody,
} from '../modules/purchase/purchaseReturn.js';
import {
  deletePurchaseReturn,
  editPurchaseReturn,
  getPurchaseReturn,
} from '../modules/purchase/purchaseReturnLifecycle.js';
import { purchaseBillData, purchaseBillHtml } from '../modules/purchase/purchaseBill.js';
import { resolvePrintScope, sendVoucherDocument } from '../modules/documents/voucherPrint.js';
import { requiredVersion } from '../modules/vouchers/version.js';

/**
 * Purchase Return (TR_KR_ISU, PURC RETURN mode): create, read, update, delete and print. Moved out of routes/txn.ts
 * with the N245 changes:
 * - the read returns the voucher's `version`; an update sends it in the body and a delete in the query as
 *   `expectedVersion`, and a stale one is `409 voucher-version-conflict` (D17, G170; the same token as purchaseVoucher.ts);
 * - the print is gated on the desktop's print right, FRM_PRINT (TR_KR_ISU.cs:5434), not on view.
 */
export interface PurchaseReturnRouteHelpers {
  prisma: any;
  auth: any;
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  scopeOf: (req: FastifyRequest) => VoucherScope;
  readScope: (req: FastifyRequest) => VoucherScope;
  run: (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => Promise<unknown>;
  body: (req: FastifyRequest) => Record<string, any>;
  mainUserOf: (req: FastifyRequest) => string;
  standardDocumentCopy: (raw: unknown, reply: FastifyReply) => string | null | undefined;
}

export function registerPurchaseReturnRoutes(
  app: FastifyInstance,
  h: PurchaseReturnRouteHelpers,
): void {
  const { prisma, auth, guard, scopeOf, readScope, run, body, mainUserOf, standardDocumentCopy } =
    h;
  const inputOf = (req: FastifyRequest, b: Record<string, any>) =>
    purchaseReturnInputFromBody(scopeOf(req), mainUserOf(req), b);
  // No JSON Schema yet: no route has one until decision D16 is accepted (N50).
  app.post('/purchase-returns', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    const input = inputOf(req, b);
    return run(reply, 201, () => createPurchaseReturn(prisma, input, b.lines ?? []));
  });
  app.put('/purchase-returns/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    const input = inputOf(req, b);
    return run(reply, 200, () =>
      editPurchaseReturn(
        prisma,
        input,
        b.lines ?? [],
        (req.params as any).vchNo,
        requiredVersion(b.expectedVersion),
      ),
    );
  });
  app.get('/purchase-returns/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getPurchaseReturn(prisma, scopeOf(req), (req.params as any).vchNo),
    );
  });
  app.get('/purchase-returns/:vchNo/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const q = req.query as any;
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    const scope = resolvePrintScope(reply, readScope(req), (req.params as any).vchNo);
    if (!scope) return reply;
    await getPurchaseReturn(prisma, scope, scope.vchNo);
    const data = await purchaseBillData(prisma, scope);
    if (!data) return reply.code(404).send({ error: 'purchase-return-not-found' });
    const html = purchaseBillHtml(data.header, data.lines, {
      company: data.company,
      party: data.party,
      copy: copyLabel,
      title: 'Purchase Return',
      partyCaption: 'Supplier',
      footerText: 'Purchase return — goods and value returned to supplier.',
    });
    return sendVoucherDocument(reply, html, {
      format: q.format,
      filename: `purchase-return-${scope.vchNo}`,
    });
  });
  app.delete('/purchase-returns/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deletePurchaseReturn(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: mainUserOf(req),
        expectedVersion: requiredVersion((req.query as any)?.expectedVersion),
      }),
    );
  });
}
