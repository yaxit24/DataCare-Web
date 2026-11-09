import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { VoucherScope } from '../modules/vouchers/numbering.js';
import {
  deleteOrderCancel,
  editOrderCancel,
  getOrderCancel,
  listPendingOrders,
  postOrderCancel,
} from '../modules/sales/orderCancel.js';
import {
  orderCancelVoucherHtml,
  OrderCancelPrintNotFoundError,
} from '../modules/sales/orderCancelPrint.js';
import { sendVoucherDocument } from '../modules/documents/voucherPrint.js';

/**
 * Order Cancel (desktop TR_SL_ORD_ADJ on a book of `MAIN_BOOK='ORDER CANCEL'`, MDI_FORM.cs:8628-8639): the voucher's
 * lifecycle, the OrdNo help list and the OrderCancelVch document. Its own file so `txn.ts` does not grow.
 */
export interface OrderCancelRouteHelpers {
  prisma: any;
  auth: any;
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  scopeOf: (req: FastifyRequest) => VoucherScope;
  readScope: (req: FastifyRequest) => VoucherScope;
  run: (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => Promise<unknown>;
  body: (req: FastifyRequest) => Record<string, any>;
  mainUserOf: (req: FastifyRequest) => string;
  standardDocumentCopy: (raw: unknown, reply: FastifyReply) => string | null | undefined;
}

/** One grid row: OrdNo (with its hidden year and book), AdjAmt, KsarAmt, PaidAmt, PaiidAc and It Desc. */
const ROW_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['ordNo', 'adjAmt'],
  properties: {
    ordNo: { type: 'string', minLength: 1, maxLength: 8 },
    ordYear: { type: 'string', maxLength: 9 },
    ordBook: { type: 'string', maxLength: 3 },
    adjAmt: { type: 'number' },
    kasarAmt: { type: 'number' },
    paidAmt: { type: 'number' },
    // The grid's PaiidAc cell takes 8 characters (TR_SL_ORD_ADJ.cs:2318-2322).
    paidAc: { type: 'string', maxLength: 8 },
    // It Desc takes 150 (:2324-2327).
    itDesc: { type: 'string', maxLength: 150 },
  },
} as const;

const BODY_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['rows'],
  properties: {
    coBook: { type: 'string', minLength: 1, maxLength: 3 },
    lcCode: { type: 'string', minLength: 1, maxLength: 2 },
    coYear: { type: 'string', pattern: '^[0-9]{4}-[0-9]{4}$' },
    rows: { type: 'array', maxItems: 200, items: ROW_SCHEMA },
    vchDate: { type: 'string', pattern: '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' },
    empCode: { type: 'string', maxLength: 3 },
    expectedVersion: { type: 'string' },
  },
} as const;

const BODY_KEYS = new Set(Object.keys(BODY_SCHEMA.properties));
const ROW_KEYS = new Set(Object.keys(ROW_SCHEMA.properties));

/** Fastify strips unknown keys by default; an Order Cancel request names every field it sends or is refused. */
async function rejectUnknownFields(req: FastifyRequest, reply: FastifyReply): Promise<void> {
  const raw = req.body;
  if (!raw || typeof raw !== 'object' || Array.isArray(raw)) return;
  const record = raw as Record<string, unknown>;
  const unknown = Object.keys(record).filter((key) => !BODY_KEYS.has(key));
  if (Array.isArray(record.rows))
    record.rows.forEach((row, index) => {
      if (row && typeof row === 'object' && !Array.isArray(row))
        for (const key of Object.keys(row))
          if (!ROW_KEYS.has(key)) unknown.push(`rows[${index}].${key}`);
    });
  if (unknown.length)
    await reply.code(400).send({
      error: 'invalid-input',
      message: `Order Cancel request contains unsupported field(s): ${unknown.join(', ')}`,
    });
}

export function registerOrderCancelRoutes(app: FastifyInstance, h: OrderCancelRouteHelpers): void {
  const { prisma, auth, guard, scopeOf, readScope, run, body, mainUserOf, standardDocumentCopy } =
    h;
  const bodyRoute = {
    ...(auth as object),
    schema: { body: BODY_SCHEMA },
    preValidation: rejectUnknownFields,
  };
  const input = (req: FastifyRequest) => {
    const b = body(req);
    return { scope: scopeOf(req), rows: b.rows, vchDate: b.vchDate, empCode: b.empCode };
  };

  // The OrdNo cell's help (TR_SL_ORD_ADJ.cs:2499-2526): orders of this location with advance still open.
  app.get('/order-cancel/pending-orders', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => listPendingOrders(prisma, scopeOf(req)));
  });
  app.post('/order-cancel', bodyRoute, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () =>
      postOrderCancel(prisma, { ...input(req), mainUser: mainUserOf(req) }),
    );
  });
  app.get('/order-cancel/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getOrderCancel(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  app.put('/order-cancel/:vchNo', bodyRoute, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () =>
      editOrderCancel(
        prisma,
        { ...input(req), expectedVersion: body(req).expectedVersion },
        (req.params as any).vchNo,
      ),
    );
  });
  app.delete('/order-cancel/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteOrderCancel(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        expectedVersion: body(req).expectedVersion,
      }),
    );
  });
  // OrderCancelVch.RPT needs the print right (TR_SL_ORD_ADJ.cs:3796-3800).
  app.get('/order-cancel/:vchNo/print', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const q = req.query as any;
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    try {
      const html = await orderCancelVoucherHtml(
        prisma,
        readScope(req),
        (req.params as any).vchNo,
        copyLabel,
      );
      return sendVoucherDocument(reply, html, {
        format: q.format,
        filename: `order-cancel-${(req.params as any).vchNo}`,
      });
    } catch (e: any) {
      if (e instanceof OrderCancelPrintNotFoundError)
        return reply.code(404).send({ error: e.code, message: e.message });
      if (/(ValidationError|NumberingConfigurationError)$/.test(e?.name ?? ''))
        return reply.code(400).send({ error: e.name, message: e.message });
      throw e;
    }
  });
}
