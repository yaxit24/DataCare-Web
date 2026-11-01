import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import { autoItemGrid, autoItemGroups, saveAutoItems } from '../modules/masters/autoItem.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Auto Item', desktop SUB_MENU 'AutoItem'). */
const FORM = 'Masters/Auto Item';

/**
 * Auto Item (MS_AUTO_ITEM, CurMast 'AutoItem'). The grid read returns the user's rights (MS_AUTO_ITEM_Load
 * :1978-1995); the save needs the edit right because DISPLAY_DATA leaves the screen in edit mode (:2648, :2668-2672),
 * so the POST is an update in the route policy.
 */
export function registerAutoItemRoutes(
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
  const query = (req: FastifyRequest) => (req.query as any) ?? {};

  app.get('/masters/auto-item', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await autoItemGrid(prisma, scope(req), String(query(req).grCode ?? ''))),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/auto-item/groups', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = query(req);
    return run(reply, 200, () =>
      autoItemGroups(prisma, scope(req), String(q.q ?? ''), Number(q.limit) || 20),
    );
  });
  app.post('/masters/auto-item', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      saveAutoItems(prisma, {
        scope: scope(req),
        user: mainUserOf(req),
        grCode: String(b.grCode ?? ''),
        grType: b.grType,
        tradeType: b.tradeType,
        hsnCode: b.hsnCode,
        rows: Array.isArray(b.rows) ? b.rows : [],
      }),
    );
  });
}
