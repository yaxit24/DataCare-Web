import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import {
  dailyRateDates,
  dailyRateExists,
  dailyRateReportHtml,
  DailyRateNotFoundError,
  deleteDailyRate,
  getDailyRate,
  saveDailyRate,
} from '../modules/masters/dailyRate.js';
import { sendVoucherDocument } from '../modules/documents/voucherPrint.js';

/** Daily Rate (desktop MS_RATE) routes, extracted from `txn.ts` so its size ceiling keeps falling. */
export interface DailyRateRouteHelpers {
  prisma: any;
  auth: any;
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  readScope: (req: FastifyRequest) => {
    tenantId: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
  };
  run: (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => Promise<unknown>;
  body: (req: FastifyRequest) => Record<string, any>;
  mainUserOf: (req: FastifyRequest) => string;
  formMutationCapabilities: (
    req: FastifyRequest,
    form: string,
  ) => Promise<{ canUpdate: boolean; canDelete: boolean }>;
}

const FORM = 'Cash / Bank/Daily Rate';
const RATE = { type: 'number', minimum: 0 } as const;
const ROW_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['grCode', 'rate'],
  properties: {
    grCode: { type: 'string', minLength: 1, maxLength: 3 },
    touch: RATE,
    taxPct: RATE,
    rate: RATE,
    taxRate: RATE,
    prRate: RATE,
  },
} as const;
const BODY_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['date', 'rows'],
  properties: {
    date: { type: 'string', pattern: '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' },
    goldRate: RATE,
    silverRate: RATE,
    prGoldRate: RATE,
    prSilverRate: RATE,
    goldOzRate: RATE,
    silverOzRate: RATE,
    empCode: { type: 'string', maxLength: 3 },
    rows: { type: 'array', maxItems: 500, items: ROW_SCHEMA },
  },
} as const;
const BODY_KEYS = new Set(Object.keys(BODY_SCHEMA.properties));
const ROW_KEYS = new Set(Object.keys(ROW_SCHEMA.properties));

/** Fastify strips unknown keys by default; a Daily Rate request names every field it sends or is refused. */
async function rejectUnknownFields(req: FastifyRequest, reply: FastifyReply): Promise<void> {
  const raw = req.body as Record<string, unknown> | undefined;
  if (!raw || typeof raw !== 'object' || Array.isArray(raw)) return;
  const unknown = Object.keys(raw).filter((key) => !BODY_KEYS.has(key));
  if (Array.isArray(raw.rows))
    raw.rows.forEach((row, index) => {
      if (row && typeof row === 'object' && !Array.isArray(row))
        for (const key of Object.keys(row))
          if (!ROW_KEYS.has(key)) unknown.push(`rows[${index}].${key}`);
    });
  if (unknown.length)
    await reply.code(400).send({
      error: 'invalid-input',
      message: `Daily Rate request contains unsupported field(s): ${unknown.join(', ')}`,
    });
}

export function registerDailyRateRoutes(app: FastifyInstance, h: DailyRateRouteHelpers): void {
  const { prisma, auth, guard, readScope, run, body, mainUserOf, formMutationCapabilities } = h;
  const dateOf = (req: FastifyRequest) => String((req.query as any)?.date ?? '');
  const notFound = (reply: FastifyReply, error: unknown) => {
    if (error instanceof DailyRateNotFoundError)
      return reply.code(404).send({ error: error.code, message: error.message });
    throw error;
  };

  app.get('/daily-rate', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getDailyRate(prisma, readScope(req), dateOf(req)));
  });
  app.get('/daily-rate/dates', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => dailyRateDates(prisma, readScope(req)));
  });
  app.post(
    '/daily-rate',
    { ...(auth as object), schema: { body: BODY_SCHEMA }, preValidation: rejectUnknownFields },
    async (req, reply) => {
      if (!guard(req, reply, 'create')) return;
      const b = body(req);
      const scope = readScope(req);
      return run(reply, 201, async () => {
        // MS_RATE.cs:1882-1886: changing a saved day needs edit rights; a new day does not.
        if (
          (await dailyRateExists(prisma, scope, b.date)) &&
          !(await formMutationCapabilities(req, FORM)).canUpdate
        ) {
          await reply
            .code(403)
            .send({ error: 'forbidden', action: 'update', message: 'You Have No Rights.....' });
          return reply;
        }
        return saveDailyRate(prisma, {
          scope,
          date: b.date,
          goldRate: b.goldRate,
          silverRate: b.silverRate,
          prGoldRate: b.prGoldRate,
          prSilverRate: b.prSilverRate,
          goldOzRate: b.goldOzRate,
          silverOzRate: b.silverOzRate,
          empCode: b.empCode,
          mainUser: mainUserOf(req),
          rows: b.rows,
        });
      });
    },
  );
  app.delete('/daily-rate', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    try {
      return reply.code(200).send(await deleteDailyRate(prisma, readScope(req), dateOf(req)));
    } catch (error) {
      if (error instanceof Error && error.name === 'DailyRateValidationError')
        return reply.code(400).send({ error: error.name, message: error.message });
      return notFound(reply, error);
    }
  });
  // RateRpt (MS_RATE.cs:1834-1866): print rights are required.
  app.get('/daily-rate/print', auth, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    try {
      const html = await dailyRateReportHtml(prisma, readScope(req), dateOf(req));
      return sendVoucherDocument(reply, html, {
        format: (req.query as any)?.format,
        filename: `daily-rate-${dateOf(req)}`,
      });
    } catch (error) {
      if (error instanceof Error && error.name === 'DailyRateValidationError')
        return reply.code(400).send({ error: error.name, message: error.message });
      return notFound(reply, error);
    }
  });
}
