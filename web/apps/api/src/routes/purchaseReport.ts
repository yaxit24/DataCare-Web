import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { pdfRenderFailure, PlaywrightPdfRenderer, renderToPdf } from '../modules/reports/render.js';
import type { PdfRenderer } from '../modules/reports/render.js';
import {
  purchaseOutputTable,
  purchaseReport,
  purchaseReportHtml,
  purchaseReportOptions,
  RpAllRequestError,
  type PurchaseReportResponse,
} from '../modules/reports/purchaseReport.js';
import { exportCsv, exportXlsxColumns } from '../modules/reports/rpAll/exportRows.js';
import { renderXlsx } from '../modules/reports/xlsx.js';
import type { RpAllRouteHelpers } from './rpAllReport.js';

/**
 * Report → Purchase Rpt: the desktop RP_ALL form in its "Purchase Rpt" caption (MDI_FORM.cs:8911-8920,
 * RP_ALL.cs:6704-6707), served by the shared RP_ALL engine (modules/reports/rpAll) like the Sales Report.
 *
 *   GET /reports/purchase-report              mode=report|register|item|bill|party|group|party-summary,
 *                                             fromDate, toDate, selectors
 *   GET /reports/purchase-report/options      City and Area drop-down values
 *   GET /reports/purchase-report/export.csv   the same dataset, every row, as CSV    (Print right)
 *   GET /reports/purchase-report/export.xlsx  the same dataset as Excel               (Print right)
 *   GET /reports/purchase-report/export.pdf   the same dataset as PDF                 (Print right)
 *
 * Company, location and year come from the session; the query may only narrow them. Rights are the
 * "Purchase Rpt" caption's (routePolicy.ts → formCatalog alias): List for the screen, Print for the exports,
 * refused by the API, not only hidden.
 */
export function registerPurchaseReportRoutes(
  app: FastifyInstance,
  h: RpAllRouteHelpers & { pdfRenderer?: PdfRenderer },
): void {
  const { prisma, auth, guard, readScope } = h;

  const build = (req: FastifyRequest): Promise<PurchaseReportResponse> => {
    const s = readScope(req);
    return purchaseReport(
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
  const fileName = (r: PurchaseReportResponse) =>
    `purchase-report-${r.mode}-${r.filters.fromDate}-${r.filters.toDate}`;
  const exporter =
    (send: (reply: FastifyReply, result: PurchaseReportResponse) => Promise<unknown> | unknown) =>
    async (req: FastifyRequest, reply: FastifyReply) => {
      if (!guard(req, reply, 'print')) return;
      try {
        return await send(reply, await build(req));
      } catch (error) {
        if (fail(reply, error)) return reply;
        throw error;
      }
    };

  app.get('/reports/purchase-report', auth as any, async (req, reply) => {
    try {
      return reply.send(await build(req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/purchase-report/options', auth as any, async (req, reply) => {
    const s = readScope(req);
    return reply.send(await purchaseReportOptions(prisma, s.tenantId, s.coCode));
  });

  app.get(
    '/reports/purchase-report/export.csv',
    auth as any,
    exporter((reply, result) =>
      reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header('content-disposition', `attachment; filename="${fileName(result)}.csv"`)
        .send(exportCsv(result as never, purchaseOutputTable(result))),
    ),
  );

  app.get(
    '/reports/purchase-report/export.xlsx',
    auth as any,
    exporter(async (reply, result) => {
      const table = purchaseOutputTable(result);
      const out = await renderXlsx(
        [
          {
            name: result.caption,
            columns: exportXlsxColumns(result as never, table),
            rows: table.lines,
          },
        ],
        fileName(result),
      );
      return reply
        .header('content-type', out.contentType)
        .header('content-disposition', `attachment; filename="${out.fileName}"`)
        .send(out.buffer);
    }),
  );

  app.get(
    '/reports/purchase-report/export.pdf',
    auth as any,
    exporter(async (reply, result) => {
      let pdf: Buffer;
      try {
        pdf = await renderToPdf(
          purchaseReportHtml(result),
          h.pdfRenderer ?? new PlaywrightPdfRenderer(),
        );
      } catch (error) {
        const failure = pdfRenderFailure(error);
        if (failure.retryAfter) reply.header('Retry-After', String(failure.retryAfter));
        return reply.code(failure.status).send(failure.body);
      }
      return reply
        .header('content-type', 'application/pdf')
        .header('content-disposition', `inline; filename="${fileName(result)}.pdf"`)
        .send(pdf);
    }),
  );
}
