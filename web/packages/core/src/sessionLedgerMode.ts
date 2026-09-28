/** Trusted semantic prerequisite for MS_OPNCOMP:1459–1476 and
 * MDI_FORM:12721–12790. No registration decoding, Windows key classification,
 * authentication, session persistence, authorization or ledger query occurs here.
 * Bootstrap edition and later command edition remain distinct observations.
 */
export const SESSION_LEDGER_MODE_VERSION = 'session-ledger-mode-semantic-v1';
export const SESSION_LEDGER_MODE_PROFILE = 'trusted-bootstrap-and-commands-abc-v1';

export type SessionLedgerMode = 'A' | 'B' | 'C';
export type SessionLedgerEdition = 'L' | 'B' | 'S' | 'U' | 'P' | 'A' | 'E';
export type SessionLedgerEvidence<T> =
  | Readonly<{ status: 'known'; value: T; revision: string }>
  | Readonly<{ status: 'unknown'; reason: string; revision: string }>;
export interface SessionLedgerContext {
  readonly tenantId: string;
  readonly coCode: string;
  readonly lcCode: string;
  readonly coYear: string;
  /** Opaque trusted context epoch; repeated scope strings do not recreate it. */
  readonly identity: string;
}
export interface SessionLedgerBootstrap {
  readonly completed: SessionLedgerEvidence<boolean>;
  readonly edition: SessionLedgerEvidence<SessionLedgerEdition>;
  readonly forceCombined: SessionLedgerEvidence<boolean>;
}
export type SessionLedgerCommand =
  | Readonly<{ kind: 'special'; letter: 'A' | 'B' | 'C' }>
  | Readonly<{
      kind: 'alias';
      letter:
        | 'D'
        | 'E'
        | 'F'
        | 'G'
        | 'H'
        | 'I'
        | 'J'
        | 'K'
        | 'L'
        | 'M'
        | 'N'
        | 'O'
        | 'P'
        | 'Q'
        | 'R'
        | 'S'
        | 'T'
        | 'U'
        | 'V'
        | 'W'
        | 'X'
        | 'Y'
        | 'Z';
    }>;
export interface SessionLedgerCatalogRow {
  readonly identity: string;
  readonly revision: string;
  readonly raw: Readonly<{
    CO_CODE: string | null;
    CON_CODE: string | null;
    CON_NAME: string | null;
  }>;
}
export interface SessionLedgerCatalog {
  /** Source query company is literal01, independent of selected company. */
  readonly company: string;
  readonly complete: boolean;
  readonly revision: string;
  readonly rows: readonly SessionLedgerCatalogRow[];
}
export type SessionLedgerBranch =
  'direct-special' | 'mapped-special' | 'special-fallback' | 'mapped-alias' | 'alias-retained';
export interface SessionLedgerTransitionProof {
  readonly commandEdition: SessionLedgerEvidence<SessionLedgerEdition>;
  readonly command: SessionLedgerCommand;
  readonly catalog: SessionLedgerCatalog;
  readonly previousMode: SessionLedgerMode | null;
  readonly nextMode: SessionLedgerMode;
  readonly outcome: 'applied' | 'retained';
  readonly branch: SessionLedgerBranch;
}
export interface SessionLedgerModeState {
  readonly version: typeof SESSION_LEDGER_MODE_VERSION;
  readonly profile: typeof SESSION_LEDGER_MODE_PROFILE;
  readonly context: SessionLedgerContext;
  readonly status: 'resolved' | 'unresolved';
  readonly mode: SessionLedgerMode | null;
  readonly reason: string | null;
  readonly bootstrap: SessionLedgerBootstrap;
  /** Accepted semantic commands only; this is not an authenticated audit log. */
  readonly history: readonly SessionLedgerTransitionProof[];
}
export interface SessionLedgerBootstrapInput extends SessionLedgerBootstrap {
  readonly context: SessionLedgerContext;
}
export interface SessionLedgerTransitionInput {
  readonly previous: SessionLedgerModeState;
  readonly commandEdition: SessionLedgerEvidence<SessionLedgerEdition>;
  readonly command: SessionLedgerCommand;
  /** Null/incomplete observations are unavailable, never an absent SQL result. */
  readonly catalog: SessionLedgerCatalog | null;
}
export type SessionLedgerDiagnosticCode =
  | 'invalid-input'
  | 'invalid-previous-state'
  | 'input-limit'
  | 'bootstrap-incomplete'
  | 'bootstrap-edition-unresolved'
  | 'bootstrap-exception-unresolved'
  | 'command-edition-unresolved'
  | 'command-edition-unavailable'
  | 'catalog-unavailable'
  | 'catalog-company-unsupported'
  | 'catalog-identity-ambiguous'
  | 'sentinel-ambiguous'
  | 'alias-ambiguous'
  | 'alias-output-unsupported'
  | 'previous-mode-unresolved'
  | 'history-limit';
export interface SessionLedgerDiagnostic {
  readonly code: SessionLedgerDiagnosticCode;
  readonly message: string;
}
export type SessionLedgerBootstrapResult =
  | Readonly<{
      status: 'resolved' | 'unresolved';
      state: SessionLedgerModeState;
      diagnostics: readonly SessionLedgerDiagnostic[];
    }>
  | Readonly<{
      status: 'invalid-input';
      state: null;
      diagnostics: readonly SessionLedgerDiagnostic[];
    }>;
export type SessionLedgerTransitionResult =
  | Readonly<{
      status: 'applied' | 'retained';
      state: SessionLedgerModeState;
      diagnostics: readonly [];
    }>
  | Readonly<{
      status: 'unsupported' | 'invalid-input';
      state: SessionLedgerModeState | null;
      diagnostics: readonly SessionLedgerDiagnostic[];
    }>;

// Resource limits name this pure transport profile; they are not desktop limits.
const MAX_HISTORY = 100;
const MAX_CATALOG_ROWS = 1000;
const MAX_NODES = 200_000;
const MAX_TEXT = 8 * 1024 * 1024;
const editions = new Set(['L', 'B', 'S', 'U', 'P', 'A', 'E']);
const modes = new Set(['A', 'B', 'C']);
class BoundaryError extends Error {
  constructor(
    readonly code: 'invalid-input' | 'input-limit',
    message: string,
  ) {
    super(message);
  }
}
function invalid(): never {
  throw new BoundaryError(
    'invalid-input',
    'A complete plain-data trusted observation is required.',
  );
}
function limited(): never {
  throw new BoundaryError('input-limit', 'The observation exceeds this bounded semantic profile.');
}
function record(value: unknown): value is Record<string, unknown> {
  return value !== null && typeof value === 'object' && !Array.isArray(value);
}
function keys(value: unknown, names: readonly string[]): value is Record<string, unknown> {
  return (
    record(value) &&
    Object.keys(value).length === names.length &&
    names.every((name) => Object.hasOwn(value, name))
  );
}
function identifier(value: unknown, max = 256): value is string {
  return (
    typeof value === 'string' &&
    value.length > 0 &&
    value.length <= max &&
    !/[^\x21-\x7e]/.test(value)
  );
}
function reason(value: unknown): value is string {
  return (
    typeof value === 'string' &&
    value.length <= 1024 &&
    value.trim().length > 0 &&
    !/[\u0000-\u001f\u007f]/.test(value)
  );
}
function isMode(value: unknown): value is SessionLedgerMode {
  return typeof value === 'string' && modes.has(value);
}
function isEdition(value: unknown): value is SessionLedgerEdition {
  return typeof value === 'string' && editions.has(value);
}

/** Inspect descriptors before reading values: getters are never invoked and
 * caller objects are neither frozen nor retained. Cycles/custom prototypes,
 * nonfinite values, sparse arrays and hidden/symbol properties are refused.
 */
function detach(input: unknown): unknown {
  const ancestors = new WeakSet<object>();
  let nodes = 0,
    textLength = 0;
  function visit(value: unknown, depth: number): unknown {
    if (++nodes > MAX_NODES || depth > 24) limited();
    if (value === null || typeof value === 'boolean') return value;
    if (typeof value === 'string') {
      textLength += value.length;
      if (textLength > MAX_TEXT) limited();
      return value;
    }
    if (typeof value === 'number') {
      if (!Number.isFinite(value)) invalid();
      return value;
    }
    if (typeof value !== 'object' || ancestors.has(value)) invalid();
    const array = Array.isArray(value);
    const prototype = Object.getPrototypeOf(value);
    if (
      array ? prototype !== Array.prototype : prototype !== Object.prototype && prototype !== null
    )
      invalid();
    const descriptors = Object.getOwnPropertyDescriptors(value);
    const own = Reflect.ownKeys(descriptors);
    if (own.some((key) => typeof key !== 'string')) invalid();
    ancestors.add(value);
    if (array) {
      const length = descriptors.length;
      if (
        !length ||
        !Object.hasOwn(length, 'value') ||
        !Number.isSafeInteger(length.value) ||
        length.value < 0
      )
        invalid();
      if (length.value > MAX_NODES || own.length !== length.value + 1) invalid();
      const output: unknown[] = [];
      for (let index = 0; index < length.value; index++) {
        const property = descriptors[String(index)];
        if (!property || !property.enumerable || !Object.hasOwn(property, 'value')) invalid();
        output.push(visit(property.value, depth + 1));
      }
      ancestors.delete(value);
      return output;
    }
    const output: Record<string, unknown> = {};
    for (const key of own as string[]) {
      const property = descriptors[key]!;
      if (!property.enumerable || !Object.hasOwn(property, 'value')) invalid();
      Object.defineProperty(output, key, {
        value: visit(property.value, depth + 1),
        enumerable: true,
        writable: true,
        configurable: true,
      });
    }
    ancestors.delete(value);
    return output;
  }
  return visit(input, 0);
}
function freeze<T>(value: T): T {
  if (value !== null && typeof value === 'object') {
    for (const child of Object.values(value)) freeze(child);
    Object.freeze(value);
  }
  return value;
}
function evidence<T>(
  value: unknown,
  valid: (candidate: unknown) => candidate is T,
): value is SessionLedgerEvidence<T> {
  if (!record(value) || !identifier(value.revision)) return false;
  return value.status === 'known'
    ? keys(value, ['status', 'value', 'revision']) && valid(value.value)
    : value.status === 'unknown' &&
        keys(value, ['status', 'reason', 'revision']) &&
        reason(value.reason);
}
const isBoolean = (value: unknown): value is boolean => typeof value === 'boolean';
function context(value: unknown): value is SessionLedgerContext {
  return (
    keys(value, ['tenantId', 'coCode', 'lcCode', 'coYear', 'identity']) &&
    identifier(value.tenantId, 24) &&
    identifier(value.coCode, 2) &&
    identifier(value.lcCode, 2) &&
    identifier(value.coYear, 10) &&
    identifier(value.identity)
  );
}
function bootstrap(value: unknown): value is SessionLedgerBootstrap {
  return (
    keys(value, ['completed', 'edition', 'forceCombined']) &&
    evidence(value.completed, isBoolean) &&
    evidence(value.edition, isEdition) &&
    evidence(value.forceCombined, isBoolean)
  );
}
function command(value: unknown): value is SessionLedgerCommand {
  return (
    keys(value, ['kind', 'letter']) &&
    typeof value.letter === 'string' &&
    value.letter.length === 1 &&
    (value.kind === 'special'
      ? isMode(value.letter)
      : value.kind === 'alias' && /^[D-Z]$/.test(value.letter))
  );
}
function catalog(value: unknown): value is SessionLedgerCatalog | null {
  if (value === null) return true;
  if (
    !keys(value, ['company', 'complete', 'revision', 'rows']) ||
    typeof value.company !== 'string' ||
    value.company.length > 255 ||
    typeof value.complete !== 'boolean' ||
    !identifier(value.revision) ||
    !Array.isArray(value.rows) ||
    value.rows.length > MAX_CATALOG_ROWS
  )
    return false;
  return value.rows.every(
    (row) =>
      keys(row, ['identity', 'revision', 'raw']) &&
      identifier(row.identity) &&
      identifier(row.revision) &&
      keys(row.raw, ['CO_CODE', 'CON_CODE', 'CON_NAME']) &&
      Object.values(row.raw).every(
        (cell) => cell === null || (typeof cell === 'string' && cell.length <= 255),
      ),
  );
}
const diagnostic = (
  code: SessionLedgerDiagnosticCode,
  message: string,
): SessionLedgerDiagnostic => ({ code, message });
type Decision =
  | { mode: SessionLedgerMode; outcome: 'applied' | 'retained'; branch: SessionLedgerBranch }
  | { diagnostic: SessionLedgerDiagnostic };
function bootstrapDecision(facts: SessionLedgerBootstrap): {
  mode: SessionLedgerMode | null;
  diagnostic?: SessionLedgerDiagnostic;
} {
  if (facts.completed.status !== 'known' || !facts.completed.value)
    return {
      mode: null,
      diagnostic: diagnostic(
        'bootstrap-incomplete',
        'A successfully completed company-open observation is required.',
      ),
    };
  if (facts.edition.status !== 'known')
    return {
      mode: null,
      diagnostic: diagnostic(
        'bootstrap-edition-unresolved',
        'The edition used during company opening is unresolved.',
      ),
    };
  // MS_OPNCOMP1459–1476: both branches endC for reached non-A/E editions.
  if (facts.edition.value !== 'A' && facts.edition.value !== 'E') return { mode: 'C' };
  if (facts.forceCombined.status !== 'known')
    return {
      mode: null,
      diagnostic: diagnostic(
        'bootstrap-exception-unresolved',
        'The company-open combined-mode exception is unresolved.',
      ),
    };
  return { mode: facts.forceCombined.value ? 'C' : 'A' };
}
const normalized = (value: string | null): string | null =>
  value === null ? null : value.trim().toUpperCase();
function transitionDecision(
  previousMode: SessionLedgerMode | null,
  completed: SessionLedgerEvidence<boolean>,
  currentEdition: SessionLedgerEvidence<SessionLedgerEdition>,
  semanticCommand: SessionLedgerCommand,
  observation: SessionLedgerCatalog | null,
): Decision {
  if (completed.status !== 'known' || !completed.value)
    return {
      diagnostic: diagnostic(
        'bootstrap-incomplete',
        'A successfully completed company-open observation is required before a command.',
      ),
    };
  if (currentEdition.status !== 'known')
    return {
      diagnostic: diagnostic(
        'command-edition-unresolved',
        'The current command edition is unresolved; bootstrap edition is not a substitute.',
      ),
    };
  if (currentEdition.value !== 'A' && currentEdition.value !== 'E')
    return {
      diagnostic: diagnostic(
        'command-edition-unavailable',
        'This command profile requires the current edition A or E.',
      ),
    };
  if (!observation || !observation.complete)
    return {
      diagnostic: diagnostic(
        'catalog-unavailable',
        'A complete trusted mode catalog is required; an unknown set is not an absent result.',
      ),
    };
  if (observation.company !== '01')
    return {
      diagnostic: diagnostic(
        'catalog-company-unsupported',
        'The source mode catalog must identify literal company01.',
      ),
    };
  const identities = new Set<string>();
  for (const row of observation.rows) {
    if (identities.has(row.identity))
      return {
        diagnostic: diagnostic(
          'catalog-identity-ambiguous',
          'The catalog repeats a physical observation identity.',
        ),
      };
    identities.add(row.identity);
  }
  // True foreign-company and SQL NULL-company rows do not satisfy the source
  // predicate. Relevant padded company/key candidates are refused, not merged.
  const sourceRows = observation.rows.filter((row) => normalized(row.raw.CO_CODE) === '01');
  if (semanticCommand.kind === 'special') {
    const sentinel = sourceRows.filter((row) => normalized(row.raw.CON_CODE) === 'A');
    if (
      sentinel.length > 1 ||
      sentinel.some((row) => row.raw.CO_CODE !== '01' || row.raw.CON_CODE !== 'A')
    )
      return {
        diagnostic: diagnostic(
          'sentinel-ambiguous',
          'The relevant company01 mode sentinel is duplicate or noncanonical.',
        ),
      };
    if (sentinel.length === 0)
      return { mode: semanticCommand.letter, outcome: 'applied', branch: 'direct-special' };
  }
  const aliases = sourceRows.filter(
    (row) => normalized(row.raw.CON_NAME) === semanticCommand.letter,
  );
  if (
    aliases.length > 1 ||
    aliases.some((row) => row.raw.CO_CODE !== '01' || row.raw.CON_NAME !== semanticCommand.letter)
  )
    return {
      diagnostic: diagnostic(
        'alias-ambiguous',
        'The relevant company01 command alias is duplicate or noncanonical.',
      ),
    };
  if (aliases.length === 1) {
    const output = aliases[0]!.raw.CON_CODE;
    if (!isMode(output))
      return {
        diagnostic: diagnostic(
          'alias-output-unsupported',
          'The selected alias does not contain an exact supported A/B/C mode.',
        ),
      };
    return {
      mode: output,
      outcome: 'applied',
      branch: semanticCommand.kind === 'special' ? 'mapped-special' : 'mapped-alias',
    };
  }
  if (semanticCommand.kind === 'special')
    return { mode: 'A', outcome: 'applied', branch: 'special-fallback' };
  if (previousMode === null)
    return {
      diagnostic: diagnostic(
        'previous-mode-unresolved',
        'A missing general alias cannot retain an unresolved previous mode.',
      ),
    };
  return { mode: previousMode, outcome: 'retained', branch: 'alias-retained' };
}

/** Recheck semantic provenance as well as shape. For example, mode B cannot
 * follow only a bootstrap A observation without a consistent transition.
 * Compatible omitted/reordered or independently supplied history cannot be
 * detected here; a trusted adapter must establish authority and freshness.
 */
function state(value: unknown): value is SessionLedgerModeState {
  if (
    !keys(value, [
      'version',
      'profile',
      'context',
      'status',
      'mode',
      'reason',
      'bootstrap',
      'history',
    ]) ||
    value.version !== SESSION_LEDGER_MODE_VERSION ||
    value.profile !== SESSION_LEDGER_MODE_PROFILE ||
    !context(value.context) ||
    !bootstrap(value.bootstrap) ||
    !Array.isArray(value.history) ||
    value.history.length > MAX_HISTORY
  )
    return false;
  const initial = bootstrapDecision(value.bootstrap);
  let mode = initial.mode;
  for (const proof of value.history) {
    if (
      !keys(proof, [
        'commandEdition',
        'command',
        'catalog',
        'previousMode',
        'nextMode',
        'outcome',
        'branch',
      ]) ||
      !evidence(proof.commandEdition, isEdition) ||
      !command(proof.command) ||
      !catalog(proof.catalog) ||
      proof.catalog === null ||
      proof.previousMode !== mode ||
      !isMode(proof.nextMode)
    )
      return false;
    const decision = transitionDecision(
      mode,
      value.bootstrap.completed,
      proof.commandEdition,
      proof.command,
      proof.catalog,
    );
    if (
      'diagnostic' in decision ||
      proof.nextMode !== decision.mode ||
      proof.outcome !== decision.outcome ||
      proof.branch !== decision.branch
    )
      return false;
    mode = decision.mode;
  }
  return (
    value.mode === mode &&
    (mode === null
      ? value.status === 'unresolved' && value.reason === initial.diagnostic?.message
      : value.status === 'resolved' && value.reason === null)
  );
}
function invalidDiagnostic(error: unknown): SessionLedgerDiagnostic {
  return error instanceof BoundaryError
    ? diagnostic(error.code, error.message)
    : diagnostic('invalid-input', 'The trusted observation could not be read as plain data.');
}
export function bootstrapSessionLedgerMode(input: unknown): SessionLedgerBootstrapResult {
  try {
    const data = detach(input);
    if (!keys(data, ['context', 'completed', 'edition', 'forceCombined']) || !context(data.context))
      invalid();
    const facts = {
      completed: data.completed,
      edition: data.edition,
      forceCombined: data.forceCombined,
    };
    if (!bootstrap(facts)) invalid();
    const decision = bootstrapDecision(facts);
    const output: SessionLedgerModeState = {
      version: SESSION_LEDGER_MODE_VERSION,
      profile: SESSION_LEDGER_MODE_PROFILE,
      context: data.context,
      status: decision.mode === null ? 'unresolved' : 'resolved',
      mode: decision.mode,
      reason: decision.diagnostic?.message ?? null,
      bootstrap: facts,
      history: [],
    };
    return freeze({
      status: output.status,
      state: output,
      diagnostics: decision.diagnostic ? [decision.diagnostic] : [],
    });
  } catch (error) {
    return freeze({
      status: 'invalid-input',
      state: null,
      diagnostics: [invalidDiagnostic(error)],
    });
  }
}

/** Return detached valid previous state even when a sibling input is malformed;
 * never access a getter merely to recover it. No invalid prior state is echoed.
 */
function previousObservation(input: unknown): SessionLedgerModeState | null {
  try {
    if (!record(input)) return null;
    const prototype = Object.getPrototypeOf(input);
    if (prototype !== Object.prototype && prototype !== null) return null;
    const descriptor = Object.getOwnPropertyDescriptor(input, 'previous');
    if (!descriptor || !descriptor.enumerable || !Object.hasOwn(descriptor, 'value')) return null;
    const previous = detach(descriptor.value);
    return state(previous) ? previous : null;
  } catch {
    return null;
  }
}
export function transitionSessionLedgerMode(input: unknown): SessionLedgerTransitionResult {
  const previous = previousObservation(input);
  try {
    const data = detach(input);
    if (!keys(data, ['previous', 'commandEdition', 'command', 'catalog'])) invalid();
    if (!previous)
      return freeze({
        status: 'invalid-input',
        state: null,
        diagnostics: [
          diagnostic(
            'invalid-previous-state',
            'A complete, consistent previous mode observation is required.',
          ),
        ],
      });
    if (
      !evidence(data.commandEdition, isEdition) ||
      !command(data.command) ||
      !catalog(data.catalog)
    )
      invalid();
    const decision = transitionDecision(
      previous.mode,
      previous.bootstrap.completed,
      data.commandEdition,
      data.command,
      data.catalog,
    );
    if ('diagnostic' in decision)
      return freeze({ status: 'unsupported', state: previous, diagnostics: [decision.diagnostic] });
    if (previous.history.length >= MAX_HISTORY)
      return freeze({
        status: 'unsupported',
        state: previous,
        diagnostics: [
          diagnostic(
            'history-limit',
            'The semantic history reached 100 accepted commands; a new trusted context is required.',
          ),
        ],
      });
    const proof: SessionLedgerTransitionProof = {
      commandEdition: data.commandEdition,
      command: data.command,
      catalog: data.catalog!,
      previousMode: previous.mode,
      nextMode: decision.mode,
      outcome: decision.outcome,
      branch: decision.branch,
    };
    const next: SessionLedgerModeState = {
      ...previous,
      status: 'resolved',
      mode: decision.mode,
      reason: null,
      history: [...previous.history, proof],
    };
    // Appending proof adds bounded transport data. Refuse atomically if the
    // resulting state could not itself be read as a subsequent observation.
    detach(next);
    return freeze({
      status: decision.outcome,
      state: next,
      diagnostics: [] as const,
    });
  } catch (error) {
    return freeze({
      status: 'invalid-input',
      state: previous,
      diagnostics: [invalidDiagnostic(error)],
    });
  }
}
