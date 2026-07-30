import type { UserRights } from '@datacare/types';
import { verifyWithMigration } from './password.js';

export interface LoginMastRow {
  CO_CODE: string;
  LOGIN_NAME: string;
  LOGIN_PWD: string;
  LOGIN_CATG?: string | null;
  USER_UPDATE?: string | null;
  USER_DELETE?: string | null;
  USER_PRINT?: string | null;
  PASSWORD_RESET_REQUIRED?: string | null;
  PASSWORD_CHANGED_AT?: Date | string | null;
}

export interface AuthInput {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  loginName: string;
  password: string;
}

export interface AuthAttempt {
  tenantId: string;
  coCode: string;
  loginName: string;
  success: boolean;
  reason?: string;
}

export interface AuthDeps {
  loadUser: (tenantId: string, coCode: string, loginName: string) => Promise<LoginMastRow | null>;
  audit: (attempt: AuthAttempt) => Promise<void>;
}

export interface Session {
  userId: string;
  coCode: string;
  lcCode?: string;
  rights: UserRights;
  forcedReset: boolean;
  legacyPassword: boolean;
}

export class AuthError extends Error {
  constructor(public reason: string) {
    super(reason);
    this.name = 'AuthError';
  }
}

const flag = (v?: string | null): boolean => v === 'Y' || v === '1' || v === 'true';

export function rightsOf(u: LoginMastRow): UserRights {
  const admin = (u.LOGIN_CATG ?? '').toUpperCase().startsWith('A');
  return {
    userUpdate: admin || flag(u.USER_UPDATE),
    userDelete: admin || flag(u.USER_DELETE),
    userPrint: admin || flag(u.USER_PRINT),
  };
}

/** Authenticate against LOGIN_MAST for the company (Req 6.1–6.3). */
export async function authenticate(deps: AuthDeps, input: AuthInput): Promise<Session> {
  const base = { tenantId: input.tenantId, coCode: input.coCode, loginName: input.loginName };
  const user = await deps.loadUser(input.tenantId, input.coCode, input.loginName);
  if (!user) {
    await deps.audit({ ...base, success: false, reason: 'unknown-user' });
    throw new AuthError('invalid-credentials');
  }
  const migrated = await verifyWithMigration(user.LOGIN_PWD, input.password);
  if (!migrated.ok) {
    await deps.audit({ ...base, success: false, reason: 'bad-password' });
    throw new AuthError('invalid-credentials');
  }
  await deps.audit({ ...base, success: true });
  return {
    userId: user.LOGIN_NAME,
    coCode: user.CO_CODE,
    lcCode: input.lcCode,
    rights: rightsOf(user),
    forcedReset: migrated.forcedReset || flag(user.PASSWORD_RESET_REQUIRED),
    legacyPassword: migrated.forcedReset,
  };
}
