import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  BookNotFoundError,
  BookVersionConflictError,
  bookAccounts,
  bookPrintRows,
  bookTemplate,
  deleteBook,
  getBook,
  listBooks,
  saveBook,
} from '../modules/masters/booksMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Books / Series', desktop SUB_MENU 'Books'). */
const FORM = 'Masters/Books / Series';

/**
 * Company → Books (MS_BOOK). A new book needs only the view right and an opened one the edit right, as BtnSave_Click
 * checks FRM_EDIT only in edit mode (MS_BOOK.cs:2586), so the screen posts a new book and puts an opened one. The list
 * returns the user's rights (MS_BOOK_Load :1930-1937) and the header families (:2119).
 */
export function registerBooksMasterRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'> & {
    guard: (
      req: FastifyRequest,
      reply: FastifyReply,
      action: 'view' | 'create' | 'update' | 'delete' | 'print',
    ) => boolean;
  },
  capabilities: (
    req: FastifyRequest,
    form: string,
  ) => Promise<{ canUpdate: boolean; canDelete: boolean; canPrint: boolean }>,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const scope = (req: FastifyRequest) => {
    const s = scopeOf(req) as any;
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode };
  };
  const codeOf = (req: FastifyRequest) => String((req.params as any).code ?? '');
  const notFound = (reply: FastifyReply) =>
    reply.code(404).send({ error: 'book-not-found', message: 'book code not found' });
  /** run(), with a stale version answered 409 and a missing book 404. */
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return await run(reply, okCode, fn);
    } catch (e) {
      if (e instanceof BookVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      if (e instanceof BookNotFoundError) return notFound(reply);
      throw e;
    }
  };

  app.get('/masters/books-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await listBooks(prisma, scope(req))),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/books-master/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    return run(reply, 200, async () => ({ rows: await bookPrintRows(prisma, scope(req)) }));
  });
  app.get('/masters/books-master/template', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query as any) ?? {};
    return run(reply, 200, () => bookTemplate(prisma, scope(req), q.family, q.code));
  });
  app.get('/masters/books-master/accounts', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query as any) ?? {};
    return run(reply, 200, () => bookAccounts(prisma, scope(req), q.q, Number(q.limit) || 200));
  });
  app.get('/masters/books-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const found = await getBook(prisma, scope(req), codeOf(req));
    if (!found) return notFound(reply);
    return reply.code(200).send(found);
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: unknown) => {
    const b = body(req);
    return saveBook(prisma, {
      scope: scope(req),
      user: mainUserOf(req),
      entryMode,
      code,
      values: b,
      slots: b.slots,
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/books-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', body(req).code));
  });
  app.put('/masters/books-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/books-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deleteBook(prisma, scope(req), codeOf(req), (req.query as any)?.expectedVersion),
    );
  });
}
