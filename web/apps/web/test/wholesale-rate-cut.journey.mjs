import assert from 'node:assert/strict';

/**
 * X16 real-browser journey: the shared TR_WH_SALE form on its two pages, driven through the screen alone, with
 * every stored row read back independently of the web code.
 *
 * Wholesale Sale (WH SALES book): two tags picked from the availability-filtered picker (one typed and resolved),
 * a received line, 4.540 fine cut at 6500 with Ac Amt Dr derived by BILL_TOTAL, cash and kasar in the band's
 * "Received" column; then an edit that drops a tag (it returns to stock), a reopen by number, and a delete that
 * audits and releases every tag. Rate Cut (RATE CUT book): a header-only purchase-side cut settled in the
 * "Payment" column, the shape of all 25 real rate cuts on Live24 book 064.
 *
 * Expected figures are the desktop's, evaluated by hand (TR_WH_SALE.cs grid and band, `Wh_Sales_Ledr` legs,
 * Ac_Ledr.cs:613-778). Contract: parity-plan-2026-09-10/evidence/implementation-2026-09-29-x16/contract.md.
 */
export const wholesaleRateCutFixtureTables = [
  'RATE_CUT_REC',
  'RATE_CUT_ISU',
  'RATE_CUT_DATA',
  'MAIN_STOCK',
  'BAR_DETL',
  'BOOK_DETL',
];
const BOOKS = ['WSB', 'RCB'];
const ACCOUNTS = [
  ['WHPARTY', 'Wholesale browser party', '9856525'],
  ['WSGOLD', 'Sales gold', ''],
  ['WPGOLD', 'Purchase gold', ''],
  ['WKASAR', 'Kasar', ''],
  ['WLBRIN', 'Labour income', ''],
  ['WLBREX', 'Labour expense', ''],
  ['WSSILV', 'Sales silver', ''],
  ['WPSILV', 'Purchase silver', ''],
  ['WINTIN', 'Interest income', ''],
  ['WOTHCH', 'Other charges', ''],
  ['WFNKSR', 'Fine kasar', ''],
];
// The twelve BOOK_DETL slots of a wholesale / rate-cut book (the real 034/064 layout; CASH is the fixture's).
const SLOTS = [
  [1, 'WSGOLD'],
  [2, 'WPGOLD'],
  [3, 'CASH'],
  [4, 'WKASAR'],
  [5, 'WKASAR'],
  [6, 'WLBRIN'],
  [7, 'WLBREX'],
  [8, 'WSSILV'],
  [9, 'WPSILV'],
  [10, 'WINTIN'],
  [11, 'WOTHCH'],
  [12, 'WFNKSR'],
];
const TAGS = [
  // 12.300 × (92 + 5) / 100 = 11.931; net-wise labour 150 / g.
  { tag: 'WTAG001', id: 900000001, gwt: 12.3, fine: 11.931, lbrType: 'N', lbrRate: 150, kr: 'KJ' },
  // 13.000 × 97 / 100 = 12.610; blank labour basis, as Next23 034/4's tags carry.
  { tag: 'WTAG002', id: 900000002, gwt: 13, fine: 12.61, lbrType: '', lbrRate: 0, kr: 'AB' },
];

export async function seedWholesaleRateCut(sql) {
  await cleanupWholesaleRateCut(sql);
  for (const [book, name, shortName, mainBook] of [
    ['WSB', 'Browser Wh Sales', 'WSALE', 'WH SALES'],
    ['RCB', 'Browser Rate Cut', 'RCUT', 'RATE CUT'],
  ])
    await sql(
      `INSERT INTO "BOOK_DATA"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","BOOK_NAME","BOOK_SNAME","MAIN_BOOK","BOOK_INOUT","CUR_USE","BOOK_TBL_NAME")
       VALUES($1,'01','01',$2,$3,$4,$5,'O','Y','RATE_CUT_DATA')`,
      book,
      name,
      shortName,
      mainBook,
    );
  for (const book of BOOKS)
    for (const [srNo, account] of SLOTS)
      await sql(
        `INSERT INTO "BOOK_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_BOOK","SR_NO","AC_CODE") VALUES($1,'01','01',$2,$3,$4)`,
        book,
        srNo,
        account,
      );
  for (const [code, name, mobile] of ACCOUNTS)
    await sql(
      `INSERT INTO "AC_MAST"(tenant_id,"CO_CODE","LC_CODE","AC_CODE","AC_NAME","AC_MOBILE") VALUES($1,'01','01',$2,$3,$4)`,
      code,
      name,
      mobile,
    );
  await sql(`INSERT INTO "ITEM_MAST"(tenant_id,"CO_CODE","IT_CODE","IT_NAME","IT_TYPE","PR_CODE","RATE_TYPE")
    VALUES($1,'01','WR916','L RING 916','G','LR','G'),($1,'01','W999','999 GOLD','G','FN','G')`);
  for (const t of TAGS) {
    await sql(
      `INSERT INTO "BAR_DETL"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","VCH_DATE","BOOK_NAME",
         "INOUT_TYPE","TAG_NO","VCH_SRNO","IT_CODE","ITM_PCS","ITM_GWT","ITM_OTH_WT","ITM_NWT","ITM_TOUCH","ITM_WEST_PRC",
         "ITM_FINE","TBL_CODE","KR_NAME","PR_CODE","LBR_TYPE","LBR_RATE","RATE_TYPE","EMP_ISU")
       VALUES($1,'01','01','2024-2025','WPB','00001',1,'2024-05-01','PURCHASE','I',$2,$3,'WR916',1,$4,0,$4,92,5,
              $5,'001',$6,'LR',$7,$8,'G','N')`,
      t.tag,
      t.id,
      t.gwt,
      t.fine,
      t.kr,
      t.lbrType,
      t.lbrRate,
    );
    await sql(
      `INSERT INTO "MAIN_STOCK"(tenant_id,"CO_CODE","LC_CODE","CO_YEAR","CO_BOOK","VCH_NO","SR_NO","ISR_NO","VCH_DATE",
         "IT_CODE","TAG_NO","VCH_SRNO","TR_TYPE","ITM_SIGN","ITM_QTY","ITM_PCS","ITM_GWT","ITM_NWT")
       VALUES($1,'01','01','2024-2025','WPB','00001',2,1,'2024-05-01','WR916',$2,$3,'P','+',1,1,$4,$4)`,
      t.tag,
      t.id,
      t.gwt,
    );
  }
}

export async function cleanupWholesaleRateCut(sql) {
  for (const table of [
    'RATE_CUT_REC',
    'RATE_CUT_ISU',
    'RATE_CUT_DATA',
    'AC_DATA',
    'ROJ_MEL_DATA',
    'DELETE_DATA',
    'MAIN_STOCK',
    'BOOK_DETL',
    'BOOK_DATA',
  ])
    await sql(`DELETE FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK" = ANY($2::text[])`, [
      ...BOOKS,
      'WPB',
    ]);
  await sql(`DELETE FROM "BAR_DETL" WHERE tenant_id=$1 AND "TAG_NO" LIKE 'WTAG%'`);
  await sql(`DELETE FROM "ITEM_MAST" WHERE tenant_id=$1 AND "IT_CODE" IN ('WR916','W999')`);
  await sql(
    `DELETE FROM "AC_MAST" WHERE tenant_id=$1 AND "AC_CODE" = ANY($2::text[])`,
    ACCOUNTS.map(([code]) => code),
  );
}

/** Type into a picker, wait for the code in its list, and take it with Enter (the desktop's F1 help). */
async function pick(page, label, code) {
  const input = page.getByLabel(label, { exact: true });
  await input.fill(code);
  await input.locator('xpath=..').getByText(code, { exact: true }).first().waitFor();
  await input.press('Enter');
}

async function bookValue(page, expected) {
  const book = page.getByRole('combobox', { name: 'Configured book', exact: true });
  for (let i = 0; i < 50 && (await book.inputValue()) !== expected; i++)
    await page.waitForTimeout(100);
  assert.equal(await book.inputValue(), expected);
  return (await book.locator('option').allTextContents()).filter((text) => text.includes('—'));
}

async function value(page, label, expected) {
  const input = page.getByLabel(label, { exact: true });
  for (let i = 0; i < 50 && (await input.inputValue()) !== expected; i++)
    await page.waitForTimeout(100);
  assert.equal(await input.inputValue(), expected, label);
}

async function text(page, testId, expected) {
  const node = page.getByTestId(testId);
  const matches = (actual) =>
    expected instanceof RegExp ? expected.test(actual) : actual.trim() === expected;
  for (let i = 0; i < 50 && !matches((await node.textContent()) ?? ''); i++)
    await page.waitForTimeout(100);
  const actual = (await node.textContent()) ?? '';
  assert(matches(actual), `${testId}: expected ${expected}, got ${JSON.stringify(actual)}`);
}

export async function exerciseWholesaleRateCut(page, { checkpoint, owner, tenantId }) {
  const rows = (query, ...params) => owner.$queryRawUnsafe(query, tenantId, ...params);
  const legs = (book) =>
    rows(
      `SELECT right("LEDR_KEY",2) AS leg,"AC_CODE" AS ac,"DR_AMT"::float8 AS dr,"CR_AMT"::float8 AS cr,
              "IT_TYPE" AS it,"SIGN" AS sign,"FINE_WT"::float8 AS fine,"FINE_RATE"::float8 AS rate
         FROM "AC_DATA" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "LEDR_KEY"`,
      book,
    );
  const stock = (book) =>
    rows(
      `SELECT "SR_NO"::int AS sr,"TAG_NO" AS tag,"IT_CODE" AS it,"ITM_SIGN" AS sign,"ITM_FINE"::float8 AS fine,
              "VCH_SRNO"::float8 AS id
         FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "CO_BOOK"=$2 ORDER BY "SR_NO","TAG_NO"`,
      book,
    );
  // A tag is in stock while its signed MAIN_STOCK balance is positive (the desktop's HAVING SUM(...) > 0).
  const inStock = async (tag) =>
    Number(
      (
        await rows(
          `SELECT coalesce(sum(CASE WHEN "ITM_SIGN"='+' THEN 1 ELSE -1 END),0)::int AS n
             FROM "MAIN_STOCK" WHERE tenant_id=$1 AND "TAG_NO"=$2`,
          tag,
        )
      )[0].n,
    ) > 0;
  const statusIs = (prefix, expected) => text(page, `${prefix}-status`, expected);

  // ---- Wholesale Sale: create ------------------------------------------------------------------
  await page.goto('/txn/wholesale-sale');
  await page.getByRole('heading', { name: 'Wholesale Sale', exact: true }).waitFor();
  // CurBookHelp("WH SALES"): the only WH SALES book is chosen by itself and the RATE CUT book is not offered.
  assert.deepEqual(await bookValue(page, 'WSB'), ['WSB — Browser Wh Sales']);
  await page.getByLabel('Date', { exact: true }).fill('2024-06-20');
  await pick(page, 'Party', 'WHPARTY');
  // Choosing the party fills its name and mobile (TR_WH_SALE.cs:14621-14623).
  await value(page, 'Party name', 'Wholesale browser party');
  await value(page, 'Mobile', '9856525');

  await pick(page, 'TagNo Issue line 1', 'WTAG001');
  // The tag brings its weights, purity, stored fine and labour: Math.Round((12.3 + 0) × 150) = 1845.
  await value(page, 'GrWt Issue line 1', '12.3');
  await value(page, 'Fine Issue line 1', '11.931');
  await value(page, 'LbrAmt Issue line 1', '1845.00');
  await value(page, 'NetAmt Issue line 1', '1845.00');
  // A typed tag number resolves on leaving the cell, as the desktop resolves it on Enter.
  const second = page.getByLabel('TagNo Issue line 2', { exact: true });
  await second.fill('WTAG002');
  await second.locator('xpath=..').getByText('WTAG002', { exact: true }).first().waitFor();
  await second.press('Escape');
  await second.press('Tab');
  await value(page, 'Fine Issue line 2', '12.610');

  await pick(page, 'ItCode Receive line 1', 'W999');
  await page.getByLabel('GrWt Receive line 1', { exact: true }).fill('20');
  await value(page, 'NetWt Receive line 1', '20');
  await page.getByLabel('Touch Receive line 1', { exact: true }).fill('100');
  await value(page, 'Fine Receive line 1', '20.000');

  await page.getByLabel('1gm Rate', { exact: true }).fill('6500');
  await page.getByLabel('Ac Fine Cr', { exact: true }).fill('4.54');
  // BILL_TOTAL: Ac Amt Dr = Math.Round(4.54 × 6500) = 29510, derived because it was left blank.
  await text(page, 'wholesale-sale-derived-settleDrAmt', '= 29510.00 (derived)');
  await page.getByLabel('Received Cash Amt', { exact: true }).fill('30000');
  await page.getByLabel('Received Kasar Amt', { exact: true }).fill('5');
  // Received net = Math.Round(29510 + 1845) = 31355; Os = 31355 − 30000 − 5 = 1350.
  await text(page, 'wholesale-sale-received-net', '31355.00');
  await text(page, 'wholesale-sale-received-os', '1350.00');
  await text(page, 'wholesale-sale-payment-os', '0.00');
  await text(page, 'wholesale-sale-diff-amount', /^1350\.00\s+Rec$/);
  // Tot fine Dr = 11.931 + 12.610 (unpriced issued) + 0; Cr = 20 + 4.54; Os fine 0.001.
  await text(page, 'wholesale-sale-tot-fine-dr', '24.541');
  await text(page, 'wholesale-sale-tot-fine-cr', '24.540');
  await text(page, 'wholesale-sale-os-fine', '0.001');
  await checkpoint('wholesale-sale-before-save', page);
  await page.getByRole('button', { name: 'Save', exact: true }).click();
  await statusIs('wholesale-sale', 'Saved voucher 00001');

  const [header] = await rows(
    `SELECT "VCH_NO",left("VCH_DATE"::text,10) AS day,"AC_CODE","AC_NAME","MOBILE","FINE_RATE"::float8 AS rate,
            "CR_FINE"::float8 AS cr_fine,"DR_AMT"::float8 AS dr_amt,"SL_FINE"::float8 AS sl_fine,
            "PR_FINE"::float8 AS pr_fine,"TOT_FINE_DR"::float8 AS tot_dr,"TOT_FINE_CR"::float8 AS tot_cr,
            "SL_LBR_AMT"::float8 AS lbr,"SL_NET_AMT"::float8 AS net,"SL_CASH_AMT"::float8 AS cash,
            "SL_KASAR_AMT"::float8 AS kasar,"SL_BILL_OS"::float8 AS os,"MAIN_USER"
       FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WSB'`,
  );
  assert.deepEqual(header, {
    VCH_NO: '00001',
    day: '2024-06-20',
    AC_CODE: 'WHPARTY',
    AC_NAME: 'Wholesale browser party',
    MOBILE: '9856525',
    rate: 6500,
    cr_fine: 4.54,
    dr_amt: 29510,
    sl_fine: 24.541,
    pr_fine: 20,
    tot_dr: 24.541,
    tot_cr: 24.54,
    lbr: 1845,
    net: 31355,
    cash: 30000,
    kasar: 5,
    os: 1350,
    MAIN_USER: 'browser',
  });
  assert.deepEqual(
    await rows(
      `SELECT "TAG_NO","VCH_SRNO"::float8 AS id,"ITM_FINE"::float8 AS fine,"LBR_TYPE","LBR_AMT"::float8 AS lbr,
              "NET_AMT"::float8 AS net FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"='WSB' ORDER BY "SR_NO"`,
    ),
    [
      { TAG_NO: 'WTAG001', id: 900000001, fine: 11.931, LBR_TYPE: 'N', lbr: 1845, net: 1845 },
      { TAG_NO: 'WTAG002', id: 900000002, fine: 12.61, LBR_TYPE: '', lbr: 0, net: 0 },
    ],
  );
  // MAIN_STOCK: the issued tags leave on SR_NO 1 ('-'), the received metal comes in on SR_NO 2 ('+').
  assert.deepEqual(await stock('WSB'), [
    { sr: 1, tag: 'WTAG001', it: 'WR916', sign: '-', fine: 11.931, id: 900000001 },
    { sr: 1, tag: 'WTAG002', it: 'WR916', sign: '-', fine: 12.61, id: 900000002 },
    { sr: 2, tag: 'N', it: 'W999', sign: '+', fine: 20, id: 0 },
  ]);
  // Wh_Sales_Ledr: 01/02 the cut (party Dr 29510 at 6500 for 4.540 fine), 15/16 labour, 23 the issued fine,
  // 29 the received fine, 43/44 cash received, 47/48 sale kasar.
  assert.deepEqual(
    (await legs('WSB')).map(({ leg, ac, dr, cr, sign, fine, rate }) => [
      leg,
      ac,
      dr,
      cr,
      sign,
      fine,
      rate,
    ]),
    [
      ['01', 'WHPARTY', 29510, 0, '+', 4.54, 6500],
      ['02', 'WSGOLD', 0, 29510, '', 0, 6500],
      ['15', 'WHPARTY', 1845, 0, '', 0, 0],
      ['16', 'WLBRIN', 0, 1845, '', 0, 0],
      ['23', 'WHPARTY', 0, 0, '-', 24.541, 0],
      ['29', 'WHPARTY', 0, 0, '+', 20, 0],
      ['43', 'WHPARTY', 0, 30000, '', 0, 0],
      ['44', 'CASH', 30000, 0, '', 0, 0],
      ['47', 'WHPARTY', 0, 5, '', 0, 0],
      ['48', 'WKASAR', 5, 0, '', 0, 0],
    ],
  );
  assert.equal(await inStock('WTAG001'), false);
  assert.equal(await inStock('WTAG002'), false);
  // The saved voucher is reloaded onto the screen: every figure shown is the stored one.
  await value(page, 'Fine Issue line 1', '11.931');
  await text(page, 'wholesale-sale-received-net', '31355.00');
  await page.getByRole('button', { name: 'Update', exact: true }).waitFor();
  await checkpoint('wholesale-sale-saved', page);

  // ---- edit: drop the second tag; it returns to stock --------------------------------------------
  await page.getByRole('button', { name: 'Remove Issue line 2', exact: true }).click();
  await text(page, 'wholesale-sale-tot-fine-dr', '11.931');
  await page.getByRole('button', { name: 'Update', exact: true }).click();
  await statusIs('wholesale-sale', 'Updated voucher 00001');
  assert.deepEqual(await stock('WSB'), [
    { sr: 1, tag: 'WTAG001', it: 'WR916', sign: '-', fine: 11.931, id: 900000001 },
    { sr: 2, tag: 'N', it: 'W999', sign: '+', fine: 20, id: 0 },
  ]);
  assert.equal(await inStock('WTAG002'), true);
  const [edited] = await rows(
    `SELECT "SL_FINE"::float8 AS sl_fine,"TOT_FINE_DR"::float8 AS tot_dr,"DR_AMT"::float8 AS dr_amt,
            "SL_NET_AMT"::float8 AS net,"SL_BILL_OS"::float8 AS os,"MAIN_USER"
       FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WSB'`,
  );
  // The stored Ac Amt Dr is re-sent, not re-derived; the edit keeps the creating user.
  assert.deepEqual(edited, {
    sl_fine: 11.931,
    tot_dr: 11.931,
    dr_amt: 29510,
    net: 31355,
    os: 1350,
    MAIN_USER: 'browser',
  });

  // ---- reopen by number ----------------------------------------------------------------------
  await page.getByRole('button', { name: 'New', exact: true }).click();
  await value(page, 'Party name', '');
  await page.getByLabel('Voucher No', { exact: true }).fill('1');
  await page.getByRole('button', { name: 'Load', exact: true }).click();
  await statusIs('wholesale-sale', 'Loaded voucher 00001');
  await value(page, 'Party name', 'Wholesale browser party');
  await value(page, 'TagNo Issue line 1', 'WTAG001');
  await value(page, 'Fine Receive line 1', '20.000');
  await text(page, 'wholesale-sale-received-os', '1350.00');

  // ---- delete: audited, and every tag back in stock -----------------------------------------------
  page.once('dialog', (dialog) => dialog.accept());
  await page.getByRole('button', { name: 'Delete', exact: true }).click();
  await statusIs('wholesale-sale', 'Deleted voucher 00001');
  for (const table of ['RATE_CUT_DATA', 'RATE_CUT_ISU', 'RATE_CUT_REC', 'MAIN_STOCK', 'AC_DATA'])
    assert.deepEqual(
      await rows(`SELECT 1 FROM "${table}" WHERE tenant_id=$1 AND "CO_BOOK"='WSB'`),
      [],
      `${table} rows remain after delete`,
    );
  assert.deepEqual(
    await rows(
      `SELECT "VCH_NO","BOOK_NAME","DELETE_USER" FROM "DELETE_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='WSB'`,
    ),
    [{ VCH_NO: '00001', BOOK_NAME: 'Browser Wh Sales', DELETE_USER: 'browser' }],
  );
  assert.equal(await inStock('WTAG001'), true);
  assert.equal(await inStock('WTAG002'), true);
  // The picker offers both tags again.
  const probe = page.getByLabel('TagNo Issue line 1', { exact: true });
  await probe.fill('WTAG');
  for (const tag of ['WTAG001', 'WTAG002'])
    await probe.locator('xpath=..').getByText(tag, { exact: true }).first().waitFor();
  await probe.press('Escape');

  // ---- Rate Cut: a header-only purchase-side cut -------------------------------------------------
  await page.goto('/txn/rate-cut');
  await page.getByRole('heading', { name: 'Rate Cut', exact: true }).waitFor();
  assert.deepEqual(await bookValue(page, 'RCB'), ['RCB — Browser Rate Cut']);
  await page.getByLabel('Date', { exact: true }).fill('2024-06-21');
  await pick(page, 'Party', 'WHPARTY');
  await page.getByLabel('1gm Rate', { exact: true }).fill('7000');
  await page.getByLabel('Ac Fine Dr', { exact: true }).fill('2.5');
  // Ac Amt Cr = Math.Round(2.5 × 7000) = 17500; paid in cash 17000 with kasar 10: Payment Os 490.
  await text(page, 'rate-cut-derived-settleCrAmt', '= 17500.00 (derived)');
  await page.getByLabel('Payment Cash Amt', { exact: true }).fill('17000');
  await page.getByLabel('Payment Kasar Amt', { exact: true }).fill('10');
  await text(page, 'rate-cut-payment-net', '17500.00');
  await text(page, 'rate-cut-payment-os', '490.00');
  await text(page, 'rate-cut-diff-amount', /^490\.00\s+Pay$/);
  await page.getByRole('button', { name: 'Save', exact: true }).click();
  await statusIs('rate-cut', 'Saved voucher 00001');
  const [cut] = await rows(
    `SELECT "DR_FINE"::float8 AS dr_fine,"CR_AMT"::float8 AS cr_amt,"FINE_RATE"::float8 AS rate,
            "PR_NET_AMT"::float8 AS net,"PR_CASH_AMT"::float8 AS cash,"PR_KASAR_AMT"::float8 AS kasar,
            "PR_BILL_OS"::float8 AS os,"TOT_FINE_DR"::float8 AS tot_dr,"TOT_FINE_CR"::float8 AS tot_cr
       FROM "RATE_CUT_DATA" WHERE tenant_id=$1 AND "CO_BOOK"='RCB'`,
  );
  assert.deepEqual(cut, {
    dr_fine: 2.5,
    cr_amt: 17500,
    rate: 7000,
    net: 17500,
    cash: 17000,
    kasar: 10,
    os: 490,
    tot_dr: 2.5,
    tot_cr: 0,
  });
  assert.deepEqual(
    await rows(`SELECT 1 FROM "RATE_CUT_ISU" WHERE tenant_id=$1 AND "CO_BOOK"='RCB'`),
    [],
  );
  // Legs 08/09 the cut (party Cr 17500 at 7000 for 2.500 fine), 45/46 cash paid, 51/52 purchase kasar.
  assert.deepEqual(
    (await legs('RCB')).map(({ leg, ac, dr, cr, sign, fine, rate }) => [
      leg,
      ac,
      dr,
      cr,
      sign,
      fine,
      rate,
    ]),
    [
      ['08', 'WHPARTY', 0, 17500, '-', 2.5, 7000],
      ['09', 'WPGOLD', 17500, 0, '', 0, 0],
      ['45', 'WHPARTY', 17000, 0, '', 0, 0],
      ['46', 'CASH', 0, 17000, '', 0, 0],
      ['51', 'WHPARTY', 10, 0, '', 0, 0],
      ['52', 'WKASAR', 0, 10, '', 0, 0],
    ],
  );
  await checkpoint('rate-cut-saved', page);
  return {
    checks: [
      'wholesale page offers only the WH SALES book and the rate-cut page only the RATE CUT book',
      'party pick fills name and mobile; picked and typed tags fill weights, stored fine and labour',
      'preview figures (fine, labour, derived Ac Amt Dr, band net/Os, tot fine, diff) equal the stored header',
      'RATE_CUT_ISU, MAIN_STOCK SR_NO 1/2 and the ten Wh_Sales_Ledr legs read back from the database',
      'edit dropping a tag returns it to stock and keeps DR_AMT and MAIN_USER',
      'reopen by voucher number restores the form from the stored rows',
      'delete removes every row, writes DELETE_DATA with the signed-in user and releases both tags',
      'header-only rate cut derives Ac Amt Cr and posts legs 08/09, 45/46, 51/52 in the Payment column',
    ],
    boundary:
      'Engineering evidence on a synthetic fixture; not an independent desktop comparison or business acceptance',
  };
}
