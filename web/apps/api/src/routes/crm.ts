import type { FastifyInstance, FastifyRequest, FastifyReply } from 'fastify';
import type { VoucherScope } from '../modules/vouchers/numbering.js';
import {
  postCustomerEntry,
  getCustomerEntry,
  editCustomerEntry,
  deleteCustomerEntry,
  customerEntryInputFromBody,
} from '../modules/crm/customerEntry.js';
import {
  receiveDhrnInterest,
  getDhrnInterest,
  editDhrnInterest,
  deleteDhrnInterest,
  dhrnInterestInputFromBody,
} from '../modules/dhrn/dhrnInterest.js';
import { dhrnOsLetterData, dhrnOsLetterHtml } from '../modules/dhrn/dhrnOsLetter.js';
import {
  postTourSale,
  getTourSale,
  editTourSale,
  deleteTourSale,
} from '../modules/sales/tourSale.js';
import { sendVoucherDocument } from '../modules/documents/voucherPrint.js';

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
  rateCutInput?: (req: FastifyRequest, b: Record<string, any>) => any;
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

/**
 * Loan / Dhrn Interest Receipt routes (N125, desktop TR_DHRN_INTREC). Full lifecycle for the
 * interest receipt against a pledged loan. Shares the same helper plumbing as the CRM routes.
 */
export function registerLoanInterestRoutes(app: FastifyInstance, h: CrmRouteHelpers): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const input = (req: FastifyRequest) =>
    dhrnInterestInputFromBody(scopeOf(req), { ...body(req), mainUser: mainUserOf(req) });

  app.post('/dhrn/interest', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => receiveDhrnInterest(prisma, input(req)));
  });
  app.get('/dhrn/interest/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getDhrnInterest(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/dhrn/interest/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editDhrnInterest(prisma, input(req), (req.params as any).vchNo));
  });
  app.delete('/dhrn/interest/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteDhrnInterest(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        deleteUser: mainUserOf(req),
      }),
    );
  });
  // N126 (G135): Dhrn Os Letter — per-party pledge outstanding statement (desktop RP_DHRN_OS).
  app.get('/dhrn/os-letter', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = req.query as any;
    const scope = scopeOf(req);
    const acCode = String(q.acCode ?? '').trim();
    if (!acCode) return reply.code(400).send({ error: 'acCode-required' });
    const data = await dhrnOsLetterData(prisma, {
      tenantId: scope.tenantId,
      coCode: scope.coCode,
      lcCode: scope.lcCode,
      coYear: scope.coYear,
      acCode,
      asOf: q.asOf ? String(q.asOf) : undefined,
    });
    if (!data) return reply.code(404).send({ error: 'party-or-pledge-not-found' });
    return sendVoucherDocument(reply, dhrnOsLetterHtml(data, {}), {
      format: q.format,
      filename: `dhrn-os-letter-${acCode}-${data.asOf}`,
    });
  });
}

/** Tour Sales routes (N127, desktop TR_TOUR_SALE): the TR_WH_SALE engine on a TOUR SALES book. */
export function registerTourSaleRoutes(app: FastifyInstance, h: CrmRouteHelpers): void {
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const input = (req: FastifyRequest) => h.rateCutInput!(req, body(req));
  app.post('/tour-sales', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => postTourSale(prisma, input(req)));
  });
  app.get('/tour-sales/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getTourSale(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/tour-sales/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editTourSale(prisma, input(req), (req.params as any).vchNo));
  });
  app.delete('/tour-sales/:vchNo', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTourSale(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: (body(req) as any).book,
        deleteUser: mainUserOf(req),
      }),
    );
  });
}
