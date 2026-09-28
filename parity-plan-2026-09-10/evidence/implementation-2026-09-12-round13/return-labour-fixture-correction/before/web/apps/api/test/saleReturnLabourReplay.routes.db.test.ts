import { randomUUID } from "node:crypto";
import { PrismaClient } from "@prisma/client";
import { SignJWT } from "jose";
import type { FastifyInstance, LightMyRequestResponse } from "fastify";
import { afterAll, beforeAll, beforeEach, describe, it, expect } from "vitest";
import { buildApp } from "../src/app.js";
import { hashPassword } from "../src/modules/auth/password.js";
import { verifyAccessToken } from "../src/modules/auth/jwt.js";
import type {
  SaleReturnLabourReplayState,
  SaleReturnLabourPrefixInput,
  SaleReturnLabourObservationResult,
  SaleReturnLabourReplayResult,
  SaleReturnLabourReplayEvent,
} from "../src/modules/sales/saleReturnLabourReplay.js";
import {
  golden,
  billInsert,
  billSelected,
  billVoucher,
  assertBillTestDatabase,
  seedLabourFixture,
  cleanLabourFixture,
  snapshotLabourFixture,
  firstPrefix,
  withPrefix,
  moneyEvent,
  assertGolden,
} from "./fixtures/saleReturnLabourReplay.fixture.js";
const run =
  process.env.RUN_DB_INTEGRITY_TESTS === "1" ? describe : describe.skip;
run("real authenticated labour observation and append routes", () => {
  const tenant = "r13-labour-http",
    foreign = "r13-labour-h-foreign",
    tenants = [tenant, foreign],
    secret = "labour-preview-http-real-session-secret-over-thirty-two";
  const password = "Labour-Preview-Test!2026";
  type Context = {
    sessionId: string;
    contextEpoch: string;
    coCode: string;
    lcCode: string;
    coYear: string;
  };
  type Login = { cookie: string; context: Context };
  let owner: PrismaClient,
    runtime: PrismaClient,
    app: FastifyInstance,
    passwordHash: string;
  let signed: Login, unrelated: Login, other: Login;
  const completed = new Map<string, () => void>();
  const sql = (q: string, ...args: unknown[]) =>
    owner.$executeRawUnsafe(q, ...args);
  const snapshot = () => snapshotLabourFixture(owner, tenants);
  const endpoint = (
    action = "incoming-labour-replay-state",
    selected: Record<string, string> = billSelected,
  ) =>
    `/sales-returns/${billVoucher}/${action}?${new URLSearchParams(selected)}`;
  const cookie = (response: LightMyRequestResponse) => {
    const c = response.headers["set-cookie"];
    return (Array.isArray(c) ? c : c ? [c] : [])
      .map((v) => v.split(";", 1)[0])
      .join("; ");
  };
  async function inject(
    method: "GET" | "POST",
    url: string,
    payload?: unknown,
    login: Login | null = signed,
    pair: Record<string, string> | null | undefined = undefined,
  ) {
    const id = randomUUID();
    let resolve!: () => void;
    const done = new Promise<void>((r) => {
      resolve = r;
    });
    completed.set(id, resolve);
    let timer: ReturnType<typeof setTimeout> | undefined;
    try {
      const response = await app.inject({
        method,
        url,
        headers: {
          "x-labour-test-id": id,
          ...(login ? { cookie: login.cookie } : {}),
          ...(pair === null
            ? {}
            : (pair ??
              (login
                ? {
                    "x-session-context-id": login.context.sessionId,
                    "x-session-context-epoch": login.context.contextEpoch,
                  }
                : {}))),
        },
        ...(payload === undefined ? {} : { payload: payload as object }),
      });
      await Promise.race([
        done,
        new Promise<never>((_, reject) => {
          timer = setTimeout(
            () =>
              reject(new Error("onResponse/audit completion did not settle")),
            10000,
          );
        }),
      ]);
      return response;
    } finally {
      if (timer) clearTimeout(timer);
      completed.delete(id);
    }
  }
  async function login(loginName = "view", tenantId = tenant): Promise<Login> {
    // Use app.inject directly for login; no authenticated request audit is expected.
    const response = await app.inject({
      method: "POST",
      url: "/auth/login",
      headers: { "x-tenant-id": tenantId },
      payload: {
        loginName,
        password,
        coCode: "01",
        lcCode: "01",
        coYear: billSelected.coYear,
      },
    });
    expect(response.statusCode, response.body).toBe(200);
    return { cookie: cookie(response), context: response.json().context };
  }
  async function state() {
    const r = await inject("GET", endpoint());
    expect(r.statusCode, r.body).toBe(200);
    expect(r.headers["cache-control"]).toBe("no-store");
    return r.json<SaleReturnLabourReplayState>();
  }
  async function lookup(
    p: SaleReturnLabourPrefixInput,
    code: string,
    field = 13,
  ) {
    const r = await inject("POST", endpoint("incoming-labour-observation"), {
      ...p,
      fieldId: `x13.primary-incoming.c${field}`,
      editorText: code,
    });
    expect(r.statusCode, r.body).toBe(200);
    return r.json<SaleReturnLabourObservationResult>();
  }
  async function append(
    p: SaleReturnLabourPrefixInput,
    e: SaleReturnLabourReplayEvent,
  ) {
    return inject("POST", endpoint("incoming-labour-replay"), {
      ...p,
      event: e,
    });
  }
  async function select(p: SaleReturnLabourPrefixInput, code: string) {
    const seen = await lookup(p, code);
    const r = await append(p, {
      kind: "labourEnter",
      fieldId: seen.fieldId,
      editorText: seen.editorText,
      observationVersion: seen.observationVersion,
    });
    expect(r.statusCode, r.body).toBe(200);
    return r.json<SaleReturnLabourReplayResult>();
  }
  const audit = () =>
    owner.$queryRawUnsafe<
      Array<{ action: string; path: string; status: number }>
    >(
      'SELECT action,path,status FROM "audit_log" WHERE tenant_id=$1 ORDER BY id',
      tenant,
    );
  beforeAll(async () => {
    assertBillTestDatabase();
    owner = new PrismaClient({
      datasources: { db: { url: process.env.MIGRATE_DATABASE_URL } },
    });
    runtime = new PrismaClient();
    passwordHash = await hashPassword(password);
    app = await buildApp({ prisma: runtime, secret, secureCookies: false });
    app.addHook("onResponse", async (req) => {
      const id = req.headers["x-labour-test-id"];
      if (typeof id === "string") completed.get(id)?.();
    });
  });
  beforeEach(async () => {
    await cleanLabourFixture(owner, tenants);
    await seedLabourFixture(owner, tenants, passwordHash);
    signed = await login();
    unrelated = await login("otherform");
    other = await login("view", foreign);
  });
  afterAll(async () => {
    if (app) await app.close();
    if (owner) {
      await cleanLabourFixture(owner, tenants);
      await owner.$disconnect();
    }
    if (runtime) await runtime.$disconnect();
  });
  it("loads complete literal phases with View-only rights and no business/session edits", async () => {
    const before = await snapshot(),
      dto = await state();
    expect(dto.context).toEqual(signed.context);
    expect(dto.billReplay.phases.loaded).toEqual(golden.expected.loaded);
    expect(dto.billReplay.phases.opened).toEqual(golden.expected.opened);
    expect(dto.capabilities).toEqual({
      canPreview: true,
      canPreviewClosing: false,
      canSaveNumeric: false,
      canApplySource: false,
    });
    expect(await snapshot()).toEqual(before);
    expect(await audit()).toEqual([]);
  });
  it("runs lookup and two source code prefixes without numeric writes, and audits exact POST outcomes", async () => {
    const p = firstPrefix(await state()),
      before = await snapshot(),
      bb = await select(p, "BB");
    assertGolden(bb.prefix, "bb");
    const aa = await select(withPrefix(p, bb.prefix), "AA");
    assertGolden(aa.prefix, "bb-aa");
    expect(aa.prefix.events).toHaveLength(2);
    expect(await snapshot()).toEqual(before);
    expect(await audit()).toEqual([
      {
        action: "POST",
        path: "/sales-returns/:vchNo/incoming-labour-observation",
        status: 200,
      },
      {
        action: "POST",
        path: "/sales-returns/:vchNo/incoming-labour-replay",
        status: 200,
      },
      {
        action: "POST",
        path: "/sales-returns/:vchNo/incoming-labour-observation",
        status: 200,
      },
      {
        action: "POST",
        path: "/sales-returns/:vchNo/incoming-labour-replay",
        status: 200,
      },
    ]);
  });
  it("requires both retained page headers and never borrows another session descriptor", async () => {
    const p = firstPrefix(await state()),
      request = { ...p, fieldId: "x13.primary-incoming.c13", editorText: "BB" },
      before = await snapshot();
    for (const pair of [
      null,
      { "x-session-context-id": signed.context.sessionId },
      {
        "x-session-context-id": other.context.sessionId,
        "x-session-context-epoch": other.context.contextEpoch,
      },
    ]) {
      const r = await inject(
        "POST",
        endpoint("incoming-labour-observation"),
        request,
        signed,
        pair,
      );
      expect(r.statusCode, r.body).toBe(409);
      expect(r.json().error).toBe("context-stale");
      expect(r.headers["cache-control"]).toBe("no-store");
    }
    expect(await snapshot()).toEqual(before);
    // Missing both reaches route after authentication; partial/mismatch are denied before state.session exists.
    expect(await audit()).toEqual([
      {
        action: "POST",
        path: "/sales-returns/:vchNo/incoming-labour-observation",
        status: 409,
      },
    ]);
  });
  it("denies anonymous, unrelated View and forced reset without accepting code events", async () => {
    expect((await inject("GET", endpoint(), undefined, null)).statusCode).toBe(
      401,
    );
    expect(
      (await inject("GET", endpoint(), undefined, unrelated)).statusCode,
    ).toBe(403);
    await sql(
      'UPDATE "LOGIN_MAST" SET "PASSWORD_RESET_REQUIRED"=\'Y\' WHERE tenant_id=$1 AND "LOGIN_NAME"=\'view\'',
      tenant,
    );
    expect((await inject("GET", endpoint())).statusCode).toBe(403);
  });
  it("rejects a foreign base and malformed authority/policy fields while preserving business state", async () => {
    const p = firstPrefix(await state()),
      request = { ...p, fieldId: "x13.primary-incoming.c13", editorText: "BB" },
      before = await snapshot();
    const foreignResponse = await inject(
      "POST",
      endpoint("incoming-labour-observation"),
      request,
      other,
    );
    expect(foreignResponse.statusCode, foreignResponse.body).toBe(409);
    for (const extra of [
      { raw: { LBR_VAL: "2" } },
      { rowPolicy: {} },
      { sessionId: signed.context.sessionId },
      { currentRow: 1 },
    ]) {
      const r = await inject("POST", endpoint("incoming-labour-observation"), {
        ...request,
        ...extra,
      });
      expect(r.statusCode, r.body).toBe(400);
    }
    expect(await snapshot()).toEqual(before);
    expect((await audit()).map((r) => r.status)).toEqual([400, 400, 400, 400]);
  });
  it("fails an old bearer after actual same-scope selection and old page pair after fresh bearer adoption", async () => {
    const old = signed;
    const response = await inject("POST", "/context/select", {
      coCode: "01",
      lcCode: "01",
      coYear: billSelected.coYear,
      expectedContextEpoch: old.context.contextEpoch,
      selectionId: randomUUID(),
    });
    expect(response.statusCode, response.body).toBe(200);
    const fresh = {
      cookie: cookie(response),
      context: response.json().context as Context,
    };
    expect(fresh.context.contextEpoch).not.toBe(old.context.contextEpoch);
    const afterSelect = await snapshot();
    expect((await inject("GET", endpoint(), undefined, old)).statusCode).toBe(
      401,
    );
    const stale = await inject("GET", endpoint(), undefined, fresh, {
      "x-session-context-id": old.context.sessionId,
      "x-session-context-epoch": old.context.contextEpoch,
    });
    expect(stale.statusCode, stale.body).toBe(409);
    expect(stale.json().error).toBe("context-stale");
    expect(await snapshot()).toEqual(afterSelect);
  });
  it("rejects real signed access claims lacking epoch rather than supplying a default", async () => {
    const pair = signed.cookie
      .split("; ")
      .find((c) => c.startsWith("access="))!;
    const claims = await verifyAccessToken(
      decodeURIComponent(pair.slice(7)),
      secret,
    );
    const legacy: Record<string, unknown> = { ...claims };
    delete legacy.contextEpoch;
    delete legacy.iat;
    delete legacy.exp;
    const jwt = await new SignJWT(legacy)
      .setProtectedHeader({ alg: "HS256" })
      .setIssuedAt()
      .setExpirationTime("10m")
      .sign(new TextEncoder().encode(secret));
    const response = await inject("GET", endpoint(), undefined, {
      ...signed,
      cookie: `access=${jwt}`,
    });
    expect(response.statusCode, response.body).toBe(401);
  });
  it("maps changed historical master to409 without returning or accepting a replacement prefix", async () => {
    const p = firstPrefix(await state()),
      bb = await select(p, "BB");
    await sql(
      'UPDATE "LBR_MAST" SET "LBR_VAL"=3 WHERE tenant_id=$1 AND "LBR_CODE"=\'BB\'',
      tenant,
    );
    const before = await snapshot();
    const response = await inject(
      "POST",
      endpoint("incoming-labour-observation"),
      {
        ...withPrefix(p, bb.prefix),
        fieldId: "x13.primary-incoming.c13",
        editorText: "AA",
      },
    );
    expect(response.statusCode, response.body).toBe(409);
    expect(response.json()).toMatchObject({ error: "master-version-conflict" });
    expect(response.json()).not.toHaveProperty("details.recovery");
    expect(await snapshot()).toEqual(before);
  });
  it("returns the exact accepted prefix after a real post-copy bill rejection", async () => {
    await sql(
      'UPDATE "CO_SET" SET "SL_AMT_TYPE"=\'F\' WHERE tenant_id=$1',
      tenant,
    );
    await sql(
      'UPDATE "SL_DATA" SET "TAX_PRC"=99999 WHERE tenant_id=$1 AND "CO_BOOK"=\'R11\'',
      tenant,
    );
    await sql(
      `UPDATE "SL_DETL_RTN" SET "ITM_GWT"=10000000000,"ITM_NWT"=10000000000,"ITM_TOUCH"=1000000000,"ITM_RATE"=1000000000000000,"LBR_PRC"=0,"LBR_RATE"=0,"LBR_AMT"=0 WHERE tenant_id=$1 AND "CO_BOOK"='R11'`,
      tenant,
    );
    await billInsert(owner, "LBR_MAST", {
      tenant_id: tenant,
      CO_CODE: "01",
      LBR_CODE: "P2",
      LBR_CATG: "02",
      LBR_VAL: "9999999999",
    });
    const p = firstPrefix(await state()),
      r = await append(p, moneyEvent(21, "0"));
    expect(r.statusCode, r.body).toBe(200);
    const prior = r.json<SaleReturnLabourReplayResult>().prefix,
      input = withPrefix(p, prior),
      seen = await lookup(input, "P2"),
      before = await snapshot();
    const failed = await append(input, {
      kind: "labourEnter",
      fieldId: seen.fieldId,
      editorText: "P2",
      observationVersion: seen.observationVersion,
    });
    expect(failed.statusCode, failed.body).toBe(422);
    expect(failed.json()).toMatchObject({
      error: "calculation-rejected",
      details: {
        eventIndex: 1,
        recovery: prior,
        diagnostics: [
          expect.objectContaining({
            code: "unsupported-precision",
            stage: "bill matrix r2",
          }),
        ],
      },
    });
    expect(await snapshot()).toEqual(before);
    expect((await audit()).map((v) => v.status)).toEqual([200, 200, 422]);
  });
  it("keeps legacy preview responses/allowlists unchanged and never exposes labour in v1", async () => {
    const dto = await state(),
      old = await inject("GET", endpoint("incoming-bill-replay-state"));
    expect(old.statusCode, old.body).toBe(200);
    expect(old.json()).toEqual(dto.billReplay);
    const row = await inject("GET", endpoint("incoming-replay-state"));
    expect(row.statusCode, row.body).toBe(200);
    expect(row.json()).toEqual(dto.billReplay.rowReplay);
    expect(
      row.json().rows[0].fieldCapabilities.map((v: any) => v.fieldId),
    ).toEqual(
      [19, 20, 21, 23, 24, 25, 26, 27, 28, 36, 37, 38].map(
        (i) => `x13.primary-incoming.c${i}`,
      ),
    );
  });
});
