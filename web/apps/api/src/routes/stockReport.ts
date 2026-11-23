import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  exportCsv,
  exportTable,
  stockDefaults,
  stockMovements,
  stockSummary,
  StockReportError,
  type StockSession,
} from '../modules/reports/stockReport/index.js';
import { renderXlsx } from '../modules/reports/xlsx.js';

/**
 * Report -> Stock Report: the desktop RP_STOCK form (MDI_FORM.cs:8881-8890), on its own route.
 *
 *   GET /reports/stock-report/defaults    form defaults: From, To, Item Type, Gross Wise Weight (RP_STOCK.cs:3705-3647)
 *   GET /reports/stock-report             dimension=item|product|group|design|safe|counter|trading|size + filters
 *   GET /reports/stock-report/movements   the movements behind one summary cell (double click, RP_STOCK.cs:2816)
 *   GET /reports/stock-report/export.csv  the summary as shown, with the "Total :" row   (Print right)
 *   GET /reports/stock-report/export.xlsx the same as Excel                                (Print right)
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
}

export function registerStockReportRoutes(app: FastifyInstance, h: StockReportRouteHelpers): void {
  const { prisma, auth, guard, readScope } = h;
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
              type: 'text' as const,
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
