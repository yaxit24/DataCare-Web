import type { FastifyInstance, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  createSaleReturn,
  deleteSaleReturn,
  editSaleReturn,
  getSaleReturn,
  saleForReturn,
  type SaleReturnInput,
} from '../modules/sales/salesReturn.js';
import { requiredVersion } from '../modules/vouchers/version.js';

/**
 * Sales Return, "New return" form (TR_SALE_RTN): create, Import from a sale, read, edit and delete one voucher.
 * Moved out of routes/txn.ts with the edit route (WP-27, N242, G254) to keep that file within its size budget.
 *
 * The edit is the desktop's save in mode `E` (TR_SALE_RTN.cs:12496-13541: rewrite under the same number, keep the
 * creator, log the changed columns). The read returns `version`; the edit sends it as `expectedVersion` and a stale
 * one is `409 voucher-version-conflict` (N51, D17), so two operators cannot overwrite each other's save.
 */
export function registerSaleReturnVoucherRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'guard' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'>,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const amount = (value: unknown): number | undefined =>
    value != null ? Number(value) : undefined;
  const returnInput = (req: FastifyRequest, b: Record<string, any>): SaleReturnInput => ({
    scope: scopeOf(req),
    acCode: b.acCode,
    acName: b.acName,
    billNo: b.billNo,
    origVchNo: b.origVchNo,
    origBook: b.origBook,
    vchDate: b.vchDate,
    discountAmount: b.discountAmount,
    taxRatePct: b.taxRatePct,
    taxCode: b.taxCode,
    interState: !!b.interState,
    cashAmt: amount(b.cashAmt),
    chequeAmt: amount(b.chequeAmt),
    cardAmt: amount(b.cardAmt),
    upiAmt: amount(b.upiAmt),
    kasar: amount(b.kasar),
    cashAc: b.cashAc,
    bankAc: b.bankAc,
    kasarAc: b.kasarAc,
    empCode: b.empCode,
    // N183 (G194): TR_SALE_RTN.cs:9966 stores MCo_User on a new voucher; on an edit this is the editor, and the
    // writer keeps the stored creator (TR_SALE_RTN.cs:10181).
    mainUser: mainUserOf(req),
  });

  app.post('/sales-returns', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return run(reply, 201, () => createSaleReturn(prisma, returnInput(req, b), b.lines ?? []));
  });
  // G05: the original SALE book is the request's validated book (`coBook`), never a literal SAL.
  // `remaining=1` is the single-item picker (TR_SALE_RTN.cs:3882); without it the whole bill is imported and a bill
  // that already has a return is refused (TR_SALE_RTN.cs:16534-16540, WP-27 D6/D7).
  app.get('/sales-returns/import', auth as any, async (req, reply) => {
    const qs = (req.query as any) || {};
    const scope = scopeOf(req);
    if (!scope.coBook) {
      return reply.code(400).send({
        error: 'SaleValidationError',
        message: 'Select the book of the original sale before importing it.',
      });
    }
    return run(reply, 200, () =>
      saleForReturn(prisma, {
        scope,
        origVchNo: qs.vchNo,
        origBook: scope.coBook,
        remaining: qs.remaining === '1' || qs.remaining === 'true',
      }),
    );
  });
  app.get('/sales-returns/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getSaleReturn(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/sales-returns/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, async () =>
      editSaleReturn(
        prisma,
        returnInput(req, b),
        b.lines ?? [],
        (req.params as any).vchNo,
        requiredVersion(b.expectedVersion),
      ),
    );
  });
  app.delete('/sales-returns/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, async () =>
      deleteSaleReturn(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: mainUserOf(req),
        // N51 (D17), like the Sale and Purchase deletes: the version read before the delete.
        expectedVersion: requiredVersion((req.query as any)?.expectedVersion),
      }),
    );
  });
}
