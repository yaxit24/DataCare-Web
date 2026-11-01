import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  ProductVersionConflictError,
  deleteProduct,
  getProduct,
  listProducts,
  saveProduct,
} from '../modules/masters/productMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Products', desktop SUB_MENU 'Product'). */
const FORM = 'Masters/Products';

/**
 * Product master (MS_PRODUCT, CurMast 'Product'). A new product needs only the view right and an opened one the edit
 * right, as BtnSave_Click checks FRM_EDIT only in edit mode (MS_PRODUCT.cs:2583-2587), so the screen posts a new
 * product and puts an opened one. The list returns the user's rights, which MS_PRODUCT_Load reads (:1918-1935). The
 * desktop's Print button does nothing (:1914-1917), so there is no print route.
 */
export function registerProductMasterRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'> & {
    guard: (
      req: FastifyRequest,
      reply: FastifyReply,
      action: 'view' | 'create' | 'update' | 'delete',
    ) => boolean;
  },
  capabilities: (
    req: FastifyRequest,
    form: string,
  ) => Promise<{ canUpdate: boolean; canDelete: boolean; canPrint: boolean }>,
): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const scope = (req: FastifyRequest) => {
    const s = scopeOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode };
  };
  const codeOf = (req: FastifyRequest) => String((req.params as any).code ?? '');
  /** run(), with a stale version answered 409 as the voucher routes answer theirs. */
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return await run(reply, okCode, fn);
    } catch (e) {
      if (e instanceof ProductVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      throw e;
    }
  };

  app.get('/masters/product-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await listProducts(prisma, scope(req))),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/product-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const product = await getProduct(prisma, scope(req), codeOf(req));
    if (!product)
      return reply
        .code(404)
        .send({ error: 'product-not-found', message: 'product code not found' });
    return reply.code(200).send(product);
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: string) => {
    const b = body(req);
    return saveProduct(prisma, {
      scope: scope(req),
      user: mainUserOf(req),
      entryMode,
      code,
      name: b.name,
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/product-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', String(body(req).code ?? '')));
  });
  app.put('/masters/product-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/product-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deleteProduct(prisma, scope(req), codeOf(req), (req.query as any)?.expectedVersion),
    );
  });
}
