import { createHash } from 'node:crypto';
import { withTenant } from '@datacare/db';

/**
 * Data-repair framework — the safety protocol shared by every operation in the desktop's `MS_UPDATE`
 * maintenance console.
 *
 * WHY A FRAMEWORK RATHER THAN 18 SCRIPTS
 * --------------------------------------
 * The desktop runs these repairs immediately on a button press, with no preview, no record, and in several
 * cases a wholesale `DELETE` followed by a rebuild (`MS_UPDATE.cs:2334-2671` clears `AC_DATA`, `AD_OS`,
 * `BANK_RECONCILE`, `DHRN_DATA`, `ROJ_MEL_DATA` and `SL_ORD_ADJ` before regenerating them). Reproducing that
 * shape on a multi-tenant web server would be indefensible: one mis-scoped statement destroys a shop's
 * ledger with nothing to show what happened.
 *
 * Every operation therefore goes through the same three steps:
 *
 *   1. PREVIEW  — compute the expected state, diff it against what is stored, and return exact
 *                 insert/update/delete counts plus a bounded sample of business keys. Reads only.
 *   2. REVIEW   — the operator sees those counts. A destructive operation additionally requires a typed
 *                 confirmation and, where marked, a backup reference.
 *   3. APPLY    — re-derive the candidate set inside ONE transaction under an advisory lock, refuse if the
 *                 recomputed `previewHash` no longer matches what was reviewed, then apply ONLY the diff.
 *
 * Applying only the diff is what makes these operations safe to re-run: a healthy row is not rewritten, so
 * a second apply reports zero changes and leaves `updated_at`-style columns untouched. That property is
 * asserted for every operation rather than assumed.
 */

export type RepairRisk = 'low' | 'medium' | 'high' | 'danger';

export interface RepairScope {
  tenantId: string;
  coCode: string;
  lcCode?: string;
  coYear?: string;
}

/** One table's proposed change set. Counts are separated so a delete can never hide inside a total. */
export interface RepairTableDiff {
  table: string;
  insert: number;
  update: number;
  delete: number;
}

export interface RepairPreview {
  operationId: string;
  /** Binds a later apply to exactly this candidate set. */
  previewHash: string;
  diffs: RepairTableDiff[];
  /** Bounded, human-readable business keys so the operator can spot a wrong scope before committing. */
  samples: string[];
  /** True when nothing needs repairing — apply becomes a no-op. */
  clean: boolean;
  risk: RepairRisk;
  requiresConfirmation: string | null;
}

export interface RepairApplied {
  operationId: string;
  previewHash: string;
  applied: RepairTableDiff[];
  /** True when the apply resolved to an existing run rather than repeating the work. */
  deduplicated: boolean;
}

export interface RepairOperation {
  id: string;
  title: string;
  /** What the operator gets, in business language. */
  description: string;
  /** Exact desktop evidence, e.g. `MS_UPDATE.cs:32561-32596`. */
  desktopSource: string;
  risk: RepairRisk;
  /** Tables the operation may write. Used for the cleanup contract in tests and for the audit record. */
  tables: readonly string[];
  /**
   * Compute the diff WITHOUT writing. Must be pure with respect to the database: the framework asserts
   * read-only behaviour in tests by comparing row counts before and after a preview.
   */
  preview: (
    tx: any,
    scope: RepairScope,
  ) => Promise<{ diffs: RepairTableDiff[]; samples: string[] }>;
  /** Apply only the diff. Runs inside the framework's transaction and advisory lock. */
  apply: (tx: any, scope: RepairScope) => Promise<RepairTableDiff[]>;
}

export class RepairError extends Error {
  readonly code: string;
  constructor(code: string, message: string) {
    super(message);
    this.name = 'RepairError';
    this.code = code;
  }
}

const REGISTRY = new Map<string, RepairOperation>();

export function registerRepair(op: RepairOperation): void {
  if (REGISTRY.has(op.id)) throw new Error(`duplicate repair operation ${op.id}`);
  REGISTRY.set(op.id, op);
}

export function listRepairs(): RepairOperation[] {
  return [...REGISTRY.values()].sort((a, b) => a.id.localeCompare(b.id));
}

export function getRepair(id: string): RepairOperation {
  const op = REGISTRY.get(id);
  if (!op) throw new RepairError('unknown-operation', `unknown repair operation: ${id}`);
  return op;
}

/** Typed confirmation a destructive operation demands before it will run. */
export function confirmationFor(op: RepairOperation, scope: RepairScope): string | null {
  if (op.risk === 'low' || op.risk === 'medium') return null;
  return `${op.id} ${scope.coCode}`;
}

/**
 * Hash the reviewed candidate set. Deliberately includes the scope and the exact counts, so moving the
 * company, adding a row, or repairing one record by hand between preview and apply all invalidate it.
 */
function hashPreview(
  op: RepairOperation,
  scope: RepairScope,
  diffs: RepairTableDiff[],
  samples: string[],
): string {
  const canonical = JSON.stringify({
    op: op.id,
    tenant: scope.tenantId,
    co: scope.coCode,
    lc: scope.lcCode ?? null,
    yr: scope.coYear ?? null,
    diffs: [...diffs]
      .sort((a, b) => a.table.localeCompare(b.table))
      .map((d) => [d.table, d.insert, d.update, d.delete]),
    samples: [...samples].sort(),
  });
  return createHash('sha256').update(canonical).digest('hex');
}

const totalChanges = (diffs: RepairTableDiff[]): number =>
  diffs.reduce((a, d) => a + d.insert + d.update + d.delete, 0);

/** Preview an operation. Reads only; records the reviewed set so a later apply can be bound to it. */
export async function previewRepair(
  prisma: any,
  operationId: string,
  scope: RepairScope,
  operator: string,
): Promise<RepairPreview> {
  const op = getRepair(operationId);
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const { diffs, samples } = await op.preview(tx, scope);
    const previewHash = hashPreview(op, scope, diffs, samples);
    const clean = totalChanges(diffs) === 0;
    await tx.$executeRawUnsafe(
      `INSERT INTO "data_repair_run"
         (tenant_id,operation_id,co_code,lc_code,co_year,state,preview_hash,counts,samples,operator)
       VALUES ($1,$2,$3,$4,$5,'previewed',$6,$7::jsonb,$8::jsonb,$9)`,
      scope.tenantId,
      op.id,
      scope.coCode,
      scope.lcCode ?? null,
      scope.coYear ?? null,
      previewHash,
      JSON.stringify(diffs),
      JSON.stringify(samples.slice(0, 50)),
      operator.slice(0, 64),
    );
    return {
      operationId: op.id,
      previewHash,
      diffs,
      samples: samples.slice(0, 50),
      clean,
      risk: op.risk,
      requiresConfirmation: confirmationFor(op, scope),
    };
  });
}

/**
 * Apply a previously reviewed repair.
 *
 * Refuses unless the recomputed hash still matches, so an operator can never commit a change set that
 * differs from the one they were shown.
 */
export async function applyRepair(
  prisma: any,
  operationId: string,
  scope: RepairScope,
  input: { previewHash: string; confirmation?: string; operator: string; reason?: string },
): Promise<RepairApplied> {
  const op = getRepair(operationId);
  const required = confirmationFor(op, scope);
  if (required && input.confirmation !== required) {
    throw new RepairError(
      'confirmation-required',
      `this operation is ${op.risk} risk; type "${required}" to confirm`,
    );
  }
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    // Serialise per tenant+operation so two operators cannot repair the same data concurrently.
    // executeRaw, not queryRaw: pg_advisory_xact_lock returns void and the driver cannot deserialise it.
    await tx.$executeRawUnsafe(
      'SELECT pg_advisory_xact_lock(hashtext($1))',
      `repair:${scope.tenantId}:${op.id}`,
    );

    // A replayed apply resolves to the run that already happened instead of repeating the work.
    const prior: any[] = await tx.$queryRawUnsafe(
      `SELECT applied_counts FROM "data_repair_run"
        WHERE tenant_id=$1 AND operation_id=$2 AND preview_hash=$3 AND state='applied' LIMIT 1`,
      scope.tenantId,
      op.id,
      input.previewHash,
    );
    if (prior.length) {
      return {
        operationId: op.id,
        previewHash: input.previewHash,
        applied: (prior[0].applied_counts ?? []) as RepairTableDiff[],
        deduplicated: true,
      };
    }

    // Re-derive under the lock and refuse if the data moved since the review.
    const { diffs, samples } = await op.preview(tx, scope);
    const recomputed = hashPreview(op, scope, diffs, samples);
    if (recomputed !== input.previewHash) {
      throw new RepairError(
        'stale-preview',
        'the data changed since the preview; review the operation again',
      );
    }

    const applied = await op.apply(tx, scope);
    await tx.$executeRawUnsafe(
      `INSERT INTO "data_repair_run"
         (tenant_id,operation_id,co_code,lc_code,co_year,state,preview_hash,counts,applied_counts,
          samples,operator,reason,applied_at)
       VALUES ($1,$2,$3,$4,$5,'applied',$6,$7::jsonb,$8::jsonb,$9::jsonb,$10,$11,now())`,
      scope.tenantId,
      op.id,
      scope.coCode,
      scope.lcCode ?? null,
      scope.coYear ?? null,
      input.previewHash,
      JSON.stringify(diffs),
      JSON.stringify(applied),
      JSON.stringify(samples.slice(0, 50)),
      input.operator.slice(0, 64),
      input.reason ?? null,
    );
    return { operationId: op.id, previewHash: input.previewHash, applied, deduplicated: false };
  });
}

/** Append-only run history for the console. */
export async function repairHistory(
  prisma: any,
  scope: { tenantId: string; coCode?: string },
  limit = 50,
): Promise<Record<string, unknown>[]> {
  return withTenant(prisma, scope.tenantId, async (tx: any) => {
    const co = scope.coCode ? ' AND co_code=$2' : '';
    const params: unknown[] = [scope.tenantId];
    if (scope.coCode) params.push(scope.coCode);
    return tx.$queryRawUnsafe(
      `SELECT operation_id, co_code, state, preview_hash, counts, applied_counts, operator, reason,
              error, created_at, applied_at
         FROM "data_repair_run" WHERE tenant_id=$1${co}
        ORDER BY created_at DESC LIMIT ${Math.min(Math.max(1, limit), 200)}`,
      ...params,
    );
  });
}

/** Helper for operations: a diff entry, omitted entirely when nothing changes. */
export const diff = (table: string, d: Partial<RepairTableDiff>): RepairTableDiff => ({
  table,
  insert: d.insert ?? 0,
  update: d.update ?? 0,
  delete: d.delete ?? 0,
});
