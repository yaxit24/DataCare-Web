import { createHash } from 'node:crypto';
import type {
  FastifyInstance,
  FastifyReply,
  FastifyRequest,
  onSendHookHandler,
  RouteHandlerMethod,
} from 'fastify';
import { withTxBudget, type TxBudgetPrisma } from './txBudget.js';
import { runWithCommand, type IdempotentCommand } from './idempotencyContext.js';

/**
 * Idempotent voucher creates (N52, G29, decision D18; LITE-MASTER-PLAN WP-04).
 *
 * A voucher page sends `Idempotency-Key: <uuid>` with its create, made when the form opens and renewed after a
 * successful save. For a guarded route the API keeps one receipt per (tenant, key) in `api_command_receipt`,
 * written in the voucher's own transaction (`idempotencyContext.ts`, hooked into `withTxBudget`):
 *
 *  - the same key with the same request answers the stored status and body again, with
 *    `Idempotency-Replayed: true`, and writes nothing;
 *  - the same key with a different request (another body, user, company, location, year or route) answers
 *    `409 idempotency-key-reused` (the error taxonomy in docs/handbook/web/engineering-standards.md §3 and D18);
 *  - a request without the header behaves as before, so an older page keeps working; the route-policy test
 *    (`test/idempotencyRoutePolicy.test.ts`) requires the pages of guarded routes to send it;
 *  - a failed save rolls its receipt back with the voucher, so a corrected retry with the same key is a new save.
 *
 * Receipts expire after the retention (D18: 30 days unless the finance owner sets another;
 * `DATACARE_IDEMPOTENCY_RETENTION_HOURS`). `purgeExpiredCommandReceipts` deletes them; a guarded request runs it
 * for its tenant at most once an hour. An expired key is free again.
 *
 * The desktop has no equivalent: its Save is a local button press, never a retried HTTP request.
 */
export interface IdempotentRoute {
  readonly method: 'POST';
  /** The literal route path, exactly as registered. */
  readonly url: string;
  /** The status the route answers on success. */
  readonly status: number;
  /** The desktop menu(s) the route serves. */
  readonly menus: readonly string[];
}

/** Every voucher create guarded so far. Literal paths: the route-policy test matches them to registrations. */
export const IDEMPOTENT_CREATE_ROUTES: readonly IdempotentRoute[] = Object.freeze([
  { method: 'POST', url: '/stock/stock-adjust', status: 201, menus: ['Other/Stock Adjust'] },
  { method: 'POST', url: '/stock/tag-cancel', status: 201, menus: ['Other/Tag Cancel'] },
  {
    method: 'POST',
    url: '/receipts',
    status: 201,
    menus: ['Transaction/Cash Received', 'Transaction/Bank Received'],
  },
  {
    method: 'POST',
    url: '/receipts/multi',
    status: 201,
    menus: ['Transaction/Cash Received', 'Transaction/Bank Received'],
  },
  {
    method: 'POST',
    url: '/payments',
    status: 201,
    menus: ['Transaction/Cash Payment', 'Transaction/Bank Payment'],
  },
  {
    method: 'POST',
    url: '/payments/multi',
    status: 201,
    menus: ['Transaction/Cash Payment', 'Transaction/Bank Payment'],
  },
]);

export const IDEMPOTENCY_KEY_HEADER = 'idempotency-key';
export const IDEMPOTENCY_REPLAYED_HEADER = 'Idempotency-Replayed';
const DEFAULT_RETENTION_HOURS = 30 * 24;
const PURGE_INTERVAL_MS = 60 * 60 * 1000;

export class IdempotencyConfigurationError extends Error {
  constructor(message: string) {
    super(message);
    this.name = 'IdempotencyConfigurationError';
  }
}

/** Receipt retention in hours: D18's 30 days, or a validated operator setting (1 hour to 400 days). */
export function idempotencyRetentionHours(): number {
  const raw = process.env.DATACARE_IDEMPOTENCY_RETENTION_HOURS?.trim();
  if (!raw) return DEFAULT_RETENTION_HOURS;
  const hours = Number(raw);
  if (!/^\d+$/.test(raw) || hours < 1 || hours > 9600)
    throw new IdempotencyConfigurationError(
      'DATACARE_IDEMPOTENCY_RETENTION_HOURS must be a whole number of hours from 1 to 9600',
    );
  return hours;
}

/** The header's key, or null when it is not 1-128 visible ASCII characters (RFC 9110 field value, no spaces). */
export function parseIdempotencyKey(value: string | string[] | undefined): string | null {
  if (typeof value !== 'string') return null;
  return /^[\x21-\x7e]{1,128}$/.test(value) ? value : null;
}

/** JSON with every object's keys sorted, so the same request always hashes the same. */
export function canonicalJson(value: unknown): string {
  if (value === null || typeof value !== 'object') return JSON.stringify(value) ?? 'null';
  if (Array.isArray(value)) return `[${value.map(canonicalJson).join(',')}]`;
  const entries = Object.entries(value as Record<string, unknown>)
    .filter(([, v]) => v !== undefined)
    .sort(([a], [b]) => (a < b ? -1 : a > b ? 1 : 0));
  return `{${entries.map(([k, v]) => `${JSON.stringify(k)}:${canonicalJson(v)}`).join(',')}}`;
}

export interface CommandIdentity {
  readonly method: string;
  readonly route: string;
  readonly actor: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear?: string;
  readonly body: unknown;
}

/** sha256 of the request as the server will execute it: route, signed-in user, session scope and body. */
export function requestSha256(identity: CommandIdentity): string {
  return createHash('sha256')
    .update(
      canonicalJson({
        method: identity.method,
        route: identity.route,
        actor: identity.actor,
        scope: [identity.coCode, identity.lcCode, identity.coYear ?? ''],
        body: identity.body ?? null,
      }),
    )
    .digest('hex');
}

interface StoredReceipt {
  request_sha256: string;
  response_status: number;
  response_body: string | null;
}

async function readReceipt(
  prisma: TxBudgetPrisma,
  command: IdempotentCommand,
): Promise<StoredReceipt | undefined> {
  const rows = await withTxBudget(
    prisma,
    command.tenantId,
    'read',
    (tx) =>
      tx.$queryRaw<StoredReceipt[]>`
      SELECT request_sha256, response_status, response_body::text AS response_body
        FROM "api_command_receipt"
       WHERE tenant_id = ${command.tenantId} AND idempotency_key = ${command.key}
         AND expires_at > now()`,
  );
  return rows[0];
}

const KEY_REUSED = {
  error: 'idempotency-key-reused',
  message: 'This Idempotency-Key was already used for a different request; nothing was saved.',
};

/** The stored answer for a key: the original response, or 409 when the key belongs to another request. */
function storedAnswer(
  command: IdempotentCommand,
  stored: StoredReceipt,
): { status: number; body: string; replayed: boolean } {
  if (stored.request_sha256 !== command.requestSha256 || stored.response_body === null)
    return { status: 409, body: JSON.stringify(KEY_REUSED), replayed: false };
  return { status: stored.response_status, body: stored.response_body, replayed: true };
}

function send(reply: FastifyReply, answer: ReturnType<typeof storedAnswer>): FastifyReply {
  if (answer.replayed) reply.header(IDEMPOTENCY_REPLAYED_HEADER, 'true');
  return reply.code(answer.status).type('application/json; charset=utf-8').send(answer.body);
}

/** Delete one tenant's expired receipts; returns how many. */
export async function purgeExpiredCommandReceipts(
  prisma: TxBudgetPrisma,
  tenantId: string,
): Promise<number> {
  return withTxBudget(
    prisma,
    tenantId,
    'voucher',
    (tx) =>
      tx.$executeRaw`
      DELETE FROM "api_command_receipt" WHERE tenant_id = ${tenantId} AND expires_at <= now()`,
  );
}

export interface IdempotencyDependencies {
  /** The signed-in session, once authentication ran; undefined otherwise. */
  session(
    req: FastifyRequest,
  ): { tenantId: string; sub: string; coCode: string; lcCode: string; coYear?: string } | undefined;
  /** True when the route's rights check passed (the handler refuses otherwise). */
  authorized(req: FastifyRequest): boolean;
}

const guardedByApp = new WeakMap<FastifyInstance, Set<string>>();

/** `METHOD /path` of every route this app wrapped with the guard (read by the route-policy test). */
export function idempotencyGuardedRoutes(app: FastifyInstance): ReadonlySet<string> {
  return guardedByApp.get(app) ?? new Set();
}

/**
 * Wrap every route of `IDEMPOTENT_CREATE_ROUTES` as it is registered. Call before the routes are registered and
 * after the authentication preHandler is added, so the guard runs after authentication, scope and rights.
 */
export function registerIdempotency(
  app: FastifyInstance,
  prisma: TxBudgetPrisma,
  deps: IdempotencyDependencies,
): void {
  const specs = new Map(
    IDEMPOTENT_CREATE_ROUTES.map((spec) => [`${spec.method} ${spec.url}`, spec]),
  );
  const guarded = new Set<string>();
  guardedByApp.set(app, guarded);
  const pending = new WeakMap<FastifyRequest, IdempotentCommand>();
  const lastPurge = new Map<string, number>();

  const purgeIfDue = async (req: FastifyRequest, tenantId: string) => {
    const now = Date.now();
    if (now - (lastPurge.get(tenantId) ?? 0) < PURGE_INTERVAL_MS) return;
    lastPurge.set(tenantId, now);
    try {
      await purgeExpiredCommandReceipts(prisma, tenantId);
    } catch (error) {
      req.log.warn({ err: error }, 'idempotency receipt purge failed');
    }
  };

  // Runs before the response leaves. Closes the command, so the audit write after it can never claim; answers a
  // duplicate that lost the race from the winner's receipt; and keeps the stored body equal to what was sent.
  const onSend: onSendHookHandler = async (req, reply, payload) => {
    const command = pending.get(req);
    if (!command) return payload;
    pending.delete(req);
    command.closed = true;
    if (command.conflict) {
      const stored = await readReceipt(prisma, command);
      if (!stored) return payload;
      const answer = storedAnswer(command, stored);
      if (answer.replayed) reply.header(IDEMPOTENCY_REPLAYED_HEADER, 'true');
      reply.code(answer.status).type('application/json; charset=utf-8');
      return answer.body;
    }
    if (
      command.committed &&
      typeof payload === 'string' &&
      reply.statusCode === command.status &&
      payload !== command.body
    ) {
      // The route reshaped the writer's result after its transaction; store what the client actually got.
      await withTxBudget(
        prisma,
        command.tenantId,
        'voucher',
        (tx) =>
          tx.$executeRaw`
          UPDATE "api_command_receipt" SET response_body = ${payload}::json
           WHERE tenant_id = ${command.tenantId} AND idempotency_key = ${command.key}`,
      );
    }
    return payload;
  };

  app.addHook('onRoute', (routeOptions) => {
    const methods = Array.isArray(routeOptions.method)
      ? routeOptions.method
      : [routeOptions.method];
    const spec = methods.map((method) => specs.get(`${method} ${routeOptions.url}`)).find(Boolean);
    if (!spec) return;
    const original = routeOptions.handler as RouteHandlerMethod;
    const handler = async function idempotentCreate(
      this: FastifyInstance,
      req: FastifyRequest,
      reply: FastifyReply,
    ) {
      const header = req.headers[IDEMPOTENCY_KEY_HEADER];
      const session = deps.session(req);
      if (header === undefined || !session || !deps.authorized(req))
        return original.call(this, req, reply);
      const key = parseIdempotencyKey(header);
      if (!key)
        return reply.code(400).send({
          error: 'invalid-idempotency-key',
          message: 'Idempotency-Key must be 1 to 128 visible ASCII characters',
        });
      const command: IdempotentCommand = {
        tenantId: session.tenantId,
        key,
        method: spec.method,
        route: spec.url,
        requestSha256: requestSha256({
          method: spec.method,
          route: spec.url,
          actor: session.sub,
          coCode: session.coCode,
          lcCode: session.lcCode,
          coYear: session.coYear,
          body: req.body,
        }),
        actor: session.sub,
        status: spec.status,
        retentionHours: idempotencyRetentionHours(),
        claimed: false,
        committed: false,
        conflict: false,
        closed: false,
      };
      await purgeIfDue(req, session.tenantId);
      const stored = await readReceipt(prisma, command);
      if (stored) return send(reply, storedAnswer(command, stored));
      pending.set(req, command);
      try {
        return await runWithCommand(command, () => original.call(this, req, reply));
      } catch (error) {
        // A duplicate that lost the race: answer from the winner's receipt instead of the claim error.
        if (command.conflict && !reply.sent) {
          pending.delete(req);
          command.closed = true;
          const winner = await readReceipt(prisma, command);
          if (winner) return send(reply, storedAnswer(command, winner));
        }
        throw error;
      } finally {
        command.closed = true;
      }
    };
    routeOptions.handler = handler;
    const existing = routeOptions.onSend;
    routeOptions.onSend = [
      ...(existing === undefined ? [] : Array.isArray(existing) ? existing : [existing]),
      onSend,
    ];
    for (const method of methods) guarded.add(`${method} ${routeOptions.url}`);
  });
}
