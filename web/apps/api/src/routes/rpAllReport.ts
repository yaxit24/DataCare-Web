import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  RpAllRequestError,
  salesReport,
  type RpAllResult,
} from '../modules/reports/rpAll/index.js';
import { exportCsv, exportTable, exportXlsxColumns } from '../modules/reports/rpAll/exportRows.js';
import { renderXlsx } from '../modules/reports/xlsx.js';

/**
 * Report → Sales Report: the desktop RP_ALL form in its "Sales Report" caption (MDI_FORM.cs:8901-8910,
 * RP_ALL.cs:6676-6698), served by the shared RP_ALL engine (modules/reports/rpAll).
 *
 *   GET /reports/sales-report              mode=report|register|item|group|employee|with-order,
 *                                          returns=yes|no, orderOnly=yes|no, fromDate, toDate, selectors
 *   GET /reports/sales-report/export.csv   the same dataset, every row, as CSV  (Print right)
 *   GET /reports/sales-report/export.xlsx  the same dataset as Excel             (Print right)
 *
 * Company, location and year come from the session; the query may only narrow them (filters.ts). Rights are
 * the "Sales Report" caption's (routePolicy.ts → formCatalog alias), refused by the API, not only hidden.
 */
export interface RpAllRouteHelpers {
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

export function registerRpAllReportRoutes(app: FastifyInstance, h: RpAllRouteHelpers): void {
  const { prisma, auth, guard, readScope } = h;

  const build = (req: FastifyRequest): Promise<RpAllResult> => {
    const s = readScope(req);
    return salesReport(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode ?? '', coYear: s.coYear ?? '' },
      (req.query ?? {}) as Record<string, unknown>,
    );
  };
  const fail = (reply: FastifyReply, error: unknown): boolean => {
    if (error instanceof RpAllRequestError) {
      void reply
        .code(error.statusCode)
        .send({ error: error.code, message: error.message, ...error.details });
      return true;
    }
    return false;
  };
  const fileName = (r: RpAllResult) =>
    `sales-report-${r.mode}${r.variant === 'return' ? '-return' : ''}-${r.filters.fromDate}-${r.filters.toDate}`;

  app.get('/reports/sales-report', auth as any, async (req, reply) => {
    try {
      return reply.send(await build(req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/sales-report/export.csv', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await build(req);
      return reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header('content-disposition', `attachment; filename="${fileName(result)}.csv"`)
        .send(exportCsv(result));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/sales-report/export.xlsx', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await build(req);
      const table = exportTable(result);
      const out = await renderXlsx(
        [{ name: result.caption, columns: exportXlsxColumns(result), rows: table.lines }],
        fileName(result),
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
