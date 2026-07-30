/**
 * Minimal health module for the foundation scaffold. NestJS (Fastify adapter) is introduced in
 * Task 10 (auth) and will expose this via a controller. Kept framework-agnostic + unit-tested now.
 */
export interface Health {
  status: 'ok';
  service: string;
  ts: number;
}

export function getHealth(now: () => number = Date.now): Health {
  return { status: 'ok', service: 'datacare-api', ts: now() };
}
