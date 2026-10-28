import type { FastifyInstance, FastifyRequest, FastifyReply } from 'fastify';
import type { VoucherScope } from '../modules/vouchers/numbering.js';
import {
  postCustomerEntry,
  getCustomerEntry,
  editCustomerEntry,
  deleteCustomerEntry,
  customerEntryInputFromBody,
} from '../modules/crm/customerEntry.js';

/**
 * CRM routes (N124): the Customer Entry workflow (desktop UT_CUST_ENTRY) — an employee-scoped,
 * non-financial customer enquiry / item-interest / follow-up-reminder log. Extracted into its own
 * plugin (per the size-budget guidance to split modules) and wired from registerTxnRoutes with the
 * shared request helpers so it reuses the same auth, guard, scope, run and body plumbing.
 */
export interface CrmRouteHelpers {
  prisma: any;
  auth: { preHandler: unknown };
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete',
  ) => boolean;
  scopeOf: (req: FastifyRequest) => VoucherScope;
  run: (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => Promise<unknown>;
  body: (req: FastifyRequest) => Record<string, any>;
  mainUserOf: (req: FastifyRequest) => string;
}

export function registerCrmRoutes(app: FastifyInstance, h: CrmRouteHelpers): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const input = (req: FastifyRequest) =>
    customerEntryInputFromBody(scopeOf(req), { ...body(req), mainUser: mainUserOf(req) });

  app.post('/crm/customer-entries', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => postCustomerEntry(prisma, input(req)));
  });
  app.get('/crm/customer-entries/:employeeCode/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const p = req.params as any;
    return run(reply, 200, () => getCustomerEntry(prisma, scopeOf(req), p.employeeCode, p.vchNo));
  });
  app.put('/crm/customer-entries/:employeeCode/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editCustomerEntry(prisma, input(req), (req.params as any).vchNo));
  });
  app.delete('/crm/customer-entries/:employeeCode/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    const p = req.params as any;
    return run(reply, 200, () =>
      deleteCustomerEntry(prisma, {
        scope: scopeOf(req),
        employeeCode: p.employeeCode,
        vchNo: p.vchNo,
      }),
    );
  });
}
