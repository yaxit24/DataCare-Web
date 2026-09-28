import { createHash } from "node:crypto";
import { readFileSync } from "node:fs";
import { describe, expect, it } from "vitest";
import {
  composeSaleReturnIncomingLabour,
  SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION,
  SALE_RETURN_INCOMING_LABOUR_COMPOSE_PROFILE,
  type SaleReturnIncomingLabourComposeInput,
} from "../src/saleReturnIncomingLabourCompose.js";
import type { SaleReturnIncomingAggregateState } from "../src/saleReturnIncomingAggregate.js";

const bytes = readFileSync(
  new URL(
    "./fixtures/saleReturnIncomingLabourCompose.independent.json",
    import.meta.url,
  ),
);
interface LiteralCase {
  id: string;
  note: string;
  input: SaleReturnIncomingLabourComposeInput;
  expected: {
    outcome: "applied" | "rejected" | "lookup-required";
    state: SaleReturnIncomingAggregateState;
    diagnosticOrigin?: string;
    dependencyCode?: string;
    aggregateApplied?: boolean;
    billApplied?: boolean;
    taxRecalculated?: boolean;
    rowJournalAdded: number;
    aggregateJournalAdded: number;
  };
}
const fixture = JSON.parse(bytes.toString()) as { cases: LiteralCase[] };
function literal(id: string): LiteralCase {
  const value = fixture.cases.find((entry) => entry.id === id);
  if (!value) throw new Error(`Missing independent literal ${id}`);
  return value;
}
// Intentional dynamic malformed-input builder: production's public parameter is unknown.
const sample = (): Record<string, any> => structuredClone(literal("L01").input);
function frozen(value: unknown): void {
  if (value && typeof value === "object") {
    expect(Object.isFrozen(value)).toBe(true);
    Object.values(value).forEach(frozen);
  }
}
function refusalPreserves(input: Record<string, any>) {
  const before = structuredClone(input.state);
  const result = composeSaleReturnIncomingLabour(input);
  expect(result.status).toBe("rejected");
  expect(result.state).toStrictEqual(before);
  expect(result.state).not.toBe(input.state);
  expect(result).toMatchObject({
    visiblePatch: null,
    nextEvent: null,
    observation: null,
    aggregateApplied: false,
    billApplied: false,
    taxRecalculated: false,
  });
  frozen(result);
  expect(Object.isFrozen(input.state)).toBe(false);
  return result;
}

describe("atomic incoming Return resolved labour composition", () => {
  it("pins the independently authored23 cases without evaluating a reducer to manufacture expectations", () => {
    expect(createHash("sha256").update(bytes).digest("hex")).toBe(
      "fd55edb9173dbc40475d7dd04a63877226600d36c983f20b1421ab013ee73dd6",
    );
    expect(fixture.cases).toHaveLength(23);
    expect(SALE_RETURN_INCOMING_LABOUR_COMPOSE_VERSION).toBe(
      "primary-incoming-labour-compose-v1",
    );
    expect(SALE_RETURN_INCOMING_LABOUR_COMPOSE_PROFILE).toBe(
      "atomic-resolved-copy-row-fold-bill-v1",
    );
  });
  for (const vector of fixture.cases) {
    it(`${vector.id}: ${vector.note}`, () => {
      const input = structuredClone(vector.input);
      const original = structuredClone(input);
      const result = composeSaleReturnIncomingLabour(input);
      expect(result.status).toBe(vector.expected.outcome);
      expect(result.state).toStrictEqual(vector.expected.state);
      expect(input).toStrictEqual(original);
      expect(Object.isFrozen(input)).toBe(false);
      expect(Object.isFrozen(input.state.rows[0]!.state.visible)).toBe(false);
      frozen(result);
      expect(result.state).not.toBe(input.state);
      if (result.status === "applied") {
        expect(result.diagnostics).toEqual([]);
        expect(result.aggregateApplied).toBe(vector.expected.aggregateApplied);
        expect(result.billApplied).toBe(vector.expected.billApplied);
        expect(result.taxRecalculated).toBe(vector.expected.taxRecalculated);
        expect(result.observation).toStrictEqual(input.observation);
        expect(result.state.journal.length - input.state.journal.length).toBe(
          vector.expected.aggregateJournalAdded,
        );
        const previous = input.state.rows.find(
          (row) => row.state.rowIdentity === input.rowIdentity,
        )!;
        const current = result.state.rows.find(
          (row) => row.state.rowIdentity === input.rowIdentity,
        )!;
        expect(
          current.state.journal.length - previous.state.journal.length,
        ).toBe(vector.expected.rowJournalAdded);
        expect(
          current.state.journal.slice(0, previous.state.journal.length),
        ).toStrictEqual(previous.state.journal);
        expect(
          result.state.journal.slice(0, input.state.journal.length),
        ).toStrictEqual(input.state.journal);
      } else {
        expect(result).toMatchObject({
          visiblePatch: null,
          nextEvent: null,
          observation: null,
          aggregateApplied: false,
          billApplied: false,
          taxRecalculated: false,
        });
        expect(result.diagnostics[0]).toMatchObject({
          origin: vector.expected.diagnosticOrigin,
          code: vector.expected.dependencyCode,
        });
        expect(result.state).toStrictEqual(input.state);
      }
    });
  }
  it("a real two-operation sequence preserves the per-prefix bill-tax history and does not restore old manual7", () => {
    const first = composeSaleReturnIncomingLabour(
      structuredClone(literal("L01").input),
    );
    expect(first.status).toBe("applied");
    if (first.status !== "applied")
      throw new Error("Independent first prefix refused");
    expect(first.state).toStrictEqual(literal("L11").input.state);
    const second = composeSaleReturnIncomingLabour({
      ...structuredClone(literal("L11").input),
      state: first.state,
    });
    expect(second.status).toBe("applied");
    expect(second.state).toStrictEqual(literal("L11").expected.state);
    expect(second.state!.bill.matrix[2]![3]).toBe("11.00");
    expect(second.state!.bill.matrix[3]![3]).toBe("121.00");
  });
  it("exposes the pre-calculation copy patch separately from final labour20 and preserves unrelated caches/raw", () => {
    const input = sample();
    const result = composeSaleReturnIncomingLabour(input);
    expect(result.status).toBe("applied");
    if (result.status !== "applied")
      throw new Error("Literal admission refused");
    expect(result.visiblePatch).toEqual({
      13: "BB",
      14: "",
      17: "",
      21: "",
      23: "2.00",
      24: "",
      28: "",
    });
    expect(result.state.rows[0]!.state.visible[24]).toBe("20.00");
    expect(result.nextEvent).toEqual({
      kind: "calculateAfterCopy",
      rowIdentity: input.rowIdentity,
      activeColumn: 13,
      editorText: "BB",
      cause: "labourCodeSelection",
    });
    expect(result.state.raw).toStrictEqual(input.state.raw);
    expect(result.state.rows[0]!.state.raw).toStrictEqual(
      input.state.rows[0].state.raw,
    );
  });

  const invalidCommand: Array<[string, (input: Record<string, any>) => void]> =
    [
      [
        "unknown envelope key",
        (input) => {
          input.save = true;
        },
      ],
      [
        "missing editor text",
        (input) => {
          delete input.editorText;
        },
      ],
      [
        "numeric editor text",
        (input) => {
          input.editorText = 12;
        },
      ],
      [
        "unknown row policy key",
        (input) => {
          input.rowPolicy.isAdmin = true;
        },
      ],
      [
        "unknown phase key",
        (input) => {
          input.context.skipBill = true;
        },
      ],
      [
        "unknown scope authority key",
        (input) => {
          input.scope.contextEpoch = "1";
        },
      ],
      [
        "unsupported observation version",
        (input) => {
          input.observation.version = "invented";
        },
      ],
      [
        "nonfinite policy value",
        (input) => {
          input.rowPolicy.fineColumnWidth = Infinity;
        },
      ],
      [
        "NaN phase value",
        (input) => {
          input.context.taxRoundingDecimals = NaN;
        },
      ],
      [
        "cyclic command",
        (input) => {
          input.cycle = input;
        },
      ],
      [
        "custom command prototype",
        (input) => {
          Object.setPrototypeOf(input, { inherited: true });
        },
      ],
      [
        "custom nested prototype",
        (input) => {
          Object.setPrototypeOf(input.observation, { inherited: true });
        },
      ],
      [
        "sparse observed master array",
        (input) => {
          delete input.observation.masters[0];
        },
      ],
      [
        "foreign saved row company",
        (input) => {
          input.state.rows[0].state.raw.CO_CODE = "02";
        },
      ],
    ];
  it.each(invalidCommand)(
    "%s retains the complete valid original state",
    (_, mutate) => {
      const input = sample();
      mutate(input);
      refusalPreserves(input);
    },
  );
  const invalidState: Array<[string, (input: Record<string, any>) => void]> = [
    [
      "state version",
      (input) => {
        input.state.version = "old";
      },
    ],
    [
      "unknown state key",
      (input) => {
        input.state.authorized = true;
      },
    ],
    [
      "sparse matrix",
      (input) => {
        delete input.state.bill.matrix[4];
      },
    ],
    [
      "sparse rows",
      (input) => {
        delete input.state.rows[0];
      },
    ],
    [
      "source ordinal mismatch",
      (input) => {
        input.state.rows[0].state.visible[0] = "99";
      },
    ],
    [
      "missing comparison cache",
      (input) => {
        delete input.state.rows[0].state.caches[58];
      },
    ],
    [
      "unknown historical event",
      (input) => {
        input.state.journal[0].event.kind = "save";
      },
    ],
    [
      "duplicate row identity",
      (input) => {
        input.state.rows.push(structuredClone(input.state.rows[0]));
        input.state.rows[1].ordinal = 2;
        input.state.rows[1].state.visible[0] = "2";
      },
    ],
  ];
  it.each(invalidState)(
    "%s has no qualified rollback-state observation",
    (_, mutate) => {
      const input = sample();
      mutate(input);
      const original = structuredClone(input);
      const result = composeSaleReturnIncomingLabour(input);
      expect(result.status).toBe("rejected");
      expect(result.state).toBeNull();
      expect(input).toStrictEqual(original);
      frozen(result);
    },
  );
  it("never invokes a command getter and separately recovers its valid own data state", () => {
    const input = sample();
    let calls = 0;
    Object.defineProperty(input, "editorText", {
      get() {
        calls++;
        return "BB";
      },
      enumerable: true,
    });
    const result = refusalPreserves(input);
    expect(calls).toBe(0);
    expect(result.status === "applied" ? null : result.attempted).toEqual({
      rowIdentity: input.rowIdentity,
      field: 13,
      editorText: null,
    });
  });
  it("never invokes a state getter and does not invent a rollback observation", () => {
    const input = sample();
    let calls = 0;
    Object.defineProperty(input, "state", {
      get() {
        calls++;
        throw new Error("getter invoked");
      },
      enumerable: true,
    });
    const result = composeSaleReturnIncomingLabour(input);
    expect(result.status).toBe("rejected");
    expect(result.state).toBeNull();
    expect(calls).toBe(0);
  });
  it("rejects a nonenumerable operation field without discarding a separately valid state", () => {
    const input = sample();
    Object.defineProperty(input, "editorText", {
      value: "BB",
      enumerable: false,
    });
    refusalPreserves(input);
  });
  it("success and refusal objects cannot mutate caller input or later observations", () => {
    const input = sample(),
      before = structuredClone(input);
    const result = composeSaleReturnIncomingLabour(input);
    expect(result.status).toBe("applied");
    if (result.status !== "applied")
      throw new Error("Literal admission refused");
    expect(Reflect.set(result.state.rows[0]!.state.visible, "13", "ZZ")).toBe(
      false,
    );
    expect(Reflect.set(result.state.bill.matrix[2]!, "3", "999")).toBe(false);
    expect(
      Reflect.set(result.observation.masters[0]!.raw, "LBR_VAL", "999"),
    ).toBe(false);
    expect(input).toStrictEqual(before);
    input.editorText = "AA";
    expect(result.nextEvent.editorText).toBe("BB");
    const rejectedInput = sample();
    rejectedInput.expectedObservationVersion = "b".repeat(64);
    const rejected = refusalPreserves(rejectedInput);
    expect(Reflect.set(rejected.state!.raw, "TAX_AMT", "999")).toBe(false);
    expect(rejectedInput.state.raw.TAX_AMT).toBe("7.0000");
  });
  it("an output journal exceeding the admitted text budget rejects atomically instead of publishing an unusable next state", () => {
    const input = sample();
    input.state.raw.PADDING = "";
    const size = (value: unknown): number => {
      if (typeof value === "string") return value.length;
      if (Array.isArray(value))
        return value.reduce(
          (total, entry, index) => total + String(index).length + size(entry),
          0,
        );
      if (value && typeof value === "object")
        return Object.entries(value).reduce(
          (total, [key, entry]) => total + key.length + size(entry),
          0,
        );
      return 0;
    };
    input.state.raw.PADDING = "x".repeat(1000000 - size(input));
    expect(size(input)).toBe(1000000);
    const result = refusalPreserves(input);
    expect(
      result.status === "applied" ? null : result.diagnostics[0],
    ).toMatchObject({ origin: "calculation", code: "unsupported-composition" });
  });
});
