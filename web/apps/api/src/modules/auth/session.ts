import { createHash, randomBytes, randomUUID, timingSafeEqual } from 'node:crypto';
import { withTxBudget } from '../shared/txBudget.js';
import type { RefreshClaims, SessionClaims } from './jwt.js';

export const REFRESH_SESSION_TTL_MS = 7 * 24 * 60 * 60 * 1000;

export interface AuthSessionRecord {
  tenantId: string;
  sessionId: string;
  loginName: string;
  loginCoCode: string;
  coCode: string;
  lcCode: string;
  coYear?: string;
  expiresAt: Date;
  revokedAt?: Date;
  revokeReason?: string;
}

export class SessionRejectedError extends Error {
  constructor(
    public code: 'session-revoked' | 'session-expired' | 'session-invalid' | 'refresh-reused',
  ) {
    super(code);
    this.name = 'SessionRejectedError';
  }
}

const hashJti = (jti: string): string => createHash('sha256').update(jti).digest('hex');
const newJti = (): string => randomBytes(32).toString('base64url');

const equalHash = (left: string, right: string): boolean => {
  const a = Buffer.from(left, 'hex');
  const b = Buffer.from(right, 'hex');
  return a.length === b.length && timingSafeEqual(a, b);
};

interface SessionRow {
  tenantId: string;
  sessionId: string;
  loginName: string;
  loginCoCode: string;
  coCode: string;
  lcCode: string;
  coYear: string | null;
  refreshJtiHash: string;
  expiresAt: Date;
  revokedAt: Date | null;
  revokeReason: string | null;
}

const toRecord = (row: SessionRow): AuthSessionRecord => ({
  tenantId: row.tenantId,
  sessionId: row.sessionId,
  loginName: row.loginName,
  loginCoCode: row.loginCoCode,
  coCode: row.coCode,
  lcCode: row.lcCode,
  coYear: row.coYear ?? undefined,
  expiresAt: new Date(row.expiresAt),
  revokedAt: row.revokedAt ? new Date(row.revokedAt) : undefined,
  revokeReason: row.revokeReason ?? undefined,
});

const selectSessionSql = `
  SELECT "tenant_id" AS "tenantId", "session_id" AS "sessionId",
         "login_name" AS "loginName", "login_co_code" AS "loginCoCode",
         "co_code" AS "coCode", "lc_code" AS "lcCode", "co_year" AS "coYear",
         "refresh_jti_hash" AS "refreshJtiHash", "expires_at" AS "expiresAt",
         "revoked_at" AS "revokedAt", "revoke_reason" AS "revokeReason"
    FROM "auth_session"
   WHERE "session_id"=$1
`;

export async function createAuthSession(
  prisma: any,
  input: {
    tenantId: string;
    loginName: string;
    loginCoCode: string;
    coCode: string;
    lcCode: string;
    coYear?: string;
    now?: Date;
  },
): Promise<{ session: AuthSessionRecord; refreshJti: string }> {
  const now = input.now ?? new Date();
  const sessionId = randomUUID();
  const refreshJti = newJti();
  const expiresAt = new Date(now.getTime() + REFRESH_SESSION_TTL_MS);
  await withTxBudget(prisma, input.tenantId, 'voucher', (tx: any) =>
    tx.$executeRawUnsafe(
      `INSERT INTO "auth_session"(
         "tenant_id","session_id","login_name","login_co_code","co_code","lc_code","co_year",
         "refresh_jti_hash","created_at","last_used_at","expires_at"
       ) VALUES ($1,$2,$3,$4,$5,$6,$7,$8,$9,$9,$10)`,
      input.tenantId,
      sessionId,
      input.loginName,
      input.loginCoCode,
      input.coCode,
      input.lcCode,
      input.coYear ?? null,
      hashJti(refreshJti),
      now,
      expiresAt,
    ),
  );
  return {
    session: {
      tenantId: input.tenantId,
      sessionId,
      loginName: input.loginName,
      loginCoCode: input.loginCoCode,
      coCode: input.coCode,
      lcCode: input.lcCode,
      coYear: input.coYear,
      expiresAt,
    },
    refreshJti,
  };
}

export async function validateAccessSession(
  prisma: any,
  claims: SessionClaims,
  now: Date = new Date(),
): Promise<AuthSessionRecord> {
  const rows: SessionRow[] = await withTxBudget(prisma, claims.tenantId, 'read', (tx: any) =>
    tx.$queryRawUnsafe(selectSessionSql, claims.sid),
  );
  const row = rows[0];
  if (!row || row.loginName !== claims.sub || row.tenantId !== claims.tenantId) {
    throw new SessionRejectedError('session-invalid');
  }
  if (row.revokedAt) throw new SessionRejectedError('session-revoked');
  if (new Date(row.expiresAt).getTime() <= now.getTime()) {
    throw new SessionRejectedError('session-expired');
  }
  return toRecord(row);
}

export async function rotateRefreshSession(
  prisma: any,
  claims: RefreshClaims,
  now: Date = new Date(),
): Promise<{ session: AuthSessionRecord; refreshJti: string }> {
  const nextJti = newJti();
  const outcome = await withTxBudget(prisma, claims.tenantId, 'voucher', async (tx: any) => {
    const rows: SessionRow[] = await tx.$queryRawUnsafe(
      `${selectSessionSql} FOR UPDATE`,
      claims.sid,
    );
    const row = rows[0];
    if (!row || row.loginName !== claims.sub || row.tenantId !== claims.tenantId) {
      return { status: 'invalid' as const };
    }
    if (row.revokedAt) return { status: 'revoked' as const };
    if (new Date(row.expiresAt).getTime() <= now.getTime()) {
      await tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "revoked_at"=$1,"revoke_reason"='expired'
          WHERE "session_id"=$2 AND "revoked_at" IS NULL`,
        now,
        claims.sid,
      );
      return { status: 'expired' as const };
    }
    if (!equalHash(row.refreshJtiHash, hashJti(claims.jti))) {
      // A rotated token was replayed. Revoke the whole session and commit that revocation before the
      // caller receives an error; throwing inside this transaction would roll the update back.
      await tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "revoked_at"=$1,"revoke_reason"='refresh-reuse'
          WHERE "session_id"=$2 AND "revoked_at" IS NULL`,
        now,
        claims.sid,
      );
      return { status: 'reused' as const };
    }
    const changed = Number(
      await tx.$executeRawUnsafe(
        `UPDATE "auth_session"
            SET "refresh_jti_hash"=$1,"last_used_at"=$2
          WHERE "session_id"=$3 AND "refresh_jti_hash"=$4 AND "revoked_at" IS NULL`,
        hashJti(nextJti),
        now,
        claims.sid,
        row.refreshJtiHash,
      ),
    );
    if (changed !== 1) return { status: 'reused' as const };
    return { status: 'ok' as const, row };
  });

  switch (outcome.status) {
    case 'invalid':
      throw new SessionRejectedError('session-invalid');
    case 'revoked':
      throw new SessionRejectedError('session-revoked');
    case 'expired':
      throw new SessionRejectedError('session-expired');
    case 'reused':
      throw new SessionRejectedError('refresh-reused');
    case 'ok':
      return { session: toRecord(outcome.row), refreshJti: nextJti };
  }
}

export async function updateSessionScope(
  prisma: any,
  tenantId: string,
  sessionId: string,
  scope: { coCode: string; lcCode: string; coYear?: string },
): Promise<void> {
  const changed = Number(
    await withTxBudget(prisma, tenantId, 'voucher', (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "co_code"=$1,"lc_code"=$2,"co_year"=$3
          WHERE "session_id"=$4 AND "revoked_at" IS NULL`,
        scope.coCode,
        scope.lcCode,
        scope.coYear ?? null,
        sessionId,
      ),
    ),
  );
  if (changed !== 1) throw new SessionRejectedError('session-revoked');
}

export async function revokeSession(
  prisma: any,
  tenantId: string,
  sessionId: string,
  reason: string,
  now: Date = new Date(),
): Promise<void> {
  await withTxBudget(prisma, tenantId, 'voucher', (tx: any) =>
    tx.$executeRawUnsafe(
      `UPDATE "auth_session" SET "revoked_at"=COALESCE("revoked_at",$1),
              "revoke_reason"=COALESCE("revoke_reason",$2)
        WHERE "session_id"=$3`,
      now,
      reason.slice(0, 40),
      sessionId,
    ),
  );
}

export async function revokeUserSessions(
  prisma: any,
  input: {
    tenantId: string;
    loginName: string;
    loginCoCode: string;
    reason: string;
    exceptSessionId?: string;
    now?: Date;
  },
): Promise<number> {
  const now = input.now ?? new Date();
  return Number(
    await withTxBudget(prisma, input.tenantId, 'voucher', (tx: any) =>
      tx.$executeRawUnsafe(
        `UPDATE "auth_session" SET "revoked_at"=$1,"revoke_reason"=$2
          WHERE "login_name"=$3 AND "login_co_code"=$4 AND "revoked_at" IS NULL
            AND ($5::text IS NULL OR "session_id"<>$5)`,
        now,
        input.reason.slice(0, 40),
        input.loginName,
        input.loginCoCode,
        input.exceptSessionId ?? null,
      ),
    ),
  );
}
