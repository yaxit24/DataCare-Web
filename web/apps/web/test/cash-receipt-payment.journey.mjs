import assert from 'node:assert/strict';

/**
 * D1 real-browser journey (PARITY-EVALUATION-2026-09-28): Cash Received, Cash Payment, a bank-mode
 * book list and Contra, saved through the forms alone. Stored rows are read back independently.
 *
 * The desktop fixes each book by MAIN_BOOK before the form opens (MDI_FORM.cs:8052-8111). Kasar posts
 * against BOOK_DETL slot 2 (Ac_Ledr.cs:571-581). Contract:
 * parity-plan-2026-09-10/evidence/implementation-2026-09-29-eval-defects/contract.md.
 */
export const cashReceiptPaymentFixtureTables = ['CASH_DATA', 'PAY_DATA', 'BOOK_DETL'];
const BOOKS = ['CRB', 'CPB', 'BRB', 'CNB'];

export async function seedCashReceiptPayment(sql) {
  await cleanupCashReceiptPayment(sql);
  for (const [book, name, shortName, mainBook, inout, table] of [
    // Desktop-width names: CASH_DATA / PAY_DATA / ROJ_MEL_DATA.BOOK_NAME are varchar(20).
    ['CRB', 'Browser Cash Rec', 'CREC', 'CASH REC', 'I', 'CASH_DATA'],
    ['CPB', 'Browser Cash Pay', 'CPAY', 'CASH PAY', 'O', 'PAY_DATA'],
    ['BRB', 'Browser Bank Rec', 'BREC', 'BANK REC', 'I', 'CASH_DATA'],
    ['CNB', 'Browser Contra', 'CONT', 'CONTRA', 'I', 'CONTRA_DATA'],
  ])
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES($1,'01','01',$2,$3,$4,$5,$6,'Y',$7)`,
      book,
      name,
      shortName,
      mainBook,
      inout,
      table,
    );
  for (const [book, srNo, account] of [
    ['CRB', 1, 'CASH'],
    ['CRB', 2, 'KSRJ'],
    ['CPB', 1, 'CASH'],
    ['CPB', 2, 'KSRA'],
    ['BRB', 1, 'BANKB'],
  ])
    await sql(
      `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE") VALUES($1,'01','01',$2,$3,$4)`,
      book,
      srNo,
      account,
    );
  await sql(`INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_GST_TYPE") VALUES
    ($1,'01','01','RCPCUST','Browser receipt customer','L'),
    ($1,'01','01','KSRJ','Kasar javak','L'),
    ($1,'01','01','KSRA','Kasar avak','L'),
    ($1,'01','01','BANKB','Browser bank','L')`);
}

export async function cleanupCashReceiptPayment(sql) {
  for (const table of [
    'CASH_DATA',
    'PAY_DATA',
    'CONTRA_DATA',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'TEMP_BOOK_DATA',
    'BOOK_DETL',
    'BOOK_DATA',
  ])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK" = ANY($2::text[])`, BOOKS);
  await sql(
    `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" IN ('RCPCUST','KSRJ','KSRA','BANKB')`,
  );
}

async function pickAccount(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).waitFor();
  await input.press('Enter');
}

async function bookValue(page, expected) {
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== expected; i++)
    await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), expected);
  return book;
}

export async function exerciseCashReceiptPayment(page, { checkpoint, owner, tenantId }) {
  const rows = (sql, ...params) => owner.$queryRawUnsafe(sql, tenantId, ...params);
  const legs = async (book) =>
    rows(
      `SELECT "AC_CODE" AS ac,"DR_AMT"::float AS dr,"CR_AMT"::float AS cr FROM "AC_DATA"
        WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "LEDR_KEY"`,
      book,
    );

  // Cash Received: the only CASH REC book is selected by itself, as CurBookHelp does with one book.
  await page.goto('/txn/receipt');
  await page.getByRole('heading', { name: /^Receipt/ }).waitFor();
  const receiptBook = await bookValue(page, 'CRB');
  const offered = await receiptBook.locator('option').allTextContents();
  assert.deepEqual(
    offered.filter((text) => text.includes('—')),
    ['CRB — Browser Cash Rec'],
    'cash mode offers only CASH REC / RECEIPT books',
  );
  await page.getByLabel('Voucher date', { exact: true }).fill('2024-06-15');
  await pickAccount(page, 'Party account', 'RCPCUST');
  await page.getByLabel('Amount', { exact: true }).fill('1000');
  await page.getByLabel('Kasar ₹ (write-off)', { exact: true }).fill('15');
  await checkpoint('cash-receipt-before-save', page);
  await page.getByRole('button', { name: 'Save Receipt', exact: true }).click();
  await page.getByText('Saved — Voucher #1', { exact: false }).waitFor();
  const [cash] = await rows(
    `SELECT "VCH_NO",left("VCH_DATE"::text,10) AS "vchDate","REC_AMT"::float AS rec,"KASAR_AMT"::float AS kasar,"REC_AC_CODE" AS "recAc" FROM "CASH_DATA"
      WHERE tenant_id=$1 AND "CO_BOOK"='CRB'`,
  );
  assert.deepEqual(cash, {
    VCH_NO: '00001',
    vchDate: '2024-06-15',
    rec: 1000,
    kasar: 15,
    recAc: 'CASH',
  });
  assert.deepEqual(await legs('CRB'), [
    { ac: 'RCPCUST', dr: 0, cr: 1000 },
    { ac: 'CASH', dr: 1000, cr: 0 },
    { ac: 'RCPCUST', dr: 0, cr: 15 },
    { ac: 'KSRJ', dr: 15, cr: 0 },
  ]);
  const [voucherPage] = await Promise.all([
    page.waitForEvent('popup'),
    page.getByRole('button', { name: 'View Receipt Voucher', exact: true }).click(),
  ]);
  await voucherPage.waitForLoadState();
  assert.match(voucherPage.url(), /coBook=CRB/);
  assert.match(await voucherPage.content(), /1,000/);
  await voucherPage.close();

  // Bank mode re-filters the books: only the BANK REC book remains.
  await page.getByLabel('Mode', { exact: true }).selectOption('bank');
  await bookValue(page, 'BRB');

  // Ctrl+F8's ?mode=BANK opens straight into bank mode.
  await page.goto('/txn/receipt?mode=BANK');
  await bookValue(page, 'BRB');
  assert.equal(await page.getByLabel('Mode', { exact: true }).inputValue(), 'bank');

  // Cash Payment.
  await page.goto('/txn/payment');
  await page.getByRole('heading', { name: /^Payment/ }).waitFor();
  await bookValue(page, 'CPB');
  await page.getByLabel('Voucher date', { exact: true }).fill('2024-06-16');
  await pickAccount(page, 'Party account', 'RCPCUST');
  await page.getByLabel('Amount', { exact: true }).fill('750');
  await page.getByRole('button', { name: 'Save Payment', exact: true }).click();
  await page.getByText('Saved — Voucher #1', { exact: false }).waitFor();
  const [pay] = await rows(
    `SELECT "VCH_NO",left("VCH_DATE"::text,10) AS "vchDate","NET_AMT"::float AS net,"CASH_AMT"::float AS cash FROM "PAY_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='CPB'`,
  );
  assert.deepEqual(pay, { VCH_NO: '00001', vchDate: '2024-06-16', net: 750, cash: 750 });
  assert.deepEqual(await legs('CPB'), [
    { ac: 'RCPCUST', dr: 750, cr: 0 },
    { ac: 'CASH', dr: 0, cr: 750 },
  ]);

  // Contra: cash deposited to the bank.
  await page.goto('/txn/contra');
  await page.getByRole('heading', { name: /^Contra/ }).waitFor();
  await bookValue(page, 'CNB');
  await page.locator('input[type="date"]').first().fill('2024-06-17');
  await pickAccount(page, 'Dr account', 'BANKB');
  await pickAccount(page, 'Cr account', 'CASH');
  await page.getByLabel('Dr amount', { exact: true }).fill('500');
  await page.getByLabel('Cr amount', { exact: true }).fill('500');
  await page.getByRole('button', { name: 'Save Contra', exact: true }).click();
  await page.getByText('Contra posted — Voucher #1', { exact: false }).waitFor();
  const contra = await rows(
    `SELECT "AC_CODE" AS ac,"DR_AMT"::float AS dr,"CR_AMT"::float AS cr FROM "AC_DATA"
      WHERE tenant_id=$1 AND "CO_BOOK"='CNB' ORDER BY "DR_AMT" DESC`,
  );
  assert.deepEqual(contra, [
    { ac: 'BANKB', dr: 500, cr: 0 },
    { ac: 'CASH', dr: 0, cr: 500 },
  ]);
  await checkpoint('contra-saved', page);
  return {
    checks: [
      'cash receipt saved in the only CASH REC book, on the operator date, with a slot-2 kasar write-off',
      'four balanced receipt legs 01-04 read back from AC_DATA',
      'receipt voucher print opens for the saved book',
      'bank mode and ?mode=BANK offer only the BANK REC book',
      'cash payment saved in the CASH PAY book',
      'contra saved in the CONTRA book',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture; not an independent desktop comparison or business acceptance',
  };
}
