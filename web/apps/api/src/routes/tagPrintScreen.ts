import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  tagPrintBook,
  tagPrintBooks,
  tagPrintHmUpdate,
  tagPrintLabels,
  tagPrintLookups,
  tagPrintSetDefault,
  tagPrintSetup,
  tagPrintStage,
  tagPrintStock,
  tagPrintTag,
  tagPrintTags,
  tagPrintVoucher,
  tagPrintVouchers,
} from '../modules/stock/tagPrintScreen.js';

/** The rights row of the screen (routePolicy 'Inventory/Tag Print', desktop SUB_MENU 'Tag Print'). */
const FORM = 'Inventory/Tag Print';

/**
 * Tag Print (UT_TAG_PRINT). The reads need the view right, Print and the label sheet the print right (BtnPrint_Click
 * :5124-5128), Hm Id Update and the default label file the edit right.
 */
export function registerTagPrintScreenRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'run' | 'body'> & {
    guard: (
      req: FastifyRequest,
      reply: FastifyReply,
      action: 'view' | 'create' | 'update' | 'delete' | 'print',
    ) => boolean;
  },
  capabilities: (
    req: FastifyRequest,
    form: string,
  ) => Promise<{ canUpdate: boolean; canDelete: boolean; canPrint: boolean }>,
): void {
  const { prisma, auth, guard, scopeOf, run, body } = h;
  const scope = (req: FastifyRequest) => {
    const s = scopeOf(req) as any;
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode, coYear: s.coYear ?? '' };
  };
  const q = (req: FastifyRequest, key: string) => String((req.query as any)?.[key] ?? '');

  app.get('/stock/tag-print-screen', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      ...(await tagPrintSetup(prisma, scope(req))),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/stock/tag-print-screen/books', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({ rows: await tagPrintBooks(prisma, scope(req)) }));
  });
  app.get('/stock/tag-print-screen/book', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      book: await tagPrintBook(prisma, scope(req), q(req, 'code')),
    }));
  });
  app.get('/stock/tag-print-screen/vouchers', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      rows: await tagPrintVouchers(prisma, scope(req), q(req, 'bookCode')),
    }));
  });
  app.get('/stock/tag-print-screen/voucher', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      rows: await tagPrintVoucher(prisma, scope(req), q(req, 'bookCode'), q(req, 'vchNo')),
    }));
  });
  app.get('/stock/tag-print-screen/stock', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      rows: await tagPrintStock(prisma, scope(req), {
        group: q(req, 'group'),
        product: q(req, 'product'),
        itemType: q(req, 'itemType'),
      }),
    }));
  });
  app.get('/stock/tag-print-screen/tag', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({
      row: await tagPrintTag(prisma, scope(req), q(req, 'tagNo')),
    }));
  });
  app.get('/stock/tag-print-screen/tags', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => ({ rows: await tagPrintTags(prisma, scope(req)) }));
  });
  app.get('/stock/tag-print-screen/lookups/:kind', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const kind = String((req.params as any).kind ?? '');
    if (kind !== 'groups' && kind !== 'products')
      return reply.code(400).send({ error: 'invalid-data', message: `unknown lookup ${kind}` });
    return run(reply, 200, async () => ({ rows: await tagPrintLookups(prisma, scope(req), kind) }));
  });
  app.post('/stock/tag-print-screen/hm-update', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const rows = Array.isArray(body(req).rows) ? body(req).rows : [];
    return run(reply, 200, () => tagPrintHmUpdate(prisma, scope(req), rows));
  });
  app.post('/stock/tag-print-screen/default-file', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () =>
      tagPrintSetDefault(prisma, scope(req), String(body(req).file ?? '')),
    );
  });
  app.post('/stock/tag-print-screen/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const b = body(req);
    return run(reply, 200, () =>
      tagPrintStage(prisma, scope(req), {
        book: String(b.bookCode ?? ''),
        labelSkip: b.labelSkip,
        tags: Array.isArray(b.tags) ? b.tags : [],
      }),
    );
  });
  app.get('/stock/tag-print-screen/labels', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const html = await tagPrintLabels(prisma, scope(req));
    return reply.code(200).type('text/html; charset=utf-8').send(html);
  });
}
