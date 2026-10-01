import assert from 'node:assert/strict';
import { expectRows } from './journeySql.mjs';

/**
 * X15 real-browser journey for the E INVOICE mode of TR_SL_EBILL: an operator creates an outward
 * e-invoice with TDS through the UI alone, generates an IRN (fake-development transport, the only
 * provider available to this harness), sees edit and delete locked, cancels the IRN and deletes it.
 * Stored rows are checked independently of the UI after each mutation.
 *
 * Expected values (CO_SET.TAX_ROF blank → whole-rupee GST): gross 10, less 0.5, rate 6000/g, gross
 * labour 500, other 250 → taxable 62,250; CGST = SGST = round(933.75) = 934; total 64,118;
 * TDS 25 at 1% = round(622.5) = 622 (half-to-even); Bill OS 63,496.
 */
export const eInvoiceEntryFixtureTables = [
  'DELETE_DATA',
  'TAX_DATA',
  'MAIN_STOCK',
  'BOOK_DETL',
  'GROUP_MAST',
  'TAX_MAST',
  'E_DATA',
  'REMARK_DATA',
];
const BOOK = 'EIV';

export async function seedEInvoiceEntry(sql) {
  await cleanupEInvoiceEntry(sql);
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","ITM_TYPE","DATA_TYPE","BOOK_SR_NAME")
    VALUES($1,'01','01','${BOOK}','Browser E Invoice','EINV','E INVOICE','O','Y','SL_DATA','SL_DETL','A','A','INV')`);
  for (const [srNo, account] of [
    [1, 'EICTRL'],
    [2, 'EICASH'],
    [3, 'EIKSR'],
    [4, 'EIROF4'],
    [5, 'EIROF5'],
  ])
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_SNAME","MAIN_BOOK","DATA_TYPE","BOOK_TYPE")
       VALUES($1,'01','01','${BOOK}',$2,$3,'EINV','E INVOICE','A','')`,
      srNo,
      account,
    );
  await sql(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE","AC_GSTNO","AC_STATE","AC_CITY","AC_PIN","AC_ADD1") VALUES
    ($1,'01','01','EICUST','Browser invoice customer','L','24AAAAA0000A1Z5','24','Surat','395007','Buyer Lane'),
    ($1,'01','01','EICTRL','Invoice control','L',NULL,NULL,NULL,NULL,NULL),
    ($1,'01','01','EICASH','Invoice cash','L',NULL,NULL,NULL,NULL,NULL),
    ($1,'01','01','EIKSR','Invoice kasar','L',NULL,NULL,NULL,NULL,NULL),
    ($1,'01','01','EIROF4','Invoice round off 4','L',NULL,NULL,NULL,NULL,NULL),
    ($1,'01','01','EIROF5','Invoice round off 5','L',NULL,NULL,NULL,NULL,NULL),
    ($1,'01','01','EISALE','Invoice gold sales','L',NULL,NULL,NULL,NULL,NULL),
    ($1,'01','01','EIGST','Invoice output GST','L',NULL,NULL,NULL,NULL,NULL),
    ($1,'01','01','EITDS','Invoice TDS receivable','L',NULL,NULL,NULL,NULL,NULL)`);
  await sql(`INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC") VALUES
    ($1,'01','10',0,'N','GST 3%',3,'EIGST'),($1,'01','10',1,'SGST','SGST',1.5,'EIGST'),
    ($1,'01','10',2,'CGST','CGST',1.5,'EIGST'),($1,'01','10',3,'IGST','IGST',3,'EIGST'),
    ($1,'01','25',0,'TDS','TDS 1%',1,'EITDS')`);
  await sql(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES($1,'01','EIG','Invoice gold','EISALE')`,
  );
  await sql(`INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","RATE_TYPE","HSN_CODE","UNIT_NAME")
    VALUES($1,'01','EIGLD','Invoice gold ring','G','EIG','G','711319','GMS')`);
  // IRN payload identities: the seller GSTIN lives on CO_MAST (restored in cleanup). Only the session company is
  // the seller; an unscoped update would also stamp every other company the harness has created.
  await expectRows(
    1,
    sql(
      `UPDATE "CO_MAST" SET "CO_GST_NO"='24ABCDE1234F1Z5',"CO_STATE_CODE"='24',"CO_ADD1"='Ring Road',"CO_CITY"='Surat',"CO_PIN"='395003' WHERE tenant_id=$1 AND "CO_CODE"='01'`,
    ),
    'company 01 CO_MAST row',
  );
}

export async function cleanupEInvoiceEntry(sql) {
  for (const table of [
    'SL_DATA',
    'SL_DETL',
    'SL_IDTL',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'MAIN_STOCK',
    'TAX_DATA',
    'DELETE_DATA',
    'REMARK_DATA',
    'DM_DATA',
    'E_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
  ])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`);
  await sql(`DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`);
  await sql(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" LIKE 'EI%'`);
  await sql(`DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE" IN ('10','25')`);
  await sql(`DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='EIG'`);
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='EIGLD'`);
  // Idempotent cleanup: restores the seeded seller columns; matches no row once the harness drops CO_MAST.
  await sql(
    `UPDATE "CO_MAST" SET "CO_GST_NO"=NULL,"CO_STATE_CODE"=NULL,"CO_ADD1"=NULL,"CO_CITY"=NULL,"CO_PIN"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`,
  );
}

async function pickLookup(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).waitFor();
  await input.press('Enter');
}

export async function exerciseEInvoiceEntry(page, { checkpoint, owner, tenantId }) {
  const stored = async () => {
    const [header] = await owner.$queryRawUnsafe(
      `SELECT "VCH_NO","TOT_AMT"::float AS "TOT","TDS_AMT"::float AS "TDS","BILL_OS"::float AS "OS" FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      tenantId,
    );
    const [ledger] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n, coalesce(sum("CR_AMT"),0)::float AS cr, coalesce(sum("DR_AMT"),0)::float AS dr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      tenantId,
    );
    const [stock] = await owner.$queryRawUnsafe(
      `SELECT string_agg("TR_TYPE"||"ITM_SIGN", ',') AS kind FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      tenantId,
    );
    const [irn] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n FROM "E_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      tenantId,
    );
    return { header, ledger, stock, irn };
  };

  await page.goto('/txn/e-invoice');
  await page.getByRole('heading', { name: 'E Invoice', exact: true }).waitFor();
  await page.getByRole('combobox', { name: 'Configured book', exact: true }).selectOption(BOOK);
  const entry = page.getByRole('region', { name: 'E-invoice entry' });
  await entry.getByRole('heading', { name: 'New e-invoice', exact: true }).waitFor();
  // The item GST help lists every code >= 10 (so 25 appears there too); wait on the TDS help list itself.
  await page
    .getByLabel('TDS', { exact: true })
    .locator('option[value="25"]')
    .waitFor({ state: 'attached' });

  await page.getByLabel('E-invoice date', { exact: true }).fill('2024-06-10');
  await pickLookup(page, 'Party account', 'EICUST');
  const partyName = page.getByLabel('Party name', { exact: true });
  for (let i = 0; i < 50 && (await partyName.inputValue()) === ''; i++)
    await page.waitForTimeout(100);
  assert.equal(await partyName.inputValue(), 'Browser invoice customer');
  await page.getByLabel('Ref No', { exact: true }).fill('BROWSER-INV');
  await pickLookup(page, 'Line 1 item', 'EIGLD');
  for (const [label, value] of [
    ['Line 1 Gross wt', '10'],
    ['Line 1 Less wt', '0.5'],
    ['Line 1 Rate', '6000'],
    ['Line 1 Labour rate', '500'],
    ['Line 1 Other amt', '250'],
  ])
    await page.getByLabel(label, { exact: true }).fill(value);
  await page.getByLabel('Line 1 labour type', { exact: true }).selectOption('G');
  await page.getByLabel('TDS', { exact: true }).selectOption('25');
  const totals = page.getByRole('table', { name: 'E-invoice totals' });
  await totals.getByRole('row', { name: /^Total\s+64,118\.00$/ }).waitFor();
  await totals.getByRole('row', { name: /^TDS\s+622\.00$/ }).waitFor();
  await totals.getByRole('row', { name: /^Outstanding \(Bill OS\)\s+63,496\.00$/ }).waitFor();
  await checkpoint('e-invoice-entry-new', page);

  await entry.getByRole('button', { name: 'Save e-invoice', exact: true }).click();
  await entry.getByRole('alert').filter({ hasText: 'Saved e-invoice 00001.' }).waitFor();
  let state = await stored();
  assert.deepEqual(state.header, { VCH_NO: '00001', TOT: 64118, TDS: 622, OS: 63496 });
  // 01 party DR, 02 sales CR, 03 GST CR, 05/06 TDS pair: DR 64,118 + 622 = CR 62,250 + 1,868 + 622.
  assert.deepEqual(state.ledger, { n: 5, cr: 64740, dr: 64740 });
  assert.deepEqual(state.stock, { kind: 'S-' });

  await entry.getByRole('button', { name: 'Generate IRN', exact: true }).click();
  await entry.getByRole('alert').filter({ hasText: 'IRN generated for e-invoice 00001' }).waitFor();
  assert.equal((await stored()).irn.n, 1);
  assert(await entry.getByRole('button', { name: 'Update e-invoice', exact: true }).isDisabled());
  assert(await entry.getByRole('button', { name: 'Delete e-invoice', exact: true }).isDisabled());
  await checkpoint('e-invoice-entry-irn-locked', page);

  page.once('dialog', (dialog) => dialog.accept());
  await entry.getByRole('button', { name: 'Cancel IRN', exact: true }).click();
  await entry.getByRole('alert').filter({ hasText: 'IRN cancelled' }).waitFor();
  assert.equal((await stored()).irn.n, 0);

  // Reopen from a fresh page load through Browse → Open.
  await page.reload();
  await page.getByRole('combobox', { name: 'Configured book', exact: true }).selectOption(BOOK);
  await page.getByRole('button', { name: 'Browse e-invoices', exact: true }).click();
  await page.getByRole('button', { name: 'Open 00001', exact: true }).click();
  await entry.getByRole('heading', { name: 'Edit e-invoice 00001', exact: true }).waitFor();
  const tds = page.getByLabel('TDS', { exact: true });
  for (let i = 0; i < 50 && (await tds.inputValue()) !== '25'; i++) await page.waitForTimeout(100);
  assert.equal(await tds.inputValue(), '25');
  await totals.getByRole('row', { name: /^Outstanding \(Bill OS\)\s+63,496\.00$/ }).waitFor();

  page.once('dialog', (dialog) => dialog.accept());
  await entry.getByRole('button', { name: 'Delete e-invoice', exact: true }).click();
  await entry.getByRole('alert').filter({ hasText: 'Delete Success.' }).waitFor();
  state = await stored();
  assert.equal(state.header, undefined);
  assert.deepEqual(state.ledger, { n: 0, cr: 0, dr: 0 });
  return {
    checks: [
      'create an outward e-invoice through the entry form',
      'live TDS and Bill OS match the posted voucher',
      'balanced AC_DATA with the TDS pair and stock-out MAIN_STOCK',
      'IRN generation locks edit and delete',
      'IRN cancel unlocks the voucher',
      'fresh-page browse reopen hydrates TDS',
      'delete removes the write set',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture with the fake-development IRN transport; not a live GSP, independent desktop or physical print acceptance',
  };
}
