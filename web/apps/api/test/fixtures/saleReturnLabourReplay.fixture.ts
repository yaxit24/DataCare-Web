import { randomUUID } from "node:crypto";
import type { PrismaClient } from "@datacare/db";
import { expect } from "vitest";
import golden from "./saleReturnLabourReplay.independent.json";
import {
  billInsert,
  billKey,
  billTables,
  billSelected,
  billVoucher,
  seedBillFixture,
  cleanBillFixture,
  assertBillTestDatabase,
} from "./saleReturnBillReplay.fixture.js";
import type {
  SaleReturnLabourReplayState,
  SaleReturnLabourPrefixInput,
  SaleReturnLabourPrefix,
  SaleReturnLabourReplayEvent,
} from "../../src/modules/sales/saleReturnLabourReplay.js";
export {
  golden,
  billInsert,
  assertBillTestDatabase,
  billSelected,
  billVoucher,
};
type Owner = Pick<PrismaClient, "$executeRawUnsafe" | "$queryRawUnsafe">;
export const allLabourTables = [
  ...billTables,
  "LBR_MAST",
  "auth_session",
  "CO_MAST",
  "LOCT_MAST",
  "LOGIN_MAST",
  "USER_SET",
] as const;
export const scopeFor = (tenantId: string) => ({ tenantId, ...billSelected });
export async function cleanLabourFixture(owner: Owner, tenants: string[]) {
  await owner.$executeRawUnsafe(
    'DELETE FROM "LBR_MAST" WHERE tenant_id=ANY($1::text[])',
    tenants,
  );
  await cleanBillFixture(owner, tenants, true);
}
export async function seedLabourFixture(
  owner: Owner,
  tenants: string[],
  passwordHash = "not-used-by-direct-service",
) {
  await seedBillFixture(owner, tenants);
  for (const tenantId of tenants) {
    const key = billKey(tenantId);
    await owner.$executeRawUnsafe(
      'DELETE FROM "SL_DETL_RTN" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3',
      tenantId,
      billSelected.coBook,
      billVoucher,
    );
    await owner.$executeRawUnsafe(
      'DELETE FROM "SL_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"=$3',
      tenantId,
      billSelected.coBook,
      billVoucher,
    );
    await billInsert(owner, "SL_DATA", { ...golden.header, ...key });
    for (const row of golden.rows)
      await billInsert(owner, "SL_DETL_RTN", { ...row, ...key });
    for (const master of golden.masters)
      await billInsert(owner, "LBR_MAST", { tenant_id: tenantId, ...master });
    await billInsert(owner, "CO_MAST", {
      tenant_id: tenantId,
      CO_CODE: "01",
      LC_CODE: "01",
      CO_NAME: "Labour preview fixture",
    });
    await billInsert(owner, "LOCT_MAST", {
      tenant_id: tenantId,
      CO_CODE: "01",
      LC_CODE: "01",
      LC_NAME: "Main",
    });
    for (const [user, form] of [
      ["view", "Sales Return"],
      ["otherform", "Sales"],
    ] as const) {
      await billInsert(owner, "LOGIN_MAST", {
        tenant_id: tenantId,
        CO_CODE: "01",
        LOGIN_NAME: user,
        LOGIN_PWD: passwordHash,
        LOGIN_CATG: "USER",
        USER_UPDATE: "N",
        USER_DELETE: "N",
        USER_PRINT: "N",
        PASSWORD_RESET_REQUIRED: "N",
      });
      await billInsert(owner, "USER_SET", {
        tenant_id: tenantId,
        CO_CODE: "01",
        LC_CODE: "01",
        USER_NAME: user,
        MAIN_MENU: "Sales",
        SUB_MENU: form,
        FRM_VIEW: "Y",
        FRM_EDIT: "N",
        FRM_DELETE: "N",
        FRM_PRINT: "N",
      });
    }
  }
}
export async function insertLabourSession(
  owner: Owner,
  tenantId: string,
  loginName = "view",
) {
  const sessionId = randomUUID();
  await owner.$executeRawUnsafe(
    `INSERT INTO "auth_session" ("tenant_id","session_id","login_name","login_co_code","co_code","lc_code","co_year","refresh_jti_hash","expires_at") VALUES($1,$2,$3,'01','01','01',$4,$5,clock_timestamp()+interval '1 day')`,
    tenantId,
    sessionId,
    loginName,
    billSelected.coYear,
    "a".repeat(64),
  );
  return {
    tenantId,
    sessionId,
    loginName,
    loginCoCode: "01",
    coCode: "01",
    lcCode: "01",
    coYear: billSelected.coYear,
    contextEpoch: "1",
  };
}
export async function snapshotLabourFixture(owner: Owner, tenants: string[]) {
  const result: Record<string, unknown> = {};
  for (const table of allLabourTables)
    result[table] = await owner.$queryRawUnsafe(
      `SELECT to_jsonb(t)::text AS raw,t.xmin::text AS revision,t.ctid::text AS locator FROM "${table}" t WHERE tenant_id=ANY($1::text[]) ORDER BY to_jsonb(t)::text`,
      tenants,
    );
  return result;
}
export function firstPrefix(
  dto: SaleReturnLabourReplayState,
): SaleReturnLabourPrefixInput {
  const row = dto.rows[0]!;
  return {
    baseVersion: dto.baseVersion,
    rowIdentity: row.rowIdentity,
    prefixVersion: row.initialPrefixVersion,
    events: [],
  };
}
export const withPrefix = (
  input: SaleReturnLabourPrefixInput,
  prefix: SaleReturnLabourPrefix,
): SaleReturnLabourPrefixInput => ({
  ...input,
  prefixVersion: prefix.prefixVersion,
  events: prefix.events,
});
export const moneyEvent = (
  column: number,
  text: string,
): SaleReturnLabourReplayEvent => ({
  kind: "moneyLeave",
  fieldId: `x13.primary-incoming.c${column}`,
  editorText: text,
});
export function assertGolden(
  actual: { preview: unknown; phase: unknown },
  name: keyof typeof golden.expected.prefixes,
) {
  expect(actual.preview).toEqual(golden.expected.prefixes[name].preview);
  expect(actual.phase).toEqual(golden.expected.prefixes[name].phase);
}
