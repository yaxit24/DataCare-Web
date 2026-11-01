import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import type { CrmRouteHelpers } from './crm.js';
import {
  EmployeeVersionConflictError,
  deleteEmployee,
  employeeAccounts,
  employeePrintRows,
  getEmployee,
  listEmployees,
  saveEmployee,
} from '../modules/masters/employeeMaster.js';

/** The rights row of the screen and its routes (routePolicy 'Masters/Employees', desktop SUB_MENU 'Employee'). */
const FORM = 'Masters/Employees';

/**
 * Employee master (MS_EMP). A new employee needs only the view right and an opened one the edit right, as BtnSave_Click
 * checks FRM_EDIT only in edit mode (MS_EMP.cs:1478-1484), so the screen posts a new employee and puts an opened one.
 * The list returns the user's rights, which MS_EMP_Load reads for the buttons' texts (:1000-1007).
 */
export function registerEmployeeMasterRoutes(
  app: FastifyInstance,
  h: Pick<CrmRouteHelpers, 'prisma' | 'auth' | 'scopeOf' | 'run' | 'body' | 'mainUserOf'> & {
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
  const { prisma, auth, guard, scopeOf, run, body, mainUserOf } = h;
  const scope = (req: FastifyRequest) => {
    const s = scopeOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode };
  };
  const codeOf = (req: FastifyRequest) => String((req.params as any).code ?? '');
  /** run(), with a stale version answered 409 as the voucher routes answer theirs. */
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return await run(reply, okCode, fn);
    } catch (e) {
      if (e instanceof EmployeeVersionConflictError)
        return reply.code(409).send({ error: e.code, message: e.message });
      throw e;
    }
  };

  app.get('/masters/employee-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const order = (req.query as any)?.order === 'code' ? 'code' : 'name';
    return run(reply, 200, async () => ({
      ...(await listEmployees(prisma, scope(req), order)),
      rights: await capabilities(req, FORM),
    }));
  });
  app.get('/masters/employee-master/print', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'print')) return;
    return run(reply, 200, async () => ({ rows: await employeePrintRows(prisma, scope(req)) }));
  });
  app.get('/masters/employee-master/accounts', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const q = (req.query as any) ?? {};
    return run(reply, 200, () =>
      employeeAccounts(prisma, scope(req), String(q.q ?? ''), Number(q.limit) || 20),
    );
  });
  app.get('/masters/employee-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    const employee = await getEmployee(prisma, scope(req), codeOf(req));
    if (!employee)
      return reply.code(404).send({ error: 'employee-not-found', message: 'employee not found' });
    return reply.code(200).send(employee);
  });
  const save = (req: FastifyRequest, entryMode: 'A' | 'E', code: string) => {
    const b = body(req);
    return saveEmployee(prisma, {
      scope: scope(req),
      entryMode,
      code,
      name: b.name,
      account: b.account,
      amount: b.amount,
      dayHours: b.dayHours,
      user: b.user,
      mainUser: mainUserOf(req),
      canUpdate: true,
      expectedVersion: b.expectedVersion,
    });
  };
  app.post('/masters/employee-master', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    return write(reply, 201, () => save(req, 'A', String(body(req).code ?? '')));
  });
  app.put('/masters/employee-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    return write(reply, 200, () => save(req, 'E', codeOf(req)));
  });
  app.delete('/masters/employee-master/:code', auth as any, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deleteEmployee(prisma, scope(req), codeOf(req), (req.query as any)?.expectedVersion),
    );
  });
}
