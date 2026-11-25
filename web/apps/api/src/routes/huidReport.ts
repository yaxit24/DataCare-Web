import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  authorizeForm,
  FormForbiddenError,
  type Principal,
} from '../modules/rbac/authorization.js';
import {
  huidTagReport,
  parseHuidTagQuery,
  HuidTagReportValidationError,
  huidTagTotals,
  type HuidTagReport,
} from '../modules/reports/huidTagReport.js';
import { toCsv } from '../modules/reports/reportCsv.js';
import { renderXlsx, type XlsxColumn, type XlsxSheet } from '../modules/reports/xlsx.js';

/**
 * WP-18 HuId Report routes — the desktop RP_HUID screen and its Excel / CSV / PDF outputs (Lite "HuId
 * Report" menu, MDI_FORM.cs:9032-9041). A dedicated plugin, exactly like the account ledger's, so the
 * dataset resolver in modules/reports/huidTagReport.ts feeds the screen and every export from one code
 * path and they can never disagree.
 *
 *   GET /reports/huid                 (view=stock|in|out, from, to, itemType, product, group, tagNo,
 *                                     acCode, hallmark, search) → {view, from, to, columns, rows, totals}
 *   GET /reports/huid/export.csv
 *   GET /reports/huid/export.xlsx
 *   GET /reports/huid/export.pdf
 *
 * Business scope (tenant/company/location/year) always comes from the session via readScope; the query may
 * only narrow the report. The desktop's Print button checks no right (RP_HUID.cs:2189-2191) while its
 * Excel button refuses without one (`You Have No Print Rights.....`, RP_HUID.cs:1359-1361); the web
 * deliberately gates every export on the print right (owner decision, cases.md `rights.print-refused-*`),
 * and refuses with the desktop's refusal shape `{error:'forbidden', action:'print'}` so the screen can
 * show the desktop's own message text.
 */
export interface HuidReportRouteHelpers {
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
  sendReportPdf: (
    req: FastifyRequest,
    reply: FastifyReply,
    slug: string,
    form: string,
    result: unknown,
  ) => Promise<unknown>;
}

const HUID_FORM = 'Reports/HuId Report';

/** Column metadata so exported codes/dates stay text and weights keep their three-decimal scale. */
function xlsxColumnsOf(result: HuidTagReport): XlsxColumn[] {
  return result.columns
    .filter((c) => !c.hidden)
    .map((c): XlsxColumn => {
      if (c.key === 'qty')
        return { header: c.header, key: c.key, type: 'number', format: '0', width: 8 };
      if (c.total)
        return { header: c.header, key: c.key, type: 'number', format: '0.000', width: 12 };
      return { header: c.header, key: c.key, type: 'text', width: c.key === 'itRemark' ? 24 : 14 };
    });
}

function sheetOf(result: HuidTagReport): XlsxSheet {
  return {
    name: `HuId ${result.view}`,
    columns: xlsxColumnsOf(result),
    rows: result.rows as unknown as Record<string, unknown>[],
    totals: result.totals as unknown as Record<string, unknown>,
  };
}

/**
 * The desktop print selection (RP_HUID.cs:2219 `{TAG_STOCK_PRINT.VCH_DATE} <= #…#`): the printed report
 * filters the voucher date, which for the Stock view can drop a row the grid still shows (the grid filters
 * the stock date, RP_HUID.cs:1838). Applied to the resolved rows — never a second query, and never a
 * staging table: the desktop's `TAG_STOCK_PRINT` shared-list weakness (study 2-4) is not ported.
 */
function printResultOf(result: HuidTagReport): Record<string, unknown> {
  const rows = result.rows.filter((row) => row.vchDate != null && row.vchDate <= result.to);
  // One section per product > group, in first-appearance order (TagHuIdRpt.xml groups on
  // {ITEM_MAST.PR_CODE} and {ITEM_MAST.GR_CODE}; the rows carry the hidden prCode/grCode for this).
  const sections = new Map<string, HuidTagReport['rows']>();
  for (const row of rows) {
    const key = `${row.prCode ?? ''} / ${row.grCode ?? ''}`;
    const bucket = sections.get(key);
    if (bucket) bucket.push(row);
    else sections.set(key, [row]);
  }
  return {
    view: result.view,
    from: result.from,
    to: result.to,
    ...Object.fromEntries([...sections.entries()].map(([key, value]) => [`Group ${key}`, value])),
    totals: huidTagTotals(rows),
  };
}

export function registerHuidReportRoutes(app: FastifyInstance, h: HuidReportRouteHelpers): void {
  const { prisma, auth, guard, readScope, sendReportPdf } = h;

  /** Send a domain error as its HTTP status; rethrow anything else for the global handler. */
  const fail = (reply: FastifyReply, error: unknown): boolean => {
    if (error instanceof HuidTagReportValidationError) {
      void reply.code(400).send({ error: 'validation', message: error.message });
      return true;
    }
    return false;
  };

  const resolve = async (req: FastifyRequest): Promise<HuidTagReport> => {
    const q = parseHuidTagQuery((req.query ?? {}) as Record<string, unknown>);
    const s = readScope(req);
    // readScope marks location and year optional (a session without an Open Company selection has
    // neither); the report must not run silently unscoped, so a missing one is a client error.
    if (!s.lcCode || !s.coYear)
      throw new HuidTagReportValidationError('session scope is incomplete');
    return huidTagReport(
      prisma,
      { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear },
      q,
    );
  };

  /**
   * The print gate. The route's policy classifies GET as a read, so the central preHandler has already
   * proved the view right; the export itself needs the desktop's print right (USER_SET.FRM_PRINT,
   * read at RP_HUID.cs:1414 and tested by the desktop's Excel button at :1359), so it is re-checked here
   * and refused with the shape every report export uses, `{error:'forbidden', form, action:'print'}`
   * (txn.ts guard). Admins keep their bootstrap bypass (authorization.ts).
   */
  const requirePrint = async (req: FastifyRequest, reply: FastifyReply): Promise<boolean> => {
    if (!guard(req, reply, 'print')) return false;
    const state = req as { session?: { tenantId: string; lcCode: string }; principal?: Principal };
    const session = state.session;
    const principal = state.principal;
    if (!session || !principal) return true; // unreachable behind `auth`; defense in depth only
    try {
      await authorizeForm(prisma, {
        tenantId: session.tenantId,
        lcCode: session.lcCode,
        principal,
        form: HUID_FORM,
        action: 'print',
      });
      return true;
    } catch (error) {
      if (error instanceof FormForbiddenError) {
        void reply.code(403).send({ error: 'forbidden', form: HUID_FORM, action: 'print' });
        return false;
      }
      throw error;
    }
  };

  // The screen dataset. View right through the route policy; a 400 names the first invalid input.
  app.get('/reports/huid', auth as any, async (req, reply) => {
    try {
      return reply.send(await resolve(req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/huid/export.csv', auth as any, async (req, reply) => {
    if (!(await requirePrint(req, reply))) return;
    try {
      const result = await resolve(req);
      const columns = result.columns.filter((c) => !c.hidden).map((c) => c.key);
      return reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header('content-disposition', `attachment; filename="huid-${result.view}.csv"`)
        .send(
          toCsv(result.rows as unknown as Record<string, unknown>[], {
            columns,
            totals: result.totals as unknown as Record<string, unknown>,
          }),
        );
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/huid/export.xlsx', auth as any, async (req, reply) => {
    if (!(await requirePrint(req, reply))) return;
    try {
      const result = await resolve(req);
      const out = await renderXlsx([sheetOf(result)], `huid-${result.view}`);
      return reply
        .header('content-type', out.contentType)
        .header('content-disposition', `attachment; filename="${out.fileName}"`)
        .send(out.buffer);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/huid/export.pdf', auth as any, async (req, reply) => {
    if (!(await requirePrint(req, reply))) return;
    try {
      const result = await resolve(req);
      // The desktop title (RP_HUID.cs:2192 `Tag Wise Huid Report As on Date ` + the To date).
      const printed = printResultOf(result);
      const to = result.to.split('-');
      const title = `Tag Wise Huid Report As on Date ${to[2]}/${to[1]}/${to[0]}`;
      return sendReportPdf(req, reply, 'huid', `Reports/${title}`, printed);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });
}
