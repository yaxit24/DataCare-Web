import type { FastifyReply } from 'fastify';
import { renderToPdf, PlaywrightPdfRenderer } from '../reports/render.js';
import {
  DocumentScopeError,
  requireVoucherDocumentScope,
  type VoucherDocumentScope,
} from './voucherDocument.js';

/**
 * Resolve a voucher-document scope from the request scope + vchNo, failing closed to a 400 (sent to the
 * reply) on a DocumentScopeError. Returns the scope, or null when a 400 was already sent — the caller
 * returns `reply` on null. Shared by every print endpoint (G125).
 */
export function resolvePrintScope(
  reply: FastifyReply,
  base: {
    tenantId: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
    coBook?: string;
  },
  vchNo: unknown,
): VoucherDocumentScope | null {
  try {
    return requireVoucherDocumentScope({
      tenantId: base.tenantId,
      coCode: base.coCode,
      lcCode: base.lcCode,
      coYear: base.coYear,
      coBook: base.coBook,
      vchNo: String(vchNo ?? ''),
    });
  } catch (e: any) {
    if (e instanceof DocumentScopeError) {
      void reply.code(400).send({ error: e.name, field: e.field, message: e.message });
      return null;
    }
    throw e;
  }
}

/**
 * Shared voucher-document print responder (G125). Encapsulates the repeated per-endpoint scaffold:
 * when `format=html` return the HTML, otherwise render it to a PDF and stream it inline with a safe
 * filename. The caller resolves the voucher-document scope, the copy label, and builds the HTML; this
 * keeps the route handlers small and the PDF/HTML behaviour identical across documents.
 */
export async function sendVoucherDocument(
  reply: FastifyReply,
  html: string,
  opts: { format?: unknown; filename: string },
): Promise<FastifyReply> {
  if (opts.format === 'html') return reply.type('text/html').send(html);
  let pdf: Buffer;
  try {
    pdf = await renderToPdf(html, new PlaywrightPdfRenderer());
  } catch {
    return reply.code(503).send({ error: 'pdf-renderer-unavailable' });
  }
  const safe = opts.filename.replace(/[^\w.-]/g, '');
  return reply
    .header('content-type', 'application/pdf')
    .header('content-disposition', `inline; filename="${safe}.pdf"`)
    .send(pdf);
}
