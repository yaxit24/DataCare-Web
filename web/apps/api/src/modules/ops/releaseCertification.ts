/**
 * Release certification (P0-07 / WP-03).
 *
 * WHAT WENT WRONG WITHOUT THIS
 * ============================
 * Every parity gate in this repository can currently pass without proving anything, and the main CI job is
 * built to stay actionable rather than to certify a release. Measured, not asserted:
 *
 *   * `pnpm g5:parity` runs in the `quality` job under `continue-on-error: true`, so the controlling
 *     desktop comparison cannot fail the build. The retained latest result is `matched: false`.
 *   * `check-schema-readiness`, the ordinary `check-type-parity` mode and `check-fresh-provision` print
 *     `*_SKIP` and exit **0** when required inputs are absent. Release type parity therefore uses its separate
 *     exact-coverage mode, which also rejects readable but incomplete dumps.
 *   * `check-completion-register`, `check-type-parity`, `restore-drill` and the report comparison are not
 *     invoked by CI at all.
 *   * `register:check` defaults to non-strict, which explicitly accepts all 198 entries being
 *     `unclassified`.
 *   * Several gates accept `--write`, which rewrites the very baseline they then compare against.
 *
 * Green therefore means "nothing objected", not "the release is proven". A release gate has to invert that:
 * a gate that did not run, ran on synthetic input, ran on evidence from another commit, or ran a long time
 * ago is treated exactly like a gate that failed.
 *
 * WHY THE LOGIC IS SEPARATE FROM THE RUNNER
 * =========================================
 * The decisions below are pure functions over observations, so they are unit tested against fixtures for
 * every refusal reason. The CLI (`scripts/release-certify.mjs`) only gathers observations — run a command,
 * read a file — and asks this module for the verdict. A certifier whose own rules cannot be tested is
 * another unproven gate.
 *
 * DELIBERATELY ABSENT: any override. There is no `--force`, no allowlist, no environment variable that
 * turns a refusal into a pass. The way to make this green is to produce the evidence.
 */

import { createHash } from 'node:crypto';

/** Why a gate did not certify. `passed` is the only acceptable outcome for a release. */
export type GateOutcome =
  | 'passed'
  /** Ran and reported failure. */
  | 'failed'
  /** Ran, exited 0, and announced it had not measured anything. */
  | 'skipped'
  /** Required evidence artefact absent or unreadable. */
  | 'missing'
  /** Evidence exists and is negative — the comparison did not match. */
  | 'red'
  /** Evidence is too old, undated, future-dated, or belongs to another commit. */
  | 'stale'
  /** Evidence exists but was produced from fabricated or self-generated input. */
  | 'synthetic'
  /** The gate was invoked in a mode that rewrites its own baseline. */
  | 'self-approved'
  /** The runner returned an id that is not in the frozen required gate set. */
  | 'unexpected'
  /** The runner returned the same id more than once. */
  | 'duplicate'
  /** The certification run itself is not set up to judge anything. */
  | 'unconfigured';

/** A gate's evidence artefact and the rules that make it count. */
export interface EvidenceRequirement {
  /**
   * Path relative to the REPOSITORY ROOT — the directory holding both `web/` and `project-memory/`.
   *
   * Gate commands run inside `web/` (that is where the package scripts live) while retained evidence lives in
   * `project-memory/`, one level above. Keeping the two bases explicit here stops the runner from resolving an
   * artefact against the wrong directory and reporting `missing` for a file that exists.
   */
  path: string;
  /** ISO timestamp field that dates the evidence. Absent means the artefact cannot be dated at all. */
  timestampField?: string;
  /**
   * Predicate that must hold for the evidence to be POSITIVE. Returning a reason rather than a boolean so
   * the certification record says which claim failed instead of "predicate false".
   */
  positive?: (json: Record<string, unknown>) => { ok: boolean; reason?: string };
  /**
   * Predicate that must hold for the evidence to be REAL rather than fabricated — a database engine banner,
   * a producer marker, a non-zero denominator.
   */
  provenance?: (json: Record<string, unknown>) => { ok: boolean; reason?: string };
  /**
   * A frozen member universe inside this artefact.
   *
   * This is deliberately configured on the REQUIREMENT, never read from the evidence being judged. Otherwise
   * an incomplete producer could submit both a one-result `reports` array and a one-id "expected" array and
   * certify itself. The member id may be a report/mode/case composite chosen by the owning manifest.
   */
  exactSet?: EvidenceExactSetRequirement;
}

/** Declarative so the complete expected set becomes part of `requirementSetFingerprint`. */
export interface EvidenceExactSetRequirement {
  /** Dotted path to the returned member array, for example `reports` or `suites.results`. */
  collectionPath: string;
  /**
   * Dotted path, relative to one object member, containing its stable identity. Omit this only when each
   * collection member is itself the string identity (for example the parity ratchet's `caseIds`).
   */
  idField?: string;
  /** Independently frozen, non-empty, unique identities required exactly once. */
  requiredIds: readonly string[];
}

export interface GateRequirement {
  id: string;
  title: string;
  /** Why this gate is in the release set. Printed on refusal so the reason is never mysterious. */
  because: string;
  /** Command the runner must execute. Absent means the gate is artefact-only. */
  command?: string;
  /** In-process runner observation that cannot safely be delegated to a shell command. */
  runnerCheck?: 'candidate-identity-postflight';
  evidence?: EvidenceRequirement;
}

/** What the runner observed for one gate. */
export interface GateObservation {
  id: string;
  command?: string;
  exitCode?: number | null;
  stdout?: string;
  stderr?: string;
  artefact?: { path: string; present: boolean; json?: unknown };
}

export interface CertificationContext {
  /** Commit the release is cut from. Evidence must belong to it. */
  releaseSha?: string;
  /**
   * How recent evidence must be. This is an OWNER DECISION (plan §8.1 item 11 / §11.2 "freshness"), so it is
   * required input rather than a default invented here: a certifier that picks its own window is deciding a
   * business question it was not asked.
   */
  freshnessWindowHours?: number;
  /** Owner-reviewed hash of the complete requirement/member universe frozen before execution. */
  approvedRequirementSetHash?: string;
  /** SHA-256 of this decision module's candidate TypeScript source, observed by the runner. */
  certifierSourceSha256?: string;
  /** Candidate requirement hash, supplied during preflight so a known mismatch runs zero gates. */
  actualRequirementSetHash?: string;
  /** Evaluation instant, injected so the rules are testable. */
  now: Date;
}

export interface GateVerdict {
  id: string;
  title: string;
  outcome: GateOutcome;
  reason: string;
}

export interface CertificationRecord {
  kind: 'datacare.release-certification/1.0';
  verdict: 'passed' | 'failed';
  evaluatedAt: string;
  releaseSha: string | null;
  freshnessWindowHours: number | null;
  approvedRequirementSetHash: string | null;
  certifierSourceSha256: string | null;
  gates: GateVerdict[];
  /** Outcome counts, so a summary line does not require re-deriving them. */
  totals: Record<GateOutcome, number>;
  /** Hash of the expected gate universe, so a record is tied to the set it claimed to execute. */
  requirementSetHash: string;
}

/**
 * A gate that announces it measured nothing.
 *
 * The three known emitters spell it `SCHEMA_READINESS_SKIP`, `TYPE_PARITY_SKIP` and `FRESH_PROVISION_SKIP`,
 * all with exit code 0. Matching the shape rather than the three literals means a future gate that follows
 * the same convention is caught the day it is added instead of the day someone remembers to list it.
 */
const SKIP_TOKEN = /\b[A-Z][A-Z0-9]*(?:_[A-Z0-9]+)*_SKIP\b/;

/** Flags that make a gate rewrite the baseline it compares against. */
const SELF_APPROVAL_FLAG = /(^|\s)--write(\s|$)/;

const FORTY_HEX = /^[0-9a-f]{40}$/;
const SIXTY_FOUR_HEX = /^[0-9a-f]{64}$/;

/**
 * Why this certification run cannot judge anything yet.
 *
 * `evaluateGate` enforces these too, so nothing depends on the runner remembering to call this. It exists so
 * the runner can refuse in the first second rather than after spending ten minutes on lint, test and build to
 * reach a verdict that was already determined: an unconfigured run cannot certify, however green the gates.
 */
export function contextProblems(ctx: CertificationContext): string[] {
  const problems: string[] = [];
  const sha = (ctx.releaseSha ?? '').trim().toLowerCase();
  if (!FORTY_HEX.test(sha)) {
    problems.push(
      'RELEASE_SHA must be the exact 40-character commit being certified (e.g. $(git rev-parse HEAD))',
    );
  }
  const window = ctx.freshnessWindowHours;
  if (!(typeof window === 'number' && Number.isFinite(window) && window > 0)) {
    problems.push(
      'RELEASE_EVIDENCE_MAX_AGE_HOURS must be a positive number of hours; it is an owner decision ' +
        '(plan §8.1 item 11) and is deliberately not defaulted',
    );
  }
  const approvedRequirementSetHash = (ctx.approvedRequirementSetHash ?? '').trim().toLowerCase();
  if (!SIXTY_FOUR_HEX.test(approvedRequirementSetHash)) {
    problems.push(
      'RELEASE_REQUIREMENT_SET_SHA256 must be the owner-reviewed 64-character requirement-set digest frozen before execution',
    );
  }
  const certifierSourceSha256 = (ctx.certifierSourceSha256 ?? '').trim().toLowerCase();
  if (!SIXTY_FOUR_HEX.test(certifierSourceSha256)) {
    problems.push(
      'candidate certifier source SHA-256 is unavailable; requirement approval must bind the decision rules as well as gate names',
    );
  }
  const actualRequirementSetHash = (ctx.actualRequirementSetHash ?? '').trim().toLowerCase();
  if (
    SIXTY_FOUR_HEX.test(approvedRequirementSetHash) &&
    SIXTY_FOUR_HEX.test(actualRequirementSetHash) &&
    approvedRequirementSetHash !== actualRequirementSetHash
  ) {
    problems.push(
      `RELEASE_REQUIREMENT_SET_SHA256 ${approvedRequirementSetHash} does not match candidate requirement set ${actualRequirementSetHash}`,
    );
  }
  return problems;
}

/** A clock is never exactly synchronised; more than this into the future is not skew, it is wrong. */
const FUTURE_TOLERANCE_MS = 5 * 60 * 1000;

const asRecord = (value: unknown): Record<string, unknown> | undefined =>
  value && typeof value === 'object' && !Array.isArray(value)
    ? (value as Record<string, unknown>)
    : undefined;

/** Read a dotted path so a requirement can date evidence by `desktop.capturedAt`. */
const readPath = (json: Record<string, unknown>, path: string): unknown =>
  path.split('.').reduce<unknown>((node, key) => asRecord(node)?.[key], json);

const idSummary = (ids: readonly string[]): string => {
  const shown = ids.slice(0, 8).join(', ');
  return ids.length > 8 ? `${shown} (+${ids.length - 8} more)` : shown;
};

const DOTTED_EVIDENCE_PATH = /^[^.\s]+(?:\.[^.\s]+)*$/;

/** Validate an exact-set declaration without trusting its compile-time shape at the JSON boundary. */
function exactSetConfigurationProblems(exact: EvidenceExactSetRequirement): string[] {
  const collectionPath =
    typeof exact.collectionPath === 'string' ? exact.collectionPath.trim() : '';
  const hasIdField = exact.idField !== undefined;
  const idField = typeof exact.idField === 'string' ? exact.idField.trim() : '';
  const rawRequiredIds: readonly unknown[] = Array.isArray(exact.requiredIds)
    ? exact.requiredIds
    : [];
  const validRequiredIds = rawRequiredIds.filter(
    (id): id is string => typeof id === 'string' && id.length > 0 && id === id.trim(),
  );
  const invalidRequired = rawRequiredIds.filter(
    (id) => typeof id !== 'string' || id.length === 0 || id !== id.trim(),
  );
  const requiredCounts = new Map<string, number>();
  for (const id of validRequiredIds) {
    requiredCounts.set(id, (requiredCounts.get(id) ?? 0) + 1);
  }
  const duplicateRequired = [...requiredCounts]
    .filter(([, count]) => count > 1)
    .map(([id]) => id)
    .sort();

  return [
    !DOTTED_EVIDENCE_PATH.test(collectionPath) ? 'collectionPath is invalid' : '',
    hasIdField && !DOTTED_EVIDENCE_PATH.test(idField) ? 'idField is invalid' : '',
    !Array.isArray(exact.requiredIds) ? 'requiredIds is not an array' : '',
    !rawRequiredIds.length ? 'requiredIds is empty' : '',
    invalidRequired.length
      ? `invalid required ids: ${idSummary(invalidRequired.map((id) => String(id)))}`
      : '',
    duplicateRequired.length ? `duplicate required ids: ${idSummary(duplicateRequired)}` : '',
  ].filter(Boolean);
}

/**
 * Compare a returned evidence collection with its independently frozen required identities.
 *
 * Returning a verdict-shaped value keeps this reusable for report modes, browser journeys, devices and the
 * other exact-set families X34 still has to add. Configuration defects are `unconfigured`; malformed or
 * unequal evidence is `red` and reports every class of set defect in one actionable reason.
 */
function exactSetVerdict(
  requirement: GateRequirement,
  json: Record<string, unknown>,
): GateVerdict | undefined {
  const exact = requirement.evidence?.exactSet;
  if (!exact) return undefined;

  const verdict = (outcome: GateOutcome, reason: string): GateVerdict => ({
    id: requirement.id,
    title: requirement.title,
    outcome,
    reason,
  });
  const defects = exactSetConfigurationProblems(exact);
  if (defects.length) {
    return verdict(
      'unconfigured',
      `exact-set requirement for ${requirement.id} is invalid (${defects.join('; ')})`,
    );
  }
  const collectionPath = exact.collectionPath.trim();
  const idField = exact.idField?.trim();
  const requiredIds = exact.requiredIds as readonly string[];

  const rawMembers = readPath(json, collectionPath);
  if (!Array.isArray(rawMembers)) {
    return verdict('red', `exact-set evidence field ${collectionPath} is not an array of results`);
  }

  const returnedIds: string[] = [];
  const invalidMembers: number[] = [];
  rawMembers.forEach((member, index) => {
    const record = idField ? asRecord(member) : undefined;
    const id = idField ? (record ? readPath(record, idField) : undefined) : member;
    if (typeof id !== 'string' || id.length === 0 || id !== id.trim()) {
      invalidMembers.push(index);
      return;
    }
    returnedIds.push(id);
  });

  const returnedCounts = new Map<string, number>();
  for (const id of returnedIds) {
    returnedCounts.set(id, (returnedCounts.get(id) ?? 0) + 1);
  }
  const duplicates = [...returnedCounts]
    .filter(([, count]) => count > 1)
    .map(([id]) => id)
    .sort();
  const returned = new Set(returnedIds);
  const required = new Set(requiredIds);
  const missing = [...required].filter((id) => !returned.has(id)).sort();
  const unexpected = [...returned].filter((id) => !required.has(id)).sort();

  if (invalidMembers.length || duplicates.length || missing.length || unexpected.length) {
    const defects = [
      invalidMembers.length
        ? `members without a valid ${idField ?? 'string identity'}: indexes ${invalidMembers.join(', ')}`
        : '',
      duplicates.length ? `duplicate ids: ${idSummary(duplicates)}` : '',
      missing.length ? `missing ids: ${idSummary(missing)}` : '',
      unexpected.length ? `unexpected ids: ${idSummary(unexpected)}` : '',
    ].filter(Boolean);
    return verdict('red', `exact-set mismatch at ${collectionPath} (${defects.join('; ')})`);
  }

  return undefined;
}

/**
 * Judge one gate.
 *
 * Order matters and is deliberate: setup problems first (an unconfigured run cannot judge anything), then
 * what the command did, then what the evidence says. A gate that both failed and is stale is reported as
 * failed, because that is the fact the operator has to act on first.
 */
export function evaluateGate(
  requirement: GateRequirement,
  observation: GateObservation | undefined,
  ctx: CertificationContext,
): GateVerdict {
  const verdict = (outcome: GateOutcome, reason: string): GateVerdict => ({
    id: requirement.id,
    title: requirement.title,
    outcome,
    reason,
  });

  const sha = (ctx.releaseSha ?? '').trim().toLowerCase();
  if (!FORTY_HEX.test(sha)) {
    return verdict(
      'unconfigured',
      'release commit is unknown: certification must name the exact 40-character commit it certifies',
    );
  }
  const window = ctx.freshnessWindowHours;
  if (!(typeof window === 'number' && Number.isFinite(window) && window > 0)) {
    return verdict(
      'unconfigured',
      'evidence freshness window is not configured; it is an owner decision (plan §8.1) and has no safe default',
    );
  }
  const approvedRequirementSetHash = (ctx.approvedRequirementSetHash ?? '').trim().toLowerCase();
  if (!SIXTY_FOUR_HEX.test(approvedRequirementSetHash)) {
    return verdict(
      'unconfigured',
      'approved requirement-set hash is unknown: certification must freeze it before execution',
    );
  }
  const certifierSourceSha256 = (ctx.certifierSourceSha256 ?? '').trim().toLowerCase();
  if (!SIXTY_FOUR_HEX.test(certifierSourceSha256)) {
    return verdict(
      'unconfigured',
      'candidate certifier source digest is unknown: requirement approval must bind the decision rules',
    );
  }

  if (!observation) {
    return verdict('missing', `${requirement.id} was never run in this certification`);
  }

  if (requirement.command || requirement.runnerCheck) {
    const invoked = observation.command ?? '';
    if (SELF_APPROVAL_FLAG.test(invoked)) {
      return verdict(
        'self-approved',
        `invoked with --write, which rewrites the baseline it compares against: ${invoked}`,
      );
    }
    const output = `${observation.stdout ?? ''}\n${observation.stderr ?? ''}`;
    if (observation.exitCode !== 0) {
      const runnerDetail = requirement.runnerCheck
        ? String(observation.stderr ?? observation.stdout ?? '').trim()
        : '';
      return verdict(
        'failed',
        `exited ${String(observation.exitCode)}` + (runnerDetail ? `: ${runnerDetail}` : ''),
      );
    }
    const skip = SKIP_TOKEN.exec(output);
    if (skip) {
      return verdict(
        'skipped',
        `exited 0 but reported ${skip[0]}: a gate that measured nothing cannot certify a release`,
      );
    }
  }

  const need = requirement.evidence;
  if (!need) return verdict('passed', 'command exited 0 with no skip result');

  if (!observation.artefact?.present) {
    return verdict('missing', `required evidence artefact is absent: ${need.path}`);
  }
  const json = asRecord(observation.artefact.json);
  if (!json) {
    return verdict('missing', `evidence artefact is not a JSON object: ${need.path}`);
  }

  const exactSetFailure = exactSetVerdict(requirement, json);
  if (exactSetFailure) return exactSetFailure;

  if (need.provenance) {
    const p = need.provenance(json);
    if (!p.ok) {
      return verdict('synthetic', p.reason ?? `evidence provenance is unacceptable: ${need.path}`);
    }
  }

  if (need.positive) {
    const outcome = need.positive(json);
    if (!outcome.ok) {
      return verdict('red', outcome.reason ?? `evidence is negative: ${need.path}`);
    }
  }

  // Freshness last, so a RED result is reported as red rather than as stale.
  if (!need.timestampField) {
    return verdict(
      'stale',
      `${need.path} carries no timestamp, so it cannot be shown to belong to this release`,
    );
  }
  const raw = readPath(json, need.timestampField);
  const at = typeof raw === 'string' ? Date.parse(raw) : NaN;
  if (!Number.isFinite(at)) {
    return verdict('stale', `${need.path} has no readable ${need.timestampField}`);
  }
  const ageMs = ctx.now.getTime() - at;
  if (ageMs < -FUTURE_TOLERANCE_MS) {
    return verdict('stale', `${need.path} is dated in the future (${String(raw)})`);
  }
  if (ageMs > window * 3600_000) {
    const hours = Math.round(ageMs / 3600_000);
    return verdict(
      'stale',
      `${need.path} was measured ${hours}h ago, outside the ${window}h freshness window`,
    );
  }

  // Evidence must belong to THIS commit. Artefacts that predate release certification carry no commit at
  // all; that is not a technicality to wave through — it is the reason a stale capture could be promoted.
  const bound = readPath(json, 'releaseSha');
  if (typeof bound !== 'string' || bound.trim().toLowerCase() !== sha) {
    return verdict(
      'stale',
      `${need.path} does not record releaseSha ${sha}, so it cannot be attributed to this release`,
    );
  }

  return verdict(
    'passed',
    'evidence is present, positive, attributable and within the freshness window',
  );
}

const EMPTY_TOTALS: Record<GateOutcome, number> = {
  passed: 0,
  failed: 0,
  skipped: 0,
  missing: 0,
  red: 0,
  stale: 0,
  synthetic: 0,
  'self-approved': 0,
  unexpected: 0,
  duplicate: 0,
  unconfigured: 0,
};

/** Validate the frozen gate universe before any command with external effects is allowed to run. */
export function requirementSetProblems(requirements: readonly GateRequirement[]): string[] {
  const counts = new Map<string, number>();
  for (const requirement of requirements) {
    counts.set(requirement.id, (counts.get(requirement.id) ?? 0) + 1);
  }
  const invalid = requirements
    .map(({ id }) => id)
    .filter((id) => !/^[a-z0-9]+(?:-[a-z0-9]+)*$/.test(id));
  const duplicates = [...counts]
    .filter(([, count]) => count > 1)
    .map(([id]) => id)
    .sort();
  const noOps = requirements
    .filter(
      (requirement) =>
        !(typeof requirement.command === 'string' && requirement.command.trim()) &&
        !requirement.runnerCheck &&
        !requirement.evidence,
    )
    .map(({ id }) => id)
    .sort();
  const exactSetDefects = requirements.flatMap((requirement) => {
    const exact = requirement.evidence?.exactSet;
    return exact
      ? exactSetConfigurationProblems(exact).map(
          (problem) => `${requirement.id} exact-set ${problem}`,
        )
      : [];
  });
  return [
    !requirements.length ? 'expected gate set is empty' : '',
    invalid.length ? `invalid gate ids: ${idSummary(invalid)}` : '',
    duplicates.length ? `duplicate gate ids: ${idSummary(duplicates)}` : '',
    noOps.length ? `gates without a command, runner check, or evidence: ${idSummary(noOps)}` : '',
    ...exactSetDefects,
  ].filter(Boolean);
}

export function requirementSetFingerprint(
  requirements: readonly GateRequirement[],
  certifierSourceSha256?: string,
): string {
  const stable = {
    // Binding the raw decision-module source catches changes to shared evaluation order/semantics that are
    // not visible in the declarative gate objects. The runner observes this digest before compiling.
    certifierSourceSha256: SIXTY_FOUR_HEX.test((certifierSourceSha256 ?? '').trim().toLowerCase())
      ? certifierSourceSha256!.trim().toLowerCase()
      : null,
    requirements: requirements.map((r) => ({
      id: r.id,
      title: r.title,
      because: r.because,
      command: r.command ?? null,
      runnerCheck: r.runnerCheck ?? null,
      evidence: r.evidence
        ? {
            path: r.evidence.path,
            timestampField: r.evidence.timestampField ?? null,
            // Predicate source is also explicit so locally constructed/tested requirements cannot change
            // validation semantics while retaining the same identity.
            positiveRuleSha256: r.evidence.positive
              ? createHash('sha256').update(r.evidence.positive.toString()).digest('hex')
              : null,
            provenanceRuleSha256: r.evidence.provenance
              ? createHash('sha256').update(r.evidence.provenance.toString()).digest('hex')
              : null,
            exactSet: r.evidence.exactSet
              ? {
                  collectionPath: r.evidence.exactSet.collectionPath,
                  idField: r.evidence.exactSet.idField ?? null,
                  // It is a set: declaration order must not alter the certificate identity.
                  requiredIds: [...r.evidence.exactSet.requiredIds].sort(),
                }
              : null,
          }
        : null,
    })),
  };
  return createHash('sha256').update(JSON.stringify(stable)).digest('hex');
}

/** Certify a release, or refuse and say why for every gate. */
export function certify(
  requirements: readonly GateRequirement[],
  observations: readonly GateObservation[],
  ctx: CertificationContext,
): CertificationRecord {
  const certifierSourceSha256 = (ctx.certifierSourceSha256 ?? '').trim().toLowerCase();
  const requirementSetHash = requirementSetFingerprint(requirements, certifierSourceSha256);
  const approvedRequirementSetHash = (ctx.approvedRequirementSetHash ?? '').trim().toLowerCase();
  const expected = new Set(requirements.map((r) => r.id));
  const byId = new Map<string, GateObservation>();
  const counts = new Map<string, number>();
  for (const o of observations) {
    counts.set(o.id, (counts.get(o.id) ?? 0) + 1);
    if (!byId.has(o.id)) byId.set(o.id, o);
  }
  const gates = requirements.map((r) => {
    const observed = counts.get(r.id) ?? 0;
    if (observed > 1) {
      return {
        id: r.id,
        title: r.title,
        outcome: 'duplicate' as const,
        reason: `${r.id} returned ${observed} observations; exact-set certification requires one result per gate id`,
      };
    }
    return evaluateGate(r, byId.get(r.id), ctx);
  });
  for (const [id, observed] of [...counts].sort(([a], [b]) => a.localeCompare(b))) {
    if (expected.has(id)) continue;
    gates.push({
      id,
      title: 'Unexpected gate observation',
      outcome: 'unexpected',
      reason:
        `${id} is not part of the required gate set` +
        (observed > 1 ? ` and appeared ${observed} times` : ''),
    });
  }
  const requiredSetDefects = requirementSetProblems(requirements);
  if (requiredSetDefects.length) {
    gates.push({
      id: 'required-gate-set',
      title: 'Required gate set',
      outcome: 'unconfigured',
      reason: `${requiredSetDefects.join('; ')}; exact-set certification requires unique nonblank gate ids in a non-zero required set`,
    });
  }
  if (
    SIXTY_FOUR_HEX.test(approvedRequirementSetHash) &&
    approvedRequirementSetHash !== requirementSetHash
  ) {
    gates.push({
      id: 'approved-requirement-set',
      title: 'Owner-approved requirement set',
      outcome: 'unconfigured',
      reason:
        `approved requirement-set hash ${approvedRequirementSetHash} does not match ` +
        `candidate requirement-set hash ${requirementSetHash}`,
    });
  }
  const totals = { ...EMPTY_TOTALS };
  for (const g of gates) totals[g.outcome] += 1;
  return {
    kind: 'datacare.release-certification/1.0',
    verdict: gates.every((g) => g.outcome === 'passed') ? 'passed' : 'failed',
    evaluatedAt: ctx.now.toISOString(),
    releaseSha: (ctx.releaseSha ?? '').trim().toLowerCase() || null,
    freshnessWindowHours: ctx.freshnessWindowHours ?? null,
    approvedRequirementSetHash: SIXTY_FOUR_HEX.test(approvedRequirementSetHash)
      ? approvedRequirementSetHash
      : null,
    certifierSourceSha256: SIXTY_FOUR_HEX.test(certifierSourceSha256)
      ? certifierSourceSha256
      : null,
    gates,
    totals,
    requirementSetHash,
  };
}

const isFiniteSafeNumber = (value: unknown): value is number =>
  typeof value === 'number' && Number.isFinite(value) && Math.abs(value) <= Number.MAX_SAFE_INTEGER;

const isSafeCount = (value: unknown): value is number =>
  isFiniteSafeNumber(value) && Number.isSafeInteger(value) && value >= 0;

const invalidSafeCounts = (
  record: Record<string, unknown> | undefined,
  fields: readonly string[],
): string[] => fields.filter((field) => !isSafeCount(record?.[field]));

const list = (value: unknown): unknown[] => (Array.isArray(value) ? value : []);

/**
 * Frozen minimum desktop-differ case universe from
 * `project-memory/parity/PARITY-RATCHET.json.caseIds` (2026-09-01).
 *
 * The verification plan calls this retained 70-case universe a starting regression set, not whole-product
 * coverage. Requiring it exactly prevents a later all-green subset from silently deleting a difficult case;
 * X06/X34 must expand this list when reviewed family/branch manifests add cases. Because these IDs are part of
 * `requirementSetHash`, that expansion invalidates certificates produced against the smaller universe.
 */
export const REQUIRED_G5_COMPARISON_CASE_IDS: readonly string[] = Object.freeze(
  `cashpay-002-00029
cashrec-001-00001
purc-035-00001
purc-035-00002
purc-035-00003
purc-035-00004
purc-035-00005
purc-035-00006
purc-035-00007
purc-035-00008
purc-035-00009
purc-035-00010
purc-035-00011
purc-035-00012
purc-035-00013
purc-035-00014
purc-035-00015
purc-035-00016
purc-035-00017
purc-035-00018
purc-035-00019
purc-035-00020
purc-035-00021
purc-035-00022
purc-035-00023
purc-035-00024
purc-035-00025
purc-035-00026
purc-035-00027
purc-035-00028
purc-035-00029
purc-036-00001
purc-036-00002
purc-036-00003
purc-036-00004
purc-036-00005
purc-036-00006
purc-036-00007
purc-037-00001
purc-037-00002
purc-037-00003
purc-037-00004
purc-037-00005
purc-037-00006
purc-037-00007
purc-038-00001
purc-038-00002
purc-038-00003
purc-038-00004
purc-038-00005
purc-041-00001
purc-041-00002
purc-041-00003
sale-027-00001
scheme-074-00001
wsale-034-00001
wsale-034-00002
wsale-034-00003
wsale-034-00004
wsale-034-00005
wsale-034-00006
wsale-034-00007
wsale-034-00008
wsale-034-00009
wsale-034-00010
wsale-034-00011
wsale-034-00012
wsale-034-00013
wsale-034-00014
wsale-034-00015`
    .trim()
    .split(/\s+/),
);

/**
 * Frozen production-stack browser journeys executed by `apps/web/test/parity.real-stack.mjs`.
 *
 * This is deliberately separate from the mocked compatibility smoke and route-render checks. A release must
 * exercise every currently registered real HTTP/browser/database journey exactly once; adding a journey to
 * the harness must expand this set and therefore changes the certification requirement fingerprint.
 */
export const REQUIRED_REAL_BROWSER_JOURNEY_IDS: readonly string[] = Object.freeze([
  'cash-receipt-payment',
  'column-settings',
  'credit-note',
  'credit-note-entry',
  'design-book',
  'design-calculations',
  'design-repeat',
  'e-invoice-entry',
  'generic-image-conflict',
  'image-conflict',
  'manufacturing-lot',
  'order-images',
  'repair-image-conflict',
  'sale-amount-basis',
  'sales-order',
  'sales-order-design',
  'sales-return-bill-replay',
  'sales-return-labour-replay',
  'sales-return-replay',
  'sales-return-saved',
  'tag-cancel-transfer',
  'tour-order',
  'wholesale-rate-cut',
]);

/**
 * Frozen report/mode comparison universe from
 * `parity-plan-2026-09-10/evidence/report-register.json` (2026-09-10): 255 supplied Crystal identities plus
 * 20 referenced-but-absent identities. An absent reference remains required until source review gives it a
 * disposition; silently omitting it is exactly the false-green X34 forbids.
 *
 * These are the current minimum stable comparison IDs. A source-discovered mode that shares a template gets
 * its own stable ID when X26 adds it; changing this list changes `requirementSetHash` and invalidates earlier
 * evidence. Keeping the list in the requirement code prevents a result artefact from choosing its own scope.
 */
export const REQUIRED_REPORT_COMPARISON_IDS: readonly string[] = Object.freeze(
  `AcCrList
AcDrList
AcFineGold
AcFineSilver
AcGroupRpt
AcLastVisit
AcLedger
AcLedgerSelected
AcOsArea
AcOsWithAdd
AcPurcRpt
AcPurcSummRpt
AcPurcWhRpt
AcSaleWhRpt
AcSumm
AcSummLdr
AcWithWt
AcWithWtGold
AcWithWtSumm
AngdiyaIsuRpt
AprBill
AprInOut
AprPan
AprPartyWise
B2BPurcBillA4Tax
B2BPurcImgVch
B2BSaleBillA4Tax
B2BSaleImgVch
BalanceHz
BarPrint10
BarPrint13
BillRecVch
BillWiseOrderAdjust
BulCustAdjust
BulCustBooking
BullBookBill
CashBankBill
CashBankBillAc
ChqPrint010
ChqPrint011
ChqPrint012
ChqPrint013
ChqPrint014
ChqPrint135
CntrTagStkRpt
CntrTagSumRpt
Company
ConsiBill
ContraBill
CounterSale
CounterTrfr
CustRepIsu
CustRepRec
CustRepRecBill
DharnDue
DhiranIssuRec
DhiranitemRpt
DhiranReg
DhiranStock
DhrnIntRec
DhrnIssue
DhrnIssueImg
DhrnKhataVahi
DhrnKhataVahiSumm
DhrnOsLetter
DhrnReceivedSumm
DiamondSf
EInvoice
EInvOthIncom
EmpIsuRecVch
EmpSaleReport
FineJvBill
FineSalesGstBill
Form12
Form8
GhatDesignIsu
GhatTagPrnt
GoldInterest
GroupStkRpt
Gstr_1
Gstr_2
Gstr_3
HedgingFixVch
InTax_PurcRpt
ItemInOut
ItemInOutSumm
ItemInword
ItemLedger
ItemOutword
ItemPurcVch
ItemSalesVch
ItemSalesVchWithQr
ItemStkRpt
ItmLotPrint
ItmStkBalance
ItmStkWithGrid
ItmStkWithOthWt
JadtarInOut
JadtarIssue
JadtarRec
JdtProcessRec
JmUdAmt
JmUdFine
JmUdFineHz
JmUdFineHzSumm
JmUdFineHzSummVch
JmUdFineSl
JmUdFineSlHz
JmUdFineSlSum
KrDesignIsuImg
KrDesignIsuVch
KrDmIsuRec
KrDmWtInOut
KrIsuBill
KrIsuBillGst
KrRecVch
KrRecVchGst
KrRepRec
LabourBill
LabourBillGst
LabourWorkVch
LbrWorkRpt
LedrAdjVch
LedrInOut
LedrInOutWh
LoanStock
LoanWisePacket
MembBonus
MembCommRpt
MembDailyRecRpt
MembGoldRpt
MembOpenNew
MembQr
MembRpt
MembRptAdd
MembSumm
MembVch
MfgGhatIsu
MfgGhatRec
MfgLedger
MfgMinoIsuRec
MfgVch
MtlIsu
OldItmSaleVch
OrdAdjBillWise
OrdAdvAdj
OrdAdvRpt
OrdDesignSumm
OrdDetlPanding
OrdDetlRpt
OrderBill
OrderCancelVch
OrderVch
OrdVchImg
OthCommVch
OthExpUae
OthItmLoose
OthItmStud
OutTax_SaleRpt
PartyInterest
PartyIntSumm
PaymentVch
ProdStkRpt
ProfitLossHz
PrRtnBill
PrRtnBillGst
PrTaxRpt
PurcBillA4
PurcBillA4Gst
PurcBillHalfGst
PurcGroupWise
PurcItem
PurcReport
PurcSumm
PurcToSalesFixingVch
QrPrint10
RateCutBill
RateCutItmBill
RateRpt
ReminderAll
ReparingCustIsu
ReparingKrRec
ReparingRec
RojMel
RojMelCash
RojMelCrDr
RojMelEstmat
RojMelGr
RojMelItem
RojMelJmaUdhar
RtlHuidPrint
SafeStkSumm
SalarySlip
SaleOrnaIsu
SaleReport
SaleRtnReport
SalesBillA4
SalesBillA4_WithImage
SalesBillA4Gst
SalesBillHz
SalesBillHzGst
SalesBillOrgDup
SalesBillOs
SalesBillVr
SalesGroupWise
SalesItem
SalesQuotation
SalesRtnA4
SalesRtnA4Gst
SalesRtnBillUae
SalesRtnItem
SalesRtnSumm
SalesSumm
SalesToPurcFixingVch
SalesWithOrder
SchmAdj
SchmMonthRpt
SchmPassBook
SchmRecVch
SlBillWapp
SlTaxRpt
StkInOutVch
StngIsuRec
TableStkGwtRpt
TagCanBill
TagHuIdRpt
TagItmSumm
TagReNumberVch
TagSplitVch
TagStkIdtlRpt
TagStkItemSumRpt
TagStkRpt
TagStkRptDmSum
TagStkSummRpt
TagWtChangeVch
TagWtChangSplit
TaxInOutRpt
TaxSummUae
TempAdd2
TempAdd3
TempPhone
TourOrdImg
TourOrdVch
TRialBalHz
UserDtlRpt
VpAdjustBill
VpIsuRpt
WhHuidPrint
WhSalesBill
WhSalesBillSumm
WhSalesEmp
WhSalesImage
WhSalesIsuRec
WhSalesRtnBill
WhSalesSumm
aprbillimg
balzoom
bankadj
billwiseos
empdaysumm
empsumm
franchisebill
jdterskt
jdtvch
krisureport
krrecreport
loctamtvch
mainacsumm
mltingisu
purcquot
reminderschm
remindervch
salesrtna4print
vpparcelbill
whquotation`
    .trim()
    .split(/\s+/),
);

/**
 * The evidence a release must carry.
 *
 * Sourced from P0-07's required action — "fresh G5, `register:check --strict`, type parity with real inputs,
 * schema readiness with live DB, report comparisons, restore drill, and no SKIP result" — plus the build,
 * test and lint gates a release obviously cannot skip.
 *
 * Every command here is the STRICT form. `register:check` is invoked with `--strict` rather than through the
 * default package script, because the default accepts every entry being unclassified.
 */
export const RELEASE_GATES: readonly GateRequirement[] = Object.freeze([
  {
    id: 'lint',
    title: 'Workspace lint and typecheck',
    because: 'a release cannot ship code that does not typecheck',
    command: 'pnpm lint',
  },
  {
    id: 'test',
    title: 'Full test suite',
    because: 'the posting, RLS and authorization behaviour is asserted here',
    command: 'pnpm test',
  },
  {
    id: 'build',
    title: 'Production build',
    because: 'the artefacts being certified must be the ones that build',
    command: 'pnpm build',
  },
  {
    id: 'real-browser',
    title: 'Real production-stack browser journeys',
    because:
      'X33/X34 require every registered real browser journey against production Next, Fastify and PostgreSQL with no mocked requests',
    command:
      'API_ORIGIN=http://127.0.0.1:4410 pnpm --filter @datacare/web build && pnpm test:parity:browser',
    evidence: {
      path: 'web/test-results/parity-real-stack/result.json',
      timestampField: 'finishedAt',
      exactSet: {
        collectionPath: 'journeys',
        idField: 'journeyId',
        requiredIds: REQUIRED_REAL_BROWSER_JOURNEY_IDS,
      },
      provenance: (json) => {
        for (const field of [
          'mockedRequests',
          'mockedResponses',
          'interceptionIndicators',
        ] as const) {
          if (
            typeof json[field] !== 'number' ||
            !Number.isSafeInteger(json[field]) ||
            json[field] !== 0
          ) {
            return {
              ok: false,
              reason: `real browser evidence reports ${field}=${String(json[field])}`,
            };
          }
        }
        if (
          typeof json.database !== 'string' ||
          !/^disposable localhost:55433\s*\/\s*app_user$/i.test(json.database)
        ) {
          return {
            ok: false,
            reason:
              'real browser evidence does not identify the disposable non-owner PostgreSQL target',
          };
        }
        return { ok: true };
      },
      positive: (json) => {
        if (String(json.status ?? '') !== 'passed') {
          return {
            ok: false,
            reason: `real browser result status is ${String(json.status ?? 'missing')}`,
          };
        }
        const failing = list(json.journeys)
          .map((journey) => asRecord(journey))
          .filter((journey) => journey?.status !== 'passed')
          .map((journey) => String(journey?.journeyId ?? '?'));
        return failing.length
          ? { ok: false, reason: `real browser journeys not passing: ${failing.join(', ')}` }
          : { ok: true };
      },
    },
  },
  {
    id: 'format',
    title: 'Formatting',
    because: 'keeps the certified tree identical to the reviewed tree',
    command: 'pnpm format:check',
  },
  {
    id: 'completion-register',
    title: 'Completion register, strict and release-grade',
    because:
      'P0-07 names `register:check --strict`; on its own that only proves every entry is CLASSIFIED, and plan §14 says implemented-unverified is not done, so a release also needs --release',
    command: 'node scripts/check-completion-register.mjs --strict --release',
  },
  {
    id: 'contract-integrity',
    title: 'Behaviour contracts are checkable and honestly cited',
    because:
      'contracts are the source of truth above the code (plan §2), and P1-07 records 8 drafts with 30 unenforced validations; nothing previously stopped a draft being flipped to approved with every cell blank',
    command: 'node scripts/check-contracts.mjs',
  },
  {
    id: 'kernel-conformance',
    title: 'Posting families use the shared compatibility kernel',
    because:
      'WP-06 requires no module-local posting fallback; 108 local rounding helpers and 5 inline BOOK_DETL reads bypass primitives that already exist, and the local helpers round negative midpoints the wrong way',
    command: 'node scripts/check-kernel-conformance.mjs',
  },
  {
    id: 'schema-readiness',
    title: 'Desktop-declared schema present, against a live database',
    because:
      'P0-07 requires this with a live DB, and the script exits 0 with SCHEMA_READINESS_SKIP without one',
    command: 'pnpm schema:readiness',
  },
  {
    id: 'type-parity',
    title: 'Complete numeric/text column-domain parity from a real SQL Server dump',
    because:
      'P0-07 requires all 5,231 desktop-declared columns from real input, plus zero unsupported numeric and text domains; the ordinary script mode may skip missing input or compare an empty baseline',
    command: 'node scripts/check-type-parity.mjs --release',
  },
  {
    id: 'fresh-provision',
    title: 'Fresh provision is tenant-isolated',
    because: 'a late-added table without forced RLS has shipped before (message_attempt_log)',
    command: 'pnpm fresh:provision',
  },
  {
    id: 'settings-parity',
    title: 'Configuration coverage',
    because: 'settings reachability is a release claim',
    command: 'pnpm settings:parity',
  },
  {
    id: 'report-baselines',
    title: 'Report layouts unchanged',
    because: 'proves the web did not change relative to itself; never invoked with --write',
    command: 'node scripts/report-baselines.mjs',
  },
  {
    id: 'g5-desktop-comparison',
    title: 'Desktop-versus-web voucher comparison',
    because:
      'the controlling parity evidence must include every retained baseline case exactly once; today its 70-case result is matched:false',
    command: 'pnpm g5:parity',
    evidence: {
      path: 'project-memory/parity/g5/parity-diff-latest.json',
      timestampField: 'comparedAt',
      exactSet: {
        collectionPath: 'cases',
        idField: 'caseId',
        requiredIds: REQUIRED_G5_COMPARISON_CASE_IDS,
      },
      provenance: (json) => {
        const desktop = asRecord(json.desktop);
        const engine =
          typeof desktop?.engine === 'string' ? desktop.engine.trim().toLowerCase() : '';
        const banner = typeof desktop?.appVersion === 'string' ? desktop.appVersion : '';
        if (engine !== 'sqlserver' || !/microsoft sql server/i.test(banner)) {
          return {
            ok: false,
            reason:
              'the desktop side of the comparison does not carry a Microsoft SQL Server banner, so it is not a real capture',
          };
        }
        const totals = asRecord(json.totals);
        const invalidCounts = invalidSafeCounts(totals, [
          'cases',
          'casesMatched',
          'tablesCompared',
          'tablesDesktopOnly',
          'tablesWebOnly',
          'fieldsCompared',
          'fieldsExcluded',
          'fieldDifferences',
          'rowsMissing',
          'rowsExtra',
        ]);
        if (invalidCounts.length) {
          return {
            ok: false,
            reason:
              `parity-diff totals must be finite non-negative safe-integer numbers; invalid: ` +
              invalidCounts.join(', '),
          };
        }
        if (totals!.cases !== REQUIRED_G5_COMPARISON_CASE_IDS.length) {
          return {
            ok: false,
            reason:
              `parity-diff totals.cases=${String(totals!.cases)} does not equal the frozen ` +
              `${REQUIRED_G5_COMPARISON_CASE_IDS.length}-case universe`,
          };
        }
        if (totals!.fieldsCompared === 0) {
          return {
            ok: false,
            reason: 'the comparison has no compared fields, so it cannot have compared anything',
          };
        }
        return { ok: true };
      },
      positive: (json) => {
        if (json.matched !== true) {
          return { ok: false, reason: 'parity-diff reports matched != true' };
        }
        const totals = asRecord(json.totals) ?? {};
        if (totals.casesMatched !== REQUIRED_G5_COMPARISON_CASE_IDS.length) {
          return {
            ok: false,
            reason:
              `parity-diff totals.casesMatched=${String(totals.casesMatched)} does not prove all ` +
              `${REQUIRED_G5_COMPARISON_CASE_IDS.length} cases matched`,
          };
        }
        for (const field of [
          'tablesDesktopOnly',
          'tablesWebOnly',
          'fieldDifferences',
          'rowsMissing',
          'rowsExtra',
        ] as const) {
          if (totals[field] !== 0) {
            return { ok: false, reason: `parity-diff reports ${field}=${String(totals[field])}` };
          }
        }
        if (!Array.isArray(json.desktopOnlyCases) || !Array.isArray(json.webOnlyCases)) {
          return {
            ok: false,
            reason: 'parity-diff must report desktopOnlyCases and webOnlyCases as arrays',
          };
        }
        if (json.desktopOnlyCases.length || json.webOnlyCases.length) {
          return { ok: false, reason: 'parity-diff reports cases present on only one side' };
        }
        const failingCases = list(json.cases)
          .map((candidate) => asRecord(candidate))
          .filter((candidate) => candidate?.matched !== true)
          .map((candidate) => String(candidate?.caseId ?? '?'));
        if (failingCases.length) {
          return {
            ok: false,
            reason: `parity-diff cases not structurally matched: ${failingCases.join(', ')}`,
          };
        }
        return { ok: true };
      },
    },
  },
  {
    id: 'report-comparison',
    title: 'Desktop-versus-web report data comparison',
    because:
      'P0-07/X34 require every frozen report/mode id exactly once; a non-empty all-pass subset cannot certify the product',
    evidence: {
      path: 'project-memory/parity/reports/report-comparison-latest.json',
      timestampField: 'comparedAt',
      exactSet: {
        collectionPath: 'reports',
        idField: 'reportModeId',
        requiredIds: REQUIRED_REPORT_COMPARISON_IDS,
      },
      provenance: (json) => {
        const reports = list(json.reports);
        if (!reports.length) {
          return { ok: false, reason: 'no report was compared' };
        }
        const malformed = reports.flatMap((candidate) => {
          const report = asRecord(candidate);
          const id = String(report?.reportModeId ?? '?');
          const crystal = asRecord(report?.crystal);
          const web = asRecord(report?.web);
          const rowLevel = asRecord(report?.rowLevel);
          const crystalRows = crystal?.rows;
          const webRows = web?.rows;
          const fieldsCompared = rowLevel?.compared;
          const invalidRows = [
            !isSafeCount(crystalRows) || crystalRows === 0 ? 'crystal.rows' : '',
            !isSafeCount(webRows) || webRows === 0 ? 'web.rows' : '',
            !isSafeCount(fieldsCompared) || fieldsCompared === 0 ? 'rowLevel.compared' : '',
          ].filter(Boolean);
          const crystalSums = asRecord(crystal?.sums);
          const webSums = asRecord(web?.sums);
          const invalidSums = [
            ...Object.entries(crystalSums ?? {})
              .filter(([, value]) => !isFiniteSafeNumber(value))
              .map(([field]) => `crystal.sums.${field}`),
            ...Object.entries(webSums ?? {})
              .filter(([, value]) => !isFiniteSafeNumber(value))
              .map(([field]) => `web.sums.${field}`),
          ];
          if (!crystalSums) invalidSums.push('crystal.sums');
          if (!webSums) invalidSums.push('web.sums');
          const invalid = [...invalidRows, ...invalidSums];
          return invalid.length ? [`${id}: ${invalid.join(', ')}`] : [];
        });
        if (malformed.length) {
          return {
            ok: false,
            reason:
              'report comparison denominators/totals must be concrete finite safe numbers: ' +
              idSummary(malformed),
          };
        }
        return { ok: true };
      },
      positive: (json) => {
        const failing = list(json.reports).flatMap((candidate) => {
          const report = asRecord(candidate);
          const id = String(report?.reportModeId ?? report?.report ?? '?');
          const crystal = asRecord(report?.crystal);
          const web = asRecord(report?.web);
          const rowLevel = asRecord(report?.rowLevel);
          const differences = rowLevel?.differences;
          const unmapped = report?.unmappedCrystalColumns;
          const missing = report?.missingWebColumns;
          const matched =
            report?.matched === true &&
            report.rowCountMatches === true &&
            report.totalsMatch === true &&
            crystal?.rows === web?.rows &&
            Array.isArray(differences) &&
            differences.length === 0 &&
            Array.isArray(unmapped) &&
            unmapped.length === 0 &&
            Array.isArray(missing) &&
            missing.length === 0;
          return matched ? [] : [id];
        });
        return failing.length
          ? { ok: false, reason: `reports not matching desktop: ${failing.join(', ')}` }
          : { ok: true };
      },
    },
  },
  {
    id: 'restore-drill',
    title: 'Backup/restore drill',
    because: 'P0-07 requires it; it is not invoked by CI today',
    command: 'pnpm restore-drill',
    evidence: {
      path: 'project-memory/parity/restore-drill-result.json',
      timestampField: 'measuredAt',
      positive: (json) => {
        if (json.status !== 'passed') {
          return { ok: false, reason: `restore drill status is ${String(json.status)}` };
        }
        const verification = asRecord(json.verification);
        if (!verification || verification.verified !== true) {
          return {
            ok: false,
            reason: 'restore drill must carry verification.verified=true',
          };
        }
        const invalidCounts = invalidSafeCounts(verification, [
          'sourceRows',
          'restoredRows',
          'tablesChecked',
        ]);
        if (invalidCounts.length) {
          return {
            ok: false,
            reason:
              'restore drill verification counts must be finite non-negative safe integers: ' +
              invalidCounts.join(', '),
          };
        }
        if (
          verification.sourceRows === 0 ||
          verification.sourceRows !== verification.restoredRows
        ) {
          return {
            ok: false,
            reason:
              `restore drill row verification is not concrete and equal: source=${String(verification.sourceRows)} ` +
              `restored=${String(verification.restoredRows)}`,
          };
        }
        if (!Array.isArray(verification.mismatches) || verification.mismatches.length !== 0) {
          return { ok: false, reason: 'restore drill verification contains mismatches' };
        }
        if (
          !Array.isArray(verification.tables) ||
          verification.tables.length === 0 ||
          verification.tablesChecked !== verification.tables.length
        ) {
          return {
            ok: false,
            reason: `restore drill tablesChecked=${String(verification.tablesChecked)} does not match a non-empty verification table list`,
          };
        }
        const tableNames = new Set<string>();
        let sourceRows = 0;
        let restoredRows = 0;
        const invalidTables: string[] = [];
        verification.tables.forEach((candidate, index) => {
          const table = asRecord(candidate);
          const name = typeof table?.table === 'string' ? table.table.trim() : '';
          const sourceCount = table?.sourceRows;
          const restoredCount = table?.restoredRows;
          const sourceChecksum = table?.sourceChecksum;
          const restoredChecksum = table?.restoredChecksum;
          const valid =
            name.length > 0 &&
            name === table?.table &&
            !tableNames.has(name) &&
            table?.matches === true &&
            isSafeCount(sourceCount) &&
            isSafeCount(restoredCount) &&
            sourceCount === restoredCount &&
            typeof sourceChecksum === 'string' &&
            sourceChecksum.length > 0 &&
            sourceChecksum === restoredChecksum;
          if (!valid) {
            invalidTables.push(name || `index ${index}`);
            return;
          }
          tableNames.add(name);
          sourceRows += sourceCount as number;
          restoredRows += restoredCount as number;
        });
        if (
          invalidTables.length ||
          sourceRows !== verification.sourceRows ||
          restoredRows !== verification.restoredRows
        ) {
          return {
            ok: false,
            reason:
              `restore drill table verification is incomplete or inconsistent` +
              (invalidTables.length ? `: ${idSummary(invalidTables)}` : ''),
          };
        }
        return { ok: true };
      },
    },
  },
  {
    /**
     * The ratchet is a SEPARATE gate from `g5-desktop-comparison`, not a softer version of it.
     *
     * That gate asks "is the web at parity?" and will answer no for a long time. This one asks "did any measured
     * parity number get worse?", which is answerable today and is the only thing that makes incremental work
     * visible. Keeping them apart means the ratchet can never be mistaken for a parity certificate, and passing
     * it can never substitute for matching the desktop.
     *
     * It exists because the comparison went unrun for a month, during which 1,354 of 3,787 field differences
     * were fixed without anyone knowing, and a regression would have been equally invisible.
     */
    id: 'parity-ratchet',
    title: 'Measured parity numbers did not worsen',
    because:
      'parity is closed incrementally, and a gate that only reports "not yet" cannot detect either progress or regression',
    command: 'pnpm parity:measure --reuse',
    evidence: {
      path: 'project-memory/parity/PARITY-RATCHET.json',
      timestampField: 'recordedAt',
      exactSet: {
        collectionPath: 'caseIds',
        requiredIds: REQUIRED_G5_COMPARISON_CASE_IDS,
      },
      positive: (json) => {
        const metrics = asRecord(json.metrics);
        if (!metrics) return { ok: false, reason: 'the recorded ceiling carries no metrics' };
        const invalidCounts = invalidSafeCounts(metrics, [
          'cases',
          'casesMatched',
          'tablesCompared',
          'tablesDesktopOnly',
          'tablesWebOnly',
          'fieldsCompared',
          'fieldsExcluded',
          'fieldDifferences',
          'rowsMissing',
          'rowsExtra',
        ]);
        if (invalidCounts.length) {
          return {
            ok: false,
            reason:
              `the recorded ceiling metrics must be finite non-negative safe-integer numbers; invalid: ` +
              invalidCounts.join(', '),
          };
        }
        if (metrics.cases !== REQUIRED_G5_COMPARISON_CASE_IDS.length) {
          return {
            ok: false,
            reason:
              `the ceiling claims ${String(metrics.cases)} cases but the frozen retained universe has ` +
              `${REQUIRED_G5_COMPARISON_CASE_IDS.length}`,
          };
        }
        // A ceiling that compared nothing would accept anything.
        if (metrics.fieldsCompared === 0) {
          return {
            ok: false,
            reason: 'the recorded ceiling compared no fields, so it constrains nothing',
          };
        }
        if ((metrics.casesMatched as number) > (metrics.cases as number)) {
          return {
            ok: false,
            reason: 'the recorded ceiling claims more matching cases than cases measured',
          };
        }
        return { ok: true };
      },
    },
  },
  {
    /**
     * Operator-depth ratchet — a THIRD, distinct parity question.
     *
     * `g5-desktop-comparison` asks "does the web produce the desktop's numbers?".
     * `parity-ratchet` asks "did any compared field get worse?".
     * This one asks "can an operator actually reach the desktop's fields?" — and it is the
     * question nothing was asking while the product sat at 33.9% operator depth and was
     * recorded as 98.9% complete, because column-write coverage and settings *exposure* both
     * looked finished. Depth is measured as bound input controls plus visible grid columns,
     * against the 5,107 the desktop presents.
     *
     * Kept separate for the same reason as the others: passing it is not parity, and parity
     * cannot be claimed without it.
     */
    id: 'operator-depth',
    title: 'Operator-reachable field depth did not worsen',
    because:
      'DB column coverage and settings exposure can both read complete while two thirds of the desktop fields are unreachable from any screen',
    command: 'node scripts/check-depth.mjs',
  },
  {
    id: 'candidate-identity-postflight',
    title: 'Candidate identity unchanged after all release gates',
    because:
      'X34 requires the reviewed commit, lockfile, schema and tracked web-template bundles to remain exact after every potentially mutating build and verification command',
    runnerCheck: 'candidate-identity-postflight',
  },
]);
