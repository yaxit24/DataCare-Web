import { createHash } from "node:crypto";
import { readFileSync } from "node:fs";
import { describe, it, expect, vi } from "vitest";
import {
  saleReturnLabourObserveInput,
  saleReturnLabourAppendInput,
  SaleReturnLabourReplayError,
} from "../src/modules/sales/saleReturnLabourReplay.js";
const hash = "a".repeat(64),
  id = "b".repeat(64);
const prefix = () => ({
  baseVersion: hash,
  rowIdentity: id,
  prefixVersion: "c".repeat(64),
  events: [] as unknown[],
});
const codeEvent = () => ({
  kind: "labourEnter",
  fieldId: "x13.primary-incoming.c13",
  editorText: "BB",
  observationVersion: "d".repeat(64),
});
const request = () => ({ ...prefix(), event: codeEvent() });
describe("saved labour replay exact transport", () => {
  it("pins independently authored complete reachable matrices before API code", () => {
    const bytes = readFileSync(
      new URL(
        "./fixtures/saleReturnLabourReplay.independent.json",
        import.meta.url,
      ),
    );
    expect(createHash("sha256").update(bytes).digest("hex")).toBe(
      "8c2e2ba9a985a1e57e353bcbf742e8b350fac47cd34e6cf96f7cb283adbeb78b",
    );
    const x = JSON.parse(bytes.toString());
    expect(Object.keys(x.expected.prefixes)).toHaveLength(8);
    for (const p of Object.values(x.expected.prefixes) as any[]) {
      expect(Object.keys(p.preview.visible)).toHaveLength(63);
      expect(Object.keys(p.preview.caches)).toHaveLength(8);
      expect(Object.keys(p.phase.incomingTotals)).toHaveLength(71);
      expect(p.phase.bill.matrix).toHaveLength(9);
      for (const row of p.phase.bill.matrix) expect(row).toHaveLength(6);
    }
  });
  it("detaches a complete repeated mixed prefix without deduplicating exact text", () => {
    const e = codeEvent();
    const r = {
      ...prefix(),
      events: [
        e,
        e,
        {
          kind: "moneyLeave",
          fieldId: "x13.primary-incoming.c27",
          editorText: "01.00",
        },
      ],
      event: e,
    };
    const result = saleReturnLabourAppendInput(r);
    r.events[0]!.editorText = "AA";
    expect(result.events).toHaveLength(3);
    expect(result.events[0]!.editorText).toBe("BB");
    expect(result.events[1]!.editorText).toBe("BB");
    expect(result.events[2]!.editorText).toBe("01.00");
    expect(result.event.editorText).toBe("BB");
    expect(Object.isFrozen(r)).toBe(false);
  });
  it("keeps lookup outside the journal", () => {
    const r = {
      ...prefix(),
      fieldId: "x13.primary-incoming.c29",
      editorText: "TA",
    };
    expect(saleReturnLabourObserveInput(r)).toEqual(r);
  });
  for (const [name, mutate] of [
    [
      "extra raw",
      (r: any) => {
        r.raw = { LBR_VAL: "2" };
      },
    ],
    [
      "extra policy",
      (r: any) => {
        r.event.rowPolicy = {};
      },
    ],
    [
      "missing version",
      (r: any) => {
        delete r.event.observationVersion;
      },
    ],
    [
      "upper hash",
      (r: any) => {
        r.baseVersion = "A".repeat(64);
      },
    ],
    [
      "short hash",
      (r: any) => {
        r.rowIdentity = "a";
      },
    ],
    [
      "hash newline",
      (r: any) => {
        r.prefixVersion += "\n";
      },
    ],
    [
      "number code",
      (r: any) => {
        r.event.editorText = 2;
      },
    ],
    [
      "blank code",
      (r: any) => {
        r.event.editorText = "";
      },
    ],
    [
      "space code",
      (r: any) => {
        r.event.editorText = "B ";
      },
    ],
    [
      "wide code",
      (r: any) => {
        r.event.editorText = "BBB";
      },
    ],
    [
      "unicode code",
      (r: any) => {
        r.event.editorText = "β";
      },
    ],
    [
      "newline code",
      (r: any) => {
        r.event.editorText = "B\n";
      },
    ],
    [
      "wrong field",
      (r: any) => {
        r.event.fieldId = "x13.primary-incoming.c19";
      },
    ],
    [
      "kind coercion",
      (r: any) => {
        r.event.kind = "leaveCell";
      },
    ],
    [
      "money extra observation",
      (r: any) => {
        r.event = {
          kind: "moneyLeave",
          fieldId: "x13.primary-incoming.c19",
          editorText: "1",
          observationVersion: hash,
        };
      },
    ],
    [
      "money unicode",
      (r: any) => {
        r.event = {
          kind: "moneyLeave",
          fieldId: "x13.primary-incoming.c19",
          editorText: "1\u2028",
        };
      },
    ],
    [
      "money oversized",
      (r: any) => {
        r.event = {
          kind: "moneyLeave",
          fieldId: "x13.primary-incoming.c19",
          editorText: "12345678901",
        };
      },
    ],
    [
      "unsupported numeric field",
      (r: any) => {
        r.event = {
          kind: "moneyLeave",
          fieldId: "x13.primary-incoming.c16",
          editorText: "1",
        };
      },
    ],
    [
      "old journal coercion",
      (r: any) => {
        r.events = "[]";
      },
    ],
    [
      "sparse journal",
      (r: any) => {
        r.events = new Array(1);
      },
    ],
    [
      "array property",
      (r: any) => {
        r.events.x = 1;
      },
    ],
    [
      "too many old events",
      (r: any) => {
        r.events = Array.from({ length: 101 }, codeEvent);
      },
    ],
    [
      "append at100",
      (r: any) => {
        r.events = Array.from({ length: 100 }, codeEvent);
      },
    ],
  ] as const)
    it(`rejects ${name}`, () => {
      const r = request();
      mutate(r);
      expect(() => saleReturnLabourAppendInput(r)).toThrow(
        SaleReturnLabourReplayError,
      );
    });
  it("allows lookup at100 without accepting a101st event", () =>
    expect(
      saleReturnLabourObserveInput({
        ...prefix(),
        events: Array.from({ length: 100 }, codeEvent),
        fieldId: "x13.primary-incoming.c13",
        editorText: "BB",
      }).events,
    ).toHaveLength(100));
  it("never invokes request, kind or array-index getters", () => {
    const getter = vi.fn(() => {
      throw new Error("must not invoke");
    });
    const values = [
      Object.defineProperty(request(), "event", {
        enumerable: true,
        get: getter,
      }),
      {
        ...request(),
        event: Object.defineProperty({}, "kind", {
          enumerable: true,
          get: getter,
        }),
      },
      {
        ...request(),
        events: Object.defineProperty([null], "0", {
          enumerable: true,
          get: getter,
        }),
      },
    ];
    for (const value of values)
      expect(() => saleReturnLabourAppendInput(value)).toThrow(
        SaleReturnLabourReplayError,
      );
    expect(getter).not.toHaveBeenCalled();
  });
  it("rejects symbol and custom-prototype envelopes without caller mutation", () => {
    const symbolic = { ...request(), [Symbol("extra")]: true };
    expect(() => saleReturnLabourAppendInput(symbolic)).toThrow();
    const custom = Object.assign(Object.create({ inherited: true }), request());
    expect(() => saleReturnLabourAppendInput(custom)).toThrow();
    expect(Object.isFrozen(symbolic)).toBe(false);
  });
  it("bounds the complete public error envelope without truncating recovery/diagnostics", () => {
    const envelope = (error: SaleReturnLabourReplayError) => ({
      error: error.code,
      message: error.message,
      ...(error.details === undefined ? {} : { details: error.details }),
    });
    const plain = {
      error: "calculation-rejected",
      message: "failed",
      details: {
        diagnostics: [{ code: "unsupported-precision", message: "" }],
      },
    };
    const room = 2097152 - Buffer.byteLength(JSON.stringify(plain), "utf8");
    const at = new SaleReturnLabourReplayError(
      422,
      "calculation-rejected",
      "failed",
      {
        diagnostics: [
          { code: "unsupported-precision", message: "x".repeat(room) },
        ],
      },
    );
    expect(Buffer.byteLength(JSON.stringify(envelope(at)), "utf8")).toBe(
      2097152,
    );
    expect(at.code).toBe("calculation-rejected");
    const above = new SaleReturnLabourReplayError(
      422,
      "calculation-rejected",
      "failed",
      {
        diagnostics: [
          { code: "unsupported-precision", message: "x".repeat(room + 1) },
        ],
      },
    );
    expect(above).toMatchObject({
      statusCode: 422,
      code: "unsupported-output",
    });
    expect(above.details).toBeUndefined();
    expect(
      Buffer.byteLength(JSON.stringify(envelope(above)), "utf8"),
    ).toBeLessThan(2097152);
  });
});
