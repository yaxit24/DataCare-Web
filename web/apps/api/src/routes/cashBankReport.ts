import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  CashBankValidationError,
  cashBankAccountHelp,
  cashBankReport,
  parseCashBankQuery,
  type CashBankResult,
} from '../modules/reports/cashBankReport.js';
import { documentCompanyTx } from '../modules/documents/voucherDocument.js';
import { cashBankPrintHtml } from '../modules/reports/cashBankPrint.js';
import { withTxBudget } from '../modules/shared/txBudget.js';
import { toCsv } from '../modules/reports/reportCsv.js';
import { renderXlsx, type XlsxColumn, type XlsxSheet } from '../modules/reports/xlsx.js';

/**
 * Cash Bank report routes (desktop RP_CASH_BANK). One resolver feeds the screen and both exports, so they cannot
 * disagree. Scope comes from the session via readScope; the query only narrows. The print html and the PDF are a
 * later packet (WP-17.print).
 */
export interface CashBankRouteHelpers {
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

const NO_PRINT = 'You Have No Print Rights.....';

const money = (header: string, key: string): XlsxColumn => ({
  header,
  key,
  type: 'number',
  format: '0.00',
  width: 14,
});
const text = (header: string, key: string, width: number): XlsxColumn => ({
  header,
  key,
  type: 'text',
  width,
});

/** The ten grid columns, in the desktop order and with its captions (hidden codes are not exported). */
const COLUMNS: XlsxColumn[] = [
  text('Sr', 'sr', 6),
  text('Book', 'book', 16),
  text('VchNo', 'vchNo', 10),
  text('Date', 'date', 12),
  text('Party Name', 'party', 28),
  text('Area', 'area', 18),
  money('Dr Amt', 'drAmt'),
  money('Cr Amt', 'crAmt'),
  money('Bal Amt', 'balAmt'),
  text('CrDr', 'side', 8),
];

/** dd/MM/yyyy text from an ISO date (RP_CASH_BANK.cs:3256 {{"dd/MM/yyyy"}}). */
const ddmmyyyy = (iso: string): string =>
  iso ? `${iso.slice(8, 10)}/${iso.slice(5, 7)}/${iso.slice(0, 4)}` : '';

/** Opening + detail rows and the totals row (label `Total :` in Party Name). */
function exportRows(r: CashBankResult): Record<string, unknown>[] {
  const out: Record<string, unknown>[] = r.rows.map((x) => ({
    sr: String(x.sr),
    book: x.book,
    vchNo: x.vchNo,
    date: ddmmyyyy(x.vchDate),
    party: x.party,
    area: x.area,
    drAmt: x.drAmt,
    crAmt: x.crAmt,
    balAmt: x.balAmt,
    side: x.side,
  }));
  if (r.totals) {
    // RP_CASH_BANK.cs:3321 {{Rows[num9].Cells[4].Value = "Total :";}}
    out.push({
      sr: '',
      book: '',
      vchNo: '',
      date: '',
      party: 'Total :',
      area: '',
      drAmt: r.totals.drAmt,
      crAmt: r.totals.crAmt,
      balAmt: r.totals.balAmt,
      side: r.totals.side,
    });
  }
  return out;
}

export function registerCashBankReportRoutes(app: FastifyInstance, h: CashBankRouteHelpers): void {
  const { prisma, auth, guard, readScope } = h;

  const fail = (reply: FastifyReply, error: unknown): boolean => {
    if (error instanceof CashBankValidationError) {
      void reply.code(400).send({ error: error.code, message: error.message });
      return true;
    }
    return false;
  };

  const resolve = async (req: FastifyRequest): Promise<CashBankResult> => {
    const q = parseCashBankQuery((req.query ?? {}) as Record<string, unknown>);
    return cashBankReport(prisma, readScope(req), q);
  };

  // The refusal carries the desktop Excel text (RP_CASH_BANK.cs:2540). guard's own body is replaced: the handler
  // checks the print right itself first so the message is the desktop's, then calls guard for its standard checks.
  const printAllowed = (req: FastifyRequest, reply: FastifyReply): boolean => {
    // guard answers a refusal on the reply it is given; a silent stand-in lets the handler answer with the desktop text.
    const probe = { code: () => ({ send: () => undefined }) };
    if (guard(req, probe as unknown as FastifyReply, 'print')) return true;
    void reply.code(403).send({ error: 'forbidden', message: NO_PRINT });
    return false;
  };

  app.get('/reports/cash-bank', auth as any, async (req, reply) => {
    try {
      return reply.send(await resolve(req));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/cash-bank/accounts', auth as any, async (req, reply) => {
    try {
      const q = String(((req.query ?? {}) as Record<string, unknown>).q ?? '');
      return reply.send({ accounts: await cashBankAccountHelp(prisma, readScope(req), q) });
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  // Print html in the AcLedger layout, from the same resolver result as the screen (WP-17.print).
  app.get('/reports/cash-bank/print', auth as any, async (req, reply) => {
    if (!printAllowed(req, reply)) return reply;
    try {
      const result = await resolve(req);
      const s = readScope(req);
      const co = await withTxBudget(prisma, s.tenantId, 'read', (tx: any) =>
        documentCompanyTx(tx, { tenantId: s.tenantId, coCode: s.coCode } as any),
      );
      const html = cashBankPrintHtml(result, {
        company: String(co?.CO_NAME ?? '').trim(),
        coYear: s.coYear ?? '',
      });
      return reply.header('content-type', 'text/html; charset=utf-8').send(html);
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  // PARTIAL: sendReportPdf builds its own generic html from `result` and cannot take the AcLedger html, so this
  // PDF is the generic report PDF of the same resolver result (same figures), not the AcLedger layout.
  app.get('/reports/cash-bank/export.pdf', auth as any, async (req, reply) => {
    if (!printAllowed(req, reply)) return reply;
    try {
      return await h.sendReportPdf(
        req,
        reply,
        'cash-bank',
        'Reports/Cash Bank',
        await resolve(req),
      );
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/cash-bank/export.csv', auth as any, async (req, reply) => {
    if (!printAllowed(req, reply)) return reply;
    try {
      const result = await resolve(req);
      return reply
        .header('content-type', 'text/csv; charset=utf-8')
        .header('content-disposition', 'attachment; filename="cash-bank.csv"')
        .send(toCsv(exportRows(result), { columns: COLUMNS.map((c) => c.key) }));
    } catch (error) {
      if (fail(reply, error)) return reply;
      throw error;
    }
  });

  app.get('/reports/cash-bank/export.xlsx', auth as any, async (req, reply) => {
    if (!printAllowed(req, reply)) return reply;
    try {
      const result = await resolve(req);
      const sheet: XlsxSheet = { name: 'Cash Bank', columns: COLUMNS, rows: exportRows(result) };
      const out = await renderXlsx([sheet], 'cash-bank');
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
