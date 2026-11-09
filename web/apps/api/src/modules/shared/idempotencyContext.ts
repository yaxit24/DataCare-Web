import { AsyncLocalStorage } from 'node:async_hooks';
import type { Tx } from '@datacare/db';

/**
 * The transaction half of idempotent voucher creates (N52, G29, decision D18).
 *
 * `idempotency.ts` runs a guarded route's handler inside `runWithCommand`. The first non-read transaction that
 * handler opens for the same tenant (`withTxBudget` asks `commandForTransaction`) becomes the command's
 * transaction: its first statement claims the receipt row and its last statement stores the response. Both are
 * therefore committed or rolled back together with the voucher, so a receipt never exists without its voucher
 * and a voucher created under a key never exists without its receipt.
 *
 * Why the claim comes first: a concurrent duplicate (two tabs, a proxy retry racing the original) blocks on the
 * receipt's primary key at its first statement, before it takes a voucher number. When the original commits,
 * the duplicate's claim finds the row, stops, and the route answers it with the stored response.
 *
 * This file imports nothing from `txBudget.ts`, which imports it.
 */
export interface IdempotentCommand {
  readonly tenantId: string;
  readonly key: string;
  readonly method: string;
  readonly route: string;
  readonly requestSha256: string;
  readonly actor: string;
  /** The status the route answers on success; the replay answers the same. */
  readonly status: number;
  readonly retentionHours: number;
  /** A transaction has claimed the receipt and has not rolled back. */
  claimed: boolean;
  /** The claiming transaction committed: the voucher and its receipt exist. */
  committed: boolean;
  /** The claim met an existing live receipt (a concurrent or earlier request with this key). */
  conflict: boolean;
  /** The response is being sent: no later transaction (audit, metrics) may claim. */
  closed: boolean;
  /** The JSON stored as the response body, once the claiming transaction wrote it. */
  body?: string;
}

/** The claim met a live receipt with this key. The route answers from that receipt (replay or 409). */
export class IdempotencyKeyClaimedError extends Error {
  readonly code = 'idempotency-key-claimed';
  constructor() {
    super('another request with this Idempotency-Key was saved first');
    this.name = 'IdempotencyKeyClaimedError';
  }
}

const commands = new AsyncLocalStorage<IdempotentCommand>();

/** Run a guarded handler with its command visible to every transaction it opens. */
export function runWithCommand<T>(command: IdempotentCommand, fn: () => T): T {
  return commands.run(command, fn);
}

/**
 * The command a new transaction must claim for, or undefined. Only a non-read transaction of the same tenant,
 * while the handler is still running and no other transaction holds the claim. Marks the claim synchronously,
 * so two transactions started together cannot both claim.
 */
export function commandForTransaction(
  tenantId: string,
  readOnly: boolean,
): IdempotentCommand | undefined {
  if (readOnly) return undefined;
  const command = commands.getStore();
  if (!command || command.tenantId !== tenantId) return undefined;
  if (command.closed || command.claimed || command.committed || command.conflict) return undefined;
  command.claimed = true;
  return command;
}

/** Called by `withTxBudget` after the claiming transaction settled. */
export function settleCommandTransaction(command: IdempotentCommand, committed: boolean): void {
  if (committed) command.committed = true;
  else command.claimed = false; // a rolled-back attempt leaves no receipt; a retry inside the writer may claim
}

/**
 * Insert the receipt, or take over an expired one with the same key. Returns normally only when this
 * transaction now owns the key; otherwise marks the command as a conflict and throws.
 */
export async function claimCommandTx(tx: Tx, command: IdempotentCommand): Promise<void> {
  let rows: Array<{ claimed: number }>;
  try {
    rows = await tx.$queryRaw<Array<{ claimed: number }>>`
      INSERT INTO "api_command_receipt"
        (tenant_id, idempotency_key, route, request_sha256, actor, response_status, expires_at)
      VALUES (${command.tenantId}, ${command.key}, ${command.route}, ${command.requestSha256},
              ${command.actor}, ${command.status}, now() + make_interval(hours => ${command.retentionHours}::int))
      ON CONFLICT (tenant_id, idempotency_key) DO UPDATE
        SET route = EXCLUDED.route,
            request_sha256 = EXCLUDED.request_sha256,
            actor = EXCLUDED.actor,
            response_status = EXCLUDED.response_status,
            response_body = NULL,
            created_at = now(),
            expires_at = EXCLUDED.expires_at
        WHERE "api_command_receipt".expires_at <= now()
      RETURNING 1::int AS claimed`;
  } catch (error) {
    // Under SERIALIZABLE, PostgreSQL reports a receipt committed by a concurrent duplicate as a serialization
    // failure on this statement rather than as a conflict. Either way the key belongs to the other request.
    command.conflict = true;
    throw error;
  }
  if (rows.length !== 1) {
    command.conflict = true;
    throw new IdempotencyKeyClaimedError();
  }
}

/** Store the response body in the claiming transaction, just before it commits. */
export async function completeCommandTx(
  tx: Tx,
  command: IdempotentCommand,
  result: unknown,
): Promise<void> {
  // Fastify serialises a handler's object with JSON.stringify; storing the same text keeps a replay identical.
  const body = JSON.stringify(result) ?? 'null';
  await tx.$executeRaw`
    UPDATE "api_command_receipt" SET response_body = ${body}::json
     WHERE tenant_id = ${command.tenantId} AND idempotency_key = ${command.key}`;
  command.body = body;
}
