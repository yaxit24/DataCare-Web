import { createHash, randomUUID } from 'node:crypto';

const REQUEST_ID = /^[A-Za-z0-9][A-Za-z0-9._:-]{0,127}$/;
const SENSITIVE_KEY =
  /(?:password|passwd|pwd|secret|token|authorization|cookie|session|api[-_]?key)/i;
const PII_KEY = /(?:email|phone|mobile|address|full[-_]?name|first[-_]?name|last[-_]?name)/i;

export function correlationId(value: unknown, generate: () => string = randomUUID): string {
  const candidate = Array.isArray(value) ? value[0] : value;
  const text = typeof candidate === 'string' ? candidate.trim() : '';
  return REQUEST_ID.test(text) ? text : generate();
}

export function safeUserReference(value: unknown): string | undefined {
  const text = String(value ?? '').trim();
  if (!text) return undefined;
  return `sha256:${createHash('sha256').update(text).digest('hex').slice(0, 16)}`;
}

export function redactLogObject(value: unknown, key = ''): unknown {
  if (SENSITIVE_KEY.test(key) || PII_KEY.test(key)) return '[redacted]';
  if (Array.isArray(value)) return value.map((entry) => redactLogObject(entry, key));
  if (value && typeof value === 'object') {
    return Object.fromEntries(
      Object.entries(value as Record<string, unknown>).map(([childKey, childValue]) => [
        childKey,
        redactLogObject(childValue, childKey),
      ]),
    );
  }
  return value;
}

export interface RequestLogInput {
  correlationId: string;
  method: string;
  route: string;
  status: number;
  durationMs: number;
  tenantId?: string;
  companyCode?: string;
  locationCode?: string;
  user?: string;
}

/** Build request-completed fields from an explicit allowlist; headers and bodies are never accepted. */
export function requestCompletedFields(input: RequestLogInput): Record<string, unknown> {
  return redactLogObject({
    event: 'request.completed',
    correlationId: input.correlationId,
    method: input.method,
    route: input.route,
    status: input.status,
    durationMs: Math.max(0, Math.round(input.durationMs * 1000) / 1000),
    tenantId: input.tenantId,
    companyCode: input.companyCode,
    locationCode: input.locationCode,
    user: safeUserReference(input.user),
  }) as Record<string, unknown>;
}
