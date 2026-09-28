import { Decimal } from "decimal.js";

/** TR_SALE_RTN13072–13124,13901–14229. Supplied observation comparison only;
 * no caller label/token creates authority or qualifies source clock conversion. */
export const SALE_RETURN_N_BAR_COMPANIONS_VERSION =
  "primary-incoming-n-bar-companions-v1";
const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
const CONTEXT = [
  "CO_CODE",
  "LC_CODE",
  "CO_YEAR",
  "CO_BOOK",
  "VCH_NO",
  "VCH_DATE",
  "STK_DATE",
  "HD_VCH_NO",
  "AC_CODE",
  "VCH_TYPE",
  "INOUT_TYPE",
  "BOOK_NAME",
  "VCH_TIME",
  "EMP_CODE",
  "VCH_DESC",
  "MAIN_USER",
] as const;
const SCOPE = ["CO_CODE", "LC_CODE", "CO_YEAR", "CO_BOOK", "VCH_NO"] as const;
const HEADER_CONTEXT = [
  "CO_CODE",
  "LC_CODE",
  "CO_YEAR",
  "CO_BOOK",
  "VCH_NO",
  "VCH_DATE",
  "VCH_TIME",
  "EMP_CODE",
  "VCH_DESC",
  "MAIN_USER",
] as const;
const PARENT_CONTEXT = CONTEXT.filter(
  (k) => k !== "EMP_CODE" && k !== "VCH_DESC",
);
const NUMERIC = {
  SR_NO: 0,
  OLD_SRNO: 51,
  ITM_PCS: 9,
  ITM_GWT: 10,
  ITM_OTH_WT: 11,
  ITM_NWT: 12,
  ITM_GHT_PRC: 14,
  ITM_GHT_WT: 15,
  ITM_TOUCH: 16,
  ITM_WEST_PRC: 17,
  ITM_FINE: 18,
  KR_GHT_WT: 15,
  KR_TOUCH: 16,
  KR_WEST_PRC: 17,
  KR_FINE: 18,
  LBR_PRC: 30,
  LBR_RATE: 31,
  LBR_AMT: 32,
  OTH_AMT: 33,
  KR_COST: 34,
  TAG_COST: 34,
  ITM_MRP: 35,
  VCH_SRNO: 40,
  TAG_SRNO: 56,
  HM_ID_WT: 62,
  HM_ID2_WT: 63,
  HM_ID3_WT: 64,
  HM_ID4_WT: 65,
} as const;
const TEXT = {
  IT_CODE: 1,
  TAG_NO: 2,
  TBL_CODE: 4,
  DESIGN_NO: 5,
  ITM_STYLE: 6,
  ITM_SIZE: 7,
  HM_ID: 8,
  LBR_TYPE: 22,
  LBR_CODE: 29,
  KR_NAME: 39,
  RATE_TYPE: 44,
  IT_TYPE: 43,
  PR_CODE: 52,
  TAG_TYPE: 54,
  APR_ISU: 50,
  EMP_ISU: 68,
  DESIGN_IMG_ID: 69,
  HM_ID2: 59,
  HM_ID3: 60,
  HM_ID4: 61,
  DATA_TYPE: 70,
} as const;
const ZERO = [
  "ITM_RATE",
  "ITM_AMT",
  "KR_LBR_RATE",
  "KR_LBR_AMT",
  "KR_OTH_AMT",
] as const;
const NUMERIC_TARGETS = new Set([...Object.keys(NUMERIC), ...ZERO]);
const TOTAL_KEYS = Array.from({ length: 71 }, (_, i) => String(i));
const VISIBLE_KEYS = TOTAL_KEYS.filter(
  (k) => !["45", "46", "47", "48", "49", "58", "66", "67"].includes(k),
);
const REQUIREMENTS = Object.freeze([
  "trusted-context-source-and-target-representation-qualification",
  "server-owned-replay-and-full-poststate-admission",
  "fresh-session-update-document-configuration-master-and-save-guards",
  "complete-effects-children-references-and-physical-membership-versions",
  "single-serializable-atomic-writer",
] as const);

export type SaleReturnNBarRaw = Readonly<Record<string, string | null>>;
export type SaleReturnNBarContext =
  | { readonly status: "unavailable"; readonly reason: string }
  | {
      readonly status: "qualified";
      readonly observationIdentity: string;
      readonly values: Readonly<Record<(typeof CONTEXT)[number], string>>;
    };
export interface SaleReturnNBarObservation {
  readonly rowId: string;
  readonly version: string;
  readonly raw: SaleReturnNBarRaw;
}
export interface SaleReturnNBarObserved {
  readonly barData: readonly SaleReturnNBarObservation[];
  readonly barDetl: readonly SaleReturnNBarObservation[];
}
export interface SaleReturnNBarPhaseInput {
  readonly visible: Readonly<Record<string, string>>;
  readonly incomingTotals: Readonly<Record<string, string>>;
}
export interface SaleReturnNBarInput {
  readonly rowIdentity: string;
  readonly tenantId: string;
  readonly context: SaleReturnNBarContext;
  readonly before: SaleReturnNBarPhaseInput;
  readonly after: SaleReturnNBarPhaseInput;
  readonly observed: SaleReturnNBarObserved;
}
export interface SaleReturnNBarProjection {
  readonly predicates: Readonly<{ barData: boolean; barDetl: boolean }>;
  readonly barData: Readonly<Record<string, string>> | null;
  readonly barDetl: Readonly<Record<string, string>> | null;
}
export type SaleReturnNBarCode =
  | "invalid-input"
  | "invalid-context"
  | "context-unavailable"
  | "invalid-phase"
  | "invalid-observation"
  | "invalid-decimal"
  | "unsupported-precision"
  | "unsupported-instance-allocation"
  | "unsupported-n-tag-profile"
  | "unsupported-row-identity"
  | "companion-membership-change"
  | "unsupported-companion-membership"
  | "companion-value-change"
  | "observed-membership-mismatch"
  | "observation-identity-mismatch"
  | "observation-value-mismatch";
export interface SaleReturnNBarDiagnostic {
  readonly code: SaleReturnNBarCode;
  readonly message: string;
  readonly field?: string;
  readonly table?: "barData" | "barDetl";
}
export interface SaleReturnNBarDifference {
  readonly table: "barData" | "barDetl";
  readonly field: string;
  readonly before: string;
  readonly after: string;
}
export interface SaleReturnNBarResult {
  readonly version: typeof SALE_RETURN_N_BAR_COMPANIONS_VERSION;
  readonly status: "matched" | "unsupported";
  readonly canCommit: false;
  readonly rowIdentity: string | null;
  readonly tenantId: string | null;
  readonly context: SaleReturnNBarContext | null;
  readonly observed: SaleReturnNBarObserved | null;
  readonly before: SaleReturnNBarProjection | null;
  readonly after: SaleReturnNBarProjection | null;
  readonly differences: readonly SaleReturnNBarDifference[];
  readonly diagnostics: readonly SaleReturnNBarDiagnostic[];
  readonly requirements: typeof REQUIREMENTS;
}
class Refusal extends Error {
  constructor(
    readonly code: SaleReturnNBarCode,
    message: string,
    readonly field?: string,
    readonly table?: "barData" | "barDetl",
  ) {
    super(message);
  }
}
function fail(
  code: SaleReturnNBarCode,
  message: string,
  field?: string,
  table?: "barData" | "barDetl",
): never {
  throw new Refusal(code, message, field, table);
}
function rec(v: unknown, code: SaleReturnNBarCode): Record<string, unknown> {
  if (
    !v ||
    typeof v !== "object" ||
    Array.isArray(v) ||
    ![Object.prototype, null].includes(Object.getPrototypeOf(v))
  )
    fail(code, "An own-data record is required.");
  const ds = Object.getOwnPropertyDescriptors(v),
    keys = Reflect.ownKeys(ds);
  if (keys.length > 1024 || keys.some((k) => typeof k !== "string"))
    fail(code, "Unsupported record keys or size.");
  const entries: [string, unknown][] = [];
  for (const k of keys as string[]) {
    const d = ds[k]!;
    if (!d.enumerable || !Object.hasOwn(d, "value"))
      fail(code, "Accessors and hidden fields are unsupported.");
    entries.push([k, d.value]);
  }
  return Object.fromEntries(entries);
}
function exact(
  v: Record<string, unknown>,
  keys: readonly string[],
  code: SaleReturnNBarCode,
): void {
  if (
    Object.keys(v).length !== keys.length ||
    keys.some((k) => !Object.hasOwn(v, k))
  )
    fail(code, "The exact complete field set is required.");
}
function text(v: unknown, max = 4096): v is string {
  return typeof v === "string" && v.length <= max;
}
function hash(v: unknown): v is string {
  return text(v, 64) && v.length === 64 && /^[0-9a-f]{64}$/.test(v);
}
function canonical(v: unknown, max: number): v is string {
  return (
    text(v, max) && v.length > 0 && v.trim() === v && !/[^\x20-\x7e]/.test(v)
  );
}
function raw(v: unknown): SaleReturnNBarRaw {
  const r = rec(v, "invalid-observation");
  let size = 0;
  for (const [k, t] of Object.entries(r)) {
    if (!canonical(k, 128) || (t !== null && !text(t, 65536)))
      fail(
        "invalid-observation",
        "Raw cells must be bounded exact string/NULL values.",
      );
    size += k.length + (typeof t === "string" ? t.length : 0);
  }
  if (size > 131072)
    fail("invalid-observation", "Raw observation exceeds its bounded size.");
  return Object.freeze(r) as SaleReturnNBarRaw;
}
function rows(v: unknown): readonly SaleReturnNBarObservation[] {
  if (
    !Array.isArray(v) ||
    Object.getPrototypeOf(v) !== Array.prototype ||
    v.length > 8
  )
    fail(
      "invalid-observation",
      "A bounded dense observation array is required.",
    );
  const ds = Object.getOwnPropertyDescriptors(v);
  if (Reflect.ownKeys(ds).length !== v.length + 1)
    fail("invalid-observation", "Unexpected observation array fields.");
  const result: SaleReturnNBarObservation[] = [];
  for (let i = 0; i < v.length; i++) {
    const d = ds[String(i)];
    if (!d || !d.enumerable || !Object.hasOwn(d, "value"))
      fail(
        "invalid-observation",
        "Sparse/accessor observations are unsupported.",
      );
    const r = rec(d.value, "invalid-observation");
    exact(r, ["rowId", "version", "raw"], "invalid-observation");
    if (
      !canonical(r.rowId, 19) ||
      !/^[1-9]\d*$/.test(r.rowId) ||
      BigInt(r.rowId) > 9223372036854775807n ||
      !hash(r.version)
    )
      fail(
        "invalid-observation",
        "Canonical physical row identity and retained version are required.",
      );
    result.push(
      Object.freeze({ rowId: r.rowId, version: r.version, raw: raw(r.raw) }),
    );
  }
  return Object.freeze(result);
}
function observed(v: unknown): SaleReturnNBarObserved {
  const r = rec(v, "invalid-observation");
  exact(r, ["barData", "barDetl"], "invalid-observation");
  return Object.freeze({ barData: rows(r.barData), barDetl: rows(r.barDetl) });
}
function recoverObserved(v: unknown): SaleReturnNBarObserved | null {
  try {
    if (!v || typeof v !== "object") return null;
    const d = Object.getOwnPropertyDescriptor(v, "observed");
    return d && Object.hasOwn(d, "value") ? observed(d.value) : null;
  } catch {
    return null;
  }
}
function context(v: unknown): SaleReturnNBarContext {
  const c = rec(v, "invalid-context");
  if (c.status === "unavailable") {
    exact(c, ["status", "reason"], "invalid-context");
    if (!text(c.reason) || !c.reason.trim())
      fail("invalid-context", "An unavailable context needs its reason.");
    return Object.freeze({ status: "unavailable", reason: c.reason });
  }
  exact(c, ["status", "observationIdentity", "values"], "invalid-context");
  if (c.status !== "qualified" || !hash(c.observationIdentity))
    fail("invalid-context", "Explicit context qualification is required.");
  const values = rec(c.values, "invalid-context");
  exact(values, CONTEXT, "invalid-context");
  if (Object.values(values).some((v) => !text(v)))
    fail(
      "invalid-context",
      "Every context target must be an explicit bounded string.",
    );
  for (const [key, max] of [
    ["CO_CODE", 2],
    ["LC_CODE", 2],
    ["CO_YEAR", 10],
    ["CO_BOOK", 3],
    ["VCH_NO", 5],
  ] as const)
    if (!canonical(values[key], max))
      fail("invalid-context", "Canonical complete scope is required.", key);
  if (
    (values.CO_CODE as string).length !== 2 ||
    (values.LC_CODE as string).length !== 2 ||
    !/^\d{5}$/.test(values.VCH_NO as string) ||
    values.INOUT_TYPE !== "I"
  )
    fail("invalid-context", "A complete saved incoming scope is required.");
  for (const key of ["VCH_DATE", "STK_DATE", "VCH_TIME"] as const)
    if (!(values[key] as string).trim())
      fail(
        "invalid-context",
        "Date/clock representation cannot be inferred from blank context.",
        key,
      );
  return Object.freeze({
    status: "qualified",
    observationIdentity: c.observationIdentity,
    values: Object.freeze(values) as Readonly<
      Record<(typeof CONTEXT)[number], string>
    >,
  });
}
function decimal(v: string, blank: boolean, field: string): Decimal {
  if (v.length > 128 || /[^\x20-\x7e]/.test(v))
    fail(
      "invalid-decimal",
      "Only bounded ASCII plain decimals are supported.",
      field,
    );
  const t = v.trim();
  if (t === "" && blank) return new D(0);
  if (!/^[+-]?(?:\d+(?:\.\d*)?|\.\d+)$/.test(t))
    fail("invalid-decimal", "Finite plain decimal required.", field);
  const d = new D(t);
  if (!d.isFinite() || d.sd() > 36 || d.dp() > 18 || d.abs().gte("1e36"))
    fail(
      "unsupported-precision",
      "Decimal exceeds the declared mathematical profile.",
      field,
    );
  return d;
}
function numberText(d: Decimal): string {
  return d.isZero() ? "0" : d.toFixed();
}
function grid(
  v: unknown,
  keys: readonly string[],
): Readonly<Record<string, string>> {
  const r = rec(v, "invalid-phase");
  exact(r, keys, "invalid-phase");
  let size = 0;
  for (const t of Object.values(r)) {
    if (!text(t))
      fail("invalid-phase", "Every grid cell must be a bounded string.");
    size += t.length;
  }
  if (size > 65536) fail("invalid-phase", "Grid exceeds bounded size.");
  return Object.freeze(r) as Readonly<Record<string, string>>;
}
function phaseInput(v: unknown): SaleReturnNBarPhaseInput {
  const r = rec(v, "invalid-phase");
  exact(r, ["visible", "incomingTotals"], "invalid-phase");
  return Object.freeze({
    visible: grid(r.visible, VISIBLE_KEYS),
    incomingTotals: grid(r.incomingTotals, TOTAL_KEYS),
  });
}
function project(
  p: SaleReturnNBarPhaseInput,
  c: Extract<SaleReturnNBarContext, { status: "qualified" }>,
  add: (e: Refusal) => void,
): SaleReturnNBarProjection {
  const n = (column: number) =>
    decimal(p.visible[column]!, true, "row.c" + column);
  const t = (column: number) =>
    decimal(p.incomingTotals[column]!, true, "totals.c" + column);
  // Desktop uses non-short-circuit |: inspect both numeric operands.
  const headerMrp = t(28),
    headerSum = t(9).plus(t(12)).plus(t(27));
  const header = !headerMrp.isZero() || !headerSum.isZero();
  const parent =
    !n(9).plus(n(12)).plus(n(38)).isZero() && p.visible["2"] !== "";
  let barData: Record<string, string> | null = null,
    barDetl: Record<string, string> | null = null;
  if (header) {
    barData = Object.fromEntries(HEADER_CONTEXT.map((k) => [k, c.values[k]]));
    barData.STK_IT_CODE = "";
    barData.DATA_TRFR = "N";
    Object.freeze(barData);
  }
  if (parent) {
    if (n(40).isZero())
      add(
        new Refusal(
          "unsupported-instance-allocation",
          "Source would allocate an instance; no clock or identity is invented.",
          "VCH_SRNO",
          "barDetl",
        ),
      );
    else {
      barDetl = Object.fromEntries(PARENT_CONTEXT.map((k) => [k, c.values[k]]));
      barDetl.ENTRY_TYPE = "P";
      barDetl.DATA_TRFR = "N";
      for (const [field, column] of Object.entries(NUMERIC))
        barDetl[field] = numberText(n(column));
      for (const [field, column] of Object.entries(TEXT))
        barDetl[field] = p.visible[column]!;
      for (const field of ZERO) barDetl[field] = "0";
      // The outer parent guard excludes blank tag; do not fabricate its unreachable N branch.
      if (p.visible["70"] === "") barDetl.DATA_TYPE = "A";
      // TAG_SRNO already uses the final c56 assignment, superseding transient zero.
      Object.freeze(barDetl);
    }
  }
  return Object.freeze({
    predicates: Object.freeze({ barData: header, barDetl: parent }),
    barData,
    barDetl,
  });
}

export function matchSaleReturnNBarCompanions(
  input: unknown,
): SaleReturnNBarResult {
  let obs = recoverObserved(input),
    ctx: SaleReturnNBarContext | null = null;
  let before: SaleReturnNBarProjection | null = null,
    after: SaleReturnNBarProjection | null = null;
  let rowIdentity: string | null = null,
    tenantId: string | null = null;
  const diagnostics: SaleReturnNBarDiagnostic[] = [],
    differences: SaleReturnNBarDifference[] = [];
  const add = (e: Refusal) =>
    diagnostics.push(
      Object.freeze({
        code: e.code,
        message: e.message,
        ...(e.field ? { field: e.field } : {}),
        ...(e.table ? { table: e.table } : {}),
      }),
    );
  const result = (status: "matched" | "unsupported"): SaleReturnNBarResult =>
    Object.freeze({
      version: SALE_RETURN_N_BAR_COMPANIONS_VERSION,
      status,
      canCommit: false,
      rowIdentity,
      tenantId,
      context: ctx,
      observed: obs,
      before,
      after,
      differences: Object.freeze([...differences]),
      diagnostics: Object.freeze([...diagnostics]),
      requirements: REQUIREMENTS,
    });
  try {
    const r = rec(input, "invalid-input");
    exact(
      r,
      ["rowIdentity", "tenantId", "context", "before", "after", "observed"],
      "invalid-input",
    );
    if (!hash(r.rowIdentity) || !canonical(r.tenantId, 24))
      fail(
        "invalid-input",
        "Exact retained row identity and tenant are required.",
      );
    rowIdentity = r.rowIdentity;
    tenantId = r.tenantId;
    obs = observed(r.observed);
    ctx = context(r.context);
    if (ctx.status === "unavailable") fail("context-unavailable", ctx.reason);
    const contextValues = ctx.values;
    let b: SaleReturnNBarPhaseInput | null = null,
      a: SaleReturnNBarPhaseInput | null = null;
    // A refused phase must not hide an independently inspectable sibling.
    try {
      b = phaseInput(r.before);
      before = project(b, ctx, add);
    } catch (e) {
      add(
        e instanceof Refusal
          ? e
          : new Refusal(
              "invalid-phase",
              "The before phase could not be inspected safely.",
            ),
      );
    }
    try {
      a = phaseInput(r.after);
      after = project(a, ctx, add);
    } catch (e) {
      add(
        e instanceof Refusal
          ? e
          : new Refusal(
              "invalid-phase",
              "The after phase could not be inspected safely.",
            ),
      );
    }
    if (!b || !a || !before || !after) return result("unsupported");
    for (const p of [b, a]) {
      if (p.visible["2"] !== "N")
        add(
          new Refusal(
            "unsupported-n-tag-profile",
            "Option A requires literal N; source nonblank behavior is reported separately.",
            "TAG_NO",
            "barDetl",
          ),
        );
      if (
        !decimal(p.visible["0"]!, true, "SR_NO").eq(1) ||
        !decimal(p.visible["40"]!, true, "VCH_SRNO").gt(0) ||
        !canonical(p.visible["1"], 64)
      )
        add(
          new Refusal(
            "unsupported-row-identity",
            "Only a stable saved ordinal1/item/nonzero instance is qualified.",
          ),
        );
    }
    for (const table of ["barData", "barDetl"] as const) {
      if (before.predicates[table] !== after.predicates[table])
        add(
          new Refusal(
            "companion-membership-change",
            "The source companion inclusion changes after replay.",
            undefined,
            table,
          ),
        );
      else if (!before.predicates[table])
        add(
          new Refusal(
            "unsupported-companion-membership",
            "Option A requires both existing source-shaped companions.",
            undefined,
            table,
          ),
        );
      const left = before[table],
        right = after[table];
      if (left && right)
        for (const field of Object.keys(left))
          if (left[field] !== right[field])
            differences.push(
              Object.freeze({
                table,
                field,
                before: left[field]!,
                after: right[field]!,
              }),
            );
      if (obs[table].length !== 1) {
        add(
          new Refusal(
            "observed-membership-mismatch",
            "Exactly one observed companion is required.",
            undefined,
            table,
          ),
        );
        continue;
      }
      const o = obs[table][0]!;
      if (
        o.raw.row_id !== o.rowId ||
        o.raw.tenant_id !== tenantId ||
        SCOPE.some((k) => o.raw[k] !== contextValues[k])
      )
        add(
          new Refusal(
            "observation-identity-mismatch",
            "Observed physical identity, tenant and full scope must agree.",
            undefined,
            table,
          ),
        );
      if (left)
        for (const [field, value] of Object.entries(left)) {
          const stored = o.raw[field];
          let matches = stored === value;
          if (table === "barDetl" && NUMERIC_TARGETS.has(field)) {
            matches = false;
            if (typeof stored === "string")
              try {
                matches = decimal(stored, false, field).eq(
                  decimal(value, false, field),
                );
              } catch {
                matches = false;
              }
          }
          if (!matches)
            add(
              new Refusal(
                "observation-value-mismatch",
                "The observed companion does not match a complete source target; raw is retained.",
                field,
                table,
              ),
            );
        }
    }
    if (differences.length)
      add(
        new Refusal(
          "companion-value-change",
          "A source-mapped companion value changes; this preservation profile refuses it.",
        ),
      );
    return result(diagnostics.length ? "unsupported" : "matched");
  } catch (error) {
    add(
      error instanceof Refusal
        ? error
        : new Refusal(
            "invalid-input",
            "The supplied observation could not be inspected safely.",
          ),
    );
    return result("unsupported");
  }
}
