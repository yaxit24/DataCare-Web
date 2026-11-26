import { withTenant } from '@datacare/db';
import { seedCompany } from '../src/modules/ops/seedCompany.js';
import { saveParty } from '../src/modules/masters/partyMaster.js';
import { createStockIn, createStockOut } from '../src/modules/stock/stockInout.js';
import { createLabourInvoice } from '../src/modules/sales/labourInvoice.js';

/**
 * WP-24 shared seed: one tenant populated through the same writers the Lite screens call (company
 * provisioning, Party master save, Stock In/Out, Labour invoice). Not a test file.
 */
const now = new Date();
const startYear = now.getMonth() + 1 >= 4 ? now.getFullYear() : now.getFullYear() - 1;
export const WP24_YEAR = `${startYear}-${startYear + 1}`;
export const WP24_DAY = `${startYear}-06-10`;
export const WP24_CO = '01';
export const WP24_LC = '01';

export async function wipeTenants(owner: any, tenants: string[]): Promise<void> {
  const tables: Array<{ table_name: string }> = await owner.$queryRawUnsafe(
    `SELECT DISTINCT c.table_name FROM information_schema.columns c
       JOIN information_schema.tables t ON t.table_schema=c.table_schema AND t.table_name=c.table_name
      WHERE c.table_schema='public' AND c.column_name='tenant_id' AND t.table_type='BASE TABLE'`,
  );
  await owner.$executeRawUnsafe(`SET session_replication_role = replica`).catch(() => undefined);
  for (const { table_name } of tables)
    await owner.$executeRawUnsafe(
      `DELETE FROM "${table_name}" WHERE tenant_id = ANY($1::text[])`,
      tenants,
    );
}

export async function seedPopulatedTenant(runtime: any, tenantId: string): Promise<void> {
  await seedCompany(runtime, tenantId, WP24_CO);
  await withTenant(runtime, tenantId, async (tx: any) => {
    // seedCompany provides the desktop installer account groups: 20 SUNDRY DEBTORS (main 2), 05 VEPARI (main 1).
    await tx.$executeRawUnsafe(
      `INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","GR_CODE")
       VALUES ($1,'01','GOLD','Gold item','G','P1','G01')`,
      tenantId,
    );
    await tx.$executeRawUnsafe(
      `INSERT INTO "LOCT_MAST"(tenant_id,"CO_CODE","LC_CODE","LC_NAME","AC_CODE")
       VALUES ($1,'01','02','Ring Road','BRANCH') ON CONFLICT DO NOTHING`,
      tenantId,
    );
  });
  const scope = { tenantId, coCode: WP24_CO, lcCode: WP24_LC };
  for (const [code, name, group] of [
    ['010001', 'WP24 CUSTOMER', '20'],
    ['010002', 'WP24 SUPPLIER', '05'],
  ] as const)
    await saveParty(runtime, {
      scope,
      user: 'wp24',
      entryMode: 'A',
      code,
      values: { name, group, mobile: '9876543210' },
    } as any);
  const vs = { ...scope, coYear: WP24_YEAR };
  const line = {
    itCode: 'GOLD',
    tagNo: 'N',
    pcs: 1,
    grossWt: 12,
    netWt: 10,
    touch: 91,
    rate: 7000,
    prCode: 'P1',
  };
  await createStockOut(runtime, {
    scope: { ...vs, coBook: 'SOT' },
    vchDate: WP24_DAY,
    mainUser: 'wp24',
    toLcCode: '02',
    lines: [line],
  } as any);
  await createStockIn(runtime, {
    scope: { ...vs, coBook: 'SIN' },
    vchDate: WP24_DAY,
    mainUser: 'wp24',
    fromLcCode: '02',
    lines: [{ ...line, tagNo: 'WP24-TAG', vchSrno: 1, fineWt: 9.1, amount: 70000 }],
  } as any);
  await createLabourInvoice(runtime, {
    scope: { ...vs, coBook: 'LBR' },
    acCode: '010001',
    acName: 'WP24 CUSTOMER',
    vchDate: WP24_DAY,
    mainUser: 'wp24',
    lines: [{ itCode: 'GOLD', pcs: 1, netWt: 2, metalAmount: 200, labourAmount: 40 }],
  } as any);
}
