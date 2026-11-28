import type { FastifyInstance, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import { dhrnInterestInputFromBody, receiveDhrnInterest, getDhrnInterest, editDhrnInterest, deleteDhrnInterest } from '../modules/dhrn/dhrnInterest.js';
import { loanInterestContextTx } from '../modules/dhrn/loanInterestContext.js';
import { withTxBudget } from '../modules/shared/txBudget.js';
import { sendVoucherDocument } from '../modules/documents/voucherPrint.js';
import { loanInterestHtml } from '../modules/dhrn/loanInterestPrint.js';

const text = { type: 'string', maxLength: 150 };
const number = { type: 'number', minimum: 0 };
const scopeFields = { coBook: { type: 'string', minLength: 1, maxLength: 3 }, coYear: text, lcCode: text };
const fields = {
  ...scopeFields, isuNo: { anyOf: [{ type: 'string', pattern: '^[0-9]{1,8}$' }, { type: 'integer', minimum: 1 }] },
  isuBook: { type: 'string', minLength: 1, maxLength: 3 }, isuYear: { type: 'string', minLength: 1, maxLength: 10 }, borrowerAc: { type: 'string', minLength: 1, maxLength: 8 },
  borrowerName: text, loanType: { type: 'string', enum: ['A', 'G', 'S'] },
  interest: number, intReceived: number, intKasar: number, principalReceived: number, unchakReceived: number,
  intPrc: number, fromDate: text, toDate: text, intMonth: { type: 'integer', minimum: 0, maximum: 36 }, intDay: number,
  settlementAc: text, intIncAc: text, kasarAc: text, metalAc: text, empCode: text, desc: text, vchDate: text,
  monthInterest: number, rateCutRate: number, rateCutPay: number, loanAmount: number, oldReceived: number,
  outstandingAmount: { type: 'number' }, dhrnDate: text, dhrnMonths: number, billNo: text,
  expectedVersion: { type: 'string', pattern: '^[a-f0-9]{64}$' },
};
const bodySchema = { type: 'object', additionalProperties: false, properties: fields, required: ['coBook', 'isuNo', 'isuBook', 'isuYear', 'borrowerAc'] };
const params = { type: 'object', additionalProperties: false, properties: { vchNo: { type: 'string', pattern: '^[0-9]{1,8}$' } }, required: ['vchNo'] };
const query = { type: 'object', additionalProperties: false, properties: { ...scopeFields, expectedVersion: fields.expectedVersion, format: { type: 'string', enum: ['html', 'pdf'] }, copy: { type: 'string', enum: ['original', 'duplicate', 'triplicate'] } }, required: ['coBook'] };

export function registerLoanModeInterestRoutes(app: FastifyInstance, h: CrmRouteHelpers) {
  const { auth, prisma, scopeOf, body, mainUserOf, guard, run } = h;
  const input = (req: FastifyRequest) => dhrnInterestInputFromBody(scopeOf(req), { ...body(req), mode: 'loan', mainUser: mainUserOf(req) });
  const write = { ...auth, schema: { body: bodySchema } } as any;
  const read = { ...auth, schema: { params, querystring: query } } as any;
  app.post('/loan/interest', write, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return run(reply, 201, () => receiveDhrnInterest(prisma, input(req)));
  });
  app.get('/loan/interest/reference', { ...auth, schema: { querystring: { ...bodySchema, properties: { ...fields, isuNo: { type: 'string', pattern: '^[0-9]{1,8}$' } } } } } as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const scope = scopeOf(req);
    return run(reply, 200, () => withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
      const result = await loanInterestContextTx(tx, dhrnInterestInputFromBody(scope, { ...(req.query as object), mode: 'loan' }));
      const { scope: _scope, ...view } = result;
      return view;
    }));
  });
  app.get('/loan/interest/:vchNo', read, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => getDhrnInterest(prisma, scopeOf(req), (req.params as any).vchNo, 'loan'));
  });
  app.put('/loan/interest/:vchNo', { ...write, schema: { body: bodySchema, params } }, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return run(reply, 200, () => editDhrnInterest(prisma, input(req), (req.params as any).vchNo));
  });
  app.delete('/loan/interest/:vchNo', read, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return run(reply, 200, () => deleteDhrnInterest(prisma, { scope: scopeOf(req), vchNo: (req.params as any).vchNo, mode: 'loan', expectedVersion: (req.query as any).expectedVersion, deleteUser: mainUserOf(req) }));
  });
  app.get('/loan/interest/:vchNo/print', read, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    const q = req.query as any;
    const data = await getDhrnInterest(prisma, scopeOf(req), (req.params as any).vchNo, 'loan');
    return sendVoucherDocument(reply, loanInterestHtml(data, q.copy), { format: q.format, filename: `loan-interest-${data.voucherNo}` });
  });
}
