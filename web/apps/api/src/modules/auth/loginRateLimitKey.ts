import type { FastifyRequest } from 'fastify';

export function loginRateLimitKey(req: FastifyRequest): string {
  const body = (req.body ?? {}) as { loginName?: unknown };
  const loginName = typeof body.loginName === 'string' ? body.loginName.trim().toLowerCase() : '';
  return `${req.ip}|${loginName}`;
}
