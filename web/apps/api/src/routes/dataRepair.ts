import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  applyRepair,
  listRepairs,
  previewRepair,
  repairHistory,
} from '../modules/utilities/dataRepair.js';
import '../modules/utilities/dataRepairOps.js';

interface DataRepairRouteDeps {
  prisma: any;
  auth: { preHandler: unknown };
  guard: (req: FastifyRequest, reply: FastifyReply, action: 'view' | 'delete') => boolean;
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
}
