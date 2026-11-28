import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  applyRepair,
  listRepairs,
  previewRepair,
  repairHistory,
} from '../modules/utilities/dataRepair.js';
import '../modules/utilities/dataRepairOps.js';
import { accountCheck, accountRefreshFamilies } from '../modules/utilities/accountRefresh.js';

interface DataRepairRouteDeps {
  prisma: any;
  auth: { preHandler: unknown };
  guard: (req: FastifyRequest, reply: FastifyReply, action: 'view' | 'delete' | 'print') => boolean;
  sess: (req: FastifyRequest) => any;
  run: (reply: FastifyReply, status: number, fn: () => Promise<unknown>) => Promise<unknown>;
}

/** Existing Data Repair URLs, extracted so the frozen transaction route file does not grow. */
export function registerDataRepairRoutes(app: FastifyInstance, deps: DataRepairRouteDeps): void {
  const { prisma, auth, guard, sess, run } = deps;

  app.get('/utilities/data-repair/operations', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return {
      operations: listRepairs().map((operation) => ({
        id: operation.id,
        title: operation.title,
        description: operation.description,
        desktopSource: operation.desktopSource,
        risk: operation.risk,
        tables: operation.tables,
        applyAvailable: operation.applyAvailable !== false,
        blockedReason: operation.blockedReason ?? null,
        completionText: operation.completionText ?? null,
      })),
    };
  });

  app.post('/utilities/data-repair/:id/preview', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const scope = sess(req);
    return run(reply, 200, () =>
      previewRepair(
        prisma,
        String((req.params as any).id),
        {
          tenantId: scope.tenantId,
          coCode: scope.coCode,
          lcCode: scope.lcCode,
          coYear: scope.coYear,
        },
        scope.sub ?? 'unknown',
      ),
    );
  });

  app.post('/utilities/data-repair/:id/apply', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const scope = sess(req);
    const body = (req.body ?? {}) as Record<string, unknown>;
    try {
      const applied = await applyRepair(
        prisma,
        String((req.params as any).id),
        {
          tenantId: scope.tenantId,
          coCode: scope.coCode,
          lcCode: scope.lcCode,
          coYear: scope.coYear,
        },
        {
          previewHash: String(body.previewHash ?? ''),
          confirmation: body.confirmation ? String(body.confirmation) : undefined,
          operator: scope.sub ?? 'unknown',
          loginCoCode: scope.loginCoCode,
          reason: body.reason ? String(body.reason) : undefined,
          operatorPassword: body.operatorPassword ? String(body.operatorPassword) : undefined,
          backupReference: body.backupReference ? String(body.backupReference) : undefined,
        },
      );
      return reply.code(200).send(applied);
    } catch (error: any) {
      if (
        error?.name === 'RepairError' &&
        (error.code === 'reauthentication-required' || error.code === 'reauthentication-failed')
      ) {
        return reply
          .code(403)
          .send({ error: 'RepairError', code: error.code, message: error.message });
      }
      if (error?.name === 'RepairError') {
        return reply
          .code(400)
          .send({ error: 'RepairError', code: error.code, message: error.message });
      }
      throw error;
    }
  });

  app.get('/utilities/data-repair/runs', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const scope = sess(req);
    return {
      runs: await repairHistory(prisma, { tenantId: scope.tenantId, coCode: scope.coCode }),
    };
  });

  // Data Refresh (desktop MS_UPDATE): the six operator actions under the caption's Print right. The same registered
  // repairs, narrowed to the six; the advanced Data Repair console above stays administrator-only.
  const SIX = new Set([
    'data-refresh-account',
    'data-refresh-stock',
    'data-refresh-field-update',
    'approval-reconcile',
    'data-refresh-image-data',
    'data-refresh-old-field',
    // Account check-and-repair, one operation per voucher family (modules/utilities/accountRefresh.ts).
    ...accountRefreshFamilies().map((family) => family.operationId),
  ]);
  const six = (req: FastifyRequest, reply: FastifyReply): string | null => {
    const id = String((req.params as any).id);
    if (SIX.has(id)) return id;
    void reply.code(404).send({ error: 'unknown-operation' });
    return null;
  };
  const scopeOf = (req: FastifyRequest) => {
    const s = sess(req);
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear };
  };

  app.get('/utilities/data-refresh/operations', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    return {
      operations: listRepairs()
        .filter((operation) => SIX.has(operation.id))
        .map((operation) => ({
          id: operation.id,
          title: operation.title,
          description: operation.description,
          desktopSource: operation.desktopSource,
          risk: operation.risk,
          tables: operation.tables,
          applyAvailable: operation.applyAvailable !== false,
          blockedReason: operation.blockedReason ?? null,
          completionText: operation.completionText ?? null,
        })),
      accountFamilies: accountRefreshFamilies(),
    };
  });

  // The Account check's per-voucher list, a page at a time (read-only; the audited preview shows the first page).
  app.get('/utilities/data-refresh/account/:family/vouchers', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const query = (req.query ?? {}) as Record<string, unknown>;
    try {
      return await accountCheck(prisma, String((req.params as any).family), scopeOf(req), {
        offset: Number(query.offset ?? 0) || 0,
        limit: Number(query.limit ?? 50) || 50,
        status: query.status ? String(query.status) : undefined,
      });
    } catch (error: any) {
      if (error?.name === 'RepairError')
        return reply
          .code(error.code === 'unknown-operation' ? 404 : 400)
          .send({ error: 'RepairError', code: error.code, message: error.message });
      throw error;
    }
  });

  app.post('/utilities/data-refresh/:id/preview', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const id = six(req, reply);
    if (!id) return;
    return run(reply, 200, () =>
      previewRepair(prisma, id, scopeOf(req), sess(req).sub ?? 'unknown'),
    );
  });

  app.post('/utilities/data-refresh/:id/apply', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const id = six(req, reply);
    if (!id) return;
    const scope = sess(req);
    const body = (req.body ?? {}) as Record<string, unknown>;
    try {
      const applied = await applyRepair(prisma, id, scopeOf(req), {
        previewHash: String(body.previewHash ?? ''),
        confirmation: body.confirmation ? String(body.confirmation) : undefined,
        operator: scope.sub ?? 'unknown',
        loginCoCode: scope.loginCoCode,
        reason: body.reason ? String(body.reason) : undefined,
        operatorPassword: body.operatorPassword ? String(body.operatorPassword) : undefined,
        backupReference: body.backupReference ? String(body.backupReference) : undefined,
      });
      return reply.code(200).send(applied);
    } catch (error: any) {
      if (
        error?.name === 'RepairError' &&
        (error.code === 'reauthentication-required' || error.code === 'reauthentication-failed')
      )
        return reply
          .code(403)
          .send({ error: 'RepairError', code: error.code, message: error.message });
      if (error?.name === 'RepairError')
        return reply
          .code(400)
          .send({ error: 'RepairError', code: error.code, message: error.message });
      // A failed write rolled the whole apply back; answer it as the other writers do (`run` in txn.ts).
      const text = String(error?.message ?? '');
      if (
        error?.code === 'P2010' ||
        /Raw query failed|violates|not-null|duplicate key/i.test(text)
      ) {
        req.log.warn({ err: error }, 'data refresh apply failed on invalid data');
        return reply.code(400).send({
          error: 'invalid-data',
          detail: 'Data Refresh could not be applied because the data is invalid.',
        });
      }
      throw error;
    }
  });

  app.get('/utilities/data-refresh/runs', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const s = sess(req);
    const runs = await repairHistory(prisma, {
      tenantId: s.tenantId,
      coCode: s.coCode,
      operationIds: [...SIX],
    });
    return { runs };
  });
}
