import type { FastifyInstance, FastifyRequest, FastifyReply } from 'fastify';
import { withTxBudget } from '../modules/shared/txBudget.js';
import { listScopeCompanies } from '../modules/auth/businessScope.js';
import type { Principal } from '../modules/rbac/authorization.js';
import type { CrmRouteHelpers } from './crm.js';
import {
  COMPANY_FIELDS,
  CompanyIdentityError,
  getCompanyIdentity,
  companyPrintRows,
  saveCompanyIdentity,
  deleteCompanyIdentity,
} from '../modules/masters/companyIdentity.js';

export function registerCompanyIdentityRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'mainUserOf'>,
) {
  const { prisma, auth, scopeOf, mainUserOf } = h;
  // A Company menu right must not bypass the login's company assignments.
  const accessible = async (req: FastifyRequest, code: string) => {
    const principal = (req as FastifyRequest & { principal: Principal }).principal;
    const companies = await listScopeCompanies(prisma, {
      tenantId: scopeOf(req).tenantId,
      loginName: principal.loginName,
      isAdmin: principal.isAdmin,
    });
    if (!companies.some((company) => company.CO_CODE === code))
      throw new CompanyIdentityError('Company is unavailable', 404);
  };
  const schema = {
    type: 'object',
    additionalProperties: false,
    properties: {
      ...Object.fromEntries(
        Object.entries(COMPANY_FIELDS).map(([key, maxLength]) => [
          key,
          { type: 'string', maxLength: key === 'CO_STATE' ? 100 : maxLength },
        ]),
      ),
      importAllParties: { type: 'boolean' },
      expectedVersion: { type: 'string', pattern: '^[a-f0-9]{64}$' },
      sourceCoCode: { type: 'string', maxLength: 2 },
      firstYear: {
        type: 'object',
        additionalProperties: false,
        required: ['coYear'],
        properties: {
          coYear: { type: 'string', maxLength: 9 },
          opDate: { type: 'string' },
          clDate: { type: 'string' },
          yearMonth: { type: 'string', pattern: '^(0[1-9]|1[0-2])$' },
        },
      },
    },
    required: ['CO_CODE', 'CO_NAME'],
  };
  const run = async (reply: any, fn: () => Promise<any>) => {
    try {
      return await fn();
    } catch (e) {
      if (e instanceof CompanyIdentityError)
        return reply.code(e.statusCode).send({ error: 'company-identity', message: e.message });
      if (e instanceof Error && e.name.endsWith('ValidationError'))
        return reply.code(400).send({ error: e.name, message: e.message });
      throw e;
    }
  };
  app.get('/company-identity/states', auth as any, async (req) =>
    withTxBudget(prisma, scopeOf(req).tenantId, 'read', (tx: any) =>
      tx.$queryRawUnsafe(
        'SELECT "STATE_CODE","STATE_NAME" FROM "STATE_MAST" WHERE tenant_id=$1 ORDER BY "STATE_NAME"',
        scopeOf(req).tenantId,
      ),
    ),
  );
  // MS_COMPANY.cs:6776-6790: the Print right (USER_SET FRM_PRINT, "You Have No Print Rights.....") and the session
  // company's Company.RPT row.
  app.get('/company-identity/print', auth as any, async (req) => ({
    rows: await companyPrintRows(prisma, scopeOf(req).tenantId, scopeOf(req).coCode),
  }));
  app.get('/company-identity/:code', auth as any, async (req, reply) => {
    return run(reply, async () => {
      await accessible(req, (req.params as any).code);
      const row = await getCompanyIdentity(prisma, scopeOf(req).tenantId, (req.params as any).code);
      return row ?? reply.code(404).send({ error: 'company-unavailable' });
    });
  });
  const save = (edit: boolean) => async (req: FastifyRequest, reply: FastifyReply) =>
    run(reply, async () => {
      const body = req.body as any;
      if (edit) await accessible(req, body.CO_CODE);
      if (!edit && body.sourceCoCode) await accessible(req, body.sourceCoCode);
      return saveCompanyIdentity(
        prisma,
        scopeOf(req).tenantId,
        mainUserOf(req),
        req.body as any,
        edit,
        (app as any).editionPolicy?.code,
      );
    });
  app.post('/company-identity', { ...(auth as any), schema: { body: schema } }, save(false));
  app.put(
    '/company-identity',
    {
      ...(auth as any),
      schema: { body: { ...schema, required: ['CO_CODE', 'CO_NAME', 'expectedVersion'] } },
    },
    save(true),
  );
  app.delete(
    '/company-identity/:code',
    {
      ...(auth as any),
      schema: {
        querystring: {
          type: 'object',
          additionalProperties: false,
          required: ['expectedVersion'],
          properties: { expectedVersion: { type: 'string', pattern: '^[a-f0-9]{64}$' } },
        },
      },
    },
    async (req, reply) =>
      run(reply, async () => {
        await accessible(req, (req.params as any).code);
        return deleteCompanyIdentity(
          prisma,
          scopeOf(req).tenantId,
          (req.params as any).code,
          (req.query as any).expectedVersion,
        );
      }),
  );
}
