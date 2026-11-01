import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { approvalBillHtml, ApprovalBillNotFoundError } from '../modules/tour/approvalBill.js';
import {
  ApprovalNotFoundError,
  approvalPrintBook,
  deleteTour,
  deleteTourReturn,
  editTour,
  editTourReturn,
  getApproval,
  tourIssue,
  tourLines,
  tourReturn,
} from '../modules/tour/tour.js';
import { formatVoucherNo, type VoucherScope } from '../modules/vouchers/numbering.js';
import { resolvePrintScope, sendVoucherDocument } from '../modules/documents/voucherPrint.js';

/** Approval Isu/Approval Rtn (TR_APR_ISU) routes, kept out of the size-capped txn.ts. */
export interface ApprovalRouteHelpers {
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

const SERIAL = { type: 'number', minimum: 0, maximum: Number.MAX_SAFE_INTEGER } as const;
const STABLE_SERIAL = {
  type: 'integer',
  minimum: 1,
  maximum: Number.MAX_SAFE_INTEGER,
} as const;
const PCS = { type: 'number', minimum: 0, maximum: 999_999_999.999 } as const;
const WEIGHT = { type: 'number', minimum: 0, maximum: 99_999_999_999.999 } as const;
const PERCENT = { type: 'number', minimum: 0, maximum: 99_999.9999 } as const;
const MONEY = { type: 'number', minimum: 0, maximum: Number.MAX_SAFE_INTEGER } as const;
const text = (maxLength: number) => ({ type: 'string', maxLength }) as const;
const STONE_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['itCode'],
  properties: {
    isrNo: STABLE_SERIAL,
    itCode: { type: 'string', minLength: 1, maxLength: 5 },
    dmCode: text(8),
    dmName: text(50),
    dmSize: text(20),
    dmSfNo: text(20),
    dmLeb: text(15),
    dmColor: text(15),
    dmOrigin: text(20),
    dmRemark: text(20),
    pcs: PCS,
    grossWt: WEIGHT,
    pcsWt: WEIGHT,
    karigarWt: WEIGHT,
    conPct: PERCENT,
    karigarLessPct: PERCENT,
    karigarConPct: PERCENT,
    karigarConWt: WEIGHT,
    rateType: text(1),
    rate: MONEY,
    amount: MONEY,
    lbrRate: MONEY,
    lbrAmount: MONEY,
    netAmount: MONEY,
    conWt: WEIGHT,
    karigarRate: MONEY,
    karigarAmount: MONEY,
    karigarLabourRate: MONEY,
    karigarLabourAmount: MONEY,
    karigarNetAmount: MONEY,
    itType: text(1),
  },
} as const;

const LINE_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['itCode'],
  properties: {
    oldSrNo: STABLE_SERIAL,
    origSrNo: STABLE_SERIAL,
    vchSrno: SERIAL,
    itCode: { type: 'string', minLength: 1, maxLength: 5 },
    tagNo: text(15),
    pcs: PCS,
    grossWt: WEIGHT,
    netWt: WEIGHT,
    touch: PERCENT,
    fineWt: WEIGHT,
    lotNo: text(15),
    itmColor: text(15),
    tagCost: MONEY,
    hallmarkId2: text(10),
    hallmarkId3: text(10),
    hallmarkId4: text(10),
    hallmarkIdWt: WEIGHT,
    hallmarkId2Wt: WEIGHT,
    hallmarkId3Wt: WEIGHT,
    hallmarkId4Wt: WEIGHT,
    adjustGrossWt: WEIGHT,
    adjustNetWt: WEIGHT,
    lessTouch: PERCENT,
    lossWt: WEIGHT,
    remark: text(255),
    isuAcName: text(50),
    metalColor: text(15),
    isuAcCode: text(8),
    tblCode: text(3),
    designNo: text(20),
    itmSize: text(20),
    huid: text(10),
    bagWt: WEIGHT,
    lessWt: WEIGHT,
    ghtWt: WEIGHT,
    westPct: PERCENT,
    labourPct: PERCENT,
    labourType: text(1),
    labourRate: MONEY,
    labourAmount: MONEY,
    otherAmount: MONEY,
    rate: MONEY,
    amount: MONEY,
    mrp: MONEY,
    discountPct: PERCENT,
    discountAmount: MONEY,
    netAmount: MONEY,
    itType: text(1),
    karigarNetWt: WEIGHT,
    karigarTouch: PERCENT,
    karigarWestPct: PERCENT,
    karigarFine: WEIGHT,
    karigarName: text(5),
    rateType: text(1),
    prCode: text(2),
    isuYrcd: text(10),
    isuDbcd: text(3),
    isuLcCode: text(2),
    isuSrNo: SERIAL,
    designImageId: text(50),
    stones: { type: 'array', maxItems: 200, items: STONE_SCHEMA },
  },
} as const;

const COMMON_PROPERTIES = {
  coBook: { type: 'string', minLength: 1, maxLength: 3 },
  lcCode: { type: 'string', minLength: 1, maxLength: 2 },
  coYear: { type: 'string', pattern: '^[0-9]{4}-[0-9]{4}$' },
  vchDate: { type: 'string', pattern: '^[0-9]{4}-[0-9]{2}-[0-9]{2}$' },
  partyAc: { type: 'string', maxLength: 8 },
  empCode: { type: 'string', maxLength: 3 },
  vchDesc: { type: 'string', maxLength: 255 },
  expectedVersion: { type: 'string', pattern: '^[0-9a-f]{64}$' },
  lines: { type: 'array', minItems: 1, maxItems: 200, items: LINE_SCHEMA },
} as const;
const ISSUE_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['coBook', 'lines'],
  properties: COMMON_PROPERTIES,
} as const;
const RETURN_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['coBook', 'origBook', 'origYear', 'origVchNo', 'lines'],
  properties: {
    ...COMMON_PROPERTIES,
    origBook: { type: 'string', minLength: 1, maxLength: 3 },
    origYear: { type: 'string', pattern: '^[0-9]{4}-[0-9]{4}$' },
    origVchNo: {
      anyOf: [
        { type: 'string', pattern: '^[0-9]{1,8}$' },
        { type: 'number', minimum: 1, maximum: 99_999_999 },
      ],
    },
  },
} as const;
const PARAMS = {
  type: 'object',
  additionalProperties: false,
  required: ['vchNo'],
  properties: { vchNo: { type: 'string', pattern: '^[0-9]{1,8}$' } },
} as const;
const BOOK_QUERY = {
  type: 'object',
  additionalProperties: false,
  required: ['coBook'],
  properties: { coBook: { type: 'string', minLength: 1, maxLength: 3 } },
} as const;
const DELETE_QUERY = {
  type: 'object',
  additionalProperties: false,
  required: ['coBook', 'expectedVersion'],
  properties: {
    ...BOOK_QUERY.properties,
    expectedVersion: { type: 'string', pattern: '^[0-9a-f]{64}$' },
  },
} as const;
const PRINT_QUERY = {
  type: 'object',
  additionalProperties: false,
  required: ['coBook'],
  properties: {
    ...BOOK_QUERY.properties,
    format: { type: 'string', enum: ['html', 'pdf'] },
    copy: { type: 'string', enum: ['O', 'D', 'T'] },
  },
} as const;

const bodyKeys = (schema: typeof ISSUE_SCHEMA | typeof RETURN_SCHEMA) =>
  new Set(Object.keys(schema.properties));
const lineKeys = new Set(Object.keys(LINE_SCHEMA.properties));
const stoneKeys = new Set(Object.keys(STONE_SCHEMA.properties));

function unknownFields(raw: unknown, schema: typeof ISSUE_SCHEMA | typeof RETURN_SCHEMA): string[] {
  if (!raw || typeof raw !== 'object' || Array.isArray(raw)) return [];
  const body = raw as Record<string, unknown>;
  const unknown = Object.keys(body).filter((key) => !bodyKeys(schema).has(key));
  if (!Array.isArray(body.lines)) return unknown;
  body.lines.forEach((line, lineIndex) => {
    if (!line || typeof line !== 'object' || Array.isArray(line)) return;
    const record = line as Record<string, unknown>;
    for (const key of Object.keys(record))
      if (!lineKeys.has(key)) unknown.push(`lines[${lineIndex}].${key}`);
    if (Array.isArray(record.stones))
      record.stones.forEach((stone, stoneIndex) => {
        if (!stone || typeof stone !== 'object' || Array.isArray(stone)) return;
        for (const key of Object.keys(stone))
          if (!stoneKeys.has(key)) unknown.push(`lines[${lineIndex}].stones[${stoneIndex}].${key}`);
      });
  });
  return unknown;
}

const bodyRoute = (auth: unknown, schema: typeof ISSUE_SCHEMA | typeof RETURN_SCHEMA) => ({
  ...(auth as object),
  schema: { body: schema },
  preValidation: async (req: FastifyRequest, reply: FastifyReply) => {
    const unknown = unknownFields(req.body, schema);
    if (unknown.length)
      await reply.code(400).send({
        error: 'invalid-input',
        message: `Approval request contains unsupported field(s): ${unknown.join(', ')}`,
      });
  },
});
const paramRoute = (auth: unknown, query: object) => ({
  ...(auth as object),
  schema: { params: PARAMS, querystring: query },
});

export function registerApprovalRoutes(app: FastifyInstance, h: ApprovalRouteHelpers): void {
  const { prisma, auth, guard, scopeOf, readScope, run, body, mainUserOf, standardDocumentCopy } =
    h;
  const issueInput = (req: FastifyRequest) => {
    const b = body(req);
    return {
      scope: scopeOf(req),
      vchDate: b.vchDate,
      partyAc: b.partyAc,
      empCode: b.empCode,
      vchDesc: b.vchDesc,
      expectedVersion: b.expectedVersion,
      lines: b.lines,
    };
  };
  const returnInput = (req: FastifyRequest) => {
    const b = body(req);
    return {
      ...issueInput(req),
      origBook: b.origBook,
      origYear: b.origYear,
      origVchNo: b.origVchNo,
    };
  };
  const no = (req: FastifyRequest) => (req.params as { vchNo: string }).vchNo;

  app.post('/tour/issue', bodyRoute(auth, ISSUE_SCHEMA), async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () =>
      tourIssue(prisma, { ...issueInput(req), mainUser: mainUserOf(req) }),
    );
  });
  app.get('/tour/:vchNo', paramRoute(auth, BOOK_QUERY), async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getApproval(prisma, scopeOf(req), 'issue', no(req)));
  });
  app.put('/tour/:vchNo', bodyRoute(auth, ISSUE_SCHEMA), async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editTour(prisma, issueInput(req), no(req)));
  });
  app.delete('/tour/:vchNo', paramRoute(auth, DELETE_QUERY), async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTour(prisma, {
        scope: scopeOf(req),
        vchNo: no(req),
        expectedVersion: (req.query as any).expectedVersion,
        deleteUser: mainUserOf(req),
      }),
    );
  });
  app.get('/tour/:vchNo/lines', paramRoute(auth, BOOK_QUERY), async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => tourLines(prisma, scopeOf(req), no(req)));
  });

  app.post('/tour/return', bodyRoute(auth, RETURN_SCHEMA), async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () =>
      tourReturn(prisma, { ...returnInput(req), mainUser: mainUserOf(req) }),
    );
  });
  app.get('/tour/return/:vchNo', paramRoute(auth, BOOK_QUERY), async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getApproval(prisma, scopeOf(req), 'return', no(req)));
  });
  app.put('/tour/return/:vchNo', bodyRoute(auth, RETURN_SCHEMA), async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editTourReturn(prisma, returnInput(req), no(req)));
  });
  app.delete('/tour/return/:vchNo', paramRoute(auth, DELETE_QUERY), async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () =>
      deleteTourReturn(prisma, {
        scope: scopeOf(req),
        vchNo: no(req),
        expectedVersion: (req.query as any).expectedVersion,
        deleteUser: mainUserOf(req),
      }),
    );
  });

  const print = (kind: 'issue' | 'return') => async (req: FastifyRequest, reply: FastifyReply) => {
    if (!guard(req, reply, 'print')) return;
    const query = req.query as any;
    const copy = standardDocumentCopy(query.copy, reply);
    if (copy === null) return reply;
    let voucherNo: string;
    try {
      voucherNo = formatVoucherNo(no(req));
    } catch (error) {
      return reply
        .code(400)
        .send({ error: 'invalid-voucher-number', message: (error as Error).message });
    }
    const scope = resolvePrintScope(reply, readScope(req), voucherNo);
    if (!scope) return reply;
    try {
      await approvalPrintBook(prisma, scope, kind);
      const html = await approvalBillHtml(prisma, scope, voucherNo, copy ?? undefined);
      return sendVoucherDocument(reply, html, {
        format: query.format,
        filename: `approval-${kind}-${voucherNo}`,
      });
    } catch (error) {
      if (error instanceof ApprovalNotFoundError || error instanceof ApprovalBillNotFoundError)
        return reply.code(404).send({ error: 'approval-not-found', message: error.message });
      if (error instanceof Error && /ValidationError$/.test(error.name))
        return reply.code(400).send({ error: error.name, message: error.message });
      throw error;
    }
  };
  app.get('/tour/:vchNo/print', paramRoute(auth, PRINT_QUERY), print('issue'));
  app.get('/tour/return/:vchNo/print', paramRoute(auth, PRINT_QUERY), print('return'));
}
