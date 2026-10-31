import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { formatVoucherNo, type VoucherScope } from '../modules/vouchers/numbering.js';
import {
  deleteFineJv,
  editFineJv,
  fineJvPrintBook,
  getFineJv,
  postFineJv,
} from '../modules/finance/fineJv.js';
import { contraVoucherData, fineJvVoucherHtml } from '../modules/finance/contraVoucher.js';
import { resolvePrintScope, sendVoucherDocument } from '../modules/documents/voucherPrint.js';

/**
 * Fine JV (TR_CONTRA with `MAIN_BOOK='FINE JV'`) lifecycle and document routes. Extracted from
 * `txn.ts` so the size-budget ceiling continues to tighten instead of being raised for this menu.
 */
export interface FineJvRouteHelpers {
  prisma: any;
  auth: any;
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  scopeOf: (req: FastifyRequest) => VoucherScope;
  readScope: (req: FastifyRequest) => VoucherScope;
  run: (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => Promise<unknown>;
  body: (req: FastifyRequest) => Record<string, any>;
  mainUserOf: (req: FastifyRequest) => string;
  standardDocumentCopy: (raw: unknown, reply: FastifyReply) => string | null | undefined;
}

/** One TR_CONTRA grid row: Cr/Dr (column 1), account (2), description (4) and its fine (5 or 6). */
const FINE_JV_LINE_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['crdr', 'acCode', 'fine'],
  properties: {
    crdr: { type: 'string', enum: ['DR', 'CR'] },
    acCode: { type: 'string', minLength: 1, maxLength: 8 },
    // CONTRA_DATA.IT_DESC is varchar(150).
    itDesc: { type: 'string', maxLength: 150 },
    fine: { type: 'number', exclusiveMinimum: 0 },
  },
} as const;

const FINE_JV_BODY_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['lines'],
  properties: {
    coBook: { type: 'string', minLength: 1, maxLength: 3 },
    lcCode: { type: 'string', minLength: 1, maxLength: 2 },
    coYear: { type: 'string', pattern: '^[0-9]{4}-[0-9]{4}$' },
    lines: { type: 'array', minItems: 2, maxItems: 200, items: FINE_JV_LINE_SCHEMA },
    metal: { type: 'string', enum: ['G', 'S'] },
    vchDate: { type: 'string', pattern: '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' },
    // CONTRA_DATA.EMP_CODE / EMP_MAST.EMP_CODE are varchar(3); '' clears the employee.
    empCode: { type: 'string', maxLength: 3 },
  },
} as const;

const BODY_KEYS = new Set(Object.keys(FINE_JV_BODY_SCHEMA.properties));
const LINE_KEYS = new Set(Object.keys(FINE_JV_LINE_SCHEMA.properties));

/** Fastify strips unknown keys by default; a Fine JV request names every field it sends or is refused. */
async function rejectUnknownFineJvFields(req: FastifyRequest, reply: FastifyReply): Promise<void> {
  const raw = req.body;
  if (!raw || typeof raw !== 'object' || Array.isArray(raw)) return;
  const record = raw as Record<string, unknown>;
  const unknown = Object.keys(record).filter((key) => !BODY_KEYS.has(key));
  if (Array.isArray(record.lines))
    record.lines.forEach((line, index) => {
      if (line && typeof line === 'object' && !Array.isArray(line))
        for (const key of Object.keys(line))
          if (!LINE_KEYS.has(key)) unknown.push(`lines[${index}].${key}`);
    });
  if (unknown.length)
    await reply.code(400).send({
      error: 'invalid-input',
      message: `Fine JV request contains unsupported field(s): ${unknown.join(', ')}`,
    });
}

const fineJvBodyRoute = (auth: unknown) => ({
  ...(auth as object),
  schema: { body: FINE_JV_BODY_SCHEMA },
  preValidation: rejectUnknownFineJvFields,
});

export function registerFineJvRoutes(app: FastifyInstance, h: FineJvRouteHelpers): void {
  const { prisma, auth, guard, scopeOf, readScope, run, body, mainUserOf, standardDocumentCopy } =
    h;
  const input = (req: FastifyRequest) => {
    const b = body(req);
    return {
      scope: scopeOf(req),
      lines: b.lines,
      metal: b.metal,
      vchDate: b.vchDate,
      empCode: b.empCode,
    };
  };

  app.post('/fine-jv', fineJvBodyRoute(auth), async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => postFineJv(prisma, { ...input(req), mainUser: mainUserOf(req) }));
  });
  app.get('/fine-jv/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getFineJv(prisma, scopeOf(req), (req.params as any).vchNo));
  });
  // FineJvBill.RPT (TR_CONTRA.cs:3000-3004 print rights; :3021/:3061-3069 report choice). The report
  // prints every CONTRA_DATA row of the voucher, so a voucher that cannot be reopened as a grid still prints.
  app.get('/fine-jv/:vchNo/print', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const q = req.query as any;
    const copyLabel = standardDocumentCopy(q.copy, reply);
    if (copyLabel === null) return reply;
    const rawNo = (req.params as any).vchNo;
    let voucherNo: string;
    try {
      voucherNo = formatVoucherNo(rawNo);
    } catch (error) {
      return reply
        .code(400)
        .send({ error: 'invalid-voucher-number', message: (error as Error).message });
    }
    const scope = resolvePrintScope(reply, readScope(req), voucherNo);
    if (!scope) return reply;
    let bookName: string;
    try {
      bookName = (await fineJvPrintBook(prisma, scope)).name;
    } catch (error) {
      if (error instanceof Error && /ValidationError$/.test(error.name))
        return reply.code(400).send({ error: error.name, message: error.message });
      throw error;
    }
    const data = await contraVoucherData(prisma, scope);
    if (!data)
      return reply
        .code(404)
        .send({ error: 'fine-jv-not-found', message: `fine-jv voucher not found: ${voucherNo}` });
    return sendVoucherDocument(
      reply,
      fineJvVoucherHtml(data.rows, { company: data.company, copy: copyLabel, bookName }),
      { format: q.format, filename: `fine-jv-${scope.vchNo}` },
    );
  });
  app.put('/fine-jv/:vchNo', fineJvBodyRoute(auth), async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editFineJv(prisma, input(req), (req.params as any).vchNo));
  });
  app.delete('/fine-jv/:vchNo', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteFineJv(prisma, {
        scope: scopeOf(req),
        vchNo: (req.params as any).vchNo,
        book: body(req).book,
        deleteUser: mainUserOf(req),
      }),
    );
  });
}
