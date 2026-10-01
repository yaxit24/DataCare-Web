import assert from 'node:assert/strict';
import { expectRows } from './journeySql.mjs';

/**
 * D6 real-browser journey (PARITY-EVALUATION-2026-09-28). A company with a blank CO_SET.SL_AMT_TYPE,
 * which is how web provisioning used to leave every company, sells:
 * - line 1: 10 g at touch 91.6 for 6,000/g;
 * - line 2: the same weight with the line's own RtWith set to F.
 *
 * Desktop (TR_SALE.cs CommPassTotal 10716-10936; blank is N per MS_OPNCOMP.cs:881-884):
 * - line 1 = (net 10 + ghat 0) x 6000 = 60,000, stored RtWith N;
 * - line 2 = fine 9.160 x 6000 = 54,960, stored RtWith F.
 *
 * Before the fix the preview showed 60,000 while the server saved 54,960 for line 1, and line 2's RtWith
 * was stored but ignored. Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects.
 */
export const saleAmountBasisFixtureTables = ['GROUP_MAST', 'TAX_MAST', 'MAIN_STOCK', 'TAX_DATA'];
const BOOK = 'SLB';

export async function seedSaleAmountBasis(sql) {
  await cleanupSaleAmountBasis(sql);
  // The harness CO_SET row has no SL_AMT_TYPE: the D6 condition.
  await expectRows(
    1,
    sql(`UPDATE "CO_SET" SET "SL_AMT_TYPE"=NULL WHERE tenant_id=$1 AND "CO_CODE"='01'`),
    'company 01 CO_SET row',
  );
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL")
    VALUES($1,'01','01','${BOOK}','Browser Sales','SLB','SALES','O','Y','SL_DATA','SL_DETL')`);
  for (const [srNo, account] of [
    [1, 'SLSALES'],
    [2, 'CASH'],
    [3, 'SLROF'],
  ])
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES($1,'01','01','${BOOK}',$2,$3,'SALES','O')`,
      srNo,
      account,
    );
  await sql(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES
    ($1,'01','01','SLCUST','Browser sale customer','L'),
    ($1,'01','01','SLSALES','Browser gold sales','L'),
    ($1,'01','01','SLGST','Browser output GST','L'),
    ($1,'01','01','SLROF','Browser round off','L')`);
  await sql(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC","PURC_AC") VALUES($1,'01','G01','Gold jewellery','SLSALES','SLSALES')`,
  );
  await sql(
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP","TAX_AC") VALUES($1,'01','S3',1,'GST 3%',3,'N','SLGST')`,
  );
}

export async function cleanupSaleAmountBasis(sql) {
  for (const table of [
    'SL_DATA',
    'SL_DETL',
    'SL_IDTL',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'MAIN_STOCK',
    'TAX_DATA',
    'BILL_OS_DATA',
    'TEMP_BOOK_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
  ])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`);
  await sql(
    `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" IN ('SLCUST','SLSALES','SLGST','SLROF')`,
  );
  await sql(`DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='G01'`);
  await sql(`DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='S3'`);
}

const cell = (page, row, column) =>
  page.locator(`[data-grid-row="${row}"][data-grid-column="${column}"] input`).first();

async function fillLine(page, row, values) {
  // Grid columns (sales/page.tsx gridCell): 0 item, 2 pcs, 3 gross, 4 net, 5 touch, 6 rate.
  await cell(page, row, 0).fill('GOLD');
  await cell(page, row, 0).press('Escape');
  for (const [column, value] of Object.entries(values))
    await cell(page, row, Number(column)).fill(value);
}

export async function exerciseSaleAmountBasis(page, { checkpoint, owner, tenantId }) {
  await page.goto('/txn/sales');
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  // The only SALES book is selected by itself; non-sales books are no longer offered.
  assert.equal(await book.inputValue(), BOOK);
  assert.deepEqual(
    (await book.locator('option').allTextContents()).filter((text) => text.includes('—')),
    ['SLB — Browser Sales'],
  );
  await page.locator('.voucher-chrome input[type="date"]').fill('2024-06-15');
  const party = page.getByPlaceholder('search accounts… (F1)').first();
  await party.fill('SLCUST');
  await party.locator('xpath=..').getByText('SLCUST', { exact: true }).waitFor();
  await party.press('Enter');

  const weights = { 2: '1', 3: '10', 4: '10', 5: '91.6', 6: '6000' };
  await fillLine(page, 0, weights);
  await page.getByRole('button', { name: '+ Add line', exact: true }).click();
  await fillLine(page, 1, weights);
  // Line 2's own RtWith (grid column 21 on the desktop), in its desktop-fields panel.
  const line2Fields = page.locator('details', { hasText: 'Item row 2 desktop fields' });
  await line2Fields.locator('summary').click();
  await line2Fields
    .locator('xpath=.//label[normalize-space()="Rate With"]/following-sibling::input[1]')
    .fill('F');

  // The preview now prices each line the way the server will save it. The line-net cell carries no grid
  // attribute, so the row is found through its input cells.
  const row = (index) =>
    page.locator('tr').filter({ has: page.locator(`[data-grid-row="${index}"]`) });
  await row(0).filter({ hasText: '60,000' }).waitFor();
  await row(1).filter({ hasText: '54,960' }).waitFor();
  await checkpoint('sale-amount-basis-before-save', page);

  await page.getByRole('button', { name: 'Save Invoice', exact: true }).click();
  await page.getByText('Saved — Voucher #1', { exact: false }).waitFor();
  const lines = await owner.$queryRawUnsafe(
    `SELECT "SR_NO"::int AS sr,"ITM_AMT"::float AS amt,"ITM_FINE"::float AS fine,"RATE_WITH" AS rw
       FROM "SL_DETL" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' ORDER BY "SR_NO"`,
    tenantId,
  );
  assert.deepEqual(lines, [
    { sr: 1, amt: 60000, fine: 9.16, rw: 'N' },
    { sr: 2, amt: 54960, fine: 9.16, rw: 'F' },
  ]);
  const [ledger] = await owner.$queryRawUnsafe(
    `SELECT coalesce(sum("DR_AMT"),0)::float AS dr, coalesce(sum("CR_AMT"),0)::float AS cr
       FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
    tenantId,
  );
  assert(ledger.dr > 0, 'the sale must post its ledger');
  assert.equal(ledger.dr, ledger.cr, 'and it must balance');
  const [income] = await owner.$queryRawUnsafe(
    `SELECT coalesce(sum("CR_AMT"),0)::float AS cr FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "AC_CODE"='SLSALES'`,
    tenantId,
  );
  // 60,000 + 54,960 of income, whatever the tax legs.
  assert.equal(income.cr, 114960);
  await checkpoint('sale-amount-basis-saved', page);
  return {
    checks: [
      'blank SL_AMT_TYPE prices a line on net + ghat (60,000) in the preview and the saved SL_DETL',
      'a line RtWith of F prices fine (54,960) in the preview and the saved SL_DETL',
      'SL_DETL.RATE_WITH stores the effective N / F',
      'only SALES books are offered, and the only one is selected',
      'balanced AC_DATA with 114,960 of sales income',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture; not an independent desktop comparison or business acceptance',
  };
}
