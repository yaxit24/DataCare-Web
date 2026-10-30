import assert from 'node:assert/strict';

/**
 * N34 / G47 real-browser journey: Purchase Return create, refusal, print, reopen, unchanged save, edit, report and
 * delete, driven through the screen alone; stored rows are read back independently.
 *
 * Desktop authority: TR_KR_ISU in PURC RETURN mode (MDI_FORM.cs:7893-7917) saves a new and a reopened voucher
 * through one handler (BtnSave_Click :4928-5355), keeping the number, hidden number, creator and time of day;
 * the return tender is cheque, card, cash and kasar (:5066-5072). Expected values follow the desktop rules:
 * fine = net x touch / 100, metal = fine x rate, per-gram labour = net x rate, 3% GST split in halves.
 */
export const purchaseReturnFixtureTables = [
  'PR_DATA',
  'PR_DETL',
  'PR_IDTL',
  'MAIN_STOCK',
  'DM_DATA',
  'TAX_DATA',
  'GROUP_MAST',
  'TAX_MAST',
  'BOOK_DETL',
];
const BOOK = 'PRB';
const ACCOUNTS = ['PRSUPP', 'PRPURC', 'PRROF', 'PRGST'];
const TAX_CODE = 'P3';
const VOUCHER_TABLES = [
  'PR_DATA',
  'PR_DETL',
  'PR_IDTL',
  'AC_DATA',
  'TAX_DATA',
  'MAIN_STOCK',
  'DM_DATA',
  'ROJ_MEL_DATA',
  'TEMP_BOOK_DATA',
];

export async function seedPurchaseReturn(sql) {
  await cleanupPurchaseReturn(sql);
  // BOOK_NAME contains "Return": the purchase-return register lists PR_DATA books named so.
  await sql(
    `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
     VALUES($1,'01','01',$2,'Browser Purc Return','PRTB','PURC RETURN','O','Y','PR_DATA')`,
    BOOK,
  );
  for (const [srNo, account] of [
    [1, 'PRPURC'],
    [2, 'CASH'],
    [3, 'PRROF'],
  ])
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE","MAIN_BOOK","BOOK_INOUT")
       VALUES($1,'01','01',$2,$3,$4,'PURC RETURN','O')`,
      BOOK,
      srNo,
      account,
    );
  await sql(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES
    ($1,'01','01','PRSUPP','Browser return supplier','L'),
    ($1,'01','01','PRPURC','Browser purchase account','L'),
    ($1,'01','01','PRROF','Browser return round off','L'),
    ($1,'01','01','PRGST','Browser input GST','L')`);
  // A desktop-shaped GST code: the parent row SR_NO 0 and the SGST, CGST and IGST components (Ac_Tax.cs).
  await sql(
    `INSERT INTO "TAX_MAST"(tenant_id,"CO_CODE","TAX_CODE","SR_NO","TAX_NAME","TAX_PRC","TAX_GROUP","TAX_AC") VALUES
      ($1,'01',$2,0,'Browser GST 3%',3,'N','PRGST'),
      ($1,'01',$2,1,'Browser GST 3% SGST',1.5,'SGST',NULL),
      ($1,'01',$2,2,'Browser GST 3% CGST',1.5,'CGST',NULL),
      ($1,'01',$2,3,'Browser GST 3% IGST',3,'IGST',NULL)`,
    TAX_CODE,
  );
  // The seeded GOLD item belongs to group G01; its purchase account posts the returned metal.
  await sql(
    `INSERT INTO "GROUP_MAST"(tenant_id,"CO_CODE","GR_CODE","GR_NAME","PURC_AC") VALUES($1,'01','G01','Gold jewellery','PRPURC')`,
  );
}

export async function cleanupPurchaseReturn(sql) {
  for (const table of [...VOUCHER_TABLES, 'DELETE_DATA', 'BOOK_DETL', 'BOOK_DATA'])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"=$2`, BOOK);
  await sql(`DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`, ACCOUNTS);
  await sql(`DELETE FROM "GROUP_MAST" WHERE tenant_id=$1 AND "GR_CODE"='G01'`);
  await sql(`DELETE FROM "TAX_MAST" WHERE tenant_id=$1 AND "TAX_CODE"=$2`, TAX_CODE);
}

const itemGrid = (page) =>
  page
    .locator('.panel', { has: page.getByRole('heading', { name: 'Returned Items', exact: true }) })
    .locator('table.grid');
const gridCell = (page, row, column) =>
  itemGrid(page).locator('tbody tr').nth(row).locator('td').nth(column);
const gridInput = (page, row, column) => gridCell(page, row, column).locator('input').first();

async function waitForText(locator, expected) {
  for (let attempt = 0; attempt < 50; attempt++) {
    if ((await locator.textContent())?.trim() === expected) return;
    await new Promise((resolve) => setTimeout(resolve, 100));
  }
  assert.equal((await locator.textContent())?.trim(), expected);
}

async function pickAccount(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).waitFor();
  await input.press('Enter');
}

async function saveAndWait(page, buttonName, method) {
  const [response] = await Promise.all([
    page.waitForResponse(
      (response) =>
        new URL(response.url()).pathname.startsWith('/api/purchase-returns') &&
        response.request().method() === method,
    ),
    page.getByRole('button', { name: buttonName, exact: true }).click(),
  ]);
  return response;
}

export async function exercisePurchaseReturn(page, { checkpoint, owner, tenantId }) {
  const rows = (sql, ...params) => owner.$queryRawUnsafe(sql, tenantId, ...params);
  /** Every row this voucher owns, without the surrogate key a delete-and-reinsert renumbers. */
  const voucherRows = async () => {
    const all = [];
    for (const table of VOUCHER_TABLES) {
      const found = await rows(
        `SELECT (to_jsonb(t) - 'row_id')::text AS row FROM "${table}" t
          WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY 1`,
        BOOK,
      );
      all.push(...found.map(({ row }) => `${table} ${row}`));
    }
    return all;
  };
  const header = async () =>
    (
      await rows(
        `SELECT "VCH_NO","HD_VCH_NO","MAIN_USER",left("VCH_DATE"::text,10) AS "vchDate",
                "NET_AMT"::float AS net,"TAX_AMT"::float AS tax,"CGST_TAX"::float AS cgst,
                "SGST_TAX"::float AS sgst,"TOT_AMT"::float AS total
           FROM "PR_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
        BOOK,
      )
    )[0];
  const line = async () =>
    (
      await rows(
        `SELECT "ITM_NWT"::float AS net,"ITM_FINE"::float AS fine,"ITM_AMT"::float AS metal,
                "LBR_TYPE" AS "labourType","LBR_AMT"::float AS labour,"NET_AMT"::float AS amount
           FROM "PR_DETL" WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
        BOOK,
      )
    )[0];

  // The only PURC RETURN book is selected by itself, as CurBookHelp does with one book.
  await page.goto('/txn/purchase-return');
  await page.getByRole('heading', { name: 'Purchase Return', exact: true }).waitFor();
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true }).first();
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), BOOK);

  await page.getByLabel('Voucher date', { exact: true }).fill('2024-06-15');
  await pickAccount(page, 'Supplier account', 'PRSUPP');
  // Grid columns: 0 item, 2 pcs, 3 gross, 4 net, 5 touch, 6 rate, 7 making, 8 fine, 9 amount, 10 remove.
  // A new line starts with no item, as the desktop grid does (the old 'GOLD' demo default is gone).
  assert.equal(await gridInput(page, 0, 0).inputValue(), '', 'a new return line starts empty');
  await gridInput(page, 0, 0).fill('GOLD');
  await gridInput(page, 0, 3).fill('5');
  await gridInput(page, 0, 4).fill('5');
  await gridInput(page, 0, 5).fill('80');
  await gridInput(page, 0, 6).fill('1500');
  await gridInput(page, 0, 7).fill('40');
  // G96: Enter from the last editable cell skips the computed Fine and Amount cells and the remove button,
  // and adds a line with the cursor in its item cell. Ctrl+D removes it again.
  const returnedRows = () => {
    const panel = [...document.querySelectorAll('.panel')].find((p) =>
      [...p.querySelectorAll('h1,h2,h3')].some((h) => h.textContent?.trim() === 'Returned Items'),
    );
    return panel ? [...panel.querySelectorAll('table.grid tbody tr')] : [];
  };
  await gridInput(page, 0, 7).press('Enter');
  await page.waitForFunction(`(${returnedRows})().length === 2 &&
    (${returnedRows})()[1].querySelector('td').contains(document.activeElement)`);
  await page.keyboard.press('Control+d');
  await page.waitForFunction(`(${returnedRows})().length === 1`);
  // fine 5 x 80 / 100 = 4, metal 4 x 1500 = 6000, labour 5 x 40 = 200 -> 6200; 3% GST 186 -> 6386.
  await waitForText(gridCell(page, 0, 8), '4');
  await waitForText(gridCell(page, 0, 9), '6,200');
  await page.getByText('Total ₹6,386', { exact: true }).waitFor();

  // Refusal: the desktop return has no UPI tender and PR_DATA no UPI column.
  const upi = page.locator('.field', { hasText: 'UPI Amt' }).locator('input');
  await upi.fill('100');
  const refused = await saveAndWait(page, 'Save Return', 'POST');
  assert.equal(refused.status(), 400);
  await page.getByText('a purchase return has no UPI tender', { exact: false }).waitFor();
  assert.deepEqual(await voucherRows(), [], 'a refused return writes nothing');
  await upi.fill('');

  await checkpoint('purchase-return-before-save', page);
  const created = await saveAndWait(page, 'Save Return', 'POST');
  assert.equal(created.status(), 201, await created.text());
  await page.getByText('Return saved — Voucher #1', { exact: false }).waitFor();
  await page.getByTestId('purchase-return-loaded').getByText('Loaded #00001').waitFor();
  const saved = await header();
  assert.deepEqual(
    { ...saved, HD_VCH_NO: undefined },
    {
      VCH_NO: '00001',
      HD_VCH_NO: undefined,
      MAIN_USER: 'browser',
      vchDate: '2024-06-15',
      net: 6200,
      tax: 186,
      cgst: 93,
      sgst: 93,
      total: 6386,
    },
  );
  assert.match(String(saved.HD_VCH_NO), /^\d{5}$/);
  assert.deepEqual(await line(), {
    net: 5,
    fine: 4,
    metal: 6000,
    labourType: 'N',
    labour: 200,
    amount: 6200,
  });

  // Print from the recent list.
  await page.getByRole('button', { name: '▸ Recent vouchers', exact: true }).click();
  const recent = page.locator('table.grid tr', { hasText: '00001' }).last();
  const [printed] = await Promise.all([
    page.waitForEvent('popup'),
    recent.getByRole('link', { name: 'Print', exact: true }).click(),
  ]);
  // The window opens blank and loads the print once the session is fresh (openDocument, G180).
  await printed.waitForURL(new RegExp(`coBook=${BOOK}`));
  await printed.waitForLoadState();
  assert.match(printed.url(), new RegExp(`coBook=${BOOK}`));
  const printedHtml = await printed.content();
  assert.match(printedHtml, /Purchase Return/);
  assert.match(printedHtml, /6,386/);
  await printed.close();

  // Reopen through the recent list (still open after New) and save unchanged: no voucher row may change.
  await page.getByRole('button', { name: 'New', exact: true }).click();
  await page
    .locator('table.grid tr', { hasText: '00001' })
    .last()
    .getByRole('button', { name: 'Load', exact: true })
    .click();
  await page.getByTestId('purchase-return-loaded').getByText('Loaded #00001').waitFor();
  assert.equal(await page.getByLabel('Supplier account', { exact: true }).inputValue(), 'PRSUPP');
  assert.equal(await page.getByLabel('Voucher date', { exact: true }).inputValue(), '2024-06-15');
  assert.equal(await gridInput(page, 0, 4).inputValue(), '5');
  assert.equal(await gridInput(page, 0, 7).inputValue(), '40');
  const beforeUnchanged = await voucherRows();
  const unchanged = await saveAndWait(page, 'Save Return #00001', 'PUT');
  assert.equal(unchanged.status(), 200, await unchanged.text());
  await page.getByText('Return saved — Voucher #1', { exact: false }).waitFor();
  assert.deepEqual(
    await voucherRows(),
    beforeUnchanged,
    'an unchanged save changes no voucher row',
  );

  // Edit: a new weight re-derives fine, metal and labour; identity and creator stay.
  await gridInput(page, 0, 3).fill('10');
  await gridInput(page, 0, 4).fill('10');
  // fine 10 x 80 / 100 = 8, metal 8 x 1500 = 12000, labour 10 x 40 = 400 -> 12400; GST 372 -> 12772.
  await waitForText(gridCell(page, 0, 8), '8');
  await waitForText(gridCell(page, 0, 9), '12,400');
  await page.getByText('Total ₹12,772', { exact: true }).waitFor();
  await checkpoint('purchase-return-edited', page);
  const edited = await saveAndWait(page, 'Save Return #00001', 'PUT');
  assert.equal(edited.status(), 200, await edited.text());
  await page.getByText('Return saved — Voucher #1', { exact: false }).waitFor();
  assert.deepEqual(await header(), {
    ...saved,
    net: 12400,
    tax: 372,
    cgst: 186,
    sgst: 186,
    total: 12772,
  });
  assert.deepEqual(await line(), {
    net: 10,
    fine: 8,
    metal: 12000,
    labourType: 'N',
    labour: 400,
    amount: 12400,
  });
  const [ledger] = await rows(
    `SELECT sum("DR_AMT")::float AS dr,sum("CR_AMT")::float AS cr FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_BOOK"=$2`,
    BOOK,
  );
  assert.deepEqual(ledger, { dr: 12772, cr: 12772 });

  // The register shows the edited voucher.
  await page.goto('/reports/purchase-return-register');
  await page.getByRole('button', { name: 'Run', exact: true }).click();
  const registerRow = page.locator('table.grid tr', { hasText: `${BOOK}/00001` });
  await registerRow.waitFor();
  assert.match((await registerRow.textContent()) ?? '', /12,?772/);
  await checkpoint('purchase-return-register', page);

  // Delete through the screen: full reversal and one DELETE_DATA row.
  await page.goto('/txn/purchase-return');
  for (let i = 0; i < 50 && (await book.inputValue()) !== BOOK; i++) await page.waitForTimeout(100);
  await page.getByLabel('Voucher No', { exact: true }).fill('1');
  await page.getByRole('button', { name: 'Load', exact: true }).first().click();
  await page.getByTestId('purchase-return-loaded').getByText('Loaded #00001').waitFor();
  page.once('dialog', (dialog) => void dialog.accept());
  const [removed] = await Promise.all([
    page.waitForResponse(
      (response) =>
        new URL(response.url()).pathname === '/api/purchase-returns/00001' &&
        response.request().method() === 'DELETE',
    ),
    // The header's Delete acts on the loaded voucher; the recent list has its own per-row Delete.
    page
      .locator('.panel', { has: page.getByLabel('Voucher No', { exact: true }) })
      .getByRole('button', { name: 'Delete', exact: true })
      .click(),
  ]);
  assert.equal(removed.status(), 200, await removed.text());
  assert.deepEqual(await voucherRows(), [], 'delete reverses every voucher row');
  const [audit] = await rows(
    `SELECT count(*)::int AS n FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 AND "VCH_NO"='00001'`,
    BOOK,
  );
  assert.equal(audit.n, 1);

  return {
    checks: [
      'the only PURC RETURN book is selected by itself',
      'a UPI refund is refused with its reason and writes nothing',
      'a new return stores fine, metal, per-gram labour (LBR_TYPE N) and 3% GST, read back from PR_DATA and PR_DETL',
      'the saved return prints from the recent list',
      'reopening from the recent list hydrates the voucher, and an unchanged save changes no voucher row',
      'a new net weight re-derives fine, metal and labour and keeps the number, hidden number and creator',
      'the purchase return register shows the edited total',
      'delete through the screen reverses every voucher row and writes one DELETE_DATA row',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture; not an independent desktop comparison or business acceptance',
  };
}
