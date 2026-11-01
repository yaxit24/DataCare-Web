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

const NUMBER = { type: 'number' } as const;
const TEXT = { type: 'string' } as const;
const STONE_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  properties: {
    isrNo: NUMBER,
    itCode: TEXT,
    dmCode: TEXT,
    dmName: TEXT,
    dmSize: TEXT,
    dmSfNo: TEXT,
    dmLeb: TEXT,
    dmColor: TEXT,
    dmOrigin: TEXT,
    dmRemark: TEXT,
    pcs: NUMBER,
    grossWt: NUMBER,
    pcsWt: NUMBER,
    karigarWt: NUMBER,
    conPct: NUMBER,
    karigarLessPct: NUMBER,
    karigarConPct: NUMBER,
    karigarConWt: NUMBER,
    rateType: TEXT,
    rate: NUMBER,
    amount: NUMBER,
    lbrRate: NUMBER,
    lbrAmount: NUMBER,
    netAmount: NUMBER,
    conWt: NUMBER,
    karigarRate: NUMBER,
    karigarAmount: NUMBER,
    karigarLabourRate: NUMBER,
    karigarLabourAmount: NUMBER,
    karigarNetAmount: NUMBER,
    itType: TEXT,
  },
} as const;

const LINE_SCHEMA = {
  type: 'object',
  additionalProperties: false,
  required: ['itCode'],
  properties: {
    oldSrNo: NUMBER,
    origSrNo: NUMBER,
    vchSrno: NUMBER,
    itCode: { type: 'string', minLength: 1, maxLength: 5 },
    tagNo: { type: 'string', maxLength: 15 },
    pcs: NUMBER,
    grossWt: NUMBER,
    netWt: NUMBER,
    touch: NUMBER,
    fineWt: NUMBER,
    lotNo: TEXT,
    itmColor: TEXT,
    tagCost: NUMBER,
    hallmarkId2: TEXT,
    hallmarkId3: TEXT,
    hallmarkId4: TEXT,
    hallmarkIdWt: NUMBER,
    hallmarkId2Wt: NUMBER,
    hallmarkId3Wt: NUMBER,
    hallmarkId4Wt: NUMBER,
    adjustGrossWt: NUMBER,
    adjustNetWt: NUMBER,
    lessTouch: NUMBER,
    lossWt: NUMBER,
    remark: TEXT,
    isuAcName: TEXT,
    metalColor: TEXT,
    isuAcCode: TEXT,
    tblCode: TEXT,
    designNo: TEXT,
    itmSize: TEXT,
    huid: TEXT,
    bagWt: NUMBER,
    lessWt: NUMBER,
    ghtWt: NUMBER,
    westPct: NUMBER,
    labourPct: NUMBER,
    labourType: TEXT,
    labourRate: NUMBER,
    labourAmount: NUMBER,
    otherAmount: NUMBER,
    rate: NUMBER,
    amount: NUMBER,
    mrp: NUMBER,
    karigarNetWt: NUMBER,
    karigarTouch: NUMBER,
    karigarWestPct: NUMBER,
    karigarFine: NUMBER,
    karigarName: TEXT,
    rateType: TEXT,
    prCode: TEXT,
    isuYrcd: TEXT,
    isuDbcd: TEXT,
    isuLcCode: TEXT,
    isuSrNo: NUMBER,
    designImageId: TEXT,
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
    origVchNo: { anyOf: [{ type: 'string', pattern: '^[0-9]{1,8}$' }, { type: 'number' }] },
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
