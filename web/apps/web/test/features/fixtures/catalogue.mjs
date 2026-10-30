/**
 * Feature E2E sample-data catalogue.
 *
 * The base company is created by the real web provisioning routine (`seedCompany`, the same code a new company
 * gets from Admin → Provision Company), so every book, BOOK_DETL slot, system account, tax code and SRNO_MAST
 * counter the screens see is the one a real fresh company has. The packs below add only what a shop enters
 * itself (items, groups, parties, users, opening stock) plus the edge-case variants the matrices need.
 *
 * Packs follow docs/master-parity-plan-2026-09-29/04-verification-playbook.md §2 "Required fixture packs".
 * Rules:
 * - Fixtures seed masters and sentinels only. The voucher under test is always created through the screen.
 * - Values are deliberately non-default (touch 91.6, rate 6123.45, making 237.5) so a dropped field cannot
 *   pass by coincidence.
 * - A second tenant holds a same-numbered sentinel voucher so a cross-scope leak shows up as a changed row.
 */
import assert from 'node:assert/strict';
import { SECOND_TENANT, TENANT } from '../harness.mjs';

export const USERS = Object.freeze({
  admin: { user: 'e2eadmin', category: 'ADMIN' },
  clerk: { user: 'e2eclerk', category: 'USER' }, // may view/create/edit sales, may NOT delete
});

export const ITEMS = Object.freeze({
  gold: { code: 'GLD22', name: 'GOLD 22K ORNAMENT', type: 'G', group: 'E1' },
  silver: { code: 'SLV92', name: 'SILVER 925 ORNAMENT', type: 'S', group: 'E2' },
});

export const PARTIES = Object.freeze({
  local: { code: 'E2ELOC', name: 'E2E LOCAL CUSTOMER', gstType: 'L', pan: 'ABCDE1234F' },
  interState: { code: 'E2EINT', name: 'E2E INTERSTATE CUSTOMER', gstType: 'I', pan: 'PQRST6789K' },
  bank: { code: 'E2EBANK', name: 'E2E BANK A/C' },
});

/** What the matrices may rely on; hashed into the run record's fixtureHash. */
export const FIXTURE_MANIFEST = Object.freeze({
  base: 'seedCompany(tenant, "01", { coName: "E2E Jeweller", lcCode: "01" }) — real web provisioning',
  years: ['current fiscal year (seedCompany)', '2024-2025 (historic)'],
  users: USERS,
  items: ITEMS,
  parties: PARTIES,
  groups: { E1: 'SALES/PURCHASE', E2: 'SLVSALE/SLVPURC' },
  openingStock: { [ITEMS.gold.code]: 500, [ITEMS.silver.code]: 2000 },
  sentinel: `${SECOND_TENANT}: same company code 01, SL book, voucher 00001`,
});

export async function seedCatalogue(stack, { password }) {
  const sql = (query, ...params) => stack.owner.$executeRawUnsafe(query, TENANT, ...params);
  const created = await stack.seedCompany(stack.runtime, TENANT, '01', {
    coName: 'E2E Jeweller',
    lcCode: '01',
  });
  assert(created, 'seedCompany must provision the base company');

  // F06: a historic year next to the current one, so year scoping is exercised.
  await sql(
    `INSERT INTO "YEAR_MAST"(tenant_id,"CO_CODE","CO_YEAR","OP_DATE","CL_DATE")
     SELECT $1::text,'01','2024-2025','2024-04-01','2025-03-31'
      WHERE NOT EXISTS (SELECT 1 FROM "YEAR_MAST" WHERE tenant_id=$1::text AND "CO_CODE"='01' AND "CO_YEAR"='2024-2025')`,
  );

  // F02: item groups name both income and expense heads (GROUP_MAST.SALE_AC / PURC_AC).
  await sql(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC")
     VALUES ($1,'01','E1','E2E GOLD','SALES','PURCHASE'),($1,'01','E2','E2E SILVER','SLVSALE','SLVPURC')`,
  );
  for (const item of Object.values(ITEMS))
    await sql(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE") VALUES ($1,'01',$2,$3,$4,$5)`,
      item.code,
      item.name,
      item.type,
      item.group,
    );

  // F04: a local and an inter-state customer (CGST+SGST vs IGST), and a bank account for electronic tender.
  for (const party of [PARTIES.local, PARTIES.interState])
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR","AC_GST_TYPE","AC_PANNO")
       VALUES ($1,'01','01',$2,$3,'10',$4,$5)`,
      party.code,
      party.name,
      party.gstType,
      party.pan,
    );
  await sql(
    `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GR") VALUES ($1,'01','01',$2,$3,'02')`,
    PARTIES.bank.code,
    PARTIES.bank.name,
  );

  // F05: opening loose stock so a sale does not depend on the negative-stock setting.
  for (const [itCode, weight] of Object.entries(FIXTURE_MANIFEST.openingStock))
    await sql(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","IT_CODE","ITM_SIGN","ITM_GWT","ITM_NWT","TAG_NO")
       VALUES ($1,'01','01','2024-2025','OPN','00001','2024-04-01',$2,'+',$3,$3,'N')`,
      itCode,
      weight,
    );

  // Users: an admin and a restricted clerk without the delete right on Sales Invoice.
  const hash = await stack.hashPassword(password);
  for (const { user, category } of Object.values(USERS))
    await sql(
      `INSERT INTO "LOGIN_MAST"(tenant_id,"CO_CODE","LOGIN_NAME","LOGIN_PWD","LOGIN_CATG","USER_UPDATE","USER_DELETE","USER_PRINT","PASSWORD_RESET_REQUIRED")
       VALUES ($1,'01',$2,$3,$4,'Y','Y','Y','N')`,
      user,
      hash,
      category,
    );
  await sql(
    `INSERT INTO "USER_SET"(tenant_id,"CO_CODE","LC_CODE","USER_NAME","MAIN_MENU","SUB_MENU","FRM_VIEW","FRM_EDIT","FRM_DELETE","FRM_PRINT")
     VALUES ($1,'01','01',$2,'Sales','Sales Invoice','Y','Y','N','Y')`,
    USERS.clerk.user,
  );

  // F01: a sentinel tenant with the same company/book/voucher number. It must never change.
  await stack.seedCompany(stack.runtime, SECOND_TENANT, '01', {
    coName: 'Sentinel Jeweller',
    lcCode: '01',
  });
  await stack.owner.$executeRawUnsafe(
    `INSERT INTO "SL_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","VCH_DATE","AC_CODE","AC_NAME","NET_AMT","TOT_AMT")
     VALUES ($1,'01','01','2024-2025','SL','00001','2024-06-01','WALKIN','SENTINEL',111,111)`,
    SECOND_TENANT,
  );
}

/** The sentinel row; a case compares it before and after to prove no cross-tenant write. */
export async function sentinelSnapshot(owner) {
  return owner.$queryRawUnsafe(
    `SELECT "VCH_NO","AC_NAME","NET_AMT"::float AS net,"TOT_AMT"::float AS tot FROM "SL_DATA" WHERE tenant_id=$1`,
    SECOND_TENANT,
  );
}
