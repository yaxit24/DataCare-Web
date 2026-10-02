import { createHash } from 'node:crypto';
import { withTxBudget } from '../shared/txBudget.js';
import { verifyWithMigration } from '../auth/password.js';

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
 *
 * AUTHORITY FOR A DESTRUCTIVE APPLY
 * --------------------------------
 * A preview-hash check answers "is this the change set that was reviewed". It does not answer "is this
 * person allowed to rewrite a shop's ledger right now". Route policy answers the first half by making the
 * console admin-only; this module answers the rest, because a requirement that lives in a route handler is
 * one refactor away from being forgotten:
 *
 *   * a written REASON, so the run ledger says why history was rewritten;
 *   * RE-AUTHENTICATION with the operator's own password, so an unattended session cannot be used;
 *   * a verified BACKUP REFERENCE naming a real, recent `company_backup_run` row for the same company, so
 *     the operation is recoverable rather than merely recorded.
 *
 * These attach to `high` and `danger` operations — the same threshold that already demands a typed
 * confirmation — and are derived from the operation's own risk, never from the caller's request.
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
  /** Everything the apply will demand, so the console can ask for it up front rather than by trial. */
  authority: RepairAuthority;
}

/** What a given operation's apply will require, derived from its risk rather than from the request. */
export interface RepairAuthority {
  /** Typed confirmation string, or null when the operation is not destructive. */
  confirmation: string | null;
  /** A written reason of at least `REPAIR_REASON_MIN_LENGTH` characters. */
  reason: boolean;
  /** The operator's own password, re-entered. */
  reauthentication: boolean;
  /** A `company_backup_run` checksum for this company, no older than `REPAIR_BACKUP_MAX_AGE_MS`. */
  backupReference: boolean;
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
 * A destructive operation is one that rewrites or removes historical business rows rather than correcting a
 * derived value in place. `high` and `danger` are exactly those, which is why they already carry a typed
 * confirmation; the remaining authority requirements attach to the same set so there is one threshold to
 * reason about instead of two.
 */
export function isDestructive(op: RepairOperation): boolean {
  return op.risk === 'high' || op.risk === 'danger';
}

/** Minimum length of the written reason a destructive apply must carry. */
export const REPAIR_REASON_MIN_LENGTH = 12;

/**
 * How recent a company backup must be to cover a destructive repair.
 *
 * A backup older than this may predate the very rows the operation is about to rewrite, so naming it would
 * prove recoverability that does not exist.
 */
export const REPAIR_BACKUP_MAX_AGE_MS = 24 * 60 * 60 * 1000;

/** Everything the apply will demand for this operation, in the shape the console needs. */
export function authorityFor(op: RepairOperation, scope: RepairScope): RepairAuthority {
  const destructive = isDestructive(op);
  return {
    confirmation: confirmationFor(op, scope),
    reason: destructive,
    reauthentication: destructive,
    backupReference: destructive,
  };
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
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
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
      authority: authorityFor(op, scope),
    };
  });
}

/** Input for an apply. The destructive fields are required only for `high`/`danger` operations. */
export interface RepairApplyInput {
  previewHash: string;
  confirmation?: string;
  operator: string;
  /** Company the operator's `LOGIN_MAST` row belongs to; defaults to the repaired company. */
  loginCoCode?: string;
  reason?: string;
  /** The operator's own password, re-entered for a destructive apply. */
  operatorPassword?: string;
  /** `company_backup_run.checksum` proving a recent restorable backup of this company exists. */
  backupReference?: string;
}

/**
 * Re-prove the operator's identity from `LOGIN_MAST`.
 *
 * Session possession is not enough for an operation that rewrites history: the desktop console sat on a shop
 * counter and the web session can be left open on one. Legacy plaintext passwords are accepted through the
 * same migration path login uses, so a shop that has not yet rotated credentials is not locked out of a
 * repair it is entitled to run.
 */
async function requireReauthentication(
  tx: any,
  scope: RepairScope,
  input: RepairApplyInput,
): Promise<void> {
  const candidate = input.operatorPassword ?? '';
  if (!candidate) {
    throw new RepairError(
      'reauthentication-required',
      're-enter your password to apply a destructive repair',
    );
  }
  const rows: Array<{ LOGIN_PWD?: string | null }> = await tx.$queryRawUnsafe(
    `SELECT "LOGIN_PWD" FROM "LOGIN_MAST" WHERE "CO_CODE"=$1 AND "LOGIN_NAME"=$2 LIMIT 1`,
    input.loginCoCode ?? scope.coCode,
    input.operator,
  );
  const stored = rows[0]?.LOGIN_PWD;
  // A missing login row fails exactly like a wrong password: the caller learns nothing about which it was.
  const ok = stored ? (await verifyWithMigration(String(stored), candidate)).ok : false;
  if (!ok) {
    throw new RepairError(
      'reauthentication-failed',
      'password does not match the applying operator',
    );
  }
}

/**
 * Require a real, recent backup of the company being repaired.
 *
 * The reference is checked against `company_backup_run`, which `backupCompany` writes append-only. An
 * operator therefore cannot satisfy this by typing a plausible string, and an old backup cannot be reused to
 * cover rows created after it.
 */
async function requireBackupReference(
  tx: any,
  scope: RepairScope,
  input: RepairApplyInput,
): Promise<void> {
  const reference = (input.backupReference ?? '').trim();
  if (!reference) {
    throw new RepairError(
      'backup-reference-required',
      'take a company backup and supply its checksum before applying a destructive repair',
    );
  }
  const rows: Array<{ generated_at: Date | string }> = await tx.$queryRawUnsafe(
    `SELECT "generated_at" FROM "company_backup_run"
      WHERE tenant_id=$1 AND co_code=$2 AND checksum=$3
      ORDER BY "generated_at" DESC LIMIT 1`,
    scope.tenantId,
    scope.coCode,
    reference,
  );
  if (!rows.length) {
    throw new RepairError(
      'backup-reference-unknown',
      'no backup of this company matches that checksum',
    );
  }
  const generatedAt = new Date(rows[0]!.generated_at as string).getTime();
  if (!Number.isFinite(generatedAt) || Date.now() - generatedAt > REPAIR_BACKUP_MAX_AGE_MS) {
    throw new RepairError(
      'backup-reference-stale',
      'that backup is too old to cover this repair; take a fresh one',
    );
  }
}

/**
 * Apply a previously reviewed repair.
 *
 * Refuses unless the recomputed hash still matches, so an operator can never commit a change set that
 * differs from the one they were shown. A destructive operation must additionally satisfy every requirement
 * in `authorityFor`, all of which are checked before the first write.
 */
export async function applyRepair(
  prisma: any,
  operationId: string,
  scope: RepairScope,
  input: RepairApplyInput,
): Promise<RepairApplied> {
  const op = getRepair(operationId);
  const authority = authorityFor(op, scope);
  if (authority.confirmation && input.confirmation !== authority.confirmation) {
    throw new RepairError(
      'confirmation-required',
      `this operation is ${op.risk} risk; type "${authority.confirmation}" to confirm`,
    );
  }
  const reason = (input.reason ?? '').trim();
  if (authority.reason && reason.length < REPAIR_REASON_MIN_LENGTH) {
    throw new RepairError(
      'reason-required',
      `record why this repair is being applied (at least ${REPAIR_REASON_MIN_LENGTH} characters)`,
    );
  }
  return withTxBudget(prisma, scope.tenantId, 'heavy', async (tx: any) => {
    // Authority first: an unauthorised caller must not even hold the operation lock.
    if (authority.reauthentication) await requireReauthentication(tx, scope, input);
    if (authority.backupReference) await requireBackupReference(tx, scope, input);
    const reauthenticatedAt = authority.reauthentication ? new Date() : null;

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
          samples,operator,reason,backup_reference,reauthenticated_at,applied_at)
       VALUES ($1,$2,$3,$4,$5,'applied',$6,$7::jsonb,$8::jsonb,$9::jsonb,$10,$11,$12,$13,now())`,
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
      reason || null,
      (input.backupReference ?? '').trim() || null,
      reauthenticatedAt,
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
  return withTxBudget(prisma, scope.tenantId, 'read', async (tx: any) => {
    const co = scope.coCode ? ' AND co_code=$2' : '';
    const params: unknown[] = [scope.tenantId];
    if (scope.coCode) params.push(scope.coCode);
    return tx.$queryRawUnsafe(
      `SELECT operation_id, co_code, state, preview_hash, counts, applied_counts, operator, reason,
              backup_reference, reauthenticated_at, error, created_at, applied_at
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
