import { Decimal } from "decimal.js";

/** TR_SALE_RTN.cs:14252,14307–14584. Mapping is inspection only: no calculation,
 * whole-document admission, effects, storage write, or session/mode authority. */
export const SALE_RETURN_INCOMING_SAVE_VERSION = "primary-incoming-save-map-v1";
export const SALE_RETURN_INCOMING_SAVE_PROFILE =
  "saved-one-primary-untagged-c27-map-decimal-pg-v1";

const D = Decimal.clone({ precision: 100, toExpNeg: -100, toExpPos: 100 });
// Source assignment order; context-owned fields are deliberately absent.
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
  ITM_RATE: 19,
  ITM_AMT: 20,
  LBR_PRC: 21,
  LBR_RATE: 23,
  LBR_AMT: 24,
  DISC_PRC: 25,
  DISC_AMT: 26,
  OTH_AMT: 27,
  ITM_MRP: 28,
  TAG_LBR_PRC: 30,
  TAG_LBR_RATE: 31,
  TAG_LBR_AMT: 32,
  TAG_OTH_AMT: 33,
  TAG_COST: 34,
  TAG_MRP: 35,
  TOT_AMT: 36,
  TAX_PRC: 37,
  NET_AMT: 38,
  VCH_SRNO: 40,
  TAG_SRNO: 56,
  HM_ID_WT: 62,
  HM_ID2_WT: 63,
  HM_ID3_WT: 64,
  HM_ID4_WT: 65,
} as const;
const TEXT = {
  IT_CODE: 1,
  ITM_REMARK: 3,
  TAG_NO: 2,
  TBL_CODE: 4,
  DESIGN_NO: 5,
  ITM_STYLE: 6,
  ITM_SIZE: 7,
  HM_ID: 8,
  LBR_CODE: 13,
  LBR_TYPE: 22,
  TAG_LBR_CODE: 29,
  KR_NAME: 39,
  RATE_TYPE: 44,
  PR_CODE: 52,
  TAG_TYPE: 54,
  HM_ID2: 59,
  HM_ID3: 60,
  HM_ID4: 61,
  APR_ISU: 50,
  EMP_ISU: 68,
  IT_TYPE: 43,
  DESIGN_IMG_ID: 69,
  DATA_TYPE: 70,
} as const;
const OWNED = ["OTH_AMT", "TOT_AMT", "NET_AMT"] as const;
const CACHE = new Set([45, 46, 47, 48, 49, 58, 66, 67]);
const VISIBLE_KEYS = Array.from({ length: 71 }, (_, i) => i)
  .filter((i) => !CACHE.has(i))
  .map(String);
const REQUIREMENTS = Object.freeze([
  "trusted-c27-only-replay-and-complete-poststate-admission",
  "fresh-update-session-document-configuration-master-and-save-guard-authority",
  "complete-bar-stock-ledger-rojmel-tax-outstanding-remark-effect-ownership",
  "header-float-and-effect-storage-representability",
  "single-serializable-atomic-writer-and-postconditions",
] as const);

export type SaleReturnIncomingSaveRaw = Readonly<Record<string, string | null>>;
export type SaleReturnIncomingSaveField =
  keyof typeof NUMERIC | keyof typeof TEXT;
export type SaleReturnIncomingSaveFields = Readonly<
  Record<SaleReturnIncomingSaveField, string>
>;
export type SaleReturnIncomingSavePatch = Readonly<
  Partial<Record<(typeof OWNED)[number], string>>
>;
export interface SaleReturnIncomingSaveInput {
  readonly rowIdentity: string;
  readonly ordinal: number;
  readonly raw: SaleReturnIncomingSaveRaw;
  readonly visible: Readonly<Record<string, string>>;
}
export type SaleReturnIncomingSaveCode =
  | "invalid-input"
  | "invalid-raw"
  | "invalid-visible"
  | "missing-raw-field"
  | "invalid-decimal"
  | "unsupported-precision"
  | "unsupported-storage-precision"
  | "unsupported-row-omission"
  | "unsupported-row-renumber"
  | "unsupported-instance-allocation"
  | "row-identity-conflict"
  | "unsupported-row-profile"
  | "unsupported-credit-row"
  | "unsupported-row-tax"
  | "unsupported-raw-numeric-null"
  | "unowned-numeric-change"
  | "unsupported-output";
export interface SaleReturnIncomingSaveDiagnostic {
  readonly code: SaleReturnIncomingSaveCode;
  readonly message: string;
  readonly field?: string;
  readonly column?: number;
}
export interface SaleReturnIncomingSaveDifference {
  readonly field: SaleReturnIncomingSaveField;
  readonly rawValue: string | null;
  readonly sourceValue: string;
  readonly disposition:
    | "numeric-text-preserved"
    | "unowned-text-preserved"
    | "candidate-numeric-change"
    | "unowned-numeric-change";
}
export interface SaleReturnIncomingSaveBranches {
  readonly sourceWouldInclude: boolean | null;
  readonly sourceOrdinal: string | null;
  readonly instanceAllocationRequired: boolean | null;
  readonly blankTagDefault: boolean | null;
  readonly blankDataTypeDefault: boolean | null;
}
interface ResultBase {
  readonly version: typeof SALE_RETURN_INCOMING_SAVE_VERSION;
  readonly profile: typeof SALE_RETURN_INCOMING_SAVE_PROFILE;
  readonly canCommit: false;
  readonly raw: SaleReturnIncomingSaveRaw | null;
  readonly rowIdentity: string | null;
  readonly diagnostics: readonly SaleReturnIncomingSaveDiagnostic[];
  readonly requirements: typeof REQUIREMENTS;
  readonly branches: SaleReturnIncomingSaveBranches;
  readonly differences: readonly SaleReturnIncomingSaveDifference[];
}
export type SaleReturnIncomingSaveResult =
  | (ResultBase & {
      readonly status: "ready";
      readonly raw: SaleReturnIncomingSaveRaw;
      readonly rowIdentity: string;
      readonly sourceFieldValues: SaleReturnIncomingSaveFields;
      readonly candidatePatch: SaleReturnIncomingSavePatch;
    })
  | (ResultBase & {
      readonly status: "unsupported";
      readonly sourceFieldValues: SaleReturnIncomingSaveFields | null;
      readonly candidatePatch: null;
    });

class Refusal extends Error {
  constructor(
    readonly code: SaleReturnIncomingSaveCode,
    message: string,
    readonly field?: string,
    readonly column?: number,
  ) {
    super(message);
  }
}
function fail(
  code: SaleReturnIncomingSaveCode,
  message: string,
  field?: string,
  column?: number,
): never {
  throw new Refusal(code, message, field, column);
}

/** Descriptor reads never evaluate getters. Proxy trap behavior is not a trust boundary. */
function record(
  value: unknown,
  code: SaleReturnIncomingSaveCode,
): Record<string, unknown> {
  if (
    !value ||
    typeof value !== "object" ||
    Array.isArray(value) ||
    ![Object.prototype, null].includes(Object.getPrototypeOf(value))
  )
    fail(code, "An ordinary own-data record is required.");
  const descriptors = Object.getOwnPropertyDescriptors(value);
  const keys = Reflect.ownKeys(descriptors);
  if (keys.length > 1024 || keys.some((key) => typeof key !== "string"))
    fail(code, "The record has unsupported keys or size.");
  const entries: [string, unknown][] = [];
  for (const key of keys as string[]) {
    const d = descriptors[key]!;
    if (!d.enumerable || !Object.hasOwn(d, "value"))
      fail(code, "Only enumerable data fields are supported.");
    entries.push([key, d.value]);
  }
  return Object.fromEntries(entries);
}
function exact(
  value: Record<string, unknown>,
  keys: readonly string[],
  code: SaleReturnIncomingSaveCode,
): void {
  if (
    Object.keys(value).length !== keys.length ||
    keys.some((key) => !Object.hasOwn(value, key))
  )
    fail(code, "The complete exact field set is required.");
}
function rawCopy(value: unknown): SaleReturnIncomingSaveRaw {
  const r = record(value, "invalid-raw");
  let size = 0;
  for (const [key, text] of Object.entries(r)) {
    if (
      !key ||
      key.length > 128 ||
      /[^\x20-\x7e]/.test(key) ||
      (text !== null && (typeof text !== "string" || text.length > 65536))
    )
      fail(
        "invalid-raw",
        "Raw observations require bounded exact string/NULL fields.",
      );
    size += key.length + (typeof text === "string" ? text.length : 0);
  }
  if (size > 262144)
    fail("invalid-raw", "The raw observation exceeds the bounded profile.");
  return Object.freeze(r) as SaleReturnIncomingSaveRaw;
}
function recoverRaw(input: unknown): SaleReturnIncomingSaveRaw | null {
  try {
    if (!input || typeof input !== "object") return null;
    const descriptor = Object.getOwnPropertyDescriptor(input, "raw");
    return descriptor && Object.hasOwn(descriptor, "value")
      ? rawCopy(descriptor.value)
      : null;
  } catch {
    return null;
  }
}
function decimal(
  value: string,
  blank: boolean,
  field: string,
  column?: number,
): Decimal {
  if (value.length > 128 || /[^\x20-\x7e]/.test(value))
    fail(
      "invalid-decimal",
      "A bounded ASCII plain decimal is required.",
      field,
      column,
    );
  const text = value.trim();
  if (text === "" && blank) return new D(0);
  if (!/^[+-]?(?:\d+(?:\.\d*)?|\.\d+)$/.test(text))
    fail(
      "invalid-decimal",
      "A finite plain decimal is required.",
      field,
      column,
    );
  const number = new D(text);
  if (
    !number.isFinite() ||
    number.sd() > 36 ||
    number.dp() > 18 ||
    number.abs().gte("1e36")
  )
    fail(
      "unsupported-precision",
      "The value exceeds the declared mathematical profile.",
      field,
      column,
    );
  return number;
}
function canonical(value: Decimal): string {
  return value.isZero() ? "0" : value.toFixed();
}
function diagnostic(error: Refusal): SaleReturnIncomingSaveDiagnostic {
  return Object.freeze({
    code: error.code,
    message: error.message,
    ...(error.field === undefined ? {} : { field: error.field }),
    ...(error.column === undefined ? {} : { column: error.column }),
  });
}

/** A ready candidate is not a complete saved row, replay receipt, effect plan or save permission.
 * In particular TAG_NO=N does not establish absence of desktop BAR save effects. */
export function projectSaleReturnIncomingSave(
  input: unknown,
): SaleReturnIncomingSaveResult {
  let raw = recoverRaw(input);
  let rowIdentity: string | null = null;
  let fields: SaleReturnIncomingSaveFields | null = null;
  let branches: SaleReturnIncomingSaveBranches = Object.freeze({
    sourceWouldInclude: null,
    sourceOrdinal: null,
    instanceAllocationRequired: null,
    blankTagDefault: null,
    blankDataTypeDefault: null,
  });
  const differences: SaleReturnIncomingSaveDifference[] = [];
  const diagnostics: SaleReturnIncomingSaveDiagnostic[] = [];
  const patch: Partial<Record<(typeof OWNED)[number], string>> = {};
  const base = (): ResultBase => ({
    version: SALE_RETURN_INCOMING_SAVE_VERSION,
    profile: SALE_RETURN_INCOMING_SAVE_PROFILE,
    canCommit: false as const,
    raw,
    rowIdentity,
    diagnostics: Object.freeze([...diagnostics]),
    requirements: REQUIREMENTS,
    branches,
    differences: Object.freeze([...differences]),
  });
  const unsupported = (): SaleReturnIncomingSaveResult =>
    Object.freeze({
      ...base(),
      status: "unsupported",
      sourceFieldValues: fields,
      candidatePatch: null,
    });
  try {
    const envelope = record(input, "invalid-input");
    exact(
      envelope,
      ["rowIdentity", "ordinal", "raw", "visible"],
      "invalid-input",
    );
    if (
      typeof envelope.rowIdentity !== "string" ||
      envelope.rowIdentity.length !== 64 ||
      !/^[0-9a-f]{64}$/.test(envelope.rowIdentity) ||
      !Number.isSafeInteger(envelope.ordinal) ||
      (envelope.ordinal as number) < 1
    )
      fail(
        "invalid-input",
        "Exact identity and a positive saved ordinal are required.",
      );
    rowIdentity = envelope.rowIdentity;
    raw = rawCopy(envelope.raw);
    const visible = record(envelope.visible, "invalid-visible");
    exact(visible, VISIBLE_KEYS, "invalid-visible");
    let visibleSize = 0;
    for (const value of Object.values(visible)) {
      if (typeof value !== "string" || value.length > 4096)
        fail("invalid-visible", "All63 visible cells must be bounded strings.");
      visibleSize += value.length;
    }
    if (visibleSize > 65536)
      fail("invalid-visible", "The visible map exceeds its bounded profile.");
    const strings = visible as Record<string, string>;
    const mapped: Record<string, string> = {};
    const values: Record<string, Decimal> = {};
    for (const [field, column] of Object.entries(NUMERIC)) {
      values[field] = decimal(strings[column]!, true, field, column);
      mapped[field] = canonical(values[field]!);
    }
    for (const [field, column] of Object.entries(TEXT))
      mapped[field] = strings[column]!;
    if (strings["2"] === "") mapped.TAG_NO = "N";
    if (strings["70"] === "") mapped.DATA_TYPE = "A";
    fields = Object.freeze(mapped) as SaleReturnIncomingSaveFields;
    branches = Object.freeze({
      sourceWouldInclude:
        strings["1"] !== "" && !values.ITM_NWT!.plus(values.NET_AMT!).isZero(),
      sourceOrdinal: mapped.SR_NO!,
      instanceAllocationRequired: values.VCH_SRNO!.isZero(),
      blankTagDefault: strings["2"] === "",
      blankDataTypeDefault: strings["70"] === "",
    });

    if (!branches.sourceWouldInclude)
      fail(
        "unsupported-row-omission",
        "Desktop Save would omit this row; removal is outside this profile.",
      );
    if (envelope.ordinal !== 1 || raw.SR_NO !== "1" || mapped.SR_NO !== "1")
      fail(
        "unsupported-row-renumber",
        "Only stable saved SR_NO1/display ordinal1 is qualified.",
        "SR_NO",
        0,
      );
    if (branches.instanceAllocationRequired)
      fail(
        "unsupported-instance-allocation",
        "A zero instance needs source allocation; no clock or identity is invented.",
        "VCH_SRNO",
        40,
      );
    for (const [field, column] of Object.entries(NUMERIC)) {
      if (!Object.hasOwn(raw, field))
        fail(
          "missing-raw-field",
          "The saved numeric observation is missing.",
          field,
          column,
        );
      if (raw[field] === null)
        fail(
          "unsupported-raw-numeric-null",
          "A required saved numeric is NULL; it remains unchanged.",
          field,
          column,
        );
    }
    for (const field of Object.keys(TEXT))
      if (!Object.hasOwn(raw, field))
        fail(
          "missing-raw-field",
          "The saved text observation is missing.",
          field,
        );
    if (raw.ENTRY_TYPE !== "P" || raw.INOUT_TYPE !== "I" || raw.TAG_NO !== "N")
      fail(
        "unsupported-row-profile",
        "Only a saved primary incoming untagged row is qualified.",
      );
    for (const field of [
      "IT_CODE",
      "TAG_NO",
      "IT_TYPE",
      "RATE_TYPE",
      "TAG_TYPE",
      "DATA_TYPE",
    ] as const) {
      if (
        typeof raw[field] !== "string" ||
        raw[field] !== mapped[field] ||
        (field === "DATA_TYPE" && !["A", "B", "C"].includes(raw[field]!))
      )
        fail(
          "row-identity-conflict",
          "Stored and visible identity/type must agree without defaults or repair.",
          field,
        );
    }
    for (const field of ["OLD_SRNO", "VCH_SRNO", "TAG_SRNO"] as const) {
      const previous = decimal(raw[field]!, false, field, NUMERIC[field]);
      if (
        !previous.eq(values[field]!) ||
        (field === "VCH_SRNO" && !previous.gt(0))
      )
        fail(
          "row-identity-conflict",
          "Stored and hidden row identity must agree exactly in value.",
          field,
          NUMERIC[field],
        );
    }
    if (!values.NET_AMT!.gt(0))
      fail(
        "unsupported-credit-row",
        "A nonpositive incoming row is outside the first credit profile.",
        "NET_AMT",
        38,
      );
    if (!values.TAX_PRC!.isZero())
      fail(
        "unsupported-row-tax",
        "Nonzero row tax is outside this initial mapping profile.",
        "TAX_PRC",
        37,
      );

    for (const [field, column] of Object.entries(NUMERIC) as [
      keyof typeof NUMERIC,
      number,
    ][]) {
      const previous = decimal(raw[field]!, false, field, column);
      const next = values[field]!;
      const owned = (OWNED as readonly string[]).includes(field);
      if (owned && (next.dp() > 2 || next.abs().gte("10000000000000000")))
        fail(
          "unsupported-storage-precision",
          "This numeric(18,2) value cannot be stored exactly without rounding.",
          field,
          column,
        );
      if (!previous.eq(next)) {
        differences.push(
          Object.freeze({
            field,
            rawValue: raw[field]!,
            sourceValue: mapped[field]!,
            disposition: owned
              ? "candidate-numeric-change"
              : "unowned-numeric-change",
          }),
        );
        if (!owned)
          diagnostics.push(
            diagnostic(
              new Refusal(
                "unowned-numeric-change",
                "An unowned numeric field differs; expanded persistence ownership is required.",
                field,
                column,
              ),
            ),
          );
        else
          patch[field as (typeof OWNED)[number]] = next.isZero()
            ? "0.00"
            : next.toFixed(2);
      } else if (raw[field] !== mapped[field]) {
        differences.push(
          Object.freeze({
            field,
            rawValue: raw[field]!,
            sourceValue: mapped[field]!,
            disposition: "numeric-text-preserved",
          }),
        );
      }
    }
    for (const field of Object.keys(TEXT) as (keyof typeof TEXT)[]) {
      if (raw[field] !== mapped[field])
        differences.push(
          Object.freeze({
            field,
            rawValue: raw[field]!,
            sourceValue: mapped[field]!,
            disposition: "unowned-text-preserved",
          }),
        );
    }
    if (diagnostics.length) return unsupported();
    const result = Object.freeze({
      ...base(),
      status: "ready" as const,
      raw,
      rowIdentity,
      sourceFieldValues: fields,
      candidatePatch: Object.freeze(patch),
    });
    if (JSON.stringify(result).length > 1048576)
      fail(
        "unsupported-output",
        "The detached observation exceeds the output bound.",
      );
    return result;
  } catch (error) {
    diagnostics.push(
      diagnostic(
        error instanceof Refusal
          ? error
          : new Refusal(
              "invalid-input",
              "The supplied observation could not be inspected safely.",
            ),
      ),
    );
    return unsupported();
  }
}
