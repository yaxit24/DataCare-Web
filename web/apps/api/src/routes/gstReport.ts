import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { PdfRenderer } from '../modules/reports/render.js';
import { pdfRenderFailure, PlaywrightPdfRenderer, renderToPdf } from '../modules/reports/render.js';
import {
  assertGstCsvSection,
  gstReport,
  gstReportHtml,
  gstReportSheet,
  gstWorkbook,
  parseGstReportQuery,
} from '../modules/reports/gstReport.js';
import { serializeGstCsv } from '../modules/reports/gstReportCsv.js';
import { GstReportRequestError } from '../modules/reports/gstReportTypes.js';
import { renderXlsx } from '../modules/reports/xlsx.js';

interface GstRouteHelpers {
  prisma: any;
  auth: { preHandler: (req: FastifyRequest, reply: FastifyReply) => Promise<void> };
  scopeOf: (req: FastifyRequest) => {
    tenantId: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
  };
  pdfRenderer?: PdfRenderer;
}

export function registerGstReportRoutes(app: FastifyInstance, helpers: GstRouteHelpers): void {
  const { prisma, auth } = helpers;
  const parse = (req: FastifyRequest, override: Record<string, unknown> = {}) => {
    const scope = helpers.scopeOf(req);
    return parseGstReportQuery(
      {
        tenantId: scope.tenantId,
        coCode: scope.coCode,
        lcCode: scope.lcCode,
        coYear: scope.coYear ?? '',
      },
      { ...((req.query ?? {}) as Record<string, unknown>), ...override },
    );
  };
  const build = async (req: FastifyRequest) => gstReport(prisma, parse(req));
  const handle = async (reply: FastifyReply, operation: () => Promise<unknown>) => {
    try {
      return await operation();
    } catch (error) {
      if (error instanceof GstReportRequestError) {
        return reply.code(error.statusCode).send({ error: error.code, ...error.details });
      }
      throw error;
    }
  };

  app.get('/reports/gst-report', auth, async (req, reply) =>
    handle(reply, async () => reply.code(200).send(await build(req))),
  );
  app.get('/reports/gst-report/export.csv', auth, async (req, reply) =>
    handle(reply, async () => {
      const report = await build(req);
      assertGstCsvSection(report);
      return reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header('content-disposition', `attachment; filename="${report.fileName}.csv"`)
        .send(serializeGstCsv(report));
    }),
  );
  app.get('/reports/gst-report/export.xlsx', auth, async (req, reply) =>
    handle(reply, async () => {
      const report = await build(req);
      const output = await renderXlsx([gstReportSheet(report)], report.fileName);
      return reply
        .header('content-type', output.contentType)
        .header('content-disposition', `attachment; filename="${output.fileName}"`)
        .send(output.buffer);
    }),
  );
  // "Gsrt1 Csv": every GSTR-1 section B2B..HSN as one workbook; the dates/book/party are the screen's filters.
  app.get('/reports/gst-report/workbook.xlsx', auth, async (req, reply) =>
    handle(reply, async () => {
      const query = (req.query ?? {}) as Record<string, unknown>;
      if (query.view != null || query.section != null) {
        throw new GstReportRequestError('invalid-query', 400, { fields: ['section', 'view'] });
      }
      const {
        view: _view,
        section: _section,
        ...input
      } = parse(req, {
        view: 'gstr1',
        section: 'B2B',
      });
      const reports = await gstWorkbook(prisma, input);
      const output = await renderXlsx(reports.map(gstReportSheet), 'GSTR1');
      return reply
        .header('content-type', output.contentType)
        .header('content-disposition', `attachment; filename="${output.fileName}"`)
        .send(output.buffer);
    }),
  );
  app.get('/reports/gst-report/export.pdf', auth, async (req, reply) =>
    handle(reply, async () => {
      const report = await build(req);
      let pdf: Buffer;
      try {
        pdf = await renderToPdf(
          gstReportHtml(report),
          helpers.pdfRenderer ?? new PlaywrightPdfRenderer(),
        );
      } catch (error) {
        const failure = pdfRenderFailure(error);
        if (failure.retryAfter) reply.header('Retry-After', String(failure.retryAfter));
        return reply.code(failure.status).send(failure.body);
      }
      return reply
        .header('content-type', 'application/pdf')
        .header('content-disposition', `inline; filename="${report.fileName}.pdf"`)
        .send(pdf);
    }),
  );
}
