import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  exportCsv,
  exportTable,
  stockDefaults,
  stockMovements,
  stockSummary,
  stockZoom,
  itemLedger,
  itemLedgerItems,
  itemLedgerTable,
  StockReportError,
  type StockSession,
} from '../modules/reports/stockReport/index.js';
import { renderXlsx } from '../modules/reports/xlsx.js';
import { authorizeForm, FormForbiddenError } from '../modules/rbac/authorization.js';

/**
 * Report -> Stock Report: the desktop RP_STOCK form (MDI_FORM.cs:8881-8890), on its own route.
 *
 *   GET /reports/stock-report/defaults    form defaults: From, To, Item Type, Gross Wise Weight (RP_STOCK.cs:3705-3647)
 *   GET /reports/stock-report             dimension=item|product|group|design|safe|counter|trading|size + filters
 *   GET /reports/stock-report/movements   the movements behind one summary cell (double click, RP_STOCK.cs:2816)
 *   GET /reports/stock-report/export.csv  the summary as shown, with the "Total :" row   (Print right)
 *   GET /reports/stock-report/export.xlsx the same as Excel                                (Print right)
 *   GET /reports/stock-report/export.pdf  the same as a printed document                   (Print right)
 *
 * Company, location and year come from the session; the query may only narrow them. The Tag Stock report
 * (RP_TAG) stays on /reports/tag-stock.
 */
export interface StockReportRouteHelpers {
  prisma: any;
  auth: { preHandler: unknown };
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  readScope: (req: FastifyRequest) => {
    tenantId: string;
    coCode: string;
    lcCode?: string;
    coYear?: string;
  };
  /** The shared PDF writer (the same one the other reports print through). */
  sendReportPdf?: (
    req: FastifyRequest,
    reply: FastifyReply,
    slug: string,
    form: string,
    result: unknown,
  ) => Promise<unknown>;
}

export function registerStockReportRoutes(app: FastifyInstance, h: StockReportRouteHelpers): void {
  const { prisma, auth, guard, readScope, sendReportPdf } = h;
  const session = (req: FastifyRequest): StockSession => {
    const s = readScope(req);
    return {
      tenantId: s.tenantId,
      coCode: s.coCode,
      lcCode: s.lcCode ?? '',
      coYear: s.coYear ?? '',
    };
  };
  const query = (req: FastifyRequest) => (req.query ?? {}) as Record<string, unknown>;
  const fail = (reply: FastifyReply, error: unknown): boolean => {
    if (error instanceof StockReportError) {
      void reply
        .code(error.statusCode)
        .send({ error: error.code, message: error.message, ...error.details });
      return true;
    }
    return false;
  };

  app.get('/reports/stock-report/defaults', auth as any, async (req, reply) => {
    return reply.send(await stockDefaults(prisma, session(req)));
  });

  app.get('/reports/stock-report', auth as any, async (req, reply) => {
    try {
      return reply.send(await stockSummary(prisma, session(req), query(req)));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/stock-report/movements', auth as any, async (req, reply) => {
    try {
      return reply.send(await stockMovements(prisma, session(req), query(req)));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  /** A double click on a movement row (RP_STOCK.cs:5218): which entry screen opens that voucher, or why none does. */
  app.get('/reports/stock-report/zoom', auth as any, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    const coBook = String(q.coBook ?? '').slice(0, 3);
    const vchNo = String(q.vchNo ?? '').slice(0, 10);
    const state = req as unknown as {
      principal?: any;
      session?: { tenantId: string; lcCode?: string };
    };
    const s = session(req);
    const canView = async (form: string): Promise<boolean> => {
      try {
        await authorizeForm(prisma, {
          tenantId: s.tenantId,
          lcCode: s.lcCode,
          principal: state.principal,
          form,
          action: 'read',
        } as any);
        return true;
      } catch (error) {
        if (error instanceof FormForbiddenError) return false;
        throw error;
      }
    };
    return reply.send(await stockZoom(prisma, s, coBook, vchNo, canView));
  });

  /** Print (RP_STOCK.cs:4020-4240): the summary on screen, printed through the shared PDF writer (Print right). */
  app.get('/reports/stock-report/export.pdf', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await stockSummary(prisma, session(req), query(req));
      const table = exportTable(result);
      const rows = table.lines.map((line) =>
        Object.fromEntries(table.header.map((head, i) => [head, line[i] ?? ''])),
      );
      if (!sendReportPdf) return reply.code(501).send({ error: 'pdf-unavailable' });
      return sendReportPdf(req, reply, 'stock-report', `Reports/${result.title.trim()}`, { rows });
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  /** The InOut picker's item list for an Item Type (RP_STOCK.cs:5879). */
  app.get('/reports/stock-report/item-ledger/items', auth as any, async (req, reply) => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return reply.send(await itemLedgerItems(prisma, session(req), String(q.itemType ?? '')));
  });

  /** The item ledger of the ticked items (RP_STOCK.cs:5946-5976), as data and as a PDF (Print right). */
  app.get('/reports/stock-report/item-ledger', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      return reply.send(await itemLedger(prisma, session(req), query(req)));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });
  app.get('/reports/stock-report/item-ledger.pdf', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const table = itemLedgerTable(await itemLedger(prisma, session(req), query(req)));
      if (!sendReportPdf) return reply.code(501).send({ error: 'pdf-unavailable' });
      return sendReportPdf(req, reply, 'stock-ledger', `Reports/${table.title}`, {
        rows: table.rows,
      });
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  const fileName = (dimension: string, from: string, to: string) =>
    `stock-report-${dimension}-${from}-${to}`;

  app.get('/reports/stock-report/export.csv', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await stockSummary(prisma, session(req), query(req));
      return reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header(
          'content-disposition',
          `attachment; filename="${fileName(result.dimension, result.fromDate, result.toDate)}.csv"`,
        )
        .send(exportCsv(result));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/stock-report/export.xlsx', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await stockSummary(prisma, session(req), query(req));
      const table = exportTable(result);
      const keys = table.header.map((_, i) => `c${i}`);
      const out = await renderXlsx(
        [
          {
            name: 'Stock Report',
            columns: table.header.map((header, i) => ({
              header,
              key: keys[i]!,
              // The desktop writes numeric grid values as numbers rounded to three decimals (RP_STOCK.cs:3306).
              type: i === 1 || i === 2 ? ('text' as const) : ('number' as const),
              format: header.endsWith('Wt') ? '0.000' : '0',
              width: i === 1 ? 28 : 12,
            })),
            rows: table.lines.map((line) => Object.fromEntries(line.map((v, i) => [keys[i]!, v]))),
          },
        ],
        fileName(result.dimension, result.fromDate, result.toDate),
      );
      return reply
        .header('content-type', out.contentType)
        .header('content-disposition', `attachment; filename="${out.fileName}"`)
        .send(out.buffer);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });
}
