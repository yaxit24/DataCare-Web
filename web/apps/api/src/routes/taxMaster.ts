import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  TaxVersionConflictError,
  deleteTax,
  getTax,
  listTaxes,
  saveTax,
  taxAccounts,
  taxPrintRows,
} from '../modules/masters/taxMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Taxes', desktop SUB_MENU 'Tax'). */
const FORM = 'Masters/Taxes';

/**
 * Tax master (MS_TAX). A new code needs only the view right and an opened one the edit right, as BtnSave_Click checks
 * FRM_EDIT only in edit mode (MS_TAX.cs:1845-1849), so the screen posts a new code and puts an opened one. The list
 * returns the user's rights, which MS_TAX_Load reads for the buttons (:1342-1350).
 */
export function registerTaxMasterRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'run' | 'body'> & {
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
  const { prisma, auth, guard, scopeOf, run, body } = h;
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
      if (e instanceof TaxVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      throw e;
    }
  };

  app.get('/masters/tax-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await listTaxes(prisma, scope(req))),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/tax-master/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    return run(reply, 200, async () => ({ rows: await taxPrintRows(prisma, scope(req)) }));
  });
  app.get('/masters/tax-master/accounts', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query as any) ?? {};
    const kind = q.kind === 'component' ? 'component' : 'header';
    return run(reply, 200, () =>
      taxAccounts(prisma, scope(req), kind, String(q.q ?? ''), Number(q.limit) || 20),
    );
  });
  app.get('/masters/tax-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const tax = await getTax(prisma, scope(req), codeOf(req));
    if (!tax)
      return reply.code(404).send({ error: 'tax-not-found', message: 'tax code not found' });
    return reply.code(200).send(tax);
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: string) => {
    const b = body(req);
    return saveTax(prisma, {
      scope: scope(req),
      entryMode,
      code,
      name: b.name,
      pct: b.pct,
      addPct: b.addPct,
      account: b.account,
      components: Array.isArray(b.components) ? b.components : [],
      canUpdate: true,
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/tax-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', String(body(req).code ?? '')));
  });
  app.put('/masters/tax-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/tax-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deleteTax(prisma, scope(req), codeOf(req), (req.query as any)?.expectedVersion),
    );
  });
}
