import { DESKTOP_MESSAGES } from '../shared/desktopMessages.js';
import { withTenant } from '@datacare/db';
import { assertStrongPassword, hashPassword, verifyPassword } from './password.js';

export class PasswordChangeError extends Error {
  constructor(
    public code:
      | 'current-password-invalid'
      | 'password-confirmation-mismatch'
      | 'user-not-found'
      /** Verbatim MS_USER.cs wording for a blank old-password box. */
      | typeof DESKTOP_MESSAGES.OLD_PASSWORD_REQUIRED,
  ) {
    super(code);
    this.name = 'PasswordChangeError';
  }
}

export async function upgradeLegacyPassword(
  prisma: any,
  input: {
    tenantId: string;
    coCode: string;
    loginName: string;
    legacyPassword: string;
  },
): Promise<void> {
  const passwordHash = await hashPassword(input.legacyPassword);
  const changed = Number(
    await withTenant(prisma, input.tenantId, (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "LOGIN_MAST"
            SET "LOGIN_PWD"=$1,"PASSWORD_RESET_REQUIRED"='Y',"PASSWORD_CHANGED_AT"=NOW()
          WHERE "CO_CODE"=$2 AND "LOGIN_NAME"=$3 AND "LOGIN_PWD"=$4`,
        passwordHash,
        input.coCode,
        input.loginName,
        input.legacyPassword,
      ),
    ),
  );
  if (changed !== 1) throw new PasswordChangeError('user-not-found');
}

export async function changeOwnPassword(
  prisma: any,
  input: {
    tenantId: string;
    loginCoCode: string;
    loginName: string;
    currentPassword: string;
    newPassword: string;
    confirmPassword: string;
    currentSessionId: string;
  },
): Promise<void> {
  // MS_USER.cs guards the blank old-password box before anything else, in these exact words.
  if (!String(input.currentPassword ?? '').trim()) {
    throw new PasswordChangeError(DESKTOP_MESSAGES.OLD_PASSWORD_REQUIRED);
  }
  if (input.newPassword !== input.confirmPassword) {
    throw new PasswordChangeError('password-confirmation-mismatch');
  }
  assertStrongPassword(input.newPassword);
  const nextHash = await hashPassword(input.newPassword);
  const outcome = await withTenant(prisma, input.tenantId, async (tx: any) => {
    const rows: Array<{ LOGIN_PWD?: string | null }> = await tx.$queryRawUnsafe(
      `SELECT "LOGIN_PWD" FROM "LOGIN_MAST"
        WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2 LIMIT 1 FOR UPDATE`,
      input.loginCoCode,
      input.loginName,
    );
    const stored = rows[0]?.LOGIN_PWD;
    if (!stored) return 'missing' as const;
    if (!(await verifyPassword(stored, input.currentPassword))) return 'invalid' as const;
    await tx.$executeRawUnsafe(
      `UPDATE "LOGIN_MAST"
          SET "LOGIN_PWD"=$1,"PASSWORD_RESET_REQUIRED"='N',"PASSWORD_CHANGED_AT"=NOW()
        WHERE "CO_CODE"=$2 AND "LOGIN_NAME"=$3`,
      nextHash,
      input.loginCoCode,
      input.loginName,
    );
    await tx.$executeRawUnsafe(
      `UPDATE "auth_session"
          SET "revoked_at"=NOW(),"revoke_reason"='password-changed'
        WHERE "login_name"=$1 AND "login_co_code"=$2 AND "revoked_at" IS NULL
          AND "session_id"<>$3`,
      input.loginName,
      input.loginCoCode,
      input.currentSessionId,
    );
    return 'ok' as const;
  });
  if (outcome === 'missing') throw new PasswordChangeError('user-not-found');
  if (outcome === 'invalid') throw new PasswordChangeError('current-password-invalid');
}

export async function resetUserPassword(
  prisma: any,
  input: {
    tenantId: string;
    coCode: string;
    loginName: string;
    newPassword: string;
  },
): Promise<void> {
  assertStrongPassword(input.newPassword);
  const nextHash = await hashPassword(input.newPassword);
  const changed = Number(
    await withTenant(prisma, input.tenantId, async (tx: any) => {
      const updated = Number(
        await tx.$executeRawUnsafe(
          `UPDATE "LOGIN_MAST"
              SET "LOGIN_PWD"=$1,"PASSWORD_RESET_REQUIRED"='Y',"PASSWORD_CHANGED_AT"=NOW()
            WHERE "CO_CODE"=$2 AND "LOGIN_NAME"=$3`,
          nextHash,
          input.coCode,
          input.loginName,
        ),
      );
      if (updated !== 1) return updated;
      await tx.$executeRawUnsafe(
        `UPDATE "auth_session"
            SET "revoked_at"=NOW(),"revoke_reason"='password-reset'
          WHERE "login_name"=$1 AND "login_co_code"=$2 AND "revoked_at" IS NULL`,
        input.loginName,
        input.coCode,
      );
      return updated;
    }),
  );
  if (changed !== 1) throw new PasswordChangeError('user-not-found');
}
