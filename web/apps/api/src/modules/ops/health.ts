import { withTenant } from '@datacare/db';
import { playwrightRendererReadiness, type PdfRendererReadiness } from '../reports/render.js';

/** Operational liveness and dependency/security readiness. */

export interface HealthPayload {
  status: 'ok';
  service: string;
  version: string;
  uptimeSec: number;
  ts: string;
}

export function healthPayload(
  now: number = Date.now(),
  startedAt: number = 0,
  version = process.env.APP_VERSION ?? '0.0.0',
): HealthPayload {
  return {
    status: 'ok',
    service: 'datacare-api',
    version,
    uptimeSec: startedAt ? Math.max(0, Math.round((now - startedAt) / 1000)) : 0,
    ts: new Date(now).toISOString(),
  };
}

export interface Readiness {
  ready: boolean;
  db: 'up' | 'down';
  role: {
    name?: string;
    superuser: boolean;
    bypassRls: boolean;
    safe: boolean;
  };
  rls: {
    tenantTables: number;
    protectedTables: number;
    safe: boolean;
  };
  renderer: PdfRendererReadiness;
  error?: string;
}

const asBool = (value: unknown): boolean =>
  value === true || String(value ?? '').toLowerCase() === 'true' || value === 't';
const asNumber = (value: unknown): number => Number(value ?? 0);

export type PdfRendererProbe = () => Promise<PdfRendererReadiness>;

/**
 * Readiness proves more than connectivity: the runtime role must not bypass RLS, every
 * public table carrying tenant_id must have ENABLE+FORCE RLS, and Chromium must launch.
 */
export async function readiness(
  prisma: any,
  tenantId = 'readiness',
  rendererProbe: PdfRendererProbe = playwrightRendererReadiness,
): Promise<Readiness> {
  let renderer: PdfRendererReadiness;
  try {
    renderer = await rendererProbe();
  } catch {
    renderer = {
      available: false,
      engine: 'playwright-chromium',
      error: 'chromium-unavailable',
    };
  }

  try {
    const result = await withTenant(prisma, tenantId, async (tx: any) => {
      const ping: any[] = await tx.$queryRawUnsafe('SELECT 1 AS ok');
      const roles: any[] = await tx.$queryRawUnsafe(
        `SELECT current_user AS name, r.rolsuper, r.rolbypassrls
         FROM pg_roles r WHERE r.rolname = current_user`,
      );
      const policies: any[] = await tx.$queryRawUnsafe(
        `SELECT COUNT(*)::int AS tenant_tables,
                COUNT(*) FILTER (WHERE c.relrowsecurity AND c.relforcerowsecurity)::int AS protected_tables
         FROM pg_class c
         JOIN pg_namespace n ON n.oid = c.relnamespace
         WHERE n.nspname = 'public'
           AND c.relkind IN ('r','p')
           AND EXISTS (
             SELECT 1 FROM pg_attribute a
             WHERE a.attrelid = c.oid AND a.attname = 'tenant_id' AND NOT a.attisdropped
           )`,
      );
      return { ping, role: roles[0] ?? {}, policy: policies[0] ?? {} };
    });

    const superuser = asBool(result.role.rolsuper);
    const bypassRls = asBool(result.role.rolbypassrls);
    const roleSafe = Boolean(result.role.name) && !superuser && !bypassRls;
    const tenantTables = asNumber(result.policy.tenant_tables);
    const protectedTables = asNumber(result.policy.protected_tables);
    const rlsSafe = tenantTables > 0 && protectedTables === tenantTables;
    const dbUp = Array.isArray(result.ping) && asNumber(result.ping[0]?.ok) === 1;

    return {
      ready: dbUp && roleSafe && rlsSafe && renderer.available,
      db: dbUp ? 'up' : 'down',
      role: { name: result.role.name, superuser, bypassRls, safe: roleSafe },
      rls: { tenantTables, protectedTables, safe: rlsSafe },
      renderer,
    };
  } catch {
    return {
      ready: false,
      db: 'down',
      role: { superuser: false, bypassRls: false, safe: false },
      rls: { tenantTables: 0, protectedTables: 0, safe: false },
      renderer,
      error: 'database-readiness-check-failed',
    };
  }
}
