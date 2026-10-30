import { withTxBudget } from '../shared/txBudget.js';
import { assertStrongPassword, hashPassword } from '../auth/password.js';
import { FORM_CATALOG } from './formCatalog.js';

/**
 * Users & Rights admin (Phase 13 RBAC).
 *
 * Backing table is the desktop `LOGIN_MAST` (columns: tenant_id, row_id [bigint PK, auto],
 * "CO_CODE", "LOGIN_NAME", "LOGIN_PWD", "LOGIN_CATG", "MAIN_USER"). Row-Level Security is enabled,
 * so every statement runs inside `withTenant(...)` exactly like masters/master.service.ts.
 *
 * The "role" exposed by this module maps 1:1 to `LOGIN_CATG`. A user is an administrator iff
 * LOGIN_CATG starts with "A" (uppercase) — this is the same rule auth.service.rightsOf uses to
 * grant the full user-right set, so it is the single source of truth for "admin".
 *
 * ── GUARD NOTE (admin-only; the ROUTE LAYER must enforce this) ───────────────────────────────────
 * listUsers / createUser / setUserRole are privileged operations and MUST only run for an admin.
 * These functions DO NOT see the caller's session (their signatures take only prisma/tenantId +
 * data), so enforcement happens where the route is wired — alongside the existing `requireAuth`
 * preHandler in app.ts (the coordinator wires `/admin/users`; do NOT edit app.ts here).
 *
 * The JWT session (`sess(req)` → { sub, tenantId, coCode, rights }) does NOT carry LOGIN_CATG, so
 * the route must re-resolve the caller's role from the DB. Use the helper provided below:
 *
 *     app.get('/admin/users', { preHandler: requireAuth }, async (req, reply) => {
 *       const s = sess(req);
 *       try { await assertAdmin(prisma, s.tenantId, { coCode: s.coCode, loginName: s.sub }); }
 *       catch { return reply.code(403).send({ error: 'forbidden', action: 'admin' }); }
 *       return listUsers(prisma, s.tenantId, s.coCode);
 *     });
 *     app.post('/admin/users', { preHandler: requireAuth }, async (req, reply) => {
 *       const s = sess(req);
 *       try { await assertAdmin(prisma, s.tenantId, { coCode: s.coCode, loginName: s.sub }); }
 *       catch { return reply.code(403).send({ error: 'forbidden', action: 'admin' }); }
 *       const b = (req.body ?? {}) as Record<string, string>;
 *       try {
 *         const r = await createUser(prisma, s.tenantId, { coCode: b.coCode ?? s.coCode, loginName: b.loginName, password: b.password, role: b.role });
 *         return reply.code(201).send(r);
 *       } catch (e) {
 *         if (e instanceof UserValidationError) return reply.code(400).send({ error: 'missing-or-invalid', fields: e.fields });
 *         if (e instanceof DuplicateUserError)  return reply.code(409).send({ error: 'duplicate-user' });
 *         throw e;
 *       }
 *     });
 *
 * (setUserRole maps the same way: UserValidationError → 400, UserNotFoundError → 404.)
 * Note: a fully self-contained `assertAdmin` is provided so no edit to jwt.ts/app.ts session shape
 * is needed. Where the existing rights are sufficient, the route may additionally call
 * `assertRight(sess.rights, 'delete')`; but `assertAdmin` is the authoritative admin-only check.
 * ─────────────────────────────────────────────────────────────────────────────────────────────────
 */

/** Roles offered by the admin UI. They map directly to LOGIN_CATG. */
export const USER_ROLES = ['ADMIN', 'USER'] as const;
export type UserRole = (typeof USER_ROLES)[number];

/** A user row safe to return to the client — NEVER includes LOGIN_PWD. */
export interface UserRow {
  loginName: string; // LOGIN_NAME
  role: string; // LOGIN_CATG
  coCode: string; // CO_CODE
  userUpdate: boolean; // USER_UPDATE = 'Y' (Phase 13 rights matrix; create/update)
  userDelete: boolean; // USER_DELETE = 'Y' (delete)
  userPrint: boolean; // USER_PRINT  = 'Y' (print)
}

export interface CreateUserInput {
  /** MAIN_USER — the operator creating this account. */
  mainUser?: string;
  coCode: string;
  lcCode: string;
  loginName: string;
  password: string;
  role: UserRole | string;
}

export interface SetUserRoleInput {
  loginName: string;
  role: UserRole | string;
  /** Optional company scope. Pass the admin's session coCode so the same LOGIN_NAME under another
   *  company is never touched (LOGIN_MAST has no unique key on CO_CODE+LOGIN_NAME). */
  coCode?: string;
}

// ── domain errors (route layer maps these → HTTP status; see GUARD NOTE) ──
export class UserValidationError extends Error {
  constructor(public fields: string[]) {
    super('missing-or-invalid: ' + fields.join(','));
    this.name = 'UserValidationError';
  }
}
export class DuplicateUserError extends Error {
  constructor(public loginName: string) {
    super('duplicate-user: ' + loginName);
    this.name = 'DuplicateUserError';
  }
}
export class UserNotFoundError extends Error {
  constructor(public loginName: string) {
    super('user-not-found: ' + loginName);
    this.name = 'UserNotFoundError';
  }
}
export class ForbiddenAdminError extends Error {
  constructor() {
    super('forbidden: admin-only');
    this.name = 'ForbiddenAdminError';
  }
}
/** Thrown by setUserRights when the rights payload is invalid (e.g. missing loginName).
 *  Name intentionally contains "ValidationError" so the route layer maps it → HTTP 400. */
export class UsersValidationError extends Error {
  constructor(public fields: string[] = ['loginName']) {
    super('missing-or-invalid: ' + fields.join(','));
    this.name = 'UsersValidationError';
  }
}

/**
 * G178: a rights change may not leave the company without an administrator. Observed on the live demo: the only
 * admin set their own LOGIN_CATG to USER and every admin screen answered 403 from then on, with no way back short of
 * editing the database. The desktop has a built-in main user to recover with; the web has none, so it refuses.
 */
export class LastAdministratorValidationError extends Error {
  constructor(loginName: string) {
    super(`the company must keep at least one administrator; ${loginName} is the last one`);
    this.name = 'LastAdministratorValidationError';
  }
}

/** Admin iff LOGIN_CATG starts with "A" (mirrors auth.service.rightsOf). */
export function isAdminRole(role?: string | null): boolean {
  return (role ?? '').toUpperCase().startsWith('A');
}

/** Validate/normalise a requested role to a known LOGIN_CATG value, or '' if unsupported. */
function normalizeRole(role?: string | null): UserRole | '' {
  const r = (role ?? '').trim().toUpperCase();
  return (USER_ROLES as readonly string[]).includes(r) ? (r as UserRole) : '';
}

/** Desktop Y/N right flag → boolean. Mirrors auth.service.rightsOf's `flag` exactly. */
const rightFlag = (v?: string | null): boolean => v === 'Y' || v === '1' || v === 'true';

/** boolean → desktop Y/N right flag (the literal value LOGIN_MAST stores). */
const yn = (b: boolean): 'Y' | 'N' => (b ? 'Y' : 'N');

/** Resolve a login's LOGIN_CATG (role). Used by the route guard to identify the caller. */
export async function resolveRole(
  prisma: any,
  tenantId: string,
  coCode: string,
  loginName: string,
): Promise<string | null> {
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    const rows: { LOGIN_CATG: string | null }[] = await tx.$queryRawUnsafe(
      'SELECT "LOGIN_CATG" FROM "LOGIN_MAST" WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2 LIMIT 1',
      coCode,
      loginName,
    );
    return rows[0]?.LOGIN_CATG ?? null;
  });
}

/** Admin-only guard for the route layer. Throws ForbiddenAdminError when the caller is not admin. */
export async function assertAdmin(
  prisma: any,
  tenantId: string,
  caller: { coCode: string; loginName: string },
): Promise<void> {
  const role = await resolveRole(prisma, tenantId, caller.coCode, caller.loginName);
  if (!isAdminRole(role)) throw new ForbiddenAdminError();
}

/** List users for a company. Returns loginName/role/coCode + the Phase 13 right flags
 *  (USER_UPDATE/USER_DELETE/USER_PRINT) — never the password hash. */
export async function listUsers(
  prisma: any,
  tenantId: string,
  coCode?: string,
): Promise<UserRow[]> {
  return withTxBudget(prisma, tenantId, 'read', async (tx: any) => {
    // The rights matrix is stored in LOGIN_MAST.USER_UPDATE/USER_DELETE/USER_PRINT (Y/N) — the same
    // columns auth.service.rightsOf reads. They are part of the desktop schema but a deployment may
    // predate them, so probe information_schema first: selecting a missing column raises Postgres
    // 42703 which would abort this RLS transaction and break the (working) user list. When absent we
    // degrade to the core columns and report rights as false until a migration adds them.
    const probe: { column_name: string }[] = await tx.$queryRawUnsafe(
      `SELECT column_name FROM information_schema.columns
        WHERE table_name = 'LOGIN_MAST' AND column_name IN ($1, $2, $3)`,
      'USER_UPDATE',
      'USER_DELETE',
      'USER_PRINT',
    );
    const hasRights = probe.length === 3;
    const cols = hasRights
      ? '"LOGIN_NAME","LOGIN_CATG","CO_CODE","USER_UPDATE","USER_DELETE","USER_PRINT"'
      : '"LOGIN_NAME","LOGIN_CATG","CO_CODE"';
    const rows: Record<string, string | null>[] = coCode
      ? await tx.$queryRawUnsafe(
          `SELECT ${cols} FROM "LOGIN_MAST" WHERE "CO_CODE"=$1 ORDER BY "LOGIN_NAME"`,
          coCode,
        )
      : await tx.$queryRawUnsafe(
          `SELECT ${cols} FROM "LOGIN_MAST" ORDER BY "CO_CODE","LOGIN_NAME"`,
        );
    return rows.map((r) => ({
      loginName: r.LOGIN_NAME ?? '',
      role: r.LOGIN_CATG ?? '',
      coCode: r.CO_CODE ?? '',
      userUpdate: rightFlag(r.USER_UPDATE),
      userDelete: rightFlag(r.USER_DELETE),
      userPrint: rightFlag(r.USER_PRINT),
    }));
  });
}

/**
 * Create a user. Password is hashed with Argon2id via auth/password.ts (hashPassword) — plaintext is
 * never stored. Rejects a duplicate LOGIN_NAME within the company (checked in-tx; the table has no
 * unique key on CO_CODE+LOGIN_NAME). Mirrors masters/master.service.createMaster.
 */
export async function createUser(
  prisma: any,
  tenantId: string,
  input: CreateUserInput,
): Promise<{ created: true; loginName: string; role: string }> {
  const coCode = (input.coCode ?? '').trim();
  const lcCode = (input.lcCode ?? '').trim();
  const loginName = (input.loginName ?? '').trim();
  const password = input.password ?? '';
  const role = normalizeRole(input.role);

  const invalid: string[] = [];
  if (!coCode) invalid.push('coCode');
  if (!lcCode) invalid.push('lcCode');
  if (!loginName) invalid.push('loginName');
  if (!password) invalid.push('password');
  if (!role) invalid.push('role');
  if (invalid.length) throw new UserValidationError(invalid);
  assertStrongPassword(password);

  const pwdHash = await hashPassword(password);

  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const dup: unknown[] = await tx.$queryRawUnsafe(
      'SELECT 1 FROM "LOGIN_MAST" WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2 LIMIT 1',
      coCode,
      loginName,
    );
    if (dup.length) throw new DuplicateUserError(loginName);
    await tx.$executeRawUnsafe(
      // MS_USER.cs writes MAIN_USER on the account row: who created this login.
      `INSERT INTO "LOGIN_MAST"(
         tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG",
         "USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED","PASSWORD_CHANGED_AT",
         "MAIN_USER"
       ) VALUES ($1,$2,$3,$4,$5,'Y','Y','Y','N',NOW(),$6)`,
      tenantId,
      coCode,
      loginName,
      pwdHash,
      role,
      // MS_USER.cs records who created the account; absent an acting user the column stays empty rather
      // than naming someone who did not do it.
      (input.mainUser ?? '').trim().slice(0, 15) || null,
    );
    let index = 0;
    for (const form of FORM_CATALOG) {
      index += 1;
      await tx.$executeRawUnsafe(
        `INSERT INTO "USER_SET"(
           tenant_id,"CO_CODE","LC_CODE","MAIN_SRNO","SUB_SRNO","USER_NAME","MAIN_MENU",
           "SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT"
         ) VALUES ($1,$2,$3,$4,$5,$6,$7,$8,'Y','Y','Y','Y')`,
        tenantId,
        coCode,
        lcCode,
        index,
        String(index),
        loginName,
        form.mainMenu,
        form.subMenu,
      );
    }
    return { created: true as const, loginName, role };
  });
}

/** Change a user's role (LOGIN_CATG). Scoped by coCode when provided. */
export async function setUserRole(
  prisma: any,
  tenantId: string,
  input: SetUserRoleInput,
): Promise<{ updated: true; loginName: string; role: string }> {
  const loginName = (input.loginName ?? '').trim();
  const role = normalizeRole(input.role);
  const coCode = input.coCode?.trim();

  const invalid: string[] = [];
  if (!loginName) invalid.push('loginName');
  if (!role) invalid.push('role');
  if (invalid.length) throw new UserValidationError(invalid);

  return withTxBudget(prisma, tenantId, 'voucher', async (tx: any) => {
    const affected: number = coCode
      ? await tx.$executeRawUnsafe(
          'UPDATE "LOGIN_MAST" SET "LOGIN_CATG"=$1 WHERE "LOGIN_NAME"=$2 AND "CO_CODE"=$3',
          role,
          loginName,
          coCode,
        )
      : await tx.$executeRawUnsafe(
          'UPDATE "LOGIN_MAST" SET "LOGIN_CATG"=$1 WHERE "LOGIN_NAME"=$2',
          role,
          loginName,
        );
    if (!affected) throw new UserNotFoundError(loginName);
    return { updated: true as const, loginName, role };
  });
}

/**
 * Phase 13 per-user RIGHTS MATRIX writer.
 *
 * Persists the desktop right flags onto LOGIN_MAST (USER_UPDATE / USER_DELETE / USER_PRINT, each
 * 'Y' | 'N') and optionally re-categorises the login (LOGIN_CATG). These are the exact columns
 * auth.service.rightsOf reads and policy.ts/guard() enforce at runtime, so saving here is the
 * single source of truth for a user's effective rights. Scoped by CO_CODE so the same LOGIN_NAME
 * under another company is never touched (LOGIN_MAST has no unique key on CO_CODE+LOGIN_NAME), and
 * runs inside withTenant() for RLS exactly like every other statement in this module.
 *
 * Admins (LOGIN_CATG starting with 'A') implicitly hold every right via rightsOf, so the UI shows
 * their flags as all-on/disabled; this function still writes whatever flags it is given.
 *
 * Requires the LOGIN_MAST.USER_UPDATE/USER_DELETE/USER_PRINT columns (varchar(1)) to exist; add
 * them by migration on any deployment that predates the rights matrix.
 */
export async function setUserRights(
  prisma: any,
  scope: { tenantId: string; coCode: string },
  p: {
    loginName: string;
    catg?: string;
    userUpdate: boolean;
    userDelete: boolean;
    userPrint: boolean;
  },
): Promise<{ saved: true }> {
  const loginName = (p.loginName ?? '').trim();
  if (!loginName) throw new UsersValidationError(['loginName']);
  const coCode = (scope.coCode ?? '').trim();
  const setCatg = p.catg !== undefined && p.catg !== null && String(p.catg).trim() !== '';

  return withTxBudget(prisma, scope.tenantId, 'voucher', async (tx: any) => {
    if (setCatg && !isAdminRole(String(p.catg))) {
      // Lock the company's administrators, so two of them demoting each other at once cannot both succeed.
      const admins: { LOGIN_NAME: string | null }[] = await tx.$queryRawUnsafe(
        `SELECT "LOGIN_NAME" FROM "LOGIN_MAST"
          WHERE "CO_CODE"=$1 AND upper(coalesce("LOGIN_CATG",'')) LIKE 'A%' FOR UPDATE`,
        coCode,
      );
      const same = (name: string | null) =>
        (name ?? '').trim().toUpperCase() === loginName.toUpperCase();
      if (admins.some((row) => same(row.LOGIN_NAME)) && admins.every((row) => same(row.LOGIN_NAME)))
        throw new LastAdministratorValidationError(loginName);
    }
    if (setCatg) {
      await tx.$executeRawUnsafe(
        'UPDATE "LOGIN_MAST" SET "USER_UPDATE"=$1,"USER_DELETE"=$2,"USER_PRINT"=$3,"LOGIN_CATG"=$4 WHERE "CO_CODE"=$5 AND "LOGIN_NAME"=$6',
        yn(p.userUpdate),
        yn(p.userDelete),
        yn(p.userPrint),
        String(p.catg).trim(),
        coCode,
        loginName,
      );
    } else {
      await tx.$executeRawUnsafe(
        'UPDATE "LOGIN_MAST" SET "USER_UPDATE"=$1,"USER_DELETE"=$2,"USER_PRINT"=$3 WHERE "CO_CODE"=$4 AND "LOGIN_NAME"=$5',
        yn(p.userUpdate),
        yn(p.userDelete),
        yn(p.userPrint),
        coCode,
        loginName,
      );
    }
    return { saved: true as const };
  });
}
