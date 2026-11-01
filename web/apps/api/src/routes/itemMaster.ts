import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  ItemVersionConflictError,
  deleteItem,
  getItem,
  itemGroups,
  itemProducts,
  listItems,
  saveItem,
  updateItemTagValues,
} from '../modules/masters/itemMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Items', desktop SUB_MENU 'Item'). */
const FORM = 'Masters/Items';

/**
 * Item master (MS_ITEM). A new item needs only the view right and an opened one the edit right, as BtnSave_Click
 * checks FRM_EDIT only in edit mode (MS_ITEM.cs:3184-3190), so the screen posts a new item and puts an opened one. The
 * list returns the user's rights (MS_ITEM_Load :2548-2560), the units and safes and the two settings that show a check
 * box. The desktop's Print button only checks the print right (BtnPrint_Click_1 :3697-3705), so there is no print
 * route; the screen reads the right from the list.
 */
export function registerItemMasterRoutes(
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
    const s = scopeOf(req) as any;
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear };
  };
  const codeOf = (req: FastifyRequest) => String((req.params as any).code ?? '');
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return await run(reply, okCode, fn);
    } catch (e) {
      if (e instanceof ItemVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      throw e;
    }
  };
  const query = (req: FastifyRequest) => (req.query as any) ?? {};

  app.get('/masters/item-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await listItems(prisma, scope(req))),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/item-master/products', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = query(req);
    return run(reply, 200, () =>
      itemProducts(prisma, scope(req), String(q.q ?? ''), Number(q.limit) || 20),
    );
  });
  app.get('/masters/item-master/groups', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = query(req);
    return run(reply, 200, () =>
      itemGroups(prisma, scope(req), String(q.q ?? ''), Number(q.limit) || 20),
    );
  });
  app.get('/masters/item-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const item = await getItem(prisma, scope(req), codeOf(req));
    if (!item)
      return reply.code(404).send({ error: 'item-not-found', message: 'item code not found' });
    return reply.code(200).send(item);
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: string) => {
    const b = body(req);
    return saveItem(prisma, {
      scope: scope(req),
      user: mainUserOf(req),
      entryMode,
      code,
      values: b,
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/item-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', String(body(req).code ?? '')));
  });
  app.put('/masters/item-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/item-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deleteItem(prisma, scope(req), codeOf(req), query(req).expectedVersion),
    );
  });
  // The Tag Value Update panel (PnlBotam double click); the edit right on the web (the desktop checks none, G230).
  app.post('/masters/item-master/:code/tag-values', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      updateItemTagValues(prisma, scope(req), codeOf(req), {
        lbrPrc: b.lbrPrc,
        krTouch: b.krTouch,
        krWestPrc: b.krWestPrc,
      }),
    );
  });
}
