import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import { neighbourVoucher, recentVouchers } from '../modules/vouchers/list.js';
import { formsForMainBook } from '../modules/vouchers/bookForms.js';
import {
  authorizeForm,
  FormForbiddenError,
  type Principal,
} from '../modules/rbac/authorization.js';
import { withTxBudget } from '../modules/shared/txBudget.js';

/**
 * Voucher screen navigation: the recent-voucher list and the voucher number box's Up and Down keys (N172, G179).
 * Both are read-only and scoped to the session's company, location and year. A session without a year finds nothing
 * (fail closed) instead of searching every year's vouchers.
 *
 * N207 (G220): the desktop lists only the open menu's own book (TR_CONTRA.cs:3136-3146 and every form's F1), and a
 * menu can only open the books of its own family (CurBookHelp, e.g. MDI_FORM.cs:8100-8111, :8360-8365). The routes
 * take the table and book from the request, so they require read rights on a form that owns the book's MAIN_BOOK
 * (`MAIN_BOOK_FORMS`). An administrator passes; a book with no owning form is refused.
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
  /** True when the signed-in user may read a form that owns the requested book; otherwise answers 403. */
  const mayList = async (
    req: FastifyRequest,
    reply: FastifyReply,
    book: string,
  ): Promise<boolean> => {
    const principal = (req as FastifyRequest & { principal?: Principal }).principal;
    const scope = listScope(req);
    if (principal?.isAdmin) return true;
    const rows: Array<{ main: string }> = book
      ? await withTxBudget(prisma, scope.tenantId, 'read', (tx: any) =>
          tx.$queryRawUnsafe(
            `SELECT coalesce("MAIN_BOOK",'') main FROM "BOOK_DATA"
              WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "CO_BOOK"=$4 ORDER BY row_id LIMIT 1`,
            scope.tenantId,
            scope.coCode,
            scope.lcCode,
            book,
          ),
        )
      : [];
    for (const form of formsForMainBook(rows[0]?.main ?? '')) {
      try {
        await authorizeForm(prisma, {
          tenantId: scope.tenantId,
          lcCode: scope.lcCode,
          principal: principal!,
          form,
          action: 'read',
        });
        return true;
      } catch (error) {
        if (!(error instanceof FormForbiddenError)) throw error;
      }
    }
    await reply.code(403).send({ error: 'forbidden', action: 'view', book });
    return false;
  };
  app.get('/vouchers/recent', auth as any, async (req, reply) => {
    const qy = (req.query as Record<string, string | undefined>) || {};
    const book = String(qy.book ?? '');
    if (!(await mayList(req, reply, book))) return reply;
    return recentVouchers(
      prisma,
      listScope(req),
      String(qy.table ?? ''),
      book,
      qy.limit ? Number(qy.limit) : 50,
    );
  });
  app.get('/vouchers/neighbour', auth as any, async (req, reply) => {
    const qy = (req.query as Record<string, string | undefined>) || {};
    const book = String(qy.book ?? '');
    if (!(await mayList(req, reply, book))) return reply;
    return run(reply, 200, () =>
      neighbourVoucher(
        prisma,
        listScope(req),
        String(qy.table ?? ''),
        book,
        String(qy.from ?? ''),
        String(qy.direction ?? ''),
      ),
    );
  });
}
