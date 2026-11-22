import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  TagStockValidationError,
  parseTagStockQuery,
  tagStockCsv,
  tagStockReport,
  type TagStockColumn,
  type TagStockReport,
} from '../modules/reports/tagStock.js';
import { renderXlsx, type XlsxColumn } from '../modules/reports/xlsx.js';

/**
 * Report → Tag Stock (desktop RP_TAG, MDI_FORM.cs:8891-8900). The resolver is read-only; the screen, the CSV and
 * the Excel export are the same report object, so they cannot disagree. The session decides tenant, company and
 * year; the query may narrow the location (blank = every location of the company) and the selectors.
 *
 *   GET /reports/tag-stock        List right
 *   GET /reports/tag-stock.csv    Print right (the desktop Excel button, RP_TAG.cs:3257-3263)
 *   GET /reports/tag-stock.xlsx   Print right
 */
export interface TagStockRouteHelpers {
  prisma: any;
  auth: { preHandler: unknown };
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  scopeOf: (req: FastifyRequest) => { tenantId: string; coCode: string; lcCode: string; coYear?: string };
}

const xlsxColumn = (c: TagStockColumn): XlsxColumn => ({
  header: c.header,
  key: c.key,
  type: c.kind === 'int' || c.kind === 'wt' || c.kind === 'amt' ? 'number' : 'text',
  ...(c.kind === 'wt' ? { format: '0.000' } : c.kind === 'amt' ? { format: '0' } : {}),
  width: c.kind === 'text' || c.kind === 'date' ? 14 : 12,
});

export function registerTagStockRoutes(app: FastifyInstance, h: TagStockRouteHelpers): void {
  const { prisma, auth, guard, scopeOf } = h;

  const resolve = async (req: FastifyRequest): Promise<TagStockReport> => {
    const s = scopeOf(req);
    const { tab, filters } = parseTagStockQuery((req.query ?? {}) as Record<string, unknown>);
    return tagStockReport(
      prisma,
      s.tenantId,
      { CO_CODE: s.coCode, LC_CODE: s.lcCode, CO_YEAR: s.coYear },
      tab,
      filters,
    );
  };
  const fail = (reply: FastifyReply, error: unknown): boolean => {
    if (error instanceof TagStockValidationError) {
      void reply.code(400).send({ error: 'invalid-request', message: error.message });
      return true;
    }
    return false;
  };
  const slug = (rep: TagStockReport) => (rep.view === 'tag' ? rep.tab : `${rep.tab}-${rep.view}`);

  app.get('/reports/tag-stock', auth as any, async (req, reply) => {
    try {
      return reply.send(await resolve(req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/tag-stock.csv', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const rep = await resolve(req);
      return reply
        .type('text/csv; charset=utf-8')
        .header('content-disposition', `attachment; filename="tag-stock-${slug(rep)}.csv"`)
        .send(
          tagStockCsv({
            columns: rep.columns,
            rows: rep.rows as unknown as Array<Record<string, unknown>>,
            totals: rep.totals as unknown as Record<string, number>,
          }),
        );
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/tag-stock.xlsx', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const rep = await resolve(req);
      const out = await renderXlsx(
        [
          {
            name: 'Tag Stock',
            columns: rep.columns.map(xlsxColumn),
            rows: rep.rows as unknown as Record<string, unknown>[],
            totals: rep.totals as unknown as Record<string, unknown>,
          },
        ],
        `tag-stock-${slug(rep)}`,
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
