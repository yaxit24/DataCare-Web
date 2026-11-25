import type { FastifyRequest } from 'fastify';

/**
 * The login attempt bucket: the real client (req.ip, resolved through the trusted proxy only) plus the account the
 * attempt is for. Login names are unique per tenant and company (auth.service.ts lookup), so both are in the key:
 * failed attempts against one company's `admin` never limit another company's `admin` behind the same address.
 */
export function loginRateLimitKey(req: FastifyRequest, tenantId: string): string {
  const body = (req.body ?? {}) as { loginName?: unknown; coCode?: unknown };
  const loginName = typeof body.loginName === 'string' ? body.loginName.trim().toLowerCase() : '';
  const coCode = typeof body.coCode === 'string' ? body.coCode.trim() : '';
  return `${req.ip}|${tenantId}|${coCode}|${loginName}`;
}
