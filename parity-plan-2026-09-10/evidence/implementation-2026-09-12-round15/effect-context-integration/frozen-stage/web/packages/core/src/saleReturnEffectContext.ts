import { projectSavedSaleReturnClock } from "./savedSaleReturnClock.js";

/** Supplied current-PG observations only: no source authority, admission or DML.
 * TR_SALE_RTN10104–10106/14557; Ac_Ledr1324/1326; Ac_Stock247.
 * ISO/text-zero preservation is an explicit adaptation, not Windows cast parity. */
export const SALE_RETURN_EFFECT_CONTEXT_VERSION =
  "saved-sale-return-effect-context-v1";
export const SALE_RETURN_EFFECT_CONTEXT_PROFILE =
  "canonical-pg-preserved-sr1-effect-context-v1";
const CLOCK = ["VCH_DATE", "VCH_TIME"] as const;
const INCOMING = [
  "CO_CODE",
  "LC_CODE",
  "CO_YEAR",
  "CO_BOOK",
  "VCH_NO",
  "SR_NO",
  ...CLOCK,
] as const;
const STORAGE = [
  "stockDateText",
  "stockDiscountText",
  "taxZeroRatedText",
] as const;
const PROVENANCE = [
  "documentIdentity",
  "documentVersion",
  "rowIdentity",
  "observationIdentity",
] as const;
const REQUIREMENTS = Object.freeze([
  "trusted-same-transaction-full-raw-and-physical-observation-binding",
  "explicit-current-pg-iso-and-zero-text-preservation-adaptation",
  "independent-database-type-and-readback-verification",
  "complete-source-shaped-bar-and-financial-effect-membership",
  "fresh-session-rights-document-config-masters-and-post-replay-save-guards",
  "single-serializable-atomic-writer-without-authority-from-this-result",
] as const);

type Raw<K extends string> = Readonly<Partial<Record<K, string | null>>>;
export interface SaleReturnEffectContextInput {
  readonly header: Raw<(typeof CLOCK)[number]>;
  readonly incoming: Raw<(typeof INCOMING)[number]>;
  readonly storageText: Raw<(typeof STORAGE)[number]>;
  readonly provenance: Readonly<Record<(typeof PROVENANCE)[number], string>>;
}
export interface SaleReturnEffectStorageValues {
  readonly acEntryTime: string;
  readonly stockEntryDate: string;
  readonly stockDateText: string;
  readonly customerLedgerKey: string;
  readonly saleLedgerKey: string;
  readonly stockDiscountText: string;
  readonly taxZeroRatedText: string;
}
export interface SaleReturnQualifiedEffectStorage {
  readonly status: "qualified";
  readonly observationIdentity: string;
  readonly values: SaleReturnEffectStorageValues;
}
export type SaleReturnEffectContextCode =
  | "invalid-input"
  | "missing-observation"
  | "null-observation"
  | "unsupported-identity"
  | "unsupported-serial"
  | "unsupported-clock"
  | "fractional-clock"
  | "incoherent-clock"
  | "unsupported-storage-text";
export interface SaleReturnEffectContextDiagnostic {
  readonly code: SaleReturnEffectContextCode;
  readonly field?: string;
  readonly message: string;
}
interface ResultBase {
  readonly version: typeof SALE_RETURN_EFFECT_CONTEXT_VERSION;
  readonly profile: typeof SALE_RETURN_EFFECT_CONTEXT_PROFILE;
  readonly canCommit: false;
  readonly requirements: typeof REQUIREMENTS;
}
export type SaleReturnEffectContextResult = ResultBase &
  (
    | {
        readonly status: "ready";
        readonly observation: SaleReturnEffectContextInput;
        readonly storage: SaleReturnQualifiedEffectStorage;
        readonly diagnostics: readonly [];
      }
    | {
        readonly status: "unsupported";
        readonly observation: SaleReturnEffectContextInput;
        readonly storage: null;
        readonly diagnostics: readonly SaleReturnEffectContextDiagnostic[];
      }
    | {
        readonly status: "invalid-input";
        readonly observation: null;
        readonly storage: null;
        readonly diagnostics: readonly SaleReturnEffectContextDiagnostic[];
      }
  );
function base(): ResultBase {
  return {
    version: SALE_RETURN_EFFECT_CONTEXT_VERSION,
    profile: SALE_RETURN_EFFECT_CONTEXT_PROFILE,
    canCommit: false,
    requirements: REQUIREMENTS,
  };
}
function freeze<T>(value: T): T {
  if (value !== null && typeof value === "object") {
    for (const child of Object.values(value)) freeze(child);
    Object.freeze(value);
  }
  return value;
}
function fields(
  value: unknown,
  allowed: readonly string[],
  all: boolean,
): Record<string, unknown> | null {
  if (!value || typeof value !== "object" || Array.isArray(value)) return null;
  const prototype = Object.getPrototypeOf(value);
  if (prototype !== null && prototype !== Object.prototype) return null;
  const keys = Reflect.ownKeys(value);
  if (all && keys.length !== allowed.length) return null;
  const output: Record<string, unknown> = {};
  for (const key of keys) {
    if (typeof key !== "string" || !allowed.includes(key)) return null;
    const descriptor = Object.getOwnPropertyDescriptor(value, key);
    if (!descriptor?.enumerable || !Object.hasOwn(descriptor, "value"))
      return null;
    output[key] = descriptor.value;
  }
  return output;
}
function raw<K extends string>(
  value: unknown,
  keys: readonly K[],
): Raw<K> | null {
  const result = fields(value, keys, false);
  if (
    !result ||
    Object.values(result).some((v) => v !== null && typeof v !== "string")
  )
    return null;
  return result as Raw<K>;
}
function id(value: unknown): value is string {
  return (
    typeof value === "string" &&
    value.length > 0 &&
    value.length <= 256 &&
    !/[^\x20-\x7e]/.test(value) &&
    value.trim() === value
  );
}
function parse(value: unknown): SaleReturnEffectContextInput | null {
  const outer = fields(
    value,
    ["header", "incoming", "storageText", "provenance"],
    true,
  );
  if (!outer) return null;
  const header = raw(outer.header, CLOCK);
  const incoming = raw(outer.incoming, INCOMING);
  const storageText = raw(outer.storageText, STORAGE);
  const provenance = fields(outer.provenance, PROVENANCE, true);
  if (
    !header ||
    !incoming ||
    !storageText ||
    !provenance ||
    !Object.values(provenance).every(id)
  )
    return null;
  return {
    header,
    incoming,
    storageText,
    provenance: provenance as SaleReturnEffectContextInput["provenance"],
  };
}
function unsupported(
  observation: SaleReturnEffectContextInput,
  code: SaleReturnEffectContextCode,
  field: string,
  message: string,
): SaleReturnEffectContextResult {
  return freeze({
    ...base(),
    status: "unsupported",
    observation,
    storage: null,
    diagnostics: [{ code, field, message }],
  });
}
function invalid(): SaleReturnEffectContextResult {
  return freeze({
    ...base(),
    status: "invalid-input",
    observation: null,
    storage: null,
    diagnostics: [
      {
        code: "invalid-input",
        message:
          "Expected the exact bounded raw observation and provenance envelope.",
      },
    ],
  });
}

export function projectSavedSaleReturnEffectContext(
  value: unknown,
): SaleReturnEffectContextResult {
  let observation: SaleReturnEffectContextInput | null;
  try {
    observation = parse(value);
  } catch {
    return invalid();
  }
  if (!observation) return invalid();
  for (const [section, keys] of [
    ["header", CLOCK],
    ["incoming", INCOMING],
    ["storageText", STORAGE],
  ] as const) {
    const group: Readonly<Record<string, string | null | undefined>> =
      observation[section];
    for (const key of keys) {
      if (!Object.hasOwn(group, key))
        return unsupported(
          observation,
          "missing-observation",
          `${section}.${key}`,
          "Required raw observation is absent; no value is supplied.",
        );
      if (group[key] === null)
        return unsupported(
          observation,
          "null-observation",
          `${section}.${key}`,
          "SQL NULL remains unsupported; no default is supplied.",
        );
    }
  }
  // Shape + presence checks above establish strings without coercion.
  const line = observation.incoming as Readonly<
    Record<(typeof INCOMING)[number], string>
  >;
  const header = observation.header as Readonly<
    Record<(typeof CLOCK)[number], string>
  >;
  const text = observation.storageText as Readonly<
    Record<(typeof STORAGE)[number], string>
  >;
  for (const [key, width] of [
    ["CO_CODE", 2],
    ["LC_CODE", 2],
    ["CO_YEAR", 10],
    ["CO_BOOK", 3],
    ["VCH_NO", 5],
  ] as const) {
    const value = line[key];
    const permitted =
      key === "CO_YEAR"
        ? /^[A-Z0-9-]+$/
        : key === "VCH_NO"
          ? /^[0-9]{5}$/
          : /^[A-Z0-9]+$/;
    if (
      value.length === 0 ||
      value.length > width ||
      /[^\x20-\x7e]/.test(value) ||
      !permitted.test(value)
    ) {
      return unsupported(
        observation,
        "unsupported-identity",
        `incoming.${key}`,
        "Observed identity is outside the exact finite storage profile; no padding, trimming or truncation is allowed.",
      );
    }
  }
  if (line.SR_NO !== "1")
    return unsupported(
      observation,
      "unsupported-serial",
      "incoming.SR_NO",
      "Only exact serial text 1 is qualified; general SQL STR rounding and overflow are not implemented.",
    );
  const provenance = {
    documentIdentity: observation.provenance.documentIdentity,
    documentVersion: observation.provenance.documentVersion,
  };
  for (const [section, clock] of [
    ["header", header],
    ["incoming", line],
  ] as const) {
    const projected = projectSavedSaleReturnClock({
      raw: { VCH_DATE: clock.VCH_DATE, VCH_TIME: clock.VCH_TIME },
      provenance,
    });
    if (projected.status !== "ready") {
      return unsupported(
        observation,
        "unsupported-clock",
        `${section}.${projected.diagnostics[0]?.sourceField ?? "VCH_TIME"}`,
        "Clock is outside the unchanged canonical PostgreSQL saved-clock profile.",
      );
    }
    if (/[1-9]/.test(clock.VCH_TIME.slice(20))) {
      return unsupported(
        observation,
        "fractional-clock",
        `${section}.VCH_TIME`,
        "Nonzero fractional seconds would be lost by desktop saved-open whole-second projection.",
      );
    }
  }
  if (header.VCH_TIME.slice(0, 10) !== header.VCH_DATE)
    return unsupported(
      observation,
      "incoherent-clock",
      "header.VCH_TIME",
      "Saved header timestamp day differs from its voucher date.",
    );
  if (line.VCH_DATE !== header.VCH_DATE)
    return unsupported(
      observation,
      "incoherent-clock",
      "incoming.VCH_DATE",
      "Saved line date differs from the header date.",
    );
  if (line.VCH_TIME.slice(0, 19) !== header.VCH_TIME.slice(0, 19))
    return unsupported(
      observation,
      "incoherent-clock",
      "incoming.VCH_TIME",
      "Saved line timestamp differs from the header whole-second clock.",
    );
  for (const [key, expected] of [
    ["stockDateText", line.VCH_DATE],
    ["stockDiscountText", "0"],
    ["taxZeroRatedText", "0"],
  ] as const) {
    if (text[key] !== expected)
      return unsupported(
        observation,
        "unsupported-storage-text",
        `storageText.${key}`,
        "Explicit current-PG preservation witness must match exactly; source implicit text casts are not inferred.",
      );
  }
  const prefix =
    line.CO_CODE + line.LC_CODE + line.CO_YEAR + line.CO_BOOK + line.VCH_NO;
  const serial = "         1"; // SQL STR(1), default width10: nine spaces +1.
  const customerLedgerKey = prefix + "01" + serial;
  const saleLedgerKey = prefix + "02" + serial;
  if (customerLedgerKey.length > 50 || saleLedgerKey.length > 50)
    return unsupported(
      observation,
      "unsupported-identity",
      "incoming",
      "Source-concatenated ledger key exceeds the current varchar50 target.",
    );
  return freeze({
    ...base(),
    status: "ready",
    observation,
    storage: {
      status: "qualified",
      observationIdentity: observation.provenance.observationIdentity,
      values: {
        acEntryTime: header.VCH_TIME.slice(0, 19),
        stockEntryDate: line.VCH_DATE,
        stockDateText: text.stockDateText,
        customerLedgerKey,
        saleLedgerKey,
        stockDiscountText: text.stockDiscountText,
        taxZeroRatedText: text.taxZeroRatedText,
      },
    },
    diagnostics: [],
  });
}
