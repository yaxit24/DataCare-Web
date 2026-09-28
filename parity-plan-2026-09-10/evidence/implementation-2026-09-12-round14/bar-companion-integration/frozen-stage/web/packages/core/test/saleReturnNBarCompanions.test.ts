import { createHash } from "node:crypto";
import { readFileSync } from "node:fs";
import { Decimal } from "decimal.js";
import { describe, expect, it } from "vitest";
import {
  matchSaleReturnNBarCompanions,
  SALE_RETURN_N_BAR_COMPANIONS_VERSION,
  type SaleReturnNBarInput,
  type SaleReturnNBarCode,
  type SaleReturnNBarProjection,
  type SaleReturnNBarObserved,
} from "../src/saleReturnNBarCompanions.js";
const bytes = readFileSync(
  new URL(
    "./fixtures/saleReturnNBarCompanions.independent.json",
    import.meta.url,
  ),
);
interface Literal {
  id: string;
  note: string;
  input: SaleReturnNBarInput;
  expected: {
    status: "matched" | "unsupported";
    before: SaleReturnNBarProjection;
    after: SaleReturnNBarProjection;
    diagnosticCode: SaleReturnNBarCode | null;
    observed: SaleReturnNBarObserved;
    canCommit: false;
  };
}
const fixture = JSON.parse(bytes.toString()) as { cases: Literal[] };
const sample = (): Record<string, any> =>
  structuredClone(fixture.cases[0]!.input);
function frozen(v: unknown): void {
  if (v && typeof v === "object") {
    expect(Object.isFrozen(v)).toBe(true);
    Object.values(v).forEach(frozen);
  }
}
function refused(x: unknown, code: SaleReturnNBarCode) {
  const r = matchSaleReturnNBarCompanions(x);
  expect(r.status).toBe("unsupported");
  expect(r.canCommit).toBe(false);
  expect(r.diagnostics.some((d) => d.code === code)).toBe(true);
  frozen(r);
  return r;
}

describe("complete independent BAR companion source literals", () => {
  it("pins22 before-code82-target fixtures without source calculator execution", () => {
    expect(createHash("sha256").update(bytes).digest("hex")).toBe(
      "30a5f3ff30c3a217bf35cf76afd763f4abde898aae3ef58311dfbce451bc382a",
    );
    expect(fixture.cases).toHaveLength(22);
    expect(SALE_RETURN_N_BAR_COMPANIONS_VERSION).toBe(
      "primary-incoming-n-bar-companions-v1",
    );
  });
  for (const v of fixture.cases)
    it(`${v.id}: ${v.note}`, () => {
      const x = structuredClone(v.input),
        before = structuredClone(x),
        r = matchSaleReturnNBarCompanions(x);
      expect(r.status).toBe(v.expected.status);
      expect(r.before).toStrictEqual(v.expected.before);
      expect(r.after).toStrictEqual(v.expected.after);
      expect(r.observed).toStrictEqual(v.expected.observed);
      expect(r.observed).not.toBe(x.observed);
      expect(r.canCommit).toBe(false);
      if (v.expected.diagnosticCode)
        expect(
          r.diagnostics.some((d) => d.code === v.expected.diagnosticCode),
        ).toBe(true);
      else expect(r.diagnostics).toStrictEqual([]);
      expect(x).toStrictEqual(before);
      expect(Object.isFrozen(x)).toBe(false);
      expect(Object.isFrozen(x.observed)).toBe(false);
      frozen(r);
    });
});
describe("scope, mapping and preserved raw observations", () => {
  it("preserves source target strings and raw NULL/scale while requiring unresolved authority", () => {
    const x = sample(),
      r = matchSaleReturnNBarCompanions(x);
    expect(r.status).toBe("matched");
    expect(Object.keys(r.before!.barData!)).toHaveLength(12);
    expect(Object.keys(r.before!.barDetl!)).toHaveLength(70);
    expect(r.before!.barDetl!.TAG_SRNO).toBe("123");
    expect(r.before!.barDetl!.STK_DATE).toBe("10/07/2024");
    expect(r.before!.barDetl!.VCH_DATE).toBe("2024-07-10");
    expect(r.before!.barDetl!.VCH_TIME).toBe("2024-07-10T12:13:14.123456");
    expect(r.observed!.barData[0]!.raw.AC_CODE).toBeNull();
    expect(r.observed!.barDetl[0]!.raw.ITM_PCS).toBe("1.000");
    expect(r.observed!.barDetl[0]!.raw.ITM_REMARK).toBeNull();
    expect(r.observed!.barDetl[0]!.raw.FUTURE_PARENT).toBe("raw\nparent");
    expect(r.requirements).toContain(
      "trusted-context-source-and-target-representation-qualification",
    );
    expect(r.requirements).toContain(
      "server-owned-replay-and-full-poststate-admission",
    );
    x.context.values.MAIN_USER = "changed later";
    x.observed.barDetl[0].raw.ITM_PCS = "2";
    expect(r.before!.barDetl!.MAIN_USER).toBe("original user");
    expect(r.observed!.barDetl[0]!.raw.ITM_PCS).toBe("1.000");
  });
  it("reports no computed phase when context is unresolved and preserves observations", () => {
    const x = sample();
    x.context = {
      status: "unavailable",
      reason: "Original clock conversion has not been qualified",
    };
    const r = refused(x, "context-unavailable");
    expect(r.before).toBeNull();
    expect(r.after).toBeNull();
    expect(r.context).toStrictEqual(x.context);
    expect(r.observed).toStrictEqual(x.observed);
  });
  it("refuses omitted context target without an invented employee/user/date", () => {
    const x = sample();
    delete x.context.values.MAIN_USER;
    const r = refused(x, "invalid-context");
    expect(r.before).toBeNull();
    expect(r.observed).toStrictEqual(x.observed);
  });
  it("reports zero-instance allocation without inventing a target parent", () => {
    const x = sample();
    x.before.visible["40"] = "0";
    const r = refused(x, "unsupported-instance-allocation");
    expect(r.before!.predicates.barDetl).toBe(true);
    expect(r.before!.barDetl).toBeNull();
    expect(r.after).toStrictEqual(fixture.cases[0]!.expected.after);
    expect(r.observed).toStrictEqual(x.observed);
  });
  it("refuses renumbering even when a caller makes raw/source serials agree", () => {
    const x = sample();
    x.before.visible["0"] = "17";
    x.after.visible["0"] = "17";
    x.observed.barDetl[0].raw.SR_NO = "17";
    refused(x, "unsupported-row-identity");
  });
  it("refuses changed instance and retains original physical identities", () => {
    const x = sample();
    x.after.visible["40"] = "500002";
    const r = refused(x, "companion-value-change");
    expect(r.differences).toContainEqual({
      table: "barDetl",
      field: "VCH_SRNO",
      before: "500001",
      after: "500002",
    });
    expect(r.observed).toStrictEqual(x.observed);
  });
  for (const [field, value] of [
    ["tenant_id", "foreign"],
    ["LC_CODE", "02"],
    ["CO_YEAR", "2025-2026"],
    ["CO_BOOK", "R12"],
    ["VCH_NO", "00018"],
  ] as const)
    it(`refuses observed scope mismatch ${field}`, () => {
      const x = sample();
      x.observed.barData[0].raw[field] = value;
      refused(x, "observation-identity-mismatch");
    });
  it("compares stock-date text exactly without locale normalization", () => {
    const x = sample();
    x.observed.barDetl[0].raw.STK_DATE = "2024-07-10";
    refused(x, "observation-value-mismatch");
  });
  it("does not bypass an invalid other OR operand when totalMRP is nonzero", () => {
    const x = sample();
    x.before.incomingTotals["28"] = "1";
    x.before.incomingTotals["9"] = "bad";
    const r = refused(x, "invalid-decimal");
    expect(r.before).toBeNull();
    expect(r.after).toStrictEqual(fixture.cases[0]!.expected.after);
  });
  it("uses private exact precision to distinguish a nonzero predicate residual", () => {
    const old = Decimal.precision;
    try {
      Decimal.set({ precision: 5 });
      const x = sample();
      x.before.incomingTotals["9"] = "999999999999999999999999999999999999";
      x.before.incomingTotals["12"] = "-999999999999999999999999999999999998";
      x.before.incomingTotals["27"] = "0";
      const r = matchSaleReturnNBarCompanions(x);
      expect(r.before!.predicates.barData).toBe(true);
      expect(r.status).toBe("matched");
      expect(Decimal.precision).toBe(5);
    } finally {
      Decimal.set({ precision: old });
    }
  });
});
describe("independent phase inspectability and strict input boundary", () => {
  it("keeps a valid after projection when before has a malformed field set", () => {
    const x = sample();
    delete x.before.visible["69"];
    const r = refused(x, "invalid-phase");
    expect(r.before).toBeNull();
    expect(r.after).toStrictEqual(fixture.cases[0]!.expected.after);
    expect(r.observed).toStrictEqual(x.observed);
  });
  it("keeps a valid before projection when after numeric parsing refuses", () => {
    const x = sample();
    x.after.visible["33"] = "1e2";
    const r = refused(x, "invalid-decimal");
    expect(r.before).toStrictEqual(fixture.cases[0]!.expected.before);
    expect(r.after).toBeNull();
  });
  for (const value of [
    "12\n",
    "12\r",
    "12\t",
    "12\u2028",
    "\u00a012",
    "NaN",
    "Infinity",
    "12x",
    "1e3",
  ])
    it(`refuses unsupported Val text ${JSON.stringify(value)}`, () => {
      const x = sample();
      x.after.visible["33"] = value;
      refused(x, "invalid-decimal");
    });
  for (const value of ["1" + "0".repeat(36), "0.0000000000000000001"])
    it(`refuses precision ${value}`, () => {
      const x = sample();
      x.after.visible["33"] = value;
      refused(x, "unsupported-precision");
    });
  for (const where of ["context", "phase", "raw"] as const)
    it(`does not invoke ${where} getters`, () => {
      const x = sample();
      let reads = 0;
      const target =
        where === "context"
          ? x.context.values
          : where === "phase"
            ? x.before.visible
            : x.observed.barData[0].raw;
      const key =
        where === "context"
          ? "MAIN_USER"
          : where === "phase"
            ? "9"
            : "VCH_DESC";
      Object.defineProperty(target, key, {
        enumerable: true,
        get: () => {
          reads++;
          throw new Error("must not execute");
        },
      });
      const r = refused(
        x,
        where === "context"
          ? "invalid-context"
          : where === "phase"
            ? "invalid-phase"
            : "invalid-observation",
      );
      expect(reads).toBe(0);
      if (where === "phase")
        expect(r.after).toStrictEqual(fixture.cases[0]!.expected.after);
    });
  for (const kind of [
    "symbol",
    "cycle",
    "hidden",
    "prototype",
    "sparse",
  ] as const)
    it(`refuses ${kind} observation safely`, () => {
      const x = sample();
      if (kind === "symbol") x.observed.barData[0].raw[Symbol("x")] = "x";
      if (kind === "cycle") x.observed.barData[0].raw.loop = x.observed;
      if (kind === "hidden")
        Object.defineProperty(x.observed.barData[0].raw, "secret", {
          value: "x",
        });
      if (kind === "prototype")
        Object.setPrototypeOf(x.observed.barData[0].raw, { inherited: "x" });
      if (kind === "sparse") delete x.observed.barData[0];
      expect(refused(x, "invalid-observation").observed).toBeNull();
    });
  it("retains plain NULL-prototype records and a safe own __proto__ raw property", () => {
    const x = sample();
    x.observed.barData[0].raw = Object.assign(
      Object.create(null),
      x.observed.barData[0].raw,
    );
    Object.defineProperty(x.observed.barData[0].raw, "__proto__", {
      enumerable: true,
      value: "literal raw",
    });
    const r = matchSaleReturnNBarCompanions(x);
    expect(r.status).toBe("matched");
    expect(r.observed!.barData[0]!.raw["__proto__"]).toBe("literal raw");
    frozen(r);
  });
  it("refuses journal or write-policy fields rather than interpreting authority", () => {
    const x = sample();
    x.canCommit = true;
    const r = refused(x, "invalid-input");
    expect(r.observed).toStrictEqual(x.observed);
  });
  it("preserves exact BIGINT row identities beyond Number precision", () => {
    const x = sample();
    x.observed.barDetl[0].rowId = "9223372036854775807";
    x.observed.barDetl[0].raw.row_id = "9223372036854775807";
    const r = matchSaleReturnNBarCompanions(x);
    expect(r.status).toBe("matched");
    expect(r.observed!.barDetl[0]!.rowId).toBe("9223372036854775807");
  });
});
