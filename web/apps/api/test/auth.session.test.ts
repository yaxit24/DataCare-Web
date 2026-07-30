import { describe, expect, it, vi } from 'vitest';
import {
  createAuthSession,
  revokeSession,
  rotateRefreshSession,
  SessionRejectedError,
  updateSessionScope,
  validateAccessSession,
} from '../src/modules/auth/session.js';
import type { RefreshClaims, SessionClaims } from '../src/modules/auth/jwt.js';

function memoryDb() {
  let row: any;
  const tx = {
    $queryRawUnsafe: vi.fn(async (sql: string, sessionId: string) => {
      if (sql.includes('FROM "auth_session"') && row?.sessionId === sessionId) return [{ ...row }];
      return [];
    }),
    $executeRawUnsafe: vi.fn(async (sql: string, ...params: any[]) => {
      if (sql.includes("set_config('app.tenant_id'")) return 1;
      if (sql.includes('INSERT INTO "auth_session"')) {
        row = {
          tenantId: params[0],
          sessionId: params[1],
          loginName: params[2],
          loginCoCode: params[3],
          coCode: params[4],
          lcCode: params[5],
          coYear: params[6],
          refreshJtiHash: params[7],
          createdAt: params[8],
          lastUsedAt: params[8],
          expiresAt: params[9],
          revokedAt: null,
          revokeReason: null,
        };
        return 1;
      }
      if (sql.includes('SET "refresh_jti_hash"')) {
        if (
          !row ||
          row.sessionId !== params[2] ||
          row.refreshJtiHash !== params[3] ||
          row.revokedAt
        )
          return 0;
        row.refreshJtiHash = params[0];
        row.lastUsedAt = params[1];
        return 1;
      }
      if (sql.includes("'refresh-reuse'")) {
        row.revokedAt = params[0];
        row.revokeReason = 'refresh-reuse';
        return 1;
      }
      if (sql.includes('COALESCE("revoked_at"')) {
        row.revokedAt ??= params[0];
        row.revokeReason ??= params[1];
        return 1;
      }
      if (sql.includes('SET "co_code"')) {
        row.coCode = params[0];
        row.lcCode = params[1];
        row.coYear = params[2];
        return row.revokedAt ? 0 : 1;
      }
      if (sql.includes("'expired'")) {
        row.revokedAt = params[0];
        row.revokeReason = 'expired';
        return 1;
      }
      return 1;
    }),
  };
  const prisma = { $transaction: (fn: (arg: typeof tx) => unknown) => fn(tx) };
  return {
    prisma,
    tx,
    get row() {
      return row;
    },
  };
}

const accessClaims = (sid: string): SessionClaims =>
  ({
    sub: 'admin',
    tenantId: 't1',
    loginCoCode: '01',
    coCode: '01',
    lcCode: '01',
    coYear: '2024',
    sid,
    rights: { userUpdate: true, userDelete: true, userPrint: true },
    typ: 'access',
  }) as SessionClaims;

const refreshClaims = (sid: string, jti: string): RefreshClaims =>
  ({ sub: 'admin', tenantId: 't1', sid, jti, typ: 'refresh' }) as RefreshClaims;

describe('persistent auth sessions', () => {
  it('validates active access sessions and rejects them immediately after logout', async () => {
    const db = memoryDb();
    const created = await createAuthSession(db.prisma, {
      tenantId: 't1',
      loginName: 'admin',
      loginCoCode: '01',
      coCode: '01',
      lcCode: '01',
      coYear: '2024',
    });
    await expect(
      validateAccessSession(db.prisma, accessClaims(created.session.sessionId)),
    ).resolves.toMatchObject({ loginName: 'admin', coYear: '2024' });
    await revokeSession(db.prisma, 't1', created.session.sessionId, 'logout');
    await expect(
      validateAccessSession(db.prisma, accessClaims(created.session.sessionId)),
    ).rejects.toBeInstanceOf(SessionRejectedError);
  });

  it('rotates refresh JTIs and revokes the session when the old token is replayed', async () => {
    const db = memoryDb();
    const created = await createAuthSession(db.prisma, {
      tenantId: 't1',
      loginName: 'admin',
      loginCoCode: '01',
      coCode: '01',
      lcCode: '01',
      coYear: '2024',
    });
    const old = refreshClaims(created.session.sessionId, created.refreshJti);
    const rotated = await rotateRefreshSession(db.prisma, old);
    expect(rotated.refreshJti).not.toBe(created.refreshJti);
    await expect(rotateRefreshSession(db.prisma, old)).rejects.toMatchObject({
      code: 'refresh-reused',
    });
    expect(db.row.revokeReason).toBe('refresh-reuse');
    await expect(
      rotateRefreshSession(db.prisma, refreshClaims(created.session.sessionId, rotated.refreshJti)),
    ).rejects.toMatchObject({ code: 'session-revoked' });
  });

  it('persists selected context so old access scope can be rejected', async () => {
    const db = memoryDb();
    const created = await createAuthSession(db.prisma, {
      tenantId: 't1',
      loginName: 'admin',
      loginCoCode: '01',
      coCode: '01',
      lcCode: '01',
      coYear: '2024',
    });
    await updateSessionScope(db.prisma, 't1', created.session.sessionId, {
      coCode: '02',
      lcCode: '03',
      coYear: '2025',
    });
    expect(db.row).toMatchObject({ coCode: '02', lcCode: '03', coYear: '2025' });
  });
});
