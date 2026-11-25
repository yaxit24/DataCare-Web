import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  AccountLedgerValidationError,
  AccountNotFoundError,
} from '../modules/reports/accountLedgerShared.js';
import {
  ledgerFinePrint,
  parseFinePrintQuery,
  type FinePrintKind,
  type FinePrintResult,
} from '../modules/reports/ledgerFinePrints.js';
import { finePrintPdfResult, finePrintSheet } from '../modules/reports/ledgerFinePrintsPdf.js';
import { renderXlsx } from '../modules/reports/xlsx.js';
import type { AccountLedgerRouteHelpers } from './accountLedger.js';

/**
 * Ledger Report fine prints (WP-20): the desktop JmaUdr, Gold and Silver buttons of RP_LEDR as read-only data
 * routes with PDF and Excel siblings. Nothing is written (decision D-20-2). The view right guards the data, the
 * print right the exports (routePolicy.ts, form "Reports/Account Ledger").
 *   GET /reports/account-ledger/jama-udhar        (JmUdAmt)
 *   GET /reports/account-ledger/gold-fine         (JmUdFine, JmUdFineHz)
 *   GET /reports/account-ledger/silver-fine       (JmUdFineSl, JmUdFineSlHz)
 * each with /export.pdf and /export.xlsx.
 */
export function registerLedgerFinePrintRoutes(
  app: FastifyInstance,
  h: AccountLedgerRouteHelpers,
): void {
  const { prisma, auth, readScope, sendReportPdf } = h;

  const resolve = (kind: FinePrintKind, req: FastifyRequest): Promise<FinePrintResult> =>
    ledgerFinePrint(
      prisma,
      readScope(req),
      kind,
      parseFinePrintQuery(kind, (req.query ?? {}) as Record<string, unknown>),
    );

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

  const data = (kind: FinePrintKind) => async (req: FastifyRequest, reply: FastifyReply) => {
    try {
      return reply.send(await resolve(kind, req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  };
  const pdf = (kind: FinePrintKind) => async (req: FastifyRequest, reply: FastifyReply) => {
    try {
      const result = await resolve(kind, req);
      return sendReportPdf(
        req,
        reply,
        `account-ledger-${kind}`,
        'Reports/Account Ledger',
        finePrintPdfResult(result),
      );
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  };
  const xlsx = (kind: FinePrintKind) => async (req: FastifyRequest, reply: FastifyReply) => {
    try {
      const result = await resolve(kind, req);
      const out = await renderXlsx([finePrintSheet(result)], `account-ledger-${kind}`);
      return reply
        .header('content-type', out.contentType)
        .header('content-disposition', `attachment; filename="${out.fileName}"`)
        .send(out.buffer);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  };

  app.get('/reports/account-ledger/jama-udhar', auth as any, data('jama-udhar'));
  app.get('/reports/account-ledger/jama-udhar/export.pdf', auth as any, pdf('jama-udhar'));
  app.get('/reports/account-ledger/jama-udhar/export.xlsx', auth as any, xlsx('jama-udhar'));
  app.get('/reports/account-ledger/gold-fine', auth as any, data('gold-fine'));
  app.get('/reports/account-ledger/gold-fine/export.pdf', auth as any, pdf('gold-fine'));
  app.get('/reports/account-ledger/gold-fine/export.xlsx', auth as any, xlsx('gold-fine'));
  app.get('/reports/account-ledger/silver-fine', auth as any, data('silver-fine'));
  app.get('/reports/account-ledger/silver-fine/export.pdf', auth as any, pdf('silver-fine'));
  app.get('/reports/account-ledger/silver-fine/export.xlsx', auth as any, xlsx('silver-fine'));
}
