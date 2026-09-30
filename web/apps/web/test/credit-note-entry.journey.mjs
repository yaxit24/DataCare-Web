import assert from 'node:assert/strict';

/**
 * X15 real-browser journey: an operator creates, prints, edits, reopens and deletes an E CRNT credit
 * note through the web UI alone (no SL_DATA fixture insert), and the stored rows are checked
 * independently of the UI after every mutation.
 *
 * Expected values follow TR_SL_EBILL with CO_SET.TAX_ROF blank (whole-rupee GST): gross 10, less 0.5,
 * rate 6000/g, gross labour 500, other 250 → taxable 62250, CGST = SGST = round(933.75) = 934,
 * total 64118, round-off 0. After the edit (rate 6100): taxable 63200, GST 948 + 948, total 65096.
 */
export const creditNoteEntryFixtureTables = [
  'DELETE_DATA',
  'TAX_DATA',
  'MAIN_STOCK',
  'BOOK_DETL',
  'GROUP_MAST',
  'TAX_MAST',
];
const BOOK = '148';

export async function seedCreditNoteEntry(sql) {
  await cleanupCreditNoteEntry(sql);
  await sql(`INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME","BOOK_TBL_DETL","ITM_TYPE","DATA_TYPE")
    VALUES($1,'01','01','${BOOK}','Entry Credit Note','ECRNT','E CRNT','I','Y','SL_DATA','SL_DETL','A','A')`);
  for (const [srNo, account] of [
    [1, 'CRCTRL'],
    [2, 'CRCASH'],
    [3, 'CRKSR'],
    [4, 'CRROF'],
  ])
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","BOOK_SNAME","MAIN_BOOK","DATA_TYPE","BOOK_TYPE")
       VALUES($1,'01','01','${BOOK}',$2,$3,'ECRNT','E CRNT','A','')`,
      srNo,
      account,
    );
  await sql(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES
    ($1,'01','01','CRCUST','Browser credit customer','L'),
    ($1,'01','01','CRCTRL','Credit note control','L'),
    ($1,'01','01','CRCASH','Credit cash','L'),
    ($1,'01','01','CRKSR','Credit kasar','L'),
    ($1,'01','01','CRROF','Credit round off','L'),
    ($1,'01','01','CRSALE','Credit gold sales','L'),
    ($1,'01','01','CRGST','Credit output GST','L')`);
  await sql(`INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_GROUP","TAX_NAME","TAX_PRC","TAX_AC") VALUES
    ($1,'01','10',0,'N','GST 3%',3,'CRGST'),($1,'01','10',1,'SGST','SGST',1.5,'CRGST'),
    ($1,'01','10',2,'CGST','CGST',1.5,'CRGST'),($1,'01','10',3,'IGST','IGST',3,'CRGST')`);
  await sql(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","SALE_AC") VALUES($1,'01','CRG','Credit gold','CRSALE')`,
  );
  await sql(`INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","GR_CODE","RATE_TYPE")
    VALUES($1,'01','CRGLD','Credit gold ring','G','CRG','G')`);
}

export async function cleanupCreditNoteEntry(sql) {
  for (const table of [
    'SL_DATA',
    'SL_DETL',
    'SL_IDTL',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'MAIN_STOCK',
    'TAX_DATA',
    'DELETE_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
  ])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`);
  await sql(`DELETE FROM "TEMP_BOOK_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`);
  await sql(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" LIKE 'CR%'`);
  await sql(`DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"='10'`);
  await sql(`DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='CRG'`);
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE"='CRGLD'`);
}

async function pickLookup(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  const option = input.locator('xpath=..').getByText(code, { exact: true });
  await option.waitFor();
  await input.press('Enter');
}

export async function exerciseCreditNoteEntry(page, { checkpoint, owner, tenantId }) {
  const stored = async () => {
    const [header] = await owner.$queryRawUnsafe(
      `SELECT "VCH_NO","TOT_AMT"::float AS "TOT","TAX_AMT"::float AS "TAX","MAIN_USER" FROM "SL_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      tenantId,
    );
    const [ledger] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n, coalesce(sum("CR_AMT"),0)::float AS cr, coalesce(sum("DR_AMT"),0)::float AS dr
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      tenantId,
    );
    const [stock] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n, string_agg("TR_TYPE"||"ITM_SIGN", ',') AS kind FROM "MAIN_STOCK"
        WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
      tenantId,
    );
    const [tax] = await owner.$queryRawUnsafe(
      `SELECT count(*)::int AS n, coalesce(sum("TAX_AMT"),0)::float AS amount FROM "TAX_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}' AND "TAX_SIGN"='-'`,
      tenantId,
    );
    return { header, ledger, stock, tax };
  };

  await page.goto('/txn/e-crnt-note');
  await page.getByRole('heading', { name: 'E CrntNote', exact: true }).waitFor();
  await page.getByRole('combobox', { name: 'Configured book', exact: true }).selectOption(BOOK);
  const entry = page.getByRole('region', { name: 'Credit note entry' });
  await entry.getByRole('heading', { name: 'New credit note', exact: true }).waitFor();
  await entry
    .getByRole('option', { name: /^10 · GST 3%$/ })
    .first()
    .waitFor({ state: 'attached' });

  // The desktop defaults the date to today; the fixture year is 2024-2025, so enter an in-year date.
  await page.getByLabel('Credit note date', { exact: true }).fill('2024-06-10');
  await pickLookup(page, 'Party account', 'CRCUST');
  const partyName = page.getByLabel('Party name', { exact: true });
  for (let i = 0; i < 50 && (await partyName.inputValue()) === ''; i++)
    await page.waitForTimeout(100);
  assert.equal(await partyName.inputValue(), 'Browser credit customer');
  await page.getByLabel('Ref No', { exact: true }).fill('BROWSER-1');
  await pickLookup(page, 'Line 1 item', 'CRGLD');
  for (const [label, value] of [
    ['Line 1 Gross wt', '10'],
    ['Line 1 Less wt', '0.5'],
    ['Line 1 Rate', '6000'],
    ['Line 1 Labour rate', '500'],
    ['Line 1 Other amt', '250'],
  ])
    await page.getByLabel(label, { exact: true }).fill(value);
  await page.getByLabel('Line 1 labour type', { exact: true }).selectOption('G');
  const totals = page.getByRole('table', { name: 'Credit note totals' });
  await totals.getByRole('row', { name: /^Total\s+64,118\.00$/ }).waitFor();
  await checkpoint('credit-note-entry-new', page);

  await entry.getByRole('button', { name: 'Save credit note', exact: true }).click();
  await entry.getByRole('alert').filter({ hasText: 'Saved credit note 00001.' }).waitFor();
  await entry.getByRole('heading', { name: 'Edit credit note 00001', exact: true }).waitFor();
  await page.getByRole('heading', { name: 'Credit note 00001', exact: true }).waitFor();
  let state = await stored();
  assert.deepEqual(state.header, { VCH_NO: '00001', TOT: 64118, TAX: 1868, MAIN_USER: 'browser' });
  assert.deepEqual(state.ledger, { n: 3, cr: 64118, dr: 64118 });
  assert.deepEqual(state.stock, { n: 1, kind: 'I+' });
  assert.deepEqual(state.tax, { n: 2, amount: 1868 });

  const [popup] = await Promise.all([
    page.context().waitForEvent('page'),
    entry.getByRole('button', { name: 'Print original', exact: true }).click(),
  ]);
  await popup.waitForLoadState();
  assert.match(await popup.content(), /ORIGINAL FOR RECIPIENT/);
  assert.match(await popup.content(), /Browser credit customer/);
  await checkpoint('credit-note-entry-print', popup);
  await popup.close();

  await page.getByLabel('Line 1 Rate', { exact: true }).fill('6100');
  await totals.getByRole('row', { name: /^Total\s+65,096\.00$/ }).waitFor();
  await entry.getByRole('button', { name: 'Update credit note', exact: true }).click();
  await entry.getByRole('alert').filter({ hasText: 'Updated credit note 00001.' }).waitFor();
  state = await stored();
  assert.deepEqual(state.header, { VCH_NO: '00001', TOT: 65096, TAX: 1896, MAIN_USER: 'browser' });
  assert.deepEqual(state.ledger, { n: 3, cr: 65096, dr: 65096 });

  // Reopen from a fresh page load through Browse → Edit.
  await page.reload();
  await page.getByRole('combobox', { name: 'Configured book', exact: true }).selectOption(BOOK);
  await page.getByRole('button', { name: 'Browse credit notes', exact: true }).click();
  await page.getByRole('button', { name: 'Open 00001', exact: true }).click();
  await page.getByRole('button', { name: 'Edit in entry form', exact: true }).click();
  await entry.getByRole('heading', { name: 'Edit credit note 00001', exact: true }).waitFor();
  for (
    let i = 0;
    i < 50 && (await page.getByLabel('Line 1 Rate', { exact: true }).inputValue()) !== '6100';
    i++
  )
    await page.waitForTimeout(100);
  assert.equal(await page.getByLabel('Line 1 Rate', { exact: true }).inputValue(), '6100');
  assert.equal(await page.getByLabel('Ref No', { exact: true }).inputValue(), 'BROWSER-1');
  await totals.getByRole('row', { name: /^Total\s+65,096\.00$/ }).waitFor();
  await checkpoint('credit-note-entry-reopened', page);

  page.once('dialog', (dialog) => dialog.accept());
  await entry.getByRole('button', { name: 'Delete credit note', exact: true }).click();
  await entry.getByRole('alert').filter({ hasText: 'Delete Success.' }).waitFor();
  state = await stored();
  assert.equal(state.header, undefined);
  assert.deepEqual(state.ledger, { n: 0, cr: 0, dr: 0 });
  assert.deepEqual(state.stock, { n: 0, kind: null });
  const audit = await owner.$queryRawUnsafe(
    `SELECT "VCH_NO","DELETE_USER" FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='${BOOK}'`,
    tenantId,
  );
  assert.deepEqual(audit, [{ VCH_NO: '00001', DELETE_USER: 'browser' }]);
  return {
    checks: [
      'create through the entry form without fixture SL_DATA',
      'live totals match the posted voucher',
      'balanced AC_DATA, stock-in MAIN_STOCK and negative TAX_DATA',
      'print original copy caption',
      'edit recalculates and reposts',
      'fresh-page browse reopen hydrates the entry form',
      'delete removes the write set and writes DELETE_DATA',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture; not an independent desktop comparison, live GSP or physical print acceptance',
  };
}
