import type { FastifyInstance, FastifyReply, FastifyRequest } from 'fastify';
import { PasswordChangeError, resetUserPassword } from '../modules/auth/passwordAccount.js';
import { PasswordPolicyError } from '../modules/auth/password.js';
import { getFormCatalog } from '../modules/rbac/formCatalog.js';
import { getUserFormRights, setUserFormRights } from '../modules/rbac/formRights.js';
import { listUsers, setUserRights } from '../modules/rbac/users.js';
import {
  createDesktopUser,
  deactivateDesktopUser,
  updateDesktopUser,
  UserMasterNotFoundError,
  UserMasterValidationError,
} from '../modules/rbac/userMaster.js';

interface UserRouteHelpers {
  prisma: any;
  auth: unknown;
  guard: (
    req: FastifyRequest,
    reply: FastifyReply,
    action: 'view' | 'create' | 'update' | 'delete' | 'print',
  ) => boolean;
  run: (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => Promise<unknown>;
  body: (req: FastifyRequest) => Record<string, any>;
}

/** The authenticated session app.ts attaches before any handler runs. */
interface RouteSession {
  tenantId: string;
  sub: string;
  sid: string;
  coCode: string;
  lcCode: string;
  loginCoCode: string;
}

/**
 * User Create (desktop MS_USER, menu caption "User Create", rights form 'Utilities/Users & Rights').
 *
 * Every route is admin-only in the registry (routePolicy ADMIN_ONLY) and classified by its action: the list and the new
 * user are View, the edit-mode Save is Edit (BtnSave_Click checks FRM_EDIT in edit mode, MS_USER.cs:1830-1834), Delete is
 * Delete (:2073-2077). Refusals carry the desktop's text in `message` and the box to return to in `field`.
 */
export function registerUserMasterRoutes(app: FastifyInstance, h: UserRouteHelpers): void {
  const { prisma, guard, run, body } = h;
  const auth = h.auth as any;
  const sessionOf = (req: FastifyRequest) => (req as any).session as RouteSession;
  const scope = (req: FastifyRequest) => {
    const s = sessionOf(req);
    return { tenantId: s.tenantId, coCode: s.coCode, lcCode: s.lcCode };
  };
  const nameParam = (req: FastifyRequest) => String((req.params as any).loginName ?? '');
  const write = async (reply: FastifyReply, okCode: number, fn: () => Promise<unknown>) => {
    try {
      return reply.code(okCode).send((await fn()) as any);
    } catch (error) {
      if (error instanceof UserMasterValidationError)
        return reply
          .code(error.statusCode)
          .send({ error: error.name, message: error.message, field: error.field });
      if (error instanceof UserMasterNotFoundError)
        return reply.code(404).send({ error: error.name, message: error.message });
      if (error instanceof PasswordPolicyError)
        return reply.code(400).send({ error: 'weak-password', reasons: error.reasons });
      return run(reply, okCode, () => Promise.reject(error));
    }
  };

  app.get('/admin/users', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () => listUsers(prisma, sessionOf(req).tenantId, sessionOf(req).coCode));
  });
  // Save in add mode (EntryMode 'A').
  app.post('/admin/users', auth, async (req, reply) => {
    if (!guard(req, reply, 'create')) return;
    const b = body(req);
    return write(reply, 201, () =>
      createDesktopUser(prisma, scope(req), {
        loginName: b.loginName,
        password: b.password,
        confirmPassword: b.confirmPassword,
        userType: b.userType ?? b.role,
        mainUser: sessionOf(req).sub,
      }),
    );
  });
  // Save in edit mode (EntryMode 'E': the name typed is an existing user).
  app.post('/admin/users/:loginName/update', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return write(reply, 200, () =>
      updateDesktopUser(
        prisma,
        scope(req),
        nameParam(req),
        {
          oldPassword: b.oldPassword,
          newPassword: b.newPassword,
          confirmPassword: b.confirmPassword,
          userType: b.userType,
        },
        { sessionId: sessionOf(req).sid },
      ),
    );
  });
  app.delete('/admin/users/:loginName', auth, async (req, reply) => {
    if (!guard(req, reply, 'delete')) return;
    return write(reply, 200, () =>
      deactivateDesktopUser(prisma, scope(req), nameParam(req), {
        loginName: sessionOf(req).sub,
      }),
    );
  });
  app.post('/admin/users/:loginName/rights', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      setUserRights(
        prisma,
        { tenantId: sessionOf(req).tenantId, coCode: sessionOf(req).coCode },
        {
          loginName: nameParam(req),
          catg: b.catg,
          userUpdate: !!b.userUpdate,
          userDelete: !!b.userDelete,
          userPrint: !!b.userPrint,
        },
      ),
    );
  });
  // Per-form RBAC (USER_SET): the rights grid of the Basic and higher editions (hidden in Lite, D36).
  app.get('/admin/form-catalog', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, async () => getFormCatalog((app as any).editionPolicy));
  });
  app.get('/admin/users/:loginName/form-rights', auth, async (req, reply) => {
    if (!guard(req, reply, 'view')) return;
    return run(reply, 200, () =>
      getUserFormRights(
        prisma,
        { tenantId: sessionOf(req).tenantId, lcCode: sessionOf(req).lcCode },
        nameParam(req),
      ),
    );
  });
  app.post('/admin/users/:loginName/form-rights', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    return run(reply, 200, () =>
      setUserFormRights(prisma, scope(req), nameParam(req), b.rows ?? []),
    );
  });
  app.post('/admin/users/:loginName/password-reset', auth, async (req, reply) => {
    if (!guard(req, reply, 'update')) return;
    const b = body(req);
    try {
      await resetUserPassword(prisma, {
        tenantId: sessionOf(req).tenantId,
        coCode: sessionOf(req).coCode,
        loginName: nameParam(req),
        newPassword: String(b.newPassword ?? ''),
      });
      return { reset: true, forcedChange: true };
    } catch (error) {
      if (error instanceof PasswordPolicyError) {
        return reply.code(400).send({ error: 'weak-password', reasons: error.reasons });
      }
      if (error instanceof PasswordChangeError) {
        return reply.code(404).send({ error: error.code });
      }
      throw error;
    }
  });
}
