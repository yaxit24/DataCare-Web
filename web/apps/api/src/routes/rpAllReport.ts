import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  orderReport,
  RpAllRequestError,
  salesReport,
  type RpAllResult,
} from '../modules/reports/rpAll/index.js';
import { exportCsv, exportTable, exportXlsxColumns } from '../modules/reports/rpAll/exportRows.js';
import { renderXlsx } from '../modules/reports/xlsx.js';
import { withTxBudget } from '../modules/shared/txBudget.js';

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

  const scope = (req: FastifyRequest) => {
    const s = readScope(req);
    return {
      tenantId: s.tenantId,
      coCode: s.coCode,
      lcCode: s.lcCode ?? '',
      coYear: s.coYear ?? '',
    };
  };
  const build = (branch: 'sales' | 'order', req: FastifyRequest): Promise<RpAllResult> => {
    const query = (req.query ?? {}) as Record<string, unknown>;
    return branch === 'order'
      ? orderReport(prisma, scope(req), query)
      : salesReport(prisma, scope(req), query);
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
    `${r.branch}-report-${r.mode}${r.variant === 'return' ? '-return' : ''}-${r.filters.fromDate}-${r.filters.toDate}`;

  // The desktop keys the Order Report right on the caption's own USER_SET row, not on the Sales Order
  // form (MDI_FORM.cs:7034 {{DC_Main.MsUserRightForm = MsSideBtn;}},
  // RP_ALL.cs:6656 {{Select * From USER_SET WHERE LC_CODE = '}}). formCatalog.ts has no alias for that
  // caption and is outside this packet, so the order routes are registered as system routes and their
  // rights are enforced here by a bound query. Print is a web-only hosted-service rule (D7): the desktop
  // reads FRM_PRINT (RP_ALL.cs:6777 {{dataTable.Rows[0]["FRM_PRINT"]}}) but never compares it.
  const orderRight = async (req: FastifyRequest, print: boolean): Promise<boolean> => {
    const s = readScope(req);
    const loginName = String((req as any).principal?.loginName ?? '');
    return withTxBudget(prisma, s.tenantId, 'read', async (tx: any) => {
      const rows = (await tx.$queryRawUnsafe(
        `SELECT "FRM_VIEW","FRM_PRINT" FROM "USER_SET"
          WHERE tenant_id=$1 AND "CO_CODE"=$2 AND "LC_CODE"=$3 AND "USER_NAME"=$4
            AND UPPER(TRIM(COALESCE("SUB_MENU",'')))='ORDER REPORT'
          ORDER BY "row_id" LIMIT 1`,
        s.tenantId,
        s.coCode,
        s.lcCode ?? '',
        loginName,
      )) as Array<{ FRM_VIEW?: string | null; FRM_PRINT?: string | null }>;
      const row = rows[0];
      const yes = (value?: string | null) => value === 'Y' || value === '1';
      return yes(row?.FRM_VIEW) && (!print || yes(row?.FRM_PRINT));
    });
  };

  app.get('/reports/sales-report', auth as any, async (req, reply) => {
    try {
      return reply.send(await build('sales', req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/sales-report/export.csv', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await build('sales', req);
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
      const result = await build('sales', req);
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

  app.get('/reports/order-report', auth as any, async (req, reply) => {
    if (!(await orderRight(req, false))) {
      reply.code(403).send({ error: 'forbidden', form: 'Order Report' });
      return;
    }
    try {
      return reply.send(await build('order', req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/order-report/export.csv', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    if (!(await orderRight(req, true))) {
      reply.code(403).send({ error: 'forbidden', form: 'Order Report', action: 'print' });
      return;
    }
    try {
      const result = await build('order', req);
      return reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header('content-disposition', `attachment; filename="${fileName(result)}.csv"`)
        .send(exportCsv(result));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/order-report/export.xlsx', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    if (!(await orderRight(req, true))) {
      reply.code(403).send({ error: 'forbidden', form: 'Order Report', action: 'print' });
      return;
    }
    try {
      const result = await build('order', req);
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
