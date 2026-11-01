import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  GroupVersionConflictError,
  deleteGroup,
  getGroup,
  groupAccounts,
  groupPrintRows,
  groupTradeTypes,
  listGroups,
  saveGroup,
} from '../modules/masters/groupMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Item Groups', desktop SUB_MENU 'Group'). */
const FORM = 'Masters/Item Groups';

/**
 * Item Group master (MS_GROUP). A new group needs only the view right and an opened one the edit right, as
 * BtnSave_Click checks FRM_EDIT only in edit mode (MS_GROUP.cs:1844-1848), so the screen posts a new group and puts an
 * opened one. The list returns the user's rights, which MS_GROUP_Load reads for the buttons (:1487-1495).
 */
export function registerGroupMasterRoutes(
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
    const s = scopeOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode };
  };
  const codeOf = (req: FastifyRequest) => String((req.params as any).code ?? '');
  /** run(), with a stale version answered 409 as the voucher routes answer theirs. */
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return await run(reply, okCode, fn);
    } catch (e) {
      if (e instanceof GroupVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      throw e;
    }
  };

  app.get('/masters/group-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await listGroups(prisma, scope(req))),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/group-master/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    return run(reply, 200, async () => ({ rows: await groupPrintRows(prisma, scope(req)) }));
  });
  app.get('/masters/group-master/accounts', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query as any) ?? {};
    const kind = q.kind === 'purchase' ? 'purchase' : 'sale';
    return run(reply, 200, () =>
      groupAccounts(prisma, scope(req), kind, String(q.q ?? ''), Number(q.limit) || 20),
    );
  });
  app.get('/masters/group-master/trade-types', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query as any) ?? {};
    return run(reply, 200, () =>
      groupTradeTypes(prisma, scope(req), String(q.q ?? ''), Number(q.limit) || 20),
    );
  });
  app.get('/masters/group-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const group = await getGroup(prisma, scope(req), codeOf(req));
    if (!group)
      return reply.code(404).send({ error: 'group-not-found', message: 'group code not found' });
    return reply.code(200).send(group);
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: string) => {
    const b = body(req);
    return saveGroup(prisma, {
      scope: scope(req),
      user: mainUserOf(req),
      entryMode,
      code,
      name: b.name,
      itemType: b.itemType,
      tradeType: b.tradeType,
      rateTouch: b.rateTouch,
      purcTouch: b.purcTouch,
      melting: b.melting,
      west: b.west,
      saleAc: b.saleAc,
      purcAc: b.purcAc,
      hsn: b.hsn,
      taxPct: b.taxPct,
      rateDisplay: b.rateDisplay === true || b.rateDisplay === 'Y',
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/group-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', String(body(req).code ?? '')));
  });
  app.put('/masters/group-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/group-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deleteGroup(prisma, scope(req), codeOf(req), (req.query as any)?.expectedVersion),
    );
  });
}
