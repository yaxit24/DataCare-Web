import type { FastifyInstance, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import { createSale, deleteSale, editSale, getSale } from '../modules/sales/sales.js';
import {
  approvalSaleBill,
  saleApprovalHelp,
  saleApprovalImport,
} from '../modules/sales/approvalImport.js';
import { requiredVersion } from '../modules/vouchers/version.js';
import { salePrintFiles, setSalePrintDefault } from '../modules/sales/salePrintChoice.js';

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
  // WP-26 (D6): the PRINT_MAST file list of the sale book and its "Set" default (TR_SALE.cs:13933, :20618-20624).
  app.get('/sales/print-files', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => salePrintFiles(prisma, scopeOf(req)));
  });
  app.post('/sales/print-files/default', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () =>
      setSalePrintDefault(prisma, scopeOf(req), String(body(req).file ?? '')),
    );
  });
  // TR_SALE.cs:20562-20590 "A" (Approval Help): the open APR ISU vouchers of the session location.
  app.get('/sales/approval-help', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => saleApprovalHelp(prisma, scopeOf(req)));
  });
  // TR_SALE.cs:20008-20050, :20120-20520: the open lines of one approval, as Sales Invoice lines.
  app.get('/sales/approval-import', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = req.query as Record<string, string | undefined>;
    return run(reply, 200, () =>
      saleApprovalImport(prisma, scopeOf(req), {
        // Not year/book: those names are the session scope keys (businessScope.ts enforceRequestScope).
        year: String(q.aprYear ?? ''),
        book: String(q.aprBook ?? ''),
        vchNo: String(q.aprNo ?? ''),
        rateDate: q.rateDate,
      }),
    );
  });
  // The import and the save in one request: createSale's transaction locks and closes every source line, so a
  // refusal leaves neither a sale nor a closed approval behind.
  app.post('/tour/:vchNo/bill', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, async () => {
      const bill = await approvalSaleBill(prisma, saleInput(req, b), (req.params as any).vchNo, b);
      return createSale(prisma, bill.input, bill.lines);
    });
  });
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
