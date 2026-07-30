import { withTenant } from '@datacare/db';

/** Audit trail for authenticated HTTP mutations. The onResponse hook cannot roll back an already
 * completed business request, so persistence failure is returned explicitly for structured logging. */
export interface AuditEntry {
  loginName?: string;
  coCode?: string;
  action: string;
  path: string;
  status: number;
}

export type AuditWriteResult = { logged: true } | { logged: false; error: 'audit-write-failed' };

export async function logAudit(
  prisma: any,
  tenantId: string,
  entry: AuditEntry,
): Promise<AuditWriteResult> {
  try {
    await withTenant(prisma, tenantId, (tx: any) =>
      tx.$executeRawUnsafe(
        `INSERT INTO "audit_log"(login_name,co_code,action,path,status) VALUES ($1,$2,$3,$4,$5)`,
        entry.loginName ?? null,
        entry.coCode ?? null,
        entry.action,
        entry.path.slice(0, 255),
        entry.status,
      ),
    );
    return { logged: true };
  } catch {
    return { logged: false, error: 'audit-write-failed' };
  }
}

export async function listAudit(
  prisma: any,
  tenantId: string,
  limit = 200,
): Promise<Record<string, unknown>[]> {
  const n = Math.min(Number(limit) || 200, 500);
  return withTenant(prisma, tenantId, (tx: any) =>
    tx.$queryRawUnsafe(
      `SELECT to_char(ts,'YYYY-MM-DD HH24:MI:SS') AS ts, login_name AS "user", co_code AS company, action, path, status
       FROM "audit_log" ORDER BY id DESC LIMIT ${n}`,
    ),
  );
}
