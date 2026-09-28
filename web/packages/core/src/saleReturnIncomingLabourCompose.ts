import {
  copySaleReturnIncomingLabour,
  type SaleReturnIncomingLabourScope,
  type SaleReturnIncomingLabourObservation,
  type SaleReturnIncomingLabourNextEvent,
} from "./saleReturnIncomingLabour.js";
import {
  createSaleReturnIncomingAggregateState,
  reduceSaleReturnIncomingAggregate,
  SALE_RETURN_INCOMING_AGGREGATE_VERSION,
  type SaleReturnIncomingAggregateState,
  type SaleReturnIncomingAggregateContext,
} from "./saleReturnIncomingAggregate.js";
import type { SaleReturnIncomingPolicy } from "./saleReturnIncoming.js";

/** TR_SALE_RTN4248–4380 then4866–5158: one resolved code operation is
 * copy -> row -> incoming fold -> bill. Exact decimal mathematical profile,
 * not Windows runtime equivalence, source-row admission or write authority. */
export const SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION =
  "primary-incoming-labour-compose-v1" as const;
export const SALE_RETURN_INCOMING_LABOUR_COMPOSE_PROFILE =
  "atomic-resolved-copy-row-fold-bill-v1" as const;
export interface SaleReturnIncomingLabourComposeInput {
  readonly state: SaleReturnIncomingAggregateState;
  readonly scope: SaleReturnIncomingLabourScope;
  readonly rowIdentity: string;
  readonly field: 13 | 29;
  readonly editorText: string;
  readonly expectedObservationVersion: string;
  readonly observation: SaleReturnIncomingLabourObservation;
  readonly rowPolicy: SaleReturnIncomingPolicy;
  readonly context: SaleReturnIncomingAggregateContext;
}
export interface SaleReturnIncomingLabourComposeDiagnostic {
  readonly origin: "input" | "copy" | "calculation";
  readonly code: string;
  readonly message: string;
  readonly stage?: string;
  readonly column?: number;
}
export interface SaleReturnIncomingLabourComposeAttempt {
  readonly rowIdentity: string | null;
  readonly field: number | null;
  readonly editorText: string | null;
}
interface ResultBase {
  readonly version: typeof SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION;
  readonly profile: typeof SALE_RETURN_INCOMING_LABOUR_COMPOSE_PROFILE;
}
export type SaleReturnIncomingLabourComposeResult =
  | (ResultBase & {
      readonly status: "applied";
      readonly state: SaleReturnIncomingAggregateState;
      /** Pre-calculation copy patch, not a final visible-cell diff or save payload. */
      readonly visiblePatch: Readonly<Record<number, string>>;
      readonly nextEvent: SaleReturnIncomingLabourNextEvent;
      readonly observation: SaleReturnIncomingLabourObservation;
      readonly aggregateApplied: boolean;
      readonly billApplied: true;
      readonly taxRecalculated: boolean;
      readonly diagnostics: readonly [];
    })
  | (ResultBase & {
      readonly status: "rejected" | "lookup-required";
      readonly state: SaleReturnIncomingAggregateState | null;
      readonly visiblePatch: null;
      readonly nextEvent: null;
      readonly observation: null;
      readonly aggregateApplied: false;
      readonly billApplied: false;
      readonly taxRecalculated: false;
      readonly attempted: SaleReturnIncomingLabourComposeAttempt;
      readonly diagnostics: readonly SaleReturnIncomingLabourComposeDiagnostic[];
    });

const ownRecord = (value: unknown): value is Record<string, unknown> => {
  if (value === null || typeof value !== "object" || Array.isArray(value))
    return false;
  const prototype = Object.getPrototypeOf(value);
  return prototype === Object.prototype || prototype === null;
};
const exact = (
  value: unknown,
  keys: readonly string[],
): value is Record<string, unknown> =>
  ownRecord(value) &&
  Object.keys(value).length === keys.length &&
  keys.every((key) => Object.hasOwn(value, key));
const stringRaw = (value: unknown): boolean =>
  ownRecord(value) &&
  Object.values(value).every(
    (cell) => cell === null || typeof cell === "string",
  );
const policyKeys = [
  "saleAmountType",
  "labourRoundingDecimals",
  "labourIncludesGhat",
  "generateLabourRate",
  "fineColumnWidth",
];
const contextKeys = [
  "taxRoundingDecimals",
  "editOpen",
  "upDown",
  "openingBalance",
];
const commandKeys = [
  "state",
  "scope",
  "rowIdentity",
  "field",
  "editorText",
  "expectedObservationVersion",
  "observation",
  "rowPolicy",
  "context",
];

/** These resource limits are a pure transport profile, not desktop row limits.
 * Descriptors avoid invoking getters; reflection errors are contained. Repeated
 * acyclic references are detached independently. No caller-owned object freezes. */
function detach(value: unknown): unknown {
  const ancestors = new Set<object>();
  let nodes = 0,
    text = 0;
  const visit = (item: unknown, depth: number): unknown => {
    if (++nodes > 100000 || depth > 24) throw new Error("input-limit");
    if (typeof item === "string") {
      text += item.length;
      if (text > 1000000) throw new Error("input-limit");
      return item;
    }
    if (item === null || typeof item === "boolean") return item;
    if (typeof item === "number" && Number.isFinite(item)) return item;
    if (item === null || typeof item !== "object" || ancestors.has(item))
      throw new Error("plain-data-required");
    const array = Array.isArray(item);
    if (
      array ? Object.getPrototypeOf(item) !== Array.prototype : !ownRecord(item)
    )
      throw new Error("plain-data-required");
    const keys = Reflect.ownKeys(item);
    const entries = array ? keys.filter((key) => key !== "length") : keys;
    const length = array
      ? Object.getOwnPropertyDescriptor(item, "length")?.value
      : undefined;
    if (
      array &&
      (entries.length !== length ||
        entries.some((key, index) => key !== String(index)))
    )
      throw new Error("dense-array-required");
    ancestors.add(item);
    const output: unknown[] | Record<string, unknown> = array ? [] : {};
    for (const key of entries) {
      if (typeof key !== "string") throw new Error("plain-data-required");
      text += key.length;
      if (text > 1000000) throw new Error("input-limit");
      const descriptor = Object.getOwnPropertyDescriptor(item, key);
      if (!descriptor?.enumerable || !Object.hasOwn(descriptor, "value"))
        throw new Error("plain-data-required");
      Object.defineProperty(output, key, {
        value: visit(descriptor.value, depth + 1),
        enumerable: true,
        writable: true,
        configurable: true,
      });
    }
    ancestors.delete(item);
    return output;
  };
  return visit(value, 0);
}
function freeze<T>(value: T): T {
  if (value && typeof value === "object") {
    Object.values(value).forEach(freeze);
    Object.freeze(value);
  }
  return value;
}
const nullableInteger = (value: unknown) =>
  value === null || Number.isInteger(value);
function policyHistory(value: unknown): boolean {
  return (
    exact(value, policyKeys) &&
    typeof value.saleAmountType === "string" &&
    Number.isInteger(value.labourRoundingDecimals) &&
    typeof value.labourIncludesGhat === "boolean" &&
    typeof value.generateLabourRate === "boolean" &&
    nullableInteger(value.fineColumnWidth)
  );
}
function contextShape(value: unknown): value is Record<string, unknown> {
  if (!exact(value, contextKeys) || !ownRecord(value.openingBalance))
    return false;
  return value.openingBalance.status === "resolved"
    ? exact(value.openingBalance, ["status", "amount", "observationIdentity"])
    : value.openingBalance.status === "unavailable" &&
        exact(value.openingBalance, ["status", "reason"]);
}
function contextHistory(value: unknown): boolean {
  if (
    !contextShape(value) ||
    !Number.isInteger(value.taxRoundingDecimals) ||
    typeof value.editOpen !== "boolean" ||
    typeof value.upDown !== "boolean"
  )
    return false;
  const opening = value.openingBalance as Record<string, unknown>;
  return opening.status === "resolved"
    ? typeof opening.amount === "string" &&
        typeof opening.observationIdentity === "string"
    : typeof opening.reason === "string";
}
function eventHistory(value: unknown): boolean {
  if (!ownRecord(value) || typeof value.rowIdentity !== "string") return false;
  if (value.kind === "calculateAfterCopy")
    return (
      exact(value, [
        "kind",
        "rowIdentity",
        "activeColumn",
        "editorText",
        "cause",
      ]) &&
      Number.isInteger(value.activeColumn) &&
      typeof value.editorText === "string" &&
      typeof value.cause === "string" &&
      [
        "sourceSelection",
        "labourCodeSelection",
        "tagLabourCodeSelection",
      ].includes(value.cause)
    );
  return (
    value.kind === "leaveCell" &&
    exact(value, ["kind", "rowIdentity", "column", "text", "context"]) &&
    Number.isInteger(value.column) &&
    typeof value.text === "string" &&
    exact(value.context, [
      "currentRow",
      "clearing",
      "editorVisible",
      "committedColumnWidth",
    ]) &&
    Number.isInteger(value.context.currentRow) &&
    typeof value.context.clearing === "boolean" &&
    typeof value.context.editorVisible === "boolean" &&
    nullableInteger(value.context.committedColumnWidth)
  );
}
function stateValue(value: unknown): value is SaleReturnIncomingAggregateState {
  if (
    !exact(value, [
      "version",
      "raw",
      "rows",
      "totals",
      "bill",
      "outgoingTotal24",
      "journal",
    ]) ||
    value.version !== SALE_RETURN_INCOMING_AGGREGATE_VERSION ||
    !stringRaw(value.raw) ||
    !Array.isArray(value.rows) ||
    !exact(value.totals, ["cells", "totCrFine", "prOthAmtLess"]) ||
    !exact(value.bill, [
      "matrix",
      "oldNetAmt",
      "oldTaxPrc",
      "outgoingRounded",
      "incomingRounded",
      "closing",
    ]) ||
    !ownRecord(value.bill.closing) ||
    !Array.isArray(value.journal)
  )
    return false;
  const closing = value.bill.closing;
  if (
    !(closing.status === "resolved"
      ? exact(closing, ["status", "amount", "label", "color"])
      : closing.status === "unavailable" &&
        exact(closing, ["status", "amount", "label", "color", "reason"]))
  )
    return false;
  for (const row of value.rows) {
    if (
      !exact(row, ["ordinal", "state"]) ||
      !exact(row.state, [
        "rowIdentity",
        "raw",
        "visible",
        "caches",
        "journal",
      ]) ||
      !Array.isArray(row.state.journal)
    )
      return false;
    if (
      !row.state.journal.every(
        (entry) =>
          exact(entry, ["event", "calculated", "policy"]) &&
          typeof entry.calculated === "boolean" &&
          eventHistory(entry.event) &&
          policyHistory(entry.policy),
      )
    )
      return false;
  }
  if (
    !value.journal.every(
      (entry) =>
        exact(entry, [
          "event",
          "rowPolicy",
          "context",
          "rowCalculated",
          "aggregateApplied",
          "billApplied",
          "taxRecalculated",
        ]) &&
        eventHistory(entry.event) &&
        policyHistory(entry.rowPolicy) &&
        contextHistory(entry.context) &&
        [
          "rowCalculated",
          "aggregateApplied",
          "billApplied",
          "taxRecalculated",
        ].every((key) => typeof entry[key] === "boolean"),
    )
  )
    return false;
  // Validation only: the constructor does no calculation. Discard its empty
  // journal and retain the complete detached original, never its new state.
  return (
    createSaleReturnIncomingAggregateState(
      value as unknown as SaleReturnIncomingAggregateState,
    ).status === "ready"
  );
}
function recoverState(input: unknown): SaleReturnIncomingAggregateState | null {
  try {
    if (input === null || typeof input !== "object") return null;
    const descriptor = Object.getOwnPropertyDescriptor(input, "state");
    if (!descriptor?.enumerable || !Object.hasOwn(descriptor, "value"))
      return null;
    const state = detach(descriptor.value);
    return stateValue(state) ? freeze(state) : null;
  } catch {
    return null;
  }
}
function attempt(input: unknown): SaleReturnIncomingLabourComposeAttempt {
  const output: {
    rowIdentity: string | null;
    field: number | null;
    editorText: string | null;
  } = { rowIdentity: null, field: null, editorText: null };
  try {
    if (input === null || typeof input !== "object") return output;
    for (const key of ["rowIdentity", "field", "editorText"] as const) {
      const descriptor = Object.getOwnPropertyDescriptor(input, key);
      if (!descriptor?.enumerable || !Object.hasOwn(descriptor, "value"))
        continue;
      const value: unknown = descriptor.value;
      if (key === "field") {
        if (typeof value === "number" && Number.isFinite(value))
          output.field = value;
      } else if (typeof value === "string" && value.length <= 256)
        output[key] = value;
    }
  } catch {
    /* Reflection refusal must not hide a separately recovered valid state. */
  }
  return output;
}

/** One explicit internal operation, no lookup, retry, callback inference or save.
 * Unsupported downstream results always roll back to the pre-copy whole state. */
export function composeSaleReturnIncomingLabour(
  input: unknown,
): SaleReturnIncomingLabourComposeResult {
  const original = recoverState(input);
  const attempted = attempt(input);
  const reject = (
    diagnostic: SaleReturnIncomingLabourComposeDiagnostic,
    status: "rejected" | "lookup-required" = "rejected",
  ): SaleReturnIncomingLabourComposeResult =>
    freeze({
      version: SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION,
      profile: SALE_RETURN_INCOMING_LABOUR_COMPOSE_PROFILE,
      status,
      state: original,
      visiblePatch: null,
      nextEvent: null,
      observation: null,
      aggregateApplied: false,
      billApplied: false,
      taxRecalculated: false,
      attempted,
      diagnostics: [diagnostic],
    });
  let data: unknown;
  try {
    data = detach(input);
  } catch {
    return reject({
      origin: "input",
      code: "invalid-input",
      message: "A bounded, detached plain-data command is required.",
    });
  }
  if (!original)
    return reject({
      origin: "input",
      code: "invalid-state",
      message:
        "A complete ordered aggregate, raw observation and both journals are required.",
    });
  if (
    !exact(data, commandKeys) ||
    !exact(data.rowPolicy, policyKeys) ||
    !contextShape(data.context)
  )
    return reject({
      origin: "input",
      code: "invalid-input",
      message:
        "The exact internal command, row policy and phase envelope are required.",
    });
  const command = data;
  const index = original.rows.findIndex(
    (row) => row.state.rowIdentity === command.rowIdentity,
  );
  if (index < 0)
    return reject({
      origin: "input",
      code: "row-identity-conflict",
      message:
        "Select the complete saved row identity, not its visual ordinal.",
    });
  const selected = original.rows[index]!;
  const copied = copySaleReturnIncomingLabour({
    scope: data.scope,
    rowIdentity: data.rowIdentity,
    state: selected.state,
    field: data.field,
    editorText: data.editorText,
    expectedObservationVersion: data.expectedObservationVersion,
    observation: data.observation,
  });
  if (copied.status !== "ready") {
    const diagnostic = copied.diagnostics[0]!;
    return reject(
      { origin: "copy", code: diagnostic.code, message: diagnostic.message },
      copied.status === "lookup-required" ? "lookup-required" : "rejected",
    );
  }
  try {
    const temporary: SaleReturnIncomingAggregateState = {
      ...original,
      rows: original.rows.map((row, position) =>
        position === index
          ? { ordinal: row.ordinal, state: copied.state }
          : row,
      ),
    };
    const calculated = reduceSaleReturnIncomingAggregate(
      temporary,
      copied.nextEvent,
      data.rowPolicy as unknown as SaleReturnIncomingPolicy,
      data.context as unknown as SaleReturnIncomingAggregateContext,
    );
    if (calculated.status === "rejected")
      return reject({ origin: "calculation", ...calculated.diagnostic });
    if (calculated.status === "skipped" || !calculated.billApplied)
      return reject({
        origin: "calculation",
        code: "calculation-skipped",
        message:
          "A resolved labour selection requires its complete row and bill callbacks.",
      });
    const tail = calculated.state.journal.at(-1)!;
    const output: SaleReturnIncomingLabourComposeResult = {
      version: SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION,
      profile: SALE_RETURN_INCOMING_LABOUR_COMPOSE_PROFILE,
      status: "applied",
      state: calculated.state,
      visiblePatch: copied.visiblePatch,
      nextEvent: copied.nextEvent,
      observation: copied.observation,
      aggregateApplied: calculated.aggregateApplied,
      billApplied: true,
      taxRecalculated: tail.taxRecalculated,
      diagnostics: [],
    };
    // Output closure: a growing event journal must remain a valid bounded state
    // for the next explicit operation. No partially successful output escapes.
    const nextInput = detach({ ...data, state: calculated.state });
    if (!ownRecord(nextInput) || !stateValue(nextInput.state))
      throw new Error("output-limit");
    return freeze(detach(output) as SaleReturnIncomingLabourComposeResult);
  } catch {
    return reject({
      origin: "calculation",
      code: "unsupported-composition",
      message:
        "The complete calculated result cannot be safely represented in this bounded profile.",
    });
  }
}
