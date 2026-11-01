import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  accountLedgerReport,
  parseAccountLedgerQuery,
  AccountLedgerValidationError,
  AccountNotFoundError,
  type AccountLedgerResult,
  type AccountLedgerView,
} from '../modules/reports/accountLedgerReport.js';
import { toCsv } from '../modules/reports/reportCsv.js';
import { renderXlsx, type XlsxColumn, type XlsxSheet } from '../modules/reports/xlsx.js';

/**
 * Account Ledger report routes — the desktop RP_LEDR screen and its Excel/CSV/PDF outputs
 * (Lite "Ledger Report" menu, MDI_FORM.cs:8871-8880). Extracted into its own plugin so the dataset
 * resolver in modules/reports/accountLedgerReport.ts feeds the screen and every export from one code
 * path — the screen and its exports can never disagree (the lesson the generic /reports pipeline learned).
 *
 * The canonical family carries its selectors in the query:
 *   GET /reports/account-ledger            (view=summary|detail|voucher-summary|ageing, acCode?, ...)
 *   GET /reports/account-ledger/export.pdf
 *   GET /reports/account-ledger/export.xlsx
 *   GET /reports/account-ledger/export.csv
 * The two older account-in-path routes are kept as thin aliases (view=detail) so the existing screen and
 * its PDF keep working during the UI migration:
 *   GET /reports/account-ledger/:acCode
 *   GET /reports/account-ledger/:acCode/export.pdf
 *
 * Business scope (tenant/company/location/year) always comes from the session via readScope; the query
 * may only narrow the report.
 */
export interface AccountLedgerRouteHelpers {
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

/** Column metadata so exported codes/dates stay text and money/weights keep their precision. */
function columnsFor(view: AccountLedgerView): XlsxColumn[] {
  const money = (header: string, key: string): XlsxColumn => ({
    header,
    key,
    type: 'number',
    format: '0.00',
    width: 14,
  });
  const wt = (header: string, key: string): XlsxColumn => ({
    header,
    key,
    type: 'number',
    format: '0.000',
    width: 14,
  });
  const text = (header: string, key: string, width = 18): XlsxColumn => ({
    header,
    key,
    type: 'text',
    width,
  });
  if (view === 'summary')
    return [
      text('Sr', 'srNo', 6),
      text('Account', 'acCode', 12),
      text('Name', 'acName', 28),
      text('Mobile', 'mobile', 14),
      money('Dr Amt', 'drAmt'),
      money('Cr Amt', 'crAmt'),
      wt('Dr Gold', 'drGold'),
      wt('Cr Gold', 'crGold'),
      wt('Dr Silver', 'drSilver'),
      wt('Cr Silver', 'crSilver'),
    ];
  if (view === 'ageing')
    return [
      text('Account', 'acCode', 12),
      text('Name', 'acName', 28),
      money('0-15', 'amt15'),
      money('16-30', 'amt30'),
      money('31-45', 'amt45'),
      money('46-60', 'amt60'),
      money('61-90', 'amt90'),
      money('91-120', 'amt120'),
      money('121-150', 'amt150'),
      money('151+', 'amt151'),
      money('Total Amt', 'amt'),
      wt('Fine 151+', 'wt151'),
      wt('Fine Total', 'wt'),
    ];
  // detail and voucher-summary share the ledger columns
  return [
    text('Sr', 'srNo', 6),
    text('Book', 'bookName', 16),
    text('Vch No', 'vchNo', 10),
    text('Date', 'date', 12),
    text('Party', 'party', 28),
    money('Cr Amt', 'crAmt'),
    money('Dr Amt', 'drAmt'),
    money('Bal Amt', 'balAmt'),
    text('Cr/Dr', 'amtSide', 8),
    wt('Cr Gold', 'crGold'),
    wt('Dr Gold', 'drGold'),
    wt('Bal Gold', 'balGold'),
    wt('Cr Silver', 'crSilver'),
    wt('Dr Silver', 'drSilver'),
    wt('Bal Silver', 'balSilver'),
    text('Remark', 'remark', 24),
  ];
}

function sheetFor(result: AccountLedgerResult): XlsxSheet {
  const columns = columnsFor(result.view);
  const rows = result.rows as Record<string, unknown>[];
  const totals = result.totals as Record<string, unknown>;
  return { name: `Account Ledger ${result.view}`, columns, rows, totals };
}

export function registerAccountLedgerRoutes(
  app: FastifyInstance,
  h: AccountLedgerRouteHelpers,
): void {
  const { prisma, auth, guard, readScope, sendReportPdf } = h;

  /** Send a domain error as its HTTP status; rethrow anything else for the global handler. */
  const fail = (reply: FastifyReply, error: unknown): boolean => {
    if (error instanceof AccountLedgerValidationError) {
      void reply.code(400).send({ error: 'invalid-request', message: error.message });
      return true;
    }
    if (error instanceof AccountNotFoundError) {
      void reply.code(404).send({ error: 'account-not-found', acCode: error.acCode });
      return true;
    }
    return false;
  };

  const resolve = async (req: FastifyRequest): Promise<AccountLedgerResult> => {
    const q = parseAccountLedgerQuery((req.query ?? {}) as Record<string, unknown>);
    const s = readScope(req);
    return accountLedgerReport(prisma, s, q);
  };

  // Canonical screen dataset (view selector in the query). Read right (a GET defaults to read/view).
  // Inputs are validated by parseAccountLedgerQuery (fail-closed 400), as every other report route does.
  app.get('/reports/account-ledger', auth as any, async (req, reply) => {
    try {
      return reply.send(await resolve(req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/account-ledger/export.csv', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await resolve(req);
      const columns = columnsFor(result.view).map((c) => c.key);
      return reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header('content-disposition', `attachment; filename="account-ledger-${result.view}.csv"`)
        .send(
          toCsv(result.rows as Record<string, unknown>[], {
            columns,
            totals: result.totals as Record<string, unknown>,
          }),
        );
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/account-ledger/export.xlsx', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await resolve(req);
      const out = await renderXlsx([sheetFor(result)], `account-ledger-${result.view}`);
      return reply
        .header('content-type', out.contentType)
        .header('content-disposition', `attachment; filename="${out.fileName}"`)
        .send(out.buffer);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/account-ledger/export.pdf', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const result = await resolve(req);
      return sendReportPdf(req, reply, 'account-ledger', 'Reports/Account Ledger', result);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  // Compatibility aliases: the old account-in-path screen and PDF, forced to the detail view.
  const aliasQuery = (req: FastifyRequest): Record<string, unknown> => {
    const q = (req.query ?? {}) as Record<string, unknown>;
    return {
      view: 'detail',
      acCode: (req.params as any).acCode,
      fromDate: q.fromDate,
      toDate: q.toDate,
      dataType: q.dataType,
    };
  };
  app.get('/reports/account-ledger/:acCode', auth as any, async (req, reply) => {
    try {
      const q = parseAccountLedgerQuery(aliasQuery(req));
      return reply.send(await accountLedgerReport(prisma, readScope(req), q));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });
  app.get('/reports/account-ledger/:acCode/export.pdf', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const q = parseAccountLedgerQuery(aliasQuery(req));
      const result = await accountLedgerReport(prisma, readScope(req), q);
      return sendReportPdf(req, reply, 'account-ledger', 'Reports/Account Ledger', result);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });
}
