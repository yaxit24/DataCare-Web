import { createHash } from "node:crypto";
import { readFileSync } from "node:fs";
import { describe, expect, it } from "vitest";
import {
  projectSavedSaleReturnEffectContext,
  SALE_RETURN_EFFECT_CONTEXT_PROFILE,
  SALE_RETURN_EFFECT_CONTEXT_VERSION,
} from "../src/saleReturnEffectContext.js";
import type {
  SaleReturnEffectContextInput,
  SaleReturnEffectStorageValues,
} from "../src/saleReturnEffectContext.js";
const bytes = readFileSync(
  new URL(
    "./fixtures/saleReturnEffectContext.independent.json",
    import.meta.url,
  ),
);
interface Vector {
  id: string;
  note: string;
  input: SaleReturnEffectContextInput;
  expected:
    | { status: "ready"; values: SaleReturnEffectStorageValues }
    | { status: "unsupported"; diagnostic: { code: string; field: string } };
}
const fixture = JSON.parse(bytes.toString()) as { cases: Vector[] };
function sample(): Record<string, any> {
  return structuredClone(fixture.cases[0]!.input);
}
function frozenDeep(value: unknown): void {
  if (value !== null && typeof value === "object") {
    expect(Object.isFrozen(value)).toBe(true);
    Object.values(value).forEach(frozenDeep);
  }
}
describe("source-authored finite effect context", () => {
  it("pins the literal fixture frozen before implementation", () => {
    expect(createHash("sha256").update(bytes).digest("hex")).toBe(
      "1c3285b2a7d4f9d75c2e442cc560a1e0960784cf8095fd640f89149614a8fe1c",
    );
    expect(fixture.cases).toHaveLength(60);
    expect(
      fixture.cases.filter((v) => v.expected.status === "ready"),
    ).toHaveLength(6);
  });
  it.each(fixture.cases)("$id $note", ({ input, expected }) => {
    const before = structuredClone(input);
    const result = projectSavedSaleReturnEffectContext(input);
    expect(input).toStrictEqual(before);
    expect(result).toMatchObject({
      status: expected.status,
      canCommit: false,
      version: SALE_RETURN_EFFECT_CONTEXT_VERSION,
      profile: SALE_RETURN_EFFECT_CONTEXT_PROFILE,
    });
    expect(result.observation).toStrictEqual(input);
    expect(result.observation).not.toBe(input);
    expect(result.requirements).toContain(
      "independent-database-type-and-readback-verification",
    );
    frozenDeep(result);
    if (expected.status === "ready") {
      expect(result.status).toBe("ready");
      if (result.status !== "ready") throw new Error("expected ready");
      expect(result.storage).toStrictEqual({
        status: "qualified",
        observationIdentity: input.provenance.observationIdentity,
        values: expected.values,
      });
      expect(result.diagnostics).toStrictEqual([]);
    } else {
      expect(result.storage).toBeNull();
      expect(result.diagnostics).toHaveLength(1);
      expect(result.diagnostics[0]).toMatchObject(expected.diagnostic);
    }
  });
  it("retains raw values without freezing or sharing caller objects", () => {
    const input = sample();
    input.header.VCH_TIME = "2026-09-12T13:04:05.000";
    const result = projectSavedSaleReturnEffectContext(input);
    expect(result.status).toBe("ready");
    input.header.VCH_TIME = "changed";
    input.incoming.SR_NO = "9";
    input.storageText.stockDiscountText = "5";
    input.provenance.observationIdentity = "new";
    expect(result.observation?.header.VCH_TIME).toBe("2026-09-12T13:04:05.000");
    expect(result.observation?.incoming.SR_NO).toBe("1");
    expect(result.observation?.storageText.stockDiscountText).toBe("0");
    expect(result.storage?.observationIdentity).toBe("observed-effects-1");
    expect(Object.isFrozen(input.header)).toBe(false);
  });
  it("keeps absent and SQL NULL observations distinct and inspectable", () => {
    const missing = sample();
    delete missing.storageText.taxZeroRatedText;
    const nulled = sample();
    nulled.storageText.taxZeroRatedText = null;
    const a = projectSavedSaleReturnEffectContext(missing),
      b = projectSavedSaleReturnEffectContext(nulled);
    expect(Object.hasOwn(a.observation!.storageText, "taxZeroRatedText")).toBe(
      false,
    );
    expect(Object.hasOwn(b.observation!.storageText, "taxZeroRatedText")).toBe(
      true,
    );
    expect(b.observation!.storageText.taxZeroRatedText).toBeNull();
  });
  it("accepts null-prototype data envelopes by detaching known scalar fields", () => {
    const input = sample();
    for (const key of ["header", "incoming", "storageText", "provenance"])
      input[key] = Object.assign(Object.create(null), input[key]);
    const result = projectSavedSaleReturnEffectContext(
      Object.assign(Object.create(null), input),
    );
    expect(result.status).toBe("ready");
    frozenDeep(result);
  });
  it("never grants authority when valid-looking observations are supplied", () => {
    const result = projectSavedSaleReturnEffectContext(sample());
    expect(result.canCommit).toBe(false);
    expect(result.requirements).toContain(
      "trusted-same-transaction-full-raw-and-physical-observation-binding",
    );
    expect(result.requirements).toContain(
      "explicit-current-pg-iso-and-zero-text-preservation-adaptation",
    );
    expect(Object.keys(result)).toEqual([
      "version",
      "profile",
      "canCommit",
      "requirements",
      "status",
      "observation",
      "storage",
      "diagnostics",
    ]);
  });
});
const malformed: {
  name: string;
  mutate: (input: Record<string, any>) => unknown;
}[] = [
  { name: "null input", mutate: () => null },
  { name: "array input", mutate: () => [] },
  { name: "extra authority", mutate: (v) => ({ ...v, canCommit: true }) },
  {
    name: "extra tenant scope",
    mutate: (v) => {
      v.incoming.tenantId = "foreign";
      return v;
    },
  },
  {
    name: "missing envelope",
    mutate: (v) => {
      delete v.storageText;
      return v;
    },
  },
  {
    name: "undefined scalar",
    mutate: (v) => {
      v.header.VCH_TIME = undefined;
      return v;
    },
  },
  {
    name: "number serial",
    mutate: (v) => {
      v.incoming.SR_NO = 1;
      return v;
    },
  },
  {
    name: "boolean text zero",
    mutate: (v) => {
      v.storageText.taxZeroRatedText = false;
      return v;
    },
  },
  {
    name: "extra provenance",
    mutate: (v) => {
      v.provenance.mode = "A";
      return v;
    },
  },
  {
    name: "missing provenance",
    mutate: (v) => {
      delete v.provenance.rowIdentity;
      return v;
    },
  },
  {
    name: "empty provenance",
    mutate: (v) => {
      v.provenance.documentIdentity = "";
      return v;
    },
  },
  {
    name: "oversized provenance",
    mutate: (v) => {
      v.provenance.documentIdentity = "a".repeat(257);
      return v;
    },
  },
  {
    name: "outer whitespace provenance",
    mutate: (v) => {
      v.provenance.rowIdentity = " a";
      return v;
    },
  },
  {
    name: "newline provenance",
    mutate: (v) => {
      v.provenance.rowIdentity = "a\n";
      return v;
    },
  },
  {
    name: "nonascii provenance",
    mutate: (v) => {
      v.provenance.documentVersion = "é";
      return v;
    },
  },
  { name: "inherited envelope", mutate: (v) => Object.create(v) },
  {
    name: "inherited group",
    mutate: (v) => {
      v.header = Object.create(v.header);
      return v;
    },
  },
  {
    name: "symbol envelope",
    mutate: (v) => {
      v[Symbol("extra")] = 1;
      return v;
    },
  },
  {
    name: "nonenumerable known field",
    mutate: (v) => {
      Object.defineProperty(v.header, "VCH_DATE", {
        value: "2026-09-12",
        enumerable: false,
      });
      return v;
    },
  },
];
describe("strict finite envelopes", () => {
  it.each(malformed)("$name", ({ mutate }) => {
    const result = projectSavedSaleReturnEffectContext(mutate(sample()));
    expect(result.status).toBe("invalid-input");
    expect(result.observation).toBeNull();
    expect(result.storage).toBeNull();
    expect(result.canCommit).toBe(false);
    frozenDeep(result);
  });
  it.each(["header", "incoming", "storageText", "provenance"])(
    "does not invoke %s getters",
    (section) => {
      const input = sample();
      let calls = 0;
      const key = Object.keys(input[section])[0]!;
      Object.defineProperty(input[section], key, {
        enumerable: true,
        get() {
          calls++;
          throw new Error("getter");
        },
      });
      expect(projectSavedSaleReturnEffectContext(input).status).toBe(
        "invalid-input",
      );
      expect(calls).toBe(0);
    },
  );
  it("contains an uninspectable descriptor object without claiming its provenance", () => {
    const input = new Proxy(sample(), {
      ownKeys() {
        throw new Error("uninspectable");
      },
    });
    expect(projectSavedSaleReturnEffectContext(input).status).toBe(
      "invalid-input",
    );
  });
});
